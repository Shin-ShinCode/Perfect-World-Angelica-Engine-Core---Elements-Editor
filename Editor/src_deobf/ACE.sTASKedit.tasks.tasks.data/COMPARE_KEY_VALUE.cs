using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class COMPARE_KEY_VALUE
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	public int nLeftType
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

	public int lLeftNum
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

	public int nCompOper
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

	public int nRightType
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

	public int lRightNum
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

	internal static void Read(int version, BinaryReader br, COMPARE_KEY_VALUE COMPARE_KEY_VALUE)
	{
		COMPARE_KEY_VALUE.nLeftType = br.ReadInt32();
		COMPARE_KEY_VALUE.lLeftNum = br.ReadInt32();
		COMPARE_KEY_VALUE.nCompOper = br.ReadInt32();
		COMPARE_KEY_VALUE.nRightType = br.ReadInt32();
		COMPARE_KEY_VALUE.lRightNum = br.ReadInt32();
	}

	internal static void Write(int version, BinaryWriter bw, COMPARE_KEY_VALUE COMPARE_KEY_VALUE)
	{
		bw.Write(COMPARE_KEY_VALUE.nLeftType);
		bw.Write(COMPARE_KEY_VALUE.lLeftNum);
		bw.Write(COMPARE_KEY_VALUE.nCompOper);
		bw.Write(COMPARE_KEY_VALUE.nRightType);
		bw.Write(COMPARE_KEY_VALUE.lRightNum);
	}
}
