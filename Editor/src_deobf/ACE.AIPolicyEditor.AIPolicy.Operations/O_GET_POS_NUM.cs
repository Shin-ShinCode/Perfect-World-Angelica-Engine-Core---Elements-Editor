using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_GET_POS_NUM : ICloneable, IOperation
{
	private uint uint_0;

	private uint uint_1;

	private TargetParam targetParam_0;

	private int int_0;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	[Browsable(false)]
	public int FromVersion => 24;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937836));

	[Browsable(false)]
	public int OperID => 39;

	[LocalizedDisplayName("pos")]
	[LocalizedCategory("OperationParam")]
	public uint pos
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	[LocalizedDisplayName("posType")]
	[LocalizedCategory("OperationParam")]
	public uint posType
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
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
	[LocalizedDisplayName("uNum")]
	public int uNum
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

	[LocalizedDisplayName("uuNumType")]
	[LocalizedCategory("OperationParam")]
	public uint uuNumType
	{
		[CompilerGenerated]
		get
		{
			return uint_2;
		}
		[CompilerGenerated]
		set
		{
			uint_2 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("varID")]
	public uint varID
	{
		[CompilerGenerated]
		get
		{
			return uint_3;
		}
		[CompilerGenerated]
		set
		{
			uint_3 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("varType")]
	public uint varType
	{
		[CompilerGenerated]
		get
		{
			return uint_4;
		}
		[CompilerGenerated]
		set
		{
			uint_4 = value;
		}
	}

	public O_GET_POS_NUM()
	{
		uNum = 0;
		uuNumType = 0u;
		pos = 0u;
		posType = 0u;
		varID = 0u;
		varType = 0u;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_GET_POS_NUM o_GET_POS_NUM = new O_GET_POS_NUM();
		o_GET_POS_NUM.uNum = uNum;
		o_GET_POS_NUM.uuNumType = uuNumType;
		o_GET_POS_NUM.pos = pos;
		o_GET_POS_NUM.posType = posType;
		o_GET_POS_NUM.varID = varID;
		o_GET_POS_NUM.varType = varType;
		o_GET_POS_NUM.Target = Target.Clone() as TargetParam;
		return o_GET_POS_NUM;
	}

	public void Read(BinaryReader br)
	{
		uNum = br.ReadInt32();
		uuNumType = br.ReadUInt32();
		pos = br.ReadUInt32();
		posType = br.ReadUInt32();
		varID = br.ReadUInt32();
		varType = br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!uNum.ToString().Contains(str) && !uuNumType.ToString().Contains(str) && !varID.ToString().Contains(str) && !varType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(uNum);
		bw.Write(uuNumType);
		bw.Write(pos);
		bw.Write(posType);
		bw.Write(varID);
		bw.Write(varType);
		TargetStream.Save(bw, Target);
	}
}
