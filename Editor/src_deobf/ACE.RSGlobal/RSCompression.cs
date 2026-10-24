using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace ACE.RSGlobal;

public class RSCompression
{
	public static void Init()
	{
	}

	private static byte[] smethod_0(byte[] byte_0, CompressionLevel compressionLevel_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			GZipStream gZipStream = new GZipStream(memoryStream, compressionLevel_0, leaveOpen: true);
			try
			{
				gZipStream.Write(byte_0, 0, byte_0.Length);
			}
			finally
			{
				((IDisposable)gZipStream).Dispose();
			}
			return memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public static byte[] CompressData(byte[] data)
	{
		return smethod_0(data, CompressionLevel.Optimal);
	}

	public static byte[] DecompressData(byte[] data)
	{
		return smethod_1(data);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool CompressFiles(string[] FileNames, string ArchiveFN)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		if (File.Exists(ArchiveFN))
		{
			File.Delete(ArchiveFN);
		}
		FileStream fileStream = new FileStream(ArchiveFN, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
		try
		{
			ZipArchive val = new ZipArchive((Stream)fileStream, (ZipArchiveMode)1);
			try
			{
				foreach (string path in FileNames)
				{
					if (!File.Exists(path))
					{
						continue;
					}
					string fileName = System.IO.Path.GetFileName(path);
					ZipArchiveEntry val2 = val.CreateEntry(fileName, CompressionLevel.Fastest);
					using Stream destination = val2.Open();
					using FileStream fileStream2 = File.OpenRead(path);
					fileStream2.CopyTo(destination);
				}
				return File.Exists(ArchiveFN);
			}
			finally
			{
				((IDisposable)val).Dispose();
			}
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool CompressFile(string FileName, string ArchiveFN)
	{
		return CompressFiles(new string[1] { FileName }, ArchiveFN);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool CompressDir(string directoryPath, string ArchiveFN)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		if (File.Exists(ArchiveFN))
		{
			File.Delete(ArchiveFN);
		}
		if (!Directory.Exists(directoryPath))
		{
			return File.Exists(ArchiveFN);
		}
		string text = directoryPath.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
		FileStream fileStream = new FileStream(ArchiveFN, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
		try
		{
			ZipArchive val = new ZipArchive((Stream)fileStream, (ZipArchiveMode)1);
			try
			{
				string[] files = Directory.GetFiles(text, Class16.smethod_0(1648941528), SearchOption.AllDirectories);
				string[] array = files;
				foreach (string text2 in array)
				{
					string text3 = text2.Substring(text.Length).TrimStart(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
					ZipArchiveEntry val2 = val.CreateEntry(text3, CompressionLevel.Optimal);
					using Stream destination = val2.Open();
					using FileStream fileStream2 = File.OpenRead(text2);
					fileStream2.CopyTo(destination);
				}
				return File.Exists(ArchiveFN);
			}
			finally
			{
				((IDisposable)val).Dispose();
			}
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}

	public static byte[] CompressDataFast(byte[] data)
	{
		return smethod_0(data, CompressionLevel.Fastest);
	}

	public static byte[] DecompressDataFast(byte[] data)
	{
		return smethod_1(data);
	}

	private static byte[] smethod_1(byte[] byte_0)
	{
		MemoryStream memoryStream = new MemoryStream(byte_0);
		try
		{
			GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
			try
			{
				MemoryStream memoryStream2 = new MemoryStream();
				try
				{
					gZipStream.CopyTo(memoryStream2);
					return memoryStream2.ToArray();
				}
				finally
				{
					((IDisposable)memoryStream2).Dispose();
				}
			}
			finally
			{
				((IDisposable)gZipStream).Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public static void DecompressArchive(string archiveFN, string directory)
	{
		smethod_2(archiveFN, directory);
	}

	public static void DecompressArchive(string archiveFN)
	{
		string text = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(archiveFN));
		if (string.IsNullOrWhiteSpace(text))
		{
			text = Environment.CurrentDirectory;
		}
		smethod_2(archiveFN, text);
	}

	private static void smethod_2(string string_0, string string_1)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		Directory.CreateDirectory(string_1);
		FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.Read);
		try
		{
			ZipArchive val = new ZipArchive((Stream)fileStream, (ZipArchiveMode)0);
			try
			{
				foreach (ZipArchiveEntry entry in val.Entries)
				{
					string path = System.IO.Path.Combine(string_1, entry.FullName);
					string directoryName = System.IO.Path.GetDirectoryName(path);
					if (!string.IsNullOrEmpty(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					if (string.IsNullOrEmpty(entry.Name))
					{
						continue;
					}
					using Stream stream = entry.Open();
					FileStream fileStream2 = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
					try
					{
						stream.CopyTo(fileStream2);
					}
					finally
					{
						((IDisposable)fileStream2).Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)val).Dispose();
			}
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}
}
