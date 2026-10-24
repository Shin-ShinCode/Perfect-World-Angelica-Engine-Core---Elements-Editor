using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACE.PWMap;

internal static class PwMapEcbsdFile
{
	public static IReadOnlyList<string> LoadBsdataPaths(string ecbsdPath)
	{
		List<string> list = new List<string>(256);
		if (!string.IsNullOrWhiteSpace(ecbsdPath) && File.Exists(ecbsdPath))
		{
			byte[] array;
			try
			{
				array = File.ReadAllBytes(ecbsdPath);
			}
			catch
			{
				return list;
			}
			if (array.Length < 76)
			{
				return list;
			}
			Encoding encoding = smethod_0();
			MemoryStream memoryStream = new MemoryStream(array, writable: false);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					if (smethod_1(binaryReader, out var _) && smethod_1(binaryReader, out var _) && smethod_1(binaryReader, out var _) && smethod_1(binaryReader, out var int_4))
					{
						if (int_4 > 0 && int_4 <= 50000 && smethod_2(binaryReader, 60L))
						{
							for (int i = 0; i < int_4; i++)
							{
								if (!smethod_1(binaryReader, out var int_5))
								{
									break;
								}
								if (int_5 < 0)
								{
									break;
								}
								if (int_5 > 16384)
								{
									break;
								}
								if (smethod_3(binaryReader) < int_5)
								{
									break;
								}
								byte[] array2 = binaryReader.ReadBytes(int_5);
								if (array2.Length != int_5)
								{
									break;
								}
								string text = encoding.GetString(array2).Replace('\0', ' ').Trim();
								if (!string.IsNullOrWhiteSpace(text))
								{
									list.Add(text.Replace('\\', '/'));
								}
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
		return list;
	}

	private static Encoding smethod_0()
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

	private static bool smethod_1(BinaryReader binaryReader_0, out int int_0)
	{
		int_0 = 0;
		if (smethod_3(binaryReader_0) < 4L)
		{
			return false;
		}
		int_0 = binaryReader_0.ReadInt32();
		return true;
	}

	private static bool smethod_2(BinaryReader binaryReader_0, long long_0)
	{
		if (long_0 >= 0L && smethod_3(binaryReader_0) >= long_0)
		{
			binaryReader_0.BaseStream.Position += long_0;
			return true;
		}
		return false;
	}

	private static long smethod_3(BinaryReader binaryReader_0)
	{
		return binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
	}
}
