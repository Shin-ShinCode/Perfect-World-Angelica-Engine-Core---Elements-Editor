using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Dependency.Ionic.Zlib;
using ACE.MainWindow;
using ACE.Protectors;
using ACE.RSGlobal;
using Sentry;

namespace ACE.Pck;

public class PCK
{
	public struct PCK_FILE_TABLE_ENTRY
	{
		public const int PATH_LENGTH = 260;

		public const int ENTRY_SIZE_V2 = 276;

		public const int ENTRY_SIZE_V3 = 288;

		public byte[] file_path;

		public int v3_unknown;

		public long Position;

		public uint OriginalSize;

		public uint CompressedSize;

		public uint Padding1;

		public uint Padding2;

		public static Encoding GB2312;

		public string FilePath
		{
			get
			{
				if (file_path == null)
				{
					return string.Empty;
				}
				string text = GB2312.GetString(file_path);
				int num = text.IndexOf('\0');
				return ((num >= 0) ? text.Substring(0, num) : text).Replace(Class16.smethod_0(1648892117), Class16.smethod_0(1648927580));
			}
			set
			{
				file_path = ToBytesGBK(value, 260);
			}
		}

		public PCK_FILE_TABLE_ENTRY(string filePath)
		{
			file_path = ToBytesGBK(filePath, 260);
			v3_unknown = 0;
			Position = 0L;
			OriginalSize = 0u;
			CompressedSize = 0u;
			Padding1 = 0u;
			Padding2 = 0u;
		}

		public PCK_FILE_TABLE_ENTRY(byte[] bytes, ArchiveVersion version)
		{
			file_path = null;
			v3_unknown = 0;
			Position = 0L;
			OriginalSize = 0u;
			CompressedSize = 0u;
			Padding1 = 0u;
			Padding2 = 0u;
			int entrySize = version.GetEntrySize();
			if (bytes.Length < entrySize)
			{
				bytes = Help.ZlibDecompress(bytes, (uint)entrySize);
			}
			MemoryStream memoryStream = new MemoryStream(bytes);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					file_path = binaryReader.ReadBytes(260);
					if (version == ArchiveVersion.V3)
					{
						v3_unknown = binaryReader.ReadInt32();
						Position = binaryReader.ReadInt64();
						OriginalSize = binaryReader.ReadUInt32();
						CompressedSize = binaryReader.ReadUInt32();
					}
					else
					{
						Position = binaryReader.ReadUInt32();
						OriginalSize = binaryReader.ReadUInt32();
						CompressedSize = binaryReader.ReadUInt32();
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

		static PCK_FILE_TABLE_ENTRY()
		{
			GB2312 = Encoding.GetEncoding(Class16.smethod_0(1648921191));
		}

		public static PCK_FILE_TABLE_ENTRY Read(byte[] buffer, int compressedSize, ArchiveVersion version)
		{
			int entrySize = version.GetEntrySize();
			if (compressedSize < entrySize)
			{
				buffer = Help.ZlibDecompress(buffer, (uint)entrySize);
			}
			return new PCK_FILE_TABLE_ENTRY(buffer, version);
		}

		public byte[] GetBytes(bool bCompress, int level, ArchiveVersion version)
		{
			int entrySize = version.GetEntrySize();
			MemoryStream memoryStream = new MemoryStream(new byte[entrySize]);
			byte[] array;
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					binaryWriter.Write(file_path ?? new byte[260]);
					if (version == ArchiveVersion.V3)
					{
						binaryWriter.Write(v3_unknown);
						binaryWriter.Write(Position);
						binaryWriter.Write(OriginalSize);
						binaryWriter.Write(CompressedSize);
						binaryWriter.Write(0L);
					}
					else
					{
						binaryWriter.Write((uint)Position);
						binaryWriter.Write(OriginalSize);
						binaryWriter.Write(CompressedSize);
						binaryWriter.Write(0u);
					}
					array = memoryStream.ToArray();
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
			if (bCompress)
			{
				byte[] array2 = Help.ZlibCompress(array, (CompressionLevel)level);
				if (array2.Length < array.Length)
				{
					return array2;
				}
			}
			return array;
		}
	}

	public struct PCK_METADATA
	{
		public const int DESCRIPTION_SIZE = 252;

		public const string DEFAULT_DESCRIPTION = "Angelica File Package, Perfect World.";

		public uint ASIG_1;

		public uint VersionFlags;

		public long FileTableOffset;

		public uint Reserved;

		public byte[] AngelicaSign;

		public uint ASIG_2;

		public uint Reserved2;

		public static PCK_METADATA FromBytes(byte[] bytes, ArchiveVersion version)
		{
			PCK_METADATA result = default(PCK_METADATA);
			MemoryStream memoryStream = new MemoryStream(bytes);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					result.ASIG_1 = binaryReader.ReadUInt32();
					result.VersionFlags = binaryReader.ReadUInt32();
					if (version == ArchiveVersion.V3)
					{
						result.FileTableOffset = binaryReader.ReadInt64();
					}
					else
					{
						result.FileTableOffset = binaryReader.ReadUInt32();
					}
					result.Reserved = binaryReader.ReadUInt32();
					result.AngelicaSign = binaryReader.ReadBytes(252);
					result.ASIG_2 = binaryReader.ReadUInt32();
					return result;
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

		public byte[] GetBytes(ArchiveVersion version)
		{
			int capacity = ((version == ArchiveVersion.V3) ? 280 : 272);
			MemoryStream memoryStream = new MemoryStream(capacity);
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					binaryWriter.Write(ASIG_1);
					binaryWriter.Write(VersionFlags);
					if (version == ArchiveVersion.V3)
					{
						binaryWriter.Write(FileTableOffset);
					}
					else
					{
						binaryWriter.Write((uint)FileTableOffset);
					}
					binaryWriter.Write(Reserved);
					binaryWriter.Write(AngelicaSign ?? new byte[252]);
					binaryWriter.Write(ASIG_2);
					return memoryStream.ToArray();
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}

		public void XorFileTable(int FTO_KEY, ArchiveVersion version)
		{
			if (version == ArchiveVersion.V3)
			{
				FileTableOffset ^= FTO_KEY;
			}
			else
			{
				FileTableOffset = (uint)((int)FileTableOffset ^ FTO_KEY);
			}
		}
	}

	public class PCK_STRUCT
	{
		public uint FSIG_1;

		public long FileSize;

		public uint FSIG_2;

		public PCK_FILE_TABLE_ENTRY[] FileTable;

		public PCK_METADATA MetaData;

		public int EntryCount;

		public ArchiveVersion Version;

		public string FileName;

		public string FileName_pkx;

		public long PckSize;

		public FileStream fs_pck;

		public List<FileStream> fs_pkx_list;

		public BinaryReader br_pck;

		public List<BinaryReader> br_pkx_list;

		public BinaryWriter bw_pck;

		public List<BinaryWriter> bw_pkx_list;

		public int current_pkx_index;

		public long Position;

		public long MaxFilePosition;

		public int LastFilePositionIndex;

		public bool IsOpenedRead;

		public bool IsOpenedWrite;

		public bool bReadingSuccess;

		public PCK_PROTECTION_SETTINGS settings;

		public static readonly long PCK_MAX_SIZE = 2147483392L;

		public static readonly long PKX_MAX_SIZE = 4294967296L;

		private static readonly HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		private static readonly HashSet<string> hashSet_1 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		public FileStream fs_pkx
		{
			get
			{
				if (!(fs_pkx_list?.Count > current_pkx_index))
				{
					return null;
				}
				return fs_pkx_list[current_pkx_index];
			}
		}

		public BinaryReader br_pkx
		{
			get
			{
				if (!(br_pkx_list?.Count > current_pkx_index))
				{
					return null;
				}
				return br_pkx_list[current_pkx_index];
			}
		}

		public BinaryWriter bw_pkx
		{
			get
			{
				if (!(bw_pkx_list?.Count > current_pkx_index))
				{
					return null;
				}
				return bw_pkx_list[current_pkx_index];
			}
		}

		public long PckMaxSize
		{
			get
			{
				if (fs_pkx != null && FileSize > PCK_MAX_SIZE)
				{
					return fs_pck.Length;
				}
				return PCK_MAX_SIZE;
			}
		}

		public PCK_STRUCT(string fileName, bool bReadFileTable, PCK_PROTECTION_SETTINGS settings)
		{
			this.settings = settings;
			Load(fileName, bReadFileTable, settings);
		}

		public PCK_STRUCT(string fileName)
		{
			settings = new PCK_PROTECTION_SETTINGS
			{
				MetaDataShift = 280
			};
			Load(fileName, bReadFileTable: false, settings);
		}

		public void Load(string fileName, bool bReadFileTable, PCK_PROTECTION_SETTINGS pck_PROTECTION_SETTINGS_0)
		{
			EditorSessionTracker.LogFolderAccess(fileName, Class16.smethod_0(1648903793), Class16.smethod_0(1649198241));
			FileName = fileName;
			settings = pck_PROTECTION_SETTINGS_0;
			FileName_pkx = GetPkxName(fileName, 0);
			if (!OpenRead())
			{
				return;
			}
			try
			{
				SetPosition(FileSize - 8L);
				EntryCount = (int)ReadUInt32();
				if (EntryCount >= 0 && EntryCount <= 10000000)
				{
					uint versionValue = ReadUInt32();
					Version = ArchiveVersionHelper.FromVersionValue(versionValue);
					int footerSize = Version.GetFooterSize();
					if (pck_PROTECTION_SETTINGS_0.MetaDataShift < footerSize)
					{
						pck_PROTECTION_SETTINGS_0.MetaDataShift = (ushort)footerSize;
					}
					long num = FileSize - pck_PROTECTION_SETTINGS_0.MetaDataShift;
					if (FileSize - num < footerSize || num < 50L)
					{
						long num2 = method_0();
						if (num2 > 0L && num2 != FileSize)
						{
							FileSize = num2;
							num = FileSize - pck_PROTECTION_SETTINGS_0.MetaDataShift;
						}
					}
					if (FileSize - num >= footerSize && num >= 50L)
					{
						int count = ((Version == ArchiveVersion.V3) ? 280 : 272);
						SetPosition(num);
						MetaData = PCK_METADATA.FromBytes(ReadBytes((uint)count), Version);
						if (bReadFileTable)
						{
							MetaData.XorFileTable(pck_PROTECTION_SETTINGS_0.FTO_KEY, Version);
							bReadingSuccess = ReadFileTable();
							if (!bReadingSuccess)
							{
								EntryCount = 0;
								FileTable = Array.Empty<PCK_FILE_TABLE_ENTRY>();
							}
						}
						return;
					}
					throw new ApplicationException(Class16.smethod_0(1649198295) + fileName);
				}
				throw new ApplicationException(Class16.smethod_0(1649198251) + fileName);
			}
			catch (ApplicationException ex)
			{
				TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, ex.Message);
			}
			catch (EndOfStreamException ex2)
			{
				SentryHelper.CaptureMessage(string.Format(Class16.smethod_0(1649198326), ex2.Message, fileName, Position), (SentryLevel)2, Class16.smethod_0(1649198370));
				TextStorage.TEXTS.ShowMessage(610, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, fileName, Position, ex2.Message);
			}
			catch (Exception ex3)
			{
				SentryHelper.CaptureException(ex3, Class16.smethod_0(1649198405));
				TextStorage.TEXTS.ShowMessage(610, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, fileName, Position, ex3.Message);
			}
		}

		private long method_0()
		{
			long long_ = 0L;
			if (!method_11(fs_pck, out long_, Class16.smethod_0(1649198420)))
			{
				return -1L;
			}
			if (fs_pkx_list != null)
			{
				foreach (FileStream item in fs_pkx_list)
				{
					if (method_11(item, out var long_2, Class16.smethod_0(1649198448)))
					{
						long_ += long_2;
						continue;
					}
					return -1L;
				}
			}
			return long_;
		}

		public static string GetPkxName(string pckFileName, int index)
		{
			string directoryName = System.IO.Path.GetDirectoryName(pckFileName);
			string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(pckFileName);
			if (index == 0)
			{
				return System.IO.Path.Combine(directoryName, fileNameWithoutExtension + Class16.smethod_0(1648989712));
			}
			return System.IO.Path.Combine(directoryName, fileNameWithoutExtension + Class16.smethod_0(1648989712) + index);
		}

		public static string GetPkxName(string pckFileName)
		{
			return GetPkxName(pckFileName, 0);
		}

		public bool OpenRead()
		{
			try
			{
				if (!IsOpenedRead)
				{
					method_1();
					if (!File.Exists(FileName))
					{
						if (hashSet_1.Add(FileName ?? string.Empty))
						{
							SentryHelper.CaptureMessage(Class16.smethod_0(1649198492) + FileName, (SentryLevel)2, Class16.smethod_0(1649198520));
						}
						TextStorage.TEXTS.ShowMessage(598, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Class16.smethod_0(1649198552), FileName);
						return false;
					}
					if (IsOpenedWrite)
					{
						CloseWrite();
					}
					br_pck = new BinaryReader(fs_pck = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
					if (!method_11(fs_pck, out PckSize, Class16.smethod_0(1649198581)))
					{
						method_1();
						return false;
					}
					if (PckSize < 12L)
					{
						method_1();
						SentryHelper.CaptureMessage(string.Format(Class16.smethod_0(1649197583), FileName, PckSize), (SentryLevel)2, Class16.smethod_0(1649197627));
						TextStorage.TEXTS.ShowMessage(598, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Class16.smethod_0(1649197670), FileName);
						return false;
					}
					FSIG_1 = br_pck.ReadUInt32();
					FileSize = br_pck.ReadUInt32();
					FSIG_2 = br_pck.ReadUInt32();
					if (FSIG_2 != 1453361591 && FSIG_2 != 1453361592)
					{
						if (PckSize < 16L)
						{
							method_1();
							SentryHelper.CaptureMessage(string.Format(Class16.smethod_0(1649197691), FileName, PckSize), (SentryLevel)2, Class16.smethod_0(1649197767));
							TextStorage.TEXTS.ShowMessage(598, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Class16.smethod_0(1649197670), FileName);
							return false;
						}
						fs_pck.Seek(4L, SeekOrigin.Begin);
						FileSize = br_pck.ReadInt64();
						FSIG_2 = br_pck.ReadUInt32();
					}
					if (FileSize > PckSize || File.Exists(FileName_pkx))
					{
						fs_pkx_list = new List<FileStream>();
						br_pkx_list = new List<BinaryReader>();
						current_pkx_index = 0;
						int num = 0;
						string pkxName;
						while (true)
						{
							pkxName = GetPkxName(FileName, num);
							if (!File.Exists(pkxName))
							{
								break;
							}
							FileStream fileStream = new FileStream(pkxName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
							BinaryReader item = new BinaryReader(fileStream);
							fs_pkx_list.Add(fileStream);
							br_pkx_list.Add(item);
							num++;
						}
						if (num == 0 && FileSize > PckSize)
						{
							method_1();
							TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, pkxName);
							return false;
						}
					}
					IsOpenedRead = true;
					IsOpenedWrite = false;
				}
				return true;
			}
			catch (Exception ex)
			{
				method_1();
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649197804));
				if (TextStorage.TEXTS.ShowMessage(598, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, ex.Message, FileName) == DialogResult.Retry)
				{
					return OpenRead();
				}
				return false;
			}
		}

		private void method_1()
		{
			try
			{
				br_pck?.Close();
			}
			catch
			{
			}
			try
			{
				fs_pck?.Close();
			}
			catch
			{
			}
			if (br_pkx_list != null)
			{
				foreach (BinaryReader item in br_pkx_list)
				{
					try
					{
						item?.Close();
					}
					catch
					{
					}
				}
				br_pkx_list.Clear();
			}
			if (fs_pkx_list != null)
			{
				foreach (FileStream item2 in fs_pkx_list)
				{
					try
					{
						item2?.Close();
					}
					catch
					{
					}
				}
				fs_pkx_list.Clear();
			}
			br_pck = null;
			fs_pck = null;
			current_pkx_index = 0;
			IsOpenedRead = false;
			IsOpenedWrite = false;
		}

		private void method_2()
		{
			try
			{
				bw_pck?.Close();
			}
			catch
			{
			}
			try
			{
				fs_pck?.Close();
			}
			catch
			{
			}
			if (bw_pkx_list != null)
			{
				foreach (BinaryWriter item in bw_pkx_list)
				{
					try
					{
						item?.Close();
					}
					catch
					{
					}
				}
				bw_pkx_list.Clear();
			}
			if (fs_pkx_list != null)
			{
				foreach (FileStream item2 in fs_pkx_list)
				{
					try
					{
						item2?.Close();
					}
					catch
					{
					}
				}
				fs_pkx_list.Clear();
			}
			bw_pck = null;
			fs_pck = null;
			current_pkx_index = 0;
			IsOpenedWrite = false;
		}

		public bool OpenWrite()
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					if (!IsOpenedWrite)
					{
						method_2();
						if (IsOpenedRead)
						{
							CloseRead();
						}
						fs_pck = new FileStream(FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
						bw_pck = new BinaryWriter(fs_pck);
						bw_pkx_list = new List<BinaryWriter>();
						fs_pkx_list = new List<FileStream>();
						current_pkx_index = 0;
						int num = 0;
						while (true)
						{
							string pkxName = GetPkxName(FileName, num);
							if (!File.Exists(pkxName))
							{
								break;
							}
							FileStream fileStream = new FileStream(pkxName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
							BinaryWriter item = new BinaryWriter(fileStream);
							fs_pkx_list.Add(fileStream);
							bw_pkx_list.Add(item);
							num++;
						}
						IsOpenedWrite = true;
						IsOpenedRead = false;
					}
					return true;
				}
				catch (IOException ex)
				{
					method_2();
					SentryHelper.CaptureMessage(Class16.smethod_0(1649197823) + ex.Message + Class16.smethod_0(1649198770) + FileName, (SentryLevel)2, Class16.smethod_0(1649197854));
					if (TextStorage.TEXTS.ShowMessage(598, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, ex.Message, FileName) != DialogResult.Retry)
					{
						return false;
					}
					Thread.Sleep(500);
				}
				catch (Exception ex2)
				{
					method_2();
					SentryHelper.CaptureException(ex2, Class16.smethod_0(1649197886));
					if (TextStorage.TEXTS.ShowMessage(598, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, ex2.Message, FileName) != DialogResult.Retry)
					{
						return false;
					}
				}
			}
			return false;
		}

