using System;
using System.IO;

namespace ACE.Dependency.zlib.net;

public class ZOutputStream : Stream
{
	protected internal ZStream zstream_0 = new ZStream();

	protected internal int bufsize = 4096;

	protected internal int flush_Renamed_Field;

	protected internal byte[] buf;

	protected internal byte[] buf1 = new byte[1];

	protected internal bool compress;

	private Stream stream_0;

	public virtual int FlushMode
	{
		get
		{
			return flush_Renamed_Field;
		}
		set
		{
			flush_Renamed_Field = value;
		}
	}

	public virtual long TotalIn => zstream_0.total_in;

	public virtual long TotalOut => zstream_0.total_out;

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => false;

	public override long Length => 0L;

	public override long Position
	{
		get
		{
			return 0L;
		}
		set
		{
		}
	}

	public ZOutputStream(Stream out_Renamed)
	{
		method_0();
		stream_0 = out_Renamed;
		zstream_0.inflateInit();
		compress = false;
	}

	public ZOutputStream(Stream out_Renamed, int level)
	{
		method_0();
		stream_0 = out_Renamed;
		zstream_0.deflateInit(level);
		compress = true;
	}

	private void method_0()
	{
		flush_Renamed_Field = 0;
		buf = new byte[bufsize];
	}

	public void WriteByte(int int_0)
	{
		buf1[0] = (byte)int_0;
		Write(buf1, 0, 1);
	}

	public override void WriteByte(byte value)
	{
		WriteByte(value);
	}

	public override void Write(byte[] b1, int off, int len)
	{
		if (len == 0)
		{
			return;
		}
		byte[] array = new byte[b1.Length];
		Array.Copy(b1, 0, array, 0, b1.Length);
		zstream_0.next_in = array;
		zstream_0.next_in_index = off;
		zstream_0.avail_in = len;
		while (true)
		{
			zstream_0.next_out = buf;
			zstream_0.next_out_index = 0;
			zstream_0.avail_out = bufsize;
			int num = (compress ? zstream_0.deflate(flush_Renamed_Field) : zstream_0.inflate(flush_Renamed_Field));
			if (num != 0 && num != 1)
			{
				break;
			}
			stream_0.Write(buf, 0, bufsize - zstream_0.avail_out);
			if (zstream_0.avail_in <= 0 && zstream_0.avail_out != 0)
			{
				return;
			}
		}
		throw new ZStreamException((compress ? Class16.smethod_0(1648898033) : Class16.smethod_0(1648886891)) + Class16.smethod_0(1648886908) + zstream_0.msg);
	}

	public virtual void finish()
	{
		do
		{
			zstream_0.next_out = buf;
			zstream_0.next_out_index = 0;
			zstream_0.avail_out = bufsize;
			int num = (compress ? zstream_0.deflate(4) : zstream_0.inflate(4));
			if (num == 1 || num == 0)
			{
				if (bufsize - zstream_0.avail_out > 0)
				{
					stream_0.Write(buf, 0, bufsize - zstream_0.avail_out);
				}
				continue;
			}
			throw new ZStreamException((compress ? Class16.smethod_0(1648898033) : Class16.smethod_0(1648886891)) + Class16.smethod_0(1648886908) + zstream_0.msg);
		}
		while (zstream_0.avail_in > 0 || zstream_0.avail_out == 0);
		try
		{
			Flush();
		}
		catch
		{
		}
	}

	public virtual void end()
	{
		if (compress)
		{
			zstream_0.deflateEnd();
		}
		else
		{
			zstream_0.inflateEnd();
		}
		zstream_0.free();
		zstream_0 = null;
	}

	public override void Close()
	{
		try
		{
			finish();
		}
		catch
		{
		}
		finally
		{
			end();
			stream_0.Close();
			stream_0 = null;
		}
	}

	public override void Flush()
	{
		stream_0.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return 0;
	}

	public override void SetLength(long value)
	{
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return 0L;
	}
}
