using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_USE_SKILL : ICloneable, IOperation
{
	private uint uint_0;

	private SkillID skillID_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 1;

	[LocalizedDisplayName("Level")]
	[LocalizedCategory("OperationParam")]
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937193));

	[Browsable(false)]
	public int OperID => 1;

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

	public O_USE_SKILL()
	{
		Skill = new SkillID();
		Level = 0u;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_USE_SKILL o_USE_SKILL = new O_USE_SKILL();
		o_USE_SKILL.Skill = Skill;
		o_USE_SKILL.Level = Level;
		o_USE_SKILL.Target = Target.Clone() as TargetParam;
		return o_USE_SKILL;
	}

	public void Read(BinaryReader br)
	{
		Skill = new SkillID
		{
			Value = br.ReadUInt32()
		};
		Level = br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Skill.Value.ToString().Contains(str) && !Level.ToString().Contains(str) && !Target.ToString().Contains(str) && !Target.Target.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Skill.Value);
		bw.Write(Level);
		TargetStream.Save(bw, Target);
	}
}
