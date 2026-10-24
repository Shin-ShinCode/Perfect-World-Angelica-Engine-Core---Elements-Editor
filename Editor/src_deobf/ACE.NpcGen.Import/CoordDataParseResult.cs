using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.NpcGen.Import;

public sealed class CoordDataParseResult
{
	private readonly List<CoordDataSpawnEntry> list_0 = new List<CoordDataSpawnEntry>();

	private readonly List<string> list_1 = new List<string>();

	private int int_0;

	public List<CoordDataSpawnEntry> Entries
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}

	public List<string> Maps
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
	}

	public int IgnoredLineCount
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}
}
