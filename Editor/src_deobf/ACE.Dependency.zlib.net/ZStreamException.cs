using System.IO;

namespace ACE.Dependency.zlib.net;

public class ZStreamException : IOException
{
	public ZStreamException()
	{
	}

	public ZStreamException(string string_0)
		: base(string_0)
	{
	}
}
