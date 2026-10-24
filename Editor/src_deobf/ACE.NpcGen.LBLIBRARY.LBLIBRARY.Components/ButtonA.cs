using System;
using System.Drawing;
using System.Windows.Forms;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class ButtonA : Button
{
	private Color color_0 = Color.FromArgb(160, 180, 200);

	private Color color_1;

	private Color color_2 = Color.Teal;

	private bool bool_0 = true;

	private Color color_3 = Color.FromArgb(0, 0, 140);

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

	public bool ChangeColorMouseHC
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
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

	public ButtonA()
	{
		base.Size = new Size(31, 24);
		ForeColor = Color.White;
		base.FlatStyle = FlatStyle.Flat;
		Font = new Font(Class16.smethod_0(1649118691), 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Text = Class16.smethod_0(1648923968);
		string_0 = Text;
	}

	protected override void OnMouseDown(MouseEventArgs mevent)
	{
		base.OnMouseDown(mevent);
		if (bool_0)
		{
			color_2 = color_0;
		}
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
		if (bool_0)
		{
			color_2 = color_1;
		}
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		if (bool_0)
		{
			color_2 = color_1;
		}
	}

	protected override void OnPaint(PaintEventArgs pe)
	{
		base.OnPaint(pe);
		string_0 = Text;
		if (int_0 == 100 && int_1 == 25)
		{
			int_0 = base.Width / 3 + 10;
			int_1 = base.Height / 2 - 1;
		}
		Point point = new Point(int_0, int_1);
		pe.Graphics.FillRectangle(new SolidBrush(color_2), base.ClientRectangle);
		pe.Graphics.DrawString(string_0, Font, new SolidBrush(ForeColor), point);
	}
}
