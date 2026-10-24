using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACE.BonFileEditor;

internal class MemoryManager
{
	private IntPtr intptr_0;

	public MemoryManager(IntPtr pHandle)
	{
		intptr_0 = pHandle;
	}

	public int ReadInt32(int address)
	{
		return MemFunctions.MemReadInt(intptr_0, address);
	}

	public uint ReadUInt32(int address)
	{
		return MemFunctions.MemReadUInt(intptr_0, address);
	}

	public float ReadFloat(int address)
	{
		return MemFunctions.MemReadFloat(intptr_0, address);
	}

	public byte[] ReadBytes(int address, int amount)
	{
		return MemFunctions.MemReadBytes(intptr_0, address, amount);
	}

	public string ReadUnicode(int address)
	{
		return MemFunctions.MemReadUnicode(intptr_0, address);
	}

	public void Write(int address, object data, bool reverse)
	{
		if (data is byte value)
		{
			MemFunctions.MemWriteByte(intptr_0, address, value);
			return;
		}
		byte[] array = null;
		if (data is int value2)
		{
			array = BitConverter.GetBytes(value2);
		}
		if (data is uint value3)
		{
			array = BitConverter.GetBytes(value3);
		}
		if (data is short value4)
		{
			array = BitConverter.GetBytes(value4);
		}
		if (data is float value5)
		{
			array = BitConverter.GetBytes(value5);
		}
		if (data is long value6)
		{
			array = BitConverter.GetBytes(value6);
		}
		if (data is bool)
		{
			array = BitConverter.GetBytes((bool)data);
		}
		if (data is byte[])
		{
			array = (byte[])data;
		}
		if (reverse)
		{
			array?.Reverse();
		}
		MemFunctions.MemWriteBytes(intptr_0, address, array);
	}

	public void Write64(long address, object data, bool reverse)
	{
		if (data is byte value)
		{
			MemFunctions.MemWriteByte64(intptr_0, address, value);
			return;
		}
		byte[] array = null;
		if (data is int value2)
		{
			array = BitConverter.GetBytes(value2);
		}
		if (data is uint value3)
		{
			array = BitConverter.GetBytes(value3);
		}
		if (data is short value4)
		{
			array = BitConverter.GetBytes(value4);
		}
		if (data is float value5)
		{
			array = BitConverter.GetBytes(value5);
		}
		if (data is long value6)
		{
			array = BitConverter.GetBytes(value6);
		}
		if (data is bool)
		{
			array = BitConverter.GetBytes((bool)data);
		}
		if (data is byte[])
		{
			array = (byte[])data;
		}
		if (reverse)
		{
			array?.Reverse();
		}
		MemFunctions.MemWriteBytes64(intptr_0, address, array);
	}

	public void Write(int address, object data)
	{
		Write(address, data, reverse: false);
	}

	public void Write64(long address, object data)
	{
		Write64(address, data, reverse: false);
	}

	public int Allocate(int amount)
	{
		return MemFunctions.AllocateMemory(intptr_0, amount);
	}

	public IntPtr CreateRemoteThread(int address)
	{
		return MemFunctions.CreateRemoteThread(intptr_0, address);
	}

	public void WaitThread(IntPtr thread)
	{
		MemFunctions.WaitForSingleObject(thread);
	}

	public void CloseThread(IntPtr thread)
	{
		MemFunctions.CloseProcess(thread);
	}

	public byte ReadByte(int address)
	{
		byte[] array = new byte[1];
		WinApi.ReadProcessMemory(intptr_0, address, array, array.Length, out var _);
		return array[0];
	}

	public short ReadInt16(int address)
	{
		byte[] array = new byte[2];
		WinApi.ReadProcessMemory(intptr_0, address, array, array.Length, out var _);
		return BitConverter.ToInt16(array, 0);
	}

	public long ReadInt64(long address)
	{
		byte[] array = new byte[8];
		WinApi.ReadProcessMemory_1(intptr_0, address, array, array.Length, out var _);
		return BitConverter.ToInt64(array, 0);
	}

	public double ReadDouble(int address)
	{
		byte[] array = new byte[8];
		WinApi.ReadProcessMemory(intptr_0, address, array, array.Length, out var _);
		return BitConverter.ToDouble(array, 0);
	}

