using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class TITLE_AWARD
{
	private int int_0;

	private int int_1;

	private uint uint_0;

	public int m_ulTitleID
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

	public int m_lPeriod
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

	public uint m_ulServerLimit
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, TITLE_AWARD TA)
	{
		TA.m_ulTitleID = br.ReadInt32();
		TA.m_lPeriod = br.ReadInt32();
		if (version >= 234)
		{
			TA.m_ulServerLimit = br.ReadUInt32();
		}
	}

	internal static void Write(int version, BinaryWriter bw, TITLE_AWARD TA)
	{
		bw.Write(TA.m_ulTitleID);
		bw.Write(TA.m_lPeriod);
		if (version >= 234)
		{
			bw.Write(TA.m_ulServerLimit);
		}
	}
}
