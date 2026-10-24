namespace ACE.Dependency.zlibnet;

internal static class BitFlag
{
	internal static bool IsSet(int bits, int flag)
	{
		return (bits & flag) == flag;
	}

	internal static bool IsSet(uint bits, uint flag)
	{
		return (bits & flag) == flag;
	}
}
