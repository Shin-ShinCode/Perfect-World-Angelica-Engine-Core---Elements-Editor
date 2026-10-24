using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using ACE.Classes;
using Sentry;

namespace ACE.License;

public static class AceSecurity
{
	private static class Class149
	{
		public static ThreadStart threadStart_0;
	}

	[Serializable]
	private sealed class Class150
	{
		public static readonly Class150 class150_0 = new Class150();

		public static Func<ProcessModule, bool> func_0;

		public static Func<ProcessModule, bool> func_1;

		internal bool method_0(ProcessModule processModule_0)
		{
			return processModule_0.ModuleName?.Contains(Class16.smethod_0(1649051780)) ?? false;
		}

		internal bool method_1(ProcessModule processModule_0)
		{
			return processModule_0.ModuleName?.Contains(Class16.smethod_0(1649051780)) ?? false;
		}
	}

	public class ProtectedString
	{
		private byte[] byte_0;

		private byte[] byte_1;

		private readonly byte[] byte_2;

		private readonly object object_0 = new object();

		public string Value
		{
			get
			{
				lock (object_0)
				{
					byte[] array = smethod_9(byte_0);
					if (!Class5.smethod_2(array, byte_1))
					{
						throw new SecurityException(Class16.smethod_0(1649051798));
					}
					return method_1();
				}
			}
			set
			{
				lock (object_0)
				{
					byte_0 = method_0(value ?? string.Empty);
					byte_1 = smethod_9(byte_0);
				}
			}
		}

		public ProtectedString(string value)
		{
			byte_2 = new byte[32];
			using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
			randomNumberGenerator.GetBytes(byte_2);
			byte_0 = method_0(value ?? string.Empty);
			byte_1 = smethod_9(byte_0);
		}

		private byte[] method_0(string string_0)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			byte[] array = new byte[bytes.Length];
			for (int i = 0; i < bytes.Length; i++)
			{
				array[i] = (byte)(bytes[i] ^ byte_2[i % byte_2.Length]);
			}
			return array;
		}

