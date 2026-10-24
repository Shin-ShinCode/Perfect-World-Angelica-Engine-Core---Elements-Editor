using System;
using System.Collections.Generic;
using System.IO;

namespace ACE.Classes.ACE_Octets;

public class OctetManager
{
	private Dictionary<int, ADDON> dictionary_0;

	public OctetManager(string Ace_Addons_fn)
	{
		using StreamReader streamReader = File.OpenText(Ace_Addons_fn);
		dictionary_0 = new Dictionary<int, ADDON>();
		string text;
		while ((text = streamReader.ReadLine()) != null)
		{
			string[] array = text.Split(';');
			ADDON value = new ADDON
			{
				id = Convert.ToInt32(array[0]),
				num_params = Convert.ToInt32(array[1]),
				type = (ADDONTYPE)Convert.ToInt32(array[2]),
				desc = array[3]
			};
			dictionary_0.Add(value.id, value);
		}
	}

	public OctetManager()
	{
	}

	public ITEMDATA ReadOctet(string sOctet, ITEMTYPE item_type = ITEMTYPE.auto)
	{
		return ReadOctet(smethod_0(sOctet), item_type);
	}

	public ITEMDATA ReadOctet(byte[] octet, ITEMTYPE item_type = ITEMTYPE.auto)
	{
		MemoryStream memoryStream = new MemoryStream(octet);
		try
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			try
			{
				ITEMDATA result = new ITEMDATA
				{
					AddonsDB = dictionary_0,
					type = item_type,
					req_level = binaryReader.ReadUInt16(),
					req_classmask = binaryReader.ReadUInt16(),
					req_strength = binaryReader.ReadUInt16(),
					req_vitality = binaryReader.ReadUInt16(),
					req_dexterity = binaryReader.ReadUInt16(),
					req_intellect = binaryReader.ReadUInt16(),
					durability = binaryReader.ReadInt32(),
					durability_max = binaryReader.ReadInt32(),
					EssenceSize = binaryReader.ReadInt16(),
					flags = binaryReader.ReadByte(),
					creator_len = binaryReader.ReadByte()
				};
				result.creator_bytes = binaryReader.ReadBytes(result.creator_len);
				if (result.type == ITEMTYPE.auto)
				{
					if (result.EssenceSize == 44)
					{
						result.type = ITEMTYPE.weapon;
					}
					else
					{
						result.type = ((binaryReader.ReadInt32() == 0) ? ITEMTYPE.ornament : ITEMTYPE.armor);
						binaryReader.BaseStream.Position -= 4L;
					}
				}
				switch (result.type)
				{
				default:
					throw new ArgumentOutOfRangeException(Class16.smethod_0(1648907626));
				case ITEMTYPE.weapon:
					result.is_ammo_required = binaryReader.ReadInt32();
					result.id_type = binaryReader.ReadInt32();
					result.lvl = binaryReader.ReadInt32();
					result.id_ammotype = binaryReader.ReadInt32();
					result.f_atc_min = binaryReader.ReadInt32();
					result.f_atc_max = binaryReader.ReadInt32();
					result.m_atc_min = binaryReader.ReadInt32();
					result.m_atc_max = binaryReader.ReadInt32();
					result.atc_speed_i = binaryReader.ReadInt32();
					result.atc_range = binaryReader.ReadSingle();
					result.atc_short_range = binaryReader.ReadSingle();
					result.atc_pause = (float)result.atc_speed_i / 20f;
					break;
				case ITEMTYPE.armor:
					result.f_def = binaryReader.ReadInt32();
					result.armor = binaryReader.ReadInt32();
					result.mp = binaryReader.ReadInt32();
					result.hp = binaryReader.ReadInt32();
					break;
				case ITEMTYPE.ornament:
					result.f_atc = binaryReader.ReadInt32();
					result.m_atc = binaryReader.ReadInt32();
					result.f_def = binaryReader.ReadInt32();
					result.armor = binaryReader.ReadInt32();
					break;
				}
				if (result.type != ITEMTYPE.weapon)
				{
					result.metal_def = binaryReader.ReadInt32();
					result.wood_def = binaryReader.ReadInt32();
					result.water_def = binaryReader.ReadInt32();
					result.fire_def = binaryReader.ReadInt32();
					result.earth_def = binaryReader.ReadInt32();
				}
				result.socket_count = binaryReader.ReadInt16();
				result.sockets_flag = binaryReader.ReadInt16();
				result.sockets_id = new int[result.socket_count];
				for (int i = 0; i < result.socket_count; i++)
				{
					result.sockets_id[i] = binaryReader.ReadInt32();
				}
				result.addon_count = binaryReader.ReadInt32();
				result.addons = new List<ADDON>(result.addon_count);
				for (int j = 0; j < result.addon_count; j++)
				{
					result.addons.Add(ReadAddon(binaryReader));
				}
				return result;
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public string GenerateOctetS(ITEMDATA it)
	{
		return BitConverter.ToString(GenerateOctet(it)).Replace(Class16.smethod_0(1648941518), string.Empty).ToLowerInvariant();
	}

	public byte[] GenerateOctet(ITEMDATA it)
	{
		it.AddonsDB = dictionary_0;
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(it.req_level);
			binaryWriter.Write(it.req_classmask);
			binaryWriter.Write(it.req_strength);
			binaryWriter.Write(it.req_vitality);
			binaryWriter.Write(it.req_dexterity);
			binaryWriter.Write(it.req_intellect);
			binaryWriter.Write(it.durability);
			binaryWriter.Write(it.durability_max);
			binaryWriter.Write(it.EssenceSize);
			binaryWriter.Write(it.flags);
			binaryWriter.Write(it.creator_len);
			binaryWriter.Write(it.creator_bytes);
			switch (it.type)
			{
			default:
				throw new ArgumentOutOfRangeException();
			case ITEMTYPE.weapon:
				binaryWriter.Write(it.is_ammo_required);
				binaryWriter.Write(it.id_type);
				binaryWriter.Write(it.lvl);
				binaryWriter.Write(it.id_ammotype);
				binaryWriter.Write(it.f_atc_min);
				binaryWriter.Write(it.f_atc_max);
				binaryWriter.Write(it.m_atc_min);
				binaryWriter.Write(it.m_atc_max);
				binaryWriter.Write(it.atc_speed_i);
				binaryWriter.Write(it.atc_range);
				binaryWriter.Write(it.atc_short_range);
				break;
			case ITEMTYPE.armor:
				binaryWriter.Write(it.f_def);
				binaryWriter.Write(it.armor);
				binaryWriter.Write(it.mp);
				binaryWriter.Write(it.hp);
				break;
			case ITEMTYPE.ornament:
				binaryWriter.Write(it.f_atc);
				binaryWriter.Write(it.m_atc);
				binaryWriter.Write(it.f_def);
				binaryWriter.Write(it.armor);
				break;
			}
			if (it.type != ITEMTYPE.weapon)
			{
				binaryWriter.Write(it.metal_def);
				binaryWriter.Write(it.wood_def);
				binaryWriter.Write(it.water_def);
				binaryWriter.Write(it.fire_def);
				binaryWriter.Write(it.earth_def);
			}
			binaryWriter.Write(it.socket_count);
			binaryWriter.Write(it.sockets_flag);
			for (int i = 0; i < it.socket_count; i++)
			{
				binaryWriter.Write(it.sockets_id[i]);
			}
			binaryWriter.Write(it.addon_count);
			for (int j = 0; j < it.addon_count; j++)
			{
				ADDON aDDON = it.addons[j];
				binaryWriter.Write(aDDON.addon_data);
				if (aDDON.num_params <= 0)
				{
					continue;
				}
				binaryWriter.Write(aDDON.param1);
				if (aDDON.num_params > 1)
				{
					binaryWriter.Write(aDDON.param2);
					if (aDDON.num_params > 2)
					{
						binaryWriter.Write(aDDON.param3);
					}
				}
			}
			return memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public ADDON ReadAddon(BinaryReader br)
	{
		ADDON result = default(ADDON);
		result.ReadData(br.ReadBytes(4));
		if (result.num_params > 0)
		{
			result.param1 = br.ReadInt32();
			if (result.num_params > 1)
			{
				result.param2 = br.ReadInt32();
				if (result.num_params > 2)
				{
					result.param3 = br.ReadInt32();
				}
			}
		}
		if (dictionary_0 != null && dictionary_0.ContainsKey(result.id))
		{
			result.desc = dictionary_0[result.id].desc;
			result.type = dictionary_0[result.id].type;
		}
		return result;
	}

	private static byte[] smethod_0(string string_0)
	{
		byte[] array = new byte[string_0.Length / 2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Convert.ToByte(string_0.Substring(i * 2, 2), 16);
		}
		return array;
	}
}
