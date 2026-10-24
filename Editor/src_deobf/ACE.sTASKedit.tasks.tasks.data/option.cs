using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class option
{
	private int int_0;

	private int int_1;

	private short[] short_0 = new short[64];

	private int int_2;

	public int crypt_key
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

	public int param
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

	public short[] text
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

	public int id
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

	public string optiontext
	{
		get
		{
			return tasksConvert.decrypt(crypt_key, text);
		}
		set
		{
			text = tasksConvert.encrypt(crypt_key, value, 64, appendZero: false);
		}
	}

	internal static void Read(int version, BinaryReader br, option option)
	{
		option.param = br.ReadInt32();
		option.text = GlobalFunctions.ReadNameChars(64, br);
		option.id = br.ReadInt32();
	}

	internal static void Write(int version, BinaryWriter bw, option option)
	{
		bw.Write(option.param);
		GlobalFunctions.WriteNameChars(bw, option.text);
		bw.Write(option.id);
	}
}
