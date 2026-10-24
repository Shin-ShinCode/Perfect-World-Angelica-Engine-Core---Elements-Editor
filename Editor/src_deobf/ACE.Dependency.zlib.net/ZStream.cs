using System;

namespace ACE.Dependency.zlib.net;

public sealed class ZStream
{
	private static readonly int int_0 = 15;

	public byte[] next_in;

	public int next_in_index;

	public int avail_in;

	public long total_in;

	public byte[] next_out;

	public int next_out_index;

	public int avail_out;

	public long total_out;

	public string msg;

	internal Deflate dstate;

	internal Inflate istate;

	internal int data_type;

	public long adler;

	internal Adler32 _adler = new Adler32();

	public int inflateInit()
	{
		return inflateInit(int_0);
	}

	public int inflateInit(int int_1)
	{
		istate = new Inflate();
		return istate.inflateInit(this, int_1);
	}

	public int inflate(int int_1)
	{
		if (istate == null)
		{
			return -2;
		}
		return istate.inflate(this, int_1);
	}

	public int inflateEnd()
	{
		if (istate == null)
		{
			return -2;
		}
		int result = istate.inflateEnd(this);
		istate = null;
		return result;
	}

	public int inflateSync()
	{
		if (istate == null)
		{
			return -2;
		}
		return istate.inflateSync(this);
	}

	public int inflateSetDictionary(byte[] dictionary, int dictLength)
	{
		if (istate == null)
		{
			return -2;
		}
		return istate.inflateSetDictionary(this, dictionary, dictLength);
	}

	public int deflateInit(int level)
	{
		return deflateInit(level, 15);
	}

	public int deflateInit(int level, int bits)
	{
		dstate = new Deflate();
		return dstate.deflateInit(this, level, bits);
	}

	public int deflate(int flush)
	{
		if (dstate == null)
		{
			return -2;
		}
		return dstate.deflate(this, flush);
	}

	public int deflateEnd()
	{
		if (dstate == null)
		{
			return -2;
		}
		int result = dstate.deflateEnd();
		dstate = null;
		return result;
	}

	public int deflateParams(int level, int strategy)
	{
		if (dstate == null)
		{
			return -2;
		}
		return dstate.deflateParams(this, level, strategy);
	}

	public int deflateSetDictionary(byte[] dictionary, int dictLength)
	{
		if (dstate == null)
		{
			return -2;
		}
		return dstate.deflateSetDictionary(this, dictionary, dictLength);
	}

	internal void flush_pending()
	{
		int pending = dstate.pending;
		if (pending > avail_out)
		{
			pending = avail_out;
		}
		if (pending != 0)
		{
			if (dstate.pending_buf.Length <= dstate.pending_out || next_out.Length <= next_out_index || dstate.pending_buf.Length < dstate.pending_out + pending)
			{
			}
			Array.Copy(dstate.pending_buf, dstate.pending_out, next_out, next_out_index, pending);
			next_out_index += pending;
			dstate.pending_out += pending;
			total_out += pending;
			avail_out -= pending;
			dstate.pending -= pending;
			if (dstate.pending == 0)
			{
				dstate.pending_out = 0;
			}
		}
	}

	internal int read_buf(byte[] buf, int start, int size)
	{
		int num = avail_in;
		if (num > size)
		{
			num = size;
		}
		if (num == 0)
		{
			return 0;
		}
		avail_in -= num;
		if (dstate.noheader == 0)
		{
			adler = _adler.adler32(adler, next_in, next_in_index, num);
		}
		Array.Copy(next_in, next_in_index, buf, start, num);
		next_in_index += num;
		total_in += num;
		return num;
	}

	public void free()
	{
		next_in = null;
		next_out = null;
		msg = null;
		_adler = null;
	}
}
