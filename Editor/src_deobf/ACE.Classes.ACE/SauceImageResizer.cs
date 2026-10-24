using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using PhotoSauce.MagicScaler;

namespace ACE.Classes.ACE;

public class SauceImageResizer
{
	public Bitmap Resize(Bitmap image, int width, int height)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		ProcessImageSettings val = new ProcessImageSettings
		{
			Width = width,
			Height = height,
			EncoderOptions = (IEncoderOptions)(object)default(PngEncoderOptions)
		};
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			image.Save(memoryStream, ImageFormat.Png);
			memoryStream.Position = 0L;
			MemoryStream memoryStream2 = new MemoryStream();
			MagicImageProcessor.ProcessImage((Stream)memoryStream, (Stream)memoryStream2, val);
			memoryStream2.Position = 0L;
			return new Bitmap(memoryStream2);
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}
}
