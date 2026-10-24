using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.PWMap;

public sealed class PwMapRmapFile
{
	private int int_0 = 1;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private float float_0 = 1f;

	private byte[] byte_0;

	private int int_5;

	private int int_6;

	public int Version
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

	public int IWidth
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

	public int ILength
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

	public int ImageWidth
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

	public int ImageLength
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

	public float PixelSize
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public byte[] ImageData
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public PwMapRmapFile()
	{
	}

	public PwMapRmapFile(int version, int width, int height)
	{
		Version = version;
		if (version == 3)
		{
			int_5 = 1113083725;
			int_6 = 1651339366;
		}
		IWidth = width / 8;
		if ((width & 7) != 0)
		{
			IWidth++;
		}
		ILength = height;
		ImageWidth = width;
		ImageLength = height;
		PixelSize = 1f;
		ImageData = new byte[IWidth * ILength];
	}

	public bool GetPixel(int int_7, int int_8)
	{
		if (int_7 >= 0 && int_7 < ImageWidth && int_8 >= 0 && int_8 < ImageLength)
		{
			int num = int_8 * IWidth + (int_7 >> 3);
			int num2 = int_7 & 7;
			return (ImageData[num] & (1 << num2)) != 0;
		}
		return false;
	}

	public void SetPixel(int int_7, int int_8, bool passable)
	{
		int num = int_8 * IWidth + (int_7 >> 3);
		if (num >= 0 && num < ImageData.Length)
		{
			int num2 = int_7 & 7;
			if (passable)
			{
				ImageData[num] |= (byte)(1 << num2);
			}
			else
			{
				ImageData[num] &= (byte)(~(1 << num2));
			}
		}
	}

	public static PwMapRmapFile Load(string filePath)
	{
		return Load(File.ReadAllBytes(filePath));
	}

	public static PwMapRmapFile Load(byte[] data)
	{
		PwMapRmapFile pwMapRmapFile = new PwMapRmapFile();
		MemoryStream memoryStream = new MemoryStream(data);
		try
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			try
			{
				pwMapRmapFile.Version = binaryReader.ReadInt32();
				if (pwMapRmapFile.Version == 1113083725)
				{
					pwMapRmapFile.int_5 = pwMapRmapFile.Version;
					pwMapRmapFile.Version = binaryReader.ReadInt32();
				}
				if (pwMapRmapFile.Version == 1651339366)
				{
					pwMapRmapFile.int_6 = pwMapRmapFile.Version;
					pwMapRmapFile.Version = binaryReader.ReadInt32();
				}
				binaryReader.ReadInt32();
				pwMapRmapFile.IWidth = binaryReader.ReadInt32();
				pwMapRmapFile.ILength = binaryReader.ReadInt32();
				pwMapRmapFile.ImageWidth = binaryReader.ReadInt32();
				pwMapRmapFile.ImageLength = binaryReader.ReadInt32();
				pwMapRmapFile.PixelSize = binaryReader.ReadSingle();
				pwMapRmapFile.ImageData = binaryReader.ReadBytes(pwMapRmapFile.IWidth * pwMapRmapFile.ILength);
				return pwMapRmapFile;
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public void Save(string filePath)
	{
		Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filePath) ?? string.Empty);
		FileStream fileStream = new FileStream(filePath, FileMode.Create);
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			try
			{
				if (Version == 3)
				{
					binaryWriter.Write(int_5);
					binaryWriter.Write(int_6);
				}
				binaryWriter.Write(Version);
				long position = fileStream.Position;
				binaryWriter.Write(0);
				binaryWriter.Write(IWidth);
				binaryWriter.Write(ILength);
				binaryWriter.Write(ImageWidth);
				binaryWriter.Write(ImageLength);
				binaryWriter.Write(PixelSize);
				binaryWriter.Write(ImageData);
				long position2 = fileStream.Position;
				fileStream.Position = position;
				binaryWriter.Write((int)(position2 - position - 4L));
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}
}
