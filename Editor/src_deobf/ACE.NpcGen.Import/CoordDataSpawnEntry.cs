using System.Runtime.CompilerServices;

namespace ACE.NpcGen.Import;

public sealed class CoordDataSpawnEntry
{
	private readonly int int_0;

	private readonly string string_0;

	private readonly float float_0;

	private readonly float float_1;

	private readonly float float_2;

	private readonly string string_1;

	private readonly int int_1;

	public int Id
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
	}

	public string MapId
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public float Single_0
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
	}

	public float Single_1
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
	}

	public float Single_2
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
	}

	public string SourceFileName
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
	}

	public int LineNumber
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
	}

	public CoordDataSpawnEntry(int id, string mapId, float float_3, float float_4, float float_5, string sourceFileName, int lineNumber)
	{
		int_0 = id;
		string_0 = mapId ?? string.Empty;
		float_0 = float_3;
		float_1 = float_4;
		float_2 = float_5;
		string_1 = sourceFileName ?? string.Empty;
		int_1 = lineNumber;
	}
}
