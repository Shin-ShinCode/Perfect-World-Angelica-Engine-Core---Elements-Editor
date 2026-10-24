using System;
using System.Collections.Generic;
using System.IO;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.DynamicObjects;

public sealed class DYNAMICOBJECTS_DATA
{
	public struct Entry
	{
		public uint Id;

		public string Path;

		public int Reserved1;

		public int Reserved2;
	}

	private static readonly int[] int_0 = new int[3] { 2, 1, 0 };

	public uint TimeStamp;

	public string fn;

	public bool FileChanged;

	private int int_1 = 2;

	public List<Entry> Entries = new List<Entry>();

	public int ReservedFieldCount => int_1;

	public DYNAMICOBJECTS_DATA()
	{
		FileChanged = false;
		int_1 = 2;
		Entries = new List<Entry>();
		GC.KeepAlive(this);
	}

	public DYNAMICOBJECTS_DATA(string fn)
		: this()
	{
		if (!string.IsNullOrWhiteSpace(fn))
		{
			Load(fn);
		}
	}

	public void SetReservedFieldCount(int reservedFieldCount)
	{
		if (reservedFieldCount < 0)
		{
			reservedFieldCount = 0;
		}
		if (reservedFieldCount > 2)
		{
			reservedFieldCount = 2;
		}
		int_1 = reservedFieldCount;
		GC.KeepAlive(this);
	}

	public void Load(string fn)
	{
		if (string.IsNullOrWhiteSpace(fn))
		{
			throw new InvalidDataException(TextStorage.Msg(Class16.smethod_0(1648998162), Class16.smethod_0(1648918812)));
		}
		if (!File.Exists(fn))
		{
			throw new FileNotFoundException(TextStorage.Msg(Class16.smethod_0(1648998211), Class16.smethod_0(1649006654)), fn);
		}
		EditorSessionTracker.LogFolderAccess(fn, Class16.smethod_0(1648998261), Class16.smethod_0(1648998292));
		this.fn = fn;
		using FileStream input = File.OpenRead(fn);
		BinaryReader binaryReader = new BinaryReader(input);
		try
		{
			if (!smethod_0(binaryReader, out var uint_, out var int_, out var list_))
			{
				throw new InvalidDataException(TextStorage.Msg(Class16.smethod_0(1648998305), Class16.smethod_0(1648998347)));
			}
			TimeStamp = uint_;
			int_1 = int_;
			Entries = list_ ?? new List<Entry>();
			FileChanged = false;
			GC.KeepAlive(this);
		}
		finally
		{
			((IDisposable)binaryReader).Dispose();
		}
	}

	public void Save()
	{
		if (!FileChanged)
		{
			return;
		}
		EditorSessionTracker.LogFolderAccess(fn, Class16.smethod_0(1648998398), Class16.smethod_0(1648998292));
		if (string.IsNullOrWhiteSpace(fn))
		{
			throw new InvalidDataException(TextStorage.Msg(Class16.smethod_0(1648998162), Class16.smethod_0(1648918812)));
		}
		if (File.Exists(fn))
		{
			File.Copy(fn, fn + Class16.smethod_0(1648898363), overwrite: true);
		}
		using FileStream output = File.Open(fn, FileMode.Create, FileAccess.Write, FileShare.None);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		try
		{
			binaryWriter.Write(TimeStamp);
			binaryWriter.Write(Entries?.Count ?? 0);
			int num = ((int_1 >= 0) ? int_1 : 0);
			if (Entries != null)
			{
				for (int i = 0; i < Entries.Count; i++)
				{
					Entry entry = Entries[i];
					binaryWriter.Write(entry.Id);
					byte[] array = ACE.RSGlobal.RSGlobal.ToBytesGBK(entry.Path ?? string.Empty);
					binaryWriter.Write(array.Length);
					binaryWriter.Write(array);
					if (num >= 1)
					{
						binaryWriter.Write(entry.Reserved1);
					}
					if (num >= 2)
					{
						binaryWriter.Write(entry.Reserved2);
					}
				}
			}
			FileChanged = false;
			GC.KeepAlive(this);
		}
		finally
		{
			((IDisposable)binaryWriter).Dispose();
		}
	}

	public static bool TryRead(byte[] data, out uint timestamp, out List<Entry> entries, out int reservedFieldCount)
	{
		timestamp = 0u;
		reservedFieldCount = 2;
		entries = new List<Entry>();
		if (data != null && data.Length >= 8)
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream(data, writable: false);
				try
				{
					BinaryReader binaryReader = new BinaryReader(memoryStream);
					try
					{
						return smethod_0(binaryReader, out timestamp, out reservedFieldCount, out entries);
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
				return false;
			}
		}
		return false;
	}

	private static bool smethod_0(BinaryReader binaryReader_0, out uint uint_0, out int int_2, out List<Entry> list_0)
	{
		uint_0 = 0u;
		int_2 = 2;
		list_0 = new List<Entry>();
		if (binaryReader_0.BaseStream.Length < 8L)
		{
			return false;
		}
		uint_0 = binaryReader_0.ReadUInt32();
		int num = binaryReader_0.ReadInt32();
		if (num >= 0 && num <= 500000)
		{
			list_0 = new List<Entry>(num);
			int[] array = int_0;
			int num2 = 0;
			int num3;
			while (true)
			{
				if (num2 < array.Length)
				{
					num3 = array[num2];
					binaryReader_0.BaseStream.Position = 8L;
					list_0.Clear();
					if (smethod_1(binaryReader_0, num, num3, list_0))
					{
						break;
					}
					num2++;
					continue;
				}
				return false;
			}
			int_2 = num3;
			return true;
		}
		return false;
	}

	private static bool smethod_1(BinaryReader binaryReader_0, int int_2, int int_3, List<Entry> list_0)
	{
		long length = binaryReader_0.BaseStream.Length;
		int num = 0;
		while (true)
		{
			if (num < int_2)
			{
				if (binaryReader_0.BaseStream.Position + 8L <= length)
				{
					uint id = binaryReader_0.ReadUInt32();
					int num2 = binaryReader_0.ReadInt32();
					if (num2 < 0 || num2 > 4096)
					{
						break;
					}
					long num3 = binaryReader_0.BaseStream.Position + num2 + int_3 * 4L;
					if (num3 <= length)
					{
						string path = ACE.RSGlobal.RSGlobal.ToStringGBK(binaryReader_0.ReadBytes(num2));
						int reserved = 0;
						int reserved2 = 0;
						if (int_3 >= 1)
						{
							reserved = binaryReader_0.ReadInt32();
						}
						if (int_3 >= 2)
						{
							reserved2 = binaryReader_0.ReadInt32();
						}
						list_0.Add(new Entry
						{
							Id = id,
							Path = path,
							Reserved1 = reserved,
							Reserved2 = reserved2
						});
						num++;
						continue;
					}
					return false;
				}
				return false;
			}
			return binaryReader_0.BaseStream.Position == length;
		}
		return false;
	}
}
