using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class ElementsMutationTools
{
	[McpServerTool]
	[Description("Query elements items by name substring or by an exact field match. Use list_idx or list_name to scope the search.")]
	public static async Task<string> query_items(AceBridgeClient bridge, [Description("Optional name substring to search for")] string query = "", [Description("Optional list index to scope the search")] int list_idx = -1, [Description("Optional list name to scope the search")] string list_name = "", [Description("Optional field name for exact match filtering")] string field_name = "", [Description("Optional field value for exact match filtering")] string field_value = "", [Description("Maximum number of results to return")] int limit = 50)
	{
		return await MetadataTools.SafeCommand(bridge, "elements", "query_items", new { query, list_idx, list_name, field_name, field_value, limit });
	}

	[McpServerTool]
	[Description("Read selected fields from one or more items in an elements list.")]
	public static async Task<string> read_elements_fields(AceBridgeClient bridge, [Description("List index that contains the items")] int list_idx, [Description("Array of item IDs")] int[] item_ids, [Description("Optional JSON array string of field names. If omitted, all fields are returned.")] string field_names_json = "")
	{
		return await MetadataTools.SafeCommand(bridge, "elements", "read_fields", new { list_idx, item_ids, field_names = field_names_json });
	}

	[McpServerTool]
	[Description("Preview setting one or more fields on elements items. fields_json must be a JSON object mapping field names to new values.")]
	public static async Task<string> preview_set_fields(AceBridgeClient bridge, [Description("List index that contains the items")] int list_idx, [Description("Array of item IDs to change")] int[] item_ids, [Description("JSON object string mapping field names to their new values")] string fields_json)
	{
		return await MetadataTools.SafeCommand(bridge, "elements", "set_fields", new { execution_mode = "preview", list_idx, item_ids, fields_json });
	}

	[McpServerTool]
	[Description("Preview creating a new item in an elements list. fields_json is optional and can preset field values.")]
	public static async Task<string> preview_add_item(AceBridgeClient bridge, [Description("List index where the item will be created")] int list_idx, [Description("Optional JSON object string mapping field names to values")] string fields_json = "{}", [Description("Optional insertion index; defaults to the end of the list")] int insert_at = -1, [Description("If true, generate a unique ID for the new item")] bool set_unique_id = true, [Description("Optional starting ID hint when set_unique_id=true")] int new_id = 0)
	{
		return await MetadataTools.SafeCommand(bridge, "elements", "add_item", new { execution_mode = "preview", list_idx, fields_json, insert_at, set_unique_id, new_id });
	}

	[McpServerTool]
	[Description("Preview cloning one or more elements items. Optionally assign new IDs and rewrite references.")]
	public static async Task<string> preview_clone_items(AceBridgeClient bridge, [Description("List index that contains the source items")] int list_idx, [Description("Array of source item IDs")] int[] item_ids, [Description("If true, assign new unique IDs to the clones")] bool assign_new_ids = true, [Description("If true and assign_new_ids=true, rewrite discovered references from old IDs to the new IDs")] bool refactor_references = false, [Description("Optional insertion index; defaults to the end of the list")] int insert_at = -1, [Description("Optional first ID hint when assign_new_ids=true")] int first_new_id = 0)
	{
		return await MetadataTools.SafeCommand(bridge, "elements", "clone_items", new { execution_mode = "preview", list_idx, item_ids, assign_new_ids, refactor_references, insert_at, first_new_id });
	}

	[McpServerTool]
	[Description("Preview deleting one or more items from an elements list.")]
	public static async Task<string> preview_delete_items(AceBridgeClient bridge, [Description("List index that contains the items")] int list_idx, [Description("Array of item IDs to delete")] int[] item_ids)
	{
		return await MetadataTools.SafeCommand(bridge, "elements", "delete_items", new { execution_mode = "preview", list_idx, item_ids });
	}

	[McpServerTool]
	[Description("Preview renaming one or more items in an elements list. Use either name_template or name_map_json. name_template supports {old_name}, {id} and {index}.")]
	public static async Task<string> preview_rename_items(AceBridgeClient bridge, [Description("List index that contains the items")] int list_idx, [Description("Array of item IDs to rename")] int[] item_ids, [Description("Optional template for generated names")] string name_template = "", [Description("Optional JSON object string mapping item ID to new name")] string name_map_json = "{}")
	{
		return await MetadataTools.SafeCommand(bridge, "elements", "rename_items", new { execution_mode = "preview", list_idx, item_ids, name_template, name_map_json });
	}

	[McpServerTool]
	[Description("Preview sorting items in an elements list by field index or field name.")]
	public static async Task<string> preview_sort_items(AceBridgeClient bridge, [Description("List index that contains the items")] int list_idx, [Description("Optional subset of item IDs to sort. Leave empty to sort the full list selection.")] int[] item_ids, [Description("Optional field name. If omitted, the list name field is used.")] string field_name = "", [Description("Optional field index. If >= 0, it overrides field_name.")] int field_idx = -1, [Description("If true, sort descending")] bool descending = false)
	{
		return await MetadataTools.SafeCommand(bridge, "elements", "sort_items", new { execution_mode = "preview", list_idx, item_ids, field_name, field_idx, descending });
	}

	[McpServerTool]
	[Description("Preview calculating a field value for one or more elements items using an NCalc expression. The expression can reference field names directly.")]
	public static async Task<string> preview_calculate_fields(AceBridgeClient bridge, [Description("List index that contains the items")] int list_idx, [Description("Array of item IDs to update")] int[] item_ids, [Description("Target field name that will receive the calculated value")] string target_field, [Description("NCalc expression used to produce the new value")] string expression)
	{
		return await MetadataTools.SafeCommand(bridge, "elements", "calculate_fields", new { execution_mode = "preview", list_idx, item_ids, target_field, expression });
	}

	[McpServerTool]
	[Description("Preview rewriting references from old item IDs to new item IDs. item_id_map_json must be a JSON object mapping old ID to new ID.")]
	public static async Task<string> preview_rewrite_references(AceBridgeClient bridge, [Description("List index that contains the source items")] int list_idx, [Description("JSON object string mapping old item IDs to new item IDs")] string item_id_map_json)
	{
		return await MetadataTools.SafeCommand(bridge, "elements", "rewrite_references", new { execution_mode = "preview", list_idx, item_id_map_json });
	}
}
