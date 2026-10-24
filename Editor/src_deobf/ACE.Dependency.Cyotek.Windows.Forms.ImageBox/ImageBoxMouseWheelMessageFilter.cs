using System;
using System.Drawing;
using System.Windows.Forms;

namespace ACE.Dependency.Cyotek.Windows.Forms.ImageBox;

internal sealed class ImageBoxMouseWheelMessageFilter : IMessageFilter
{
	private static ImageBoxMouseWheelMessageFilter imageBoxMouseWheelMessageFilter_0;

	private static bool bool_0;

	public static bool Active
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (bool_0 == value)
			{
				return;
			}
			bool_0 = value;
			if (bool_0)
			{
				if (imageBoxMouseWheelMessageFilter_0 == null)
				{
					imageBoxMouseWheelMessageFilter_0 = new ImageBoxMouseWheelMessageFilter();
				}
				Application.AddMessageFilter(imageBoxMouseWheelMessageFilter_0);
			}
			else if (imageBoxMouseWheelMessageFilter_0 != null)
			{
				Application.RemoveMessageFilter(imageBoxMouseWheelMessageFilter_0);
			}
		}
	}

	private ImageBoxMouseWheelMessageFilter()
	{
	}

	bool IMessageFilter.PreFilterMessage(ref Message message_0)
	{
		int msg = message_0.Msg;
		if (msg != 522 && msg != 526)
		{
			return false;
		}
		IntPtr intPtr = NativeMethods.WindowFromPoint(new Point((int)message_0.LParam));
		if (intPtr == message_0.HWnd)
		{
			return false;
		}
		if (Control.FromHandle(intPtr) is ImageBox { AllowUnfocusedMouseWheel: not false })
		{
			NativeMethods.SendMessage(intPtr, message_0.Msg, message_0.WParam, message_0.LParam);
			return true;
		}
		return false;
	}
}
