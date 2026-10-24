using System.Runtime.CompilerServices;

namespace ACE.Models;

public class pwHeaderInfo
{
	private byte[] byte_0;

	private int int_0;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private uint uint_8;

	private byte[] byte_1;

	public byte[] Format
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public int Version
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

	public uint SkinMeshCount
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

	public uint RigidMeshCount
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

	public uint MorphSkinMeshCount
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

	public uint MorphRigidMeshCount
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

	public uint TextureCount
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

	public uint MaterialCount
	{
		[CompilerGenerated]
		get
		{
			return uint_5;
		}
		[CompilerGenerated]
		set
		{
			uint_5 = value;
		}
	}

	public uint NumBones
	{
		[CompilerGenerated]
		get
		{
			return uint_6;
		}
		[CompilerGenerated]
		set
		{
			uint_6 = value;
		}
	}

	public uint MinWeight
	{
		[CompilerGenerated]
		get
		{
			return uint_7;
		}
		[CompilerGenerated]
		set
		{
			uint_7 = value;
		}
	}

	public uint NumSkeletonBones
	{
		[CompilerGenerated]
		get
		{
			return uint_8;
		}
		[CompilerGenerated]
		set
		{
			uint_8 = value;
		}
	}

	public byte[] Reserved
	{
		[CompilerGenerated]
		get
		{
			return byte_1;
		}
		[CompilerGenerated]
		set
		{
			byte_1 = value;
		}
	}

	public uint MeshCount => SkinMeshCount + RigidMeshCount;

	public uint JointCount => NumBones;
}
