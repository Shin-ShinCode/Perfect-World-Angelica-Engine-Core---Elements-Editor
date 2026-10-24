using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_76 : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	private int int_0;

	private VarType varType_0;

	private int int_1;

	private VarType varType_1;

	[Browsable(false)]
	public int FromVersion => 33;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938290));

	[Browsable(false)]
	public int OperID => 76;

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
	[LocalizedDisplayName("uLevel")]
	public int uLevel
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
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
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

	public O_76()
	{
		uSkill = 0;
		uSkillType = VarType.GlobalVarID;
		uLevel = 0;
		uLevelType = VarType.GlobalVarID;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_76 o_ = new O_76();
		o_.uSkill = uSkill;
		o_.uSkillType = uSkillType;
		o_.uLevel = uLevel;
		o_.uLevelType = uLevelType;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		uSkill = br.ReadInt32();
		uSkillType = (VarType)br.ReadInt32();
		uLevel = br.ReadInt32();
		uLevelType = (VarType)br.ReadInt32();
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
		TargetStream.Save(bw, Target);
	}
}
