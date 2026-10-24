using System;
using System.Windows.Forms;

namespace ACE.RSGlobal;

public class Keyboard
{
	public static void KeyPress(Keys key, int count)
	{
		if (0 < count)
		{
			int num = count;
			do
			{
				KeyDown((int)key);
				KeyUp((int)key);
				num--;
			}
			while (num != 0);
		}
	}

	public static void KeyDown(int key)
	{
		byte bVk = (byte)key;
		RSGlobal.keybd_event(bVk, 0, 1u, (UIntPtr)0u);
		RSGlobal.keybd_event(bVk, 0, 2u, (UIntPtr)0u);
	}

	public static void KeyUp(int key)
	{
		byte bVk = (byte)key;
		RSGlobal.keybd_event(bVk, 0, 1u, (UIntPtr)0u);
		RSGlobal.keybd_event(bVk, 0, 2u, (UIntPtr)0u);
	}
}
