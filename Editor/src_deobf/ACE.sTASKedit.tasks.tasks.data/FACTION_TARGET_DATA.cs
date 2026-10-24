using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class FACTION_TARGET_DATA
{
	private int int_0;

	private int int_1 = 1;

	public int FactionTargetId
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

	public int FactionNum
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

	internal static void Read(int version, BinaryReader br, FACTION_TARGET_DATA FACTION_TARGET_DATA)
	{
		FACTION_TARGET_DATA.FactionTargetId = br.ReadInt32();
		FACTION_TARGET_DATA.FactionNum = br.ReadInt32();
	}

	internal static void Write(int version, BinaryWriter bw, FACTION_TARGET_DATA FACTION_TARGET_DATA)
	{
		bw.Write(FACTION_TARGET_DATA.FactionTargetId);
		bw.Write(FACTION_TARGET_DATA.FactionNum);
	}
}
