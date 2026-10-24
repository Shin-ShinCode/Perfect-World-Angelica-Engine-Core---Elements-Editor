using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.License;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class ProbsEditor : Form
{
	public static ItemsWindow ItemsWindow1;

	public static ACE.Elements.eListCollection.eListCollection eLC;

	public static CommonStorage CStorage;

	public static SettingsClass Settings;

	public bool dontchange;

	public bool IsScroller;

	private List<PROB_SUITE_EXTENDED> list_0;

	private List<string> list_1;

	private int int_0;

	private PROB_SUITE_EXTENDED prob_SUITE_EXTENDED_0;

	private List<PROB_VALUES> list_2;

	private ITEMPOS itempos_0;

	private int int_1;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewImageColumn dataGridViewImageColumn_1;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private CheckBox checkBox_0;

	private ToolTip toolTip_0;

	private Button button_3;

	private ComboBox comboBox_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private DataGridView dataGridView_0;

	private NumericUpDown numericUpDown_0;

	private TrackBar trackBar_0;

	private NumericUpDown numericUpDown_1;

	private Button button_4;

	private Label label_0;

	private Button button_5;

	private NumericUpDown numericUpDown_2;

	private IContainer icontainer_0;

	public ProbsEditor(ITEMPOS ItemPos, int SuiteIndex)
	{
		try
		{
			method_4();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_0, value: true);
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			if (Settings.GetSetting(Class16.smethod_0(1648971390), Class16.smethod_0(1648926403), string.Empty) == Class16.smethod_0(1648926418))
			{
				checkBox_0.Checked = true;
			}
			if (ItemPos == null)
			{
				GC.KeepAlive(this);
				return;
			}
			itempos_0 = ItemPos;
			int_1 = ItemPos.int_0;
			list_0 = eLC.ProbSuitesGetAllItemValues(ItemPos);
			dontchange = true;
			List<string> list = (list_1 = eLC.ProbSuitesNames[int_1]);
			int num = 0;
			if (0 < list.Count)
			{
				do
				{
					comboBox_0.Items.Add(method_1(num));
					num++;
				}
				while (num < list_1.Count);
			}
			dontchange = false;
			comboBox_0.SelectedIndex = SuiteIndex;
			byte b = ((list_1.Count > 1) ? ((byte)1) : ((byte)0));
			comboBox_0.Enabled = b != 0;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void ProbsEditor_Shown(object sender, EventArgs e)
	{
		method_9(bool_0: true);
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			TextStorage.TEXTS.ShowMessage(913, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
			GC.KeepAlive(this);
		}
	}

	private unsafe void method_0()
	{
		PROB_SUITE_EXTENDED pROB_SUITE_EXTENDED = prob_SUITE_EXTENDED_0;
		if (pROB_SUITE_EXTENDED == null)
		{
			return;
		}
		float num = default(float);
		if (pROB_SUITE_EXTENDED.IsProbsSumCorrect(&num))
		{
			label_0.Visible = false;
		}
		else
		{
			float value = num;
			int numAfterDecimal = 2;
			if ((double)num < 0.0001)
			{
				numAfterDecimal = 4;
			}
			string text = ACE.RSGlobal.RSGlobal.ToPercent(value, numAfterDecimal);
			label_0.Text = text;
			Color red = Color.Red;
			label_0.ForeColor = red;
			label_0.Visible = true;
		}
		dontchange = true;
		int int_ = int_0;
		int index = int_0;
		comboBox_0.Items[index] = method_1(int_);
		dontchange = false;
	}

	private unsafe string method_1(int int_2)
	{
		string text;
		if (list_0[int_2].IsFixedSize)
		{
			List<PROB_SUITE_EXTENDED> list = list_0;
			List<string> list2 = list_1;
			text = string.Format(Class16.smethod_0(1648938828), list2[int_2], list[int_2].ProbCount);
		}
		else
		{
			object[] vars = new object[3]
			{
				list_1[int_2],
				list_0[int_2].ProbCount,
				list_0[int_2].FieldCount
			};
			text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648971400), vars);
		}
		float num = default(float);
		if (!list_0[int_2].IsProbsSumCorrect(&num))
		{
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648971431));
			text += text2;
		}
		GC.KeepAlive(this);
		return text;
	}

	private void method_2(object sender, EventArgs e)
	{
		method_0();
		method_9(bool_0: false);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		if (dataGridView_0.SelectedRows.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		int index = dataGridView_0.SelectedRows[0].Index;
		if (prob_SUITE_EXTENDED_0.ProbCount > 1 && list_2[index].prob > 0f)
		{
			bool flag = checkBox_0.Checked;
			checkBox_0.Checked = false;
			numericUpDown_0.Value = default(decimal);
			method_6();
			checkBox_0.Checked = flag;
		}
		list_2.RemoveAt(index);
		dataGridView_0.Rows.RemoveAt(index);
		method_0();
		method_9(bool_0: true);
		method_7();
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		int fieldCount = prob_SUITE_EXTENDED_0.FieldCount;
		if (dataGridView_0.RowCount >= fieldCount)
		{
			object[] vars = new object[1] { prob_SUITE_EXTENDED_0.FieldCount };
			TextStorage.TEXTS.ShowMessage(797, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
			GC.KeepAlive(this);
			return;
		}
		string text = numericUpDown_2.Value.ToString();
		if (prob_SUITE_EXTENDED_0.IsItemPresent && text == Class16.smethod_0(1648924112))
		{
			numericUpDown_2_DoubleClick(null, null);
			text = numericUpDown_2.Value.ToString();
			if (CommonStorage.sData == null)
			{
				GC.KeepAlive(this);
				return;
			}
		}
		int int_ = prob_SUITE_EXTENDED_0.ProbCount - 1;
		method_12(prob_SUITE_EXTENDED_0.AddValues(int_1, text), int_);
		int index = dataGridView_0.RowCount - 1;
		dataGridView_0.Rows[index].Selected = true;
		int rowIndex = dataGridView_0.RowCount - 1;
		dataGridView_0.CurrentCell = dataGridView_0[5, rowIndex];
		method_9(bool_0: true);
		method_7();
		method_0();
	}

	private void method_3()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_4()
	{
		icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(ProbsEditor));
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_1 = new DataGridViewImageColumn();
		dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		numericUpDown_0 = new NumericUpDown();
		trackBar_0 = new TrackBar();
		numericUpDown_1 = new NumericUpDown();
		button_4 = new Button();
		label_0 = new Label();
		button_5 = new Button();
		numericUpDown_2 = new NumericUpDown();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		checkBox_0 = new CheckBox();
		toolTip_0 = new ToolTip(icontainer_0);
		button_3 = new Button();
		comboBox_0 = new ComboBox();
		tableLayoutPanel_0 = new TableLayoutPanel();
		((ISupportInitialize)dataGridView_0).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)trackBar_0).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		tableLayoutPanel_0.SuspendLayout();
		SuspendLayout();
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_0.BackgroundColor = Color.FromArgb(32, 32, 32);
		dataGridView_0.BorderStyle = BorderStyle.None;
		dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_0.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewImageColumn_0, dataGridViewTextBoxColumn_1, dataGridViewTextBoxColumn_2, dataGridViewTextBoxColumn_3, dataGridViewTextBoxColumn_4, dataGridViewImageColumn_1, dataGridViewCheckBoxColumn_0);
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(32, 32, 32);
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = Color.White;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = Color.White;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.GridColor = Color.Silver;
		dataGridView_0.Location = new Point(5, 35);
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1648971454);
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648942905), 9f);
		dataGridView_0.RowsDefaultCellStyle = dataGridViewCellStyle3;
		dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 12f);
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellToolTips = false;
		dataGridView_0.Size = new Size(853, 461);
		dataGridView_0.TabIndex = 25;
		dataGridView_0.CellClick += dataGridView_0_CellClick;
		dataGridView_0.CellDoubleClick += dataGridView_0_CellDoubleClick;
		dataGridView_0.CellValueChanged += dataGridView_0_CellValueChanged;
		dataGridView_0.ColumnHeaderMouseClick += dataGridView_0_ColumnHeaderMouseClick;
		dataGridView_0.ColumnWidthChanged += dataGridView_0_ColumnWidthChanged;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridView_0.SortCompare += dataGridView_0_SortCompare;
		dataGridView_0.Sorted += dataGridView_0_Sorted;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle4.ForeColor = Color.FromArgb(210, 210, 210);
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648929955);
		dataGridViewTextBoxColumn_0.Resizable = DataGridViewTriState.False;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 60;
		dataGridViewImageColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewImageColumn_0.HeaderText = string.Empty;
		dataGridViewImageColumn_0.MinimumWidth = 32;
		dataGridViewImageColumn_0.Name = Class16.smethod_0(1648986695);
		dataGridViewImageColumn_0.ReadOnly = true;
		dataGridViewImageColumn_0.Resizable = DataGridViewTriState.False;
		dataGridViewImageColumn_0.Width = 32;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648986725);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_1.Width = 42;
		dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648971469);
		dataGridViewTextBoxColumn_2.MinimumWidth = 74;
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648971475);
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_2.Width = 74;
		dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648971491);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1648971505);
		dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_3.Width = 50;
		dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle5;
		dataGridViewTextBoxColumn_4.FillWeight = 90f;
		dataGridViewTextBoxColumn_4.HeaderText = Class16.smethod_0(1648941080);
		dataGridViewTextBoxColumn_4.Name = Class16.smethod_0(1648986743);
		dataGridViewTextBoxColumn_4.SortMode = DataGridViewColumnSortMode.Programmatic;
		dataGridViewTextBoxColumn_4.Width = 90;
		dataGridViewImageColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewImageColumn_1.HeaderText = string.Empty;
		dataGridViewImageColumn_1.Name = Class16.smethod_0(1648926525);
		dataGridViewImageColumn_1.ReadOnly = true;
		dataGridViewImageColumn_1.SortMode = DataGridViewColumnSortMode.Programmatic;
		dataGridViewCheckBoxColumn_0.HeaderText = Class16.smethod_0(1648926548);
		dataGridViewCheckBoxColumn_0.Name = Class16.smethod_0(1648986757);
		dataGridViewCheckBoxColumn_0.ReadOnly = true;
		numericUpDown_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		numericUpDown_0.DecimalPlaces = 4;
		numericUpDown_0.Location = new Point(80, 503);
		numericUpDown_0.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_0.Name = Class16.smethod_0(1648926574);
		numericUpDown_0.Size = new Size(89, 22);
		numericUpDown_0.TabIndex = 42;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		trackBar_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		trackBar_0.LargeChange = 50;
		trackBar_0.Location = new Point(175, 503);
		trackBar_0.Margin = new Padding(3, 4, 3, 4);
		trackBar_0.Maximum = 1000;
		trackBar_0.Name = Class16.smethod_0(1648926599);
		trackBar_0.Size = new Size(616, 45);
		trackBar_0.SmallChange = 10;
		trackBar_0.TabIndex = 41;
		trackBar_0.TickFrequency = 10;
		trackBar_0.TickStyle = TickStyle.None;
		trackBar_0.Scroll += trackBar_0_Scroll;
		trackBar_0.MouseDown += trackBar_0_MouseDown;
		trackBar_0.MouseUp += trackBar_0_MouseUp;
		numericUpDown_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		numericUpDown_1.BackColor = Color.FromArgb(225, 255, 225);
		numericUpDown_1.Increment = new decimal(new int[4]);
		numericUpDown_1.Location = new Point(5, 503);
		numericUpDown_1.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_1.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_1.Name = Class16.smethod_0(1648926630);
		numericUpDown_1.Size = new Size(69, 22);
		numericUpDown_1.TabIndex = 44;
		numericUpDown_1.TextAlign = HorizontalAlignment.Center;
		numericUpDown_1.ValueChanged += numericUpDown_1_ValueChanged;
		numericUpDown_1.DoubleClick += numericUpDown_1_DoubleClick;
		button_4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_4.Image = Resources.ProbsEditor_cmdAdd;
		button_4.ImageAlign = ContentAlignment.MiddleRight;
		button_4.Location = new Point(444, 5);
		button_4.Name = Class16.smethod_0(1648926646);
		button_4.Size = new Size(131, 27);
		button_4.TabIndex = 64;
		button_4.Text = Class16.smethod_0(1648931361);
		button_4.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		label_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		label_0.BackColor = Color.FromArgb(32, 32, 32);
		label_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.ForeColor = Color.White;
		label_0.Location = new Point(773, 466);
		label_0.Name = Class16.smethod_0(1648926651);
		label_0.Size = new Size(63, 30);
		label_0.TabIndex = 63;
		label_0.Text = Class16.smethod_0(1648926675);
		label_0.TextAlign = ContentAlignment.MiddleCenter;
		label_0.Visible = false;
		button_5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_5.Image = Resources.ProbsEditor_cmdDel;
		button_5.ImageAlign = ContentAlignment.MiddleRight;
		button_5.Location = new Point(576, 5);
		button_5.Name = Class16.smethod_0(1648925697);
		button_5.Size = new Size(131, 27);
		button_5.TabIndex = 65;
		button_5.Text = Class16.smethod_0(1648925718);
		button_5.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		numericUpDown_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		numericUpDown_2.BackColor = Color.FromArgb(225, 255, 225);
		numericUpDown_2.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_2.Location = new Point(354, 7);
		numericUpDown_2.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_2.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_2.Name = Class16.smethod_0(1648971521);
		numericUpDown_2.Size = new Size(87, 25);
		numericUpDown_2.TabIndex = 66;
		numericUpDown_2.TextAlign = HorizontalAlignment.Center;
		numericUpDown_2.DoubleClick += numericUpDown_2_DoubleClick;
		button_0.DialogResult = DialogResult.OK;
		button_0.Dock = DockStyle.Fill;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.ProbsEditor_cmdok;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(3, 3);
		button_0.Name = Class16.smethod_0(1648925748);
		button_0.Size = new Size(425, 26);
		button_0.TabIndex = 67;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648941761);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.Cancel;
		button_1.Dock = DockStyle.Fill;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.ProbsEditor_cmdcancel;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(434, 3);
		button_1.Name = Class16.smethod_0(1648925752);
		button_1.Size = new Size(426, 26);
		button_1.TabIndex = 68;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_2.Image = Resources.ProbsEditor_cmdSort;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(720, 5);
		button_2.Name = Class16.smethod_0(1648925768);
		button_2.Size = new Size(116, 27);
		button_2.TabIndex = 69;
		button_2.Text = Class16.smethod_0(1648925790);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		checkBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(841, 13);
		checkBox_0.Margin = new Padding(3, 4, 3, 4);
		checkBox_0.Name = Class16.smethod_0(1648925793);
		checkBox_0.Size = new Size(15, 14);
		checkBox_0.TabIndex = 72;
		toolTip_0.SetToolTip(checkBox_0, Class16.smethod_0(1648986158));
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.Click += checkBox_0_Click;
		button_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(797, 499);
		button_3.Name = Class16.smethod_0(1648920454);
		button_3.Size = new Size(61, 27);
		button_3.TabIndex = 73;
		button_3.Text = Class16.smethod_0(1648920478);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		comboBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(5, 7);
		comboBox_0.Name = Class16.smethod_0(1648971539);
		comboBox_0.Size = new Size(343, 23);
		comboBox_0.TabIndex = 74;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		tableLayoutPanel_0.ColumnCount = 2;
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel_0.Controls.Add(button_0, 0, 0);
		tableLayoutPanel_0.Controls.Add(button_1, 1, 0);
		tableLayoutPanel_0.Dock = DockStyle.Bottom;
		tableLayoutPanel_0.Location = new Point(0, 528);
		tableLayoutPanel_0.Name = Class16.smethod_0(1648929366);
		tableLayoutPanel_0.RowCount = 1;
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		tableLayoutPanel_0.Size = new Size(863, 32);
		tableLayoutPanel_0.TabIndex = 75;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_1;
		base.ClientSize = new Size(863, 560);
		base.Controls.Add(tableLayoutPanel_0);
		base.Controls.Add(comboBox_0);
		base.Controls.Add(button_3);
		base.Controls.Add(label_0);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(button_2);
		base.Controls.Add(numericUpDown_2);
		base.Controls.Add(button_5);
		base.Controls.Add(button_4);
		base.Controls.Add(numericUpDown_1);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(trackBar_0);
		base.Controls.Add(dataGridView_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.Icon = Resources.ProbsEditor_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MinimizeBox = false;
		MinimumSize = new Size(750, 500);
		base.Name = Class16.smethod_0(1648971390);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648971567);
		toolTip_0.SetToolTip(this, Class16.smethod_0(1648920548));
		base.FormClosed += ProbsEditor_FormClosed;
		base.Load += ProbsEditor_Load;
		base.Shown += ProbsEditor_Shown;
		base.Resize += ProbsEditor_Resize;
		((ISupportInitialize)dataGridView_0).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)trackBar_0).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		((ISupportInitialize)numericUpDown_2).EndInit();
		tableLayoutPanel_0.ResumeLayout(performLayout: false);
		tableLayoutPanel_0.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_3();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		int rowIndex = e.RowIndex;
		int columnIndex = e.ColumnIndex;
		if (dontchange || rowIndex < 0)
		{
			return;
		}
		if (dataGridView_0[columnIndex, rowIndex].Value == null)
		{
			GC.KeepAlive(this);
			return;
		}
		dontchange = true;
		string text = dataGridView_0[columnIndex, rowIndex].Value.ToString().Trim();
		switch (columnIndex)
		{
		case 0:
		{
			if (!ACE.RSGlobal.RSGlobal.IsUIntFast(text))
			{
				text = Class16.smethod_0(1648924112);
			}
			ref int id = ref list_2[rowIndex].id;
			id = ACE.RSGlobal.RSGlobal.UIntParseFast(text);
			int id2 = list_2[rowIndex].id;
			int[] availableLists = prob_SUITE_EXTENDED_0.AvailableLists;
			ITEMPOS itemPos = eLC.FindItemPos(availableLists, id2);
			ITEMINFO itemInfo = eLC.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
			if (itemInfo != null)
			{
				string name = itemInfo.name;
				dataGridView_0[2, rowIndex].Value = name;
				dataGridView_0[2, rowIndex].Style.ForeColor = itemInfo.color;
				string iconName = itemInfo.IconName;
				ICONS icons = eLC.Icons;
				dataGridView_0[1, rowIndex].Value = icons.GetIcon(iconName, IsTga: false);
			}
			else
			{
				string value6 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648902988));
				dataGridView_0[2, rowIndex].Value = value6;
				Color red = Color.Red;
				dataGridView_0[2, rowIndex].Style.ForeColor = red;
				dataGridView_0[1, rowIndex].Value = ICONS.NopeIcon;
			}
			numericUpDown_1.Text = text;
			break;
		}
		case 3:
			list_2[rowIndex].val1 = text;
			break;
		case 4:
			list_2[rowIndex].val2 = text;
			break;
		case 5:
		{
			if (text.Contains(Class16.smethod_0(1648923229)))
			{
				text = text.Substring(0, text.Length - 1);
			}
			else
			{
				DataGridViewCell dataGridViewCell = dataGridView_0[5, rowIndex];
				string text2 = Class16.smethod_0(1648923229);
				dataGridViewCell.Value = string.Concat(dataGridViewCell.Value, text2);
			}
			if (!ACE.RSGlobal.RSGlobal.IsNumber(text))
			{
				text = Class16.smethod_0(1648924112);
				string value = Class16.smethod_0(1648919583);
				dataGridView_0[5, rowIndex].Value = value;
			}
			if (Convert.ToDouble(text) > 100.0)
			{
				text = Class16.smethod_0(1648919573);
				string value2 = Class16.smethod_0(1648926675);
				dataGridView_0[5, rowIndex].Value = value2;
			}
			else if (Convert.ToDouble(text) < 0.0)
			{
				text = Class16.smethod_0(1648924112);
				string value3 = Class16.smethod_0(1648919583);
				dataGridView_0[5, rowIndex].Value = value3;
			}
			decimal num = 100m;
			decimal value4 = Convert.ToDecimal(text) / num;
			ref float prob = ref list_2[rowIndex].prob;
			prob = Convert.ToSingle(value4);
			decimal value5 = Convert.ToDecimal(text);
			numericUpDown_0.Value = value5;
			method_0();
			method_9(bool_0: false);
			break;
		}
		}
		dontchange = false;
	}

	private void numericUpDown_1_DoubleClick(object sender, EventArgs e)
	{
		method_5();
	}

	private void method_5()
	{
		if (prob_SUITE_EXTENDED_0.IsItemPresent)
		{
			CStorage.ResetBuffer();
			decimal value = numericUpDown_1.Value;
			int[] availableLists = prob_SUITE_EXTENDED_0.AvailableLists;
			ITEMPOS iTEMPOS = eLC.FindItemPos(availableLists, (int)value);
			if (iTEMPOS != null)
			{
				ItemsWindow1.newitemlist = iTEMPOS.int_0;
				ItemsWindow1.newitemindex = iTEMPOS.int_1;
			}
			ItemsWindow1.newlistsindices = prob_SUITE_EXTENDED_0.AvailableLists;
			ItemsWindow1.ShowDialog();
			if (CommonStorage.sData != null && CommonStorage.sData != string.Empty)
			{
				numericUpDown_1.Text = CommonStorage.sData;
			}
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if ((prob_SUITE_EXTENDED_0.IsItemPresent && e.ColumnIndex == 1) || e.ColumnIndex == 2 || e.ColumnIndex == 6)
		{
			method_5();
		}
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		if (dontchange)
		{
			return;
		}
		dontchange = true;
		int index;
		NumericUpDown numericUpDown;
		object obj;
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			DataGridView dataGridView = dataGridView_0;
			int probCount = prob_SUITE_EXTENDED_0.ProbCount;
			if (dataGridView.SelectedRows[0].Index < probCount)
			{
				index = dataGridView_0.SelectedRows[0].Index;
				numericUpDown = numericUpDown_1;
				object value = dataGridView_0[0, index].Value;
				if (value == null)
				{
					obj = null;
				}
				else
				{
					obj = value.ToString();
					if (obj != null)
					{
						goto IL_0099;
					}
				}
				obj = Class16.smethod_0(1648924112);
				goto IL_0099;
			}
		}
		numericUpDown_1.Text = Class16.smethod_0(1648924112);
		trackBar_0.Value = 0;
		numericUpDown_0.Text = Class16.smethod_0(1648924112);
		goto IL_012e;
		IL_0099:
		numericUpDown.Text = (string)obj;
		decimal value2 = ACE.RSGlobal.RSGlobal.ToDecimalSafe(list_2[index].prob * 100f);
		numericUpDown_0.Value = value2;
		decimal num = 10m;
		decimal num2 = numericUpDown_0.Value * num;
		trackBar_0.Value = (int)num2;
		goto IL_012e;
		IL_012e:
		method_7();
		dontchange = false;
	}

	private void numericUpDown_1_ValueChanged(object sender, EventArgs e)
	{
		if (!dontchange)
		{
			if (dataGridView_0.SelectedRows.Count < 1)
			{
				GC.KeepAlive(this);
				return;
			}
			decimal value = numericUpDown_1.Value;
			DataGridView dataGridView = dataGridView_0;
			dataGridView_0[0, dataGridView.SelectedRows[0].Index].Value = value.ToString();
			GC.KeepAlive(this);
		}
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (!dontchange)
		{
			if (dataGridView_0.SelectedRows.Count < 1)
			{
				GC.KeepAlive(this);
				return;
			}
			decimal num = 10m;
			decimal num2 = numericUpDown_0.Value * num;
			trackBar_0.Value = (int)num2;
			method_6();
		}
	}

	private void trackBar_0_Scroll(object sender, EventArgs e)
	{
		if (!dontchange)
		{
			decimal value = trackBar_0.Value / 10;
			numericUpDown_0.Value = value;
			GC.KeepAlive(this);
		}
	}

	private void dataGridView_0_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 7 && e.RowIndex > -1)
		{
			int num = ((!(bool)dataGridView_0[7, e.RowIndex].Value) ? 1 : 0);
			dataGridView_0[7, e.RowIndex].Value = (byte)num != 0;
			dataGridView_0.RefreshEdit();
		}
		GC.KeepAlive(this);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_11(bool_0: true);
		dataGridView_0.Focus();
		GC.KeepAlive(this);
	}

	private void ProbsEditor_Load(object sender, EventArgs e)
	{
	}

	private void ProbsEditor_FormClosed(object sender, FormClosedEventArgs e)
	{
		bool flag = checkBox_0.Checked;
		Settings.SaveSetting(Class16.smethod_0(1648971390), Class16.smethod_0(1648926403), flag.ToString());
		GC.KeepAlive(this);
	}

	private void method_6()
	{
		float num6;
		if (dataGridView_0.RowCount != 0 && dataGridView_0.SelectedRows.Count != 0)
		{
			int index = dataGridView_0.SelectedRows[0].Index;
			decimal num = 100m;
			float num2 = (float)(numericUpDown_0.Value / num);
			if (num2 < 1E-06f)
			{
				num2 = 0f;
			}
			else if (num2 > 1f)
			{
				num2 = 1f;
			}
			float num3 = 1f;
			float num4 = 0f;
			int num5 = 0;
			num6 = 0f;
			int num7 = 0;
			if (0 < prob_SUITE_EXTENDED_0.ProbCount)
			{
				do
				{
					if (num7 != index)
					{
						num6 = (float)((double)list_2[num7].prob + (double)num6);
						if ((bool)dataGridView_0[7, num7].Value)
						{
							num3 = (float)((double)num3 - (double)list_2[num7].prob);
							num5++;
						}
						else
						{
							num4 = (float)((double)list_2[num7].prob + (double)num4);
						}
					}
					num7++;
				}
				while (num7 < prob_SUITE_EXTENDED_0.ProbCount);
			}
			int num8 = (((double)Math.Abs((float)(1.0 - (double)num6)) < 5E-07 && !((double)list_2[index].prob <= 5E-07)) ? 1 : 0);
			if ((byte)num8 == 0)
			{
				if ((double)num3 - (double)num2 < 0.0 && num4 > 0f)
				{
					num2 = (float)((double)list_2[index].prob + (double)num4);
				}
				num3 = (float)((double)num3 - (double)num2);
				if (num3 < 0f || (num4 == 0f && num5 >= prob_SUITE_EXTENDED_0.ProbCount - 1))
				{
					decimal value = ACE.RSGlobal.RSGlobal.ToDecimalSafe(list_2[index].prob * 100f);
					numericUpDown_0.Value = value;
					GC.KeepAlive(this);
					return;
				}
				dontchange = true;
				list_2[index].prob = num2;
				float prob = list_2[index].prob;
				int numAfterDecimal = 2;
				if ((double)prob < 0.0001)
				{
					numAfterDecimal = 4;
				}
				string value2 = ACE.RSGlobal.RSGlobal.ToPercent(prob, numAfterDecimal);
				dataGridView_0[5, index].Value = value2;
				if (checkBox_0.Checked)
				{
					prob_SUITE_EXTENDED_0.coefficients = method_8(num4, num3, index);
				}
				else
				{
					PROB_SUITE_EXTENDED pROB_SUITE_EXTENDED = prob_SUITE_EXTENDED_0;
					if ((nint)pROB_SUITE_EXTENDED.coefficients.LongLength != pROB_SUITE_EXTENDED.ProbCount)
					{
						method_7();
					}
				}
				int num9 = 0;
				if (0 < prob_SUITE_EXTENDED_0.ProbCount)
				{
					do
					{
						if (!(bool)dataGridView_0[7, num9].Value && num9 != index)
						{
							float prob2 = (float)((double)prob_SUITE_EXTENDED_0.coefficients[num9] * (double)num3);
							list_2[num9].prob = prob2;
							float prob3 = list_2[num9].prob;
							int numAfterDecimal2 = 2;
							if ((double)prob3 < 0.0001)
							{
								numAfterDecimal2 = 4;
							}
							string value3 = ACE.RSGlobal.RSGlobal.ToPercent(prob3, numAfterDecimal2);
							dataGridView_0[5, num9].Value = value3;
						}
						num9++;
					}
					while (num9 < prob_SUITE_EXTENDED_0.ProbCount);
				}
				num6 = 0f;
				int num10 = 0;
				if (0 >= prob_SUITE_EXTENDED_0.ProbCount)
				{
					goto IL_03dd;
				}
				do
				{
					num6 = (float)((double)list_2[num10].prob + (double)num6);
					num10++;
				}
				while (num10 < prob_SUITE_EXTENDED_0.ProbCount);
			}
			if (num6 != 1f)
			{
				goto IL_03dd;
			}
			goto IL_048b;
		}
		GC.KeepAlive(this);
		return;
		IL_048b:
		dontchange = false;
		method_0();
		method_9(bool_0: false);
		return;
		IL_03dd:
		int maxProbIndex = PROB_VALUES.GetMaxProbIndex(list_2);
		ref float prob4 = ref list_2[maxProbIndex].prob;
		prob4 = (float)(1.0 - (double)num6 + (double)prob4);
		if (list_2[maxProbIndex].prob < 0f)
		{
			list_2[maxProbIndex].prob = 0f;
		}
		float prob5 = list_2[maxProbIndex].prob;
		int numAfterDecimal3 = 2;
		if ((double)prob5 < 0.0001)
		{
			numAfterDecimal3 = 4;
		}
		string value4 = ACE.RSGlobal.RSGlobal.ToPercent(prob5, numAfterDecimal3);
		dataGridView_0[5, maxProbIndex].Value = value4;
		goto IL_048b;
	}

	private void method_7()
	{
		prob_SUITE_EXTENDED_0.coefficients = new float[prob_SUITE_EXTENDED_0.ProbCount];
		if (dataGridView_0.SelectedRows.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		float num = (float)trackBar_0.Value / 1000f;
		if (num < 1E-06f)
		{
			num = 0f;
		}
		float num2 = (float)(1.0 - (double)num);
		float num3 = 0f;
		int index = dataGridView_0.SelectedRows[0].Index;
		int num4 = 0;
		if (0 < prob_SUITE_EXTENDED_0.ProbCount)
		{
			do
			{
				if (num4 != index)
				{
					if ((bool)dataGridView_0[7, num4].Value)
					{
						num2 = (float)((double)num2 - (double)list_2[num4].prob);
					}
					else
					{
						num3 = (float)((double)list_2[num4].prob + (double)num3);
					}
				}
				num4++;
			}
			while (num4 < prob_SUITE_EXTENDED_0.ProbCount);
		}
		prob_SUITE_EXTENDED_0.coefficients = method_8(num3, num2, index);
	}

	private float[] method_8(float float_0, float float_1, int int_2)
	{
		float[] array = new float[prob_SUITE_EXTENDED_0.ProbCount];
		if (float_0 > 0f)
		{
			int num = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					if (!(bool)dataGridView_0[7, num].Value && num != int_2)
					{
						float num2 = (float)((double)list_2[num].prob / (double)float_0);
						if (float_1 <= 0f)
						{
							num2 = 0f;
						}
						array[num] = num2;
					}
					num++;
				}
				while (num < (nint)array.LongLength);
			}
		}
		else
		{
			float num3 = (float)(1.0 / (double)(float)prob_SUITE_EXTENDED_0.ProbCount);
			int num4 = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					array[num4] = num3;
					num4++;
				}
				while (num4 < (nint)array.LongLength);
			}
		}
		GC.KeepAlive(this);
		return array;
	}

	private void method_9([MarshalAs(UnmanagedType.U1)] bool bool_0)
	{
		ACE.RSGlobal.RSGlobal.recurse_level_UpdateGraphicalProbs_ProbsEditor++;
		ACE.RSGlobal.RSGlobal.valid_recurse_level_UpdateGraphicalProbs_ProbsEditor = ACE.RSGlobal.RSGlobal.recurse_level_UpdateGraphicalProbs_ProbsEditor;
		PROB_SUITE_EXTENDED pROB_SUITE_EXTENDED = prob_SUITE_EXTENDED_0;
		if (pROB_SUITE_EXTENDED != null && pROB_SUITE_EXTENDED.ProbCount == dataGridView_0.RowCount)
		{
			int num = Math.Max(1, dataGridView_0.Columns[6].Width);
			int num2 = 0;
			int num3 = Math.Min(prob_SUITE_EXTENDED_0.ProbCount, dataGridView_0.RowCount);
			if (0 < num3)
			{
				while (num2 < num3)
				{
					int num4 = Math.Max(1, dataGridView_0.Rows[num2].Height);
					if (!bool_0)
					{
						float prob = list_2[num2].prob;
						int num5 = 0;
						if (prob > 1E-06f)
						{
							num5 = (int)((double)(float)num * (double)prob - 2.0);
							num5 = ((num5 < 1) ? 1 : num5);
						}
						int num6 = Convert.ToInt32(dataGridView_0[6, num2].Tag ?? ((object)(-1)));
						if (num6 == num5)
						{
							num2++;
							continue;
						}
					}
					float prob2 = list_2[num2].prob;
					dataGridView_0[6, num2].Value = ACE.RSGlobal.RSGlobal.DrawProgress(prob2, num, num4);
					float prob3 = list_2[num2].prob;
					int num7 = 0;
					if (prob3 > 1E-06f)
					{
						num7 = (int)((double)(float)num * (double)prob3 - 2.0);
						num7 = ((num7 < 1) ? 1 : num7);
					}
					dataGridView_0[6, num2].Tag = num7;
					num2++;
				}
			}
		}
		ACE.RSGlobal.RSGlobal.recurse_level_UpdateGraphicalProbs_ProbsEditor--;
		GC.KeepAlive(this);
	}

	private void ProbsEditor_Resize(object sender, EventArgs e)
	{
	}

	private void trackBar_0_MouseUp(object sender, MouseEventArgs e)
	{
	}

	private void method_10()
	{
		PROB_SUITE_EXTENDED pROB_SUITE_EXTENDED = prob_SUITE_EXTENDED_0;
		if (pROB_SUITE_EXTENDED != null && !pROB_SUITE_EXTENDED.IsFixedSize)
		{
			List<PROB_VALUES> valuesList = (list_2 = PROB_VALUES.SortDesceding(list_2));
			prob_SUITE_EXTENDED_0.ValuesList = valuesList;
		}
	}

	private void dataGridView_0_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
	{
		if (e.Column.Index == 5 || e.Column.Index == 6)
		{
			int rowIndex = e.RowIndex1;
			int rowIndex2 = e.RowIndex2;
			float num = (float)dataGridView_0[5, rowIndex].Tag;
			float num2 = (float)dataGridView_0[5, rowIndex2].Tag;
			if ((double)num > (double)num2)
			{
				e.SortResult = 1;
				e.Handled = true;
			}
			else if ((double)num < (double)num2)
			{
				e.SortResult = -1;
				e.Handled = true;
			}
			else
			{
				e.SortResult = 0;
			}
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_0_Sorted(object sender, EventArgs e)
	{
	}

	private void dataGridView_0_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
	{
		if (e.Column.Index == 6)
		{
			method_9(bool_0: true);
		}
	}

	private void dataGridView_0_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex == 5 || e.ColumnIndex == 6)
		{
			method_11(bool_0: true);
		}
	}

	private void checkBox_0_Click(object sender, EventArgs e)
	{
		if (checkBox_0.Checked)
		{
			method_11(bool_0: true);
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (dataGridView_0.RowCount < 1)
		{
			GC.KeepAlive(this);
			return;
		}
		decimal num = prob_SUITE_EXTENDED_0.ProbCount;
		float num2 = (float)(1m / num);
		float num3 = 0f;
		dontchange = true;
		int num4 = prob_SUITE_EXTENDED_0.ProbCount - 1;
		if (num4 >= 0)
		{
			do
			{
				num3 = (float)((double)num3 + (double)num2);
				if (num4 == 0 && num3 != 1f)
				{
					num2 = (float)(1.0 - (double)num3 + (double)num2);
				}
				int numAfterDecimal = 2;
				if ((double)num2 < 0.0001)
				{
					numAfterDecimal = 4;
				}
				string value = ACE.RSGlobal.RSGlobal.ToPercent(num2, numAfterDecimal);
				dataGridView_0[5, num4].Value = value;
				list_2[num4].prob = num2;
				num4--;
			}
			while (num4 >= 0);
		}
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			decimal value2 = ACE.RSGlobal.RSGlobal.ToDecimalSafe(num2 * 100f);
			numericUpDown_0.Value = value2;
			decimal num5 = 10m;
			decimal num6 = numericUpDown_0.Value * num5;
			trackBar_0.Value = (int)num6;
		}
		dontchange = false;
		method_0();
		method_9(bool_0: false);
		method_7();
	}

	private void trackBar_0_MouseDown(object sender, MouseEventArgs e)
	{
		decimal num = 0.99m;
		if (numericUpDown_0.Value < num)
		{
			method_7();
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!dontchange)
		{
			int index = (int_0 = comboBox_0.SelectedIndex);
			list_2 = (prob_SUITE_EXTENDED_0 = list_0[index]).ValuesList;
			method_11(checkBox_0.Checked);
			GC.KeepAlive(this);
		}
	}

	private void method_11([MarshalAs(UnmanagedType.U1)] bool bool_0)
	{
		if (ACE.RSGlobal.RSGlobal.antirecurse_SelectedSuiteChanged_ProbsEditor)
		{
			return;
		}
		ACE.RSGlobal.RSGlobal.antirecurse_SelectedSuiteChanged_ProbsEditor = true;
		try
		{
			if (bool_0)
			{
				method_10();
			}
			dontchange = true;
			dataGridView_0.Rows.Clear();
			dataGridViewImageColumn_0.Visible = false;
			Color fieldDefaultBack = TDark.FieldDefaultBack;
			numericUpDown_2.BackColor = fieldDefaultBack;
			if (prob_SUITE_EXTENDED_0.IsItemPresent)
			{
				Color fieldReferenceBack = TDark.FieldReferenceBack;
				numericUpDown_2.BackColor = fieldReferenceBack;
			}
			dataGridViewTextBoxColumn_0.Visible = prob_SUITE_EXTENDED_0.IsItemPresent;
			PROB_SUITE_EXTENDED pROB_SUITE_EXTENDED = prob_SUITE_EXTENDED_0;
			byte b = (byte)((pROB_SUITE_EXTENDED.IsItemPresent || pROB_SUITE_EXTENDED.IsFixedSize) ? 1u : 0u);
			dataGridViewTextBoxColumn_1.Visible = b != 0;
			byte b2 = ((!prob_SUITE_EXTENDED_0.IsFixedSize) ? ((byte)1) : ((byte)0));
			button_4.Enabled = b2 != 0;
			byte b3 = ((!prob_SUITE_EXTENDED_0.IsFixedSize) ? ((byte)1) : ((byte)0));
			button_5.Enabled = b3 != 0;
			byte b4 = ((!prob_SUITE_EXTENDED_0.IsFixedSize) ? ((byte)1) : ((byte)0));
			numericUpDown_2.Enabled = b4 != 0;
			byte b5 = ((!prob_SUITE_EXTENDED_0.IsFixedSize) ? ((byte)1) : ((byte)0));
			button_2.Enabled = b5 != 0;
			byte b6 = ((prob_SUITE_EXTENDED_0.FieldList[0].val1_f > 0) ? ((byte)1) : ((byte)0));
			dataGridViewTextBoxColumn_2.Visible = b6 != 0;
			byte b7 = ((prob_SUITE_EXTENDED_0.FieldList[0].val2_f > 0) ? ((byte)1) : ((byte)0));
			dataGridViewTextBoxColumn_3.Visible = b7 != 0;
			if (dataGridViewTextBoxColumn_2.Visible)
			{
				PROB_FIELDS pROB_FIELDS = prob_SUITE_EXTENDED_0.FieldList[0];
				int num = int_1;
				dataGridViewTextBoxColumn_2.HeaderText = eLC.GetOnlyFieldCaption(num, pROB_FIELDS.val1_f);
			}
			if (dataGridViewTextBoxColumn_3.Visible)
			{
				PROB_FIELDS pROB_FIELDS2 = prob_SUITE_EXTENDED_0.FieldList[0];
				int num2 = int_1;
				dataGridViewTextBoxColumn_3.HeaderText = eLC.GetOnlyFieldCaption(num2, pROB_FIELDS2.val2_f);
			}
			for (int i = 0; i < list_2.Count; i++)
			{
				method_12(list_2[i], i);
			}
			method_0();
			dontchange = false;
			method_9(bool_0: true);
			dataGridView_0_SelectionChanged(null, null);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648971586));
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.antirecurse_SelectedSuiteChanged_ProbsEditor = false;
		}
		GC.KeepAlive(this);
	}

	private void method_12(PROB_VALUES prob_VALUES_0, int int_2)
	{
		if (prob_VALUES_0 == null)
		{
			return;
		}
		string text = null;
		Image image = null;
		ITEMINFO iTEMINFO = null;
		PROB_SUITE_EXTENDED pROB_SUITE_EXTENDED = prob_SUITE_EXTENDED_0;
		if (pROB_SUITE_EXTENDED.IsItemPresent)
		{
			dataGridViewTextBoxColumn_1.Visible = true;
			int id = prob_VALUES_0.id;
			int[] availableLists = prob_SUITE_EXTENDED_0.AvailableLists;
			ITEMPOS itemPos = eLC.FindItemPos(availableLists, id);
			iTEMINFO = eLC.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
			if (iTEMINFO != null)
			{
				text = iTEMINFO.name;
				if (string.IsNullOrWhiteSpace(iTEMINFO.IconName))
				{
					int num = iTEMINFO.pos.int_0;
					if (!eLC.IsIconsExist(num))
					{
						image = ICONS.UnknownIcon;
						goto IL_0143;
					}
				}
				dataGridViewImageColumn_0.Visible = true;
				image = eLC.GetIcon(iTEMINFO, 32);
			}
			else
			{
				image = ICONS.NopeIcon;
				text = ((prob_VALUES_0.id == 0) ? TextStorage.TEXTS.GetText(Class16.smethod_0(1648971625)) : TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372)));
			}
		}
		else if (pROB_SUITE_EXTENDED.IsFixedSize)
		{
			PROB_FIELDS pROB_FIELDS = pROB_SUITE_EXTENDED.FieldList[int_2];
			string text2 = Class16.smethod_0(1648924402);
			int num2 = int_1;
			text = eLC.GetFieldName(num2, pROB_FIELDS.prob_f) + text2;
		}
		goto IL_0143;
		IL_0143:
		float prob = prob_VALUES_0.prob;
		int numAfterDecimal = 2;
		if ((double)prob < 0.0001)
		{
			numAfterDecimal = 4;
		}
		string text3 = ACE.RSGlobal.RSGlobal.ToPercent(prob, numAfterDecimal);
		object[] values = new object[8] { prob_VALUES_0.id, image, text, prob_VALUES_0.val1, prob_VALUES_0.val2, text3, null, false };
		dataGridView_0.Rows.Add(values);
		if (prob_SUITE_EXTENDED_0.IsItemPresent)
		{
			if (iTEMINFO != null)
			{
				int rowIndex = dataGridView_0.RowCount - 1;
				dataGridView_0[2, rowIndex].Style.ForeColor = iTEMINFO.color;
			}
			else
			{
				Color red = Color.Red;
				int rowIndex2 = dataGridView_0.RowCount - 1;
				dataGridView_0[2, rowIndex2].Style.ForeColor = red;
			}
		}
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			TextStorage.TEXTS.ShowMessage(913, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
			GC.KeepAlive(this);
			return;
		}
		int[] selectedElItems = CommonStorage.SelectedElItems;
		int num = 0;
		if (0 < (nint)selectedElItems.LongLength)
		{
			do
			{
				itempos_0.int_1 = selectedElItems[num];
				List<PROB_SUITE_EXTENDED>.Enumerator enumerator = list_0.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						PROB_SUITE_EXTENDED current = enumerator.Current;
						int num2 = 0;
						if (0 < current.FieldCount)
						{
							do
							{
								PROB_FIELDS pROB_FIELDS = current.FieldList[num2];
								PROB_VALUES pROB_VALUES = ((num2 >= current.ValuesList.Count) ? new PROB_VALUES() : current.ValuesList[num2]);
								ITEMPOS iTEMPOS = itempos_0;
								eLC.Lists[iTEMPOS.int_0].elementValues[iTEMPOS.int_1][pROB_FIELDS.prob_f] = pROB_VALUES.prob;
								int id_f = pROB_FIELDS.id_f;
								if (id_f > 0)
								{
									int id = pROB_VALUES.id;
									ITEMPOS iTEMPOS2 = itempos_0;
									int num3 = iTEMPOS2.int_1;
									int num4 = iTEMPOS2.int_0;
									eLC.SetValue(num4, num3, id_f, id.ToString(), AutoSaveStage: false);
								}
								int val1_f = pROB_FIELDS.val1_f;
								if (val1_f > 0)
								{
									string val = pROB_VALUES.val1;
									ITEMPOS iTEMPOS3 = itempos_0;
									int num5 = iTEMPOS3.int_1;
									int num6 = iTEMPOS3.int_0;
									eLC.SetValue(num6, num5, val1_f, val, AutoSaveStage: false);
								}
								int val2_f = pROB_FIELDS.val2_f;
								if (val2_f > 0)
								{
									string val2 = pROB_VALUES.val2;
									ITEMPOS iTEMPOS4 = itempos_0;
									int num7 = iTEMPOS4.int_1;
									int num8 = iTEMPOS4.int_0;
									eLC.SetValue(num8, num7, val2_f, val2, AutoSaveStage: false);
								}
								num2++;
							}
							while (num2 < current.FieldCount);
						}
						if (current.ProbCount == 0)
						{
							PROB_FIELDS pROB_FIELDS2 = current.FieldList[0];
							ITEMPOS iTEMPOS5 = itempos_0;
							eLC.Lists[iTEMPOS5.int_0].elementValues[iTEMPOS5.int_1][pROB_FIELDS2.prob_f] = 1f;
						}
					}
					while (enumerator.MoveNext());
				}
				ITEMPOS iTEMPOS6 = itempos_0;
				eLC.ItemChanged(iTEMPOS6.int_0, iTEMPOS6.int_1);
				num++;
			}
			while (num < (nint)selectedElItems.LongLength);
		}
		Close();
	}

	private void numericUpDown_2_DoubleClick(object sender, EventArgs e)
	{
		CStorage.ResetBuffer();
		decimal value = numericUpDown_2.Value;
		int[] availableLists = prob_SUITE_EXTENDED_0.AvailableLists;
		ITEMPOS iTEMPOS = eLC.FindItemPos(availableLists, (int)value);
		if (iTEMPOS != null)
		{
			ItemsWindow1.newitemlist = iTEMPOS.int_0;
			ItemsWindow1.newitemindex = iTEMPOS.int_1;
		}
		ItemsWindow1.newlistsindices = prob_SUITE_EXTENDED_0.AvailableLists;
		ItemsWindow1.ShowDialog();
		if (CommonStorage.sData != null && CommonStorage.sData != string.Empty)
		{
			numericUpDown_2.Text = CommonStorage.sData;
		}
		GC.KeepAlive(this);
	}
}
