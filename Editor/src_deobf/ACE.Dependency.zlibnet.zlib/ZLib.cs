using System;
using System.Runtime.InteropServices;

namespace ACE.Dependency.zlibnet.zlib;

internal static class ZLib
{
	internal const string ZLibVersion = "1.2.8";

	internal const int MAX_WBITS = 15;

	internal const int DEF_MEM_LEVEL = 8;

	internal const int Z_DEFAULT_STRATEGY = 0;

	internal const uint VERSIONMADEBY = 0u;

	static ZLib()
	{
		DllLoader.Load();
	}

	[DllImport("zlib32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	private static extern int inflateInit2_(ref z_stream z_stream_0, int int_0, string string_0, int int_1);

	[DllImport("zlib64.dll", CharSet = CharSet.Ansi, EntryPoint = "inflateInit2_", ExactSpelling = true)]
	private static extern int inflateInit2__1(ref z_stream z_stream_0, int int_0, string string_0, int int_1);

	internal static int inflateInit(ref z_stream strm, ZLibOpenType windowBits)
	{
		if (ZLibDll.Is64)
		{
			return inflateInit2__1(ref strm, (int)windowBits, Class16.smethod_0(1648887964), Marshal.SizeOf(typeof(z_stream)));
		}
		return inflateInit2_(ref strm, (int)windowBits, Class16.smethod_0(1648887964), Marshal.SizeOf(typeof(z_stream)));
	}

	[DllImport("zlib32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	private static extern int deflateInit2_(ref z_stream z_stream_0, int int_0, int int_1, int int_2, int int_3, int int_4, string string_0, int int_5);

	[DllImport("zlib64.dll", CharSet = CharSet.Ansi, EntryPoint = "deflateInit2_", ExactSpelling = true)]
	private static extern int deflateInit2__1(ref z_stream z_stream_0, int int_0, int int_1, int int_2, int int_3, int int_4, string string_0, int int_5);

	internal static int deflateInit(ref z_stream strm, CompressionLevel level, ZLibWriteType windowBits)
	{
		if (ZLibDll.Is64)
		{
			return deflateInit2__1(ref strm, (int)level, 8, (int)windowBits, 8, 0, Class16.smethod_0(1648887964), Marshal.SizeOf(typeof(z_stream)));
		}
		return deflateInit2_(ref strm, (int)level, 8, (int)windowBits, 8, 0, Class16.smethod_0(1648887964), Marshal.SizeOf(typeof(z_stream)));
	}

	[DllImport("zlib32.dll", EntryPoint = "inflate", ExactSpelling = true)]
	private static extern int inflate_1(ref z_stream z_stream_0, ZLibFlush zlibFlush_0);

	[DllImport("zlib64.dll", EntryPoint = "inflate", ExactSpelling = true)]
	private static extern int inflate_2(ref z_stream z_stream_0, ZLibFlush zlibFlush_0);

	internal static int inflate(ref z_stream strm, ZLibFlush flush)
	{
		if (ZLibDll.Is64)
		{
			return inflate_2(ref strm, flush);
		}
		return inflate_1(ref strm, flush);
	}

	[DllImport("zlib32.dll", EntryPoint = "deflate", ExactSpelling = true)]
	private static extern int deflate_1(ref z_stream z_stream_0, ZLibFlush zlibFlush_0);

	[DllImport("zlib64.dll", EntryPoint = "deflate", ExactSpelling = true)]
	private static extern int deflate_2(ref z_stream z_stream_0, ZLibFlush zlibFlush_0);

	internal static int deflate(ref z_stream strm, ZLibFlush flush)
	{
		if (ZLibDll.Is64)
		{
			return deflate_2(ref strm, flush);
		}
		return deflate_1(ref strm, flush);
	}

	[DllImport("zlib32.dll", EntryPoint = "inflateEnd", ExactSpelling = true)]
	private static extern int inflateEnd_1(ref z_stream z_stream_0);

	[DllImport("zlib64.dll", EntryPoint = "inflateEnd", ExactSpelling = true)]
	private static extern int inflateEnd_2(ref z_stream z_stream_0);

	internal static int inflateEnd(ref z_stream strm)
	{
		if (ZLibDll.Is64)
		{
			return inflateEnd_2(ref strm);
		}
		return inflateEnd_1(ref strm);
	}

	[DllImport("zlib32.dll", EntryPoint = "deflateEnd", ExactSpelling = true)]
	private static extern int deflateEnd_1(ref z_stream z_stream_0);

	[DllImport("zlib64.dll", EntryPoint = "deflateEnd", ExactSpelling = true)]
	private static extern int deflateEnd_2(ref z_stream z_stream_0);

	internal static int deflateEnd(ref z_stream strm)
	{
		if (ZLibDll.Is64)
		{
			return deflateEnd_2(ref strm);
		}
		return deflateEnd_1(ref strm);
	}

	[DllImport("zlib32.dll", EntryPoint = "crc32", ExactSpelling = true)]
	private static extern uint crc32_1(uint uint_0, IntPtr intptr_0, uint uint_1);

	[DllImport("zlib64.dll", EntryPoint = "crc32", ExactSpelling = true)]
	private static extern uint crc32_2(uint uint_0, IntPtr intptr_0, uint uint_1);

	internal static uint crc32(uint crc, IntPtr buffer, uint len)
	{
		if (ZLibDll.Is64)
		{
			return crc32_2(crc, buffer, len);
		}
		return crc32_1(crc, buffer, len);
	}
}
