using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxContainerElement : GfxElement
{
	private string string_6 = string.Empty;

	public string GfxFile
	{
		[CompilerGenerated]
		get
		{
			return string_6;
		}
		[CompilerGenerated]
		set
		{
			string_6 = value;
		}
	}

	public GfxContainerElement()
	{
		base.ElementType = GfxElementType.GfxContainer;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		GfxFile = gfxFileReader_0.ReadString();
	}
}
