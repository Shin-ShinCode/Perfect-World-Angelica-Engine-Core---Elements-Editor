using System;
using System.Runtime.InteropServices;

namespace ACE.RSGlobal;

[StructLayout(LayoutKind.Sequential)]
public class CopyDataStruct
{
	public IntPtr dwData;

	public int cbData;

	public IntPtr lpData;
}
