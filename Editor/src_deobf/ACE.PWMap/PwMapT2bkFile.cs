using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ACE.PWMap;

internal sealed class PwMapT2bkFile
{
	private sealed class Class321
	{
		public float[] float_0 = Array.Empty<float>();
	}

	private readonly List<Class321> list_0 = new List<Class321>();

	private readonly int int_0;

	private readonly int int_1;

	private readonly int int_2;

	private readonly int int_3;

	private readonly int int_4;

	private readonly int int_5;

	public int TileSize => int_2;

	public int GridSpacing => int_5;

	public int BlocksWide => int_3;

	public int BlocksHigh => int_4;

	private PwMapT2bkFile(int int_6, int int_7, int int_8, int int_9)
	{
		int_0 = Math.Max(1, int_6 / 2);
		int_1 = Math.Max(1, int_7 / 2);
		int_2 = Math.Max(1, int_8);
		int_3 = Math.Max(1, int_6 / int_2);
		int_4 = Math.Max(1, int_7 / int_2);
		int_5 = Math.Max(1, int_9);
	}

	public List<float[]> GetSubTerrains()
	{
		List<float[]> list = new List<float[]>(list_0.Count);
		foreach (Class321 item in list_0)
		{
			list.Add(item.float_0);
		}
		return list;
	}

