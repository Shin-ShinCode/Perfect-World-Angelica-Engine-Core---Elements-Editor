using System;

namespace ACE.Dependency.Ionic.Zlib;

internal sealed class InflateBlocks
{
	private enum Enum3
	{

	}

	internal static readonly int[] border = new int[19]
	{
		16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
		11, 4, 12, 3, 13, 2, 14, 1, 15
	};

	private Enum3 enum3_0;

	internal int left;

	internal int table;

	internal int index;

	internal int[] blens;

	internal int[] bb = new int[1];

	internal int[] tb = new int[1];

	internal InflateCodes codes = new InflateCodes();

	internal int last;

	internal ZlibCodec _codec;

	internal int bitk;

	internal int bitb;

	internal int[] hufts;

	internal byte[] window;

	internal int end;

	internal int readAt;

	internal int writeAt;

	internal object checkfn;

	internal uint check;

	internal InfTree inftree = new InfTree();

	internal InflateBlocks(ZlibCodec codec, object checkfn, int int_0)
	{
		_codec = codec;
		hufts = new int[4320];
		window = new byte[int_0];
		end = int_0;
		this.checkfn = checkfn;
		enum3_0 = (Enum3)0;
		Reset();
	}

	internal uint Reset()
	{
		uint result = check;
		enum3_0 = (Enum3)0;
		bitk = 0;
		bitb = 0;
		writeAt = 0;
		readAt = 0;
		if (checkfn != null)
		{
			_codec._Adler32 = (check = Adler.Adler32(0u, null, 0, 0));
		}
		return result;
	}

