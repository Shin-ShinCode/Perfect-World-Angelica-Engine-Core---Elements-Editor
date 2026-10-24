using System;

namespace ACE.Dependency.zlibnet.zlib;

public static class CrcCalculator
{
	public static uint CaclulateCRC32(byte[] buffer)
	{
		FixedArray fixedArray = new FixedArray(buffer);
		try
		{
			return ZLib.crc32(0u, fixedArray, (uint)buffer.Length);
		}
		finally
		{
			((IDisposable)fixedArray).Dispose();
		}
	}
}
