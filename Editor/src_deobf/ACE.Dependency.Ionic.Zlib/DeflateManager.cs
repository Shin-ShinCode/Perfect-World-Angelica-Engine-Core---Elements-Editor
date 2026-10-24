using System;

namespace ACE.Dependency.Ionic.Zlib;

internal sealed class DeflateManager
{
	internal delegate BlockState CompressFunc(FlushType flush);

	internal class Config
	{
		internal int GoodLength;

		internal int MaxLazy;

		internal int NiceLength;

		internal int MaxChainLength;

		internal DeflateFlavor Flavor;

		private static readonly Config[] config_0;

		private Config(int int_0, int int_1, int int_2, int int_3, DeflateFlavor deflateFlavor_0)
		{
			GoodLength = int_0;
			MaxLazy = int_1;
			NiceLength = int_2;
			MaxChainLength = int_3;
			Flavor = deflateFlavor_0;
		}

		static Config()
		{
			config_0 = new Config[10]
			{
				new Config(0, 0, 0, 0, DeflateFlavor.Store),
				new Config(4, 4, 8, 4, DeflateFlavor.Fast),
				new Config(4, 5, 16, 8, DeflateFlavor.Fast),
				new Config(4, 6, 32, 32, DeflateFlavor.Fast),
				new Config(4, 4, 16, 16, DeflateFlavor.Slow),
				new Config(8, 16, 32, 32, DeflateFlavor.Slow),
				new Config(8, 16, 128, 128, DeflateFlavor.Slow),
				new Config(8, 32, 128, 256, DeflateFlavor.Slow),
				new Config(32, 128, 258, 1024, DeflateFlavor.Slow),
				new Config(32, 258, 258, 4096, DeflateFlavor.Slow)
			};
		}

		public static Config Lookup(CompressionLevel level)
		{
			return config_0[(int)level];
		}
	}

	private static readonly int int_0 = 9;

	private static readonly int int_1 = 8;

	private CompressFunc compressFunc_0;

	private static readonly string[] string_0 = new string[10]
	{
		Class16.smethod_0(1648892559),
		Class16.smethod_0(1648892581),
		string.Empty,
		Class16.smethod_0(1648892598),
		Class16.smethod_0(1648892615),
		Class16.smethod_0(1648892626),
		Class16.smethod_0(1648892643),
		Class16.smethod_0(1648892677),
		Class16.smethod_0(1648892688),
		string.Empty
	};

	private static readonly int int_2 = 32;

	private static readonly int int_3 = 42;

	private static readonly int int_4 = 113;

	private static readonly int int_5 = 666;

	private static readonly int int_6 = 8;

	private static readonly int int_7 = 0;

	private static readonly int int_8 = 1;

	private static readonly int int_9 = 2;

	private static readonly int int_10 = 0;

	private static readonly int int_11 = 1;

	private static readonly int int_12 = 2;

	private static readonly int int_13 = 16;

	private static readonly int int_14 = 3;

	private static readonly int int_15 = 258;

	private static readonly int int_16 = int_15 + int_14 + 1;

	private static readonly int int_17 = 2 * InternalConstants.L_CODES + 1;

	private static readonly int int_18 = 256;

	internal ZlibCodec _codec;

	internal int status;

	internal byte[] pending;

	internal int nextPending;

	internal int pendingCount;

	internal sbyte data_type;

	internal int last_flush;

	internal int w_size;

	internal int w_bits;

	internal int w_mask;

	internal byte[] window;

	internal int window_size;

	internal short[] prev;

	internal short[] head;

	internal int ins_h;

	internal int hash_size;

	internal int hash_bits;

	internal int hash_mask;

	internal int hash_shift;

	internal int block_start;

	private Config config_0;

	internal int match_length;

	internal int prev_match;

	internal int match_available;

	internal int strstart;

	internal int match_start;

	internal int lookahead;

	internal int prev_length;

	internal CompressionLevel compressionLevel;

	internal CompressionStrategy compressionStrategy;

	internal short[] dyn_ltree;

	internal short[] dyn_dtree;

	internal short[] bl_tree;

	internal Tree treeLiterals = new Tree();

	internal Tree treeDistances = new Tree();

	internal Tree treeBitLengths = new Tree();

	internal short[] bl_count = new short[InternalConstants.MAX_BITS + 1];

	internal int[] heap = new int[2 * InternalConstants.L_CODES + 1];

	internal int heap_len;

	internal int heap_max;

	internal sbyte[] depth = new sbyte[2 * InternalConstants.L_CODES + 1];

	internal int _lengthOffset;

	internal int lit_bufsize;

	internal int last_lit;

	internal int _distanceOffset;

