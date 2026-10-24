using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using ACE.RSGlobal;

namespace ACE.Classes;

public class HTML_HELPER
{
	public static int HotKeyIndex;

	public static bool bEchoHotkey;

	public bool bViewListIndex;

	public bool bViewListName;

	public bool bListInTheEnd;

	public bool bListBold;

	public bool FirstListIndexIs1;

	public string ListName;

	public bool bMargin;

	public bool bViewID = true;

	public bool IdAfterName;

	public int ID;

	public bool bNameBold;

	public bool bNameUnderline;

	public string Name;

	public string extra1;

	public string extra2;

	public Color NameColor = Color.White;

	public Color IDColor = Color.Silver;

	public object NameBorderColor;

	public bool bBorderItemName;

	public bool bIconNecessarily;

	public bool bViewIcon = true;

	public Image icon;

	public int icon_size = 16;

	public bool bViewReferences = true;

	public int LinkTaskID;

	public int ListIndex = -1;

	public ITEMPOS LinkItem;

	public FIELDPOS LinkField;

	public ITEMINFO ItemInfo;

	public bool bDisableLinks;

	public bool bHtmlEncode = true;

	public HTML_HELPER(ITEMPOS ItemPos)
	{
		LinkItem = ItemPos;
		ListIndex = ItemPos.int_0;
	}

