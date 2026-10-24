using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_USE_SKILL_4 : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	private int int_1;

	private VarType varType_0;

	private int int_2;

	private VarType varType_1;

	private int int_3;

	[Browsable(false)]
	public int FromVersion => 33;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iMonsterID")]
	public int iMonsterID
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937230));

	[Browsable(false)]
	public int OperID => 77;

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

	[LocalizedDisplayName("uLevel")]
	[LocalizedCategory("OperationParam")]
	public int uLevel
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
	[LocalizedDisplayName("uLevelType")]
	public VarType uLevelType
	{
		[CompilerGenerated]
		get
		{
			return varType_0;
		}
		[CompilerGenerated]
		set
		{
			varType_0 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("uSkill")]
	public int uSkill
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

	[LocalizedDisplayName("uSkillType")]
	[LocalizedCategory("OperationParam")]
	public VarType uSkillType
	{
		[CompilerGenerated]
		get
		{
			return varType_1;
		}
		[CompilerGenerated]
		set
		{
			varType_1 = value;
		}
	}

	[LocalizedDisplayName("Value5")]
	[LocalizedCategory("OperationParam")]
	public int Value5
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

	public O_USE_SKILL_4()
	{
		uSkill = 0;
		uSkillType = VarType.GlobalVarID;
		uLevel = 0;
		uLevelType = VarType.GlobalVarID;
		iMonsterID = 0;
		Value5 = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_USE_SKILL_4 o_USE_SKILL_ = new O_USE_SKILL_4();
		o_USE_SKILL_.uSkill = uSkill;
		o_USE_SKILL_.uSkillType = uSkillType;
		o_USE_SKILL_.uLevel = uLevel;
		o_USE_SKILL_.uLevelType = uLevelType;
		o_USE_SKILL_.iMonsterID = iMonsterID;
		o_USE_SKILL_.Value5 = Value5;
		o_USE_SKILL_.Target = Target.Clone() as TargetParam;
		return o_USE_SKILL_;
	}

	public void Read(BinaryReader br)
	{
		uSkill = br.ReadInt32();
		uSkillType = (VarType)br.ReadInt32();
		uLevel = br.ReadInt32();
		uLevelType = (VarType)br.ReadInt32();
		iMonsterID = br.ReadInt32();
		Value5 = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!uSkill.ToString().Contains(str) && !uSkillType.ToString().Contains(str) && !uLevel.ToString().Contains(str) && !uLevelType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(uSkill);
		bw.Write(Convert.ToUInt32(uSkillType));
		bw.Write(uLevel);
		bw.Write(Convert.ToUInt32(uLevelType));
		bw.Write(iMonsterID);
		bw.Write(Value5);
		TargetStream.Save(bw, Target);
	}
}
