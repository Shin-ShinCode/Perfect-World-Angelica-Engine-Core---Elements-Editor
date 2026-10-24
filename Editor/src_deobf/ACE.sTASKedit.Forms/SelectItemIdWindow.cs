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

public class SelectItemIdWindow : Form
{
	private int int_0;

	public bool CommonItem;

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

	private RichTextBox richTextBox_0;

	private CheckBox checkBox_0;

	private DataGridView dataGridView_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private ToolTip toolTip_0;

	private SplitContainer splitContainer_0;

	public DataGridView dataGridView_Items;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	public SelectItemIdWindow(int currentid, List<int> listindexes)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		int_0 = currentid;
		list_0 = listindexes;
		SetLocalization();
		try
		{
			richTextBox_0.Font = new Font(GProD.PWUIFont.Families[0], 8f, FontStyle.Bold);
		}
		catch
		{
		}
		if (ACE.sTASKedit.Classes.Settings.Fields.SelectItemIdWindow_Size.Width > 0 && ACE.sTASKedit.Classes.Settings.Fields.SelectItemIdWindow_Size.Height > 0)
		{
			base.Size = ACE.sTASKedit.Classes.Settings.Fields.SelectItemIdWindow_Size;
		}
		dataGridView_Items.Columns[0].DataPropertyName = Class16.smethod_0(1649077794);
		dataGridView_Items.Columns[1].DataPropertyName = Class16.smethod_0(1648960225);
		dataGridView_Items.Columns[2].DataPropertyName = Class16.smethod_0(1648936731);
		dataGridView_0.Columns[0].DataPropertyName = Class16.smethod_0(1649246974);
		dataGridView_0.Columns[1].DataPropertyName = Class16.smethod_0(1649246977);
		dataGridView_Items.Columns[1].Width = GProD.ElementIconWidth + 1;
		dataGridView_Items.RowTemplate.Height = GProD.ElementIconHeight + 1;
	}

	private void SelectItemIdWindow_Load(object sender, EventArgs e)
	{
		for (int i = 0; i < list_0.Count; i += 2)
		{
			if (GProD.eLC.Version >= list_0[i + 1])
			{
				comboBox_0.Items.Add(GProD.eLC.Lists[list_0[i]].ListName + Class16.smethod_0(1648899468) + GProD.eLC.Lists[list_0[i]].elementValues.Length + Class16.smethod_0(1648942897));
			}
		}
		if (comboBox_0.Items.Count > 0)
		{
			comboBox_0.SelectedIndex = GProD.SelectItemIdWindow_SelectedListIndex;
			dataGridView_Items.CurrentCell = dataGridView_Items.Rows[GProD.SelectItemIdWindow_SelectedItemIndex].Cells[0];
			dataGridView_Items_SelectionChanged(null, null);
			if (int_0 != 0)
			{
				textBox_0.Text = int_0.ToString();
			}
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		bool_0 = true;
		int num = 3;
		int selectedIndex = comboBox_0.SelectedIndex;
		num = list_0[selectedIndex * 2];
		if (num == 28)
		{
			CommonItem = false;
		}
		else
		{
			CommonItem = true;
		}
		int num2 = 297;
		if (GProD.eLC.Version >= 191 && num2 >= 58)
		{
			num2--;
		}
		if (num != GProD.eLC.ConversationListIndex)
		{
			List<DGW_Element_Row> list = new List<DGW_Element_Row>();
			list.Add(new DGW_Element_Row(Class16.smethod_0(1648924112), GProD.GetItemIcon(string.Empty), GProD.TX(402)));
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
			if (num != num2)
			{
				for (int j = 0; j < GProD.eLC.Lists[num].elementFields.Length; j++)
				{
					string text = GProD.eLC.Lists[num].elementFields[j];
					if (text == Class16.smethod_0(1648960592) || text == Class16.smethod_0(1649246366))
					{
						fieldIndex2 = j;
						break;
					}
				}
			}
			else
			{
				for (int k = 0; k < GProD.eLC.Lists[num].elementFields.Length; k++)
				{
					string text2 = GProD.eLC.Lists[num].elementFields[k];
					if (text2 == Class16.smethod_0(1649246383))
					{
						fieldIndex2 = k;
						break;
					}
				}
			}
			if (GProD.eLC.Lists[num].elementFields[0] == Class16.smethod_0(1648941057))
			{
				for (int l = 0; l < GProD.eLC.Lists[num].elementValues.Length; l++)
				{
					list.Add(new DGW_Element_Row(GProD.eLC.GetValue(num, l, 0), GProD.GetItemIcon(GProD.eLC.GetValue(num, l, fieldIndex2)), GProD.eLC.GetValue(num, l, fieldIndex)));
				}
			}
			dataGridView_Items.DataSource = list;
		}
		bool_0 = false;
	}

	private void dataGridView_Items_SelectionChanged(object sender, EventArgs e)
	{
		int num = 3;
		richTextBox_0.Text = string.Empty;
		richTextBox_0.SelectionColor = Color.White;
		int selectedIndex = comboBox_0.SelectedIndex;
		num = list_0[selectedIndex * 2];
		int num2 = dataGridView_Items.CurrentCell.RowIndex - 1;
		if (num2 >= 0)
		{
			if (num != GProD.eLC.ConversationListIndex && !bool_0)
			{
				string text = string.Empty;
				if (GProD.eLC.Lists[num].elementFields[0] == Class16.smethod_0(1648941057))
				{
					int fieldIndex = -1;
					for (int i = 0; i < GProD.eLC.Lists[num].elementFields.Length; i++)
					{
						if (GProD.eLC.Lists[num].elementFields[i] == Class16.smethod_0(1648955728))
						{
							fieldIndex = i;
							break;
						}
					}
					string value = GProD.eLC.GetValue(num, num2, fieldIndex);
					if (value != Class16.smethod_0(1648924112) && value != null)
					{
						int.TryParse(value, out var result);
						if ((result & 0x40) != 0)
						{
							text = text + GProD.TX(4006) + Class16.smethod_0(1648898460);
						}
						if ((result & 0x8000) != 0)
						{
							text += GProD.TX(4015);
						}
						if ((result & 0x2000) != 0)
						{
							text += GProD.TX(4013);
						}
					}
					if (GProD.eLC.Version >= 191 && num >= 58)
					{
						num++;
					}
					if (num == 124)
					{
						int num3 = 124;
						if (GProD.eLC.Version >= 191 && num3 >= 58)
						{
							num3--;
						}
						string elParamValue = Extensions.GetElParamValue(GProD.eLC, num3, num2, Class16.smethod_0(1648970107));
						if (elParamValue != null)
						{
							text = text + GProD.GetSkillDesc(Convert.ToInt32(elParamValue)) + Class16.smethod_0(1648898460);
						}
					}
					if (GProD.eLC.Version >= 191 && num >= 58)
					{
						num--;
					}
					if (value != Class16.smethod_0(1648924112) && value != null)
					{
						text += Extensions.DecodingProcType(value);
					}
					text += GProD.GetItemDesc(Convert.ToInt32(dataGridView_Items.Rows[num2 + 1].Cells[0].Value));
					richTextBox_0.Rtf = mConvert.StringToRTF(text, richTextBox_0.ForeColor, richTextBox_0.Font);
				}
			}
		}
		else
		{
			richTextBox_0.Text = string.Empty;
		}
		int firstDisplayedScrollingRowIndex = dataGridView_0.FirstDisplayedScrollingRowIndex;
		if (num2 >= 0 && !bool_0)
		{
			List<DGW_Prop_Row> list = new List<DGW_Prop_Row>();
			for (int j = 0; j < GProD.eLC.Lists[num].elementValues[num2].Length; j++)
			{
				list.Add(new DGW_Prop_Row(GProD.eLC.Lists[num].elementFields[j], GProD.eLC.GetValue(num, num2, j)));
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
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(SelectItemIdWindow));
		comboBox_0 = new ComboBox();
		dataGridView_Items = new DataGridView();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		button_0 = new Button();
		button_1 = new Button();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		label_0 = new Label();
		label_1 = new Label();
		richTextBox_0 = new RichTextBox();
		checkBox_0 = new CheckBox();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		toolTip_0 = new ToolTip(icontainer_0);
		splitContainer_0 = new SplitContainer();
		((ISupportInitialize)dataGridView_Items).BeginInit();
		((ISupportInitialize)dataGridView_0).BeginInit();
		((ISupportInitialize)splitContainer_0).BeginInit();
		splitContainer_0.Panel1.SuspendLayout();
		splitContainer_0.Panel2.SuspendLayout();
		splitContainer_0.SuspendLayout();
		SuspendLayout();
		comboBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(12, 12);
		comboBox_0.Name = Class16.smethod_0(1649246394);
		comboBox_0.Size = new Size(630, 21);
		comboBox_0.TabIndex = 999;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		dataGridView_Items.AllowUserToAddRows = false;
		dataGridView_Items.AllowUserToDeleteRows = false;
		dataGridView_Items.AllowUserToResizeColumns = false;
		dataGridView_Items.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dataGridView_Items.BackgroundColor = SystemColors.Window;
		dataGridView_Items.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_Items.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_Items.Columns.AddRange(dataGridViewTextBoxColumn_2, dataGridViewImageColumn_0, dataGridViewTextBoxColumn_3);
		dataGridView_Items.Location = new Point(12, 41);
		dataGridView_Items.Name = Class16.smethod_0(1649246428);
		dataGridView_Items.ReadOnly = true;
		dataGridView_Items.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 134);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dataGridView_Items.RowHeadersDefaultCellStyle = dataGridViewCellStyle;
		dataGridView_Items.RowHeadersVisible = false;
		dataGridView_Items.RowTemplate.Height = 20;
		dataGridView_Items.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_Items.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_Items.Size = new Size(312, 220);
		dataGridView_Items.TabIndex = 1;
		dataGridView_Items.CellMouseEnter += dataGridView_Items_CellMouseEnter;
		dataGridView_Items.CellMouseLeave += dataGridView_Items_CellMouseLeave;
		dataGridView_Items.Scroll += dataGridView_Items_Scroll;
		dataGridView_Items.SelectionChanged += dataGridView_Items_SelectionChanged;
		dataGridView_Items.MouseEnter += dataGridView_0_MouseEnter;
		dataGridView_Items.MouseMove += dataGridView_Items_MouseMove;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1649246453);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1649246468);
		dataGridViewTextBoxColumn_2.ReadOnly = true;
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_2.Width = 60;
		dataGridViewImageColumn_0.HeaderText = string.Empty;
		dataGridViewImageColumn_0.Name = Class16.smethod_0(1649246480);
		dataGridViewImageColumn_0.ReadOnly = true;
		dataGridViewImageColumn_0.Resizable = DataGridViewTriState.False;
		dataGridViewImageColumn_0.Width = 20;
		dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1649246510);
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
		textBox_0.Name = Class16.smethod_0(1649246532);
		textBox_0.Size = new Size(200, 20);
		textBox_0.TabIndex = 4;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.KeyPress += textBox_0_KeyPress;
		textBox_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		textBox_1.Location = new Point(124, 298);
		textBox_1.Name = Class16.smethod_0(1649246559);
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
		richTextBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		richTextBox_0.BackColor = Color.FromArgb(32, 32, 32);
		richTextBox_0.BorderStyle = BorderStyle.FixedSingle;
		richTextBox_0.Font = new Font(Class16.smethod_0(1649246588), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		richTextBox_0.ForeColor = Color.White;
		richTextBox_0.Location = new Point(0, 0);
		richTextBox_0.MinimumSize = new Size(313, 109);
		richTextBox_0.Name = Class16.smethod_0(1649246594);
		richTextBox_0.Size = new Size(313, 109);
		richTextBox_0.TabIndex = 8;
		richTextBox_0.Text = string.Empty;
		checkBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		checkBox_0.AutoSize = true;
		checkBox_0.Checked = true;
		checkBox_0.CheckState = CheckState.Checked;
		checkBox_0.Location = new Point(12, 330);
		checkBox_0.Name = Class16.smethod_0(1649247203);
		checkBox_0.Size = new Size(115, 17);
		checkBox_0.TabIndex = 9;
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
		dataGridView_0.Location = new Point(0, 0);
		dataGridView_0.Name = Class16.smethod_0(1649246235);
		dataGridView_0.ReadOnly = true;
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.RowTemplate.Height = 18;
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.Size = new Size(312, 220);
		dataGridView_0.TabIndex = 10;
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
		splitContainer_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		splitContainer_0.Location = new Point(330, 41);
		splitContainer_0.MinimumSize = new Size(312, 337);
		splitContainer_0.Name = Class16.smethod_0(1648931759);
		splitContainer_0.Orientation = Orientation.Horizontal;
		splitContainer_0.Panel1.Controls.Add(dataGridView_0);
		splitContainer_0.Panel2.Controls.Add(richTextBox_0);
		splitContainer_0.Panel2MinSize = 109;
		splitContainer_0.Size = new Size(312, 337);
		splitContainer_0.SplitterDistance = 220;
		splitContainer_0.SplitterWidth = 8;
		splitContainer_0.TabIndex = 1000;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Window;
		base.ClientSize = new Size(654, 389);
		base.Controls.Add(splitContainer_0);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(label_1);
		base.Controls.Add(label_0);
		base.Controls.Add(textBox_1);
		base.Controls.Add(textBox_0);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(dataGridView_Items);
		base.Controls.Add(comboBox_0);
		base.Icon = Resources.edit;
		MinimumSize = new Size(670, 428);
		base.Name = Class16.smethod_0(1649246617);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649246617);
		base.FormClosing += SelectItemIdWindow_FormClosing;
		base.Load += SelectItemIdWindow_Load;
		base.SizeChanged += SelectItemIdWindow_SizeChanged;
		((ISupportInitialize)dataGridView_Items).EndInit();
		((ISupportInitialize)dataGridView_0).EndInit();
		splitContainer_0.Panel1.ResumeLayout(performLayout: false);
		splitContainer_0.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_0).EndInit();
		splitContainer_0.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void dataGridView_Items_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (!bool_1 && e.ColumnIndex >= 0 && e.ColumnIndex < 3 && e.RowIndex > -1)
		{
			try
			{
				int num = Convert.ToInt32(dataGridView_Items.Rows[e.RowIndex].Cells[0].Value);
				if (num > 0 && ACE.sTASKedit.Classes.Settings.Fields.EnableShowInfo)
				{
					string text = string.Empty;
					string empty = string.Empty;
					((DataGridView)sender).ShowCellToolTips = false;
					if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements)
					{
						text += GlobalFunctions.ColorClean(GProD.GetItemName(num));
					}
					empty += GlobalFunctions.ColorClean(GProD.GetItemProps(num, 0u));
					toolTip_0.ToolTipTitle = text;
					Point point = Extensions.SetToolTipPos((Control)sender);
					toolTip_0.Show(empty, (Control)sender, point.X, point.Y);
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

	private void dataGridView_Items_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		toolTip_0.Hide((Control)sender);
	}

	private void dataGridView_Items_Scroll(object sender, ScrollEventArgs e)
	{
		bool_1 = true;
	}

	private void dataGridView_Items_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_1)
		{
			bool_1 = false;
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (checkBox_0.Checked)
		{
			for (int i = 0; i < list_0.Count; i += 2)
			{
				if (GProD.eLC.Version < list_0[i + 1])
				{
					continue;
				}
				int num = list_0[i];
				for (int j = 0; j < GProD.eLC.Lists[num].elementValues.Length; j++)
				{
					if (GProD.eLC.GetValue(num, j, 0) == textBox_0.Text)
					{
						comboBox_0.SelectedIndex = i / 2;
						dataGridView_Items.CurrentCell = dataGridView_Items.Rows[j + 1].Cells[0];
						dataGridView_Items_SelectionChanged(null, null);
						return;
					}
				}
			}
			return;
		}
		int num2 = 0;
		while (true)
		{
			if (num2 <= dataGridView_Items.Rows.Count - 1)
			{
				if (dataGridView_Items.Rows[num2].Cells[0].FormattedValue.ToString() == textBox_0.Text)
				{
					break;
				}
				num2++;
				continue;
			}
			return;
		}
		dataGridView_Items.CurrentCell = dataGridView_Items.Rows[num2].Cells[0];
		dataGridView_Items_SelectionChanged(null, null);
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		if (checkBox_0.Checked)
		{
			int num = 0;
			int selectedIndex = comboBox_0.SelectedIndex;
			int num2 = dataGridView_Items.CurrentCell.RowIndex - 1;
			if (num2 < 0)
			{
				num2 = 0;
			}
			for (int i = selectedIndex * 2; i < list_0.Count; i += 2)
			{
				if (GProD.eLC.Version >= list_0[i + 1])
				{
					int num3 = list_0[i];
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
							comboBox_0.SelectedIndex = i / 2;
							dataGridView_Items.CurrentCell = dataGridView_Items.Rows[k + 1].Cells[0];
							dataGridView_Items_SelectionChanged(null, null);
							return;
						}
					}
				}
				num2 = 0;
				if (i == list_0.Count - 2 && num == 0)
				{
					num = 1;
					i = -2;
				}
			}
			return;
		}
		int num4 = 0;
		int rowIndex = dataGridView_Items.CurrentCell.RowIndex;
		int num5 = rowIndex;
		while (true)
		{
			if (num5 <= dataGridView_Items.Rows.Count - 1)
			{
				if (TextSearchHelper.Contains(dataGridView_Items.Rows[num5].Cells[2].FormattedValue?.ToString(), textBox_1.Text))
				{
					break;
				}
				if (num5 == dataGridView_Items.Rows.Count - 1 && num4 == 0)
				{
					num4 = 1;
					num5 = 0;
				}
				num5++;
				continue;
			}
			return;
		}
		dataGridView_Items.CurrentCell = dataGridView_Items.Rows[num5].Cells[2];
		dataGridView_Items_SelectionChanged(null, null);
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
			int num2 = dataGridView_Items.CurrentCell.RowIndex;
			if (num2 < 0)
			{
				num2 = 0;
			}
			for (int i = selectedIndex * 2; i < list_0.Count; i += 2)
			{
				if (GProD.eLC.Version >= list_0[i + 1])
				{
					int num3 = list_0[i];
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
							comboBox_0.SelectedIndex = i / 2;
							dataGridView_Items.CurrentCell = dataGridView_Items.Rows[k + 1].Cells[0];
							dataGridView_Items_SelectionChanged(null, null);
							return;
						}
					}
				}
				num2 = 0;
				if (i == list_0.Count - 2 && num == 0)
				{
					num = 1;
					i = -2;
				}
			}
			return;
		}
		int num4 = 0;
		int num5 = dataGridView_Items.CurrentCell.RowIndex + 1;
		int num6 = num5;
		while (true)
		{
			if (num6 <= dataGridView_Items.Rows.Count - 1)
			{
				if (TextSearchHelper.Contains(dataGridView_Items.Rows[num6].Cells[1].FormattedValue?.ToString(), textBox_1.Text))
				{
					break;
				}
				if (num6 == dataGridView_Items.Rows.Count - 1 && num4 == 0)
				{
					num4 = 1;
					num6 = 0;
				}
				num6++;
				continue;
			}
			return;
		}
		dataGridView_Items.CurrentCell = dataGridView_Items.Rows[num6].Cells[1];
		dataGridView_Items_SelectionChanged(null, null);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (comboBox_0.Items.Count > 0 && dataGridView_Items.Rows.Count > 0)
		{
			ArrayList arrayList = new ArrayList();
			ids = new ArrayList();
			arrayList = Extensions.SetIndexesRows(dataGridView_Items.SelectedCells);
			for (int i = 0; i < arrayList.Count; i++)
			{
				ids.Add(dataGridView_Items.Rows[Convert.ToInt32(arrayList[i])].Cells[0].Value);
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

	private void SelectItemIdWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (comboBox_0.Items.Count > 0)
		{
			GProD.SelectItemIdWindow_SelectedListIndex = comboBox_0.SelectedIndex;
			if (dataGridView_Items.Rows.Count > 0)
			{
				GProD.SelectItemIdWindow_SelectedItemIndex = dataGridView_Items.CurrentCell.RowIndex;
			}
		}
	}

	private void SelectItemIdWindow_SizeChanged(object sender, EventArgs e)
	{
		if (base.WindowState != FormWindowState.Maximized)
		{
			ACE.sTASKedit.Classes.Settings.Fields.SelectItemIdWindow_Size = base.Size;
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
		Text = GProD.TX(6035);
		dataGridViewTextBoxColumn_2.HeaderText = GProD.TX(6036);
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
