using System.Collections.Generic;
using ACE.NpcGen;

namespace ACE.Classes.Localization;

public interface ILocalizationProvider
{
	LocaleInfo ResolveLocale(int langIndex, string legacyPrefix = null);

	LocaleInfo ResolveByCodeOrPrefix(string codeOrPrefix);

	bool TryGetLegacyMessageKey(int id, int index, out string key);

	bool TryGetLegacyMessageKeys(int id, out string[] keys);

	bool TryGetMessage(string localeCode, string key, out string value);

	FormTexts GetFormTexts(string localeCode, int langIndex, int langCount, string formName);

	Dictionary<string, string> GetProperties(string localeCode);

	bool TryGetStaskeditDictionary(string localeCode, string bucket, out Dictionary<int, string> values);

	Dictionary<string, string> GetAipolicyDictionary(string localeCode);

	void Reload();
}