		public void CreateAndOpenPkx()
		{
			if (bw_pkx_list == null)
			{
				bw_pkx_list = new List<BinaryWriter>();
				fs_pkx_list = new List<FileStream>();
				current_pkx_index = 0;
			}
			string pkxName = GetPkxName(FileName, fs_pkx_list.Count);
			File.WriteAllBytes(pkxName, new byte[4]);
			FileStream fileStream = new FileStream(pkxName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
			BinaryWriter item = new BinaryWriter(fileStream);
			fs_pkx_list.Add(fileStream);
			bw_pkx_list.Add(item);
			current_pkx_index = fs_pkx_list.Count - 1;
		}

		public void CloseRead()
		{
			if (IsOpenedRead)
			{
				method_1();
			}
		}

		public void CloseWrite()
		{
			if (!IsOpenedWrite)
			{
				return;
			}
			bw_pck?.Close();
			fs_pck?.Close();
			if (bw_pkx_list != null)
			{
				foreach (BinaryWriter item in bw_pkx_list)
				{
					item?.Close();
				}
				bw_pkx_list.Clear();
			}
			if (fs_pkx_list != null)
			{
				foreach (FileStream item2 in fs_pkx_list)
				{
					item2?.Close();
				}
				fs_pkx_list.Clear();
			}
			current_pkx_index = 0;
			IsOpenedWrite = false;
			IsOpenedRead = false;
		}

		public void Close()
		{
			if (IsOpenedRead)
			{
				CloseRead();
			}
			else if (IsOpenedWrite)
			{
				CloseWrite();
			}
		}

		public bool ReadFileTable()
		{
			try
			{
				if (EntryCount > 0)
				{
					method_0();
					long long_ = MetaData.FileTableOffset;
					if (!method_6(ref long_))
					{
						throw new ApplicationException(Class16.smethod_0(1649197898) + FileName);
					}
					MetaData.FileTableOffset = long_;
					FileTable = new PCK_FILE_TABLE_ENTRY[EntryCount];
					SetPosition(long_);
					MaxFilePosition = 0L;
					LastFilePositionIndex = -1;
					for (int i = 0; i < EntryCount; i++)
					{
						uint num = ReadUInt32() ^ (uint)settings.KEY_1;
						ReadUInt32();
						byte[] buffer = ReadBytes(num);
						FileTable[i] = PCK_FILE_TABLE_ENTRY.Read(buffer, (int)num, Version);
						long num2 = FileTable[i].Position + FileTable[i].CompressedSize;
						if (num2 > MaxFilePosition)
						{
							MaxFilePosition = num2;
							LastFilePositionIndex = i;
						}
					}
				}
				else
				{
					MaxFilePosition = Version.GetHeaderSize();
				}
				return true;
			}
			catch (EndOfStreamException ex)
			{
				method_3();
				if (hashSet_0.Add(FileName ?? string.Empty))
				{
					SentryHelper.CaptureMessage(string.Format(Class16.smethod_0(1649197943), FileName, Position, ex.Message), (SentryLevel)2, Class16.smethod_0(1649198002));
				}
				string message = string.Format(Class16.smethod_0(1649198046), Position, ex.Message);
				ACE.MainWindow.MainWindow.ShowBackgroundMessageOutside(message, IsAlert: true);
				return false;
			}
			catch (OverflowException ex2)
			{
				method_3();
				if (hashSet_0.Add(FileName ?? string.Empty))
				{
					SentryHelper.CaptureMessage(string.Format(Class16.smethod_0(1649197066), FileName, Position, ex2.Message), (SentryLevel)2, Class16.smethod_0(1649197130));
				}
				string message2 = string.Format(Class16.smethod_0(1649198046), Position, ex2.Message);
				ACE.MainWindow.MainWindow.ShowBackgroundMessageOutside(message2, IsAlert: true);
				return false;
			}
			catch (Exception ex3)
			{
				method_3();
				if (!(ex3 is ApplicationException))
				{
					if (hashSet_0.Add(FileName ?? string.Empty))
					{
						SentryHelper.CaptureException(ex3, Class16.smethod_0(1649197163));
					}
					string message3 = string.Format(Class16.smethod_0(1649198046), Position, ex3.Message);
					ACE.MainWindow.MainWindow.ShowBackgroundMessageOutside(message3, IsAlert: true);
				}
				else if (hashSet_0.Add(FileName ?? string.Empty))
				{
					TextStorage.TEXTS.ShowMessage(606, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, FileName);
				}
				return false;
			}
		}

		private void method_3()
		{
			EntryCount = 0;
			FileTable = Array.Empty<PCK_FILE_TABLE_ENTRY>();
			MaxFilePosition = Version.GetHeaderSize();
			LastFilePositionIndex = -1;
		}

		private void method_4(int int_0, uint uint_0, uint uint_1, long long_0)
		{
			if (uint_0 != uint_1)
			{
				throw new ApplicationException(string.Format(Class16.smethod_0(1649197187), int_0, uint_0, uint_1));
			}
			if (uint_0 == 0)
			{
				throw new ApplicationException(string.Format(Class16.smethod_0(1649197269), int_0));
			}
			if (Position < 0L || Position + uint_0 > long_0)
			{
				throw new EndOfStreamException(string.Format(Class16.smethod_0(1649197320), uint_0, Position, Math.Max(0L, long_0 - Position)));
			}
		}

		private void method_5(int int_0, PCK_FILE_TABLE_ENTRY pck_FILE_TABLE_ENTRY_0, long long_0)
		{
			if (pck_FILE_TABLE_ENTRY_0.file_path != null && pck_FILE_TABLE_ENTRY_0.file_path.Length != 0)
			{
				if (pck_FILE_TABLE_ENTRY_0.Position < Version.GetHeaderSize())
				{
					throw new ApplicationException(string.Format(Class16.smethod_0(1649197484), int_0, pck_FILE_TABLE_ENTRY_0.Position));
				}
				long num = pck_FILE_TABLE_ENTRY_0.Position + pck_FILE_TABLE_ENTRY_0.CompressedSize;
				if (num < pck_FILE_TABLE_ENTRY_0.Position || num > long_0)
				{
					throw new EndOfStreamException(string.Format(Class16.smethod_0(1649197550), int_0, num, long_0));
				}
				return;
			}
			throw new ApplicationException(string.Format(Class16.smethod_0(1649197414), int_0));
		}

		private bool method_6(ref long long_0)
		{
			if (method_7(long_0))
			{
				return true;
			}
			List<long> list = new List<long> { long_0 };
			if (Version == ArchiveVersion.V3)
			{
				list.Add(long_0 ^ settings.FTO_KEY);
				list.Add(long_0 ^ settings.KEY_1);
				list.Add(long_0 ^ (uint)settings.FTO_KEY);
				list.Add(long_0 ^ (uint)settings.KEY_1);
			}
			else
			{
				list.Add((int)long_0 ^ settings.FTO_KEY);
				list.Add((int)long_0 ^ settings.KEY_1);
				list.Add((uint)((int)long_0 ^ settings.FTO_KEY));
				list.Add((uint)((int)long_0 ^ settings.KEY_1));
			}
			HashSet<long> hashSet = new HashSet<long>();
			foreach (long item in list)
			{
				if (hashSet.Add(item) && method_7(item))
				{
					long_0 = item;
					return true;
				}
			}
			return false;
		}

		private bool method_7(long long_0)
		{
			if (long_0 >= Version.GetHeaderSize())
			{
				return FileSize - long_0 >= 50L;
			}
			return false;
		}

		public bool WriteFileTable(bool bRandCompression)
		{
			if (!OpenWrite())
			{
				return false;
			}
			if (EntryCount > 0)
			{
				if (IsProtectionActivated())
				{
					MetaData.FileTableOffset = Math.Max(MaxFilePosition, MetaData.FileTableOffset);
				}
				else
				{
					MetaData.FileTableOffset = MaxFilePosition;
				}
				SetPosition(MetaData.FileTableOffset);
				for (int i = 0; i < EntryCount; i++)
				{
					int level = ((!bRandCompression) ? 1 : RND.GenerateRnd(3, 7));
					byte[] bytes = FileTable[i].GetBytes(bCompress: true, level, Version);
					int num = bytes.Length;
					WriteUInt32((uint)(settings.KEY_1 ^ num));
					WriteUInt32((uint)(settings.KEY_2 ^ num));
					WriteBytes(bytes);
				}
			}
			return true;
		}

		public bool WriteFileTable()
		{
			return WriteFileTable(bRandCompression: false);
		}

		public void SetPosition(long position)
		{
			if (!IsOpenedWrite && !IsOpenedRead)
			{
				OpenRead();
			}
			if (position < 0L)
			{
				position = 0L;
			}
			Position = position;
			if (IsOpenedRead)
			{
				if (position < PckSize)
				{
					fs_pck.Position = Math.Min(position, fs_pck.Length);
					if (fs_pkx_list != null && fs_pkx_list.Count > 0)
					{
						current_pkx_index = 0;
						fs_pkx_list[current_pkx_index].Position = 0L;
					}
				}
				else
				{
					if (fs_pkx_list == null || fs_pkx_list.Count <= 0)
					{
						return;
					}
					long num = position - PckSize;
					long num2 = 0L;
					int num3 = 0;
					while (true)
					{
						if (num3 < fs_pkx_list.Count)
						{
							if (num < num2 + fs_pkx_list[num3].Length)
							{
								break;
							}
							num2 += fs_pkx_list[num3].Length;
							num3++;
							continue;
						}
						return;
					}
					current_pkx_index = num3;
					fs_pkx_list[num3].Position = num - num2;
				}
			}
			else if (position < PckMaxSize)
			{
				fs_pck.Position = position;
				if (fs_pkx_list != null && fs_pkx_list.Count > 0)
				{
					current_pkx_index = 0;
					fs_pkx_list[current_pkx_index].Position = 0L;
				}
			}
			else
			{
				if (fs_pkx_list == null || fs_pkx_list.Count == 0)
				{
					CreateAndOpenPkx();
				}
				long num4 = position - PckMaxSize;
				int num5 = (int)(num4 / PKX_MAX_SIZE);
				long position2 = num4 % PKX_MAX_SIZE;
				while (num5 >= fs_pkx_list.Count)
				{
					CreateAndOpenPkx();
				}
				current_pkx_index = num5;
				fs_pkx_list[current_pkx_index].Position = position2;
			}
		}

		public uint ReadUInt32()
		{
			if (Position < PckSize)
			{
				fs_pck.Position = Position;
			}
			long num = PckSize - Position;
			uint result;
			if (num >= 4L)
			{
				result = br_pck.ReadUInt32();
				if (fs_pck.Position >= PckSize && fs_pkx_list != null && fs_pkx_list.Count > 0)
				{
					current_pkx_index = 0;
					fs_pkx_list[current_pkx_index].Position = 0L;
				}
			}
			else if (num <= 0L)
			{
				if (fs_pkx_list != null && fs_pkx_list.Count != 0)
				{
					result = method_8(Position - PckSize);
				}
				else
				{
					if (Position >= fs_pck.Length)
					{
						throw new EndOfStreamException(string.Format(Class16.smethod_0(1649200686), Position, PckSize));
					}
					fs_pck.Position = Position;
					result = br_pck.ReadUInt32();
				}
			}
			else
			{
				if (fs_pkx_list == null || fs_pkx_list.Count == 0)
				{
					throw new EndOfStreamException(string.Format(Class16.smethod_0(1649200768), Position, num));
				}
				byte[] array = new byte[4];
				int num2 = (int)num;
				br_pck.ReadBytes(num2).CopyTo(array, 0);
				current_pkx_index = 0;
				fs_pkx_list[current_pkx_index].Position = 0L;
				br_pkx_list[current_pkx_index].ReadBytes(4 - num2).CopyTo(array, num2);
				result = BitConverter.ToUInt32(array, 0);
			}
			Position += 4L;
			return result;
		}

		private uint method_8(long long_0)
		{
			if (fs_pkx_list != null && fs_pkx_list.Count != 0)
			{
				long num = 0L;
				int num2 = 0;
				int num3 = 0;
				while (true)
				{
					if (num3 < fs_pkx_list.Count)
					{
						if (long_0 >= num + fs_pkx_list[num3].Length)
						{
							num += fs_pkx_list[num3].Length;
							if (num3 == fs_pkx_list.Count - 1)
							{
								break;
							}
							num3++;
							continue;
						}
						num2 = num3;
					}
					current_pkx_index = num2;
					long num4 = long_0 - num;
					fs_pkx_list[current_pkx_index].Position = num4;
					long num5 = fs_pkx_list[current_pkx_index].Length - num4;
					if (num5 >= 4L)
					{
						return br_pkx_list[current_pkx_index].ReadUInt32();
					}
					if (num5 <= 0L)
					{
						if (current_pkx_index + 1 < br_pkx_list.Count)
						{
							current_pkx_index++;
							fs_pkx_list[current_pkx_index].Position = 0L;
							return br_pkx_list[current_pkx_index].ReadUInt32();
						}
						throw new EndOfStreamException(Class16.smethod_0(1649200967));
					}
					byte[] array = new byte[4];
					int num6 = (int)num5;
					br_pkx_list[current_pkx_index].ReadBytes(num6).CopyTo(array, 0);
					if (current_pkx_index + 1 >= br_pkx_list.Count)
					{
						throw new EndOfStreamException(Class16.smethod_0(1649200994));
					}
					current_pkx_index++;
					fs_pkx_list[current_pkx_index].Position = 0L;
					br_pkx_list[current_pkx_index].ReadBytes(4 - num6).CopyTo(array, num6);
					return BitConverter.ToUInt32(array, 0);
				}
				throw new EndOfStreamException(string.Format(Class16.smethod_0(1649200913), long_0));
			}
			throw new EndOfStreamException(Class16.smethod_0(1649200868));
		}

		public byte[] ReadBytes(uint count)
		{
			if (count == 0)
			{
				return Array.Empty<byte>();
			}
			if (fs_pck != null && br_pck != null)
			{
				if (count > int.MaxValue)
				{
					throw new OverflowException(string.Format(Class16.smethod_0(1649201083), count));
				}
				if (Position < PckSize)
				{
					fs_pck.Position = Position;
				}
				long num = PckSize - Position;
				byte[] array;
				if (num >= count)
				{
					array = br_pck.ReadBytes((int)count);
					if (fs_pck.Position >= PckSize && fs_pkx_list != null && fs_pkx_list.Count > 0)
					{
						current_pkx_index = 0;
						fs_pkx_list[current_pkx_index].Position = 0L;
					}
				}
				else if (num <= 0L)
				{
					if (fs_pkx_list != null && fs_pkx_list.Count != 0)
					{
						array = method_9((int)count, Position - PckSize);
					}
					else
					{
						if (Position >= fs_pck.Length)
						{
							throw new EndOfStreamException(string.Format(Class16.smethod_0(1649201128), count, Position, PckSize));
						}
						fs_pck.Position = Position;
						array = br_pck.ReadBytes((int)count);
					}
				}
				else
				{
					if (fs_pkx_list == null || fs_pkx_list.Count == 0)
					{
						throw new EndOfStreamException(string.Format(Class16.smethod_0(1649200205), count, Position, num));
					}
					array = new byte[count];
					int num2 = (int)num;
					br_pck.ReadBytes(num2).CopyTo(array, 0);
					current_pkx_index = 0;
					fs_pkx_list[current_pkx_index].Position = 0L;
					byte[] array2 = method_9((int)count - num2, 0L);
					array2.CopyTo(array, num2);
				}
				Position += count;
				return array;
			}
			throw new InvalidOperationException(Class16.smethod_0(1649201061));
		}

		private byte[] method_9(int int_0, long long_0)
		{
			if (int_0 < 0)
			{
				throw new OverflowException(string.Format(Class16.smethod_0(1649200300), int_0));
			}
			if (int_0 == 0)
			{
				return Array.Empty<byte>();
			}
			if (long_0 < 0L)
			{
				throw new EndOfStreamException(string.Format(Class16.smethod_0(1649200348), long_0));
			}
			if (fs_pkx_list != null && fs_pkx_list.Count != 0)
			{
				if (br_pkx_list != null && br_pkx_list.Count == fs_pkx_list.Count)
				{
					byte[] array = new byte[int_0];
					int num = 0;
					long num2 = 0L;
					int num3 = 0;
					int num4 = 0;
					long length;
					while (true)
					{
						if (num4 < fs_pkx_list.Count)
						{
							length = fs_pkx_list[num4].Length;
							if (long_0 >= num2 + length)
							{
								num2 += length;
								if (num4 == fs_pkx_list.Count - 1)
								{
									break;
								}
								num4++;
								continue;
							}
							num3 = num4;
						}
						long position = long_0 - num2;
						current_pkx_index = num3;
						fs_pkx_list[current_pkx_index].Position = position;
						while (num < int_0 && current_pkx_index < fs_pkx_list.Count)
						{
							long val = fs_pkx_list[current_pkx_index].Length - fs_pkx_list[current_pkx_index].Position;
							int num5 = (int)Math.Min(int_0 - num, val);
							if (num5 > 0)
							{
								BinaryReader binaryReader = br_pkx_list[current_pkx_index];
								if (binaryReader == null)
								{
									throw new InvalidOperationException(string.Format(Class16.smethod_0(1649200541), current_pkx_index));
								}
								byte[] array2 = binaryReader.ReadBytes(num5);
								array2.CopyTo(array, num);
								num += array2.Length;
							}
							if (num < int_0)
							{
								current_pkx_index++;
								if (current_pkx_index < fs_pkx_list.Count)
								{
									fs_pkx_list[current_pkx_index].Position = 0L;
								}
							}
						}
						if (num < int_0)
						{
							throw new EndOfStreamException(string.Format(Class16.smethod_0(1649200575), int_0, num));
						}
						return array;
					}
					throw new EndOfStreamException(string.Format(Class16.smethod_0(1649200477), long_0, num2 + length));
				}
				throw new InvalidOperationException(Class16.smethod_0(1649200445));
			}
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1649200382), int_0));
		}

		public void WriteBytes(byte[] bytes)
		{
			long num = PckMaxSize - Position;
			if (num >= bytes.Length)
			{
				bw_pck.Write(bytes);
				PckSize = (uint)fs_pck.Length;
				if (fs_pck.Position == PckMaxSize && fs_pkx != null)
				{
					fs_pkx.Position = 0L;
				}
			}
			else if (num <= 0L)
			{
				if (fs_pkx == null)
				{
					CreateAndOpenPkx();
				}
				method_10(bytes);
			}
			else
			{
				int num2 = (int)num;
				byte[] array = new byte[num2];
				Array.Copy(bytes, 0, array, 0, num2);
				bw_pck.Write(array);
				PckSize = PckMaxSize;
				if (fs_pkx == null)
				{
					CreateAndOpenPkx();
				}
				bw_pkx.BaseStream.Position = 0L;
				byte[] array2 = new byte[bytes.Length - num2];
				Array.Copy(bytes, num2, array2, 0, array2.Length);
				bw_pkx.Write(array2);
			}
			Position += bytes.Length;
		}

		private void method_10(byte[] byte_0)
		{
			int num = 0;
			long num2 = Position - PckMaxSize;
			while (num < byte_0.Length)
			{
				int num3 = (int)(num2 / PKX_MAX_SIZE);
				long num4 = num2 % PKX_MAX_SIZE;
				while (num3 >= bw_pkx_list.Count)
				{
					CreateAndOpenPkx();
				}
				current_pkx_index = num3;
				bw_pkx_list[current_pkx_index].BaseStream.Position = num4;
				long val = PKX_MAX_SIZE - num4;
				int num5 = (int)Math.Min(byte_0.Length - num, val);
				byte[] array = new byte[num5];
				Array.Copy(byte_0, num, array, 0, num5);
				bw_pkx_list[current_pkx_index].Write(array);
				num += num5;
				num2 += num5;
			}
		}

		public void WriteUInt32(uint value)
		{
			WriteBytes(BitConverter.GetBytes(value));
		}

		public byte[] GetFileContent(PCK_FILE_TABLE_ENTRY entry)
		{
			if (bReadingSuccess && OpenRead())
			{
				try
				{
					long physicalSize = GetPhysicalSize();
					if (physicalSize <= 0L)
					{
						return null;
					}
					if (entry.Position < 0L)
					{
						throw new InvalidDataException(string.Format(Class16.smethod_0(1649200635), entry.Position));
					}
					if (entry.CompressedSize == 0)
					{
						return (entry.OriginalSize == 0) ? Array.Empty<byte>() : null;
					}
					if (entry.Position + entry.CompressedSize > physicalSize)
					{
						SentryHelper.CaptureMessage(string.Format(Class16.smethod_0(1649199654), entry.FilePath, entry.Position, entry.CompressedSize) + string.Format(Class16.smethod_0(1649199735), physicalSize, PckSize, FileSize, (fs_pkx_list?.Count ?? 0) > 0), (SentryLevel)2, Class16.smethod_0(1649199798));
						return null;
					}
					SetPosition(entry.Position);
					byte[] array = ReadBytes(entry.CompressedSize);
					if (entry.CompressedSize < entry.OriginalSize)
					{
						array = Help.ZlibDecompress(array, entry.OriginalSize);
					}
					return array;
				}
				catch (ZlibException ex)
				{
					string text = Class16.smethod_0(1649199832) + entry.FilePath + Class16.smethod_0(1648927638) + ex.Message;
					if (ex.Message.Contains(Class16.smethod_0(1649199866)) || ex.Message.Contains(Class16.smethod_0(1648885958)))
					{
						text += string.Format(Class16.smethod_0(1649199882), entry.Position, entry.CompressedSize, entry.OriginalSize);
					}
					SentryHelper.CaptureMessage(text, (SentryLevel)2, Class16.smethod_0(1649199991));
					return null;
				}
				catch (InvalidDataException ex2)
				{
					SentryHelper.CaptureMessage(Class16.smethod_0(1649200025) + entry.FilePath + Class16.smethod_0(1648927638) + ex2.Message, (SentryLevel)2, Class16.smethod_0(1649200056));
					return null;
				}
				catch (EndOfStreamException ex3)
				{
					SentryHelper.CaptureMessage(Class16.smethod_0(1649200102) + entry.FilePath + Class16.smethod_0(1648927638) + ex3.Message, (SentryLevel)2, Class16.smethod_0(1649199110));
					return null;
				}
				catch (IOException ex4)
				{
					SentryHelper.CaptureMessage(Class16.smethod_0(1649199150) + entry.FilePath + Class16.smethod_0(1648927638) + ex4.Message, (SentryLevel)2, Class16.smethod_0(1649199183));
					return null;
				}
				catch (Exception ex5)
				{
					SentryHelper.CaptureException(ex5, Class16.smethod_0(1649199210));
					string text2 = string.Format(Class16.smethod_0(1649199235), entry.FilePath, entry.Position, entry.CompressedSize) + string.Format(Class16.smethod_0(1649199275), PckSize, FileSize, Version);
					TextStorage.TEXTS.ShowMessage(611, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, FileName, entry.FilePath, entry.Position, entry.CompressedSize, ex5.Message + Class16.smethod_0(1649199323) + text2);
					return null;
				}
			}
			return null;
		}

		public byte[] GetFileContent(int entryIndex)
		{
			if (entryIndex >= 0 && FileTable != null && entryIndex < FileTable.Length)
			{
				return GetFileContent(FileTable[entryIndex]);
			}
			return null;
		}

		public int WriteFile(int entryIndex, byte[] bytes)
		{
			if (!OpenWrite())
			{
				return -1;
			}
			PCK_FILE_TABLE_ENTRY pCK_FILE_TABLE_ENTRY = FileTable[entryIndex];
			pCK_FILE_TABLE_ENTRY.OriginalSize = (uint)bytes.Length;
			bytes = Help.ZlibCompress(bytes);
			if (bytes.Length > pCK_FILE_TABLE_ENTRY.CompressedSize && entryIndex != LastFilePositionIndex)
			{
				pCK_FILE_TABLE_ENTRY.Position = MaxFilePosition;
				SetPosition(pCK_FILE_TABLE_ENTRY.Position);
				WriteBytes(bytes);
				MaxFilePosition = Position;
				LastFilePositionIndex = entryIndex;
			}
			else
			{
				SetPosition(pCK_FILE_TABLE_ENTRY.Position);
				WriteBytes(bytes);
				if (entryIndex == LastFilePositionIndex)
				{
					MaxFilePosition = Position;
				}
			}
			pCK_FILE_TABLE_ENTRY.CompressedSize = (uint)bytes.Length;
			FileTable[entryIndex] = pCK_FILE_TABLE_ENTRY;
			return entryIndex;
		}

		public bool AddFile(string filePath, byte[] bytes)
		{
			PCK_FILE_TABLE_ENTRY element = new PCK_FILE_TABLE_ENTRY(filePath);
			element.OriginalSize = (uint)bytes.Length;
			bytes = Help.ZlibCompress(bytes);
			if (!OpenWrite())
			{
				return false;
			}
			element.Position = MaxFilePosition;
			SetPosition(element.Position);
			WriteBytes(bytes);
			MaxFilePosition = Position;
			element.CompressedSize = (uint)bytes.Length;
			AddElementToArray(ref FileTable, element, toBegin: false);
			EntryCount++;
			return true;
		}

		public bool Save(bool bSetPhysicalSize)
		{
			if (!OpenWrite())
			{
				return false;
			}
			if (!WriteFileTable(bRandCompression: false))
			{
				CloseWrite();
				return false;
			}
			MetaData.XorFileTable(settings.FTO_KEY, Version);
			WriteBytes(MetaData.GetBytes(Version));
			MetaData.XorFileTable(settings.FTO_KEY, Version);
			if (settings.ProtectionLevel >= 4)
			{
				Version.GetFooterSize();
				int num = ((Version == ArchiveVersion.V3) ? 280 : 272);
				if (settings.MetaDataShift > num + 8)
				{
					WriteBytes(GenerateTrash(settings.MetaDataShift - num - 8));
				}
			}
			if (Version == ArchiveVersion.V3)
			{
				WriteUInt32(0u);
			}
			WriteUInt32((uint)EntryCount);
			WriteUInt32(Version.GetVersionValue());
			FileSize = Position;
			fs_pck.Position = 4L;
			if (Version == ArchiveVersion.V3)
			{
				bw_pck.Write(FileSize);
			}
			else
			{
				bw_pck.Write((uint)FileSize);
			}
			bw_pck?.Flush();
			fs_pck?.Flush();
			if (bw_pkx_list != null)
			{
				foreach (BinaryWriter item in bw_pkx_list)
				{
					item?.Flush();
				}
			}
			if (fs_pkx_list != null)
			{
				foreach (FileStream item2 in fs_pkx_list)
				{
					item2?.Flush();
				}
			}
			if (FileSize <= PckMaxSize)
			{
				if (bw_pkx_list != null)
				{
					foreach (BinaryWriter item3 in bw_pkx_list)
					{
						item3?.Close();
					}
					bw_pkx_list.Clear();
				}
				if (fs_pkx_list != null)
				{
					foreach (FileStream item4 in fs_pkx_list)
					{
						item4?.Close();
					}
					fs_pkx_list.Clear();
				}
				int num2 = 0;
				while (true)
				{
					string pkxName = GetPkxName(FileName, num2);
					if (!File.Exists(pkxName))
					{
						break;
					}
					try
					{
						File.Delete(pkxName);
					}
					catch
					{
					}
					num2++;
				}
				fs_pck.SetLength(FileSize);
			}
			CloseWrite();
			return true;
		}

		private bool method_11(Stream stream_0, out long long_0, string string_0)
		{
			long_0 = 0L;
			if (stream_0 == null)
			{
				return true;
			}
			try
			{
				long_0 = stream_0.Length;
				return true;
			}
			catch (IOException ex)
			{
				SentryHelper.CaptureException(ex, string_0);
			}
			catch (ObjectDisposedException ex2)
			{
				SentryHelper.CaptureException(ex2, string_0);
			}
			return false;
		}

		public void SetPhysicalSize(long newFileSize)
		{
			if (newFileSize <= PckMaxSize)
			{
				if (br_pkx_list != null)
				{
					foreach (BinaryReader item in br_pkx_list)
					{
						item?.Close();
					}
					br_pkx_list.Clear();
				}
				if (fs_pkx_list != null)
				{
					foreach (FileStream item2 in fs_pkx_list)
					{
						item2?.Close();
					}
					fs_pkx_list.Clear();
				}
				int num = 0;
				while (true)
				{
					string pkxName = GetPkxName(FileName, num);
					if (!File.Exists(pkxName))
					{
						break;
					}
					File.Delete(pkxName);
					num++;
				}
				current_pkx_index = 0;
				fs_pck.SetLength(newFileSize);
			}
			else
			{
				long length = newFileSize - PckMaxSize;
				if (fs_pkx_list != null && fs_pkx_list.Count > 0)
				{
					fs_pkx_list[fs_pkx_list.Count - 1].SetLength(length);
				}
			}
			FileSize = newFileSize;
		}

		public long GetPhysicalSize()
		{
			if (!IsOpenedWrite && !IsOpenedRead)
			{
				OpenRead();
			}
			if (bReadingSuccess)
			{
				if (!method_11(fs_pck, out var long_, Class16.smethod_0(1649199338)))
				{
					return -1L;
				}
				if (fs_pkx_list != null)
				{
					foreach (FileStream item in fs_pkx_list)
					{
						if (method_11(item, out var long_2, Class16.smethod_0(1649199368)))
						{
							long_ += long_2;
							continue;
						}
						return -1L;
					}
				}
				return long_;
			}
			return -1L;
		}

		public bool IsProtectionActivated()
		{
			return settings.ProtectionLevel > 0;
		}

		public void RandomizeFileTable()
		{
			List<int> list = new List<int>(EntryCount);
			for (int i = 0; i < EntryCount; i++)
			{
				list.Add(i);
			}
			PCK_FILE_TABLE_ENTRY[] array = new PCK_FILE_TABLE_ENTRY[EntryCount];
			for (int j = 0; j < EntryCount; j++)
			{
				int index = RND.GenerateRnd(0, list.Count - 1);
				array[j] = FileTable[list[index]];
				list.RemoveAt(index);
			}
			FileTable = array;
		}

		public bool WriteFakeFileTables()
		{
			if (!OpenWrite())
			{
				return false;
			}
			int num = RND.GenerateRnd(EntryCount * 2, EntryCount * 5);
			FileStream fileStream = fs_pkx;
			if (fileStream != null && fileStream.Length > 1709872960L)
			{
				num /= 2;
			}
			FileStream fileStream2 = fs_pkx;
			if (fileStream2 != null && fileStream2.Length > 1809872960L)
			{
				num /= 2;
			}
			FileStream fileStream3 = fs_pkx;
			if (fileStream3 != null && fileStream3.Length > 1909872960L)
			{
				num /= 10;
			}
			int num2 = RND.GenerateRnd(int.MinValue, int.MaxValue);
			int num3 = RND.GenerateRnd(int.MinValue, int.MaxValue);
			int num4 = num / 50 + 1;
			int num5 = RND.GenerateRnd(0, Math.Max(0, num - EntryCount - 1));
			for (int i = 0; i < num; i++)
			{
				int num6 = i % EntryCount;
				int num7 = RND.GenerateRnd(0, EntryCount - 1);
				byte[] file_path = FileTable[num6].file_path;
				FileTable[num6].file_path = FileTable[num7].file_path;
				byte[] bytes = FileTable[num6].GetBytes(bCompress: true, RND.GenerateRnd(3, 7), Version);
				int num8 = bytes.Length;
				WriteUInt32((uint)(num8 ^ num2));
				WriteUInt32((uint)(num8 ^ num3));
				WriteBytes(bytes);
				FileTable[num6].file_path = file_path;
				if (Position > 3900000000L)
				{
					break;
				}
				if (i <= num5 || i > EntryCount + num5)
				{
					if (i == num5)
					{
						num2 = settings.KEY_1;
						num3 = settings.KEY_2;
						Application.DoEvents();
					}
					else if (i % num4 == 0)
					{
						num2 = RND.GenerateRnd(int.MinValue, int.MaxValue);
						num3 = RND.GenerateRnd(int.MinValue, int.MaxValue);
						Application.DoEvents();
					}
				}
			}
			return true;
		}
	}

	public Hashtable ExtraFiles;

	public static CommonStorage CStorage;

	public string FileName;

	public string BaseName;

	public PCK_STRUCT Pck;

	public GAMES Game;

	public PCK_PROTECTION_OPTIONS options;

	public PCK_PROTECTION_SETTINGS settings;

	public bool FileChanged;

	public bool FileLoaded;

	public IDictionary<string, int> FileTableIndices;

	public List<string> SkiPaths;

	public List<string> EcmPaths;

	public List<string> MalePaths;

	public List<string> FemalePaths;

	public List<string> SkiAndEcmPaths;

	public string[] Paths;

	private static byte[] byte_0;

	public int LastFileIndex;

	public long OriginalSize
	{
		get
		{
			long num = 0L;
			if (Pck?.FileTable != null)
			{
				PCK_FILE_TABLE_ENTRY[] fileTable = Pck.FileTable;
				for (int i = 0; i < fileTable.Length; i++)
				{
					PCK_FILE_TABLE_ENTRY pCK_FILE_TABLE_ENTRY = fileTable[i];
					num += pCK_FILE_TABLE_ENTRY.OriginalSize;
				}
			}
			return num;
		}
	}

	public long CompressedSize
	{
		get
		{
			long num = 0L;
			if (Pck?.FileTable != null)
			{
				PCK_FILE_TABLE_ENTRY[] fileTable = Pck.FileTable;
				for (int i = 0; i < fileTable.Length; i++)
				{
					PCK_FILE_TABLE_ENTRY pCK_FILE_TABLE_ENTRY = fileTable[i];
					num += pCK_FILE_TABLE_ENTRY.CompressedSize;
				}
			}
			return num;
		}
	}

	public int FileCount => (Pck?.FileTable?.Length).GetValueOrDefault();

	public PCK(string fileName, GAMES game, PCK_PROTECTION_OPTIONS options)
	{
		FileName = fileName;
		BaseName = System.IO.Path.GetFileNameWithoutExtension(fileName);
		if (options != null)
		{
			game = options.Game;
			this.options = options;
		}
		Game = game;
		if (!File.Exists(fileName))
		{
			return;
		}
		if (game <= GAMES.UNKNOWN_GAME)
		{
			if (DetectGame())
			{
				Pck.bReadingSuccess = Pck.ReadFileTable();
			}
			else
			{
				TextStorage.TEXTS.ShowErrorMessage(566);
			}
		}
		else
		{
			SetKeys();
			Pck = new PCK_STRUCT(fileName, bReadFileTable: true, settings);
		}
		if (FileLoaded = Pck.bReadingSuccess)
		{
			CreateFileTableDictionary();
		}
		else
		{
			Pck?.CloseRead();
		}
	}

	static PCK()
	{
		byte_0 = Encoding.ASCII.GetBytes(Class16.smethod_0(1648893557));
	}

	public bool DetectGame()
	{
		Pck = new PCK_STRUCT(FileName);
		for (int i = 1; i <= 8; i++)
		{
			try
			{
				Game = (GAMES)i;
				SetKeys();
				int kEY_ = settings.KEY_1;
				long fileTableOffset = Pck.MetaData.FileTableOffset;
				fileTableOffset = ((Pck.Version != ArchiveVersion.V3) ? ((uint)((int)fileTableOffset ^ kEY_)) : (fileTableOffset ^ kEY_));
				if (fileTableOffset < 0L || fileTableOffset > Pck.FileSize || Pck.FileSize - fileTableOffset < 50L)
				{
					continue;
				}
				Pck.SetPosition(fileTableOffset);
				uint num = Pck.ReadUInt32() ^ (uint)settings.KEY_1;
				int entrySize = Pck.Version.GetEntrySize();
				if (num <= entrySize)
				{
					uint num2 = Pck.ReadUInt32() ^ (uint)settings.KEY_2;
					if (num == num2)
					{
						Pck.settings = settings;
						Pck.MetaData.FileTableOffset = fileTableOffset;
						return true;
					}
				}
			}
			catch
			{
			}
		}
		return false;
	}

	public void SetKeys()
	{
		PCK_PROTECTION_OPTIONS pCK_PROTECTION_OPTIONS = options;
		if (pCK_PROTECTION_OPTIONS != null && pCK_PROTECTION_OPTIONS.IsProtected && options.KeysChanged)
		{
			settings = new PCK_PROTECTION_SETTINGS(options.KEY_1, options.KEY_2);
			if (options.FTO_KEY_Changed)
			{
				settings.FTO_KEY = options.FTO_KEY;
			}
			if (options.MetaDataShifted)
			{
				settings.MetaDataShift = (ushort)options.MetaDataShift;
			}
		}
		else
		{
			settings = GetDefaultKeys(Game);
		}
	}

	public static PCK_PROTECTION_SETTINGS GetDefaultKeys(GAMES game)
	{
		return game switch
		{
			GAMES.RWPD => new PCK_PROTECTION_SETTINGS(711164174, 839959661), 
			GAMES.ESO => new PCK_PROTECTION_SETTINGS(-1228069623, 1822409141), 
			GAMES.FW => new PCK_PROTECTION_SETTINGS(566434367, 408690725), 
			_ => new PCK_PROTECTION_SETTINGS(-1466731422, -240896429), 
		};
	}

	public unsafe static PCK_PROTECTION_SETTINGS GetDefaultSettings(string fileName, GAMES* game)
	{
		int num = (int)(*game);
		if (num > 0)
		{
			return GetDefaultKeys((GAMES)num);
		}
		PCK pCK = new PCK(fileName, GAMES.UNKNOWN_GAME, null);
		pCK.Close();
		*game = pCK.Game;
		return pCK.settings;
	}

	public void CreateFileTableDictionary()
	{
		FileTableIndices = new Dictionary<string, int>(Pck.EntryCount);
		bool flag = false;
		for (int i = 0; i < Pck.EntryCount; i++)
		{
			string text = Pck.FileTable[i].FilePath.ToLowerInvariant();
			if (FileTableIndices.ContainsKey(text))
			{
				if (!flag)
				{
					TextStorage.TEXTS.ShowMessage(686, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, i, text, FileName);
					flag = true;
				}
			}
			else
			{
				FileTableIndices.Add(text, i);
			}
		}
	}

	public void CreatePathsArray()
	{
		if (FileTableIndices != null)
		{
			Paths = new string[FileTableIndices.Keys.Count];
			FileTableIndices.Keys.CopyTo(Paths, 0);
			Array.Reverse(Paths);
		}
		else
		{
			Paths = new string[0];
		}
	}

	public static string FixPath(string path)
	{
		int num = path.IndexOf('\0');
		string text = ((num >= 0) ? path.Substring(0, num) : path).Trim().ToLowerInvariant().Replace('/', '\\');
		while (text.Contains(Class16.smethod_0(1648903386)))
		{
			text = text.Replace(Class16.smethod_0(1648903386), Class16.smethod_0(1648927580));
		}
		return text;
	}

	public unsafe bool TryGetFileIndex(ref string filePath, int* fileIndex)
	{
		if (filePath != null && FileTableIndices != null)
		{
			string key = (filePath = FixPath(filePath));
			if (!FileTableIndices.TryGetValue(key, out *fileIndex))
			{
				*fileIndex = -1;
				int num = filePath.IndexOf(Class16.smethod_0(1648927580));
				if (num > -1 && num + 1 < filePath.Length)
				{
					string text = filePath.Substring(num + 1);
					if (FileTableIndices.TryGetValue(text, out *fileIndex))
					{
						filePath = text;
					}
					else
					{
						*fileIndex = -1;
					}
				}
			}
			LastFileIndex = *fileIndex;
			return *fileIndex > -1;
		}
		return false;
	}

	public byte[] GetFileB(int fileIndex)
	{
		return Pck.GetFileContent(fileIndex);
	}

	public unsafe byte[] GetFileB(string filePath)
	{
		int entryIndex = -1;
		if (TryGetFileIndex(ref filePath, &entryIndex))
		{
			return Pck.GetFileContent(entryIndex);
		}
		return null;
	}

	public string GetFileU(string filePath)
	{
		byte[] fileB = GetFileB(filePath);
		if (fileB == null)
		{
			return null;
		}
		return Encoding.Unicode.GetString(fileB);
	}

	public string GetFileGBK(string filePath)
	{
		byte[] fileB = GetFileB(filePath);
		if (fileB == null)
		{
			return null;
		}
		return Encoding.GetEncoding(Class16.smethod_0(1648985403)).GetString(fileB);
	}

	public uint GetFileSize(int fileIndex, bool bCompressed)
	{
		if (!bCompressed)
		{
			return Pck.FileTable[fileIndex].OriginalSize;
		}
		return Pck.FileTable[fileIndex].CompressedSize;
	}

	public unsafe bool IsFileExist(string filePath)
	{
		int num = -1;
		return TryGetFileIndex(ref filePath, &num);
	}

	public unsafe bool WriteFile(string filePath, byte[] content)
	{
		int entryIndex = -1;
		if (TryGetFileIndex(ref filePath, &entryIndex))
		{
			int num = Pck.WriteFile(entryIndex, content);
			if (num > -1)
			{
				FileTableIndices[filePath] = num;
				return true;
			}
		}
		return false;
	}

	public bool WriteFile(string filePath, string content)
	{
		return WriteFile(filePath, Encoding.UTF8.GetBytes(content));
	}

	private bool method_0(string string_0, string string_1)
	{
		string_0 = FixPath(string_0);
		if (FileTableIndices.ContainsKey(string_0))
		{
			RemoveArrayElement(ref Pck.FileTable, FileTableIndices[string_0]);
			FileTableIndices.Remove(string_0);
			Pck.EntryCount--;
		}
		if (Pck.AddFile(string_0, File.ReadAllBytes(string_1)))
		{
			FileTableIndices.Add(string_0, Pck.FileTable.Length - 1);
			return true;
		}
		return false;
	}

	public void Close()
	{
		Pck?.Close();
	}

	public bool Save(bool bSetPhysicalSize)
	{
		return Pck.Save(bSetPhysicalSize);
	}

	public static bool Defragment(string pckFileName)
	{
		GAMES game = CommonStorage.Params.Game;
		PCK pCK = new PCK(pckFileName, game, PCK_PROTECTION_OPTIONS.ImportFromParams(CommonStorage.Params));
		return pCK.Pck.Save(bSetPhysicalSize: true);
	}

	public bool IsSizeBroken()
	{
		return Pck.FileSize != Pck.GetPhysicalSize();
	}

	public bool ExtractDir(string pathInPck, string pathOnDisc)
	{
		if (pathInPck != null && FileTableIndices != null)
		{
			pathInPck = FixPath(pathInPck);
			string extractionRoot = System.IO.Path.GetFullPath(pathOnDisc);
			string extractionPrefix = extractionRoot.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar) + System.IO.Path.DirectorySeparatorChar;
			Directory.CreateDirectory(extractionRoot);
			if (!pathInPck.EndsWith(Class16.smethod_0(1648927580)))
			{
				pathInPck += Class16.smethod_0(1648927580);
			}
			foreach (KeyValuePair<string, int> fileTableIndex in FileTableIndices)
			{
				string key = fileTableIndex.Key;
				if (!key.StartsWith(pathInPck))
				{
					continue;
				}
				string text = key.Substring(pathInPck.Length);
				string[] array = text.Split('\\');
				if (array.Length > 1)
				{
					string text2 = pathOnDisc;
					for (int i = 0; i < array.Length - 1; i++)
					{
						text2 = System.IO.Path.Combine(text2, array[i]);
						if (!Directory.Exists(text2))
						{
							Directory.CreateDirectory(text2);
						}
					}
				}
				string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(extractionRoot, text));
				if (!path.StartsWith(extractionPrefix, StringComparison.OrdinalIgnoreCase))
				{
					throw new InvalidDataException("O caminho do arquivo PCK sai da pasta de extração permitida: " + key);
				}
				byte[] fileContent = Pck.GetFileContent(fileTableIndex.Value);
				if (fileContent != null)
				{
					string directoryName = System.IO.Path.GetDirectoryName(path);
					if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					File.WriteAllBytes(path, fileContent);
				}
				else
				{
					throw new InvalidDataException("O arquivo não pôde ser lido do PCK: " + key);
				}
			}
			return true;
		}
		return false;
	}

	public List<string> GetFilesList(string dirPath)
	{
		if (dirPath != null && FileTableIndices != null)
		{
			if (Paths == null)
			{
				CreatePathsArray();
			}
			dirPath = FixPath(dirPath) + Class16.smethod_0(1648927580);
			List<string> list = new List<string>();
			int num = Math.Max(0, LastFileIndex - 50);
			int num2 = Math.Min(Paths.Length, LastFileIndex + 50);
			for (int i = num; i < num2; i++)
			{
				if (Paths[i].StartsWith(dirPath))
				{
					list.Add(Paths[i]);
				}
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return list;
		}
		return null;
	}

	public List<byte[]> GetFilesB(string dirPath)
	{
		List<string> filesList = GetFilesList(dirPath);
		if (filesList == null)
		{
			return null;
		}
		filesList.Sort();
		List<byte[]> list = new List<byte[]>();
		foreach (string item in filesList)
		{
			byte[] fileContent = Pck.GetFileContent(FileTableIndices[item]);
			if (fileContent != null)
			{
				list.Add(fileContent);
			}
		}
		return list;
	}

	public unsafe static bool Protect(string fileName, GAMES games_0, PCK_PROTECTION_SETTINGS pck_PROTECTION_SETTINGS_0, PCK_PROTECTION_OPTIONS options, Hashtable extraFiles, string clientDir, string customFile, string customFile2)
	{
		PCK pCK = null;
		try
		{
			pCK = new PCK(fileName, games_0, null);
			if (!pCK.FileLoaded)
			{
				return false;
			}
			ref PCK_STRUCT pck = ref pCK.Pck;
			bool flag = false;
			if (GetPckProtectionLevel(pck, null, null, &flag) > 0)
			{
				throw new ApplicationException(Class16.smethod_0(1649199406) + fileName);
			}
			pck.settings = pck_PROTECTION_SETTINGS_0;
			pck.settings.ProtectionLevel = 0;
			if (!pck.OpenWrite())
			{
				return false;
			}
			if (pck_PROTECTION_SETTINGS_0.ExtraFilesMask != 0)
			{
				pCK.ExtraFiles = extraFiles;
				if (options.ServerlistPath != null)
				{
					pCK.AddExtraFile(Class16.smethod_0(1649048735), clientDir + Class16.smethod_0(1649199435), options.ServerlistPath);
				}
				if (options.ElementsPath != null)
				{
					pCK.AddExtraFile(Class16.smethod_0(1648906367), clientDir + Class16.smethod_0(1649199472), options.ElementsPath);
				}
				if (options.GShopPath != null)
				{
					pCK.AddExtraFile(Class16.smethod_0(1648906382), clientDir + Class16.smethod_0(1649199497), options.GShopPath);
				}
				if (options.TasksPath != null)
				{
					pCK.AddExtraFile(Class16.smethod_0(1648906421), clientDir + Class16.smethod_0(1649199527), options.TasksPath);
				}
			}
			pck.RandomizeFileTable();
			Application.DoEvents();
			pck.SetPosition(pck.MaxFilePosition);
			if (options.TrashBeforeFileTableOffset)
			{
				pck.WriteBytes(GenerateTrash(RND.GenerateRnd(10, 1024)));
				pck.MaxFilePosition = pck.Position;
			}
			if (options.RandomizedFileTableAdded)
			{
				pck.WriteFakeFileTables();
			}
			Application.DoEvents();
			pck.MaxFilePosition = pck.Position;
			pck.WriteFileTable(bRandCompression: true);
			Application.DoEvents();
			if (pck.Position < 3800000000L && options.RandomizedFileTableAdded)
			{
				pck.WriteFakeFileTables();
				Application.DoEvents();
			}
			int fTO_KEY = (options.FTO_KEY_Changed ? options.FTO_KEY : options.KEY_1);
			uint reserved = pck.MetaData.Reserved;
			byte[] angelicaSign = pck.MetaData.AngelicaSign;
			if (options.AngelicaSignChanged)
			{
				pck.MetaData.Reserved = 0u;
				pck.MetaData.AngelicaSign = GenerateTrash(252);
			}
			else
			{
				pck.MetaData.AngelicaSign = ToBytesA(Class16.smethod_0(1649199549), 252);
			}
			pck.MetaData.XorFileTable(fTO_KEY, pck.Version);
			pck.WriteBytes(pck.MetaData.GetBytes(pck.Version));
			pck.MetaData.XorFileTable(fTO_KEY, pck.Version);
			if (options.MetaDataShifted)
			{
				pck.WriteBytes(GenerateTrash((int)options.MetaDataTrashLen));
			}
			pck.WriteUInt32((uint)pck.EntryCount);
			pck.WriteUInt32(pck.Version.GetVersionValue());
			pck.MaxFilePosition = pck.Position;
			pck.FileSize = pck.Position;
			pck.fs_pck.Position = 4L;
			if (pck.Version == ArchiveVersion.V3)
			{
				pck.bw_pck.Write(pck.FileSize);
			}
			else
			{
				pck.bw_pck.Write((uint)pck.FileSize);
			}
			if (options.TrashInTheEOF)
			{
				pck.SetPosition(pck.MaxFilePosition);
				pck.WriteBytes(GenerateTrash(RND.GenerateRnd(10240, 102400)));
				pck.WriteBytes(new byte[128]);
				pck.WriteBytes(byte_0);
				pck.WriteBytes(new byte[128]);
				pck.WriteBytes(options.ProjectUnique);
				pck.WriteBytes(new byte[1] { (byte)pck_PROTECTION_SETTINGS_0.ProtectionLevel });
				pck.MetaData.FileTableOffset = (long)RND.GenerateRnd(1073741823.5, 4294967294.0);
				pck.MetaData.Reserved = reserved;
				pck.MetaData.AngelicaSign = angelicaSign;
				pck.WriteBytes(pck.MetaData.GetBytes(pck.Version));
				pck.WriteUInt32((uint)RND.GenerateRnd((double)pck.EntryCount / 1.2, (double)pck.EntryCount * 1.2));
				pck.WriteUInt32(pck.Version.GetVersionValue());
			}
			return true;
		}
		catch (ApplicationException ex)
		{
			SentryHelper.CaptureMessage(Class16.smethod_0(1649199585) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649199613));
			TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, ex.Message);
			return false;
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649194532));
			TextStorage tEXTS = TextStorage.TEXTS;
			object[] obj = new object[3] { fileName, null, null };
			object obj2;
			if (pCK == null)
			{
				obj2 = null;
			}
			else
			{
				PCK_STRUCT pck2 = pCK.Pck;
				if (pck2 == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = pck2.Position.ToString();
					if (obj2 != null)
					{
						goto IL_050c;
					}
				}
			}
			obj2 = Class16.smethod_0(1649194550);
			goto IL_050c;
			IL_050c:
			obj[1] = obj2;
			obj[2] = ex2.Message;
			tEXTS.ShowMessage(646, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, obj);
			return false;
		}
		finally
		{
			pCK?.Close();
		}
	}

	public unsafe static bool UnProtect(string fileName, GAMES game, PCK_PROTECTION_SETTINGS pck_PROTECTION_SETTINGS_0, PCK_PROTECTION_OPTIONS pck_PROTECTION_OPTIONS_0, bool ignoreSignChecking)
	{
		PCK pCK = null;
		try
		{
			bool flag = !TextStorage.TEXTS.DontShowExceptions;
			TextStorage.TEXTS.DontShowExceptions = true;
			pCK = new PCK(fileName, game, pck_PROTECTION_OPTIONS_0);
			string lastErrorText = CommonStorage.Texts.LastErrorText;
			if (!pCK.FileLoaded)
			{
				pCK = new PCK(fileName, game, null);
				if (flag)
				{
					TextStorage.TEXTS.DontShowExceptions = false;
				}
				if (!pCK.FileLoaded)
				{
					CommonStorage.Texts.LastErrorText = lastErrorText;
					CommonStorage.Texts.ShowLastError();
					return false;
				}
				if (pCK.Pck.FileSize == pCK.Pck.GetPhysicalSize())
				{
					pCK.Close();
					return true;
				}
			}
			if (flag)
			{
				TextStorage.TEXTS.DontShowExceptions = false;
			}
			PCK_STRUCT pck = pCK.Pck;
			if (!ignoreSignChecking)
			{
				bool flag2 = false;
				int pckProtectionLevel = GetPckProtectionLevel(pck, pck_PROTECTION_OPTIONS_0.ProjectName, pck_PROTECTION_OPTIONS_0.ProjectUnique, &flag2);
				if (pckProtectionLevel < 1)
				{
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649194561), Class16.smethod_0(1649194596)), pck.FileName), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					pCK.Close();
					return false;
				}
				if (!flag2)
				{
					TextStorage.TEXTS.ShowErrorMessage(632);
					pCK.Close();
					return false;
				}
				if (pckProtectionLevel != pck_PROTECTION_SETTINGS_0.ProtectionLevel)
				{
					TextStorage.TEXTS.ShowMessage(634, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, fileName, pckProtectionLevel);
					pCK.Close();
					return false;
				}
			}
			pck.settings = GetDefaultKeys(game);
			pck.MetaData.Reserved = 0u;
			pck.MetaData.AngelicaSign = ToBytesA(Class16.smethod_0(1649199549), 252);
			if (!pck.OpenWrite())
			{
				return false;
			}
			bool result = pCK.Save(bSetPhysicalSize: true);
			pck.OpenWrite();
			return result;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649194617));
			if (ex is ApplicationException)
			{
				TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, ex.Message);
				goto IL_0266;
			}
			TextStorage tEXTS = TextStorage.TEXTS;
			object[] obj = new object[3] { fileName, null, null };
			object obj2;
			if (pCK == null)
			{
				obj2 = null;
			}
			else
			{
				PCK_STRUCT pck2 = pCK.Pck;
				if (pck2 == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = pck2.Position.ToString();
					if (obj2 != null)
					{
						goto IL_0256;
					}
				}
			}
			obj2 = Class16.smethod_0(1649194550);
			goto IL_0256;
			IL_0266:
			return false;
			IL_0256:
			obj[1] = obj2;
			obj[2] = ex.Message;
			tEXTS.ShowMessage(608, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, obj);
			goto IL_0266;
		}
		finally
		{
			pCK?.Close();
		}
	}

	public static bool IsArchiveProtected(string fileName, GAMES games_0)
	{
		bool flag = true;
		PCK pCK = null;
		try
		{
			bool flag2 = !TextStorage.TEXTS.DontShowExceptions;
			TextStorage.TEXTS.DontShowExceptions = true;
			pCK = new PCK(fileName, games_0, null);
			if (pCK.FileLoaded)
			{
				flag = pCK.Pck.IsProtectionActivated() && flag;
			}
			if (flag2)
			{
				TextStorage.TEXTS.DontShowExceptions = false;
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649194645));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649194666), Class16.smethod_0(1649194698)), fileName), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		pCK?.Close();
		return flag;
	}

	public unsafe static sbyte GetPckProtectionLevel(PCK_STRUCT pck, string projectName, byte[] projUnique, bool* bProjectAccepted)
	{
		sbyte b = 0;
		int num = byte_0.Length + 256;
		long num2 = num + 297;
		if (pck.FileSize > num2)
		{
			pck.SetPosition(pck.GetPhysicalSize() - num2);
			byte[] byte_ = pck.ReadBytes((uint)num);
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				memoryStream.Write(new byte[128], 0, 128);
				memoryStream.Write(byte_0, 0, byte_0.Length);
				memoryStream.Write(new byte[128], 0, 128);
				if (IsArraysEquals(byte_, memoryStream.ToArray()))
				{
					byte[] byte_2 = pck.ReadBytes(16u);
					b = (sbyte)pck.ReadBytes(1u)[0];
					if (b > 15)
					{
						b -= 15;
						byte[] bytes = Encoding.GetEncoding(1251).GetBytes(projectName);
						byte[] byte_3 = RSMD5._md5.ComputeHash(bytes);
						*bProjectAccepted = IsArraysEquals(byte_3, byte_2);
					}
					else
					{
						*bProjectAccepted = IsArraysEquals(projUnique, byte_2);
					}
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		return b;
	}

	public void AddExtraFile(string fileKey, string extraFileName, string pathInArchive)
	{
		if (pathInArchive == null)
		{
			return;
		}
		if (!File.Exists(extraFileName))
		{
			throw new ApplicationException(Class16.smethod_0(1649194731) + extraFileName);
		}
		string text = (string)ExtraFiles[fileKey];
		if (text != null && (text.Contains(Class16.smethod_0(1648927580)) ? FileName.EndsWith(text) : (System.IO.Path.GetFileName(FileName) == text)))
		{
			string string_ = ((Game == GAMES.UNKNOWN_GAME) ? string.Empty : (BaseName + Class16.smethod_0(1648927580))) + pathInArchive;
			if (!method_0(string_, extraFileName))
			{
				throw new ApplicationException(Class16.smethod_0(1649194760) + extraFileName);
			}
		}
	}

	public List<string> GetTexturesPaths(string dirPath, string name, bool bFromBeginning)
	{
		if (dirPath != null && FileTableIndices != null)
		{
			List<string> list = new List<string>();
			dirPath = FixPath(dirPath);
			int num = ((!bFromBeginning) ? Math.Max(0, LastFileIndex - 1000) : 0);
			int num2 = (bFromBeginning ? Paths.Length : Math.Min(Paths.Length, LastFileIndex + 1000));
			string text = dirPath + Class16.smethod_0(1649194793);
			for (int i = num; i < num2; i++)
			{
				if (Paths[i].StartsWith(text) && (Paths[i].StartsWith(text + Class16.smethod_0(1648923968) + name) || Paths[i].StartsWith(text + Class16.smethod_0(1649194812))))
				{
					list.Add(Paths[i]);
				}
			}
			if (list.Count == 0 && !bFromBeginning)
			{
				return GetTexturesPaths(dirPath, name, bFromBeginning: true);
			}
			return list;
		}
		return null;
	}

	public string GetTexturesDir(string dirPath, string name, bool bFromBeginning)
	{
		if (dirPath != null && FileTableIndices != null)
		{
			dirPath = FixPath(dirPath);
			int num = ((!bFromBeginning) ? Math.Max(0, LastFileIndex - 50) : 0);
			int num2 = (bFromBeginning ? Paths.Length : Math.Min(Paths.Length, LastFileIndex + 50));
			string text = dirPath + Class16.smethod_0(1649194793);
			int num3 = num;
			while (true)
			{
				if (num3 < num2)
				{
					if (Paths[num3].StartsWith(text))
					{
						if (Paths[num3].StartsWith(text + Class16.smethod_0(1648923968) + name))
						{
							return text + Class16.smethod_0(1648923968) + name;
						}
						if (Paths[num3].StartsWith(text + Class16.smethod_0(1649194812)))
						{
							break;
						}
					}
					num3++;
					continue;
				}
				if (!bFromBeginning)
				{
					return GetTexturesDir(dirPath, name, bFromBeginning: true);
				}
				return null;
			}
			return text + Class16.smethod_0(1649194812);
		}
		return null;
	}

	public static byte[] ToBytesGBK(string value, int length)
	{
		byte[] array = new byte[length];
		if (!string.IsNullOrEmpty(value))
		{
			byte[] bytes = Encoding.GetEncoding(Class16.smethod_0(1648921191)).GetBytes(value.Replace('/', '\\'));
			Array.Copy(bytes, array, Math.Min(bytes.Length, length));
		}
		return array;
	}

	public static byte[] ToBytesA(string value, int length)
	{
		byte[] array = new byte[length];
		if (!string.IsNullOrEmpty(value))
		{
			byte[] bytes = Encoding.ASCII.GetBytes(value);
			Array.Copy(bytes, array, Math.Min(bytes.Length, length));
		}
		return array;
	}

	public static T ReadStruct<T>(byte[] bytes) where T : struct
	{
		GCHandle gCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
		try
		{
			return Marshal.PtrToStructure<T>(gCHandle.AddrOfPinnedObject());
		}
		finally
		{
			gCHandle.Free();
		}
	}

	public static byte[] GetStructBytes<T>(T obj) where T : struct
	{
		int num = Marshal.SizeOf<T>();
		byte[] array = new byte[num];
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		try
		{
			Marshal.StructureToPtr(obj, intPtr, fDeleteOld: false);
			Marshal.Copy(intPtr, array, 0, num);
			return array;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static void AddElementToArray<T>(ref T[] array, T element, bool toBegin)
	{
		if (array == null)
		{
			array = new T[1] { element };
			return;
		}
		T[] array2 = new T[array.Length + 1];
		if (toBegin)
		{
			array2[0] = element;
			Array.Copy(array, 0, array2, 1, array.Length);
		}
		else
		{
			Array.Copy(array, array2, array.Length);
			array2[array.Length] = element;
		}
		array = array2;
	}

	public static void RemoveArrayElement<T>(ref T[] array, int index)
	{
		if (array != null && index >= 0 && index < array.Length)
		{
			T[] array2 = new T[array.Length - 1];
			if (index > 0)
			{
				Array.Copy(array, 0, array2, 0, index);
			}
			if (index < array.Length - 1)
			{
				Array.Copy(array, index + 1, array2, index, array.Length - index - 1);
			}
			array = array2;
		}
	}

	public static bool IsArraysEquals(byte[] byte_1, byte[] byte_2)
	{
		if (byte_1 == null && byte_2 == null)
		{
			return true;
		}
		if (byte_1 != null && byte_2 != null)
		{
			if (byte_1.Length != byte_2.Length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < byte_1.Length)
				{
					if (byte_1[num] != byte_2[num])
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public static byte[] GenerateTrash(int length)
	{
		byte[] array = new byte[length];
		new Random().NextBytes(array);
		return array;
	}
}
