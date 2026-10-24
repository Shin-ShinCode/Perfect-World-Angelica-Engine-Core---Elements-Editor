using System;
using ACE.Models.ECM;

namespace ACE.GFX;

public static class GfxMath
{
	public static readonly Vector3f UnitX = new Vector3f(1f, 0f, 0f);

	public static readonly Vector3f UnitY = new Vector3f(0f, 1f, 0f);

	public static readonly Vector3f UnitZ = new Vector3f(0f, 0f, 1f);

	public static readonly Vector3f Zero = new Vector3f(0f, 0f, 0f);

	public static readonly Quaternion IdentityQuat = Quaternion.Identity;

	public static float Dot(Vector3f vector3f_0, Vector3f vector3f_1)
	{
		return vector3f_0.float_0 * vector3f_1.float_0 + vector3f_0.float_1 * vector3f_1.float_1 + vector3f_0.float_2 * vector3f_1.float_2;
	}

	public static Vector3f Cross(Vector3f vector3f_0, Vector3f vector3f_1)
	{
		return new Vector3f(vector3f_0.float_1 * vector3f_1.float_2 - vector3f_0.float_2 * vector3f_1.float_1, vector3f_0.float_2 * vector3f_1.float_0 - vector3f_0.float_0 * vector3f_1.float_2, vector3f_0.float_0 * vector3f_1.float_1 - vector3f_0.float_1 * vector3f_1.float_0);
	}

	public static Quaternion Slerp(Quaternion quaternion_0, Quaternion quaternion_1, float float_0)
	{
		float num = quaternion_0.float_0 * quaternion_1.float_0 + quaternion_0.float_1 * quaternion_1.float_1 + quaternion_0.float_2 * quaternion_1.float_2 + quaternion_0.float_3 * quaternion_1.float_3;
		if (num < 0f)
		{
			quaternion_1 = new Quaternion(0f - quaternion_1.float_0, 0f - quaternion_1.float_1, 0f - quaternion_1.float_2, 0f - quaternion_1.float_3);
			num = 0f - num;
		}
		if (num > 0.9995f)
		{
			return NormalizeQuat(new Quaternion(quaternion_0.float_0 + (quaternion_1.float_0 - quaternion_0.float_0) * float_0, quaternion_0.float_1 + (quaternion_1.float_1 - quaternion_0.float_1) * float_0, quaternion_0.float_2 + (quaternion_1.float_2 - quaternion_0.float_2) * float_0, quaternion_0.float_3 + (quaternion_1.float_3 - quaternion_0.float_3) * float_0));
		}
		float num2 = (float)Math.Acos(Math.Min(Math.Max(num, -1f), 1f));
		float num3 = (float)Math.Sin(num2);
		float num4 = (float)Math.Sin((1f - float_0) * num2) / num3;
		float num5 = (float)Math.Sin(float_0 * num2) / num3;
		return new Quaternion(num4 * quaternion_0.float_0 + num5 * quaternion_1.float_0, num4 * quaternion_0.float_1 + num5 * quaternion_1.float_1, num4 * quaternion_0.float_2 + num5 * quaternion_1.float_2, num4 * quaternion_0.float_3 + num5 * quaternion_1.float_3);
	}

	public static Quaternion NormalizeQuat(Quaternion quaternion_0)
	{
		float num = (float)Math.Sqrt(quaternion_0.float_0 * quaternion_0.float_0 + quaternion_0.float_1 * quaternion_0.float_1 + quaternion_0.float_2 * quaternion_0.float_2 + quaternion_0.float_3 * quaternion_0.float_3);
		if (num < 0.0001f)
		{
			return Quaternion.Identity;
		}
		return new Quaternion(quaternion_0.float_0 / num, quaternion_0.float_1 / num, quaternion_0.float_2 / num, quaternion_0.float_3 / num);
	}

	public static Vector3f RotateVec(Quaternion quaternion_0, Vector3f vector3f_0)
	{
		float float_ = quaternion_0.float_0;
		float float_2 = quaternion_0.float_1;
		float float_3 = quaternion_0.float_2;
		float float_4 = quaternion_0.float_3;
		float float_5 = vector3f_0.float_0;
		float float_6 = vector3f_0.float_1;
		float float_7 = vector3f_0.float_2;
		float num = 2f * (float_2 * float_7 - float_3 * float_6);
		float num2 = 2f * (float_3 * float_5 - float_ * float_7);
		float num3 = 2f * (float_ * float_6 - float_2 * float_5);
		return new Vector3f(float_5 + float_4 * num + (float_2 * num3 - float_3 * num2), float_6 + float_4 * num2 + (float_3 * num - float_ * num3), float_7 + float_4 * num3 + (float_ * num2 - float_2 * num));
	}

	public static Vector3f TransformCoord(Vector3f vector3f_0, float[] m4x4)
	{
		return new Vector3f(vector3f_0.float_0 * m4x4[0] + vector3f_0.float_1 * m4x4[4] + vector3f_0.float_2 * m4x4[8] + m4x4[12], vector3f_0.float_0 * m4x4[1] + vector3f_0.float_1 * m4x4[5] + vector3f_0.float_2 * m4x4[9] + m4x4[13], vector3f_0.float_0 * m4x4[2] + vector3f_0.float_1 * m4x4[6] + vector3f_0.float_2 * m4x4[10] + m4x4[14]);
	}

	public static Vector3f TransformNormal(Vector3f vector3f_0, float[] m4x4)
	{
		return new Vector3f(vector3f_0.float_0 * m4x4[0] + vector3f_0.float_1 * m4x4[4] + vector3f_0.float_2 * m4x4[8], vector3f_0.float_0 * m4x4[1] + vector3f_0.float_1 * m4x4[5] + vector3f_0.float_2 * m4x4[9], vector3f_0.float_0 * m4x4[2] + vector3f_0.float_1 * m4x4[6] + vector3f_0.float_2 * m4x4[10]);
	}

	public static float Clamp01(float float_0)
	{
		return Math.Min(Math.Max(float_0, 0f), 1f);
	}

	public static float Deg2Rad(float float_0)
	{
		return float_0 * (float)Math.PI / 180f;
	}
}
