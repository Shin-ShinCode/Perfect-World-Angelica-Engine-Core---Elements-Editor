using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_RANDOM_ASSIGNMENT : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 30;

	[LocalizedDisplayName("iQuantity")]
	[LocalizedCategory("OperationParam")]
	public int iQuantity
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
	[LocalizedDisplayName("iRandomMax")]
	public int iRandomMax
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

	[LocalizedDisplayName("iRandomMin")]
	[LocalizedCategory("OperationParam")]
	public int iRandomMin
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

	[LocalizedDisplayName("iTargetID")]
	[LocalizedCategory("OperationParam")]
	public int iTargetID
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937898));

	[Browsable(false)]
	public int OperID => 47;

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

	public O_RANDOM_ASSIGNMENT()
	{
		iRandomMin = 0;
		iRandomMax = 0;
		iQuantity = 0;
		iTargetID = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_RANDOM_ASSIGNMENT o_RANDOM_ASSIGNMENT = new O_RANDOM_ASSIGNMENT();
		o_RANDOM_ASSIGNMENT.iRandomMin = iRandomMin;
		o_RANDOM_ASSIGNMENT.iRandomMax = iRandomMax;
		o_RANDOM_ASSIGNMENT.iQuantity = iQuantity;
		o_RANDOM_ASSIGNMENT.iTargetID = iTargetID;
		o_RANDOM_ASSIGNMENT.Target = Target.Clone() as TargetParam;
		return o_RANDOM_ASSIGNMENT;
	}

	public void Read(BinaryReader br)
	{
		iRandomMin = br.ReadInt32();
		iRandomMax = br.ReadInt32();
		iQuantity = br.ReadInt32();
		iTargetID = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!iRandomMin.ToString().Contains(str) && !iRandomMax.ToString().Contains(str) && !iQuantity.ToString().Contains(str) && !iTargetID.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iRandomMin);
		bw.Write(iRandomMax);
		bw.Write(iQuantity);
		bw.Write(iTargetID);
		TargetStream.Save(bw, Target);
	}
}
