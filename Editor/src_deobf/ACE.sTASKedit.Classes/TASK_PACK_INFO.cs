using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices;
using ACE.RSGlobal;

namespace ACE.sTASKedit.Classes;

public class TASK_PACK_INFO
{
	public uint magic;

	public uint version;

	public uint export_version;

	public uint item_count;

	public int pack_count;

	public ObservableCollection<byte[]> taskmd5;

	public TASK_PACK_INFO()
	{
	}

	public TASK_PACK_INFO(string FilePath)
	{
		BinaryReader binaryReader = new BinaryReader(File.OpenRead(FilePath));
		magic = binaryReader.ReadUInt32();
		version = binaryReader.ReadUInt32();
		export_version = binaryReader.ReadUInt32();
		item_count = binaryReader.ReadUInt32();
		pack_count = (int)binaryReader.ReadUInt32();
		taskmd5 = new ObservableCollection<byte[]>();
		int num = 0;
		if (0 < pack_count)
		{
			do
			{
				taskmd5.Add(binaryReader.ReadBytes(16));
				num++;
			}
			while (num < pack_count);
		}
		binaryReader.Close();
		GC.KeepAlive(this);
	}

	public void Save(string FilePath, [MarshalAs(UnmanagedType.U1)] bool bSkipMagic)
	{
		ACE.RSGlobal.RSGlobal.DeleteIfExists(FilePath);
		BinaryWriter binaryWriter = new BinaryWriter(File.OpenWrite(FilePath));
		if (!bSkipMagic)
		{
			binaryWriter.Write(magic);
		}
		binaryWriter.Write(version);
		binaryWriter.Write(export_version);
		binaryWriter.Write(item_count);
		binaryWriter.Write(pack_count);
		int num = 0;
		if (0 < pack_count)
		{
			do
			{
				int num2 = num + 1;
				byte[] buffer = RSMD5.ComputeFile(FilePath + num2);
				binaryWriter.Write(buffer);
				num = num2;
			}
			while (num < pack_count);
		}
		binaryWriter.Close();
		GC.KeepAlive(this);
	}
}
