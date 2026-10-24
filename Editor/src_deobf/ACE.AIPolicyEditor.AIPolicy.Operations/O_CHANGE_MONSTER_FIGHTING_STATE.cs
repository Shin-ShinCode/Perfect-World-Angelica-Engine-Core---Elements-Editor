using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CHANGE_MONSTER_FIGHTING_STATE : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 30;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iChangeState")]
	public int iChangeState
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937686));

	[Browsable(false)]
	public int OperID => 56;

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

	public O_CHANGE_MONSTER_FIGHTING_STATE()
	{
		iChangeState = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_CHANGE_MONSTER_FIGHTING_STATE o_CHANGE_MONSTER_FIGHTING_STATE = new O_CHANGE_MONSTER_FIGHTING_STATE();
		o_CHANGE_MONSTER_FIGHTING_STATE.iChangeState = iChangeState;
		o_CHANGE_MONSTER_FIGHTING_STATE.Target = Target.Clone() as TargetParam;
		return o_CHANGE_MONSTER_FIGHTING_STATE;
	}

	public void Read(BinaryReader br)
	{
		iChangeState = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (iChangeState.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iChangeState);
		TargetStream.Save(bw, Target);
	}
}
