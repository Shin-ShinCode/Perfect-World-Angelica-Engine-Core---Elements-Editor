using System;

namespace ACE.Models.ECM;

internal static class MathHelper
{
	public static int Clamp(int value, int min, int max)
	{
		return Math.Max(min, Math.Min(max, value));
	}

	public static float Clamp(float value, float min, float max)
	{
		return Math.Max(min, Math.Min(max, value));
	}
}
