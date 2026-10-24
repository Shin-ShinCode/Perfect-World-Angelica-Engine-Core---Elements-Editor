using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ACE.Classes;

namespace ACE.IconEditor;

public static class DdsLoader
{
	public static Bitmap Load(string path)
	{
		if (!File.Exists(path))
		{
			return null;
		}
		try
		{
			byte[] ddsImage = File.ReadAllBytes(path);
			DDSImage dDSImage = new DDSImage(ddsImage);
			try
			{
				if (dDSImage.IsValid && dDSImage.BitmapImage != null)
				{
					return new Bitmap(dDSImage.BitmapImage);
				}
				return null;
			}
			finally
			{
				((IDisposable)dDSImage).Dispose();
			}
		}
		catch
		{
			return null;
		}
	}

	public static bool Save(Bitmap image, string path)
	{
		if (image != null && !string.IsNullOrWhiteSpace(path))
		{
			try
			{
				bool bool_;
				Bitmap bitmap = smethod_0(image, out bool_);
				try
				{
					BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
					try
					{
						int stride = bitmapData.Stride;
						int num = Math.Abs(stride) * bitmap.Height;
						byte[] array = new byte[num];
						Marshal.Copy(bitmapData.Scan0, array, 0, num);
						FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
						try
						{
							BinaryWriter binaryWriter = new BinaryWriter(fileStream);
							try
							{
								binaryWriter.Write(542327876);
								binaryWriter.Write(124);
								binaryWriter.Write(4111);
								binaryWriter.Write(bitmap.Height);
								binaryWriter.Write(bitmap.Width);
								binaryWriter.Write(stride);
								binaryWriter.Write(0);
								binaryWriter.Write(0);
								for (int i = 0; i < 11; i++)
								{
									binaryWriter.Write(0);
								}
								binaryWriter.Write(32);
								binaryWriter.Write(65);
								binaryWriter.Write(0);
								binaryWriter.Write(32);
								binaryWriter.Write(16711680);
								binaryWriter.Write(65280);
								binaryWriter.Write(255);
								binaryWriter.Write(-16777216);
								binaryWriter.Write(4096);
								binaryWriter.Write(0);
								binaryWriter.Write(0);
								binaryWriter.Write(0);
								binaryWriter.Write(0);
								binaryWriter.Write(array);
							}
							finally
							{
								((IDisposable)binaryWriter).Dispose();
							}
						}
						finally
						{
							((IDisposable)fileStream).Dispose();
						}
					}
					finally
					{
						bitmap.UnlockBits(bitmapData);
					}
				}
				finally
				{
					if (bool_)
					{
						bitmap.Dispose();
					}
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	private static Bitmap smethod_0(Bitmap bitmap_0, out bool bool_0)
	{
		if (bitmap_0.PixelFormat == PixelFormat.Format32bppArgb)
		{
			bool_0 = false;
			return bitmap_0;
		}
		Bitmap bitmap = new Bitmap(bitmap_0.Width, bitmap_0.Height, PixelFormat.Format32bppArgb);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.CompositingMode = CompositingMode.SourceCopy;
			graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			graphics.PixelOffsetMode = PixelOffsetMode.Half;
			graphics.DrawImage(bitmap_0, 0, 0, bitmap_0.Width, bitmap_0.Height);
		}
		bool_0 = true;
		return bitmap;
	}
}
