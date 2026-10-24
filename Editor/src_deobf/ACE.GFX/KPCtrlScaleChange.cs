using System;

namespace ACE.GFX;

public class KPCtrlScaleChange : KPController
{
	public float ScaleDelta;

	public float MinScale;

	public float MaxScale;

	public KPCtrlScaleChange()
	{
		base.Type = KPCtrlType.Scale;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		(float x, float y, float z) tuple = gfxFileReader_0.ReadVector3();
		float item = tuple.x;
		float item2 = tuple.y;
		float item3 = tuple.z;
		ScaleDelta = item;
		MinScale = item2;
		MaxScale = item3;
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
		if (Tick(data.TimeSpan))
		{
			data.Scale += ScaleDelta * fTimeSpan;
			data.Scale = Math.Min(Math.Max(data.Scale, MinScale), MaxScale);
		}
	}
}
