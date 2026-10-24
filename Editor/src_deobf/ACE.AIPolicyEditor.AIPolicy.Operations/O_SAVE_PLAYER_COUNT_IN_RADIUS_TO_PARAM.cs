using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM : ICloneable, IOperation
{
	private uint uint_0;

	private float float_0;

	private TargetParam targetParam_0;

	private uint uint_1;

	private int int_0;

	[Browsable(false)]
	public int FromVersion => 23;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648936963));

	[Browsable(false)]
	public int OperID => 34;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("RadiusType")]
	public uint RadiusType
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	[LocalizedDisplayName("RadiusValue")]
	[LocalizedCategory("OperationParam")]
	public float RadiusValue
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
	[LocalizedDisplayName("TargetType")]
	public uint Target_Type
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	[LocalizedDisplayName("TargetID")]
	[LocalizedCategory("OperationParam")]
	public int TargetID
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

	public O_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM()
	{
		RadiusValue = 0f;
		RadiusType = 0u;
		TargetID = 0;
		Target_Type = 0u;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM o_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM = new O_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM();
		o_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM.RadiusValue = RadiusValue;
		o_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM.RadiusType = RadiusType;
		o_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM.TargetID = TargetID;
		o_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM.Target_Type = Target_Type;
		o_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM.Target = Target.Clone() as TargetParam;
		return o_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM;
	}

	public void Read(BinaryReader br)
	{
		RadiusValue = br.ReadSingle();
		RadiusType = br.ReadUInt32();
		TargetID = br.ReadInt32();
		Target_Type = br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!RadiusValue.ToString().Contains(str) && !RadiusType.ToString().Contains(str) && !TargetID.ToString().Contains(str) && !Target_Type.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(RadiusValue);
		bw.Write(RadiusType);
		bw.Write(TargetID);
		bw.Write(Target_Type);
		TargetStream.Save(bw, Target);
	}
}
