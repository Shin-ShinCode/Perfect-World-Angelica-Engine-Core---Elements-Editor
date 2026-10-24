using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Elements.eList;
using ACE.RSGlobal;

namespace ACE.Classes;

public class SkillsCollection
{
	public eList[] Lists;

	public SkillsBase CommonSkills;

	public HashSet<int> PotionsSkillsIDs;

	public string Game;

	public Dictionary<int, SkillsBase> FilteredSkills;

	public SkillsCollection(eList[] ref_Lists, string Game, ref string FileContent)
	{
		this.Game = Game;
		Lists = ref_Lists;
		CommonSkills = new SkillsBase(ref FileContent, (Game == Class16.smethod_0(1648901867)) ? 2180 : 10);
		string text = Class16.smethod_0(1648901884);
		string text2 = Class16.smethod_0(1648901903);
		string path = string.Concat(string.Concat(Application.StartupPath + text2, Game), text);
		if (File.Exists(path))
		{
			int[] other = global::ACE.RSGlobal.RSGlobal.StringArray2IntArray(File.ReadAllLines(path));
			(PotionsSkillsIDs = new HashSet<int>()).UnionWith(other);
		}
		FilteredSkills = new Dictionary<int, SkillsBase>();
	}

	public SkillsBase GetSkills(int int_0, List<int> FilterIDs)
	{
		SkillsBase skillsBase = null;
		SkillInfo skillInfo = null;
		SkillInfo skillInfo2 = null;
		if (CommonSkills == null)
		{
			return null;
		}
		if (Lists[int_0] == null)
		{
			return null;
		}
		skillsBase = null;
		if (FilterIDs != null && FilterIDs.Count > 0 && CommonStorage.Params.UseSkillsFilter)
		{
			if (FilteredSkills.TryGetValue(int_0, out skillsBase))
			{
				GC.KeepAlive(this);
				return skillsBase;
			}
			skillsBase = new SkillsBase();
			eList eList2 = Lists[int_0];
			string name = ((!global::ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList2.ListName : eList2.uListName);
			skillsBase.Name = name;
			skillsBase.Skills = new Dictionary<int, SkillInfo>(100);
			List<int>.Enumerator enumerator = FilterIDs.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					int current = enumerator.Current;
					skillInfo = null;
					if (CommonSkills.Skills.TryGetValue(current, out skillInfo))
					{
						skillsBase.Skills.Add(current, skillInfo);
					}
				}
				while (enumerator.MoveNext());
			}
			FilterIDs.Clear();
			if (Game == Class16.smethod_0(1648922898) && Lists[int_0].uListName == Class16.smethod_0(1648901912) && PotionsSkillsIDs != null)
			{
				HashSet<int>.Enumerator enumerator2 = PotionsSkillsIDs.GetEnumerator();
				if (enumerator2.MoveNext())
				{
					do
					{
						int current2 = enumerator2.Current;
						skillInfo2 = null;
						if (!skillsBase.Skills.ContainsKey(current2) && CommonSkills.Skills.TryGetValue(current2, out skillInfo2))
						{
							skillsBase.Skills.Add(current2, skillInfo2);
						}
					}
					while (enumerator2.MoveNext());
				}
			}
			FilteredSkills.Add(int_0, skillsBase);
		}
		else
		{
			skillsBase = CommonSkills;
		}
		return skillsBase;
	}

	public SkillsBase GetSkills(int int_0)
	{
		SkillsBase skillsBase = null;
		if (CommonSkills == null)
		{
			return null;
		}
		if (Lists[int_0] == null)
		{
			return null;
		}
		skillsBase = null;
		if (CommonStorage.Params.UseSkillsFilter)
		{
			FilteredSkills.TryGetValue(int_0, out skillsBase);
		}
		if (skillsBase == null)
		{
			skillsBase = CommonSkills;
		}
		return skillsBase;
	}

	public string GetSkillName(int id)
	{
		return GetSkillName(id, bNormalText: false);
	}

	public string GetSkillName(int id, [MarshalAs(UnmanagedType.U1)] bool bNormalText)
	{
		if (id <= 0)
		{
			return Class16.smethod_0(1648924410);
		}
		string name = CommonSkills.GetName(id);
		name = global::ACE.RSGlobal.RSGlobal.RemoveSpecialTextVars(name);
		if (bNormalText)
		{
			name = global::ACE.RSGlobal.RSGlobal.ToNormalText(name, bOneLine: true);
		}
		GC.KeepAlive(this);
		return name;
	}

	public string GetSkillDesc(int id, [MarshalAs(UnmanagedType.U1)] bool bNormalText)
	{
		if (id <= 0)
		{
			return string.Empty;
		}
		string text = CommonSkills.GetDescription(id);
		if (!string.IsNullOrWhiteSpace(text))
		{
			text = global::ACE.RSGlobal.RSGlobal.RemoveSpecialTextVars(text);
			if (bNormalText)
			{
				text = global::ACE.RSGlobal.RSGlobal.ToNormalText(text, bOneLine: true);
			}
		}
		GC.KeepAlive(this);
		return text;
	}

	public string GetSkillNameAndDesc(int id)
	{
		if (id <= 0)
		{
			return Class16.smethod_0(1648924410);
		}
		string text = GetSkillName(id, bNormalText: true);
		string skillDesc = GetSkillDesc(id, bNormalText: true);
		if (!string.IsNullOrWhiteSpace(skillDesc))
		{
			string text2 = Class16.smethod_0(1648942897);
			text = string.Concat(text, string.Concat(Class16.smethod_0(1648899468) + skillDesc, text2));
		}
		GC.KeepAlive(this);
		return text;
	}

	public void Close()
	{
		Lists = null;
		SkillsBase commonSkills = CommonSkills;
		if (commonSkills != null)
		{
			commonSkills.Close();
			CommonSkills = null;
		}
		Dictionary<int, SkillsBase> filteredSkills = FilteredSkills;
		if (filteredSkills != null)
		{
			Dictionary<int, SkillsBase>.ValueCollection.Enumerator enumerator = filteredSkills.Values.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					enumerator.Current.Close();
				}
				while (enumerator.MoveNext());
			}
			FilteredSkills.Clear();
		}
		GC.KeepAlive(this);
	}
}
