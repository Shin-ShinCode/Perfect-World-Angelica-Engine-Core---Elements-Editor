using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_REVISE_HISTORY : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	private int int_1;

	[Browsable(false)]
	public int FromVersion => 14;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ID")]
	public int ID
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937956));

	[Browsable(false)]
	public int OperID => 20;

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

	[LocalizedDisplayName("Value")]
	[LocalizedCategory("OperationParam")]
	public int Value
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public O_REVISE_HISTORY()
	{
		ID = 0;
		Value = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_REVISE_HISTORY o_REVISE_HISTORY = new O_REVISE_HISTORY();
		o_REVISE_HISTORY.ID = ID;
		o_REVISE_HISTORY.Value = Value;
		o_REVISE_HISTORY.Target = Target.Clone() as TargetParam;
		return o_REVISE_HISTORY;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadInt32();
		Value = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ID.ToString().Contains(str) && !Value.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID);
		bw.Write(Value);
		TargetStream.Save(bw, Target);
	}
}