	internal int opt_len;

	internal int static_len;

	internal int matches;

	internal int last_eob_len;

	internal short bi_buf;

	internal int bi_valid;

	private bool bool_0;

	private bool bool_1 = true;

	internal bool WantRfc1950HeaderBytes
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal DeflateManager()
	{
		dyn_ltree = new short[int_17 * 2];
		dyn_dtree = new short[(2 * InternalConstants.D_CODES + 1) * 2];
		bl_tree = new short[(2 * InternalConstants.BL_CODES + 1) * 2];
	}

	private void method_0()
	{
		window_size = 2 * w_size;
		Array.Clear(head, 0, hash_size);
		config_0 = Config.Lookup(compressionLevel);
		method_4();
		strstart = 0;
		block_start = 0;
		lookahead = 0;
		match_length = (prev_length = int_14 - 1);
		match_available = 0;
		ins_h = 0;
	}

	private void method_1()
	{
		treeLiterals.dyn_tree = dyn_ltree;
		treeLiterals.staticTree = StaticTree.Literals;
		treeDistances.dyn_tree = dyn_dtree;
		treeDistances.staticTree = StaticTree.Distances;
		treeBitLengths.dyn_tree = bl_tree;
		treeBitLengths.staticTree = StaticTree.BitLengths;
		bi_buf = 0;
		bi_valid = 0;
		last_eob_len = 8;
		_InitializeBlocks();
	}

	internal void _InitializeBlocks()
	{
		for (int i = 0; i < InternalConstants.L_CODES; i++)
		{
			dyn_ltree[i * 2] = 0;
		}
		for (int j = 0; j < InternalConstants.D_CODES; j++)
		{
			dyn_dtree[j * 2] = 0;
		}
		for (int k = 0; k < InternalConstants.BL_CODES; k++)
		{
			bl_tree[k * 2] = 0;
		}
		dyn_ltree[int_18 * 2] = 1;
		static_len = 0;
		opt_len = 0;
		matches = 0;
		last_lit = 0;
	}

	internal void pqdownheap(short[] tree, int int_19)
	{
		int num = heap[int_19];
		for (int num2 = int_19 << 1; num2 <= heap_len; num2 <<= 1)
		{
			if (num2 < heap_len && _IsSmaller(tree, heap[num2 + 1], heap[num2], depth))
			{
				num2++;
			}
			if (_IsSmaller(tree, num, heap[num2], depth))
			{
				break;
			}
			heap[int_19] = heap[num2];
			int_19 = num2;
		}
		heap[int_19] = num;
	}

	internal static bool _IsSmaller(short[] tree, int int_19, int int_20, sbyte[] depth)
	{
		short num = tree[int_19 * 2];
		short num2 = tree[int_20 * 2];
		if (num >= num2)
		{
			if (num == num2)
			{
				return depth[int_19] <= depth[int_20];
			}
			return false;
		}
		return true;
	}

	internal void scan_tree(short[] tree, int max_code)
	{
		int num = -1;
		int num2 = tree[1];
		int num3 = 0;
		int num4 = 7;
		int num5 = 4;
		if (num2 == 0)
		{
			num4 = 138;
			num5 = 3;
		}
		tree[(max_code + 1) * 2 + 1] = short.MaxValue;
		for (int i = 0; i <= max_code; i++)
		{
			int num6 = num2;
			num2 = tree[(i + 1) * 2 + 1];
			if (++num3 < num4 && num6 == num2)
			{
				continue;
			}
			if (num3 < num5)
			{
				bl_tree[num6 * 2] = (short)(bl_tree[num6 * 2] + num3);
			}
			else if (num6 != 0)
			{
				if (num6 != num)
				{
					bl_tree[num6 * 2]++;
				}
				bl_tree[InternalConstants.REP_3_6 * 2]++;
			}
			else if (num3 <= 10)
			{
				bl_tree[InternalConstants.REPZ_3_10 * 2]++;
			}
			else
			{
				bl_tree[InternalConstants.REPZ_11_138 * 2]++;
			}
			num3 = 0;
			num = num6;
			if (num2 == 0)
			{
				num4 = 138;
				num5 = 3;
			}
			else if (num6 == num2)
			{
				num4 = 6;
				num5 = 3;
			}
			else
			{
				num4 = 7;
				num5 = 4;
			}
		}
	}

	internal int build_bl_tree()
	{
		scan_tree(dyn_ltree, treeLiterals.max_code);
		scan_tree(dyn_dtree, treeDistances.max_code);
		treeBitLengths.build_tree(this);
		int num = InternalConstants.BL_CODES - 1;
		while (num >= 3 && bl_tree[Tree.bl_order[num] * 2 + 1] == 0)
		{
			num--;
		}
		opt_len += 3 * (num + 1) + 5 + 5 + 4;
		return num;
	}