		private string method_1()
		{
			byte[] array = new byte[byte_0.Length];
			for (int i = 0; i < byte_0.Length; i++)
			{
				array[i] = (byte)(byte_0[i] ^ byte_2[i % byte_2.Length]);
			}
			return Encoding.UTF8.GetString(array);
		}
	}

	public class ProtectedValue<T> where T : struct
	{
		private byte[] byte_0;

		private byte[] byte_1;

		private readonly byte[] byte_2;

		private readonly object object_0 = new object();

		public T Value
		{
			get
			{
				lock (object_0)
				{
					byte[] array = smethod_9(byte_0);
					if (!Class5.smethod_2(array, byte_1))
					{
						throw new SecurityException(Class16.smethod_0(1649051832));
					}
					return method_1();
				}
			}
			set
			{
				lock (object_0)
				{
					byte_0 = method_0(value);
					byte_1 = smethod_9(byte_0);
				}
			}
		}

		public ProtectedValue(T initialValue)
		{
			byte_2 = new byte[32];
			using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
			randomNumberGenerator.GetBytes(byte_2);
			byte_0 = method_0(initialValue);
			byte_1 = smethod_9(byte_0);
		}

		private byte[] method_0(T gparam_0)
		{
			int num = Marshal.SizeOf<T>();
			byte[] array = new byte[num];
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			try
			{
				Marshal.StructureToPtr(gparam_0, intPtr, fDeleteOld: false);
				Marshal.Copy(intPtr, array, 0, num);
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
			byte[] array2 = new byte[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (byte)(array[i] ^ byte_2[i % byte_2.Length]);
			}
			return array2;
		}

		private T method_1()
		{
			byte[] array = new byte[byte_0.Length];
			for (int i = 0; i < byte_0.Length; i++)
			{
				array[i] = (byte)(byte_0[i] ^ byte_2[i % byte_2.Length]);
			}
			IntPtr intPtr = Marshal.AllocHGlobal(array.Length);
			try
			{
				Marshal.Copy(array, 0, intPtr, array.Length);
				return Marshal.PtrToStructure<T>(intPtr);
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}
	}

	public class SecurityConfig
	{
		private bool bool_0 = true;

		private bool bool_1 = true;

		private bool bool_2 = true;

		private bool bool_3 = true;

		private bool bool_4 = true;

		private int int_0 = 3000;

		private bool bool_5 = true;

		private bool bool_6;

		public bool EnableAntiDebug
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}

		public bool EnableAntiCheatEngine
		{
			[CompilerGenerated]
			get
			{
				return bool_1;
			}
			[CompilerGenerated]
			set
			{
				bool_1 = value;
			}
		}

		public bool EnableMemoryIntegrity
		{
			[CompilerGenerated]
			get
			{
				return bool_2;
			}
			[CompilerGenerated]
			set
			{
				bool_2 = value;
			}
		}

		public bool EnableTimingChecks
		{
			[CompilerGenerated]
			get
			{
				return bool_3;
			}
			[CompilerGenerated]
			set
			{
				bool_3 = value;
			}
		}

		public bool EnableProcessMonitoring
		{
			[CompilerGenerated]
			get
			{
				return bool_4;
			}
			[CompilerGenerated]
			set
			{
				bool_4 = value;
			}
		}

		public int CheckIntervalMs
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public bool TerminateOnViolation
		{
			[CompilerGenerated]
			get
			{
				return bool_5;
			}
			[CompilerGenerated]
			set
			{
				bool_5 = value;
			}
		}

		public bool AllowVirtualMachine
		{
			[CompilerGenerated]
			get
			{
				return bool_6;
			}
			[CompilerGenerated]
			set
			{
				bool_6 = value;
			}
		}
	}

	public class SecurityViolation
	{
		private SecurityViolationType securityViolationType_0;

		private string string_0 = string.Empty;

		private DateTime dateTime_0 = DateTime.UtcNow;

		public SecurityViolationType Type
		{
			[CompilerGenerated]
			get
			{
				return securityViolationType_0;
			}
			[CompilerGenerated]
			set
			{
				securityViolationType_0 = value;
			}
		}

		public string Details
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public DateTime Timestamp
		{
			[CompilerGenerated]
			get
			{
				return dateTime_0;
			}
			[CompilerGenerated]
			set
			{
				dateTime_0 = value;
			}
		}
	}

	public enum SecurityViolationType
	{
		None,
		DebuggerDetected,
		CheatEngineDetected,
		MemoryTampered,
		IntegrityViolation,
		TimingAttack,
		SuspiciousProcess,
		ApiHooked,
		CodeModified,
		VirtualMachine,
		Sandbox
	}

	private static readonly object object_0 = new object();

	private static bool bool_0 = false;

	private static Thread thread_0;

	private static CancellationTokenSource cancellationTokenSource_0;

	private static readonly ConcurrentDictionary<string, byte[]> concurrentDictionary_0 = new ConcurrentDictionary<string, byte[]>();

	private static readonly ConcurrentDictionary<IntPtr, (int, byte[])> concurrentDictionary_1 = new ConcurrentDictionary<IntPtr, (int, byte[])>();

	private static Action<SecurityViolation> action_0;

	private static DateTime dateTime_0 = DateTime.UtcNow;

	private static int int_0 = 0;

	private static readonly Random random_0 = new Random();

	private static readonly byte[] byte_0 = new byte[8] { 74, 206, 83, 69, 67, 85, 82, 73 };

	private static byte[] byte_1 = Array.Empty<byte>();

	private static SecurityConfig securityConfig_0 = new SecurityConfig();

	private static readonly string[] string_0 = new string[36]
	{
		Class16.smethod_0(1649051873),
		Class16.smethod_0(1649051891),
		Class16.smethod_0(1649051918),
		Class16.smethod_0(1649051932),
		Class16.smethod_0(1649051938),
		Class16.smethod_0(1649051959),
		Class16.smethod_0(1649051972),
		Class16.smethod_0(1649051977),
		Class16.smethod_0(1649051992),
		Class16.smethod_0(1649052008),
		Class16.smethod_0(1649052030),
		Class16.smethod_0(1649052047),
		Class16.smethod_0(1649052057),
		Class16.smethod_0(1649052085),
		Class16.smethod_0(1649052096),
		Class16.smethod_0(1649052118),
		Class16.smethod_0(1649052134),
		Class16.smethod_0(1649052138),
		Class16.smethod_0(1649052152),
		Class16.smethod_0(1649047052),
		Class16.smethod_0(1649047059),
		Class16.smethod_0(1649047072),
		Class16.smethod_0(1649047089),
		Class16.smethod_0(1649047105),
		Class16.smethod_0(1649047120),
		Class16.smethod_0(1649047148),
		Class16.smethod_0(1649047153),
		Class16.smethod_0(1649047169),
		Class16.smethod_0(1649047187),
		Class16.smethod_0(1649047212),
		Class16.smethod_0(1649047218),
		Class16.smethod_0(1649047239),
		Class16.smethod_0(1649047253),
		Class16.smethod_0(1649047258),
		Class16.smethod_0(1649047274),
		Class16.smethod_0(1649047295)
	};

	private static readonly string[] string_1 = new string[8]
	{
		Class16.smethod_0(1649047309),
		Class16.smethod_0(1649047318),
		Class16.smethod_0(1649047323),
		Class16.smethod_0(1649047341),
		Class16.smethod_0(1649047351),
		Class16.smethod_0(1649047365),
		Class16.smethod_0(1649047370),
		Class16.smethod_0(1649047391)
	};

	private static readonly string[] string_2 = new string[14]
	{
		Class16.smethod_0(1649047405),
		Class16.smethod_0(1649047416),
		Class16.smethod_0(1649051938),
		Class16.smethod_0(1649051959),
		Class16.smethod_0(1649047438),
		Class16.smethod_0(1649047451),
		Class16.smethod_0(1649047464),
		Class16.smethod_0(1649047484),
		Class16.smethod_0(1649047496),
		Class16.smethod_0(1649047524),
		Class16.smethod_0(1649047542),
		Class16.smethod_0(1649046533),
		Class16.smethod_0(1649046539),
		Class16.smethod_0(1649046564)
	};

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool IsDebuggerPresent();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CheckRemoteDebuggerPresent(IntPtr intptr_0, ref bool bool_1);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtQueryInformationProcess(IntPtr intptr_0, int int_1, ref IntPtr intptr_1, int int_2, out int int_3);

	[DllImport("kernel32.dll")]
	private static extern IntPtr GetCurrentProcess();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CloseHandle(IntPtr intptr_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	private static extern IntPtr FindWindow(string string_3, string string_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern IntPtr CreateFile(string string_3, uint uint_0, uint uint_1, IntPtr intptr_0, uint uint_2, uint uint_3, IntPtr intptr_1);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool VirtualProtect(IntPtr intptr_0, UIntPtr uintptr_0, uint uint_0, out uint uint_1);

	[DllImport("kernel32.dll")]
	private static extern void OutputDebugString(string string_3);

	public static void Initialize(SecurityConfig config = null, Action<SecurityViolation> callback = null)
	{
		lock (object_0)
		{
			if (!bool_0)
			{
				securityConfig_0 = config ?? new SecurityConfig();
				action_0 = callback;
				smethod_6();
				byte_1 = smethod_10(new byte[4]);
				cancellationTokenSource_0 = new CancellationTokenSource();
				thread_0 = new Thread(smethod_7)
				{
					IsBackground = true,
					Name = Class16.smethod_0(1649046576),
					Priority = ThreadPriority.AboveNormal
				};
				thread_0.Start();
				bool_0 = true;
				SentryHelper.LogInfo(Class16.smethod_0(1649046602));
			}
		}
	}

	public static void Shutdown()
	{
		lock (object_0)
		{
			if (bool_0)
			{
				cancellationTokenSource_0?.Cancel();
				thread_0?.Join(1000);
				cancellationTokenSource_0?.Dispose();
				cancellationTokenSource_0 = null;
				thread_0 = null;
				concurrentDictionary_0.Clear();
				concurrentDictionary_1.Clear();
				bool_0 = false;
				SentryHelper.LogInfo(Class16.smethod_0(1649046644));
			}
		}
	}

	public static bool IsDebuggerAttached()
	{
		if (Debugger.IsAttached)
		{
			return true;
		}
		if (IsDebuggerPresent())
		{
			return true;
		}
		bool bool_ = false;
		if (CheckRemoteDebuggerPresent(GetCurrentProcess(), ref bool_) && bool_)
		{
			return true;
		}
		try
		{
			IntPtr intptr_ = IntPtr.Zero;
			if (NtQueryInformationProcess(GetCurrentProcess(), 7, ref intptr_, IntPtr.Size, out var _) == 0 && intptr_ != IntPtr.Zero)
			{
				return true;
			}
		}
		catch
		{
		}
		try
		{
			IntPtr intptr_2 = IntPtr.Zero;
			if (NtQueryInformationProcess(GetCurrentProcess(), 31, ref intptr_2, IntPtr.Size, out var _) == 0 && intptr_2 == IntPtr.Zero)
			{
				return true;
			}
		}
		catch
		{
		}
		if (smethod_0())
		{
			return true;
		}
		if (smethod_1())
		{
			return true;
		}
		return false;
	}

	private static bool smethod_0()
	{
		try
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			int num = 0;
			for (int i = 0; i < 1000; i++)
			{
				num += i;
			}
			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds > 100L;
		}
		catch
		{
			return false;
		}
	}

	private static bool smethod_1()
	{
		try
		{
			OutputDebugString(Class16.smethod_0(1649046679));
			return false;
		}
		catch
		{
			return true;
		}
	}

	public static bool IsCheatEngineDetected()
	{
		if (smethod_2())
		{
			return true;
		}
		if (smethod_3())
		{
			return true;
		}
		if (smethod_4())
		{
			return true;
		}
		if (smethod_5())
		{
			return true;
		}
		return false;
	}

	private static bool smethod_2()
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			Process[] array = processes;
			foreach (Process process in array)
			{
				try
				{
					string text = process.ProcessName.ToLowerInvariant();
					string[] array2 = string_0;
					foreach (string value in array2)
					{
						if (text.Contains(value))
						{
							process.Dispose();
							return true;
						}
					}
					string[] array3 = string_1;
					foreach (string text2 in array3)
					{
						if (text == text2)
						{
							process.Dispose();
							return true;
						}
					}
				}
				catch
				{
				}
				finally
				{
					process.Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649046695));
		}
		return false;
	}

	private static bool smethod_3()
	{
		string[] array = string_2;
		foreach (string string_ in array)
		{
			try
			{
				if (FindWindow(null, string_) != IntPtr.Zero)
				{
					return true;
				}
			}
			catch
			{
			}
		}
		return false;
	}

	private static bool smethod_4()
	{
		string[] array = new string[4]
		{
			Class16.smethod_0(1649046731),
			Class16.smethod_0(1649046752),
			Class16.smethod_0(1649046781),
			Class16.smethod_0(1649046794)
		};
		string[] array2 = array;
		foreach (string string_ in array2)
		{
			try
			{
				IntPtr intPtr = CreateFile(string_, 3221225472u, 0u, IntPtr.Zero, 3u, 0u, IntPtr.Zero);
				if (intPtr != IntPtr.Zero && intPtr != new IntPtr(-1))
				{
					CloseHandle(intPtr);
					return true;
				}
			}
			catch
			{
			}
		}
		return false;
	}

	private static bool smethod_5()
	{
		string[] array = new string[6]
		{
			Class16.smethod_0(1649046822),
			Class16.smethod_0(1649046834),
			Class16.smethod_0(1649046860),
			Class16.smethod_0(1649051873),
			Class16.smethod_0(1649046879),
			Class16.smethod_0(1649046895)
		};
		try
		{
			ProcessModuleCollection modules = Process.GetCurrentProcess().Modules;
			foreach (ProcessModule item in modules)
			{
				string moduleName = item.ModuleName;
				object obj;
				if (moduleName == null)
				{
					obj = null;
				}
				else
				{
					obj = moduleName.ToLowerInvariant();
					if (obj != null)
					{
						goto IL_0096;
					}
				}
				obj = string.Empty;
				goto IL_0096;
				IL_0096:
				string text = (string)obj;
				string[] array2 = array;
				foreach (string value in array2)
				{
					if (text.Contains(value))
					{
						return true;
					}
				}
			}
		}
		catch (Win32Exception)
		{
			return false;
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649046910));
		}
		return false;
	}

	private static void smethod_6()
	{
		try
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string location = executingAssembly.Location;
			if (!string.IsNullOrEmpty(location) && File.Exists(location))
			{
				byte[] byte_ = File.ReadAllBytes(location);
				byte[] value = smethod_9(byte_);
				concurrentDictionary_0[Class16.smethod_0(1649046947)] = value;
			}
			try
			{
				ProcessModule processModule = Process.GetCurrentProcess().Modules.Cast<ProcessModule>().FirstOrDefault(Class150.class150_0.method_0);
				if (processModule != null && File.Exists(processModule.FileName))
				{
					byte[] byte_2 = File.ReadAllBytes(processModule.FileName);
					byte[] value2 = smethod_9(byte_2);
					concurrentDictionary_0[Class16.smethod_0(1649051780)] = value2;
				}
			}
			catch
			{
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649046974));
		}
	}

	public static bool VerifyAssemblyIntegrity()
	{
		foreach (KeyValuePair<string, byte[]> item in concurrentDictionary_0)
		{
			try
			{
				string key = item.Key;
				string text = ((key == Class16.smethod_0(1649046947)) ? Assembly.GetExecutingAssembly().Location : ((key == Class16.smethod_0(1649051780)) ? Process.GetCurrentProcess().Modules.Cast<ProcessModule>().FirstOrDefault(Class150.class150_0.method_1)?.FileName : null));
				string text2 = text;
				if (!string.IsNullOrEmpty(text2) && File.Exists(text2))
				{
					byte[] byte_ = File.ReadAllBytes(text2);
					byte[] first = smethod_9(byte_);
					if (!first.SequenceEqual(item.Value))
					{
						return false;
					}
				}
			}
			catch
			{
				return false;
			}
		}
		return true;
	}

	private static void smethod_7()
	{
		CancellationToken cancellationToken = cancellationTokenSource_0?.Token ?? CancellationToken.None;
		while (!cancellationToken.IsCancellationRequested)
		{
			try
			{
				Thread.Sleep(securityConfig_0.CheckIntervalMs + random_0.Next(-500, 500));
				SecurityViolation securityViolation = RunSecurityChecks();
				if (securityViolation != null)
				{
					int_0++;
					SentryHelper.LogFatal(string.Format(Class16.smethod_0(1649047010), securityViolation.Type, securityViolation.Details));
					SentryHelper.CaptureMessage(string.Format(Class16.smethod_0(1649047010), securityViolation.Type, securityViolation.Details), (SentryLevel)4, Class16.smethod_0(1649046030));
					action_0?.Invoke(securityViolation);
					if (securityConfig_0.TerminateOnViolation)
					{
						smethod_8(securityViolation);
					}
				}
				dateTime_0 = DateTime.UtcNow;
			}
			catch (ThreadInterruptedException)
			{
				break;
			}
			catch (Exception ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1649046040));
			}
		}
	}

	public static SecurityViolation RunSecurityChecks()
	{
		if (securityConfig_0.EnableAntiDebug && IsDebuggerAttached())
		{
			return new SecurityViolation
			{
				Type = SecurityViolationType.DebuggerDetected,
				Details = Class16.smethod_0(1649046072)
			};
		}
		if (securityConfig_0.EnableAntiCheatEngine && IsCheatEngineDetected())
		{
			return new SecurityViolation
			{
				Type = SecurityViolationType.CheatEngineDetected,
				Details = Class16.smethod_0(1649046096)
			};
		}
		if (securityConfig_0.EnableMemoryIntegrity && !VerifyMemoryIntegrity())
		{
			return new SecurityViolation
			{
				Type = SecurityViolationType.MemoryTampered,
				Details = Class16.smethod_0(1649046122)
			};
		}
		if (securityConfig_0.EnableMemoryIntegrity && !VerifyAssemblyIntegrity())
		{
			return new SecurityViolation
			{
				Type = SecurityViolationType.IntegrityViolation,
				Details = Class16.smethod_0(1649046159)
			};
		}
		if (securityConfig_0.EnableProcessMonitoring && smethod_2())
		{
			return new SecurityViolation
			{
				Type = SecurityViolationType.SuspiciousProcess,
				Details = Class16.smethod_0(1649046186)
			};
		}
		return null;
	}

	private static void smethod_8(SecurityViolation securityViolation_0)
	{
		try
		{
			SentryHelper.LogFatal(string.Format(Class16.smethod_0(1649046228), securityViolation_0.Type, securityViolation_0.Details));
			SentryHelper.Flush(5);
			concurrentDictionary_0.Clear();
			concurrentDictionary_1.Clear();
			byte_1 = Array.Empty<byte>();
			Environment.FailFast(string.Format(Class16.smethod_0(1649046269), securityViolation_0.Type));
		}
		catch
		{
			Environment.Exit(-1);
		}
	}

	private static byte[] smethod_9(byte[] byte_2)
	{
		using SHA256 sHA = SHA256.Create();
		return sHA.ComputeHash(byte_2);
	}

	private static byte[] smethod_10(byte[] byte_2)
	{
		byte[] array = new byte[byte_2.Length];
		for (int i = 0; i < byte_2.Length; i++)
		{
			array[i] = (byte)(byte_2[i] ^ byte_0[i % byte_0.Length]);
		}
		return array;
	}

	public static bool QuickSecurityCheck()
	{
		if (!bool_0)
		{
			return true;
		}
		if (Debugger.IsAttached)
		{
			return false;
		}
		if (IsDebuggerPresent())
		{
			return false;
		}
		return true;
	}

	public static (int violationCount, DateTime lastCheck, bool isMonitoring) GetSecurityStats()
	{
		return (violationCount: int_0, lastCheck: dateTime_0, isMonitoring: bool_0 && (thread_0?.IsAlive ?? false));
	}

	public static void RegisterMemoryRegion(IntPtr address, int size, string name)
	{
		if (!(address == IntPtr.Zero) && size > 0)
		{
			try
			{
				byte[] array = new byte[size];
				Marshal.Copy(address, array, 0, size);
				byte[] item = smethod_9(array);
				concurrentDictionary_1[address] = (size, item);
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649046291));
			}
		}
	}

	public static bool VerifyMemoryIntegrity()
	{
		foreach (KeyValuePair<IntPtr, (int, byte[])> item in concurrentDictionary_1)
		{
			try
			{
				byte[] array = new byte[item.Value.Item1];
				Marshal.Copy(item.Key, array, 0, item.Value.Item1);
				byte[] first = smethod_9(array);
				if (!first.SequenceEqual(item.Value.Item2))
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649046330));
				return false;
			}
		}
		return true;
	}
}
