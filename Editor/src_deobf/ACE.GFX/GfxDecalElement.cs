using System;
using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxDecalElement : GfxElement
{
	private float float_2 = 0.5f;

	private float float_3 = 0.5f;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private float float_4 = 0.5f;

	private float float_5 = 0.5f;

	private float float_6;

	private bool bool_18;

	private bool bool_19;

	private float float_7;

	private bool bool_20;

	private bool bool_21;

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

	public bool RotFromView
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

	public bool GrndNormOnly
	{
		[CompilerGenerated]
		get
		{
			return bool_15;
		}
		[CompilerGenerated]
		set
		{
			bool_15 = value;
		}
	}

	public bool NoWidthScale
	{
		[CompilerGenerated]
		get
		{
			return bool_16;
		}
		[CompilerGenerated]
		set
		{
			bool_16 = value;
		}
	}

	public bool NoHeightScale
	{
		[CompilerGenerated]
		get
		{
			return bool_17;
		}
		[CompilerGenerated]
		set
		{
			bool_17 = value;
		}
	}

	public float OrgPtWidth
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

	public float OrgPtHeight
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

	public float ZOffset
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

	public bool MatchSurface
	{
		[CompilerGenerated]
		get
		{
			return bool_18;
		}
		[CompilerGenerated]
		set
		{
			bool_18 = value;
		}
	}

	public bool SurfaceUseParentDir
	{
		[CompilerGenerated]
		get
		{
			return bool_19;
		}
		[CompilerGenerated]
		set
		{
			bool_19 = value;
		}
	}

	public float MaxExtent
	{
		[CompilerGenerated]
		get
		{
			return float_7;
		}
		[CompilerGenerated]
		set
		{
			float_7 = value;
		}
	}

	public bool YawEffectOnGrndNorm
	{
		[CompilerGenerated]
		get
		{
			return bool_20;
		}
		[CompilerGenerated]
		set
		{
			bool_20 = value;
		}
	}

	public bool ScreenSpace
	{
		[CompilerGenerated]
		get
		{
			return bool_21;
		}
		[CompilerGenerated]
		set
		{
			bool_21 = value;
		}
	}

	public GfxDecalElement(GfxElementType type)
	{
		base.ElementType = type;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		Width = gfxFileReader_0.ReadFloat();
		Height = gfxFileReader_0.ReadFloat();
		if (version < 9)
		{
			gfxFileReader_0.ReadInt();
			gfxFileReader_0.ReadInt();
			int num = gfxFileReader_0.ReadInt();
			base.TexInterval = (uint)(num * 50);
		}
		RotFromView = gfxFileReader_0.ReadBool();
		if (version >= 26)
		{
			GrndNormOnly = gfxFileReader_0.ReadBool();
		}
		if (version >= 36)
		{
			NoWidthScale = gfxFileReader_0.ReadBool();
			NoHeightScale = gfxFileReader_0.ReadBool();
			OrgPtWidth = gfxFileReader_0.ReadFloat();
			OrgPtHeight = gfxFileReader_0.ReadFloat();
		}
		if (version >= 42)
		{
			ZOffset = gfxFileReader_0.ReadFloat();
		}
		if (version >= 54)
		{
			MatchSurface = gfxFileReader_0.ReadBool();
		}
		if (version >= 86)
		{
			SurfaceUseParentDir = gfxFileReader_0.ReadBool();
		}
		if (version >= 55)
		{
			MaxExtent = gfxFileReader_0.ReadFloat();
		}
		if (version >= 61)
		{
			YawEffectOnGrndNorm = gfxFileReader_0.ReadBool();
		}
		if (version >= 115)
		{
			ScreenSpace = gfxFileReader_0.ReadBool();
		}
		if (MaxExtent == 0f)
		{
			MaxExtent = Math.Max(Width, Height) * 1.5f;
		}
	}
}
