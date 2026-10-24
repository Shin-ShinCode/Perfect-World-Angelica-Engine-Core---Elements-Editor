using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using ACE.Classes;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes.ChangeTaskParameters;

public class ChangeTaskParameters
{
	private sealed class Class387
	{
		public ATaskTempl ataskTempl_0;

		public ACE.sTASKedit.MainEditor.MainEditor mainEditor_0;

		public object object_0;

		public Control control_0;

		internal void method_0()
		{
			ataskTempl_0.m_bDisplayInExclusiveUI = smethod_7(mainEditor_0, ataskTempl_0.m_bDisplayInExclusiveUI, object_0);
		}

		internal void method_1()
		{
			ataskTempl_0.m_bDisplayInTitleTaskUI = smethod_7(mainEditor_0, ataskTempl_0.m_bDisplayInTitleTaskUI, object_0);
		}

		internal void method_2()
		{
			ataskTempl_0.m_bReadyToNotifyServer = smethod_7(mainEditor_0, ataskTempl_0.m_bReadyToNotifyServer, object_0);
		}

		internal void method_3()
		{
			ataskTempl_0.m_bUsedInTokenShop = smethod_7(mainEditor_0, ataskTempl_0.m_bUsedInTokenShop, object_0);
		}

		internal void method_4()
		{
			ataskTempl_0.m_bDeathTrig = smethod_7(mainEditor_0, ataskTempl_0.m_bDeathTrig, object_0);
		}

		internal void method_5()
		{
			ataskTempl_0.m_bClearAcquired = smethod_7(mainEditor_0, ataskTempl_0.m_bClearAcquired, object_0);
		}

		internal void method_6()
		{
			ataskTempl_0.m_bShowGfxFinished = smethod_7(mainEditor_0, ataskTempl_0.m_bShowGfxFinished, object_0);
		}

		internal void method_7()
		{
			ataskTempl_0.m_bChangePQRanking = smethod_7(mainEditor_0, ataskTempl_0.m_bChangePQRanking, object_0);
		}

		internal void method_8()
		{
			ataskTempl_0.m_bCompareItemAndInventory = smethod_7(mainEditor_0, ataskTempl_0.m_bCompareItemAndInventory, object_0);
		}

		internal void method_9()
		{
			ataskTempl_0.m_ulInventorySlotNum = smethod_14(mainEditor_0, ataskTempl_0.m_ulInventorySlotNum, object_0);
		}

		internal void method_10()
		{
			ataskTempl_0.m_bShowMethod = smethod_7(mainEditor_0, ataskTempl_0.m_bShowMethod, object_0);
		}

		internal void method_11()
		{
			ataskTempl_0.m_iGfxType = smethod_15(mainEditor_0, ataskTempl_0.m_iGfxType, object_0);
		}

		internal void method_12()
		{
			ataskTempl_0.m_bTowerTask = smethod_7(mainEditor_0, ataskTempl_0.m_bTowerTask, object_0);
		}

		internal void method_13()
		{
			ataskTempl_0.m_bHomeTask = smethod_7(mainEditor_0, ataskTempl_0.m_bHomeTask, object_0);
		}

		internal void method_14()
		{
			ataskTempl_0.m_bDeliverInHostHome = smethod_7(mainEditor_0, ataskTempl_0.m_bDeliverInHostHome, object_0);
		}

		internal void method_15()
		{
			ataskTempl_0.m_bFinishInHostHome = smethod_7(mainEditor_0, ataskTempl_0.m_bFinishInHostHome, object_0);
		}

		internal void method_16()
		{
			ataskTempl_0.m_bPQTask = smethod_7(mainEditor_0, ataskTempl_0.m_bPQTask, object_0);
		}

		internal void method_17()
		{
			ataskTempl_0.m_bPQSubTask = smethod_7(mainEditor_0, ataskTempl_0.m_bPQSubTask, object_0);
		}

		internal void method_18()
		{
			ataskTempl_0.m_bClearContrib = smethod_7(mainEditor_0, ataskTempl_0.m_bClearContrib, object_0);
		}

		internal void method_19()
		{
			ataskTempl_0.m_bAccountTaskLimit = smethod_7(mainEditor_0, ataskTempl_0.m_bAccountTaskLimit, object_0);
		}

		internal void method_20()
		{
			ataskTempl_0.m_bRoleTaskLimit = smethod_7(mainEditor_0, ataskTempl_0.m_bRoleTaskLimit, object_0);
		}

		internal void method_21()
		{
			ataskTempl_0.m_ulAccountTaskLimitCnt = smethod_14(mainEditor_0, ataskTempl_0.m_ulAccountTaskLimitCnt, object_0);
		}

		internal void method_22()
		{
			ataskTempl_0.m_bLeaveFactionFail = smethod_7(mainEditor_0, ataskTempl_0.m_bLeaveFactionFail, object_0);
		}

		internal void method_23()
		{
			ataskTempl_0.m_bNotIncCntWhenFailed = smethod_7(mainEditor_0, ataskTempl_0.m_bNotIncCntWhenFailed, object_0);
		}

		internal void method_24()
		{
			ataskTempl_0.m_bNotClearItemWhenFailed = smethod_7(mainEditor_0, ataskTempl_0.m_bNotClearItemWhenFailed, object_0);
		}

		internal void method_25()
		{
			ataskTempl_0.m_ulSuitableLevel = smethod_14(mainEditor_0, ataskTempl_0.m_ulSuitableLevel, object_0);
		}

		internal void method_26()
		{
			ataskTempl_0.m_iPremNeedRecordTasksNum = smethod_14(mainEditor_0, ataskTempl_0.m_iPremNeedRecordTasksNum, object_0);
		}

		internal void method_27()
		{
			ataskTempl_0.m_bShowByNeedRecordTasksNum = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByNeedRecordTasksNum, object_0);
		}

		internal void method_28()
		{
			ataskTempl_0.m_iPremiseFactionContrib = smethod_13(mainEditor_0, ataskTempl_0.m_iPremiseFactionContrib, object_0, 2);
		}

