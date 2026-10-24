using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NReco.Logging.File;

namespace ACE.McpServer;

/// <summary>
/// Entry point for the Angelica Core Editor MCP server.
///
/// Two transports are supported, selected by command line:
///   * default  -> stdio transport (one MCP client over stdin/stdout),
///                  hosted by a generic <see cref="Host"/>.
///   * --sse / --http -> HTTP transport on http://127.0.0.1:5489,
///                  or on all interfaces when --listen-any is also specified,
///                  hosted by an ASP.NET Core <see cref="WebApplication"/>.
///
/// In both modes the MCP server registers a singleton <see cref="AceBridgeClient"/>
/// and discovers every [McpServerTool] / [McpServerResource] in this assembly.
/// Logs are written to the console (stderr) and appended to mcp-logs.txt next to
/// the executable.
/// </summary>
// Not a static class: ILogger<Program> is resolved from DI, which requires a
// usable (non-static) type argument - matching the original assembly.
public sealed class Program
{
	private const string LocalHttpUrl = "http://127.0.0.1:5489";
	private const string NetworkHttpUrl = "http://0.0.0.0:5489";

	public static async Task Main(string[] args)
	{
		string logFilePath = Path.Combine(AppContext.BaseDirectory, "mcp-logs.txt");

		if (args.Any(arg => arg == "--sse" || arg == "--http"))
		{
			// HTTP / SSE transport via ASP.NET Core.
			bool listenOnNetwork = args.Any(arg => arg == "--listen-any");
			string[] hostArgs = args.Where(arg => arg != "--sse" && arg != "--http" && arg != "--listen-any").ToArray();
			string httpUrl = listenOnNetwork ? NetworkHttpUrl : LocalHttpUrl;
			WebApplicationBuilder builder = WebApplication.CreateBuilder(hostArgs);
			ConfigureLogging(builder.Logging, logFilePath);
			builder.Services.AddSingleton<AceBridgeClient>();
			builder.Services.AddMcpServer()
				.WithHttpTransport()
				.WithToolsFromAssembly()
				.WithResourcesFromAssembly();

			WebApplication app = builder.Build();
			app.MapMcp();
			app.Urls.Clear();
			app.Urls.Add(httpUrl);

			ILogger<Program> logger = app.Services.GetRequiredService<ILogger<Program>>();
			logger.LogInformation("ACE MCP Server starting in HTTP mode on {Url}", httpUrl);
			if (listenOnNetwork)
			{
				logger.LogWarning("Network access is enabled without MCP authentication. Restrict access with a firewall and use only on a trusted network.");
			}

			await app.RunAsync();
		}
		else
		{
			// stdio transport via the generic host.
			HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
			ConfigureLogging(builder.Logging, logFilePath);
			builder.Services.AddSingleton<AceBridgeClient>();
			builder.Services.AddMcpServer()
				.WithStdioServerTransport()
				.WithToolsFromAssembly()
				.WithResourcesFromAssembly();

			IHost host = builder.Build();
			ILogger<Program> logger = host.Services.GetRequiredService<ILogger<Program>>();
			logger.LogInformation("ACE MCP Server starting in stdio mode");

			await host.RunAsync();
		}
	}

	private static void ConfigureLogging(ILoggingBuilder logging, string logFilePath)
	{
		logging.ClearProviders();
		// Send all console logging to stderr so stdout stays clean for the stdio
		// MCP transport.
		logging.AddConsole(options => options.LogToStandardErrorThreshold = LogLevel.Trace);
		logging.AddFile(logFilePath, options =>
		{
			options.Append = true;
			options.MinLevel = LogLevel.Debug;
		});
	}
}
