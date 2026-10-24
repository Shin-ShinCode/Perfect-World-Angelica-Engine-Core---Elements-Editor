using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ACE.RSGlobal;

namespace ACE.Classes;

public class FIELD_LANG_REGEX_DB : IDisposable
{
	private static class Class71
	{
		public static MatchEvaluator matchEvaluator_0;
	}

	public List<string> sRegexes;

	public List<string> Translations;

	public List<Regex> RegExes;

	public static string ItemField;

	public int Count
	{
		get
		{
			int count = Translations.Count;
			GC.KeepAlive(this);
			return count;
		}
	}

	public FIELD_LANG_REGEX_DB(int count)
	{
		sRegexes = new List<string>(count);
		Translations = new List<string>(count);
		RegExes = new List<Regex>(count);
	}

	private void method_0()
	{
		sRegexes.Clear();
		Translations.Clear();
		RegExes.Clear();
		sRegexes = null;
		Translations = null;
		RegExes = null;
	}

	public void Add(string sRegex, string translated, [MarshalAs(UnmanagedType.U1)] bool bCheckExistence)
	{
		sRegex = sRegex.Replace(Class16.smethod_0(1648938114), Class16.smethod_0(1648902910));
		if (!sRegex.Contains(Class16.smethod_0(1648935659)))
		{
			string text = Class16.smethod_0(1648938114);
			sRegex = string.Concat(Class16.smethod_0(1648935659) + sRegex, text);
		}
		if (bCheckExistence)
		{
			int num = sRegexes.IndexOf(sRegex);
			if (num > -1)
			{
				Translations[num] = translated;
				GC.KeepAlive(this);
				return;
			}
		}
		Regex item = new Regex(sRegex);
		sRegexes.Add(sRegex);
		Translations.Add(translated);
		RegExes.Add(item);
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TryTranslateField(string fieldname, ref string sTranslated, int index)
	{
		if (RegExes[index].IsMatch(fieldname))
		{
			ItemField = Translations[index];
			if (!string.IsNullOrEmpty(ItemField) && ItemField[0] == '`')
			{
				List<Regex> regExes = RegExes;
				sTranslated = regExes[index].Replace(fieldname, ItemFieldIndexFunc);
			}
			else
			{
				List<Regex> regExes2 = RegExes;
				sTranslated = regExes2[index].Replace(fieldname, ItemField);
			}
		}
		bool result = sTranslated != null;
		GC.KeepAlive(this);
		return result;
	}

	public static string ItemFieldIndexFunc(Match match_0)
	{
		uint num = (uint)(global::ACE.RSGlobal.RSGlobal.UIntParseFast(match_0.Groups[2].Value) - 1);
		int num2 = (int)((num & 7) + 1);
		int num3 = (int)((num >> 3) + 1);
		string text = Class16.smethod_0(1648941518);
		return string.Concat(string.Concat(ItemField.Substring(1) + num3, text), num2.ToString());
	}

	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			method_0();
		}
	}

	public virtual void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
		GC.KeepAlive(this);
	}
}
