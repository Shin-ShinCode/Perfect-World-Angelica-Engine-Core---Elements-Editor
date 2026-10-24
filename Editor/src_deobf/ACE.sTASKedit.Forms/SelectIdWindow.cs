using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.sTASKedit.Classes;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;

namespace ACE.sTASKedit.Forms;

public class SelectIdWindow : Form
{
	private int int_0;

	private int int_1;

	private bool bool_0;

	private bool bool_1;

	public ArrayList ids;

	private List<int> list_0;

	private IContainer icontainer_0;

	private ComboBox comboBox_0;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private Label label_0;

	private Label label_1;

	private CheckBox checkBox_0;

	private DataGridView dataGridView_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	public DataGridView dataGridView_Elements;

	private ToolTip toolTip_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	public SelectIdWindow(int currentid, List<int> listindexes, int type = -1)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		int_0 = currentid;
		list_0 = listindexes;
		int_1 = type;
		SetLocalization();
		if (ACE.sTASKedit.Classes.Settings.Fields.SelectIdWindow_Size.Width > 0 && ACE.sTASKedit.Classes.Settings.Fields.SelectIdWindow_Size.Height > 0)
		{
			base.Size = ACE.sTASKedit.Classes.Settings.Fields.SelectIdWindow_Size;
		}
		dataGridView_Elements.Columns[0].DataPropertyName = Class16.smethod_0(1649077794);
		dataGridView_Elements.Columns[1].DataPropertyName = Class16.smethod_0(1648960225);
		dataGridView_Elements.Columns[2].DataPropertyName = Class16.smethod_0(1648936731);
		dataGridView_0.Columns[0].DataPropertyName = Class16.smethod_0(1649246974);
		dataGridView_0.Columns[1].DataPropertyName = Class16.smethod_0(1649246977);
		if (int_1 == 2)
		{
			dataGridView_Elements.Columns[1].Width = GProD.ElementIconWidth + 1;
			dataGridView_Elements.RowTemplate.Height = GProD.ElementIconHeight + 1;
			dataGridView_Elements.Columns[1].Visible = true;
		}
		else
		{
			dataGridView_Elements.Columns[1].Visible = false;
		}
	}

	private void SelectIdWindow_Load(object sender, EventArgs e)
	{
		comboBox_0.Items.Clear();
		for (int i = 0; i < list_0.Count; i++)
		{
			int num = list_0[i];
			if (GProD.eLC.Version >= 191 && num >= 58)
			{
				num--;
			}
			comboBox_0.Items.Add(GProD.eLC.Lists[num].ListName + Class16.smethod_0(1648899468) + GProD.eLC.Lists[num].elementValues.Length + Class16.smethod_0(1648942897));
		}
		if (comboBox_0.Items.Count > 0)
		{
			comboBox_0.SelectedIndex = 0;
			dataGridView_Elements.CurrentCell = dataGridView_Elements.Rows[0].Cells[0];
			dataGridView_Elements_SelectionChanged(null, null);
			if (int_0 != 0)
			{
				textBox_0.Text = int_0.ToString();
			}
			else
			{
				textBox_0.Text = GProD.SelectId.ToString();
			}
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		bool_0 = true;
		int num = list_0[comboBox_0.SelectedIndex];
		if (GProD.eLC.Version >= 191 && num >= 58)
		{
			num--;
		}
		if (num != GProD.eLC.ConversationListIndex)
		{
			List<DGW_Element_Row> list = new List<DGW_Element_Row>();
			list.Add(new DGW_Element_Row(Class16.smethod_0(1648924112), GProD.GetItemIcon(string.Empty), GProD.TX(402)));
			if (list_0[comboBox_0.SelectedIndex] == 150)
			{
				list.Add(new DGW_Element_Row(Class16.smethod_0(1648919381), GProD.GetItemIcon(string.Empty), GProD.TX(2531)));
			}
			int fieldIndex = -1;
			int fieldIndex2 = -1;
			for (int i = 0; i < GProD.eLC.Lists[num].elementFields.Length; i++)
			{
				if (GProD.eLC.Lists[num].elementFields[i] == Class16.smethod_0(1648936731))
				{
					fieldIndex = i;
					break;
				}
			}
			for (int j = 0; j < GProD.eLC.Lists[num].elementFields.Length; j++)
			{
				if (GProD.eLC.Lists[num].elementFields[j] == Class16.smethod_0(1648960592))
				{
					fieldIndex2 = j;
					break;
				}
			}
			if (GProD.eLC.Lists[num].elementFields[0] == Class16.smethod_0(1648941057))
			{
				for (int k = 0; k < GProD.eLC.Lists[num].elementValues.Length; k++)
				{
					if (int_1 == 2)
					{
						list.Add(new DGW_Element_Row(GProD.eLC.GetValue(num, k, 0), GProD.GetItemIcon(GProD.eLC.GetValue(num, k, fieldIndex2)), GProD.eLC.GetValue(num, k, fieldIndex)));
					}
					else
					{
						list.Add(new DGW_Element_Row(GProD.eLC.GetValue(num, k, 0), null, GProD.eLC.GetValue(num, k, fieldIndex)));
					}
				}
			}
			dataGridView_Elements.DataSource = list;
		}
		bool_0 = false;
	}

	private void dataGridView_Elements_SelectionChanged(object sender, EventArgs e)
	{
		int num = list_0[comboBox_0.SelectedIndex];
		if (GProD.eLC.Version >= 191 && num >= 58)
		{
			num--;
		}
		int num2 = dataGridView_Elements.CurrentCell.RowIndex - 1;
		if (list_0[comboBox_0.SelectedIndex] == 150)
		{
			num2--;
		}
		int firstDisplayedScrollingRowIndex = dataGridView_0.FirstDisplayedScrollingRowIndex;
		if (num2 >= 0 && !bool_0)
		{
			List<DGW_Prop_Row> list = new List<DGW_Prop_Row>();
			for (int i = 0; i < GProD.eLC.Lists[num].elementValues[num2].Length; i++)
			{
				list.Add(new DGW_Prop_Row(GProD.eLC.Lists[num].elementFields[i], GProD.eLC.GetValue(num, num2, i)));
			}
			dataGridView_0.DataSource = list;
		}
		else
		{
			dataGridView_0.DataSource = new List<DGW_Prop_Row>();
		}
		if (firstDisplayedScrollingRowIndex > -1 && num2 > -1 && dataGridView_0.RowCount > 0)
		{
			dataGridView_0.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
		}
	}

	private void dataGridView_Elements_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (!bool_1 && e.ColumnIndex >= 0 && e.ColumnIndex < 3 && e.RowIndex > -1)
		{
			try
			{
				int num = Convert.ToInt32(dataGridView_Elements.Rows[e.RowIndex].Cells[0].Value);
				if (num > 0 && ACE.sTASKedit.Classes.Settings.Fields.EnableShowInfo)
				{
					string text = string.Empty;
					string text2 = string.Empty;
					((DataGridView)sender).ShowCellToolTips = false;
					if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements)
					{
						switch (int_1)
						{
						case 0:
							text += GlobalFunctions.ColorClean(GProD.GetMonsterNPCMineName(num));
							text2 = text2 + GlobalFunctions.ColorClean(GProD.GetMonsterNPCMineProps(num)) + Class16.smethod_0(1648941987);
							break;
						case 1:
							text += GlobalFunctions.ColorClean(GProD.GetTitleName(num));
							text2 = text2 + GlobalFunctions.ColorClean(GProD.GetTitleProps(num)) + Class16.smethod_0(1648941987);
							break;
						case 2:
							text += GlobalFunctions.ColorClean(GProD.GetHomeItemName(num));
							text2 = text2 + GlobalFunctions.ColorClean(GProD.GetHomeItemProps(num)) + Class16.smethod_0(1648941987);
							break;
						}
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

	private void dataGridView_Elements_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		toolTip_0.Hide((Control)sender);
	}

	private void dataGridView_Elements_Scroll(object sender, ScrollEventArgs e)
	{
		bool_1 = true;
	}

	private void dataGridView_Elements_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_1)
		{
			bool_1 = false;
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
		new ComponentResourceManager(typeof(SelectIdWindow));
		comboBox_0 = new ComboBox();
		dataGridView_Elements = new DataGridView();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		button_0 = new Button();
		button_1 = new Button();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		label_0 = new Label();
		label_1 = new Label();
		checkBox_0 = new CheckBox();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		toolTip_0 = new ToolTip(icontainer_0);
		((ISupportInitialize)dataGridView_Elements).BeginInit();
		((ISupportInitialize)dataGridView_0).BeginInit();
		SuspendLayout();
		comboBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(12, 12);
		comboBox_0.Name = Class16.smethod_0(1649246987);
		comboBox_0.Size = new Size(630, 21);
		comboBox_0.TabIndex = 999;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		dataGridView_Elements.AllowUserToAddRows = false;
		dataGridView_Elements.AllowUserToDeleteRows = false;
		dataGridView_Elements.AllowUserToResizeColumns = false;
		dataGridView_Elements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dataGridView_Elements.BackgroundColor = SystemColors.Window;
		dataGridView_Elements.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_Elements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_Elements.Columns.AddRange(dataGridViewTextBoxColumn_2, dataGridViewImageColumn_0, dataGridViewTextBoxColumn_3);
		dataGridView_Elements.Location = new Point(12, 41);
		dataGridView_Elements.Name = Class16.smethod_0(1649253659);
		dataGridView_Elements.ReadOnly = true;
		dataGridView_Elements.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_Elements.RowHeadersVisible = false;
		dataGridView_Elements.RowTemplate.Height = 18;
		dataGridView_Elements.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_Elements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_Elements.Size = new Size(312, 220);
		dataGridView_Elements.TabIndex = 1;
		dataGridView_Elements.CellMouseEnter += dataGridView_Elements_CellMouseEnter;
		dataGridView_Elements.CellMouseLeave += dataGridView_Elements_CellMouseLeave;
		dataGridView_Elements.Scroll += dataGridView_Elements_Scroll;
		dataGridView_Elements.SelectionChanged += dataGridView_Elements_SelectionChanged;
		dataGridView_Elements.MouseEnter += dataGridView_0_MouseEnter;
		dataGridView_Elements.MouseMove += dataGridView_Elements_MouseMove;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1649247008);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1649247026);
		dataGridViewTextBoxColumn_2.ReadOnly = true;
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_2.Width = 60;
		dataGridViewImageColumn_0.HeaderText = string.Empty;
		dataGridViewImageColumn_0.Name = Class16.smethod_0(1649247049);
		dataGridViewImageColumn_0.ReadOnly = true;
		dataGridViewImageColumn_0.Resizable = DataGridViewTriState.False;
		dataGridViewImageColumn_0.Width = 20;
		dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1649247074);
		dataGridViewTextBoxColumn_3.ReadOnly = true;
		dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.NotSortable;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_0.Location = new Point(11, 355);
		button_0.Name = Class16.smethod_0(1649253385);
		button_0.Size = new Size(150, 23);
		button_0.TabIndex = 2;
		button_0.Text = Class16.smethod_0(1649253884);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_1.Location = new Point(175, 355);
		button_1.Name = Class16.smethod_0(1649262492);
		button_1.Size = new Size(150, 23);
		button_1.TabIndex = 3;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		textBox_0.Location = new Point(124, 269);
		textBox_0.Name = Class16.smethod_0(1649247099);
		textBox_0.Size = new Size(200, 20);
		textBox_0.TabIndex = 4;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.KeyPress += textBox_0_KeyPress;
		textBox_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		textBox_1.Location = new Point(124, 298);
		textBox_1.Name = Class16.smethod_0(1649247129);
		textBox_1.Size = new Size(200, 20);
		textBox_1.TabIndex = 5;
		textBox_1.TextChanged += textBox_1_TextChanged;
		textBox_1.KeyPress += textBox_1_KeyPress;
		label_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_0.AutoSize = true;
		label_0.Location = new Point(8, 273);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(71, 13);
		label_0.TabIndex = 6;
		label_0.Text = Class16.smethod_0(1649247161);
		label_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_1.AutoSize = true;
		label_1.Location = new Point(8, 302);
		label_1.Name = Class16.smethod_0(1648912083);
		label_1.Size = new Size(90, 13);
		label_1.TabIndex = 7;
		label_1.Text = Class16.smethod_0(1649247189);
		checkBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		checkBox_0.AutoSize = true;
		checkBox_0.Checked = true;
		checkBox_0.CheckState = CheckState.Checked;
		checkBox_0.Location = new Point(12, 330);
		checkBox_0.Name = Class16.smethod_0(1649247203);
		checkBox_0.Size = new Size(115, 17);
		checkBox_0.TabIndex = 8;
		checkBox_0.Text = Class16.smethod_0(1649246209);
		checkBox_0.UseVisualStyleBackColor = true;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_0.BackgroundColor = SystemColors.Window;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1);
		dataGridView_0.Location = new Point(330, 41);
		dataGridView_0.Name = Class16.smethod_0(1649246235);
		dataGridView_0.ReadOnly = true;
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.RowTemplate.Height = 18;
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.Size = new Size(312, 336);
		dataGridView_0.TabIndex = 9;
		dataGridView_0.MouseEnter += dataGridView_0_MouseEnter;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649029180);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649246268);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 61;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648941098);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649246283);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		toolTip_0.AutoPopDelay = 90000;
		toolTip_0.InitialDelay = 500;
		toolTip_0.ReshowDelay = 100;
		toolTip_0.UseAnimation = false;
		toolTip_0.UseFading = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Window;
		base.ClientSize = new Size(654, 389);
		base.Controls.Add(dataGridView_0);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(label_1);
		base.Controls.Add(label_0);
		base.Controls.Add(textBox_1);
		base.Controls.Add(textBox_0);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(dataGridView_Elements);
		base.Controls.Add(comboBox_0);
		base.Icon = Resources.edit;
		MinimumSize = new Size(670, 428);
		base.Name = Class16.smethod_0(1649246310);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649246323);
		base.FormClosing += SelectIdWindow_FormClosing;
		base.Load += SelectIdWindow_Load;
		base.SizeChanged += SelectIdWindow_SizeChanged;
		((ISupportInitialize)dataGridView_Elements).EndInit();
		((ISupportInitialize)dataGridView_0).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (checkBox_0.Checked)
		{
			int num = 0;
			while (true)
			{
				if (num >= list_0.Count)
				{
					return;
				}
				int num2 = 1;
				if (list_0[num] == 150)
				{
					if (textBox_0.Text == Class16.smethod_0(1648919381))
					{
						break;
					}
					num2++;
				}
				int num3 = list_0[num];
				if (GProD.eLC.Version >= 191 && num3 >= 58)
				{
					num3--;
				}
				for (int i = 0; i < GProD.eLC.Lists[num3].elementValues.Length; i++)
				{
					if (GProD.eLC.GetValue(num3, i, 0) == textBox_0.Text)
					{
						comboBox_0.SelectedIndex = num;
						dataGridView_Elements.CurrentCell = dataGridView_Elements.Rows[i + num2].Cells[0];
						dataGridView_Elements_SelectionChanged(null, null);
						return;
					}
				}
				num++;
			}
			comboBox_0.SelectedIndex = num;
			dataGridView_Elements.CurrentCell = dataGridView_Elements.Rows[1].Cells[0];
			dataGridView_Elements_SelectionChanged(null, null);
			return;
		}
		int num4 = 0;
		while (true)
		{
			if (num4 <= dataGridView_Elements.Rows.Count - 1)
			{
				if (dataGridView_Elements.Rows[num4].Cells[0].FormattedValue.ToString() == textBox_0.Text)
				{
					break;
				}
				num4++;
				continue;
			}
			return;
		}
		dataGridView_Elements.CurrentCell = dataGridView_Elements.Rows[num4].Cells[0];
		dataGridView_Elements_SelectionChanged(null, null);
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		if (checkBox_0.Checked)
		{
			int num = 0;
			int selectedIndex = comboBox_0.SelectedIndex;
			int num2 = dataGridView_Elements.CurrentCell.RowIndex - 1;
			if (num2 < 0)
			{
				num2 = 0;
			}
			int num3 = selectedIndex;
			while (true)
			{
				if (num3 >= list_0.Count)
				{
					return;
				}
				int num4 = 1;
				if (list_0[num3] == 150)
				{
					if (TextSearchHelper.Contains(GProD.TX(2531), textBox_1.Text))
					{
						break;
					}
					num4++;
				}
				int num5 = list_0[num3];
				if (GProD.eLC.Version >= 191 && num5 >= 58)
				{
					num5--;
				}
				int fieldIndex = 0;
				for (int i = 0; i < GProD.eLC.Lists[num5].elementFields.Length; i++)
				{
					if (GProD.eLC.Lists[num5].elementFields[i] == Class16.smethod_0(1648936731))
					{
						fieldIndex = i;
						break;
					}
				}
				for (int j = num2; j < GProD.eLC.Lists[num5].elementValues.Length; j++)
				{
					if (TextSearchHelper.Contains(GProD.eLC.GetValue(num5, j, fieldIndex), textBox_1.Text))
					{
						comboBox_0.SelectedIndex = num3;
						dataGridView_Elements.CurrentCell = dataGridView_Elements.Rows[j + num4].Cells[0];
						dataGridView_Elements_SelectionChanged(null, null);
						return;
					}
				}
				num2 = 0;
				if (num3 == list_0.Count - 1 && num == 0)
				{
					num = 1;
					num3 = -1;
				}
				num3++;
			}
			comboBox_0.SelectedIndex = num3;
			dataGridView_Elements.CurrentCell = dataGridView_Elements.Rows[1].Cells[0];
			dataGridView_Elements_SelectionChanged(null, null);
			return;
		}
		int num6 = 0;
		int rowIndex = dataGridView_Elements.CurrentCell.RowIndex;
		int num7 = rowIndex;
		while (true)
		{
			if (num7 <= dataGridView_Elements.Rows.Count - 1)
			{
				if (TextSearchHelper.Contains(dataGridView_Elements.Rows[num7].Cells[2].FormattedValue?.ToString(), textBox_1.Text))
				{
					break;
				}
				if (num7 == dataGridView_Elements.Rows.Count - 1 && num6 == 0)
				{
					num6 = 1;
					num7 = 0;
				}
				num7++;
				continue;
			}
			return;
		}
		dataGridView_Elements.CurrentCell = dataGridView_Elements.Rows[num7].Cells[2];
		dataGridView_Elements_SelectionChanged(null, null);
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
		if (checkBox_0.Checked)
		{
			int num = 0;
			int selectedIndex = comboBox_0.SelectedIndex;
			int num2 = dataGridView_Elements.CurrentCell.RowIndex;
			if (num2 < 0)
			{
				num2 = 0;
			}
			for (int i = selectedIndex; i < list_0.Count; i++)
			{
				int num3 = list_0[i];
				if (GProD.eLC.Version >= 191 && num3 >= 58)
				{
					num3--;
				}
				int fieldIndex = 0;
				for (int j = 0; j < GProD.eLC.Lists[num3].elementFields.Length; j++)
				{
					if (GProD.eLC.Lists[num3].elementFields[j] == Class16.smethod_0(1648936731))
					{
						fieldIndex = j;
						break;
					}
				}
				for (int k = num2; k < GProD.eLC.Lists[num3].elementValues.Length; k++)
				{
					if (TextSearchHelper.Contains(GProD.eLC.GetValue(num3, k, fieldIndex), textBox_1.Text))
					{
						comboBox_0.SelectedIndex = i;
						dataGridView_Elements.CurrentCell = dataGridView_Elements.Rows[k + 1].Cells[0];
						dataGridView_Elements_SelectionChanged(null, null);
						return;
					}
				}
				num2 = 0;
				if (i == list_0.Count - 1 && num == 0)
				{
					num = 1;
					i = -1;
				}
			}
			return;
		}
		int num4 = 0;
		int num5 = dataGridView_Elements.CurrentCell.RowIndex + 1;
		int num6 = num5;
		while (true)
		{
			if (num6 <= dataGridView_Elements.Rows.Count - 1)
			{
				if (TextSearchHelper.Contains(dataGridView_Elements.Rows[num6].Cells[1].FormattedValue?.ToString(), textBox_1.Text))
				{
					break;
				}
				if (num6 == dataGridView_Elements.Rows.Count - 1 && num4 == 0)
				{
					num4 = 1;
					num6 = 0;
				}
				num6++;
				continue;
			}
			return;
		}
		dataGridView_Elements.CurrentCell = dataGridView_Elements.Rows[num6].Cells[1];
		dataGridView_Elements_SelectionChanged(null, null);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (dataGridView_Elements.Rows.Count > 0)
		{
			ArrayList arrayList = new ArrayList();
			ids = new ArrayList();
			arrayList = Extensions.SetIndexesRows(dataGridView_Elements.SelectedCells);
			for (int i = 0; i < arrayList.Count; i++)
			{
				ids.Add(dataGridView_Elements.Rows[Convert.ToInt32(arrayList[i])].Cells[0].Value);
			}
			base.DialogResult = DialogResult.OK;
		}
		Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void SelectIdWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (dataGridView_Elements.Rows.Count > 0)
		{
			GProD.SelectId = Convert.ToInt32(dataGridView_Elements.Rows[dataGridView_Elements.CurrentCell.RowIndex].Cells[0].Value);
		}
	}

	private void SelectIdWindow_SizeChanged(object sender, EventArgs e)
	{
		if (base.WindowState != FormWindowState.Maximized)
		{
			ACE.sTASKedit.Classes.Settings.Fields.SelectIdWindow_Size = base.Size;
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
		Text = GProD.TX(6039);
		dataGridViewTextBoxColumn_2.HeaderText = GProD.TX(6040);
		dataGridViewTextBoxColumn_3.HeaderText = GProD.TX(6025);
		dataGridViewTextBoxColumn_0.HeaderText = GProD.TX(6049);
		dataGridViewTextBoxColumn_1.HeaderText = GProD.TX(6050);
		label_0.Text = GProD.TX(6026);
		label_1.Text = GProD.TX(6027);
		checkBox_0.Text = GProD.TX(6048);
		button_0.Text = GProD.TX(6001);
		button_1.Text = GProD.TX(6002);
	}
}
