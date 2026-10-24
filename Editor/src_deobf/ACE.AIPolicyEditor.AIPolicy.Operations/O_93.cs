using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_93 : ICloneable, IOperation
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

	[Browsable(false)]
	public int FromVersion => 39;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938440));

	[Browsable(false)]
	public int OperID => 93;

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

	[LocalizedDisplayName("Value4")]
	[LocalizedCategory("OperationParam")]
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

	[LocalizedDisplayName("Value5")]
	[LocalizedCategory("OperationParam")]
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

	[LocalizedDisplayName("Value6")]
	[LocalizedCategory("OperationParam")]
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value7")]
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

	[LocalizedDisplayName("Value8")]
	[LocalizedCategory("OperationParam")]
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

	[LocalizedDisplayName("Value9")]
	[LocalizedCategory("OperationParam")]
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

	public O_93()
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
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_93 o_ = new O_93();
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
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Value1.ToString().Contains(str) && !Value2.ToString().Contains(str) && !Value3.ToString().Contains(str) && !Value4.ToString().Contains(str) && !Value5.ToString().Contains(str) && !Value6.ToString().Contains(str) && !Value7.ToString().Contains(str) && !Value8.ToString().Contains(str) && !Value8.ToString().Contains(str) && !Value10.ToString().Contains(str))
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
		TargetStream.Save(bw, Target);
	}
}
