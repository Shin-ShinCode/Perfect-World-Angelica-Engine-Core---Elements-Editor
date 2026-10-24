using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CLOSE_CHILD_MONSTER : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 33;

	[LocalizedDisplayName("iMonsterID")]
	[LocalizedCategory("OperationParam")]
	public int iMonsterID
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937727));

	[Browsable(false)]
	public int OperID => 59;

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

	public O_CLOSE_CHILD_MONSTER()
	{
		iMonsterID = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_CLOSE_CHILD_MONSTER o_CLOSE_CHILD_MONSTER = new O_CLOSE_CHILD_MONSTER();
		o_CLOSE_CHILD_MONSTER.iMonsterID = iMonsterID;
		o_CLOSE_CHILD_MONSTER.Target = Target.Clone() as TargetParam;
		return o_CLOSE_CHILD_MONSTER;
	}

	public void Read(BinaryReader br)
	{
		iMonsterID = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (iMonsterID.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iMonsterID);
		TargetStream.Save(bw, Target);
	}
}
