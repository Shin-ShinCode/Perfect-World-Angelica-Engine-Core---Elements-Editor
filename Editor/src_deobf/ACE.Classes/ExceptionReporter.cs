using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using ACE.License;
using Sentry;

namespace ACE.Classes;

public static class ExceptionReporter
{
	private static class Class69
	{
		public static UnhandledExceptionEventHandler unhandledExceptionEventHandler_0;

		public static ThreadExceptionEventHandler threadExceptionEventHandler_0;
	}

	private static bool bool_0;

	[ThreadStatic]
	private static bool bool_1;

	private static void smethod_0(string string_0, Exception exception_0)
	{
	}

	public static void Initialize()
	{
		if (!bool_0)
		{
			AppDomain.CurrentDomain.UnhandledException += smethod_1;
			Application.ThreadException += smethod_2;
			bool_0 = true;
		}
	}

	private static void smethod_1(object sender, UnhandledExceptionEventArgs e)
	{
		if (e.ExceptionObject is Exception ex)
		{
			ReportException(ex, Class16.smethod_0(1648903509), e.IsTerminating);
		}
	}

	private static void smethod_2(object sender, ThreadExceptionEventArgs e)
	{
		ReportException(e.Exception, Class16.smethod_0(1648903534));
	}

	public static void ReportException(Exception ex, string context = "", bool isTerminating = false)
	{
		try
		{
			SentryHelper.CaptureException(ex, context, isTerminating);
		}
		catch (Exception exception_)
		{
			smethod_0(Class16.smethod_0(1648903556), exception_);
		}
	}

	public static void Report(Exception ex, string context = "")
	{
		SentryHelper.CaptureException(ex, context);
	}

	internal static void ReportToApi(Exception ex, string context = "", bool isTerminating = false)
	{
		if (!bool_0 || bool_1)
		{
			return;
		}
		bool_1 = true;
		try
		{
			string text = ex.Message;
			if (ex.InnerException != null)
			{
				text = text + Class16.smethod_0(1648903571) + ex.InnerException.Message;
			}
			string context2 = context + (isTerminating ? Class16.smethod_0(1648903605) : string.Empty);
			AceNative.ACE_ReportErrorEx(Class16.smethod_0(1648903618), ex.GetType().FullName ?? ex.GetType().Name, text, ex.StackTrace ?? string.Empty, context2, Settings.UserName ?? Class16.smethod_0(1648908791), smethod_3());
		}
		catch (Exception exception_)
		{
			smethod_0(Class16.smethod_0(1648903639), exception_);
		}
		finally
		{
			bool_1 = false;
		}
	}

	public static void ReportError(string message, string context = "")
	{
		try
		{
			SentryHelper.CaptureMessage(message, (SentryLevel)3, context);
			if (bool_1)
			{
				return;
			}
			bool_1 = true;
			try
			{
				AceNative.ACE_ReportErrorEx(Class16.smethod_0(1648903618), Class16.smethod_0(1648903669), message, Environment.StackTrace, context, Settings.UserName ?? Class16.smethod_0(1648908791), smethod_3());
			}
			finally
			{
				bool_1 = false;
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648902663));
		}
	}

	private static string smethod_3()
	{
		try
		{
			Version version = Assembly.GetExecutingAssembly().GetName().Version;
			return (version != null) ? string.Format(Class16.smethod_0(1648902691), version.Major, version.Minor, version.Build) : Class16.smethod_0(1648908791);
		}
		catch
		{
			return Class16.smethod_0(1648908791);
		}
	}
}
