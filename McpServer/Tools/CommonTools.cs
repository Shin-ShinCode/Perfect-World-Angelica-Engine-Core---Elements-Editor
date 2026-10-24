using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class CommonTools
{
	[McpServerTool]
	[Description("Get the load state, source path, change flag and fingerprint for the ACE modules managed by the MCP: elements, tasks, aipolicy and npcgen.")]
	public static async Task<string> get_loaded_modules(AceBridgeClient bridge)
	{
		return await MetadataTools.SafeCommand(bridge, "common", "get_loaded_modules");
	}

	[McpServerTool]
	[Description("Load an ACE module from disk into the editor process. Supported modules: elements, tasks, aipolicy, npcgen.")]
	public static async Task<string> load_module(AceBridgeClient bridge, [Description("Module name: elements, tasks, aipolicy or npcgen")] string module, [Description("Absolute or relative path to the module file")] string path)
	{
		return await MetadataTools.SafeCommand(bridge, "common", "load_module", new { module, path });
	}

	[McpServerTool]
	[Description("Reload a previously loaded ACE module from its known file path.")]
	public static async Task<string> reload_module(AceBridgeClient bridge, [Description("Module name: elements, tasks, aipolicy or npcgen")] string module)
	{
		return await MetadataTools.SafeCommand(bridge, "common", "reload_module", new { module });
	}

	[McpServerTool]
	[Description("Save the in-memory module back to its current path. Does not create or apply a change set; it persists current editor state.")]
	public static async Task<string> save_module(AceBridgeClient bridge, [Description("Module name: elements, tasks, aipolicy or npcgen")] string module)
	{
		return await MetadataTools.SafeCommand(bridge, "common", "save_module", new { module });
	}

	[McpServerTool]
	[Description("Save the in-memory module to a new path.")]
	public static async Task<string> save_module_as(AceBridgeClient bridge, [Description("Module name: elements, tasks, aipolicy or npcgen")] string module, [Description("Destination path for the saved file")] string path)
	{
		return await MetadataTools.SafeCommand(bridge, "common", "save_module_as", new { module, path });
	}

	[McpServerTool]
	[Description("Create a raw file backup of the currently loaded module. If no path is provided, the backup path is generated automatically next to the source file.")]
	public static async Task<string> backup_module(AceBridgeClient bridge, [Description("Module name: elements, tasks, aipolicy or npcgen")] string module, [Description("Optional destination path for the backup file")] string path = "")
	{
		return await MetadataTools.SafeCommand(bridge, "common", "backup_module", new { module, path });
	}

	[McpServerTool]
	[Description("Export the current module state to a JSON file. Set include_data=true to dump the full payload instead of only a summary.")]
	public static async Task<string> export_module_json(AceBridgeClient bridge, [Description("Module name: elements, tasks, aipolicy or npcgen")] string module, [Description("Destination JSON file path")] string path, [Description("If true, export full module data instead of a summary")] bool include_data = false)
	{
		return await MetadataTools.SafeCommand(bridge, "common", "export_module_json", new { module, path, include_data });
	}

	[McpServerTool]
	[Description("Apply a previously previewed change set if the source fingerprints still match.")]
	public static async Task<string> apply_change_set(AceBridgeClient bridge, [Description("The change_set_id returned by a preview tool")] string change_set_id)
	{
		return await MetadataTools.SafeCommand(bridge, "common", "apply_change_set", new { change_set_id });
	}

	[McpServerTool]
	[Description("Discard a previously previewed change set without applying it.")]
	public static async Task<string> discard_change_set(AceBridgeClient bridge, [Description("The change_set_id returned by a preview tool")] string change_set_id)
	{
		return await MetadataTools.SafeCommand(bridge, "common", "discard_change_set", new { change_set_id });
	}
}
