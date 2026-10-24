#define TRACE
using System;
using System.Diagnostics;

namespace ACE.Classes.ACE_Extra;

public static class RLogger
{
	private static readonly TraceSource traceSource_0 = new TraceSource(Class16.smethod_0(1648907587));

	public static void Fatal(string message)
	{
		traceSource_0.TraceEvent(TraceEventType.Critical, 0, message);
	}

	public static void Fatal(Exception exception_0, string message)
	{
		if (exception_0 != null)
		{
			traceSource_0.TraceEvent(TraceEventType.Critical, 0, string.Format(Class16.smethod_0(1648907601), message, exception_0));
		}
		else
		{
			traceSource_0.TraceEvent(TraceEventType.Critical, 0, message);
		}
	}

	public static void CloseAndFlush()
	{
		traceSource_0.Close();
	}
}
