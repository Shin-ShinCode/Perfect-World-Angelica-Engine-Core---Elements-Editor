using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxRingElement : GfxElement
{
	private float float_2 = 1f;

	private float float_3 = 0.1f;

	private int int_3 = 16;

	private float float_4;

	private bool bool_14;

	public float Radius
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

	public float Height
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

	public int SegmentCount
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

	public float InnerRadius
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

	public bool ScaleOnly
	{
		[CompilerGenerated]
		get
		{
			return bool_14;
		}
		[CompilerGenerated]
		set
		{
			bool_14 = value;
		}
	}

	public GfxRingElement()
	{
		base.ElementType = GfxElementType.Ring;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		Radius = gfxFileReader_0.ReadFloat();
		Height = gfxFileReader_0.ReadFloat();
		SegmentCount = gfxFileReader_0.ReadInt();
		if (version >= 14)
		{
			gfxFileReader_0.ReadFloat();
			if (version >= 15)
			{
				gfxFileReader_0.ReadFloat();
			}
		}
		if (version >= 60)
		{
			gfxFileReader_0.ReadFloat();
		}
		if (version >= 83)
		{
			gfxFileReader_0.ReadBool();
		}
	}
}
