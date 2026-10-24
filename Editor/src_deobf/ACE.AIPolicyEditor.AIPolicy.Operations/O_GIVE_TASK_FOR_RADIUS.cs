using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_GIVE_TASK_FOR_RADIUS : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	private int int_1;

	private int int_2;

	private int int_3;

	[Browsable(false)]
	public int FromVersion => 40;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("TaskID")]
	public int TaskID
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937846));

	[Browsable(false)]
	public int OperID => 110;

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

	[LocalizedDisplayName("Value")]
	[LocalizedCategory("OperationParam")]
	public int Value
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

	[LocalizedDisplayName("Range")]
	[LocalizedCategory("OperationParam")]
	public int Range
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value2")]
	public int Value2
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

	public O_GIVE_TASK_FOR_RADIUS()
	{
		TaskID = 0;
		Value = 0;
		Range = 0;
		Value2 = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_GIVE_TASK_FOR_RADIUS o_GIVE_TASK_FOR_RADIUS = new O_GIVE_TASK_FOR_RADIUS();
		o_GIVE_TASK_FOR_RADIUS.TaskID = TaskID;
		o_GIVE_TASK_FOR_RADIUS.Value = Value;
		o_GIVE_TASK_FOR_RADIUS.Range = Range;
		o_GIVE_TASK_FOR_RADIUS.Value2 = Value2;
		o_GIVE_TASK_FOR_RADIUS.Target = Target.Clone() as TargetParam;
		return o_GIVE_TASK_FOR_RADIUS;
	}

	public void Read(BinaryReader br)
	{
		TaskID = br.ReadInt32();
		Value = br.ReadInt32();
		Range = br.ReadInt32();
		Value2 = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!TaskID.ToString().Contains(str) && !Value.ToString().Contains(str) && !Range.ToString().Contains(str) && !Value2.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(TaskID);
		bw.Write(Value);
		bw.Write(Range);
		bw.Write(Value2);
		TargetStream.Save(bw, Target);
	}
}
