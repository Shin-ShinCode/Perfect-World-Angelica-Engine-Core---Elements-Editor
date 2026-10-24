using System;
using System.Text;

namespace ACE.EcmEditor.Models;

public static class EcmBase64Helper
{
	private static readonly Encoding encoding_0;

	static EcmBase64Helper()
	{
		encoding_0 = Encoding.GetEncoding(936);
	}

	public static string Encode(string data)
	{
		if (string.IsNullOrEmpty(data))
		{
			return string.Empty;
		}
		byte[] bytes = encoding_0.GetBytes(data);
		return Convert.ToBase64String(bytes);
	}

	public static string Decode(string data)
	{
		if (string.IsNullOrEmpty(data))
		{
			return string.Empty;
		}
		try
		{
			byte[] bytes = Convert.FromBase64String(data);
			return encoding_0.GetString(bytes);
		}
		catch (FormatException)
		{
			return string.Empty;
		}
	}
}
