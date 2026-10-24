using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ACE.Settings;

namespace ACE.Classes.Localization;

public static class DatabaseLocaleResolver
{
	private static readonly Dictionary<string, string[]> dictionary_0 = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
	{
		[Class16.smethod_0(1648932072)] = new string[2]
		{
			Class16.smethod_0(1648932072),
			Class16.smethod_0(1648924112)
		},
		[Class16.smethod_0(1648931959)] = new string[2]
		{
			Class16.smethod_0(1648931959),
			Class16.smethod_0(1648934925)
		},
		[Class16.smethod_0(1648931984)] = new string[5]
		{
			Class16.smethod_0(1648931984),
			Class16.smethod_0(1648932081),
			Class16.smethod_0(1648932099),
			Class16.smethod_0(1648932090),
			Class16.smethod_0(1648934967)
		},
		[Class16.smethod_0(1648932004)] = new string[4]
		{
			Class16.smethod_0(1648932004),
			Class16.smethod_0(1648932116),
			Class16.smethod_0(1648932125),
			Class16.smethod_0(1648911557)
		},
		[Class16.smethod_0(1648932134)] = new string[2]
		{
			Class16.smethod_0(1648932134),
			Class16.smethod_0(1648935001)
		},
		[Class16.smethod_0(1648932143)] = new string[2]
		{
			Class16.smethod_0(1648932143),
			Class16.smethod_0(1648911820)
		}
	};

	public static string[] GetLookupTokens(string explicitToken = null)
	{
		List<string> list = new List<string>(16);
		HashSet<string> hashSet_ = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		smethod_2(list, hashSet_, explicitToken);
		LANG_INFO currentLang = LANG_INFO.CurrentLang;
		if (currentLang != null)
		{
			smethod_2(list, hashSet_, currentLang.Prefix);
			smethod_2(list, hashSet_, currentLang.Code);
			if (currentLang.Index >= 0)
			{
				smethod_2(list, hashSet_, currentLang.Index.ToString(CultureInfo.InvariantCulture));
			}
		}
		smethod_0(list, hashSet_, explicitToken);
		if (currentLang != null)
		{
			smethod_0(list, hashSet_, currentLang.Prefix);
			smethod_0(list, hashSet_, currentLang.Code);
			if (currentLang.Index >= 0)
			{
				smethod_0(list, hashSet_, currentLang.Index.ToString(CultureInfo.InvariantCulture));
			}
		}
		smethod_1(list, hashSet_, Class16.smethod_0(1648931959));
		smethod_2(list, hashSet_, Class16.smethod_0(1648934925));
		return list.ToArray();
	}

	public static bool TryFindFirstExistingByToken(Func<string, string> buildPath, out string existingPath, out string usedToken, string explicitToken = null)
	{
		existingPath = null;
		usedToken = null;
		if (buildPath == null)
		{
			return false;
		}
		string[] lookupTokens = GetLookupTokens(explicitToken);
		int num = 0;
		string text;
		string text2;
		while (true)
		{
			if (num < lookupTokens.Length)
			{
				text = lookupTokens[num];
				text2 = buildPath(text);
				if (!string.IsNullOrWhiteSpace(text2) && File.Exists(text2))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		existingPath = text2;
		usedToken = text;
		return true;
	}

	public static bool TryFindFirstExistingPath(IEnumerable<string> candidatePaths, out string existingPath)
	{
		existingPath = null;
		if (candidatePaths == null)
		{
			return false;
		}
		foreach (string candidatePath in candidatePaths)
		{
			if (!string.IsNullOrWhiteSpace(candidatePath) && File.Exists(candidatePath))
			{
				existingPath = candidatePath;
				return true;
			}
		}
		return false;
	}

	private static void smethod_0(List<string> list_0, HashSet<string> hashSet_0, string string_0)
	{
		if (!string.IsNullOrWhiteSpace(string_0))
		{
			string string_1 = LocalizationBridge.ResolveLocaleCodeFromLegacyPrefix(string_0);
			smethod_1(list_0, hashSet_0, string_1);
		}
	}

	private static void smethod_1(List<string> list_0, HashSet<string> hashSet_0, string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return;
		}
		if (dictionary_0.TryGetValue(string_0, out var value) && value != null)
		{
			for (int i = 0; i < value.Length; i++)
			{
				smethod_2(list_0, hashSet_0, value[i]);
			}
		}
		else
		{
			smethod_2(list_0, hashSet_0, string_0);
		}
	}

	private static void smethod_2(List<string> list_0, HashSet<string> hashSet_0, string string_0)
	{
		if (!string.IsNullOrWhiteSpace(string_0))
		{
			string text = string_0.Trim();
			if (text.Length != 0 && hashSet_0.Add(text))
			{
				list_0.Add(text);
			}
		}
	}
}
