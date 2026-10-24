using System;

namespace ACE.Dependency.zlib.net;

internal sealed class InfCodes
{
	private static readonly int[] int_0 = new int[17]
	{
		0, 1, 3, 7, 15, 31, 63, 127, 255, 511,
		1023, 2047, 4095, 8191, 16383, 32767, 65535
	};

	internal int mode;

	internal int len;

	internal int[] tree;

	internal int tree_index;

	internal int need;

	internal int lit;

	internal int get_Renamed;

	internal int dist;

	internal byte lbits;

	internal byte dbits;

	internal int[] ltree;

	internal int ltree_index;

	internal int[] dtree;

	internal int dtree_index;

	internal InfCodes(int bl, int bd, int[] tl, int tl_index, int[] td, int td_index, ZStream zstream_0)
	{
		mode = 0;
		lbits = (byte)bl;
		dbits = (byte)bd;
		ltree = tl;
		ltree_index = tl_index;
		dtree = td;
		dtree_index = td_index;
	}

	internal InfCodes(int bl, int bd, int[] tl, int[] td, ZStream zstream_0)
	{
		mode = 0;
		lbits = (byte)bl;
		dbits = (byte)bd;
		ltree = tl;
		ltree_index = 0;
		dtree = td;
		dtree_index = 0;
	}

