using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ACE.Dependency.Ionic.Zlib;

public class ParallelDeflateOutputStream : Stream
{
	private enum Enum5 : uint
	{

	}

	private static readonly int int_0 = 65536;

	private static readonly int int_1 = 4;

	private List<WorkItem> list_0;

	private bool bool_0;

	private bool bool_1;

	private Stream stream_0;

	private int int_2;

	private int int_3 = int_0;

	private AutoResetEvent autoResetEvent_0;

	private object object_0 = new object();

	private bool bool_2;

	private bool bool_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private CRC32 crc32_0;

	private object object_1 = new object();

	private Queue<int> queue_0;

	private Queue<int> queue_1;

	private long long_0;

	private CompressionLevel compressionLevel_0;

	private volatile Exception exception_0;

	private bool bool_4;

	private object object_2 = new object();

	private Enum5 enum5_0 = (Enum5)26942u;

	private CompressionStrategy compressionStrategy_0;

	public CompressionStrategy Strategy
	{
		[CompilerGenerated]
		get
		{
			return compressionStrategy_0;
		}
	}

	public int MaxBufferPairs
	{
		get
		{
			return int_2;
		}
		set
		{
			if (value < 4)
			{
				throw new ArgumentException(Class16.smethod_0(1648887700), Class16.smethod_0(1648887713));
			}
			int_2 = value;
		}
	}

