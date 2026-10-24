using System;
using System.Collections.Generic;
using ACE.Classes.ACE;
using ACE.Cpk;
using ACE.RSGlobal;
using ACE.sTASKedit.Classes;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.Classes;

public class CreateTasksReferences
{
	public static TASKS Tasks;

	public ELEMENTS_REFERENCES References;

	public ELEMENTS_IDS_REFERENCES ReferencesMatters;

	private ATaskTempl ataskTempl_0;

	private QUEST_INFO quest_INFO_0;

	private int int_0;

	public Dictionary<ReferenceType, ELEMENTS_IDS_REFERENCES> RefsExtra;

	public CreateTasksReferences(ATaskTempl quest, QUEST_INFO qi, ELEMENTS_REFERENCES References)
	{
		this.References = References;
		ReferencesMatters = References.ReferencesExtra[ReferenceType.TASKS_MATTERS];
		ataskTempl_0 = quest;
		quest_INFO_0 = qi;
		int_0 = quest.ID;
		TASKS_PROPS.CreateTaskProps(quest.ID);
		method_0();
	}

	public CreateTasksReferences(TASKS Tasks, ELEMENTS_REFERENCES References)
	{
		CreateTasksReferences.Tasks = Tasks;
		this.References = References;
		if (Tasks != null && Tasks.FileLoaded)
		{
			CreateReferences();
		}
		References = null;
		ReferencesMatters = null;
	}

	public static Dictionary<ReferenceSubType, TASK_PROPS_PART> GetTaskProps(ATaskTempl quest, QUEST_INFO qi)
	{
		ELEMENTS_REFERENCES eLEMENTS_REFERENCES = new ELEMENTS_REFERENCES();
		ReferenceType referenceType = ReferenceType.TASKS_MATTERS;
		do
		{
			eLEMENTS_REFERENCES.NewRefs(referenceType);
			referenceType++;
		}
		while (referenceType <= ReferenceType.TASKS_MINES);
		new CreateTasksReferences(quest, qi, eLEMENTS_REFERENCES);
		eLEMENTS_REFERENCES.ReferencesExtra.Clear();
		return TASKS_PROPS.CurrentTaskProps;
	}

	public void CreateReferences()
	{
		ReferenceType referenceType = ReferenceType.TASKS_MATTERS;
		do
		{
			References.NewRefs(referenceType);
			referenceType++;
		}
		while (referenceType <= ReferenceType.TASKS_MINES);
		ReferencesMatters = References.ReferencesExtra[ReferenceType.TASKS_MATTERS];
		TASKS_PROPS.CurrentTaskProps = null;
		foreach (KeyValuePair<int, ATaskTempl> quest in Tasks.quests)
		{
			ATaskTempl aTaskTempl = (ataskTempl_0 = ((KeyValuePair<int, ATaskTempl>)(object)quest).Value);
			IDictionary<int, QUEST_INFO> infos = Tasks.infos;
			quest_INFO_0 = infos[aTaskTempl.ID];
			int_0 = ataskTempl_0.ID;
			method_0();
		}
		TASKS_PROPS.CurrentTaskProps = null;
		GC.KeepAlive(this);
	}

