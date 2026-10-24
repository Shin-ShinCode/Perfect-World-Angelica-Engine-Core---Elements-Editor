namespace ACE.GFX;

public class KPCtrlScaleTrans : KPController
{
	public float[] DestScales = new float[7];

	public float[] TransTimes = new float[6];

	public int DestNum;

	public KPCtrlScaleTrans()
	{
		base.Type = KPCtrlType.ScaleTrans;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		DestScales[0] = gfxFileReader_0.ReadFloat();
		DestNum = gfxFileReader_0.ReadInt();
		for (int i = 0; i < DestNum; i++)
		{
			DestScales[i + 1] = gfxFileReader_0.ReadFloat();
			TransTimes[i] = gfxFileReader_0.ReadFloat();
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
			if (i >= DestNum)
			{
				data.Scale = DestScales[DestNum];
				return;
			}
			float num2 = ((TransTimes[i] > 0f) ? (num / TransTimes[i]) : 1f);
			data.Scale = DestScales[i] * (1f - num2) + DestScales[i + 1] * num2;
		}
	}
}
