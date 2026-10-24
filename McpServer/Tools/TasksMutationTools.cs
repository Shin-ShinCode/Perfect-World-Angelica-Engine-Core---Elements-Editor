using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class TasksMutationTools
{
	[McpServerTool]
	[Description("Get a task by its numeric task ID.")]
	public static async Task<string> get_task_by_id(AceBridgeClient bridge, [Description("The numeric task ID")] int task_id)
	{
		return await MetadataTools.SafeCommand(bridge, "tasks", "get_task_by_id", new { task_id });
	}

	[McpServerTool]
	[Description("Search tasks by name substring.")]
	public static async Task<string> query_tasks(AceBridgeClient bridge, [Description("Name substring to search for")] string query, [Description("Maximum number of results to return")] int limit = 50)
	{
		return await MetadataTools.SafeCommand(bridge, "tasks", "query_tasks", new { query, limit });
	}

	[McpServerTool]
	[Description("Read selected task fields by property path for one or more task IDs.")]
	public static async Task<string> read_task_fields(AceBridgeClient bridge, [Description("Array of task IDs")] int[] task_ids, [Description("Optional JSON array string of property paths. If omitted, a default summary is returned.")] string field_paths_json = "")
	{
		return await MetadataTools.SafeCommand(bridge, "tasks", "read_fields", new { task_ids, field_paths = field_paths_json });
	}

	[McpServerTool]
	[Description("Preview setting task fields by property path. fields_json must be a JSON object mapping property path to new value.")]
	public static async Task<string> preview_set_task_fields(AceBridgeClient bridge, [Description("Array of task IDs to update")] int[] task_ids, [Description("JSON object string mapping property path to new value")] string fields_json)
	{
		return await MetadataTools.SafeCommand(bridge, "tasks", "set_task_fields", new { execution_mode = "preview", task_ids, fields_json });
	}

	[McpServerTool]
	[Description("Preview cloning one or more tasks. If parent_id is set, the clones are inserted as children of that task; otherwise they are appended as root tasks.")]
	public static async Task<string> preview_clone_tasks(AceBridgeClient bridge, [Description("Array of source task IDs")] int[] task_ids, [Description("If true, assign new unique task IDs to the cloned tree")] bool assign_new_ids = true, [Description("Optional parent task ID for the clones. Use -1 to append as root tasks.")] int parent_id = -1)
	{
		return await MetadataTools.SafeCommand(bridge, "tasks", "clone_tasks", new { execution_mode = "preview", task_ids, assign_new_ids, parent_id });
	}

	[McpServerTool]
	[Description("Preview creating a new task. fields_json is optional and can initialize task properties.")]
	public static async Task<string> preview_add_task(AceBridgeClient bridge, [Description("Optional parent task ID. Use -1 to create a root task.")] int parent_id = -1, [Description("Optional JSON object string mapping property path to initial value")] string fields_json = "{}")
	{
		return await MetadataTools.SafeCommand(bridge, "tasks", "add_task", new { execution_mode = "preview", parent_id, fields_json });
	}

	[McpServerTool]
	[Description("Preview deleting one or more tasks by ID.")]
	public static async Task<string> preview_delete_tasks(AceBridgeClient bridge, [Description("Array of task IDs to delete")] int[] task_ids)
	{
		return await MetadataTools.SafeCommand(bridge, "tasks", "delete_tasks", new { execution_mode = "preview", task_ids });
	}

	[McpServerTool]
	[Description("Preview moving a task to a new parent. Use new_parent_id=-1 to move the task to the root list.")]
	public static async Task<string> preview_reparent_tasks(AceBridgeClient bridge, [Description("Task ID to move")] int task_id, [Description("New parent task ID, or -1 to move to root")] int new_parent_id = -1)
	{
		return await MetadataTools.SafeCommand(bridge, "tasks", "reparent_tasks", new { execution_mode = "preview", task_id, new_parent_id });
	}

	[McpServerTool]
	[Description("Preview replacing task IDs across the task file. id_map_json must be a JSON object mapping old ID to new ID.")]
	public static async Task<string> preview_replace_task_ids(AceBridgeClient bridge, [Description("JSON object string mapping old task IDs to new task IDs")] string id_map_json)
	{
		return await MetadataTools.SafeCommand(bridge, "tasks", "replace_task_ids", new { execution_mode = "preview", id_map_json });
	}
}