	internal void send_all_trees(int lcodes, int dcodes, int blcodes)
	{
		send_bits(lcodes - 257, 5);
		send_bits(dcodes - 1, 5);
		send_bits(blcodes - 4, 4);
		for (int i = 0; i < blcodes; i++)
		{
			send_bits(bl_tree[Tree.bl_order[i] * 2 + 1], 3);
		}
		send_tree(dyn_ltree, lcodes - 1);
		send_tree(dyn_dtree, dcodes - 1);
	}

	internal void send_tree(short[] tree, int max_code)
	{
		int num = -1;
		int num2 = tree[1];
		int num3 = 0;
		int num4 = 7;
		int num5 = 4;
		if (num2 == 0)
		{
			num4 = 138;
			num5 = 3;
		}
		for (int i = 0; i <= max_code; i++)
		{
			int num6 = num2;
			num2 = tree[(i + 1) * 2 + 1];
			if (++num3 < num4 && num6 == num2)
			{
				continue;
			}
			if (num3 < num5)
			{
				do
				{
					send_code(num6, bl_tree);
				}
				while (--num3 != 0);
			}
			else if (num6 != 0)
			{
				if (num6 != num)
				{
					send_code(num6, bl_tree);
					num3--;
				}
				send_code(InternalConstants.REP_3_6, bl_tree);
				send_bits(num3 - 3, 2);
			}
			else if (num3 <= 10)
			{
				send_code(InternalConstants.REPZ_3_10, bl_tree);
				send_bits(num3 - 3, 3);
			}
			else
			{
				send_code(InternalConstants.REPZ_11_138, bl_tree);
				send_bits(num3 - 11, 7);
			}
			num3 = 0;
			num = num6;
			if (num2 == 0)
			{
				num4 = 138;
				num5 = 3;
			}
			else if (num6 == num2)
			{
				num4 = 6;
				num5 = 3;
			}
			else
			{
				num4 = 7;
				num5 = 4;
			}
		}
	}

	private void method_2(byte[] byte_0, int int_19, int int_20)
	{
		Array.Copy(byte_0, int_19, pending, pendingCount, int_20);
		pendingCount += int_20;
	}

	internal void send_code(int int_19, short[] tree)
	{
		int num = int_19 * 2;
		send_bits(tree[num] & 0xFFFF, tree[num + 1] & 0xFFFF);
	}

	internal void send_bits(int value, int length)
	{
		if (bi_valid > int_13 - length)
		{
			bi_buf |= (short)(value << bi_valid);
			pending[pendingCount++] = (byte)bi_buf;
			pending[pendingCount++] = (byte)(bi_buf >> 8);
			bi_buf = (short)(value >>> int_13 - bi_valid);
			bi_valid += length - int_13;
		}
		else
		{
			bi_buf |= (short)(value << bi_valid);
			bi_valid += length;
		}
	}

	internal void _tr_align()
	{
		send_bits(int_8 << 1, 3);
		send_code(int_18, StaticTree.lengthAndLiteralsTreeCodes);
		bi_flush();
		if (1 + last_eob_len + 10 - bi_valid < 9)
		{
			send_bits(int_8 << 1, 3);
			send_code(int_18, StaticTree.lengthAndLiteralsTreeCodes);
			bi_flush();
		}
		last_eob_len = 7;
	}

	internal bool _tr_tally(int dist, int lc)
	{
		pending[_distanceOffset + last_lit * 2] = (byte)((uint)dist >> 8);
		pending[_distanceOffset + last_lit * 2 + 1] = (byte)dist;
		pending[_lengthOffset + last_lit] = (byte)lc;
		last_lit++;
		if (dist == 0)
		{
			dyn_ltree[lc * 2]++;
		}
		else
		{
			matches++;
			dist--;
			dyn_ltree[(Tree.LengthCode[lc] + InternalConstants.LITERALS + 1) * 2]++;
			dyn_dtree[Tree.DistanceCode(dist) * 2]++;
		}
		if ((last_lit & 0x1FFF) == 0 && compressionLevel > CompressionLevel.Level2)
		{
			int num = last_lit << 3;
			int num2 = strstart - block_start;
			for (int i = 0; i < InternalConstants.D_CODES; i++)
			{
				num = (int)(num + dyn_dtree[i * 2] * (5L + Tree.ExtraDistanceBits[i]));
			}
			num >>= 3;
			if (matches < last_lit / 2 && num < num2 / 2)
			{
				return true;
			}
		}
		if (last_lit != lit_bufsize - 1)
		{
			return last_lit == lit_bufsize;
		}
		return true;
	}

