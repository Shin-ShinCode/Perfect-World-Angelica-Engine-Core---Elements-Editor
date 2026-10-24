namespace ACE.GFX;

public class KPCtrlColorNoise : KPController
{
	public int BufLen;

	public float Amplitude;

	public int WaveLen;

	public float Persistence;

	public int OctaveNum;

	public uint BaseColor;

	public KPCtrlColorNoise()
	{
		base.Type = KPCtrlType.ColorNoise;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		BufLen = gfxFileReader_0.ReadInt();
		Amplitude = gfxFileReader_0.ReadFloat();
		WaveLen = gfxFileReader_0.ReadInt();
		Persistence = gfxFileReader_0.ReadFloat();
		OctaveNum = gfxFileReader_0.ReadInt();
		BaseColor = gfxFileReader_0.ReadColor();
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
		if (Tick(data.TimeSpan))
		{
			data.Color = BaseColor;
		}
	}
}
