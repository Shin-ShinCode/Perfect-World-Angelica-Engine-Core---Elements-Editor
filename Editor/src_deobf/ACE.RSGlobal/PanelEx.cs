using System;
using System.Windows.Forms;

namespace ACE.RSGlobal;

public class PanelEx : Panel
{
	public short scroll_step;

	protected override void WndProc(ref Message message_0)
	{
		if (message_0.Msg == 522)
		{
			short num = scroll_step;
			if ((short)((long)message_0.WParam >>> 16) < 0)
			{
				num = (short)(-num);
			}
			long num2 = message_0.WParam.ToInt64();
			long value = (ushort)num2 | ((ushort)num << 16);
			message_0.WParam = new IntPtr(value);
		}
		base.WndProc(ref message_0);
	}
}
