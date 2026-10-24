using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_USE_SKILL_IN_REGION : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	private int int_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	[Browsable(false)]
	public int FromVersion => 33;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937232));

	[Browsable(false)]
	public int OperID => 67;

	[LocalizedCategory("TargetParam")]
	[LocalizedDisplayName("Target")]
	public TargetParam Target
	{
		[CompilerGenerated]
		get
		{
			return targetParam_0;
		}
		[CompilerGenerated]
		set
		{
			targetParam_0 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("uSkill")]
	public int uSkill
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

	[LocalizedDisplayName("zvMax_X")]
	[LocalizedCategory("OperationParam")]
	public float zvMax_X
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("zvMax_Y")]
	public float zvMax_Y
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

	[LocalizedDisplayName("zvMax_Z")]
	[LocalizedCategory("OperationParam")]
	public float zvMax_Z
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

	[LocalizedDisplayName("zvMin_X")]
	[LocalizedCategory("OperationParam")]
	public float zvMin_X
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("zvMin_Y")]
	public float zvMin_Y
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

	[LocalizedDisplayName("zvMin_Z")]
	[LocalizedCategory("OperationParam")]
	public float zvMin_Z
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

	public O_USE_SKILL_IN_REGION()
	{
		zvMin_X = 0f;
		zvMin_Y = 0f;
		zvMin_Z = 0f;
		zvMax_X = 0f;
		zvMax_Y = 0f;
		zvMax_Z = 0f;
		uSkill = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_USE_SKILL_IN_REGION o_USE_SKILL_IN_REGION = new O_USE_SKILL_IN_REGION();
		o_USE_SKILL_IN_REGION.zvMin_X = zvMin_X;
		o_USE_SKILL_IN_REGION.zvMin_Y = zvMin_Y;
		o_USE_SKILL_IN_REGION.zvMin_Z = zvMin_Z;
		o_USE_SKILL_IN_REGION.zvMax_X = zvMax_X;
		o_USE_SKILL_IN_REGION.zvMax_Y = zvMax_Y;
		o_USE_SKILL_IN_REGION.zvMax_Z = zvMax_Z;
		o_USE_SKILL_IN_REGION.uSkill = uSkill;
		o_USE_SKILL_IN_REGION.Target = Target.Clone() as TargetParam;
		return o_USE_SKILL_IN_REGION;
	}

	public void Read(BinaryReader br)
	{
		zvMin_X = br.ReadSingle();
		zvMin_Y = br.ReadSingle();
		zvMin_Z = br.ReadSingle();
		zvMax_X = br.ReadSingle();
		zvMax_Y = br.ReadSingle();
		zvMax_Z = br.ReadSingle();
		uSkill = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (uSkill.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(zvMin_X);
		bw.Write(zvMin_Y);
		bw.Write(zvMin_Z);
		bw.Write(zvMax_X);
		bw.Write(zvMax_Y);
		bw.Write(zvMax_Z);
		bw.Write(uSkill);
		TargetStream.Save(bw, Target);
	}
}
