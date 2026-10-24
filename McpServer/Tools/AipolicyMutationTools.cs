using System.ComponentModel;
using System.Threading.Tasks;
using ACE.McpServer.Bridge;
using ModelContextProtocol.Server;

namespace ACE.McpServer.Tools;

[McpServerToolType]
public sealed class AipolicyMutationTools
{
	[McpServerTool]
	[Description("List the AIPolicy controllers currently loaded in memory.")]
	public static async Task<string> get_aipolicy_controllers(AceBridgeClient bridge)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "get_controllers");
	}

	[McpServerTool]
	[Description("Get one AIPolicy controller by ID.")]
	public static async Task<string> get_aipolicy_controller(AceBridgeClient bridge, [Description("Controller ID")] int controller_id)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "get_controller", new { controller_id });
	}

	[McpServerTool]
	[Description("Get one AIPolicy trigger by controller ID and trigger ID.")]
	public static async Task<string> get_aipolicy_trigger(AceBridgeClient bridge, [Description("Controller ID")] int controller_id, [Description("Trigger ID")] int trigger_id)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "get_trigger", new { controller_id, trigger_id });
	}

	[McpServerTool]
	[Description("Get one AIPolicy operation by controller ID, trigger ID and operation index.")]
	public static async Task<string> get_aipolicy_operation(AceBridgeClient bridge, [Description("Controller ID")] int controller_id, [Description("Trigger ID")] int trigger_id, [Description("Zero-based operation index")] int operation_index)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "get_operation", new { controller_id, trigger_id, operation_index });
	}

	[McpServerTool]
	[Description("Preview adding a new empty AIPolicy controller.")]
	public static async Task<string> preview_add_controller(AceBridgeClient bridge)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "add_controller", new { execution_mode = "preview" });
	}

	[McpServerTool]
	[Description("Preview cloning one or more AIPolicy controllers.")]
	public static async Task<string> preview_clone_controller(AceBridgeClient bridge, [Description("Array of controller IDs to clone")] int[] controller_ids)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "clone_controller", new { execution_mode = "preview", controller_ids });
	}

	[McpServerTool]
	[Description("Preview removing one or more AIPolicy controllers.")]
	public static async Task<string> preview_remove_controller(AceBridgeClient bridge, [Description("Array of controller IDs to remove")] int[] controller_ids)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "remove_controller", new { execution_mode = "preview", controller_ids });
	}

	[McpServerTool]
	[Description("Preview adding a new trigger to a controller.")]
	public static async Task<string> preview_add_trigger(AceBridgeClient bridge, [Description("Controller ID that will receive the new trigger")] int controller_id)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "add_trigger", new { execution_mode = "preview", controller_id });
	}

	[McpServerTool]
	[Description("Preview cloning one or more triggers inside a controller.")]
	public static async Task<string> preview_clone_trigger(AceBridgeClient bridge, [Description("Controller ID that owns the triggers")] int controller_id, [Description("Array of trigger IDs to clone")] int[] trigger_ids)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "clone_trigger", new { execution_mode = "preview", controller_id, trigger_ids });
	}

	[McpServerTool]
	[Description("Preview removing one or more triggers from a controller.")]
	public static async Task<string> preview_remove_trigger(AceBridgeClient bridge, [Description("Controller ID that owns the triggers")] int controller_id, [Description("Array of trigger IDs to remove")] int[] trigger_ids)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "remove_trigger", new { execution_mode = "preview", controller_id, trigger_ids });
	}

	[McpServerTool]
	[Description("Preview renaming a trigger.")]
	public static async Task<string> preview_rename_trigger(AceBridgeClient bridge, [Description("Controller ID that owns the trigger")] int controller_id, [Description("Trigger ID to rename")] int trigger_id, [Description("New trigger name")] string name)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "rename_trigger", new { execution_mode = "preview", controller_id, trigger_id, name });
	}

	[McpServerTool]
	[Description("Preview adding a new operation to a trigger. operation_id is the numeric AIPolicy operation ID.")]
	public static async Task<string> preview_add_operation(AceBridgeClient bridge, [Description("Controller ID that owns the trigger")] int controller_id, [Description("Trigger ID that will receive the new operation")] int trigger_id, [Description("Numeric AIPolicy operation ID")] int operation_id)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "add_operation", new { execution_mode = "preview", controller_id, trigger_id, operation_id });
	}

	[McpServerTool]
	[Description("Preview cloning one or more operations inside a trigger.")]
	public static async Task<string> preview_clone_operation(AceBridgeClient bridge, [Description("Controller ID that owns the trigger")] int controller_id, [Description("Trigger ID that owns the operations")] int trigger_id, [Description("Zero-based operation indices to clone")] int[] operation_indexes)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "clone_operation", new { execution_mode = "preview", controller_id, trigger_id, operation_indexes });
	}

	[McpServerTool]
	[Description("Preview removing one or more operations from a trigger.")]
	public static async Task<string> preview_remove_operation(AceBridgeClient bridge, [Description("Controller ID that owns the trigger")] int controller_id, [Description("Trigger ID that owns the operations")] int trigger_id, [Description("Zero-based operation indices to remove")] int[] operation_indexes)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "remove_operation", new { execution_mode = "preview", controller_id, trigger_id, operation_indexes });
	}

	[McpServerTool]
	[Description("Preview setting one or more fields on an AIPolicy operation. fields_json must be a JSON object mapping property path to new value.")]
	public static async Task<string> preview_set_operation_fields(AceBridgeClient bridge, [Description("Controller ID that owns the trigger")] int controller_id, [Description("Trigger ID that owns the operation")] int trigger_id, [Description("Zero-based operation index")] int operation_index, [Description("JSON object string mapping operation property path to new value")] string fields_json)
	{
		return await MetadataTools.SafeCommand(bridge, "aipolicy", "set_operation_fields", new { execution_mode = "preview", controller_id, trigger_id, operation_index, fields_json });
	}
}
