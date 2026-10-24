using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACE.BonFileEditor;

public static class WinApi
{
	[Flags]
	public enum AllocationType
	{
		Commit = 0x1000,
		Reserve = 0x2000,
		Decommit = 0x4000,
		Release = 0x8000,
		Reset = 0x80000,
		Physical = 0x400000,
		TopDown = 0x100000,
		WriteWatch = 0x200000,
		LargePages = 0x20000000
	}

	[Flags]
	public enum FreeType
	{
		Decommit = 0x4000,
		Release = 0x8000
	}

	public static class HWND
	{
		public static IntPtr NoTopMost = new IntPtr(-2);

		public static IntPtr TopMost = new IntPtr(-1);

		public static IntPtr Top = new IntPtr(0);

		public static IntPtr Bottom = new IntPtr(1);
	}

	public delegate int KeyboardHookProc(int code, int wParam, ref KeyboardHookStruct lParam);

	public struct KeyboardHookStruct
	{
		public int vkCode;

		public int scanCode;

		public int flags;

		public int time;

		public int dwExtraInfo;
	}

	[Flags]
	public enum MemoryProtection
	{
		Execute = 0x10,
		ExecuteRead = 0x20,
		ExecuteReadWrite = 0x40,
		ExecuteWriteCopy = 0x80,
		NoAccess = 1,
		ReadOnly = 2,
		ReadWrite = 4,
		WriteCopy = 8,
		GuardModifierflag = 0x100,
		NoCacheModifierflag = 0x200,
		WriteCombineModifierflag = 0x400
	}

	[Flags]
	public enum Msg
	{
		SetText = 0xC,
		Close = 0x10,
		ButtonDown = 0x201,
		ButtonUp = 0x202
	}

	[Flags]
	public enum ProcessAccessFlags : uint
	{
		All = 0x1F0FFFu,
		Terminate = 1u,
		CreateThread = 2u,
		VmOperation = 8u,
		VmRead = 0x10u,
		VmWrite = 0x20u,
		DupHandle = 0x40u,
		SetInformation = 0x200u,
		QueryInformation = 0x400u,
		Synchronize = 0x100000u
	}

	[Flags]
	public enum SetWinPosFlag
	{
		NOSIZE = 1,
		NOMOVE = 2,
		NOZORDER = 4,
		NOREDRAW = 8,
		NOACTIVATE = 0x10,
		DRAWFRAME = 0x20,
		FRAMECHANGED = 0x20,
		SHOWWINDOW = 0x40,
		HIDEWINDOW = 0x80,
		NOCOPYBITS = 0x100,
		NOOWNERZORDER = 0x200,
		NOREPOSITION = 0x200,
		NOSENDCHANGING = 0x400,
		DEFERERASE = 0x2000,
		ASYNCWINDOWPOS = 0x4000
	}

	public const int WH_KEYBOARD_LL = 13;

	public const int WM_KEYDOWN = 256;

	public const int WM_KEYUP = 257;

	public const int WM_SYSKEYDOWN = 260;

	public const int WM_SYSKEYUP = 261;

	private static readonly IntPtr intptr_0 = new IntPtr(-1);

	private static readonly IntPtr intptr_1 = new IntPtr(-2);

	private static readonly IntPtr intptr_2 = new IntPtr(0);

	private static readonly IntPtr intptr_3 = new IntPtr(1);

	[DllImport("kernel32.dll")]
	public static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseHandle(IntPtr hObject);

	[DllImport("kernel32.dll")]
	public static extern int ReadProcessMemory(IntPtr hProcess, int lpBaseAddress, [In][Out] byte[] buffer, int size, out int lpNumberOfBytesRead);

	[DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
	public static extern int ReadProcessMemory_1(IntPtr hProcess, long lpBaseAddress, byte[] buffer, int size, out int lpNumberOfBytesRead);

	[DllImport("kernel32.dll")]
	public static extern bool WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, [In][Out] byte[] buffer, int nSize, out int lpNumberOfBytesWritten);

	[DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
	public static extern bool WriteProcessMemory_1(IntPtr hProcess, long lpBaseAddress, [In][Out] byte[] buffer, int nSize, out int lpNumberOfBytesWritten);

	[DllImport("kernel32.dll")]
	public static extern bool WriteProcessMemory64(IntPtr hProcess, long lpBaseAddress, IntPtr buffer, int nSize, out int lpNumberOfBytesWritten);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern int VirtualAllocEx(IntPtr hProcess, int lpAddress, int dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr VirtualAlloc(int lpAddress, int dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool VirtualFreeEx(IntPtr hProcess, int lpAddress, int dwSize, FreeType dwFreeType);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool VirtualFree(int lpAddress, int dwSize, FreeType dwFreeType);

	[DllImport("kernel32.dll")]
	public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, int dwStackSize, int lpStartAddress, IntPtr lpParameter, int dwCreationFlags, out IntPtr lpThreadId);

	[DllImport("kernel32.dll")]
	public static extern IntPtr CreateThread(IntPtr lpThreadAttributes, int dwStackSize, int lpStartAddress, IntPtr lpParameter, int dwCreationFlags, out IntPtr lpThreadId);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

	public static string GetWindowClass(IntPtr handle)
	{
		StringBuilder stringBuilder = new StringBuilder(128);
		GetClassName(handle, stringBuilder, 128);
		return stringBuilder.ToString();
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

	public static string GetWindowText(IntPtr handle)
	{
		StringBuilder stringBuilder = new StringBuilder(128);
		GetWindowText(handle, stringBuilder, 128);
		return stringBuilder.ToString();
	}

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int int_0, int int_1, int cx, int cy, SetWinPosFlag uFlags);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern IntPtr LoadLibraryW(string lpFileName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

	[DllImport("user32.dll")]
	public static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookProc callback, IntPtr hInstance, uint threadId);

	[DllImport("user32.dll")]
	public static extern bool UnhookWindowsHookEx(IntPtr hInstance);

	[DllImport("user32.dll")]
	public static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref KeyboardHookStruct lParam);

	[DllImport("user32.dll")]
	public static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll")]
	public static extern int SendMessage(int hWnd, int Msg, int wParam, string lParam);
}
