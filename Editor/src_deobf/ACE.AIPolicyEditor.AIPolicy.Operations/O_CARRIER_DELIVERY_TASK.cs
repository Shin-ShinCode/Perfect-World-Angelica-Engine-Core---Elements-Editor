using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CARRIER_DELIVERY_TASK : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 30;

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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937636));

	[Browsable(false)]
	public int OperID => 51;

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

	public O_CARRIER_DELIVERY_TASK()
	{
		iTaskID = 0;
		iTaskIDType = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_CARRIER_DELIVERY_TASK o_CARRIER_DELIVERY_TASK = new O_CARRIER_DELIVERY_TASK();
		o_CARRIER_DELIVERY_TASK.iTaskID = iTaskID;
		o_CARRIER_DELIVERY_TASK.iTaskIDType = iTaskIDType;
		o_CARRIER_DELIVERY_TASK.Target = Target.Clone() as TargetParam;
		return o_CARRIER_DELIVERY_TASK;
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
