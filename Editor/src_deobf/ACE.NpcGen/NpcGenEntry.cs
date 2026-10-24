using ACE.Classes;

namespace ACE.NpcGen;

public class NpcGenEntry
{
	public int dwID;

	public int dwNum;

	public int dwRefresh;

	public int dwDiedTimes;

	public int dwAggressive;

	public float fOffsetWater;

	public float fOffsetTrn;

	public int dwFaction;

	public int dwFacHelper;

	public int dwFacAccept;

	public byte bNeedHelp;

	public byte bDefFaction;

	public byte bDefFacHelper;

	public byte bDefFacAccept;

	public int iPathID;

	public int iLoopType;

	public int iSpeedFlag;

	public int iDeadTime;

	public ITEMPOS ItemPos;

	public NpcGenEntry Clone()
	{
		return (NpcGenEntry)MemberwiseClone();
	}
}
