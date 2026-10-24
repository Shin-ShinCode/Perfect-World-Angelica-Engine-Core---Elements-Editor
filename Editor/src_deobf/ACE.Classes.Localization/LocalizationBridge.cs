using System.Collections.Generic;
using ACE.NpcGen;

namespace ACE.Classes.Localization;

public static class LocalizationBridge
{
	private static readonly ILocalizationProvider ilocalizationProvider_0 = new JsonLocalizationProvider();

	public static ILocalizationProvider Provider => ilocalizationProvider_0;

	public static LocaleInfo ResolveLocale(int langIndex, string legacyPrefix = null)
	{
		return ilocalizationProvider_0.ResolveLocale(langIndex, legacyPrefix);
	}

	public static string ResolveLocaleCode(int langIndex, string legacyPrefix = null)
	{
		LocaleInfo localeInfo = ResolveLocale(langIndex, legacyPrefix);
		object obj;
		if (localeInfo == null)
		{
			obj = null;
		}
		else
		{
			obj = localeInfo.Code;
			if (obj != null)
			{
				goto IL_0022;
			}
		}
		obj = Class16.smethod_0(1648931959);
		goto IL_0022;
		IL_0022:
		return (string)obj;
	}

	public static string ResolveLocaleCodeFromLegacyPrefix(string prefixOrCode)
	{
		LocaleInfo localeInfo = ilocalizationProvider_0.ResolveByCodeOrPrefix(prefixOrCode);
		object obj;
		if (localeInfo == null)
		{
			obj = null;
		}
		else
		{
			obj = localeInfo.Code;
			if (obj != null)
			{
				goto IL_0026;
			}
		}
		obj = Class16.smethod_0(1648931959);
		goto IL_0026;
		IL_0026:
		return (string)obj;
	}

	public static bool TryGetLegacyMessageKey(int id, int index, out string key)
	{
		return ilocalizationProvider_0.TryGetLegacyMessageKey(id, index, out key);
	}

	public static bool TryGetLegacyMessageKeys(int id, out string[] keys)
	{
		return ilocalizationProvider_0.TryGetLegacyMessageKeys(id, out keys);
	}

	public static bool TryGetMessage(string localeCode, string key, out string value)
	{
		return ilocalizationProvider_0.TryGetMessage(localeCode, key, out value);
	}

	public static FormTexts GetFormTexts(string localeCode, int langIndex, int langCount, string formName)
	{
		return ilocalizationProvider_0.GetFormTexts(localeCode, langIndex, langCount, formName);
	}

	public static Dictionary<string, string> GetProperties(string localeCode)
	{
		return ilocalizationProvider_0.GetProperties(localeCode);
	}

	public static bool TryGetStaskeditDictionary(string localeCode, string bucket, out Dictionary<int, string> values)
	{
		return ilocalizationProvider_0.TryGetStaskeditDictionary(localeCode, bucket, out values);
	}

	public static Dictionary<string, string> GetAipolicyDictionary(string localeCode)
	{
		return ilocalizationProvider_0.GetAipolicyDictionary(localeCode);
	}

	public static void Reload()
	{
		ilocalizationProvider_0.Reload();
	}
}
