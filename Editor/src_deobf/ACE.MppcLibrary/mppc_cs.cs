using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ACE.MppcLibrary;

public class mppc_cs
{
	public static uint compressBound(uint sourcelen)
	{
		return sourcelen * 9 / 8 + 1 + 2 + 3;
	}

	public static int compress(byte[] dest, ref int destLen, byte[] source, int sourceLen)
	{
		int num = smethod_3(source, dest, sourceLen, destLen, 0u, 0u);
		if (num > 0 && num <= destLen)
		{
			destLen = num;
			return 0;
		}
		return -1;
	}

	public unsafe static int uncompress(byte* dest, int* destLen, byte* source, int sourceLen)
	{
		int num = smethod_7(source, dest, sourceLen, *destLen);
		if (num > 0 && num <= *destLen)
		{
			*destLen = num;
			return 0;
		}
		return -1;
	}

	public static int compress2(byte[] dest, ref int destLen, byte[] source, int sourceLen)
	{
		int num = destLen;
		destLen = 0;
		uint num2 = 0u;
		uint num3 = 0u;
		while (sourceLen > 0 && num > 2)
		{
			int num4 = ((sourceLen > 8192) ? 8192 : sourceLen);
			int num5 = smethod_3(source, dest, num4, num - 2, num2, num3 + 2);
			if (num5 > 0 && num5 < num4 && num5 <= num - 2)
			{
				BitConverter.GetBytes((ushort)(num5 | 0x8000)).CopyTo(dest, num3);
			}
			else
			{
				if (num4 <= 0 || num4 > num - 2)
				{
					return -1;
				}
				num5 = num4;
				Array.Copy(source, num2, dest, num3 + 2, num5);
				BitConverter.GetBytes((ushort)num5).CopyTo(dest, num3);
			}
			num2 += (uint)num4;
			sourceLen -= num4;
			num3 += (uint)(num5 + 2);
			num -= num5 + 2;
			destLen += num5 + 2;
		}
		if (sourceLen != 0)
		{
			return -1;
		}
		return 0;
	}

	public unsafe static int uncompress2(byte* dest, int* destLen, byte* source, int sourceLen)
	{
		int num = *destLen;
		*destLen = 0;
		while (sourceLen > 2 && num > 0)
		{
			int num2 = *(ushort*)source & 0x7FFF;
			if (num2 > 0 && num2 + 2 <= sourceLen && num2 <= 8192)
			{
				int num3;
				if ((*(ushort*)source & 0x8000) != 0)
				{
					num3 = smethod_7(source + 2, dest, num2, num);
					if (num3 <= 0 || num3 > num || num3 > 8192)
					{
						return -1;
					}
				}
				else
				{
					num3 = num2;
					if (num3 > num)
					{
						return -1;
					}
					Buffer.MemoryCopy(source + 2, dest, num3, num3);
				}
				source += num2 + 2;
				sourceLen -= num2 + 2;
				dest += num3;
				num -= num3;
				*destLen += num3;
				continue;
			}
			return -1;
		}
		if (sourceLen != 0)
		{
			return -1;
		}
		return 0;
	}

	private static void smethod_0(byte[] byte_0, uint uint_0, uint uint_1, ref uint uint_2, ref uint uint_3)
	{
		uint_2 += uint_1;
		BitConverter.GetBytes(smethod_8(uint_0 << (int)(32 - uint_2)) | byte_0[uint_3]).CopyTo(byte_0, uint_3);
		uint_3 += uint_2 >> 3;
		uint_2 &= 7u;
	}

	private static void smethod_1(byte[] byte_0, uint uint_0, ref uint uint_1, ref uint uint_2)
	{
		if (uint_0 < 128)
		{
			smethod_0(byte_0, uint_0, 8u, ref uint_1, ref uint_2);
		}
		else
		{
			smethod_0(byte_0, (uint_0 & 0x7F) | 0x100, 9u, ref uint_1, ref uint_2);
		}
	}

