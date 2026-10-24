using System;
using System.Text;

namespace ACE.Pck;

public static class GBKEncoding
{
	private static Encoding encoding_0;

	public static Encoding Instance
	{
		get
		{
			if (encoding_0 == null)
			{
				try
				{
					encoding_0 = Encoding.GetEncoding(936);
				}
				catch
				{
					encoding_0 = Encoding.UTF8;
				}
			}
			return encoding_0;
		}
	}

	public static byte[] GetBytes(string value)
	{
		return Instance.GetBytes(value + Class16.smethod_0(1648938185));
	}

	public static string GetString(byte[] bytes)
	{
		if (bytes != null && bytes.Length != 0)
		{
			string text = Instance.GetString(bytes);
			int num = text.IndexOf('\0');
			if (num < 0)
			{
				return text;
			}
			return text.Substring(0, num);
		}
		return string.Empty;
	}

	public static byte[] GetBytes(string value, int fixedSize)
	{
		byte[] array = new byte[fixedSize];
		byte[] bytes = Instance.GetBytes(value);
		Array.Copy(bytes, array, Math.Min(bytes.Length, fixedSize - 1));
		return array;
	}
}
