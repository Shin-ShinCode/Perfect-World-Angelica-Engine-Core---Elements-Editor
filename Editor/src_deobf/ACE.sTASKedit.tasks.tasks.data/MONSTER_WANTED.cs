using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class MONSTER_WANTED
{
	private int int_0;

	private int int_1 = 1;

	private int int_2;

	private int int_3;

	private bool bool_0;

	private float float_0;

	private byte byte_0;

	private int int_4;

	private int int_5;

	private int int_6;

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

	public int m_ulMonsterNum
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

	public int m_ulDropItemId
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

	public int m_ulDropItemCount
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

	public bool m_bDropCmnItem
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

	public float m_fDropProb
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public byte m_bKillerLev
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public int m_iDPH
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

	public int m_iDPS
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

	public int m_iWorldLevel
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

	internal static void Read(int version, BinaryReader br, MONSTER_WANTED MW)
	{
		MW.m_ulMonsterTemplId = br.ReadInt32();
		MW.m_ulMonsterNum = br.ReadInt32();
		MW.m_ulDropItemId = br.ReadInt32();
		MW.m_ulDropItemCount = br.ReadInt32();
		MW.m_bDropCmnItem = br.ReadBoolean();
		MW.m_fDropProb = br.ReadSingle();
		MW.m_bKillerLev = br.ReadByte();
		if (version >= 92)
		{
			MW.m_iDPH = br.ReadInt32();
			MW.m_iDPS = br.ReadInt32();
		}
		if (version >= 226)
		{
			MW.m_iWorldLevel = br.ReadInt32();
		}
	}

	internal static void Write(int version, BinaryWriter bw, MONSTER_WANTED MW)
	{
		bw.Write(MW.m_ulMonsterTemplId);
		bw.Write(MW.m_ulMonsterNum);
		bw.Write(MW.m_ulDropItemId);
		bw.Write(MW.m_ulDropItemCount);
		bw.Write(MW.m_bDropCmnItem);
		bw.Write(MW.m_fDropProb);
		bw.Write(MW.m_bKillerLev);
		if (version >= 92)
		{
			bw.Write(MW.m_iDPH);
			bw.Write(MW.m_iDPS);
		}
		if (version >= 226)
		{
			bw.Write(MW.m_iWorldLevel);
		}
	}
}
