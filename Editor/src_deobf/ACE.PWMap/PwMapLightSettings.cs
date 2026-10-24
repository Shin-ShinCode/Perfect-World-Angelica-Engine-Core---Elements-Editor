using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapLightSettings
{
	private float float_0 = 10f;

	private float float_1 = 0.1f;

	private float float_2 = 4f;

	private float float_3 = 0.001f;

	private float float_4 = 1f;

	private float float_5 = 0.001f;

	[JsonProperty("constantMax")]
	public float ConstantMax
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

	[JsonProperty("constantStep")]
	public float ConstantStep
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

	[JsonProperty("linearMax")]
	public float LinearMax
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

	[JsonProperty("linearStep")]
	public float LinearStep
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

	[JsonProperty("quadraticMax")]
	public float QuadraticMax
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

	[JsonProperty("quadraticStep")]
	public float QuadraticStep
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
}
