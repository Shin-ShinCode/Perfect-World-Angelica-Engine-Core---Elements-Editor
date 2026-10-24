using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_USE_SKILL_2 : ICloneable, IOperation
{
	private uint uint_0;

	private uint uint_1;

	private SkillID skillID_0;

	private uint uint_2;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 20;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Level")]
	public uint Level
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

	[LocalizedDisplayName("LevelType")]
	[LocalizedCategory("OperationParam")]
	public uint LevelType
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937202));

	[Browsable(false)]
	public int OperID => 26;

	[LocalizedDisplayName("Skill")]
	[LocalizedCategory("OperationParam")]
	public SkillID Skill
	{
		[CompilerGenerated]
		get
		{
			return skillID_0;
		}
		[CompilerGenerated]
		set
		{
			skillID_0 = value;
		}
	}

	[LocalizedDisplayName("SkillType")]
	[LocalizedCategory("OperationParam")]
	public uint SkillType
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

	public O_USE_SKILL_2()
	{
		Skill = new SkillID();
		SkillType = 0u;
		Level = 0u;
		LevelType = 0u;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_USE_SKILL_2 o_USE_SKILL_ = new O_USE_SKILL_2();
		o_USE_SKILL_.Skill = Skill;
		o_USE_SKILL_.SkillType = SkillType;
		o_USE_SKILL_.Level = Level;
		o_USE_SKILL_.LevelType = LevelType;
		o_USE_SKILL_.Target = Target.Clone() as TargetParam;
		return o_USE_SKILL_;
	}

	public void Read(BinaryReader br)
	{
		Skill = new SkillID
		{
			Value = br.ReadUInt32()
		};
		SkillType = br.ReadUInt32();
		Level = br.ReadUInt32();
		LevelType = br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Skill.Value.ToString().Contains(str) && !SkillType.ToString().Contains(str) && !Level.ToString().Contains(str) && !LevelType.ToString().Contains(str) && !Target.ToString().Contains(str) && !Target.Target.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Skill.Value);
		bw.Write(SkillType);
		bw.Write(Level);
		bw.Write(LevelType);
		TargetStream.Save(bw, Target);
	}
}
