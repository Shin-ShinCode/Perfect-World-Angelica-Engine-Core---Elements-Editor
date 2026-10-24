using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ACE.RSGlobal;

[DefaultMember("Item")]
public class DataGridViewEx : DataGridView
{
	private EventHandler eventHandler_0;

	public int MouseDownTime;

	[SpecialName]
	public event EventHandler DragStart
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			eventHandler_0 = (EventHandler)Delegate.Combine(eventHandler_0, value);
			GC.KeepAlive(this);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			eventHandler_0 = (EventHandler)Delegate.Remove(eventHandler_0, value);
			GC.KeepAlive(this);
		}
	}

	[SpecialName]
	protected void raise_DragStart(object sender, EventArgs e)
	{
		eventHandler_0?.Invoke(sender, e);
	}

	protected override void WndProc(ref Message message_0)
	{
		try
		{
			if (message_0.Msg == 513 && (int)message_0.WParam == 1 && base.SelectedRows.Count > 1)
			{
				int num = (short)(int)message_0.LParam;
				int num2 = (short)((int)message_0.LParam >>> 16);
				HitTestInfo hitTestInfo = HitTest(num, num2);
				int num3 = -1;
				if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
				{
					num3 = hitTestInfo.RowIndex;
				}
				if (MouseDownTime == 0 && num3 > -1 && base.SelectedRows.Contains(base.Rows[num3]))
				{
					MouseDownTime = (int)RSGlobal.GetTickCount();
					IntPtr result = (IntPtr)1;
					message_0.Result = result;
					raise_DragStart(message_0, null);
				}
				else
				{
					MouseDownTime = 0;
					base.WndProc(ref message_0);
				}
			}
			else
			{
				base.WndProc(ref message_0);
			}
		}
		catch (InvalidOperationException)
		{
			message_0.Result = IntPtr.Zero;
		}
		catch (InvalidCastException)
		{
			message_0.Result = IntPtr.Zero;
		}
		catch (ArgumentException)
		{
			message_0.Result = IntPtr.Zero;
		}
	}
}
