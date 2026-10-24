using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.ExtraDrops;

public class EXTRADROPTABLE
{
	public int MonsterCount;

	public List<int> id_monsters;

	public DROP_ITEMS[] drop_items;

	public byte[] name;

	public EDT_TYPE type;

	public float[] drop_num_probability;

	public static Encoding GB2312 = Encoding.GetEncoding(Class16.smethod_0(1648921191));

	public List<DROP_ITEMS> SortedDrop
	{
		get
		{
			List<DROP_ITEMS> list = new List<DROP_ITEMS>();
			DROP_ITEMS[] array = drop_items;
			int num = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					DROP_ITEMS dROP_ITEMS = array[num];
					DROP_ITEMS dROP_ITEMS2 = dROP_ITEMS;
					if (dROP_ITEMS2.id > 0)
					{
						list.Add(dROP_ITEMS);
					}
					num++;
				}
				while (num < (nint)array.LongLength);
			}
			list.Sort();
			list.Reverse();
			GC.KeepAlive(this);
			return list;
		}
	}

	public string Name
	{
		get
		{
			byte[] bytes = name;
			string text = GB2312.GetString(bytes);
			int num = text.IndexOf('\0');
			string result = ((num >= 0) ? text.Substring(0, num) : text);
			GC.KeepAlive(this);
			return result;
		}
		set
		{
			name = ACE.RSGlobal.RSGlobal.ToBytesGBK(value, 128);
			GC.KeepAlive(this);
		}
	}

	public EXTRADROPTABLE()
	{
		MonsterCount = 0;
		id_monsters = new List<int>();
		drop_items = new DROP_ITEMS[256];
		name = new byte[128];
		type = EDT_TYPE.Addon;
		drop_num_probability = new float[8];
		drop_num_probability[0] = 1f;
	}

	public EXTRADROPTABLE(BinaryReader br)
	{
		drop_items = new DROP_ITEMS[256];
		drop_num_probability = new float[8];
		id_monsters = new List<int>(MonsterCount = br.ReadInt32());
		int num = 0;
		if (0 < MonsterCount)
		{
			do
			{
				id_monsters.Add(br.ReadInt32());
				num++;
			}
			while (num < MonsterCount);
		}
		int num2 = 0;
		do
		{
			DROP_ITEMS dROP_ITEMS = new DROP_ITEMS(br);
			drop_items[num2] = dROP_ITEMS;
			num2++;
		}
		while (num2 < 256);
		name = br.ReadBytes(128);
		type = (EDT_TYPE)br.ReadInt32();
		int num3 = 0;
		do
		{
			drop_num_probability[num3] = br.ReadSingle();
			num3++;
		}
		while (num3 < 8);
		GC.KeepAlive(this);
	}

	public static EXTRADROPTABLE CreateEmpty(string tableName = "New Table")
	{
		EXTRADROPTABLE eXTRADROPTABLE = new EXTRADROPTABLE();
		eXTRADROPTABLE.Name = tableName ?? string.Empty;
		return eXTRADROPTABLE;
	}

	public void ValidateAndFix()
	{
		if (id_monsters == null)
		{
			id_monsters = new List<int>();
		}
		if (drop_items == null || drop_items.Length != 256)
		{
			DROP_ITEMS[] array = new DROP_ITEMS[256];
			if (drop_items != null && drop_items.Length != 0)
			{
				Array.Copy(drop_items, array, Math.Min(drop_items.Length, array.Length));
			}
			drop_items = array;
		}
		if (name == null || name.Length != 128)
		{
			byte[] array2 = new byte[128];
			if (name != null && name.Length != 0)
			{
				Array.Copy(name, array2, Math.Min(name.Length, array2.Length));
			}
			name = array2;
		}
		if (drop_num_probability == null || drop_num_probability.Length != 8)
		{
			float[] array3 = new float[8];
			if (drop_num_probability != null && drop_num_probability.Length != 0)
			{
				Array.Copy(drop_num_probability, array3, Math.Min(drop_num_probability.Length, array3.Length));
			}
			else
			{
				array3[0] = 1f;
			}
			drop_num_probability = array3;
		}
	}

	public void Save(BinaryWriter bw)
	{
		ValidateAndFix();
		bw.Write(id_monsters.Count);
		int num = 0;
		if (0 < id_monsters.Count)
		{
			do
			{
				bw.Write(id_monsters[num]);
				num++;
			}
			while (num < id_monsters.Count);
		}
		int num2 = 0;
		do
		{
			drop_items[num2].Save(bw);
			num2++;
		}
		while (num2 < 256);
		bw.Write(name);
		bw.Write((int)type);
		int num3 = 0;
		do
		{
			bw.Write(drop_num_probability[num3]);
			num3++;
		}
		while (num3 < 8);
		GC.KeepAlive(this);
	}
}
