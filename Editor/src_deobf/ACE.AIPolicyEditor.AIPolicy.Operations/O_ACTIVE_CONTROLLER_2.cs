using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_ACTIVE_CONTROLLER_2 : ICloneable, IOperation
{
	private uint uint_0;

	private uint uint_1;

	private bool bool_0;

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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937494));

	[Browsable(false)]
	public int OperID => 27;

	[LocalizedDisplayName("Stop")]
	[LocalizedCategory("OperationParam")]
	public bool Stop
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

	public O_ACTIVE_CONTROLLER_2()
	{
		ID = 0u;
		IDType = 0u;
		Stop = false;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_ACTIVE_CONTROLLER_2 o_ACTIVE_CONTROLLER_ = new O_ACTIVE_CONTROLLER_2();
		o_ACTIVE_CONTROLLER_.ID = ID;
		o_ACTIVE_CONTROLLER_.IDType = IDType;
		o_ACTIVE_CONTROLLER_.Stop = Stop;
		o_ACTIVE_CONTROLLER_.Target = Target.Clone() as TargetParam;
		return o_ACTIVE_CONTROLLER_;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadUInt32();
		IDType = br.ReadUInt32();
		Stop = br.ReadBoolean();
		br.ReadBytes(3);
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ID.ToString().Contains(str) && !IDType.ToString().Contains(str) && !Stop.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID);
		bw.Write(IDType);
		bw.Write(Stop);
		bw.Write(new byte[3]);
		TargetStream.Save(bw, Target);
	}
}
