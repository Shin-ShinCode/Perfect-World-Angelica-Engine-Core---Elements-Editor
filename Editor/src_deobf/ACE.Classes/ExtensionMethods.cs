using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACE.Classes;

public static class ExtensionMethods
{
	[Serializable]
	private sealed class Class70
	{
		public static readonly Class70 class70_0 = new Class70();

		public static Func<string, string> func_0;

		internal string method_0(string string_0)
		{
			return string_0.Replace(Class16.smethod_0(1648942211), string.Empty);
		}
	}

	private static string[] string_0 = new string[1] { Class16.smethod_0(1648924402) };

	public static void SetValueSafe(this NumericUpDown nud, decimal value)
	{
		if (value < nud.Minimum)
		{
			value = nud.Minimum;
		}
		else if (value > nud.Maximum)
		{
			value = nud.Maximum;
		}
		nud.Value = value;
	}

	public static byte[] GetBytesFromString(this string str, int int_0, Encoding encoding_0)
	{
		str = str.Split(default(char))[0];
		byte[] array = new byte[int_0];
		if (encoding_0.GetByteCount(str) > int_0)
		{
			Array.Copy(encoding_0.GetBytes(str), 0, array, 0, int_0);
		}
		else
		{
			Array.Copy(encoding_0.GetBytes(str), array, encoding_0.GetByteCount(str));
		}
		return array;
	}

	public static string Decode(this byte[] array, Encoding encoding_0)
	{
		return encoding_0.GetString(array);
	}

	public static string GetIconNameFromString(this string Source)
	{
		return Source.Split('\\').Last();
	}

	public static string ToString(this byte[] Array, Encoding encoding_0)
	{
		return encoding_0.GetString(Array).TrimEnd(default(char));
	}

	public static Bitmap ResizeImage(this Bitmap Source, int Width, int Height)
	{
		Bitmap bitmap = new Bitmap(Width, Height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(Source, 0, 0, Width, Height);
		graphics.Dispose();
		return bitmap;
	}

	public static int SumBytes(this List<string> Types)
	{
		int num = 0;
		foreach (string Type in Types)
		{
			if (!Type.Contains(Class16.smethod_0(1648902717)) && !Type.Contains(Class16.smethod_0(1648902721)) && !Type.Contains(Class16.smethod_0(1648902740)) && !Type.Contains(Class16.smethod_0(1648902744)))
			{
				if (Type.Contains(Class16.smethod_0(1648902764)) && !Type.Contains(Class16.smethod_0(1648902775)))
				{
					num += Convert.ToInt32(Type.Split(':')[1]);
				}
				else if (Type.Contains(Class16.smethod_0(1648902778)))
				{
					num += Convert.ToInt32(Type.Split(':')[1]);
				}
				else if (Type.Contains(Class16.smethod_0(1648902792)))
				{
					num += Convert.ToInt32(Type.Split(':')[1]);
				}
				else if (Type.Contains(Class16.smethod_0(1648902813)))
				{
					num = -1;
					break;
				}
			}
			else
			{
				num += 4;
			}
		}
		return num;
	}

	public static List<string> ToLines(this MemoryStream ms, Encoding encoding_0)
	{
		if (ms != null)
		{
			return new StreamReader(ms, encoding_0).ReadToEnd().Split(new string[1] { Class16.smethod_0(1648924428) }, StringSplitOptions.RemoveEmptyEntries).ToList();
		}
		return null;
	}

	public static string GetEcmLineValue(this string Line)
	{
		return Line.Split(string_0, StringSplitOptions.RemoveEmptyEntries)[1].Replace(Class16.smethod_0(1648942211), string.Empty);
	}

	public static string[] SplitEcmLine(this string Line)
	{
		return Line.Split(string_0, StringSplitOptions.RemoveEmptyEntries).Select(Class70.class70_0.method_0).ToArray();
	}

	public static int ToInt32(this string value)
	{
		return Convert.ToInt32(value);
	}

	public static float ToSingle(this string value)
	{
		return Convert.ToSingle(value.Replace('.', ','));
	}

	public static bool ToBoolean(this string value)
	{
		if (!(value == Class16.smethod_0(1648934925)))
		{
			return false;
		}
		return true;
	}
}
