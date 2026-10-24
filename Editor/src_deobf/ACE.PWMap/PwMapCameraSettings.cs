using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapCameraSettings
{
	public const int ShadowNone = 0;

	public const int ShadowT2Lm = 1;

	private bool bool_0 = true;

	private bool bool_1 = true;

	private bool bool_2 = true;

	private bool bool_3;

	private bool bool_4 = true;

	private bool bool_5;

	private bool bool_6;

	private int int_0 = 150;

	private float float_0 = 0.2f;

	private int int_1 = 1;

	private bool bool_7;

	private float float_1;

	private bool bool_8;

	private bool bool_9 = true;

	private bool bool_10;

	private bool bool_11 = true;

	private bool bool_12 = true;

	private bool bool_13 = true;

	private bool bool_14 = true;

	private bool bool_15 = true;

	private bool bool_16 = true;

	private bool bool_17 = true;

	private bool bool_18 = true;

	private bool bool_19 = true;

	private bool bool_20 = true;

	private bool bool_21 = true;

	private bool bool_22 = true;

	private bool bool_23 = true;

	private bool bool_24;

	private int int_2 = -12686016;

	private int int_3 = -3390396;

	private int int_4 = -12285731;

	private int int_5 = -12272828;

	private int int_6 = -2250189;

	private int int_7 = -154;

	private int int_8 = -10048973;

	private bool bool_25;

	private bool bool_26 = true;

	private bool bool_27;

	private bool bool_28;

	private bool bool_29;

	[JsonProperty("showModelBackside")]
	public bool ShowModelBackside
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

	[JsonProperty("showBoundingBoxes")]
	public bool ShowBoundingBoxes
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

	[JsonProperty("showCompass")]
	public bool ShowCompass
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

	[JsonProperty("showRenderInfo")]
	public bool ShowRenderInfo
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

	[JsonProperty("showCollideOnly")]
	public bool ShowCollideOnly
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	[JsonProperty("showTerrainWire")]
	public bool ShowTerrainWire
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	[JsonProperty("showObjectsWire")]
	public bool ShowObjectsWire
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	[JsonProperty("cameraSpeed")]
	public int CameraSpeed
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

	[JsonProperty("cameraRotateSpeed")]
	public float CameraRotateSpeed
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

	[JsonProperty("shadowMode")]
	public int ShadowMode
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

	[JsonProperty("enableFog")]
	public bool EnableFog
	{
		[CompilerGenerated]
		get
		{
			return bool_7;
		}
		[CompilerGenerated]
		set
		{
			bool_7 = value;
		}
	}

	[JsonProperty("dnFactor")]
	public float DayNightFactor
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

	[JsonProperty("litmodelLightRender")]
	public bool IncludeLitModelRender
	{
		[CompilerGenerated]
		get
		{
			return bool_8;
		}
		[CompilerGenerated]
		set
		{
			bool_8 = value;
		}
	}

	[JsonProperty("showLightBox")]
	public bool ShowLightBox
	{
		[CompilerGenerated]
		get
		{
			return bool_9;
		}
		[CompilerGenerated]
		set
		{
			bool_9 = value;
		}
	}

	[JsonProperty("topView")]
	public bool TopView
	{
		[CompilerGenerated]
		get
		{
			return bool_10;
		}
		[CompilerGenerated]
		set
		{
			bool_10 = value;
		}
	}

	[JsonProperty("showGrid")]
	public bool ShowGrid
	{
		[CompilerGenerated]
		get
		{
			return bool_11;
		}
		[CompilerGenerated]
		set
		{
			bool_11 = value;
		}
	}

	[JsonProperty("showAxes")]
	public bool ShowAxes
	{
		[CompilerGenerated]
		get
		{
			return bool_12;
		}
		[CompilerGenerated]
		set
		{
			bool_12 = value;
		}
	}

	[JsonProperty("showRegionLayer")]
	public bool ShowRegionLayer
	{
		[CompilerGenerated]
		get
		{
			return bool_13;
		}
		[CompilerGenerated]
		set
		{
			bool_13 = value;
		}
	}

	[JsonProperty("showPrecinctLayer")]
	public bool ShowPrecinctLayer
	{
		[CompilerGenerated]
		get
		{
			return bool_14;
		}
		[CompilerGenerated]
		set
		{
			bool_14 = value;
		}
	}

	[JsonProperty("showTransportLayer")]
	public bool ShowTransportLayer
	{
		[CompilerGenerated]
		get
		{
			return bool_15;
		}
		[CompilerGenerated]
		set
		{
			bool_15 = value;
		}
	}

	[JsonProperty("showNpcLayer")]
	public bool ShowNpcLayer
	{
		[CompilerGenerated]
		get
		{
			return bool_16;
		}
		[CompilerGenerated]
		set
		{
			bool_16 = value;
		}
	}

	[JsonProperty("showTerrainLayer")]
	public bool ShowTerrainLayer
	{
		[CompilerGenerated]
		get
		{
			return bool_17;
		}
		[CompilerGenerated]
		set
		{
			bool_17 = value;
		}
	}

	[JsonProperty("loadLitModels")]
	public bool LoadLitModels
	{
		[CompilerGenerated]
		get
		{
			return bool_18;
		}
		[CompilerGenerated]
		set
		{
			bool_18 = value;
		}
	}

	[JsonProperty("loadFlora")]
	public bool LoadFlora
	{
		[CompilerGenerated]
		get
		{
			return bool_19;
		}
		[CompilerGenerated]
		set
		{
			bool_19 = value;
		}
	}

	[JsonProperty("loadWater")]
	public bool LoadWater
	{
		[CompilerGenerated]
		get
		{
			return bool_20;
		}
		[CompilerGenerated]
		set
		{
			bool_20 = value;
		}
	}

	[JsonProperty("loadTerrainTextures")]
	public bool LoadTerrainTextures
	{
		[CompilerGenerated]
		get
		{
			return bool_21;
		}
		[CompilerGenerated]
		set
		{
			bool_21 = value;
		}
	}

	[JsonProperty("preferMapAssets")]
	public bool PreferMapAssets
	{
		[CompilerGenerated]
		get
		{
			return bool_22;
		}
		[CompilerGenerated]
		set
		{
			bool_22 = value;
		}
	}

	[JsonProperty("vsync")]
	public bool UseVSync
	{
		[CompilerGenerated]
		get
		{
			return bool_23;
		}
		[CompilerGenerated]
		set
		{
			bool_23 = value;
		}
	}

	[JsonProperty("colorModeEnabled")]
	public bool ColorModeEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_24;
		}
		[CompilerGenerated]
		set
		{
			bool_24 = value;
		}
	}

	[JsonProperty("colorModeTerrain")]
	public int ColorModeTerrain
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

	[JsonProperty("colorModeLitModel")]
	public int ColorModeLitModel
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

	[JsonProperty("colorModeWater")]
	public int ColorModeWater
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

	[JsonProperty("colorModeFlora")]
	public int ColorModeFlora
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

	[JsonProperty("colorModeGfx")]
	public int ColorModeGfx
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	[JsonProperty("colorModeLight")]
	public int ColorModeLight
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	[JsonProperty("colorModeGrass")]
	public int ColorModeGrass
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}

	[JsonProperty("playerMode")]
	public bool PlayerMode
	{
		[CompilerGenerated]
		get
		{
			return bool_25;
		}
		[CompilerGenerated]
		set
		{
			bool_25 = value;
		}
	}

	[JsonProperty("playerCollision")]
	public bool PlayerCollision
	{
		[CompilerGenerated]
		get
		{
			return bool_26;
		}
		[CompilerGenerated]
		set
		{
			bool_26 = value;
		}
	}

	[JsonProperty("freeCameraCollision")]
	public bool FreeCameraCollision
	{
		[CompilerGenerated]
		get
		{
			return bool_27;
		}
		[CompilerGenerated]
		set
		{
			bool_27 = value;
		}
	}

	[JsonProperty("enableSceneLighting")]
	public bool EnableSceneLighting
	{
		[CompilerGenerated]
		get
		{
			return bool_28;
		}
		[CompilerGenerated]
		set
		{
			bool_28 = value;
		}
	}

	[JsonProperty("enterBuildings")]
	public bool EnterBuildings
	{
		[CompilerGenerated]
		get
		{
			return bool_29;
		}
		[CompilerGenerated]
		set
		{
			bool_29 = value;
		}
	}

	public int GetCameraSpeed()
	{
		float num = CameraSpeed * CameraSpeed;
		float num2 = 0.1f * num + 5f;
		return (int)num2;
	}
}
