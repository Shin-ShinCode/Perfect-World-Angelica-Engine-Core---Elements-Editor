using System;
using System.Globalization;
using System.IO;

namespace ACE.GFX;

public sealed class GfxFileReader : IDisposable
{
	private readonly StringReader stringReader_0;

	private int int_0;

	public int LineNumber => int_0;

	public GfxFileReader(string content)
	{
		stringReader_0 = new StringReader(content);
		int_0 = 0;
	}

	public string ReadLine()
	{
		int_0++;
		return stringReader_0.ReadLine();
	}

	public int ReadInt(string prefix = null)
	{
		string text = ReadLine();
		if (text == null)
		{
			return 0;
		}
		return smethod_0(text, prefix);
	}

	public float ReadFloat(string prefix = null)
	{
		string text = ReadLine();
		if (text == null)
		{
			return 0f;
		}
		return smethod_1(text, prefix);
	}

	public string ReadString(string prefix = null)
	{
		string text = ReadLine();
		if (text == null)
		{
			return string.Empty;
		}
		return smethod_2(text, prefix);
	}

	public int ReadIntField()
	{
		string text = ReadLine();
		if (text == null)
		{
			return 0;
		}
		return smethod_3(text);
	}

	public float ReadFloatField()
	{
		string text = ReadLine();
		if (text == null)
		{
			return 0f;
		}
		return smethod_4(text);
	}

	public bool ReadBool(string prefix = null)
	{
		return ReadInt(prefix) != 0;
	}

	public (float x, float y, float z) ReadVector3()
	{
		string text = ReadLine();
		if (text == null)
		{
			return (x: 0f, y: 0f, z: 0f);
		}
		int num = text.IndexOf(':');
		if (num < 0)
		{
			return (x: 0f, y: 0f, z: 0f);
		}
		string text2 = text.Substring(num + 1).Trim();
		string[] array = text2.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length < 3)
		{
			return (x: 0f, y: 0f, z: 0f);
		}
		return (x: float.Parse(array[0].Trim(), CultureInfo.InvariantCulture), y: float.Parse(array[1].Trim(), CultureInfo.InvariantCulture), z: float.Parse(array[2].Trim(), CultureInfo.InvariantCulture));
	}

	public (float x, float y, float z, float w) ReadVector4()
	{
		string text = ReadLine();
		if (text == null)
		{
			return (x: 0f, y: 0f, z: 0f, w: 1f);
		}
		int num = text.IndexOf(':');
		if (num < 0)
		{
			return (x: 0f, y: 0f, z: 0f, w: 1f);
		}
		string text2 = text.Substring(num + 1).Trim();
		string[] array = text2.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length < 4)
		{
			return (x: 0f, y: 0f, z: 0f, w: 1f);
		}
		return (x: float.Parse(array[0].Trim(), CultureInfo.InvariantCulture), y: float.Parse(array[1].Trim(), CultureInfo.InvariantCulture), z: float.Parse(array[2].Trim(), CultureInfo.InvariantCulture), w: float.Parse(array[3].Trim(), CultureInfo.InvariantCulture));
	}

	public uint ReadColor()
	{
		string text = ReadLine();
		if (text == null)
		{
			return uint.MaxValue;
		}
		int num = text.IndexOf(':');
		if (num < 0)
		{
			return uint.MaxValue;
		}
		string s = text.Substring(num + 1).Trim();
		if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return (uint)result;
		}
		if (uint.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2))
		{
			return result2;
		}
		return uint.MaxValue;
	}

	public uint ReadHexColor()
	{
		string text = ReadLine();
		if (text == null)
		{
			return uint.MaxValue;
		}
		int num = text.IndexOf(':');
		if (num < 0)
		{
			return uint.MaxValue;
		}
		string s = text.Substring(num + 1).Trim();
		if (uint.TryParse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		if (uint.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2))
		{
			return result2;
		}
		return uint.MaxValue;
	}

	public (int a, int b, int c, int d) ReadInt4()
	{
		string text = ReadLine();
		if (text == null)
		{
			return (a: 0, b: 0, c: 0, d: 0);
		}
		int num = text.IndexOf(':');
		if (num < 0)
		{
			return (a: 0, b: 0, c: 0, d: 0);
		}
		string text2 = text.Substring(num + 1).Trim();
		string[] array = text2.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length < 4)
		{
			return (a: 0, b: 0, c: 0, d: 0);
		}
		return (a: int.Parse(array[0].Trim(), CultureInfo.InvariantCulture), b: int.Parse(array[1].Trim(), CultureInfo.InvariantCulture), c: int.Parse(array[2].Trim(), CultureInfo.InvariantCulture), d: int.Parse(array[3].Trim(), CultureInfo.InvariantCulture));
	}

	private static int smethod_0(string string_0, string string_1)
	{
		return smethod_3(string_0);
	}

	private static float smethod_1(string string_0, string string_1)
	{
		return smethod_4(string_0);
	}

	private static string smethod_2(string string_0, string string_1)
	{
		int num = string_0.IndexOf(':');
		if (num < 0)
		{
			return string_0.Trim();
		}
		return string_0.Substring(num + 1).Trim();
	}

	private static int smethod_3(string string_0)
	{
		int num = string_0.IndexOf(':');
		if (num < 0)
		{
			int.TryParse(string_0.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result);
			return result;
		}
		string s = string_0.Substring(num + 1).Trim();
		int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2);
		return result2;
	}

	private static float smethod_4(string string_0)
	{
		int num = string_0.IndexOf(':');
		if (num < 0)
		{
			float.TryParse(string_0.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var result);
			return result;
		}
		string s = string_0.Substring(num + 1).Trim();
		float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var result2);
		return result2;
	}

	public void Dispose()
	{
		stringReader_0?.Dispose();
	}
}
