using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.sTASKedit.Forms;

public abstract class LootSimulatorFormBase : Form
{
	protected int _totalOpens;

	protected readonly Random _rng = new Random();

	private IContainer icontainer_0;

	protected Label label_Source;

	protected ComboBox comboBox_Source;

	protected Label label_OpenCount;

	protected NumericUpDown numericUpDown_OpenCount;

	protected Button button_Simulate;

	protected Button button_Clear;

	protected Panel panel_Top;

	protected InventoryGridPanel inventoryGridPanel;

	protected DataGridView dataGridView_Statistics;

	protected Label label_Status;

	protected SplitContainer splitContainer_Main;

	protected ToolTip toolTip_Item;

	protected abstract string SourceLabelText { get; }

	protected abstract void PopulateSourceList();

	protected abstract void OnSimulate(int openCount);

	protected abstract void ShowItemTooltip(Control owner, int itemId);

	protected void InitializeBase()
	{
		method_2();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		toolTip_Item.Active = false;
		inventoryGridPanel.SlotHovered += method_0;
		inventoryGridPanel.SlotLeft += method_1;
		base.Shown += LootSimulatorFormBase_Shown;
		base.Resize += LootSimulatorFormBase_Resize;
		PopulateSourceList();
	}

	protected void comboBox_Source_SelectedIndexChanged(object sender, EventArgs e)
	{
		ClearResults();
	}

	protected void button_Simulate_Click(object sender, EventArgs e)
	{
		int selectedIndex = comboBox_Source.SelectedIndex;
		if (selectedIndex >= 0)
		{
			int num = (int)numericUpDown_OpenCount.Value;
			OnSimulate(num);
			_totalOpens += num;
			UpdateStatistics();
		}
	}

	protected void button_Clear_Click(object sender, EventArgs e)
	{
		ClearResults();
	}

	protected void ClearResults()
	{
		inventoryGridPanel.ClearItems();
		dataGridView_Statistics.Rows.Clear();
		_totalOpens = 0;
		UpdateStatusLabel();
	}

	protected int GetItemIdFromGridRow(int rowIndex)
	{
		List<int> orderedIds = inventoryGridPanel.OrderedIds;
		if (rowIndex >= 0 && rowIndex < orderedIds.Count)
		{
			return orderedIds[rowIndex];
		}
		return 0;
	}

	protected void UpdateStatusLabel()
	{
		int totalItemCount = inventoryGridPanel.TotalItemCount;
		int uniqueItemCount = inventoryGridPanel.UniqueItemCount;
		label_Status.Text = string.Format(Class16.smethod_0(1649250800), _totalOpens, totalItemCount, uniqueItemCount);
	}

	protected void UpdateStatistics()
	{
		dataGridView_Statistics.Rows.Clear();
		Dictionary<int, InventoryGridPanel.SlotItem> items = inventoryGridPanel.Items;
		List<int> orderedIds = inventoryGridPanel.OrderedIds;
		int totalItemCount = inventoryGridPanel.TotalItemCount;
		for (int i = 0; i < orderedIds.Count; i++)
		{
			InventoryGridPanel.SlotItem slotItem = items[orderedIds[i]];
			double num = ((totalItemCount > 0) ? ((double)slotItem.Count / (double)totalItemCount * 100.0) : 0.0);
			dataGridView_Statistics.Rows.Add(slotItem.Icon, slotItem.Name, slotItem.Count.ToString(Class16.smethod_0(1648909972)), num.ToString(Class16.smethod_0(1648922976)) + Class16.smethod_0(1648923229));
		}
		UpdateStatusLabel();
	}

	private void method_0(int int_0, int int_1)
	{
		if (int_1 > 0)
		{
			if (HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(inventoryGridPanel.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(int_1, ItemType.Matter);
			}
			else
			{
				ShowItemTooltip(inventoryGridPanel, int_1);
			}
		}
	}

	private void method_1()
	{
		toolTip_Item.Hide(inventoryGridPanel);
		if (HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
	}

	protected void dataGridView_Stats_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex <= 1)
		{
			int itemIdFromGridRow = GetItemIdFromGridRow(e.RowIndex);
			if (itemIdFromGridRow > 0 && HINTS.ToolTipWindow == null)
			{
				ShowItemTooltip((Control)sender, itemIdFromGridRow);
			}
		}
	}

