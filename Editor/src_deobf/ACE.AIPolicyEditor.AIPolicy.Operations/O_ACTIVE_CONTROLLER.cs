using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_ACTIVE_CONTROLLER : ICloneable, IOperation
{
	private uint uint_0;

	private bool bool_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 1;

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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937484));

	[Browsable(false)]
	public int OperID => 14;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Stop")]
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

	public O_ACTIVE_CONTROLLER()
	{
		ID = 0u;
		Stop = false;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_ACTIVE_CONTROLLER o_ACTIVE_CONTROLLER = new O_ACTIVE_CONTROLLER();
		o_ACTIVE_CONTROLLER.ID = ID;
		o_ACTIVE_CONTROLLER.Stop = Stop;
		o_ACTIVE_CONTROLLER.Target = Target.Clone() as TargetParam;
		return o_ACTIVE_CONTROLLER;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadUInt32();
		Stop = br.ReadBoolean();
		br.ReadBytes(3);
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!ID.ToString().Contains(str) && !Stop.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID);
		bw.Write(Stop);
		bw.Write(new byte[3]);
		TargetStream.Save(bw, Target);
	}
}
