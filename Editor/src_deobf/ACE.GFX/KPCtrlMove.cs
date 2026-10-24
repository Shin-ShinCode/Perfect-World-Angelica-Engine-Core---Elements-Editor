using ACE.Models.ECM;

namespace ACE.GFX;

public class KPCtrlMove : KPController
{
	public Vector3f MoveDir;

	public float Velocity;

	public float Acceleration;

	public KPCtrlMove()
	{
		base.Type = KPCtrlType.Move;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		(float x, float y, float z) tuple = gfxFileReader_0.ReadVector3();
		float item = tuple.x;
		float item2 = tuple.y;
		float item3 = tuple.z;
		MoveDir = new Vector3f(item, item2, item3);
		Velocity = gfxFileReader_0.ReadFloat();
		Acceleration = gfxFileReader_0.ReadFloat();
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
		if (Tick(data.TimeSpan))
		{
			float num = smethod_1(Velocity, Acceleration, data.TimeSpan, fTimeSpan);
			data.Position += MoveDir * num;
			data.AxisOff += MoveDir * num;
		}
	}

	private static float smethod_1(float float_2, float float_3, float float_4, float float_5)
	{
		float num = float_2 + float_3 * float_4;
		float num2 = num + float_5 * float_3;
		return 0.5f * (num + num2) * float_5;
	}
}
