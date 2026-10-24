using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACE.Models.ECM;

public class Skeleton
{
	public const string HEADER_SIGNATURE = "MOXBEKSA";

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private List<Bone> list_0 = new List<Bone>();

	private List<Bone> list_1 = new List<Bone>();

	private List<Joint> list_2 = new List<Joint>();

	private List<SkeletonHook> list_3 = new List<SkeletonHook>();

	private string string_0;

	private string string_1;

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

	public int NumBone
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

	public int NumJoint
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

	public int NumHook
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

	public int AnimStart
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

	public int AnimEnd
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

	public int AnimFPS
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

	public List<Bone> Bones
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

	public List<Bone> RootBones
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public List<Joint> Joints
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
		[CompilerGenerated]
		set
		{
			list_2 = value;
		}
	}

	public List<SkeletonHook> Hooks
	{
		[CompilerGenerated]
		get
		{
			return list_3;
		}
		[CompilerGenerated]
		set
		{
			list_3 = value;
		}
	}

	public string FilePath
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

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public int TotalFrames => AnimEnd - AnimStart + 1;

	public static Skeleton Load(byte[] data, string filePath = null)
	{
		if (data != null && data.Length >= 8)
		{
			MemoryStream memoryStream = new MemoryStream(data);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					return Load(binaryReader, filePath);
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		return null;
	}

	public static Skeleton Load(BinaryReader reader, string filePath = null)
	{
		Skeleton skeleton = new Skeleton();
		skeleton.FilePath = filePath;
		if (!string.IsNullOrEmpty(filePath))
		{
			skeleton.Name = System.IO.Path.GetFileNameWithoutExtension(filePath);
		}
		if (reader.BaseStream.Length - reader.BaseStream.Position < 8L)
		{
			return null;
		}
		byte[] bytes = reader.ReadBytes(8);
		string text = Encoding.ASCII.GetString(bytes);
		if (!text.StartsWith(Class16.smethod_0(1648918753)))
		{
			return null;
		}
		if (reader.BaseStream.Length - reader.BaseStream.Position < 28L)
		{
			return null;
		}
		skeleton.Version = reader.ReadInt32();
		skeleton.NumBone = reader.ReadInt32();
		skeleton.NumJoint = reader.ReadInt32();
		skeleton.NumHook = reader.ReadInt32();
		skeleton.AnimStart = reader.ReadInt32();
		skeleton.AnimEnd = reader.ReadInt32();
		skeleton.AnimFPS = reader.ReadInt32();
		if (reader.BaseStream.Length - reader.BaseStream.Position < 64L)
		{
			return null;
		}
		reader.ReadBytes(64);
		for (int i = 0; i < skeleton.NumBone; i++)
		{
			Bone bone = Bone.Read(reader, i);
			skeleton.Bones.Add(bone);
			if (bone.ParentBone < 0)
			{
				skeleton.RootBones.Add(bone);
			}
		}
		if (skeleton.NumJoint > 0)
		{
			int[] array = new int[skeleton.NumJoint];
			for (int j = 0; j < skeleton.NumJoint; j++)
			{
				array[j] = reader.ReadInt32();
			}
			for (int k = 0; k < skeleton.NumJoint; k++)
			{
				Joint joint = new Joint(array[k]);
				joint.JointIndex = k;
				joint.Read(reader);
				skeleton.Joints.Add(joint);
			}
		}
		for (int l = 0; l < skeleton.NumHook; l++)
		{
			try
			{
				skeleton.Hooks.Add(SkeletonHook.Read(reader));
			}
			catch (EndOfStreamException)
			{
				skeleton.NumHook = l;
				break;
			}
		}
		return skeleton;
	}

	public int GetBoneByName(string name)
	{
		int num = 0;
		while (true)
		{
			if (num < Bones.Count)
			{
				if (Bones[num].Name == name)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}
}
