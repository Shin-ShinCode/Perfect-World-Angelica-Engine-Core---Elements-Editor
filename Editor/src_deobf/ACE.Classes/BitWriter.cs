using System;

namespace ACE.Classes;

public class BitWriter
{
	public int Position;

	public int result;

	public BitWriter()
	{
		result = 0;
	}

	public byte[] GetBytes()
	{
		return BitConverter.GetBytes(result);
	}

	public void Write(bool bool_0)
	{
		Write(bool_0 ? 1 : 0, 1);
	}

	public void Write(int value, int bitCount)
	{
		for (int i = 0; i < bitCount; i++)
		{
			if ((value & (1 << i)) != 0)
			{
				result |= 1 << Position;
			}
			Position++;
		}
	}

	public bool Seek(int shift)
	{
		Position += shift;
		if (Position < 0)
		{
			Position = 0;
			return false;
		}
		return true;
	}
}
