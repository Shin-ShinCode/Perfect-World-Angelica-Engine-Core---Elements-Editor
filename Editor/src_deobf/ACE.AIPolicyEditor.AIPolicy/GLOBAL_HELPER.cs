using System;
using System.Collections.Generic;
using System.IO;

namespace ACE.AIPolicyEditor.AIPolicy;

public class GLOBAL_HELPER
{
	public static string FilePath;

	private static List<ModifeData> list_0 = new List<ModifeData>();

	private static object object_0 = new object();

	public static void AddModife(long position, byte[] bytes)
	{
		lock (object_0)
		{
			list_0.Add(new ModifeData
			{
				Address = position,
				Bytes = bytes
			});
		}
	}

	public static void ProcessModife()
	{
		if (string.IsNullOrEmpty(FilePath))
		{
			return;
		}
		FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Write);
		try
		{
			lock (object_0)
			{
				foreach (ModifeData item in list_0)
				{
					fileStream.Position = item.Address;
					fileStream.Write(item.Bytes, 0, item.Bytes.Length);
				}
			}
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}
}
