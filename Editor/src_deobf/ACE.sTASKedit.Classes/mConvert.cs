using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using ACE.sTASKedit.Classes.GlobalProgramData;

namespace ACE.sTASKedit.Classes;

internal class mConvert
{
	public static string SecondsToString(int time, int Type = 0)
	{
		if (Type == 1 && (uint)time > 2147483648u)
		{
			int num = Convert.ToInt32(((time & 0x7FFFFFFFL) >> 24) + 100L);
			int num2 = ((time & 0xFF0000) >> 16) - 1;
			int day = (time & 0xFF00) >> 8;
			int hour = (byte)time;
			return new DateTime(num + 1900, num2 + 1, day, hour, 0, 0, 0).ToString(Class16.smethod_0(1649252051));
		}
		uint num3 = (uint)time;
		uint num4 = num3 / 86400;
		num3 -= num4 * 86400;
		uint num5 = num3 / 3600;
		num3 -= num5 * 3600;
		uint num6 = num3 / 60;
		uint num7 = num3 - num6 * 60;
		return num4.ToString(Class16.smethod_0(1648971648)) + Class16.smethod_0(1648941518) + num5.ToString(Class16.smethod_0(1648971648)) + Class16.smethod_0(1648924402) + num6.ToString(Class16.smethod_0(1648971648)) + Class16.smethod_0(1648924402) + num7.ToString(Class16.smethod_0(1648971648));
	}

	public static int StringToSeconds(string time)
	{
		if (string.IsNullOrWhiteSpace(time))
		{
			return 0;
		}
		time = time.Trim();
		if (!uint.TryParse(time, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) && !uint.TryParse(time, out result))
		{
			if (!DateTime.TryParse(time, CultureInfo.CurrentCulture, DateTimeStyles.None, out var result2) && !DateTime.TryParse(time, CultureInfo.InvariantCulture, DateTimeStyles.None, out result2))
			{
				if (!TimeSpan.TryParse(time, CultureInfo.InvariantCulture, out var result3) && !TimeSpan.TryParse(time, CultureInfo.CurrentCulture, out result3))
				{
					string input = time.Replace(Class16.smethod_0(1648942211), string.Empty);
					Match match = Regex.Match(input, Class16.smethod_0(1649252074));
					if (match.Success)
					{
						uint result4 = 0u;
						uint result5 = 0u;
						uint result6 = 0u;
						uint result7 = 0u;
						if ((!match.Groups[Class16.smethod_0(1648906620)].Success || uint.TryParse(match.Groups[Class16.smethod_0(1648906620)].Value, out result4)) && uint.TryParse(match.Groups[Class16.smethod_0(1649252140)].Value, out result5) && uint.TryParse(match.Groups[Class16.smethod_0(1649078588)].Value, out result6) && (!match.Groups[Class16.smethod_0(1649257907)].Success || uint.TryParse(match.Groups[Class16.smethod_0(1649257907)].Value, out result7)))
						{
							ulong val = (ulong)((long)result4 * 86400L + (long)result5 * 3600L + (long)result6 * 60L + result7);
							return (int)Math.Min(val, 2147483647uL);
						}
					}
					return 0;
				}
				double val2 = Math.Max(0.0, result3.TotalSeconds);
				return (int)Math.Min(val2, 2147483647.0);
			}
			return BitConverter.ToInt32(new byte[4]
			{
				Convert.ToByte(result2.Hour),
				Convert.ToByte(result2.Day),
				Convert.ToByte(result2.Month),
				Convert.ToByte(result2.Year - 1872)
			}, 0);
		}
		return (int)Math.Min(result, 2147483647u);
	}

