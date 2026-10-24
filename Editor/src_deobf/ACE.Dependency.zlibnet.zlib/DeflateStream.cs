using System;
using System.IO;
using ACE.Dependency.zlibnet.Minizip;

namespace ACE.Dependency.zlibnet.zlib;

public class DeflateStream : Stream
{
	private long long_0;

	private long long_1;

	private bool bool_0;

	private byte[] byte_0 = new byte[4096];

	private int int_0;

	private Stream stream_0;

	private CompressionMode compressionMode_0;

	private z_stream z_stream_0;

	private bool bool_1;

	protected virtual ZLibOpenType OpenType => ZLibOpenType.Deflate;

	protected virtual ZLibWriteType WriteType => ZLibWriteType.Deflate;

	public long TotalIn => long_0;

	public long TotalOut => long_1;

	public double CompressionRatio
	{
		get
		{
			if (compressionMode_0 == CompressionMode.Compress)
			{
				if (long_0 != 0L)
				{
					return 100.0 - (double)long_1 * 100.0 / (double)long_0;
				}
				return 0.0;
			}
			if (long_1 != 0L)
			{
				return 100.0 - (double)long_0 * 100.0 / (double)long_1;
			}
			return 0.0;
		}
	}

	public override bool CanRead
	{
		get
		{
			if (compressionMode_0 == CompressionMode.Decompress)
			{
				return stream_0.CanRead;
			}
			return false;
		}
	}

	public override bool CanWrite
	{
		get
		{
			if (compressionMode_0 == CompressionMode.Compress)
			{
				return stream_0.CanWrite;
			}
			return false;
		}
	}

	public override bool CanSeek => false;

	public Stream BaseStream => stream_0;

	public override long Length
	{
		get
		{
			throw new NotSupportedException(Class16.smethod_0(1648887873));
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException(Class16.smethod_0(1648887909));
		}
		set
		{
			throw new NotSupportedException(Class16.smethod_0(1648887909));
		}
	}

	public DeflateStream(Stream stream, CompressionMode mode)
		: this(stream, mode, CompressionLevel.Default)
	{
	}

	public DeflateStream(Stream stream, CompressionMode mode, bool leaveOpen)
		: this(stream, mode, CompressionLevel.Default, leaveOpen)
	{
	}

	public DeflateStream(Stream stream, CompressionMode mode, CompressionLevel level)
		: this(stream, mode, level, leaveOpen: false)
	{
	}

	public DeflateStream(Stream stream, CompressionMode compMode, CompressionLevel level, bool leaveOpen)
	{
		bool_1 = leaveOpen;
		stream_0 = stream;
		compressionMode_0 = compMode;
		int num = ((compressionMode_0 != CompressionMode.Compress) ? ZLib.inflateInit(ref z_stream_0, OpenType) : ZLib.deflateInit(ref z_stream_0, level, WriteType));
		if (num != 0)
		{
			throw new ZLibException(num, z_stream_0.lasterrormsg);
		}
		bool_0 = true;
	}

