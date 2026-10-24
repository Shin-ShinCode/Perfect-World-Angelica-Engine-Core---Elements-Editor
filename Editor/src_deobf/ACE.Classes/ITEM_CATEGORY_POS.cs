using ACE.GShop;

namespace ACE.Classes;

public class ITEM_CATEGORY_POS
{
	public SHOP_CATEGORY_FW Category;

	public int pos1;

	public int pos2;

	public int pos3;

	public int deep;

	public int item_pos;

	public ITEM_CATEGORY_POS(SHOP_CATEGORY_FW Category, int c1, int c2, int c3, int index)
	{
		this.Category = Category;
		pos1 = c1;
		pos2 = c2;
		pos3 = c3;
		item_pos = index;
		if (c3 > -1)
		{
			deep = 3;
		}
		else if (c2 > -1)
		{
			deep = 2;
		}
		else
		{
			deep = 1;
		}
	}

	public ITEM_CATEGORY_POS()
	{
		pos1 = -1;
		pos2 = -1;
		pos3 = -1;
		item_pos = -1;
	}
}
