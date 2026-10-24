using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Models;
using ACE.RSGlobal;

namespace ACE.Addons;

public class AddonsCollection
{
	public AddonsParts Abilities;

	public bool bLoaded;

	public CommonStorage CStorage;

	public DBReaderClass DBReader;

	public ELEMENTS_DECODED_VALUES DecodedValues;

	public HashSet<int> ElementsAddons;

	public List<AddonsParts> EquipAddons;

	public Dictionary<int, List<AddonsParts>> fEquipAddons;

	public List<int> FilteredListsindices;

	public Dictionary<int, List<AddonsParts>> fRefineAddons;

	public Dictionary<int, int> LastAddons;

	public eList[] Lists;

	public AddonsParts OtherAddons;

	public List<AddonsParts> RefineAddons;

	public SkillsCollection Skills;

	private static float[] float_0 = new float[12]
	{
		1f, 2f, 3.044f, 4.294f, 5.72f, 7.544f, 9.94f, 13f, 17.044f, 22.3f,
		29f, 37.5f
	};

	private eList eList_0;

	private ushort ushort_0;

	public AddonsCollection(eList[] Lists, [MarshalAs(UnmanagedType.U1)] bool bEnableFilter, DBReaderClass DBReader, Dictionary<int, int> LastAddons, ELEMENTS_DECODED_VALUES DecodedValues, SkillsCollection Skills)
	{
		CStorage = DBReader.CStorage;
		this.Lists = Lists;
		eList_0 = Lists[0];
		ushort_0 = DBReader.file_version;
		this.DBReader = DBReader;
		this.LastAddons = LastAddons;
		this.DecodedValues = DecodedValues;
		this.Skills = Skills;
		(FilteredListsindices = new List<int>()).Add(0);
		fRefineAddons = new Dictionary<int, List<AddonsParts>>();
		fEquipAddons = new Dictionary<int, List<AddonsParts>>();
		try
		{
			method_3();
			method_1();
			method_0();
			method_2();
			AddonsParts otherAddons = OtherAddons;
			int num = ((otherAddons != null && (nint)otherAddons.IDs.LongLength > 0) ? 1 : 0);
			bLoaded = (byte)num != 0;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648924016));
			DKBox.Show(ex.Message, Class16.smethod_0(1648924056), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		if (RefineAddons != null && RefineAddons.Count >= 4)
		{
			try
			{
				List<AddonsParts> value = new List<AddonsParts>(3)
				{
					RefineAddons[0],
					RefineAddons[1],
					RefineAddons[2]
				};
				fRefineAddons.Add(ListsHelper.GetListIndexByListType(Lists, ItemType.PW_WEAPON_ESSENCE), value);
				List<AddonsParts> value2 = new List<AddonsParts>(1) { RefineAddons[3] };
				fRefineAddons.Add(ListsHelper.GetListIndexByListType(Lists, ItemType.PW_ARMOR_ESSENCE), value2);
				if (RefineAddons.Count >= 7)
				{
					List<AddonsParts> list = new List<AddonsParts>(4)
					{
						RefineAddons[4],
						RefineAddons[5],
						RefineAddons[6]
					};
					if ((uint)ushort_0 > 62u && RefineAddons.Count >= 8)
					{
						list.Add(RefineAddons[7]);
					}
					fRefineAddons.Add(ListsHelper.GetListIndexByListType(Lists, ItemType.PW_DECORATION_ESSENCE), list);
				}
			}
			catch (Exception ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1648924072));
			}
		}
		GC.KeepAlive(this);
	}

	public void CreateAddonsCache(eList SourceList, int firstvalueindex, int lastvalueindex, int step)
	{
		ElementsAddons = new HashSet<int>();
		int num = SourceList.elementValues.Length;
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				int num3 = firstvalueindex;
				if (firstvalueindex <= lastvalueindex)
				{
					do
					{
						uint valueIFast = (uint)SourceList.GetValueIFast(num2, num3);
						if (valueIFast != 0)
						{
							ElementsAddons.Add((int)valueIFast);
						}
						num3 = step + num3;
					}
					while (num3 <= lastvalueindex);
				}
				num2++;
			}
			while (num2 < num);
		}
		GC.KeepAlive(this);
	}

	public string Decode_EquipAddon(string id)
	{
		if (id == Class16.smethod_0(1648924112))
		{
			GC.KeepAlive(this);
			return Class16.smethod_0(1648924410);
		}
		List<AddonsParts> equipAddons = EquipAddons;
		if (equipAddons != null)
		{
			List<AddonsParts>.Enumerator enumerator = equipAddons.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					AddonsParts current = enumerator.Current;
					int num = 0;
					string[] iDs = current.IDs;
					if (0 >= (nint)iDs.LongLength)
					{
						continue;
					}
					do
					{
						if (!(iDs[num] == id))
						{
							num++;
							iDs = current.IDs;
							continue;
						}
						GC.KeepAlive(this);
						return current.values[num];
					}
					while (num < (nint)iDs.LongLength);
				}
				while (enumerator.MoveNext());
			}
		}
		AddonsParts abilities = Abilities;
		if (abilities != null)
		{
			int num2 = 0;
			string[] iDs2 = abilities.IDs;
			if (0 < (nint)iDs2.LongLength)
			{
				do
				{
					if (!(iDs2[num2] == id))
					{
						num2++;
						iDs2 = Abilities.IDs;
						continue;
					}
					return Abilities.values[num2];
				}
				while (num2 < (nint)iDs2.LongLength);
			}
		}
		return FindInOtherAddons(id);
	}

	public string Decode_Refine(string id)
	{
		if (id == Class16.smethod_0(1648924112))
		{
			GC.KeepAlive(this);
			return Class16.smethod_0(1648924120);
		}
		List<AddonsParts> refineAddons = RefineAddons;
		if (refineAddons == null)
		{
			return Class16.smethod_0(1648924131);
		}
		List<AddonsParts>.Enumerator enumerator = refineAddons.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				AddonsParts current = enumerator.Current;
				int num = 0;
				string[] iDs = current.IDs;
				if (0 >= (nint)iDs.LongLength)
				{
					continue;
				}
				do
				{
					if (!(iDs[num] == id))
					{
						num++;
						iDs = current.IDs;
						continue;
					}
					GC.KeepAlive(this);
					return current.values[num];
				}
				while (num < (nint)iDs.LongLength);
			}
			while (enumerator.MoveNext());
		}
		return FindInOtherAddons(id);
	}

	public List<AddonsParts> FilterAddons(List<AddonsParts> Source, int ListIndex, string fieldname1, string fieldname2, int step)
	{
		if (Source == null)
		{
			return new List<AddonsParts>();
		}
		eList eList2 = Lists[ListIndex];
		bool flag = false;
		int num = 0;
		int index = 0;
		int firstvalueindex = eList2.get_fields(fieldname1);
		int lastvalueindex = eList2.get_fields(fieldname2);
		List<AddonsParts> list = new List<AddonsParts>(40);
		List<AddonsParts>.Enumerator enumerator = Source.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				AddonsParts current = enumerator.Current;
				if (current == null)
				{
					break;
				}
				int index2 = current.Index;
				if (index2 == 12 || (uint)(index2 - 15) <= 19u)
				{
					continue;
				}
				int num2 = 0;
				CreateAddonsCache(eList2, firstvalueindex, lastvalueindex, step);
				int num3 = 0;
				string[] iDs = current.IDs;
				if (0 < (nint)iDs.LongLength)
				{
					int num4 = num - 1;
					do
					{
						int item = ACE.RSGlobal.RSGlobal.UIntParseFast(iDs[num3]);
						if (ElementsAddons.Contains(item))
						{
							if (!flag)
							{
								num++;
								num4++;
								index = num4;
								list.Add(new AddonsParts());
								ref string caption = ref list[num4].Caption;
								caption = current.Caption;
								ref bool bFloat = ref list[num4].bFloat;
								bFloat = current.bFloat;
								ref bool bPercent = ref list[num4].bPercent;
								bPercent = current.bPercent;
								flag = true;
							}
							num2++;
							Array.Resize(ref list[index].IDs, num2);
							Array.Resize(ref list[index].values, num2);
							string[] iDs2 = current.IDs;
							list[index].IDs[num2 - 1] = iDs2[num3];
							string[] values = current.values;
							list[index].values[num2 - 1] = values[num3];
							list[index].IdsHashes.Add(item);
						}
						num3++;
						iDs = current.IDs;
					}
					while (num3 < (nint)iDs.LongLength);
				}
				flag = false;
			}
			while (enumerator.MoveNext());
		}
		ElementsAddons.Clear();
		GC.KeepAlive(this);
		return list;
	}

	public List<AddonsParts> FilterAddons(List<AddonsParts> Source, int ListIndex, string fieldname1, string fieldname2)
	{
		return FilterAddons(Source, ListIndex, fieldname1, fieldname2, 1);
	}

	public string FindInOtherAddons(string id)
	{
		AddonsParts otherAddons = OtherAddons;
		if (otherAddons != null)
		{
			int num = 0;
			string[] iDs = otherAddons.IDs;
			if (0 < (nint)iDs.LongLength)
			{
				do
				{
					if (!(iDs[num] == id))
					{
						num++;
						iDs = OtherAddons.IDs;
						continue;
					}
					return OtherAddons.values[num];
				}
				while (num < (nint)iDs.LongLength);
			}
		}
		string result = id + Class16.smethod_0(1648923142);
		GC.KeepAlive(this);
		return result;
	}

	public string GetAddonName(string id)
	{
		List<AddonsParts> equipAddons = EquipAddons;
		if (equipAddons != null)
		{
			List<AddonsParts>.Enumerator enumerator = equipAddons.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					AddonsParts current = enumerator.Current;
					int num = 0;
					string[] iDs = current.IDs;
					if (0 >= (nint)iDs.LongLength)
					{
						continue;
					}
					do
					{
						if (!(iDs[num] == id))
						{
							num++;
							iDs = current.IDs;
							continue;
						}
						GC.KeepAlive(this);
						return current.values[num];
					}
					while (num < (nint)iDs.LongLength);
				}
				while (enumerator.MoveNext());
			}
		}
		List<AddonsParts> refineAddons = RefineAddons;
		if (refineAddons != null)
		{
			List<AddonsParts>.Enumerator enumerator2 = refineAddons.GetEnumerator();
			if (enumerator2.MoveNext())
			{
				do
				{
					AddonsParts current2 = enumerator2.Current;
					int num2 = 0;
					string[] iDs2 = current2.IDs;
					if (0 >= (nint)iDs2.LongLength)
					{
						continue;
					}
					do
					{
						if (!(iDs2[num2] == id))
						{
							num2++;
							iDs2 = current2.IDs;
							continue;
						}
						GC.KeepAlive(this);
						return current2.values[num2];
					}
					while (num2 < (nint)iDs2.LongLength);
				}
				while (enumerator2.MoveNext());
			}
		}
		AddonsParts otherAddons = OtherAddons;
		if (otherAddons != null)
		{
			int num3 = 0;
			string[] iDs3 = otherAddons.IDs;
			if (0 < (nint)iDs3.LongLength)
			{
				do
				{
					if (!(iDs3[num3] == id))
					{
						num3++;
						iDs3 = OtherAddons.IDs;
						continue;
					}
					return OtherAddons.values[num3];
				}
				while (num3 < (nint)iDs3.LongLength);
			}
		}
		AddonsParts abilities = Abilities;
		if (abilities != null)
		{
			int num4 = 0;
			string[] iDs4 = abilities.IDs;
			if (0 < (nint)iDs4.LongLength)
			{
				do
				{
					if (!(iDs4[num4] == id))
					{
						num4++;
						iDs4 = Abilities.IDs;
						continue;
					}
					return Abilities.values[num4];
				}
				while (num4 < (nint)iDs4.LongLength);
			}
		}
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648923167));
		GC.KeepAlive(this);
		return text;
	}

	public string GetAddonNameByID(int id)
	{
		if (DBReader.Game == GAMES.PW && id == 2311)
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648923190));
			GC.KeepAlive(this);
			return text;
		}
		if (Abilities != null)
		{
			int num = id;
			if (Array.IndexOf(Abilities.IDs, num.ToString()) > -1)
			{
				int num2 = eList_0.IDs.IndexOf(id);
				if (num2 > -1)
				{
					int valueIFast = eList_0.GetValueIFast(num2, 3);
					if (Skills != null)
					{
						string text2 = Skills.GetSkillDesc(valueIFast, bNormalText: true);
						if (string.IsNullOrWhiteSpace(text2))
						{
							text2 = Skills.GetSkillName(valueIFast, bNormalText: true);
						}
						GC.KeepAlive(this);
						return text2;
					}
				}
			}
		}
		int num3 = id;
		string addonName = GetAddonName(num3.ToString());
		GC.KeepAlive(this);
		return addonName;
	}

	public string GetAddonTitle(string id)
	{
		List<AddonsParts> equipAddons = EquipAddons;
		if (equipAddons != null)
		{
			List<AddonsParts>.Enumerator enumerator = equipAddons.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					AddonsParts current = enumerator.Current;
					int num = 0;
					string[] iDs = current.IDs;
					if (0 >= (nint)iDs.LongLength)
					{
						continue;
					}
					do
					{
						if (!(iDs[num] == id))
						{
							num++;
							iDs = current.IDs;
							continue;
						}
						GC.KeepAlive(this);
						return current.Caption;
					}
					while (num < (nint)iDs.LongLength);
				}
				while (enumerator.MoveNext());
			}
		}
		List<AddonsParts> refineAddons = RefineAddons;
		if (refineAddons != null)
		{
			List<AddonsParts>.Enumerator enumerator2 = refineAddons.GetEnumerator();
			if (enumerator2.MoveNext())
			{
				do
				{
					AddonsParts current2 = enumerator2.Current;
					int num2 = 0;
					string[] iDs2 = current2.IDs;
					if (0 >= (nint)iDs2.LongLength)
					{
						continue;
					}
					do
					{
						if (!(iDs2[num2] == id))
						{
							num2++;
							iDs2 = current2.IDs;
							continue;
						}
						GC.KeepAlive(this);
						return current2.Caption;
					}
					while (num2 < (nint)iDs2.LongLength);
				}
				while (enumerator2.MoveNext());
			}
		}
		AddonsParts otherAddons = OtherAddons;
		if (otherAddons != null)
		{
			int num3 = 0;
			string[] iDs3 = otherAddons.IDs;
			if (0 < (nint)iDs3.LongLength)
			{
				do
				{
					if (!(iDs3[num3] == id))
					{
						num3++;
						iDs3 = OtherAddons.IDs;
						continue;
					}
					return OtherAddons.captions[num3];
				}
				while (num3 < (nint)iDs3.LongLength);
			}
		}
		AddonsParts abilities = Abilities;
		if (abilities != null)
		{
			int num4 = Array.IndexOf(abilities.IDs, id);
			if (num4 > -1)
			{
				GC.KeepAlive(this);
				return Abilities.values[num4];
			}
		}
		return Class16.smethod_0(1648923213);
	}

	public string GetAddonTitleByID(int id)
	{
		if (id == 2311)
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648923190));
			GC.KeepAlive(this);
			return text;
		}
		if (Abilities?.IDs != null)
		{
			int num = id;
			if (Array.IndexOf(Abilities.IDs, num.ToString()) > -1 && eList_0?.IDs != null)
			{
				int num2 = eList_0.IDs.IndexOf(id);
				if (num2 > -1 && Skills != null)
				{
					int valueIFast = eList_0.GetValueIFast(num2, 3);
					string skillName = Skills.GetSkillName(valueIFast, bNormalText: false);
					if (!string.IsNullOrWhiteSpace(skillName))
					{
						GC.KeepAlive(this);
						return skillName;
					}
				}
			}
		}
		int num3 = id;
		string addonTitle = GetAddonTitle(num3.ToString());
		GC.KeepAlive(this);
		return addonTitle;
	}

	public int GetRefineBonus(int refine_level, int basenum)
	{
		int result = (int)Math.Floor((double)float_0[refine_level - 1] * (double)(float)basenum);
		GC.KeepAlive(this);
		return result;
	}

	public int id2index(string id)
	{
		if (id == Class16.smethod_0(1648924112))
		{
			GC.KeepAlive(this);
			return -1;
		}
		object obj = Convert.ToInt32(id);
		int num = 0;
		object[][] elementValues = eList_0.elementValues;
		int num2 = elementValues.Length;
		if (0 < num2)
		{
			do
			{
				if ((int)obj != (int)elementValues[num][0])
				{
					num++;
					continue;
				}
				GC.KeepAlive(this);
				return num;
			}
			while (num < num2);
		}
		return -1;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsAbility(string id)
	{
		AddonsParts abilities = Abilities;
		if (abilities != null)
		{
			int num = 0;
			string[] iDs = abilities.IDs;
			if (0 < (nint)iDs.LongLength)
			{
				do
				{
					if (!(iDs[num] == id))
					{
						num++;
						iDs = Abilities.IDs;
						continue;
					}
					return true;
				}
				while (num < (nint)iDs.LongLength);
			}
		}
		GC.KeepAlive(this);
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsAbility(int id)
	{
		int num = id;
		bool result = IsAbility(num.ToString());
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsPercentAddon(string id)
	{
		List<AddonsParts> equipAddons = EquipAddons;
		if (equipAddons != null)
		{
			List<AddonsParts>.Enumerator enumerator = equipAddons.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					AddonsParts current = enumerator.Current;
					int num = 0;
					string[] iDs = current.IDs;
					if (0 >= (nint)iDs.LongLength)
					{
						continue;
					}
					do
					{
						if (!(iDs[num] == id))
						{
							num++;
							iDs = current.IDs;
							continue;
						}
						GC.KeepAlive(this);
						return current.bPercent;
					}
					while (num < (nint)iDs.LongLength);
				}
				while (enumerator.MoveNext());
			}
		}
		return false;
	}

	public unsafe void RefineArmor(string id, int refine_level, int* hp)
	{
		if (RefineAddons == null)
		{
			return;
		}
		if (!(id == Class16.smethod_0(1648924112)) && (uint)(refine_level - 1) <= 11u)
		{
			List<AddonsParts>.Enumerator enumerator = RefineAddons.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return;
			}
			do
			{
				AddonsParts current = enumerator.Current;
				int num = 0;
				string[] iDs = current.IDs;
				if (0 >= (nint)iDs.LongLength)
				{
					continue;
				}
				do
				{
					if (!(iDs[num] == id))
					{
						num++;
						iDs = current.IDs;
						continue;
					}
					int refineBonus = GetRefineBonus(refine_level, current.realvalues[num]);
					*hp += refineBonus;
					GC.KeepAlive(this);
					return;
				}
				while (num < (nint)iDs.LongLength);
			}
			while (enumerator.MoveNext());
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	public unsafe void RefineOrnament(string id, int refine_level, ITEMDATA* data)
	{
		if (RefineAddons == null)
		{
			return;
		}
		if (!(id == Class16.smethod_0(1648924112)) && (uint)(refine_level - 1) <= 11u)
		{
			int num = 0;
			if (0 < RefineAddons.Count)
			{
				do
				{
					AddonsParts addonsParts = RefineAddons[num];
					int num2 = 0;
					string[] iDs = addonsParts.IDs;
					if (0 < (nint)iDs.LongLength)
					{
						do
						{
							if (!(iDs[num2] == id))
							{
								num2++;
								iDs = addonsParts.IDs;
								continue;
							}
							int refineBonus = GetRefineBonus(refine_level, addonsParts.realvalues[num2]);
							int length = addonsParts.Caption.IndexOf(Class16.smethod_0(1648941500)) - 1;
							addonsParts.Caption.Substring(0, length);
							switch (num)
							{
							case 4:
								((int*)data)[18] += refineBonus;
								break;
							case 5:
								((int*)data)[19] += refineBonus;
								((int*)data)[20] += refineBonus;
								((int*)data)[21] += refineBonus;
								((int*)data)[22] += refineBonus;
								((int*)data)[23] += refineBonus;
								break;
							default:
								((int*)data)[18] += refineBonus;
								((int*)data)[19] += refineBonus;
								((int*)data)[20] += refineBonus;
								((int*)data)[21] += refineBonus;
								((int*)data)[22] += refineBonus;
								((int*)data)[23] += refineBonus;
								break;
							case 7:
								((int*)data)[7] += refineBonus;
								break;
							}
							return;
						}
						while (num2 < (nint)iDs.LongLength);
					}
					num++;
				}
				while (num < RefineAddons.Count);
			}
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	public unsafe void RefineWeapon(string id, int refine_level, int* min_fatc, int* max_fatc, int* min_matc, int* max_matc)
	{
		if (RefineAddons == null)
		{
			return;
		}
		if (!(id == Class16.smethod_0(1648924112)) && (uint)(refine_level - 1) <= 11u)
		{
			int num = 0;
			if (0 < RefineAddons.Count)
			{
				do
				{
					AddonsParts addonsParts = RefineAddons[num];
					int num2 = 0;
					string[] iDs = addonsParts.IDs;
					if (0 < (nint)iDs.LongLength)
					{
						do
						{
							if (!(iDs[num2] == id))
							{
								num2++;
								iDs = addonsParts.IDs;
								continue;
							}
							int refineBonus = GetRefineBonus(refine_level, addonsParts.realvalues[num2]);
							int length = addonsParts.Caption.IndexOf(Class16.smethod_0(1648941500)) - 1;
							addonsParts.Caption.Substring(0, length);
							switch (num)
							{
							case 0:
								*min_fatc += refineBonus;
								*max_fatc += refineBonus;
								break;
							case 1:
								*min_matc += refineBonus;
								*max_matc += refineBonus;
								break;
							case 2:
								*min_fatc += refineBonus;
								*max_fatc += refineBonus;
								*min_matc += refineBonus;
								*max_matc += refineBonus;
								break;
							}
							return;
						}
						while (num2 < (nint)iDs.LongLength);
					}
					num++;
				}
				while (num < RefineAddons.Count);
			}
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	public void Refresh()
	{
		UpdateEquipAddons();
		UpdateRefine();
		method_2();
	}

	public void UpdateEquipAddons()
	{
		List<AddonsParts> equipAddons = EquipAddons;
		if (equipAddons == null)
		{
			return;
		}
		List<AddonsParts>.Enumerator enumerator = equipAddons.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				AddonsParts current = enumerator.Current;
				if (current.bPercent)
				{
					current.Caption = current.Caption.Replace(Class16.smethod_0(1648923229), string.Empty);
				}
				string[] iDs = current.IDs;
				current.values = new string[(nint)iDs.LongLength];
				int num = 0;
				if (0 < (nint)iDs.LongLength)
				{
					do
					{
						int num2 = id2index(current.IDs[num]);
						if (num2 >= 0)
						{
							if (!current.bFloat)
							{
								string text = ((int)eList_0.elementValues[num2][3]).ToString();
								string text2 = ((int)eList_0.elementValues[num2][4]).ToString();
								object[] array = eList_0.elementValues[num2];
								switch ((int)array[2])
								{
								default:
								{
									string text4 = ((int)array[5]).ToString();
									string text5 = Class16.smethod_0(1648923237);
									current.values[num] = string.Concat(string.Concat(string.Concat(string.Concat(current.Caption + text, text5), text2), text5), text4);
									break;
								}
								case 2:
									if (text != text2)
									{
										string text3 = Class16.smethod_0(1648923237);
										current.values[num] = string.Concat(string.Concat(current.Caption + text, text3), text2);
									}
									else
									{
										current.values[num] = current.Caption + text;
									}
									break;
								case 1:
									current.values[num] = current.Caption + text;
									break;
								}
							}
							else
							{
								float num3 = BitConverter.ToSingle(BitConverter.GetBytes((int)eList_0.elementValues[num2][3]), 0);
								GC.KeepAlive(this);
								float num4 = num3;
								float num5 = BitConverter.ToSingle(BitConverter.GetBytes((int)eList_0.elementValues[num2][4]), 0);
								GC.KeepAlive(this);
								float num6 = num5;
								bool bPercent;
								if (bPercent = current.bPercent)
								{
									num4 = num3 * 100f;
								}
								if (bPercent)
								{
									num6 = num5 * 100f;
								}
								float num7 = num4;
								string text6 = num7.ToString();
								float num8 = num6;
								string text7 = num8.ToString();
								switch ((int)eList_0.elementValues[num2][2])
								{
								case 2:
									if (text6 != text7)
									{
										string text8 = Class16.smethod_0(1648923237);
										current.values[num] = string.Concat(string.Concat(current.Caption + text6, text8), text7);
									}
									else
									{
										current.values[num] = current.Caption + text6;
									}
									break;
								case 1:
									current.values[num] = current.Caption + text6;
									break;
								}
								if (current.bPercent)
								{
									current.values[num] = current.values[num] + Class16.smethod_0(1648923229);
								}
							}
						}
						num++;
					}
					while (num < (nint)current.IDs.LongLength);
				}
				if (current.bPercent)
				{
					current.Caption += Class16.smethod_0(1648923229);
				}
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
	}

	public void UpdateRefine()
	{
		List<AddonsParts> refineAddons = RefineAddons;
		if (refineAddons == null)
		{
			return;
		}
		List<AddonsParts>.Enumerator enumerator = refineAddons.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			return;
		}
		do
		{
			AddonsParts current = enumerator.Current;
			string[] iDs = current.IDs;
			current.values = new string[(nint)iDs.LongLength];
			current.realvalues = new int[(nint)iDs.LongLength];
			int num = 0;
			if (0 >= (nint)iDs.LongLength)
			{
				continue;
			}
			do
			{
				int num2 = id2index(current.IDs[num]);
				if (num2 >= 0)
				{
					int num3 = (int)eList_0.elementValues[num2][3];
					string text = current.Caption + num3;
					current.values[num] = text;
					ref int reference = ref current.realvalues[num];
					reference = (int)eList_0.elementValues[num2][3];
				}
				num++;
			}
			while (num < (nint)current.IDs.LongLength);
		}
		while (enumerator.MoveNext());
	}

	public void ValidateFilter(int int_0)
	{
		List<int> filteredListsindices = FilteredListsindices;
		if (filteredListsindices != null && !filteredListsindices.Contains(int_0))
		{
			FilteredListsindices.Add(int_0);
			string uListName = Lists[int_0].uListName;
			if (uListName != null)
			{
				switch (uListName.Length)
				{
				case 13:
					switch (uListName[1])
					{
					case 'O':
						if (uListName == Class16.smethod_0(1648923338))
						{
							List<AddonsParts> equipAddons3 = EquipAddons;
							List<AddonsParts> value3 = FilterAddons(equipAddons3, int_0, Class16.smethod_0(1648922710), Class16.smethod_0(1648922757), 1);
							fEquipAddons.Add(int_0, value3);
						}
						break;
					case 'R':
						if (uListName == Class16.smethod_0(1648923258))
						{
							fEquipAddons.Add(int_0, FilterAddons(EquipAddons, int_0, Class16.smethod_0(1648923486), Class16.smethod_0(1648923552), 2));
						}
						break;
					case 'T':
						if (uListName == Class16.smethod_0(1648923286))
						{
							List<AddonsParts> equipAddons5 = EquipAddons;
							List<AddonsParts> value5 = FilterAddons(equipAddons5, int_0, Class16.smethod_0(1648923615), Class16.smethod_0(1648923637), 1);
							fEquipAddons.Add(int_0, value5);
						}
						break;
					case 'U':
						if (uListName == Class16.smethod_0(1648923298))
						{
							List<AddonsParts> equipAddons4 = EquipAddons;
							List<AddonsParts> value4 = FilterAddons(equipAddons4, int_0, Class16.smethod_0(1648922636), Class16.smethod_0(1648922654), 1);
							fEquipAddons.Add(int_0, value4);
						}
						break;
					case 'I':
						if (uListName == Class16.smethod_0(1648923326))
						{
							List<AddonsParts> equipAddons2 = EquipAddons;
							List<AddonsParts> value2 = FilterAddons(equipAddons2, int_0, Class16.smethod_0(1648922665), Class16.smethod_0(1648922683), 1);
							fEquipAddons.Add(int_0, value2);
						}
						break;
					}
					break;
				case 14:
					if (uListName == Class16.smethod_0(1648923245))
					{
						if ((uint)ushort_0 >= 153u)
						{
							fEquipAddons.Add(int_0, FilterAddons(EquipAddons, int_0, Class16.smethod_0(1648923486), Class16.smethod_0(1648923510), 2));
						}
						else
						{
							fEquipAddons.Add(int_0, FilterAddons(EquipAddons, int_0, Class16.smethod_0(1648923486), Class16.smethod_0(1648923533), 2));
						}
					}
					break;
				case 15:
					if (uListName == Class16.smethod_0(1648923456))
					{
						fEquipAddons.Add(int_0, FilterAddons(EquipAddons, int_0, Class16.smethod_0(1648922636), Class16.smethod_0(1648922730), 2));
					}
					break;
				case 17:
					switch (uListName[0])
					{
					case 'S':
						if (uListName == Class16.smethod_0(1648923408))
						{
							fEquipAddons.Add(int_0, FilterAddons(EquipAddons, int_0, Class16.smethod_0(1648922710), Class16.smethod_0(1648922724), 2));
						}
						break;
					case 'A':
						if (uListName == Class16.smethod_0(1648923432))
						{
							fEquipAddons.Add(int_0, FilterAddons(EquipAddons, int_0, Class16.smethod_0(1648922763), Class16.smethod_0(1648923552), 3));
						}
						break;
					}
					break;
				case 18:
					switch (uListName[0])
					{
					case 'P':
						if (uListName == Class16.smethod_0(1648923391))
						{
							List<AddonsParts> equipAddons = EquipAddons;
							List<AddonsParts> value = FilterAddons(equipAddons, int_0, Class16.smethod_0(1648923583), Class16.smethod_0(1648923599), 1);
							fEquipAddons.Add(int_0, value);
						}
						break;
					case 'D':
						if (uListName == Class16.smethod_0(1648923366))
						{
							fEquipAddons.Add(int_0, FilterAddons(EquipAddons, int_0, Class16.smethod_0(1648923486), Class16.smethod_0(1648923552), 2));
						}
						break;
					}
					break;
				}
			}
		}
		GC.KeepAlive(this);
	}

	private void method_0()
	{
		DBReaderClass dBReader = DBReader;
		string fn = null;
		string[] array = dBReader.Read(Class16.smethod_0(1648922785), bVersion2: false, ref fn);
		if (array != null && array.Length != 0)
		{
			Abilities = new AddonsParts();
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648922801));
			Abilities.Caption = text;
			Abilities.IDs = new string[(nint)array.LongLength];
			Abilities.values = new string[(nint)array.LongLength];
			int num = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					char[] separator = new char[1] { '\t' };
					string[] array2 = array[num].Split(separator);
					Abilities.IDs[num] = array2[0];
					Abilities.values[num] = array2[1];
					num++;
				}
				while (num < (nint)array.LongLength);
			}
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private void method_1()
	{
		string fn = null;
		string[] array = DBReader.Read(Class16.smethod_0(1648922824), bVersion2: false, ref fn);
		if (array != null)
		{
			int num = array.Length;
			if (num >= 2)
			{
				if (num % 2 != 0)
				{
					throw new ApplicationException(Class16.smethod_0(1648922845) + fn);
				}
				int num2 = num / 2;
				EquipAddons = new List<AddonsParts>(num2);
				int num3 = 0;
				if (0 < num2)
				{
					do
					{
						EquipAddons.Add(new AddonsParts());
						EquipAddons[num3].Index = num3;
						char[] separator = new char[1] { '\t' };
						string[] array2 = array[num3 * 2].Split(separator);
						if (array2[0].Contains(Class16.smethod_0(1648923229)))
						{
							EquipAddons[num3].bFloat = true;
							EquipAddons[num3].bPercent = true;
						}
						if ((nint)array2.LongLength >= 2)
						{
							if (array2[1] == Class16.smethod_0(1648934925))
							{
								EquipAddons[num3].bFloat = true;
							}
							if ((nint)array2.LongLength == 3 && array2[2] == Class16.smethod_0(1648934925))
							{
								EquipAddons[num3].bPercent = true;
							}
						}
						if (!array2[0].Contains(Class16.smethod_0(1648941500)) && !array2[0].Contains(Class16.smethod_0(1648941518)))
						{
							array2[0] += Class16.smethod_0(1648922866);
						}
						ref string caption = ref EquipAddons[num3].Caption;
						caption = array2[0];
						char[] separator2 = new char[1] { ' ' };
						string[] iDs = array[num3 * 2 + 1].Split(separator2);
						EquipAddons[num3].IDs = iDs;
						num3++;
					}
					while (num3 < num2);
				}
				UpdateEquipAddons();
				return;
			}
		}
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		OtherAddons = new AddonsParts();
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648922875));
		OtherAddons.Caption = text;
		OtherAddons.IDs = new string[(nint)eList_0.elementValues.LongLength];
		OtherAddons.values = new string[(nint)eList_0.elementValues.LongLength];
		OtherAddons.captions = new string[(nint)eList_0.elementValues.LongLength];
		int num = 0;
		num = ((DBReader.GamePrefix != Class16.smethod_0(1648922898)) ? 1 : num);
		int num2 = 0;
		if (0 < (nint)OtherAddons.IDs.LongLength)
		{
			int num3 = num + 2;
			int int_ = num + 3;
			int int_2 = num + 4;
			do
			{
				int num4;
				try
				{
					num4 = Convert.ToInt32(eList_0.elementValues[num2][0]);
				}
				catch (InvalidCastException)
				{
					num4 = 0;
				}
				catch (FormatException)
				{
					num4 = 0;
				}
				OtherAddons.IDs[num2] = num4.ToString();
				string text2 = null;
				if (DBReader.Game == GAMES.JD)
				{
					decimal value;
					try
					{
						value = Convert.ToInt32(eList_0.elementValues[num2][2]);
					}
					catch (InvalidCastException)
					{
						value = default(decimal);
					}
					catch (FormatException)
					{
						value = default(decimal);
					}
					text2 = DecodedValues.DecodeValue(33, value);
				}
				if (text2 == null || text2 == Class16.smethod_0(1648936686))
				{
					text2 = eList_0.GetValue(num2, 1).Trim();
				}
				int num5;
				try
				{
					num5 = Convert.ToInt32(eList_0.elementValues[num2][num3]);
				}
				catch (InvalidCastException)
				{
					num5 = 0;
				}
				catch (FormatException)
				{
					num5 = 0;
				}
				string text3;
				while (true)
				{
					if (text2.Contains(Class16.smethod_0(1648942889)))
					{
						text2 = text2.Replace(Class16.smethod_0(1648942889), string.Empty);
					}
					if (text2.Contains(Class16.smethod_0(1648942897)))
					{
						text2 = text2.Replace(Class16.smethod_0(1648942897), string.Empty);
					}
					bool bool_ = false;
					if (text2.Contains(Class16.smethod_0(1648923229)))
					{
						text2 = text2.Replace(Class16.smethod_0(1648923229), string.Empty);
						bool_ = true;
					}
					if (text2.EndsWith(Class16.smethod_0(1648922907)))
					{
						text2 = text2.Substring(0, text2.Length - 4);
					}
					else if (text2.EndsWith(Class16.smethod_0(1648922926)))
					{
						text2 = text2.Substring(0, text2.Length - 2);
					}
					else if (text2.EndsWith(Class16.smethod_0(1648922907)))
					{
						text2 = text2.Substring(0, text2.Length - 4);
					}
					text3 = Class16.smethod_0(1648941500);
					if (text2.Contains(Class16.smethod_0(1648922929)))
					{
						text3 = Class16.smethod_0(1648941518);
					}
					else if (text2.Contains(Class16.smethod_0(1648922938)))
					{
						text3 = string.Empty;
					}
					text2 = text2.Trim();
					int num6 = 0;
					int num7 = text2.Length - 1;
					if (num7 > 0)
					{
						do
						{
							char c = text2[num7];
							if ((uint)(ushort)(c + 65504) > 32u)
							{
								break;
							}
							num6++;
							num7--;
						}
						while (num7 > 0);
						if (num6 > 0)
						{
							text2 = text2.Substring(0, text2.Length - num6);
						}
					}
					string text4 = method_4(num2, int_, bool_);
					string text5 = method_4(num2, int_2, bool_);
					if (num5 != 1)
					{
						if (num5 != 2)
						{
							if (num5 > 3 && DBReader.Game == GAMES.PW)
							{
								num5 -= 3;
								int valueIFast = eList_0.GetValueIFast(num2, 5);
								if (valueIFast > 0)
								{
									text2 = GetAddonTitleByID(valueIFast);
									continue;
								}
								text2 = Class16.smethod_0(1648922957);
								OtherAddons.values[num2] = text2;
								break;
							}
							string text6 = Class16.smethod_0(1648923237);
							OtherAddons.values[num2] = string.Concat(string.Concat(string.Concat(string.Concat(text2 + Class16.smethod_0(1648942211), text3), text4), text6), text5);
							break;
						}
						string text7 = Class16.smethod_0(1648923237);
						OtherAddons.values[num2] = string.Concat(string.Concat(string.Concat(string.Concat(text2 + Class16.smethod_0(1648942211), text3), text4), text7), text5);
						break;
					}
					OtherAddons.values[num2] = string.Concat(string.Concat(text2 + Class16.smethod_0(1648942211), text3), text4);
					break;
				}
				OtherAddons.captions[num2] = string.Concat(text2 + Class16.smethod_0(1648942211), text3);
				num2++;
			}
			while (num2 < (nint)OtherAddons.IDs.LongLength);
		}
		GC.KeepAlive(this);
	}

	private static bool smethod_0(object object_0, out int int_0)
	{
		try
		{
			int_0 = Convert.ToInt32(object_0);
			return true;
		}
		catch
		{
			int_0 = 0;
			return false;
		}
	}

	private void method_3()
	{
		DBReaderClass dBReader = DBReader;
		string fn = null;
		string[] array = dBReader.Read(Class16.smethod_0(1648922963), bVersion2: false, ref fn);
		if (array != null)
		{
			int num = array.Length;
			if (num >= 2 && num % 2 == 0)
			{
				int num2 = num / 2;
				RefineAddons = new List<AddonsParts>(num2);
				int num3 = 0;
				if (0 < num2)
				{
					do
					{
						RefineAddons.Add(new AddonsParts());
						ref string caption = ref RefineAddons[num3].Caption;
						int num4 = num3 * 2;
						caption = array[num4];
						char[] separator = new char[1] { ' ' };
						string[] iDs = array[num4 + 1].Split(separator);
						RefineAddons[num3].IDs = iDs;
						num3++;
					}
					while (num3 < num2);
				}
				UpdateRefine();
				return;
			}
		}
		GC.KeepAlive(this);
	}

	private string method_4(int int_0, int int_1, [MarshalAs(UnmanagedType.U1)] bool bool_0)
	{
		if (eList_0 != null && eList_0.elementValues != null && int_0 >= 0 && int_0 < eList_0.elementValues.Length && eList_0.elementValues[int_0] != null && int_1 >= 0 && int_1 < eList_0.elementValues[int_0].Length)
		{
			object object_ = eList_0.elementValues[int_0][int_1];
			if (method_7(int_0, int_1, bool_0))
			{
				if (!smethod_0(object_, out var int_2))
				{
					return Class16.smethod_0(1648924112);
				}
				float num = BitConverter.ToSingle(BitConverter.GetBytes(int_2), 0);
				GC.KeepAlive(this);
				if (bool_0)
				{
					string result = ACE.RSGlobal.RSGlobal.ToPercent(num, 4);
					GC.KeepAlive(this);
					return result;
				}
				float num2 = num;
				string result2 = num2.ToString(Class16.smethod_0(1648922976));
				GC.KeepAlive(this);
				return result2;
			}
			if (!smethod_0(object_, out var int_3))
			{
				return Class16.smethod_0(1648924112);
			}
			string result3 = int_3.ToString();
			GC.KeepAlive(this);
			return result3;
		}
		return Class16.smethod_0(1648924112);
	}

	private string method_5(int int_0, int int_1)
	{
		return method_4(int_0, int_1, bool_0: false);
	}

	private float method_6(int int_0)
	{
		float result = BitConverter.ToSingle(BitConverter.GetBytes(int_0), 0);
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_7(int int_0, int int_1, [MarshalAs(UnmanagedType.U1)] bool bool_0)
	{
		eList eList2 = eList_0;
		if (eList2 != null && int_0 >= 0 && int_0 < eList2.ItemCount)
		{
			FIELD_DATA_TYPE_ENUM fIELD_DATA_TYPE_ENUM = CommonStorage.AParams?.GetCustomAddonType(eList2.getid(int_0)) ?? FIELD_DATA_TYPE_ENUM.Unknown;
			if (fIELD_DATA_TYPE_ENUM > FIELD_DATA_TYPE_ENUM.Unknown)
			{
				GC.KeepAlive(this);
				int num = ((int_1 < 5 && fIELD_DATA_TYPE_ENUM == FIELD_DATA_TYPE_ENUM.Float) ? 1 : 0);
				return (byte)num != 0;
			}
			try
			{
				if (!bool_0 && Lists[0]?.elementValues != null && int_0 < Lists[0].elementValues.Length && Lists[0].elementValues[int_0] != null && int_1 < Lists[0].elementValues[int_0].Length && Convert.ToInt32(Lists[0].elementValues[int_0][int_1]) <= 500000000)
				{
					return false;
				}
			}
			catch (InvalidCastException)
			{
				return false;
			}
			catch (FormatException)
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
