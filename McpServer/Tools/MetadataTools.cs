using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class MetadataTools
{
	[McpServerTool]
	[Description("Check if UniversalDataEditor is running and if elements.data is loaded. Returns connection status, list count, and total items.")]
	public static async Task<string> get_status(AceBridgeClient bridge)
	{
		return await SafeCall(bridge, "get_status");
	}

	[McpServerTool]
	[Description("Get detailed information about the loaded elements.data file including game name, version, config version, total lists and items count.")]
	public static async Task<string> get_loaded_file_info(AceBridgeClient bridge)
	{
		return await SafeCall(bridge, "get_loaded_file_info");
	}

	internal static async Task<string> SafeCall(AceBridgeClient bridge, string method, object? parameters = null)
	{
		try
		{
			return FormatJson(await bridge.SendRequestAsync(method, parameters));
		}
		catch (Exception ex)
		{
			return JsonSerializer.Serialize(new { error = true, message = ex.Message, tool = method });
		}
	}

	internal static async Task<string> SafeCommand(AceBridgeClient bridge, string domain, string action, object? parameters = null)
	{
		try
		{
			return FormatJson(await bridge.SendCommandAsync(domain, action, parameters));
		}
		catch (Exception ex)
		{
			return JsonSerializer.Serialize(new { error = true, message = ex.Message, domain, action });
		}
	}

	internal static string FormatJson(JsonElement element)
	{
		return JsonSerializer.Serialize(element, new JsonSerializerOptions
		{
			WriteIndented = true
		});
	}
}
