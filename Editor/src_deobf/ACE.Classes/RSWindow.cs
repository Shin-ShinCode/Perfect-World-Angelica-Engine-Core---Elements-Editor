using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.RSGlobal;

namespace ACE.Classes;

public class RSWindow
{
	private static class Class81
	{
		public static EnumWindowsProc enumWindowsProc_0;
	}

	private static string string_0;

	private static IntPtr intptr_0;

	public string WindowName;

	public string WindowClass;

	public IntPtr hWnd = IntPtr.Zero;

	public IntPtr ownerHwnd = IntPtr.Zero;

	public int iWait;

	public bool IsACE;

	public bool bProcessStarted;

	public string ACEArguments;

	public bool RunNewCopy;

	public RSWindow(IntPtr hWnd)
	{
		this.hWnd = hWnd;
	}

	public RSWindow(string WindowName, [MarshalAs(UnmanagedType.U1)] bool IsACE)
	{
		this.WindowName = WindowName;
		this.IsACE = IsACE;
	}

	public RSWindow(string WindowClass, string WindowName)
	{
		this.WindowName = WindowName;
		this.WindowClass = WindowClass;
	}

	public RSWindow(string WindowName)
	{
		this.WindowName = WindowName;
	}

	public int SendMessage(int msg, int wParam, int lParam)
	{
		GetHwnd();
		if (IsACE && ACEArguments != null && bProcessStarted)
		{
			return 1;
		}
		int result = global::ACE.RSGlobal.RSGlobal.SendMessage(hWnd, msg, wParam, lParam);
		GC.KeepAlive(this);
		return result;
	}

	public int SendMessage(int msg, IntPtr wParam, IntPtr lParam)
	{
		GetHwnd();
		if (IsACE && ACEArguments != null && bProcessStarted)
		{
			return 1;
		}
		int result = global::ACE.RSGlobal.RSGlobal.SendMessage(hWnd, msg, wParam, lParam);
		GC.KeepAlive(this);
		return result;
	}

