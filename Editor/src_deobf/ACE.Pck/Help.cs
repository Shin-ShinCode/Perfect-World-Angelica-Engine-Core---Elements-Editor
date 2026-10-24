using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ACE.Dependency.Ionic.Zlib;

namespace ACE.Pck;

public static class Help
{
	private sealed class Class323
	{
		public string string_0;

		public SearchOption searchOption_0;

		internal IEnumerable<string> method_0(string string_1)
		{
			return GetListFiles(string_1, string_0, searchOption_0);
		}
	}

	public static string AfterFirst(this string value, char delimiter)
	{
		return value.Substring((value.Split(delimiter)[0] + delimiter).Length);
	}

	public static string AfterLast(this string value, char delimiter)
	{
		return value.Split(delimiter)[value.Split(delimiter).Length - 1];
	}

	public static string BeforeFirst(this string value, char delimiter)
	{
		return value.Split(delimiter)[0];
	}

	public static string BeforeLast(this string value, char delimiter)
	{
		return value.TrimEnd(string.Format(delimiter + value.Split(delimiter)[value.Split(delimiter).Length - 1]).ToCharArray());
	}

	public static string Append(this string value, string delimiter)
	{
		return value + delimiter;
	}

	public static string Mid(this string value, int length)
	{
		return value.Substring(length);
	}

	public static byte[] ConvertTo(this string value, Encoding encoding)
	{
		return encoding.GetBytes(value);
	}

	public static byte[] FillPath(this byte[] value)
	{
		Array.Resize(ref value, 260);
		return value;
	}

	public static byte[] ZlibCompress(byte[] buffer, CompressionLevel level)
	{
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			ZlibStream zlibStream = new ZlibStream(memoryStream, CompressionMode.Compress, level);
			try
			{
				zlibStream.Write(buffer, 0, buffer.Length);
			}
			finally
			{
				((IDisposable)zlibStream).Dispose();
			}
			return memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public static byte[] ZlibCompress(byte[] buffer)
	{
		return ZlibCompress(buffer, CompressionLevel.BestSpeed);
	}

	public static byte[] ZlibDecompress(byte[] buffer, uint sizeDecompressed)
	{
		MemoryStream memoryStream = new MemoryStream(buffer);
		try
		{
			ZlibStream zlibStream = new ZlibStream(memoryStream, CompressionMode.Decompress);
			try
			{
				byte[] array = new byte[sizeDecompressed];
				zlibStream.Read(array, 0, (int)sizeDecompressed);
				return array;
			}
			finally
			{
				((IDisposable)zlibStream).Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public static void CreatePath(string rootDirectory, string subPath)
	{
		rootDirectory = rootDirectory.Append(Class16.smethod_0(1648927580));
		subPath = subPath.Replace('/', '\\');
		while (subPath.Contains(Class16.smethod_0(1648927580)))
		{
			rootDirectory = rootDirectory.Append(subPath.BeforeFirst('\\') + Class16.smethod_0(1648927580));
			subPath = subPath.AfterFirst('\\');
			if (!Directory.Exists(rootDirectory))
			{
				Directory.CreateDirectory(rootDirectory);
			}
		}
	}

	public static IEnumerable<string> GetListFiles(string path, string pattern, SearchOption so)
	{
		Class323 @class = new Class323();
		@class.string_0 = pattern;
		@class.searchOption_0 = so;
		try
		{
			return Directory.EnumerateDirectories(path).SelectMany(@class.method_0).Concat(Directory.EnumerateFiles(path, @class.string_0));
		}
		catch (UnauthorizedAccessException)
		{
			return Enumerable.Empty<string>();
		}
	}

	public static bool Compare(byte[] buffer1, byte[] buffer2, uint length)
	{
		uint num = 0u;
		while (true)
		{
			if (num < length)
			{
				if (buffer1[num] != buffer2[num])
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

	public static string EncodeBase64Entry(string decodedPath, Encoding encoding)
	{
		string text = string.Empty;
		while (decodedPath.Contains(Class16.smethod_0(1648927580)))
		{
			string value = decodedPath.AfterLast('\\');
			value = Base64Encode(value, encoding);
			text = Class16.smethod_0(1648927580) + value + text;
			decodedPath = decodedPath.BeforeLast('\\');
		}
		return text;
	}

	public static string DecodeBase64Entry(string encodedPath, Encoding encoding)
	{
		string text = string.Empty;
		while (encodedPath.Contains(Class16.smethod_0(1648927580)))
		{
			string value = encodedPath.AfterLast('\\');
			value = Base64Decode(value, encoding);
			text = Class16.smethod_0(1648927580) + value + text;
			encodedPath = encodedPath.BeforeLast('\\');
		}
		return text;
	}

	public static string Base64Encode(string value, Encoding encoding)
	{
		return Convert.ToBase64String(encoding.GetBytes(value));
	}

	public static string Base64Decode(string value, Encoding encoding)
	{
		return encoding.GetString(Convert.FromBase64String(value));
	}
}
