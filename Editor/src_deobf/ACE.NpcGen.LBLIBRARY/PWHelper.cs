using System;
using System.Drawing;
using ACE.Classes;

namespace ACE.NpcGen.LBLIBRARY;

public static class PWHelper
{
	public static Bitmap LoadDDSImage(byte[] byteArray)
	{
		if (byteArray != null && byteArray.Length != 0)
		{
			try
			{
				DDSImage dDSImage = new DDSImage(byteArray);
				try
				{
					if (dDSImage.IsValid && dDSImage.BitmapImage != null)
					{
						return new Bitmap(dDSImage.BitmapImage);
					}
				}
				finally
				{
					((IDisposable)dDSImage).Dispose();
				}
			}
			catch
			{
			}
			return null;
		}
		return null;
	}
}
