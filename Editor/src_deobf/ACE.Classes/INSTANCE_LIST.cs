using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.Precint;
using ACE.RSGlobal;

namespace ACE.Classes;

public class INSTANCE_LIST
{
	public static string FileName;

	public static List<INSTANCE> Instances;

	public static void Load(string fn)
	{
		Instances = new List<INSTANCE>(100);
		if (!File.Exists(fn))
		{
			return;
		}
		FileName = fn;
		StreamReader streamReader = File.OpenText(fn);
		string text = streamReader.ReadLine();
		if (text != null)
		{
			do
			{
				if (!string.IsNullOrWhiteSpace(text) && text[0] != '/')
				{
					string[] array = text.Split('\t');
					if ((nint)array.LongLength >= 5)
					{
						INSTANCE item = new INSTANCE
						{
							ID = global::ACE.RSGlobal.RSGlobal.UIntParseFast(array[0])
						};
						if (array[1] == Class16.smethod_0(1648904929))
						{
							array[1] = Class16.smethod_0(1648904944);
						}
						item.ClientMapTag = array[1];
						item.ServerMapTag = array[2];
						item.ProcName = array[3];
						item.Name = array[4];
						Instances.Add(item);
					}
				}
				text = streamReader.ReadLine();
			}
			while (text != null);
		}
		streamReader.Close();
	}

	public static int AddInstance(string text)
	{
		INSTANCE item = new INSTANCE
		{
			ID = Instances.Count + 1000,
			ClientMapTag = text,
			ServerMapTag = text,
			Name = text
		};
		Instances.Add(item);
		return item.ID;
	}

	public static string GetNameByID(int ID)
	{
		if (ID == 0)
		{
			return Class16.smethod_0(1648924120);
		}
		if (Instances != null)
		{
			int num = 0;
			if (0 < Instances.Count)
			{
				do
				{
					if (Instances[num].ID != ID)
					{
						num++;
						continue;
					}
					INSTANCE iNSTANCE = Instances[num];
					INSTANCE iNSTANCE2 = Instances[num];
					string text = Class16.smethod_0(1648924347);
					return string.Concat(string.Concat(Class16.smethod_0(1648924364) + iNSTANCE2.ServerMapTag, text), iNSTANCE.Name);
				}
				while (num < Instances.Count);
			}
		}
		return null;
	}

	public static string GetNameByServerTag(string ServerMapTag)
	{
		int num = 0;
		if (0 < Instances.Count)
		{
			do
			{
				if (!(Instances[num].ServerMapTag == ServerMapTag))
				{
					num++;
					continue;
				}
				return Instances[num].Name;
			}
			while (num < Instances.Count);
		}
		return ServerMapTag;
	}

	public static string GetClientTagByID(int ID)
	{
		int num = 0;
		if (0 < Instances.Count)
		{
			do
			{
				if (Instances[num].ID != ID)
				{
					num++;
					continue;
				}
				return Instances[num].ClientMapTag;
			}
			while (num < Instances.Count);
		}
		return null;
	}

	public static int GetIdByServerTag(string ServerMapTag)
	{
		int num = 0;
		if (0 < Instances.Count)
		{
			do
			{
				if (!(Instances[num].ServerMapTag == ServerMapTag))
				{
					num++;
					continue;
				}
				return Instances[num].ID;
			}
			while (num < Instances.Count);
		}
		return 0;
	}

	public static int GetIdByClientTag(string ClientMapTag)
	{
		int num = 0;
		if (0 < Instances.Count)
		{
			do
			{
				if (!(Instances[num].ClientMapTag == ClientMapTag))
				{
					num++;
					continue;
				}
				return Instances[num].ID;
			}
			while (num < Instances.Count);
		}
		return 0;
	}

	public static string DecodeIdAndCoords(int instance_id, float[] vPos)
	{
		if (instance_id == 0)
		{
			return Class16.smethod_0(1648924120);
		}
		if (Instances == null)
		{
			return null;
		}
		return GetPositionInfo(instance_id, vPos).DecodeAll();
	}

