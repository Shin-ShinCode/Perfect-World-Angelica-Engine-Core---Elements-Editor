using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_111 : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	private int int_1;

	private int int_2;

	private float float_0;

	private int int_3;

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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938226));

	[Browsable(false)]
	public int OperID => 111;

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
	[LocalizedDisplayName("Value1")]
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value3")]
	public float Value3
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
	[LocalizedDisplayName("Value4")]
	public int Value4
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

	public O_111()
	{
		ID = 0;
		Value1 = 0;
		Value2 = 0;
		Value3 = 0f;
		Value4 = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_111 o_ = new O_111();
		o_.ID = ID;
		o_.Value1 = Value1;
		o_.Value2 = Value2;
		o_.Value3 = Value3;
		o_.Value4 = Value4;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadInt32();
		Value1 = br.ReadInt32();
		Value2 = br.ReadInt32();
		Value3 = br.ReadSingle();
		Value4 = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Value1.ToString().Contains(str) && !Value2.ToString().Contains(str) && !Value3.ToString().Contains(str) && !Value4.ToString().Contains(str))
		{
			return false;
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
		TargetStream.Save(bw, Target);
	}
}
