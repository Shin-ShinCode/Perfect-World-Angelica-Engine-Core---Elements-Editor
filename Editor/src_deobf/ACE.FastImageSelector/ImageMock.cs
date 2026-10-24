using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ACE.FastImageSelector;

internal class ImageMock
{
	private static Dictionary<string, Bitmap> dictionary_0 = new Dictionary<string, Bitmap>();

	internal static Bitmap Create(Size size, string text, bool useCache = true)
	{
		if (useCache && dictionary_0.TryGetValue(text, out var value))
		{
			return value;
		}
		Bitmap bitmap = new Bitmap(size.Width, size.Height);
		Rectangle rect = new Rectangle(0, 0, size.Width, size.Height);
		RectangleF layoutRectangle = new RectangleF(0f, 0f, size.Width, size.Height);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			Font font = new Font(Class16.smethod_0(1649072021), 8f);
			try
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.DrawRectangle(Pens.Azure, rect);
				graphics.DrawString(text, font, Brushes.White, layoutRectangle);
				graphics.Flush();
			}
			finally
			{
				((IDisposable)font).Dispose();
			}
		}
		if (useCache)
		{
			dictionary_0.Add(text, bitmap);
		}
		return bitmap;
	}
}
