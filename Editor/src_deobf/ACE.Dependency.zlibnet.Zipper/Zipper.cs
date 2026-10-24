using System;
using System.Collections.Generic;
using System.IO;
using ACE.Dependency.zlibnet.Minizip;

namespace ACE.Dependency.zlibnet.Zipper;

public class Zipper
{
	private sealed class Class98 : IComparable<Class98>
	{
		public string string_0;

		public FileSystemInfo fileSystemInfo_0;

		public Class98(string string_1, FileSystemInfo fileSystemInfo_1)
		{
			string_0 = string_1;
			fileSystemInfo_0 = fileSystemInfo_1;
		}

		public bool method_0()
		{
			return !method_1();
		}

		public bool method_1()
		{
			return fileSystemInfo_0 is DirectoryInfo;
		}

		public string method_2()
		{
			return fileSystemInfo_0.FullName;
		}

		public int CompareTo(Class98 other)
		{
			return string_0.CompareTo(other.string_0);
		}
	}

	public bool Recurse;

	public string ZipFile;

	public enZip64 Zip64 = enZip64.Auto;

	public bool UTF8Encoding = true;

	public List<string> ItemList = new List<string>();

	public List<string> StoreSuffixes = new List<string>();

	private bool bool_0;

	public List<string> ExcludeFollowing = new List<string>();

	public List<string> IncludeOnlyFollowing = new List<string>();

	public bool UseTempFile = true;

	public enPathInZip PathInZip;

	public string Comment;

	private byte[] byte_0;

	public void Zip()
	{
		if (ZipFile == null)
		{
			throw new ArgumentException(Class16.smethod_0(1648888344));
		}
		if (ItemList.Count == 0)
		{
			throw new ArgumentException(Class16.smethod_0(1648889244));
		}
		if (System.IO.Path.GetExtension(ZipFile).Length == 0)
		{
			ZipFile = System.IO.Path.ChangeExtension(ZipFile, Class16.smethod_0(1648888374));
		}
		string text = null;
		if (UseTempFile)
		{
			text = ZipFile;
			ZipFile = method_7(ZipFile);
		}
		FileSpecMatcher fileSpecMatcher_ = null;
		if (ExcludeFollowing.Count > 0)
		{
			fileSpecMatcher_ = new FileSpecMatcher(ExcludeFollowing, recurseFiles: true);
		}
		FileSpecMatcher fileSpecMatcher_2 = null;
		if (IncludeOnlyFollowing.Count > 0)
		{
			fileSpecMatcher_2 = new FileSpecMatcher(IncludeOnlyFollowing, recurseFiles: true);
		}
		byte_0 = new byte[4096];
		List<Class98> list = method_2();
		try
		{
			bool flag = false;
			ZipWriter zipWriter = new ZipWriter(ZipFile);
			try
			{
				zipWriter.Comment = Comment;
				foreach (Class98 item in list)
				{
					if (!method_6(item.string_0, item.method_1(), fileSpecMatcher_2, fileSpecMatcher_))
					{
						continue;
					}
					if (item.method_1())
					{
						if (!method_3())
						{
							throw new Exception(Class16.smethod_0(1648888376));
						}
						DirectoryInfo directoryInfo = (DirectoryInfo)item.fileSystemInfo_0;
						ZipEntry zipEntry = new ZipEntry(item.string_0, isDirectory: true);
						zipEntry.ModifiedTime = method_1(directoryInfo);
						zipEntry.FileAttributes = directoryInfo.Attributes;
						zipEntry.UTF8Encoding = UTF8Encoding;
						zipEntry.Zip64 = Zip64 == enZip64.Yes;
						zipEntry.Method = CompressionMethod.Stored;
						zipWriter.AddEntry(zipEntry);
					}
					else
					{
						FileInfo fileInfo = (FileInfo)item.fileSystemInfo_0;
						if (Zip64 == enZip64.No && fileInfo.Length > 4294967295L)
						{
							throw new NotSupportedException(Class16.smethod_0(1648888423));
						}
						ZipEntry zipEntry2 = new ZipEntry(item.string_0);
						zipEntry2.ModifiedTime = method_1(fileInfo);
						zipEntry2.FileAttributes = fileInfo.Attributes;
						zipEntry2.UTF8Encoding = UTF8Encoding;
						zipEntry2.Zip64 = Zip64 == enZip64.Yes || (fileInfo.Length > 4294967295L && Zip64 == enZip64.Auto);
						if (fileInfo.Length == 0L || method_0(item.string_0))
						{
							zipEntry2.Method = CompressionMethod.Stored;
						}
						zipWriter.AddEntry(zipEntry2);
						using FileStream fileStream = fileInfo.OpenRead();
						int count;
						while ((count = fileStream.Read(byte_0, 0, byte_0.Length)) > 0)
						{
							zipWriter.Write(byte_0, 0, count);
						}
					}
					flag = true;
				}
			}
			finally
			{
				((IDisposable)zipWriter).Dispose();
			}
			if (!flag)
			{
				throw new ZipException(Class16.smethod_0(1648888487));
			}
			if (UseTempFile)
			{
				File.Delete(text);
				File.Move(ZipFile, text);
				ZipFile = text;
			}
		}
		catch
		{
			File.Delete(ZipFile);
			throw;
		}
	}

