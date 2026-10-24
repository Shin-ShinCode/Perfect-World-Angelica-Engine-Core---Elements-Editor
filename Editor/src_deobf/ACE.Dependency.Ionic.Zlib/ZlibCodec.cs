using System;
using System.Runtime.InteropServices;

namespace ACE.Dependency.Ionic.Zlib;

[ComVisible(true)]
[Guid("ebc25cf6-9120-4283-b972-0e5520d0000D")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class ZlibCodec
{
	public byte[] InputBuffer;

	public int NextIn;

	public int AvailableBytesIn;

	public long TotalBytesIn;

	public byte[] OutputBuffer;

	public int NextOut;

	public int AvailableBytesOut;

	public long TotalBytesOut;

	public string Message;

	internal DeflateManager dstate;

	internal InflateManager istate;

	internal uint _Adler32;

	public CompressionLevel CompressLevel = CompressionLevel.Default;

	public int WindowBits = 15;

	public CompressionStrategy Strategy;

	public int Adler32 => (int)_Adler32;

	public ZlibCodec()
	{
	}

	public ZlibCodec(CompressionMode mode)
	{
		switch (mode)
		{
		case CompressionMode.Compress:
			if (InitializeDeflate() != 0)
			{
				throw new ZlibException(Class16.smethod_0(1648886552));
			}
			break;
		case CompressionMode.Decompress:
			if (InitializeInflate() != 0)
			{
				throw new ZlibException(Class16.smethod_0(1648886597));
			}
			break;
		default:
			throw new ZlibException(Class16.smethod_0(1648886626));
		}
	}

	public int InitializeInflate()
	{
		return InitializeInflate(WindowBits);
	}

	public int InitializeInflate(bool expectRfc1950Header)
	{
		return InitializeInflate(WindowBits, expectRfc1950Header);
	}

	public int InitializeInflate(int windowBits)
	{
		WindowBits = windowBits;
		return InitializeInflate(windowBits, expectRfc1950Header: true);
	}

	public int InitializeInflate(int windowBits, bool expectRfc1950Header)
	{
		WindowBits = windowBits;
		if (dstate != null)
		{
			throw new ZlibException(Class16.smethod_0(1648886658));
		}
		istate = new InflateManager(expectRfc1950Header);
		return istate.Initialize(this, windowBits);
	}

	public int Inflate(FlushType flush)
	{
		if (istate == null)
		{
			throw new ZlibException(Class16.smethod_0(1648886736));
		}
		return istate.Inflate(flush);
	}

	public int EndInflate()
	{
		if (istate == null)
		{
			throw new ZlibException(Class16.smethod_0(1648886736));
		}
		int result = istate.End();
		istate = null;
		return result;
	}

	public int SyncInflate()
	{
		if (istate == null)
		{
			throw new ZlibException(Class16.smethod_0(1648886736));
		}
		return istate.Sync();
	}

	public int InitializeDeflate()
	{
		return method_0(bool_0: true);
	}

	public int InitializeDeflate(CompressionLevel level)
	{
		CompressLevel = level;
		return method_0(bool_0: true);
	}

	public int InitializeDeflate(CompressionLevel level, bool wantRfc1950Header)
	{
		CompressLevel = level;
		return method_0(wantRfc1950Header);
	}

	public int InitializeDeflate(CompressionLevel level, int bits)
	{
		CompressLevel = level;
		WindowBits = bits;
		return method_0(bool_0: true);
	}

	public int InitializeDeflate(CompressionLevel level, int bits, bool wantRfc1950Header)
	{
		CompressLevel = level;
		WindowBits = bits;
		return method_0(wantRfc1950Header);
	}

	private int method_0(bool bool_0)
	{
		if (istate != null)
		{
			throw new ZlibException(Class16.smethod_0(1648886760));
		}
		dstate = new DeflateManager();
		dstate.WantRfc1950HeaderBytes = bool_0;
		return dstate.Initialize(this, CompressLevel, WindowBits, Strategy);
	}

	public int Deflate(FlushType flush)
	{
		if (dstate == null)
		{
			throw new ZlibException(Class16.smethod_0(1648885822));
		}
		return dstate.Deflate(flush);
	}

	public int EndDeflate()
	{
		if (dstate == null)
		{
			throw new ZlibException(Class16.smethod_0(1648885822));
		}
		dstate = null;
		return 0;
	}

	public void ResetDeflate()
	{
		if (dstate == null)
		{
			throw new ZlibException(Class16.smethod_0(1648885822));
		}
		dstate.Reset();
	}

	public int SetDeflateParams(CompressionLevel level, CompressionStrategy strategy)
	{
		if (dstate == null)
		{
			throw new ZlibException(Class16.smethod_0(1648885822));
		}
		return dstate.SetParams(level, strategy);
	}

	public int SetDictionary(byte[] dictionary)
	{
		if (istate != null)
		{
			return istate.SetDictionary(dictionary);
		}
		if (dstate == null)
		{
			throw new ZlibException(Class16.smethod_0(1648885846));
		}
		return dstate.SetDictionary(dictionary);
	}

	internal void flush_pending()
	{
		int num = dstate.pendingCount;
		if (num > AvailableBytesOut)
		{
			num = AvailableBytesOut;
		}
		if (num != 0)
		{
			if (dstate.pending.Length <= dstate.nextPending || OutputBuffer.Length <= NextOut || dstate.pending.Length < dstate.nextPending + num || OutputBuffer.Length < NextOut + num)
			{
				throw new ZlibException(string.Format(Class16.smethod_0(1648885873), dstate.pending.Length, dstate.pendingCount));
			}
			Array.Copy(dstate.pending, dstate.nextPending, OutputBuffer, NextOut, num);
			NextOut += num;
			dstate.nextPending += num;
			TotalBytesOut += num;
			AvailableBytesOut -= num;
			dstate.pendingCount -= num;
			if (dstate.pendingCount == 0)
			{
				dstate.nextPending = 0;
			}
		}
	}

	internal int read_buf(byte[] buf, int start, int size)
	{
		int num = AvailableBytesIn;
		if (num > size)
		{
			num = size;
		}
		if (num == 0)
		{
			return 0;
		}
		AvailableBytesIn -= num;
		if (dstate.WantRfc1950HeaderBytes)
		{
			_Adler32 = Adler.Adler32(_Adler32, InputBuffer, NextIn, num);
		}
		Array.Copy(InputBuffer, NextIn, buf, start, num);
		NextIn += num;
		TotalBytesIn += num;
		return num;
	}
}
