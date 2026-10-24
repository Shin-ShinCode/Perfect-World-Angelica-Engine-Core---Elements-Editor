using System.Globalization;
using System.Runtime.InteropServices;

namespace ACE.RSGlobal;

public class NumberConverter
{
	public static string NumberDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

	public static char correct_sep = NumberDecimalSeparator[0];

	public static string WrongSeparator = ((!(NumberDecimalSeparator == Class16.smethod_0(1648928036))) ? Class16.smethod_0(1648928036) : Class16.smethod_0(1648928028));

	public static char wrong_sep = WrongSeparator[0];

	public static string GetUniversalFloated(string number, [MarshalAs(UnmanagedType.U1)] bool IsPercent)
	{
		number = number.Replace(Class16.smethod_0(1648942211), string.Empty);
		if (number.Contains(Class16.smethod_0(1648928028)) && number.Contains(Class16.smethod_0(1648928036)))
		{
			number = number.Replace(WrongSeparator, string.Empty);
		}
		else if (number.Contains(WrongSeparator))
		{
			number = number.Replace(WrongSeparator, NumberDecimalSeparator);
		}
		if (IsPercent)
		{
			string text = number;
			if (text[text.Length - 1] == '%')
			{
				number = number.Substring(0, number.Length - 1);
			}
			decimal result = default(decimal);
			if (decimal.TryParse(number, out result))
			{
				decimal d = 100m;
				number = decimal.Divide(result, d).ToString();
			}
		}
		return number;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TryParseUniversalFloat(string text, ref float float_0)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		text = GetUniversalFloated(text, IsPercent: false);
		return float.TryParse(text, out float_0);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TryParsePercent(string text, ref float float_0)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		text = GetUniversalFloated(text, IsPercent: true);
		return float.TryParse(text, out float_0);
	}
}
