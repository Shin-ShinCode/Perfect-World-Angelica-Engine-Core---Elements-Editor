using System;

namespace ACE.PWMap;

public sealed class TerrainPaintChange : PwMapChangeItem
{
	private readonly int int_0;

	private readonly byte[] byte_0;

	private readonly byte[] byte_1;

	private readonly Action<int, byte[]> action_0;

	public TerrainPaintChange(int sectorIndex, byte[] oldAlpha, byte[] newAlpha, Action<int, byte[]> applyAlpha)
		: base(Class16.smethod_0(1649203685))
	{
		int_0 = sectorIndex;
		byte_0 = oldAlpha;
		byte_1 = newAlpha;
		action_0 = applyAlpha;
	}

	public override void Apply()
	{
		action_0?.Invoke(int_0, byte_1);
	}

	public override void Revert()
	{
		action_0?.Invoke(int_0, byte_0);
	}
}
