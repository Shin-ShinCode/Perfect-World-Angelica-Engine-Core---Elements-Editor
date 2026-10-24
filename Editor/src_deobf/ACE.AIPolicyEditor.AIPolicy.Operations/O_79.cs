using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_79 : ICloneable, IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	private VarType varType_0;

	[Browsable(false)]
	public int FromVersion => 33;

	[LocalizedDisplayName("Value1")]
	[LocalizedCategory("OperationParam")]
	public int iTargetID
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938318));

	[Browsable(false)]
	public int OperID => 79;

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

	[LocalizedDisplayName("Value2")]
	[LocalizedCategory("OperationParam")]
	public VarType uTargetType
	{
		[CompilerGenerated]
		get
		{
			return varType_0;
		}
		[CompilerGenerated]
		set
		{
			varType_0 = value;
		}
	}

	public O_79()
	{
		iTargetID = 0;
		uTargetType = VarType.GlobalVarID;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_79 o_ = new O_79();
		o_.iTargetID = iTargetID;
		o_.uTargetType = uTargetType;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		iTargetID = br.ReadInt32();
		uTargetType = (VarType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!iTargetID.ToString().Contains(str) && !uTargetType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iTargetID);
		bw.Write(Convert.ToUInt32(uTargetType));
		TargetStream.Save(bw, Target);
	}
}
