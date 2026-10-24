using System;
using System.Collections.Generic;
using System.Linq;

namespace ACE.Classes.ACE_Octets;

public struct ITEMDATA
{
	private sealed class Class55
	{
		public ADDON addon_0;

		internal bool method_0(ADDON addon_1)
		{
			return addon_1.id != addon_0.id;
		}
	}

	public ITEMTYPE type;

	public int id;

	public short socket_count;

	public int[] sockets_id;

	public int id_type;

	public int lvl;

	public int hp;

	public int mp;

	public int armor;

	public int m_atc;

	public int f_atc;

	public float atc_pause;

	public int atc_speed_i;

	public float atc_speed_f;

	public float atc_range;

	public float atc_short_range;

	public int f_atc_min;

	public int f_atc_max;

	public int m_atc_min;

	public int m_atc_max;

	public int f_def;

	public int metal_def;

	public int wood_def;

	public int water_def;

	public int fire_def;

	public int earth_def;

	public int durability;

	public int durability_max;

	public int id_ammotype;

	public ushort req_classmask;

	public ushort req_level;

	public ushort req_strength;

	public ushort req_dexterity;

	public ushort req_intellect;

	public ushort req_vitality;

	public int is_ammo_required;

	public int addon_count;

	public List<ADDON> addons;

	public byte creator_len;

	public byte[] creator_bytes;

	public short EssenceSize;

	public byte flags;

	public short sockets_flag;

	public Dictionary<int, ADDON> AddonsDB;

	public void RemoveAddonAt(int index)
	{
		addons.RemoveAt(index);
		addon_count--;
	}

	public void AddAddon(int id, double param1 = -1.0, int param2 = -1, int param3 = -1)
	{
		ADDON item = AddonsDB[id];
		if (item.num_params > 0)
		{
			if (param1 > -1.0)
			{
				item.param1 = Convert.ToInt32(param1);
			}
			if (param2 > -1 && item.num_params > 1)
			{
				item.param2 = param2;
			}
			if (param3 > -1 && item.num_params > 2)
			{
				item.param3 = param3;
			}
			if (item.type != ADDONTYPE.ability)
			{
				item.num_params = 1;
				if (item.type == ADDONTYPE.attack_speed)
				{
					item.param1 = Convert.ToInt32(param1 * 20.0);
				}
				else if (item.type == ADDONTYPE.floated)
				{
					item.param1 = Convert.ToInt32(param1 * 100.0);
				}
			}
		}
		item.MakeData();
		addons.Add(item);
		addon_count++;
	}

	public void RemoveByDesc(string desc)
	{
		using List<ADDON>.Enumerator enumerator = addons.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class55 @class = new Class55();
			@class.addon_0 = enumerator.Current;
			if (@class.addon_0.desc.ToLower().Contains(desc.ToLower()))
			{
				addons = addons.Where(@class.method_0).ToList();
				addon_count--;
			}
		}
	}

	public void ReplaceAddon(int old, int int_0)
	{
		ADDON[] array = new ADDON[addons.Count];
		for (int i = 0; i < addons.Count; i++)
		{
			if (addons[i].id == old)
			{
				ADDON aDDON = AddonsDB[int_0];
				aDDON.MakeData();
				array[i] = aDDON;
			}
			else
			{
				array[i] = addons[i];
			}
		}
		addons = array.ToList();
	}

	private float method_0(int int_0)
	{
		return BitConverter.ToSingle(BitConverter.GetBytes(int_0), 0);
	}
}
