using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ACE.Classes;

[StructLayout(LayoutKind.Sequential, Size = 2048)]
[CLSCompliant(false)]
[UnsafeValueType]
[NativeCppClass]
public struct ITEMDATA
{
	[StructLayout(LayoutKind.Sequential, Size = 24)]
	[CLSCompliant(false)]
	[NativeCppClass]
	[UnsafeValueType]
	public struct addon
	{
	}
}
