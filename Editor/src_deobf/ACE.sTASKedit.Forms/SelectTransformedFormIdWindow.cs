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

public class SelectTransformedFormIdWindow : Form
{
	private int int_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private Button button_0;

	private Button button_1;

	public DataGridView dataGridView_TransformedForms;

	private ToolTip toolTip_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	public SelectTransformedFormIdWindow(int currentid)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		int_0 = currentid;
		SetLocalization();
		if (ACE.sTASKedit.Classes.Settings.Fields.SelectTransformedFormIdWindow_Size.Width > 0 && ACE.sTASKedit.Classes.Settings.Fields.SelectTransformedFormIdWindow_Size.Height > 0)
		{
			base.Size = ACE.sTASKedit.Classes.Settings.Fields.SelectTransformedFormIdWindow_Size;
		}
	}

	private void SelectTransformedFormIdWindow_Load(object sender, EventArgs e)
	{
		Dictionary<int, int>.KeyCollection keys = GProD.transformedformslist.Keys;
		dataGridView_TransformedForms.Rows.Clear();
		DataGridViewRowCollection rows = dataGridView_TransformedForms.Rows;
		object[] values = new string[2]
		{
			Class16.smethod_0(1648924112),
			GProD.TX(402)
		};
		rows.Add(values);
		for (int i = 0; i < GProD.transformedformslist.Count - 1; i++)
		{
			try
			{
				DataGridViewRowCollection rows2 = dataGridView_TransformedForms.Rows;
				values = new string[2]
				{
					keys.ElementAt(i).ToString(),
					GProD.GetTransformedFormName(keys.ElementAt(i))
				};
				rows2.Add(values);
			}
			catch
			{
				DKBox.Show(GProD.TX(465), string.Empty);
			}
		}
		if (GProD.SelectTransformedFormIdWindow_SelectedItemIndex < dataGridView_TransformedForms.RowCount)
		{
			dataGridView_TransformedForms.CurrentCell = dataGridView_TransformedForms.Rows[GProD.SelectTransformedFormIdWindow_SelectedItemIndex].Cells[0];
		}
		if (int_0 == 0)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < dataGridView_TransformedForms.Rows.Count)
			{
				if (Convert.ToInt32(dataGridView_TransformedForms.Rows[num].Cells[0].Value) == int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		dataGridView_TransformedForms.CurrentCell = dataGridView_TransformedForms.Rows[num].Cells[0];
	}

	private void dataGridView_TransformedForms_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.ColumnIndex < 0 || e.ColumnIndex >= 2 || e.RowIndex <= -1)
		{
			return;
		}
		try
		{
			int num = Convert.ToInt32(dataGridView_TransformedForms.Rows[e.RowIndex].Cells[0].Value);
			if (num > 0 && ACE.sTASKedit.Classes.Settings.Fields.EnableShowInfo)
			{
				string empty = string.Empty;
				empty += GlobalFunctions.ColorClean(GProD.GetTransformedFormName(num));
				Point point = Extensions.SetToolTipPos((Control)sender);
				toolTip_0.Show(empty, (Control)sender, point.X, point.Y);
			}
		}
		catch
		{
		}
	}

	private void dataGridView_TransformedForms_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		toolTip_0.Hide((Control)sender);
	}

	private void dataGridView_TransformedForms_Scroll(object sender, ScrollEventArgs e)
	{
		bool_0 = true;
	}

	private void dataGridView_TransformedForms_MouseMove(object sender, MouseEventArgs e)
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

	private void SelectTransformedFormIdWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		GProD.SelectTransformedFormIdWindow_SelectedItemIndex = dataGridView_TransformedForms.CurrentCell.RowIndex;
	}

	private void SelectTransformedFormIdWindow_SizeChanged(object sender, EventArgs e)
	{
		if (base.WindowState != FormWindowState.Maximized)
		{
			ACE.sTASKedit.Classes.Settings.Fields.SelectTransformedFormIdWindow_Size = base.Size;
		}
	}

	private void dataGridView_TransformedForms_MouseEnter(object sender, EventArgs e)
	{
		if (Form.ActiveForm == this)
		{
			((Control)sender).Focus();
		}
	}

	public void SetLocalization()
	{
		Text = GProD.TX(6104);
		dataGridViewTextBoxColumn_0.HeaderText = GProD.TX(6105);
		dataGridViewTextBoxColumn_1.HeaderText = GProD.TX(6025);
		button_0.Text = GProD.TX(6001);
		button_1.Text = GProD.TX(6002);
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
		new ComponentResourceManager(typeof(SelectTransformedFormIdWindow));
		dataGridView_TransformedForms = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		button_0 = new Button();
		button_1 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		((ISupportInitialize)dataGridView_TransformedForms).BeginInit();
		SuspendLayout();
		dataGridView_TransformedForms.AllowUserToAddRows = false;
		dataGridView_TransformedForms.AllowUserToDeleteRows = false;
		dataGridView_TransformedForms.AllowUserToResizeColumns = false;
		dataGridView_TransformedForms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_TransformedForms.BackgroundColor = SystemColors.Window;
		dataGridView_TransformedForms.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_TransformedForms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_TransformedForms.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1);
		dataGridView_TransformedForms.Location = new Point(12, 12);
		dataGridView_TransformedForms.Name = Class16.smethod_0(1649250228);
		dataGridView_TransformedForms.ReadOnly = true;
		dataGridView_TransformedForms.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_TransformedForms.RowHeadersVisible = false;
		dataGridView_TransformedForms.RowTemplate.Height = 18;
		dataGridView_TransformedForms.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_TransformedForms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_TransformedForms.ShowCellToolTips = false;
		dataGridView_TransformedForms.Size = new Size(312, 202);
		dataGridView_TransformedForms.TabIndex = 0;
		dataGridView_TransformedForms.CellMouseEnter += dataGridView_TransformedForms_CellMouseEnter;
		dataGridView_TransformedForms.CellMouseLeave += dataGridView_TransformedForms_CellMouseLeave;
		dataGridView_TransformedForms.Scroll += dataGridView_TransformedForms_Scroll;
		dataGridView_TransformedForms.MouseEnter += dataGridView_TransformedForms_MouseEnter;
		dataGridView_TransformedForms.MouseMove += dataGridView_TransformedForms_MouseMove;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649077794);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649250256);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 60;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649250295);
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
		base.Controls.Add(dataGridView_TransformedForms);
		base.Icon = Resources.edit;
		MinimumSize = new Size(352, 294);
		base.Name = Class16.smethod_0(1649249296);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649249296);
		base.FormClosing += SelectTransformedFormIdWindow_FormClosing;
		base.Load += SelectTransformedFormIdWindow_Load;
		base.SizeChanged += SelectTransformedFormIdWindow_SizeChanged;
		((ISupportInitialize)dataGridView_TransformedForms).EndInit();
		ResumeLayout(performLayout: false);
	}
}
