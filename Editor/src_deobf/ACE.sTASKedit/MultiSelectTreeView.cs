using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ACE.Classes;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit;

public class MultiSelectTreeView : TreeView
{
	private sealed class Class418 : IEnumerable, IEnumerator, IDisposable, IEnumerable<TreeNode>, IEnumerator<TreeNode>
	{
		private int int_0;

		private TreeNode treeNode_0;

		private int int_1;

		private IEnumerable<TreeNode> ienumerable_0;

		public IEnumerable<TreeNode> ienumerable_1;

		public MultiSelectTreeView multiSelectTreeView_0;

		private IEnumerator<TreeNode> ienumerator_0;

		private TreeNode treeNode_1;

		private IEnumerator<TreeNode> ienumerator_1;

		TreeNode IEnumerator<TreeNode>.Current
		{
			[DebuggerHidden]
			get
			{
				return treeNode_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return treeNode_0;
			}
		}

		[DebuggerHidden]
		public Class418(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = int_0;
			if ((uint)(num - -4) <= 1u || (uint)(num - 1) <= 1u)
			{
				try
				{
					if (num == -4 || num == 2)
					{
						try
						{
						}
						finally
						{
							method_1();
						}
					}
				}
				finally
				{
					method_0();
				}
			}
			ienumerator_0 = null;
			treeNode_1 = null;
			ienumerator_1 = null;
			int_0 = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = int_0;
				MultiSelectTreeView multiSelectTreeView = multiSelectTreeView_0;
				TreeNode current;
				switch (num)
				{
				default:
					return false;
				case 0:
					int_0 = -1;
					ienumerator_0 = ienumerable_0.GetEnumerator();
					int_0 = -3;
					goto IL_00a5;
				case 1:
					int_0 = -3;
					ienumerator_1 = multiSelectTreeView.method_3(treeNode_1.Nodes.Cast<TreeNode>()).GetEnumerator();
					int_0 = -4;
					goto IL_0084;
				case 2:
					{
						int_0 = -4;
						goto IL_0084;
					}
					IL_0084:
					if (!ienumerator_1.MoveNext())
					{
						method_1();
						ienumerator_1 = null;
						treeNode_1 = null;
						goto IL_00a5;
					}
					current = ienumerator_1.Current;
					treeNode_0 = current;
					int_0 = 2;
					return true;
					IL_00a5:
					if (!ienumerator_0.MoveNext())
					{
						method_0();
						ienumerator_0 = null;
						return false;
					}
					treeNode_1 = ienumerator_0.Current;
					treeNode_0 = treeNode_1;
					int_0 = 1;
					return true;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void method_0()
		{
			int_0 = -1;
			if (ienumerator_0 != null)
			{
				ienumerator_0.Dispose();
			}
		}

		private void method_1()
		{
			int_0 = -3;
			if (ienumerator_1 != null)
			{
				ienumerator_1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<TreeNode> IEnumerable<TreeNode>.GetEnumerator()
		{
			Class418 @class;
			if (int_0 == -2 && int_1 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class418(0);
				@class.multiSelectTreeView_0 = multiSelectTreeView_0;
			}
			@class.ienumerable_0 = ienumerable_1;
			return @class;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<TreeNode>)this).GetEnumerator();
		}
	}

	private sealed class Class419
	{
		public List<TreeNode> list_0;

		public int int_0;

		public int int_1;

		public MultiSelectTreeView multiSelectTreeView_0;

		internal bool method_0(TreeNode treeNode_0)
		{
			int num = list_0.IndexOf(treeNode_0);
			if (num != -1 && (num < int_0 || num > int_1))
			{
				return treeNode_0 != multiSelectTreeView_0.treeNode_0;
			}
			return false;
		}
	}

	private readonly List<TreeNode> list_0 = new List<TreeNode>();

	private readonly Dictionary<TreeNode, Color> dictionary_0 = new Dictionary<TreeNode, Color>();

	private readonly Dictionary<TreeNode, Color> dictionary_1 = new Dictionary<TreeNode, Color>();

	private bool bool_0 = true;

	private bool bool_1;

	private TreeNode treeNode_0;

	private TreeNode treeNode_1;

	private bool bool_2;

	private EventHandler<TaskDragDropEventArgs> eventHandler_0;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool MultiSelectEnabled
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public List<TreeNode> SelectedNodes => list_0.ToList();

	public event EventHandler<TaskDragDropEventArgs> TaskDragDropRequested
	{
		[CompilerGenerated]
		add
		{
			EventHandler<TaskDragDropEventArgs> eventHandler = eventHandler_0;
			EventHandler<TaskDragDropEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TaskDragDropEventArgs> value2 = (EventHandler<TaskDragDropEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<TaskDragDropEventArgs> eventHandler = eventHandler_0;
			EventHandler<TaskDragDropEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TaskDragDropEventArgs> value2 = (EventHandler<TaskDragDropEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public MultiSelectTreeView()
	{
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		base.DrawMode = TreeViewDrawMode.Normal;
	}

	[DllImport("user32.dll")]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

	protected override void OnHandleCreated(EventArgs eventArgs_0)
	{
		base.OnHandleCreated(eventArgs_0);
		SendMessage(base.Handle, 4396, (IntPtr)4, (IntPtr)4);
		TDark.SetControlDarkExplorerTheme(this);
	}

	public void BeginBulkUpdate()
	{
		if (!base.IsDisposed && !base.Disposing)
		{
			bool_1 = true;
			base.DrawMode = TreeViewDrawMode.Normal;
			try
			{
				BeginUpdate();
			}
			catch (ObjectDisposedException)
			{
				bool_1 = false;
			}
		}
	}

	public void EndBulkUpdate()
	{
		bool_1 = false;
		if (base.IsDisposed || base.Disposing)
		{
			return;
		}
		try
		{
			if (base.IsHandleCreated)
			{
				EndUpdate();
			}
			base.DrawMode = TreeViewDrawMode.OwnerDrawText;
			Invalidate();
		}
		catch (ObjectDisposedException)
		{
		}
		catch (InvalidOperationException)
		{
		}
	}

	public void ClearSelectedNodes()
	{
		if (list_0.Count == 0)
		{
			return;
		}
		foreach (TreeNode item in list_0)
		{
			method_5(item);
		}
		list_0.Clear();
		method_0();
		treeNode_0 = null;
		if (!bool_1)
		{
			Invalidate();
		}
	}

	private void method_0()
	{
		List<TreeNode> list = new List<TreeNode>();
		foreach (TreeNode key in dictionary_0.Keys)
		{
			if (key.TreeView == null || method_1(key))
			{
				list.Add(key);
			}
		}
		foreach (TreeNode item in list)
		{
			dictionary_0.Remove(item);
			dictionary_1.Remove(item);
		}
	}

	private bool method_1(TreeNode treeNode_2)
	{
		try
		{
			_ = treeNode_2.Text;
			TreeView treeView = treeNode_2.TreeView;
			return treeView != this;
		}
		catch
		{
			return true;
		}
	}

	public void SetSelectedNodes(IEnumerable<TreeNode> nodes)
	{
		list_0.Clear();
		list_0.AddRange(nodes);
	}

	public void SelectNode(TreeNode node, bool extend = false)
	{
		if (node == null)
		{
			return;
		}
		if (!extend || !bool_0)
		{
			ClearSelectedNodes();
			treeNode_0 = node;
		}
		if (!list_0.Contains(node))
		{
			list_0.Add(node);
			if (!bool_1)
			{
				method_4(node);
			}
			if (treeNode_0 == null)
			{
				treeNode_0 = node;
			}
		}
		else if (extend && bool_0)
		{
			list_0.Remove(node);
			if (!bool_1)
			{
				method_5(node);
			}
		}
		base.SelectedNode = node;
		if (!bool_1)
		{
			Invalidate();
		}
	}

	public void SelectRange(TreeNode fromNode, TreeNode toNode)
	{
		Class419 @class = new Class419();
		@class.multiSelectTreeView_0 = this;
		if (fromNode == null || toNode == null)
		{
			return;
		}
		@class.list_0 = method_2().ToList();
		@class.int_0 = @class.list_0.IndexOf(fromNode);
		@class.int_1 = @class.list_0.IndexOf(toNode);
		if (@class.int_0 == -1 || @class.int_1 == -1)
		{
			return;
		}
		if (@class.int_0 > @class.int_1)
		{
			int int_ = @class.int_1;
			int int_2 = @class.int_0;
			@class.int_1 = int_2;
			@class.int_0 = int_;
		}
		List<TreeNode> list = list_0.Where(@class.method_0).ToList();
		foreach (TreeNode item in list)
		{
			list_0.Remove(item);
			method_5(item);
		}
		for (int i = @class.int_0; i <= @class.int_1; i++)
		{
			if (!list_0.Contains(@class.list_0[i]))
			{
				list_0.Add(@class.list_0[i]);
				method_4(@class.list_0[i]);
			}
		}
		base.SelectedNode = toNode;
		Invalidate();
	}

	private IEnumerable<TreeNode> method_2()
	{
		return method_3(base.Nodes.Cast<TreeNode>());
	}

	private IEnumerable<TreeNode> method_3(IEnumerable<TreeNode> ienumerable_0)
	{
		return new Class418(-2)
		{
			multiSelectTreeView_0 = this,
			ienumerable_1 = ienumerable_0
		};
	}

	private void method_4(TreeNode treeNode_2)
	{
		if (!dictionary_0.ContainsKey(treeNode_2))
		{
			dictionary_0[treeNode_2] = treeNode_2.BackColor;
			dictionary_1[treeNode_2] = treeNode_2.ForeColor;
		}
		treeNode_2.BackColor = Color.FromArgb(64, 64, 128);
		treeNode_2.ForeColor = Color.White;
	}

	private void method_5(TreeNode treeNode_2)
	{
		if (dictionary_0.ContainsKey(treeNode_2))
		{
			treeNode_2.BackColor = dictionary_0[treeNode_2];
			treeNode_2.ForeColor = dictionary_1[treeNode_2];
			dictionary_0.Remove(treeNode_2);
			dictionary_1.Remove(treeNode_2);
		}
		else
		{
			treeNode_2.BackColor = BackColor;
			treeNode_2.ForeColor = ForeColor;
		}
	}

	protected override void OnDrawNode(DrawTreeNodeEventArgs drawTreeNodeEventArgs_0)
	{
		if (bool_1)
		{
			drawTreeNodeEventArgs_0.DrawDefault = true;
			base.OnDrawNode(drawTreeNodeEventArgs_0);
			return;
		}
		if (list_0.Contains(drawTreeNodeEventArgs_0.Node))
		{
			Brush brush = new SolidBrush(Color.FromArgb(64, 64, 128));
			try
			{
				drawTreeNodeEventArgs_0.Graphics.FillRectangle(brush, drawTreeNodeEventArgs_0.Bounds);
			}
			finally
			{
				((IDisposable)brush).Dispose();
			}
			Brush brush2 = new SolidBrush(Color.White);
			try
			{
				drawTreeNodeEventArgs_0.Graphics.DrawString(drawTreeNodeEventArgs_0.Node.Text, drawTreeNodeEventArgs_0.Node.TreeView.Font, brush2, drawTreeNodeEventArgs_0.Bounds.Left + 2, drawTreeNodeEventArgs_0.Bounds.Top + 1);
			}
			finally
			{
				((IDisposable)brush2).Dispose();
			}
			drawTreeNodeEventArgs_0.DrawDefault = false;
		}
		else
		{
			Color backColor = BackColor;
			Color foreColor = ForeColor;
			if (drawTreeNodeEventArgs_0.Node.BackColor != BackColor && drawTreeNodeEventArgs_0.Node.BackColor.ToArgb() != Color.FromArgb(64, 64, 128).ToArgb())
			{
				backColor = drawTreeNodeEventArgs_0.Node.BackColor;
			}
			if (drawTreeNodeEventArgs_0.Node.ForeColor != ForeColor && drawTreeNodeEventArgs_0.Node.ForeColor != Color.White)
			{
				foreColor = drawTreeNodeEventArgs_0.Node.ForeColor;
			}
			Brush brush3 = new SolidBrush(backColor);
			try
			{
				drawTreeNodeEventArgs_0.Graphics.FillRectangle(brush3, drawTreeNodeEventArgs_0.Bounds);
			}
			finally
			{
				((IDisposable)brush3).Dispose();
			}
			Brush brush4 = new SolidBrush(foreColor);
			try
			{
				drawTreeNodeEventArgs_0.Graphics.DrawString(drawTreeNodeEventArgs_0.Node.Text, drawTreeNodeEventArgs_0.Node.TreeView.Font, brush4, drawTreeNodeEventArgs_0.Bounds.Left + 2, drawTreeNodeEventArgs_0.Bounds.Top + 1);
			}
			finally
			{
				((IDisposable)brush4).Dispose();
			}
			drawTreeNodeEventArgs_0.DrawDefault = false;
		}
		base.OnDrawNode(drawTreeNodeEventArgs_0);
	}

	protected override void OnPaint(PaintEventArgs paintEventArgs_0)
	{
		if (base.DrawMode != TreeViewDrawMode.OwnerDrawText)
		{
			base.DrawMode = TreeViewDrawMode.OwnerDrawText;
		}
		base.OnPaint(paintEventArgs_0);
	}

	protected override void WndProc(ref Message message_0)
	{
		if (message_0.Msg == 20)
		{
			message_0.Result = IntPtr.Zero;
		}
		else
		{
			base.WndProc(ref message_0);
		}
	}

	protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
	{
		if (!bool_0)
		{
			base.OnMouseDown(mouseEventArgs_0);
			return;
		}
		TreeNode nodeAt = GetNodeAt(mouseEventArgs_0.Location);
		if (nodeAt == null)
		{
			base.OnMouseDown(mouseEventArgs_0);
			return;
		}
		if (mouseEventArgs_0.Button == MouseButtons.Right)
		{
			if (list_0.Contains(nodeAt))
			{
				base.SelectedNode = nodeAt;
				base.OnMouseDown(mouseEventArgs_0);
			}
			else
			{
				SelectNode(nodeAt);
				base.OnMouseDown(mouseEventArgs_0);
			}
			return;
		}
		bool flag = (Control.ModifierKeys & Keys.Control) == Keys.Control;
		if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && treeNode_0 != null)
		{
			SelectRange(treeNode_0, nodeAt);
		}
		else if (flag)
		{
			SelectNode(nodeAt, extend: true);
		}
		else
		{
			SelectNode(nodeAt);
		}
		base.OnMouseDown(mouseEventArgs_0);
	}

	protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
	{
		if (bool_0 && keyEventArgs_0.Control && keyEventArgs_0.KeyCode == Keys.A)
		{
			ClearSelectedNodes();
			foreach (TreeNode item in method_2())
			{
				list_0.Add(item);
				method_4(item);
			}
			keyEventArgs_0.Handled = true;
		}
		else
		{
			base.OnKeyDown(keyEventArgs_0);
		}
	}

	protected override void OnAfterSelect(TreeViewEventArgs treeViewEventArgs_0)
	{
		if (!bool_0 || list_0.Count <= 1)
		{
			base.OnAfterSelect(treeViewEventArgs_0);
		}
	}

	public List<ATaskTempl> GetSelectedTasks()
	{
		List<ATaskTempl> list = new List<ATaskTempl>();
		foreach (TreeNode item in list_0)
		{
			try
			{
				List<int> list2 = new List<int>();
				TreeNode treeNode = item;
				while (treeNode.Parent != null)
				{
					list2.Add(treeNode.Index);
					treeNode = treeNode.Parent;
				}
				ATaskTempl aTaskTempl = GProD.Tasks[treeNode.Index];
				for (int num = list2.Count - 1; num >= 0; num--)
				{
					aTaskTempl = aTaskTempl.pSub[list2[num]];
				}
				list.Add(aTaskTempl);
			}
			catch
			{
			}
		}
		return list;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			dictionary_0.Clear();
			dictionary_1.Clear();
			list_0.Clear();
		}
		base.Dispose(disposing);
	}

	public void ResetState()
	{
		ClearSelectedNodes();
		method_0();
		treeNode_0 = null;
		CleanNewlyAddedNodes();
		method_6();
		method_7();
	}

	private void method_6()
	{
		foreach (TreeNode item in method_2())
		{
			if (item.BackColor.ToArgb() == Color.FromArgb(64, 64, 128).ToArgb())
			{
				item.BackColor = BackColor;
			}
			if (item.ForeColor == Color.White && !list_0.Contains(item))
			{
				item.ForeColor = ForeColor;
			}
		}
	}

	private void method_7()
	{
		base.DrawMode = TreeViewDrawMode.Normal;
		Invalidate();
		Update();
		base.DrawMode = TreeViewDrawMode.OwnerDrawText;
		Invalidate();
	}

	public void CleanNewlyAddedNodes()
	{
		foreach (TreeNode item in method_2())
		{
			if (list_0.Contains(item))
			{
				continue;
			}
			if (item.BackColor.ToArgb() == Color.FromArgb(64, 64, 128).ToArgb())
			{
				if (dictionary_0.ContainsKey(item))
				{
					item.BackColor = dictionary_0[item];
				}
				else
				{
					item.BackColor = BackColor;
				}
			}
			if (item.ForeColor == Color.White)
			{
				if (dictionary_1.ContainsKey(item) && dictionary_1[item] != Color.White)
				{
					item.ForeColor = dictionary_1[item];
				}
				else if (!dictionary_1.ContainsKey(item))
				{
					item.ForeColor = ForeColor;
				}
			}
		}
		Invalidate();
	}

	public void FixClonedNodeColors()
	{
		TreeViewDrawMode treeViewDrawMode = base.DrawMode;
		base.DrawMode = TreeViewDrawMode.Normal;
		foreach (TreeNode item in method_2())
		{
			if (!list_0.Contains(item))
			{
				if (item.BackColor.ToArgb() == Color.FromArgb(64, 64, 128).ToArgb())
				{
					item.BackColor = BackColor;
				}
				if (item.ForeColor == Color.White)
				{
					item.ForeColor = ForeColor;
				}
			}
		}
		Refresh();
		base.DrawMode = treeViewDrawMode;
		Invalidate();
	}

	protected override void OnItemDrag(ItemDragEventArgs itemDragEventArgs_0)
	{
		if (itemDragEventArgs_0.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Control) == Keys.Control)
		{
			treeNode_1 = itemDragEventArgs_0.Item as TreeNode;
			if (treeNode_1 != null)
			{
				bool_2 = true;
				DoDragDrop(treeNode_1, DragDropEffects.Move);
			}
		}
		else
		{
			base.OnItemDrag(itemDragEventArgs_0);
		}
	}

	protected override void OnDragOver(DragEventArgs drgevent)
	{
		if (bool_2 && treeNode_1 != null)
		{
			Point pt = PointToClient(new Point(drgevent.X, drgevent.Y));
			TreeNode nodeAt = GetNodeAt(pt);
			if (nodeAt != null && nodeAt != treeNode_1 && !method_8(nodeAt, treeNode_1))
			{
				bool flag = treeNode_1.Parent == nodeAt.Parent;
				drgevent.Effect = (flag ? DragDropEffects.Move : DragDropEffects.None);
			}
			else
			{
				drgevent.Effect = DragDropEffects.None;
			}
			base.OnDragOver(drgevent);
		}
		else
		{
			drgevent.Effect = DragDropEffects.None;
			base.OnDragOver(drgevent);
		}
	}

	protected override void OnDragDrop(DragEventArgs drgevent)
	{
		if (bool_2 && treeNode_1 != null)
		{
			Point pt = PointToClient(new Point(drgevent.X, drgevent.Y));
			TreeNode nodeAt = GetNodeAt(pt);
			if (nodeAt != null && nodeAt != treeNode_1 && treeNode_1.Parent == nodeAt.Parent)
			{
				int index = treeNode_1.Index;
				int index2 = nodeAt.Index;
				eventHandler_0?.Invoke(this, new TaskDragDropEventArgs(index, index2, treeNode_1.Parent));
			}
			bool_2 = false;
			treeNode_1 = null;
			base.OnDragDrop(drgevent);
		}
		else
		{
			bool_2 = false;
			treeNode_1 = null;
			base.OnDragDrop(drgevent);
		}
	}

	protected override void OnDragLeave(EventArgs eventArgs_0)
	{
		bool_2 = false;
		treeNode_1 = null;
		base.OnDragLeave(eventArgs_0);
	}

	private bool method_8(TreeNode treeNode_2, TreeNode treeNode_3)
	{
		TreeNode treeNode = treeNode_2.Parent;
		while (true)
		{
			if (treeNode != null)
			{
				if (treeNode == treeNode_3)
				{
					break;
				}
				treeNode = treeNode.Parent;
				continue;
			}
			return false;
		}
		return true;
	}
}
