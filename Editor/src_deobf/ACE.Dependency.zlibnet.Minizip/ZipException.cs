using System;
using System.Runtime.Serialization;

namespace ACE.Dependency.zlibnet.Minizip;

[Serializable]
public class ZipException : ApplicationException
{
	public ZipException()
	{
	}

	public ZipException(string message)
		: base(message)
	{
	}

	public ZipException(string message, int errorCode)
		: base(message + Class16.smethod_0(1648899468) + ZipReturnCode.GetMessage(errorCode) + Class16.smethod_0(1648942897))
	{
	}

	public ZipException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public ZipException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
