using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ACE.PWMap;

internal sealed class PwMapCollisionExportResolver
{
	private readonly PwMapTrn2File pwMapTrn2File_0;

	private readonly string string_0;

	private readonly string string_1;

	private readonly string string_2;

	private readonly Dictionary<int, HashSet<string>> dictionary_0 = new Dictionary<int, HashSet<string>>();

	private readonly HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<string, List<PwMapCollisionBrush>> dictionary_1 = new Dictionary<string, List<PwMapCollisionBrush>>(StringComparer.OrdinalIgnoreCase);

	public int TotalModelFiles => hashSet_0.Count;

	private PwMapCollisionExportResolver(PwMapTrn2File pwMapTrn2File_1, string string_3, string string_4, string string_5)
	{
		pwMapTrn2File_0 = pwMapTrn2File_1;
		string_0 = string_3 ?? string.Empty;
		string_1 = string_4 ?? string.Empty;
		string_2 = string_5 ?? string.Empty;
	}

	public IEnumerable<string> GetAllModelPaths()
	{
		return hashSet_0;
	}

	public IEnumerable<string> GetSectorModelPaths(int sectorIndex)
	{
		if (!dictionary_0.TryGetValue(sectorIndex, out var value))
		{
			return Array.Empty<string>();
		}
		return value;
	}

	public static PwMapCollisionExportResolver Create(PwMapTrn2File trn2, string mapName, string mapRoot, string elementPath)
	{
		PwMapCollisionExportResolver pwMapCollisionExportResolver = new PwMapCollisionExportResolver(trn2, mapName, mapRoot, elementPath);
		pwMapCollisionExportResolver.method_0();
		return pwMapCollisionExportResolver;
	}

	public List<PwMapCollisionBrush> LoadAllBrushes()
	{
		List<PwMapCollisionBrush> list = new List<PwMapCollisionBrush>(4096);
		foreach (string item in hashSet_0)
		{
			list.AddRange(method_4(item));
		}
		return list;
	}

	public List<PwMapCollisionBrush> LoadSectorBrushes(int sectorIndex)
	{
		List<PwMapCollisionBrush> list = new List<PwMapCollisionBrush>(512);
		if (!dictionary_0.TryGetValue(sectorIndex, out var value))
		{
			return list;
		}
		foreach (string item in value)
		{
			list.AddRange(method_4(item));
		}
		return list;
	}

	private void method_0()
	{
		if (!method_1())
		{
			method_2();
		}
	}

	private bool method_1()
	{
		smethod_4(string_1, string_0, out var string_, out var string_2);
		if (!string.IsNullOrWhiteSpace(string_) && !string.IsNullOrWhiteSpace(string_2))
		{
			PwMapEcwldCollisionIndex pwMapEcwldCollisionIndex = PwMapEcwldCollisionIndex.Build(string_, string_2, pwMapTrn2File_0);
			if (pwMapEcwldCollisionIndex != null && pwMapEcwldCollisionIndex.OrnamentPathByExportId.Count != 0)
			{
				Dictionary<int, string> dictionary = new Dictionary<int, string>();
				int num = 0;
				foreach (KeyValuePair<int, string> item in pwMapEcwldCollisionIndex.OrnamentPathByExportId)
				{
					string text = method_5(item.Value);
					if (string.IsNullOrWhiteSpace(text))
					{
						num++;
						continue;
					}
					dictionary[item.Key] = text;
					hashSet_0.Add(text);
				}
				for (int i = 0; i < pwMapTrn2File_0.TotalSectors; i++)
				{
					foreach (int sectorExportId in pwMapEcwldCollisionIndex.GetSectorExportIds(i))
					{
						if (dictionary.TryGetValue(sectorExportId, out var value))
						{
							if (!dictionary_0.TryGetValue(i, out var value2))
							{
								value2 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
								dictionary_0[i] = value2;
							}
							value2.Add(value);
						}
					}
				}
				return hashSet_0.Count > 0;
			}
			return false;
		}
		return false;
	}

	private void method_2()
	{
		foreach (string item in method_8())
		{
			foreach (string item2 in method_7(item))
			{
				if (!Directory.Exists(item2))
				{
					continue;
				}
				for (int i = 0; i < pwMapTrn2File_0.TotalSectors; i++)
				{
					string path = System.IO.Path.Combine(item2, (i + 1).ToString());
					if (!Directory.Exists(path))
					{
						continue;
					}
					if (!dictionary_0.TryGetValue(i, out var value))
					{
						value = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
						dictionary_0[i] = value;
					}
					try
					{
						foreach (string item3 in Directory.EnumerateFiles(path, Class16.smethod_0(1649093171), SearchOption.AllDirectories))
						{
							value.Add(item3);
							hashSet_0.Add(item3);
						}
					}
					catch
					{
					}
				}
			}
		}
		method_3();
	}

