using System;
using System.Runtime.InteropServices;
using System.Text;
using ACE.Classes;

namespace ACE.RSGlobal;

public class RSCrypt
{
	public bool IS_LICENSE_KEY;

	public bool IS_ACT_KEY;

	public static RSCrypt STATIC_CRYPTER = new RSCrypt(bGenerateKey: false);

	public string Key;

	public byte[] key;

	private static int int_0 = 36;

	private static int int_1 = 3;

	private int int_2;

	private int int_3;

	public RSCrypt(byte[] key)
	{
		SetKey(key);
	}

	public RSCrypt([MarshalAs(UnmanagedType.U1)] bool bGenerateKey)
	{
		if (bGenerateKey)
		{
			GenerateNewKey(40, 60);
		}
	}

	public static string GetProtectedString(string str_base64)
	{
		byte[] input = Convert.FromBase64String(str_base64);
		return STATIC2().DecryptString(input);
	}

	public static string ProtectString(string str)
	{
		RSCrypt rSCrypt = STATIC2();
		byte[] inArray = rSCrypt.EncryptBytes(Encoding.UTF8.GetBytes(str), bBase64: true);
		GC.KeepAlive(rSCrypt);
		return Convert.ToBase64String(inArray);
	}

	public static byte[] GetS3()
	{
		byte[] array = new byte[31];
		RSGlobal.Static3();
		int num = 0;
		do
		{
			array[num] = RSGlobal.STATIC_LICENSE_KEY[num];
			RSGlobal.STATIC_LICENSE_KEY[num] = 0;
			num++;
		}
		while (num < 31);
		RSGlobal.STATIC_LICENSE_KEY = null;
		return array;
	}

	public static RSCrypt STATIC1()
	{
		byte[] lICENSE_FILE_KEY = RSGlobal.LICENSE_FILE_KEY;
		char[] array = new char[lICENSE_FILE_KEY.Length];
		for (int i = 0; i < lICENSE_FILE_KEY.Length; i++)
		{
			array[i] = (char)lICENSE_FILE_KEY[i];
		}
		STATIC_CRYPTER.SetKey(new string(array));
		return STATIC_CRYPTER;
	}

