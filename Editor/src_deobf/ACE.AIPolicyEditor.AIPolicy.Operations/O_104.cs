using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_104 : ICloneable, IOperation
{
	private TargetParam targetParam_0;

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

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16;

	private int int_17;

	private int int_18;

	private int int_19;

	private int int_20;

	private int int_21;

	private int int_22;

	private int int_23;

	private int int_24;

	private int int_25;

	[Browsable(false)]
	public int FromVersion => 40;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938081));

	[Browsable(false)]
	public int OperID => 104;

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
	[LocalizedDisplayName("Value1")]
	public int Value1
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
	[LocalizedDisplayName("Value10")]
	public int Value10
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

	[LocalizedDisplayName("Value11")]
	[LocalizedCategory("OperationParam")]
	public int Value11
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

	[LocalizedDisplayName("Value12")]
	[LocalizedCategory("OperationParam")]
	public int Value12
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
	[LocalizedDisplayName("Value13")]
	public int Value13
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

	[LocalizedDisplayName("Value14")]
	[LocalizedCategory("OperationParam")]
	public int Value14
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

	[LocalizedDisplayName("Value15")]
	[LocalizedCategory("OperationParam")]
	public int Value15
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value16")]
	public int Value16
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
	[LocalizedDisplayName("Value17")]
	public int Value17
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
	[LocalizedDisplayName("Value18")]
	public int Value18
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value19")]
	public int Value19
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value2")]
	public int Value2
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

	[LocalizedDisplayName("Value20")]
	[LocalizedCategory("OperationParam")]
	public int Value20
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
	[LocalizedDisplayName("Value21")]
	public int Value21
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
	[LocalizedDisplayName("Value22")]
	public int Value22
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
	[LocalizedDisplayName("Value23")]
	public int Value23
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
	[LocalizedDisplayName("Value24")]
	public int Value24
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
	[LocalizedDisplayName("Value25")]
	public int Value25
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value26")]
	public int Value26
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
	[LocalizedDisplayName("Value3")]
	public int Value3
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value4")]
	public int Value4
	{
		[CompilerGenerated]
		get
		{
			return int_20;
		}
		[CompilerGenerated]
		set
		{
			int_20 = value;
		}
	}

	[LocalizedDisplayName("Value5")]
	[LocalizedCategory("OperationParam")]
	public int Value5
	{
		[CompilerGenerated]
		get
		{
			return int_21;
		}
		[CompilerGenerated]
		set
		{
			int_21 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value6")]
	public int Value6
	{
		[CompilerGenerated]
		get
		{
			return int_22;
		}
		[CompilerGenerated]
		set
		{
			int_22 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value7")]
	public int Value7
	{
		[CompilerGenerated]
		get
		{
			return int_23;
		}
		[CompilerGenerated]
		set
		{
			int_23 = value;
		}
	}

	[LocalizedDisplayName("Value8")]
	[LocalizedCategory("OperationParam")]
	public int Value8
	{
		[CompilerGenerated]
		get
		{
			return int_24;
		}
		[CompilerGenerated]
		set
		{
			int_24 = value;
		}
	}

	[LocalizedDisplayName("Value9")]
	[LocalizedCategory("OperationParam")]
	public int Value9
	{
		[CompilerGenerated]
		get
		{
			return int_25;
		}
		[CompilerGenerated]
		set
		{
			int_25 = value;
		}
	}

	public O_104()
	{
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
		Value20 = 0;
		Value21 = 0;
		Value22 = 0;
		Value23 = 0;
		Value24 = 0;
		Value25 = 0;
		Value26 = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_104 o_ = new O_104();
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
		o_.Value20 = Value20;
		o_.Value21 = Value21;
		o_.Value22 = Value22;
		o_.Value23 = Value23;
		o_.Value24 = Value24;
		o_.Value25 = Value25;
		o_.Value26 = Value26;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
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
		Value20 = br.ReadInt32();
		Value21 = br.ReadInt32();
		Value22 = br.ReadInt32();
		Value23 = br.ReadInt32();
		Value24 = br.ReadInt32();
		Value25 = br.ReadInt32();
		Value26 = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Value1.ToString().Contains(str) && !Value2.ToString().Contains(str) && !Value3.ToString().Contains(str) && !Value4.ToString().Contains(str) && !Value5.ToString().Contains(str) && !Value6.ToString().Contains(str) && !Value7.ToString().Contains(str) && !Value8.ToString().Contains(str) && !Value8.ToString().Contains(str) && !Value10.ToString().Contains(str) && !Value11.ToString().Contains(str) && !Value12.ToString().Contains(str) && !Value13.ToString().Contains(str) && !Value14.ToString().Contains(str) && !Value15.ToString().Contains(str) && !Value16.ToString().Contains(str) && !Value17.ToString().Contains(str) && !Value18.ToString().Contains(str) && !Value19.ToString().Contains(str) && !Value20.ToString().Contains(str) && !Value21.ToString().Contains(str) && !Value22.ToString().Contains(str) && !Value23.ToString().Contains(str) && !Value24.ToString().Contains(str) && !Value25.ToString().Contains(str) && !Value26.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
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
		bw.Write(Value20);
		bw.Write(Value21);
		bw.Write(Value22);
		bw.Write(Value23);
		bw.Write(Value24);
		bw.Write(Value25);
		bw.Write(Value26);
		TargetStream.Save(bw, Target);
	}
}
