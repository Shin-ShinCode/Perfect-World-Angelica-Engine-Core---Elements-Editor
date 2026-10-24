using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACE.BonFileEditor;

public class SecondStage
{
	public string AnimationName;

	public int unknown1;

	public int unknown2;

	public int unknown3;

	public int cordcount;

	public int cordcount2;

	public int spacetype;

	public Point3D[] SingleCords = new Point3D[2];

	public int unknown4;

	public int unknown5;

	public int unknown6;

	public int unknown7;

	public int unknown8;

	public int unknown9;

	public int unknown10;

	public float unknown11;

	public int unknown12;

	public int unknown13;

	public int unknown14;

	public int unknown15;

	public List<Point3D> Cords = new List<Point3D>();

	public List<Stage2SectionB> Stage2SectionBs = new List<Stage2SectionB>();

	public int cordcount3;

	public int cordcount4;

	public int unknown16;

	public List<BuchaFloats> BuchaFloats = new List<BuchaFloats>();

	public List<Stage2SectionB> Stage2SectionBs2 = new List<Stage2SectionB>();

	public SecondStage(BinaryReader binaryReader_0, int Version)
	{
		AnimationName = BonFile.ReadEncodedString(binaryReader_0, Class16.smethod_0(1648907866));
		unknown1 = binaryReader_0.ReadInt32();
		unknown2 = binaryReader_0.ReadInt32();
		unknown3 = binaryReader_0.ReadInt32();
		cordcount = BonFile.ReadBoundedCount(binaryReader_0, Class16.smethod_0(1648907904), 100000);
		cordcount2 = BonFile.ReadBoundedCount(binaryReader_0, Class16.smethod_0(1648907932), 100000);
		spacetype = binaryReader_0.ReadInt32();
		if (spacetype == 31)
		{
			SingleCords[0] = new Point3D(binaryReader_0);
			unknown4 = binaryReader_0.ReadInt32();
			unknown5 = binaryReader_0.ReadInt32();
			unknown6 = binaryReader_0.ReadInt32();
			unknown7 = binaryReader_0.ReadInt32();
			unknown8 = binaryReader_0.ReadInt32();
			unknown9 = binaryReader_0.ReadInt32();
			unknown10 = binaryReader_0.ReadInt32();
			unknown11 = binaryReader_0.ReadSingle();
			SingleCords[1] = new Point3D(binaryReader_0);
			unknown12 = binaryReader_0.ReadInt32();
			unknown13 = binaryReader_0.ReadInt32();
			unknown14 = binaryReader_0.ReadInt32();
			unknown15 = binaryReader_0.ReadInt32();
			return;
		}
		for (int i = 0; i < cordcount; i++)
		{
			Cords.Add(new Point3D(binaryReader_0));
		}
		for (int j = 0; j < cordcount2; j++)
		{
			Stage2SectionBs.Add(new Stage2SectionB(binaryReader_0));
		}
		cordcount3 = BonFile.ReadBoundedCount(binaryReader_0, Class16.smethod_0(1648907945), 100000);
		cordcount4 = BonFile.ReadBoundedCount(binaryReader_0, Class16.smethod_0(1648907974), 100000);
		unknown16 = binaryReader_0.ReadInt32();
		for (int k = 0; k < cordcount3; k++)
		{
			BuchaFloats.Add(new BuchaFloats(binaryReader_0));
		}
		for (int l = 0; l < cordcount4; l++)
		{
			Stage2SectionBs2.Add(new Stage2SectionB(binaryReader_0));
		}
	}

	public void Save(BinaryWriter bw, int vers)
	{
		byte[] bytes = Encoding.GetEncoding(936).GetBytes(AnimationName);
		bw.Write(bytes.Length);
		bw.Write(bytes);
		bw.Write(unknown1);
		bw.Write(unknown2);
		bw.Write(unknown3);
		bw.Write(cordcount);
		bw.Write(cordcount2);
		bw.Write(spacetype);
		if (spacetype == 31)
		{
			SingleCords[0].Save(bw);
			bw.Write(unknown4);
			bw.Write(unknown5);
			bw.Write(unknown6);
			bw.Write(unknown7);
			bw.Write(unknown8);
			bw.Write(unknown9);
			bw.Write(unknown10);
			bw.Write(unknown11);
			SingleCords[1].Save(bw);
			bw.Write(unknown12);
			bw.Write(unknown13);
			bw.Write(unknown14);
			bw.Write(unknown15);
			return;
		}
		for (int i = 0; i < cordcount; i++)
		{
			Cords[i].Save(bw);
		}
		for (int j = 0; j < cordcount2; j++)
		{
			Stage2SectionBs[j].Save(bw);
		}
		bw.Write(cordcount3);
		bw.Write(cordcount4);
		bw.Write(unknown16);
		for (int k = 0; k < cordcount3; k++)
		{
			BuchaFloats[k].Save(bw);
		}
		for (int l = 0; l < cordcount4; l++)
		{
			Stage2SectionBs2[l].Save(bw);
		}
	}
}
