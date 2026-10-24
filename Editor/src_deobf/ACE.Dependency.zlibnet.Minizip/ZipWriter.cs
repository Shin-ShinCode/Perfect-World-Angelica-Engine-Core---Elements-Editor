using System;
using System.IO;
using System.Text;

namespace ACE.Dependency.zlibnet.Minizip;

public class ZipWriter : IDisposable
{
	private string string_0;

	private string string_1 = string.Empty;

	private ZipEntry zipEntry_0;

	private IntPtr intptr_0 = IntPtr.Zero;

	public string Name => string_0;

	public string Comment
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public ZipWriter(string fileName)
	{
		string_0 = fileName;
		intptr_0 = Minizip.zipOpen(fileName, append: false);
		if (intptr_0 == IntPtr.Zero)
		{
			string message = string.Format(Class16.smethod_0(1648888925), fileName);
			throw new ZipException(message);
		}
	}

	~ZipWriter()
	{
		method_1();
	}

	void IDisposable.Dispose()
	{
		Close();
	}

	public void Close()
	{
		method_1();
		GC.SuppressFinalize(this);
	}

	public void AddEntry(ZipEntry entry)
	{
		method_0();
		ZipFileEntryInfo entryInfoPtr = new ZipFileEntryInfo
		{
			ZipDateTime = entry.ModifiedTime,
			ExternalFileAttributes = (uint)entry.GetFileAttributesForZip()
		};
		byte[] extraField = null;
		uint extraFieldLength = 0u;
		if (entry.ExtraField != null)
		{
			extraField = entry.ExtraField;
			extraFieldLength = (uint)entry.ExtraField.Length;
		}
		string nameForZip = entry.GetNameForZip();
		uint num = 0u;
		if (entry.UTF8Encoding)
		{
			num |= 0x800;
		}
		else
		{
			if (!nameForZip.IsAscii())
			{
				throw new ArgumentException(Class16.smethod_0(1648888974));
			}
			if (entry.Comment != null && !entry.Comment.IsAscii())
			{
				throw new ArgumentException(Class16.smethod_0(1648889018));
			}
		}
		Encoding encoding = (entry.UTF8Encoding ? Encoding.UTF8 : Minizip.OEMEncoding);
		byte[] bytes = encoding.GetBytes(nameForZip + Class16.smethod_0(1648938185));
		byte[] comment = null;
		if (entry.Comment != null)
		{
			comment = encoding.GetBytes(entry.Comment + Class16.smethod_0(1648938185));
		}
		int num2 = Minizip.zipOpenNewFileInZip4_64(intptr_0, bytes, ref entryInfoPtr, extraField, extraFieldLength, null, 0u, comment, (int)entry.Method, entry.Level, num, entry.Zip64);
		if (num2 < 0)
		{
			throw new ZipException(Class16.smethod_0(1648889073), num2);
		}
		zipEntry_0 = entry;
	}

	public void Write(byte[] buffer, int index, int count)
	{
		FixedArray fixedArray = new FixedArray(buffer);
		try
		{
			int num = Minizip.zipWriteInFileInZip(intptr_0, fixedArray[index], (uint)count);
			if (num < 0)
			{
				throw new ZipException(Class16.smethod_0(1648889103), num);
			}
		}
		finally
		{
			((IDisposable)fixedArray).Dispose();
		}
	}

	public void Write(Stream reader)
	{
		byte[] array = new byte[4096];
		int count;
		while ((count = reader.Read(array, 0, array.Length)) > 0)
		{
			Write(array, 0, count);
		}
	}

	private void method_0()
	{
		if (zipEntry_0 != null)
		{
			int num = Minizip.zipCloseFileInZip(intptr_0);
			if (num < 0)
			{
				throw new ZipException(Class16.smethod_0(1648889114), num);
			}
			zipEntry_0 = null;
		}
	}

	private void method_1()
	{
		if (!(intptr_0 != IntPtr.Zero))
		{
			return;
		}
		try
		{
			method_0();
		}
		finally
		{
			int num = Minizip.zipClose(intptr_0, string_1);
			if (num < 0)
			{
				throw new ZipException(Class16.smethod_0(1648889707), num);
			}
			intptr_0 = IntPtr.Zero;
		}
	}
}
