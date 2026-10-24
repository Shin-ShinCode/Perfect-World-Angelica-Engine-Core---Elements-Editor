namespace ACE.Dependency.zlib.net;

internal sealed class Inflate
{
	internal const int Z_NO_FLUSH = 0;

	internal const int Z_PARTIAL_FLUSH = 1;

	internal const int Z_SYNC_FLUSH = 2;

	internal const int Z_FULL_FLUSH = 3;

	internal const int Z_FINISH = 4;

	internal int mode;

	internal int method;

	internal long[] was = new long[1];

	internal long need;

	internal int marker;

	internal int nowrap;

	internal int wbits;

	internal InfBlocks blocks;

	private static byte[] byte_0 = new byte[4]
	{
		0,
		0,
		(byte)SupportClass.Identity(255L),
		(byte)SupportClass.Identity(255L)
	};

	internal int inflateReset(ZStream zstream_0)
	{
		if (zstream_0 != null && zstream_0.istate != null)
		{
			zstream_0.total_out = 0L;
			zstream_0.total_in = 0L;
			zstream_0.msg = null;
			zstream_0.istate.mode = ((zstream_0.istate.nowrap != 0) ? 7 : 0);
			zstream_0.istate.blocks.reset(zstream_0, null);
			return 0;
		}
		return -2;
	}

	internal int inflateEnd(ZStream zstream_0)
	{
		if (blocks != null)
		{
			blocks.free(zstream_0);
		}
		blocks = null;
		return 0;
	}

	internal int inflateInit(ZStream zstream_0, int int_0)
	{
		zstream_0.msg = null;
		blocks = null;
		nowrap = 0;
		if (int_0 < 0)
		{
			int_0 = -int_0;
			nowrap = 1;
		}
		if (int_0 >= 8 && int_0 <= 15)
		{
			wbits = int_0;
			zstream_0.istate.blocks = new InfBlocks(zstream_0, (zstream_0.istate.nowrap != 0) ? null : this, 1 << int_0);
			inflateReset(zstream_0);
			return 0;
		}
		inflateEnd(zstream_0);
		return -2;
	}

	internal int inflate(ZStream zstream_0, int int_0)
	{
		if (zstream_0 != null && zstream_0.istate != null && zstream_0.next_in != null)
		{
			int_0 = ((int_0 == 4) ? (-5) : 0);
			int num = -5;
			while (true)
			{
				switch (zstream_0.istate.mode)
				{
				case 11:
					if (zstream_0.avail_in != 0)
					{
						num = int_0;
						zstream_0.avail_in--;
						zstream_0.total_in++;
						zstream_0.istate.need += zstream_0.next_in[zstream_0.next_in_index++] & 0xFFL;
						if ((int)zstream_0.istate.was[0] != (int)zstream_0.istate.need)
						{
							zstream_0.istate.mode = 13;
							zstream_0.msg = Class16.smethod_0(1648887643);
							zstream_0.istate.marker = 5;
							break;
						}
						zstream_0.istate.mode = 12;
						goto case 12;
					}
					return num;
				case 10:
					if (zstream_0.avail_in != 0)
					{
						num = int_0;
						zstream_0.avail_in--;
						zstream_0.total_in++;
						zstream_0.istate.need += ((zstream_0.next_in[zstream_0.next_in_index++] & 0xFF) << 8) & 0xFF00L;
						zstream_0.istate.mode = 11;
						goto case 11;
					}
					return num;
				case 9:
					if (zstream_0.avail_in != 0)
					{
						num = int_0;
						zstream_0.avail_in--;
						zstream_0.total_in++;
						zstream_0.istate.need += ((zstream_0.next_in[zstream_0.next_in_index++] & 0xFF) << 16) & 0xFF0000L;
						zstream_0.istate.mode = 10;
						goto case 10;
					}
					return num;
				case 8:
					if (zstream_0.avail_in != 0)
					{
						num = int_0;
						zstream_0.avail_in--;
						zstream_0.total_in++;
						zstream_0.istate.need = ((zstream_0.next_in[zstream_0.next_in_index++] & 0xFF) << 24) & -16777216;
						zstream_0.istate.mode = 9;
						goto case 9;
					}
					return num;
				case 7:
					num = zstream_0.istate.blocks.proc(zstream_0, num);
					switch (num)
					{
					case -3:
						zstream_0.istate.mode = 13;
						zstream_0.istate.marker = 0;
						goto end_IL_0484;
					case 0:
						num = int_0;
						break;
					}
					if (num == 1)
					{
						num = int_0;
						zstream_0.istate.blocks.reset(zstream_0, zstream_0.istate.was);
						if (zstream_0.istate.nowrap != 0)
						{
							zstream_0.istate.mode = 12;
							break;
						}
						zstream_0.istate.mode = 8;
						goto case 8;
					}
					return num;
				case 1:
					if (zstream_0.avail_in != 0)
					{
						num = int_0;
						zstream_0.avail_in--;
						zstream_0.total_in++;
						int num2 = zstream_0.next_in[zstream_0.next_in_index++] & 0xFF;
						if (((zstream_0.istate.method << 8) + num2) % 31 != 0)
						{
							zstream_0.istate.mode = 13;
							zstream_0.msg = Class16.smethod_0(1648887622);
							zstream_0.istate.marker = 5;
							break;
						}
						if ((num2 & 0x20) == 0)
						{
							zstream_0.istate.mode = 7;
							break;
						}
						zstream_0.istate.mode = 2;
						goto case 2;
					}
					return num;
				case 0:
					if (zstream_0.avail_in != 0)
					{
						num = int_0;
						zstream_0.avail_in--;
						zstream_0.total_in++;
						if (((zstream_0.istate.method = zstream_0.next_in[zstream_0.next_in_index++]) & 0xF) != 8)
						{
							zstream_0.istate.mode = 13;
							zstream_0.msg = Class16.smethod_0(1648885958);
							zstream_0.istate.marker = 5;
							break;
						}
						if ((zstream_0.istate.method >> 4) + 8 > zstream_0.istate.wbits)
						{
							zstream_0.istate.mode = 13;
							zstream_0.msg = Class16.smethod_0(1648885991);
							zstream_0.istate.marker = 5;
							break;
						}
						zstream_0.istate.mode = 1;
						goto case 1;
					}
					return num;
				default:
					return -2;
				case 2:
					if (zstream_0.avail_in == 0)
					{
						return num;
					}
					num = int_0;
					zstream_0.avail_in--;
					zstream_0.total_in++;
					zstream_0.istate.need = ((zstream_0.next_in[zstream_0.next_in_index++] & 0xFF) << 24) & -16777216;
					zstream_0.istate.mode = 3;
					goto case 3;
				case 3:
					if (zstream_0.avail_in == 0)
					{
						return num;
					}
					num = int_0;
					zstream_0.avail_in--;
					zstream_0.total_in++;
					zstream_0.istate.need += ((zstream_0.next_in[zstream_0.next_in_index++] & 0xFF) << 16) & 0xFF0000L;
					zstream_0.istate.mode = 4;
					goto case 4;
				case 4:
					if (zstream_0.avail_in == 0)
					{
						return num;
					}
					num = int_0;
					zstream_0.avail_in--;
					zstream_0.total_in++;
					zstream_0.istate.need += ((zstream_0.next_in[zstream_0.next_in_index++] & 0xFF) << 8) & 0xFF00L;
					zstream_0.istate.mode = 5;
					goto case 5;
				case 5:
					if (zstream_0.avail_in == 0)
					{
						return num;
					}
					num = int_0;
					zstream_0.avail_in--;
					zstream_0.total_in++;
					zstream_0.istate.need += zstream_0.next_in[zstream_0.next_in_index++] & 0xFFL;
					zstream_0.adler = zstream_0.istate.need;
					zstream_0.istate.mode = 6;
					return 2;
				case 6:
					zstream_0.istate.mode = 13;
					zstream_0.msg = Class16.smethod_0(1648892559);
					zstream_0.istate.marker = 0;
					return -2;
				case 12:
					return 1;
				case 13:
					{
						return -3;
					}
					end_IL_0484:
					break;
				}
			}
		}
		return -2;
	}

