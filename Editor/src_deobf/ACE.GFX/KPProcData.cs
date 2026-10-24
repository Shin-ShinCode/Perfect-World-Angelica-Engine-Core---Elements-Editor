using ACE.Models.ECM;

namespace ACE.GFX;

public class KPProcData
{
	public Vector3f Position;

	public Quaternion Direction = Quaternion.Identity;

	public uint Color = uint.MaxValue;

	public float Scale = 1f;

	public float Rad2D;

	public float TimeSpan;

	public Vector3f AxisOff;

	public float ScaleNoise;
}
