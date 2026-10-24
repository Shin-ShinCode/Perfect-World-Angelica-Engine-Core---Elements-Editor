using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class VAGUE_PROMPT_INFO
{
	private float float_0;

	private float float_1;

	private float float_2;

	public float m_fVaguePromptRadius
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

	public float m_fVaguePromptX
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	public float m_fVaguePromptY
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, VAGUE_PROMPT_INFO vpi)
	{
		vpi.m_fVaguePromptRadius = br.ReadSingle();
		vpi.m_fVaguePromptX = br.ReadSingle();
		vpi.m_fVaguePromptY = br.ReadSingle();
	}

	internal static void Write(int version, BinaryWriter bw, VAGUE_PROMPT_INFO vpi)
	{
		bw.Write(vpi.m_fVaguePromptRadius);
		bw.Write(vpi.m_fVaguePromptX);
		bw.Write(vpi.m_fVaguePromptY);
	}
}
