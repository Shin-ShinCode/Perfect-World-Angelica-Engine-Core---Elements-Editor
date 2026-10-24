using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class NpcGenMutationTools
{
	[McpServerTool]
	[Description("Get a high-level overview of the currently loaded npcgen document.")]
	public static async Task<string> get_npcgen_overview(AceBridgeClient bridge)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "get_npcgen_overview");
	}

	[McpServerTool]
	[Description("Query npcgen entries by kind and optional substring match.")]
	public static async Task<string> query_npcgen_entries(AceBridgeClient bridge, [Description("Kind: existence, resource, trigger or dynamic_object")] string kind, [Description("Optional substring to filter results")] string query = "", [Description("Maximum number of results to return")] int limit = 50)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "query_entries", new { kind, query, limit });
	}

	[McpServerTool]
	[Description("Get one npcgen entry by kind and zero-based index.")]
	public static async Task<string> get_npcgen_entry(AceBridgeClient bridge, [Description("Kind: existence, resource, trigger or dynamic_object")] string kind, [Description("Zero-based entry index")] int index)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "get_entry", new { kind, index });
	}

	[McpServerTool]
	[Description("Preview adding a new existence entry. entry_json is optional and can initialize the full object.")]
	public static async Task<string> preview_add_existence(AceBridgeClient bridge, [Description("Optional JSON object string for the existence entry")] string entry_json = "")
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "add_existence", new { execution_mode = "preview", entry_json });
	}

	[McpServerTool]
	[Description("Preview cloning one or more existence entries by index.")]
	public static async Task<string> preview_clone_existence(AceBridgeClient bridge, [Description("Zero-based existence indices to clone")] int[] indexes)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "clone_existence", new { execution_mode = "preview", indexes });
	}

	[McpServerTool]
	[Description("Preview removing one or more existence entries by index.")]
	public static async Task<string> preview_remove_existence(AceBridgeClient bridge, [Description("Zero-based existence indices to remove")] int[] indexes)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "remove_existence", new { execution_mode = "preview", indexes });
	}

	[McpServerTool]
	[Description("Preview moving one or more existence entries to a target index.")]
	public static async Task<string> preview_move_existence(AceBridgeClient bridge, [Description("Zero-based existence indices to move")] int[] indexes, [Description("Zero-based target index")] int target_index)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "move_existence", new { execution_mode = "preview", indexes, target_index });
	}

	[McpServerTool]
	[Description("Preview setting fields on one or more existence entries. fields_json must be a JSON object mapping property path to new value.")]
	public static async Task<string> preview_set_existence_fields(AceBridgeClient bridge, [Description("Zero-based existence indices to update")] int[] indexes, [Description("JSON object string mapping property path to new value")] string fields_json)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "set_existence_fields", new { execution_mode = "preview", indexes, fields_json });
	}

	[McpServerTool]
	[Description("Preview adding a new resource entry. entry_json is optional and can initialize the full object.")]
	public static async Task<string> preview_add_resource(AceBridgeClient bridge, [Description("Optional JSON object string for the resource entry")] string entry_json = "")
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "add_resource", new { execution_mode = "preview", entry_json });
	}

	[McpServerTool]
	[Description("Preview cloning one or more resource entries by index.")]
	public static async Task<string> preview_clone_resource(AceBridgeClient bridge, [Description("Zero-based resource indices to clone")] int[] indexes)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "clone_resource", new { execution_mode = "preview", indexes });
	}

	[McpServerTool]
	[Description("Preview removing one or more resource entries by index.")]
	public static async Task<string> preview_remove_resource(AceBridgeClient bridge, [Description("Zero-based resource indices to remove")] int[] indexes)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "remove_resource", new { execution_mode = "preview", indexes });
	}

	[McpServerTool]
	[Description("Preview moving one or more resource entries to a target index.")]
	public static async Task<string> preview_move_resource(AceBridgeClient bridge, [Description("Zero-based resource indices to move")] int[] indexes, [Description("Zero-based target index")] int target_index)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "move_resource", new { execution_mode = "preview", indexes, target_index });
	}

	[McpServerTool]
	[Description("Preview setting fields on one or more resource entries. fields_json must be a JSON object mapping property path to new value.")]
	public static async Task<string> preview_set_resource_fields(AceBridgeClient bridge, [Description("Zero-based resource indices to update")] int[] indexes, [Description("JSON object string mapping property path to new value")] string fields_json)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "set_resource_fields", new { execution_mode = "preview", indexes, fields_json });
	}

	[McpServerTool]
	[Description("Preview adding a new trigger entry. entry_json is optional and can initialize the full object.")]
	public static async Task<string> preview_add_npcgen_trigger(AceBridgeClient bridge, [Description("Optional JSON object string for the trigger entry")] string entry_json = "")
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "add_trigger", new { execution_mode = "preview", entry_json });
	}

	[McpServerTool]
	[Description("Preview cloning one or more trigger entries by index.")]
	public static async Task<string> preview_clone_npcgen_trigger(AceBridgeClient bridge, [Description("Zero-based trigger indices to clone")] int[] indexes)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "clone_trigger", new { execution_mode = "preview", indexes });
	}

	[McpServerTool]
	[Description("Preview removing one or more trigger entries by index.")]
	public static async Task<string> preview_remove_npcgen_trigger(AceBridgeClient bridge, [Description("Zero-based trigger indices to remove")] int[] indexes)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "remove_trigger", new { execution_mode = "preview", indexes });
	}

	[McpServerTool]
	[Description("Preview moving one or more trigger entries to a target index.")]
	public static async Task<string> preview_move_npcgen_trigger(AceBridgeClient bridge, [Description("Zero-based trigger indices to move")] int[] indexes, [Description("Zero-based target index")] int target_index)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "move_trigger", new { execution_mode = "preview", indexes, target_index });
	}

	[McpServerTool]
	[Description("Preview setting fields on one or more trigger entries. fields_json must be a JSON object mapping property path to new value.")]
	public static async Task<string> preview_set_trigger_fields(AceBridgeClient bridge, [Description("Zero-based trigger indices to update")] int[] indexes, [Description("JSON object string mapping property path to new value")] string fields_json)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "set_trigger_fields", new { execution_mode = "preview", indexes, fields_json });
	}

	[McpServerTool]
	[Description("Preview adding a new dynamic object entry. entry_json is optional and can initialize the full object.")]
	public static async Task<string> preview_add_dynamic_object(AceBridgeClient bridge, [Description("Optional JSON object string for the dynamic object entry")] string entry_json = "")
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "add_dynamic_object", new { execution_mode = "preview", entry_json });
	}

	[McpServerTool]
	[Description("Preview cloning one or more dynamic object entries by index.")]
	public static async Task<string> preview_clone_dynamic_object(AceBridgeClient bridge, [Description("Zero-based dynamic object indices to clone")] int[] indexes)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "clone_dynamic_object", new { execution_mode = "preview", indexes });
	}

	[McpServerTool]
	[Description("Preview removing one or more dynamic object entries by index.")]
	public static async Task<string> preview_remove_dynamic_object(AceBridgeClient bridge, [Description("Zero-based dynamic object indices to remove")] int[] indexes)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "remove_dynamic_object", new { execution_mode = "preview", indexes });
	}

	[McpServerTool]
	[Description("Preview moving one or more dynamic object entries to a target index.")]
	public static async Task<string> preview_move_dynamic_object(AceBridgeClient bridge, [Description("Zero-based dynamic object indices to move")] int[] indexes, [Description("Zero-based target index")] int target_index)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "move_dynamic_object", new { execution_mode = "preview", indexes, target_index });
	}

	[McpServerTool]
	[Description("Preview setting fields on one or more dynamic object entries. fields_json must be a JSON object mapping property path to new value.")]
	public static async Task<string> preview_set_dynamic_object_fields(AceBridgeClient bridge, [Description("Zero-based dynamic object indices to update")] int[] indexes, [Description("JSON object string mapping property path to new value")] string fields_json)
	{
		return await MetadataTools.SafeCommand(bridge, "npcgen", "set_dynamic_object_fields", new { execution_mode = "preview", indexes, fields_json });
	}
}
