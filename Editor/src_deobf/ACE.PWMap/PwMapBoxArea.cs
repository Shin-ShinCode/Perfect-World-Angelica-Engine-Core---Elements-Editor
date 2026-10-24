using System.Drawing;

namespace ACE.PWMap;

public sealed class PwMapBoxArea
{
	public int Version;

	public int ExportId;

	public int DefaultArea;

	public int AreaFlags;

	public float PosX;

	public float PosY;

	public float PosZ;

	public float HalfExtentX;

	public float HalfExtentY;

	public float HalfExtentZ;

	public float AxisXx;

	public float AxisXy;

	public float AxisXz;

	public float AxisYx;

	public float AxisYy;

	public float AxisYz;

	public float AxisZx;

	public float AxisZy;

	public float AxisZz;

	public float FogStart;

	public float FogEnd;

	public float FogDensity;

	public int FogColor;

	public float UwFogStart;

	public float UwFogEnd;

	public float UwFogDensity;

	public int UwFogColor;

	public float FogStartNight;

	public float FogEndNight;

	public float FogDensityNight;

	public int FogColorNight;

	public float LightDirX;

	public float LightDirY;

	public float LightDirZ;

	public int Ambient;

	public int DirLtCol;

	public int AmbientNight;

	public int DirLtColNight;

	public float SkySpeedX;

	public float SkySpeedY;

	public int TrnLtScale;

	public int TransTime;

	public int RainSpeed;

	public float RainSize;

	public int RainColor;

	public int SnowSpeed;

	public float SnowSize;

	public int SnowColor;

	public float SunPower;

	public float SunPowerNight;

	public int CloudAmb;

	public int CloudDir;

	public int CloudAmbNight;

	public int CloudDirNight;

	public float UwFogStartNight;

	public float UwFogEndNight;

	public float UwFogDensityNight;

	public int UwFogColorNight;

	public int TmBornYear;

	public int TmBornMonth;

	public int TmBornWeek;

	public int TmBornDay;

	public int TmBornHour;

	public int TmBornMinute;

	public int TmDieYear;

	public int TmDieMonth;

	public int TmDieWeek;

	public int TmDieDay;

	public int TmDieHour;

	public int TmDieMinute;

	public float CapTileSpeed;

	public float CapRotSpeed;

	public int Priority;

	public float GlbFogHeightStart;

	public float GlbFogHeightEnd;

	public float GlbFogDensityStart;

	public float GlbFogDensityEnd;

	public float GlbFogHeightStartNight;

	public float GlbFogHeightEndNight;

	public float GlbFogDensityStartNight;

	public float GlbFogDensityEndNight;

	public int FogColor2;

	public float FogColorDensityStart;

	public float FogColorDensityEnd;

	public float FogHorzeDensity;

	public float FogHorzePower;

	public int FogColor2Night;

	public float FogColorDensityStartNight;

	public float FogColorDensityEndNight;

	public float FogHorzeDensityNight;

	public float FogHorzePowerNight;

	public int Ambient2;

	public int Ambient2Night;

	public string SkyFile0 = string.Empty;

	public string SkyFile1 = string.Empty;

	public string SkyFile2 = string.Empty;

	public string SkyFile0Night = string.Empty;

	public string SkyFile1Night = string.Empty;

	public string SkyFile2Night = string.Empty;

	public string MusicFile = string.Empty;

	public int SkyType;

	public string SkyTop = string.Empty;

	public string SkyBottom = string.Empty;

	public string SkyLeft = string.Empty;

	public string SkyRight = string.Empty;

	public string SkyFront = string.Empty;

	public string SkyBack = string.Empty;

	public string SkyNightTop = string.Empty;

	public string SkyNightBottom = string.Empty;

	public string SkyNightLeft = string.Empty;

	public string SkyNightRight = string.Empty;

	public string SkyNightFront = string.Empty;

	public string SkyNightBack = string.Empty;

	public string ColorMappingTex = string.Empty;

	public const int FLAG_DIRLIGHT = 1;

	public const int FLAG_RAIN = 2;

	public const int FLAG_SNOW = 4;

	public const int FLAG_SUN = 8;

	public const int FLAG_MOON = 16;

	public bool HasFlag(int flag)
	{
		return (AreaFlags & flag) != 0;
	}

	public string FormatPosition()
	{
		return string.Format(Class16.smethod_0(1649094136), PosX, PosY, PosZ);
	}

	public string FormatExtents()
	{
		return string.Format(Class16.smethod_0(1649094136), HalfExtentX, HalfExtentY, HalfExtentZ);
	}

	public static Color ArgbIntToColor(int argb)
	{
		int alpha = (argb >> 24) & 0xFF;
		int red = (argb >> 16) & 0xFF;
		int green = (argb >> 8) & 0xFF;
		int blue = argb & 0xFF;
		return Color.FromArgb(alpha, red, green, blue);
	}

	public static int ColorToArgbInt(Color color_0)
	{
		return (color_0.A << 24) | (color_0.R << 16) | (color_0.G << 8) | color_0.B;
	}
}
