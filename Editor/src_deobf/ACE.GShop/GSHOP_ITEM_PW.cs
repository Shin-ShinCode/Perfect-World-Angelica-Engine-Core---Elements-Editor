using System;
using ACE.Classes;
using ACE.Cpk;

namespace ACE.GShop;

public class GSHOP_ITEM_PW : GSHOP_ITEM
{
	public PW_GSHOP_VERSION Version;

	public uint CatIndex;

	public uint SubCatIndex;

	public string icon_path = string.Empty;

	public SALE_OPTION[] SaleOptions;

	public string description = string.Empty;

	public int GiftCount;

	public uint GiftDuration;

	public uint LogPrice;

	public int[] owner_npcs;

	public int BuyTimesLimit;

	public int BuyTimesLimitMode;

	public int tasks_id;

	public int tasks_space;

	public int Occupation = -1;

	public int reserved1;

	public int reserved2;

	public int reserved3;

	public int reserved4;

	public int special_server_forbid;

	public byte in_green_shop;

	public byte unk184;

	public int add_trade_time;

	public int reserved6;

	public int MinVipLevel
	{
		get
		{
			if (SaleOptions == null)
			{
				return 0;
			}
			return (int)SaleOptions[CurrentOptionIndex].MinVipLevel;
		}
		set
		{
			if (SaleOptions != null)
			{
				SaleOptions[CurrentOptionIndex].MinVipLevel = (uint)value;
			}
		}
	}

	public int ControlType
	{
		get
		{
			if (SaleOptions == null)
			{
				return 0;
			}
			return SaleOptions[CurrentOptionIndex].ControlType;
		}
		set
		{
			if (SaleOptions != null)
			{
				SaleOptions[CurrentOptionIndex].ControlType = value;
			}
		}
	}

