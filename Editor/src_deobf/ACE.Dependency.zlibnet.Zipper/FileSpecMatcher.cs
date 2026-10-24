using System;
using System.Collections.Generic;
using System.IO;

namespace ACE.Dependency.zlibnet.Zipper;

internal class FileSpecMatcher
{
	private sealed class Class97
	{
		public string string_0;

		public string string_1;

		public Class97(string string_2, bool bool_0)
		{
			string_1 = System.IO.Path.GetDirectoryName(string_2);
			if (string_1 == null)
			{
				throw new ArgumentException(Class16.smethod_0(1648889187));
			}
			string_0 = System.IO.Path.GetFileName(string_2);
			if (string_0 == null)
			{
				throw new ArgumentException(Class16.smethod_0(1648889187));
			}
			string_1 = string_1.SetEndDirSep().TrimStartDirSep();
			if (bool_0 && string_0.Length > 0)
			{
				string_1 += Class16.smethod_0(1648941528);
			}
		}
	}

	private List<Class97> list_0 = new List<Class97>();

	public FileSpecMatcher(List<string> specs, bool recurseFiles)
	{
		foreach (string spec in specs)
		{
			list_0.Add(new Class97(spec, recurseFiles));
		}
	}

	public bool MatchSpecs(string entryName, bool entryIsDir)
	{
		if (entryIsDir)
		{
			entryName = entryName.SetEndDirSep();
		}
		string directoryName = System.IO.Path.GetDirectoryName(entryName);
		string fileName = System.IO.Path.GetFileName(entryName);
		directoryName = directoryName.SetEndDirSep().TrimStartDirSep();
		foreach (Class97 item in list_0)
		{
			bool flag = fileName.WildcardMatch(item.string_0, ignoreCase: true);
			if (directoryName.WildcardMatch(item.string_1, ignoreCase: true) && flag)
			{
				return true;
			}
		}
		return false;
	}
}
