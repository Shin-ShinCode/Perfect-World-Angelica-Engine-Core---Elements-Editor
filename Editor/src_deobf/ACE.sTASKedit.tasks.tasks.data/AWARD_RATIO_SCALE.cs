using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class AWARD_RATIO_SCALE
{
	private int int_0;

	private float[] float_0 = new float[6];

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

	public float[] m_Ratios
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

	internal static void Read(int version, BinaryReader br, AWARD_RATIO_SCALE AWARD_RATIO_SCALE)
	{
		AWARD_RATIO_SCALE.m_ulScales = br.ReadInt32();
		int maxAwardScales = GlobalFunctions.GetMaxAwardScales(version);
		for (int i = 0; i < maxAwardScales; i++)
		{
			AWARD_RATIO_SCALE.m_Ratios[i] = br.ReadSingle();
		}
		AWARD_RATIO_SCALE.m_Awards = new AWARD_DATA[AWARD_RATIO_SCALE.m_ulScales];
		for (int j = 0; j < AWARD_RATIO_SCALE.m_ulScales; j++)
		{
			AWARD_RATIO_SCALE.m_Awards[j] = new AWARD_DATA();
			AWARD_DATA.Read(version, br, AWARD_RATIO_SCALE.m_Awards[j]);
		}
	}

	internal static void Write(int version, BinaryWriter bw, AWARD_RATIO_SCALE AWARD_RATIO_SCALE)
	{
		int maxAwardScales = GlobalFunctions.GetMaxAwardScales(version);
		if (AWARD_RATIO_SCALE.m_ulScales > maxAwardScales)
		{
			bw.Write(maxAwardScales);
		}
		else
		{
			bw.Write(AWARD_RATIO_SCALE.m_ulScales);
		}
		for (int i = 0; i < maxAwardScales; i++)
		{
			bw.Write(AWARD_RATIO_SCALE.m_Ratios[i]);
		}
		for (int j = 0; j < AWARD_RATIO_SCALE.m_ulScales && j < maxAwardScales; j++)
		{
			AWARD_DATA.Write(version, bw, AWARD_RATIO_SCALE.m_Awards[j]);
		}
	}
}
