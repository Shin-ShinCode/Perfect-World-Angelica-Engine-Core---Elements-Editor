using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_ACTIVE_TRIGGER : ICloneable, IOperation
{
	private uint uint_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 1;

	[LocalizedDisplayName("ID")]
	[LocalizedCategory("OperationParam")]
	public uint ID
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937507));

	[Browsable(false)]
	public int OperID => 6;

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

	public O_ACTIVE_TRIGGER()
	{
		ID = 0u;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_ACTIVE_TRIGGER o_ACTIVE_TRIGGER = new O_ACTIVE_TRIGGER();
		o_ACTIVE_TRIGGER.ID = ID;
		o_ACTIVE_TRIGGER.Target = Target.Clone() as TargetParam;
		return o_ACTIVE_TRIGGER;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (ID.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID);
		TargetStream.Save(bw, Target);
	}
}
