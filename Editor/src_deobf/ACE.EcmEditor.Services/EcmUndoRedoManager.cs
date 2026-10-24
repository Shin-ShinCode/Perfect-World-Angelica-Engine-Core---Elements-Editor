using System.Collections.Generic;

namespace ACE.EcmEditor.Services;

public class EcmUndoRedoManager
{
	private readonly Dictionary<string, Stack<string>> dictionary_0 = new Dictionary<string, Stack<string>>();

	private readonly Dictionary<string, Stack<string>> dictionary_1 = new Dictionary<string, Stack<string>>();

	private readonly int int_0;

	public EcmUndoRedoManager(int maxStackSize = 100)
	{
		int_0 = maxStackSize;
	}

	private void method_0(string string_0)
	{
		if (!dictionary_0.ContainsKey(string_0))
		{
			dictionary_0[string_0] = new Stack<string>();
		}
		if (!dictionary_1.ContainsKey(string_0))
		{
			dictionary_1[string_0] = new Stack<string>();
		}
	}

	public void PushState(string filePath, string content)
	{
		method_0(filePath);
		if (dictionary_0[filePath].Count <= 0 || !(dictionary_0[filePath].Peek() == content))
		{
			dictionary_0[filePath].Push(content);
			if (dictionary_0[filePath].Count > int_0)
			{
				List<string> list = new List<string>(dictionary_0[filePath]);
				list.RemoveAt(list.Count - 1);
				dictionary_0[filePath] = new Stack<string>(list);
			}
			dictionary_1[filePath].Clear();
		}
	}

	public string Undo(string filePath, string currentContent)
	{
		method_0(filePath);
		if (dictionary_0[filePath].Count == 0)
		{
			return null;
		}
		dictionary_1[filePath].Push(currentContent);
		return dictionary_0[filePath].Pop();
	}

	public string Redo(string filePath, string currentContent)
	{
		method_0(filePath);
		if (dictionary_1[filePath].Count == 0)
		{
			return null;
		}
		dictionary_0[filePath].Push(currentContent);
		return dictionary_1[filePath].Pop();
	}

	public bool CanUndo(string filePath)
	{
		method_0(filePath);
		return dictionary_0[filePath].Count > 0;
	}

	public bool CanRedo(string filePath)
	{
		method_0(filePath);
		return dictionary_1[filePath].Count > 0;
	}

	public void Clear(string filePath)
	{
		if (dictionary_0.ContainsKey(filePath))
		{
			dictionary_0[filePath].Clear();
		}
		if (dictionary_1.ContainsKey(filePath))
		{
			dictionary_1[filePath].Clear();
		}
	}

	public void ClearAll()
	{
		dictionary_0.Clear();
		dictionary_1.Clear();
	}
}
