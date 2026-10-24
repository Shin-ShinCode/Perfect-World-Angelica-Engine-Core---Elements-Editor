using System.IO;

namespace ACE.Dependency.zlib.net;

public class ZInputStream : BinaryReader
{
	protected ZStream zstream_0 = new ZStream();

	protected int bufsize = 512;

	protected int flush;

	protected byte[] buf;

	protected byte[] buf1 = new byte[1];

	protected bool compress;

	internal Stream in_Renamed;

	internal bool nomoreinput;

	public virtual int FlushMode
	{
		get
		{
			return flush;
		}
		set
		{
			flush = value;
		}
	}

	public virtual long TotalIn => zstream_0.total_in;

	public virtual long TotalOut => zstream_0.total_out;

	public ZInputStream(Stream in_Renamed)
		: base(in_Renamed)
	{
		InitBlock();
		this.in_Renamed = in_Renamed;
		zstream_0.inflateInit();
		compress = false;
		zstream_0.next_in = buf;
		zstream_0.next_in_index = 0;
		zstream_0.avail_in = 0;
	}

	public ZInputStream(Stream in_Renamed, int level)
		: base(in_Renamed)
	{
		InitBlock();
		this.in_Renamed = in_Renamed;
		zstream_0.deflateInit(level);
		compress = true;
		zstream_0.next_in = buf;
		zstream_0.next_in_index = 0;
		zstream_0.avail_in = 0;
	}

	internal void InitBlock()
	{
		flush = 0;
		buf = new byte[bufsize];
	}

	public override int Read()
	{
		if (read(buf1, 0, 1) == -1)
		{
			return -1;
		}
		return buf1[0] & 0xFF;
	}

	public int read(byte[] byte_0, int off, int len)
	{
		if (len == 0)
		{
			return 0;
		}
		zstream_0.next_out = byte_0;
		zstream_0.next_out_index = off;
		zstream_0.avail_out = len;
		int num;
		do
		{
			if (zstream_0.avail_in == 0 && !nomoreinput)
			{
				zstream_0.next_in_index = 0;
				zstream_0.avail_in = SupportClass.ReadInput(in_Renamed, buf, 0, bufsize);
				if (zstream_0.avail_in == -1)
				{
					zstream_0.avail_in = 0;
					nomoreinput = true;
				}
			}
			num = ((!compress) ? zstream_0.inflate(flush) : zstream_0.deflate(flush));
			if (!nomoreinput || num != -5)
			{
				if (num == 0 || num == 1)
				{
					if (nomoreinput && zstream_0.avail_out == len)
					{
						return -1;
					}
					continue;
				}
				throw new ZStreamException((compress ? Class16.smethod_0(1648898033) : Class16.smethod_0(1648886891)) + Class16.smethod_0(1648886908) + zstream_0.msg);
			}
			return -1;
		}
		while (zstream_0.avail_out == len && num == 0);
		return len - zstream_0.avail_out;
	}

	public long skip(long long_0)
	{
		int num = 512;
		if (long_0 < 512L)
		{
			num = (int)long_0;
		}
		byte[] array = new byte[num];
		return SupportClass.ReadInput(BaseStream, array, 0, array.Length);
	}

	public override void Close()
	{
		in_Renamed.Close();
	}
}
