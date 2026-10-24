using System;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations;

namespace ACE.AIPolicyEditor.AIPolicy;

public class POLICY_CONTROLLER_LIST
{
	private int int_0;

	private VarType varType_0;

	[LocalizedDisplayName("uID")]
	[LocalizedCategory("ControllersParam")]
	public int uID
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

	[LocalizedCategory("ControllersParam")]
	[LocalizedDisplayName("uIDType")]
	public VarType uIDType
	{
		[CompilerGenerated]
		get
		{
			return varType_0;
		}
		[CompilerGenerated]
		set
		{
			varType_0 = value;
		}
	}

	public static POLICY_CONTROLLER_LIST Read(BinaryReader br)
	{
		return new POLICY_CONTROLLER_LIST
		{
			uID = br.ReadInt32(),
			uIDType = (VarType)br.ReadInt32()
		};
	}

	public static void Write(BinaryWriter bw, POLICY_CONTROLLER_LIST param)
	{
		bw.Write(param.uID);
		bw.Write(Convert.ToUInt32(param.uIDType));
	}

	public POLICY_CONTROLLER_LIST Copy()
	{
		return new POLICY_CONTROLLER_LIST
		{
			uID = uID,
			uIDType = uIDType
		};
	}

	public override string ToString()
	{
		return string.Format(Class16.smethod_0(1648937398), uID, uIDType);
	}
}
