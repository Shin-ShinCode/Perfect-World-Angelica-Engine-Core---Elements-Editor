using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ACE.RSGlobal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ACE.Classes;

public class UniversalTranslator
{
	private sealed class Class95
	{
		private static Dictionary<int, Dictionary<int, Dictionary<string, string>>> dictionary_0;

		public static void smethod_0()
		{
			dictionary_0 = new Dictionary<int, Dictionary<int, Dictionary<string, string>>>();
		}

		public static void smethod_1(int int_0, int int_1, string string_0, string string_1)
		{
			Dictionary<string, string> dictionary = null;
			Dictionary<int, Dictionary<string, string>> value = null;
			if (!dictionary_0.TryGetValue(int_0, out value))
			{
				value = new Dictionary<int, Dictionary<string, string>>();
				dictionary_0.Add(int_0, value);
			}
			dictionary = null;
			if (!value.TryGetValue(int_1, out dictionary))
			{
				dictionary = new Dictionary<string, string>();
				value.Add(int_1, dictionary);
			}
			dictionary[string_0] = string_1;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public static bool smethod_2(int int_0, int int_1, string string_0, ref string string_1)
		{
			Dictionary<string, string> dictionary = null;
			Dictionary<int, Dictionary<string, string>> value = null;
			if (dictionary_0.TryGetValue(int_0, out value))
			{
				dictionary = null;
				if (value.TryGetValue(int_1, out dictionary))
				{
					return dictionary.TryGetValue(string_0, out string_1);
				}
			}
			return false;
		}
	}

	private static readonly HttpClient httpClient_0 = smethod_0();

	private static readonly string[] string_0 = new string[45]
	{
		Class16.smethod_0(1648897915),
		Class16.smethod_0(1648897934),
		Class16.smethod_0(1648897943),
		Class16.smethod_0(1648897944),
		Class16.smethod_0(1648897953),
		Class16.smethod_0(1648897974),
		Class16.smethod_0(1648897979),
		Class16.smethod_0(1648897996),
		Class16.smethod_0(1648898005),
		Class16.smethod_0(1648931959),
		Class16.smethod_0(1648898014),
		Class16.smethod_0(1648898023),
		Class16.smethod_0(1648898024),
		Class16.smethod_0(1648898033),
		Class16.smethod_0(1648898042),
		Class16.smethod_0(1648897027),
		Class16.smethod_0(1648897044),
		Class16.smethod_0(1648897053),
		Class16.smethod_0(1648897062),
		Class16.smethod_0(1648897064),
		Class16.smethod_0(1648932143),
		Class16.smethod_0(1648897073),
		Class16.smethod_0(1648897082),
		Class16.smethod_0(1648897091),
		Class16.smethod_0(1648897109),
		Class16.smethod_0(1648897124),
		Class16.smethod_0(1648897133),
		Class16.smethod_0(1648897142),
		Class16.smethod_0(1648907719),
		Class16.smethod_0(1648897151),
		Class16.smethod_0(1648897152),
		Class16.smethod_0(1648897161),
		Class16.smethod_0(1648897170),
		Class16.smethod_0(1648932116),
		Class16.smethod_0(1648897179),
		Class16.smethod_0(1648932072),
		Class16.smethod_0(1648897196),
		Class16.smethod_0(1648897205),
		Class16.smethod_0(1648897214),
		Class16.smethod_0(1648897223),
		Class16.smethod_0(1648897224),
		Class16.smethod_0(1648897233),
		Class16.smethod_0(1648907710),
		Class16.smethod_0(1648897242),
		Class16.smethod_0(1648932134)
	};

