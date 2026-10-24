#nullable enable annotations
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ACE.UIEdit;

internal sealed class PreviewCanvasPanel : Panel
{
	private float float_0 = 1f;

	private PreviewBackgroundMode previewBackgroundMode_0;

	private Image? image_0;

	private Rectangle rectangle_0 = Rectangle.Empty;

	private bool bool_0;

	private Padding padding_0 = new Padding(0);

	private Rectangle rectangle_1 = Rectangle.Empty;

	private bool bool_1 = true;

	public float Zoom
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public PreviewBackgroundMode BackgroundMode
	{
		[CompilerGenerated]
		get
		{
			return previewBackgroundMode_0;
		}
		[CompilerGenerated]
		set
		{
			previewBackgroundMode_0 = value;
		}
	}

	public Image? DialogBackgroundImage
	{
		[CompilerGenerated]
		get
		{
			return image_0;
		}
		[CompilerGenerated]
		set
		{
			image_0 = value;
		}
	}

	public Rectangle DialogBackgroundBounds
	{
		[CompilerGenerated]
		get
		{
			return rectangle_0;
		}
		[CompilerGenerated]
		set
		{
			rectangle_0 = value;
		}
	}

	public bool DialogBackgroundUseNineSlice
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public Padding DialogBackgroundPadding
	{
		[CompilerGenerated]
		get
		{
			return padding_0;
		}
		[CompilerGenerated]
		set
		{
			padding_0 = value;
		}
	}

	public Rectangle SelectionRectangle
	{
		[CompilerGenerated]
		get
		{
			return rectangle_1;
		}
		[CompilerGenerated]
		set
		{
			rectangle_1 = value;
		}
	}