	~DeflateStream()
	{
		Dispose(disposing: false);
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			try
			{
				if (disposing && stream_0 != null)
				{
					if (compressionMode_0 == CompressionMode.Compress && bool_0)
					{
						Flush();
					}
					if (!bool_1)
					{
						stream_0.Close();
					}
					stream_0 = null;
				}
			}
			finally
			{
				method_0();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void method_0()
	{
		if (compressionMode_0 == CompressionMode.Compress)
		{
			ZLib.deflateEnd(ref z_stream_0);
		}
		else
		{
			ZLib.inflateEnd(ref z_stream_0);
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (compressionMode_0 == CompressionMode.Compress)
		{
			throw new NotSupportedException(Class16.smethod_0(1648888724));
		}
		int num = 0;
		if (int_0 != -1)
		{
			FixedArray fixedArray = new FixedArray(byte_0);
			try
			{
				FixedArray fixedArray2 = new FixedArray(buffer);
				try
				{
					z_stream_0.next_in = fixedArray[int_0];
					z_stream_0.next_out = fixedArray2[offset];
					z_stream_0.avail_out = (uint)count;
					while (z_stream_0.avail_out != 0)
					{
						if (z_stream_0.avail_in == 0)
						{
							int_0 = 0;
							z_stream_0.next_in = fixedArray;
							z_stream_0.avail_in = (uint)stream_0.Read(byte_0, 0, 4096);
							long_0 += z_stream_0.avail_in;
						}
						uint avail_in = z_stream_0.avail_in;
						uint avail_out = z_stream_0.avail_out;
						int num2 = ZLib.inflate(ref z_stream_0, ZLibFlush.NoFlush);
						int_0 += (int)(avail_in - z_stream_0.avail_in);
						num += (int)(avail_out - z_stream_0.avail_out);
						if (num2 != 1)
						{
							if (num2 != 0)
							{
								bool_0 = false;
								throw new ZLibException(num2, z_stream_0.lasterrormsg);
							}
							continue;
						}
						int_0 = -1;
						break;
					}
					long_1 += num;
				}
				finally
				{
					((IDisposable)fixedArray2).Dispose();
				}
			}
			finally
			{
				((IDisposable)fixedArray).Dispose();
			}
		}
		return num;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (compressionMode_0 == CompressionMode.Decompress)
		{
			throw new NotSupportedException(Class16.smethod_0(1648888755));
		}
		long_0 += count;
		FixedArray fixedArray = new FixedArray(byte_0);
		try
		{
			FixedArray fixedArray2 = new FixedArray(buffer);
			try
			{
				z_stream_0.next_in = fixedArray2[offset];
				z_stream_0.avail_in = (uint)count;
				z_stream_0.next_out = fixedArray[int_0];
				z_stream_0.avail_out = (uint)(4096 - int_0);
				int num;
				do
				{
					if (z_stream_0.avail_in != 0)
					{
						if (z_stream_0.avail_out == 0)
						{
							stream_0.Write(byte_0, 0, 4096);
							long_1 += 4096L;
							int_0 = 0;
							z_stream_0.next_out = fixedArray;
							z_stream_0.avail_out = 4096u;
						}
						uint avail_out = z_stream_0.avail_out;
						num = ZLib.deflate(ref z_stream_0, ZLibFlush.NoFlush);
						int_0 += (int)(avail_out - z_stream_0.avail_out);
						continue;
					}
					return;
				}
				while (num == 0);
				bool_0 = false;
				throw new ZLibException(num, z_stream_0.lasterrormsg);
			}
			finally
			{
				((IDisposable)fixedArray2).Dispose();
			}
		}
		finally
		{
			((IDisposable)fixedArray).Dispose();
		}
	}

	public override void Flush()
	{
		if (compressionMode_0 == CompressionMode.Decompress)
		{
			throw new NotSupportedException(Class16.smethod_0(1648888800));
		}
		FixedArray fixedArray = new FixedArray(byte_0);
		try
		{
			z_stream_0.next_in = IntPtr.Zero;
			z_stream_0.avail_in = 0u;
			z_stream_0.next_out = fixedArray[int_0];
			z_stream_0.avail_out = (uint)(4096 - int_0);
			int num = 0;
			while (num != 1)
			{
				if (z_stream_0.avail_out != 0)
				{
					uint avail_out = z_stream_0.avail_out;
					num = ZLib.deflate(ref z_stream_0, ZLibFlush.Finish);
					int_0 += (int)(avail_out - z_stream_0.avail_out);
					if (num != 1 && num != 0)
					{
						bool_0 = false;
						throw new ZLibException(num, z_stream_0.lasterrormsg);
					}
				}
				stream_0.Write(byte_0, 0, int_0);
				long_1 += int_0;
				int_0 = 0;
				z_stream_0.next_out = fixedArray;
				z_stream_0.avail_out = 4096u;
			}
		}
		finally
		{
			((IDisposable)fixedArray).Dispose();
		}
		stream_0.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException(Class16.smethod_0(1648887818));
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException(Class16.smethod_0(1648887843));
	}
}