	public unsafe static POSITION_INFO GetPositionInfo(int instance_id, float[] vPos)
	{
		if (instance_id != 0 && Instances != null)
		{
			POSITION_INFO pOSITION_INFO = new POSITION_INFO(vPos);
			int num = 0;
			if (0 < Instances.Count)
			{
				do
				{
					if (Instances[num].ID == instance_id)
					{
						INSTANCE instance = Instances[num];
						pOSITION_INFO.instance = instance;
					}
					num++;
				}
				while (num < Instances.Count);
			}
			if (pOSITION_INFO.instance.ClientMapTag != null && PRECINCT_LIST.FilesLoaded)
			{
				bool bRIP = false;
				pOSITION_INFO.area = PRECINCT_LIST.GetArea(pOSITION_INFO.instance.ClientMapTag, instance_id, vPos, &bRIP);
				pOSITION_INFO.bRIP = bRIP;
			}
			return pOSITION_INFO;
		}
		return null;
	}

	public static int GetAreaID(int instance_id, float[] vPos)
	{
		if (Instances != null && PRECINCT_LIST.FilesLoaded)
		{
			string clientTagByID = GetClientTagByID(instance_id);
			if (clientTagByID != null)
			{
				return PRECINCT_LIST.GetAreaID(clientTagByID, instance_id, vPos) ? 1 : 0;
			}
			return 0;
		}
		return 0;
	}

