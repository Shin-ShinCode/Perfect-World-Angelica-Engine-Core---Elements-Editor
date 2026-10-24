using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.NpcGen;
using Newtonsoft.Json.Linq;
using Sentry;

namespace ACE.Classes.Localization;

public sealed class JsonLocalizationProvider : ILocalizationProvider
{
	private sealed class Class76
	{
		public int int_0;

		internal bool method_0(LocaleInfo localeInfo_0)
		{
			return localeInfo_0.Index == int_0;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	// TODO(recovered): bumped private->internal to match the ref-param method that exposes it.
	internal struct Struct47
	{
		public HashSet<string> hashSet_0;
	}

	private sealed class Class77
	{
		public int int_0;

		internal bool method_0(LocaleInfo localeInfo_0)
		{
			return localeInfo_0.Index == int_0;
		}
	}

	private sealed class Class78 : IEnumerable, IEnumerable<string>, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int int_0;

		private string string_0;

		private int int_1;

		private string string_1;

		public string string_2;

		private string string_3;

		private string string_4;

		private string string_5;

		private int int_2;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return string_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return string_0;
			}
		}

		[DebuggerHidden]
		public Class78(int int_3)
		{
			int_0 = int_3;
			int_1 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			string_3 = null;
			string_4 = null;
			string_5 = null;
			int_0 = -2;
		}

