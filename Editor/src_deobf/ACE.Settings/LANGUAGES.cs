using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sentry;

namespace ACE.Settings;

public class LANGUAGES
{
	[Serializable]
	private sealed class Class361
	{
		public static readonly Class361 class361_0 = new Class361();

		public static Comparison<LANG_INFO> comparison_0;

		internal int method_0(LANG_INFO lang_INFO_0, LANG_INFO lang_INFO_1)
		{
			return lang_INFO_0.Index.CompareTo(lang_INFO_1.Index);
		}
	}

	public LANG_INFO[] Languages;

	public int Count;

	public LANGUAGES()
	{
		Languages = Array.Empty<LANG_INFO>();
		Count = 0;
		method_0();
		if (Count <= 0)
		{
			Languages = new LANG_INFO[6]
			{
				new LANG_INFO
				{
					Index = 0,
					Prefix = Class16.smethod_0(1648932072),
					Code = Class16.smethod_0(1648932072),
					Name = Class16.smethod_0(1649156716)
				},
				new LANG_INFO
				{
					Index = 1,
					Prefix = Class16.smethod_0(1648931959),
					Code = Class16.smethod_0(1648931959),
					Name = Class16.smethod_0(1648899236)
				},
				new LANG_INFO
				{
					Index = 2,
					Prefix = Class16.smethod_0(1648932099),
					Code = Class16.smethod_0(1648931984),
					Name = Class16.smethod_0(1649156729)
				},
				new LANG_INFO
				{
					Index = 3,
					Prefix = Class16.smethod_0(1648932125),
					Code = Class16.smethod_0(1648932004),
					Name = Class16.smethod_0(1648899251)
				},
				new LANG_INFO
				{
					Index = 4,
					Prefix = Class16.smethod_0(1648932134),
					Code = Class16.smethod_0(1648932134),
					Name = Class16.smethod_0(1649156748)
				},
				new LANG_INFO
				{
					Index = 5,
					Prefix = Class16.smethod_0(1648932143),
					Code = Class16.smethod_0(1648932143),
					Name = Class16.smethod_0(1648899301)
				}
			};
			Count = Languages.Length;
		}
	}

