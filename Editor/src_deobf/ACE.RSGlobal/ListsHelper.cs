using ACE.Classes;
using ACE.Elements.eList;

namespace ACE.RSGlobal;

public class ListsHelper
{
	public static int GetListIndexByListType(eList[] lists, ItemType listType)
	{
		int num = 0;
		int num2 = lists.Length;
		if (0 < num2)
		{
			eList eList2;
			while (true)
			{
				eList2 = lists[num];
				if (eList2.ListType == listType)
				{
					break;
				}
				num++;
				if (num >= num2)
				{
					return -1;
				}
			}
			return eList2.ListIndex;
		}
		return -1;
	}
}
