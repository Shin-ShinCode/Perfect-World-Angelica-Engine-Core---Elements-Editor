using System.IO;
using System.Runtime.InteropServices;
using ACE.RSGlobal;

namespace ACE.Classes;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 2)]
public struct ExportInfo
{
	public int export_time;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string export_vss_name;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string export_computer_name;

	public void Write(BinaryWriter bw)
	{
		global::ACE.RSGlobal.RSGlobal.WriteStruct(bw, this);
	}

	public static ExportInfo Read(BinaryReader br)
	{
		return global::ACE.RSGlobal.RSGlobal.ReadStruct<ExportInfo>(br);
	}
}
