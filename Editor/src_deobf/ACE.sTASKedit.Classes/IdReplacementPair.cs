using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.Classes;

public class IdReplacementPair
{
	private int int_0;

	private int int_1;

	public int OldId
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

	public int NewId
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

	public IdReplacementPair(int oldId, int newId)
	{
		OldId = oldId;
		NewId = newId;
	}
}
