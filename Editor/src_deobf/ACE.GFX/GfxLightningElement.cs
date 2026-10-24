using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxLightningElement : GfxElement
{
	private int int_3 = 6;

	private float float_2 = 0.1f;

	private float float_3 = 0.05f;

	private float float_4 = 0.5f;

	private float float_5 = 1f;

	private float float_6 = 1f;

	public int NumPoints
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

	public float StartWidth
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

	public float EndWidth
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

	public float Amplitude
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

	public float AlphaStart
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

	public float AlphaEnd
	{
		[CompilerGenerated]
		get
		{
			return float_6;
		}
		[CompilerGenerated]
		set
		{
			float_6 = value;
		}
	}

	public GfxLightningElement()
	{
		base.ElementType = GfxElementType.Lightning;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		NumPoints = gfxFileReader_0.ReadInt();
		if (version >= 6)
		{
			StartWidth = gfxFileReader_0.ReadFloat();
			EndWidth = gfxFileReader_0.ReadFloat();
		}
		Amplitude = gfxFileReader_0.ReadFloat();
		if (version >= 7)
		{
			AlphaStart = gfxFileReader_0.ReadFloat();
			AlphaEnd = gfxFileReader_0.ReadFloat();
		}
	}
}
