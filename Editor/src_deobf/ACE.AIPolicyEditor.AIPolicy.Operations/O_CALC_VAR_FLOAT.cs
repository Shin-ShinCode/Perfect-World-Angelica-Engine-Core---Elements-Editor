using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CALC_VAR_FLOAT : ICloneable, IOperation
{
	private int int_0;

	private VarType varType_0;

	private float float_0;

	private VarType varType_1;

	private OperatorType operatorType_0;

	private float float_1;

	private VarType varType_2;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 100;

	[Browsable(false)]
	public int OperID => 200;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937614));

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Dst")]
	public int Dst
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
	[LocalizedDisplayName("DstType")]
	public VarType DstType
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

	[LocalizedDisplayName("Src1")]
	[LocalizedCategory("OperationParam")]
	public float Src1
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

	[LocalizedDisplayName("Src1Type")]
	[LocalizedCategory("OperationParam")]
	public VarType Src1Type
	{
		[CompilerGenerated]
		get
		{
			return varType_1;
		}
		[CompilerGenerated]
		set
		{
			varType_1 = value;
		}
	}

	[LocalizedDisplayName("Op")]
	[LocalizedCategory("OperationParam")]
	public OperatorType Op
	{
		[CompilerGenerated]
		get
		{
			return operatorType_0;
		}
		[CompilerGenerated]
		set
		{
			operatorType_0 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Src2")]
	public float Src2
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

	[LocalizedDisplayName("Src2Type")]
	[LocalizedCategory("OperationParam")]
	public VarType Src2Type
	{
		[CompilerGenerated]
		get
		{
			return varType_2;
		}
		[CompilerGenerated]
		set
		{
			varType_2 = value;
		}
	}

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

	public O_CALC_VAR_FLOAT()
	{
		Dst = 0;
		DstType = VarType.GlobalVarID;
		Src1 = 0f;
		Src1Type = VarType.GlobalVarID;
		Op = OperatorType.Add;
		Src2 = 0f;
		Src2Type = VarType.GlobalVarID;
		Target = new TargetParam();
	}

	public void Read(BinaryReader br)
	{
		Dst = br.ReadInt32();
		DstType = (VarType)br.ReadInt32();
		Src1 = br.ReadSingle();
		Src1Type = (VarType)br.ReadInt32();
		Op = (OperatorType)br.ReadInt32();
		Src2 = br.ReadSingle();
		Src2Type = (VarType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Dst);
		bw.Write(Convert.ToUInt32(DstType));
		bw.Write(Src1);
		bw.Write(Convert.ToUInt32(Src1Type));
		bw.Write(Convert.ToUInt32(Op));
		bw.Write(Src2);
		bw.Write(Convert.ToUInt32(Src2Type));
		TargetStream.Save(bw, Target);
	}

	public bool Search(string str)
	{
		if (!Dst.ToString().Contains(str) && !DstType.ToString().Contains(str) && !Src1.ToString().Contains(str) && !Src1Type.ToString().Contains(str) && !Op.ToString().Contains(str) && !Src2.ToString().Contains(str) && !Src2Type.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public object Clone()
	{
		O_CALC_VAR_FLOAT o_CALC_VAR_FLOAT = new O_CALC_VAR_FLOAT();
		o_CALC_VAR_FLOAT.Dst = Dst;
		o_CALC_VAR_FLOAT.DstType = DstType;
		o_CALC_VAR_FLOAT.Src1 = Src1;
		o_CALC_VAR_FLOAT.Src1Type = Src1Type;
		o_CALC_VAR_FLOAT.Op = Op;
		o_CALC_VAR_FLOAT.Src2 = Src2;
		o_CALC_VAR_FLOAT.Src2Type = Src2Type;
		o_CALC_VAR_FLOAT.Target = Target.Clone() as TargetParam;
		return o_CALC_VAR_FLOAT;
	}
}
