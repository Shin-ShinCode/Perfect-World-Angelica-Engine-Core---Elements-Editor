using System;
using System.IO;

namespace ACE.Dependency.zlibnet.zlib;

public class CrcStream : Stream
{
	private uint uint_0;

	private Stream stream_0;

	public uint CRC32 => uint_0;

	public override bool CanRead => stream_0.CanRead;

	public override bool CanWrite => stream_0.CanWrite;

	public override bool CanSeek => stream_0.CanSeek;

	public Stream BaseStream => stream_0;

	public override long Length => stream_0.Length;

	public override long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			stream_0.Position = value;
		}
	}

	public CrcStream(Stream stream)
	{
		stream_0 = stream;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = stream_0.Read(buffer, offset, count);
		FixedArray fixedArray = new FixedArray(buffer);
		try
		{
			uint_0 = ZLib.crc32(uint_0, fixedArray[offset], (uint)num);
			return num;
		}
		finally
		{
			((IDisposable)fixedArray).Dispose();
		}
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		stream_0.Write(buffer, offset, count);
		FixedArray fixedArray = new FixedArray(buffer);
		try
		{
			uint_0 = ZLib.crc32(uint_0, fixedArray[offset], (uint)count);
		}
		finally
		{
			((IDisposable)fixedArray).Dispose();
		}
	}

	public override void Flush()
	{
		stream_0.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return stream_0.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		stream_0.SetLength(value);
	}
}
