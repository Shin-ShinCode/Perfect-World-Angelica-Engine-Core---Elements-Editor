namespace ACE.NpcGen.Classes;

public class ClassPosition
{
	public float DirX;

	public float DirY;

	public float DirZ;

	public float PosX;

	public float PosY;

	public float PosZ;

	public ClassPosition(float float_0, float float_1, float float_2, float DX, float DY, float DZ)
	{
		PosX = float_0;
		PosY = float_1;
		PosZ = float_2;
		DirX = DX;
		DirY = DY;
		DirZ = DZ;
	}
}
