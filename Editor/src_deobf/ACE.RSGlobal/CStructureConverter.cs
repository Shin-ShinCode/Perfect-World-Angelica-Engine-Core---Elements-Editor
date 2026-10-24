using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using ACE.Classes;
using NCalc;

namespace ACE.RSGlobal;

public class CStructureConverter
{
	public CSC_ACTION action;

	public string currentListName;

	public HashSet<string> EnumsAndMasks;

	public GAMES Game;

	private static HashSet<string> hashSet_0 = new HashSet<string>(new string[11]
	{
		Class16.smethod_0(1648989776),
		Class16.smethod_0(1648989786),
		Class16.smethod_0(1648989805),
		Class16.smethod_0(1648989809),
		Class16.smethod_0(1648989830),
		Class16.smethod_0(1648989834),
		Class16.smethod_0(1648902744),
		Class16.smethod_0(1648989855),
		Class16.smethod_0(1649168362),
		Class16.smethod_0(1648902792),
		Class16.smethod_0(1648902778)
	});

	private Dictionary<string, List<string>> dictionary_0 = new Dictionary<string, List<string>>();

	public CStructureConverter(CSC_ACTION action, string src_fn, string dest_fn, GAMES Game, int default_offset)
	{
		this.action = action;
		this.Game = Game;
		ParseStructs(src_fn, dest_fn, default_offset);
	}

	public CStructureConverter()
	{
	}

	public static void ParseOrderAndConvertStructToNormal(GAMES Game, string sCStructPath, string sListOrderPath, short version)
	{
		string text = Class16.smethod_0(1648927580);
		string text2 = string.Concat(System.IO.Path.GetDirectoryName(sCStructPath) + text, System.IO.Path.GetFileNameWithoutExtension(sCStructPath));
		string text3 = text2 + Class16.smethod_0(1649168383);
		int default_offset = ((Game != GAMES.SW && Game != GAMES.ROG && Game != GAMES.TOS) ? 4 : 0);
		new CStructureConverter(CSC_ACTION.UNKNOWN, sCStructPath, text3, Game, default_offset);
		if (File.Exists(sListOrderPath))
		{
			RSGlobal.OrderConfig(text3, text3, sListOrderPath, Game, version);
		}
		RSGlobal.ConvertStructureToNormalEnglish(text3, text2 + Class16.smethod_0(1649143702), Game, bPreserveUniversalFields: false);
	}