	private void method_0()
	{
		RefsExtra = References.ReferencesExtra;
		INDICES ind = new INDICES
		{
			int_0 = -1
		};
		ATaskTempl aTaskTempl = ataskTempl_0;
		int id = int_0;
		QUEST_INFO oSpecial = quest_INFO_0;
		RefsExtra[ReferenceType.TASKS_NPCS].AddRef(ReferenceSubType.TASKS_DELV_NPC, null, ind, oSpecial, id, aTaskTempl.m_ulDelvNPC);
		INDICES ind2 = new INDICES
		{
			int_0 = -1
		};
		ATaskTempl aTaskTempl2 = ataskTempl_0;
		int id2 = int_0;
		QUEST_INFO oSpecial2 = quest_INFO_0;
		RefsExtra[ReferenceType.TASKS_NPCS].AddRef(ReferenceSubType.TASKS_AWARD_NPC, null, ind2, oSpecial2, id2, aTaskTempl2.m_ulAwardNPC);
		int num = 0;
		if (0 < (nint)ataskTempl_0.m_MonstersContrib.LongLength)
		{
			INDICES ind3 = new INDICES
			{
				int_0 = -1
			};
			do
			{
				ref MONSTERS_CONTRIB reference = ref ataskTempl_0.m_MonstersContrib[num];
				ind3.int_0 = num;
				MONSTERS_CONTRIB mONSTERS_CONTRIB = reference;
				int id3 = int_0;
				QUEST_INFO oSpecial3 = quest_INFO_0;
				ATaskTempl aTaskTempl3 = ataskTempl_0;
				RefsExtra[ReferenceType.TASKS_MONSTERS].AddRef(ReferenceSubType.TASKS_MONSTERS_CONTRIB, aTaskTempl3.m_MonstersContrib, ind3, oSpecial3, id3, mONSTERS_CONTRIB.m_ulMonsterTemplId);
				num++;
			}
			while (num < (nint)ataskTempl_0.m_MonstersContrib.LongLength);
		}
		ITEM_WANTED[] item_WANTED_ = ataskTempl_0.m_PremItems;
		method_4(ref item_WANTED_, ReferenceSubType.TASKS_PREM_ITEMS);
		ITEM_WANTED[] item_WANTED_2 = ataskTempl_0.m_GivenItems;
		method_4(ref item_WANTED_2, ReferenceSubType.TASKS_GIVEN_ITEMS);
		int num2 = 0;
		if (0 < (nint)ataskTempl_0.m_PremTitles.LongLength)
		{
			INDICES ind4 = default(INDICES);
			do
			{
				ind4.int_0 = num2;
				int element_id = ataskTempl_0.m_PremTitles[num2];
				int id4 = int_0;
				QUEST_INFO oSpecial4 = quest_INFO_0;
				ATaskTempl aTaskTempl4 = ataskTempl_0;
				RefsExtra[ReferenceType.TASKS_TITLES].AddRef(ReferenceSubType.TASKS_PREM_TITLES, aTaskTempl4.m_PremTitles, ind4, oSpecial4, id4, element_id);
				num2++;
			}
			while (num2 < (nint)ataskTempl_0.m_PremTitles.LongLength);
		}
		int num3 = 0;
		if (0 < (nint)ataskTempl_0.m_MonsterWanted.LongLength)
		{
			INDICES ind5 = default(INDICES);
			INDICES ind6 = default(INDICES);
			do
			{
				ref MONSTER_WANTED reference2 = ref ataskTempl_0.m_MonsterWanted[num3];
				ind5.int_0 = num3;
				MONSTER_WANTED mONSTER_WANTED = reference2;
				MONSTER_WANTED mONSTER_WANTED2 = reference2;
				int id5 = int_0;
				QUEST_INFO oSpecial5 = quest_INFO_0;
				ATaskTempl aTaskTempl5 = ataskTempl_0;
				RefsExtra[ReferenceType.TASKS_MONSTERS].AddRef(ReferenceSubType.TASKS_MONSTER_WANTED_MONSTERS, aTaskTempl5.m_MonsterWanted, ind5, oSpecial5, id5, mONSTER_WANTED2.m_ulMonsterTemplId, mONSTER_WANTED.m_ulMonsterNum);
				ind6.int_0 = num3;
				MONSTER_WANTED mONSTER_WANTED3 = reference2;
				MONSTER_WANTED mONSTER_WANTED4 = reference2;
				int id6 = int_0;
				QUEST_INFO oSpecial6 = quest_INFO_0;
				ATaskTempl aTaskTempl6 = ataskTempl_0;
				ReferencesMatters.AddRef(ReferenceSubType.TASKS_MONSTER_WANTED_ITEMS, aTaskTempl6.m_MonsterWanted, ind6, oSpecial6, id6, mONSTER_WANTED4.m_ulDropItemId, mONSTER_WANTED3.m_ulDropItemCount);
				num3++;
			}
			while (num3 < (nint)ataskTempl_0.m_MonsterWanted.LongLength);
		}
		int num4 = 0;
		if (0 < (nint)ataskTempl_0.m_PlayerWanted.LongLength)
		{
			INDICES ind7 = default(INDICES);
			do
			{
				ref PLAYER_WANTED reference3 = ref ataskTempl_0.m_PlayerWanted[num4];
				ind7.int_0 = num4;
				PLAYER_WANTED pLAYER_WANTED = reference3;
				PLAYER_WANTED pLAYER_WANTED2 = reference3;
				int id7 = int_0;
				QUEST_INFO oSpecial7 = quest_INFO_0;
				ATaskTempl aTaskTempl7 = ataskTempl_0;
				ReferencesMatters.AddRef(ReferenceSubType.TASKS_MATTERS_PLAYER_WANTED, aTaskTempl7.m_PlayerWanted, ind7, oSpecial7, id7, pLAYER_WANTED2.m_ulDropItemId, pLAYER_WANTED.m_ulDropItemCount);
				num4++;
			}
			while (num4 < (nint)ataskTempl_0.m_PlayerWanted.LongLength);
		}
		ITEM_WANTED[] item_WANTED_3 = ataskTempl_0.m_ItemsWanted;
		method_4(ref item_WANTED_3, ReferenceSubType.TASKS_ITEMS_WANTED);
		INDICES ind8 = new INDICES
		{
			int_0 = -1
		};
		ATaskTempl aTaskTempl8 = ataskTempl_0;
		int id8 = int_0;
		QUEST_INFO oSpecial8 = quest_INFO_0;
		RefsExtra[ReferenceType.TASKS_MONSTERS].AddRef(ReferenceSubType.TASKS_TM_BIND_CARRTER_ID, null, ind8, oSpecial8, id8, aTaskTempl8.m_ulBindOnCarrierId);
		int num5 = 0;
		if (0 < (nint)ataskTempl_0.m_HomeItemsWanted.LongLength)
		{
			INDICES ind9 = default(INDICES);
			do
			{
				ref HOME_ITEM_WANTED reference4 = ref ataskTempl_0.m_HomeItemsWanted[num5];
				ind9.int_0 = num5;
				HOME_ITEM_WANTED hOME_ITEM_WANTED = reference4;
				HOME_ITEM_WANTED hOME_ITEM_WANTED2 = reference4;
				int id9 = int_0;
				QUEST_INFO oSpecial9 = quest_INFO_0;
				ATaskTempl aTaskTempl9 = ataskTempl_0;
				RefsExtra[ReferenceType.TASKS_HOME_ITEMS].AddRef(ReferenceSubType.TASKS_HOME_ITEMS_WANTED, aTaskTempl9.m_HomeItemsWanted, ind9, oSpecial9, id9, hOME_ITEM_WANTED2.m_ulHomeItemTid, hOME_ITEM_WANTED.m_ulHomeItemCount);
				num5++;
			}
			while (num5 < (nint)ataskTempl_0.m_HomeItemsWanted.LongLength);
		}
		TaskEventData[] taskEventData_ = ataskTempl_0.TaskEventMonsterData;
		method_1(ReferenceType.TASKS_MONSTERS, ReferenceSubType.TASKS_TASK_EVENT_MONSTER_DATA, ref taskEventData_);
		TaskEventData[] taskEventData_2 = ataskTempl_0.TaskEventMineData;
		method_1(ReferenceType.TASKS_MINES, ReferenceSubType.TASKS_TASK_EVENT_MINE_DATA, ref taskEventData_2);
		AWARD_DATA award_DATA_ = ataskTempl_0.m_Award_S;
		method_3(ref award_DATA_, ReferenceSubType.TASKS_AWARD_SUCCESS_CAND_ITEMS);
		AWARD_DATA award_DATA_2 = ataskTempl_0.m_Award_F;
		method_3(ref award_DATA_2, ReferenceSubType.TASKS_AWARD_FAIL_CAND_ITEMS);
		AWARD_DATA[] award_DATA_3 = ataskTempl_0.m_AwByRatio_S.m_Awards;
		method_2(ref award_DATA_3, ReferenceSubType.TASKS_AWARD_BY_RATIO_SUCCESS_CAND_ITEMS);
		AWARD_DATA[] award_DATA_4 = ataskTempl_0.m_AwByRatio_F.m_Awards;
		method_2(ref award_DATA_4, ReferenceSubType.TASKS_AWARD_BY_RATIO_FAIL_CAND_ITEMS);
		AWARD_DATA[] award_DATA_5 = ataskTempl_0.m_AwByItems_S.m_Awards;
		method_2(ref award_DATA_5, ReferenceSubType.TASKS_AWARD_BY_ITEMS_SUCCESS_CAND_ITEMS);
		AWARD_DATA[] award_DATA_6 = ataskTempl_0.m_AwByItems_F.m_Awards;
		method_2(ref award_DATA_6, ReferenceSubType.TASKS_AWARD_BY_ITEMS_FAIL_CAND_ITEMS);
		AWARD_DATA[] award_DATA_7 = ataskTempl_0.AwByTaskEventRatio_S.m_Awards;
		method_2(ref award_DATA_7, ReferenceSubType.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_CAND_ITEMS);
		AWARD_DATA[] award_DATA_8 = ataskTempl_0.AwByTaskEventRatio_F.m_Awards;
		method_2(ref award_DATA_8, ReferenceSubType.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_CAND_ITEMS);
		if (Tasks == null || Tasks.version >= 146)
		{
			AWARD_DATA[] award_DATA_9 = ataskTempl_0.AwByCarrierHp_S.m_Awards;
			method_2(ref award_DATA_9, ReferenceSubType.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_CAND_ITEMS);
			AWARD_DATA[] award_DATA_10 = ataskTempl_0.AwByCarrierHp_F.m_Awards;
			method_2(ref award_DATA_10, ReferenceSubType.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_CAND_ITEMS);
		}
		INDICES ind10 = new INDICES
		{
			int_0 = 16777201
		};
		int id10 = int_0;
		QUEST_INFO oSpecial10 = quest_INFO_0;
		ReferencesMatters.AddRef(ReferenceSubType.TASKS_AWARD_BY_ITEMS_SUCCESS_CAND_ITEMS, null, ind10, oSpecial10, id10, ataskTempl_0.m_AwByItems_S.m_ulItemId);
		INDICES ind11 = new INDICES
		{
			int_0 = 16777202
		};
		int id11 = int_0;
		QUEST_INFO oSpecial11 = quest_INFO_0;
		ReferencesMatters.AddRef(ReferenceSubType.TASKS_AWARD_BY_ITEMS_FAIL_CAND_ITEMS, null, ind11, oSpecial11, id11, ataskTempl_0.m_AwByItems_F.m_ulItemId);
		GC.KeepAlive(this);
	}

