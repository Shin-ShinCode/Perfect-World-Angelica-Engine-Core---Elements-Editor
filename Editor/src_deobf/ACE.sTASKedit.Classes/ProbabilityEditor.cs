using System;
using System.Windows.Forms;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.Forms;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes;

internal class ProbabilityEditor
{
	[Serializable]
	private sealed class Class403
	{
		public static readonly Class403 class403_0 = new Class403();

		public static Func<MONSTERS_SUMMONED, ElementProbability> func_0;

		public static Action<ElementProbability, MONSTERS_SUMMONED> action_0;

		public static Func<ITEM_WANTED, ElementProbability> func_1;

		public static Action<ElementProbability, ITEM_WANTED> action_1;

		public static Func<ITEM_WANTED, ElementProbability> func_2;

		public static Action<ElementProbability, ITEM_WANTED> action_2;

		public static Func<PLAYER_WANTED, ElementProbability> func_3;

		public static Action<ElementProbability, PLAYER_WANTED> action_3;

		public static Func<MONSTER_WANTED, ElementProbability> func_4;

		public static Action<ElementProbability, MONSTER_WANTED> action_4;

		public static Func<MONSTER_WANTED, ElementProbability> func_5;

		public static Action<ElementProbability, MONSTER_WANTED> action_5;

		public static Func<ITEM_WANTED, ElementProbability> func_6;

		public static Action<ElementProbability, ITEM_WANTED> action_6;

		public static Func<ITEM_WANTED, ElementProbability> func_7;

		public static Action<ElementProbability, ITEM_WANTED> action_7;

		public static Func<MONSTERS_SUMMONED, ElementProbability> func_8;

		public static Action<ElementProbability, MONSTERS_SUMMONED> action_8;

		internal ElementProbability method_0(MONSTERS_SUMMONED monsters_SUMMONED_0)
		{
			return new ElementProbability
			{
				Id = monsters_SUMMONED_0.m_ulMonsterTemplId,
				Probability = monsters_SUMMONED_0.m_fSummonProb
			};
		}

		internal void method_1(ElementProbability elementProbability_0, MONSTERS_SUMMONED monsters_SUMMONED_0)
		{
			monsters_SUMMONED_0.m_fSummonProb = elementProbability_0.Probability;
		}

		internal ElementProbability method_2(ITEM_WANTED item_WANTED_0)
		{
			return new ElementProbability
			{
				Id = item_WANTED_0.m_ulItemTemplId,
				Probability = item_WANTED_0.m_fProb
			};
		}

		internal void method_3(ElementProbability elementProbability_0, ITEM_WANTED item_WANTED_0)
		{
			item_WANTED_0.m_fProb = elementProbability_0.Probability;
		}

		internal ElementProbability method_4(ITEM_WANTED item_WANTED_0)
		{
			return new ElementProbability
			{
				Id = item_WANTED_0.m_ulItemTemplId,
				Probability = item_WANTED_0.m_fProb
			};
		}

		internal void method_5(ElementProbability elementProbability_0, ITEM_WANTED item_WANTED_0)
		{
			item_WANTED_0.m_fProb = elementProbability_0.Probability;
		}

		internal ElementProbability method_6(PLAYER_WANTED player_WANTED_0)
		{
			return new ElementProbability
			{
				Id = player_WANTED_0.m_ulDropItemId,
				Probability = player_WANTED_0.m_fDropProb
			};
		}

		internal void method_7(ElementProbability elementProbability_0, PLAYER_WANTED player_WANTED_0)
		{
			player_WANTED_0.m_fDropProb = elementProbability_0.Probability;
		}

		internal ElementProbability method_8(MONSTER_WANTED monster_WANTED_0)
		{
			return new ElementProbability
			{
				Id = monster_WANTED_0.m_ulDropItemId,
				Probability = monster_WANTED_0.m_fDropProb
			};
		}

		internal void method_9(ElementProbability elementProbability_0, MONSTER_WANTED monster_WANTED_0)
		{
			monster_WANTED_0.m_fDropProb = elementProbability_0.Probability;
		}

		internal ElementProbability method_10(MONSTER_WANTED monster_WANTED_0)
		{
			return new ElementProbability
			{
				Id = monster_WANTED_0.m_ulDropItemId,
				Probability = monster_WANTED_0.m_fDropProb
			};
		}

		internal void method_11(ElementProbability elementProbability_0, MONSTER_WANTED monster_WANTED_0)
		{
			monster_WANTED_0.m_fDropProb = elementProbability_0.Probability;
		}

		internal ElementProbability method_12(ITEM_WANTED item_WANTED_0)
		{
			return new ElementProbability
			{
				Id = item_WANTED_0.m_ulItemTemplId,
				Probability = item_WANTED_0.m_fProb
			};
		}

		internal void method_13(ElementProbability elementProbability_0, ITEM_WANTED item_WANTED_0)
		{
			item_WANTED_0.m_fProb = elementProbability_0.Probability;
		}

		internal ElementProbability method_14(ITEM_WANTED item_WANTED_0)
		{
			return new ElementProbability
			{
				Id = item_WANTED_0.m_ulItemTemplId,
				Probability = item_WANTED_0.m_fProb
			};
		}

		internal void method_15(ElementProbability elementProbability_0, ITEM_WANTED item_WANTED_0)
		{
			item_WANTED_0.m_fProb = elementProbability_0.Probability;
		}

