using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_114 : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

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

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16;

	private int int_17;

	private int int_18;

	private int int_19;

	[Browsable(false)]
	public int FromVersion => 40;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ID")]
	public int ID
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938259));

	[Browsable(false)]
	public int OperID => 114;

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

	[LocalizedDisplayName("Value1")]
	[LocalizedCategory("OperationParam")]
	public int Value1
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
	[LocalizedDisplayName("Value2")]
	public int Value2
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

	[LocalizedDisplayName("Value3")]
	[LocalizedCategory("OperationParam")]
	public int Value3
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
	[LocalizedDisplayName("Value4")]
	public int Value4
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
	[LocalizedDisplayName("Value5")]
	public int Value5
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
	[LocalizedDisplayName("Value6")]
	public int Value6
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

	[LocalizedDisplayName("Value7")]
	[LocalizedCategory("OperationParam")]
	public int Value7
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value8")]
	public int Value8
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value9")]
	public int Value9
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

	[LocalizedDisplayName("Value10")]
	[LocalizedCategory("OperationParam")]
	public int Value10
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

	[LocalizedDisplayName("Value11")]
	[LocalizedCategory("OperationParam")]
	public int Value11
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value12")]
	public int Value12
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

	[LocalizedDisplayName("Value13")]
	[LocalizedCategory("OperationParam")]
	public int Value13
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
	[LocalizedDisplayName("Value14")]
	public int Value14
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value15")]
	public int Value15
	{
		[CompilerGenerated]
		get
		{
			return int_15;
		}
		[CompilerGenerated]
		set
		{
			int_15 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value16")]
	public int Value16
	{
		[CompilerGenerated]
		get
		{
			return int_16;
		}
		[CompilerGenerated]
		set
		{
			int_16 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value17")]
	public int Value17
	{
		[CompilerGenerated]
		get
		{
			return int_17;
		}
		[CompilerGenerated]
		set
		{
			int_17 = value;
		}
	}

	[LocalizedDisplayName("Value18")]
	[LocalizedCategory("OperationParam")]
	public int Value18
	{
		[CompilerGenerated]
		get
		{
			return int_18;
		}
		[CompilerGenerated]
		set
		{
			int_18 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value19")]
	public int Value19
	{
		[CompilerGenerated]
		get
		{
			return int_19;
		}
		[CompilerGenerated]
		set
		{
			int_19 = value;
		}
	}

	public O_114()
	{
		ID = 0;
		Value1 = 0;
		Value2 = 0;
		Value3 = 0;
		Value4 = 0;
		Value5 = 0;
		Value6 = 0;
		Value7 = 0;
		Value8 = 0;
		Value9 = 0;
		Value10 = 0;
		Value11 = 0;
		Value12 = 0;
		Value13 = 0;
		Value14 = 0;
		Value15 = 0;
		Value16 = 0;
		Value17 = 0;
		Value18 = 0;
		Value19 = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_114 o_ = new O_114();
		o_.ID = ID;
		o_.Value1 = Value1;
		o_.Value2 = Value2;
		o_.Value3 = Value3;
		o_.Value4 = Value4;
		o_.Value5 = Value5;
		o_.Value6 = Value6;
		o_.Value7 = Value7;
		o_.Value8 = Value8;
		o_.Value9 = Value9;
		o_.Value10 = Value10;
		o_.Value11 = Value11;
		o_.Value12 = Value12;
		o_.Value13 = Value13;
		o_.Value14 = Value14;
		o_.Value15 = Value15;
		o_.Value16 = Value16;
		o_.Value17 = Value17;
		o_.Value18 = Value18;
		o_.Value19 = Value19;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadInt32();
		Value1 = br.ReadInt32();
		Value2 = br.ReadInt32();
		Value3 = br.ReadInt32();
		Value4 = br.ReadInt32();
		Value5 = br.ReadInt32();
		Value6 = br.ReadInt32();
		Value7 = br.ReadInt32();
		Value8 = br.ReadInt32();
		Value9 = br.ReadInt32();
		Value10 = br.ReadInt32();
		Value11 = br.ReadInt32();
		Value12 = br.ReadInt32();
		Value13 = br.ReadInt32();
		Value14 = br.ReadInt32();
		Value15 = br.ReadInt32();
		Value16 = br.ReadInt32();
		Value17 = br.ReadInt32();
		Value18 = br.ReadInt32();
		Value19 = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ID.ToString().Contains(str) && !Value1.ToString().Contains(str) && !Value2.ToString().Contains(str) && !Value3.ToString().Contains(str) && !Value4.ToString().Contains(str) && !Value5.ToString().Contains(str) && !Value6.ToString().Contains(str) && !Value7.ToString().Contains(str) && !Value8.ToString().Contains(str) && !Value9.ToString().Contains(str) && !Value10.ToString().Contains(str) && !Value11.ToString().Contains(str) && !Value12.ToString().Contains(str) && !Value13.ToString().Contains(str) && !Value14.ToString().Contains(str) && !Value15.ToString().Contains(str) && !Value16.ToString().Contains(str) && !Value17.ToString().Contains(str) && !Value18.ToString().Contains(str))
		{
			return Value19.ToString().Contains(str);
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID);
		bw.Write(Value1);
		bw.Write(Value2);
		bw.Write(Value3);
		bw.Write(Value4);
		bw.Write(Value5);
		bw.Write(Value6);
		bw.Write(Value7);
		bw.Write(Value8);
		bw.Write(Value9);
		bw.Write(Value10);
		bw.Write(Value11);
		bw.Write(Value12);
		bw.Write(Value13);
		bw.Write(Value14);
		bw.Write(Value15);
		bw.Write(Value16);
		bw.Write(Value17);
		bw.Write(Value18);
		bw.Write(Value19);
		TargetStream.Save(bw, Target);
	}
}