	private static void smethod_2(byte[] byte_0, uint uint_0, ref uint uint_1, ref uint uint_2)
	{
		if (uint_0 < 64)
		{
			smethod_0(byte_0, 0x3C0 | uint_0, 10u, ref uint_1, ref uint_2);
		}
		else if (uint_0 < 320)
		{
			smethod_0(byte_0, 0xE00 | (uint_0 - 64), 12u, ref uint_1, ref uint_2);
		}
		else
		{
			smethod_0(byte_0, 0xC000 | (uint_0 - 320), 16u, ref uint_1, ref uint_2);
		}
	}

	private static int smethod_3(byte[] byte_0, byte[] byte_1, int int_0, int int_1, uint uint_0, uint uint_1)
	{
		Dictionary<ushort, int> dictionary = new Dictionary<ushort, int>();
		uint num = uint_1;
		uint num2 = uint_0;
		uint num3 = (uint)(uint_0 + int_0);
		uint num4 = uint_0;
		byte_1[uint_1] = 0;
		uint uint_2 = 0u;
		while (num3 - num4 > 2)
		{
			ushort key = BitConverter.ToUInt16(byte_0, (int)num4);
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, -1);
			}
			int num5 = dictionary[key];
			dictionary[key] = (int)num4;
			if (num5 < num2)
			{
				smethod_1(byte_1, byte_0[uint_0++], ref uint_2, ref uint_1);
				num4 = uint_0;
				continue;
			}
			if (num5 >= num4)
			{
				smethod_1(byte_1, byte_0[uint_0++], ref uint_2, ref uint_1);
				num4 = uint_0;
				continue;
			}
			if (BitConverter.ToUInt16(byte_0, num5) != BitConverter.ToUInt16(byte_0, (int)num4++))
			{
				smethod_1(byte_1, byte_0[uint_0++], ref uint_2, ref uint_1);
				continue;
			}
			if (byte_0[num5 += 2] != byte_0[++num4])
			{
				smethod_1(byte_1, byte_0[uint_0++], ref uint_2, ref uint_1);
				num4 = uint_0;
				continue;
			}
			num5++;
			for (num4++; num4 < num3 && byte_0[num5] == byte_0[num4]; num4++)
			{
				num5++;
			}
			uint num6 = num4 - uint_0;
			uint_0 = num4;
			smethod_2(byte_1, (uint)(num4 - num5), ref uint_2, ref uint_1);
			if (num6 < 4)
			{
				smethod_0(byte_1, 0u, 1u, ref uint_2, ref uint_1);
			}
			else if (num6 < 8)
			{
				smethod_0(byte_1, 8 | (num6 & 3), 4u, ref uint_2, ref uint_1);
			}
			else if (num6 < 16)
			{
				smethod_0(byte_1, 0x30 | (num6 & 7), 6u, ref uint_2, ref uint_1);
			}
			else if (num6 < 32)
			{
				smethod_0(byte_1, 0xE0 | (num6 & 0xF), 8u, ref uint_2, ref uint_1);
			}
			else if (num6 < 64)
			{
				smethod_0(byte_1, 0x3C0 | (num6 & 0x1F), 10u, ref uint_2, ref uint_1);
			}
			else if (num6 < 128)
			{
				smethod_0(byte_1, 0xF80 | (num6 & 0x3F), 12u, ref uint_2, ref uint_1);
			}
			else if (num6 < 256)
			{
				smethod_0(byte_1, 0x3F00 | (num6 & 0x7F), 14u, ref uint_2, ref uint_1);
			}
			else if (num6 < 512)
			{
				smethod_0(byte_1, 0xFE00 | (num6 & 0xFF), 16u, ref uint_2, ref uint_1);
			}
			else if (num6 < 1024)
			{
				smethod_0(byte_1, 0x3FC00 | (num6 & 0x1FF), 18u, ref uint_2, ref uint_1);
			}
			else if (num6 < 2048)
			{
				smethod_0(byte_1, 0xFF800 | (num6 & 0x3FF), 20u, ref uint_2, ref uint_1);
			}
			else if (num6 < 4096)
			{
				smethod_0(byte_1, 0x3FF000 | (num6 & 0x7FF), 22u, ref uint_2, ref uint_1);
			}
			else if (num6 < 8192)
			{
				smethod_0(byte_1, 0xFFE000 | (num6 & 0xFFF), 24u, ref uint_2, ref uint_1);
			}
		}
		switch (num3 - num4)
		{
		case 2u:
			smethod_1(byte_1, byte_0[uint_0++], ref uint_2, ref uint_1);
			smethod_1(byte_1, byte_0[uint_0++], ref uint_2, ref uint_1);
			break;
		case 1u:
			smethod_1(byte_1, byte_0[uint_0++], ref uint_2, ref uint_1);
			break;
		}
		if (uint_2 != 0)
		{
			smethod_0(byte_1, 0u, 8 - uint_2, ref uint_2, ref uint_1);
		}
		return (int)(uint_1 - num);
	}

	private static void smethod_4(uint uint_0, ref uint uint_1, ref uint uint_2)
	{
		uint_1 += uint_0;
		uint_2 += uint_0;
	}

	private unsafe static uint smethod_5(ref byte* pByte_0, ref uint uint_0)
	{
		pByte_0 += uint_0 >> 3;
		uint_0 &= 7u;
		return smethod_8(*(uint*)pByte_0) << (int)uint_0;
	}

	private unsafe static void smethod_6(byte* pByte_0, byte* pByte_1, uint uint_0)
	{
		if ((nint)(pByte_0 - (nuint)pByte_1) > 3L)
		{
			while (uint_0 > 3)
			{
				*(int*)pByte_0 = *(int*)pByte_1;
				pByte_0 += 4;
				pByte_1 += 4;
				uint_0 -= 4;
			}
		}
		while (uint_0-- != 0)
		{
			*(pByte_0++) = *(pByte_1++);
		}
	}

	private unsafe static int smethod_7(byte* pByte_0, byte* pByte_1, int int_0, int int_1)
	{
		if (int_0 > 9217)
		{
			return -1;
		}
		byte* ptr = (byte*)(void*)Marshal.AllocHGlobal(16384);
		smethod_9(ptr, pByte_0, int_0);
		pByte_0 = ptr;
		byte* ptr2 = pByte_1;
		byte* ptr3 = pByte_1 + int_1;
		uint num = (uint)(int_0 * 8);
		uint uint_ = 0u;
		uint uint_2 = 7u;
		while (true)
		{
			if (num > uint_2)
			{
				uint num2 = smethod_5(ref pByte_0, ref uint_);
				if (num2 < 2147483648u)
				{
					if (pByte_1 < ptr3)
					{
						*(pByte_1++) = (byte)(num2 >> 24);
						smethod_4(8u, ref uint_, ref uint_2);
						continue;
					}
					Marshal.FreeHGlobal((IntPtr)ptr);
					return -1;
				}
				if (num2 < 3221225472u)
				{
					if (pByte_1 < ptr3)
					{
						*(pByte_1++) = (byte)((num2 >> 23) | 0x80);
						smethod_4(9u, ref uint_, ref uint_2);
						continue;
					}
					Marshal.FreeHGlobal((IntPtr)ptr);
					return -1;
				}
				uint num3;
				uint num4;
				if (num2 >= 4026531840u)
				{
					num3 = (num2 >> 22) & 0x3F;
					num2 <<= 10;
					if (num2 < 2147483648u)
					{
						num4 = 3u;
						smethod_4(11u, ref uint_, ref uint_2);
					}
					else if (num2 < 3221225472u)
					{
						num4 = 4 | ((num2 >> 28) & 3);
						smethod_4(14u, ref uint_, ref uint_2);
					}
					else if (num2 < 3758096384u)
					{
						num4 = 8 | ((num2 >> 26) & 7);
						smethod_4(16u, ref uint_, ref uint_2);
					}
					else if (num2 < 4026531840u)
					{
						num4 = 0x10 | ((num2 >> 24) & 0xF);
						smethod_4(18u, ref uint_, ref uint_2);
					}
					else if (num2 < 4160749568u)
					{
						num4 = 0x20 | ((num2 >> 22) & 0x1F);
						smethod_4(20u, ref uint_, ref uint_2);
					}
					else if (num2 < 4227858432u)
					{
						num4 = 0x40 | ((num2 >> 20) & 0x3F);
						smethod_4(22u, ref uint_, ref uint_2);
					}
					else if (num2 < 4261412864u)
					{
						num4 = 0x80 | ((num2 >> 18) & 0x7F);
						smethod_4(24u, ref uint_, ref uint_2);
					}
					else
					{
						smethod_4(10u, ref uint_, ref uint_2);
						num2 = smethod_5(ref pByte_0, ref uint_);
						if (num2 < 4278190080u)
						{
							num4 = 0x100 | ((num2 >> 16) & 0xFF);
							smethod_4(16u, ref uint_, ref uint_2);
						}
						else if (num2 < 4286578688u)
						{
							num4 = 0x200 | ((num2 >> 14) & 0x1FF);
							smethod_4(18u, ref uint_, ref uint_2);
						}
						else if (num2 < 4290772992u)
						{
							num4 = 0x400 | ((num2 >> 12) & 0x3FF);
							smethod_4(20u, ref uint_, ref uint_2);
						}
						else if (num2 < 4292870144u)
						{
							num4 = 0x800 | ((num2 >> 10) & 0x7FF);
							smethod_4(22u, ref uint_, ref uint_2);
						}
						else
						{
							if (num2 >= 4293918720u)
							{
								Marshal.FreeHGlobal((IntPtr)ptr);
								return -1;
							}
							num4 = 0x1000 | ((num2 >> 8) & 0xFFF);
							smethod_4(24u, ref uint_, ref uint_2);
						}
					}
				}
				else if (num2 >= 3758096384u)
				{
					num3 = ((num2 >> 20) & 0xFF) + 64;
					num2 <<= 12;
					if (num2 < 2147483648u)
					{
						num4 = 3u;
						smethod_4(13u, ref uint_, ref uint_2);
					}
					else if (num2 < 3221225472u)
					{
						num4 = 4 | ((num2 >> 28) & 3);
						smethod_4(16u, ref uint_, ref uint_2);
					}
					else if (num2 < 3758096384u)
					{
						num4 = 8 | ((num2 >> 26) & 7);
						smethod_4(18u, ref uint_, ref uint_2);
					}
					else if (num2 < 4026531840u)
					{
						num4 = 0x10 | ((num2 >> 24) & 0xF);
						smethod_4(20u, ref uint_, ref uint_2);
					}
					else if (num2 < 4160749568u)
					{
						num4 = 0x20 | ((num2 >> 22) & 0x1F);
						smethod_4(22u, ref uint_, ref uint_2);
					}
					else if (num2 < 4227858432u)
					{
						num4 = 0x40 | ((num2 >> 20) & 0x3F);
						smethod_4(24u, ref uint_, ref uint_2);
					}
					else
					{
						smethod_4(12u, ref uint_, ref uint_2);
						num2 = smethod_5(ref pByte_0, ref uint_);
						if (num2 < 4261412864u)
						{
							num4 = 0x80 | ((num2 >> 18) & 0x7F);
							smethod_4(14u, ref uint_, ref uint_2);
						}
						else if (num2 < 4278190080u)
						{
							num4 = 0x100 | ((num2 >> 16) & 0xFF);
							smethod_4(16u, ref uint_, ref uint_2);
						}
						else if (num2 < 4286578688u)
						{
							num4 = 0x200 | ((num2 >> 14) & 0x1FF);
							smethod_4(18u, ref uint_, ref uint_2);
						}
						else if (num2 < 4290772992u)
						{
							num4 = 0x400 | ((num2 >> 12) & 0x3FF);
							smethod_4(20u, ref uint_, ref uint_2);
						}
						else if (num2 < 4292870144u)
						{
							num4 = 0x800 | ((num2 >> 10) & 0x7FF);
							smethod_4(22u, ref uint_, ref uint_2);
						}
						else
						{
							if (num2 >= 4293918720u)
							{
								Marshal.FreeHGlobal((IntPtr)ptr);
								return -1;
							}
							num4 = 0x1000 | ((num2 >> 8) & 0xFFF);
							smethod_4(24u, ref uint_, ref uint_2);
						}
					}
				}
				else
				{
					num3 = ((num2 >> 16) & 0x1FFF) + 320;
					num2 <<= 16;
					if (num2 < 2147483648u)
					{
						num4 = 3u;
						smethod_4(17u, ref uint_, ref uint_2);
					}
					else if (num2 < 3221225472u)
					{
						num4 = 4 | ((num2 >> 28) & 3);
						smethod_4(20u, ref uint_, ref uint_2);
					}
					else if (num2 < 3758096384u)
					{
						num4 = 8 | ((num2 >> 26) & 7);
						smethod_4(22u, ref uint_, ref uint_2);
					}
					else if (num2 < 4026531840u)
					{
						num4 = 0x10 | ((num2 >> 24) & 0xF);
						smethod_4(24u, ref uint_, ref uint_2);
					}
					else
					{
						smethod_4(16u, ref uint_, ref uint_2);
						num2 = smethod_5(ref pByte_0, ref uint_);
						if (num2 < 4160749568u)
						{
							num4 = 0x20 | ((num2 >> 22) & 0x1F);
							smethod_4(10u, ref uint_, ref uint_2);
						}
						else if (num2 < 4227858432u)
						{
							num4 = 0x40 | ((num2 >> 20) & 0x3F);
							smethod_4(12u, ref uint_, ref uint_2);
						}
						else if (num2 < 4261412864u)
						{
							num4 = 0x80 | ((num2 >> 18) & 0x7F);
							smethod_4(14u, ref uint_, ref uint_2);
						}
						else if (num2 < 4278190080u)
						{
							num4 = 0x100 | ((num2 >> 16) & 0xFF);
							smethod_4(16u, ref uint_, ref uint_2);
						}
						else if (num2 < 4286578688u)
						{
							num4 = 0x200 | ((num2 >> 14) & 0x1FF);
							smethod_4(18u, ref uint_, ref uint_2);
						}
						else if (num2 < 4290772992u)
						{
							num4 = 0x400 | ((num2 >> 12) & 0x3FF);
							smethod_4(20u, ref uint_, ref uint_2);
						}
						else if (num2 < 4292870144u)
						{
							num4 = 0x800 | ((num2 >> 10) & 0x7FF);
							smethod_4(22u, ref uint_, ref uint_2);
						}
						else
						{
							if (num2 >= 4293918720u)
							{
								Marshal.FreeHGlobal((IntPtr)ptr);
								return -1;
							}
							num4 = 0x1000 | ((num2 >> 8) & 0xFFF);
							smethod_4(24u, ref uint_, ref uint_2);
						}
					}
				}
				if (pByte_1 - num3 < ptr2 || pByte_1 + num4 > ptr3)
				{
					break;
				}
				smethod_6(pByte_1, pByte_1 - num3, num4);
				pByte_1 += num4;
				continue;
			}
			Marshal.FreeHGlobal((IntPtr)ptr);
			return (int)(nint)(pByte_1 - (nuint)ptr2);
		}
		Marshal.FreeHGlobal((IntPtr)ptr);
		return -1;
	}

	private static uint smethod_8(uint uint_0)
	{
		return ((uint_0 & 0xFF) << 24) + (((uint_0 >> 8) & 0xFF) << 16) + (((uint_0 >> 16) & 0xFF) << 8) + ((uint_0 >> 24) & 0xFF);
	}

	private unsafe static void smethod_9(void* pVoid_0, void* pVoid_1, int int_0)
	{
		byte[] array = new byte[4096];
		byte* ptr = (byte*)pVoid_0;
		byte* ptr2 = (byte*)pVoid_1;
		int num = 0;
		while (num < int_0)
		{
			int num2 = int_0 - num;
			if (num2 > 4096)
			{
				num2 = 4096;
			}
			Marshal.Copy(new IntPtr(ptr2), array, 0, num2);
			Marshal.Copy(array, 0, new IntPtr(ptr), num2);
			num += num2;
			ptr += num2;
			ptr2 += num2;
		}
	}
}
