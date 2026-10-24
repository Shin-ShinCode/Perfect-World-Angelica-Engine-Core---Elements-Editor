using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SET_HISTORY : ICloneable, IOperation
{
	private int int_0;

	private bool bool_0;

	private TargetParam targetParam_0;

	private int int_1;

	[Browsable(false)]
	public int FromVersion => 14;

	[LocalizedDisplayName("ID")]
	[LocalizedCategory("OperationParam")]
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

	[LocalizedDisplayName("IsHistoryValue")]
	[LocalizedCategory("OperationParam")]
	public bool IsHistoryValue
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937033));

	[Browsable(false)]
	public int OperID => 21;

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

	public O_SET_HISTORY()
	{
		ID = 0;
		Value = 0;
		IsHistoryValue = false;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SET_HISTORY o_SET_HISTORY = new O_SET_HISTORY();
		o_SET_HISTORY.ID = ID;
		o_SET_HISTORY.Value = Value;
		o_SET_HISTORY.IsHistoryValue = IsHistoryValue;
		o_SET_HISTORY.Target = Target.Clone() as TargetParam;
		return o_SET_HISTORY;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadInt32();
		Value = br.ReadInt32();
		IsHistoryValue = br.ReadBoolean();
		br.ReadBytes(3);
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ID.ToString().Contains(str) && !Value.ToString().Contains(str) && !IsHistoryValue.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID);
		bw.Write(Value);
		bw.Write(IsHistoryValue);
		bw.Write(new byte[3]);
		TargetStream.Save(bw, Target);
	}
}
