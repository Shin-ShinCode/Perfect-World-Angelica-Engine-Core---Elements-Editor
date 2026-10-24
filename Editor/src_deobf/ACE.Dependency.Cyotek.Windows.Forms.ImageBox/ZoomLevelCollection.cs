using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Dependency.Cyotek.Windows.Forms.ImageBox;

public class ZoomLevelCollection : IEnumerable<int>, IEnumerable, IList<int>, ICollection<int>
{
	private SortedList<int, int> sortedList_0;

	public static ZoomLevelCollection Default => new ZoomLevelCollection(new int[19]
	{
		7, 10, 15, 20, 25, 30, 50, 70, 100, 150,
		200, 300, 400, 500, 600, 700, 800, 1200, 1600
	});

	public int Count => List.Count;

	public bool IsReadOnly => false;

	public int this[int index]
	{
		get
		{
			return List.Values[index];
		}
		set
		{
			List.RemoveAt(index);
			Add(value);
		}
	}

	protected SortedList<int, int> List
	{
		[CompilerGenerated]
		get
		{
			return sortedList_0;
		}
		[CompilerGenerated]
		set
		{
			sortedList_0 = value;
		}
	}

	public ZoomLevelCollection()
	{
		List = new SortedList<int, int>();
	}

	public ZoomLevelCollection(IEnumerable<int> collection)
		: this()
	{
		if (collection == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1648892424));
		}
		AddRange(collection);
	}

	public void Add(int item)
	{
		List.Add(item, item);
	}

	public void AddRange(IEnumerable<int> collection)
	{
		if (collection == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1648892435));
		}
		foreach (int item in collection)
		{
			Add(item);
		}
	}

	public void Clear()
	{
		List.Clear();
	}

	public bool Contains(int item)
	{
		return List.ContainsKey(item);
	}

	public void CopyTo(int[] array, int arrayIndex)
	{
		for (int i = 0; i < Count; i++)
		{
			array[arrayIndex + i] = List.Values[i];
		}
	}

	public int FindNearest(int zoomLevel)
	{
		int num = List.Values[0];
		int num2 = Math.Abs(num - zoomLevel);
		for (int i = 1; i < Count; i++)
		{
			int num3 = List.Values[i];
			int num4 = Math.Abs(num3 - zoomLevel);
			if (num4 < num2)
			{
				num = num3;
				num2 = num4;
			}
		}
		return num;
	}

	public IEnumerator<int> GetEnumerator()
	{
		return List.Values.GetEnumerator();
	}

	public int IndexOf(int item)
	{
		return List.IndexOfKey(item);
	}

	public void Insert(int index, int item)
	{
		throw new NotImplementedException();
	}

	public int NextZoom(int zoomLevel)
	{
		int num = IndexOf(FindNearest(zoomLevel));
		if (num < Count - 1)
		{
			num++;
		}
		return this[num];
	}

	public int PreviousZoom(int zoomLevel)
	{
		int num = IndexOf(FindNearest(zoomLevel));
		if (num > 0)
		{
			num--;
		}
		return this[num];
	}

	public bool Remove(int item)
	{
		return List.Remove(item);
	}

	public void RemoveAt(int index)
	{
		List.RemoveAt(index);
	}

	public int[] ToArray()
	{
		int[] array = new int[Count];
		CopyTo(array, 0);
		return array;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
