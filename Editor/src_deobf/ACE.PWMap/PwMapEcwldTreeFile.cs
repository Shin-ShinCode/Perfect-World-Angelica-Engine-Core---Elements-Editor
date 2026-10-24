using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using SharpDX;

namespace ACE.PWMap;

internal static class PwMapEcwldTreeFile
{
	internal sealed class SceneData
	{
		private readonly List<TreeInstance> list_0 = new List<TreeInstance>(8192);

		private readonly List<TreeTypeInfo> list_1 = new List<TreeTypeInfo>(256);

		public List<TreeInstance> TreeInstances
		{
			[CompilerGenerated]
			get
			{
				return list_0;
			}
		}

		public List<TreeTypeInfo> TreeTypes
		{
			[CompilerGenerated]
			get
			{
				return list_1;
			}
		}
	}

	internal sealed class TreeInstance
	{
		public int Type;

		public Vector3 Position;
	}

	internal sealed class TreeTypeInfo
	{
		public int Index;

		public string SptFile = string.Empty;

		public string DdsFile = string.Empty;
	}

	public static List<Vector3> LoadTreePositions(string ecwldPath)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		SceneData sceneData = LoadSceneData(ecwldPath);
		List<Vector3> list = new List<Vector3>(sceneData.TreeInstances.Count);
		for (int i = 0; i < sceneData.TreeInstances.Count; i++)
		{
			list.Add(sceneData.TreeInstances[i].Position);
		}
		return list;
	}

	public static SceneData LoadSceneData(string ecwldPath)
	{
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		SceneData sceneData = new SceneData();
		if (!string.IsNullOrWhiteSpace(ecwldPath) && File.Exists(ecwldPath))
		{
			byte[] array;
			try
			{
				array = File.ReadAllBytes(ecwldPath);
			}
			catch
			{
				return sceneData;
			}
			if (array.Length < 128)
			{
				return sceneData;
			}
			MemoryStream memoryStream = new MemoryStream(array, writable: false);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					if (smethod_9(binaryReader, 4L) && smethod_7(binaryReader, out var int_))
					{
						if (smethod_9(binaryReader, 12L) && smethod_7(binaryReader, out var _) && smethod_7(binaryReader, out var int_3) && smethod_7(binaryReader, out var _) && smethod_7(binaryReader, out var _) && smethod_7(binaryReader, out var int_6) && smethod_7(binaryReader, out var int_7) && smethod_7(binaryReader, out var int_8) && smethod_7(binaryReader, out var _) && smethod_7(binaryReader, out var _) && smethod_9(binaryReader, 60L))
						{
							if (int_3 > 0 && int_3 <= 100000 && smethod_10(binaryReader) >= int_3 * 4L)
							{
								int[] array2 = new int[int_3];
								int num = 0;
								while (true)
								{
									if (num < int_3)
									{
										if (!smethod_7(binaryReader, out array2[num]))
										{
											break;
										}
										num++;
										continue;
									}
									foreach (int num2 in array2)
									{
										if (num2 < 0 || num2 >= array.Length)
										{
											continue;
										}
										long num3 = smethod_5(num2, array2, int_6, int_7, array.Length);
										if (num3 <= num2 + 32)
										{
											continue;
										}
										memoryStream.Position = num2;
										if (!smethod_9(binaryReader, 4L) || !smethod_7(binaryReader, out var int_11) || !smethod_7(binaryReader, out var int_12) || !smethod_7(binaryReader, out var int_13) || !smethod_7(binaryReader, out var int_14) || !smethod_7(binaryReader, out var int_15) || !smethod_6(int_11, int_12, int_13, int_14, int_15) || (int_ >= 4 && !smethod_9(binaryReader, 12L)) || (int_ >= 7 && !smethod_9(binaryReader, 4L)) || (int_ >= 9 && !smethod_9(binaryReader, 4L)))
										{
											continue;
										}
										long position = binaryReader.BaseStream.Position;
										long long_ = position + 4L;
										long long_2 = int_11 * 16L + int_13 * 8L + int_12 * 8L + int_14 * 8L + int_15 * 8L;
										long num4 = smethod_3(array, num3, int_11, position, long_, long_2);
										if (num4 < 0L)
										{
											continue;
										}
										memoryStream.Position = num4;
										for (int j = 0; j < int_11; j++)
										{
											if (!smethod_7(binaryReader, out var int_16))
											{
												break;
											}
											if (!smethod_8(binaryReader, out var float_))
											{
												break;
											}
											if (!smethod_8(binaryReader, out var float_2))
											{
												break;
											}
											if (!smethod_8(binaryReader, out var float_3))
											{
												break;
											}
											if (!float.IsNaN(float_) && !float.IsNaN(float_2) && !float.IsNaN(float_3) && !float.IsInfinity(float_) && !float.IsInfinity(float_2) && !float.IsInfinity(float_3))
											{
												sceneData.TreeInstances.Add(new TreeInstance
												{
													Type = int_16,
													Position = new Vector3(float_, float_2, 0f - float_3)
												});
											}
										}
									}
									smethod_0(array, int_6, int_8, sceneData.TreeTypes);
									return sceneData;
								}
								return sceneData;
							}
							return sceneData;
						}
						return sceneData;
					}
					return sceneData;
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
		return sceneData;
	}

	private static void smethod_0(byte[] byte_0, int int_0, int int_1, List<TreeTypeInfo> list_0)
	{
		if (int_0 <= 0 || int_1 <= 0 || int_0 >= byte_0.Length)
		{
			return;
		}
		MemoryStream memoryStream = new MemoryStream(byte_0, writable: false);
		try
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			try
			{
				memoryStream.Position = int_0;
				Encoding encoding_ = smethod_1();
				for (int i = 0; i < int_1; i++)
				{
					if (!smethod_7(binaryReader, out var int_2))
					{
						break;
					}
					if (int_2 < 0)
					{
						break;
					}
					if (int_2 > 32768)
					{
						break;
					}
					if (smethod_10(binaryReader) < int_2)
					{
						break;
					}
					byte[] array = binaryReader.ReadBytes(int_2);
					if (array.Length == int_2 && smethod_7(binaryReader, out var int_3) && int_3 >= 0 && int_3 <= 32768 && smethod_10(binaryReader) >= int_3)
					{
						byte[] array2 = binaryReader.ReadBytes(int_3);
						if (array2.Length != int_3)
						{
							break;
						}
						list_0.Add(new TreeTypeInfo
						{
							Index = i,
							SptFile = smethod_2(encoding_, array),
							DdsFile = smethod_2(encoding_, array2)
						});
						continue;
					}
					break;
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

	private static Encoding smethod_1()
	{
		try
		{
			return Encoding.GetEncoding(Class16.smethod_0(1648921191));
		}
		catch
		{
			return Encoding.Default;
		}
	}

	private static string smethod_2(Encoding encoding_0, byte[] byte_0)
	{
		if (byte_0 != null && byte_0.Length != 0)
		{
			return encoding_0.GetString(byte_0).Replace('\0', ' ').Trim();
		}
		return string.Empty;
	}

	private static long smethod_3(byte[] byte_0, long long_0, int int_0, long long_1, long long_2, long long_3)
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
		if (int_0 <= 0)
		{
			return long_1;
		}
		int num = smethod_4(byte_0, (int)long_1);
		int num2 = smethod_4(byte_0, (int)long_2);
		if (num2 <= num)
		{
			return long_1;
		}
		return long_2;
	}

	private static int smethod_4(byte[] byte_0, int int_0)
	{
		if (int_0 >= 0 && int_0 + 16 <= byte_0.Length)
		{
			int num = BitConverter.ToInt32(byte_0, int_0);
			float num2 = BitConverter.ToSingle(byte_0, int_0 + 4);
			float num3 = BitConverter.ToSingle(byte_0, int_0 + 8);
			float num4 = BitConverter.ToSingle(byte_0, int_0 + 12);
			int num5 = 0;
			if (num >= 0 && num < 1000000)
			{
				num5++;
			}
			if (Math.Abs(num2) < 500000f && Math.Abs(num3) < 500000f && Math.Abs(num4) < 500000f)
			{
				num5++;
			}
			if (!float.IsNaN(num2) && !float.IsNaN(num3) && !float.IsNaN(num4))
			{
				num5++;
			}
			return num5;
		}
		return 0;
	}

	private static long smethod_5(int int_0, int[] int_1, int int_2, int int_3, int int_4)
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

	private static bool smethod_6(int int_0, int int_1, int int_2, int int_3, int int_4)
	{
		if (int_0 >= 0 && int_0 < 100000 && int_1 >= 0 && int_1 < 100000 && int_2 >= 0 && int_2 < 100000 && int_3 >= 0 && int_3 < 100000 && int_4 >= 0)
		{
			return int_4 < 100000;
		}
		return false;
	}

	private static bool smethod_7(BinaryReader binaryReader_0, out int int_0)
	{
		int_0 = 0;
		if (smethod_10(binaryReader_0) < 4L)
		{
			return false;
		}
		int_0 = binaryReader_0.ReadInt32();
		return true;
	}

	private static bool smethod_8(BinaryReader binaryReader_0, out float float_0)
	{
		float_0 = 0f;
		if (smethod_10(binaryReader_0) < 4L)
		{
			return false;
		}
		float_0 = binaryReader_0.ReadSingle();
		return true;
	}

	private static bool smethod_9(BinaryReader binaryReader_0, long long_0)
	{
		if (long_0 >= 0L && smethod_10(binaryReader_0) >= long_0)
		{
			binaryReader_0.BaseStream.Position += long_0;
			return true;
		}
		return false;
	}

	private static long smethod_10(BinaryReader binaryReader_0)
	{
		return binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
	}
}
