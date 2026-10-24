using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class window
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private short[] short_0 = new short[0];

	private int int_4;

	private option[] option_0 = new option[0];

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

	public int id
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

	public int id_parent
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

	public int talk_text_len
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

	public short[] talk_text
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

	public int num_option
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

	public option[] options
	{
		[CompilerGenerated]
		get
		{
			return option_0;
		}
		[CompilerGenerated]
		set
		{
			option_0 = value;
		}
	}

	public string talktext
	{
		get
		{
			return tasksConvert.decrypt(crypt_key, talk_text);
		}
		set
		{
			value = value.TrimEnd(default(char));
			talk_text = tasksConvert.encrypt(crypt_key, value, value.Length, appendZero: true);
			talk_text_len = talk_text.Length;
		}
	}

	internal static void Read(int version, BinaryReader br, window window)
	{
		if (window == null || br == null)
		{
			return;
		}
		if (br.BaseStream.Length - br.BaseStream.Position < 12L)
		{
			window.id = 0;
			window.id_parent = 0;
			window.talk_text_len = 0;
			window.talk_text = new short[0];
			window.num_option = 0;
			window.options = new option[0];
			return;
		}
		window.id = br.ReadInt32();
		window.id_parent = br.ReadInt32();
		window.talk_text_len = br.ReadInt32();
		if (window.talk_text_len < 0 || window.talk_text_len > 32768)
		{
			window.talk_text_len = 0;
		}
		int num = window.talk_text_len * 2;
		if (num > br.BaseStream.Length - br.BaseStream.Position)
		{
			window.talk_text_len = 0;
		}
		window.talk_text = GlobalFunctions.ReadNameChars(window.talk_text_len, br);
		if (br.BaseStream.Length - br.BaseStream.Position < 4L)
		{
			window.num_option = 0;
			window.options = new option[0];
			return;
		}
		window.num_option = br.ReadInt32();
		if (window.num_option >= 0 && window.num_option <= 2048)
		{
			window.options = new option[window.num_option];
			int num2 = 0;
			while (true)
			{
				if (num2 < window.num_option)
				{
					if (br.BaseStream.Length - br.BaseStream.Position < 136L)
					{
						break;
					}
					window.options[num2] = new option();
					window.options[num2].crypt_key = window.crypt_key;
					option.Read(version, br, window.options[num2]);
					num2++;
					continue;
				}
				return;
			}
			window.num_option = num2;
			option[] array = window.options;
			Array.Resize(ref array, num2);
			window.options = array;
		}
		else
		{
			window.num_option = 0;
			window.options = new option[0];
		}
	}

	internal static void Write(int version, BinaryWriter bw, window window)
	{
		bw.Write(window.id);
		bw.Write(window.id_parent);
		bw.Write(window.talk_text_len);
		GlobalFunctions.WriteNameChars(bw, window.talk_text);
		bw.Write(window.num_option);
		for (int i = 0; i < window.num_option; i++)
		{
			option.Write(version, bw, window.options[i]);
		}
	}
}
