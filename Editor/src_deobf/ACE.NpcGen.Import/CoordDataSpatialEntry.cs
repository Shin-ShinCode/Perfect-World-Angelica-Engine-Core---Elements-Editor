using System.Runtime.CompilerServices;

namespace ACE.NpcGen.Import;

public sealed class CoordDataSpatialEntry
{
	private readonly int int_0;

	private readonly float float_0;

	private readonly float float_1;

	private readonly float float_2;

	public int Id
	{
		[CompilerGenerated]
		get
		{
			return int_0;
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

	public CoordDataSpatialEntry(int id, float float_3, float float_4, float float_5)
	{
		int_0 = id;
		float_0 = float_3;
		float_1 = float_4;
		float_2 = float_5;
	}
}
