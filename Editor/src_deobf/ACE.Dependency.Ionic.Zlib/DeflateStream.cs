using System;
using System.IO;

namespace ACE.Dependency.Ionic.Zlib;

public class DeflateStream : Stream
{
	internal ZlibBaseStream _baseStream;

	internal Stream _innerStream;

	private bool bool_0;

	public virtual FlushType FlushMode
	{
		get
		{
			return _baseStream._flushMode;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException(Class16.smethod_0(1648891945));
			}
			_baseStream._flushMode = value;
		}
	}

	public int BufferSize
	{
		get
		{
			return _baseStream._bufferSize;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException(Class16.smethod_0(1648891945));
			}
			if (_baseStream._workingBuffer != null)
			{
				throw new ZlibException(Class16.smethod_0(1648891973));
			}
			if (value < 1024)
			{
				throw new ZlibException(string.Format(Class16.smethod_0(1648892014), value, 1024));
			}
			_baseStream._bufferSize = value;
		}
	}

	public CompressionStrategy Strategy
	{
		get
		{
			return _baseStream.Strategy;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException(Class16.smethod_0(1648891945));
			}
			_baseStream.Strategy = value;
		}
	}

	public virtual long TotalIn => _baseStream._z.TotalBytesIn;

	public virtual long TotalOut => _baseStream._z.TotalBytesOut;

	public override bool CanRead
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException(Class16.smethod_0(1648891945));
			}
			return _baseStream._stream.CanRead;
		}
	}

	public override bool CanSeek => false;

	public override bool CanWrite
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException(Class16.smethod_0(1648891945));
			}
			return _baseStream._stream.CanWrite;
		}
	}

	public override long Length
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override long Position
	{
		get
		{
			if (_baseStream._streamMode == ZlibBaseStream.StreamMode.Writer)
			{
				return _baseStream._z.TotalBytesOut;
			}
			if (_baseStream._streamMode == ZlibBaseStream.StreamMode.Reader)
			{
				return _baseStream._z.TotalBytesIn;
			}
			return 0L;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public DeflateStream(Stream stream, CompressionMode mode)
		: this(stream, mode, CompressionLevel.Default, leaveOpen: false)
	{
	}

	public DeflateStream(Stream stream, CompressionMode mode, CompressionLevel level)
		: this(stream, mode, level, leaveOpen: false)
	{
	}

	public DeflateStream(Stream stream, CompressionMode mode, bool leaveOpen)
		: this(stream, mode, CompressionLevel.Default, leaveOpen)
	{
	}

	public DeflateStream(Stream stream, CompressionMode mode, CompressionLevel level, bool leaveOpen)
	{
		_innerStream = stream;
		_baseStream = new ZlibBaseStream(stream, mode, level, ZlibStreamFlavor.DEFLATE, leaveOpen);
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (!bool_0)
			{
				if (disposing && _baseStream != null)
				{
					_baseStream.Close();
				}
				bool_0 = true;
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	public override void Flush()
	{
		if (bool_0)
		{
			throw new ObjectDisposedException(Class16.smethod_0(1648891945));
		}
		_baseStream.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException(Class16.smethod_0(1648891945));
		}
		return _baseStream.Read(buffer, offset, count);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException(Class16.smethod_0(1648891945));
		}
		_baseStream.Write(buffer, offset, count);
	}

	public static byte[] CompressString(string string_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			Stream compressor = new DeflateStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
			ZlibBaseStream.CompressString(string_0, compressor);
			return memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public static byte[] CompressBuffer(byte[] byte_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			Stream compressor = new DeflateStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
			ZlibBaseStream.CompressBuffer(byte_0, compressor);
			return memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public static string UncompressString(byte[] compressed)
	{
		MemoryStream memoryStream = new MemoryStream(compressed);
		try
		{
			Stream decompressor = new DeflateStream(memoryStream, CompressionMode.Decompress);
			return ZlibBaseStream.UncompressString(compressed, decompressor);
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public static byte[] UncompressBuffer(byte[] compressed)
	{
		MemoryStream memoryStream = new MemoryStream(compressed);
		try
		{
			Stream decompressor = new DeflateStream(memoryStream, CompressionMode.Decompress);
			return ZlibBaseStream.UncompressBuffer(compressed, decompressor);
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}
}
