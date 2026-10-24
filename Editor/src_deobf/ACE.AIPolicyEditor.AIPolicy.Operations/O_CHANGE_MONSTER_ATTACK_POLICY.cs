using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CHANGE_MONSTER_ATTACK_POLICY : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 33;

	[LocalizedDisplayName("iChangeState")]
	[LocalizedCategory("OperationParam")]
	public int iAttackPolicyID
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937676));

	[Browsable(false)]
	public int OperID => 61;

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

	public O_CHANGE_MONSTER_ATTACK_POLICY()
	{
		iAttackPolicyID = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_CHANGE_MONSTER_ATTACK_POLICY o_CHANGE_MONSTER_ATTACK_POLICY = new O_CHANGE_MONSTER_ATTACK_POLICY();
		o_CHANGE_MONSTER_ATTACK_POLICY.iAttackPolicyID = iAttackPolicyID;
		o_CHANGE_MONSTER_ATTACK_POLICY.Target = Target.Clone() as TargetParam;
		return o_CHANGE_MONSTER_ATTACK_POLICY;
	}

	public void Read(BinaryReader br)
	{
		iAttackPolicyID = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (iAttackPolicyID.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iAttackPolicyID);
		TargetStream.Save(bw, Target);
	}
}
