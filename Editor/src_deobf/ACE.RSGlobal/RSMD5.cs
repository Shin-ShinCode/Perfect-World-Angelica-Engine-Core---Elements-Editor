using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ACE.RSGlobal;

public class RSMD5
{
	public static MD5 _md5 = MD5.Create();

	public unsafe static string Encode(byte[] data)
	{
		byte[] array = new byte[32];
		fixed (byte* buffer = data)
		{
			fixed (byte* hashResult = array)
			{
				int num = RSGlobal.CryptHashBuffer(2, (sbyte*)buffer, data.Length, (sbyte*)hashResult);
				if (num == 1)
				{
					string empty = string.Empty;
					string oldValue = Class16.smethod_0(1648941518);
					return BitConverter.ToString(array).Replace(oldValue, empty).ToLowerInvariant();
				}
				using MD5 mD = MD5.Create();
				byte[] array2 = mD.ComputeHash(data);
				string empty2 = string.Empty;
				string oldValue2 = Class16.smethod_0(1648941518);
				return BitConverter.ToString(array2).Replace(oldValue2, empty2).ToLowerInvariant();
			}
		}
	}

	public static string Encode(string data)
	{
		return Encode(Encoding.UTF8.GetBytes(data));
	}

	public static byte[] GetBytes(byte[] data)
	{
		return _md5.ComputeHash(data);
	}

	public unsafe static byte[] ComputeFile(string FileName)
	{
		byte[] array = new byte[32];
		fixed (byte* hashResult = array)
		{
			int num = RSGlobal.CryptHashFileW(FileName, (sbyte*)hashResult);
			if (num == 1)
			{
				return array;
			}
			return new byte[0];
		}
	}

	public static string ComputeFileS(string FileName)
	{
		if (File.Exists(FileName))
		{
			byte[] array = ComputeFile(FileName);
			string empty = string.Empty;
			string oldValue = Class16.smethod_0(1648941518);
			return BitConverter.ToString(array).Replace(oldValue, empty).ToLowerInvariant();
		}
		return null;
	}
}
