using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SUMMON_MONSTER_2 : ICloneable, IOperation
{
	private SummoneeDisppearType summoneeDisppearType_0;

	private int int_0;

	private MobID mobID_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

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
	public int FromVersion => 20;

	[LocalizedDisplayName("Life")]
	[LocalizedCategory("OperationParam")]
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("MonsterIDType")]
	public int MonsterIDType
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

	[LocalizedDisplayName("MonsterNumType")]
	[LocalizedCategory("OperationParam")]
	public int MonsterNumType
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937141));

	[Browsable(false)]
	public int OperID => 24;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("PathID")]
	public int PathID
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("PathIDType")]
	public int PathIDType
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Range")]
	public int Range
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

	public O_SUMMON_MONSTER_2()
	{
		DispearCondition = SummoneeDisppearType.Never;
		MonsterID = new MobID();
		MonsterIDType = 0;
		Range = 0;
		Life = 0;
		PathID = 0;
		PathIDType = 0;
		MonsterNum = 0;
		MonsterNumType = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SUMMON_MONSTER_2 o_SUMMON_MONSTER_ = new O_SUMMON_MONSTER_2();
		o_SUMMON_MONSTER_.DispearCondition = DispearCondition;
		o_SUMMON_MONSTER_.MonsterID = MonsterID;
		o_SUMMON_MONSTER_.MonsterIDType = MonsterIDType;
		o_SUMMON_MONSTER_.Range = Range;
		o_SUMMON_MONSTER_.Life = Life;
		o_SUMMON_MONSTER_.PathID = PathID;
		o_SUMMON_MONSTER_.PathIDType = PathIDType;
		o_SUMMON_MONSTER_.MonsterNum = MonsterNum;
		o_SUMMON_MONSTER_.MonsterNumType = MonsterNumType;
		o_SUMMON_MONSTER_.Target = Target.Clone() as TargetParam;
		return o_SUMMON_MONSTER_;
	}

	public void Read(BinaryReader br)
	{
		DispearCondition = (SummoneeDisppearType)br.ReadInt32();
		MonsterID = new MobID
		{
			Value = br.ReadUInt32()
		};
		MonsterIDType = br.ReadInt32();
		Range = br.ReadInt32();
		Life = br.ReadInt32();
		PathID = br.ReadInt32();
		PathIDType = br.ReadInt32();
		MonsterNum = br.ReadInt32();
		MonsterNumType = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!DispearCondition.ToString().Contains(str) && !MonsterID.Value.ToString().Contains(str) && !MonsterIDType.ToString().Contains(str) && !Range.ToString().Contains(str) && !Life.ToString().Contains(str) && !PathID.ToString().Contains(str) && !PathIDType.ToString().Contains(str) && !MonsterNum.ToString().Contains(str) && !MonsterNumType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Convert.ToUInt32(DispearCondition));
		bw.Write(MonsterID.Value);
		bw.Write(MonsterIDType);
		bw.Write(Range);
		bw.Write(Life);
		bw.Write(PathID);
		bw.Write(PathIDType);
		bw.Write(MonsterNum);
		bw.Write(MonsterNumType);
		TargetStream.Save(bw, Target);
	}
}
