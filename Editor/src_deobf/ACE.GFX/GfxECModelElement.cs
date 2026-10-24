using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxECModelElement : GfxElement
{
	private string string_6 = string.Empty;

	private int int_3;

	public string ECModelFile
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

	public int LoaderType
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public GfxECModelElement()
	{
		base.ElementType = GfxElementType.ECModel;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		LoaderType = gfxFileReader_0.ReadInt();
		ECModelFile = gfxFileReader_0.ReadString();
	}
}