	internal void send_compressed_block(short[] ltree, short[] dtree)
	{
		int num = 0;
		if (last_lit != 0)
		{
			do
			{
				int num2 = _distanceOffset + num * 2;
				int num3 = ((pending[num2] << 8) & 0xFF00) | (pending[num2 + 1] & 0xFF);
				int num4 = pending[_lengthOffset + num] & 0xFF;
				num++;
				if (num3 != 0)
				{
					int num5 = Tree.LengthCode[num4];
					send_code(num5 + InternalConstants.LITERALS + 1, ltree);
					int num6 = Tree.ExtraLengthBits[num5];
					if (num6 != 0)
					{
						num4 -= Tree.LengthBase[num5];
						send_bits(num4, num6);
					}
					num3--;
					num5 = Tree.DistanceCode(num3);
					send_code(num5, dtree);
					num6 = Tree.ExtraDistanceBits[num5];
					if (num6 != 0)
					{
						num3 -= Tree.DistanceBase[num5];
						send_bits(num3, num6);
					}
				}
				else
				{
					send_code(num4, ltree);
				}
			}
			while (num < last_lit);
		}
		send_code(int_18, ltree);
		last_eob_len = ltree[int_18 * 2 + 1];
	}

	internal void set_data_type()
	{
		int i = 0;
		int num = 0;
		int num2 = 0;
		for (; i < 7; i++)
		{
			num2 += dyn_ltree[i * 2];
		}
		for (; i < 128; i++)
		{
			num += dyn_ltree[i * 2];
		}
		for (; i < InternalConstants.LITERALS; i++)
		{
			num2 += dyn_ltree[i * 2];
		}
		data_type = (sbyte)((num2 > num >> 2) ? int_10 : int_11);
	}

	internal void bi_flush()
	{
		if (bi_valid == 16)
		{
			pending[pendingCount++] = (byte)bi_buf;
			pending[pendingCount++] = (byte)(bi_buf >> 8);
			bi_buf = 0;
			bi_valid = 0;
		}
		else if (bi_valid >= 8)
		{
			pending[pendingCount++] = (byte)bi_buf;
			bi_buf >>= 8;
			bi_valid -= 8;
		}
	}

	internal void bi_windup()
	{
		if (bi_valid > 8)
		{
			pending[pendingCount++] = (byte)bi_buf;
			pending[pendingCount++] = (byte)(bi_buf >> 8);
		}
		else if (bi_valid > 0)
		{
			pending[pendingCount++] = (byte)bi_buf;
		}
		bi_buf = 0;
		bi_valid = 0;
	}

	internal void copy_block(int buf, int len, bool header)
	{
		bi_windup();
		last_eob_len = 8;
		if (header)
		{
			pending[pendingCount++] = (byte)len;
			pending[pendingCount++] = (byte)(len >> 8);
			pending[pendingCount++] = (byte)(~len);
			pending[pendingCount++] = (byte)(~len >> 8);
		}
		method_2(window, buf, len);
	}

	internal void flush_block_only(bool eof)
	{
		_tr_flush_block((block_start >= 0) ? block_start : (-1), strstart - block_start, eof);
		block_start = strstart;
		_codec.flush_pending();
	}

	internal BlockState DeflateNone(FlushType flush)
	{
		int num = 65535;
		if (65535 > pending.Length - 5)
		{
			num = pending.Length - 5;
		}
		while (true)
		{
			if (lookahead <= 1)
			{
				method_3();
				if (lookahead == 0 && flush == FlushType.None)
				{
					return BlockState.NeedMore;
				}
				if (lookahead == 0)
				{
					flush_block_only(flush == FlushType.Finish);
					if (_codec.AvailableBytesOut == 0)
					{
						if (flush != FlushType.Finish)
						{
							return BlockState.NeedMore;
						}
						return BlockState.FinishStarted;
					}
					if (flush != FlushType.Finish)
					{
						return BlockState.BlockDone;
					}
					return BlockState.FinishDone;
				}
			}
			strstart += lookahead;
			lookahead = 0;
			int num2 = block_start + num;
			if (strstart == 0 || strstart >= num2)
			{
				lookahead = strstart - num2;
				strstart = num2;
				flush_block_only(eof: false);
				if (_codec.AvailableBytesOut == 0)
				{
					return BlockState.NeedMore;
				}
			}
			if (strstart - block_start >= w_size - int_16)
			{
				flush_block_only(eof: false);
				if (_codec.AvailableBytesOut == 0)
				{
					break;
				}
			}
		}
		return BlockState.NeedMore;
	}