	private void method_1(ReferenceType referenceType_0, ReferenceSubType referenceSubType_0, ref TaskEventData[] taskEventData_0)
	{
		int num = 0;
		TaskEventData[] array = taskEventData_0;
		if (0 < (nint)array.LongLength)
		{
			INDICES ind = default(INDICES);
			do
			{
				ind.int_0 = num;
				TaskEventData taskEventData = array[num];
				int id = int_0;
				QUEST_INFO oSpecial = quest_INFO_0;
				TaskEventData[] oParent = taskEventData_0;
				RefsExtra[referenceType_0].AddRef(referenceSubType_0, oParent, ind, oSpecial, id, taskEventData.Id);
				num++;
				array = taskEventData_0;
			}
			while (num < (nint)array.LongLength);
		}
		GC.KeepAlive(this);
	}

	private void method_2(ref AWARD_DATA[] award_DATA_0, ReferenceSubType referenceSubType_0)
	{
		AWARD_DATA[] array = award_DATA_0;
		if (array == null)
		{
			return;
		}
		int num = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				method_3(ref array[num], referenceSubType_0);
				num++;
			}
			while (num < (nint)array.LongLength);
		}
	}

	private void method_3(ref AWARD_DATA award_DATA_0, ReferenceSubType referenceSubType_0)
	{
		AWARD_ITEMS_CAND[] candItems = award_DATA_0.m_CandItems;
		if (candItems != null)
		{
			int num = 0;
			if (0 < (nint)candItems.LongLength)
			{
				do
				{
					ITEM_WANTED[] item_WANTED_ = candItems[num].m_AwardItems;
					if (item_WANTED_ != null)
					{
						method_4(ref item_WANTED_, referenceSubType_0);
					}
					num++;
				}
				while (num < (nint)candItems.LongLength);
			}
		}
		ReferenceSubType refSubType = referenceSubType_0 + 1;
		RANKING_AWARD[] array = award_DATA_0.m_PQRankingAward?.m_RankingAward;
		if (array != null)
		{
			int num2 = 0;
			if (0 < (nint)array.LongLength)
			{
				INDICES ind = default(INDICES);
				do
				{
					ref RANKING_AWARD reference = ref array[num2];
					ind.int_0 = num2;
					RANKING_AWARD rANKING_AWARD = reference;
					RANKING_AWARD rANKING_AWARD2 = reference;
					int id = int_0;
					QUEST_INFO oSpecial = quest_INFO_0;
					AWARD_DATA aWARD_DATA = award_DATA_0;
					ReferencesMatters.AddRef(refSubType, aWARD_DATA.m_PQRankingAward, ind, oSpecial, id, rANKING_AWARD2.m_ulAwardItemId, rANKING_AWARD.m_ulAwardItemNum);
					num2++;
				}
				while (num2 < (nint)array.LongLength);
			}
		}
		ReferenceSubType refSubType2 = referenceSubType_0 + 2;
		TITLE_AWARD[] pTitleAward = award_DATA_0.m_pTitleAward;
		if (pTitleAward != null)
		{
			int num3 = 0;
			if (0 < (nint)pTitleAward.LongLength)
			{
				INDICES ind2 = default(INDICES);
				do
				{
					ref TITLE_AWARD reference2 = ref pTitleAward[num3];
					ind2.int_0 = num3;
					TITLE_AWARD tITLE_AWARD = reference2;
					int id2 = int_0;
					QUEST_INFO oSpecial2 = quest_INFO_0;
					AWARD_DATA aWARD_DATA2 = award_DATA_0;
					RefsExtra[ReferenceType.TASKS_TITLES].AddRef(refSubType2, aWARD_DATA2.m_pTitleAward, ind2, oSpecial2, id2, tITLE_AWARD.m_ulTitleID);
					num3++;
				}
				while (num3 < (nint)pTitleAward.LongLength);
			}
		}
		AWARD_MONSTERS_SUMMONED award_MONSTERS_SUMMONED_ = award_DATA_0.m_SummonedMonsters;
		method_5(ref award_MONSTERS_SUMMONED_, referenceSubType_0 + 3);
		if (TASKS_PROPS.CurrentTaskProps != null && TASKS_PROPS.AwardHintProps != null)
		{
			AWARD_DATA award_DATA_1 = award_DATA_0;
			method_6(TASKS_PROPS.AwardHintProps, award_DATA_1, referenceSubType_0);
		}
	}

	private void method_4(ref ITEM_WANTED[] item_WANTED_0, ReferenceSubType referenceSubType_0)
	{
		int num = ((referenceSubType_0 != ReferenceSubType.TASKS_ITEMS_WANTED && referenceSubType_0 != ReferenceSubType.TASKS_PREM_ITEMS) ? 1 : 0);
		bool flag = (byte)num != 0;
		int num2 = 0;
		ITEM_WANTED[] array = item_WANTED_0;
		if (0 < (nint)array.LongLength)
		{
			INDICES ind = default(INDICES);
			INDICES ind2 = default(INDICES);
			do
			{
				ref ITEM_WANTED reference = ref array[num2];
				if (flag)
				{
					ind2.int_0 = num2;
					ITEM_WANTED iTEM_WANTED = reference;
					ITEM_WANTED iTEM_WANTED2 = reference;
					ITEM_WANTED iTEM_WANTED3 = reference;
					int id = int_0;
					QUEST_INFO oSpecial = quest_INFO_0;
					ITEM_WANTED[] oParent = item_WANTED_0;
					ReferencesMatters.AddRef(referenceSubType_0, oParent, ind2, oSpecial, id, iTEM_WANTED3.m_ulItemTemplId, iTEM_WANTED2.m_ulItemNum, iTEM_WANTED.m_fProb);
				}
				else
				{
					ind.int_0 = num2;
					ITEM_WANTED iTEM_WANTED4 = reference;
					ITEM_WANTED iTEM_WANTED5 = reference;
					int id2 = int_0;
					QUEST_INFO oSpecial2 = quest_INFO_0;
					ITEM_WANTED[] oParent2 = item_WANTED_0;
					ReferencesMatters.AddRef(referenceSubType_0, oParent2, ind, oSpecial2, id2, iTEM_WANTED5.m_ulItemTemplId, iTEM_WANTED4.m_ulItemNum);
				}
				num2++;
				array = item_WANTED_0;
			}
			while (num2 < (nint)array.LongLength);
		}
		GC.KeepAlive(this);
	}

	private void method_5(ref AWARD_MONSTERS_SUMMONED award_MONSTERS_SUMMONED_0, ReferenceSubType referenceSubType_0)
	{
		int num = 0;
		if (0 < (nint)award_MONSTERS_SUMMONED_0.m_Monsters.LongLength)
		{
			INDICES ind = default(INDICES);
			do
			{
				ref MONSTERS_SUMMONED reference = ref award_MONSTERS_SUMMONED_0.m_Monsters[num];
				ind.int_0 = num;
				MONSTERS_SUMMONED mONSTERS_SUMMONED = reference;
				MONSTERS_SUMMONED mONSTERS_SUMMONED2 = reference;
				MONSTERS_SUMMONED mONSTERS_SUMMONED3 = reference;
				int id = int_0;
				QUEST_INFO oSpecial = quest_INFO_0;
				AWARD_MONSTERS_SUMMONED oParent = award_MONSTERS_SUMMONED_0;
				RefsExtra[ReferenceType.TASKS_MONSTERS].AddRef(referenceSubType_0, oParent, ind, oSpecial, id, mONSTERS_SUMMONED3.m_ulMonsterTemplId, mONSTERS_SUMMONED2.m_ulMonsterNum, mONSTERS_SUMMONED.m_fSummonProb);
				num++;
			}
			while (num < (nint)award_MONSTERS_SUMMONED_0.m_Monsters.LongLength);
		}
		GC.KeepAlive(this);
	}

	private void method_6(Dictionary<string, string> dictionary_0, AWARD_DATA award_DATA_0, ReferenceSubType referenceSubType_0)
	{
		TASK_PROPS_PART tASK_PROPS_PART = null;
		Dictionary<string, string>.KeyCollection.Enumerator enumerator = dictionary_0.Keys.GetEnumerator();
		if (enumerator.MoveNext())
		{
			int num = 0;
			do
			{
				string current = enumerator.Current;
				object propValue = global::ACE.RSGlobal.RSGlobal.GetPropValue(award_DATA_0, current);
				if (propValue.GetType() == typeof(int))
				{
					num = (int)propValue;
				}
				else if (propValue.GetType() == typeof(bool))
				{
					num = (((bool)propValue) ? 1 : 0);
				}
				if (num == 0)
				{
					continue;
				}
				if (tASK_PROPS_PART != null)
				{
					if (!tASK_PROPS_PART.Props.ContainsKey(current))
					{
						tASK_PROPS_PART.Props[current] = num;
					}
				}
				else
				{
					tASK_PROPS_PART = TASKS_PROPS.AddTaskProp(referenceSubType_0, current, num);
				}
				if (current == Class16.smethod_0(1648909178))
				{
					tASK_PROPS_PART.AwardTeleportPos = award_DATA_0.m_TransPt.Single_0;
				}
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
	}
}
