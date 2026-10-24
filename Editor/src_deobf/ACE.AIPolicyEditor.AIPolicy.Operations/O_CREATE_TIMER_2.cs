using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CREATE_TIMER_2 : ICloneable, IOperation
{
	private VarType varType_0;

	private VarType varType_1;

	private VarType varType_2;

	private TargetParam targetParam_0;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	[Browsable(false)]
	public int FromVersion => 30;

	[LocalizedDisplayName("iCounterType")]
	[LocalizedCategory("OperationParam")]
	public VarType iCounterType
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
	[LocalizedDisplayName("iIDType")]
	public VarType iIDType
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
	[LocalizedDisplayName("iPeriodType")]
	public VarType iPeriodType
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937756));

	[Browsable(false)]
	public int OperID => 54;

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

	[LocalizedDisplayName("uCounter")]
	[LocalizedCategory("OperationParam")]
	public uint uCounter
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("uID")]
	public uint uID
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("uPeriod")]
	public uint uPeriod
	{
		[CompilerGenerated]
		get
		{
			return uint_2;
		}
		[CompilerGenerated]
		set
		{
			uint_2 = value;
		}
	}

	public O_CREATE_TIMER_2()
	{
		uID = 0u;
		iIDType = VarType.GlobalVarID;
		uPeriod = 0u;
		iPeriodType = VarType.GlobalVarID;
		uCounter = 0u;
		iCounterType = VarType.GlobalVarID;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_CREATE_TIMER_2 o_CREATE_TIMER_ = new O_CREATE_TIMER_2();
		o_CREATE_TIMER_.uID = uID;
		o_CREATE_TIMER_.iIDType = iIDType;
		o_CREATE_TIMER_.uPeriod = uPeriod;
		o_CREATE_TIMER_.iPeriodType = iPeriodType;
		o_CREATE_TIMER_.uCounter = uCounter;
		o_CREATE_TIMER_.iCounterType = iCounterType;
		o_CREATE_TIMER_.Target = Target.Clone() as TargetParam;
		return o_CREATE_TIMER_;
	}

	public void Read(BinaryReader br)
	{
		uID = br.ReadUInt32();
		iIDType = (VarType)br.ReadInt32();
		uPeriod = br.ReadUInt32();
		iPeriodType = (VarType)br.ReadInt32();
		uCounter = br.ReadUInt32();
		iCounterType = (VarType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!uID.ToString().Contains(str) && !iIDType.ToString().Contains(str) && !uPeriod.ToString().Contains(str) && !iPeriodType.ToString().Contains(str) && !uCounter.ToString().Contains(str) && !iCounterType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(uID);
		bw.Write(Convert.ToUInt32(iIDType));
		bw.Write(uPeriod);
		bw.Write(Convert.ToUInt32(iPeriodType));
		bw.Write(uCounter);
		bw.Write(Convert.ToUInt32(iCounterType));
		TargetStream.Save(bw, Target);
	}
}
