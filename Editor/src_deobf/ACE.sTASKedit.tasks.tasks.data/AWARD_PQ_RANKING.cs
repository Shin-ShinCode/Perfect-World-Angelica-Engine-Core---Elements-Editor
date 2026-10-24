using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class AWARD_PQ_RANKING
{
	private bool bool_0;

	private int int_0;

	private RANKING_AWARD[] ranking_AWARD_0 = new RANKING_AWARD[0];

	public bool m_bAwardByProf
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

	public int m_ulRankingAwardNum
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

	public RANKING_AWARD[] m_RankingAward
	{
		[CompilerGenerated]
		get
		{
			return ranking_AWARD_0;
		}
		[CompilerGenerated]
		set
		{
			ranking_AWARD_0 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, AWARD_PQ_RANKING AWARD_PQ_RANKING)
	{
		AWARD_PQ_RANKING.m_bAwardByProf = br.ReadBoolean();
		AWARD_PQ_RANKING.m_RankingAward = new RANKING_AWARD[AWARD_PQ_RANKING.m_ulRankingAwardNum];
		for (int i = 0; i < AWARD_PQ_RANKING.m_ulRankingAwardNum; i++)
		{
			AWARD_PQ_RANKING.m_RankingAward[i] = new RANKING_AWARD();
			RANKING_AWARD.Read(version, br, AWARD_PQ_RANKING.m_RankingAward[i]);
		}
	}

	internal static void Write(int version, BinaryWriter bw, AWARD_PQ_RANKING AWARD_PQ_RANKING)
	{
		bw.Write(AWARD_PQ_RANKING.m_bAwardByProf);
		for (int i = 0; i < AWARD_PQ_RANKING.m_RankingAward.Length; i++)
		{
			RANKING_AWARD.Write(version, bw, AWARD_PQ_RANKING.m_RankingAward[i]);
		}
	}
}
