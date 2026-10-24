using System;
using System.Collections.Generic;

namespace ACE.AIPolicyEditor;

public static class Utils
{
	public static List<uint> GetMask(uint value)
	{
		List<uint> list = new List<uint>();
		for (uint num = value; num != 0; num >>= 1)
		{
			list.Add(num & 1);
		}
		return list;
	}

	public static void MemoryCleaner()
	{
		GC.Collect();
		GC.WaitForPendingFinalizers();
	}
}
