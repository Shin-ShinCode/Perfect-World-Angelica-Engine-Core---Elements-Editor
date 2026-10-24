using System.IO;

namespace ACE.Dependency.zlibnet;

internal static class StringHelper
{
	public static string SetEndDirSep(this string string_0)
	{
		if (string_0.EndsWithDirSep())
		{
			return string_0;
		}
		return string_0 + System.IO.Path.DirectorySeparatorChar;
	}

	public static string TrimStartDirSep(this string string_0)
	{
		return string_0.TrimStart(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
	}

	public static string TrimEndDirSep(this string string_0)
	{
		return string_0.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
	}

	public static bool EndsWithDirSep(this string str)
	{
		if (str.Length == 0)
		{
			return false;
		}
		char c = str[str.Length - 1];
		if (c != System.IO.Path.DirectorySeparatorChar)
		{
			return c == System.IO.Path.AltDirectorySeparatorChar;
		}
		return true;
	}

	public static bool StartsWithDirSep(this string str)
	{
		if (str.Length == 0)
		{
			return false;
		}
		char c = str[0];
		if (c != System.IO.Path.DirectorySeparatorChar)
		{
			return c == System.IO.Path.AltDirectorySeparatorChar;
		}
		return true;
	}

	public static bool WildcardMatch(this string str, string wildcompare, bool ignoreCase)
	{
		if (ignoreCase)
		{
			return str.ToLower().WildcardMatch(wildcompare.ToLower());
		}
		return str.WildcardMatch(wildcompare);
	}

	public static bool IsAscii(this string str)
	{
		int num = 0;
		while (true)
		{
			if (num < str.Length)
			{
				char c = str[num];
				if (c > 'ÿ')
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static bool WildcardMatch(this string str, string wildcompare)
	{
		if (string.IsNullOrEmpty(wildcompare))
		{
			return str.Length == 0;
		}
		wildcompare = wildcompare.Replace(Class16.smethod_0(1648889151), Class16.smethod_0(1648941528));
		int i = 0;
		int j = 0;
		int length = str.Length;
		int length2 = wildcompare.Length;
		for (; i < length; i++)
		{
			if (j >= length2)
			{
				break;
			}
			if (wildcompare[j] == '*')
			{
				break;
			}
			char c = wildcompare[j];
			if (c == '?' || c == str[i])
			{
				j++;
				continue;
			}
			return false;
		}
		int num = 0;
		int num2 = 0;
		while (i < length && j < length2)
		{
			char c2 = wildcompare[j];
			switch (c2)
			{
			case '*':
				j++;
				if (j != length2)
				{
					num2 = j;
					num = i + 1;
					continue;
				}
				return true;
			default:
				if (c2 == str[i])
				{
					break;
				}
				j = num2;
				i = num;
				num++;
				continue;
			case '?':
				break;
			}
			j++;
			i++;
		}
		for (; j < length2 && wildcompare[j] == '*'; j++)
		{
		}
		if (j == length2)
		{
			return i == length;
		}
		return false;
	}
}
