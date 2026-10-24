namespace ACE.Dependency.Ionic.Zlib;

internal sealed class InflateManager
{
	private enum Enum4
	{

	}

	private Enum4 enum4_0;

	internal ZlibCodec _codec;

	internal int method;

	internal uint computedCheck;

	internal uint expectedCheck;

	internal int marker;

	private bool bool_0 = true;

	internal int wbits;

	internal InflateBlocks blocks;

	private static readonly byte[] byte_0 = new byte[4] { 0, 0, 255, 255 };

	internal bool HandleRfc1950HeaderBytes
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

	public InflateManager()
	{
	}

	public InflateManager(bool expectRfc1950HeaderBytes)
	{
		bool_0 = expectRfc1950HeaderBytes;
	}

	internal int Reset()
	{
		ZlibCodec codec = _codec;
		_codec.TotalBytesOut = 0L;
		codec.TotalBytesIn = 0L;
		_codec.Message = null;
		enum4_0 = ((!HandleRfc1950HeaderBytes) ? ((Enum4)7) : ((Enum4)0));
		blocks.Reset();
		return 0;
	}

	internal int End()
	{
		if (blocks != null)
		{
			blocks.Free();
		}
		blocks = null;
		return 0;
	}

	internal int Initialize(ZlibCodec codec, int int_0)
	{
		_codec = codec;
		_codec.Message = null;
		blocks = null;
		if (int_0 >= 8 && int_0 <= 15)
		{
			wbits = int_0;
			blocks = new InflateBlocks(codec, HandleRfc1950HeaderBytes ? this : null, 1 << int_0);
			Reset();
			return 0;
		}
		End();
		throw new ZlibException(Class16.smethod_0(1648887495));
	}

	internal int Inflate(FlushType flush)
	{
		if (_codec.InputBuffer == null)
		{
			throw new ZlibException(Class16.smethod_0(1648887518));
		}
		int num = 0;
		int num2 = -5;
		while (true)
		{
			switch (enum4_0)
			{
			case (Enum4)11:
				if (_codec.AvailableBytesIn != 0)
				{
					num2 = num;
					_codec.AvailableBytesIn--;
					_codec.TotalBytesIn++;
					expectedCheck += (uint)(_codec.InputBuffer[_codec.NextIn++] & 0xFF);
					if (computedCheck != expectedCheck)
					{
						enum4_0 = (Enum4)13;
						_codec.Message = Class16.smethod_0(1648887643);
						marker = 5;
						break;
					}
					enum4_0 = (Enum4)12;
					return 1;
				}
				return num2;
			case (Enum4)10:
				if (_codec.AvailableBytesIn != 0)
				{
					num2 = num;
					_codec.AvailableBytesIn--;
					_codec.TotalBytesIn++;
					expectedCheck += (uint)((_codec.InputBuffer[_codec.NextIn++] << 8) & 0xFF00);
					enum4_0 = (Enum4)11;
					break;
				}
				return num2;
			case (Enum4)9:
				if (_codec.AvailableBytesIn != 0)
				{
					num2 = num;
					_codec.AvailableBytesIn--;
					_codec.TotalBytesIn++;
					expectedCheck += (uint)((_codec.InputBuffer[_codec.NextIn++] << 16) & 0xFF0000);
					enum4_0 = (Enum4)10;
					break;
				}
				return num2;
			case (Enum4)8:
				if (_codec.AvailableBytesIn != 0)
				{
					num2 = num;
					_codec.AvailableBytesIn--;
					_codec.TotalBytesIn++;
					expectedCheck = (uint)((_codec.InputBuffer[_codec.NextIn++] << 24) & 0xFF000000L);
					enum4_0 = (Enum4)9;
					break;
				}
				return num2;
			case (Enum4)7:
				num2 = blocks.Process(num2);
				switch (num2)
				{
				case -3:
					enum4_0 = (Enum4)13;
					marker = 0;
					goto end_IL_0605;
				case 0:
					num2 = num;
					break;
				}
				if (num2 == 1)
				{
					num2 = num;
					computedCheck = blocks.Reset();
					if (HandleRfc1950HeaderBytes)
					{
						enum4_0 = (Enum4)8;
						break;
					}
					enum4_0 = (Enum4)12;
					return 1;
				}
				return num2;
			case (Enum4)4:
				if (_codec.AvailableBytesIn != 0)
				{
					num2 = num;
					_codec.AvailableBytesIn--;
					_codec.TotalBytesIn++;
					expectedCheck += (uint)((_codec.InputBuffer[_codec.NextIn++] << 8) & 0xFF00);
					enum4_0 = (Enum4)5;
					break;
				}
				return num2;
			case (Enum4)3:
				if (_codec.AvailableBytesIn != 0)
				{
					num2 = num;
					_codec.AvailableBytesIn--;
					_codec.TotalBytesIn++;
					expectedCheck += (uint)((_codec.InputBuffer[_codec.NextIn++] << 16) & 0xFF0000);
					enum4_0 = (Enum4)4;
					break;
				}
				return num2;
			case (Enum4)2:
				if (_codec.AvailableBytesIn != 0)
				{
					num2 = num;
					_codec.AvailableBytesIn--;
					_codec.TotalBytesIn++;
					expectedCheck = (uint)((_codec.InputBuffer[_codec.NextIn++] << 24) & 0xFF000000L);
					enum4_0 = (Enum4)3;
					break;
				}
				return num2;
			case (Enum4)1:
				if (_codec.AvailableBytesIn != 0)
				{
					num2 = num;
					_codec.AvailableBytesIn--;
					_codec.TotalBytesIn++;
					int num3 = _codec.InputBuffer[_codec.NextIn++] & 0xFF;
					if (((method << 8) + num3) % 31 != 0)
					{
						enum4_0 = (Enum4)13;
						_codec.Message = Class16.smethod_0(1648887622);
						marker = 5;
					}
					else
					{
						enum4_0 = (((num3 & 0x20) == 0) ? ((Enum4)7) : ((Enum4)2));
					}
					break;
				}
				return num2;
			case (Enum4)0:
				if (_codec.AvailableBytesIn != 0)
				{
					num2 = num;
					_codec.AvailableBytesIn--;
					_codec.TotalBytesIn++;
					if (((method = _codec.InputBuffer[_codec.NextIn++]) & 0xF) != 8)
					{
						enum4_0 = (Enum4)13;
						_codec.Message = string.Format(Class16.smethod_0(1648887538), method);
						marker = 5;
					}
					else if ((method >> 4) + 8 > wbits)
					{
						enum4_0 = (Enum4)13;
						_codec.Message = string.Format(Class16.smethod_0(1648887590), (method >> 4) + 8);
						marker = 5;
					}
					else
					{
						enum4_0 = (Enum4)1;
					}
					break;
				}
				return num2;
			default:
				throw new ZlibException(Class16.smethod_0(1648892812));
			case (Enum4)5:
				if (_codec.AvailableBytesIn == 0)
				{
					return num2;
				}
				num2 = num;
				_codec.AvailableBytesIn--;
				_codec.TotalBytesIn++;
				expectedCheck += (uint)(_codec.InputBuffer[_codec.NextIn++] & 0xFF);
				_codec._Adler32 = expectedCheck;
				enum4_0 = (Enum4)6;
				return 2;
			case (Enum4)6:
				enum4_0 = (Enum4)13;
				_codec.Message = Class16.smethod_0(1648892559);
				marker = 0;
				return -2;
			case (Enum4)13:
				throw new ZlibException(string.Format(Class16.smethod_0(1648887678), _codec.Message));
			case (Enum4)12:
				{
					return 1;
				}
				end_IL_0605:
				break;
			}
		}
	}

