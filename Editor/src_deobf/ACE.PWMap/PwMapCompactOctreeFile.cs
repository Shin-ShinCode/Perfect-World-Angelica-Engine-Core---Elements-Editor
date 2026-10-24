using System;
using System.Collections.Generic;
using System.IO;

namespace ACE.PWMap;

internal static class PwMapCompactOctreeFile
{
	public static void SaveFlatFree(string filePath, int octreeId, int centerX, int centerY, int centerZ, int halfSize, int leafNodeSize)
	{
		int[] nodes = new int[8];
		Save(filePath, octreeId, centerX, centerY, centerZ, halfSize, leafNodeSize, nodes);
	}

	public static void Save(string filePath, int octreeId, int centerX, int centerY, int centerZ, int halfSize, int leafNodeSize, IReadOnlyList<int> nodes)
	{
		int[] array;
		if (nodes != null && nodes.Count != 0)
		{
			if (nodes.Count == 8)
			{
				array = new int[8];
				for (int i = 0; i < 8; i++)
				{
					array[i] = nodes[i];
				}
			}
			else
			{
				array = new int[nodes.Count];
				for (int j = 0; j < nodes.Count; j++)
				{
					array[j] = nodes[j];
				}
			}
		}
		else
		{
			array = new int[8];
		}
		Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filePath) ?? string.Empty);
		FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			try
			{
				binaryWriter.Write(-872415231);
				binaryWriter.Write((byte)Math.Max(0, Math.Min(255, octreeId)));
				binaryWriter.Write(centerX);
				binaryWriter.Write(centerY);
				binaryWriter.Write(centerZ);
				binaryWriter.Write(Math.Max(1, halfSize));
				binaryWriter.Write(Math.Max(1, leafNodeSize));
				binaryWriter.Write(array.Length);
				for (int k = 0; k < array.Length; k++)
				{
					binaryWriter.Write(array[k]);
				}
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}
}
