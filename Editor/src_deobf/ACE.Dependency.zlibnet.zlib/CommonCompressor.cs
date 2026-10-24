using System;
using System.IO;
using ACE.Dependency.zlibnet.Minizip;

namespace ACE.Dependency.zlibnet.zlib;

internal class CommonCompressor
{
	private static void smethod_0(CreateStreamDelegate createStreamDelegate_0, Stream stream_0, Stream stream_1)
	{
		using DeflateStream destination = createStreamDelegate_0(stream_1, CompressionMode.Compress, leaveOpen: true);
		stream_0.CopyTo(destination);
	}

	private static void smethod_1(CreateStreamDelegate createStreamDelegate_0, Stream stream_0, Stream stream_1)
	{
		using DeflateStream deflateStream = createStreamDelegate_0(stream_0, CompressionMode.Decompress, leaveOpen: true);
		deflateStream.CopyTo(stream_1);
	}

	public static MemoryStream Compress(CreateStreamDelegate sc, Stream source)
	{
		MemoryStream memoryStream = new MemoryStream();
		smethod_0(sc, source, memoryStream);
		memoryStream.Position = 0L;
		return memoryStream;
	}

	public static MemoryStream DeCompress(CreateStreamDelegate sc, Stream source)
	{
		MemoryStream memoryStream = new MemoryStream();
		smethod_1(sc, source, memoryStream);
		memoryStream.Position = 0L;
		return memoryStream;
	}

	public static byte[] Compress(CreateStreamDelegate sc, byte[] source)
	{
		MemoryStream memoryStream = new MemoryStream(source);
		try
		{
			using MemoryStream memoryStream2 = Compress(sc, memoryStream);
			return memoryStream2.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public static byte[] DeCompress(CreateStreamDelegate sc, byte[] source)
	{
		MemoryStream memoryStream = new MemoryStream(source);
		try
		{
			using MemoryStream memoryStream2 = DeCompress(sc, memoryStream);
			return memoryStream2.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}
}
