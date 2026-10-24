using System.Collections;
using System.Runtime.CompilerServices;
using ACE.Classes;
using ACE.License;

namespace ACE.sTASKedit.tasks;

public class GlobalData
{
	public enum DynTaskTyp : byte
	{
		enumDTTNone,
		enumDTTSpecialAward,
		enumDTTNormal,
		enumDTTGiftCard
	}

	public enum ENUM_HOME_LEVEL_TYPE
	{
		enumHomeLevel,
		enumHomeFactory,
		enumHomeBuy,
		enumHomeStone,
		enumHomeWood,
		enumHomeIron,
		enumHomeCloth,
		enumHomeFarm,
		enumHomeAnimal
	}

	public enum ENUM_TASK_TYPE
	{
		enumTTCommonOld = 0,
		enumTTRepeatedOld = 1,
		enumTTKeyOld = 2,
		enumTTBossOld = 3,
		enumTTInstanceOld = 4,
		enumTTScrollOld = 5,
		enumTTBusinessOld = 6,
		enumTTFeelingOld = 7,
		enumTTTacticsOld = 8,
		enumTTRegionOld = 9,
		enumTTSevenKillListOld = 10,
		enumTTFactionOld = 11,
		enumTTHintOld = 12,
		enumTTDaily = 100,
		enumTTLevel2 = 101,
		enumTTMajor = 102,
		enumTTBranch = 103,
		enumTTEvent = 104,
		enumTTQiShaList = 105,
		enumTTFaction = 106,
		enumTTFunction = 107,
		enumTTLegend = 108,
		enumTTQuestion = 109,
		enumTTHome = 110,
		enumTTGrowth = 111,
		enumTTStory = 112,
		enumTTInstance = 113,
		enumTTReserved = 114,
		enumTTNewAnecdote = 115
	}

	public enum SERVICE_TYPE : uint
	{
		NPC_TALK = 2147483648u,
		NPC_SELL,
		NPC_BUY,
		NPC_REPAIR,
		NPC_INSTALL,
		NPC_UNINSTALL,
		NPC_GIVE_TASK,
		NPC_COMPLETE_TASK,
		NPC_GIVE_TASK_MATTER,
		NPC_SKILL,
		NPC_HEAL,
		NPC_TRANSMIT,
		NPC_TRANSPORT,
		NPC_PROXY,
		NPC_STORAGE,
		NPC_MAKE,
		NPC_DECOMPOSE,
		TALK_RETURN,
		TALK_EXIT,
		NPC_STORAGE_PASSWORD,
		NPC_IDENTIFY,
		TALK_GIVEUP_TASK,
		NPC_WAR_TOWERBUILD,
		NPC_RESETPROP,
		NPC_PETNAME,
		NPC_PETLEARNSKILL,
		NPC_PETFORGETSKILL,
		NPC_EQUIPBIND,
		NPC_EQUIPDESTROY,
		NPC_EQUIPUNDESTROY,
		NPC_ACCOUNT_STORAGE,
		NPC_ENGRAVE,
		NPC_RANDPROP
	}

