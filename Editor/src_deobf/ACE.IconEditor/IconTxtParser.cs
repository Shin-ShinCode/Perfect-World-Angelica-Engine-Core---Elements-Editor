using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACE.IconEditor;

public static class IconTxtParser
{
	[Serializable]
	private sealed class Class148
	{
		public static readonly Class148 class148_0 = new Class148();

		public static Func<IconEntry, int> func_0;

		public static Func<IconEntry, int> func_1;

		public static Func<IconEntry, string> func_2;

		public static Func<IconEntry, int> func_3;

		internal int method_0(IconEntry iconEntry_0)
		{
			return iconEntry_0.StartIndex;
		}

		internal int method_1(IconEntry iconEntry_0)
		{
			return iconEntry_0.StartIndex;
		}

		internal string method_2(IconEntry iconEntry_0)
		{
			return iconEntry_0.ToTxtLine();
		}

		internal int method_3(IconEntry iconEntry_0)
		{
			return iconEntry_0.StartIndex;
		}
	}

	public sealed class LoadResult
	{
		private List<IconEntry> list_0 = new List<IconEntry>();

		private bool bool_0;

		private string[] string_0 = Array.Empty<string>();

		public List<IconEntry> Entries
		{
			[CompilerGenerated]
			get
			{
				return list_0;
			}
			[CompilerGenerated]
			set
			{
				list_0 = value;
			}
		}

		public bool IsIconList
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}

		public string[] IconListHeaderLines
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}
	}

	public static LoadResult Load(string path)
	{
		if (!File.Exists(path))
		{
			return new LoadResult();
		}
		try
		{
			Encoding encoding = Encoding.GetEncoding(Class16.smethod_0(1649053565));
			string[] ienumerable_ = File.ReadAllLines(path, encoding);
			List<string> list = smethod_0(ienumerable_);
			if (smethod_1(list))
			{
				return smethod_2(list);
			}
			string[] ienumerable_2 = File.ReadAllLines(path, Encoding.Unicode);
			List<string> list2 = smethod_0(ienumerable_2);
			if (smethod_1(list2))
			{
				return smethod_2(list2);
			}
			return smethod_3((list2.Count > 0) ? list2 : list);
		}
		catch
		{
			return new LoadResult();
		}
	}

	public static bool Save(IconSheet sheet)
	{
		if (sheet != null && !string.IsNullOrWhiteSpace(sheet.TxtPath))
		{
			try
			{
				if (sheet.IsIconListFormat)
				{
					string[] array = sheet.IconListHeaderLines;
					if (array == null || array.Length < 4)
					{
						array = new string[4]
						{
							sheet.IconSize.ToString(),
							sheet.IconSize.ToString(),
							sheet.Rows.ToString(),
							sheet.Columns.ToString()
						};
					}
					List<string> list = new List<string>(array.Take(4));
					foreach (IconEntry item in sheet.Entries.OrderBy(Class148.class148_0.method_0))
					{
						int num = Math.Max(1, item.FrameCount);
						for (int i = 0; i < num; i++)
						{
							list.Add(item.Name ?? string.Empty);
						}
					}
					File.WriteAllLines(sheet.TxtPath, list, Encoding.GetEncoding(Class16.smethod_0(1649053565)));
				}
				else
				{
					List<string> contents = sheet.Entries.OrderBy(Class148.class148_0.method_1).Select(Class148.class148_0.method_2).ToList();
					File.WriteAllLines(sheet.TxtPath, contents, Encoding.Unicode);
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	private static List<string> smethod_0(IEnumerable<string> ienumerable_0)
	{
		List<string> list = new List<string>();
		foreach (string item in ienumerable_0)
		{
			if (item != null)
			{
				string text = item.Trim();
				if (text.Length != 0 && !text.StartsWith(Class16.smethod_0(1648904229), StringComparison.Ordinal) && !text.StartsWith(Class16.smethod_0(1648929947), StringComparison.Ordinal))
				{
					list.Add(text);
				}
			}
		}
		return list;
	}

	private static bool smethod_1(IReadOnlyList<string> ireadOnlyList_0)
	{
		if (ireadOnlyList_0.Count >= 4 && int.TryParse(ireadOnlyList_0[0], out var result) && int.TryParse(ireadOnlyList_0[1], out result) && int.TryParse(ireadOnlyList_0[2], out result))
		{
			return int.TryParse(ireadOnlyList_0[3], out result);
		}
		return false;
	}

	private static LoadResult smethod_2(IReadOnlyList<string> ireadOnlyList_0)
	{
		List<IconEntry> list = new List<IconEntry>();
		int num = 0;
		for (int i = 4; i < ireadOnlyList_0.Count; i++)
		{
			string text = ireadOnlyList_0[i];
			if (!string.IsNullOrWhiteSpace(text))
			{
				list.Add(new IconEntry
				{
					Name = text.Trim(),
					StartIndex = num,
					FrameCount = 1,
					Durations = new List<int> { 0 }
				});
				num++;
			}
		}
		return new LoadResult
		{
			Entries = list,
			IsIconList = true,
			IconListHeaderLines = ireadOnlyList_0.Take(4).ToArray()
		};
	}

	private static LoadResult smethod_3(IReadOnlyList<string> ireadOnlyList_0)
	{
		List<IconEntry> list = new List<IconEntry>();
		foreach (string item in ireadOnlyList_0)
		{
			if (IconEntry.TryParseLegacy(item, out var entry))
			{
				list.Add(entry);
			}
		}
		list = list.OrderBy(Class148.class148_0.method_3).ToList();
		return new LoadResult
		{
			Entries = list,
			IsIconList = false,
			IconListHeaderLines = Array.Empty<string>()
		};
	}
}
