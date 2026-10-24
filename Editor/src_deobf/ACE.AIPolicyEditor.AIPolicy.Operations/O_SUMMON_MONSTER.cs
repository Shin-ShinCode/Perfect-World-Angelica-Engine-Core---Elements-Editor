using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SUMMON_MONSTER : ICloneable, IOperation
{
	private SummoneeDisppearType summoneeDisppearType_0;

	private int int_0;

	private MobID mobID_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private TargetParam targetParam_0;

	[LocalizedDisplayName("DispearCondition")]
	[LocalizedCategory("OperationParam")]
	public SummoneeDisppearType DispearCondition
	{
		[CompilerGenerated]
		get
		{
			return summoneeDisppearType_0;
		}
		[CompilerGenerated]
		set
		{
			summoneeDisppearType_0 = value;
		}
	}

	[Browsable(false)]
	public int FromVersion => 7;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Life")]
	public int Life
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
	[LocalizedDisplayName("MonsterID")]
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

	[LocalizedDisplayName("MonsterNum")]
	[LocalizedCategory("OperationParam")]
	public int MonsterNum
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
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	[LocalizedDisplayName("Range")]
	[LocalizedCategory("OperationParam")]
	public int Range
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

	public O_SUMMON_MONSTER()
	{
		MonsterID = new MobID();
		Range = 0;
		Life = 0;
		DispearCondition = SummoneeDisppearType.Never;
		PathID = 0;
		MonsterNum = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SUMMON_MONSTER o_SUMMON_MONSTER = new O_SUMMON_MONSTER();
		o_SUMMON_MONSTER.MonsterID = MonsterID;
		o_SUMMON_MONSTER.Range = Range;
		o_SUMMON_MONSTER.Life = Life;
		o_SUMMON_MONSTER.DispearCondition = DispearCondition;
		o_SUMMON_MONSTER.PathID = PathID;
		o_SUMMON_MONSTER.MonsterNum = MonsterNum;
		o_SUMMON_MONSTER.Target = Target.Clone() as TargetParam;
		return o_SUMMON_MONSTER;
	}

	public void Read(BinaryReader br)
	{
		MonsterID = new MobID
		{
			Value = br.ReadUInt32()
		};
		Range = br.ReadInt32();
		Life = br.ReadInt32();
		DispearCondition = (SummoneeDisppearType)br.ReadInt32();
		PathID = br.ReadInt32();
		MonsterNum = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!MonsterID.Value.ToString().Contains(str) && !Range.ToString().Contains(str) && !Life.ToString().Contains(str) && !DispearCondition.ToString().Contains(str) && !PathID.ToString().Contains(str) && !MonsterNum.ToString().Contains(str))
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
		bw.Write(Convert.ToUInt32(DispearCondition));
		bw.Write(PathID);
		bw.Write(MonsterNum);
		TargetStream.Save(bw, Target);
	}
}
