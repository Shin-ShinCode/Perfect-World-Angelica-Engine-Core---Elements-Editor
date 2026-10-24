using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_USE_SKILL_IN_STRATEGY_ZONE : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private TargetParam targetParam_0;

	private int int_12;

	private VarType varType_0;

	private int int_13;

	private VarType varType_1;

	private int int_14;

	[Browsable(false)]
	public int FromVersion => 33;

	[LocalizedCategory("ControllersParam")]
	[LocalizedDisplayName("ID1")]
	public int ID1
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

	[LocalizedDisplayName("ID1Type")]
	[LocalizedCategory("ControllersParam")]
	public int ID1Type
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

	[LocalizedCategory("ControllersParam")]
	[LocalizedDisplayName("ID2")]
	public int ID2
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

	[LocalizedDisplayName("ID2Type")]
	[LocalizedCategory("ControllersParam")]
	public int ID2Type
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

	[LocalizedCategory("ControllersParam")]
	[LocalizedDisplayName("ID3")]
	public int ID3
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

	[LocalizedDisplayName("ID3Type")]
	[LocalizedCategory("ControllersParam")]
	public int ID3Type
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

	[LocalizedDisplayName("ID4")]
	[LocalizedCategory("ControllersParam")]
	public int ID4
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

	[LocalizedDisplayName("ID4Type")]
	[LocalizedCategory("ControllersParam")]
	public int ID4Type
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

	[LocalizedDisplayName("ID5")]
	[LocalizedCategory("ControllersParam")]
	public int ID5
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

	[LocalizedCategory("ControllersParam")]
	[LocalizedDisplayName("ID5Type")]
	public int ID5Type
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

	[LocalizedDisplayName("ID6")]
	[LocalizedCategory("ControllersParam")]
	public int ID6
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

	[LocalizedDisplayName("ID6Type")]
	[LocalizedCategory("ControllersParam")]
	public int ID6Type
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937242));

	[Browsable(false)]
	public int OperID => 74;

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
			return int_12;
		}
		[CompilerGenerated]
		set
		{
			int_12 = value;
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

	[LocalizedDisplayName("uSkill")]
	[LocalizedCategory("OperationParam")]
	public int uSkill
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("uSkillType")]
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

	[LocalizedDisplayName("Value2")]
	[LocalizedCategory("OperationParam")]
	public int Value2
	{
		[CompilerGenerated]
		get
		{
			return int_14;
		}
		[CompilerGenerated]
		set
		{
			int_14 = value;
		}
	}

	public O_USE_SKILL_IN_STRATEGY_ZONE()
	{
		ID1 = 0;
		ID1Type = 0;
		ID2 = 0;
		ID2Type = 0;
		ID3 = 0;
		ID3Type = 0;
		ID4 = 0;
		ID4Type = 0;
		ID5 = 0;
		ID5Type = 0;
		ID6 = 0;
		ID6Type = 0;
		Value2 = 0;
		uSkill = 0;
		uSkillType = VarType.GlobalVarID;
		uLevel = 0;
		uLevelType = VarType.GlobalVarID;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_USE_SKILL_IN_STRATEGY_ZONE o_USE_SKILL_IN_STRATEGY_ZONE = new O_USE_SKILL_IN_STRATEGY_ZONE();
		o_USE_SKILL_IN_STRATEGY_ZONE.ID1 = ID1;
		o_USE_SKILL_IN_STRATEGY_ZONE.ID1Type = ID1Type;
		o_USE_SKILL_IN_STRATEGY_ZONE.ID2 = ID2;
		o_USE_SKILL_IN_STRATEGY_ZONE.ID2Type = ID2Type;
		o_USE_SKILL_IN_STRATEGY_ZONE.ID3 = ID3;
		o_USE_SKILL_IN_STRATEGY_ZONE.ID3Type = ID3Type;
		o_USE_SKILL_IN_STRATEGY_ZONE.ID4 = ID4;
		o_USE_SKILL_IN_STRATEGY_ZONE.ID4Type = ID4Type;
		o_USE_SKILL_IN_STRATEGY_ZONE.ID5 = ID5;
		o_USE_SKILL_IN_STRATEGY_ZONE.ID5Type = ID5Type;
		o_USE_SKILL_IN_STRATEGY_ZONE.ID6 = ID6;
		o_USE_SKILL_IN_STRATEGY_ZONE.ID6Type = ID6Type;
		o_USE_SKILL_IN_STRATEGY_ZONE.Value2 = Value2;
		o_USE_SKILL_IN_STRATEGY_ZONE.uSkill = uSkill;
		o_USE_SKILL_IN_STRATEGY_ZONE.uSkillType = uSkillType;
		o_USE_SKILL_IN_STRATEGY_ZONE.uLevel = uLevel;
		o_USE_SKILL_IN_STRATEGY_ZONE.uLevelType = uLevelType;
		o_USE_SKILL_IN_STRATEGY_ZONE.Target = Target.Clone() as TargetParam;
		return o_USE_SKILL_IN_STRATEGY_ZONE;
	}

	public void Read(BinaryReader br)
	{
		ID1 = br.ReadInt32();
		ID1Type = br.ReadInt32();
		ID2 = br.ReadInt32();
		ID2Type = br.ReadInt32();
		ID3 = br.ReadInt32();
		ID3Type = br.ReadInt32();
		ID4 = br.ReadInt32();
		ID4Type = br.ReadInt32();
		ID5 = br.ReadInt32();
		ID5Type = br.ReadInt32();
		ID6 = br.ReadInt32();
		ID6Type = br.ReadInt32();
		Value2 = br.ReadInt32();
		uSkill = br.ReadInt32();
		uSkillType = (VarType)br.ReadInt32();
		uLevel = br.ReadInt32();
		uLevelType = (VarType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (Value2.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID1);
		bw.Write(ID1Type);
		bw.Write(ID2);
		bw.Write(ID2Type);
		bw.Write(ID3);
		bw.Write(ID3Type);
		bw.Write(ID4);
		bw.Write(ID4Type);
		bw.Write(ID5);
		bw.Write(ID5Type);
		bw.Write(ID6);
		bw.Write(ID6Type);
		bw.Write(Value2);
		bw.Write(uSkill);
		bw.Write(Convert.ToUInt32(uSkillType));
		bw.Write(uLevel);
		bw.Write(Convert.ToUInt32(uLevelType));
		TargetStream.Save(bw, Target);
	}
}
