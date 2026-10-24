using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_AUTO_BIND_CARRIER : ICloneable, IOperation
{
	private float float_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 28;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937564));

	[Browsable(false)]
	public int OperID => 40;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("range")]
	public float range
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

	public O_AUTO_BIND_CARRIER()
	{
		range = 0f;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_AUTO_BIND_CARRIER o_AUTO_BIND_CARRIER = new O_AUTO_BIND_CARRIER();
		o_AUTO_BIND_CARRIER.range = range;
		o_AUTO_BIND_CARRIER.Target = Target.Clone() as TargetParam;
		return o_AUTO_BIND_CARRIER;
	}

	public void Read(BinaryReader br)
	{
		range = br.ReadSingle();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (range.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(range);
		TargetStream.Save(bw, Target);
	}
}
