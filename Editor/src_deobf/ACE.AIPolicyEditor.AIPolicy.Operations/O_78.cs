using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_78 : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	private VarType varType_0;

	private int int_1;

	private VarType varType_1;

	private int int_2;

	private VarType varType_2;

	private int int_3;

	private VarType varType_3;

	private int int_4;

	private VarType varType_4;

	[Browsable(false)]
	public int FromVersion => 33;

	[LocalizedDisplayName("iTargetID")]
	[LocalizedCategory("OperationParam")]
	public int iTargetID
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938308));

	[Browsable(false)]
	public int OperID => 78;

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
	[LocalizedDisplayName("uTargetType")]
	public VarType uTargetType
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

	[LocalizedDisplayName("Value1")]
	[LocalizedCategory("OperationParam")]
	public int Value1
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

	[LocalizedDisplayName("Value1Type")]
	[LocalizedCategory("OperationParam")]
	public VarType Value1Type
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

	[LocalizedDisplayName("Value3")]
	[LocalizedCategory("OperationParam")]
	public int Value2
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value2Type")]
	public VarType Value2Type
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

	[LocalizedDisplayName("Value3")]
	[LocalizedCategory("OperationParam")]
	public int Value3
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	[LocalizedDisplayName("Value3Type")]
	[LocalizedCategory("OperationParam")]
	public VarType Value3Type
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value4")]
	public int Value4
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	[LocalizedDisplayName("Value4Type")]
	[LocalizedCategory("OperationParam")]
	public VarType Value4Type
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

	public O_78()
	{
		Value1 = 0;
		Value1Type = VarType.GlobalVarID;
		Value2 = 0;
		Value2Type = VarType.GlobalVarID;
		Value3 = 0;
		Value3Type = VarType.GlobalVarID;
		Value4 = 0;
		Value4Type = VarType.GlobalVarID;
		iTargetID = 0;
		uTargetType = VarType.GlobalVarID;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_78 o_ = new O_78();
		o_.Value1 = Value1;
		o_.Value1Type = Value1Type;
		o_.Value2 = Value2;
		o_.Value2Type = Value2Type;
		o_.Value3 = Value3;
		o_.Value3Type = Value3Type;
		o_.Value4 = Value4;
		o_.Value4Type = Value4Type;
		o_.iTargetID = iTargetID;
		o_.uTargetType = uTargetType;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		Value1 = br.ReadInt32();
		Value1Type = (VarType)br.ReadInt32();
		Value2 = br.ReadInt32();
		Value2Type = (VarType)br.ReadInt32();
		Value3 = br.ReadInt32();
		Value3Type = (VarType)br.ReadInt32();
		Value4 = br.ReadInt32();
		Value4Type = (VarType)br.ReadInt32();
		iTargetID = br.ReadInt32();
		uTargetType = (VarType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Value1.ToString().Contains(str) && !Value1Type.ToString().Contains(str) && !Value2.ToString().Contains(str) && !Value2Type.ToString().Contains(str) && !Value3.ToString().Contains(str) && !Value3Type.ToString().Contains(str) && !Value4.ToString().Contains(str) && !Value4Type.ToString().Contains(str) && !iTargetID.ToString().Contains(str) && !uTargetType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Value1);
		bw.Write(Convert.ToUInt32(Value1Type));
		bw.Write(Value2);
		bw.Write(Convert.ToUInt32(Value2Type));
		bw.Write(Value3);
		bw.Write(Convert.ToUInt32(Value3Type));
		bw.Write(Value4);
		bw.Write(Convert.ToUInt32(Value4Type));
		bw.Write(iTargetID);
		bw.Write(Convert.ToUInt32(uTargetType));
		TargetStream.Save(bw, Target);
	}
}