	internal int Process(int int_0)
	{
		int num = _codec.NextIn;
		int num2 = _codec.AvailableBytesIn;
		int num3 = bitb;
		int i = bitk;
		int num4 = writeAt;
		int num5 = ((num4 < readAt) ? (readAt - num4 - 1) : (end - num4));
		while (true)
		{
			switch (enum3_0)
			{
			case (Enum3)6:
				bitb = num3;
				bitk = i;
				_codec.AvailableBytesIn = num2;
				_codec.TotalBytesIn += num - _codec.NextIn;
				_codec.NextIn = num;
				writeAt = num4;
				int_0 = codes.Process(this, int_0);
				if (int_0 == 1)
				{
					int_0 = 0;
					num = _codec.NextIn;
					num2 = _codec.AvailableBytesIn;
					num3 = bitb;
					i = bitk;
					num4 = writeAt;
					num5 = ((num4 < readAt) ? (readAt - num4 - 1) : (end - num4));
					if (last == 0)
					{
						enum3_0 = (Enum3)0;
						break;
					}
					enum3_0 = (Enum3)7;
					goto case (Enum3)7;
				}
				return Flush(int_0);
			case (Enum3)5:
			{
				int num6;
				while (true)
				{
					num6 = table;
					if (index >= 258 + (num6 & 0x1F) + ((num6 >> 5) & 0x1F))
					{
						break;
					}
					for (num6 = bb[0]; i < num6; i += 8)
					{
						if (num2 != 0)
						{
							int_0 = 0;
							num2--;
							num3 |= (_codec.InputBuffer[num++] & 0xFF) << i;
							continue;
						}
						bitb = num3;
						bitk = i;
						_codec.AvailableBytesIn = num2;
						_codec.TotalBytesIn += num - _codec.NextIn;
						_codec.NextIn = num;
						writeAt = num4;
						return Flush(int_0);
					}
					num6 = hufts[(tb[0] + (num3 & InternalInflateConstants.InflateMask[num6])) * 3 + 1];
					int num7 = hufts[(tb[0] + (num3 & InternalInflateConstants.InflateMask[num6])) * 3 + 2];
					if (num7 < 16)
					{
						num3 >>= num6;
						i -= num6;
						blens[index++] = num7;
						continue;
					}
					int num8 = ((num7 == 18) ? 7 : (num7 - 14));
					int num9 = ((num7 == 18) ? 11 : 3);
					for (; i < num6 + num8; i += 8)
					{
						if (num2 != 0)
						{
							int_0 = 0;
							num2--;
							num3 |= (_codec.InputBuffer[num++] & 0xFF) << i;
							continue;
						}
						bitb = num3;
						bitk = i;
						_codec.AvailableBytesIn = num2;
						_codec.TotalBytesIn += num - _codec.NextIn;
						_codec.NextIn = num;
						writeAt = num4;
						return Flush(int_0);
					}
					num3 >>= num6;
					i -= num6;
					num9 += num3 & InternalInflateConstants.InflateMask[num8];
					num3 >>= num8;
					i -= num8;
					num8 = index;
					num6 = table;
					if (num8 + num9 <= 258 + (num6 & 0x1F) + ((num6 >> 5) & 0x1F) && (num7 != 16 || num8 >= 1))
					{
						num7 = ((num7 == 16) ? blens[num8 - 1] : 0);
						do
						{
							blens[num8++] = num7;
						}
						while (--num9 != 0);
						index = num8;
						continue;
					}
					blens = null;
					enum3_0 = (Enum3)9;
					_codec.Message = Class16.smethod_0(1648887393);
					int_0 = -3;
					bitb = num3;
					bitk = i;
					_codec.AvailableBytesIn = num2;
					_codec.TotalBytesIn += num - _codec.NextIn;
					_codec.NextIn = num;
					writeAt = num4;
					return Flush(-3);
				}
				tb[0] = -1;
				int[] array5 = new int[1] { 9 };
				int[] array6 = new int[1] { 6 };
				int[] array7 = new int[1];
				int[] array8 = new int[1];
				num6 = table;
				num6 = inftree.inflate_trees_dynamic(257 + (num6 & 0x1F), 1 + ((num6 >> 5) & 0x1F), blens, array5, array6, array7, array8, hufts, _codec);
				if (num6 == 0)
				{
					codes.Init(array5[0], array6[0], hufts, array7[0], hufts, array8[0]);
					enum3_0 = (Enum3)6;
					goto case (Enum3)6;
				}
				if (num6 == -3)
				{
					blens = null;
					enum3_0 = (Enum3)9;
				}
				int_0 = num6;
				bitb = num3;
				bitk = i;
				_codec.AvailableBytesIn = num2;
				_codec.TotalBytesIn += num - _codec.NextIn;
				_codec.NextIn = num;
				writeAt = num4;
				return Flush(int_0);
			}
			case (Enum3)4:
			{
				while (index < 4 + (table >> 10))
				{
					for (; i < 3; i += 8)
					{
						if (num2 != 0)
						{
							int_0 = 0;
							num2--;
							num3 |= (_codec.InputBuffer[num++] & 0xFF) << i;
							continue;
						}
						bitb = num3;
						bitk = i;
						_codec.AvailableBytesIn = num2;
						_codec.TotalBytesIn += num - _codec.NextIn;
						_codec.NextIn = num;
						writeAt = num4;
						return Flush(int_0);
					}
					blens[border[index++]] = num3 & 7;
					num3 >>= 3;
					i -= 3;
				}
				while (index < 19)
				{
					blens[border[index++]] = 0;
				}
				bb[0] = 7;
				int num6 = inftree.inflate_trees_bits(blens, bb, tb, hufts, _codec);
				if (num6 == 0)
				{
					index = 0;
					enum3_0 = (Enum3)5;
					goto case (Enum3)5;
				}
				int_0 = num6;
				if (int_0 == -3)
				{
					blens = null;
					enum3_0 = (Enum3)9;
				}
				bitb = num3;
				bitk = i;
				_codec.AvailableBytesIn = num2;
				_codec.TotalBytesIn += num - _codec.NextIn;
				_codec.NextIn = num;
				writeAt = num4;
				return Flush(int_0);
			}
			case (Enum3)3:
			{
				for (; i < 14; i += 8)
				{
					if (num2 != 0)
					{
						int_0 = 0;
						num2--;
						num3 |= (_codec.InputBuffer[num++] & 0xFF) << i;
						continue;
					}
					bitb = num3;
					bitk = i;
					_codec.AvailableBytesIn = num2;
					_codec.TotalBytesIn += num - _codec.NextIn;
					_codec.NextIn = num;
					writeAt = num4;
					return Flush(int_0);
				}
				int num6 = (table = num3 & 0x3FFF);
				if ((num6 & 0x1F) <= 29 && ((num6 >> 5) & 0x1F) <= 29)
				{
					num6 = 258 + (num6 & 0x1F) + ((num6 >> 5) & 0x1F);
					if (blens != null && blens.Length >= num6)
					{
						Array.Clear(blens, 0, num6);
					}
					else
					{
						blens = new int[num6];
					}
					num3 >>= 14;
					i -= 14;
					index = 0;
					enum3_0 = (Enum3)4;
					goto case (Enum3)4;
				}
				enum3_0 = (Enum3)9;
				_codec.Message = Class16.smethod_0(1648887359);
				int_0 = -3;
				bitb = num3;
				bitk = i;
				_codec.AvailableBytesIn = num2;
				_codec.TotalBytesIn += num - _codec.NextIn;
				_codec.NextIn = num;
				writeAt = num4;
				return Flush(-3);
			}
			case (Enum3)2:
				if (num2 != 0)
				{
					if (num5 == 0)
					{
						if (num4 == end && readAt != 0)
						{
							num4 = 0;
							num5 = ((0 < readAt) ? (readAt - num4 - 1) : (end - num4));
						}
						if (num5 == 0)
						{
							writeAt = num4;
							int_0 = Flush(int_0);
							num4 = writeAt;
							num5 = ((num4 < readAt) ? (readAt - num4 - 1) : (end - num4));
							if (num4 == end && readAt != 0)
							{
								num4 = 0;
								num5 = ((0 < readAt) ? (readAt - num4 - 1) : (end - num4));
							}
							if (num5 == 0)
							{
								bitb = num3;
								bitk = i;
								_codec.AvailableBytesIn = num2;
								_codec.TotalBytesIn += num - _codec.NextIn;
								_codec.NextIn = num;
								writeAt = num4;
								return Flush(int_0);
							}
						}
					}
					int_0 = 0;
					int num6 = left;
					if (num6 > num2)
					{
						num6 = num2;
					}
					if (num6 > num5)
					{
						num6 = num5;
					}
					Array.Copy(_codec.InputBuffer, num, window, num4, num6);
					num += num6;
					num2 -= num6;
					num4 += num6;
					num5 -= num6;
					if ((left -= num6) == 0)
					{
						enum3_0 = ((last != 0) ? ((Enum3)7) : ((Enum3)0));
					}
					break;
				}
				bitb = num3;
				bitk = i;
				_codec.AvailableBytesIn = num2;
				_codec.TotalBytesIn += num - _codec.NextIn;
				_codec.NextIn = num;
				writeAt = num4;
				return Flush(int_0);
			case (Enum3)1:
				for (; i < 32; i += 8)
				{
					if (num2 != 0)
					{
						int_0 = 0;
						num2--;
						num3 |= (_codec.InputBuffer[num++] & 0xFF) << i;
						continue;
					}
					bitb = num3;
					bitk = i;
					_codec.AvailableBytesIn = num2;
					_codec.TotalBytesIn += num - _codec.NextIn;
					_codec.NextIn = num;
					writeAt = num4;
					return Flush(int_0);
				}
				if (((~num3 >> 16) & 0xFFFF) == (num3 & 0xFFFF))
				{
					left = num3 & 0xFFFF;
					i = 0;
					num3 = 0;
					enum3_0 = ((left != 0) ? ((Enum3)2) : ((last != 0) ? ((Enum3)7) : ((Enum3)0)));
					break;
				}
				enum3_0 = (Enum3)9;
				_codec.Message = Class16.smethod_0(1648887324);
				int_0 = -3;
				bitb = num3;
				bitk = i;
				_codec.AvailableBytesIn = num2;
				_codec.TotalBytesIn += num - _codec.NextIn;
				_codec.NextIn = num;
				writeAt = num4;
				return Flush(-3);
			case (Enum3)0:
			{
				for (; i < 3; i += 8)
				{
					if (num2 != 0)
					{
						int_0 = 0;
						num2--;
						num3 |= (_codec.InputBuffer[num++] & 0xFF) << i;
						continue;
					}
					bitb = num3;
					bitk = i;
					_codec.AvailableBytesIn = num2;
					_codec.TotalBytesIn += num - _codec.NextIn;
					_codec.NextIn = num;
					writeAt = num4;
					return Flush(int_0);
				}
				int num6 = num3 & 7;
				last = num6 & 1;
				switch ((uint)(num6 >>> 1))
				{
				case 0u:
					num3 >>= 3;
					i -= 3;
					num6 = i & 7;
					num3 >>= num6;
					i -= num6;
					enum3_0 = (Enum3)1;
					break;
				case 1u:
				{
					int[] array = new int[1];
					int[] array2 = new int[1];
					int[][] array3 = new int[1][];
					int[][] array4 = new int[1][];
					InfTree.inflate_trees_fixed(array, array2, array3, array4, _codec);
					codes.Init(array[0], array2[0], array3[0], 0, array4[0], 0);
					num3 >>= 3;
					i -= 3;
					enum3_0 = (Enum3)6;
					break;
				}
				case 2u:
					num3 >>= 3;
					i -= 3;
					enum3_0 = (Enum3)3;
					break;
				case 3u:
					num3 >>= 3;
					i -= 3;
					enum3_0 = (Enum3)9;
					_codec.Message = Class16.smethod_0(1648892411);
					int_0 = -3;
					bitb = num3;
					bitk = i;
					_codec.AvailableBytesIn = num2;
					_codec.TotalBytesIn += num - _codec.NextIn;
					_codec.NextIn = num;
					writeAt = num4;
					return Flush(-3);
				}
				break;
			}
			default:
				int_0 = -2;
				bitb = num3;
				bitk = i;
				_codec.AvailableBytesIn = num2;
				_codec.TotalBytesIn += num - _codec.NextIn;
				_codec.NextIn = num;
				writeAt = num4;
				return Flush(-2);
			case (Enum3)7:
				writeAt = num4;
				int_0 = Flush(int_0);
				num4 = writeAt;
				num5 = ((num4 < readAt) ? (readAt - num4 - 1) : (end - num4));
				if (readAt != writeAt)
				{
					bitb = num3;
					bitk = i;
					_codec.AvailableBytesIn = num2;
					_codec.TotalBytesIn += num - _codec.NextIn;
					_codec.NextIn = num;
					writeAt = num4;
					return Flush(int_0);
				}
				enum3_0 = (Enum3)8;
				goto case (Enum3)8;
			case (Enum3)8:
				int_0 = 1;
				bitb = num3;
				bitk = i;
				_codec.AvailableBytesIn = num2;
				_codec.TotalBytesIn += num - _codec.NextIn;
				_codec.NextIn = num;
				writeAt = num4;
				return Flush(1);
			case (Enum3)9:
				int_0 = -3;
				bitb = num3;
				bitk = i;
				_codec.AvailableBytesIn = num2;
				_codec.TotalBytesIn += num - _codec.NextIn;
				_codec.NextIn = num;
				writeAt = num4;
				return Flush(-3);
			}
		}
	}

