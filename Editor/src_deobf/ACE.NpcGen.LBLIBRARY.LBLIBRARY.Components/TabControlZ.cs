using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class TabControlZ : TabControl
{
	private Color color_0;

	private Color color_1;

	private Color color_2;

	private Color color_3;

	private Color color_4;

	private Point point_0;

	public override Color BackColor
	{
		get
		{
			return Color.Transparent;
		}
		set
		{
			base.BackColor = Color.Transparent;
		}
	}

	[Category("LBLIBRARY")]
	public Color BorderColor
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

	[Category("LBLIBRARY")]
	public Color SelectedTabBackground
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

	[Category("LBLIBRARY")]
	public Color SelectedTabForeground
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

	[Category("LBLIBRARY")]
	public Color TabDefaultBackground
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

	[Category("LBLIBRARY")]
	public Color TabDefaultForeground
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

	[Category("LBLIBRARY")]
	public Point TextPosition
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

	public TabControlZ()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, value: true);
		base.ResizeRedraw = true;
		DoubleBuffered = true;
		base.DrawMode = TabDrawMode.OwnerDrawFixed;
	}

	protected virtual void DrawTab(Graphics graphics_0, int index, Rectangle rectangle_0, Color co)
	{
		if (index != -1)
		{
			rectangle_0.Inflate(-1, -1);
			TextRenderer.DrawText(graphics_0, base.TabPages[index].Text, Font, rectangle_0, co, TextFormatFlags.Default);
			graphics_0.FillRectangle(new SolidBrush(BorderColor), 0, 23, base.Width, 2);
			graphics_0.FillRectangle(new SolidBrush(BorderColor), 0, base.Height - 4, base.Width, 4);
			graphics_0.FillRectangle(new SolidBrush(BorderColor), 0, 25, 4, base.Height);
			graphics_0.FillRectangle(new SolidBrush(BorderColor), base.Width - 4, 25, 4, base.Height);
		}
	}

	protected virtual void DrawTabRectangle(Graphics graphics_0, int index, Rectangle rectangle_0)
	{
		if (index == 0)
		{
			rectangle_0 = new Rectangle(rectangle_0.Left - 2, rectangle_0.Top, rectangle_0.Width + 2, rectangle_0.Height);
		}
		if (index != base.SelectedIndex)
		{
			rectangle_0 = new Rectangle(rectangle_0.Left, rectangle_0.Top + 2, rectangle_0.Width, rectangle_0.Height - 2);
		}
		Color color = ((index != base.SelectedIndex) ? color_3 : color_1);
		SolidBrush solidBrush = new SolidBrush(color);
		try
		{
			graphics_0.FillRectangle(solidBrush, rectangle_0);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
	}

	protected override void OnPaint(PaintEventArgs paintEventArgs_0)
	{
		if (base.TabCount <= 0)
		{
			return;
		}
		Rectangle clientRectangle = base.ClientRectangle;
		int bottom = GetTabRect(0).Bottom;
		SolidBrush solidBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
		try
		{
			paintEventArgs_0.Graphics.FillRectangle(solidBrush, new Rectangle(clientRectangle.Left, bottom, clientRectangle.Width, clientRectangle.Height - bottom));
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		for (int i = 0; i < base.TabCount; i++)
		{
			clientRectangle = GetTabRect(i);
			DrawTabRectangle(paintEventArgs_0.Graphics, i, clientRectangle);
			if (i == base.SelectedIndex)
			{
				DrawTab(paintEventArgs_0.Graphics, i, clientRectangle, color_2);
				clientRectangle.Inflate(-1, -1);
				ControlPaint.DrawFocusRectangle(paintEventArgs_0.Graphics, clientRectangle);
			}
			else
			{
				DrawTab(paintEventArgs_0.Graphics, i, clientRectangle, color_4);
			}
		}
	}
}
