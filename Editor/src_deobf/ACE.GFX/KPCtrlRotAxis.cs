using System;
using ACE.Models.ECM;

namespace ACE.GFX;

public class KPCtrlRotAxis : KPController
{
	public Vector3f Position;

	public Vector3f Axis;

	public float Velocity;

	public float Acceleration;

	public override bool HasAxis => true;

	public KPCtrlRotAxis()
	{
		base.Type = KPCtrlType.RotAxis;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		(float x, float y, float z) tuple = gfxFileReader_0.ReadVector3();
		float item = tuple.x;
		float item2 = tuple.y;
		float item3 = tuple.z;
		Position = new Vector3f(item, item2, item3);
		(float x, float y, float z) tuple2 = gfxFileReader_0.ReadVector3();
		float item4 = tuple2.x;
		float item5 = tuple2.y;
		float item6 = tuple2.z;
		Axis = new Vector3f(item4, item5, item6);
		Velocity = gfxFileReader_0.ReadFloat();
		Acceleration = gfxFileReader_0.ReadFloat();
	}

	public override Vector3f GetAxisCenter()
	{
		return Position;
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
		if (Tick(data.TimeSpan))
		{
			float num = Velocity + Acceleration * data.TimeSpan;
			float num2 = num + fTimeSpan * Acceleration;
			float float_ = 0.5f * (num + num2) * fTimeSpan;
			Vector3f vector3f_ = Position + data.AxisOff;
			data.Position = smethod_1(data.Position, vector3f_, Axis, float_);
		}
	}

	private static Vector3f smethod_1(Vector3f vector3f_0, Vector3f vector3f_1, Vector3f vector3f_2, float float_2)
	{
		Vector3f vector3f_3 = vector3f_0 - vector3f_1;
		Quaternion quaternion_ = new Quaternion(vector3f_2.float_0 * (float)Math.Sin(float_2 / 2f), vector3f_2.float_1 * (float)Math.Sin(float_2 / 2f), vector3f_2.float_2 * (float)Math.Sin(float_2 / 2f), (float)Math.Cos(float_2 / 2f));
		Vector3f vector3f = GfxMath.RotateVec(quaternion_, vector3f_3);
		return vector3f_1 + vector3f;
	}
}
