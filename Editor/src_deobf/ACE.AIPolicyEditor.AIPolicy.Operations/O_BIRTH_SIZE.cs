using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_BIRTH_SIZE : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	private float float_0;

	private VarType varType_0;

	private float float_1;

	[Browsable(false)]
	public int FromVersion => 33;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937574));

	[Browsable(false)]
	public int OperID => 68;

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

	[LocalizedDisplayName("Value1")]
	[LocalizedCategory("OperationParam")]
	public float Value1
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value1Type")]
	public VarType Value1Type
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

	[LocalizedDisplayName("Value3")]
	[LocalizedCategory("OperationParam")]
	public float Value3
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	public O_BIRTH_SIZE()
	{
		Value1 = 0f;
		Value1Type = VarType.GlobalVarID;
		Value3 = 0f;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_BIRTH_SIZE o_BIRTH_SIZE = new O_BIRTH_SIZE();
		o_BIRTH_SIZE.Value1 = Value1;
		o_BIRTH_SIZE.Value1Type = Value1Type;
		o_BIRTH_SIZE.Value3 = Value3;
		o_BIRTH_SIZE.Target = Target.Clone() as TargetParam;
		return o_BIRTH_SIZE;
	}

	public void Read(BinaryReader br)
	{
		Value1 = br.ReadSingle();
		Value1Type = (VarType)br.ReadInt32();
		Value3 = br.ReadSingle();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Value1.ToString().Contains(str) && !Value1Type.ToString().Contains(str) && !Value3.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Value1);
		bw.Write(Convert.ToUInt32(Value1Type));
		bw.Write(Value3);
		TargetStream.Save(bw, Target);
	}
}
