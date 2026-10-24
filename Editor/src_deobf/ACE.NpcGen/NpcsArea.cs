using System;
using ACE.RSGlobal;

namespace ACE.NpcGen;

public class NpcsArea
{
	public int iType;

	public int iNumGen;

	public float[] vPos;

	public float[] vDir;

	public float[] vExts;

	public int iNPCType;

	public int iGroupType;

	public byte bInitGen;

	public byte bAutoRevive;

	public byte bValidOnce;

	public int dwGenID;

	public int idCtrl;

	public int iLifeTime;

	public int iMaxNum;

	public int dwExportID;

	public int iAttachNum;

	public int idBufRegion;

	public NpcGenEntry[] Gens;

	public int[] Attach;

	public void AddGen()
	{
		Array.Resize(ref Gens, (int)((nint)Gens.LongLength + 1));
		NpcGenEntry[] gens = Gens;
		int num = (int)((nint)gens.LongLength - 1);
		gens[num] = new NpcGenEntry();
	}

	public void AddGen(int SourceIndex)
	{
		Array.Resize(ref Gens, (int)((nint)Gens.LongLength + 1));
		NpcGenEntry[] gens = Gens;
		int num = (int)((nint)gens.LongLength - 1);
		gens[num] = Gens[SourceIndex].Clone();
	}

	public void DeleteGen(int Index)
	{
		NpcGenEntry[] gens = Gens;
		NpcGenEntry[] array = new NpcGenEntry[(nint)gens.LongLength - 1];
		Array.Copy(gens, 0, array, 0, Index);
		NpcGenEntry[] gens2 = Gens;
		Array.Copy(gens2, Index + 1, array, Index, (int)((nint)gens2.LongLength - Index - 1));
		Gens = array;
	}

	public NpcsArea Clone()
	{
		NpcsArea npcsArea = (NpcsArea)MemberwiseClone();
		npcsArea.vPos = ACE.RSGlobal.RSGlobal.CloneArray(vPos);
		npcsArea.vDir = ACE.RSGlobal.RSGlobal.CloneArray(vDir);
		npcsArea.vExts = ACE.RSGlobal.RSGlobal.CloneArray(vExts);
		NpcGenEntry[] array = (npcsArea.Gens = new NpcGenEntry[(nint)npcsArea.Gens.LongLength]);
		int num = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				npcsArea.Gens[num] = Gens[num].Clone();
				num++;
			}
			while (num < (nint)npcsArea.Gens.LongLength);
		}
		npcsArea.Attach = ACE.RSGlobal.RSGlobal.CloneArray(Attach);
		return npcsArea;
	}
}
