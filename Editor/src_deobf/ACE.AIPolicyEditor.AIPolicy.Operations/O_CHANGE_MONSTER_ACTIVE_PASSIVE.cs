using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CHANGE_MONSTER_ACTIVE_PASSIVE : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 30;

	[LocalizedDisplayName("iChoose")]
	[LocalizedCategory("OperationParam")]
	public int iChoose
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937658));

	[Browsable(false)]
	public int OperID => 57;

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

	public O_CHANGE_MONSTER_ACTIVE_PASSIVE()
	{
		iChoose = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_CHANGE_MONSTER_ACTIVE_PASSIVE o_CHANGE_MONSTER_ACTIVE_PASSIVE = new O_CHANGE_MONSTER_ACTIVE_PASSIVE();
		o_CHANGE_MONSTER_ACTIVE_PASSIVE.iChoose = iChoose;
		o_CHANGE_MONSTER_ACTIVE_PASSIVE.Target = Target.Clone() as TargetParam;
		return o_CHANGE_MONSTER_ACTIVE_PASSIVE;
	}

	public void Read(BinaryReader br)
	{
		iChoose = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (iChoose.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iChoose);
		TargetStream.Save(bw, Target);
	}
}
