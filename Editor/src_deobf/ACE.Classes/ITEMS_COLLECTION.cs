using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ACE.Classes;

[Serializable]
public class ITEMS_COLLECTION
{
	[NonSerialized]
	public List<vITEMPOS> ItemsList;

	public HashSet<LISTandID> ListAndIdHashes;

	public HashSet<vITEMPOS> ItemsHashes;

	public HashSet<int> FieldsHashes;

	public HashSet<int> IDsHashes;

	public bool bChangeDesc;

	public int Count
	{
		get
		{
			HashSet<vITEMPOS> itemsHashes = ItemsHashes;
			if (itemsHashes != null)
			{
				int count = itemsHashes.Count;
				GC.KeepAlive(this);
				return count;
			}
			List<vITEMPOS> itemsList = ItemsList;
			if (itemsList != null)
			{
				int count2 = itemsList.Count;
				GC.KeepAlive(this);
				return count2;
			}
			GC.KeepAlive(this);
			return 0;
		}
	}

	public vITEMPOS this[int index]
	{
		get
		{
			vITEMPOS result = GetListOfItems()[index];
			GC.KeepAlive(this);
			return result;
		}
		set
		{
			ItemsList[index] = value;
			GC.KeepAlive(this);
		}
	}

	public ITEMS_COLLECTION(int[] IDs)
	{
		(IDsHashes = new HashSet<int>()).UnionWith(IDs);
		GC.KeepAlive(this);
	}

	public ITEMS_COLLECTION(int int_0, int[] indices)
	{
		SetItems(int_0, indices);
		(ItemsHashes = new HashSet<vITEMPOS>()).UnionWith(ItemsList);
		GC.KeepAlive(this);
	}

	public ITEMS_COLLECTION()
	{
		ItemsHashes = new HashSet<vITEMPOS>();
	}

	public int[] TryGetIndicesArray()
	{
		int[] result = TryGetIndices().ToArray();
		GC.KeepAlive(this);
		return result;
	}

	public List<int> TryGetIndices()
	{
		List<int> list = new List<int>(Count);
		int int32_ = GetListOfItems()[0].Int32_1;
		List<vITEMPOS>.Enumerator enumerator = ItemsList.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				ValueType valueType = enumerator.Current;
				if (((vITEMPOS)(object)valueType).Int32_1 == int32_)
				{
					list.Add(((vITEMPOS)(object)valueType).Int32_0);
				}
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
		return list;
	}

	public void AddItem(vITEMPOS item)
	{
		if (!ItemsHashes.Contains(item))
		{
			ItemsHashes.Add(item);
		}
		GC.KeepAlive(this);
	}

	public void AddItem(ITEMPOS item)
	{
		vITEMPOS item2 = new vITEMPOS(item);
		AddItem(item2);
		GC.KeepAlive(this);
	}

	public void SetItems(int int_0, int[] indices)
	{
		ItemsList = new List<vITEMPOS>(indices.Length);
		int num = 0;
		if (0 < (nint)indices.LongLength)
		{
			vITEMPOS item = default(vITEMPOS);
			do
			{
				int int32_ = indices[num];
				item.Int32_1 = int_0;
				item.Int32_0 = int32_;
				ItemsList.Add(item);
				num++;
			}
			while (num < (nint)indices.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void SetFields(int[] fields)
	{
		(FieldsHashes = new HashSet<int>()).UnionWith(fields);
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Contains(int id)
	{
		bool result = IDsHashes.Contains(id);
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Contains(vITEMPOS item)
	{
		bool result = ItemsHashes.Contains(item);
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ContainsItem(vITEMPOS item)
	{
		bool result = ItemsHashes.Contains(item);
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ContainsId(LISTandID item)
	{
		HashSet<LISTandID> listAndIdHashes = ListAndIdHashes;
		if (listAndIdHashes != null)
		{
			bool result = listAndIdHashes.Contains(item);
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return false;
	}

	public List<vITEMPOS> GetListOfItems()
	{
		if (ItemsList == null)
		{
			ItemsList = new List<vITEMPOS>(ItemsHashes);
		}
		return ItemsList;
	}

	public void ValidateValues()
	{
		HashSet<vITEMPOS> itemsHashes = ItemsHashes;
		if (itemsHashes != null && ItemsList == null)
		{
			ItemsList = new List<vITEMPOS>(itemsHashes);
		}
		else if (ItemsList != null && itemsHashes.Count == 0)
		{
			ItemsHashes.UnionWith(ItemsList);
		}
		GC.KeepAlive(this);
	}
}
