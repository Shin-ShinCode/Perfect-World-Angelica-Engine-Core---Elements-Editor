using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.Pck;
using ACE.Pck.Package;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes.Extensions;

internal class Extensions
{
	private static readonly object object_0 = new object();

	[DllImport("Kernel32.dll")]
	private static extern bool ReadProcessMemory(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, int int_0, out IntPtr intptr_2);

	public static string GetRealmLevelName(int value)
	{
		string result = string.Empty;
		if (value != 0 && value <= 100)
		{
			if (value > 0 && value < 11)
			{
				result = GProD.TX(3170) + value;
			}
			else if (value > 10 && value < 21)
			{
				result = GProD.TX(3171) + (value - 10);
			}
			else if (value > 20 && value < 31)
			{
				result = GProD.TX(3172) + (value - 20);
			}
			else if (value > 30 && value < 41)
			{
				result = GProD.TX(3173) + (value - 30);
			}
			else if (value > 40 && value < 51)
			{
				result = GProD.TX(3174) + (value - 40);
			}
			else if (value > 50 && value < 61)
			{
				result = GProD.TX(3175) + (value - 50);
			}
			else if (value > 60 && value < 71)
			{
				result = GProD.TX(3176) + (value - 60);
			}
			else if (value > 70 && value < 81)
			{
				result = GProD.TX(3177) + (value - 70);
			}
			else if (value > 80 && value < 91)
			{
				result = GProD.TX(3178) + (value - 80);
			}
			else if (value > 90 && value < 101)
			{
				result = GProD.TX(3179) + (value - 90);
			}
		}
		else
		{
			result = GProD.TX(402);
		}
		return result;
	}

	public static string GetOccupationsName(ATaskTemplFixedData FixedData)
	{
		string text = string.Empty;
		for (int i = 0; i < FixedData.m_Occupations.Length && i < FixedData.m_ulOccupations; i++)
		{
			if (text != string.Empty)
			{
				text += Class16.smethod_0(1648942920);
			}
			text += GProD.TX(1120 + FixedData.m_Occupations[i]);
		}
		return text;
	}

	public static string DecodingCharacterComboId(string character_combo_id)
	{
		string text = string.Empty;
		if ((character_combo_id != Class16.smethod_0(1648924112) && character_combo_id != Class16.smethod_0(1649263799) && GProD.eLC.Version < 52) || (character_combo_id != Class16.smethod_0(1648924112) && character_combo_id != Class16.smethod_0(1649263801) && GProD.eLC.Version < 227) || (character_combo_id != Class16.smethod_0(1648924112) && character_combo_id != Class16.smethod_0(1649263820) && GProD.eLC.Version < 340) || (character_combo_id != Class16.smethod_0(1648924112) && character_combo_id != Class16.smethod_0(1649263824) && GProD.eLC.Version < 501) || (character_combo_id != Class16.smethod_0(1648924112) && character_combo_id != Class16.smethod_0(1649263844)))
		{
			text += GProD.TX(7017);
			int.TryParse(character_combo_id, out var result);
			List<int> list = new List<int>(GlobalFunctions.GetPowers(result));
			for (int i = 0; i < list.Count; i++)
			{
				text = ((list[i] >= 15) ? (text + string.Format(Class16.smethod_0(1649263848), list[i])) : (text + Class16.smethod_0(1648942211) + GProD.TX(1120 + list[i])));
			}
			text += Class16.smethod_0(1648941987);
		}
		return text;
	}