	public enum TASKELEMENTS_TYPE
	{
		NONE,
		TASKS_DELV_WORLD,
		TASKS_ENTER_REGION_WORLD,
		TASKS_LEAVE_REGION_WORLD,
		TASKS_TRANS_WLD_ID,
		TASKS_MONS_CTRL,
		TASKS_DELV_NPC,
		TASKS_AWARD_NPC,
		TASKS_CHANGE_KEY,
		TASKS_MONSTERS_CONTRIB,
		TASKS_PREM_ITEMS,
		TASKS_GIVEN_ITEMS,
		TASKS_PREM_1_KEY_VALUE_LEFT_NUM,
		TASKS_PREM_1_KEY_VALUE_RIGHT_NUM,
		TASKS_PREM_2_KEY_VALUE_LEFT_NUM,
		TASKS_PREM_2_KEY_VALUE_RIGHT_NUM,
		TASKS_PREM_TITLES,
		TASKS_MATTERS_PLAYER_WANTED,
		TASKS_MONSTER_WANTED_MONSTERS,
		TASKS_MONSTER_WANTED_ITEMS,
		TASKS_ITEMS_WANTED,
		TASKS_REACH_SITE_ID,
		TASKS_TREASURE_ZONE_MAP_ID,
		TASKS_LEAVE_SITE_ID,
		TASKS_FIN_1_KEY_VALUE_LEFT_NUM,
		TASKS_FIN_1_KEY_VALUE_RIGHT_NUM,
		TASKS_FIN_2_KEY_VALUE_LEFT_NUM,
		TASKS_FIN_2_KEY_VALUE_RIGHT_NUM,
		TASKS_HOME_ITEMS_WANTED,
		TASKS_TM_BIND_CARRTER_ID,
		TASKS_TASK_EVENT_MONSTER_DATA,
		TASKS_TASK_EVENT_MINE_DATA,
		TASKS_TASK_EVENT_TASK_DATA,
		TASKS_AWARD_SUCCESS_TRANS_WLD_ID,
		TASKS_AWARD_SUCCESS_MONS_CTRL,
		TASKS_AWARD_SUCCESS_CAND_ITEMS,
		TASKS_AWARD_SUCCESS_PQ_RANKING_AWARD,
		TASKS_AWARD_SUCCESS_CHANGE_KEY,
		TASKS_AWARD_SUCCESS_TITLE_AWARD,
		TASKS_AWARD_SUCCESS_SUMMONED_MONSTERS,
		TASKS_AWARD_SUCCESS_FACTION_TARGET_DATA,
		TASKS_AWARD_BY_RATIO_SUCCESS_TRANS_WLD_ID,
		TASKS_AWARD_BY_RATIO_SUCCESS_MONS_CTRL,
		TASKS_AWARD_BY_RATIO_SUCCESS_CAND_ITEMS,
		TASKS_AWARD_BY_RATIO_SUCCESS_PQ_RANKING_AWARD,
		TASKS_AWARD_BY_RATIO_SUCCESS_CHANGE_KEY,
		TASKS_AWARD_BY_RATIO_SUCCESS_TITLE_AWARD,
		TASKS_AWARD_BY_RATIO_SUCCESS_SUMMONED_MONSTERS,
		TASKS_AWARD_BY_RATIO_SUCCESS_FACTION_TARGET_DATA,
		TASKS_AWARD_BY_ITEMS_SUCCESS_TRANS_WLD_ID,
		TASKS_AWARD_BY_ITEMS_SUCCESS_MONS_CTRL,
		TASKS_AWARD_BY_ITEMS_SUCCESS_CAND_ITEMS,
		TASKS_AWARD_BY_ITEMS_SUCCESS_PQ_RANKING_AWARD,
		TASKS_AWARD_BY_ITEMS_SUCCESS_CHANGE_KEY,
		TASKS_AWARD_BY_ITEMS_SUCCESS_TITLE_AWARD,
		TASKS_AWARD_BY_ITEMS_SUCCESS_SUMMONED_MONSTERS,
		TASKS_AWARD_BY_ITEMS_SUCCESS_FACTION_TARGET_DATA,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_TRANS_WLD_ID,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_MONS_CTRL,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_CAND_ITEMS,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_PQ_RANKING_AWARD,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_CHANGE_KEY,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_TITLE_AWARD,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_SUMMONED_MONSTERS,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_FACTION_TARGET_DATA,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_TRANS_WLD_ID,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_MONS_CTRL,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_CAND_ITEMS,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_PQ_RANKING_AWARD,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_CHANGE_KEY,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_TITLE_AWARD,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_SUMMONED_MONSTERS,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_FACTION_TARGET_DATA,
		TASKS_AWARD_FAIL_TRANS_WLD_ID,
		TASKS_AWARD_FAIL_MONS_CTRL,
		TASKS_AWARD_FAIL_CAND_ITEMS,
		TASKS_AWARD_FAIL_PQ_RANKING_AWARD,
		TASKS_AWARD_FAIL_CHANGE_KEY,
		TASKS_AWARD_FAIL_TITLE_AWARD,
		TASKS_AWARD_FAIL_SUMMONED_MONSTERS,
		TASKS_AWARD_FAIL_FACTION_TARGET_DATA,
		TASKS_AWARD_BY_RATIO_FAIL_TRANS_WLD_ID,
		TASKS_AWARD_BY_RATIO_FAIL_MONS_CTRL,
		TASKS_AWARD_BY_RATIO_FAIL_CAND_ITEMS,
		TASKS_AWARD_BY_RATIO_FAIL_PQ_RANKING_AWARD,
		TASKS_AWARD_BY_RATIO_FAIL_CHANGE_KEY,
		TASKS_AWARD_BY_RATIO_FAIL_TITLE_AWARD,
		TASKS_AWARD_BY_RATIO_FAIL_SUMMONED_MONSTERS,
		TASKS_AWARD_BY_RATIO_FAIL_FACTION_TARGET_DATA,
		TASKS_AWARD_BY_ITEMS_FAIL_TRANS_WLD_ID,
		TASKS_AWARD_BY_ITEMS_FAIL_MONS_CTRL,
		TASKS_AWARD_BY_ITEMS_FAIL_CAND_ITEMS,
		TASKS_AWARD_BY_ITEMS_FAIL_PQ_RANKING_AWARD,
		TASKS_AWARD_BY_ITEMS_FAIL_CHANGE_KEY,
		TASKS_AWARD_BY_ITEMS_FAIL_TITLE_AWARD,
		TASKS_AWARD_BY_ITEMS_FAIL_SUMMONED_MONSTERS,
		TASKS_AWARD_BY_ITEMS_FAIL_FACTION_TARGET_DATA,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_TRANS_WLD_ID,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_MONS_CTRL,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_CAND_ITEMS,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_PQ_RANKING_AWARD,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_CHANGE_KEY,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_TITLE_AWARD,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_SUMMONED_MONSTERS,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_FACTION_TARGET_DATA,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_TRANS_WLD_ID,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_MONS_CTRL,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_CAND_ITEMS,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_PQ_RANKING_AWARD,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_CHANGE_KEY,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_TITLE_AWARD,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_SUMMONED_MONSTERS,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_FACTION_TARGET_DATA,
		TASKS_SL_USE_ITEM_IDS,
		TASKS_SL_COMPLETE_TASK_IDS,
		TASKS_DELV_REGION,
		TASKS_ENTER_REGION,
		TASKS_LEAVE_REGION,
		TASKS_REACH_SITE,
		TASKS_LEAVE_SITE,
		TASKS_GLOBAL_KEY_FOR_AWARD_VAR,
		TASKS_AWARD_BY_VAR_SUCCESS_TRANS_WLD_ID,
		TASKS_AWARD_BY_VAR_SUCCESS_MONS_CTRL,
		TASKS_AWARD_BY_VAR_SUCCESS_CAND_ITEMS,
		TASKS_AWARD_BY_VAR_SUCCESS_PQ_RANKING_AWARD,
		TASKS_AWARD_BY_VAR_SUCCESS_CHANGE_KEY,
		TASKS_AWARD_BY_VAR_SUCCESS_TITLE_AWARD,
		TASKS_AWARD_BY_VAR_SUCCESS_SUMMONED_MONSTERS,
		TASKS_AWARD_BY_VAR_SUCCESS_FACTION_TARGET_DATA,
		TASKS_AWARD_BY_VAR_FAIL_TRANS_WLD_ID,
		TASKS_AWARD_BY_VAR_FAIL_MONS_CTRL,
		TASKS_AWARD_BY_VAR_FAIL_CAND_ITEMS,
		TASKS_AWARD_BY_VAR_FAIL_PQ_RANKING_AWARD,
		TASKS_AWARD_BY_VAR_FAIL_CHANGE_KEY,
		TASKS_AWARD_BY_VAR_FAIL_TITLE_AWARD,
		TASKS_AWARD_BY_VAR_FAIL_SUMMONED_MONSTERS,
		TASKS_AWARD_BY_VAR_FAIL_FACTION_TARGET_DATA,
		TASKS_AWARD_SUCCESS_INVITER_AWARD,
		TASKS_AWARD_BY_RATIO_SUCCESS_INVITER_AWARD,
		TASKS_AWARD_BY_ITEMS_SUCCESS_INVITER_AWARD,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_INVITER_AWARD,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_INVITER_AWARD,
		TASKS_AWARD_BY_VAR_SUCCESS_INVITER_AWARD,
		TASKS_AWARD_FAIL_INVITER_AWARD,
		TASKS_AWARD_BY_RATIO_FAIL_INVITER_AWARD,
		TASKS_AWARD_BY_ITEMS_FAIL_INVITER_AWARD,
		TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_INVITER_AWARD,
		TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_INVITER_AWARD,
		TASKS_AWARD_BY_VAR_FAIL_INVITER_AWARD,
		TASKS_FAIL_1_KEY_VALUE_LEFT_NUM,
		TASKS_FAIL_1_KEY_VALUE_RIGHT_NUM,
		TASKS_FAIL_2_KEY_VALUE_LEFT_NUM,
		TASKS_FAIL_2_KEY_VALUE_RIGHT_NUM,
		TASKS_PROP_SUMMONED_MONSTERS,
		TASKS_MONSTER_UNWANTED_MONSTERS,
		TASKS_MONSTER_UNWANTED_ITEMS
	}

