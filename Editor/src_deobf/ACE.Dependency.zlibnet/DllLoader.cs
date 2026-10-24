using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ACE.Dependency.zlibnet;

public static class DllLoader
{
	[DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern IntPtr LoadLibrary(string string_0);

	public static void Load()
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string text = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Class16.smethod_0(1648886029));
		try
		{
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
		}
		catch
		{
			if (!Directory.Exists(text))
			{
				throw;
			}
		}
		string dllName = ZLibDll.GetDllName();
		string text2 = System.IO.Path.Combine(text, dllName);
		if (!File.Exists(text2))
		{
			string tempFileName = System.IO.Path.GetTempFileName();
			using (Stream stream = executingAssembly.GetManifestResourceStream(Class16.smethod_0(1648886055) + dllName))
			{
				using Stream destination = File.Create(tempFileName);
				stream.CopyTo(destination);
			}
			try
			{
				File.Move(tempFileName, text2);
			}
			catch
			{
				try
				{
					File.Delete(tempFileName);
				}
				catch
				{
				}
				if (!File.Exists(text2))
				{
					throw;
				}
			}
		}
		IntPtr intPtr = LoadLibrary(text2);
		if (intPtr == IntPtr.Zero)
		{
			throw new Exception(Class16.smethod_0(1648886070) + text2);
		}
	}
}
