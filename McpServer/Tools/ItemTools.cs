using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class ItemTools
{
	[McpServerTool]
	[Description("Find an item by its numeric ID. Optionally specify a list index to search in a specific list. Returns item info including name, type, list position, icon, references, and category.")]
	public static async Task<string> get_item_by_id(AceBridgeClient bridge, [Description("The numeric ID of the item to find")] int id, [Description("Optional: list index to search in. If omitted, searches all lists.")] int list_idx = -1)
	{
		return await MetadataTools.SafeCall(bridge, "get_item_by_id", new { id, list_idx });
	}

	[McpServerTool]
	[Description("Get a paginated list of items in a specific list. Returns item index, ID, and display name for each item. Use offset/limit for pagination.")]
	public static async Task<string> get_items_by_list(AceBridgeClient bridge, [Description("The zero-based index of the list")] int list_idx, [Description("Number of items to skip (default: 0)")] int offset = 0, [Description("Maximum number of items to return (default: 100, max recommended: 500)")] int limit = 100)
	{
		return await MetadataTools.SafeCall(bridge, "get_items_by_list", new { list_idx, offset, limit });
	}

	[McpServerTool]
	[Description("Get ALL field names and values for a specific item. This returns the complete data for one item. Use this to inspect all properties of an item.")]
	public static async Task<string> get_item_all_fields(AceBridgeClient bridge, [Description("The zero-based index of the list containing the item")] int list_idx, [Description("The numeric ID of the item")] int item_id)
	{
		return await MetadataTools.SafeCall(bridge, "get_item_all_fields", new { list_idx, item_id });
	}

	[McpServerTool]
	[Description("Get basic info for multiple items at once by their IDs within a single list. Efficient batch lookup.")]
	public static async Task<string> get_multiple_items(AceBridgeClient bridge, [Description("The zero-based index of the list")] int list_idx, [Description("Array of numeric item IDs to look up")] int[] item_ids)
	{
		return await MetadataTools.SafeCall(bridge, "get_multiple_items", new { list_idx, item_ids });
	}
}
