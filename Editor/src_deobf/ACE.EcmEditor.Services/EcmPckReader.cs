using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ACE.EcmEditor.Models;

namespace ACE.EcmEditor.Services;

public class EcmPckReader : IDisposable
{
	private sealed class Class120
	{
		public List<string> list_0;

		internal bool method_0(EcmPckEntry ecmPckEntry_0)
		{
			Class123 @class = new Class123();
			@class.string_0 = System.IO.Path.GetFileName(ecmPckEntry_0.Path);
			return list_0.Any(@class.method_0);
		}
	}

	[Serializable]
	private sealed class Class121
	{
		public static readonly Class121 class121_0 = new Class121();

		public static Func<char, bool> func_0;

		internal bool method_0(char char_0)
		{
			if (char_0 < ' ')
			{
				return char_0 != '\0';
			}
			return false;
		}
	}

	private sealed class Class122
	{
		public List<string> list_0;

		internal bool method_0(EcmPckEntry ecmPckEntry_0)
		{
			string fileName = System.IO.Path.GetFileName(ecmPckEntry_0.Path);
			if (!fileName.EndsWith(Class16.smethod_0(1648906325), StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			string text = fileName;
			string text2 = text.Substring(0, text.Length - 4);
			if (text2.EndsWith(Class16.smethod_0(1648994631), StringComparison.OrdinalIgnoreCase))
			{
				text = text2;
				text2 = text.Substring(0, text.Length - 2);
			}
			return list_0.Contains(text2);
		}
	}

	private sealed class Class123
	{
		public string string_0;

		internal bool method_0(string string_1)
		{
			return string.Equals(string_0, string_1, StringComparison.OrdinalIgnoreCase);
		}
	}

	private EcmPckMultiStream ecmPckMultiStream_0;

	private readonly string string_0;

	private EcmPckKey ecmPckKey_0;

	private EcmPckVersion ecmPckVersion_0;

	private EcmPckPathFormat ecmPckPathFormat_0 = EcmPckPathFormat.Standard256;

	private readonly List<EcmPckEntry> list_0 = new List<EcmPckEntry>();

	public IReadOnlyList<EcmPckEntry> Entries => list_0;

	public int FileCount => list_0.Count;

	public EcmPckKey CurrentKey => ecmPckKey_0;

	public EcmPckPathFormat CurrentPathFormat => ecmPckPathFormat_0;

	public bool HasPkxFiles => ecmPckMultiStream_0?.HasPkxFiles ?? false;

	public EcmPckReader(string pckPath, EcmPckKey key = null)
	{
		string_0 = pckPath;
		ecmPckKey_0 = key ?? EcmPckKey.AllKeys[0];
	}

	public bool Open()
	{
		try
		{
			method_0();
			method_1();
			bool result = method_2();
			Close();
			return result;
		}
		catch
		{
			Close();
			return false;
		}
	}

	public EcmPckOpenResult OpenWithAutoKey()
	{
		EcmPckOpenResult ecmPckOpenResult = new EcmPckOpenResult();
		foreach (EcmPckKey allKey in EcmPckKey.AllKeys)
		{
			ecmPckOpenResult.TriedKeys.Add(allKey.Name);
			ecmPckKey_0 = allKey;
			ecmPckPathFormat_0 = EcmPckPathFormat.Standard256;
			list_0.Clear();
			try
			{
				method_0();
				ecmPckOpenResult.HasPkxFiles = ecmPckMultiStream_0?.HasPkxFiles ?? false;
				method_1();
				if (method_2())
				{
					Close();
					ecmPckOpenResult.Success = true;
					ecmPckOpenResult.DetectedKey = allKey;
					ecmPckOpenResult.PathFormat = ecmPckPathFormat_0;
					return ecmPckOpenResult;
				}
			}
			catch
			{
			}
			finally
			{
				Close();
			}
			if (ecmPckVersion_0 != EcmPckVersion.V2)
			{
				continue;
			}
			ecmPckPathFormat_0 = EcmPckPathFormat.Alternate260;
			list_0.Clear();
			try
			{
				method_0();
				ecmPckOpenResult.HasPkxFiles = ecmPckMultiStream_0?.HasPkxFiles ?? false;
				method_1();
				if (method_2())
				{
					Close();
					ecmPckOpenResult.Success = true;
					ecmPckOpenResult.DetectedKey = allKey;
					ecmPckOpenResult.PathFormat = ecmPckPathFormat_0;
					return ecmPckOpenResult;
				}
			}
			catch
			{
			}
			finally
			{
				Close();
			}
		}
		ecmPckOpenResult.Success = false;
		ecmPckOpenResult.ErrorMessage = Class16.smethod_0(1648989747) + string.Join(Class16.smethod_0(1648942920), ecmPckOpenResult.TriedKeys);
		return ecmPckOpenResult;
	}

	private void method_0()
	{
		Close();
		ecmPckMultiStream_0 = new EcmPckMultiStream(string_0);
		ecmPckMultiStream_0.Open();
	}

	private void method_1()
	{
		if (ecmPckMultiStream_0 != null)
		{
			ecmPckMultiStream_0.Seek(-4L, SeekOrigin.End);
			short num = ecmPckMultiStream_0.ReadInt16();
			ecmPckVersion_0 = ((num == 3) ? EcmPckVersion.V3 : EcmPckVersion.V2);
		}
	}

	private bool method_2()
	{
		if (ecmPckMultiStream_0 == null)
		{
			return false;
		}
		ecmPckMultiStream_0.Seek(-8L, SeekOrigin.End);
		int num = ecmPckMultiStream_0.ReadInt32();
		if (num >= 0 && num <= 10000000)
		{
			long num2;
			int num3;
			if (ecmPckVersion_0 == EcmPckVersion.V2)
			{
				ecmPckMultiStream_0.Seek(-272L, SeekOrigin.End);
				num2 = (uint)(ecmPckMultiStream_0.ReadUInt32() ^ ecmPckKey_0.KEY_1);
				num3 = 280;
			}
			else
			{
				ecmPckMultiStream_0.Seek(-280L, SeekOrigin.End);
				num2 = ecmPckMultiStream_0.ReadInt64() ^ ecmPckKey_0.KEY_1;
				num3 = 288;
			}
			if (num2 >= 0L && num2 < ecmPckMultiStream_0.Length)
			{
				ecmPckMultiStream_0.Seek(num2, SeekOrigin.Begin);
				byte[] array = ecmPckMultiStream_0.ReadBytes((int)(ecmPckMultiStream_0.Length - num2 - num3));
				if (array.Length == 0)
				{
					return false;
				}
				BinaryReader binaryReader = new BinaryReader(new MemoryStream(array));
				try
				{
					int num4 = 0;
					for (int i = 0; i < num; i++)
					{
						if (binaryReader.BaseStream.Position >= binaryReader.BaseStream.Length - 8L)
						{
							break;
						}
						int num5 = binaryReader.ReadInt32() ^ ecmPckKey_0.KEY_1;
						if (num5 <= 0 || num5 > 1000000)
						{
							break;
						}
						binaryReader.ReadInt32();
						if (binaryReader.BaseStream.Position + num5 > binaryReader.BaseStream.Length)
						{
							break;
						}
						byte[] byte_ = binaryReader.ReadBytes(num5);
						EcmPckEntry ecmPckEntry = method_3(byte_);
						if (ecmPckEntry != null && !string.IsNullOrEmpty(ecmPckEntry.Path) && ecmPckEntry.Path.Length > 1)
						{
							list_0.Add(ecmPckEntry);
							num4++;
						}
					}
					return num4 > 0;
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			return false;
		}
		return false;
	}

	private EcmPckEntry method_3(byte[] byte_0)
	{
		try
		{
			int num = (int)((ecmPckVersion_0 == EcmPckVersion.V2) ? ecmPckPathFormat_0 : EcmPckPathFormat.Alternate260);
			int num2 = ((ecmPckVersion_0 == EcmPckVersion.V3) ? 288 : (num + 20));
			if (byte_0.Length < num2)
			{
				byte_0 = EcmZlibHelper.Decompress(byte_0, num2);
			}
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(byte_0));
			try
			{
				string text;
				long offset;
				int size;
				int compressedSize;
				if (ecmPckVersion_0 == EcmPckVersion.V2)
				{
					text = binaryReader.ReadBytes(num).ToGBK().Replace('/', '\\');
					if (ecmPckPathFormat_0 == EcmPckPathFormat.Standard256)
					{
						binaryReader.ReadUInt32();
						offset = binaryReader.ReadUInt32();
					}
					else
					{
						offset = binaryReader.ReadUInt32();
					}
					size = binaryReader.ReadInt32();
					compressedSize = binaryReader.ReadInt32();
				}
				else
				{
					text = binaryReader.ReadBytes(260).ToGBK().Replace('/', '\\');
					binaryReader.ReadUInt32();
					offset = binaryReader.ReadInt64();
					size = binaryReader.ReadInt32();
					compressedSize = binaryReader.ReadInt32();
				}
				if (!string.IsNullOrEmpty(text) && !text.Any(Class121.class121_0.method_0))
				{
					return new EcmPckEntry
					{
						Path = text.Replace('\\', '/'),
						Offset = offset,
						Size = size,
						CompressedSize = compressedSize
					};
				}
				return null;
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
		catch
		{
			return null;
		}
	}

	public byte[] ExtractFile(EcmPckEntry entry)
	{
		try
		{
			method_0();
			ecmPckMultiStream_0.Seek(entry.Offset, SeekOrigin.Begin);
			byte[] array = ecmPckMultiStream_0.ReadBytes(entry.CompressedSize);
			Close();
			if (entry.CompressedSize < entry.Size)
			{
				return EcmZlibHelper.Decompress(array, entry.Size);
			}
			return array;
		}
		catch
		{
			return null;
		}
	}

	public List<EcmPckEntry> FindAllEcmFiles()
	{
		Class122 @class = new Class122();
		@class.list_0 = EcmClassIdentifier.GetAllBaseNames();
		return list_0.Where(@class.method_0).ToList();
	}

	public List<EcmPckEntry> FindEcmFiles(EcmVersion version)
	{
		Class120 @class = new Class120();
		@class.list_0 = EcmClassIdentifier.GetAllEcmNames(version);
		return list_0.Where(@class.method_0).ToList();
	}

	public (int extracted, int failed) ExtractEcmFiles(List<EcmPckEntry> entries, string outputDir, Action<int, int> progress = null)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < entries.Count; i++)
		{
			EcmPckEntry ecmPckEntry = entries[i];
			progress?.Invoke(i + 1, entries.Count);
			try
			{
				byte[] array = ExtractFile(ecmPckEntry);
				if (array == null)
				{
					num2++;
					continue;
				}
				string path = System.IO.Path.Combine(outputDir, ecmPckEntry.Path.Replace('/', System.IO.Path.DirectorySeparatorChar));
				string directoryName = System.IO.Path.GetDirectoryName(path);
				if (directoryName != null && !Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				File.WriteAllBytes(path, array);
				num++;
			}
			catch
			{
				num2++;
			}
		}
		return (extracted: num, failed: num2);
	}

	public void Close()
	{
		ecmPckMultiStream_0?.Close();
		ecmPckMultiStream_0 = null;
	}

	public void Dispose()
	{
		Close();
		GC.SuppressFinalize(this);
	}
}
