using System;
using System.Runtime.InteropServices;

namespace ACE.RSGlobal;

[return: MarshalAs(UnmanagedType.U1)]
public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);
