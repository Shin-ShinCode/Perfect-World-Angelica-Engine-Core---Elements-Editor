using System;

namespace ACE.RSGlobal;

public class RND
{
	public static Random Randomer = new Random();

	public static double GenerateRnd(double min, double max)
	{
		if (min > max)
		{
			return min;
		}
		return Randomer.NextDouble() * (max - min) + min;
	}

	public static float GenerateRnd(float min, float max)
	{
		double num = min;
		double num2 = max;
		double num3 = ((!(num > num2)) ? (Randomer.NextDouble() * (num2 - num) + num) : num);
		return (float)num3;
	}

	public static int GenerateRnd(int min, int max)
	{
		if (min > max)
		{
			return min;
		}
		max = ((max == int.MaxValue) ? 2147483646 : max);
		return Randomer.Next(min, max + 1);
	}
}
