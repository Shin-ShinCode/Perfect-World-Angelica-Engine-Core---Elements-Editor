using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACE.Models.ECM;

public class Bone
{
	public const int FAKEBONE = 1;

	public const int FLIPPED = 2;

	private string string_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private Matrix4x4 matrix4x4_0;

	private Matrix4x4 matrix4x4_1;

	private List<int> list_0 = new List<int>();

	private int int_4;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int BoneFlags
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

	public int ParentBone
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

	public int FirstJoint
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

	public int NumChild
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

	public Matrix4x4 RelativeMatrix
	{
		[CompilerGenerated]
		get
		{
			return matrix4x4_0;
		}
		[CompilerGenerated]
		set
		{
			matrix4x4_0 = value;
		}
	}

	public Matrix4x4 InitialBoneMatrix
	{
		[CompilerGenerated]
		get
		{
			return matrix4x4_1;
		}
		[CompilerGenerated]
		set
		{
			matrix4x4_1 = value;
		}
	}

	public List<int> ChildBones
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public int Index
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

	public bool IsFlipped => (BoneFlags & 2) != 0;

	public bool IsFakeBone => (BoneFlags & 1) != 0;

	public static Bone Read(BinaryReader reader, int index)
	{
		Bone bone = new Bone();
		bone.Index = index;
		int num = reader.ReadInt32();
		if (num > 0 && num < 256)
		{
			byte[] bytes = reader.ReadBytes(num);
			bone.Name = Encoding.GetEncoding(936).GetString(bytes);
		}
		else
		{
			bone.Name = string.Format(Class16.smethod_0(1649123015), index);
		}
		bone.BoneFlags = reader.ReadInt32();
		bone.ParentBone = reader.ReadInt32();
		bone.FirstJoint = reader.ReadInt32();
		bone.NumChild = reader.ReadInt32();
		bone.RelativeMatrix = Matrix4x4.Read(reader);
		bone.InitialBoneMatrix = Matrix4x4.Read(reader);
		for (int i = 0; i < bone.NumChild; i++)
		{
			bone.ChildBones.Add(reader.ReadInt32());
		}
		return bone;
	}
}
