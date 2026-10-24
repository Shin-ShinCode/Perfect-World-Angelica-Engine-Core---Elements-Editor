using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ACE.Classes;

namespace ACE.Models;

public class PWMeshReader
{
	public static pwMeshContainer pwMesh;

	public static bool ReadFile(MemoryStream stream)
	{
		try
		{
			byte[] rawData = stream.ToArray();
			BinaryReader binaryReader_ = new BinaryReader(stream);
			pwMesh = new pwMeshContainer();
			pwMesh.RawData = rawData;
			if (!smethod_0(binaryReader_))
			{
				return false;
			}
			smethod_1(binaryReader_);
			smethod_2(binaryReader_);
			smethod_3(binaryReader_);
			smethod_4(binaryReader_);
			smethod_5(binaryReader_);
			smethod_7();
			return true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649115659));
			return false;
		}
	}

	private static bool smethod_0(BinaryReader binaryReader_0)
	{
		pwMesh.HeaderInfo = new pwHeaderInfo();
		pwMesh.HeaderInfo.Format = binaryReader_0.ReadBytes(8);
		string text = Encoding.ASCII.GetString(pwMesh.HeaderInfo.Format);
		if (!text.StartsWith(Class16.smethod_0(1648918753)))
		{
			return false;
		}
		pwMesh.HeaderInfo.Version = binaryReader_0.ReadInt32();
		pwMesh.HeaderInfo.SkinMeshCount = binaryReader_0.ReadUInt32();
		pwMesh.HeaderInfo.RigidMeshCount = binaryReader_0.ReadUInt32();
		pwMesh.HeaderInfo.MorphSkinMeshCount = binaryReader_0.ReadUInt32();
		pwMesh.HeaderInfo.MorphRigidMeshCount = binaryReader_0.ReadUInt32();
		pwMesh.HeaderInfo.TextureCount = binaryReader_0.ReadUInt32();
		pwMesh.HeaderInfo.MaterialCount = binaryReader_0.ReadUInt32();
		pwMesh.HeaderInfo.NumBones = binaryReader_0.ReadUInt32();
		pwMesh.HeaderInfo.MinWeight = binaryReader_0.ReadUInt32();
		pwMesh.HeaderInfo.NumSkeletonBones = binaryReader_0.ReadUInt32();
		pwMesh.HeaderInfo.Reserved = binaryReader_0.ReadBytes(60);
		return true;
	}

	private static void smethod_1(BinaryReader binaryReader_0)
	{
		if (pwMesh.HeaderInfo.Version < 9 || pwMesh.HeaderInfo.NumBones == 0)
		{
			return;
		}
		pwMesh.Joints = new pwJoints[pwMesh.HeaderInfo.NumBones];
		for (int i = 0; i < pwMesh.HeaderInfo.NumBones; i++)
		{
			pwMesh.Joints[i] = new pwJoints();
			int num = binaryReader_0.ReadInt32();
			if (num > 0 && num < 256)
			{
				pwMesh.Joints[i].Name = binaryReader_0.ReadBytes(num);
			}
		}
	}

	private static void smethod_2(BinaryReader binaryReader_0)
	{
		pwMesh.Textures = new pwTextures[pwMesh.HeaderInfo.TextureCount];
		for (int i = 0; i < pwMesh.HeaderInfo.TextureCount; i++)
		{
			pwMesh.Textures[i] = new pwTextures();
			int num = binaryReader_0.ReadInt32();
			if (num > 0 && num < 1024)
			{
				pwMesh.Textures[i].TexFileName = binaryReader_0.ReadBytes(num);
			}
		}
	}

	private static void smethod_3(BinaryReader binaryReader_0)
	{
		pwMesh.Materials = new pwMaterials[pwMesh.HeaderInfo.MaterialCount];
		for (int i = 0; i < pwMesh.HeaderInfo.MaterialCount; i++)
		{
			pwMesh.Materials[i] = new pwMaterials();
			pwMesh.Materials[i].MatHeader = binaryReader_0.ReadBytes(11);
			pwMesh.Materials[i].Values = new float[16];
			for (int j = 0; j < 16; j++)
			{
				pwMesh.Materials[i].Values[j] = binaryReader_0.ReadSingle();
			}
			pwMesh.Materials[i].Scale = binaryReader_0.ReadSingle();
			pwMesh.Materials[i].isClothing = binaryReader_0.ReadByte();
		}
	}

	private static void smethod_4(BinaryReader binaryReader_0)
	{
		int skinMeshCount = (int)pwMesh.HeaderInfo.SkinMeshCount;
		pwMesh.SkinMeshes = new pwObject[skinMeshCount];
		for (int i = 0; i < skinMeshCount; i++)
		{
			pwObject pwObject2 = new pwObject();
			pwObject2.Type = MeshType.Skin;
			int num = binaryReader_0.ReadInt32();
			if (num > 0 && num < 256)
			{
				pwObject2.MeshName = binaryReader_0.ReadBytes(num);
			}
			pwObject2.TextureIndex = binaryReader_0.ReadInt32();
			pwObject2.MaterialIndex = binaryReader_0.ReadInt32();
			pwObject2.VertexCount = binaryReader_0.ReadInt32();
			pwObject2.FaceVertsCount = binaryReader_0.ReadInt32();
			pwObject2.Vertices = new pwVertex[pwObject2.VertexCount];
			pwObject2.VertexWeight = new pwVertexWeight[pwObject2.VertexCount];
			pwObject2.BoneIndex = new pwBoneIndex[pwObject2.VertexCount];
			pwObject2.Normals = new pwNormal[pwObject2.VertexCount];
			pwObject2.UVs = new pwUV[pwObject2.VertexCount];
			for (int j = 0; j < pwObject2.VertexCount; j++)
			{
				pwObject2.Vertices[j] = new pwVertex(binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle());
				pwObject2.VertexWeight[j] = new pwVertexWeight(binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle());
				pwObject2.BoneIndex[j] = new pwBoneIndex(binaryReader_0.ReadByte(), binaryReader_0.ReadByte(), binaryReader_0.ReadByte(), binaryReader_0.ReadByte());
				pwObject2.Normals[j] = new pwNormal(binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle());
				pwObject2.UVs[j] = new pwUV(binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle());
			}
			int num2 = pwObject2.FaceVertsCount / 3;
			pwObject2.Faces = new pwFaces[num2];
			for (int k = 0; k < num2; k++)
			{
				pwObject2.Faces[k] = new pwFaces(binaryReader_0.ReadInt16(), binaryReader_0.ReadInt16(), binaryReader_0.ReadInt16());
			}
			smethod_6(binaryReader_0, pwObject2);
			pwMesh.SkinMeshes[i] = pwObject2;
		}
	}

	private static void smethod_5(BinaryReader binaryReader_0)
	{
		int rigidMeshCount = (int)pwMesh.HeaderInfo.RigidMeshCount;
		pwMesh.RigidMeshes = new pwObject[rigidMeshCount];
		for (int i = 0; i < rigidMeshCount; i++)
		{
			pwObject pwObject2 = new pwObject();
			pwObject2.Type = MeshType.Rigid;
			int num = binaryReader_0.ReadInt32();
			if (num > 0 && num < 256)
			{
				pwObject2.MeshName = binaryReader_0.ReadBytes(num);
			}
			pwObject2.RigidBoneIndex = binaryReader_0.ReadInt32();
			pwObject2.TextureIndex = binaryReader_0.ReadInt32();
			pwObject2.MaterialIndex = binaryReader_0.ReadInt32();
			pwObject2.VertexCount = binaryReader_0.ReadInt32();
			pwObject2.FaceVertsCount = binaryReader_0.ReadInt32();
			pwObject2.Vertices = new pwVertex[pwObject2.VertexCount];
			pwObject2.Normals = new pwNormal[pwObject2.VertexCount];
			pwObject2.UVs = new pwUV[pwObject2.VertexCount];
			for (int j = 0; j < pwObject2.VertexCount; j++)
			{
				pwObject2.Vertices[j] = new pwVertex(binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle());
				pwObject2.Normals[j] = new pwNormal(binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle());
				pwObject2.UVs[j] = new pwUV(binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle());
			}
			int num2 = pwObject2.FaceVertsCount / 3;
			pwObject2.Faces = new pwFaces[num2];
			for (int k = 0; k < num2; k++)
			{
				pwObject2.Faces[k] = new pwFaces(binaryReader_0.ReadInt16(), binaryReader_0.ReadInt16(), binaryReader_0.ReadInt16());
			}
			smethod_6(binaryReader_0, pwObject2);
			pwMesh.RigidMeshes[i] = pwObject2;
		}
	}

	private static void smethod_6(BinaryReader binaryReader_0, pwObject pwObject_0)
	{
		switch (pwMesh.HeaderInfo.Version)
		{
		case 201:
			if (binaryReader_0.ReadByte() != 0)
			{
				int num2 = 16 * pwObject_0.VertexCount;
				if (num2 > 0)
				{
					pwObject_0.Binormals = binaryReader_0.ReadBytes(num2);
				}
			}
			if (binaryReader_0.ReadByte() != 0)
			{
				int num3 = 8 * pwObject_0.VertexCount;
				if (num3 > 0)
				{
					pwObject_0.LightmapUVs = binaryReader_0.ReadBytes(num3);
				}
			}
			break;
		case 100:
		case 101:
		{
			int num = 16 * pwObject_0.VertexCount;
			if (num > 0)
			{
				pwObject_0.Binormals = binaryReader_0.ReadBytes(num);
			}
			break;
		}
		}
	}

	private static void smethod_7()
	{
		List<pwObject> list = new List<pwObject>();
		if (pwMesh.SkinMeshes != null)
		{
			list.AddRange(pwMesh.SkinMeshes);
		}
		if (pwMesh.RigidMeshes != null)
		{
			list.AddRange(pwMesh.RigidMeshes);
		}
		pwMesh.Objects = list.ToArray();
	}
}
