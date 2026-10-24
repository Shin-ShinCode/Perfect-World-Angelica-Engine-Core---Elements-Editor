using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class MONSTERS_SUMMONED
{
	private int int_0;

	private int int_1;

	private float float_0;

	private int int_2;

	public int m_ulMonsterTemplId
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

	public int m_ulMonsterNum
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public float m_fSummonProb
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public int m_lPeriod
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, MONSTERS_SUMMONED MS)
	{
		MS.m_ulMonsterTemplId = br.ReadInt32();
		MS.m_ulMonsterNum = br.ReadInt32();
		MS.m_fSummonProb = br.ReadSingle();
		MS.m_lPeriod = br.ReadInt32();
	}

	internal static void Write(int version, BinaryWriter bw, MONSTERS_SUMMONED MS)
	{
		bw.Write(MS.m_ulMonsterTemplId);
		bw.Write(MS.m_ulMonsterNum);
		bw.Write(MS.m_fSummonProb);
		bw.Write(MS.m_lPeriod);
	}

	public static MONSTERS_SUMMONED[] NewArray(int size)
	{
		MONSTERS_SUMMONED[] array = new MONSTERS_SUMMONED[size];
		for (int i = 0; i < size; i++)
		{
			array[i] = new MONSTERS_SUMMONED();
		}
		return array;
	}
}