	public static PwMapT2bkFile Load(string filePath, int sectorWidth, int sectorHeight, int tileSize, int gridSpacing)
	{
		if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
		{
			PwMapT2bkFile pwMapT2bkFile = new PwMapT2bkFile(sectorWidth, sectorHeight, tileSize, gridSpacing);
			using FileStream fileStream = File.OpenRead(filePath);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			try
			{
				int num = binaryReader.ReadInt32();
				if (num != 1413630786)
				{
					return null;
				}
				int num2 = binaryReader.ReadInt32();
				int num3 = binaryReader.ReadInt32();
				if (num3 > 0 && num3 <= 100000)
				{
					binaryReader.ReadInt32();
					int[] array = new int[num3];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = binaryReader.ReadInt32();
					}
					int num4 = pwMapT2bkFile.int_2 / pwMapT2bkFile.int_5 + 1;
					int int_ = Math.Max(4, num4 * num4);
					for (int j = 0; j < array.Length; j++)
					{
						if (array[j] > 0 && array[j] < fileStream.Length)
						{
							fileStream.Position = array[j];
							try
							{
								binaryReader.ReadInt32();
								binaryReader.ReadInt16();
								binaryReader.ReadInt16();
								binaryReader.ReadSingle();
								binaryReader.ReadInt32();
								if (num2 < 2)
								{
									pwMapT2bkFile.list_0.Add(new Class321());
									continue;
								}
								int int_2;
								if (num2 < 3)
								{
									int_2 = binaryReader.ReadInt32();
									int int_3 = binaryReader.ReadInt32();
									byte[] byte_ = smethod_0(binaryReader, int_2);
									smethod_1(binaryReader, int_3);
									pwMapT2bkFile.list_0.Add(new Class321
									{
										float_0 = smethod_2(byte_, int_)
									});
									continue;
								}
								if (num2 < 4)
								{
									int_2 = binaryReader.ReadInt32();
									int num5 = binaryReader.ReadInt32();
									int num6 = binaryReader.ReadInt32();
									byte[] byte_2 = smethod_0(binaryReader, int_2);
									smethod_1(binaryReader, num5 + num6);
									pwMapT2bkFile.list_0.Add(new Class321
									{
										float_0 = smethod_2(byte_2, int_)
									});
									continue;
								}
								int_2 = binaryReader.ReadInt32();
								int num7 = binaryReader.ReadInt32();
								int num8 = binaryReader.ReadInt32();
								int num9 = binaryReader.ReadInt32();
								if (num2 >= 6)
								{
									binaryReader.ReadInt32();
								}
								byte[] byte_3 = smethod_0(binaryReader, int_2);
								smethod_1(binaryReader, num7 + num8 + num9);
								pwMapT2bkFile.list_0.Add(new Class321
								{
									float_0 = smethod_2(byte_3, int_)
								});
							}
							catch
							{
								pwMapT2bkFile.list_0.Add(new Class321());
							}
						}
						else
						{
							pwMapT2bkFile.list_0.Add(new Class321());
						}
					}
					return pwMapT2bkFile;
				}
				return null;
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
		return null;
	}

	public float GetHeightAtSectorPos(float sectorX, float sectorZ)
	{
		if (!(sectorX > (float)int_0) && !(sectorX < (float)(-int_0)) && !(sectorZ > (float)int_1) && sectorZ >= (float)(-int_1))
		{
			float float_ = (float)int_0 + sectorX;
			float float_2 = (float)int_1 - sectorZ;
			return method_2(float_, float_2);
		}
		return 0f;
	}

	public void ApplySectorHeightMap(float[] heights)
	{
		int num = int_0 + 1;
		int num2 = int_1 + 1;
		if (heights == null || heights.Length < num * num2)
		{
			return;
		}
		int num3 = 0;
		for (int i = 0; i < num2; i++)
		{
			float float_ = int_1 - i;
			for (int j = 0; j < num; j++)
			{
				float float_2 = -int_0 + j;
				method_0(float_2, float_, heights[num3++]);
			}
		}
	}

	public float[] BuildSectorHeightMap()
	{
		int num = int_0 + 1;
		int num2 = int_1 + 1;
		float[] array = new float[num * num2];
		int num3 = 0;
		for (int i = 0; i < num2; i++)
		{
			float sectorZ = int_1 - i;
			for (int j = 0; j < num; j++)
			{
				float sectorX = -int_0 + j;
				array[num3++] = GetHeightAtSectorPos(sectorX, sectorZ);
			}
		}
		return array;
	}

	private void method_0(float float_0, float float_1, float float_2)
	{
		float float_3 = (float)int_0 + float_0;
		float float_4 = (float)int_1 - float_1;
		method_1(float_3, float_4, float_2);
	}

	private void method_1(float float_0, float float_1, float float_2)
	{
		int num = (int)Math.Floor(float_1 / (float)int_2);
		int num2 = (int)Math.Floor(float_0 / (float)int_2);
		int num3 = num * int_3 + num2;
		if (num3 < 0 || num3 >= list_0.Count)
		{
			return;
		}
		float[] float_3 = list_0[num3].float_0;
		if (float_3 != null && float_3.Length >= 4)
		{
			int num4 = int_2 / int_5 + 1;
			int val = (int)Math.Floor(float_0 / (float)int_5) - num2 * (int_2 / int_5);
			int val2 = (int)Math.Floor(float_1 / (float)int_5) - num * (int_2 / int_5);
			val = Math.Max(0, Math.Min(num4 - 1, val));
			val2 = Math.Max(0, Math.Min(num4 - 1, val2));
			int num5 = val2 * num4 + val;
			if (num5 >= 0 && num5 < float_3.Length)
			{
				float_3[num5] = float_2;
			}
		}
	}

	private float method_2(float float_0, float float_1)
	{
		int num = (int)Math.Floor(float_1 / (float)int_2);
		int num2 = (int)Math.Floor(float_0 / (float)int_2);
		int num3 = num * int_3 + num2;
		if (num3 >= 0 && num3 < list_0.Count)
		{
			float[] float_2 = list_0[num3].float_0;
			if (float_2 != null && float_2.Length >= 4)
			{
				int num4 = int_2 / int_5 + 1;
				int val = (int)Math.Floor(float_0 / (float)int_5) - num2 * (int_2 / int_5);
				int val2 = (int)Math.Floor(float_1 / (float)int_5) - num * (int_2 / int_5);
				val = Math.Max(0, Math.Min(num4 - 2, val));
				val2 = Math.Max(0, Math.Min(num4 - 2, val2));
				float num5 = float_0 % (float)int_5 / (float)int_5;
				float num6 = float_1 % (float)int_5 / (float)int_5;
				if (num5 < 0f)
				{
					num5 += 1f;
				}
				if (num6 < 0f)
				{
					num6 += 1f;
				}
				int num7 = val2 * num4 + val;
				if (num7 + num4 + 1 >= float_2.Length)
				{
					return 0f;
				}
				float num8;
				float num9;
				float num10;
				if (num5 < num6)
				{
					num8 = float_2[num7 + num4];
					num9 = float_2[num7 + num4 + 1];
					num10 = float_2[num7];
					num6 = 1f - num6;
				}
				else
				{
					num8 = float_2[num7 + 1];
					num9 = float_2[num7];
					num10 = float_2[num7 + num4 + 1];
					num5 = 1f - num5;
				}
				return num8 + (num9 - num8) * num5 + (num10 - num8) * num6;
			}
			return 0f;
		}
		return 0f;
	}

	private static byte[] smethod_0(BinaryReader binaryReader_0, int int_6)
	{
		if (int_6 <= 0)
		{
			return Array.Empty<byte>();
		}
		long num = binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
		if (int_6 > num)
		{
			return binaryReader_0.ReadBytes((int)num);
		}
		return binaryReader_0.ReadBytes(int_6);
	}

	private static void smethod_1(BinaryReader binaryReader_0, int int_6)
	{
		if (int_6 > 0)
		{
			long val = binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
			long num = Math.Min(int_6, val);
			binaryReader_0.BaseStream.Position += num;
		}
	}

	private static float[] smethod_2(byte[] byte_0, int int_6)
	{
		if (byte_0 != null && byte_0.Length != 0)
		{
			byte[] array = smethod_3(byte_0);
			if (array.Length % 4 == 0 && array.Length >= 4)
			{
				int num = array.Length / 4;
				float[] array2 = new float[num];
				for (int i = 0; i < num; i++)
				{
					array2[i] = BitConverter.ToSingle(array, i * 4);
				}
				return array2;
			}
			return new float[int_6];
		}
		return new float[int_6];
	}

	private static byte[] smethod_3(byte[] byte_0)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_0);
			try
			{
				InflaterInputStream val = new InflaterInputStream((Stream)memoryStream);
				try
				{
					MemoryStream memoryStream2 = new MemoryStream(Math.Max(4096, byte_0.Length * 2));
					try
					{
						((Stream)(object)val).CopyTo((Stream)memoryStream2);
						return memoryStream2.ToArray();
					}
					finally
					{
						((IDisposable)memoryStream2).Dispose();
					}
				}
				finally
				{
					((IDisposable)val).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		catch
		{
			try
			{
				MemoryStream memoryStream3 = new MemoryStream(byte_0);
				try
				{
					DeflateStream deflateStream = new DeflateStream(memoryStream3, CompressionMode.Decompress);
					try
					{
						MemoryStream memoryStream4 = new MemoryStream(Math.Max(4096, byte_0.Length * 2));
						try
						{
							deflateStream.CopyTo(memoryStream4);
							return memoryStream4.ToArray();
						}
						finally
						{
							((IDisposable)memoryStream4).Dispose();
						}
					}
					finally
					{
						((IDisposable)deflateStream).Dispose();
					}
				}
				finally
				{
					((IDisposable)memoryStream3).Dispose();
				}
			}
			catch
			{
				return byte_0;
			}
		}
	}
}
