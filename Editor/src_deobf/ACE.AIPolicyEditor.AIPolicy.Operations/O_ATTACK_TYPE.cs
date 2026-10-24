using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_ATTACK_TYPE : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	private uint uint_0;

	[Browsable(false)]
	public int FromVersion => 1;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937547));

	[Browsable(false)]
	public int OperID => 0;

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

	[LocalizedDisplayName("Type")]
	[LocalizedCategory("OperationParam")]
	public uint Type
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

	public O_ATTACK_TYPE()
	{
		Type = 0u;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_ATTACK_TYPE o_ATTACK_TYPE = new O_ATTACK_TYPE();
		o_ATTACK_TYPE.Type = Type;
		o_ATTACK_TYPE.Target = Target.Clone() as TargetParam;
		return o_ATTACK_TYPE;
	}

	public void Read(BinaryReader br)
	{
		Type = br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (Type.ToString().Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Type);
		TargetStream.Save(bw, Target);
	}
}
