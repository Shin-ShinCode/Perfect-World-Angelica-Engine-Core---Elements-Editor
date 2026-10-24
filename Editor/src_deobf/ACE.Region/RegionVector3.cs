using System;
using System.Globalization;
using System.IO;

namespace ACE.Region;

public class RegionVector3
{
	public string oX = Class16.smethod_0(1648924112);

	public string oY = Class16.smethod_0(1648924112);

	public string oZ = Class16.smethod_0(1648924112);

	public float Single_0 => Convert.ToSingle(oX, CultureInfo.InvariantCulture);

	public float Single_1 => Convert.ToSingle(oY, CultureInfo.InvariantCulture);

	public float Single_2 => Convert.ToSingle(oZ, CultureInfo.InvariantCulture);

	public RegionVector3()
	{
		oX = Class16.smethod_0(1648924112);
		oY = Class16.smethod_0(1648924112);
		oZ = Class16.smethod_0(1648924112);
	}

	public RegionVector3(string string_0, string string_1, string string_2)
	{
		oX = string_0.Trim();
		oY = string_1.Trim();
		oZ = string_2.Trim();
	}

	public RegionVector3(string line, char split)
	{
		string[] array = line.Split(split);
		oX = ((array.Length != 0) ? array[0].Trim() : Class16.smethod_0(1648924112));
		oY = ((array.Length > 1) ? array[1].Trim() : Class16.smethod_0(1648924112));
		oZ = ((array.Length > 2) ? array[2].Trim() : Class16.smethod_0(1648924112));
	}

	public RegionVector3(string line)
	{
		string[] array = line.Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
		oX = ((array.Length != 0) ? array[0].Trim() : Class16.smethod_0(1648924112));
		oY = ((array.Length > 1) ? array[1].Trim() : Class16.smethod_0(1648924112));
		oZ = ((array.Length > 2) ? array[2].Trim() : Class16.smethod_0(1648924112));
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Single_0);
		bw.Write(Single_1);
		bw.Write(Single_2);
	}

	public string ToStringSpaced()
	{
		return oX + Class16.smethod_0(1649043292) + oY + Class16.smethod_0(1649043292) + oZ;
	}

	public string ToStringComma()
	{
		return oX + Class16.smethod_0(1648942920) + oY + Class16.smethod_0(1648942920) + oZ;
	}

	public RegionVector3 Clone()
	{
		return new RegionVector3(oX, oY, oZ);
	}
}
