using System;
using System.Collections.Generic;

namespace ACE.Classes;

public class FIELD_SET
{
	public int NameID;

	public Dictionary<int, int> Fields;

	public bool bNotInterrelated;

	public int Count
	{
		get
		{
			int count = Fields.Count;
			GC.KeepAlive(this);
			return count;
		}
	}

	public FIELD_SET(int NameID, int FieldCount)
	{
		this.NameID = NameID;
		Fields = new Dictionary<int, int>(FieldCount);
	}
}
