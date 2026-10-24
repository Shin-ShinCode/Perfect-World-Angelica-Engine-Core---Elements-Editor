using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class ListTools
{
	[McpServerTool]
	[Description("Get all available element lists with their index, name, universal name, item count, and field count. Use this first to discover what data is available.")]
	public static async Task<string> get_all_lists(AceBridgeClient bridge)
	{
		return await MetadataTools.SafeCall(bridge, "get_all_lists");
	}

	[McpServerTool]
	[Description("Get detailed information about a specific list by its name (e.g. 'WEAPON', 'ARMOR', 'NPC'). Returns list index, names, item/field counts, and all field definitions.")]
	public static async Task<string> get_list_by_name(AceBridgeClient bridge, [Description("The name of the list to look up (e.g. 'WEAPON', 'ARMOR', 'NPC_ESSENCE')")] string name)
	{
		return await MetadataTools.SafeCall(bridge, "get_list_by_name", new { name });
	}

	[McpServerTool]
	[Description("Get detailed information about a specific list by its index number. Returns list index, names, item/field counts, and all field definitions.")]
	public static async Task<string> get_list_by_idx(AceBridgeClient bridge, [Description("The zero-based index of the list")] int index)
	{
		return await MetadataTools.SafeCall(bridge, "get_list_by_idx", new { index });
	}

	[McpServerTool]
	[Description("Get the predefined list groups: matters (items/materials), equipment (armor/weapons), npc_mob_mine (NPCs/monsters/mines), and all lists.")]
	public static async Task<string> get_list_groups(AceBridgeClient bridge)
	{
		return await MetadataTools.SafeCall(bridge, "get_list_groups");
	}
}