		internal ElementProbability method_16(MONSTERS_SUMMONED monsters_SUMMONED_0)
		{
			return new ElementProbability
			{
				Id = monsters_SUMMONED_0.m_ulMonsterTemplId,
				Probability = monsters_SUMMONED_0.m_fSummonProb
			};
		}

		internal void method_17(ElementProbability elementProbability_0, MONSTERS_SUMMONED monsters_SUMMONED_0)
		{
			monsters_SUMMONED_0.m_fSummonProb = elementProbability_0.Probability;
		}
	}

	private static void smethod_0<T>(T[] gparam_0, Func<T, ElementProbability> func_0, Action<ElementProbability, T> action_0, DataGridView dataGridView_0, int int_0, int int_1)
	{
		if (gparam_0 == null || gparam_0.Length == 0)
		{
			return;
		}
		ElementProbability[] array = new ElementProbability[gparam_0.Length];
		for (int i = 0; i < gparam_0.Length; i++)
		{
			array[i] = func_0(gparam_0[i]);
		}
		ProbabilityEditorWindow probabilityEditorWindow = new ProbabilityEditorWindow(array, int_1);
		if (probabilityEditorWindow.ShowDialog() == DialogResult.OK)
		{
			for (int j = 0; j < gparam_0.Length; j++)
			{
				action_0(probabilityEditorWindow.Elements[j], gparam_0[j]);
				dataGridView_0.Rows[j].Cells[int_0].Value = probabilityEditorWindow.Elements[j].Probability.ToString(GProD.ProbValueFormat);
			}
		}
	}

	public static void PropMonsterSummoned_m_Monsters_EditProbabilities(ATaskTempl selectedTask, DataGridView dgv)
	{
		if (selectedTask != null && selectedTask.m_ulPropSummonedMonsters != 0)
		{
			smethod_0(selectedTask.PropMonsterSummoned.m_Monsters, Class403.class403_0.method_0, Class403.class403_0.method_1, dgv, 3, 1);
		}
	}

	public static void m_PremItems_EditProbabilities(ATaskTempl selectedTask, DataGridView dgv)
	{
		if (selectedTask != null && selectedTask.m_PremItems.Length != 0)
		{
			smethod_0(selectedTask.m_PremItems, Class403.class403_0.method_2, Class403.class403_0.method_3, dgv, 5, 0);
		}
	}

	public static void m_GivenItems_EditProbabilities(ATaskTempl selectedTask, DataGridView dgv)
	{
		if (selectedTask != null && selectedTask.m_GivenItems.Length != 0)
		{
			smethod_0(selectedTask.m_GivenItems, Class403.class403_0.method_4, Class403.class403_0.method_5, dgv, 5, 0);
		}
	}

	public static void m_PlayerWanted_EditProbabilities(ATaskTempl selectedTask, DataGridView dgv)
	{
		if (selectedTask != null && selectedTask.m_PlayerWanted.Length != 0)
		{
			smethod_0(selectedTask.m_PlayerWanted, Class403.class403_0.method_6, Class403.class403_0.method_7, dgv, 6, 0);
		}
	}

	public static void m_MonsterWanted_EditProbabilities(ATaskTempl selectedTask, DataGridView dgv)
	{
		if (selectedTask != null && selectedTask.m_MonsterWanted.Length != 0)
		{
			smethod_0(selectedTask.m_MonsterWanted, Class403.class403_0.method_8, Class403.class403_0.method_9, dgv, 8, 0);
		}
	}

	public static void m_MonsterUnwanted_EditProbabilities(ATaskTempl selectedTask, DataGridView dgv)
	{
		if (selectedTask != null && selectedTask.m_MonsterUnwanted.Length != 0)
		{
			smethod_0(selectedTask.m_MonsterUnwanted, Class403.class403_0.method_10, Class403.class403_0.method_11, dgv, 8, 0);
		}
	}

	public static void m_ItemsWanted_EditProbabilities(ATaskTempl selectedTask, DataGridView dgv)
	{
		if (selectedTask != null && selectedTask.m_ItemsWanted.Length != 0)
		{
			smethod_0(selectedTask.m_ItemsWanted, Class403.class403_0.method_12, Class403.class403_0.method_13, dgv, 5, 0);
		}
	}

	public static void Award_m_CandItems_m_AwardItems_EditProbabilities(AWARD_DATA selectedAward, DataGridView dgv, CheckedListBox clb)
	{
		if (selectedAward != null && selectedAward.m_CandItems.Length != 0)
		{
			int selectedIndex = clb.SelectedIndex;
			if (selectedIndex >= 0 && selectedAward.m_CandItems[selectedIndex].m_AwardItems.Length != 0)
			{
				smethod_0(selectedAward.m_CandItems[selectedIndex].m_AwardItems, Class403.class403_0.method_14, Class403.class403_0.method_15, dgv, 5, 0);
			}
		}
	}

	public static void Award_m_SummonedMonsters_m_Monsters_EditProbabilities(AWARD_DATA selectedAward, DataGridView dgv)
	{
		if (selectedAward != null && selectedAward.m_SummonedMonsters.m_Monsters.Length != 0)
		{
			smethod_0(selectedAward.m_SummonedMonsters.m_Monsters, Class403.class403_0.method_16, Class403.class403_0.method_17, dgv, 3, 1);
		}
	}
}
