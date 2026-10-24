using System.IO;
using ACE.RSGlobal;

namespace ACE.NpcGen;

public class DynObj
{
	public int dwDynObjID;

	public float[] vPos;

	public byte[] dir;

	public byte rad;

	public byte scale;

	public uint idController;

	public byte bBroadcast;

	public uint export_id;

	public void Write(BinaryWriter bw, int version)
	{
		bw.Write(dwDynObjID);
		ACE.RSGlobal.RSGlobal.WriteFloat3(bw, vPos);
		bw.Write(dir);
		bw.Write(rad);
		if (version >= 9)
		{
			bw.Write(scale);
		}
		if (version >= 10)
		{
			bw.Write(idController);
		}
		if (version >= 14)
		{
			bw.Write(bBroadcast);
		}
		if (version >= 24)
		{
			bw.Write(export_id);
		}
	}
}
