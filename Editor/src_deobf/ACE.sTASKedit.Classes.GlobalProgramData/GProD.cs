using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes.GlobalProgramData;

public class GProD
{
	public static bool Debug = false;

	public static bool ConfigsPCKIsLoaded = false;

	public static bool InterfacesIsLoaded = false;

	public static string ValueFormat;

	public static string ProbValueFormat;

	public static int ElementIconWidth = 19;

	public static int ElementIconHeight = 19;

	public static IniFile ConfigINI;

	public static Image UnknownItemIcon;

	public static ArrayList clientOffsets;

	public static List<int> itemlists;

	public static Dictionary<int, string> LocalizationText;

	public static Dictionary<int, string> InstanceList;

	public static Dictionary<int, string> buff_str;

	public static Dictionary<int, string> item_ext_desc;

	public static Dictionary<int, string> skillstr;

	public static Dictionary<int, string> taskdescriptions;

	public static Dictionary<int, string> world_targets;

	public static Dictionary<int, string> items;

	public static Dictionary<int, string> items_icon_name;

	public static Dictionary<int, string> monsters_npcs_mines;

	public static Dictionary<int, string> forces;

	public static Dictionary<int, string> titles;

	public static Dictionary<int, string> homeitems;

	public static Dictionary<int, string> homeitems_icon_name;

	public static Dictionary<int, string> factiontargets;

	public static Dictionary<int, string> crossservers;

	public static Dictionary<string, int> addonslist;

	public static Dictionary<int, int> transformedformslist;

	public static Dictionary<int, int> gfxtypeslist;

	public static Dictionary<int, int> emotionslist;

	public static ImageList imageList1;

	public static ImageList imageList2;

	public static IconList iconlist_ivtr;

	public static Dictionary<int, Image> ItemsCache;

	[CLSCompliant(false)]
	public static ATaskTempl[] Tasks;

	[CLSCompliant(false)]
	public static eListCollection eLC;

	public static PrivateFontCollection PWUIFont;

	public static int SelectId = 0;

	public static int SelectItemIdWindow_SelectedListIndex = 0;

	public static int SelectItemIdWindow_SelectedItemIndex = 0;

	public static int SelectBuffIdWindow_SelectedItemIndex = 0;

	public static int SelectWorldIdWindow_SelectedItemIndex = 0;

	public static int SelectSkillIdWindow_SelectedItemIndex = 0;

	public static int SelectTaskDescriptionIdWindow_SelectedItemIndex = 0;

	public static int SelectRelayStationIdWindow_SelectedItemIndex = 0;

	public static int SelectTransformedFormIdWindow_SelectedItemIndex = 0;

