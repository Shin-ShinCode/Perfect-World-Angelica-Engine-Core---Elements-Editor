using System;

namespace ACE.GFX;

public class KPCtrlColorChange : KPController
{
	public int[] ColorDelta = new int[4];

	private float[] float_2 = new float[4];

	public KPCtrlColorChange()
	{
		base.Type = KPCtrlType.Color;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		var (num, num2, num3, num4) = gfxFileReader_0.ReadInt4();
		ColorDelta[0] = num;
		ColorDelta[1] = num2;
		ColorDelta[2] = num3;
		ColorDelta[3] = num4;
	}

	public override void Resume()
	{
		float_2 = new float[4];
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
		if (Tick(data.TimeSpan))
		{
			GfxColor gfxColor = new GfxColor(data.Color);
			byte[] array = new byte[4] { gfxColor.Byte_0, gfxColor.Byte_1, gfxColor.Byte_2, gfxColor.Byte_3 };
			for (int i = 0; i < 4; i++)
			{
				float num = (float)ColorDelta[i] * fTimeSpan + float_2[i];
				int num2 = (int)num;
				float_2[i] = num - (float)num2;
				int val = array[i] + num2;
				array[i] = (byte)Math.Min(Math.Max(val, 0), 255);
			}
			data.Color = new GfxColor(array[0], array[1], array[2], array[3]).Value;
		}
	}
}
