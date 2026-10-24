using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxParticleElement : GfxElement
{
	private int int_3;

	private float float_2 = 1f;

	private float float_3 = 1f;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private float float_4 = 0.5f;

	private float float_5 = 0.5f;

	private bool bool_19;

	private bool bool_20;

	private bool bool_21;

	private bool bool_22;

	private float float_6;

	private GfxEmitterData gfxEmitterData_0 = new GfxEmitterData();

	private List<KPController> list_1 = new List<KPController>();

	public int Quota
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

	public float ParticleWidth
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

	public float ParticleHeight
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

	public bool Is3D
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

	public bool Facing
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

	public bool ScaleNoOffset
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

	public bool NoWidthScale
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

	public bool NoHeightScale
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

	public bool UseParUV
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

	public bool StartOnGround
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

	public bool StopEmitWhenFade
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

	public bool InitRandom
	{
		[CompilerGenerated]
		get
		{
			return bool_22;
		}
		[CompilerGenerated]
		set
		{
			bool_22 = value;
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

	public GfxEmitterData Emitter
	{
		[CompilerGenerated]
		get
		{
			return gfxEmitterData_0;
		}
		[CompilerGenerated]
		set
		{
			gfxEmitterData_0 = value;
		}
	}

	public List<KPController> Affectors
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public GfxParticleElement(GfxElementType type)
	{
		base.ElementType = type;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		Quota = gfxFileReader_0.ReadInt();
		ParticleWidth = gfxFileReader_0.ReadFloat();
		ParticleHeight = gfxFileReader_0.ReadFloat();
		Is3D = gfxFileReader_0.ReadBool();
		Facing = gfxFileReader_0.ReadBool();
		if (version >= 30)
		{
			ScaleNoOffset = gfxFileReader_0.ReadBool();
		}
		if (version >= 37)
		{
			NoWidthScale = gfxFileReader_0.ReadBool();
			NoHeightScale = gfxFileReader_0.ReadBool();
			OrgPtWidth = gfxFileReader_0.ReadFloat();
			OrgPtHeight = gfxFileReader_0.ReadFloat();
		}
		if (version >= 72)
		{
			UseParUV = gfxFileReader_0.ReadBool();
		}
		if (version >= 79)
		{
			StartOnGround = gfxFileReader_0.ReadBool();
		}
		if (version >= 92)
		{
			StopEmitWhenFade = gfxFileReader_0.ReadBool();
		}
		if (version >= 99)
		{
			InitRandom = gfxFileReader_0.ReadBool();
		}
		if (version >= 108)
		{
			ZOffset = gfxFileReader_0.ReadFloat();
		}
		Emitter.Load(gfxFileReader_0, version, base.ElementType);
		int num = gfxFileReader_0.ReadInt();
		for (int i = 0; i < num; i++)
		{
			KPController kPController = KPController.LoadFromFile(gfxFileReader_0, version);
			if (kPController != null)
			{
				Affectors.Add(kPController);
			}
		}
	}
}
