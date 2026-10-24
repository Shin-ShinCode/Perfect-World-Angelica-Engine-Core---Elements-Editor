using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.Cpk;
using ACE.Elements;
using ACE.Elements.eListCollection;
using ACE.RSGlobal;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes;

public class TASKS_HINT
{
	public static CommonStorage CStorage;

	public static ItemsToolTip ToolTipWindow;

	public static int LatestID;

	public static string ShowedText;

	public static bool bUseLevCo;

	public static void ShowTaskToolTip(Control control, ATaskTempl quest, int version, ITEMPOS HighlightItem)
	{
		if (control == null || control.IsDisposed || quest == null || ToolTipWindow == null || CommonStorage.AParams == null || CommonStorage.AParams.DisableAllHints)
		{
			return;
		}
		if (quest.ID != LatestID || string.IsNullOrEmpty(ShowedText))
		{
			string toolTipText = GetToolTipText(quest, version, HighlightItem);
			if (string.IsNullOrEmpty(toolTipText))
			{
				return;
			}
			toolTipText += Class16.smethod_0(1648902161);
			toolTipText += Class16.smethod_0(1648958369);
			LatestID = quest.ID;
			ShowedText = toolTipText;
		}
		ToolTipWindow.ShowToolTip(control, ShowedText);
		ToolTipWindow.IsItemOrTaskToolTip = true;
	}

	public static void ShowTaskToolTip(Control control, int task_id, ITEMPOS HighlightItem)
	{
		ATaskTempl aTaskTempl = null;
		if (task_id <= 0 || CommonStorage.AParams == null || CommonStorage.AParams.TasksHintItemsLimit <= 0)
		{
			return;
		}
		TASKS tasks = DataFiles.Tasks;
		if (tasks != null && tasks.quests != null)
		{
			aTaskTempl = null;
			if (tasks.quests.TryGetValue(task_id, out aTaskTempl))
			{
				ShowTaskToolTip(control, aTaskTempl, DataFiles.Tasks.version, HighlightItem);
			}
		}
	}

