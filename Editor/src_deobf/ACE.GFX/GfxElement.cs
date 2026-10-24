using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using ACE.Models.ECM;

namespace ACE.GFX;

public abstract class GfxElement
{
	private GfxElementType gfxElementType_0 = GfxElementType.None;

	private string string_0 = string.Empty;

	public GfxShader Shader;

	private string string_1 = string.Empty;

	private bool bool_0 = true;

	private int int_0;

	private int int_1;

	private int int_2 = 1;

	private uint uint_0;

	private string string_2 = string.Empty;

	private GfxElement gfxElement_0;

	private bool bool_1;

	private string string_3 = string.Empty;

	private uint uint_1 = 1u;

	private uint uint_2 = 1u;

	private uint uint_3;

	private uint uint_4;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private float float_0;

	private float float_1;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private string string_4 = string.Empty;

	private string string_5 = string.Empty;

	private List<GfxPixelShaderConst> list_0 = new List<GfxPixelShaderConst>();

	private GfxKeyPointSet gfxKeyPointSet_0 = new GfxKeyPointSet();

	private GfxState gfxState_0;

	public GfxElementType ElementType
	{
		[CompilerGenerated]
		get
		{
			return gfxElementType_0;
		}
		[CompilerGenerated]
		set
		{
			gfxElementType_0 = value;
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string TexturePath
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public bool ZEnable
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public int RenderLayer
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int Priority
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int RepeatCount
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public uint RepeatDelay
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public string BindElement
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public string BindElementName => BindElement;

	public GfxElement BindTarget
	{
		[CompilerGenerated]
		get
		{
			return gfxElement_0;
		}
		[CompilerGenerated]
		set
		{
			gfxElement_0 = value;
		}
	}

	public bool IsDummy
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public string DummyElement
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public uint TexRows
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	public uint TexCols
	{
		[CompilerGenerated]
		get
		{
			return uint_2;
		}
		[CompilerGenerated]
		set
		{
			uint_2 = value;
		}
	}

	public uint TexInterval
	{
		[CompilerGenerated]
		get
		{
			return uint_3;
		}
		[CompilerGenerated]
		set
		{
			uint_3 = value;
		}
	}

	public uint TexAnimMaxTime
	{
		[CompilerGenerated]
		get
		{
			return uint_4;
		}
		[CompilerGenerated]
		set
		{
			uint_4 = value;
		}
	}

	public bool UseGroundNormal
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public bool UseGroundHeight
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public bool TileMode
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public float UOffsetSpeed
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public float VOffsetSpeed
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	public bool UReverse
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	public bool VReverse
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public bool UVInterchange
	{
		[CompilerGenerated]
		get
		{
			return bool_7;
		}
		[CompilerGenerated]
		set
		{
			bool_7 = value;
		}
	}

	public bool Warp
	{
		[CompilerGenerated]
		get
		{
			return bool_8;
		}
		[CompilerGenerated]
		set
		{
			bool_8 = value;
		}
	}

	public bool NoDownSample
	{
		[CompilerGenerated]
		get
		{
			return bool_9;
		}
		[CompilerGenerated]
		set
		{
			bool_9 = value;
		}
	}

	public bool ResetWhenLoop
	{
		[CompilerGenerated]
		get
		{
			return bool_10;
		}
		[CompilerGenerated]
		set
		{
			bool_10 = value;
		}
	}

	public bool CanDoFadeOut
	{
		[CompilerGenerated]
		get
		{
			return bool_11;
		}
		[CompilerGenerated]
		set
		{
			bool_11 = value;
		}
	}

	public bool SoftEdge
	{
		[CompilerGenerated]
		get
		{
			return bool_12;
		}
		[CompilerGenerated]
		set
		{
			bool_12 = value;
		}
	}

	public bool UseInnerLight
	{
		[CompilerGenerated]
		get
		{
			return bool_13;
		}
		[CompilerGenerated]
		set
		{
			bool_13 = value;
		}
	}

	public string PixelShaderPath
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	public string ShaderTexPath
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		set
		{
			string_5 = value;
		}
	}

	public List<GfxPixelShaderConst> PSConsts
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public GfxKeyPointSet KeyPointSet
	{
		[CompilerGenerated]
		get
		{
			return gfxKeyPointSet_0;
		}
		[CompilerGenerated]
		set
		{
			gfxKeyPointSet_0 = value;
		}
	}

	public GfxState State
	{
		[CompilerGenerated]
		get
		{
			return gfxState_0;
		}
		[CompilerGenerated]
		set
		{
			gfxState_0 = value;
		}
	}

	public Vector3f CurrentPosition => KeyPointSet.ProcData.Position;

	public Quaternion CurrentDirection => KeyPointSet.ProcData.Direction;

	public uint CurrentColor => KeyPointSet.ProcData.Color;

	public float CurrentScale => KeyPointSet.ProcData.Scale;

	public float CurrentRad2D => KeyPointSet.ProcData.Rad2D;

	public abstract void LoadSpecific(GfxFileReader gfxFileReader_0, uint version);

	public virtual void Play()
	{
		State = GfxState.Play;
		KeyPointSet.Start();
	}

	public virtual void Stop()
	{
		State = GfxState.Stop;
	}

	public virtual void Tick(uint deltaTimeMs)
	{
		if (State == GfxState.Play)
		{
			KeyPointSet.TickAnimation(deltaTimeMs);
			if (KeyPointSet.IsFinished)
			{
				State = GfxState.Stop;
			}
		}
	}

	public static GfxElement LoadFromFile(GfxFileReader gfxFileReader_0, uint version)
	{
		int num = gfxFileReader_0.ReadInt();
		GfxElementType gfxElementType = (GfxElementType)num;
		GfxElement gfxElement = smethod_0(gfxElementType);
		if (gfxElement == null)
		{
			return null;
		}
		gfxElement.ElementType = gfxElementType;
		gfxElement.Name = gfxFileReader_0.ReadString();
		gfxElement.Shader.SrcBlend = gfxFileReader_0.ReadInt();
		gfxElement.Shader.DestBlend = gfxFileReader_0.ReadInt();
		int repeatCount = gfxFileReader_0.ReadInt();
		uint repeatDelay = (uint)gfxFileReader_0.ReadInt();
		gfxElement.TexturePath = gfxFileReader_0.ReadString();
		if (version >= 4)
		{
			gfxElement.BindElement = gfxFileReader_0.ReadString();
		}
		if (version >= 8)
		{
			gfxElement.ZEnable = gfxFileReader_0.ReadBool();
			if (version < 76)
			{
				gfxElement.ZEnable = true;
			}
		}
		if (version >= 22)
		{
			gfxElement.UseGroundNormal = gfxFileReader_0.ReadBool();
		}
		if (version >= 57)
		{
			gfxElement.UseGroundHeight = gfxFileReader_0.ReadBool();
		}
		if (version >= 9)
		{
			gfxElement.TexRows = (uint)gfxFileReader_0.ReadInt();
			gfxElement.TexCols = (uint)gfxFileReader_0.ReadInt();
			gfxElement.TexInterval = (uint)gfxFileReader_0.ReadInt();
		}
		if (version >= 28)
		{
			gfxElement.Priority = gfxFileReader_0.ReadInt();
		}
		if (version >= 32)
		{
			gfxElement.IsDummy = gfxFileReader_0.ReadBool();
			gfxElement.DummyElement = gfxFileReader_0.ReadString();
		}
		if (version >= 33)
		{
			gfxElement.Warp = gfxFileReader_0.ReadBool();
		}
		if (version >= 34)
		{
			gfxElement.TileMode = gfxFileReader_0.ReadBool();
			gfxElement.UOffsetSpeed = gfxFileReader_0.ReadFloat();
			gfxElement.VOffsetSpeed = gfxFileReader_0.ReadFloat();
		}
		if (version >= 41)
		{
			gfxElement.UReverse = gfxFileReader_0.ReadBool();
			gfxElement.VReverse = gfxFileReader_0.ReadBool();
			gfxElement.UVInterchange = gfxFileReader_0.ReadBool();
		}
		if (version >= 45)
		{
			gfxElement.RenderLayer = gfxFileReader_0.ReadInt();
		}
		if (version >= 58)
		{
			gfxElement.NoDownSample = gfxFileReader_0.ReadBool();
		}
		if (version >= 74)
		{
			gfxElement.ResetWhenLoop = gfxFileReader_0.ReadBool();
		}
		if (version >= 75)
		{
			gfxElement.TexAnimMaxTime = (uint)gfxFileReader_0.ReadInt();
		}
		switch (version)
		{
		default:
			smethod_1(gfxFileReader_0, gfxElement);
			break;
		case 91u:
		case 92u:
		case 93u:
		case 94u:
			smethod_2(gfxFileReader_0, gfxElement, version);
			break;
		case 0u:
		case 1u:
		case 2u:
		case 3u:
		case 4u:
		case 5u:
		case 6u:
		case 7u:
		case 8u:
		case 9u:
		case 10u:
		case 11u:
		case 12u:
		case 13u:
		case 14u:
		case 15u:
		case 16u:
		case 17u:
		case 18u:
		case 19u:
		case 20u:
		case 21u:
		case 22u:
		case 23u:
		case 24u:
		case 25u:
		case 26u:
		case 27u:
		case 28u:
		case 29u:
		case 30u:
		case 31u:
		case 32u:
		case 33u:
		case 34u:
		case 35u:
		case 36u:
		case 37u:
		case 38u:
		case 39u:
		case 40u:
		case 41u:
		case 42u:
		case 43u:
		case 44u:
		case 45u:
		case 46u:
		case 47u:
		case 48u:
		case 49u:
		case 50u:
		case 51u:
		case 52u:
		case 53u:
		case 54u:
		case 55u:
		case 56u:
		case 57u:
		case 58u:
		case 59u:
		case 60u:
		case 61u:
		case 62u:
		case 63u:
		case 64u:
		case 65u:
		case 66u:
		case 67u:
		case 68u:
		case 69u:
		case 70u:
		case 71u:
		case 72u:
		case 73u:
		case 74u:
		case 75u:
		case 76u:
		case 77u:
		case 78u:
		case 79u:
		case 80u:
		case 81u:
		case 82u:
		case 83u:
		case 84u:
		case 85u:
		case 86u:
		case 87u:
		case 88u:
		case 89u:
		case 90u:
			break;
		}
		if (version >= 92)
		{
			gfxElement.CanDoFadeOut = gfxFileReader_0.ReadBool();
		}
		if (version >= 104)
		{
			gfxElement.SoftEdge = gfxFileReader_0.ReadBool();
		}
		if (version >= 118)
		{
			gfxElement.UseInnerLight = gfxFileReader_0.ReadBool();
		}
		if (version >= 105)
		{
			smethod_3(gfxFileReader_0);
		}
		if (version >= 109)
		{
			smethod_4(gfxFileReader_0);
		}
		gfxElement.RepeatCount = repeatCount;
		gfxElement.RepeatDelay = repeatDelay;
		gfxElement.LoadSpecific(gfxFileReader_0, version);
		gfxElement.KeyPointSet.RepeatCount = repeatCount;
		gfxElement.KeyPointSet.RepeatDelay = repeatDelay;
		gfxElement.KeyPointSet.Load(gfxFileReader_0, version);
		return gfxElement;
	}

	private static GfxElement smethod_0(GfxElementType gfxElementType_1)
	{
		switch (gfxElementType_1)
		{
		case GfxElementType.Light:
			return new GfxLightElement();
		case GfxElementType.Trail:
			return new GfxTrailElement();
		case GfxElementType.TrailEx:
			return new GfxTrailExElement();
		case GfxElementType.ParticlePoint:
		case GfxElementType.ParticleBox:
		case GfxElementType.ParticleMultiPlane:
		case GfxElementType.ParticleEllipsoid:
		case GfxElementType.ParticleCylinder:
		case GfxElementType.ParticleCurve:
		case GfxElementType.ParticleSkeleton:
			return new GfxParticleElement(gfxElementType_1);
		case GfxElementType.Decal3D:
		case GfxElementType.Decal2D:
		case GfxElementType.DecalBillboard:
			return new GfxDecalElement(gfxElementType_1);
		case GfxElementType.Lightning:
			return new GfxLightningElement();
		case GfxElementType.LtnBolt:
			return new GfxLtnBoltElement();
		case GfxElementType.LightningEx:
			return new GfxLightningExElement();
		case GfxElementType.Ring:
			return new GfxRingElement();
		case GfxElementType.Sound:
			return new GfxSoundElement();
		case GfxElementType.Model:
			return new GfxModelElement();
		case GfxElementType.GfxContainer:
			return new GfxContainerElement();
		case GfxElementType.Paraboloid:
			return new GfxParaboloidElement();
		case GfxElementType.LtnTrail:
			return new GfxLtnTrailElement();
		case GfxElementType.ECModel:
			return new GfxECModelElement();
		case GfxElementType.GridDecal3D:
		case GfxElementType.GridDecal2D:
			return new GfxGridDecalElement(gfxElementType_1);
		default:
			return null;
		case GfxElementType.ModelProxy:
			return new GfxModelProxyElement();
		case GfxElementType.Ribbon:
			return new GfxRibbonElement();
		}
	}

	private static void smethod_1(GfxFileReader gfxFileReader_0, GfxElement gfxElement_1)
	{
		gfxFileReader_0.ReadInt();
		gfxElement_1.PixelShaderPath = gfxFileReader_0.ReadString();
		gfxElement_1.ShaderTexPath = gfxFileReader_0.ReadString();
		int num = gfxFileReader_0.ReadInt();
		for (int i = 0; i < num; i++)
		{
			GfxPixelShaderConst gfxPixelShaderConst = new GfxPixelShaderConst();
			gfxPixelShaderConst.Index = gfxFileReader_0.ReadInt();
			(float x, float y, float z, float w) tuple = gfxFileReader_0.ReadVector4();
			float item = tuple.x;
			float item2 = tuple.y;
			float item3 = tuple.z;
			float item4 = tuple.w;
			gfxPixelShaderConst.InitR = item;
			gfxPixelShaderConst.InitG = item2;
			gfxPixelShaderConst.InitB = item3;
			gfxPixelShaderConst.InitA = item4;
			gfxPixelShaderConst.LoopCount = gfxFileReader_0.ReadInt();
			int num2 = gfxFileReader_0.ReadInt();
			for (int j = 0; j < num2; j++)
			{
				GfxPixelShaderConst.GfxPSTarget gfxPSTarget = new GfxPixelShaderConst.GfxPSTarget();
				gfxPSTarget.Interval = gfxFileReader_0.ReadInt();
				(float x, float y, float z, float w) tuple2 = gfxFileReader_0.ReadVector4();
				float item5 = tuple2.x;
				float item6 = tuple2.y;
				float item7 = tuple2.z;
				float item8 = tuple2.w;
				gfxPSTarget.float_0 = item5;
				gfxPSTarget.float_1 = item6;
				gfxPSTarget.float_2 = item7;
				gfxPSTarget.float_3 = item8;
				gfxPixelShaderConst.Targets.Add(gfxPSTarget);
			}
			gfxElement_1.PSConsts.Add(gfxPixelShaderConst);
		}
	}

	private static void smethod_2(GfxFileReader gfxFileReader_0, GfxElement gfxElement_1, uint uint_5)
	{
		gfxElement_1.PixelShaderPath = gfxFileReader_0.ReadString();
		gfxElement_1.ShaderTexPath = gfxFileReader_0.ReadString();
		int num = gfxFileReader_0.ReadInt();
		for (int i = 0; i < num; i++)
		{
			GfxPixelShaderConst gfxPixelShaderConst = new GfxPixelShaderConst();
			gfxPixelShaderConst.Index = gfxFileReader_0.ReadInt();
			(float x, float y, float z, float w) tuple = gfxFileReader_0.ReadVector4();
			float item = tuple.x;
			float item2 = tuple.y;
			float item3 = tuple.z;
			float item4 = tuple.w;
			gfxPixelShaderConst.InitR = item;
			gfxPixelShaderConst.InitG = item2;
			gfxPixelShaderConst.InitB = item3;
			gfxPixelShaderConst.InitA = item4;
			if (uint_5 >= 93)
			{
				gfxPixelShaderConst.LoopCount = gfxFileReader_0.ReadInt();
			}
			int num2 = gfxFileReader_0.ReadInt();
			for (int j = 0; j < num2; j++)
			{
				GfxPixelShaderConst.GfxPSTarget gfxPSTarget = new GfxPixelShaderConst.GfxPSTarget();
				gfxPSTarget.Interval = gfxFileReader_0.ReadInt();
				if (gfxPSTarget.Interval < 0 && uint_5 < 93)
				{
					gfxPSTarget.Interval = 0;
				}
				(float x, float y, float z, float w) tuple2 = gfxFileReader_0.ReadVector4();
				float item5 = tuple2.x;
				float item6 = tuple2.y;
				float item7 = tuple2.z;
				float item8 = tuple2.w;
				gfxPSTarget.float_0 = item5;
				gfxPSTarget.float_1 = item6;
				gfxPSTarget.float_2 = item7;
				gfxPSTarget.float_3 = item8;
				gfxPixelShaderConst.Targets.Add(gfxPSTarget);
			}
			gfxElement_1.PSConsts.Add(gfxPixelShaderConst);
		}
	}

	private static void smethod_3(GfxFileReader gfxFileReader_0)
	{
		int num = gfxFileReader_0.ReadInt();
		if (num < 1)
		{
			return;
		}
		int num2 = gfxFileReader_0.ReadInt();
		gfxFileReader_0.ReadString();
		if (num2 >= 2)
		{
			int num3 = gfxFileReader_0.ReadInt();
			for (int i = 0; i < num3; i++)
			{
				gfxFileReader_0.ReadLine();
				gfxFileReader_0.ReadLine();
			}
			return;
		}
		int num4 = gfxFileReader_0.ReadInt();
		for (int j = 0; j < num4; j++)
		{
			gfxFileReader_0.ReadString();
			switch (gfxFileReader_0.ReadInt())
			{
			case 0:
				gfxFileReader_0.ReadFloat();
				break;
			case 1:
				gfxFileReader_0.ReadVector3();
				break;
			case 2:
				gfxFileReader_0.ReadVector4();
				break;
			case 3:
				gfxFileReader_0.ReadInt();
				break;
			case 4:
				gfxFileReader_0.ReadString();
				break;
			}
		}
	}

	private static void smethod_4(GfxFileReader gfxFileReader_0)
	{
		for (int i = 0; i < 2; i++)
		{
			gfxFileReader_0.ReadInt();
			int num = gfxFileReader_0.ReadInt();
			for (int j = 0; j < num; j++)
			{
				gfxFileReader_0.ReadLine();
				gfxFileReader_0.ReadInt();
				int num2 = gfxFileReader_0.ReadInt();
				for (int k = 0; k < num2; k++)
				{
					string string_ = gfxFileReader_0.ReadLine();
					int num3 = smethod_5(string_);
					for (int l = 0; l < num3; l++)
					{
						gfxFileReader_0.ReadLine();
						gfxFileReader_0.ReadLine();
					}
				}
			}
		}
	}

	private static int smethod_5(string string_6)
	{
		if (string.IsNullOrEmpty(string_6))
		{
			return 0;
		}
		int num = string_6.IndexOf(Class16.smethod_0(1649072045), StringComparison.OrdinalIgnoreCase);
		if (num < 0)
		{
			return 0;
		}
		string text = string_6.Substring(num + 6).Trim();
		int num2 = text.IndexOf(' ');
		if (num2 > 0)
		{
			text = text.Substring(0, num2);
		}
		int.TryParse(text.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result);
		return result;
	}
}
