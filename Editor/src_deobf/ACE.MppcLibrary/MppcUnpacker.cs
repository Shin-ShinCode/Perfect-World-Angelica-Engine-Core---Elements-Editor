using System;
using System.Collections.Generic;

namespace ACE.MppcLibrary;

public class MppcUnpacker
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private byte byte_0;

	private readonly List<byte> list_0;

	private readonly List<byte> list_1;

	private List<byte> list_2;

	public MppcUnpacker()
	{
		int_2 = 0;
		int_3 = 0;
		list_0 = new List<byte>();
		list_2 = new List<byte>();
		list_1 = new List<byte>(8192);
	}

	public static byte[] Decompress(byte[] compressedBytes)
	{
		return new MppcUnpacker().Unpack(compressedBytes);
	}

	public void Unpack(byte packedByte, List<byte> unpackedChunk)
	{
		list_0.Add(packedByte);
		if (list_1.Count >= 10240)
		{
			list_1.RemoveRange(0, 2048);
		}
		while (true)
		{
			if (int_2 != 0)
			{
				if (int_2 == 1)
				{
					if (int_0 == 1)
					{
						if (!method_2(7))
						{
							break;
						}
						byte item = (byte)method_1(7);
						unpackedChunk.Add(item);
						list_1.Add(item);
						int_2 = 0;
					}
					else if (int_0 == 2)
					{
						if (!method_2(7))
						{
							break;
						}
						byte item2 = (byte)(method_1(7) | 0x80);
						unpackedChunk.Add(item2);
						list_1.Add(item2);
						int_2 = 0;
					}
					else if (int_0 == 3)
					{
						if (!method_2(13))
						{
							break;
						}
						int_3 = (int)(method_1(13) + 320);
						int_2 = 2;
					}
					else if (int_0 == 4)
					{
						if (!method_2(8))
						{
							break;
						}
						int_3 = (int)(method_1(8) + 64);
						int_2 = 2;
					}
					else if (int_0 == 5)
					{
						if (!method_2(6))
						{
							break;
						}
						int_3 = (int)method_1(6);
						int_2 = 2;
					}
				}
				else if (int_2 == 2)
				{
					if (int_3 == 0)
					{
						if (byte_0 != 0)
						{
							byte_0 = 0;
							list_0.RemoveAt(0);
						}
						int_2 = 0;
					}
					else
					{
						int_1 = 0;
						int_2 = 3;
					}
				}
				else if (int_2 == 3)
				{
					if (!method_2(1))
					{
						break;
					}
					if (method_1(1) == 0)
					{
						int_2 = 4;
					}
					else
					{
						int_1++;
					}
				}
				else
				{
					if (int_2 != 4)
					{
						continue;
					}
					int int_;
					if (int_1 == 0)
					{
						int_ = 3;
					}
					else
					{
						int num = int_1 + 1;
						if (!method_2(num))
						{
							break;
						}
						int_ = (int)method_1(num) + (1 << num);
					}
					method_0(int_3, int_, ref unpackedChunk);
					int_2 = 0;
				}
			}
			else
			{
				if (!method_2(4))
				{
					break;
				}
				if (method_1(1) == 0)
				{
					int_0 = 1;
					int_2 = 1;
				}
				else if (method_1(1) == 0)
				{
					int_0 = 2;
					int_2 = 1;
				}
				else if (method_1(1) == 0)
				{
					int_0 = 3;
					int_2 = 1;
				}
				else if (method_1(1) == 0)
				{
					int_0 = 4;
					int_2 = 1;
				}
				else
				{
					int_0 = 5;
					int_2 = 1;
				}
			}
		}
	}

	public byte[] Unpack(byte packetByte)
	{
		list_2.Clear();
		Unpack(packetByte, list_2);
		return list_2.ToArray();
	}

	public byte[] Unpack(byte[] compressedBytes)
	{
		return Unpack(compressedBytes, 0, compressedBytes.Length);
	}

	public byte[] Unpack(byte[] compressedBytes, int offset, int count)
	{
		list_2.Clear();
		for (int i = 0; i < count; i++)
		{
			Unpack(compressedBytes[offset + i], list_2);
		}
		return list_2.ToArray();
	}

	private void method_0(int int_4, int int_5, ref List<byte> list_3)
	{
		for (int i = 0; i < int_5; i++)
		{
			int num = list_1.Count - int_4;
			if (num >= 0)
			{
				byte item = list_1[num];
				list_1.Add(item);
				list_3.Add(item);
				continue;
			}
			break;
		}
	}

	private uint method_1(int int_4)
	{
		if (int_4 > 16)
		{
			return 0u;
		}
		if (!method_2(int_4))
		{
			throw new Exception(Class16.smethod_0(1649115967));
		}
		int num = (int_4 + byte_0 + 7) / 8;
		uint num2 = 0u;
		for (int i = 0; i < num; i++)
		{
			num2 |= (uint)(list_0[i] << 24 - i * 8);
		}
		num2 <<= (int)byte_0;
		num2 >>= 32 - int_4;
		byte_0 += (byte)int_4;
		int num3 = byte_0 / 8;
		if (num3 != 0)
		{
			list_0.RemoveRange(0, num3);
		}
		byte_0 %= 8;
		return num2;
	}

	private bool method_2(int int_4)
	{
		return list_0.Count * 8 - byte_0 >= int_4;
	}
}
