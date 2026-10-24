using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapSelectionSettings
{
	private float float_0 = 0.001f;

	private bool bool_0;

	private bool bool_1;

	private int int_0 = 14;

	private bool bool_2;

	private bool bool_3 = true;

	private float float_1 = 400f;

	private float float_2 = 0.001f;

	private float float_3;

	private float float_4;

	private float float_5 = 250f;

	private float float_6 = 200f;

	[JsonProperty("fineMoveStep")]
	public float FineMoveStep
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	[JsonProperty("showCollide")]
	public bool ShowCollide
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	[JsonProperty("showDirection")]
	public bool ShowDirection
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	[JsonProperty("shorePointSize")]
	public int ShorePointSize
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

	[JsonProperty("computeCH")]
	public bool ComputeConvexHull
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	[JsonProperty("collisionsVisible")]
	public bool CollisionsVisible
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	[JsonProperty("additionalExtentMax")]
	public float AdditionalExtentMax
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	[JsonProperty("additionalExtentStep")]
	public float AdditionalExtentStep
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	[JsonProperty("additionalEcmExtent")]
	public float AdditionalEcmExtent
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	[JsonProperty("additionalGfxExtent")]
	public float AdditionalGfxExtent
	{
		[CompilerGenerated]
		get
		{
			return float_4;
		}
		[CompilerGenerated]
		set
		{
			float_4 = value;
		}
	}

	[JsonProperty("additionalGfxExtentMax")]
	public float AdditionalGfxExtentMax
	{
		[CompilerGenerated]
		get
		{
			return float_5;
		}
		[CompilerGenerated]
		set
		{
			float_5 = value;
		}
	}

	[JsonProperty("additionalEcmExtentMax")]
	public float AdditionalEcmExtentMax
	{
		[CompilerGenerated]
		get
		{
			return float_6;
		}
		[CompilerGenerated]
		set
		{
			float_6 = value;
		}
	}
}
