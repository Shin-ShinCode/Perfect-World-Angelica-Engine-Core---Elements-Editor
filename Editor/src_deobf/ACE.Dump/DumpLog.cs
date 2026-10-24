#nullable enable annotations
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ACE.Dump;

internal static class DumpLog
{
	[Serializable]
	private sealed class Class107
	{
		public static readonly Class107 class107_0 = new Class107();

		public static EventHandler eventHandler_0;

		internal void method_0(object sender, EventArgs e)
		{
			smethod_9();
		}
	}

	private static readonly object object_0 = new object();

	private static readonly StringComparer stringComparer_0 = (smethod_7() ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);

	private static string? string_0;

	private static string? string_1;

	private static LinkedList<string>? linkedList_0;

	private static Dictionary<string, LinkedListNode<string>>? dictionary_0;

	private static bool bool_0;

	private static HashSet<string>? hashSet_0;

	private static string? string_2;

	private static DateTime dateTime_0;

	private static DateTime dateTime_1;

	private static Dictionary<string, int>? dictionary_1;

	private static HashSet<string>? hashSet_1;

	private static int int_0;

	[Conditional("DEBUG_DUMP")]
	public static void Log(string sourceFile, string memberName, string version)
	{
		try
		{
			string text = smethod_5(sourceFile);
			string text2 = Class16.smethod_0(1648924364) + text + Class16.smethod_0(1648924347) + memberName + Class16.smethod_0(1649008377) + version;
			if (smethod_1(text, memberName, version))
			{
				return;
			}
			lock (object_0)
			{
				smethod_0();
				if (linkedList_0 == null || dictionary_0 == null || dictionary_1 == null || hashSet_1 == null)
				{
					return;
				}
				dictionary_1.TryGetValue(text2, out var value);
				value++;
				dictionary_1[text2] = value;
				LinkedListNode<string> value3;
				if (value > 15)
				{
					hashSet_1.Add(text2);
					if (dictionary_0.TryGetValue(text2, out LinkedListNode<string> value2))
					{
						linkedList_0.Remove(value2);
						dictionary_0.Remove(text2);
					}
				}
				else if (dictionary_0.TryGetValue(text2, out value3))
				{
					linkedList_0.Remove(value3);
					linkedList_0.AddLast(value3);
				}
				else
				{
					LinkedListNode<string> value4 = linkedList_0.AddLast(text2);
					dictionary_0.Add(text2, value4);
				}
				int_0++;
				if (int_0 >= 5)
				{
					int_0 = 0;
					smethod_8(bool_1: false);
				}
			}
		}
		catch
		{
		}
	}

