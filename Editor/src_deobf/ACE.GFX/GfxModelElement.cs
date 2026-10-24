using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxModelElement : GfxElement
{
	private string string_6 = string.Empty;

	private string string_7 = string.Empty;

	public string ModelFile
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

	public string ActionName
	{
		[CompilerGenerated]
		get
		{
			return string_7;
		}
		[CompilerGenerated]
		set
		{
			string_7 = value;
		}
	}

	public GfxModelElement()
	{
		base.ElementType = GfxElementType.Model;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		ModelFile = gfxFileReader_0.ReadString();
		if (version >= 19)
		{
			ActionName = gfxFileReader_0.ReadString();
		}
	}
}
