using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_WALK_ALONG_2 : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private MonsterPatrolType monsterPatrolType_0;

	private MonsterPatrolSpeedType monsterPatrolSpeedType_0;

	private TargetParam targetParam_0;

	private int int_2;

	[Browsable(false)]
	public int FromVersion => 20;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937282));

	[Browsable(false)]
	public int OperID => 25;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("PathID")]
	public int PathID
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
	[LocalizedDisplayName("PathIDType")]
	public int PathIDType
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

	[LocalizedDisplayName("PatrolType")]
	[LocalizedCategory("OperationParam")]
	public MonsterPatrolType PatrolType
	{
		[CompilerGenerated]
		get
		{
			return monsterPatrolType_0;
		}
		[CompilerGenerated]
		set
		{
			monsterPatrolType_0 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("SpeedType")]
	public MonsterPatrolSpeedType SpeedType
	{
		[CompilerGenerated]
		get
		{
			return monsterPatrolSpeedType_0;
		}
		[CompilerGenerated]
		set
		{
			monsterPatrolSpeedType_0 = value;
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("WorldID")]
	public int WorldID
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

	public O_WALK_ALONG_2()
	{
		WorldID = 0;
		PathID = 0;
		PathIDType = 0;
		PatrolType = MonsterPatrolType.StopAtEnd;
		SpeedType = MonsterPatrolSpeedType.Begin;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_WALK_ALONG_2 o_WALK_ALONG_ = new O_WALK_ALONG_2();
		o_WALK_ALONG_.WorldID = WorldID;
		o_WALK_ALONG_.PathID = PathID;
		o_WALK_ALONG_.PathIDType = PathIDType;
		o_WALK_ALONG_.PatrolType = PatrolType;
		o_WALK_ALONG_.SpeedType = SpeedType;
		o_WALK_ALONG_.Target = Target.Clone() as TargetParam;
		return o_WALK_ALONG_;
	}

	public void Read(BinaryReader br)
	{
		WorldID = br.ReadInt32();
		PathID = br.ReadInt32();
		PathIDType = br.ReadInt32();
		PatrolType = (MonsterPatrolType)br.ReadInt32();
		SpeedType = (MonsterPatrolSpeedType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!WorldID.ToString().Contains(str) && !PathID.ToString().Contains(str) && !PathIDType.ToString().Contains(str) && !PatrolType.ToString().Contains(str) && !SpeedType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(WorldID);
		bw.Write(PathID);
		bw.Write(PathIDType);
		bw.Write(Convert.ToUInt32(PatrolType));
		bw.Write(Convert.ToUInt32(SpeedType));
		TargetStream.Save(bw, Target);
	}
}
