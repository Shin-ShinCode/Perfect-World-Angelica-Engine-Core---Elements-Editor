using System.IO;
using ACE.Dependency.zlibnet.Minizip;

namespace ACE.Dependency.zlibnet.zlib;

public static class DeflateCompressor
{
	private static class Class99
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
		return new DeflateStream(stream_0, compressionMode_0, bool_0);
	}

	private static DeflateStream smethod_1(Stream stream_0, CompressionMode compressionMode_0, bool bool_0)
	{
		return new ZLibStream(stream_0, compressionMode_0, bool_0);
	}

	public static byte[] CompressZlib(byte[] source)
	{
		return CommonCompressor.Compress(smethod_1, source);
	}

	public static byte[] DeCompressZlib(byte[] source)
	{
		return CommonCompressor.DeCompress(smethod_1, source);
	}
}
