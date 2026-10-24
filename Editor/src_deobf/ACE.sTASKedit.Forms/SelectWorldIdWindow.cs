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

public class SelectWorldIdWindow : Form
{
	private int int_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private Button button_0;

	private Button button_1;

	public DataGridView dataGridView_Instances;

	private ToolTip toolTip_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	public TextBox textBox_WorldId;

	public SelectWorldIdWindow(int currentid)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		int_0 = currentid;
		SetLocalization();
		if (ACE.sTASKedit.Classes.Settings.Fields.SelectWorldIdWindow_Size.Width > 0 && ACE.sTASKedit.Classes.Settings.Fields.SelectWorldIdWindow_Size.Height > 0)
		{
			base.Size = ACE.sTASKedit.Classes.Settings.Fields.SelectWorldIdWindow_Size;
		}
	}

	private void SelectWorldIdWindow_Load(object sender, EventArgs e)
	{
		Dictionary<int, string>.KeyCollection keys = GProD.InstanceList.Keys;
		Dictionary<int, string>.ValueCollection values = GProD.InstanceList.Values;
		dataGridView_Instances.Rows.Clear();
		for (int i = 0; i < GProD.InstanceList.Count; i++)
		{
			try
			{
				DataGridViewRowCollection rows = dataGridView_Instances.Rows;
				object[] values2 = new string[2]
				{
					keys.ElementAt(i).ToString(),
					values.ElementAt(i).Replace(Class16.smethod_0(1648903412), Environment.NewLine)
				};
				rows.Add(values2);
			}
			catch
			{
				DKBox.Show(GProD.TX(465), string.Empty);
			}
		}
		if (GProD.SelectWorldIdWindow_SelectedItemIndex < dataGridView_Instances.RowCount)
		{
			dataGridView_Instances.CurrentCell = dataGridView_Instances.Rows[GProD.SelectWorldIdWindow_SelectedItemIndex].Cells[0];
		}
		textBox_WorldId.Text = int_0.ToString();
		if (int_0 == 0)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < dataGridView_Instances.Rows.Count)
			{
				if (Convert.ToInt32(dataGridView_Instances.Rows[num].Cells[0].Value) == int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		dataGridView_Instances.CurrentCell = dataGridView_Instances.Rows[num].Cells[0];
		dataGridView_Instances_SelectionChanged(null, null);
	}

	private void dataGridView_Instances_SelectionChanged(object sender, EventArgs e)
	{
		TextBox textBox = textBox_WorldId;
		object value = dataGridView_Instances.Rows[dataGridView_Instances.CurrentRow.Index].Cells[0].Value;
		object obj;
		if (value == null)
		{
			obj = null;
		}
		else
		{
			obj = value.ToString();
			if (obj != null)
			{
				goto IL_0050;
			}
		}
		obj = Class16.smethod_0(1648924112);
		goto IL_0050;
		IL_0050:
		textBox.Text = (string)obj;
	}

	private void dataGridView_Instances_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.ColumnIndex < 0 || e.ColumnIndex >= 2 || e.RowIndex <= -1)
		{
			return;
		}
		try
		{
			int num = Convert.ToInt32(dataGridView_Instances.Rows[e.RowIndex].Cells[0].Value);
			if (num > 0 && ACE.sTASKedit.Classes.Settings.Fields.EnableShowInfo)
			{
				string empty = string.Empty;
				empty += GlobalFunctions.ColorClean(GProD.GetInstanceName(num));
				Point point = Extensions.SetToolTipPos((Control)sender);
				toolTip_0.Show(empty, (Control)sender, point.X, point.Y);
			}
		}
		catch
		{
		}
	}

	private void dataGridView_Instances_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		toolTip_0.Hide((Control)sender);
	}

	private void dataGridView_Instances_Scroll(object sender, ScrollEventArgs e)
	{
		bool_0 = true;
	}

	private void dataGridView_Instances_MouseMove(object sender, MouseEventArgs e)
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

	private void SelectWorldIdWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		GProD.SelectWorldIdWindow_SelectedItemIndex = dataGridView_Instances.CurrentCell.RowIndex;
	}

	private void SelectWorldIdWindow_SizeChanged(object sender, EventArgs e)
	{
		if (base.WindowState != FormWindowState.Maximized)
		{
			ACE.sTASKedit.Classes.Settings.Fields.SelectWorldIdWindow_Size = base.Size;
		}
	}

	private void dataGridView_Instances_MouseEnter(object sender, EventArgs e)
	{
		if (Form.ActiveForm == this)
		{
			((Control)sender).Focus();
		}
	}

	public void SetLocalization()
	{
		Text = GProD.TX(6013);
		dataGridViewTextBoxColumn_0.HeaderText = GProD.TX(6014);
		dataGridViewTextBoxColumn_1.HeaderText = GProD.TX(6015);
		button_0.Text = GProD.TX(6016);
		button_1.Text = GProD.TX(6017);
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
		new ComponentResourceManager(typeof(SelectWorldIdWindow));
		dataGridView_Instances = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		button_0 = new Button();
		button_1 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		textBox_WorldId = new TextBox();
		((ISupportInitialize)dataGridView_Instances).BeginInit();
		SuspendLayout();
		dataGridView_Instances.AllowUserToAddRows = false;
		dataGridView_Instances.AllowUserToDeleteRows = false;
		dataGridView_Instances.AllowUserToResizeColumns = false;
		dataGridView_Instances.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_Instances.BackgroundColor = SystemColors.Window;
		dataGridView_Instances.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_Instances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_Instances.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1);
		dataGridView_Instances.Location = new Point(12, 41);
		dataGridView_Instances.Name = Class16.smethod_0(1649249340);
		dataGridView_Instances.ReadOnly = true;
		dataGridView_Instances.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_Instances.RowHeadersVisible = false;
		dataGridView_Instances.RowTemplate.Height = 18;
		dataGridView_Instances.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_Instances.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_Instances.ShowCellToolTips = false;
		dataGridView_Instances.Size = new Size(312, 202);
		dataGridView_Instances.TabIndex = 0;
		dataGridView_Instances.CellMouseEnter += dataGridView_Instances_CellMouseEnter;
		dataGridView_Instances.CellMouseLeave += dataGridView_Instances_CellMouseLeave;
		dataGridView_Instances.Scroll += dataGridView_Instances_Scroll;
		dataGridView_Instances.SelectionChanged += dataGridView_Instances_SelectionChanged;
		dataGridView_Instances.MouseEnter += dataGridView_Instances_MouseEnter;
		dataGridView_Instances.MouseMove += dataGridView_Instances_MouseMove;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649249361);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649249376);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 60;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649249405);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		button_0.Anchor = AnchorStyles.Bottom;
		button_0.Location = new Point(11, 250);
		button_0.Name = Class16.smethod_0(1649253385);
		button_0.Size = new Size(150, 23);
		button_0.TabIndex = 1;
		button_0.Text = Class16.smethod_0(1649253884);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom;
		button_1.Location = new Point(175, 250);
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
		textBox_WorldId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_WorldId.Location = new Point(12, 12);
		textBox_WorldId.Name = Class16.smethod_0(1649249431);
		textBox_WorldId.Size = new Size(312, 20);
		textBox_WorldId.TabIndex = 3;
		textBox_WorldId.TextAlign = HorizontalAlignment.Center;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Window;
		base.ClientSize = new Size(336, 284);
		base.Controls.Add(textBox_WorldId);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(dataGridView_Instances);
		base.Icon = Resources.edit;
		MinimumSize = new Size(352, 323);
		base.Name = Class16.smethod_0(1649249453);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649249453);
		base.FormClosing += SelectWorldIdWindow_FormClosing;
		base.Load += SelectWorldIdWindow_Load;
		base.SizeChanged += SelectWorldIdWindow_SizeChanged;
		((ISupportInitialize)dataGridView_Instances).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
