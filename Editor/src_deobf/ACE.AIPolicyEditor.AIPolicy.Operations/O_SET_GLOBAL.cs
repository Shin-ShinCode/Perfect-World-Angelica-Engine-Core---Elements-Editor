using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SET_GLOBAL : ICloneable, IOperation
{
	private int int_0;

	private bool bool_0;

	private TargetParam targetParam_0;

	private int int_1;

	[Browsable(false)]
	public int FromVersion => 7;

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

	[LocalizedDisplayName("IsValue")]
	[LocalizedCategory("OperationParam")]
	public bool IsValue
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648936993));

	[Browsable(false)]
	public int OperID => 15;

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

	public O_SET_GLOBAL()
	{
		ID = 0;
		Value = 0;
		IsValue = false;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SET_GLOBAL o_SET_GLOBAL = new O_SET_GLOBAL();
		o_SET_GLOBAL.ID = ID;
		o_SET_GLOBAL.Value = Value;
		o_SET_GLOBAL.IsValue = IsValue;
		o_SET_GLOBAL.Target = Target.Clone() as TargetParam;
		return o_SET_GLOBAL;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadInt32();
		Value = br.ReadInt32();
		IsValue = br.ReadBoolean();
		br.ReadBytes(3);
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ID.ToString().Contains(str) && !Value.ToString().Contains(str) && !IsValue.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID);
		bw.Write(Value);
		bw.Write(IsValue);
		bw.Write(new byte[3]);
		TargetStream.Save(bw, Target);
	}
}
