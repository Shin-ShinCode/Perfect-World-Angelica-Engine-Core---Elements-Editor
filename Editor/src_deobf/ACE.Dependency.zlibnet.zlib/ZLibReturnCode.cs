using System.Runtime.InteropServices;

namespace ACE.Dependency.zlibnet.zlib;

internal static class ZLibReturnCode
{
	public const int Ok = 0;

	public const int StreamEnd = 1;

	public const int NeedDictionary = 2;

	public const int Errno = -1;

	public const int StreamError = -2;

	public const int DataError = -3;

	public const int MemoryError = -4;

	public const int BufferError = -5;

	public const int VersionError = -6;

	public static string GetMesage(int retCode)
	{
		return retCode switch
		{
			-6 => Class16.smethod_0(1648888183), 
			-5 => Class16.smethod_0(1648888142), 
			-4 => Class16.smethod_0(1648888114), 
			-3 => Class16.smethod_0(1648888089), 
			-2 => Class16.smethod_0(1648888078), 
			-1 => Class16.smethod_0(1648888049) + Marshal.GetLastWin32Error(), 
			0 => Class16.smethod_0(1648889739), 
			1 => Class16.smethod_0(1648887986), 
			2 => Class16.smethod_0(1648888021), 
			_ => Class16.smethod_0(1648889754), 
		};
	}
}
