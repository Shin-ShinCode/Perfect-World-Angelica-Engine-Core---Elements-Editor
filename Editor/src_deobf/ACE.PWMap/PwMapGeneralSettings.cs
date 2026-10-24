using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapGeneralSettings
{
	public const int DefaultFontSize = 11;

	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private string string_2 = string.Empty;

	private string string_3 = string.Empty;

	private List<PwMapMapSettings> list_0 = new List<PwMapMapSettings>();

	private string string_4 = Class16.smethod_0(1649090288);

	private float float_0 = 0.14f;

	private float float_1 = 0.75f;

	private int int_0 = 11;

	private int int_1 = 16;

	private int int_2 = -1;

	private int int_3 = -1;

	private int int_4 = -1;

	private int int_5 = -1;

	private bool bool_0;

	private int int_6 = 1;

	private bool bool_1;

	private bool bool_2 = true;

	[JsonProperty("serverPath")]
	public string ServerPath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	[JsonProperty("elementPath")]
	public string ElementPath
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	[JsonProperty("workingPath")]
	public string WorkingPath
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	[JsonProperty("currentMap")]
	public string CurrentMap
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	[JsonProperty("mapSettings")]
	public List<PwMapMapSettings> MapSettings
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	[JsonProperty("language")]
	public string Language
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	[JsonProperty("leftSplit")]
	public float LeftSplit
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

	[JsonProperty("rightSplit")]
	public float RightSplit
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

	[JsonProperty("fontSize")]
	public int FontSize
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

	[JsonProperty("iconSize")]
	public int IconSize
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

	[JsonProperty("windowWidth")]
	public int Width
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

	[JsonProperty("windowHeight")]
	public int Height
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

	[JsonProperty("positionX")]
	public int PositionX
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

	[JsonProperty("positionY")]
	public int PositionY
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

	[JsonProperty("saveSideEffects")]
	public bool SaveSideEffects
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

	[JsonProperty("logLevel")]
	public int LogLevel
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

	[JsonProperty("enableShadowCalculation")]
	public bool EnableShadowCalculation
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

	[JsonProperty("vsync")]
	public bool VSync
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

	public PwMapVector3 GetLastPositionInMap(string mapName)
	{
		if (!string.IsNullOrWhiteSpace(mapName) && MapSettings != null)
		{
			int num = 0;
			PwMapMapSettings pwMapMapSettings;
			while (true)
			{
				if (num < MapSettings.Count)
				{
					pwMapMapSettings = MapSettings[num];
					if (pwMapMapSettings != null && string.Equals(pwMapMapSettings.Name, mapName, StringComparison.OrdinalIgnoreCase))
					{
						break;
					}
					num++;
					continue;
				}
				return PwMapVector3.Zero;
			}
			return new PwMapVector3(pwMapMapSettings.Single_0, pwMapMapSettings.Single_1, pwMapMapSettings.Single_2);
		}
		return PwMapVector3.Zero;
	}

	public void UpdateLastPosition(string mapName, PwMapVector3 position)
	{
		if (string.IsNullOrWhiteSpace(mapName))
		{
			return;
		}
		CurrentMap = mapName;
		if (MapSettings == null)
		{
			MapSettings = new List<PwMapMapSettings>();
		}
		PwMapMapSettings pwMapMapSettings = null;
		for (int i = 0; i < MapSettings.Count; i++)
		{
			PwMapMapSettings pwMapMapSettings2 = MapSettings[i];
			if (pwMapMapSettings2 != null && string.Equals(pwMapMapSettings2.Name, mapName, StringComparison.OrdinalIgnoreCase))
			{
				pwMapMapSettings = pwMapMapSettings2;
				break;
			}
		}
		if (pwMapMapSettings == null)
		{
			pwMapMapSettings = new PwMapMapSettings
			{
				Name = mapName
			};
			MapSettings.Add(pwMapMapSettings);
		}
		pwMapMapSettings.Single_0 = position.Single_0;
		pwMapMapSettings.Single_1 = position.Single_1;
		pwMapMapSettings.Single_2 = position.Single_2;
	}

	public float GetFontFactor()
	{
		if (FontSize <= 0)
		{
			return 1f;
		}
		return (float)FontSize / 11f;
	}
}