	public static PRECINCT GetPrecinct(int instance_id)
	{
		PRECINCT pRECINCT = null;
		if (Instances != null && PRECINCT_LIST.FilesLoaded)
		{
			string clientTagByID = GetClientTagByID(instance_id);
			pRECINCT = null;
			if (clientTagByID != null && !PRECINCT_LIST.Precincts.TryGetValue(clientTagByID, out pRECINCT))
			{
				string text = Class16.smethod_0(1648904954);
				DKBox.Show(string.Concat(Class16.smethod_0(1648904980) + clientTagByID, text), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return pRECINCT;
		}
		return null;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsPointVisible(int instance_id, int area_id, float[] vPos)
	{
		if (Instances != null && PRECINCT_LIST.FilesLoaded)
		{
			string clientTagByID = GetClientTagByID(instance_id);
			if (clientTagByID != null)
			{
				return PRECINCT_LIST.IsPointVisible(clientTagByID, area_id, vPos);
			}
			return false;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsPointVisibleS(int instance_id, string area_name, float[] vPos, [MarshalAs(UnmanagedType.U1)] bool bCheckContains)
	{
		if (Instances != null && PRECINCT_LIST.FilesLoaded)
		{
			string clientTagByID = GetClientTagByID(instance_id);
			if (clientTagByID != null)
			{
				return PRECINCT_LIST.IsPointVisibleS(clientTagByID, area_name, vPos, bCheckContains);
			}
			return false;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool LoadFromBytes(byte[] fileContent, string fileName)
	{
		if (fileContent != null && fileContent.Length != 0 && !string.IsNullOrWhiteSpace(fileName))
		{
			string fileContent2 = smethod_6(fileContent);
			if (fileName.EndsWith(Class16.smethod_0(1648904996), StringComparison.OrdinalIgnoreCase))
			{
				return LoadFromLuaContent(fileContent2);
			}
			return LoadFromTextContent(fileContent2);
		}
		Instances = new List<INSTANCE>(100);
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TryLoadFromPckEntries(byte[] luaContent, byte[] textContent, [MarshalAs(UnmanagedType.U1)] out bool sourceFound)
	{
		if (luaContent != null)
		{
			sourceFound = true;
			if (LoadFromBytes(luaContent, Class16.smethod_0(1648905007)))
			{
				return true;
			}
			if (textContent != null)
			{
				return LoadFromBytes(textContent, Class16.smethod_0(1648905026));
			}
			return false;
		}
		if (textContent != null)
		{
			sourceFound = true;
			return LoadFromBytes(textContent, Class16.smethod_0(1648905026));
		}
		sourceFound = false;
		Instances = new List<INSTANCE>(100);
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool LoadFromLuaContent(string fileContent)
	{
		Instances = new List<INSTANCE>(100);
		if (string.IsNullOrWhiteSpace(fileContent))
		{
			return false;
		}
		string text = smethod_2(fileContent);
		MatchCollection matchCollection = Regex.Matches(text, Class16.smethod_0(1648905061), RegexOptions.Multiline);
		if (matchCollection.Count == 0)
		{
			return false;
		}
		foreach (Match item in matchCollection)
		{
			if (!int.TryParse(item.Groups[Class16.smethod_0(1648932143)].Value, out var result))
			{
				continue;
			}
			string text2 = smethod_0(text, item.Index + item.Length);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				string string_ = smethod_1(text2, Class16.smethod_0(1648905100));
				string text3 = smethod_1(text2, Class16.smethod_0(1648906425));
				string string_2 = smethod_1(text2, Class16.smethod_0(1648905111));
				if (!string.IsNullOrWhiteSpace(text3))
				{
					Instances.Add(smethod_7(result, string_, text3, string_2));
				}
			}
		}
		return Instances.Count > 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool LoadFromTextContent(string fileContent)
	{
		Instances = new List<INSTANCE>(100);
		if (string.IsNullOrWhiteSpace(fileContent))
		{
			return false;
		}
		MatchCollection matchCollection = Regex.Matches(fileContent, Class16.smethod_0(1648905126), RegexOptions.Multiline);
		if (matchCollection.Count == 0)
		{
			return false;
		}
		foreach (Match item in matchCollection)
		{
			string text = smethod_0(fileContent, item.Index + item.Length - 1);
			if (string.IsNullOrWhiteSpace(text))
			{
				continue;
			}
			List<string> list = smethod_3(text);
			if (list.Count >= 2 && int.TryParse(list[0], out var result))
			{
				string text2 = smethod_5(list[1]);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					Instances.Add(smethod_7(result, item.Groups[Class16.smethod_0(1648905100)].Value, text2, null));
				}
			}
		}
		return Instances.Count > 0;
	}

	public static string FormatDisplayName(INSTANCE instance)
	{
		if (string.IsNullOrWhiteSpace(instance.ServerMapTag))
		{
			return instance.Name ?? string.Empty;
		}
		if (string.IsNullOrWhiteSpace(instance.ProcName))
		{
			return Class16.smethod_0(1648924364) + instance.ServerMapTag + Class16.smethod_0(1648924347) + instance.Name;
		}
		return Class16.smethod_0(1648924364) + instance.ServerMapTag + Class16.smethod_0(1648942920) + instance.ProcName + Class16.smethod_0(1648924347) + instance.Name;
	}

	private static string smethod_0(string string_0, int int_0)
	{
		int num = string_0.IndexOf('{', int_0);
		if (num < 0)
		{
			return null;
		}
		int num2 = 0;
		for (int i = num; i < string_0.Length; i++)
		{
			switch (string_0[i])
			{
			case '{':
				num2++;
				break;
			case '}':
				num2--;
				if (num2 == 0)
				{
					return string_0.Substring(num + 1, i - num - 1);
				}
				break;
			}
		}
		return null;
	}

	private static string smethod_1(string string_0, string string_1)
	{
		Match match = Regex.Match(string_0, Class16.smethod_0(1648905146) + Regex.Escape(string_1) + Class16.smethod_0(1648905155));
		if (!match.Success)
		{
			return null;
		}
		return match.Groups[Class16.smethod_0(1648905186)].Value.Trim();
	}

	private static string smethod_2(string string_0)
	{
		string input = Regex.Replace(string_0, Class16.smethod_0(1648905206), string.Empty, RegexOptions.Singleline);
		return Regex.Replace(input, Class16.smethod_0(1648904201), string.Empty, RegexOptions.Multiline);
	}

	private static List<string> smethod_3(string string_0)
	{
		List<string> list = new List<string>();
		string[] array = string_0.Split(new string[3]
		{
			Class16.smethod_0(1648924428),
			Class16.smethod_0(1648941987),
			Class16.smethod_0(1648904221)
		}, StringSplitOptions.None);
		string[] array2 = array;
		foreach (string string_1 in array2)
		{
			string text = smethod_4(string_1).Trim();
			if (!string.IsNullOrWhiteSpace(text))
			{
				list.Add(text);
			}
		}
		return list;
	}

	private static string smethod_4(string string_0)
	{
		int num = string_0.IndexOf(Class16.smethod_0(1648904229), StringComparison.Ordinal);
		if (num < 0)
		{
			return string_0;
		}
		return string_0.Substring(0, num);
	}

	private static string smethod_5(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return null;
		}
		string text = string_0.Trim();
		if (text.Length >= 2 && text[0] == '"' && text[text.Length - 1] == '"')
		{
			return text.Substring(1, text.Length - 2);
		}
		return text;
	}

	private static string smethod_6(byte[] byte_0)
	{
		if (byte_0.Length >= 2 && byte_0[0] == byte.MaxValue && byte_0[1] == 254)
		{
			return Encoding.Unicode.GetString(byte_0, 2, byte_0.Length - 2);
		}
		if (byte_0.Length >= 2 && byte_0[0] == 254 && byte_0[1] == byte.MaxValue)
		{
			return Encoding.BigEndianUnicode.GetString(byte_0, 2, byte_0.Length - 2);
		}
		if (byte_0.Length >= 3 && byte_0[0] == 239 && byte_0[1] == 187 && byte_0[2] == 191)
		{
			return Encoding.UTF8.GetString(byte_0, 3, byte_0.Length - 3);
		}
		if (byte_0.Length >= 2 && byte_0[0] == 60 && byte_0[1] == 0)
		{
			return Encoding.Unicode.GetString(byte_0);
		}
		if (byte_0.Length >= 2 && byte_0[0] == 0 && byte_0[1] == 60)
		{
			return Encoding.BigEndianUnicode.GetString(byte_0);
		}
		return Encoding.UTF8.GetString(byte_0);
	}

	private static INSTANCE smethod_7(int int_0, string string_0, string string_1, string string_2)
	{
		smethod_8(string_1, string_2, out var string_3, out var string_4);
		return new INSTANCE
		{
			ID = int_0,
			ClientMapTag = string_4,
			ServerMapTag = string_3,
			ProcName = string.Empty,
			Name = (string_0 ?? string.Empty)
		};
	}

	private static void smethod_8(string string_0, string string_1, out string string_2, out string string_3)
	{
		string text = smethod_10(string_0);
		string text2 = smethod_10(string_1);
		if (!string.IsNullOrWhiteSpace(text2))
		{
			string_2 = smethod_9(text2);
			string_3 = smethod_9(text2);
		}
		else if (!string.IsNullOrWhiteSpace(text) && text.Contains(Class16.smethod_0(1648928028)))
		{
			string_3 = (string_2 = smethod_9(text));
		}
		else
		{
			string_2 = text;
			string_3 = (string.IsNullOrWhiteSpace(text2) ? text : text2);
		}
	}

	private static string smethod_9(string string_0)
	{
		string text = smethod_10(string_0);
		if (!string.IsNullOrWhiteSpace(text) && text.Contains(Class16.smethod_0(1648928028)))
		{
			string[] array = text.Split(',');
			return smethod_10((array.Length > 1) ? array[1] : array[0]);
		}
		return text;
	}

	private static string smethod_10(string string_0)
	{
		if (!string.IsNullOrWhiteSpace(string_0))
		{
			return string_0.Trim();
		}
		return null;
	}
}
