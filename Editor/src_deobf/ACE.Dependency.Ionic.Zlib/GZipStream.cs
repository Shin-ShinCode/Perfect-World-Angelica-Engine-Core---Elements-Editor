using System;
using System.IO;
using System.Text;

namespace ACE.Dependency.Ionic.Zlib;

public class GZipStream : Stream
{
	public DateTime? LastModified;

	private int int_0;

	internal ZlibBaseStream _baseStream;

	private bool bool_0;

	private bool bool_1;

	private string string_0;

	private string string_1;

	private int int_1;

	internal static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	internal static readonly Encoding iso8859dash1 = Encoding.GetEncoding(Class16.smethod_0(1648892075));

	public string Comment
	{
		get
		{
			return string_1;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException(Class16.smethod_0(1648892100));
			}
			string_1 = value;
		}
	}

	public string FileName
	{
		get
		{
			return string_0;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException(Class16.smethod_0(1648892100));
			}
			string_0 = value;
			if (string_0 != null)
			{
				if (string_0.IndexOf(Class16.smethod_0(1648892117)) != -1)
				{
					string_0 = string_0.Replace('/', '\\');
				}
				if (string_0.EndsWith(Class16.smethod_0(1648927580)))
				{
					throw new Exception(Class16.smethod_0(1648892125));
				}
				if (string_0.IndexOf(Class16.smethod_0(1648927580)) != -1)
				{
					string_0 = System.IO.Path.GetFileName(string_0);
				}
			}
		}
	}

	public int Crc32 => int_1;

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
				throw new ObjectDisposedException(Class16.smethod_0(1648892100));
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
				throw new ObjectDisposedException(Class16.smethod_0(1648892100));
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

	public virtual long TotalIn => _baseStream._z.TotalBytesIn;

	public virtual long TotalOut => _baseStream._z.TotalBytesOut;

	public override bool CanRead
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException(Class16.smethod_0(1648892100));
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
				throw new ObjectDisposedException(Class16.smethod_0(1648892100));
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
				return _baseStream._z.TotalBytesOut + int_0;
			}
			if (_baseStream._streamMode == ZlibBaseStream.StreamMode.Reader)
			{
				return _baseStream._z.TotalBytesIn + _baseStream._gzipHeaderByteCount;
			}
			return 0L;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public GZipStream(Stream stream, CompressionMode mode)
		: this(stream, mode, CompressionLevel.Default, leaveOpen: false)
	{
	}

	public GZipStream(Stream stream, CompressionMode mode, CompressionLevel level)
		: this(stream, mode, level, leaveOpen: false)
	{
	}

	public GZipStream(Stream stream, CompressionMode mode, bool leaveOpen)
		: this(stream, mode, CompressionLevel.Default, leaveOpen)
	{
	}

	public GZipStream(Stream stream, CompressionMode mode, CompressionLevel level, bool leaveOpen)
	{
		_baseStream = new ZlibBaseStream(stream, mode, level, ZlibStreamFlavor.GZIP, leaveOpen);
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
					int_1 = _baseStream.Crc32;
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
			throw new ObjectDisposedException(Class16.smethod_0(1648892100));
		}
		_baseStream.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException(Class16.smethod_0(1648892100));
		}
		int result = _baseStream.Read(buffer, offset, count);
		if (!bool_1)
		{
			bool_1 = true;
			FileName = _baseStream._GzipFileName;
			Comment = _baseStream._GzipComment;
		}
		return result;
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
			throw new ObjectDisposedException(Class16.smethod_0(1648892100));
		}
		if (_baseStream._streamMode == ZlibBaseStream.StreamMode.Undefined)
		{
			if (!_baseStream._wantCompress)
			{
				throw new InvalidOperationException();
			}
			int_0 = method_0();
		}
		_baseStream.Write(buffer, offset, count);
	}

	private int method_0()
	{
		byte[] array = ((Comment == null) ? null : iso8859dash1.GetBytes(Comment));
		byte[] array2 = ((FileName == null) ? null : iso8859dash1.GetBytes(FileName));
		int num = ((Comment != null) ? (array.Length + 1) : 0);
		int num2 = ((FileName != null) ? (array2.Length + 1) : 0);
		int num3 = 10 + num + num2;
		byte[] array3 = new byte[num3];
		int num4 = 0;
		num4 = 1;
		array3[0] = 31;
		num4 = 2;
		array3[1] = 139;
		num4 = 3;
		array3[2] = 8;
		byte b = 0;
		if (Comment != null)
		{
			b ^= 0x10;
		}
		if (FileName != null)
		{
			b ^= 8;
		}
		array3[num4++] = b;
		if (!LastModified.HasValue)
		{
			LastModified = DateTime.Now;
		}
		int value = (int)(LastModified.Value - _unixEpoch).TotalSeconds;
		Array.Copy(BitConverter.GetBytes(value), 0, array3, num4, 4);
		num4 += 4;
		array3[num4++] = 0;
		array3[num4++] = byte.MaxValue;
		if (num2 != 0)
		{
			Array.Copy(array2, 0, array3, num4, num2 - 1);
			num4 += num2 - 1;
			array3[num4++] = 0;
		}
		if (num != 0)
		{
			Array.Copy(array, 0, array3, num4, num - 1);
			num4 += num - 1;
			array3[num4++] = 0;
		}
		_baseStream._stream.Write(array3, 0, array3.Length);
		return array3.Length;
	}

	public static byte[] CompressString(string string_2)
	{
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			Stream compressor = new GZipStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
			ZlibBaseStream.CompressString(string_2, compressor);
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
			Stream compressor = new GZipStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
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
			Stream decompressor = new GZipStream(memoryStream, CompressionMode.Decompress);
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
			Stream decompressor = new GZipStream(memoryStream, CompressionMode.Decompress);
			return ZlibBaseStream.UncompressBuffer(compressed, decompressor);
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}
}
