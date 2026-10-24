using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class TASK_EXPRESSION
{
	private int int_0;

	private float float_0;

	public int type
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

	public float value
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

	public static TASK_EXPRESSION[] New(int size)
	{
		TASK_EXPRESSION[] array = new TASK_EXPRESSION[size];
		for (int i = 0; i < size; i++)
		{
			array[i] = new TASK_EXPRESSION();
		}
		return array;
	}

	internal static void Read(int version, BinaryReader binaryReader_0, TASK_EXPRESSION TASK_EXPRESSION)
	{
		TASK_EXPRESSION.type = binaryReader_0.ReadInt32();
		TASK_EXPRESSION.value = binaryReader_0.ReadSingle();
	}

	internal static void Write(int version, BinaryWriter bw, TASK_EXPRESSION TASK_EXPRESSION)
	{
		bw.Write(TASK_EXPRESSION.type);
		bw.Write(TASK_EXPRESSION.value);
	}
}
