using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.Forms;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes;

public class ReplaceIdWindow : Form
{
	private ACE.sTASKedit.MainEditor.MainEditor mainEditor_0;

	private TreeNodeCollection treeNodeCollection_0;

	private StringBuilder stringBuilder_0;

	private List<IdReplacementPair> list_0;

	private IContainer icontainer_0;

	private Label label_0;

	private DataGridView dataGridView_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private GroupBox groupBox_0;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private GroupBox groupBox_1;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private CheckBox checkBox_5;

	private CheckBox checkBox_6;

	private CheckBox checkBox_7;

	private Button button_4;

	private Button button_5;

	private TextBox textBox_0;

	private Label label_1;

	private Button button_6;

	private Button button_7;

	public ReplaceIdWindow(ACE.sTASKedit.MainEditor.MainEditor mainWindow, TreeNodeCollection nodes)
	{
		method_3();
		TDark.StoreOriginalColors(this);
		TDark.ApplyThemeToForm(this);
		mainEditor_0 = mainWindow;
		treeNodeCollection_0 = nodes;
		stringBuilder_0 = new StringBuilder();
		method_0();
		TextStorage.TEXTS.SetFormLanguage(this, null);
		method_1();
	}

	private void method_0()
	{
		Text = Class16.smethod_0(1649260423);
		label_0.Text = TextStorage.Msg(Class16.smethod_0(1649260446));
		groupBox_0.Text = TextStorage.Msg(Class16.smethod_0(1649260479));
		radioButton_1.Text = TextStorage.Msg(Class16.smethod_0(1649260489));
		radioButton_0.Text = TextStorage.Msg(Class16.smethod_0(1649260519));
		groupBox_1.Text = TextStorage.Msg(Class16.smethod_0(1649260536));
		label_1.Text = TextStorage.Msg(Class16.smethod_0(1649259549));
		button_4.Text = TextStorage.Msg(Class16.smethod_0(1649259569));
		button_5.Text = TextStorage.Msg(Class16.smethod_0(1649005070), Class16.smethod_0(1648941799));
		button_6.Text = TextStorage.Msg(Class16.smethod_0(1649259593));
		button_7.Text = TextStorage.Msg(Class16.smethod_0(1649259609));
		button_0.Text = TextStorage.Msg(Class16.smethod_0(1649259626));
		button_1.Text = TextStorage.Msg(Class16.smethod_0(1649259642));
		button_2.Text = TextStorage.Msg(Class16.smethod_0(1649259669));
		button_3.Text = TextStorage.Msg(Class16.smethod_0(1649259683));
	}

	private void method_1()
	{
		method_2();
	}

