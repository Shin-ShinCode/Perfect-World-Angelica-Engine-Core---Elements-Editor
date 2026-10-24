using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SPECIFY_FAILED_TASK_ID_REGIONAL : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private TargetParam targetParam_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	[Browsable(false)]
	public int FromVersion => 33;

	[LocalizedDisplayName("iTaskID")]
	[LocalizedCategory("OperationParam")]
	public int iTaskID
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

	[LocalizedDisplayName("iTaskIDType")]
	[LocalizedCategory("OperationParam")]
	public int iTaskIDType
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937102));

	[Browsable(false)]
	public int OperID => 63;

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

	[LocalizedDisplayName("zvMaxx")]
	[LocalizedCategory("OperationParam")]
	public float zvMaxx
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
	[LocalizedDisplayName("zvMaxy")]
	public float zvMaxy
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

	[LocalizedDisplayName("zvMaxz")]
	[LocalizedCategory("OperationParam")]
	public float zvMaxz
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("zvMinx")]
	public float zvMinx
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

	[LocalizedDisplayName("zvMiny")]
	[LocalizedCategory("OperationParam")]
	public float zvMiny
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

	[LocalizedDisplayName("zvMinz")]
	[LocalizedCategory("OperationParam")]
	public float zvMinz
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

	public O_SPECIFY_FAILED_TASK_ID_REGIONAL()
	{
		iTaskID = 0;
		iTaskIDType = 0;
		zvMinx = 0f;
		zvMiny = 0f;
		zvMinz = 0f;
		zvMaxx = 0f;
		zvMaxy = 0f;
		zvMaxz = 0f;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SPECIFY_FAILED_TASK_ID_REGIONAL o_SPECIFY_FAILED_TASK_ID_REGIONAL = new O_SPECIFY_FAILED_TASK_ID_REGIONAL();
		o_SPECIFY_FAILED_TASK_ID_REGIONAL.iTaskID = iTaskID;
		o_SPECIFY_FAILED_TASK_ID_REGIONAL.iTaskIDType = iTaskIDType;
		o_SPECIFY_FAILED_TASK_ID_REGIONAL.zvMinx = zvMinx;
		o_SPECIFY_FAILED_TASK_ID_REGIONAL.zvMiny = zvMiny;
		o_SPECIFY_FAILED_TASK_ID_REGIONAL.zvMinz = zvMinz;
		o_SPECIFY_FAILED_TASK_ID_REGIONAL.zvMaxx = zvMaxx;
		o_SPECIFY_FAILED_TASK_ID_REGIONAL.zvMaxy = zvMaxy;
		o_SPECIFY_FAILED_TASK_ID_REGIONAL.zvMaxz = zvMaxz;
		o_SPECIFY_FAILED_TASK_ID_REGIONAL.Target = Target.Clone() as TargetParam;
		return o_SPECIFY_FAILED_TASK_ID_REGIONAL;
	}

	public void Read(BinaryReader br)
	{
		iTaskID = br.ReadInt32();
		iTaskIDType = br.ReadInt32();
		zvMinx = br.ReadSingle();
		zvMiny = br.ReadSingle();
		zvMinz = br.ReadSingle();
		zvMaxx = br.ReadSingle();
		zvMaxy = br.ReadSingle();
		zvMaxz = br.ReadSingle();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!iTaskID.ToString().Contains(str) && !iTaskIDType.ToString().Contains(str) && !zvMinx.ToString().Contains(str) && !zvMiny.ToString().Contains(str) && !zvMinz.ToString().Contains(str) && !zvMaxx.ToString().Contains(str) && !zvMaxy.ToString().Contains(str) && !zvMaxz.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iTaskID);
		bw.Write(iTaskIDType);
		bw.Write(zvMinx);
		bw.Write(zvMiny);
		bw.Write(zvMinz);
		bw.Write(zvMaxx);
		bw.Write(zvMaxy);
		bw.Write(zvMaxz);
		TargetStream.Save(bw, Target);
	}
}
