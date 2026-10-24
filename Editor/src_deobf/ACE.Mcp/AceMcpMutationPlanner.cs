using System;
using System.Linq;

namespace ACE.Mcp;

internal sealed class AceMcpMutationPlanner : IAceMcpMutationPlanner
{
	[Serializable]
	private sealed class Class171
	{
		public static readonly Class171 class171_0 = new Class171();

		public static Func<IAceMcpChangeOperation, object> func_0;

		public static Func<IAceMcpChangeOperation, object> func_1;

		internal object method_0(IAceMcpChangeOperation iaceMcpChangeOperation_0)
		{
			return iaceMcpChangeOperation_0.Describe();
		}

		internal object method_1(IAceMcpChangeOperation iaceMcpChangeOperation_0)
		{
			return iaceMcpChangeOperation_0.Describe();
		}
	}

	private readonly IAceMcpChangeSetStore iaceMcpChangeSetStore_0;

	public AceMcpMutationPlanner(IAceMcpChangeSetStore changeSetStore)
	{
		iaceMcpChangeSetStore_0 = changeSetStore;
	}

	public object Complete(string requestedMode, AceMcpCommandResult result, string fallbackDomain)
	{
		if (!result.HasOperations)
		{
			return new
			{
				ok = true,
				mode = Class16.smethod_0(1649130425),
				domain = fallbackDomain,
				data = result.Data,
				warnings = result.Warnings
			};
		}
		string text = (string.IsNullOrWhiteSpace(requestedMode) ? Class16.smethod_0(1649130444) : requestedMode.Trim().ToLowerInvariant());
		if ((text == Class16.smethod_0(1649130450) || text == Class16.smethod_0(1649130471) || text == Class16.smethod_0(1649130484)) ? true : false)
		{
			foreach (IAceMcpChangeOperation operation in result.Operations)
			{
				operation.Apply();
			}
			return new
			{
				ok = true,
				mode = Class16.smethod_0(1649130450),
				domain = fallbackDomain,
				applied = true,
				operation_count = result.Operations.Count,
				operations = result.Operations.Select(Class171.class171_0.method_0).ToArray(),
				data = result.Data,
				warnings = result.Warnings
			};
		}
		AceMcpChangeSet aceMcpChangeSet = iaceMcpChangeSetStore_0.Create(result.Operations, result.Warnings);
		return new
		{
			ok = true,
			mode = Class16.smethod_0(1649130444),
			change_set_id = aceMcpChangeSet.Id,
			domains = aceMcpChangeSet.SourceFingerprints.Keys.ToArray(),
			source_fingerprints = aceMcpChangeSet.SourceFingerprints,
			preview = new
			{
				operation_count = aceMcpChangeSet.Operations.Count,
				operations = aceMcpChangeSet.Operations.Select(Class171.class171_0.method_1).ToArray()
			},
			warnings = aceMcpChangeSet.Warnings,
			can_apply = true,
			expires_on_reload = aceMcpChangeSet.ExpiresOnReload,
			data = result.Data
		};
	}
}
