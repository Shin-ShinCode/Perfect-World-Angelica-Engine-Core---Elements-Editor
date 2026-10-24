#nullable enable annotations
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Pfim;

namespace ACE.Classes.ACE;

public class IconsService
{
	public class IconReadResult
	{
		private IconsInfo iconsInfo_0;

		private int int_0;

		private Dictionary<string, Bitmap> dictionary_0;

		private Bitmap? bitmap_0;

		public IconsInfo IconsInfo
		{
			[CompilerGenerated]
			get
			{
				return iconsInfo_0;
			}
			[CompilerGenerated]
			set
			{
				iconsInfo_0 = value;
			}
		}

		public int AdaptedIconsPerLine
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

		public Dictionary<string, Bitmap> Icons
		{
			[CompilerGenerated]
			get
			{
				return dictionary_0;
			}
			[CompilerGenerated]
			set
			{
				dictionary_0 = value;
			}
		}

		public Bitmap? ScreenAdapted
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

		public IconReadResult(IconsInfo iconsInfo, int adaptedIconsPerLine, Dictionary<string, Bitmap> icons, Bitmap? screenAdapted)
		{
			IconsInfo = iconsInfo;
			AdaptedIconsPerLine = adaptedIconsPerLine;
			Icons = icons;
			ScreenAdapted = screenAdapted;
		}
	}

	public class IconsInfo
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private List<string> list_0 = new List<string>();

		private Dictionary<string, int> dictionary_0 = new Dictionary<string, int>();

		public int IconWidth
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

		public int IconHeight
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

		public int LinesCount
		{
			[CompilerGenerated]
			get
			{
				return int_2;
			}
			[CompilerGenerated]
			set
			{
				int_2 = value;
			}
		}

		public int IconsPerLine
		{
			[CompilerGenerated]
			get
			{
				return int_3;
			}
			[CompilerGenerated]
			set
			{
				int_3 = value;
			}
		}

		public int IconsCount
		{
			[CompilerGenerated]
			get
			{
				return int_4;
			}
			[CompilerGenerated]
			set
			{
				int_4 = value;
			}
		}

		public List<string> IconsNames
		{
			[CompilerGenerated]
			get
			{
				return list_0;
			}
			[CompilerGenerated]
			set
			{
				list_0 = value;
			}
		}

