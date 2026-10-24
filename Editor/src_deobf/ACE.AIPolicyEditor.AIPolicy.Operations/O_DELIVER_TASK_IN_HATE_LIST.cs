using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_DELIVER_TASK_IN_HATE_LIST : ICloneable, IOperation
{
	private uint uint_0;

	private uint uint_1;

	private int int_0;

	private int int_1;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 20;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ID")]
	public uint ID
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

	[LocalizedDisplayName("IDType")]
	[LocalizedCategory("OperationParam")]
	public uint IDType
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937796));

	[Browsable(false)]
	public int OperID => 32;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("PlayerNum")]
	public int PlayerNum
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
	[LocalizedDisplayName("Range")]
	public int Range
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

	public O_DELIVER_TASK_IN_HATE_LIST()
	{
		ID = 0u;
		IDType = 0u;
		Range = 0;
		PlayerNum = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_DELIVER_TASK_IN_HATE_LIST o_DELIVER_TASK_IN_HATE_LIST = new O_DELIVER_TASK_IN_HATE_LIST();
		o_DELIVER_TASK_IN_HATE_LIST.ID = ID;
		o_DELIVER_TASK_IN_HATE_LIST.IDType = IDType;
		o_DELIVER_TASK_IN_HATE_LIST.Range = Range;
		o_DELIVER_TASK_IN_HATE_LIST.PlayerNum = PlayerNum;
		o_DELIVER_TASK_IN_HATE_LIST.Target = Target.Clone() as TargetParam;
		return o_DELIVER_TASK_IN_HATE_LIST;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadUInt32();
		IDType = br.ReadUInt32();
		Range = br.ReadInt32();
		PlayerNum = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ID.ToString().Contains(str) && !IDType.ToString().Contains(str) && !Range.ToString().Contains(str) && !PlayerNum.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID);
		bw.Write(IDType);
		bw.Write(Range);
		bw.Write(PlayerNum);
		TargetStream.Save(bw, Target);
	}
}
