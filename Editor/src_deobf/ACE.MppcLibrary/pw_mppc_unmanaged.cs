using System;
using System.Runtime.InteropServices;

namespace ACE.MppcLibrary;

public class pw_mppc_unmanaged : pw_mppc
{
	public static uint compressBound(uint sourcelen)
	{
		return sourcelen * 9 / 8 + 1 + 2 + 3;
	}

	public byte[] compress(byte[] buffer)
	{
		throw new Exception();
	}

	public unsafe byte[] decompress(byte[] buffer, int dataSize)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1649115992));
		}
		if (dataSize < 0)
		{
			throw new ArgumentOutOfRangeException(Class16.smethod_0(1649116003), Class16.smethod_0(1649116022));
		}
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		try
		{
			int cb = Math.Max(1, buffer.Length);
			intPtr = Marshal.AllocHGlobal(cb);
			if (buffer.Length != 0)
			{
				Marshal.Copy(buffer, 0, intPtr, buffer.Length);
			}
			int num = Math.Max(102400, dataSize);
			intPtr2 = Marshal.AllocHGlobal(num);
			int sourceLen = buffer.Length;
			int num2 = dataSize;
			int num3 = ((num2 <= 8192) ? mppc_cpp.uncompress((byte*)(void*)intPtr2, &num2, (byte*)(void*)intPtr, sourceLen) : mppc_cpp.uncompress2((byte*)(void*)intPtr2, &num2, (byte*)(void*)intPtr, sourceLen));
			if (num3 == -1)
			{
				return null;
			}
			if (num2 >= 0 && num2 <= num)
			{
				byte[] array = new byte[num2];
				if (num2 > 0)
				{
					Marshal.Copy(intPtr2, array, 0, array.Length);
				}
				return array;
			}
			return null;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr2);
			}
		}
	}
}
