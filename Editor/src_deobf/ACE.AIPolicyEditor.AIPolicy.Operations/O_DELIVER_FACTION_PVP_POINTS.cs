using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_DELIVER_FACTION_PVP_POINTS : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	private FactionPVPPointType factionPVPPointType_0;

	[Browsable(false)]
	public int FromVersion => 20;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937766));

	[Browsable(false)]
	public int OperID => 22;

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

	[LocalizedDisplayName("Type")]
	[LocalizedCategory("OperationParam")]
	public FactionPVPPointType Type
	{
		[CompilerGenerated]
		get
		{
			return factionPVPPointType_0;
		}
		[CompilerGenerated]
		set
		{
			factionPVPPointType_0 = value;
		}
	}

	public O_DELIVER_FACTION_PVP_POINTS()
	{
		Type = FactionPVPPointType.MineCar;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_DELIVER_FACTION_PVP_POINTS o_DELIVER_FACTION_PVP_POINTS = new O_DELIVER_FACTION_PVP_POINTS();
		o_DELIVER_FACTION_PVP_POINTS.Type = Type;
		o_DELIVER_FACTION_PVP_POINTS.Target = Target.Clone() as TargetParam;
		return o_DELIVER_FACTION_PVP_POINTS;
	}

	public void Read(BinaryReader br)
	{
		Type = (FactionPVPPointType)br.ReadUInt32();
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
		bw.Write(Convert.ToUInt32(Type));
		TargetStream.Save(bw, Target);
	}
}
