using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACE.Dependency.Cyotek.Windows.Forms.ImageBox;

internal class NativeMethods
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class SCROLLINFO
	{
		public int cbSize;

		public SIF fMask;

		public int nMin;

		public int nMax;

		public int nPage;

		public int nPos;

		public int nTrackPos;

		public SCROLLINFO()
		{
			cbSize = Marshal.SizeOf(this);
			nPage = 0;
			nMin = 0;
			nMax = 0;
			nPos = 0;
			nTrackPos = 0;
			fMask = (SIF)0;
		}
	}

	[Flags]
	public enum SIF
	{
		SIF_RANGE = 1,
		SIF_PAGE = 2,
		SIF_POS = 4,
		SIF_DISABLENOSCROLL = 8,
		SIF_TRACKPOS = 0x10,
		SIF_ALL = 0x17
	}

	public const int GWL_STYLE = -16;

	public const int SB_BOTH = 3;

	public const int SB_BOTTOM = 7;

	public const int SB_CTL = 2;

	public const int SB_ENDSCROLL = 8;

	public const int SB_HORZ = 0;

	public const int SB_LEFT = 6;

	public const int SB_LINEDOWN = 1;

	public const int SB_LINELEFT = 0;

	public const int SB_LINERIGHT = 1;

	public const int SB_LINEUP = 0;

	public const int SB_PAGEDOWN = 3;

	public const int SB_PAGELEFT = 2;

	public const int SB_PAGERIGHT = 3;

	public const int SB_PAGEUP = 2;

	public const int SB_RIGHT = 7;

	public const int SB_THUMBPOSITION = 4;

	public const int SB_THUMBTRACK = 5;

	public const int SB_TOP = 6;

	public const int SB_VERT = 1;

	public const int WM_HSCROLL = 276;

	public const int WM_VSCROLL = 277;

	public const int WS_BORDER = 8388608;

	public const int WS_EX_CLIENTEDGE = 512;

	public const int WS_HSCROLL = 1048576;

	public const int WS_VSCROLL = 2097152;

	public const int WM_MOUSEWHEEL = 522;

	public const int WM_MOUSEHWHEEL = 526;

	private NativeMethods()
	{
	}

	[DllImport("user32.dll", SetLastError = true)]
	public static extern int GetScrollInfo(IntPtr hwnd, int bar, [MarshalAs(UnmanagedType.LPStruct)] SCROLLINFO scrollInfo);

	[DllImport("kernel32.dll")]
	public static extern uint GetTickCount();

	[DllImport("user32.dll", SetLastError = true)]
	public static extern uint GetWindowLong(IntPtr hwnd, int index);

	[DllImport("user32.dll")]
	public static extern int SetScrollInfo(IntPtr hwnd, int bar, [MarshalAs(UnmanagedType.LPStruct)] SCROLLINFO scrollInfo, bool redraw);

	[DllImport("user32.dll")]
	public static extern int SetWindowLong(IntPtr hwnd, int index, uint newLong);

	[DllImport("user32.dll")]
	public static extern IntPtr WindowFromPoint(Point point);

	[DllImport("user32.dll")]
	public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
}
