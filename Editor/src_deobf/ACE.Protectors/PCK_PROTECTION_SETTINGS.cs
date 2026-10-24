using System;
using System.Runtime.InteropServices;
using System.Text;
using ACE.RSGlobal;

namespace ACE.Protectors;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 16)]
public struct PCK_PROTECTION_SETTINGS
{
	public sbyte ProtectionLevel;

	public int KEY_1;

	public int KEY_2;

	public int FTO_KEY;

	public ushort MetaDataShift;

	public byte ExtraFilesMask;

	public PCK_PROTECTION_SETTINGS(int KEY_1, int KEY_2)
	{
		ProtectionLevel = 0;
		ExtraFilesMask = 0;
		this.KEY_1 = KEY_1;
		this.KEY_2 = KEY_2;
		FTO_KEY = KEY_1;
		MetaDataShift = 280;
	}

	public PCK_PROTECTION_SETTINGS(ushort MetaDataShift)
	{
		ProtectionLevel = 0;
		KEY_1 = 0;
		KEY_2 = 0;
		FTO_KEY = 0;
		ExtraFilesMask = 0;
		this.MetaDataShift = MetaDataShift;
	}

	public static PCK_PROTECTION_SETTINGS Deserialize(string Key)
	{
		return ACE.RSGlobal.RSGlobal.ReadStruct<PCK_PROTECTION_SETTINGS>(Convert.FromBase64String(Key));
	}

	public static PCK_PROTECTION_SETTINGS Deserialize(string EncryptedKey, string PN)
	{
		byte[] array = Convert.FromBase64String(EncryptedKey);
		byte[] bytes = Encoding.GetEncoding(1251).GetBytes(PN);
		int num = 0;
		do
		{
			array[num] = (byte)(bytes[num % (nint)bytes.LongLength] ^ array[num]);
			num++;
		}
		while (num < 16);
		return ACE.RSGlobal.RSGlobal.ReadStruct<PCK_PROTECTION_SETTINGS>(array);
	}

	public static string DecryptKey(string EncryptedKey, string PN)
	{
		byte[] array = Convert.FromBase64String(EncryptedKey);
		byte[] bytes = Encoding.GetEncoding(1251).GetBytes(PN);
		int num = 0;
		do
		{
			array[num] = (byte)(bytes[num % (nint)bytes.LongLength] ^ array[num]);
			num++;
		}
		while (num < 16);
		return Convert.ToBase64String(array);
	}
}
