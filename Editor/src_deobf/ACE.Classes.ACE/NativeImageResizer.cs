using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ACE.Classes.ACE;

public class NativeImageResizer : IImageResizer
{
	private static readonly object object_0 = new object();

	private readonly Bitmap bitmap_0;

	public NativeImageResizer(Bitmap image)
	{
		bitmap_0 = image;
	}

	public Bitmap Resize(int width, int height)
	{
		Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
		try
		{
			lock (object_0)
			{
				using Graphics graphics = Graphics.FromImage(bitmap);
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.DrawImage(bitmap_0, 0, 0, width, height);
			}
			return bitmap;
		}
		catch (InvalidOperationException)
		{
			bitmap.Dispose();
			return new Bitmap(width, height, PixelFormat.Format32bppArgb);
		}
		catch (ArgumentException)
		{
			bitmap.Dispose();
			return new Bitmap(width, height, PixelFormat.Format32bppArgb);
		}
	}
}
