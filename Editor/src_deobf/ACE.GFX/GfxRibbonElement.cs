using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxRibbonElement : GfxElement
{
	private float float_2 = 0.1f;

	private int int_3;

	private bool bool_14;

	public float Width
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

	public int SegLife
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

	public bool Bind
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

	public GfxRibbonElement()
	{
		base.ElementType = GfxElementType.Ribbon;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		Width = gfxFileReader_0.ReadFloat();
		SegLife = gfxFileReader_0.ReadInt();
		if (version >= 97)
		{
			Bind = gfxFileReader_0.ReadBool();
		}
		if (version >= 100)
		{
			gfxFileReader_0.ReadBool();
		}
		if (version >= 101)
		{
			gfxFileReader_0.ReadFloat();
		}
	}
}
