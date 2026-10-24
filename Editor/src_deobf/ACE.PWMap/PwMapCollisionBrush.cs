using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SharpDX;

namespace ACE.PWMap;

internal sealed class PwMapCollisionBrush
{
	internal readonly struct Side(Vector3 normal, float distance, byte bevel)
	{
		public readonly Vector3 Normal = normal;

		public readonly float Distance = distance;

		public readonly byte Bevel = bevel;
	}

	private Vector3 vector3_0;

	private Vector3 vector3_1;

	private Vector3 vector3_2;

	private Vector3 vector3_3;

	private int int_0;

	private readonly List<Side> list_0 = new List<Side>(16);

	public Vector3 Center
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return vector3_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			vector3_0 = value;
		}
	}

	public Vector3 Extents
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return vector3_1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			vector3_1 = value;
		}
	}

	public Vector3 Min
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return vector3_2;
		}
		[CompilerGenerated]
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			vector3_2 = value;
		}
	}

	public Vector3 Max
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return vector3_3;
		}
		[CompilerGenerated]
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			vector3_3 = value;
		}
	}

	public int Flags
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public List<Side> Sides
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}
}