	public enum TaskAvailFrequency
	{
		enumTAFNormal,
		enumTAFEachDay,
		enumTAFEachWeek,
		enumTAFEachMonth,
		enumTAFEachYear
	}

	public enum TaskAwardType
	{
		enumTATNormal,
		enumTATEach,
		enumTATRatio,
		enumTATItemCount,
		enumTATTaskEventTimeRatio,
		enumTATCarrierHp,
		enumTATVar
	}

	public enum TaskExp
	{
		enumTaskExpVar,
		enumTaskExpConst,
		enumTaskExpOprt
	}

	public enum TaskFinishType
	{
		enumTFTUnk = -1,
		enumTFTDirect,
		enumTFTNPC,
		enumTFTConfirm,
		enumTFTHomeUI,
		enumTFTType4
	}

	public enum TaskMethod
	{
		enumTMNone,
		enumTMKillNumMonster,
		enumTMCollectNumArticle,
		enumTMTalkToNPC,
		enumTMReachSite,
		enumTMWaitTime,
		enumTMAnswerQuestion,
		enumTMTinyGame,
		enumTMProtectNPC,
		enumTMNPCReachSite,
		enumTMGlobalValOK,
		enumTMLeaveSite,
		enumTMReachTreasureZone,
		enumTMKillPlayer,
		enumTMTransform,
		enumTMReachLevel,
		enumTMSimpleClientTask,
		enumTMSimpleClientTaskForceNavi,
		enumTMIconStateID,
		enumTMReachHomeLevel,
		enumTMReachHomeFlourish,
		enumTMCollectNumHomeArticle,
		enumTMBindCarrierId,
		enumTMReachArenaTime,
		enumTMReachArenaWin,
		enumTMTaskEvent,
		enumTMReachFactionPersonScore,
		enumTMUseItems,
		enumTMHaveFactionMembersInTeam,
		enumTMReachGrowthTarget,
		enumTMOpenDialog,
		enumTMSuccTriggerEvent,
		enumTMVerifyStateLayer,
		enumTMKeyWord,
		enumTMPersonValOK,
		enumTMHistoryValOK,
		enumTMGuess,
		enumTMTakePictureWanted,
		enumTMSubmitItemWanted,
		enumTMTransmitPoint,
		enumTMTSMServices,
		enumTMTSMTargetTask,
		enumTMDailyActivity
	}

