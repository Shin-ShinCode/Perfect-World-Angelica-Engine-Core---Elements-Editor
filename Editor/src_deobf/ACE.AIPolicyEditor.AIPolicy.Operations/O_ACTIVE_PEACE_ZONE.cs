using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_ACTIVE_PEACE_ZONE : ICloneable, IOperation
{
	private int int_0;

	private PeaceZoneStrategyType peaceZoneStrategyType_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 100;

	[Browsable(false)]
	public int OperID => 206;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937496));

	[LocalizedDisplayName("StrategyID")]
	[LocalizedCategory("OperationParam")]
	public int StrategyID
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

	[LocalizedDisplayName("StrategyType")]
	[LocalizedCategory("OperationParam")]
	public PeaceZoneStrategyType StrategyType
	{
		[CompilerGenerated]
		get
		{
			return peaceZoneStrategyType_0;
		}
		[CompilerGenerated]
		set
		{
			peaceZoneStrategyType_0 = value;
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

	public O_ACTIVE_PEACE_ZONE()
	{
		StrategyID = 0;
		StrategyType = PeaceZoneStrategyType.PvPZone;
		Target = new TargetParam();
	}

	public void Read(BinaryReader br)
	{
		StrategyID = br.ReadInt32();
		StrategyType = (PeaceZoneStrategyType)br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(StrategyID);
		bw.Write(Convert.ToUInt32(StrategyType));
		TargetStream.Save(bw, Target);
	}

	public bool Search(string str)
	{
		if (!StrategyID.ToString().Contains(str) && !StrategyType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public object Clone()
	{
		O_ACTIVE_PEACE_ZONE o_ACTIVE_PEACE_ZONE = new O_ACTIVE_PEACE_ZONE();
		o_ACTIVE_PEACE_ZONE.StrategyID = StrategyID;
		o_ACTIVE_PEACE_ZONE.StrategyType = StrategyType;
		o_ACTIVE_PEACE_ZONE.Target = Target.Clone() as TargetParam;
		return o_ACTIVE_PEACE_ZONE;
	}
}
