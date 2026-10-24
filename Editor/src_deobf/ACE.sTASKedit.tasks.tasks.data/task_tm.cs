using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class task_tm
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	public int year
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

	public int month
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

	public int day
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

	public int hour
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

	public int min
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

	public int wday
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, task_tm TM)
	{
		TM.year = br.ReadInt32();
		TM.month = br.ReadInt32();
		TM.day = br.ReadInt32();
		TM.hour = br.ReadInt32();
		TM.min = br.ReadInt32();
		TM.wday = br.ReadInt32();
	}

	internal static void Write(int version, BinaryWriter bw, task_tm TM)
	{
		bw.Write(TM.year);
		bw.Write(TM.month);
		bw.Write(TM.day);
		bw.Write(TM.hour);
		bw.Write(TM.min);
		bw.Write(TM.wday);
	}
}
