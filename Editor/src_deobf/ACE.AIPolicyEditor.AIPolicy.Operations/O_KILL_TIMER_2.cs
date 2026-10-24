using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_KILL_TIMER_2 : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	private uint uint_0;

	[Browsable(false)]
	public int FromVersion => 30;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iIDType")]
	public int iIDType
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937858));

	[Browsable(false)]
	public int OperID => 55;

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
	[LocalizedDisplayName("uID")]
	public uint uID
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

	public O_KILL_TIMER_2()
	{
		uID = 0u;
		iIDType = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_KILL_TIMER_2 o_KILL_TIMER_ = new O_KILL_TIMER_2();
		o_KILL_TIMER_.uID = uID;
		o_KILL_TIMER_.iIDType = iIDType;
		o_KILL_TIMER_.Target = Target.Clone() as TargetParam;
		return o_KILL_TIMER_;
	}

	public void Read(BinaryReader br)
	{
		uID = br.ReadUInt32();
		iIDType = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!uID.ToString().Contains(str) && !iIDType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(uID);
		bw.Write(iIDType);
		TargetStream.Save(bw, Target);
	}
}
