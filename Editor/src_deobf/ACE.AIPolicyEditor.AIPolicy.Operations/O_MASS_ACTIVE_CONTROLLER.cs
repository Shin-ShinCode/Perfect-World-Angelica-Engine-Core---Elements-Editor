using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_MASS_ACTIVE_CONTROLLER : ICloneable, IOperation
{
	private byte[] byte_0 = new byte[3];

	private bool bool_0;

	private int int_0;

	private int int_1;

	private VarType varType_0;

	private VarType varType_1;

	private int int_2;

	private VarType varType_2;

	private int int_3;

	private VarType varType_3;

	private int int_4;

	private VarType varType_4;

	private int int_5;

	private VarType varType_5;

	private int int_6;

	private VarType varType_6;

	private int int_7;

	private VarType varType_7;

	private int int_8;

	private VarType varType_8;

	private int int_9;

	private VarType varType_9;

	private TargetParam targetParam_0;

	[LocalizedDisplayName("bStop")]
	[LocalizedCategory("OperationParam")]
	public bool bStop
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
	public int FromVersion => 33;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ID1")]
	public int ID1
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

	[LocalizedDisplayName("ID10")]
	[LocalizedCategory("OperationParam")]
	public int ID10
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

	[LocalizedDisplayName("ID10Type")]
	[LocalizedCategory("OperationParam")]
	public VarType ID10Type
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

	[LocalizedDisplayName("ID1Type")]
	[LocalizedCategory("OperationParam")]
	public VarType ID1Type
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ID2")]
	public int ID2
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

	[LocalizedDisplayName("ID2Type")]
	[LocalizedCategory("OperationParam")]
	public VarType ID2Type
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

	[LocalizedDisplayName("ID3")]
	[LocalizedCategory("OperationParam")]
	public int ID3
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

	[LocalizedDisplayName("ID3Type")]
	[LocalizedCategory("OperationParam")]
	public VarType ID3Type
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

	[LocalizedDisplayName("ID4")]
	[LocalizedCategory("OperationParam")]
	public int ID4
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ID4Type")]
	public VarType ID4Type
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
	[LocalizedDisplayName("ID5")]
	public int ID5
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

	[LocalizedDisplayName("ID5Type")]
	[LocalizedCategory("OperationParam")]
	public VarType ID5Type
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

	[LocalizedDisplayName("ID6")]
	[LocalizedCategory("OperationParam")]
	public int ID6
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ID6Type")]
	public VarType ID6Type
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

	[LocalizedDisplayName("ID7")]
	[LocalizedCategory("OperationParam")]
	public int ID7
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ID7Type")]
	public VarType ID7Type
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

	[LocalizedDisplayName("ID8")]
	[LocalizedCategory("OperationParam")]
	public int ID8
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ID8Type")]
	public VarType ID8Type
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

	[LocalizedDisplayName("ID9")]
	[LocalizedCategory("OperationParam")]
	public int ID9
	{
		[CompilerGenerated]
		get
		{
			return int_9;
		}
		[CompilerGenerated]
		set
		{
			int_9 = value;
		}
	}

	[LocalizedDisplayName("ID9Type")]
	[LocalizedCategory("OperationParam")]
	public VarType ID9Type
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937876));

	[Browsable(false)]
	public int OperID => 64;

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

	public O_MASS_ACTIVE_CONTROLLER()
	{
		bStop = false;
		byte_0 = new byte[3];
		ID1 = 0;
		ID1Type = VarType.Const;
		ID2 = 0;
		ID2Type = VarType.Const;
		ID3 = 0;
		ID3Type = VarType.Const;
		ID4 = 0;
		ID4Type = VarType.Const;
		ID5 = 0;
		ID5Type = VarType.Const;
		ID6 = 0;
		ID6Type = VarType.Const;
		ID7 = 0;
		ID7Type = VarType.Const;
		ID8 = 0;
		ID8Type = VarType.Const;
		ID9 = 0;
		ID9Type = VarType.Const;
		ID10 = 0;
		ID10Type = VarType.Const;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_MASS_ACTIVE_CONTROLLER o_MASS_ACTIVE_CONTROLLER = new O_MASS_ACTIVE_CONTROLLER();
		o_MASS_ACTIVE_CONTROLLER.bStop = bStop;
		o_MASS_ACTIVE_CONTROLLER.Target = Target.Clone() as TargetParam;
		o_MASS_ACTIVE_CONTROLLER.ID1 = ID1;
		o_MASS_ACTIVE_CONTROLLER.ID1Type = ID1Type;
		o_MASS_ACTIVE_CONTROLLER.ID2 = ID2;
		o_MASS_ACTIVE_CONTROLLER.ID2Type = ID2Type;
		o_MASS_ACTIVE_CONTROLLER.ID3 = ID3;
		o_MASS_ACTIVE_CONTROLLER.ID3Type = ID3Type;
		o_MASS_ACTIVE_CONTROLLER.ID4 = ID4;
		o_MASS_ACTIVE_CONTROLLER.ID4Type = ID4Type;
		o_MASS_ACTIVE_CONTROLLER.ID5 = ID5;
		o_MASS_ACTIVE_CONTROLLER.ID5Type = ID5Type;
		o_MASS_ACTIVE_CONTROLLER.ID6 = ID6;
		o_MASS_ACTIVE_CONTROLLER.ID6Type = ID6Type;
		o_MASS_ACTIVE_CONTROLLER.ID7 = ID7;
		o_MASS_ACTIVE_CONTROLLER.ID7Type = ID7Type;
		o_MASS_ACTIVE_CONTROLLER.ID8 = ID8;
		o_MASS_ACTIVE_CONTROLLER.ID8Type = ID8Type;
		o_MASS_ACTIVE_CONTROLLER.ID9 = ID9;
		o_MASS_ACTIVE_CONTROLLER.ID9Type = ID9Type;
		o_MASS_ACTIVE_CONTROLLER.ID10 = ID10;
		o_MASS_ACTIVE_CONTROLLER.ID10Type = ID10Type;
		return o_MASS_ACTIVE_CONTROLLER;
	}

	public void Read(BinaryReader br)
	{
		bStop = br.ReadBoolean();
		byte_0 = br.ReadBytes(3);
		ID1 = br.ReadInt32();
		ID1Type = (VarType)br.ReadUInt32();
		ID2 = br.ReadInt32();
		ID2Type = (VarType)br.ReadUInt32();
		ID3 = br.ReadInt32();
		ID3Type = (VarType)br.ReadUInt32();
		ID4 = br.ReadInt32();
		ID4Type = (VarType)br.ReadUInt32();
		ID5 = br.ReadInt32();
		ID5Type = (VarType)br.ReadUInt32();
		ID6 = br.ReadInt32();
		ID6Type = (VarType)br.ReadUInt32();
		ID7 = br.ReadInt32();
		ID7Type = (VarType)br.ReadUInt32();
		ID8 = br.ReadInt32();
		ID8Type = (VarType)br.ReadUInt32();
		ID9 = br.ReadInt32();
		ID9Type = (VarType)br.ReadUInt32();
		ID10 = br.ReadInt32();
		ID10Type = (VarType)br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!bStop.ToString().Contains(str) && !ID1.ToString().Contains(str) && !ID2.ToString().Contains(str) && !ID3.ToString().Contains(str) && !ID4.ToString().Contains(str) && !ID5.ToString().Contains(str) && !ID6.ToString().Contains(str) && !ID7.ToString().Contains(str) && !ID8.ToString().Contains(str) && !ID9.ToString().Contains(str) && !ID10.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(bStop);
		bw.Write(byte_0);
		bw.Write(ID1);
		bw.Write(Convert.ToUInt32(ID1Type));
		bw.Write(ID2);
		bw.Write(Convert.ToUInt32(ID2Type));
		bw.Write(ID3);
		bw.Write(Convert.ToUInt32(ID3Type));
		bw.Write(ID4);
		bw.Write(Convert.ToUInt32(ID4Type));
		bw.Write(ID5);
		bw.Write(Convert.ToUInt32(ID5Type));
		bw.Write(ID6);
		bw.Write(Convert.ToUInt32(ID6Type));
		bw.Write(ID7);
		bw.Write(Convert.ToUInt32(ID7Type));
		bw.Write(ID8);
		bw.Write(Convert.ToUInt32(ID8Type));
		bw.Write(ID9);
		bw.Write(Convert.ToUInt32(ID9Type));
		bw.Write(ID10);
		bw.Write(Convert.ToUInt32(ID10Type));
		TargetStream.Save(bw, Target);
	}
}
