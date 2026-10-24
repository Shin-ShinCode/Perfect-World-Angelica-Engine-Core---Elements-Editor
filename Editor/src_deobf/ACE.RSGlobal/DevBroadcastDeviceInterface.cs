using System;
using System.Runtime.InteropServices;

namespace ACE.RSGlobal;

[StructLayout(LayoutKind.Sequential)]
internal class DevBroadcastDeviceInterface
{
	public int Size;

	public int DeviceType;

	public int Reserved;

	public Guid ClassGuid;

	public short Name;
}
