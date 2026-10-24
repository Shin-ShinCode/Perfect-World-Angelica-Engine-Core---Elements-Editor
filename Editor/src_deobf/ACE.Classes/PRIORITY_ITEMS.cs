using System;
using System.Collections.Generic;
using ACE.RSGlobal;

namespace ACE.Classes;

public class PRIORITY_ITEMS
{
	public static vITEMPOS[] RecentItems;

	public static HashSet<vITEMPOS> UsersItems;

	public static Dictionary<int, int[]> ShortcutItems;

	public static Dictionary<int, int[]> RecentItemsByList;

	public static Dictionary<int, int[]> UsersItemsByList;

	public static Dictionary<LISTandID, int> FavoriteItems;

	public static Dictionary<LISTandID, int> FavoriteItemsLimited;

	public static bool bPriorityChanged = true;

	public static HashSet<int> PriorityIDs;

	public static HashSet<int> GetPriorities(int ListIndex)
	{
		int[] array = null;
		int[] array2 = null;
		int[] value = null;
		PriorityIDs = new HashSet<int>();
		if (ShortcutItems != null && ShortcutItems.TryGetValue(ListIndex, out value))
		{
			PriorityIDs.UnionWith(value);
		}
		array = null;
		if (RecentItemsByList != null && RecentItemsByList.TryGetValue(ListIndex, out array))
		{
			PriorityIDs.UnionWith(array);
		}
		array2 = null;
		if (UsersItemsByList != null && UsersItemsByList.TryGetValue(ListIndex, out array2))
		{
			PriorityIDs.UnionWith(array2);
		}
		return PriorityIDs;
	}

