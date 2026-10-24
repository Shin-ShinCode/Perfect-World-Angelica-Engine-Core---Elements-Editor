using Newtonsoft.Json.Linq;

namespace ACE.Mcp;

internal interface IAceMcpDomainHandler
{
	string Domain { get; }

	AceMcpCommandResult Execute(string action, JObject parameters);

	string GetFingerprint();
}
