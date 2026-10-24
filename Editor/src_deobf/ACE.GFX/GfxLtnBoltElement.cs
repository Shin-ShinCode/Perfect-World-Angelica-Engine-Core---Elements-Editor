namespace ACE.GFX;

public class GfxLtnBoltElement : GfxElement
{
	public GfxLtnBoltElement()
	{
		base.ElementType = GfxElementType.LtnBolt;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		gfxFileReader_0.ReadInt();
		gfxFileReader_0.ReadFloat();
		gfxFileReader_0.ReadFloat();
		gfxFileReader_0.ReadFloat();
		if (version >= 52)
		{
			gfxFileReader_0.ReadInt();
			gfxFileReader_0.ReadFloat();
		}
	}
}
