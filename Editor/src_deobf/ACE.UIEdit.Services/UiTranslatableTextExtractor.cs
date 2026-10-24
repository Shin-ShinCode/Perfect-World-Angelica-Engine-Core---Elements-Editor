using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ACE.UIEdit.Models;

namespace ACE.UIEdit.Services;

internal static class UiTranslatableTextExtractor
{
	[Serializable]
	private sealed class Class370
	{
		public static readonly Class370 class370_0 = new Class370();

		public static Func<UiAiTranslationEntry, int> func_0;

		public static Func<UiAiTranslationEntry, bool> func_1;

		public static Func<UiAiTranslationEntry, int> func_2;

		internal int method_0(UiAiTranslationEntry uiAiTranslationEntry_0)
		{
			return uiAiTranslationEntry_0.ValueStart;
		}

		internal bool method_1(UiAiTranslationEntry uiAiTranslationEntry_0)
		{
			if (uiAiTranslationEntry_0.Selected)
			{
				return !string.IsNullOrWhiteSpace(uiAiTranslationEntry_0.TranslatedText);
			}
			return false;
		}

		internal int method_2(UiAiTranslationEntry uiAiTranslationEntry_0)
		{
			return uiAiTranslationEntry_0.ValueStart;
		}
	}

	private static readonly Regex regex_0 = new Regex(Class16.smethod_0(1649275429), RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);

	private static readonly Regex regex_1 = new Regex(Class16.smethod_0(1649275489), RegexOptions.Compiled | RegexOptions.Singleline);

	private static readonly Regex regex_2 = new Regex(Class16.smethod_0(1649275543), RegexOptions.Compiled);

	private static readonly Dictionary<string, string> dictionary_0 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
	{
		[Class16.smethod_0(1648931959)] = Class16.smethod_0(1648899236),
		[Class16.smethod_0(1648932116)] = Class16.smethod_0(1648896720),
		[Class16.smethod_0(1648932072)] = Class16.smethod_0(1648896752),
		[Class16.smethod_0(1648932081)] = Class16.smethod_0(1649275547),
		[Class16.smethod_0(1648897953)] = Class16.smethod_0(1648897312),
		[Class16.smethod_0(1648897974)] = Class16.smethod_0(1648897339),
		[Class16.smethod_0(1648897214)] = Class16.smethod_0(1648896795),
		[Class16.smethod_0(1648898024)] = Class16.smethod_0(1648897433),
		[Class16.smethod_0(1648898033)] = Class16.smethod_0(1648897454),
		[Class16.smethod_0(1648897082)] = Class16.smethod_0(1648896564),
		[Class16.smethod_0(1648897124)] = Class16.smethod_0(1648896615)
	};

	public static List<UiAiTranslationEntry> DetectEntries(string text, string filePath)
	{
		string text2 = text ?? string.Empty;
		bool flag = text2.IndexOf('<') >= 0 && text2.IndexOf('>') >= 0;
		bool flag2 = filePath.EndsWith(Class16.smethod_0(1649143702), StringComparison.OrdinalIgnoreCase);
		List<UiAiTranslationEntry> list = new List<UiAiTranslationEntry>();
		HashSet<int> hashSet_ = new HashSet<int>();
		if (flag)
		{
			foreach (Match item in regex_0.Matches(text2))
			{
				smethod_0(list, hashSet_, item, item.Groups[Class16.smethod_0(1649170453)].Value.ToUpperInvariant());
			}
		}
		if (flag2 || list.Count == 0)
		{
			foreach (Match item2 in regex_1.Matches(text2))
			{
				smethod_0(list, hashSet_, item2, Class16.smethod_0(1649275561));
			}
		}
		return list.OrderBy(Class370.class370_0.method_0).ToList();
	}

	public static string ApplyTranslations(string originalText, IReadOnlyCollection<UiAiTranslationEntry> entries)
	{
		string text = originalText ?? string.Empty;
		List<UiAiTranslationEntry> list = entries.Where(Class370.class370_0.method_1).OrderByDescending(Class370.class370_0.method_2).ToList();
		if (list.Count == 0)
		{
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder(text);
		foreach (UiAiTranslationEntry item in list)
		{
			if (item.ValueStart >= 0 && item.ValueStart + item.ValueLength <= stringBuilder.Length)
			{
				stringBuilder.Remove(item.ValueStart, item.ValueLength);
				stringBuilder.Insert(item.ValueStart, item.TranslatedText);
			}
		}
		return stringBuilder.ToString();
	}

	public static string ResolveLanguageName(string code)
	{
		if (string.IsNullOrWhiteSpace(code))
		{
			return Class16.smethod_0(1648936686);
		}
		if (!dictionary_0.TryGetValue(code, out string value))
		{
			return code;
		}
		return value;
	}

	private static void smethod_0(List<UiAiTranslationEntry> list_0, HashSet<int> hashSet_0, Match match_0, string string_0)
	{
		Group obj = match_0.Groups[Class16.smethod_0(1648905186)];
		if (obj.Success)
		{
			string value = obj.Value;
			if (!string.IsNullOrWhiteSpace(value) && regex_2.IsMatch(value) && !hashSet_0.Contains(obj.Index))
			{
				hashSet_0.Add(obj.Index);
				list_0.Add(new UiAiTranslationEntry
				{
					Kind = string_0,
					ValueStart = obj.Index,
					ValueLength = obj.Length,
					SourceText = value,
					Preview = smethod_1(match_0.Value)
				});
			}
		}
	}

	private static string smethod_1(string string_0)
	{
		if (string_0.Length <= 120)
		{
			return string_0;
		}
		return string_0.Substring(0, 117) + Class16.smethod_0(1648924410);
	}
}
