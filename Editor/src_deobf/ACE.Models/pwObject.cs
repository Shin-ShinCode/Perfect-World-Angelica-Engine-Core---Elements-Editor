using System.Runtime.CompilerServices;

namespace ACE.Models;

public class pwObject
{
	private MeshType meshType_0;

	private byte[] byte_0;

	private int int_0;

	private int int_1;

	private int int_2 = -1;

	private int int_3;

	private int int_4;

	private pwVertex[] pwVertex_0;

	private pwVertexWeight[] pwVertexWeight_0;

	private pwBoneIndex[] pwBoneIndex_0;

	private pwNormal[] pwNormal_0;

	private pwUV[] pwUV_0;

	private pwFaces[] pwFaces_0;

	private byte[] byte_1;

	private byte[] byte_2;

	private byte[] byte_3;

	public MeshType Type
	{
		[CompilerGenerated]
		get
		{
			return meshType_0;
		}
		[CompilerGenerated]
		set
		{
			meshType_0 = value;
		}
	}

	public byte[] MeshName
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

	public int TextureIndex
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

	public int MaterialIndex
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

	public int RigidBoneIndex
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

	public int VertexCount
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

	public int FaceVertsCount
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

	public pwVertex[] Vertices
	{
		[CompilerGenerated]
		get
		{
			return pwVertex_0;
		}
		[CompilerGenerated]
		set
		{
			pwVertex_0 = value;
		}
	}

	public pwVertexWeight[] VertexWeight
	{
		[CompilerGenerated]
		get
		{
			return pwVertexWeight_0;
		}
		[CompilerGenerated]
		set
		{
			pwVertexWeight_0 = value;
		}
	}

	public pwBoneIndex[] BoneIndex
	{
		[CompilerGenerated]
		get
		{
			return pwBoneIndex_0;
		}
		[CompilerGenerated]
		set
		{
			pwBoneIndex_0 = value;
		}
	}

	public pwNormal[] Normals
	{
		[CompilerGenerated]
		get
		{
			return pwNormal_0;
		}
		[CompilerGenerated]
		set
		{
			pwNormal_0 = value;
		}
	}

	public pwUV[] UVs
	{
		[CompilerGenerated]
		get
		{
			return pwUV_0;
		}
		[CompilerGenerated]
		set
		{
			pwUV_0 = value;
		}
	}

	public pwFaces[] Faces
	{
		[CompilerGenerated]
		get
		{
			return pwFaces_0;
		}
		[CompilerGenerated]
		set
		{
			pwFaces_0 = value;
		}
	}

	public byte[] Binormals
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

	public byte[] LightmapUVs
	{
		[CompilerGenerated]
		get
		{
			return byte_2;
		}
		[CompilerGenerated]
		set
		{
			byte_2 = value;
		}
	}

	public byte[] ExtraData
	{
		[CompilerGenerated]
		get
		{
			return byte_3;
		}
		[CompilerGenerated]
		set
		{
			byte_3 = value;
		}
	}
}
