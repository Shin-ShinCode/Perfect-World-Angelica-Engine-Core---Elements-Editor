using System.Runtime.InteropServices;

namespace ACE.RSGlobal;

public struct DEVMODE
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string dmDeviceName;

	public short dmSpecVersion;

	public short dmDriverVersion;

	public short dmSize;

	public short dmDriverExtra;

	public int dmFields;

	public int dmPositionX;

	public int dmPositionY;

	public int dmDisplayOrientation;

	public int dmDisplayFixedOutput;

	public short dmColor;

	public short dmDuplex;

	public short dmYResolution;

	public short dmTTOption;

	public short dmCollate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string dmFormName;

	public short dmLogPixels;

	public int dmBitsPerPel;

	public int dmPelsWidth;

	public int dmPelsHeight;

	public int dmDisplayFlags;

	public int dmDisplayFrequency;
}
