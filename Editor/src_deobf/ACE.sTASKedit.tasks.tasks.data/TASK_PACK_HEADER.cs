using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class TASK_PACK_HEADER
{
	private int int_0;

	private int int_1;

	private int int_2;

	public int magic
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

	public int version
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

	public int item_count
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

	public TASK_PACK_HEADER()
	{
	}

	public TASK_PACK_HEADER(BinaryReader BinaryStream)
	{
		method_0(BinaryStream);
	}

	private void method_0(BinaryReader binaryReader_0)
	{
		magic = binaryReader_0.ReadInt32();
		version = binaryReader_0.ReadInt32();
		item_count = binaryReader_0.ReadInt32();
	}
}
