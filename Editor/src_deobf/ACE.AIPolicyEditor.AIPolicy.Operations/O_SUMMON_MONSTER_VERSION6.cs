using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SUMMON_MONSTER_VERSION6 : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private MobID mobID_0;

	private int int_2;

	private int int_3;

	private int int_4;

	private TargetParam targetParam_0;

	private int int_5;

	[LocalizedDisplayName("Dispear")]
	[LocalizedCategory("OperationParam")]
	public int Dispear
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
	public int FromVersion => 6;

	[LocalizedDisplayName("Life")]
	[LocalizedCategory("OperationParam")]
	public int Life
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

	[LocalizedDisplayName("MonsterID")]
	[LocalizedCategory("OperationParam")]
	public MobID MonsterID
	{
		[CompilerGenerated]
		get
		{
			return mobID_0;
		}
		[CompilerGenerated]
		set
		{
			mobID_0 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("MonsterNum")]
	public int MonsterNum
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937123));

	[Browsable(false)]
	public int OperID => 17;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("PathID")]
	public int PathID
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Range")]
	public int Range
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("UsePolicyTarget")]
	public int UsePolicyTarget
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

	public O_SUMMON_MONSTER_VERSION6()
	{
		MonsterID = new MobID();
		Range = 0;
		Life = 0;
		Dispear = 0;
		UsePolicyTarget = 0;
		PathID = 0;
		MonsterNum = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SUMMON_MONSTER_VERSION6 o_SUMMON_MONSTER_VERSION = new O_SUMMON_MONSTER_VERSION6();
		o_SUMMON_MONSTER_VERSION.MonsterID = MonsterID;
		o_SUMMON_MONSTER_VERSION.Range = Range;
		o_SUMMON_MONSTER_VERSION.Life = Life;
		o_SUMMON_MONSTER_VERSION.Dispear = Dispear;
		o_SUMMON_MONSTER_VERSION.UsePolicyTarget = UsePolicyTarget;
		o_SUMMON_MONSTER_VERSION.PathID = PathID;
		o_SUMMON_MONSTER_VERSION.MonsterNum = MonsterNum;
		o_SUMMON_MONSTER_VERSION.Target = Target.Clone() as TargetParam;
		return o_SUMMON_MONSTER_VERSION;
	}

	public void Read(BinaryReader br)
	{
		MonsterID = new MobID
		{
			Value = br.ReadUInt32()
		};
		Range = br.ReadInt32();
		Life = br.ReadInt32();
		Dispear = br.ReadInt32();
		UsePolicyTarget = br.ReadInt32();
		PathID = br.ReadInt32();
		MonsterNum = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!MonsterID.Value.ToString().Contains(str) && !Range.ToString().Contains(str) && !Life.ToString().Contains(str) && !Dispear.ToString().Contains(str) && !UsePolicyTarget.ToString().Contains(str) && !PathID.ToString().Contains(str) && !MonsterNum.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(MonsterID.Value);
		bw.Write(Range);
		bw.Write(Life);
		bw.Write(Dispear);
		bw.Write(UsePolicyTarget);
		bw.Write(PathID);
		bw.Write(MonsterNum);
		TargetStream.Save(bw, Target);
	}
}
