using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_BOSS_RUSH_AWARD : ICloneable, IOperation
{
	private byte[] byte_0 = new byte[3];

	private bool bool_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private TargetParam targetParam_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Active")]
	public bool Active
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	[Browsable(false)]
	public int FromVersion => 33;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ItemId_1")]
	public int ItemId_1
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

	[LocalizedDisplayName("ItemId_2")]
	[LocalizedCategory("OperationParam")]
	public int ItemId_2
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937576));

	[Browsable(false)]
	public int OperID => 65;

	[LocalizedDisplayName("Qnt_1")]
	[LocalizedCategory("OperationParam")]
	public int Qnt_1
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

	[LocalizedDisplayName("Qnt_2")]
	[LocalizedCategory("OperationParam")]
	public int Qnt_2
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("zvMax_X")]
	public float zvMax_X
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("zvMax_Y")]
	public float zvMax_Y
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	[LocalizedDisplayName("zvMax_Z")]
	[LocalizedCategory("OperationParam")]
	public float zvMax_Z
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("zvMin_X")]
	public float zvMin_X
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	[LocalizedDisplayName("zvMin_Y")]
	[LocalizedCategory("OperationParam")]
	public float zvMin_Y
	{
		[CompilerGenerated]
		get
		{
			return float_4;
		}
		[CompilerGenerated]
		set
		{
			float_4 = value;
		}
	}

	[LocalizedDisplayName("zvMin_Z")]
	[LocalizedCategory("OperationParam")]
	public float zvMin_Z
	{
		[CompilerGenerated]
		get
		{
			return float_5;
		}
		[CompilerGenerated]
		set
		{
			float_5 = value;
		}
	}

	public O_BOSS_RUSH_AWARD()
	{
		Active = false;
		byte_0 = new byte[3];
		ItemId_1 = 0;
		Qnt_1 = 0;
		ItemId_2 = 0;
		Qnt_2 = 0;
		zvMin_X = 0f;
		zvMin_Y = 0f;
		zvMin_Z = 0f;
		zvMax_X = 0f;
		zvMax_Y = 0f;
		zvMax_Z = 0f;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_BOSS_RUSH_AWARD o_BOSS_RUSH_AWARD = new O_BOSS_RUSH_AWARD();
		o_BOSS_RUSH_AWARD.Active = Active;
		o_BOSS_RUSH_AWARD.ItemId_1 = ItemId_1;
		o_BOSS_RUSH_AWARD.Qnt_1 = Qnt_1;
		o_BOSS_RUSH_AWARD.ItemId_2 = ItemId_2;
		o_BOSS_RUSH_AWARD.Qnt_2 = Qnt_2;
		o_BOSS_RUSH_AWARD.zvMin_X = zvMin_X;
		o_BOSS_RUSH_AWARD.zvMin_Y = zvMin_Y;
		o_BOSS_RUSH_AWARD.zvMin_Z = zvMin_Z;
		o_BOSS_RUSH_AWARD.zvMax_X = zvMax_X;
		o_BOSS_RUSH_AWARD.zvMax_Y = zvMax_Y;
		o_BOSS_RUSH_AWARD.zvMax_Z = zvMax_Z;
		o_BOSS_RUSH_AWARD.Target = Target.Clone() as TargetParam;
		return o_BOSS_RUSH_AWARD;
	}

	public void Read(BinaryReader br)
	{
		Active = br.ReadBoolean();
		byte_0 = br.ReadBytes(3);
		ItemId_1 = br.ReadInt32();
		Qnt_1 = br.ReadInt32();
		ItemId_2 = br.ReadInt32();
		Qnt_2 = br.ReadInt32();
		zvMin_X = br.ReadSingle();
		zvMin_Y = br.ReadSingle();
		zvMin_Z = br.ReadSingle();
		zvMax_X = br.ReadSingle();
		zvMax_Y = br.ReadSingle();
		zvMax_Z = br.ReadSingle();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Active.ToString().Contains(str) && !ItemId_1.ToString().Contains(str) && !ItemId_2.ToString().Contains(str) && !Qnt_2.ToString().Contains(str) && !zvMin_X.ToString().Contains(str) && !zvMin_Y.ToString().Contains(str) && !zvMin_Z.ToString().Contains(str) && !zvMax_X.ToString().Contains(str) && !zvMax_Y.ToString().Contains(str) && !zvMax_Z.ToString().Contains(str) && !Qnt_1.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Active);
		bw.Write(byte_0);
		bw.Write(ItemId_1);
		bw.Write(Qnt_1);
		bw.Write(ItemId_2);
		bw.Write(Qnt_2);
		bw.Write(zvMin_X);
		bw.Write(zvMin_Y);
		bw.Write(zvMin_Z);
		bw.Write(zvMax_X);
		bw.Write(zvMax_Y);
		bw.Write(zvMax_Z);
		TargetStream.Save(bw, Target);
	}
}
