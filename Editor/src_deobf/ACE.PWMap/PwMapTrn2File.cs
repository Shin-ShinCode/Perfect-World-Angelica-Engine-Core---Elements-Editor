using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACE.PWMap;

internal sealed class PwMapTrn2File
{
	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private string string_2 = string.Empty;

	private float float_0;

	private float float_1;

	private float float_2;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private float float_3;

	private readonly List<(float, float)> list_0 = new List<(float, float)>();

	private readonly List<string> list_1 = new List<string>();

	private readonly List<string> list_2 = new List<string>();

	public string FilePath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public string MapRootPath
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
	}

	public string MapName
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
	}

	public float Width
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
	}

	public float Height
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
	}

	public float BlockSize
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
	}

	public int BlockGrid
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
	}

	public int NumBlocks
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
	}

	public int BlockHeight
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
	}

	public int BlockWidth
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
	}

	public int DdsCount
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
	}

	public int NumMasks
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
	}

	public int MaskBlocks
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
	}

	public int MaskGrid
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
	}

	public int TotalSectors
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
	}

	public int SectorsHigh
	{
		[CompilerGenerated]
		get
		{
			return int_9;
		}
	}

	public int SectorsWide
	{
		[CompilerGenerated]
		get
		{
			return int_10;
		}
	}

	public int SubTrnGrid
	{
		[CompilerGenerated]
		get
		{
			return int_11;
		}
	}

	public float GridSize
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
	}

	public List<(float Min, float Max)> SectorHeights
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}

	public List<string> DdsFiles
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
	}

	public List<string> MapSectors
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
	}

	private PwMapTrn2File()
	{
	}

	private void method_0(string string_3)
	{
		string_0 = string_3;
	}

	private void method_1(string string_3)
	{
		string_1 = string_3;
	}

	private void method_2(string string_3)
	{
		string_2 = string_3;
	}

	private void method_3(float float_4)
	{
		float_0 = float_4;
	}

	private void method_4(float float_4)
	{
		float_1 = float_4;
	}

	private void method_5(float float_4)
	{
		float_2 = float_4;
	}

	private void method_6(int int_12)
	{
		int_0 = int_12;
	}

	private void method_7(int int_12)
	{
		int_1 = int_12;
	}

	private void method_8(int int_12)
	{
		int_2 = int_12;
	}

	private void method_9(int int_12)
	{
		int_3 = int_12;
	}

	private void method_10(int int_12)
	{
		int_4 = int_12;
	}

	private void method_11(int int_12)
	{
		int_5 = int_12;
	}

	private void method_12(int int_12)
	{
		int_6 = int_12;
	}

	private void method_13(int int_12)
	{
		int_7 = int_12;
	}

	private void method_14(int int_12)
	{
		int_8 = int_12;
	}

	private void method_15(int int_12)
	{
		int_9 = int_12;
	}

	private void method_16(int int_12)
	{
		int_10 = int_12;
	}

	private void method_17(int int_12)
	{
		int_11 = int_12;
	}

	private void method_18(float float_4)
	{
		float_3 = float_4;
	}

	public static PwMapTrn2File Load(string filePath)
	{
		if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
		{
			PwMapTrn2File pwMapTrn2File = new PwMapTrn2File();
			pwMapTrn2File.method_0(filePath);
			pwMapTrn2File.method_1(System.IO.Path.GetDirectoryName(filePath) ?? string.Empty);
			pwMapTrn2File.method_2(System.IO.Path.GetFileNameWithoutExtension(filePath) ?? string.Empty);
			Encoding encoding;
			try
			{
				encoding = Encoding.GetEncoding(Class16.smethod_0(1648921191));
			}
			catch
			{
				encoding = Encoding.Default;
			}
			using FileStream fileStream = File.OpenRead(filePath);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			try
			{
				binaryReader.ReadBytes(4);
				binaryReader.ReadInt32();
				pwMapTrn2File.method_3(binaryReader.ReadSingle());
				pwMapTrn2File.method_4(binaryReader.ReadSingle());
				pwMapTrn2File.method_5(binaryReader.ReadSingle());
				pwMapTrn2File.method_6(binaryReader.ReadInt32());
				pwMapTrn2File.method_7(binaryReader.ReadInt32());
				pwMapTrn2File.method_8(binaryReader.ReadInt32());
				pwMapTrn2File.method_9(binaryReader.ReadInt32());
				pwMapTrn2File.method_10(binaryReader.ReadInt32());
				pwMapTrn2File.method_11(binaryReader.ReadInt32());
				pwMapTrn2File.method_12(binaryReader.ReadInt32());
				pwMapTrn2File.method_13(binaryReader.ReadInt32());
				pwMapTrn2File.method_14(binaryReader.ReadInt32());
				pwMapTrn2File.method_15(binaryReader.ReadInt32());
				pwMapTrn2File.method_16(binaryReader.ReadInt32());
				pwMapTrn2File.method_17(binaryReader.ReadInt32());
				pwMapTrn2File.method_18(binaryReader.ReadSingle());
				binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				binaryReader.ReadBytes(56);
				for (int i = 0; i < pwMapTrn2File.TotalSectors; i++)
				{
					float item = binaryReader.ReadSingle();
					float item2 = binaryReader.ReadSingle();
					pwMapTrn2File.SectorHeights.Add((item, item2));
				}
				for (int j = 0; j < pwMapTrn2File.DdsCount; j++)
				{
					int num = binaryReader.ReadInt32();
					if (num > 0 && num <= fileStream.Length - fileStream.Position)
					{
						string text = encoding.GetString(binaryReader.ReadBytes(num));
						pwMapTrn2File.DdsFiles.Add(text.Replace('\\', System.IO.Path.DirectorySeparatorChar));
					}
					else
					{
						pwMapTrn2File.DdsFiles.Add(string.Empty);
					}
				}
				if (fileStream.Position + 4L <= fileStream.Length)
				{
					binaryReader.ReadInt32();
				}
				for (int k = 0; k < pwMapTrn2File.TotalSectors; k++)
				{
					if (fileStream.Position + 4L > fileStream.Length)
					{
						break;
					}
					int num2 = binaryReader.ReadInt32();
					if (num2 > 0 && num2 <= fileStream.Length - fileStream.Position)
					{
						string item3 = encoding.GetString(binaryReader.ReadBytes(num2));
						pwMapTrn2File.MapSectors.Add(item3);
					}
					else
					{
						pwMapTrn2File.MapSectors.Add(string.Empty);
					}
				}
				return pwMapTrn2File;
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
		return null;
	}
}
