namespace ACE.GFX;

public struct GfxColor
{
	public uint Value;

	public byte Byte_0 => (byte)(Value >> 16);

	public byte Byte_1 => (byte)(Value >> 8);

	public byte Byte_2 => (byte)Value;

	public byte Byte_3 => (byte)(Value >> 24);

	public static GfxColor White => new GfxColor(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	public GfxColor(uint value)
	{
		Value = value;
	}

	public GfxColor(byte byte_0, byte byte_1, byte byte_2, byte byte_3)
	{
		Value = (uint)((byte_3 << 24) | (byte_0 << 16) | (byte_1 << 8) | byte_2);
	}

	public static GfxColor Lerp(GfxColor gfxColor_0, GfxColor gfxColor_1, float float_0)
	{
		float num = 1f - float_0;
		return new GfxColor((byte)((float)(int)gfxColor_0.Byte_0 * num + (float)(int)gfxColor_1.Byte_0 * float_0), (byte)((float)(int)gfxColor_0.Byte_1 * num + (float)(int)gfxColor_1.Byte_1 * float_0), (byte)((float)(int)gfxColor_0.Byte_2 * num + (float)(int)gfxColor_1.Byte_2 * float_0), (byte)((float)(int)gfxColor_0.Byte_3 * num + (float)(int)gfxColor_1.Byte_3 * float_0));
	}
}
