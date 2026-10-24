using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class AWARD_DATA
{
	private AWARD_ITEMS_CAND[] award_ITEMS_CAND_0 = new AWARD_ITEMS_CAND[0];

	private AWARD_MONSTERS_SUMMONED award_MONSTERS_SUMMONED_0 = new AWARD_MONSTERS_SUMMONED();

	private AWARD_PQ_RANKING award_PQ_RANKING_0 = new AWARD_PQ_RANKING();

	private FACTION_TARGET_DATA[] faction_TARGET_DATA_0 = new FACTION_TARGET_DATA[0];

	private RANDOM_DIALOG_GROUP_DATA random_DIALOG_GROUP_DATA_0 = new RANDOM_DIALOG_GROUP_DATA();

	private SUBMIT_RANK_INFO submit_RANK_INFO_0 = new SUBMIT_RANK_INFO();

	private TASK_EXPRESSION[][] task_EXPRESSION_0 = new TASK_EXPRESSION[0][];

	private TITLE_AWARD[] title_AWARD_0 = new TITLE_AWARD[0];

	private ZONE_VERT zone_VERT_0 = new ZONE_VERT();

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private byte[] byte_0 = new byte[0];

	private byte[] byte_1 = new byte[0];

	private byte[] byte_2 = new byte[0];

	private byte[] byte_3 = new byte[0];

	private char[][] char_0 = new char[0][];

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16;

	private int int_17;

	private int int_18;

	private int int_19;

	private int int_20;

	private int int_21;

	private int int_22;

	private int int_23;

	private int int_24;

	private int int_25;

	private int int_26;

	private int int_27;

	private int int_28;

	private int int_29;

	private int int_30;

	private int int_31;

	private int int_32;

	private int int_33;

	private int int_34;

	private int int_35;

	private int int_36;

	private int int_37;

	private int int_38;

	private int int_39;

	private int int_40;

	private int int_41;

	private int int_42;

	private int int_43;

	private int int_44;

	private int int_45;

	private int int_46;

	private int int_47;

	private int int_48;

	private int int_49;

	private int int_50;

	private int int_51;

	private int int_52;

	private int int_53;

	private int int_54;

	private int int_55;

	private int int_56;

	private int int_57;

	private int int_58;

	private int int_59;

	private int int_60;

	private int int_61;

	private int int_62;

	private int int_63;

	private int int_64;

	private int int_65;

	private int int_66;

	private int int_67;

	private int int_68;

	private int[] int_69 = new int[0];

	private int[] int_70 = new int[0];

	private int[] int_71 = new int[0];

	private int[] int_72 = new int[0];

	private int[] int_73 = new int[0];

	private int[] int_74 = new int[0];

	private int[] int_75 = new int[5];

	private int[] int_76 = new int[0];

	private int[] int_77 = new int[0];

	private int[] int_78 = new int[0];

	private int[] int_79 = new int[0];

	private int[] int_80 = new int[0];

	private int[] int_81 = new int[0];

	private int[] int_82 = new int[0];

	private short[][] short_0 = new short[0][];

	private uint uint_0;

	private bool bool_12;

	private byte byte_4;

	private int int_83;

	private int int_84;

	private int int_85;

	private uint uint_1;

	private int int_86;

	private int int_87;

	private int int_88;

	private int int_89;

	private int int_90;

	private int int_91;

	private int int_92;

	private int int_93;

	private int int_94;

	private int int_95;

	private int int_96;

	private int int_97;

	private int int_98;

	private int int_99;

	private int int_100;

	public AWARD_ITEMS_CAND[] m_CandItems
	{
		[CompilerGenerated]
		get
		{
			return award_ITEMS_CAND_0;
		}
		[CompilerGenerated]
		set
		{
			award_ITEMS_CAND_0 = value;
		}
	}

	public AWARD_MONSTERS_SUMMONED m_SummonedMonsters
	{
		[CompilerGenerated]
		get
		{
			return award_MONSTERS_SUMMONED_0;
		}
		[CompilerGenerated]
		set
		{
			award_MONSTERS_SUMMONED_0 = value;
		}
	}

	public AWARD_PQ_RANKING m_PQRankingAward
	{
		[CompilerGenerated]
		get
		{
			return award_PQ_RANKING_0;
		}
		[CompilerGenerated]
		set
		{
			award_PQ_RANKING_0 = value;
		}
	}

	public FACTION_TARGET_DATA[] AwardFactionTargetData
	{
		[CompilerGenerated]
		get
		{
			return faction_TARGET_DATA_0;
		}
		[CompilerGenerated]
		set
		{
			faction_TARGET_DATA_0 = value;
		}
	}

	public RANDOM_DIALOG_GROUP_DATA AwardRandomDialogGroupData
	{
		[CompilerGenerated]
		get
		{
			return random_DIALOG_GROUP_DATA_0;
		}
		[CompilerGenerated]
		set
		{
			random_DIALOG_GROUP_DATA_0 = value;
		}
	}

	public SUBMIT_RANK_INFO submit_rank
	{
		[CompilerGenerated]
		get
		{
			return submit_RANK_INFO_0;
		}
		[CompilerGenerated]
		set
		{
			submit_RANK_INFO_0 = value;
		}
	}

	public TASK_EXPRESSION[][] m_pExpArr
	{
		[CompilerGenerated]
		get
		{
			return task_EXPRESSION_0;
		}
		[CompilerGenerated]
		set
		{
			task_EXPRESSION_0 = value;
		}
	}

	public TITLE_AWARD[] m_pTitleAward
	{
		[CompilerGenerated]
		get
		{
			return title_AWARD_0;
		}
		[CompilerGenerated]
		set
		{
			title_AWARD_0 = value;
		}
	}

	public ZONE_VERT m_TransPt
	{
		[CompilerGenerated]
		get
		{
			return zone_VERT_0;
		}
		[CompilerGenerated]
		set
		{
			zone_VERT_0 = value;
		}
	}

	public bool m_bAwardDeath
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

	public bool m_bAwardDeathWithLoss
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public bool m_bAwardSkill
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public bool m_bCreateHome
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public bool m_bDivorce
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public bool m_bExpandRealmLevelMax
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	public bool m_bLeaveCarrier
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public bool m_bMulti
	{
		[CompilerGenerated]
		get
		{
			return bool_7;
		}
		[CompilerGenerated]
		set
		{
			bool_7 = value;
		}
	}

	public bool m_bSendMsg
	{
		[CompilerGenerated]
		get
		{
			return bool_8;
		}
		[CompilerGenerated]
		set
		{
			bool_8 = value;
		}
	}

	public bool m_bSubmitRankScore
	{
		[CompilerGenerated]
		get
		{
			return bool_9;
		}
		[CompilerGenerated]
		set
		{
			bool_9 = value;
		}
	}

	public bool m_bTrigCtrl
	{
		[CompilerGenerated]
		get
		{
			return bool_10;
		}
		[CompilerGenerated]
		set
		{
			bool_10 = value;
		}
	}

	public bool m_bUseLevCo
	{
		[CompilerGenerated]
		get
		{
			return bool_11;
		}
		[CompilerGenerated]
		set
		{
			bool_11 = value;
		}
	}

	public byte[] NewChangeType
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public byte[] PersonChangeType
	{
		[CompilerGenerated]
		get
		{
			return byte_1;
		}
		[CompilerGenerated]
		set
		{
			byte_1 = value;
		}
	}

	public byte[] m_pbChangeType
	{
		[CompilerGenerated]
		get
		{
			return byte_2;
		}
		[CompilerGenerated]
		set
		{
			byte_2 = value;
		}
	}

	public byte[] m_pbHistoryChangeType
	{
		[CompilerGenerated]
		get
		{
			return byte_3;
		}
		[CompilerGenerated]
		set
		{
			byte_3 = value;
		}
	}

	public char[][] m_pszExp
	{
		[CompilerGenerated]
		get
		{
			return char_0;
		}
		[CompilerGenerated]
		set
		{
			char_0 = value;
		}
	}

	public int NewTaskSpace
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

	public int m_faction_money
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

	public int m_faction_person_score
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

	public int m_iAwardSkillID
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

	public int m_iAwardSkillLevel
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

	public int m_iCampScore
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public int m_iCoupleIntimacy
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	public int m_iCrossServerMoney
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	public int m_iFactionAwardConfig
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}

	public int m_iFactionContrib
	{
		[CompilerGenerated]
		get
		{
			return int_9;
		}
		[CompilerGenerated]
		set
		{
			int_9 = value;
		}
	}

	public int m_iFactionExpContrib
	{
		[CompilerGenerated]
		get
		{
			return int_10;
		}
		[CompilerGenerated]
		set
		{
			int_10 = value;
		}
	}

	public int m_iForceActivity
	{
		[CompilerGenerated]
		get
		{
			return int_11;
		}
		[CompilerGenerated]
		set
		{
			int_11 = value;
		}
	}

	public int m_iForceContribution
	{
		[CompilerGenerated]
		get
		{
			return int_12;
		}
		[CompilerGenerated]
		set
		{
			int_12 = value;
		}
	}

	public int m_iForceReputation
	{
		[CompilerGenerated]
		get
		{
			return int_13;
		}
		[CompilerGenerated]
		set
		{
			int_13 = value;
		}
	}

	public int m_iForceSetRepu
	{
		[CompilerGenerated]
		get
		{
			return int_14;
		}
		[CompilerGenerated]
		set
		{
			int_14 = value;
		}
	}

	public int m_iInviterAwardItem
	{
		[CompilerGenerated]
		get
		{
			return int_15;
		}
		[CompilerGenerated]
		set
		{
			int_15 = value;
		}
	}

	public int m_iInviterAwardNum
	{
		[CompilerGenerated]
		get
		{
			return int_16;
		}
		[CompilerGenerated]
		set
		{
			int_16 = value;
		}
	}

	public int m_iLeaderShip
	{
		[CompilerGenerated]
		get
		{
			return int_17;
		}
		[CompilerGenerated]
		set
		{
			int_17 = value;
		}
	}

	public int m_iMentorStudentValue
	{
		[CompilerGenerated]
		get
		{
			return int_18;
		}
		[CompilerGenerated]
		set
		{
			int_18 = value;
		}
	}

	public int m_iNewPlayerEvent
	{
		[CompilerGenerated]
		get
		{
			return int_19;
		}
		[CompilerGenerated]
		set
		{
			int_19 = value;
		}
	}

	public int m_iOpenSystem
	{
		[CompilerGenerated]
		get
		{
			return int_20;
		}
		[CompilerGenerated]
		set
		{
			int_20 = value;
		}
	}

	public int m_iPerceptionVal
	{
		[CompilerGenerated]
		get
		{
			return int_21;
		}
		[CompilerGenerated]
		set
		{
			int_21 = value;
		}
	}

	public int m_iRewardFriendPoint
	{
		[CompilerGenerated]
		get
		{
			return int_22;
		}
		[CompilerGenerated]
		set
		{
			int_22 = value;
		}
	}

	public int m_iSoloTowerChallengeScore
	{
		[CompilerGenerated]
		get
		{
			return int_23;
		}
		[CompilerGenerated]
		set
		{
			int_23 = value;
		}
	}

	public int m_iTaskLimit
	{
		[CompilerGenerated]
		get
		{
			return int_24;
		}
		[CompilerGenerated]
		set
		{
			int_24 = value;
		}
	}

	public int m_iWorldContribution
	{
		[CompilerGenerated]
		get
		{
			return int_25;
		}
		[CompilerGenerated]
		set
		{
			int_25 = value;
		}
	}

	public int m_lInventorySize
	{
		[CompilerGenerated]
		get
		{
			return int_26;
		}
		[CompilerGenerated]
		set
		{
			int_26 = value;
		}
	}

	public int m_lMonsCtrl
	{
		[CompilerGenerated]
		get
		{
			return int_27;
		}
		[CompilerGenerated]
		set
		{
			int_27 = value;
		}
	}

	public int m_lNum
	{
		[CompilerGenerated]
		get
		{
			return int_28;
		}
		[CompilerGenerated]
		set
		{
			int_28 = value;
		}
	}

	public int m_lReputation
	{
		[CompilerGenerated]
		get
		{
			return int_29;
		}
		[CompilerGenerated]
		set
		{
			int_29 = value;
		}
	}

	public int m_nMsgChannel
	{
		[CompilerGenerated]
		get
		{
			return int_30;
		}
		[CompilerGenerated]
		set
		{
			int_30 = value;
		}
	}

	public int m_nNumType
	{
		[CompilerGenerated]
		get
		{
			return int_31;
		}
		[CompilerGenerated]
		set
		{
			int_31 = value;
		}
	}

	public int m_uiGroupNum
	{
		[CompilerGenerated]
		get
		{
			return int_32;
		}
		[CompilerGenerated]
		set
		{
			int_32 = value;
		}
	}

	public int m_uiNumPerGroup
	{
		[CompilerGenerated]
		get
		{
			return int_33;
		}
		[CompilerGenerated]
		set
		{
			int_33 = value;
		}
	}

	public int m_ulCandItems
	{
		[CompilerGenerated]
		get
		{
			return int_34;
		}
		[CompilerGenerated]
		set
		{
			int_34 = value;
		}
	}

	public int m_ulCarrierChangeCnt
	{
		[CompilerGenerated]
		get
		{
			return int_35;
		}
		[CompilerGenerated]
		set
		{
			int_35 = value;
		}
	}

	public int m_ulChangeKeyCnt
	{
		[CompilerGenerated]
		get
		{
			return int_36;
		}
		[CompilerGenerated]
		set
		{
			int_36 = value;
		}
	}

	public int m_ulContrib
	{
		[CompilerGenerated]
		get
		{
			return int_37;
		}
		[CompilerGenerated]
		set
		{
			int_37 = value;
		}
	}

	public int m_ulCrossServerWldId
	{
		[CompilerGenerated]
		get
		{
			return int_38;
		}
		[CompilerGenerated]
		set
		{
			int_38 = value;
		}
	}

	public int m_ulDisplayKeyCnt
	{
		[CompilerGenerated]
		get
		{
			return int_39;
		}
		[CompilerGenerated]
		set
		{
			int_39 = value;
		}
	}

	public int m_ulDividend
	{
		[CompilerGenerated]
		get
		{
			return int_40;
		}
		[CompilerGenerated]
		set
		{
			int_40 = value;
		}
	}

	public int m_ulExp
	{
		[CompilerGenerated]
		get
		{
			return int_41;
		}
		[CompilerGenerated]
		set
		{
			int_41 = value;
		}
	}

	public int m_ulExpCnt
	{
		[CompilerGenerated]
		get
		{
			return int_42;
		}
		[CompilerGenerated]
		set
		{
			int_42 = value;
		}
	}

	public int m_ulFuryULimit
	{
		[CompilerGenerated]
		get
		{
			return int_43;
		}
		[CompilerGenerated]
		set
		{
			int_43 = value;
		}
	}

	public int m_ulGoldNum
	{
		[CompilerGenerated]
		get
		{
			return int_44;
		}
		[CompilerGenerated]
		set
		{
			int_44 = value;
		}
	}

	public int m_ulHistoryChangeCnt
	{
		[CompilerGenerated]
		get
		{
			return int_45;
		}
		[CompilerGenerated]
		set
		{
			int_45 = value;
		}
	}

	public int m_ulLowestcontrib
	{
		[CompilerGenerated]
		get
		{
			return int_46;
		}
		[CompilerGenerated]
		set
		{
			int_46 = value;
		}
	}

	public int m_ulNewPeriod
	{
		[CompilerGenerated]
		get
		{
			return int_47;
		}
		[CompilerGenerated]
		set
		{
			int_47 = value;
		}
	}

	public int m_ulNewRelayStation
	{
		[CompilerGenerated]
		get
		{
			return int_48;
		}
		[CompilerGenerated]
		set
		{
			int_48 = value;
		}
	}

	public int m_ulNewTask
	{
		[CompilerGenerated]
		get
		{
			return int_49;
		}
		[CompilerGenerated]
		set
		{
			int_49 = value;
		}
	}

	public int m_ulPQRankingAwardCnt
	{
		[CompilerGenerated]
		get
		{
			return int_50;
		}
		[CompilerGenerated]
		set
		{
			int_50 = value;
		}
	}

	public int m_ulPersonChangeKeyCnt
	{
		[CompilerGenerated]
		get
		{
			return int_51;
		}
		[CompilerGenerated]
		set
		{
			int_51 = value;
		}
	}

	public int m_ulPetInventorySize
	{
		[CompilerGenerated]
		get
		{
			return int_52;
		}
		[CompilerGenerated]
		set
		{
			int_52 = value;
		}
	}

	public int m_ulRandContrib
	{
		[CompilerGenerated]
		get
		{
			return int_53;
		}
		[CompilerGenerated]
		set
		{
			int_53 = value;
		}
	}

	public int m_ulRealmExp
	{
		[CompilerGenerated]
		get
		{
			return int_54;
		}
		[CompilerGenerated]
		set
		{
			int_54 = value;
		}
	}

	public int m_ulRedBookExp
	{
		[CompilerGenerated]
		get
		{
			return int_55;
		}
		[CompilerGenerated]
		set
		{
			int_55 = value;
		}
	}

	public int m_ulSP
	{
		[CompilerGenerated]
		get
		{
			return int_56;
		}
		[CompilerGenerated]
		set
		{
			int_56 = value;
		}
	}

	public int m_ulSpecifyContrib
	{
		[CompilerGenerated]
		get
		{
			return int_57;
		}
		[CompilerGenerated]
		set
		{
			int_57 = value;
		}
	}

	public int m_ulSpecifyContribSubTaskID
	{
		[CompilerGenerated]
		get
		{
			return int_58;
		}
		[CompilerGenerated]
		set
		{
			int_58 = value;
		}
	}

	public int m_ulSpecifyContribTaskID
	{
		[CompilerGenerated]
		get
		{
			return int_59;
		}
		[CompilerGenerated]
		set
		{
			int_59 = value;
		}
	}

	public int m_ulStorehouseSize2
	{
		[CompilerGenerated]
		get
		{
			return int_60;
		}
		[CompilerGenerated]
		set
		{
			int_60 = value;
		}
	}

	public int m_ulStorehouseSize3
	{
		[CompilerGenerated]
		get
		{
			return int_61;
		}
		[CompilerGenerated]
		set
		{
			int_61 = value;
		}
	}

	public int m_ulStorehouseSize4
	{
		[CompilerGenerated]
		get
		{
			return int_62;
		}
		[CompilerGenerated]
		set
		{
			int_62 = value;
		}
	}

	public int m_ulStorehouseSize
	{
		[CompilerGenerated]
		get
		{
			return int_63;
		}
		[CompilerGenerated]
		set
		{
			int_63 = value;
		}
	}

	public int m_ulSummonedMonsters
	{
		[CompilerGenerated]
		get
		{
			return int_64;
		}
		[CompilerGenerated]
		set
		{
			int_64 = value;
		}
	}

	public int m_ulTaskCharCnt
	{
		[CompilerGenerated]
		get
		{
			return int_65;
		}
		[CompilerGenerated]
		set
		{
			int_65 = value;
		}
	}

	public int m_ulTitleNum
	{
		[CompilerGenerated]
		get
		{
			return int_66;
		}
		[CompilerGenerated]
		set
		{
			int_66 = value;
		}
	}

	public int m_ulTransWldId
	{
		[CompilerGenerated]
		get
		{
			return int_67;
		}
		[CompilerGenerated]
		set
		{
			int_67 = value;
		}
	}

	public int m_usFactionTargetCount
	{
		[CompilerGenerated]
		get
		{
			return int_68;
		}
		[CompilerGenerated]
		set
		{
			int_68 = value;
		}
	}

	public int[] NewChangeKey
	{
		[CompilerGenerated]
		get
		{
			return int_69;
		}
		[CompilerGenerated]
		set
		{
			int_69 = value;
		}
	}

	public int[] NewChangeKeyValue2
	{
		[CompilerGenerated]
		get
		{
			return int_70;
		}
		[CompilerGenerated]
		set
		{
			int_70 = value;
		}
	}

	public int[] NewChangeKeyValue
	{
		[CompilerGenerated]
		get
		{
			return int_71;
		}
		[CompilerGenerated]
		set
		{
			int_71 = value;
		}
	}

	public int[] PersonChangeKey
	{
		[CompilerGenerated]
		get
		{
			return int_72;
		}
		[CompilerGenerated]
		set
		{
			int_72 = value;
		}
	}

	public int[] PersonChangeKeyValue2
	{
		[CompilerGenerated]
		get
		{
			return int_73;
		}
		[CompilerGenerated]
		set
		{
			int_73 = value;
		}
	}

	public int[] PersonChangeKeyValue
	{
		[CompilerGenerated]
		get
		{
			return int_74;
		}
		[CompilerGenerated]
		set
		{
			int_74 = value;
		}
	}

	public int[] m_iHomeResource
	{
		[CompilerGenerated]
		get
		{
			return int_75;
		}
		[CompilerGenerated]
		set
		{
			int_75 = value;
		}
	}

	public int[] m_plChangeKey
	{
		[CompilerGenerated]
		get
		{
			return int_76;
		}
		[CompilerGenerated]
		set
		{
			int_76 = value;
		}
	}

	public int[] m_plChangeKeyValue2
	{
		[CompilerGenerated]
		get
		{
			return int_77;
		}
		[CompilerGenerated]
		set
		{
			int_77 = value;
		}
	}

	public int[] m_plChangeKeyValue
	{
		[CompilerGenerated]
		get
		{
			return int_78;
		}
		[CompilerGenerated]
		set
		{
			int_78 = value;
		}
	}

	public int[] m_plDisplayKey
	{
		[CompilerGenerated]
		get
		{
			return int_79;
		}
		[CompilerGenerated]
		set
		{
			int_79 = value;
		}
	}

	public int[] m_plHistoryChangeKey
	{
		[CompilerGenerated]
		get
		{
			return int_80;
		}
		[CompilerGenerated]
		set
		{
			int_80 = value;
		}
	}

	public int[] m_plHistoryChangeKeyValue2
	{
		[CompilerGenerated]
		get
		{
			return int_81;
		}
		[CompilerGenerated]
		set
		{
			int_81 = value;
		}
	}

	public int[] m_plHistoryChangeKeyValue
	{
		[CompilerGenerated]
		get
		{
			return int_82;
		}
		[CompilerGenerated]
		set
		{
			int_82 = value;
		}
	}

	public short[][] m_pTaskChar
	{
		[CompilerGenerated]
		get
		{
			return short_0;
		}
		[CompilerGenerated]
		set
		{
			short_0 = value;
		}
	}

	public uint m_ulPanguExp
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

	public bool m_iAwardRedBookKey
	{
		[CompilerGenerated]
		get
		{
			return bool_12;
		}
		[CompilerGenerated]
		set
		{
			bool_12 = value;
		}
	}

	public byte m_bRepairShentongSearchBug
	{
		[CompilerGenerated]
		get
		{
			return byte_4;
		}
		[CompilerGenerated]
		set
		{
			byte_4 = value;
		}
	}

	public int m_iAwardRedBookKeyCount
	{
		[CompilerGenerated]
		get
		{
			return int_83;
		}
		[CompilerGenerated]
		set
		{
			int_83 = value;
		}
	}

	public int m_iAwardCameraMovementID
	{
		[CompilerGenerated]
		get
		{
			return int_84;
		}
		[CompilerGenerated]
		set
		{
			int_84 = value;
		}
	}

	public int m_iAwardRedBookKeyType
	{
		[CompilerGenerated]
		get
		{
			return int_85;
		}
		[CompilerGenerated]
		set
		{
			int_85 = value;
		}
	}

	public uint m_ulPanguExpYear
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	public int m_CandItemsPointer
	{
		[CompilerGenerated]
		get
		{
			return int_86;
		}
		[CompilerGenerated]
		set
		{
			int_86 = value;
		}
	}

	public int m_MonstersPointer
	{
		[CompilerGenerated]
		get
		{
			return int_87;
		}
		[CompilerGenerated]
		set
		{
			int_87 = value;
		}
	}

	public int m_RankingAwardPointer
	{
		[CompilerGenerated]
		get
		{
			return int_88;
		}
		[CompilerGenerated]
		set
		{
			int_88 = value;
		}
	}

	public int m_ulChangeKeyPointer
	{
		[CompilerGenerated]
		get
		{
			return int_89;
		}
		[CompilerGenerated]
		set
		{
			int_89 = value;
		}
	}

	public int m_plChangeKeyValuePointer
	{
		[CompilerGenerated]
		get
		{
			return int_90;
		}
		[CompilerGenerated]
		set
		{
			int_90 = value;
		}
	}

	public int m_pbChangeTypePointer
	{
		[CompilerGenerated]
		get
		{
			return int_91;
		}
		[CompilerGenerated]
		set
		{
			int_91 = value;
		}
	}

	public int m_plHistoryChangeKeyPointer
	{
		[CompilerGenerated]
		get
		{
			return int_92;
		}
		[CompilerGenerated]
		set
		{
			int_92 = value;
		}
	}

	public int m_plHistoryChangeKeyValuePointer
	{
		[CompilerGenerated]
		get
		{
			return int_93;
		}
		[CompilerGenerated]
		set
		{
			int_93 = value;
		}
	}

	public int m_pbHistoryChangeTypePointer
	{
		[CompilerGenerated]
		get
		{
			return int_94;
		}
		[CompilerGenerated]
		set
		{
			int_94 = value;
		}
	}

	public int m_ulDisplayKeyCntPointer
	{
		[CompilerGenerated]
		get
		{
			return int_95;
		}
		[CompilerGenerated]
		set
		{
			int_95 = value;
		}
	}

	public int m_pszExpPointer
	{
		[CompilerGenerated]
		get
		{
			return int_96;
		}
		[CompilerGenerated]
		set
		{
			int_96 = value;
		}
	}

	public int m_pExpArrPointer
	{
		[CompilerGenerated]
		get
		{
			return int_97;
		}
		[CompilerGenerated]
		set
		{
			int_97 = value;
		}
	}

	public int m_pTaskCharPointer
	{
		[CompilerGenerated]
		get
		{
			return int_98;
		}
		[CompilerGenerated]
		set
		{
			int_98 = value;
		}
	}

	public int m_pTitleAwardPointer
	{
		[CompilerGenerated]
		get
		{
			return int_99;
		}
		[CompilerGenerated]
		set
		{
			int_99 = value;
		}
	}

	public int AwardFactionTargetDataPointer
	{
		[CompilerGenerated]
		get
		{
			return int_100;
		}
		[CompilerGenerated]
		set
		{
			int_100 = value;
		}
	}

	public static AWARD_DATA Clone(AWARD_DATA award)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		Write(9999, binaryWriter, award);
		binaryReader.BaseStream.Position = 0L;
		AWARD_DATA aWARD_DATA = new AWARD_DATA();
		Read(9999, binaryReader, aWARD_DATA);
		binaryWriter.Close();
		binaryReader.Close();
		memoryStream.Close();
		return aWARD_DATA;
	}

	internal static void Read(int version, BinaryReader br, AWARD_DATA award_DATA_0)
	{
		smethod_0(version, br, award_DATA_0);
		smethod_1(version, br, award_DATA_0);
		smethod_2(version, br, award_DATA_0);
		smethod_3(version, br, award_DATA_0);
		smethod_4(version, br, award_DATA_0);
		smethod_5(version, br, award_DATA_0);
		smethod_6(version, br, award_DATA_0);
		smethod_7(version, br, award_DATA_0);
		smethod_8(version, br, award_DATA_0);
		smethod_9(version, br, award_DATA_0);
		smethod_10(version, br, award_DATA_0);
	}

	private static void smethod_0(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		award_DATA_0.m_ulGoldNum = binaryReader_0.ReadInt32();
		award_DATA_0.m_ulExp = binaryReader_0.ReadInt32();
		if (int_101 >= 113)
		{
			award_DATA_0.m_ulRealmExp = binaryReader_0.ReadInt32();
			if (int_101 >= 198)
			{
				award_DATA_0.m_ulPanguExp = binaryReader_0.ReadUInt32();
			}
			if (int_101 >= 225)
			{
				award_DATA_0.m_ulPanguExpYear = binaryReader_0.ReadUInt32();
			}
			award_DATA_0.m_bExpandRealmLevelMax = binaryReader_0.ReadBoolean();
		}
		if (int_101 >= 153)
		{
			award_DATA_0.NewTaskSpace = binaryReader_0.ReadInt32();
		}
		award_DATA_0.m_ulNewTask = binaryReader_0.ReadInt32();
		award_DATA_0.m_ulSP = binaryReader_0.ReadInt32();
		award_DATA_0.m_lReputation = binaryReader_0.ReadInt32();
		award_DATA_0.m_ulNewPeriod = binaryReader_0.ReadInt32();
		award_DATA_0.m_ulNewRelayStation = binaryReader_0.ReadInt32();
	}

	private static void smethod_1(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		award_DATA_0.m_ulStorehouseSize = binaryReader_0.ReadInt32();
		if (int_101 >= 57)
		{
			award_DATA_0.m_ulStorehouseSize2 = binaryReader_0.ReadInt32();
			award_DATA_0.m_ulStorehouseSize3 = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 75)
		{
			award_DATA_0.m_ulStorehouseSize4 = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 52)
		{
			award_DATA_0.m_lInventorySize = binaryReader_0.ReadInt32();
			award_DATA_0.m_ulPetInventorySize = binaryReader_0.ReadInt32();
		}
	}

	private static void smethod_2(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		award_DATA_0.m_ulFuryULimit = binaryReader_0.ReadInt32();
		award_DATA_0.m_ulTransWldId = binaryReader_0.ReadInt32();
		if (int_101 >= 161)
		{
			award_DATA_0.m_ulCrossServerWldId = binaryReader_0.ReadInt32();
		}
		ZONE_VERT.Read(int_101, binaryReader_0, award_DATA_0.m_TransPt);
		if (int_101 >= 52)
		{
			award_DATA_0.m_lMonsCtrl = binaryReader_0.ReadInt32();
			award_DATA_0.m_bTrigCtrl = binaryReader_0.ReadBoolean();
		}
		if (int_101 >= 54)
		{
			award_DATA_0.m_bUseLevCo = binaryReader_0.ReadBoolean();
		}
		if (int_101 >= 55)
		{
			award_DATA_0.m_bDivorce = binaryReader_0.ReadBoolean();
		}
		if (int_101 >= 56)
		{
			award_DATA_0.m_bSendMsg = binaryReader_0.ReadBoolean();
			award_DATA_0.m_nMsgChannel = binaryReader_0.ReadInt32();
		}
	}

	private static void smethod_3(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		award_DATA_0.m_ulCandItems = binaryReader_0.ReadInt32();
		if (int_101 < 176)
		{
			award_DATA_0.m_CandItemsPointer = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 64)
		{
			award_DATA_0.m_ulSummonedMonsters = binaryReader_0.ReadInt32();
			if (int_101 < 176)
			{
				award_DATA_0.m_MonstersPointer = binaryReader_0.ReadInt32();
			}
		}
		if (int_101 >= 69)
		{
			award_DATA_0.m_bAwardDeath = binaryReader_0.ReadBoolean();
			award_DATA_0.m_bAwardDeathWithLoss = binaryReader_0.ReadBoolean();
		}
		if (int_101 >= 75)
		{
			award_DATA_0.m_ulDividend = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 225)
		{
			award_DATA_0.m_bRepairShentongSearchBug = binaryReader_0.ReadByte();
		}
	}

	private static void smethod_4(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 78)
		{
			award_DATA_0.m_bAwardSkill = binaryReader_0.ReadBoolean();
			award_DATA_0.m_iAwardSkillID = binaryReader_0.ReadInt32();
			award_DATA_0.m_iAwardSkillLevel = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 124)
		{
			award_DATA_0.m_iSoloTowerChallengeScore = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 153)
		{
			award_DATA_0.m_iOpenSystem = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 75)
		{
			award_DATA_0.m_ulSpecifyContribTaskID = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 78)
		{
			award_DATA_0.m_ulSpecifyContribSubTaskID = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 75)
		{
			award_DATA_0.m_ulSpecifyContrib = binaryReader_0.ReadInt32();
			award_DATA_0.m_ulContrib = binaryReader_0.ReadInt32();
			award_DATA_0.m_ulRandContrib = binaryReader_0.ReadInt32();
			award_DATA_0.m_ulLowestcontrib = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 87)
		{
			award_DATA_0.m_iFactionContrib = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 89)
		{
			award_DATA_0.m_iFactionExpContrib = binaryReader_0.ReadInt32();
		}
	}

	private static void smethod_5(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 75)
		{
			award_DATA_0.m_ulPQRankingAwardCnt = binaryReader_0.ReadInt32();
			if (int_101 < 176)
			{
				award_DATA_0.m_RankingAwardPointer = binaryReader_0.ReadInt32();
			}
		}
		if (int_101 >= 59)
		{
			award_DATA_0.m_ulChangeKeyCnt = binaryReader_0.ReadInt32();
			if (int_101 < 176)
			{
				award_DATA_0.m_ulChangeKeyPointer = binaryReader_0.ReadInt32();
				award_DATA_0.m_plChangeKeyValuePointer = binaryReader_0.ReadInt32();
				award_DATA_0.m_pbChangeTypePointer = binaryReader_0.ReadInt32();
			}
		}
		if (int_101 >= 178)
		{
			award_DATA_0.m_ulPersonChangeKeyCnt = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 186)
		{
			award_DATA_0.m_ulCarrierChangeCnt = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 112)
		{
			award_DATA_0.m_ulHistoryChangeCnt = binaryReader_0.ReadInt32();
			if (int_101 < 176)
			{
				award_DATA_0.m_plHistoryChangeKeyPointer = binaryReader_0.ReadInt32();
				award_DATA_0.m_plHistoryChangeKeyValuePointer = binaryReader_0.ReadInt32();
				award_DATA_0.m_pbHistoryChangeTypePointer = binaryReader_0.ReadInt32();
			}
		}
	}

	private static void smethod_6(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 59)
		{
			award_DATA_0.m_bMulti = binaryReader_0.ReadBoolean();
			award_DATA_0.m_nNumType = binaryReader_0.ReadInt32();
			award_DATA_0.m_lNum = binaryReader_0.ReadInt32();
			award_DATA_0.m_ulDisplayKeyCnt = binaryReader_0.ReadInt32();
			if (int_101 < 176)
			{
				award_DATA_0.m_ulDisplayKeyCntPointer = binaryReader_0.ReadInt32();
			}
		}
		if (int_101 >= 63)
		{
			award_DATA_0.m_ulExpCnt = binaryReader_0.ReadInt32();
			if (int_101 < 176)
			{
				award_DATA_0.m_pszExpPointer = binaryReader_0.ReadInt32();
				award_DATA_0.m_pExpArrPointer = binaryReader_0.ReadInt32();
			}
			award_DATA_0.m_ulTaskCharCnt = binaryReader_0.ReadInt32();
			if (int_101 < 176)
			{
				award_DATA_0.m_pTaskCharPointer = binaryReader_0.ReadInt32();
			}
		}
	}

	private static void smethod_7(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 97)
		{
			award_DATA_0.m_iForceContribution = binaryReader_0.ReadInt32();
			award_DATA_0.m_iForceReputation = binaryReader_0.ReadInt32();
			award_DATA_0.m_iForceActivity = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 100)
		{
			award_DATA_0.m_iForceSetRepu = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 101)
		{
			award_DATA_0.m_iTaskLimit = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 109)
		{
			award_DATA_0.m_ulTitleNum = binaryReader_0.ReadInt32();
			if (int_101 < 176)
			{
				award_DATA_0.m_pTitleAwardPointer = binaryReader_0.ReadInt32();
			}
		}
		if (int_101 >= 115)
		{
			award_DATA_0.m_iLeaderShip = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 119)
		{
			award_DATA_0.m_iWorldContribution = binaryReader_0.ReadInt32();
		}
	}

	private static void smethod_8(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 126)
		{
			for (int i = 0; i < award_DATA_0.m_iHomeResource.Length; i++)
			{
				award_DATA_0.m_iHomeResource[i] = binaryReader_0.ReadInt32();
			}
			award_DATA_0.m_bCreateHome = binaryReader_0.ReadBoolean();
		}
		if (int_101 >= 135)
		{
			award_DATA_0.m_bLeaveCarrier = binaryReader_0.ReadBoolean();
		}
		if (int_101 >= 146)
		{
			award_DATA_0.m_faction_money = binaryReader_0.ReadInt32();
			award_DATA_0.m_faction_person_score = binaryReader_0.ReadInt32();
			award_DATA_0.m_usFactionTargetCount = binaryReader_0.ReadInt32();
			if (int_101 < 176)
			{
				award_DATA_0.AwardFactionTargetDataPointer = binaryReader_0.ReadInt32();
			}
			award_DATA_0.m_bSubmitRankScore = binaryReader_0.ReadBoolean();
			SUBMIT_RANK_INFO.Read(int_101, binaryReader_0, award_DATA_0.submit_rank);
		}
		if (int_101 >= 156)
		{
			award_DATA_0.m_iMentorStudentValue = binaryReader_0.ReadInt32();
			award_DATA_0.m_iCoupleIntimacy = binaryReader_0.ReadInt32();
		}
	}

	private static void smethod_9(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 162)
		{
			award_DATA_0.m_ulRedBookExp = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 167)
		{
			award_DATA_0.m_iCampScore = binaryReader_0.ReadInt32();
			award_DATA_0.m_iCrossServerMoney = binaryReader_0.ReadInt32();
			award_DATA_0.m_iInviterAwardItem = binaryReader_0.ReadInt32();
			award_DATA_0.m_iRewardFriendPoint = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 175)
		{
			award_DATA_0.m_iInviterAwardNum = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 180)
		{
			award_DATA_0.m_iPerceptionVal = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 194)
		{
			award_DATA_0.m_uiGroupNum = binaryReader_0.ReadInt32();
			award_DATA_0.m_uiNumPerGroup = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 216)
		{
			award_DATA_0.m_iNewPlayerEvent = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 232)
		{
			award_DATA_0.m_iFactionAwardConfig = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 237)
		{
			award_DATA_0.m_iAwardRedBookKey = binaryReader_0.ReadBoolean();
			award_DATA_0.m_iAwardRedBookKeyType = binaryReader_0.ReadInt32();
			award_DATA_0.m_iAwardRedBookKeyCount = binaryReader_0.ReadInt32();
		}
		if (int_101 >= 240)
		{
			award_DATA_0.m_iAwardCameraMovementID = binaryReader_0.ReadInt32();
		}
	}

	private static void smethod_10(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		smethod_11(int_101, binaryReader_0, award_DATA_0);
		smethod_12(int_101, binaryReader_0, award_DATA_0);
		smethod_13(int_101, binaryReader_0, award_DATA_0);
		smethod_14(int_101, binaryReader_0, award_DATA_0);
		smethod_15(int_101, binaryReader_0, award_DATA_0);
		smethod_20(int_101, binaryReader_0, award_DATA_0);
		smethod_21(int_101, binaryReader_0, award_DATA_0);
		smethod_22(int_101, binaryReader_0, award_DATA_0);
		smethod_23(int_101, binaryReader_0, award_DATA_0);
		smethod_24(int_101, binaryReader_0, award_DATA_0);
	}

	private static void smethod_11(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		award_DATA_0.m_CandItems = new AWARD_ITEMS_CAND[award_DATA_0.m_ulCandItems];
		for (int i = 0; i < award_DATA_0.m_ulCandItems; i++)
		{
			award_DATA_0.m_CandItems[i] = new AWARD_ITEMS_CAND();
			AWARD_ITEMS_CAND.Read(int_101, binaryReader_0, award_DATA_0.m_CandItems[i]);
		}
	}

	private static void smethod_12(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 64 && award_DATA_0.m_ulSummonedMonsters > 0)
		{
			award_DATA_0.m_SummonedMonsters.m_ulMonsterNum = award_DATA_0.m_ulSummonedMonsters;
			AWARD_MONSTERS_SUMMONED.Read(int_101, binaryReader_0, award_DATA_0.m_SummonedMonsters);
		}
	}

	private static void smethod_13(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 75 && award_DATA_0.m_ulPQRankingAwardCnt > 0)
		{
			award_DATA_0.m_PQRankingAward.m_ulRankingAwardNum = award_DATA_0.m_ulPQRankingAwardCnt;
			AWARD_PQ_RANKING.Read(int_101, binaryReader_0, award_DATA_0.m_PQRankingAward);
		}
	}

	private static void smethod_14(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 109)
		{
			award_DATA_0.m_pTitleAward = new TITLE_AWARD[award_DATA_0.m_ulTitleNum];
			for (int i = 0; i < award_DATA_0.m_ulTitleNum; i++)
			{
				award_DATA_0.m_pTitleAward[i] = new TITLE_AWARD();
				TITLE_AWARD.Read(int_101, binaryReader_0, award_DATA_0.m_pTitleAward[i]);
			}
		}
	}

	private static void smethod_15(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		smethod_16(int_101, binaryReader_0, award_DATA_0);
		smethod_17(int_101, binaryReader_0, award_DATA_0);
		smethod_18(int_101, binaryReader_0, award_DATA_0);
		smethod_19(int_101, binaryReader_0, award_DATA_0);
	}

	private static void smethod_16(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 < 59)
		{
			return;
		}
		award_DATA_0.m_plChangeKey = new int[award_DATA_0.m_ulChangeKeyCnt];
		award_DATA_0.m_plChangeKeyValue = new int[award_DATA_0.m_ulChangeKeyCnt];
		award_DATA_0.m_plChangeKeyValue2 = new int[award_DATA_0.m_ulChangeKeyCnt];
		award_DATA_0.m_pbChangeType = new byte[award_DATA_0.m_ulChangeKeyCnt];
		for (int i = 0; i < award_DATA_0.m_ulChangeKeyCnt; i++)
		{
			award_DATA_0.m_plChangeKey[i] = binaryReader_0.ReadInt32();
			award_DATA_0.m_plChangeKeyValue[i] = binaryReader_0.ReadInt32();
			if (int_101 >= 215)
			{
				award_DATA_0.m_plChangeKeyValue2[i] = binaryReader_0.ReadInt32();
			}
			else
			{
				award_DATA_0.m_plChangeKeyValue2[i] = 0;
			}
			award_DATA_0.m_pbChangeType[i] = binaryReader_0.ReadByte();
		}
	}

	private static void smethod_17(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 < 178)
		{
			return;
		}
		award_DATA_0.PersonChangeKey = new int[award_DATA_0.m_ulPersonChangeKeyCnt];
		award_DATA_0.PersonChangeKeyValue = new int[award_DATA_0.m_ulPersonChangeKeyCnt];
		award_DATA_0.PersonChangeKeyValue2 = new int[award_DATA_0.m_ulPersonChangeKeyCnt];
		award_DATA_0.PersonChangeType = new byte[award_DATA_0.m_ulPersonChangeKeyCnt];
		for (int i = 0; i < award_DATA_0.m_ulPersonChangeKeyCnt; i++)
		{
			award_DATA_0.PersonChangeKey[i] = binaryReader_0.ReadInt32();
			award_DATA_0.PersonChangeKeyValue[i] = binaryReader_0.ReadInt32();
			if (int_101 >= 215)
			{
				award_DATA_0.PersonChangeKeyValue2[i] = binaryReader_0.ReadInt32();
			}
			else
			{
				award_DATA_0.PersonChangeKeyValue2[i] = 0;
			}
			award_DATA_0.PersonChangeType[i] = binaryReader_0.ReadByte();
		}
	}

	private static void smethod_18(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 < 186)
		{
			return;
		}
		award_DATA_0.NewChangeKey = new int[award_DATA_0.m_ulCarrierChangeCnt];
		award_DATA_0.NewChangeKeyValue = new int[award_DATA_0.m_ulCarrierChangeCnt];
		award_DATA_0.NewChangeKeyValue2 = new int[award_DATA_0.m_ulCarrierChangeCnt];
		award_DATA_0.NewChangeType = new byte[award_DATA_0.m_ulCarrierChangeCnt];
		for (int i = 0; i < award_DATA_0.m_ulCarrierChangeCnt; i++)
		{
			award_DATA_0.NewChangeKey[i] = binaryReader_0.ReadInt32();
			award_DATA_0.NewChangeKeyValue[i] = binaryReader_0.ReadInt32();
			if (int_101 >= 215)
			{
				award_DATA_0.NewChangeKeyValue2[i] = binaryReader_0.ReadInt32();
			}
			else
			{
				award_DATA_0.NewChangeKeyValue2[i] = 0;
			}
			award_DATA_0.NewChangeType[i] = binaryReader_0.ReadByte();
		}
	}

	private static void smethod_19(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 < 112)
		{
			return;
		}
		award_DATA_0.m_plHistoryChangeKey = new int[award_DATA_0.m_ulHistoryChangeCnt];
		award_DATA_0.m_plHistoryChangeKeyValue = new int[award_DATA_0.m_ulHistoryChangeCnt];
		award_DATA_0.m_plHistoryChangeKeyValue2 = new int[award_DATA_0.m_ulHistoryChangeCnt];
		award_DATA_0.m_pbHistoryChangeType = new byte[award_DATA_0.m_ulHistoryChangeCnt];
		for (int i = 0; i < award_DATA_0.m_ulHistoryChangeCnt; i++)
		{
			award_DATA_0.m_plHistoryChangeKey[i] = binaryReader_0.ReadInt32();
			award_DATA_0.m_plHistoryChangeKeyValue[i] = binaryReader_0.ReadInt32();
			if (int_101 >= 215)
			{
				award_DATA_0.m_plHistoryChangeKeyValue2[i] = binaryReader_0.ReadInt32();
			}
			else
			{
				award_DATA_0.m_plHistoryChangeKeyValue2[i] = 0;
			}
			award_DATA_0.m_pbHistoryChangeType[i] = binaryReader_0.ReadByte();
		}
	}

	private static void smethod_20(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 59)
		{
			award_DATA_0.m_plDisplayKey = new int[award_DATA_0.m_ulDisplayKeyCnt];
			for (int i = 0; i < award_DATA_0.m_ulDisplayKeyCnt; i++)
			{
				award_DATA_0.m_plDisplayKey[i] = binaryReader_0.ReadInt32();
			}
		}
	}

	private static void smethod_21(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 < 63)
		{
			return;
		}
		award_DATA_0.m_pszExp = new char[award_DATA_0.m_ulExpCnt][];
		award_DATA_0.m_pExpArr = new TASK_EXPRESSION[award_DATA_0.m_ulExpCnt][];
		for (int i = 0; i < award_DATA_0.m_ulExpCnt; i++)
		{
			award_DATA_0.m_pszExp[i] = GlobalFunctions.ReadChars(64, binaryReader_0);
			award_DATA_0.m_pExpArr[i] = new TASK_EXPRESSION[64];
			for (int j = 0; j < award_DATA_0.m_pExpArr[i].Length; j++)
			{
				award_DATA_0.m_pExpArr[i][j] = new TASK_EXPRESSION();
				TASK_EXPRESSION.Read(int_101, binaryReader_0, award_DATA_0.m_pExpArr[i][j]);
			}
		}
	}

	private static void smethod_22(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 63)
		{
			award_DATA_0.m_pTaskChar = new short[award_DATA_0.m_ulTaskCharCnt][];
			for (int i = 0; i < award_DATA_0.m_ulTaskCharCnt; i++)
			{
				award_DATA_0.m_pTaskChar[i] = GlobalFunctions.ReadNameChars(64, binaryReader_0);
			}
		}
	}

	private static void smethod_23(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 146)
		{
			award_DATA_0.AwardFactionTargetData = new FACTION_TARGET_DATA[award_DATA_0.m_usFactionTargetCount];
			for (int i = 0; i < award_DATA_0.m_usFactionTargetCount; i++)
			{
				award_DATA_0.AwardFactionTargetData[i] = new FACTION_TARGET_DATA();
				FACTION_TARGET_DATA.Read(int_101, binaryReader_0, award_DATA_0.AwardFactionTargetData[i]);
			}
		}
	}

	private static void smethod_24(int int_101, BinaryReader binaryReader_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 194 && award_DATA_0.m_uiGroupNum > 0 && award_DATA_0.m_uiNumPerGroup > 0)
		{
			award_DATA_0.AwardRandomDialogGroupData = new RANDOM_DIALOG_GROUP_DATA();
			RANDOM_DIALOG_GROUP_DATA.Read(int_101, binaryReader_0, award_DATA_0.m_uiGroupNum, award_DATA_0.m_uiNumPerGroup, award_DATA_0.AwardRandomDialogGroupData);
		}
	}

	internal static void Write(int version, BinaryWriter bw, AWARD_DATA AD)
	{
		smethod_25(version, bw, AD);
		smethod_26(version, bw, AD);
		smethod_27(version, bw, AD);
		smethod_28(version, bw, AD);
		smethod_29(version, bw, AD);
		smethod_30(version, bw, AD);
		smethod_31(version, bw, AD);
		smethod_32(version, bw, AD);
		smethod_33(version, bw, AD);
		smethod_34(version, bw, AD);
		smethod_35(version, bw, AD);
	}

	private static void smethod_25(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		binaryWriter_0.Write(award_DATA_0.m_ulGoldNum);
		binaryWriter_0.Write(award_DATA_0.m_ulExp);
		if (int_101 >= 113)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulRealmExp);
			if (int_101 >= 198)
			{
				binaryWriter_0.Write(award_DATA_0.m_ulPanguExp);
			}
			if (int_101 >= 225)
			{
				binaryWriter_0.Write(award_DATA_0.m_ulPanguExpYear);
			}
			binaryWriter_0.Write(award_DATA_0.m_bExpandRealmLevelMax);
		}
		if (int_101 >= 153)
		{
			binaryWriter_0.Write(award_DATA_0.NewTaskSpace);
		}
		binaryWriter_0.Write(award_DATA_0.m_ulNewTask);
		binaryWriter_0.Write(award_DATA_0.m_ulSP);
		binaryWriter_0.Write(award_DATA_0.m_lReputation);
		binaryWriter_0.Write(award_DATA_0.m_ulNewPeriod);
		binaryWriter_0.Write(award_DATA_0.m_ulNewRelayStation);
	}

	private static void smethod_26(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		binaryWriter_0.Write(award_DATA_0.m_ulStorehouseSize);
		if (int_101 >= 57)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulStorehouseSize2);
			binaryWriter_0.Write(award_DATA_0.m_ulStorehouseSize3);
		}
		if (int_101 >= 75)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulStorehouseSize4);
		}
		if (int_101 >= 52)
		{
			binaryWriter_0.Write(award_DATA_0.m_lInventorySize);
			binaryWriter_0.Write(award_DATA_0.m_ulPetInventorySize);
		}
	}

	private static void smethod_27(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		binaryWriter_0.Write(award_DATA_0.m_ulFuryULimit);
		binaryWriter_0.Write(award_DATA_0.m_ulTransWldId);
		if (int_101 >= 161)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulCrossServerWldId);
		}
		ZONE_VERT.Write(int_101, binaryWriter_0, award_DATA_0.m_TransPt);
		if (int_101 >= 52)
		{
			binaryWriter_0.Write(award_DATA_0.m_lMonsCtrl);
			binaryWriter_0.Write(award_DATA_0.m_bTrigCtrl);
		}
		if (int_101 >= 54)
		{
			binaryWriter_0.Write(award_DATA_0.m_bUseLevCo);
		}
		if (int_101 >= 55)
		{
			binaryWriter_0.Write(award_DATA_0.m_bDivorce);
		}
		if (int_101 >= 56)
		{
			binaryWriter_0.Write(award_DATA_0.m_bSendMsg);
			binaryWriter_0.Write(award_DATA_0.m_nMsgChannel);
		}
	}

	private static void smethod_28(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		int maxAwardCandidates = GlobalFunctions.GetMaxAwardCandidates(int_101);
		if (award_DATA_0.m_ulCandItems > maxAwardCandidates)
		{
			binaryWriter_0.Write(maxAwardCandidates);
		}
		else
		{
			binaryWriter_0.Write(award_DATA_0.m_ulCandItems);
		}
		if (int_101 < 176)
		{
			binaryWriter_0.Write(award_DATA_0.m_CandItemsPointer);
		}
		if (int_101 >= 64)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulSummonedMonsters);
			if (int_101 < 176)
			{
				binaryWriter_0.Write(award_DATA_0.m_MonstersPointer);
			}
		}
		if (int_101 >= 69)
		{
			binaryWriter_0.Write(award_DATA_0.m_bAwardDeath);
			binaryWriter_0.Write(award_DATA_0.m_bAwardDeathWithLoss);
		}
		if (int_101 >= 75)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulDividend);
		}
		if (int_101 >= 225)
		{
			binaryWriter_0.Write(award_DATA_0.m_bRepairShentongSearchBug);
		}
	}

	private static void smethod_29(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 78)
		{
			binaryWriter_0.Write(award_DATA_0.m_bAwardSkill);
			binaryWriter_0.Write(award_DATA_0.m_iAwardSkillID);
			binaryWriter_0.Write(award_DATA_0.m_iAwardSkillLevel);
		}
		if (int_101 >= 124)
		{
			binaryWriter_0.Write(award_DATA_0.m_iSoloTowerChallengeScore);
		}
		if (int_101 >= 153)
		{
			binaryWriter_0.Write(award_DATA_0.m_iOpenSystem);
		}
		if (int_101 >= 75)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulSpecifyContribTaskID);
		}
		if (int_101 >= 78)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulSpecifyContribSubTaskID);
		}
		if (int_101 >= 75)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulSpecifyContrib);
			binaryWriter_0.Write(award_DATA_0.m_ulContrib);
			binaryWriter_0.Write(award_DATA_0.m_ulRandContrib);
			binaryWriter_0.Write(award_DATA_0.m_ulLowestcontrib);
		}
		if (int_101 >= 87)
		{
			binaryWriter_0.Write(award_DATA_0.m_iFactionContrib);
		}
		if (int_101 >= 89)
		{
			binaryWriter_0.Write(award_DATA_0.m_iFactionExpContrib);
		}
	}

	private static void smethod_30(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 75)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulPQRankingAwardCnt);
			if (int_101 < 176)
			{
				binaryWriter_0.Write(award_DATA_0.m_RankingAwardPointer);
			}
		}
		if (int_101 >= 59)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulChangeKeyCnt);
			if (int_101 < 176)
			{
				binaryWriter_0.Write(award_DATA_0.m_ulChangeKeyPointer);
				binaryWriter_0.Write(award_DATA_0.m_plChangeKeyValuePointer);
				binaryWriter_0.Write(award_DATA_0.m_pbChangeTypePointer);
			}
		}
		if (int_101 >= 178)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulPersonChangeKeyCnt);
		}
		if (int_101 >= 186)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulCarrierChangeCnt);
		}
		if (int_101 >= 112)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulHistoryChangeCnt);
			if (int_101 < 176)
			{
				binaryWriter_0.Write(award_DATA_0.m_plHistoryChangeKeyPointer);
				binaryWriter_0.Write(award_DATA_0.m_plHistoryChangeKeyValuePointer);
				binaryWriter_0.Write(award_DATA_0.m_pbHistoryChangeTypePointer);
			}
		}
	}

	private static void smethod_31(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 59)
		{
			binaryWriter_0.Write(award_DATA_0.m_bMulti);
			binaryWriter_0.Write(award_DATA_0.m_nNumType);
			binaryWriter_0.Write(award_DATA_0.m_lNum);
			binaryWriter_0.Write(award_DATA_0.m_ulDisplayKeyCnt);
			if (int_101 < 176)
			{
				binaryWriter_0.Write(award_DATA_0.m_ulDisplayKeyCntPointer);
			}
		}
		if (int_101 >= 63)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulExpCnt);
			if (int_101 < 176)
			{
				binaryWriter_0.Write(award_DATA_0.m_pszExpPointer);
				binaryWriter_0.Write(award_DATA_0.m_pExpArrPointer);
			}
			binaryWriter_0.Write(award_DATA_0.m_ulTaskCharCnt);
			if (int_101 < 176)
			{
				binaryWriter_0.Write(award_DATA_0.m_pTaskCharPointer);
			}
		}
	}

	private static void smethod_32(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 97)
		{
			binaryWriter_0.Write(award_DATA_0.m_iForceContribution);
			binaryWriter_0.Write(award_DATA_0.m_iForceReputation);
			binaryWriter_0.Write(award_DATA_0.m_iForceActivity);
		}
		if (int_101 >= 100)
		{
			binaryWriter_0.Write(award_DATA_0.m_iForceSetRepu);
		}
		if (int_101 >= 101)
		{
			binaryWriter_0.Write(award_DATA_0.m_iTaskLimit);
		}
		if (int_101 >= 109)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulTitleNum);
			if (int_101 < 176)
			{
				binaryWriter_0.Write(award_DATA_0.m_pTitleAwardPointer);
			}
		}
		if (int_101 >= 115)
		{
			binaryWriter_0.Write(award_DATA_0.m_iLeaderShip);
		}
		if (int_101 >= 119)
		{
			binaryWriter_0.Write(award_DATA_0.m_iWorldContribution);
		}
	}

	private static void smethod_33(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 126)
		{
			for (int i = 0; i < award_DATA_0.m_iHomeResource.Length; i++)
			{
				binaryWriter_0.Write(award_DATA_0.m_iHomeResource[i]);
			}
			binaryWriter_0.Write(award_DATA_0.m_bCreateHome);
		}
		if (int_101 >= 135)
		{
			binaryWriter_0.Write(award_DATA_0.m_bLeaveCarrier);
		}
		if (int_101 >= 146)
		{
			binaryWriter_0.Write(award_DATA_0.m_faction_money);
			binaryWriter_0.Write(award_DATA_0.m_faction_person_score);
			binaryWriter_0.Write(award_DATA_0.m_usFactionTargetCount);
			if (int_101 < 176)
			{
				binaryWriter_0.Write(award_DATA_0.AwardFactionTargetDataPointer);
			}
			binaryWriter_0.Write(award_DATA_0.m_bSubmitRankScore);
			SUBMIT_RANK_INFO.Write(int_101, binaryWriter_0, award_DATA_0.submit_rank);
		}
		if (int_101 >= 156)
		{
			binaryWriter_0.Write(award_DATA_0.m_iMentorStudentValue);
			binaryWriter_0.Write(award_DATA_0.m_iCoupleIntimacy);
		}
	}

	private static void smethod_34(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 162)
		{
			binaryWriter_0.Write(award_DATA_0.m_ulRedBookExp);
		}
		if (int_101 >= 167)
		{
			binaryWriter_0.Write(award_DATA_0.m_iCampScore);
			binaryWriter_0.Write(award_DATA_0.m_iCrossServerMoney);
			binaryWriter_0.Write(award_DATA_0.m_iInviterAwardItem);
			binaryWriter_0.Write(award_DATA_0.m_iRewardFriendPoint);
		}
		if (int_101 >= 175)
		{
			binaryWriter_0.Write(award_DATA_0.m_iInviterAwardNum);
		}
		if (int_101 >= 180)
		{
			binaryWriter_0.Write(award_DATA_0.m_iPerceptionVal);
		}
		if (int_101 >= 194)
		{
			binaryWriter_0.Write(award_DATA_0.m_uiGroupNum);
			binaryWriter_0.Write(award_DATA_0.m_uiNumPerGroup);
		}
		if (int_101 >= 216)
		{
			binaryWriter_0.Write(award_DATA_0.m_iNewPlayerEvent);
		}
		if (int_101 >= 232)
		{
			binaryWriter_0.Write(award_DATA_0.m_iFactionAwardConfig);
		}
		if (int_101 >= 237)
		{
			binaryWriter_0.Write(award_DATA_0.m_iAwardRedBookKey);
			binaryWriter_0.Write(award_DATA_0.m_iAwardRedBookKeyType);
			binaryWriter_0.Write(award_DATA_0.m_iAwardRedBookKeyCount);
		}
		if (int_101 >= 240)
		{
			binaryWriter_0.Write(award_DATA_0.m_iAwardCameraMovementID);
		}
	}

	private static void smethod_35(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		smethod_36(int_101, binaryWriter_0, award_DATA_0);
		smethod_37(int_101, binaryWriter_0, award_DATA_0);
		smethod_38(int_101, binaryWriter_0, award_DATA_0);
		smethod_39(int_101, binaryWriter_0, award_DATA_0);
		smethod_40(int_101, binaryWriter_0, award_DATA_0);
		smethod_45(int_101, binaryWriter_0, award_DATA_0);
		smethod_46(int_101, binaryWriter_0, award_DATA_0);
		smethod_47(int_101, binaryWriter_0, award_DATA_0);
		smethod_48(int_101, binaryWriter_0, award_DATA_0);
		smethod_49(int_101, binaryWriter_0, award_DATA_0);
	}

	private static void smethod_36(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		int maxAwardCandidates = GlobalFunctions.GetMaxAwardCandidates(int_101);
		for (int i = 0; i < award_DATA_0.m_ulCandItems && i < maxAwardCandidates; i++)
		{
			AWARD_ITEMS_CAND.Write(int_101, binaryWriter_0, award_DATA_0.m_CandItems[i]);
		}
	}

	private static void smethod_37(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 64 && award_DATA_0.m_ulSummonedMonsters > 0)
		{
			AWARD_MONSTERS_SUMMONED.Write(int_101, binaryWriter_0, award_DATA_0.m_SummonedMonsters);
		}
	}

	private static void smethod_38(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 75 && award_DATA_0.m_ulPQRankingAwardCnt > 0)
		{
			AWARD_PQ_RANKING.Write(int_101, binaryWriter_0, award_DATA_0.m_PQRankingAward);
		}
	}

	private static void smethod_39(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 109)
		{
			for (int i = 0; i < award_DATA_0.m_ulTitleNum; i++)
			{
				TITLE_AWARD.Write(int_101, binaryWriter_0, award_DATA_0.m_pTitleAward[i]);
			}
		}
	}

	private static void smethod_40(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		smethod_41(int_101, binaryWriter_0, award_DATA_0);
		smethod_42(int_101, binaryWriter_0, award_DATA_0);
		smethod_43(int_101, binaryWriter_0, award_DATA_0);
		smethod_44(int_101, binaryWriter_0, award_DATA_0);
	}

	private static void smethod_41(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 < 59)
		{
			return;
		}
		for (int i = 0; i < award_DATA_0.m_ulChangeKeyCnt; i++)
		{
			binaryWriter_0.Write(award_DATA_0.m_plChangeKey[i]);
			binaryWriter_0.Write(award_DATA_0.m_plChangeKeyValue[i]);
			if (int_101 >= 215)
			{
				binaryWriter_0.Write(award_DATA_0.m_plChangeKeyValue2[i]);
			}
			binaryWriter_0.Write(award_DATA_0.m_pbChangeType[i]);
		}
	}

	private static void smethod_42(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 < 178)
		{
			return;
		}
		for (int i = 0; i < award_DATA_0.m_ulPersonChangeKeyCnt; i++)
		{
			binaryWriter_0.Write(award_DATA_0.PersonChangeKey[i]);
			binaryWriter_0.Write(award_DATA_0.PersonChangeKeyValue[i]);
			if (int_101 >= 215)
			{
				binaryWriter_0.Write(award_DATA_0.PersonChangeKeyValue2[i]);
			}
			binaryWriter_0.Write(award_DATA_0.PersonChangeType[i]);
		}
	}

	private static void smethod_43(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 < 186)
		{
			return;
		}
		for (int i = 0; i < award_DATA_0.m_ulCarrierChangeCnt; i++)
		{
			binaryWriter_0.Write(award_DATA_0.NewChangeKey[i]);
			binaryWriter_0.Write(award_DATA_0.NewChangeKeyValue[i]);
			if (int_101 >= 215)
			{
				binaryWriter_0.Write(award_DATA_0.NewChangeKeyValue2[i]);
			}
			binaryWriter_0.Write(award_DATA_0.NewChangeType[i]);
		}
	}

	private static void smethod_44(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 < 112)
		{
			return;
		}
		for (int i = 0; i < award_DATA_0.m_ulHistoryChangeCnt; i++)
		{
			binaryWriter_0.Write(award_DATA_0.m_plHistoryChangeKey[i]);
			binaryWriter_0.Write(award_DATA_0.m_plHistoryChangeKeyValue[i]);
			if (int_101 >= 215)
			{
				binaryWriter_0.Write(award_DATA_0.m_plHistoryChangeKeyValue2[i]);
			}
			binaryWriter_0.Write(award_DATA_0.m_pbHistoryChangeType[i]);
		}
	}

	private static void smethod_45(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 59)
		{
			for (int i = 0; i < award_DATA_0.m_ulDisplayKeyCnt; i++)
			{
				binaryWriter_0.Write(award_DATA_0.m_plDisplayKey[i]);
			}
		}
	}

	private static void smethod_46(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 < 63)
		{
			return;
		}
		for (int i = 0; i < award_DATA_0.m_ulExpCnt; i++)
		{
			GlobalFunctions.WriteChars(binaryWriter_0, award_DATA_0.m_pszExp[i]);
			for (int j = 0; j < award_DATA_0.m_pExpArr[i].Length; j++)
			{
				TASK_EXPRESSION.Write(int_101, binaryWriter_0, award_DATA_0.m_pExpArr[i][j]);
			}
		}
	}

	private static void smethod_47(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 63)
		{
			for (int i = 0; i < award_DATA_0.m_ulTaskCharCnt; i++)
			{
				GlobalFunctions.WriteNameChars(binaryWriter_0, award_DATA_0.m_pTaskChar[i]);
			}
		}
	}

	private static void smethod_48(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 146)
		{
			for (int i = 0; i < award_DATA_0.m_usFactionTargetCount; i++)
			{
				FACTION_TARGET_DATA.Write(int_101, binaryWriter_0, award_DATA_0.AwardFactionTargetData[i]);
			}
		}
	}

	private static void smethod_49(int int_101, BinaryWriter binaryWriter_0, AWARD_DATA award_DATA_0)
	{
		if (int_101 >= 194 && award_DATA_0.m_uiGroupNum > 0 && award_DATA_0.m_uiNumPerGroup > 0)
		{
			RANDOM_DIALOG_GROUP_DATA.Write(int_101, binaryWriter_0, award_DATA_0.m_uiGroupNum, award_DATA_0.m_uiNumPerGroup, award_DATA_0.AwardRandomDialogGroupData);
		}
	}
}
