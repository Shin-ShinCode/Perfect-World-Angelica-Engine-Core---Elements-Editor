using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_ADD_RANGE_TO_HATE_LIST : ICloneable, IOperation
{
	private int int_0;

	private uint uint_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 28;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937534));

	[Browsable(false)]
	public int OperID => 41;

	[LocalizedDisplayName("range")]
	[LocalizedCategory("OperationParam")]
	public int range
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

	[LocalizedDisplayName("rangeType")]
	[LocalizedCategory("OperationParam")]
	public uint rangeType
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

	public O_ADD_RANGE_TO_HATE_LIST()
	{
		range = 0;
		rangeType = 0u;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_ADD_RANGE_TO_HATE_LIST o_ADD_RANGE_TO_HATE_LIST = new O_ADD_RANGE_TO_HATE_LIST();
		o_ADD_RANGE_TO_HATE_LIST.range = range;
		o_ADD_RANGE_TO_HATE_LIST.rangeType = rangeType;
		o_ADD_RANGE_TO_HATE_LIST.Target = Target.Clone() as TargetParam;
		return o_ADD_RANGE_TO_HATE_LIST;
	}

	public void Read(BinaryReader br)
	{
		range = br.ReadInt32();
		rangeType = br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!range.ToString().Contains(str) && !rangeType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(range);
		bw.Write(rangeType);
		TargetStream.Save(bw, Target);
	}
}