	public static string GetToolTipText(ATaskTempl at, int version, ITEMPOS HighlightItem)
	{
		if (at != null && CommonStorage.AParams != null)
		{
			string text = null;
			string empty = string.Empty;
			QUEST_INFO questInfo = TASKS.GetQuestInfo(at, version, addSubQuestText: true);
			if (questInfo == null)
			{
				return null;
			}
			HTML_HELPER hTML_HELPER = new HTML_HELPER();
			hTML_HELPER.bNameBold = true;
			hTML_HELPER.IdAfterName = true;
			hTML_HELPER.ID = questInfo.id;
			Color gray = Color.Gray;
			hTML_HELPER.IDColor = gray;
			hTML_HELPER.Name = questInfo.name;
			ref Color nameColor = ref hTML_HELPER.NameColor;
			nameColor = questInfo.color;
			hTML_HELPER.icon = questInfo.image;
			hTML_HELPER.LinkTaskID = questInfo.id;
			empty += hTML_HELPER.GetItemHtml();
			text = at.m_ulType.ToString();
			TASKS.TaskTypes?.TryGetValue(at.m_ulType, out text);
			empty = string.Concat(empty, Class16.smethod_0(1648958369) + AddProperty(0, text));
			if (at.m_ulOccupations > 0 && at.m_Occupations != null)
			{
				string text2 = string.Empty;
				int num = 0;
				do
				{
					int num2 = Array.IndexOf(at.m_Occupations, num);
					if (num2 > -1 && num2 < at.m_ulOccupations)
					{
						string text3 = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(80, num), null);
						text2 = string.Concat(text2, text3 + Class16.smethod_0(1648942211));
					}
					num++;
				}
				while (num < 12);
				empty = string.Concat(empty, Class16.smethod_0(1648958369) + AddProperty(1, text2));
			}
			int ulPremise_Lev_Max = at.m_ulPremise_Lev_Max;
			int ulPremise_Lev_Min = at.m_ulPremise_Lev_Min;
			string text4 = Class16.smethod_0(1648941518);
			string text5 = string.Concat(ulPremise_Lev_Min + text4, ulPremise_Lev_Max.ToString());
			if (text5 != Class16.smethod_0(1649257738))
			{
				empty = string.Concat(empty, Class16.smethod_0(1648958369) + AddProperty(2, text5));
			}
			int ulGender = at.m_ulGender;
			if ((uint)(ulGender - 1) <= 1u)
			{
				string text6 = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(736, ulGender), null);
				empty = string.Concat(empty, Class16.smethod_0(1648958369) + AddProperty(3, text6));
			}
			empty += AddExtraProps(at);
			Dictionary<ReferenceSubType, TASK_PROPS_PART> taskProps = CreateTasksReferences.GetTaskProps(at, questInfo);
			if (taskProps != null && taskProps.Count > 0)
			{
				int num3 = 0;
				KeyValuePair<ReferenceSubType, TASK_PROPS_PART>[] array = taskProps.ToArray();
				REFERENCE_TYPE_EX refType = default(REFERENCE_TYPE_EX);
				KeyValuePair<ReferenceSubType, TASK_PROPS_PART>[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					KeyValuePair<ReferenceSubType, TASK_PROPS_PART> keyValuePair = array2[i];
					ReferenceSubType key = keyValuePair.Key;
					TASK_PROPS_PART value = keyValuePair.Value;
					ref List<TASKS_ITEM_ENTRY> items = ref value.Items;
					int num4 = 0;
					List<TASKS_ITEM_ENTRY> list = items;
					if (list != null)
					{
						num4 = list.Count;
					}
					string text7 = ELEMENTS_REFERENCES_SUITE.GetRefCaption(DATA_FILES_ENUM.TASKS, key, IsTaskHint: true);
					if (num4 > 1)
					{
						int num5 = num4;
						string text8 = Class16.smethod_0(1648942897);
						text7 = string.Concat(text7, string.Concat(Class16.smethod_0(1648899468) + num5, text8));
					}
					text7 += Class16.smethod_0(1648924402);
					Color color_ = Color.LightSalmon;
					if (key >= ReferenceSubType.TASKS_AWARD_SUCCESS_CAND_ITEMS)
					{
						color_ = Color.LightGreen;
					}
					string text9 = Class16.smethod_0(1648902161);
					string text10 = Class16.smethod_0(1648905490);
					empty = string.Concat(empty, string.Concat(string.Concat(string.Concat(Class16.smethod_0(1649257756) + ACE.RSGlobal.RSGlobal.Color2HTML(color_), text10), text7), text9));
					refType.DataFileType = DATA_FILES_ENUM.TASKS;
					ReferenceType referenceType = (refType.SectionType = value.section);
					refType.SubType = key;
					if (num4 > 0)
					{
						int num6 = ((key == ReferenceSubType.TASKS_AWARD_NPC || key == ReferenceSubType.TASKS_DELV_NPC) ? 1 : 0);
						bool bOneLine = (byte)num6 != 0;
						ItemType item_type;
						switch (referenceType)
						{
						default:
							item_type = ItemType.All;
							break;
						case ReferenceType.TASKS_MATTERS:
							item_type = ItemType.Matter;
							break;
						case ReferenceType.TASKS_TITLES:
							item_type = ItemType.PW_TITLE_CONFIG;
							break;
						case ReferenceType.TASKS_HOME_ITEMS:
							item_type = ItemType.PW_HOME_ITEM_ENTITY;
							break;
						case ReferenceType.TASKS_MONSTERS:
						case ReferenceType.TASKS_NPCS:
						case ReferenceType.TASKS_MINES:
							item_type = ItemType.NpcOrMobOrMine;
							break;
						}
						if (items != null && DataFiles.Elements != null)
						{
							TASKS_ITEM_ENTRY[] array3 = items.ToArray();
							TASKS_ITEM_ENTRY[] array4 = array3;
							for (int j = 0; j < array4.Length; j++)
							{
								TASKS_ITEM_ENTRY tASKS_ITEM_ENTRY = array4[j];
								if (num3 >= CommonStorage.AParams.TasksHintItemsLimit)
								{
									break;
								}
								eListCollection elements = DataFiles.Elements;
								int item_id = tASKS_ITEM_ENTRY.item_id;
								ITEMPOS iTEMPOS = elements.FindItemPos(elements.GetLists(item_type), item_id);
								int num7 = ((iTEMPOS != null && iTEMPOS.Equals(HighlightItem)) ? 1 : 0);
								bool bUnderline = (byte)num7 != 0;
								empty += DataFiles.Elements.EchoItem(iTEMPOS, tASKS_ITEM_ENTRY.ref_info, refType, bOneLine, IsTaskHint: true, item_id, bUnderline);
								num3++;
							}
						}
						if (num3 >= CommonStorage.AParams.TasksHintItemsLimit)
						{
							empty += Class16.smethod_0(1649257791);
							break;
						}
					}
					bUseLevCo = false;
					Dictionary<string, int> props = value.Props;
					if (props == null)
					{
						continue;
					}
					KeyValuePair<string, int>[] array5 = props.ToArray();
					KeyValuePair<string, int>[] array6 = array5;
					for (int k = 0; k < array6.Length; k++)
					{
						KeyValuePair<string, int> keyValuePair2 = array6[k];
						string key2 = keyValuePair2.Key;
						int value2 = keyValuePair2.Value;
						if (TASKS_PROPS.AwardHintProps != null && TASKS_PROPS.AwardHintProps.TryGetValue(key2, out var value3))
						{
							string sValue;
							if (TASKS_PROPS.AwardHintFlags != null && TASKS_PROPS.AwardHintFlags.ContainsKey(key2))
							{
								sValue = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(14, value2), null);
							}
							else
							{
								int num8 = value2;
								sValue = num8.ToString(Class16.smethod_0(1648909972));
							}
							empty = string.Concat(empty, Class16.smethod_0(1648958369) + AddProperty(key2, value3, value2, sValue, IsSubValue: true, value));
						}
					}
				}
			}
			return empty;
		}
		return null;
	}

	public static string GetToolTipText(ATaskTempl quest, ITEMPOS HighlightItem)
	{
		TASKS tasks = DataFiles.Tasks;
		if (tasks != null && tasks.quests != null)
		{
			return GetToolTipText(quest, tasks.version, HighlightItem);
		}
		return null;
	}

	public static string AddExtraProps(ATaskTempl quest)
	{
		string text = string.Empty;
		Dictionary<string, string>.Enumerator enumerator = TASKS_PROPS.MainHintProps.GetEnumerator();
		if (enumerator.MoveNext())
		{
			int num = 0;
			do
			{
				ValueType valueType = enumerator.Current;
				string key = ((KeyValuePair<string, string>)(object)valueType).Key;
				string value = ((KeyValuePair<string, string>)(object)valueType).Value;
				object propValue = ACE.RSGlobal.RSGlobal.GetPropValue(quest, key);
				bool flag = false;
				if (propValue.GetType() == typeof(int))
				{
					num = (int)propValue;
				}
				else if (propValue.GetType() == typeof(bool))
				{
					num = (((bool)propValue) ? 1 : 0);
					flag = true;
				}
				if (!TASKS_PROPS.HintDefaultVals.ContainsKey(key) || num != TASKS_PROPS.HintDefaultVals[key])
				{
					string value2;
					if (flag)
					{
						value2 = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(14, num), null);
					}
					else
					{
						int num2 = num;
						value2 = num2.ToString(Class16.smethod_0(1648909972));
					}
					text = string.Concat(text, Class16.smethod_0(1648958369) + AddProperty(value, value2, IsSubValue: false));
				}
			}
			while (enumerator.MoveNext());
		}
		return text;
	}

	public static string AddProperty(string caption, string value, [MarshalAs(UnmanagedType.U1)] bool IsSubValue)
	{
		Color color_ = Color.LightSalmon;
		string text;
		if (IsSubValue)
		{
			color_ = Color.LightBlue;
			text = Class16.smethod_0(1648902317);
		}
		else
		{
			text = string.Empty;
		}
		string text2 = Class16.smethod_0(1649257807);
		string text3 = Class16.smethod_0(1648905490);
		return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(Class16.smethod_0(1649257823) + ACE.RSGlobal.RSGlobal.Color2HTML(color_), text3), text), caption), text2), value);
	}

	public static string AddProperty(int prop_index, string value)
	{
		return AddProperty(TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(734, prop_index), null), value, IsSubValue: false);
	}

	public static string AddProperty(string prop, string caption, int val, string sValue, [MarshalAs(UnmanagedType.U1)] bool IsSubValue, TASK_PROPS_PART InfoPart)
	{
		if (TASKS_DECODED_VALUES.ValuesDictionary.ContainsKey(prop))
		{
			sValue = TASKS_DECODED_VALUES.DecodeValue(prop, val);
		}
		if (bUseLevCo && (prop == Class16.smethod_0(1649257852) || prop == Class16.smethod_0(1649257858)))
		{
			int num = val * 4000;
			string text = Class16.smethod_0(1648942897);
			sValue = string.Concat(sValue, string.Concat(Class16.smethod_0(1648899468) + num.ToString(Class16.smethod_0(1648909972)), text));
		}
		else if (prop == Class16.smethod_0(1649257879))
		{
			bUseLevCo = true;
		}
		else if (prop == Class16.smethod_0(1648909178) && INSTANCE_LIST.Instances != null)
		{
			sValue = INSTANCE_LIST.DecodeIdAndCoords(val, InfoPart.AwardTeleportPos);
			if (sValue == null)
			{
				int num2 = val;
				string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908687));
				string text3 = Class16.smethod_0(1648942211);
				sValue = string.Concat(num2 + text3, text2);
			}
			else if (sValue == Class16.smethod_0(1648924120))
			{
				string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908635));
				sValue = string.Concat(val + Class16.smethod_0(1648942211), text4);
			}
		}
		else if (prop == Class16.smethod_0(1649257889))
		{
			sValue = GetTaskNameHtml(val);
		}
		return AddProperty(caption, sValue, IsSubValue);
	}

	public static string GetTaskNameHtml(int id)
	{
		if (DataFiles.Tasks != null && DataFiles.Tasks.FileLoaded)
		{
			QUEST_INFO questInfo = DataFiles.Tasks.GetQuestInfo(id);
			HTML_HELPER hTML_HELPER = new HTML_HELPER();
			hTML_HELPER.ID = id;
			hTML_HELPER.LinkTaskID = id;
			if (questInfo != null)
			{
				hTML_HELPER.Name = questInfo.name;
				ref Color nameColor = ref hTML_HELPER.NameColor;
				nameColor = questInfo.color;
				hTML_HELPER.icon = questInfo.image;
			}
			else
			{
				hTML_HELPER.Name = Class16.smethod_0(1649071060);
				hTML_HELPER.bNameBold = true;
				Color red = Color.Red;
				hTML_HELPER.NameColor = red;
			}
			return hTML_HELPER.GetItemHtml();
		}
		int num = id;
		return num.ToString();
	}

	public static ItemType GetItemType(ReferenceType section)
	{
		switch (section)
		{
		default:
			return ItemType.All;
		case ReferenceType.TASKS_MATTERS:
			return ItemType.Matter;
		case ReferenceType.TASKS_TITLES:
			return ItemType.PW_TITLE_CONFIG;
		case ReferenceType.TASKS_HOME_ITEMS:
			return ItemType.PW_HOME_ITEM_ENTITY;
		case ReferenceType.TASKS_MONSTERS:
		case ReferenceType.TASKS_NPCS:
		case ReferenceType.TASKS_MINES:
			return ItemType.NpcOrMobOrMine;
		}
	}

	public static List<string> GetPropertiesList()
	{
		string text = null;
		PropertyInfo[] properties = typeof(ATaskTempl).GetProperties();
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>(properties.Length);
		int num = 0;
		if (0 < (nint)properties.LongLength)
		{
			do
			{
				ref PropertyInfo reference = ref properties[num];
				string name = reference.Name;
				if (!name.EndsWith(Class16.smethod_0(1649257907)) && !name.EndsWith(Class16.smethod_0(1649257915)) && !name.EndsWith(Class16.smethod_0(1649257933)) && (!(reference.PropertyType != typeof(bool)) || !(reference.PropertyType != typeof(int))))
				{
					dictionary.Add(name, new List<string>(new string[1] { name }));
				}
				num++;
			}
			while (num < (nint)properties.LongLength);
		}
		int num2 = 0;
		do
		{
			CommonStorage.Texts.Lang.Index = num2;
			TASKS_PROPS.LoadHints();
			Dictionary<string, List<string>>.KeyCollection.Enumerator enumerator = dictionary.Keys.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					string current = enumerator.Current;
					List<string> list = dictionary[current];
					text = null;
					if (!TASKS_PROPS.AwardHintProps.TryGetValue(current, out text))
					{
						text = TASKS_PROPS.MakeTaskPropCaption(current);
					}
					list.Add(text);
				}
				while (enumerator.MoveNext());
			}
			num2++;
		}
		while (num2 <= 2);
		List<string> list2 = new List<string>(dictionary.Count);
		Dictionary<string, List<string>>.ValueCollection.Enumerator enumerator2 = dictionary.Values.GetEnumerator();
		if (enumerator2.MoveNext())
		{
			do
			{
				List<string> current2 = enumerator2.Current;
				list2.Add(string.Join(Class16.smethod_0(1648898262), current2));
			}
			while (enumerator2.MoveNext());
		}
		return list2;
	}
}
