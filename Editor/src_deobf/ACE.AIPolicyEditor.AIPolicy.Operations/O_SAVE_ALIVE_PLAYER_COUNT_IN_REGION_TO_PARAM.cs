using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM : ICloneable, IOperation
{
	private int int_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private TargetParam targetParam_0;

	private VarType varType_0;

	[Browsable(false)]
	public int FromVersion => 28;

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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("MaxX")]
	public float MaxX
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
	[LocalizedDisplayName("MaxY")]
	public float MaxY
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
	[LocalizedDisplayName("MaxZ")]
	public float MaxZ
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

	[LocalizedDisplayName("MinX")]
	[LocalizedCategory("OperationParam")]
	public float MinX
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("MinY")]
	public float MinY
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("MinZ")]
	public float MinZ
	{
		[CompilerGenerated]
		get
		{
			return float_5;
		}
		[CompilerGenerated]
		set
		{
			float_5 = value;
		}
	}

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937977));

	[Browsable(false)]
	public int OperID => 43;

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

	public O_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM()
	{
		MinX = 0f;
		MinY = 0f;
		MinZ = 0f;
		MaxX = 0f;
		MaxY = 0f;
		MaxZ = 0f;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM o_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM = new O_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM();
		o_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM.MinX = MinX;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM.MinY = MinY;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM.MinZ = MinZ;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM.MaxX = MaxX;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM.MaxY = MaxY;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM.MaxZ = MaxZ;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM.iTargetID = iTargetID;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM.uTargetType = uTargetType;
		o_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM.Target = Target.Clone() as TargetParam;
		return o_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM;
	}

	public void Read(BinaryReader br)
	{
		MinX = br.ReadSingle();
		MinY = br.ReadSingle();
		MinZ = br.ReadSingle();
		MaxX = br.ReadSingle();
		MaxY = br.ReadSingle();
		MaxZ = br.ReadSingle();
		iTargetID = br.ReadInt32();
		uTargetType = (VarType)br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!iTargetID.ToString().Contains(str) && !uTargetType.ToString().Contains(str) && !MinX.ToString().Contains(str) && !MinY.ToString().Contains(str) && !MinZ.ToString().Contains(str) && !MaxX.ToString().Contains(str) && !MaxY.ToString().Contains(str) && !MaxZ.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(MinX);
		bw.Write(MinY);
		bw.Write(MinZ);
		bw.Write(MaxX);
		bw.Write(MaxY);
		bw.Write(MaxZ);
		bw.Write(iTargetID);
		bw.Write(Convert.ToUInt32(uTargetType));
		TargetStream.Save(bw, Target);
	}
}
