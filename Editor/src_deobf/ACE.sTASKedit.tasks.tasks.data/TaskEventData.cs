using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class TaskEventData
{
	private short short_0;

	private int int_0;

	private float float_0 = 1f;

	public short IdSpace
	{
		[CompilerGenerated]
		get
		{
			return short_0;
		}
		[CompilerGenerated]
		set
		{
			short_0 = value;
		}
	}

	public int Id
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

	public float Value
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

	internal static void Read(int version, BinaryReader br, TaskEventData TaskEventData)
	{
		if (version >= 153)
		{
			TaskEventData.IdSpace = br.ReadInt16();
		}
		TaskEventData.Id = br.ReadInt32();
		TaskEventData.Value = br.ReadSingle();
	}

	internal static void Write(int version, BinaryWriter bw, TaskEventData TaskEventData)
	{
		if (version >= 153)
		{
			bw.Write(TaskEventData.IdSpace);
		}
		bw.Write(TaskEventData.Id);
		bw.Write(TaskEventData.Value);
	}
}
