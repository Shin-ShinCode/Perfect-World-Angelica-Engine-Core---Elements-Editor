using System;
using System.IO;

namespace ACE.Models.ECM;

public struct Vector3f(float float_3, float float_4, float float_5)
{
	public float float_0 = float_3;

	public float float_1 = float_4;

	public float float_2 = float_5;

	public static Vector3f Read(BinaryReader reader)
	{
		return new Vector3f(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
	}

	public float Length()
	{
		return (float)Math.Sqrt(float_0 * float_0 + float_1 * float_1 + float_2 * float_2);
	}

	public Vector3f Normalize()
	{
		float num = Length();
		if (num > 0.0001f)
		{
			return new Vector3f(float_0 / num, float_1 / num, float_2 / num);
		}
		return this;
	}

	public static Vector3f Lerp(Vector3f vector3f_0, Vector3f vector3f_1, float float_3)
	{
		return new Vector3f(vector3f_0.float_0 + (vector3f_1.float_0 - vector3f_0.float_0) * float_3, vector3f_0.float_1 + (vector3f_1.float_1 - vector3f_0.float_1) * float_3, vector3f_0.float_2 + (vector3f_1.float_2 - vector3f_0.float_2) * float_3);
	}

	public static Vector3f operator +(Vector3f vector3f_0, Vector3f vector3f_1)
	{
		return new Vector3f(vector3f_0.float_0 + vector3f_1.float_0, vector3f_0.float_1 + vector3f_1.float_1, vector3f_0.float_2 + vector3f_1.float_2);
	}

	public static Vector3f operator -(Vector3f vector3f_0, Vector3f vector3f_1)
	{
		return new Vector3f(vector3f_0.float_0 - vector3f_1.float_0, vector3f_0.float_1 - vector3f_1.float_1, vector3f_0.float_2 - vector3f_1.float_2);
	}

	public static Vector3f operator *(Vector3f vector3f_0, float float_3)
	{
		return new Vector3f(vector3f_0.float_0 * float_3, vector3f_0.float_1 * float_3, vector3f_0.float_2 * float_3);
	}
}
