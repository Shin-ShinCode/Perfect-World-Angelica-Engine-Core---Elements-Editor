using System;
using System.Collections.Generic;
using ACE.RSGlobal;

namespace ACE.GShop;

public class SHOP_CATEGORY_FW
{
	public string Name;

	public List<int> Items;

	public List<SHOP_CATEGORY_FW> SubCategories;

	public bool IsItems;

	public string VariableName;

	public SHOP_CATEGORY_FW(string sCategory)
	{
		IsItems = false;
		SubCategories = new List<SHOP_CATEGORY_FW>();
		Items = new List<int>();
		int num = 0;
		if (0 < sCategory.Length - 9)
		{
			do
			{
				string text = Class16.smethod_0(1649054045);
				if (sCategory.Substring(num, 8) == text)
				{
					num += 8;
					Name = method_1(sCategory.Substring(num, sCategory.IndexOf(Class16.smethod_0(1648928028), num) - num));
					num = sCategory.IndexOf(Class16.smethod_0(1648928028), num) + 1;
				}
				else
				{
					string text2 = Class16.smethod_0(1648905100);
					if (sCategory.Substring(num, 4) == text2)
					{
						Name = method_1(sCategory.Substring(num, sCategory.IndexOf(Class16.smethod_0(1648928028), num) - num));
						num = sCategory.IndexOf(Class16.smethod_0(1648928028), num) + 1;
						IsItems = true;
					}
				}
				string text3 = Class16.smethod_0(1648978656);
				if (sCategory.Substring(num, 5) == text3)
				{
					int num2 = sCategory.IndexOf(Class16.smethod_0(1648908124), num) + 1;
					int num3 = sCategory.IndexOf(Class16.smethod_0(1648908132), num2);
					string string_ = sCategory.Substring(num2, num3 - num2);
					method_0(string_);
					num = num3;
				}
				string text4 = Class16.smethod_0(1648924364);
				if (sCategory.Substring(num, 1) == text4)
				{
					int num4 = sCategory.IndexOf(Class16.smethod_0(1648908124), num) + 1;
					int num5 = ACE.RSGlobal.RSGlobal.FindCloseSymbolIndex(sCategory, Class16.smethod_0(1648908124), Class16.smethod_0(1648908132), num4);
					string sCategory2 = sCategory.Substring(num4, num5 - num4);
					SubCategories.Add(new SHOP_CATEGORY_FW(sCategory2));
					num = num5;
				}
				num++;
			}
			while (num < sCategory.Length - 9);
		}
		GC.KeepAlive(this);
	}

	public SHOP_CATEGORY_FW()
	{
		SubCategories = new List<SHOP_CATEGORY_FW>();
		IsItems = false;
		Items = new List<int>();
	}

	public static SHOP_CATEGORY_FW Create(string Name)
	{
		SHOP_CATEGORY_FW sHOP_CATEGORY_FW = new SHOP_CATEGORY_FW();
		sHOP_CATEGORY_FW.Name = Name;
		sHOP_CATEGORY_FW.IsItems = true;
		return sHOP_CATEGORY_FW;
	}

	public void AddCategory(string Name)
	{
		SubCategories.Add(Create(Name));
		if (IsItems)
		{
			ref List<int> items = ref SubCategories[0].Items;
			items = Items;
			SubCategories[0].IsItems = true;
			IsItems = false;
			Items = new List<int>();
		}
	}