		private bool MoveNext()
		{
			switch (int_0)
			{
			default:
				return false;
			case 0:
				int_0 = -1;
				if (string.IsNullOrWhiteSpace(string_1))
				{
					return false;
				}
				string_0 = string_1;
				int_0 = 1;
				return true;
			case 1:
				int_0 = -1;
				string_3 = System.IO.Path.GetDirectoryName(string_1);
				string_4 = System.IO.Path.GetFileNameWithoutExtension(string_1);
				string_5 = System.IO.Path.GetExtension(string_1);
				if (!string.IsNullOrWhiteSpace(string_3) && !string.IsNullOrWhiteSpace(string_4) && !string.IsNullOrWhiteSpace(string_5))
				{
					int_2 = 1;
					goto IL_00bb;
				}
				return false;
			case 2:
				{
					int_0 = -1;
					goto IL_00ff;
				}
				IL_00ff:
				int_2++;
				goto IL_00bb;
				IL_00bb:
				if (int_2 <= 99)
				{
					string path = System.IO.Path.Combine(string_3, string.Format(Class16.smethod_0(1648899675), string_4, int_2, string_5));
					if (File.Exists(path))
					{
						string_0 = path;
						int_0 = 2;
						return true;
					}
					goto IL_00ff;
				}
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			Class78 @class;
			if (int_0 == -2 && int_1 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class78(0);
			}
			@class.string_1 = string_2;
			return @class;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private sealed class Class79
	{
		public string string_0;

		public Func<string, bool> func_0;

		internal bool method_0(LocaleInfo localeInfo_0)
		{
			return localeInfo_0.Code.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_1(LocaleInfo localeInfo_0)
		{
			return localeInfo_0.LegacyPrefixes.Any(method_2);
		}

		internal bool method_2(string string_1)
		{
			return string_1.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[Serializable]
	private sealed class Class80
	{
		public static readonly Class80 class80_0 = new Class80();

		public static Func<LocaleInfo, bool> func_0;

		public static Func<LocaleInfo, bool> func_1;

		public static Func<LocaleInfo, bool> func_2;

		public static Func<string, bool> func_3;

		public static Func<JToken, string> func_4;

		public static Func<string, bool> func_5;

		public static Func<string, string> func_6;

		internal bool method_0(LocaleInfo localeInfo_0)
		{
			return localeInfo_0.Code.Equals(Class16.smethod_0(1648931959), StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_1(LocaleInfo localeInfo_0)
		{
			return localeInfo_0.Code.Equals(Class16.smethod_0(1648931959), StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_2(LocaleInfo localeInfo_0)
		{
			return localeInfo_0.Code.Equals(Class16.smethod_0(1648931959), StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_3(string string_0)
		{
			return !string.IsNullOrWhiteSpace(string_0);
		}

		internal string method_4(JToken jtoken_0)
		{
			return smethod_16(((object)jtoken_0)?.ToString());
		}

		internal bool method_5(string string_0)
		{
			return !string.IsNullOrWhiteSpace(string_0);
		}

		internal string method_6(string string_0)
		{
			return string_0;
		}
	}

	private readonly object object_0 = new object();

	private readonly List<LocaleInfo> list_0 = new List<LocaleInfo>();

	private readonly Dictionary<int, List<string>> dictionary_0 = new Dictionary<int, List<string>>();

	private readonly Dictionary<string, Dictionary<string, string>> dictionary_1 = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<string, Dictionary<string, string>> dictionary_2 = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<string, Dictionary<string, string>> dictionary_3 = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<string, Dictionary<int, string>> dictionary_4 = new Dictionary<string, Dictionary<int, string>>(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<string, Dictionary<int, string>> dictionary_5 = new Dictionary<string, Dictionary<int, string>>(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<string, FormTexts> dictionary_6 = new Dictionary<string, FormTexts>(StringComparer.OrdinalIgnoreCase);

	private readonly HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private bool bool_0;

	public LocaleInfo ResolveLocale(int langIndex, string legacyPrefix = null)
	{
		Class76 @class = new Class76();
		@class.int_0 = langIndex;
		method_0();
		lock (object_0)
		{
			LocaleInfo localeInfo = list_0.FirstOrDefault(@class.method_0);
			if (localeInfo != null)
			{
				return localeInfo;
			}
			if (!string.IsNullOrWhiteSpace(legacyPrefix))
			{
				LocaleInfo localeInfo2 = ResolveByCodeOrPrefix(legacyPrefix);
				if (localeInfo2 != null)
				{
					return localeInfo2;
				}
			}
			return list_0.FirstOrDefault(Class80.class80_0.method_0) ?? Class5.smethod_0(list_0) ?? smethod_17()[1];
		}
	}

	public LocaleInfo ResolveByCodeOrPrefix(string codeOrPrefix)
	{
		Class79 @class = new Class79();
		method_0();
		@class.string_0 = smethod_16(codeOrPrefix);
		lock (object_0)
		{
			Class77 class2 = new Class77();
			if (string.IsNullOrWhiteSpace(@class.string_0))
			{
				return list_0.FirstOrDefault(Class80.class80_0.method_1) ?? Class5.smethod_0(list_0) ?? smethod_17()[1];
			}
			LocaleInfo localeInfo = list_0.FirstOrDefault(@class.method_0);
			if (localeInfo != null)
			{
				return localeInfo;
			}
			LocaleInfo localeInfo2 = list_0.FirstOrDefault(@class.method_1);
			if (localeInfo2 != null)
			{
				return localeInfo2;
			}
			if (int.TryParse(@class.string_0, out class2.int_0))
			{
				LocaleInfo localeInfo3 = list_0.FirstOrDefault(class2.method_0);
				if (localeInfo3 != null)
				{
					return localeInfo3;
				}
			}
			return list_0.FirstOrDefault(Class80.class80_0.method_2) ?? Class5.smethod_0(list_0) ?? smethod_17()[1];
		}
	}

	public bool TryGetLegacyMessageKey(int id, int index, out string key)
	{
		method_0();
		key = null;
		lock (object_0)
		{
			if (dictionary_0.TryGetValue(id, out var value) && value != null && value.Count != 0)
			{
				if (index < 0)
				{
					index = 0;
				}
				if (index >= value.Count)
				{
					index = value.Count - 1;
				}
				key = value[index];
				return !string.IsNullOrWhiteSpace(key);
			}
			return false;
		}
	}

	public bool TryGetLegacyMessageKeys(int id, out string[] keys)
	{
		method_0();
		keys = null;
		lock (object_0)
		{
			if (dictionary_0.TryGetValue(id, out var value) && value != null && value.Count != 0)
			{
				keys = value.Where(Class80.class80_0.method_3).ToArray();
				return keys.Length != 0;
			}
			return false;
		}
	}

	public bool TryGetMessage(string localeCode, string key, out string value)
	{
		method_0();
		value = null;
		if (string.IsNullOrWhiteSpace(key))
		{
			return false;
		}
		LocaleInfo localeInfo = ResolveByCodeOrPrefix(localeCode);
		try
		{
			Dictionary<string, string> dictionary = method_4(localeInfo.Code);
			if (dictionary.TryGetValue(key, out var value2) && !string.IsNullOrWhiteSpace(value2))
			{
				value = value2;
				return true;
			}
		}
		catch (Exception)
		{
		}
		string text = (string.IsNullOrWhiteSpace(localeInfo.Fallback) ? Class16.smethod_0(1648931959) : localeInfo.Fallback);
		if (!text.Equals(localeInfo.Code, StringComparison.OrdinalIgnoreCase))
		{
			try
			{
				Dictionary<string, string> dictionary2 = method_4(text);
				if (dictionary2.TryGetValue(key, out var value3) && !string.IsNullOrWhiteSpace(value3))
				{
					value = value3;
					return true;
				}
			}
			catch (Exception)
			{
			}
		}
		if (key.StartsWith(Class16.smethod_0(1648908609), StringComparison.OrdinalIgnoreCase))
		{
			value = key;
			method_12(localeInfo.Code, key);
			return true;
		}
		method_12(localeInfo.Code, key);
		return false;
	}

	public FormTexts GetFormTexts(string localeCode, int langIndex, int langCount, string formName)
	{
		method_0();
		if (string.IsNullOrWhiteSpace(formName))
		{
			return null;
		}
		LocaleInfo localeInfo = ResolveByCodeOrPrefix(localeCode);
		string key = string.Format(Class16.smethod_0(1648899703), localeInfo.Code, langIndex, langCount, formName);
		lock (object_0)
		{
			if (dictionary_6.TryGetValue(key, out var value))
			{
				return value;
			}
		}
		FormTexts formTexts = method_5(localeInfo, langIndex, langCount, formName);
		lock (object_0)
		{
			if (dictionary_6.Count >= 128) dictionary_6.Clear();
			dictionary_6[key] = formTexts;
			return formTexts;
		}
	}

	public Dictionary<string, string> GetProperties(string localeCode)
	{
		method_0();
		LocaleInfo localeInfo = ResolveByCodeOrPrefix(localeCode);
		lock (object_0)
		{
			if (dictionary_2.TryGetValue(localeInfo.Code, out var value))
			{
				return new Dictionary<string, string>(value, StringComparer.OrdinalIgnoreCase);
			}
		}
		Dictionary<string, string> dictionary = method_8(localeInfo, Class16.smethod_0(1648899725), Class16.smethod_0(1648899739));
		lock (object_0)
		{
			dictionary_2[localeInfo.Code] = dictionary;
		}
		return new Dictionary<string, string>(dictionary, StringComparer.OrdinalIgnoreCase);
	}

	public bool TryGetStaskeditDictionary(string localeCode, string bucket, out Dictionary<int, string> values)
	{
		method_0();
		values = null;
		LocaleInfo localeInfo = ResolveByCodeOrPrefix(localeCode);
		string text = (bucket ?? string.Empty).Trim().ToLowerInvariant();
		Dictionary<string, Dictionary<int, string>> dictionary = ((text == Class16.smethod_0(1648899764)) ? dictionary_5 : dictionary_4);
		lock (object_0)
		{
			if (dictionary.TryGetValue(localeInfo.Code, out var value))
			{
				values = new Dictionary<int, string>(value);
				return values.Count > 0;
			}
		}
		string path = ((text == Class16.smethod_0(1648899764)) ? Class16.smethod_0(1648899799) : Class16.smethod_0(1648899771));
		Dictionary<int, string> dictionary2 = method_10(localeInfo, System.IO.Path.Combine(Class16.smethod_0(1648899811), path), Class16.smethod_0(1648899827));
		lock (object_0)
		{
			dictionary[localeInfo.Code] = dictionary2;
		}
		values = new Dictionary<int, string>(dictionary2);
		return values.Count > 0;
	}

	public Dictionary<string, string> GetAipolicyDictionary(string localeCode)
	{
		method_0();
		LocaleInfo localeInfo = ResolveByCodeOrPrefix(localeCode);
		lock (object_0)
		{
			if (dictionary_3.TryGetValue(localeInfo.Code, out var value))
			{
				return new Dictionary<string, string>(value, StringComparer.OrdinalIgnoreCase);
			}
		}
		Dictionary<string, string> dictionary = method_8(localeInfo, Class16.smethod_0(1648899841), Class16.smethod_0(1648899827));
		lock (object_0)
		{
			dictionary_3[localeInfo.Code] = dictionary;
		}
		return new Dictionary<string, string>(dictionary, StringComparer.OrdinalIgnoreCase);
	}

	public void Reload()
	{
		lock (object_0)
		{
			bool_0 = false;
			list_0.Clear();
			dictionary_0.Clear();
			dictionary_1.Clear();
			dictionary_2.Clear();
			dictionary_3.Clear();
			dictionary_4.Clear();
			dictionary_5.Clear();
			dictionary_6.Clear();
			hashSet_0.Clear();
		}
		method_0();
	}

	private void method_0()
	{
		lock (object_0)
		{
			if (!bool_0)
			{
				method_1();
				method_2();
				bool_0 = true;
			}
		}
	}

	private void method_1()
	{
		list_0.Clear();
		string path = System.IO.Path.Combine(smethod_14(), Class16.smethod_0(1648899869));
		if (!File.Exists(path))
		{
			list_0.AddRange(smethod_17());
			return;
		}
		try
		{
			JObject val = JObject.Parse(File.ReadAllText(path, Encoding.UTF8));
			JToken obj = val[Class16.smethod_0(1648899880)];
			JArray val2 = (JArray)(object)((obj is JArray) ? obj : null);
			if (val2 != null)
			{
				foreach (JToken item in val2)
				{
					JObject val3 = (JObject)(object)((item is JObject) ? item : null);
					if (val3 == null)
					{
						continue;
					}
					LocaleInfo localeInfo = new LocaleInfo();
					localeInfo.Index = ((JToken)val3).Value<int?>((object)Class16.smethod_0(1648899902)).GetValueOrDefault();
					localeInfo.Code = smethod_16(((JToken)val3).Value<string>((object)Class16.smethod_0(1648899906))) ?? Class16.smethod_0(1648931959);
					localeInfo.DisplayName = ((JToken)val3).Value<string>((object)Class16.smethod_0(1648899925)) ?? ((JToken)val3).Value<string>((object)Class16.smethod_0(1648905100)) ?? Class16.smethod_0(1648936686);
					localeInfo.Fallback = smethod_16(((JToken)val3).Value<string>((object)Class16.smethod_0(1648899943))) ?? Class16.smethod_0(1648931959);
					JToken obj2 = val3[Class16.smethod_0(1648899958)];
					JToken obj3 = ((obj2 is JArray) ? obj2 : null);
					object obj4;
					if (obj3 == null)
					{
						obj4 = null;
					}
					else
					{
						obj4 = ((IEnumerable<JToken>)obj3).Select(Class80.class80_0.method_4).Where(Class80.class80_0.method_5).Distinct(StringComparer.OrdinalIgnoreCase)
							.ToArray();
						if (obj4 != null)
						{
							goto IL_01bb;
						}
					}
					obj4 = Array.Empty<string>();
					goto IL_01bb;
					IL_01bb:
					localeInfo.LegacyPrefixes = (string[])obj4;
					LocaleInfo localeInfo2 = localeInfo;
					if (!string.IsNullOrWhiteSpace(localeInfo2.Code))
					{
						list_0.Add(localeInfo2);
					}
				}
			}
		}
		catch
		{
			list_0.Clear();
		}
		if (list_0.Count == 0)
		{
			list_0.AddRange(smethod_17());
		}
	}

	private void method_2()
	{
		dictionary_0.Clear();
		string text = System.IO.Path.Combine(smethod_14(), Class16.smethod_0(1648899971), Class16.smethod_0(1648899986));
		if (!File.Exists(text))
		{
			return;
		}
		method_3(text);
		string directoryName = System.IO.Path.GetDirectoryName(text);
		string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(text);
		string extension = System.IO.Path.GetExtension(text);
		for (int i = 1; i <= 99; i++)
		{
			string text2 = System.IO.Path.Combine(directoryName, string.Format(Class16.smethod_0(1648899675), fileNameWithoutExtension, i, extension));
			if (File.Exists(text2))
			{
				method_3(text2);
				continue;
			}
			break;
		}
	}

	private void method_3(string string_0)
	{
		try
		{
			JObject val = JObject.Parse(File.ReadAllText(string_0, Encoding.UTF8));
			JToken obj = val[Class16.smethod_0(1648900011)];
			JObject val2 = (JObject)(((object)((obj is JObject) ? obj : null)) ?? ((object)val));
			foreach (JProperty item in val2.Properties())
			{
				if (!int.TryParse(item.Name, out var result))
				{
					continue;
				}
				List<string> list = new List<string>();
				JToken value = item.Value;
				JArray val3 = (JArray)(object)((value is JArray) ? value : null);
				if (val3 != null)
				{
					foreach (JToken item2 in val3)
					{
						string text = ((object)item2)?.ToString();
						if (!string.IsNullOrWhiteSpace(text))
						{
							list.Add(text);
						}
					}
				}
				else
				{
					string text2 = ((object)item.Value)?.ToString();
					if (!string.IsNullOrWhiteSpace(text2))
					{
						list.Add(text2);
					}
				}
				if (list.Count > 0)
				{
					dictionary_0[result] = list;
				}
			}
		}
		catch
		{
			dictionary_0.Clear();
		}
	}

	private Dictionary<string, string> method_4(string string_0)
	{
		lock (object_0)
		{
			if (dictionary_1.TryGetValue(string_0, out var value))
			{
				return value;
			}
		}
		Dictionary<string, string> dictionary = method_9(string_0, System.IO.Path.Combine(Class16.smethod_0(1648900029), Class16.smethod_0(1648900032)), Class16.smethod_0(1648900060));
		smethod_11(dictionary, method_9(string_0, Class16.smethod_0(1648900067), Class16.smethod_0(1648900060)));
		lock (object_0)
		{
			dictionary_1[string_0] = dictionary;
			return dictionary;
		}
	}

	private FormTexts method_5(LocaleInfo localeInfo_0, int int_0, int int_1, string string_0)
	{
		FormTexts formTexts = new FormTexts(string_0);
		LocaleInfo localeInfo = ResolveByCodeOrPrefix(localeInfo_0.Fallback);
		if (localeInfo != null && !localeInfo.Code.Equals(localeInfo_0.Code, StringComparison.OrdinalIgnoreCase))
		{
			method_6(formTexts, localeInfo.Code, string_0, int_0, int_1, bool_1: false);
			method_6(formTexts, localeInfo.Code, string_0, int_0, int_1, bool_1: true);
		}
		method_6(formTexts, localeInfo_0.Code, string_0, int_0, int_1, bool_1: false);
		method_6(formTexts, localeInfo_0.Code, string_0, int_0, int_1, bool_1: true);
		if (formTexts.Controls.Count == 0 && formTexts.ToolTips.Count == 0)
		{
			return null;
		}
		return formTexts;
	}

	private void method_6(FormTexts formTexts_0, string string_0, string string_1, int int_0, int int_1, bool bool_1)
	{
		string string_2 = (bool_1 ? smethod_15() : smethod_14());
		string text = smethod_0(string_2, string_0, string_1);
		if (string.IsNullOrWhiteSpace(text) || !File.Exists(text))
		{
			return;
		}
		method_7(formTexts_0, text, int_0, int_1);
		string directoryName = System.IO.Path.GetDirectoryName(text);
		string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(text);
		for (int i = 1; i <= 99; i++)
		{
			string text2 = System.IO.Path.Combine(directoryName, string.Format(Class16.smethod_0(1648900082), fileNameWithoutExtension, i));
			if (File.Exists(text2))
			{
				method_7(formTexts_0, text2, int_0, int_1);
				continue;
			}
			break;
		}
	}

	private void method_7(FormTexts formTexts_0, string string_0, int int_0, int int_1)
	{
		JObject val;
		try
		{
			val = JObject.Parse(File.ReadAllText(string_0, Encoding.UTF8));
		}
		catch
		{
			return;
		}
		JToken obj2 = val[Class16.smethod_0(1648899080)];
		JObject val2 = (JObject)(object)((obj2 is JObject) ? obj2 : null);
		if (val2 != null)
		{
			using IEnumerator<JProperty> enumerator = val2.Properties().GetEnumerator();
			JProperty current;
			object obj3;
			string string_1;
			for (; enumerator.MoveNext(); string_1 = (string)obj3, formTexts_0.Controls[current.Name] = smethod_13(string_1, int_0, int_1))
			{
				current = enumerator.Current;
				JToken value = current.Value;
				if (value == null)
				{
					obj3 = null;
				}
				else
				{
					obj3 = ((object)value).ToString();
					if (obj3 != null)
					{
						continue;
					}
				}
				obj3 = string.Empty;
			}
		}
		JToken obj4 = val[Class16.smethod_0(1648899103)];
		JObject val3 = (JObject)(object)((obj4 is JObject) ? obj4 : null);
		if (val3 == null)
		{
			return;
		}
		using IEnumerator<JProperty> enumerator2 = val3.Properties().GetEnumerator();
		JProperty current2;
		object obj5;
		string string_2;
		for (; enumerator2.MoveNext(); string_2 = (string)obj5, formTexts_0.ToolTips[current2.Name] = smethod_13(string_2, int_0, int_1))
		{
			current2 = enumerator2.Current;
			JToken value2 = current2.Value;
			if (value2 == null)
			{
				obj5 = null;
			}
			else
			{
				obj5 = ((object)value2).ToString();
				if (obj5 != null)
				{
					continue;
				}
			}
			obj5 = string.Empty;
		}
	}

	private static string smethod_0(string string_0, string string_1, string string_2)
	{
		if (!string.IsNullOrWhiteSpace(string_0) && !string.IsNullOrWhiteSpace(string_1) && !string.IsNullOrWhiteSpace(string_2))
		{
			string text = System.IO.Path.Combine(string_0, string_1, Class16.smethod_0(1648899118));
			if (!Directory.Exists(text))
			{
				return null;
			}
			string text2 = System.IO.Path.Combine(text, string_2 + Class16.smethod_0(1648899122));
			if (File.Exists(text2))
			{
				return text2;
			}
			foreach (string item in smethod_1(string_2))
			{
				string text3 = System.IO.Path.Combine(text, item + Class16.smethod_0(1648899122));
				if (File.Exists(text3))
				{
					return text3;
				}
			}
			string value = smethod_3(string_2);
			if (string.IsNullOrWhiteSpace(value))
			{
				return null;
			}
			foreach (string item2 in Directory.EnumerateFiles(text, Class16.smethod_0(1648899142), SearchOption.TopDirectoryOnly).OrderBy(Class80.class80_0.method_6, StringComparer.OrdinalIgnoreCase))
			{
				string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(item2);
				if (smethod_3(fileNameWithoutExtension).Equals(value, StringComparison.OrdinalIgnoreCase))
				{
					return item2;
				}
			}
			return null;
		}
		return null;
	}

	private static IEnumerable<string> smethod_1(string string_0)
	{
		Struct47 A_ = default(Struct47);
		A_.hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		smethod_18(smethod_2(string_0), ref A_);
		smethod_18(string_0.Replace(Class16.smethod_0(1648942211), string.Empty), ref A_);
		smethod_18(string_0.Replace(' ', '_'), ref A_);
		return A_.hashSet_0;
	}

	private static string smethod_2(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return string_0;
		}
		string input = string_0.Trim();
		input = Regex.Replace(input, Class16.smethod_0(1648899147), Class16.smethod_0(1648905543));
		return Regex.Replace(input, Class16.smethod_0(1648899178), Class16.smethod_0(1648923968));
	}

	private static string smethod_3(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(string_0.Length);
		foreach (char c in string_0)
		{
			if (char.IsLetterOrDigit(c))
			{
				stringBuilder.Append(char.ToLowerInvariant(c));
			}
		}
		return stringBuilder.ToString();
	}

	private Dictionary<string, string> method_8(LocaleInfo localeInfo_0, string string_0, string string_1)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		LocaleInfo localeInfo = ResolveByCodeOrPrefix(localeInfo_0.Fallback);
		if (localeInfo != null && !localeInfo.Code.Equals(localeInfo_0.Code, StringComparison.OrdinalIgnoreCase))
		{
			smethod_11(dictionary, method_9(localeInfo.Code, string_0, string_1));
		}
		smethod_11(dictionary, method_9(localeInfo_0.Code, string_0, string_1));
		return dictionary;
	}

	private Dictionary<string, string> method_9(string string_0, string string_1, string string_2)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		string string_3 = System.IO.Path.Combine(smethod_14(), string_0, string_1);
		string string_4 = System.IO.Path.Combine(smethod_15(), string_0, string_1);
		smethod_11(dictionary, smethod_4(string_3, string_2));
		smethod_11(dictionary, smethod_4(string_4, string_2));
		return dictionary;
	}

	private Dictionary<int, string> method_10(LocaleInfo localeInfo_0, string string_0, string string_1)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		LocaleInfo localeInfo = ResolveByCodeOrPrefix(localeInfo_0.Fallback);
		if (localeInfo != null && !localeInfo.Code.Equals(localeInfo_0.Code, StringComparison.OrdinalIgnoreCase))
		{
			smethod_12(dictionary, method_11(localeInfo.Code, string_0, string_1));
		}
		smethod_12(dictionary, method_11(localeInfo_0.Code, string_0, string_1));
		return dictionary;
	}

	private Dictionary<int, string> method_11(string string_0, string string_1, string string_2)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		string string_3 = System.IO.Path.Combine(smethod_14(), string_0, string_1);
		string string_4 = System.IO.Path.Combine(smethod_15(), string_0, string_1);
		smethod_12(dictionary, smethod_5(string_3, string_2));
		smethod_12(dictionary, smethod_5(string_4, string_2));
		return dictionary;
	}

	private static Dictionary<string, string> smethod_4(string string_0, string string_1)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		foreach (string item in smethod_6(string_0))
		{
			smethod_11(dictionary, smethod_7(item, string_1));
		}
		return dictionary;
	}

	private static Dictionary<int, string> smethod_5(string string_0, string string_1)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		foreach (string item in smethod_6(string_0))
		{
			smethod_12(dictionary, smethod_9(item, string_1));
		}
		return dictionary;
	}

	private static IEnumerable<string> smethod_6(string string_0)
	{
		return new Class78(-2)
		{
			string_2 = string_0
		};
	}

	private static Dictionary<string, string> smethod_7(string string_0, string string_1)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		smethod_8(dictionary, string_0, string_1);
		string directoryName = System.IO.Path.GetDirectoryName(string_0);
		string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(string_0);
		string extension = System.IO.Path.GetExtension(string_0);
		for (int i = 1; i <= 99; i++)
		{
			string text = System.IO.Path.Combine(directoryName, string.Format(Class16.smethod_0(1648899675), fileNameWithoutExtension, i, extension));
			if (!File.Exists(text))
			{
				break;
			}
			smethod_8(dictionary, text, string_1);
		}
		return dictionary;
	}

	private static void smethod_8(Dictionary<string, string> dictionary_7, string string_0, string string_1)
	{
		if (!File.Exists(string_0))
		{
			return;
		}
		try
		{
			JObject val = JObject.Parse(File.ReadAllText(string_0, Encoding.UTF8));
			JToken obj = val[string_1];
			JObject val2 = (JObject)(((object)((obj is JObject) ? obj : null)) ?? ((object)val));
			using IEnumerator<JProperty> enumerator = val2.Properties().GetEnumerator();
			string name;
			object obj2;
			for (; enumerator.MoveNext(); dictionary_7[name] = (string)obj2)
			{
				JProperty current = enumerator.Current;
				name = current.Name;
				JToken value = current.Value;
				if (value == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = ((object)value).ToString();
					if (obj2 != null)
					{
						continue;
					}
				}
				obj2 = string.Empty;
			}
		}
		catch
		{
		}
	}

	private static Dictionary<int, string> smethod_9(string string_0, string string_1)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		smethod_10(dictionary, string_0, string_1);
		string directoryName = System.IO.Path.GetDirectoryName(string_0);
		string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(string_0);
		string extension = System.IO.Path.GetExtension(string_0);
		for (int i = 1; i <= 99; i++)
		{
			string text = System.IO.Path.Combine(directoryName, string.Format(Class16.smethod_0(1648899675), fileNameWithoutExtension, i, extension));
			if (!File.Exists(text))
			{
				break;
			}
			smethod_10(dictionary, text, string_1);
		}
		return dictionary;
	}

	private static void smethod_10(Dictionary<int, string> dictionary_7, string string_0, string string_1)
	{
		if (!File.Exists(string_0))
		{
			return;
		}
		try
		{
			JObject val = JObject.Parse(File.ReadAllText(string_0, Encoding.UTF8));
			JToken obj = val[string_1];
			JObject val2 = (JObject)(((object)((obj is JObject) ? obj : null)) ?? ((object)val));
			foreach (JProperty item in val2.Properties())
			{
				if (!int.TryParse(item.Name, out var result))
				{
					continue;
				}
				int key = result;
				JToken value = item.Value;
				object obj2;
				if (value == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = ((object)value).ToString();
					if (obj2 != null)
					{
						goto IL_0070;
					}
				}
				obj2 = string.Empty;
				goto IL_0070;
				IL_0070:
				dictionary_7[key] = (string)obj2;
			}
		}
		catch
		{
		}
	}

	private static void smethod_11(Dictionary<string, string> dictionary_7, Dictionary<string, string> dictionary_8)
	{
		foreach (KeyValuePair<string, string> item in dictionary_8)
		{
			dictionary_7[item.Key] = item.Value;
		}
	}

	private static void smethod_12(Dictionary<int, string> dictionary_7, Dictionary<int, string> dictionary_8)
	{
		foreach (KeyValuePair<int, string> item in dictionary_8)
		{
			dictionary_7[item.Key] = item.Value;
		}
	}

	private static string[] smethod_13(string string_0, int int_0, int int_1)
	{
		int num = Math.Max(int_1, 2);
		string[] array = new string[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = string.Empty;
		}
		int num2 = int_0;
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num2 >= num)
		{
			num2 = num - 1;
		}
		array[num2] = string_0 ?? string.Empty;
		if (num > 1 && string.IsNullOrWhiteSpace(array[1]))
		{
			array[1] = string_0 ?? string.Empty;
		}
		return array;
	}

	private static string smethod_14()
	{
		return System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648899196));
	}

	private static string smethod_15()
	{
		return System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648899207), Class16.smethod_0(1648899196));
	}

	private static string smethod_16(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return string_0;
		}
		string text = string_0.Trim();
		if (int.TryParse(text, out var result))
		{
			return result switch
			{
				0 => Class16.smethod_0(1648932072), 
				1 => Class16.smethod_0(1648931959), 
				2 => Class16.smethod_0(1648931984), 
				3 => Class16.smethod_0(1648932004), 
				4 => Class16.smethod_0(1648932134), 
				5 => Class16.smethod_0(1648932143), 
				_ => text, 
			};
		}
		if (!text.Equals(Class16.smethod_0(1648932099), StringComparison.OrdinalIgnoreCase) && !text.Equals(Class16.smethod_0(1648932090), StringComparison.OrdinalIgnoreCase))
		{
			if (!text.Equals(Class16.smethod_0(1648932125), StringComparison.OrdinalIgnoreCase) && !text.Equals(Class16.smethod_0(1648932116), StringComparison.OrdinalIgnoreCase))
			{
				return text;
			}
			return Class16.smethod_0(1648932004);
		}
		return Class16.smethod_0(1648931984);
	}

	private static List<LocaleInfo> smethod_17()
	{
		List<LocaleInfo> list = new List<LocaleInfo>();
		list.Add(new LocaleInfo
		{
			Index = 0,
			Code = Class16.smethod_0(1648932072),
			DisplayName = Class16.smethod_0(1648899222),
			Fallback = Class16.smethod_0(1648931959),
			LegacyPrefixes = new string[2]
			{
				Class16.smethod_0(1648932072),
				Class16.smethod_0(1648924112)
			}
		});
		list.Add(new LocaleInfo
		{
			Index = 1,
			Code = Class16.smethod_0(1648931959),
			DisplayName = Class16.smethod_0(1648899236),
			Fallback = Class16.smethod_0(1648931959),
			LegacyPrefixes = new string[2]
			{
				Class16.smethod_0(1648931959),
				Class16.smethod_0(1648934925)
			}
		});
		list.Add(new LocaleInfo
		{
			Index = 2,
			Code = Class16.smethod_0(1648931984),
			DisplayName = Class16.smethod_0(1648899242),
			Fallback = Class16.smethod_0(1648931959),
			LegacyPrefixes = new string[4]
			{
				Class16.smethod_0(1648932099),
				Class16.smethod_0(1648932090),
				Class16.smethod_0(1648932081),
				Class16.smethod_0(1648934967)
			}
		});
		list.Add(new LocaleInfo
		{
			Index = 3,
			Code = Class16.smethod_0(1648932004),
			DisplayName = Class16.smethod_0(1648899251),
			Fallback = Class16.smethod_0(1648931959),
			LegacyPrefixes = new string[3]
			{
				Class16.smethod_0(1648932125),
				Class16.smethod_0(1648932116),
				Class16.smethod_0(1648911557)
			}
		});
		list.Add(new LocaleInfo
		{
			Index = 4,
			Code = Class16.smethod_0(1648932134),
			DisplayName = Class16.smethod_0(1648899284),
			Fallback = Class16.smethod_0(1648931959),
			LegacyPrefixes = new string[2]
			{
				Class16.smethod_0(1648932134),
				Class16.smethod_0(1648935001)
			}
		});
		list.Add(new LocaleInfo
		{
			Index = 5,
			Code = Class16.smethod_0(1648932143),
			DisplayName = Class16.smethod_0(1648899301),
			Fallback = Class16.smethod_0(1648931959),
			LegacyPrefixes = new string[2]
			{
				Class16.smethod_0(1648932143),
				Class16.smethod_0(1648911820)
			}
		});
		return list;
	}

	private void method_12(string string_0, string string_1)
	{
		if (string.IsNullOrWhiteSpace(string_0) || string.IsNullOrWhiteSpace(string_1))
		{
			return;
		}
		string item = string_0 + Class16.smethod_0(1648905535) + string_1;
		lock (object_0)
		{
			if (!hashSet_0.Add(item))
			{
				return;
			}
		}
		// TODO(recovered): this reported every missing/untranslated localization key to Sentry via
		// SentryHelper.CaptureMessage, which (with AttachStacktrace=true) captures a full stack trace
		// SYNCHRONOUSLY on the calling thread. The i18n message data isn't present in this build, so
		// loading a large file (e.g. an 88MB elements.data) produces tens of thousands of unique
		// missing "legacy.msg.*" keys, each firing an expensive capture on the UI thread -> the editor
		// appears to "load forever". Missing-translation telemetry is non-essential; the hashSet above
		// still records which keys were seen. Skip the per-key Sentry capture.
	}

	[CompilerGenerated]
	internal static void smethod_18(string name, ref Struct47 A_1)
	{
		if (!string.IsNullOrWhiteSpace(name))
		{
			A_1.hashSet_0.Add(name.Trim());
		}
	}
}
