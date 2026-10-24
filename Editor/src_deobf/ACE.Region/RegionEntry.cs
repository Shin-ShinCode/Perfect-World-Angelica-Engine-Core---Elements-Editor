using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Region;

public class RegionEntry
{
	private int int_0;

	private int int_1;

	private string string_0 = string.Empty;

	private List<RegionVector3> list_0 = new List<RegionVector3>();

	public int Type
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int Strategy
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public string name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public List<RegionVector3> Zones
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public int ZoneCount => Zones?.Count ?? 0;

	public RegionEntry Clone()
	{
		RegionEntry regionEntry = new RegionEntry();
		regionEntry.Type = Type;
		regionEntry.Strategy = Strategy;
		regionEntry.name = name;
		regionEntry.Zones = new List<RegionVector3>();
		foreach (RegionVector3 zone in Zones)
		{
			regionEntry.Zones.Add(zone.Clone());
		}
		return regionEntry;
	}
}
