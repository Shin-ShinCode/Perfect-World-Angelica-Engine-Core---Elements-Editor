using System.IO;
using System.Text;

namespace ACE.BonFileEditor;

public class SecondStageAlt
{
	public string BoneName;

	public int[] ID = new int[2];

	public int Unknown1;

	public SecondStageAlt(BinaryReader binaryReader_0, int Version)
	{
		BoneName = BonFile.ReadEncodedString(binaryReader_0, Class16.smethod_0(1648907987));
		ID[0] = binaryReader_0.ReadInt32();
		ID[1] = binaryReader_0.ReadInt32();
		Unknown1 = binaryReader_0.ReadInt32();
	}

	public void Save(BinaryWriter bw)
	{
		byte[] bytes = Encoding.GetEncoding(936).GetBytes(BoneName);
		bw.Write(bytes.Length);
		bw.Write(bytes);
		bw.Write(ID[0]);
		bw.Write(ID[1]);
		bw.Write(Unknown1);
	}
}
