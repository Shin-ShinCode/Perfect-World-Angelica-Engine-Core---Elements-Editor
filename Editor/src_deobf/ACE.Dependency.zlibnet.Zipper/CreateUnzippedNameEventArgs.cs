using System;
using System.Runtime.CompilerServices;

namespace ACE.Dependency.zlibnet.Zipper;

public class CreateUnzippedNameEventArgs : EventArgs
{
	private string string_0;

	private bool bool_0;

	public string UnzippedName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public bool IsDirectory
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
	}

	public CreateUnzippedNameEventArgs(string unzippedName, bool isDirectory)
	{
		UnzippedName = unzippedName;
		method_0(isDirectory);
	}

	private void method_0(bool bool_1)
	{
		bool_0 = bool_1;
	}
}
