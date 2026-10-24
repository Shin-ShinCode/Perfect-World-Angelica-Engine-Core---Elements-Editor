using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_70 : ICloneable, IOperation
{
	private float float_0;

	private TargetParam targetParam_0;

	[LocalizedDisplayName("Value1")]
	[LocalizedCategory("OperationParam")]
	public float fRadius
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

	[Browsable(false)]
	public int FromVersion => 33;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938278));

	[Browsable(false)]
	public int OperID => 70;

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

	public O_70()
	{
		fRadius = 0f;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_70 o_ = new O_70();
		o_.fRadius = fRadius;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		fRadius = br.ReadSingle();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (fRadius.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(fRadius);
		TargetStream.Save(bw, Target);
	}
}
