using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes;

internal class DetectUnknownValue
{
	private static string string_0 = Class16.smethod_0(1649273578);

	private static void smethod_0(int int_0, string string_1, int int_1)
	{
		if (int_1 != 0)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, string_1, int_1));
		}
	}

	public static void DetectUnknownValues(ATaskTempl[] tasks)
	{
		if (tasks == null)
		{
			return;
		}
		for (int i = 0; i < tasks.Length; i++)
		{
			smethod_2(tasks[i]);
			if (tasks[i].pSub.Length != 0)
			{
				DetectUnknownValues(tasks[i].pSub);
			}
		}
	}

	private static void smethod_1(ATaskTempl ataskTempl_0)
	{
		if (ataskTempl_0.m_plChangeKeyValue2 != null && ataskTempl_0.m_plChangeKeyValue2.Length != 0)
		{
			for (int i = 0; i < ataskTempl_0.m_plChangeKeyValue2.Length; i++)
			{
				smethod_0(ataskTempl_0.m_ID, Class16.smethod_0(1649273638) + i + Class16.smethod_0(1649008474), ataskTempl_0.m_plChangeKeyValue2[i]);
			}
		}
		if (ataskTempl_0.m_plPersonChangeKeyValue2 != null && ataskTempl_0.m_plPersonChangeKeyValue2.Length != 0)
		{
			for (int j = 0; j < ataskTempl_0.m_plPersonChangeKeyValue2.Length; j++)
			{
				smethod_0(ataskTempl_0.m_ID, Class16.smethod_0(1649273657) + j + Class16.smethod_0(1649008474), ataskTempl_0.m_plPersonChangeKeyValue2[j]);
			}
		}
		if (ataskTempl_0.m_plHistoryChangeKeyValue2 != null && ataskTempl_0.m_plHistoryChangeKeyValue2.Length != 0)
		{
			for (int k = 0; k < ataskTempl_0.m_plHistoryChangeKeyValue2.Length; k++)
			{
				smethod_0(ataskTempl_0.m_ID, Class16.smethod_0(1649273690) + k + Class16.smethod_0(1649008474), ataskTempl_0.m_plHistoryChangeKeyValue2[k]);
			}
		}
	}

	private static void smethod_2(ATaskTempl ataskTempl_0)
	{
		if (ataskTempl_0.m_ulTimetable > 24)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273732), ataskTempl_0.m_ulTimetable));
		}
		if (ataskTempl_0.m_ulDelvRegionCnt > 16)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273744), ataskTempl_0.m_ulDelvRegionCnt));
		}
		if (ataskTempl_0.m_ulEnterRegionCnt > 16)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273768), ataskTempl_0.m_ulEnterRegionCnt));
		}
		if (ataskTempl_0.m_ulLeaveRegionCnt > 16)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273793), ataskTempl_0.m_ulLeaveRegionCnt));
		}
		if (ataskTempl_0.m_ulChangeKeyCnt > 255)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273818), ataskTempl_0.m_ulChangeKeyCnt));
		}
		if (ataskTempl_0.m_ulChangePersonKeyCnt > 255)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273841), ataskTempl_0.m_ulChangePersonKeyCnt));
		}
		if (ataskTempl_0.m_ulChangeHistoryKeyCnt > 255)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649272854), ataskTempl_0.m_ulChangeHistoryKeyCnt));
		}
		smethod_1(ataskTempl_0);
		if (ataskTempl_0.m_ulPQExpCnt > 32)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649272884), ataskTempl_0.m_ulPQExpCnt));
		}
		if (ataskTempl_0.m_ulMonsterContribCnt > 100)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649272903), ataskTempl_0.m_ulMonsterContribCnt));
		}
		if (ataskTempl_0.m_ulPremItems > 30)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649272923), ataskTempl_0.m_ulPremItems));
		}
		if (ataskTempl_0.m_ulGivenItems > 30)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649272951), ataskTempl_0.m_ulGivenItems));
		}
		if (ataskTempl_0.m_ulTeamMemsWanted > 18)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649272972), ataskTempl_0.m_ulTeamMemsWanted));
		}
		if (ataskTempl_0.m_iPremTitleNumTotal > 999)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649272997), ataskTempl_0.m_iPremTitleNumTotal));
		}
		if (ataskTempl_0.m_ulPlayerWanted > 6)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273016), ataskTempl_0.m_ulPlayerWanted));
		}
		if (ataskTempl_0.m_ulMonsterWanted > 6)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273047), ataskTempl_0.m_ulMonsterWanted));
		}
		if ((long)ataskTempl_0.m_ulMonsterUnwanted > 6L)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273071), ataskTempl_0.m_ulMonsterUnwanted));
		}
		if (ataskTempl_0.m_ulItemsWanted > 30)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273089), ataskTempl_0.m_ulItemsWanted));
		}
		if (ataskTempl_0.m_ulExpCnt > 32)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273119), ataskTempl_0.m_ulExpCnt));
		}
		if (ataskTempl_0.m_ulPersonExpCnt > 32)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273128), ataskTempl_0.m_ulPersonExpCnt));
		}
		if (ataskTempl_0.m_ulHistoryExpCnt > 32)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273159), ataskTempl_0.m_ulHistoryExpCnt));
		}
		if (ataskTempl_0.m_ulTaskCharCnt > 32)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273183), ataskTempl_0.m_ulTaskCharCnt));
		}
		if (ataskTempl_0.m_ulPersonTaskCharCnt > 32)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273205), ataskTempl_0.m_ulPersonTaskCharCnt));
		}
		if (ataskTempl_0.m_ulHistoryTaskCharCnt > 32)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273225), ataskTempl_0.m_ulHistoryTaskCharCnt));
		}
		if (ataskTempl_0.m_ulReachSiteCnt > 16)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273262), ataskTempl_0.m_ulReachSiteCnt));
		}
		if (ataskTempl_0.m_ulLeaveSiteCnt > 16)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273793), ataskTempl_0.m_ulLeaveSiteCnt));
		}
		if (ataskTempl_0.m_usIDSpace > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273285), ataskTempl_0.m_usIDSpace));
		}
		if (ataskTempl_0.m_ulType < 0 || ataskTempl_0.m_ulType > 113)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273303), ataskTempl_0.m_ulType));
		}
		if (ataskTempl_0.m_tmAbsFailTime.wday < 0 || ataskTempl_0.m_tmAbsFailTime.wday > 7)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273318), ataskTempl_0.m_tmAbsFailTime.wday));
		}
		if (ataskTempl_0.m_tmNextFailTime.year > 0)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649273337), ataskTempl_0.m_tmNextFailTime.year));
		}
		if (ataskTempl_0.m_tmNextFailTime.wday > 8)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268253), ataskTempl_0.m_tmNextFailTime.wday));
		}
		for (int i = 0; i < ataskTempl_0.m_tmType.Length; i++)
		{
			if (ataskTempl_0.m_tmType[i] < 0 || ataskTempl_0.m_tmType[i] > 3)
			{
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268273) + i + Class16.smethod_0(1649008474), ataskTempl_0.m_tmType[i]));
			}
		}
		for (int j = 0; j < ataskTempl_0.m_tmStart.Length; j++)
		{
			if (ataskTempl_0.m_tmStart[j].wday < 0 || ataskTempl_0.m_tmStart[j].wday > 7)
			{
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268289) + j + Class16.smethod_0(1649268306), ataskTempl_0.m_tmStart[j].wday));
			}
		}
		for (int k = 0; k < ataskTempl_0.m_tmEnd.Length; k++)
		{
			if (ataskTempl_0.m_tmEnd[k].wday < 0 || ataskTempl_0.m_tmEnd[k].wday > 7)
			{
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268327) + k + Class16.smethod_0(1649268306), ataskTempl_0.m_tmEnd[k].wday));
			}
		}
		if (ataskTempl_0.m_lAvailFrequency < 0 || ataskTempl_0.m_lAvailFrequency > 4)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268342), ataskTempl_0.m_lAvailFrequency));
		}
		if (ataskTempl_0.m_tmAvailFrequency.year > 0)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268366), ataskTempl_0.m_tmAvailFrequency.year));
		}
		if (ataskTempl_0.m_tmAvailFrequency.wday > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268396), ataskTempl_0.m_tmAvailFrequency.wday));
		}
		if (ataskTempl_0.m_ulChangeHistoryKeyCnt > 0)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649272854), ataskTempl_0.m_ulChangeHistoryKeyCnt));
		}
		if (ataskTempl_0.m_ulCrossServerId > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268418), ataskTempl_0.m_ulCrossServerId));
		}
		if (ataskTempl_0.m_bCrossServer)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268442), ataskTempl_0.m_bCrossServer));
		}
		if (ataskTempl_0.m_lHistoryKeyForAwardVar > 0)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268471), ataskTempl_0.m_lHistoryKeyForAwardVar));
		}
		if (ataskTempl_0.m_nPropExp1AndOrExp2 < 0 || ataskTempl_0.m_nPropExp1AndOrExp2 > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268502), ataskTempl_0.m_nPropExp1AndOrExp2));
		}
		if (ataskTempl_0.m_Prop1KeyValue.nLeftType < 0 || ataskTempl_0.m_Prop1KeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268521), ataskTempl_0.m_Prop1KeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Prop1KeyValue.nCompOper < 0 || ataskTempl_0.m_Prop1KeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268553), ataskTempl_0.m_Prop1KeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Prop1KeyValue.nRightType < 0 || ataskTempl_0.m_Prop1KeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268585), ataskTempl_0.m_Prop1KeyValue.nRightType));
		}
		if (ataskTempl_0.m_Prop2KeyValue.nLeftType < 0 || ataskTempl_0.m_Prop2KeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268618), ataskTempl_0.m_Prop2KeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Prop2KeyValue.nCompOper < 0 || ataskTempl_0.m_Prop2KeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268650), ataskTempl_0.m_Prop2KeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Prop2KeyValue.nRightType < 0 || ataskTempl_0.m_Prop2KeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268682), ataskTempl_0.m_Prop2KeyValue.nRightType));
		}
		if (ataskTempl_0.m_nPropExp1AndOrExp2_personal < 0 || ataskTempl_0.m_nPropExp1AndOrExp2_personal > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268715), ataskTempl_0.m_nPropExp1AndOrExp2_personal));
		}
		if (ataskTempl_0.m_Prop1KeyValue_personal.nLeftType < 0 || ataskTempl_0.m_Prop1KeyValue_personal.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267735), ataskTempl_0.m_Prop1KeyValue_personal.nLeftType));
		}
		if (ataskTempl_0.m_Prop1KeyValue_personal.nCompOper < 0 || ataskTempl_0.m_Prop1KeyValue_personal.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267768), ataskTempl_0.m_Prop1KeyValue_personal.nCompOper));
		}
		if (ataskTempl_0.m_Prop1KeyValue_personal.nRightType < 0 || ataskTempl_0.m_Prop1KeyValue_personal.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267809), ataskTempl_0.m_Prop1KeyValue_personal.nRightType));
		}
		if (ataskTempl_0.m_Prop2KeyValue_personal.nLeftType < 0 || ataskTempl_0.m_Prop2KeyValue_personal.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267851), ataskTempl_0.m_Prop2KeyValue_personal.nLeftType));
		}
		if (ataskTempl_0.m_Prop2KeyValue_personal.nCompOper < 0 || ataskTempl_0.m_Prop2KeyValue_personal.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267900), ataskTempl_0.m_Prop2KeyValue_personal.nCompOper));
		}
		if (ataskTempl_0.m_Prop2KeyValue_personal.nRightType < 0 || ataskTempl_0.m_Prop2KeyValue_personal.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267941), ataskTempl_0.m_Prop2KeyValue_personal.nRightType));
		}
		if (ataskTempl_0.m_iGfxType > 26)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267983), ataskTempl_0.m_iGfxType));
		}
		if ((ataskTempl_0.m_ucPremiseTransformedForm < 0 || ataskTempl_0.m_ucPremiseTransformedForm > 0) && (ataskTempl_0.m_ucPremiseTransformedForm < 128 || ataskTempl_0.m_ucPremiseTransformedForm > 128) && (ataskTempl_0.m_ucPremiseTransformedForm < 138 || ataskTempl_0.m_ucPremiseTransformedForm > 141) && (ataskTempl_0.m_ucPremiseTransformedForm < 154 || ataskTempl_0.m_ucPremiseTransformedForm > 189) && (ataskTempl_0.m_ucPremiseTransformedForm < 207 || ataskTempl_0.m_ucPremiseTransformedForm > 208) && (ataskTempl_0.m_ucPremiseTransformedForm < 215 || ataskTempl_0.m_ucPremiseTransformedForm > 216) && (ataskTempl_0.m_ucPremiseTransformedForm < 254 || ataskTempl_0.m_ucPremiseTransformedForm > byte.MaxValue))
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267992), ataskTempl_0.m_ucPremiseTransformedForm));
		}
		if ((ataskTempl_0.m_ulPremise_Period < 0 || ataskTempl_0.m_ulPremise_Period > 8) && (ataskTempl_0.m_ulPremise_Period < 20 || ataskTempl_0.m_ulPremise_Period > 22) && (ataskTempl_0.m_ulPremise_Period < 30 || ataskTempl_0.m_ulPremise_Period > 32) && (ataskTempl_0.m_ulPremise_Period < 40 || ataskTempl_0.m_ulPremise_Period > 41))
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268025), ataskTempl_0.m_ulPremise_Period));
		}
		if (ataskTempl_0.m_iPremise_FactionRole < 2 || ataskTempl_0.m_iPremise_FactionRole > 6)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268050), ataskTempl_0.m_iPremise_FactionRole));
		}
		if (ataskTempl_0.m_tmCharEndTime.wday < 0 || ataskTempl_0.m_tmCharEndTime.wday > 7)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268087), ataskTempl_0.m_tmCharEndTime.wday));
		}
		if (ataskTempl_0.m_DynTaskType < 0 || ataskTempl_0.m_DynTaskType > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268106), ataskTempl_0.m_DynTaskType));
		}
		for (int l = 0; l < ataskTempl_0.m_TeamMemsWanted.Length; l++)
		{
			if (ataskTempl_0.m_TeamMemsWanted[l].m_ulRace < 0 || ataskTempl_0.m_TeamMemsWanted[l].m_ulRace > 6)
			{
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268134) + l + Class16.smethod_0(1649268158), ataskTempl_0.m_TeamMemsWanted[l].m_ulRace));
			}
			if (ataskTempl_0.m_TeamMemsWanted[l].m_ulOccupation < -1 || ataskTempl_0.m_TeamMemsWanted[l].m_ulOccupation > 14)
			{
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268134) + l + Class16.smethod_0(1649268175), ataskTempl_0.m_TeamMemsWanted[l].m_ulOccupation));
			}
			if ((ataskTempl_0.m_TeamMemsWanted[l].m_iForce < 0 || ataskTempl_0.m_TeamMemsWanted[l].m_iForce > 0) && (ataskTempl_0.m_TeamMemsWanted[l].m_iForce < 1004 || ataskTempl_0.m_TeamMemsWanted[l].m_iForce > 1006))
			{
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268134) + l + Class16.smethod_0(1649268198), ataskTempl_0.m_TeamMemsWanted[l].m_iForce));
			}
		}
		if (ataskTempl_0.m_nPremExp1AndOrExp2 < 0 || ataskTempl_0.m_nPremExp1AndOrExp2 > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649268215), ataskTempl_0.m_nPremExp1AndOrExp2));
		}
		if (ataskTempl_0.m_Prem1KeyValue.nLeftType < 0 || ataskTempl_0.m_Prem1KeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267210), ataskTempl_0.m_Prem1KeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Prem1KeyValue.nCompOper < 0 || ataskTempl_0.m_Prem1KeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267242), ataskTempl_0.m_Prem1KeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Prem1KeyValue.nRightType < 0 || ataskTempl_0.m_Prem1KeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267274), ataskTempl_0.m_Prem1KeyValue.nRightType));
		}
		if (ataskTempl_0.m_Prem2KeyValue.nLeftType < 0 || ataskTempl_0.m_Prem2KeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267307), ataskTempl_0.m_Prem2KeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Prem2KeyValue.nCompOper < 0 || ataskTempl_0.m_Prem2KeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267339), ataskTempl_0.m_Prem2KeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Prem2KeyValue.nRightType < 0 || ataskTempl_0.m_Prem2KeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267371), ataskTempl_0.m_Prem2KeyValue.nRightType));
		}
		if (ataskTempl_0.m_nPremPersonExp1AndOrExp2 < 0 || ataskTempl_0.m_nPremPersonExp1AndOrExp2 > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267412), ataskTempl_0.m_nPremPersonExp1AndOrExp2));
		}
		if (ataskTempl_0.m_Prem1PersonKeyValue.nLeftType < 0 || ataskTempl_0.m_Prem1PersonKeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267445), ataskTempl_0.m_Prem1PersonKeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Prem1PersonKeyValue.nCompOper < 0 || ataskTempl_0.m_Prem1PersonKeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267475), ataskTempl_0.m_Prem1PersonKeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Prem1PersonKeyValue.nRightType < 0 || ataskTempl_0.m_Prem1PersonKeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267513), ataskTempl_0.m_Prem1PersonKeyValue.nRightType));
		}
		if (ataskTempl_0.m_Prem2PersonKeyValue.nLeftType < 0 || ataskTempl_0.m_Prem2PersonKeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267552), ataskTempl_0.m_Prem2PersonKeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Prem2PersonKeyValue.nCompOper < 0 || ataskTempl_0.m_Prem2PersonKeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267598), ataskTempl_0.m_Prem2PersonKeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Prem2PersonKeyValue.nRightType < 0 || ataskTempl_0.m_Prem2PersonKeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267636), ataskTempl_0.m_Prem2PersonKeyValue.nRightType));
		}
		if (ataskTempl_0.m_nPremHistoryExp1AndOrExp2 < 0 || ataskTempl_0.m_nPremHistoryExp1AndOrExp2 > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267667), ataskTempl_0.m_nPremHistoryExp1AndOrExp2));
		}
		if (ataskTempl_0.m_Prem1HistoryKeyValue.nLeftType < 0 || ataskTempl_0.m_Prem1HistoryKeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267709), ataskTempl_0.m_Prem1HistoryKeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Prem1HistoryKeyValue.nCompOper < 0 || ataskTempl_0.m_Prem1HistoryKeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649266724), ataskTempl_0.m_Prem1HistoryKeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Prem1HistoryKeyValue.nRightType < 0 || ataskTempl_0.m_Prem1HistoryKeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649266755), ataskTempl_0.m_Prem1HistoryKeyValue.nRightType));
		}
		if (ataskTempl_0.m_Prem2HistoryKeyValue.nLeftType < 0 || ataskTempl_0.m_Prem2HistoryKeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649266795), ataskTempl_0.m_Prem2HistoryKeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Prem2HistoryKeyValue.nCompOper < 0 || ataskTempl_0.m_Prem2HistoryKeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649266834), ataskTempl_0.m_Prem2HistoryKeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Prem2HistoryKeyValue.nRightType < 0 || ataskTempl_0.m_Prem2HistoryKeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649266873), ataskTempl_0.m_Prem2HistoryKeyValue.nRightType));
		}
		if ((ataskTempl_0.m_iPremForce < -1 || ataskTempl_0.m_iPremForce > 0) && (ataskTempl_0.m_iPremForce < 1004 || ataskTempl_0.m_iPremForce > 1006))
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649266913), ataskTempl_0.m_iPremForce));
		}
		if (ataskTempl_0.m_iPremGeneralCardRank < -1 || ataskTempl_0.m_iPremGeneralCardRank > 4)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649266940), ataskTempl_0.m_iPremGeneralCardRank));
		}
		if (ataskTempl_0.m_iPremHomeResourceLevelType < 0 || ataskTempl_0.m_iPremHomeResourceLevelType > 5)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649266961), ataskTempl_0.m_iPremHomeResourceLevelType));
		}
		if (ataskTempl_0.m_iPremHomeFactoryLevelType < 0 || ataskTempl_0.m_iPremHomeFactoryLevelType > 4)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267004), ataskTempl_0.m_iPremHomeFactoryLevelType));
		}
		if (ataskTempl_0.m_iCamp > 2)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267038), ataskTempl_0.m_iCamp));
		}
		if (ataskTempl_0.m_iCampPower > 2)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267052), ataskTempl_0.m_iCampPower));
		}
		if (ataskTempl_0.m_iRankType > 6)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267071), ataskTempl_0.m_iRankType));
		}
		if (ataskTempl_0.m_iRankGradeMin > 20 || ataskTempl_0.m_iRankGradeMax > 20)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267081), ataskTempl_0.m_iRankGradeMin));
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267111), ataskTempl_0.m_iRankGradeMax));
		}
		if (ataskTempl_0.m_enumMethod < 0 || ataskTempl_0.m_enumMethod > 37 || ataskTempl_0.m_enumMethod == 6 || ataskTempl_0.m_enumMethod == 9)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267133), ataskTempl_0.m_enumMethod));
		}
		if (ataskTempl_0.m_enumFinishType <= -1 || ataskTempl_0.m_enumFinishType > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649267144), ataskTempl_0.m_enumFinishType));
		}
		for (int m = 0; m < ataskTempl_0.m_PlayerWanted.Length; m++)
		{
			if (ataskTempl_0.m_PlayerWanted[m].m_Requirements.m_ulOccupations != 0)
			{
				uint num = 1u;
				for (int n = 1; n <= 32; n++)
				{
					if (((uint)ataskTempl_0.m_PlayerWanted[m].m_Requirements.m_ulOccupations & num) != 0 && num > 16384)
					{
						ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(Class16.smethod_0(1649267175) + ataskTempl_0.m_ID + Class16.smethod_0(1649267188) + m + Class16.smethod_0(1649270295) + (n - 1) + Class16.smethod_0(1649270357) + num);
					}
					num *= 2;
				}
			}
			if (ataskTempl_0.m_PlayerWanted[m].m_Requirements.m_iForce == 0)
			{
				continue;
			}
			uint num2 = 1u;
			for (int num3 = 1; num3 <= 32; num3++)
			{
				if (((uint)ataskTempl_0.m_PlayerWanted[m].m_Requirements.m_iForce & num2) != 0 && num2 > 4)
				{
					ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(Class16.smethod_0(1649267175) + ataskTempl_0.m_ID + Class16.smethod_0(1649267188) + m + Class16.smethod_0(1649270373) + (num3 - 1) + Class16.smethod_0(1649270357) + num2);
				}
				num2 *= 2;
			}
		}
		if (ataskTempl_0.m_nFinExp1AndOrExp2 < 0 || ataskTempl_0.m_nFinExp1AndOrExp2 > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270428), ataskTempl_0.m_nFinExp1AndOrExp2));
		}
		if (ataskTempl_0.m_Fin1KeyValue.nLeftType < 0 || ataskTempl_0.m_Fin1KeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270454), ataskTempl_0.m_Fin1KeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Fin1KeyValue.nCompOper < 0 || ataskTempl_0.m_Fin1KeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270485), ataskTempl_0.m_Fin1KeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Fin1KeyValue.nRightType < 0 || ataskTempl_0.m_Fin1KeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270516), ataskTempl_0.m_Fin1KeyValue.nRightType));
		}
		if (ataskTempl_0.m_Fin2KeyValue.nLeftType < 0 || ataskTempl_0.m_Fin2KeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270548), ataskTempl_0.m_Fin2KeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Fin2KeyValue.nCompOper < 0 || ataskTempl_0.m_Fin2KeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270571), ataskTempl_0.m_Fin2KeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Fin2KeyValue.nRightType < 0 || ataskTempl_0.m_Fin2KeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270602), ataskTempl_0.m_Fin2KeyValue.nRightType));
		}
		if (ataskTempl_0.m_nFinPersonExp1AndOrExp2 < 0 || ataskTempl_0.m_nFinPersonExp1AndOrExp2 > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270634), ataskTempl_0.m_nFinPersonExp1AndOrExp2));
		}
		if (ataskTempl_0.m_Fin1PersonKeyValue.nLeftType < 0 || ataskTempl_0.m_Fin1PersonKeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270666), ataskTempl_0.m_Fin1PersonKeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Fin1PersonKeyValue.nCompOper < 0 || ataskTempl_0.m_Fin1PersonKeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270711), ataskTempl_0.m_Fin1PersonKeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Fin1PersonKeyValue.nRightType < 0 || ataskTempl_0.m_Fin1PersonKeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270748), ataskTempl_0.m_Fin1PersonKeyValue.nRightType));
		}
		if (ataskTempl_0.m_Fin2PersonKeyValue.nLeftType < 0 || ataskTempl_0.m_Fin2PersonKeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270778), ataskTempl_0.m_Fin2PersonKeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Fin2PersonKeyValue.nCompOper < 0 || ataskTempl_0.m_Fin2PersonKeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269799), ataskTempl_0.m_Fin2PersonKeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Fin2PersonKeyValue.nRightType < 0 || ataskTempl_0.m_Fin2PersonKeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269836), ataskTempl_0.m_Fin2PersonKeyValue.nRightType));
		}
		if (ataskTempl_0.m_nFinHistoryExp1AndOrExp2 < 0 || ataskTempl_0.m_nFinHistoryExp1AndOrExp2 > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269866), ataskTempl_0.m_nFinHistoryExp1AndOrExp2));
		}
		if (ataskTempl_0.m_Fin1HistoryKeyValue.lLeftNum > 0)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269899), ataskTempl_0.m_Fin1HistoryKeyValue.lLeftNum));
		}
		if (ataskTempl_0.m_Fin1HistoryKeyValue.nLeftType < 0 || ataskTempl_0.m_Fin1HistoryKeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269936), ataskTempl_0.m_Fin1HistoryKeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Fin1HistoryKeyValue.nCompOper < 0 || ataskTempl_0.m_Fin1HistoryKeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269982), ataskTempl_0.m_Fin1HistoryKeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Fin1HistoryKeyValue.nRightType < 0 || ataskTempl_0.m_Fin1HistoryKeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270020), ataskTempl_0.m_Fin1HistoryKeyValue.nRightType));
		}
		if (ataskTempl_0.m_Fin2HistoryKeyValue.nLeftType < 0 || ataskTempl_0.m_Fin2HistoryKeyValue.nLeftType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270051), ataskTempl_0.m_Fin2HistoryKeyValue.nLeftType));
		}
		if (ataskTempl_0.m_Fin2HistoryKeyValue.nCompOper < 0 || ataskTempl_0.m_Fin2HistoryKeyValue.nCompOper > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270089), ataskTempl_0.m_Fin2HistoryKeyValue.nCompOper));
		}
		if (ataskTempl_0.m_Fin2HistoryKeyValue.nRightType < 0 || ataskTempl_0.m_Fin2HistoryKeyValue.nRightType > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270135), ataskTempl_0.m_Fin2HistoryKeyValue.nRightType));
		}
		if ((ataskTempl_0.m_ucTransformedForm < 0 || ataskTempl_0.m_ucTransformedForm > 0) && (ataskTempl_0.m_ucTransformedForm < 128 || ataskTempl_0.m_ucTransformedForm > 128) && (ataskTempl_0.m_ucTransformedForm < 138 || ataskTempl_0.m_ucTransformedForm > 141) && (ataskTempl_0.m_ucTransformedForm < 154 || ataskTempl_0.m_ucTransformedForm > 189) && (ataskTempl_0.m_ucTransformedForm < 207 || ataskTempl_0.m_ucTransformedForm > 208) && (ataskTempl_0.m_ucTransformedForm < 215 || ataskTempl_0.m_ucTransformedForm > 216) && (ataskTempl_0.m_ucTransformedForm < 254 || ataskTempl_0.m_ucTransformedForm > byte.MaxValue))
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270174), ataskTempl_0.m_ucTransformedForm));
		}
		if ((ataskTempl_0.m_uiEmotion < 0 || ataskTempl_0.m_uiEmotion > 31) && (ataskTempl_0.m_uiEmotion < 1024 || ataskTempl_0.m_uiEmotion > 1029) && ataskTempl_0.m_uiEmotion != 500 && ataskTempl_0.m_uiEmotion != 502)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270192), ataskTempl_0.m_uiEmotion));
		}
		if (ataskTempl_0.m_ulGrowthTarget != 0)
		{
			uint num4 = 1u;
			for (int num5 = 1; num5 <= 32; num5++)
			{
				if (((uint)ataskTempl_0.m_ulGrowthTarget & num4) != 0 && num4 > 8388608)
				{
					ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270210), Class16.smethod_0(1649270233) + (num5 - 1) + Class16.smethod_0(1649270357) + num4));
				}
				num4 *= 2;
			}
		}
		if (ataskTempl_0.m_ulTMHomeLevelType < 0 || ataskTempl_0.m_ulTMHomeLevelType > 8)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649270248), ataskTempl_0.m_ulTMHomeLevelType));
		}
		if (ataskTempl_0.m_iTriggerEvent > 0)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269250), ataskTempl_0.m_iTriggerEvent));
		}
		if (ataskTempl_0.m_TaskEventType < 0 || ataskTempl_0.m_TaskEventType > 2)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269272), ataskTempl_0.m_TaskEventType));
		}
		if (ataskTempl_0.m_iTinyGameType > 5)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269302), ataskTempl_0.m_iTinyGameType));
		}
		if (ataskTempl_0.m_ulAwardType_S < 0 || ataskTempl_0.m_ulAwardType_S > 6)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269324), ataskTempl_0.m_ulAwardType_S));
		}
		if (ataskTempl_0.m_ulAwardType_F < 0 || ataskTempl_0.m_ulAwardType_F > 6)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269338), ataskTempl_0.m_ulAwardType_F));
		}
		for (int num6 = 0; num6 < ataskTempl_0.AwByVar_S.AwardVar.Length; num6++)
		{
			if (ataskTempl_0.AwByVar_S.AwardVar[num6].value > 0f)
			{
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269360) + num6 + Class16.smethod_0(1649269386), ataskTempl_0.AwByVar_S.AwardVar[num6].type));
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269360) + num6 + Class16.smethod_0(1649269407), ataskTempl_0.AwByVar_S.AwardVar[num6].value));
			}
		}
		for (int num7 = 0; num7 < ataskTempl_0.AwByVar_F.AwardVar.Length; num7++)
		{
			if (ataskTempl_0.AwByVar_F.AwardVar[num7].value > 0f)
			{
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269421) + num7 + Class16.smethod_0(1649269386), ataskTempl_0.AwByVar_F.AwardVar[num7].type));
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269421) + num7 + Class16.smethod_0(1649269407), ataskTempl_0.AwByVar_F.AwardVar[num7].value));
			}
		}
		smethod_3(ataskTempl_0.m_Award_S, ataskTempl_0.m_ID, 0, 0);
		smethod_3(ataskTempl_0.m_Award_F, ataskTempl_0.m_ID, 1, 0);
		for (int num8 = 0; num8 < ataskTempl_0.m_AwByRatio_S.m_Awards.Length; num8++)
		{
			smethod_3(ataskTempl_0.m_AwByRatio_S.m_Awards[num8], ataskTempl_0.m_ID, 2, num8);
		}
		for (int num9 = 0; num9 < ataskTempl_0.m_AwByRatio_F.m_Awards.Length; num9++)
		{
			smethod_3(ataskTempl_0.m_AwByRatio_F.m_Awards[num9], ataskTempl_0.m_ID, 3, num9);
		}
		for (int num10 = 0; num10 < ataskTempl_0.m_AwByItems_S.m_Awards.Length; num10++)
		{
			smethod_3(ataskTempl_0.m_AwByItems_S.m_Awards[num10], ataskTempl_0.m_ID, 4, num10);
		}
		for (int num11 = 0; num11 < ataskTempl_0.m_AwByItems_F.m_Awards.Length; num11++)
		{
			smethod_3(ataskTempl_0.m_AwByItems_F.m_Awards[num11], ataskTempl_0.m_ID, 5, num11);
		}
		for (int num12 = 0; num12 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards.Length; num12++)
		{
			smethod_3(ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num12], ataskTempl_0.m_ID, 6, num12);
		}
		for (int num13 = 0; num13 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards.Length; num13++)
		{
			smethod_3(ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num13], ataskTempl_0.m_ID, 7, num13);
		}
		for (int num14 = 0; num14 < ataskTempl_0.AwByCarrierHp_S.m_Awards.Length; num14++)
		{
			smethod_3(ataskTempl_0.AwByCarrierHp_S.m_Awards[num14], ataskTempl_0.m_ID, 8, num14);
		}
		for (int num15 = 0; num15 < ataskTempl_0.AwByCarrierHp_F.m_Awards.Length; num15++)
		{
			smethod_3(ataskTempl_0.AwByCarrierHp_F.m_Awards[num15], ataskTempl_0.m_ID, 9, num15);
		}
		for (int num16 = 0; num16 < ataskTempl_0.AwByVar_S.m_Awards.Length; num16++)
		{
			smethod_3(ataskTempl_0.AwByVar_S.m_Awards[num16], ataskTempl_0.m_ID, 10, num16);
		}
		for (int num17 = 0; num17 < ataskTempl_0.AwByVar_F.m_Awards.Length; num17++)
		{
			smethod_3(ataskTempl_0.AwByVar_F.m_Awards[num17], ataskTempl_0.m_ID, 11, num17);
		}
		if (ataskTempl_0.CombinedSwitches[18] != 0)
		{
			int num18 = 1;
			for (int num19 = 1; num19 <= 8; num19++)
			{
				if ((ataskTempl_0.CombinedSwitches[17] & num18) > 0 && num18 == 4)
				{
					ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269447) + 18 + Class16.smethod_0(1649008474), Class16.smethod_0(1649270233) + (num19 - 1) + Class16.smethod_0(1649270357) + num18));
				}
				num18 *= 2;
			}
		}
		if (ataskTempl_0.CombinedSwitches[19] != 0)
		{
			int num20 = 1;
			for (int num21 = 1; num21 <= 8; num21++)
			{
				if ((ataskTempl_0.CombinedSwitches[19] & num20) > 0 && num20 == 8)
				{
					ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269447) + 19 + Class16.smethod_0(1649008474), Class16.smethod_0(1649270233) + (num21 - 1) + Class16.smethod_0(1649270357) + num20));
				}
				num20 *= 2;
			}
		}
		if (ataskTempl_0.CombinedSwitches[20] != 0)
		{
			int num22 = 1;
			for (int num23 = 1; num23 <= 8; num23++)
			{
				if ((ataskTempl_0.CombinedSwitches[20] & num22) > 0 && num22 == 8)
				{
					ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269447) + 20 + Class16.smethod_0(1649008474), Class16.smethod_0(1649270233) + (num23 - 1) + Class16.smethod_0(1649270357) + num22));
				}
				num22 *= 2;
			}
		}
		for (int num24 = 0; num24 < ataskTempl_0.SpecialParameters.unk176.Length; num24++)
		{
			if (ataskTempl_0.SpecialParameters.unk176[num24] != 0)
			{
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269471) + num24 + Class16.smethod_0(1649008474), ataskTempl_0.SpecialParameters.unk176[num24]));
			}
		}
		if (ataskTempl_0.SpecialParameters.Parameter9 != 0)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269485), ataskTempl_0.SpecialParameters.Parameter9));
		}
		if (ataskTempl_0.SpecialParameters.need_story_book_collection > 1)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, ataskTempl_0.m_ID, Class16.smethod_0(1649269502), ataskTempl_0.SpecialParameters.need_story_book_collection));
		}
	}

	private static void smethod_3(AWARD_DATA award_DATA_0, int int_0, int int_1, int int_2)
	{
		string text = string.Empty;
		switch (int_1)
		{
		case 0:
			text = Class16.smethod_0(1649269535);
			break;
		case 1:
			text = Class16.smethod_0(1649269544);
			break;
		case 2:
			text = Class16.smethod_0(1649269561) + int_2 + Class16.smethod_0(1649269599);
			break;
		case 3:
			text = Class16.smethod_0(1649269600) + int_2 + Class16.smethod_0(1649269599);
			break;
		case 4:
			text = Class16.smethod_0(1649269638) + int_2 + Class16.smethod_0(1649269599);
			break;
		case 5:
			text = Class16.smethod_0(1649269668) + int_2 + Class16.smethod_0(1649269599);
			break;
		case 6:
			text = Class16.smethod_0(1649269690) + int_2 + Class16.smethod_0(1649269599);
			break;
		case 7:
			text = Class16.smethod_0(1649269735) + int_2 + Class16.smethod_0(1649269599);
			break;
		case 8:
			text = Class16.smethod_0(1649268748) + int_2 + Class16.smethod_0(1649269599);
			break;
		case 9:
			text = Class16.smethod_0(1649268780) + int_2 + Class16.smethod_0(1649269599);
			break;
		case 10:
			text = Class16.smethod_0(1649268812) + int_2 + Class16.smethod_0(1649269599);
			break;
		case 11:
			text = Class16.smethod_0(1649268838) + int_2 + Class16.smethod_0(1649269599);
			break;
		}
		if (award_DATA_0.m_ulCandItems > 999)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649268856), award_DATA_0.m_ulCandItems));
		}
		for (int i = 0; i < award_DATA_0.m_ulCandItems; i++)
		{
			if (award_DATA_0.m_CandItems[i].m_ulAwardItems > 64)
			{
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649268884) + i + Class16.smethod_0(1649268903), award_DATA_0.m_CandItems[i].m_ulAwardItems));
			}
		}
		if (award_DATA_0.m_ulSummonedMonsters > 32)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649268926), award_DATA_0.m_ulSummonedMonsters));
		}
		if (award_DATA_0.m_ulPQRankingAwardCnt > 32)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649268945), award_DATA_0.m_ulPQRankingAwardCnt));
		}
		if (award_DATA_0.m_ulChangeKeyCnt > 255)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649273818), award_DATA_0.m_ulChangeKeyCnt));
		}
		if (award_DATA_0.m_ulPersonChangeKeyCnt > 255)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649268981), award_DATA_0.m_ulPersonChangeKeyCnt));
		}
		if (award_DATA_0.m_ulHistoryChangeCnt > 255)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649269002), award_DATA_0.m_ulHistoryChangeCnt));
		}
		if (award_DATA_0.m_plChangeKeyValue2 != null && award_DATA_0.m_plChangeKeyValue2.Length != 0 && award_DATA_0.m_ulChangeKeyCnt > 0)
		{
			int num = award_DATA_0.m_ulChangeKeyCnt;
			if (num > award_DATA_0.m_plChangeKeyValue2.Length)
			{
				num = award_DATA_0.m_plChangeKeyValue2.Length;
			}
			for (int j = 0; j < num; j++)
			{
				smethod_0(int_0, text + Class16.smethod_0(1649273638) + j + Class16.smethod_0(1649008474), award_DATA_0.m_plChangeKeyValue2[j]);
			}
		}
		if (award_DATA_0.PersonChangeKeyValue2 != null && award_DATA_0.PersonChangeKeyValue2.Length != 0 && award_DATA_0.m_ulPersonChangeKeyCnt > 0)
		{
			int num2 = award_DATA_0.m_ulPersonChangeKeyCnt;
			if (num2 > award_DATA_0.PersonChangeKeyValue2.Length)
			{
				num2 = award_DATA_0.PersonChangeKeyValue2.Length;
			}
			for (int k = 0; k < num2; k++)
			{
				smethod_0(int_0, text + Class16.smethod_0(1649269037) + k + Class16.smethod_0(1649008474), award_DATA_0.PersonChangeKeyValue2[k]);
			}
		}
		if (award_DATA_0.m_plHistoryChangeKeyValue2 != null && award_DATA_0.m_plHistoryChangeKeyValue2.Length != 0 && award_DATA_0.m_ulHistoryChangeCnt > 0)
		{
			int num3 = award_DATA_0.m_ulHistoryChangeCnt;
			if (num3 > award_DATA_0.m_plHistoryChangeKeyValue2.Length)
			{
				num3 = award_DATA_0.m_plHistoryChangeKeyValue2.Length;
			}
			for (int l = 0; l < num3; l++)
			{
				smethod_0(int_0, text + Class16.smethod_0(1649273690) + l + Class16.smethod_0(1649008474), award_DATA_0.m_plHistoryChangeKeyValue2[l]);
			}
		}
		if (award_DATA_0.m_ulDisplayKeyCnt > 64)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649269058), award_DATA_0.m_ulDisplayKeyCnt));
		}
		if (award_DATA_0.m_ulExpCnt > 32)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649273119), award_DATA_0.m_ulExpCnt));
		}
		if (award_DATA_0.m_ulTaskCharCnt > 32)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649273183), award_DATA_0.m_ulTaskCharCnt));
		}
		if (award_DATA_0.m_ulTitleNum > 999)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649269082), award_DATA_0.m_ulTitleNum));
		}
		if ((award_DATA_0.m_ulNewPeriod < 0 || award_DATA_0.m_ulNewPeriod > 8) && (award_DATA_0.m_ulNewPeriod < 20 || award_DATA_0.m_ulNewPeriod > 22) && (award_DATA_0.m_ulNewPeriod < 30 || award_DATA_0.m_ulNewPeriod > 32) && (award_DATA_0.m_ulNewPeriod < 40 || award_DATA_0.m_ulNewPeriod > 41))
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649269109), award_DATA_0.m_ulNewPeriod));
		}
		if (award_DATA_0.m_nMsgChannel < 0 || award_DATA_0.m_nMsgChannel > 15)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649269121), award_DATA_0.m_nMsgChannel));
		}
		if (award_DATA_0.m_ulCarrierChangeCnt > 0)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649269149), award_DATA_0.m_ulCarrierChangeCnt));
			for (int m = 0; m < award_DATA_0.m_ulCarrierChangeCnt; m++)
			{
				if (award_DATA_0.NewChangeKey != null && m < award_DATA_0.NewChangeKey.Length)
				{
					ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1648924364) + m + Class16.smethod_0(1649269168), award_DATA_0.NewChangeKey[m]));
				}
				if (award_DATA_0.NewChangeKeyValue != null && m < award_DATA_0.NewChangeKeyValue.Length)
				{
					ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1648924364) + m + Class16.smethod_0(1649269196), award_DATA_0.NewChangeKeyValue[m]));
				}
				if (award_DATA_0.NewChangeKeyValue2 != null && m < award_DATA_0.NewChangeKeyValue2.Length)
				{
					smethod_0(int_0, text + Class16.smethod_0(1648924364) + m + Class16.smethod_0(1649269221), award_DATA_0.NewChangeKeyValue2[m]);
				}
				if (award_DATA_0.NewChangeType != null && m < award_DATA_0.NewChangeType.Length)
				{
					ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1648924364) + m + Class16.smethod_0(1649269247), award_DATA_0.NewChangeType[m]));
				}
			}
		}
		if (award_DATA_0.m_iOpenSystem > 2)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649264148), award_DATA_0.m_iOpenSystem));
		}
		if (award_DATA_0.submit_rank.m_iRankID > 2)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649264160), award_DATA_0.submit_rank.m_iRankID));
		}
		if (award_DATA_0.submit_rank.m_iSubmitType > 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649264196), award_DATA_0.submit_rank.m_iSubmitType));
		}
		if (award_DATA_0.submit_rank.m_iTempRankID != -1 && award_DATA_0.submit_rank.m_iTempRankID != 0 && award_DATA_0.submit_rank.m_iTempRankID != 1 && award_DATA_0.submit_rank.m_iTempRankID != 3)
		{
			ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(string_0, int_0, text + Class16.smethod_0(1649264228), award_DATA_0.submit_rank.m_iTempRankID));
		}
	}
}
