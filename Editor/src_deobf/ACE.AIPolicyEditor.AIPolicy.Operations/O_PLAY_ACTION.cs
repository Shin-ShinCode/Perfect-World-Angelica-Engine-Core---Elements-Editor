using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_PLAY_ACTION : ICloneable, IOperation
{
	private string string_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private TargetParam targetParam_0;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ActionName")]
	public string ActionName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	[Browsable(false)]
	public int FromVersion => 9;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Interval")]
	public int Interval
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
	[LocalizedDisplayName("LoopCount")]
	public int LoopCount
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937888));

	[Browsable(false)]
	public int OperID => 19;

	[LocalizedDisplayName("PlayTime")]
	[LocalizedCategory("OperationParam")]
	public int PlayTime
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
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

	public O_PLAY_ACTION()
	{
		ActionName = string.Empty;
		LoopCount = 0;
		Interval = 0;
		PlayTime = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_PLAY_ACTION o_PLAY_ACTION = new O_PLAY_ACTION();
		o_PLAY_ACTION.ActionName = ActionName;
		o_PLAY_ACTION.LoopCount = LoopCount;
		o_PLAY_ACTION.Interval = Interval;
		o_PLAY_ACTION.PlayTime = PlayTime;
		o_PLAY_ACTION.Target = Target.Clone() as TargetParam;
		return o_PLAY_ACTION;
	}

	public void Read(BinaryReader br)
	{
		ActionName = br.ReadBytes(128).ToGBK();
		LoopCount = br.ReadInt32();
		Interval = br.ReadInt32();
		PlayTime = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ActionName.Contains(str) && !LoopCount.ToString().Contains(str) && !Interval.ToString().Contains(str) && !PlayTime.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ActionName.FromGBK(128));
		bw.Write(LoopCount);
		bw.Write(Interval);
		bw.Write(PlayTime);
		TargetStream.Save(bw, Target);
	}
}