	internal int inflateSetDictionary(ZStream zstream_0, byte[] dictionary, int dictLength)
	{
		int start = 0;
		int num = dictLength;
		if (zstream_0 != null && zstream_0.istate != null && zstream_0.istate.mode == 6)
		{
			if (zstream_0._adler.adler32(1L, dictionary, 0, dictLength) != zstream_0.adler)
			{
				return -3;
			}
			zstream_0.adler = zstream_0._adler.adler32(0L, null, 0, 0);
			if (num >= 1 << zstream_0.istate.wbits)
			{
				num = (1 << zstream_0.istate.wbits) - 1;
				start = dictLength - num;
			}
			zstream_0.istate.blocks.set_dictionary(dictionary, start, num);
			zstream_0.istate.mode = 7;
			return 0;
		}
		return -2;
	}

	internal int inflateSync(ZStream zstream_0)
	{
		if (zstream_0 != null && zstream_0.istate != null)
		{
			if (zstream_0.istate.mode != 13)
			{
				zstream_0.istate.mode = 13;
				zstream_0.istate.marker = 0;
			}
			int num;
			if ((num = zstream_0.avail_in) == 0)
			{
				return -5;
			}
			int num2 = zstream_0.next_in_index;
			int num3 = zstream_0.istate.marker;
			while (num != 0 && num3 < 4)
			{
				num3 = ((zstream_0.next_in[num2] != byte_0[num3]) ? ((zstream_0.next_in[num2] == 0) ? (4 - num3) : 0) : (num3 + 1));
				num2++;
				num--;
			}
			zstream_0.total_in += num2 - zstream_0.next_in_index;
			zstream_0.next_in_index = num2;
			zstream_0.avail_in = num;
			zstream_0.istate.marker = num3;
			if (num3 != 4)
			{
				return -3;
			}
			long total_in = zstream_0.total_in;
			long total_out = zstream_0.total_out;
			inflateReset(zstream_0);
			zstream_0.total_in = total_in;
			zstream_0.total_out = total_out;
			zstream_0.istate.mode = 7;
			return 0;
		}
		return -2;
	}

	internal int inflateSyncPoint(ZStream zstream_0)
	{
		if (zstream_0 != null && zstream_0.istate != null && zstream_0.istate.blocks != null)
		{
			return zstream_0.istate.blocks.sync_point();
		}
		return -2;
	}
}
