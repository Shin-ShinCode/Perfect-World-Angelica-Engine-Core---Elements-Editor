using System.Collections.Generic;

namespace ACE.Dependency.zlibnet;

public static class ListHelper
{
	public static void Add<T>(this List<T> list, params T[] items)
	{
		foreach (T item in items)
		{
			list.Add(item);
		}
	}

	public static void AddRange<T>(this List<T> list, IEnumerable<T> items)
	{
		foreach (T item in items)
		{
			list.Add(item);
		}
	}
}
