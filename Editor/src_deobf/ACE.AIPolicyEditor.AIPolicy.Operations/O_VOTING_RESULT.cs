using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_VOTING_RESULT : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 30;

	[LocalizedDisplayName("iSaveResult")]
	[LocalizedCategory("OperationParam")]
	public int iSaveResult
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
	[LocalizedDisplayName("iSaveResultType")]
	public int iSaveResultType
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

	[LocalizedDisplayName("iSelect")]
	[LocalizedCategory("OperationParam")]
	public int iSelect
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iSelectType")]
	public int iSelectType
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

	[LocalizedDisplayName("iVoteID")]
	[LocalizedCategory("OperationParam")]
	public int iVoteID
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iVoteIDType")]
	public int iVoteIDType
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937260));

	[Browsable(false)]
	public int OperID => 49;

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

	public O_VOTING_RESULT()
	{
		iVoteID = 0;
		iVoteIDType = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_VOTING_RESULT o_VOTING_RESULT = new O_VOTING_RESULT();
		o_VOTING_RESULT.iVoteID = iVoteID;
		o_VOTING_RESULT.iVoteIDType = iVoteIDType;
		o_VOTING_RESULT.iSelect = iSelect;
		o_VOTING_RESULT.iSelectType = iSelectType;
		o_VOTING_RESULT.iSaveResult = iSaveResult;
		o_VOTING_RESULT.iSaveResultType = iSaveResultType;
		o_VOTING_RESULT.Target = Target.Clone() as TargetParam;
		return o_VOTING_RESULT;
	}

	public void Read(BinaryReader br)
	{
		iVoteID = br.ReadInt32();
		iVoteIDType = br.ReadInt32();
		iSelect = br.ReadInt32();
		iSelectType = br.ReadInt32();
		iSaveResult = br.ReadInt32();
		iSaveResultType = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!iVoteID.ToString().Contains(str) && !iVoteIDType.ToString().Contains(str) && !iSelect.ToString().Contains(str) && !iSelectType.ToString().Contains(str) && !iSaveResult.ToString().Contains(str) && !iSaveResultType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iVoteID);
		bw.Write(iVoteIDType);
		bw.Write(iSelect);
		bw.Write(iSelectType);
		bw.Write(iSaveResult);
		bw.Write(iSaveResultType);
		TargetStream.Save(bw, Target);
	}
}