	private static void smethod_0()
	{
		if (string_0 == null)
		{
			string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Class16.smethod_0(1649008386));
			Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path) ?? AppDomain.CurrentDomain.BaseDirectory);
			string_0 = path;
			string_1 = string.Format(Class16.smethod_0(1649008401), DateTime.Now);
			linkedList_0 = new LinkedList<string>();
			dictionary_0 = new Dictionary<string, LinkedListNode<string>>(stringComparer_0);
			dictionary_1 = new Dictionary<string, int>(stringComparer_0);
			hashSet_1 = new HashSet<string>(stringComparer_0);
			int_0 = 0;
			if (!bool_0)
			{
				AppDomain.CurrentDomain.ProcessExit += Class107.class107_0.method_0;
				bool_0 = true;
			}
			smethod_8(bool_1: false);
		}
	}

	private static bool smethod_1(string string_3, string string_4, string string_5)
	{
		HashSet<string> hashSet = smethod_2();
		if (hashSet.Count == 0)
		{
			return false;
		}
		if (!hashSet.Contains(string_3) && !hashSet.Contains(Class16.smethod_0(1648924364) + string_3 + Class16.smethod_0(1649008474)) && !hashSet.Contains(Class16.smethod_0(1648924364) + string_3 + Class16.smethod_0(1648924347) + string_4))
		{
			return hashSet.Contains(Class16.smethod_0(1648924364) + string_3 + Class16.smethod_0(1648924347) + string_4 + Class16.smethod_0(1649008377) + string_5);
		}
		return true;
	}

	private static HashSet<string> smethod_2()
	{
		lock (object_0)
		{
			DateTime utcNow = DateTime.UtcNow;
			if (hashSet_0 != null && utcNow < dateTime_1)
			{
				return hashSet_0;
			}
			dateTime_1 = utcNow.AddSeconds(1.0);
			string text = smethod_3();
			if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
			{
				DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(text);
				if (hashSet_0 != null && stringComparer_0.Equals(string_2, text) && dateTime_0 == lastWriteTimeUtc)
				{
					return hashSet_0;
				}
				HashSet<string> hashSet = new HashSet<string>(stringComparer_0);
				foreach (string item in File.ReadLines(text))
				{
					string text2 = smethod_4(item);
					if (!string.IsNullOrWhiteSpace(text2))
					{
						hashSet.Add(text2);
					}
				}
				hashSet_0 = hashSet;
				string_2 = text;
				dateTime_0 = lastWriteTimeUtc;
				return hashSet;
			}
			hashSet_0 = hashSet_0 ?? new HashSet<string>(stringComparer_0);
			hashSet_0.Clear();
			string_2 = text;
			dateTime_0 = DateTime.MinValue;
			return hashSet_0;
		}
	}

	private static string? smethod_3()
	{
		string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		string text = System.IO.Path.Combine(baseDirectory, Class16.smethod_0(1649008482));
		if (File.Exists(text))
		{
			return text;
		}
		string text2 = System.IO.Path.Combine(baseDirectory, Class16.smethod_0(1649008505), Class16.smethod_0(1649008482));
		if (File.Exists(text2))
		{
			return text2;
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(baseDirectory);
		for (int i = 0; i < 8; i++)
		{
			if (directoryInfo == null)
			{
				break;
			}
			string text3 = System.IO.Path.Combine(directoryInfo.FullName, Class16.smethod_0(1649008505), Class16.smethod_0(1649008482));
			if (!File.Exists(text3))
			{
				directoryInfo = directoryInfo.Parent;
				continue;
			}
			return text3;
		}
		return null;
	}

	private static string? smethod_4(string string_3)
	{
		if (string.IsNullOrWhiteSpace(string_3))
		{
			return null;
		}
		string text = string_3.Trim().TrimStart('\ufeff');
		int num = smethod_6(text);
		if (num == 0)
		{
			return null;
		}
		if (num > 0)
		{
			text = text.Substring(0, num).TrimEnd();
		}
		if (text.Length == 0)
		{
			return null;
		}
		if (!text.StartsWith(Class16.smethod_0(1648924364), StringComparison.Ordinal))
		{
			return smethod_5(text);
		}
		int num2 = text.IndexOf(']');
		if (num2 <= 1)
		{
			return smethod_5(text);
		}
		string text2 = smethod_5(text.Substring(1, num2 - 1).Trim());
		string text3 = text.Substring(num2 + 1).Trim();
		if (text3.Length != 0)
		{
			return Class16.smethod_0(1648924364) + text2 + Class16.smethod_0(1648924347) + text3;
		}
		return Class16.smethod_0(1648924364) + text2 + Class16.smethod_0(1649008474);
	}

	private static string smethod_5(string string_3)
	{
		return string_3.Replace('\\', '/');
	}

	private static int smethod_6(string string_3)
	{
		int num = 0;
		while (true)
		{
			if (num < string_3.Length)
			{
				if (string_3[num] == '#' && (num == 0 || char.IsWhiteSpace(string_3[num - 1])))
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	private static bool smethod_7()
	{
		PlatformID platform = Environment.OSVersion.Platform;
		if (platform != PlatformID.Win32NT && platform != PlatformID.Win32S && platform != PlatformID.Win32Windows)
		{
			return platform == PlatformID.WinCE;
		}
		return true;
	}

	private static void smethod_8(bool bool_1)
	{
		if (string.IsNullOrWhiteSpace(string_0) || string.IsNullOrWhiteSpace(string_1) || linkedList_0 == null)
		{
			return;
		}
		FileStream fileStream = new FileStream(string_0, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
		try
		{
			StreamWriter streamWriter = new StreamWriter(fileStream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
			try
			{
				streamWriter.WriteLine(string_1);
				foreach (string item in linkedList_0)
				{
					streamWriter.WriteLine(item);
				}
				if (hashSet_1 != null && hashSet_1.Count > 0 && dictionary_1 != null)
				{
					streamWriter.WriteLine();
					streamWriter.WriteLine(string.Format(Class16.smethod_0(1649008524), 15));
					foreach (string item2 in hashSet_1)
					{
						dictionary_1.TryGetValue(item2, out var value);
						streamWriter.WriteLine(string.Format(Class16.smethod_0(1649008566), item2, value));
					}
				}
				if (bool_1)
				{
					streamWriter.WriteLine(string.Format(Class16.smethod_0(1649008576), DateTime.Now));
				}
			}
			finally
			{
				((IDisposable)streamWriter).Dispose();
			}
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}

	private static void smethod_9()
	{
		lock (object_0)
		{
			if (string_0 == null)
			{
				return;
			}
			try
			{
				smethod_8(bool_1: true);
			}
			catch
			{
			}
			finally
			{
				string_0 = null;
				string_1 = null;
				linkedList_0?.Clear();
				dictionary_0?.Clear();
				dictionary_1?.Clear();
				hashSet_1?.Clear();
			}
		}
	}
}
