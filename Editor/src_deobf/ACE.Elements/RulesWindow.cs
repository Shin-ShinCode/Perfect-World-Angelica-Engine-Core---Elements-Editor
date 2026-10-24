using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.Properties;

namespace ACE.Elements;

public class RulesWindow : Form
{
	protected ACE.Elements.eListCollection.eListCollection eLC_base;

	protected ACE.Elements.eListCollection.eListCollection eLC_recent;

	protected RuleConfig[] eRules;

	private GroupBox groupBox_0;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private GroupBox groupBox_1;

	private TextBox textBox_4;

	private TextBox textBox_5;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private CheckBox checkBox_0;

	private ComboBox comboBox_0;

	private DataGridView dataGridView_0;

	private DataGridView dataGridView_1;

	private Button button_2;

	private Button button_3;

	private Button button_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private DataGridViewButtonColumn dataGridViewButtonColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private ToolTip toolTip_0;

	private IContainer icontainer_0;

	public RulesWindow()
	{
		try
		{
			method_2();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this, null);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private int method_0(int int_0, int int_1, int int_2)
	{
		int num = 0;
		if (eRules[int_0].RemoveValues[int_2])
		{
			return -1;
		}
		if (int_1 >= (nint)eLC_base.Lists[int_0].elementFields.LongLength)
		{
			return -1;
		}
		ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC_recent;
		ACE.Elements.eList.eList eList2 = eListCollection2.Lists[int_0];
		if (int_2 >= (nint)eList2.elementFields.LongLength)
		{
			return -1;
		}
		int num2 = 0;
		int num3 = eList2.elementValues.Length;
		if (0 < num3)
		{
			while (num2 < (nint)eLC_base.Lists[int_0].elementValues.LongLength && num2 < num3)
			{
				if (eLC_base.GetValue(int_0, num2, int_1) != eListCollection2.GetValue(int_0, num2, int_2))
				{
					num++;
				}
				num2++;
				eListCollection2 = eLC_recent;
				num3 = eListCollection2.Lists[int_0].elementValues.Length;
				if (num2 >= num3)
				{
					break;
				}
			}
		}
		GC.KeepAlive(this);
		return num;
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1648964284);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			Cursor = Cursors.AppStarting;
			dataGridView_1.Rows.Clear();
			dataGridView_0.Rows.Clear();
			dataGridViewTextBoxColumn_0.HeaderText = TextStorage.Msg(Class16.smethod_0(1648964312), Class16.smethod_0(1648964339));
			dataGridViewTextBoxColumn_1.HeaderText = TextStorage.Msg(Class16.smethod_0(1648964365), Class16.smethod_0(1648964386));
			dataGridViewTextBoxColumn_3.HeaderText = TextStorage.Msg(Class16.smethod_0(1648964414), Class16.smethod_0(1648964433));
			dataGridViewTextBoxColumn_4.HeaderText = TextStorage.Msg(Class16.smethod_0(1648964451), Class16.smethod_0(1648964480));
			comboBox_0.Items.Clear();
			if (sender == button_1)
			{
				eLC_base = new ACE.Elements.eListCollection.eListCollection(openFileDialog.FileName, bMultithread: false);
				textBox_3.Text = openFileDialog.FileName;
				short version = eLC_base.Version;
				textBox_1.Text = version.ToString();
			}
			if (sender == button_0)
			{
				eLC_recent = new ACE.Elements.eListCollection.eListCollection(openFileDialog.FileName, bMultithread: false);
				textBox_2.Text = openFileDialog.FileName;
				short version2 = eLC_recent.Version;
				textBox_0.Text = version2.ToString();
			}
			ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC_base;
			if (eListCollection2 != null)
			{
				ACE.Elements.eListCollection.eListCollection eListCollection3 = eLC_recent;
				if (eListCollection3 != null && (nint)eListCollection2.Lists.LongLength > 0)
				{
					int num = eListCollection3.Lists.Length;
					if (num > 0)
					{
						eRules = new RuleConfig[num];
						int num2 = 0;
						if (0 < (nint)eListCollection3.Lists.LongLength)
						{
							do
							{
								string text = Class16.smethod_0(1648942897);
								ACE.Elements.eList.eList eList2 = eLC_recent.Lists[num2];
								int num3 = eList2.elementValues.Length;
								string text2 = Class16.smethod_0(1648899468);
								string listName = eList2.ListName;
								string text3 = Class16.smethod_0(1648985628);
								string text4 = Class16.smethod_0(1648924364);
								comboBox_0.Items.Add(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(text4 + num2, text3), listName), text2), num3), text));
								eRules[num2] = new RuleConfig();
								eRules[num2].RemoveList = false;
								eRules[num2].ReplaceOffset = false;
								eRules[num2].Offset = string.Empty;
								eRules[num2].RemoveValues = new bool[(nint)eLC_recent.Lists[num2].elementFields.LongLength];
								int num4 = 0;
								if (0 < (nint)eRules[num2].RemoveValues.LongLength)
								{
									do
									{
										eRules[num2].RemoveValues[num4] = false;
										num4++;
									}
									while (num4 < (nint)eRules[num2].RemoveValues.LongLength);
								}
								num2++;
							}
							while (num2 < (nint)eLC_recent.Lists.LongLength);
						}
					}
				}
			}
			Cursor = Cursors.Default;
		}
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RulesWindow));
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		groupBox_0 = new GroupBox();
		button_0 = new Button();
		button_1 = new Button();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		textBox_2 = new TextBox();
		textBox_3 = new TextBox();
		label_0 = new Label();
		label_1 = new Label();
		label_2 = new Label();
		label_3 = new Label();
		groupBox_1 = new GroupBox();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		dataGridView_1 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		dataGridViewButtonColumn_0 = new DataGridViewButtonColumn();
		textBox_4 = new TextBox();
		textBox_5 = new TextBox();
		radioButton_0 = new RadioButton();
		radioButton_1 = new RadioButton();
		checkBox_0 = new CheckBox();
		comboBox_0 = new ComboBox();
		button_2 = new Button();
		button_3 = new Button();
		button_4 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		groupBox_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		((ISupportInitialize)dataGridView_1).BeginInit();
		SuspendLayout();
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_0.Controls.Add(button_0);
		groupBox_0.Controls.Add(button_1);
		groupBox_0.Controls.Add(textBox_0);
		groupBox_0.Controls.Add(textBox_1);
		groupBox_0.Controls.Add(textBox_2);
		groupBox_0.Controls.Add(textBox_3);
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Controls.Add(label_2);
		groupBox_0.Controls.Add(label_3);
		groupBox_0.Location = new Point(0, 2);
		groupBox_0.Name = Class16.smethod_0(1648929126);
		groupBox_0.Size = new Size(792, 75);
		groupBox_0.TabIndex = 0;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1648964508);
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_0.Location = new Point(711, 46);
		button_0.Name = Class16.smethod_0(1648964512);
		button_0.Size = new Size(75, 23);
		button_0.TabIndex = 9;
		button_0.Text = Class16.smethod_0(1648978102);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_1_Click;
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_1.Location = new Point(711, 17);
		button_1.Name = Class16.smethod_0(1648964538);
		button_1.Size = new Size(75, 23);
		button_1.TabIndex = 8;
		button_1.Text = Class16.smethod_0(1648978102);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		textBox_0.Enabled = false;
		textBox_0.Location = new Point(669, 48);
		textBox_0.Name = Class16.smethod_0(1648964562);
		textBox_0.Size = new Size(36, 20);
		textBox_0.TabIndex = 7;
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		textBox_1.Enabled = false;
		textBox_1.Location = new Point(669, 19);
		textBox_1.Name = Class16.smethod_0(1648964598);
		textBox_1.Size = new Size(36, 20);
		textBox_1.TabIndex = 6;
		textBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_2.Enabled = false;
		textBox_2.Location = new Point(75, 48);
		textBox_2.Name = Class16.smethod_0(1648963592);
		textBox_2.Size = new Size(537, 20);
		textBox_2.TabIndex = 5;
		textBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_3.Enabled = false;
		textBox_3.Location = new Point(75, 19);
		textBox_3.Name = Class16.smethod_0(1648963617);
		textBox_3.Size = new Size(537, 20);
		textBox_3.TabIndex = 4;
		label_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		label_0.AutoSize = true;
		label_0.Location = new Point(618, 51);
		label_0.Name = Class16.smethod_0(1648912200);
		label_0.Size = new Size(45, 13);
		label_0.TabIndex = 3;
		label_0.Text = Class16.smethod_0(1648931051);
		label_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		label_1.AutoSize = true;
		label_1.Location = new Point(618, 22);
		label_1.Name = Class16.smethod_0(1648912145);
		label_1.Size = new Size(45, 13);
		label_1.TabIndex = 2;
		label_1.Text = Class16.smethod_0(1648931051);
		label_2.AutoSize = true;
		label_2.Location = new Point(6, 51);
		label_2.Name = Class16.smethod_0(1648912083);
		label_2.Size = new Size(64, 13);
		label_2.TabIndex = 1;
		label_2.Text = Class16.smethod_0(1648963640);
		label_3.AutoSize = true;
		label_3.Location = new Point(6, 22);
		label_3.Name = Class16.smethod_0(1648919238);
		label_3.Size = new Size(53, 13);
		label_3.TabIndex = 0;
		label_3.Text = Class16.smethod_0(1648963659);
		groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_1.Controls.Add(dataGridView_0);
		groupBox_1.Controls.Add(dataGridView_1);
		groupBox_1.Controls.Add(textBox_4);
		groupBox_1.Controls.Add(textBox_5);
		groupBox_1.Controls.Add(radioButton_0);
		groupBox_1.Controls.Add(radioButton_1);
		groupBox_1.Controls.Add(checkBox_0);
		groupBox_1.Controls.Add(comboBox_0);
		groupBox_1.Location = new Point(0, 83);
		groupBox_1.Name = Class16.smethod_0(1648929037);
		groupBox_1.Size = new Size(792, 457);
		groupBox_1.TabIndex = 1;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1648963684);
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_3, dataGridViewTextBoxColumn_4);
		dataGridView_0.Location = new Point(488, 98);
		dataGridView_0.Name = Class16.smethod_0(1648963688);
		dataGridView_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridView_0.Size = new Size(298, 353);
		dataGridView_0.TabIndex = 7;
		dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648964433);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1648963714);
		dataGridViewTextBoxColumn_3.ReadOnly = true;
		dataGridViewTextBoxColumn_3.Width = 91;
		dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		dataGridViewTextBoxColumn_4.HeaderText = Class16.smethod_0(1648964480);
		dataGridViewTextBoxColumn_4.Name = Class16.smethod_0(1648963728);
		dataGridViewTextBoxColumn_4.ReadOnly = true;
		dataGridViewTextBoxColumn_4.Width = 102;
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToDeleteRows = false;
		dataGridView_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_1.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1, dataGridViewTextBoxColumn_2, dataGridViewCheckBoxColumn_0, dataGridViewButtonColumn_0);
		dataGridView_1.Location = new Point(6, 98);
		dataGridView_1.Name = Class16.smethod_0(1648963750);
		dataGridView_1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridView_1.Size = new Size(476, 353);
		dataGridView_1.TabIndex = 6;
		toolTip_0.SetToolTip(dataGridView_1, componentResourceManager.GetString(Class16.smethod_0(1648963768)));
		dataGridView_1.CellContentClick += dataGridView_1_CellContentClick;
		dataGridView_1.CellValueChanged += dataGridView_1_CellValueChanged;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648964339);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648990839);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.Width = 86;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648964386);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648990853);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.Width = 97;
		dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648963802);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648963825);
		dataGridViewTextBoxColumn_2.ReadOnly = true;
		dataGridViewCheckBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		dataGridViewCheckBoxColumn_0.HeaderText = Class16.smethod_0(1648941934);
		dataGridViewCheckBoxColumn_0.Name = Class16.smethod_0(1648963847);
		dataGridViewCheckBoxColumn_0.Width = 34;
		dataGridViewButtonColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewButtonColumn_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridViewButtonColumn_0.HeaderText = Class16.smethod_0(1648963861);
		dataGridViewButtonColumn_0.Name = Class16.smethod_0(1648963867);
		dataGridViewButtonColumn_0.Width = 50;
		textBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_4.Location = new Point(131, 72);
		textBox_4.Name = Class16.smethod_0(1648963881);
		textBox_4.Size = new Size(655, 20);
		textBox_4.TabIndex = 5;
		textBox_5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_5.Location = new Point(131, 46);
		textBox_5.Name = Class16.smethod_0(1648963916);
		textBox_5.Size = new Size(655, 20);
		textBox_5.TabIndex = 4;
		radioButton_0.AutoSize = true;
		radioButton_0.Location = new Point(6, 73);
		radioButton_0.Name = Class16.smethod_0(1648963941);
		radioButton_0.Size = new Size(119, 17);
		radioButton_0.TabIndex = 3;
		radioButton_0.TabStop = true;
		radioButton_0.Text = Class16.smethod_0(1648963972);
		toolTip_0.SetToolTip(radioButton_0, Class16.smethod_0(1648963997));
		radioButton_0.UseVisualStyleBackColor = true;
		radioButton_1.AutoSize = true;
		radioButton_1.Location = new Point(6, 47);
		radioButton_1.Name = Class16.smethod_0(1648967260);
		radioButton_1.Size = new Size(102, 17);
		radioButton_1.TabIndex = 2;
		radioButton_1.TabStop = true;
		radioButton_1.Text = Class16.smethod_0(1648967281);
		toolTip_0.SetToolTip(radioButton_1, componentResourceManager.GetString(Class16.smethod_0(1648967311)));
		radioButton_1.UseVisualStyleBackColor = true;
		radioButton_1.CheckedChanged += radioButton_1_CheckedChanged;
		checkBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(701, 21);
		checkBox_0.Name = Class16.smethod_0(1648967348);
		checkBox_0.Size = new Size(85, 17);
		checkBox_0.TabIndex = 1;
		checkBox_0.Text = Class16.smethod_0(1648967374);
		toolTip_0.SetToolTip(checkBox_0, Class16.smethod_0(1648967384));
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		comboBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(6, 19);
		comboBox_0.Name = Class16.smethod_0(1648990734);
		comboBox_0.Size = new Size(689, 21);
		comboBox_0.TabIndex = 0;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		button_2.Anchor = AnchorStyles.Bottom;
		button_2.Location = new Point(346, 546);
		button_2.Name = Class16.smethod_0(1648967416);
		button_2.Size = new Size(100, 23);
		button_2.TabIndex = 2;
		button_2.Text = Class16.smethod_0(1648967434);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Anchor = AnchorStyles.Bottom;
		button_3.Location = new Point(240, 546);
		button_3.Name = Class16.smethod_0(1648967462);
		button_3.Size = new Size(100, 23);
		button_3.TabIndex = 2;
		button_3.Text = Class16.smethod_0(1648967474);
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		button_4.Anchor = AnchorStyles.Bottom;
		button_4.Location = new Point(452, 546);
		button_4.Name = Class16.smethod_0(1648967496);
		button_4.Size = new Size(100, 23);
		button_4.TabIndex = 2;
		button_4.Text = Class16.smethod_0(1648967524);
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		toolTip_0.AutomaticDelay = 0;
		toolTip_0.AutoPopDelay = 25000;
		toolTip_0.InitialDelay = 0;
		toolTip_0.ReshowDelay = 0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(844, 573);
		base.Controls.Add(button_2);
		base.Controls.Add(button_3);
		base.Controls.Add(button_4);
		base.Controls.Add(groupBox_1);
		base.Controls.Add(groupBox_0);
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(860, 600);
		base.Name = Class16.smethod_0(1648967538);
		base.ShowIcon = false;
		Text = Class16.smethod_0(1648967564);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		((ISupportInitialize)dataGridView_0).EndInit();
		((ISupportInitialize)dataGridView_1).EndInit();
		ResumeLayout(performLayout: false);
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_1();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		Cursor = Cursors.AppStarting;
		dataGridView_1.Rows.Clear();
		dataGridView_0.Rows.Clear();
		dataGridViewTextBoxColumn_0.HeaderText = TextStorage.Msg(Class16.smethod_0(1648967605), Class16.smethod_0(1648964339));
		dataGridViewTextBoxColumn_1.HeaderText = TextStorage.Msg(Class16.smethod_0(1648967626), Class16.smethod_0(1648964386));
		dataGridViewTextBoxColumn_3.HeaderText = TextStorage.Msg(Class16.smethod_0(1648967657), Class16.smethod_0(1648964433));
		dataGridViewTextBoxColumn_4.HeaderText = TextStorage.Msg(Class16.smethod_0(1648966670), Class16.smethod_0(1648964480));
		int selectedIndex = comboBox_0.SelectedIndex;
		if (selectedIndex > -1)
		{
			checkBox_0.Checked = eRules[selectedIndex].RemoveList;
			ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC_base;
			ACE.Elements.eList.eList[] lists = eListCollection2.Lists;
			if ((nint)lists.LongLength > selectedIndex && eListCollection2.ConversationListIndex != selectedIndex)
			{
				int num = lists[selectedIndex].elementFields.Length;
				string text = Class16.smethod_0(1648942897);
				dataGridViewTextBoxColumn_0.HeaderText = string.Concat(Class16.smethod_0(1648966701) + num, text);
				int num2 = eLC_recent.Lists[selectedIndex].elementFields.Length;
				string text2 = Class16.smethod_0(1648942897);
				dataGridViewTextBoxColumn_1.HeaderText = string.Concat(Class16.smethod_0(1648966713) + num2, text2);
				int num3 = 0;
				if (eRules[selectedIndex].ReplaceOffset)
				{
					radioButton_1.Checked = true;
					radioButton_0.Checked = false;
				}
				else
				{
					radioButton_1.Checked = false;
					radioButton_0.Checked = true;
				}
				textBox_5.Text = eLC_base.GetOffset(selectedIndex);
				textBox_4.Text = eLC_recent.GetOffset(selectedIndex);
				int num4 = 0;
				if (0 < (nint)eLC_recent.Lists[selectedIndex].elementFields.LongLength)
				{
					do
					{
						bool num5 = eRules[selectedIndex].RemoveValues[num4];
						bool flag = num5;
						bool flag2 = num5;
						if (flag)
						{
							num3--;
						}
						object[] values;
						if (!flag2)
						{
							ACE.Elements.eList.eList eList2 = eLC_base.Lists[selectedIndex];
							if (num3 < (nint)eList2.elementFields.LongLength)
							{
								string[] array = new string[5]
								{
									eList2.elementTypes[num3],
									eLC_recent.Lists[selectedIndex].elementTypes[num4],
									method_0(selectedIndex, num3, num4).ToString(),
									null,
									null
								};
								bool flag3 = eRules[selectedIndex].RemoveValues[num4];
								array[3] = flag3.ToString();
								array[4] = Class16.smethod_0(1648966743);
								DataGridViewRowCollection rows = dataGridView_1.Rows;
								values = array;
								rows.Add(values);
								goto IL_0352;
							}
						}
						string[] array2 = new string[5]
						{
							string.Empty,
							eLC_recent.Lists[selectedIndex].elementTypes[num4],
							method_0(selectedIndex, num3, num4).ToString(),
							null,
							null
						};
						bool flag4 = eRules[selectedIndex].RemoveValues[num4];
						array2[3] = flag4.ToString();
						array2[4] = Class16.smethod_0(1648966743);
						DataGridViewRowCollection rows2 = dataGridView_1.Rows;
						values = array2;
						rows2.Add(values);
						goto IL_0352;
						IL_0352:
						int num6 = num4;
						int index = dataGridView_1.Rows.Count - 1;
						dataGridView_1.Rows[index].HeaderCell.Value = num6.ToString();
						num3++;
						num4++;
					}
					while (num4 < (nint)eLC_recent.Lists[selectedIndex].elementFields.LongLength);
				}
			}
		}
		Cursor = Cursors.Default;
		GC.KeepAlive(this);
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		int selectedIndex = comboBox_0.SelectedIndex;
		if (selectedIndex > -1)
		{
			eRules[selectedIndex].RemoveList = checkBox_0.Checked;
		}
		GC.KeepAlive(this);
	}

	private void radioButton_1_CheckedChanged(object sender, EventArgs e)
	{
		int selectedIndex = comboBox_0.SelectedIndex;
		if (selectedIndex > -1)
		{
			if (radioButton_1.Checked)
			{
				eRules[selectedIndex].ReplaceOffset = true;
				eRules[selectedIndex].Offset = eLC_base.GetOffset(selectedIndex);
			}
			else
			{
				eRules[selectedIndex].ReplaceOffset = false;
				eRules[selectedIndex].Offset = string.Empty;
			}
		}
	}

	private void dataGridView_1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void dataGridView_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		int selectedIndex = comboBox_0.SelectedIndex;
		if (selectedIndex > -1)
		{
			if (e.ColumnIndex == 3 && e.RowIndex > -1)
			{
				int rowIndex = dataGridView_1.FirstDisplayedCell.RowIndex;
				int columnIndex = dataGridView_1.FirstDisplayedCell.ColumnIndex;
				DataGridView dataGridView = dataGridView_1;
				ref bool reference = ref eRules[selectedIndex].RemoveValues[e.RowIndex];
				reference = Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
				comboBox_0_SelectedIndexChanged(null, null);
				dataGridView_1.FirstDisplayedCell = dataGridView_1.Rows[rowIndex].Cells[columnIndex];
			}
			if (e.ColumnIndex == 4 && e.RowIndex > -1)
			{
				Cursor = Cursors.AppStarting;
				dataGridView_0.Rows.Clear();
				dataGridViewTextBoxColumn_3.HeaderText = TextStorage.Msg(Class16.smethod_0(1648966757), Class16.smethod_0(1648964433));
				dataGridViewTextBoxColumn_4.HeaderText = TextStorage.Msg(Class16.smethod_0(1648966778), Class16.smethod_0(1648964480));
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				if (0 < e.RowIndex)
				{
					do
					{
						if (eRules[selectedIndex].RemoveValues[num3])
						{
							num--;
						}
						num++;
						num2++;
						num3++;
					}
					while (num3 < e.RowIndex);
				}
				if (num2 < (nint)eLC_recent.Lists[selectedIndex].elementFields.LongLength)
				{
					int num4 = eLC_base.Lists[selectedIndex].elementValues.Length;
					string text = Class16.smethod_0(1648942897);
					dataGridViewTextBoxColumn_3.HeaderText = string.Concat(Class16.smethod_0(1648966809) + num4, text);
					int num5 = eLC_recent.Lists[selectedIndex].elementValues.Length;
					string text2 = Class16.smethod_0(1648942897);
					dataGridViewTextBoxColumn_4.HeaderText = string.Concat(Class16.smethod_0(1648966837) + num5, text2);
					int num6 = 0;
					if (0 < (nint)eLC_recent.Lists[selectedIndex].elementValues.LongLength)
					{
						do
						{
							ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC_base;
							ACE.Elements.eList.eList eList2 = eListCollection2.Lists[selectedIndex];
							if (num6 >= (nint)eList2.elementValues.LongLength || num >= (nint)eList2.elementFields.LongLength || eRules[selectedIndex].RemoveValues[num2])
							{
								string[] array = new string[2]
								{
									string.Empty,
									eLC_recent.GetValue(selectedIndex, num6, num2)
								};
								DataGridViewRowCollection rows = dataGridView_0.Rows;
								object[] values = array;
								rows.Add(values);
							}
							else
							{
								string[] array2 = new string[2]
								{
									eListCollection2.GetValue(selectedIndex, num6, num),
									eLC_recent.GetValue(selectedIndex, num6, num2)
								};
								DataGridViewRowCollection rows2 = dataGridView_0.Rows;
								object[] values = array2;
								rows2.Add(values);
							}
							int num7 = num6;
							int index = dataGridView_0.Rows.Count - 1;
							dataGridView_0.Rows[index].HeaderCell.Value = num7.ToString();
							num6++;
						}
						while (num6 < (nint)eLC_recent.Lists[selectedIndex].elementValues.LongLength);
					}
				}
				Cursor = Cursors.Default;
			}
		}
		GC.KeepAlive(this);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		if (eRules != null)
		{
			string empty = string.Empty;
			empty += Class16.smethod_0(1648966851);
			short version = eLC_base.Version;
			short version2 = eLC_recent.Version;
			string text = Class16.smethod_0(1648966890);
			string text2 = Class16.smethod_0(1648966904);
			empty = string.Concat(empty, string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648966924) + version2, text2), version.ToString()), text));
			empty += Class16.smethod_0(1648966851);
			short version3 = eLC_base.Version;
			empty = string.Concat(empty, Class16.smethod_0(1648966939) + version3);
			short signature = eLC_base.Signature;
			string text3 = Class16.smethod_0(1648924428);
			empty = string.Concat(empty, string.Concat(Class16.smethod_0(1648966967) + signature, text3));
			int num = 0;
			RuleConfig[] array = eRules;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					if (array[num].RemoveList)
					{
						int num2 = num;
						empty = string.Concat(empty, Class16.smethod_0(1648966989) + num2);
					}
					num++;
					array = eRules;
				}
				while (num < (nint)array.LongLength);
			}
			empty += Class16.smethod_0(1648924428);
			int num3 = 0;
			RuleConfig[] array2 = eRules;
			if (0 < (nint)array2.LongLength)
			{
				do
				{
					RuleConfig ruleConfig = array2[num3];
					if (ruleConfig.ReplaceOffset)
					{
						int num4 = num3;
						string offset = ruleConfig.Offset;
						string text4 = Class16.smethod_0(1648905535);
						empty = string.Concat(empty, string.Concat(string.Concat(Class16.smethod_0(1648967001) + num4, text4), offset));
					}
					num3++;
					array2 = eRules;
				}
				while (num3 < (nint)array2.LongLength);
			}
			bool flag = true;
			int num5 = 0;
			if (0 < (nint)eRules.LongLength)
			{
				do
				{
					if (flag)
					{
						empty += Class16.smethod_0(1648924428);
						flag = false;
					}
					int num6 = 0;
					bool[] removeValues = eRules[num5].RemoveValues;
					if (0 < (nint)removeValues.LongLength)
					{
						do
						{
							if (removeValues[num6])
							{
								int num7 = num6;
								int num8 = num5;
								string text5 = Class16.smethod_0(1648924402);
								empty = string.Concat(empty, string.Concat(string.Concat(Class16.smethod_0(1648967024) + num8, text5), num7.ToString()));
								flag = true;
							}
							num6++;
							removeValues = eRules[num5].RemoveValues;
						}
						while (num6 < (nint)removeValues.LongLength);
					}
					num5++;
				}
				while (num5 < (nint)eRules.LongLength);
			}
			short version4 = eLC_base.Version;
			short version5 = eLC_recent.Version;
			string text6 = Class16.smethod_0(1648966904);
			new DebugWindow(string.Concat(string.Concat(Class16.smethod_0(1648967053) + version5, text6), version4.ToString()), empty);
		}
		GC.KeepAlive(this);
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (eRules != null)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = Class16.smethod_0(1648967059);
			if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
			{
				Cursor = Cursors.AppStarting;
				StreamReader streamReader = new StreamReader(openFileDialog.FileName);
				string text = streamReader.ReadLine();
				if (text != null)
				{
					do
					{
						Application.DoEvents();
						if (text != string.Empty && !text.StartsWith(Class16.smethod_0(1648929947)))
						{
							if (text.StartsWith(Class16.smethod_0(1648967102)))
							{
								string[] array = text.Split(':');
								eRules[Convert.ToInt32(array[1])].RemoveList = true;
							}
							if (text.StartsWith(Class16.smethod_0(1648967112)))
							{
								int num = Convert.ToInt32(text.Split(':', '|')[1]);
								eRules[num].ReplaceOffset = true;
								eRules[num].Offset = eLC_base.GetOffset(num);
							}
							if (text.StartsWith(Class16.smethod_0(1648967141)))
							{
								string[] array2 = text.Split(':');
								int num2 = Convert.ToInt32(array2[2]);
								eRules[Convert.ToInt32(array2[1])].RemoveValues[num2] = true;
							}
						}
						text = streamReader.ReadLine();
					}
					while (text != null);
				}
				streamReader.Close();
				comboBox_0_SelectedIndexChanged(null, null);
				Cursor = Cursors.Default;
			}
		}
		GC.KeepAlive(this);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		if (eRules != null)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = Class16.smethod_0(1648967059);
			short version = eLC_base.Version;
			short version2 = eLC_recent.Version;
			string text = Class16.smethod_0(1648967152);
			string text2 = Class16.smethod_0(1648966149);
			saveFileDialog.FileName = string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648966155) + version2, text2), version.ToString()), text);
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Cursor = Cursors.AppStarting;
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
				streamWriter.WriteLine(Class16.smethod_0(1648966174));
				short version3 = eLC_base.Version;
				short version4 = eLC_recent.Version;
				string text3 = Class16.smethod_0(1648966203);
				string text4 = Class16.smethod_0(1648966904);
				streamWriter.WriteLine(string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648966924) + version4, text4), version3.ToString()), text3));
				streamWriter.WriteLine(Class16.smethod_0(1648966174));
				streamWriter.WriteLine();
				short version5 = eLC_base.Version;
				streamWriter.WriteLine(Class16.smethod_0(1648966223) + version5);
				short signature = eLC_base.Signature;
				streamWriter.WriteLine(Class16.smethod_0(1648966233) + signature);
				streamWriter.WriteLine();
				int num = 0;
				RuleConfig[] array = eRules;
				if (0 < (nint)array.LongLength)
				{
					do
					{
						if (array[num].RemoveList)
						{
							int num2 = num;
							streamWriter.WriteLine(Class16.smethod_0(1648967102) + num2);
						}
						num++;
						array = eRules;
					}
					while (num < (nint)array.LongLength);
				}
				streamWriter.WriteLine();
				int num3 = 0;
				RuleConfig[] array2 = eRules;
				if (0 < (nint)array2.LongLength)
				{
					do
					{
						RuleConfig ruleConfig = array2[num3];
						if (ruleConfig.ReplaceOffset)
						{
							int num4 = num3;
							string offset = ruleConfig.Offset;
							string text5 = Class16.smethod_0(1648905535);
							streamWriter.WriteLine(string.Concat(string.Concat(Class16.smethod_0(1648967112) + num4, text5), offset));
						}
						num3++;
						array2 = eRules;
					}
					while (num3 < (nint)array2.LongLength);
				}
				bool flag = true;
				int num5 = 0;
				if (0 < (nint)eRules.LongLength)
				{
					do
					{
						if (flag)
						{
							streamWriter.WriteLine();
							flag = false;
						}
						int num6 = 0;
						bool[] removeValues = eRules[num5].RemoveValues;
						if (0 < (nint)removeValues.LongLength)
						{
							do
							{
								if (removeValues[num6])
								{
									int num7 = num6;
									int num8 = num5;
									string text6 = Class16.smethod_0(1648924402);
									streamWriter.WriteLine(string.Concat(string.Concat(Class16.smethod_0(1648967141) + num8, text6), num7.ToString()));
									flag = true;
								}
								num6++;
								removeValues = eRules[num5].RemoveValues;
							}
							while (num6 < (nint)removeValues.LongLength);
						}
						num5++;
					}
					while (num5 < (nint)eRules.LongLength);
				}
				streamWriter.Close();
				Cursor = Cursors.Default;
			}
		}
		GC.KeepAlive(this);
	}
}
