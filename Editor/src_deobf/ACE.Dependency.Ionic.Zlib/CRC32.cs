using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ACE.Dependency.Ionic.Zlib;

[Guid("ebc25cf6-9120-4283-b972-0e5520d0000C")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public class CRC32
{
	private uint uint_0;

	private long long_0;

	private bool bool_0;

	private uint[] uint_1;

	private uint uint_2 = uint.MaxValue;

	public long TotalBytesRead => long_0;

	public int Crc32Result => (int)(~uint_2);

	public CRC32()
		: this(reverseBits: false)
	{
	}

	public CRC32(bool reverseBits)
		: this(-306674912, reverseBits)
	{
	}

	public CRC32(int polynomial, bool reverseBits)
	{
		bool_0 = reverseBits;
		uint_0 = (uint)polynomial;
		method_0();
	}

	public int GetCrc32(Stream input)
	{
		return GetCrc32AndCopy(input, null);
	}

	public int GetCrc32AndCopy(Stream input, Stream output)
	{
		if (input == null)
		{
			throw new Exception(Class16.smethod_0(1648892457));
		}
		byte[] array = new byte[8192];
		int count = 8192;
		long_0 = 0L;
		int num = input.Read(array, 0, 8192);
		output?.Write(array, 0, num);
		long_0 += num;
		while (num > 0)
		{
			SlurpBlock(array, 0, num);
			num = input.Read(array, 0, count);
			output?.Write(array, 0, num);
			long_0 += num;
		}
		return (int)(~uint_2);
	}

	public int ComputeCrc32(int int_0, byte byte_0)
	{
		return _InternalComputeCrc32((uint)int_0, byte_0);
	}

	internal int _InternalComputeCrc32(uint uint_3, byte byte_0)
	{
		return (int)(uint_1[(uint_3 ^ byte_0) & 0xFF] ^ (uint_3 >> 8));
	}

	public void SlurpBlock(byte[] block, int offset, int count)
	{
		if (block == null)
		{
			throw new Exception(Class16.smethod_0(1648892498));
		}
		for (int i = 0; i < count; i++)
		{
			int num = offset + i;
			byte b = block[num];
			if (bool_0)
			{
				uint num2 = (uint_2 >> 24) ^ b;
				uint_2 = (uint_2 << 8) ^ uint_1[num2];
			}
			else
			{
				uint num3 = (uint_2 & 0xFF) ^ b;
				uint_2 = (uint_2 >> 8) ^ uint_1[num3];
			}
		}
		long_0 += count;
	}

	public void UpdateCRC(byte byte_0)
	{
		if (bool_0)
		{
			uint num = (uint_2 >> 24) ^ byte_0;
			uint_2 = (uint_2 << 8) ^ uint_1[num];
		}
		else
		{
			uint num2 = (uint_2 & 0xFF) ^ byte_0;
			uint_2 = (uint_2 >> 8) ^ uint_1[num2];
		}
	}

	public void UpdateCRC(byte byte_0, int int_0)
	{
		while (int_0-- > 0)
		{
			if (bool_0)
			{
				uint num = (uint_2 >> 24) ^ byte_0;
				uint_2 = (uint_2 << 8) ^ uint_1[num];
			}
			else
			{
				uint num2 = (uint_2 & 0xFF) ^ byte_0;
				uint_2 = (uint_2 >> 8) ^ uint_1[num2];
			}
		}
	}

	private static uint smethod_0(uint uint_3)
	{
		uint num = uint_3;
		num = ((num & 0x55555555) << 1) | ((num >> 1) & 0x55555555);
		num = ((num & 0x33333333) << 2) | ((num >> 2) & 0x33333333);
		num = ((num & 0xF0F0F0F) << 4) | ((num >> 4) & 0xF0F0F0F);
		return (num << 24) | ((num & 0xFF00) << 8) | ((num >> 8) & 0xFF00) | (num >> 24);
	}

	private static byte smethod_1(byte byte_0)
	{
		uint num = (uint)(byte_0 * 131586);
		uint num2 = num & 0x1044010;
		uint num3 = (num << 2) & 0x2088020;
		return (byte)(16781313 * (num2 + num3) >> 24);
	}

	private void method_0()
	{
		uint_1 = new uint[256];
		byte b = 0;
		do
		{
			uint num = b;
			for (byte b2 = 8; b2 > 0; b2--)
			{
				num = (((num & 1) != 1) ? (num >> 1) : ((num >> 1) ^ uint_0));
			}
			if (bool_0)
			{
				uint_1[smethod_1(b)] = smethod_0(num);
			}
			else
			{
				uint_1[b] = num;
			}
			b++;
		}
		while (b != 0);
	}

	private uint method_1(uint[] uint_3, uint uint_4)
	{
		uint num = 0u;
		int num2 = 0;
		while (uint_4 != 0)
		{
			if ((uint_4 & 1) == 1)
			{
				num ^= uint_3[num2];
			}
			uint_4 >>= 1;
			num2++;
		}
		return num;
	}

	private void method_2(uint[] uint_3, uint[] uint_4)
	{
		for (int i = 0; i < 32; i++)
		{
			uint_3[i] = method_1(uint_4, uint_4[i]);
		}
	}

	public void Combine(int crc, int length)
	{
		uint[] array = new uint[32];
		uint[] array2 = new uint[32];
		if (length == 0)
		{
			return;
		}
		uint num = ~uint_2;
		array2[0] = uint_0;
		uint num2 = 1u;
		for (int i = 1; i < 32; i++)
		{
			array2[i] = num2;
			num2 <<= 1;
		}
		method_2(array, array2);
		method_2(array2, array);
		uint num3 = (uint)length;
		do
		{
			method_2(array, array2);
			if ((num3 & 1) == 1)
			{
				num = method_1(array, num);
			}
			num3 >>= 1;
			if (num3 == 0)
			{
				break;
			}
			method_2(array2, array);
			if ((num3 & 1) == 1)
			{
				num = method_1(array2, num);
			}
			num3 >>= 1;
		}
		while (num3 != 0);
		num ^= (uint)crc;
		uint_2 = ~num;
	}

	public void Reset()
	{
		uint_2 = uint.MaxValue;
	}
}
