using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ACE.UIEdit.Models;

namespace ACE.UIEdit.Services;

internal sealed class UiXmlFileService
{
	[Serializable]
	private sealed class Class371
	{
		public static readonly Class371 class371_0 = new Class371();

		public static Func<UiSourceFile, string> func_0;

		public static Func<UiSourceFile, string> func_1;

		internal string method_0(UiSourceFile uiSourceFile_0)
		{
			return uiSourceFile_0.RelativeDirectory;
		}

		internal string method_1(UiSourceFile uiSourceFile_0)
		{
			return uiSourceFile_0.FileName;
		}
	}

	public List<UiSourceFile> LoadSourceFiles(string interfacesPath)
	{
		List<UiSourceFile> list = new List<UiSourceFile>();
		if (!string.IsNullOrWhiteSpace(interfacesPath) && Directory.Exists(interfacesPath))
		{
			string[] files = Directory.GetFiles(interfacesPath, Class16.smethod_0(1649275571), SearchOption.AllDirectories);
			foreach (string filePath in files)
			{
				list.Add(new UiSourceFile
				{
					FilePath = filePath,
					RootPath = interfacesPath
				});
			}
			return list.OrderBy(Class371.class371_0.method_0, StringComparer.OrdinalIgnoreCase).ThenBy(Class371.class371_0.method_1, StringComparer.OrdinalIgnoreCase).ToList();
		}
		return list;
	}

	public string LoadFileContent(UiSourceFile file)
	{
		bool bool_;
		Encoding encoding = smethod_2(file.FilePath, out bool_);
		file.HasBom = bool_;
		file.EncodingName = encoding.WebName;
		byte[] array = File.ReadAllBytes(file.FilePath);
		int num = smethod_1(array);
		return encoding.GetString(array, num, array.Length - num);
	}

	public void SaveFileContent(UiSourceFile file, string text)
	{
		Encoding encoding = new UnicodeEncoding(bigEndian: false, byteOrderMark: true);
		file.HasBom = true;
		file.EncodingName = Class16.smethod_0(1649275591);
		string s = smethod_3(smethod_0(text), 4);
		FileStream fileStream = new FileStream(file.FilePath, FileMode.Create, FileAccess.Write, FileShare.None);
		try
		{
			byte[] preamble = encoding.GetPreamble();
			if (preamble.Length != 0)
			{
				fileStream.Write(preamble, 0, preamble.Length);
			}
			byte[] bytes = encoding.GetBytes(s);
			fileStream.Write(bytes, 0, bytes.Length);
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}

	public bool FileContainsText(UiSourceFile file, string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return true;
		}
		try
		{
			string text2 = LoadFileContent(file);
			return text2.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;
		}
		catch
		{
			return false;
		}
	}

	private static string smethod_0(string string_0)
	{
		string text = string_0 ?? string.Empty;
		Match match = Regex.Match(text, Class16.smethod_0(1649275604), RegexOptions.IgnoreCase);
		if (!match.Success)
		{
			return Class16.smethod_0(1649275636) + text;
		}
		string value = match.Value;
		string value2 = ((!Regex.IsMatch(value, Class16.smethod_0(1649275684), RegexOptions.IgnoreCase)) ? value.Insert(value.Length - 2, Class16.smethod_0(1649275736)) : Regex.Replace(value, Class16.smethod_0(1649275684), Class16.smethod_0(1649275712), RegexOptions.IgnoreCase));
		return text.Remove(match.Index, match.Length).Insert(match.Index, value2);
	}

	private static int smethod_1(byte[] byte_0)
	{
		if (byte_0.Length >= 2)
		{
			if (byte_0[0] == byte.MaxValue && byte_0[1] == 254)
			{
				return 2;
			}
			if (byte_0[0] == 254 && byte_0[1] == byte.MaxValue)
			{
				return 2;
			}
		}
		if (byte_0.Length >= 3 && byte_0[0] == 239 && byte_0[1] == 187 && byte_0[2] == 191)
		{
			return 3;
		}
		if (byte_0.Length >= 4)
		{
			if (byte_0[0] == 0 && byte_0[1] == 0 && byte_0[2] == 254 && byte_0[3] == byte.MaxValue)
			{
				return 4;
			}
			if (byte_0[0] == byte.MaxValue && byte_0[1] == 254 && byte_0[2] == 0 && byte_0[3] == 0)
			{
				return 4;
			}
		}
		return 0;
	}

	private static Encoding smethod_2(string string_0, out bool bool_0)
	{
		byte[] array = File.ReadAllBytes(string_0);
		int num = smethod_1(array);
		bool_0 = num > 0;
		if (num == 2)
		{
			if (array[0] == byte.MaxValue && array[1] == 254)
			{
				return Encoding.Unicode;
			}
			if (array[0] == 254 && array[1] == byte.MaxValue)
			{
				return Encoding.BigEndianUnicode;
			}
		}
		switch (num)
		{
		case 3:
			return Encoding.UTF8;
		case 4:
			if (array[0] == 0 && array[1] == 0 && array[2] == 254 && array[3] == byte.MaxValue)
			{
				return new UTF32Encoding(bigEndian: true, byteOrderMark: true);
			}
			if (array[0] == byte.MaxValue && array[1] == 254 && array[2] == 0 && array[3] == 0)
			{
				return new UTF32Encoding(bigEndian: false, byteOrderMark: true);
			}
			break;
		}
		if (array.Length >= 2)
		{
			if (array[0] == 60 && array[1] == 0)
			{
				return Encoding.Unicode;
			}
			if (array[0] == 0 && array[1] == 60)
			{
				return Encoding.BigEndianUnicode;
			}
		}
		string input = Encoding.ASCII.GetString(array, 0, Math.Min(array.Length, 200));
		Match match = Regex.Match(input, Class16.smethod_0(1649275761), RegexOptions.IgnoreCase);
		if (match.Success)
		{
			string text = match.Groups[Class16.smethod_0(1649275792)].Value.ToLowerInvariant();
			if (text == Class16.smethod_0(1649275802))
			{
				return Encoding.Unicode;
			}
			try
			{
				return Encoding.GetEncoding(text);
			}
			catch
			{
			}
		}
		return new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
	}

	private static string smethod_3(string string_0, int int_0)
	{
		string newValue = new string(' ', int_0);
		return string_0.Replace(Class16.smethod_0(1648904383), newValue).Replace(Class16.smethod_0(1648924428), Class16.smethod_0(1648941987)).Replace('\r', '\n')
			.Replace(Class16.smethod_0(1648941987), Class16.smethod_0(1648924428));
	}
}
