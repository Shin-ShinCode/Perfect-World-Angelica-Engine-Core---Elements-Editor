using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SUMMON_MINE_VERSION23 : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private MineID mineID_0;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private TargetParam targetParam_0;

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

	[LocalizedDisplayName("LifeType")]
	[LocalizedCategory("OperationParam")]
	public int LifeType
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

	[LocalizedDisplayName("MineID")]
	[LocalizedCategory("OperationParam")]
	public MineID MineID
	{
		[CompilerGenerated]
		get
		{
			return mineID_0;
		}
		[CompilerGenerated]
		set
		{
			mineID_0 = value;
		}
	}

	[LocalizedDisplayName("MineIDType")]
	[LocalizedCategory("OperationParam")]
	public int MineIDType
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

	[LocalizedDisplayName("MineNum")]
	[LocalizedCategory("OperationParam")]
	public int MineNum
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
	[LocalizedDisplayName("MineNumType")]
	public int MineNumType
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937113));

	[Browsable(false)]
	public int OperID => 29;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Range")]
	public int Range
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

	public O_SUMMON_MINE_VERSION23()
	{
		LifeType = 0;
		MineID = new MineID();
		MineIDType = 0;
		Range = 0;
		Life = 0;
		MineNum = 0;
		MineNumType = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SUMMON_MINE_VERSION23 o_SUMMON_MINE_VERSION = new O_SUMMON_MINE_VERSION23();
		o_SUMMON_MINE_VERSION.LifeType = LifeType;
		o_SUMMON_MINE_VERSION.MineID = MineID;
		o_SUMMON_MINE_VERSION.MineIDType = MineIDType;
		o_SUMMON_MINE_VERSION.Range = Range;
		o_SUMMON_MINE_VERSION.Life = Life;
		o_SUMMON_MINE_VERSION.MineNum = MineNum;
		o_SUMMON_MINE_VERSION.MineNumType = MineNumType;
		o_SUMMON_MINE_VERSION.Target = Target.Clone() as TargetParam;
		return o_SUMMON_MINE_VERSION;
	}

	public void Read(BinaryReader br)
	{
		LifeType = br.ReadInt32();
		MineID = new MineID
		{
			Value = br.ReadUInt32()
		};
		MineIDType = br.ReadInt32();
		Range = br.ReadInt32();
		Life = br.ReadInt32();
		MineNum = br.ReadInt32();
		MineNumType = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!LifeType.ToString().Contains(str) && !MineID.Value.ToString().Contains(str) && !MineIDType.ToString().Contains(str) && !Range.ToString().Contains(str) && !Life.ToString().Contains(str) && !MineNum.ToString().Contains(str) && !MineNumType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(LifeType);
		bw.Write(MineID.Value);
		bw.Write(MineIDType);
		bw.Write(Range);
		bw.Write(Life);
		bw.Write(MineNum);
		bw.Write(MineNumType);
		TargetStream.Save(bw, Target);
	}
}
