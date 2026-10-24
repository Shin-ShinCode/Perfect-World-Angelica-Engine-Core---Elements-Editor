using System;
using System.Collections.Generic;
using System.Linq;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.sTASKedit.Classes;

public class TASKS_DECODED_VALUES
{
	[Serializable]
	private sealed class Class404
	{
		public static readonly Class404 class404_0 = new Class404();

		public static Func<decimal, decimal> func_0;

		public static Func<decimal, decimal> func_1;

		internal decimal method_0(decimal decimal_0)
		{
			return decimal_0;
		}

		internal decimal method_1(decimal decimal_0)
		{
			return decimal_0;
		}
	}

	public static CommonStorage CStorage;

	public static IDictionary<string, VALUES_ARRAY_PAIR> ValuesDictionary;

	public static void Init()
	{
		ValuesDictionary = new Dictionary<string, VALUES_ARRAY_PAIR>();
		decimal[] array = new decimal[17]
		{
			default(decimal),
			0m,
			0m,
			0m,
			0m,
			0m,
			0m,
			0m,
			0m,
			0m,
			0m,
			0m,
			0m,
			0m,
			0m,
			0m,
			0m
		};
		decimal num = 1m;
		array[1] = num;
		decimal num2 = 2m;
		array[2] = num2;
		decimal num3 = 3m;
		array[3] = num3;
		decimal num4 = 4m;
		array[4] = num4;
		decimal num5 = 5m;
		array[5] = num5;
		decimal num6 = 6m;
		array[6] = num6;
		decimal num7 = 7m;
		array[7] = num7;
		decimal num8 = 8m;
		array[8] = num8;
		decimal num9 = 20m;
		array[9] = num9;
		decimal num10 = 30m;
		array[10] = num10;
		decimal num11 = 21m;
		array[11] = num11;
		decimal num12 = 31m;
		array[12] = num12;
		decimal num13 = 22m;
		array[13] = num13;
		decimal num14 = 32m;
		array[14] = num14;
		decimal num15 = 40m;
		array[15] = num15;
		decimal num16 = 41m;
		array[16] = num16;
		AddValues(Class16.smethod_0(1649269109), 742, array);
		AddValues(Class16.smethod_0(1649269121), 743);
	}

	public static void AddValues(string prop, int str_index, decimal[] realvalues)
	{
		string[] array = smethod_0(str_index, (realvalues != null) ? realvalues.Length : 0);
		decimal[] array2 = ((realvalues == null || realvalues.Length == 0) ? ACE.RSGlobal.RSGlobal.DecimalArray(0, array.Length).Select(Class404.class404_0.method_0).ToArray() : realvalues);
		if (array.Length != array2.Length)
		{
			Array.Resize(ref array, array2.Length);
			for (int i = 0; i < array.Length; i++)
			{
				if (string.IsNullOrWhiteSpace(array[i]))
				{
					array[i] = array2[i].ToString();
				}
			}
		}
		VALUES_ARRAY_PAIR value = new VALUES_ARRAY_PAIR(array, array2);
		ValuesDictionary[prop] = value;
	}

	public static void AddValues(string prop, int str_index)
	{
		string[] array = smethod_0(str_index, 0);
		VALUES_ARRAY_PAIR value = new VALUES_ARRAY_PAIR(array, ACE.RSGlobal.RSGlobal.DecimalArray(0, array.Length).Select(Class404.class404_0.method_1).ToArray());
		ValuesDictionary[prop] = value;
	}

	private static string[] smethod_0(int int_0, int int_1)
	{
		string[] array = TextStorage.TEXTS?.GetTextsByPrefix(Class16.smethod_0(1648908609) + int_0);
		if (array != null && array.Length != 0)
		{
			return array;
		}
		int num = Math.Max(int_1, 1);
		string[] array2 = new string[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = int_0 + Class16.smethod_0(1648924402) + i;
		}
		return array2;
	}

	public static string DecodeValue(string prop, int value)
	{
		if (!ValuesDictionary.ContainsKey(prop))
		{
			int num = value;
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908657));
			string text2 = Class16.smethod_0(1648942211);
			return string.Concat(num + text2, text);
		}
		VALUES_ARRAY_PAIR vALUES_ARRAY_PAIR = ValuesDictionary[prop];
		int num2 = 0;
		if (0 < (nint)vALUES_ARRAY_PAIR.realvalues.LongLength)
		{
			do
			{
				decimal num3 = value;
				if (!(vALUES_ARRAY_PAIR.realvalues[num2] == num3))
				{
					num2++;
					continue;
				}
				return vALUES_ARRAY_PAIR.decodedvalues[num2];
			}
			while (num2 < (nint)vALUES_ARRAY_PAIR.realvalues.LongLength);
		}
		decimal num4 = -1m;
		decimal[] realvalues = vALUES_ARRAY_PAIR.realvalues;
		if (realvalues[(nint)realvalues.LongLength - 1] != num4)
		{
			int num5 = value;
			string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908687));
			string text4 = Class16.smethod_0(1648942211);
			return string.Concat(num5 + text4, text3);
		}
		string[] decodedvalues = vALUES_ARRAY_PAIR.decodedvalues;
		return decodedvalues[(nint)decodedvalues.LongLength - 1];
	}
}
