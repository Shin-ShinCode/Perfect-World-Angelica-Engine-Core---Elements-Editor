using System;
using System.Runtime.Serialization;

namespace ACE.Dependency.zlibnet.zlib;

[Serializable]
public class ZLibException : ApplicationException
{
	public ZLibException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public ZLibException(int errorCode)
		: base(smethod_0(errorCode, null))
	{
	}

	public ZLibException(int errorCode, string lastStreamError)
		: base(smethod_0(errorCode, lastStreamError))
	{
	}

	private static string smethod_0(int int_0, string string_0)
	{
		string text = Class16.smethod_0(1648887968) + int_0 + Class16.smethod_0(1648908709) + ZLibReturnCode.GetMesage(int_0);
		if (string_0 != null && string_0.Length > 0)
		{
			text = text + Class16.smethod_0(1648899468) + string_0 + Class16.smethod_0(1648942897);
		}
		return text;
	}
}
