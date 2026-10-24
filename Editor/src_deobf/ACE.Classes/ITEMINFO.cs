using System.Drawing;

namespace ACE.Classes;

public class ITEMINFO
{
	public ItemType item_type;

	public int id;

	public string ID;

	public string name;

	public Color color;

	public ITEMPOS pos;

	public string IconName;

	public bool IsTgaIcon;

	public int RefCount;

	public bool bOcupiedID;

	public bool bHasReferences;

	public bool bHasErrors;

	public int SubItemsCount;

	public string CatName;

	public Color CatColor;

	public int _link_id;

	public bool bCustomItem;

	public string NameWithSubItems()
	{
		int subItemsCount = SubItemsCount;
		if (subItemsCount > 0)
		{
			return string.Format(Class16.smethod_0(1648904238), name, subItemsCount);
		}
		return name;
	}

	public ITEMINFO Clone()
	{
		return new ITEMINFO
		{
			item_type = item_type,
			id = id,
			ID = ID,
			name = name,
			color = color,
			pos = pos,
			IconName = IconName,
			IsTgaIcon = IsTgaIcon,
			RefCount = RefCount,
			bOcupiedID = bOcupiedID,
			bHasReferences = bHasReferences,
			bHasErrors = bHasErrors,
			SubItemsCount = SubItemsCount,
			CatName = CatName,
			CatColor = CatColor,
			_link_id = _link_id,
			bCustomItem = bCustomItem
		};
	}
}
