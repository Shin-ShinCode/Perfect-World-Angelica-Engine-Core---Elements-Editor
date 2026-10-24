using System;
using System.Collections.Generic;
using SharpDX;

namespace ACE.PWMap;

internal static class PwMapSpacePassableOctreeBuilder
{
	private enum Enum21
	{

	}

	private sealed class Class320
	{
		public Vector3 vector3_0;

		public float float_0;

		public byte byte_0;

		public Class320[] class320_0;
	}

	internal sealed class OctreeData
	{
		public int OctreeId;

		public int CenterX;

		public int CenterY;

		public int CenterZ;

		public int HalfSize;

		public int LeafNodeSize;

		public int[] Nodes = Array.Empty<int>();
	}

	public static OctreeData Build(int octreeId, Vector3 center, int halfSize, int leafNodeSize, IReadOnlyList<PwMapCollisionBrush> brushes)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		OctreeData octreeData = new OctreeData
		{
			OctreeId = Math.Max(0, Math.Min(255, octreeId)),
			CenterX = (int)Math.Round(center.X),
			CenterY = (int)Math.Round(center.Y),
			CenterZ = (int)Math.Round(center.Z),
			HalfSize = Math.Max(1, halfSize),
			LeafNodeSize = Math.Max(1, leafNodeSize)
		};
		float float_ = Math.Max(0.5f, (float)octreeData.LeafNodeSize * 0.5f);
		List<PwMapCollisionBrush> list_ = ((brushes == null || brushes.Count <= 0) ? new List<PwMapCollisionBrush>() : new List<PwMapCollisionBrush>(brushes));
		Class320 class320_ = new Class320
		{
			vector3_0 = new Vector3((float)octreeData.CenterX, (float)octreeData.CenterY, (float)octreeData.CenterZ),
			float_0 = octreeData.HalfSize,
			byte_0 = 2
		};
		smethod_0(class320_, list_, float_, bool_0: true);
		octreeData.Nodes = smethod_1(class320_);
		return octreeData;
	}

	private static void smethod_0(Class320 class320_0, List<PwMapCollisionBrush> list_0, float float_0, bool bool_0)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		if (class320_0 == null)
		{
			return;
		}
		List<PwMapCollisionBrush> list = new List<PwMapCollisionBrush>(list_0.Count);
		if (!bool_0)
		{
			bool flag = false;
			for (int i = 0; i < list_0.Count; i++)
			{
				PwMapCollisionBrush pwMapCollisionBrush = list_0[i];
				switch (smethod_2(pwMapCollisionBrush, class320_0.vector3_0, class320_0.float_0))
				{
				case (Enum21)1:
					list.Add(pwMapCollisionBrush);
					flag = true;
					break;
				case (Enum21)2:
					class320_0.byte_0 = 1;
					return;
				}
			}
			class320_0.byte_0 = (byte)(flag ? 2 : 0);
			if (!flag)
			{
				return;
			}
		}
		if (!(class320_0.float_0 <= float_0))
		{
			float num = class320_0.float_0 * 0.5f;
			class320_0.class320_0 = new Class320[8];
			for (int j = 0; j < 8; j++)
			{
				bool flag2 = (j & 4) != 0;
				bool flag3 = (j & 2) != 0;
				bool flag4 = (j & 1) != 0;
				class320_0.class320_0[j] = new Class320
				{
					float_0 = num,
					vector3_0 = new Vector3(flag2 ? (class320_0.vector3_0.X + num) : (class320_0.vector3_0.X - num), flag3 ? (class320_0.vector3_0.Y + num) : (class320_0.vector3_0.Y - num), flag4 ? (class320_0.vector3_0.Z + num) : (class320_0.vector3_0.Z - num))
				};
				smethod_0(class320_0.class320_0[j], bool_0 ? list_0 : list, float_0, bool_0: false);
			}
		}
	}

	private static int[] smethod_1(Class320 class320_0)
	{
		if (class320_0?.class320_0 != null && class320_0.class320_0.Length == 8)
		{
			Queue<Class320> queue = new Queue<Class320>(2048);
			for (int i = 0; i < 8; i++)
			{
				queue.Enqueue(class320_0.class320_0[i]);
			}
			List<int> list = new List<int>(8192);
			int num = 0;
			while (queue.Count > 0)
			{
				Class320 @class = queue.Dequeue();
				int num2 = 0;
				if (@class.class320_0 != null && @class.class320_0.Length == 8)
				{
					num++;
					num2 = num;
					for (int j = 0; j < 8; j++)
					{
						queue.Enqueue(@class.class320_0[j]);
					}
				}
				int item = ((@class.byte_0 & 3) << 30) | (num2 & 0x3FFFFFF);
				list.Add(item);
			}
			return list.ToArray();
		}
		return new int[8];
	}

	private static Enum21 smethod_2(PwMapCollisionBrush pwMapCollisionBrush_0, Vector3 vector3_0, float float_0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = default(Vector3);
		val = new Vector3(vector3_0.X - float_0, vector3_0.Y - float_0, vector3_0.Z - float_0);
		Vector3 val2 = default(Vector3);
		val2 = new Vector3(vector3_0.X + float_0, vector3_0.Y + float_0, vector3_0.Z + float_0);
		if (!smethod_3(val, val2, pwMapCollisionBrush_0.Min, pwMapCollisionBrush_0.Max))
		{
			return (Enum21)0;
		}
		if (pwMapCollisionBrush_0.Sides != null && pwMapCollisionBrush_0.Sides.Count != 0)
		{
			bool flag = true;
			int num = 0;
			Vector3 val3 = default(Vector3);
			Vector3 val4 = default(Vector3);
			while (true)
			{
				if (num < pwMapCollisionBrush_0.Sides.Count)
				{
					PwMapCollisionBrush.Side side = pwMapCollisionBrush_0.Sides[num];
					val3 = new Vector3((side.Normal.X >= 0f) ? val.X : val2.X, (side.Normal.Y >= 0f) ? val.Y : val2.Y, (side.Normal.Z >= 0f) ? val.Z : val2.Z);
					val4 = new Vector3((side.Normal.X >= 0f) ? val2.X : val.X, (side.Normal.Y >= 0f) ? val2.Y : val.Y, (side.Normal.Z >= 0f) ? val2.Z : val.Z);
					float num2 = Vector3.Dot(side.Normal, val3);
					float num3 = Vector3.Dot(side.Normal, val4);
					if (!(num2 <= side.Distance + 0.0001f))
					{
						break;
					}
					if (num3 > side.Distance + 0.0001f)
					{
						flag = false;
					}
					num++;
					continue;
				}
				if (!flag)
				{
					return (Enum21)1;
				}
				return (Enum21)2;
			}
			return (Enum21)0;
		}
		return (Enum21)1;
	}

	private static bool smethod_3(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2, Vector3 vector3_3)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if (!(vector3_1.X < vector3_2.X) && !(vector3_0.X > vector3_3.X) && !(vector3_1.Y < vector3_2.Y) && !(vector3_0.Y > vector3_3.Y) && !(vector3_1.Z < vector3_2.Z))
		{
			return !(vector3_0.Z > vector3_3.Z);
		}
		return false;
	}
}
