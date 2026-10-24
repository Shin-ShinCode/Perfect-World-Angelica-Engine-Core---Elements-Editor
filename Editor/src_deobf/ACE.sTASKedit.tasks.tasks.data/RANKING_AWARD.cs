using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class RANKING_AWARD
{
	private int int_0;

	private int int_1;

	private bool bool_0 = true;

	private int int_2;

	private int int_3 = 1;

	private int int_4;

	public int m_iRankingStart
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

	public int m_iRankingEnd
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

	public int m_ulAwardItemId
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

	public int m_ulAwardItemNum
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public int m_lPeriod
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, RANKING_AWARD RA)
	{
		RA.m_iRankingStart = br.ReadInt32();
		RA.m_iRankingEnd = br.ReadInt32();
		RA.m_bCommonItem = br.ReadBoolean();
		RA.m_ulAwardItemId = br.ReadInt32();
		RA.m_ulAwardItemNum = br.ReadInt32();
		RA.m_lPeriod = br.ReadInt32();
	}

	internal static void Write(int version, BinaryWriter bw, RANKING_AWARD PW)
	{
		bw.Write(PW.m_iRankingStart);
		bw.Write(PW.m_iRankingEnd);
		bw.Write(PW.m_bCommonItem);
		bw.Write(PW.m_ulAwardItemId);
		bw.Write(PW.m_ulAwardItemNum);
		bw.Write(PW.m_lPeriod);
	}
}
