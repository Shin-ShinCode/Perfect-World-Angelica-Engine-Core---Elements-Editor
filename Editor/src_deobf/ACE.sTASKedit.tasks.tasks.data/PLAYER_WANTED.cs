using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class PLAYER_WANTED
{
	private int int_0 = 1;

	private int int_1;

	private int int_2;

	private bool bool_0;

	private float float_0;

	private Kill_Player_Requirements kill_Player_Requirements_0 = new Kill_Player_Requirements();

	public int m_ulPlayerNum
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

	public int m_ulDropItemId
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

	public int m_ulDropItemCount
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

	public Kill_Player_Requirements m_Requirements
	{
		[CompilerGenerated]
		get
		{
			return kill_Player_Requirements_0;
		}
		[CompilerGenerated]
		set
		{
			kill_Player_Requirements_0 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, PLAYER_WANTED PW)
	{
		PW.m_ulPlayerNum = br.ReadInt32();
		PW.m_ulDropItemId = br.ReadInt32();
		PW.m_ulDropItemCount = br.ReadInt32();
		PW.m_bDropCmnItem = br.ReadBoolean();
		PW.m_fDropProb = br.ReadSingle();
		Kill_Player_Requirements.Read(version, br, PW.m_Requirements);
	}

	internal static void Write(int version, BinaryWriter bw, PLAYER_WANTED PW)
	{
		bw.Write(PW.m_ulPlayerNum);
		bw.Write(PW.m_ulDropItemId);
		bw.Write(PW.m_ulDropItemCount);
		bw.Write(PW.m_bDropCmnItem);
		bw.Write(PW.m_fDropProb);
		Kill_Player_Requirements.Write(version, bw, PW.m_Requirements);
	}
}
