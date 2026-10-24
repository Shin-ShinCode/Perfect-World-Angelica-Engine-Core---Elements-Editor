using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapTerrainSettings
{
	public const float DefaultOffset = 0.2f;

	public const float DefaultStrength = 0.4f;

	private float float_0 = 10f;

	private float float_1 = 0.4f;

	private float float_2 = 0.2f;

	private int int_0 = -11737574;

	private int int_1 = -1697050;

	private int int_2 = -1697204;

	private int int_3;

	private int int_4;

	private bool bool_0;

	private int int_5;

	[JsonProperty("brushRadius")]
	public float BrushRadius
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

	[JsonProperty("brushStrength")]
	public float BrushStrength
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

	[JsonProperty("brushOffset")]
	public float BrushOffset
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

	[JsonProperty("brushPaintColor")]
	public int BrushPaintColorArgb
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

	[JsonProperty("brushHoverColor")]
	public int BrushHoverColorArgb
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

	[JsonProperty("brushEraseColor")]
	public int BrushEraseColorArgb
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

	[JsonProperty("textureAction")]
	public int TextureAction
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

	[JsonProperty("landscapeAction")]
	public int LandscapeAction
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	[JsonProperty("smoothImport")]
	public bool SmoothImport
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

	[JsonProperty("currentBrush")]
	public int CurrentBrush
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public void Init()
	{
		if (BrushRadius < 0f)
		{
			BrushRadius = 0f;
		}
	}
}
