using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class ButtonC : Button
{
	public enum ButtonsShapes
	{
		Rect,
		RoundRect,
		Circle
	}

	public Color borderColor = Color.Transparent;

	public int borderWidth = 2;

	public Color buttonborder_1 = Color.FromArgb(220, 220, 220);

	public Color buttonborder_2 = Color.FromArgb(150, 150, 150);

	public bool ImToHeight;

	public bool showButtonText = true;

	private int int_0 = 90;

	private ButtonsShapes buttonsShapes_0;

	private Color color_0 = Color.Yellow;

	private Color color_1 = Color.Red;

	private Color color_2;

	private Color color_3;

	private Color color_4 = Color.DodgerBlue;

	private int int_1 = 250;

	private Color color_5 = Color.MidnightBlue;

	private int int_2 = 250;

	private Bitmap bitmap_0;

	private Point point_0;

	private Color color_6 = Color.Turquoise;

	private Color color_7 = Color.DarkSlateGray;

	private string string_0 = string.Empty;

	private int int_3 = 100;

	private int int_4 = 25;

	public Color BorderColor
	{
		get
		{
			return borderColor;
		}
		set
		{
			borderColor = value;
			if (borderColor == Color.Transparent)
			{
				buttonborder_1 = Color.FromArgb(220, 220, 220);
				buttonborder_2 = Color.FromArgb(150, 150, 150);
			}
			else
			{
				method_3(borderColor);
			}
		}
	}

	public int BorderWidth
	{
		get
		{
			return borderWidth;
		}
		set
		{
			borderWidth = value;
			Invalidate();
		}
	}

	public ButtonsShapes ButtonShape
	{
		get
		{
			return buttonsShapes_0;
		}
		set
		{
			buttonsShapes_0 = value;
			Invalidate();
		}
	}

	public string ButtonText
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

	public Color EndColor
	{
		get
		{
			return color_5;
		}
		set
		{
			color_5 = value;
			Invalidate();
		}
	}

	public int GradientAngle
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

	[Category("Image")]
	public new Bitmap Image
	{
		get
		{
			return bitmap_0;
		}
		set
		{
			bitmap_0 = value;
		}
	}

	[Category("Image")]
	public Point Image_Location
	{
		get
		{
			return point_0;
		}
		set
		{
			point_0 = value;
			Invalidate();
		}
	}

	[Category("Image")]
	public bool ImageToHeight
	{
		get
		{
			return ImToHeight;
		}
		set
		{
			ImToHeight = value;
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

	public Color MouseClickColor2
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			Invalidate();
		}
	}

	public Color MouseHoverColor1
	{
		get
		{
			return color_6;
		}
		set
		{
			color_6 = value;
			Invalidate();
		}
	}

	public Color MouseHoverColor2
	{
		get
		{
			return color_7;
		}
		set
		{
			color_7 = value;
			Invalidate();
		}
	}

	public bool ShowButtontext
	{
		get
		{
			return showButtonText;
		}
		set
		{
			showButtonText = value;
			Invalidate();
		}
	}

	public Color StartColor
	{
		get
		{
			return color_4;
		}
		set
		{
			color_4 = value;
			Invalidate();
		}
	}

	public int TextLocation_X
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
			Invalidate();
		}
	}

	public int TextLocation_Y
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
			Invalidate();
		}
	}

	public int Transparent1
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
			if (int_1 > 255)
			{
				int_1 = 255;
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
			return int_2;
		}
		set
		{
			int_2 = value;
			if (int_2 > 255)
			{
				int_2 = 255;
				Invalidate();
			}
			else
			{
				Invalidate();
			}
		}
	}

	public ButtonC()
	{
		base.Size = new Size(100, 40);
		BackColor = Color.Transparent;
		base.FlatStyle = FlatStyle.Flat;
		base.FlatAppearance.BorderSize = 0;
		base.FlatAppearance.MouseOverBackColor = Color.Transparent;
		base.FlatAppearance.MouseDownBackColor = Color.Transparent;
		string_0 = Text;
	}

	protected override void OnLostFocus(EventArgs eventArgs_0)
	{
		base.OnLostFocus(eventArgs_0);
		color_4 = color_2;
		color_5 = color_3;
		Invalidate();
	}

	protected override void OnMouseDown(MouseEventArgs mevent)
	{
		base.OnMouseDown(mevent);
		color_4 = color_0;
		color_5 = color_1;
		int num = borderColor.R - 40;
		int num2 = borderColor.G - 40;
		int num3 = borderColor.B - 40;
		if (num < 0)
		{
			num = 0;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num3 < 0)
		{
			num3 = 0;
		}
		buttonborder_2 = Color.FromArgb(num, num2, num3);
		buttonborder_1 = borderColor;
		Invalidate();
	}

	protected override void OnMouseEnter(EventArgs eventArgs_0)
	{
		base.OnMouseEnter(eventArgs_0);
		color_2 = color_4;
		color_3 = color_5;
		color_4 = color_6;
		color_5 = color_7;
	}

	protected override void OnMouseLeave(EventArgs eventArgs_0)
	{
		base.OnMouseLeave(eventArgs_0);
		color_4 = color_2;
		color_5 = color_3;
		method_3(borderColor);
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		OnMouseLeave(mevent);
		color_4 = color_2;
		color_5 = color_3;
		method_3(borderColor);
		Invalidate();
	}

	protected override void OnPaint(PaintEventArgs paintEventArgs_0)
	{
		base.OnPaint(paintEventArgs_0);
		switch (buttonsShapes_0)
		{
		case ButtonsShapes.Rect:
			method_1(paintEventArgs_0.Graphics);
			break;
		case ButtonsShapes.RoundRect:
			method_2(paintEventArgs_0.Graphics);
			break;
		case ButtonsShapes.Circle:
			method_0(paintEventArgs_0.Graphics);
			break;
		}
	}

	protected override void OnResize(EventArgs eventArgs_0)
	{
		base.OnResize(eventArgs_0);
		int_3 = base.Width / 3 - 1;
		int_4 = base.Height / 3 + 5;
	}

	private void method_0(Graphics graphics_0)
	{
		Color color = Color.FromArgb(int_1, color_4);
		Color color2 = Color.FromArgb(int_2, color_5);
		Brush brush = new LinearGradientBrush(base.ClientRectangle, color, color2, int_0);
		graphics_0.FillEllipse(brush, 5, 5, base.Width - 10, base.Height - 10);
		for (int i = 0; i < borderWidth; i++)
		{
			graphics_0.DrawArc(new Pen(new SolidBrush(buttonborder_1)), 5 + i, 5, base.Width - 10, base.Height - 10, 120, 180);
			graphics_0.DrawArc(new Pen(new SolidBrush(buttonborder_2)), 5, 5, base.Width - (10 + i), base.Height - 10, 300, 180);
		}
		if (showButtonText)
		{
			Point point = new Point(int_3, int_4);
			SolidBrush brush2 = new SolidBrush(ForeColor);
			graphics_0.DrawString(string_0, Font, brush2, point);
		}
		if (bitmap_0 != null)
		{
			Bitmap source = bitmap_0;
			if (ImToHeight)
			{
				source = source.ResizeImage(base.Height - 2, base.Height - 2);
			}
			graphics_0.DrawImage(source, point_0.X + 1, point_0.Y + 1);
		}
		brush.Dispose();
	}

	private void method_1(Graphics graphics_0)
	{
		Color color = Color.FromArgb(int_1, color_4);
		Color color2 = Color.FromArgb(int_2, color_5);
		Brush brush = new LinearGradientBrush(base.ClientRectangle, color, color2, int_0);
		graphics_0.FillRectangle(brush, 0, 0, base.Width, base.Height);
		for (int i = 0; i < borderWidth; i++)
		{
			graphics_0.DrawLine(new Pen(new SolidBrush(buttonborder_1)), base.Width - i - 1, 0, base.Width - i - 1, base.Height);
			graphics_0.DrawLine(new Pen(new SolidBrush(buttonborder_1)), 0, base.Height - i - 1, base.Width, base.Height - i - 1);
			graphics_0.DrawLine(new Pen(new SolidBrush(buttonborder_2)), i, 0, i, base.Height);
			graphics_0.DrawLine(new Pen(new SolidBrush(buttonborder_2)), 0, i, base.Width, i);
		}
		if (showButtonText)
		{
			Point point = new Point(int_3, int_4);
			SolidBrush brush2 = new SolidBrush(ForeColor);
			graphics_0.DrawString(string_0, Font, brush2, point);
		}
		if (bitmap_0 != null)
		{
			Bitmap source = bitmap_0;
			if (ImToHeight)
			{
				source = source.ResizeImage(base.Height - 2, base.Height - 2);
			}
			graphics_0.DrawImage(source, point_0.X + 1, point_0.Y + 1);
		}
		brush.Dispose();
	}

	private void method_2(Graphics graphics_0)
	{
		Color color = Color.FromArgb(int_1, color_4);
		Color color2 = Color.FromArgb(int_2, color_5);
		Brush brush = new LinearGradientBrush(base.ClientRectangle, color, color2, int_0);
		System.Drawing.Region region = new System.Drawing.Region(new Rectangle(5, 5, base.Width, base.Height));
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddArc(5, 5, 40, 40, 180f, 90f);
		graphicsPath.AddLine(25, 5, base.Width - 25, 5);
		graphicsPath.AddArc(base.Width - 45, 5, 40, 40, 270f, 90f);
		graphicsPath.AddLine(base.Width - 5, 25, base.Width - 5, base.Height - 25);
		graphicsPath.AddArc(base.Width - 45, base.Height - 45, 40, 40, 0f, 90f);
		graphicsPath.AddLine(25, base.Height - 5, base.Width - 25, base.Height - 5);
		graphicsPath.AddArc(5, base.Height - 45, 40, 40, 90f, 90f);
		graphicsPath.AddLine(5, 25, 5, base.Height - 25);
		region.Intersect(graphicsPath);
		graphics_0.FillRegion(brush, region);
		for (int i = 0; i < borderWidth; i++)
		{
			graphics_0.DrawArc(new Pen(buttonborder_1), 5 + i, 5 + i, 40, 40, 180, 90);
			graphics_0.DrawLine(new Pen(buttonborder_1), 25, 5 + i, base.Width - 25, 5 + i);
			graphics_0.DrawArc(new Pen(buttonborder_1), base.Width - 45 - i, 5 + i, 40, 40, 270, 90);
			graphics_0.DrawLine(new Pen(buttonborder_1), 5 + i, 25, 5 + i, base.Height - 25);
			graphics_0.DrawLine(new Pen(buttonborder_2), base.Width - 5 - i, 25, base.Width - 5 - i, base.Height - 25);
			graphics_0.DrawArc(new Pen(buttonborder_2), base.Width - 45 - i, base.Height - 45 - i, 40, 40, 0, 90);
			graphics_0.DrawLine(new Pen(buttonborder_2), 25, base.Height - 5 - i, base.Width - 25, base.Height - 5 - i);
			graphics_0.DrawArc(new Pen(buttonborder_2), 5 + i, base.Height - 45 - i, 40, 40, 90, 90);
		}
		if (showButtonText)
		{
			Point point = new Point(int_3, int_4);
			SolidBrush brush2 = new SolidBrush(ForeColor);
			graphics_0.DrawString(string_0, Font, brush2, point);
		}
		if (bitmap_0 != null)
		{
			Bitmap source = bitmap_0;
			if (ImToHeight)
			{
				source = source.ResizeImage(base.Height - 2, base.Height - 2);
			}
			graphics_0.DrawImage(source, point_0.X + 1, point_0.Y + 1);
		}
		brush.Dispose();
	}

	private void method_3(Color color_8)
	{
		int num = color_8.R - 40;
		int num2 = color_8.G - 40;
		int num3 = color_8.B - 40;
		if (num < 0)
		{
			num = 0;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num3 < 0)
		{
			num3 = 0;
		}
		buttonborder_1 = Color.FromArgb(num, num2, num3);
		buttonborder_2 = color_8;
	}
}
