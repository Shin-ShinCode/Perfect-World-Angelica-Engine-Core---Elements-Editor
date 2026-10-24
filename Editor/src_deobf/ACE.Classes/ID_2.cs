using System;
using System.Runtime.InteropServices;

namespace ACE.Classes;

public struct ID_2
{
	public int id1;

	public int id2;

	public int item_count;

	public void Init()
	{
		id1 = -1;
		id2 = -1;
		item_count = -1;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool CheckItemCount(uint test_count)
	{
		if (test_count > 70000)
		{
			return false;
		}
		if (Math.Abs(item_count - (int)test_count) < 10)
		{
			return true;
		}
		int num = item_count;
		if (num != -1 && num != (int)test_count)
		{
			double num2 = num;
			int num3 = ((test_count > (uint)(int)(num2 / 1.5) && test_count < (uint)(100 - (int)(num2 * -1.5))) ? 1 : 0);
			return (byte)num3 != 0;
		}
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IdExists()
	{
		int num = ((id1 > -1 && id2 > -1) ? 1 : 0);
		return (byte)num != 0;
	}
}