	protected void dataGridView_Stats_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		toolTip_Item.Hide((Control)sender);
		if (HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
	}

	protected void dataGridView_Stats_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex >= 0 && e.ColumnIndex == 0)
		{
			int itemIdFromGridRow = GetItemIdFromGridRow(e.RowIndex);
			if (itemIdFromGridRow > 0 && HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(((Control)sender).Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(itemIdFromGridRow, ItemType.Matter);
			}
		}
	}

	private void LootSimulatorFormBase_Shown(object sender, EventArgs e)
	{
		method_7();
	}

	private void LootSimulatorFormBase_Resize(object sender, EventArgs e)
	{
		method_7();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		toolTip_Item = new ToolTip(icontainer_0);
		label_Source = new Label();
		comboBox_Source = new ComboBox();
		label_OpenCount = new Label();
		numericUpDown_OpenCount = new NumericUpDown();
		button_Simulate = new Button();
		button_Clear = new Button();
		panel_Top = new Panel();
		inventoryGridPanel = new InventoryGridPanel();
		label_Status = new Label();
		splitContainer_Main = new SplitContainer();
		method_4();
		((ISupportInitialize)numericUpDown_OpenCount).BeginInit();
		((ISupportInitialize)dataGridView_Statistics).BeginInit();
		((ISupportInitialize)splitContainer_Main).BeginInit();
		splitContainer_Main.Panel1.SuspendLayout();
		splitContainer_Main.Panel2.SuspendLayout();
		splitContainer_Main.SuspendLayout();
		panel_Top.SuspendLayout();
		SuspendLayout();
		method_3();
		method_5();
		method_6();
		((ISupportInitialize)numericUpDown_OpenCount).EndInit();
		((ISupportInitialize)dataGridView_Statistics).EndInit();
		splitContainer_Main.Panel1.ResumeLayout(performLayout: false);
		splitContainer_Main.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_Main).EndInit();
		splitContainer_Main.ResumeLayout(performLayout: false);
		panel_Top.ResumeLayout(performLayout: false);
		panel_Top.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void method_3()
	{
		panel_Top.Dock = DockStyle.Top;
		panel_Top.Height = 42;
		panel_Top.Padding = new Padding(6, 6, 6, 4);
		panel_Top.Controls.Add(label_Source);
		panel_Top.Controls.Add(comboBox_Source);
		panel_Top.Controls.Add(label_OpenCount);
		panel_Top.Controls.Add(numericUpDown_OpenCount);
		panel_Top.Controls.Add(button_Simulate);
		panel_Top.Controls.Add(button_Clear);
		label_Source.AutoSize = true;
		label_Source.Location = new Point(8, 12);
		label_Source.Text = SourceLabelText;
		comboBox_Source.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_Source.Location = new Point(78, 8);
		comboBox_Source.Size = new Size(180, 23);
		comboBox_Source.SelectedIndexChanged += comboBox_Source_SelectedIndexChanged;
		label_OpenCount.AutoSize = true;
		label_OpenCount.Location = new Point(270, 12);
		label_OpenCount.Text = Class16.smethod_0(1649253928);
		numericUpDown_OpenCount.Location = new Point(316, 8);
		numericUpDown_OpenCount.Size = new Size(90, 23);
		numericUpDown_OpenCount.Minimum = 1m;
		numericUpDown_OpenCount.Maximum = 1000000m;
		numericUpDown_OpenCount.Value = 100m;
		button_Simulate.Location = new Point(416, 7);
		button_Simulate.Size = new Size(100, 26);
		button_Simulate.Text = Class16.smethod_0(1649253949);
		button_Simulate.UseVisualStyleBackColor = true;
		button_Simulate.Click += button_Simulate_Click;
		button_Clear.Location = new Point(522, 7);
		button_Clear.Size = new Size(75, 26);
		button_Clear.Text = Class16.smethod_0(1648928315);
		button_Clear.UseVisualStyleBackColor = true;
		button_Clear.Click += button_Clear_Click;
	}

	private void method_4()
	{
		dataGridView_Statistics = new DataGridView();
		DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn();
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn.HeaderText = string.Empty;
		dataGridViewImageColumn.Width = 28;
		dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
		dataGridViewTextBoxColumn.HeaderText = Class16.smethod_0(1648969762);
		dataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn.MinimumWidth = 80;
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewTextBoxColumn2.HeaderText = Class16.smethod_0(1649253970);
		dataGridViewTextBoxColumn2.Width = 70;
		dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle;
		dataGridViewTextBoxColumn3.HeaderText = Class16.smethod_0(1649253988);
		dataGridViewTextBoxColumn3.Width = 80;
		dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle.Clone();
		dataGridView_Statistics.AllowUserToAddRows = false;
		dataGridView_Statistics.AllowUserToDeleteRows = false;
		dataGridView_Statistics.AllowUserToResizeRows = false;
		dataGridView_Statistics.ReadOnly = true;
		dataGridView_Statistics.RowHeadersVisible = false;
		dataGridView_Statistics.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_Statistics.BackgroundColor = Color.FromArgb(30, 30, 35);
		dataGridView_Statistics.BorderStyle = BorderStyle.FixedSingle;
		dataGridView_Statistics.RowTemplate.Height = 24;
		dataGridView_Statistics.Columns.AddRange(dataGridViewImageColumn, dataGridViewTextBoxColumn, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3);
		dataGridView_Statistics.CellMouseEnter += dataGridView_Stats_CellMouseEnter;
		dataGridView_Statistics.CellMouseLeave += dataGridView_Stats_CellMouseLeave;
		dataGridView_Statistics.CellMouseMove += dataGridView_Stats_CellMouseMove;
	}

	private void method_5()
	{
		inventoryGridPanel.Dock = DockStyle.Fill;
		inventoryGridPanel.BackColor = Color.FromArgb(30, 30, 35);
		inventoryGridPanel.BorderStyle = BorderStyle.FixedSingle;
		inventoryGridPanel.SetToolTipText(null);
		dataGridView_Statistics.Dock = DockStyle.Fill;
		splitContainer_Main.Dock = DockStyle.Fill;
		splitContainer_Main.Size = new Size(900, 500);
		splitContainer_Main.SplitterWidth = 5;
		splitContainer_Main.Panel1MinSize = 250;
		splitContainer_Main.Panel2MinSize = 220;
		splitContainer_Main.FixedPanel = FixedPanel.None;
		splitContainer_Main.Panel1.Controls.Add(inventoryGridPanel);
		splitContainer_Main.Panel2.Controls.Add(dataGridView_Statistics);
		method_7();
		label_Status.Dock = DockStyle.Bottom;
		label_Status.Height = 24;
		label_Status.TextAlign = ContentAlignment.MiddleLeft;
		label_Status.Padding = new Padding(8, 0, 0, 0);
		label_Status.Text = Class16.smethod_0(1648920624);
	}

	private void method_6()
	{
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(900, 600);
		base.Controls.Add(splitContainer_Main);
		base.Controls.Add(label_Status);
		base.Controls.Add(panel_Top);
		MinimumSize = new Size(700, 450);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649253993);
	}

	private void method_7()
	{
		if (splitContainer_Main.Width > 0)
		{
			int panel1MinSize = splitContainer_Main.Panel1MinSize;
			int val = Math.Max(panel1MinSize, splitContainer_Main.ClientSize.Width - splitContainer_Main.Panel2MinSize - splitContainer_Main.SplitterWidth);
			int num = Math.Max(panel1MinSize, Math.Min(360, val));
			if (num > 0 && splitContainer_Main.SplitterDistance != num)
			{
				splitContainer_Main.SplitterDistance = num;
			}
		}
	}
}
