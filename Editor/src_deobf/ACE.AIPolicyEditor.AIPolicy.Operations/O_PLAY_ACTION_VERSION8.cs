using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_PLAY_ACTION_VERSION8 : ICloneable, IOperation
{
	private string string_0;

	private int int_0;

	private bool bool_0;

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
	public int FromVersion => 8;

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
	[LocalizedDisplayName("Loop")]
	public bool Loop
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937888));

	[Browsable(false)]
	public int OperID => 19;

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

	public O_PLAY_ACTION_VERSION8()
	{
		ActionName = string.Empty;
		Loop = false;
		Interval = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_PLAY_ACTION_VERSION8 o_PLAY_ACTION_VERSION = new O_PLAY_ACTION_VERSION8();
		o_PLAY_ACTION_VERSION.ActionName = ActionName;
		o_PLAY_ACTION_VERSION.Loop = Loop;
		o_PLAY_ACTION_VERSION.Interval = Interval;
		o_PLAY_ACTION_VERSION.Target = Target.Clone() as TargetParam;
		return o_PLAY_ACTION_VERSION;
	}

	public void Read(BinaryReader br)
	{
		ActionName = br.ReadBytes(128).ToGBK();
		Loop = br.ReadBoolean();
		br.ReadBytes(3);
		Interval = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ActionName.Contains(str) && !Loop.ToString().Contains(str) && !Interval.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ActionName.FromGBK(128));
		bw.Write(Loop);
		bw.Write(new byte[3]);
		bw.Write(Interval);
		TargetStream.Save(bw, Target);
	}
}
