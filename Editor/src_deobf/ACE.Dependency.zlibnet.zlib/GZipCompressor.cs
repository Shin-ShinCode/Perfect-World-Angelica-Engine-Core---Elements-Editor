using System.IO;
using ACE.Dependency.zlibnet.Minizip;

namespace ACE.Dependency.zlibnet.zlib;

public static class GZipCompressor
{
	private static class Class100
	{
		public static CreateStreamDelegate createStreamDelegate_0;
	}

	public static MemoryStream Compress(Stream source)
	{
		return CommonCompressor.Compress(smethod_0, source);
	}

	public static MemoryStream DeCompress(Stream source)
	{
		return CommonCompressor.DeCompress(smethod_0, source);
	}

	public static byte[] Compress(byte[] source)
	{
		return CommonCompressor.Compress(smethod_0, source);
	}

	public static byte[] DeCompress(byte[] source)
	{
		return CommonCompressor.DeCompress(smethod_0, source);
	}

	private static DeflateStream smethod_0(Stream stream_0, CompressionMode compressionMode_0, bool bool_0)
	{
		return new GZipStream(stream_0, compressionMode_0, bool_0);
	}
}
