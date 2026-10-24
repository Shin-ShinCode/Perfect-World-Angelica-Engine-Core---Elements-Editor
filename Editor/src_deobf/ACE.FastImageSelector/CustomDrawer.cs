using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ACE.FastImageSelector;

public static class CustomDrawer
{
	public static Image CreateRectangle(Size size, Color color)
	{
		Bitmap bitmap = new Bitmap(size.Width, size.Height);
		Rectangle rect = new Rectangle(0, 0, size.Width, size.Height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		SolidBrush solidBrush = new SolidBrush(color);
		try
		{
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.FillRectangle(solidBrush, rect);
			graphics.Flush();
			return bitmap;
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
	}

	public static Image CreateStrokedRectangle(Size size, Color color, int width = 2)
	{
		Bitmap bitmap = new Bitmap(size.Width, size.Height);
		Rectangle rect = new Rectangle(0, 0, size.Width, size.Height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		SolidBrush solidBrush = new SolidBrush(Color.Transparent);
		try
		{
			Pen pen = new Pen(color, width);
			try
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.FillRectangle(solidBrush, rect);
				graphics.DrawRectangle(pen, rect);
				graphics.Flush();
				return bitmap;
			}
			finally
			{
				((IDisposable)pen).Dispose();
			}
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
	}

	public static Image DrawCheck(Size size, Image image)
	{
		Bitmap bitmap = new Bitmap(image);
		float emSize = (float)size.Height / 2f;
		using Graphics graphics = Graphics.FromImage(bitmap);
		Font font = new Font(Class16.smethod_0(1648942905), emSize);
		try
		{
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.DrawString(Class16.smethod_0(1649071806), layoutRectangle: new RectangleF(0f, 0f, size.Width, size.Height), font: font, brush: Brushes.Black);
			graphics.DrawString(Class16.smethod_0(1649071806), layoutRectangle: new RectangleF((float)size.Width / 3f, 0f, size.Width, size.Height), font: font, brush: Brushes.White);
			graphics.Flush();
			return bitmap;
		}
		finally
		{
			((IDisposable)font).Dispose();
		}
	}
}
