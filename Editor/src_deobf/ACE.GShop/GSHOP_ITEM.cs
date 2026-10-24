using System;
using ACE.Classes;

namespace ACE.GShop;

public class GSHOP_ITEM
{
	public int ID;

	public string name = string.Empty;

	public int ItemID;

	public int Count = 1;

	public int GiftID;

	public ITEMINFO ItemInfo;

	public string sName
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
			GC.KeepAlive(this);
		}
	}

	public GSHOP_ITEM Clone()
	{
		GSHOP_ITEM gSHOP_ITEM = new GSHOP_ITEM();
		gSHOP_ITEM.ID = ID;
		gSHOP_ITEM.name = name;
		gSHOP_ITEM.ItemID = ItemID;
		gSHOP_ITEM.Count = Count;
		gSHOP_ITEM.GiftID = GiftID;
		gSHOP_ITEM.ItemInfo = ItemInfo?.Clone();
		GC.KeepAlive(this);
		return gSHOP_ITEM;
	}
}
