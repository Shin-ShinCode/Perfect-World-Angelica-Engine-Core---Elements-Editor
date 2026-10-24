using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.tasks;

public static class MethodExtensions
{
	[Serializable]
	private sealed class Class421
	{
		public static readonly Class421 class421_0 = new Class421();

		public static Func<ConcurrentBag<ATaskTempl>, ATaskTempl, ConcurrentBag<ATaskTempl>> func_0;

		public static Func<List<ATaskTempl>, ATaskTempl, List<ATaskTempl>> func_1;

		internal ConcurrentBag<ATaskTempl> method_0(ConcurrentBag<ATaskTempl> concurrentBag_0, ATaskTempl ataskTempl_0)
		{
			concurrentBag_0.Add(ataskTempl_0);
			if (ataskTempl_0.pSub != null && ataskTempl_0.pSub.Length != 0)
			{
				foreach (ATaskTempl allTask in ataskTempl_0.pSub.GetAllTasks())
				{
					concurrentBag_0.Add(allTask);
				}
			}
			return concurrentBag_0;
		}

		internal List<ATaskTempl> method_1(List<ATaskTempl> list_0, ATaskTempl ataskTempl_0)
		{
			list_0.Add(ataskTempl_0);
			if (ataskTempl_0.pSub != null && ataskTempl_0.pSub.Length != 0)
			{
				list_0.AddRange(ataskTempl_0.pSub.GetAllTasks());
			}
			return list_0;
		}
	}

	public static T[] Resize<T>(this T[] array, int newSize)
	{
		Array.Resize(ref array, newSize);
		return array;
	}

	public static ParallelQuery<ATaskTempl> GetAllTasks(this ParallelQuery<ATaskTempl> parallelQuery_0)
	{
		return parallelQuery_0.Aggregate(new ConcurrentBag<ATaskTempl>(), Class421.class421_0.method_0).AsParallel();
	}

	public static IEnumerable<ATaskTempl> GetAllTasks(this IEnumerable<ATaskTempl> tasks)
	{
		return tasks.Aggregate(new List<ATaskTempl>(), Class421.class421_0.method_1);
	}
}
