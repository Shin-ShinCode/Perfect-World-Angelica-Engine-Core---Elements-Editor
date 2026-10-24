using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_RESET_HATE_LIST : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 1;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937927));

	[Browsable(false)]
	public int OperID => 3;

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

	public O_RESET_HATE_LIST()
	{
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_RESET_HATE_LIST o_RESET_HATE_LIST = new O_RESET_HATE_LIST();
		o_RESET_HATE_LIST.Target = Target.Clone() as TargetParam;
		return o_RESET_HATE_LIST;
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