		internal void method_29()
		{
			ataskTempl_0.m_bShowByFactionContrib = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByFactionContrib, object_0);
		}

		internal void method_30()
		{
			ataskTempl_0.m_ucPremiseTransformedForm = smethod_8(mainEditor_0, ataskTempl_0.m_ucPremiseTransformedForm, object_0);
		}

		internal void method_31()
		{
			ataskTempl_0.m_cEffectiveGameServer = smethod_8(mainEditor_0, ataskTempl_0.m_cEffectiveGameServer, object_0);
		}

		internal void method_32()
		{
			ataskTempl_0.m_cPremInventorySizeMax = smethod_8(mainEditor_0, ataskTempl_0.m_cPremInventorySizeMax, object_0);
		}

		internal void method_33()
		{
			ataskTempl_0.m_cPremInventorySizeMin = smethod_8(mainEditor_0, ataskTempl_0.m_cPremInventorySizeMin, object_0);
		}

		internal void method_34()
		{
			ataskTempl_0.m_cPremStorageSizeMax = smethod_8(mainEditor_0, ataskTempl_0.m_cPremStorageSizeMax, object_0);
		}

		internal void method_35()
		{
			ataskTempl_0.m_cPremStorageSizeMin = smethod_8(mainEditor_0, ataskTempl_0.m_cPremStorageSizeMin, object_0);
		}

		internal void method_36()
		{
			ataskTempl_0.m_iSlotMachineType = smethod_8(mainEditor_0, ataskTempl_0.m_iSlotMachineType, object_0);
		}

		internal void method_37()
		{
			ataskTempl_0.m_bShowByTransformed = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByTransformed, object_0);
		}

		internal void method_38()
		{
			ataskTempl_0.m_ulPremise_Lev_Min = smethod_14(mainEditor_0, ataskTempl_0.m_ulPremise_Lev_Min, object_0);
		}

		internal void method_39()
		{
			ataskTempl_0.m_ulPremise_Lev_Max = smethod_14(mainEditor_0, ataskTempl_0.m_ulPremise_Lev_Max, object_0);
		}

		internal void method_40()
		{
			ataskTempl_0.m_bPremCheckMaxHistoryLevel = Convert.ToInt32(smethod_7(mainEditor_0, Convert.ToBoolean(ataskTempl_0.m_bPremCheckMaxHistoryLevel), object_0));
		}

		internal void method_41()
		{
			ataskTempl_0.m_bShowByLev = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByLev, object_0);
		}

		internal void method_42()
		{
			ataskTempl_0.m_bPremCheckReincarnation = smethod_7(mainEditor_0, ataskTempl_0.m_bPremCheckReincarnation, object_0);
		}

		internal void method_43()
		{
			ataskTempl_0.m_ulPremReincarnationMin = smethod_14(mainEditor_0, ataskTempl_0.m_ulPremReincarnationMin, object_0);
		}

		internal void method_44()
		{
			ataskTempl_0.m_ulPremReincarnationMax = smethod_14(mainEditor_0, ataskTempl_0.m_ulPremReincarnationMax, object_0);
		}

		internal void method_45()
		{
			ataskTempl_0.m_bShowByReincarnation = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByReincarnation, object_0);
		}

		internal void method_46()
		{
			ataskTempl_0.m_bPremCheckRealmLevel = smethod_7(mainEditor_0, ataskTempl_0.m_bPremCheckRealmLevel, object_0);
		}

		internal void method_47()
		{
			ataskTempl_0.m_ulPremRealmLevelMin = smethod_14(mainEditor_0, ataskTempl_0.m_ulPremRealmLevelMin, object_0);
			mainEditor_0.ShowRealmLevelName(control_0, ataskTempl_0.m_ulPremRealmLevelMin);
		}

		internal void method_48()
		{
			ataskTempl_0.m_ulPremRealmLevelMax = smethod_14(mainEditor_0, ataskTempl_0.m_ulPremRealmLevelMax, object_0);
			mainEditor_0.ShowRealmLevelName(control_0, ataskTempl_0.m_ulPremRealmLevelMax);
		}

		internal void method_49()
		{
			ataskTempl_0.m_bPremCheckRealmExpFull = smethod_7(mainEditor_0, ataskTempl_0.m_bPremCheckRealmExpFull, object_0);
		}

		internal void method_50()
		{
			ataskTempl_0.m_bShowByRealmLevel = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByRealmLevel, object_0);
		}

		internal void method_51()
		{
			ataskTempl_0.m_bRecordDeliverTime = smethod_7(mainEditor_0, ataskTempl_0.m_bRecordDeliverTime, object_0);
		}

		internal void method_52()
		{
			ataskTempl_0.m_bAllowBatchAward = smethod_7(mainEditor_0, ataskTempl_0.m_bAllowBatchAward, object_0);
		}

		internal void method_53()
		{
			ataskTempl_0.m_bCheckExp = smethod_7(mainEditor_0, ataskTempl_0.m_bCheckExp, object_0);
		}

		internal void method_54()
		{
			ataskTempl_0.m_bCheckInventorySize = smethod_7(mainEditor_0, ataskTempl_0.m_bCheckInventorySize, object_0);
		}

		internal void method_55()
		{
			ataskTempl_0.m_bCheckStorageSize = smethod_7(mainEditor_0, ataskTempl_0.m_bCheckStorageSize, object_0);
		}

		internal void method_56()
		{
			ataskTempl_0.m_bMethodItemsRandOne = smethod_7(mainEditor_0, ataskTempl_0.m_bMethodItemsRandOne, object_0);
		}

		internal void method_57()
		{
			ataskTempl_0.m_bCheckYuMoLevel = smethod_7(mainEditor_0, ataskTempl_0.m_bCheckYuMoLevel, object_0);
		}

		internal void method_58()
		{
			ataskTempl_0.m_bPremCheckPanguLevel = smethod_7(mainEditor_0, ataskTempl_0.m_bPremCheckPanguLevel, object_0);
		}

		internal void method_59()
		{
			ataskTempl_0.m_bRecordReset = smethod_7(mainEditor_0, ataskTempl_0.m_bRecordReset, object_0);
		}

		internal void method_60()
		{
			ataskTempl_0.m_bShowAchievementSeriesId = smethod_7(mainEditor_0, ataskTempl_0.m_bShowAchievementSeriesId, object_0);
		}

		internal void method_61()
		{
			ataskTempl_0.m_bShowByRealmExpNotFull = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByRealmExpNotFull, object_0);
		}

		internal void method_62()
		{
			ataskTempl_0.m_bShowByTradeTime = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByTradeTime, object_0);
		}

		internal void method_63()
		{
			ataskTempl_0.m_bShowDailyActivityPremise = smethod_7(mainEditor_0, ataskTempl_0.m_bShowDailyActivityPremise, object_0);
		}

		internal void method_64()
		{
			ataskTempl_0.m_bShowPanguEquipPremise = smethod_7(mainEditor_0, ataskTempl_0.m_bShowPanguEquipPremise, object_0);
		}

		internal void method_65()
		{
			ataskTempl_0.m_bShowPropertyPremis = smethod_7(mainEditor_0, ataskTempl_0.m_bShowPropertyPremis, object_0);
		}

		internal void method_66()
		{
			ataskTempl_0.m_bVaguePromptingMode = smethod_7(mainEditor_0, ataskTempl_0.m_bVaguePromptingMode, object_0);
		}

		internal void method_67()
		{
			ataskTempl_0.m_bShowPackSizePremise = smethod_7(mainEditor_0, ataskTempl_0.m_bShowPackSizePremise, object_0);
		}

		internal void method_68()
		{
			ataskTempl_0.m_bShowExploreIcon = smethod_7(mainEditor_0, ataskTempl_0.m_bShowExploreIcon, object_0);
		}

		internal void method_69()
		{
			ataskTempl_0.m_bShowByExpNotFull = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByExpNotFull, object_0);
		}

		internal void method_70()
		{
			ataskTempl_0.m_bDoNotShowGfx = smethod_7(mainEditor_0, ataskTempl_0.m_bDoNotShowGfx, object_0);
		}

		internal void method_71()
		{
			ataskTempl_0.m_bCheckTradeTime = smethod_7(mainEditor_0, ataskTempl_0.m_bCheckTradeTime, object_0);
		}

		internal void method_72()
		{
			ataskTempl_0.m_bCheckPanguEquip = smethod_7(mainEditor_0, ataskTempl_0.m_bCheckPanguEquip, object_0);
		}

		internal void method_73()
		{
			ataskTempl_0.m_bCheckRealmExp = smethod_7(mainEditor_0, ataskTempl_0.m_bCheckRealmExp, object_0);
		}

		internal void method_74()
		{
			ataskTempl_0.m_bCheckLieMoLevel = smethod_7(mainEditor_0, ataskTempl_0.m_bCheckLieMoLevel, object_0);
		}

		internal void method_75()
		{
			ataskTempl_0.m_bFailIconStateID = smethod_7(mainEditor_0, ataskTempl_0.m_bFailIconStateID, object_0);
		}

		internal void method_76()
		{
			ataskTempl_0.m_bAutoDeliverHighPriority = smethod_7(mainEditor_0, ataskTempl_0.m_bAutoDeliverHighPriority, object_0);
		}

		internal void method_77()
		{
			ataskTempl_0.m_bPremTotalItemsWanted = smethod_7(mainEditor_0, ataskTempl_0.m_bPremTotalItemsWanted, object_0);
		}

		internal void method_78()
		{
			ataskTempl_0.m_bMethodTotalItemsWanted = smethod_7(mainEditor_0, ataskTempl_0.m_bMethodTotalItemsWanted, object_0);
		}

		internal void method_79()
		{
			ataskTempl_0.m_iCameraMovementID = smethod_13(mainEditor_0, ataskTempl_0.m_iCameraMovementID, object_0, 0);
		}

		internal void method_80()
		{
			ataskTempl_0.m_iPremDailyActivityValue = smethod_13(mainEditor_0, ataskTempl_0.m_iPremDailyActivityValue, object_0, 2);
		}

		internal void method_81()
		{
			ataskTempl_0.m_bCanAwardOnCarrier = smethod_7(mainEditor_0, ataskTempl_0.m_bCanAwardOnCarrier, object_0);
		}

		internal void method_82()
		{
			ataskTempl_0.m_bCheckFactionMember = smethod_7(mainEditor_0, ataskTempl_0.m_bCheckFactionMember, object_0);
		}

		internal void method_83()
		{
			ataskTempl_0.m_iFactionMember = smethod_13(mainEditor_0, ataskTempl_0.m_iFactionMember, object_0, 2);
		}

		internal void method_84()
		{
			ataskTempl_0.m_bSpecialLogic = smethod_7(mainEditor_0, ataskTempl_0.m_bSpecialLogic, object_0);
		}

		internal void method_85()
		{
			ataskTempl_0.m_bDiscardedTask = smethod_7(mainEditor_0, ataskTempl_0.m_bDiscardedTask, object_0);
			GlobalFunctions.UpdateNode(mainEditor_0.treeView_tasks.SelectedNode, ataskTempl_0, 1, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
			mainEditor_0.textBox_m_szName.ForeColor = mainEditor_0.treeView_tasks.SelectedNode.ForeColor;
		}

		internal void method_86()
		{
			ataskTempl_0.m_bNoCheckTitleGot = smethod_7(mainEditor_0, ataskTempl_0.m_bNoCheckTitleGot, object_0);
		}

		internal void method_87()
		{
			ataskTempl_0.m_ulCrossServerId = smethod_14(mainEditor_0, ataskTempl_0.m_ulCrossServerId, object_0);
		}

		internal void method_88()
		{
			ataskTempl_0.m_bCrossServer = smethod_7(mainEditor_0, ataskTempl_0.m_bCrossServer, object_0);
		}

		internal void method_89()
		{
			ataskTempl_0.m_ulIconStateIDForAwardVar = smethod_13(mainEditor_0, ataskTempl_0.m_ulIconStateIDForAwardVar, object_0, 0);
		}

		internal void method_90()
		{
			ataskTempl_0.m_lGlobalKeyForAwardVar = smethod_13(mainEditor_0, ataskTempl_0.m_lGlobalKeyForAwardVar, object_0, 0);
		}

		internal void method_91()
		{
			ataskTempl_0.m_lPersonKeyForAwardVar = smethod_13(mainEditor_0, ataskTempl_0.m_lPersonKeyForAwardVar, object_0, 0);
		}

		internal void method_92()
		{
			ataskTempl_0.m_lHistoryKeyForAwardVar = smethod_13(mainEditor_0, ataskTempl_0.m_lHistoryKeyForAwardVar, object_0, 0);
		}

		internal void method_93()
		{
			ataskTempl_0.m_bRecordFnshCnt = smethod_7(mainEditor_0, ataskTempl_0.m_bRecordFnshCnt, object_0);
		}

		internal void method_94()
		{
			ataskTempl_0.m_bTeamHaveRecaller = smethod_7(mainEditor_0, ataskTempl_0.m_bTeamHaveRecaller, object_0);
		}

		internal void method_95()
		{
			ataskTempl_0.m_bBindedRecaller = smethod_7(mainEditor_0, ataskTempl_0.m_bBindedRecaller, object_0);
		}

		internal void method_96()
		{
			ataskTempl_0.m_bHistoryVarTask = smethod_7(mainEditor_0, ataskTempl_0.m_bHistoryVarTask, object_0);
		}
	}

	private sealed class Class388
	{
		public ATaskTempl ataskTempl_0;

		public ACE.sTASKedit.MainEditor.MainEditor mainEditor_0;

		public object object_0;

		internal void method_0()
		{
			ataskTempl_0.m_bOfflineFail = smethod_7(mainEditor_0, ataskTempl_0.m_bOfflineFail, object_0);
		}

		internal void method_1()
		{
			ataskTempl_0.m_bAbsFail = smethod_7(mainEditor_0, ataskTempl_0.m_bAbsFail, object_0);
		}

		internal void method_2()
		{
			ataskTempl_0.m_tmAbsFailTime = smethod_18(mainEditor_0, ataskTempl_0.m_tmAbsFailTime, object_0);
		}

		internal void method_3()
		{
			ataskTempl_0.m_ulTimeLimit = smethod_13(mainEditor_0, ataskTempl_0.m_ulTimeLimit, object_0, 1);
		}

		internal void method_4()
		{
			ataskTempl_0.m_bNextTimeFail = smethod_7(mainEditor_0, ataskTempl_0.m_bNextTimeFail, object_0);
		}

		internal void method_5()
		{
			ataskTempl_0.m_bAbsTime = smethod_7(mainEditor_0, ataskTempl_0.m_bAbsTime, object_0);
		}

		internal void method_6()
		{
			ataskTempl_0.m_lAvailFrequency = smethod_15(mainEditor_0, ataskTempl_0.m_lAvailFrequency, object_0);
		}

		internal void method_7()
		{
			ataskTempl_0.m_lFrequencyNum = smethod_14(mainEditor_0, ataskTempl_0.m_lFrequencyNum, object_0);
		}

		internal void method_8()
		{
			ataskTempl_0.m_lPeriodLimit = smethod_14(mainEditor_0, ataskTempl_0.m_lPeriodLimit, object_0);
		}

		internal void method_9()
		{
			ataskTempl_0.m_bAvailFrequency = smethod_7(mainEditor_0, ataskTempl_0.m_bAvailFrequency, object_0);
		}

		internal void method_10()
		{
			ataskTempl_0.m_bChooseOne = smethod_7(mainEditor_0, ataskTempl_0.m_bChooseOne, object_0);
		}

		internal void method_11()
		{
			ataskTempl_0.m_bRandOne = smethod_7(mainEditor_0, ataskTempl_0.m_bRandOne, object_0);
		}

		internal void method_12()
		{
			ataskTempl_0.m_bExeChildInOrder = smethod_7(mainEditor_0, ataskTempl_0.m_bExeChildInOrder, object_0);
		}

		internal void method_13()
		{
			ataskTempl_0.m_bParentAlsoFail = smethod_7(mainEditor_0, ataskTempl_0.m_bParentAlsoFail, object_0);
		}

		internal void method_14()
		{
			ataskTempl_0.m_bParentAlsoSucc = smethod_7(mainEditor_0, ataskTempl_0.m_bParentAlsoSucc, object_0);
		}

		internal void method_15()
		{
			ataskTempl_0.m_bCanGiveUp = smethod_7(mainEditor_0, ataskTempl_0.m_bCanGiveUp, object_0);
		}

		internal void method_16()
		{
			ataskTempl_0.m_bCanRedo = smethod_7(mainEditor_0, ataskTempl_0.m_bCanRedo, object_0);
		}

		internal void method_17()
		{
			ataskTempl_0.m_bCanRedoAfterFailure = smethod_7(mainEditor_0, ataskTempl_0.m_bCanRedoAfterFailure, object_0);
		}

		internal void method_18()
		{
			ataskTempl_0.m_bClearAsGiveUp = smethod_7(mainEditor_0, ataskTempl_0.m_bClearAsGiveUp, object_0);
		}

		internal void method_19()
		{
			ataskTempl_0.m_bNeedRecord = smethod_7(mainEditor_0, ataskTempl_0.m_bNeedRecord, object_0);
		}

		internal void method_20()
		{
			ataskTempl_0.m_bFailAsPlayerDie = smethod_7(mainEditor_0, ataskTempl_0.m_bFailAsPlayerDie, object_0);
		}

		internal void method_21()
		{
			ataskTempl_0.m_ulMaxReceiver = smethod_14(mainEditor_0, ataskTempl_0.m_ulMaxReceiver, object_0);
		}

		internal void method_22()
		{
			ataskTempl_0.m_bItemNotTakeOff = smethod_7(mainEditor_0, ataskTempl_0.m_bItemNotTakeOff, object_0);
		}

		internal void method_23()
		{
			ataskTempl_0.m_bMultiNpcTalk = smethod_7(mainEditor_0, ataskTempl_0.m_bMultiNpcTalk, object_0);
		}

		internal void method_24()
		{
			ataskTempl_0.m_bSkillTask = smethod_7(mainEditor_0, ataskTempl_0.m_bSkillTask, object_0);
		}

		internal void method_25()
		{
			ataskTempl_0.m_bCanSeekOut = smethod_7(mainEditor_0, ataskTempl_0.m_bCanSeekOut, object_0);
		}

		internal void method_26()
		{
			ataskTempl_0.m_bShowDirection = smethod_7(mainEditor_0, ataskTempl_0.m_bShowDirection, object_0);
		}

		internal void method_27()
		{
			ataskTempl_0.m_bMarriage = smethod_7(mainEditor_0, ataskTempl_0.m_bMarriage, object_0);
		}

		internal void method_28()
		{
			ataskTempl_0.m_bSwitchSceneFail = smethod_7(mainEditor_0, ataskTempl_0.m_bSwitchSceneFail, object_0);
		}

		internal void method_29()
		{
			ataskTempl_0.m_bHidden = smethod_7(mainEditor_0, ataskTempl_0.m_bHidden, object_0);
		}

		internal void method_30()
		{
			ataskTempl_0.m_bShowPrompt = smethod_7(mainEditor_0, ataskTempl_0.m_bShowPrompt, object_0);
		}

		internal void method_31()
		{
			ataskTempl_0.m_bKeyTask = smethod_7(mainEditor_0, ataskTempl_0.m_bKeyTask, object_0);
			GlobalFunctions.UpdateNode(mainEditor_0.treeView_tasks.SelectedNode, ataskTempl_0, 1, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
			mainEditor_0.textBox_m_szName.ForeColor = mainEditor_0.treeView_tasks.SelectedNode.ForeColor;
		}

		internal void method_32()
		{
			ataskTempl_0.m_bGM = smethod_7(mainEditor_0, ataskTempl_0.m_bGM, object_0);
			GlobalFunctions.UpdateNode(mainEditor_0.treeView_tasks.SelectedNode, ataskTempl_0, 1, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
			mainEditor_0.textBox_m_szName.ForeColor = mainEditor_0.treeView_tasks.SelectedNode.ForeColor;
		}

		internal void method_33()
		{
			ataskTempl_0.m_bShieldUser = smethod_7(mainEditor_0, ataskTempl_0.m_bShieldUser, object_0);
		}

		internal void method_34()
		{
			ataskTempl_0.m_bTeamwork = smethod_7(mainEditor_0, ataskTempl_0.m_bTeamwork, object_0);
		}

		internal void method_35()
		{
			ataskTempl_0.m_bRcvByTeam = smethod_7(mainEditor_0, ataskTempl_0.m_bRcvByTeam, object_0);
		}

		internal void method_36()
		{
			ataskTempl_0.m_bSharedTask = smethod_7(mainEditor_0, ataskTempl_0.m_bSharedTask, object_0);
		}

		internal void method_37()
		{
			ataskTempl_0.m_bSharedAchieved = smethod_7(mainEditor_0, ataskTempl_0.m_bSharedAchieved, object_0);
		}

		internal void method_38()
		{
			ataskTempl_0.m_bCheckTeammate = smethod_7(mainEditor_0, ataskTempl_0.m_bCheckTeammate, object_0);
		}

		internal void method_39()
		{
			ataskTempl_0.m_bAllFail = smethod_7(mainEditor_0, ataskTempl_0.m_bAllFail, object_0);
		}

		internal void method_40()
		{
			ataskTempl_0.m_bCapFail = smethod_7(mainEditor_0, ataskTempl_0.m_bCapFail, object_0);
		}

		internal void method_41()
		{
			ataskTempl_0.m_bCapSucc = smethod_7(mainEditor_0, ataskTempl_0.m_bCapSucc, object_0);
		}

		internal void method_42()
		{
			ataskTempl_0.m_bDismAsSelfFail = smethod_7(mainEditor_0, ataskTempl_0.m_bDismAsSelfFail, object_0);
		}

		internal void method_43()
		{
			ataskTempl_0.m_bRcvChckMem = smethod_7(mainEditor_0, ataskTempl_0.m_bRcvChckMem, object_0);
		}

		internal void method_44()
		{
			ataskTempl_0.m_bCntByMemPos = smethod_7(mainEditor_0, ataskTempl_0.m_bCntByMemPos, object_0);
		}

		internal void method_45()
		{
			ataskTempl_0.m_bAllSucc = smethod_7(mainEditor_0, ataskTempl_0.m_bAllSucc, object_0);
		}

		internal void method_46()
		{
			ataskTempl_0.m_bCoupleOnly = smethod_7(mainEditor_0, ataskTempl_0.m_bCoupleOnly, object_0);
		}

		internal void method_47()
		{
			ataskTempl_0.m_bDistinguishedOcc = smethod_7(mainEditor_0, ataskTempl_0.m_bDistinguishedOcc, object_0);
		}
	}

	private sealed class Class389
	{
		public ACE.sTASKedit.MainEditor.MainEditor mainEditor_0;

		public object object_0;

		public AWARD_DATA award_DATA_0;

		public Control control_0;

		internal void method_0()
		{
			award_DATA_0.m_ulGoldNum = smethod_13(mainEditor_0, award_DATA_0.m_ulGoldNum, object_0, 2);
		}

		internal void method_1()
		{
			award_DATA_0.m_uiGroupNum = smethod_14(mainEditor_0, award_DATA_0.m_uiGroupNum, object_0);
			mainEditor_0.UpdatenumericUpDown_Award_m_uiGroupNum(mainEditor_0.numericUpDown_Award_m_uiGroupNum.Value);
		}

		internal void method_2()
		{
			award_DATA_0.m_uiNumPerGroup = smethod_14(mainEditor_0, award_DATA_0.m_uiNumPerGroup, object_0);
			mainEditor_0.UpdatenumericUpDown_Award_m_uiNumPerGroup(mainEditor_0.numericUpDown_Award_m_uiNumPerGroup.Value);
		}

		internal void method_3()
		{
			award_DATA_0.m_ulExp = smethod_13(mainEditor_0, award_DATA_0.m_ulExp, object_0, 2);
			mainEditor_0.CalculationExpAndSPDependingOnLvlAndNum(null, null);
		}

		internal void method_4()
		{
			award_DATA_0.m_ulRealmExp = smethod_13(mainEditor_0, award_DATA_0.m_ulRealmExp, object_0, 2);
		}

		internal void method_5()
		{
			award_DATA_0.m_bExpandRealmLevelMax = smethod_7(mainEditor_0, award_DATA_0.m_bExpandRealmLevelMax, object_0);
		}

		internal void method_6()
		{
			award_DATA_0.NewTaskSpace = smethod_15(mainEditor_0, award_DATA_0.NewTaskSpace, object_0);
		}

		internal void method_7()
		{
			award_DATA_0.m_ulNewTask = smethod_13(mainEditor_0, award_DATA_0.m_ulNewTask, object_0, 0);
		}

		internal void method_8()
		{
			award_DATA_0.m_ulSP = smethod_13(mainEditor_0, award_DATA_0.m_ulSP, object_0, 2);
			mainEditor_0.CalculationExpAndSPDependingOnLvlAndNum(null, null);
		}

		internal void method_9()
		{
			award_DATA_0.m_lReputation = smethod_13(mainEditor_0, award_DATA_0.m_lReputation, object_0, 2);
		}

		internal void method_10()
		{
			if (mainEditor_0.comboBox_Award_m_ulNewPeriod.SelectedIndex < 9)
			{
				award_DATA_0.m_ulNewPeriod = mainEditor_0.comboBox_Award_m_ulNewPeriod.SelectedIndex;
			}
			else
			{
				switch (mainEditor_0.comboBox_Award_m_ulNewPeriod.SelectedIndex)
				{
				case 9:
					award_DATA_0.m_ulNewPeriod = 20;
					break;
				case 10:
					award_DATA_0.m_ulNewPeriod = 30;
					break;
				case 11:
					award_DATA_0.m_ulNewPeriod = 21;
					break;
				case 12:
					award_DATA_0.m_ulNewPeriod = 31;
					break;
				case 13:
					award_DATA_0.m_ulNewPeriod = 22;
					break;
				case 14:
					award_DATA_0.m_ulNewPeriod = 32;
					break;
				case 15:
					award_DATA_0.m_ulNewPeriod = 40;
					break;
				case 16:
					award_DATA_0.m_ulNewPeriod = 41;
					break;
				}
			}
			mainEditor_0.TriggerDebug(control_0);
		}

		internal void method_11()
		{
			award_DATA_0.m_ulNewRelayStation = smethod_13(mainEditor_0, award_DATA_0.m_ulNewRelayStation, object_0, 0);
		}

		internal void method_12()
		{
			award_DATA_0.m_ulStorehouseSize = smethod_13(mainEditor_0, award_DATA_0.m_ulStorehouseSize, object_0, 2);
		}

		internal void method_13()
		{
			award_DATA_0.m_ulStorehouseSize2 = smethod_13(mainEditor_0, award_DATA_0.m_ulStorehouseSize2, object_0, 2);
		}

		internal void method_14()
		{
			award_DATA_0.m_ulStorehouseSize3 = smethod_13(mainEditor_0, award_DATA_0.m_ulStorehouseSize3, object_0, 2);
		}

		internal void method_15()
		{
			award_DATA_0.m_ulStorehouseSize4 = smethod_13(mainEditor_0, award_DATA_0.m_ulStorehouseSize4, object_0, 2);
		}

		internal void method_16()
		{
			award_DATA_0.m_lInventorySize = smethod_13(mainEditor_0, award_DATA_0.m_lInventorySize, object_0, 2);
		}

		internal void method_17()
		{
			award_DATA_0.m_ulPetInventorySize = smethod_13(mainEditor_0, award_DATA_0.m_ulPetInventorySize, object_0, 2);
		}

		internal void method_18()
		{
			award_DATA_0.m_ulFuryULimit = smethod_13(mainEditor_0, award_DATA_0.m_ulFuryULimit, object_0, 2);
		}

		internal void method_19()
		{
			award_DATA_0.m_ulTransWldId = smethod_13(mainEditor_0, award_DATA_0.m_ulTransWldId, object_0, 0);
		}

		internal void method_20()
		{
			award_DATA_0.m_ulCrossServerWldId = smethod_13(mainEditor_0, award_DATA_0.m_ulCrossServerWldId, object_0, 0);
		}

		internal void method_21()
		{
			award_DATA_0.m_TransPt.Single_0[0] = smethod_17(mainEditor_0, award_DATA_0.m_TransPt.Single_0[0], object_0, 0);
		}

		internal void method_22()
		{
			award_DATA_0.m_TransPt.Single_0[1] = smethod_17(mainEditor_0, award_DATA_0.m_TransPt.Single_0[1], object_0, 0);
		}

		internal void method_23()
		{
			award_DATA_0.m_TransPt.Single_0[2] = smethod_17(mainEditor_0, award_DATA_0.m_TransPt.Single_0[2], object_0, 0);
		}

		internal void method_24()
		{
			award_DATA_0.m_lMonsCtrl = smethod_13(mainEditor_0, award_DATA_0.m_lMonsCtrl, object_0, 0);
		}

		internal void method_25()
		{
			award_DATA_0.m_bTrigCtrl = smethod_7(mainEditor_0, award_DATA_0.m_bTrigCtrl, object_0);
		}

		internal void method_26()
		{
			award_DATA_0.m_bUseLevCo = smethod_7(mainEditor_0, award_DATA_0.m_bUseLevCo, object_0);
			mainEditor_0.CalculationExpAndSPDependingOnLvlAndNum(null, null);
			mainEditor_0.ShowHide();
		}

		internal void method_27()
		{
			award_DATA_0.m_bDivorce = smethod_7(mainEditor_0, award_DATA_0.m_bDivorce, object_0);
		}

		internal void method_28()
		{
			award_DATA_0.m_bSendMsg = smethod_7(mainEditor_0, award_DATA_0.m_bSendMsg, object_0);
		}

		internal void method_29()
		{
			award_DATA_0.m_nMsgChannel = smethod_15(mainEditor_0, award_DATA_0.m_nMsgChannel, object_0);
			mainEditor_0.FormatingString(2);
		}

		internal void method_30()
		{
			award_DATA_0.m_SummonedMonsters.m_bRandChoose = smethod_7(mainEditor_0, award_DATA_0.m_SummonedMonsters.m_bRandChoose, object_0);
		}

		internal void method_31()
		{
			award_DATA_0.m_SummonedMonsters.m_ulSummonRadius = smethod_13(mainEditor_0, award_DATA_0.m_SummonedMonsters.m_ulSummonRadius, object_0, 2);
		}

		internal void method_32()
		{
			award_DATA_0.m_SummonedMonsters.m_bDeathDisappear = smethod_7(mainEditor_0, award_DATA_0.m_SummonedMonsters.m_bDeathDisappear, object_0);
		}

		internal void method_33()
		{
			award_DATA_0.m_bAwardDeath = smethod_7(mainEditor_0, award_DATA_0.m_bAwardDeath, object_0);
		}

		internal void method_34()
		{
			award_DATA_0.m_bAwardDeathWithLoss = smethod_7(mainEditor_0, award_DATA_0.m_bAwardDeathWithLoss, object_0);
		}

		internal void method_35()
		{
			award_DATA_0.m_ulDividend = smethod_13(mainEditor_0, award_DATA_0.m_ulDividend, object_0, 3);
		}

		internal void method_36()
		{
			award_DATA_0.m_bAwardSkill = smethod_7(mainEditor_0, award_DATA_0.m_bAwardSkill, object_0);
		}

		internal void method_37()
		{
			award_DATA_0.m_iAwardSkillID = smethod_13(mainEditor_0, award_DATA_0.m_iAwardSkillID, object_0, 0);
		}

		internal void method_38()
		{
			award_DATA_0.m_iAwardSkillLevel = smethod_14(mainEditor_0, award_DATA_0.m_iAwardSkillLevel, object_0);
		}

		internal void method_39()
		{
			award_DATA_0.m_iSoloTowerChallengeScore = smethod_13(mainEditor_0, award_DATA_0.m_iSoloTowerChallengeScore, object_0, 2);
		}

		internal void method_40()
		{
			award_DATA_0.m_iOpenSystem = smethod_15(mainEditor_0, award_DATA_0.m_iOpenSystem, object_0);
		}

		internal void method_41()
		{
			award_DATA_0.m_ulSpecifyContribTaskID = smethod_13(mainEditor_0, award_DATA_0.m_ulSpecifyContribTaskID, object_0, 0);
		}

		internal void method_42()
		{
			award_DATA_0.m_ulSpecifyContribSubTaskID = smethod_13(mainEditor_0, award_DATA_0.m_ulSpecifyContribSubTaskID, object_0, 0);
		}

		internal void method_43()
		{
			award_DATA_0.m_ulSpecifyContrib = smethod_13(mainEditor_0, award_DATA_0.m_ulSpecifyContrib, object_0, 2);
		}

		internal void method_44()
		{
			award_DATA_0.m_ulContrib = smethod_13(mainEditor_0, award_DATA_0.m_ulContrib, object_0, 2);
		}

		internal void method_45()
		{
			award_DATA_0.m_ulRandContrib = smethod_13(mainEditor_0, award_DATA_0.m_ulRandContrib, object_0, 2);
		}

		internal void method_46()
		{
			award_DATA_0.m_ulLowestcontrib = smethod_13(mainEditor_0, award_DATA_0.m_ulLowestcontrib, object_0, 2);
		}

		internal void method_47()
		{
			award_DATA_0.m_iFactionContrib = smethod_13(mainEditor_0, award_DATA_0.m_iFactionContrib, object_0, 2);
		}

		internal void method_48()
		{
			award_DATA_0.m_iFactionExpContrib = smethod_13(mainEditor_0, award_DATA_0.m_iFactionExpContrib, object_0, 2);
		}

		internal void method_49()
		{
			award_DATA_0.m_PQRankingAward.m_bAwardByProf = smethod_7(mainEditor_0, award_DATA_0.m_PQRankingAward.m_bAwardByProf, object_0);
		}

		internal void method_50()
		{
			award_DATA_0.m_bMulti = smethod_7(mainEditor_0, award_DATA_0.m_bMulti, object_0);
		}

		internal void method_51()
		{
			award_DATA_0.m_nNumType = smethod_15(mainEditor_0, award_DATA_0.m_nNumType, object_0);
		}

		internal void method_52()
		{
			award_DATA_0.m_lNum = smethod_13(mainEditor_0, award_DATA_0.m_lNum, object_0, 2);
		}

		internal void method_53()
		{
			award_DATA_0.m_iForceContribution = smethod_13(mainEditor_0, award_DATA_0.m_iForceContribution, object_0, 2);
		}

		internal void method_54()
		{
			award_DATA_0.m_iForceReputation = smethod_13(mainEditor_0, award_DATA_0.m_iForceReputation, object_0, 2);
		}

		internal void method_55()
		{
			award_DATA_0.m_iForceActivity = smethod_13(mainEditor_0, award_DATA_0.m_iForceActivity, object_0, 2);
		}

		internal void method_56()
		{
			award_DATA_0.m_iForceSetRepu = smethod_13(mainEditor_0, award_DATA_0.m_iForceSetRepu, object_0, 2);
		}

		internal void method_57()
		{
			award_DATA_0.m_iTaskLimit = smethod_13(mainEditor_0, award_DATA_0.m_iTaskLimit, object_0, 2);
		}

		internal void method_58()
		{
			award_DATA_0.m_iLeaderShip = smethod_13(mainEditor_0, award_DATA_0.m_iLeaderShip, object_0, 2);
		}

		internal void method_59()
		{
			award_DATA_0.m_iWorldContribution = smethod_13(mainEditor_0, award_DATA_0.m_iWorldContribution, object_0, 2);
		}

		internal void method_60()
		{
			award_DATA_0.m_iHomeResource[0] = smethod_13(mainEditor_0, award_DATA_0.m_iHomeResource[0], object_0, 2);
		}

		internal void method_61()
		{
			award_DATA_0.m_iHomeResource[1] = smethod_13(mainEditor_0, award_DATA_0.m_iHomeResource[1], object_0, 2);
		}

		internal void method_62()
		{
			award_DATA_0.m_iHomeResource[2] = smethod_13(mainEditor_0, award_DATA_0.m_iHomeResource[2], object_0, 2);
		}

		internal void method_63()
		{
			award_DATA_0.m_iHomeResource[3] = smethod_13(mainEditor_0, award_DATA_0.m_iHomeResource[3], object_0, 2);
		}

		internal void method_64()
		{
			award_DATA_0.m_iHomeResource[4] = smethod_13(mainEditor_0, award_DATA_0.m_iHomeResource[4], object_0, 2);
		}

		internal void method_65()
		{
			award_DATA_0.m_bCreateHome = smethod_7(mainEditor_0, award_DATA_0.m_bCreateHome, object_0);
		}

		internal void method_66()
		{
			award_DATA_0.m_bLeaveCarrier = smethod_7(mainEditor_0, award_DATA_0.m_bLeaveCarrier, object_0);
		}

		internal void method_67()
		{
			award_DATA_0.m_faction_money = smethod_13(mainEditor_0, award_DATA_0.m_faction_money, object_0, 2);
		}

		internal void method_68()
		{
			award_DATA_0.m_faction_person_score = smethod_13(mainEditor_0, award_DATA_0.m_faction_person_score, object_0, 2);
		}

		internal void method_69()
		{
			award_DATA_0.m_bSubmitRankScore = smethod_7(mainEditor_0, award_DATA_0.m_bSubmitRankScore, object_0);
		}

		internal void method_70()
		{
			award_DATA_0.submit_rank.m_iSubmitType = smethod_15(mainEditor_0, award_DATA_0.submit_rank.m_iSubmitType, object_0);
		}

		internal void method_71()
		{
			award_DATA_0.submit_rank.m_iRankID = smethod_15(mainEditor_0, award_DATA_0.submit_rank.m_iRankID + 1, object_0) - 1;
		}

		internal void method_72()
		{
			award_DATA_0.submit_rank.m_iTempRankID = smethod_13(mainEditor_0, award_DATA_0.submit_rank.m_iTempRankID, object_0, 2);
		}

		internal void method_73()
		{
			award_DATA_0.m_iMentorStudentValue = smethod_13(mainEditor_0, award_DATA_0.m_iMentorStudentValue, object_0, 2);
		}

		internal void method_74()
		{
			award_DATA_0.m_iCoupleIntimacy = smethod_13(mainEditor_0, award_DATA_0.m_iCoupleIntimacy, object_0, 2);
		}

		internal void method_75()
		{
			award_DATA_0.m_ulRedBookExp = smethod_13(mainEditor_0, award_DATA_0.m_ulRedBookExp, object_0, 2);
		}

		internal void method_76()
		{
			award_DATA_0.m_iCampScore = smethod_13(mainEditor_0, award_DATA_0.m_iCampScore, object_0, 2);
		}

		internal void method_77()
		{
			award_DATA_0.m_iCrossServerMoney = smethod_13(mainEditor_0, award_DATA_0.m_iCrossServerMoney, object_0, 2);
		}

		internal void method_78()
		{
			award_DATA_0.m_iAwardRedBookKey = smethod_7(mainEditor_0, award_DATA_0.m_iAwardRedBookKey, object_0);
		}

		internal void method_79()
		{
			award_DATA_0.m_iAwardRedBookKeyCount = smethod_13(mainEditor_0, award_DATA_0.m_iAwardRedBookKeyCount, object_0, 2);
		}

		internal void method_80()
		{
			award_DATA_0.m_iAwardRedBookKeyType = smethod_13(mainEditor_0, award_DATA_0.m_iAwardRedBookKeyType, object_0, 0);
		}

		internal void method_81()
		{
			award_DATA_0.m_ulPanguExpYear = (uint)smethod_13(mainEditor_0, (int)award_DATA_0.m_ulPanguExpYear, object_0, 2);
		}

		internal void method_82()
		{
			award_DATA_0.m_ulPanguExp = (uint)smethod_13(mainEditor_0, (int)award_DATA_0.m_ulPanguExp, object_0, 2);
		}

		internal void method_83()
		{
			award_DATA_0.m_iFactionAwardConfig = smethod_13(mainEditor_0, award_DATA_0.m_iFactionAwardConfig, object_0, 2);
		}

		internal void method_84()
		{
			award_DATA_0.m_iNewPlayerEvent = smethod_13(mainEditor_0, award_DATA_0.m_iNewPlayerEvent, object_0, 2);
		}

		internal void method_85()
		{
			award_DATA_0.m_bRepairShentongSearchBug = smethod_8(mainEditor_0, award_DATA_0.m_bRepairShentongSearchBug, object_0);
		}

		internal void method_86()
		{
			award_DATA_0.m_iInviterAwardItem = smethod_13(mainEditor_0, award_DATA_0.m_iInviterAwardItem, object_0, 0);
		}

		internal void method_87()
		{
			award_DATA_0.m_iRewardFriendPoint = smethod_13(mainEditor_0, award_DATA_0.m_iRewardFriendPoint, object_0, 2);
		}

		internal void method_88()
		{
			award_DATA_0.m_iInviterAwardNum = smethod_13(mainEditor_0, award_DATA_0.m_iInviterAwardNum, object_0, 2);
		}

		internal void method_89()
		{
			award_DATA_0.m_iPerceptionVal = smethod_13(mainEditor_0, award_DATA_0.m_iPerceptionVal, object_0, 2);
		}

		internal void method_90()
		{
			award_DATA_0.m_iAwardCameraMovementID = smethod_13(mainEditor_0, award_DATA_0.m_iAwardCameraMovementID, object_0, 2);
		}
	}

	private sealed class Class390
	{
		public ATaskTempl ataskTempl_0;

		public ACE.sTASKedit.MainEditor.MainEditor mainEditor_0;

		public object object_0;

		public Control control_0;

		internal void method_0()
		{
			ataskTempl_0.m_usIDSpace = smethod_12(mainEditor_0, ataskTempl_0.m_usIDSpace, object_0);
		}

		internal void method_1()
		{
			if (ataskTempl_0.m_ID == Convert.ToInt32(mainEditor_0.textBox_m_ID.Text))
			{
				return;
			}
			mainEditor_0.treeView_tasks.BeginBulkUpdate();
			int iD = ataskTempl_0.m_ID;
			int selectedIndex = mainEditor_0.listBox_Talks.SelectedIndex;
			int selectedIndex2 = mainEditor_0.listBox_Talk_windows.SelectedIndex;
			int selectedIndex3 = mainEditor_0.listBox_Talk_windows_options.SelectedIndex;
			ataskTempl_0.ID = Convert.ToInt32(mainEditor_0.textBox_m_ID.Text);
			mainEditor_0.treeView_tasks.SelectedNode.Text = ataskTempl_0.m_ID + Class16.smethod_0(1648942627) + GlobalFunctions.ColorClean(ataskTempl_0.Name);
			if (ataskTempl_0.m_nSubCount != 0)
			{
				for (int i = 0; i < ataskTempl_0.m_nSubCount; i++)
				{
					ataskTempl_0.pSub[i].m_ulParent = ataskTempl_0.m_ID;
				}
			}
			ArrayList arrayList = new ArrayList();
			TreeNode treeNode = mainEditor_0.treeView_tasks.SelectedNode;
			if (treeNode.Parent != null)
			{
				while (treeNode.Parent != null)
				{
					arrayList.Add(treeNode.Index);
					treeNode = treeNode.Parent;
				}
				ATaskTempl aTaskTempl = GProD.Tasks[treeNode.Index];
				for (int num = arrayList.Count - 1; num > 0; num--)
				{
					aTaskTempl = aTaskTempl.pSub[(int)arrayList[num]];
				}
				if ((int)arrayList[0] < aTaskTempl.m_nSubCount - 1)
				{
					aTaskTempl.pSub[(int)arrayList[0] + 1].m_ulPrevSibling = ataskTempl_0.m_ID;
				}
				if ((int)arrayList[0] != 0)
				{
					aTaskTempl.pSub[(int)arrayList[0] - 1].m_ulNextSibling = ataskTempl_0.m_ID;
				}
				if ((int)arrayList[0] == 0)
				{
					aTaskTempl.m_ulFirstChild = ataskTempl_0.m_ID;
				}
			}
			mainEditor_0.SetNewIDIntalk_procs(ataskTempl_0, iD, ataskTempl_0.m_ID);
			GlobalFunctions.UpdateNode(mainEditor_0.treeView_tasks.SelectedNode, ataskTempl_0, 0, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
			mainEditor_0.listBox_Talks.SelectedIndex = -1;
			mainEditor_0.listBox_Talks.SelectedIndex = selectedIndex;
			mainEditor_0.listBox_Talk_windows.SelectedIndex = selectedIndex2;
			mainEditor_0.listBox_Talk_windows_options.SelectedIndex = selectedIndex3;
			mainEditor_0.treeView_tasks.EndBulkUpdate();
			mainEditor_0.TriggerDebug(control_0);
		}

		internal void method_2()
		{
			if (ataskTempl_0.Name != mainEditor_0.textBox_m_szName.Text)
			{
				mainEditor_0.treeView_tasks.BeginBulkUpdate();
				ataskTempl_0.Name = mainEditor_0.textBox_m_szName.Text;
				GlobalFunctions.UpdateNode(mainEditor_0.treeView_tasks.SelectedNode, ataskTempl_0, 0, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
				mainEditor_0.treeView_tasks.EndBulkUpdate();
				mainEditor_0.textBox_m_szName.ForeColor = mainEditor_0.treeView_tasks.SelectedNode.ForeColor;
				mainEditor_0.logic_select_task_02_01();
				mainEditor_0.TriggerDebug(control_0);
			}
		}

		internal void method_3()
		{
			if (ataskTempl_0.Signature != mainEditor_0.textBox_m_pszSignature.Text)
			{
				ataskTempl_0.Signature = mainEditor_0.textBox_m_pszSignature.Text;
				ataskTempl_0.m_bHasSign = !string.IsNullOrEmpty(mainEditor_0.textBox_m_pszSignature.Text);
				mainEditor_0.TriggerDebug(control_0);
			}
		}

		internal void method_4()
		{
			ataskTempl_0.m_ulType = ((mainEditor_0.comboBox_m_ulType.SelectedIndex < 13) ? mainEditor_0.comboBox_m_ulType.SelectedIndex : (mainEditor_0.comboBox_m_ulType.SelectedIndex + 87));
			GlobalFunctions.UpdateNode(mainEditor_0.treeView_tasks.SelectedNode, ataskTempl_0, 1, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
			mainEditor_0.textBox_m_szName.ForeColor = mainEditor_0.treeView_tasks.SelectedNode.ForeColor;
			mainEditor_0.TriggerDebug(control_0);
		}

		internal void method_5()
		{
			ataskTempl_0.m_ulDelvNPC = smethod_13(mainEditor_0, ataskTempl_0.m_ulDelvNPC, object_0, 0);
		}

		internal void method_6()
		{
			ataskTempl_0.m_ulAwardNPC = smethod_13(mainEditor_0, ataskTempl_0.m_ulAwardNPC, object_0, 0);
		}

		internal void method_7()
		{
			ataskTempl_0.m_ulParent = smethod_13(mainEditor_0, ataskTempl_0.m_ulParent, object_0, 0);
		}

		internal void method_8()
		{
			ataskTempl_0.m_ulPrevSibling = smethod_13(mainEditor_0, ataskTempl_0.m_ulPrevSibling, object_0, 0);
		}

		internal void method_9()
		{
			ataskTempl_0.m_ulNextSibling = smethod_13(mainEditor_0, ataskTempl_0.m_ulNextSibling, object_0, 0);
		}

		internal void method_10()
		{
			ataskTempl_0.m_ulFirstChild = smethod_13(mainEditor_0, ataskTempl_0.m_ulFirstChild, object_0, 0);
		}
	}

	private sealed class Class391
	{
		public ATaskTempl ataskTempl_0;

		public ACE.sTASKedit.MainEditor.MainEditor mainEditor_0;

		public object object_0;

		public Control control_0;

		internal void method_0()
		{
			ataskTempl_0.m_bShowByItems = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByItems, object_0);
		}

		internal void method_1()
		{
			ataskTempl_0.m_bPremItemsAnyOne = smethod_7(mainEditor_0, ataskTempl_0.m_bPremItemsAnyOne, object_0);
		}

		internal void method_2()
		{
			ataskTempl_0.m_bNotOpenWithItem = smethod_7(mainEditor_0, ataskTempl_0.m_bNotOpenWithItem, object_0);
		}

		internal void method_3()
		{
			ataskTempl_0.m_ulGivenCmnCount = smethod_13(mainEditor_0, ataskTempl_0.m_ulGivenCmnCount, object_0, 0);
		}

		internal void method_4()
		{
			ataskTempl_0.m_ulGivenTskCount = smethod_13(mainEditor_0, ataskTempl_0.m_ulGivenTskCount, object_0, 0);
		}

		internal void method_5()
		{
			ataskTempl_0.m_ulPremise_Deposit = smethod_13(mainEditor_0, ataskTempl_0.m_ulPremise_Deposit, object_0, 2);
		}

		internal void method_6()
		{
			ataskTempl_0.m_bShowByDeposit = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByDeposit, object_0);
		}

		internal void method_7()
		{
			ataskTempl_0.m_lPremise_Reputation = smethod_13(mainEditor_0, ataskTempl_0.m_lPremise_Reputation, object_0, 2);
		}

		internal void method_8()
		{
			ataskTempl_0.m_lPremise_RepuMax = smethod_13(mainEditor_0, ataskTempl_0.m_lPremise_RepuMax, object_0, 2);
		}

		internal void method_9()
		{
			ataskTempl_0.m_bShowByRepu = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByRepu, object_0);
		}

		internal void method_10()
		{
			ataskTempl_0.m_bShowByPreTask = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByPreTask, object_0);
		}

		internal void method_11()
		{
			ataskTempl_0.m_ulPremise_Task_Least_Num = smethod_14(mainEditor_0, ataskTempl_0.m_ulPremise_Task_Least_Num, object_0);
		}

		internal void method_12()
		{
			if (mainEditor_0.comboBox_m_ulPremise_Period.SelectedIndex < 9)
			{
				ataskTempl_0.m_ulPremise_Period = mainEditor_0.comboBox_m_ulPremise_Period.SelectedIndex;
			}
			else
			{
				switch (mainEditor_0.comboBox_m_ulPremise_Period.SelectedIndex)
				{
				case 9:
					ataskTempl_0.m_ulPremise_Period = 20;
					break;
				case 10:
					ataskTempl_0.m_ulPremise_Period = 30;
					break;
				case 11:
					ataskTempl_0.m_ulPremise_Period = 21;
					break;
				case 12:
					ataskTempl_0.m_ulPremise_Period = 31;
					break;
				case 13:
					ataskTempl_0.m_ulPremise_Period = 22;
					break;
				case 14:
					ataskTempl_0.m_ulPremise_Period = 32;
					break;
				case 15:
					ataskTempl_0.m_ulPremise_Period = 40;
					break;
				case 16:
					ataskTempl_0.m_ulPremise_Period = 41;
					break;
				}
			}
			mainEditor_0.TriggerDebug(control_0);
		}

		internal void method_13()
		{
			ataskTempl_0.m_bShowByPeriod = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByPeriod, object_0);
		}

		internal void method_14()
		{
			ataskTempl_0.m_ulPremise_Faction = Convert.ToInt32(smethod_7(mainEditor_0, Convert.ToBoolean(ataskTempl_0.m_ulPremise_Faction), object_0));
		}

		internal void method_15()
		{
			ataskTempl_0.m_iPremise_FactionRole = 6 - smethod_15(mainEditor_0, 6 - ataskTempl_0.m_iPremise_FactionRole, object_0);
		}

		internal void method_16()
		{
			ataskTempl_0.m_bShowByFaction = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByFaction, object_0);
		}

		internal void method_17()
		{
			ataskTempl_0.m_ulGender = smethod_15(mainEditor_0, ataskTempl_0.m_ulGender, object_0);
		}

		internal void method_18()
		{
			ataskTempl_0.m_bShowByGender = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByGender, object_0);
		}

		internal void method_19()
		{
			ataskTempl_0.m_bShowByOccup = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByOccup, object_0);
		}

		internal void method_20()
		{
			ataskTempl_0.m_bPremise_Spouse = smethod_7(mainEditor_0, ataskTempl_0.m_bPremise_Spouse, object_0);
		}

		internal void method_21()
		{
			ataskTempl_0.m_bShowBySpouse = smethod_7(mainEditor_0, ataskTempl_0.m_bShowBySpouse, object_0);
		}

		internal void method_22()
		{
			ataskTempl_0.m_bPremiseWeddingOwner = smethod_7(mainEditor_0, ataskTempl_0.m_bPremiseWeddingOwner, object_0);
		}

		internal void method_23()
		{
			ataskTempl_0.m_bShowByWeddingOwner = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByWeddingOwner, object_0);
		}

		internal void method_24()
		{
			ataskTempl_0.m_bShowByRMB = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByRMB, object_0);
		}

		internal void method_25()
		{
			ataskTempl_0.m_ulPremRMBMin = smethod_13(mainEditor_0, ataskTempl_0.m_ulPremRMBMin, object_0, 3);
		}

		internal void method_26()
		{
			ataskTempl_0.m_ulPremRMBMax = smethod_13(mainEditor_0, ataskTempl_0.m_ulPremRMBMax, object_0, 3);
		}

		internal void method_27()
		{
			ataskTempl_0.m_bCharTime = smethod_7(mainEditor_0, ataskTempl_0.m_bCharTime, object_0);
		}

		internal void method_28()
		{
			ataskTempl_0.m_bShowByCharTime = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByCharTime, object_0);
		}

		internal void method_29()
		{
			ataskTempl_0.m_iCharStartTime = smethod_15(mainEditor_0, ataskTempl_0.m_iCharStartTime, object_0);
		}

		internal void method_30()
		{
			ataskTempl_0.m_iCharEndTime = smethod_15(mainEditor_0, ataskTempl_0.m_iCharEndTime, object_0);
		}

		internal void method_31()
		{
			ataskTempl_0.m_tmCharEndTime = smethod_18(mainEditor_0, ataskTempl_0.m_tmCharEndTime, object_0);
		}

		internal void method_32()
		{
			ataskTempl_0.m_ulCharTimeGreaterThan = smethod_14(mainEditor_0, ataskTempl_0.m_ulCharTimeGreaterThan, object_0);
		}

		internal void method_33()
		{
			ataskTempl_0.m_usPremise_Cotask_Space = smethod_12(mainEditor_0, ataskTempl_0.m_usPremise_Cotask_Space, object_0);
		}

		internal void method_34()
		{
			ataskTempl_0.m_ulPremise_Cotask = smethod_13(mainEditor_0, ataskTempl_0.m_ulPremise_Cotask, object_0, 0);
		}

		internal void method_35()
		{
			ataskTempl_0.m_ulCoTaskCond = smethod_15(mainEditor_0, ataskTempl_0.m_ulCoTaskCond, object_0);
		}

		internal void method_36()
		{
			ataskTempl_0.m_bShowByTeam = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByTeam, object_0);
		}

		internal void method_37()
		{
			ataskTempl_0.m_bPremNeedComp = smethod_7(mainEditor_0, ataskTempl_0.m_bPremNeedComp, object_0);
		}

		internal void method_38()
		{
			ataskTempl_0.m_nPremExp1AndOrExp2 = smethod_15(mainEditor_0, ataskTempl_0.m_nPremExp1AndOrExp2, object_0);
		}

		internal void method_39()
		{
			ataskTempl_0.m_bPremPersonNeedComp = smethod_7(mainEditor_0, ataskTempl_0.m_bPremPersonNeedComp, object_0);
		}

		internal void method_40()
		{
			ataskTempl_0.m_nPremPersonExp1AndOrExp2 = smethod_15(mainEditor_0, ataskTempl_0.m_nPremPersonExp1AndOrExp2, object_0);
		}

		internal void method_41()
		{
			ataskTempl_0.m_bPremHistoryNeedComp = smethod_7(mainEditor_0, ataskTempl_0.m_bPremHistoryNeedComp, object_0);
		}

		internal void method_42()
		{
			ataskTempl_0.m_nPremHistoryExp1AndOrExp2 = smethod_15(mainEditor_0, ataskTempl_0.m_nPremHistoryExp1AndOrExp2, object_0);
		}

		internal void method_43()
		{
			ataskTempl_0.m_bIsLibraryTask = smethod_7(mainEditor_0, ataskTempl_0.m_bIsLibraryTask, object_0);
		}

		internal void method_44()
		{
			ataskTempl_0.m_fLibraryTasksProbability = smethod_17(mainEditor_0, ataskTempl_0.m_fLibraryTasksProbability, object_0, 1);
		}

		internal void method_45()
		{
			ataskTempl_0.m_bIsUniqueStorageTask = smethod_7(mainEditor_0, ataskTempl_0.m_bIsUniqueStorageTask, object_0);
		}

		internal void method_46()
		{
			ataskTempl_0.m_iWorldContribution = smethod_13(mainEditor_0, ataskTempl_0.m_iWorldContribution, object_0, 2);
		}

		internal void method_47()
		{
			ataskTempl_0.m_bWriteSpecialLog = smethod_7(mainEditor_0, ataskTempl_0.m_bWriteSpecialLog, object_0);
		}

		internal void method_48()
		{
			ataskTempl_0.m_bPremCheckForce = smethod_7(mainEditor_0, ataskTempl_0.m_bPremCheckForce, object_0);
		}

		internal void method_49()
		{
			ataskTempl_0.m_iPremForce = smethod_13(mainEditor_0, ataskTempl_0.m_iPremForce, object_0, 0);
		}

		internal void method_50()
		{
			ataskTempl_0.m_bShowByForce = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByForce, object_0);
		}

		internal void method_51()
		{
			ataskTempl_0.m_iPremForceReputation = smethod_13(mainEditor_0, ataskTempl_0.m_iPremForceReputation, object_0, 2);
		}

		internal void method_52()
		{
			ataskTempl_0.m_bShowByForceReputation = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByForceReputation, object_0);
		}

		internal void method_53()
		{
			ataskTempl_0.m_iPremForceContribution = smethod_13(mainEditor_0, ataskTempl_0.m_iPremForceContribution, object_0, 2);
		}

		internal void method_54()
		{
			ataskTempl_0.m_bShowByForceContribution = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByForceContribution, object_0);
		}

		internal void method_55()
		{
			ataskTempl_0.m_iPremForceExp = smethod_13(mainEditor_0, ataskTempl_0.m_iPremForceExp, object_0, 2);
		}

		internal void method_56()
		{
			ataskTempl_0.m_bShowByForceExp = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByForceExp, object_0);
		}

		internal void method_57()
		{
			ataskTempl_0.m_iPremForceSP = smethod_13(mainEditor_0, ataskTempl_0.m_iPremForceSP, object_0, 2);
		}

		internal void method_58()
		{
			ataskTempl_0.m_bShowByForceSP = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByForceSP, object_0);
		}

		internal void method_59()
		{
			ataskTempl_0.m_iPremForceActivityLevel = smethod_13(mainEditor_0, ataskTempl_0.m_iPremForceActivityLevel, object_0, 0);
		}

		internal void method_60()
		{
			ataskTempl_0.m_bShowByForceActivityLevel = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByForceActivityLevel, object_0);
		}

		internal void method_61()
		{
			ataskTempl_0.m_bPremIsKing = smethod_7(mainEditor_0, ataskTempl_0.m_bPremIsKing, object_0);
		}

		internal void method_62()
		{
			ataskTempl_0.m_bShowByKing = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByKing, object_0);
		}

		internal void method_63()
		{
			ataskTempl_0.m_bPremNotInTeam = smethod_7(mainEditor_0, ataskTempl_0.m_bPremNotInTeam, object_0);
		}

		internal void method_64()
		{
			ataskTempl_0.m_bShowByNotInTeam = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByNotInTeam, object_0);
		}

		internal void method_65()
		{
			ataskTempl_0.m_iPremTitleNumRequired = smethod_13(mainEditor_0, ataskTempl_0.m_iPremTitleNumRequired, object_0, 2);
		}

		internal void method_66()
		{
			ataskTempl_0.m_bShowByTitle = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByTitle, object_0);
		}

		internal void method_67()
		{
			ataskTempl_0.m_iPremHistoryStageIndex[0] = smethod_13(mainEditor_0, ataskTempl_0.m_iPremHistoryStageIndex[0], object_0, 0);
		}

		internal void method_68()
		{
			ataskTempl_0.m_iPremHistoryStageIndex[1] = smethod_13(mainEditor_0, ataskTempl_0.m_iPremHistoryStageIndex[1], object_0, 0);
		}

		internal void method_69()
		{
			ataskTempl_0.m_bShowByHistoryStage = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByHistoryStage, object_0);
		}

		internal void method_70()
		{
			ataskTempl_0.m_ulPremGeneralCardCount = smethod_13(mainEditor_0, ataskTempl_0.m_ulPremGeneralCardCount, object_0, 2);
		}

		internal void method_71()
		{
			ataskTempl_0.m_bShowByGeneralCard = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByGeneralCard, object_0);
		}

		internal void method_72()
		{
			ataskTempl_0.m_iPremGeneralCardRank = smethod_15(mainEditor_0, ataskTempl_0.m_iPremGeneralCardRank + 1, object_0) - 1;
		}

		internal void method_73()
		{
			ataskTempl_0.m_ulPremGeneralCardRankCount = smethod_13(mainEditor_0, ataskTempl_0.m_ulPremGeneralCardRankCount, object_0, 2);
		}

		internal void method_74()
		{
			ataskTempl_0.m_bShowByGeneralCardRank = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByGeneralCardRank, object_0);
		}

		internal void method_75()
		{
			ataskTempl_0.m_ulPremIconStateID = smethod_13(mainEditor_0, ataskTempl_0.m_ulPremIconStateID, object_0, 0);
		}

		internal void method_76()
		{
			ataskTempl_0.m_bShowByIconStateID = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByIconStateID, object_0);
		}

		internal void method_77()
		{
			ataskTempl_0.m_iVIPLevelMin = smethod_13(mainEditor_0, ataskTempl_0.m_iVIPLevelMin, object_0, 0);
		}

		internal void method_78()
		{
			ataskTempl_0.m_iVIPLevelMax = smethod_13(mainEditor_0, ataskTempl_0.m_iVIPLevelMax, object_0, 0);
		}

		internal void method_79()
		{
			ataskTempl_0.m_ulFailIconStateID = smethod_13(mainEditor_0, ataskTempl_0.m_ulFailIconStateID, object_0, 0);
		}

		internal void method_80()
		{
			ataskTempl_0.m_bShowByVIPLevel = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByVIPLevel, object_0);
		}

		internal void method_81()
		{
			ataskTempl_0.m_bPremNoHome = smethod_7(mainEditor_0, ataskTempl_0.m_bPremNoHome, object_0);
		}

		internal void method_82()
		{
			ataskTempl_0.m_iPremHomeLevelMin = smethod_14(mainEditor_0, ataskTempl_0.m_iPremHomeLevelMin, object_0);
		}

		internal void method_83()
		{
			ataskTempl_0.m_iPremHomeLevelMax = smethod_14(mainEditor_0, ataskTempl_0.m_iPremHomeLevelMax, object_0);
		}

		internal void method_84()
		{
			ataskTempl_0.m_bShowByHomeLevel = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByHomeLevel, object_0);
		}

		internal void method_85()
		{
			ataskTempl_0.m_iPremHomeResourceLevelMin = smethod_14(mainEditor_0, ataskTempl_0.m_iPremHomeResourceLevelMin, object_0);
		}

		internal void method_86()
		{
			ataskTempl_0.m_iPremHomeResourceLevelMax = smethod_14(mainEditor_0, ataskTempl_0.m_iPremHomeResourceLevelMax, object_0);
		}

		internal void method_87()
		{
			ataskTempl_0.m_bShowByHomeResourceLevel = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByHomeResourceLevel, object_0);
		}

		internal void method_88()
		{
			ataskTempl_0.m_iPremHomeFactoryLevelType = smethod_15(mainEditor_0, ataskTempl_0.m_iPremHomeFactoryLevelType, object_0);
		}

		internal void method_89()
		{
			ataskTempl_0.m_iPremHomeFactoryLevelMin = smethod_14(mainEditor_0, ataskTempl_0.m_iPremHomeFactoryLevelMin, object_0);
		}

		internal void method_90()
		{
			ataskTempl_0.m_iPremHomeFactoryLevelMax = smethod_14(mainEditor_0, ataskTempl_0.m_iPremHomeFactoryLevelMax, object_0);
		}

		internal void method_91()
		{
			ataskTempl_0.m_bShowByHomeFactoryLevel = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByHomeFactoryLevel, object_0);
		}

		internal void method_92()
		{
			ataskTempl_0.m_iPremHomeFlourishMin = smethod_13(mainEditor_0, ataskTempl_0.m_iPremHomeFlourishMin, object_0, 2);
		}

		internal void method_93()
		{
			ataskTempl_0.m_iPremHomeFlourishMax = smethod_13(mainEditor_0, ataskTempl_0.m_iPremHomeFlourishMax, object_0, 2);
		}

		internal void method_94()
		{
			ataskTempl_0.m_bShowByHomeFlourish = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByHomeFlourish, object_0);
		}

		internal void method_95()
		{
			ataskTempl_0.m_bPremHomeStorageTask = smethod_7(mainEditor_0, ataskTempl_0.m_bPremHomeStorageTask, object_0);
		}

		internal void method_96()
		{
			ataskTempl_0.m_bShowByHomeStorageTask = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByHomeStorageTask, object_0);
		}

		internal void method_97()
		{
			ataskTempl_0.m_iPremArenaWinCount = smethod_13(mainEditor_0, ataskTempl_0.m_iPremArenaWinCount, object_0, 2);
		}

		internal void method_98()
		{
			ataskTempl_0.m_bPremReachArenaWinCount = smethod_7(mainEditor_0, ataskTempl_0.m_bPremReachArenaWinCount, object_0);
		}

		internal void method_99()
		{
			ataskTempl_0.m_bShowByReachArenaWinCount = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByReachArenaWinCount, object_0);
		}

		internal void method_100()
		{
			ataskTempl_0.m_bPremFaction = smethod_7(mainEditor_0, ataskTempl_0.m_bPremFaction, object_0);
		}

		internal void method_101()
		{
			ataskTempl_0.m_iPremFactionScore = smethod_13(mainEditor_0, ataskTempl_0.m_iPremFactionScore, object_0, 2);
		}

		internal void method_102()
		{
			ataskTempl_0.m_bShowByFactionScore = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByFactionScore, object_0);
		}

		internal void method_103()
		{
			ataskTempl_0.m_iPremFactionMoney = smethod_13(mainEditor_0, ataskTempl_0.m_iPremFactionMoney, object_0, 2);
		}

		internal void method_104()
		{
			ataskTempl_0.m_bShowByFactionMoney = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByFactionMoney, object_0);
		}

		internal void method_105()
		{
			ataskTempl_0.m_iPremFactionPersonScore = smethod_13(mainEditor_0, ataskTempl_0.m_iPremFactionPersonScore, object_0, 2);
		}

		internal void method_106()
		{
			ataskTempl_0.m_bShowByFactionPersonScore = smethod_7(mainEditor_0, ataskTempl_0.m_bShowByFactionPersonScore, object_0);
		}

		internal void method_107()
		{
			ataskTempl_0.m_bBecomeMentor = smethod_7(mainEditor_0, ataskTempl_0.m_bBecomeMentor, object_0);
		}

		internal void method_108()
		{
			ataskTempl_0.m_iPremMentorMorality = smethod_13(mainEditor_0, ataskTempl_0.m_iPremMentorMorality, object_0, 2);
		}

		internal void method_109()
		{
			ataskTempl_0.m_bShowMentorMorality = smethod_7(mainEditor_0, ataskTempl_0.m_bShowMentorMorality, object_0);
		}

		internal void method_110()
		{
			ataskTempl_0.m_iPremMentorStudentValue = smethod_13(mainEditor_0, ataskTempl_0.m_iPremMentorStudentValue, object_0, 2);
		}

		internal void method_111()
		{
			ataskTempl_0.m_bShowMentorStudentValue = smethod_7(mainEditor_0, ataskTempl_0.m_bShowMentorStudentValue, object_0);
		}

		internal void method_112()
		{
			ataskTempl_0.m_iPremCoupleIntimacy = smethod_13(mainEditor_0, ataskTempl_0.m_iPremCoupleIntimacy, object_0, 2);
		}

		internal void method_113()
		{
			ataskTempl_0.m_bShowCoupleIntimacy = smethod_7(mainEditor_0, ataskTempl_0.m_bShowCoupleIntimacy, object_0);
		}

		internal void method_114()
		{
			ataskTempl_0.m_ulPremDeposit2 = smethod_13(mainEditor_0, ataskTempl_0.m_ulPremDeposit2, object_0, 2);
		}

		internal void method_115()
		{
			ataskTempl_0.m_bShowDeposit2 = smethod_7(mainEditor_0, ataskTempl_0.m_bShowDeposit2, object_0);
		}

		internal void method_116()
		{
			ataskTempl_0.m_iNeededTasksLeastNum = smethod_9(mainEditor_0, ataskTempl_0.m_iNeededTasksLeastNum, object_0);
		}

		internal void method_117()
		{
			ataskTempl_0.m_bShowCamp = smethod_7(mainEditor_0, ataskTempl_0.m_bShowCamp, object_0);
		}

		internal void method_118()
		{
			ataskTempl_0.m_iCampPower = smethod_13(mainEditor_0, ataskTempl_0.m_iCampPower, object_0, 2);
		}

		internal void method_119()
		{
			ataskTempl_0.m_iCamp = smethod_15(mainEditor_0, ataskTempl_0.m_iCamp, object_0);
		}

		internal void method_120()
		{
			ataskTempl_0.m_bShowCampPower = smethod_7(mainEditor_0, ataskTempl_0.m_bShowCampPower, object_0);
		}

		internal void method_121()
		{
			ataskTempl_0.m_bReturnCampPower = smethod_7(mainEditor_0, ataskTempl_0.m_bReturnCampPower, object_0);
		}

		internal void method_122()
		{
			ataskTempl_0.m_iNeedFriendPoint = smethod_13(mainEditor_0, ataskTempl_0.m_iNeedFriendPoint, object_0, 2);
		}

		internal void method_123()
		{
			ataskTempl_0.m_bShowNeedFriendPoint = smethod_7(mainEditor_0, ataskTempl_0.m_bShowNeedFriendPoint, object_0);
		}

		internal void method_124()
		{
			ataskTempl_0.m_bRankPre = smethod_7(mainEditor_0, ataskTempl_0.m_bRankPre, object_0);
		}

		internal void method_125()
		{
			ataskTempl_0.m_iRankType = smethod_15(mainEditor_0, ataskTempl_0.m_iRankType, object_0);
		}

		internal void method_126()
		{
			ataskTempl_0.m_iRankGradeMin = smethod_13(mainEditor_0, ataskTempl_0.m_iRankGradeMin, object_0, 0);
		}

		internal void method_127()
		{
			ataskTempl_0.m_iRankGradeMax = smethod_13(mainEditor_0, ataskTempl_0.m_iRankGradeMax, object_0, 0);
		}
	}

	private sealed class Class392
	{
		public ATaskTempl ataskTempl_0;

		public ACE.sTASKedit.MainEditor.MainEditor mainEditor_0;

		public object object_0;

		public Control control_0;

		internal void method_0()
		{
			ataskTempl_0.camera_rotate_axis = smethod_13(mainEditor_0, ataskTempl_0.camera_rotate_axis, object_0, 0);
		}

		internal void method_1()
		{
			ataskTempl_0.camera_rotate_angle = smethod_17(mainEditor_0, ataskTempl_0.camera_rotate_angle, object_0, 0);
		}

		internal void method_2()
		{
			ataskTempl_0.camera_take_seconds = smethod_17(mainEditor_0, ataskTempl_0.camera_take_seconds, object_0, 0);
		}

		internal void method_3()
		{
			ataskTempl_0.camera_pos_x = smethod_17(mainEditor_0, ataskTempl_0.camera_pos_x, object_0, 0);
		}

		internal void method_4()
		{
			ataskTempl_0.camera_pos_y = smethod_17(mainEditor_0, ataskTempl_0.camera_pos_y, object_0, 0);
		}

		internal void method_5()
		{
			ataskTempl_0.camera_pos_z = smethod_17(mainEditor_0, ataskTempl_0.camera_pos_z, object_0, 0);
		}

		internal void method_6()
		{
			ataskTempl_0.camera_quat_x = smethod_17(mainEditor_0, ataskTempl_0.camera_quat_x, object_0, 0);
		}

		internal void method_7()
		{
			ataskTempl_0.camera_quat_y = smethod_17(mainEditor_0, ataskTempl_0.camera_quat_y, object_0, 0);
		}

		internal void method_8()
		{
			ataskTempl_0.camera_quat_z = smethod_17(mainEditor_0, ataskTempl_0.camera_quat_z, object_0, 0);
		}

		internal void method_9()
		{
			ataskTempl_0.camera_quat_a = smethod_17(mainEditor_0, ataskTempl_0.camera_quat_a, object_0, 0);
		}

		internal void method_10()
		{
			ataskTempl_0.camera_target_pos_x = smethod_17(mainEditor_0, ataskTempl_0.camera_target_pos_x, object_0, 0);
		}

		internal void method_11()
		{
			ataskTempl_0.camera_target_pos_y = smethod_17(mainEditor_0, ataskTempl_0.camera_target_pos_y, object_0, 0);
		}

		internal void method_12()
		{
			ataskTempl_0.camera_target_pos_z = smethod_17(mainEditor_0, ataskTempl_0.camera_target_pos_z, object_0, 0);
		}

		internal void method_13()
		{
			ataskTempl_0.camera_target_quat_x = smethod_17(mainEditor_0, ataskTempl_0.camera_target_quat_x, object_0, 0);
		}

		internal void method_14()
		{
			ataskTempl_0.camera_target_quat_y = smethod_17(mainEditor_0, ataskTempl_0.camera_target_quat_y, object_0, 0);
		}

		internal void method_15()
		{
			ataskTempl_0.camera_target_quat_z = smethod_17(mainEditor_0, ataskTempl_0.camera_target_quat_z, object_0, 0);
		}

		internal void method_16()
		{
			ataskTempl_0.camera_target_quat_a = smethod_17(mainEditor_0, ataskTempl_0.camera_target_quat_a, object_0, 0);
		}

		internal void method_17()
		{
			ataskTempl_0.m_bPropNeedComp = smethod_7(mainEditor_0, ataskTempl_0.m_bPropNeedComp, object_0);
		}

		internal void method_18()
		{
			ataskTempl_0.m_nPropExp1AndOrExp2 = smethod_15(mainEditor_0, ataskTempl_0.m_nPropExp1AndOrExp2, object_0);
		}

		internal void method_19()
		{
			ataskTempl_0.m_bPropNeedComp_personal = smethod_7(mainEditor_0, ataskTempl_0.m_bPropNeedComp_personal, object_0);
		}

		internal void method_20()
		{
			ataskTempl_0.m_nPropExp1AndOrExp2_personal = smethod_15(mainEditor_0, ataskTempl_0.m_nPropExp1AndOrExp2_personal, object_0);
		}

		internal void method_21()
		{
			ataskTempl_0.m_bFinNeedComp = smethod_7(mainEditor_0, ataskTempl_0.m_bFinNeedComp, object_0);
		}

		internal void method_22()
		{
			ataskTempl_0.m_nFinExp1AndOrExp2 = smethod_15(mainEditor_0, ataskTempl_0.m_nFinExp1AndOrExp2, object_0);
		}

		internal void method_23()
		{
			ataskTempl_0.m_bFinPersonNeedComp = smethod_7(mainEditor_0, ataskTempl_0.m_bFinPersonNeedComp, object_0);
		}

		internal void method_24()
		{
			ataskTempl_0.m_nFinPersonExp1AndOrExp2 = smethod_15(mainEditor_0, ataskTempl_0.m_nFinPersonExp1AndOrExp2, object_0);
		}

		internal void method_25()
		{
			ataskTempl_0.m_bFinHistoryNeedComp = smethod_7(mainEditor_0, ataskTempl_0.m_bFinHistoryNeedComp, object_0);
		}

		internal void method_26()
		{
			ataskTempl_0.m_nFinHistoryExp1AndOrExp2 = smethod_15(mainEditor_0, ataskTempl_0.m_nFinHistoryExp1AndOrExp2, object_0);
		}

		internal void method_27()
		{
			ataskTempl_0.m_ucTransformedForm = smethod_8(mainEditor_0, ataskTempl_0.m_ucTransformedForm, object_0);
		}

		internal void method_28()
		{
			ataskTempl_0.TransformedDescID = smethod_13(mainEditor_0, ataskTempl_0.TransformedDescID, object_0, 0);
		}

		internal void method_29()
		{
			ataskTempl_0.m_HintConfigId = smethod_13(mainEditor_0, ataskTempl_0.m_HintConfigId, object_0, 0);
		}

		internal void method_30()
		{
			ataskTempl_0.m_iAchievementSeriesId = smethod_13(mainEditor_0, ataskTempl_0.m_iAchievementSeriesId, object_0, 0);
		}

		internal void method_31()
		{
			ataskTempl_0.m_iPremHomeResourceLevelType = smethod_15(mainEditor_0, ataskTempl_0.m_iPremHomeResourceLevelType, object_0);
		}

		internal void method_32()
		{
			ataskTempl_0.m_uSpecialMethodNpcServicesLeastLeastCount = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_uSpecialMethodNpcServicesLeastLeastCount, object_0, 0);
		}

		internal void method_33()
		{
			ataskTempl_0.m_uSpecialMethodParm1 = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_uSpecialMethodParm1, object_0, 0);
		}

		internal void method_34()
		{
			ataskTempl_0.m_uSpecialMethodParm2 = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_uSpecialMethodParm2, object_0, 0);
		}

		internal void method_35()
		{
			ataskTempl_0.m_uSpecialMethodParm3 = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_uSpecialMethodParm3, object_0, 0);
		}

		internal void method_36()
		{
			ataskTempl_0.m_uSpecialMethodTargetTaskLeastCount = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_uSpecialMethodTargetTaskLeastCount, object_0, 0);
		}

		internal void method_37()
		{
			ataskTempl_0.m_uSpecialMethodType = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_uSpecialMethodType, object_0, 0);
		}

		internal void method_38()
		{
			ataskTempl_0.m_ulDailyActivityValue = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_ulDailyActivityValue, object_0, 0);
		}

		internal void method_39()
		{
			ataskTempl_0.m_ulGivenDongluCmnCount = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_ulGivenDongluCmnCount, object_0, 0);
		}

		internal void method_40()
		{
			ataskTempl_0.m_ulGivenRelicCount = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_ulGivenRelicCount, object_0, 0);
		}

		internal void method_41()
		{
			ataskTempl_0.m_ulMonsterShapeID = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_ulMonsterShapeID, object_0, 0);
		}

		internal void method_42()
		{
			ataskTempl_0.m_ulPremPanguLevelMax = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_ulPremPanguLevelMax, object_0, 0);
		}

		internal void method_43()
		{
			ataskTempl_0.m_ulPremPanguLevelMin = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_ulPremPanguLevelMin, object_0, 0);
		}

		internal void method_44()
		{
			ataskTempl_0.m_ulPremPanguLevelYear = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_ulPremPanguLevelYear, object_0, 0);
		}

		internal void method_45()
		{
			ataskTempl_0.m_ulTransmitPointID = (uint)smethod_16(mainEditor_0, (int)ataskTempl_0.m_ulTransmitPointID, object_0, 0);
		}

		internal void method_46()
		{
			ataskTempl_0.m_iPanguEquipLevel = smethod_13(mainEditor_0, ataskTempl_0.m_iPanguEquipLevel, object_0, 0);
		}

		internal void method_47()
		{
			ataskTempl_0.m_iPanguEquipQuality = smethod_13(mainEditor_0, ataskTempl_0.m_iPanguEquipQuality, object_0, 0);
		}

		internal void method_48()
		{
			ataskTempl_0.m_iPanguEquipSlot = smethod_13(mainEditor_0, ataskTempl_0.m_iPanguEquipSlot, object_0, 0);
		}

		internal void method_49()
		{
			ataskTempl_0.m_iPanguEquipYear = smethod_13(mainEditor_0, ataskTempl_0.m_iPanguEquipYear, object_0, 0);
		}

		internal void method_50()
		{
			ataskTempl_0.m_iPremYuMoLevelMin = smethod_13(mainEditor_0, ataskTempl_0.m_iPremYuMoLevelMin, object_0, 0);
		}

		internal void method_51()
		{
			ataskTempl_0.m_iPremYuMoLevelMax = smethod_13(mainEditor_0, ataskTempl_0.m_iPremYuMoLevelMax, object_0, 0);
		}

		internal void method_52()
		{
			ataskTempl_0.m_ulReachLevel = smethod_14(mainEditor_0, ataskTempl_0.m_ulReachLevel, object_0);
		}

		internal void method_53()
		{
			ataskTempl_0.m_ulReachReincarnationCount = smethod_14(mainEditor_0, ataskTempl_0.m_ulReachReincarnationCount, object_0);
		}

		internal void method_54()
		{
			ataskTempl_0.m_ulReachRealmLevel = smethod_14(mainEditor_0, ataskTempl_0.m_ulReachRealmLevel, object_0);
			mainEditor_0.ShowRealmLevelName(control_0, ataskTempl_0.m_ulReachRealmLevel);
		}

		internal void method_55()
		{
			ataskTempl_0.m_uiEmotion = ACE.sTASKedit.Classes.Extensions.Extensions.GetDictionaryElementKeyByIndex(GProD.emotionslist, mainEditor_0.comboBox_m_uiEmotion.SelectedIndex);
			mainEditor_0.TriggerDebug(control_0);
		}

		internal void method_56()
		{
			ataskTempl_0.m_ulGrowthTarget = smethod_16(mainEditor_0, ataskTempl_0.m_ulGrowthTarget, object_0, 0);
		}

		internal void method_57()
		{
			ataskTempl_0.m_ulTMIconStateID = smethod_13(mainEditor_0, ataskTempl_0.m_ulTMIconStateID, object_0, 0);
		}

		internal void method_58()
		{
			ataskTempl_0.TMIconStateDescID = smethod_13(mainEditor_0, ataskTempl_0.TMIconStateDescID, object_0, 0);
		}

		internal void method_59()
		{
			ataskTempl_0.m_ulTMHomeLevelType = smethod_15(mainEditor_0, ataskTempl_0.m_ulTMHomeLevelType, object_0);
		}

		internal void method_60()
		{
			ataskTempl_0.m_ulTMReachHomeLevel = smethod_14(mainEditor_0, ataskTempl_0.m_ulTMReachHomeLevel, object_0);
		}

		internal void method_61()
		{
			ataskTempl_0.m_ulBindOnCarrierId = smethod_13(mainEditor_0, ataskTempl_0.m_ulBindOnCarrierId, object_0, 0);
		}

		internal void method_62()
		{
			ataskTempl_0.m_ulTMReachHomeFlourish = smethod_13(mainEditor_0, ataskTempl_0.m_ulTMReachHomeFlourish, object_0, 2);
		}

		internal void method_63()
		{
			ataskTempl_0.m_ulTMReachArenaCount = smethod_13(mainEditor_0, ataskTempl_0.m_ulTMReachArenaCount, object_0, 2);
		}

		internal void method_64()
		{
			ataskTempl_0.m_ulTMReachArenaWinCount = smethod_13(mainEditor_0, ataskTempl_0.m_ulTMReachArenaWinCount, object_0, 2);
		}

		internal void method_65()
		{
			ataskTempl_0.m_iTinyGameType = smethod_10(mainEditor_0, ataskTempl_0.m_iTinyGameType, object_0);
		}

		internal void method_66()
		{
			ataskTempl_0.m_bDeliverByUI = smethod_7(mainEditor_0, ataskTempl_0.m_bDeliverByUI, object_0);
		}

		internal void method_67()
		{
			ataskTempl_0.m_bWarTaskAward = smethod_7(mainEditor_0, ataskTempl_0.m_bWarTaskAward, object_0);
		}

		internal void method_68()
		{
			ataskTempl_0.m_bHideOtherPlayer = smethod_7(mainEditor_0, ataskTempl_0.m_bHideOtherPlayer, object_0);
		}

		internal void method_69()
		{
			ataskTempl_0.m_iHideOtherPlayerTime = smethod_13(mainEditor_0, ataskTempl_0.m_iHideOtherPlayerTime, object_0, 1);
		}

		internal void method_70()
		{
			ataskTempl_0.PropMonsterSummoned.m_bRandChoose = smethod_7(mainEditor_0, ataskTempl_0.PropMonsterSummoned.m_bRandChoose, object_0);
		}

		internal void method_71()
		{
			ataskTempl_0.PropMonsterSummoned.m_ulSummonRadius = smethod_13(mainEditor_0, ataskTempl_0.PropMonsterSummoned.m_ulSummonRadius, object_0, 2);
		}

		internal void method_72()
		{
			ataskTempl_0.PropMonsterSummoned.m_bDeathDisappear = smethod_7(mainEditor_0, ataskTempl_0.PropMonsterSummoned.m_bDeathDisappear, object_0);
		}
	}

	private sealed class Class393
	{
		public ATaskTempl ataskTempl_0;

		public ACE.sTASKedit.MainEditor.MainEditor mainEditor_0;

		public object object_0;

		public Control control_0;

		internal void method_0()
		{
			ataskTempl_0.m_bDelvInZone = smethod_7(mainEditor_0, ataskTempl_0.m_bDelvInZone, object_0);
		}

		internal void method_1()
		{
			ataskTempl_0.m_ulDelvWorld = smethod_13(mainEditor_0, ataskTempl_0.m_ulDelvWorld, object_0, 0);
		}

		internal void method_2()
		{
			ataskTempl_0.m_bEnterRegionFail = smethod_7(mainEditor_0, ataskTempl_0.m_bEnterRegionFail, object_0);
		}

		internal void method_3()
		{
			ataskTempl_0.m_ulEnterRegionWorld = smethod_13(mainEditor_0, ataskTempl_0.m_ulEnterRegionWorld, object_0, 0);
		}

		internal void method_4()
		{
			ataskTempl_0.m_bLeaveRegionFail = smethod_7(mainEditor_0, ataskTempl_0.m_bLeaveRegionFail, object_0);
		}

		internal void method_5()
		{
			ataskTempl_0.m_ulLeaveRegionWorld = smethod_13(mainEditor_0, ataskTempl_0.m_ulLeaveRegionWorld, object_0, 0);
		}

		internal void method_6()
		{
			ataskTempl_0.m_bLeaveForceFail = smethod_7(mainEditor_0, ataskTempl_0.m_bLeaveForceFail, object_0);
		}

		internal void method_7()
		{
			ataskTempl_0.m_bTransTo = smethod_7(mainEditor_0, ataskTempl_0.m_bTransTo, object_0);
		}

		internal void method_8()
		{
			ataskTempl_0.m_ulTransWldId = smethod_13(mainEditor_0, ataskTempl_0.m_ulTransWldId, object_0, 0);
		}

		internal void method_9()
		{
			ataskTempl_0.m_TransPt.Single_0[0] = smethod_17(mainEditor_0, ataskTempl_0.m_TransPt.Single_0[0], object_0, 0);
		}

		internal void method_10()
		{
			ataskTempl_0.m_TransPt.Single_0[1] = smethod_17(mainEditor_0, ataskTempl_0.m_TransPt.Single_0[1], object_0, 0);
		}

		internal void method_11()
		{
			ataskTempl_0.m_TransPt.Single_0[2] = smethod_17(mainEditor_0, ataskTempl_0.m_TransPt.Single_0[2], object_0, 0);
		}

		internal void method_12()
		{
			ataskTempl_0.m_lMonsCtrl = smethod_13(mainEditor_0, ataskTempl_0.m_lMonsCtrl, object_0, 0);
		}

		internal void method_13()
		{
			ataskTempl_0.m_bTrigCtrl = smethod_7(mainEditor_0, ataskTempl_0.m_bTrigCtrl, object_0);
		}

		internal void method_14()
		{
			ataskTempl_0.m_bAutoDeliver = smethod_7(mainEditor_0, ataskTempl_0.m_bAutoDeliver, object_0);
		}

		internal void method_15()
		{
			ataskTempl_0.m_fTeammateDist = smethod_17(mainEditor_0, ataskTempl_0.m_fTeammateDist, object_0, 0);
		}

		internal void method_16()
		{
			ataskTempl_0.m_fSuccDist = smethod_17(mainEditor_0, ataskTempl_0.m_fSuccDist, object_0, 0);
		}

		internal void method_17()
		{
			ataskTempl_0.m_fRcvMemDist = smethod_17(mainEditor_0, ataskTempl_0.m_fRcvMemDist, object_0, 0);
		}

		internal void method_18()
		{
			ataskTempl_0.m_fCntMemDist = smethod_17(mainEditor_0, ataskTempl_0.m_fCntMemDist, object_0, 0);
		}

		internal void method_19()
		{
			ataskTempl_0.m_ulReachSiteId = smethod_13(mainEditor_0, ataskTempl_0.m_ulReachSiteId, object_0, 0);
		}

		internal void method_20()
		{
			ataskTempl_0.m_ulLeaveSiteId = smethod_13(mainEditor_0, ataskTempl_0.m_ulLeaveSiteId, object_0, 0);
		}

		internal void method_21()
		{
			ataskTempl_0.m_ulWaitTime = smethod_13(mainEditor_0, ataskTempl_0.m_ulWaitTime, object_0, 1);
		}

		internal void method_22()
		{
			ataskTempl_0.m_TreasureStartZone.Single_0[0] = smethod_17(mainEditor_0, ataskTempl_0.m_TreasureStartZone.Single_0[0], object_0, 0);
		}

		internal void method_23()
		{
			ataskTempl_0.m_TreasureStartZone.Single_0[1] = smethod_17(mainEditor_0, ataskTempl_0.m_TreasureStartZone.Single_0[1], object_0, 0);
		}

		internal void method_24()
		{
			ataskTempl_0.m_TreasureStartZone.Single_0[2] = smethod_17(mainEditor_0, ataskTempl_0.m_TreasureStartZone.Single_0[2], object_0, 0);
		}

		internal void method_25()
		{
			ataskTempl_0.m_ucZonesNumX = smethod_8(mainEditor_0, ataskTempl_0.m_ucZonesNumX, object_0);
		}

		internal void method_26()
		{
			ataskTempl_0.m_ucZonesNumZ = smethod_8(mainEditor_0, ataskTempl_0.m_ucZonesNumZ, object_0);
		}

		internal void method_27()
		{
			ataskTempl_0.m_ucZoneSide = smethod_8(mainEditor_0, ataskTempl_0.m_ucZoneSide, object_0);
		}

		internal void method_28()
		{
			ataskTempl_0.m_usZoneMapID = smethod_11(mainEditor_0, ataskTempl_0.m_usZoneMapID, object_0, 0);
		}

		internal void method_29()
		{
			ataskTempl_0.m_ulNPCToProtect = smethod_13(mainEditor_0, ataskTempl_0.m_ulNPCToProtect, object_0, 0);
		}

		internal void method_30()
		{
			ataskTempl_0.m_ulProtectTimeLen = smethod_13(mainEditor_0, ataskTempl_0.m_ulProtectTimeLen, object_0, 1);
		}

		internal void method_31()
		{
			ataskTempl_0.m_ulNPCMoving = smethod_13(mainEditor_0, ataskTempl_0.m_ulNPCMoving, object_0, 0);
		}

		internal void method_32()
		{
			ataskTempl_0.m_ulNPCDestSite = smethod_13(mainEditor_0, ataskTempl_0.m_ulNPCDestSite, object_0, 0);
		}

		internal void method_33()
		{
			ataskTempl_0.m_bDeliverySkill = smethod_7(mainEditor_0, ataskTempl_0.m_bDeliverySkill, object_0);
		}

		internal void method_34()
		{
			ataskTempl_0.m_iDeliveredSkillID = smethod_13(mainEditor_0, ataskTempl_0.m_iDeliveredSkillID, object_0, 0);
		}

		internal void method_35()
		{
			ataskTempl_0.m_iDeliveredSkillLevel = smethod_14(mainEditor_0, ataskTempl_0.m_iDeliveredSkillLevel, object_0);
		}

		internal void method_36()
		{
			ataskTempl_0.m_lSkillLev[0] = smethod_14(mainEditor_0, ataskTempl_0.m_lSkillLev[0], object_0);
		}

		internal void method_37()
		{
			ataskTempl_0.m_lSkillLev[1] = smethod_14(mainEditor_0, ataskTempl_0.m_lSkillLev[1], object_0);
		}

		internal void method_38()
		{
			ataskTempl_0.m_lSkillLev[2] = smethod_14(mainEditor_0, ataskTempl_0.m_lSkillLev[2], object_0);
		}

		internal void method_39()
		{
			ataskTempl_0.m_lSkillLev[3] = smethod_14(mainEditor_0, ataskTempl_0.m_lSkillLev[3], object_0);
		}

		internal void method_40()
		{
			ataskTempl_0.m_DynTaskType = smethod_10(mainEditor_0, ataskTempl_0.m_DynTaskType, object_0);
		}

		internal void method_41()
		{
			ataskTempl_0.m_ulSpecialAward = smethod_13(mainEditor_0, ataskTempl_0.m_ulSpecialAward, object_0, 0);
		}

		internal void method_42()
		{
			int selectedMethodValue = mainEditor_0.GetSelectedMethodValue();
			if (ataskTempl_0.m_enumMethod != selectedMethodValue)
			{
				ataskTempl_0.m_enumMethod = selectedMethodValue;
				mainEditor_0.TriggerDebug(control_0);
			}
			mainEditor_0.ChangeMethodUI();
			if (ataskTempl_0.m_enumMethod == 27)
			{
				mainEditor_0.tabControl1.SelectedIndex = 1;
			}
		}

		internal void method_43()
		{
			ataskTempl_0.m_enumFinishType = smethod_15(mainEditor_0, ataskTempl_0.m_enumFinishType, object_0);
		}

		internal void method_44()
		{
			ataskTempl_0.m_bMonsterTotalCount = smethod_7(mainEditor_0, ataskTempl_0.m_bMonsterTotalCount, object_0);
		}

		internal void method_45()
		{
			ataskTempl_0.m_ulGoldWanted = smethod_13(mainEditor_0, ataskTempl_0.m_ulGoldWanted, object_0, 2);
		}

		internal void method_46()
		{
			ataskTempl_0.m_ulGoldWanted2 = smethod_13(mainEditor_0, ataskTempl_0.m_ulGoldWanted2, object_0, 2);
		}

		internal void method_47()
		{
			ataskTempl_0.m_iFactionContribWanted = smethod_13(mainEditor_0, ataskTempl_0.m_iFactionContribWanted, object_0, 2);
		}

		internal void method_48()
		{
			ataskTempl_0.m_iFactionExpContribWanted = smethod_13(mainEditor_0, ataskTempl_0.m_iFactionExpContribWanted, object_0, 2);
		}

		internal void method_49()
		{
			if (tasksConvert.ShortsToGbkString(ataskTempl_0.m_szShowDialogName) != mainEditor_0.textBox_Dialog.Text)
			{
				ataskTempl_0.m_szShowDialogName = tasksConvert.GbkStringToShorts(mainEditor_0.textBox_Dialog.Text, 20);
				mainEditor_0.TriggerDebug(control_0);
			}
		}

		internal void method_50()
		{
			if (tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_TaskEventName) != mainEditor_0.textBox_TaskEventChar.Text)
			{
				ataskTempl_0.m_TaskEventName = tasksConvert.UnicodeStringToShorts(mainEditor_0.textBox_TaskEventChar.Text, 30);
				mainEditor_0.TriggerDebug(control_0);
			}
		}

		internal void method_51()
		{
			ataskTempl_0.m_TaskEventType = smethod_15(mainEditor_0, ataskTempl_0.m_TaskEventType, object_0);
			mainEditor_0.SetUIPropsByTaskEventType();
		}

		internal void method_52()
		{
			ataskTempl_0.m_usTaskEventTimeOrScore = smethod_11(mainEditor_0, ataskTempl_0.m_usTaskEventTimeOrScore, object_0, 2);
		}

		internal void method_53()
		{
			ataskTempl_0.m_FactionPersonScore = smethod_11(mainEditor_0, ataskTempl_0.m_FactionPersonScore, object_0, 2);
		}

		internal void method_54()
		{
			ataskTempl_0.m_iTinyGameType = smethod_10(mainEditor_0, ataskTempl_0.m_iTinyGameType, object_0);
		}

		internal void method_55()
		{
			ataskTempl_0.m_chatGroupId = smethod_13(mainEditor_0, ataskTempl_0.m_chatGroupId, object_0, 0);
		}

		internal void method_56()
		{
			ataskTempl_0.m_iGuessStringID = smethod_13(mainEditor_0, ataskTempl_0.m_iGuessStringID, object_0, 0);
		}

		internal void method_57()
		{
			ataskTempl_0.m_iTriggerEvent = smethod_13(mainEditor_0, ataskTempl_0.m_iTriggerEvent, object_0, 0);
		}

		internal void method_58()
		{
			ataskTempl_0.m_iVerifyStateLayer = smethod_13(mainEditor_0, ataskTempl_0.m_iVerifyStateLayer, object_0, 0);
		}

		internal void method_59()
		{
			ataskTempl_0.m_ulVerifyStateLayerID = smethod_13(mainEditor_0, ataskTempl_0.m_ulVerifyStateLayerID, object_0, 0);
		}

		internal void method_60()
		{
			ataskTempl_0.m_iKeyWordIndex = smethod_13(mainEditor_0, ataskTempl_0.m_iKeyWordIndex, object_0, 0);
		}
	}

	[CLSCompliant(false)]
	public static void Task(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, ref ATaskTempl ataskTempl_0, object object_0)
	{
		if (ataskTempl_0 == null || ACE.sTASKedit.MainEditor.MainEditor.LockedChange || ACE.sTASKedit.MainEditor.MainEditor.Selecting)
		{
			return;
		}
		try
		{
			Control control_ = (Control)object_0;
			if (!smethod_0(mainEditor_0, ataskTempl_0, control_, object_0) && !smethod_1(mainEditor_0, ataskTempl_0, control_, object_0) && !smethod_2(mainEditor_0, ataskTempl_0, control_, object_0) && !smethod_3(mainEditor_0, ataskTempl_0, control_, object_0) && !smethod_4(mainEditor_0, ataskTempl_0, control_, object_0))
			{
				smethod_5(mainEditor_0, ataskTempl_0, control_, object_0);
			}
		}
		catch
		{
			DKBox.Show(GProD.TX(403), string.Empty);
		}
	}

	private static bool smethod_0(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, ATaskTempl ataskTempl_0, Control control_0, object object_0)
	{
		Class390 @class = new Class390();
		@class.ataskTempl_0 = ataskTempl_0;
		@class.mainEditor_0 = mainEditor_0;
		@class.object_0 = object_0;
		@class.control_0 = control_0;
		Dictionary<Control, Action> dictionary = new Dictionary<Control, Action>
		{
			{
				@class.mainEditor_0.comboBox_IDSpace,
				@class.method_0
			},
			{
				@class.mainEditor_0.textBox_m_ID,
				@class.method_1
			},
			{
				@class.mainEditor_0.textBox_m_szName,
				@class.method_2
			},
			{
				@class.mainEditor_0.textBox_m_pszSignature,
				@class.method_3
			},
			{
				@class.mainEditor_0.comboBox_m_ulType,
				@class.method_4
			},
			{
				@class.mainEditor_0.textBox_m_ulDelvNPC,
				@class.method_5
			},
			{
				@class.mainEditor_0.textBox_m_ulAwardNPC,
				@class.method_6
			},
			{
				@class.mainEditor_0.textBox_m_ulParent,
				@class.method_7
			},
			{
				@class.mainEditor_0.textBox_m_ulPrevSibling,
				@class.method_8
			},
			{
				@class.mainEditor_0.textBox_m_ulNextSibling,
				@class.method_9
			},
			{
				@class.mainEditor_0.textBox_m_ulFirstChild,
				@class.method_10
			}
		};
		if (dictionary.TryGetValue(@class.control_0, out var value))
		{
			value();
			return true;
		}
		return false;
	}

	private static bool smethod_1(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, ATaskTempl ataskTempl_0, Control control_0, object object_0)
	{
		Class388 @class = new Class388();
		@class.ataskTempl_0 = ataskTempl_0;
		@class.mainEditor_0 = mainEditor_0;
		@class.object_0 = object_0;
		Dictionary<Control, Action> dictionary = new Dictionary<Control, Action>
		{
			{
				@class.mainEditor_0.checkBox_m_bOfflineFail,
				@class.method_0
			},
			{
				@class.mainEditor_0.checkBox_m_bAbsFail,
				@class.method_1
			},
			{
				@class.mainEditor_0.dateTimePicker_m_tmAbsFailTime,
				@class.method_2
			},
			{
				@class.mainEditor_0.textBox_m_ulTimeLimit,
				@class.method_3
			},
			{
				@class.mainEditor_0.checkBox_NextFail,
				@class.method_4
			},
			{
				@class.mainEditor_0.checkBox_m_bAbsTime,
				@class.method_5
			},
			{
				@class.mainEditor_0.comboBox_m_lAvailFrequency,
				@class.method_6
			},
			{
				@class.mainEditor_0.numericUpDown_m_lFrequencyNum,
				@class.method_7
			},
			{
				@class.mainEditor_0.numericUpDown_m_lPeriodLimit,
				@class.method_8
			},
			{
				@class.mainEditor_0.checkBox_m_bAvailFrequency,
				@class.method_9
			},
			{
				@class.mainEditor_0.checkBox_m_bChooseOne,
				@class.method_10
			},
			{
				@class.mainEditor_0.checkBox_m_bRandOne,
				@class.method_11
			},
			{
				@class.mainEditor_0.checkBox_m_bExeChildInOrder,
				@class.method_12
			},
			{
				@class.mainEditor_0.checkBox_m_bParentAlsoFail,
				@class.method_13
			},
			{
				@class.mainEditor_0.checkBox_m_bParentAlsoSucc,
				@class.method_14
			},
			{
				@class.mainEditor_0.checkBox_m_bCanGiveUp,
				@class.method_15
			},
			{
				@class.mainEditor_0.checkBox_m_bCanRedo,
				@class.method_16
			},
			{
				@class.mainEditor_0.checkBox_m_bCanRedoAfterFailure,
				@class.method_17
			},
			{
				@class.mainEditor_0.checkBox_m_bClearAsGiveUp,
				@class.method_18
			},
			{
				@class.mainEditor_0.checkBox_m_bNeedRecord,
				@class.method_19
			},
			{
				@class.mainEditor_0.checkBox_m_bFailAsPlayerDie,
				@class.method_20
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulMaxReceiver,
				@class.method_21
			},
			{
				@class.mainEditor_0.checkBox_m_bItemNotTakeOff,
				@class.method_22
			},
			{
				@class.mainEditor_0.checkBox_MultiNpcTalk,
				@class.method_23
			},
			{
				@class.mainEditor_0.checkBox_m_bSkillTask,
				@class.method_24
			},
			{
				@class.mainEditor_0.checkBox_m_bCanSeekOut,
				@class.method_25
			},
			{
				@class.mainEditor_0.checkBox_m_bShowDirection,
				@class.method_26
			},
			{
				@class.mainEditor_0.checkBox_m_bMarriage,
				@class.method_27
			},
			{
				@class.mainEditor_0.checkBox_m_bSwitchSceneFail,
				@class.method_28
			},
			{
				@class.mainEditor_0.checkBox_m_bHidden,
				@class.method_29
			},
			{
				@class.mainEditor_0.checkBox_m_bShowPrompt,
				@class.method_30
			},
			{
				@class.mainEditor_0.checkBox_m_bKeyTask,
				@class.method_31
			},
			{
				@class.mainEditor_0.checkBox_m_bGM,
				@class.method_32
			},
			{
				@class.mainEditor_0.checkBox_m_bShieldUser,
				@class.method_33
			},
			{
				@class.mainEditor_0.checkBox_m_bTeamwork,
				@class.method_34
			},
			{
				@class.mainEditor_0.checkBox_m_bRcvByTeam,
				@class.method_35
			},
			{
				@class.mainEditor_0.checkBox_m_bSharedTask,
				@class.method_36
			},
			{
				@class.mainEditor_0.checkBox_m_bSharedAchieved,
				@class.method_37
			},
			{
				@class.mainEditor_0.checkBox_m_bCheckTeammate,
				@class.method_38
			},
			{
				@class.mainEditor_0.checkBox_m_bAllFail,
				@class.method_39
			},
			{
				@class.mainEditor_0.checkBox_m_bCapFail,
				@class.method_40
			},
			{
				@class.mainEditor_0.checkBox_m_bCapSucc,
				@class.method_41
			},
			{
				@class.mainEditor_0.checkBox_m_bDismAsSelfFail,
				@class.method_42
			},
			{
				@class.mainEditor_0.checkBox_m_bRcvChckMem,
				@class.method_43
			},
			{
				@class.mainEditor_0.checkBox_m_bCntByMemPos,
				@class.method_44
			},
			{
				@class.mainEditor_0.checkBox_m_bAllSucc,
				@class.method_45
			},
			{
				@class.mainEditor_0.checkBox_m_bCoupleOnly,
				@class.method_46
			},
			{
				@class.mainEditor_0.checkBox_m_bDistinguishedOcc,
				@class.method_47
			}
		};
		if (dictionary.TryGetValue(control_0, out var value))
		{
			value();
			return true;
		}
		return false;
	}

	private static bool smethod_2(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, ATaskTempl ataskTempl_0, Control control_0, object object_0)
	{
		Class393 @class = new Class393();
		@class.ataskTempl_0 = ataskTempl_0;
		@class.mainEditor_0 = mainEditor_0;
		@class.object_0 = object_0;
		@class.control_0 = control_0;
		Dictionary<Control, Action> dictionary = new Dictionary<Control, Action>
		{
			{
				@class.mainEditor_0.checkBox_m_bDelvInZone,
				@class.method_0
			},
			{
				@class.mainEditor_0.textBox_m_ulDelvWorld,
				@class.method_1
			},
			{
				@class.mainEditor_0.checkBox_m_bEnterRegionFail,
				@class.method_2
			},
			{
				@class.mainEditor_0.textBox_m_ulEnterRegionWorld,
				@class.method_3
			},
			{
				@class.mainEditor_0.checkBox_m_bLeaveRegionFail,
				@class.method_4
			},
			{
				@class.mainEditor_0.textBox_m_ulLeaveRegionWorld,
				@class.method_5
			},
			{
				@class.mainEditor_0.checkBox_m_bLeaveForceFail,
				@class.method_6
			},
			{
				@class.mainEditor_0.checkBox_m_bTransTo,
				@class.method_7
			},
			{
				@class.mainEditor_0.textBox_m_ulTransWldId,
				@class.method_8
			},
			{
				@class.mainEditor_0.textBox_m_TransPt_v_1,
				@class.method_9
			},
			{
				@class.mainEditor_0.textBox_m_TransPt_v_2,
				@class.method_10
			},
			{
				@class.mainEditor_0.textBox_m_TransPt_v_3,
				@class.method_11
			},
			{
				@class.mainEditor_0.textBox_m_lMonsCtrl,
				@class.method_12
			},
			{
				@class.mainEditor_0.checkBox_m_bTrigCtrl,
				@class.method_13
			},
			{
				@class.mainEditor_0.checkBox_m_bAutoDeliver,
				@class.method_14
			},
			{
				@class.mainEditor_0.textBox_m_fTeammateDist,
				@class.method_15
			},
			{
				@class.mainEditor_0.textBox_m_fSuccDist,
				@class.method_16
			},
			{
				@class.mainEditor_0.textBox_m_fRcvMemDist,
				@class.method_17
			},
			{
				@class.mainEditor_0.textBox_m_fCntMemDist,
				@class.method_18
			},
			{
				@class.mainEditor_0.textBox_m_ulReachSiteId,
				@class.method_19
			},
			{
				@class.mainEditor_0.textBox_m_ulLeaveSiteId,
				@class.method_20
			},
			{
				@class.mainEditor_0.textBox_m_ulWaitTime,
				@class.method_21
			},
			{
				@class.mainEditor_0.textBox_m_TreasureStartZone_v_1,
				@class.method_22
			},
			{
				@class.mainEditor_0.textBox_m_TreasureStartZone_v_2,
				@class.method_23
			},
			{
				@class.mainEditor_0.textBox_m_TreasureStartZone_v_3,
				@class.method_24
			},
			{
				@class.mainEditor_0.textBox_m_ucZonesNumX,
				@class.method_25
			},
			{
				@class.mainEditor_0.textBox_m_ucZonesNumZ,
				@class.method_26
			},
			{
				@class.mainEditor_0.textBox_m_ucZoneSide,
				@class.method_27
			},
			{
				@class.mainEditor_0.textBox_treasureZoneMapID,
				@class.method_28
			},
			{
				@class.mainEditor_0.textBox_m_ulNPCToProtect,
				@class.method_29
			},
			{
				@class.mainEditor_0.textBox_m_ulProtectTimeLen,
				@class.method_30
			},
			{
				@class.mainEditor_0.textBox_m_ulNPCMoving,
				@class.method_31
			},
			{
				@class.mainEditor_0.textBox_m_ulNPCDestSite,
				@class.method_32
			},
			{
				@class.mainEditor_0.checkBox_m_bDeliverySkill,
				@class.method_33
			},
			{
				@class.mainEditor_0.textBox_m_iDeliveredSkillID,
				@class.method_34
			},
			{
				@class.mainEditor_0.numericUpDown_m_iDeliveredSkillLevel,
				@class.method_35
			},
			{
				@class.mainEditor_0.numericUpDown_m_lSkillLev_1,
				@class.method_36
			},
			{
				@class.mainEditor_0.numericUpDown_m_lSkillLev_2,
				@class.method_37
			},
			{
				@class.mainEditor_0.numericUpDown_m_lSkillLev_3,
				@class.method_38
			},
			{
				@class.mainEditor_0.numericUpDown_m_lSkillLev_4,
				@class.method_39
			},
			{
				@class.mainEditor_0.comboBox_m_DynTaskType,
				@class.method_40
			},
			{
				@class.mainEditor_0.textBox_m_ulSpecialAward,
				@class.method_41
			},
			{
				@class.mainEditor_0.comboBox_m_enumMethod,
				@class.method_42
			},
			{
				@class.mainEditor_0.comboBox_m_enumFinishType,
				@class.method_43
			},
			{
				@class.mainEditor_0.checkBox_MonsterTotalCount,
				@class.method_44
			},
			{
				@class.mainEditor_0.textBox_m_ulGoldWanted,
				@class.method_45
			},
			{
				@class.mainEditor_0.textBox_m_ulGold2Wanted,
				@class.method_46
			},
			{
				@class.mainEditor_0.textBox_m_iFactionContribWanted,
				@class.method_47
			},
			{
				@class.mainEditor_0.textBox_m_iFactionExpContribWanted,
				@class.method_48
			},
			{
				@class.mainEditor_0.textBox_Dialog,
				@class.method_49
			},
			{
				@class.mainEditor_0.textBox_TaskEventChar,
				@class.method_50
			},
			{
				@class.mainEditor_0.comboBox_TaskEventType,
				@class.method_51
			},
			{
				@class.mainEditor_0.textBox_TaskEventTime,
				@class.method_52
			},
			{
				@class.mainEditor_0.textBox_FactionPersonScore,
				@class.method_53
			},
			{
				@class.mainEditor_0.comboBox_TMTinyGameType,
				@class.method_54
			},
			{
				@class.mainEditor_0.textBox_BarrageChannel,
				@class.method_55
			},
			{
				@class.mainEditor_0.textBox_GuessInputID,
				@class.method_56
			},
			{
				@class.mainEditor_0.textBox_SuccTriggerEvent,
				@class.method_57
			},
			{
				@class.mainEditor_0.textBox_VerifyStateLayer,
				@class.method_58
			},
			{
				@class.mainEditor_0.textBox_VerifyStateLayerID,
				@class.method_59
			},
			{
				@class.mainEditor_0.textBox_KeyWordIndex,
				@class.method_60
			}
		};
		if (dictionary.TryGetValue(@class.control_0, out var value))
		{
			value();
			return true;
		}
		return false;
	}

	private static bool smethod_3(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, ATaskTempl ataskTempl_0, Control control_0, object object_0)
	{
		Class387 @class = new Class387();
		@class.ataskTempl_0 = ataskTempl_0;
		@class.mainEditor_0 = mainEditor_0;
		@class.object_0 = object_0;
		@class.control_0 = control_0;
		Dictionary<Control, Action> dictionary = new Dictionary<Control, Action>
		{
			{
				@class.mainEditor_0.checkBox_m_bDisplayInExclusiveUI,
				@class.method_0
			},
			{
				@class.mainEditor_0.checkBox_m_bDisplayInTitleTaskUI,
				@class.method_1
			},
			{
				@class.mainEditor_0.checkBox_m_bReadyToNotifyServer,
				@class.method_2
			},
			{
				@class.mainEditor_0.checkBox_m_bUsedInTokenShop,
				@class.method_3
			},
			{
				@class.mainEditor_0.checkBox_m_bDeathTrig,
				@class.method_4
			},
			{
				@class.mainEditor_0.checkBox_m_bClearAcquired,
				@class.method_5
			},
			{
				@class.mainEditor_0.checkBox_m_bShowGfxFinished,
				@class.method_6
			},
			{
				@class.mainEditor_0.checkBox_m_bChangePQRanking,
				@class.method_7
			},
			{
				@class.mainEditor_0.checkBox_m_bCompareItemAndInventory,
				@class.method_8
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulInventorySlotNum,
				@class.method_9
			},
			{
				@class.mainEditor_0.checkBox_ShowMethod,
				@class.method_10
			},
			{
				@class.mainEditor_0.comboBox_GfxType,
				@class.method_11
			},
			{
				@class.mainEditor_0.checkBox_m_bTowerTask,
				@class.method_12
			},
			{
				@class.mainEditor_0.checkBox_m_bHomeTask,
				@class.method_13
			},
			{
				@class.mainEditor_0.checkBox_m_bDeliverInHostHome,
				@class.method_14
			},
			{
				@class.mainEditor_0.checkBox_m_bFinishInHostHome,
				@class.method_15
			},
			{
				@class.mainEditor_0.checkBox_m_bPQTask,
				@class.method_16
			},
			{
				@class.mainEditor_0.checkBox_m_bPQSubTask,
				@class.method_17
			},
			{
				@class.mainEditor_0.checkBox_m_bClearContrib,
				@class.method_18
			},
			{
				@class.mainEditor_0.checkBox_m_bAccountTaskLimit,
				@class.method_19
			},
			{
				@class.mainEditor_0.checkBox_m_bRoleTaskLimit,
				@class.method_20
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulAccountTaskLimitCnt,
				@class.method_21
			},
			{
				@class.mainEditor_0.checkBox_m_bLeaveFactionFail,
				@class.method_22
			},
			{
				@class.mainEditor_0.checkBox_m_bNotIncCntWhenFailed,
				@class.method_23
			},
			{
				@class.mainEditor_0.checkBox_m_bNotClearItemWhenFailed,
				@class.method_24
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulSuitableLevel,
				@class.method_25
			},
			{
				@class.mainEditor_0.numericUpDown_m_iPremNeedRecordTasksNum,
				@class.method_26
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByNeedRecordTasksNum,
				@class.method_27
			},
			{
				@class.mainEditor_0.textBox_m_iPremiseFactionContrib,
				@class.method_28
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByFactionContrib,
				@class.method_29
			},
			{
				@class.mainEditor_0.textBox_m_ucPremiseTransformedForm,
				@class.method_30
			},
			{
				@class.mainEditor_0.textBox_m_cEffectiveGameServer,
				@class.method_31
			},
			{
				@class.mainEditor_0.textBox_m_cPremInventorySizeMax,
				@class.method_32
			},
			{
				@class.mainEditor_0.textBox_m_cPremInventorySizeMin,
				@class.method_33
			},
			{
				@class.mainEditor_0.textBox_m_cPremStorageSizeMax,
				@class.method_34
			},
			{
				@class.mainEditor_0.textBox_m_cPremStorageSizeMin,
				@class.method_35
			},
			{
				@class.mainEditor_0.textBox_m_iSlotMachineType,
				@class.method_36
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByTransformed,
				@class.method_37
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulPremise_Lev_Min,
				@class.method_38
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulPremise_Lev_Max,
				@class.method_39
			},
			{
				@class.mainEditor_0.checkBox_m_bPremCheckMaxHistoryLevel,
				@class.method_40
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByLev,
				@class.method_41
			},
			{
				@class.mainEditor_0.checkBox_m_bPremCheckReincarnation,
				@class.method_42
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulPremReincarnationMin,
				@class.method_43
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulPremReincarnationMax,
				@class.method_44
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByReincarnation,
				@class.method_45
			},
			{
				@class.mainEditor_0.checkBox_m_bPremCheckRealmLevel,
				@class.method_46
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulPremRealmLevelMin,
				@class.method_47
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulPremRealmLevelMax,
				@class.method_48
			},
			{
				@class.mainEditor_0.checkBox_m_bPremCheckRealmExpFull,
				@class.method_49
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByRealmLevel,
				@class.method_50
			},
			{
				@class.mainEditor_0.checkBox_RecordDeliverTime,
				@class.method_51
			},
			{
				@class.mainEditor_0.checkBox_m_bAllowBatchAward,
				@class.method_52
			},
			{
				@class.mainEditor_0.checkBox_m_bCheckExp,
				@class.method_53
			},
			{
				@class.mainEditor_0.checkBox_m_bCheckInventorySize,
				@class.method_54
			},
			{
				@class.mainEditor_0.checkBox_m_bCheckStorageSize,
				@class.method_55
			},
			{
				@class.mainEditor_0.checkBox_m_bMethodItemsRandOne,
				@class.method_56
			},
			{
				@class.mainEditor_0.checkBox_m_bCheckYuMoLevel,
				@class.method_57
			},
			{
				@class.mainEditor_0.checkBox_m_bPremCheckPanguLevel,
				@class.method_58
			},
			{
				@class.mainEditor_0.checkBox_m_bRecordReset,
				@class.method_59
			},
			{
				@class.mainEditor_0.checkBox_m_bShowAchievementSeriesId,
				@class.method_60
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByRealmExpNotFull,
				@class.method_61
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByTradeTime,
				@class.method_62
			},
			{
				@class.mainEditor_0.checkBox_m_bShowDailyActivityPremise,
				@class.method_63
			},
			{
				@class.mainEditor_0.checkBox_m_bShowPanguEquipPremise,
				@class.method_64
			},
			{
				@class.mainEditor_0.checkBox_m_bShowPropertyPremis,
				@class.method_65
			},
			{
				@class.mainEditor_0.checkBox_m_bVaguePromptingMode,
				@class.method_66
			},
			{
				@class.mainEditor_0.checkBox_m_bShowPackSizePremise,
				@class.method_67
			},
			{
				@class.mainEditor_0.checkBox_m_bShowExploreIcon,
				@class.method_68
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByExpNotFull,
				@class.method_69
			},
			{
				@class.mainEditor_0.checkBox_m_bDoNotShowGfx,
				@class.method_70
			},
			{
				@class.mainEditor_0.checkBox_m_bCheckTradeTime,
				@class.method_71
			},
			{
				@class.mainEditor_0.checkBox_m_bCheckPanguEquip,
				@class.method_72
			},
			{
				@class.mainEditor_0.checkBox_m_bCheckRealmExp,
				@class.method_73
			},
			{
				@class.mainEditor_0.checkBox_m_bCheckLieMoLevel,
				@class.method_74
			},
			{
				@class.mainEditor_0.checkBox_m_bFailIconStateID,
				@class.method_75
			},
			{
				@class.mainEditor_0.checkBox_m_bAutoDeliverHighPriority,
				@class.method_76
			},
			{
				@class.mainEditor_0.checkBox_m_bPremTotalItemsWanted,
				@class.method_77
			},
			{
				@class.mainEditor_0.checkBox_m_bMethodTotalItemsWanted,
				@class.method_78
			},
			{
				@class.mainEditor_0.textBox_m_iCameraMovementID,
				@class.method_79
			},
			{
				@class.mainEditor_0.textBox_m_iPremDailyActivityValue,
				@class.method_80
			},
			{
				@class.mainEditor_0.checkBox_CanAwardOnCarrier,
				@class.method_81
			},
			{
				@class.mainEditor_0.checkBox_CheckFactionMem,
				@class.method_82
			},
			{
				@class.mainEditor_0.textBox_FactionMem,
				@class.method_83
			},
			{
				@class.mainEditor_0.checkBox_SpecailLogicTask,
				@class.method_84
			},
			{
				@class.mainEditor_0.checkBox_DiscardedTask,
				@class.method_85
			},
			{
				@class.mainEditor_0.checkBox_NoCheckTitleGot,
				@class.method_86
			},
			{
				@class.mainEditor_0.numericUpDown_CrossServer,
				@class.method_87
			},
			{
				@class.mainEditor_0.checkBox_CrossServer,
				@class.method_88
			},
			{
				@class.mainEditor_0.textBox_IconStateIDForAwardVar,
				@class.method_89
			},
			{
				@class.mainEditor_0.textBox_GlobalKeyForAwardVar,
				@class.method_90
			},
			{
				@class.mainEditor_0.textBox_PersonKeyForAwardVar,
				@class.method_91
			},
			{
				@class.mainEditor_0.textBox_HistoryKeyForAwardVar,
				@class.method_92
			},
			{
				@class.mainEditor_0.checkBox_RecordFinishCount,
				@class.method_93
			},
			{
				@class.mainEditor_0.checkBox_TeamHaveRecaller,
				@class.method_94
			},
			{
				@class.mainEditor_0.checkBox_BindedRecaller,
				@class.method_95
			},
			{
				@class.mainEditor_0.checkBox_HistoryVarTask,
				@class.method_96
			}
		};
		if (dictionary.TryGetValue(@class.control_0, out var value))
		{
			value();
			return true;
		}
		return false;
	}

	private static bool smethod_4(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, ATaskTempl ataskTempl_0, Control control_0, object object_0)
	{
		Class392 @class = new Class392();
		@class.ataskTempl_0 = ataskTempl_0;
		@class.mainEditor_0 = mainEditor_0;
		@class.object_0 = object_0;
		@class.control_0 = control_0;
		Dictionary<Control, Action> dictionary = new Dictionary<Control, Action>
		{
			{
				@class.mainEditor_0.textBox_camera_rotate_axis,
				@class.method_0
			},
			{
				@class.mainEditor_0.textBox_camera_rotate_angle,
				@class.method_1
			},
			{
				@class.mainEditor_0.textBox_camera_take_seconds,
				@class.method_2
			},
			{
				@class.mainEditor_0.textBox_camera_start_pos_x,
				@class.method_3
			},
			{
				@class.mainEditor_0.textBox_camera_start_pos_y,
				@class.method_4
			},
			{
				@class.mainEditor_0.textBox_camera_start_pos_z,
				@class.method_5
			},
			{
				@class.mainEditor_0.textBox_camera_start_quat_x,
				@class.method_6
			},
			{
				@class.mainEditor_0.textBox_camera_start_quat_y,
				@class.method_7
			},
			{
				@class.mainEditor_0.textBox_camera_start_quat_z,
				@class.method_8
			},
			{
				@class.mainEditor_0.textBox_camera_start_quat_w,
				@class.method_9
			},
			{
				@class.mainEditor_0.textBox_camera_target_pos_x,
				@class.method_10
			},
			{
				@class.mainEditor_0.textBox_camera_target_pos_y,
				@class.method_11
			},
			{
				@class.mainEditor_0.textBox_camera_target_pos_z,
				@class.method_12
			},
			{
				@class.mainEditor_0.textBox_camera_target_quat_x,
				@class.method_13
			},
			{
				@class.mainEditor_0.textBox_camera_target_quat_y,
				@class.method_14
			},
			{
				@class.mainEditor_0.textBox_camera_target_quat_z,
				@class.method_15
			},
			{
				@class.mainEditor_0.textBox_camera_target_quat_w,
				@class.method_16
			},
			{
				@class.mainEditor_0.checkBox_FailNeedComp,
				@class.method_17
			},
			{
				@class.mainEditor_0.comboBox_FailExp1AndOrExp2,
				@class.method_18
			},
			{
				@class.mainEditor_0.checkBox_FailPersonNeedComp,
				@class.method_19
			},
			{
				@class.mainEditor_0.comboBox_FailPersonExp1AndOrExp2,
				@class.method_20
			},
			{
				@class.mainEditor_0.checkBox_m_bFinNeedComp,
				@class.method_21
			},
			{
				@class.mainEditor_0.comboBox_m_nFinExp1AndOrExp2,
				@class.method_22
			},
			{
				@class.mainEditor_0.checkBox_FinNeedCompPerson,
				@class.method_23
			},
			{
				@class.mainEditor_0.comboBox_FinPersonExp1AndOrExp2,
				@class.method_24
			},
			{
				@class.mainEditor_0.checkBox_FinNeedCompHistory,
				@class.method_25
			},
			{
				@class.mainEditor_0.comboBox_FinHistoryExp1AndOrExp2,
				@class.method_26
			},
			{
				@class.mainEditor_0.textBox_m_ucTransformedForm,
				@class.method_27
			},
			{
				@class.mainEditor_0.textBox_TransformedDescID,
				@class.method_28
			},
			{
				@class.mainEditor_0.textBox_m_HintConfigId,
				@class.method_29
			},
			{
				@class.mainEditor_0.textBox_m_iAchievementSeriesId,
				@class.method_30
			},
			{
				@class.mainEditor_0.comboBox_m_iPremHomeResourceLevelType,
				@class.method_31
			},
			{
				@class.mainEditor_0.textBox_m_uSpecialMethodNpcServicesLeastLeastCount,
				@class.method_32
			},
			{
				@class.mainEditor_0.textBox_m_uSpecialMethodParm1,
				@class.method_33
			},
			{
				@class.mainEditor_0.textBox_m_uSpecialMethodParm2,
				@class.method_34
			},
			{
				@class.mainEditor_0.textBox_m_uSpecialMethodParm3,
				@class.method_35
			},
			{
				@class.mainEditor_0.textBox_m_uSpecialMethodTargetTaskLeastCount,
				@class.method_36
			},
			{
				@class.mainEditor_0.textBox_m_uSpecialMethodType,
				@class.method_37
			},
			{
				@class.mainEditor_0.textBox_m_ulDailyActivityValue,
				@class.method_38
			},
			{
				@class.mainEditor_0.textBox_m_ulGivenDongluCmnCount,
				@class.method_39
			},
			{
				@class.mainEditor_0.textBox_m_ulGivenRelicCount,
				@class.method_40
			},
			{
				@class.mainEditor_0.textBox_m_ulMonsterShapeID,
				@class.method_41
			},
			{
				@class.mainEditor_0.textBox_m_ulPremPanguLevelMax,
				@class.method_42
			},
			{
				@class.mainEditor_0.textBox_m_ulPremPanguLevelMin,
				@class.method_43
			},
			{
				@class.mainEditor_0.textBox_m_ulPremPanguLevelYear,
				@class.method_44
			},
			{
				@class.mainEditor_0.textBox_m_ulTransmitPointID,
				@class.method_45
			},
			{
				@class.mainEditor_0.textBox_m_iPanguEquipLevel,
				@class.method_46
			},
			{
				@class.mainEditor_0.textBox_m_iPanguEquipQuality,
				@class.method_47
			},
			{
				@class.mainEditor_0.textBox_m_iPanguEquipSlot,
				@class.method_48
			},
			{
				@class.mainEditor_0.textBox_m_iPanguEquipYear,
				@class.method_49
			},
			{
				@class.mainEditor_0.textBox_m_iPremYuMoLevelMin,
				@class.method_50
			},
			{
				@class.mainEditor_0.textBox_m_iPremYuMoLevelMax,
				@class.method_51
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulReachLevel,
				@class.method_52
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulReachReincarnationCount,
				@class.method_53
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulReachRealmLevel,
				@class.method_54
			},
			{
				@class.mainEditor_0.comboBox_m_uiEmotion,
				@class.method_55
			},
			{
				@class.mainEditor_0.textBox_GrowthTarget,
				@class.method_56
			},
			{
				@class.mainEditor_0.textBox_m_ulTMIconStateID,
				@class.method_57
			},
			{
				@class.mainEditor_0.textBox_TMIconStateDescID,
				@class.method_58
			},
			{
				@class.mainEditor_0.comboBox_m_ulTMHomeLevelType,
				@class.method_59
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulTMReachHomeLevel,
				@class.method_60
			},
			{
				@class.mainEditor_0.textBox_TMBindCarrierId,
				@class.method_61
			},
			{
				@class.mainEditor_0.textBox_m_ulTMReachHomeFlourish,
				@class.method_62
			},
			{
				@class.mainEditor_0.textBox_TMReachArenaTime,
				@class.method_63
			},
			{
				@class.mainEditor_0.textBox_ReachArenaWinCount,
				@class.method_64
			},
			{
				@class.mainEditor_0.comboBox_TMTinyGameType,
				@class.method_65
			},
			{
				@class.mainEditor_0.checkBox_DeliverByUI,
				@class.method_66
			},
			{
				@class.mainEditor_0.checkBox_WarTaskAward,
				@class.method_67
			},
			{
				@class.mainEditor_0.checkBox_HideOtherPlayer,
				@class.method_68
			},
			{
				@class.mainEditor_0.textBox_HideOtherPlayerTime,
				@class.method_69
			},
			{
				@class.mainEditor_0.checkBox_PropMonsterSummoned_m_bRandChoose,
				@class.method_70
			},
			{
				@class.mainEditor_0.textBox_PropMonsterSummoned_m_ulSummonRadius,
				@class.method_71
			},
			{
				@class.mainEditor_0.checkBox_PropMonsterSummoned_m_bDeathDisappear,
				@class.method_72
			}
		};
		if (dictionary.TryGetValue(@class.control_0, out var value))
		{
			value();
			return true;
		}
		return false;
	}

	private static bool smethod_5(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, ATaskTempl ataskTempl_0, Control control_0, object object_0)
	{
		if (control_0 == mainEditor_0.comboBox_m_ulAwardType_S_m_ulAwardType_F)
		{
			if (mainEditor_0.radioButton_AwardSuccess.Checked)
			{
				ataskTempl_0.m_ulAwardType_S = smethod_15(mainEditor_0, ataskTempl_0.m_ulAwardType_S, object_0);
			}
			else
			{
				ataskTempl_0.m_ulAwardType_F = smethod_15(mainEditor_0, ataskTempl_0.m_ulAwardType_F, object_0);
			}
			mainEditor_0.CalculationExpAndSPDependingOnLvlAndNum(null, null);
			mainEditor_0.ShowHide();
			return true;
		}
		return smethod_6(mainEditor_0, ataskTempl_0, control_0, object_0);
	}

	private static bool smethod_6(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, ATaskTempl ataskTempl_0, Control control_0, object object_0)
	{
		Class391 @class = new Class391();
		@class.ataskTempl_0 = ataskTempl_0;
		@class.mainEditor_0 = mainEditor_0;
		@class.object_0 = object_0;
		@class.control_0 = control_0;
		Dictionary<Control, Action> dictionary = new Dictionary<Control, Action>
		{
			{
				@class.mainEditor_0.checkBox_m_bShowByItems,
				@class.method_0
			},
			{
				@class.mainEditor_0.checkBox_m_bPremItemsAnyOne,
				@class.method_1
			},
			{
				@class.mainEditor_0.checkBox_NotOpenWithItem,
				@class.method_2
			},
			{
				@class.mainEditor_0.textBox_m_ulGivenCmnCount,
				@class.method_3
			},
			{
				@class.mainEditor_0.textBox_m_ulGivenTskCount,
				@class.method_4
			},
			{
				@class.mainEditor_0.textBox_m_ulPremise_Deposit,
				@class.method_5
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByDeposit,
				@class.method_6
			},
			{
				@class.mainEditor_0.textBox_m_lPremise_Reputation,
				@class.method_7
			},
			{
				@class.mainEditor_0.textBox_m_lPremise_RepuMax,
				@class.method_8
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByRepu,
				@class.method_9
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByPreTask,
				@class.method_10
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulPremise_Task_Least_Num,
				@class.method_11
			},
			{
				@class.mainEditor_0.comboBox_m_ulPremise_Period,
				@class.method_12
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByPeriod,
				@class.method_13
			},
			{
				@class.mainEditor_0.checkBox_m_ulPremise_Faction,
				@class.method_14
			},
			{
				@class.mainEditor_0.comboBox_m_iPremise_FactionRole,
				@class.method_15
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByFaction,
				@class.method_16
			},
			{
				@class.mainEditor_0.comboBox_m_ulGender,
				@class.method_17
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByGender,
				@class.method_18
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByOccup,
				@class.method_19
			},
			{
				@class.mainEditor_0.checkBox_m_bPremise_Spouse,
				@class.method_20
			},
			{
				@class.mainEditor_0.checkBox_m_bShowBySpouse,
				@class.method_21
			},
			{
				@class.mainEditor_0.checkBox_m_bPremiseWeddingOwner,
				@class.method_22
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByWeddingOwner,
				@class.method_23
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByRMB,
				@class.method_24
			},
			{
				@class.mainEditor_0.textBox_m_ulPremRMBMin,
				@class.method_25
			},
			{
				@class.mainEditor_0.textBox_m_ulPremRMBMax,
				@class.method_26
			},
			{
				@class.mainEditor_0.checkBox_m_bCharTime,
				@class.method_27
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByCharTime,
				@class.method_28
			},
			{
				@class.mainEditor_0.comboBox_m_iCharStartTime,
				@class.method_29
			},
			{
				@class.mainEditor_0.comboBox_m_iCharEndTime,
				@class.method_30
			},
			{
				@class.mainEditor_0.dateTimePicker_m_tmCharEndTime,
				@class.method_31
			},
			{
				@class.mainEditor_0.numericUpDown_m_ulCharTimeGreaterThan,
				@class.method_32
			},
			{
				@class.mainEditor_0.comboBox_PremiseCotaskSpace,
				@class.method_33
			},
			{
				@class.mainEditor_0.textBox_m_ulPremise_Cotask,
				@class.method_34
			},
			{
				@class.mainEditor_0.comboBox_m_ulCoTaskCond,
				@class.method_35
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByTeam,
				@class.method_36
			},
			{
				@class.mainEditor_0.checkBox_m_bPremNeedComp,
				@class.method_37
			},
			{
				@class.mainEditor_0.comboBox_m_nPremExp1AndOrExp2,
				@class.method_38
			},
			{
				@class.mainEditor_0.checkBox_PremNeedCompPerson,
				@class.method_39
			},
			{
				@class.mainEditor_0.comboBox_PremPersonExp1AndOrExp2,
				@class.method_40
			},
			{
				@class.mainEditor_0.checkBox_PremNeedCompHistory,
				@class.method_41
			},
			{
				@class.mainEditor_0.comboBox_PremHistoryExp1AndOrExp2,
				@class.method_42
			},
			{
				@class.mainEditor_0.checkBox_m_bIsLibraryTask,
				@class.method_43
			},
			{
				@class.mainEditor_0.textBox_m_fLibraryTasksProbability,
				@class.method_44
			},
			{
				@class.mainEditor_0.checkBox_m_bIsUniqueStorageTask,
				@class.method_45
			},
			{
				@class.mainEditor_0.textBox_m_iWorldContribution,
				@class.method_46
			},
			{
				@class.mainEditor_0.checkBox_WriteSpecialLog,
				@class.method_47
			},
			{
				@class.mainEditor_0.checkBox_m_bPremCheckForce,
				@class.method_48
			},
			{
				@class.mainEditor_0.textBox_m_iPremForce,
				@class.method_49
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByForce,
				@class.method_50
			},
			{
				@class.mainEditor_0.textBox_m_iPremForceReputation,
				@class.method_51
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByForceReputation,
				@class.method_52
			},
			{
				@class.mainEditor_0.textBox_m_iPremForceContribution,
				@class.method_53
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByForceContribution,
				@class.method_54
			},
			{
				@class.mainEditor_0.textBox_m_iPremForceExp,
				@class.method_55
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByForceExp,
				@class.method_56
			},
			{
				@class.mainEditor_0.textBox_m_iPremForceSP,
				@class.method_57
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByForceSP,
				@class.method_58
			},
			{
				@class.mainEditor_0.textBox_m_iPremForceActivityLevel,
				@class.method_59
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByForceActivityLevel,
				@class.method_60
			},
			{
				@class.mainEditor_0.checkBox_m_bPremIsKing,
				@class.method_61
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByKing,
				@class.method_62
			},
			{
				@class.mainEditor_0.checkBox_m_bPremNotInTeam,
				@class.method_63
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByNotInTeam,
				@class.method_64
			},
			{
				@class.mainEditor_0.textBox_m_iPremTitleNumRequired,
				@class.method_65
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByTitle,
				@class.method_66
			},
			{
				@class.mainEditor_0.textBox_m_iPremHistoryStageIndex_1,
				@class.method_67
			},
			{
				@class.mainEditor_0.textBox_m_iPremHistoryStageIndex_2,
				@class.method_68
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByHistoryStage,
				@class.method_69
			},
			{
				@class.mainEditor_0.textBox_m_ulPremGeneralCardCount,
				@class.method_70
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByGeneralCard,
				@class.method_71
			},
			{
				@class.mainEditor_0.comboBox_m_iPremGeneralCardRank,
				@class.method_72
			},
			{
				@class.mainEditor_0.textBox_m_ulPremGeneralCardRankCount,
				@class.method_73
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByGeneralCardRank,
				@class.method_74
			},
			{
				@class.mainEditor_0.textBox_m_ulPremIconStateID,
				@class.method_75
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByIconStateID,
				@class.method_76
			},
			{
				@class.mainEditor_0.textBox_m_iVIPLevelMin,
				@class.method_77
			},
			{
				@class.mainEditor_0.textBox_m_iVIPLevelMax,
				@class.method_78
			},
			{
				@class.mainEditor_0.textBox_m_ulFailIconStateID,
				@class.method_79
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByVIPLevel,
				@class.method_80
			},
			{
				@class.mainEditor_0.checkBox_PremNoHome,
				@class.method_81
			},
			{
				@class.mainEditor_0.numericUpDown_m_iPremHomeLevelMin,
				@class.method_82
			},
			{
				@class.mainEditor_0.numericUpDown_m_iPremHomeLevelMax,
				@class.method_83
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByHomeLevel,
				@class.method_84
			},
			{
				@class.mainEditor_0.numericUpDown_m_iPremHomeResourceLevelMin,
				@class.method_85
			},
			{
				@class.mainEditor_0.numericUpDown_m_iPremHomeResourceLevelMax,
				@class.method_86
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByHomeResourceLevel,
				@class.method_87
			},
			{
				@class.mainEditor_0.comboBox_m_iPremHomeFactoryLevelType,
				@class.method_88
			},
			{
				@class.mainEditor_0.numericUpDown_m_iPremHomeFactoryLevelMin,
				@class.method_89
			},
			{
				@class.mainEditor_0.numericUpDown_m_iPremHomeFactoryLevelMax,
				@class.method_90
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByHomeFactoryLevel,
				@class.method_91
			},
			{
				@class.mainEditor_0.textBox_m_iPremHomeFlourishMin,
				@class.method_92
			},
			{
				@class.mainEditor_0.textBox_m_iPremHomeFlourishMax,
				@class.method_93
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByHomeFlourish,
				@class.method_94
			},
			{
				@class.mainEditor_0.checkBox_m_bPremHomeStorageTask,
				@class.method_95
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByHomeStorageTask,
				@class.method_96
			},
			{
				@class.mainEditor_0.textBox_ArenaWinCount,
				@class.method_97
			},
			{
				@class.mainEditor_0.checkBox_PreReachArenaWinCount,
				@class.method_98
			},
			{
				@class.mainEditor_0.checkBox_ShowByReachArenaWinCount,
				@class.method_99
			},
			{
				@class.mainEditor_0.checkBox_ByFactionScore,
				@class.method_100
			},
			{
				@class.mainEditor_0.textBox_PreFactionScore,
				@class.method_101
			},
			{
				@class.mainEditor_0.checkBox_ShowByPreFactionScore,
				@class.method_102
			},
			{
				@class.mainEditor_0.textBox_PreFactionMoney,
				@class.method_103
			},
			{
				@class.mainEditor_0.checkBox_ShowByPreFactionMoney,
				@class.method_104
			},
			{
				@class.mainEditor_0.textBox_PreFactionPersonScore,
				@class.method_105
			},
			{
				@class.mainEditor_0.checkBox_ShowByPreFactionPersonScore,
				@class.method_106
			},
			{
				@class.mainEditor_0.checkBox_BecomeMentor,
				@class.method_107
			},
			{
				@class.mainEditor_0.textBox_PremMentorMorality,
				@class.method_108
			},
			{
				@class.mainEditor_0.checkBox_ShowMentorMorality,
				@class.method_109
			},
			{
				@class.mainEditor_0.textBox_PremMentorStudent,
				@class.method_110
			},
			{
				@class.mainEditor_0.checkBox_ShowMentorStudent,
				@class.method_111
			},
			{
				@class.mainEditor_0.textBox_PremCoupleIntimacy,
				@class.method_112
			},
			{
				@class.mainEditor_0.checkBox_ShowCoupleIntimacy,
				@class.method_113
			},
			{
				@class.mainEditor_0.textBox_m_ulPremise_Deposit2,
				@class.method_114
			},
			{
				@class.mainEditor_0.checkBox_m_bShowByDeposit2,
				@class.method_115
			},
			{
				@class.mainEditor_0.numericUpDown_NeededTaskLeast,
				@class.method_116
			},
			{
				@class.mainEditor_0.checkBox_ShowCamp,
				@class.method_117
			},
			{
				@class.mainEditor_0.textBox_PremCampPower,
				@class.method_118
			},
			{
				@class.mainEditor_0.comboBox_PremCamp,
				@class.method_119
			},
			{
				@class.mainEditor_0.checkBox_ShowCampPower,
				@class.method_120
			},
			{
				@class.mainEditor_0.checkBox_ReturnCampPower,
				@class.method_121
			},
			{
				@class.mainEditor_0.textBox_NeedFriendPoint,
				@class.method_122
			},
			{
				@class.mainEditor_0.checkBox_ShowNeedFriendPoint,
				@class.method_123
			},
			{
				@class.mainEditor_0.checkBox_PremRank,
				@class.method_124
			},
			{
				@class.mainEditor_0.comboBox_RankType,
				@class.method_125
			},
			{
				@class.mainEditor_0.textBox_RankGradeMin,
				@class.method_126
			},
			{
				@class.mainEditor_0.textBox_RankGradeMax,
				@class.method_127
			}
		};
		if (dictionary.TryGetValue(@class.control_0, out var value))
		{
			value();
			return true;
		}
		return false;
	}

	[CLSCompliant(false)]
	public static void SpecialParameters(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, in SPECIAL_PARAMETERS special_PARAMETERS_0, object object_0)
	{
		if (special_PARAMETERS_0 == null || ACE.sTASKedit.MainEditor.MainEditor.LockedChange || ACE.sTASKedit.MainEditor.MainEditor.Selecting || ACE.sTASKedit.MainEditor.MainEditor.SelectingSpecialParameters)
		{
			return;
		}
		try
		{
			if ((Control)object_0 == mainEditor_0.textBox_SpecialParameters_FailWhenGetOffCarrier)
			{
				special_PARAMETERS_0.FailWhenGetOffCarrier = smethod_13(mainEditor_0, special_PARAMETERS_0.FailWhenGetOffCarrier, object_0, 0);
			}
			if ((Control)object_0 == mainEditor_0.textBox_SpecialParameters_GetOffCarrierID)
			{
				special_PARAMETERS_0.GetOffCarrierID = smethod_13(mainEditor_0, special_PARAMETERS_0.GetOffCarrierID, object_0, 0);
			}
			if ((Control)object_0 == mainEditor_0.textBox_SpecialParameters_TimeWhenRideCarrier)
			{
				special_PARAMETERS_0.TimeWhenRideCarrier = smethod_13(mainEditor_0, special_PARAMETERS_0.TimeWhenRideCarrier, object_0, 0);
			}
			if ((Control)object_0 == mainEditor_0.textBox_SpecialParameters_RideCarrierID)
			{
				special_PARAMETERS_0.RideCarrierID = smethod_13(mainEditor_0, special_PARAMETERS_0.RideCarrierID, object_0, 0);
			}
			if ((Control)object_0 == mainEditor_0.textBox_SpecialParameters_UseItemTimes)
			{
				special_PARAMETERS_0.UseItemTimes = smethod_13(mainEditor_0, special_PARAMETERS_0.UseItemTimes, object_0, 2);
			}
			if ((Control)object_0 == mainEditor_0.textBox_SpecialParameters_CompleteTaskTimes)
			{
				special_PARAMETERS_0.CompleteTaskTimes = smethod_13(mainEditor_0, special_PARAMETERS_0.CompleteTaskTimes, object_0, 2);
			}
			if ((Control)object_0 == mainEditor_0.textBox_SpecialParameters_Parameter9)
			{
				special_PARAMETERS_0.Parameter9 = smethod_13(mainEditor_0, special_PARAMETERS_0.Parameter9, object_0, 0);
			}
			if ((Control)object_0 == mainEditor_0.textBox_SpecialParameters_need_story_book_collection)
			{
				special_PARAMETERS_0.need_story_book_collection = smethod_13(mainEditor_0, special_PARAMETERS_0.need_story_book_collection, object_0, 0);
			}
			if ((Control)object_0 == mainEditor_0.textBox_SpecialParameters_story_book_collection_count)
			{
				special_PARAMETERS_0.story_book_collection_count = smethod_13(mainEditor_0, special_PARAMETERS_0.story_book_collection_count, object_0, 2);
			}
		}
		catch
		{
			DKBox.Show(GProD.TX(403), string.Empty);
		}
	}

	[CLSCompliant(false)]
	public static void Award(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, ref AWARD_DATA award, object object_0)
	{
		Class389 @class = new Class389();
		@class.mainEditor_0 = mainEditor_0;
		@class.object_0 = object_0;
		if (award == null || ACE.sTASKedit.MainEditor.MainEditor.LockedChange || ACE.sTASKedit.MainEditor.MainEditor.Selecting || ACE.sTASKedit.MainEditor.MainEditor.SelectingAward)
		{
			return;
		}
		try
		{
			@class.control_0 = (Control)@class.object_0;
			@class.award_DATA_0 = award;
			Dictionary<Control, Action> dictionary = new Dictionary<Control, Action>
			{
				{
					@class.mainEditor_0.textBox_Award_m_ulGoldNum,
					@class.method_0
				},
				{
					@class.mainEditor_0.numericUpDown_Award_m_uiGroupNum,
					@class.method_1
				},
				{
					@class.mainEditor_0.numericUpDown_Award_m_uiNumPerGroup,
					@class.method_2
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulExp,
					@class.method_3
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulRealmExp,
					@class.method_4
				},
				{
					@class.mainEditor_0.checkBox_Award_m_bExpandRealmLevelMax,
					@class.method_5
				},
				{
					@class.mainEditor_0.comboBox_Award_NewTaskSpace,
					@class.method_6
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulNewTask,
					@class.method_7
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulSP,
					@class.method_8
				},
				{
					@class.mainEditor_0.textBox_Award_m_lReputation,
					@class.method_9
				},
				{
					@class.mainEditor_0.comboBox_Award_m_ulNewPeriod,
					@class.method_10
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulNewRelayStation,
					@class.method_11
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulStorehouseSize,
					@class.method_12
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulStorehouseSize2,
					@class.method_13
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulStorehouseSize3,
					@class.method_14
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulStorehouseSize4,
					@class.method_15
				},
				{
					@class.mainEditor_0.textBox_Award_m_lInventorySize,
					@class.method_16
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulPetInventorySize,
					@class.method_17
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulFuryULimit,
					@class.method_18
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulTransWldId,
					@class.method_19
				},
				{
					@class.mainEditor_0.textBox_Award_CrossServerID,
					@class.method_20
				},
				{
					@class.mainEditor_0.textBox_Award_m_TransPt_v_1,
					@class.method_21
				},
				{
					@class.mainEditor_0.textBox_Award_m_TransPt_v_2,
					@class.method_22
				},
				{
					@class.mainEditor_0.textBox_Award_m_TransPt_v_3,
					@class.method_23
				},
				{
					@class.mainEditor_0.textBox_Award_m_lMonsCtrl,
					@class.method_24
				},
				{
					@class.mainEditor_0.checkBox_Award_m_bTrigCtrl,
					@class.method_25
				},
				{
					@class.mainEditor_0.checkBox_Award_m_bUseLevCo,
					@class.method_26
				},
				{
					@class.mainEditor_0.checkBox_Award_m_bDivorce,
					@class.method_27
				},
				{
					@class.mainEditor_0.checkBox_Award_m_bSendMsg,
					@class.method_28
				},
				{
					@class.mainEditor_0.comboBox_Award_m_nMsgChannel,
					@class.method_29
				},
				{
					@class.mainEditor_0.checkBox_Award_m_SummonedMonsters_m_bRandChoose,
					@class.method_30
				},
				{
					@class.mainEditor_0.textBox_Award_m_SummonedMonsters_m_ulSummonRadius,
					@class.method_31
				},
				{
					@class.mainEditor_0.checkBox_Award_m_SummonedMonsters_m_bDeathDisappear,
					@class.method_32
				},
				{
					@class.mainEditor_0.checkBox_Award_m_bAwardDeath,
					@class.method_33
				},
				{
					@class.mainEditor_0.checkBox_Award_m_bAwardDeathWithLoss,
					@class.method_34
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulDividend,
					@class.method_35
				},
				{
					@class.mainEditor_0.checkBox_Award_m_bAwardSkill,
					@class.method_36
				},
				{
					@class.mainEditor_0.textBox_Award_m_iAwardSkillID,
					@class.method_37
				},
				{
					@class.mainEditor_0.numericUpDown_Award_m_iAwardSkillLevel,
					@class.method_38
				},
				{
					@class.mainEditor_0.textBox_Award_m_iSoloTowerChallengeScore,
					@class.method_39
				},
				{
					@class.mainEditor_0.comboBox_Award_AwardOpenSystem,
					@class.method_40
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulSpecifyContribTaskID,
					@class.method_41
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulSpecifyContribSubTaskID,
					@class.method_42
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulSpecifyContrib,
					@class.method_43
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulContrib,
					@class.method_44
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulRandContrib,
					@class.method_45
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulLowestcontrib,
					@class.method_46
				},
				{
					@class.mainEditor_0.textBox_Award_m_iFactionContrib,
					@class.method_47
				},
				{
					@class.mainEditor_0.textBox_Award_m_iFactionExpContrib,
					@class.method_48
				},
				{
					@class.mainEditor_0.checkBox_Award_m_PQRankingAward_m_bAwardByProf,
					@class.method_49
				},
				{
					@class.mainEditor_0.checkBox_Award_m_bMulti,
					@class.method_50
				},
				{
					@class.mainEditor_0.comboBox_Award_m_nNumType,
					@class.method_51
				},
				{
					@class.mainEditor_0.textBox_Award_m_lNum,
					@class.method_52
				},
				{
					@class.mainEditor_0.textBox_Award_m_iForceContribution,
					@class.method_53
				},
				{
					@class.mainEditor_0.textBox_Award_m_iForceReputation,
					@class.method_54
				},
				{
					@class.mainEditor_0.textBox_Award_m_iForceActivity,
					@class.method_55
				},
				{
					@class.mainEditor_0.textBox_Award_m_iForceSetRepu,
					@class.method_56
				},
				{
					@class.mainEditor_0.textBox_Award_m_iTaskLimit,
					@class.method_57
				},
				{
					@class.mainEditor_0.textBox_Award_m_iLeaderShip,
					@class.method_58
				},
				{
					@class.mainEditor_0.textBox_Award_m_iWorldContribution,
					@class.method_59
				},
				{
					@class.mainEditor_0.textBox_Award_m_iHomeResource_1,
					@class.method_60
				},
				{
					@class.mainEditor_0.textBox_Award_m_iHomeResource_2,
					@class.method_61
				},
				{
					@class.mainEditor_0.textBox_Award_m_iHomeResource_3,
					@class.method_62
				},
				{
					@class.mainEditor_0.textBox_Award_m_iHomeResource_4,
					@class.method_63
				},
				{
					@class.mainEditor_0.textBox_Award_m_iHomeResource_5,
					@class.method_64
				},
				{
					@class.mainEditor_0.checkBox_Award_m_bCreateHome,
					@class.method_65
				},
				{
					@class.mainEditor_0.checkBox_Award_AwardLeaveCarrier,
					@class.method_66
				},
				{
					@class.mainEditor_0.textBox_Award_AwardFactionMoney,
					@class.method_67
				},
				{
					@class.mainEditor_0.textBox_Award_AwardFactionPersonScore,
					@class.method_68
				},
				{
					@class.mainEditor_0.checkBox_Award_SubmitRankScore,
					@class.method_69
				},
				{
					@class.mainEditor_0.comboBox_Award_submit_rank_Param1,
					@class.method_70
				},
				{
					@class.mainEditor_0.comboBox_Award_submit_rank_Param2,
					@class.method_71
				},
				{
					@class.mainEditor_0.textBox_Award_submit_rank_Param3,
					@class.method_72
				},
				{
					@class.mainEditor_0.textBox_Award_AwardMentorStudent,
					@class.method_73
				},
				{
					@class.mainEditor_0.textBox_Award_AwardCoupleIntimacy,
					@class.method_74
				},
				{
					@class.mainEditor_0.textBox_Award_AwardRedBookExp,
					@class.method_75
				},
				{
					@class.mainEditor_0.textBox_Award_AwardCampScore,
					@class.method_76
				},
				{
					@class.mainEditor_0.textBox_Award_AwardCrossServerMoney,
					@class.method_77
				},
				{
					@class.mainEditor_0.checkBox_Award_m_iAwardRedBookKey,
					@class.method_78
				},
				{
					@class.mainEditor_0.textBox_Award_AwardRedBookKeyCount,
					@class.method_79
				},
				{
					@class.mainEditor_0.textBox_Award_AwardRedBookKeyType,
					@class.method_80
				},
				{
					@class.mainEditor_0.textBox_Award_m_ulPanguExpYear,
					@class.method_81
				},
				{
					@class.mainEditor_0.textBox_Award_AwardPanguExp,
					@class.method_82
				},
				{
					@class.mainEditor_0.textBox_Award_AwardFactionAwardConfig,
					@class.method_83
				},
				{
					@class.mainEditor_0.textBox_Award_AwardNewPlayerEvent,
					@class.method_84
				},
				{
					@class.mainEditor_0.textBox_Award_RepairShentongSearchBug,
					@class.method_85
				},
				{
					@class.mainEditor_0.textBox_Award_InviterAward,
					@class.method_86
				},
				{
					@class.mainEditor_0.textBox_Award_AwardFriendPoint,
					@class.method_87
				},
				{
					@class.mainEditor_0.textBox_Award_InviterAwardCount,
					@class.method_88
				},
				{
					@class.mainEditor_0.textBox_Award_AwardPerceptionValue,
					@class.method_89
				},
				{
					@class.mainEditor_0.textBox_Award_m_iAwardCameraMovementID,
					@class.method_90
				}
			};
			if (dictionary.TryGetValue(@class.control_0, out var value))
			{
				value();
			}
		}
		catch
		{
			DKBox.Show(GProD.TX(403), string.Empty);
		}
	}

	private static bool smethod_7(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, bool bool_0, object object_0)
	{
		bool flag = ((CheckBox)object_0).Checked;
		if (bool_0 != flag)
		{
			bool_0 = flag;
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return bool_0;
	}

	private static byte smethod_8(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, byte byte_0, object object_0)
	{
		byte b = Convert.ToByte(((TextBox)object_0).Text);
		if (byte_0 != b)
		{
			byte_0 = b;
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return byte_0;
	}

	private static byte smethod_9(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, byte byte_0, object object_0)
	{
		byte b = Convert.ToByte(((NumericUpDown)object_0).Value);
		if (byte_0 != b)
		{
			byte_0 = b;
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return byte_0;
	}

	private static byte smethod_10(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, byte byte_0, object object_0)
	{
		byte b = Convert.ToByte(((ComboBox)object_0).SelectedIndex);
		if (byte_0 != b)
		{
			byte_0 = b;
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return byte_0;
	}

	private static short smethod_11(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, short short_0, object object_0, int int_0)
	{
		short num = 0;
		num = ((int_0 != 1) ? ((short)mConvert.DigitNumberToInt32(((TextBox)object_0).Text)) : ((short)mConvert.StringToSeconds(((TextBox)object_0).Text)));
		if (short_0 != num)
		{
			short_0 = num;
			switch (int_0)
			{
			case 1:
				((TextBox)object_0).Text = mConvert.SecondsToString(short_0);
				break;
			case 2:
				((TextBox)object_0).Text = mConvert.Int32ToString(short_0);
				break;
			case 3:
				((TextBox)object_0).Text = mConvert.Int32ToSilver(short_0);
				break;
			}
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return short_0;
	}

	private static short smethod_12(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, short short_0, object object_0)
	{
		short num = Convert.ToInt16(((ComboBox)object_0).SelectedIndex);
		if (short_0 != num)
		{
			short_0 = num;
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return short_0;
	}

	private static int smethod_13(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int int_0, object object_0, int int_1)
	{
		int num = 0;
		num = ((int_1 != 1) ? mConvert.DigitNumberToInt32(((TextBox)object_0).Text) : mConvert.StringToSeconds(((TextBox)object_0).Text));
		if (int_0 != num)
		{
			int_0 = num;
			switch (int_1)
			{
			case 1:
				((TextBox)object_0).Text = mConvert.SecondsToString(int_0);
				break;
			case 2:
				((TextBox)object_0).Text = mConvert.Int32ToString(int_0);
				break;
			case 3:
				((TextBox)object_0).Text = mConvert.Int32ToSilver(int_0);
				break;
			}
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return int_0;
	}

	private static int smethod_14(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int int_0, object object_0)
	{
		int num = Convert.ToInt32(((NumericUpDown)object_0).Value);
		if (int_0 != num)
		{
			int_0 = num;
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return int_0;
	}

	private static int smethod_15(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int int_0, object object_0)
	{
		int selectedIndex = ((ComboBox)object_0).SelectedIndex;
		if (int_0 != selectedIndex)
		{
			int_0 = selectedIndex;
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return int_0;
	}

	private static int smethod_16(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int int_0, object object_0, int int_1)
	{
		int num = 0;
		num = ((int_1 != 1) ? mConvert.DigitNumberToUInt32(((TextBox)object_0).Text) : mConvert.StringToSeconds(((TextBox)object_0).Text));
		if (int_0 != num)
		{
			int_0 = num;
			switch (int_1)
			{
			case 1:
				((TextBox)object_0).Text = mConvert.SecondsToString(int_0);
				break;
			case 2:
				((TextBox)object_0).Text = mConvert.UInt32ToString(int_0);
				break;
			case 3:
				((TextBox)object_0).Text = mConvert.UInt32ToSilver(int_0);
				break;
			}
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return int_0;
	}

	private static float smethod_17(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, float float_0, object object_0, int int_0)
	{
		float result = 0f;
		if (int_0 == 1)
		{
			result = ((!mConvert.TryParseSingle(((TextBox)object_0).Text, out var result2)) ? float_0 : (Settings.Fields.EnableShowPercents ? (result2 * 0.01f) : result2));
		}
		else if (!mConvert.TryParseSingle(((TextBox)object_0).Text, out result))
		{
			result = float_0;
		}
		if (float_0 != result)
		{
			float_0 = result;
			if (int_0 == 1)
			{
				((TextBox)object_0).Text = result.ToString(GProD.ProbValueFormat);
			}
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return float_0;
	}

	private static task_tm smethod_18(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, task_tm task_tm_0, object object_0)
	{
		task_tm task_tm2 = new task_tm();
		task_tm2.year = ((DateTimePicker)object_0).Value.Year;
		task_tm2.month = ((DateTimePicker)object_0).Value.Month;
		task_tm2.day = ((DateTimePicker)object_0).Value.Day;
		task_tm2.hour = ((DateTimePicker)object_0).Value.Hour;
		task_tm2.min = ((DateTimePicker)object_0).Value.Minute;
		if (task_tm_0 != task_tm2)
		{
			task_tm_0 = task_tm2;
			mainEditor_0.TriggerDebug((Control)object_0);
		}
		return task_tm_0;
	}
}
