using System;
using System.Collections.Generic;

namespace ACE.Classes;

public class IMPORT_RESULT_LIST
{
	public int int_0;

	public List<int> AddedItems;

	public List<int> ReplacedItems;

	public IMPORT_RESULT_LIST(int int_1)
	{
		int_0 = int_1;
		AddedItems = new List<int>();
		ReplacedItems = new List<int>();
	}

	public int[] GetChangedItems()
	{
		int[] array = new int[ReplacedItems.Count + AddedItems.Count];
		AddedItems.CopyTo(array, 0);
		ReplacedItems.CopyTo(array, AddedItems.Count);
		GC.KeepAlive(this);
		return array;
	}
}
