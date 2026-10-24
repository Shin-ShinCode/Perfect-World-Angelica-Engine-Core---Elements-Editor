using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using ACE.Classes;
using ACE.Pck;
using ACE.Pck.Package;
using ACE.sTASKedit.Classes.GlobalProgramData;

namespace ACE.sTASKedit.Classes;

public class IconList
{
	public Size IconSize;

	private int int_0;

	private int int_1;

	public Dictionary<string, Image> Icons;

	[CLSCompliant(false)]
	public IconList(ACE.Pck.Package.FileInfo[] FileTable, string SurfacesParh, string IconListName)
	{
		method_0(FileTable, SurfacesParh, IconListName);
	}

	private void method_0(ACE.Pck.Package.FileInfo[] fileInfo_0, string string_0, string string_1)
	{
		StreamReader streamReader = new StreamReader(Functions.GetFile(fileInfo_0, string_0, Class16.smethod_0(1649188915), string_1 + Class16.smethod_0(1648997294)), Encoding.GetEncoding(Class16.smethod_0(1648985403)));
		List<string> list = new List<string>();
		while (!streamReader.EndOfStream)
		{
			string text = streamReader.ReadLine();
			if (text != string.Empty && !text.StartsWith(Class16.smethod_0(1648892117)) && !text.StartsWith(Class16.smethod_0(1648929947)))
			{
				list.Add(text.ToLower());
			}
		}
		IconSize = new Size(Convert.ToInt32(list[0]), Convert.ToInt32(list[1]));
		int_0 = Convert.ToInt32(list[2]);
		int_1 = Convert.ToInt32(list[3]);
		list.RemoveRange(0, 4);
		streamReader.Close();
		MemoryStream file = Functions.GetFile(fileInfo_0, string_0, Class16.smethod_0(1649188915), string_1 + Class16.smethod_0(1648904847));
		BinaryReader binaryReader = new BinaryReader(file);
		byte[] array = new byte[file.Length];
		array = binaryReader.ReadBytes(array.Length);
		DDSImage dDSImage = new DDSImage(array);
		Bitmap bitmapImage = dDSImage.BitmapImage;
		array = null;
		file.Close();
		binaryReader.Close();
		int num = 0;
		Icons = new Dictionary<string, Image>();
		for (int i = 0; i <= int_0; i++)
		{
			if (num >= list.Count)
			{
				break;
			}
			for (int j = 0; j < int_1; j++)
			{
				if (num >= list.Count)
				{
					break;
				}
				Image image = bitmapImage.Clone(new Rectangle(IconSize.Width * j, IconSize.Height * i, IconSize.Width, IconSize.Height), bitmapImage.PixelFormat);
				Image image2 = new Bitmap(GProD.ElementIconWidth, GProD.ElementIconHeight);
				using (Graphics graphics = Graphics.FromImage(image2))
				{
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					graphics.DrawImage(image, 0, 0, GProD.ElementIconWidth, GProD.ElementIconHeight);
					graphics.Dispose();
				}
				Icons.Add(list[num], image2);
				num++;
			}
		}
	}
}
