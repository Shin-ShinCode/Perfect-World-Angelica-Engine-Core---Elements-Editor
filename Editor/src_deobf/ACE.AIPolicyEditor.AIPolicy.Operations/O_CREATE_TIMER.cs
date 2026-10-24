using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CREATE_TIMER : ICloneable, IOperation
{
	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private TargetParam targetParam_0;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Counter")]
	public uint Counter
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

	[Browsable(false)]
	public int FromVersion => 1;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ID")]
	public uint ID
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937739));

	[Browsable(false)]
	public int OperID => 7;

	[LocalizedDisplayName("Period")]
	[LocalizedCategory("OperationParam")]
	public uint Period
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

	public O_CREATE_TIMER()
	{
		ID = 0u;
		Period = 0u;
		Counter = 0u;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_CREATE_TIMER o_CREATE_TIMER = new O_CREATE_TIMER();
		o_CREATE_TIMER.ID = ID;
		o_CREATE_TIMER.Period = Period;
		o_CREATE_TIMER.Counter = Counter;
		o_CREATE_TIMER.Target = Target.Clone() as TargetParam;
		return o_CREATE_TIMER;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadUInt32();
		Period = br.ReadUInt32();
		Counter = br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ID.ToString().Contains(str) && !Period.ToString().Contains(str) && !Counter.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID);
		bw.Write(Period);
		bw.Write(Counter);
		TargetStream.Save(bw, Target);
	}
}