	public struct TaskParameterInfo
	{
		private TaskParameters taskParameters_0;

		private int int_0;

		private int int_1;

		public TaskParameters Parameter
		{
			[CompilerGenerated]
			readonly get
			{
				return taskParameters_0;
			}
			[CompilerGenerated]
			set
			{
				taskParameters_0 = value;
			}
		}

		public int MinVersion
		{
			[CompilerGenerated]
			readonly get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public int MaxVersion
		{
			[CompilerGenerated]
			readonly get
			{
				return int_1;
			}
			[CompilerGenerated]
			set
			{
				int_1 = value;
			}
		}

		public TaskParameterInfo(TaskParameters param, int minVer, int maxVer)
		{
			Parameter = param;
			MinVersion = minVer;
			MaxVersion = maxVer;
		}

		public bool IsValidForVersion(int version)
		{
			if (MinVersion == 0 && MaxVersion == 0)
			{
				return true;
			}
			if (MinVersion == 0)
			{
				return version <= MaxVersion;
			}
			if (MaxVersion == 0)
			{
				return version >= MinVersion;
			}
			if (version >= MinVersion)
			{
				return version <= MaxVersion;
			}
			return false;
		}
	}

	public static class TaskParameterManager
	{
		private static readonly TaskParameterInfo[] taskParameterInfo_0 = new TaskParameterInfo[188]
		{
			new TaskParameterInfo(TaskParameters.ShowByTransformed, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByLev, 0, 0),
			new TaskParameterInfo(TaskParameters.PremCheckReincarnation, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByReincarnation, 0, 0),
			new TaskParameterInfo(TaskParameters.PremCheckRealmLevel, 0, 0),
			new TaskParameterInfo(TaskParameters.PremCheckRealmExpFull, 0, 0),
			new TaskParameterInfo(TaskParameters.CheckTradeTime, 232, 0),
			new TaskParameterInfo(TaskParameters.ShowByTradeTime, 232, 0),
			new TaskParameterInfo(TaskParameters.ShowByRealmLevel, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByItems, 0, 0),
			new TaskParameterInfo(TaskParameters.PremItemsAnyOne, 0, 0),
			new TaskParameterInfo(TaskParameters.MethodItemsRandOne, 215, 0),
			new TaskParameterInfo(TaskParameters.NotOpenWithItem, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByDeposit, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByRepu, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByPreTask, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByPeriod, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByFaction, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByGender, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByOccup, 0, 0),
			new TaskParameterInfo(TaskParameters.Premise_Spouse, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowBySpouse, 0, 0),
			new TaskParameterInfo(TaskParameters.PremiseWeddingOwner, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByWeddingOwner, 0, 0),
			new TaskParameterInfo(TaskParameters.GM, 0, 0),
			new TaskParameterInfo(TaskParameters.ShieldUser, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByRMB, 0, 0),
			new TaskParameterInfo(TaskParameters.CharTime, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByCharTime, 0, 0),
			new TaskParameterInfo(TaskParameters.Teamwork, 0, 0),
			new TaskParameterInfo(TaskParameters.RcvByTeam, 0, 0),
			new TaskParameterInfo(TaskParameters.SharedTask, 0, 0),
			new TaskParameterInfo(TaskParameters.SharedAchieved, 0, 0),
			new TaskParameterInfo(TaskParameters.CheckTeammate, 0, 0),
			new TaskParameterInfo(TaskParameters.AllFail, 0, 0),
			new TaskParameterInfo(TaskParameters.CapFail, 0, 0),
			new TaskParameterInfo(TaskParameters.CapSucc, 0, 0),
			new TaskParameterInfo(TaskParameters.DismAsSelfFail, 0, 0),
			new TaskParameterInfo(TaskParameters.RcvChckMem, 0, 0),
			new TaskParameterInfo(TaskParameters.CntByMemPos, 0, 0),
			new TaskParameterInfo(TaskParameters.AllSucc, 0, 0),
			new TaskParameterInfo(TaskParameters.CoupleOnly, 0, 0),
			new TaskParameterInfo(TaskParameters.DistinguishedOcc, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByTeam, 0, 0),
			new TaskParameterInfo(TaskParameters.PremNeedComp, 0, 0),
			new TaskParameterInfo(TaskParameters.PremNeedCompPerson, 178, 0),
			new TaskParameterInfo(TaskParameters.PremNeedCompHistory, 185, 0),
			new TaskParameterInfo(TaskParameters.PremCheckForce, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByForce, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByForceReputation, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByForceContribution, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByForceExp, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByForceSP, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByForceActivityLevel, 0, 0),
			new TaskParameterInfo(TaskParameters.PremIsKing, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByKing, 0, 0),
			new TaskParameterInfo(TaskParameters.PremNotInTeam, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByNotInTeam, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByTitle, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByHistoryStage, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByGeneralCard, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByGeneralCardRank, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByIconStateID, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByVIPLevel, 0, 0),
			new TaskParameterInfo(TaskParameters.PremNoHome, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByHomeLevel, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByHomeResourceLevel, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByHomeFactoryLevel, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByHomeFlourish, 0, 0),
			new TaskParameterInfo(TaskParameters.PremHomeStorageTask, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByHomeStorageTask, 0, 0),
			new TaskParameterInfo(TaskParameters.MonsterTotalCount, 0, 0),
			new TaskParameterInfo(TaskParameters.NotShowGfx, 195, 0),
			new TaskParameterInfo(TaskParameters.FinNeedComp, 0, 0),
			new TaskParameterInfo(TaskParameters.FinNeedCompPerson, 178, 0),
			new TaskParameterInfo(TaskParameters.FinNeedCompHistory, 185, 0),
			new TaskParameterInfo(TaskParameters.IsLibraryTask, 0, 0),
			new TaskParameterInfo(TaskParameters.IsUniqueStorageTask, 0, 0),
			new TaskParameterInfo(TaskParameters.HasSign, 0, 0),
			new TaskParameterInfo(TaskParameters.OfflineFail, 0, 0),
			new TaskParameterInfo(TaskParameters.ItemNotTakeOff, 0, 0),
			new TaskParameterInfo(TaskParameters.AbsTime, 0, 0),
			new TaskParameterInfo(TaskParameters.MultiNpcTalk, 180, 0),
			new TaskParameterInfo(TaskParameters.ChooseOne, 0, 0),
			new TaskParameterInfo(TaskParameters.RandOne, 0, 0),
			new TaskParameterInfo(TaskParameters.ExeChildInOrder, 0, 0),
			new TaskParameterInfo(TaskParameters.ParentAlsoFail, 0, 0),
			new TaskParameterInfo(TaskParameters.ParentAlsoSucc, 0, 0),
			new TaskParameterInfo(TaskParameters.CanGiveUp, 0, 0),
			new TaskParameterInfo(TaskParameters.CanRedo, 0, 0),
			new TaskParameterInfo(TaskParameters.CanRedoAfterFailure, 0, 0),
			new TaskParameterInfo(TaskParameters.ClearAsGiveUp, 0, 0),
			new TaskParameterInfo(TaskParameters.NeedRecord, 0, 0),
			new TaskParameterInfo(TaskParameters.FailAsPlayerDie, 0, 0),
			new TaskParameterInfo(TaskParameters.DelvInZone, 0, 0),
			new TaskParameterInfo(TaskParameters.EnterRegionFail, 0, 0),
			new TaskParameterInfo(TaskParameters.LeaveRegionFail, 0, 0),
			new TaskParameterInfo(TaskParameters.LeaveForceFail, 0, 0),
			new TaskParameterInfo(TaskParameters.TransTo, 0, 0),
			new TaskParameterInfo(TaskParameters.TrigCtrl, 0, 0),
			new TaskParameterInfo(TaskParameters.AutoDeliver, 0, 0),
			new TaskParameterInfo(TaskParameters.AutoDeliverHighPriority, 240, 0),
			new TaskParameterInfo(TaskParameters.DisplayInExclusiveUI, 0, 0),
			new TaskParameterInfo(TaskParameters.ReadyToNotifyServer, 0, 0),
			new TaskParameterInfo(TaskParameters.UsedInTokenShop, 0, 0),
			new TaskParameterInfo(TaskParameters.DeathTrig, 0, 0),
			new TaskParameterInfo(TaskParameters.ClearAcquired, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowPrompt, 0, 0),
			new TaskParameterInfo(TaskParameters.KeyTask, 0, 0),
			new TaskParameterInfo(TaskParameters.SkillTask, 0, 0),
			new TaskParameterInfo(TaskParameters.CanSeekOut, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowDirection, 0, 0),
			new TaskParameterInfo(TaskParameters.Marriage, 0, 0),
			new TaskParameterInfo(TaskParameters.SwitchSceneFail, 0, 0),
			new TaskParameterInfo(TaskParameters.Hidden, 0, 0),
			new TaskParameterInfo(TaskParameters.DeliverySkill, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowGfxFinished, 0, 0),
			new TaskParameterInfo(TaskParameters.ChangePQRanking, 0, 0),
			new TaskParameterInfo(TaskParameters.CompareItemAndInventory, 0, 0),
			new TaskParameterInfo(TaskParameters.TowerTask, 0, 0),
			new TaskParameterInfo(TaskParameters.HomeTask, 0, 0),
			new TaskParameterInfo(TaskParameters.DeliverInHostHome, 0, 0),
			new TaskParameterInfo(TaskParameters.FinishInHostHome, 0, 0),
			new TaskParameterInfo(TaskParameters.PQTask, 0, 0),
			new TaskParameterInfo(TaskParameters.PQSubTask, 0, 0),
			new TaskParameterInfo(TaskParameters.ClearContrib, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByNeedRecordTasksNum, 0, 0),
			new TaskParameterInfo(TaskParameters.ShowByFactionContrib, 0, 0),
			new TaskParameterInfo(TaskParameters.AccountTaskLimit, 0, 0),
			new TaskParameterInfo(TaskParameters.RoleTaskLimit, 0, 0),
			new TaskParameterInfo(TaskParameters.LeaveFactionFail, 0, 0),
			new TaskParameterInfo(TaskParameters.NotIncCntWhenFailed, 0, 0),
			new TaskParameterInfo(TaskParameters.NotClearItemWhenFailed, 0, 0),
			new TaskParameterInfo(TaskParameters.DisplayInTitleTaskUI, 0, 0),
			new TaskParameterInfo(TaskParameters.CanAwardOnCarrier, 0, 0),
			new TaskParameterInfo(TaskParameters.PreReachArenaWinCount, 137, 0),
			new TaskParameterInfo(TaskParameters.ShowByReachArenaWinCount, 137, 0),
			new TaskParameterInfo(TaskParameters.WriteSpecialLog, 140, 0),
			new TaskParameterInfo(TaskParameters.ShowByPreFactionScore, 146, 0),
			new TaskParameterInfo(TaskParameters.ShowByPreFactionMoney, 146, 0),
			new TaskParameterInfo(TaskParameters.ShowByPreFactionPersonScore, 146, 0),
			new TaskParameterInfo(TaskParameters.CheckFactionMem, 146, 0),
			new TaskParameterInfo(TaskParameters.ByFactionScore, 146, 0),
			new TaskParameterInfo(TaskParameters.SpecailLogicTask, 146, 0),
			new TaskParameterInfo(TaskParameters.BecomeMentor, 153, 0),
			new TaskParameterInfo(TaskParameters.ShowMentorMorality, 153, 0),
			new TaskParameterInfo(TaskParameters.ShowMentorStudent, 153, 0),
			new TaskParameterInfo(TaskParameters.DiscardedTask, 153, 0),
			new TaskParameterInfo(TaskParameters.NoCheckTitleGot, 153, 0),
			new TaskParameterInfo(TaskParameters.ShowCoupleIntimacy, 156, 0),
			new TaskParameterInfo(TaskParameters.ShowByDeposit2, 158, 0),
			new TaskParameterInfo(TaskParameters.CrossServer, 194, 0),
			new TaskParameterInfo(TaskParameters.RecordFinishCount, 163, 0),
			new TaskParameterInfo(TaskParameters.RecordReset, 198, 0),
			new TaskParameterInfo(TaskParameters.ShowCamp, 167, 0),
			new TaskParameterInfo(TaskParameters.ShowCampPower, 167, 0),
			new TaskParameterInfo(TaskParameters.ReturnCampPower, 167, 0),
			new TaskParameterInfo(TaskParameters.TeamHaveRecaller, 167, 0),
			new TaskParameterInfo(TaskParameters.BindedRecaller, 167, 0),
			new TaskParameterInfo(TaskParameters.ShowNeedFriendPoint, 167, 0),
			new TaskParameterInfo(TaskParameters.HistoryVarTask, 175, 0),
			new TaskParameterInfo(TaskParameters.PremRank, 175, 0),
			new TaskParameterInfo(TaskParameters.DeliverByUI, 175, 0),
			new TaskParameterInfo(TaskParameters.WarTaskAward, 177, 0),
			new TaskParameterInfo(TaskParameters.HideOtherPlayer, 180, 0),
			new TaskParameterInfo(TaskParameters.RecordDeliverTime, 187, 0),
			new TaskParameterInfo(TaskParameters.ShowMethod, 194, 0),
			new TaskParameterInfo(TaskParameters.CheckPanguLevel, 198, 0),
			new TaskParameterInfo(TaskParameters.AchievementSeriesId, 198, 0),
			new TaskParameterInfo(TaskParameters.VaguePromptingMode, 198, 0),
			new TaskParameterInfo(TaskParameters.CheckPanguEquip, 215, 0),
			new TaskParameterInfo(TaskParameters.ShowPanguEquipPremise, 215, 0),
			new TaskParameterInfo(TaskParameters.ShowExploreIcon, 215, 0),
			new TaskParameterInfo(TaskParameters.ShowByExpNotFull, 234, 0),
			new TaskParameterInfo(TaskParameters.CheckInventorySize, 218, 0),
			new TaskParameterInfo(TaskParameters.CheckStorageSize, 218, 0),
			new TaskParameterInfo(TaskParameters.ShowPackSizePremise, 218, 0),
			new TaskParameterInfo(TaskParameters.ShowByRealmExpNotFull, 234, 0),
			new TaskParameterInfo(TaskParameters.AllowBatchAward, 234, 0),
			new TaskParameterInfo(TaskParameters.CheckExp, 223, 0),
			new TaskParameterInfo(TaskParameters.CheckRealmExp, 223, 0),
			new TaskParameterInfo(TaskParameters.ShowPropertyPremis, 223, 0),
			new TaskParameterInfo(TaskParameters.CheckLieMoLevel, 223, 0),
			new TaskParameterInfo(TaskParameters.CheckYuMoLevel, 223, 0),
			new TaskParameterInfo(TaskParameters.ShowDailyActivityPremise, 229, 0),
			new TaskParameterInfo(TaskParameters.FailIconStateID, 236, 0),
			new TaskParameterInfo(TaskParameters.PremTotalItemsWanted, 238, 0),
			new TaskParameterInfo(TaskParameters.MethodTotalItemsWanted, 238, 0)
		};