	private static readonly Dictionary<string, string> dictionary_0 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
	{
		{
			Class16.smethod_0(1648897915),
			Class16.smethod_0(1648897251)
		},
		{
			Class16.smethod_0(1648897934),
			Class16.smethod_0(1648897277)
		},
		{
			Class16.smethod_0(1648897943),
			Class16.smethod_0(1648897282)
		},
		{
			Class16.smethod_0(1648897944),
			Class16.smethod_0(1648897298)
		},
		{
			Class16.smethod_0(1648897953),
			Class16.smethod_0(1648897312)
		},
		{
			Class16.smethod_0(1648897974),
			Class16.smethod_0(1648897339)
		},
		{
			Class16.smethod_0(1648897979),
			Class16.smethod_0(1648897375)
		},
		{
			Class16.smethod_0(1648897996),
			Class16.smethod_0(1648897379)
		},
		{
			Class16.smethod_0(1648898005),
			Class16.smethod_0(1648897392)
		},
		{
			Class16.smethod_0(1648931959),
			Class16.smethod_0(1648899236)
		},
		{
			Class16.smethod_0(1648898014),
			Class16.smethod_0(1648897412)
		},
		{
			Class16.smethod_0(1648898023),
			Class16.smethod_0(1648897419)
		},
		{
			Class16.smethod_0(1648898024),
			Class16.smethod_0(1648897433)
		},
		{
			Class16.smethod_0(1648898033),
			Class16.smethod_0(1648897454)
		},
		{
			Class16.smethod_0(1648898042),
			Class16.smethod_0(1648897459)
		},
		{
			Class16.smethod_0(1648897027),
			Class16.smethod_0(1648897479)
		},
		{
			Class16.smethod_0(1648897044),
			Class16.smethod_0(1648897500)
		},
		{
			Class16.smethod_0(1648897053),
			Class16.smethod_0(1648897505)
		},
		{
			Class16.smethod_0(1648897062),
			Class16.smethod_0(1648897525)
		},
		{
			Class16.smethod_0(1648897064),
			Class16.smethod_0(1648896517)
		},
		{
			Class16.smethod_0(1648932143),
			Class16.smethod_0(1648896533)
		},
		{
			Class16.smethod_0(1648897073),
			Class16.smethod_0(1648896550)
		},
		{
			Class16.smethod_0(1648897082),
			Class16.smethod_0(1648896564)
		},
		{
			Class16.smethod_0(1648897091),
			Class16.smethod_0(1648896571)
		},
		{
			Class16.smethod_0(1648897109),
			Class16.smethod_0(1648896585)
		},
		{
			Class16.smethod_0(1648897124),
			Class16.smethod_0(1648896615)
		},
		{
			Class16.smethod_0(1648897133),
			Class16.smethod_0(1648896628)
		},
		{
			Class16.smethod_0(1648897142),
			Class16.smethod_0(1648896634)
		},
		{
			Class16.smethod_0(1648907719),
			Class16.smethod_0(1648896651)
		},
		{
			Class16.smethod_0(1648897151),
			Class16.smethod_0(1648896671)
		},
		{
			Class16.smethod_0(1648897152),
			Class16.smethod_0(1648896685)
		},
		{
			Class16.smethod_0(1648897161),
			Class16.smethod_0(1648896701)
		},
		{
			Class16.smethod_0(1648897170),
			Class16.smethod_0(1648896707)
		},
		{
			Class16.smethod_0(1648932116),
			Class16.smethod_0(1648896720)
		},
		{
			Class16.smethod_0(1648897179),
			Class16.smethod_0(1648896737)
		},
		{
			Class16.smethod_0(1648932072),
			Class16.smethod_0(1648896752)
		},
		{
			Class16.smethod_0(1648897196),
			Class16.smethod_0(1648896774)
		},
		{
			Class16.smethod_0(1648897205),
			Class16.smethod_0(1648896779)
		},
		{
			Class16.smethod_0(1648897214),
			Class16.smethod_0(1648896795)
		},
		{
			Class16.smethod_0(1648897223),
			Class16.smethod_0(1648896809)
		},
		{
			Class16.smethod_0(1648897224),
			Class16.smethod_0(1648896831)
		},
		{
			Class16.smethod_0(1648897233),
			Class16.smethod_0(1648896834)
		},
		{
			Class16.smethod_0(1648907710),
			Class16.smethod_0(1648896848)
		},
		{
			Class16.smethod_0(1648897242),
			Class16.smethod_0(1648896864)
		},
		{
			Class16.smethod_0(1648932134),
			Class16.smethod_0(1648896875)
		}
	};

	public static string OpenAIApiKey;

	public static string OpenAIBaseUrl;

	public static string OpenAIModel = Class16.smethod_0(1648896900);

	public static bool UseOpenAI = true;

	public static bool Initialized = false;

	public static bool OpenAIErrorShown = false;

	private static DateTime dateTime_0 = DateTime.MinValue;

	public static int cn_index;

	public static int ru_index;