	public HTML_HELPER()
	{
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool LinkExists()
	{
		int num = ((LinkItem != null || LinkField != null || LinkTaskID > 0) ? 1 : 0);
		return (byte)num != 0;
	}

	public void HotKeysStart()
	{
		HotKeyIndex = 0;
		bEchoHotkey = true;
	}

	public void HotKeysEnd()
	{
		HotKeyIndex = 0;
		bEchoHotkey = false;
	}

	public string GetItemHtml()
	{
		StringBuilder stringBuilder = new StringBuilder(2048);
		bool flag = !string.IsNullOrEmpty(Name);
		if (bMargin)
		{
			stringBuilder.Append(Class16.smethod_0(1648902317));
		}
		if (bViewListIndex && ListIndex > -1)
		{
			int num = (FirstListIndexIs1 ? 1 : 0);
			Color yellow = Color.Yellow;
			string text = (ListIndex + num).ToString(Class16.smethod_0(1648902328));
			string text2 = Class16.smethod_0(1648902337);
			object text3 = string.Concat(Class16.smethod_0(1648924364) + text, text2);
			string text4 = EchoTextColored(yellow, bBold: true, bUderline: false, text3);
			stringBuilder.Append(TryEchoLink(text4));
			stringBuilder.Append('\t');
		}
		if (bViewListName && !bListInTheEnd && !string.IsNullOrEmpty(ListName))
		{
			string text5 = EchoTextColored(Color.Yellow, text: ListName, bBold: bListBold, bUderline: false);
			stringBuilder.Append(TryEchoLink(text5));
			if (ItemInfo != null)
			{
				stringBuilder.Append(Class16.smethod_0(1648902346));
			}
		}
		ITEMINFO itemInfo = ItemInfo;
		if (itemInfo != null && itemInfo.bOcupiedID)
		{
			Color red = Color.Red;
			IDColor = red;
		}
		if (bViewID && !IdAfterName)
		{
			string text6 = Class16.smethod_0(1648902355);
			stringBuilder.Append(string.Concat(Class16.smethod_0(1648902388) + TryEchoLink(EchoTextColored(IDColor, ID)), text6));
		}
		string text7 = string.Empty;
		ITEMINFO itemInfo2 = ItemInfo;
		int num2 = ((itemInfo2 != null && itemInfo2.bCustomItem) ? 1 : 0);
		bool flag2 = (byte)num2 != 0;
		if (bViewIcon)
		{
			Image image = icon;
			if (image != null)
			{
				string text8 = Class16.smethod_0(1648902465);
				text7 = string.Concat(text7, string.Concat(Class16.smethod_0(1648902555) + global::ACE.RSGlobal.RSGlobal.ImageToBase64(image), text8));
				if (flag2 && flag && global::ACE.RSGlobal.RSGlobal.IsSpecialLongChar(Name.Substring(0, 1)))
				{
					text7 += Class16.smethod_0(1648902317);
				}
			}
		}
		string text9 = null;
		if (!string.IsNullOrEmpty(Name))
		{
			float float_ = 0f;
			if (Name.Contains(Class16.smethod_0(1648923229)) && NumberConverter.TryParsePercent(Name, ref float_))
			{
				text9 = Name;
			}
			if (bHtmlEncode)
			{
				Name = HttpUtility.HtmlEncode(Name);
			}
			text7 += EchoTextColored(bBold: (bNameBold || flag2) ? true : false, color: NameColor, bUderline: bNameUnderline, text: Name, NameBorderColor: NameBorderColor);
		}
		if (!string.IsNullOrEmpty(text7))
		{
			stringBuilder.Append(TryEchoLink(text7));
		}
		if (bViewID && IdAfterName)
		{
			if (!flag || !Name.EndsWith(Class16.smethod_0(1648902603)))
			{
				stringBuilder.Append(Class16.smethod_0(1648902317));
			}
			int iD = ID;
			stringBuilder.Append(TryEchoLink(EchoTextColored(IDColor, Class16.smethod_0(1648902620) + iD)));
		}
		ITEMINFO itemInfo3 = ItemInfo;
		if (itemInfo3 != null && bViewReferences && LinkItem != null && LinkItem.IsValid())
		{
			Color color = ((!itemInfo3.bHasReferences) ? Color.Gray : Color.Cyan);
			int refCount = ItemInfo.RefCount;
			ITEMPOS linkItem = LinkItem;
			stringBuilder.Append(Class16.smethod_0(1648942211) + EchoReferencesLink(Class16.smethod_0(1648902631) + refCount, linkItem, color));
		}
		string text10 = extra1;
		if (text10 != null)
		{
			if (text9 == null)
			{
				if (text10.Contains(Class16.smethod_0(1648923229)))
				{
					text9 = extra1;
				}
				else
				{
					string text11 = extra2;
					if (text11 != null && text11.Contains(Class16.smethod_0(1648923229)))
					{
						text9 = extra2;
					}
				}
			}
			if (bHtmlEncode)
			{
				extra1 = HttpUtility.HtmlEncode(extra1);
				string text12 = extra2;
				if (text12 != null)
				{
					extra2 = HttpUtility.HtmlEncode(text12);
				}
			}
			Color gray = Color.Gray;
			string text13 = extra2;
			string text14 = Class16.smethod_0(1648942211);
			stringBuilder.Append(EchoTextColored(gray, string.Concat(string.Concat(text14 + extra1, text14), text13)));
		}
		float float_2 = 0f;
		if (text9 != null && NumberConverter.TryParsePercent(text9, ref float_2) && float_2 > 0f)
		{
			Image image2 = global::ACE.RSGlobal.RSGlobal.DrawProgress(float_2, 110, 11);
			string value = Class16.smethod_0(1648942211) + Image2Html(image2);
			stringBuilder.Append(value);
		}
		if (LinkItem != null && bEchoHotkey)
		{
			HotKeyIndex++;
		}
		if (bViewListName && bListInTheEnd && !string.IsNullOrEmpty(ListName))
		{
			Color yellow2 = Color.Yellow;
			object text15 = Class16.smethod_0(1648902650) + ListName;
			string text16 = EchoTextColored(yellow2, bBold: false, bUderline: false, text15);
			stringBuilder.Append(TryEchoLink(text16));
		}
		string result = stringBuilder.ToString();
		GC.KeepAlive(this);
		return result;
	}

	public static string Image2Html(string imageBase64, int width, int height)
	{
		return string.Format(Class16.smethod_0(1648905747), width, height, imageBase64);
	}

	public static string Image2Html(Image image)
	{
		int height = image.Height;
		int width = image.Width;
		string arg = global::ACE.RSGlobal.RSGlobal.ImageToBase64(image);
		return string.Format(Class16.smethod_0(1648905747), width, height, arg);
	}

	public static string EchoReferencesLink(string text, ITEMPOS ItemPos, Color color)
	{
		string arg = EchoTextColored(color, bBold: true, bUderline: false, text);
		return string.Format(Class16.smethod_0(1648905833), ItemPos.int_0, ItemPos.int_1, arg);
	}

	public static string EchoListLink(string text, int ListIndex, Color color)
	{
		string arg = EchoTextColored(color, bBold: false, bUderline: false, text);
		return string.Format(Class16.smethod_0(1648905895), ListIndex, arg);
	}

	public string TryEchoLink(string text)
	{
		if (bDisableLinks)
		{
			return text;
		}
		FIELDPOS linkField = LinkField;
		string result;
		if (linkField != null)
		{
			result = string.Format(Class16.smethod_0(1648905937), linkField.int_0, LinkField.int_1, LinkField.int_2, text);
		}
		else
		{
			ITEMPOS linkItem = LinkItem;
			if (linkItem != null)
			{
				result = string.Format(Class16.smethod_0(1648905993), linkItem.int_0, linkItem.int_1, text);
			}
			else
			{
				int linkTaskID = LinkTaskID;
				if (linkTaskID > 0)
				{
					result = string.Format(Class16.smethod_0(1648906052), linkTaskID, text);
				}
				else
				{
					int listIndex = ListIndex;
					result = ((listIndex <= -1) ? text : string.Format(Class16.smethod_0(1648906090), listIndex, text));
				}
			}
		}
		GC.KeepAlive(this);
		return result;
	}

	public static string EchoTextColored(Color color, [MarshalAs(UnmanagedType.U1)] bool bBold, [MarshalAs(UnmanagedType.U1)] bool bUderline, object text, object NameBorderColor)
	{
		if (NameBorderColor != null)
		{
			string newValue = global::ACE.RSGlobal.RSGlobal.Color2HTML((Color)NameBorderColor);
			string text2 = Class16.smethod_0(1648906139).Replace(Class16.smethod_0(1648906231), newValue);
			object[] array = new object[5]
			{
				global::ACE.RSGlobal.RSGlobal.Color2HTML(color),
				null,
				null,
				null,
				null
			};
			string text3 = ((!bBold) ? Class16.smethod_0(1648905218) : Class16.smethod_0(1648906239));
			array[1] = text3;
			string text4 = ((!bUderline) ? Class16.smethod_0(1648905255) : Class16.smethod_0(1648905239));
			array[2] = text4;
			array[3] = text2;
			array[4] = text;
			return string.Format(Class16.smethod_0(1648905269), array);
		}
		return EchoTextColored(color, bBold, bUderline, text);
	}

	public static string EchoTextColored(Color color, [MarshalAs(UnmanagedType.U1)] bool bBold, [MarshalAs(UnmanagedType.U1)] bool bUderline, object text)
	{
		object[] array = new object[4]
		{
			global::ACE.RSGlobal.RSGlobal.Color2HTML(color),
			null,
			null,
			null
		};
		string text2 = ((!bBold) ? Class16.smethod_0(1648905218) : Class16.smethod_0(1648906239));
		array[1] = text2;
		string text3 = ((!bUderline) ? Class16.smethod_0(1648905255) : Class16.smethod_0(1648905239));
		array[2] = text3;
		array[3] = text;
		return string.Format(Class16.smethod_0(1648905347), array);
	}

	public static string EchoTextColored(Color color, [MarshalAs(UnmanagedType.U1)] bool bBold, object text)
	{
		return EchoTextColored(color, bBold, bUderline: false, text);
	}

	public static string EchoTextColored(Color color, Color BackgroundColor, object text)
	{
		return string.Format(Class16.smethod_0(1648905438), global::ACE.RSGlobal.RSGlobal.Color2HTML(color), global::ACE.RSGlobal.RSGlobal.Color2HTML(BackgroundColor), text);
	}

	public static string EchoTextColored(Color color, object text)
	{
		string text2 = Class16.smethod_0(1648902161);
		string text3 = Class16.smethod_0(1648905490);
		object obj;
		if (text == null)
		{
			obj = null;
		}
		else
		{
			obj = text.ToString();
			if (obj != null)
			{
				goto IL_002b;
			}
		}
		obj = string.Empty;
		goto IL_002b;
		IL_002b:
		string text4 = (string)obj;
		return string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648905508) + global::ACE.RSGlobal.RSGlobal.Color2HTML(color), text3), text4), text2);
	}

	public static string HighlightText(string string_0, string[] highlights)
	{
		string text = Class16.smethod_0(1648942897);
		Regex regex = new Regex(string.Concat(Class16.smethod_0(1648942889) + string.Join(Class16.smethod_0(1648905535), highlights), text), RegexOptions.IgnoreCase);
		Color lightGreen = Color.LightGreen;
		return regex.Replace(string_0, EchoTextColored(lightGreen, bBold: true, bUderline: true, Class16.smethod_0(1648905543)));
	}

	public static string HighlightText(string string_0, string highlight)
	{
		if (!string.IsNullOrWhiteSpace(string_0) && !string.IsNullOrWhiteSpace(highlight))
		{
			return HighlightText(string_0, new string[1] { Regex.Escape(highlight) });
		}
		return string_0;
	}

	public static void HighlightText_Escape(ref string[] highlights)
	{
		string[] array = highlights;
		int num = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				ref string reference = ref array[num];
				reference = Regex.Escape(reference);
				num++;
			}
			while (num < (nint)array.LongLength);
		}
	}
}
