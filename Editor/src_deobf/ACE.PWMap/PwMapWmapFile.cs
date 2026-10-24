using System;
using System.Collections.Generic;
using System.IO;

namespace ACE.PWMap;

internal sealed class PwMapWmapFile
{
	internal struct WaterArea
	{
		public float CenterX;

		public float CenterZ;

		public float ExtentX;

		public float ExtentZ;

		public float Height;
	}

	public static void Save(string filePath, float width, float length, IReadOnlyList<WaterArea> areas)
	{
		if (string.IsNullOrWhiteSpace(filePath))
		{
			return;
		}
		Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filePath) ?? string.Empty);
		FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			try
			{
				binaryWriter.Write(-872415231);
				binaryWriter.Write(width);
				binaryWriter.Write(length);
				binaryWriter.Write(areas?.Count ?? 0);
				if (areas != null)
				{
					for (int i = 0; i < areas.Count; i++)
					{
						WaterArea waterArea = areas[i];
						binaryWriter.Write(waterArea.CenterX);
						binaryWriter.Write(waterArea.CenterZ);
						binaryWriter.Write(waterArea.ExtentX);
						binaryWriter.Write(waterArea.ExtentZ);
						binaryWriter.Write(waterArea.Height);
					}
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
