using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACE.BonFileEditor;

public class FirstStage
{
	public string BoneName;

	public int Extras2;

	public int[] ID = new int[2];

	public Point3D[] Points = new Point3D[8];

	public int unknown0;

	public int unknown1;

	public int unknown2;

	public decimal unknown3;

	public decimal unknown4;

	public decimal unknown5;

	public decimal unknown6;

	public decimal unknown7;

	public List<int> Extras = new List<int>();

	public FirstStage(BinaryReader binaryReader_0, int Version)
	{
		BoneName = BonFile.ReadEncodedString(binaryReader_0, Class16.smethod_0(1648907811));
		Extras2 = binaryReader_0.ReadInt32();
		ID[0] = binaryReader_0.ReadInt32();
		ID[1] = binaryReader_0.ReadInt32();
		Extras = new List<int>(BonFile.ReadBoundedCount(binaryReader_0, Class16.smethod_0(1648907843), 100000));
		Points[0] = new Point3D(binaryReader_0);
		unknown0 = binaryReader_0.ReadInt32();
		Points[1] = new Point3D(binaryReader_0);
		unknown1 = binaryReader_0.ReadInt32();
		Points[2] = new Point3D(binaryReader_0);
		unknown2 = binaryReader_0.ReadInt32();
		Points[3] = new Point3D(binaryReader_0);
		unknown3 = (decimal)binaryReader_0.ReadSingle();
		Points[4] = new Point3D(binaryReader_0);
		unknown4 = (decimal)binaryReader_0.ReadSingle();
		Points[5] = new Point3D(binaryReader_0);
		unknown5 = (decimal)binaryReader_0.ReadSingle();
		Points[6] = new Point3D(binaryReader_0);
		unknown6 = (decimal)binaryReader_0.ReadSingle();
		Points[7] = new Point3D(binaryReader_0);
		unknown7 = (decimal)binaryReader_0.ReadSingle();
		for (int i = 0; i < Extras.Capacity; i++)
		{
			Extras.Add(binaryReader_0.ReadInt32());
		}
	}

	public void Save(BinaryWriter bw, int vers)
	{
		byte[] bytes = Encoding.GetEncoding(936).GetBytes(BoneName);
		bw.Write(bytes.Length);
		bw.Write(bytes);
		bw.Write(Extras2);
		bw.Write(ID[0]);
		bw.Write(ID[1]);
		bw.Write(Extras.Count);
		Points[0].Save(bw);
		bw.Write(unknown0);
		Points[1].Save(bw);
		bw.Write(unknown1);
		Points[2].Save(bw);
		bw.Write(unknown2);
		Points[3].Save(bw);
		bw.Write((float)unknown3);
		Points[4].Save(bw);
		bw.Write((float)unknown4);
		Points[5].Save(bw);
		bw.Write((float)unknown5);
		Points[6].Save(bw);
		bw.Write((float)unknown6);
		Points[7].Save(bw);
		bw.Write((float)unknown7);
		for (int i = 0; i < Extras.Count; i++)
		{
			bw.Write(Extras[i]);
		}
	}
}
