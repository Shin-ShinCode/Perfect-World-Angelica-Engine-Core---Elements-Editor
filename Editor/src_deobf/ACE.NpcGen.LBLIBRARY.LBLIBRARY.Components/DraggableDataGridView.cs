using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class DraggableDataGridView : DataGridView
{
	[Serializable]
	private sealed class Class252
	{
		public static readonly Class252 class252_0 = new Class252();

		public static Action<DataGridViewRow> action_0;

		internal void method_0(DataGridViewRow dataGridViewRow_0)
		{
			dataGridViewRow_0.Selected = true;
		}
	}

	private bool bool_0;

	private Rectangle rectangle_0 = Rectangle.Empty;

	public DraggableDataGridView()
	{
		AllowDrop = true;
		base.Tag = new Stopwatch();
	}

	protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs dataGridViewCellMouseEventArgs_0)
	{
		base.OnCellMouseDown(dataGridViewCellMouseEventArgs_0);
		if (dataGridViewCellMouseEventArgs_0.RowIndex < 0 || dataGridViewCellMouseEventArgs_0.Button != MouseButtons.Right)
		{
			return;
		}
		int index = base.CurrentRow.Index;
		List<DataGridViewRow> list = base.SelectedRows.OfType<DataGridViewRow>().ToList();
		bool selected = base.Rows[dataGridViewCellMouseEventArgs_0.RowIndex].Selected;
		base.CurrentCell = base.Rows[dataGridViewCellMouseEventArgs_0.RowIndex].Cells[dataGridViewCellMouseEventArgs_0.ColumnIndex];
		if ((Control.ModifierKeys & Keys.Control) != 0 || selected)
		{
			list.ForEach(Class252.class252_0.method_0);
		}
		if ((Control.ModifierKeys & Keys.Shift) != Keys.None)
		{
			for (int i = index; i != dataGridViewCellMouseEventArgs_0.RowIndex; i += Math.Sign(dataGridViewCellMouseEventArgs_0.RowIndex - index))
			{
				base.Rows[i].Selected = true;
			}
		}
	}

	protected override void OnDragOver(DragEventArgs drgevent)
	{
		base.OnDragOver(drgevent);
		drgevent.Effect = DragDropEffects.All;
	}

	protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
	{
		(base.Tag as Stopwatch).Start();
		int rowIndex = HitTest(mouseEventArgs_0.X, mouseEventArgs_0.Y).RowIndex;
		bool_0 = rowIndex >= 0 && (base.SelectedRows.Contains(base.Rows[rowIndex]) || (Control.ModifierKeys & Keys.Control) > Keys.None);
		if (!bool_0)
		{
			base.OnMouseDown(mouseEventArgs_0);
			if (rowIndex >= 0)
			{
				Size dragSize = SystemInformation.DragSize;
				rectangle_0 = new Rectangle(new Point(mouseEventArgs_0.X - dragSize.Width / 2, mouseEventArgs_0.Y - dragSize.Height / 2), dragSize);
			}
			else
			{
				rectangle_0 = Rectangle.Empty;
			}
		}
	}

	protected override void OnMouseMove(MouseEventArgs mea)
	{
		base.OnMouseMove(mea);
		Stopwatch stopwatch = base.Tag as Stopwatch;
		stopwatch.Stop();
		if (stopwatch.ElapsedMilliseconds > 75L)
		{
			DoDragDrop(base.SelectedRows, DragDropEffects.Move);
		}
		stopwatch.Reset();
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		Stopwatch stopwatch = base.Tag as Stopwatch;
		stopwatch.Stop();
		stopwatch.Reset();
		if (bool_0)
		{
			bool_0 = false;
			base.OnMouseDown(mevent);
		}
		base.OnMouseUp(mevent);
	}
}
