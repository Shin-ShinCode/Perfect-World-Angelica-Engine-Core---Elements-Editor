using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM : ICloneable, IOperation
{
	private float float_0;

	private int int_0;

	private TargetParam targetParam_0;

	private VarType varType_0;

	private VarType varType_1;

	[LocalizedDisplayName("fRadiusValue")]
	[LocalizedCategory("OperationParam")]
	public float fRadiusValue
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

	[Browsable(false)]
	public int FromVersion => 28;

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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937975));

	[Browsable(false)]
	public int OperID => 42;

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

	[LocalizedDisplayName("uRadiusType")]
	[LocalizedCategory("OperationParam")]
	public VarType uRadiusType
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
	[LocalizedDisplayName("uTargetType")]
	public VarType uTargetType
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

	public O_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM()
	{
		fRadiusValue = 0f;
		uRadiusType = VarType.GlobalVarID;
		iTargetID = 0;
		uTargetType = VarType.GlobalVarID;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM o_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM = new O_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM();
		o_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM.fRadiusValue = fRadiusValue;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM.uRadiusType = uRadiusType;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM.iTargetID = iTargetID;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM.uTargetType = uTargetType;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM.Target = Target.Clone() as TargetParam;
		return o_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM;
	}

	public void Read(BinaryReader br)
	{
		fRadiusValue = br.ReadSingle();
		uRadiusType = (VarType)br.ReadUInt32();
		iTargetID = br.ReadInt32();
		uTargetType = (VarType)br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!fRadiusValue.ToString().Contains(str) && !uRadiusType.ToString().Contains(str) && !iTargetID.ToString().Contains(str) && !uTargetType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(fRadiusValue);
		bw.Write(Convert.ToUInt32(uRadiusType));
		bw.Write(iTargetID);
		bw.Write(Convert.ToUInt32(uTargetType));
		TargetStream.Save(bw, Target);
	}
}
