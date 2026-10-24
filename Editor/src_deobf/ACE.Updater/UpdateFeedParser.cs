using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using ACE.Classes;

namespace ACE.Updater;

internal static class UpdateFeedParser
{
	private readonly struct Struct116(Version version_1, string string_5, string string_6, string string_7, string string_8, string string_9, long long_1)
	{
		private readonly Version version_0 = version_1;

		private readonly string string_0 = string_5 ?? string.Empty;

		private readonly string string_1 = string_6 ?? string.Empty;

		private readonly string string_2 = string_7 ?? string.Empty;

		private readonly string string_3 = string_8 ?? string.Empty;

		private readonly string string_4 = string_9 ?? string.Empty;

		private readonly long long_0 = long_1;

		public Version method_0()
		{
			return version_0;
		}

		public string method_1()
		{
			return string_0;
		}

		public string method_2()
		{
			return string_1;
		}

		public string method_3()
		{
			return string_2;
		}

		public string method_4()
		{
			return string_3;
		}

		public string method_5()
		{
			return string_4;
		}

		public long method_6()
		{
			return long_0;
		}
	}

	private sealed class Class383
	{
		private readonly string string_0;

		private readonly Dictionary<string, string> dictionary_0;

		public Class383(string string_1)
		{
			string_0 = string_1 ?? string.Empty;
			dictionary_0 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_1, string string_2)
		{
			dictionary_0[string_1] = string_2 ?? string.Empty;
		}

		public string method_2(string string_1)
		{
			if (string.IsNullOrWhiteSpace(string_1))
			{
				return null;
			}
			if (!dictionary_0.TryGetValue(string_1, out var value))
			{
				return null;
			}
			return value;
		}
	}

	[Serializable]
	private sealed class Class384
	{
		public static readonly Class384 class384_0 = new Class384();

		public static Func<Struct116, Version> func_0;

		public static Func<string, bool> func_1;

		public static Func<string, bool> func_2;

		public static Func<string, bool> func_3;

		public static Func<string, bool> func_4;

		internal Version method_0(Struct116 struct116_0)
		{
			return struct116_0.method_0();
		}

