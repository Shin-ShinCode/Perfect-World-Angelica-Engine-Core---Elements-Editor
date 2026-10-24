using System;

namespace ACE.Classes;

public class BitReader
{
	public int Position;

	private byte[] byte_0;

	public int Length => byte_0.Length * 8;

	public BitReader(byte[] source)
	{
		byte_0 = source;
	}

	public int Read()
	{
		if (Position >= Length)
		{
			return -1;
		}
		int num = Position / 8;
		int num2 = Position % 8;
		Position++;
		return ((byte_0[num] & (1 << num2)) != 0) ? 1 : 0;
	}

	public bool ReadBool()
	{
		return Read() == 1;
	}

	public int ReadInt32(int bitCount)
	{
		int num = 0;
		for (int i = 0; i < bitCount; i++)
		{
			int num2 = Read();
			if (num2 >= 0)
			{
				if (num2 == 1)
				{
					num |= 1 << i;
				}
				continue;
			}
			throw new Exception(Class16.smethod_0(1648907645));
		}
		return num;
	}

	public uint ReadUInt32(int bitCount)
	{
		uint num = 0u;
		for (int i = 0; i < bitCount; i++)
		{
			int num2 = Read();
			if (num2 >= 0)
			{
				num = (num << 1) | (uint)num2;
				continue;
			}
			throw new Exception(Class16.smethod_0(1648907645));
		}
		return num;
	}

	public bool Seek(int shift)
	{
		Position += shift;
		if (Position < 0)
		{
			Position = 0;
			return false;
		}
		if (Position >= Length)
		{
			Position = Length - 1;
			return false;
		}
		return true;
	}
}