	public void DeleteCategory(int cat_index)
	{
		if (cat_index >= 0 && SubCategories.Count != 0)
		{
			SubCategories.RemoveAt(cat_index);
			if (SubCategories.Count == 0)
			{
				IsItems = true;
				Items = new List<int>();
			}
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	public void AddItem(int id, int pos)
	{
		if (Items == null)
		{
			Items = new List<int>();
		}
		Items.Add(id);
		ChangeItemPos(Items.Count - 1, pos);
		GC.KeepAlive(this);
	}

	public void AddItem(int id)
	{
		if (Items == null)
		{
			Items = new List<int>();
		}
		Items.Add(id);
		GC.KeepAlive(this);
	}

	public void DeleteItem(int index)
	{
		Items.RemoveAt(index);
		GC.KeepAlive(this);
	}

	public void ChangeItemPos(int current_pos, int new_pos)
	{
		if (current_pos != new_pos)
		{
			int value = Items[current_pos];
			int value2 = Items[new_pos];
			Items[new_pos] = value;
			Items[current_pos] = value2;
			GC.KeepAlive(this);
		}
	}

	public string[] GetSubCategories()
	{
		string[] array = new string[SubCategories.Count];
		int num = 0;
		if (0 < SubCategories.Count)
		{
			do
			{
				string name = SubCategories[num].Name;
				array[num] = name;
				num++;
			}
			while (num < SubCategories.Count);
		}
		GC.KeepAlive(this);
		return array;
	}

	public string GetLua(int tabs_count)
	{
		string empty = string.Empty;
		string text = empty;
		if (!IsItems)
		{
			string text2 = Class16.smethod_0(1648904383);
			string text3 = empty;
			if (0 < tabs_count)
			{
				int num = tabs_count;
				do
				{
					text3 += text2;
					num--;
				}
				while (num != 0);
			}
			string text4 = Class16.smethod_0(1648924428);
			string text5 = Class16.smethod_0(1649054060);
			string name = Name;
			text = string.Concat(text, string.Concat(string.Concat(string.Concat(text3 + Class16.smethod_0(1649054069), name), text5), text4));
			int num2 = 0;
			if (0 < SubCategories.Count)
			{
				int tabs_count2 = tabs_count + 1;
				do
				{
					string text6 = Class16.smethod_0(1648904383);
					string text7 = string.Empty;
					if (0 < tabs_count)
					{
						int num3 = tabs_count;
						do
						{
							text7 += text6;
							num3--;
						}
						while (num3 != 0);
					}
					string text8 = Class16.smethod_0(1648924428);
					string text9 = Class16.smethod_0(1649054080);
					text = string.Concat(text, string.Concat(string.Concat(string.Concat(text7 + Class16.smethod_0(1648924364), num2 + 1), text9), text8));
					text += SubCategories[num2].GetLua(tabs_count2);
					string text10 = Class16.smethod_0(1648904383);
					string text11 = string.Empty;
					if (0 < tabs_count)
					{
						int num4 = tabs_count;
						do
						{
							text11 += text10;
							num4--;
						}
						while (num4 != 0);
					}
					text = string.Concat(text, text11 + Class16.smethod_0(1648908132));
					if (num2 + 1 < SubCategories.Count)
					{
						text += Class16.smethod_0(1648928028);
					}
					text += Class16.smethod_0(1648924428);
					num2++;
				}
				while (num2 < SubCategories.Count);
			}
		}
		else
		{
			string text12 = Class16.smethod_0(1648904383);
			string text13 = empty;
			if (0 < tabs_count)
			{
				int num5 = tabs_count;
				do
				{
					text13 += text12;
					num5--;
				}
				while (num5 != 0);
			}
			string text14 = Class16.smethod_0(1648924428);
			string text15 = Class16.smethod_0(1649054060);
			string name2 = Name;
			text = string.Concat(text, string.Concat(string.Concat(string.Concat(text13 + Class16.smethod_0(1649054100), name2), text15), text14));
			string text16 = Class16.smethod_0(1648904383);
			string text17 = string.Empty;
			if (0 < tabs_count)
			{
				int num6 = tabs_count;
				do
				{
					text17 += text16;
					num6--;
				}
				while (num6 != 0);
			}
			string text18 = Class16.smethod_0(1648924428);
			text = string.Concat(text, string.Concat(text17 + Class16.smethod_0(1649054107), text18));
			tabs_count++;
			int num7 = 0;
			if (0 < Items.Count)
			{
				do
				{
					string text19 = Items[num7].ToString();
					if (text19 == Class16.smethod_0(1648919381))
					{
						text19 = VariableName;
					}
					if (num7 + 1 < Items.Count)
					{
						string text20 = Class16.smethod_0(1648904383);
						string text21 = string.Empty;
						if (0 < tabs_count)
						{
							int num8 = tabs_count;
							do
							{
								text21 += text20;
								num8--;
							}
							while (num8 != 0);
						}
						string text22 = Class16.smethod_0(1648924428);
						string text23 = Class16.smethod_0(1648928028);
						text = string.Concat(text, string.Concat(string.Concat(text21 + text19, text23), text22));
					}
					else
					{
						string text24 = Class16.smethod_0(1648904383);
						string text25 = string.Empty;
						if (0 < tabs_count)
						{
							int num9 = tabs_count;
							do
							{
								text25 += text24;
								num9--;
							}
							while (num9 != 0);
						}
						string text26 = Class16.smethod_0(1648924428);
						text = string.Concat(text, string.Concat(text25 + text19, text26));
					}
					num7++;
				}
				while (num7 < Items.Count);
			}
			tabs_count--;
			string text27 = Class16.smethod_0(1648904383);
			string text28 = string.Empty;
			if (0 < tabs_count)
			{
				int num10 = tabs_count;
				do
				{
					text28 += text27;
					num10--;
				}
				while (num10 != 0);
			}
			string text29 = Class16.smethod_0(1648924428);
			text = string.Concat(text, string.Concat(text28 + Class16.smethod_0(1648908132), text29));
		}
		GC.KeepAlive(this);
		return text;
	}

	private void method_0(string string_0)
	{
		string_0 = string_0.Replace(Class16.smethod_0(1648942211), string.Empty);
		string_0 = string_0.Replace(Class16.smethod_0(1648904383), string.Empty);
		string_0 = string_0.Replace(Class16.smethod_0(1648904221), string.Empty);
		string_0 = string_0.Replace(Class16.smethod_0(1648941987), string.Empty);
		if (string_0.Length > 0)
		{
			string[] array = string_0.Split(',');
			Items = new List<int>(array.Length);
			int num = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					if (ACE.RSGlobal.RSGlobal.IsUIntFast(array[num]))
					{
						Items.Add(Convert.ToInt32(array[num]));
					}
					else
					{
						VariableName = array[num];
						Items.Add(-1);
					}
					num++;
				}
				while (num < (nint)array.LongLength);
			}
		}
		GC.KeepAlive(this);
	}

	private string method_1(string string_0)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (0 < string_0.Length)
		{
			do
			{
				if (num > 0)
				{
					string text = Class16.smethod_0(1648904453);
					if (string_0.Substring(num3, 1) == text)
					{
						num2 = num3;
						break;
					}
				}
				else
				{
					string text2 = Class16.smethod_0(1648904453);
					if (string_0.Substring(num3, 1) == text2)
					{
						num = num3 + 1;
					}
				}
				num3++;
			}
			while (num3 < string_0.Length);
		}
		string input = string_0.Substring(num, num2 - num);
		input = RSCommon.DecodeLuaString(input);
		GC.KeepAlive(this);
		return input;
	}
}
