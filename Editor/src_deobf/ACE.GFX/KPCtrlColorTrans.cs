using System;

namespace ACE.GFX;

public class KPCtrlColorTrans : KPController
{
	public uint OrgColor;

	public int DestNum;

	public uint[] DestColors = new uint[10];

	public float[] TransTimes = new float[10];

	public bool AlphaOnly;

	public KPCtrlColorTrans()
	{
		base.Type = KPCtrlType.ColorTrans;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		OrgColor = gfxFileReader_0.ReadColor();
		if (version < 11)
		{
			DestNum = 1;
			DestColors[0] = gfxFileReader_0.ReadColor();
			int num = gfxFileReader_0.ReadInt();
			TransTimes[0] = (float)num * 1000f;
			return;
		}
		DestNum = gfxFileReader_0.ReadInt();
		for (int i = 0; i < DestNum; i++)
		{
			uint num2 = gfxFileReader_0.ReadColor();
			float num4;
			if (version < 12)
			{
				int num3 = gfxFileReader_0.ReadInt();
				num4 = num3;
			}
			else
			{
				num4 = gfxFileReader_0.ReadFloat();
			}
			if (i < 10)
			{
				DestColors[i] = num2;
				TransTimes[i] = num4;
			}
		}
		if (version >= 81)
		{
			AlphaOnly = gfxFileReader_0.ReadBool();
		}
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
		if (Tick(data.TimeSpan) && DestNum > 0)
		{
			int i = 0;
			float num;
			for (num = data.TimeSpan * 1000f; i < DestNum && !(num < TransTimes[i]); i++)
			{
				num -= TransTimes[i];
			}
			float val;
			if (i >= DestNum)
			{
				i = DestNum - 1;
				val = 1f;
			}
			else
			{
				val = ((TransTimes[i] > 0f) ? (num / TransTimes[i]) : 1f);
			}
			val = Math.Min(Math.Max(val, 0f), 1f);
			uint value = ((i == 0) ? OrgColor : DestColors[i - 1]);
			uint value2 = DestColors[i];
			GfxColor gfxColor = GfxColor.Lerp(new GfxColor(value), new GfxColor(value2), val);
			if (AlphaOnly)
			{
				GfxColor gfxColor2 = new GfxColor(data.Color);
				data.Color = new GfxColor(gfxColor2.Byte_0, gfxColor2.Byte_1, gfxColor2.Byte_2, gfxColor.Byte_3).Value;
			}
			else
			{
				data.Color = gfxColor.Value;
			}
		}
	}
}