	internal int proc(InfBlocks infBlocks_0, ZStream zstream_0, int int_1)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		num3 = zstream_0.next_in_index;
		int num4 = zstream_0.avail_in;
		num = infBlocks_0.bitb;
		num2 = infBlocks_0.bitk;
		int num5 = infBlocks_0.write;
		int num6 = ((num5 < infBlocks_0.read) ? (infBlocks_0.read - num5 - 1) : (infBlocks_0.end - num5));
		while (true)
		{
			switch (mode)
			{
			case 6:
				if (num6 == 0)
				{
					if (num5 == infBlocks_0.end && infBlocks_0.read != 0)
					{
						num5 = 0;
						num6 = ((0 < infBlocks_0.read) ? (infBlocks_0.read - num5 - 1) : (infBlocks_0.end - num5));
					}
					if (num6 == 0)
					{
						infBlocks_0.write = num5;
						int_1 = infBlocks_0.inflate_flush(zstream_0, int_1);
						num5 = infBlocks_0.write;
						num6 = ((num5 < infBlocks_0.read) ? (infBlocks_0.read - num5 - 1) : (infBlocks_0.end - num5));
						if (num5 == infBlocks_0.end && infBlocks_0.read != 0)
						{
							num5 = 0;
							num6 = ((0 < infBlocks_0.read) ? (infBlocks_0.read - num5 - 1) : (infBlocks_0.end - num5));
						}
						if (num6 == 0)
						{
							infBlocks_0.bitb = num;
							infBlocks_0.bitk = num2;
							zstream_0.avail_in = num4;
							zstream_0.total_in += num3 - zstream_0.next_in_index;
							zstream_0.next_in_index = num3;
							infBlocks_0.write = num5;
							return infBlocks_0.inflate_flush(zstream_0, int_1);
						}
					}
				}
				int_1 = 0;
				infBlocks_0.window[num5++] = (byte)lit;
				num6--;
				mode = 0;
				break;
			case 5:
			{
				int i;
				for (i = num5 - dist; i < 0; i += infBlocks_0.end)
				{
				}
				while (len != 0)
				{
					if (num6 == 0)
					{
						if (num5 == infBlocks_0.end && infBlocks_0.read != 0)
						{
							num5 = 0;
							num6 = ((0 < infBlocks_0.read) ? (infBlocks_0.read - num5 - 1) : (infBlocks_0.end - num5));
						}
						if (num6 == 0)
						{
							infBlocks_0.write = num5;
							int_1 = infBlocks_0.inflate_flush(zstream_0, int_1);
							num5 = infBlocks_0.write;
							num6 = ((num5 < infBlocks_0.read) ? (infBlocks_0.read - num5 - 1) : (infBlocks_0.end - num5));
							if (num5 == infBlocks_0.end && infBlocks_0.read != 0)
							{
								num5 = 0;
								num6 = ((0 < infBlocks_0.read) ? (infBlocks_0.read - num5 - 1) : (infBlocks_0.end - num5));
							}
							if (num6 == 0)
							{
								infBlocks_0.bitb = num;
								infBlocks_0.bitk = num2;
								zstream_0.avail_in = num4;
								zstream_0.total_in += num3 - zstream_0.next_in_index;
								zstream_0.next_in_index = num3;
								infBlocks_0.write = num5;
								return infBlocks_0.inflate_flush(zstream_0, int_1);
							}
						}
					}
					infBlocks_0.window[num5++] = infBlocks_0.window[i++];
					num6--;
					if (i == infBlocks_0.end)
					{
						i = 0;
					}
					len--;
				}
				mode = 0;
				break;
			}
			case 4:
			{
				int num7;
				for (num7 = get_Renamed; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						int_1 = 0;
						num4--;
						num |= (zstream_0.next_in[num3++] & 0xFF) << num2;
						continue;
					}
					infBlocks_0.bitb = num;
					infBlocks_0.bitk = num2;
					zstream_0.avail_in = num4;
					zstream_0.total_in += num3 - zstream_0.next_in_index;
					zstream_0.next_in_index = num3;
					infBlocks_0.write = num5;
					return infBlocks_0.inflate_flush(zstream_0, int_1);
				}
				dist += num & int_0[num7];
				num >>= num7;
				num2 -= num7;
				mode = 5;
				goto case 5;
			}
			case 3:
			{
				int num7;
				for (num7 = need; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						int_1 = 0;
						num4--;
						num |= (zstream_0.next_in[num3++] & 0xFF) << num2;
						continue;
					}
					infBlocks_0.bitb = num;
					infBlocks_0.bitk = num2;
					zstream_0.avail_in = num4;
					zstream_0.total_in += num3 - zstream_0.next_in_index;
					zstream_0.next_in_index = num3;
					infBlocks_0.write = num5;
					return infBlocks_0.inflate_flush(zstream_0, int_1);
				}
				int num8 = (tree_index + (num & int_0[num7])) * 3;
				num >>= tree[num8 + 1];
				num2 -= tree[num8 + 1];
				int num9 = tree[num8];
				if ((num9 & 0x10) != 0)
				{
					get_Renamed = num9 & 0xF;
					dist = tree[num8 + 2];
					mode = 4;
					break;
				}
				if ((num9 & 0x40) == 0)
				{
					need = num9;
					tree_index = num8 / 3 + tree[num8 + 2];
					break;
				}
				mode = 9;
				zstream_0.msg = Class16.smethod_0(1648887459);
				int_1 = -3;
				infBlocks_0.bitb = num;
				infBlocks_0.bitk = num2;
				zstream_0.avail_in = num4;
				zstream_0.total_in += num3 - zstream_0.next_in_index;
				zstream_0.next_in_index = num3;
				infBlocks_0.write = num5;
				return infBlocks_0.inflate_flush(zstream_0, -3);
			}
			case 2:
			{
				int num7;
				for (num7 = get_Renamed; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						int_1 = 0;
						num4--;
						num |= (zstream_0.next_in[num3++] & 0xFF) << num2;
						continue;
					}
					infBlocks_0.bitb = num;
					infBlocks_0.bitk = num2;
					zstream_0.avail_in = num4;
					zstream_0.total_in += num3 - zstream_0.next_in_index;
					zstream_0.next_in_index = num3;
					infBlocks_0.write = num5;
					return infBlocks_0.inflate_flush(zstream_0, int_1);
				}
				len += num & int_0[num7];
				num >>= num7;
				num2 -= num7;
				need = dbits;
				tree = dtree;
				tree_index = dtree_index;
				mode = 3;
				goto case 3;
			}
			case 1:
			{
				int num7;
				for (num7 = need; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						int_1 = 0;
						num4--;
						num |= (zstream_0.next_in[num3++] & 0xFF) << num2;
						continue;
					}
					infBlocks_0.bitb = num;
					infBlocks_0.bitk = num2;
					zstream_0.avail_in = num4;
					zstream_0.total_in += num3 - zstream_0.next_in_index;
					zstream_0.next_in_index = num3;
					infBlocks_0.write = num5;
					return infBlocks_0.inflate_flush(zstream_0, int_1);
				}
				int num8 = (tree_index + (num & int_0[num7])) * 3;
				num = SupportClass.URShift(num, tree[num8 + 1]);
				num2 -= tree[num8 + 1];
				int num9 = tree[num8];
				if (num9 == 0)
				{
					lit = tree[num8 + 2];
					mode = 6;
					break;
				}
				if ((num9 & 0x10) != 0)
				{
					get_Renamed = num9 & 0xF;
					len = tree[num8 + 2];
					mode = 2;
					break;
				}
				if ((num9 & 0x40) == 0)
				{
					need = num9;
					tree_index = num8 / 3 + tree[num8 + 2];
					break;
				}
				if ((num9 & 0x20) != 0)
				{
					mode = 7;
					break;
				}
				mode = 9;
				zstream_0.msg = Class16.smethod_0(1648887425);
				int_1 = -3;
				infBlocks_0.bitb = num;
				infBlocks_0.bitk = num2;
				zstream_0.avail_in = num4;
				zstream_0.total_in += num3 - zstream_0.next_in_index;
				zstream_0.next_in_index = num3;
				infBlocks_0.write = num5;
				return infBlocks_0.inflate_flush(zstream_0, -3);
			}
			case 0:
				if (num6 >= 258 && num4 >= 10)
				{
					infBlocks_0.bitb = num;
					infBlocks_0.bitk = num2;
					zstream_0.avail_in = num4;
					zstream_0.total_in += num3 - zstream_0.next_in_index;
					zstream_0.next_in_index = num3;
					infBlocks_0.write = num5;
					int_1 = inflate_fast(lbits, dbits, ltree, ltree_index, dtree, dtree_index, infBlocks_0, zstream_0);
					num3 = zstream_0.next_in_index;
					num4 = zstream_0.avail_in;
					num = infBlocks_0.bitb;
					num2 = infBlocks_0.bitk;
					num5 = infBlocks_0.write;
					num6 = ((num5 < infBlocks_0.read) ? (infBlocks_0.read - num5 - 1) : (infBlocks_0.end - num5));
					if (int_1 != 0)
					{
						mode = ((int_1 == 1) ? 7 : 9);
						break;
					}
				}
				need = lbits;
				tree = ltree;
				tree_index = ltree_index;
				mode = 1;
				goto case 1;
			default:
				int_1 = -2;
				infBlocks_0.bitb = num;
				infBlocks_0.bitk = num2;
				zstream_0.avail_in = num4;
				zstream_0.total_in += num3 - zstream_0.next_in_index;
				zstream_0.next_in_index = num3;
				infBlocks_0.write = num5;
				return infBlocks_0.inflate_flush(zstream_0, -2);
			case 7:
				if (num2 > 7)
				{
					num2 -= 8;
					num4++;
					num3--;
				}
				infBlocks_0.write = num5;
				int_1 = infBlocks_0.inflate_flush(zstream_0, int_1);
				num5 = infBlocks_0.write;
				num6 = ((num5 < infBlocks_0.read) ? (infBlocks_0.read - num5 - 1) : (infBlocks_0.end - num5));
				if (infBlocks_0.read != infBlocks_0.write)
				{
					infBlocks_0.bitb = num;
					infBlocks_0.bitk = num2;
					zstream_0.avail_in = num4;
					zstream_0.total_in += num3 - zstream_0.next_in_index;
					zstream_0.next_in_index = num3;
					infBlocks_0.write = num5;
					return infBlocks_0.inflate_flush(zstream_0, int_1);
				}
				mode = 8;
				goto case 8;
			case 8:
				int_1 = 1;
				infBlocks_0.bitb = num;
				infBlocks_0.bitk = num2;
				zstream_0.avail_in = num4;
				zstream_0.total_in += num3 - zstream_0.next_in_index;
				zstream_0.next_in_index = num3;
				infBlocks_0.write = num5;
				return infBlocks_0.inflate_flush(zstream_0, 1);
			case 9:
				int_1 = -3;
				infBlocks_0.bitb = num;
				infBlocks_0.bitk = num2;
				zstream_0.avail_in = num4;
				zstream_0.total_in += num3 - zstream_0.next_in_index;
				zstream_0.next_in_index = num3;
				infBlocks_0.write = num5;
				return infBlocks_0.inflate_flush(zstream_0, -3);
			}
		}
	}

	internal void free(ZStream zstream_0)
	{
	}

	internal int inflate_fast(int bl, int bd, int[] tl, int tl_index, int[] td, int td_index, InfBlocks infBlocks_0, ZStream zstream_0)
	{
		int next_in_index = zstream_0.next_in_index;
		int num = zstream_0.avail_in;
		int num2 = infBlocks_0.bitb;
		int num3 = infBlocks_0.bitk;
		int num4 = infBlocks_0.write;
		int num5 = ((num4 < infBlocks_0.read) ? (infBlocks_0.read - num4 - 1) : (infBlocks_0.end - num4));
		int num6 = int_0[bl];
		int num7 = int_0[bd];
		int num11;
		while (true)
		{
			if (num3 < 20)
			{
				num--;
				num2 |= (zstream_0.next_in[next_in_index++] & 0xFF) << num3;
				num3 += 8;
				continue;
			}
			int num8 = num2 & num6;
			int[] array = tl;
			int num9 = tl_index;
			int num10;
			if ((num10 = array[(num9 + num8) * 3]) == 0)
			{
				num2 >>= array[(num9 + num8) * 3 + 1];
				num3 -= array[(num9 + num8) * 3 + 1];
				infBlocks_0.window[num4++] = (byte)array[(num9 + num8) * 3 + 2];
				num5--;
			}
			else
			{
				while (true)
				{
					num2 >>= array[(num9 + num8) * 3 + 1];
					num3 -= array[(num9 + num8) * 3 + 1];
					if ((num10 & 0x10) == 0)
					{
						if ((num10 & 0x40) == 0)
						{
							num8 += array[(num9 + num8) * 3 + 2];
							num8 += num2 & int_0[num10];
							if ((num10 = array[(num9 + num8) * 3]) == 0)
							{
								num2 >>= array[(num9 + num8) * 3 + 1];
								num3 -= array[(num9 + num8) * 3 + 1];
								infBlocks_0.window[num4++] = (byte)array[(num9 + num8) * 3 + 2];
								num5--;
								break;
							}
							continue;
						}
						if ((num10 & 0x20) != 0)
						{
							num11 = zstream_0.avail_in - num;
							num11 = ((num3 >> 3 < num11) ? (num3 >> 3) : num11);
							num += num11;
							next_in_index -= num11;
							num3 -= num11 << 3;
							infBlocks_0.bitb = num2;
							infBlocks_0.bitk = num3;
							zstream_0.avail_in = num;
							zstream_0.total_in += next_in_index - zstream_0.next_in_index;
							zstream_0.next_in_index = next_in_index;
							infBlocks_0.write = num4;
							return 1;
						}
						zstream_0.msg = Class16.smethod_0(1648887425);
						num11 = zstream_0.avail_in - num;
						num11 = ((num3 >> 3 < num11) ? (num3 >> 3) : num11);
						num += num11;
						next_in_index -= num11;
						num3 -= num11 << 3;
						infBlocks_0.bitb = num2;
						infBlocks_0.bitk = num3;
						zstream_0.avail_in = num;
						zstream_0.total_in += next_in_index - zstream_0.next_in_index;
						zstream_0.next_in_index = next_in_index;
						infBlocks_0.write = num4;
						return -3;
					}
					num10 &= 0xF;
					num11 = array[(num9 + num8) * 3 + 2] + (num2 & int_0[num10]);
					num2 >>= num10;
					for (num3 -= num10; num3 < 15; num3 += 8)
					{
						num--;
						num2 |= (zstream_0.next_in[next_in_index++] & 0xFF) << num3;
					}
					num8 = num2 & num7;
					array = td;
					num9 = td_index;
					num10 = array[(num9 + num8) * 3];
					while (true)
					{
						num2 >>= array[(num9 + num8) * 3 + 1];
						num3 -= array[(num9 + num8) * 3 + 1];
						if ((num10 & 0x10) != 0)
						{
							break;
						}
						if ((num10 & 0x40) == 0)
						{
							num8 += array[(num9 + num8) * 3 + 2];
							num8 += num2 & int_0[num10];
							num10 = array[(num9 + num8) * 3];
							continue;
						}
						zstream_0.msg = Class16.smethod_0(1648887459);
						num11 = zstream_0.avail_in - num;
						num11 = ((num3 >> 3 < num11) ? (num3 >> 3) : num11);
						num += num11;
						next_in_index -= num11;
						num3 -= num11 << 3;
						infBlocks_0.bitb = num2;
						infBlocks_0.bitk = num3;
						zstream_0.avail_in = num;
						zstream_0.total_in += next_in_index - zstream_0.next_in_index;
						zstream_0.next_in_index = next_in_index;
						infBlocks_0.write = num4;
						return -3;
					}
					for (num10 &= 0xF; num3 < num10; num3 += 8)
					{
						num--;
						num2 |= (zstream_0.next_in[next_in_index++] & 0xFF) << num3;
					}
					int num12 = array[(num9 + num8) * 3 + 2] + (num2 & int_0[num10]);
					num2 >>= num10;
					num3 -= num10;
					num5 -= num11;
					int num13;
					if (num4 >= num12)
					{
						num13 = num4 - num12;
						if (num4 - num13 > 0 && 2 > num4 - num13)
						{
							infBlocks_0.window[num4++] = infBlocks_0.window[num13++];
							num11--;
							infBlocks_0.window[num4++] = infBlocks_0.window[num13++];
							num11--;
						}
						else
						{
							Array.Copy(infBlocks_0.window, num13, infBlocks_0.window, num4, 2);
							num4 += 2;
							num13 += 2;
							num11 -= 2;
						}
					}
					else
					{
						num13 = num4 - num12;
						do
						{
							num13 += infBlocks_0.end;
						}
						while (num13 < 0);
						num10 = infBlocks_0.end - num13;
						if (num11 > num10)
						{
							num11 -= num10;
							if (num4 - num13 > 0 && num10 > num4 - num13)
							{
								do
								{
									infBlocks_0.window[num4++] = infBlocks_0.window[num13++];
								}
								while (--num10 != 0);
							}
							else
							{
								Array.Copy(infBlocks_0.window, num13, infBlocks_0.window, num4, num10);
								num4 += num10;
								num13 += num10;
								num10 = 0;
							}
							num13 = 0;
						}
					}
					if (num4 - num13 > 0 && num11 > num4 - num13)
					{
						do
						{
							infBlocks_0.window[num4++] = infBlocks_0.window[num13++];
						}
						while (--num11 != 0);
						break;
					}
					Array.Copy(infBlocks_0.window, num13, infBlocks_0.window, num4, num11);
					num4 += num11;
					num13 += num11;
					num11 = 0;
					break;
				}
			}
			if (num5 < 258 || num < 10)
			{
				break;
			}
		}
		num11 = zstream_0.avail_in - num;
		num11 = ((num3 >> 3 < num11) ? (num3 >> 3) : num11);
		num += num11;
		next_in_index -= num11;
		num3 -= num11 << 3;
		infBlocks_0.bitb = num2;
		infBlocks_0.bitk = num3;
		zstream_0.avail_in = num;
		zstream_0.total_in += next_in_index - zstream_0.next_in_index;
		zstream_0.next_in_index = next_in_index;
		infBlocks_0.write = num4;
		return 0;
	}
}
