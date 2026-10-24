using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ACE.Classes.ACE;
using ACE.RSGlobal;

namespace ACE.Classes;

public class ELEMENTS_REFERENCES
{
	private sealed class Class61
	{
		public static float smethod_0(REFERENCE_ENTRY reference_ENTRY_0)
		{
			return (float)reference_ENTRY_0.extra_value1;
		}
	}

	private static class Class62
	{
		public static Func<REFERENCE_ENTRY, float> func_0;
	}

	public static CommonStorage CStorage;

	public Dictionary<int, ELEMENTS_IDS_REFERENCES> ReferencesSpecial;

	public ELEMENTS_IDS_REFERENCES ReferencesMatters;

	public Dictionary<ReferenceType, ELEMENTS_IDS_REFERENCES> ReferencesExtra;

	public ELEMENTS_REFERENCES()
	{
		ReferencesSpecial = new Dictionary<int, ELEMENTS_IDS_REFERENCES>();
		ReferencesExtra = new Dictionary<ReferenceType, ELEMENTS_IDS_REFERENCES>();
	}

	public static void SortReferences(ref List<ELEMENTS_REFERENCES_SUITE> refs)
	{
		List<ELEMENTS_REFERENCES_SUITE> list = refs;
		if (list == null)
		{
			return;
		}
		List<ELEMENTS_REFERENCES_SUITE>.Enumerator enumerator = list.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			return;
		}
		do
		{
			ELEMENTS_REFERENCES_SUITE current = enumerator.Current;
			if (current.Count > 0 && current.refs[0].extra_value1 != null && current.refs[0].extra_value1.GetType() == typeof(float))
			{
				float num = (float)current.refs[0].extra_value1;
				if (num <= 1f)
				{
					List<REFERENCE_ENTRY> refs2 = current.refs;
					current.refs = new List<REFERENCE_ENTRY>(refs2.OrderByDescending(Class61.smethod_0));
				}
			}
		}
		while (enumerator.MoveNext());
	}

	public void InitElementsRefs(int ListCount)
	{
		ReferencesSpecial = new Dictionary<int, ELEMENTS_IDS_REFERENCES>(ListCount);
	}

	public int GetCount(ReferenceType RefType, int item_id)
	{
		ELEMENTS_IDS_REFERENCES value = null;
		if (ReferencesExtra.TryGetValue(RefType, out value))
		{
			int count = value.GetCount(item_id);
			GC.KeepAlive(this);
			return count;
		}
		GC.KeepAlive(this);
		return 0;
	}

	public static int GetCount(List<ELEMENTS_REFERENCES_SUITE> ReferencesList)
	{
		if (ReferencesList != null && ReferencesList.Count != 0)
		{
			int num = 0;
			List<ELEMENTS_REFERENCES_SUITE>.Enumerator enumerator = ReferencesList.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					num = enumerator.Current.Count + num;
				}
				while (enumerator.MoveNext());
			}
			return num;
		}
		return 0;
	}

	public int GetCount(int int_0, ItemType item_type, int item_id)
	{
		int num = 0;
		ELEMENTS_IDS_REFERENCES value = null;
		if (ReferencesSpecial.TryGetValue(int_0, out value))
		{
			num = value.GetCount(item_id);
			ELEMENTS_IDS_REFERENCES referencesMatters = ReferencesMatters;
			if (referencesMatters != null && item_type == ItemType.Matter)
			{
				num = referencesMatters.GetCount(item_id) + num;
			}
			ReferenceType[] itemRefSections = global::ACE.RSGlobal.RSGlobal.GetItemRefSections(item_type);
			if (itemRefSections != null)
			{
				int num2 = 0;
				if (0 < (nint)itemRefSections.LongLength)
				{
					do
					{
						ReferenceType refType = itemRefSections[num2];
						num = GetCount(refType, item_id) + num;
						num2++;
					}
					while (num2 < (nint)itemRefSections.LongLength);
				}
			}
		}
		return num;
	}

	public int GetCount(int int_0, ItemType item_type, List<int> IDs)
	{
		if (IDs != null && IDs.Count != 0)
		{
			int num = 0;
			List<int>.Enumerator enumerator = IDs.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					int current = enumerator.Current;
					num = GetCount(int_0, item_type, current) + num;
				}
				while (enumerator.MoveNext());
			}
			return num;
		}
		GC.KeepAlive(this);
		return 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool GetReferences(int int_0, ItemType item_type, int item_id, ref List<ELEMENTS_REFERENCES_SUITE> dest)
	{
		ELEMENTS_IDS_REFERENCES value = null;
		if (ReferencesSpecial.TryGetValue(int_0, out value))
		{
			ELEMENTS_IDS_REFERENCES eLEMENTS_IDS_REFERENCES = value;
			if (value != null)
			{
				if (dest != null)
				{
					List<ELEMENTS_REFERENCES_SUITE> references = eLEMENTS_IDS_REFERENCES.GetReferences(item_id);
					if (references != null)
					{
						dest.AddRange(references);
					}
				}
				else
				{
					dest = eLEMENTS_IDS_REFERENCES.GetReferences(item_id);
				}
				GC.KeepAlive(this);
			}
		}
		if (item_type == ItemType.Matter)
		{
			ELEMENTS_IDS_REFERENCES referencesMatters = ReferencesMatters;
			if (referencesMatters != null)
			{
				if (dest != null)
				{
					List<ELEMENTS_REFERENCES_SUITE> references2 = referencesMatters.GetReferences(item_id);
					if (references2 != null)
					{
						dest.AddRange(references2);
					}
				}
				else
				{
					dest = referencesMatters.GetReferences(item_id);
				}
				GC.KeepAlive(this);
			}
		}
		ReferenceType[] itemRefSections = global::ACE.RSGlobal.RSGlobal.GetItemRefSections(item_type);
		if (itemRefSections != null)
		{
			int num = 0;
			if (0 < (nint)itemRefSections.LongLength)
			{
				do
				{
					method_1(itemRefSections[num], item_id, ref dest);
					num++;
				}
				while (num < (nint)itemRefSections.LongLength);
			}
		}
		return dest != null;
	}

	public List<ELEMENTS_REFERENCES_SUITE> GetReferences(int int_0, ItemType item_type, int item_id)
	{
		List<ELEMENTS_REFERENCES_SUITE> dest = null;
		GetReferences(int_0, item_type, item_id, ref dest);
		return dest;
	}

	public int GetReferences(int int_0, ItemType item_type, List<int> IDs, ref Dictionary<int, List<ELEMENTS_REFERENCES_SUITE>> dest)
	{
		List<ELEMENTS_REFERENCES_SUITE> list = null;
		List<ELEMENTS_REFERENCES_SUITE> dest2 = null;
		List<int>.Enumerator enumerator = IDs.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				int current = enumerator.Current;
				GetReferences(int_0, item_type, current, ref dest2);
			}
			while (enumerator.MoveNext());
		}
		int num = 0;
		if (dest2 != null)
		{
			if (dest == null)
			{
				dest = new Dictionary<int, List<ELEMENTS_REFERENCES_SUITE>>();
			}
			List<ELEMENTS_REFERENCES_SUITE>.Enumerator enumerator2 = dest2.GetEnumerator();
			if (enumerator2.MoveNext())
			{
				do
				{
					ELEMENTS_REFERENCES_SUITE current2 = enumerator2.Current;
					int typeHash = current2.RefType.GetTypeHash();
					list = null;
					bool flag = dest.TryGetValue(typeHash, out list);
					if (list == null)
					{
						list = new List<ELEMENTS_REFERENCES_SUITE>();
					}
					if (CommonStorage.AParams.ViewOnlyUniqueReferences)
					{
						HashSet<int> hashSet = new HashSet<int>();
						int num2 = current2.refs.Count - 1;
						if (num2 >= 0)
						{
							do
							{
								REFERENCE_ENTRY rEFERENCE_ENTRY = current2.refs[num2];
								if (hashSet.Contains(rEFERENCE_ENTRY.id))
								{
									current2.refs.RemoveAt(num2);
								}
								else
								{
									hashSet.Add(rEFERENCE_ENTRY.id);
								}
								num2--;
							}
							while (num2 >= 0);
						}
					}
					if (current2.Count > 0)
					{
						list.Add(current2);
						if (!flag)
						{
							dest.Add(typeHash, list);
						}
						num = current2.Count + num;
					}
				}
				while (enumerator2.MoveNext());
			}
			dest2.Clear();
		}
		GC.KeepAlive(this);
		return num;
	}

	public List<ELEMENTS_REFERENCES_SUITE> GetElementsReferences(int int_0, ItemType item_type, int item_id)
	{
		List<ELEMENTS_REFERENCES_SUITE> list = null;
		ELEMENTS_IDS_REFERENCES value = null;
		if (ReferencesSpecial.TryGetValue(int_0, out value))
		{
			list = value.GetReferences(item_id);
		}
		if (item_type == ItemType.Matter)
		{
			ELEMENTS_IDS_REFERENCES referencesMatters = ReferencesMatters;
			if (referencesMatters != null)
			{
				if (list != null)
				{
					List<ELEMENTS_REFERENCES_SUITE> references = referencesMatters.GetReferences(item_id);
					if (references != null)
					{
						list.AddRange(references);
					}
				}
				else
				{
					list = referencesMatters.GetReferences(item_id);
				}
				GC.KeepAlive(this);
			}
		}
		return list;
	}

	public List<ELEMENTS_REFERENCES_SUITE> GetNpcGenReferences(ItemType type, int item_id)
	{
		List<ELEMENTS_REFERENCES_SUITE> list_ = null;
		switch (type)
		{
		default:
			method_1(ReferenceType.NPCGEN_MONSTERS, item_id, ref list_);
			method_1(ReferenceType.NPCGEN_NPCS, item_id, ref list_);
			method_1(ReferenceType.NPCGEN_MINES, item_id, ref list_);
			break;
		case ItemType.PW_MINE_ESSENCE:
			list_ = ReferencesExtra[ReferenceType.NPCGEN_MINES].GetReferences(item_id);
			break;
		case ItemType.PW_NPC_ESSENCE:
			list_ = ReferencesExtra[ReferenceType.NPCGEN_NPCS].GetReferences(item_id);
			break;
		case ItemType.PW_MONSTER_ESSENCE:
			list_ = ReferencesExtra[ReferenceType.NPCGEN_MONSTERS].GetReferences(item_id);
			break;
		}
		return list_;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemHasReferences(ReferenceType RefType, int item_id)
	{
		ELEMENTS_IDS_REFERENCES value = null;
		if (ReferencesExtra.TryGetValue(RefType, out value))
		{
			bool result = value.IsItemHasReferences(item_id);
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemHasReferences(int int_0, ItemType item_type, int item_id)
	{
		ELEMENTS_IDS_REFERENCES value = null;
		if (ReferencesSpecial.TryGetValue(int_0, out value) && value.IsItemHasReferences(item_id))
		{
			GC.KeepAlive(this);
			return true;
		}
		if (item_type == ItemType.Matter && ReferencesMatters.IsItemHasReferences(item_id))
		{
			GC.KeepAlive(this);
			return true;
		}
		ReferenceType[] itemRefSections = global::ACE.RSGlobal.RSGlobal.GetItemRefSections(item_type);
		if (itemRefSections != null)
		{
			int num = 0;
			if (0 < (nint)itemRefSections.LongLength)
			{
				do
				{
					ReferenceType refType = itemRefSections[num];
					if (!IsItemHasReferences(refType, item_id))
					{
						num++;
						continue;
					}
					GC.KeepAlive(this);
					return true;
				}
				while (num < (nint)itemRefSections.LongLength);
			}
		}
		return false;
	}

	public ELEMENTS_IDS_REFERENCES NewRefs(ReferenceType RefType)
	{
		if (ReferencesExtra.ContainsKey(RefType))
		{
			ReferencesExtra.Remove(RefType);
		}
		ELEMENTS_IDS_REFERENCES eLEMENTS_IDS_REFERENCES = new ELEMENTS_IDS_REFERENCES(RefType);
		ReferencesExtra.Add(RefType, eLEMENTS_IDS_REFERENCES);
		GC.KeepAlive(this);
		return eLEMENTS_IDS_REFERENCES;
	}

	private void method_0(ELEMENTS_IDS_REFERENCES elements_IDS_REFERENCES_0, int int_0, ref List<ELEMENTS_REFERENCES_SUITE> list_0)
	{
		if (elements_IDS_REFERENCES_0 == null)
		{
			return;
		}
		if (list_0 != null)
		{
			List<ELEMENTS_REFERENCES_SUITE> references = elements_IDS_REFERENCES_0.GetReferences(int_0);
			if (references != null)
			{
				list_0.AddRange(references);
			}
		}
		else
		{
			list_0 = elements_IDS_REFERENCES_0.GetReferences(int_0);
		}
		GC.KeepAlive(this);
	}

	private void method_1(ReferenceType referenceType_0, int int_0, ref List<ELEMENTS_REFERENCES_SUITE> list_0)
	{
		ELEMENTS_IDS_REFERENCES value = null;
		if (!ReferencesExtra.TryGetValue(referenceType_0, out value))
		{
			return;
		}
		ELEMENTS_IDS_REFERENCES eLEMENTS_IDS_REFERENCES = value;
		if (value == null)
		{
			return;
		}
		if (list_0 != null)
		{
			List<ELEMENTS_REFERENCES_SUITE> references = eLEMENTS_IDS_REFERENCES.GetReferences(int_0);
			if (references != null)
			{
				list_0.AddRange(references);
			}
		}
		else
		{
			list_0 = eLEMENTS_IDS_REFERENCES.GetReferences(int_0);
		}
		GC.KeepAlive(this);
	}

	public void ClearElementsRefs()
	{
		Dictionary<int, ELEMENTS_IDS_REFERENCES> referencesSpecial = ReferencesSpecial;
		if (referencesSpecial != null)
		{
			referencesSpecial.Clear();
			ReferencesSpecial = null;
		}
		ELEMENTS_IDS_REFERENCES referencesMatters = ReferencesMatters;
		if (referencesMatters != null)
		{
			referencesMatters.references?.Clear();
			ReferencesMatters = null;
		}
	}
}
