using System;
using Sentry;

namespace ACE.Classes;

// TODO(recovered): The original SentryHelper bound to bleeding-edge Sentry APIs
// (SentryHint before-send, SentrySdk.Logger structured logs, EnableLogs/EnableMetrics)
// and the Gapotchenko.Eazfuscator.NET.SDK symbol decoder (ISymbolDecoder/SymbolDecoder),
// neither of which is available at the net48-compatible Sentry package version used here.
// Crash telemetry is non-essential to the data editors, so this is reduced to a
// signature-preserving shim: Init() still boots the Sentry SDK with the stable options,
// and Capture* forward to the stable SentrySdk overloads; the symbol-demangling
// before-send hook and structured logging are dropped. Restore against the original
// Sentry/Eazfuscator SDK versions if full crash reporting is needed.
public static class SentryHelper
{
	private static IDisposable idisposable_0;

	public static IDisposable Init()
	{
		idisposable_0 = SentrySdk.Init(delegate (SentryOptions o)
		{
			o.Dsn = Class16.smethod_0(1648898702);
			o.IsGlobalModeEnabled = true;
			o.AutoSessionTracking = true;
			// Crash reports should not attach automatic user identifiers or other PII.
			o.SendDefaultPii = false;
			o.AttachStacktrace = true;
			o.Debug = false;
			o.Environment = Class16.smethod_0(1648898818);
			o.TracesSampleRate = 0.1;
			Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			if (version != null)
			{
				o.Release = string.Format(Class16.smethod_0(1648898804), version.Major, version.Minor, version.Build);
			}
		});
		return idisposable_0;
	}

	public static void SetUser(string username, string email)
	{
		SentrySdk.ConfigureScope(delegate (Scope s)
		{
			s.User = new User { Username = username, Email = email };
		});
	}

	public static void SetTag(string key, string value)
	{
		SentrySdk.ConfigureScope(delegate (Scope s) { s.SetTag(key, value); });
	}

	public static void CaptureException(Exception ex, string context = null, bool isTerminating = false)
	{
		SentrySdk.CaptureException(ex, delegate (Scope s)
		{
			if (!string.IsNullOrEmpty(context))
			{
				s.SetTag(Class16.smethod_0(1648898862), context);
			}
		});
		ExceptionReporter.ReportToApi(ex, context ?? string.Empty, isTerminating);
		if (isTerminating)
		{
			Flush();
		}
	}

	public static void CaptureMessage(string message, SentryLevel level = (SentryLevel)3, string context = null)
	{
		SentrySdk.CaptureMessage(message, level);
	}

	public static void AddBreadcrumb(string message, string category = "app", BreadcrumbLevel level = (BreadcrumbLevel)0)
	{
		SentrySdk.AddBreadcrumb(message, category, null, null, level);
	}

	// TODO(recovered): structured-logging helpers were SentrySdk.Logger.* (Sentry 5.x) — no-op shims.
	public static void LogTrace(string message) { }
	public static void LogDebug(string message) { }
	public static void LogInfo(string message) { }
	public static void LogWarning(string message) { }
	public static void LogError(string message) { }
	public static void LogFatal(string message) { }

	public static void Flush(int timeoutSeconds = 3)
	{
		SentrySdk.FlushAsync(TimeSpan.FromSeconds(timeoutSeconds)).GetAwaiter().GetResult();
	}
}
