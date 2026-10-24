using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ACE.ImageCombo;

public class ImageCombo : ComboBox
{
	public delegate void PopupItemSelectionChangedHandler(object sender, PopupItemSelectionChangedEventArgs e);

	private ImageList imageList_0 = new ImageList();

	private int int_0 = -1;

	private IntPtr intptr_0;

	private PopupItemSelectionChangedHandler popupItemSelectionChangedHandler_0;

	public int SelectedIndexPopup
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public IntPtr ListBoxHandle
	{
		[CompilerGenerated]
		get
		{
			return intptr_0;
		}
	}

	public ImageList ImageList
	{
		get
		{
			return imageList_0;
		}
		set
		{
			imageList_0 = value;
		}
	}

	public event PopupItemSelectionChangedHandler PopupItemSelectionChanged
	{
		[CompilerGenerated]
		add
		{
			PopupItemSelectionChangedHandler popupItemSelectionChangedHandler = popupItemSelectionChangedHandler_0;
			PopupItemSelectionChangedHandler popupItemSelectionChangedHandler2;
			do
			{
				popupItemSelectionChangedHandler2 = popupItemSelectionChangedHandler;
				PopupItemSelectionChangedHandler value2 = (PopupItemSelectionChangedHandler)Delegate.Combine(popupItemSelectionChangedHandler2, value);
				popupItemSelectionChangedHandler = Interlocked.CompareExchange(ref popupItemSelectionChangedHandler_0, value2, popupItemSelectionChangedHandler2);
			}
			while ((object)popupItemSelectionChangedHandler != popupItemSelectionChangedHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PopupItemSelectionChangedHandler popupItemSelectionChangedHandler = popupItemSelectionChangedHandler_0;
			PopupItemSelectionChangedHandler popupItemSelectionChangedHandler2;
			do
			{
				popupItemSelectionChangedHandler2 = popupItemSelectionChangedHandler;
				PopupItemSelectionChangedHandler value2 = (PopupItemSelectionChangedHandler)Delegate.Remove(popupItemSelectionChangedHandler2, value);
				popupItemSelectionChangedHandler = Interlocked.CompareExchange(ref popupItemSelectionChangedHandler_0, value2, popupItemSelectionChangedHandler2);
			}
			while ((object)popupItemSelectionChangedHandler != popupItemSelectionChangedHandler2);
		}
	}

	public ImageCombo()
	{
		base.DrawMode = DrawMode.OwnerDrawFixed;
	}

	private void method_0(IntPtr intptr_1)
	{
		intptr_0 = intptr_1;
	}

	protected virtual void OnPopupItemSelectionChanged(int ItemIndex, bool IsSelected)
	{
		popupItemSelectionChangedHandler_0?.Invoke(this, new PopupItemSelectionChangedEventArgs(ItemIndex, IsSelected));
	}

	protected override void OnDrawItem(DrawItemEventArgs drawItemEventArgs_0)
	{
		drawItemEventArgs_0.DrawBackground();
		drawItemEventArgs_0.DrawFocusRectangle();
		SolidBrush solidBrush = new SolidBrush(drawItemEventArgs_0.ForeColor);
		try
		{
			if (drawItemEventArgs_0.Index < 0)
			{
				drawItemEventArgs_0.Graphics.DrawString(Text, drawItemEventArgs_0.Font, solidBrush, drawItemEventArgs_0.Bounds.Left + imageList_0.ImageSize.Width, drawItemEventArgs_0.Bounds.Top);
			}
			else if (base.Items[drawItemEventArgs_0.Index].GetType() == typeof(ImageComboItem))
			{
				ImageComboItem imageComboItem = (ImageComboItem)base.Items[drawItemEventArgs_0.Index];
				Color color = ((imageComboItem.ForeColor != Color.FromKnownColor(KnownColor.Transparent)) ? imageComboItem.ForeColor : drawItemEventArgs_0.ForeColor);
				Font font = (imageComboItem.Indicate ? new Font(drawItemEventArgs_0.Font, FontStyle.Bold) : drawItemEventArgs_0.Font);
				SolidBrush solidBrush2 = new SolidBrush(color);
				try
				{
					if (imageComboItem.ImageIndex != -1 && imageList_0 != null && imageList_0.Images.Count > 0 && imageComboItem.ImageIndex >= 0 && imageComboItem.ImageIndex < imageList_0.Images.Count)
					{
						ImageList.Draw(drawItemEventArgs_0.Graphics, drawItemEventArgs_0.Bounds.Left, drawItemEventArgs_0.Bounds.Top, imageComboItem.ImageIndex);
						drawItemEventArgs_0.Graphics.DrawString(imageComboItem.ItemText, font, solidBrush2, drawItemEventArgs_0.Bounds.Left + imageList_0.ImageSize.Width, drawItemEventArgs_0.Bounds.Top);
					}
					else
					{
						drawItemEventArgs_0.Graphics.DrawString(imageComboItem.ItemText, font, solidBrush2, drawItemEventArgs_0.Bounds.Left + imageList_0.ImageSize.Width, drawItemEventArgs_0.Bounds.Top);
					}
				}
				finally
				{
					((IDisposable)solidBrush2).Dispose();
				}
			}
			else
			{
				drawItemEventArgs_0.Graphics.DrawString(base.Items[drawItemEventArgs_0.Index].ToString(), drawItemEventArgs_0.Font, solidBrush, drawItemEventArgs_0.Bounds.Left + imageList_0.ImageSize.Width, drawItemEventArgs_0.Bounds.Top);
			}
			if ((drawItemEventArgs_0.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				OnPopupItemSelectionChanged(drawItemEventArgs_0.Index, IsSelected: true);
				SelectedIndexPopup = drawItemEventArgs_0.Index;
			}
			else
			{
				OnPopupItemSelectionChanged(drawItemEventArgs_0.Index, IsSelected: false);
			}
			base.OnDrawItem(drawItemEventArgs_0);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
	}

	protected override void OnDropDownClosed(EventArgs eventArgs_0)
	{
		SelectedIndexPopup = -1;
		OnPopupItemSelectionChanged(-1, IsSelected: false);
		base.OnDropDownClosed(eventArgs_0);
	}

	protected override void WndProc(ref Message message_0)
	{
		if (message_0.Msg == 308)
		{
			method_0(message_0.LParam);
		}
		base.WndProc(ref message_0);
	}
}
