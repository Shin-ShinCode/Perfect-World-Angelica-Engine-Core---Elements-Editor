using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ACE.Classes.ACE;
using ACE.sTASKedit.Classes;

namespace ACE.Classes;

public class ELEMENTS_IDS_REFERENCES
{
	public DATA_FILES_ENUM DataFileType;

	public ReferenceType RefSectionType;

	public Dictionary<int, Dictionary<int, ELEMENTS_REFERENCES_SUITE>> references;

	public Dictionary<int, int> references_count;

	public ELEMENTS_IDS_REFERENCES(ReferenceType RefSectionType)
	{
		this.RefSectionType = RefSectionType;
		DATA_FILES_ENUM dataFileType;
		switch (RefSectionType)
		{
		default:
			dataFileType = DATA_FILES_ENUM.NONE;
			break;
		case ReferenceType.ELEMENTS_LIST:
		case ReferenceType.ELEMENTS_MATTERS:
			dataFileType = DATA_FILES_ENUM.ELEMENTS;
			break;
		case ReferenceType.GSHOP_MATTERS:
		case ReferenceType.GSHOP_NPCS:
			dataFileType = DATA_FILES_ENUM.GSHOP;
			break;
		case ReferenceType.GSHOP1_MATTERS:
		case ReferenceType.GSHOP1_NPCS:
			dataFileType = DATA_FILES_ENUM.GSHOP1;
			break;
		case ReferenceType.GSHOP2_MATTERS:
		case ReferenceType.GSHOP2_NPCS:
			dataFileType = DATA_FILES_ENUM.GSHOP2;
			break;
		case ReferenceType.TASKS_MATTERS:
		case ReferenceType.TASKS_MONSTERS:
		case ReferenceType.TASKS_NPCS:
		case ReferenceType.TASKS_TITLES:
		case ReferenceType.TASKS_HOME_ITEMS:
		case ReferenceType.TASKS_MINES:
			dataFileType = DATA_FILES_ENUM.TASKS;
			break;
		case ReferenceType.NPCGEN_NPCS:
		case ReferenceType.NPCGEN_MONSTERS:
		case ReferenceType.NPCGEN_MINES:
			dataFileType = DATA_FILES_ENUM.NPCGEN;
			break;
		case ReferenceType.EXTRA_DROPS_MONSTERS:
		case ReferenceType.EXTRA_DROPS_MATTERS:
			dataFileType = DATA_FILES_ENUM.EXTRA_DROPS;
			break;
		case ReferenceType.GSHOP3_MATTERS:
		case ReferenceType.GSHOP3_NPCS:
			dataFileType = DATA_FILES_ENUM.GSHOP3;
			break;
		}
		DataFileType = dataFileType;
		references = new Dictionary<int, Dictionary<int, ELEMENTS_REFERENCES_SUITE>>();
		references_count = new Dictionary<int, int>();
	}

	public void AddRef(ReferenceSubType RefSubType, int param1, int param2, object oParent, INDICES ind, object oSpecial, int id, int element_id, object val1, object val2)
	{
		REFERENCE_TYPE_EX refType = new REFERENCE_TYPE_EX
		{
			DataFileType = DataFileType,
			SectionType = RefSectionType,
			SubType = RefSubType,
			param1 = param1,
			param2 = param2
		};
		REFERENCE_ENTRY entry = new REFERENCE_ENTRY(oParent, ind, oSpecial, id, null, val1, val2);
		AddReference(refType, element_id, entry);
	}

	public void AddRef(ReferenceSubType RefSubType, object oParent, INDICES ind, object oSpecial, int id, int element_id, object val1, object val2)
	{
		REFERENCE_TYPE_EX refType = new REFERENCE_TYPE_EX
		{
			DataFileType = DataFileType,
			SectionType = RefSectionType,
			SubType = RefSubType
		};
		REFERENCE_ENTRY entry = new REFERENCE_ENTRY(oParent, ind, oSpecial, id, null, val1, val2);
		AddReference(refType, element_id, entry);
	}

	public void AddRef(ReferenceSubType RefSubType, object oParent, INDICES ind, object oSpecial, int id, int element_id, object val1)
	{
		REFERENCE_TYPE_EX refType = new REFERENCE_TYPE_EX
		{
			DataFileType = DataFileType,
			SectionType = RefSectionType,
			SubType = RefSubType
		};
		REFERENCE_ENTRY entry = new REFERENCE_ENTRY(oParent, ind, oSpecial, id, null, val1, null);
		AddReference(refType, element_id, entry);
	}

	public void AddRef(ReferenceSubType RefSubType, int param1, object oParent, INDICES ind, object oSpecial, int id, int element_id)
	{
		REFERENCE_TYPE_EX refType = new REFERENCE_TYPE_EX
		{
			DataFileType = DataFileType,
			SectionType = RefSectionType,
			SubType = RefSubType,
			param1 = param1,
			param2 = 0
		};
		REFERENCE_ENTRY entry = new REFERENCE_ENTRY(oParent, ind, oSpecial, id, null, null, null);
		AddReference(refType, element_id, entry);
	}

	public void AddRef(ReferenceSubType RefSubType, object oParent, INDICES ind, object oSpecial, int id, int element_id)
	{
		REFERENCE_TYPE_EX refType = new REFERENCE_TYPE_EX
		{
			DataFileType = DataFileType,
			SectionType = RefSectionType,
			SubType = RefSubType
		};
		REFERENCE_ENTRY entry = new REFERENCE_ENTRY(oParent, ind, oSpecial, id, null, null, null);
		AddReference(refType, element_id, entry);
	}

