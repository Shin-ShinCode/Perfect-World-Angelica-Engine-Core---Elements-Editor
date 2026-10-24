using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class ITEM_WANTED
{
	private int int_0;

	private bool bool_0 = true;

	private int int_1 = 1;

	private float float_0 = 1f;

	private int int_2;

	private uint uint_0;

	public int m_ulItemTemplId
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

	public bool m_bCommonItem
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

	public int m_ulItemNum
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

	public float m_fProb
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

	public uint m_ulServerLimit
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, ITEM_WANTED ITW)
	{
		ITW.m_ulItemTemplId = br.ReadInt32();
		ITW.m_bCommonItem = br.ReadBoolean();
		ITW.m_ulItemNum = br.ReadInt32();
		ITW.m_fProb = br.ReadSingle();
		if (version >= 60)
		{
			ITW.m_lPeriod = br.ReadInt32();
		}
		if (version >= 234)
		{
			ITW.m_ulServerLimit = br.ReadUInt32();
		}
	}

	internal static void Write(int version, BinaryWriter bw, ITEM_WANTED ITW)
	{
		bw.Write(ITW.m_ulItemTemplId);
		bw.Write(ITW.m_bCommonItem);
		bw.Write(ITW.m_ulItemNum);
		bw.Write(ITW.m_fProb);
		if (version >= 60)
		{
			bw.Write(ITW.m_lPeriod);
		}
		if (version >= 234)
		{
			bw.Write(ITW.m_ulServerLimit);
		}
	}
}
