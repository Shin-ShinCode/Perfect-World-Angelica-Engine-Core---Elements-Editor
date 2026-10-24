using System;
using ACE.Models.ECM;

namespace ACE.GFX;

public class KPCtrlRevol : KPController
{
	public Vector3f Position;

	public Vector3f Axis;

	public float AngVel;

	public float AngAcc;

	public KPCtrlRevol()
	{
		base.Type = KPCtrlType.Revol;
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
		AngVel = gfxFileReader_0.ReadFloat();
		AngAcc = gfxFileReader_0.ReadFloat();
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
		if (Tick(data.TimeSpan))
		{
			float num = AngVel + AngAcc * data.TimeSpan;
			float num2 = num + fTimeSpan * AngAcc;
			float num3 = 0.5f * (num + num2) * fTimeSpan;
			Vector3f vector3f = Position + data.AxisOff;
			Vector3f vector3f_ = data.Position - vector3f;
			Quaternion quaternion_ = new Quaternion(Axis.float_0 * (float)Math.Sin(num3 / 2f), Axis.float_1 * (float)Math.Sin(num3 / 2f), Axis.float_2 * (float)Math.Sin(num3 / 2f), (float)Math.Cos(num3 / 2f));
			data.Position = vector3f + GfxMath.RotateVec(quaternion_, vector3f_);
		}
	}
}
