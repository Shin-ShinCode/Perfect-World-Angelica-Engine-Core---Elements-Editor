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

public class SelectSkillIdWindow : Form
{
	private int int_0;

	private bool bool_0;

	private bool bool_1;

	private IContainer icontainer_0;

	private RichTextBox richTextBox_0;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private Label label_0;

	private Label label_1;

	public DataGridView dataGridView_Skills;

	private ToolTip toolTip_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	public SelectSkillIdWindow(int currentid)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		int_0 = currentid;
		SetLocalization();
		dataGridView_Skills.Columns[0].DataPropertyName = Class16.smethod_0(1649246974);
		dataGridView_Skills.Columns[1].DataPropertyName = Class16.smethod_0(1649246977);
		try
		{
			richTextBox_0.Font = new Font(GProD.PWUIFont.Families[0], 8f, FontStyle.Bold);
		}
		catch
		{
		}
		if (ACE.sTASKedit.Classes.Settings.Fields.SelectSkillIdWindow_Size.Width > 0 && ACE.sTASKedit.Classes.Settings.Fields.SelectSkillIdWindow_Size.Height > 0)
		{
			base.Size = ACE.sTASKedit.Classes.Settings.Fields.SelectSkillIdWindow_Size;
		}
	}

	private void SelectSkillIdWindow_Load(object sender, EventArgs e)
	{
		List<DGW_Prop_Row> list = new List<DGW_Prop_Row>();
		if (GProD.skillstr != null)
		{
			Dictionary<int, string>.KeyCollection keys = GProD.skillstr.Keys;
			Dictionary<int, string>.ValueCollection values = GProD.skillstr.Values;
			for (int i = 0; i < GProD.skillstr.Count - 1; i += 2)
			{
				try
				{
					list.Add(new DGW_Prop_Row((keys.ElementAt(i) / 10).ToString(), values.ElementAt(i)));
				}
				catch
				{
					DKBox.Show(GProD.TX(465), string.Empty);
				}
			}
		}
		dataGridView_Skills.DataSource = list;
		bool_0 = true;
		if (GProD.SelectSkillIdWindow_SelectedItemIndex < dataGridView_Skills.RowCount && dataGridView_Skills.RowCount > 0)
		{
			dataGridView_Skills.CurrentCell = dataGridView_Skills.Rows[GProD.SelectSkillIdWindow_SelectedItemIndex].Cells[0];
		}
		if (int_0 != 0)
		{
			textBox_0.Text = int_0.ToString();
		}
	}

	private void dataGridView_Skills_SelectionChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			int rowIndex = dataGridView_Skills.CurrentCell.RowIndex;
			int num = Convert.ToInt32(dataGridView_Skills.Rows[rowIndex].Cells[0].Value);
			if (num != 0)
			{
				richTextBox_0.Rtf = mConvert.StringToRTF(GProD.GetSkillDesc(num), richTextBox_0.ForeColor, richTextBox_0.Font);
				return;
			}
			richTextBox_0.Text = GProD.TX(402);
			richTextBox_0.Select(0, richTextBox_0.Text.Length);
			richTextBox_0.SelectionColor = Color.White;
		}
	}

	private void dataGridView_Skills_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (!bool_1 && e.ColumnIndex >= 0 && e.ColumnIndex < 2 && e.RowIndex > -1)
		{
			try
			{
				int num = Convert.ToInt32(dataGridView_Skills.Rows[e.RowIndex].Cells[0].Value);
				if (num > 0 && ACE.sTASKedit.Classes.Settings.Fields.EnableShowInfo)
				{
					string text = string.Empty;
					string text2 = GProD.TX(402);
					((DataGridView)sender).ShowCellToolTips = false;
					string skillName = GProD.GetSkillName(num);
					text2 = GlobalFunctions.ColorClean(GProD.GetSkillDesc(num));
					if (text != GProD.TX(404) && text2 != GProD.TX(404))
					{
						text = skillName;
					}
					if (text2 == string.Empty)
					{
						text2 = Class16.smethod_0(1648942211);
					}
					toolTip_0.ToolTipTitle = text;
					Point point = Extensions.SetToolTipPos((Control)sender);
					toolTip_0.Show(text2, (Control)sender, point.X, point.Y);
				}
				return;
			}
			catch
			{
				((DataGridView)sender).ShowCellToolTips = true;
				return;
			}
		}
		((DataGridView)sender).ShowCellToolTips = true;
	}

	private void dataGridView_Skills_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		toolTip_0.Hide((Control)sender);
	}

	private void dataGridView_Skills_Scroll(object sender, ScrollEventArgs e)
	{
		bool_1 = true;
	}

	private void dataGridView_Skills_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_1)
		{
			bool_1 = false;
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		int num = 0;
		while (true)
		{
			if (num <= dataGridView_Skills.Rows.Count - 1)
			{
				if (dataGridView_Skills.Rows[num].Cells[0].FormattedValue.ToString() == textBox_0.Text)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		dataGridView_Skills.CurrentCell = dataGridView_Skills.Rows[num].Cells[0];
		dataGridView_Skills_SelectionChanged(null, null);
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		int num = 0;
		int rowIndex = dataGridView_Skills.CurrentCell.RowIndex;
		int num2 = rowIndex;
		while (true)
		{
			if (num2 <= dataGridView_Skills.Rows.Count - 1)
			{
				if (TextSearchHelper.Contains(dataGridView_Skills.Rows[num2].Cells[1].FormattedValue?.ToString(), textBox_1.Text))
				{
					break;
				}
				if (num2 == dataGridView_Skills.Rows.Count - 1 && num == 0)
				{
					num = 1;
					num2 = 0;
				}
				num2++;
				continue;
			}
			return;
		}
		dataGridView_Skills.CurrentCell = dataGridView_Skills.Rows[num2].Cells[1];
		dataGridView_Skills_SelectionChanged(null, null);
	}

	private void textBox_0_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			textBox_0_TextChanged(null, null);
		}
	}

	private void textBox_1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		int num = 0;
		int num2 = dataGridView_Skills.CurrentCell.RowIndex + 1;
		int num3 = num2;
		while (true)
		{
			if (num3 <= dataGridView_Skills.Rows.Count - 1)
			{
				if (TextSearchHelper.Contains(dataGridView_Skills.Rows[num3].Cells[1].FormattedValue?.ToString(), textBox_1.Text))
				{
					break;
				}
				if (num3 == dataGridView_Skills.Rows.Count - 1 && num == 0)
				{
					num = 1;
					num3 = 0;
				}
				num3++;
				continue;
			}
			return;
		}
		dataGridView_Skills.CurrentCell = dataGridView_Skills.Rows[num3].Cells[1];
		dataGridView_Skills_SelectionChanged(null, null);
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

	private void SelectSkillIdWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (dataGridView_Skills.RowCount > 0)
		{
			GProD.SelectSkillIdWindow_SelectedItemIndex = dataGridView_Skills.CurrentCell.RowIndex;
		}
	}

	private void SelectSkillIdWindow_SizeChanged(object sender, EventArgs e)
	{
		if (base.WindowState != FormWindowState.Maximized)
		{
			ACE.sTASKedit.Classes.Settings.Fields.SelectSkillIdWindow_Size = base.Size;
		}
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
		new ComponentResourceManager(typeof(SelectSkillIdWindow));
		dataGridView_Skills = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		richTextBox_0 = new RichTextBox();
		button_0 = new Button();
		button_1 = new Button();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		label_0 = new Label();
		label_1 = new Label();
		toolTip_0 = new ToolTip(icontainer_0);
		((ISupportInitialize)dataGridView_Skills).BeginInit();
		SuspendLayout();
		dataGridView_Skills.AllowUserToAddRows = false;
		dataGridView_Skills.AllowUserToDeleteRows = false;
		dataGridView_Skills.AllowUserToResizeColumns = false;
		dataGridView_Skills.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dataGridView_Skills.BackgroundColor = SystemColors.Window;
		dataGridView_Skills.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_Skills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_Skills.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1);
		dataGridView_Skills.Location = new Point(12, 12);
		dataGridView_Skills.Name = Class16.smethod_0(1649249869);
		dataGridView_Skills.ReadOnly = true;
		dataGridView_Skills.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_Skills.RowHeadersVisible = false;
		dataGridView_Skills.RowTemplate.Height = 18;
		dataGridView_Skills.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_Skills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_Skills.Size = new Size(392, 382);
		dataGridView_Skills.TabIndex = 0;
		dataGridView_Skills.CellMouseEnter += dataGridView_Skills_CellMouseEnter;
		dataGridView_Skills.CellMouseLeave += dataGridView_Skills_CellMouseLeave;
		dataGridView_Skills.Scroll += dataGridView_Skills_Scroll;
		dataGridView_Skills.SelectionChanged += dataGridView_Skills_SelectionChanged;
		dataGridView_Skills.MouseEnter += dataGridView_Skills_MouseEnter;
		dataGridView_Skills.MouseMove += dataGridView_Skills_MouseMove;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649249895);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649249910);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 60;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649249923);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		richTextBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		richTextBox_0.BackColor = Color.FromArgb(32, 32, 32);
		richTextBox_0.BorderStyle = BorderStyle.FixedSingle;
		richTextBox_0.Font = new Font(Class16.smethod_0(1649246588), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		richTextBox_0.ForeColor = Color.White;
		richTextBox_0.Location = new Point(410, 12);
		richTextBox_0.Name = Class16.smethod_0(1649249946);
		richTextBox_0.Size = new Size(392, 470);
		richTextBox_0.TabIndex = 1;
		richTextBox_0.Text = string.Empty;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_0.Location = new Point(11, 459);
		button_0.Name = Class16.smethod_0(1649253385);
		button_0.Size = new Size(190, 23);
		button_0.TabIndex = 2;
		button_0.Text = Class16.smethod_0(1649253884);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_1.Location = new Point(215, 459);
		button_1.Name = Class16.smethod_0(1649262492);
		button_1.Size = new Size(190, 23);
		button_1.TabIndex = 3;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		textBox_0.Location = new Point(124, 402);
		textBox_0.Name = Class16.smethod_0(1649249982);
		textBox_0.Size = new Size(280, 20);
		textBox_0.TabIndex = 4;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.KeyPress += textBox_0_KeyPress;
		textBox_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		textBox_1.Location = new Point(124, 431);
		textBox_1.Name = Class16.smethod_0(1649250002);
		textBox_1.Size = new Size(280, 20);
		textBox_1.TabIndex = 5;
		textBox_1.TextChanged += textBox_1_TextChanged;
		textBox_1.KeyPress += textBox_1_KeyPress;
		label_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_0.AutoSize = true;
		label_0.Location = new Point(8, 406);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(71, 13);
		label_0.TabIndex = 6;
		label_0.Text = Class16.smethod_0(1649247161);
		label_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_1.AutoSize = true;
		label_1.Location = new Point(8, 435);
		label_1.Name = Class16.smethod_0(1648912083);
		label_1.Size = new Size(90, 13);
		label_1.TabIndex = 7;
		label_1.Text = Class16.smethod_0(1649247189);
		toolTip_0.AutoPopDelay = 90000;
		toolTip_0.InitialDelay = 500;
		toolTip_0.ReshowDelay = 100;
		toolTip_0.UseAnimation = false;
		toolTip_0.UseFading = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Window;
		base.ClientSize = new Size(812, 493);
		base.Controls.Add(label_1);
		base.Controls.Add(label_0);
		base.Controls.Add(textBox_1);
		base.Controls.Add(textBox_0);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(richTextBox_0);
		base.Controls.Add(dataGridView_Skills);
		base.Icon = Resources.edit;
		MinimumSize = new Size(828, 532);
		base.Name = Class16.smethod_0(1649250032);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649250032);
		base.FormClosing += SelectSkillIdWindow_FormClosing;
		base.Load += SelectSkillIdWindow_Load;
		base.SizeChanged += SelectSkillIdWindow_SizeChanged;
		((ISupportInitialize)dataGridView_Skills).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void dataGridView_Skills_MouseEnter(object sender, EventArgs e)
	{
		if (Form.ActiveForm == this)
		{
			((Control)sender).Focus();
		}
	}

	public void SetLocalization()
	{
		Text = GProD.TX(6023);
		dataGridViewTextBoxColumn_0.HeaderText = GProD.TX(6024);
		dataGridViewTextBoxColumn_1.HeaderText = GProD.TX(6025);
		label_0.Text = GProD.TX(6026);
		label_1.Text = GProD.TX(6027);
		button_0.Text = GProD.TX(6028);
		button_1.Text = GProD.TX(6029);
	}
}
