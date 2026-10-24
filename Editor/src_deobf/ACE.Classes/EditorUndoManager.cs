using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ACE.Properties;

namespace ACE.Classes;

public class EditorUndoManager<T> where T : class
{
	private sealed class Class68
	{
		public Func<T> func_0;

		public EditorUndoManager<T> editorUndoManager_0;

		public Action<T> action_0;

		internal void method_0(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.Z && !e.Shift)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				T currentState = func_0();
				T val = editorUndoManager_0.Undo(currentState);
				if (val != null)
				{
					action_0(val);
				}
			}
			else if (e.Control && (e.KeyCode == Keys.Y || (e.KeyCode == Keys.Z && e.Shift)))
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				T currentState2 = func_0();
				T val2 = editorUndoManager_0.Redo(currentState2);
				if (val2 != null)
				{
					action_0(val2);
				}
			}
		}
	}

	private readonly Stack<T> stack_0 = new Stack<T>();

	private readonly Stack<T> stack_1 = new Stack<T>();

	private readonly int int_0;

	private Action action_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	public bool CanUndo => stack_0.Count > 0;

	public bool CanRedo => stack_1.Count > 0;

	public int UndoCount => stack_0.Count;

	public int RedoCount => stack_1.Count;

	public EditorUndoManager(int maxHistory = 100)
	{
		int_0 = maxHistory;
	}

	public void SetStateChangedCallback(Action callback)
	{
		action_0 = callback;
	}

	public void PushUndo(T snapshot)
	{
		if (snapshot == null)
		{
			return;
		}
		if (stack_0.Count >= int_0)
		{
			T[] array = stack_0.ToArray();
			stack_0.Clear();
			for (int num = array.Length - 2; num >= 0; num--)
			{
				stack_0.Push(array[num]);
			}
		}
		stack_0.Push(snapshot);
		stack_1.Clear();
		action_0?.Invoke();
	}

	public T Undo(T currentState)
	{
		if (!CanUndo)
		{
			return null;
		}
		if (currentState != null)
		{
			stack_1.Push(currentState);
		}
		T result = stack_0.Pop();
		action_0?.Invoke();
		return result;
	}

	public T Redo(T currentState)
	{
		if (!CanRedo)
		{
			return null;
		}
		if (currentState != null)
		{
			stack_0.Push(currentState);
		}
		T result = stack_1.Pop();
		action_0?.Invoke();
		return result;
	}

	public void Clear()
	{
		stack_0.Clear();
		stack_1.Clear();
		action_0?.Invoke();
	}

	public void AttachToToolStrip(ToolStrip strip, EventHandler undoHandler, EventHandler redoHandler)
	{
		if (strip != null)
		{
			if (strip.Items[Class16.smethod_0(1648903445)] is ToolStripButton toolStripButton && strip.Items[Class16.smethod_0(1648903458)] is ToolStripButton toolStripButton2)
			{
				toolStripButton_0 = toolStripButton;
				toolStripButton_1 = toolStripButton2;
				action_0 = (Action)Delegate.Remove(action_0, new Action(method_0));
				action_0 = (Action)Delegate.Combine(action_0, new Action(method_0));
				method_0();
				return;
			}
			ToolStripButton toolStripButton3 = new ToolStripButton
			{
				Text = Class16.smethod_0(1648903487),
				ToolTipText = Class16.smethod_0(1648933841),
				DisplayStyle = ToolStripItemDisplayStyle.Image,
				Image = Resources.GShopEditor_PW_mbUndo,
				ImageTransparentColor = Color.Magenta,
				Enabled = false,
				Name = Class16.smethod_0(1648903445)
			};
			ToolStripButton toolStripButton4 = new ToolStripButton
			{
				Text = Class16.smethod_0(1648903490),
				ToolTipText = Class16.smethod_0(1648933869),
				DisplayStyle = ToolStripItemDisplayStyle.Image,
				Image = Resources.GShopEditor_PW_mbRedo,
				ImageTransparentColor = Color.Magenta,
				Enabled = false,
				Name = Class16.smethod_0(1648903458)
			};
			toolStripButton3.Click += undoHandler;
			toolStripButton4.Click += redoHandler;
			strip.Items.Insert(0, new ToolStripSeparator());
			strip.Items.Insert(0, toolStripButton4);
			strip.Items.Insert(0, toolStripButton3);
			toolStripButton_0 = toolStripButton3;
			toolStripButton_1 = toolStripButton4;
			action_0 = (Action)Delegate.Remove(action_0, new Action(method_0));
			action_0 = (Action)Delegate.Combine(action_0, new Action(method_0));
			method_0();
		}
	}

	private void method_0()
	{
		if (toolStripButton_0 != null)
		{
			toolStripButton_0.Enabled = CanUndo;
		}
		if (toolStripButton_1 != null)
		{
			toolStripButton_1.Enabled = CanRedo;
		}
	}

	public void AttachKeyboardShortcuts(Form form, Func<T> captureState, Action<T> restoreState)
	{
		Class68 @class = new Class68();
		@class.func_0 = captureState;
		@class.editorUndoManager_0 = this;
		@class.action_0 = restoreState;
		form.KeyPreview = true;
		form.KeyDown += @class.method_0;
	}
}