	public static string DecodingProcType(string proc_type)
	{
		string text = string.Empty;
		int.TryParse(proc_type, out var result);
		List<int> list = new List<int>(GlobalFunctions.GetPowers(result));
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] < 25)
			{
				if (list[i] != 6 && list[i] != 13 && list[i] != 15)
				{
					text += GProD.TX(4000 + list[i]);
				}
			}
			else
			{
				text += string.Format(Class16.smethod_0(1649263900), list[i]);
			}
		}
		return text;
	}

	public static string DecodingOccupation(string occupations)
	{
		string text = string.Empty;
		if (occupations != Class16.smethod_0(1648924112))
		{
			int.TryParse(occupations, out var result);
			List<int> list = new List<int>(GlobalFunctions.GetPowers(result));
			for (int i = 0; i < list.Count; i++)
			{
				text = ((list[i] >= 16) ? (text + string.Format(Class16.smethod_0(1649263935), list[i])) : (text + GProD.TX(1120 + list[i]) + Class16.smethod_0(1648941987)));
			}
		}
		return text;
	}

	public static string DecodingForce(string forces)
	{
		string text = string.Empty;
		if (forces != Class16.smethod_0(1648924112))
		{
			int.TryParse(forces, out var result);
			List<int> list = new List<int>(GlobalFunctions.GetPowers(result));
			for (int i = 0; i < list.Count; i++)
			{
				text = ((list[i] >= 3) ? (text + string.Format(Class16.smethod_0(1649263963), list[i])) : (text + GProD.TX(2501 + list[i]) + Class16.smethod_0(1648941987)));
			}
		}
		return text;
	}

	public static string DecodingFoodMask(string food_mask)
	{
		string text = string.Empty;
		if (food_mask != Class16.smethod_0(1648924112))
		{
			text += GProD.TX(7050);
			int.TryParse(food_mask, out var result);
			List<int> list = new List<int>(GlobalFunctions.GetPowers(result));
			for (int i = 0; i < list.Count; i++)
			{
				text = ((list[i] >= 5) ? (text + string.Format(Class16.smethod_0(1649263994), list[i])) : (text + Class16.smethod_0(1648942211) + GProD.TX(3050 + list[i])));
			}
			text += Class16.smethod_0(1648941987);
		}
		return text;
	}

	public static string DecodingEquipMask(string equip_mask)
	{
		string text = string.Empty;
		if (equip_mask != Class16.smethod_0(1648924112))
		{
			int.TryParse(equip_mask, out var result);
			List<int> list = new List<int>(GlobalFunctions.GetPowers(result));
			for (int i = 0; i < list.Count; i++)
			{
				text = ((list[i] >= 28) ? (text + string.Format(Class16.smethod_0(1649264037), list[i])) : (text + GProD.TX(3700 + list[i])));
			}
		}
		return text + Class16.smethod_0(1648941987);
	}

	public static string DecodingKidMask(string kid_mask)
	{
		string text = string.Empty;
		if (kid_mask != Class16.smethod_0(1648924112))
		{
			text += GProD.TX(7157);
			int.TryParse(kid_mask, out var result);
			List<int> list = new List<int>(GlobalFunctions.GetPowers(result));
			for (int i = 0; i < list.Count; i++)
			{
				text = ((list[i] >= 11) ? (text + string.Format(Class16.smethod_0(1649264065), list[i])) : (text + Class16.smethod_0(1648942211) + GProD.TX(4200 + list[i])));
			}
			text += Class16.smethod_0(1648941987);
		}
		return text;
	}

	public static string DecodingGrowthTargetMask(uint growth_target_mask)
	{
		string text = string.Empty;
		if (growth_target_mask != 0)
		{
			List<int> list = new List<int>(GlobalFunctions.GetPowers((int)growth_target_mask));
			for (int i = 0; i < list.Count; i++)
			{
				text = ((list[i] >= 24) ? (text + string.Format(Class16.smethod_0(1649264099), list[i])) : (text + GProD.TX(3801 + list[i]) + Class16.smethod_0(1648941987)));
			}
		}
		else
		{
			text += GProD.TX(3800);
		}
		return text;
	}

	public static string DecodingGrowthTargetMask2(uint growth_target_mask)
	{
		string text = string.Empty;
		if (growth_target_mask != 0)
		{
			List<int> list = new List<int>(GlobalFunctions.GetPowers((int)growth_target_mask));
			for (int i = 0; i < list.Count; i++)
			{
				if (text != string.Empty)
				{
					text += Class16.smethod_0(1649263127);
					break;
				}
				text = ((list[i] >= 24) ? (text + string.Format(Class16.smethod_0(1649263130), list[i])) : (text + GProD.TX(3801 + list[i])));
			}
		}
		else
		{
			text += GProD.TX(3800);
		}
		return text;
	}

	public static string GetOptionParam(int param, int id)
	{
		string result = string.Empty;
		try
		{
			if (param < 0)
			{
				switch ((GlobalData.SERVICE_TYPE)param)
				{
				case GlobalData.SERVICE_TYPE.NPC_TALK:
					result = GProD.TX(2961);
					break;
				case GlobalData.SERVICE_TYPE.NPC_SELL:
					result = GProD.TX(2962);
					break;
				case GlobalData.SERVICE_TYPE.NPC_BUY:
					result = GProD.TX(2963);
					break;
				case GlobalData.SERVICE_TYPE.NPC_REPAIR:
					result = GProD.TX(2964);
					break;
				case GlobalData.SERVICE_TYPE.NPC_INSTALL:
					result = GProD.TX(2965);
					break;
				case GlobalData.SERVICE_TYPE.NPC_UNINSTALL:
					result = GProD.TX(2966);
					break;
				case GlobalData.SERVICE_TYPE.NPC_GIVE_TASK:
					result = GProD.TX(2967) + Class16.smethod_0(1648942211) + id;
					break;
				case GlobalData.SERVICE_TYPE.NPC_COMPLETE_TASK:
					result = GProD.TX(2968) + Class16.smethod_0(1648942211) + id;
					break;
				case GlobalData.SERVICE_TYPE.NPC_GIVE_TASK_MATTER:
					result = GProD.TX(2969);
					break;
				case GlobalData.SERVICE_TYPE.NPC_SKILL:
					result = GProD.TX(2970);
					break;
				case GlobalData.SERVICE_TYPE.NPC_HEAL:
					result = GProD.TX(2971);
					break;
				case GlobalData.SERVICE_TYPE.NPC_TRANSMIT:
					result = GProD.TX(2972);
					break;
				case GlobalData.SERVICE_TYPE.NPC_TRANSPORT:
					result = GProD.TX(2973);
					break;
				case GlobalData.SERVICE_TYPE.NPC_PROXY:
					result = GProD.TX(2974);
					break;
				case GlobalData.SERVICE_TYPE.NPC_STORAGE:
					result = GProD.TX(2975);
					break;
				case GlobalData.SERVICE_TYPE.NPC_MAKE:
					result = GProD.TX(2976);
					break;
				case GlobalData.SERVICE_TYPE.NPC_DECOMPOSE:
					result = GProD.TX(2977);
					break;
				case GlobalData.SERVICE_TYPE.TALK_RETURN:
					result = GProD.TX(2978);
					break;
				case GlobalData.SERVICE_TYPE.TALK_EXIT:
					result = GProD.TX(2979);
					break;
				case GlobalData.SERVICE_TYPE.NPC_STORAGE_PASSWORD:
					result = GProD.TX(2980);
					break;
				case GlobalData.SERVICE_TYPE.NPC_IDENTIFY:
					result = GProD.TX(2981);
					break;
				case GlobalData.SERVICE_TYPE.TALK_GIVEUP_TASK:
					result = GProD.TX(2982) + Class16.smethod_0(1648942211) + id;
					break;
				case GlobalData.SERVICE_TYPE.NPC_WAR_TOWERBUILD:
					result = GProD.TX(2983);
					break;
				case GlobalData.SERVICE_TYPE.NPC_RESETPROP:
					result = GProD.TX(2984);
					break;
				case GlobalData.SERVICE_TYPE.NPC_PETNAME:
					result = GProD.TX(2985);
					break;
				case GlobalData.SERVICE_TYPE.NPC_PETLEARNSKILL:
					result = GProD.TX(2986);
					break;
				case GlobalData.SERVICE_TYPE.NPC_PETFORGETSKILL:
					result = GProD.TX(2987);
					break;
				case GlobalData.SERVICE_TYPE.NPC_EQUIPBIND:
					result = GProD.TX(2988);
					break;
				case GlobalData.SERVICE_TYPE.NPC_EQUIPDESTROY:
					result = GProD.TX(2989);
					break;
				case GlobalData.SERVICE_TYPE.NPC_EQUIPUNDESTROY:
					result = GProD.TX(2990);
					break;
				case GlobalData.SERVICE_TYPE.NPC_ACCOUNT_STORAGE:
					result = GProD.TX(2991);
					break;
				case GlobalData.SERVICE_TYPE.NPC_ENGRAVE:
					result = GProD.TX(2992);
					break;
				case GlobalData.SERVICE_TYPE.NPC_RANDPROP:
					result = GProD.TX(2993);
					break;
				}
			}
			else
			{
				result = GProD.TX(2960) + Class16.smethod_0(1648942211) + param;
			}
		}
		catch
		{
			result = string.Empty;
		}
		return result;
	}

	public static ArrayList SetIndexesRows(DataGridViewSelectedCellCollection SelectedCells)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < SelectedCells.Count; i++)
		{
			bool flag = true;
			for (int j = 0; j < arrayList.Count; j++)
			{
				if ((int)arrayList[j] == SelectedCells[i].RowIndex)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				arrayList.Add(SelectedCells[i].RowIndex);
			}
		}
		arrayList.Sort();
		return arrayList;
	}

	public static ArrayList SetIndexesColumns(DataGridViewSelectedCellCollection SelectedCells)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < SelectedCells.Count; i++)
		{
			bool flag = true;
			for (int j = 0; j < arrayList.Count; j++)
			{
				if ((int)arrayList[j] == SelectedCells[i].ColumnIndex)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				arrayList.Add(SelectedCells[i].ColumnIndex);
			}
		}
		arrayList.Sort();
		return arrayList;
	}

	public static Color GetColor(ATaskTemplFixedData FixedData)
	{
		string name = FixedData.Name;
		Color result = Color.White;
		switch ((GlobalData.ENUM_TASK_TYPE)FixedData.m_ulType)
		{
		case GlobalData.ENUM_TASK_TYPE.enumTTDaily:
			if (GlobalData.version >= 120)
			{
				result = ((GlobalData.version < 156) ? Color.FromArgb(100, 185, 250) : Color.FromArgb(38, 178, 255));
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTLevel2:
			if (GlobalData.version >= 120)
			{
				result = Color.FromArgb(238, 156, 15);
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTMajor:
			if (GlobalData.version >= 120)
			{
				result = ((GlobalData.version < 156) ? Color.FromArgb(255, 150, 255) : Color.FromArgb(20, 255, 255));
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTBranch:
			if (GlobalData.version >= 120)
			{
				result = Color.FromArgb(255, 255, 255);
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTEvent:
			if (GlobalData.version >= 120)
			{
				result = ((GlobalData.version < 156) ? Color.FromArgb(255, 255, 0) : Color.FromArgb(150, 224, 255));
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTQiShaList:
			if (GlobalData.version >= 120)
			{
				result = ((GlobalData.version < 161) ? ((GlobalData.version < 156) ? Color.FromArgb(180, 180, 255) : Color.FromArgb(255, 255, 255)) : Color.FromArgb(150, 224, 255));
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTFaction:
			if (GlobalData.version >= 120)
			{
				result = ((GlobalData.version < 156) ? Color.FromArgb(0, 200, 200) : Color.FromArgb(255, 255, 255));
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTFunction:
			if (GlobalData.version >= 120)
			{
				result = ((GlobalData.version < 156) ? Color.FromArgb(120, 255, 120) : Color.FromArgb(20, 196, 100));
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTLegend:
			if (GlobalData.version >= 120)
			{
				result = ((GlobalData.version < 126) ? Color.FromArgb(255, 120, 120) : ((GlobalData.version < 156) ? Color.FromArgb(255, 0, 0) : Color.FromArgb(255, 255, 255)));
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTQuestion:
			if (GlobalData.version >= 120)
			{
				result = Color.FromArgb(146, 255, 216);
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTHome:
			if (GlobalData.version >= 120)
			{
				result = ((GlobalData.version < 156) ? Color.FromArgb(255, 120, 120) : Color.FromArgb(84, 197, 255));
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTGrowth:
			if (GlobalData.version >= 120)
			{
				result = Color.FromArgb(20, 196, 100);
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTStory:
			if (GlobalData.version >= 120)
			{
				result = Color.FromArgb(255, 173, 255);
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTInstance:
			if (GlobalData.version >= 120)
			{
				result = Color.FromArgb(255, 255, 255);
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTReserved:
			if (GlobalData.version >= 236)
			{
				result = Color.FromArgb(0, 255, 255);
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTNewAnecdote:
			if (GlobalData.version >= 237)
			{
				result = Color.FromArgb(240, 128, 128);
			}
			break;
		}
		if (FixedData.m_bKeyTask)
		{
			result = Color.FromArgb(238, 156, 15);
		}
		if (name.StartsWith(Class16.smethod_0(1648935659)))
		{
			try
			{
				if (GlobalData.version <= 119 || ((FixedData.m_ulType == 105 || FixedData.m_ulType == 110) && !FixedData.m_bKeyTask))
				{
					result = mConvert.StringToColor(name, 1);
					if (result.A == 1)
					{
						result = Color.White;
					}
				}
			}
			catch
			{
				result = Color.White;
			}
		}
		return result;
	}

	public static Image GetIcon(ATaskTemplFixedData ataskTemplFixedData_0)
	{
		Image result = GProD.imageList1.Images[0];
		switch ((GlobalData.ENUM_TASK_TYPE)ataskTemplFixedData_0.m_ulType)
		{
		case GlobalData.ENUM_TASK_TYPE.enumTTDaily:
			result = GProD.imageList1.Images[8];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTLevel2:
			if (GlobalData.version >= 156)
			{
				result = GProD.imageList1.Images[0];
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTMajor:
			result = ((GlobalData.version < 156) ? GProD.imageList1.Images[10] : GProD.imageList1.Images[16]);
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTBranch:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTEvent:
			result = GProD.imageList1.Images[8];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTQiShaList:
			result = GProD.imageList1.Images[6];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTFaction:
			result = GProD.imageList1.Images[4];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTFunction:
			result = GProD.imageList1.Images[4];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTLegend:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTQuestion:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTHome:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTGrowth:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTStory:
			result = GProD.imageList1.Images[12];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTInstance:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTReserved:
			result = GProD.imageList1.Images[5];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTNewAnecdote:
			result = GProD.imageList1.Images[7];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTCommonOld:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTRepeatedOld:
			result = GProD.imageList1.Images[8];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTKeyOld:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTBossOld:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTInstanceOld:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTScrollOld:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTBusinessOld:
			result = GProD.imageList1.Images[4];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTFeelingOld:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTTacticsOld:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTRegionOld:
			result = GProD.imageList1.Images[6];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTSevenKillListOld:
			result = GProD.imageList1.Images[0];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTFactionOld:
			result = GProD.imageList1.Images[6];
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTHintOld:
			result = GProD.imageList1.Images[0];
			break;
		}
		if (ataskTemplFixedData_0.m_bKeyTask)
		{
			result = ((GlobalData.version < 156) ? GProD.imageList1.Images[2] : GProD.imageList1.Images[14]);
		}
		if (ataskTemplFixedData_0.m_bGM)
		{
			result = GProD.imageList1.Images[GProD.imageList1.Images.Count - 2];
		}
		if (ataskTemplFixedData_0.m_bDiscardedTask)
		{
			result = GProD.imageList1.Images[GProD.imageList1.Images.Count - 1];
		}
		return result;
	}

	public static ArrayList RowsMove(DataGridView dataGridView_0, int RowIndex)
	{
		ACE.sTASKedit.MainEditor.MainEditor.LockedChange = true;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		if (Control.ModifierKeys == System.Windows.Forms.Keys.Alt && Control.MouseButtons == MouseButtons.Right && dataGridView_0.Rows.Count > 0 && RowIndex >= 0 && RowIndex < dataGridView_0.Rows.Count)
		{
			arrayList = SetIndexesRows(dataGridView_0.SelectedCells);
			if (RowIndex < ACE.sTASKedit.MainEditor.MainEditor.LeaveIndex && (int)arrayList[0] > 0)
			{
				for (int i = 0; i < arrayList.Count; i++)
				{
					ArrayList arrayList3 = new ArrayList();
					for (int j = 0; j < dataGridView_0.Rows[(int)arrayList[i]].Cells.Count; j++)
					{
						arrayList3.Add(dataGridView_0.Rows[(int)arrayList[i]].Cells[j].Value);
					}
					for (int k = 0; k < dataGridView_0.Rows[(int)arrayList[i]].Cells.Count; k++)
					{
						dataGridView_0.Rows[(int)arrayList[i]].Cells[k].Value = dataGridView_0.Rows[(int)arrayList[i] - 1].Cells[k].Value;
					}
					for (int l = 0; l < arrayList3.Count; l++)
					{
						dataGridView_0.Rows[(int)arrayList[i] - 1].Cells[l].Value = arrayList3[l];
					}
					for (int m = 0; m < dataGridView_0.ColumnCount; m++)
					{
						dataGridView_0.Rows[(int)arrayList[i] - 1].Cells[m].Selected = true;
						dataGridView_0.Rows[(int)arrayList[i]].Cells[m].Selected = false;
					}
				}
				for (int n = (int)arrayList[0] - 1; n <= (int)arrayList[arrayList.Count - 1]; n++)
				{
					arrayList2.Add(n);
				}
			}
			else if (RowIndex > ACE.sTASKedit.MainEditor.MainEditor.LeaveIndex && (int)arrayList[arrayList.Count - 1] < dataGridView_0.Rows.Count - 1)
			{
				for (int num = arrayList.Count - 1; num >= 0; num--)
				{
					ArrayList arrayList4 = new ArrayList();
					for (int num2 = 0; num2 < dataGridView_0.Rows[(int)arrayList[num]].Cells.Count; num2++)
					{
						arrayList4.Add(dataGridView_0.Rows[(int)arrayList[num]].Cells[num2].Value);
					}
					for (int num3 = 0; num3 < dataGridView_0.Rows[(int)arrayList[num]].Cells.Count; num3++)
					{
						dataGridView_0.Rows[(int)arrayList[num]].Cells[num3].Value = dataGridView_0.Rows[(int)arrayList[num] + 1].Cells[num3].Value;
					}
					for (int num4 = 0; num4 < arrayList4.Count; num4++)
					{
						dataGridView_0.Rows[(int)arrayList[num] + 1].Cells[num4].Value = arrayList4[num4];
					}
					for (int num5 = 0; num5 < dataGridView_0.ColumnCount; num5++)
					{
						dataGridView_0.Rows[(int)arrayList[num] + 1].Cells[num5].Selected = true;
						dataGridView_0.Rows[(int)arrayList[num]].Cells[num5].Selected = false;
					}
				}
				for (int num6 = (int)arrayList[0]; num6 <= (int)arrayList[arrayList.Count - 1] + 1; num6++)
				{
					arrayList2.Add(num6);
				}
			}
		}
		ACE.sTASKedit.MainEditor.MainEditor.LockedChange = false;
		return arrayList2;
	}

	public static float[] GetCoordinates(int ClientVer)
	{
		float[] array = new float[3];
		if (ClientVer > -1)
		{
			Process[] processesByName = Process.GetProcessesByName(Class16.smethod_0(1649099831));
			if (processesByName.Length != 0)
			{
				IntPtr handle = processesByName[0].Handle;
				byte[] array2 = new byte[4];
				Offset offset = (Offset)GProD.clientOffsets[ClientVer];
				int num = 0;
				IntPtr intptr_;
				for (int i = 0; i < offset.BaseChain.Length; i++)
				{
					ReadProcessMemory(handle, (IntPtr)(num + offset.BaseChain[i]), array2, 4, out intptr_);
					num = BitConverter.ToInt32(array2, 0);
				}
				ReadProcessMemory(handle, (IntPtr)(num + offset.DirX), array2, 4, out intptr_);
				BitConverter.ToSingle(array2, 0);
				ReadProcessMemory(handle, (IntPtr)(num + offset.DirY), array2, 4, out intptr_);
				BitConverter.ToSingle(array2, 0);
				ReadProcessMemory(handle, (IntPtr)(num + offset.DirZ), array2, 4, out intptr_);
				BitConverter.ToSingle(array2, 0);
				ReadProcessMemory(handle, (IntPtr)(num + offset.PosX), array2, 4, out intptr_);
				float num2 = BitConverter.ToSingle(array2, 0);
				ReadProcessMemory(handle, (IntPtr)(num + offset.PosY), array2, 4, out intptr_);
				float num3 = BitConverter.ToSingle(array2, 0);
				ReadProcessMemory(handle, (IntPtr)(num + offset.PosZ), array2, 4, out intptr_);
				float num4 = BitConverter.ToSingle(array2, 0);
				array[0] = num2;
				array[1] = num3;
				array[2] = num4;
			}
		}
		return array;
	}

	public static void WriteLog(string message)
	{
		lock (object_0)
		{
			File.AppendAllText(Application.StartupPath + Class16.smethod_0(1649263181), Class16.smethod_0(1648924364) + DateTime.Now.ToString(Class16.smethod_0(1649263197)) + Class16.smethod_0(1648924347) + message + Class16.smethod_0(1648924428), Encoding.Unicode);
		}
	}

	public static string GetTaskName(ATaskTempl[] tasks, int task_id_space, int task_id, bool ColorClean = true)
	{
		string empty = string.Empty;
		if (task_id != 0)
		{
			ATaskTempl aTaskTempl = null;
			aTaskTempl = GetTask(tasks, task_id_space, task_id);
			if (aTaskTempl != null)
			{
				empty = aTaskTempl.Name;
				if (ColorClean)
				{
					empty = GlobalFunctions.ColorClean(empty);
				}
			}
			else
			{
				empty = GProD.TX(404);
			}
		}
		else
		{
			empty = GProD.TX(402);
		}
		return empty;
	}

	public static ATaskTempl GetTask(ATaskTempl[] tasks, int task_id_space, int task_id)
	{
		ATaskTempl aTaskTempl = null;
		if (ACE.sTASKedit.MainEditor.MainEditor.LoadedTask)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				if (tasks[i].m_usIDSpace != task_id_space || tasks[i].m_ID != task_id)
				{
					aTaskTempl = GetTask(tasks[i].pSub, task_id_space, task_id);
					if (aTaskTempl != null)
					{
						break;
					}
					continue;
				}
				return tasks[i];
			}
		}
		return aTaskTempl;
	}

	public static string GetElParamValue(eListCollection eLC, int ListIndex, int ItemIndex, string Parameter)
	{
		string result = null;
		for (int i = 0; i < eLC.Lists[ListIndex].elementFields.Length; i++)
		{
			if (eLC.Lists[ListIndex].elementFields[i] == Parameter)
			{
				result = eLC.GetValue(ListIndex, ItemIndex, i);
				break;
			}
		}
		return result;
	}

	public static Dictionary<int, string> ReadStringFromPCK(ACE.Pck.Package.FileInfo[] FileTable, string PackagePath, string GameMode, string File)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		StreamReader streamReader = new StreamReader(Functions.GetFile(FileTable, PackagePath, GameMode, File));
		try
		{
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine();
				while (text.StartsWith(Class16.smethod_0(1648942211)) || text.StartsWith(Class16.smethod_0(1648904383)))
				{
					text = text.Remove(0, 1);
				}
				if (!(text != string.Empty) || text.StartsWith(Class16.smethod_0(1648929947)) || text.StartsWith(Class16.smethod_0(1648904229)))
				{
					continue;
				}
				int key = Convert.ToInt32(text.Substring(0, text.IndexOf(Class16.smethod_0(1648904453))));
				string text2 = text.Substring(text.IndexOf(Class16.smethod_0(1648904453)) + 1);
				int num = text2.IndexOf(Class16.smethod_0(1648904453));
				if (num > -1)
				{
					text2 = text2.Substring(0, num);
				}
				else
				{
					int num2 = -1;
					string text3 = string.Empty;
					do
					{
						text2 += text3;
						text3 = Class16.smethod_0(1648924428) + streamReader.ReadLine();
						num2 = text3.IndexOf(Class16.smethod_0(1648904453));
					}
					while (num2 < 0);
					text2 += text3.Substring(0, num2);
				}
				dictionary.Add(key, text2);
			}
			streamReader.Close();
			return dictionary;
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
	}

	public static Dictionary<int, string> ReadString(string FilePath)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		StreamReader streamReader = new StreamReader(new FileStream(FilePath, FileMode.Open, FileAccess.Read));
		try
		{
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine();
				while (text.StartsWith(Class16.smethod_0(1648942211)) || text.StartsWith(Class16.smethod_0(1648904383)))
				{
					text = text.Remove(0, 1);
				}
				if (!(text != string.Empty) || text.StartsWith(Class16.smethod_0(1648929947)) || text.StartsWith(Class16.smethod_0(1648904229)))
				{
					continue;
				}
				int key = Convert.ToInt32(text.Substring(0, text.IndexOf(Class16.smethod_0(1648904453))));
				string text2 = text.Substring(text.IndexOf(Class16.smethod_0(1648904453)) + 1);
				int num = text2.IndexOf(Class16.smethod_0(1648904453));
				if (num > -1)
				{
					text2 = text2.Substring(0, num);
				}
				else
				{
					int num2 = -1;
					string text3 = string.Empty;
					do
					{
						text2 += text3;
						text3 = Class16.smethod_0(1648924428) + streamReader.ReadLine();
						num2 = text3.IndexOf(Class16.smethod_0(1648904453));
					}
					while (num2 < 0);
					text2 += text3.Substring(0, num2);
				}
				dictionary.Add(key, text2);
			}
			streamReader.Close();
			return dictionary;
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
	}

	public static Dictionary<int, string> ReadInstanceString(string FilePath)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		StreamReader streamReader = new StreamReader(new FileStream(FilePath, FileMode.Open, FileAccess.Read));
		try
		{
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine();
				if (!text.StartsWith(Class16.smethod_0(1648929947)) && !text.StartsWith(Class16.smethod_0(1648904229)) && !string.IsNullOrWhiteSpace(text))
				{
					string[] array = text.Split('\t');
					if (array.Length >= 5)
					{
						int key = Convert.ToInt32(array[0]);
						string text2 = Class16.smethod_0(1648924364) + array[1] + Class16.smethod_0(1649263219) + array[2] + Class16.smethod_0(1649263219) + array[3] + Class16.smethod_0(1648924347) + array[4];
						dictionary.Add(key, text2.Replace(Class16.smethod_0(1648903412), Class16.smethod_0(1648924428)));
					}
				}
			}
			streamReader.Close();
			return dictionary;
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
	}

	public static void ConvertServerToClientCoords(Task_Region[] Region, DataGridView DGV, TextBox textBox_Min, TextBox textBox_Max)
	{
		if (Region.Length != 0 && DGV.SelectedCells.Count > 0)
		{
			int rowIndex = DGV.SelectedCells[DGV.SelectedCells.Count - 1].RowIndex;
			textBox_Min.Text = GetClientCoords(Region[rowIndex].zvMin);
			textBox_Max.Text = GetClientCoords(Region[rowIndex].zvMax);
		}
		else
		{
			textBox_Min.Text = Class16.smethod_0(1649263236);
			textBox_Max.Text = Class16.smethod_0(1649263236);
		}
	}

	public static void ConvertServerToClientCoords1(ZONE_VERT Zone, ToolTip toolTip, TextBox textBox_x, TextBox textBox_y, TextBox textBox_z)
	{
		string empty = string.Empty;
		if (Zone != null)
		{
			empty = GetClientCoords(Zone);
			if (toolTip.GetToolTip(textBox_x) != empty)
			{
				toolTip.SetToolTip(textBox_x, empty);
			}
			if (toolTip.GetToolTip(textBox_y) != empty)
			{
				toolTip.SetToolTip(textBox_y, empty);
			}
			if (toolTip.GetToolTip(textBox_z) != empty)
			{
				toolTip.SetToolTip(textBox_z, empty);
			}
		}
	}

	public static void SetMidleClientCoords(Task_Region[] Region, int RowIndex)
	{
		if (Region.Length != 0 && RowIndex > -1)
		{
			int num = Convert.ToInt32(mConvert.ServerXToClientX(Region[RowIndex].zvMin.Single_0[0]));
			int num2 = Convert.ToInt32(mConvert.ServerYToClientY(Region[RowIndex].zvMin.Single_0[1]));
			int num3 = Convert.ToInt32(mConvert.ServerZToClientZ(Region[RowIndex].zvMin.Single_0[2]));
			int num4 = Convert.ToInt32(mConvert.ServerXToClientX(Region[RowIndex].zvMax.Single_0[0]));
			int num5 = Convert.ToInt32(mConvert.ServerYToClientY(Region[RowIndex].zvMax.Single_0[1]));
			int num6 = Convert.ToInt32(mConvert.ServerZToClientZ(Region[RowIndex].zvMax.Single_0[2]));
			Clipboard.SetText(Convert.ToString(num + (num4 - num) / 2) + Class16.smethod_0(1648942920) + Convert.ToString(num3 + (num6 - num3) / 2) + Class16.smethod_0(1648899468) + num2 + Class16.smethod_0(1648941518) + num5 + Class16.smethod_0(1648942897));
		}
	}

	public static void SetMidleClientCoords1(Task_Region[] Region, int RowIndex)
	{
		if (Region.Length != 0 && RowIndex > -1)
		{
			int num = Convert.ToInt32(mConvert.ServerXToClientX(Region[RowIndex].zvMin.Single_0[0]));
			int num2 = Convert.ToInt32(mConvert.ServerYToClientY(Region[RowIndex].zvMin.Single_0[1]));
			int num3 = Convert.ToInt32(mConvert.ServerZToClientZ(Region[RowIndex].zvMin.Single_0[2]));
			int num4 = Convert.ToInt32(mConvert.ServerXToClientX(Region[RowIndex].zvMax.Single_0[0]));
			int num5 = Convert.ToInt32(mConvert.ServerYToClientY(Region[RowIndex].zvMax.Single_0[1]));
			int num6 = Convert.ToInt32(mConvert.ServerZToClientZ(Region[RowIndex].zvMax.Single_0[2]));
			Clipboard.SetText(Convert.ToString(num + (num4 - num) / 2) + Class16.smethod_0(1648942920) + Convert.ToString(num3 + (num6 - num3) / 2) + Class16.smethod_0(1648899468) + num2 + Class16.smethod_0(1648941518) + num5 + Class16.smethod_0(1648942897));
		}
	}

	public static void GetClientCoordsDGV(ZONE_VERT Zone, DataGridView DGV, int Cell_x, int Cell_y, int Cell_z, int ClientVersion)
	{
		float[] coordinates = GetCoordinates(ClientVersion);
		int index = DGV.CurrentRow.Index;
		for (int i = 0; i < 3; i++)
		{
			Zone.Single_0[i] = coordinates[i];
		}
		DGV.Rows[index].Cells[Cell_x].Value = coordinates[0].ToString(Class16.smethod_0(1648964192));
		DGV.Rows[index].Cells[Cell_y].Value = coordinates[1].ToString(Class16.smethod_0(1648964192));
		DGV.Rows[index].Cells[Cell_z].Value = coordinates[2].ToString(Class16.smethod_0(1648964192));
	}

	public static void GetClientCoordsTB(ZONE_VERT Zone, TextBox textBox_x, TextBox textBox_y, TextBox textBox_z, int ClientVersion)
	{
		float[] coordinates = GetCoordinates(ClientVersion);
		for (int i = 0; i < 3; i++)
		{
			Zone.Single_0[i] = coordinates[i];
		}
		textBox_x.Text = coordinates[0].ToString(Class16.smethod_0(1648964192));
		textBox_y.Text = coordinates[1].ToString(Class16.smethod_0(1648964192));
		textBox_z.Text = coordinates[2].ToString(Class16.smethod_0(1648964192));
	}

	public static string GetClientCoords(ZONE_VERT Zone)
	{
		return string.Format(Class16.smethod_0(1649263243), mConvert.ServerXToClientX(Zone.Single_0[0]), mConvert.ServerZToClientZ(Zone.Single_0[2]), mConvert.ServerYToClientY(Zone.Single_0[1]));
	}

	public static Point SetToolTipPos(Control sender)
	{
		Point result = sender.PointToClient(Cursor.Position);
		result.X += Cursor.Current.Size.Width / 2;
		result.Y += Cursor.Current.Size.Height / 2;
		return result;
	}

	public static void InsertColorCodTB(TextBox textBox, string colorcod)
	{
		int selectionStart = textBox.SelectionStart;
		textBox.Text = textBox.Text.Insert(selectionStart, colorcod);
		textBox.SelectionStart = selectionStart + 7;
	}

	public static Color GetVersionColor(int Version)
	{
		Color result = (Color)Lists.VersionsColors[0];
		if (Version >= 198)
		{
			result = (Color)Lists.VersionsColors[9];
		}
		else if (Version >= 194)
		{
			result = (Color)Lists.VersionsColors[8];
		}
		else if (Version >= 191)
		{
			result = (Color)Lists.VersionsColors[7];
		}
		else if (Version >= 140)
		{
			result = (Color)Lists.VersionsColors[6];
		}
		else if (Version >= 126)
		{
			result = (Color)Lists.VersionsColors[5];
		}
		else if (Version >= 112)
		{
			result = (Color)Lists.VersionsColors[4];
		}
		else if (Version >= 108)
		{
			result = (Color)Lists.VersionsColors[3];
		}
		else if (Version >= 94)
		{
			result = (Color)Lists.VersionsColors[2];
		}
		else if (Version >= 75)
		{
			result = (Color)Lists.VersionsColors[1];
		}
		if (TDark.IsDarkMode)
		{
			if (result.ToArgb() == Color.Black.ToArgb())
			{
				return TDark.DarkFore;
			}
			if (result.ToArgb() == Color.DarkGreen.ToArgb())
			{
				return Color.LightGreen;
			}
			if (result.ToArgb() == Color.Maroon.ToArgb())
			{
				return Color.IndianRed;
			}
			if (result.ToArgb() == Color.Purple.ToArgb())
			{
				return Color.MediumPurple;
			}
			if (result.ToArgb() == SystemColors.HotTrack.ToArgb())
			{
				return Color.CornflowerBlue;
			}
			if (result.ToArgb() == Color.Blue.ToArgb())
			{
				return Color.LightBlue;
			}
		}
		return result;
	}

	public static bool CheckFlag(int Value, int Flag)
	{
		return (Value & Flag) != 0;
	}

	public static int GetDictionaryElementIndexByKey(Dictionary<int, int> List, int Key)
	{
		return List.Keys.ToList().IndexOf(Key);
	}

	public static int GetDictionaryElementKeyByIndex(Dictionary<int, int> List, int Index)
	{
		int num = List.Keys.ElementAt(Index);
		if (num > -1)
		{
			return num;
		}
		return 0;
	}
}
