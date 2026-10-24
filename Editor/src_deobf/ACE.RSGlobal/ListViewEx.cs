using System;
using System.Windows.Forms;

namespace ACE.RSGlobal;

public class ListViewEx : ListView
{
	public bool bBusy;

	protected override void WndProc(ref Message message_0)
	{
		if (bBusy && (message_0.Msg == 513 || message_0.Msg == 514 || message_0.Msg == 515 || message_0.Msg == 516 || message_0.Msg == 517 || message_0.Msg == 518 || message_0.Msg == 256 || message_0.Msg == 257))
		{
			message_0.Result = IntPtr.Zero;
			return;
		}
		try
		{
			base.WndProc(ref message_0);
		}
		catch (InvalidOperationException)
		{
			message_0.Result = IntPtr.Zero;
		}
		catch (NullReferenceException)
		{
			message_0.Result = IntPtr.Zero;
		}
		catch (InvalidCastException)
		{
			message_0.Result = IntPtr.Zero;
		}
	}
}
