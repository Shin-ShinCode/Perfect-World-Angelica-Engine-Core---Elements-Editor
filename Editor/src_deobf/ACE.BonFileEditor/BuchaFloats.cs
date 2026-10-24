using System.IO;

namespace ACE.BonFileEditor;

public class BuchaFloats
{
	public float unknown;

	public float unknown1;

	public float unknown2;

	public float unknown3;

	public BuchaFloats(BinaryReader br)
	{
		unknown = br.ReadSingle();
		unknown1 = br.ReadSingle();
		unknown2 = br.ReadSingle();
		unknown3 = br.ReadSingle();
	}

	public void Save(BinaryWriter bw)
	{
		bw.Write(unknown);
		bw.Write(unknown1);
		bw.Write(unknown2);
		bw.Write(unknown3);
	}
}
