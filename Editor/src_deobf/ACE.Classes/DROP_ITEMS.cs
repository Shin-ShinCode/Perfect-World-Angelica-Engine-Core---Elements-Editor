using System;
using System.IO;

namespace ACE.Classes;

public struct DROP_ITEMS(BinaryReader br) : IComparable
{
	public int id = br.ReadInt32();

	public float probability = br.ReadSingle();

	public void Save(BinaryWriter bw)
	{
		bw.Write(id);
		bw.Write(probability);
	}

	public int CompareTo(object obj)
	{
		if (obj == null)
		{
			return 1;
		}
		DROP_ITEMS dROP_ITEMS = (DROP_ITEMS)obj;
		float num = probability;
		return num.CompareTo(dROP_ITEMS.probability);
	}
}
