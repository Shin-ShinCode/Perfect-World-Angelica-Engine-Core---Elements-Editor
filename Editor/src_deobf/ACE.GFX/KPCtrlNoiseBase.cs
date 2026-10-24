namespace ACE.GFX;

public class KPCtrlNoiseBase : KPController
{
	public int BufLen;

	public float Amplitude;

	public int WaveLen;

	public float Persistence;

	public int OctaveNum;

	public KPCtrlNoiseBase()
	{
		base.Type = KPCtrlType.NoiseBase;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		BufLen = gfxFileReader_0.ReadInt();
		Amplitude = gfxFileReader_0.ReadFloat();
		WaveLen = gfxFileReader_0.ReadInt();
		Persistence = gfxFileReader_0.ReadFloat();
		OctaveNum = gfxFileReader_0.ReadInt();
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
	}
}
