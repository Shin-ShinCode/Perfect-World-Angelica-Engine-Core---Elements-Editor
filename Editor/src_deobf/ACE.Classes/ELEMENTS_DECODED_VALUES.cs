using System;
using System.Collections.Generic;
using ACE.RSGlobal;

namespace ACE.Classes;

public class ELEMENTS_DECODED_VALUES
{
	private Dictionary<int, VALUES_ARRAY_PAIR> dictionary_0;

	public static CommonStorage CStorage;

	public ELEMENTS_DECODED_VALUES()
	{
		dictionary_0 = new Dictionary<int, VALUES_ARRAY_PAIR>();
	}

	public void AddValues(int ftype, string[] decodedvalues, decimal[] realvalues)
	{
		if (dictionary_0.ContainsKey(ftype))
		{
			GC.KeepAlive(this);
			return;
		}
		VALUES_ARRAY_PAIR value = new VALUES_ARRAY_PAIR(decodedvalues, realvalues);
		dictionary_0.Add(ftype, value);
		GC.KeepAlive(this);
	}

	public void AddValues(int ftype, string[] decodedvalues, params ulong[] realvalues)
	{
		int num = realvalues.Length;
		decimal[] array = new decimal[num];
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				decimal num3 = realvalues[num2];
				array[num2] = num3;
				num2++;
			}
			while (num2 < (nint)realvalues.LongLength);
		}
		AddValues(ftype, decodedvalues, array);
	}

	public void AddValues(int ftype, string[] decodedvalues)
	{
		if (decodedvalues != null && decodedvalues.Length != 0)
		{
			AddValues(ftype, decodedvalues, global::ACE.RSGlobal.RSGlobal.DecimalArray(0, (int)((nint)decodedvalues.LongLength - 1)));
			GC.KeepAlive(this);
		}
		else
		{
			AddValues(ftype, new string[0], new decimal[0]);
			GC.KeepAlive(this);
		}
	}

	public void AddValues(FIELDTYPE ftype, string[] decodedvalues, params ulong[] realvalues)
	{
		AddValues((int)ftype, decodedvalues, realvalues);
	}

	public void AddValues(FIELDTYPE ftype, string[] decodedvalues, decimal[] realvalues)
	{
		AddValues((int)ftype, decodedvalues, realvalues);
	}

	public void AddValues(FIELDTYPE ftype, string[] decodedvalues)
	{
		if (decodedvalues != null && decodedvalues.Length != 0)
		{
			AddValues((int)ftype, decodedvalues, global::ACE.RSGlobal.RSGlobal.DecimalArray(0, (int)((nint)decodedvalues.LongLength - 1)));
			GC.KeepAlive(this);
		}
		else
		{
			AddValues((int)ftype, new string[0], new decimal[0]);
			GC.KeepAlive(this);
		}
	}

	public void AddValues(int str_id)
	{
		if (dictionary_0.ContainsKey(str_id))
		{
			GC.KeepAlive(this);
			return;
		}
		if (CommonStorage.Texts == null)
		{
			GC.KeepAlive(this);
			return;
		}
		string[] textsByPrefix = CommonStorage.Texts.GetTextsByPrefix(Class16.smethod_0(1648908609) + str_id);
		if (textsByPrefix != null && textsByPrefix.Length != 0)
		{
			VALUES_ARRAY_PAIR vALUES_ARRAY_PAIR = new VALUES_ARRAY_PAIR(textsByPrefix.Length);
			int num = 0;
			if (0 < (nint)textsByPrefix.LongLength)
			{
				do
				{
					string text = textsByPrefix[num];
					decimal num2 = num;
					if (text.Contains(Class16.smethod_0(1648908627)))
					{
						string[] array = text.Split('=');
						text = array[0];
						num2 = decimal.Parse(array[1].Trim());
					}
					vALUES_ARRAY_PAIR.decodedvalues[num] = text;
					vALUES_ARRAY_PAIR.realvalues[num] = num2;
					num++;
				}
				while (num < (nint)textsByPrefix.LongLength);
			}
			dictionary_0[str_id] = vALUES_ARRAY_PAIR;
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	public void AddValues(int str_id, VALUES_ARRAY_PAIR arrpair)
	{
		dictionary_0[str_id] = arrpair;
		GC.KeepAlive(this);
	}

	public string DecodeValue(int ftype, decimal value)
	{
		if ((ftype == 48 || ftype == 47) && value == default(decimal))
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908635));
			GC.KeepAlive(this);
			return text;
		}
		if (!dictionary_0.ContainsKey(ftype))
		{
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908657));
			GC.KeepAlive(this);
			return text2;
		}
		VALUES_ARRAY_PAIR vALUES_ARRAY_PAIR = dictionary_0[ftype];
		int num = 0;
		decimal[] realvalues = vALUES_ARRAY_PAIR.realvalues;
		if (0 < (nint)realvalues.LongLength)
		{
			do
			{
				if (!(realvalues[num] == value))
				{
					num++;
					realvalues = vALUES_ARRAY_PAIR.realvalues;
					continue;
				}
				GC.KeepAlive(this);
				return vALUES_ARRAY_PAIR.decodedvalues[num];
			}
			while (num < (nint)realvalues.LongLength);
		}
		decimal num2 = -1m;
		realvalues = vALUES_ARRAY_PAIR.realvalues;
		decimal[] array = realvalues;
		if ((nint)array.LongLength == 0)
		{
			string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908687));
			string result = string.Concat(text3 + Class16.smethod_0(1648908709), value.ToString());
			GC.KeepAlive(this);
			return result;
		}
		if (array[(nint)array.LongLength - 1] != num2)
		{
			string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908687));
			string result2 = string.Concat(text4 + Class16.smethod_0(1648908709), value.ToString());
			GC.KeepAlive(this);
			return result2;
		}
		GC.KeepAlive(this);
		string[] decodedvalues = vALUES_ARRAY_PAIR.decodedvalues;
		if ((nint)decodedvalues.LongLength == 0)
		{
			string text5 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908687));
			string result3 = string.Concat(text5 + Class16.smethod_0(1648908709), value.ToString());
			GC.KeepAlive(this);
			return result3;
		}
		return decodedvalues[(nint)decodedvalues.LongLength - 1];
	}

	public decimal[] GetRealValuesArray(int ftype)
	{
		if (!dictionary_0.ContainsKey(ftype))
		{
			decimal[] result = new decimal[1] { default(decimal) };
			GC.KeepAlive(this);
			return result;
		}
		VALUES_ARRAY_PAIR vALUES_ARRAY_PAIR = dictionary_0[ftype];
		GC.KeepAlive(this);
		return vALUES_ARRAY_PAIR.realvalues;
	}

	public string[] GetDecodedValuesArray(int ftype)
	{
		if (!dictionary_0.ContainsKey(ftype))
		{
			string[] result = new string[1] { Class16.smethod_0(1648908718) };
			GC.KeepAlive(this);
			return result;
		}
		VALUES_ARRAY_PAIR vALUES_ARRAY_PAIR = dictionary_0[ftype];
		GC.KeepAlive(this);
		return vALUES_ARRAY_PAIR.decodedvalues;
	}

	public void Close()
	{
		dictionary_0?.Clear();
		GC.KeepAlive(this);
	}
}
