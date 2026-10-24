using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ACE.NpcGen.Import;

public static class CoordDataParser
{
	[Serializable]
	private sealed class Class251
	{
		public static readonly Class251 class251_0 = new Class251();

		public static Func<string, string> func_0;

		internal string method_0(string string_0)
		{
			return string_0.Trim();
		}
	}

	public static CoordDataParseResult ParseFiles(IEnumerable<string> filePaths)
	{
		CoordDataParseResult coordDataParseResult = new CoordDataParseResult();
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		if (filePaths == null)
		{
			return coordDataParseResult;
		}
		foreach (string filePath in filePaths)
		{
			string text = (filePath ?? string.Empty).Trim();
			if (text.Length == 0 || !File.Exists(text))
			{
				continue;
			}
			IReadOnlyList<string> readOnlyList = smethod_0(text);
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				if (smethod_1(readOnlyList[i], System.IO.Path.GetFileName(text), i + 1, out var coordDataSpawnEntry_))
				{
					coordDataParseResult.Entries.Add(coordDataSpawnEntry_);
					if (!string.IsNullOrWhiteSpace(coordDataSpawnEntry_.MapId) && hashSet.Add(coordDataSpawnEntry_.MapId))
					{
						coordDataParseResult.Maps.Add(coordDataSpawnEntry_.MapId);
					}
				}
				else
				{
					coordDataParseResult.IgnoredLineCount++;
				}
			}
		}
		return coordDataParseResult;
	}

	private static IReadOnlyList<string> smethod_0(string string_0)
	{
		byte[] bytes = File.ReadAllBytes(string_0);
		try
		{
			return new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true).GetString(bytes).Split(new string[2]
			{
				Class16.smethod_0(1648924428),
				Class16.smethod_0(1648941987)
			}, StringSplitOptions.None);
		}
		catch (DecoderFallbackException)
		{
			Encoding encoding = Encoding.GetEncoding(936);
			return encoding.GetString(bytes).Split(new string[2]
			{
				Class16.smethod_0(1648924428),
				Class16.smethod_0(1648941987)
			}, StringSplitOptions.None);
		}
	}

	private static bool smethod_1(string string_0, string string_1, int int_0, out CoordDataSpawnEntry coordDataSpawnEntry_0)
	{
		coordDataSpawnEntry_0 = null;
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return false;
		}
		string[] array = string_0.Split(new char[1] { '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(Class251.class251_0.method_0).ToArray();
		if (array.Length < 5)
		{
			return false;
		}
		if (int.TryParse(array[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) && result > 0)
		{
			string text = array[1].Trim();
			if (text.Length == 0)
			{
				return false;
			}
			if (float.TryParse(array[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var result2) && float.TryParse(array[3], NumberStyles.Float, CultureInfo.InvariantCulture, out var result3) && float.TryParse(array[4], NumberStyles.Float, CultureInfo.InvariantCulture, out var result4))
			{
				coordDataSpawnEntry_0 = new CoordDataSpawnEntry(result, text, result2, result3, result4, string_1, int_0);
				return true;
			}
			return false;
		}
		return false;
	}
}
