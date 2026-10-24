using System.Collections.Generic;

namespace ACE.PWMap;

public sealed class PwMapChangeLog
{
	private readonly List<PwMapChangeItem> list_0 = new List<PwMapChangeItem>();

	private int int_0;

	private int int_1;

	private readonly List<IPwMapChangeLogListener> list_1 = new List<IPwMapChangeLogListener>();

	public bool CanUndo => int_0 > 0;

	public bool CanRedo => int_0 < list_0.Count;

	public string UndoDescription
	{
		get
		{
			if (!CanUndo)
			{
				return string.Empty;
			}
			return list_0[int_0 - 1].Description;
		}
	}

	public string RedoDescription
	{
		get
		{
			if (!CanRedo)
			{
				return string.Empty;
			}
			return list_0[int_0].Description;
		}
	}

	public int UndoCount => int_0;

	public int RedoCount => list_0.Count - int_0;

	public PwMapChangeLog(int capacity = 200)
	{
		int_1 = capacity;
	}

	public void Push(PwMapChangeItem item)
	{
		if (item != null)
		{
			if (int_0 < list_0.Count)
			{
				list_0.RemoveRange(int_0, list_0.Count - int_0);
			}
			list_0.Add(item);
			int_0 = list_0.Count;
			while (list_0.Count > int_1 && int_1 > 0)
			{
				list_0.RemoveAt(0);
				int_0--;
			}
			method_0();
		}
	}

	public void Undo()
	{
		if (CanUndo)
		{
			int_0--;
			list_0[int_0].Revert();
			method_0();
		}
	}

	public void Redo()
	{
		if (CanRedo)
		{
			list_0[int_0].Apply();
			int_0++;
			method_0();
		}
	}

	public void Clear()
	{
		list_0.Clear();
		int_0 = 0;
		method_0();
	}

	public void AddListener(IPwMapChangeLogListener listener)
	{
		if (listener != null && !list_1.Contains(listener))
		{
			list_1.Add(listener);
		}
	}

	public void RemoveListener(IPwMapChangeLogListener listener)
	{
		list_1.Remove(listener);
	}

	private void method_0()
	{
		foreach (IPwMapChangeLogListener item in list_1)
		{
			item.OnChangeLogUpdated(this);
		}
	}
}
