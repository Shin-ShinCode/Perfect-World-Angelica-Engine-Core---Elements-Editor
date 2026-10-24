using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ACE.EcmEditor.Models;

namespace ACE.EcmEditor.Services;

public class EcmDirectoryScanner
{
	[Serializable]
	private sealed class Class119
	{
		public static readonly Class119 class119_0 = new Class119();

		public static Func<EcmFile, string> func_0;

		public static Func<EcmFile, EcmGender> func_1;

		internal string method_0(EcmFile ecmFile_0)
		{
			return ecmFile_0.ClassName;
		}

		internal EcmGender method_1(EcmFile ecmFile_0)
		{
			return ecmFile_0.Gender;
		}
	}

	private static readonly Encoding encoding_0;

	static EcmDirectoryScanner()
	{
		encoding_0 = Encoding.GetEncoding(936);
	}

	public List<EcmFile> ScanRecursive(string rootPath)
	{
		List<EcmFile> list = new List<EcmFile>();
		if (!Directory.Exists(rootPath))
		{
			return list;
		}
		try
		{
			string[] files = Directory.GetFiles(rootPath, Class16.smethod_0(1648994650), SearchOption.AllDirectories);
			string[] array = files;
			foreach (string string_ in array)
			{
				EcmFile ecmFile = method_0(string_);
				if (ecmFile != null)
				{
					list.Add(ecmFile);
				}
			}
		}
		catch (UnauthorizedAccessException)
		{
		}
		catch (IOException)
		{
		}
		return list.OrderBy(Class119.class119_0.method_0).ThenBy(Class119.class119_0.method_1).ToList();
	}

	private EcmFile method_0(string string_0)
	{
		try
		{
			string fileName = System.IO.Path.GetFileName(string_0);
			var (className, gender) = EcmClassIdentifier.Identify(fileName);
			return new EcmFile
			{
				FilePath = string_0,
				FileName = fileName,
				ClassName = className,
				Gender = gender
			};
		}
		catch
		{
			return null;
		}
	}

	public bool LoadContent(EcmFile ecmFile)
	{
		try
		{
			if (!File.Exists(ecmFile.FilePath))
			{
				return false;
			}
			string[] buffer = File.ReadAllLines(ecmFile.FilePath, encoding_0);
			ecmFile.ScriptData = new EcmScriptData(buffer);
			ecmFile.ScriptData.GetIndexAndCount();
			int num = -1;
			List<int> arrIdScript = ecmFile.ScriptData.GetArrIdScript();
			for (int i = 0; i < arrIdScript.Count; i++)
			{
				if (arrIdScript[i] == 6)
				{
					num = i;
					break;
				}
			}
			if (num >= 0)
			{
				ecmFile.OriginalContent = ecmFile.ScriptData.GetDecodeData(num);
				ecmFile.CurrentContent = ecmFile.OriginalContent;
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	public bool SaveContent(EcmFile ecmFile)
	{
		try
		{
			if (ecmFile.ScriptData == null)
			{
				return false;
			}
			int num = -1;
			List<int> arrIdScript = ecmFile.ScriptData.GetArrIdScript();
			for (int i = 0; i < arrIdScript.Count; i++)
			{
				if (arrIdScript[i] == 6)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				return false;
			}
			ecmFile.ScriptData.GetIndexAndCount();
			ecmFile.ScriptData.GetEncodeData(ecmFile.CurrentContent);
			ecmFile.ScriptData.ReplaceEncodeData(num);
			StreamWriter streamWriter = new StreamWriter(ecmFile.FilePath, append: false, encoding_0);
			try
			{
				foreach (string item in ecmFile.ScriptData.GetBuffer())
				{
					streamWriter.WriteLine(item);
				}
			}
			finally
			{
				((IDisposable)streamWriter).Dispose();
			}
			ecmFile.OriginalContent = ecmFile.CurrentContent;
			return true;
		}
		catch
		{
			return false;
		}
	}
}
