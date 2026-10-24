using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ACE.Elements.eList;
using ACE.RSGlobal;

namespace ACE.Classes;

public class PROB_SUITE_EXTENDED
{
	public eList elList;

	public int[] fields;

	public List<PROB_VALUES> ValuesList;

	public int field_count;

	public List<PROB_FIELDS> FieldList;

	public int[] AvailableLists;

	public bool IsFixedSize;

	public bool IsItemPresent;

	public bool AreProbsNotConcurents;

	public float[] coefficients;

	public int FieldCount
	{
		get
		{
			int count = FieldList.Count;
			GC.KeepAlive(this);
			return count;
		}
	}

	public int ProbCount
	{
		get
		{
			int count = ValuesList.Count;
			GC.KeepAlive(this);
			return count;
		}
	}

	public PROB_SUITE_EXTENDED(eList elList)
	{
		this.elList = elList;
		ValuesList = new List<PROB_VALUES>();
		coefficients = new float[0];
		FieldList = new List<PROB_FIELDS>();
	}

	public PROB_VALUES GetValues(ITEMPOS ItemPos, int FieldsIndex)
	{
		PROB_FIELDS pROB_FIELDS = FieldList[FieldsIndex];
		int int_ = ItemPos.int_1;
		float valueFloat = elList.GetValueFloat(int_, pROB_FIELDS.prob_f);
		PROB_VALUES pROB_VALUES = new PROB_VALUES(valueFloat);
		int id_f = pROB_FIELDS.id_f;
		if (id_f != 0)
		{
			int int_2 = ItemPos.int_1;
			eList eList2 = elList;
			pROB_VALUES.id = eList2.GetValueIFast(int_2, id_f);
		}
		int val1_f = pROB_FIELDS.val1_f;
		if (val1_f != 0)
		{
			pROB_VALUES.val1 = elList.GetValue(ItemPos.int_1, val1_f);
		}
		int val2_f = pROB_FIELDS.val2_f;
		if (val2_f != 0)
		{
			pROB_VALUES.val2 = elList.GetValue(ItemPos.int_1, val2_f);
		}
		GC.KeepAlive(this);
		return pROB_VALUES;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TryAddValues(ITEMPOS ItemPos, int FieldsIndex)
	{
		_ = FieldList[FieldsIndex];
		PROB_VALUES values = GetValues(ItemPos, FieldsIndex);
		if (!IsFixedSize && values.prob == 0f && !values.IsSomeValuesPresent())
		{
			return false;
		}
		ValuesList.Add(values);
		GC.KeepAlive(this);
		return true;
	}

	public PROB_VALUES AddValues(int int_0, string new_val)
	{
		PROB_FIELDS pROB_FIELDS = FieldList[ValuesList.Count];
		PROB_VALUES pROB_VALUES = new PROB_VALUES(0f);
		if (IsItemPresent)
		{
			pROB_VALUES.id = global::ACE.RSGlobal.RSGlobal.UIntParseFast(new_val);
			if (elList.IsCountField(pROB_FIELDS.val1_f))
			{
				pROB_VALUES.val1 = Class16.smethod_0(1648934925);
			}
			else if (elList.IsCountField(pROB_FIELDS.val2_f))
			{
				pROB_VALUES.val2 = Class16.smethod_0(1648934925);
			}
		}
		else
		{
			pROB_VALUES.val1 = new_val;
			if (elList.IsCountField(pROB_FIELDS.val2_f))
			{
				pROB_VALUES.val2 = Class16.smethod_0(1648934925);
			}
		}
		if (ValuesList.Count == 0)
		{
			pROB_VALUES.prob = 1f;
		}
		ValuesList.Add(pROB_VALUES);
		GC.KeepAlive(this);
		return pROB_VALUES;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool IsProbsSumCorrect(float* result)
	{
		if (ProbCount == 0)
		{
			return true;
		}
		float num = 0f;
		List<PROB_VALUES>.Enumerator enumerator = ValuesList.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				num = (float)((double)enumerator.Current.prob + (double)num);
			}
			while (enumerator.MoveNext());
		}
		*result = num;
		bool result2 = Math.Round(num, 6) == 1.0;
		GC.KeepAlive(this);
		return result2;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool IsProbsSumCorrect()
	{
		float num = default(float);
		return IsProbsSumCorrect(&num);
	}
}