	public static RSCrypt STATIC2()
	{
		if (RSGlobal.PROTECTED_STRINGS_KEY == null)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649161749));
		}
		byte[] pROTECTED_STRINGS_KEY = RSGlobal.PROTECTED_STRINGS_KEY;
		char[] array = new char[pROTECTED_STRINGS_KEY.Length];
		for (int i = 0; i < pROTECTED_STRINGS_KEY.Length; i++)
		{
			array[i] = (char)pROTECTED_STRINGS_KEY[i];
		}
		STATIC_CRYPTER.SetKey(new string(array));
		return STATIC_CRYPTER;
	}

	public static string GetActKey(string Username)
	{
		STATIC_CRYPTER.IS_ACT_KEY = true;
		if (RSGlobal.ACTKEY_KEY == null || RSGlobal.ACTKEY_KEY.Length == 0)
		{
			RSGlobal.ACTKEY_KEY = Encoding.ASCII.GetBytes(Class16.smethod_0(1649161795));
		}
		byte[] aCTKEY_KEY = RSGlobal.ACTKEY_KEY;
		char[] array = new char[aCTKEY_KEY.Length];
		for (int i = 0; i < aCTKEY_KEY.Length; i++)
		{
			array[i] = (char)aCTKEY_KEY[i];
		}
		STATIC_CRYPTER.SetKey(new string(array));
		string data = Username ?? string.Empty;
		string result = RSMD5.Encode(STATIC_CRYPTER.EncryptString(RSMD5.Encode(data)));
		STATIC_CRYPTER.IS_ACT_KEY = false;
		return result;
	}

	public void SetKey(byte[] key)
	{
		this.key = key;
		Key = Encoding.UTF8.GetString(key);
		int num = key[0];
		int_2 = num % int_1;
		if (IS_ACT_KEY)
		{
			int_3 = 0;
			return;
		}
		int num2 = (int)((nint)key.LongLength * 3);
		int_3 = num2 % int_0;
	}

	public void SetKey(string Key)
	{
		if (this.Key != Key)
		{
			this.Key = Key;
			if (string.IsNullOrEmpty(Key))
			{
				key = null;
			}
			else
			{
				SetKey(Encoding.UTF8.GetBytes(Key));
			}
		}
		GC.KeepAlive(this);
	}

	public string GenerateNewKey(int min_len, int max_len)
	{
		byte[] array = (key = new byte[RND.GenerateRnd(min_len, max_len)]);
		int num = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				RND.GenerateRnd(0, 255);
				num++;
			}
			while (num < (nint)key.LongLength);
		}
		byte[] bytes = key;
		Key = Encoding.UTF8.GetString(bytes);
		int num2 = key[0];
		int_2 = num2 % int_1;
		if ((int_3 = (int)((nint)key.LongLength * 3 % int_0)) > 0)
		{
			return Key;
		}
		return GenerateNewKey(40, 60);
	}

	public string GenerateNewKey()
	{
		return GenerateNewKey(40, 60);
	}

	public byte[] EncryptString(string Input, [MarshalAs(UnmanagedType.U1)] bool bBase64)
	{
		byte[] result = EncryptBytes(Encoding.UTF8.GetBytes(Input), bBase64);
		GC.KeepAlive(this);
		return result;
	}

	public string EncryptString(string Input)
	{
		byte[] bytes = EncryptBytes(Encoding.UTF8.GetBytes(Input), bBase64: true);
		string result = Encoding.UTF8.GetString(bytes);
		GC.KeepAlive(this);
		return result;
	}

	public byte[] EncryptBytes(byte[] input, [MarshalAs(UnmanagedType.U1)] bool bBase64)
	{
		if (bBase64)
		{
			string s = Convert.ToBase64String(input);
			input = Encoding.UTF8.GetBytes(s);
		}
		if (key == null)
		{
			GenerateNewKey(40, 60);
		}
		int num = input.Length;
		byte[] array = new byte[int_3 + num];
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				byte byte_ = input[num2];
				byte[] array2 = key;
				int num3 = array2.Length;
				byte byte_2 = array2[num3 - num2 % (num3 - 1) - 2];
				array[num2] = RSGlobal.CryptChar(byte_, byte_2, int_2);
				num2++;
			}
			while (num2 < (nint)input.LongLength);
		}
		int num4 = input.Length;
		if (num4 < (nint)array.LongLength)
		{
			do
			{
				byte b = (byte)RND.GenerateRnd(54, 127);
				array[num4] = b;
				num4++;
			}
			while (num4 < (nint)array.LongLength);
		}
		GC.KeepAlive(this);
		return array;
	}

	public string DecryptString(byte[] input)
	{
		byte[] bytes = DecryptBytes(input, bBase64: true);
		string result = Encoding.UTF8.GetString(bytes);
		GC.KeepAlive(this);
		return result;
	}

	public string DecryptString(string Input)
	{
		byte[] bytes = DecryptBytes(Encoding.UTF8.GetBytes(Input), bBase64: true);
		string result = Encoding.UTF8.GetString(bytes);
		GC.KeepAlive(this);
		return result;
	}

	public byte[] DecryptBytes(byte[] input, [MarshalAs(UnmanagedType.U1)] bool bBase64)
	{
		byte[] array = key;
		if (array != null && (nint)array.LongLength >= 6)
		{
			int num = (int)((nint)input.LongLength - int_3);
			if (num < 1)
			{
				return input;
			}
			byte[] array2 = new byte[num];
			int num2 = 0;
			if (0 < (nint)array2.LongLength)
			{
				do
				{
					byte byte_ = input[num2];
					byte[] array3 = key;
					int num3 = array3.Length;
					byte byte_2 = array3[num3 - num2 % (num3 - 1) - 2];
					array2[num2] = RSGlobal.CryptChar(byte_, byte_2, int_2);
					num2++;
				}
				while (num2 < (nint)array2.LongLength);
			}
			if (IS_LICENSE_KEY)
			{
				int num4 = 0;
				if (0 < (nint)array2.LongLength)
				{
					do
					{
						byte b = array2[num4];
						byte b2 = ((num4 < 6) ? key[num4] : array2[num4 - 6]);
						array2[num4] = (byte)(b2 ^ b);
						num4++;
					}
					while (num4 < (nint)array2.LongLength);
				}
			}
			if (bBase64)
			{
				try
				{
					string text = Encoding.UTF8.GetString(array2);
					int num5 = text.Length % 4;
					if (num5 > 0)
					{
						text = text.PadRight(text.Length + (4 - num5), '=');
					}
					bool flag = true;
					foreach (char c in text)
					{
						if ((c < 'A' || c > 'Z') && (c < 'a' || c > 'z') && (c < '0' || c > '9') && c != '+' && c != '/' && c != '=')
						{
							flag = false;
							break;
						}
					}
					if (!flag)
					{
						return input;
					}
					array2 = Convert.FromBase64String(text);
				}
				catch (FormatException)
				{
					return input;
				}
				catch (Exception ex2)
				{
					SentryHelper.CaptureException(ex2, Class16.smethod_0(1649161823));
					return input;
				}
			}
			GC.KeepAlive(this);
			return array2;
		}
		return input;
	}
}
