using System;
using System.Collections.Generic;
using System.IO;

namespace ACE.PWMap;

internal sealed class PwMapBsdataFile
{
	internal sealed class WaterBlockEntry
	{
		public int Version;

		public int AreaId;

		public int WaterColor = -11564899;

		public float WaterHeight;

		public int EdgeSize;

		public int Width;

		public int Height;

		public float GridSize;

		public float WorldX;

		public float WorldY;

		public float WorldZ;

		public byte[] AboveGround = Array.Empty<byte>();
	}

	private readonly List<WaterBlockEntry> list_0 = new List<WaterBlockEntry>();

	public IReadOnlyList<WaterBlockEntry> WaterBlocks => list_0;

	private PwMapBsdataFile()
	{
	}

	public static PwMapBsdataFile Load(string filePath)
	{
		if (string.IsNullOrWhiteSpace(filePath))
		{
			return null;
		}
		byte[] array = PwMapAssetProvider.ReadFileOrPckBytes(filePath);
		if (array == null)
		{
			return null;
		}
		if (array.Length < 20)
		{
			return null;
		}
		PwMapBsdataFile pwMapBsdataFile = new PwMapBsdataFile();
		try
		{
			MemoryStream memoryStream = new MemoryStream(array, writable: false);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					if (!smethod_3(binaryReader, out var _) || !smethod_3(binaryReader, out var int_2))
					{
						return pwMapBsdataFile;
					}
					if (int_2 >= 2 && !smethod_3(binaryReader, out var _))
					{
						return pwMapBsdataFile;
					}
					memoryStream.Position = memoryStream.Length - 4L;
					if (!smethod_3(binaryReader, out var int_4) || int_4 <= 0 || int_4 > 200000)
					{
						return pwMapBsdataFile;
					}
					long num = memoryStream.Length - 4L - int_4 * 4L;
					if (num < 0L || num > memoryStream.Length - 4L)
					{
						return pwMapBsdataFile;
					}
					memoryStream.Position = num;
					int[] array2 = new int[int_4];
					for (int i = 0; i < int_4; i++)
					{
						if (!smethod_3(binaryReader, out array2[i]))
						{
							return pwMapBsdataFile;
						}
					}
					foreach (int num2 in array2)
					{
						if (num2 < 0 || num2 > num - 4L)
						{
							continue;
						}
						memoryStream.Position = num2;
						if (smethod_3(binaryReader, out var int_5) && (int_5 >= 268435456 || int_5 <= 4))
						{
							WaterBlockEntry waterBlockEntry = smethod_0(binaryReader, int_5, num2, num, array2);
							if (waterBlockEntry != null)
							{
								pwMapBsdataFile.list_0.Add(waterBlockEntry);
							}
						}
					}
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
		catch
		{
		}
		return pwMapBsdataFile;
	}

	private static WaterBlockEntry smethod_0(BinaryReader binaryReader_0, int int_0, int int_1, long long_0, int[] int_2)
	{
		try
		{
			long val = smethod_2(int_1, long_0, int_2);
			WaterBlockEntry waterBlockEntry = new WaterBlockEntry
			{
				Version = int_0
			};
			if (!smethod_3(binaryReader_0, out waterBlockEntry.AreaId))
			{
				return null;
			}
			if (int_0 >= 268435456)
			{
				if (int_0 > 268435456 && !smethod_3(binaryReader_0, out waterBlockEntry.WaterColor))
				{
					return null;
				}
				if (!smethod_4(binaryReader_0, out waterBlockEntry.WaterHeight))
				{
					return null;
				}
				if (int_0 >= 268443648 && !smethod_3(binaryReader_0, out waterBlockEntry.EdgeSize))
				{
					return null;
				}
				if (!smethod_3(binaryReader_0, out waterBlockEntry.Width) || !smethod_3(binaryReader_0, out waterBlockEntry.Height) || !smethod_4(binaryReader_0, out waterBlockEntry.GridSize) || !smethod_4(binaryReader_0, out waterBlockEntry.WorldX) || !smethod_4(binaryReader_0, out waterBlockEntry.WorldY) || !smethod_4(binaryReader_0, out waterBlockEntry.WorldZ))
				{
					return null;
				}
				if (int_0 == 268447744 && !smethod_5(binaryReader_0, 1L))
				{
					return null;
				}
				int num = smethod_1(waterBlockEntry.Width, waterBlockEntry.Height);
				if (num > 0)
				{
					waterBlockEntry.AboveGround = binaryReader_0.ReadBytes(num);
					if (waterBlockEntry.AboveGround.Length != num)
					{
						return null;
					}
				}
				if (int_0 > 268435456 && !smethod_3(binaryReader_0, out var _))
				{
					return null;
				}
			}
			else
			{
				if (!smethod_4(binaryReader_0, out waterBlockEntry.WaterHeight) || !smethod_3(binaryReader_0, out waterBlockEntry.EdgeSize) || !smethod_3(binaryReader_0, out waterBlockEntry.Width) || !smethod_3(binaryReader_0, out waterBlockEntry.Height) || !smethod_4(binaryReader_0, out waterBlockEntry.GridSize) || !smethod_4(binaryReader_0, out waterBlockEntry.WorldX) || !smethod_4(binaryReader_0, out waterBlockEntry.WorldY) || !smethod_4(binaryReader_0, out waterBlockEntry.WorldZ))
				{
					return null;
				}
				if (!smethod_3(binaryReader_0, out var _))
				{
					return null;
				}
				if (!smethod_5(binaryReader_0, 24L))
				{
					return null;
				}
				if (int_0 < 2)
				{
					if (!smethod_5(binaryReader_0, 1L))
					{
						return null;
					}
				}
				else if (!smethod_5(binaryReader_0, 8L))
				{
					return null;
				}
				if (!smethod_3(binaryReader_0, out var int_5) || !smethod_5(binaryReader_0, 16L))
				{
					return null;
				}
				waterBlockEntry.WaterColor = int_5;
				if (!smethod_5(binaryReader_0, 4L) || !smethod_5(binaryReader_0, 16L))
				{
					return null;
				}
				if (int_0 >= 4 && !smethod_5(binaryReader_0, 8L))
				{
					return null;
				}
				int num2 = smethod_1(waterBlockEntry.Width, waterBlockEntry.Height);
				if (num2 > 0)
				{
					waterBlockEntry.AboveGround = binaryReader_0.ReadBytes(num2);
					if (waterBlockEntry.AboveGround.Length != num2)
					{
						return null;
					}
				}
			}
			if (waterBlockEntry.Width > 0 && waterBlockEntry.Height > 0 && waterBlockEntry.GridSize > 0f)
			{
				binaryReader_0.BaseStream.Position = Math.Min(val, binaryReader_0.BaseStream.Length);
				return waterBlockEntry;
			}
			return null;
		}
		catch
		{
			return null;
		}
	}

	private static int smethod_1(int int_0, int int_1)
	{
		if (int_0 > 0 && int_1 > 0)
		{
			long num = (long)int_0 * (long)int_1;
			if (num > 0L && num <= 100000000L)
			{
				return (int)num;
			}
			return 0;
		}
		return 0;
	}

	private static long smethod_2(int int_0, long long_0, int[] int_1)
	{
		long num = long_0;
		foreach (int num2 in int_1)
		{
			if (num2 > int_0 && num2 < num)
			{
				num = num2;
			}
		}
		return num;
	}

	private static bool smethod_3(BinaryReader binaryReader_0, out int int_0)
	{
		int_0 = 0;
		if (smethod_6(binaryReader_0) < 4L)
		{
			return false;
		}
		int_0 = binaryReader_0.ReadInt32();
		return true;
	}

	private static bool smethod_4(BinaryReader binaryReader_0, out float float_0)
	{
		float_0 = 0f;
		if (smethod_6(binaryReader_0) < 4L)
		{
			return false;
		}
		float_0 = binaryReader_0.ReadSingle();
		return true;
	}

	private static bool smethod_5(BinaryReader binaryReader_0, long long_0)
	{
		if (long_0 >= 0L && smethod_6(binaryReader_0) >= long_0)
		{
			binaryReader_0.BaseStream.Position += long_0;
			return true;
		}
		return false;
	}

	private static long smethod_6(BinaryReader binaryReader_0)
	{
		return binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
	}
}
