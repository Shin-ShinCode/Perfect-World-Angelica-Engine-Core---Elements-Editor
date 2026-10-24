using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxLightElement : GfxElement
{
	private float float_2 = 5f;

	private float float_3 = 1f;

	private float float_4;

	private float float_5;

	public float Range
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	public float Attenuation0
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	public float Attenuation1
	{
		[CompilerGenerated]
		get
		{
			return float_4;
		}
		[CompilerGenerated]
		set
		{
			float_4 = value;
		}
	}

	public float Attenuation2
	{
		[CompilerGenerated]
		get
		{
			return float_5;
		}
		[CompilerGenerated]
		set
		{
			float_5 = value;
		}
	}

	public GfxLightElement()
	{
		base.ElementType = GfxElementType.Light;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		Range = gfxFileReader_0.ReadFloat();
		if (version >= 29)
		{
			Attenuation0 = gfxFileReader_0.ReadFloat();
			Attenuation1 = gfxFileReader_0.ReadFloat();
			Attenuation2 = gfxFileReader_0.ReadFloat();
		}
	}
}
