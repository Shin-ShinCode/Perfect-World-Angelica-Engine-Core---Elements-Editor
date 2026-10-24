using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class SearchTools
{
	[McpServerTool]
	[Description("Search for items by name (case-insensitive substring match). Can search across all lists or within a specific list. Returns matching items with their list, index, ID, and name.")]
	public static async Task<string> search_items_by_name(AceBridgeClient bridge, [Description("The search query string (case-insensitive substring match)")] string query, [Description("Optional: list index to search in. If -1, searches all lists.")] int list_idx = -1, [Description("Maximum number of results to return (default: 50)")] int limit = 50)
	{
		return await MetadataTools.SafeCall(bridge, "search_items_by_name", new { query, list_idx, limit });
	}

	[McpServerTool]
	[Description("Search for items in a specific list where a given field has a specific value. Useful for finding items by specific properties like type, level, etc.")]
	public static async Task<string> search_items_by_field_value(AceBridgeClient bridge, [Description("The zero-based index of the list to search in")] int list_idx, [Description("The name of the field to compare")] string field_name, [Description("The value to search for (exact string match)")] string value, [Description("Maximum number of results to return (default: 50)")] int limit = 50)
	{
		return await MetadataTools.SafeCall(bridge, "search_items_by_field_value", new { list_idx, field_name, value, limit });
	}
}
