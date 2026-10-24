using System.Windows.Forms;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes;

internal class TaskElements
{
	public const byte BASIC_PROPERTIES_PAGE_INDEX = 0;

	public const byte SPECIAL_PARAMETERS_PAGE_INDEX = 1;

	public const byte GIVEN_REQUIREMENTS_PAGE_INDEX = 2;

	public const byte COMPLETE_REQUIREMENTS_PAGE_INDEX = 3;

	public const byte AWARDS_PAGE_INDEX = 4;

	public const byte TEXT_PAGE_INDEX = 5;

	public static void SelectElement(ACE.sTASKedit.MainEditor.MainEditor mainEditor_0, int AwardIndex, int ElementGroupIndex, int ElementIndex, GlobalData.TASKELEMENTS_TYPE taskelements_TYPE_0, ATaskTempl ataskTempl_0)
	{
		mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectionMode = SelectionMode.One;
		switch (taskelements_TYPE_0)
		{
		case GlobalData.TASKELEMENTS_TYPE.TASKS_DELV_WORLD:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 1;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_ENTER_REGION_WORLD:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 1;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_LEAVE_REGION_WORLD:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 1;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 1;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 1;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_DELV_NPC:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 1;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_NPC:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 1;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 2;
			mainEditor_0.dataGridView_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTERS_CONTRIB:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 3;
			mainEditor_0.dataGridView_m_MonstersContrib.CurrentCell = mainEditor_0.dataGridView_m_MonstersContrib.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 2;
			mainEditor_0.tabControl_GivenRequirements.SelectedIndex = 0;
			mainEditor_0.dataGridView_m_PremItems.CurrentCell = mainEditor_0.dataGridView_m_PremItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_GIVEN_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 2;
			mainEditor_0.tabControl_GivenRequirements.SelectedIndex = 0;
			mainEditor_0.dataGridView_m_GivenItems.CurrentCell = mainEditor_0.dataGridView_m_GivenItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_1_KEY_VALUE_LEFT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 2;
			mainEditor_0.tabControl_GivenRequirements.SelectedIndex = 2;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_1_KEY_VALUE_RIGHT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 2;
			mainEditor_0.tabControl_GivenRequirements.SelectedIndex = 2;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_2_KEY_VALUE_LEFT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 2;
			mainEditor_0.tabControl_GivenRequirements.SelectedIndex = 2;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_2_KEY_VALUE_RIGHT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 2;
			mainEditor_0.tabControl_GivenRequirements.SelectedIndex = 2;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_PREM_TITLES:
			mainEditor_0.tabControl1.SelectedIndex = 2;
			mainEditor_0.tabControl_GivenRequirements.SelectedIndex = 3;
			mainEditor_0.dataGridView_m_PremTitles.CurrentCell = mainEditor_0.dataGridView_m_PremTitles.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_MATTERS_PLAYER_WANTED:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_m_PlayerWanted.CurrentCell = mainEditor_0.dataGridView_m_PlayerWanted.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_WANTED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_m_MonsterWanted.CurrentCell = mainEditor_0.dataGridView_m_MonsterWanted.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_WANTED_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_m_MonsterWanted.CurrentCell = mainEditor_0.dataGridView_m_MonsterWanted.Rows[ElementIndex].Cells[2];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_ITEMS_WANTED:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_m_ItemsWanted.CurrentCell = mainEditor_0.dataGridView_m_ItemsWanted.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_REACH_SITE_ID:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_TREASURE_ZONE_MAP_ID:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_LEAVE_SITE_ID:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_FIN_1_KEY_VALUE_LEFT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_FIN_1_KEY_VALUE_RIGHT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_FIN_2_KEY_VALUE_LEFT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_FIN_2_KEY_VALUE_RIGHT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_HOME_ITEMS_WANTED:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_m_HomeItemsWanted.CurrentCell = mainEditor_0.dataGridView_m_HomeItemsWanted.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_TM_BIND_CARRTER_ID:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_TASK_EVENT_MONSTER_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_TaskEventMonsterData.CurrentCell = mainEditor_0.dataGridView_TaskEventMonsterData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_TASK_EVENT_MINE_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_TaskEventMineData.CurrentCell = mainEditor_0.dataGridView_TaskEventMineData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_TASK_EVENT_TASK_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_TaskEventTaskData.CurrentCell = mainEditor_0.dataGridView_TaskEventTaskData.Rows[ElementIndex].Cells[1];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 6;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 6;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 6;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 1;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_SL_USE_ITEM_IDS:
			mainEditor_0.tabControl1.SelectedIndex = 1;
			mainEditor_0.dataGridView_SpecialParameters_UseItemIDs.CurrentCell = mainEditor_0.dataGridView_SpecialParameters_UseItemIDs.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_SL_COMPLETE_TASK_IDS:
			mainEditor_0.tabControl1.SelectedIndex = 1;
			mainEditor_0.dataGridView_SpecialParameters_CompleteTaskIDs.CurrentCell = mainEditor_0.dataGridView_SpecialParameters_CompleteTaskIDs.Rows[ElementIndex].Cells[1];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_DELV_REGION:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 1;
			mainEditor_0.dataGridView_m_pDelvRegion.CurrentCell = mainEditor_0.dataGridView_m_pDelvRegion.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_ENTER_REGION:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 1;
			mainEditor_0.dataGridView_m_pEnterRegion.CurrentCell = mainEditor_0.dataGridView_m_pEnterRegion.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_LEAVE_REGION:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 1;
			mainEditor_0.dataGridView_m_pLeaveRegion.CurrentCell = mainEditor_0.dataGridView_m_pLeaveRegion.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_REACH_SITE:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_m_pReachSite.CurrentCell = mainEditor_0.dataGridView_m_pReachSite.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_LEAVE_SITE:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_m_pLeaveSite.CurrentCell = mainEditor_0.dataGridView_m_pLeaveSite.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_GLOBAL_KEY_FOR_AWARD_VAR:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_TRANS_WLD_ID:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_MONS_CTRL:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_CAND_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.checkedListBox_Award_m_CandItems_m_bRandChoose.SelectedIndex = ElementGroupIndex;
			mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.CurrentCell = mainEditor_0.dataGridView_Award_m_CandItems_m_AwardItems.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_PQ_RANKING_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.CurrentCell = mainEditor_0.dataGridView_Award_m_PQRankingAward_m_RankingAward.Rows[ElementIndex].Cells[3];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_CHANGE_KEY:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_plChangeKey.CurrentCell = mainEditor_0.dataGridView_Award_m_plChangeKey.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_TITLE_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_pTitleAward.CurrentCell = mainEditor_0.dataGridView_Award_m_pTitleAward.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.CurrentCell = mainEditor_0.dataGridView_Award_m_SummonedMonsters_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_FACTION_TARGET_DATA:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			mainEditor_0.dataGridView_Award_AwardFactionTargetData.CurrentCell = mainEditor_0.dataGridView_Award_AwardFactionTargetData.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_SUCCESS_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_SUCCESS_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_SUCCESS_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_SUCCESS_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_SUCCESS_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_SUCCESS_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = true;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_FAIL_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_RATIO_FAIL_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_ITEMS_FAIL_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_TASK_EVENT_RATIO_FAIL_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_CARRIER_HP_RATIO_FAIL_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectedIndex = AwardIndex;
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_AWARD_BY_VAR_FAIL_INVITER_AWARD:
			mainEditor_0.tabControl1.SelectedIndex = 4;
			mainEditor_0.tabControl_Awards.SelectedIndex = 0;
			mainEditor_0.radioButton_AwardSuccess.Checked = false;
			mainEditor_0.dataGridView_AwByVar_AwardVar.CurrentCell = mainEditor_0.dataGridView_AwByVar_AwardVar.Rows[AwardIndex].Cells[0];
			ACE.sTASKedit.MainEditor.MainEditor.EnableSelectAward = true;
			mainEditor_0.select_award(null, null);
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_FAIL_1_KEY_VALUE_LEFT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_FAIL_1_KEY_VALUE_RIGHT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_FAIL_2_KEY_VALUE_LEFT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_FAIL_2_KEY_VALUE_RIGHT_NUM:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 3;
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_PROP_SUMMONED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 0;
			mainEditor_0.tabControl_BasicProperties.SelectedIndex = 4;
			mainEditor_0.dataGridView_PropMonsterSummoned_m_Monsters.CurrentCell = mainEditor_0.dataGridView_PropMonsterSummoned_m_Monsters.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_UNWANTED_MONSTERS:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_m_MonsterUnwanted.CurrentCell = mainEditor_0.dataGridView_m_MonsterUnwanted.Rows[ElementIndex].Cells[0];
			break;
		case GlobalData.TASKELEMENTS_TYPE.TASKS_MONSTER_UNWANTED_ITEMS:
			mainEditor_0.tabControl1.SelectedIndex = 3;
			mainEditor_0.dataGridView_m_MonsterUnwanted.CurrentCell = mainEditor_0.dataGridView_m_MonsterUnwanted.Rows[ElementIndex].Cells[2];
			break;
		}
		mainEditor_0.listBox_Award_m_Ratios_m_Counts.SelectionMode = SelectionMode.MultiExtended;
	}
}
