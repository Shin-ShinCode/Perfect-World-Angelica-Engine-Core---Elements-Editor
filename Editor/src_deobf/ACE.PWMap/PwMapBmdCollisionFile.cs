using System;
using System.Collections.Generic;
using System.IO;
using SharpDX;

namespace ACE.PWMap;

internal static class PwMapBmdCollisionFile
{
	public static List<PwMapCollisionBrush> LoadBrushes(string filePath)
	{
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		List<PwMapCollisionBrush> list = new List<PwMapCollisionBrush>(64);
		if (string.IsNullOrWhiteSpace(filePath))
		{
			return list;
		}
		try
		{
			using Stream stream = smethod_0(filePath);
			if (stream == null)
			{
				return list;
			}
			BinaryReader binaryReader = new BinaryReader(stream);
			try
			{
				if (!smethod_8(binaryReader, 4L))
				{
					return list;
				}
				if (!smethod_5(binaryReader, out var int_))
				{
					return list;
				}
				int int_2;
				if (int_ == -2147483647)
				{
					if (!smethod_8(binaryReader, 1L) || !smethod_5(binaryReader, out int_2))
					{
						return list;
					}
				}
				else
				{
					int_2 = int_;
				}
				if (!smethod_8(binaryReader, 48L))
				{
					return list;
				}
				if (int_2 >= 268436228 && !smethod_8(binaryReader, 4L))
				{
					return list;
				}
				if (smethod_5(binaryReader, out var int_3) && int_3 >= 0 && int_3 <= 20000)
				{
					bool flag = false;
					bool flag2 = false;
					if (int_2 >= 268436224)
					{
						if (!smethod_7(binaryReader, out var byte_) || !smethod_7(binaryReader, out var byte_2))
						{
							return list;
						}
						flag = byte_ != 0;
						flag2 = byte_2 != 0;
					}
					if (flag2)
					{
						return list;
					}
					int num = 0;
					while (true)
					{
						if (num < int_3)
						{
							if (smethod_1(binaryReader, int_2))
							{
								num++;
								continue;
							}
							return list;
						}
						if (int_2 >= 268436224)
						{
							if (flag && (!smethod_3(binaryReader) || !smethod_3(binaryReader)))
							{
								return list;
							}
							if (!smethod_5(binaryReader, out var int_4) || int_4 < 4)
							{
								return list;
							}
							if (!smethod_8(binaryReader, int_4 - 4L))
							{
								return list;
							}
						}
						if (smethod_5(binaryReader, out var int_5) && int_5 >= 0 && int_5 <= 100000)
						{
							int num2 = 0;
							while (true)
							{
								if (num2 < int_5)
								{
									if (smethod_5(binaryReader, out var int_6) && int_6 >= 0 && int_6 <= 1000000)
									{
										if (smethod_8(binaryReader, int_6 * 4L))
										{
											num2++;
											continue;
										}
										return list;
									}
									return list;
								}
								for (int i = 0; i < int_5; i++)
								{
									PwMapCollisionBrush pwMapCollisionBrush = new PwMapCollisionBrush();
									if (smethod_4(binaryReader, out var vector3_) && smethod_4(binaryReader, out var vector3_2) && smethod_4(binaryReader, out var vector3_3) && smethod_4(binaryReader, out var vector3_4) && smethod_5(binaryReader, out var int_7) && smethod_5(binaryReader, out var int_8) && int_8 >= 0 && int_8 <= 1024)
									{
										pwMapCollisionBrush.Center = vector3_;
										pwMapCollisionBrush.Extents = vector3_2;
										pwMapCollisionBrush.Min = vector3_3;
										pwMapCollisionBrush.Max = vector3_4;
										pwMapCollisionBrush.Flags = int_7;
										for (int j = 0; j < int_8; j++)
										{
											if (smethod_6(binaryReader, out var float_) && smethod_6(binaryReader, out var float_2) && smethod_6(binaryReader, out var float_3) && smethod_6(binaryReader, out var float_4) && smethod_7(binaryReader, out var byte_3))
											{
												pwMapCollisionBrush.Sides.Add(new PwMapCollisionBrush.Side(new Vector3(float_, float_2, float_3), float_4, byte_3));
												continue;
											}
											return list;
										}
										list.Add(pwMapCollisionBrush);
										continue;
									}
									return list;
								}
								break;
							}
							break;
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
		catch
		{
			return new List<PwMapCollisionBrush>();
		}
	}

	private static Stream smethod_0(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return null;
		}
		if (File.Exists(string_0))
		{
			try
			{
				return File.OpenRead(string_0);
			}
			catch
			{
				return null;
			}
		}
		byte[] array = PwMapAssetProvider.ReadPckBytes(string_0);
		if (array != null && array.Length != 0)
		{
			return new MemoryStream(array, writable: false);
		}
		return null;
	}

	private static bool smethod_1(BinaryReader binaryReader_0, int int_0)
	{
		if (int_0 >= 268436224)
		{
			if (smethod_7(binaryReader_0, out var byte_) && smethod_7(binaryReader_0, out var byte_2))
			{
				bool flag = byte_ != 0;
				bool flag2 = byte_2 != 0;
				if (!smethod_3(binaryReader_0))
				{
					return false;
				}
				if (!smethod_3(binaryReader_0))
				{
					return false;
				}
				if (smethod_5(binaryReader_0, out var int_1) && int_1 >= 0 && int_1 <= 10000000)
				{
					if (smethod_5(binaryReader_0, out var int_2) && int_2 >= 0 && int_2 <= 10000000)
					{
						if (!smethod_8(binaryReader_0, int_1 * 24L))
						{
							return false;
						}
						if (!smethod_8(binaryReader_0, int_2 * 6L))
						{
							return false;
						}
						if (!smethod_8(binaryReader_0, int_1 * 12L))
						{
							return false;
						}
						if (int_0 >= 268436226 && !smethod_8(binaryReader_0, int_2 * 6L))
						{
							return false;
						}
						if (int_0 >= 268436228 && !smethod_8(binaryReader_0, 16L))
						{
							return false;
						}
						if (!smethod_2(binaryReader_0))
						{
							return false;
						}
						if (flag && !smethod_8(binaryReader_0, int_1 * 8L))
						{
							return false;
						}
						if ((!flag || !flag2) && !smethod_8(binaryReader_0, int_1 * 8L))
						{
							return false;
						}
						if (!smethod_8(binaryReader_0, 48L))
						{
							return false;
						}
						if (smethod_5(binaryReader_0, out var int_3) && int_3 >= 4)
						{
							if (!smethod_8(binaryReader_0, int_3 - 4L))
							{
								return false;
							}
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
		if (!smethod_5(binaryReader_0, out var int_4))
		{
			return false;
		}
		if (int_4 < 268435458)
		{
			return false;
		}
		if (!smethod_8(binaryReader_0, 320L))
		{
			return false;
		}
		if (smethod_5(binaryReader_0, out var int_5) && int_5 >= 0 && int_5 <= 10000000)
		{
			if (smethod_5(binaryReader_0, out var int_6) && int_6 >= 0 && int_6 <= 10000000)
			{
				byte byte_3 = 0;
				if (int_4 >= 268435462 && !smethod_7(binaryReader_0, out byte_3))
				{
					return false;
				}
				long num = ((int_4 == 268435458 || int_4 == 268435459) ? 28L : 24L);
				if (!smethod_8(binaryReader_0, int_5 * num))
				{
					return false;
				}
				if (!smethod_8(binaryReader_0, int_6 * 6L))
				{
					return false;
				}
				if (!smethod_8(binaryReader_0, int_5 * 12L))
				{
					return false;
				}
				if (int_4 >= 268435459 && !smethod_8(binaryReader_0, int_5 * 8L))
				{
					return false;
				}
				if (int_4 >= 268435462 && byte_3 == 1 && !smethod_8(binaryReader_0, int_5 * 8L))
				{
					return false;
				}
				if (!smethod_8(binaryReader_0, 48L))
				{
					return false;
				}
				if (int_4 >= 268435461 && !smethod_2(binaryReader_0))
				{
					return false;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool smethod_2(BinaryReader binaryReader_0)
	{
		if (!smethod_8(binaryReader_0, 10L))
		{
			return false;
		}
		while (binaryReader_0.BaseStream.Position < binaryReader_0.BaseStream.Length)
		{
			if (smethod_7(binaryReader_0, out var byte_))
			{
				if (byte_ == 0)
				{
					break;
				}
				continue;
			}
			return false;
		}
		return smethod_8(binaryReader_0, 69L);
	}

	private static bool smethod_3(BinaryReader binaryReader_0)
	{
		if (smethod_5(binaryReader_0, out var int_) && int_ >= 0)
		{
			return smethod_8(binaryReader_0, int_);
		}
		return false;
	}

	private static bool smethod_4(BinaryReader binaryReader_0, out Vector3 vector3_0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		vector3_0 = Vector3.Zero;
		if (smethod_6(binaryReader_0, out var float_) && smethod_6(binaryReader_0, out var float_2) && smethod_6(binaryReader_0, out var float_3))
		{
			vector3_0 = new Vector3(float_, float_2, float_3);
			return true;
		}
		return false;
	}

	private static bool smethod_5(BinaryReader binaryReader_0, out int int_0)
	{
		int_0 = 0;
		if (smethod_9(binaryReader_0) < 4L)
		{
			return false;
		}
		int_0 = binaryReader_0.ReadInt32();
		return true;
	}

	private static bool smethod_6(BinaryReader binaryReader_0, out float float_0)
	{
		float_0 = 0f;
		if (smethod_9(binaryReader_0) < 4L)
		{
			return false;
		}
		float_0 = binaryReader_0.ReadSingle();
		return true;
	}

	private static bool smethod_7(BinaryReader binaryReader_0, out byte byte_0)
	{
		byte_0 = 0;
		if (smethod_9(binaryReader_0) < 1L)
		{
			return false;
		}
		byte_0 = binaryReader_0.ReadByte();
		return true;
	}

	private static bool smethod_8(BinaryReader binaryReader_0, long long_0)
	{
		if (long_0 >= 0L && smethod_9(binaryReader_0) >= long_0)
		{
			binaryReader_0.BaseStream.Position += long_0;
			return true;
		}
		return false;
	}

	private static long smethod_9(BinaryReader binaryReader_0)
	{
		return binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
	}
}
