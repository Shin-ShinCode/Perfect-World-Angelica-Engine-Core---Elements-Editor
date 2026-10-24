using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapGrassSettings
{
	public const float MaxAmount = 200f;

	public const float MaxSensitivity = 10f;

	public const float DefaultSensitivity = 3f;

	private float float_0 = 5f;

	private float float_1 = 2f;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	[JsonProperty("amount")]
	public float Amount
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

	[JsonProperty("sensitivity")]
	public float Sensitivity
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

	[JsonProperty("showAllGrass")]
	public bool ShowAllGrass
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

	[JsonProperty("showMatte")]
	public bool ShowMatte
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

	[JsonProperty("useRange")]
	public bool UseRange
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
}
