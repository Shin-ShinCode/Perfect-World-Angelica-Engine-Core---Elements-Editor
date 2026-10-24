using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACE.Dependency.Ionic.Zlib;

internal class ZlibBaseStream : Stream
{
	internal enum StreamMode
	{
		Writer,
		Reader,
		Undefined
	}

	protected internal ZlibCodec _z;

	protected internal StreamMode _streamMode = StreamMode.Undefined;

	protected internal FlushType _flushMode;

	protected internal ZlibStreamFlavor _flavor;

	protected internal CompressionMode _compressionMode;

	protected internal CompressionLevel _level;

	protected internal bool _leaveOpen;

	protected internal byte[] _workingBuffer;

	protected internal int _bufferSize = 16384;

	protected internal byte[] _buf1 = new byte[1];

	protected internal Stream _stream;

	protected internal CompressionStrategy Strategy;

	private CRC32 crc32_0;

	protected internal string _GzipFileName;

	protected internal string _GzipComment;

	protected internal DateTime _GzipMtime;

	protected internal int _gzipHeaderByteCount;

	private bool bool_0;

	internal int Crc32
	{
		get
		{
			if (crc32_0 == null)
			{
				return 0;
			}
			return crc32_0.Crc32Result;
		}
	}

	protected internal bool _wantCompress => _compressionMode == CompressionMode.Compress;

	public override bool CanRead => _stream.CanRead;

	public override bool CanSeek => _stream.CanSeek;

	public override bool CanWrite => _stream.CanWrite;

	public override long Length => _stream.Length;

	public override long Position
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public ZlibBaseStream(Stream stream, CompressionMode compressionMode, CompressionLevel level, ZlibStreamFlavor flavor, bool leaveOpen)
	{
		_flushMode = FlushType.None;
		_stream = stream;
		_leaveOpen = leaveOpen;
		_compressionMode = compressionMode;
		_flavor = flavor;
		_level = level;
		if (flavor == ZlibStreamFlavor.GZIP)
		{
			crc32_0 = new CRC32();
		}
	}

	private ZlibCodec method_0()
	{
		if (_z == null)
		{
			bool flag = _flavor == ZlibStreamFlavor.ZLIB;
			_z = new ZlibCodec();
			if (_compressionMode == CompressionMode.Decompress)
			{
				_z.InitializeInflate(flag);
			}
			else
			{
				_z.Strategy = Strategy;
				_z.InitializeDeflate(_level, flag);
			}
		}
		return _z;
	}

	private byte[] method_1()
	{
		if (_workingBuffer == null)
		{
			_workingBuffer = new byte[_bufferSize];
		}
		return _workingBuffer;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (crc32_0 != null)
		{
			crc32_0.SlurpBlock(buffer, offset, count);
		}
		if (_streamMode == StreamMode.Undefined)
		{
			_streamMode = StreamMode.Writer;
		}
		else if (_streamMode != StreamMode.Writer)
		{
			throw new ZlibException(Class16.smethod_0(1648886857));
		}
		if (count == 0)
		{
			return;
		}
		method_0().InputBuffer = buffer;
		_z.NextIn = offset;
		_z.AvailableBytesIn = count;
		bool flag = false;
		while (true)
		{
			_z.OutputBuffer = method_1();
			_z.NextOut = 0;
			_z.AvailableBytesOut = _workingBuffer.Length;
			int num = ((!_wantCompress) ? _z.Inflate(_flushMode) : _z.Deflate(_flushMode));
			if (num != 0 && num != 1)
			{
				break;
			}
			_stream.Write(_workingBuffer, 0, _workingBuffer.Length - _z.AvailableBytesOut);
			flag = _z.AvailableBytesIn == 0 && _z.AvailableBytesOut != 0;
			if (_flavor == ZlibStreamFlavor.GZIP && !_wantCompress)
			{
				flag = _z.AvailableBytesIn == 8 && _z.AvailableBytesOut != 0;
			}
			if (flag)
			{
				return;
			}
		}
		throw new ZlibException((_wantCompress ? Class16.smethod_0(1648898033) : Class16.smethod_0(1648886891)) + Class16.smethod_0(1648886908) + _z.Message);
	}

