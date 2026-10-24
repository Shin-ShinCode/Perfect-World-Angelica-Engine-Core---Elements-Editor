using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapRenderSettings
{
	private int int_0 = 8;

	private int int_1 = 64;

	private int int_2 = -10496;

	private int int_3 = -14513374;

	private bool bool_0 = true;

	private bool[] bool_1 = smethod_0();

	[JsonProperty("render-distance")]
	public int RenderBlockDistance
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

	[JsonIgnore]
	public int BlockSize
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

	[JsonProperty("renderOptions")]
	public bool[] RenderOptions
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value ?? smethod_0();
		}
	}

	[JsonProperty("dirColor")]
	public int DirColor
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	[JsonProperty("upColor")]
	public int UpColor
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	[JsonProperty("renderGfxDecal")]
	public bool RenderGfxDecal
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

	private static bool[] smethod_0()
	{
		return new bool[8] { true, false, false, false, false, false, false, false };
	}

	public void Init()
	{
		if (bool_1 == null || bool_1.Length != 8)
		{
			bool[] array = new bool[8];
			if (bool_1 != null)
			{
				int length = Math.Min(bool_1.Length, array.Length);
				Array.Copy(bool_1, array, length);
			}
			bool_1 = array;
		}
	}

	public void SetAllOptions(bool enabled)
	{
		Init();
		for (int i = 0; i < bool_1.Length; i++)
		{
			bool_1[i] = enabled;
		}
	}

	public void SetRenderOption(PwMapRenderOption option, bool enabled)
	{
		Init();
		if (option >= PwMapRenderOption.LitModel && (int)option < bool_1.Length)
		{
			bool_1[(int)option] = enabled;
		}
	}

	public bool GetRenderOption(PwMapRenderOption option)
	{
		Init();
		if (option >= PwMapRenderOption.LitModel && (int)option < bool_1.Length)
		{
			return bool_1[(int)option];
		}
		return false;
	}

	public float GetRenderDistance()
	{
		return RenderBlockDistance * BlockSize;
	}
}
