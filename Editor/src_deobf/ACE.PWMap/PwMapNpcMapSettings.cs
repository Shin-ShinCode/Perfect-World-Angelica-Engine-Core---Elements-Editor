using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapNpcMapSettings
{
	private bool bool_0 = true;

	private int int_0 = -1291780352;

	private int int_1 = -1275133952;

	[JsonProperty("immediateUpdate")]
	public bool ImmediateUpdate
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

	[JsonProperty("passColor")]
	public int PassColor
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

	[JsonProperty("denyColor")]
	public int DenyColor
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public void Init()
	{
		if (PassColor == 0)
		{
			PassColor = -1291780352;
		}
		if (DenyColor == 0)
		{
			DenyColor = -1275133952;
		}
	}
}
