using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_80 : ICloneable, IOperation
{
	private int int_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private TargetParam targetParam_0;

	private int int_1;

	private VarType varType_0;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Const")]
	public int Const
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
	public int FromVersion => 35;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938320));

	[Browsable(false)]
	public int OperID => 80;

	[LocalizedDisplayName("posX")]
	[LocalizedCategory("OperationParam")]
	public float posX
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

	[LocalizedDisplayName("posY")]
	[LocalizedCategory("OperationParam")]
	public float posY
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("posZ")]
	public float posZ
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

	[LocalizedDisplayName("Var")]
	[LocalizedCategory("OperationParam")]
	public int Var
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

	[LocalizedDisplayName("VarType")]
	[LocalizedCategory("OperationParam")]
	public VarType VarType
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

	public O_80()
	{
		posX = 0f;
		posY = 0f;
		posZ = 0f;
		Const = 0;
		Var = 0;
		VarType = VarType.GlobalVarID;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_80 o_ = new O_80();
		o_.posX = posX;
		o_.posY = posY;
		o_.posZ = posZ;
		o_.Const = Const;
		o_.Var = Var;
		o_.VarType = VarType;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		posX = br.ReadSingle();
		posY = br.ReadSingle();
		posZ = br.ReadSingle();
		Const = br.ReadInt32();
		Var = br.ReadInt32();
		VarType = (VarType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!posX.ToString().Contains(str) && !posY.ToString().Contains(str) && !posZ.ToString().Contains(str) && !Const.ToString().Contains(str) && !Var.ToString().Contains(str) && !VarType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(posX);
		bw.Write(posY);
		bw.Write(posZ);
		bw.Write(Const);
		bw.Write(Var);
		bw.Write(Convert.ToUInt32(VarType));
		TargetStream.Save(bw, Target);
	}
}