	private void method_2()
	{
		dataGridView_0.Rows.Add(Class16.smethod_0(1648934925), Class16.smethod_0(1648934967));
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		List<IdReplacementPair> list = new List<IdReplacementPair>();
		HashSet<int> hashSet = new HashSet<int>();
		int num = 0;
		while (true)
		{
			if (num < dataGridView_0.Rows.Count)
			{
				DataGridViewRow dataGridViewRow = dataGridView_0.Rows[num];
				if (!dataGridViewRow.IsNewRow && dataGridViewRow.Cells[0].Value != null && dataGridViewRow.Cells[1].Value != null)
				{
					if (!int.TryParse(dataGridViewRow.Cells[0].Value.ToString(), out var result) || !int.TryParse(dataGridViewRow.Cells[1].Value.ToString(), out var result2))
					{
						break;
					}
					if (result == result2)
					{
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649259817), Class16.smethod_0(1649259860)), num + 1), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (result <= 0 || result2 <= 0)
					{
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649259905), Class16.smethod_0(1649259945)), num + 1), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					if (hashSet.Contains(result))
					{
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649259996), Class16.smethod_0(1649259013)), num + 1, result), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					hashSet.Add(result);
					list.Add(new IdReplacementPair(result, result2));
				}
				num++;
				continue;
			}
			if (list.Count == 0)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649259084)), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			stringBuilder_0.Clear();
			textBox_0.Clear();
			int num2 = 0;
			try
			{
				mainEditor_0.treeView_tasks.BeginBulkUpdate();
				method_12(string.Format(Class16.smethod_0(1649259106), list.Count));
				foreach (IdReplacementPair item in list)
				{
					method_12(string.Format(Class16.smethod_0(1649259165), item.OldId, item.NewId));
				}
				method_12(string.Empty);
				list_0 = list;
				for (int i = 0; i < GProD.Tasks.Length; i++)
				{
					if (!radioButton_1.Checked && (!radioButton_0.Checked || !treeNodeCollection_0[i].Checked))
					{
						continue;
					}
					ATaskTempl aTaskTempl = GProD.Tasks[i];
					foreach (IdReplacementPair item2 in list)
					{
						if (aTaskTempl.m_ID == item2.OldId)
						{
							int iD = aTaskTempl.m_ID;
							aTaskTempl.ID = item2.NewId;
							method_12(string.Format(Class16.smethod_0(1649259176), i, item2.OldId, item2.NewId));
							num2++;
							method_13(aTaskTempl, i, iD, item2.NewId);
							if (checkBox_2.Checked)
							{
								method_16(aTaskTempl, iD, item2.NewId);
							}
							treeNodeCollection_0[i].Text = string.Format(Class16.smethod_0(1649259220), item2.OldId, item2.NewId, aTaskTempl.Name);
							break;
						}
					}
					foreach (IdReplacementPair item3 in list)
					{
						num2 += method_4(aTaskTempl, i, item3.OldId, item3.NewId);
					}
					foreach (IdReplacementPair item4 in list)
					{
						num2 += method_6(aTaskTempl.pSub, i, item4.OldId, item4.NewId);
					}
				}
				mainEditor_0.treeView_tasks.EndBulkUpdate();
				mainEditor_0.select_task(null, null);
				stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649259247), num2));
				textBox_0.Text = stringBuilder_0.ToString();
				if (num2 > 0)
				{
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649259275), Class16.smethod_0(1649259344)), num2, list.Count), Class16.smethod_0(1649171053), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649259434)), Class16.smethod_0(1649141664), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				return;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649259470));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649259498), Class16.smethod_0(1649258515)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649259719), Class16.smethod_0(1649259752)), num + 1), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_3()
	{
		new DataGridViewCellStyle();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		label_0 = new Label();
		groupBox_0 = new GroupBox();
		radioButton_1 = new RadioButton();
		radioButton_0 = new RadioButton();
		groupBox_1 = new GroupBox();
		checkBox_7 = new CheckBox();
		checkBox_6 = new CheckBox();
		checkBox_5 = new CheckBox();
		checkBox_4 = new CheckBox();
		checkBox_3 = new CheckBox();
		checkBox_1 = new CheckBox();
		checkBox_0 = new CheckBox();
		checkBox_2 = new CheckBox();
		button_4 = new Button();
		button_5 = new Button();
		textBox_0 = new TextBox();
		label_1 = new Label();
		button_6 = new Button();
		button_7 = new Button();
		((ISupportInitialize)dataGridView_0).BeginInit();
		groupBox_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		SuspendLayout();
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_0.BackgroundColor = SystemColors.Window;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1);
		dataGridView_0.Location = new Point(12, 35);
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1649258559);
		dataGridView_0.RowHeadersWidth = 25;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.Size = new Size(350, 120);
		dataGridView_0.TabIndex = 1;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649258578);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649258599);
		dataGridViewTextBoxColumn_0.Width = 110;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1649258610);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649258631);
		dataGridViewTextBoxColumn_1.Width = 110;
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_0.Location = new Point(368, 35);
		button_0.Name = Class16.smethod_0(1649258642);
		button_0.Size = new Size(75, 23);
		button_0.TabIndex = 2;
		button_0.Text = Class16.smethod_0(1648931361);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_1.Location = new Point(368, 64);
		button_1.Name = Class16.smethod_0(1649258665);
		button_1.Size = new Size(75, 23);
		button_1.TabIndex = 3;
		button_1.Text = Class16.smethod_0(1648931371);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_2.Location = new Point(368, 93);
		button_2.Name = Class16.smethod_0(1649258691);
		button_2.Size = new Size(75, 23);
		button_2.TabIndex = 4;
		button_2.Text = Class16.smethod_0(1649258713);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_3.Location = new Point(368, 122);
		button_3.Name = Class16.smethod_0(1649258729);
		button_3.Size = new Size(75, 23);
		button_3.TabIndex = 5;
		button_3.Text = Class16.smethod_0(1649258765);
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		label_0.AutoSize = true;
		label_0.Location = new Point(12, 15);
		label_0.Name = Class16.smethod_0(1649258779);
		label_0.Size = new Size(118, 13);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1649258807);
		groupBox_0.Controls.Add(radioButton_0);
		groupBox_0.Controls.Add(radioButton_1);
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_0.Location = new Point(12, 185);
		groupBox_0.Name = Class16.smethod_0(1648929126);
		groupBox_0.Size = new Size(431, 50);
		groupBox_0.TabIndex = 6;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1649090128);
		radioButton_1.AutoSize = true;
		radioButton_1.Location = new Point(15, 20);
		radioButton_1.Name = Class16.smethod_0(1649258827);
		radioButton_1.Size = new Size(69, 17);
		radioButton_1.TabIndex = 0;
		radioButton_1.TabStop = true;
		radioButton_1.Text = Class16.smethod_0(1649258849);
		radioButton_1.UseVisualStyleBackColor = true;
		radioButton_0.AutoSize = true;
		radioButton_0.Checked = true;
		radioButton_0.Location = new Point(150, 20);
		radioButton_0.Name = Class16.smethod_0(1649258865);
		radioButton_0.Size = new Size(96, 17);
		radioButton_0.TabIndex = 1;
		radioButton_0.TabStop = true;
		radioButton_0.Text = Class16.smethod_0(1649258890);
		radioButton_0.UseVisualStyleBackColor = true;
		groupBox_1.Controls.Add(button_7);
		groupBox_1.Controls.Add(button_6);
		groupBox_1.Controls.Add(checkBox_2);
		groupBox_1.Controls.Add(checkBox_0);
		groupBox_1.Controls.Add(checkBox_1);
		groupBox_1.Controls.Add(checkBox_3);
		groupBox_1.Controls.Add(checkBox_4);
		groupBox_1.Controls.Add(checkBox_5);
		groupBox_1.Controls.Add(checkBox_6);
		groupBox_1.Controls.Add(checkBox_7);
		groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_1.Location = new Point(12, 241);
		groupBox_1.Name = Class16.smethod_0(1648929037);
		groupBox_1.Size = new Size(431, 200);
		groupBox_1.TabIndex = 7;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1649258917);
		checkBox_7.AutoSize = true;
		checkBox_7.Checked = true;
		checkBox_7.CheckState = CheckState.Checked;
		checkBox_7.Location = new Point(15, 25);
		checkBox_7.Name = Class16.smethod_0(1649258940);
		checkBox_7.Size = new Size(122, 17);
		checkBox_7.TabIndex = 0;
		checkBox_7.Text = Class16.smethod_0(1649258960);
		checkBox_7.UseVisualStyleBackColor = true;
		checkBox_6.AutoSize = true;
		checkBox_6.Checked = true;
		checkBox_6.CheckState = CheckState.Checked;
		checkBox_6.Location = new Point(15, 48);
		checkBox_6.Name = Class16.smethod_0(1649258984);
		checkBox_6.Size = new Size(103, 17);
		checkBox_6.TabIndex = 1;
		checkBox_6.Text = Class16.smethod_0(1649262082);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_5.AutoSize = true;
		checkBox_5.Checked = true;
		checkBox_5.CheckState = CheckState.Checked;
		checkBox_5.Location = new Point(15, 71);
		checkBox_5.Name = Class16.smethod_0(1649262111);
		checkBox_5.Size = new Size(87, 17);
		checkBox_5.TabIndex = 2;
		checkBox_5.Text = Class16.smethod_0(1649262129);
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_4.AutoSize = true;
		checkBox_4.Checked = true;
		checkBox_4.CheckState = CheckState.Checked;
		checkBox_4.Location = new Point(15, 94);
		checkBox_4.Name = Class16.smethod_0(1649262146);
		checkBox_4.Size = new Size(175, 17);
		checkBox_4.TabIndex = 3;
		checkBox_4.Text = Class16.smethod_0(1649262183);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_3.AutoSize = true;
		checkBox_3.Checked = true;
		checkBox_3.CheckState = CheckState.Checked;
		checkBox_3.Location = new Point(15, 117);
		checkBox_3.Name = Class16.smethod_0(1649262214);
		checkBox_3.Size = new Size(154, 17);
		checkBox_3.TabIndex = 4;
		checkBox_3.Text = Class16.smethod_0(1649262234);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_1.AutoSize = true;
		checkBox_1.Checked = true;
		checkBox_1.CheckState = CheckState.Checked;
		checkBox_1.Location = new Point(15, 140);
		checkBox_1.Name = Class16.smethod_0(1649262271);
		checkBox_1.Size = new Size(112, 17);
		checkBox_1.TabIndex = 5;
		checkBox_1.Text = Class16.smethod_0(1649262300);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_0.AutoSize = true;
		checkBox_0.Checked = true;
		checkBox_0.CheckState = CheckState.Checked;
		checkBox_0.Location = new Point(15, 163);
		checkBox_0.Name = Class16.smethod_0(1649262315);
		checkBox_0.Size = new Size(211, 17);
		checkBox_0.TabIndex = 6;
		checkBox_0.Text = Class16.smethod_0(1649262346);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_2.AutoSize = true;
		checkBox_2.Checked = true;
		checkBox_2.CheckState = CheckState.Checked;
		checkBox_2.Location = new Point(240, 163);
		checkBox_2.Name = Class16.smethod_0(1649262387);
		checkBox_2.Size = new Size(147, 17);
		checkBox_2.TabIndex = 7;
		checkBox_2.Text = Class16.smethod_0(1649262420);
		checkBox_2.UseVisualStyleBackColor = true;
		button_4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_4.Location = new Point(12, 615);
		button_4.Name = Class16.smethod_0(1649262453);
		button_4.Size = new Size(175, 23);
		button_4.TabIndex = 10;
		button_4.Text = Class16.smethod_0(1649262466);
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		button_5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_5.Location = new Point(268, 615);
		button_5.Name = Class16.smethod_0(1649262492);
		button_5.Size = new Size(175, 23);
		button_5.TabIndex = 11;
		button_5.Text = Class16.smethod_0(1648941799);
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.Location = new Point(12, 472);
		textBox_0.Multiline = true;
		textBox_0.Name = Class16.smethod_0(1649262504);
		textBox_0.ReadOnly = true;
		textBox_0.ScrollBars = ScrollBars.Vertical;
		textBox_0.Size = new Size(431, 137);
		textBox_0.TabIndex = 8;
		label_1.AutoSize = true;
		label_1.Location = new Point(12, 456);
		label_1.Name = Class16.smethod_0(1648912145);
		label_1.Size = new Size(91, 13);
		label_1.TabIndex = 9;
		label_1.Text = Class16.smethod_0(1649262522);
		button_6.Location = new Point(240, 25);
		button_6.Name = Class16.smethod_0(1649262545);
		button_6.Size = new Size(60, 23);
		button_6.TabIndex = 7;
		button_6.Text = Class16.smethod_0(1648973883);
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		button_7.Location = new Point(306, 25);
		button_7.Name = Class16.smethod_0(1649262568);
		button_7.Size = new Size(48, 23);
		button_7.TabIndex = 8;
		button_7.Text = Class16.smethod_0(1648924120);
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(455, 650);
		base.Controls.Add(label_1);
		base.Controls.Add(textBox_0);
		base.Controls.Add(button_5);
		base.Controls.Add(button_4);
		base.Controls.Add(groupBox_1);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(button_3);
		base.Controls.Add(button_2);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(dataGridView_0);
		base.Controls.Add(label_0);
		base.FormBorderStyle = FormBorderStyle.Sizable;
		MinimumSize = new Size(450, 600);
		base.Name = Class16.smethod_0(1649261568);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649260423);
		((ISupportInitialize)dataGridView_0).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private int method_4(ATaskTempl ataskTempl_0, int int_0, int int_1, int int_2)
	{
		int num = 0;
		if (checkBox_7.Checked)
		{
			for (int i = 0; i < ataskTempl_0.m_ulPremise_Tasks.Length; i++)
			{
				if (ataskTempl_0.m_ulPremise_Tasks[i] == int_1)
				{
					ataskTempl_0.m_ulPremise_Tasks[i] = int_2;
					method_12(string.Format(Class16.smethod_0(1649261598), int_0, i, int_1, int_2));
					num++;
				}
			}
		}
		if (checkBox_6.Checked)
		{
			for (int j = 0; j < ataskTempl_0.m_ulMutexTasks.Length; j++)
			{
				if (ataskTempl_0.m_ulMutexTasks[j] == int_1)
				{
					ataskTempl_0.m_ulMutexTasks[j] = int_2;
					method_12(string.Format(Class16.smethod_0(1649261641), int_0, j, int_1, int_2));
					num++;
				}
			}
		}
		if (checkBox_5.Checked)
		{
			for (int k = 0; k < ataskTempl_0.m_ulNeededTasks.Length; k++)
			{
				if (ataskTempl_0.m_ulNeededTasks[k] == int_1)
				{
					ataskTempl_0.m_ulNeededTasks[k] = int_2;
					method_12(string.Format(Class16.smethod_0(1649261689), int_0, k, int_1, int_2));
					num++;
				}
			}
		}
		if (checkBox_4.Checked)
		{
			for (int l = 0; l < ataskTempl_0.m_TeamMemsWanted.Length; l++)
			{
				if (ataskTempl_0.m_TeamMemsWanted[l].m_ulTask == int_1)
				{
					ataskTempl_0.m_TeamMemsWanted[l].m_ulTask = int_2;
					method_12(string.Format(Class16.smethod_0(1649261741), int_0, l, int_1, int_2));
					num++;
				}
			}
		}
		if (checkBox_3.Checked)
		{
			num += method_5(ataskTempl_0.m_Award_S, int_0, Class16.smethod_0(1649261792), int_1, int_2);
			num += method_5(ataskTempl_0.m_Award_F, int_0, Class16.smethod_0(1649261808), int_1, int_2);
			for (int m = 0; m < ataskTempl_0.m_AwByRatio_S.m_Awards.Length; m++)
			{
				num += method_5(ataskTempl_0.m_AwByRatio_S.m_Awards[m], int_0, string.Format(Class16.smethod_0(1649261824), m), int_1, int_2);
			}
			for (int n = 0; n < ataskTempl_0.m_AwByRatio_F.m_Awards.Length; n++)
			{
				num += method_5(ataskTempl_0.m_AwByRatio_F.m_Awards[n], int_0, string.Format(Class16.smethod_0(1649261858), n), int_1, int_2);
			}
			for (int num2 = 0; num2 < ataskTempl_0.m_AwByItems_S.m_Awards.Length; num2++)
			{
				num += method_5(ataskTempl_0.m_AwByItems_S.m_Awards[num2], int_0, string.Format(Class16.smethod_0(1649261900), num2), int_1, int_2);
			}
			for (int num3 = 0; num3 < ataskTempl_0.m_AwByItems_F.m_Awards.Length; num3++)
			{
				num += method_5(ataskTempl_0.m_AwByItems_F.m_Awards[num3], int_0, string.Format(Class16.smethod_0(1649261934), num3), int_1, int_2);
			}
		}
		if (checkBox_1.Checked)
		{
			for (int num4 = 0; num4 < ataskTempl_0.TaskEventTaskData.Length; num4++)
			{
				if (ataskTempl_0.TaskEventTaskData[num4].Id == int_1)
				{
					ataskTempl_0.TaskEventTaskData[num4].Id = int_2;
					method_12(string.Format(Class16.smethod_0(1649261960), int_0, num4, int_1, int_2));
					num++;
				}
			}
		}
		if (checkBox_0.Checked)
		{
			for (int num5 = 0; num5 < ataskTempl_0.SpecialParameters.CompleteTaskIDs.Length; num5++)
			{
				if (ataskTempl_0.SpecialParameters.CompleteTaskIDs[num5] == int_1)
				{
					ataskTempl_0.SpecialParameters.CompleteTaskIDs[num5] = int_2;
					method_12(string.Format(Class16.smethod_0(1649262022), int_0, num5, int_1, int_2));
					num++;
				}
			}
		}
		return num;
	}

	private int method_5(AWARD_DATA award_DATA_0, int int_0, string string_0, int int_1, int int_2)
	{
		if (award_DATA_0.m_ulNewTask == int_1)
		{
			award_DATA_0.m_ulNewTask = int_2;
			method_12(string.Format(Class16.smethod_0(1649261057), int_0, string_0, int_1, int_2));
			return 1;
		}
		return 0;
	}

	private int method_6(ATaskTempl[] ataskTempl_0, int int_0, int int_1, int int_2)
	{
		int num = 0;
		for (int i = 0; i < ataskTempl_0.Length; i++)
		{
			if (ataskTempl_0[i].m_ID == int_1)
			{
				int iD = ataskTempl_0[i].m_ID;
				ataskTempl_0[i].ID = int_2;
				method_12(string.Format(Class16.smethod_0(1649261109), int_0, i, int_1, int_2));
				method_14(ataskTempl_0, i, int_0, iD, int_2);
				if (checkBox_2.Checked)
				{
					method_16(ataskTempl_0[i], iD, int_2);
				}
				if (int_0 < treeNodeCollection_0.Count && treeNodeCollection_0[int_0].Nodes.Count > i)
				{
					treeNodeCollection_0[int_0].Nodes[i].Text = string.Format(Class16.smethod_0(1649259220), int_1, int_2, ataskTempl_0[i].Name);
				}
				num++;
			}
			num += method_8(ataskTempl_0[i], string.Format(Class16.smethod_0(1649261158), int_0, i), int_1, int_2);
			num += method_7(ataskTempl_0[i].pSub, string.Format(Class16.smethod_0(1649261158), int_0, i), int_1, int_2);
		}
		return num;
	}

	private int method_7(ATaskTempl[] ataskTempl_0, string string_0, int int_0, int int_1)
	{
		int num = 0;
		for (int i = 0; i < ataskTempl_0.Length; i++)
		{
			if (ataskTempl_0[i].m_ID == int_0)
			{
				int iD = ataskTempl_0[i].m_ID;
				ataskTempl_0[i].ID = int_1;
				method_12(string.Format(Class16.smethod_0(1649261109), string_0, i, int_0, int_1));
				method_15(ataskTempl_0, i, string_0, iD, int_1);
				if (checkBox_2.Checked)
				{
					method_16(ataskTempl_0[i], iD, int_1);
				}
				TreeNode treeNode = method_11(string.Format(Class16.smethod_0(1649261158), string_0, i));
				if (treeNode != null)
				{
					treeNode.Text = string.Format(Class16.smethod_0(1649259220), int_0, int_1, ataskTempl_0[i].Name);
				}
				num++;
			}
			num += method_8(ataskTempl_0[i], string.Format(Class16.smethod_0(1649261158), string_0, i), int_0, int_1);
			num += method_7(ataskTempl_0[i].pSub, string.Format(Class16.smethod_0(1649261158), string_0, i), int_0, int_1);
		}
		return num;
	}

	private int method_8(ATaskTempl ataskTempl_0, string string_0, int int_0, int int_1)
	{
		int num = 0;
		if (checkBox_7.Checked)
		{
			for (int i = 0; i < ataskTempl_0.m_ulPremise_Tasks.Length; i++)
			{
				if (ataskTempl_0.m_ulPremise_Tasks[i] == int_0)
				{
					ataskTempl_0.m_ulPremise_Tasks[i] = int_1;
					method_12(string.Format(Class16.smethod_0(1649261598), string_0, i, int_0, int_1));
					num++;
				}
			}
		}
		if (checkBox_6.Checked)
		{
			for (int j = 0; j < ataskTempl_0.m_ulMutexTasks.Length; j++)
			{
				if (ataskTempl_0.m_ulMutexTasks[j] == int_0)
				{
					ataskTempl_0.m_ulMutexTasks[j] = int_1;
					method_12(string.Format(Class16.smethod_0(1649261641), string_0, j, int_0, int_1));
					num++;
				}
			}
		}
		if (checkBox_5.Checked)
		{
			for (int k = 0; k < ataskTempl_0.m_ulNeededTasks.Length; k++)
			{
				if (ataskTempl_0.m_ulNeededTasks[k] == int_0)
				{
					ataskTempl_0.m_ulNeededTasks[k] = int_1;
					method_12(string.Format(Class16.smethod_0(1649261689), string_0, k, int_0, int_1));
					num++;
				}
			}
		}
		if (checkBox_4.Checked)
		{
			for (int l = 0; l < ataskTempl_0.m_TeamMemsWanted.Length; l++)
			{
				if (ataskTempl_0.m_TeamMemsWanted[l].m_ulTask == int_0)
				{
					ataskTempl_0.m_TeamMemsWanted[l].m_ulTask = int_1;
					method_12(string.Format(Class16.smethod_0(1649261741), string_0, l, int_0, int_1));
					num++;
				}
			}
		}
		if (checkBox_3.Checked)
		{
			num += method_9(ataskTempl_0.m_Award_S, string_0, Class16.smethod_0(1649261792), int_0, int_1);
			num += method_9(ataskTempl_0.m_Award_F, string_0, Class16.smethod_0(1649261808), int_0, int_1);
			for (int m = 0; m < ataskTempl_0.m_AwByRatio_S.m_Awards.Length; m++)
			{
				num += method_9(ataskTempl_0.m_AwByRatio_S.m_Awards[m], string_0, string.Format(Class16.smethod_0(1649261824), m), int_0, int_1);
			}
			for (int n = 0; n < ataskTempl_0.m_AwByRatio_F.m_Awards.Length; n++)
			{
				num += method_9(ataskTempl_0.m_AwByRatio_F.m_Awards[n], string_0, string.Format(Class16.smethod_0(1649261858), n), int_0, int_1);
			}
			for (int num2 = 0; num2 < ataskTempl_0.m_AwByItems_S.m_Awards.Length; num2++)
			{
				num += method_9(ataskTempl_0.m_AwByItems_S.m_Awards[num2], string_0, string.Format(Class16.smethod_0(1649261900), num2), int_0, int_1);
			}
			for (int num3 = 0; num3 < ataskTempl_0.m_AwByItems_F.m_Awards.Length; num3++)
			{
				num += method_9(ataskTempl_0.m_AwByItems_F.m_Awards[num3], string_0, string.Format(Class16.smethod_0(1649261934), num3), int_0, int_1);
			}
		}
		if (checkBox_1.Checked)
		{
			for (int num4 = 0; num4 < ataskTempl_0.TaskEventTaskData.Length; num4++)
			{
				if (ataskTempl_0.TaskEventTaskData[num4].Id == int_0)
				{
					ataskTempl_0.TaskEventTaskData[num4].Id = int_1;
					method_12(string.Format(Class16.smethod_0(1649261960), string_0, num4, int_0, int_1));
					num++;
				}
			}
		}
		if (checkBox_0.Checked)
		{
			for (int num5 = 0; num5 < ataskTempl_0.SpecialParameters.CompleteTaskIDs.Length; num5++)
			{
				if (ataskTempl_0.SpecialParameters.CompleteTaskIDs[num5] == int_0)
				{
					ataskTempl_0.SpecialParameters.CompleteTaskIDs[num5] = int_1;
					method_12(string.Format(Class16.smethod_0(1649262022), string_0, num5, int_0, int_1));
					num++;
				}
			}
		}
		if (checkBox_2.Checked)
		{
			num += method_10(ataskTempl_0.m_DelvTaskTalk, string_0, Class16.smethod_0(1649266187), int_0, int_1);
			num += method_10(ataskTempl_0.m_UnqualifiedTaskTalk, string_0, Class16.smethod_0(1649266208), int_0, int_1);
			num += method_10(ataskTempl_0.m_DelvItemTalk, string_0, Class16.smethod_0(1649266244), int_0, int_1);
			num += method_10(ataskTempl_0.m_ExeTalk, string_0, Class16.smethod_0(1649266257), int_0, int_1);
			num += method_10(ataskTempl_0.m_AwardTalk, string_0, Class16.smethod_0(1649266273), int_0, int_1);
		}
		return num;
	}

	private int method_9(AWARD_DATA award_DATA_0, string string_0, string string_1, int int_0, int int_1)
	{
		if (award_DATA_0.m_ulNewTask == int_0)
		{
			award_DATA_0.m_ulNewTask = int_1;
			method_12(string.Format(Class16.smethod_0(1649261057), string_0, string_1, int_0, int_1));
			return 1;
		}
		return 0;
	}

	private int method_10(talk_proc talk_proc_0, string string_0, string string_1, int int_0, int int_1)
	{
		int num = 0;
		if (talk_proc_0.crypt_key == int_0)
		{
			talk_proc_0.crypt_key = int_1;
			method_12(string.Format(Class16.smethod_0(1649261172), string_0, string_1, int_0, int_1));
			num++;
		}
		for (int i = 0; i < talk_proc_0.windows.Length; i++)
		{
			if (talk_proc_0.windows[i].crypt_key == int_0)
			{
				talk_proc_0.windows[i].crypt_key = int_1;
				method_12(string.Format(Class16.smethod_0(1649261214), string_0, string_1, i, int_0, int_1));
				num++;
			}
			for (int j = 0; j < talk_proc_0.windows[i].options.Length; j++)
			{
				if (talk_proc_0.windows[i].options[j].crypt_key == int_0)
				{
					talk_proc_0.windows[i].options[j].crypt_key = int_1;
					method_12(string.Format(Class16.smethod_0(1649261269), string_0, string_1, i, j, int_0, int_1));
					num++;
				}
				if (talk_proc_0.windows[i].options[j].id == int_0)
				{
					talk_proc_0.windows[i].options[j].id = int_1;
					method_12(string.Format(Class16.smethod_0(1649261329), string_0, string_1, i, j, int_0, int_1));
					num++;
					continue;
				}
				int num2 = method_18(talk_proc_0.windows[i].options[j].id);
				if (num2 != -1)
				{
					int id = talk_proc_0.windows[i].options[j].id;
					talk_proc_0.windows[i].options[j].id = num2;
					method_12(string.Format(Class16.smethod_0(1649261398), string_0, string_1, i, j, id, num2));
					num++;
				}
			}
		}
		return num;
	}

	private TreeNode method_11(string string_0)
	{
		try
		{
			string[] array = string_0.Split('.');
			TreeNode treeNode = null;
			if (array.Length != 0 && int.TryParse(array[0], out var result) && result < treeNodeCollection_0.Count)
			{
				treeNode = treeNodeCollection_0[result];
				for (int i = 1; i < array.Length; i++)
				{
					if (int.TryParse(array[i], out var result2))
					{
						if (treeNode.Nodes.Count > result2)
						{
							treeNode = treeNode.Nodes[result2];
							continue;
						}
						return null;
					}
					return null;
				}
			}
			return treeNode;
		}
		catch
		{
			return null;
		}
	}

	private void method_12(string string_0)
	{
		stringBuilder_0.AppendLine(string_0);
		textBox_0.Text = stringBuilder_0.ToString();
		textBox_0.SelectionStart = textBox_0.Text.Length;
		textBox_0.ScrollToCaret();
		Application.DoEvents();
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		checkBox_7.Checked = true;
		checkBox_6.Checked = true;
		checkBox_5.Checked = true;
		checkBox_4.Checked = true;
		checkBox_3.Checked = true;
		checkBox_1.Checked = true;
		checkBox_0.Checked = true;
		checkBox_2.Checked = true;
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		checkBox_7.Checked = false;
		checkBox_6.Checked = false;
		checkBox_5.Checked = false;
		checkBox_4.Checked = false;
		checkBox_3.Checked = false;
		checkBox_1.Checked = false;
		checkBox_0.Checked = false;
		checkBox_2.Checked = false;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		dataGridView_0.Rows.Add(string.Empty, string.Empty);
		if (dataGridView_0.Rows.Count > 0)
		{
			int index = dataGridView_0.Rows.Count - 1;
			dataGridView_0.CurrentCell = dataGridView_0.Rows[index].Cells[0];
			dataGridView_0.BeginEdit(selectAll: true);
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			DataGridViewRow dataGridViewRow = dataGridView_0.SelectedRows[0];
			if (!dataGridViewRow.IsNewRow)
			{
				dataGridView_0.Rows.Remove(dataGridViewRow);
			}
		}
		else if (dataGridView_0.CurrentRow != null && !dataGridView_0.CurrentRow.IsNewRow)
		{
			dataGridView_0.Rows.Remove(dataGridView_0.CurrentRow);
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649261477)), TextStorage.Msg(Class16.smethod_0(1649261499)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		AddRangeDialog addRangeDialog = new AddRangeDialog();
		try
		{
			if (addRangeDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			int startOldId = addRangeDialog.StartOldId;
			int count = addRangeDialog.Count;
			int startNewId = addRangeDialog.StartNewId;
			HashSet<int> hashSet = new HashSet<int>();
			for (int i = 0; i < dataGridView_0.Rows.Count; i++)
			{
				DataGridViewRow dataGridViewRow = dataGridView_0.Rows[i];
				if (!dataGridViewRow.IsNewRow && dataGridViewRow.Cells[0].Value != null && int.TryParse(dataGridViewRow.Cells[0].Value.ToString(), out var result))
				{
					hashSet.Add(result);
				}
			}
			List<int> list = new List<int>();
			for (int j = 0; j < count; j++)
			{
				int item = startOldId + j;
				if (hashSet.Contains(item))
				{
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				string text = Class16.smethod_0(1649261532) + string.Join(Class16.smethod_0(1648942920), list) + Class16.smethod_0(1649260568);
				DialogResult dialogResult = DKBox.Show(text, Class16.smethod_0(1649260626), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (dialogResult == DialogResult.No)
				{
					return;
				}
			}
			int num = 0;
			for (int k = 0; k < count; k++)
			{
				int item2 = startOldId + k;
				int num2 = startNewId + k;
				if (!hashSet.Contains(item2))
				{
					dataGridView_0.Rows.Add(item2.ToString(), num2.ToString());
					num++;
				}
			}
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649260656), Class16.smethod_0(1649260711)), num), Class16.smethod_0(1649260774), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		finally
		{
			((IDisposable)addRangeDialog).Dispose();
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		IncrementRangeDialog incrementRangeDialog = new IncrementRangeDialog();
		try
		{
			if (incrementRangeDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			int idMin = incrementRangeDialog.IdMin;
			int idMax = incrementRangeDialog.IdMax;
			int increment = incrementRangeDialog.Increment;
			if (idMin > idMax)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649260784)), TextStorage.Msg(Class16.smethod_0(1649260823)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (increment == 0)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649260841)), TextStorage.Msg(Class16.smethod_0(1649260876)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			List<int> list = new List<int>();
			for (int i = idMin; i <= idMax; i++)
			{
				list.Add(i);
			}
			int count = list.Count;
			if (count == 0)
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649260898), Class16.smethod_0(1649260942)), idMin, idMax), Class16.smethod_0(1649260969), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			HashSet<int> hashSet = new HashSet<int>();
			for (int j = 0; j < dataGridView_0.Rows.Count; j++)
			{
				DataGridViewRow dataGridViewRow = dataGridView_0.Rows[j];
				if (!dataGridViewRow.IsNewRow && dataGridViewRow.Cells[0].Value != null && int.TryParse(dataGridViewRow.Cells[0].Value.ToString(), out var result))
				{
					hashSet.Add(result);
				}
			}
			List<(int, int)> list2 = new List<(int, int)>();
			List<int> list3 = new List<int>();
			foreach (int item2 in list)
			{
				if (hashSet.Contains(item2))
				{
					list3.Add(item2);
					continue;
				}
				int item = item2 + increment;
				list2.Add((item2, item));
			}
			string text = string.Format(Class16.smethod_0(1649260997), count, idMin, idMax);
			if (list3.Count > 0)
			{
				text += string.Format(Class16.smethod_0(1649261046), list3.Count);
			}
			text += string.Format(Class16.smethod_0(1649255965), list2.Count, increment);
			text += Class16.smethod_0(1649256021);
			DialogResult dialogResult = DKBox.Show(text, Class16.smethod_0(1649256043), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.No)
			{
				return;
			}
			foreach (var (num, num2) in list2)
			{
				dataGridView_0.Rows.Add(num.ToString(), num2.ToString());
			}
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649256073), Class16.smethod_0(1649260711)), list2.Count), Class16.smethod_0(1649256122), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		finally
		{
			((IDisposable)incrementRangeDialog).Dispose();
		}
	}

	private void method_13(ATaskTempl ataskTempl_0, int int_0, int int_1, int int_2)
	{
		if (ataskTempl_0.m_nSubCount != 0)
		{
			for (int i = 0; i < ataskTempl_0.m_nSubCount; i++)
			{
				ataskTempl_0.pSub[i].m_ulParent = ataskTempl_0.m_ID;
				method_12(string.Format(Class16.smethod_0(1649256153), int_0, i, int_1, int_2));
			}
		}
	}

	private void method_14(ATaskTempl[] ataskTempl_0, int int_0, int int_1, int int_2, int int_3)
	{
		if (ataskTempl_0[int_0].m_nSubCount != 0)
		{
			for (int i = 0; i < ataskTempl_0[int_0].m_nSubCount; i++)
			{
				ataskTempl_0[int_0].pSub[i].m_ulParent = ataskTempl_0[int_0].m_ID;
				method_12(string.Format(Class16.smethod_0(1649256221), int_1, int_0, i, int_2, int_3));
			}
		}
		ATaskTempl aTaskTempl = GProD.Tasks[int_1];
		if (int_0 < aTaskTempl.m_nSubCount - 1)
		{
			aTaskTempl.pSub[int_0 + 1].m_ulPrevSibling = int_3;
			method_12(string.Format(Class16.smethod_0(1649256294), int_1, int_0 + 1, int_2, int_3));
		}
		if (int_0 != 0)
		{
			aTaskTempl.pSub[int_0 - 1].m_ulNextSibling = int_3;
			method_12(string.Format(Class16.smethod_0(1649256359), int_1, int_0 - 1, int_2, int_3));
		}
		if (int_0 == 0)
		{
			aTaskTempl.m_ulFirstChild = int_3;
			method_12(string.Format(Class16.smethod_0(1649256416), int_1, int_2, int_3));
		}
	}

	private void method_15(ATaskTempl[] ataskTempl_0, int int_0, string string_0, int int_1, int int_2)
	{
		if (ataskTempl_0[int_0].m_nSubCount != 0)
		{
			for (int i = 0; i < ataskTempl_0[int_0].m_nSubCount; i++)
			{
				ataskTempl_0[int_0].pSub[i].m_ulParent = ataskTempl_0[int_0].m_ID;
				method_12(string.Format(Class16.smethod_0(1649256221), string_0, int_0, i, int_1, int_2));
			}
		}
		string[] array = string_0.Split('.');
		ATaskTempl aTaskTempl = null;
		if (array.Length == 1)
		{
			int num = int.Parse(array[0]);
			aTaskTempl = GProD.Tasks[num];
		}
		else
		{
			int num2 = int.Parse(array[0]);
			aTaskTempl = GProD.Tasks[num2];
			for (int j = 1; j < array.Length; j++)
			{
				int num3 = int.Parse(array[j]);
				aTaskTempl = aTaskTempl.pSub[num3];
			}
		}
		if (aTaskTempl != null)
		{
			if (int_0 < aTaskTempl.m_nSubCount - 1)
			{
				aTaskTempl.pSub[int_0 + 1].m_ulPrevSibling = int_2;
				method_12(string.Format(Class16.smethod_0(1649256294), string_0, int_0 + 1, int_1, int_2));
			}
			if (int_0 != 0)
			{
				aTaskTempl.pSub[int_0 - 1].m_ulNextSibling = int_2;
				method_12(string.Format(Class16.smethod_0(1649256359), string_0, int_0 - 1, int_1, int_2));
			}
			if (int_0 == 0)
			{
				aTaskTempl.m_ulFirstChild = int_2;
				method_12(string.Format(Class16.smethod_0(1649256416), string_0, int_1, int_2));
			}
		}
	}

	private void method_16(ATaskTempl ataskTempl_0, int int_0, int int_1)
	{
		method_17(ataskTempl_0.m_DelvTaskTalk, Class16.smethod_0(1649266187), int_0, int_1);
		method_17(ataskTempl_0.m_UnqualifiedTaskTalk, Class16.smethod_0(1649266208), int_0, int_1);
		method_17(ataskTempl_0.m_DelvItemTalk, Class16.smethod_0(1649266244), int_0, int_1);
		method_17(ataskTempl_0.m_ExeTalk, Class16.smethod_0(1649266257), int_0, int_1);
		method_17(ataskTempl_0.m_AwardTalk, Class16.smethod_0(1649266273), int_0, int_1);
		for (int i = 0; i < ataskTempl_0.m_nSubCount; i++)
		{
			method_16(ataskTempl_0.pSub[i], int_0, int_1);
		}
	}

	private void method_17(talk_proc talk_proc_0, string string_0, int int_0, int int_1)
	{
		for (int i = 0; i < talk_proc_0.windows.Length; i++)
		{
			for (int j = 0; j < talk_proc_0.windows[i].options.Length; j++)
			{
				bool flag = false;
				if (talk_proc_0.windows[i].options[j].id == int_0)
				{
					talk_proc_0.windows[i].options[j].id = int_1;
					method_12(string.Format(Class16.smethod_0(1649255443), string_0, i, j, int_0, int_1));
					flag = true;
				}
				if (!flag)
				{
					int num = method_18(talk_proc_0.windows[i].options[j].id);
					if (num != -1)
					{
						int id = talk_proc_0.windows[i].options[j].id;
						talk_proc_0.windows[i].options[j].id = num;
						method_12(string.Format(Class16.smethod_0(1649255519), string_0, i, j, id, num));
					}
				}
			}
		}
	}

	private int method_18(int int_0)
	{
		if (list_0 == null)
		{
			return -1;
		}
		foreach (IdReplacementPair item in list_0)
		{
			if (item.OldId == int_0)
			{
				return item.NewId;
			}
		}
		return -1;
	}
}
