using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_75 : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	private int int_0;

	[Browsable(false)]
	public int FromVersion => 33;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938280));

	[Browsable(false)]
	public int OperID => 75;

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

	[LocalizedDisplayName("uID")]
	[LocalizedCategory("OperationParam")]
	public int uID
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

	public O_75()
	{
		uID = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_75 o_ = new O_75();
		o_.uID = uID;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		uID = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (uID.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(uID);
		TargetStream.Save(bw, Target);
	}
}
