using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ACE.BonFileEditor;

internal class WindowManager
{
	private static IntPtr intptr_0;

	public static IntPtr MainWindowHandle
	{
		[CompilerGenerated]
		get
		{
			return intptr_0;
		}
	}

	private static void smethod_0(IntPtr intptr_1)
	{
		intptr_0 = intptr_1;
	}

	[DllImport("user32.dll")]
	private static extern IntPtr GetForegroundWindow();

	public static IntPtr GetActiveWindow()
	{
		new StringBuilder(256);
		return GetForegroundWindow();
	}

	public static void SetMainHandle(IntPtr hnd)
	{
		smethod_0(hnd);
	}
}
