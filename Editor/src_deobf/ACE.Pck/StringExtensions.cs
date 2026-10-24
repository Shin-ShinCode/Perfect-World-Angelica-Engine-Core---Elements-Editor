using System;

namespace ACE.Pck;

public static class StringExtensions
{
	public static byte[] ToGBK(this string value)
	{
		return GBKEncoding.GetBytes(value);
	}

	public static string FromGBK(this byte[] value)
	{
		return GBKEncoding.GetString(value);
	}

	public static string RemoveFirst(this string value, string pattern)
	{
		int num = value.IndexOf(pattern);
		if (num > -1)
		{
			value = value.Remove(num, pattern.Length);
		}
		return value;
	}

	public static string RemoveFirstSeparator(this string value)
	{
		if (value.Length > 2 && value.StartsWith(Class16.smethod_0(1648927580)))
		{
			value = value.Remove(0, 1);
		}
		return value;
	}

	public static int ToInt32(this string value, int defaultValue = 0)
	{
		if (!int.TryParse(value, out var result))
		{
			return defaultValue;
		}
		return result;
	}

	public static bool ContainsIgnoreCase(this string value, string substring)
	{
		return value.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
	}

	public static bool Contains(this string value, string substring, StringComparison comparison)
	{
		if (value == null)
		{
			return false;
		}
		return value.IndexOf(substring, comparison) >= 0;
	}
}
