namespace ACE.GFX;

public class GfxLtnTrailElement : GfxElement
{
	public GfxLtnTrailElement()
	{
		base.ElementType = GfxElementType.LtnTrail;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		gfxFileReader_0.ReadFloat();
		gfxFileReader_0.ReadInt();
		gfxFileReader_0.ReadFloat();
		gfxFileReader_0.ReadInt();
	}
}
