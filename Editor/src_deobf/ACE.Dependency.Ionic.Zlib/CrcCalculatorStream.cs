using System;
using System.IO;

namespace ACE.Dependency.Ionic.Zlib;

public class CrcCalculatorStream : Stream, IDisposable
{
	private static readonly long long_0 = -99L;

	internal Stream _innerStream;

	private CRC32 crc32_0;

	private long long_1 = -99L;

	private bool bool_0;

	public long TotalBytesSlurped => crc32_0.TotalBytesRead;

	public int Crc => crc32_0.Crc32Result;

	public bool LeaveOpen
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public override bool CanRead => _innerStream.CanRead;

	public override bool CanSeek => false;

	public override bool CanWrite => _innerStream.CanWrite;

	public override long Length
	{
		get
		{
			if (long_1 == long_0)
			{
				return _innerStream.Length;
			}
			return long_1;
		}
	}

	public override long Position
	{
		get
		{
			return crc32_0.TotalBytesRead;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public CrcCalculatorStream(Stream stream)
		: this(bool_1: true, long_0, stream, null)
	{
	}

	public CrcCalculatorStream(Stream stream, bool leaveOpen)
		: this(leaveOpen, long_0, stream, null)
	{
	}

	public CrcCalculatorStream(Stream stream, long length)
		: this(bool_1: true, length, stream, null)
	{
		if (length < 0L)
		{
			throw new ArgumentException(Class16.smethod_0(1648892538));
		}
	}

	public CrcCalculatorStream(Stream stream, long length, bool leaveOpen)
		: this(leaveOpen, length, stream, null)
	{
		if (length < 0L)
		{
			throw new ArgumentException(Class16.smethod_0(1648892538));
		}
	}

	public CrcCalculatorStream(Stream stream, long length, bool leaveOpen, CRC32 crc32)
		: this(leaveOpen, length, stream, crc32)
	{
		if (length < 0L)
		{
			throw new ArgumentException(Class16.smethod_0(1648892538));
		}
	}

	private CrcCalculatorStream(bool bool_1, long long_2, Stream stream_0, CRC32 crc32_1)
	{
		_innerStream = stream_0;
		crc32_0 = crc32_1 ?? new CRC32();
		long_1 = long_2;
		bool_0 = bool_1;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int count2 = count;
		if (long_1 != long_0)
		{
			if (crc32_0.TotalBytesRead >= long_1)
			{
				return 0;
			}
			long num = long_1 - crc32_0.TotalBytesRead;
			if (num < count)
			{
				count2 = (int)num;
			}
		}
		int num2 = _innerStream.Read(buffer, offset, count2);
		if (num2 > 0)
		{
			crc32_0.SlurpBlock(buffer, offset, num2);
		}
		return num2;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (count > 0)
		{
			crc32_0.SlurpBlock(buffer, offset, count);
		}
		_innerStream.Write(buffer, offset, count);
	}

	public override void Flush()
	{
		_innerStream.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	void IDisposable.Dispose()
	{
		Close();
	}

	public override void Close()
	{
		base.Close();
		if (!bool_0)
		{
			_innerStream.Close();
		}
	}
}
