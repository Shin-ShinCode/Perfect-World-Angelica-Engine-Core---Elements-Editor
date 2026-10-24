using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class AWARD_MONSTERS_SUMMONED
{
	private int int_0;

	private bool bool_0;

	private int int_1;

	private bool bool_1;

	private MONSTERS_SUMMONED[] monsters_SUMMONED_0 = new MONSTERS_SUMMONED[0];

	public int m_ulMonsterNum
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

	public bool m_bRandChoose
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public int m_ulSummonRadius
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

	public bool m_bDeathDisappear
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public MONSTERS_SUMMONED[] m_Monsters
	{
		[CompilerGenerated]
		get
		{
			return monsters_SUMMONED_0;
		}
		[CompilerGenerated]
		set
		{
			monsters_SUMMONED_0 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, AWARD_MONSTERS_SUMMONED AMS)
	{
		AMS.m_bRandChoose = br.ReadBoolean();
		AMS.m_ulSummonRadius = br.ReadInt32();
		AMS.m_bDeathDisappear = br.ReadBoolean();
		AMS.m_Monsters = new MONSTERS_SUMMONED[AMS.m_ulMonsterNum];
		for (int i = 0; i < AMS.m_ulMonsterNum; i++)
		{
			AMS.m_Monsters[i] = new MONSTERS_SUMMONED();
			MONSTERS_SUMMONED.Read(version, br, AMS.m_Monsters[i]);
		}
	}

	internal static void Read2(int version, BinaryReader br, AWARD_MONSTERS_SUMMONED AMS)
	{
		AMS.m_Monsters = new MONSTERS_SUMMONED[32];
		if (version >= 180)
		{
			AMS.m_ulMonsterNum = br.ReadInt32();
			AMS.m_bRandChoose = br.ReadBoolean();
			AMS.m_ulSummonRadius = br.ReadInt32();
			AMS.m_bDeathDisappear = br.ReadBoolean();
		}
		for (int i = 0; i < 32; i++)
		{
			AMS.m_Monsters[i] = new MONSTERS_SUMMONED();
			if (version >= 180)
			{
				MONSTERS_SUMMONED.Read(version, br, AMS.m_Monsters[i]);
			}
		}
	}

	internal static void Read3(int version, BinaryReader br, AWARD_MONSTERS_SUMMONED AMS)
	{
		if (AMS.m_ulMonsterNum > 0)
		{
			AMS.m_ulMonsterNum = br.ReadInt32();
			AMS.m_bRandChoose = br.ReadBoolean();
			AMS.m_ulSummonRadius = br.ReadInt32();
			AMS.m_bDeathDisappear = br.ReadBoolean();
		}
		AMS.m_Monsters = new MONSTERS_SUMMONED[32];
		for (int i = 0; i < 32; i++)
		{
			AMS.m_Monsters[i] = new MONSTERS_SUMMONED();
			if (i < AMS.m_ulMonsterNum)
			{
				MONSTERS_SUMMONED.Read(version, br, AMS.m_Monsters[i]);
			}
		}
	}

	internal static void Write(int version, BinaryWriter bw, AWARD_MONSTERS_SUMMONED AMS)
	{
		bw.Write(AMS.m_bRandChoose);
		bw.Write(AMS.m_ulSummonRadius);
		bw.Write(AMS.m_bDeathDisappear);
		for (int i = 0; i < AMS.m_Monsters.Length; i++)
		{
			MONSTERS_SUMMONED.Write(version, bw, AMS.m_Monsters[i]);
		}
	}

	internal static void Write2(int version, BinaryWriter bw, AWARD_MONSTERS_SUMMONED AMS)
	{
		bw.Write(AMS.m_ulMonsterNum);
		bw.Write(AMS.m_bRandChoose);
		bw.Write(AMS.m_ulSummonRadius);
		bw.Write(AMS.m_bDeathDisappear);
		for (int i = 0; i < AMS.m_Monsters.Length; i++)
		{
			MONSTERS_SUMMONED.Write(version, bw, AMS.m_Monsters[i]);
		}
	}

	internal static void Write3(int version, BinaryWriter bw, AWARD_MONSTERS_SUMMONED AMS)
	{
		bw.Write(AMS.m_ulMonsterNum);
		bw.Write(AMS.m_bRandChoose);
		bw.Write(AMS.m_ulSummonRadius);
		bw.Write(AMS.m_bDeathDisappear);
		for (int i = 0; i < AMS.m_ulMonsterNum; i++)
		{
			MONSTERS_SUMMONED.Write(version, bw, AMS.m_Monsters[i]);
		}
	}
}
