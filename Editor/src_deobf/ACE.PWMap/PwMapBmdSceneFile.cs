using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using SharpDX;

namespace ACE.PWMap;

internal sealed class PwMapBmdSceneFile
{
	private sealed class Class294
	{
		public float float_0;

		public float float_1;

		public float float_2;

		public float float_3;

		public float float_4;

		public float float_5;

		public float float_6;

		public float float_7;

		public float float_8;

		public float float_9;

		public float float_10;

		public float float_11;
	}

	internal sealed class Mesh
	{
		public Vector3[] Vertices = Array.Empty<Vector3>();

		public Vector3[] Normals = Array.Empty<Vector3>();

		public Vector2[] TexCoords = Array.Empty<Vector2>();

		public int[] DiffuseColors = Array.Empty<int>();

		public short[] Indices = Array.Empty<short>();

		public string TexturePath = string.Empty;
	}

	private string string_0 = string.Empty;

	private readonly List<Mesh> list_0 = new List<Mesh>(8);

	private Vector3 vector3_0 = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

	private Vector3 vector3_1 = new Vector3(float.MinValue, float.MinValue, float.MinValue);

	private bool bool_0;

	private bool bool_1;

	public string FilePath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public List<Mesh> Meshes
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}

	public Vector3 BoundsMin
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return vector3_0;
		}
	}

	public Vector3 BoundsMax
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return vector3_1;
		}
	}

	public bool HasBounds
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
	}

	public bool IsSharedData
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
	}

	private void method_0(string string_1)
	{
		string_0 = string_1;
	}

	private void method_1(Vector3 vector3_2)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		vector3_0 = vector3_2;
	}

	private void method_2(Vector3 vector3_2)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		vector3_1 = vector3_2;
	}

	private void method_3(bool bool_2)
	{
		bool_0 = bool_2;
	}

	private void method_4(bool bool_2)
	{
		bool_1 = bool_2;
	}

	public static PwMapBmdSceneFile Load(string filePath)
	{
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(filePath))
		{
			return null;
		}
		try
		{
			PwMapBmdSceneFile pwMapBmdSceneFile = new PwMapBmdSceneFile();
			pwMapBmdSceneFile.method_0(filePath);
			using Stream stream = smethod_0(filePath);
			if (stream != null)
			{
				BinaryReader binaryReader = new BinaryReader(stream);
				try
				{
					if (smethod_18(binaryReader, 4L) && smethod_14(binaryReader, out var int_))
					{
						int int_2;
						if (int_ == -2147483647)
						{
							if (!smethod_18(binaryReader, 1L) || !smethod_14(binaryReader, out int_2))
							{
								return null;
							}
						}
						else
						{
							int_2 = int_;
						}
						Class294 class294_ = new Class294();
						if (!smethod_7(binaryReader, class294_))
						{
							return null;
						}
						if (int_2 >= 268436228 && !smethod_18(binaryReader, 4L))
						{
							return null;
						}
						if (smethod_14(binaryReader, out var int_3) && int_3 >= 0 && int_3 <= 20000)
						{
							bool flag = false;
							bool flag2 = false;
							if (int_2 >= 268436224)
							{
								if (!smethod_17(binaryReader, out var byte_) || !smethod_17(binaryReader, out var byte_2))
								{
									return null;
								}
								flag = byte_ != 0;
								flag2 = byte_2 != 0;
							}
							if (flag2)
							{
								pwMapBmdSceneFile.method_4(bool_2: true);
								return pwMapBmdSceneFile;
							}
							for (int i = 0; i < int_3; i++)
							{
								Mesh mesh = smethod_1(binaryReader, int_2);
								if (mesh == null)
								{
									break;
								}
								if (mesh.Vertices.Length != 0 && mesh.Indices.Length > 2)
								{
									pwMapBmdSceneFile.Meshes.Add(mesh);
								}
							}
							if (pwMapBmdSceneFile.Meshes.Count == 0 && int_3 > 0)
							{
								return pwMapBmdSceneFile;
							}
							try
							{
								if (int_2 >= 268436224 && (!flag || (smethod_9(binaryReader) && smethod_9(binaryReader))) && smethod_14(binaryReader, out var int_4) && int_4 >= 4)
								{
									smethod_18(binaryReader, int_4 - 4L);
								}
							}
							catch
							{
							}
							smethod_4(class294_, out var vector3_, out var vector3_2, out var vector3_3);
							for (int j = 0; j < pwMapBmdSceneFile.Meshes.Count; j++)
							{
								Mesh mesh2 = pwMapBmdSceneFile.Meshes[j];
								for (int k = 0; k < mesh2.Vertices.Length; k++)
								{
									Vector3 val = smethod_5(mesh2.Vertices[k], class294_, vector3_, vector3_2, vector3_3);
									mesh2.Vertices[k] = val;
									pwMapBmdSceneFile.method_5(val);
								}
								for (int l = 0; l < mesh2.Normals.Length; l++)
								{
									mesh2.Normals[l] = smethod_6(mesh2.Normals[l], class294_, vector3_, vector3_2, vector3_3);
								}
							}
							return pwMapBmdSceneFile;
						}
						return null;
					}
					return null;
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			return null;
		}
		catch
		{
			return null;
		}
	}

	private static Stream smethod_0(string string_1)
	{
		if (string.IsNullOrWhiteSpace(string_1))
		{
			return null;
		}
		if (File.Exists(string_1))
		{
			try
			{
				return File.OpenRead(string_1);
			}
			catch
			{
				return null;
			}
		}
		byte[] array = PwMapAssetProvider.ReadPckBytes(string_1);
		if (array != null && array.Length != 0)
		{
			return new MemoryStream(array, writable: false);
		}
		return null;
	}

	private static Mesh smethod_1(BinaryReader binaryReader_0, int int_0)
	{
		if (int_0 < 268436224)
		{
			return smethod_3(binaryReader_0);
		}
		return smethod_2(binaryReader_0, int_0);
	}

	private static Mesh smethod_2(BinaryReader binaryReader_0, int int_0)
	{
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		if (smethod_17(binaryReader_0, out var byte_) && smethod_17(binaryReader_0, out var byte_2))
		{
			bool flag = byte_ != 0;
			bool flag2 = byte_2 != 0;
			if (smethod_10(binaryReader_0, out var _) && smethod_10(binaryReader_0, out var string_2))
			{
				if (smethod_14(binaryReader_0, out var int_1) && smethod_14(binaryReader_0, out var int_2))
				{
					if (int_1 >= 0 && int_1 <= 2000000 && int_2 >= 0 && int_2 <= 2000000)
					{
						Mesh mesh = new Mesh();
						mesh.Vertices = (Vector3[])(object)new Vector3[int_1];
						mesh.Normals = (Vector3[])(object)new Vector3[int_1];
						mesh.TexCoords = (Vector2[])(object)new Vector2[int_1];
						mesh.DiffuseColors = new int[int_1];
						mesh.Indices = new short[int_2 * 3];
						mesh.TexturePath = smethod_12(string_2);
						Mesh mesh2 = mesh;
						int num = 0;
						while (true)
						{
							if (num < int_1)
							{
								if (!smethod_15(binaryReader_0, out var float_) || !smethod_15(binaryReader_0, out var float_2) || !smethod_15(binaryReader_0, out var float_3) || !smethod_14(binaryReader_0, out var int_3) || !smethod_15(binaryReader_0, out var float_4) || !smethod_15(binaryReader_0, out var float_5))
								{
									break;
								}
								mesh2.Vertices[num] = new Vector3(float_, float_2, float_3);
								mesh2.DiffuseColors[num] = int_3;
								mesh2.TexCoords[num] = new Vector2(float_4, float_5);
								num++;
								continue;
							}
							int num2 = 0;
							while (true)
							{
								if (num2 < int_2)
								{
									if (!smethod_16(binaryReader_0, out var short_) || !smethod_16(binaryReader_0, out var short_2) || !smethod_16(binaryReader_0, out var short_3))
									{
										break;
									}
									int num3 = num2 * 3;
									mesh2.Indices[num3] = short_3;
									mesh2.Indices[num3 + 1] = short_2;
									mesh2.Indices[num3 + 2] = short_;
									num2++;
									continue;
								}
								int num4 = 0;
								while (true)
								{
									if (num4 < int_1)
									{
										if (!smethod_15(binaryReader_0, out var float_6) || !smethod_15(binaryReader_0, out var float_7) || !smethod_15(binaryReader_0, out var float_8))
										{
											break;
										}
										mesh2.Normals[num4] = new Vector3(float_6, float_7, float_8);
										num4++;
										continue;
									}
									if (int_0 >= 268436226 && !smethod_18(binaryReader_0, int_2 * 6L))
									{
										return null;
									}
									if (int_0 >= 268436228 && !smethod_18(binaryReader_0, 16L))
									{
										return null;
									}
									if (!smethod_8(binaryReader_0))
									{
										return null;
									}
									if (flag && !smethod_18(binaryReader_0, int_1 * 8L))
									{
										return null;
									}
									if ((!flag || !flag2) && !smethod_18(binaryReader_0, int_1 * 8L))
									{
										return null;
									}
									if (!smethod_18(binaryReader_0, 48L))
									{
										return null;
									}
									if (smethod_14(binaryReader_0, out var int_4) && int_4 >= 4 && smethod_18(binaryReader_0, int_4 - 4L))
									{
										return mesh2;
									}
									return null;
								}
								return null;
							}
							return null;
						}
						return null;
					}
					return null;
				}
				return null;
			}
			return null;
		}
		return null;
	}

	private static Mesh smethod_3(BinaryReader binaryReader_0)
	{
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		if (!smethod_14(binaryReader_0, out var int_))
		{
			return null;
		}
		if (int_ < 268435458)
		{
			return null;
		}
		byte[] byte_ = new byte[64];
		if (!smethod_13(binaryReader_0, byte_))
		{
			return null;
		}
		byte[] byte_2 = new byte[256];
		if (!smethod_13(binaryReader_0, byte_2))
		{
			return null;
		}
		if (smethod_14(binaryReader_0, out var int_2) && smethod_14(binaryReader_0, out var int_3))
		{
			if (int_2 >= 0 && int_2 <= 2000000 && int_3 >= 0 && int_3 <= 2000000)
			{
				byte byte_3 = 0;
				if (int_ >= 268435462 && !smethod_17(binaryReader_0, out byte_3))
				{
					return null;
				}
				Mesh mesh = new Mesh();
				mesh.Vertices = (Vector3[])(object)new Vector3[int_2];
				mesh.Normals = (Vector3[])(object)new Vector3[int_2];
				mesh.TexCoords = (Vector2[])(object)new Vector2[int_2];
				mesh.DiffuseColors = new int[int_2];
				mesh.Indices = new short[int_3 * 3];
				mesh.TexturePath = smethod_12(smethod_11(byte_2));
				Mesh mesh2 = mesh;
				int num = 0;
				while (true)
				{
					if (num < int_2)
					{
						if (!smethod_15(binaryReader_0, out var float_) || !smethod_15(binaryReader_0, out var float_2) || !smethod_15(binaryReader_0, out var float_3) || !smethod_14(binaryReader_0, out var int_4))
						{
							break;
						}
						if ((int_ != 268435458 && int_ != 268435459) || smethod_18(binaryReader_0, 4L))
						{
							if (smethod_15(binaryReader_0, out var float_4) && smethod_15(binaryReader_0, out var float_5))
							{
								mesh2.Vertices[num] = new Vector3(float_, float_2, float_3);
								mesh2.DiffuseColors[num] = int_4;
								mesh2.TexCoords[num] = new Vector2(float_4, float_5);
								num++;
								continue;
							}
							return null;
						}
						return null;
					}
					int num2 = 0;
					while (true)
					{
						if (num2 < int_3)
						{
							if (!smethod_16(binaryReader_0, out var short_) || !smethod_16(binaryReader_0, out var short_2) || !smethod_16(binaryReader_0, out var short_3))
							{
								break;
							}
							int num3 = num2 * 3;
							mesh2.Indices[num3] = short_3;
							mesh2.Indices[num3 + 1] = short_2;
							mesh2.Indices[num3 + 2] = short_;
							num2++;
							continue;
						}
						int num4 = 0;
						while (true)
						{
							if (num4 < int_2)
							{
								if (!smethod_15(binaryReader_0, out var float_6) || !smethod_15(binaryReader_0, out var float_7) || !smethod_15(binaryReader_0, out var float_8))
								{
									break;
								}
								mesh2.Normals[num4] = new Vector3(float_6, float_7, float_8);
								num4++;
								continue;
							}
							if (int_ >= 268435459 && !smethod_18(binaryReader_0, int_2 * 8L))
							{
								return null;
							}
							if (int_ >= 268435462 && byte_3 == 1 && !smethod_18(binaryReader_0, int_2 * 8L))
							{
								return null;
							}
							if (!smethod_18(binaryReader_0, 48L))
							{
								return null;
							}
							if (int_ >= 268435461 && !smethod_8(binaryReader_0))
							{
								return null;
							}
							return mesh2;
						}
						return null;
					}
					return null;
				}
				return null;
			}
			return null;
		}
		return null;
	}

	private void method_5(Vector3 vector3_2)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		if (!HasBounds)
		{
			method_1(vector3_2);
			method_2(vector3_2);
			method_3(bool_2: true);
			return;
		}
		Vector3 boundsMin = BoundsMin;
		Vector3 boundsMax = BoundsMax;
		boundsMin.X = Math.Min(boundsMin.X, vector3_2.X);
		boundsMin.Y = Math.Min(boundsMin.Y, vector3_2.Y);
		boundsMin.Z = Math.Min(boundsMin.Z, vector3_2.Z);
		boundsMax.X = Math.Max(boundsMax.X, vector3_2.X);
		boundsMax.Y = Math.Max(boundsMax.Y, vector3_2.Y);
		boundsMax.Z = Math.Max(boundsMax.Z, vector3_2.Z);
		method_1(boundsMin);
		method_2(boundsMax);
	}

	private static void smethod_4(Class294 class294_0, out Vector3 vector3_2, out Vector3 vector3_3, out Vector3 vector3_4)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		Vector3 unitZ = default(Vector3);
		unitZ = new Vector3(class294_0.float_3, class294_0.float_4, class294_0.float_5);
		if (unitZ.LengthSquared() < 1E-05f)
		{
			unitZ = Vector3.UnitZ;
		}
		unitZ.Normalize();
		Vector3 unitY = default(Vector3);
		unitY = new Vector3(class294_0.float_6, class294_0.float_7, class294_0.float_8);
		if (unitY.LengthSquared() < 1E-05f)
		{
			unitY = Vector3.UnitY;
		}
		unitY.Normalize();
		Vector3 val = Vector3.Cross(unitZ, unitY);
		if (val.LengthSquared() < 1E-05f)
		{
			val = Vector3.UnitX;
		}
		val.Normalize();
		vector3_2 = new Vector3(val.X, val.Y, 0f - val.Z);
		vector3_3 = new Vector3(unitY.X, unitY.Y, 0f - unitY.Z);
		vector3_4 = new Vector3(unitZ.X, unitZ.Y, 0f - unitZ.Z);
	}

	private static Vector3 smethod_5(Vector3 vector3_2, Class294 class294_0, Vector3 vector3_3, Vector3 vector3_4, Vector3 vector3_5)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		float num = 0f - class294_0.float_0;
		float float_ = class294_0.float_1;
		float float_2 = class294_0.float_2;
		float num2 = vector3_2.X * num;
		float num3 = vector3_2.Y * float_;
		float num4 = vector3_2.Z * float_2;
		return new Vector3(vector3_3.X * num2 + vector3_4.X * num3 + vector3_5.X * num4 + class294_0.float_9, vector3_3.Y * num2 + vector3_4.Y * num3 + vector3_5.Y * num4 + class294_0.float_10, vector3_3.Z * num2 + vector3_4.Z * num3 + vector3_5.Z * num4 - class294_0.float_11);
	}

	private static Vector3 smethod_6(Vector3 vector3_2, Class294 class294_0, Vector3 vector3_3, Vector3 vector3_4, Vector3 vector3_5)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		float num = 0f - class294_0.float_0;
		float float_ = class294_0.float_1;
		float float_2 = class294_0.float_2;
		float num2 = vector3_2.X * num;
		float num3 = vector3_2.Y * float_;
		float num4 = vector3_2.Z * float_2;
		Vector3 unitY = default(Vector3);
		unitY = new Vector3(vector3_3.X * num2 + vector3_4.X * num3 + vector3_5.X * num4, vector3_3.Y * num2 + vector3_4.Y * num3 + vector3_5.Y * num4, vector3_3.Z * num2 + vector3_4.Z * num3 + vector3_5.Z * num4);
		if (unitY.LengthSquared() > 1E-05f)
		{
			unitY.Normalize();
			return unitY;
		}
		unitY = Vector3.UnitY;
		return unitY;
	}

	private static bool smethod_7(BinaryReader binaryReader_0, Class294 class294_0)
	{
		if (smethod_15(binaryReader_0, out class294_0.float_0) && smethod_15(binaryReader_0, out class294_0.float_1) && smethod_15(binaryReader_0, out class294_0.float_2) && smethod_15(binaryReader_0, out class294_0.float_3) && smethod_15(binaryReader_0, out class294_0.float_4) && smethod_15(binaryReader_0, out class294_0.float_5) && smethod_15(binaryReader_0, out class294_0.float_6) && smethod_15(binaryReader_0, out class294_0.float_7) && smethod_15(binaryReader_0, out class294_0.float_8) && smethod_15(binaryReader_0, out class294_0.float_9) && smethod_15(binaryReader_0, out class294_0.float_10))
		{
			return smethod_15(binaryReader_0, out class294_0.float_11);
		}
		return false;
	}

	private static bool smethod_8(BinaryReader binaryReader_0)
	{
		if (!smethod_18(binaryReader_0, 10L))
		{
			return false;
		}
		while (binaryReader_0.BaseStream.Position < binaryReader_0.BaseStream.Length)
		{
			if (smethod_17(binaryReader_0, out var byte_))
			{
				if (byte_ == 0)
				{
					break;
				}
				continue;
			}
			return false;
		}
		return smethod_18(binaryReader_0, 69L);
	}

	private static bool smethod_9(BinaryReader binaryReader_0)
	{
		if (smethod_14(binaryReader_0, out var int_) && int_ >= 0)
		{
			return smethod_18(binaryReader_0, int_);
		}
		return false;
	}

	private static bool smethod_10(BinaryReader binaryReader_0, out string string_1)
	{
		string_1 = string.Empty;
		if (smethod_14(binaryReader_0, out var int_) && int_ >= 0 && smethod_19(binaryReader_0) >= int_)
		{
			if (int_ == 0)
			{
				return true;
			}
			byte[] bytes = binaryReader_0.ReadBytes(int_);
			try
			{
				string_1 = Encoding.GetEncoding(Class16.smethod_0(1648921191)).GetString(bytes).Trim('\0', ' ', '\t', '\r', '\n');
			}
			catch
			{
				string_1 = Encoding.Default.GetString(bytes).Trim('\0', ' ', '\t', '\r', '\n');
			}
			return true;
		}
		return false;
	}

	private static string smethod_11(byte[] byte_0)
	{
		if (byte_0 != null && byte_0.Length != 0)
		{
			int i;
			for (i = 0; i < byte_0.Length && byte_0[i] != 0; i++)
			{
			}
			if (i <= 0)
			{
				return string.Empty;
			}
			try
			{
				return Encoding.GetEncoding(Class16.smethod_0(1648921191)).GetString(byte_0, 0, i).Trim();
			}
			catch
			{
				return Encoding.Default.GetString(byte_0, 0, i).Trim();
			}
		}
		return string.Empty;
	}

	private static string smethod_12(string string_1)
	{
		return (string_1 ?? string.Empty).Replace('\\', '/').Trim();
	}

	private static bool smethod_13(BinaryReader binaryReader_0, byte[] byte_0)
	{
		if (byte_0 == null)
		{
			return false;
		}
		if (smethod_19(binaryReader_0) < byte_0.Length)
		{
			return false;
		}
		int num = binaryReader_0.Read(byte_0, 0, byte_0.Length);
		return num == byte_0.Length;
	}

	private static bool smethod_14(BinaryReader binaryReader_0, out int int_0)
	{
		int_0 = 0;
		if (smethod_19(binaryReader_0) < 4L)
		{
			return false;
		}
		int_0 = binaryReader_0.ReadInt32();
		return true;
	}

	private static bool smethod_15(BinaryReader binaryReader_0, out float float_0)
	{
		float_0 = 0f;
		if (smethod_19(binaryReader_0) < 4L)
		{
			return false;
		}
		float_0 = binaryReader_0.ReadSingle();
		return true;
	}

	private static bool smethod_16(BinaryReader binaryReader_0, out short short_0)
	{
		short_0 = 0;
		if (smethod_19(binaryReader_0) < 2L)
		{
			return false;
		}
		short_0 = binaryReader_0.ReadInt16();
		return true;
	}

	private static bool smethod_17(BinaryReader binaryReader_0, out byte byte_0)
	{
		byte_0 = 0;
		if (smethod_19(binaryReader_0) < 1L)
		{
			return false;
		}
		byte_0 = binaryReader_0.ReadByte();
		return true;
	}

	private static bool smethod_18(BinaryReader binaryReader_0, long long_0)
	{
		if (long_0 >= 0L && smethod_19(binaryReader_0) >= long_0)
		{
			binaryReader_0.BaseStream.Position += long_0;
			return true;
		}
		return false;
	}

	private static long smethod_19(BinaryReader binaryReader_0)
	{
		return binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
	}
}
