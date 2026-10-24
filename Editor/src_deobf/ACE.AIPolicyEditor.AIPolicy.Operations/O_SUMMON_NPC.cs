using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SUMMON_NPC : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private NpcID npcID_0;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 20;

	[LocalizedDisplayName("Life")]
	[LocalizedCategory("OperationParam")]
	public int Life
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

	[LocalizedDisplayName("LifeType")]
	[LocalizedCategory("OperationParam")]
	public int LifeType
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937151));

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("NPCID")]
	public NpcID NPCID
	{
		[CompilerGenerated]
		get
		{
			return npcID_0;
		}
		[CompilerGenerated]
		set
		{
			npcID_0 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("NPCIDType")]
	public int NPCIDType
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
	[LocalizedDisplayName("NPCNum")]
	public int NPCNum
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
	[LocalizedDisplayName("NPCNumType")]
	public int NPCNumType
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

	[Browsable(false)]
	public int OperID => 30;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("PathID")]
	public int PathID
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
	[LocalizedDisplayName("PathIDType")]
	public int PathIDType
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Range")]
	public int Range
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

	public O_SUMMON_NPC()
	{
		LifeType = 0;
		NPCID = new NpcID();
		NPCIDType = 0;
		Range = 0;
		Life = 0;
		PathID = 0;
		PathIDType = 0;
		NPCNum = 0;
		NPCNumType = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SUMMON_NPC o_SUMMON_NPC = new O_SUMMON_NPC();
		o_SUMMON_NPC.LifeType = LifeType;
		o_SUMMON_NPC.NPCID = NPCID;
		o_SUMMON_NPC.NPCIDType = NPCIDType;
		o_SUMMON_NPC.Range = Range;
		o_SUMMON_NPC.Life = Life;
		o_SUMMON_NPC.PathID = PathID;
		o_SUMMON_NPC.PathIDType = PathIDType;
		o_SUMMON_NPC.NPCNum = NPCNum;
		o_SUMMON_NPC.NPCNumType = NPCNumType;
		o_SUMMON_NPC.Target = Target.Clone() as TargetParam;
		return o_SUMMON_NPC;
	}

	public void Read(BinaryReader br)
	{
		LifeType = br.ReadInt32();
		NPCID = new NpcID
		{
			Value = br.ReadUInt32()
		};
		NPCIDType = br.ReadInt32();
		Range = br.ReadInt32();
		Life = br.ReadInt32();
		PathID = br.ReadInt32();
		PathIDType = br.ReadInt32();
		NPCNum = br.ReadInt32();
		NPCNumType = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!LifeType.ToString().Contains(str) && !NPCID.Value.ToString().Contains(str) && !NPCIDType.ToString().Contains(str) && !Range.ToString().Contains(str) && !Life.ToString().Contains(str) && !PathID.ToString().Contains(str) && !PathIDType.ToString().Contains(str) && !NPCNum.ToString().Contains(str) && !NPCNumType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(LifeType);
		bw.Write(NPCID.Value);
		bw.Write(NPCIDType);
		bw.Write(Range);
		bw.Write(Life);
		bw.Write(PathID);
		bw.Write(PathIDType);
		bw.Write(NPCNum);
		bw.Write(NPCNumType);
		TargetStream.Save(bw, Target);
	}
}
