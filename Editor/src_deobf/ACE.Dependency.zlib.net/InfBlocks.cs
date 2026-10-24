using System;

namespace ACE.Dependency.zlib.net;

internal sealed class InfBlocks
{
	private static readonly int[] int_0 = new int[17]
	{
		0, 1, 3, 7, 15, 31, 63, 127, 255, 511,
		1023, 2047, 4095, 8191, 16383, 32767, 65535
	};

	internal static readonly int[] border = new int[19]
	{
		16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
		11, 4, 12, 3, 13, 2, 14, 1, 15
	};

	internal int mode;

	internal int left;

	internal int table;

	internal int index;

	internal int[] blens;

	internal int[] bb = new int[1];

	internal int[] tb = new int[1];

	internal InfCodes codes;

	internal int last;

	internal int bitk;

	internal int bitb;

	internal int[] hufts;

	internal byte[] window;

	internal int end;

	internal int read;

	internal int write;

	internal object checkfn;

	internal long check;

	// TODO(recovered): ILSpy rendered set_dictionary(byte[], int, int) as a property setter,
	// dropping its two extra parameters (byte_0, start) so they appeared undefined. Restored
	// as the method its call site (blocks.set_dictionary(dictionary, start, num)) expects.
	internal void set_dictionary(byte[] byte_0, int start, int value)
	{
		Array.Copy(byte_0, start, window, 0, value);
		read = (write = value);
	}

	internal InfBlocks(ZStream zstream_0, object checkfn, int int_1)
	{
		hufts = new int[4320];
		window = new byte[int_1];
		end = int_1;
		this.checkfn = checkfn;
		mode = 0;
		reset(zstream_0, null);
	}

	internal void reset(ZStream zstream_0, long[] long_0)
	{
		if (long_0 != null)
		{
			long_0[0] = check;
		}
		if (mode == 4 || mode == 5)
		{
			blens = null;
		}
		if (mode == 6)
		{
			codes.free(zstream_0);
		}
		mode = 0;
		bitk = 0;
		bitb = 0;
		write = 0;
		read = 0;
		if (checkfn != null)
		{
			zstream_0.adler = (check = zstream_0._adler.adler32(0L, null, 0, 0));
		}
	}

