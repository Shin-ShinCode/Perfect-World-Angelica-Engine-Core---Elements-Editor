using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class Task_Region
{
	private int int_0;

	private int int_1;

	private ZONE_VERT zone_VERT_0 = new ZONE_VERT();

	private ZONE_VERT zone_VERT_1 = new ZONE_VERT();

	public int MapID
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

	public int RegionID
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

	public ZONE_VERT zvMin
	{
		[CompilerGenerated]
		get
		{
			return zone_VERT_0;
		}
		[CompilerGenerated]
		set
		{
			zone_VERT_0 = value;
		}
	}

	public ZONE_VERT zvMax
	{
		[CompilerGenerated]
		get
		{
			return zone_VERT_1;
		}
		[CompilerGenerated]
		set
		{
			zone_VERT_1 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, Task_Region Task_Region)
	{
		if (version >= 157)
		{
			Task_Region.MapID = br.ReadInt32();
		}
		if (version >= 191)
		{
			Task_Region.RegionID = br.ReadInt32();
		}
		ZONE_VERT.Read(version, br, Task_Region.zvMin);
		ZONE_VERT.Read(version, br, Task_Region.zvMax);
	}

	internal static void Write(int version, BinaryWriter bw, Task_Region Task_Region)
	{
		if (version >= 157)
		{
			bw.Write(Task_Region.MapID);
		}
		if (version >= 191)
		{
			bw.Write(Task_Region.RegionID);
		}
		ZONE_VERT.Write(version, bw, Task_Region.zvMin);
		ZONE_VERT.Write(version, bw, Task_Region.zvMax);
	}
}
