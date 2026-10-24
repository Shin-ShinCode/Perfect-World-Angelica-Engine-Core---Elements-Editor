using System.IO;
using ACE.RSGlobal;

namespace ACE.Models;

public class SKI
{
	public struct SKI_METADATA
	{
		public long sign;

		public int version;

		public int meshCount;

		public int meshTwoCount;

		public int vertexType;

		public int vertexType1;

		public int textCount;

		public int matCount;

		public int bipsCount;

		public int u_3;

		public int mask;
	}

	public SKI_METADATA metadata;

	public byte[] blank;

	public byte[][] Bips;

	public byte[][] Textures;

	public bool Loaded;

	public static byte[] emptySki = new byte[48]
	{
		77, 79, 88, 66, 73, 75, 83, 65, 8, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 112, 0, 0, 0
	};

	public SKI(byte[] bytes)
	{
		if (bytes == null || (nint)bytes.LongLength < 48)
		{
			return;
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(bytes));
		SKI_METADATA sKI_METADATA = ACE.RSGlobal.RSGlobal.ReadStruct<SKI_METADATA>(binaryReader);
		metadata = sKI_METADATA;
		blank = binaryReader.ReadBytes(60);
		int textCount = metadata.textCount;
		if (textCount < 0 || textCount > 5000)
		{
			metadata.textCount = 0;
		}
		if (metadata.version >= 9)
		{
			Bips = new byte[metadata.bipsCount][];
			int num = 0;
			if (0 < metadata.bipsCount)
			{
				do
				{
					int count = binaryReader.ReadInt32();
					Bips[num] = binaryReader.ReadBytes(count);
					num++;
				}
				while (num < metadata.bipsCount);
			}
		}
		int textCount2 = metadata.textCount;
		if (textCount2 > 0)
		{
			Textures = new byte[textCount2][];
			int num2 = 0;
			if (0 < textCount2)
			{
				do
				{
					int count2 = binaryReader.ReadInt32();
					Textures[num2] = binaryReader.ReadBytes(count2);
					num2++;
				}
				while (num2 < metadata.textCount);
			}
		}
		binaryReader.Close();
		Loaded = true;
	}
}