	private static int smethod_0(string string_0)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (!string_0.Contains(Class16.smethod_0(1648941528)) && !string_0.Contains(Class16.smethod_0(1648941500)))
		{
			return Convert.ToInt32(string_0);
		}
		return (int)new Expression(string_0).Evaluate();
	}

	private void method_0(string string_0, string string_1)
	{
		List<string> value = null;
		bool flag;
		if (!(flag = dictionary_0.TryGetValue(currentListName, out value)))
		{
			value = new List<string>();
		}
		value.Add(string.Concat(string_0 + Class16.smethod_0(1649167375), string_1));
		if (!flag)
		{
			dictionary_0.Add(currentListName, value);
		}
		GC.KeepAlive(this);
	}

	private void method_1(string string_0, string string_1, ref string[] string_2, ref string[] string_3, string string_4)
	{
		Array.Resize(ref string_2, string_2.Length + 1);
		Array.Resize(ref string_3, string_3.Length + 1);
		string_2[string_2.Length - 1] = string_0;
		string_3[string_3.Length - 1] = string_1;
		if (string_4 != null)
		{
			method_0(string_0, string_4);
		}
	}

	private string method_2(string string_0, string string_1)
	{
		int num = string_1.IndexOf(Class16.smethod_0(1648982877) + string_0);
		if (num == -1)
		{
			GC.KeepAlive(this);
			return null;
		}
		int num2 = string_1.IndexOf(Class16.smethod_0(1648908124), num) + 1;
		int num3 = RSGlobal.FindCloseSymbolIndex(string_1, Class16.smethod_0(1648908124), Class16.smethod_0(1648908132), num2);
		string text = string_1.Substring(num2, num3 - num2).Trim();
		string text2 = Class16.smethod_0(1649167376);
		string result = string.Concat(Class16.smethod_0(1649167385) + text, text2);
		GC.KeepAlive(this);
		return result;
	}

	private string method_3(string string_0)
	{
		string[] array = null;
		string[] array2 = null;
		if (string_0.Contains(Class16.smethod_0(1649167401)))
		{
			throw new Exception(Class16.smethod_0(1649167428) + string_0);
		}
		string[] array3 = new string[0];
		array = new string[0];
		array2 = new string[0];
		int num = 0;
		if (0 < (nint)array3.LongLength)
		{
			do
			{
				string text = array3[num];
				int num2 = text.LastIndexOf(Class16.smethod_0(1648942211)) + 1;
				string text2 = text.Substring(0, num2 - 1);
				string input = text.Substring(num2);
				int num3 = 0;
				int num4 = 1;
				if (text.EndsWith(Class16.smethod_0(1649008474)))
				{
					int num5 = text.IndexOf(Class16.smethod_0(1648924364));
					int num6 = text.IndexOf(Class16.smethod_0(1649008474), num5);
					num3 = smethod_0(text.Substring(num5 + 1, num6 - num5 - 1));
					int num7 = text.IndexOf(Class16.smethod_0(1648924364), num6);
					if (num7 > 0)
					{
						int num8 = text.IndexOf(Class16.smethod_0(1649008474), num7);
						num4 = smethod_0(text.Substring(num7 + 1, num8 - num7 - 1));
					}
				}
				input = Regex.Replace(input, Class16.smethod_0(1649167477), string.Empty);
				if (input == Class16.smethod_0(1648932143))
				{
					input = Class16.smethod_0(1648941057);
					text2 = Class16.smethod_0(1648989776);
				}
				if (input == Class16.smethod_0(1648905100))
				{
					input = Class16.smethod_0(1648936731);
				}
				if (input == Class16.smethod_0(1648956099) || input == Class16.smethod_0(1648960536))
				{
					text2 = Class16.smethod_0(1648989776);
				}
				if (input == Class16.smethod_0(1648960564))
				{
					text2 = Class16.smethod_0(1648989776);
				}
				if (text2.Contains(Class16.smethod_0(1649167483)))
				{
					int num9 = text2.LastIndexOf(Class16.smethod_0(1648942897));
					text2 = text2.Substring(num9 + 2, text2.Length + (-2 - num9));
				}
				if (text2 == Class16.smethod_0(1648986032))
				{
					GAMES game = Game;
					string text3 = ((game == GAMES.SW || game == GAMES.ROG || game == GAMES.TOS) ? Class16.smethod_0(1648989776) : Class16.smethod_0(1649168362));
					text2 = text3;
				}
				if (text2 == Class16.smethod_0(1649167511))
				{
					text2 = Class16.smethod_0(1649168362);
				}
				if (text2 == Class16.smethod_0(1648985199))
				{
					text2 = Class16.smethod_0(1648902778);
				}
				if (text2 == Class16.smethod_0(1649167524))
				{
					text2 = Class16.smethod_0(1648902778);
				}
				if (text2 == Class16.smethod_0(1648985163))
				{
					text2 = Class16.smethod_0(1648902792);
				}
				if (text2 == Class16.smethod_0(1649167539))
				{
					text2 = Class16.smethod_0(1648989786);
				}
				if (text2 == Class16.smethod_0(1649167554))
				{
					text2 = Class16.smethod_0(1648989830);
				}
				text2 = text2.Replace(Class16.smethod_0(1649167568), Class16.smethod_0(1649167584));
				if (text2 == Class16.smethod_0(1648960851))
				{
					text2 = Class16.smethod_0(1648989786);
				}
				if (text2 == Class16.smethod_0(1649167592))
				{
					text2 = Class16.smethod_0(1648989834);
				}
				if (text2 == Class16.smethod_0(1648985159))
				{
					text2 = Class16.smethod_0(1648989830);
				}
				if (text2 == Class16.smethod_0(1649167615))
				{
					text2 = Class16.smethod_0(1648989834);
				}
				if (text2 == Class16.smethod_0(1649167628))
				{
					text2 = Class16.smethod_0(1648989834);
				}
				text2 = text2.Replace(Class16.smethod_0(1648985106), Class16.smethod_0(1648989830));
				text2 = text2.Replace(Class16.smethod_0(1648985122), Class16.smethod_0(1648989830));
				text2 = text2.Replace(Class16.smethod_0(1649167638), Class16.smethod_0(1648989834));
				text2 = text2.Replace(Class16.smethod_0(1649167654), Class16.smethod_0(1648989830));
				HashSet<string> enumsAndMasks = EnumsAndMasks;
				int num10 = ((enumsAndMasks != null && enumsAndMasks.Contains(text2)) ? 1 : 0);
				bool flag = (byte)num10 != 0;
				string string_1 = null;
				if (flag)
				{
					if (action == CSC_ACTION.ENUM_AND_MASKS)
					{
						EnumsAndMasks.Add(text2);
					}
					string_1 = text2;
					text2 = Class16.smethod_0(1648989776);
				}
				else if (text2.Substring(0, 1) != text2.Substring(0, 1).ToLower())
				{
					RSGlobal.msgbox(Class16.smethod_0(1649167669) + text2);
				}
				if (hashSet_0.Contains(text2))
				{
					if (num3 == 0)
					{
						method_1(input, text2, ref array, ref array2, string_1);
					}
					else if (!(text2 == Class16.smethod_0(1648902792)) && !(text2 == Class16.smethod_0(1648902778)))
					{
						int num11 = 1;
						if (1 <= num3)
						{
							do
							{
								int num12 = 1;
								if (1 <= num4)
								{
									do
									{
										string text4 = string.Concat(input + Class16.smethod_0(1648923968), num11);
										if (num4 > 1)
										{
											text4 = string.Concat(text4, Class16.smethod_0(1648923968) + num12);
										}
										method_1(text4, text2, ref array, ref array2, string_1);
										num12++;
									}
									while (num12 <= num4);
								}
								num11++;
							}
							while (num11 <= num3);
						}
					}
					else if (num4 == 1)
					{
						if (text2 == Class16.smethod_0(1648902778))
						{
							num3 <<= 1;
						}
						text2 = string.Concat(text2, Class16.smethod_0(1648924402) + num3);
						method_1(input, text2, ref array, ref array2, string_1);
					}
					else
					{
						if (text2 == Class16.smethod_0(1648902778))
						{
							num4 <<= 1;
						}
						text2 = string.Concat(text2, Class16.smethod_0(1648924402) + num4);
						int num13 = 1;
						if (1 <= num3)
						{
							do
							{
								string string_2 = string.Concat(input + Class16.smethod_0(1648923968), num13);
								method_1(string_2, text2, ref array, ref array2, string_1);
								num13++;
							}
							while (num13 <= num3);
						}
					}
					num++;
					continue;
				}
				throw new Exception(Class16.smethod_0(1649167696) + text2);
			}
			while (num < (nint)array3.LongLength);
		}
		string separator = Class16.smethod_0(1648898262);
		string text5 = Class16.smethod_0(1648924428);
		string result = string.Concat(string.Join(Class16.smethod_0(1648898262), array) + text5, string.Join(separator, array2));
		GC.KeepAlive(this);
		return result;
	}

	private string method_4(string string_0, string string_1)
	{
		int num = string_0.IndexOf(Class16.smethod_0(1649008377));
		if (num != 0)
		{
			while (num >= 1)
			{
				int num2 = 0;
				int num3 = 0;
				int num4 = num;
				if (num > 0)
				{
					while (true)
					{
						string text = Class16.smethod_0(1648942211);
						if (!(string_0.Substring(num4, 1) == text))
						{
							string text2 = Class16.smethod_0(1648904383);
							if (!(string_0.Substring(num4, 1) == text2))
							{
								string text3 = Class16.smethod_0(1648941987);
								if (!(string_0.Substring(num4, 1) == text3))
								{
									num4--;
									if (num4 <= 0)
									{
										break;
									}
									continue;
								}
							}
						}
						num2 = num4 + 1;
						break;
					}
				}
				int num5 = num;
				if (num < string_0.Length)
				{
					while (true)
					{
						string text4 = Class16.smethod_0(1648942211);
						if (!(string_0.Substring(num5, 1) == text4))
						{
							string text5 = Class16.smethod_0(1648904383);
							if (!(string_0.Substring(num5, 1) == text5))
							{
								num5++;
								if (num5 >= string_0.Length)
								{
									break;
								}
								continue;
							}
						}
						num3 = num5;
						break;
					}
				}
				int num6 = string_0.IndexOf(Class16.smethod_0(1648898262), num3);
				string text6 = Class16.smethod_0(1649167725);
				if (string_0.Substring(num6 - 1, 2) != text6)
				{
					string_0 = string_0.Insert(num6, Class16.smethod_0(1649167734));
				}
				string text7 = string_0.Substring(num2, num3 - num2);
				string text8 = method_2(text7, string_1);
				if (!string.IsNullOrEmpty(text8))
				{
					string_0 = string.Concat(string_0.Substring(0, num2) + text8, string_0.Substring(num3));
					num = string_0.IndexOf(Class16.smethod_0(1649008377));
					if (num == 0)
					{
						break;
					}
					continue;
				}
				throw new Exception(Class16.smethod_0(1649167736) + text7);
			}
		}
		int num7 = string_0.IndexOf(Class16.smethod_0(1649167769));
		if (num7 > -1)
		{
			string text9 = Class16.smethod_0(1649167769);
			int num8 = text9.Length + num7;
			if (num8 < string_0.Length)
			{
				do
				{
					string text10 = Class16.smethod_0(1648942211);
					if (string_0.Substring(num8, 1) == text10)
					{
						break;
					}
					string text11 = Class16.smethod_0(1648904383);
					if (string_0.Substring(num8, 1) == text11)
					{
						break;
					}
					num8++;
				}
				while (num8 < string_0.Length);
			}
			string text12 = method_2(text9, string_1);
			if (string.IsNullOrEmpty(text12))
			{
				throw new Exception(Class16.smethod_0(1649167736) + text9);
			}
			int startIndex = string_0.IndexOf(Class16.smethod_0(1648898262), num7) + 1;
			int num9 = text12.IndexOf(Class16.smethod_0(1648908124));
			int num10 = text12.LastIndexOf(Class16.smethod_0(1648908132));
			text12 = text12.Substring(num9 + 1, num10 - num9 - 1);
			string_0 = string.Concat(string_0.Substring(0, num7) + text12, string_0.Substring(startIndex));
		}
		GC.KeepAlive(this);
		return string_0;
	}

	private string method_5(string string_0)
	{
		if (!string_0.Contains(Class16.smethod_0(1649167792)))
		{
			GC.KeepAlive(this);
			return string_0;
		}
		return string_0;
	}

	public void ParseStructs(string structs_fn, string dest_fn, int default_offset)
	{
		string text = null;
		string text2 = Class16.smethod_0(1649167809);
		string path = System.IO.Path.GetDirectoryName(structs_fn) + text2;
		if (File.Exists(path))
		{
			EnumsAndMasks = new HashSet<string>(File.ReadAllLines(path));
		}
		string input = File.ReadAllText(structs_fn);
		input = RSCommon.RemoveComments(input);
		input = input.Replace(Class16.smethod_0(1648924428), Class16.smethod_0(1648941987));
		input = input.Replace('\t', ' ');
		if (input.Contains(Class16.smethod_0(1649043292)))
		{
			do
			{
				input = input.Replace(Class16.smethod_0(1649043292), Class16.smethod_0(1648942211));
			}
			while (input.Contains(Class16.smethod_0(1649043292)));
		}
		input = input.Replace(Class16.smethod_0(1648986192), Class16.smethod_0(1648898262));
		input = input.Replace(Class16.smethod_0(1649167839), Class16.smethod_0(1648941987));
		if (input.Contains(Class16.smethod_0(1648908367)))
		{
			do
			{
				input = input.Replace(Class16.smethod_0(1648908367), Class16.smethod_0(1648941987));
			}
			while (input.Contains(Class16.smethod_0(1648908367)));
		}
		input = input.Replace(Class16.smethod_0(1649167840), Class16.smethod_0(1648985965));
		input = input.Replace(Class16.smethod_0(1649167868), Class16.smethod_0(1648982877));
		int num = input.LastIndexOf(Class16.smethod_0(1649097215)) - 1;
		string text3 = string.Empty;
		if (num > 1)
		{
			text3 = input.Substring(num + 5);
			input = input.Substring(0, num);
		}
		input = Class16.smethod_0(1648908367) + input;
		Dictionary<string, string> dictionary = new Dictionary<string, string>(300);
		int num2 = input.IndexOf(Class16.smethod_0(1649166851), 0);
		if (num2 > 0)
		{
			do
			{
				int start_index = input.IndexOf(Class16.smethod_0(1648908124), num2) + 1;
				int num3 = RSGlobal.FindCloseSymbolIndex(input, Class16.smethod_0(1648908124), Class16.smethod_0(1648908132), start_index);
				string text4 = input.Substring(num2 + 1, num3 - num2).Trim();
				if (!text4.Contains(Class16.smethod_0(1649166866)))
				{
					string value = Regex.Match(text4, Class16.smethod_0(1649166902), RegexOptions.Multiline).Groups[1].Value;
					value = value.Trim();
					Match match = Regex.Match(text4, Class16.smethod_0(1649166922));
					int num4 = text4.IndexOf(Class16.smethod_0(1648908124)) + 1;
					int num5 = text4.LastIndexOf(Class16.smethod_0(1648908132)) - 1;
					text4 = text4.Substring(num4, num5 - num4).Trim();
					if (match.Success)
					{
						if (Game == GAMES.FW)
						{
							goto IL_01ca;
						}
						string value2 = match.Groups[1].Value;
						text = null;
						if (!dictionary.TryGetValue(value2, out text))
						{
							throw new Exception(Class16.smethod_0(1649166972) + value2);
						}
						text4 = string.Concat(text + Class16.smethod_0(1648941987), text4);
					}
					dictionary.Add(value, text4.Trim());
				}
				goto IL_01ca;
				IL_01ca:
				num2 = input.IndexOf(Class16.smethod_0(1649166851), num3);
			}
			while (num2 > 0);
		}
		string[] array = new string[dictionary.Count];
		int num6 = 0;
		Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				ValueType valueType = enumerator.Current;
				currentListName = ((KeyValuePair<string, string>)(object)valueType).Key;
				string string_ = ((KeyValuePair<string, string>)(object)valueType).Value;
				array[num6] = currentListName;
				string text5 = string.Concat(array[num6], Class16.smethod_0(1648924428) + default_offset);
				array[num6] = text5;
				if (currentListName != Class16.smethod_0(1649167005))
				{
					if (text3 != null)
					{
						string_ = method_4(string_, text3);
					}
					string text6 = string.Concat(array[num6], Class16.smethod_0(1648924428) + method_3(string_));
					array[num6] = text6;
				}
				else
				{
					array[num6] += Class16.smethod_0(1649167021);
				}
				num6++;
			}
			while (enumerator.MoveNext());
		}
		switch (action)
		{
		case CSC_ACTION.ENUM_AND_MASKS:
		{
			HashSet<string> enumsAndMasks = EnumsAndMasks;
			File.WriteAllText(dest_fn, string.Join(Class16.smethod_0(1648924428), enumsAndMasks), Encoding.UTF8);
			break;
		}
		case CSC_ACTION.UNKNOWN:
		{
			string arg = string.Join(Class16.smethod_0(1648898460), array);
			string contents = string.Format(Class16.smethod_0(1649167039), array.Length, 999, arg);
			File.WriteAllText(dest_fn, contents, Encoding.UTF8);
			break;
		}
		}
		if (dictionary_0.Count > 0)
		{
			string text7 = Class16.smethod_0(1649167061);
			string text8 = System.IO.Path.GetDirectoryName(structs_fn) + text7;
			RSGlobal.DeleteIfExists(text8);
			StreamWriter streamWriter = new StreamWriter(File.OpenWrite(text8));
			Dictionary<string, List<string>>.Enumerator enumerator2 = dictionary_0.GetEnumerator();
			if (enumerator2.MoveNext())
			{
				do
				{
					ValueType valueType2 = enumerator2.Current;
					string key = ((KeyValuePair<string, List<string>>)(object)valueType2).Key;
					List<string> value3 = ((KeyValuePair<string, List<string>>)(object)valueType2).Value;
					streamWriter.WriteLine(Class16.smethod_0(1648929947) + key);
					List<string>.Enumerator enumerator3 = value3.GetEnumerator();
					if (enumerator3.MoveNext())
					{
						do
						{
							string current = enumerator3.Current;
							streamWriter.WriteLine(current);
						}
						while (enumerator3.MoveNext());
					}
					streamWriter.WriteLine(string.Empty);
				}
				while (enumerator2.MoveNext());
			}
			streamWriter.Close();
		}
		GC.KeepAlive(this);
	}
}
