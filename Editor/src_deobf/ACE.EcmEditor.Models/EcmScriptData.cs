using System;
using System.Collections.Generic;
using System.Linq;

namespace ACE.EcmEditor.Models;

public class EcmScriptData
{
	[Serializable]
	private sealed class Class117
	{
		public static readonly Class117 class117_0 = new Class117();

		public static Func<char, bool> func_0;

		public static Func<char, bool> func_1;

		internal bool method_0(char char_0)
		{
			return char.IsDigit(char_0);
		}

		internal bool method_1(char char_0)
		{
			return char.IsDigit(char_0);
		}
	}

	private List<string> list_0;

	private List<string> list_1;

	private List<int> list_2;

	private List<int> list_3;

	private List<int> list_4;

	public EcmScriptData()
	{
		list_0 = new List<string>();
		list_1 = new List<string>();
		list_2 = new List<int>();
		list_3 = new List<int>();
		list_4 = new List<int>();
	}

	public EcmScriptData(string[] buffer)
	{
		list_0 = buffer.ToList();
		list_2 = new List<int>();
		list_3 = new List<int>();
		list_1 = new List<string>();
		list_4 = new List<int>();
	}

	public List<string> GetBuffer()
	{
		return list_0;
	}

	public List<int> GetArrIdScript()
	{
		return list_4;
	}

	public void GetIndexAndCount()
	{
		int num = 0;
		list_4.Clear();
		list_2.Clear();
		list_3.Clear();
		foreach (string item in list_0)
		{
			if (item.IndexOf(Class16.smethod_0(1648994819)) != -1 && int.TryParse(new string(item.Where(Class117.class117_0.method_0).ToArray()), out var result))
			{
				list_2.Add(num);
				list_3.Add(result);
				if (int.TryParse(new string(list_0[num - 1].Where(Class117.class117_0.method_1).ToArray()), out var result2))
				{
					list_4.Add(result2);
				}
			}
			num++;
		}
	}

	public string GetDecodeData(int id)
	{
		if (id >= 0 && id < list_3.Count)
		{
			string text = string.Empty;
			for (int i = 0; i < list_3[id]; i++)
			{
				text += list_0[list_2[id] + 1 + i];
			}
			return EcmBase64Helper.Decode(text);
		}
		return string.Empty;
	}

	public void GetEncodeData(string data)
	{
		data += Class16.smethod_0(1648938185);
		list_1.Clear();
		string text = EcmBase64Helper.Encode(data);
		string source = text;
		string item;
		while ((item = new string(source.Take(1500).ToArray())).Any())
		{
			list_1.Add(item);
			source = new string(source.Skip(1500).ToArray());
		}
	}

	public void ReplaceEncodeData(int id)
	{
		if (id >= 0 && id < list_3.Count)
		{
			if (list_3[id] != list_1.Count)
			{
				list_0[list_2[id]] = Class16.smethod_0(1648994845) + list_1.Count;
			}
			for (int i = 0; i < list_3[id]; i++)
			{
				list_0.RemoveAt(list_2[id] + 1);
			}
			list_1.Reverse();
			for (int j = 0; j < list_1.Count; j++)
			{
				list_0.Insert(list_2[id] + 1, list_1[j]);
			}
		}
	}

	public static string GetNameID(int id)
	{
		return id switch
		{
			0 => Class16.smethod_0(1648994857), 
			1 => Class16.smethod_0(1648994872), 
			2 => Class16.smethod_0(1648994893), 
			3 => Class16.smethod_0(1648994896), 
			4 => Class16.smethod_0(1648994918), 
			5 => Class16.smethod_0(1648994928), 
			6 => Class16.smethod_0(1648994946), 
			7 => Class16.smethod_0(1648994981), 
			_ => id.ToString(), 
		};
	}
}
