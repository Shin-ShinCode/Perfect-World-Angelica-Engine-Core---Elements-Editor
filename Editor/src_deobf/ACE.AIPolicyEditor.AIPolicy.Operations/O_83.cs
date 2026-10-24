using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_83 : ICloneable, IOperation
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private TargetParam targetParam_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	[Browsable(false)]
	public int FromVersion => 35;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Max_X")]
	public float Max_X
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
	[LocalizedDisplayName("Max_Y")]
	public float Max_Y
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Max_Z")]
	public float Max_Z
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
	[LocalizedDisplayName("Min_X")]
	public float Min_X
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

	[LocalizedDisplayName("Min_Y")]
	[LocalizedCategory("OperationParam")]
	public float Min_Y
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

	[LocalizedDisplayName("Min_Z")]
	[LocalizedCategory("OperationParam")]
	public float Min_Z
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

	[LocalizedDisplayName("MonsterID")]
	[LocalizedCategory("OperationParam")]
	public float MonsterID
	{
		[CompilerGenerated]
		get
		{
			return float_6;
		}
		[CompilerGenerated]
		set
		{
			float_6 = value;
		}
	}

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938358));

	[Browsable(false)]
	public int OperID => 83;

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

	[LocalizedDisplayName("Value10")]
	[LocalizedCategory("OperationParam")]
	public int Value10
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

	[LocalizedDisplayName("Value8")]
	[LocalizedCategory("OperationParam")]
	public int Value8
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
	[LocalizedDisplayName("Value9")]
	public int Value9
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Var")]
	public int Var
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

	public O_83()
	{
		Min_X = 0f;
		Min_Y = 0f;
		Min_Z = 0f;
		Max_X = 0f;
		Max_Y = 0f;
		Max_Z = 0f;
		MonsterID = 0f;
		Var = 0;
		Value8 = 0;
		Value9 = 0;
		Value10 = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_83 o_ = new O_83();
		o_.Min_X = Min_X;
		o_.Min_Y = Min_Y;
		o_.Min_Z = Min_Z;
		o_.Max_X = Max_X;
		o_.Max_Y = Max_Y;
		o_.Max_Z = Max_Z;
		o_.MonsterID = MonsterID;
		o_.Var = Var;
		o_.Value8 = Value8;
		o_.Value9 = Value9;
		o_.Value10 = Value10;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		Min_X = br.ReadSingle();
		Min_Y = br.ReadSingle();
		Min_Z = br.ReadSingle();
		Max_X = br.ReadSingle();
		Max_Y = br.ReadSingle();
		Max_Z = br.ReadSingle();
		MonsterID = br.ReadInt32();
		Var = br.ReadInt32();
		Value8 = br.ReadInt32();
		Value9 = br.ReadInt32();
		Value10 = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Min_X.ToString().Contains(str) && !Min_Y.ToString().Contains(str) && !Min_Z.ToString().Contains(str) && !Max_X.ToString().Contains(str) && !Max_Y.ToString().Contains(str) && !Max_Z.ToString().Contains(str) && !MonsterID.ToString().Contains(str) && !Var.ToString().Contains(str) && !Value8.ToString().Contains(str) && !Value9.ToString().Contains(str) && !Value10.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Min_X);
		bw.Write(Min_Y);
		bw.Write(Min_Z);
		bw.Write(Max_X);
		bw.Write(Max_Y);
		bw.Write(Max_Z);
		bw.Write(MonsterID);
		bw.Write(Var);
		bw.Write(Value8);
		bw.Write(Value9);
		bw.Write(Value10);
		TargetStream.Save(bw, Target);
	}
}
