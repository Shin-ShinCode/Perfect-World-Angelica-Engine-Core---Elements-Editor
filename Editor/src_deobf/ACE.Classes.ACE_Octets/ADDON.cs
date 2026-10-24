using System;

namespace ACE.Classes.ACE_Octets;

public struct ADDON
{
	public int id;

	public int num_params;

	public int param1;

	public int param2;

	public int param3;

	public ADDONTYPE type;

	public string desc;

	public bool mosaic_15th;

	public bool unused_16th;

	public bool engraved_17th;

	public byte[] addon_data;

	public void ReadData(byte[] data)
	{
		addon_data = data;
		BitReader bitReader = new BitReader(data);
		id = bitReader.ReadInt32(13);
		num_params = bitReader.ReadInt32(2);
		mosaic_15th = bitReader.ReadBool();
		unused_16th = bitReader.ReadBool();
		engraved_17th = bitReader.ReadBool();
	}

	public void MakeData()
	{
		BitWriter bitWriter = new BitWriter();
		bitWriter.Write(id, 13);
		bitWriter.Write(num_params, 2);
		bitWriter.Write(mosaic_15th);
		bitWriter.Write(unused_16th);
		bitWriter.Write(engraved_17th);
		addon_data = bitWriter.GetBytes();
	}

	public string GetAddonHeadOctet()
	{
		MakeData();
		return BitConverter.ToString(addon_data).Replace(Class16.smethod_0(1648941518), string.Empty);
	}

	public static string GetAddonHeadOctet(int id, int num_params)
	{
		ADDON aDDON = new ADDON
		{
			id = id,
			num_params = num_params
		};
		return aDDON.GetAddonHeadOctet();
	}
}
