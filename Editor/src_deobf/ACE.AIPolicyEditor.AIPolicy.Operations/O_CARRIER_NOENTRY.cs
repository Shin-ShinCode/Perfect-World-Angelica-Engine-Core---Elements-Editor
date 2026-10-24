using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CARRIER_NOENTRY : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 30;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iOpen")]
	public int iOpen
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937646));

	[Browsable(false)]
	public int OperID => 52;

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

	public O_CARRIER_NOENTRY()
	{
		iOpen = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_CARRIER_NOENTRY o_CARRIER_NOENTRY = new O_CARRIER_NOENTRY();
		o_CARRIER_NOENTRY.iOpen = iOpen;
		o_CARRIER_NOENTRY.Target = Target.Clone() as TargetParam;
		return o_CARRIER_NOENTRY;
	}

	public void Read(BinaryReader br)
	{
		iOpen = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (iOpen.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iOpen);
		TargetStream.Save(bw, Target);
	}
}