	public uint Flags
	{
		get
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				return SaleOptions[CurrentOptionIndex].Flags;
			}
			return 0u;
		}
		set
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				SaleOptions[CurrentOptionIndex].Flags = value;
			}
		}
	}

	public uint Status
	{
		get
		{
			if (SaleOptions == null)
			{
				return 0u;
			}
			if (Version == PW_GSHOP_VERSION.PW_1_2_6)
			{
				if (SaleOptions.Length != 0 && SaleOptions[0] != null)
				{
					return SaleOptions[0].Status;
				}
				return 0u;
			}
			if (CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				return SaleOptions[CurrentOptionIndex].Status;
			}
			return 0u;
		}
		set
		{
			if (SaleOptions == null)
			{
				return;
			}
			if (Version == PW_GSHOP_VERSION.PW_1_2_6)
			{
				if (SaleOptions.Length != 0 && SaleOptions[0] != null)
				{
					SaleOptions[0].Status = value;
				}
			}
			else if (CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				SaleOptions[CurrentOptionIndex].Status = value;
			}
		}
	}

	public uint Day
	{
		get
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				return SaleOptions[CurrentOptionIndex].Day;
			}
			return 0u;
		}
		set
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				SaleOptions[CurrentOptionIndex].Day = value;
			}
		}
	}

	public uint StartDate
	{
		get
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				return SaleOptions[CurrentOptionIndex].StartDate;
			}
			return 0u;
		}
		set
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				SaleOptions[CurrentOptionIndex].StartDate = value;
			}
		}
	}

	public uint Duration
	{
		get
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				return SaleOptions[CurrentOptionIndex].Duration;
			}
			return 0u;
		}
		set
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				SaleOptions[CurrentOptionIndex].Duration = value;
			}
		}
	}

	public uint ExpireDate
	{
		get
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				return SaleOptions[CurrentOptionIndex].ExpireDate;
			}
			return 0u;
		}
		set
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				SaleOptions[CurrentOptionIndex].ExpireDate = value;
			}
		}
	}

	public double Price
	{
		get
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				return (double)SaleOptions[CurrentOptionIndex].Price / 100.0;
			}
			return 0.0;
		}
		set
		{
			if (SaleOptions != null && CurrentOptionIndex < SaleOptions.Length && SaleOptions[CurrentOptionIndex] != null)
			{
				uint price = (uint)Math.Ceiling(value * 100.0);
				SaleOptions[CurrentOptionIndex].Price = price;
			}
			GC.KeepAlive(this);
		}
	}

	public uint CurrentOptionIndex
	{
		get
		{
			if (CommonStorage.AParams != null)
			{
				uint currentGShopSaleOption = CommonStorage.AParams.CurrentGShopSaleOption;
				GC.KeepAlive(this);
				return currentGShopSaleOption;
			}
			GC.KeepAlive(this);
			return 0u;
		}
	}

	public string sDescription
	{
		get
		{
			return description;
		}
		set
		{
			description = value;
		}
	}

	public string sIconPath
	{
		get
		{
			return (icon_path ?? string.Empty).ToLowerInvariant();
		}
		set
		{
			icon_path = value;
		}
	}

	public new GSHOP_ITEM_PW Clone()
	{
		GSHOP_ITEM_PW gSHOP_ITEM_PW = new GSHOP_ITEM_PW();
		gSHOP_ITEM_PW.Version = Version;
		gSHOP_ITEM_PW.ID = ID;
		gSHOP_ITEM_PW.CatIndex = CatIndex;
		gSHOP_ITEM_PW.SubCatIndex = SubCatIndex;
		gSHOP_ITEM_PW.icon_path = icon_path ?? string.Empty;
		gSHOP_ITEM_PW.ItemID = ItemID;
		gSHOP_ITEM_PW.Count = Count;
		gSHOP_ITEM_PW.SaleOptions = new SALE_OPTION[4];
		for (int i = 0; i < 4; i++)
		{
			if (SaleOptions != null && i < SaleOptions.Length && SaleOptions[i] != null)
			{
				gSHOP_ITEM_PW.SaleOptions[i] = SaleOptions[i].Clone();
			}
			else
			{
				gSHOP_ITEM_PW.SaleOptions[i] = new SALE_OPTION();
			}
		}
		gSHOP_ITEM_PW.description = description ?? string.Empty;
		gSHOP_ITEM_PW.name = name ?? string.Empty;
		gSHOP_ITEM_PW.GiftID = GiftID;
		gSHOP_ITEM_PW.GiftCount = GiftCount;
		gSHOP_ITEM_PW.GiftDuration = GiftDuration;
		gSHOP_ITEM_PW.LogPrice = LogPrice;
		if (owner_npcs != null)
		{
			gSHOP_ITEM_PW.owner_npcs = new int[owner_npcs.Length];
			Array.Copy(owner_npcs, gSHOP_ITEM_PW.owner_npcs, owner_npcs.Length);
		}
		else
		{
			gSHOP_ITEM_PW.owner_npcs = null;
		}
		gSHOP_ITEM_PW.BuyTimesLimit = BuyTimesLimit;
		gSHOP_ITEM_PW.BuyTimesLimitMode = BuyTimesLimitMode;
		gSHOP_ITEM_PW.tasks_id = tasks_id;
		gSHOP_ITEM_PW.tasks_space = tasks_space;
		gSHOP_ITEM_PW.Occupation = Occupation;
		gSHOP_ITEM_PW.reserved1 = reserved1;
		gSHOP_ITEM_PW.reserved2 = reserved2;
		gSHOP_ITEM_PW.reserved3 = reserved3;
		gSHOP_ITEM_PW.reserved4 = reserved4;
		gSHOP_ITEM_PW.special_server_forbid = special_server_forbid;
		gSHOP_ITEM_PW.in_green_shop = in_green_shop;
		gSHOP_ITEM_PW.add_trade_time = add_trade_time;
		gSHOP_ITEM_PW.reserved6 = reserved6;
		return gSHOP_ITEM_PW;
	}
}
