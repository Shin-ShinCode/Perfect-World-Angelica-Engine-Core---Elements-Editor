using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
internal static class Class5
{
	internal static T smethod_0<T>(List<T> list_0)
	{
		if (list_0 == null)
		{
			throw new ArgumentNullException();
		}
		if (list_0.Count > 0)
		{
			return list_0[0];
		}
		return default(T);
	}

	internal static T smethod_1<T>(T[] gparam_0)
	{
		if (gparam_0 == null)
		{
			throw new ArgumentNullException();
		}
		if (gparam_0.Length != 0)
		{
			return gparam_0[0];
		}
		return default(T);
	}

	internal static bool smethod_2(byte[] byte_0, byte[] byte_1)
	{
		if (byte_0 != null && byte_1 != null)
		{
			if (byte_0 == byte_1)
			{
				return true;
			}
			if (byte_0.Length != byte_1.Length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < byte_0.Length)
				{
					if (byte_0[num] != byte_1[num])
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		throw new ArgumentNullException();
	}
}
