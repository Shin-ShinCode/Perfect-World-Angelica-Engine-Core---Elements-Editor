using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class Kill_Player_Requirements
{
	private int int_0;

	private int int_1 = 1;

	private int int_2 = 150;

	private int int_3;

	private int int_4;

	private bool bool_0;

	private byte[] byte_0 = new byte[3];

	public int m_ulOccupations
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

	public int m_iMinLevel
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

	public int m_iMaxLevel
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

	public int m_iGender
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

	public int m_iForce
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

	public bool ModelCheck
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

	public byte[] ModelType
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

	internal static void Read(int version, BinaryReader br, Kill_Player_Requirements KPR)
	{
		KPR.m_ulOccupations = br.ReadInt32();
		KPR.m_iMinLevel = br.ReadInt32();
		KPR.m_iMaxLevel = br.ReadInt32();
		KPR.m_iGender = br.ReadInt32();
		KPR.m_iForce = br.ReadInt32();
		if (version >= 130)
		{
			KPR.ModelCheck = br.ReadBoolean();
			for (int i = 0; i < 3; i++)
			{
				KPR.ModelType[i] = br.ReadByte();
			}
		}
	}

	internal static void Write(int version, BinaryWriter bw, Kill_Player_Requirements KPR)
	{
		bw.Write(KPR.m_ulOccupations);
		bw.Write(KPR.m_iMinLevel);
		bw.Write(KPR.m_iMaxLevel);
		bw.Write(KPR.m_iGender);
		bw.Write(KPR.m_iForce);
		if (version >= 130)
		{
			bw.Write(KPR.ModelCheck);
			for (byte b = 0; b < 3; b++)
			{
				bw.Write(KPR.ModelType[b]);
			}
		}
	}
}
