using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ACE.McpServer.Tools;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Resources;

/// <summary>
/// Read-only MCP resources exposing the loaded ACE elements data as
/// addressable <c>ace://...</c> URIs. Each resource is a thin wrapper over a
/// bridge request, returned as formatted JSON via <see cref="MetadataTools.SafeCall"/>.
/// </summary>
[McpServerResourceType]
public sealed class AceResources
{
	[McpServerResource(UriTemplate = "ace://status", Name = "ace-status", Title = "ACE Status", MimeType = "application/json")]
	public static async Task<string> Status(AceBridgeClient bridge)
	{
		return await MetadataTools.SafeCall(bridge, "get_status");
	}

	[McpServerResource(UriTemplate = "ace://loaded-file-info", Name = "ace-loaded-file-info", Title = "Loaded File Info", MimeType = "application/json")]
	public static async Task<string> LoadedFileInfo(AceBridgeClient bridge)
	{
		return await MetadataTools.SafeCall(bridge, "get_loaded_file_info");
	}

	[McpServerResource(UriTemplate = "ace://lists", Name = "ace-all-lists", Title = "All Element Lists", MimeType = "application/json")]
	public static async Task<string> AllLists(AceBridgeClient bridge)
	{
		return await MetadataTools.SafeCall(bridge, "get_all_lists");
	}

	[McpServerResource(UriTemplate = "ace://groups", Name = "ace-list-groups", Title = "List Groups", MimeType = "application/json")]
	public static async Task<string> ListGroups(AceBridgeClient bridge)
	{
		return await MetadataTools.SafeCall(bridge, "get_list_groups");
	}

	[McpServerResource(UriTemplate = "ace://list/{idx}", Name = "ace-list-by-idx", Title = "List by Index", MimeType = "application/json")]
	public static async Task<string> ListByIdx(AceBridgeClient bridge, [Description("The zero-based index of the list")] int idx)
	{
		return await MetadataTools.SafeCall(bridge, "get_list_by_idx", new { index = idx });
	}

	[McpServerResource(UriTemplate = "ace://list/{list_idx}/fields", Name = "ace-list-fields", Title = "List Fields", MimeType = "application/json")]
	public static async Task<string> ListFields(AceBridgeClient bridge, [Description("The zero-based index of the list")] int list_idx)
	{
		return await MetadataTools.SafeCall(bridge, "get_fields_by_list_idx", new { list_idx });
	}

	[McpServerResource(UriTemplate = "ace://list/{list_idx}/items", Name = "ace-list-items", Title = "List Items (first 100)", MimeType = "application/json")]
	public static async Task<string> ListItems(AceBridgeClient bridge, [Description("The zero-based index of the list")] int list_idx)
	{
		return await MetadataTools.SafeCall(bridge, "get_items_by_list", new { list_idx, offset = 0, limit = 100 });
	}

	[McpServerResource(UriTemplate = "ace://item/{list_idx}/{item_id}", Name = "ace-item-all-fields", Title = "Item All Fields", MimeType = "application/json")]
	public static async Task<string> ItemAllFields(AceBridgeClient bridge, [Description("The zero-based index of the list")] int list_idx, [Description("The numeric ID of the item")] int item_id)
	{
		return await MetadataTools.SafeCall(bridge, "get_item_all_fields", new { list_idx, item_id });
	}

	[McpServerResource(UriTemplate = "ace://item/{list_idx}/{item_id}/references", Name = "ace-item-references", Title = "Item References", MimeType = "application/json")]
	public static async Task<string> ItemReferences(AceBridgeClient bridge, [Description("The zero-based index of the list")] int list_idx, [Description("The numeric ID of the item")] int item_id)
	{
		return await MetadataTools.SafeCall(bridge, "get_item_list_references", new { item_id, list_idx });
	}

	[McpServerResource(UriTemplate = "ace://search/{query}", Name = "ace-search", Title = "Search Items by Name", MimeType = "application/json")]
	public static async Task<string> Search(AceBridgeClient bridge, [Description("Search query string")] string query)
	{
		return await MetadataTools.SafeCall(bridge, "search_items_by_name", new { query, list_idx = -1, limit = 50 });
	}
}