	public static string GetItemName(int id)
	{
		if (id == 0)
		{
			return TX(402);
		}
		if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements && eLC != null)
		{
			try
			{
				ITEMPOS itemPos = eLC.FindItemPos(eLC.GetLists(ItemType.Matter), id);
				ITEMINFO itemInfo = eLC.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
				object obj;
				if (itemInfo == null)
				{
					obj = null;
				}
				else
				{
					obj = itemInfo.name;
					if (obj != null)
					{
						goto IL_005f;
					}
				}
				obj = TX(404);
				goto IL_005f;
				IL_005f:
				return (string)obj;
			}
			catch
			{
				return TX(404);
			}
		}
		return TX(402);
	}

	[CLSCompliant(false)]
	public static string GetItemProps(int Id, uint Period)
	{
		string empty = string.Empty;
		try
		{
			return empty + GetItemDesc(Id);
		}
		catch
		{
			return string.Empty;
		}
	}

	public static string GetItemDesc(int id)
	{
		string text = ((id == 0) ? TX(402) : ((item_ext_desc == null || !item_ext_desc.ContainsKey(id)) ? string.Empty : item_ext_desc[id]));
		return text.Replace(Class16.smethod_0(1648935632), Environment.NewLine).Replace(Class16.smethod_0(1648903421), Class16.smethod_0(1648904383));
	}

	public static Image GetItemIcon(int ItemId)
	{
		Image image = UnknownItemIcon;
		if (ItemId != 0 && ItemId < 1000000)
		{
			try
			{
				if (ItemsCache == null)
				{
					ItemsCache = new Dictionary<int, Image>();
				}
				if (ItemsCache.TryGetValue(ItemId, out var value) && value != null)
				{
					return value;
				}
				eListCollection eListCollection2 = eLC;
				if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements && eListCollection2 != null && eListCollection2.Icons != null)
				{
					int[] lists = eListCollection2.GetLists(ItemType.Matter);
					if (lists != null)
					{
						ITEMPOS iTEMPOS = eListCollection2.FindItemPos(lists, ItemId);
						if (iTEMPOS != null && iTEMPOS.IsValid())
						{
							int num = 0;
							try
							{
								num = eListCollection2.GetItemsCount(iTEMPOS.int_0);
							}
							catch
							{
								num = 0;
							}
							if (iTEMPOS.int_0 >= 0 && iTEMPOS.int_1 >= 0 && iTEMPOS.int_1 < num)
							{
								ITEMINFO itemInfo = eListCollection2.GetItemInfo(iTEMPOS, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
								if (itemInfo != null)
								{
									Image icon = eListCollection2.Icons.GetIcon(itemInfo.IconName, itemInfo.IsTgaIcon, ElementIconHeight);
									if (icon != null)
									{
										ItemsCache[ItemId] = icon;
										image = icon;
									}
								}
							}
						}
					}
				}
			}
			catch (NullReferenceException)
			{
			}
			catch (Exception ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1649263264));
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(string.Format(Class16.smethod_0(1649263308), ItemId, ex2.Message));
			}
			if (image == UnknownItemIcon && items_icon_name != null && iconlist_ivtr != null && items_icon_name.TryGetValue(ItemId, out var value2) && iconlist_ivtr.Icons.ContainsKey(value2))
			{
				image = iconlist_ivtr.Icons[value2];
			}
		}
		return image;
	}

	public static Image GetItemIcon(string IconName)
	{
		string text = IconName.ToLower().Replace(Class16.smethod_0(1648904229), Class16.smethod_0(1648927580));
		text = text.Substring(text.LastIndexOf(Class16.smethod_0(1648927580)) + 1);
		if (iconlist_ivtr != null && iconlist_ivtr.Icons.ContainsKey(text))
		{
			return iconlist_ivtr.Icons[text];
		}
		return UnknownItemIcon;
	}

	[CLSCompliant(false)]
	public static string GetItemPrice(eListCollection eLC, int ListIndex, int ItemIndex)
	{
		string elParamValue = ACE.sTASKedit.Classes.Extensions.Extensions.GetElParamValue(eLC, ListIndex, ItemIndex, Class16.smethod_0(1648941057));
		string elParamValue2 = ACE.sTASKedit.Classes.Extensions.Extensions.GetElParamValue(eLC, ListIndex, ItemIndex, Class16.smethod_0(1648970148));
		if (elParamValue != null && elParamValue2 != Class16.smethod_0(1648924112) && elParamValue2 != null)
		{
			string text = Convert.ToInt32(elParamValue2).ToString(Class16.smethod_0(1648909972), CultureInfo.CreateSpecificCulture(Class16.smethod_0(1648931984)));
			if (eLC.Version >= 235)
			{
				bool flag = false;
				for (int i = 2; i < 258; i++)
				{
					if (!(eLC.GetValue(311, 0, i) == elParamValue))
					{
						if (eLC.GetValue(311, 0, i) == Class16.smethod_0(1648924112))
						{
							break;
						}
						continue;
					}
					flag = true;
					break;
				}
				text = ((!flag) ? string.Format(TX(7147), text) : string.Format(TX(7146), text));
			}
			else
			{
				text = Class16.smethod_0(1648942211) + text;
			}
			return TX(7024) + text + Class16.smethod_0(1648941987);
		}
		return string.Empty;
	}

	public static string GetMonsterNPCMineName(int id)
	{
		if (id == 0)
		{
			return TX(402);
		}
		if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements && eLC != null)
		{
			try
			{
				ITEMPOS itemPos = eLC.FindItemPos(eLC.GetLists(ItemType.NpcOrMobOrMine), id);
				ITEMINFO itemInfo = eLC.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
				object obj;
				if (itemInfo == null)
				{
					obj = null;
				}
				else
				{
					obj = itemInfo.name;
					if (obj != null)
					{
						goto IL_005f;
					}
				}
				obj = TX(404);
				goto IL_005f;
				IL_005f:
				return (string)obj;
			}
			catch
			{
				return TX(404);
			}
		}
		return TX(402);
	}

	public static string GetMonsterNPCMineText(int Id)
	{
		string text = string.Empty;
		try
		{
			text = GetMonsterNPCMineName(Id) + Class16.smethod_0(1648941987);
			text += GetMonsterNPCMineProps(Id);
		}
		catch
		{
		}
		return text;
	}

	public static string GetMonsterNPCMineProps(int Id)
	{
		string empty = string.Empty;
		int num = 0;
		int num2 = -1;
		bool flag = false;
		try
		{
			for (int i = 0; i < Lists.monster_npc_minelists.Count; i++)
			{
				num = Lists.monster_npc_minelists[i];
				if (eLC.Version >= 191 && num >= 58)
				{
					num--;
				}
				for (int j = 0; j < eLC.Lists[num].elementValues.Length; j++)
				{
					if (Convert.ToInt32(eLC.GetValue(num, j, 0)) == Id)
					{
						num2 = j;
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (num2 > -1 && eLC.Version >= 191 && num >= 58)
			{
				num++;
			}
		}
		catch
		{
			empty = string.Empty;
		}
		return empty;
	}

	public static string GetForceName(int id)
	{
		switch (id)
		{
		case -1:
			return TX(2531);
		case 0:
			return TX(402);
		default:
			if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements && eLC != null)
			{
				try
				{
					ITEMPOS itemPos = eLC.FindItemPos(eLC.GetLists(ItemType.PW_FORCE_CONFIG), id);
					ITEMINFO itemInfo = eLC.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
					object obj;
					if (itemInfo == null)
					{
						obj = null;
					}
					else
					{
						obj = itemInfo.name;
						if (obj != null)
						{
							goto IL_0073;
						}
					}
					obj = TX(404);
					goto IL_0073;
					IL_0073:
					return (string)obj;
				}
				catch
				{
					return TX(404);
				}
			}
			return TX(402);
		}
	}

	public static string GetTitleName(int id)
	{
		if (id == 0)
		{
			return TX(402);
		}
		if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements && eLC != null)
		{
			try
			{
				ITEMPOS itemPos = eLC.FindItemPos(eLC.GetLists(ItemType.PW_TITLE_CONFIG), id);
				ITEMINFO itemInfo = eLC.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
				object obj;
				if (itemInfo == null)
				{
					obj = null;
				}
				else
				{
					obj = itemInfo.name;
					if (obj != null)
					{
						goto IL_0063;
					}
				}
				obj = TX(404);
				goto IL_0063;
				IL_0063:
				return (string)obj;
			}
			catch
			{
				return TX(404);
			}
		}
		return TX(402);
	}

	public static string GetTitleText(int Id)
	{
		string text = string.Empty;
		try
		{
			text = GetTitleName(Id) + Class16.smethod_0(1648941987);
			text += GetTitleProps(Id);
		}
		catch
		{
		}
		return text;
	}

	public static string GetTitleProps(int Id)
	{
		string empty = string.Empty;
		int num = 0;
		try
		{
			num = 169;
			if (eLC.Version >= 191 && num >= 58)
			{
				num--;
			}
		}
		catch
		{
			empty = string.Empty;
		}
		return empty;
	}

	public static string GetCrossServerName(int id)
	{
		if (id == 0)
		{
			return TX(402);
		}
		if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements && eLC != null)
		{
			try
			{
				ITEMPOS itemPos = eLC.FindItemPos(eLC.GetLists(ItemType.PW_NPC_CROSS_SERVER_SERVICE), id);
				ITEMINFO itemInfo = eLC.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
				object obj;
				if (itemInfo == null)
				{
					obj = null;
				}
				else
				{
					obj = itemInfo.name;
					if (obj != null)
					{
						goto IL_0063;
					}
				}
				obj = TX(404);
				goto IL_0063;
				IL_0063:
				return (string)obj;
			}
			catch
			{
				return TX(404);
			}
		}
		return TX(402);
	}

	public static string GetHomeItemName(int id)
	{
		if (id == 0)
		{
			return TX(402);
		}
		if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements && eLC != null)
		{
			try
			{
				ITEMPOS itemPos = eLC.FindItemPos(eLC.GetLists(ItemType.PW_HOME_ITEM_ENTITY), id);
				ITEMINFO itemInfo = eLC.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
				object obj;
				if (itemInfo == null)
				{
					obj = null;
				}
				else
				{
					obj = itemInfo.name;
					if (obj != null)
					{
						goto IL_0063;
					}
				}
				obj = TX(404);
				goto IL_0063;
				IL_0063:
				return (string)obj;
			}
			catch
			{
				return TX(404);
			}
		}
		return TX(402);
	}

	public static string GetHomeItemText(int Id)
	{
		string text = string.Empty;
		try
		{
			text = GetHomeItemName(Id) + Class16.smethod_0(1648941987);
			text += GetHomeItemProps(Id);
		}
		catch
		{
		}
		return text;
	}

	public static string GetHomeItemProps(int Id)
	{
		string empty = string.Empty;
		int num = 0;
		try
		{
			num = 223;
			if (eLC.Version >= 191 && num >= 58)
			{
				num--;
			}
		}
		catch
		{
			empty = string.Empty;
		}
		return empty;
	}

	public static Image GetHomeItemIcon(int HomeItemId)
	{
		Image image = UnknownItemIcon;
		if (HomeItemId != 0)
		{
			try
			{
				if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements && eLC != null && eLC.Icons != null)
				{
					ITEMPOS itemPos = eLC.FindItemPos(eLC.GetLists(ItemType.PW_HOME_ITEM_ENTITY), HomeItemId);
					ITEMINFO itemInfo = eLC.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
					if (itemInfo != null)
					{
						Image icon = eLC.Icons.GetIcon(itemInfo.IconName, itemInfo.IsTgaIcon, ElementIconHeight);
						if (icon != null)
						{
							image = icon;
						}
					}
				}
			}
			catch
			{
			}
			if (image == UnknownItemIcon && homeitems_icon_name != null && iconlist_ivtr != null && homeitems_icon_name.TryGetValue(HomeItemId, out var value) && iconlist_ivtr.Icons.ContainsKey(value))
			{
				image = iconlist_ivtr.Icons[value];
			}
		}
		return image;
	}

	public static string GetFactionTargetName(int id)
	{
		if (id == 0)
		{
			return TX(402);
		}
		if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements && eLC != null)
		{
			try
			{
				ITEMPOS itemPos = eLC.FindItemPos(eLC.GetLists(ItemType.PW_FACTION_TARGET_CONFIG), id);
				ITEMINFO itemInfo = eLC.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
				object obj;
				if (itemInfo == null)
				{
					obj = null;
				}
				else
				{
					obj = itemInfo.name;
					if (obj != null)
					{
						goto IL_0063;
					}
				}
				obj = TX(404);
				goto IL_0063;
				IL_0063:
				return (string)obj;
			}
			catch
			{
				return TX(404);
			}
		}
		return TX(402);
	}

	public static string GetInstanceName(int id, int string_count = 0)
	{
		string text = ((InstanceList == null || !InstanceList.ContainsKey(id)) ? TX(404) : InstanceList[id]);
		if (string_count > 0)
		{
			string[] array = Regex.Split(text, Class16.smethod_0(1648924428));
			text = array[0].TrimEnd(' ');
			if (array.Length > string_count)
			{
				text += Class16.smethod_0(1649263127);
			}
		}
		return text.Replace(Class16.smethod_0(1648903412), Environment.NewLine).Replace(Class16.smethod_0(1648903421), Class16.smethod_0(1648904383));
	}

	public static string GetBuffDesc(int id, int string_count = 0)
	{
		string text = ((id == 0) ? TX(402) : ((buff_str == null || !buff_str.ContainsKey(id)) ? TX(404) : buff_str[id]));
		if (string_count > 0)
		{
			string[] array = Regex.Split(text, Class16.smethod_0(1648924428));
			text = array[0];
			if (array.Length > string_count)
			{
				text += Class16.smethod_0(1649263127);
			}
		}
		return text.Replace(Class16.smethod_0(1648935632), Environment.NewLine).Replace(Class16.smethod_0(1648903412), Environment.NewLine).Replace(Class16.smethod_0(1648903421), Class16.smethod_0(1648904383));
	}

	public static string GetSkillName(int id)
	{
		int key = id * 10;
		string text = ((skillstr == null || !skillstr.ContainsKey(key)) ? TX(404) : skillstr[key]);
		return text.Replace(Class16.smethod_0(1648903412), Environment.NewLine).Replace(Class16.smethod_0(1648903421), Class16.smethod_0(1648904383));
	}

	public static string GetSkillDesc(int id)
	{
		int key = id * 10 + 1;
		string text = ((skillstr == null || !skillstr.ContainsKey(key)) ? TX(404) : skillstr[key]);
		return text.Replace(Class16.smethod_0(1648908173), Class16.smethod_0(1648923229)).Replace(Class16.smethod_0(1648903412), Environment.NewLine).Replace(Class16.smethod_0(1648903421), Class16.smethod_0(1648904383));
	}

	public static string GetSkillText(int id)
	{
		if (id != 0)
		{
			try
			{
				string skillName = GetSkillName(id);
				string skillDesc = GetSkillDesc(id);
				if (skillName != TX(404) && skillDesc != TX(404))
				{
					if (skillName != string.Empty)
					{
						if (skillDesc != string.Empty)
						{
							return skillName + Class16.smethod_0(1648908367) + GlobalFunctions.ColorClean(skillDesc);
						}
						return skillName;
					}
					return GlobalFunctions.ColorClean(skillDesc);
				}
				return TX(404);
			}
			catch
			{
				return TX(404);
			}
		}
		return TX(402);
	}

	public static string GetTaskDescriptionDesc(int id)
	{
		string text = ((id == 0) ? TX(402) : ((taskdescriptions == null || !taskdescriptions.ContainsKey(id)) ? TX(404) : taskdescriptions[id]));
		return text.Replace(Class16.smethod_0(1648935632), Environment.NewLine).Replace(Class16.smethod_0(1648903412), Environment.NewLine).Replace(Class16.smethod_0(1648903421), Class16.smethod_0(1648904383));
	}

	public static string GetRelayStationName(int id)
	{
		string empty = string.Empty;
		empty = ((id == 0) ? TX(402) : ((world_targets == null || !world_targets.ContainsKey(id)) ? TX(404) : world_targets[id]));
		return empty.Replace(Class16.smethod_0(1648903412), Environment.NewLine).Replace(Class16.smethod_0(1648903421), Class16.smethod_0(1648904383));
	}

	public static string GetTransformedFormName(int id)
	{
		string text = ((id == 0) ? TX(402) : ((transformedformslist == null || !transformedformslist.ContainsKey(id)) ? TX(404) : TX(transformedformslist[id])));
		return text.Replace(Class16.smethod_0(1648903412), Environment.NewLine).Replace(Class16.smethod_0(1648903421), Class16.smethod_0(1648904383));
	}

	public static string GetGfxTypeName(int id)
	{
		string text = ((gfxtypeslist == null || !gfxtypeslist.ContainsKey(id)) ? (TX(404) + Class16.smethod_0(1648899468) + id + Class16.smethod_0(1648942897)) : TX(gfxtypeslist[id]));
		return text.Replace(Class16.smethod_0(1648903412), Environment.NewLine).Replace(Class16.smethod_0(1648903421), Class16.smethod_0(1648904383));
	}

	public static string GetEmotionName(int id)
	{
		string text = ((emotionslist == null || !emotionslist.ContainsKey(id)) ? (TX(404) + Class16.smethod_0(1648899468) + id + Class16.smethod_0(1648942897)) : TX(emotionslist[id]));
		return text.Replace(Class16.smethod_0(1648903412), Environment.NewLine).Replace(Class16.smethod_0(1648903421), Class16.smethod_0(1648904383));
	}

	public static string TX(int key, bool appendsymbols = false)
	{
		string text;
		if (LocalizationText != null && LocalizationText.ContainsKey(key))
		{
			text = LocalizationText[key];
			if (appendsymbols)
			{
				text += Class16.smethod_0(1648924402);
			}
		}
		else
		{
			text = Class16.smethod_0(1649263345) + key;
			if (Debug)
			{
				ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(Class16.smethod_0(1649263374) + Settings.Fields.Language + Class16.smethod_0(1649263398) + key);
			}
		}
		return text.Replace(Class16.smethod_0(1648903412), Environment.NewLine).Replace(Class16.smethod_0(1648903421), Class16.smethod_0(1648904383));
	}

	public static int GetElementListIndex(int ListIndex)
	{
		if (eLC.Version >= 191 && ListIndex >= 58)
		{
			return ListIndex - 1;
		}
		return ListIndex;
	}
}