	internal int SetDictionary(byte[] dictionary)
	{
		int start = 0;
		int num = dictionary.Length;
		if (enum4_0 != (Enum4)6)
		{
			throw new ZlibException(Class16.smethod_0(1648892812));
		}
		if (Adler.Adler32(1u, dictionary, 0, dictionary.Length) != _codec._Adler32)
		{
			return -3;
		}
		_codec._Adler32 = Adler.Adler32(0u, null, 0, 0);
		if (num >= 1 << wbits)
		{
			num = (1 << wbits) - 1;
			start = dictionary.Length - num;
		}
		blocks.SetDictionary(dictionary, start, num);
		enum4_0 = (Enum4)7;
		return 0;
	}

	internal int Sync()
	{
		if (enum4_0 != (Enum4)13)
		{
			enum4_0 = (Enum4)13;
			marker = 0;
		}
		int num;
		if ((num = _codec.AvailableBytesIn) == 0)
		{
			return -5;
		}
		int num2 = _codec.NextIn;
		int num3 = marker;
		while (num != 0 && num3 < 4)
		{
			num3 = ((_codec.InputBuffer[num2] != byte_0[num3]) ? ((_codec.InputBuffer[num2] == 0) ? (4 - num3) : 0) : (num3 + 1));
			num2++;
			num--;
		}
		_codec.TotalBytesIn += num2 - _codec.NextIn;
		_codec.NextIn = num2;
		_codec.AvailableBytesIn = num;
		marker = num3;
		if (num3 != 4)
		{
			return -3;
		}
		long totalBytesIn = _codec.TotalBytesIn;
		long totalBytesOut = _codec.TotalBytesOut;
		Reset();
		_codec.TotalBytesIn = totalBytesIn;
		_codec.TotalBytesOut = totalBytesOut;
		enum4_0 = (Enum4)7;
		return 0;
	}

	internal int SyncPoint(ZlibCodec zlibCodec_0)
	{
		return blocks.SyncPoint();
	}
}
