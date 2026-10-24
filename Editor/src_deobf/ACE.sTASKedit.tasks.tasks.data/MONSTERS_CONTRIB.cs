using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class MONSTERS_CONTRIB
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	public int m_ulMonsterTemplId
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

	public int m_iWholeContrib
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

	public int m_iShareContrib
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

	public int m_iPersonalWholeContrib
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

	internal static void Read(int version, BinaryReader br, MONSTERS_CONTRIB MONSTERS_CONTRIB)
	{
		MONSTERS_CONTRIB.m_ulMonsterTemplId = br.ReadInt32();
		MONSTERS_CONTRIB.m_iWholeContrib = br.ReadInt32();
		MONSTERS_CONTRIB.m_iShareContrib = br.ReadInt32();
		if (version >= 82)
		{
			MONSTERS_CONTRIB.m_iPersonalWholeContrib = br.ReadInt32();
		}
	}

	internal static void Write(int version, BinaryWriter bw, MONSTERS_CONTRIB MONSTERS_CONTRIB)
	{
		bw.Write(MONSTERS_CONTRIB.m_ulMonsterTemplId);
		bw.Write(MONSTERS_CONTRIB.m_iWholeContrib);
		bw.Write(MONSTERS_CONTRIB.m_iShareContrib);
		if (version >= 82)
		{
			bw.Write(MONSTERS_CONTRIB.m_iPersonalWholeContrib);
		}
	}
}