	internal void Free()
	{
		Reset();
		window = null;
		hufts = null;
	}

	internal void SetDictionary(byte[] byte_0, int start, int int_0)
	{
		Array.Copy(byte_0, start, window, 0, int_0);
		readAt = (writeAt = int_0);
	}

	internal int SyncPoint()
	{
		return (enum3_0 == (Enum3)1) ? 1 : 0;
	}

	internal int Flush(int int_0)
	{
		int num = 0;
		while (true)
		{
			if (num >= 2)
			{
				return int_0;
			}
			int num2 = ((num != 0) ? (writeAt - readAt) : (((readAt <= writeAt) ? writeAt : end) - readAt));
			if (num2 == 0)
			{
				break;
			}
			if (num2 > _codec.AvailableBytesOut)
			{
				num2 = _codec.AvailableBytesOut;
			}
			if (num2 != 0 && int_0 == -5)
			{
				int_0 = 0;
			}
			_codec.AvailableBytesOut -= num2;
			_codec.TotalBytesOut += num2;
			if (checkfn != null)
			{
				_codec._Adler32 = (check = Adler.Adler32(check, window, readAt, num2));
			}
			Array.Copy(window, readAt, _codec.OutputBuffer, _codec.NextOut, num2);
			_codec.NextOut += num2;
			readAt += num2;
			if (readAt == end && num == 0)
			{
				readAt = 0;
				if (writeAt == end)
				{
					writeAt = 0;
				}
			}
			else
			{
				num++;
			}
			num++;
		}
		if (int_0 == -5)
		{
			int_0 = 0;
		}
		return int_0;
	}
}
