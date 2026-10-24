using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ACE.NpcGen.LBLIBRARY;

public class CheckBoxZ : CheckBox
{
	private int int_0 = 90;

	private int int_1;

	public int boxlocaty;

	private int int_2 = 18;

	private Color color_0;

	private Color color_1;

	private Color color_2 = Color.SteelBlue;

	private int int_3 = 150;

	private Color color_3 = Color.DarkBlue;

	private int int_4 = 150;

	private Color color_4 = Color.Yellow;

	private Color color_5 = Color.DarkOrange;

	private string string_0 = string.Empty;

	private int int_5 = 14;

	private int int_6 = 4;

	public int BoxLocation_X
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

	public int TextLocation_X
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
			Invalidate();
		}
	}

	public int TextLocation_Y
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
			Invalidate();
		}
	}

	public int Transparent1
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
			if (int_3 > 255)
			{
				int_3 = 255;
				Invalidate();
			}
			else
			{
				Invalidate();
			}
		}
	}

	public int Transparent2
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
			if (int_4 > 255)
			{
				int_4 = 255;
				Invalidate();
			}
			else
			{
				Invalidate();
			}
		}
	}

	public CheckBoxZ()
	{
		ForeColor = Color.White;
		AutoSize = false;
	}

	protected override void OnMouseEnter(EventArgs eventArgs_0)
	{
		base.OnMouseEnter(eventArgs_0);
		color_0 = color_2;
		color_1 = color_3;
		color_2 = color_4;
		color_3 = color_5;
	}

	protected override void OnMouseLeave(EventArgs eventArgs_0)
	{
		base.OnMouseLeave(eventArgs_0);
		color_2 = color_0;
		color_3 = color_1;
	}

	protected override void OnPaint(PaintEventArgs paintEventArgs_0)
	{
		base.OnPaint(paintEventArgs_0);
		AutoSize = false;
		string_0 = Text;
		if (int_5 == 100 && int_6 == 25)
		{
			int_5 = base.Width / 3 + 10;
			int_6 = base.Height / 2 - 1;
		}
		Color color = Color.FromArgb(int_3, color_2);
		Color color2 = Color.FromArgb(int_4, color_3);
		Brush brush = new LinearGradientBrush(base.ClientRectangle, color, color2, int_0);
		Point point = new Point(int_5, int_6);
		SolidBrush brush2 = new SolidBrush(ForeColor);
		paintEventArgs_0.Graphics.FillRectangle(brush, base.ClientRectangle);
		paintEventArgs_0.Graphics.DrawString(string_0, Font, brush2, point);
		ControlPaint.DrawCheckBox(rectangle: new Rectangle(int_1, boxlocaty, int_2, int_2), graphics: paintEventArgs_0.Graphics, state: base.Checked ? ButtonState.Checked : ButtonState.Normal);
		brush.Dispose();
	}
}
