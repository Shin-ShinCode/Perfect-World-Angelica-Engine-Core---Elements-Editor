using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ACE.Classes;

public class FIELD_TYPES_DB
{
	public Dictionary<string, FIELD_TYPE_INFO> Fields;

	public int Count
	{
		get
		{
			int count = Fields.Count;
			GC.KeepAlive(this);
			return count;
		}
	}

	public FIELD_TYPES_DB(Dictionary<string, FIELD_TYPE_INFO> fields)
	{
		Fields = fields;
	}

	public FIELD_TYPES_DB()
	{
		Fields = new Dictionary<string, FIELD_TYPE_INFO>();
	}

	public void Add(string field_name, string field_type, [MarshalAs(UnmanagedType.U1)] bool bRegex, [MarshalAs(UnmanagedType.U1)] bool bUserType)
	{
		if (bRegex)
		{
			field_name = field_name.Replace(Class16.smethod_0(1648938114), Class16.smethod_0(1648902914));
			string text = Class16.smethod_0(1648938114);
			field_name = string.Concat(Class16.smethod_0(1648935659) + field_name, text);
		}
		FIELD_TYPE_INFO value = new FIELD_TYPE_INFO
		{
			Type = field_type,
			bRegex = bRegex,
			bUserType = bUserType
		};
		if (Fields.ContainsKey(field_name))
		{
			Fields[field_name] = value;
		}
		else
		{
			Fields.Add(field_name, value);
		}
		GC.KeepAlive(this);
	}

	public FIELD_TYPES_DB Clone()
	{
		Dictionary<string, FIELD_TYPE_INFO> dictionary = null;
		if (Count == 0)
		{
			return new FIELD_TYPES_DB();
		}
		dictionary = null;
		CopyMembersTo(ref dictionary);
		return new FIELD_TYPES_DB(dictionary);
	}

	public void CopyMembersTo(ref Dictionary<string, FIELD_TYPE_INFO> dest)
	{
		if (Fields.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		Dictionary<string, FIELD_TYPE_INFO> dictionary = dest;
		if (dictionary == null || dictionary.Count == 0)
		{
			dest = new Dictionary<string, FIELD_TYPE_INFO>(Fields.Count);
		}
		Dictionary<string, FIELD_TYPE_INFO>.Enumerator enumerator = Fields.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				ValueType valueType = enumerator.Current;
				if (!dest.ContainsKey(((KeyValuePair<string, FIELD_TYPE_INFO>)(object)valueType).Key))
				{
					FIELD_TYPE_INFO value = ((KeyValuePair<string, FIELD_TYPE_INFO>)(object)valueType).Value.Clone();
					dest.Add(((KeyValuePair<string, FIELD_TYPE_INFO>)(object)valueType).Key, value);
				}
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
	}
}
