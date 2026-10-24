using System;
using System.IO;
using System.Threading;
using ACE.Classes;

namespace ACE.NpcGen;

internal static class NpcGenFileHelper
{
	internal static void ReplaceFileWithRetry(string tempFilePath, string destinationPath, int attempts = 5, int delayMs = 200)
	{
		Exception innerException = null;
		for (int i = 0; i < attempts; i++)
		{
			try
			{
				if (File.Exists(destinationPath))
				{
					string text = destinationPath + Class16.smethod_0(1648898363);
					File.Replace(tempFilePath, destinationPath, text, ignoreMetadataErrors: true);
					try
					{
						if (File.Exists(text))
						{
							File.Delete(text);
						}
						return;
					}
					catch (Exception ex)
					{
						SentryHelper.CaptureException(ex, Class16.smethod_0(1649096727));
						return;
					}
				}
				File.Move(tempFilePath, destinationPath);
				return;
			}
			catch (IOException ex2)
			{
				innerException = ex2;
				Thread.Sleep(delayMs);
			}
			catch (UnauthorizedAccessException ex3)
			{
				innerException = ex3;
				Thread.Sleep(delayMs);
			}
		}
		try
		{
			if (File.Exists(tempFilePath))
			{
				File.Delete(tempFilePath);
			}
		}
		catch
		{
		}
		throw new IOException(Class16.smethod_0(1649096776) + destinationPath + Class16.smethod_0(1648928156), innerException);
	}
}
