// TODO(recovered): minimal mshtml interop shim.
// The original assembly referenced the Microsoft.mshtml PIA, which is not resolvable in
// an SDK-only net48 build. Only two surfaces are actually used by the editor:
//   * tagPOINT  -- a COM POINT struct (used with user32 WindowFromPoint / GetCursorPos)
//   * IHTMLDocument2.createStyleSheet(...).cssText  -- to inject CSS into the tooltip
//     WebBrowser document.
// These are reproduced here with the original COM GUIDs/layout so behavior is preserved.
using System;
using System.Runtime.InteropServices;

namespace mshtml
{
	[StructLayout(LayoutKind.Sequential)]
	public struct tagPOINT
	{
		public int x;
		public int y;
	}

	[ComImport]
	[Guid("3050F37E-98B5-11CF-BB82-00AA00BDCE0B")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IHTMLStyleSheet
	{
		[DispId(1037)]
		string cssText { get; set; }
	}

	[ComImport]
	[Guid("332C4425-26CB-11D0-B483-00C04FD90119")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IHTMLDocument2
	{
		[DispId(1078)]
		IHTMLStyleSheet createStyleSheet([In] string bstrHref, [In] int lIndex);
	}
}
