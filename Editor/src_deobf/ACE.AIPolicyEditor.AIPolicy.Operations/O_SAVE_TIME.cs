using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SAVE_TIME : ICloneable, IOperation
{
	private int int_0;

	private VarType varType_0;

	private TimeType timeType_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 28;

	[LocalizedDisplayName("iParamID")]
	[LocalizedCategory("OperationParam")]
	public int iParamID
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

	[LocalizedDisplayName("iParamIDType")]
	[LocalizedCategory("OperationParam")]
	public VarType iParamIDType
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
	[LocalizedDisplayName("iTimeType")]
	public TimeType iTimeType
	{
		[CompilerGenerated]
		get
		{
			return timeType_0;
		}
		[CompilerGenerated]
		set
		{
			timeType_0 = value;
		}
	}

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648936991));

	[Browsable(false)]
	public int OperID => 46;

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

	public O_SAVE_TIME()
	{
		iTimeType = TimeType.Year;
		iParamID = 0;
		iParamIDType = VarType.GlobalVarID;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SAVE_TIME o_SAVE_TIME = new O_SAVE_TIME();
		o_SAVE_TIME.iTimeType = iTimeType;
		o_SAVE_TIME.iParamID = iParamID;
		o_SAVE_TIME.iParamIDType = iParamIDType;
		o_SAVE_TIME.Target = Target.Clone() as TargetParam;
		return o_SAVE_TIME;
	}

	public void Read(BinaryReader br)
	{
		iTimeType = (TimeType)br.ReadInt32();
		iParamID = br.ReadInt32();
		iParamIDType = (VarType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!iTimeType.ToString().Contains(str) && !iParamID.ToString().Contains(str) && !iParamIDType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Convert.ToUInt32(iTimeType));
		bw.Write(iParamID);
		bw.Write(Convert.ToUInt32(iParamIDType));
		TargetStream.Save(bw, Target);
	}
}
