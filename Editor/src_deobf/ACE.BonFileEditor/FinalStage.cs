using System.IO;
using System.Text;

namespace ACE.BonFileEditor;

public class FinalStage
{
	public string BoneName;

	public int unknown0;

	public int ID;

	public Point3D[] Cords = new Point3D[4];

	public int[] CordsInts = new int[3];

	public float unknown1;

	public FinalStage(BinaryReader br, int Version)
	{
		BoneName = BonFile.ReadEncodedString(br, Class16.smethod_0(1648907779));
		unknown0 = br.ReadInt32();
		ID = br.ReadInt32();
		Cords[0] = new Point3D(br);
		CordsInts[0] = br.ReadInt32();
		Cords[1] = new Point3D(br);
		CordsInts[1] = br.ReadInt32();
		Cords[2] = new Point3D(br);
		CordsInts[2] = br.ReadInt32();
		Cords[3] = new Point3D(br);
		unknown1 = br.ReadSingle();
	}

	public void Save(BinaryWriter bw)
	{
		byte[] bytes = Encoding.GetEncoding(936).GetBytes(BoneName);
		bw.Write(bytes.Length);
		bw.Write(bytes);
		bw.Write(unknown0);
		bw.Write(ID);
		Cords[0].Save(bw);
		bw.Write(CordsInts[0]);
		Cords[1].Save(bw);
		bw.Write(CordsInts[1]);
		Cords[2].Save(bw);
		bw.Write(CordsInts[2]);
		Cords[3].Save(bw);
		bw.Write(unknown1);
	}
}
