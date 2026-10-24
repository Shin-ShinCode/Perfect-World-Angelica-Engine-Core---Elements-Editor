using System;
using System.Collections.Generic;
using System.IO;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.Pck;

namespace ACE.PWMap;

internal static class PwMapAssetProvider
{
	private static readonly HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		Class16.smethod_0(1649138031),
		Class16.smethod_0(1649138081),
		Class16.smethod_0(1649093786),
		Class16.smethod_0(1649094038),
		Class16.smethod_0(1649067915),
		Class16.smethod_0(1649121484),
		Class16.smethod_0(1649094053),
		Class16.smethod_0(1649093829),
		Class16.smethod_0(1649094059),
		Class16.smethod_0(1649094073),
		Class16.smethod_0(1649094090),
		Class16.smethod_0(1649094110),
		Class16.smethod_0(1648961598),
		Class16.smethod_0(1648991932),
		Class16.smethod_0(1649141675),
		Class16.smethod_0(1649141703),
		Class16.smethod_0(1649094124),
		Class16.smethod_0(1649145044)
	};

	private static readonly Dictionary<string, string> dictionary_0 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

	private static readonly object object_0 = new object();

	private static Dictionary<string, byte[]> dictionary_1;

	private static Dictionary<string, bool> dictionary_2;

	private static bool bool_0;

	public static void BeginLoadingSession()
	{
		dictionary_1 = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
		dictionary_2 = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
		bool_0 = true;
	}

	public static void EndLoadingSession()
	{
		bool_0 = false;
		dictionary_1?.Clear();
		dictionary_1 = null;
		dictionary_2?.Clear();
		dictionary_2 = null;
	}

	public static byte[] ReadFileOrPckBytes(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			return null;
		}
		if (File.Exists(path))
		{
			try
			{
				return File.ReadAllBytes(path);
			}
			catch
			{
			}
		}
		return ReadPckBytes(path);
	}

	public static byte[] ReadPckBytes(string path)
	{
		string text = NormalizePckPath(path);
		if (bool_0 && dictionary_1 != null && dictionary_1.TryGetValue(text, out var value))
		{
			return value;
		}
		PCK_LIST pCK_LIST = smethod_0();
		if (pCK_LIST == null)
		{
			return null;
		}
		byte[] array = null;
		try
		{
			if (smethod_1(text, pCK_LIST))
			{
				byte[] fileB = pCK_LIST.GetFileB(text);
				if (fileB != null && fileB.Length != 0)
				{
					array = fileB;
				}
				if (array == null)
				{
					string text2 = smethod_4(text);
					string text3 = smethod_5(text);
					if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
					{
						PCK pCK = pCK_LIST[text2];
						if (pCK != null && pCK.FileLoaded)
						{
							byte[] fileB2 = pCK.GetFileB(text3);
							if (fileB2 != null && fileB2.Length != 0)
							{
								array = fileB2;
							}
						}
					}
				}
			}
			if (array == null)
			{
				foreach (string item in smethod_3(pCK_LIST))
				{
					PCK pCK2 = pCK_LIST[item];
					if (pCK2 == null || !pCK2.FileLoaded)
					{
						continue;
					}
					byte[] fileB3 = pCK2.GetFileB(text);
					if (fileB3 == null || fileB3.Length == 0)
					{
						if (!text.StartsWith(item + Class16.smethod_0(1648927580), StringComparison.OrdinalIgnoreCase))
						{
							fileB3 = pCK2.GetFileB(item + Class16.smethod_0(1648927580) + text);
							if (fileB3 != null && fileB3.Length != 0)
							{
								array = fileB3;
								break;
							}
						}
						continue;
					}
					array = fileB3;
					break;
				}
			}
		}
		catch
		{
		}
		if (bool_0 && dictionary_1 != null && array != null)
		{
			dictionary_1[text] = array;
		}
		return array;
	}

	public static bool ExistsInPck(string path)
	{
		string text = NormalizePckPath(path);
		if (bool_0 && dictionary_2 != null && dictionary_2.TryGetValue(text, out var value))
		{
			return value;
		}
		PCK_LIST pCK_LIST = smethod_0();
		if (pCK_LIST == null)
		{
			return false;
		}
		bool flag = false;
		try
		{
			if (smethod_1(text, pCK_LIST))
			{
				if (pCK_LIST.IsFileExist(text))
				{
					flag = true;
				}
				if (!flag)
				{
					string text2 = smethod_4(text);
					string text3 = smethod_5(text);
					if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
					{
						PCK pCK = pCK_LIST[text2];
						if (pCK != null && pCK.FileLoaded && pCK.IsFileExist(text3))
						{
							flag = true;
						}
					}
				}
			}
			if (!flag)
			{
				foreach (string item in smethod_3(pCK_LIST))
				{
					PCK pCK2 = pCK_LIST[item];
					if (pCK2 != null && pCK2.FileLoaded)
					{
						if (pCK2.IsFileExist(text))
						{
							flag = true;
							break;
						}
						if (!text.StartsWith(item + Class16.smethod_0(1648927580), StringComparison.OrdinalIgnoreCase) && pCK2.IsFileExist(item + Class16.smethod_0(1648927580) + text))
						{
							flag = true;
							break;
						}
					}
				}
			}
		}
		catch
		{
		}
		if (bool_0 && dictionary_2 != null)
		{
			dictionary_2[text] = flag;
		}
		return flag;
	}

	public static string ResolveFirstExistingPckPath(IEnumerable<string> candidates)
	{
		if (candidates == null)
		{
			return string.Empty;
		}
		foreach (string candidate in candidates)
		{
			string text = NormalizePckPath(candidate);
			if (ExistsInPck(text))
			{
				return text;
			}
		}
		return string.Empty;
	}

	public static IReadOnlyList<string> EnumeratePckFiles(string pckName, string directoryPrefix, string extension = "")
	{
		if (string.IsNullOrWhiteSpace(pckName))
		{
			return Array.Empty<string>();
		}
		PCK_LIST pCK_LIST = smethod_0();
		if (pCK_LIST == null)
		{
			return Array.Empty<string>();
		}
		PCK pCK = pCK_LIST[pckName];
		if (pCK != null && pCK.FileLoaded)
		{
			try
			{
				if (pCK.Paths == null || pCK.Paths.Length == 0)
				{
					pCK.CreatePathsArray();
				}
				string text = NormalizePckPath(directoryPrefix);
				if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith(Class16.smethod_0(1648927580), StringComparison.Ordinal))
				{
					text += Class16.smethod_0(1648927580);
				}
				List<string> list = new List<string>(4);
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.Add(text);
					if (text.StartsWith(pckName + Class16.smethod_0(1648927580), StringComparison.OrdinalIgnoreCase))
					{
						list.Add(text.Substring(pckName.Length + 1));
					}
					else
					{
						list.Add(pckName + Class16.smethod_0(1648927580) + text);
					}
				}
				List<string> list2 = new List<string>(256);
				string value = extension ?? string.Empty;
				for (int i = 0; i < pCK.Paths.Length; i++)
				{
					string text2 = pCK.Paths[i];
					if (!string.IsNullOrWhiteSpace(text2))
					{
						string text3 = NormalizePckPath(text2);
						if (!string.IsNullOrWhiteSpace(text))
						{
							bool flag = false;
							for (int j = 0; j < list.Count; j++)
							{
								if (text3.StartsWith(list[j], StringComparison.OrdinalIgnoreCase))
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								continue;
							}
						}
						if (string.IsNullOrWhiteSpace(value) || text3.EndsWith(value, StringComparison.OrdinalIgnoreCase))
						{
							list2.Add(text3);
						}
					}
				}
				return list2;
			}
			catch
			{
				return Array.Empty<string>();
			}
		}
		return Array.Empty<string>();
	}

	public static string ResolveFromPckByFileName(string pckName, string fileName, string requiredSubPath = "")
	{
		object obj;
		if (!string.IsNullOrWhiteSpace(pckName) && !string.IsNullOrWhiteSpace(fileName))
		{
			string fileName2 = System.IO.Path.GetFileName(fileName);
			if (fileName2 == null)
			{
				obj = null;
			}
			else
			{
				obj = fileName2.Trim();
				if (obj != null)
				{
					goto IL_0031;
				}
			}
			obj = string.Empty;
			goto IL_0031;
		}
		return string.Empty;
		IL_0031:
		string text = (string)obj;
		if (string.IsNullOrWhiteSpace(text))
		{
			return string.Empty;
		}
		string text2 = NormalizePckPath(requiredSubPath).ToLowerInvariant();
		string key = pckName.ToLowerInvariant() + Class16.smethod_0(1648905535) + text2 + Class16.smethod_0(1648905535) + text.ToLowerInvariant();
		lock (object_0)
		{
			if (dictionary_0.TryGetValue(key, out var value))
			{
				return value;
			}
		}
		PCK_LIST pCK_LIST = smethod_0();
		if (pCK_LIST == null)
		{
			return string.Empty;
		}
		PCK pCK = pCK_LIST[pckName];
		if (pCK != null && pCK.FileLoaded)
		{
			string text3 = string.Empty;
			try
			{
				if (pCK.Paths == null || pCK.Paths.Length == 0)
				{
					pCK.CreatePathsArray();
				}
				string text4 = (text2.StartsWith(pckName + Class16.smethod_0(1648927580), StringComparison.OrdinalIgnoreCase) ? text2.Substring(pckName.Length + 1) : text2);
				string value2 = (string.IsNullOrWhiteSpace(text4) ? string.Empty : (pckName + Class16.smethod_0(1648927580) + text4));
				for (int i = 0; i < pCK.Paths.Length; i++)
				{
					string text5 = pCK.Paths[i];
					if (!string.IsNullOrWhiteSpace(text5))
					{
						string text6 = NormalizePckPath(text5);
						if (text6.EndsWith(Class16.smethod_0(1648927580) + text, StringComparison.OrdinalIgnoreCase) && (string.IsNullOrWhiteSpace(text4) || text6.IndexOf(text4, StringComparison.OrdinalIgnoreCase) >= 0 || text6.IndexOf(value2, StringComparison.OrdinalIgnoreCase) >= 0))
						{
							text3 = text6;
							break;
						}
					}
				}
			}
			catch
			{
			}
			lock (object_0)
			{
				dictionary_0[key] = text3;
				return text3;
			}
		}
		return string.Empty;
	}

	public static string NormalizePckPath(string path)
	{
		string text = (path ?? string.Empty).Trim().Replace('/', '\\');
		while (text.StartsWith(Class16.smethod_0(1649094135), StringComparison.Ordinal))
		{
			text = text.Substring(2);
		}
		while (text.Contains(Class16.smethod_0(1648903386)))
		{
			text = text.Replace(Class16.smethod_0(1648903386), Class16.smethod_0(1648927580));
		}
		return text.TrimStart('\\');
	}

	private static PCK_LIST smethod_0()
	{
		if (CommonStorage.Params != null && CommonStorage.Params.UsePck)
		{
			return eListCollection.PCKs;
		}
		return null;
	}

	private static bool smethod_1(string string_0, PCK_LIST pck_LIST_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return false;
		}
		int num = string_0.IndexOf('\\');
		if (num <= 0)
		{
			return false;
		}
		string string_1 = string_0.Substring(0, num).ToLowerInvariant();
		return smethod_2(string_1, pck_LIST_0);
	}

	private static bool smethod_2(string string_0, PCK_LIST pck_LIST_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return false;
		}
		if (hashSet_0.Contains(string_0))
		{
			return true;
		}
		if (pck_LIST_0?.FileNames != null)
		{
			return pck_LIST_0.FileNames.ContainsKey(string_0);
		}
		return false;
	}

	private static IReadOnlyList<string> smethod_3(PCK_LIST pck_LIST_0)
	{
		List<string> list = new List<string>(hashSet_0.Count + 16);
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		foreach (string item in hashSet_0)
		{
			if (!string.IsNullOrWhiteSpace(item) && hashSet.Add(item))
			{
				list.Add(item);
			}
		}
		if (pck_LIST_0?.FileNames != null)
		{
			foreach (string key in pck_LIST_0.FileNames.Keys)
			{
				if (!string.IsNullOrWhiteSpace(key) && hashSet.Add(key))
				{
					list.Add(key);
				}
			}
		}
		return list;
	}

	private static string smethod_4(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return string.Empty;
		}
		int num = string_0.IndexOf('\\');
		if (num <= 0)
		{
			return string.Empty;
		}
		return string_0.Substring(0, num).ToLowerInvariant();
	}

	private static string smethod_5(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return string.Empty;
		}
		int num = string_0.IndexOf('\\');
		if (num > 0 && num + 1 < string_0.Length)
		{
			return string_0.Substring(num + 1);
		}
		return string.Empty;
	}
}
