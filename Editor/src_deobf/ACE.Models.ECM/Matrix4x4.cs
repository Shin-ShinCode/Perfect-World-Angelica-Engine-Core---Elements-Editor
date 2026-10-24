using System;
using System.IO;
using SharpDX;

namespace ACE.Models.ECM;

public struct Matrix4x4
{
	public float M11;

	public float M12;

	public float M13;

	public float M14;

	public float M21;

	public float M22;

	public float M23;

	public float M24;

	public float M31;

	public float M32;

	public float M33;

	public float M34;

	public float M41;

	public float M42;

	public float M43;

	public float M44;

	public static Matrix4x4 Identity => new Matrix4x4
	{
		M11 = 1f,
		M22 = 1f,
		M33 = 1f,
		M44 = 1f
	};

	public static Matrix4x4 Read(BinaryReader reader)
	{
		return new Matrix4x4
		{
			M11 = reader.ReadSingle(),
			M12 = reader.ReadSingle(),
			M13 = reader.ReadSingle(),
			M14 = reader.ReadSingle(),
			M21 = reader.ReadSingle(),
			M22 = reader.ReadSingle(),
			M23 = reader.ReadSingle(),
			M24 = reader.ReadSingle(),
			M31 = reader.ReadSingle(),
			M32 = reader.ReadSingle(),
			M33 = reader.ReadSingle(),
			M34 = reader.ReadSingle(),
			M41 = reader.ReadSingle(),
			M42 = reader.ReadSingle(),
			M43 = reader.ReadSingle(),
			M44 = reader.ReadSingle()
		};
	}

	public static Matrix4x4 CreateTranslation(Vector3f pos)
	{
		Matrix4x4 identity = Identity;
		identity.M41 = pos.float_0;
		identity.M42 = pos.float_1;
		identity.M43 = pos.float_2;
		return identity;
	}

	public static Matrix4x4 CreateScale(Vector3f scale)
	{
		Matrix4x4 identity = Identity;
		identity.M11 = scale.float_0;
		identity.M22 = scale.float_1;
		identity.M33 = scale.float_2;
		return identity;
	}

	public static Matrix4x4 operator *(Matrix4x4 matrix4x4_0, Matrix4x4 matrix4x4_1)
	{
		return new Matrix4x4
		{
			M11 = matrix4x4_0.M11 * matrix4x4_1.M11 + matrix4x4_0.M12 * matrix4x4_1.M21 + matrix4x4_0.M13 * matrix4x4_1.M31 + matrix4x4_0.M14 * matrix4x4_1.M41,
			M12 = matrix4x4_0.M11 * matrix4x4_1.M12 + matrix4x4_0.M12 * matrix4x4_1.M22 + matrix4x4_0.M13 * matrix4x4_1.M32 + matrix4x4_0.M14 * matrix4x4_1.M42,
			M13 = matrix4x4_0.M11 * matrix4x4_1.M13 + matrix4x4_0.M12 * matrix4x4_1.M23 + matrix4x4_0.M13 * matrix4x4_1.M33 + matrix4x4_0.M14 * matrix4x4_1.M43,
			M14 = matrix4x4_0.M11 * matrix4x4_1.M14 + matrix4x4_0.M12 * matrix4x4_1.M24 + matrix4x4_0.M13 * matrix4x4_1.M34 + matrix4x4_0.M14 * matrix4x4_1.M44,
			M21 = matrix4x4_0.M21 * matrix4x4_1.M11 + matrix4x4_0.M22 * matrix4x4_1.M21 + matrix4x4_0.M23 * matrix4x4_1.M31 + matrix4x4_0.M24 * matrix4x4_1.M41,
			M22 = matrix4x4_0.M21 * matrix4x4_1.M12 + matrix4x4_0.M22 * matrix4x4_1.M22 + matrix4x4_0.M23 * matrix4x4_1.M32 + matrix4x4_0.M24 * matrix4x4_1.M42,
			M23 = matrix4x4_0.M21 * matrix4x4_1.M13 + matrix4x4_0.M22 * matrix4x4_1.M23 + matrix4x4_0.M23 * matrix4x4_1.M33 + matrix4x4_0.M24 * matrix4x4_1.M43,
			M24 = matrix4x4_0.M21 * matrix4x4_1.M14 + matrix4x4_0.M22 * matrix4x4_1.M24 + matrix4x4_0.M23 * matrix4x4_1.M34 + matrix4x4_0.M24 * matrix4x4_1.M44,
			M31 = matrix4x4_0.M31 * matrix4x4_1.M11 + matrix4x4_0.M32 * matrix4x4_1.M21 + matrix4x4_0.M33 * matrix4x4_1.M31 + matrix4x4_0.M34 * matrix4x4_1.M41,
			M32 = matrix4x4_0.M31 * matrix4x4_1.M12 + matrix4x4_0.M32 * matrix4x4_1.M22 + matrix4x4_0.M33 * matrix4x4_1.M32 + matrix4x4_0.M34 * matrix4x4_1.M42,
			M33 = matrix4x4_0.M31 * matrix4x4_1.M13 + matrix4x4_0.M32 * matrix4x4_1.M23 + matrix4x4_0.M33 * matrix4x4_1.M33 + matrix4x4_0.M34 * matrix4x4_1.M43,
			M34 = matrix4x4_0.M31 * matrix4x4_1.M14 + matrix4x4_0.M32 * matrix4x4_1.M24 + matrix4x4_0.M33 * matrix4x4_1.M34 + matrix4x4_0.M34 * matrix4x4_1.M44,
			M41 = matrix4x4_0.M41 * matrix4x4_1.M11 + matrix4x4_0.M42 * matrix4x4_1.M21 + matrix4x4_0.M43 * matrix4x4_1.M31 + matrix4x4_0.M44 * matrix4x4_1.M41,
			M42 = matrix4x4_0.M41 * matrix4x4_1.M12 + matrix4x4_0.M42 * matrix4x4_1.M22 + matrix4x4_0.M43 * matrix4x4_1.M32 + matrix4x4_0.M44 * matrix4x4_1.M42,
			M43 = matrix4x4_0.M41 * matrix4x4_1.M13 + matrix4x4_0.M42 * matrix4x4_1.M23 + matrix4x4_0.M43 * matrix4x4_1.M33 + matrix4x4_0.M44 * matrix4x4_1.M43,
			M44 = matrix4x4_0.M41 * matrix4x4_1.M14 + matrix4x4_0.M42 * matrix4x4_1.M24 + matrix4x4_0.M43 * matrix4x4_1.M34 + matrix4x4_0.M44 * matrix4x4_1.M44
		};
	}

