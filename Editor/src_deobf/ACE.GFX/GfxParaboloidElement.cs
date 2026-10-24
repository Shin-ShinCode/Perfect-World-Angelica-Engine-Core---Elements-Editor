namespace ACE.GFX;

public class GfxParaboloidElement : GfxElement
{
	public GfxParaboloidElement()
	{
		base.ElementType = GfxElementType.Paraboloid;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		gfxFileReader_0.ReadFloat();
		gfxFileReader_0.ReadFloat();
		gfxFileReader_0.ReadInt();
	}
}
