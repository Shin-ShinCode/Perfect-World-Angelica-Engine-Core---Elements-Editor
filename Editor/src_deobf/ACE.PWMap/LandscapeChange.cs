using System;

namespace ACE.PWMap;

public sealed class LandscapeChange : PwMapChangeItem
{
	private readonly int int_0;

	private readonly float[] float_0;

	private readonly float[] float_1;

	private readonly Action<int, float[]> action_0;

	public LandscapeChange(int sectorIndex, float[] oldHeights, float[] newHeights, Action<int, float[]> applyHeights)
		: base(Class16.smethod_0(1649090986))
	{
		int_0 = sectorIndex;
		float_0 = oldHeights;
		float_1 = newHeights;
		action_0 = applyHeights;
	}

	public override void Apply()
	{
		action_0?.Invoke(int_0, float_1);
	}

	public override void Revert()
	{
		action_0?.Invoke(int_0, float_0);
	}
}
