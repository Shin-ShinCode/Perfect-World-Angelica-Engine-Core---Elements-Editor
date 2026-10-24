namespace ACE.GFX;

public class KPCtrlRot : KPController
{
	public float AngVel;

	public float AngAcc;

	public KPCtrlRot()
	{
		base.Type = KPCtrlType.Rot;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		AngVel = gfxFileReader_0.ReadFloat();
		AngAcc = gfxFileReader_0.ReadFloat();
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
		if (Tick(data.TimeSpan))
		{
			float num = AngVel + AngAcc * data.TimeSpan;
			float num2 = num + fTimeSpan * AngAcc;
			data.Rad2D += 0.5f * (num + num2) * fTimeSpan;
		}
	}
}
