#nullable enable annotations
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Domain2;
using ACE.Elements;
using ACE.Elements.eListCollection;
using ACE.License;
using ACE.MainWindow;
using ACE.Models;
using ACE.RSGlobal;
using Sentry;

namespace ACE;

internal static class Program
{
	private enum Enum22
	{

	}

	[Serializable]
	private sealed class Class353
	{
		public static readonly Class353 class353_0 = new Class353();

		public static EventHandler eventHandler_0;

		public static EventHandler eventHandler_1;

		internal void method_0(object sender, EventArgs e)
		{
			AceSecurity.Shutdown();
		}

		internal void method_1(object sender, EventArgs e)
		{
			EditorSessionTracker.Stop();
		}
	}

	public static AceNative.LogCallbackW? _logCallback;

	private static Form form_0;

	[HandleProcessCorruptedStateExceptions]
	[SecurityCritical]
	private static void smethod_0()
	{
	}

	[STAThread]
	private static void Main(string[] args)
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
		using (SentryHelper.Init())
		{
			ExceptionReporter.Initialize();
			ACE.RSGlobal.RSGlobal.InitVariables();
			Version version = Assembly.GetExecutingAssembly().GetName().Version;
			string text = string.Format(Class16.smethod_0(1648902691), version?.Major ?? 0, version?.Minor ?? 0, version?.Build ?? 0);
			CommonStorage cStorage = (InputWindow.CStorage = new CommonStorage(args));
			smethod_3(text);
			SentryHelper.SetTag(Class16.smethod_0(1649186388), "True");
			Application.ThreadException += smethod_1;
			AppDomain.CurrentDomain.UnhandledException += smethod_2;
			ACE.RSGlobal.RSGlobal.RegisterApplicationRestart(smethod_13(), 0);
			if (CommonStorage.CmdFlags.Domain2 && !CommonStorage.CmdFlags.Elements)
			{
				form_0 = new Domain2Editor(cStorage);
				Application.Run(form_0);
				return;
			}
			if (CommonStorage.CmdFlags.Tasks && !CommonStorage.CmdFlags.Elements)
			{
				if (File.Exists(CommonStorage.Params.OutEditorsPath.TasksEditor))
				{
					ACE.RSGlobal.RSGlobal.OpenWith(CommonStorage.Params.OutEditorsPath.TasksEditor, CommonStorage.CmdFlags.tasksFN, null);
				}
				return;
			}
			string skiOrEcmFN = CommonStorage.CmdFlags.SkiOrEcmFN;
			if (skiOrEcmFN != null)
			{
				MODEL_VIEWER.ShowModelFromFile(skiOrEcmFN);
				return;
			}
			string fN = CommonStorage.CmdFlags.FN;
			if (fN != null && fN.EndsWith(smethod_11(), StringComparison.OrdinalIgnoreCase))
			{
				ACE.RSGlobal.RSGlobal.OpenInNotepad(eListCollection._CreateQueryConfigDB(CommonStorage.CmdFlags.FN) + Class16.smethod_0(1648898262));
			}
			else if (CommonStorage.CmdFlags.importFN == null || !ACE.MainWindow.MainWindow.TryOpenFileInRunningMainWindow(CommonStorage.CmdFlags.importFN))
			{
				form_0 = new ACE.MainWindow.MainWindow(cStorage, IsSubwindow: false);
				Application.Run(form_0);
			}
		}
	}

	private static void smethod_1(object sender, ThreadExceptionEventArgs e)
	{
		if (e?.Exception is NullReferenceException { StackTrace: not null } ex && ex.StackTrace.Contains(Class16.smethod_0(1649186432)))
		{
			SentryHelper.AddBreadcrumb(Class16.smethod_0(1649186494), Class16.smethod_0(1649186567), (BreadcrumbLevel)1);
		}
		else if (e?.Exception is InvalidCastException { StackTrace: not null } ex2 && (ex2.StackTrace.Contains(Class16.smethod_0(1649186608)) || ex2.StackTrace.Contains(Class16.smethod_0(1649186664))))
		{
			SentryHelper.AddBreadcrumb(Class16.smethod_0(1649186723), Class16.smethod_0(1649186803), (BreadcrumbLevel)1);
		}
		else if (e?.Exception is ArgumentException { StackTrace: not null } ex3 && (ex3.StackTrace.Contains(Class16.smethod_0(1649185816)) || ex3.StackTrace.Contains(Class16.smethod_0(1649185867)) || ex3.StackTrace.Contains(Class16.smethod_0(1649185913))))
		{
			SentryHelper.AddBreadcrumb(Class16.smethod_0(1649185967), Class16.smethod_0(1649186025), (BreadcrumbLevel)1);
		}
		else
		{
			SentryHelper.CaptureException(e.Exception, Class16.smethod_0(1648903534));
		}
	}

	private static void smethod_2(object sender, UnhandledExceptionEventArgs e)
	{
		if (e.ExceptionObject is Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648903509), e.IsTerminating);
		}
	}

	private static void smethod_3(string string_0)
	{
		ACE.Classes.Settings.ExceptionSubject = smethod_4(string_0);
		ACE.Classes.Settings.UserName = CommonStorage.License.UserName;
		ACE.Classes.Settings.UserEmail = LICENSE_INFO.Info.Email ?? smethod_15();
		SentryHelper.SetUser(CommonStorage.License.UserName, LICENSE_INFO.Info.Email ?? smethod_15());
	}

	private static string smethod_4(string string_0)
	{
		return (CommonStorage.License.UserName ?? string.Empty) + smethod_14() + Application.ProductName + smethod_16() + string_0;
	}

	private static void smethod_5(Enum22 enum22_0)
	{
		smethod_8(enum22_0);
		smethod_7();
		SentryHelper.Flush();
		Application.Exit();
	}

	private static void smethod_6(Enum22 enum22_0)
	{
		smethod_9(enum22_0);
	}

	private static void smethod_7()
	{
	}

	private static void smethod_8(Enum22 enum22_0)
	{
		string key = Class16.smethod_0(1649186072);
		int num = (int)enum22_0;
		SentryHelper.SetTag(key, num.ToString());
		SentryHelper.LogFatal(Class16.smethod_0(1649186097));
	}

	private static void smethod_9(Enum22 enum22_0)
	{
		string key = Class16.smethod_0(1649186131);
		int num = (int)enum22_0;
		SentryHelper.SetTag(key, num.ToString());
		SentryHelper.LogWarning(Class16.smethod_0(1649186166));
	}

	private static Exception smethod_10(Exception exception_0)
	{
		return null;
	}

	private static string smethod_11()
	{
		return string.Concat('.', 'c', 'f', 'g');
	}

	private static string smethod_12()
	{
		return new string(new char[15]
		{
			'A', 'C', 'E', '_', 'L', 'i', 'c', 'e', 'n', 's',
			'e', '.', 'd', 'l', 'l'
		});
	}

	private static string smethod_13()
	{
		return string.Concat('-', 'r', 'e', 's', 't', 'a', 'r', 't', 'e', 'd');
	}

	private static string smethod_14()
	{
		return string.Concat(':', ' ');
	}

	private static string smethod_15()
	{
		return Class16.smethod_0(1649047610) + Class16.smethod_0(1649078580) + Class16.smethod_0(1649186203);
	}

	private static string smethod_16()
	{
		return string.Concat(' ', 'v');
	}

	private static DateTime smethod_17(string string_0)
	{
		byte[] array = new byte[48];
		array[0] = 27;
		IPAddress[] addressList = Dns.GetHostEntry(string_0).AddressList;
		IPEndPoint remoteEP = new IPEndPoint(addressList[0], 123);
		Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		try
		{
			socket.ReceiveTimeout = 3000;
			socket.SendTimeout = 3000;
			socket.Connect(remoteEP);
			socket.Send(array);
			socket.Receive(array);
		}
		finally
		{
			((IDisposable)socket).Dispose();
		}
		uint num = (uint)((array[40] << 24) | (array[41] << 16) | (array[42] << 8) | array[43]);
		uint num2 = (uint)((array[44] << 24) | (array[45] << 16) | (array[46] << 8) | array[47]);
		ulong num3 = (ulong)((long)num * 1000L) + (ulong)((long)num2 * 1000L) / 4294967296uL;
		return new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(num3).ToLocalTime();
	}

	private static DateTime? smethod_18()
	{
		string[] array = smethod_19();
		string[] array2 = array;
		foreach (string string_ in array2)
		{
			try
			{
				return smethod_17(string_);
			}
			catch
			{
			}
		}
		return null;
	}

	private static string[] smethod_19()
	{
		return new string[4]
		{
			Class16.smethod_0(1649186226) + Class16.smethod_0(1648928036) + Class16.smethod_0(1649186245) + Class16.smethod_0(1648928036) + Class16.smethod_0(1649186255),
			Class16.smethod_0(1649186257) + Class16.smethod_0(1648928036) + Class16.smethod_0(1649186276) + Class16.smethod_0(1648928036) + Class16.smethod_0(1649186281),
			Class16.smethod_0(1649186257) + Class16.smethod_0(1648928036) + Class16.smethod_0(1649186291) + Class16.smethod_0(1648928036) + Class16.smethod_0(1649185286),
			Class16.smethod_0(1649186257) + Class16.smethod_0(1648928036) + Class16.smethod_0(1649185288) + Class16.smethod_0(1648928036) + Class16.smethod_0(1649186281)
		};
	}

	private static bool smethod_20()
	{
		return true;
	}
}
