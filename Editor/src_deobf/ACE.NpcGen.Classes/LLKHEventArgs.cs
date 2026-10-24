using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ACE.NpcGen.Classes;

public class LLKHEventArgs
{
	private Keys keys_0;

	private bool bool_0;

	private uint uint_0;

	private uint uint_1;

	private bool bool_1;

	public bool Hooked
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public bool IsPressed => bool_0;

	public Keys Keys => keys_0;

	public uint ScanCode => uint_0;

	public uint Time => uint_1;

	public LLKHEventArgs(Keys keys, bool pressed, uint time, uint scanCode)
	{
		keys_0 = keys;
		bool_0 = pressed;
		uint_1 = time;
		uint_0 = scanCode;
	}
}
