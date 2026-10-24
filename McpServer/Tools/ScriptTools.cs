using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class ScriptTools
{
	[McpServerTool]
	[Description("Run an ACE Script inline in preview mode. The script can be JSON or YAML and produces a change set when it contains mutating steps.")]
	public static async Task<string> preview_run_ace_script(AceBridgeClient bridge, [Description("ACE Script document as JSON or YAML")] string script)
	{
		return await MetadataTools.SafeCommand(bridge, "script", "run", new { execution_mode = "preview", script });
	}

	[McpServerTool]
	[Description("Run an ACE Script file in preview mode. The file can contain JSON or YAML.")]
	public static async Task<string> preview_run_ace_script_file(AceBridgeClient bridge, [Description("Path to the ACE Script file")] string path)
	{
		return await MetadataTools.SafeCommand(bridge, "script", "run", new { execution_mode = "preview", path });
	}

	[McpServerTool]
	[Description("Run an ACE Script inline in unsafe direct mode. Mutating steps are applied immediately to the loaded editor state.")]
	public static async Task<string> run_ace_script_unsafe(AceBridgeClient bridge, [Description("ACE Script document as JSON or YAML")] string script)
	{
		return await MetadataTools.SafeCommand(bridge, "script", "run", new { execution_mode = "unsafe", script });
	}

	[McpServerTool]
	[Description("Run an ACE Script file in unsafe direct mode. Mutating steps are applied immediately to the loaded editor state.")]
	public static async Task<string> run_ace_script_file_unsafe(AceBridgeClient bridge, [Description("Path to the ACE Script file")] string path)
	{
		return await MetadataTools.SafeCommand(bridge, "script", "run", new { execution_mode = "unsafe", path });
	}
}