	public static string TimestampToString(uint timestamp)
	{
		return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp).ToString(Class16.smethod_0(1649006896));
	}

	public static string ServerXToClientX(float float_0)
	{
		return (400.0 + Math.Truncate((double)float_0 * 0.1)).ToString();
	}

	public static string ServerYToClientY(float float_0)
	{
		return Math.Truncate((double)float_0 * 0.1).ToString();
	}

	public static string ServerZToClientZ(float float_0)
	{
		return (550.0 + Math.Truncate((double)float_0 * 0.1)).ToString();
	}

	public static string Int32ToString(int value)
	{
		return value.ToString(GProD.ValueFormat, CultureInfo.CreateSpecificCulture(Class16.smethod_0(1648931960)));
	}

	public static string UInt32ToString(int value)
	{
		uint num = (uint)value;
		return num.ToString(GProD.ValueFormat, CultureInfo.CreateSpecificCulture(Class16.smethod_0(1648931960)));
	}

	public static int DigitNumberToInt32(object value)
	{
		string s = Convert.ToString(value).Replace(Class16.smethod_0(1649117873), string.Empty).Replace(Class16.smethod_0(1648942211), string.Empty);
		if (int.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		return 0;
	}

	public static int DigitNumberToUInt32(object value)
	{
		string s = Convert.ToString(value).Replace(Class16.smethod_0(1649117873), string.Empty).Replace(Class16.smethod_0(1648942211), string.Empty);
		if (uint.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
		{
			return (int)result;
		}
		return 0;
	}

	public static string Int32ToSilver(int value)
	{
		string empty = string.Empty;
		if (Settings.Fields.EnableShowDigits)
		{
			if (value < 100)
			{
				return value.ToString();
			}
			string text = value.ToString();
			string text2 = text.Substring(0, text.Length - 2);
			string text3 = text.Substring(text.Length - 2, 2);
			return text2 + Class16.smethod_0(1648942211) + text3;
		}
		return value.ToString();
	}

	public static string UInt32ToSilver(int value)
	{
		string empty = string.Empty;
		uint num;
		if (Settings.Fields.EnableShowDigits)
		{
			if ((uint)value < 100u)
			{
				num = (uint)value;
				return num.ToString();
			}
			num = (uint)value;
			string text = num.ToString();
			string text2 = text.Substring(0, text.Length - 2);
			string text3 = text.Substring(text.Length - 2, 2);
			return text2 + Class16.smethod_0(1648942211) + text3;
		}
		num = (uint)value;
		return num.ToString();
	}

	public static float PercentNumberToSingle(object value, bool EnableShowPercents)
	{
		if (!smethod_0(value, out var float_))
		{
			return 0f;
		}
		if (!EnableShowPercents)
		{
			return float_;
		}
		return (float)((double)float_ * 0.01);
	}

	public static bool TryParseSingle(object value, out float result)
	{
		return smethod_0(value, out result);
	}

	private static bool smethod_0(object object_0, out float float_0)
	{
		float_0 = 0f;
		if (object_0 != null && object_0 != DBNull.Value)
		{
			string text = Convert.ToString(object_0, CultureInfo.CurrentCulture);
			if (string.IsNullOrWhiteSpace(text))
			{
				return true;
			}
			text = text.Replace(CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, string.Empty).Replace(CultureInfo.InvariantCulture.NumberFormat.PercentSymbol, string.Empty).Replace('\u00a0'.ToString(), string.Empty)
				.Trim();
			if (text.Length == 0)
			{
				return true;
			}
			if (!float.TryParse(text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out float_0) && !float.TryParse(text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out float_0))
			{
				return float.TryParse(smethod_1(text), NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out float_0);
			}
			return true;
		}
		return true;
	}

	private static string smethod_1(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return string.Empty;
		}
		string text = string_0.Replace(Class16.smethod_0(1648942211), string.Empty);
		int num = text.LastIndexOf(',');
		int num2 = text.LastIndexOf('.');
		if (num >= 0 && num2 >= 0)
		{
			text = ((num <= num2) ? text.Replace(Class16.smethod_0(1648928028), string.Empty) : text.Replace(Class16.smethod_0(1648928036), string.Empty).Replace(',', '.'));
		}
		else if (num >= 0)
		{
			text = text.Replace(',', '.');
		}
		return text;
	}

	public static string ItemPropsSecondsToString(uint time)
	{
		string result = string.Empty;
		uint num = time;
		uint num2 = time / 86400;
		time -= num2 * 86400;
		uint num3 = time / 3600;
		time -= num3 * 3600;
		uint num4 = time / 60;
		uint num5 = time - num4 * 60;
		if (num == 60)
		{
			num5 = 60u;
		}
		if (num == 3600)
		{
			num4 = 60u;
		}
		if (num == 86400)
		{
			num3 = 24u;
		}
		if (num <= 60)
		{
			result = num5 + GProD.TX(7091);
		}
		if (num > 60 && num <= 3600)
		{
			result = num4 + GProD.TX(7092) + Class16.smethod_0(1648942211) + num5 + GProD.TX(7091);
		}
		if (num > 3600 && num <= 86400)
		{
			result = num3 + GProD.TX(7093) + Class16.smethod_0(1648942211) + num4 + GProD.TX(7092);
		}
		if (num > 86400)
		{
			result = num2 + GProD.TX(7094) + Class16.smethod_0(1648942211) + num3 + GProD.TX(7093);
		}
		return result;
	}

	public static string ItemPropsSecondsToString2(uint time)
	{
		string result = string.Empty;
		uint num = time;
		uint num2 = time / 86400;
		time -= num2 * 86400;
		uint num3 = time / 3600;
		time -= num3 * 3600;
		uint num4 = time / 60;
		uint num5 = time - num4 * 60;
		if (num == 60)
		{
			num5 = 60u;
		}
		if (num == 3600)
		{
			num4 = 60u;
		}
		if (num == 86400)
		{
			num3 = 24u;
		}
		if (num <= 60)
		{
			result = num5 + GProD.TX(7114);
		}
		if (num > 60 && num <= 3600)
		{
			result = num4 + GProD.TX(7115) + Class16.smethod_0(1648942211) + num5 + GProD.TX(7114);
		}
		if (num > 3600 && num <= 86400)
		{
			result = num3 + GProD.TX(7116) + Class16.smethod_0(1648942211) + num4 + GProD.TX(7115);
		}
		if (num > 86400)
		{
			result = num2 + GProD.TX(7117) + Class16.smethod_0(1648942211) + num3 + GProD.TX(7116);
		}
		return result;
	}

	public static string ColorToString(Color color)
	{
		return string.Format(Class16.smethod_0(1649252148), color.R, color.G, color.B).ToUpper();
	}

	public static Color StringToColor(string String, int StartIndex)
	{
		Color result = Color.FromArgb(1, 0, 0, 0);
		if (String.Length >= 6 + StartIndex && int.TryParse(Class16.smethod_0(1649252174) + String.Substring(StartIndex, 6), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result2))
		{
			return Color.FromArgb(result2);
		}
		return result;
	}

	public static string BS(bool value)
	{
		if (value)
		{
			return GProD.TX(2311);
		}
		return GProD.TX(2310);
	}

	public static string StringToRTF(string String, Color DefaultColor, Font Font)
	{
		String = String.Replace(Class16.smethod_0(1648927580), Class16.smethod_0(1648903386));
		String = String.Replace(Class16.smethod_0(1648908124), Class16.smethod_0(1649252183));
		String = String.Replace(Class16.smethod_0(1648908132), Class16.smethod_0(1649252184));
		string text = string.Empty;
		string text2 = Class16.smethod_0(1649252193);
		List<Color> list = new List<Color>();
		list.Add(DefaultColor);
		text2 = text2 + Class16.smethod_0(1649252220) + list[0].R + Class16.smethod_0(1649252231) + list[0].G + Class16.smethod_0(1649252244) + list[0].B + Class16.smethod_0(1648898262);
		Color color = DefaultColor;
		bool flag = true;
		string[] array = (ColorToString(DefaultColor) + String).Split('^');
		for (int i = 1; i < array.Length; i++)
		{
			if (!(array[i] != string.Empty))
			{
				continue;
			}
			try
			{
				Color color2 = StringToColor(array[i], 0);
				if (color2.A != 1)
				{
					color = ((!(color2.Name == Class16.smethod_0(1649252248))) ? color2 : DefaultColor);
					flag = true;
					for (int j = 0; j < list.Count; j++)
					{
						if (list[j] == color)
						{
							text += smethod_2(Class16.smethod_0(1649252269) + (j + 1) + Class16.smethod_0(1648942211) + array[i].Substring(6));
							flag = false;
							break;
						}
					}
					if (flag)
					{
						list.Add(color);
						text2 = text2 + Class16.smethod_0(1649252220) + list[list.Count - 1].R + Class16.smethod_0(1649252231) + list[list.Count - 1].G + Class16.smethod_0(1649252244) + list[list.Count - 1].B + Class16.smethod_0(1648898262);
						text += smethod_2(Class16.smethod_0(1649252269) + list.Count + Class16.smethod_0(1648942211) + array[i].Substring(6));
					}
				}
				else
				{
					text += smethod_2(Class16.smethod_0(1648935659) + array[i]);
				}
			}
			catch
			{
				text += smethod_2(Class16.smethod_0(1648935659) + array[i]);
			}
		}
		text2 += Class16.smethod_0(1649252279);
		string text3 = Class16.smethod_0(1649252281) + Font.Name + Class16.smethod_0(1649251347) + text2 + Class16.smethod_0(1649251367);
		if (Font.Bold)
		{
			text3 += Class16.smethod_0(1648905146);
		}
		return text3 + Class16.smethod_0(1649251394) + Math.Ceiling(Font.Size * 2f) + Class16.smethod_0(1648942211) + text;
	}

	private static string smethod_2(string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = string_0.Replace(Class16.smethod_0(1648924428), Class16.smethod_0(1649251415));
		foreach (char c in text)
		{
			if (c <= '\u007f')
			{
				stringBuilder.Append(c);
			}
			else
			{
				stringBuilder.Append(Class16.smethod_0(1649251428) + Convert.ToUInt32(c) + Class16.smethod_0(1648942867));
			}
		}
		return stringBuilder.ToString();
	}
}
