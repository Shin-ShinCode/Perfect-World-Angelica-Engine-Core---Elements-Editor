using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACE.PWMap;

internal sealed class PwMapEcwldCollisionIndex
{
	private readonly struct Struct72(int int_3, int int_4, int int_5)
	{
		public readonly int int_0 = int_3;

		public readonly int int_1 = int_4;

		public readonly int int_2 = int_5;
	}

	public struct OrnamentTransform
	{
		public float PosX;

		public float PosY;

		public float PosZ;

		public float DirX;

		public float DirY;

		public float DirZ;

		public float ScaleX;

		public float ScaleY;

		public float ScaleZ;
	}

	private readonly Dictionary<int, string> dictionary_0 = new Dictionary<int, string>();

	private readonly Dictionary<int, OrnamentTransform> dictionary_1 = new Dictionary<int, OrnamentTransform>();

	private readonly Dictionary<int, HashSet<int>> dictionary_2 = new Dictionary<int, HashSet<int>>();

	private readonly HashSet<int> hashSet_0 = new HashSet<int>();

	public IReadOnlyDictionary<int, string> OrnamentPathByExportId => dictionary_0;

	public IReadOnlyDictionary<int, OrnamentTransform> OrnamentTransformByExportId => dictionary_1;

	public IEnumerable<int> GetAllExportIds()
	{
		return hashSet_0;
	}

	public IEnumerable<int> GetSectorExportIds(int sectorIndex)
	{
		if (!dictionary_2.TryGetValue(sectorIndex, out var value))
		{
			return Array.Empty<int>();
		}
		return value;
	}

