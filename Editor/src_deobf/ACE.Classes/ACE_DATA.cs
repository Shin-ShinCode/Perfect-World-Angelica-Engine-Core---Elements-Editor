using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.RSGlobal;

namespace ACE.Classes;

[Serializable]
public class ACE_DATA
{
	public int ClassVersion = 1;

	public string Caption;

	public GAMES Game;

	public int ElementsVersion;

	public bool bWithSubitems;

	[NonSerialized]
	public eListCollection eLC;

	[NonSerialized]
	public HashSet<vITEMPOS> AddedItems;

	[NonSerialized]
	public HashSet<int> AddedQuests;

	[NonSerialized]
	public bool bCaptionCreated;

	public Dictionary<int, ACE_DATA_LIST> Lists;

	public Dictionary<int, ACE_DATA_LIST> SubitemsLists;

	public int ItemCount;

	public int SubitemCount;

	public int TotalCount => SubitemCount + ItemCount;

	public ACE_DATA(eListCollection eLC, [MarshalAs(UnmanagedType.U1)] bool bWithSubitems)
	{
		this.eLC = eLC;
		this.bWithSubitems = bWithSubitems;
		Game = eLC.Game;
		ElementsVersion = eLC.Version;
		Lists = new Dictionary<int, ACE_DATA_LIST>();
		AddedItems = new HashSet<vITEMPOS>();
		if (bWithSubitems)
		{
			SubitemsLists = new Dictionary<int, ACE_DATA_LIST>();
		}
	}

	public void AddItem(int int_0, object[] itemValues, [MarshalAs(UnmanagedType.U1)] bool bSubitem, string description, int color)
	{
		Dictionary<int, ACE_DATA_LIST> dictionary = Lists;
		if (bSubitem)
		{
			dictionary = SubitemsLists;
		}
		ACE_DATA_LIST value = null;
		bool flag;
		if (!(flag = dictionary.TryGetValue(int_0, out value)))
		{
			eList eList2 = eLC.Lists[int_0];
			eList eList3 = eList2;
			eList eList4 = eList2;
			value = new ACE_DATA_LIST(eList2.uListName, eList4.elementFields, eList3.elementTypes);
			value.ListIndex = int_0;
			value.IsSubitems = bSubitem;
		}
		value.AddItem(itemValues, description, color);
		if (!flag)
		{
			dictionary.Add(int_0, value);
		}
		if (bSubitem)
		{
			SubitemCount++;
		}
		else
		{
			ItemCount++;
		}
	}

	public void AddItem(int int_0, object[] itemValues, [MarshalAs(UnmanagedType.U1)] bool bSubitem)
	{
		int num = (int)itemValues[0];
		string description = null;
		int color = -1;
		if (eLC.IsMattersList(int_0))
		{
			if (eLC.IsDescExist(num))
			{
				description = eLC.Descriptions.Descriptions[num];
			}
			if (eLC.IsColorExist(num))
			{
				color = eLC.Colors.Colors[num];
			}
		}
		AddItem(int_0, itemValues, bSubitem, description, color);
	}

	public void AddItem(int int_0, int int_1, [MarshalAs(UnmanagedType.U1)] bool bSubitem)
	{
		vITEMPOS item = new vITEMPOS
		{
			Int32_1 = int_0,
			Int32_0 = int_1
		};
		if (AddedItems.Contains(item))
		{
			return;
		}
		if (!bSubitem && !bCaptionCreated)
		{
			if (Caption != null)
			{
				string parsedItemName = eLC.GetParsedItemName(int_0, int_1, bRealAddonName: true);
				string caption = Caption;
				Caption = string.Concat(caption, Class16.smethod_0(1648928044) + parsedItemName);
				bCaptionCreated = true;
			}
			else
			{
				eListCollection eListCollection2 = eLC;
				Caption = eListCollection2.GetParsedItemName(int_0, int_1, bRealAddonName: true);
			}
		}
		object[] itemValues = global::ACE.RSGlobal.RSGlobal.CloneArray(eLC.Lists[int_0].elementValues[int_1]);
		AddItem(int_0, itemValues, bSubitem);
		AddedItems.Add(item);
		if (!bWithSubitems)
		{
			return;
		}
		int num = 1;
		if (1 >= (nint)eLC.Lists[int_0].elementTypes.LongLength)
		{
			return;
		}
		do
		{
			if (eLC.GetFieldType(int_0, int_1, num) >= FIELDTYPE.matters)
			{
				eListCollection eListCollection3 = eLC;
				int iDinField = eListCollection3.GetIDinField(int_0, int_1, num);
				ITEMPOS iTEMPOS = ((iDinField <= 0) ? null : eListCollection3.FindItemPos(eListCollection3.GetFieldLists(int_0, int_1, num), iDinField));
				if (iTEMPOS != null)
				{
					AddItem(iTEMPOS.int_0, iTEMPOS.int_1, bSubitem: true);
				}
			}
			num++;
		}
		while (num < (nint)eLC.Lists[int_0].elementTypes.LongLength);
	}

	public void AddItem(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool bSubitem)
	{
		AddItem(ItemPos.int_0, ItemPos.int_1, bSubitem);
	}
}
