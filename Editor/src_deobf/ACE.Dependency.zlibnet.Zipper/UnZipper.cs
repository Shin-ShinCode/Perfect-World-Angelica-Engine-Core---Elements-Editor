using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using ACE.Dependency.zlibnet.Minizip;

namespace ACE.Dependency.zlibnet.Zipper;

public class UnZipper
{
	public string ZipFile;

	public List<string> ItemList = new List<string>();

	public bool Recurse;

	public enIfFileExist IfFileExist = enIfFileExist.Exception;

	public bool NoDirectoryNames;

	public string Destination;

	private byte[] byte_0;

	private CreateUnzippedNameEventHandler createUnzippedNameEventHandler_0;

	public event CreateUnzippedNameEventHandler CreateUnzippedNameEvent
	{
		[CompilerGenerated]
		add
		{
			CreateUnzippedNameEventHandler createUnzippedNameEventHandler = createUnzippedNameEventHandler_0;
			CreateUnzippedNameEventHandler createUnzippedNameEventHandler2;
			do
			{
				createUnzippedNameEventHandler2 = createUnzippedNameEventHandler;
				CreateUnzippedNameEventHandler value2 = (CreateUnzippedNameEventHandler)Delegate.Combine(createUnzippedNameEventHandler2, value);
				createUnzippedNameEventHandler = Interlocked.CompareExchange(ref createUnzippedNameEventHandler_0, value2, createUnzippedNameEventHandler2);
			}
			while ((object)createUnzippedNameEventHandler != createUnzippedNameEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CreateUnzippedNameEventHandler createUnzippedNameEventHandler = createUnzippedNameEventHandler_0;
			CreateUnzippedNameEventHandler createUnzippedNameEventHandler2;
			do
			{
				createUnzippedNameEventHandler2 = createUnzippedNameEventHandler;
				CreateUnzippedNameEventHandler value2 = (CreateUnzippedNameEventHandler)Delegate.Remove(createUnzippedNameEventHandler2, value);
				createUnzippedNameEventHandler = Interlocked.CompareExchange(ref createUnzippedNameEventHandler_0, value2, createUnzippedNameEventHandler2);
			}
			while ((object)createUnzippedNameEventHandler != createUnzippedNameEventHandler2);
		}
	}

	public void UnZip()
	{
		if (Destination == null)
		{
			throw new ArgumentException(Class16.smethod_0(1648889210));
		}
		if (ItemList.Count == 0)
		{
			throw new ArgumentException(Class16.smethod_0(1648889244));
		}
		FileSpecMatcher fileSpecMatcher = new FileSpecMatcher(ItemList, Recurse);
		bool flag = false;
		ZipReader zipReader = new ZipReader(ZipFile);
		try
		{
			byte_0 = new byte[4096];
			foreach (ZipEntry item in zipReader)
			{
				if (!fileSpecMatcher.MatchSpecs(item.Name, item.IsDirectory))
				{
					continue;
				}
				if (item.IsDirectory)
				{
					if (!NoDirectoryNames)
					{
						string path = method_1(item);
						DirectoryInfo directoryInfo = new DirectoryInfo(path);
						if (!directoryInfo.Exists)
						{
							directoryInfo.Create();
						}
						method_0(directoryInfo, item.ModifiedTime);
					}
				}
				else
				{
					string text = method_1(item);
					FileInfo fileInfo = new FileInfo(text);
					if (!fileInfo.Directory.Exists)
					{
						fileInfo.Directory.Create();
					}
					if (fileInfo.Exists)
					{
						switch (IfFileExist)
						{
						case enIfFileExist.Overwrite:
							break;
						case enIfFileExist.Skip:
							continue;
						default:
							throw new NotImplementedException(Class16.smethod_0(1648889288) + IfFileExist);
						case enIfFileExist.Exception:
							throw new ZipException(Class16.smethod_0(1648889268) + text);
						}
					}
					using (FileStream fileStream = fileInfo.Create())
					{
						int count;
						while ((count = zipReader.Read(byte_0, 0, byte_0.Length)) > 0)
						{
							fileStream.Write(byte_0, 0, count);
						}
					}
					method_0(fileInfo, item.ModifiedTime);
				}
				flag = true;
			}
		}
		finally
		{
			((IDisposable)zipReader).Dispose();
		}
		if (!flag)
		{
			throw new ZipException(Class16.smethod_0(1648889317));
		}
	}

	private void method_0(FileSystemInfo fileSystemInfo_0, DateTime dateTime_0)
	{
		TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
		fileSystemInfo_0.LastWriteTimeUtc = dateTime_0 - utcOffset;
	}

	private string method_1(ZipEntry zipEntry_0)
	{
		string text = null;
		if (NoDirectoryNames)
		{
			if (zipEntry_0.IsDirectory)
			{
				throw new Exception(Class16.smethod_0(1648889341));
			}
			text = System.IO.Path.GetFileName(zipEntry_0.Name);
		}
		else
		{
			text = zipEntry_0.Name.TrimStartDirSep();
		}
		string fullPath = System.IO.Path.GetFullPath(Destination + System.IO.Path.DirectorySeparatorChar + text);
		CreateUnzippedNameEventArgs e = new CreateUnzippedNameEventArgs(fullPath, zipEntry_0.IsDirectory);
		method_2(e);
		return e.UnzippedName;
	}

	private void method_2(CreateUnzippedNameEventArgs createUnzippedNameEventArgs_0)
	{
		if (createUnzippedNameEventHandler_0 != null)
		{
			createUnzippedNameEventHandler_0(this, createUnzippedNameEventArgs_0);
		}
	}
}
