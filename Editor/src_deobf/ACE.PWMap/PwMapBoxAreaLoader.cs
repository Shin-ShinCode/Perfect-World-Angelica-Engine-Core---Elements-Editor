using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACE.PWMap;

internal static class PwMapBoxAreaLoader
{
	internal sealed class BoxAreaRef
	{
		public int BlockIndex;

		public int ExportId;

		public int FileOffset;
	}

	private static Encoding encoding_0;

	public static List<PwMapBoxArea> Load(string ecwldPath, string ecbsdPath)
	{
		List<PwMapBoxArea> list = new List<PwMapBoxArea>();
		if (!string.IsNullOrWhiteSpace(ecwldPath) && File.Exists(ecwldPath) && !string.IsNullOrWhiteSpace(ecbsdPath) && File.Exists(ecbsdPath))
		{
			byte[] byte_;
			byte[] array;
			try
			{
				byte_ = File.ReadAllBytes(ecwldPath);
				array = File.ReadAllBytes(ecbsdPath);
			}
			catch
			{
				return list;
			}
			int num = smethod_0(array);
			if (num < 0)
			{
				return list;
			}
			List<BoxAreaRef> list2 = smethod_1(byte_);
			HashSet<int> hashSet = new HashSet<int>();
			for (int i = 0; i < list2.Count; i++)
			{
				BoxAreaRef boxAreaRef = list2[i];
				if (boxAreaRef.FileOffset >= 0 && boxAreaRef.FileOffset < array.Length && hashSet.Add(boxAreaRef.FileOffset))
				{
					PwMapBoxArea pwMapBoxArea = smethod_5(array, boxAreaRef.FileOffset, num, boxAreaRef.ExportId);
					if (pwMapBoxArea != null)
					{
						list.Add(pwMapBoxArea);
					}
				}
			}
			return list;
		}
		return list;
	}

	private static int smethod_0(byte[] byte_0)
	{
		if (byte_0.Length < 76)
		{
			return -1;
		}
		return BitConverter.ToInt32(byte_0, 8);
	}

