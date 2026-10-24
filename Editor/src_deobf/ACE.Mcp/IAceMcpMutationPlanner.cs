namespace ACE.Mcp;

internal interface IAceMcpMutationPlanner
{
	object Complete(string requestedMode, AceMcpCommandResult result, string fallbackDomain);
}
