using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class HOME_ITEM_WANTED
{
	private int int_0;

	private int int_1 = 1;

	public int m_ulHomeItemTid
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

	public int m_ulHomeItemCount
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

	internal static void Read(int version, BinaryReader br, HOME_ITEM_WANTED HIW)
	{
		HIW.m_ulHomeItemTid = br.ReadInt32();
		HIW.m_ulHomeItemCount = br.ReadInt32();
	}

	internal static void Write(int version, BinaryWriter bw, HOME_ITEM_WANTED HIW)
	{
		bw.Write(HIW.m_ulHomeItemTid);
		bw.Write(HIW.m_ulHomeItemCount);
	}
}