		internal bool method_1(string string_0)
		{
			return string_0.Equals(Class16.smethod_0(1649271624), StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_2(string string_0)
		{
			return string_0.Equals(Class16.smethod_0(1649271635), StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_3(string string_0)
		{
			return string_0.Equals(Class16.smethod_0(1649271654), StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_4(string string_0)
		{
			return string_0.Equals(Class16.smethod_0(1649271658), StringComparison.OrdinalIgnoreCase);
		}
	}

	public static bool TryFetchLatestCompatibleUpdate(string feedUrl, out UpdateInfo update, out string error)
	{
		update = null;
		error = null;
		if (string.IsNullOrWhiteSpace(feedUrl))
		{
			error = Class16.smethod_0(1649271678);
			return false;
		}
		if (!smethod_0(feedUrl, 15000, out var string_, out error))
		{
			return false;
		}
		return TryParseLatestCompatibleUpdate(string_, out update, out error);
	}

	public static bool TryParseLatestCompatibleUpdate(string content, out UpdateInfo updateInfo_0, out string error)
	{
		updateInfo_0 = null;
		error = null;
		if (string.IsNullOrWhiteSpace(content))
		{
			error = Class16.smethod_0(1649271703);
			return false;
		}
		List<Class383> list = smethod_4(content);
		if (list.Count == 0)
		{
			error = Class16.smethod_0(1649271723);
			return false;
		}
		bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
		bool is64BitProcess = Environment.Is64BitProcess;
		List<Struct116> list2 = new List<Struct116>(list.Count);
		foreach (Class383 item in list)
		{
			Version version = smethod_2(item.method_0()) ?? smethod_2(item.method_2(Class16.smethod_0(1648942674))) ?? smethod_2(item.method_2(Class16.smethod_0(1649271755)));
			if (version == null)
			{
				continue;
			}
			string text = item.method_2(Class16.smethod_0(1649002474)) ?? string.Empty;
			if (smethod_1(text, is64BitOperatingSystem, is64BitProcess))
			{
				string string_ = item.method_2(Class16.smethod_0(1648936731)) ?? string.Empty;
				string string_2 = item.method_2(Class16.smethod_0(1649271776)) ?? item.method_2(Class16.smethod_0(1649271786)) ?? string.Empty;
				string string_3 = smethod_3(new string[4]
				{
					item.method_2(Class16.smethod_0(1648997999)),
					item.method_2(Class16.smethod_0(1649271805)),
					item.method_2(Class16.smethod_0(1649270792)),
					item.method_2(Class16.smethod_0(1649270814))
				});
				string string_4 = (item.method_2(Class16.smethod_0(1649270819)) ?? string.Empty).Trim();
				long result = 0L;
				string text2 = item.method_2(Class16.smethod_0(1648980967));
				if (!string.IsNullOrWhiteSpace(text2))
				{
					long.TryParse(text2.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
				}
				list2.Add(new Struct116(version, string_, string_2, text, string_3, string_4, result));
			}
		}
		if (list2.Count == 0)
		{
			error = Class16.smethod_0(1649270837);
			return false;
		}
		Struct116 @struct = list2.OrderByDescending(Class384.class384_0.method_0).First();
		updateInfo_0 = new UpdateInfo(@struct.method_0(), @struct.method_1(), @struct.method_2(), @struct.method_3(), @struct.method_4(), @struct.method_5(), @struct.method_6());
		return true;
	}

	private static bool smethod_0(string string_0, int int_0, out string string_1, out string string_2)
	{
		string_1 = null;
		string_2 = null;
		try
		{
			ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
		}
		catch
		{
		}
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
			httpWebRequest.Method = Class16.smethod_0(1649270872);
			httpWebRequest.Timeout = int_0;
			httpWebRequest.ReadWriteTimeout = int_0;
			httpWebRequest.UserAgent = Class16.smethod_0(1649270882);
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			using Stream stream = httpWebResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(stream ?? Stream.Null, Encoding.UTF8);
			try
			{
				string_1 = streamReader.ReadToEnd();
				return true;
			}
			finally
			{
				((IDisposable)streamReader).Dispose();
			}
		}
		catch (WebException ex)
		{
			string_2 = ex.Message;
			return false;
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649270920));
			string_2 = ex2.Message;
			return false;
		}
	}

	private static bool smethod_1(string string_0, bool bool_0, bool bool_1)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return true;
		}
		string[] source = string_0.Split(new char[4] { '|', ';', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
		bool flag = source.Any(Class384.class384_0.method_1);
		bool flag2 = source.Any(Class384.class384_0.method_2);
		bool flag3 = source.Any(Class384.class384_0.method_3);
		bool flag4 = source.Any(Class384.class384_0.method_4);
		if (flag && !bool_0)
		{
			return false;
		}
		if (flag2 && bool_0)
		{
			return false;
		}
		if (flag3 && !bool_1)
		{
			return false;
		}
		if (flag4 && bool_1)
		{
			return false;
		}
		return true;
	}

	private static Version smethod_2(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return null;
		}
		string text = string_0.Trim();
		if (Version.TryParse(text, out var result))
		{
			return result;
		}
		text = text.TrimStart('v', 'V');
		if (Version.TryParse(text, out result))
		{
			return result;
		}
		return null;
	}

	private static string smethod_3(string[] string_0)
	{
		if (string_0 == null)
		{
			return string.Empty;
		}
		int num = 0;
		string text;
		while (true)
		{
			if (num < string_0.Length)
			{
				text = string_0[num];
				if (!string.IsNullOrWhiteSpace(text))
				{
					break;
				}
				num++;
				continue;
			}
			return string.Empty;
		}
		return text.Trim();
	}

	private static List<Class383> smethod_4(string string_0)
	{
		List<Class383> list = new List<Class383>();
		Class383 @class = null;
		StringReader stringReader = new StringReader(string_0);
		try
		{
			string text;
			while ((text = stringReader.ReadLine()) != null)
			{
				text = text.Trim();
				if (text.Length == 0 || text.StartsWith(Class16.smethod_0(1648898262), StringComparison.Ordinal))
				{
					continue;
				}
				if (text.StartsWith(Class16.smethod_0(1648924364)) && text.EndsWith(Class16.smethod_0(1649008474)) && text.Length > 2)
				{
					string string_1 = text.Substring(1, text.Length - 2).Trim();
					@class = new Class383(string_1);
					list.Add(@class);
					continue;
				}
				int num = text.IndexOf('=');
				if (num > 0 && @class != null)
				{
					string text2 = text.Substring(0, num).Trim();
					string string_2 = text.Substring(num + 1).Trim();
					if (text2.Length != 0)
					{
						@class.method_1(text2, string_2);
					}
				}
			}
			return list;
		}
		finally
		{
			((IDisposable)stringReader).Dispose();
		}
	}
}