		public static int GetParameterIndex(int version, TaskParameters param)
		{
			int num = 0;
			TaskParameterInfo[] array = taskParameterInfo_0;
			int num2 = 0;
			while (true)
			{
				if (num2 < array.Length)
				{
					TaskParameterInfo taskParameterInfo = array[num2];
					if (taskParameterInfo.IsValidForVersion(version))
					{
						if (taskParameterInfo.Parameter == param)
						{
							break;
						}
						num++;
					}
					num2++;
					continue;
				}
				return -1;
			}
			return num;
		}

		public static bool IsParameterValidForVersion(int version, TaskParameters param)
		{
			TaskParameterInfo[] array = taskParameterInfo_0;
			int num = 0;
			TaskParameterInfo taskParameterInfo;
			while (true)
			{
				if (num < array.Length)
				{
					taskParameterInfo = array[num];
					if (taskParameterInfo.Parameter == param)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return taskParameterInfo.IsValidForVersion(version);
		}

		public static int GetCombinedSwitchesCount(int version)
		{
			int num = 0;
			TaskParameterInfo[] array = taskParameterInfo_0;
			foreach (TaskParameterInfo taskParameterInfo in array)
			{
				if (taskParameterInfo.IsValidForVersion(version))
				{
					num++;
				}
			}
			return (num + 7) / 8;
		}
	}

	public enum TaskParameters
	{
		ShowByTransformed,
		ShowByLev,
		PremCheckReincarnation,
		ShowByReincarnation,
		PremCheckRealmLevel,
		PremCheckRealmExpFull,
		CheckTradeTime,
		ShowByTradeTime,
		ShowByRealmLevel,
		ShowByItems,
		PremItemsAnyOne,
		MethodItemsRandOne,
		NotOpenWithItem,
		ShowByDeposit,
		ShowByRepu,
		ShowByPreTask,
		ShowByPeriod,
		ShowByFaction,
		ShowByGender,
		ShowByOccup,
		Premise_Spouse,
		ShowBySpouse,
		PremiseWeddingOwner,
		ShowByWeddingOwner,
		GM,
		ShieldUser,
		ShowByRMB,
		CharTime,
		ShowByCharTime,
		Teamwork,
		RcvByTeam,
		SharedTask,
		SharedAchieved,
		CheckTeammate,
		AllFail,
		CapFail,
		CapSucc,
		DismAsSelfFail,
		RcvChckMem,
		CntByMemPos,
		AllSucc,
		CoupleOnly,
		DistinguishedOcc,
		ShowByTeam,
		PremNeedComp,
		PremNeedCompPerson,
		PremNeedCompHistory,
		PremCheckForce,
		ShowByForce,
		ShowByForceReputation,
		ShowByForceContribution,
		ShowByForceExp,
		ShowByForceSP,
		ShowByForceActivityLevel,
		PremIsKing,
		ShowByKing,
		PremNotInTeam,
		ShowByNotInTeam,
		ShowByTitle,
		ShowByHistoryStage,
		ShowByGeneralCard,
		ShowByGeneralCardRank,
		ShowByIconStateID,
		ShowByVIPLevel,
		PremNoHome,
		ShowByHomeLevel,
		ShowByHomeResourceLevel,
		ShowByHomeFactoryLevel,
		ShowByHomeFlourish,
		PremHomeStorageTask,
		ShowByHomeStorageTask,
		MonsterTotalCount,
		NotShowGfx,
		FinNeedComp,
		FinNeedCompPerson,
		FinNeedCompHistory,
		IsLibraryTask,
		IsUniqueStorageTask,
		HasSign,
		OfflineFail,
		ItemNotTakeOff,
		AbsTime,
		MultiNpcTalk,
		ChooseOne,
		RandOne,
		ExeChildInOrder,
		ParentAlsoFail,
		ParentAlsoSucc,
		CanGiveUp,
		CanRedo,
		CanRedoAfterFailure,
		ClearAsGiveUp,
		NeedRecord,
		FailAsPlayerDie,
		DelvInZone,
		EnterRegionFail,
		LeaveRegionFail,
		LeaveForceFail,
		TransTo,
		TrigCtrl,
		AutoDeliver,
		AutoDeliverHighPriority,
		DisplayInExclusiveUI,
		ReadyToNotifyServer,
		UsedInTokenShop,
		DeathTrig,
		ClearAcquired,
		ShowPrompt,
		KeyTask,
		SkillTask,
		CanSeekOut,
		ShowDirection,
		Marriage,
		SwitchSceneFail,
		Hidden,
		DeliverySkill,
		ShowGfxFinished,
		ChangePQRanking,
		CompareItemAndInventory,
		TowerTask,
		HomeTask,
		DeliverInHostHome,
		FinishInHostHome,
		PQTask,
		PQSubTask,
		ClearContrib,
		ShowByNeedRecordTasksNum,
		ShowByFactionContrib,
		AccountTaskLimit,
		RoleTaskLimit,
		LeaveFactionFail,
		NotIncCntWhenFailed,
		NotClearItemWhenFailed,
		DisplayInTitleTaskUI,
		CanAwardOnCarrier,
		PreReachArenaWinCount,
		ShowByReachArenaWinCount,
		WriteSpecialLog,
		ShowByPreFactionScore,
		ShowByPreFactionMoney,
		ShowByPreFactionPersonScore,
		CheckFactionMem,
		ByFactionScore,
		SpecailLogicTask,
		BecomeMentor,
		ShowMentorMorality,
		ShowMentorStudent,
		DiscardedTask,
		NoCheckTitleGot,
		ShowCoupleIntimacy,
		ShowByDeposit2,
		CrossServer,
		RecordFinishCount,
		RecordReset,
		ShowCamp,
		ShowCampPower,
		ReturnCampPower,
		TeamHaveRecaller,
		BindedRecaller,
		ShowNeedFriendPoint,
		HistoryVarTask,
		PremRank,
		DeliverByUI,
		WarTaskAward,
		HideOtherPlayer,
		RecordDeliverTime,
		ShowMethod,
		CheckPanguLevel,
		AchievementSeriesId,
		VaguePromptingMode,
		CheckPanguEquip,
		ShowPanguEquipPremise,
		ShowExploreIcon,
		ShowByExpNotFull,
		CheckInventorySize,
		CheckStorageSize,
		ShowPackSizePremise,
		ShowByRealmExpNotFull,
		AllowBatchAward,
		CheckExp,
		CheckRealmExp,
		ShowPropertyPremis,
		CheckLieMoLevel,
		CheckYuMoLevel,
		ShowDailyActivityPremise,
		FailIconStateID,
		PremTotalItemsWanted,
		MethodTotalItemsWanted
	}

	public enum task_tm_type : byte
	{
		enumTaskTimeDate,
		enumTaskTimeMonth,
		enumTaskTimeWeek,
		enumTaskTimeDay,
		enumTaskTimeUnkI,
		enumTaskTimeUnkII
	}

	public static int version = 241;

	public static int data_size = 0;

	public static int NewID = 0;

	public const short MAX_TASK_NAME_LEN = 30;

	public const short MAX_TIMETABLE_SIZE = 24;

	public const short MAX_TASKREGION = 16;

	public const short TASK_AWARD_MAX_CHANGE_VALUE = 255;

	public const short TASK_AWARD_MAX_DISPLAY_EXP_CNT = 32;

	public const short TASK_AWARD_MAX_DISPLAY_CHAR_LEN = 64;

	public const short MAX_CONTRIB_MONSTERS = 100;

	public const short MAX_ITEM_WANTED = 30;

	public const short MAX_PREM_TASK_COUNT = 20;

	public const short MAX_OCCUPATIONS = 18;

	public const short MAX_MUTEX_TASK_COUNT = 20;

	public const short MAX_NEEDED_TASK_COUNT = 20;

	public const short MAX_LIVING_SKILLS = 4;

	public const short MAX_TEAM_MEM_WANTED = 18;

	public const short MAX_TITLE_NUM = 999;

	public const short MAX_MONSTER_WANTED = 6;

	public const short MAX_PLAYER_WANTED = 6;

	public const short MAX_DIALOG_LEN = 20;

	public const short MAX_AWARD_SCALES = 6;

	public const short MAX_AWARD_CARRIER_HP_SCALES = 5;

	public const short MAX_AWARD_VAR_SCALES = 16;

	public const short MAX_COMBINED_SWITCHES = 20;

	public const short MAX_AWARD_CANDIDATES = 999;

	public const short MAX_ITEM_AWARD = 64;

	public const short MAX_MONSTER_SUMMONED = 32;

	public const short MAX_AWARD_PQ_RANKING = 32;

	public const short TASK_AWARD_MAX_DISPLAY_VALUE = 64;

	public static ArrayList Versions = new ArrayList(new int[122]
	{
		43, 52, 53, 54, 55, 56, 57, 59, 60, 63,
		64, 68, 69, 75, 78, 79, 80, 81, 82, 83,
		84, 85, 86, 87, 88, 89, 90, 91, 92, 93,
		94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
		104, 105, 106, 107, 108, 109, 110, 111, 112, 113,
		114, 115, 116, 117, 118, 119, 120, 121, 122, 123,
		124, 125, 126, 127, 128, 129, 130, 135, 137, 139,
		140, 146, 147, 153, 156, 157, 158, 161, 162, 163,
		164, 167, 175, 176, 177, 178, 180, 181, 182, 183,
		185, 186, 187, 188, 189, 190, 191, 192, 193, 194,
		195, 198, 215, 216, 217, 218, 219, 220, 223, 225,
		226, 227, 228, 229, 232, 234, 236, 237, 238, 239,
		240, 241
	});

	public const int BASIC_MAX_TASK_VERSION = 189;

	public static int GetMaxAllowedTaskVersion()
	{
		if (CommonStorage.License == null)
		{
			return 189;
		}
		if (LICENSE_INFO.Info.LicenseType != LICENSE_TYPE.DEV && !CommonStorage.License.Special.dev && !CommonStorage.License.GetFeatureEntitlementsByName(Class16.smethod_0(1648893727)) && !CommonStorage.License.GetFeatureEntitlementsByName(Class16.smethod_0(1649048505)))
		{
			if (LICENSE_INFO.Info.LicenseType != LICENSE_TYPE.PROFESSIONAL && LICENSE_INFO.Info.LicenseType != LICENSE_TYPE.BRAZILIAN_EDITION && LICENSE_INFO.Info.LicenseType != LICENSE_TYPE.ULTIMATE)
			{
				return 189;
			}
			return int.MaxValue;
		}
		return int.MaxValue;
	}
}
