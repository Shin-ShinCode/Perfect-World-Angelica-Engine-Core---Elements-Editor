#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ACE.RSGlobal;

public class RSCommon
{
	private static class Class359
	{
		public static MatchEvaluator matchEvaluator_0;
	}

	public static string ConvertLuaStrings(string fn)
	{
		string text = Regex.Replace(File.ReadAllText(fn), Class16.smethod_0(1649166781), ItemFieldIndexFunc);
		RSGlobal.OpenInNotepad(text);
		return text;
	}

	public static string ItemFieldIndexFunc(Match match_0)
	{
		return DecodeLuaString(match_0.Captures[0].Value);
	}

	public static string DecodeLuaString(string input)
	{
		if (!string.IsNullOrWhiteSpace(input) && input.Contains(Class16.smethod_0(1648927580)))
		{
			StringBuilder stringBuilder = new StringBuilder(input.Length);
			List<byte> list = new List<byte>();
			int num = 0;
			if (0 < input.Length)
			{
				do
				{
					if (input[num] != '\\' || num >= input.Length - 4)
					{
						if (list.Count > 0)
						{
							stringBuilder.Append(Encoding.UTF8.GetString(list.ToArray()));
							list.Clear();
						}
						stringBuilder.Append(input[num]);
					}
					else
					{
						int num2 = 0;
						int num3 = num + 1;
						if (num3 < num + 4)
						{
							do
							{
								char c = input[num3];
								if (((uint)c < 48u || (uint)c > 57u) && num2 != 0)
								{
									break;
								}
								num2++;
								num3++;
							}
							while (num3 < num + 4);
							if (num2 > 0)
							{
								if (num2 == 1)
								{
									char c2 = input[num + 1];
									stringBuilder.Append('\\');
									stringBuilder.Append(c2);
									if (c2 != 'r' && c2 != 'n' && c2 != '"' && c2 != '\\')
									{
										Debug.WriteLine(Class16.smethod_0(1649166786) + new string(c2, 1));
									}
									break;
								}
								string value = input.Substring(num + 1, num2);
								list.Add((byte)RSGlobal.UIntParseFast(value));
								num = num2 + num;
							}
						}
					}
					num++;
				}
				while (num < input.Length);
			}
			if (list.Count > 0)
			{
				stringBuilder.Append(Encoding.UTF8.GetString(list.ToArray()));
				list.Clear();
			}
			return stringBuilder.ToString();
		}
		return input;
	}

	public static string RemoveComments(string input)
	{
		if (!input.Contains(Class16.smethod_0(1648904229)) && !input.Contains(Class16.smethod_0(1649166823)))
		{
			return input;
		}
		return Regex.Replace(Regex.Replace(input, Class16.smethod_0(1649166824), string.Empty), Class16.smethod_0(1649166835), string.Empty, RegexOptions.Multiline);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool StartsWithFast(string str, string check)
	{
		int num = ((check.Length >= str.Length) ? str.Length : check.Length);
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				if (str[num2] == check[num2])
				{
					num2++;
					continue;
				}
				return false;
			}
			while (num2 < num);
		}
		return true;
	}

	public static string GetCommonPrefix(string[] members, int checkCount)
	{
		if (checkCount == -1)
		{
			checkCount = members.Length;
		}
		int num = 2;
		if (2 < members[0].Length)
		{
			do
			{
				string value = members[0].Substring(0, num);
				int num2 = 1;
				if (1 < checkCount)
				{
					while (members[num2].StartsWith(value))
					{
						num2++;
						if (num2 < checkCount)
						{
							continue;
						}
						goto IL_0018;
					}
					break;
				}
				goto IL_0018;
				IL_0018:
				num++;
			}
			while (num < members[0].Length);
		}
		num--;
		object obj = null;
		if (num > 2)
		{
			obj = members[0].Substring(0, num);
		}
		return (string)obj;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsTagColorExist(string Name)
	{
		if (!string.IsNullOrWhiteSpace(Name) && Name.Length >= 7 && Name[0] == '^')
		{
			int num = 0;
			int num2 = 1;
			do
			{
				char c = Name[num2];
				if (((uint)c >= 48u && (uint)c <= 57u) || ((uint)c >= 97u && (uint)c <= 102u) || (uint)(ushort)(c + 65471) <= 5u)
				{
					num++;
				}
				num2++;
			}
			while (num2 <= 6);
			return num == 6;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool ParseNameAndColor(string text, ref string name, ref Color color)
	{
		if (IsTagColorExist(text))
		{
			Color color2 = Color.FromArgb(Convert.ToInt32(text.Substring(1, 6), 16));
			color = color2;
			name = text.Substring(7, text.Length - 7);
		}
		else
		{
			name = text;
		}
		return false;
	}

	public static string GetTagColorTextWPF(string text)
	{
		if (IsTagColorExist(text))
		{
			return Class16.smethod_0(1649161731) + text.Substring(1, 6);
		}
		return Class16.smethod_0(1648910035);
	}

	public static string Color2ColorTag(Color color_0)
	{
		byte b = color_0.B;
		byte g = color_0.G;
		return string.Concat(string.Concat(Class16.smethod_0(1648935659) + color_0.R.ToString(Class16.smethod_0(1648918695)), g.ToString(Class16.smethod_0(1648918695))), b.ToString(Class16.smethod_0(1648918695))).ToLowerInvariant();
	}

	public static Color GetTagColor(string text)
	{
		if (IsTagColorExist(text))
		{
			return Color.FromArgb(Convert.ToInt32(text.Substring(1, 6), 16));
		}
		return Color.White;
	}

	public static object GetTagColor_o(string text)
	{
		if (IsTagColorExist(text))
		{
			return Color.FromArgb(Convert.ToInt32(text.Substring(1, 6), 16));
		}
		return null;
	}

	public static object HexToColor_o(string text)
	{
		return Color.FromArgb(Convert.ToInt32(text, 16));
	}

	public static string GetParsedItemName(string Name)
	{
		if (IsTagColorExist(Name))
		{
			Name = Name.Substring(7, Name.Length - 7);
		}
		return Name;
	}

	public static string GetTagColorText(string Name)
	{
		if (IsTagColorExist(Name))
		{
			return Name.Substring(1, 6);
		}
		return string.Empty;
	}
}