	private static List<BoxAreaRef> smethod_1(byte[] byte_0)
	{
		List<BoxAreaRef> list = new List<BoxAreaRef>();
		if (byte_0.Length < 128)
		{
			return list;
		}
		MemoryStream memoryStream = new MemoryStream(byte_0, writable: false);
		try
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			try
			{
				if (smethod_16(binaryReader, 4L) && smethod_14(binaryReader, out var int_))
				{
					if (smethod_16(binaryReader, 12L) && smethod_14(binaryReader, out var _) && smethod_14(binaryReader, out var int_3) && smethod_14(binaryReader, out var _) && smethod_14(binaryReader, out var _) && smethod_14(binaryReader, out var int_6) && smethod_14(binaryReader, out var int_7) && smethod_14(binaryReader, out var _) && smethod_14(binaryReader, out var _) && smethod_14(binaryReader, out var _) && smethod_16(binaryReader, 60L))
					{
						if (int_3 > 0 && int_3 <= 100000 && smethod_17(binaryReader) >= int_3 * 4L)
						{
							int[] array = new int[int_3];
							int num = 0;
							while (true)
							{
								if (num < int_3)
								{
									if (!smethod_14(binaryReader, out array[num]))
									{
										break;
									}
									num++;
									continue;
								}
								for (int i = 0; i < array.Length; i++)
								{
									int num2 = array[i];
									if (num2 < 0 || num2 >= byte_0.Length)
									{
										continue;
									}
									long num3 = smethod_2(num2, array, int_6, int_7, byte_0.Length);
									if (num3 <= num2 + 32)
									{
										continue;
									}
									memoryStream.Position = num2;
									if (!smethod_16(binaryReader, 4L) || !smethod_14(binaryReader, out var int_11) || !smethod_14(binaryReader, out var int_12) || !smethod_14(binaryReader, out var int_13) || !smethod_14(binaryReader, out var int_14) || !smethod_14(binaryReader, out var int_15) || !smethod_4(int_11, int_12, int_13, int_14, int_15) || (int_ >= 4 && !smethod_16(binaryReader, 12L)) || (int_ >= 7 && !smethod_16(binaryReader, 4L)) || (int_ >= 9 && !smethod_16(binaryReader, 4L)))
									{
										continue;
									}
									long num4 = smethod_3(byte_0, num3, int_11, binaryReader.BaseStream.Position, binaryReader.BaseStream.Position + 4L, int_11 * 16L + int_13 * 8L + int_12 * 8L + int_14 * 8L + int_15 * 8L);
									if (num4 < 0L)
									{
										continue;
									}
									long num5 = num4 + int_11 * 16L + int_13 * 8L + int_12 * 8L + int_14 * 8L;
									if (num5 + int_15 * 8L > num3)
									{
										continue;
									}
									memoryStream.Position = num5;
									for (int j = 0; j < int_15; j++)
									{
										if (!smethod_14(binaryReader, out var int_16))
										{
											break;
										}
										if (!smethod_14(binaryReader, out var int_17))
										{
											break;
										}
										list.Add(new BoxAreaRef
										{
											BlockIndex = i,
											ExportId = int_16,
											FileOffset = int_17
										});
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

	private static long smethod_2(int int_0, int[] int_1, int int_2, int int_3, int int_4)
	{
		long num = int_4;
		if (int_2 > int_0 && int_2 < num)
		{
			num = int_2;
		}
		if (int_3 > int_0 && int_3 < num)
		{
			num = int_3;
		}
		for (int i = 0; i < int_1.Length; i++)
		{
			if (int_1[i] > int_0 && int_1[i] < num)
			{
				num = int_1[i];
			}
		}
		return num;
	}

	private static long smethod_3(byte[] byte_0, long long_0, int int_0, long long_1, long long_2, long long_3)
	{
		bool flag = long_1 + long_3 <= long_0;
		bool flag2 = long_2 + long_3 <= long_0;
		if (flag)
		{
			return long_1;
		}
		if (flag2)
		{
			return long_2;
		}
		return -1L;
	}

	private static bool smethod_4(int int_0, int int_1, int int_2, int int_3, int int_4)
	{
		if (int_0 >= 0 && int_0 < 100000 && int_1 >= 0 && int_1 < 100000 && int_2 >= 0 && int_2 < 100000 && int_3 >= 0 && int_3 < 100000 && int_4 >= 0)
		{
			return int_4 < 100000;
		}
		return false;
	}

	private static PwMapBoxArea smethod_5(byte[] byte_0, int int_0, int int_1, int int_2)
	{
		if (int_0 >= 0 && int_0 < byte_0.Length)
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream(byte_0, writable: false);
				try
				{
					memoryStream.Position = int_0;
					BinaryReader binaryReader = new BinaryReader(memoryStream);
					try
					{
						PwMapBoxArea pwMapBoxArea = new PwMapBoxArea
						{
							Version = int_1,
							ExportId = int_2
						};
						if (!smethod_14(binaryReader, out pwMapBoxArea.DefaultArea))
						{
							return null;
						}
						if (int_1 >= 6 && !smethod_14(binaryReader, out pwMapBoxArea.AreaFlags))
						{
							return null;
						}
						if (smethod_15(binaryReader, out pwMapBoxArea.PosX) && smethod_15(binaryReader, out pwMapBoxArea.PosY) && smethod_15(binaryReader, out pwMapBoxArea.PosZ))
						{
							if (smethod_15(binaryReader, out pwMapBoxArea.HalfExtentX) && smethod_15(binaryReader, out pwMapBoxArea.HalfExtentY) && smethod_15(binaryReader, out pwMapBoxArea.HalfExtentZ))
							{
								if (smethod_15(binaryReader, out pwMapBoxArea.AxisXx) && smethod_15(binaryReader, out pwMapBoxArea.AxisXy) && smethod_15(binaryReader, out pwMapBoxArea.AxisXz) && smethod_15(binaryReader, out pwMapBoxArea.AxisYx) && smethod_15(binaryReader, out pwMapBoxArea.AxisYy) && smethod_15(binaryReader, out pwMapBoxArea.AxisYz) && smethod_15(binaryReader, out pwMapBoxArea.AxisZx) && smethod_15(binaryReader, out pwMapBoxArea.AxisZy) && smethod_15(binaryReader, out pwMapBoxArea.AxisZz))
								{
									if (smethod_15(binaryReader, out pwMapBoxArea.FogStart) && smethod_15(binaryReader, out pwMapBoxArea.FogEnd) && smethod_15(binaryReader, out pwMapBoxArea.FogDensity) && smethod_14(binaryReader, out pwMapBoxArea.FogColor))
									{
										if (smethod_15(binaryReader, out pwMapBoxArea.UwFogStart) && smethod_15(binaryReader, out pwMapBoxArea.UwFogEnd) && smethod_15(binaryReader, out pwMapBoxArea.UwFogDensity) && smethod_14(binaryReader, out pwMapBoxArea.UwFogColor))
										{
											if (int_1 < 6)
											{
												return smethod_6(binaryReader, pwMapBoxArea);
											}
											return smethod_7(binaryReader, pwMapBoxArea, int_1);
										}
										return null;
									}
									return null;
								}
								return null;
							}
							return null;
						}
						return null;
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
				return null;
			}
		}
		return null;
	}

	private static PwMapBoxArea smethod_6(BinaryReader binaryReader_0, PwMapBoxArea pwMapBoxArea_0)
	{
		if (smethod_14(binaryReader_0, out pwMapBoxArea_0.Ambient) && smethod_14(binaryReader_0, out pwMapBoxArea_0.DirLtCol) && smethod_15(binaryReader_0, out pwMapBoxArea_0.SkySpeedX) && smethod_15(binaryReader_0, out pwMapBoxArea_0.SkySpeedY) && smethod_14(binaryReader_0, out pwMapBoxArea_0.TrnLtScale) && smethod_14(binaryReader_0, out pwMapBoxArea_0.TransTime))
		{
			smethod_10(binaryReader_0, pwMapBoxArea_0);
			return pwMapBoxArea_0;
		}
		return null;
	}

	private static PwMapBoxArea smethod_7(BinaryReader binaryReader_0, PwMapBoxArea pwMapBoxArea_0, int int_0)
	{
		if (smethod_15(binaryReader_0, out pwMapBoxArea_0.FogStartNight) && smethod_15(binaryReader_0, out pwMapBoxArea_0.FogEndNight) && smethod_15(binaryReader_0, out pwMapBoxArea_0.FogDensityNight) && smethod_14(binaryReader_0, out pwMapBoxArea_0.FogColorNight))
		{
			if (smethod_15(binaryReader_0, out pwMapBoxArea_0.LightDirX) && smethod_15(binaryReader_0, out pwMapBoxArea_0.LightDirY) && smethod_15(binaryReader_0, out pwMapBoxArea_0.LightDirZ))
			{
				if (smethod_14(binaryReader_0, out pwMapBoxArea_0.Ambient) && smethod_14(binaryReader_0, out pwMapBoxArea_0.DirLtCol) && smethod_14(binaryReader_0, out pwMapBoxArea_0.AmbientNight) && smethod_14(binaryReader_0, out pwMapBoxArea_0.DirLtColNight))
				{
					if (smethod_15(binaryReader_0, out pwMapBoxArea_0.SkySpeedX) && smethod_15(binaryReader_0, out pwMapBoxArea_0.SkySpeedY))
					{
						if (smethod_14(binaryReader_0, out pwMapBoxArea_0.TrnLtScale) && smethod_14(binaryReader_0, out pwMapBoxArea_0.TransTime))
						{
							if (smethod_14(binaryReader_0, out pwMapBoxArea_0.RainSpeed) && smethod_15(binaryReader_0, out pwMapBoxArea_0.RainSize) && smethod_14(binaryReader_0, out pwMapBoxArea_0.RainColor) && smethod_14(binaryReader_0, out pwMapBoxArea_0.SnowSpeed) && smethod_15(binaryReader_0, out pwMapBoxArea_0.SnowSize) && smethod_14(binaryReader_0, out pwMapBoxArea_0.SnowColor))
							{
								if (int_0 >= 8 && (!smethod_15(binaryReader_0, out pwMapBoxArea_0.SunPower) || !smethod_15(binaryReader_0, out pwMapBoxArea_0.SunPowerNight)))
								{
									return null;
								}
								if (int_0 >= 9 && (!smethod_14(binaryReader_0, out pwMapBoxArea_0.CloudAmb) || !smethod_14(binaryReader_0, out pwMapBoxArea_0.CloudDir)))
								{
									return null;
								}
								if (int_0 >= 10 && (!smethod_14(binaryReader_0, out pwMapBoxArea_0.CloudAmbNight) || !smethod_14(binaryReader_0, out pwMapBoxArea_0.CloudDirNight)))
								{
									return null;
								}
								if (int_0 >= 11 && (!smethod_15(binaryReader_0, out pwMapBoxArea_0.UwFogStartNight) || !smethod_15(binaryReader_0, out pwMapBoxArea_0.UwFogEndNight) || !smethod_15(binaryReader_0, out pwMapBoxArea_0.UwFogDensityNight) || !smethod_14(binaryReader_0, out pwMapBoxArea_0.UwFogColorNight)))
								{
									return null;
								}
								if (int_0 >= 14)
								{
									if (!smethod_8(binaryReader_0, out pwMapBoxArea_0.TmBornYear, out pwMapBoxArea_0.TmBornMonth, out pwMapBoxArea_0.TmBornWeek, out pwMapBoxArea_0.TmBornDay, out pwMapBoxArea_0.TmBornHour, out pwMapBoxArea_0.TmBornMinute))
									{
										return null;
									}
									if (!smethod_8(binaryReader_0, out pwMapBoxArea_0.TmDieYear, out pwMapBoxArea_0.TmDieMonth, out pwMapBoxArea_0.TmDieWeek, out pwMapBoxArea_0.TmDieDay, out pwMapBoxArea_0.TmDieHour, out pwMapBoxArea_0.TmDieMinute))
									{
										return null;
									}
								}
								if (int_0 >= 15 && (!smethod_15(binaryReader_0, out pwMapBoxArea_0.CapTileSpeed) || !smethod_15(binaryReader_0, out pwMapBoxArea_0.CapRotSpeed)))
								{
									return null;
								}
								if (int_0 == 17 && !smethod_9(binaryReader_0, pwMapBoxArea_0))
								{
									return null;
								}
								smethod_10(binaryReader_0, pwMapBoxArea_0);
								smethod_11(binaryReader_0, pwMapBoxArea_0, int_0);
								return pwMapBoxArea_0;
							}
							return null;
						}
						return null;
					}
					return null;
				}
				return null;
			}
			return null;
		}
		return null;
	}

	private static bool smethod_8(BinaryReader binaryReader_0, out int int_0, out int int_1, out int int_2, out int int_3, out int int_4, out int int_5)
	{
		int_5 = 0;
		int_4 = 0;
		int_3 = 0;
		int_2 = 0;
		int_1 = 0;
		int_0 = 0;
		if (smethod_14(binaryReader_0, out int_0) && smethod_14(binaryReader_0, out int_1) && smethod_14(binaryReader_0, out int_2) && smethod_14(binaryReader_0, out int_3) && smethod_14(binaryReader_0, out int_4))
		{
			return smethod_14(binaryReader_0, out int_5);
		}
		return false;
	}

	private static bool smethod_9(BinaryReader binaryReader_0, PwMapBoxArea pwMapBoxArea_0)
	{
		if (!smethod_14(binaryReader_0, out pwMapBoxArea_0.Priority))
		{
			return false;
		}
		if (smethod_15(binaryReader_0, out pwMapBoxArea_0.GlbFogHeightStart) && smethod_15(binaryReader_0, out pwMapBoxArea_0.GlbFogHeightEnd) && smethod_15(binaryReader_0, out pwMapBoxArea_0.GlbFogDensityStart) && smethod_15(binaryReader_0, out pwMapBoxArea_0.GlbFogDensityEnd))
		{
			if (smethod_15(binaryReader_0, out pwMapBoxArea_0.GlbFogHeightStartNight) && smethod_15(binaryReader_0, out pwMapBoxArea_0.GlbFogHeightEndNight) && smethod_15(binaryReader_0, out pwMapBoxArea_0.GlbFogDensityStartNight) && smethod_15(binaryReader_0, out pwMapBoxArea_0.GlbFogDensityEndNight))
			{
				if (smethod_14(binaryReader_0, out pwMapBoxArea_0.FogColor2) && smethod_15(binaryReader_0, out pwMapBoxArea_0.FogColorDensityStart) && smethod_15(binaryReader_0, out pwMapBoxArea_0.FogColorDensityEnd) && smethod_15(binaryReader_0, out pwMapBoxArea_0.FogHorzeDensity) && smethod_15(binaryReader_0, out pwMapBoxArea_0.FogHorzePower))
				{
					if (smethod_14(binaryReader_0, out pwMapBoxArea_0.FogColor2Night) && smethod_15(binaryReader_0, out pwMapBoxArea_0.FogColorDensityStartNight) && smethod_15(binaryReader_0, out pwMapBoxArea_0.FogColorDensityEndNight) && smethod_15(binaryReader_0, out pwMapBoxArea_0.FogHorzeDensityNight) && smethod_15(binaryReader_0, out pwMapBoxArea_0.FogHorzePowerNight))
					{
						if (smethod_14(binaryReader_0, out pwMapBoxArea_0.Ambient2) && smethod_14(binaryReader_0, out pwMapBoxArea_0.Ambient2Night))
						{
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private static void smethod_10(BinaryReader binaryReader_0, PwMapBoxArea pwMapBoxArea_0)
	{
		pwMapBoxArea_0.SkyFile0 = smethod_12(binaryReader_0);
		pwMapBoxArea_0.SkyFile1 = smethod_12(binaryReader_0);
		pwMapBoxArea_0.SkyFile2 = smethod_12(binaryReader_0);
		pwMapBoxArea_0.SkyFile0Night = smethod_12(binaryReader_0);
		pwMapBoxArea_0.SkyFile1Night = smethod_12(binaryReader_0);
		pwMapBoxArea_0.SkyFile2Night = smethod_12(binaryReader_0);
		pwMapBoxArea_0.MusicFile = smethod_12(binaryReader_0);
	}

	private static void smethod_11(BinaryReader binaryReader_0, PwMapBoxArea pwMapBoxArea_0, int int_0)
	{
		if (int_0 >= 15 && smethod_17(binaryReader_0) >= 4L && smethod_14(binaryReader_0, out pwMapBoxArea_0.SkyType))
		{
			pwMapBoxArea_0.SkyTop = smethod_12(binaryReader_0);
			pwMapBoxArea_0.SkyBottom = smethod_12(binaryReader_0);
			pwMapBoxArea_0.SkyLeft = smethod_12(binaryReader_0);
			pwMapBoxArea_0.SkyRight = smethod_12(binaryReader_0);
			pwMapBoxArea_0.SkyFront = smethod_12(binaryReader_0);
			pwMapBoxArea_0.SkyBack = smethod_12(binaryReader_0);
			pwMapBoxArea_0.SkyNightTop = smethod_12(binaryReader_0);
			pwMapBoxArea_0.SkyNightBottom = smethod_12(binaryReader_0);
			pwMapBoxArea_0.SkyNightLeft = smethod_12(binaryReader_0);
			pwMapBoxArea_0.SkyNightRight = smethod_12(binaryReader_0);
			pwMapBoxArea_0.SkyNightFront = smethod_12(binaryReader_0);
			pwMapBoxArea_0.SkyNightBack = smethod_12(binaryReader_0);
			if (int_0 > 15 && smethod_17(binaryReader_0) >= 4L)
			{
				pwMapBoxArea_0.ColorMappingTex = smethod_12(binaryReader_0);
			}
		}
	}

	private static string smethod_12(BinaryReader binaryReader_0)
	{
		if (smethod_17(binaryReader_0) < 4L)
		{
			return string.Empty;
		}
		int num = binaryReader_0.ReadInt32();
		if (num > 0 && num <= 16384 && smethod_17(binaryReader_0) >= num)
		{
			byte[] bytes = binaryReader_0.ReadBytes(num);
			return smethod_13().GetString(bytes).TrimEnd(default(char));
		}
		return string.Empty;
	}

	private static Encoding smethod_13()
	{
		if (encoding_0 != null)
		{
			return encoding_0;
		}
		try
		{
			encoding_0 = Encoding.GetEncoding(Class16.smethod_0(1648921191));
		}
		catch
		{
			encoding_0 = Encoding.Default;
		}
		return encoding_0;
	}

	private static bool smethod_14(BinaryReader binaryReader_0, out int int_0)
	{
		int_0 = 0;
		if (smethod_17(binaryReader_0) < 4L)
		{
			return false;
		}
		int_0 = binaryReader_0.ReadInt32();
		return true;
	}

	private static bool smethod_15(BinaryReader binaryReader_0, out float float_0)
	{
		float_0 = 0f;
		if (smethod_17(binaryReader_0) < 4L)
		{
			return false;
		}
		float_0 = binaryReader_0.ReadSingle();
		return true;
	}

	private static bool smethod_16(BinaryReader binaryReader_0, long long_0)
	{
		if (long_0 >= 0L && smethod_17(binaryReader_0) >= long_0)
		{
			binaryReader_0.BaseStream.Position += long_0;
			return true;
		}
		return false;
	}

	private static long smethod_17(BinaryReader binaryReader_0)
	{
		return binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
	}
}
