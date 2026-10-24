using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class SUBMIT_RANK_INFO
{
	private int int_0;

	private int int_1;

	private int int_2;

	public int m_iSubmitType
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

	public int m_iRankID
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

	public int m_iTempRankID
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

	internal static void Read(int version, BinaryReader br, SUBMIT_RANK_INFO SUBMIT_RANK_INFO)
	{
		SUBMIT_RANK_INFO.m_iSubmitType = br.ReadInt32();
		SUBMIT_RANK_INFO.m_iRankID = br.ReadInt32();
		SUBMIT_RANK_INFO.m_iTempRankID = br.ReadInt32();
	}

	internal static void Write(int version, BinaryWriter bw, SUBMIT_RANK_INFO SUBMIT_RANK_INFO)
	{
		bw.Write(SUBMIT_RANK_INFO.m_iSubmitType);
		bw.Write(SUBMIT_RANK_INFO.m_iRankID);
		bw.Write(SUBMIT_RANK_INFO.m_iTempRankID);
	}
}
