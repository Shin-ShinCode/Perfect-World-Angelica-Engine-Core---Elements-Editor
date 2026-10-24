using System.Runtime.CompilerServices;
using System.Text;
using ACE.Models.ECM;

namespace ACE.Models;

public class pwMeshContainer
{
	private pwHeaderInfo pwHeaderInfo_0;

	private pwJoints[] pwJoints_0;

	private pwTextures[] pwTextures_0;

	private pwMaterials[] pwMaterials_0;

	private pwObject[] pwObject_0;

	private pwObject[] pwObject_1;

	private pwObject[] pwObject_2;

	private byte[] byte_0;

	private int[] int_0;

	public pwHeaderInfo HeaderInfo
	{
		[CompilerGenerated]
		get
		{
			return pwHeaderInfo_0;
		}
		[CompilerGenerated]
		set
		{
			pwHeaderInfo_0 = value;
		}
	}

	public pwJoints[] Joints
	{
		[CompilerGenerated]
		get
		{
			return pwJoints_0;
		}
		[CompilerGenerated]
		set
		{
			pwJoints_0 = value;
		}
	}

	public pwTextures[] Textures
	{
		[CompilerGenerated]
		get
		{
			return pwTextures_0;
		}
		[CompilerGenerated]
		set
		{
			pwTextures_0 = value;
		}
	}

	public pwMaterials[] Materials
	{
		[CompilerGenerated]
		get
		{
			return pwMaterials_0;
		}
		[CompilerGenerated]
		set
		{
			pwMaterials_0 = value;
		}
	}

	public pwObject[] SkinMeshes
	{
		[CompilerGenerated]
		get
		{
			return pwObject_0;
		}
		[CompilerGenerated]
		set
		{
			pwObject_0 = value;
		}
	}

	public pwObject[] RigidMeshes
	{
		[CompilerGenerated]
		get
		{
			return pwObject_1;
		}
		[CompilerGenerated]
		set
		{
			pwObject_1 = value;
		}
	}

	public pwObject[] Objects
	{
		[CompilerGenerated]
		get
		{
			return pwObject_2;
		}
		[CompilerGenerated]
		set
		{
			pwObject_2 = value;
		}
	}

	public byte[] RawData
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

	public int[] BoneIndexMap
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

	public void BindSkeleton(Skeleton skeleton)
	{
		if (skeleton == null)
		{
			return;
		}
		int num = (int)((HeaderInfo.Version >= 9) ? HeaderInfo.NumBones : HeaderInfo.NumSkeletonBones);
		BoneIndexMap = new int[num + 1];
		if (HeaderInfo.Version < 9)
		{
			for (int i = 0; i < num; i++)
			{
				BoneIndexMap[i] = i;
			}
		}
		else
		{
			for (int j = 0; j < Joints?.Length && j < num; j++)
			{
				string name = string.Empty;
				if (Joints[j]?.Name != null)
				{
					name = Encoding.GetEncoding(936).GetString(Joints[j].Name).TrimEnd(default(char));
				}
				int boneByName = skeleton.GetBoneByName(name);
				BoneIndexMap[j] = ((boneByName >= 0) ? boneByName : 0);
			}
		}
		BoneIndexMap[num] = skeleton.Bones.Count;
	}

	public int GetRemappedBoneIndex(int skiIndex)
	{
		if (BoneIndexMap != null && skiIndex >= 0 && skiIndex < BoneIndexMap.Length)
		{
			return BoneIndexMap[skiIndex];
		}
		return skiIndex;
	}
}
