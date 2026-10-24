using System.Collections.Generic;

namespace ACE.Mcp;

internal interface IAceMcpChangeSetStore
{
	AceMcpChangeSet Create(IReadOnlyList<IAceMcpChangeOperation> operations, IReadOnlyCollection<string> warnings);

	AceMcpChangeSet Get(string changeSetId);

	bool Remove(string changeSetId);
}
