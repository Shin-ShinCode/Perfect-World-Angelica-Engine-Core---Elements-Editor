using System;
using System.IO;
using System.Text;

namespace ACE.Dependency.zlibnet.Minizip;

public class ZipEntry
{
	private string string_0 = string.Empty;

	private uint uint_0;

	private long long_0;

	private long long_1;

	private byte[] byte_0;

	private string string_1 = string.Empty;

	private DateTime dateTime_0 = DateTime.Now;

	private FileAttributes fileAttributes_0;

	private CompressionMethod compressionMethod_0 = CompressionMethod.Deflated;

	private int int_0 = 5;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	public string Comment
	{
		get
		{
			return string_1;
		}
		set
		{
			if (value != null && value.Length > 65535)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648886122));
			}
			string_1 = value;
		}
	}

	public long CompressedLength => long_0;

	public uint Crc => uint_0;

	public bool UTF8Encoding
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public byte[] ExtraField
	{
		get
		{
			return byte_0;
		}
		set
		{
			if (value.Length > 65535)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648886180));
			}
			byte_0 = value;
		}
	}

	public CompressionMethod Method
	{
		get
		{
			return compressionMethod_0;
		}
		set
		{
			compressionMethod_0 = value;
		}
	}

	public int Level
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < -1 || value > 9)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648886228), value, Class16.smethod_0(1648886232));
			}
			int_0 = value;
		}
	}

	public bool Zip64
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public long Length => long_1;

	public DateTime ModifiedTime
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			dateTime_0 = value;
		}
	}

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException(Class16.smethod_0(1648889356));
			}
			if (value.Length > 65535)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648889383));
			}
			string_0 = value;
		}
	}

	public bool IsDirectory => bool_0;

	public float Ratio
	{
		get
		{
			float result = -1f;
			if (Length > 0L)
			{
				result = Convert.ToSingle(Length - CompressedLength) / (float)Length;
			}
			return result;
		}
	}

	public FileAttributes FileAttributes
	{
		get
		{
			return fileAttributes_0;
		}
		set
		{
			fileAttributes_0 = value;
		}
	}

	public ZipEntry(string name, bool isDirectory)
	{
		Name = name;
		bool_0 = isDirectory;
	}

	public ZipEntry(string name)
		: this(name, isDirectory: false)
	{
	}

	internal ZipEntry(IntPtr handle)
	{
		ZipEntryInfo64 entryInfoPtr = default(ZipEntryInfo64);
		int num = Minizip.unzGetCurrentFileInfo64(handle, out entryInfoPtr, null, 0u, null, 0u, null, 0u);
		if (num != 0)
		{
			throw new ZipException(Class16.smethod_0(1648886080) + Name, num);
		}
		byte_0 = new byte[entryInfoPtr.ExtraFieldLength];
		byte[] array = new byte[entryInfoPtr.FileNameLength];
		byte[] array2 = new byte[entryInfoPtr.CommentLength];
		num = Minizip.unzGetCurrentFileInfo64(handle, out entryInfoPtr, array, (uint)array.Length, byte_0, (uint)byte_0.Length, array2, (uint)array2.Length);
		if (num != 0)
		{
			throw new ZipException(Class16.smethod_0(1648886080) + Name, num);
		}
		bool_1 = BitFlag.IsSet(entryInfoPtr.Flag, 2048u);
		Encoding encoding = (bool_1 ? Encoding.UTF8 : Minizip.OEMEncoding);
		string_0 = encoding.GetString(array);
		string_1 = encoding.GetString(array2);
		uint_0 = entryInfoPtr.Crc;
		long_0 = (long)entryInfoPtr.CompressedSize;
		long_1 = (long)entryInfoPtr.UncompressedSize;
		compressionMethod_0 = (CompressionMethod)entryInfoPtr.CompressionMethod;
		dateTime_0 = entryInfoPtr.ZipDateTime;
		fileAttributes_0 = (FileAttributes)entryInfoPtr.ExternalFileAttributes;
		bool_0 = method_0();
	}

	private bool method_0()
	{
		bool flag = (fileAttributes_0 & FileAttributes.Directory) != 0;
		bool flag2 = string_0.EndsWithDirSep();
		return flag || flag2;
	}

	internal string GetNameForZip()
	{
		string text = string_0;
		if (bool_0)
		{
			text = text.SetEndDirSep();
		}
		return text.Replace('\\', '/');
	}

	internal FileAttributes GetFileAttributesForZip()
	{
		FileAttributes fileAttributes = fileAttributes_0;
		if (bool_0)
		{
			fileAttributes |= FileAttributes.Directory;
		}
		return fileAttributes;
	}

	public override string ToString()
	{
		return string.Format(Class16.smethod_0(1648889430), Name, base.ToString());
	}
}
