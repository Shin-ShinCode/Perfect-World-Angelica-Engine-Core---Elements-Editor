using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.sTASKedit.Classes;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.tasks;

namespace ACE.sTASKedit.Forms;

public class SelectTaskDescriptionIdWindow : Form
{
	private int int_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private Button button_0;

	private Button button_1;

	public DataGridView dataGridView_TaskDescriptions;

	private ToolTip toolTip_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	public SelectTaskDescriptionIdWindow(int currentid)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		int_0 = currentid;
		SetLocalization();
		if (ACE.sTASKedit.Classes.Settings.Fields.SelectTaskDescriptionIdWindow_Size.Width > 0 && ACE.sTASKedit.Classes.Settings.Fields.SelectTaskDescriptionIdWindow_Size.Height > 0)
		{
			base.Size = ACE.sTASKedit.Classes.Settings.Fields.SelectTaskDescriptionIdWindow_Size;
		}
	}

	private void SelectTaskDescriptionIdWindow_Load(object sender, EventArgs e)
	{
		dataGridView_TaskDescriptions.Rows.Clear();
		DataGridViewRowCollection rows = dataGridView_TaskDescriptions.Rows;
		object[] values = new string[2]
		{
			Class16.smethod_0(1648924112),
			GProD.TX(402)
		};
		rows.Add(values);
		if (GProD.taskdescriptions != null)
		{
			Dictionary<int, string>.KeyCollection keys = GProD.taskdescriptions.Keys;
			Dictionary<int, string>.ValueCollection values2 = GProD.taskdescriptions.Values;
			for (int i = 0; i < GProD.taskdescriptions.Count; i++)
			{
				try
				{
					DataGridViewRowCollection rows2 = dataGridView_TaskDescriptions.Rows;
					values = new string[2]
					{
						keys.ElementAt(i).ToString(),
						values2.ElementAt(i).Replace(Class16.smethod_0(1648935632), Environment.NewLine).Replace(Class16.smethod_0(1648903412), Environment.NewLine)
					};
					rows2.Add(values);
				}
				catch
				{
					DKBox.Show(GProD.TX(465), string.Empty);
				}
			}
		}
		if (GProD.SelectTaskDescriptionIdWindow_SelectedItemIndex < dataGridView_TaskDescriptions.RowCount)
		{
			dataGridView_TaskDescriptions.CurrentCell = dataGridView_TaskDescriptions.Rows[GProD.SelectTaskDescriptionIdWindow_SelectedItemIndex].Cells[0];
		}
		if (int_0 == 0)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < dataGridView_TaskDescriptions.Rows.Count)
			{
				if (Convert.ToInt32(dataGridView_TaskDescriptions.Rows[num].Cells[0].Value) == int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		dataGridView_TaskDescriptions.CurrentCell = dataGridView_TaskDescriptions.Rows[num].Cells[0];
	}

	private void dataGridView_TaskDescriptions_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.ColumnIndex < 0 || e.ColumnIndex >= 2 || e.RowIndex <= -1)
		{
			return;
		}
		try
		{
			int num = Convert.ToInt32(dataGridView_TaskDescriptions.Rows[e.RowIndex].Cells[0].Value);
			if (num > 0 && ACE.sTASKedit.Classes.Settings.Fields.EnableShowInfo)
			{
				string empty = string.Empty;
				empty += GlobalFunctions.ColorClean(GProD.GetTaskDescriptionDesc(num));
				Point point = Extensions.SetToolTipPos((Control)sender);
				toolTip_0.Show(empty, (Control)sender, point.X, point.Y);
			}
		}
		catch
		{
		}
	}

	private void dataGridView_TaskDescriptions_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		toolTip_0.Hide((Control)sender);
	}

	private void dataGridView_TaskDescriptions_Scroll(object sender, ScrollEventArgs e)
	{
		bool_0 = true;
	}

	private void dataGridView_TaskDescriptions_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_0)
		{
			bool_0 = false;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void SelectTaskDescriptionIdWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (dataGridView_TaskDescriptions.RowCount > 0)
		{
			GProD.SelectTaskDescriptionIdWindow_SelectedItemIndex = dataGridView_TaskDescriptions.CurrentCell.RowIndex;
		}
	}

	private void SelectTaskDescriptionIdWindow_SizeChanged(object sender, EventArgs e)
	{
		if (base.WindowState != FormWindowState.Maximized)
		{
			ACE.sTASKedit.Classes.Settings.Fields.SelectTaskDescriptionIdWindow_Size = base.Size;
		}
	}

	private void dataGridView_TaskDescriptions_MouseEnter(object sender, EventArgs e)
	{
		if (Form.ActiveForm == this)
		{
			((Control)sender).Focus();
		}
	}

	public void SetLocalization()
	{
		Text = GProD.TX(6037);
		dataGridViewTextBoxColumn_0.HeaderText = GProD.TX(6038);
		dataGridViewTextBoxColumn_1.HeaderText = GProD.TX(6020);
		button_0.Text = GProD.TX(6021);
		button_1.Text = GProD.TX(6022);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_0()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(SelectTaskDescriptionIdWindow));
		dataGridView_TaskDescriptions = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		button_0 = new Button();
		button_1 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		((ISupportInitialize)dataGridView_TaskDescriptions).BeginInit();
		SuspendLayout();
		dataGridView_TaskDescriptions.AllowUserToAddRows = false;
		dataGridView_TaskDescriptions.AllowUserToDeleteRows = false;
		dataGridView_TaskDescriptions.AllowUserToResizeColumns = false;
		dataGridView_TaskDescriptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_TaskDescriptions.BackgroundColor = SystemColors.Window;
		dataGridView_TaskDescriptions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_TaskDescriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_TaskDescriptions.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1);
		dataGridView_TaskDescriptions.Location = new Point(12, 12);
		dataGridView_TaskDescriptions.Name = Class16.smethod_0(1649250058);
		dataGridView_TaskDescriptions.ReadOnly = true;
		dataGridView_TaskDescriptions.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_TaskDescriptions.RowHeadersVisible = false;
		dataGridView_TaskDescriptions.RowTemplate.Height = 18;
		dataGridView_TaskDescriptions.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_TaskDescriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_TaskDescriptions.ShowCellToolTips = false;
		dataGridView_TaskDescriptions.Size = new Size(312, 202);
		dataGridView_TaskDescriptions.TabIndex = 0;
		dataGridView_TaskDescriptions.CellMouseEnter += dataGridView_TaskDescriptions_CellMouseEnter;
		dataGridView_TaskDescriptions.CellMouseLeave += dataGridView_TaskDescriptions_CellMouseLeave;
		dataGridView_TaskDescriptions.Scroll += dataGridView_TaskDescriptions_Scroll;
		dataGridView_TaskDescriptions.MouseEnter += dataGridView_TaskDescriptions_MouseEnter;
		dataGridView_TaskDescriptions.MouseMove += dataGridView_TaskDescriptions_MouseMove;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649250102);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649250120);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 60;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648997999);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649250159);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		button_0.Anchor = AnchorStyles.Bottom;
		button_0.Location = new Point(11, 221);
		button_0.Name = Class16.smethod_0(1649253385);
		button_0.Size = new Size(150, 23);
		button_0.TabIndex = 1;
		button_0.Text = Class16.smethod_0(1649253884);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom;
		button_1.Location = new Point(175, 221);
		button_1.Name = Class16.smethod_0(1649262492);
		button_1.Size = new Size(150, 23);
		button_1.TabIndex = 2;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		toolTip_0.AutoPopDelay = 90000;
		toolTip_0.InitialDelay = 500;
		toolTip_0.ReshowDelay = 100;
		toolTip_0.UseAnimation = false;
		toolTip_0.UseFading = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Window;
		base.ClientSize = new Size(336, 255);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(dataGridView_TaskDescriptions);
		base.Icon = Resources.edit;
		MinimumSize = new Size(352, 294);
		base.Name = Class16.smethod_0(1649250184);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649250184);
		base.FormClosing += SelectTaskDescriptionIdWindow_FormClosing;
		base.Load += SelectTaskDescriptionIdWindow_Load;
		base.SizeChanged += SelectTaskDescriptionIdWindow_SizeChanged;
		((ISupportInitialize)dataGridView_TaskDescriptions).EndInit();
		ResumeLayout(performLayout: false);
	}
}
