using System;
using System.Linq;

namespace ACE.MppcLibrary;

public class pw_mppc_managed : pw_mppc
{
	public static uint compressBound(uint sourcelen)
	{
		return sourcelen * 9 / 8 + 1 + 2 + 3;
	}

	public byte[] compress(byte[] buffer)
	{
		byte[] array = new byte[16384];
		int num = buffer.Length;
		int destLen = (int)compressBound((uint)num);
		if (!((num > 8192) ? (mppc_cs.compress2(array, ref destLen, buffer, num) == 0) : (mppc_cs.compress(array, ref destLen, buffer, num) == 0)))
		{
			return buffer;
		}
		return array.Take(destLen).ToArray();
	}

	public byte[] decompress(byte[] buffer, int dataSize)
	{
		throw new Exception();
	}
}