	private void method_2()
	{
		if (_z == null)
		{
			return;
		}
		if (_streamMode == StreamMode.Writer)
		{
			bool flag = false;
			do
			{
				_z.OutputBuffer = method_1();
				_z.NextOut = 0;
				_z.AvailableBytesOut = _workingBuffer.Length;
				int num = ((!_wantCompress) ? _z.Inflate(FlushType.Finish) : _z.Deflate(FlushType.Finish));
				if (num == 1 || num == 0)
				{
					if (_workingBuffer.Length - _z.AvailableBytesOut > 0)
					{
						_stream.Write(_workingBuffer, 0, _workingBuffer.Length - _z.AvailableBytesOut);
					}
					flag = _z.AvailableBytesIn == 0 && _z.AvailableBytesOut != 0;
					if (_flavor == ZlibStreamFlavor.GZIP && !_wantCompress)
					{
						flag = _z.AvailableBytesIn == 8 && _z.AvailableBytesOut != 0;
					}
					continue;
				}
				string text = (_wantCompress ? Class16.smethod_0(1648898033) : Class16.smethod_0(1648886891)) + Class16.smethod_0(1648886924);
				if (_z.Message == null)
				{
					throw new ZlibException(string.Format(Class16.smethod_0(1648886930), text, num));
				}
				throw new ZlibException(text + Class16.smethod_0(1648908709) + _z.Message);
			}
			while (!flag);
			Flush();
			if (_flavor == ZlibStreamFlavor.GZIP)
			{
				if (!_wantCompress)
				{
					throw new ZlibException(Class16.smethod_0(1648886952));
				}
				int crc32Result = crc32_0.Crc32Result;
				_stream.Write(BitConverter.GetBytes(crc32Result), 0, 4);
				int value = (int)(crc32_0.TotalBytesRead & 0xFFFFFFFFL);
				_stream.Write(BitConverter.GetBytes(value), 0, 4);
			}
		}
		else
		{
			if (_streamMode != StreamMode.Reader || _flavor != ZlibStreamFlavor.GZIP)
			{
				return;
			}
			if (_wantCompress)
			{
				throw new ZlibException(Class16.smethod_0(1648887201));
			}
			if (_z.TotalBytesOut == 0L)
			{
				return;
			}
			byte[] array = new byte[8];
			if (_z.AvailableBytesIn < 8)
			{
				Array.Copy(_z.InputBuffer, _z.NextIn, array, 0, _z.AvailableBytesIn);
				int num2 = 8 - _z.AvailableBytesIn;
				int num3 = _stream.Read(array, _z.AvailableBytesIn, num2);
				if (num2 != num3)
				{
					throw new ZlibException(string.Format(Class16.smethod_0(1648887003), _z.AvailableBytesIn + num3));
				}
			}
			else
			{
				Array.Copy(_z.InputBuffer, _z.NextIn, array, 0, array.Length);
			}
			int num4 = BitConverter.ToInt32(array, 0);
			int crc32Result2 = crc32_0.Crc32Result;
			int num5 = BitConverter.ToInt32(array, 4);
			int num6 = (int)(_z.TotalBytesOut & 0xFFFFFFFFL);
			if (crc32Result2 != num4)
			{
				throw new ZlibException(string.Format(Class16.smethod_0(1648887072), crc32Result2, num4));
			}
			if (num6 != num5)
			{
				throw new ZlibException(string.Format(Class16.smethod_0(1648887148), num6, num5));
			}
		}
	}

	private void method_3()
	{
		if (method_0() != null)
		{
			if (_wantCompress)
			{
				_z.EndDeflate();
			}
			else
			{
				_z.EndInflate();
			}
			_z = null;
		}
	}

	public override void Close()
	{
		if (_stream == null)
		{
			return;
		}
		try
		{
			method_2();
		}
		finally
		{
			method_3();
			if (!_leaveOpen)
			{
				_stream.Close();
			}
			_stream = null;
		}
	}

	public override void Flush()
	{
		_stream.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		_stream.SetLength(value);
	}

	private string method_4()
	{
		List<byte> list = new List<byte>();
		bool flag = false;
		do
		{
			int num = _stream.Read(_buf1, 0, 1);
			if (num == 1)
			{
				if (_buf1[0] == 0)
				{
					flag = true;
				}
				else
				{
					list.Add(_buf1[0]);
				}
				continue;
			}
			throw new ZlibException(Class16.smethod_0(1648887250));
		}
		while (!flag);
		byte[] array = list.ToArray();
		return GZipStream.iso8859dash1.GetString(array, 0, array.Length);
	}

