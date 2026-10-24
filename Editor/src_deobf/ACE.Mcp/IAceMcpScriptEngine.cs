using Newtonsoft.Json.Linq;

namespace ACE.Mcp;

internal interface IAceMcpScriptEngine
{
	object Run(JObject parameters);
}