	public int BufferSize
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value < 1024)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648887747), Class16.smethod_0(1648887772));
			}
			int_3 = value;
		}
	}

	public int Crc32 => int_8;

	public long BytesProcessed => long_0;

	public override bool CanSeek => false;

	public override bool CanRead => false;

	public override bool CanWrite => stream_0.CanWrite;

	public override long Length
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public override long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public ParallelDeflateOutputStream(Stream stream)
		: this(stream, CompressionLevel.Default, CompressionStrategy.Default, leaveOpen: false)
	{
	}

	public ParallelDeflateOutputStream(Stream stream, CompressionLevel level)
		: this(stream, level, CompressionStrategy.Default, leaveOpen: false)
	{
	}

	public ParallelDeflateOutputStream(Stream stream, bool leaveOpen)
		: this(stream, CompressionLevel.Default, CompressionStrategy.Default, leaveOpen)
	{
	}

	public ParallelDeflateOutputStream(Stream stream, CompressionLevel level, bool leaveOpen)
		: this(stream, CompressionLevel.Default, CompressionStrategy.Default, leaveOpen)
	{
	}

	public ParallelDeflateOutputStream(Stream stream, CompressionLevel level, CompressionStrategy strategy, bool leaveOpen)
	{
		stream_0 = stream;
		compressionLevel_0 = level;
		method_0(strategy);
		bool_0 = leaveOpen;
		MaxBufferPairs = 16;
	}

	private void method_0(CompressionStrategy compressionStrategy_1)
	{
		compressionStrategy_0 = compressionStrategy_1;
	}

	private void method_1()
	{
		queue_0 = new Queue<int>();
		queue_1 = new Queue<int>();
		list_0 = new List<WorkItem>();
		int val = int_1 * Environment.ProcessorCount;
		val = Math.Min(val, int_2);
		for (int i = 0; i < val; i++)
		{
			list_0.Add(new WorkItem(int_3, compressionLevel_0, Strategy, i));
			queue_1.Enqueue(i);
		}
		autoResetEvent_0 = new AutoResetEvent(initialState: false);
		crc32_0 = new CRC32();
		int_4 = -1;
		int_5 = -1;
		int_6 = -1;
		int_7 = -1;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		bool bool_ = false;
		if (bool_2)
		{
			throw new InvalidOperationException();
		}
		if (exception_0 != null)
		{
			bool_4 = true;
			Exception ex = exception_0;
			exception_0 = null;
			throw ex;
		}
		if (count == 0)
		{
			return;
		}
		if (!bool_3)
		{
			method_1();
			bool_3 = true;
		}
		while (true)
		{
			method_4(bool_5: false, bool_);
			bool_ = false;
			int num = -1;
			if (int_4 < 0)
			{
				if (queue_1.Count == 0)
				{
					bool_ = true;
					goto IL_0124;
				}
				num = queue_1.Dequeue();
				int_5++;
			}
			else
			{
				num = int_4;
			}
			WorkItem workItem = list_0[num];
			int num2 = ((workItem.buffer.Length - workItem.inputBytesAvailable > count) ? count : (workItem.buffer.Length - workItem.inputBytesAvailable));
			workItem.ordinal = int_5;
			Buffer.BlockCopy(buffer, offset, workItem.buffer, workItem.inputBytesAvailable, num2);
			count -= num2;
			offset += num2;
			workItem.inputBytesAvailable += num2;
			if (workItem.inputBytesAvailable == workItem.buffer.Length)
			{
				if (!ThreadPool.QueueUserWorkItem(method_5, workItem))
				{
					break;
				}
				int_4 = -1;
			}
			else
			{
				int_4 = num;
			}
			goto IL_0124;
			IL_0124:
			if (count <= 0)
			{
				return;
			}
		}
		throw new Exception(Class16.smethod_0(1648886797));
	}

	private void method_2()
	{
		byte[] array = new byte[128];
		ZlibCodec zlibCodec = new ZlibCodec();
		int num = zlibCodec.InitializeDeflate(compressionLevel_0, wantRfc1950Header: false);
		zlibCodec.InputBuffer = null;
		zlibCodec.NextIn = 0;
		zlibCodec.AvailableBytesIn = 0;
		zlibCodec.OutputBuffer = array;
		zlibCodec.NextOut = 0;
		zlibCodec.AvailableBytesOut = array.Length;
		num = zlibCodec.Deflate(FlushType.Finish);
		if (num != 1 && num != 0)
		{
			throw new Exception(Class16.smethod_0(1648886819) + zlibCodec.Message);
		}
		if (array.Length - zlibCodec.AvailableBytesOut > 0)
		{
			stream_0.Write(array, 0, array.Length - zlibCodec.AvailableBytesOut);
		}
		zlibCodec.EndDeflate();
		int_8 = crc32_0.Crc32Result;
	}

	private void method_3(bool bool_5)
	{
		if (bool_2)
		{
			throw new InvalidOperationException();
		}
		if (!bool_1)
		{
			if (int_4 >= 0)
			{
				WorkItem object_ = list_0[int_4];
				method_5(object_);
				int_4 = -1;
			}
			if (bool_5)
			{
				method_4(bool_5: true, bool_6: false);
				method_2();
			}
			else
			{
				method_4(bool_5: false, bool_6: false);
			}
		}
	}

	public override void Flush()
	{
		if (exception_0 != null)
		{
			bool_4 = true;
			Exception ex = exception_0;
			exception_0 = null;
			throw ex;
		}
		if (!bool_4)
		{
			method_3(bool_5: false);
		}
	}

	public override void Close()
	{
		if (exception_0 != null)
		{
			bool_4 = true;
			Exception ex = exception_0;
			exception_0 = null;
			throw ex;
		}
		if (!bool_4 && !bool_2)
		{
			method_3(bool_5: true);
			if (!bool_0)
			{
				stream_0.Close();
			}
			bool_2 = true;
		}
	}

	public new void Dispose()
	{
		Close();
		list_0 = null;
		Dispose(disposing: true);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	public void Reset(Stream stream)
	{
		if (!bool_3)
		{
			return;
		}
		queue_0.Clear();
		queue_1.Clear();
		foreach (WorkItem item in list_0)
		{
			queue_1.Enqueue(item.index);
			item.ordinal = -1;
		}
		bool_3 = false;
		long_0 = 0L;
		crc32_0 = new CRC32();
		bool_2 = false;
		int_4 = -1;
		int_5 = -1;
		int_6 = -1;
		int_7 = -1;
		stream_0 = stream;
	}

	private void method_4(bool bool_5, bool bool_6)
	{
		if (bool_1)
		{
			return;
		}
		bool_1 = true;
		if (bool_5 || bool_6)
		{
			autoResetEvent_0.WaitOne();
		}
		do
		{
			int num = -1;
			int num2 = (bool_5 ? 200 : (bool_6 ? (-1) : 0));
			int num3 = -1;
			do
			{
				if (!Monitor.TryEnter(queue_0, num2))
				{
					num3 = -1;
					continue;
				}
				num3 = -1;
				try
				{
					if (queue_0.Count > 0)
					{
						num3 = queue_0.Dequeue();
					}
				}
				finally
				{
					Monitor.Exit(queue_0);
				}
				if (num3 < 0)
				{
					continue;
				}
				WorkItem workItem = list_0[num3];
				if (workItem.ordinal != int_6 + 1)
				{
					lock (queue_0)
					{
						queue_0.Enqueue(num3);
					}
					if (num == num3)
					{
						autoResetEvent_0.WaitOne();
						num = -1;
					}
					else if (num == -1)
					{
						num = num3;
					}
					continue;
				}
				num = -1;
				stream_0.Write(workItem.compressed, 0, workItem.compressedBytesAvailable);
				crc32_0.Combine(workItem.crc, workItem.inputBytesAvailable);
				long_0 += workItem.inputBytesAvailable;
				workItem.inputBytesAvailable = 0;
				int_6 = workItem.ordinal;
				queue_1.Enqueue(workItem.index);
				if (num2 == -1)
				{
					num2 = 0;
				}
			}
			while (num3 >= 0);
		}
		while (bool_5 && int_6 != int_7);
		bool_1 = false;
	}

	private void method_5(object object_3)
	{
		WorkItem workItem = (WorkItem)object_3;
		try
		{
			CRC32 cRC = new CRC32();
			cRC.SlurpBlock(workItem.buffer, 0, workItem.inputBytesAvailable);
			method_6(workItem);
			workItem.crc = cRC.Crc32Result;
			lock (object_1)
			{
				if (workItem.ordinal > int_7)
				{
					int_7 = workItem.ordinal;
				}
			}
			lock (queue_0)
			{
				queue_0.Enqueue(workItem.index);
			}
			autoResetEvent_0.Set();
		}
		catch (Exception ex)
		{
			lock (object_2)
			{
				if (exception_0 != null)
				{
					exception_0 = ex;
				}
			}
		}
	}

	private bool method_6(WorkItem workItem_0)
	{
		ZlibCodec compressor = workItem_0.compressor;
		compressor.ResetDeflate();
		compressor.NextIn = 0;
		compressor.AvailableBytesIn = workItem_0.inputBytesAvailable;
		compressor.NextOut = 0;
		compressor.AvailableBytesOut = workItem_0.compressed.Length;
		do
		{
			compressor.Deflate(FlushType.None);
		}
		while (compressor.AvailableBytesIn > 0 || compressor.AvailableBytesOut == 0);
		compressor.Deflate(FlushType.Sync);
		workItem_0.compressedBytesAvailable = (int)compressor.TotalBytesOut;
		return true;
	}

	[Conditional("Trace")]
	private void method_7(Enum5 enum5_1, string string_0, object[] object_3)
	{
		if ((enum5_1 & enum5_0) != 0)
		{
			lock (object_0)
			{
				int hashCode = Thread.CurrentThread.GetHashCode();
				Console.ForegroundColor = (ConsoleColor)(hashCode % 8 + 8);
				Console.Write(Class16.smethod_0(1648886845), hashCode);
				Console.WriteLine(string_0, object_3);
				Console.ResetColor();
			}
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}
}
