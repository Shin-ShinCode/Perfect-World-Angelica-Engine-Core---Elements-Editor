namespace ACE.Mcp;

internal interface IAceMcpChangeOperation
{
	string Domain { get; }

	string OperationType { get; }

	object Describe();

	void Apply();
}
