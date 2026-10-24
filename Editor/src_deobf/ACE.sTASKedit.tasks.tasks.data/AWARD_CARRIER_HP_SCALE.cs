using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class AWARD_CARRIER_HP_SCALE
{
	private int int_0;

	private int[] int_1 = new int[5];

	private AWARD_DATA[] award_DATA_0 = new AWARD_DATA[0];

	public int m_ulScales
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

	public int[] AwardCarrierHp
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

	public AWARD_DATA[] m_Awards
	{
		[CompilerGenerated]
		get
		{
			return award_DATA_0;
		}
		[CompilerGenerated]
		set
		{
			award_DATA_0 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, AWARD_CARRIER_HP_SCALE ACHS)
	{
		ACHS.m_ulScales = br.ReadInt32();
		for (int i = 0; i < ACHS.AwardCarrierHp.Length; i++)
		{
			ACHS.AwardCarrierHp[i] = br.ReadInt32();
		}
		ACHS.m_Awards = new AWARD_DATA[ACHS.m_ulScales];
		for (int j = 0; j < ACHS.m_Awards.Length; j++)
		{
			ACHS.m_Awards[j] = new AWARD_DATA();
			AWARD_DATA.Read(version, br, ACHS.m_Awards[j]);
		}
	}

	internal static void Write(int version, BinaryWriter bw, AWARD_CARRIER_HP_SCALE ACHS)
	{
		bw.Write(ACHS.m_ulScales);
		for (int i = 0; i < ACHS.AwardCarrierHp.Length; i++)
		{
			bw.Write(ACHS.AwardCarrierHp[i]);
		}
		for (int j = 0; j < ACHS.m_Awards.Length; j++)
		{
			AWARD_DATA.Write(version, bw, ACHS.m_Awards[j]);
		}
	}
}
