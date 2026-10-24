using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.sTASKedit.Classes;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;

namespace ACE.sTASKedit.Forms;

public class SelectGrowthTargetWindow : Form
{
	[CLSCompliant(false)]
	public uint GrowthTarget;

	private bool bool_0;

	private IContainer icontainer_0;

	private DataGridView dataGridView_0;

	private Button button_0;

	private Button button_1;

	private ToolTip toolTip_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	public SelectGrowthTargetWindow(int growthtarget)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		GrowthTarget = (uint)growthtarget;
		SetLocalization();
		if (ACE.sTASKedit.Classes.Settings.Fields.SelectGrowthTargetWindow_Size.Width > 0 && ACE.sTASKedit.Classes.Settings.Fields.SelectGrowthTargetWindow_Size.Height > 0)
		{
			base.Size = ACE.sTASKedit.Classes.Settings.Fields.SelectGrowthTargetWindow_Size;
		}
	}

	private void SelectGrowthTargetWindow_Load(object sender, EventArgs e)
	{
		uint num = 1u;
		for (int i = 1; i <= 24; i++)
		{
			bool flag = false;
			if ((GrowthTarget & num) != 0)
			{
				flag = true;
			}
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			object[] values = new string[3]
			{
				num.ToString(),
				flag.ToString(),
				GProD.TX(3800 + i)
			};
			rows.Add(values);
			num *= 2;
		}
	}

	private void dataGridView_0_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.ColumnIndex < 0 || e.ColumnIndex >= 3 || e.RowIndex <= -1)
		{
			return;
		}
		try
		{
			object value = dataGridView_0.Rows[e.RowIndex].Cells[2].Value;
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
					goto IL_0061;
				}
			}
			obj = string.Empty;
			goto IL_0061;
			IL_0061:
			string text = (string)obj;
			Point point = Extensions.SetToolTipPos((Control)sender);
			toolTip_0.Show(text, (Control)sender, point.X, point.Y);
		}
		catch
		{
		}
	}

	private void dataGridView_0_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		toolTip_0.Hide((Control)sender);
	}

	private void dataGridView_0_Scroll(object sender, ScrollEventArgs e)
	{
		bool_0 = true;
	}

	private void dataGridView_0_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_0)
		{
			bool_0 = false;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		GrowthTarget = 0u;
		for (int i = 0; i < dataGridView_0.RowCount; i++)
		{
			if (Convert.ToBoolean(dataGridView_0.Rows[i].Cells[1].Value))
			{
				GrowthTarget += Convert.ToUInt32(dataGridView_0.Rows[i].Cells[0].Value);
			}
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void SelectGrowthTargetWindow_SizeChanged(object sender, EventArgs e)
	{
		if (base.WindowState != FormWindowState.Maximized)
		{
			ACE.sTASKedit.Classes.Settings.Fields.SelectGrowthTargetWindow_Size = base.Size;
		}
	}

	private void dataGridView_0_MouseEnter(object sender, EventArgs e)
	{
		if (Form.ActiveForm == this)
		{
			((Control)sender).Focus();
		}
	}

	public void SetLocalization()
	{
		Text = GProD.TX(6041);
		dataGridViewTextBoxColumn_0.HeaderText = GProD.TX(6042);
		dataGridViewCheckBoxColumn_0.HeaderText = GProD.TX(6043);
		dataGridViewTextBoxColumn_1.HeaderText = GProD.TX(6020);
		button_0.Text = GProD.TX(6033);
		button_1.Text = GProD.TX(6034);
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
		new ComponentResourceManager(typeof(SelectGrowthTargetWindow));
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		button_0 = new Button();
		button_1 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		((ISupportInitialize)dataGridView_0).BeginInit();
		SuspendLayout();
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_0.BackgroundColor = SystemColors.Window;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewCheckBoxColumn_0, dataGridViewTextBoxColumn_1);
		dataGridView_0.Location = new Point(12, 12);
		dataGridView_0.Name = Class16.smethod_0(1649246795);
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.RowTemplate.Height = 18;
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellToolTips = false;
		dataGridView_0.Size = new Size(312, 202);
		dataGridView_0.TabIndex = 0;
		dataGridView_0.CellMouseEnter += dataGridView_0_CellMouseEnter;
		dataGridView_0.CellMouseLeave += dataGridView_0_CellMouseLeave;
		dataGridView_0.Scroll += dataGridView_0_Scroll;
		dataGridView_0.MouseEnter += dataGridView_0_MouseEnter;
		dataGridView_0.MouseMove += dataGridView_0_MouseMove;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649246836);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649246847);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 39;
		dataGridViewCheckBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewCheckBoxColumn_0.HeaderText = Class16.smethod_0(1649089161);
		dataGridViewCheckBoxColumn_0.Name = Class16.smethod_0(1649246877);
		dataGridViewCheckBoxColumn_0.Width = 32;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648997999);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649246898);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		button_0.Anchor = AnchorStyles.Bottom;
		button_0.Location = new Point(11, 221);
		button_0.Name = Class16.smethod_0(1649253385);
		button_0.Size = new Size(150, 23);
		button_0.TabIndex = 2;
		button_0.Text = Class16.smethod_0(1649253884);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom;
		button_1.Location = new Point(175, 221);
		button_1.Name = Class16.smethod_0(1649262492);
		button_1.Size = new Size(150, 23);
		button_1.TabIndex = 3;
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
		base.Controls.Add(dataGridView_0);
		base.Icon = Resources.edit;
		MinimumSize = new Size(352, 294);
		base.Name = Class16.smethod_0(1649246943);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649246943);
		base.Load += SelectGrowthTargetWindow_Load;
		base.SizeChanged += SelectGrowthTargetWindow_SizeChanged;
		((ISupportInitialize)dataGridView_0).EndInit();
		ResumeLayout(performLayout: false);
	}
}
