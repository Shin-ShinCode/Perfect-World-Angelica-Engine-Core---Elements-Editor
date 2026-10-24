using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ACE.sTASKedit;

public class TaskDragDropEventArgs : EventArgs
{
	private readonly int int_0;

	private readonly int int_1;

	private readonly TreeNode treeNode_0;

	public int SourceIndex
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
	}

	public int TargetIndex
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
	}

	public TreeNode ParentNode
	{
		[CompilerGenerated]
		get
		{
			return treeNode_0;
		}
	}

	public TaskDragDropEventArgs(int sourceIndex, int targetIndex, TreeNode parentNode)
	{
		int_0 = sourceIndex;
		int_1 = targetIndex;
		treeNode_0 = parentNode;
	}
}
