using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CALC_VAR_MULTI : ICloneable, IOperation
{
	private int int_0;

	private VarType varType_0;

	private VarTypeConst varTypeConst_0;

	private float float_0;

	private VarType varType_1;

	private OperatorType operatorType_0;

	private VarTypeConst varTypeConst_1;

	private float float_1;

	private VarType varType_2;

	private OperatorType operatorType_1;

	private VarTypeConst varTypeConst_2;

	private float float_2;

	private VarType varType_3;

	private OperatorType operatorType_2;

	private VarTypeConst varTypeConst_3;

	private float float_3;

	private VarType varType_4;

	private OperatorType operatorType_3;

	private VarTypeConst varTypeConst_4;

	private float float_4;

	private VarType varType_5;

	private OperatorType operatorType_4;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 100;

	[Browsable(false)]
	public int OperID => 201;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937617));

	[LocalizedCategory("CalcDestParam")]
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

	[LocalizedDisplayName("DstType")]
	[LocalizedCategory("CalcDestParam")]
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

	[LocalizedDisplayName("Src1VarTypeConst")]
	[LocalizedCategory("CalcParam1")]
	public VarTypeConst Src1VarTypeConst
	{
		[CompilerGenerated]
		get
		{
			return varTypeConst_0;
		}
		[CompilerGenerated]
		set
		{
			varTypeConst_0 = value;
		}
	}

	[LocalizedCategory("CalcParam1")]
	[LocalizedDisplayName("Src1")]
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
	[LocalizedCategory("CalcParam1")]
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

	[LocalizedDisplayName("Op1")]
	[LocalizedCategory("CalcParam1")]
	public OperatorType Op1
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

	[LocalizedCategory("CalcParam2")]
	[LocalizedDisplayName("Src2VarTypeConst")]
	public VarTypeConst Src2VarTypeConst
	{
		[CompilerGenerated]
		get
		{
			return varTypeConst_1;
		}
		[CompilerGenerated]
		set
		{
			varTypeConst_1 = value;
		}
	}

	[LocalizedDisplayName("Src2")]
	[LocalizedCategory("CalcParam2")]
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
	[LocalizedCategory("CalcParam2")]
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

	[LocalizedCategory("CalcParam2")]
	[LocalizedDisplayName("Op2")]
	public OperatorType Op2
	{
		[CompilerGenerated]
		get
		{
			return operatorType_1;
		}
		[CompilerGenerated]
		set
		{
			operatorType_1 = value;
		}
	}

	[LocalizedCategory("CalcParam3")]
	[LocalizedDisplayName("Src3VarTypeConst")]
	public VarTypeConst Src3VarTypeConst
	{
		[CompilerGenerated]
		get
		{
			return varTypeConst_2;
		}
		[CompilerGenerated]
		set
		{
			varTypeConst_2 = value;
		}
	}

	[LocalizedDisplayName("Src3")]
	[LocalizedCategory("CalcParam3")]
	public float Src3
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	[LocalizedDisplayName("Src3Type")]
	[LocalizedCategory("CalcParam3")]
	public VarType Src3Type
	{
		[CompilerGenerated]
		get
		{
			return varType_3;
		}
		[CompilerGenerated]
		set
		{
			varType_3 = value;
		}
	}

	[LocalizedCategory("CalcParam3")]
	[LocalizedDisplayName("Op3")]
	public OperatorType Op3
	{
		[CompilerGenerated]
		get
		{
			return operatorType_2;
		}
		[CompilerGenerated]
		set
		{
			operatorType_2 = value;
		}
	}

	[LocalizedCategory("CalcParam4")]
	[LocalizedDisplayName("Src4VarTypeConst")]
	public VarTypeConst Src4VarTypeConst
	{
		[CompilerGenerated]
		get
		{
			return varTypeConst_3;
		}
		[CompilerGenerated]
		set
		{
			varTypeConst_3 = value;
		}
	}

	[LocalizedDisplayName("Src4")]
	[LocalizedCategory("CalcParam4")]
	public float Src4
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	[LocalizedCategory("CalcParam4")]
	[LocalizedDisplayName("Src4Type")]
	public VarType Src4Type
	{
		[CompilerGenerated]
		get
		{
			return varType_4;
		}
		[CompilerGenerated]
		set
		{
			varType_4 = value;
		}
	}

	[LocalizedCategory("CalcParam4")]
	[LocalizedDisplayName("Op4")]
	public OperatorType Op4
	{
		[CompilerGenerated]
		get
		{
			return operatorType_3;
		}
		[CompilerGenerated]
		set
		{
			operatorType_3 = value;
		}
	}

	[LocalizedCategory("CalcParam5")]
	[LocalizedDisplayName("Src5VarTypeConst")]
	public VarTypeConst Src5VarTypeConst
	{
		[CompilerGenerated]
		get
		{
			return varTypeConst_4;
		}
		[CompilerGenerated]
		set
		{
			varTypeConst_4 = value;
		}
	}

	[LocalizedCategory("CalcParam5")]
	[LocalizedDisplayName("Src5")]
	public float Src5
	{
		[CompilerGenerated]
		get
		{
			return float_4;
		}
		[CompilerGenerated]
		set
		{
			float_4 = value;
		}
	}

	[LocalizedCategory("CalcParam5")]
	[LocalizedDisplayName("Src5Type")]
	public VarType Src5Type
	{
		[CompilerGenerated]
		get
		{
			return varType_5;
		}
		[CompilerGenerated]
		set
		{
			varType_5 = value;
		}
	}

	[LocalizedDisplayName("Op5")]
	[LocalizedCategory("CalcParam5")]
	public OperatorType Op5
	{
		[CompilerGenerated]
		get
		{
			return operatorType_4;
		}
		[CompilerGenerated]
		set
		{
			operatorType_4 = value;
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

	public O_CALC_VAR_MULTI()
	{
		Dst = 0;
		DstType = VarType.GlobalVarID;
		Src1VarTypeConst = VarTypeConst.NoCalc;
		Src1 = 0f;
		Src1Type = VarType.Const;
		Op1 = OperatorType.Add;
		Src2VarTypeConst = VarTypeConst.NoCalc;
		Src2 = 0f;
		Src2Type = VarType.Const;
		Op2 = OperatorType.Add;
		Src3VarTypeConst = VarTypeConst.NoCalc;
		Src3 = 0f;
		Src3Type = VarType.Const;
		Op3 = OperatorType.Add;
		Src4VarTypeConst = VarTypeConst.NoCalc;
		Src4 = 0f;
		Src4Type = VarType.Const;
		Op4 = OperatorType.Add;
		Src5VarTypeConst = VarTypeConst.NoCalc;
		Src5 = 0f;
		Src5Type = VarType.Const;
		Op5 = OperatorType.Add;
		Target = new TargetParam();
	}

	public void Read(BinaryReader br)
	{
		Dst = br.ReadInt32();
		DstType = (VarType)br.ReadInt32();
		Src1VarTypeConst = (VarTypeConst)br.ReadInt32();
		Src1 = br.ReadSingle();
		Src1Type = (VarType)br.ReadInt32();
		Op1 = (OperatorType)br.ReadInt32();
		Src2VarTypeConst = (VarTypeConst)br.ReadInt32();
		Src2 = br.ReadSingle();
		Src2Type = (VarType)br.ReadInt32();
		Op2 = (OperatorType)br.ReadInt32();
		Src3VarTypeConst = (VarTypeConst)br.ReadInt32();
		Src3 = br.ReadSingle();
		Src3Type = (VarType)br.ReadInt32();
		Op3 = (OperatorType)br.ReadInt32();
		Src4VarTypeConst = (VarTypeConst)br.ReadInt32();
		Src4 = br.ReadSingle();
		Src4Type = (VarType)br.ReadInt32();
		Op4 = (OperatorType)br.ReadInt32();
		Src5VarTypeConst = (VarTypeConst)br.ReadInt32();
		Src5 = br.ReadSingle();
		Src5Type = (VarType)br.ReadInt32();
		Op5 = (OperatorType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Dst);
		bw.Write(Convert.ToUInt32(DstType));
		bw.Write(Convert.ToUInt32(Src1VarTypeConst));
		bw.Write(Src1);
		bw.Write(Convert.ToUInt32(Src1Type));
		bw.Write(Convert.ToUInt32(Op1));
		bw.Write(Convert.ToUInt32(Src2VarTypeConst));
		bw.Write(Src2);
		bw.Write(Convert.ToUInt32(Src2Type));
		bw.Write(Convert.ToUInt32(Op2));
		bw.Write(Convert.ToUInt32(Src3VarTypeConst));
		bw.Write(Src3);
		bw.Write(Convert.ToUInt32(Src3Type));
		bw.Write(Convert.ToUInt32(Op3));
		bw.Write(Convert.ToUInt32(Src4VarTypeConst));
		bw.Write(Src4);
		bw.Write(Convert.ToUInt32(Src4Type));
		bw.Write(Convert.ToUInt32(Op4));
		bw.Write(Convert.ToUInt32(Src5VarTypeConst));
		bw.Write(Src5);
		bw.Write(Convert.ToUInt32(Src5Type));
		bw.Write(Convert.ToUInt32(Op5));
		TargetStream.Save(bw, Target);
	}

	public bool Search(string str)
	{
		if (!Dst.ToString().Contains(str) && !DstType.ToString().Contains(str) && !Src1VarTypeConst.ToString().Contains(str) && !Src1.ToString().Contains(str) && !Src1Type.ToString().Contains(str) && !Op1.ToString().Contains(str) && !Src2VarTypeConst.ToString().Contains(str) && !Src2.ToString().Contains(str) && !Src2Type.ToString().Contains(str) && !Op2.ToString().Contains(str) && !Src3VarTypeConst.ToString().Contains(str) && !Src3.ToString().Contains(str) && !Src3Type.ToString().Contains(str) && !Op3.ToString().Contains(str) && !Src4VarTypeConst.ToString().Contains(str) && !Src4.ToString().Contains(str) && !Src4Type.ToString().Contains(str) && !Op4.ToString().Contains(str) && !Src5VarTypeConst.ToString().Contains(str) && !Src5.ToString().Contains(str) && !Src5Type.ToString().Contains(str) && !Op5.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public object Clone()
	{
		O_CALC_VAR_MULTI o_CALC_VAR_MULTI = new O_CALC_VAR_MULTI();
		o_CALC_VAR_MULTI.Dst = Dst;
		o_CALC_VAR_MULTI.DstType = DstType;
		o_CALC_VAR_MULTI.Src1VarTypeConst = Src1VarTypeConst;
		o_CALC_VAR_MULTI.Src1 = Src1;
		o_CALC_VAR_MULTI.Src1Type = Src1Type;
		o_CALC_VAR_MULTI.Op1 = Op1;
		o_CALC_VAR_MULTI.Src2VarTypeConst = Src2VarTypeConst;
		o_CALC_VAR_MULTI.Src2 = Src2;
		o_CALC_VAR_MULTI.Src2Type = Src2Type;
		o_CALC_VAR_MULTI.Op2 = Op2;
		o_CALC_VAR_MULTI.Src3VarTypeConst = Src3VarTypeConst;
		o_CALC_VAR_MULTI.Src3 = Src3;
		o_CALC_VAR_MULTI.Src3Type = Src3Type;
		o_CALC_VAR_MULTI.Op3 = Op3;
		o_CALC_VAR_MULTI.Src4VarTypeConst = Src4VarTypeConst;
		o_CALC_VAR_MULTI.Src4 = Src4;
		o_CALC_VAR_MULTI.Src4Type = Src4Type;
		o_CALC_VAR_MULTI.Op4 = Op4;
		o_CALC_VAR_MULTI.Src5VarTypeConst = Src5VarTypeConst;
		o_CALC_VAR_MULTI.Src5 = Src5;
		o_CALC_VAR_MULTI.Src5Type = Src5Type;
		o_CALC_VAR_MULTI.Op5 = Op5;
		o_CALC_VAR_MULTI.Target = Target.Clone() as TargetParam;
		return o_CALC_VAR_MULTI;
	}
}
