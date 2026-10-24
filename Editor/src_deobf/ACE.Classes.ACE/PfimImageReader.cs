#nullable enable annotations
using System;
using System.Buffers;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Pfim;
// TODO(recovered): disambiguation aliases (decompiled file mixes SharpDX + System.Drawing).
using Color = System.Drawing.Color;
using ImageFormat = Pfim.ImageFormat;

namespace ACE.Classes.ACE;

public class PfimImageReader : IImageReader
{
	private sealed class Class54 : IImageAllocator
	{
		private int int_0;

		private static readonly ArrayPool<byte> arrayPool_0 = ArrayPool<byte>.Create(1024 * 1024, 4);

		public int method_0()
		{
			return int_0;
		}

		public byte[] Rent(int int_1)
		{
			byte[] array = arrayPool_0.Rent(int_1);
			Interlocked.Increment(ref int_0);
			Array.Clear(array, 0, array.Length);
			return array;
		}

		public void Return(byte[] byte_0)
		{
			Interlocked.Decrement(ref int_0);
			arrayPool_0.Return(byte_0, false);
		}
	}

	private readonly Class54 class54_0 = new Class54();

	private readonly PfimConfig pfimConfig_0;

	private readonly PfimConfig pfimConfig_1;

	public PfimImageReader()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		pfimConfig_0 = new PfimConfig(32768, (TargetFormat)0, true, (IImageAllocator)(object)class54_0, true);
		pfimConfig_1 = new PfimConfig(32768, (TargetFormat)0, true, (IImageAllocator)(object)class54_0, true);
	}

	public Bitmap ReadDds(Stream stream)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		Dds val = Dds.Create(stream, new PfimConfig(32768, (TargetFormat)0, true, (IImageAllocator)null, true));
		try
		{
			return ConvertToBitmap((IImage)(object)val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public Bitmap ReadTga(Stream stream)
	{
		Targa val = Targa.Create(stream, pfimConfig_1);
		try
		{
			return ConvertToBitmap((IImage)(object)val);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public bool TryReadShopIcon(Stream stream, int checkWidth, out Bitmap? result)
	{
		IImage val = Pfimage.FromStream(stream, pfimConfig_0);
		try
		{
			if (val.Width == checkWidth)
			{
				result = ConvertToBitmap(val);
				return true;
			}
			result = null;
			return false;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	internal static Bitmap ConvertToBitmap(IImage image)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		if (image != null && image.Data != null && image.DataLen > 0)
		{
			if (image.Width > 0 && image.Height > 0 && image.Width <= 8192 && image.Height <= 8192)
			{
				PixelFormat pixelFormat = GetPixelFormat(image.Format);
				Bitmap bitmap = new Bitmap(image.Width, image.Height, pixelFormat);
				BitmapData bitmapData = null;
				try
				{
					bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
                    int rowBytes = checked(image.Width * Image.GetPixelFormatSize(pixelFormat) / 8);
                    int sourceStride = image.Stride;
                    long required = (long)(image.Height - 1) * sourceStride + rowBytes;
                    if (sourceStride < rowBytes || required > image.DataLen || required > image.Data.Length || Math.Abs((long)bitmapData.Stride) < rowBytes)
                        throw new InvalidDataException("Invalid image stride or truncated pixels.");
                    for (int row = 0; row < image.Height; row++)
                        Marshal.Copy(image.Data, checked(row * sourceStride), IntPtr.Add(bitmapData.Scan0, checked(row * bitmapData.Stride)), rowBytes);
				}
				catch
				{
					try
					{
						if (bitmapData != null)
						{
							bitmap.UnlockBits(bitmapData);
						}
					}
					catch
					{
					}
					bitmap.Dispose();
					return new Bitmap(1, 1, PixelFormat.Format32bppArgb);
				}
				if (bitmapData != null)
				{
					bitmap.UnlockBits(bitmapData);
				}
				smethod_0(pixelFormat, bitmap);
				return bitmap;
			}
			return new Bitmap(1, 1, PixelFormat.Format32bppArgb);
		}
		return new Bitmap(1, 1, PixelFormat.Format32bppArgb);
	}

	internal static PixelFormat GetPixelFormat(ImageFormat imageFormat)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected I4, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		return (int)imageFormat switch
		{
			0 => PixelFormat.Format8bppIndexed, 
			1 => PixelFormat.Format16bppRgb555, 
			2 => PixelFormat.Format16bppRgb565, 
			3 => PixelFormat.Format16bppArgb1555, 
			5 => PixelFormat.Format24bppRgb, 
			6 => PixelFormat.Format32bppArgb, 
			_ => throw new InvalidOperationException(string.Format(Class16.smethod_0(1648907453), imageFormat) + Class16.smethod_0(1648907511)), 
		};
	}

	private static void smethod_0(PixelFormat pixelFormat_0, Bitmap bitmap_0)
	{
		if (pixelFormat_0 == PixelFormat.Format8bppIndexed)
		{
			ColorPalette palette = bitmap_0.Palette;
			for (int i = 0; i < 256; i++)
			{
				palette.Entries[i] = Color.FromArgb((byte)i, (byte)i, (byte)i);
			}
			bitmap_0.Palette = palette;
		}
	}
}
