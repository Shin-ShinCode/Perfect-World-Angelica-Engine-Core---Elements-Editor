using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACE.BonFileEditor;

internal class MemFunctions
{
	public enum EncodingType
	{
		ASCII,
		Unicode,
		UTF7,
		UTF8
	}

	[Flags]
	public enum FreeType
	{
		Decommit = 0x4000,
		Release = 0x8000
	}

	public delegate int ThreadProc(IntPtr param);

	[DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
	private static extern IntPtr OpenProcess_1(uint uint_0, int int_0, uint uint_1);

	[DllImport("Kernel32.dll")]
	private static extern bool ReadProcessMemory(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, uint uint_0, ref uint uint_1);

	[DllImport("kernel32.dll")]
	private static extern int CloseHandle(IntPtr intptr_0);

	[DllImport("kernel32.dll")]
	private static extern bool WriteProcessMemory(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, uint uint_0, ref uint uint_1);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool VirtualFreeEx(IntPtr intptr_0, IntPtr intptr_1, int int_0, FreeType freeType_0);

	[DllImport("kernel32.dll", EntryPoint = "WaitForSingleObject", SetLastError = true)]
	private static extern uint WaitForSingleObject_1(IntPtr intptr_0, uint uint_0);

	[DllImport("kernel32.dll", EntryPoint = "CreateRemoteThread")]
	private static extern IntPtr CreateRemoteThread_1(IntPtr intptr_0, IntPtr intptr_1, uint uint_0, IntPtr intptr_2, IntPtr intptr_3, uint uint_1, IntPtr intptr_4);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr VirtualAllocEx(IntPtr intptr_0, IntPtr intptr_1, uint uint_0, uint uint_1, uint uint_2);

	public static int AllocateMemory(IntPtr processHandle, int memorySize)
	{
		return (int)VirtualAllocEx(processHandle, (IntPtr)0, (uint)memorySize, 4096u, 64u);
	}

	public static IntPtr CreateRemoteThread(IntPtr processHandle, int address)
	{
		return CreateRemoteThread_1(processHandle, (IntPtr)0, 0u, (IntPtr)address, (IntPtr)0, 0u, (IntPtr)0);
	}

	public static void WaitForSingleObject(IntPtr threadHandle)
	{
		WaitForSingleObject_1(threadHandle, uint.MaxValue);
	}

	public static void FreeMemory(IntPtr processHandle, int address)
	{
		VirtualFreeEx(processHandle, (IntPtr)address, 0, FreeType.Release);
	}

	public static IntPtr OpenProcess(int pId)
	{
		return OpenProcess_1(2035711u, 0, (uint)pId);
	}

	public static void CloseProcess(IntPtr handle)
	{
		CloseHandle(handle);
	}

	public static void MemWriteBytes(IntPtr processHandle, int address, byte[] value)
	{
		uint uint_ = 0u;
		WriteProcessMemory(processHandle, (IntPtr)address, value, (uint)value.Length, ref uint_);
	}

	public static void MemWriteBytes64(IntPtr processHandle, long address, byte[] value)
	{
		uint uint_ = 0u;
		WriteProcessMemory(processHandle, (IntPtr)address, value, (uint)value.Length, ref uint_);
	}

	public static void MemWriteStruct(IntPtr processHandle, int address, object value)
	{
		byte[] array = smethod_1(value);
		uint uint_ = 0u;
		WriteProcessMemory(processHandle, (IntPtr)address, array, (uint)array.Length, ref uint_);
	}

	public static void MemWriteInt(IntPtr processHandle, int address, int value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		uint uint_ = 0u;
		WriteProcessMemory(processHandle, (IntPtr)address, bytes, 4u, ref uint_);
	}

	public static void MemWriteFloat(IntPtr processHandle, int address, float value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		uint uint_ = 0u;
		WriteProcessMemory(processHandle, (IntPtr)address, bytes, 4u, ref uint_);
	}

	public static void MemWriteShort(IntPtr processHandle, int address, short value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		uint uint_ = 0u;
		WriteProcessMemory(processHandle, (IntPtr)address, bytes, 2u, ref uint_);
	}

	public static void MemWriteByte(IntPtr processHandle, int address, byte value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		uint uint_ = 0u;
		WriteProcessMemory(processHandle, (IntPtr)address, bytes, 1u, ref uint_);
	}

	public static void MemWriteByte64(IntPtr processHandle, long address, byte value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		uint uint_ = 0u;
		WriteProcessMemory(processHandle, (IntPtr)address, bytes, 1u, ref uint_);
	}

	public static byte[] MemReadBytes(IntPtr processHandle, int address, int size)
	{
		byte[] array = new byte[size];
		uint uint_ = 0u;
		ReadProcessMemory(processHandle, (IntPtr)address, array, (uint)size, ref uint_);
		return array;
	}

	public static int MemReadInt(IntPtr processHandle, int address)
	{
		byte[] array = new byte[4];
		uint uint_ = 0u;
		ReadProcessMemory(processHandle, (IntPtr)address, array, 4u, ref uint_);
		return BitConverter.ToInt32(array, 0);
	}

	public static uint MemReadUInt(IntPtr processHandle, int address)
	{
		byte[] array = new byte[4];
		uint uint_ = 0u;
		ReadProcessMemory(processHandle, (IntPtr)address, array, 4u, ref uint_);
		return BitConverter.ToUInt32(array, 0);
	}

	public static float MemReadFloat(IntPtr processHandle, int address)
	{
		byte[] array = new byte[4];
		uint uint_ = 0u;
		ReadProcessMemory(processHandle, (IntPtr)address, array, 4u, ref uint_);
		return BitConverter.ToSingle(array, 0);
	}

	public static string MemReadUnicode(IntPtr processHandle, int address)
	{
		byte[] byte_ = new byte[4096];
		uint uint_ = 0u;
		ReadProcessMemory(processHandle, (IntPtr)address, byte_, 4096u, ref uint_);
		return smethod_3(byte_, EncodingType.Unicode);
	}

	public static object MemReadStruct(IntPtr processHandle, int address, Type anyType)
	{
		int num = Marshal.SizeOf(anyType);
		byte[] byte_ = new byte[num];
		uint uint_ = 0u;
		ReadProcessMemory(processHandle, (IntPtr)address, byte_, (uint)num, ref uint_);
		return smethod_0(byte_, 0, anyType);
	}

	private static object smethod_0(byte[] byte_0, int int_0, Type type_0)
	{
		int num = Marshal.SizeOf(type_0);
		if (num > byte_0.Length)
		{
			return null;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		Marshal.Copy(byte_0, int_0, intPtr, num);
		object result = Marshal.PtrToStructure(intPtr, type_0);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	private static byte[] smethod_1(object object_0)
	{
		int num = Marshal.SizeOf(object_0);
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		Marshal.StructureToPtr(object_0, intPtr, fDeleteOld: false);
		byte[] array = new byte[num];
		Marshal.Copy(intPtr, array, 0, num);
		Marshal.FreeHGlobal(intPtr);
		return array;
	}

	private static string smethod_2(byte[] byte_0)
	{
		return smethod_3(byte_0, EncodingType.Unicode);
	}

	private static string smethod_3(byte[] byte_0, EncodingType encodingType_0)
	{
		Encoding encoding = null;
		string result = string.Empty;
		switch (encodingType_0)
		{
		case EncodingType.ASCII:
			encoding = new ASCIIEncoding();
			break;
		case EncodingType.Unicode:
			encoding = new UnicodeEncoding();
			break;
		case EncodingType.UTF7:
			encoding = new UTF7Encoding();
			break;
		case EncodingType.UTF8:
			encoding = new UTF8Encoding();
			break;
		}
		for (int i = 0; i < byte_0.Length; i += 2)
		{
			if (byte_0[i] == 0 && byte_0[i + 1] == 0)
			{
				result = encoding.GetString(byte_0, 0, i);
				break;
			}
		}
		return result;
	}

	private static byte[] smethod_4(string string_0, EncodingType encodingType_0)
	{
		Encoding encoding = null;
		switch (encodingType_0)
		{
		case EncodingType.ASCII:
			encoding = new ASCIIEncoding();
			break;
		case EncodingType.Unicode:
			encoding = new UnicodeEncoding();
			break;
		case EncodingType.UTF7:
			encoding = new UTF7Encoding();
			break;
		case EncodingType.UTF8:
			encoding = new UTF8Encoding();
			break;
		}
		return encoding.GetBytes(string_0);
	}
}