	public void AddRef(ReferenceSubType RefSubType, int param1, int param2, object oParent, INDICES ind, object oSpecial, int id, string Name, int element_id, object val1, object val2)
	{
		REFERENCE_TYPE_EX refType = new REFERENCE_TYPE_EX
		{
			DataFileType = DataFileType,
			SectionType = RefSectionType,
			SubType = RefSubType,
			param1 = param1,
			param2 = param2
		};
		REFERENCE_ENTRY entry = new REFERENCE_ENTRY(oParent, ind, oSpecial, id, Name, val1, val2);
		AddReference(refType, element_id, entry);
	}

	public void AddRef(ReferenceSubType RefSubType, object oParent, INDICES ind, object oSpecial, int id, string Name, int element_id, object val1, object val2)
	{
		REFERENCE_TYPE_EX refType = new REFERENCE_TYPE_EX
		{
			DataFileType = DataFileType,
			SectionType = RefSectionType,
			SubType = RefSubType
		};
		REFERENCE_ENTRY entry = new REFERENCE_ENTRY(oParent, ind, oSpecial, id, Name, val1, val2);
		AddReference(refType, element_id, entry);
	}

	public void AddRef(ReferenceSubType RefSubType, object oParent, INDICES ind, object oSpecial, int id, string Name, int element_id, object val1)
	{
		REFERENCE_TYPE_EX refType = new REFERENCE_TYPE_EX
		{
			DataFileType = DataFileType,
			SectionType = RefSectionType,
			SubType = RefSubType
		};
		REFERENCE_ENTRY entry = new REFERENCE_ENTRY(oParent, ind, oSpecial, id, Name, val1, null);
		AddReference(refType, element_id, entry);
	}

	public void AddRef(ReferenceSubType RefSubType, object oParent, INDICES ind, object oSpecial, int id, string Name, int element_id)
	{
		REFERENCE_TYPE_EX refType = new REFERENCE_TYPE_EX
		{
			DataFileType = DataFileType,
			SectionType = RefSectionType,
			SubType = RefSubType
		};
		REFERENCE_ENTRY entry = new REFERENCE_ENTRY(oParent, ind, oSpecial, id, Name, null, null);
		AddReference(refType, element_id, entry);
	}

	public void AddReference(REFERENCE_TYPE_EX RefType, int element_id, REFERENCE_ENTRY entry)
	{
		ELEMENTS_REFERENCES_SUITE eLEMENTS_REFERENCES_SUITE = null;
		if (element_id > 0)
		{
			DATA_FILES_ENUM dataFileType = RefType.DataFileType;
			bool flag2;
			bool flag = (flag2 = dataFileType == DATA_FILES_ENUM.TASKS);
			int key = ((flag2 || dataFileType == DATA_FILES_ENUM.GSHOP || dataFileType == DATA_FILES_ENUM.GSHOP1 || dataFileType == DATA_FILES_ENUM.GSHOP2 || dataFileType == DATA_FILES_ENUM.GSHOP3) ? ((int)RefType.SubType) : RefType.param1);
			Dictionary<int, ELEMENTS_REFERENCES_SUITE> value = null;
			bool flag3;
			if (!(flag3 = references.TryGetValue(element_id, out value)))
			{
				value = new Dictionary<int, ELEMENTS_REFERENCES_SUITE>();
			}
			eLEMENTS_REFERENCES_SUITE = null;
			int num = ((flag3 && value.TryGetValue(key, out eLEMENTS_REFERENCES_SUITE)) ? 1 : 0);
			byte b = (byte)num;
			bool flag4 = b != 0;
			if (b == 0)
			{
				eLEMENTS_REFERENCES_SUITE = new ELEMENTS_REFERENCES_SUITE(RefType, element_id);
			}
			eLEMENTS_REFERENCES_SUITE.AddReference(entry);
			if (flag)
			{
				TASKS_PROPS.AddTaskItem(RefSectionType, RefType.SubType, element_id, entry);
			}
			if (!flag4)
			{
				value[key] = eLEMENTS_REFERENCES_SUITE;
			}
			if (!flag3)
			{
				references[element_id] = value;
			}
			if (!references_count.TryGetValue(element_id, out var value2))
			{
				references_count[element_id] = 1;
			}
			else
			{
				references_count[element_id] = value2 + 1;
			}
			GC.KeepAlive(this);
		}
	}

	public int GetCount(int item_id)
	{
		int value = 0;
		references_count.TryGetValue(item_id, out value);
		GC.KeepAlive(this);
		return value;
	}

	public List<ELEMENTS_REFERENCES_SUITE> GetReferences(int item_id)
	{
		List<ELEMENTS_REFERENCES_SUITE> list = null;
		Dictionary<int, ELEMENTS_REFERENCES_SUITE> value = null;
		if (references.TryGetValue(item_id, out value))
		{
			list = new List<ELEMENTS_REFERENCES_SUITE>(value.Count);
			list.AddRange(value.Values);
		}
		GC.KeepAlive(this);
		return list;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemHasReferences(int item_id)
	{
		bool result = references.ContainsKey(item_id);
		GC.KeepAlive(this);
		return result;
	}
}
