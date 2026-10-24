using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_98 : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	private int int_0;

	[Browsable(false)]
	public int FromVersion => 39;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938490));

	[Browsable(false)]
	public int OperID => 98;

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

	public O_98()
	{
		Value1 = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_98 o_ = new O_98();
		o_.Value1 = Value1;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		Value1 = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (Value1.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Value1);
		TargetStream.Save(bw, Target);
	}
}
