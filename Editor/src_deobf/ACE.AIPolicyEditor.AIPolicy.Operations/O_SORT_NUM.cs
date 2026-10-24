using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SORT_NUM : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	private int int_0;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	[Browsable(false)]
	public int FromVersion => 24;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937074));

	[Browsable(false)]
	public int OperID => 38;

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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("uuNumType")]
	public uint uuNumType
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

	[LocalizedDisplayName("varID")]
	[LocalizedCategory("OperationParam")]
	public uint varID
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("varType")]
	public uint varType
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

	public O_SORT_NUM()
	{
		uNum = 0;
		uuNumType = 0u;
		varID = 0u;
		varType = 0u;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SORT_NUM o_SORT_NUM = new O_SORT_NUM();
		o_SORT_NUM.uNum = uNum;
		o_SORT_NUM.uuNumType = uuNumType;
		o_SORT_NUM.varID = varID;
		o_SORT_NUM.varType = varType;
		o_SORT_NUM.Target = Target.Clone() as TargetParam;
		return o_SORT_NUM;
	}

	public void Read(BinaryReader br)
	{
		uNum = br.ReadInt32();
		uuNumType = br.ReadUInt32();
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
		bw.Write(varID);
		bw.Write(varType);
		TargetStream.Save(bw, Target);
	}
}