	public bool ShowGrid
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public PreviewCanvasPanel()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		base.ResizeRedraw = true;
		BackColor = Color.White;
	}

	protected override void OnPaintBackground(PaintEventArgs paintEventArgs_0)
	{
		switch (BackgroundMode)
		{
		default:
			smethod_0(paintEventArgs_0.Graphics, Rectangle.Intersect(paintEventArgs_0.ClipRectangle, base.ClientRectangle));
			break;
		case PreviewBackgroundMode.Dark:
		{
			SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(30, 30, 30));
			try
			{
				paintEventArgs_0.Graphics.FillRectangle(solidBrush2, base.ClientRectangle);
				break;
			}
			finally
			{
				((IDisposable)solidBrush2).Dispose();
			}
		}
		case PreviewBackgroundMode.GameScene:
		{
			SolidBrush solidBrush = new SolidBrush(Color.Black);
			try
			{
				paintEventArgs_0.Graphics.FillRectangle(solidBrush, base.ClientRectangle);
				break;
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
		}
		}
	}

	internal void PaintBackgroundRegion(Graphics graphics_0, Rectangle childBoundsInCanvas)
	{
		GraphicsState gstate = graphics_0.Save();
		graphics_0.SetClip(new Rectangle(0, 0, childBoundsInCanvas.Width, childBoundsInCanvas.Height));
		graphics_0.TranslateTransform(-childBoundsInCanvas.X, -childBoundsInCanvas.Y);
		switch (BackgroundMode)
		{
		default:
			smethod_0(graphics_0, childBoundsInCanvas);
			break;
		case PreviewBackgroundMode.Dark:
		{
			SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(30, 30, 30));
			try
			{
				graphics_0.FillRectangle(solidBrush2, base.ClientRectangle);
			}
			finally
			{
				((IDisposable)solidBrush2).Dispose();
			}
			break;
		}
		case PreviewBackgroundMode.GameScene:
		{
			SolidBrush solidBrush = new SolidBrush(Color.Black);
			try
			{
				graphics_0.FillRectangle(solidBrush, base.ClientRectangle);
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
			break;
		}
		}
		graphics_0.Restore(gstate);
	}

	private static TextureBrush textureBrush_0;

	private static TextureBrush smethod_1()
	{
		if (textureBrush_0 == null)
		{
			Bitmap bitmap = new Bitmap(20, 20);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.FromArgb(255, 255, 255));
				using SolidBrush brush = new SolidBrush(Color.FromArgb(204, 204, 204));
				graphics.FillRectangle(brush, 0, 0, 10, 10);
				graphics.FillRectangle(brush, 10, 10, 10, 10);
			}
			textureBrush_0 = new TextureBrush(bitmap) { WrapMode = WrapMode.Tile };
		}
		return textureBrush_0;
	}

	private static void smethod_0(Graphics graphics_0, Rectangle rectangle_2)
	{
		// One tiled fill instead of a FillRectangle per 10px cell: the old loop ran over the entire
		// (layout-sized) canvas ClientRectangle and issued millions of GDI calls, freezing the UI thread.
		// The brush tiles in world space so the checkerboard stays grid-aligned across canvas and children.
		graphics_0.FillRectangle(smethod_1(), rectangle_2);
	}


	protected override void OnPaint(PaintEventArgs paintEventArgs_0)
	{
		base.OnPaint(paintEventArgs_0);
		try
		{
			if (ShowGrid)
			{
				int num = Math.Max(8, (int)Math.Round(16f * Math.Max(0.25f, Zoom), MidpointRounding.AwayFromZero));
				Pen pen = new Pen(Color.FromArgb(22, 60, 60, 60), 1f);
				try
				{
					Rectangle clip = paintEventArgs_0.ClipRectangle;
					int x0 = clip.Left - (((clip.Left % num) + num) % num);
					for (int i = x0; i < clip.Right; i += num)
					{
						paintEventArgs_0.Graphics.DrawLine(pen, i, clip.Top, i, clip.Bottom);
					}
					int y0 = clip.Top - (((clip.Top % num) + num) % num);
					for (int j = y0; j < clip.Bottom; j += num)
					{
						paintEventArgs_0.Graphics.DrawLine(pen, clip.Left, j, clip.Right, j);
					}
				}
				finally
				{
					((IDisposable)pen).Dispose();
				}
			}
			if (DialogBackgroundBounds.Width > 0 && DialogBackgroundBounds.Height > 0)
			{
				if (DialogBackgroundImage != null)
				{
					paintEventArgs_0.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					paintEventArgs_0.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
					if (DialogBackgroundUseNineSlice)
					{
						DrawNineSliceImage(paintEventArgs_0.Graphics, DialogBackgroundImage, DialogBackgroundBounds, DialogBackgroundPadding);
					}
					else
					{
						paintEventArgs_0.Graphics.DrawImage(DialogBackgroundImage, DialogBackgroundBounds);
					}
				}
				using Pen pen2 = new Pen(Color.FromArgb(100, 188, 154, 88), 1f)
				{
					DashStyle = DashStyle.Dash
				};
				paintEventArgs_0.Graphics.DrawRectangle(pen2, DialogBackgroundBounds.X, DialogBackgroundBounds.Y, Math.Max(0, DialogBackgroundBounds.Width - 1), Math.Max(0, DialogBackgroundBounds.Height - 1));
			}
			if (SelectionRectangle.Width > 0 || SelectionRectangle.Height > 0)
			{
				Rectangle selectionRectangle = SelectionRectangle;
				if (selectionRectangle.X > -100000 && selectionRectangle.Y > -100000 && selectionRectangle.Width < 100000 && selectionRectangle.Height < 100000)
				{
					SolidBrush solidBrush = new SolidBrush(Color.FromArgb(40, 96, 160, 255));
					try
					{
						using Pen pen3 = new Pen(Color.FromArgb(180, 96, 160, 255), 1f)
						{
							DashStyle = DashStyle.Dash
						};
						paintEventArgs_0.Graphics.FillRectangle(solidBrush, selectionRectangle);
						paintEventArgs_0.Graphics.DrawRectangle(pen3, selectionRectangle);
					}
					finally
					{
						((IDisposable)solidBrush).Dispose();
					}
				}
			}
			int num2 = Math.Max(0, Math.Min(base.Width - 1, 100000));
			int num3 = Math.Max(0, Math.Min(base.Height - 1, 100000));
			Pen pen4 = new Pen(Color.FromArgb(64, 88, 88, 88), 1f);
			try
			{
				paintEventArgs_0.Graphics.DrawRectangle(pen4, 0, 0, num2, num3);
			}
			finally
			{
				((IDisposable)pen4).Dispose();
			}
		}
		catch
		{
		}
	}

	internal static void DrawNineSliceImage(Graphics graphics_0, Image image, Rectangle target, Padding sourcePadding)
	{
		if (target.Width >= 2 && target.Height >= 2)
		{
			int num = image.Width;
			int num2 = image.Height;
			int num3 = Math.Max(1, Math.Min(sourcePadding.Left, num / 2));
			int num4 = Math.Max(1, Math.Min(sourcePadding.Right, num - num3));
			int num5 = Math.Max(1, Math.Min(sourcePadding.Top, num2 / 2));
			int num6 = Math.Max(1, Math.Min(sourcePadding.Bottom, num2 - num5));
			int num7 = Math.Max(1, Math.Min(num3, target.Width / 2));
			int num8 = Math.Max(1, Math.Min(num4, target.Width - num7));
			int num9 = Math.Max(1, Math.Min(num5, target.Height / 2));
			int num10 = Math.Max(1, Math.Min(num6, target.Height - num9));
			Rectangle srcRect = new Rectangle(0, 0, num3, num5);
			Rectangle srcRect2 = new Rectangle(num3, 0, Math.Max(1, num - num3 - num4), num5);
			Rectangle srcRect3 = new Rectangle(num - num4, 0, num4, num5);
			Rectangle srcRect4 = new Rectangle(0, num5, num3, Math.Max(1, num2 - num5 - num6));
			Rectangle srcRect5 = new Rectangle(num3, num5, Math.Max(1, num - num3 - num4), Math.Max(1, num2 - num5 - num6));
			Rectangle srcRect6 = new Rectangle(num - num4, num5, num4, Math.Max(1, num2 - num5 - num6));
			Rectangle srcRect7 = new Rectangle(0, num2 - num6, num3, num6);
			Rectangle srcRect8 = new Rectangle(num3, num2 - num6, Math.Max(1, num - num3 - num4), num6);
			Rectangle srcRect9 = new Rectangle(num - num4, num2 - num6, num4, num6);
			Rectangle destRect = new Rectangle(target.Left, target.Top, num7, num9);
			Rectangle destRect2 = new Rectangle(target.Left + num7, target.Top, Math.Max(1, target.Width - num7 - num8), num9);
			Rectangle destRect3 = new Rectangle(target.Right - num8, target.Top, num8, num9);
			Rectangle destRect4 = new Rectangle(target.Left, target.Top + num9, num7, Math.Max(1, target.Height - num9 - num10));
			Rectangle destRect5 = new Rectangle(target.Left + num7, target.Top + num9, Math.Max(1, target.Width - num7 - num8), Math.Max(1, target.Height - num9 - num10));
			Rectangle destRect6 = new Rectangle(target.Right - num8, target.Top + num9, num8, Math.Max(1, target.Height - num9 - num10));
			Rectangle destRect7 = new Rectangle(target.Left, target.Bottom - num10, num7, num10);
			Rectangle destRect8 = new Rectangle(target.Left + num7, target.Bottom - num10, Math.Max(1, target.Width - num7 - num8), num10);
			Rectangle destRect9 = new Rectangle(target.Right - num8, target.Bottom - num10, num8, num10);
			graphics_0.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
			graphics_0.DrawImage(image, destRect2, srcRect2, GraphicsUnit.Pixel);
			graphics_0.DrawImage(image, destRect3, srcRect3, GraphicsUnit.Pixel);
			graphics_0.DrawImage(image, destRect4, srcRect4, GraphicsUnit.Pixel);
			graphics_0.DrawImage(image, destRect5, srcRect5, GraphicsUnit.Pixel);
			graphics_0.DrawImage(image, destRect6, srcRect6, GraphicsUnit.Pixel);
			graphics_0.DrawImage(image, destRect7, srcRect7, GraphicsUnit.Pixel);
			graphics_0.DrawImage(image, destRect8, srcRect8, GraphicsUnit.Pixel);
			graphics_0.DrawImage(image, destRect9, srcRect9, GraphicsUnit.Pixel);
		}
	}
}
