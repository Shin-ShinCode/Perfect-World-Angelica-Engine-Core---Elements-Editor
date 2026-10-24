using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ACE.NpcGen.Import;

public static class CoordDataImportLogic
{
	private sealed class Class249
	{
		public string string_0;

		internal bool method_0(CoordDataSpawnEntry coordDataSpawnEntry_0)
		{
			return string.Equals(coordDataSpawnEntry_0.MapId, string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[Serializable]
	private sealed class Class250
	{
		public static readonly Class250 class250_0 = new Class250();

		public static Func<string, bool> func_0;

		public static Func<string, string> func_1;

		public static Func<string, int> func_2;

		public static Func<string, int> func_3;

		public static Func<string, string> func_4;

		public static Func<string, bool> func_5;

		public static Func<string, string> func_6;

		public static Func<string, int> func_7;

		public static Func<string, int> func_8;

		public static Func<string, string> func_9;

		public static Func<string, string> func_10;

		internal bool method_0(string string_0)
		{
			return !string.IsNullOrWhiteSpace(string_0);
		}

		internal string method_1(string string_0)
		{
			return string_0.Trim();
		}

		internal int method_2(string string_0)
		{
			return smethod_1(string_0);
		}

		internal int method_3(string string_0)
		{
			return smethod_2(string_0);
		}

		internal string method_4(string string_0)
		{
			return string_0;
		}

		internal bool method_5(string string_0)
		{
			return !string.IsNullOrWhiteSpace(string_0);
		}

		internal string method_6(string string_0)
		{
			return string_0.Trim();
		}

		internal int method_7(string string_0)
		{
			return smethod_1(smethod_4(string_0));
		}

		internal int method_8(string string_0)
		{
			return smethod_2(smethod_4(string_0));
		}

		internal string method_9(string string_0)
		{
			return smethod_4(string_0) ?? string.Empty;
		}

		internal string method_10(string string_0)
		{
			return string_0;
		}
	}

	public static List<CoordDataSpawnEntry> FilterEntriesByMap(IEnumerable<CoordDataSpawnEntry> entries, string mapId)
	{
		Class249 @class = new Class249();
		@class.string_0 = mapId;
		if (entries != null && !string.IsNullOrWhiteSpace(@class.string_0))
		{
			return entries.Where(@class.method_0).ToList();
		}
		return new List<CoordDataSpawnEntry>();
	}

	public static IEnumerable<string> SortMapIds(IEnumerable<string> mapIds)
	{
		if (mapIds == null)
		{
			return Array.Empty<string>();
		}
		return mapIds.Where(Class250.class250_0.method_0).Select(Class250.class250_0.method_1).Distinct(StringComparer.OrdinalIgnoreCase)
			.OrderBy(Class250.class250_0.method_2)
			.ThenBy(Class250.class250_0.method_3)
			.ThenBy(Class250.class250_0.method_4, StringComparer.OrdinalIgnoreCase)
			.ToArray();
	}

	public static IEnumerable<string> SortNpcgenPresetPaths(IEnumerable<string> presetPaths)
	{
		if (presetPaths == null)
		{
			return Array.Empty<string>();
		}
		return presetPaths.Where(Class250.class250_0.method_5).Select(Class250.class250_0.method_6).OrderBy(Class250.class250_0.method_7)
			.ThenBy(Class250.class250_0.method_8)
			.ThenBy(Class250.class250_0.method_9, StringComparer.OrdinalIgnoreCase)
			.ThenBy(Class250.class250_0.method_10, StringComparer.OrdinalIgnoreCase)
			.ToArray();
	}

	public static string ResolveCurrentMap(string npcgenFilePath, IEnumerable<string> availableMaps, string selectedMap)
	{
		Dictionary<string, string> dictionary = smethod_0(availableMaps);
		if (dictionary.Count == 0)
		{
			return null;
		}
		if (!string.IsNullOrWhiteSpace(npcgenFilePath))
		{
			string[] array = npcgenFilePath.Split(new char[6] { '\\', '/', '.', '-', '_', ' ' }, StringSplitOptions.RemoveEmptyEntries);
			string[] array2 = array;
			foreach (string key in array2)
			{
				if (dictionary.TryGetValue(key, out var value))
				{
					return value;
				}
			}
		}
		if (!string.IsNullOrWhiteSpace(selectedMap) && dictionary.TryGetValue(selectedMap, out var value2))
		{
			return value2;
		}
		if (dictionary.Count != 1)
		{
			return null;
		}
		return dictionary.Values.First();
	}

	public static bool IsDuplicate(CoordDataSpawnEntry importedEntry, IEnumerable<CoordDataSpatialEntry> existingEntries, bool considerNearCoordinates, float nearDistance)
	{
		if (importedEntry != null && existingEntries != null)
		{
			float num = (considerNearCoordinates ? Math.Max(nearDistance, 0.01f) : 0.01f);
			float num2 = num * num;
			foreach (CoordDataSpatialEntry existingEntry in existingEntries)
			{
				if (existingEntry != null && existingEntry.Id == importedEntry.Id)
				{
					float num3 = existingEntry.Single_0 - importedEntry.Single_0;
					float num4 = existingEntry.Single_1 - importedEntry.Single_1;
					float num5 = existingEntry.Single_2 - importedEntry.Single_2;
					float num6 = num3 * num3 + num4 * num4 + num5 * num5;
					if (!(num6 > num2))
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	private static Dictionary<string, string> smethod_0(IEnumerable<string> ienumerable_0)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		if (ienumerable_0 == null)
		{
			return dictionary;
		}
		foreach (string item in ienumerable_0)
		{
			string text = (item ?? string.Empty).Trim();
			if (text.Length != 0 && !dictionary.ContainsKey(text))
			{
				dictionary.Add(text, text);
			}
		}
		return dictionary;
	}

	private static int smethod_1(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return 3;
		}
		if (string.Equals(string_0, Class16.smethod_0(1649081476), StringComparison.OrdinalIgnoreCase))
		{
			return 0;
		}
		if (!smethod_3(string_0, out var _))
		{
			return 2;
		}
		return 1;
	}

	private static int smethod_2(string string_0)
	{
		if (!smethod_3(string_0, out var int_))
		{
			return int.MaxValue;
		}
		return int_;
	}

	private static bool smethod_3(string string_0, out int int_0)
	{
		int_0 = 0;
		if (!string.IsNullOrWhiteSpace(string_0) && string_0.Length >= 2 && char.ToLowerInvariant(string_0[0]) == 'a')
		{
			return int.TryParse(string_0.Substring(1), NumberStyles.Integer, CultureInfo.InvariantCulture, out int_0);
		}
		return false;
	}

	private static string smethod_4(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return null;
		}
		string[] array = string_0.Split(new char[2] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);
		int num = array.Length - 1;
		string text;
		while (true)
		{
			if (num >= 0)
			{
				text = array[num].Trim();
				if (text.Length != 0 && (string.Equals(text, Class16.smethod_0(1649081476), StringComparison.OrdinalIgnoreCase) || smethod_3(text, out var _)))
				{
					break;
				}
				num--;
				continue;
			}
			return null;
		}
		return text;
	}
}
