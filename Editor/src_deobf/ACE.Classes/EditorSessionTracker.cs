using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ACE.License;
using Sentry;

namespace ACE.Classes;

public static class EditorSessionTracker
{
	private struct Struct45
	{
		public uint uint_0;

		public uint uint_1;
	}

	private sealed class Class63
	{
		public uint uint_0;

		public string string_0;

		internal void method_0(object object_0)
		{
			try
			{
				AceNative.ACE_EditorLogFeature(uint_0, string_0);
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648903718));
			}
		}
	}

	private static class Class64
	{
		public static TimerCallback timerCallback_0;

		public static TimerCallback timerCallback_1;

		public static AceNative.BanCheckCallback banCheckCallback_0;
	}

	private sealed class Class65
	{
		public uint uint_0;

		public uint uint_1;

		public string string_0;

		internal void method_0(object object_0)
		{
			try
			{
				if (AceNative.ACE_EditorSessionStart(uint_0, uint_1, string_0 ?? Class16.smethod_0(1648908791), out var result) == AceNative.AceStatusCode.ACE_OK && result.session_id != 0)
				{
					EditorSessionTracker.uint_0 = result.session_id;
					timer_0 = new System.Threading.Timer(smethod_1, null, 300000, 300000);
					timer_1 = new System.Threading.Timer(smethod_3, null, 30000, 30000);
				}
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648903685));
			}
		}
	}

	[Serializable]
	private sealed class Class66
	{
		public static readonly Class66 class66_0 = new Class66();

		public static WaitCallback waitCallback_0;

		internal void method_0(object object_0)
		{
			smethod_4();
		}
	}

	private sealed class Class67
	{
		public string string_0;

		public Form form_0;

		internal void method_0()
		{
			MessageBox.Show(form_0, string_0, Class16.smethod_0(1648903756), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Environment.Exit(1);
		}
	}

	private readonly struct Struct46(string string_3, string string_4, uint uint_1, string string_5)
	{
		public readonly string string_0 = string_3;

		public readonly string string_1 = string_4;

		public readonly uint uint_0 = uint_1;

		public readonly string string_2 = string_5;
	}

	private static AceNative.BanCheckCallback banCheckCallback_0;

	private static volatile bool bool_0;

	private static volatile uint uint_0;

	private static volatile uint uint_1;

	private static volatile uint uint_2;

	private static System.Threading.Timer timer_0;

	private static DateTime dateTime_0;

	private static uint uint_3;

	private static readonly ConcurrentQueue<Struct46> concurrentQueue_0 = new ConcurrentQueue<Struct46>();

	private static System.Threading.Timer timer_1;

	public static bool IsActive
	{
		get
		{
			if (bool_0)
			{
				return uint_0 != 0;
			}
			return false;
		}
	}

	[DllImport("user32.dll")]
	private static extern bool GetLastInputInfo(ref Struct45 struct45_0);

	public static void Start(uint userId, uint licenseId, string editorVersion)
	{
		Class65 @class = new Class65();
		@class.uint_0 = userId;
		@class.uint_1 = licenseId;
		@class.string_0 = editorVersion;
		if (!bool_0)
		{
			uint_1 = @class.uint_0;
			uint_2 = @class.uint_1;
			dateTime_0 = DateTime.UtcNow;
			uint_3 = 0u;
			bool_0 = true;
			ThreadPool.QueueUserWorkItem(@class.method_0);
		}
	}

	public static void Stop()
	{
		if (!bool_0)
		{
			return;
		}
		bool_0 = false;
		System.Threading.Timer timer = timer_0;
		timer_0 = null;
		try
		{
			timer?.Dispose();
		}
		catch
		{
		}
		System.Threading.Timer timer2 = timer_1;
		timer_1 = null;
		try
		{
			timer2?.Dispose();
		}
		catch
		{
		}
		uint num = uint_0;
		uint num2 = uint_1;
		if (num != 0 && num2 != 0)
		{
			smethod_4();
		}
		uint_0 = 0u;
		if (num == 0)
		{
			return;
		}
		try
		{
			var (durationSec, idleSec) = smethod_6();
			AceNative.ACE_EditorSessionEnd(num, num2, durationSec, idleSec, null);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648903761));
		}
	}

	public static void LogFolderAccess(string folderPath, string accessType, string folderType = null)
	{
		if (bool_0 && uint_1 != 0)
		{
			concurrentQueue_0.Enqueue(new Struct46(folderPath, accessType ?? Class16.smethod_0(1648903793), uint_2, folderType));
			if (concurrentQueue_0.Count >= 50)
			{
				ThreadPool.QueueUserWorkItem(Class66.class66_0.method_0);
			}
		}
	}

	public static void LogFeature(string featureKey)
	{
		Class63 @class = new Class63();
		@class.string_0 = featureKey;
		if (bool_0 && uint_1 != 0)
		{
			@class.uint_0 = uint_1;
			ThreadPool.QueueUserWorkItem(@class.method_0);
		}
	}

	public static bool CheckBan(out string reason)
	{
		reason = null;
		try
		{
			if (AceNative.ACE_EditorCheckBan(out var result) == AceNative.AceStatusCode.ACE_OK && result.banned != 0)
			{
				reason = AceNative.Utf8Z(result.reason);
				return true;
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648903812));
		}
		return false;
	}

	public static void StartBanCheck()
	{
		if (banCheckCallback_0 != null)
		{
			return;
		}
		banCheckCallback_0 = smethod_0;
		try
		{
			AceNative.ACE_SetBanCheckCallback(banCheckCallback_0);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648903840));
		}
	}

	private static void smethod_0(uint uint_4, IntPtr intptr_0, IntPtr intptr_1)
	{
		Class67 @class = new Class67();
		if (uint_4 == 0)
		{
			return;
		}
		string text = ((intptr_0 != IntPtr.Zero) ? Marshal.PtrToStringAnsi(intptr_0) : string.Empty);
		string text2 = ((intptr_1 != IntPtr.Zero) ? Marshal.PtrToStringAnsi(intptr_1) : string.Empty);
		SentryHelper.LogFatal(Class16.smethod_0(1648903881) + text + Class16.smethod_0(1648903909) + text2 + Class16.smethod_0(1648942897));
		SentryHelper.Flush();
		@class.string_0 = ((!string.IsNullOrEmpty(text)) ? (Class16.smethod_0(1648903967) + text) : Class16.smethod_0(1648903927));
		if (!string.IsNullOrEmpty(text2))
		{
			@class.string_0 = @class.string_0 + Class16.smethod_0(1648904009) + text2;
		}
		try
		{
			@class.form_0 = ((Application.OpenForms.Count > 0) ? Application.OpenForms[0] : null);
			if (@class.form_0 == null || !@class.form_0.InvokeSafe(@class.method_0))
			{
				MessageBox.Show(@class.string_0, Class16.smethod_0(1648903756), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Environment.Exit(1);
			}
		}
		catch
		{
			Environment.Exit(1);
		}
	}

	private static void smethod_1(object object_0)
	{
		if (!bool_0 || uint_0 == 0)
		{
			return;
		}
		uint sessionId = uint_0;
		uint userId = uint_1;
		try
		{
			(uint, uint) tuple = smethod_6();
			uint item = tuple.Item1;
			uint item2 = tuple.Item2;
			AceNative.AceStatusCode aceStatusCode = AceNative.ACE_EditorSessionHeartbeat(sessionId, userId, item, item2);
			if (aceStatusCode == AceNative.AceStatusCode.ACE_EXPIRED)
			{
				smethod_2(Class16.smethod_0(1648904026));
				return;
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648904035));
		}
		try
		{
			if (CommonStorage.License != null && !CommonStorage.License.IsValid())
			{
				smethod_2(Class16.smethod_0(1648904074));
			}
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1648904083));
		}
	}

	private static void smethod_2(string string_0)
	{
		bool_0 = false;
		System.Threading.Timer timer = timer_0;
		timer_0 = null;
		try
		{
			timer?.Dispose();
		}
		catch
		{
		}
		System.Threading.Timer timer2 = timer_1;
		timer_1 = null;
		try
		{
			timer2?.Dispose();
		}
		catch
		{
		}
		bool num = string.Equals(string_0, Class16.smethod_0(1648904074), StringComparison.OrdinalIgnoreCase);
		SentryHelper.CaptureMessage(level: (SentryLevel)(num ? 1 : 2), message: num ? (Class16.smethod_0(1648903173) + string_0) : (Class16.smethod_0(1648904141) + string_0), context: Class16.smethod_0(1648903224));
		Environment.Exit(0);
	}

	private static void smethod_3(object object_0)
	{
		smethod_4();
	}

	private static void smethod_4()
	{
		if (concurrentQueue_0.IsEmpty)
		{
			return;
		}
		uint num = uint_1;
		uint sessionId = uint_0;
		if (num == 0)
		{
			return;
		}
		try
		{
			List<Struct46> list = new List<Struct46>(100);
			Struct46 result;
			while (list.Count < 100 && concurrentQueue_0.TryDequeue(out result))
			{
				list.Add(result);
			}
			if (list.Count == 0)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder(list.Count * 128);
			stringBuilder.Append('[');
			for (int i = 0; i < list.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				Struct46 @struct = list[i];
				stringBuilder.Append(Class16.smethod_0(1648903251));
				stringBuilder.Append(smethod_5(@struct.string_0));
				stringBuilder.Append(Class16.smethod_0(1648903274));
				stringBuilder.Append(smethod_5(@struct.string_1));
				stringBuilder.Append('"');
				if (@struct.uint_0 != 0)
				{
					stringBuilder.Append(Class16.smethod_0(1648903298));
					stringBuilder.Append(@struct.uint_0);
				}
				if (@struct.string_2 != null)
				{
					stringBuilder.Append(Class16.smethod_0(1648903327));
					stringBuilder.Append(smethod_5(@struct.string_2));
					stringBuilder.Append('"');
				}
				stringBuilder.Append('}');
			}
			stringBuilder.Append(']');
			AceNative.ACE_EditorLogFolderBatch(num, sessionId, stringBuilder.ToString());
			if (!concurrentQueue_0.IsEmpty && list.Count == 100)
			{
				smethod_4();
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648903350));
		}
	}

	private static string smethod_5(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(string_0.Length + 8);
		foreach (char c in string_0)
		{
			switch (c)
			{
			case '\\':
				stringBuilder.Append(Class16.smethod_0(1648903386));
				continue;
			case '"':
				stringBuilder.Append(Class16.smethod_0(1648903395));
				continue;
			case '\t':
				stringBuilder.Append(Class16.smethod_0(1648903421));
				continue;
			case '\n':
				stringBuilder.Append(Class16.smethod_0(1648903412));
				continue;
			case '\r':
				stringBuilder.Append(Class16.smethod_0(1648935632));
				continue;
			}
			if (c < ' ')
			{
				stringBuilder.Append(string.Format(Class16.smethod_0(1648903430), (int)c));
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	private static (uint, uint) smethod_6()
	{
		uint item = (uint)(DateTime.UtcNow - dateTime_0).TotalSeconds;
		uint num = 0u;
		try
		{
			Struct45 struct45_ = new Struct45
			{
				uint_0 = (uint)Marshal.SizeOf<Struct45>()
			};
			if (GetLastInputInfo(ref struct45_))
			{
				uint num2 = (uint)Environment.TickCount - struct45_.uint_1;
				num = num2 / 1000;
			}
		}
		catch
		{
		}
		if (num > 120)
		{
			uint_3 += num - 120;
		}
		return (item, uint_3);
	}
}
