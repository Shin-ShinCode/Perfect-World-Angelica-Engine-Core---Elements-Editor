using System;
using System.Runtime.CompilerServices;
using ACE.Models.ECM;

namespace ACE.GFX;

public class GfxLightningExElement : GfxElement
{
	private int int_3 = 256;

	private float float_2 = 1f;

	private int int_4 = 1;

	private float float_3 = 0.25f;

	private int int_5 = 5;

	public Vector3f StartPos;

	public Vector3f EndPos;

	private int int_6 = 30;

	private int int_7 = 1;

	private float float_4 = 1f;

	private int int_8 = 100;

	private float[] float_5 = Array.Empty<float>();

	private float[] float_6 = Array.Empty<float>();

	private float float_7 = 0.1f;

	private float float_8 = 1f;

	private int int_9;

	private int int_10;

	private float[] float_9 = Array.Empty<float>();

	private int int_11;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	public Vector3f Normal;

	private bool bool_17;

	private bool bool_18;

	private float float_10 = 1f;

	private bool bool_19;

	private float float_11 = 5f;

	private bool bool_20;

	private int int_12;

	private bool bool_21;

	private int int_13;

	private bool bool_22;

	public int BufLen
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

	public float NoiseAmplitude
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

	public int NoiseWaveLen
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

	public float Persistence
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

	public int OctaveNum
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public int Segments
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	public int LightNum
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	public float LightningWaveLen
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

	public int Interval
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}

	public float[] Widths
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

	public float[] Alphas
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

	public float CenterWidth
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

	public float CenterAlpha
	{
		[CompilerGenerated]
		get
		{
			return float_8;
		}
		[CompilerGenerated]
		set
		{
			float_8 = value;
		}
	}

	public int DestNum
	{
		[CompilerGenerated]
		get
		{
			return int_9;
		}
		[CompilerGenerated]
		set
		{
			int_9 = value;
		}
	}

	public int DestStartTime
	{
		[CompilerGenerated]
		get
		{
			return int_10;
		}
		[CompilerGenerated]
		set
		{
			int_10 = value;
		}
	}

	public float[] DestVals
	{
		[CompilerGenerated]
		get
		{
			return float_9;
		}
		[CompilerGenerated]
		set
		{
			float_9 = value;
		}
	}

	public int TransTime
	{
		[CompilerGenerated]
		get
		{
			return int_11;
		}
		[CompilerGenerated]
		set
		{
			int_11 = value;
		}
	}

	public bool Pos1Enable
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

	public bool Pos2Enable
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

	public bool UseNormal
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

	public bool Filter
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

	public bool WaveMoving
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

	public float WaveMovingSpeed
	{
		[CompilerGenerated]
		get
		{
			return float_10;
		}
		[CompilerGenerated]
		set
		{
			float_10 = value;
		}
	}

	public bool FixWaveLength
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

	public float NumWaves
	{
		[CompilerGenerated]
		get
		{
			return float_11;
		}
		[CompilerGenerated]
		set
		{
			float_11 = value;
		}
	}

	public bool IsAppend
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

	public int RenderSide
	{
		[CompilerGenerated]
		get
		{
			return int_12;
		}
		[CompilerGenerated]
		set
		{
			int_12 = value;
		}
	}

	public bool IsTailDisappear
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

	public int VertsLife
	{
		[CompilerGenerated]
		get
		{
			return int_13;
		}
		[CompilerGenerated]
		set
		{
			int_13 = value;
		}
	}

	public bool TailFadeOut
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

	public GfxLightningExElement()
	{
		base.ElementType = GfxElementType.LightningEx;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		BufLen = gfxFileReader_0.ReadInt();
		NoiseAmplitude = gfxFileReader_0.ReadFloat();
		NoiseWaveLen = gfxFileReader_0.ReadInt();
		Persistence = gfxFileReader_0.ReadFloat();
		OctaveNum = gfxFileReader_0.ReadInt();
		(float x, float y, float z) tuple = gfxFileReader_0.ReadVector3();
		float item = tuple.x;
		float item2 = tuple.y;
		float item3 = tuple.z;
		StartPos = new Vector3f(item, item2, item3);
		(float x, float y, float z) tuple2 = gfxFileReader_0.ReadVector3();
		float item4 = tuple2.x;
		float item5 = tuple2.y;
		float item6 = tuple2.z;
		EndPos = new Vector3f(item4, item5, item6);
		Segments = gfxFileReader_0.ReadInt();
		LightNum = gfxFileReader_0.ReadInt();
		LightningWaveLen = gfxFileReader_0.ReadFloat();
		Interval = gfxFileReader_0.ReadInt();
		int num = LightNum + 1;
		Widths = new float[num];
		for (int i = 0; i < num; i++)
		{
			Widths[i] = gfxFileReader_0.ReadFloat();
		}
		Alphas = new float[num];
		for (int j = 0; j < num; j++)
		{
			Alphas[j] = gfxFileReader_0.ReadFloat();
		}
		CenterWidth = gfxFileReader_0.ReadFloat();
		CenterAlpha = gfxFileReader_0.ReadFloat();
		DestNum = gfxFileReader_0.ReadInt();
		DestStartTime = gfxFileReader_0.ReadInt();
		DestVals = new float[DestNum * 2];
		for (int k = 0; k < DestNum * 2; k++)
		{
			DestVals[k] = gfxFileReader_0.ReadFloat();
		}
		TransTime = gfxFileReader_0.ReadInt();
		Pos1Enable = gfxFileReader_0.ReadBool();
		Pos2Enable = gfxFileReader_0.ReadBool();
		UseNormal = gfxFileReader_0.ReadBool();
		(float x, float y, float z) tuple3 = gfxFileReader_0.ReadVector3();
		float item7 = tuple3.x;
		float item8 = tuple3.y;
		float item9 = tuple3.z;
		Normal = new Vector3f(item7, item8, item9);
		if (version >= 40)
		{
			Filter = gfxFileReader_0.ReadBool();
		}
		if (version >= 67)
		{
			WaveMoving = gfxFileReader_0.ReadBool();
			WaveMovingSpeed = gfxFileReader_0.ReadFloat();
		}
		if (version >= 68)
		{
			FixWaveLength = gfxFileReader_0.ReadBool();
			NumWaves = gfxFileReader_0.ReadFloat();
		}
		if (version >= 69)
		{
			IsAppend = gfxFileReader_0.ReadBool();
			RenderSide = gfxFileReader_0.ReadInt();
		}
		if (version >= 73)
		{
			IsTailDisappear = gfxFileReader_0.ReadBool();
		}
		if (version >= 77)
		{
			VertsLife = gfxFileReader_0.ReadInt();
		}
		if (version >= 78)
		{
			TailFadeOut = gfxFileReader_0.ReadBool();
		}
	}
}
