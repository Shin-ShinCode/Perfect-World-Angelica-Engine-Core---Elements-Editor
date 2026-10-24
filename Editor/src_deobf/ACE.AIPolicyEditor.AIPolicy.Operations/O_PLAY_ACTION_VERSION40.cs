using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_PLAY_ACTION_VERSION40 : ICloneable, IOperation
{
	private string string_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private TargetParam targetParam_0;

	private int int_3;

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
	public int FromVersion => 38;

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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("PlayTime")]
	public int UNK
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public O_PLAY_ACTION_VERSION40()
	{
		ActionName = string.Empty;
		LoopCount = 0;
		Interval = 0;
		PlayTime = 0;
		UNK = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_PLAY_ACTION_VERSION40 o_PLAY_ACTION_VERSION = new O_PLAY_ACTION_VERSION40();
		o_PLAY_ACTION_VERSION.ActionName = ActionName;
		o_PLAY_ACTION_VERSION.LoopCount = LoopCount;
		o_PLAY_ACTION_VERSION.Interval = Interval;
		o_PLAY_ACTION_VERSION.PlayTime = PlayTime;
		o_PLAY_ACTION_VERSION.UNK = UNK;
		o_PLAY_ACTION_VERSION.Target = Target.Clone() as TargetParam;
		return o_PLAY_ACTION_VERSION;
	}

	public void Read(BinaryReader br)
	{
		ActionName = br.ReadBytes(128).ToGBK();
		LoopCount = br.ReadInt32();
		Interval = br.ReadInt32();
		PlayTime = br.ReadInt32();
		UNK = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ActionName.Contains(str) && !LoopCount.ToString().Contains(str) && !Interval.ToString().Contains(str) && !PlayTime.ToString().Contains(str) && !UNK.ToString().Contains(str))
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
		bw.Write(UNK);
		TargetStream.Save(bw, Target);
	}
}
