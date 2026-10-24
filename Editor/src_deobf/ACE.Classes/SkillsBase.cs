using System;
using System.Collections.Generic;
using ACE.RSGlobal;

namespace ACE.Classes;

public class SkillsBase
{
	public string Name;

	public Dictionary<int, SkillInfo> Skills;

	public SkillInfo[] SkillArray;

	public SkillsBase(ref string FileContent, int min_id)
	{
		Skills = new Dictionary<int, SkillInfo>(3500);
		if (string.IsNullOrWhiteSpace(FileContent))
		{
			GC.KeepAlive(this);
			return;
		}
		char[] anyOf = new char[2] { '\n', '\r' };
		int length = FileContent.Length;
		SkillInfo skillInfo = null;
		int num = 0;
		if (0 < length)
		{
			do
			{
				char c = FileContent[num];
				int num2 = c;
				if (num2 == 35 || num2 == 47)
				{
					num = FileContent.IndexOfAny(anyOf, num);
				}
				else if ((uint)(ushort)(c + 65488) <= 9u)
				{
					int num3 = num;
					int num4 = FileContent.IndexOf('"', num);
					if (num4 == -1)
					{
						num4 = FileContent.Length;
					}
					bool flag = false;
					num = num4 - 1;
					if (num > num3)
					{
						do
						{
							char c2 = FileContent[num];
							if (c2 == ' ' || c2 == '\t')
							{
								num--;
								continue;
							}
							flag = c2 == '0';
							break;
						}
						while (num > num3);
					}
					int num5 = global::ACE.RSGlobal.RSGlobal.UIntParseFast(FileContent.Substring(num3, num - num3 + 1));
					int num6 = num4;
					char c3;
					do
					{
						num6 = FileContent.IndexOf('"', num6 + 1);
						if (num6 > -1)
						{
							if (num6 + 1 >= length)
							{
								break;
							}
							c3 = FileContent[num6 + 1];
							continue;
						}
						num6 = length;
						break;
					}
					while (c3 != '\r' && c3 != '\n');
					string text = FileContent.Substring(num4 + 1, num6 - num4 - 1);
					if (num5 >= min_id)
					{
						num5 /= 10;
						if (flag)
						{
							skillInfo = new SkillInfo(num5, text);
							if (!Skills.ContainsKey(num5))
							{
								Skills.Add(num5, skillInfo);
							}
						}
						else if (skillInfo != null && skillInfo.id == num5)
						{
							ref string desciption = ref skillInfo.Desciption;
							if (string.IsNullOrEmpty(desciption))
							{
								desciption = text;
							}
							else
							{
								string text2 = desciption;
								desciption = string.Concat(text2, Class16.smethod_0(1648941987) + text);
							}
							if (string.IsNullOrWhiteSpace(skillInfo.Name))
							{
								skillInfo.Name = text;
							}
						}
						else if (!Skills.ContainsKey(num5))
						{
							skillInfo = new SkillInfo(num5, text);
							Skills.Add(num5, skillInfo);
						}
					}
					num = num6;
				}
				num++;
			}
			while (num < length);
		}
		GC.KeepAlive(this);
	}

	public SkillsBase()
	{
		Skills = new Dictionary<int, SkillInfo>();
	}

	public string GetDescription(int id)
	{
		SkillInfo skillInfo = null;
		Dictionary<int, SkillInfo> skills = Skills;
		if (skills == null)
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648901829));
			GC.KeepAlive(this);
			return text;
		}
		if (id == 0)
		{
			GC.KeepAlive(this);
			return Class16.smethod_0(1648924410);
		}
		skillInfo = null;
		if (skills.TryGetValue(id, out skillInfo))
		{
			GC.KeepAlive(this);
			return skillInfo.Desciption;
		}
		object[] vars = new object[1] { id };
		string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648901852), vars);
		GC.KeepAlive(this);
		return text2;
	}

	public void Close()
	{
		Dictionary<int, SkillInfo> skills = Skills;
		if (skills != null)
		{
			Dictionary<int, SkillInfo>.ValueCollection.Enumerator enumerator = skills.Values.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					enumerator.Current.Name = null;
				}
				while (enumerator.MoveNext());
			}
			Skills.Clear();
		}
		Array skillArray = SkillArray;
		if (skillArray != null)
		{
			Array.Clear(skillArray, 0, skillArray.Length);
		}
		GC.KeepAlive(this);
	}

	public SkillInfo[] GetSkillArray(string text)
	{
		if (Skills == null)
		{
			return null;
		}
		List<SkillInfo> list = new List<SkillInfo>();
		Dictionary<int, SkillInfo>.Enumerator enumerator = Skills.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				SkillInfo value = ((KeyValuePair<int, SkillInfo>)(object)enumerator.Current).Value;
				if (global::ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(value.Name, text) || global::ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(value.Desciption, text))
				{
					list.Add(value);
				}
			}
			while (enumerator.MoveNext());
		}
		SkillInfo[] result = list.ToArray();
		GC.KeepAlive(this);
		return result;
	}

	public SkillInfo[] GetSkillArray()
	{
		Dictionary<int, SkillInfo> skills = Skills;
		if (skills == null)
		{
			return null;
		}
		SkillInfo[] skillArray = SkillArray;
		if (skillArray != null)
		{
			return skillArray;
		}
		SkillInfo[] array = (SkillArray = new SkillInfo[skills.Count]);
		Skills.Values.CopyTo(array, 0);
		GC.KeepAlive(this);
		return SkillArray;
	}

	public string GetName(int id)
	{
		SkillInfo skillInfo = null;
		Dictionary<int, SkillInfo> skills = Skills;
		if (skills == null)
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648901829));
			GC.KeepAlive(this);
			return text;
		}
		if (id == 0)
		{
			GC.KeepAlive(this);
			return Class16.smethod_0(1648924410);
		}
		skillInfo = null;
		if (skills.TryGetValue(id, out skillInfo))
		{
			GC.KeepAlive(this);
			return skillInfo.Name;
		}
		object[] vars = new object[1] { id };
		string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648901852), vars);
		GC.KeepAlive(this);
		return text2;
	}
}
