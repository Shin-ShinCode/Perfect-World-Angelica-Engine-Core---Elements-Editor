using System;
using System.IO;

namespace ACE.Models.ECM;

public struct Quaternion(float float_4, float float_5, float float_6, float float_7)
{
	public float float_0 = float_4;

	public float float_1 = float_5;

	public float float_2 = float_6;

	public float float_3 = float_7;

	public static Quaternion Identity => new Quaternion(0f, 0f, 0f, 1f);

	public static Quaternion Read(BinaryReader reader)
	{
		return new Quaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
	}

	public static Quaternion ReadCompressed(BinaryReader reader)
	{
		float num = reader.ReadSingle();
		float num2 = reader.ReadSingle();
		float num3 = reader.ReadSingle();
		float num4 = 1f - num * num - num2 * num2 - num3 * num3;
		float float_ = ((num4 > 0f) ? ((float)Math.Sqrt(num4)) : 0f);
		return new Quaternion(num, num2, num3, float_);
	}

	public Quaternion Normalize()
	{
		float num = (float)Math.Sqrt(float_0 * float_0 + float_1 * float_1 + float_2 * float_2 + float_3 * float_3);
		if (num > 0.0001f)
		{
			return new Quaternion(float_0 / num, float_1 / num, float_2 / num, float_3 / num);
		}
		return Identity;
	}

	public static Quaternion Slerp(Quaternion quaternion_0, Quaternion quaternion_1, float float_4)
	{
		quaternion_0 = quaternion_0.Normalize();
		quaternion_1 = quaternion_1.Normalize();
		float num = quaternion_0.float_0 * quaternion_1.float_0 + quaternion_0.float_1 * quaternion_1.float_1 + quaternion_0.float_2 * quaternion_1.float_2 + quaternion_0.float_3 * quaternion_1.float_3;
		if (num < 0f)
		{
			quaternion_1 = new Quaternion(0f - quaternion_1.float_0, 0f - quaternion_1.float_1, 0f - quaternion_1.float_2, 0f - quaternion_1.float_3);
			num = 0f - num;
		}
		if (num > 0.9995f)
		{
			return new Quaternion(quaternion_0.float_0 + (quaternion_1.float_0 - quaternion_0.float_0) * float_4, quaternion_0.float_1 + (quaternion_1.float_1 - quaternion_0.float_1) * float_4, quaternion_0.float_2 + (quaternion_1.float_2 - quaternion_0.float_2) * float_4, quaternion_0.float_3 + (quaternion_1.float_3 - quaternion_0.float_3) * float_4).Normalize();
		}
		float num2 = (float)Math.Acos(num);
		float num3 = num2 * float_4;
		float num4 = (float)Math.Sin(num3);
		float num5 = (float)Math.Sin(num2);
		float num6 = (float)Math.Cos(num3) - num * num4 / num5;
		float num7 = num4 / num5;
		return new Quaternion(quaternion_0.float_0 * num6 + quaternion_1.float_0 * num7, quaternion_0.float_1 * num6 + quaternion_1.float_1 * num7, quaternion_0.float_2 * num6 + quaternion_1.float_2 * num7, quaternion_0.float_3 * num6 + quaternion_1.float_3 * num7);
	}

	public Matrix4x4 ToMatrix()
	{
		Quaternion quaternion = Normalize();
		float num = quaternion.float_0 * quaternion.float_0;
		float num2 = quaternion.float_1 * quaternion.float_1;
		float num3 = quaternion.float_2 * quaternion.float_2;
		float num4 = quaternion.float_0 * quaternion.float_1;
		float num5 = quaternion.float_0 * quaternion.float_2;
		float num6 = quaternion.float_1 * quaternion.float_2;
		float num7 = quaternion.float_3 * quaternion.float_0;
		float num8 = quaternion.float_3 * quaternion.float_1;
		float num9 = quaternion.float_3 * quaternion.float_2;
		Matrix4x4 identity = Matrix4x4.Identity;
		identity.M11 = 1f - 2f * (num2 + num3);
		identity.M12 = 2f * (num4 - num9);
		identity.M13 = 2f * (num5 + num8);
		identity.M21 = 2f * (num4 + num9);
		identity.M22 = 1f - 2f * (num + num3);
		identity.M23 = 2f * (num6 - num7);
		identity.M31 = 2f * (num5 - num8);
		identity.M32 = 2f * (num6 + num7);
		identity.M33 = 1f - 2f * (num + num2);
		return identity;
	}
}
