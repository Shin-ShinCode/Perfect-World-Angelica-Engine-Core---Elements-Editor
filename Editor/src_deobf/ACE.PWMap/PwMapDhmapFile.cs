using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.PWMap;

public sealed class PwMapDhmapFile
{
	private int int_0 = 1;

	private int int_1;

	private int int_2;

	private int int_3 = 6;

	private int int_4;

	private int int_5;

	private float float_0 = 1f;

	private int int_6;

	private byte[] byte_0;

	private int[] int_7;

	private readonly List<short[]> list_0 = new List<short[]>();

	private short short_0;

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

	public int BlockSizeExp
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

	public int ImageWidth
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

	public int ImageLength
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
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

	public int ITSize
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	public byte[] IVal
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

	public int[] BlockIds
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	public List<short[]> ImageData
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}

	public PwMapDhmapFile()
	{
	}

	public PwMapDhmapFile(int imgWidth, int imgLength, int version = 1)
	{
		Version = version;
		ImageWidth = imgWidth;
		ImageLength = imgLength;
		PixelSize = 1f;
		if (version == 2)
		{
			BlockSizeExp = 4;
			ITSize = 2;
			IVal = new byte[2];
		}
		else
		{
			BlockSizeExp = 6;
		}
		IWidth = imgWidth >> BlockSizeExp;
		if ((imgWidth & (method_0() - 1)) != 0)
		{
			IWidth++;
		}
		ILength = imgLength >> BlockSizeExp;
		if ((imgLength & (method_0() - 1)) != 0)
		{
			ILength++;
		}
		BlockIds = new int[IWidth * ILength];
		for (int i = 0; i < BlockIds.Length; i++)
		{
			BlockIds[i] = -1;
		}
	}

	private int method_0()
	{
		return 1 << BlockSizeExp;
	}

	public short GetPixel(int int_8, int int_9)
	{
		if (int_8 >= 0 && int_8 < ImageWidth && int_9 >= 0 && int_9 < ImageLength)
		{
			int num = BlockIds[(int_9 >> BlockSizeExp) * IWidth + (int_8 >> BlockSizeExp)];
			if (num >= 0 && num < ImageData.Count)
			{
				int num2 = ((int_9 & (method_0() - 1)) << BlockSizeExp) + (int_8 & (method_0() - 1));
				return ImageData[num][num2];
			}
			return short_0;
		}
		return short_0;
	}

	public void SetPixel(int int_8, int int_9, short val)
	{
		int num = int_8 >> BlockSizeExp;
		int num2 = int_9 >> BlockSizeExp;
		int num3 = num2 * IWidth + num;
		if (num3 < 0 || num3 >= BlockIds.Length)
		{
			return;
		}
		int num4 = BlockIds[num3];
		if (num4 == -1)
		{
			if (val == short_0)
			{
				return;
			}
			int num5 = method_0() * method_0();
			short[] array = new short[num5];
			if (short_0 != 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = short_0;
				}
			}
			array[((int_9 & (method_0() - 1)) << BlockSizeExp) + (int_8 & (method_0() - 1))] = val;
			ImageData.Add(array);
			BlockIds[num3] = ImageData.Count - 1;
		}
		else
		{
			int num6 = ((int_9 & (method_0() - 1)) << BlockSizeExp) + (int_8 & (method_0() - 1));
			ImageData[num4][num6] = val;
		}
	}

	public static PwMapDhmapFile Load(string filePath)
	{
		byte[] data = File.ReadAllBytes(filePath);
		return Load(data);
	}

	public static PwMapDhmapFile Load(byte[] data)
	{
		PwMapDhmapFile pwMapDhmapFile = new PwMapDhmapFile();
		MemoryStream memoryStream = new MemoryStream(data);
		try
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			try
			{
				pwMapDhmapFile.Version = binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				if (pwMapDhmapFile.Version == 2)
				{
					pwMapDhmapFile.ITSize = binaryReader.ReadInt32();
					pwMapDhmapFile.IVal = binaryReader.ReadBytes(pwMapDhmapFile.ITSize);
				}
				pwMapDhmapFile.IWidth = binaryReader.ReadInt32();
				pwMapDhmapFile.ILength = binaryReader.ReadInt32();
				pwMapDhmapFile.BlockSizeExp = binaryReader.ReadInt32();
				pwMapDhmapFile.ImageWidth = binaryReader.ReadInt32();
				pwMapDhmapFile.ImageLength = binaryReader.ReadInt32();
				pwMapDhmapFile.PixelSize = binaryReader.ReadSingle();
				int num = 0;
				if (pwMapDhmapFile.Version == 2 && binaryReader.ReadInt32() == 0)
				{
					num = pwMapDhmapFile.IWidth * pwMapDhmapFile.ILength;
				}
				int num2 = pwMapDhmapFile.method_0();
				if (pwMapDhmapFile.Version == 2 && pwMapDhmapFile.ITSize == 2 && pwMapDhmapFile.IVal != null)
				{
					pwMapDhmapFile.short_0 = BitConverter.ToInt16(pwMapDhmapFile.IVal, 0);
				}
				pwMapDhmapFile.BlockIds = new int[pwMapDhmapFile.IWidth * pwMapDhmapFile.ILength];
				int num3 = 0;
				for (int i = 0; i < pwMapDhmapFile.BlockIds.Length; i++)
				{
					pwMapDhmapFile.BlockIds[i] = binaryReader.ReadInt32();
					if (pwMapDhmapFile.BlockIds[i] != -1)
					{
						num3++;
					}
				}
				int num4 = ((pwMapDhmapFile.Version < 2) ? binaryReader.ReadInt32() : num3);
				int num5 = num2 * num2;
				for (int j = 0; j < num4; j++)
				{
					short[] array = new short[num5];
					for (int k = 0; k < num5; k++)
					{
						array[k] = binaryReader.ReadInt16();
					}
					pwMapDhmapFile.ImageData.Add(array);
				}
				return pwMapDhmapFile;
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
				binaryWriter.Write(Version);
				long position = fileStream.Position;
				binaryWriter.Write(0);
				if (Version == 2)
				{
					binaryWriter.Write(ITSize);
					binaryWriter.Write(IVal ?? new byte[ITSize]);
				}
				binaryWriter.Write(IWidth);
				binaryWriter.Write(ILength);
				binaryWriter.Write(BlockSizeExp);
				binaryWriter.Write(ImageWidth);
				binaryWriter.Write(ImageLength);
				binaryWriter.Write(PixelSize);
				if (Version == 2)
				{
					binaryWriter.Write(0);
				}
				for (int i = 0; i < BlockIds.Length; i++)
				{
					binaryWriter.Write(BlockIds[i]);
				}
				if (Version < 2)
				{
					binaryWriter.Write(ImageData.Count);
				}
				foreach (short[] imageDatum in ImageData)
				{
					short[] array = imageDatum;
					foreach (short value in array)
					{
						binaryWriter.Write(value);
					}
				}
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