	internal void _tr_stored_block(int buf, int stored_len, bool eof)
	{
		send_bits((int_7 << 1) + (eof ? 1 : 0), 3);
		copy_block(buf, stored_len, header: true);
	}

	internal void _tr_flush_block(int buf, int stored_len, bool eof)
	{
		int num = 0;
		int num2;
		int num3;
		if (compressionLevel > CompressionLevel.None)
		{
			if (data_type == int_12)
			{
				set_data_type();
			}
			treeLiterals.build_tree(this);
			treeDistances.build_tree(this);
			num = build_bl_tree();
			num2 = opt_len + 3 + 7 >> 3;
			num3 = static_len + 3 + 7 >> 3;
			if (num3 <= num2)
			{
				num2 = num3;
			}
		}
		else
		{
			num2 = (num3 = stored_len + 5);
		}
		if (stored_len + 4 <= num2 && buf != -1)
		{
			_tr_stored_block(buf, stored_len, eof);
		}
		else if (num3 == num2)
		{
			send_bits((int_8 << 1) + (eof ? 1 : 0), 3);
			send_compressed_block(StaticTree.lengthAndLiteralsTreeCodes, StaticTree.distTreeCodes);
		}
		else
		{
			send_bits((int_9 << 1) + (eof ? 1 : 0), 3);
			send_all_trees(treeLiterals.max_code + 1, treeDistances.max_code + 1, num + 1);
			send_compressed_block(dyn_ltree, dyn_dtree);
		}
		_InitializeBlocks();
		if (eof)
		{
			bi_windup();
		}
	}

	private void method_3()
	{
		do
		{
			int num = window_size - lookahead - strstart;
			if (num != 0 || strstart != 0 || lookahead != 0)
			{
				if (num == -1)
				{
					num--;
				}
				else if (strstart >= w_size + w_size - int_16)
				{
					Array.Copy(window, w_size, window, 0, w_size);
					match_start -= w_size;
					strstart -= w_size;
					block_start -= w_size;
					int num2 = hash_size;
					int num3 = num2;
					do
					{
						int num4 = head[--num3] & 0xFFFF;
						head[num3] = (short)((num4 >= w_size) ? (num4 - w_size) : 0);
					}
					while (--num2 != 0);
					num2 = w_size;
					num3 = num2;
					do
					{
						int num4 = prev[--num3] & 0xFFFF;
						prev[num3] = (short)((num4 >= w_size) ? (num4 - w_size) : 0);
					}
					while (--num2 != 0);
					num += w_size;
				}
			}
			else
			{
				num = w_size;
			}
			if (_codec.AvailableBytesIn != 0)
			{
				int num2 = _codec.read_buf(window, strstart + lookahead, num);
				lookahead += num2;
				if (lookahead >= int_14)
				{
					ins_h = window[strstart] & 0xFF;
					ins_h = ((ins_h << hash_shift) ^ (window[strstart + 1] & 0xFF)) & hash_mask;
				}
				continue;
			}
			break;
		}
		while (lookahead < int_16 && _codec.AvailableBytesIn != 0);
	}

	internal BlockState DeflateFast(FlushType flush)
	{
		int num = 0;
		while (true)
		{
			if (lookahead < int_16)
			{
				method_3();
				if (lookahead < int_16 && flush == FlushType.None)
				{
					return BlockState.NeedMore;
				}
				if (lookahead == 0)
				{
					flush_block_only(flush == FlushType.Finish);
					if (_codec.AvailableBytesOut == 0)
					{
						if (flush == FlushType.Finish)
						{
							return BlockState.FinishStarted;
						}
						return BlockState.NeedMore;
					}
					if (flush != FlushType.Finish)
					{
						return BlockState.BlockDone;
					}
					return BlockState.FinishDone;
				}
			}
			if (lookahead >= int_14)
			{
				ins_h = ((ins_h << hash_shift) ^ (window[strstart + (int_14 - 1)] & 0xFF)) & hash_mask;
				num = head[ins_h] & 0xFFFF;
				prev[strstart & w_mask] = head[ins_h];
				head[ins_h] = (short)strstart;
			}
			if (num != 0L && ((strstart - num) & 0xFFFF) <= w_size - int_16 && compressionStrategy != CompressionStrategy.HuffmanOnly)
			{
				match_length = longest_match(num);
			}
			bool flag;
			if (match_length >= int_14)
			{
				flag = _tr_tally(strstart - match_start, match_length - int_14);
				lookahead -= match_length;
				if (match_length <= config_0.MaxLazy && lookahead >= int_14)
				{
					match_length--;
					do
					{
						strstart++;
						ins_h = ((ins_h << hash_shift) ^ (window[strstart + (int_14 - 1)] & 0xFF)) & hash_mask;
						num = head[ins_h] & 0xFFFF;
						prev[strstart & w_mask] = head[ins_h];
						head[ins_h] = (short)strstart;
					}
					while (--match_length != 0);
					strstart++;
				}
				else
				{
					strstart += match_length;
					match_length = 0;
					ins_h = window[strstart] & 0xFF;
					ins_h = ((ins_h << hash_shift) ^ (window[strstart + 1] & 0xFF)) & hash_mask;
				}
			}
			else
			{
				flag = _tr_tally(0, window[strstart] & 0xFF);
				lookahead--;
				strstart++;
			}
			if (flag)
			{
				flush_block_only(eof: false);
				if (_codec.AvailableBytesOut == 0)
				{
					break;
				}
			}
		}
		return BlockState.NeedMore;
	}

