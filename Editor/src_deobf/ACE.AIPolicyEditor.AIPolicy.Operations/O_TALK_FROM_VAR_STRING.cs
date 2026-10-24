using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_TALK_FROM_VAR_STRING : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 100;

	[Browsable(false)]
	public int OperID => 203;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937153));

	[LocalizedDisplayName("iKey")]
	[LocalizedCategory("OperationParam")]
	public int iKey
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

	public O_TALK_FROM_VAR_STRING()
	{
		iKey = 0;
		Target = new TargetParam();
	}

	public void Read(BinaryReader br)
	{
		iKey = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iKey);
		TargetStream.Save(bw, Target);
	}

	public bool Search(string str)
	{
		if (iKey.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public object Clone()
	{
		O_TALK_FROM_VAR_STRING o_TALK_FROM_VAR_STRING = new O_TALK_FROM_VAR_STRING();
		o_TALK_FROM_VAR_STRING.iKey = iKey;
		o_TALK_FROM_VAR_STRING.Target = Target.Clone() as TargetParam;
		return o_TALK_FROM_VAR_STRING;
	}
}
