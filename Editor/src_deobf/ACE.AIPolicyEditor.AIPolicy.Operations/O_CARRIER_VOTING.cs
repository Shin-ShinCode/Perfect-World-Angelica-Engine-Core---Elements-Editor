using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CARRIER_VOTING : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 30;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iVoteID")]
	public int iVoteID
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
	[LocalizedDisplayName("iVoteIDType")]
	public int iVoteIDType
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937648));

	[Browsable(false)]
	public int OperID => 48;

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

	public O_CARRIER_VOTING()
	{
		iVoteID = 0;
		iVoteIDType = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_CARRIER_VOTING o_CARRIER_VOTING = new O_CARRIER_VOTING();
		o_CARRIER_VOTING.iVoteID = iVoteID;
		o_CARRIER_VOTING.iVoteIDType = iVoteIDType;
		o_CARRIER_VOTING.Target = Target.Clone() as TargetParam;
		return o_CARRIER_VOTING;
	}

	public void Read(BinaryReader br)
	{
		iVoteID = br.ReadInt32();
		iVoteIDType = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!iVoteID.ToString().Contains(str) && !iVoteIDType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iVoteID);
		bw.Write(iVoteIDType);
		TargetStream.Save(bw, Target);
	}
}
