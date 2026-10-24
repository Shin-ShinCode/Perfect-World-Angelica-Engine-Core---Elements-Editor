using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapPreferencesDocument
{
	private PwMapGeneralSettings pwMapGeneralSettings_0 = new PwMapGeneralSettings();

	private PwMapRenderSettings pwMapRenderSettings_0 = new PwMapRenderSettings();

	private PwMapCameraSettings pwMapCameraSettings_0 = new PwMapCameraSettings();

	private PwMapTerrainSettings pwMapTerrainSettings_0 = new PwMapTerrainSettings();

	private PwMapNpcMapSettings pwMapNpcMapSettings_0 = new PwMapNpcMapSettings();

	private PwMapSelectionSettings pwMapSelectionSettings_0 = new PwMapSelectionSettings();

	private PwMapGrassSettings pwMapGrassSettings_0 = new PwMapGrassSettings();

	private PwMapLightSettings pwMapLightSettings_0 = new PwMapLightSettings();

	[JsonProperty("settings")]
	public PwMapGeneralSettings Settings
	{
		[CompilerGenerated]
		get
		{
			return pwMapGeneralSettings_0;
		}
		[CompilerGenerated]
		set
		{
			pwMapGeneralSettings_0 = value;
		}
	}

	[JsonProperty("renderOptions")]
	public PwMapRenderSettings RenderOptions
	{
		[CompilerGenerated]
		get
		{
			return pwMapRenderSettings_0;
		}
		[CompilerGenerated]
		set
		{
			pwMapRenderSettings_0 = value;
		}
	}

	[JsonProperty("cameraSettings")]
	public PwMapCameraSettings CameraSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapCameraSettings_0;
		}
		[CompilerGenerated]
		set
		{
			pwMapCameraSettings_0 = value;
		}
	}

	[JsonProperty("terrainSettings")]
	public PwMapTerrainSettings TerrainSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapTerrainSettings_0;
		}
		[CompilerGenerated]
		set
		{
			pwMapTerrainSettings_0 = value;
		}
	}

	[JsonProperty("npcMapSettings")]
	public PwMapNpcMapSettings NpcMapSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapNpcMapSettings_0;
		}
		[CompilerGenerated]
		set
		{
			pwMapNpcMapSettings_0 = value;
		}
	}

	[JsonProperty("selectionSettings")]
	public PwMapSelectionSettings SelectionSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapSelectionSettings_0;
		}
		[CompilerGenerated]
		set
		{
			pwMapSelectionSettings_0 = value;
		}
	}

	[JsonProperty("grassSettings")]
	public PwMapGrassSettings GrassSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapGrassSettings_0;
		}
		[CompilerGenerated]
		set
		{
			pwMapGrassSettings_0 = value;
		}
	}

	[JsonProperty("lightSettings")]
	public PwMapLightSettings LightSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapLightSettings_0;
		}
		[CompilerGenerated]
		set
		{
			pwMapLightSettings_0 = value;
		}
	}
}