	public static int en_index;

	public static int pt_index;

	public static Dictionary<string, string> CacheEN = new Dictionary<string, string>();

	public static Dictionary<string, string> CacheRU = new Dictionary<string, string>();

	public static void SwitchTranslator([MarshalAs(UnmanagedType.U1)] bool useOpenAi)
	{
		if (UseOpenAI != useOpenAi)
		{
			UseOpenAI = useOpenAi;
			Initialized = false;
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool Init()
	{
		if (Initialized)
		{
			return true;
		}
		if (!UseOpenAI)
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(smethod_1()))
		{
			return false;
		}
		try
		{
			smethod_2();
			string[] languagesCodes = GetLanguagesCodes();
			cn_index = Array.IndexOf(languagesCodes, Class16.smethod_0(1648897953));
			ru_index = Array.IndexOf(languagesCodes, Class16.smethod_0(1648932072));
			en_index = Array.IndexOf(languagesCodes, Class16.smethod_0(1648931959));
			pt_index = Array.IndexOf(languagesCodes, Class16.smethod_0(1648932116));
			Class95.smethod_0();
			OpenAIErrorShown = false;
			dateTime_0 = DateTime.MinValue;
			Initialized = true;
			return true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648896918));
			global::ACE.RSGlobal.RSGlobal.ShowHandledException(ex, Class16.smethod_0(1648896949) + ex.Message);
			return false;
		}
	}

	public static string[] GetLanguagesNames()
	{
		return GetLanguagesCodes();
	}

	public static string[] GetLanguagesCodes()
	{
		return (string[])string_0.Clone();
	}

