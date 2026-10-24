using System;
using System.Text;

namespace ACE.AIPolicyEditor;

public static class StaticConverter
{
	public static byte[] FromGBK(this string value, int len)
	{
		value += Class16.smethod_0(1648938185);
		byte[] array = new byte[len];
		Encoding encoding = Encoding.GetEncoding(936);
		if (encoding.GetByteCount(value) > len)
		{
			Array.Copy(encoding.GetBytes(value), 0, array, 0, len);
		}
		else
		{
			Array.Copy(encoding.GetBytes(value), array, encoding.GetByteCount(value));
		}
		return array;
	}

	public static byte[] FromUnicode(this string value, int len)
	{
		value += Class16.smethod_0(1648938185);
		byte[] array = new byte[len];
		Encoding unicode = Encoding.Unicode;
		if (unicode.GetByteCount(value) > len)
		{
			Array.Copy(unicode.GetBytes(value), 0, array, 0, len);
		}
		else
		{
			Array.Copy(unicode.GetBytes(value), array, unicode.GetByteCount(value));
		}
		return array;
	}

	public static string ToGBK(this byte[] value)
	{
		return Encoding.GetEncoding(936).GetString(value).Split(default(char))[0];
	}

	public static int ToInt32(this string value)
	{
		return int.Parse(value);
	}

	public static string ToUnicode(this byte[] value)
	{
		return Encoding.Unicode.GetString(value).Split(default(char))[0];
	}
}
