using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapPreferencesStore
{
	private PwMapGeneralSettings pwMapGeneralSettings_0 = new PwMapGeneralSettings();

	private PwMapRenderSettings pwMapRenderSettings_0 = new PwMapRenderSettings();

	private PwMapCameraSettings pwMapCameraSettings_0 = new PwMapCameraSettings();

	private PwMapTerrainSettings pwMapTerrainSettings_0 = new PwMapTerrainSettings();

	private PwMapNpcMapSettings pwMapNpcMapSettings_0 = new PwMapNpcMapSettings();

	private PwMapSelectionSettings pwMapSelectionSettings_0 = new PwMapSelectionSettings();

	private PwMapGrassSettings pwMapGrassSettings_0 = new PwMapGrassSettings();

	private PwMapLightSettings pwMapLightSettings_0 = new PwMapLightSettings();

	private readonly string string_0;

	public PwMapGeneralSettings Settings
	{
		[CompilerGenerated]
		get
		{
			return pwMapGeneralSettings_0;
		}
	}

	public PwMapRenderSettings RenderOptions
	{
		[CompilerGenerated]
		get
		{
			return pwMapRenderSettings_0;
		}
	}

	public PwMapCameraSettings CameraSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapCameraSettings_0;
		}
	}

	public PwMapTerrainSettings TerrainSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapTerrainSettings_0;
		}
	}

	public PwMapNpcMapSettings NpcMapSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapNpcMapSettings_0;
		}
	}

	public PwMapSelectionSettings SelectionSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapSelectionSettings_0;
		}
	}

	public PwMapGrassSettings GrassSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapGrassSettings_0;
		}
	}

	public PwMapLightSettings LightSettings
	{
		[CompilerGenerated]
		get
		{
			return pwMapLightSettings_0;
		}
	}

	public string FilePath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public string MapsBasePath
	{
		get
		{
			if (string.IsNullOrWhiteSpace(Settings?.ElementPath))
			{
				return string.Empty;
			}
			return System.IO.Path.Combine(Settings.ElementPath, Class16.smethod_0(1649094124));
		}
	}

	public PwMapPreferencesStore(string filePath = null)
	{
		string_0 = (string.IsNullOrWhiteSpace(filePath) ? smethod_0() : filePath);
	}

	private void method_0(PwMapGeneralSettings pwMapGeneralSettings_1)
	{
		pwMapGeneralSettings_0 = pwMapGeneralSettings_1;
	}

	private void method_1(PwMapRenderSettings pwMapRenderSettings_1)
	{
		pwMapRenderSettings_0 = pwMapRenderSettings_1;
	}

	private void method_2(PwMapCameraSettings pwMapCameraSettings_1)
	{
		pwMapCameraSettings_0 = pwMapCameraSettings_1;
	}

	private void method_3(PwMapTerrainSettings pwMapTerrainSettings_1)
	{
		pwMapTerrainSettings_0 = pwMapTerrainSettings_1;
	}

	private void method_4(PwMapNpcMapSettings pwMapNpcMapSettings_1)
	{
		pwMapNpcMapSettings_0 = pwMapNpcMapSettings_1;
	}

	private void method_5(PwMapSelectionSettings pwMapSelectionSettings_1)
	{
		pwMapSelectionSettings_0 = pwMapSelectionSettings_1;
	}

	private void method_6(PwMapGrassSettings pwMapGrassSettings_1)
	{
		pwMapGrassSettings_0 = pwMapGrassSettings_1;
	}

	private void method_7(PwMapLightSettings pwMapLightSettings_1)
	{
		pwMapLightSettings_0 = pwMapLightSettings_1;
	}

	public bool Load()
	{
		if (!File.Exists(FilePath))
		{
			method_8();
			return false;
		}
		try
		{
			string text = File.ReadAllText(FilePath);
			PwMapPreferencesDocument pwMapPreferencesDocument = JsonConvert.DeserializeObject<PwMapPreferencesDocument>(text);
			if (pwMapPreferencesDocument != null)
			{
				method_0(pwMapPreferencesDocument.Settings ?? new PwMapGeneralSettings());
				method_1(pwMapPreferencesDocument.RenderOptions ?? new PwMapRenderSettings());
				method_2(pwMapPreferencesDocument.CameraSettings ?? new PwMapCameraSettings());
				method_3(pwMapPreferencesDocument.TerrainSettings ?? new PwMapTerrainSettings());
				method_4(pwMapPreferencesDocument.NpcMapSettings ?? new PwMapNpcMapSettings());
				method_5(pwMapPreferencesDocument.SelectionSettings ?? new PwMapSelectionSettings());
				method_6(pwMapPreferencesDocument.GrassSettings ?? new PwMapGrassSettings());
				method_7(pwMapPreferencesDocument.LightSettings ?? new PwMapLightSettings());
			}
		}
		catch
		{
			method_8();
			return false;
		}
		method_8();
		return true;
	}

	public bool Save()
	{
		method_8();
		try
		{
			string directoryName = System.IO.Path.GetDirectoryName(FilePath);
			if (!string.IsNullOrWhiteSpace(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			PwMapPreferencesDocument pwMapPreferencesDocument = new PwMapPreferencesDocument
			{
				Settings = Settings,
				RenderOptions = RenderOptions,
				CameraSettings = CameraSettings,
				TerrainSettings = TerrainSettings,
				NpcMapSettings = NpcMapSettings,
				SelectionSettings = SelectionSettings,
				GrassSettings = GrassSettings,
				LightSettings = LightSettings
			};
			string contents = JsonConvert.SerializeObject((object)pwMapPreferencesDocument, (Formatting)1);
			File.WriteAllText(FilePath, contents);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static string smethod_0()
	{
		return System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1649075606), Class16.smethod_0(1649083988));
	}

	private void method_8()
	{
		if (Settings == null)
		{
			method_0(new PwMapGeneralSettings());
		}
		if (RenderOptions == null)
		{
			method_1(new PwMapRenderSettings());
		}
		if (CameraSettings == null)
		{
			method_2(new PwMapCameraSettings());
		}
		if (TerrainSettings == null)
		{
			method_3(new PwMapTerrainSettings());
		}
		if (NpcMapSettings == null)
		{
			method_4(new PwMapNpcMapSettings());
		}
		if (SelectionSettings == null)
		{
			method_5(new PwMapSelectionSettings());
		}
		if (GrassSettings == null)
		{
			method_6(new PwMapGrassSettings());
		}
		if (LightSettings == null)
		{
			method_7(new PwMapLightSettings());
		}
		RenderOptions.Init();
		RenderOptions.SetRenderOption(PwMapRenderOption.PassMap, enabled: false);
		TerrainSettings.Init();
		NpcMapSettings.Init();
	}
}
