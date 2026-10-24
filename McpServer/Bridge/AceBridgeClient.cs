using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ACE.McpServer.Bridge;

/// <summary>
/// Client side of the named-pipe bridge between the ACE MCP server and the
/// running Angelica Core Editor (UniversalDataEditor) process.
///
/// Transport: a duplex named pipe "ACE_MCP_BRIDGE" carrying newline-delimited
/// UTF-8 JSON. Two request shapes are supported:
///
///   * <see cref="SendRequestAsync"/>  -> { "method": ..., "params": ... }
///       used by the read-only metadata/list/item/field/search/reference tools.
///
///   * <see cref="SendCommandAsync"/>  -> { "protocol_version", "domain",
///       "action", "params" } used by the domain mutation tools
///       (elements, tasks, aipolicy, npcgen, script, common).
///
/// Each response is one JSON line: an envelope carrying either "result" or
/// "error" { "message" }. Calls are serialized through a semaphore so a single
/// pipe is shared safely across concurrent MCP tool invocations.
/// </summary>
public sealed class AceBridgeClient : IDisposable
{
	private const string PipeName = "ACE_MCP_BRIDGE";

	private const int ConnectTimeoutMs = 5000;

	private NamedPipeClientStream? _pipe;

	private StreamReader? _reader;

	private StreamWriter? _writer;

	private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

	/// <summary>
	/// Send a plain method request: <c>{ "method": method, "params": parameters }</c>.
	/// Returns the unwrapped "result" element (or the whole root when absent).
	/// </summary>
	public async Task<JsonElement> SendRequestAsync(string method, object? parameters = null, CancellationToken ct = default)
	{
		await _lock.WaitAsync(ct);
		try
		{
			await EnsureConnectedAsync(ct);
			var request = new
			{
				method,
				@params = parameters ?? new { }
			};
			string payload = JsonSerializer.Serialize(request);
			await _writer!.WriteLineAsync(payload);
			await _writer.FlushAsync();
			string? line = await _reader!.ReadLineAsync();
			if (string.IsNullOrEmpty(line))
			{
				throw new InvalidOperationException("Empty response from ACE bridge");
			}
			using JsonDocument document = JsonDocument.Parse(line);
			JsonElement root = document.RootElement;
			if (root.TryGetProperty("error", out var error))
			{
				string message = error.TryGetProperty("message", out var messageElement)
					? (messageElement.GetString() ?? "Unknown error")
					: "Unknown error";
				throw new InvalidOperationException("ACE bridge error: " + message);
			}
			if (root.TryGetProperty("result", out var result))
			{
				return result.Clone();
			}
			return root.Clone();
		}
		catch (InvalidOperationException)
		{
			throw;
		}
		catch (Exception ex)
		{
			Disconnect();
			throw new InvalidOperationException(
				$"Connection error: {ex.GetType().Name}: {ex.Message}. Make sure UniversalDataEditor is running with elements.data loaded.", ex);
		}
		finally
		{
			_lock.Release();
		}
	}

	/// <summary>
	/// Send a domain command:
	/// <c>{ "protocol_version", "domain", "action", "params" }</c>.
	/// Used by the two-phase (preview/apply) mutation tools.
	/// Returns the unwrapped "result" element (or the whole root when absent).
	/// </summary>
	public async Task<JsonElement> SendCommandAsync(string domain, string action, object? parameters = null, int protocolVersion = 1, CancellationToken ct = default)
	{
		await _lock.WaitAsync(ct);
		try
		{
			await EnsureConnectedAsync(ct);
			var command = new
			{
				protocol_version = protocolVersion,
				domain,
				action,
				@params = parameters ?? new { }
			};
			string payload = JsonSerializer.Serialize(command);
			await _writer!.WriteLineAsync(payload);
			await _writer.FlushAsync();
			string? line = await _reader!.ReadLineAsync();
			if (string.IsNullOrEmpty(line))
			{
				throw new InvalidOperationException("Empty response from ACE bridge");
			}
			using JsonDocument document = JsonDocument.Parse(line);
			JsonElement root = document.RootElement;
			if (root.TryGetProperty("error", out var error))
			{
				string message = error.TryGetProperty("message", out var messageElement)
					? (messageElement.GetString() ?? "Unknown error")
					: "Unknown error";
				throw new InvalidOperationException("ACE bridge error: " + message);
			}
			if (root.TryGetProperty("result", out var result))
			{
				return result.Clone();
			}
			return root.Clone();
		}
		catch (InvalidOperationException)
		{
			throw;
		}
		catch (Exception ex)
		{
			Disconnect();
			throw new InvalidOperationException(
				$"Connection error: {ex.GetType().Name}: {ex.Message}. Make sure UniversalDataEditor is running with the required module loaded.", ex);
		}
		finally
		{
			_lock.Release();
		}
	}

	private async Task EnsureConnectedAsync(CancellationToken ct)
	{
		NamedPipeClientStream? pipe = _pipe;
		if (pipe == null || !pipe.IsConnected)
		{
			Disconnect();
			_pipe = new NamedPipeClientStream(".", PipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
			try
			{
				await _pipe.ConnectAsync(ConnectTimeoutMs, ct);
			}
			catch (TimeoutException)
			{
				throw new InvalidOperationException("Cannot connect to UniversalDataEditor. Make sure the app is running with elements.data loaded.");
			}
			_reader = new StreamReader(_pipe, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
			_writer = new StreamWriter(_pipe, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false))
			{
				AutoFlush = true
			};
		}
	}

	private void Disconnect()
	{
		_writer?.Dispose();
		_reader?.Dispose();
		_pipe?.Dispose();
		_writer = null;
		_reader = null;
		_pipe = null;
	}

	public void Dispose()
	{
		Disconnect();
		_lock.Dispose();
	}
}
