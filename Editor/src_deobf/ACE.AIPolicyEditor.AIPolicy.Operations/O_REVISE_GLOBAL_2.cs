using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_REVISE_GLOBAL_2 : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	private int int_0;

	private int int_1;

	[Browsable(false)]
	public int FromVersion => 33;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937938));

	[Browsable(false)]
	public int OperID => 69;

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

	[LocalizedDisplayName("Value1")]
	[LocalizedCategory("OperationParam")]
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
	[LocalizedDisplayName("Value2")]
	public int Value2
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

	public O_REVISE_GLOBAL_2()
	{
		Value1 = 0;
		Value2 = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_REVISE_GLOBAL_2 o_REVISE_GLOBAL_ = new O_REVISE_GLOBAL_2();
		o_REVISE_GLOBAL_.Value1 = Value1;
		o_REVISE_GLOBAL_.Value2 = Value2;
		o_REVISE_GLOBAL_.Target = Target.Clone() as TargetParam;
		return o_REVISE_GLOBAL_;
	}

	public void Read(BinaryReader br)
	{
		Value1 = br.ReadInt32();
		Value2 = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Value1.ToString().Contains(str) && !Value2.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Value1);
		bw.Write(Value2);
		TargetStream.Save(bw, Target);
	}
}
