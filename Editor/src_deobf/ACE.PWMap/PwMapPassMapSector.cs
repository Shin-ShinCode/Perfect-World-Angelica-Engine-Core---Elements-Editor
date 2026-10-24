using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapPassMapSector
{
	private bool bool_0;

	[JsonProperty("dungeon")]
	public bool Dungeon
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}
}
