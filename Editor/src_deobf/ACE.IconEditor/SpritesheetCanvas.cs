using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ACE.IconEditor;

public sealed class SpritesheetCanvas : Control
{
	private static readonly Brush brush_0 = new SolidBrush(Color.FromArgb(56, 56, 56));

	private static readonly Brush brush_1 = new SolidBrush(Color.FromArgb(72, 72, 72));

	private static readonly Pen pen_0 = new Pen(Color.FromArgb(0, 120, 212), 2f);

	private static readonly Brush brush_2 = new SolidBrush(Color.FromArgb(56, 0, 120, 212));

	private readonly HashSet<int> hashSet_0 = new HashSet<int>();

	private Bitmap bitmap_0;

	private int int_0 = 32;

	private int int_1;

	private EventHandler<int> eventHandler_0;

	public Bitmap SheetImage
	{
		[CompilerGenerated]
		get
		{
			return bitmap_0;
		}
		[CompilerGenerated]
		set
		{
			bitmap_0 = value;
		}
	}

	public int IconSize
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

	public int TotalFrames
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public event EventHandler<int> FrameClicked
	{
		[CompilerGenerated]
		add
		{
			EventHandler<int> eventHandler = eventHandler_0;
			EventHandler<int> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<int> value2 = (EventHandler<int>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<int> eventHandler = eventHandler_0;
			EventHandler<int> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<int> value2 = (EventHandler<int>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public SpritesheetCanvas()
	{
		DoubleBuffered = true;
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		BackColor = Color.FromArgb(26, 26, 26);
		Cursor = Cursors.Hand;
	}

	public void SetHighlightedFrames(IEnumerable<int> frames)
	{
		hashSet_0.Clear();
		if (frames != null)
		{
			foreach (int frame in frames)
			{
				hashSet_0.Add(frame);
			}
		}
		Invalidate();
	}

	protected override void OnPaint(PaintEventArgs paintEventArgs_0)
	{
		base.OnPaint(paintEventArgs_0);
		Graphics graphics = paintEventArgs_0.Graphics;
		graphics.Clear(BackColor);
		if (SheetImage == null)
		{
			return;
		}
		smethod_0(graphics, SheetImage.Width, SheetImage.Height);
		graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		graphics.PixelOffsetMode = PixelOffsetMode.Half;
		graphics.DrawImage(SheetImage, 0, 0, SheetImage.Width, SheetImage.Height);
		if (IconSize <= 0 || TotalFrames <= 0)
		{
			return;
		}
		int num = Math.Max(1, SheetImage.Width / IconSize);
		foreach (int item in hashSet_0)
		{
			if (item >= 0 && item < TotalFrames)
			{
				int num2 = item / num;
				int num3 = item % num;
				int num4 = num3 * IconSize;
				int num5 = num2 * IconSize;
				Rectangle rect = new Rectangle(num4, num5, IconSize, IconSize);
				graphics.FillRectangle(brush_2, rect);
				graphics.DrawRectangle(pen_0, rect);
			}
		}
	}

	protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
	{
		base.OnMouseDown(mouseEventArgs_0);
		if (mouseEventArgs_0.Button == MouseButtons.Left && SheetImage != null && IconSize > 0 && TotalFrames > 0 && mouseEventArgs_0.X >= 0 && mouseEventArgs_0.Y >= 0 && mouseEventArgs_0.X < SheetImage.Width && mouseEventArgs_0.Y < SheetImage.Height)
		{
			int num = Math.Max(1, SheetImage.Width / IconSize);
			int num2 = mouseEventArgs_0.X / IconSize;
			int num3 = mouseEventArgs_0.Y / IconSize;
			int num4 = num3 * num + num2;
			if (num4 >= 0 && num4 < TotalFrames)
			{
				eventHandler_0?.Invoke(this, num4);
			}
		}
	}

	private static void smethod_0(Graphics graphics_0, int int_2, int int_3)
	{
		for (int i = 0; i < int_3; i += 8)
		{
			for (int j = 0; j < int_2; j += 8)
			{
				bool flag = ((j / 8 + i / 8) & 1) == 0;
				graphics_0.FillRectangle(flag ? brush_0 : brush_1, j, i, 8, 8);
			}
		}
	}
}
