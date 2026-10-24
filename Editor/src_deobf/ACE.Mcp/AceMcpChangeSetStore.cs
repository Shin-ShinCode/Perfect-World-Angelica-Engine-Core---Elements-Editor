using System;
using System.Collections.Generic;
using System.Globalization;

namespace ACE.Mcp;

internal sealed class AceMcpChangeSetStore : IAceMcpChangeSetStore
{
	private readonly Dictionary<string, AceMcpChangeSet> dictionary_0 = new Dictionary<string, AceMcpChangeSet>(StringComparer.OrdinalIgnoreCase);

	private readonly object object_0 = new object();

	public AceMcpChangeSet Create(IReadOnlyList<IAceMcpChangeOperation> operations, IReadOnlyCollection<string> warnings)
	{
		AceMcpChangeSet aceMcpChangeSet = new AceMcpChangeSet
		{
			Id = Guid.NewGuid().ToString(Class16.smethod_0(1648930778)),
			CreatedAtUtc = DateTime.UtcNow.ToString(Class16.smethod_0(1649130914), CultureInfo.InvariantCulture)
		};
		foreach (IAceMcpChangeOperation operation in operations)
		{
			aceMcpChangeSet.Operations.Add(operation);
			if (!aceMcpChangeSet.SourceFingerprints.ContainsKey(operation.Domain))
			{
				aceMcpChangeSet.SourceFingerprints[operation.Domain] = AceMcpRuntime.GetDomainFingerprint(operation.Domain);
			}
		}
		foreach (string warning in warnings)
		{
			aceMcpChangeSet.Warnings.Add(warning);
		}
		lock (object_0)
		{
			dictionary_0[aceMcpChangeSet.Id] = aceMcpChangeSet;
			return aceMcpChangeSet;
		}
	}

	public AceMcpChangeSet Get(string changeSetId)
	{
		lock (object_0)
		{
			AceMcpChangeSet value;
			return (changeSetId == null || !dictionary_0.TryGetValue(changeSetId, out value)) ? null : value;
		}
	}

	public bool Remove(string changeSetId)
	{
		lock (object_0)
		{
			return changeSetId != null && dictionary_0.Remove(changeSetId);
		}
	}
}
