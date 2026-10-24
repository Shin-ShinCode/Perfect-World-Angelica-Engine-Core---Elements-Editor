using System;
using System.IO;
using ACE.Dependency.Ionic.Zlib;

namespace ACE.EcmEditor.Services;

internal static class EcmZlibHelper
{
	public static byte[] Decompress(byte[] bytes, int size)
	{
		try
		{
			MemoryStream memoryStream = new MemoryStream(bytes);
			try
			{
				MemoryStream memoryStream2 = new MemoryStream();
				try
				{
					ZlibStream zlibStream = new ZlibStream(memoryStream, CompressionMode.Decompress);
					try
					{
						byte[] array = new byte[4096];
						int count;
						while ((count = zlibStream.Read(array, 0, array.Length)) > 0)
						{
							memoryStream2.Write(array, 0, count);
						}
						byte[] array2 = memoryStream2.ToArray();
						if (array2.Length >= size)
						{
							return array2;
						}
						byte[] array3 = new byte[size];
						Array.Copy(array2, array3, array2.Length);
						return array3;
					}
					finally
					{
						((IDisposable)zlibStream).Dispose();
					}
				}
				finally
				{
					((IDisposable)memoryStream2).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		catch
		{
			return new byte[size];
		}
	}
}
