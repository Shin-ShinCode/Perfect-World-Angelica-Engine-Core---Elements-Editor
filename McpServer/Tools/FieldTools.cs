using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class FieldTools
{
	[McpServerTool]
	[Description("Get all field definitions for a list (field names, types, data types, sizes). Use this to understand the structure of items in a list before querying specific values.")]
	public static async Task<string> get_fields_by_list_idx(AceBridgeClient bridge, [Description("The zero-based index of the list")] int list_idx)
	{
		return await MetadataTools.SafeCall(bridge, "get_fields_by_list_idx", new { list_idx });
	}

	[McpServerTool]
	[Description("Get the value of a specific field by field name for an item at a given position (list index + item index).")]
	public static async Task<string> get_value_by_field_name(AceBridgeClient bridge, [Description("The zero-based index of the list")] int list_idx, [Description("The zero-based index of the item within the list")] int item_idx, [Description("The name of the field to read")] string field_name)
	{
		return await MetadataTools.SafeCall(bridge, "get_value_by_field_name", new { list_idx, item_idx, field_name });
	}

	[McpServerTool]
	[Description("Get the value of a specific field by field name and item ID. Automatically finds the item position. Optionally specify list_idx to narrow the search.")]
	public static async Task<string> get_value_by_field_by_name_by_item_id(AceBridgeClient bridge, [Description("The name of the field to read")] string field_name, [Description("The numeric ID of the item")] int item_id, [Description("Optional: list index to search in. If -1, searches all lists.")] int list_idx = -1)
	{
		return await MetadataTools.SafeCall(bridge, "get_value_by_field_by_name_by_item_id", new { field_name, item_id, list_idx });
	}

	[McpServerTool]
	[Description("Get detailed type information for a specific field (data type enum, byte size, type name).")]
	public static async Task<string> get_field_type_info(AceBridgeClient bridge, [Description("The zero-based index of the list")] int list_idx, [Description("The zero-based index of the field")] int field_idx)
	{
		return await MetadataTools.SafeCall(bridge, "get_field_type_info", new { list_idx, field_idx });
	}
}