	public string ReadString_Unicode(int address, int length)
	{
		byte[] array = new byte[length];
		WinApi.ReadProcessMemory(intptr_0, address, array, length, out var _);
		string text = new UnicodeEncoding().GetString(array);
		if (text.IndexOf('\0') == -1)
		{
			return text;
		}
		return text.Substring(0, text.IndexOf('\0'));
	}

	public string ReadString_Unicode64(long address, int length)
	{
		byte[] array = new byte[length];
		WinApi.ReadProcessMemory_1(intptr_0, address, array, length, out var _);
		string text = new UnicodeEncoding().GetString(array);
		if (text.IndexOf('\0') == -1)
		{
			return text;
		}
		return text.Substring(0, text.IndexOf('\0'));
	}

	public string ReadString_ASCII(int address, int length)
	{
		byte[] array = new byte[length];
		WinApi.ReadProcessMemory(intptr_0, address, array, length, out var _);
		string text = new ASCIIEncoding().GetString(array);
		if (text.IndexOf('\0') == -1)
		{
			return text;
		}
		return text.Substring(0, text.IndexOf('\0'));
	}

	public short ChainReadByte(int address, params int[] offsets)
	{
		if (offsets.Length == 0)
		{
			return ReadByte(address);
		}
		int num = ReadInt32(address);
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt32(num + offsets[i]);
		}
		return ReadByte(num + offsets[offsets.Length - 1]);
	}

	public short ChainReadInt16(int address, params int[] offsets)
	{
		if (offsets.Length == 0)
		{
			return ReadInt16(address);
		}
		int num = ReadInt32(address);
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt32(num + offsets[i]);
		}
		return ReadInt16(num + offsets[offsets.Length - 1]);
	}

	public int ChainReadInt32(int address, params int[] offsets)
	{
		if (offsets.Length == 0)
		{
			return ReadInt32(address);
		}
		int num = ReadInt32(address);
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt32(num + offsets[i]);
		}
		return ReadInt32(num + offsets[offsets.Length - 1]);
	}

	public uint ChainReadUInt32(int address, params int[] offsets)
	{
		if (offsets.Length == 0)
		{
			return ReadUInt32(address);
		}
		int num = ReadInt32(address);
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt32(num + offsets[i]);
		}
		return ReadUInt32(num + offsets[offsets.Length - 1]);
	}

	public long ChainReadInt64(int address, params int[] offsets)
	{
		if (offsets.Length == 0)
		{
			return ReadInt64(address);
		}
		int num = ReadInt32(address);
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt32(num + offsets[i]);
		}
		return ReadInt64(num + offsets[offsets.Length - 1]);
	}

	public float ChainReadFloat(int address, params int[] offsets)
	{
		if (offsets.Length == 0)
		{
			return ReadFloat(address);
		}
		int num = ReadInt32(address);
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt32(num + offsets[i]);
		}
		return ReadFloat(num + offsets[offsets.Length - 1]);
	}

	public double ChainReadDouble(int address, params int[] offsets)
	{
		if (offsets.Length == 0)
		{
			return ReadDouble(address);
		}
		int num = ReadInt32(address);
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt32(num + offsets[i]);
		}
		return ReadDouble(num + offsets[offsets.Length - 1]);
	}

	public string ChainReadString_Unicode(int address, int length, params int[] offsets)
	{
		if (offsets.Length == 0)
		{
			return ReadString_Unicode(address, length);
		}
		int num = ReadInt32(address);
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt32(num + offsets[i]);
		}
		return ReadString_Unicode(num + offsets[offsets.Length - 1], length);
	}

	public string ChainReadString_Unicode64(long address, int length, params int[] offsets)
	{
		if (offsets.Length == 0)
		{
			return ReadString_Unicode64(address, length);
		}
		long num = ReadInt64(address);
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt64(num + offsets[i]);
		}
		return ReadString_Unicode64(num + offsets[offsets.Length - 1], length);
	}

	public string ChainReadString_ASCII(int address, int length, params int[] offsets)
	{
		if (offsets.Length == 0)
		{
			return ReadString_ASCII(address, length);
		}
		int num = ReadInt32(address);
		for (int i = 0; i < offsets.Length - 1; i++)
		{
			num = ReadInt32(num + offsets[i]);
		}
		return ReadString_ASCII(num + offsets[offsets.Length - 1], length);
	}

	private int method_0(int int_0, int[] int_1)
	{
		if (int_1.Length == 0)
		{
			return ReadInt32(int_0);
		}
		int num = ReadInt32(int_0);
		for (int i = 0; i < int_1.Length - 1; i++)
		{
			num = ReadInt32(num + int_1[i]);
		}
		return num + int_1[int_1.Length - 1];
	}

	public bool WriteByte(int address, byte value)
	{
		int lpNumberOfBytesWritten;
		return WinApi.WriteProcessMemory(intptr_0, address, new byte[1] { value }, 1, out lpNumberOfBytesWritten);
	}

	public bool WriteBytes(int address, byte[] value)
	{
		int lpNumberOfBytesWritten;
		return WinApi.WriteProcessMemory(intptr_0, address, value, value.Length, out lpNumberOfBytesWritten);
	}

	public bool WriteInt16(int address, short value)
	{
		int lpNumberOfBytesWritten;
		return WinApi.WriteProcessMemory(intptr_0, address, BitConverter.GetBytes(value), 2, out lpNumberOfBytesWritten);
	}

	public bool WriteInt32(int address, int value)
	{
		int lpNumberOfBytesWritten;
		return WinApi.WriteProcessMemory(intptr_0, address, BitConverter.GetBytes(value), 4, out lpNumberOfBytesWritten);
	}

	public bool WriteInt64(int address, long value)
	{
		int lpNumberOfBytesWritten;
		return WinApi.WriteProcessMemory(intptr_0, address, BitConverter.GetBytes(value), 8, out lpNumberOfBytesWritten);
	}

	public bool WriteFloat(int address, float value)
	{
		int lpNumberOfBytesWritten;
		return WinApi.WriteProcessMemory(intptr_0, address, BitConverter.GetBytes(value), 4, out lpNumberOfBytesWritten);
	}

	public bool WriteDouble(int address, double value)
	{
		int lpNumberOfBytesWritten;
		return WinApi.WriteProcessMemory(intptr_0, address, BitConverter.GetBytes(value), 8, out lpNumberOfBytesWritten);
	}

	public bool WriteString_Unicode(int address, string str)
	{
		List<byte> list = new List<byte>();
		list.AddRange(Encoding.Unicode.GetBytes(str));
		list.AddRange(Encoding.Unicode.GetBytes(Class16.smethod_0(1648938185)));
		int lpNumberOfBytesWritten;
		return WinApi.WriteProcessMemory(intptr_0, address, list.ToArray(), list.Count, out lpNumberOfBytesWritten);
	}

	public bool WriteString_ASCII(int address, string str)
	{
		List<byte> list = new List<byte>();
		list.AddRange(Encoding.ASCII.GetBytes(str));
		list.AddRange(Encoding.ASCII.GetBytes(Class16.smethod_0(1648938185)));
		int lpNumberOfBytesWritten;
		return WinApi.WriteProcessMemory(intptr_0, address, list.ToArray(), list.Count, out lpNumberOfBytesWritten);
	}

	public bool ChainWriteByte(byte value, int address, params int[] offsets)
	{
		return WriteByte(method_0(address, offsets), value);
	}

	public bool ChainWriteBytes(byte[] value, int address, params int[] offsets)
	{
		return WriteBytes(method_0(address, offsets), value);
	}

	public bool ChainWriteInt16(short value, int address, params int[] offsets)
	{
		return WriteInt16(method_0(address, offsets), value);
	}

	public bool ChainWriteInt32(int value, int address, params int[] offsets)
	{
		return WriteInt32(method_0(address, offsets), value);
	}

	public bool ChainWriteInt64(long value, int address, params int[] offsets)
	{
		return WriteInt64(method_0(address, offsets), value);
	}

	public bool ChainWriteFloat(float value, int address, params int[] offsets)
	{
		return WriteFloat(method_0(address, offsets), value);
	}

	public bool ChainWriteDouble(double value, int address, params int[] offsets)
	{
		return WriteDouble(method_0(address, offsets), value);
	}

	public bool ChainWriteString(string str, int address, params int[] offsets)
	{
		return WriteString_Unicode(method_0(address, offsets), str);
	}
}
