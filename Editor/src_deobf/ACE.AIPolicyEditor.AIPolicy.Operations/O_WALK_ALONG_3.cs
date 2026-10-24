using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_WALK_ALONG_3 : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 28;

	[LocalizedDisplayName("iEndPathID")]
	[LocalizedCategory("OperationParam")]
	public int iEndPathID
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

	[LocalizedDisplayName("iEndPathIDType")]
	[LocalizedCategory("OperationParam")]
	public int iEndPathIDType
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iPatrolType")]
	public int iPatrolType
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
	[LocalizedDisplayName("iPatrolType")]
	public int iSpeedType
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

	[LocalizedDisplayName("iStartPathID")]
	[LocalizedCategory("OperationParam")]
	public int iStartPathID
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
	[LocalizedDisplayName("iStartPathIDType")]
	public int iStartPathIDType
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

	[LocalizedDisplayName("iWorldID")]
	[LocalizedCategory("OperationParam")]
	public int iWorldID
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937300));

	[Browsable(false)]
	public int OperID => 44;

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

	public O_WALK_ALONG_3()
	{
		iWorldID = 0;
		iStartPathID = 0;
		iStartPathIDType = 0;
		iEndPathID = 0;
		iEndPathIDType = 0;
		iPatrolType = 0;
		iSpeedType = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_WALK_ALONG_3 o_WALK_ALONG_ = new O_WALK_ALONG_3();
		o_WALK_ALONG_.iWorldID = iWorldID;
		o_WALK_ALONG_.iStartPathID = iStartPathID;
		o_WALK_ALONG_.iStartPathIDType = iStartPathIDType;
		o_WALK_ALONG_.iEndPathID = iEndPathID;
		o_WALK_ALONG_.iEndPathIDType = iEndPathIDType;
		o_WALK_ALONG_.iPatrolType = iPatrolType;
		o_WALK_ALONG_.iSpeedType = iSpeedType;
		o_WALK_ALONG_.Target = Target.Clone() as TargetParam;
		return o_WALK_ALONG_;
	}

	public void Read(BinaryReader br)
	{
		iWorldID = br.ReadInt32();
		iStartPathID = br.ReadInt32();
		iStartPathIDType = br.ReadInt32();
		iEndPathID = br.ReadInt32();
		iEndPathIDType = br.ReadInt32();
		iPatrolType = br.ReadInt32();
		iSpeedType = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!iWorldID.ToString().Contains(str) && !iStartPathID.ToString().Contains(str) && !iStartPathIDType.ToString().Contains(str) && !iEndPathID.ToString().Contains(str) && !iEndPathIDType.ToString().Contains(str) && !iPatrolType.ToString().Contains(str) && !iSpeedType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iWorldID);
		bw.Write(iStartPathID);
		bw.Write(iStartPathIDType);
		bw.Write(iEndPathID);
		bw.Write(iEndPathIDType);
		bw.Write(iPatrolType);
		bw.Write(iSpeedType);
		TargetStream.Save(bw, Target);
	}
}
