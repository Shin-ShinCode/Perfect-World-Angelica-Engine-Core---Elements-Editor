using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using SharpDX;
// TODO(recovered): disambiguation aliases (decompiled file mixes SharpDX + System.Drawing).
using Color = System.Drawing.Color;

namespace ACE.PWMap;

internal static class PwMapSceneLightFile
{
	internal sealed class SceneLight
	{
		public Vector3 Location;

		public float Range;

		public float Attenuation;

		public float Attenuation2;

		public float Attenuation3;

		public Vector4 Ambient;

		public Vector4 Diffuse;

		public int Flags;

		public int Type = 1;

		public Vector4 Specular;

		public Vector3 Direction;

		public float Falloff;

		public float Theta;

		public float Phi;

		public int Version;

		public const int DayOnly = 0;

		public const int NightOnly = 1;

		public const int Both = 2;

		public Color DiffuseColor => Color.FromArgb(255, (int)(Diffuse.X * 255f), (int)(Diffuse.Y * 255f), (int)(Diffuse.Z * 255f));

		public string ModeLabel => Flags switch
		{
			1 => Class16.smethod_0(1648915231), 
			0 => Class16.smethod_0(1648941238), 
			_ => Class16.smethod_0(1649084009), 
		};
	}

	internal sealed class SceneLightCollection
	{
		private readonly List<SceneLight> list_0 = new List<SceneLight>();

		private int int_0;

		public List<SceneLight> Lights
		{
			[CompilerGenerated]
			get
			{
				return list_0;
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
	}

	public static SceneLightCollection Load(byte[] bytes)
	{
		SceneLightCollection sceneLightCollection = new SceneLightCollection();
		if (bytes != null && bytes.Length >= 8)
		{
			MemoryStream memoryStream = new MemoryStream(bytes, writable: false);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					int num = binaryReader.ReadInt32();
					int num2;
					int num3;
					if (num == -2147483647)
					{
						num2 = binaryReader.ReadInt32();
						num3 = 1;
					}
					else
					{
						num2 = num;
						num3 = 2;
					}
					sceneLightCollection.Version = num3;
					if (num2 > 0 && num2 <= 100000)
					{
						for (int i = 0; i < num2; i++)
						{
							if (memoryStream.Position >= memoryStream.Length - 4L)
							{
								break;
							}
							SceneLight sceneLight = smethod_0(binaryReader, num3);
							if (sceneLight != null)
							{
								sceneLightCollection.Lights.Add(sceneLight);
							}
						}
						return sceneLightCollection;
					}
					return sceneLightCollection;
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
		return sceneLightCollection;
	}

	public static SceneLightCollection LoadFromPath(string filePath)
	{
		byte[] array = PwMapAssetProvider.ReadFileOrPckBytes(filePath);
		if (array == null)
		{
			return new SceneLightCollection();
		}
		return Load(array);
	}

	private static SceneLight smethod_0(BinaryReader binaryReader_0, int int_0)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		SceneLight sceneLight = new SceneLight
		{
			Version = int_0
		};
		try
		{
			if (int_0 == 1)
			{
				sceneLight.Location = smethod_1(binaryReader_0);
				sceneLight.Range = binaryReader_0.ReadSingle();
				sceneLight.Attenuation = binaryReader_0.ReadSingle();
				sceneLight.Attenuation2 = binaryReader_0.ReadSingle();
				sceneLight.Attenuation3 = binaryReader_0.ReadSingle();
				sceneLight.Diffuse = smethod_2(binaryReader_0);
				sceneLight.Ambient = smethod_2(binaryReader_0);
				binaryReader_0.BaseStream.Position += 48L;
				sceneLight.Flags = binaryReader_0.ReadInt32();
			}
			else
			{
				sceneLight.Flags = binaryReader_0.ReadInt32();
				sceneLight.Type = binaryReader_0.ReadInt32();
				sceneLight.Diffuse = smethod_2(binaryReader_0);
				sceneLight.Specular = smethod_2(binaryReader_0);
				sceneLight.Ambient = smethod_2(binaryReader_0);
				sceneLight.Location = smethod_1(binaryReader_0);
				sceneLight.Direction = smethod_1(binaryReader_0);
				sceneLight.Range = binaryReader_0.ReadSingle();
				sceneLight.Falloff = binaryReader_0.ReadSingle();
				sceneLight.Attenuation = binaryReader_0.ReadSingle();
				sceneLight.Attenuation2 = binaryReader_0.ReadSingle();
				sceneLight.Attenuation3 = binaryReader_0.ReadSingle();
				sceneLight.Theta = binaryReader_0.ReadSingle();
				sceneLight.Phi = binaryReader_0.ReadSingle();
			}
			sceneLight.Location = new Vector3(sceneLight.Location.X, sceneLight.Location.Y, 0f - sceneLight.Location.Z);
			return sceneLight;
		}
		catch
		{
			return null;
		}
	}

	private static Vector3 smethod_1(BinaryReader binaryReader_0)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		float num = binaryReader_0.ReadSingle();
		float num2 = binaryReader_0.ReadSingle();
		float num3 = binaryReader_0.ReadSingle();
		return new Vector3(num, num2, num3);
	}

