using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_BOSS_RUSH_END : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private TargetParam targetParam_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	[Browsable(false)]
	public int FromVersion => 33;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("id")]
	public int id
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

	[LocalizedDisplayName("interfaces")]
	[LocalizedCategory("OperationParam")]
	public int interfaces
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
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937586));

	[Browsable(false)]
	public int OperID => 66;

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
	[LocalizedDisplayName("zvMax_X")]
	public float zvMax_X
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("zvMax_Y")]
	public float zvMax_Y
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	[LocalizedDisplayName("zvMax_Z")]
	[LocalizedCategory("OperationParam")]
	public float zvMax_Z
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	[LocalizedDisplayName("zvMin_X")]
	[LocalizedCategory("OperationParam")]
	public float zvMin_X
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	[LocalizedDisplayName("zvMin_Y")]
	[LocalizedCategory("OperationParam")]
	public float zvMin_Y
	{
		[CompilerGenerated]
		get
		{
			return float_4;
		}
		[CompilerGenerated]
		set
		{
			float_4 = value;
		}
	}

	[LocalizedDisplayName("zvMin_Z")]
	[LocalizedCategory("OperationParam")]
	public float zvMin_Z
	{
		[CompilerGenerated]
		get
		{
			return float_5;
		}
		[CompilerGenerated]
		set
		{
			float_5 = value;
		}
	}

	public O_BOSS_RUSH_END()
	{
		id = 0;
		interfaces = 0;
		zvMin_X = 0f;
		zvMin_Y = 0f;
		zvMin_Z = 0f;
		zvMax_X = 0f;
		zvMax_Y = 0f;
		zvMax_Z = 0f;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_BOSS_RUSH_END o_BOSS_RUSH_END = new O_BOSS_RUSH_END();
		o_BOSS_RUSH_END.id = id;
		o_BOSS_RUSH_END.interfaces = interfaces;
		o_BOSS_RUSH_END.Target = Target.Clone() as TargetParam;
		return o_BOSS_RUSH_END;
	}

	public void Read(BinaryReader br)
	{
		id = br.ReadInt32();
		interfaces = br.ReadInt32();
		zvMin_X = br.ReadSingle();
		zvMin_Y = br.ReadSingle();
		zvMin_Z = br.ReadSingle();
		zvMax_X = br.ReadSingle();
		zvMax_Y = br.ReadSingle();
		zvMax_Z = br.ReadSingle();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!id.ToString().Contains(str) && !interfaces.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(id);
		bw.Write(interfaces);
		bw.Write(zvMin_X);
		bw.Write(zvMin_Y);
		bw.Write(zvMin_Z);
		bw.Write(zvMax_X);
		bw.Write(zvMax_Y);
		bw.Write(zvMax_Z);
		TargetStream.Save(bw, Target);
	}
}
