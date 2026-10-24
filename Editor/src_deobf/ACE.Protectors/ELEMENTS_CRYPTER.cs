using System;
using System.Runtime.CompilerServices;
using ACE.RSGlobal;

namespace ACE.Protectors;

public class ELEMENTS_CRYPTER
{
	public byte[] key;

	private int int_0;

	private int int_1;

	public ELEMENTS_CRYPTER(byte[] key)
	{
		this.key = key;
		Reset();
	}

	public ELEMENTS_CRYPTER()
	{
		GenerateKey();
	}

	public void GenerateKey()
	{
		int num = (int_0 = RND.GenerateRnd(40, 80));
		key = new byte[num];
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				byte b = (byte)RND.GenerateRnd(0, 50);
				key[num2] = b;
				num2++;
			}
			while (num2 < int_0);
		}
	}

	public void Reset()
	{
		int_0 = key.Length;
		int_1 = 0;
	}

	public float EncryptValue(float value)
	{
		int num = int_1;
		System.Runtime.CompilerServices.Unsafe.As<float, sbyte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<float>(ref value, new IntPtr(3))) = (sbyte)(key[num] ^ System.Runtime.CompilerServices.Unsafe.As<float, byte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<float>(ref value, new IntPtr(3))));
		if ((int_1 = num + 1) == int_0)
		{
			int_1 = 0;
		}
		return value;
	}

	public float DecodeValue(float value)
	{
		int num = int_1;
		System.Runtime.CompilerServices.Unsafe.As<float, sbyte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<float>(ref value, new IntPtr(3))) = (sbyte)(key[num] ^ System.Runtime.CompilerServices.Unsafe.As<float, byte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<float>(ref value, new IntPtr(3))));
		if ((int_1 = num + 1) == int_0)
		{
			int_1 = 0;
		}
		return value;
	}
}
