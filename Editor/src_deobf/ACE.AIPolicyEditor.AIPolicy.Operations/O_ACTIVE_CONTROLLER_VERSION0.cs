using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_ACTIVE_CONTROLLER_VERSION0 : ICloneable, IOperation
{
	private uint uint_0;

	private bool bool_0;

	private TargetParam targetParam_0;

	private byte[] byte_0;

	[Browsable(false)]
	public int FromVersion => 0;

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

	public byte[] Unknown
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public O_ACTIVE_CONTROLLER_VERSION0()
	{
		ID = 0u;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_ACTIVE_CONTROLLER_VERSION0 o_ACTIVE_CONTROLLER_VERSION = new O_ACTIVE_CONTROLLER_VERSION0();
		o_ACTIVE_CONTROLLER_VERSION.ID = ID;
		o_ACTIVE_CONTROLLER_VERSION.Target = Target.Clone() as TargetParam;
		return o_ACTIVE_CONTROLLER_VERSION;
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (ID.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(ID);
		TargetStream.Save(bw, Target);
	}
}
