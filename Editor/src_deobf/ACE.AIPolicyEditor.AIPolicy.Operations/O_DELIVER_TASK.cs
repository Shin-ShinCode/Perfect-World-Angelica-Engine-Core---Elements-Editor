using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_DELIVER_TASK : ICloneable, IOperation
{
	private uint uint_0;

	private uint uint_1;

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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937778));

	[Browsable(false)]
	public int OperID => 28;

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

	public O_DELIVER_TASK()
	{
		ID = 0u;
		IDType = 0u;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_DELIVER_TASK o_DELIVER_TASK = new O_DELIVER_TASK();
		o_DELIVER_TASK.ID = ID;
		o_DELIVER_TASK.IDType = IDType;
		o_DELIVER_TASK.Target = Target.Clone() as TargetParam;
		return o_DELIVER_TASK;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadUInt32();
		IDType = br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ID.ToString().Contains(str) && !IDType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID);
		bw.Write(IDType);
		TargetStream.Save(bw, Target);
	}
}
