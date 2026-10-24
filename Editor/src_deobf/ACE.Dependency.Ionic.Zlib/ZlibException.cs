using System;
using System.Runtime.InteropServices;

namespace ACE.Dependency.Ionic.Zlib;

[Guid("ebc25cf6-9120-4283-b972-0e5520d0000E")]
public class ZlibException : Exception
{
	public ZlibException()
	{
	}

	public ZlibException(string string_0)
		: base(string_0)
	{
	}
}
