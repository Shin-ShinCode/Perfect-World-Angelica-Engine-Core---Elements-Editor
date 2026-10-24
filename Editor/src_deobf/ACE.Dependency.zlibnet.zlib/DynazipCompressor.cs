using System;
using System.IO;
using ACE.Dependency.zlibnet.Minizip;

namespace ACE.Dependency.zlibnet.zlib;

public static class DynazipCompressor
{
	public static bool IsDynazip(byte[] source)
	{
		if (source.Length >= 4)
		{
			return BitConverter.ToInt32(source, 0) == 33639248;
		}
		return false;
	}

	public static byte[] DeCompress(byte[] source)
	{
		if (!IsDynazip(source))
		{
			throw new InvalidDataException(Class16.smethod_0(1648887931));
		}
		MemoryStream memoryStream = new MemoryStream(source, 46, source.Length - 46);
		try
		{
			using MemoryStream memoryStream2 = smethod_0(memoryStream);
			return memoryStream2.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	private static MemoryStream smethod_0(Stream stream_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		smethod_1(stream_0, memoryStream);
		memoryStream.Position = 0L;
		return memoryStream;
	}

	private static void smethod_1(Stream stream_0, Stream stream_1)
	{
		DeflateStream deflateStream = new DeflateStream(stream_0, CompressionMode.Decompress, leaveOpen: true);
		try
		{
			deflateStream.CopyTo(stream_1);
		}
		finally
		{
			((IDisposable)deflateStream).Dispose();
		}
	}
}
