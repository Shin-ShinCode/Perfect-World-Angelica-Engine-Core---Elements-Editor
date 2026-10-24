using System;
using System.IO;

using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.tasks;

internal static class TaskRecordReader
{
	internal static byte[] ReadBytes(BinaryReader reader, int[] offsets, int index)
	{
		if (offsets == null || index < 0 || index >= offsets.Length) throw new ArgumentOutOfRangeException(nameof(index));
        long end = index + 1 < offsets.Length ? offsets[index + 1] : reader.BaseStream.Length;
		long length = end - offsets[index];
		if (offsets[index] < 0 || end > reader.BaseStream.Length || length < 64 || length > 64L * 1024 * 1024)
			throw new InvalidDataException($"任务记录长度异常：索引 {index}，偏移 {offsets[index]}，长度 {length}。已停止读取，原文件未修改。");
		reader.BaseStream.Position = offsets[index];
		byte[] data = reader.ReadBytes((int)length);
		if (data.Length != length) throw new EndOfStreamException($"任务记录 {index} 被截断。");
		return data;
	}

	internal static ATaskTempl Parse(int version, byte[] data)
    {
        if (data == null || data.Length < 64 || data.Length > 64L * 1024 * 1024)
            throw new InvalidDataException("Invalid task record size (limit: 64 MiB).");
        using var stream = new MemoryStream(data, writable: false);
        using var reader = new BinaryReader(stream);
        // Core owns the schema. Do not import V22-only constructors or guess layouts.
        ATaskTempl task = new ATaskTempl(version, reader);
        if (stream.Position != stream.Length)
            throw new InvalidDataException("Task " + task.ID + " consumed " + stream.Position + "/" + stream.Length + " bytes; unsupported layout.");
        return task;
    }
}
