using System.Runtime.InteropServices;

namespace ACE.Classes;

[StructLayout(LayoutKind.Sequential, Size = 68)]
public struct IdAndNameManaged
{
	public int item_id;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] name;
}
