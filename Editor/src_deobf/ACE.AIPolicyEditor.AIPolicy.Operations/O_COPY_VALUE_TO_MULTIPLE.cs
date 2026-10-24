using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_COPY_VALUE_TO_MULTIPLE : ICloneable, IOperation
{
	private VarType varType_0;

	private int int_0;

	private VarType varType_1;

	private int int_1;

	private VarType varType_2;

	private int int_2;

	private VarType varType_3;

	private int int_3;

	private VarType varType_4;

	private int int_4;

	private VarType varType_5;

	private int int_5;

	private VarType varType_6;

	private int int_6;

	private VarType varType_7;

	private int int_7;

	private VarType varType_8;

	private OperatorType operatorType_0;

	private int int_8;

	private VarType varType_9;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 39;

	[Browsable(false)]
	public int OperID => 99;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937729));

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("SourceVarType")]
	public VarType SourceVarType
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("DestinationVariable1")]
	public int DestinationVariable1
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
	[LocalizedDisplayName("DestinationVarType1")]
	public VarType DestinationVarType1
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

	[LocalizedDisplayName("DestinationVariable2")]
	[LocalizedCategory("OperationParam")]
	public int DestinationVariable2
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

	[LocalizedDisplayName("DestinationVarType2")]
	[LocalizedCategory("OperationParam")]
	public VarType DestinationVarType2
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

	[LocalizedDisplayName("DestinationVariable3")]
	[LocalizedCategory("OperationParam")]
	public int DestinationVariable3
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

	[LocalizedDisplayName("DestinationVarType3")]
	[LocalizedCategory("OperationParam")]
	public VarType DestinationVarType3
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
	[LocalizedDisplayName("DestinationVariable4")]
	public int DestinationVariable4
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("DestinationVarType4")]
	public VarType DestinationVarType4
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("DestinationVariable5")]
	public int DestinationVariable5
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

	[LocalizedDisplayName("DestinationVarType5")]
	[LocalizedCategory("OperationParam")]
	public VarType DestinationVarType5
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("DestinationVariable6")]
	public int DestinationVariable6
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	[LocalizedDisplayName("DestinationVarType6")]
	[LocalizedCategory("OperationParam")]
	public VarType DestinationVarType6
	{
		[CompilerGenerated]
		get
		{
			return varType_6;
		}
		[CompilerGenerated]
		set
		{
			varType_6 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("DestinationVariable7")]
	public int DestinationVariable7
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	[LocalizedDisplayName("DestinationVarType7")]
	[LocalizedCategory("OperationParam")]
	public VarType DestinationVarType7
	{
		[CompilerGenerated]
		get
		{
			return varType_7;
		}
		[CompilerGenerated]
		set
		{
			varType_7 = value;
		}
	}

	[LocalizedDisplayName("DestinationVariable8")]
	[LocalizedCategory("OperationParam")]
	public int DestinationVariable8
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	[LocalizedDisplayName("DestinationVarType8")]
	[LocalizedCategory("OperationParam")]
	public VarType DestinationVarType8
	{
		[CompilerGenerated]
		get
		{
			return varType_8;
		}
		[CompilerGenerated]
		set
		{
			varType_8 = value;
		}
	}

	[LocalizedDisplayName("OperatorType")]
	[LocalizedCategory("OperationParam")]
	public OperatorType OperatorType
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
	[LocalizedDisplayName("SourceVariable")]
	public int SourceVariable
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}

	[LocalizedDisplayName("AdditionalVarType")]
	[LocalizedCategory("OperationParam")]
	public VarType AdditionalVarType
	{
		[CompilerGenerated]
		get
		{
			return varType_9;
		}
		[CompilerGenerated]
		set
		{
			varType_9 = value;
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

	public O_COPY_VALUE_TO_MULTIPLE()
	{
		SourceVarType = VarType.GlobalVarID;
		DestinationVariable1 = 0;
		DestinationVariable2 = 0;
		DestinationVariable3 = 0;
		DestinationVariable4 = 0;
		DestinationVariable5 = 0;
		DestinationVariable6 = 0;
		DestinationVariable7 = 0;
		DestinationVariable8 = 0;
		OperatorType = OperatorType.Add;
		DestinationVarType1 = VarType.GlobalVarID;
		DestinationVarType2 = VarType.GlobalVarID;
		DestinationVarType3 = VarType.GlobalVarID;
		DestinationVarType4 = VarType.GlobalVarID;
		DestinationVarType5 = VarType.GlobalVarID;
		DestinationVarType6 = VarType.GlobalVarID;
		DestinationVarType7 = VarType.GlobalVarID;
		DestinationVarType8 = VarType.GlobalVarID;
		SourceVariable = 0;
		AdditionalVarType = VarType.GlobalVarID;
		Target = new TargetParam();
	}

	public void Read(BinaryReader br)
	{
		SourceVarType = (VarType)br.ReadInt32();
		DestinationVariable1 = br.ReadInt32();
		DestinationVariable2 = br.ReadInt32();
		DestinationVariable3 = br.ReadInt32();
		DestinationVariable4 = br.ReadInt32();
		DestinationVariable5 = br.ReadInt32();
		DestinationVariable6 = br.ReadInt32();
		DestinationVariable7 = br.ReadInt32();
		DestinationVariable8 = br.ReadInt32();
		OperatorType = (OperatorType)br.ReadInt32();
		DestinationVarType1 = (VarType)br.ReadInt32();
		DestinationVarType2 = (VarType)br.ReadInt32();
		DestinationVarType3 = (VarType)br.ReadInt32();
		DestinationVarType4 = (VarType)br.ReadInt32();
		DestinationVarType5 = (VarType)br.ReadInt32();
		DestinationVarType6 = (VarType)br.ReadInt32();
		DestinationVarType7 = (VarType)br.ReadInt32();
		DestinationVarType8 = (VarType)br.ReadInt32();
		SourceVariable = br.ReadInt32();
		AdditionalVarType = (VarType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Convert.ToUInt32(SourceVarType));
		bw.Write(DestinationVariable1);
		bw.Write(DestinationVariable2);
		bw.Write(DestinationVariable3);
		bw.Write(DestinationVariable4);
		bw.Write(DestinationVariable5);
		bw.Write(DestinationVariable6);
		bw.Write(DestinationVariable7);
		bw.Write(DestinationVariable8);
		bw.Write(Convert.ToUInt32(OperatorType));
		bw.Write(Convert.ToUInt32(DestinationVarType1));
		bw.Write(Convert.ToUInt32(DestinationVarType2));
		bw.Write(Convert.ToUInt32(DestinationVarType3));
		bw.Write(Convert.ToUInt32(DestinationVarType4));
		bw.Write(Convert.ToUInt32(DestinationVarType5));
		bw.Write(Convert.ToUInt32(DestinationVarType6));
		bw.Write(Convert.ToUInt32(DestinationVarType7));
		bw.Write(Convert.ToUInt32(DestinationVarType8));
		bw.Write(SourceVariable);
		bw.Write(Convert.ToUInt32(AdditionalVarType));
		TargetStream.Save(bw, Target);
	}

	public bool Search(string str)
	{
		if (!SourceVarType.ToString().Contains(str) && !DestinationVariable1.ToString().Contains(str) && !DestinationVariable2.ToString().Contains(str) && !DestinationVariable3.ToString().Contains(str) && !DestinationVariable4.ToString().Contains(str) && !DestinationVariable5.ToString().Contains(str) && !DestinationVariable6.ToString().Contains(str) && !DestinationVariable7.ToString().Contains(str) && !DestinationVariable8.ToString().Contains(str) && !OperatorType.ToString().Contains(str) && !DestinationVarType1.ToString().Contains(str) && !DestinationVarType2.ToString().Contains(str) && !DestinationVarType3.ToString().Contains(str) && !DestinationVarType4.ToString().Contains(str) && !DestinationVarType5.ToString().Contains(str) && !DestinationVarType6.ToString().Contains(str) && !DestinationVarType7.ToString().Contains(str) && !DestinationVarType8.ToString().Contains(str) && !SourceVariable.ToString().Contains(str) && !AdditionalVarType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public object Clone()
	{
		O_COPY_VALUE_TO_MULTIPLE o_COPY_VALUE_TO_MULTIPLE = new O_COPY_VALUE_TO_MULTIPLE();
		o_COPY_VALUE_TO_MULTIPLE.SourceVarType = SourceVarType;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVariable1 = DestinationVariable1;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVariable2 = DestinationVariable2;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVariable3 = DestinationVariable3;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVariable4 = DestinationVariable4;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVariable5 = DestinationVariable5;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVariable6 = DestinationVariable6;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVariable7 = DestinationVariable7;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVariable8 = DestinationVariable8;
		o_COPY_VALUE_TO_MULTIPLE.OperatorType = OperatorType;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVarType1 = DestinationVarType1;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVarType2 = DestinationVarType2;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVarType3 = DestinationVarType3;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVarType4 = DestinationVarType4;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVarType5 = DestinationVarType5;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVarType6 = DestinationVarType6;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVarType7 = DestinationVarType7;
		o_COPY_VALUE_TO_MULTIPLE.DestinationVarType8 = DestinationVarType8;
		o_COPY_VALUE_TO_MULTIPLE.SourceVariable = SourceVariable;
		o_COPY_VALUE_TO_MULTIPLE.AdditionalVarType = AdditionalVarType;
		o_COPY_VALUE_TO_MULTIPLE.Target = Target.Clone() as TargetParam;
		return o_COPY_VALUE_TO_MULTIPLE;
	}
}
