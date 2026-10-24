using System;
using System.Collections.Generic;
using SharpDX;

namespace ACE.PWMap;

internal sealed class PwMapBrushCollisionService
{
	public readonly struct AABBObject(Vector3 center, Vector3 extents)
	{
		public readonly Vector3 Center = center;

		public readonly Vector3 Extents = extents;
	}

	private readonly List<PwMapCollisionBrush> list_0 = new List<PwMapCollisionBrush>(512);

	private readonly List<AABBObject> list_1 = new List<AABBObject>(4096);

	public int BrushCount => list_0.Count;

	public void SetBrushes(IEnumerable<PwMapCollisionBrush> brushes)
	{
		list_0.Clear();
		if (brushes != null)
		{
			list_0.AddRange(brushes);
		}
	}

	public void SetAABBObjects(IReadOnlyList<AABBObject> objects)
	{
		list_1.Clear();
		if (objects != null)
		{
			list_1.AddRange(objects);
		}
	}

	public float SampleFloorHeight(Vector3 pos, float eyeHeight, bool enterBuildings)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		if (enterBuildings)
		{
			return method_1(pos, eyeHeight);
		}
		return method_0(pos, eyeHeight);
	}

	private float method_0(Vector3 vector3_0, float float_0)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		float num = float.MinValue;
		for (int i = 0; i < list_1.Count; i++)
		{
			AABBObject aABBObject = list_1[i];
			Vector3 center = aABBObject.Center;
			Vector3 extents = aABBObject.Extents;
			if (vector3_0.X < center.X - extents.X || vector3_0.X > center.X + extents.X || vector3_0.Z < center.Z - extents.Z || vector3_0.Z > center.Z + extents.Z)
			{
				continue;
			}
			float num2 = center.Y + extents.Y;
			float num3 = center.Y - extents.Y;
			if (vector3_0.Y - float_0 < num2 && vector3_0.Y > num3)
			{
				float num4 = num2 + float_0;
				if (num4 > num)
				{
					num = num4;
				}
			}
		}
		return num;
	}

	private float method_1(Vector3 vector3_0, float float_0)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		float num = float.MinValue;
		Vector3 val = default(Vector3);
		val = new Vector3(vector3_0.X, vector3_0.Y - float_0, vector3_0.Z);
		for (int i = 0; i < list_0.Count; i++)
		{
			PwMapCollisionBrush pwMapCollisionBrush = list_0[i];
			if (val.X < pwMapCollisionBrush.Min.X || val.X > pwMapCollisionBrush.Max.X || val.Z < pwMapCollisionBrush.Min.Z || val.Z > pwMapCollisionBrush.Max.Z || val.Y < pwMapCollisionBrush.Min.Y - 2f || val.Y > pwMapCollisionBrush.Max.Y + 10f)
			{
				continue;
			}
			float num2 = smethod_0(pwMapCollisionBrush, vector3_0.X, vector3_0.Z);
			if (num2 > float.MinValue)
			{
				float num3 = num2 + float_0;
				if (num3 > num && num3 <= vector3_0.Y + 2f)
				{
					num = num3;
				}
			}
		}
		return num;
	}

	private static float smethod_0(PwMapCollisionBrush pwMapCollisionBrush_0, float float_0, float float_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		float num = float.MinValue;
		for (int i = 0; i < pwMapCollisionBrush_0.Sides.Count; i++)
		{
			PwMapCollisionBrush.Side side = pwMapCollisionBrush_0.Sides[i];
			if (!(side.Normal.Y < 0.5f))
			{
				float num2 = (side.Distance - side.Normal.X * float_0 - side.Normal.Z * float_1) / side.Normal.Y;
				if (num2 > num)
				{
					num = num2;
				}
			}
		}
		return num;
	}

	public bool TraceAABB(Vector3 start, Vector3 delta, Vector3 halfExtents, out float fraction, out Vector3 normal)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		fraction = 1f;
		normal = Vector3.Zero;
		bool result = false;
		for (int i = 0; i < list_0.Count; i++)
		{
			PwMapCollisionBrush pwMapCollisionBrush = list_0[i];
			Vector3 val = pwMapCollisionBrush.Min - halfExtents;
			Vector3 val2 = pwMapCollisionBrush.Max + halfExtents;
			Vector3 val3 = start + delta;
			if ((!(start.X > val2.X) || !(val3.X > val2.X)) && (!(start.X < val.X) || !(val3.X < val.X)) && (!(start.Z > val2.Z) || !(val3.Z > val2.Z)) && (!(start.Z < val.Z) || !(val3.Z < val.Z)) && (!(start.Y > val2.Y) || !(val3.Y > val2.Y)) && (!(start.Y < val.Y) || !(val3.Y < val.Y)) && smethod_1(pwMapCollisionBrush, start, delta, halfExtents, out var float_, out var vector3_) && float_ < fraction)
			{
				fraction = float_;
				normal = vector3_;
				result = true;
			}
		}
		return result;
	}

	private static bool smethod_1(PwMapCollisionBrush pwMapCollisionBrush_0, Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2, out float float_0, out Vector3 vector3_3)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		float_0 = -1f;
		vector3_3 = Vector3.Zero;
		float num = 1f;
		int num2 = 0;
		while (true)
		{
			if (num2 < pwMapCollisionBrush_0.Sides.Count)
			{
				PwMapCollisionBrush.Side side = pwMapCollisionBrush_0.Sides[num2];
				Vector3 normal = side.Normal;
				float distance = side.Distance;
				float num3 = Math.Abs(normal.X) * vector3_2.X + Math.Abs(normal.Y) * vector3_2.Y + Math.Abs(normal.Z) * vector3_2.Z;
				float num4 = Vector3.Dot(vector3_0, normal) - (distance + num3);
				float num5 = Vector3.Dot(vector3_0 + vector3_1, normal) - (distance + num3);
				if (num4 >= 0f && !(num5 < 0f))
				{
					break;
				}
				if (!(num4 < 0f) || !(num5 < 0f))
				{
					float num6 = num4 / (num4 - num5);
					if (num4 > num5)
					{
						if (num6 > float_0)
						{
							float_0 = num6;
							vector3_3 = normal;
						}
					}
					else if (num6 < num)
					{
						num = num6;
					}
				}
				num2++;
				continue;
			}
			if (float_0 < 0f)
			{
				float_0 = 0f;
			}
			return float_0 < num;
		}
		return false;
	}
}
