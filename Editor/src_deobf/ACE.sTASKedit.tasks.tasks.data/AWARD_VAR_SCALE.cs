using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class AWARD_VAR_SCALE
{
	private int int_0;

	private TASK_EXPRESSION[] task_EXPRESSION_0 = TASK_EXPRESSION.New(16);

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

	public TASK_EXPRESSION[] AwardVar
	{
		[CompilerGenerated]
		get
		{
			return task_EXPRESSION_0;
		}
		[CompilerGenerated]
		set
		{
			task_EXPRESSION_0 = value;
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

	internal static void Read(int version, BinaryReader br, AWARD_VAR_SCALE AWARD_VAR_SCALE)
	{
		AWARD_VAR_SCALE.m_ulScales = br.ReadInt32();
		for (int i = 0; i < AWARD_VAR_SCALE.AwardVar.Length; i++)
		{
			TASK_EXPRESSION.Read(version, br, AWARD_VAR_SCALE.AwardVar[i]);
		}
		AWARD_VAR_SCALE.m_Awards = new AWARD_DATA[AWARD_VAR_SCALE.m_ulScales];
		for (int j = 0; j < AWARD_VAR_SCALE.m_Awards.Length; j++)
		{
			AWARD_VAR_SCALE.m_Awards[j] = new AWARD_DATA();
			AWARD_DATA.Read(version, br, AWARD_VAR_SCALE.m_Awards[j]);
		}
	}

	internal static void Write(int version, BinaryWriter bw, AWARD_VAR_SCALE AWARD_VAR_SCALE)
	{
		bw.Write(AWARD_VAR_SCALE.m_ulScales);
		for (int i = 0; i < AWARD_VAR_SCALE.AwardVar.Length; i++)
		{
			TASK_EXPRESSION.Write(version, bw, AWARD_VAR_SCALE.AwardVar[i]);
		}
		for (int j = 0; j < AWARD_VAR_SCALE.m_Awards.Length; j++)
		{
			AWARD_DATA.Write(version, bw, AWARD_VAR_SCALE.m_Awards[j]);
		}
	}
}
