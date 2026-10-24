using System;
using System.Runtime.InteropServices;

namespace ACE.Pck;

public static class ByteExtensions
{
	public static T ReadStruct<T>(this byte[] bytes) where T : struct
	{
		GCHandle gCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
		try
		{
			return Marshal.PtrToStructure<T>(gCHandle.AddrOfPinnedObject());
		}
		finally
		{
			gCHandle.Free();
		}
	}

	public static byte[] ToBytes<T>(this T structure) where T : struct
	{
		int num = Marshal.SizeOf(structure);
		byte[] array = new byte[num];
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		try
		{
			Marshal.StructureToPtr(structure, intPtr, fDeleteOld: false);
			Marshal.Copy(intPtr, array, 0, num);
			return array;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static byte[] Xor(this byte[] data, byte[] key)
	{
		byte[] array = new byte[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			array[i] = (byte)(data[i] ^ key[i % key.Length]);
		}
		return array;
	}
}
