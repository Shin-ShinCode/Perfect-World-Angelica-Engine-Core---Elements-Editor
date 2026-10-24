using System.Runtime.CompilerServices;
using ACE.Models.ECM;

namespace ACE.GFX;

public abstract class KPController
{
	private KPCtrlType kpctrlType_0 = KPCtrlType.None;

	private float float_0;

	private float float_1 = -1f;

	public KPCtrlType Type
	{
		[CompilerGenerated]
		get
		{
			return kpctrlType_0;
		}
		[CompilerGenerated]
		set
		{
			kpctrlType_0 = value;
		}
	}

	public float StartTime
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

	public float EndTime
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

	public virtual bool HasAxis => false;

	public abstract void Load(GfxFileReader gfxFileReader_0, uint version);

	public bool Tick(float fTimeSpan)
	{
		if (StartTime > 0f && fTimeSpan < StartTime)
		{
			return false;
		}
		if (EndTime > 0f && fTimeSpan > EndTime)
		{
			return false;
		}
		return true;
	}

	public virtual Vector3f GetAxisCenter()
	{
		return GfxMath.Zero;
	}

	public abstract void Process(KPProcData data, float fTimeSpan);

	public virtual void Resume()
	{
	}

	public static KPController LoadFromFile(GfxFileReader gfxFileReader_0, uint version)
	{
		int kpctrlType_ = gfxFileReader_0.ReadInt();
		float startTime = 0f;
		float endTime = -1f;
		if (version >= 21)
		{
			startTime = gfxFileReader_0.ReadFloat();
			endTime = gfxFileReader_0.ReadFloat();
		}
		KPController kPController = smethod_0((KPCtrlType)kpctrlType_);
		if (kPController == null)
		{
			return null;
		}
		kPController.StartTime = startTime;
		kPController.EndTime = endTime;
		kPController.Load(gfxFileReader_0, version);
		return kPController;
	}

	private static KPController smethod_0(KPCtrlType kpctrlType_1)
	{
		return kpctrlType_1 switch
		{
			KPCtrlType.Move => new KPCtrlMove(), 
			KPCtrlType.Rot => new KPCtrlRot(), 
			KPCtrlType.RotAxis => new KPCtrlRotAxis(), 
			KPCtrlType.Revol => new KPCtrlRevol(), 
			KPCtrlType.Centri => new KPCtrlCentriMove(), 
			KPCtrlType.Color => new KPCtrlColorChange(), 
			KPCtrlType.Scale => new KPCtrlScaleChange(), 
			KPCtrlType.ColorNoise => new KPCtrlColorNoise(), 
			KPCtrlType.ColorTrans => new KPCtrlColorTrans(), 
			KPCtrlType.ScaleNoise => new KPCtrlScaleNoise(), 
			KPCtrlType.CurveMove => new KPCtrlCurveMove(), 
			KPCtrlType.ScaleTrans => new KPCtrlScaleTrans(), 
			KPCtrlType.NoiseBase => new KPCtrlNoiseBase(), 
			_ => null, 
		};
	}
}
