using System;

namespace ACE.Dependency.zlibnet;

public static class ZLibDll
{
	internal const string Name32 = "zlib32.dll";

	internal const string Name64 = "zlib64.dll";

	internal static bool Is64 = IntPtr.Size == 8;

	internal const string ZLibDllFileVersion = "1.2.8.1";

	internal static string GetDllName()
	{
		if (Is64)
		{
			return Class16.smethod_0(1648889153);
		}
		return Class16.smethod_0(1648889170);
	}
}
