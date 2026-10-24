using System;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;
using ACE.Classes;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes;

internal class TaskToolTip
{
	public static int MaxSaveVersionForACE = 241;

	private static bool bool_0 = false;

	public static void ShowTaskHint(object sender, ATaskTempl ataskTempl_0, int task_id)
	{
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		try
		{
			Control control = sender as Control;
			int num = GlobalData.version;
			if (num > MaxSaveVersionForACE)
			{
				num = MaxSaveVersionForACE;
			}
			if (ataskTempl_0 == null)
			{
				TASKS_HINT.ToolTipWindow?.Hide();
			}
			else if (control != null && !control.IsDisposed)
			{
				TASKS_HINT.ShowTaskToolTip(control, ataskTempl_0, num, null);
			}
		}
		finally
		{
			bool_0 = false;
		}
	}

	public static void SetTaskToolTip_treeView_tasks(ToolTip toolTip_0, object sender, MouseEventArgs mouseEventArgs_0)
	{
		try
		{
			if (!(sender is TreeView treeView))
			{
				ShowTaskHint(null, null, 0);
				return;
			}
			TreeNode nodeAt = treeView.GetNodeAt(mouseEventArgs_0.X, mouseEventArgs_0.Y);
			if (nodeAt != null && Settings.Fields.EnableShowInfo && ACE.sTASKedit.MainEditor.MainEditor.LoadedTask && GProD.Tasks != null)
			{
				ArrayList arrayList = new ArrayList();
				ATaskTempl aTaskTempl = null;
				TreeNode treeNode = nodeAt;
				while (treeNode.Parent != null)
				{
					arrayList.Add(treeNode.Index);
					treeNode = treeNode.Parent;
				}
				if (treeNode.Index >= 0 && treeNode.Index < GProD.Tasks.Length)
				{
					aTaskTempl = GProD.Tasks[treeNode.Index];
					int num = arrayList.Count - 1;
					while (num >= 0)
					{
						int num2 = (int)arrayList[num];
						if (aTaskTempl?.pSub != null && num2 >= 0 && num2 < aTaskTempl.pSub.Length)
						{
							aTaskTempl = aTaskTempl.pSub[num2];
							num--;
							continue;
						}
						aTaskTempl = null;
						break;
					}
					toolTip_0?.Hide(treeView);
					if (aTaskTempl != null)
					{
						ShowTaskHint(sender, aTaskTempl, aTaskTempl.m_ID);
					}
					else
					{
						ShowTaskHint(null, null, 0);
					}
				}
				else
				{
					toolTip_0?.Hide(treeView);
					ShowTaskHint(null, null, 0);
				}
			}
			else
			{
				toolTip_0?.Hide(treeView);
				ShowTaskHint(null, null, 0);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649257183));
			if (sender is Control win)
			{
				toolTip_0?.Hide(win);
			}
			ShowTaskHint(null, null, 0);
		}
	}

	public static void SetTaskToolTip_dataGridView_ExtendedSearchResult(ToolTip toolTip_0, object sender, DataGridViewCellMouseEventArgs dataGridViewCellMouseEventArgs_0)
	{
		if (!(sender is DataGridView dataGridView))
		{
			return;
		}
		if (dataGridViewCellMouseEventArgs_0.RowIndex > -1 && dataGridViewCellMouseEventArgs_0.ColumnIndex > -1 && dataGridViewCellMouseEventArgs_0.RowIndex < dataGridView.Rows.Count)
		{
			if (!Settings.Fields.EnableShowInfo || !ACE.sTASKedit.MainEditor.MainEditor.LoadedTask)
			{
				return;
			}
			DataGridViewRow dataGridViewRow = dataGridView.Rows[dataGridViewCellMouseEventArgs_0.RowIndex];
			if (dataGridViewRow != null && dataGridViewRow.Cells.Count >= 2)
			{
				if (int.TryParse(Convert.ToString(dataGridViewRow.Cells[1].Value, CultureInfo.InvariantCulture), out var result) && int.TryParse(Convert.ToString(dataGridViewRow.Cells[0].Value, CultureInfo.InvariantCulture), out var result2))
				{
					ATaskTempl task = ACE.sTASKedit.Classes.Extensions.Extensions.GetTask(GProD.Tasks, result2, result);
					ShowTaskHint(sender, task, result);
					toolTip_0?.Hide(dataGridView);
				}
				else
				{
					toolTip_0?.Hide(dataGridView);
				}
			}
			else
			{
				toolTip_0?.Hide(dataGridView);
			}
		}
		else
		{
			toolTip_0?.Hide(dataGridView);
		}
	}
}
