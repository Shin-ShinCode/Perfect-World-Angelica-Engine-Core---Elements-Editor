using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ACE.Classes;

public class PROB_VALUES
{
	public int id;

	public float prob;

	public string val1;

	public string val2;

	public static Func<PROB_VALUES, float> ProbSelectorDelegate = ProbSelectorFunc;

	public PROB_VALUES(int id, float prob)
	{
		if (prob > 1f)
		{
			prob = 1f;
		}
		else if (prob < 0f)
		{
			prob = 0f;
		}
		this.id = id;
		this.prob = prob;
	}

	public PROB_VALUES(float prob)
		: this(0, prob)
	{
	}

	public PROB_VALUES()
	{
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsSomeValuesPresent()
	{
		int num = ((id != 0 || (!string.IsNullOrWhiteSpace(val1) && val1 != Class16.smethod_0(1648924112)) || (!string.IsNullOrWhiteSpace(val2) && val2 != Class16.smethod_0(1648924112))) ? 1 : 0);
		GC.KeepAlive(this);
		return (byte)num != 0;
	}

	public static float ProbSelectorFunc(PROB_VALUES val)
	{
		return val.prob;
	}

	public static List<PROB_VALUES> SortDesceding(List<PROB_VALUES> values)
	{
		return new List<PROB_VALUES>(values).OrderByDescending(ProbSelectorDelegate).ToList();
	}

	public static int GetMaxProbIndex(List<PROB_VALUES> values)
	{
		float num = 0f;
		int result = 0;
		int count = values.Count;
		int num2 = 0;
		if (0 < count)
		{
			do
			{
				if ((double)values[num2].prob > (double)num)
				{
					num = values[num2].prob;
					result = num2;
				}
				num2++;
			}
			while (num2 < count);
		}
		return result;
	}
}
