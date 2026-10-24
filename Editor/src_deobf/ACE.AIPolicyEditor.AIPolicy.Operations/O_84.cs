using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_84 : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 35;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938360));

	[Browsable(false)]
	public int OperID => 84;

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

	public O_84()
	{
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_84 o_ = new O_84();
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		TargetStream.Save(bw, Target);
	}
}
