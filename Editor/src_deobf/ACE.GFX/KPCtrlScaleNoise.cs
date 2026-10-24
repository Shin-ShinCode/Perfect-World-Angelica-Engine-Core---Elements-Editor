namespace ACE.GFX;

public class KPCtrlScaleNoise : KPController
{
	public int BufLen;

	public float Amplitude;

	public int WaveLen;

	public float Persistence;

	public int OctaveNum;

	public KPCtrlScaleNoise()
	{
		base.Type = KPCtrlType.ScaleNoise;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		BufLen = gfxFileReader_0.ReadInt();
		Amplitude = gfxFileReader_0.ReadFloat();
		WaveLen = gfxFileReader_0.ReadInt();
		Persistence = gfxFileReader_0.ReadFloat();
		OctaveNum = gfxFileReader_0.ReadInt();
		if (version < 13)
		{
			gfxFileReader_0.ReadLine();
		}
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
		if (Tick(data.TimeSpan))
		{
			data.ScaleNoise = 0f;
		}
	}
}
