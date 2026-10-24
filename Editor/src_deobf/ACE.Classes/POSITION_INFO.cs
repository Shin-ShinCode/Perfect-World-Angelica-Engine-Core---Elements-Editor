using System;
using System.Drawing;
using ACE.Precint;

namespace ACE.Classes;

public class POSITION_INFO
{
	public INSTANCE instance;

	public PRECINCT_AREA area;

	public PointF position;

	public float[] vPos;

	public bool bRIP;

	public POSITION_INFO(float[] vPos)
	{
		PointF pointF = new PointF(vPos[0], vPos[2]);
		position = pointF;
		this.vPos = vPos;
	}

	public POSITION_INFO()
	{
	}

	public string DecodeAll()
	{
		string name = instance.Name;
		string text = Class16.smethod_0(1648924347);
		string serverMapTag = instance.ServerMapTag;
		string text2 = Class16.smethod_0(1648908709);
		string text3 = string.Concat(string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648924364) + instance.ID, text2), serverMapTag), text), name);
		text3 += GetDecodedCoords();
		string text4 = Class16.smethod_0(1648942897);
		text3 = string.Concat(text3, string.Concat(Class16.smethod_0(1648899468) + GetAreaName(), text4));
		GC.KeepAlive(this);
		return text3;
	}

	public string GetDecodedCoords()
	{
		float[] array = vPos;
		string result = string.Format(Class16.smethod_0(1648899477), (int)((double)array[0] + 4000.0) / 10, (int)((double)array[2] + 5500.0) / 10, (int)(double)array[1] / 10);
		GC.KeepAlive(this);
		return result;
	}

	public double GetPriority()
	{
		double num = (double)instance.ID * 10000.0;
		PRECINCT_AREA pRECINCT_AREA = area;
		if (pRECINCT_AREA != null)
		{
			num = (double)pRECINCT_AREA.areaIndex + num;
		}
		num = ((double)position.X + 4000.0) / 10.0 / 1000.0 + num;
		num = ((double)position.Y + 5500.0) / 10.0 / 10000.0 + num;
		GC.KeepAlive(this);
		return num;
	}

	public string GetAreaName()
	{
		PRECINCT_AREA pRECINCT_AREA = area;
		if (pRECINCT_AREA != null)
		{
			return pRECINCT_AREA.Name;
		}
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648899490));
		GC.KeepAlive(this);
		return text;
	}
}
