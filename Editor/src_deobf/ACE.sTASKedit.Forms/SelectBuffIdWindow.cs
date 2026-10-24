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

public class SelectBuffIdWindow : Form
{
	private int int_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private Button button_0;

	private Button button_1;

	public DataGridView dataGridView_Buffs;

	private ToolTip toolTip_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	public SelectBuffIdWindow(int currentid)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		int_0 = currentid;
		SetLocalization();
		if (ACE.sTASKedit.Classes.Settings.Fields.SelectBuffIdWindow_Size.Width > 0 && ACE.sTASKedit.Classes.Settings.Fields.SelectBuffIdWindow_Size.Height > 0)
		{
			base.Size = ACE.sTASKedit.Classes.Settings.Fields.SelectBuffIdWindow_Size;
		}
	}

	private void SelectBuffIdWindow_Load(object sender, EventArgs e)
	{
		dataGridView_Buffs.Rows.Clear();
		DataGridViewRowCollection rows = dataGridView_Buffs.Rows;
		object[] values = new string[2]
		{
			Class16.smethod_0(1648924112),
			GProD.TX(402)
		};
		rows.Add(values);
		if (GProD.buff_str != null)
		{
			Dictionary<int, string>.KeyCollection keys = GProD.buff_str.Keys;
			Dictionary<int, string>.ValueCollection values2 = GProD.buff_str.Values;
			for (int i = 0; i < GProD.buff_str.Count; i++)
			{
				try
				{
					DataGridViewRowCollection rows2 = dataGridView_Buffs.Rows;
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
		if (GProD.SelectBuffIdWindow_SelectedItemIndex < dataGridView_Buffs.RowCount)
		{
			dataGridView_Buffs.CurrentCell = dataGridView_Buffs.Rows[GProD.SelectBuffIdWindow_SelectedItemIndex].Cells[0];
		}
		if (int_0 == 0)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < dataGridView_Buffs.Rows.Count)
			{
				if (Convert.ToInt32(dataGridView_Buffs.Rows[num].Cells[0].Value) == int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		dataGridView_Buffs.CurrentCell = dataGridView_Buffs.Rows[num].Cells[0];
	}

	private void dataGridView_Buffs_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.ColumnIndex < 0 || e.ColumnIndex >= 2 || e.RowIndex <= -1)
		{
			return;
		}
		try
		{
			int num = Convert.ToInt32(dataGridView_Buffs.Rows[e.RowIndex].Cells[0].Value);
			if (num > 0 && ACE.sTASKedit.Classes.Settings.Fields.EnableShowInfo)
			{
				string empty = string.Empty;
				empty += GlobalFunctions.ColorClean(GProD.GetBuffDesc(num));
				Point point = Extensions.SetToolTipPos((Control)sender);
				toolTip_0.Show(empty, (Control)sender, point.X, point.Y);
			}
		}
		catch
		{
		}
	}

	private void dataGridView_Buffs_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		toolTip_0.Hide((Control)sender);
	}

	private void dataGridView_Buffs_Scroll(object sender, ScrollEventArgs e)
	{
		bool_0 = true;
	}

	private void dataGridView_Buffs_MouseMove(object sender, MouseEventArgs e)
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

	private void SelectBuffIdWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (dataGridView_Buffs.RowCount > 0)
		{
			GProD.SelectBuffIdWindow_SelectedItemIndex = dataGridView_Buffs.CurrentCell.RowIndex;
		}
	}

	private void SelectBuffIdWindow_SizeChanged(object sender, EventArgs e)
	{
		if (base.WindowState != FormWindowState.Maximized)
		{
			ACE.sTASKedit.Classes.Settings.Fields.SelectBuffIdWindow_Size = base.Size;
		}
	}

	private void dataGridView_Buffs_MouseEnter(object sender, EventArgs e)
	{
		if (Form.ActiveForm == this)
		{
			((Control)sender).Focus();
		}
	}

	public void SetLocalization()
	{
		Text = GProD.TX(6018);
		dataGridViewTextBoxColumn_0.HeaderText = GProD.TX(6019);
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
		new ComponentResourceManager(typeof(SelectBuffIdWindow));
		dataGridView_Buffs = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		button_0 = new Button();
		button_1 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		((ISupportInitialize)dataGridView_Buffs).BeginInit();
		SuspendLayout();
		dataGridView_Buffs.AllowUserToAddRows = false;
		dataGridView_Buffs.AllowUserToDeleteRows = false;
		dataGridView_Buffs.AllowUserToResizeColumns = false;
		dataGridView_Buffs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_Buffs.BackgroundColor = SystemColors.Window;
		dataGridView_Buffs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_Buffs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_Buffs.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1);
		dataGridView_Buffs.Location = new Point(12, 12);
		dataGridView_Buffs.Name = Class16.smethod_0(1649247713);
		dataGridView_Buffs.ReadOnly = true;
		dataGridView_Buffs.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_Buffs.RowHeadersVisible = false;
		dataGridView_Buffs.RowTemplate.Height = 18;
		dataGridView_Buffs.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_Buffs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_Buffs.ShowCellToolTips = false;
		dataGridView_Buffs.Size = new Size(312, 202);
		dataGridView_Buffs.TabIndex = 0;
		dataGridView_Buffs.CellMouseEnter += dataGridView_Buffs_CellMouseEnter;
		dataGridView_Buffs.CellMouseLeave += dataGridView_Buffs_CellMouseLeave;
		dataGridView_Buffs.Scroll += dataGridView_Buffs_Scroll;
		dataGridView_Buffs.MouseEnter += dataGridView_Buffs_MouseEnter;
		dataGridView_Buffs.MouseMove += dataGridView_Buffs_MouseMove;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649247738);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649246728);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 60;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648997999);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649246756);
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
		base.Controls.Add(dataGridView_Buffs);
		base.Icon = Resources.edit;
		MinimumSize = new Size(352, 294);
		base.Name = Class16.smethod_0(1649246770);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649246770);
		base.FormClosing += SelectBuffIdWindow_FormClosing;
		base.Load += SelectBuffIdWindow_Load;
		base.SizeChanged += SelectBuffIdWindow_SizeChanged;
		((ISupportInitialize)dataGridView_Buffs).EndInit();
		ResumeLayout(performLayout: false);
	}
}
