using System;
using ACE.RSGlobal;

namespace ACE.GShop;

public class GSHOP_ITEM_FW : GSHOP_ITEM
{
	public int FileIcon;

	public uint IsHide;

	public uint CanGetConsumeScore;

	public uint uint_0;

	public float GiftRate;

	public uint BuyTypeMask;

	public int price;

	public uint ExpireDate;

	public byte[] ext_search;

	public uint NewItemIndex;

	public uint SellBeginTime;

	public uint SellEndTime;

	public uint DiscountBeginTime;

	public uint DiscountEndTime;

	public int DiscountPrice;

	public int LogoIcon;

	public int PreviewBackgroundPic;

	public int PreviewPriority;

	public uint DiscountItemShowIndex;

	public int PriorityPreviewModel;

	public uint LimitTimesTaskId;

	public int Price
	{
		get
		{
			int result = (int)Math.Floor((double)price * 0.4);
			GC.KeepAlive(this);
			return result;
		}
		set
		{
			if (value % 2 == 1)
			{
				value++;
			}
			price = (int)Math.Ceiling((double)value * 2.5);
			GC.KeepAlive(this);
		}
	}

	public string sExtSearch
	{
		get
		{
			string result = ACE.RSGlobal.RSGlobal.ToStringW(ext_search);
			GC.KeepAlive(this);
			return result;
		}
		set
		{
			ext_search = ACE.RSGlobal.RSGlobal.ToBytesW(value, 16);
			GC.KeepAlive(this);
		}
	}

	public new GSHOP_ITEM_FW Clone()
	{
		GSHOP_ITEM_FW gSHOP_ITEM_FW = (GSHOP_ITEM_FW)MemberwiseClone();
		gSHOP_ITEM_FW.name = name;
		byte[] array = (gSHOP_ITEM_FW.ext_search = new byte[32]);
		ext_search.CopyTo(array, 0);
		GC.KeepAlive(this);
		return gSHOP_ITEM_FW;
	}
}
