using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ACE.Classes;

public class FIELDS_TRANSLATER
{
	public Dictionary<string, string> TranslatedFields;

	public FIELD_LANG_REGEX_DB TranslatedFieldsRegEx;

	public int Count
	{
		get
		{
			int result = TranslatedFields.Count + TranslatedFieldsRegEx.Count;
			GC.KeepAlive(this);
			return result;
		}
	}

	public FIELDS_TRANSLATER()
	{
	}

	public FIELDS_TRANSLATER(int FieldCount, int RegexCount)
	{
		TranslatedFields = new Dictionary<string, string>(FieldCount);
		TranslatedFieldsRegEx = new FIELD_LANG_REGEX_DB(RegexCount);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TryGetTranslation(string field_name, ref string dest)
	{
		bool result = false;
		Dictionary<string, string> translatedFields = TranslatedFields;
		if (translatedFields != null)
		{
			result = translatedFields.TryGetValue(field_name, out dest);
		}
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TryGetTranslationRegEx(string fieldname, ref string sTranslated)
	{
		FIELD_LANG_REGEX_DB translatedFieldsRegEx = TranslatedFieldsRegEx;
		if (translatedFieldsRegEx == null)
		{
			return false;
		}
		int count = translatedFieldsRegEx.Count;
		int num = 0;
		if (0 < count)
		{
			do
			{
				if (!TranslatedFieldsRegEx.TryTranslateField(fieldname, ref sTranslated, num))
				{
					num++;
					continue;
				}
				GC.KeepAlive(this);
				return true;
			}
			while (num < count);
		}
		return false;
	}

	public void Add(string field_name, string translated, [MarshalAs(UnmanagedType.U1)] bool bCheckExistence, [MarshalAs(UnmanagedType.U1)] bool IsRegex)
	{
		if (IsRegex)
		{
			TranslatedFieldsRegEx.Add(field_name, translated, bCheckExistence);
		}
		else
		{
			bool flag = TranslatedFields.ContainsKey(field_name);
			if (bCheckExistence)
			{
				if (flag)
				{
					TranslatedFields[field_name] = translated;
					goto IL_006d;
				}
			}
			else if (flag)
			{
				string text = Class16.smethod_0(1648902829);
				throw new ApplicationException(string.Concat(Class16.smethod_0(1648902889) + field_name, text));
			}
			TranslatedFields.Add(field_name, translated);
		}
		goto IL_006d;
		IL_006d:
		GC.KeepAlive(this);
	}
}
