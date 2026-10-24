using System;
using System.IO;

namespace ACE.Models;

public class MultiStream : Stream
{
	private readonly Stream[] stream_0;

	private readonly long[] long_0;

	private readonly long long_1;

	private long long_2;

	private int int_0;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length => long_1;

	public override long Position
	{
		get
		{
			return long_2;
		}
		set
		{
			if (value >= 0L && value <= long_1)
			{
				long_2 = value;
				if (value == long_1)
				{
					int_0 = stream_0.Length - 1;
					return;
				}
				while (int_0 > 0 && long_2 < long_0[int_0])
				{
					int_0--;
				}
				while (int_0 < stream_0.Length - 1 && long_2 >= long_0[int_0] + stream_0[int_0].Length)
				{
					int_0++;
				}
				return;
			}
			throw new ArgumentOutOfRangeException(Class16.smethod_0(1649116566));
		}
	}

	public MultiStream(params Stream[] underlyingStreams)
	{
		if (underlyingStreams == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1649116401));
		}
		int num = 0;
		while (true)
		{
			if (num < underlyingStreams.Length)
			{
				Stream stream = underlyingStreams[num] ?? throw new ArgumentException(Class16.smethod_0(1649116420), Class16.smethod_0(1649116477));
				if (stream.CanRead)
				{
					if (stream.CanSeek)
					{
						num++;
						continue;
					}
					throw new InvalidOperationException(Class16.smethod_0(1649116527));
				}
				throw new InvalidOperationException(Class16.smethod_0(1649116480));
			}
			stream_0 = new Stream[underlyingStreams.Length];
			long_0 = new long[underlyingStreams.Length];
			Array.Copy(underlyingStreams, stream_0, underlyingStreams.Length);
			long_2 = 0L;
			int_0 = 0;
			long_0[0] = 0L;
			for (int i = 1; i < long_0.Length; i++)
			{
				long_0[i] = long_0[i - 1] + stream_0[i - 1].Length;
			}
			break;
		}
		long_1 = long_0[long_0.Length - 1] + stream_0[stream_0.Length - 1].Length;
	}

	public override void Flush()
	{
		Stream[] array = stream_0;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Flush();
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = 0;
		while (count > 0)
		{
			stream_0[int_0].Position = long_2 - long_0[int_0];
			int num2 = stream_0[int_0].Read(buffer, offset, count);
			num += num2;
			offset += num2;
			count -= num2;
			long_2 += num2;
			if (count > 0)
			{
				if (int_0 >= stream_0.Length - 1)
				{
					break;
				}
				int_0++;
			}
		}
		return num;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		switch (origin)
		{
		case SeekOrigin.Begin:
			Position = offset;
			break;
		case SeekOrigin.Current:
			Position += offset;
			break;
		case SeekOrigin.End:
			Position = Length + offset;
			break;
		}
		return Position;
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException(Class16.smethod_0(1649116569));
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException(Class16.smethod_0(1649116635));
	}
}
