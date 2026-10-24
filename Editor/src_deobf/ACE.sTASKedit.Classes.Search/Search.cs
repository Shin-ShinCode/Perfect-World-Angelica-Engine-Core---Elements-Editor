using System;
using System.Windows.Forms;
using ACE.Classes;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes.Search;

internal class Search
{
	public enum SearchType
	{
		enumSTID,
		enumSTName,
		enumSTWldId,
		enumSTMonsCtrl,
		enumSTNPCId,
		enumSTKey,
		enumSTItemTemplId,
		enumSTMonsterTemplId,
		enumSTTitleId,
		enumSTTransWldId,
		enumSTMonstersContrib,
		enumSTPremItems,
		enumSTGivenItems,
		enumSTPremTitles,
		enumSTMonsterWantedMonster,
		enumSTMonsterWantedItem,
		enumSTItemsWanted,
		enumSTTaskChar,
		enumSTHomeItemsWanted,
		enumSTAwardItems,
		enumSTSummonedMonsters,
		enumSTRankingAward,
		enumSTTitleAward,
		enumSTTexts
	}

	private static bool smethod_0(string string_0, string string_1)
	{
		return TextSearchHelper.Contains(string_0, string_1);
	}

	public static bool search(ACE.sTASKedit.MainEditor.MainEditor ME, int[] indices, SearchType type, int id_space, string string_0)
	{
		if (indices.Length != 0)
		{
			ATaskTempl aTaskTempl = smethod_1(indices);
			if (aTaskTempl == null)
			{
				return false;
			}
			if (type == SearchType.enumSTID)
			{
				if (id_space > -1)
				{
					if (aTaskTempl.m_usIDSpace == id_space && aTaskTempl.m_ID.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						return true;
					}
				}
				else if (aTaskTempl.m_ID.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					return true;
				}
			}
			if (type == SearchType.enumSTName)
			{
				if (Settings.Fields.IgnoreColorCod)
				{
					if (smethod_0(GlobalFunctions.ColorClean(aTaskTempl.Name), string_0))
					{
						smethod_2(ME.treeView_tasks, indices);
						return true;
					}
				}
				else if (smethod_0(aTaskTempl.Name, string_0))
				{
					smethod_2(ME.treeView_tasks, indices);
					return true;
				}
			}
			if (type == SearchType.enumSTWldId)
			{
				if (aTaskTempl.m_ulDelvWorld.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_DELV_WORLD, aTaskTempl);
					return true;
				}
				for (int i = 0; i < aTaskTempl.m_pDelvRegion.Length; i++)
				{
					if (!(aTaskTempl.m_pDelvRegion[i].MapID.ToString() == string_0))
					{
						if (aTaskTempl.m_pDelvRegion[i].RegionID.ToString() == string_0)
						{
							smethod_2(ME.treeView_tasks, indices);
							TaskElements.SelectElement(ME, 0, 0, i, GlobalData.TASKELEMENTS_TYPE.TASKS_DELV_REGION, aTaskTempl);
							return true;
						}
						continue;
					}
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, i, GlobalData.TASKELEMENTS_TYPE.TASKS_DELV_REGION, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_ulEnterRegionWorld.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_ENTER_REGION_WORLD, aTaskTempl);
					return true;
				}
				for (int j = 0; j < aTaskTempl.m_pEnterRegion.Length; j++)
				{
					if (!(aTaskTempl.m_pEnterRegion[j].MapID.ToString() == string_0))
					{
						if (aTaskTempl.m_pEnterRegion[j].RegionID.ToString() == string_0)
						{
							smethod_2(ME.treeView_tasks, indices);
							TaskElements.SelectElement(ME, 0, 0, j, GlobalData.TASKELEMENTS_TYPE.TASKS_ENTER_REGION, aTaskTempl);
							return true;
						}
						continue;
					}
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, j, GlobalData.TASKELEMENTS_TYPE.TASKS_ENTER_REGION, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_ulLeaveRegionWorld.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_LEAVE_REGION_WORLD, aTaskTempl);
					return true;
				}
				for (int k = 0; k < aTaskTempl.m_pLeaveRegion.Length; k++)
				{
					if (!(aTaskTempl.m_pLeaveRegion[k].MapID.ToString() == string_0))
					{
						if (aTaskTempl.m_pLeaveRegion[k].RegionID.ToString() == string_0)
						{
							smethod_2(ME.treeView_tasks, indices);
							TaskElements.SelectElement(ME, 0, 0, k, GlobalData.TASKELEMENTS_TYPE.TASKS_LEAVE_REGION, aTaskTempl);
							return true;
						}
						continue;
					}
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, k, GlobalData.TASKELEMENTS_TYPE.TASKS_LEAVE_REGION, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_ulTransWldId.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_TRANS_WLD_ID, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_ulReachSiteId.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_REACH_SITE_ID, aTaskTempl);
					return true;
				}
				for (int l = 0; l < aTaskTempl.m_pReachSite.Length; l++)
				{
					if (!(aTaskTempl.m_pReachSite[l].MapID.ToString() == string_0))
					{
						if (aTaskTempl.m_pReachSite[l].RegionID.ToString() == string_0)
						{
							smethod_2(ME.treeView_tasks, indices);
							TaskElements.SelectElement(ME, 0, 0, l, GlobalData.TASKELEMENTS_TYPE.TASKS_REACH_SITE, aTaskTempl);
							return true;
						}
						continue;
					}
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, l, GlobalData.TASKELEMENTS_TYPE.TASKS_REACH_SITE, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_usZoneMapID.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_TREASURE_ZONE_MAP_ID, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_ulLeaveSiteId.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_LEAVE_SITE_ID, aTaskTempl);
					return true;
				}
				for (int m = 0; m < aTaskTempl.m_pLeaveSite.Length; m++)
				{
					if (aTaskTempl.m_pLeaveSite[m].MapID.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, m, GlobalData.TASKELEMENTS_TYPE.TASKS_LEAVE_SITE, aTaskTempl);
						return true;
					}
				}
				if (smethod_3(ME, indices, aTaskTempl, string_0))
				{
					return true;
				}
			}
			if (type == SearchType.enumSTMonsCtrl)
			{
				if (aTaskTempl.m_lMonsCtrl.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_MONS_CTRL, aTaskTempl);
					return true;
				}
				if (smethod_4(ME, indices, aTaskTempl, string_0))
				{
					return true;
				}
			}
			if (type == SearchType.enumSTNPCId)
			{
				if (aTaskTempl.m_ulDelvNPC.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_DELV_NPC, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_ulAwardNPC.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_NPC, aTaskTempl);
					return true;
				}
				for (int n = 0; n < aTaskTempl.m_ulPropSummonedMonsters; n++)
				{
					if (aTaskTempl.PropMonsterSummoned.m_Monsters[n].m_ulMonsterTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, n, GlobalData.TASKELEMENTS_TYPE.TASKS_PROP_SUMMONED_MONSTERS, aTaskTempl);
						return true;
					}
				}
				if (smethod_6(ME, indices, aTaskTempl, string_0))
				{
					return true;
				}
			}
			if (type == SearchType.enumSTKey)
			{
				for (int num = 0; num < aTaskTempl.m_plChangeKey.Length; num++)
				{
					if (aTaskTempl.m_plChangeKey[num].ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num, GlobalData.TASKELEMENTS_TYPE.TASKS_CHANGE_KEY, aTaskTempl);
						return true;
					}
				}
				if (aTaskTempl.m_Prop1KeyValue.lLeftNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_FAIL_1_KEY_VALUE_LEFT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_Prop1KeyValue.lRightNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_FAIL_1_KEY_VALUE_RIGHT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_Prop2KeyValue.lLeftNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_FAIL_2_KEY_VALUE_LEFT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_Prop2KeyValue.lRightNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_FAIL_2_KEY_VALUE_RIGHT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_Prem1KeyValue.lLeftNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_1_KEY_VALUE_LEFT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_Prem1KeyValue.lRightNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_1_KEY_VALUE_RIGHT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_Prem2KeyValue.lLeftNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_2_KEY_VALUE_LEFT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_Prem2KeyValue.lRightNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_2_KEY_VALUE_RIGHT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_Fin1KeyValue.lLeftNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_FIN_1_KEY_VALUE_LEFT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_Fin1KeyValue.lRightNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_FIN_1_KEY_VALUE_RIGHT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_Fin2KeyValue.lLeftNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_FIN_2_KEY_VALUE_LEFT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_Fin2KeyValue.lRightNum.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_FIN_2_KEY_VALUE_RIGHT_NUM, aTaskTempl);
					return true;
				}
				if (aTaskTempl.m_lGlobalKeyForAwardVar.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_GLOBAL_KEY_FOR_AWARD_VAR, aTaskTempl);
					return true;
				}
				if (smethod_8(ME, indices, aTaskTempl, string_0))
				{
					return true;
				}
			}
			if (type == SearchType.enumSTItemTemplId)
			{
				for (int num2 = 0; num2 < aTaskTempl.m_PremItems.Length; num2++)
				{
					if (aTaskTempl.m_PremItems[num2].m_ulItemTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num2, GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_ITEMS, aTaskTempl);
						return true;
					}
				}
				for (int num3 = 0; num3 < aTaskTempl.m_GivenItems.Length; num3++)
				{
					if (aTaskTempl.m_GivenItems[num3].m_ulItemTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num3, GlobalData.TASKELEMENTS_TYPE.TASKS_GIVEN_ITEMS, aTaskTempl);
						return true;
					}
				}
				for (int num4 = 0; num4 < aTaskTempl.m_PlayerWanted.Length; num4++)
				{
					if (aTaskTempl.m_PlayerWanted[num4].m_ulDropItemId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num4, GlobalData.TASKELEMENTS_TYPE.TASKS_MATTERS_PLAYER_WANTED, aTaskTempl);
						return true;
					}
				}
				for (int num5 = 0; num5 < aTaskTempl.m_MonsterWanted.Length; num5++)
				{
					if (aTaskTempl.m_MonsterWanted[num5].m_ulDropItemId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num5, GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_WANTED_ITEMS, aTaskTempl);
						return true;
					}
				}
				for (int num6 = 0; num6 < aTaskTempl.m_MonsterUnwanted.Length; num6++)
				{
					if (aTaskTempl.m_MonsterUnwanted[num6].m_ulDropItemId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num6, GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_UNWANTED_ITEMS, aTaskTempl);
						return true;
					}
				}
				for (int num7 = 0; num7 < aTaskTempl.m_ItemsWanted.Length; num7++)
				{
					if (aTaskTempl.m_ItemsWanted[num7].m_ulItemTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num7, GlobalData.TASKELEMENTS_TYPE.TASKS_ITEMS_WANTED, aTaskTempl);
						return true;
					}
				}
				if (smethod_5(ME, indices, aTaskTempl, string_0))
				{
					return true;
				}
				if (smethod_7(ME, indices, aTaskTempl, string_0))
				{
					return true;
				}
				if (smethod_10(ME, indices, aTaskTempl, string_0))
				{
					return true;
				}
				for (int num8 = 0; num8 < aTaskTempl.SpecialParameters.UseItemIDs.Length; num8++)
				{
					if (aTaskTempl.SpecialParameters.UseItemIDs[num8].ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num8, GlobalData.TASKELEMENTS_TYPE.TASKS_SL_USE_ITEM_IDS, aTaskTempl);
						return true;
					}
				}
			}
			if (type == SearchType.enumSTMonsterTemplId)
			{
				for (int num9 = 0; num9 < aTaskTempl.m_MonstersContrib.Length; num9++)
				{
					if (aTaskTempl.m_MonstersContrib[num9].m_ulMonsterTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num9, GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTERS_CONTRIB, aTaskTempl);
						return true;
					}
				}
				for (int num10 = 0; num10 < aTaskTempl.m_ulPropSummonedMonsters; num10++)
				{
					if (aTaskTempl.PropMonsterSummoned.m_Monsters[num10].m_ulMonsterTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num10, GlobalData.TASKELEMENTS_TYPE.TASKS_PROP_SUMMONED_MONSTERS, aTaskTempl);
						return true;
					}
				}
				for (int num11 = 0; num11 < aTaskTempl.m_MonsterWanted.Length; num11++)
				{
					if (aTaskTempl.m_MonsterWanted[num11].m_ulMonsterTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num11, GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_WANTED_MONSTERS, aTaskTempl);
						return true;
					}
				}
				for (int num12 = 0; num12 < aTaskTempl.m_MonsterUnwanted.Length; num12++)
				{
					if (aTaskTempl.m_MonsterUnwanted[num12].m_ulMonsterTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num12, GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_UNWANTED_MONSTERS, aTaskTempl);
						return true;
					}
				}
				if (aTaskTempl.m_ulBindOnCarrierId.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_TM_BIND_CARRTER_ID, aTaskTempl);
					return true;
				}
				for (int num13 = 0; num13 < aTaskTempl.TaskEventMonsterData.Length; num13++)
				{
					if (aTaskTempl.TaskEventMonsterData[num13].Id.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num13, GlobalData.TASKELEMENTS_TYPE.TASKS_TASK_EVENT_MONSTER_DATA, aTaskTempl);
						return true;
					}
				}
				if (smethod_6(ME, indices, aTaskTempl, string_0))
				{
					return true;
				}
			}
			if (type == SearchType.enumSTTitleId)
			{
				for (int num14 = 0; num14 < aTaskTempl.m_PremTitles.Length; num14++)
				{
					if (aTaskTempl.m_PremTitles[num14].ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num14, GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_TITLES, aTaskTempl);
						return true;
					}
				}
				if (smethod_9(ME, indices, aTaskTempl, string_0))
				{
					return true;
				}
			}
			if (type == SearchType.enumSTTransWldId)
			{
				if (aTaskTempl.m_ulTransWldId.ToString() == string_0)
				{
					smethod_2(ME.treeView_tasks, indices);
					TaskElements.SelectElement(ME, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_TRANS_WLD_ID, aTaskTempl);
					return true;
				}
				if (smethod_3(ME, indices, aTaskTempl, string_0))
				{
					return true;
				}
			}
			if (type == SearchType.enumSTMonstersContrib)
			{
				for (int num15 = 0; num15 < aTaskTempl.m_MonstersContrib.Length; num15++)
				{
					if (aTaskTempl.m_MonstersContrib[num15].m_ulMonsterTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num15, GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTERS_CONTRIB, aTaskTempl);
						return true;
					}
				}
			}
			if (type == SearchType.enumSTPremItems)
			{
				for (int num16 = 0; num16 < aTaskTempl.m_PremItems.Length; num16++)
				{
					if (aTaskTempl.m_PremItems[num16].m_ulItemTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num16, GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_ITEMS, aTaskTempl);
						return true;
					}
				}
			}
			if (type == SearchType.enumSTGivenItems)
			{
				for (int num17 = 0; num17 < aTaskTempl.m_GivenItems.Length; num17++)
				{
					if (aTaskTempl.m_GivenItems[num17].m_ulItemTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num17, GlobalData.TASKELEMENTS_TYPE.TASKS_GIVEN_ITEMS, aTaskTempl);
						return true;
					}
				}
			}
			if (type == SearchType.enumSTPremTitles)
			{
				for (int num18 = 0; num18 < aTaskTempl.m_PremTitles.Length; num18++)
				{
					if (aTaskTempl.m_PremTitles[num18].ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num18, GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_TITLES, aTaskTempl);
						return true;
					}
				}
			}
			if (type == SearchType.enumSTMonsterWantedMonster)
			{
				for (int num19 = 0; num19 < aTaskTempl.m_MonsterWanted.Length; num19++)
				{
					if (aTaskTempl.m_MonsterWanted[num19].m_ulMonsterTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num19, GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_WANTED_MONSTERS, aTaskTempl);
						return true;
					}
				}
				for (int num20 = 0; num20 < aTaskTempl.m_MonsterUnwanted.Length; num20++)
				{
					if (aTaskTempl.m_MonsterUnwanted[num20].m_ulMonsterTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num20, GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_UNWANTED_MONSTERS, aTaskTempl);
						return true;
					}
				}
			}
			if (type == SearchType.enumSTMonsterWantedItem)
			{
				for (int num21 = 0; num21 < aTaskTempl.m_MonsterWanted.Length; num21++)
				{
					if (aTaskTempl.m_MonsterWanted[num21].m_ulDropItemId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num21, GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_WANTED_ITEMS, aTaskTempl);
						return true;
					}
				}
				for (int num22 = 0; num22 < aTaskTempl.m_MonsterUnwanted.Length; num22++)
				{
					if (aTaskTempl.m_MonsterUnwanted[num22].m_ulDropItemId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num22, GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_UNWANTED_ITEMS, aTaskTempl);
						return true;
					}
				}
			}
			if (type == SearchType.enumSTItemsWanted)
			{
				for (int num23 = 0; num23 < aTaskTempl.m_ItemsWanted.Length; num23++)
				{
					if (aTaskTempl.m_ItemsWanted[num23].m_ulItemTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num23, GlobalData.TASKELEMENTS_TYPE.TASKS_ITEMS_WANTED, aTaskTempl);
						return true;
					}
				}
			}
			if (type == SearchType.enumSTTaskChar)
			{
				if (Settings.Fields.IgnoreColorCod)
				{
					for (int num24 = 0; num24 < aTaskTempl.m_pTaskChar.Length; num24++)
					{
						if (smethod_0(GlobalFunctions.ColorClean(tasksConvert.ShortsToUnicodeString(aTaskTempl.m_pTaskChar[num24])), string_0))
						{
							smethod_2(ME.treeView_tasks, indices);
							ME.tabControl1.SelectedIndex = 3;
							ME.dataGridView_m_pTaskChar.CurrentCell = ME.dataGridView_m_pTaskChar.Rows[num24].Cells[0];
							return true;
						}
					}
				}
				else
				{
					for (int num25 = 0; num25 < aTaskTempl.m_pTaskChar.Length; num25++)
					{
						if (smethod_0(tasksConvert.ShortsToUnicodeString(aTaskTempl.m_pTaskChar[num25]), string_0))
						{
							smethod_2(ME.treeView_tasks, indices);
							ME.tabControl1.SelectedIndex = 3;
							ME.dataGridView_m_pTaskChar.CurrentCell = ME.dataGridView_m_pTaskChar.Rows[num25].Cells[0];
							return true;
						}
					}
				}
				if (Settings.Fields.IgnoreColorCod)
				{
					for (int num26 = 0; num26 < aTaskTempl.PersonTaskChar.Length; num26++)
					{
						if (smethod_0(GlobalFunctions.ColorClean(tasksConvert.ShortsToUnicodeString(aTaskTempl.PersonTaskChar[num26])), string_0))
						{
							smethod_2(ME.treeView_tasks, indices);
							ME.tabControl1.SelectedIndex = 3;
							ME.dataGridView_PersonTaskChar.CurrentCell = ME.dataGridView_PersonTaskChar.Rows[num26].Cells[0];
							return true;
						}
					}
				}
				else
				{
					for (int num27 = 0; num27 < aTaskTempl.PersonTaskChar.Length; num27++)
					{
						if (smethod_0(tasksConvert.ShortsToUnicodeString(aTaskTempl.PersonTaskChar[num27]), string_0))
						{
							smethod_2(ME.treeView_tasks, indices);
							ME.tabControl1.SelectedIndex = 3;
							ME.dataGridView_PersonTaskChar.CurrentCell = ME.dataGridView_PersonTaskChar.Rows[num27].Cells[0];
							return true;
						}
					}
				}
			}
			if (type == SearchType.enumSTHomeItemsWanted)
			{
				for (int num28 = 0; num28 < aTaskTempl.m_HomeItemsWanted.Length; num28++)
				{
					if (aTaskTempl.m_HomeItemsWanted[num28].m_ulHomeItemTid.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num28, GlobalData.TASKELEMENTS_TYPE.TASKS_HOME_ITEMS_WANTED, aTaskTempl);
						return true;
					}
				}
			}
			if (type == SearchType.enumSTAwardItems && smethod_5(ME, indices, aTaskTempl, string_0))
			{
				return true;
			}
			if (type == SearchType.enumSTSummonedMonsters)
			{
				for (int num29 = 0; num29 < aTaskTempl.m_ulPropSummonedMonsters; num29++)
				{
					if (aTaskTempl.PropMonsterSummoned.m_Monsters[num29].m_ulMonsterTemplId.ToString() == string_0)
					{
						smethod_2(ME.treeView_tasks, indices);
						TaskElements.SelectElement(ME, 0, 0, num29, GlobalData.TASKELEMENTS_TYPE.TASKS_PROP_SUMMONED_MONSTERS, aTaskTempl);
						return true;
					}
				}
				if (smethod_6(ME, indices, aTaskTempl, string_0))
				{
					return true;
				}
			}
			if (type == SearchType.enumSTRankingAward && smethod_7(ME, indices, aTaskTempl, string_0))
			{
				return true;
			}
			if (type == SearchType.enumSTTitleAward && smethod_9(ME, indices, aTaskTempl, string_0))
			{
				return true;
			}
			if (type == SearchType.enumSTTexts)
			{
				if (Settings.Fields.IgnoreColorCod)
				{
					if (smethod_0(GlobalFunctions.ColorClean(aTaskTempl.Descript), string_0))
					{
						smethod_2(ME.treeView_tasks, indices);
						ME.tabControl1.SelectedIndex = 5;
						return true;
					}
				}
				else if (smethod_0(aTaskTempl.Descript, string_0))
				{
					smethod_2(ME.treeView_tasks, indices);
					ME.tabControl1.SelectedIndex = 5;
					return true;
				}
				if (Settings.Fields.IgnoreColorCod)
				{
					if (smethod_0(GlobalFunctions.ColorClean(aTaskTempl.OkText), string_0))
					{
						smethod_2(ME.treeView_tasks, indices);
						ME.tabControl1.SelectedIndex = 5;
						return true;
					}
				}
				else if (smethod_0(aTaskTempl.OkText, string_0))
				{
					smethod_2(ME.treeView_tasks, indices);
					ME.tabControl1.SelectedIndex = 5;
					return true;
				}
				if (Settings.Fields.IgnoreColorCod)
				{
					if (smethod_0(GlobalFunctions.ColorClean(aTaskTempl.NoText), string_0))
					{
						smethod_2(ME.treeView_tasks, indices);
						ME.tabControl1.SelectedIndex = 5;
						return true;
					}
				}
				else if (smethod_0(aTaskTempl.NoText, string_0))
				{
					smethod_2(ME.treeView_tasks, indices);
					ME.tabControl1.SelectedIndex = 5;
					return true;
				}
				if (Settings.Fields.IgnoreColorCod)
				{
					if (smethod_0(GlobalFunctions.ColorClean(aTaskTempl.Tribute), string_0))
					{
						smethod_2(ME.treeView_tasks, indices);
						ME.tabControl1.SelectedIndex = 5;
						return true;
					}
				}
				else if (smethod_0(aTaskTempl.Tribute, string_0))
				{
					smethod_2(ME.treeView_tasks, indices);
					ME.tabControl1.SelectedIndex = 5;
					return true;
				}
				if (smethod_12(ME, indices, aTaskTempl.m_DelvTaskTalk, 0, string_0))
				{
					return true;
				}
				if (smethod_12(ME, indices, aTaskTempl.m_UnqualifiedTaskTalk, 1, string_0))
				{
					return true;
				}
				if (smethod_12(ME, indices, aTaskTempl.m_DelvItemTalk, 2, string_0))
				{
					return true;
				}
				if (smethod_12(ME, indices, aTaskTempl.m_ExeTalk, 3, string_0))
				{
					return true;
				}
				if (smethod_12(ME, indices, aTaskTempl.m_AwardTalk, 4, string_0))
				{
					return true;
				}
				if (smethod_11(ME, indices, aTaskTempl.m_DelvTaskTalk, 0, string_0))
				{
					return true;
				}
				if (smethod_11(ME, indices, aTaskTempl.m_UnqualifiedTaskTalk, 1, string_0))
				{
					return true;
				}
				if (smethod_11(ME, indices, aTaskTempl.m_DelvItemTalk, 2, string_0))
				{
					return true;
				}
				if (smethod_11(ME, indices, aTaskTempl.m_ExeTalk, 3, string_0))
				{
					return true;
				}
				if (smethod_11(ME, indices, aTaskTempl.m_AwardTalk, 4, string_0))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static int[] next_treeNode(TreeNode selectedNode)
	{
		if (selectedNode == null)
		{
			return null;
		}
		int[] array = null;
		int[] array2 = new int[1];
		array = array2;
		if (selectedNode.Index > -1)
		{
			array = new int[selectedNode.Level + 1];
			bool flag = false;
			TreeNode treeNode = selectedNode;
			for (int num = array.Length - 1; num > -1; num--)
			{
				array[num] = treeNode.Index;
				if (treeNode == selectedNode && selectedNode.Nodes.Count > 0)
				{
					flag = true;
				}
				if (!flag)
				{
					if (treeNode.NextNode != null)
					{
						array[num]++;
						flag = true;
					}
					else
					{
						Array.Resize(ref array, array.Length - 1);
					}
				}
				treeNode = treeNode.Parent;
			}
			treeNode = selectedNode;
			while (treeNode.Nodes.Count > 0)
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = 0;
				treeNode = treeNode.Nodes[0];
			}
		}
		return array;
	}

	public static int[] next_task(int[] currentIndices)
	{
		int[] array = null;
		if (currentIndices != null && currentIndices.Length != 0)
		{
			array = new int[currentIndices.Length];
			ATaskTempl aTaskTempl = smethod_1(currentIndices);
			if (aTaskTempl == null)
			{
				return new int[0];
			}
			currentIndices.CopyTo(array, 0);
			if (aTaskTempl.m_nSubCount > 0)
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = 0;
				return array;
			}
			int num = array.Length - 1;
			while (num > 0)
			{
				ATaskTempl aTaskTempl2 = smethod_1(array);
				if (aTaskTempl2 == null || aTaskTempl2.m_ulNextSibling == 0)
				{
					Array.Resize(ref array, array.Length - 1);
					num--;
					continue;
				}
				array[num]++;
				return array;
			}
			if (GProD.Tasks != null && array[0] >= 0 && array[0] < GProD.Tasks.Length - 1)
			{
				array[0]++;
				return array;
			}
		}
		return new int[0];
	}

	private static ATaskTempl smethod_1(int[] int_0)
	{
		if (int_0 != null && int_0.Length != 0 && GProD.Tasks != null)
		{
			if (int_0[0] >= 0 && int_0[0] < GProD.Tasks.Length)
			{
				ATaskTempl aTaskTempl = GProD.Tasks[int_0[0]];
				if (aTaskTempl == null)
				{
					return null;
				}
				int num = 1;
				while (true)
				{
					if (num < int_0.Length)
					{
						if (aTaskTempl.pSub == null || int_0[num] < 0 || int_0[num] >= aTaskTempl.pSub.Length)
						{
							break;
						}
						aTaskTempl = aTaskTempl.pSub[int_0[num]];
						if (aTaskTempl != null)
						{
							num++;
							continue;
						}
						return null;
					}
					return aTaskTempl;
				}
				return null;
			}
			return null;
		}
		return null;
	}

	private static void smethod_2(TreeView treeView_0, int[] int_0)
	{
		if (treeView_0 == null || int_0 == null || int_0.Length == 0 || int_0[0] < 0 || int_0[0] >= treeView_0.Nodes.Count || int_0.Length == 0)
		{
			return;
		}
		TreeNode treeNode = treeView_0.Nodes[int_0[0]];
		int num = 1;
		while (true)
		{
			if (num < int_0.Length)
			{
				if (int_0[num] >= 0 && int_0[num] < treeNode.Nodes.Count)
				{
					treeNode = treeNode.Nodes[int_0[num]];
					num++;
					continue;
				}
				break;
			}
			treeView_0.SelectedNode = treeNode;
			break;
		}
	}

	private static bool smethod_3(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int[] int_0, ATaskTempl ataskTempl_0, string string_0)
	{
		if (ataskTempl_0.m_Award_S.m_ulTransWldId.ToString() == string_0)
		{
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_TRANS_WLD_ID, bool_0: true);
		}
		if (ataskTempl_0.m_Award_F.m_ulTransWldId.ToString() == string_0)
		{
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_TRANS_WLD_ID, bool_0: true);
		}
		int num = 0;
		while (true)
		{
			if (num < ataskTempl_0.m_AwByRatio_S.m_Awards.Length)
			{
				if (ataskTempl_0.m_AwByRatio_S.m_Awards[num].m_ulTransWldId.ToString() == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < ataskTempl_0.m_AwByRatio_F.m_Awards.Length)
				{
					if (ataskTempl_0.m_AwByRatio_F.m_Awards[num2].m_ulTransWldId.ToString() == string_0)
					{
						break;
					}
					num2++;
					continue;
				}
				int num3 = 0;
				while (true)
				{
					if (num3 < ataskTempl_0.m_AwByItems_S.m_Awards.Length)
					{
						if (ataskTempl_0.m_AwByItems_S.m_Awards[num3].m_ulTransWldId.ToString() == string_0)
						{
							break;
						}
						num3++;
						continue;
					}
					int num4 = 0;
					while (true)
					{
						if (num4 < ataskTempl_0.m_AwByItems_F.m_Awards.Length)
						{
							if (ataskTempl_0.m_AwByItems_F.m_Awards[num4].m_ulTransWldId.ToString() == string_0)
							{
								break;
							}
							num4++;
							continue;
						}
						int num5 = 0;
						while (true)
						{
							if (num5 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards.Length)
							{
								if (ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num5].m_ulTransWldId.ToString() == string_0)
								{
									break;
								}
								num5++;
								continue;
							}
							int num6 = 0;
							while (true)
							{
								if (num6 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards.Length)
								{
									if (ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num6].m_ulTransWldId.ToString() == string_0)
									{
										break;
									}
									num6++;
									continue;
								}
								int num7 = 0;
								while (true)
								{
									if (num7 < ataskTempl_0.AwByCarrierHp_S.m_Awards.Length)
									{
										if (ataskTempl_0.AwByCarrierHp_S.m_Awards[num7].m_ulTransWldId.ToString() == string_0)
										{
											break;
										}
										num7++;
										continue;
									}
									int num8 = 0;
									while (true)
									{
										if (num8 < ataskTempl_0.AwByCarrierHp_F.m_Awards.Length)
										{
											if (ataskTempl_0.AwByCarrierHp_F.m_Awards[num8].m_ulTransWldId.ToString() == string_0)
											{
												break;
											}
											num8++;
											continue;
										}
										int num9 = 0;
										while (true)
										{
											if (num9 < ataskTempl_0.AwByVar_S.m_Awards.Length)
											{
												if (ataskTempl_0.AwByVar_S.m_Awards[num9].m_ulTransWldId.ToString() == string_0)
												{
													break;
												}
												num9++;
												continue;
											}
											int num10 = 0;
											while (true)
											{
												if (num10 < ataskTempl_0.AwByVar_F.m_Awards.Length)
												{
													if (ataskTempl_0.AwByVar_F.m_Awards[num10].m_ulTransWldId.ToString() == string_0)
													{
														break;
													}
													num10++;
													continue;
												}
												return false;
											}
											return smethod_13(mainEditor_0, int_0, ataskTempl_0, num10, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_TRANS_WLD_ID, bool_0: false);
										}
										return smethod_13(mainEditor_0, int_0, ataskTempl_0, num9, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_TRANS_WLD_ID, bool_0: false);
									}
									return smethod_13(mainEditor_0, int_0, ataskTempl_0, num8, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_TRANS_WLD_ID, bool_0: false);
								}
								return smethod_13(mainEditor_0, int_0, ataskTempl_0, num7, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_TRANS_WLD_ID, bool_0: false);
							}
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num6, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_TRANS_WLD_ID, bool_0: false);
						}
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num5, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_TRANS_WLD_ID, bool_0: false);
					}
					return smethod_13(mainEditor_0, int_0, ataskTempl_0, num4, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_TRANS_WLD_ID, bool_0: false);
				}
				return smethod_13(mainEditor_0, int_0, ataskTempl_0, num3, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_TRANS_WLD_ID, bool_0: false);
			}
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, num2, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_TRANS_WLD_ID, bool_0: false);
		}
		return smethod_13(mainEditor_0, int_0, ataskTempl_0, num, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_TRANS_WLD_ID, bool_0: false);
	}

	private static bool smethod_4(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int[] int_0, ATaskTempl ataskTempl_0, string string_0)
	{
		if (ataskTempl_0.m_Award_S.m_lMonsCtrl.ToString() == string_0)
		{
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_MONS_CTRL, bool_0: true);
		}
		if (ataskTempl_0.m_Award_F.m_lMonsCtrl.ToString() == string_0)
		{
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_MONS_CTRL, bool_0: true);
		}
		int num = 0;
		while (true)
		{
			if (num < ataskTempl_0.m_AwByRatio_S.m_Awards.Length)
			{
				if (ataskTempl_0.m_AwByRatio_S.m_Awards[num].m_lMonsCtrl.ToString() == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < ataskTempl_0.m_AwByRatio_F.m_Awards.Length)
				{
					if (ataskTempl_0.m_AwByRatio_F.m_Awards[num2].m_lMonsCtrl.ToString() == string_0)
					{
						break;
					}
					num2++;
					continue;
				}
				int num3 = 0;
				while (true)
				{
					if (num3 < ataskTempl_0.m_AwByItems_S.m_Awards.Length)
					{
						if (ataskTempl_0.m_AwByItems_S.m_Awards[num3].m_lMonsCtrl.ToString() == string_0)
						{
							break;
						}
						num3++;
						continue;
					}
					int num4 = 0;
					while (true)
					{
						if (num4 < ataskTempl_0.m_AwByItems_F.m_Awards.Length)
						{
							if (ataskTempl_0.m_AwByItems_F.m_Awards[num4].m_lMonsCtrl.ToString() == string_0)
							{
								break;
							}
							num4++;
							continue;
						}
						int num5 = 0;
						while (true)
						{
							if (num5 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards.Length)
							{
								if (ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num5].m_lMonsCtrl.ToString() == string_0)
								{
									break;
								}
								num5++;
								continue;
							}
							int num6 = 0;
							while (true)
							{
								if (num6 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards.Length)
								{
									if (ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num6].m_lMonsCtrl.ToString() == string_0)
									{
										break;
									}
									num6++;
									continue;
								}
								int num7 = 0;
								while (true)
								{
									if (num7 < ataskTempl_0.AwByCarrierHp_S.m_Awards.Length)
									{
										if (ataskTempl_0.AwByCarrierHp_S.m_Awards[num7].m_lMonsCtrl.ToString() == string_0)
										{
											break;
										}
										num7++;
										continue;
									}
									int num8 = 0;
									while (true)
									{
										if (num8 < ataskTempl_0.AwByCarrierHp_F.m_Awards.Length)
										{
											if (ataskTempl_0.AwByCarrierHp_F.m_Awards[num8].m_lMonsCtrl.ToString() == string_0)
											{
												break;
											}
											num8++;
											continue;
										}
										int num9 = 0;
										while (true)
										{
											if (num9 < ataskTempl_0.AwByVar_S.m_Awards.Length)
											{
												if (ataskTempl_0.AwByVar_S.m_Awards[num9].m_lMonsCtrl.ToString() == string_0)
												{
													break;
												}
												num9++;
												continue;
											}
											int num10 = 0;
											while (true)
											{
												if (num10 < ataskTempl_0.AwByVar_F.m_Awards.Length)
												{
													if (ataskTempl_0.AwByVar_F.m_Awards[num10].m_lMonsCtrl.ToString() == string_0)
													{
														break;
													}
													num10++;
													continue;
												}
												return false;
											}
											return smethod_13(mainEditor_0, int_0, ataskTempl_0, num10, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_MONS_CTRL, bool_0: false);
										}
										return smethod_13(mainEditor_0, int_0, ataskTempl_0, num9, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_MONS_CTRL, bool_0: false);
									}
									return smethod_13(mainEditor_0, int_0, ataskTempl_0, num8, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_MONS_CTRL, bool_0: false);
								}
								return smethod_13(mainEditor_0, int_0, ataskTempl_0, num7, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_MONS_CTRL, bool_0: false);
							}
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num6, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_MONS_CTRL, bool_0: false);
						}
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num5, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_MONS_CTRL, bool_0: false);
					}
					return smethod_13(mainEditor_0, int_0, ataskTempl_0, num4, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_MONS_CTRL, bool_0: false);
				}
				return smethod_13(mainEditor_0, int_0, ataskTempl_0, num3, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_MONS_CTRL, bool_0: false);
			}
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, num2, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_MONS_CTRL, bool_0: false);
		}
		return smethod_13(mainEditor_0, int_0, ataskTempl_0, num, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_MONS_CTRL, bool_0: false);
	}

	private static bool smethod_5(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int[] int_0, ATaskTempl ataskTempl_0, string string_0)
	{
		for (int i = 0; i < ataskTempl_0.m_Award_S.m_CandItems.Length; i++)
		{
			for (int j = 0; j < ataskTempl_0.m_Award_S.m_CandItems[i].m_AwardItems.Length; j++)
			{
				if (ataskTempl_0.m_Award_S.m_CandItems[i].m_AwardItems[j].m_ulItemTemplId.ToString() == string_0)
				{
					return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, i, j, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_CAND_ITEMS, bool_0: true);
				}
			}
		}
		for (int k = 0; k < ataskTempl_0.m_Award_F.m_CandItems.Length; k++)
		{
			for (int l = 0; l < ataskTempl_0.m_Award_F.m_CandItems[k].m_AwardItems.Length; l++)
			{
				if (ataskTempl_0.m_Award_F.m_CandItems[k].m_AwardItems[l].m_ulItemTemplId.ToString() == string_0)
				{
					return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, k, l, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_CAND_ITEMS, bool_0: true);
				}
			}
		}
		for (int m = 0; m < ataskTempl_0.m_AwByRatio_S.m_Awards.Length; m++)
		{
			for (int n = 0; n < ataskTempl_0.m_AwByRatio_S.m_Awards[m].m_CandItems.Length; n++)
			{
				for (int num = 0; num < ataskTempl_0.m_AwByRatio_S.m_Awards[m].m_CandItems[n].m_AwardItems.Length; num++)
				{
					if (ataskTempl_0.m_AwByRatio_S.m_Awards[m].m_CandItems[n].m_AwardItems[num].m_ulItemTemplId.ToString() == string_0)
					{
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, m, n, num, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_CAND_ITEMS, bool_0: false);
					}
				}
			}
		}
		for (int num2 = 0; num2 < ataskTempl_0.m_AwByRatio_F.m_Awards.Length; num2++)
		{
			for (int num3 = 0; num3 < ataskTempl_0.m_AwByRatio_F.m_Awards[num2].m_CandItems.Length; num3++)
			{
				for (int num4 = 0; num4 < ataskTempl_0.m_AwByRatio_F.m_Awards[num2].m_CandItems[num3].m_AwardItems.Length; num4++)
				{
					if (ataskTempl_0.m_AwByRatio_F.m_Awards[num2].m_CandItems[num3].m_AwardItems[num4].m_ulItemTemplId.ToString() == string_0)
					{
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num2, num3, num4, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_CAND_ITEMS, bool_0: false);
					}
				}
			}
		}
		for (int num5 = 0; num5 < ataskTempl_0.m_AwByItems_S.m_Awards.Length; num5++)
		{
			for (int num6 = 0; num6 < ataskTempl_0.m_AwByItems_S.m_Awards[num5].m_CandItems.Length; num6++)
			{
				for (int num7 = 0; num7 < ataskTempl_0.m_AwByItems_S.m_Awards[num5].m_CandItems[num6].m_AwardItems.Length; num7++)
				{
					if (ataskTempl_0.m_AwByItems_S.m_Awards[num5].m_CandItems[num6].m_AwardItems[num7].m_ulItemTemplId.ToString() == string_0)
					{
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num5, num6, num7, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_CAND_ITEMS, bool_0: false);
					}
				}
			}
		}
		for (int num8 = 0; num8 < ataskTempl_0.m_AwByItems_F.m_Awards.Length; num8++)
		{
			for (int num9 = 0; num9 < ataskTempl_0.m_AwByItems_F.m_Awards[num8].m_CandItems.Length; num9++)
			{
				for (int num10 = 0; num10 < ataskTempl_0.m_AwByItems_F.m_Awards[num8].m_CandItems[num9].m_AwardItems.Length; num10++)
				{
					if (ataskTempl_0.m_AwByItems_F.m_Awards[num8].m_CandItems[num9].m_AwardItems[num10].m_ulItemTemplId.ToString() == string_0)
					{
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num8, num9, num10, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_CAND_ITEMS, bool_0: false);
					}
				}
			}
		}
		for (int num11 = 0; num11 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards.Length; num11++)
		{
			for (int num12 = 0; num12 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num11].m_CandItems.Length; num12++)
			{
				for (int num13 = 0; num13 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num11].m_CandItems[num12].m_AwardItems.Length; num13++)
				{
					if (ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num11].m_CandItems[num12].m_AwardItems[num13].m_ulItemTemplId.ToString() == string_0)
					{
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num11, num12, num13, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_CAND_ITEMS, bool_0: false);
					}
				}
			}
		}
		for (int num14 = 0; num14 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards.Length; num14++)
		{
			for (int num15 = 0; num15 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num14].m_CandItems.Length; num15++)
			{
				for (int num16 = 0; num16 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num14].m_CandItems[num15].m_AwardItems.Length; num16++)
				{
					if (ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num14].m_CandItems[num15].m_AwardItems[num16].m_ulItemTemplId.ToString() == string_0)
					{
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num14, num15, num16, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_CAND_ITEMS, bool_0: false);
					}
				}
			}
		}
		for (int num17 = 0; num17 < ataskTempl_0.AwByCarrierHp_S.m_Awards.Length; num17++)
		{
			for (int num18 = 0; num18 < ataskTempl_0.AwByCarrierHp_S.m_Awards[num17].m_CandItems.Length; num18++)
			{
				for (int num19 = 0; num19 < ataskTempl_0.AwByCarrierHp_S.m_Awards[num17].m_CandItems[num18].m_AwardItems.Length; num19++)
				{
					if (ataskTempl_0.AwByCarrierHp_S.m_Awards[num17].m_CandItems[num18].m_AwardItems[num19].m_ulItemTemplId.ToString() == string_0)
					{
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num17, num18, num19, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_CAND_ITEMS, bool_0: false);
					}
				}
			}
		}
		for (int num20 = 0; num20 < ataskTempl_0.AwByCarrierHp_F.m_Awards.Length; num20++)
		{
			for (int num21 = 0; num21 < ataskTempl_0.AwByCarrierHp_F.m_Awards[num20].m_CandItems.Length; num21++)
			{
				for (int num22 = 0; num22 < ataskTempl_0.AwByCarrierHp_F.m_Awards[num20].m_CandItems[num21].m_AwardItems.Length; num22++)
				{
					if (ataskTempl_0.AwByCarrierHp_F.m_Awards[num20].m_CandItems[num21].m_AwardItems[num22].m_ulItemTemplId.ToString() == string_0)
					{
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num20, num21, num22, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_CAND_ITEMS, bool_0: false);
					}
				}
			}
		}
		for (int num23 = 0; num23 < ataskTempl_0.AwByVar_S.m_Awards.Length; num23++)
		{
			for (int num24 = 0; num24 < ataskTempl_0.AwByVar_S.m_Awards[num23].m_CandItems.Length; num24++)
			{
				for (int num25 = 0; num25 < ataskTempl_0.AwByVar_S.m_Awards[num23].m_CandItems[num24].m_AwardItems.Length; num25++)
				{
					if (ataskTempl_0.AwByVar_S.m_Awards[num23].m_CandItems[num24].m_AwardItems[num25].m_ulItemTemplId.ToString() == string_0)
					{
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num23, num24, num25, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_CAND_ITEMS, bool_0: false);
					}
				}
			}
		}
		for (int num26 = 0; num26 < ataskTempl_0.AwByVar_F.m_Awards.Length; num26++)
		{
			for (int num27 = 0; num27 < ataskTempl_0.AwByVar_F.m_Awards[num26].m_CandItems.Length; num27++)
			{
				for (int num28 = 0; num28 < ataskTempl_0.AwByVar_F.m_Awards[num26].m_CandItems[num27].m_AwardItems.Length; num28++)
				{
					if (ataskTempl_0.AwByVar_F.m_Awards[num26].m_CandItems[num27].m_AwardItems[num28].m_ulItemTemplId.ToString() == string_0)
					{
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num26, num27, num28, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_CAND_ITEMS, bool_0: false);
					}
				}
			}
		}
		return false;
	}

	private static bool smethod_6(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int[] int_0, ATaskTempl ataskTempl_0, string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < ataskTempl_0.m_Award_S.m_SummonedMonsters.m_Monsters.Length)
			{
				if (ataskTempl_0.m_Award_S.m_SummonedMonsters.m_Monsters[num].m_ulMonsterTemplId.ToString() == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < ataskTempl_0.m_Award_F.m_SummonedMonsters.m_Monsters.Length)
				{
					if (ataskTempl_0.m_Award_F.m_SummonedMonsters.m_Monsters[num2].m_ulMonsterTemplId.ToString() == string_0)
					{
						break;
					}
					num2++;
					continue;
				}
				for (int i = 0; i < ataskTempl_0.m_AwByRatio_S.m_Awards.Length; i++)
				{
					for (int j = 0; j < ataskTempl_0.m_AwByRatio_S.m_Awards[i].m_SummonedMonsters.m_Monsters.Length; j++)
					{
						if (ataskTempl_0.m_AwByRatio_S.m_Awards[i].m_SummonedMonsters.m_Monsters[j].m_ulMonsterTemplId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, i, 0, j, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_SUMMONED_MONSTERS, bool_0: false);
						}
					}
				}
				for (int k = 0; k < ataskTempl_0.m_AwByRatio_F.m_Awards.Length; k++)
				{
					for (int l = 0; l < ataskTempl_0.m_AwByRatio_F.m_Awards[k].m_SummonedMonsters.m_Monsters.Length; l++)
					{
						if (ataskTempl_0.m_AwByRatio_F.m_Awards[k].m_SummonedMonsters.m_Monsters[l].m_ulMonsterTemplId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, k, 0, l, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_SUMMONED_MONSTERS, bool_0: false);
						}
					}
				}
				for (int m = 0; m < ataskTempl_0.m_AwByItems_S.m_Awards.Length; m++)
				{
					for (int n = 0; n < ataskTempl_0.m_AwByItems_S.m_Awards[m].m_SummonedMonsters.m_Monsters.Length; n++)
					{
						if (ataskTempl_0.m_AwByItems_S.m_Awards[m].m_SummonedMonsters.m_Monsters[n].m_ulMonsterTemplId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, m, 0, n, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_SUMMONED_MONSTERS, bool_0: false);
						}
					}
				}
				for (int num3 = 0; num3 < ataskTempl_0.m_AwByItems_F.m_Awards.Length; num3++)
				{
					for (int num4 = 0; num4 < ataskTempl_0.m_AwByItems_F.m_Awards[num3].m_SummonedMonsters.m_Monsters.Length; num4++)
					{
						if (ataskTempl_0.m_AwByItems_F.m_Awards[num3].m_SummonedMonsters.m_Monsters[num4].m_ulMonsterTemplId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num3, 0, num4, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_SUMMONED_MONSTERS, bool_0: false);
						}
					}
				}
				for (int num5 = 0; num5 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards.Length; num5++)
				{
					for (int num6 = 0; num6 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num5].m_SummonedMonsters.m_Monsters.Length; num6++)
					{
						if (ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num5].m_SummonedMonsters.m_Monsters[num6].m_ulMonsterTemplId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num5, 0, num6, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_SUMMONED_MONSTERS, bool_0: false);
						}
					}
				}
				for (int num7 = 0; num7 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards.Length; num7++)
				{
					for (int num8 = 0; num8 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num7].m_SummonedMonsters.m_Monsters.Length; num8++)
					{
						if (ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num7].m_SummonedMonsters.m_Monsters[num8].m_ulMonsterTemplId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num7, 0, num8, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_SUMMONED_MONSTERS, bool_0: false);
						}
					}
				}
				for (int num9 = 0; num9 < ataskTempl_0.AwByCarrierHp_S.m_Awards.Length; num9++)
				{
					for (int num10 = 0; num10 < ataskTempl_0.AwByCarrierHp_S.m_Awards[num9].m_SummonedMonsters.m_Monsters.Length; num10++)
					{
						if (ataskTempl_0.AwByCarrierHp_S.m_Awards[num9].m_SummonedMonsters.m_Monsters[num10].m_ulMonsterTemplId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num9, 0, num10, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_SUMMONED_MONSTERS, bool_0: false);
						}
					}
				}
				for (int num11 = 0; num11 < ataskTempl_0.AwByCarrierHp_F.m_Awards.Length; num11++)
				{
					for (int num12 = 0; num12 < ataskTempl_0.AwByCarrierHp_F.m_Awards[num11].m_SummonedMonsters.m_Monsters.Length; num12++)
					{
						if (ataskTempl_0.AwByCarrierHp_F.m_Awards[num11].m_SummonedMonsters.m_Monsters[num12].m_ulMonsterTemplId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num11, 0, num12, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_SUMMONED_MONSTERS, bool_0: false);
						}
					}
				}
				for (int num13 = 0; num13 < ataskTempl_0.AwByVar_S.m_Awards.Length; num13++)
				{
					for (int num14 = 0; num14 < ataskTempl_0.AwByVar_S.m_Awards[num13].m_SummonedMonsters.m_Monsters.Length; num14++)
					{
						if (ataskTempl_0.AwByVar_S.m_Awards[num13].m_SummonedMonsters.m_Monsters[num14].m_ulMonsterTemplId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num13, 0, num14, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_SUMMONED_MONSTERS, bool_0: false);
						}
					}
				}
				for (int num15 = 0; num15 < ataskTempl_0.AwByVar_F.m_Awards.Length; num15++)
				{
					for (int num16 = 0; num16 < ataskTempl_0.AwByVar_F.m_Awards[num15].m_SummonedMonsters.m_Monsters.Length; num16++)
					{
						if (ataskTempl_0.AwByVar_F.m_Awards[num15].m_SummonedMonsters.m_Monsters[num16].m_ulMonsterTemplId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num15, 0, num16, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_SUMMONED_MONSTERS, bool_0: false);
						}
					}
				}
				return false;
			}
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, num2, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_SUMMONED_MONSTERS, bool_0: true);
		}
		return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, num, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_SUMMONED_MONSTERS, bool_0: true);
	}

	private static bool smethod_7(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int[] int_0, ATaskTempl ataskTempl_0, string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < ataskTempl_0.m_Award_S.m_PQRankingAward.m_RankingAward.Length)
			{
				if (ataskTempl_0.m_Award_S.m_PQRankingAward.m_RankingAward[num].m_ulAwardItemId.ToString() == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < ataskTempl_0.m_Award_F.m_PQRankingAward.m_RankingAward.Length)
				{
					if (ataskTempl_0.m_Award_F.m_PQRankingAward.m_RankingAward[num2].m_ulAwardItemId.ToString() == string_0)
					{
						break;
					}
					num2++;
					continue;
				}
				for (int i = 0; i < ataskTempl_0.m_AwByRatio_S.m_Awards.Length; i++)
				{
					for (int j = 0; j < ataskTempl_0.m_AwByRatio_S.m_Awards[i].m_PQRankingAward.m_RankingAward.Length; j++)
					{
						if (ataskTempl_0.m_AwByRatio_S.m_Awards[i].m_PQRankingAward.m_RankingAward[j].m_ulAwardItemId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, i, 0, j, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_PQ_RANKING_AWARD, bool_0: false);
						}
					}
				}
				for (int k = 0; k < ataskTempl_0.m_AwByRatio_F.m_Awards.Length; k++)
				{
					for (int l = 0; l < ataskTempl_0.m_AwByRatio_F.m_Awards[k].m_PQRankingAward.m_RankingAward.Length; l++)
					{
						if (ataskTempl_0.m_AwByRatio_F.m_Awards[k].m_PQRankingAward.m_RankingAward[l].m_ulAwardItemId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, k, 0, l, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_PQ_RANKING_AWARD, bool_0: false);
						}
					}
				}
				for (int m = 0; m < ataskTempl_0.m_AwByItems_S.m_Awards.Length; m++)
				{
					for (int n = 0; n < ataskTempl_0.m_AwByItems_S.m_Awards[m].m_PQRankingAward.m_RankingAward.Length; n++)
					{
						if (ataskTempl_0.m_AwByItems_S.m_Awards[m].m_PQRankingAward.m_RankingAward[n].m_ulAwardItemId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, m, 0, n, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_PQ_RANKING_AWARD, bool_0: false);
						}
					}
				}
				for (int num3 = 0; num3 < ataskTempl_0.m_AwByItems_F.m_Awards.Length; num3++)
				{
					for (int num4 = 0; num4 < ataskTempl_0.m_AwByItems_F.m_Awards[num3].m_PQRankingAward.m_RankingAward.Length; num4++)
					{
						if (ataskTempl_0.m_AwByItems_F.m_Awards[num3].m_PQRankingAward.m_RankingAward[num4].m_ulAwardItemId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num3, 0, num4, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_PQ_RANKING_AWARD, bool_0: false);
						}
					}
				}
				for (int num5 = 0; num5 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards.Length; num5++)
				{
					for (int num6 = 0; num6 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num5].m_PQRankingAward.m_RankingAward.Length; num6++)
					{
						if (ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num5].m_PQRankingAward.m_RankingAward[num6].m_ulAwardItemId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num5, 0, num6, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_PQ_RANKING_AWARD, bool_0: false);
						}
					}
				}
				for (int num7 = 0; num7 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards.Length; num7++)
				{
					for (int num8 = 0; num8 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num7].m_PQRankingAward.m_RankingAward.Length; num8++)
					{
						if (ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num7].m_PQRankingAward.m_RankingAward[num8].m_ulAwardItemId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num7, 0, num8, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_PQ_RANKING_AWARD, bool_0: false);
						}
					}
				}
				for (int num9 = 0; num9 < ataskTempl_0.AwByCarrierHp_S.m_Awards.Length; num9++)
				{
					for (int num10 = 0; num10 < ataskTempl_0.AwByCarrierHp_S.m_Awards[num9].m_PQRankingAward.m_RankingAward.Length; num10++)
					{
						if (ataskTempl_0.AwByCarrierHp_S.m_Awards[num9].m_PQRankingAward.m_RankingAward[num10].m_ulAwardItemId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num9, 0, num10, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_PQ_RANKING_AWARD, bool_0: false);
						}
					}
				}
				for (int num11 = 0; num11 < ataskTempl_0.AwByCarrierHp_F.m_Awards.Length; num11++)
				{
					for (int num12 = 0; num12 < ataskTempl_0.AwByCarrierHp_F.m_Awards[num11].m_PQRankingAward.m_RankingAward.Length; num12++)
					{
						if (ataskTempl_0.AwByCarrierHp_F.m_Awards[num11].m_PQRankingAward.m_RankingAward[num12].m_ulAwardItemId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num11, 0, num12, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_PQ_RANKING_AWARD, bool_0: false);
						}
					}
				}
				for (int num13 = 0; num13 < ataskTempl_0.AwByVar_S.m_Awards.Length; num13++)
				{
					for (int num14 = 0; num14 < ataskTempl_0.AwByVar_S.m_Awards[num13].m_PQRankingAward.m_RankingAward.Length; num14++)
					{
						if (ataskTempl_0.AwByVar_S.m_Awards[num13].m_PQRankingAward.m_RankingAward[num14].m_ulAwardItemId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num13, 0, num14, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_PQ_RANKING_AWARD, bool_0: false);
						}
					}
				}
				for (int num15 = 0; num15 < ataskTempl_0.AwByVar_F.m_Awards.Length; num15++)
				{
					for (int num16 = 0; num16 < ataskTempl_0.AwByVar_F.m_Awards[num15].m_PQRankingAward.m_RankingAward.Length; num16++)
					{
						if (ataskTempl_0.AwByVar_F.m_Awards[num15].m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num15, 0, num16, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_PQ_RANKING_AWARD, bool_0: false);
						}
					}
				}
				return false;
			}
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, num2, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_PQ_RANKING_AWARD, bool_0: true);
		}
		return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, num, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_PQ_RANKING_AWARD, bool_0: true);
	}

	private static bool smethod_8(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int[] int_0, ATaskTempl ataskTempl_0, string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < ataskTempl_0.m_Award_S.m_plChangeKey.Length)
			{
				if (ataskTempl_0.m_Award_S.m_plChangeKey[num].ToString() == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < ataskTempl_0.m_Award_F.m_plChangeKey.Length)
				{
					if (ataskTempl_0.m_Award_F.m_plChangeKey[num2].ToString() == string_0)
					{
						break;
					}
					num2++;
					continue;
				}
				for (int i = 0; i < ataskTempl_0.m_AwByRatio_S.m_Awards.Length; i++)
				{
					for (int j = 0; j < ataskTempl_0.m_AwByRatio_S.m_Awards[i].m_plChangeKey.Length; j++)
					{
						if (ataskTempl_0.m_AwByRatio_S.m_Awards[i].m_plChangeKey[j].ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, i, 0, j, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_CHANGE_KEY, bool_0: false);
						}
					}
				}
				for (int k = 0; k < ataskTempl_0.m_AwByRatio_F.m_Awards.Length; k++)
				{
					for (int l = 0; l < ataskTempl_0.m_AwByRatio_F.m_Awards[k].m_plChangeKey.Length; l++)
					{
						if (ataskTempl_0.m_AwByRatio_F.m_Awards[k].m_plChangeKey[l].ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, k, 0, l, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_CHANGE_KEY, bool_0: false);
						}
					}
				}
				for (int m = 0; m < ataskTempl_0.m_AwByItems_S.m_Awards.Length; m++)
				{
					for (int n = 0; n < ataskTempl_0.m_AwByItems_S.m_Awards[m].m_plChangeKey.Length; n++)
					{
						if (ataskTempl_0.m_AwByItems_S.m_Awards[m].m_plChangeKey[n].ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, m, 0, n, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_CHANGE_KEY, bool_0: false);
						}
					}
				}
				for (int num3 = 0; num3 < ataskTempl_0.m_AwByItems_F.m_Awards.Length; num3++)
				{
					for (int num4 = 0; num4 < ataskTempl_0.m_AwByItems_F.m_Awards[num3].m_plChangeKey.Length; num4++)
					{
						if (ataskTempl_0.m_AwByItems_F.m_Awards[num3].m_plChangeKey[num4].ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num3, 0, num4, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_CHANGE_KEY, bool_0: false);
						}
					}
				}
				for (int num5 = 0; num5 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards.Length; num5++)
				{
					for (int num6 = 0; num6 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num5].m_plChangeKey.Length; num6++)
					{
						if (ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num5].m_plChangeKey[num6].ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num5, 0, num6, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_CHANGE_KEY, bool_0: false);
						}
					}
				}
				for (int num7 = 0; num7 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards.Length; num7++)
				{
					for (int num8 = 0; num8 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num7].m_plChangeKey.Length; num8++)
					{
						if (ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num7].m_plChangeKey[num8].ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num7, 0, num8, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_CHANGE_KEY, bool_0: false);
						}
					}
				}
				for (int num9 = 0; num9 < ataskTempl_0.AwByCarrierHp_S.m_Awards.Length; num9++)
				{
					for (int num10 = 0; num10 < ataskTempl_0.AwByCarrierHp_S.m_Awards[num9].m_plChangeKey.Length; num10++)
					{
						if (ataskTempl_0.AwByCarrierHp_S.m_Awards[num9].m_plChangeKey[num10].ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num9, 0, num10, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_CHANGE_KEY, bool_0: false);
						}
					}
				}
				for (int num11 = 0; num11 < ataskTempl_0.AwByCarrierHp_F.m_Awards.Length; num11++)
				{
					for (int num12 = 0; num12 < ataskTempl_0.AwByCarrierHp_F.m_Awards[num11].m_plChangeKey.Length; num12++)
					{
						if (ataskTempl_0.AwByCarrierHp_F.m_Awards[num11].m_plChangeKey[num12].ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num11, 0, num12, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_CHANGE_KEY, bool_0: false);
						}
					}
				}
				for (int num13 = 0; num13 < ataskTempl_0.AwByVar_S.m_Awards.Length; num13++)
				{
					for (int num14 = 0; num14 < ataskTempl_0.AwByVar_S.m_Awards[num13].m_plChangeKey.Length; num14++)
					{
						if (ataskTempl_0.AwByVar_S.m_Awards[num13].m_plChangeKey[num14].ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num13, 0, num14, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_CHANGE_KEY, bool_0: false);
						}
					}
				}
				for (int num15 = 0; num15 < ataskTempl_0.AwByVar_F.m_Awards.Length; num15++)
				{
					for (int num16 = 0; num16 < ataskTempl_0.AwByVar_F.m_Awards[num15].m_plChangeKey.Length; num16++)
					{
						if (ataskTempl_0.AwByVar_F.m_Awards[num15].m_plChangeKey[num16].ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num15, 0, num16, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_CHANGE_KEY, bool_0: false);
						}
					}
				}
				return false;
			}
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, num2, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_CHANGE_KEY, bool_0: true);
		}
		return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, num, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_CHANGE_KEY, bool_0: true);
	}

	private static bool smethod_9(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int[] int_0, ATaskTempl ataskTempl_0, string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < ataskTempl_0.m_Award_S.m_pTitleAward.Length)
			{
				if (ataskTempl_0.m_Award_S.m_pTitleAward[num].m_ulTitleID.ToString() == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < ataskTempl_0.m_Award_F.m_pTitleAward.Length)
				{
					if (ataskTempl_0.m_Award_F.m_pTitleAward[num2].m_ulTitleID.ToString() == string_0)
					{
						break;
					}
					num2++;
					continue;
				}
				for (int i = 0; i < ataskTempl_0.m_AwByRatio_S.m_Awards.Length; i++)
				{
					for (int j = 0; j < ataskTempl_0.m_AwByRatio_S.m_Awards[i].m_pTitleAward.Length; j++)
					{
						if (ataskTempl_0.m_AwByRatio_S.m_Awards[i].m_pTitleAward[j].m_ulTitleID.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, i, 0, j, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_TITLE_AWARD, bool_0: false);
						}
					}
				}
				for (int k = 0; k < ataskTempl_0.m_AwByRatio_F.m_Awards.Length; k++)
				{
					for (int l = 0; l < ataskTempl_0.m_AwByRatio_F.m_Awards[k].m_pTitleAward.Length; l++)
					{
						if (ataskTempl_0.m_AwByRatio_F.m_Awards[k].m_pTitleAward[l].m_ulTitleID.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, k, 0, l, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_TITLE_AWARD, bool_0: false);
						}
					}
				}
				for (int m = 0; m < ataskTempl_0.m_AwByItems_S.m_Awards.Length; m++)
				{
					for (int n = 0; n < ataskTempl_0.m_AwByItems_S.m_Awards[m].m_pTitleAward.Length; n++)
					{
						if (ataskTempl_0.m_AwByItems_S.m_Awards[m].m_pTitleAward[n].m_ulTitleID.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, m, 0, n, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_TITLE_AWARD, bool_0: false);
						}
					}
				}
				for (int num3 = 0; num3 < ataskTempl_0.m_AwByItems_F.m_Awards.Length; num3++)
				{
					for (int num4 = 0; num4 < ataskTempl_0.m_AwByItems_F.m_Awards[num3].m_pTitleAward.Length; num4++)
					{
						if (ataskTempl_0.m_AwByItems_F.m_Awards[num3].m_pTitleAward[num4].m_ulTitleID.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num3, 0, num4, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_TITLE_AWARD, bool_0: false);
						}
					}
				}
				for (int num5 = 0; num5 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards.Length; num5++)
				{
					for (int num6 = 0; num6 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num5].m_pTitleAward.Length; num6++)
					{
						if (ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num5].m_pTitleAward[num6].m_ulTitleID.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num5, 0, num6, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_TITLE_AWARD, bool_0: false);
						}
					}
				}
				for (int num7 = 0; num7 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards.Length; num7++)
				{
					for (int num8 = 0; num8 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num7].m_pTitleAward.Length; num8++)
					{
						if (ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num7].m_pTitleAward[num8].m_ulTitleID.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num7, 0, num8, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_TITLE_AWARD, bool_0: false);
						}
					}
				}
				for (int num9 = 0; num9 < ataskTempl_0.AwByCarrierHp_S.m_Awards.Length; num9++)
				{
					for (int num10 = 0; num10 < ataskTempl_0.AwByCarrierHp_S.m_Awards[num9].m_pTitleAward.Length; num10++)
					{
						if (ataskTempl_0.AwByCarrierHp_S.m_Awards[num9].m_pTitleAward[num10].m_ulTitleID.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num9, 0, num10, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_TITLE_AWARD, bool_0: false);
						}
					}
				}
				for (int num11 = 0; num11 < ataskTempl_0.AwByCarrierHp_F.m_Awards.Length; num11++)
				{
					for (int num12 = 0; num12 < ataskTempl_0.AwByCarrierHp_F.m_Awards[num11].m_pTitleAward.Length; num12++)
					{
						if (ataskTempl_0.AwByCarrierHp_F.m_Awards[num11].m_pTitleAward[num12].m_ulTitleID.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num11, 0, num12, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_TITLE_AWARD, bool_0: false);
						}
					}
				}
				for (int num13 = 0; num13 < ataskTempl_0.AwByVar_S.m_Awards.Length; num13++)
				{
					for (int num14 = 0; num14 < ataskTempl_0.AwByVar_S.m_Awards[num13].m_pTitleAward.Length; num14++)
					{
						if (ataskTempl_0.AwByVar_S.m_Awards[num13].m_pTitleAward[num14].m_ulTitleID.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num13, 0, num14, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_TITLE_AWARD, bool_0: false);
						}
					}
				}
				for (int num15 = 0; num15 < ataskTempl_0.AwByVar_F.m_Awards.Length; num15++)
				{
					for (int num16 = 0; num16 < ataskTempl_0.AwByVar_F.m_Awards[num15].m_pTitleAward.Length; num16++)
					{
						if (ataskTempl_0.AwByVar_F.m_Awards[num15].m_pTitleAward[num16].m_ulTitleID.ToString() == string_0)
						{
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num15, 0, num16, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_TITLE_AWARD, bool_0: false);
						}
					}
				}
				return false;
			}
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, num2, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_TITLE_AWARD, bool_0: true);
		}
		return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, num, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_TITLE_AWARD, bool_0: true);
	}

	private static bool smethod_10(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int[] int_0, ATaskTempl ataskTempl_0, string string_0)
	{
		if (ataskTempl_0.m_Award_S.m_iInviterAwardItem.ToString() == string_0)
		{
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_INVITER_AWARD, bool_0: true);
		}
		if (ataskTempl_0.m_Award_F.m_iInviterAwardItem.ToString() == string_0)
		{
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, 0, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_INVITER_AWARD, bool_0: true);
		}
		int num = 0;
		while (true)
		{
			if (num < ataskTempl_0.m_AwByRatio_S.m_Awards.Length)
			{
				if (ataskTempl_0.m_AwByRatio_S.m_Awards[num].m_iInviterAwardItem.ToString() == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < ataskTempl_0.m_AwByRatio_F.m_Awards.Length)
				{
					if (ataskTempl_0.m_AwByRatio_F.m_Awards[num2].m_iInviterAwardItem.ToString() == string_0)
					{
						break;
					}
					num2++;
					continue;
				}
				int num3 = 0;
				while (true)
				{
					if (num3 < ataskTempl_0.m_AwByItems_S.m_Awards.Length)
					{
						if (ataskTempl_0.m_AwByItems_S.m_Awards[num3].m_iInviterAwardItem.ToString() == string_0)
						{
							break;
						}
						num3++;
						continue;
					}
					int num4 = 0;
					while (true)
					{
						if (num4 < ataskTempl_0.m_AwByItems_F.m_Awards.Length)
						{
							if (ataskTempl_0.m_AwByItems_F.m_Awards[num4].m_iInviterAwardItem.ToString() == string_0)
							{
								break;
							}
							num4++;
							continue;
						}
						int num5 = 0;
						while (true)
						{
							if (num5 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards.Length)
							{
								if (ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num5].m_iInviterAwardItem.ToString() == string_0)
								{
									break;
								}
								num5++;
								continue;
							}
							int num6 = 0;
							while (true)
							{
								if (num6 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards.Length)
								{
									if (ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num6].m_iInviterAwardItem.ToString() == string_0)
									{
										break;
									}
									num6++;
									continue;
								}
								int num7 = 0;
								while (true)
								{
									if (num7 < ataskTempl_0.AwByCarrierHp_S.m_Awards.Length)
									{
										if (ataskTempl_0.AwByCarrierHp_S.m_Awards[num7].m_iInviterAwardItem.ToString() == string_0)
										{
											break;
										}
										num7++;
										continue;
									}
									int num8 = 0;
									while (true)
									{
										if (num8 < ataskTempl_0.AwByCarrierHp_F.m_Awards.Length)
										{
											if (ataskTempl_0.AwByCarrierHp_F.m_Awards[num8].m_iInviterAwardItem.ToString() == string_0)
											{
												break;
											}
											num8++;
											continue;
										}
										int num9 = 0;
										while (true)
										{
											if (num9 < ataskTempl_0.AwByVar_S.m_Awards.Length)
											{
												if (ataskTempl_0.AwByVar_S.m_Awards[num9].m_iInviterAwardItem.ToString() == string_0)
												{
													break;
												}
												num9++;
												continue;
											}
											int num10 = 0;
											while (true)
											{
												if (num10 < ataskTempl_0.AwByVar_F.m_Awards.Length)
												{
													if (ataskTempl_0.AwByVar_F.m_Awards[num10].m_iInviterAwardItem.ToString() == string_0)
													{
														break;
													}
													num10++;
													continue;
												}
												return false;
											}
											return smethod_13(mainEditor_0, int_0, ataskTempl_0, num10, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_INVITER_AWARD, bool_0: false);
										}
										return smethod_13(mainEditor_0, int_0, ataskTempl_0, num9, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_INVITER_AWARD, bool_0: false);
									}
									return smethod_13(mainEditor_0, int_0, ataskTempl_0, num8, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_INVITER_AWARD, bool_0: false);
								}
								return smethod_13(mainEditor_0, int_0, ataskTempl_0, num7, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_INVITER_AWARD, bool_0: false);
							}
							return smethod_13(mainEditor_0, int_0, ataskTempl_0, num6, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_INVITER_AWARD, bool_0: false);
						}
						return smethod_13(mainEditor_0, int_0, ataskTempl_0, num5, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_INVITER_AWARD, bool_0: false);
					}
					return smethod_13(mainEditor_0, int_0, ataskTempl_0, num4, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_INVITER_AWARD, bool_0: false);
				}
				return smethod_13(mainEditor_0, int_0, ataskTempl_0, num3, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_INVITER_AWARD, bool_0: false);
			}
			return smethod_13(mainEditor_0, int_0, ataskTempl_0, num2, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_INVITER_AWARD, bool_0: false);
		}
		return smethod_13(mainEditor_0, int_0, ataskTempl_0, num, 0, 0, GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_INVITER_AWARD, bool_0: false);
	}

	private static bool smethod_11(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int[] int_0, talk_proc talk_proc_0, int int_1, string string_0)
	{
		for (int i = 0; i < talk_proc_0.windows.Length; i++)
		{
			for (int j = 0; j < talk_proc_0.windows[i].options.Length; j++)
			{
				if (Settings.Fields.IgnoreColorCod)
				{
					if (smethod_0(GlobalFunctions.ColorClean(talk_proc_0.windows[i].options[j].optiontext), string_0))
					{
						smethod_2(mainEditor_0.treeView_tasks, int_0);
						mainEditor_0.tabControl1.SelectedIndex = 5;
						mainEditor_0.listBox_Talks.SelectedIndex = int_1;
						mainEditor_0.listBox_Talk_windows.SelectedIndex = i;
						mainEditor_0.listBox_Talk_windows_options.SelectedIndex = j;
						return true;
					}
				}
				else if (smethod_0(talk_proc_0.windows[i].options[j].optiontext, string_0))
				{
					smethod_2(mainEditor_0.treeView_tasks, int_0);
					mainEditor_0.tabControl1.SelectedIndex = 5;
					mainEditor_0.listBox_Talks.SelectedIndex = int_1;
					mainEditor_0.listBox_Talk_windows.SelectedIndex = i;
					mainEditor_0.listBox_Talk_windows_options.SelectedIndex = j;
					return true;
				}
			}
		}
		return false;
	}

	private static bool smethod_12(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int[] int_0, talk_proc talk_proc_0, int int_1, string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < talk_proc_0.windows.Length)
			{
				if (Settings.Fields.IgnoreColorCod)
				{
					if (smethod_0(GlobalFunctions.ColorClean(talk_proc_0.windows[num].talktext), string_0))
					{
						smethod_2(mainEditor_0.treeView_tasks, int_0);
						mainEditor_0.tabControl1.SelectedIndex = 5;
						mainEditor_0.listBox_Talks.SelectedIndex = int_1;
						mainEditor_0.listBox_Talk_windows.SelectedIndex = num;
						return true;
					}
				}
				else if (smethod_0(talk_proc_0.windows[num].talktext, string_0))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		smethod_2(mainEditor_0.treeView_tasks, int_0);
		mainEditor_0.tabControl1.SelectedIndex = 5;
		mainEditor_0.listBox_Talks.SelectedIndex = int_1;
		mainEditor_0.listBox_Talk_windows.SelectedIndex = num;
		return true;
	}

	private static bool smethod_13(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int[] int_0, ATaskTempl ataskTempl_0, int int_1, int int_2, int int_3, GlobalData.TASKELEMENTS_TYPE taskelements_TYPE_0, bool bool_0)
	{
		ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = bool_0;
		smethod_2(mainEditor_0.treeView_tasks, int_0);
		TaskElements.SelectElement(mainEditor_0, int_1, 0, 0, taskelements_TYPE_0, ataskTempl_0);
		return true;
	}
}
