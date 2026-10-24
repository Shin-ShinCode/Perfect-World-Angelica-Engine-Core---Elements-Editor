using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CHILD_CARRIER_PARENT_MONSTER : ICloneable, IOperation
{
	private float float_0;

	private int int_0;

	private TargetParam targetParam_0;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("fRange")]
	public float fRange
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	[Browsable(false)]
	public int FromVersion => 33;

	[LocalizedDisplayName("iPos")]
	[LocalizedCategory("OperationParam")]
	public int iPos
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937699));

	[Browsable(false)]
	public int OperID => 58;

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

	public O_CHILD_CARRIER_PARENT_MONSTER()
	{
		fRange = 0f;
		iPos = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_CHILD_CARRIER_PARENT_MONSTER o_CHILD_CARRIER_PARENT_MONSTER = new O_CHILD_CARRIER_PARENT_MONSTER();
		o_CHILD_CARRIER_PARENT_MONSTER.fRange = fRange;
		o_CHILD_CARRIER_PARENT_MONSTER.iPos = iPos;
		o_CHILD_CARRIER_PARENT_MONSTER.Target = Target.Clone() as TargetParam;
		return o_CHILD_CARRIER_PARENT_MONSTER;
	}

	public void Read(BinaryReader br)
	{
		fRange = br.ReadSingle();
		iPos = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!fRange.ToString().Contains(str) && !iPos.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(fRange);
		bw.Write(iPos);
		TargetStream.Save(bw, Target);
	}
}
