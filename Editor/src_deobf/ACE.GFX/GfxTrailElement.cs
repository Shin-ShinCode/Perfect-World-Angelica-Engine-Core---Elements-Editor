using System.Runtime.CompilerServices;
using ACE.Models.ECM;

namespace ACE.GFX;

public class GfxTrailElement : GfxElement
{
	public Vector3f OrgPos0;

	public Vector3f OrgPos1;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private int int_3;

	private bool bool_17;

	private TrailMode trailMode_0;

	private int int_4 = 5;

	private TrailPerturbMode trailPerturbMode_0;

	public float DisappearSpeed;

	public float SpreadSpeed;

	public float SpreadAccel;

	public float DisappearAccel;

	public float SpreadDelay;

	public float DisappearDelay;

	public int SpreadSegCount;

	public Vector3f SpreadDirMin;

	public Vector3f SpreadDirMax;

	private bool bool_18;

	public bool MatrixEnable
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

	public bool OrgPos1Enable
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

	public bool OrgPos2Enable
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
			return bool_17;
		}
		[CompilerGenerated]
		set
		{
			bool_17 = value;
		}
	}

	public TrailMode SplineMode
	{
		[CompilerGenerated]
		get
		{
			return trailMode_0;
		}
		[CompilerGenerated]
		set
		{
			trailMode_0 = value;
		}
	}

	public int SampleFreq
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public TrailPerturbMode PerturbMode
	{
		[CompilerGenerated]
		get
		{
			return trailPerturbMode_0;
		}
		[CompilerGenerated]
		set
		{
			trailPerturbMode_0 = value;
		}
	}

	public bool FaceCamera
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

	public GfxTrailElement()
	{
		base.ElementType = GfxElementType.Trail;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		(float x, float y, float z) tuple = gfxFileReader_0.ReadVector3();
		float item = tuple.x;
		float item2 = tuple.y;
		float item3 = tuple.z;
		OrgPos0 = new Vector3f(item, item2, item3);
		(float x, float y, float z) tuple2 = gfxFileReader_0.ReadVector3();
		float item4 = tuple2.x;
		float item5 = tuple2.y;
		float item6 = tuple2.z;
		OrgPos1 = new Vector3f(item4, item5, item6);
		MatrixEnable = gfxFileReader_0.ReadBool();
		OrgPos1Enable = gfxFileReader_0.ReadBool();
		OrgPos2Enable = gfxFileReader_0.ReadBool();
		SegLife = gfxFileReader_0.ReadInt();
		if (version >= 18)
		{
			Bind = gfxFileReader_0.ReadBool();
		}
		if (version < 80)
		{
			base.Warp = false;
		}
		if (version >= 87)
		{
			SplineMode = (TrailMode)gfxFileReader_0.ReadInt();
		}
		if (version >= 111)
		{
			SampleFreq = gfxFileReader_0.ReadInt();
		}
		if (version >= 122)
		{
			PerturbMode = (TrailPerturbMode)gfxFileReader_0.ReadInt();
			if (PerturbMode == TrailPerturbMode.Spreading)
			{
				DisappearSpeed = gfxFileReader_0.ReadFloat();
				SpreadSpeed = gfxFileReader_0.ReadFloat();
				SpreadSegCount = gfxFileReader_0.ReadInt();
				SpreadAccel = gfxFileReader_0.ReadFloat();
				(float x, float y, float z) tuple3 = gfxFileReader_0.ReadVector3();
				float item7 = tuple3.x;
				float item8 = tuple3.y;
				float item9 = tuple3.z;
				SpreadDirMin = new Vector3f(item7, item8, item9);
				(float x, float y, float z) tuple4 = gfxFileReader_0.ReadVector3();
				float item10 = tuple4.x;
				float item11 = tuple4.y;
				float item12 = tuple4.z;
				SpreadDirMax = new Vector3f(item10, item11, item12);
				DisappearAccel = gfxFileReader_0.ReadFloat();
				SpreadDelay = gfxFileReader_0.ReadFloat();
				DisappearDelay = gfxFileReader_0.ReadFloat();
			}
		}
		if (version >= 123)
		{
			FaceCamera = gfxFileReader_0.ReadBool();
		}
	}
}