	internal BlockState DeflateSlow(FlushType flush)
	{
		int num = 0;
		while (true)
		{
			if (lookahead < int_16)
			{
				method_3();
				if (lookahead < int_16 && flush == FlushType.None)
				{
					return BlockState.NeedMore;
				}
				if (lookahead == 0)
				{
					if (match_available != 0)
					{
						bool flag = _tr_tally(0, window[strstart - 1] & 0xFF);
						match_available = 0;
					}
					flush_block_only(flush == FlushType.Finish);
					if (_codec.AvailableBytesOut == 0)
					{
						if (flush == FlushType.Finish)
						{
							return BlockState.FinishStarted;
						}
						return BlockState.NeedMore;
					}
					if (flush != FlushType.Finish)
					{
						return BlockState.BlockDone;
					}
					return BlockState.FinishDone;
				}
			}
			if (lookahead >= int_14)
			{
				ins_h = ((ins_h << hash_shift) ^ (window[strstart + (int_14 - 1)] & 0xFF)) & hash_mask;
				num = head[ins_h] & 0xFFFF;
				prev[strstart & w_mask] = head[ins_h];
				head[ins_h] = (short)strstart;
			}
			prev_length = match_length;
			prev_match = match_start;
			match_length = int_14 - 1;
			if (num != 0 && prev_length < config_0.MaxLazy && ((strstart - num) & 0xFFFF) <= w_size - int_16)
			{
				if (compressionStrategy != CompressionStrategy.HuffmanOnly)
				{
					match_length = longest_match(num);
				}
				if (match_length <= 5 && (compressionStrategy == CompressionStrategy.Filtered || (match_length == int_14 && strstart - match_start > 4096)))
				{
					match_length = int_14 - 1;
				}
			}
			if (prev_length >= int_14 && match_length <= prev_length)
			{
				int num2 = strstart + lookahead - int_14;
				bool flag = _tr_tally(strstart - 1 - prev_match, prev_length - int_14);
				lookahead -= prev_length - 1;
				prev_length -= 2;
				do
				{
					if (++strstart <= num2)
					{
						ins_h = ((ins_h << hash_shift) ^ (window[strstart + (int_14 - 1)] & 0xFF)) & hash_mask;
						num = head[ins_h] & 0xFFFF;
						prev[strstart & w_mask] = head[ins_h];
						head[ins_h] = (short)strstart;
					}
				}
				while (--prev_length != 0);
				match_available = 0;
				match_length = int_14 - 1;
				strstart++;
				if (flag)
				{
					flush_block_only(eof: false);
					if (_codec.AvailableBytesOut == 0)
					{
						return BlockState.NeedMore;
					}
				}
			}
			else if (match_available != 0)
			{
				bool flag;
				if (flag = _tr_tally(0, window[strstart - 1] & 0xFF))
				{
					flush_block_only(eof: false);
				}
				strstart++;
				lookahead--;
				if (_codec.AvailableBytesOut == 0)
				{
					break;
				}
			}
			else
			{
				match_available = 1;
				strstart++;
				lookahead--;
			}
		}
		return BlockState.NeedMore;
	}

