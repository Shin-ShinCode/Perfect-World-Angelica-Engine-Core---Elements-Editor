using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_FAKE_MONSTER_POS : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	private int int_0;

	private float float_0;

	[Browsable(false)]
	public int FromVersion => 40;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937806));

	[Browsable(false)]
	public int OperID => 100;

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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("MoveType")]
	public int MoveType
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Radius")]
	public float Radius
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

	public O_FAKE_MONSTER_POS()
	{
		MoveType = 0;
		Radius = 0f;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_FAKE_MONSTER_POS o_FAKE_MONSTER_POS = new O_FAKE_MONSTER_POS();
		o_FAKE_MONSTER_POS.MoveType = MoveType;
		o_FAKE_MONSTER_POS.Radius = Radius;
		o_FAKE_MONSTER_POS.Target = Target.Clone() as TargetParam;
		return o_FAKE_MONSTER_POS;
	}

	public void Read(BinaryReader br)
	{
		MoveType = br.ReadInt32();
		Radius = br.ReadSingle();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!MoveType.ToString().Contains(str) && !Radius.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(MoveType);
		bw.Write(Radius);
		TargetStream.Save(bw, Target);
	}
}
