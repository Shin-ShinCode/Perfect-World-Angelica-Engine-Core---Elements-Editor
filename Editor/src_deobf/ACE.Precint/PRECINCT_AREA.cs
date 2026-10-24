using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ACE.RSGlobal;

namespace ACE.Precint;

public class PRECINCT_AREA
{
	public int ID;

	public string Name;

	public int instance_id;

	public int pointCount;

	public System.Drawing.Region region;

	public double area;

	public int areaIndex;

	public PRECINCT_AREA(string AreaName, StreamReader sr, int version)
	{
		Name = AreaName;
		string text = sr.ReadLine();
		if (string.IsNullOrWhiteSpace(text))
		{
			GC.KeepAlive(this);
			return;
		}
		char[] separator = new char[1] { ' ' };
		string[] array = text.Replace(Class16.smethod_0(1649043292), Class16.smethod_0(1648942211)).Split(separator);
		if ((nint)array.LongLength < 10)
		{
			GC.KeepAlive(this);
			return;
		}
		int[] array2 = ACE.RSGlobal.RSGlobal.StringArray2IntArray(array);
		ID = array2[0];
		instance_id = array2[8];
		sr.ReadLine();
		ReadRegion(sr, pointCount = array2[1]);
		sr.ReadLine();
		int num = array2[2];
		if (0 < num)
		{
			int num2 = num;
			do
			{
				sr.ReadLine();
				num2--;
			}
			while (num2 != 0);
		}
		sr.ReadLine();
		int num3 = array2[5] + 2;
		if (0 < num3)
		{
			int num4 = num3;
			do
			{
				sr.ReadLine();
				num4--;
			}
			while (num4 != 0);
		}
		GC.KeepAlive(this);
	}

	public PRECINCT_AREA(string Name)
	{
		this.Name = Name;
	}

	public void ReadRegion(StreamReader sr, int count)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[count];
		int num = 0;
		string text = sr.ReadLine();
		if (text != null)
		{
			float float_ = 0f;
			float float_2 = 0f;
			do
			{
				if (text.Length != 0)
				{
					if (text[0] == '"')
					{
						break;
					}
					char[] separator = new char[1] { ' ' };
					string[] array2 = text.Replace(Class16.smethod_0(1649043292), Class16.smethod_0(1648942211)).Split(separator);
					if ((nint)array2.LongLength == 3 && NumberConverter.TryParseUniversalFloat(array2[0], ref float_) && NumberConverter.TryParseUniversalFloat(array2[2], ref float_2))
					{
						PointF pointF = new PointF(float_, float_2);
						array[num] = pointF;
						num++;
						if (num == count)
						{
							break;
						}
					}
				}
				text = sr.ReadLine();
			}
			while (text != null);
		}
		area = ACE.RSGlobal.RSGlobal.CalculatePolygonArea(array);
		graphicsPath.AddPolygon(array);
		region = new System.Drawing.Region(graphicsPath);
	}
}
