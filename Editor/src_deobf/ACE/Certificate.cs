using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace ACE;

internal static class Certificate
{
	private struct Struct37
	{
		public uint uint_0;

		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public IntPtr intptr_2;

		public uint uint_4;

		public IntPtr intptr_3;

		public IntPtr intptr_4;

		public uint uint_5;

		public uint uint_6;

		public IntPtr intptr_5;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct Struct38
	{
		public uint uint_0;

		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public IntPtr intptr_2;
	}

	private static readonly Guid guid_0 = new Guid(Class16.smethod_0(1648908031));

	private static readonly string[] string_0 = new string[1] { Class16.smethod_0(1648908066) };

	private static readonly bool bool_0 = true;

	[DllImport("wintrust.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern int WinVerifyTrust(IntPtr intptr_0, ref Guid guid_1, ref Struct37 struct37_0);

	public static bool CheckCertificate()
	{
		try
		{
			string text = smethod_0();
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (bool_0 && !smethod_1(text))
			{
				return false;
			}
			CertificateInfo certificateInfo = smethod_2(text);
			if (certificateInfo == null)
			{
				return false;
			}
			if (!smethod_3(certificateInfo.SerialNumber))
			{
				return false;
			}
			if (!smethod_4(certificateInfo))
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static string smethod_0()
	{
		try
		{
			string text = Process.GetCurrentProcess().MainModule?.FileName;
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
		}
		catch
		{
		}
		try
		{
			return Assembly.GetEntryAssembly()?.Location;
		}
		catch
		{
		}
		try
		{
			return Assembly.GetExecutingAssembly()?.Location;
		}
		catch
		{
		}
		return null;
	}

	private static bool smethod_1(string string_1)
	{
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.StringToCoTaskMemUni(string_1);
			Struct38 structure = new Struct38
			{
				uint_0 = (uint)Marshal.SizeOf(typeof(Struct38)),
				intptr_0 = intPtr,
				intptr_1 = IntPtr.Zero,
				intptr_2 = IntPtr.Zero
			};
			IntPtr intPtr2 = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(Struct38)));
			Marshal.StructureToPtr(structure, intPtr2, fDeleteOld: false);
			Struct37 struct37_ = new Struct37
			{
				uint_0 = (uint)Marshal.SizeOf(typeof(Struct37)),
				intptr_0 = IntPtr.Zero,
				intptr_1 = IntPtr.Zero,
				uint_1 = 2u,
				uint_2 = 0u,
				uint_3 = 1u,
				intptr_2 = intPtr2,
				uint_4 = 1u,
				intptr_3 = IntPtr.Zero,
				intptr_4 = IntPtr.Zero,
				uint_5 = 0u,
				uint_6 = 0u,
				intptr_5 = IntPtr.Zero
			};
			Guid guid_ = guid_0;
			int num = WinVerifyTrust(IntPtr.Zero, ref guid_, ref struct37_);
			struct37_.uint_4 = 2u;
			WinVerifyTrust(IntPtr.Zero, ref guid_, ref struct37_);
			Marshal.FreeCoTaskMem(intPtr2);
			return num == 0;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}
	}

	private static CertificateInfo smethod_2(string string_1)
	{
		try
		{
			X509Certificate x509Certificate = X509Certificate.CreateFromSignedFile(string_1);
			if (x509Certificate == null)
			{
				return null;
			}
			X509Certificate2 x509Certificate2 = new X509Certificate2(x509Certificate);
			CertificateInfo certificateInfo = new CertificateInfo();
			string serialNumber = x509Certificate2.SerialNumber;
			object obj;
			if (serialNumber == null)
			{
				obj = null;
			}
			else
			{
				obj = serialNumber.ToLowerInvariant();
				if (obj != null)
				{
					goto IL_0036;
				}
			}
			obj = string.Empty;
			goto IL_0036;
			IL_0036:
			certificateInfo.SerialNumber = (string)obj;
			certificateInfo.ValidFrom = x509Certificate2.NotBefore;
			certificateInfo.ValidTo = x509Certificate2.NotAfter;
			return certificateInfo;
		}
		catch
		{
			return null;
		}
	}

	private static bool smethod_3(string string_1)
	{
		if (string.IsNullOrEmpty(string_1))
		{
			return false;
		}
		string text = string_1.ToLowerInvariant().Replace(Class16.smethod_0(1648942211), string.Empty).Replace(Class16.smethod_0(1648941518), string.Empty);
		string[] array = string_0;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				string text2 = array[num];
				string text3 = text2.ToLowerInvariant().Replace(Class16.smethod_0(1648942211), string.Empty).Replace(Class16.smethod_0(1648941518), string.Empty);
				if (text == text3)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private static bool smethod_4(CertificateInfo certificateInfo_0)
	{
		if (certificateInfo_0 == null)
		{
			return false;
		}
		DateTime now = DateTime.Now;
		if (now >= certificateInfo_0.ValidFrom)
		{
			return now <= certificateInfo_0.ValidTo;
		}
		return false;
	}
}
