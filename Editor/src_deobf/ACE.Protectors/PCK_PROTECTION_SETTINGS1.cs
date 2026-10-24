using System;
using System.Runtime.InteropServices;
using System.Text;
using ACE.Pck;

namespace ACE.Protectors;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 16)]
public struct PCK_PROTECTION_SETTINGS1(int KEY_1, int KEY_2)
{
	public sbyte ProtectionLevel = 0;

	public int KEY_1 = KEY_1;

	public int KEY_2 = KEY_2;

	public int FTO_KEY = KEY_1;

	public ushort MetaDataShift = 280;

	public byte ExtraFilesMask = 0;

	public static PCK_PROTECTION_SETTINGS1 Deserialize(string Key)
	{
		return Convert.FromBase64String(Key).ReadStruct<PCK_PROTECTION_SETTINGS1>();
	}

	public static PCK_PROTECTION_SETTINGS1 Deserialize(string EncryptedKey, string PN)
	{
		byte[] array = Convert.FromBase64String(EncryptedKey);
		byte[] bytes = Encoding.GetEncoding(1251).GetBytes(PN);
		for (int i = 0; i < 16; i++)
		{
			array[i] ^= bytes[i % bytes.Length];
		}
		return array.ReadStruct<PCK_PROTECTION_SETTINGS1>();
	}

	public static string DecryptKey(string EncryptedKey, string PN)
	{
		byte[] array = Convert.FromBase64String(EncryptedKey);
		byte[] bytes = Encoding.GetEncoding(1251).GetBytes(PN);
		for (int i = 0; i < 16; i++)
		{
			array[i] ^= bytes[i % bytes.Length];
		}
		return Convert.ToBase64String(array);
	}
}
