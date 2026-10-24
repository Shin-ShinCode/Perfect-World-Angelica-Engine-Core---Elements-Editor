using System.IO;
using ACE.Pck.Package;

namespace ACE.Pck;

public class Functions
{
	public static ACE.Pck.Package.FileInfo[] GetFileTable(string PackagePath, string GameMode)
	{
		ACE.Pck.Package.Package package = new ACE.Pck.Package.Package(PackagePath, Keys.SetKeys(GameMode));
		int num = -272;
		package.Seek(-4L, SeekOrigin.End);
		int num2 = package.ReadInt32();
		if (num2 == 131075)
		{
			num = -280;
		}
		package.Seek(-8L, SeekOrigin.End);
		int num3 = package.ReadInt32();
		package.Seek(num, SeekOrigin.End);
		long num4 = ((num2 != 131075) ? ((uint)((int)package.ReadUInt32() ^ package.key.KEY_1)) : (package.ReadInt64() ^ package.key.KEY_1));
		package.Seek(num4, SeekOrigin.Begin);
		BinaryReader tableStream = new BinaryReader(new MemoryStream(package.ReadBytes((int)(package.GetLenght() - num4 - 280L))));
		ACE.Pck.Package.FileInfo[] array = new ACE.Pck.Package.FileInfo[num3];
		for (int i = 0; i < num3; i++)
		{
			array[i] = ACE.Pck.Package.FileInfo.Read(tableStream, num2, package.key);
		}
		package.Dispose();
		return array;
	}

	public static MemoryStream GetFile(ACE.Pck.Package.FileInfo[] FileTable, string PackagePath, string GameMode, string File)
	{
		ACE.Pck.Package.Package package = new ACE.Pck.Package.Package(PackagePath, Keys.SetKeys(GameMode));
		int num = 0;
		while (true)
		{
			if (num < FileTable.Length)
			{
				if (File.ToLower() == FileTable[num].Path.ToLower())
				{
					break;
				}
				num++;
				continue;
			}
			package.Dispose();
			return new MemoryStream();
		}
		package.Seek(FileTable[num].Offset, SeekOrigin.Begin);
		byte[] array = package.ReadBytes(FileTable[num].CompressedSize);
		if (FileTable[num].CompressedSize < FileTable[num].Size)
		{
			package.Dispose();
			return new MemoryStream(Zlib.Decompress(array, FileTable[num].Size));
		}
		package.Dispose();
		return new MemoryStream(array);
	}
}
