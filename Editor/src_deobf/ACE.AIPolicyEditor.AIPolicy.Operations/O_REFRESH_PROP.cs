using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_REFRESH_PROP : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 100;

	[Browsable(false)]
	public int OperID => 205;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937916));

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Unused")]
	public int Unused
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

	public O_REFRESH_PROP()
	{
		Unused = 0;
		Target = new TargetParam();
	}

	public void Read(BinaryReader br)
	{
		Unused = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Unused);
		TargetStream.Save(bw, Target);
	}

	public bool Search(string str)
	{
		if (Unused.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public object Clone()
	{
		O_REFRESH_PROP o_REFRESH_PROP = new O_REFRESH_PROP();
		o_REFRESH_PROP.Unused = Unused;
		o_REFRESH_PROP.Target = Target.Clone() as TargetParam;
		return o_REFRESH_PROP;
	}
}