		public Dictionary<string, int> IconsNamesDict
		{
			[CompilerGenerated]
			get
			{
				return dictionary_0;
			}
			[CompilerGenerated]
			set
			{
				dictionary_0 = value;
			}
		}
	}

	public IconReadResult ReadIconsAndRebuild(Stream iconListDdsStream, Stream iconListTxtStream, int preferredIconsPerLine, AdaptedImageStrategy adaptedImageStrategy, int adaptedImageIconsLimit)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		IconsInfo iconsInfo = LoadIconsInfo(iconListTxtStream);
		Dds val = Dds.Create(iconListDdsStream, new PfimConfig(32768, (TargetFormat)0, true, (IImageAllocator)null, true));
		Dictionary<string, Bitmap> icons;
		try
		{
			icons = ParseIcons(val.Data, val.Width, val.Height, PfimImageReader.GetPixelFormat(val.Format), iconsInfo.IconsNames, iconsInfo.LinesCount, iconsInfo.IconsPerLine, iconsInfo.IconsCount, iconsInfo.IconWidth, iconsInfo.IconHeight, val.Stride);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		if (adaptedImageStrategy != AdaptedImageStrategy.Force && (adaptedImageStrategy != AdaptedImageStrategy.Auto || iconsInfo.IconsCount >= adaptedImageIconsLimit) || iconsInfo.IconsCount == 0)
		{
			return new IconReadResult(iconsInfo, iconsInfo.IconsPerLine, icons, null);
		}
		int num;
		Bitmap screenAdapted;
        try { num = smethod_0(preferredIconsPerLine, iconsInfo); screenAdapted = CreateScreenAdaptedImageUnsafe(icons, iconsInfo.IconsNames, iconsInfo.IconsCount, iconsInfo.IconWidth, iconsInfo.IconHeight, num); }
        catch { foreach (Bitmap icon in icons.Values) icon.Dispose(); throw; }
		return new IconReadResult(iconsInfo, num, icons, screenAdapted);
	}

	private static int smethod_0(int int_0, IconsInfo iconsInfo_0)
	{
		if (int_0 <= 0) throw new ArgumentOutOfRangeException(nameof(int_0));
		int result = int_0;
		if ((long)(iconsInfo_0.IconsCount / int_0 + ((iconsInfo_0.IconsCount % int_0 != 0) ? 1 : 0)) * iconsInfo_0.IconHeight > 65500)
		{
			result = CalculateMinRequiredIconsPerLine(iconsInfo_0.IconsCount, iconsInfo_0.IconWidth, iconsInfo_0.IconHeight);
		}
		return result;
	}

	public IconsInfo LoadIconsInfo(Stream iconListTxtStream)
	{
		StreamReader streamReader = new StreamReader(iconListTxtStream, Encoding.GetEncoding(Class16.smethod_0(1648908265)));
		try
		{
			IconsInfo iconsInfo = new IconsInfo
			{
				IconWidth = Convert.ToInt32(streamReader.ReadLine()),
				IconHeight = Convert.ToInt32(streamReader.ReadLine()),
				LinesCount = Convert.ToInt32(streamReader.ReadLine()),
				IconsPerLine = Convert.ToInt32(streamReader.ReadLine()),
				IconsNames = new List<string>(),
				IconsNamesDict = new Dictionary<string, int>()
			};
			if (iconsInfo.IconWidth <= 0 || iconsInfo.IconHeight <= 0 || iconsInfo.LinesCount < 0 || iconsInfo.IconsPerLine <= 0)
                throw new InvalidDataException("Invalid icon atlas dimensions.");
            iconsInfo.IconsCount = checked(iconsInfo.LinesCount * iconsInfo.IconsPerLine);
			while (true)
			{
				string text = streamReader.ReadLine();
				if (text == null)
				{
					break;
				}
				string text2 = text.ToLowerInvariant();
				iconsInfo.IconsNames.Add(text2);
				if (!iconsInfo.IconsNamesDict.ContainsKey(text2))
				{
					iconsInfo.IconsNamesDict.Add(text2, iconsInfo.IconsNames.Count - 1);
				}
			}
			iconsInfo.IconsCount = iconsInfo.IconsNames.Count;
			return iconsInfo;
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
	}

	public Dictionary<string, Bitmap> ParseIcons(byte[] pixelData, int width, int height, PixelFormat format, List<string> iconsNames, int linesCount, int iconsPerLine, int iconsCount, int iconWidth, int iconHeight, int sourceStride = 0)
    {
        if (pixelData == null || iconsNames == null) throw new ArgumentNullException();
        int bytesPerPixel = Image.GetPixelFormatSize(format) / 8;
        if ((bytesPerPixel != 3 && bytesPerPixel != 4) || width <= 0 || height <= 0 || iconWidth <= 0 || iconHeight <= 0 || iconsPerLine <= 0 || linesCount < 0 || iconsCount < 0 || iconsCount > iconsNames.Count)
            throw new InvalidDataException("Unsupported icon atlas format or dimensions.");
        int stride = sourceStride == 0 ? checked((checked(width * bytesPerPixel) + 3) & ~3) : sourceStride;
        if (stride < (long)width * bytesPerPixel) throw new InvalidDataException("Invalid icon source stride.");
        if ((long)stride * height > pixelData.Length || (long)iconsPerLine * iconWidth > width || (long)linesCount * iconHeight > height || (long)iconsPerLine * linesCount < iconsCount)
            throw new InvalidDataException("Truncated icon atlas or inconsistent metadata.");
        var icons = new Dictionary<string, Bitmap>(iconsCount);
        try
        {
            for (int i = 0; i < iconsCount; i++)
            {
                string key = iconsNames[i];
                Bitmap icon = method_0(pixelData, stride, (i % iconsPerLine) * iconWidth, (i / iconsPerLine) * iconHeight, iconWidth, iconHeight, width, height, bytesPerPixel);
                if (icons.TryGetValue(key, out Bitmap old)) old.Dispose();
                icons[key] = icon;
            }
            return icons;
        }
        catch { foreach (Bitmap icon in icons.Values) icon.Dispose(); throw; }
    }

	private unsafe Bitmap method_0(byte[] data, int stride, int x, int y, int width, int height, int sourceWidth, int sourceHeight, int bytesPerPixel)
    {
        var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        try
        {
            BitmapData bits = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            try
            {
                for (int row = 0; row < height; row++)
                {
                    int offset = checked((y + row) * stride + x * bytesPerPixel);
                    byte* target = (byte*)bits.Scan0 + row * bits.Stride;
                    if (bytesPerPixel == 4) Marshal.Copy(data, offset, (IntPtr)target, checked(width * 4));
                    else
                        for (int col = 0; col < width; col++)
                        {
                            target[col * 4] = data[offset + col * 3];
                            target[col * 4 + 1] = data[offset + col * 3 + 1];
                            target[col * 4 + 2] = data[offset + col * 3 + 2];
                            target[col * 4 + 3] = 255;
                        }
                }
            }
            finally { bitmap.UnlockBits(bits); }
            return bitmap;
        }
        catch { bitmap.Dispose(); throw; }
    }

	public unsafe static Bitmap CreateScreenAdaptedImageUnsafe(IDictionary<string, Bitmap> icons, List<string> iconNames, int iconCount, int iconWidth, int iconHeight, int requiredIconsPerLine)
	{
		if (requiredIconsPerLine <= 0 || iconWidth <= 0 || iconHeight <= 0 || iconCount <= 0 || iconCount > iconNames.Count)
            throw new ArgumentOutOfRangeException(nameof(iconCount));
        int width = checked(requiredIconsPerLine * iconWidth);
		int num = checked((iconCount / requiredIconsPerLine + ((iconCount % requiredIconsPerLine != 0) ? 1 : 0)) * iconHeight);
		if (num > 65500)
		{
			throw new ArgumentException(Class16.smethod_0(1648908286));
		}
		Bitmap bitmap = new Bitmap(width, num, PixelFormat.Format32bppArgb);
		try
        {
        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, num), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        try
        {
		for (int i = 0; i < iconCount; i++)
		{
			if (!icons.TryGetValue(iconNames[i], out Bitmap value))
			{
				if (icons.Count == 0)
				{
					continue;
				}
				value = icons.Values.First();
			}
			BitmapData bitmapData2 = value.LockBits(new Rectangle(0, 0, iconWidth, iconHeight), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            try
            {
			byte* ptr = (byte*)(void*)bitmapData.Scan0;
			byte* ptr2 = (byte*)(void*)bitmapData2.Scan0;
			int num2 = i / requiredIconsPerLine * iconHeight;
			int num3 = i % requiredIconsPerLine * iconWidth;
			for (int j = 0; j < iconHeight; j++)
			{
				for (int k = 0; k < iconWidth; k++)
				{
					int num4 = j * bitmapData2.Stride + k * 4;
					int num5 = (num2 + j) * bitmapData.Stride + (num3 + k) * 4;
					ptr[num5] = ptr2[num4];
					ptr[num5 + 1] = ptr2[num4 + 1];
					ptr[num5 + 2] = ptr2[num4 + 2];
					ptr[num5 + 3] = ptr2[num4 + 3];
				}
			}
			}
            finally { value.UnlockBits(bitmapData2); }
		}
		}
        finally { bitmap.UnlockBits(bitmapData); }
		return bitmap;
        }
        catch { bitmap.Dispose(); throw; }
	}

	public static Bitmap CreateScreenAdaptedImageSlow(IDictionary<string, Bitmap> icons, List<string> iconNames, int iconCount, int iconWidth, int iconHeight, int requiredIconsPerLine)
	{
		int width = requiredIconsPerLine * iconWidth;
		int num = (iconCount / requiredIconsPerLine + ((iconCount % requiredIconsPerLine != 0) ? 1 : 0)) * iconHeight;
		if (num > 65500)
		{
			throw new ArgumentException(Class16.smethod_0(1648908286));
		}
		Bitmap bitmap = new Bitmap(width, num, PixelFormat.Format32bppArgb);
		using Graphics graphics = Graphics.FromImage(bitmap);
		Rectangle srcRect = new Rectangle(0, 0, iconWidth, iconHeight);
		for (int i = 0; i < iconCount; i++)
		{
			int y = i / requiredIconsPerLine * iconHeight;
			int x = i % requiredIconsPerLine * iconWidth;
			if (!icons.TryGetValue(iconNames[i], out Bitmap value))
			{
				if (icons.Count == 0)
				{
					continue;
				}
				value = icons.Values.First();
			}
			graphics.DrawImage(value, x, y, srcRect, GraphicsUnit.Pixel);
		}
		return bitmap;
	}

	public unsafe Bitmap RebuildImage(byte[] pixelData, int width, int height, PixelFormat format, int totalIcons, int iconsPerLine, int iconWidth, int iconHeight)
	{
		int num = (int)Math.Ceiling((double)totalIcons / (double)iconsPerLine);
		int width2 = iconsPerLine * iconWidth;
		int num2 = num * iconHeight;
		Bitmap bitmap = new Bitmap(width2, num2, format);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width2, num2), ImageLockMode.WriteOnly, format);
		int num3 = Image.GetPixelFormatSize(format) / 8;
		int num4 = width * num3;
		for (int i = 0; i < totalIcons; i++)
		{
			int num5 = i / iconsPerLine;
			int num6 = i % iconsPerLine;
			int num7 = i / iconsPerLine;
			int num8 = i % iconsPerLine;
			for (int j = 0; j < iconHeight; j++)
			{
				int num9 = (num5 * iconHeight + j) * num4 + num6 * iconWidth * num3;
				int num10 = (num7 * iconHeight + j) * bitmapData.Stride + num8 * iconWidth * num3;
				if (num9 >= 0 && num9 < pixelData.Length && num10 >= 0 && num10 < bitmapData.Stride * num2)
				{
					Marshal.Copy(pixelData, num9, new IntPtr((byte*)(void*)bitmapData.Scan0 + num10), iconWidth * num3);
					continue;
				}
				throw new ArgumentOutOfRangeException(string.Format(Class16.smethod_0(1648907328), num9, num10));
			}
		}
		bitmap.UnlockBits(bitmapData);
		return bitmap;
	}

	public static int CalculateMinRequiredIconsPerLine(int iconCount, int iconWidth, int iconHeight)
	{
		return (int)Math.Ceiling((double)iconCount / (65500.0 / (double)iconHeight));
	}
}
