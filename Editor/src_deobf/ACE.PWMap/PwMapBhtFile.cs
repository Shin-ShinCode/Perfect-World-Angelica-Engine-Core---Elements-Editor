using System;
using System.Collections.Generic;
using System.IO;

namespace ACE.PWMap;

internal static class PwMapBhtFile
{
	private struct Struct71
	{
		public float float_0;

		public float float_1;

		public float float_2;

		public float float_3;

		public byte byte_0;

		public byte byte_1;
	}

	public static void SaveEmpty(string filePath, float mapWidth, float mapHeight)
	{
		Save(filePath, mapWidth, mapHeight, Array.Empty<PwMapCollisionBrush>());
	}

	public static void Save(string filePath, float mapWidth, float mapHeight, IReadOnlyList<PwMapCollisionBrush> brushes)
	{
		SortedDictionary<int, List<Struct71>> sortedDictionary = new SortedDictionary<int, List<Struct71>>();
		smethod_0(sortedDictionary, 0f, 0f, mapWidth * 0.5f, mapHeight * 0.5f, bool_0: false, 0);
		List<Struct71> list = new List<Struct71>(4096);
		foreach (KeyValuePair<int, List<Struct71>> item in sortedDictionary)
		{
			list.AddRange(item.Value);
		}
		Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filePath) ?? string.Empty);
		FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			try
			{
				binaryWriter.Write(1651798630);
				binaryWriter.Write(1);
				binaryWriter.Write(brushes?.Count ?? 0);
				if (brushes != null)
				{
					for (int i = 0; i < brushes.Count; i++)
					{
						smethod_1(binaryWriter, brushes[i]);
					}
				}
				for (int j = 0; j < list.Count; j++)
				{
					Struct71 @struct = list[j];
					binaryWriter.Write(@struct.float_0);
					binaryWriter.Write(@struct.float_1);
					binaryWriter.Write(@struct.float_2);
					binaryWriter.Write(@struct.float_3);
					binaryWriter.Write(@struct.byte_0);
					binaryWriter.Write(@struct.byte_1);
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

	private static void smethod_0(SortedDictionary<int, List<Struct71>> sortedDictionary_0, float float_0, float float_1, float float_2, float float_3, bool bool_0, int int_0)
	{
		if (!sortedDictionary_0.TryGetValue(int_0, out var value))
		{
			value = (sortedDictionary_0[int_0] = new List<Struct71>());
		}
		value.Add(new Struct71
		{
			float_0 = float_0,
			float_1 = float_1,
			float_2 = float_2,
			float_3 = float_3,
			byte_0 = 1,
			byte_1 = (bool_0 ? ((byte)1) : ((byte)0))
		});
		if (!bool_0)
		{
			bool bool_1 = float_2 * 0.5f <= 8f || float_3 * 0.5f <= 8f;
			int int_1 = int_0 + 1;
			float num = float_2 * 0.5f;
			float num2 = float_3 * 0.5f;
			smethod_0(sortedDictionary_0, float_0 - num, float_1 - num2, num, num2, bool_1, int_1);
			smethod_0(sortedDictionary_0, float_0 - num, float_1 + num2, num, num2, bool_1, int_1);
			smethod_0(sortedDictionary_0, float_0 + num, float_1 + num2, num, num2, bool_1, int_1);
			smethod_0(sortedDictionary_0, float_0 + num, float_1 - num2, num, num2, bool_1, int_1);
		}
	}

	private static void smethod_1(BinaryWriter binaryWriter_0, PwMapCollisionBrush pwMapCollisionBrush_0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		binaryWriter_0.Write(pwMapCollisionBrush_0.Center.X);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Center.Y);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Center.Z);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Extents.X);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Extents.Y);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Extents.Z);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Min.X);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Min.Y);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Min.Z);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Max.X);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Max.Y);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Max.Z);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Flags);
		binaryWriter_0.Write(pwMapCollisionBrush_0.Sides?.Count ?? 0);
		if (pwMapCollisionBrush_0.Sides != null)
		{
			for (int i = 0; i < pwMapCollisionBrush_0.Sides.Count; i++)
			{
				PwMapCollisionBrush.Side side = pwMapCollisionBrush_0.Sides[i];
				binaryWriter_0.Write(side.Normal.X);
				binaryWriter_0.Write(side.Normal.Y);
				binaryWriter_0.Write(side.Normal.Z);
				binaryWriter_0.Write(side.Distance);
				binaryWriter_0.Write(side.Bevel);
			}
		}
	}
}
