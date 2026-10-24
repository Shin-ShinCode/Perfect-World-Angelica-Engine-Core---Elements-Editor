using System;
using System.Collections.Generic;

namespace ACE.Classes;

public class DUBLICATES
{
	public Dictionary<string, List<FIELDPOS>> Entries;

	public DUBLICATES()
	{
		Entries = new Dictionary<string, List<FIELDPOS>>();
	}

	public void AddEntrie(string value, FIELDPOS fieldpos)
	{
		if (!Entries.ContainsKey(value))
		{
			Entries.Add(value, new List<FIELDPOS>(1));
		}
		Entries[value].Add(fieldpos);
		GC.KeepAlive(this);
	}
}
