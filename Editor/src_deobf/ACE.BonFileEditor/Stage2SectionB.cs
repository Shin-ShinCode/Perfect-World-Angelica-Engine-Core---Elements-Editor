using System.IO;

namespace ACE.BonFileEditor;

public class Stage2SectionB
{
	public int Unknown1;

	public int unknown2;

	public int[] ID = new int[2];

	public Stage2SectionB(BinaryReader br)
	{
		Unknown1 = br.ReadInt32();
		unknown2 = br.ReadInt32();
		ID[0] = br.ReadInt32();
		ID[1] = br.ReadInt32();
	}

	public void Save(BinaryWriter bw)
	{
		bw.Write(Unknown1);
		bw.Write(unknown2);
		bw.Write(ID[0]);
		bw.Write(ID[1]);
	}
}