	private int method_5()
	{
		int num = 0;
		byte[] array = new byte[10];
		int num2 = _stream.Read(array, 0, array.Length);
		switch (num2)
		{
		case 0:
			return 0;
		default:
			throw new ZlibException(Class16.smethod_0(1648886276));
		case 10:
			if (array[0] == 31 && array[1] == 139 && array[2] == 8)
			{
				int num3 = BitConverter.ToInt32(array, 4);
				_GzipMtime = GZipStream._unixEpoch.AddSeconds(num3);
				num += num2;
				if ((array[3] & 4) == 4)
				{
					num2 = _stream.Read(array, 0, 2);
					num += num2;
					short num4 = (short)(array[0] + array[1] * 256);
					byte[] array2 = new byte[num4];
					num2 = _stream.Read(array2, 0, array2.Length);
					if (num2 != num4)
					{
						throw new ZlibException(Class16.smethod_0(1648886322));
					}
					num += num2;
				}
				if ((array[3] & 8) == 8)
				{
					_GzipFileName = method_4();
				}
				if ((array[3] & 0x10) == 16)
				{
					_GzipComment = method_4();
				}
				if ((array[3] & 2) == 2)
				{
					Read(_buf1, 0, 1);
				}
				return num;
			}
			throw new ZlibException(Class16.smethod_0(1648886299));
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (_streamMode == StreamMode.Undefined)
		{
			if (!_stream.CanRead)
			{
				throw new ZlibException(Class16.smethod_0(1648886380));
			}
			_streamMode = StreamMode.Reader;
			method_0().AvailableBytesIn = 0;
			if (_flavor == ZlibStreamFlavor.GZIP)
			{
				_gzipHeaderByteCount = method_5();
				if (_gzipHeaderByteCount == 0)
				{
					return 0;
				}
			}
		}
		if (_streamMode != StreamMode.Reader)
		{
			throw new ZlibException(Class16.smethod_0(1648886414));
		}
		if (count == 0)
		{
			return 0;
		}
		if (bool_0 && _wantCompress)
		{
			return 0;
		}
		if (buffer == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1648886447));
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException(Class16.smethod_0(1648886450));
		}
		if (offset < buffer.GetLowerBound(0))
		{
			throw new ArgumentOutOfRangeException(Class16.smethod_0(1648886469));
		}
		if (offset + count > buffer.GetLength(0))
		{
			throw new ArgumentOutOfRangeException(Class16.smethod_0(1648886472));
		}
		int num = 0;
		_z.OutputBuffer = buffer;
		_z.NextOut = offset;
		_z.AvailableBytesOut = count;
		_z.InputBuffer = method_1();
		do
		{
			if (_z.AvailableBytesIn == 0 && !bool_0)
			{
				_z.NextIn = 0;
				_z.AvailableBytesIn = _stream.Read(_workingBuffer, 0, _workingBuffer.Length);
				if (_z.AvailableBytesIn == 0)
				{
					bool_0 = true;
				}
			}
			num = (_wantCompress ? _z.Deflate(_flushMode) : _z.Inflate(_flushMode));
			if (!bool_0 || num != -5)
			{
				if (num != 0 && num != 1)
				{
					throw new ZlibException(string.Format(Class16.smethod_0(1648886483), _wantCompress ? Class16.smethod_0(1648898033) : Class16.smethod_0(1648886891), num, _z.Message));
				}
				continue;
			}
			return 0;
		}
		while (((!bool_0 && num != 1) || _z.AvailableBytesOut != count) && _z.AvailableBytesOut > 0 && !bool_0 && num == 0);
		if (_z.AvailableBytesOut > 0)
		{
			if (num != 0)
			{
			}
			if (bool_0 && _wantCompress)
			{
				num = _z.Deflate(FlushType.Finish);
				if (num != 0 && num != 1)
				{
					throw new ZlibException(string.Format(Class16.smethod_0(1648886526), num, _z.Message));
				}
			}
		}
		num = count - _z.AvailableBytesOut;
		if (crc32_0 != null)
		{
			crc32_0.SlurpBlock(buffer, offset, num);
		}
		return num;
	}

	public static void CompressString(string string_0, Stream compressor)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(string_0);
		using (compressor)
		{
			compressor.Write(bytes, 0, bytes.Length);
		}
	}

	public static void CompressBuffer(byte[] byte_0, Stream compressor)
	{
		using (compressor)
		{
			compressor.Write(byte_0, 0, byte_0.Length);
		}
	}

	public static string UncompressString(byte[] compressed, Stream decompressor)
	{
		byte[] array = new byte[1024];
		Encoding uTF = Encoding.UTF8;
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			using (decompressor)
			{
				int count;
				while ((count = decompressor.Read(array, 0, array.Length)) != 0)
				{
					memoryStream.Write(array, 0, count);
				}
			}
			memoryStream.Seek(0L, SeekOrigin.Begin);
			StreamReader streamReader = new StreamReader(memoryStream, uTF);
			return streamReader.ReadToEnd();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public static byte[] UncompressBuffer(byte[] compressed, Stream decompressor)
	{
		byte[] array = new byte[1024];
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			using (decompressor)
			{
				int count;
				while ((count = decompressor.Read(array, 0, array.Length)) != 0)
				{
					memoryStream.Write(array, 0, count);
				}
			}
			return memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}
}