	public int PostMessage(int msg, int wParam, int lParam)
	{
		int result = global::ACE.RSGlobal.RSGlobal.PostMessage(GetHwnd(), msg, wParam, lParam);
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsWindowAvailable(RSWindow window)
	{
		int num;
		if (window != null)
		{
			bool flag = window.GetHwnd() != IntPtr.Zero;
			GC.KeepAlive(window);
			if (flag)
			{
				num = 1;
				goto IL_0023;
			}
		}
		num = 0;
		goto IL_0023;
		IL_0023:
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool WaitForHandleCreation()
	{
		uint tickCount = global::ACE.RSGlobal.RSGlobal.GetTickCount();
		IntPtr hwnd = GetHwnd();
		bool flag = hwnd != IntPtr.Zero;
		GC.KeepAlive(this);
		if (!flag)
		{
			do
			{
				Application.DoEvents();
				if (global::ACE.RSGlobal.RSGlobal.GetTickCount() - tickCount <= 5000)
				{
					hwnd = GetHwnd();
					flag = hwnd != IntPtr.Zero;
					GC.KeepAlive(this);
					continue;
				}
				GC.KeepAlive(this);
				return false;
			}
			while (!flag);
		}
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool WaitForWindowCreation()
	{
		uint tickCount = global::ACE.RSGlobal.RSGlobal.GetTickCount();
		if (!global::ACE.RSGlobal.RSGlobal.IsWindowEnabled(hWnd))
		{
			do
			{
				Application.DoEvents();
				if (global::ACE.RSGlobal.RSGlobal.GetTickCount() - tickCount > 5000)
				{
					GC.KeepAlive(this);
					return false;
				}
			}
			while (!global::ACE.RSGlobal.RSGlobal.IsWindowEnabled(hWnd));
		}
		return true;
	}

	public IntPtr GetHwnd()
	{
		bProcessStarted = false;
		if (hWnd == IntPtr.Zero || !global::ACE.RSGlobal.RSGlobal.IsWindowEnabled(hWnd))
		{
			if (!string.IsNullOrWhiteSpace(WindowClass))
			{
				if (!string.IsNullOrEmpty(WindowName))
				{
					IntPtr intPtr = (IntPtr)global::ACE.RSGlobal.RSGlobal.FindWindow(WindowClass, WindowName);
					hWnd = intPtr;
				}
				else
				{
					IntPtr intPtr2 = (IntPtr)global::ACE.RSGlobal.RSGlobal.FindWindow(WindowClass, null);
					hWnd = intPtr2;
				}
			}
			else if (!string.IsNullOrEmpty(WindowName))
			{
				string_0 = WindowName;
				intptr_0 = IntPtr.Zero;
				global::ACE.RSGlobal.RSGlobal.EnumWindows(enumFunc, IntPtr.Zero);
				hWnd = intptr_0;
			}
		}
		if ((RunNewCopy || hWnd == IntPtr.Zero) && IsACE)
		{
			string text = Application.StartupPath + Class16.smethod_0(1648909093);
			if (File.Exists(Application.StartupPath + Class16.smethod_0(1648909112)))
			{
				text = Application.StartupPath + Class16.smethod_0(1648909145);
			}
			if (!File.Exists(text))
			{
				GC.KeepAlive(this);
				return IntPtr.Zero;
			}
			string aCEArguments = ACEArguments;
			if (aCEArguments != null && !aCEArguments.Contains(Class16.smethod_0(1648898666)))
			{
				Process.Start(text, Class16.smethod_0(1648898682) + aCEArguments);
			}
			else
			{
				Process.Start(text, Class16.smethod_0(1648898682) + aCEArguments);
			}
			RunNewCopy = false;
		}
		return hWnd;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Show()
	{
		IntPtr hwnd = GetHwnd();
		hWnd = hwnd;
		if (hWnd != IntPtr.Zero)
		{
			IntPtr intPtr = hWnd;
			global::ACE.RSGlobal.RSGlobal.ShowWindow(intPtr, FormWindowState.Minimized);
			GC.KeepAlive(this);
			return true;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool enumFunc(IntPtr hWnd, int lParam)
	{
		int num = global::ACE.RSGlobal.RSGlobal.GetWindowTextLength(hWnd) + 1;
		if (num > string_0.Length && global::ACE.RSGlobal.RSGlobal.IsWindowVisible(hWnd))
		{
			StringBuilder stringBuilder = new StringBuilder(num);
			global::ACE.RSGlobal.RSGlobal.GetWindowText(hWnd, stringBuilder, num);
			if (stringBuilder.ToString().Contains(string_0))
			{
				intptr_0 = hWnd;
				return false;
			}
		}
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsWindowVisible()
	{
		bool result = hWnd != IntPtr.Zero && global::ACE.RSGlobal.RSGlobal.IsWindowVisible(hWnd);
		GC.KeepAlive(this);
		return result;
	}

	public void Hide()
	{
		if (IsWindowVisible())
		{
			global::ACE.RSGlobal.RSGlobal.ShowWindow(hWnd, 0);
		}
		GC.KeepAlive(this);
	}

	public void ShowWithoutActivation()
	{
		global::ACE.RSGlobal.RSGlobal.ShowWindow(hWnd, 4);
		GC.KeepAlive(this);
	}

	public Point GetWindowPos()
	{
		Point result = default(Point);
		RECT rECT = default(RECT);
		IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf<RECT>());
		try
		{
			global::ACE.RSGlobal.RSGlobal.GetWindowRect(hWnd, intPtr);
			rECT = Marshal.PtrToStructure<RECT>(intPtr);
			result.X = rECT.left;
			result.Y = rECT.top;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsWindowOnScreen()
	{
		if (!IsWindowVisible())
		{
			return false;
		}
		Point windowPos = GetWindowPos();
		Rectangle virtualScreen = SystemInformation.VirtualScreen;
		Rectangle virtualScreen2 = SystemInformation.VirtualScreen;
		int y = virtualScreen.Height - 100;
		int x = virtualScreen2.Width - 100;
		bool result = global::ACE.RSGlobal.RSGlobal.IsPointOnPlane(0, x, 0, y, windowPos.X, windowPos.Y);
		GC.KeepAlive(this);
		return result;
	}

	public void SetPosition(int int_0, int int_1, [MarshalAs(UnmanagedType.U1)] bool bCheckBorders, int current_width, int current_height)
	{
		if (bCheckBorders)
		{
			if (current_width == -1)
			{
				RECT rECT = default(RECT);
				IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf<RECT>());
				try
				{
					global::ACE.RSGlobal.RSGlobal.GetWindowRect(hWnd, intPtr);
					rECT = Marshal.PtrToStructure<RECT>(intPtr);
					current_width = rECT.right - rECT.left;
					current_height = rECT.bottom - rECT.top;
				}
				finally
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			if (int_0 + current_width > SystemInformation.VirtualScreen.Width)
			{
				int_0 = SystemInformation.VirtualScreen.Width - current_width;
			}
			if (int_1 == -1)
			{
				int_1 = SystemInformation.VirtualScreen.Height / 2 - current_height / 2;
			}
		}
		global::ACE.RSGlobal.RSGlobal.SetWindowPos(hWnd, ownerHwnd, int_0, int_1, 0, 0, 17u);
		GC.KeepAlive(this);
	}
}
