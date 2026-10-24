using ACE.Models.ECM;

namespace ACE.GFX;

public class KPCtrlCentriMove : KPController
{
	public Vector3f CenterPos;

	public float Velocity;

	public float Acceleration;

	public override bool HasAxis => true;

	public KPCtrlCentriMove()
	{
		base.Type = KPCtrlType.Centri;
	}

	public override Vector3f GetAxisCenter()
	{
		return CenterPos;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		(float x, float y, float z) tuple = gfxFileReader_0.ReadVector3();
		float item = tuple.x;
		float item2 = tuple.y;
		float item3 = tuple.z;
		CenterPos = new Vector3f(item, item2, item3);
		Velocity = gfxFileReader_0.ReadFloat();
		Acceleration = gfxFileReader_0.ReadFloat();
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
		if (Tick(data.TimeSpan) && Velocity != 0f)
		{
			float num = Velocity + Acceleration * data.TimeSpan;
			float num2 = num + fTimeSpan * Acceleration;
			float num3 = 0.5f * (num + num2) * fTimeSpan;
			Vector3f vector3f = CenterPos + data.AxisOff;
			Vector3f vector3f2 = data.Position - vector3f;
			float num4 = vector3f2.Length();
			if (num4 > 0.0001f)
			{
				vector3f2 = vector3f2.Normalize();
			}
			if (Velocity < 0f && num4 < 0f - num3)
			{
				data.Position = vector3f;
			}
			else
			{
				data.Position += vector3f2 * num3;
			}
		}
	}
}
