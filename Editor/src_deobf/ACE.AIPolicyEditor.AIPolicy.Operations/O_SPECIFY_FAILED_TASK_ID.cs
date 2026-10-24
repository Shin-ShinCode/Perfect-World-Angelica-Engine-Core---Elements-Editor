using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SPECIFY_FAILED_TASK_ID : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 33;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iTaskID")]
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iTaskIDType")]
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937092));

	[Browsable(false)]
	public int OperID => 62;

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

	public O_SPECIFY_FAILED_TASK_ID()
	{
		iTaskID = 0;
		iTaskIDType = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SPECIFY_FAILED_TASK_ID o_SPECIFY_FAILED_TASK_ID = new O_SPECIFY_FAILED_TASK_ID();
		o_SPECIFY_FAILED_TASK_ID.iTaskID = iTaskID;
		o_SPECIFY_FAILED_TASK_ID.iTaskIDType = iTaskIDType;
		o_SPECIFY_FAILED_TASK_ID.Target = Target.Clone() as TargetParam;
		return o_SPECIFY_FAILED_TASK_ID;
	}

	public void Read(BinaryReader br)
	{
		iTaskID = br.ReadInt32();
		iTaskIDType = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!iTaskID.ToString().Contains(str) && !iTaskIDType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iTaskID);
		bw.Write(iTaskIDType);
		TargetStream.Save(bw, Target);
	}
}
