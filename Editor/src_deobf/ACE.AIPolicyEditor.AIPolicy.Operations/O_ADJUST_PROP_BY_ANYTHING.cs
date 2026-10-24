using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_ADJUST_PROP_BY_ANYTHING : ICloneable, IOperation
{
	private enumPolicyPropType enumPolicyPropType_0;

	private int int_0;

	private VarType varType_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 100;

	[Browsable(false)]
	public int OperID => 204;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937536));

	[LocalizedDisplayName("Type")]
	[LocalizedCategory("OperationParam")]
	public enumPolicyPropType Type
	{
		[CompilerGenerated]
		get
		{
			return enumPolicyPropType_0;
		}
		[CompilerGenerated]
		set
		{
			enumPolicyPropType_0 = value;
		}
	}

	[LocalizedDisplayName("Value")]
	[LocalizedCategory("OperationParam")]
	public int Value
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

	[LocalizedDisplayName("ValueType")]
	[LocalizedCategory("OperationParam")]
	public VarType ValueType
	{
		[CompilerGenerated]
		get
		{
			return varType_0;
		}
		[CompilerGenerated]
		set
		{
			varType_0 = value;
		}
	}

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

	public O_ADJUST_PROP_BY_ANYTHING()
	{
		Type = enumPolicyPropType.PROP_TYPE_MAX_HP;
		Value = 0;
		ValueType = VarType.GlobalVarID;
		Target = new TargetParam();
	}

	public void Read(BinaryReader br)
	{
		Type = (enumPolicyPropType)br.ReadInt32();
		Value = br.ReadInt32();
		ValueType = (VarType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Convert.ToUInt32(Type));
		bw.Write(Value);
		bw.Write(Convert.ToUInt32(ValueType));
		TargetStream.Save(bw, Target);
	}

	public bool Search(string str)
	{
		if (!Type.ToString().Contains(str) && !Value.ToString().Contains(str) && !ValueType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public object Clone()
	{
		O_ADJUST_PROP_BY_ANYTHING o_ADJUST_PROP_BY_ANYTHING = new O_ADJUST_PROP_BY_ANYTHING();
		o_ADJUST_PROP_BY_ANYTHING.Type = Type;
		o_ADJUST_PROP_BY_ANYTHING.Value = Value;
		o_ADJUST_PROP_BY_ANYTHING.ValueType = ValueType;
		o_ADJUST_PROP_BY_ANYTHING.Target = Target.Clone() as TargetParam;
		return o_ADJUST_PROP_BY_ANYTHING;
	}
}
