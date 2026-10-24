using System;
using System.Runtime.InteropServices;
using ACE.RSGlobal;

namespace ACE.Classes;

public class ProbabilitiesHelper
{
	public float[] probs;

	public ProbabilitiesHelper(float[] probs)
	{
		this.probs = probs;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool ChangeSmart(ref float[] probs, int changed_index, float new_prob)
	{
		ProbabilitiesHelper probabilitiesHelper = new ProbabilitiesHelper(probs);
		bool result = probabilitiesHelper.RecalculateProbabilities(changed_index, new_prob);
		probs = probabilitiesHelper.probs;
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool RecalculateProbabilities(int changed_index, float new_prob)
	{
		float[] array = probs;
		float num3;
		if (array != null)
		{
			int num = array.Length;
			if (num != 0)
			{
				if (new_prob < 1E-06f)
				{
					new_prob = 0f;
				}
				else if (new_prob > 1f)
				{
					new_prob = 1f;
				}
				float num2 = 0f;
				num3 = 0f;
				int num4 = 0;
				int num5 = num;
				if (0 < num5)
				{
					do
					{
						if (num4 != changed_index)
						{
							float num6 = array[num4];
							num3 = (float)((double)num6 + (double)num3);
							num2 = (float)((double)num6 + (double)num2);
						}
						num4++;
					}
					while (num4 < num5);
				}
				int num7 = (((double)Math.Abs((float)(1.0 - (double)num3)) < 5E-07 && !((double)probs[changed_index] <= 5E-07)) ? 1 : 0);
				if ((byte)num7 == 0)
				{
					if (1.0 - (double)new_prob < 0.0 && num2 > 0f)
					{
						new_prob = (float)((double)probs[changed_index] + (double)num2);
					}
					float num8 = (float)(1.0 - (double)new_prob);
					if (num8 < 0f || (num2 == 0f && 0 >= (nint)probs.LongLength - 1))
					{
						return false;
					}
					probs[changed_index] = new_prob;
					float[] array2 = method_0(num2, num8, changed_index);
					int num9 = 0;
					float[] array3 = probs;
					if (0 < (nint)array3.LongLength)
					{
						do
						{
							if (num9 != changed_index)
							{
								array3[num9] = (float)((double)array2[num9] * (double)num8);
							}
							num9++;
							array3 = probs;
						}
						while (num9 < (nint)array3.LongLength);
					}
					num3 = 0f;
					int num10 = 0;
					float[] array4 = probs;
					int num11 = array4.Length;
					if (0 >= num11)
					{
						goto IL_01b8;
					}
					do
					{
						num3 = (float)((double)array4[num10] + (double)num3);
						num10++;
					}
					while (num10 < num11);
				}
				if (num3 != 1f)
				{
					goto IL_01b8;
				}
				goto IL_0204;
			}
		}
		return false;
		IL_0204:
		return true;
		IL_01b8:
		int maxValueIndex = global::ACE.RSGlobal.RSGlobal.GetMaxValueIndex(probs);
		float[] array5 = probs;
		array5[maxValueIndex] = (float)((double)array5[maxValueIndex] + (1.0 - (double)num3));
		float[] array6 = probs;
		if (array6[maxValueIndex] < 0f)
		{
			array6[maxValueIndex] = 0f;
		}
		goto IL_0204;
	}

	private float[] method_0(float float_0, float float_1, int int_0)
	{
		float[] array = probs;
		int num = array.Length;
		float[] array2 = new float[num];
		if (float_0 > 0f)
		{
			int num2 = 0;
			if (0 < (nint)array2.LongLength)
			{
				do
				{
					if (num2 != int_0)
					{
						float num3 = (float)((double)array[num2] / (double)float_0);
						if (float_1 <= 0f)
						{
							num3 = 0f;
						}
						array2[num2] = num3;
					}
					num2++;
				}
				while (num2 < (nint)array2.LongLength);
			}
		}
		else
		{
			float num4 = (float)(1.0 / (double)(float)num);
			int num5 = 0;
			if (0 < (nint)array2.LongLength)
			{
				do
				{
					array2[num5] = num4;
					num5++;
				}
				while (num5 < (nint)array2.LongLength);
			}
		}
		return array2;
	}
}