	internal int longest_match(int cur_match)
	{
		int num = config_0.MaxChainLength;
		int num2 = strstart;
		int num3 = prev_length;
		int num4 = ((strstart > w_size - int_16) ? (strstart - (w_size - int_16)) : 0);
		int niceLength = config_0.NiceLength;
		int num5 = w_mask;
		int num6 = strstart + int_15;
		byte b = window[num2 + num3 - 1];
		byte b2 = window[num2 + num3];
		if (prev_length >= config_0.GoodLength)
		{
			num >>= 2;
		}
		if (niceLength > lookahead)
		{
			niceLength = lookahead;
		}
		do
		{
			int num7 = cur_match;
			if (window[num7 + num3] != b2 || window[num7 + num3 - 1] != b || window[num7] != window[num2] || window[++num7] != window[num2 + 1])
			{
				continue;
			}
			num2 += 2;
			num7++;
			while (window[++num2] == window[++num7] && window[++num2] == window[++num7] && window[++num2] == window[++num7] && window[++num2] == window[++num7] && window[++num2] == window[++num7] && window[++num2] == window[++num7] && window[++num2] == window[++num7] && window[++num2] == window[++num7] && num2 < num6)
			{
			}
			int num8 = int_15 - (num6 - num2);
			num2 = num6 - int_15;
			if (num8 > num3)
			{
				match_start = cur_match;
				num3 = num8;
				if (num8 >= niceLength)
				{
					break;
				}
				b = window[num2 + num3 - 1];
				b2 = window[num2 + num3];
			}
		}
		while ((cur_match = prev[cur_match & num5] & 0xFFFF) > num4 && --num != 0);
		if (num3 <= lookahead)
		{
			return num3;
		}
		return lookahead;
	}

	internal int Initialize(ZlibCodec codec, CompressionLevel level)
	{
		return Initialize(codec, level, 15);
	}

	internal int Initialize(ZlibCodec codec, CompressionLevel level, int bits)
	{
		return Initialize(codec, level, bits, int_1, CompressionStrategy.Default);
	}

	internal int Initialize(ZlibCodec codec, CompressionLevel level, int bits, CompressionStrategy compressionStrategy)
	{
		return Initialize(codec, level, bits, int_1, compressionStrategy);
	}

	internal int Initialize(ZlibCodec codec, CompressionLevel level, int windowBits, int memLevel, CompressionStrategy strategy)
	{
		_codec = codec;
		_codec.Message = null;
		if (windowBits >= 9 && windowBits <= 15)
		{
			if (memLevel < 1 || memLevel > int_0)
			{
				throw new ZlibException(string.Format(Class16.smethod_0(1648892760), int_0));
			}
			_codec.dstate = this;
			w_bits = windowBits;
			w_size = 1 << w_bits;
			w_mask = w_size - 1;
			hash_bits = memLevel + 7;
			hash_size = 1 << hash_bits;
			hash_mask = hash_size - 1;
			hash_shift = (hash_bits + int_14 - 1) / int_14;
			window = new byte[w_size * 2];
			prev = new short[w_size];
			head = new short[hash_size];
			lit_bufsize = 1 << memLevel + 6;
			pending = new byte[lit_bufsize * 4];
			_distanceOffset = lit_bufsize;
			_lengthOffset = 3 * lit_bufsize;
			compressionLevel = level;
			compressionStrategy = strategy;
			Reset();
			return 0;
		}
		throw new ZlibException(Class16.smethod_0(1648892715));
	}

	internal void Reset()
	{
		ZlibCodec codec = _codec;
		_codec.TotalBytesOut = 0L;
		codec.TotalBytesIn = 0L;
		_codec.Message = null;
		pendingCount = 0;
		nextPending = 0;
		bool_0 = false;
		status = (WantRfc1950HeaderBytes ? int_3 : int_4);
		_codec._Adler32 = Adler.Adler32(0u, null, 0, 0);
		last_flush = 0;
		method_1();
		method_0();
	}

	internal int End()
	{
		if (status != int_3 && status != int_4 && status != int_5)
		{
			return -2;
		}
		pending = null;
		head = null;
		prev = null;
		window = null;
		if (status != int_4)
		{
			return 0;
		}
		return -3;
	}

	private void method_4()
	{
		switch (config_0.Flavor)
		{
		case DeflateFlavor.Store:
			compressFunc_0 = DeflateNone;
			break;
		case DeflateFlavor.Fast:
			compressFunc_0 = DeflateFast;
			break;
		case DeflateFlavor.Slow:
			compressFunc_0 = DeflateSlow;
			break;
		}
	}

	internal int SetParams(CompressionLevel level, CompressionStrategy strategy)
	{
		int result = 0;
		if (compressionLevel != level)
		{
			Config config = Config.Lookup(level);
			if (config.Flavor != config_0.Flavor && _codec.TotalBytesIn != 0L)
			{
				result = _codec.Deflate(FlushType.Partial);
			}
			compressionLevel = level;
			config_0 = config;
			method_4();
		}
		compressionStrategy = strategy;
		return result;
	}

