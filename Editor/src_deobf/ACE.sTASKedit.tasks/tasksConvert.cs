using System;
using System.Text;

namespace ACE.sTASKedit.tasks;

public class tasksConvert
{
	public static string decrypt(int key, short[] chars)
	{
		short[] array = new short[chars.Length];
		string text = string.Empty;
		for (int i = 0; i < chars.Length; i++)
		{
			array[i] = chars[i];
			if (GlobalData.version >= 52)
			{
				array[i] ^= (short)key;
			}
			text += (char)array[i];
		}
		return text.Split(default(char))[0];
	}

	public static short[] encrypt(int key, string text, int length, bool appendZero)
	{
		short[] array = new short[length + Convert.ToByte(appendZero)];
		if (text == null)
		{
			text = string.Empty;
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (i < text.Length)
			{
				array[i] = (short)Convert.ToChar(text.Substring(i, 1));
			}
			if (GlobalData.version >= 52)
			{
				array[i] ^= (short)key;
			}
		}
		return array;
	}

	public static string ShortsToUnicodeString(short[] chars)
	{
		string text = string.Empty;
		for (int i = 0; i < chars.Length; i++)
		{
			text += (char)chars[i];
		}
		return text.Split(default(char))[0];
	}

	public static short[] UnicodeStringToShorts(string text, int length)
	{
		short[] array = new short[length];
		for (int i = 0; i < array.Length && i < text.Length; i++)
		{
			array[i] = (short)Convert.ToChar(text.Substring(i, 1));
		}
		return array;
	}

	public static string ShortsToGbkString(short[] chars)
	{
		byte[] array = new byte[chars.Length * 2];
		for (int i = 0; i < chars.Length; i++)
		{
			byte[] bytes = BitConverter.GetBytes(chars[i]);
			array[i * 2] = bytes[0];
			array[i * 2 + 1] = bytes[1];
		}
		Encoding encoding = Encoding.GetEncoding(Class16.smethod_0(1648985403));
		return encoding.GetString(array).Split(default(char))[0];
	}

	public static short[] GbkStringToShorts(string text, int length)
	{
		Encoding encoding = Encoding.GetEncoding(Class16.smethod_0(1648985403));
		byte[] array = new byte[length * 2];
		byte[] bytes = encoding.GetBytes(text);
		Array.Copy(bytes, array, bytes.Length);
		short[] array2 = new short[length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = BitConverter.ToInt16(array, i * 2);
		}
		return array2;
	}

	public static string CharsToString(char[] chars)
	{
		string text = string.Empty;
		for (int i = 0; i < chars.Length; i++)
		{
			text += chars[i];
		}
		return text.Split(default(char))[0];
	}

	public static char[] StringToChars(string text, int length)
	{
		char[] array = new char[length];
		for (int i = 0; i < array.Length && i < text.Length; i++)
		{
			array[i] = Convert.ToChar(text.Substring(i, 1));
		}
		return array;
	}
}
