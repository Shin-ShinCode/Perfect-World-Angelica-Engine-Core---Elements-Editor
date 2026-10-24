using ACE.NpcGen;

namespace ACE.Models;

public struct AREA
{
	public byte[] body;

	public int iGroupType;

	public int iNPCType;

	public int iNumGen;

	public int iType;

	public NPCGENFILEAIGEN[] m_aNPCGens;

	public byte[][] m_aNPCGens_tail;

	public float[] vDir;

	public float[] vExts;

	public float[] vPos;
}
