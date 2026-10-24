using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.Path;

public class PATH_DATA
{
	private struct Struct85
	{
		public int int_0;

		public int int_1;
	}

	private static readonly int[] int_0 = new int[3] { 2, 1, 0 };

	public uint TimeStamp;

	public int Count;

	public IDictionary<uint, string> Paths;

	public string fn;

	public bool FileChanged;

	public uint last_id;

	private int int_1 = 1;

	private Dictionary<uint, Struct85> dictionary_0;

	public int ReservedFieldCount => int_1;

	public PATH_DATA(string fn)
	{
		FileChanged = false;
		int_1 = 1;
		dictionary_0 = new Dictionary<uint, Struct85>();
		if (fn != null)
		{
			Load(fn);
		}
	}

	public void Load(string fn)
	{
		if (fn != null && File.Exists(fn))
		{
			EditorSessionTracker.LogFolderAccess(fn, Class16.smethod_0(1648903793), Class16.smethod_0(1648906425));
			this.fn = fn;
			using FileStream input = File.OpenRead(fn);
			BinaryReader binaryReader = new BinaryReader(input);
			try
			{
				if (!method_0(binaryReader, bool_0: true, out var uint_, out var int_, out var uint_2, out var int_2))
				{
					throw new InvalidDataException(Class16.smethod_0(1649203697));
				}
				TimeStamp = uint_;
				Count = int_;
				last_id = uint_2;
				int_1 = int_2;
				FileChanged = false;
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
		GC.KeepAlive(this);
	}

	public void Save()
	{
		if (!FileChanged)
		{
			return;
		}
		EditorSessionTracker.LogFolderAccess(fn, Class16.smethod_0(1649006856), Class16.smethod_0(1648906425));
		if (string.IsNullOrWhiteSpace(fn))
		{
			throw new InvalidDataException(Class16.smethod_0(1648918812));
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
			binaryWriter.Write(CommonStorage.ValidateValue(Paths?.Count ?? 0));
			int num = ((int_1 >= 0) ? int_1 : 0);
			foreach (KeyValuePair<uint, string> path in Paths)
			{
				ValueType valueType = path;
				uint key = ((KeyValuePair<uint, string>)(object)valueType).Key;
				string value = ((KeyValuePair<uint, string>)(object)valueType).Value;
				binaryWriter.Write(key);
				byte[] array = ACE.RSGlobal.RSGlobal.ToBytesGBK(value);
				binaryWriter.Write(array.Length);
				binaryWriter.Write(array);
				Struct85 @struct = method_1(key);
				if (num >= 1)
				{
					binaryWriter.Write(@struct.int_0);
				}
				if (num >= 2)
				{
					binaryWriter.Write(@struct.int_1);
				}
			}
			FileChanged = false;
		}
		finally
		{
			((IDisposable)binaryWriter).Dispose();
		}
	}

	public unsafe string GetPath(uint id, bool* path_found)
	{
		string text = null;
		*path_found = false;
		if (id == 0)
		{
			return string.Empty;
		}
		IDictionary<uint, string> paths = Paths;
		if (paths == null)
		{
			string result = id + Class16.smethod_0(1649198638);
			GC.KeepAlive(this);
			return result;
		}
		text = null;
		if (paths.TryGetValue(id, out text))
		{
			*path_found = true;
		}
		else
		{
			text = id + Class16.smethod_0(1649198668);
		}
		GC.KeepAlive(this);
		return text;
	}

	public unsafe string GetPath(uint id)
	{
		bool flag = default(bool);
		return GetPath(id, &flag);
	}

	public uint GetPathID(string path, [MarshalAs(UnmanagedType.U1)] bool bContains)
	{
		if (!string.IsNullOrWhiteSpace(path))
		{
			IDictionary<uint, string> paths = Paths;
			if (paths != null)
			{
				foreach (KeyValuePair<uint, string> item in paths)
				{
					ValueType valueType = item;
					if (((KeyValuePair<uint, string>)(object)valueType).Value != null)
					{
						int num = ((path == ((KeyValuePair<uint, string>)(object)valueType).Value || (bContains && ((KeyValuePair<uint, string>)(object)valueType).Value.Contains(path))) ? 1 : 0);
						if ((byte)num != 0)
						{
							uint key = ((KeyValuePair<uint, string>)(object)valueType).Key;
							GC.KeepAlive(this);
							return key;
						}
					}
				}
				GC.KeepAlive(this);
				return AddNew(GetUniqueID(), path);
			}
		}
		return 0u;
	}

	public uint GetPathID(string path)
	{
		return GetPathID(path, bContains: false);
	}

	public uint AddNew(uint id, string path)
	{
		method_2(0);
		Paths.Add(id, path);
		dictionary_0[id] = smethod_1();
		Count++;
		FileChanged = true;
		last_id = ((id > last_id) ? id : last_id);
		return id;
	}

	public uint AddNew(string path)
	{
		return AddNew(GetUniqueID(), path);
	}

	public uint GetUniqueID()
	{
		method_2(0);
		uint num = ++last_id;
		if (Paths.ContainsKey(num))
		{
			do
			{
				num = ++last_id;
			}
			while (Paths.ContainsKey(num));
		}
		return num;
	}

	public static bool TryRead(byte[] data, out Dictionary<uint, string> map)
	{
		uint timestamp;
		return TryRead(data, out timestamp, out map);
	}

	public static bool TryRead(byte[] data, out uint timestamp, out Dictionary<uint, string> map)
	{
		timestamp = 0u;
		map = new Dictionary<uint, string>();
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
						timestamp = binaryReader.ReadUInt32();
						int num = binaryReader.ReadInt32();
						if (num >= 0 && num <= 500000)
						{
							int[] array = int_0;
							int num2 = 0;
							while (true)
							{
								if (num2 >= array.Length)
								{
									return false;
								}
								int int_ = array[num2];
								binaryReader.BaseStream.Position = 8L;
								map.Clear();
								if (smethod_0(binaryReader, num, int_, bool_0: false, map, null, out var _))
								{
									break;
								}
								num2++;
							}
							return true;
						}
						return false;
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

	private bool method_0(BinaryReader binaryReader_0, bool bool_0, out uint uint_0, out int int_2, out uint uint_1, out int int_3)
	{
		uint_0 = 0u;
		int_2 = 0;
		uint_1 = 0u;
		int_3 = 1;
		if (binaryReader_0.BaseStream.Length < 8L)
		{
			return false;
		}
		uint_0 = binaryReader_0.ReadUInt32();
		int_2 = binaryReader_0.ReadInt32();
		if (int_2 >= 0 && int_2 <= 500000)
		{
			int[] array = int_0;
			int num = 0;
			int num2;
			while (true)
			{
				if (num < array.Length)
				{
					num2 = array[num];
					binaryReader_0.BaseStream.Position = 8L;
					method_2(int_2);
					Paths.Clear();
					dictionary_0.Clear();
					if (smethod_0(binaryReader_0, int_2, num2, bool_0, Paths, dictionary_0, out uint_1))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			int_3 = num2;
			return true;
		}
		return false;
	}

	private static bool smethod_0(BinaryReader binaryReader_0, int int_2, int int_3, bool bool_0, IDictionary<uint, string> idictionary_0, Dictionary<uint, Struct85> dictionary_1, out uint uint_0)
	{
		uint_0 = 0u;
		if (idictionary_0 == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < int_2)
			{
				if (binaryReader_0.BaseStream.Position + 8L <= binaryReader_0.BaseStream.Length)
				{
					uint num2 = binaryReader_0.ReadUInt32();
					int num3 = binaryReader_0.ReadInt32();
					if (num3 < 0 || num3 > 4096)
					{
						break;
					}
					long num4 = binaryReader_0.BaseStream.Position + num3 + int_3 * 4;
					if (num4 <= binaryReader_0.BaseStream.Length)
					{
						string value = ACE.RSGlobal.RSGlobal.ToStringGBK(binaryReader_0.ReadBytes(num3));
						idictionary_0[num2] = value;
						Struct85 value2 = smethod_1();
						if (int_3 >= 1)
						{
							value2.int_0 = binaryReader_0.ReadInt32();
						}
						if (int_3 >= 2)
						{
							value2.int_1 = binaryReader_0.ReadInt32();
						}
						if (bool_0 && dictionary_1 != null)
						{
							dictionary_1[num2] = value2;
						}
						uint_0 = num2;
						num++;
						continue;
					}
					return false;
				}
				return false;
			}
			return binaryReader_0.BaseStream.Position == binaryReader_0.BaseStream.Length;
		}
		return false;
	}

	private Struct85 method_1(uint uint_0)
	{
		if (dictionary_0 != null && dictionary_0.TryGetValue(uint_0, out var value))
		{
			return value;
		}
		return smethod_1();
	}

	private static Struct85 smethod_1()
	{
		return new Struct85
		{
			int_0 = 0,
			int_1 = 0
		};
	}

	private void method_2(int int_2)
	{
		IDictionary<uint, string> paths;
		if (Paths != null)
		{
			paths = Paths;
		}
		else
		{
			IDictionary<uint, string> dictionary = new Dictionary<uint, string>(int_2);
			paths = dictionary;
		}
		Paths = paths;
		dictionary_0 = ((dictionary_0 == null) ? new Dictionary<uint, Struct85>(int_2) : dictionary_0);
	}

	public PathDataSnapshot CreateUndoSnapshot()
	{
		method_2(Paths?.Count ?? 0);
		List<PathDataEntrySnapshot> list = new List<PathDataEntrySnapshot>(Paths.Count);
		foreach (KeyValuePair<uint, string> path in Paths)
		{
			Struct85 @struct = method_1(path.Key);
			list.Add(new PathDataEntrySnapshot
			{
				Id = path.Key,
				Path = path.Value,
				Reserved1 = @struct.int_0,
				Reserved2 = @struct.int_1
			});
		}
		return new PathDataSnapshot
		{
			FileName = fn,
			FileChanged = FileChanged,
			TimeStamp = TimeStamp,
			Count = Count,
			LastId = last_id,
			ReservedFieldCount = int_1,
			Entries = list
		};
	}

	public void RestoreUndoSnapshot(PathDataSnapshot snapshot)
	{
		if (snapshot == null)
		{
			return;
		}
		fn = snapshot.FileName;
		FileChanged = snapshot.FileChanged;
		TimeStamp = snapshot.TimeStamp;
		Count = snapshot.Count;
		last_id = snapshot.LastId;
		int_1 = snapshot.ReservedFieldCount;
		method_2(snapshot.Entries?.Count ?? 0);
		Paths.Clear();
		dictionary_0.Clear();
		foreach (PathDataEntrySnapshot item in snapshot.Entries ?? new List<PathDataEntrySnapshot>())
		{
			Paths[item.Id] = item.Path ?? string.Empty;
			dictionary_0[item.Id] = new Struct85
			{
				int_0 = item.Reserved1,
				int_1 = item.Reserved2
			};
		}
		Count = Paths.Count;
	}
}
