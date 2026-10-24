using System.IO;

namespace ACE.BonFileEditor;

public class Point3D
{
	public decimal decimal_0;

	public decimal decimal_1;

	public decimal decimal_2;

	public Point3D(BinaryReader br)
	{
		decimal_0 = (decimal)br.ReadSingle();
		decimal_1 = (decimal)br.ReadSingle();
		decimal_2 = (decimal)br.ReadSingle();
	}

	public void Save(BinaryWriter bw)
	{
		bw.Write((float)decimal_0);
		bw.Write((float)decimal_1);
		bw.Write((float)decimal_2);
	}
}