	private static Vector4 smethod_2(BinaryReader binaryReader_0)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		float num = binaryReader_0.ReadSingle();
		float num2 = binaryReader_0.ReadSingle();
		float num3 = binaryReader_0.ReadSingle();
		float num4 = binaryReader_0.ReadSingle();
		return new Vector4(num, num2, num3, num4);
	}

	public static void Save(SceneLightCollection collection, string outputPath)
	{
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			try
			{
				int version = collection.Version;
				if (version == 1)
				{
					binaryWriter.Write(-2147483647);
				}
				binaryWriter.Write(collection.Lights.Count);
				Vector3 vector3_ = default(Vector3);
				foreach (SceneLight light in collection.Lights)
				{
					vector3_ = new Vector3(light.Location.X, light.Location.Y, 0f - light.Location.Z);
					if (version == 1)
					{
						smethod_3(binaryWriter, vector3_);
						binaryWriter.Write(light.Range);
						binaryWriter.Write(light.Attenuation);
						binaryWriter.Write(light.Attenuation2);
						binaryWriter.Write(light.Attenuation3);
						smethod_4(binaryWriter, light.Diffuse);
						smethod_4(binaryWriter, light.Ambient);
						smethod_5(binaryWriter, vector3_, light.Range);
						binaryWriter.Write(light.Flags);
					}
					else
					{
						binaryWriter.Write(light.Flags);
						binaryWriter.Write(light.Type);
						smethod_4(binaryWriter, light.Diffuse);
						smethod_4(binaryWriter, light.Specular);
						smethod_4(binaryWriter, light.Ambient);
						smethod_3(binaryWriter, vector3_);
						smethod_3(binaryWriter, light.Direction);
						binaryWriter.Write(light.Range);
						binaryWriter.Write(light.Falloff);
						binaryWriter.Write(light.Attenuation);
						binaryWriter.Write(light.Attenuation2);
						binaryWriter.Write(light.Attenuation3);
						binaryWriter.Write(light.Theta);
						binaryWriter.Write(light.Phi);
					}
				}
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}

	private static void smethod_3(BinaryWriter binaryWriter_0, Vector3 vector3_0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		binaryWriter_0.Write(vector3_0.X);
		binaryWriter_0.Write(vector3_0.Y);
		binaryWriter_0.Write(vector3_0.Z);
	}

	private static void smethod_4(BinaryWriter binaryWriter_0, Vector4 vector4_0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		binaryWriter_0.Write(vector4_0.X);
		binaryWriter_0.Write(vector4_0.Y);
		binaryWriter_0.Write(vector4_0.Z);
		binaryWriter_0.Write(vector4_0.W);
	}

	private static void smethod_5(BinaryWriter binaryWriter_0, Vector3 vector3_0, float float_0)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = default(Vector3);
		val = new Vector3(float_0, float_0, float_0);
		Vector3 vector3_1 = vector3_0 - val;
		Vector3 vector3_2 = vector3_0 + val;
		smethod_3(binaryWriter_0, vector3_1);
		smethod_3(binaryWriter_0, vector3_2);
		smethod_3(binaryWriter_0, vector3_0);
		smethod_3(binaryWriter_0, val);
	}
}
