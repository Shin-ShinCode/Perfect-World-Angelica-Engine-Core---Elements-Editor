using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_PET_POLICY : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private int int_2;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 35;

	[LocalizedDisplayName("MonsterID")]
	[LocalizedCategory("OperationParam")]
	public int MonsterID
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937886));

	[Browsable(false)]
	public int OperID => 88;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("SkillID")]
	public int SkillID
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("SkillType")]
	public int SkillType
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

	[LocalizedDisplayName("Target")]
	[LocalizedCategory("TargetParam")]
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

	public O_PET_POLICY()
	{
		SkillID = 0;
		SkillType = 0;
		MonsterID = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_PET_POLICY o_PET_POLICY = new O_PET_POLICY();
		o_PET_POLICY.SkillID = SkillID;
		o_PET_POLICY.SkillType = SkillType;
		o_PET_POLICY.MonsterID = MonsterID;
		o_PET_POLICY.Target = Target.Clone() as TargetParam;
		return o_PET_POLICY;
	}

	public void Read(BinaryReader br)
	{
		SkillID = br.ReadInt32();
		SkillType = br.ReadInt32();
		MonsterID = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!SkillID.ToString().Contains(str) && !SkillType.ToString().Contains(str) && !MonsterID.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(SkillID);
		bw.Write(SkillType);
		bw.Write(MonsterID);
		TargetStream.Save(bw, Target);
	}
}