	private void method_0()
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		string text = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648899196), Class16.smethod_0(1648899869));
		if (!File.Exists(text))
		{
			return;
		}
		try
		{
			FileInfo fileInfo = new FileInfo(text);
			if (fileInfo.Length > 0L && fileInfo.Length <= 1048576L)
			{
				using (FileStream stream = File.Open(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					StreamReader streamReader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, 4096, leaveOpen: false);
					try
					{
						JsonTextReader val = new JsonTextReader((TextReader)streamReader)
						{
							CloseInput = false,
							MaxDepth = 16
						};
						try
						{
							JObject val2 = JObject.Load((JsonReader)(object)val);
							JToken obj = val2[Class16.smethod_0(1648899880)];
							JArray val3 = (JArray)(object)((obj is JArray) ? obj : null);
							if (val3 != null && ((JContainer)val3).Count != 0)
							{
								List<LANG_INFO> list = new List<LANG_INFO>(((JContainer)val3).Count);
								foreach (JToken item in val3)
								{
									JObject val4 = (JObject)(object)((item is JObject) ? item : null);
									if (val4 != null)
									{
										int num = ((JToken)val4).Value<int?>((object)Class16.smethod_0(1648899902)) ?? list.Count;
										string text2 = smethod_1(((JToken)val4).Value<string>((object)Class16.smethod_0(1648899906)), num);
										string name = ((JToken)val4).Value<string>((object)Class16.smethod_0(1648899925)) ?? ((JToken)val4).Value<string>((object)Class16.smethod_0(1648905100)) ?? text2;
										string iconName = ((JToken)val4).Value<string>((object)Class16.smethod_0(1649156901)) ?? string.Empty;
										string prefix = smethod_0(val4, text2, num);
										list.Add(new LANG_INFO
										{
											Index = num,
											Prefix = prefix,
											Code = text2,
											Name = name,
											IconName = iconName
										});
									}
								}
								if (list.Count != 0)
								{
									list.Sort(Class361.class361_0.method_0);
									for (int i = 0; i < list.Count; i++)
									{
										list[i].Index = i;
									}
									Languages = list.ToArray();
									Count = Languages.Length;
								}
							}
							return;
						}
						finally
						{
							((IDisposable)val)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)streamReader).Dispose();
					}
				}
			}
			SentryHelper.CaptureMessage(string.Format(Class16.smethod_0(1649156775), fileInfo.Length), (SentryLevel)2, Class16.smethod_0(1649156853));
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649156916));
		}
	}

	private static string smethod_0(JObject jobject_0, string string_0, int int_0)
	{
		JToken obj = jobject_0[Class16.smethod_0(1648899958)];
		JArray val = (JArray)(object)((obj is JArray) ? obj : null);
		if (val != null)
		{
			foreach (JToken item in val)
			{
				object obj2;
				if (item == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = ((object)item).ToString();
					if (obj2 != null)
					{
						goto IL_003f;
					}
				}
				obj2 = string.Empty;
				goto IL_003f;
				IL_003f:
				string text = ((string)obj2).Trim();
				if (!string.IsNullOrWhiteSpace(text) && !int.TryParse(text, out var _))
				{
					return text.ToLowerInvariant();
				}
			}
		}
		return smethod_3(string_0, int_0);
	}

	private static string smethod_1(string string_0, int int_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return smethod_2(int_0);
		}
		return smethod_4(string_0, int_0);
	}

	private static string smethod_2(int int_0)
	{
		return int_0 switch
		{
			0 => Class16.smethod_0(1648932072), 
			1 => Class16.smethod_0(1648931959), 
			2 => Class16.smethod_0(1648931984), 
			3 => Class16.smethod_0(1648932004), 
			4 => Class16.smethod_0(1648932134), 
			5 => Class16.smethod_0(1648932143), 
			_ => Class16.smethod_0(1648931959), 
		};
	}

	private static string smethod_3(string string_0, int int_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return int_0 switch
			{
				0 => Class16.smethod_0(1648932072), 
				1 => Class16.smethod_0(1648931959), 
				2 => Class16.smethod_0(1648932099), 
				3 => Class16.smethod_0(1648932125), 
				4 => Class16.smethod_0(1648932134), 
				5 => Class16.smethod_0(1648932143), 
				_ => Class16.smethod_0(1648931959), 
			};
		}
		string text = string_0.Trim().ToLowerInvariant();
		if (!(text == Class16.smethod_0(1649156944)) && !(text == Class16.smethod_0(1648932081)))
		{
			if (!(text == Class16.smethod_0(1649156964)) && !(text == Class16.smethod_0(1648932116)))
			{
				return text;
			}
			return Class16.smethod_0(1648932125);
		}
		return Class16.smethod_0(1648932099);
	}

	private static string smethod_4(string string_0, int int_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return smethod_2(int_0);
		}
		string text = string_0.Trim().ToLowerInvariant();
		if (!(text == Class16.smethod_0(1648932099)) && !(text == Class16.smethod_0(1648932090)))
		{
			if (!(text == Class16.smethod_0(1648932125)) && !(text == Class16.smethod_0(1648932116)))
			{
				if (int.TryParse(text, out var result))
				{
					return smethod_2(result);
				}
				return text;
			}
			return Class16.smethod_0(1648932004);
		}
		return Class16.smethod_0(1648931984);
	}

	public string[] GetLanguages()
	{
		int count = Count;
		string[] array = new string[count];
		int num = 0;
		if (0 < count)
		{
			do
			{
				array[num] = Languages[num].Name;
				num++;
			}
			while (num < Count);
		}
		return array;
	}
}
