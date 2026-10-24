using System;

namespace ACE.BonFileEditor;

public class Convert
{
	public static decimal ToDecimal(string text)
	{
		try
		{
			return System.Convert.ToDecimal(text);
		}
		catch
		{
			return 0m;
		}
	}

	public static int ToInt32(string text)
	{
		try
		{
			return System.Convert.ToInt32(text);
		}
		catch
		{
			return 0;
		}
	}
}
