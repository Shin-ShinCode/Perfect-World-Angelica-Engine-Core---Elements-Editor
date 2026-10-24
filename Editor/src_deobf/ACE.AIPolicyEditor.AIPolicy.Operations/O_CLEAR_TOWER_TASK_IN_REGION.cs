using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_CLEAR_TOWER_TASK_IN_REGION : ICloneable, IOperation
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 22;

	[LocalizedDisplayName("MaxX")]
	[LocalizedCategory("OperationParam")]
	public float MaxX
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

	[LocalizedDisplayName("MaxY")]
	[LocalizedCategory("OperationParam")]
	public float MaxY
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("MaxZ")]
	public float MaxZ
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

	[LocalizedDisplayName("MinX")]
	[LocalizedCategory("OperationParam")]
	public float MinX
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("MinY")]
	public float MinY
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

	[LocalizedDisplayName("MinZ")]
	[LocalizedCategory("OperationParam")]
	public float MinZ
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937717));

	[Browsable(false)]
	public int OperID => 33;

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

	public O_CLEAR_TOWER_TASK_IN_REGION()
	{
		MinX = 0f;
		MinY = 0f;
		MinZ = 0f;
		MaxX = 0f;
		MaxY = 0f;
		MaxZ = 0f;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_CLEAR_TOWER_TASK_IN_REGION o_CLEAR_TOWER_TASK_IN_REGION = new O_CLEAR_TOWER_TASK_IN_REGION();
		o_CLEAR_TOWER_TASK_IN_REGION.MinX = MinX;
		o_CLEAR_TOWER_TASK_IN_REGION.MinY = MinY;
		o_CLEAR_TOWER_TASK_IN_REGION.MinZ = MinZ;
		o_CLEAR_TOWER_TASK_IN_REGION.MaxX = MaxX;
		o_CLEAR_TOWER_TASK_IN_REGION.MaxY = MaxY;
		o_CLEAR_TOWER_TASK_IN_REGION.MaxZ = MaxZ;
		o_CLEAR_TOWER_TASK_IN_REGION.Target = Target.Clone() as TargetParam;
		return o_CLEAR_TOWER_TASK_IN_REGION;
	}

	public void Read(BinaryReader br)
	{
		MinX = br.ReadSingle();
		MinY = br.ReadSingle();
		MinZ = br.ReadSingle();
		MaxX = br.ReadSingle();
		MaxY = br.ReadSingle();
		MaxZ = br.ReadSingle();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!MinX.ToString().Contains(str) && !MinY.ToString().Contains(str) && !MinZ.ToString().Contains(str) && !MaxX.ToString().Contains(str) && !MaxY.ToString().Contains(str) && !MaxZ.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(MinX);
		bw.Write(MinY);
		bw.Write(MinZ);
		bw.Write(MaxX);
		bw.Write(MaxY);
		bw.Write(MaxZ);
		TargetStream.Save(bw, Target);
	}
}
