using System;
using System.Collections.Generic;
using System.IO;

namespace ACE.PWMap;

public static class PwMapFileDiscoveryService
{
	private static readonly string[] string_0 = new string[4]
	{
		Class16.smethod_0(1649093324),
		Class16.smethod_0(1649090199),
		Class16.smethod_0(1649090203),
		Class16.smethod_0(1649090223)
	};

	private static readonly string[] string_1 = new string[5]
	{
		Class16.smethod_0(1648904847),
		Class16.smethod_0(1649008311),
		Class16.smethod_0(1649008300),
		Class16.smethod_0(1649090227),
		Class16.smethod_0(1649008314)
	};

	public static PwMapFileLayout Discover(string mapRootPath, int maxTextureFiles = 250)
	{
		PwMapFileLayout pwMapFileLayout = new PwMapFileLayout();
		if (string.IsNullOrWhiteSpace(mapRootPath))
		{
			return pwMapFileLayout;
		}
		string fullPath;
		try
		{
			fullPath = System.IO.Path.GetFullPath(mapRootPath);
		}
		catch
		{
			return pwMapFileLayout;
		}
		pwMapFileLayout.MapRootPath = fullPath;
		pwMapFileLayout.MapName = new DirectoryInfo(fullPath).Name;
		if (!Directory.Exists(fullPath))
		{
			return pwMapFileLayout;
		}
		pwMapFileLayout.RegionFile = smethod_0(fullPath, Class16.smethod_0(1649090247));
		pwMapFileLayout.PrecinctFile = smethod_0(fullPath, Class16.smethod_0(1649090256));
		pwMapFileLayout.PathDataFile = smethod_0(fullPath, Class16.smethod_0(1648908925));
		pwMapFileLayout.DynamicObjectsFile = smethod_0(fullPath, Class16.smethod_0(1648997579));
		pwMapFileLayout.Domain2File = smethod_0(fullPath, Class16.smethod_0(1649011531));
		if (string.IsNullOrWhiteSpace(pwMapFileLayout.Domain2File))
		{
			pwMapFileLayout.Domain2File = smethod_0(fullPath, Class16.smethod_0(1648908885));
		}
		pwMapFileLayout.WorldFile = smethod_1(fullPath, string_0);
		pwMapFileLayout.Trn2File = smethod_1(fullPath, new string[1] { Class16.smethod_0(1649090223) });
		pwMapFileLayout.EcwldFile = smethod_1(fullPath, new string[1] { Class16.smethod_0(1649093324) });
		pwMapFileLayout.EcbsdFile = smethod_1(fullPath, new string[1] { Class16.smethod_0(1649093329) });
		pwMapFileLayout.LitmodelsFolder = smethod_3(fullPath, Class16.smethod_0(1649093786));
		pwMapFileLayout.BsdataFolder = smethod_3(fullPath, Class16.smethod_0(1649090275));
		pwMapFileLayout.TextureFiles = smethod_2(fullPath, maxTextureFiles);
		return pwMapFileLayout;
	}

	private static string smethod_0(string string_2, string string_3)
	{
		try
		{
			foreach (string item in Directory.EnumerateFiles(string_2, string_3, SearchOption.AllDirectories))
			{
				if (File.Exists(item))
				{
					return item;
				}
			}
		}
		catch
		{
		}
		return string.Empty;
	}

	private static string smethod_1(string string_2, IReadOnlyList<string> ireadOnlyList_0)
	{
		if (ireadOnlyList_0 != null && ireadOnlyList_0.Count != 0)
		{
			try
			{
				foreach (string item in Directory.EnumerateFiles(string_2, Class16.smethod_0(1648889151), SearchOption.AllDirectories))
				{
					string extension = System.IO.Path.GetExtension(item);
					if (string.IsNullOrWhiteSpace(extension))
					{
						continue;
					}
					for (int i = 0; i < ireadOnlyList_0.Count; i++)
					{
						if (string.Equals(extension, ireadOnlyList_0[i], StringComparison.OrdinalIgnoreCase))
						{
							return item;
						}
					}
				}
			}
			catch
			{
			}
			return string.Empty;
		}
		return string.Empty;
	}

	private static List<string> smethod_2(string string_2, int int_0)
	{
		List<string> list = new List<string>();
		if (int_0 <= 0)
		{
			return list;
		}
		try
		{
			foreach (string item in Directory.EnumerateFiles(string_2, Class16.smethod_0(1648889151), SearchOption.AllDirectories))
			{
				string extension = System.IO.Path.GetExtension(item);
				if (string.IsNullOrWhiteSpace(extension))
				{
					continue;
				}
				bool flag = false;
				for (int i = 0; i < string_1.Length; i++)
				{
					if (string.Equals(extension, string_1[i], StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					list.Add(item);
					if (list.Count >= int_0)
					{
						break;
					}
				}
			}
		}
		catch
		{
		}
		list.Sort(StringComparer.OrdinalIgnoreCase);
		return list;
	}

	private static string smethod_3(string string_2, string string_3)
	{
		if (!string.IsNullOrWhiteSpace(string_2) && !string.IsNullOrWhiteSpace(string_3))
		{
			try
			{
				foreach (string item in Directory.EnumerateDirectories(string_2, string_3, SearchOption.AllDirectories))
				{
					if (Directory.Exists(item))
					{
						return item;
					}
				}
			}
			catch
			{
			}
			return string.Empty;
		}
		return string.Empty;
	}
}
