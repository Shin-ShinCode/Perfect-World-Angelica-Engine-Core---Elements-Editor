using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACE.Dependency.zlibnet.Minizip;

public class ZipReader : IEnumerable, IEnumerable<ZipEntry>, IDisposable
{
	private sealed class Class96 : IEnumerator, IDisposable, IEnumerator<ZipEntry>
	{
		private ZipReader zipReader_0;

		public ZipEntry Current => zipReader_0.zipEntry_0;

		object IEnumerator.Current => Current;

		public Class96(ZipReader zipReader_1)
		{
			zipReader_0 = zipReader_1;
		}

		public void Dispose()
		{
			zipReader_0.method_3();
		}

		public bool MoveNext()
		{
			return zipReader_0.method_1();
		}

		public void Reset()
		{
			zipReader_0.method_2();
		}
	}

	private IntPtr intptr_0 = IntPtr.Zero;

	private string string_0;

	private string string_1;

	private ZipEntry zipEntry_0;

	public string Name => string_0;

	public string Comment
	{
		get
		{
			if (string_1 == null)
			{
				ZipFileInfo globalInfoPtr = default(ZipFileInfo);
				int num = Minizip.unzGetGlobalInfo(intptr_0, out globalInfoPtr);
				if (num < 0)
				{
					string message = string.Format(Class16.smethod_0(1648889473), Name);
					throw new ZipException(message, num);
				}
				byte[] array = new byte[globalInfoPtr.CommentLength];
				num = Minizip.unzGetGlobalComment(intptr_0, array, (uint)array.Length);
				if (num < 0)
				{
					string message2 = string.Format(Class16.smethod_0(1648889473), Name);
					throw new ZipException(message2, num);
				}
				string_1 = Encoding.Default.GetString(array);
			}
			return string_1;
		}
	}

	public ZipReader(string fileName)
	{
		string_0 = fileName;
		intptr_0 = Minizip.unzOpen(fileName);
		if (intptr_0 == IntPtr.Zero)
		{
			string message = string.Format(Class16.smethod_0(1648889444), fileName);
			throw new ZipException(message);
		}
	}

	~ZipReader()
	{
		method_5();
	}

	void IDisposable.Dispose()
	{
		Close();
	}

	public void Close()
	{
		method_5();
		GC.SuppressFinalize(this);
	}

	private ZipEntry method_0()
	{
		return zipEntry_0;
	}

	public IEnumerator<ZipEntry> GetEnumerator()
	{
		if (zipEntry_0 != null)
		{
			throw new InvalidOperationException(Class16.smethod_0(1648889523));
		}
		return new Class96(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private bool method_1()
	{
		int num;
		if (zipEntry_0 == null)
		{
			num = Minizip.unzGoToFirstFile(intptr_0);
		}
		else
		{
			method_3();
			num = Minizip.unzGoToNextFile(intptr_0);
		}
		if (num == -100)
		{
			zipEntry_0 = null;
		}
		else
		{
			if (num < 0)
			{
				throw new ZipException(Class16.smethod_0(1648889588), num);
			}
			method_4();
		}
		return zipEntry_0 != null;
	}

	private void method_2()
	{
		method_3();
	}

	private void method_3()
	{
		if (zipEntry_0 != null)
		{
			int num = Minizip.unzCloseCurrentFile(intptr_0);
			if (num < 0)
			{
				throw new ZipException(Class16.smethod_0(1648889603), num);
			}
			zipEntry_0 = null;
		}
	}

	private void method_4()
	{
		zipEntry_0 = new ZipEntry(intptr_0);
		int num = Minizip.unzOpenCurrentFile(intptr_0);
		if (num < 0)
		{
			zipEntry_0 = null;
			throw new ZipException(Class16.smethod_0(1648889644), num);
		}
	}

	public int Read(byte[] buffer, int index, int count)
	{
		FixedArray fixedArray = new FixedArray(buffer);
		try
		{
			int num = Minizip.unzReadCurrentFile(intptr_0, fixedArray[index], (uint)count);
			if (num < 0)
			{
				throw new ZipException(Class16.smethod_0(1648889684), num);
			}
			return num;
		}
		finally
		{
			((IDisposable)fixedArray).Dispose();
		}
	}

	public void Read(Stream writer)
	{
		byte[] array = new byte[4096];
		int count;
		while ((count = Read(array, 0, array.Length)) > 0)
		{
			writer.Write(array, 0, count);
		}
	}

	private void method_5()
	{
		if (!(intptr_0 != IntPtr.Zero))
		{
			return;
		}
		try
		{
			method_3();
		}
		finally
		{
			int num = Minizip.unzClose(intptr_0);
			if (num < 0)
			{
				throw new ZipException(Class16.smethod_0(1648889707), num);
			}
			intptr_0 = IntPtr.Zero;
		}
	}
}