	private bool method_0(string string_0)
	{
		if (string_0.EndsWith(Class16.smethod_0(1648906484), StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		foreach (string storeSuffix in StoreSuffixes)
		{
			if (string_0.EndsWith(storeSuffix, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	private DateTime method_1(FileSystemInfo fileSystemInfo_0)
	{
		TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
		return fileSystemInfo_0.LastWriteTimeUtc + utcOffset;
	}

	private List<Class98> method_2()
	{
		Dictionary<string, Class98> dictionary = new Dictionary<string, Class98>(StringComparer.OrdinalIgnoreCase);
		foreach (string item2 in ItemList)
		{
			string directoryName = System.IO.Path.GetDirectoryName(item2);
			DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
			Stack<DirectoryInfo> stack = new Stack<DirectoryInfo>();
			stack.Push(directoryInfo);
			string fileName = System.IO.Path.GetFileName(item2);
			while (stack.Count != 0)
			{
				DirectoryInfo directoryInfo2 = stack.Pop();
				method_4(dictionary, directoryInfo, directoryInfo2, fileName);
				if (Recurse)
				{
					DirectoryInfo[] directories = directoryInfo2.GetDirectories();
					foreach (DirectoryInfo item in directories)
					{
						stack.Push(item);
					}
				}
			}
		}
		List<Class98> list = new List<Class98>(dictionary.Values);
		list.Sort();
		return list;
	}

	private bool method_3()
	{
		if (PathInZip != enPathInZip.None)
		{
			return !bool_0;
		}
		return false;
	}

	private void method_4(Dictionary<string, Class98> dictionary_0, DirectoryInfo directoryInfo_0, DirectoryInfo directoryInfo_1, string string_0)
	{
		bool flag = false;
		if (method_3() && directoryInfo_1 != directoryInfo_0)
		{
			method_5(dictionary_0, directoryInfo_0, directoryInfo_1);
		}
		if (string_0.Length > 0)
		{
			FileInfo[] files = directoryInfo_1.GetFiles(string_0);
			foreach (FileInfo fileSystemInfo_ in files)
			{
				flag |= method_5(dictionary_0, directoryInfo_0, fileSystemInfo_);
			}
		}
	}

	private bool method_5(Dictionary<string, Class98> dictionary_0, DirectoryInfo directoryInfo_0, FileSystemInfo fileSystemInfo_0)
	{
		string text = method_8(directoryInfo_0, fileSystemInfo_0);
		Class98 @class = new Class98(text, fileSystemInfo_0);
		string key = text.TrimEndDirSep();
		Class98 value = null;
		if (dictionary_0.TryGetValue(key, out value))
		{
			if ((@class.method_1() && value.method_1()) || (@class.method_0() && value.method_0() && value.method_2().Equals(@class.method_2(), StringComparison.OrdinalIgnoreCase)))
			{
				return false;
			}
			throw new ArgumentException(string.Format(Class16.smethod_0(1648888508), value.method_1() ? Class16.smethod_0(1648888575) : Class16.smethod_0(1648888564), value.fileSystemInfo_0.FullName, @class.method_1() ? Class16.smethod_0(1648888575) : Class16.smethod_0(1648888564), @class.fileSystemInfo_0.FullName, @class.string_0));
		}
		dictionary_0.Add(key, @class);
		return true;
	}

	private bool method_6(string string_0, bool bool_1, FileSpecMatcher fileSpecMatcher_0, FileSpecMatcher fileSpecMatcher_1)
	{
		if ((fileSpecMatcher_0 != null && !fileSpecMatcher_0.MatchSpecs(string_0, bool_1)) || (fileSpecMatcher_1 != null && fileSpecMatcher_1.MatchSpecs(string_0, bool_1)))
		{
			return false;
		}
		return true;
	}

	private string method_7(string string_0)
	{
		int num = 0;
		string text;
		while (true)
		{
			text = string_0 + Class16.smethod_0(1648928036);
			if (num > 0)
			{
				text += num;
			}
			text += Class16.smethod_0(1648888577);
			if (!File.Exists(text))
			{
				break;
			}
			num++;
		}
		return text;
	}

	private string method_8(DirectoryInfo directoryInfo_0, FileSystemInfo fileSystemInfo_0)
	{
		string text = null;
		if (bool_0 && fileSystemInfo_0 is DirectoryInfo)
		{
			throw new Exception(Class16.smethod_0(1648888587));
		}
		text = PathInZip switch
		{
			enPathInZip.Relative => method_9(fileSystemInfo_0.FullName, directoryInfo_0.FullName), 
			enPathInZip.Absolute => method_9(fileSystemInfo_0.FullName, directoryInfo_0.Root.FullName), 
			enPathInZip.AbsoluteRoot => fileSystemInfo_0.FullName, 
			enPathInZip.None => fileSystemInfo_0.Name, 
			_ => throw new NotImplementedException(Class16.smethod_0(1648888656) + PathInZip), 
		};
		if (text.Length == 0)
		{
			throw new Exception(string.Format(Class16.smethod_0(1648888675), (fileSystemInfo_0 is DirectoryInfo) ? Class16.smethod_0(1648888575) : Class16.smethod_0(1648888564), fileSystemInfo_0.FullName));
		}
		if (fileSystemInfo_0 is DirectoryInfo)
		{
			text = text.SetEndDirSep();
		}
		return text;
	}

	private string method_9(string string_0, string string_1)
	{
		return string_0.Substring(string_1.Length).TrimStartDirSep();
	}
}