	internal int proc(ZStream zstream_0, int int_1)
	{
		int num = zstream_0.next_in_index;
		int num2 = zstream_0.avail_in;
		int num3 = bitb;
		int i = bitk;
		int num4 = write;
		int num5 = ((num4 < read) ? (read - num4 - 1) : (end - num4));
		while (true)
		{
			switch (mode)
			{
			case 6:
				bitb = num3;
				bitk = i;
				zstream_0.avail_in = num2;
				zstream_0.total_in += num - zstream_0.next_in_index;
				zstream_0.next_in_index = num;
				write = num4;
				if ((int_1 = codes.proc(this, zstream_0, int_1)) == 1)
				{
					int_1 = 0;
					codes.free(zstream_0);
					num = zstream_0.next_in_index;
					num2 = zstream_0.avail_in;
					num3 = bitb;
					i = bitk;
					num4 = write;
					num5 = ((num4 < read) ? (read - num4 - 1) : (end - num4));
					if (last == 0)
					{
						mode = 0;
						break;
					}
					mode = 7;
					goto case 7;
				}
				return inflate_flush(zstream_0, int_1);
			case 5:
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
							int_1 = 0;
							num2--;
							num3 |= (zstream_0.next_in[num++] & 0xFF) << i;
							continue;
						}
						bitb = num3;
						bitk = i;
						zstream_0.avail_in = num2;
						zstream_0.total_in += num - zstream_0.next_in_index;
						zstream_0.next_in_index = num;
						write = num4;
						return inflate_flush(zstream_0, int_1);
					}
					num6 = hufts[(tb[0] + (num3 & int_0[num6])) * 3 + 1];
					int num7 = hufts[(tb[0] + (num3 & int_0[num6])) * 3 + 2];
					if (num7 < 16)
					{
						num3 = SupportClass.URShift(num3, num6);
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
							int_1 = 0;
							num2--;
							num3 |= (zstream_0.next_in[num++] & 0xFF) << i;
							continue;
						}
						bitb = num3;
						bitk = i;
						zstream_0.avail_in = num2;
						zstream_0.total_in += num - zstream_0.next_in_index;
						zstream_0.next_in_index = num;
						write = num4;
						return inflate_flush(zstream_0, int_1);
					}
					num3 = SupportClass.URShift(num3, num6);
					i -= num6;
					num9 += num3 & int_0[num8];
					num3 = SupportClass.URShift(num3, num8);
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
					mode = 9;
					zstream_0.msg = Class16.smethod_0(1648887393);
					int_1 = -3;
					bitb = num3;
					bitk = i;
					zstream_0.avail_in = num2;
					zstream_0.total_in += num - zstream_0.next_in_index;
					zstream_0.next_in_index = num;
					write = num4;
					return inflate_flush(zstream_0, -3);
				}
				tb[0] = -1;
				int[] array5 = new int[1];
				int[] array6 = new int[1];
				int[] array7 = new int[1];
				int[] array8 = new int[1];
				array5[0] = 9;
				array6[0] = 6;
				num6 = table;
				num6 = InfTree.inflate_trees_dynamic(257 + (num6 & 0x1F), 1 + ((num6 >> 5) & 0x1F), blens, array5, array6, array7, array8, hufts, zstream_0);
				if (num6 == 0)
				{
					codes = new InfCodes(array5[0], array6[0], hufts, array7[0], hufts, array8[0], zstream_0);
					blens = null;
					mode = 6;
					goto case 6;
				}
				if (num6 == -3)
				{
					blens = null;
					mode = 9;
				}
				int_1 = num6;
				bitb = num3;
				bitk = i;
				zstream_0.avail_in = num2;
				zstream_0.total_in += num - zstream_0.next_in_index;
				zstream_0.next_in_index = num;
				write = num4;
				return inflate_flush(zstream_0, int_1);
			}
			case 4:
			{
				while (index < 4 + SupportClass.URShift(table, 10))
				{
					for (; i < 3; i += 8)
					{
						if (num2 != 0)
						{
							int_1 = 0;
							num2--;
							num3 |= (zstream_0.next_in[num++] & 0xFF) << i;
							continue;
						}
						bitb = num3;
						bitk = i;
						zstream_0.avail_in = num2;
						zstream_0.total_in += num - zstream_0.next_in_index;
						zstream_0.next_in_index = num;
						write = num4;
						return inflate_flush(zstream_0, int_1);
					}
					blens[border[index++]] = num3 & 7;
					num3 = SupportClass.URShift(num3, 3);
					i -= 3;
				}
				while (index < 19)
				{
					blens[border[index++]] = 0;
				}
				bb[0] = 7;
				int num6 = InfTree.inflate_trees_bits(blens, bb, tb, hufts, zstream_0);
				if (num6 == 0)
				{
					index = 0;
					mode = 5;
					goto case 5;
				}
				int_1 = num6;
				if (int_1 == -3)
				{
					blens = null;
					mode = 9;
				}
				bitb = num3;
				bitk = i;
				zstream_0.avail_in = num2;
				zstream_0.total_in += num - zstream_0.next_in_index;
				zstream_0.next_in_index = num;
				write = num4;
				return inflate_flush(zstream_0, int_1);
			}
			case 3:
			{
				for (; i < 14; i += 8)
				{
					if (num2 != 0)
					{
						int_1 = 0;
						num2--;
						num3 |= (zstream_0.next_in[num++] & 0xFF) << i;
						continue;
					}
					bitb = num3;
					bitk = i;
					zstream_0.avail_in = num2;
					zstream_0.total_in += num - zstream_0.next_in_index;
					zstream_0.next_in_index = num;
					write = num4;
					return inflate_flush(zstream_0, int_1);
				}
				int num6 = (table = num3 & 0x3FFF);
				if ((num6 & 0x1F) <= 29 && ((num6 >> 5) & 0x1F) <= 29)
				{
					num6 = 258 + (num6 & 0x1F) + ((num6 >> 5) & 0x1F);
					blens = new int[num6];
					num3 = SupportClass.URShift(num3, 14);
					i -= 14;
					index = 0;
					mode = 4;
					goto case 4;
				}
				mode = 9;
				zstream_0.msg = Class16.smethod_0(1648887359);
				int_1 = -3;
				bitb = num3;
				bitk = i;
				zstream_0.avail_in = num2;
				zstream_0.total_in += num - zstream_0.next_in_index;
				zstream_0.next_in_index = num;
				write = num4;
				return inflate_flush(zstream_0, -3);
			}
			case 2:
				if (num2 != 0)
				{
					if (num5 == 0)
					{
						if (num4 == end && read != 0)
						{
							num4 = 0;
							num5 = ((0 < read) ? (read - num4 - 1) : (end - num4));
						}
						if (num5 == 0)
						{
							write = num4;
							int_1 = inflate_flush(zstream_0, int_1);
							num4 = write;
							num5 = ((num4 < read) ? (read - num4 - 1) : (end - num4));
							if (num4 == end && read != 0)
							{
								num4 = 0;
								num5 = ((0 < read) ? (read - num4 - 1) : (end - num4));
							}
							if (num5 == 0)
							{
								bitb = num3;
								bitk = i;
								zstream_0.avail_in = num2;
								zstream_0.total_in += num - zstream_0.next_in_index;
								zstream_0.next_in_index = num;
								write = num4;
								return inflate_flush(zstream_0, int_1);
							}
						}
					}
					int_1 = 0;
					int num6 = left;
					if (num6 > num2)
					{
						num6 = num2;
					}
					if (num6 > num5)
					{
						num6 = num5;
					}
					Array.Copy(zstream_0.next_in, num, window, num4, num6);
					num += num6;
					num2 -= num6;
					num4 += num6;
					num5 -= num6;
					if ((left -= num6) == 0)
					{
						mode = ((last != 0) ? 7 : 0);
					}
					break;
				}
				bitb = num3;
				bitk = i;
				zstream_0.avail_in = num2;
				zstream_0.total_in += num - zstream_0.next_in_index;
				zstream_0.next_in_index = num;
				write = num4;
				return inflate_flush(zstream_0, int_1);
			case 1:
				for (; i < 32; i += 8)
				{
					if (num2 != 0)
					{
						int_1 = 0;
						num2--;
						num3 |= (zstream_0.next_in[num++] & 0xFF) << i;
						continue;
					}
					bitb = num3;
					bitk = i;
					zstream_0.avail_in = num2;
					zstream_0.total_in += num - zstream_0.next_in_index;
					zstream_0.next_in_index = num;
					write = num4;
					return inflate_flush(zstream_0, int_1);
				}
				if ((SupportClass.URShift(~num3, 16) & 0xFFFF) == (num3 & 0xFFFF))
				{
					left = num3 & 0xFFFF;
					i = 0;
					num3 = 0;
					mode = ((left != 0) ? 2 : ((last != 0) ? 7 : 0));
					break;
				}
				mode = 9;
				zstream_0.msg = Class16.smethod_0(1648887324);
				int_1 = -3;
				bitb = num3;
				bitk = i;
				zstream_0.avail_in = num2;
				zstream_0.total_in += num - zstream_0.next_in_index;
				zstream_0.next_in_index = num;
				write = num4;
				return inflate_flush(zstream_0, -3);
			case 0:
			{
				for (; i < 3; i += 8)
				{
					if (num2 != 0)
					{
						int_1 = 0;
						num2--;
						num3 |= (zstream_0.next_in[num++] & 0xFF) << i;
						continue;
					}
					bitb = num3;
					bitk = i;
					zstream_0.avail_in = num2;
					zstream_0.total_in += num - zstream_0.next_in_index;
					zstream_0.next_in_index = num;
					write = num4;
					return inflate_flush(zstream_0, int_1);
				}
				int num6 = num3 & 7;
				last = num6 & 1;
				switch (SupportClass.URShift(num6, 1))
				{
				case 0:
					num3 = SupportClass.URShift(num3, 3);
					i -= 3;
					num6 = i & 7;
					num3 = SupportClass.URShift(num3, num6);
					i -= num6;
					mode = 1;
					break;
				case 1:
				{
					int[] array = new int[1];
					int[] array2 = new int[1];
					int[][] array3 = new int[1][];
					int[][] array4 = new int[1][];
					InfTree.inflate_trees_fixed(array, array2, array3, array4, zstream_0);
					codes = new InfCodes(array[0], array2[0], array3[0], array4[0], zstream_0);
					num3 = SupportClass.URShift(num3, 3);
					i -= 3;
					mode = 6;
					break;
				}
				case 2:
					num3 = SupportClass.URShift(num3, 3);
					i -= 3;
					mode = 3;
					break;
				case 3:
					num3 = SupportClass.URShift(num3, 3);
					i -= 3;
					mode = 9;
					zstream_0.msg = Class16.smethod_0(1648892411);
					int_1 = -3;
					bitb = num3;
					bitk = i;
					zstream_0.avail_in = num2;
					zstream_0.total_in += num - zstream_0.next_in_index;
					zstream_0.next_in_index = num;
					write = num4;
					return inflate_flush(zstream_0, -3);
				}
				break;
			}
			default:
				int_1 = -2;
				bitb = num3;
				bitk = i;
				zstream_0.avail_in = num2;
				zstream_0.total_in += num - zstream_0.next_in_index;
				zstream_0.next_in_index = num;
				write = num4;
				return inflate_flush(zstream_0, -2);
			case 7:
				write = num4;
				int_1 = inflate_flush(zstream_0, int_1);
				num4 = write;
				num5 = ((num4 < read) ? (read - num4 - 1) : (end - num4));
				if (read != write)
				{
					bitb = num3;
					bitk = i;
					zstream_0.avail_in = num2;
					zstream_0.total_in += num - zstream_0.next_in_index;
					zstream_0.next_in_index = num;
					write = num4;
					return inflate_flush(zstream_0, int_1);
				}
				mode = 8;
				goto case 8;
			case 8:
				int_1 = 1;
				bitb = num3;
				bitk = i;
				zstream_0.avail_in = num2;
				zstream_0.total_in += num - zstream_0.next_in_index;
				zstream_0.next_in_index = num;
				write = num4;
				return inflate_flush(zstream_0, 1);
			case 9:
				int_1 = -3;
				bitb = num3;
				bitk = i;
				zstream_0.avail_in = num2;
				zstream_0.total_in += num - zstream_0.next_in_index;
				zstream_0.next_in_index = num;
				write = num4;
				return inflate_flush(zstream_0, -3);
			}
		}
	}

	internal void free(ZStream zstream_0)
	{
		reset(zstream_0, null);
		window = null;
		hufts = null;
	}

	internal int sync_point()
	{
		return (mode == 1) ? 1 : 0;
	}

	internal int inflate_flush(ZStream zstream_0, int int_1)
	{
		int next_out_index = zstream_0.next_out_index;
		int num = read;
		int num2 = ((num <= write) ? write : end) - num;
		if (num2 > zstream_0.avail_out)
		{
			num2 = zstream_0.avail_out;
		}
		if (num2 != 0 && int_1 == -5)
		{
			int_1 = 0;
		}
		zstream_0.avail_out -= num2;
		zstream_0.total_out += num2;
		if (checkfn != null)
		{
			zstream_0.adler = (check = zstream_0._adler.adler32(check, window, num, num2));
		}
		Array.Copy(window, num, zstream_0.next_out, next_out_index, num2);
		next_out_index += num2;
		num += num2;
		if (num == end)
		{
			num = 0;
			if (write == end)
			{
				write = 0;
			}
			num2 = write - num;
			if (num2 > zstream_0.avail_out)
			{
				num2 = zstream_0.avail_out;
			}
			if (num2 != 0 && int_1 == -5)
			{
				int_1 = 0;
			}
			zstream_0.avail_out -= num2;
			zstream_0.total_out += num2;
			if (checkfn != null)
			{
				zstream_0.adler = (check = zstream_0._adler.adler32(check, window, num, num2));
			}
			Array.Copy(window, num, zstream_0.next_out, next_out_index, num2);
			next_out_index += num2;
			num += num2;
		}
		zstream_0.next_out_index = next_out_index;
		read = num;
		return int_1;
	}
}
