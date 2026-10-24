using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class ReferenceTools
{
	[McpServerTool]
	[Description("Get cross-references for an item - find all other items/lists that reference this item. Useful for understanding dependencies and relationships between game elements.")]
	public static async Task<string> get_item_list_references(AceBridgeClient bridge, [Description("The numeric ID of the item to find references for")] int item_id, [Description("Optional: list index where the item is located. If -1, auto-detects.")] int list_idx = -1)
	{
		return await MetadataTools.SafeCall(bridge, "get_item_list_references", new { item_id, list_idx });
	}
}