	public Vector3f TransformPoint(Vector3f vector3f_0)
	{
		float float_ = vector3f_0.float_0 * M11 + vector3f_0.float_1 * M21 + vector3f_0.float_2 * M31 + M41;
		float float_2 = vector3f_0.float_0 * M12 + vector3f_0.float_1 * M22 + vector3f_0.float_2 * M32 + M42;
		float float_3 = vector3f_0.float_0 * M13 + vector3f_0.float_1 * M23 + vector3f_0.float_2 * M33 + M43;
		return new Vector3f(float_, float_2, float_3);
	}

	public Vector3f TransformVector(Vector3f vector3f_0)
	{
		return new Vector3f(vector3f_0.float_0 * M11 + vector3f_0.float_1 * M21 + vector3f_0.float_2 * M31, vector3f_0.float_0 * M12 + vector3f_0.float_1 * M22 + vector3f_0.float_2 * M32, vector3f_0.float_0 * M13 + vector3f_0.float_1 * M23 + vector3f_0.float_2 * M33);
	}

	public Matrix4x4 Inverse()
	{
		float num = method_0();
		if (Math.Abs(num) < 1E-05f)
		{
			return Identity;
		}
		float num2 = 1f / num;
		return new Matrix4x4
		{
			M11 = smethod_0(M22, M23, M24, M32, M33, M34, M42, M43, M44) * num2,
			M12 = (0f - smethod_0(M12, M13, M14, M32, M33, M34, M42, M43, M44)) * num2,
			M13 = smethod_0(M12, M13, M14, M22, M23, M24, M42, M43, M44) * num2,
			M14 = (0f - smethod_0(M12, M13, M14, M22, M23, M24, M32, M33, M34)) * num2,
			M21 = (0f - smethod_0(M21, M23, M24, M31, M33, M34, M41, M43, M44)) * num2,
			M22 = smethod_0(M11, M13, M14, M31, M33, M34, M41, M43, M44) * num2,
			M23 = (0f - smethod_0(M11, M13, M14, M21, M23, M24, M41, M43, M44)) * num2,
			M24 = smethod_0(M11, M13, M14, M21, M23, M24, M31, M33, M34) * num2,
			M31 = smethod_0(M21, M22, M24, M31, M32, M34, M41, M42, M44) * num2,
			M32 = (0f - smethod_0(M11, M12, M14, M31, M32, M34, M41, M42, M44)) * num2,
			M33 = smethod_0(M11, M12, M14, M21, M22, M24, M41, M42, M44) * num2,
			M34 = (0f - smethod_0(M11, M12, M14, M21, M22, M24, M31, M32, M34)) * num2,
			M41 = (0f - smethod_0(M21, M22, M23, M31, M32, M33, M41, M42, M43)) * num2,
			M42 = smethod_0(M11, M12, M13, M31, M32, M33, M41, M42, M43) * num2,
			M43 = (0f - smethod_0(M11, M12, M13, M21, M22, M23, M41, M42, M43)) * num2,
			M44 = smethod_0(M11, M12, M13, M21, M22, M23, M31, M32, M33) * num2
		};
	}

	private float method_0()
	{
		return smethod_0(M11, M12, M13, M21, M22, M23, M31, M32, M33);
	}

	private static float smethod_0(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8)
	{
		return float_0 * float_4 * float_8 + float_3 * float_7 * float_2 + float_6 * float_1 * float_5 - float_2 * float_4 * float_6 - float_5 * float_7 * float_0 - float_8 * float_1 * float_3;
	}

	public Matrix ToSharpDX()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		return new Matrix(M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);
	}
}