	private void method_3()
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return;
		}
		string text = PwMapAssetProvider.NormalizePckPath(Class16.smethod_0(1649093191) + string_0);
		string text2 = PwMapAssetProvider.NormalizePckPath(Class16.smethod_0(1649093215) + string_0);
		string text3 = PwMapAssetProvider.NormalizePckPath(Class16.smethod_0(1649093224) + string_0 + Class16.smethod_0(1649093243));
		string text4 = PwMapAssetProvider.NormalizePckPath(Class16.smethod_0(1649093268) + string_0 + Class16.smethod_0(1649093243));
		string[] array = new string[2]
		{
			Class16.smethod_0(1649093786),
			Class16.smethod_0(1649138031)
		};
		List<string> list = new List<string>();
		foreach (string pckName in array)
		{
			smethod_0(list, PwMapAssetProvider.EnumeratePckFiles(pckName, text, Class16.smethod_0(1649142694)));
			smethod_0(list, PwMapAssetProvider.EnumeratePckFiles(pckName, text2, Class16.smethod_0(1649142694)));
			smethod_0(list, PwMapAssetProvider.EnumeratePckFiles(pckName, text3, Class16.smethod_0(1649142694)));
			smethod_0(list, PwMapAssetProvider.EnumeratePckFiles(pckName, text4, Class16.smethod_0(1649142694)));
		}
		if (list.Count == 0)
		{
			return;
		}
		string string_ = text + Class16.smethod_0(1648927580);
		string string_2 = text2 + Class16.smethod_0(1648927580);
		string string_3 = text3 + Class16.smethod_0(1648927580);
		string string_4 = text4 + Class16.smethod_0(1648927580);
		for (int j = 0; j < list.Count; j++)
		{
			string text5 = list[j];
			if (string.IsNullOrWhiteSpace(text5))
			{
				continue;
			}
			int num = smethod_1(text5, string_);
			if (num < 0)
			{
				num = smethod_1(text5, string_2);
			}
			if (num < 0)
			{
				num = smethod_1(text5, string_3);
			}
			if (num < 0)
			{
				num = smethod_1(text5, string_4);
			}
			if (num >= 0 && num < pwMapTrn2File_0.TotalSectors)
			{
				hashSet_0.Add(text5);
				if (!dictionary_0.TryGetValue(num, out var value))
				{
					value = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
					dictionary_0[num] = value;
				}
				value.Add(text5);
			}
		}
	}

	private static void smethod_0(List<string> list_0, IReadOnlyList<string> ireadOnlyList_0)
	{
		if (list_0 == null || ireadOnlyList_0 == null || ireadOnlyList_0.Count == 0)
		{
			return;
		}
		for (int i = 0; i < ireadOnlyList_0.Count; i++)
		{
			string text = ireadOnlyList_0[i];
			if (string.IsNullOrWhiteSpace(text))
			{
				continue;
			}
			bool flag = false;
			for (int j = 0; j < list_0.Count; j++)
			{
				if (string.Equals(list_0[j], text, StringComparison.OrdinalIgnoreCase))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list_0.Add(text);
			}
		}
	}

	private static int smethod_1(string string_3, string string_4)
	{
		string_3 = PwMapAssetProvider.NormalizePckPath(string_3);
		string_4 = PwMapAssetProvider.NormalizePckPath(string_4);
		if (!string.IsNullOrWhiteSpace(string_3) && !string.IsNullOrWhiteSpace(string_4) && string_3.StartsWith(string_4, StringComparison.OrdinalIgnoreCase))
		{
			string text = string_3.Substring(string_4.Length).TrimStart('\\');
			if (string.IsNullOrWhiteSpace(text))
			{
				return -1;
			}
			int num = text.IndexOf('\\');
			if (num <= 0)
			{
				return -1;
			}
			string s = text.Substring(0, num);
			if (!int.TryParse(s, out var result))
			{
				return -1;
			}
			return result - 1;
		}
		return -1;
	}

	private List<PwMapCollisionBrush> method_4(string string_3)
	{
		if (!dictionary_1.TryGetValue(string_3, out var value))
		{
			value = PwMapBmdCollisionFile.LoadBrushes(string_3);
			dictionary_1[string_3] = value;
		}
		return value;
	}

	private string method_5(string string_3)
	{
		if (string.IsNullOrWhiteSpace(string_3))
		{
			return string.Empty;
		}
		string text = string_3.Replace('\\', '/').Trim();
		while (text.StartsWith(Class16.smethod_0(1649093272), StringComparison.Ordinal))
		{
			text = text.Substring(2);
		}
		if (System.IO.Path.IsPathRooted(text) && File.Exists(text))
		{
			return text;
		}
		string[] array = smethod_2(text);
		bool flag = text.StartsWith(Class16.smethod_0(1649093281), StringComparison.OrdinalIgnoreCase);
		foreach (string item in method_8())
		{
			foreach (string text2 in array)
			{
				string text3 = text2.Replace('/', System.IO.Path.DirectorySeparatorChar);
				string[] array2 = new string[6]
				{
					flag ? System.IO.Path.Combine(item, text3) : string.Empty,
					System.IO.Path.Combine(item, Class16.smethod_0(1649093786), string_0, text3),
					System.IO.Path.Combine(item, Class16.smethod_0(1649094124), string_0, text3),
					System.IO.Path.Combine(item, Class16.smethod_0(1649094124), string_0, Class16.smethod_0(1649093786), text3),
					System.IO.Path.Combine(string_1, text3),
					System.IO.Path.Combine(string_1, Class16.smethod_0(1649093786), string_0, text3)
				};
				for (int j = 0; j < array2.Length; j++)
				{
					if (!string.IsNullOrWhiteSpace(array2[j]) && File.Exists(array2[j]))
					{
						return array2[j];
					}
				}
			}
		}
		string text4 = method_6(text, array);
		if (!string.IsNullOrWhiteSpace(text4))
		{
			return text4;
		}
		return string.Empty;
	}

	private string method_6(string string_3, IReadOnlyList<string> ireadOnlyList_0)
	{
		if (ireadOnlyList_0 != null && ireadOnlyList_0.Count != 0)
		{
			List<string> list = new List<string>(24);
			for (int i = 0; i < ireadOnlyList_0.Count; i++)
			{
				string text = ireadOnlyList_0[i];
				if (string.IsNullOrWhiteSpace(text))
				{
					continue;
				}
				string text2 = text.Replace('/', '\\').Trim().TrimStart('\\');
				if (string.IsNullOrWhiteSpace(text2))
				{
					continue;
				}
				if (text2.StartsWith(Class16.smethod_0(1649116763), StringComparison.OrdinalIgnoreCase))
				{
					list.Add(text2);
					string text3 = text2.Substring(7);
					if (!string.IsNullOrWhiteSpace(text3))
					{
						list.Add(text3);
					}
				}
				else if (text2.StartsWith(Class16.smethod_0(1649093215), StringComparison.OrdinalIgnoreCase))
				{
					list.Add(Class16.smethod_0(1649116763) + text2);
					list.Add(text2);
				}
				else if (text2.StartsWith(Class16.smethod_0(1649093268), StringComparison.OrdinalIgnoreCase))
				{
					list.Add(Class16.smethod_0(1649116763) + text2);
					list.Add(text2);
				}
				else if (!string.IsNullOrWhiteSpace(string_0))
				{
					list.Add(Class16.smethod_0(1649093191) + string_0 + Class16.smethod_0(1648927580) + text2);
					list.Add(Class16.smethod_0(1649093215) + string_0 + Class16.smethod_0(1648927580) + text2);
					list.Add(Class16.smethod_0(1649093224) + string_0 + Class16.smethod_0(1649093298) + text2);
					list.Add(Class16.smethod_0(1649093268) + string_0 + Class16.smethod_0(1649093298) + text2);
					list.Add(Class16.smethod_0(1649093224) + string_0 + Class16.smethod_0(1648927580) + text2);
					list.Add(Class16.smethod_0(1649093268) + string_0 + Class16.smethod_0(1648927580) + text2);
				}
			}
			if (!string.IsNullOrWhiteSpace(string_0))
			{
				for (int j = 0; j < ireadOnlyList_0.Count; j++)
				{
					string text4 = ireadOnlyList_0[j];
					if (!string.IsNullOrWhiteSpace(text4))
					{
						string text5 = text4.Replace('/', '\\').Trim().TrimStart('\\');
						if (!string.IsNullOrWhiteSpace(text5))
						{
							list.Add(Class16.smethod_0(1649093224) + string_0 + Class16.smethod_0(1648927580) + text5);
							list.Add(Class16.smethod_0(1649093268) + string_0 + Class16.smethod_0(1648927580) + text5);
							list.Add(Class16.smethod_0(1649093224) + string_0 + Class16.smethod_0(1649093298) + text5);
							list.Add(Class16.smethod_0(1649093268) + string_0 + Class16.smethod_0(1649093298) + text5);
						}
					}
				}
			}
			string text6 = PwMapAssetProvider.ResolveFirstExistingPckPath(list);
			if (!string.IsNullOrWhiteSpace(text6))
			{
				return text6;
			}
			string fileName = System.IO.Path.GetFileName(string_3);
			if (string.IsNullOrWhiteSpace(fileName))
			{
				return string.Empty;
			}
			if (string.IsNullOrWhiteSpace(string_0))
			{
				return string.Empty;
			}
			string text7 = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649093786), fileName, Class16.smethod_0(1649093215) + string_0);
			if (!string.IsNullOrWhiteSpace(text7))
			{
				return text7;
			}
			text7 = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649138031), fileName, Class16.smethod_0(1649093215) + string_0);
			if (!string.IsNullOrWhiteSpace(text7))
			{
				return text7;
			}
			return PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649138031), fileName, Class16.smethod_0(1649093268) + string_0 + Class16.smethod_0(1649093243));
		}
		return string.Empty;
	}

	private static string[] smethod_2(string string_3)
	{
		if (string.IsNullOrWhiteSpace(string_3))
		{
			return Array.Empty<string>();
		}
		if (!string.IsNullOrWhiteSpace(System.IO.Path.GetExtension(string_3)))
		{
			return new string[1] { string_3 };
		}
		return new string[2]
		{
			string_3 + Class16.smethod_0(1649142694),
			string_3
		};
	}

	private IEnumerable<string> method_7(string string_3)
	{
		List<string> list = new List<string>(8);
		HashSet<string> hashSet_ = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		if (!string.IsNullOrWhiteSpace(string_3) && !string.IsNullOrWhiteSpace(string_0))
		{
			smethod_3(list, hashSet_, System.IO.Path.Combine(string_3, Class16.smethod_0(1649093786), string_0));
			smethod_3(list, hashSet_, System.IO.Path.Combine(string_3, Class16.smethod_0(1649094124), string_0, Class16.smethod_0(1649093786)));
		}
		if (!string.IsNullOrWhiteSpace(string_1) && !string.IsNullOrWhiteSpace(string_0))
		{
			smethod_3(list, hashSet_, System.IO.Path.Combine(string_1, Class16.smethod_0(1649093786), string_0));
		}
		return list;
	}

	private IEnumerable<string> method_8()
	{
		List<string> list = new List<string>(8);
		HashSet<string> hashSet_ = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		if (Directory.Exists(string_1))
		{
			smethod_3(list, hashSet_, string_1);
			DirectoryInfo directoryInfo = new DirectoryInfo(string_1);
			if (string.Equals(directoryInfo.Parent?.Name, Class16.smethod_0(1649094124), StringComparison.OrdinalIgnoreCase) && directoryInfo.Parent?.Parent != null)
			{
				smethod_3(list, hashSet_, directoryInfo.Parent.Parent.FullName);
			}
			if (directoryInfo.Parent != null)
			{
				smethod_3(list, hashSet_, directoryInfo.Parent.FullName);
			}
		}
		if (Directory.Exists(string_2))
		{
			smethod_3(list, hashSet_, string_2);
			DirectoryInfo directoryInfo2 = new DirectoryInfo(string_2);
			if (directoryInfo2.Parent != null)
			{
				smethod_3(list, hashSet_, directoryInfo2.Parent.FullName);
			}
		}
		return list;
	}

	private static void smethod_3(List<string> list_0, HashSet<string> hashSet_1, string string_3)
	{
		if (!string.IsNullOrWhiteSpace(string_3) && Directory.Exists(string_3))
		{
			string fullPath;
			try
			{
				fullPath = System.IO.Path.GetFullPath(string_3);
			}
			catch
			{
				return;
			}
			if (hashSet_1.Add(fullPath))
			{
				list_0.Add(fullPath);
			}
		}
	}

	private static void smethod_4(string string_3, string string_4, out string string_5, out string string_6)
	{
		string_5 = string.Empty;
		string_6 = string.Empty;
		if (Directory.Exists(string_3))
		{
			string text = System.IO.Path.Combine(string_3, string_4 + Class16.smethod_0(1649093324));
			string text2 = System.IO.Path.Combine(string_3, string_4 + Class16.smethod_0(1649093329));
			if (File.Exists(text))
			{
				string_5 = text;
			}
			if (File.Exists(text2))
			{
				string_6 = text2;
			}
			if (string.IsNullOrWhiteSpace(string_5))
			{
				string_5 = Directory.EnumerateFiles(string_3, Class16.smethod_0(1649093350), SearchOption.TopDirectoryOnly).FirstOrDefault() ?? string.Empty;
			}
			if (string.IsNullOrWhiteSpace(string_6))
			{
				string_6 = Directory.EnumerateFiles(string_3, Class16.smethod_0(1649093364), SearchOption.TopDirectoryOnly).FirstOrDefault() ?? string.Empty;
			}
		}
	}
}
