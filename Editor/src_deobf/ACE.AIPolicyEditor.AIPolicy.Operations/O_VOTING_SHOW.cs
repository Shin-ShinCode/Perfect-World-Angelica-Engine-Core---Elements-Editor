using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_VOTING_SHOW : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 30;

	[LocalizedDisplayName("iSelect0")]
	[LocalizedCategory("OperationParam")]
	public int iSelect0
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
	[LocalizedDisplayName("iSelect1")]
	public int iSelect1
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

	[LocalizedDisplayName("iSelect2")]
	[LocalizedCategory("OperationParam")]
	public int iSelect2
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
	[LocalizedDisplayName("iSelect3")]
	public int iSelect3
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iSelect4")]
	public int iSelect4
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
	[LocalizedDisplayName("iSelect5")]
	public int iSelect5
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iSelect6")]
	public int iSelect6
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	[LocalizedDisplayName("iSelect7")]
	[LocalizedCategory("OperationParam")]
	public int iSelect7
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iStyle")]
	public int iStyle
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iVoteID0")]
	public int iVoteID0
	{
		[CompilerGenerated]
		get
		{
			return int_9;
		}
		[CompilerGenerated]
		set
		{
			int_9 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iVoteID1")]
	public int iVoteID1
	{
		[CompilerGenerated]
		get
		{
			return int_10;
		}
		[CompilerGenerated]
		set
		{
			int_10 = value;
		}
	}

	[LocalizedDisplayName("iVoteID2")]
	[LocalizedCategory("OperationParam")]
	public int iVoteID2
	{
		[CompilerGenerated]
		get
		{
			return int_11;
		}
		[CompilerGenerated]
		set
		{
			int_11 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iVoteID3")]
	public int iVoteID3
	{
		[CompilerGenerated]
		get
		{
			return int_12;
		}
		[CompilerGenerated]
		set
		{
			int_12 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iVoteID4")]
	public int iVoteID4
	{
		[CompilerGenerated]
		get
		{
			return int_13;
		}
		[CompilerGenerated]
		set
		{
			int_13 = value;
		}
	}

	[LocalizedDisplayName("iVoteID5")]
	[LocalizedCategory("OperationParam")]
	public int iVoteID5
	{
		[CompilerGenerated]
		get
		{
			return int_14;
		}
		[CompilerGenerated]
		set
		{
			int_14 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iVoteID6")]
	public int iVoteID6
	{
		[CompilerGenerated]
		get
		{
			return int_15;
		}
		[CompilerGenerated]
		set
		{
			int_15 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iVoteID7")]
	public int iVoteID7
	{
		[CompilerGenerated]
		get
		{
			return int_16;
		}
		[CompilerGenerated]
		set
		{
			int_16 = value;
		}
	}

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937270));

	[Browsable(false)]
	public int OperID => 50;

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

	public O_VOTING_SHOW()
	{
		iStyle = 0;
		iVoteID0 = 0;
		iSelect0 = 0;
		iVoteID1 = 0;
		iSelect1 = 0;
		iVoteID2 = 0;
		iSelect2 = 0;
		iVoteID3 = 0;
		iSelect3 = 0;
		iVoteID4 = 0;
		iSelect4 = 0;
		iVoteID5 = 0;
		iSelect5 = 0;
		iVoteID6 = 0;
		iSelect6 = 0;
		iVoteID7 = 0;
		iSelect7 = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_VOTING_SHOW o_VOTING_SHOW = new O_VOTING_SHOW();
		o_VOTING_SHOW.iStyle = iStyle;
		o_VOTING_SHOW.iVoteID0 = iVoteID0;
		o_VOTING_SHOW.iSelect0 = iSelect0;
		o_VOTING_SHOW.iVoteID1 = iVoteID1;
		o_VOTING_SHOW.iSelect1 = iSelect1;
		o_VOTING_SHOW.iVoteID2 = iVoteID2;
		o_VOTING_SHOW.iSelect2 = iSelect2;
		o_VOTING_SHOW.iVoteID3 = iVoteID3;
		o_VOTING_SHOW.iSelect3 = iSelect3;
		o_VOTING_SHOW.iVoteID4 = iVoteID4;
		o_VOTING_SHOW.iSelect4 = iSelect4;
		o_VOTING_SHOW.iVoteID5 = iVoteID5;
		o_VOTING_SHOW.iSelect5 = iSelect5;
		o_VOTING_SHOW.iVoteID6 = iVoteID6;
		o_VOTING_SHOW.iSelect6 = iSelect6;
		o_VOTING_SHOW.iVoteID7 = iVoteID7;
		o_VOTING_SHOW.iSelect7 = iSelect7;
		o_VOTING_SHOW.Target = Target.Clone() as TargetParam;
		return o_VOTING_SHOW;
	}

	public void Read(BinaryReader br)
	{
		iStyle = br.ReadInt32();
		iVoteID0 = br.ReadInt32();
		iSelect0 = br.ReadInt32();
		iVoteID1 = br.ReadInt32();
		iSelect1 = br.ReadInt32();
		iVoteID2 = br.ReadInt32();
		iSelect2 = br.ReadInt32();
		iVoteID3 = br.ReadInt32();
		iSelect3 = br.ReadInt32();
		iVoteID4 = br.ReadInt32();
		iSelect4 = br.ReadInt32();
		iVoteID5 = br.ReadInt32();
		iSelect5 = br.ReadInt32();
		iVoteID6 = br.ReadInt32();
		iSelect6 = br.ReadInt32();
		iVoteID7 = br.ReadInt32();
		iSelect7 = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!iStyle.ToString().Contains(str) && !iVoteID0.ToString().Contains(str) && !iSelect0.ToString().Contains(str) && !iVoteID1.ToString().Contains(str) && !iSelect1.ToString().Contains(str) && !iVoteID2.ToString().Contains(str) && !iSelect2.ToString().Contains(str) && !iVoteID3.ToString().Contains(str) && !iSelect3.ToString().Contains(str) && !iVoteID4.ToString().Contains(str) && !iSelect4.ToString().Contains(str) && !iVoteID5.ToString().Contains(str) && !iSelect5.ToString().Contains(str) && !iVoteID6.ToString().Contains(str) && !iSelect6.ToString().Contains(str) && !iVoteID7.ToString().Contains(str) && !iSelect7.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iStyle);
		bw.Write(iVoteID0);
		bw.Write(iSelect0);
		bw.Write(iVoteID1);
		bw.Write(iSelect1);
		bw.Write(iVoteID2);
		bw.Write(iSelect2);
		bw.Write(iVoteID3);
		bw.Write(iSelect3);
		bw.Write(iVoteID4);
		bw.Write(iSelect4);
		bw.Write(iVoteID5);
		bw.Write(iSelect5);
		bw.Write(iVoteID6);
		bw.Write(iSelect6);
		bw.Write(iVoteID7);
		bw.Write(iSelect7);
		TargetStream.Save(bw, Target);
	}
}
