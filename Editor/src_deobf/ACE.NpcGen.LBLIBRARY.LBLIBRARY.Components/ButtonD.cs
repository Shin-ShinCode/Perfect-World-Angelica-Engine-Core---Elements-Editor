using System;
using System.Drawing;
using System.Windows.Forms;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class ButtonD : Button
{
	public enum CustomFormState
	{
		Normal,
		Maximize
	}

	private CustomFormState customFormState_0;

	private Color color_0 = Color.FromArgb(160, 180, 200);

	private Color color_1;

	private Color color_2 = Color.Gray;

	private Color color_3 = Color.FromArgb(180, 200, 240);

	private string string_0 = Class16.smethod_0(1648923968);

	private int int_0 = 6;

	private int int_1 = -20;

	public Color BZBackColor
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
			Invalidate();
		}
	}

	public CustomFormState CFormState
	{
		get
		{
			return customFormState_0;
		}
		set
		{
			customFormState_0 = value;
			Invalidate();
		}
	}

	public string DisplayText
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			Invalidate();
		}
	}

	public Color MouseClickColor1
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			Invalidate();
		}
	}

	public Color MouseHoverColor
	{
		get
		{
			return color_3;
		}
		set
		{
			color_3 = value;
			Invalidate();
		}
	}

	public int TextLocation_X
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			Invalidate();
		}
	}

	public int TextLocation_Y
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
			Invalidate();
		}
	}

	public ButtonD()
	{
		base.Size = new Size(31, 24);
		ForeColor = Color.White;
		base.FlatStyle = FlatStyle.Flat;
		Text = Class16.smethod_0(1648923968);
		string_0 = Text;
	}

	protected override void OnMouseDown(MouseEventArgs mevent)
	{
		base.OnMouseDown(mevent);
		color_2 = color_0;
	}

	protected override void OnMouseEnter(EventArgs eventArgs_0)
	{
		base.OnMouseEnter(eventArgs_0);
		color_1 = color_2;
		color_2 = color_3;
	}

	protected override void OnMouseLeave(EventArgs eventArgs_0)
	{
		base.OnMouseLeave(eventArgs_0);
		color_2 = color_1;
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		color_2 = color_1;
	}

	protected override void OnPaint(PaintEventArgs pe)
	{
		base.OnPaint(pe);
		switch (customFormState_0)
		{
		case CustomFormState.Maximize:
		{
			pe.Graphics.FillRectangle(new SolidBrush(color_2), base.ClientRectangle);
			for (int j = 0; j < 2; j++)
			{
				pe.Graphics.DrawRectangle(new Pen(ForeColor), int_0 + 5, int_1, 8, 8);
				pe.Graphics.FillRectangle(new SolidBrush(ForeColor), int_0 + 5, int_1 - 1, 9, 4);
				pe.Graphics.DrawRectangle(new Pen(ForeColor), int_0 + 2, int_1 + 5, 8, 8);
				pe.Graphics.FillRectangle(new SolidBrush(ForeColor), int_0 + 2, int_1 + 4, 9, 4);
			}
			break;
		}
		case CustomFormState.Normal:
		{
			pe.Graphics.FillRectangle(new SolidBrush(color_2), base.ClientRectangle);
			for (int i = 0; i < 2; i++)
			{
				pe.Graphics.DrawRectangle(new Pen(ForeColor), int_0 + i + 1, int_1, 10, 10);
				pe.Graphics.FillRectangle(new SolidBrush(ForeColor), int_0 + 1, int_1 - 1, 12, 4);
			}
			break;
		}
		}
	}
}
