using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class talk_proc
{
	private int int_0;

	private int int_1;

	private short[] short_0 = new short[64];

	private int int_2;

	private window[] window_0 = new window[0];

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

	public int id_talk
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

	public int num_window
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

	public window[] windows
	{
		[CompilerGenerated]
		get
		{
			return window_0;
		}
		[CompilerGenerated]
		set
		{
			window_0 = value;
		}
	}

	public string DialogText
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

	internal static void Read(int version, BinaryReader br, int Id, talk_proc tp)
	{
		if (tp == null || br == null)
		{
			return;
		}
		tp.crypt_key = Id;
		if (br.BaseStream.Length - br.BaseStream.Position < 136L)
		{
			tp.id_talk = 0;
			tp.text = new short[64];
			tp.num_window = 0;
			tp.windows = new window[0];
			return;
		}
		tp.id_talk = br.ReadInt32();
		tp.text = GlobalFunctions.ReadNameChars(64, br);
		tp.num_window = br.ReadInt32();
		if (tp.num_window >= 0 && tp.num_window <= 2048)
		{
			tp.windows = new window[tp.num_window];
			for (int i = 0; i < tp.num_window; i++)
			{
				tp.windows[i] = new window();
				tp.windows[i].crypt_key = tp.crypt_key;
				window.Read(version, br, tp.windows[i]);
			}
		}
		else
		{
			tp.num_window = 0;
			tp.windows = new window[0];
		}
	}

	internal static void Write(int version, BinaryWriter bw, talk_proc tp)
	{
		bw.Write(tp.id_talk);
		GlobalFunctions.WriteNameChars(bw, tp.text);
		bw.Write(tp.num_window);
		for (int i = 0; i < tp.num_window; i++)
		{
			window.Write(version, bw, tp.windows[i]);
		}
	}
}
