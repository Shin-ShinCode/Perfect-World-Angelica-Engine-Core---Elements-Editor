using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ACE.Classes.ACE;

namespace ACE.Classes;

public class ELEMENTS_REFERENCES_SUITE
{
	public int enumerator_counter;

	public HashSet<int> ReturnedIndices;

	public bool bPriorityOut;

	public int limit;

	public HashSet<int> PriorityIDs;

	public static CommonStorage CStorage;

	public REFERENCE_TYPE_EX RefType;

	public int element_id;

	public List<REFERENCE_ENTRY> refs;

	public int ListIndex;

	public int Count
	{
		get
		{
			int result = 0;
			List<REFERENCE_ENTRY> list = refs;
			if (list != null)
			{
				result = list.Count;
			}
			GC.KeepAlive(this);
			return result;
		}
	}

	public ELEMENTS_REFERENCES_SUITE(REFERENCE_TYPE_EX RefType, int element_id)
	{
		this.element_id = element_id;
		this.RefType = RefType;
		if (RefType.DataFileType == DATA_FILES_ENUM.ELEMENTS)
		{
			ListIndex = RefType.param1;
		}
		refs = new List<REFERENCE_ENTRY>();
	}

	public void InitEnumerator(int result_limit)
	{
		limit = result_limit;
		if (result_limit < 0 || limit > refs.Count)
		{
			limit = refs.Count;
		}
		enumerator_counter = 0;
		ReturnedIndices = null;
		PriorityIDs = null;
		int num = limit;
		if (num > 1 && result_limit != -2 && RefType.DataFileType == DATA_FILES_ENUM.ELEMENTS && num < 10000)
		{
			if ((PriorityIDs = PRIORITY_ITEMS.GetPriorities(ListIndex)).Count > 0)
			{
				bPriorityOut = false;
				ReturnedIndices = new HashSet<int>();
			}
			else
			{
				PriorityIDs = null;
			}
		}
	}

	public REFERENCE_ENTRY GetNext()
	{
		int num = enumerator_counter;
		if (num >= limit)
		{
			PriorityIDs?.Clear();
			ReturnedIndices?.Clear();
			GC.KeepAlive(this);
			return null;
		}
		REFERENCE_ENTRY rEFERENCE_ENTRY = null;
		if (PriorityIDs != null)
		{
			if (!bPriorityOut)
			{
				rEFERENCE_ENTRY = method_0();
				if (rEFERENCE_ENTRY == null)
				{
					bPriorityOut = true;
				}
			}
			if (bPriorityOut)
			{
				if (ReturnedIndices.Count > 0)
				{
					int num2 = 0;
					if (0 < refs.Count)
					{
						do
						{
							REFERENCE_ENTRY rEFERENCE_ENTRY2 = refs[num2];
							if (ReturnedIndices.Contains(num2))
							{
								num2++;
								continue;
							}
							ReturnedIndices.Add(num2);
							rEFERENCE_ENTRY = rEFERENCE_ENTRY2;
							break;
						}
						while (num2 < refs.Count);
					}
				}
				else
				{
					rEFERENCE_ENTRY = refs[enumerator_counter];
				}
			}
		}
		else
		{
			rEFERENCE_ENTRY = refs[num];
		}
		enumerator_counter++;
		return rEFERENCE_ENTRY;
	}

	private REFERENCE_ENTRY method_0()
	{
		HashSet<int>.Enumerator enumerator = PriorityIDs.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				int current = enumerator.Current;
				int num = 0;
				if (0 >= refs.Count)
				{
					continue;
				}
				do
				{
					REFERENCE_ENTRY rEFERENCE_ENTRY = refs[num];
					if (rEFERENCE_ENTRY.id != current || ReturnedIndices.Contains(num))
					{
						num++;
						continue;
					}
					ReturnedIndices.Add(num);
					GC.KeepAlive(this);
					return rEFERENCE_ENTRY;
				}
				while (num < refs.Count);
			}
			while (enumerator.MoveNext());
		}
		return null;
	}

	public void AddReference(REFERENCE_ENTRY entry)
	{
		refs.Add(entry);
		GC.KeepAlive(this);
	}

	public static string GetRefCaption(DATA_FILES_ENUM DataFileType, ReferenceSubType RefSubType, [MarshalAs(UnmanagedType.U1)] bool IsTaskHint)
	{
		switch (DataFileType)
		{
		case DATA_FILES_ENUM.GSHOP:
			return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(698, (int)(RefSubType - 3)), null);
		case DATA_FILES_ENUM.GSHOP1:
			return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(772, (int)(RefSubType - 8)), null);
		case DATA_FILES_ENUM.GSHOP2:
			return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(773, (int)(RefSubType - 13)), null);
		case DATA_FILES_ENUM.TASKS:
		{
			int num = (IsTaskHint ? 10 : 0);
			if (RefSubType >= ReferenceSubType.TASKS_AWARD_FAIL_CAND_ITEMS)
			{
				string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908737));
				return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(num + 729, (int)(RefSubType - 53)), null) + text;
			}
			if (RefSubType >= ReferenceSubType.TASKS_AWARD_SUCCESS_CAND_ITEMS)
			{
				return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(num + 729, (int)(RefSubType - 33)), null);
			}
			return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(num + 728, (int)(RefSubType - 18)), null);
		}
		case DATA_FILES_ENUM.EXTRA_DROPS:
			return TextStorage.TEXTS.GetText(Class16.smethod_0(1648908760));
		default:
			return string.Empty;
		case DATA_FILES_ENUM.GSHOP3:
			return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(773, (int)(RefSubType - 13)), null);
		}
	}

	public string GetRefCaption()
	{
		string refCaption = GetRefCaption(RefType.DataFileType, RefType.SubType, IsTaskHint: false);
		GC.KeepAlive(this);
		return refCaption;
	}
}
