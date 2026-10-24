using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class TEAM_MEM_WANTED
{
	private int int_0;

	private int int_1 = 150;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6 = 10;

	private int int_7;

	private int int_8;

	private short short_0;

	public int m_ulLevelMin
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

	public int m_ulLevelMax
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

	public int m_ulRace
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public int m_ulOccupation
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public int m_ulGender
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public int m_ulMinCount
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public int m_ulMaxCount
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	public int m_ulTask
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	public int m_iForce
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}

	public short TeamMemTaskSpace
	{
		[CompilerGenerated]
		get
		{
			return short_0;
		}
		[CompilerGenerated]
		set
		{
			short_0 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, TEAM_MEM_WANTED TMW)
	{
		TMW.m_ulLevelMin = br.ReadInt32();
		TMW.m_ulLevelMax = br.ReadInt32();
		TMW.m_ulRace = br.ReadInt32();
		TMW.m_ulOccupation = br.ReadInt32();
		TMW.m_ulGender = br.ReadInt32();
		TMW.m_ulMinCount = br.ReadInt32();
		TMW.m_ulMaxCount = br.ReadInt32();
		TMW.m_ulTask = br.ReadInt32();
		if (version >= 97)
		{
			TMW.m_iForce = br.ReadInt32();
		}
		if (version >= 153)
		{
			TMW.TeamMemTaskSpace = br.ReadInt16();
		}
	}

	internal static void Write(int version, BinaryWriter bw, TEAM_MEM_WANTED TMW)
	{
		bw.Write(TMW.m_ulLevelMin);
		bw.Write(TMW.m_ulLevelMax);
		bw.Write(TMW.m_ulRace);
		bw.Write(TMW.m_ulOccupation);
		bw.Write(TMW.m_ulGender);
		bw.Write(TMW.m_ulMinCount);
		bw.Write(TMW.m_ulMaxCount);
		bw.Write(TMW.m_ulTask);
		if (version >= 97)
		{
			bw.Write(TMW.m_iForce);
		}
		if (version >= 153)
		{
			bw.Write(TMW.TeamMemTaskSpace);
		}
	}
}
