using System;
using System.Globalization;

namespace ACE.AIPolicyEditor;

public class StringFormatToIntConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		object obj;
		if (value == null)
		{
			obj = null;
		}
		else
		{
			obj = value.ToString();
			if (obj != null)
			{
				goto IL_0015;
			}
		}
		obj = string.Empty;
		goto IL_0015;
		IL_0015:
		return obj;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is string text)
		{
			int result;
			if (!text.Contains(Class16.smethod_0(1648928028)) && !text.Contains(Class16.smethod_0(1648928036)))
			{
				return int.TryParse(text, out result) ? result : 0;
			}
			float result2;
			return float.TryParse(text, out result2) ? result2 : 0f;
		}
		return value;
	}
}