	public static ITEMPOS[] GetRecents()
	{
		ITEMPOS[] array = new ITEMPOS[(nint)RecentItems.LongLength];
		int num = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				ref vITEMPOS reference = ref RecentItems[num];
				ITEMPOS iTEMPOS = new ITEMPOS(reference.Int32_1, reference.Int32_0);
				array[num] = iTEMPOS;
				num++;
			}
			while (num < (nint)array.LongLength);
		}
		return array;
	}

	public static void LoadRecentItemsList()
	{
		RecentItemsByList = CommonStorage.AParams.ElementsRecentItems;
		if (RecentItemsByList == null)
		{
			RecentItemsByList = new Dictionary<int, int[]>();
		}
		RecentItems = CommonStorage.AParams.ElementsRecentItemsGlobal;
		if (RecentItems == null)
		{
			RecentItems = new vITEMPOS[0];
		}
		if (CommonStorage.AParams.RecentItemsLimit <= 0)
		{
			RecentItemsByList.Clear();
			int length = RecentItems.Length;
			Array.Clear(RecentItems, 0, length);
		}
		FavoriteItems = CommonStorage.AParams.ElementsFavoriteItems;
		if (FavoriteItems == null)
		{
			FavoriteItems = new Dictionary<LISTandID, int>();
		}
		if (CommonStorage.AParams.FavoriteItemsLimit <= 0)
		{
			FavoriteItems.Clear();
		}
		int num = 1;
		if (FavoriteItems.Count > 1000)
		{
			do
			{
				CheckFavoriteItemsOverflow(1000, num);
				num++;
			}
			while (FavoriteItems.Count > 1000);
		}
	}

	public static void CheckFavoriteItemsOverflow(int limit, int min_val)
	{
		if (FavoriteItems.Count <= limit)
		{
			return;
		}
		Dictionary<LISTandID, int> dictionary = new Dictionary<LISTandID, int>();
		Dictionary<LISTandID, int>.Enumerator enumerator = FavoriteItems.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				ValueType valueType = enumerator.Current;
				if (((KeyValuePair<LISTandID, int>)(object)valueType).Value > min_val)
				{
					LISTandID key = ((KeyValuePair<LISTandID, int>)(object)valueType).Key;
					dictionary.Add(key, ((KeyValuePair<LISTandID, int>)(object)valueType).Value);
				}
			}
			while (enumerator.MoveNext());
		}
		FavoriteItems = dictionary;
	}

	public static void AddRecentItem(ITEMPOS ItemPos, int id)
	{
		int[] array = null;
		if (CommonStorage.AParams.RecentItemsLimit <= 0 || RecentItemsByList == null)
		{
			return;
		}
		array = null;
		int int_ = ItemPos.int_0;
		if (RecentItemsByList.TryGetValue(int_, out array))
		{
			int num = Array.IndexOf(array, id);
			if (num != 0)
			{
				if (num > 0)
				{
					global::ACE.RSGlobal.RSGlobal.RemoveArrayElement(array, num);
				}
				global::ACE.RSGlobal.RSGlobal.AddValueToStack(ref array, id, CommonStorage.AParams.RecentItemsLimit);
				int int_2 = ItemPos.int_0;
				RecentItemsByList[int_2] = array;
			}
		}
		else
		{
			int[] value = new int[1] { id };
			int int_3 = ItemPos.int_0;
			RecentItemsByList.Add(int_3, value);
		}
		vITEMPOS vITEMPOS2 = new vITEMPOS(ItemPos);
		vITEMPOS vITEMPOS3 = vITEMPOS2;
		int num2 = Array.IndexOf(RecentItems, vITEMPOS3);
		if (num2 != 0)
		{
			if (num2 > 0)
			{
				global::ACE.RSGlobal.RSGlobal.RemoveArrayElement(ref RecentItems, num2);
			}
			AddItemToStack(ref RecentItems, vITEMPOS3, CommonStorage.AParams.RecentItemsLimit);
			bPriorityChanged = true;
		}
		LISTandID lISTandID = new LISTandID
		{
			Int32_0 = ItemPos.int_0
		};
		int id2 = ((id > 1000000) ? 100000 : id);
		lISTandID.id = id2;
		LISTandID key = lISTandID;
		if (FavoriteItems.ContainsKey(key))
		{
			int num3 = FavoriteItems[key];
			num3++;
			FavoriteItems[key] = num3;
		}
		else
		{
			FavoriteItems.Add(key, 1);
		}
		CommonStorage.AParams.ElementsRecentItems = RecentItemsByList;
		CommonStorage.AParams.ElementsRecentItemsGlobal = RecentItems;
		CommonStorage.AParams.ElementsFavoriteItems = FavoriteItems;
	}

	public static void AddItemToStack(ref vITEMPOS[] arr, vITEMPOS vItem, int limit)
	{
		if (limit > 0)
		{
			vITEMPOS[] array = arr;
			if (array == null || array.Length == 0 || limit == 1)
			{
				arr = new vITEMPOS[1] { vItem };
			}
			int num = (int)((nint)arr.LongLength + 1);
			int num2 = ((num < limit) ? num : limit);
			vITEMPOS[] array2 = new vITEMPOS[num2];
			array2[0] = vItem;
			Array.Copy(arr, 0, array2, 1, num2 - 1);
			arr = array2;
		}
	}

	public static void SortItemsByPriority(ref List<vITEMPOS> Items, List<int> PriorityLists, int UntouchableItemCount)
	{
		HashSet<vITEMPOS> hashSet = new HashSet<vITEMPOS>(Items);
		HashSet<vITEMPOS> hashSet2 = new HashSet<vITEMPOS>();
		if (UntouchableItemCount > 0 && UntouchableItemCount < Items.Count)
		{
			int num = 0;
			if (0 < UntouchableItemCount)
			{
				do
				{
					vITEMPOS item = Items[num];
					hashSet2.Add(item);
					num++;
				}
				while (num < UntouchableItemCount);
			}
		}
		vITEMPOS[] recentItems = RecentItems;
		int num2 = 0;
		if (0 < (nint)recentItems.LongLength)
		{
			do
			{
				ref vITEMPOS reference = ref recentItems[num2];
				if (hashSet.Contains(reference) && !hashSet2.Contains(reference))
				{
					hashSet2.Add(reference);
				}
				num2++;
			}
			while (num2 < (nint)recentItems.LongLength);
		}
		if (PriorityLists != null)
		{
			List<int>.Enumerator enumerator = PriorityLists.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					int current = enumerator.Current;
					List<vITEMPOS>.Enumerator enumerator2 = Items.GetEnumerator();
					if (!enumerator2.MoveNext())
					{
						continue;
					}
					do
					{
						vITEMPOS current2 = enumerator2.Current;
						if (current2.Int32_1 == current && !hashSet2.Contains(current2))
						{
							hashSet2.Add(current2);
						}
					}
					while (enumerator2.MoveNext());
				}
				while (enumerator.MoveNext());
			}
		}
		if (UsersItems != null)
		{
			int num3 = 0;
			if (0 < Items.Count)
			{
				do
				{
					vITEMPOS item2 = Items[num3];
					if (UsersItems.Contains(item2) && !hashSet2.Contains(item2))
					{
						hashSet2.Add(item2);
					}
					num3++;
				}
				while (num3 < Items.Count);
			}
		}
		int num4 = 0;
		if (0 < Items.Count)
		{
			do
			{
				vITEMPOS item3 = Items[num4];
				if (!hashSet2.Contains(item3))
				{
					vITEMPOS item4 = Items[num4];
					hashSet2.Add(item4);
				}
				num4++;
			}
			while (num4 < Items.Count);
		}
		Items = new List<vITEMPOS>(hashSet2);
	}

	public static void SortItemsByPriority(ref List<vITEMPOS> Items)
	{
		SortItemsByPriority(ref Items, null, 0);
	}

	public static List<vITEMPOS> GetRecentItems(int limit)
	{
		if ((nint)RecentItems.LongLength > limit)
		{
			Array.Resize(ref RecentItems, limit);
		}
		return new List<vITEMPOS>(RecentItems);
	}

	public static List<LISTandID> GetFavoriteItems(int limit)
	{
		int num = ((limit >= FavoriteItems.Count) ? FavoriteItems.Count : limit);
		List<LISTandID> list = new List<LISTandID>(num);
		int[] array = new int[FavoriteItems.Count];
		LISTandID[] array2 = new LISTandID[FavoriteItems.Count];
		FavoriteItems.Values.CopyTo(array, 0);
		FavoriteItems.Keys.CopyTo(array2, 0);
		if (list.Count < num)
		{
			do
			{
				int num2 = 1;
				int num3 = 0;
				int num4 = 0;
				int num5 = array.Length;
				if (0 >= num5)
				{
					break;
				}
				do
				{
					int num6 = array[num4];
					if (num6 >= num2)
					{
						num3 = num4;
						num2 = num6;
					}
					num4++;
				}
				while (num4 < num5);
				if (num2 <= 1)
				{
					break;
				}
				list.Add(array2[num3]);
				array[num3] = 0;
			}
			while (list.Count < num);
		}
		if (list.Count < num)
		{
			int num7 = (int)((nint)array2.LongLength - 1);
			if (num7 >= 0)
			{
				do
				{
					if (array[num7] <= 1)
					{
						list.Add(array2[num7]);
					}
					if (list.Count >= num)
					{
						break;
					}
					num7--;
				}
				while (num7 >= 0);
			}
		}
		return list;
	}
}
