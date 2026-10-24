using System.IO;
using System.Runtime.InteropServices;
using ACE.RSGlobal;

namespace ACE.NpcGen;

[StructLayout(LayoutKind.Sequential)]
public class ResEntry
{
	public int iResType;

	public int idTemplate;

	public int dwRefreshTime;

	public int dwNumber;

	public float fHeiOff;

	public void Write(BinaryWriter bw)
	{
		ACE.RSGlobal.RSGlobal.WriteStruct(bw, this);
	}
}