	private static HttpClient smethod_0()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		HttpClient val = new HttpClient();
		val.Timeout = TimeSpan.FromSeconds(60.0);
		val.DefaultRequestHeaders.Accept.Clear();
		val.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Class16.smethod_0(1648896995)));
		val.DefaultRequestHeaders.UserAgent.ParseAdd(Class16.smethod_0(1648897018));
		return val;
	}

	public static string Translate(string text, int from, int to, int maxFieldChars = 0)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		if (!Initialized && !Init())
		{
			return text;
		}
		if (DateTime.UtcNow < dateTime_0)
		{
			return text;
		}
		string string_ = null;
		if (!Class95.smethod_2(from, to, text, ref string_))
		{
			try
			{
				string[] languagesCodes = GetLanguagesCodes();
				if (from < 0 || to < 0 || from >= (nint)languagesCodes.LongLength || to >= (nint)languagesCodes.LongLength)
				{
					return text;
				}
				string string_2 = languagesCodes[from];
				string string_3 = languagesCodes[to];
				string_ = smethod_9(text, string_2, string_3, maxFieldChars);
			}
			catch (Exception ex)
			{
				bool flag = ex is InvalidOperationException && ex.Message != null && ex.Message.IndexOf(Class16.smethod_0(1648896024), StringComparison.OrdinalIgnoreCase) >= 0;
				bool flag2 = ex.Message != null && (ex.Message.Contains(Class16.smethod_0(1648896046)) || ex.Message.IndexOf(Class16.smethod_0(1648896048), StringComparison.OrdinalIgnoreCase) >= 0 || ex.Message.IndexOf(Class16.smethod_0(1648896065), StringComparison.OrdinalIgnoreCase) >= 0);
				bool flag3 = ex.Message != null && (ex.Message.Contains(Class16.smethod_0(1648896085)) || ex.Message.IndexOf(Class16.smethod_0(1648896095), StringComparison.OrdinalIgnoreCase) >= 0 || ex.Message.IndexOf(Class16.smethod_0(1648896117), StringComparison.OrdinalIgnoreCase) >= 0 || ex.Message.IndexOf(Class16.smethod_0(1648896137), StringComparison.OrdinalIgnoreCase) >= 0 || ex.Message.IndexOf(Class16.smethod_0(1648896164), StringComparison.OrdinalIgnoreCase) >= 0);
				if (flag2)
				{
					dateTime_0 = DateTime.UtcNow.AddMinutes(5.0);
				}
				else if (flag3)
				{
					dateTime_0 = DateTime.UtcNow.AddMinutes(30.0);
				}
				if (!OpenAIErrorShown)
				{
					OpenAIErrorShown = true;
					if (!flag2 && !flag3 && !flag)
					{
						SentryHelper.CaptureException(ex, Class16.smethod_0(1648896178));
						global::ACE.RSGlobal.RSGlobal.ShowHandledException(ex, Class16.smethod_0(1648896222) + ex.Message);
					}
				}
				string_ = text;
			}
			if (!string.IsNullOrWhiteSpace(string_))
			{
				Class95.smethod_1(from, to, text, string_);
			}
		}
		return string_;
	}

	public static string Chinese2Russian(string text)
	{
		return Translate(text, cn_index, ru_index);
	}

	public static string Chinese2English(string text)
	{
		return Translate(text, cn_index, en_index);
	}

	public static string English2Chinese(string text)
	{
		string value = null;
		string text2;
		if (CacheEN.TryGetValue(text, out value))
		{
			text2 = value;
		}
		else
		{
			text2 = Translate(text, en_index, cn_index);
			CacheEN.Add(text, text2);
		}
		return text2;
	}

	public static string Russian2Chinese(string text)
	{
		string value = null;
		string text2;
		if (CacheRU.TryGetValue(text, out value))
		{
			text2 = value;
		}
		else
		{
			text2 = Translate(text, ru_index, cn_index);
			CacheRU.Add(text, text2);
		}
		return text2;
	}

	public static string Russian2Portuguese(string text)
	{
		return Translate(text, ru_index, pt_index);
	}

	public static string English2Portuguese(string text)
	{
		return Translate(text, en_index, pt_index);
	}

	private static string smethod_1()
	{
		if (!string.IsNullOrWhiteSpace(OpenAIApiKey))
		{
			return OpenAIApiKey.Trim();
		}
		string environmentVariable = Environment.GetEnvironmentVariable(Class16.smethod_0(1648896288));
		if (!string.IsNullOrWhiteSpace(environmentVariable))
		{
			return environmentVariable.Trim();
		}
		return null;
	}

	private static string smethod_2()
	{
		string uriString = (string.IsNullOrWhiteSpace(OpenAIBaseUrl) ? Class16.smethod_0(1648896317) : OpenAIBaseUrl.Trim());
		Uri result = null;
		if (!Uri.TryCreate(uriString, UriKind.Absolute, out result))
		{
			throw new InvalidOperationException(Class16.smethod_0(1648896349));
		}
		if (!string.Equals(result.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) && !string.Equals(result.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidOperationException(Class16.smethod_0(1648896477));
		}
		string text = result.AbsolutePath.TrimEnd('/');
		if (text.EndsWith(Class16.smethod_0(1648891393), StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidOperationException(Class16.smethod_0(1648891417));
		}
		UriBuilder uriBuilder = new UriBuilder(result);
		uriBuilder.Query = string.Empty;
		uriBuilder.Fragment = string.Empty;
		return uriBuilder.Uri.AbsoluteUri.TrimEnd('/');
	}

	private static string smethod_3()
	{
		return smethod_2() + Class16.smethod_0(1648891393);
	}

	private static string smethod_4(string string_1)
	{
		string value = null;
		if (!string.IsNullOrWhiteSpace(string_1) && dictionary_0.TryGetValue(string_1, out value))
		{
			return value;
		}
		return string_1 ?? Class16.smethod_0(1648936686);
	}

	private static string smethod_5(string string_1)
	{
		if (string.Equals(string_1, Class16.smethod_0(1648932116), StringComparison.OrdinalIgnoreCase))
		{
			return Class16.smethod_0(1648932004);
		}
		return string_1;
	}

	private static string smethod_6(string string_1)
	{
		if (string.Equals(string_1, Class16.smethod_0(1648932116), StringComparison.OrdinalIgnoreCase))
		{
			return Class16.smethod_0(1648891546);
		}
		return smethod_4(string_1);
	}

	private static string smethod_7(string string_1)
	{
		if (!string.IsNullOrWhiteSpace(string_1) && !string.Equals(string_1, Class16.smethod_0(1648897915), StringComparison.OrdinalIgnoreCase))
		{
			string text = smethod_4(string_1);
			return Class16.smethod_0(1648891601) + text + Class16.smethod_0(1648899468) + string_1 + Class16.smethod_0(1648891652);
		}
		return Class16.smethod_0(1648891580);
	}

	private static string smethod_8(int int_0)
	{
		if (int_0 > 0)
		{
			return Class16.smethod_0(1648891661) + string.Format(Class16.smethod_0(1648891284), int_0);
		}
		return Class16.smethod_0(1648891661);
	}

	private static string smethod_9(string string_1, string string_2, string string_3, int int_0)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		if (!string.IsNullOrWhiteSpace(string_1) && !string.Equals(string_2, string_3, StringComparison.OrdinalIgnoreCase))
		{
			string text = smethod_1();
			if (string.IsNullOrWhiteSpace(text))
			{
				return string_1;
			}
			string text2 = smethod_3();
			string text3 = smethod_7(string_2);
			string text4 = smethod_5(string_3);
			string text5 = smethod_6(string_3);
			string text6 = smethod_8(int_0);
			JObject val = new JObject();
			val[Class16.smethod_0(1648891370)] = (OpenAIModel);
			val[Class16.smethod_0(1648891390)] = (0.0);
			string text7 = Class16.smethod_0(1648900060);
			JArray val2 = new JArray();
			val2.Add((JToken)new JObject
			{
				[Class16.smethod_0(1648890376)] = (Class16.smethod_0(1648890387)),
				[Class16.smethod_0(1648890400)] = (text6)
			});
			JObject val3 = new JObject();
			val3[Class16.smethod_0(1648890376)] = (Class16.smethod_0(1648890422));
			val3[Class16.smethod_0(1648890400)] = (Class16.smethod_0(1648890425) + text3 + Class16.smethod_0(1648890449) + text5 + Class16.smethod_0(1648899468) + text4 + Class16.smethod_0(1648890474) + string_1);
			val2.Add((JToken)(object)val3);
			val[text7] = (JToken)(object)val2;
			JObject val4 = val;
			try
			{
				HttpRequestMessage val5 = new HttpRequestMessage(HttpMethod.Post, text2);
				try
				{
					val5.Headers.Authorization = new AuthenticationHeaderValue(Class16.smethod_0(1648890489), text);
					val5.Headers.Accept.Clear();
					val5.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(Class16.smethod_0(1648896995)));
					val5.Headers.UserAgent.ParseAdd(Class16.smethod_0(1648897018));
					val5.Content = (HttpContent)new StringContent(((JToken)val4).ToString((Formatting)0), Encoding.UTF8, Class16.smethod_0(1648896995));
					HttpResponseMessage result = httpClient_0.SendAsync(val5).GetAwaiter().GetResult();
					try
					{
						string result2 = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
						if (!result.IsSuccessStatusCode)
						{
							if (result.StatusCode == (HttpStatusCode)429)
							{
								dateTime_0 = smethod_10(result, TimeSpan.FromMinutes(5.0));
								return string_1;
							}
							if (smethod_11(result))
							{
								throw new InvalidOperationException(string.Format(Class16.smethod_0(1648890510), (int)result.StatusCode, result.ReasonPhrase));
							}
							HttpContent content = result.Content;
							object obj;
							if (content == null)
							{
								obj = null;
							}
							else
							{
								HttpContentHeaders headers = content.Headers;
								if (headers == null)
								{
									obj = null;
								}
								else
								{
									MediaTypeHeaderValue contentType = headers.ContentType;
									obj = ((contentType != null) ? contentType.MediaType : null);
								}
							}
							string text8 = (string)obj;
							if (!string.IsNullOrWhiteSpace(text8) && text8.IndexOf(Class16.smethod_0(1648890760), StringComparison.OrdinalIgnoreCase) >= 0)
							{
								throw new InvalidOperationException(string.Format(Class16.smethod_0(1648890771), (int)result.StatusCode, result.ReasonPhrase));
							}
							string string_4 = null;
							string string_5 = null;
							string string_6 = null;
							if (smethod_12(result2, ref string_4, ref string_5, ref string_6))
							{
								if (!string.Equals(string_6, Class16.smethod_0(1648889968), StringComparison.OrdinalIgnoreCase) && !string.Equals(string_5, Class16.smethod_0(1648889986), StringComparison.OrdinalIgnoreCase))
								{
									throw new InvalidOperationException(string.Format(Class16.smethod_0(1648890195), (int)result.StatusCode, result.ReasonPhrase, text2, string_4));
								}
								throw new InvalidOperationException(Class16.smethod_0(1648890021) + text2 + Class16.smethod_0(1648890054) + (string_5 ?? Class16.smethod_0(1648908791)) + Class16.smethod_0(1648890111) + (string_6 ?? Class16.smethod_0(1648908791)) + Class16.smethod_0(1648890126));
							}
							throw new InvalidOperationException(string.Format(Class16.smethod_0(1648890195), (int)result.StatusCode, result.ReasonPhrase, text2, result2));
						}
						JObject val6 = JObject.Parse(result2);
						JToken obj2 = val6[Class16.smethod_0(1648890262)];
						object obj3;
						if (obj2 == null)
						{
							obj3 = null;
						}
						else
						{
							JToken obj4 = obj2[(object)0];
							if (obj4 == null)
							{
								obj3 = null;
							}
							else
							{
								JToken obj5 = obj4[(object)Class16.smethod_0(1648894248)];
								obj3 = ((obj5 == null) ? null : ((object)obj5[(object)Class16.smethod_0(1648890400)])?.ToString());
							}
						}
						string text9 = (string)obj3;
						if (string.IsNullOrWhiteSpace(text9))
						{
							throw new InvalidOperationException(Class16.smethod_0(1648890276));
						}
						return text9.Trim();
					}
					finally
					{
						((IDisposable)result)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val5).Dispose();
				}
			}
			catch (TaskCanceledException)
			{
				return string_1;
			}
			catch (OperationCanceledException)
			{
				return string_1;
			}
		}
		return string_1;
	}

	private static DateTime smethod_10(HttpResponseMessage httpResponseMessage_0, TimeSpan timeSpan_0)
	{
		IEnumerable<string> enumerable = default(IEnumerable<string>);
		DateTime result3;
		if (((httpResponseMessage_0 != null) ? httpResponseMessage_0.Headers : null) != null && ((HttpHeaders)httpResponseMessage_0.Headers).TryGetValues(Class16.smethod_0(1648890324), out enumerable) && enumerable != null)
		{
			foreach (string item in enumerable)
			{
				if (string.IsNullOrWhiteSpace(item))
				{
					continue;
				}
				string s = item.Trim();
				if (!int.TryParse(s, out var result) || result <= 0)
				{
					if (!DateTime.TryParse(s, out var result2))
					{
						continue;
					}
					DateTime dateTime = ((result2.Kind == DateTimeKind.Utc) ? result2 : result2.ToUniversalTime());
					if (!(dateTime > DateTime.UtcNow))
					{
						continue;
					}
					result3 = dateTime;
				}
				else
				{
					result3 = DateTime.UtcNow;
					result3 = result3.AddSeconds(result);
				}
				goto IL_00bf;
			}
		}
		return DateTime.UtcNow.Add(timeSpan_0);
		IL_00bf:
		return result3;
	}

	private static bool smethod_11(HttpResponseMessage httpResponseMessage_0)
	{
		if (httpResponseMessage_0 != null && httpResponseMessage_0.StatusCode == HttpStatusCode.Forbidden)
		{
			IEnumerable<string> enumerable = null;
			if (!((HttpHeaders)httpResponseMessage_0.Headers).TryGetValues(Class16.smethod_0(1648890342), out enumerable))
			{
				return false;
			}
			foreach (string item in enumerable)
			{
				if (!string.IsNullOrWhiteSpace(item) && item.IndexOf(Class16.smethod_0(1648890353), StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	private static bool smethod_12(string string_1, ref string string_2, ref string string_3, ref string string_4)
	{
		if (string.IsNullOrWhiteSpace(string_1))
		{
			return false;
		}
		try
		{
			JObject val = JObject.Parse(string_1);
			JToken val2 = val[Class16.smethod_0(1648893441)];
			if (val2 == null)
			{
				return false;
			}
			string_2 = ((object)val2[(object)Class16.smethod_0(1648894248)])?.ToString();
			string_3 = ((object)val2[(object)Class16.smethod_0(1648893461)])?.ToString();
			string_4 = ((object)val2[(object)Class16.smethod_0(1648899906)])?.ToString();
			return !string.IsNullOrWhiteSpace(string_2) || !string.IsNullOrWhiteSpace(string_3) || !string.IsNullOrWhiteSpace(string_4);
		}
		catch
		{
			return false;
		}
	}
}
