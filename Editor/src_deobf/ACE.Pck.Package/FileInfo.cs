using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACE.Pck.Package;

public class FileInfo
{
	private string string_0;

	private long long_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	public string Path
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public long Offset
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
		[CompilerGenerated]
		set
		{
			long_0 = value;
		}
	}

	public int v3p1
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int Size
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int CompressedSize
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public int v3p2
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public int unk
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public FileInfo()
	{
	}

	public FileInfo(byte[] bytes, int version)
	{
		ReadFile(bytes, version);
	}

	public static FileInfo Read(BinaryReader TableStream, int Version, Keys Key)
	{
		int count = TableStream.ReadInt32() ^ Key.KEY_1;
		TableStream.ReadInt32();
		return new FileInfo(TableStream.ReadBytes(count), Version);
	}

	public void ReadFile(byte[] bytes, int version)
	{
		int num = 276;
		if (version == 131075)
		{
			num = 288;
		}
		if (bytes.Length < num)
		{
			bytes = Zlib.Decompress(bytes, num);
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(bytes));
		Path = Encoding.GetEncoding(936).GetString(binaryReader.ReadBytes(260)).Split(new string[1] { Class16.smethod_0(1648938185) }, StringSplitOptions.RemoveEmptyEntries)[0].Replace('/', '\\');
		if (version == 131075)
		{
			v3p1 = binaryReader.ReadInt32();
			Offset = binaryReader.ReadInt64();
		}
		else
		{
			Offset = binaryReader.ReadUInt32();
		}
		Size = binaryReader.ReadInt32();
		CompressedSize = binaryReader.ReadInt32();
		if (version == 131075)
		{
			v3p2 = binaryReader.ReadInt32();
		}
		unk = binaryReader.ReadInt32();
		binaryReader.Close();
	}

	public byte[] WriteFile(int CompressionLevel, int version)
	{
		int num = 276;
		if (version == 131075)
		{
			num = 288;
		}
		byte[] array = new byte[num];
		MemoryStream output = new MemoryStream(array);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		binaryWriter.Write(Encoding.GetEncoding(Class16.smethod_0(1648921191)).GetBytes(Path.Replace('/', '\\')));
		binaryWriter.BaseStream.Seek(260L, SeekOrigin.Begin);
		if (version == 131075)
		{
			binaryWriter.Write(v3p1);
			binaryWriter.Write(Offset);
		}
		else
		{
			binaryWriter.Write((uint)Offset);
		}
		binaryWriter.Write(Size);
		binaryWriter.Write(CompressedSize);
		if (version == 131075)
		{
			binaryWriter.Write(v3p2);
		}
		binaryWriter.Write(unk);
		binaryWriter.BaseStream.Seek(0L, SeekOrigin.Begin);
		binaryWriter.Close();
		byte[] array2 = Zlib.Compress(array, CompressionLevel);
		if (array2.Length >= num)
		{
			return array;
		}
		return array2;
	}
}