	internal int SetDictionary(byte[] dictionary)
	{
		int num = dictionary.Length;
		int sourceIndex = 0;
		if (dictionary != null && status == int_3)
		{
			_codec._Adler32 = Adler.Adler32(_codec._Adler32, dictionary, 0, dictionary.Length);
			if (num < int_14)
			{
				return 0;
			}
			if (num > w_size - int_16)
			{
				num = w_size - int_16;
				sourceIndex = dictionary.Length - num;
			}
			Array.Copy(dictionary, sourceIndex, window, 0, num);
			strstart = num;
			block_start = num;
			ins_h = window[0] & 0xFF;
			ins_h = ((ins_h << hash_shift) ^ (window[1] & 0xFF)) & hash_mask;
			for (int i = 0; i <= num - int_14; i++)
			{
				ins_h = ((ins_h << hash_shift) ^ (window[i + (int_14 - 1)] & 0xFF)) & hash_mask;
				prev[i & w_mask] = head[ins_h];
				head[ins_h] = (short)i;
			}
			return 0;
		}
		throw new ZlibException(Class16.smethod_0(1648892812));
	}

	internal int Deflate(FlushType flush)
	{
		if (_codec.OutputBuffer != null && (_codec.InputBuffer != null || _codec.AvailableBytesIn == 0) && (status != int_5 || flush == FlushType.Finish))
		{
			if (_codec.AvailableBytesOut == 0)
			{
				_codec.Message = string_0[7];
				throw new ZlibException(Class16.smethod_0(1648892856));
			}
			int num = last_flush;
			last_flush = (int)flush;
			if (status == int_3)
			{
				int num2 = int_6 + (w_bits - 8 << 4) << 8;
				int num3 = (int)((compressionLevel - 1) & (CompressionLevel)255) >> 1;
				if (num3 > 3)
				{
					num3 = 3;
				}
				num2 |= num3 << 6;
				if (strstart != 0)
				{
					num2 |= int_2;
				}
				num2 += 31 - num2 % 31;
				status = int_4;
				pending[pendingCount++] = (byte)(num2 >> 8);
				pending[pendingCount++] = (byte)num2;
				if (strstart != 0)
				{
					pending[pendingCount++] = (byte)((_codec._Adler32 & 0xFF000000u) >> 24);
					pending[pendingCount++] = (byte)((_codec._Adler32 & 0xFF0000) >> 16);
					pending[pendingCount++] = (byte)((_codec._Adler32 & 0xFF00) >> 8);
					pending[pendingCount++] = (byte)_codec._Adler32;
				}
				_codec._Adler32 = Adler.Adler32(0u, null, 0, 0);
			}
			if (pendingCount != 0)
			{
				_codec.flush_pending();
				if (_codec.AvailableBytesOut == 0)
				{
					last_flush = -1;
					return 0;
				}
			}
			else if (_codec.AvailableBytesIn == 0 && (int)flush <= num && flush != FlushType.Finish)
			{
				return 0;
			}
			if (status == int_5 && _codec.AvailableBytesIn != 0)
			{
				_codec.Message = string_0[7];
				throw new ZlibException(Class16.smethod_0(1648892916));
			}
			if (_codec.AvailableBytesIn != 0 || lookahead != 0 || (flush != FlushType.None && status != int_5))
			{
				BlockState blockState = compressFunc_0(flush);
				if (blockState == BlockState.FinishStarted || blockState == BlockState.FinishDone)
				{
					status = int_5;
				}
				if (blockState == BlockState.NeedMore || blockState == BlockState.FinishStarted)
				{
					if (_codec.AvailableBytesOut == 0)
					{
						last_flush = -1;
					}
					return 0;
				}
				if (blockState == BlockState.BlockDone)
				{
					if (flush == FlushType.Partial)
					{
						_tr_align();
					}
					else
					{
						_tr_stored_block(0, 0, eof: false);
						if (flush == FlushType.Full)
						{
							for (int i = 0; i < hash_size; i++)
							{
								head[i] = 0;
							}
						}
					}
					_codec.flush_pending();
					if (_codec.AvailableBytesOut == 0)
					{
						last_flush = -1;
						return 0;
					}
				}
			}
			if (flush != FlushType.Finish)
			{
				return 0;
			}
			if (WantRfc1950HeaderBytes && !bool_0)
			{
				pending[pendingCount++] = (byte)((_codec._Adler32 & 0xFF000000u) >> 24);
				pending[pendingCount++] = (byte)((_codec._Adler32 & 0xFF0000) >> 16);
				pending[pendingCount++] = (byte)((_codec._Adler32 & 0xFF00) >> 8);
				pending[pendingCount++] = (byte)_codec._Adler32;
				_codec.flush_pending();
				bool_0 = true;
				return (pendingCount == 0) ? 1 : 0;
			}
			return 1;
		}
		_codec.Message = string_0[4];
		throw new ZlibException(string.Format(Class16.smethod_0(1648892824), _codec.Message));
	}
}
