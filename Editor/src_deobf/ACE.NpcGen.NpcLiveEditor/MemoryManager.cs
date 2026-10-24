using System;
using System.Runtime.InteropServices;
using System.Text;
using ACE.Classes;

namespace ACE.NpcGen.NpcLiveEditor;

public class MemoryManager
{
	private readonly IntPtr intptr_0;

	public MemoryManager(IntPtr processHandle)
	{
		intptr_0 = processHandle;
	}

	[DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
	private static extern IntPtr OpenProcess_1(uint uint_0, int int_0, uint uint_1);

	[DllImport("kernel32.dll")]
	private static extern bool ReadProcessMemory(IntPtr intptr_1, IntPtr intptr_2, byte[] byte_0, uint uint_0, ref uint uint_1);

	[DllImport("kernel32.dll")]
	private static extern bool WriteProcessMemory(IntPtr intptr_1, IntPtr intptr_2, byte[] byte_0, uint uint_0, ref uint uint_1);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr VirtualAllocEx(IntPtr intptr_1, IntPtr intptr_2, uint uint_0, uint uint_1, uint uint_2);

	[DllImport("kernel32.dll", EntryPoint = "CreateRemoteThread")]
	private static extern IntPtr CreateRemoteThread_1(IntPtr intptr_1, IntPtr intptr_2, uint uint_0, IntPtr intptr_3, IntPtr intptr_4, uint uint_1, IntPtr intptr_5);

	[DllImport("kernel32.dll", EntryPoint = "CloseHandle")]
	private static extern int CloseHandle_1(IntPtr intptr_1);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool VirtualFreeEx(IntPtr intptr_1, IntPtr intptr_2, int int_0, FreeType freeType_0);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern uint WaitForSingleObject(IntPtr intptr_1, uint uint_0);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "FindWindowEx", SetLastError = true)]
	private static extern IntPtr FindWindowEx_1(IntPtr intptr_1, IntPtr intptr_2, string string_0, string string_1);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowThreadProcessId", SetLastError = true)]
	private static extern uint GetWindowThreadProcessId_1(IntPtr intptr_1, out uint uint_0);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowText", SetLastError = true)]
	private static extern int GetWindowText_1(IntPtr intptr_1, StringBuilder stringBuilder_0, int int_0);

	public static IntPtr OpenProcess(int processId)
	{
		return OpenProcess_1(2035711u, 0, (uint)processId);
	}

	public static string GetWindowText(IntPtr handle)
	{
		StringBuilder stringBuilder = new StringBuilder(128);
		GetWindowText_1(handle, stringBuilder, 128);
		return stringBuilder.ToString();
	}

	public static IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow)
	{
		return FindWindowEx_1(hwndParent, hwndChildAfter, lpszClass, lpszWindow);
	}

	public static IntPtr GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId)
	{
		uint uint_;
		uint windowThreadProcessId_ = GetWindowThreadProcessId_1(hWnd, out uint_);
		lpdwProcessId = (int)uint_;
		return (IntPtr)windowThreadProcessId_;
	}

	public void CloseHandle()
	{
		CloseHandle_1(intptr_0);
	}

	public byte[] ReadBytes(IntPtr address, int size)
	{
		if (!(intptr_0 == IntPtr.Zero) && !(address == IntPtr.Zero) && size > 0)
		{
			byte[] array = new byte[size];
			uint uint_ = 0u;
			if (!ReadProcessMemory(intptr_0, address, array, (uint)size, ref uint_) || uint_ != size)
			{
				throw new InvalidOperationException(TextStorage.Msg(Class16.smethod_0(1649099981), Class16.smethod_0(1649092365)));
			}
			return array;
		}
		throw new InvalidOperationException(TextStorage.Msg(Class16.smethod_0(1649099981), Class16.smethod_0(1649092365)));
	}

	public T Read<T>(IntPtr address) where T : struct
	{
		int size = Marshal.SizeOf<T>();
		byte[] value = ReadBytes(address, size);
		GCHandle gCHandle = GCHandle.Alloc(value, GCHandleType.Pinned);
		try
		{
			return Marshal.PtrToStructure<T>(gCHandle.AddrOfPinnedObject());
		}
		finally
		{
			gCHandle.Free();
		}
	}

	public byte ReadByte(long address)
	{
		return Read<byte>((IntPtr)address);
	}

	public short ReadInt16(long address)
	{
		return Read<short>((IntPtr)address);
	}

	public int ReadInt32(long address)
	{
		return Read<int>((IntPtr)address);
	}

	public long ReadInt64(long address)
	{
		return Read<long>((IntPtr)address);
	}

	public float ReadFloat(long address)
	{
		return Read<float>((IntPtr)address);
	}

	public double ReadDouble(long address)
	{
		return Read<double>((IntPtr)address);
	}

	public uint ReadUInt32(long address)
	{
		return Read<uint>((IntPtr)address);
	}

	public string ReadString(long address, int maxLength, Encoding encoding)
	{
		byte[] bytes = ReadBytes((IntPtr)address, maxLength);
		string text = encoding.GetString(bytes);
		int num = text.IndexOf('\0');
		if (num < 0)
		{
			return text;
		}
		return text.Substring(0, num);
	}

	public string ReadUnicode(long address, int maxLength = 4096)
	{
		return ReadString(address, maxLength, Encoding.Unicode);
	}

	public string ReadAscii(long address, int maxLength = 4096)
	{
		return ReadString(address, maxLength, Encoding.ASCII);
	}

	public void WriteBytes(long address, byte[] buffer)
	{
		if (!(intptr_0 == IntPtr.Zero) && address != 0L && buffer != null && buffer.Length != 0)
		{
			uint uint_ = 0u;
			if (!WriteProcessMemory(intptr_0, (IntPtr)address, buffer, (uint)buffer.Length, ref uint_) || uint_ != buffer.Length)
			{
				throw new InvalidOperationException(TextStorage.Msg(Class16.smethod_0(1649099981), Class16.smethod_0(1649092365)));
			}
			return;
		}
		throw new InvalidOperationException(TextStorage.Msg(Class16.smethod_0(1649099981), Class16.smethod_0(1649092365)));
	}

	public void Write<T>(long address, T value) where T : struct
	{
		int num = Marshal.SizeOf<T>();
		byte[] array = new byte[num];
		GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
		try
		{
			Marshal.StructureToPtr(value, gCHandle.AddrOfPinnedObject(), fDeleteOld: false);
			WriteBytes(address, array);
		}
		finally
		{
			gCHandle.Free();
		}
	}

	public void WriteByte(long address, byte value)
	{
		Write(address, value);
	}

	public void WriteInt16(long address, short value)
	{
		Write(address, value);
	}

	public void WriteInt32(long address, int value)
	{
		Write(address, value);
	}

	public void WriteInt64(long address, long value)
	{
		Write(address, value);
	}

	public void WriteFloat(long address, float value)
	{
		Write(address, value);
	}

	public void WriteDouble(long address, double value)
	{
		Write(address, value);
	}

	public void WriteUInt32(long address, uint value)
	{
		Write(address, value);
	}

	public IntPtr AllocateMemory(int size)
	{
		return VirtualAllocEx(intptr_0, IntPtr.Zero, (uint)size, 4096u, 64u);
	}

	public void FreeMemory(IntPtr address)
	{
		VirtualFreeEx(intptr_0, address, 0, FreeType.Release);
	}

	public IntPtr CreateRemoteThread(long address)
	{
		return CreateRemoteThread_1(intptr_0, IntPtr.Zero, 0u, (IntPtr)address, IntPtr.Zero, 0u, IntPtr.Zero);
	}

	public void WaitForThread(IntPtr threadHandle)
	{
		WaitForSingleObject(threadHandle, uint.MaxValue);
	}

	public T ChainRead<T>(long baseAddress, params int[] offsets) where T : struct
	{
		long num = baseAddress;
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt32(num + offsets[i]);
		}
		return Read<T>((IntPtr)(num + offsets[offsets.Length - 1]));
	}

	public string ChainReadString_Unicode64(long address, int length, params int[] offsets)
	{
		if (offsets.Length == 0)
		{
			return ReadUnicode(address, length);
		}
		long num = ReadInt64(address);
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt64(num + offsets[i]);
		}
		return ReadUnicode(num + offsets[offsets.Length - 1], length);
	}

	public byte ChainReadByte(long address, params int[] offsets)
	{
		return ChainRead<byte>(address, offsets);
	}

	public short ChainReadInt16(long address, params int[] offsets)
	{
		return ChainRead<short>(address, offsets);
	}

	public int ChainReadInt32(long address, params int[] offsets)
	{
		return ChainRead<int>(address, offsets);
	}

	public long ChainReadInt64(long address, params int[] offsets)
	{
		return ChainRead<long>(address, offsets);
	}

	public float ChainReadFloat(long address, params int[] offsets)
	{
		return ChainRead<float>(address, offsets);
	}

	public double ChainReadDouble(long address, params int[] offsets)
	{
		return ChainRead<double>(address, offsets);
	}

	public uint ChainReadUInt32(long address, params int[] offsets)
	{
		return ChainRead<uint>(address, offsets);
	}
}