	public static PwMapEcwldCollisionIndex Build(string ecwldPath, string ecbsdPath, PwMapTrn2File trn2)
	{
		PwMapEcwldCollisionIndex pwMapEcwldCollisionIndex = new PwMapEcwldCollisionIndex();
		if (trn2 != null && !string.IsNullOrWhiteSpace(ecwldPath) && File.Exists(ecwldPath))
		{
			int int_;
			List<Struct72> list = smethod_0(ecwldPath, ecbsdPath, out int_);
			if (list.Count == 0)
			{
				return pwMapEcwldCollisionIndex;
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			for (int i = 0; i < list.Count; i++)
			{
				Struct72 @struct = list[i];
				if (@struct.int_1 > 0 && @struct.int_2 >= 0 && !dictionary.ContainsKey(@struct.int_1))
				{
					dictionary[@struct.int_1] = @struct.int_2;
				}
			}
			smethod_3(ecbsdPath, int_, dictionary, pwMapEcwldCollisionIndex.dictionary_0, pwMapEcwldCollisionIndex.dictionary_1);
			smethod_4(trn2, list, pwMapEcwldCollisionIndex.dictionary_0, pwMapEcwldCollisionIndex.dictionary_2, pwMapEcwldCollisionIndex.hashSet_0);
			return pwMapEcwldCollisionIndex;
		}
		return pwMapEcwldCollisionIndex;
	}

	private static List<Struct72> smethod_0(string string_0, string string_1, out int int_0)
	{
		int_0 = smethod_8(string_1);
		List<Struct72> list = new List<Struct72>(4096);
		byte[] array;
		try
		{
			array = File.ReadAllBytes(string_0);
		}
		catch
		{
			return list;
		}
		if (array.Length < 128)
		{
			return list;
		}
		MemoryStream memoryStream = new MemoryStream(array, writable: false);
		try
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			try
			{
				if (!smethod_11(binaryReader, 20L))
				{
					return list;
				}
				if (smethod_10(binaryReader, out var _) && smethod_10(binaryReader, out var int_2) && smethod_10(binaryReader, out var _) && smethod_10(binaryReader, out var _) && smethod_10(binaryReader, out var int_5) && smethod_10(binaryReader, out var int_6) && smethod_10(binaryReader, out var _) && smethod_10(binaryReader, out var _) && smethod_10(binaryReader, out var _))
				{
					if (!smethod_11(binaryReader, 60L))
					{
						return list;
					}
					int num = smethod_7(array, 4);
					if (int_2 > 0 && int_2 <= 100000 && smethod_12(binaryReader) >= int_2 * 4L)
					{
						int[] array2 = new int[int_2];
						int num2 = 0;
						while (true)
						{
							if (num2 < int_2)
							{
								if (!smethod_10(binaryReader, out array2[num2]))
								{
									break;
								}
								num2++;
								continue;
							}
							for (int i = 0; i < array2.Length; i++)
							{
								int num3 = array2[i];
								if (num3 < 0 || num3 >= array.Length)
								{
									continue;
								}
								long num4 = smethod_6(num3, array2, int_5, int_6, array.Length);
								if (num4 <= num3 + 32)
								{
									continue;
								}
								memoryStream.Position = num3;
								if (!smethod_11(binaryReader, 4L) || !smethod_10(binaryReader, out var int_10) || !smethod_10(binaryReader, out var int_11) || !smethod_10(binaryReader, out var int_12) || !smethod_10(binaryReader, out var int_13) || !smethod_10(binaryReader, out var int_14) || !smethod_9(int_10, int_11, int_12, int_13, int_14) || (num >= 4 && !smethod_11(binaryReader, 12L)) || (num >= 7 && !smethod_11(binaryReader, 4L)) || (num >= 9 && !smethod_11(binaryReader, 4L)))
								{
									continue;
								}
								long position = binaryReader.BaseStream.Position;
								long long_ = int_10 * 16L + int_12 * 8L + int_11 * 8L + int_13 * 8L + int_14 * 8L;
								long long_2 = position;
								long long_3 = position + 4L;
								long num5 = smethod_1(array, num, int_0, num4, int_10, int_11, int_12, int_13, int_14, long_2, long_3, long_);
								if (num5 < 0L)
								{
									continue;
								}
								long num6 = num5 + int_10 * 16L + int_12 * 8L + int_11 * 8L;
								if (num6 < num3 || num6 + int_13 * 8L > num4)
								{
									continue;
								}
								memoryStream.Position = num6;
								for (int j = 0; j < int_13; j++)
								{
									if (!smethod_10(binaryReader, out var int_15))
									{
										break;
									}
									if (!smethod_10(binaryReader, out var int_16))
									{
										break;
									}
									if (int_15 > 0 && int_16 >= 0)
									{
										list.Add(new Struct72(i, int_15, int_16));
									}
								}
							}
							return list;
						}
						return list;
					}
					return list;
				}
				return list;
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

	private static long smethod_1(byte[] byte_0, int int_0, int int_1, long long_0, int int_2, int int_3, int int_4, int int_5, int int_6, long long_1, long long_2, long long_3)
	{
		bool flag = long_1 + long_3 <= long_0;
		bool flag2 = long_2 + long_3 <= long_0;
		if (!flag && !flag2)
		{
			return -1L;
		}
		if (flag && !flag2)
		{
			return long_1;
		}
		if (!flag && flag2)
		{
			return long_2;
		}
		if (int_0 < 16)
		{
			return long_1;
		}
		int num = smethod_2(byte_0, int_1, long_0, int_2, int_3, int_4, int_5, long_1);
		int num2 = smethod_2(byte_0, int_1, long_0, int_2, int_3, int_4, int_5, long_2);
		if (num2 <= num)
		{
			return long_1;
		}
		return long_2;
	}

	private static int smethod_2(byte[] byte_0, int int_0, long long_0, int int_1, int int_2, int int_3, int int_4, long long_1)
	{
		if (int_4 <= 0)
		{
			return 0;
		}
		long num = long_1 + int_1 * 16L + int_3 * 8L + int_2 * 8L;
		if (num >= 0L && num + 8L <= long_0 && num + 8L <= byte_0.Length)
		{
			int num2 = smethod_7(byte_0, (int)num);
			int num3 = smethod_7(byte_0, (int)num + 4);
			int num4 = 0;
			if (num2 > 0 && num2 < 100000000)
			{
				num4++;
			}
			if (num3 >= 0)
			{
				num4++;
				if (int_0 > 0 && num3 < int_0)
				{
					num4++;
				}
			}
			return num4;
		}
		return 0;
	}

	private static void smethod_3(string string_0, int int_0, Dictionary<int, int> dictionary_3, Dictionary<int, string> dictionary_4, Dictionary<int, OrnamentTransform> dictionary_5)
	{
		if (int_0 <= 0 || string.IsNullOrWhiteSpace(string_0) || !File.Exists(string_0) || dictionary_3.Count == 0)
		{
			return;
		}
		byte[] array;
		try
		{
			array = File.ReadAllBytes(string_0);
		}
		catch
		{
			return;
		}
		Encoding encoding;
		try
		{
			encoding = Encoding.GetEncoding(Class16.smethod_0(1648921191));
		}
		catch
		{
			encoding = Encoding.Default;
		}
		foreach (KeyValuePair<int, int> item in dictionary_3)
		{
			int key = item.Key;
			int value = item.Value;
			if (value < 0 || value + 44 >= array.Length)
			{
				continue;
			}
			int num = value + 40;
			int num2 = smethod_7(array, num);
			int num3 = num + 4;
			if (num2 <= 0 || num2 > 8192 || num3 + num2 > array.Length)
			{
				continue;
			}
			string value2 = encoding.GetString(array, num3, num2).Replace('\\', '/').Trim('\0', ' ', '\t', '\r', '\n');
			if (!string.IsNullOrWhiteSpace(value2))
			{
				dictionary_4[key] = value2;
				if (value + 36 <= array.Length)
				{
					dictionary_5[key] = new OrnamentTransform
					{
						PosX = BitConverter.ToSingle(array, value),
						PosY = BitConverter.ToSingle(array, value + 4),
						PosZ = BitConverter.ToSingle(array, value + 8),
						DirX = BitConverter.ToSingle(array, value + 12),
						DirY = BitConverter.ToSingle(array, value + 16),
						DirZ = BitConverter.ToSingle(array, value + 20),
						ScaleX = BitConverter.ToSingle(array, value + 24),
						ScaleY = BitConverter.ToSingle(array, value + 28),
						ScaleZ = BitConverter.ToSingle(array, value + 32)
					};
				}
			}
		}
	}

	private static void smethod_4(PwMapTrn2File pwMapTrn2File_0, List<Struct72> list_0, IReadOnlyDictionary<int, string> ireadOnlyDictionary_0, Dictionary<int, HashSet<int>> dictionary_3, HashSet<int> hashSet_1)
	{
		int num = Math.Max(1, (int)(pwMapTrn2File_0.Width / (float)Math.Max(1, pwMapTrn2File_0.SectorsWide)));
		int int_ = Math.Max(1, (int)((float)num / Math.Max(1f, pwMapTrn2File_0.BlockSize)));
		for (int i = 0; i < list_0.Count; i++)
		{
			Struct72 @struct = list_0[i];
			if (!ireadOnlyDictionary_0.ContainsKey(@struct.int_1))
			{
				continue;
			}
			hashSet_1.Add(@struct.int_1);
			int num2 = smethod_5(@struct.int_0, pwMapTrn2File_0.BlockWidth, pwMapTrn2File_0.SectorsWide, pwMapTrn2File_0.TotalSectors, int_);
			if (num2 >= 0)
			{
				if (!dictionary_3.TryGetValue(num2, out var value))
				{
					value = (dictionary_3[num2] = new HashSet<int>());
				}
				value.Add(@struct.int_1);
			}
		}
	}

	private static int smethod_5(int int_0, int int_1, int int_2, int int_3, int int_4)
	{
		if (int_0 >= 0 && int_1 > 0 && int_2 > 0 && int_4 > 0)
		{
			int num = int_0 / int_1;
			int num2 = int_0 % int_1;
			int num3 = num2 / int_4;
			int num4 = num / int_4;
			int num5 = num4 * int_2 + num3;
			if (num5 >= 0 && num5 < int_3)
			{
				return num5;
			}
			return -1;
		}
		return -1;
	}

	private static long smethod_6(int int_0, int[] int_1, int int_2, int int_3, int int_4)
	{
		long num = int_4;
		foreach (int num2 in int_1)
		{
			if (num2 > int_0 && num2 < num)
			{
				num = num2;
			}
		}
		if (int_2 > int_0 && int_2 < num)
		{
			num = int_2;
		}
		if (int_3 > int_0 && int_3 < num)
		{
			num = int_3;
		}
		return num;
	}

	private static int smethod_7(byte[] byte_0, int int_0)
	{
		if (int_0 >= 0 && int_0 + 4 <= byte_0.Length)
		{
			return BitConverter.ToInt32(byte_0, int_0);
		}
		return 0;
	}

	private static int smethod_8(string string_0)
	{
		try
		{
			return (int)((!string.IsNullOrWhiteSpace(string_0) && File.Exists(string_0)) ? new FileInfo(string_0).Length : 0);
		}
		catch
		{
			return 0;
		}
	}

	private static bool smethod_9(int int_0, int int_1, int int_2, int int_3, int int_4)
	{
		if (int_0 >= 0 && int_0 < 100000 && int_1 >= 0 && int_1 < 100000 && int_2 >= 0 && int_2 < 100000 && int_3 >= 0 && int_3 < 100000 && int_4 >= 0)
		{
			return int_4 < 100000;
		}
		return false;
	}

	private static bool smethod_10(BinaryReader binaryReader_0, out int int_0)
	{
		int_0 = 0;
		if (smethod_12(binaryReader_0) < 4L)
		{
			return false;
		}
		int_0 = binaryReader_0.ReadInt32();
		return true;
	}

	private static bool smethod_11(BinaryReader binaryReader_0, long long_0)
	{
		if (long_0 >= 0L && smethod_12(binaryReader_0) >= long_0)
		{
			binaryReader_0.BaseStream.Position += long_0;
			return true;
		}
		return false;
	}

	private static long smethod_12(BinaryReader binaryReader_0)
	{
		return binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
	}
}
