using System;
using System.IO;

/// <summary>Checked reads for elements files. Never allocate from an unchecked length.</summary>
namespace ACE.Elements.eList;

internal static class ElementsBinary
{
    private static readonly object[] SmallInts = CreateInts();
    private static readonly object[] SmallUInts = CreateUInts();
    private static readonly object OneFloat = 1f, MinusOneFloat = -1f;

    private static object[] CreateInts()
    {
        var values = new object[32770];
        for (int i = 0; i < values.Length; i++) values[i] = i - 1;
        return values;
    }
    private static object[] CreateUInts()
    {
        var values = new object[257];
        for (uint i = 0; i < values.Length; i++) values[i] = i;
        return values;
    }
    // Only immutable boxed scalars are shared. Editable byte arrays are never interned.
    internal static object Box(int value) => value == 0 ? eList.i0 : value >= -1 && value <= 32768 ? SmallInts[value + 1] : (object)value;
    internal static object Box(uint value) => value <= 256 ? SmallUInts[value] : (object)value;
    internal static object Box(float value)
    {
        // Keep IEEE-754 negative zero; normalizing it would corrupt a lossless round-trip.
        if (value == 0f && float.IsPositiveInfinity(1f / value)) return eList.f0;
        if (value == 1f) return OneFloat;
        if (value == -1f) return MinusOneFloat;
        return value;
    }
    internal static void Require(BinaryReader reader, long length)
    {
        if (length < 0 || length > reader.BaseStream.Length - reader.BaseStream.Position)
            throw new InvalidDataException($"elements 数据长度无效或文件已截断：偏移 {reader.BaseStream.Position}，需要 {length} 字节。");
    }
    internal static byte[] ReadExact(BinaryReader reader, int length)
    {
        Require(reader, length);
        if (length == 0) return Array.Empty<byte>();
        byte[] result = reader.ReadBytes(length);
        if (result.Length != length) throw new EndOfStreamException("elements 数据被截断。");
        return result;
    }
    internal static void Skip(BinaryReader reader, long length)
    {
        Require(reader, length);
        reader.BaseStream.Seek(length, SeekOrigin.Current);
    }
    internal static int Count(BinaryReader reader, int minimumSize)
    {
        if (minimumSize <= 0) throw new ArgumentOutOfRangeException(nameof(minimumSize));
        int count = reader.ReadInt32();
        Require(reader, (long)count * minimumSize);
        if (count < 0) throw new InvalidDataException("elements 记录数量不能为负数。");
        return count;
    }
}
