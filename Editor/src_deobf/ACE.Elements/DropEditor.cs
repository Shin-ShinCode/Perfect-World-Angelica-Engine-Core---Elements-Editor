using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.License;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class DropEditor : Form
{
	private bool bool_0;

	private ItemsWindow itemsWindow_0;

	private float[] float_0;

	private ACE.Elements.eListCollection.eListCollection eListCollection_0;

	private CommonStorage commonStorage_0;

	private bool bool_1;

	private ITEMPOS itempos_0;

	private SettingsClass settingsClass_0;

	private List<PROB_VALUES> list_0 = new List<PROB_VALUES>(32);

	private TrackBar trackBar_0;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private Label label_0;

	private NumericUpDown numericUpDown_0;

	private CheckBox checkBox_0;

	private ToolTip toolTip_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewImageColumn dataGridViewImageColumn_1;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private Button button_3;

	private DataGridView dataGridView_0;

	private NumericUpDown numericUpDown_1;

	private TrackBar trackBar_1;

	private NumericUpDown numericUpDown_2;

	private Button button_4;

	private NumericUpDown numericUpDown_3;

	private TrackBar trackBar_2;

	private Label label_1;

	private CheckBox checkBox_1;

	private NumericUpDown numericUpDown_4;

	private TrackBar trackBar_3;

	private Label label_2;

	private CheckBox checkBox_2;

	private NumericUpDown numericUpDown_5;

	private TrackBar trackBar_4;

	private Label label_3;

	private CheckBox checkBox_3;

	private NumericUpDown numericUpDown_6;

	private TrackBar trackBar_5;

	private Label label_4;

	private CheckBox checkBox_4;

	private Label label_5;

	private Button button_5;

	private NumericUpDown numericUpDown_7;

	private IContainer icontainer_0;

	private const decimal decimal_0 = 100000m;

	public DropEditor(ITEMPOS _ItemPos, ACE.Elements.eListCollection.eListCollection ref_eLC, ItemsWindow ItemsWindow1, CommonStorage ref_CStorage)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_0, value: true);
			commonStorage_0 = ref_CStorage;
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			if (_ItemPos == null)
			{
				return;
			}
			if ((settingsClass_0 = CommonStorage.Profile).GetSetting(Class16.smethod_0(1648987494), Class16.smethod_0(1648926403), string.Empty) == Class16.smethod_0(1648926418))
			{
				checkBox_0.Checked = true;
			}
			bool_0 = false;
			itempos_0 = _ItemPos;
			eListCollection_0 = ref_eLC;
			itemsWindow_0 = ItemsWindow1;
			bool_1 = true;
			int int_ = _ItemPos.int_0;
			ACE.Elements.eList.eList eList2 = ref_eLC.Lists[int_];
			ITEMPOS iTEMPOS = itempos_0;
			int int_2 = iTEMPOS.int_1;
			int int_3 = iTEMPOS.int_0;
			float num = eListCollection_0.GetValueF(int_3, int_2, eList2.get_fields(Class16.smethod_0(1648987511))) * 100f;
			numericUpDown_6.Text = num.ToString();
			int int_4 = itempos_0.int_0;
			ACE.Elements.eList.eList eList3 = eListCollection_0.Lists[int_4];
			ITEMPOS iTEMPOS2 = itempos_0;
			int int_5 = iTEMPOS2.int_1;
			int int_6 = iTEMPOS2.int_0;
			float num2 = eListCollection_0.GetValueF(int_6, int_5, eList3.get_fields(Class16.smethod_0(1648987531))) * 100f;
			numericUpDown_5.Text = num2.ToString();
			int int_7 = itempos_0.int_0;
			ACE.Elements.eList.eList eList4 = eListCollection_0.Lists[int_7];
			ITEMPOS iTEMPOS3 = itempos_0;
			int int_8 = iTEMPOS3.int_1;
			int int_9 = iTEMPOS3.int_0;
			float num3 = eListCollection_0.GetValueF(int_9, int_8, eList4.get_fields(Class16.smethod_0(1648987567))) * 100f;
			numericUpDown_4.Text = num3.ToString();
			int int_10 = itempos_0.int_0;
			ACE.Elements.eList.eList eList5 = eListCollection_0.Lists[int_10];
			ITEMPOS iTEMPOS4 = itempos_0;
			int int_11 = iTEMPOS4.int_1;
			int int_12 = iTEMPOS4.int_0;
			float num4 = eListCollection_0.GetValueF(int_12, int_11, eList5.get_fields(Class16.smethod_0(1648987587))) * 100f;
			numericUpDown_3.Text = num4.ToString();
			decimal num5 = 100000m;
			decimal value = numericUpDown_6.Value * num5;
			trackBar_5.Value = Convert.ToInt32(value);
			decimal num6 = 100000m;
			decimal value2 = numericUpDown_5.Value * num6;
			trackBar_4.Value = Convert.ToInt32(value2);
			decimal num7 = 100000m;
			decimal value3 = numericUpDown_4.Value * num7;
			trackBar_3.Value = Convert.ToInt32(value3);
			decimal num8 = 100000m;
			decimal value4 = numericUpDown_3.Value * num8;
			trackBar_2.Value = Convert.ToInt32(value4);
			int int_13 = itempos_0.int_0;
			ACE.Elements.eList.eList eList6 = eListCollection_0.Lists[int_13];
			ITEMPOS iTEMPOS5 = itempos_0;
			int int_14 = iTEMPOS5.int_1;
			int int_15 = iTEMPOS5.int_0;
			int valueI = eListCollection_0.GetValueI(int_15, int_14, eList6.get_fields(Class16.smethod_0(1648987623)));
			numericUpDown_0.Text = valueI.ToString();
			int num9 = 1;
			do
			{
				ITEMPOS iTEMPOS6 = itempos_0;
				int int_16 = iTEMPOS6.int_1;
				int int_17 = iTEMPOS6.int_0;
				int valueI2 = eListCollection_0.GetValueI(int_17, int_16, string.Format(Class16.smethod_0(1648987632), num9));
				if (valueI2 != 0)
				{
					ITEMPOS iTEMPOS7 = itempos_0;
					int int_18 = iTEMPOS7.int_1;
					int int_19 = iTEMPOS7.int_0;
					float valueF = eListCollection_0.GetValueF(int_19, int_18, string.Format(Class16.smethod_0(1648986634), num9));
					list_0.Add(new PROB_VALUES(valueI2, valueF));
				}
				num9++;
			}
			while (num9 <= 32);
			method_19();
			bool_1 = false;
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void numericUpDown_6_ValueChanged(object sender, EventArgs e)
	{
		if (bool_1)
		{
			return;
		}
		NumericUpDown numericUpDown = (NumericUpDown)sender;
		int num = method_5(numericUpDown);
		if (num >= 0)
		{
			TrackBar trackBar = method_4(num);
			if (trackBar != null && (!bool_0 || trackBar != trackBar_0))
			{
				int val = (int)(numericUpDown.Value * 100000m);
				val = Math.Max(trackBar.Minimum, Math.Min(trackBar.Maximum, val));
				trackBar.Value = val;
				method_8();
			}
		}
	}

	private void trackBar_5_Scroll(object sender, EventArgs e)
	{
		trackBar_0 = (TrackBar)sender;
		bool_0 = true;
		method_7();
		bool_0 = false;
	}

	private void method_0()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(DropEditor));
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_1 = new DataGridViewImageColumn();
		dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		numericUpDown_1 = new NumericUpDown();
		trackBar_1 = new TrackBar();
		numericUpDown_2 = new NumericUpDown();
		button_4 = new Button();
		numericUpDown_3 = new NumericUpDown();
		trackBar_2 = new TrackBar();
		label_1 = new Label();
		checkBox_1 = new CheckBox();
		numericUpDown_4 = new NumericUpDown();
		trackBar_3 = new TrackBar();
		label_2 = new Label();
		checkBox_2 = new CheckBox();
		numericUpDown_5 = new NumericUpDown();
		trackBar_4 = new TrackBar();
		label_3 = new Label();
		checkBox_3 = new CheckBox();
		numericUpDown_6 = new NumericUpDown();
		trackBar_5 = new TrackBar();
		label_4 = new Label();
		checkBox_4 = new CheckBox();
		label_5 = new Label();
		button_5 = new Button();
		numericUpDown_7 = new NumericUpDown();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		label_0 = new Label();
		numericUpDown_0 = new NumericUpDown();
		checkBox_0 = new CheckBox();
		toolTip_0 = new ToolTip(icontainer_0);
		button_3 = new Button();
		((ISupportInitialize)dataGridView_0).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		((ISupportInitialize)trackBar_1).BeginInit();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		((ISupportInitialize)numericUpDown_3).BeginInit();
		((ISupportInitialize)trackBar_2).BeginInit();
		((ISupportInitialize)numericUpDown_4).BeginInit();
		((ISupportInitialize)trackBar_3).BeginInit();
		((ISupportInitialize)numericUpDown_5).BeginInit();
		((ISupportInitialize)trackBar_4).BeginInit();
		((ISupportInitialize)numericUpDown_6).BeginInit();
		((ISupportInitialize)trackBar_5).BeginInit();
		((ISupportInitialize)numericUpDown_7).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
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
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewImageColumn_0, dataGridViewTextBoxColumn_1, dataGridViewTextBoxColumn_2, dataGridViewImageColumn_1, dataGridViewCheckBoxColumn_0);
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(32, 32, 32);
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = Color.White;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = Color.White;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.GridColor = Color.Silver;
		dataGridView_0.Location = new Point(5, 144);
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1648986677);
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
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648929920), 9f);
		dataGridView_0.RowsDefaultCellStyle = dataGridViewCellStyle3;
		dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648929920), 12f);
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellToolTips = true;
		dataGridView_0.Size = new Size(767, 465);
		dataGridView_0.TabIndex = 25;
		dataGridView_0.CellToolTipTextNeeded += dataGridView_0_CellToolTipTextNeeded;
		dataGridView_0.KeyDown += dataGridView_0_KeyDown;
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
		dataGridViewImageColumn_0.HeaderText = string.Empty;
		dataGridViewImageColumn_0.MinimumWidth = 32;
		dataGridViewImageColumn_0.Name = Class16.smethod_0(1648986695);
		dataGridViewImageColumn_0.ReadOnly = true;
		dataGridViewImageColumn_0.Resizable = DataGridViewTriState.False;
		dataGridViewImageColumn_0.Width = 32;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648986709);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648986725);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_1.Width = 300;
		dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle5;
		dataGridViewTextBoxColumn_2.FillWeight = 90f;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648941080);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648986743);
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.Programmatic;
		dataGridViewTextBoxColumn_2.Width = 90;
		dataGridViewImageColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewImageColumn_1.HeaderText = string.Empty;
		dataGridViewImageColumn_1.Name = Class16.smethod_0(1648926525);
		dataGridViewImageColumn_1.ReadOnly = true;
		dataGridViewImageColumn_1.SortMode = DataGridViewColumnSortMode.Programmatic;
		dataGridViewCheckBoxColumn_0.HeaderText = Class16.smethod_0(1648926548);
		dataGridViewCheckBoxColumn_0.Name = Class16.smethod_0(1648986757);
		dataGridViewCheckBoxColumn_0.ReadOnly = true;
		numericUpDown_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		numericUpDown_1.DecimalPlaces = 4;
		numericUpDown_1.Location = new Point(80, 616);
		numericUpDown_1.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_1.Name = Class16.smethod_0(1648926574);
		numericUpDown_1.Size = new Size(89, 22);
		numericUpDown_1.TabIndex = 42;
		numericUpDown_1.TextAlign = HorizontalAlignment.Center;
		numericUpDown_1.ValueChanged += numericUpDown_1_ValueChanged;
		trackBar_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		trackBar_1.LargeChange = 50;
		trackBar_1.Location = new Point(175, 616);
		trackBar_1.Margin = new Padding(3, 4, 3, 4);
		trackBar_1.Maximum = 1000;
		trackBar_1.Name = Class16.smethod_0(1648926599);
		trackBar_1.Size = new Size(530, 45);
		trackBar_1.SmallChange = 10;
		trackBar_1.TabIndex = 41;
		trackBar_1.TickFrequency = 10;
		trackBar_1.TickStyle = TickStyle.None;
		trackBar_1.Scroll += trackBar_1_Scroll;
		trackBar_1.MouseDown += trackBar_1_MouseDown;
		trackBar_1.MouseUp += trackBar_1_MouseUp;
		numericUpDown_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		numericUpDown_2.BackColor = Color.FromArgb(225, 255, 225);
		numericUpDown_2.Increment = new decimal(new int[4]);
		numericUpDown_2.Location = new Point(5, 616);
		numericUpDown_2.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_2.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_2.Name = Class16.smethod_0(1648926630);
		numericUpDown_2.Size = new Size(69, 22);
		numericUpDown_2.TabIndex = 44;
		numericUpDown_2.TextAlign = HorizontalAlignment.Center;
		numericUpDown_2.ValueChanged += numericUpDown_2_ValueChanged;
		numericUpDown_2.DoubleClick += numericUpDown_2_DoubleClick;
		button_4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_4.Image = Resources.DropEditor_cmdAdd;
		button_4.ImageAlign = ContentAlignment.MiddleRight;
		button_4.Location = new Point(358, 111);
		button_4.Name = Class16.smethod_0(1648926646);
		button_4.Size = new Size(131, 27);
		button_4.TabIndex = 64;
		button_4.Text = Class16.smethod_0(1648931361);
		button_4.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		numericUpDown_3.DecimalPlaces = 4;
		numericUpDown_3.Location = new Point(185, 85);
		numericUpDown_3.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_3.Name = Class16.smethod_0(1648986774);
		numericUpDown_3.Size = new Size(77, 22);
		numericUpDown_3.TabIndex = 61;
		numericUpDown_3.TextAlign = HorizontalAlignment.Center;
		numericUpDown_3.ValueChanged += numericUpDown_6_ValueChanged;
		numericUpDown_3.Leave += numericUpDown_6_Leave;
		trackBar_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		trackBar_2.LargeChange = 1000000;
		trackBar_2.Location = new Point(259, 86);
		trackBar_2.Margin = new Padding(3, 4, 3, 4);
		trackBar_2.Maximum = 10000000;
		trackBar_2.Name = Class16.smethod_0(1648986785);
		trackBar_2.Size = new Size(384, 45);
		trackBar_2.TabIndex = 60;
		trackBar_2.TickFrequency = 1000000;
		trackBar_2.TickStyle = TickStyle.None;
		trackBar_2.Scroll += trackBar_5_Scroll;
		label_1.AutoSize = true;
		label_1.Location = new Point(13, 86);
		label_1.Name = Class16.smethod_0(1648912200);
		label_1.Size = new Size(118, 13);
		label_1.TabIndex = 59;
		label_1.Text = Class16.smethod_0(1648986810);
		checkBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		checkBox_1.AutoSize = true;
		checkBox_1.Location = new Point(722, 88);
		checkBox_1.Margin = new Padding(3, 4, 3, 4);
		checkBox_1.Name = Class16.smethod_0(1648986840);
		checkBox_1.Size = new Size(40, 17);
		checkBox_1.TabIndex = 58;
		checkBox_1.Text = Class16.smethod_0(1648926548);
		checkBox_1.UseVisualStyleBackColor = true;
		numericUpDown_4.DecimalPlaces = 4;
		numericUpDown_4.Location = new Point(185, 61);
		numericUpDown_4.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_4.Name = Class16.smethod_0(1648986851);
		numericUpDown_4.Size = new Size(77, 22);
		numericUpDown_4.TabIndex = 57;
		numericUpDown_4.TextAlign = HorizontalAlignment.Center;
		numericUpDown_4.ValueChanged += numericUpDown_6_ValueChanged;
		numericUpDown_4.Leave += numericUpDown_6_Leave;
		trackBar_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		trackBar_3.LargeChange = 1000000;
		trackBar_3.Location = new Point(259, 62);
		trackBar_3.Margin = new Padding(3, 4, 3, 4);
		trackBar_3.Maximum = 10000000;
		trackBar_3.Name = Class16.smethod_0(1648986878);
		trackBar_3.Size = new Size(384, 45);
		trackBar_3.TabIndex = 56;
		trackBar_3.TickFrequency = 1000000;
		trackBar_3.TickStyle = TickStyle.None;
		trackBar_3.Scroll += trackBar_5_Scroll;
		label_2.AutoSize = true;
		label_2.Location = new Point(13, 62);
		label_2.Name = Class16.smethod_0(1648912145);
		label_2.Size = new Size(118, 13);
		label_2.TabIndex = 55;
		label_2.Text = Class16.smethod_0(1648986903);
		checkBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		checkBox_2.AutoSize = true;
		checkBox_2.Location = new Point(722, 64);
		checkBox_2.Margin = new Padding(3, 4, 3, 4);
		checkBox_2.Name = Class16.smethod_0(1648986933);
		checkBox_2.Size = new Size(40, 17);
		checkBox_2.TabIndex = 54;
		checkBox_2.Text = Class16.smethod_0(1648926548);
		checkBox_2.UseVisualStyleBackColor = true;
		numericUpDown_5.DecimalPlaces = 4;
		numericUpDown_5.Location = new Point(185, 37);
		numericUpDown_5.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_5.Name = Class16.smethod_0(1648986936);
		numericUpDown_5.Size = new Size(77, 22);
		numericUpDown_5.TabIndex = 53;
		numericUpDown_5.TextAlign = HorizontalAlignment.Center;
		numericUpDown_5.ValueChanged += numericUpDown_6_ValueChanged;
		numericUpDown_5.Leave += numericUpDown_6_Leave;
		trackBar_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		trackBar_4.LargeChange = 1000000;
		trackBar_4.Location = new Point(259, 38);
		trackBar_4.Margin = new Padding(3, 4, 3, 4);
		trackBar_4.Maximum = 10000000;
		trackBar_4.Name = Class16.smethod_0(1648986955);
		trackBar_4.Size = new Size(384, 45);
		trackBar_4.TabIndex = 52;
		trackBar_4.TickFrequency = 1000000;
		trackBar_4.TickStyle = TickStyle.None;
		trackBar_4.Scroll += trackBar_5_Scroll;
		label_3.AutoSize = true;
		label_3.Location = new Point(13, 38);
		label_3.Name = Class16.smethod_0(1648912083);
		label_3.Size = new Size(113, 13);
		label_3.TabIndex = 51;
		label_3.Text = Class16.smethod_0(1648986988);
		checkBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		checkBox_3.AutoSize = true;
		checkBox_3.Location = new Point(653, 40);
		checkBox_3.Margin = new Padding(3, 4, 3, 4);
		checkBox_3.Name = Class16.smethod_0(1648987009);
		checkBox_3.Size = new Size(109, 17);
		checkBox_3.TabIndex = 50;
		checkBox_3.Text = Class16.smethod_0(1648926548);
		checkBox_3.UseVisualStyleBackColor = true;
		numericUpDown_6.DecimalPlaces = 4;
		numericUpDown_6.Location = new Point(185, 13);
		numericUpDown_6.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_6.Name = Class16.smethod_0(1648987028);
		numericUpDown_6.Size = new Size(77, 22);
		numericUpDown_6.TabIndex = 49;
		numericUpDown_6.TextAlign = HorizontalAlignment.Center;
		numericUpDown_6.ValueChanged += numericUpDown_6_ValueChanged;
		numericUpDown_6.Leave += numericUpDown_6_Leave;
		trackBar_5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		trackBar_5.LargeChange = 1000000;
		trackBar_5.Location = new Point(259, 14);
		trackBar_5.Margin = new Padding(3, 4, 3, 4);
		trackBar_5.Maximum = 10000000;
		trackBar_5.Name = Class16.smethod_0(1648987047);
		trackBar_5.Size = new Size(384, 45);
		trackBar_5.TabIndex = 48;
		trackBar_5.TickFrequency = 1000000;
		trackBar_5.TickStyle = TickStyle.None;
		trackBar_5.Scroll += trackBar_5_Scroll;
		label_4.AutoSize = true;
		label_4.Location = new Point(13, 14);
		label_4.Name = Class16.smethod_0(1648919238);
		label_4.Size = new Size(118, 13);
		label_4.TabIndex = 47;
		label_4.Text = Class16.smethod_0(1648987064);
		checkBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(722, 16);
		checkBox_4.Margin = new Padding(3, 4, 3, 4);
		checkBox_4.Name = Class16.smethod_0(1648987102);
		checkBox_4.Size = new Size(40, 17);
		checkBox_4.TabIndex = 46;
		checkBox_4.Text = Class16.smethod_0(1648926548);
		checkBox_4.UseVisualStyleBackColor = true;
		label_5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		label_5.BackColor = Color.FromArgb(32, 32, 32);
		label_5.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_5.ForeColor = Color.White;
		label_5.Location = new Point(660, 579);
		label_5.Name = Class16.smethod_0(1648926651);
		label_5.Size = new Size(90, 30);
		label_5.TabIndex = 63;
		label_5.Text = Class16.smethod_0(1648987105);
		label_5.TextAlign = ContentAlignment.MiddleCenter;
		label_5.Visible = false;
		button_5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_5.Image = Resources.DropEditor_cmdDel;
		button_5.ImageAlign = ContentAlignment.MiddleRight;
		button_5.Location = new Point(490, 111);
		button_5.Name = Class16.smethod_0(1648925697);
		button_5.Size = new Size(131, 27);
		button_5.TabIndex = 65;
		button_5.Text = Class16.smethod_0(1648925718);
		button_5.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		numericUpDown_7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		numericUpDown_7.BackColor = Color.FromArgb(225, 255, 225);
		numericUpDown_7.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_7.Location = new Point(268, 113);
		numericUpDown_7.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_7.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_7.Name = Class16.smethod_0(1648987122);
		numericUpDown_7.Size = new Size(87, 25);
		numericUpDown_7.TabIndex = 66;
		numericUpDown_7.TextAlign = HorizontalAlignment.Center;
		numericUpDown_7.ValueChanged += numericUpDown_7_ValueChanged;
		numericUpDown_7.DoubleClick += numericUpDown_7_DoubleClick;
		numericUpDown_7.MouseCaptureChanged += numericUpDown_7_MouseCaptureChanged;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_0.DialogResult = DialogResult.OK;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.DropEditor_cmdok;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(5, 643);
		button_0.Name = Class16.smethod_0(1648925748);
		button_0.Size = new Size(390, 26);
		button_0.TabIndex = 67;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648941761);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.Cancel;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.DropEditor_cmdcancel;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(401, 643);
		button_1.Name = Class16.smethod_0(1648925752);
		button_1.Size = new Size(371, 26);
		button_1.TabIndex = 68;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_2.Image = Resources.DropEditor_cmdSort;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(634, 111);
		button_2.Name = Class16.smethod_0(1648925768);
		button_2.Size = new Size(116, 27);
		button_2.TabIndex = 69;
		button_2.Text = Class16.smethod_0(1648925790);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.Location = new Point(13, 113);
		label_0.Name = Class16.smethod_0(1648912262);
		label_0.Size = new Size(82, 19);
		label_0.TabIndex = 70;
		label_0.Text = Class16.smethod_0(1648986114);
		numericUpDown_0.BackColor = Color.White;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_0.Location = new Point(185, 112);
		numericUpDown_0.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_0.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648986141);
		numericUpDown_0.Size = new Size(77, 25);
		numericUpDown_0.TabIndex = 71;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		checkBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(755, 119);
		checkBox_0.Margin = new Padding(3, 4, 3, 4);
		checkBox_0.Name = Class16.smethod_0(1648925793);
		checkBox_0.Size = new Size(15, 14);
		checkBox_0.TabIndex = 72;
		toolTip_0.SetToolTip(checkBox_0, Class16.smethod_0(1648986158));
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		checkBox_0.Click += checkBox_0_Click;
		button_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(711, 612);
		button_3.Name = Class16.smethod_0(1648920454);
		button_3.Size = new Size(61, 27);
		button_3.TabIndex = 73;
		button_3.Text = Class16.smethod_0(1648920478);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_1;
		base.ClientSize = new Size(777, 673);
		base.Controls.Add(button_3);
		base.Controls.Add(label_5);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(label_0);
		base.Controls.Add(button_2);
		base.Controls.Add(button_0);
		base.Controls.Add(button_1);
		base.Controls.Add(numericUpDown_7);
		base.Controls.Add(button_5);
		base.Controls.Add(button_4);
		base.Controls.Add(numericUpDown_3);
		base.Controls.Add(trackBar_2);
		base.Controls.Add(label_1);
		base.Controls.Add(numericUpDown_4);
		base.Controls.Add(trackBar_3);
		base.Controls.Add(label_2);
		base.Controls.Add(checkBox_2);
		base.Controls.Add(checkBox_3);
		base.Controls.Add(numericUpDown_5);
		base.Controls.Add(trackBar_4);
		base.Controls.Add(label_3);
		base.Controls.Add(checkBox_1);
		base.Controls.Add(numericUpDown_6);
		base.Controls.Add(trackBar_5);
		base.Controls.Add(label_4);
		base.Controls.Add(checkBox_4);
		base.Controls.Add(numericUpDown_2);
		base.Controls.Add(numericUpDown_1);
		base.Controls.Add(trackBar_1);
		base.Controls.Add(dataGridView_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.Icon = Resources.DropEditor_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MinimizeBox = false;
		MinimumSize = new Size(750, 500);
		base.Name = Class16.smethod_0(1648987494);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648986182);
		toolTip_0.SetToolTip(this, Class16.smethod_0(1648920548));
		base.FormClosed += DropEditor_FormClosed;
		base.Load += DropEditor_Load;
		base.Shown += DropEditor_Shown;
		base.Resize += DropEditor_Resize;
		((ISupportInitialize)dataGridView_0).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		((ISupportInitialize)trackBar_1).EndInit();
		((ISupportInitialize)numericUpDown_2).EndInit();
		((ISupportInitialize)numericUpDown_3).EndInit();
		((ISupportInitialize)trackBar_2).EndInit();
		((ISupportInitialize)numericUpDown_4).EndInit();
		((ISupportInitialize)trackBar_3).EndInit();
		((ISupportInitialize)numericUpDown_5).EndInit();
		((ISupportInitialize)trackBar_4).EndInit();
		((ISupportInitialize)numericUpDown_6).EndInit();
		((ISupportInitialize)trackBar_5).EndInit();
		((ISupportInitialize)numericUpDown_7).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
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
				method_0();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private NumericUpDown method_2(int int_0)
	{
		return int_0 switch
		{
			0 => numericUpDown_6, 
			1 => numericUpDown_5, 
			2 => numericUpDown_4, 
			3 => numericUpDown_3, 
			_ => null, 
		};
	}

	private CheckBox method_3(int int_0)
	{
		return int_0 switch
		{
			0 => checkBox_4, 
			1 => checkBox_3, 
			2 => checkBox_2, 
			3 => checkBox_1, 
			_ => null, 
		};
	}

	private TrackBar method_4(int int_0)
	{
		return int_0 switch
		{
			0 => trackBar_5, 
			1 => trackBar_4, 
			2 => trackBar_3, 
			3 => trackBar_2, 
			_ => null, 
		};
	}

	private int method_5(NumericUpDown numericUpDown_8)
	{
		if (numericUpDown_8 == numericUpDown_6)
		{
			return 0;
		}
		if (numericUpDown_8 == numericUpDown_5)
		{
			return 1;
		}
		if (numericUpDown_8 == numericUpDown_4)
		{
			return 2;
		}
		if (numericUpDown_8 == numericUpDown_3)
		{
			return 3;
		}
		return -1;
	}

	private int method_6(TrackBar trackBar_6)
	{
		if (trackBar_6 == trackBar_5)
		{
			return 0;
		}
		if (trackBar_6 == trackBar_4)
		{
			return 1;
		}
		if (trackBar_6 == trackBar_3)
		{
			return 2;
		}
		if (trackBar_6 == trackBar_2)
		{
			return 3;
		}
		return -1;
	}

	private void method_7()
	{
		TrackBar trackBar = trackBar_0;
		if (trackBar == null)
		{
			return;
		}
		int num = method_6(trackBar);
		if (num < 0)
		{
			return;
		}
		NumericUpDown numericUpDown = method_2(num);
		if (numericUpDown == null)
		{
			return;
		}
		decimal num2 = (decimal)trackBar.Value / 10000000m;
		decimal num3 = 1m - num2;
		decimal num4 = default(decimal);
		int num5 = 0;
		for (int i = 0; i < 4; i++)
		{
			NumericUpDown numericUpDown2 = method_2(i);
			CheckBox checkBox = method_3(i);
			if (numericUpDown2 != null && checkBox != null && numericUpDown2 != numericUpDown)
			{
				if (checkBox.Checked)
				{
					num3 -= numericUpDown2.Value / 100m;
					num5++;
				}
				else
				{
					num4 += numericUpDown2.Value / 100m;
				}
			}
		}
		if (!(num3 < 0m) && (!(num4 == 0m) || num5 < 3))
		{
			numericUpDown.Value = num2 * 100m;
		}
		else
		{
			int val = (int)(numericUpDown.Value * 100000m);
			val = Math.Max(trackBar.Minimum, Math.Min(trackBar.Maximum, val));
			trackBar.Value = val;
		}
		for (int j = 0; j < 4; j++)
		{
			NumericUpDown numericUpDown3 = method_2(j);
			CheckBox checkBox2 = method_3(j);
			if (numericUpDown3 != null && checkBox2 != null && numericUpDown3 != numericUpDown && !checkBox2.Checked)
			{
				decimal num6 = ((!(num4 > 0m)) ? 0.25m : (numericUpDown3.Value / 100m / num4));
				if (num3 <= 0m)
				{
					num6 = default(decimal);
				}
				decimal value = num3 * num6 * 100m;
				numericUpDown3.Value = value;
			}
		}
		decimal num7 = default(decimal);
		for (int k = 0; k < 4; k++)
		{
			NumericUpDown numericUpDown4 = method_2(k);
			if (numericUpDown4 != null)
			{
				num7 += numericUpDown4.Value / 100m;
			}
		}
		if (num7 < 1m)
		{
			decimal num8 = (1m - num7) * 100m;
			numericUpDown.Value += num8;
		}
		method_8();
	}

	private void DropEditor_Shown(object sender, EventArgs e)
	{
		method_18(bool_2: true);
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			TextStorage.TEXTS.ShowMessage(913, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
			GC.KeepAlive(this);
			return;
		}
		if (checkBox_0.Checked)
		{
			method_15();
		}
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars2 = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			TextStorage.TEXTS.ShowMessage(913, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars2);
			Close();
		}
	}

	private void method_8()
	{
		if (numericUpDown_6 == null || numericUpDown_5 == null || numericUpDown_4 == null || numericUpDown_3 == null)
		{
			return;
		}
		decimal num = 100m;
		decimal num2 = numericUpDown_3.Value / num;
		decimal num3 = 100m;
		decimal num4 = numericUpDown_4.Value / num3;
		decimal num5 = 100m;
		decimal num6 = numericUpDown_5.Value / num5;
		decimal num7 = 100m;
		decimal num8 = numericUpDown_6.Value / num7 + num6 + num4 + num2;
		float num9 = 0f;
		int num10 = 0;
		if (0 < list_0.Count)
		{
			do
			{
				num9 = (float)((double)list_0[num10].prob + (double)num9);
				num10++;
			}
			while (num10 < list_0.Count);
		}
		if (Math.Round((double)num8, 6) == 1.0 && Math.Round(num9, 6) == 1.0)
		{
			label_5.Visible = false;
		}
		else
		{
			int numAfterDecimal = 2;
			if ((double)num9 < 0.0001)
			{
				numAfterDecimal = 4;
			}
			string text = ACE.RSGlobal.RSGlobal.ToPercent(num9, numAfterDecimal);
			float num11 = (float)num8;
			int numAfterDecimal2 = 2;
			if ((double)num11 < 0.0001)
			{
				numAfterDecimal2 = 4;
			}
			string text2 = ACE.RSGlobal.RSGlobal.ToPercent(num11, numAfterDecimal2);
			label_5.Text = string.Concat(text2 + Class16.smethod_0(1648986192), text);
			Color red = Color.Red;
			label_5.ForeColor = red;
			label_5.Visible = true;
		}
		GC.KeepAlive(this);
	}

	private void numericUpDown_6_Leave(object sender, EventArgs e)
	{
		method_8();
		method_18(bool_2: false);
	}

	private void dataGridView_0_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete)
		{
			e.Handled = true;
			button_5_Click(sender, e);
		}
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		if (dataGridView_0.SelectedRows.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		int index = dataGridView_0.SelectedRows[0].Index;
		if (list_0.Count > 1 && list_0[index].prob > 0f)
		{
			bool flag = checkBox_0.Checked;
			checkBox_0.Checked = false;
			method_12(default(decimal));
			method_16();
			checkBox_0.Checked = flag;
		}
		list_0.RemoveAt(index);
		DataGridView dataGridView = dataGridView_0;
		dataGridView_0.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
		method_8();
		method_18(bool_2: true);
		method_17();
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		if (list_0.Count >= 32)
		{
			TextStorage.TEXTS.ShowMessage(425, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			GC.KeepAlive(this);
			return;
		}
		string text = numericUpDown_7.Value.ToString();
		if (text == Class16.smethod_0(1648924112))
		{
			numericUpDown_7_DoubleClick(null, null);
			text = numericUpDown_7.Value.ToString();
			if (CommonStorage.sData == null)
			{
				GC.KeepAlive(this);
				return;
			}
		}
		string[] array = ((CommonStorage.sarr1 != null && CommonStorage.sarr1.Length > 1) ? CommonStorage.sarr1 : new string[1] { text });
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			if (list_0.Count >= 32)
			{
				break;
			}
			if (!string.IsNullOrWhiteSpace(text2) && !(text2 == Class16.smethod_0(1648924112)))
			{
				method_9(text2);
			}
		}
		method_18(bool_2: true);
		method_17();
	}

	private void method_9(string string_0)
	{
		string iconName = null;
		ACE.Elements.eListCollection.eListCollection eListCollection2 = eListCollection_0;
		ITEMPOS itemPos = eListCollection2.FindMatter(string_0);
		ITEMINFO itemInfo = eListCollection2.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		string name;
		if (itemInfo != null)
		{
			name = itemInfo.name;
			iconName = itemInfo.IconName;
		}
		else
		{
			name = TextStorage.TEXTS.GetText(Class16.smethod_0(1648902988));
		}
		if (int.TryParse(string_0, out var result))
		{
			list_0.Add(new PROB_VALUES(result, 0f));
			if (list_0.Count == 1)
			{
				list_0[0].prob = 1f;
			}
			int index = list_0.Count - 1;
			float prob = list_0[index].prob;
			int numAfterDecimal = 2;
			if ((double)prob < 0.0001)
			{
				numAfterDecimal = 4;
			}
			string text = ACE.RSGlobal.RSGlobal.ToPercent(prob, numAfterDecimal);
			object[] values = new object[6]
			{
				string_0,
				eListCollection_0.Icons.GetIcon(iconName, IsTga: false, 32),
				name,
				text,
				null,
				false
			};
			dataGridView_0.Rows.Add(values);
			if (itemInfo != null)
			{
				int rowIndex = dataGridView_0.RowCount - 1;
				dataGridView_0[2, rowIndex].Style.ForeColor = itemInfo.color;
			}
			else
			{
				Color red = Color.Red;
				int rowIndex2 = dataGridView_0.RowCount - 1;
				dataGridView_0[2, rowIndex2].Style.ForeColor = red;
			}
			int rowIndex3 = dataGridView_0.RowCount - 1;
			dataGridView_0[4, rowIndex3].Tag = 0f;
			int index2 = dataGridView_0.RowCount - 1;
			dataGridView_0.Rows[index2].Selected = true;
			int rowIndex4 = dataGridView_0.RowCount - 1;
			dataGridView_0.CurrentCell = dataGridView_0[2, rowIndex4];
		}
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
				decimal num2 = 100m;
				decimal num3 = numericUpDown_6.Value / num2;
				ACE.Elements.eList.eList eList2 = eListCollection_0.Lists[itempos_0.int_0];
				ITEMPOS iTEMPOS = itempos_0;
				ref object reference = ref eListCollection_0.Lists[iTEMPOS.int_0].elementValues[iTEMPOS.int_1][eList2.get_fields(Class16.smethod_0(1648987511))];
				reference = (float)num3;
				decimal num4 = 100m;
				decimal num5 = numericUpDown_5.Value / num4;
				ACE.Elements.eList.eList eList3 = eListCollection_0.Lists[itempos_0.int_0];
				ITEMPOS iTEMPOS2 = itempos_0;
				ref object reference2 = ref eListCollection_0.Lists[iTEMPOS2.int_0].elementValues[iTEMPOS2.int_1][eList3.get_fields(Class16.smethod_0(1648987531))];
				reference2 = (float)num5;
				decimal num6 = 100m;
				decimal num7 = numericUpDown_4.Value / num6;
				ACE.Elements.eList.eList eList4 = eListCollection_0.Lists[itempos_0.int_0];
				ITEMPOS iTEMPOS3 = itempos_0;
				ref object reference3 = ref eListCollection_0.Lists[iTEMPOS3.int_0].elementValues[iTEMPOS3.int_1][eList4.get_fields(Class16.smethod_0(1648987567))];
				reference3 = (float)num7;
				decimal num8 = 100m;
				decimal num9 = numericUpDown_3.Value / num8;
				ACE.Elements.eList.eList eList5 = eListCollection_0.Lists[itempos_0.int_0];
				ITEMPOS iTEMPOS4 = itempos_0;
				ref object reference4 = ref eListCollection_0.Lists[iTEMPOS4.int_0].elementValues[iTEMPOS4.int_1][eList5.get_fields(Class16.smethod_0(1648987587))];
				reference4 = (float)num9;
				decimal value = numericUpDown_0.Value;
				ACE.Elements.eList.eList eList6 = eListCollection_0.Lists[itempos_0.int_0];
				ITEMPOS iTEMPOS5 = itempos_0;
				ref object reference5 = ref eListCollection_0.Lists[iTEMPOS5.int_0].elementValues[iTEMPOS5.int_1][eList6.get_fields(Class16.smethod_0(1648987623))];
				reference5 = (int)value;
				int num10 = 0;
				do
				{
					object obj;
					if (num10 < dataGridView_0.RowCount)
					{
						object value2 = dataGridView_0[0, num10].Value;
						if (value2 == null)
						{
							obj = null;
						}
						else
						{
							obj = value2.ToString();
							if (obj != null)
							{
								goto IL_008d;
							}
						}
						obj = Class16.smethod_0(1648924112);
						goto IL_008d;
					}
					string text = Class16.smethod_0(1648924112);
					float num11 = 0f;
					goto IL_00b4;
					IL_008d:
					text = (string)obj;
					if (!ACE.RSGlobal.RSGlobal.IsUIntFast(text))
					{
						text = Class16.smethod_0(1648924112);
					}
					num11 = list_0[num10].prob;
					goto IL_00b4;
					IL_00b4:
					int num12 = num10 + 1;
					ACE.Elements.eList.eList eList7 = eListCollection_0.Lists[itempos_0.int_0];
					string text2 = Class16.smethod_0(1648986201);
					ITEMPOS iTEMPOS6 = itempos_0;
					ref object reference6 = ref eListCollection_0.Lists[iTEMPOS6.int_0].elementValues[iTEMPOS6.int_1][eList7.get_fields(string.Concat(Class16.smethod_0(1648986211) + num12, text2))];
					reference6 = ACE.RSGlobal.RSGlobal.UIntParseFast(text);
					int num13 = num10 + 1;
					ACE.Elements.eList.eList eList8 = eListCollection_0.Lists[itempos_0.int_0];
					string text3 = Class16.smethod_0(1648986239);
					ITEMPOS iTEMPOS7 = itempos_0;
					eListCollection_0.Lists[iTEMPOS7.int_0].elementValues[iTEMPOS7.int_1][eList8.get_fields(string.Concat(Class16.smethod_0(1648986211) + num13, text3))] = num11;
					num10++;
				}
				while (num10 < 32);
				if (dataGridView_0.RowCount == 0)
				{
					ACE.Elements.eList.eList eList9 = eListCollection_0.Lists[itempos_0.int_0];
					ITEMPOS iTEMPOS8 = itempos_0;
					eListCollection_0.Lists[iTEMPOS8.int_0].elementValues[iTEMPOS8.int_1][eList9.get_fields(Class16.smethod_0(1648986250))] = 1f;
				}
				ITEMPOS iTEMPOS9 = itempos_0;
				eListCollection_0.ItemChanged(iTEMPOS9.int_0, iTEMPOS9.int_1);
				num++;
			}
			while (num < (nint)selectedElItems.LongLength);
		}
		Close();
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		object obj;
		object obj2;
		if (!bool_1 && e.RowIndex >= 0)
		{
			bool_1 = true;
			if (e.ColumnIndex == 0)
			{
				object value = dataGridView_0[0, e.RowIndex].Value;
				if (value == null)
				{
					obj = null;
				}
				else
				{
					obj = value.ToString();
					if (obj != null)
					{
						goto IL_005a;
					}
				}
				obj = Class16.smethod_0(1648924112);
				goto IL_005a;
			}
			if (e.ColumnIndex == 3)
			{
				object value2 = dataGridView_0[3, e.RowIndex].Value;
				if (value2 == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = value2.ToString();
					if (obj2 != null)
					{
						goto IL_025c;
					}
				}
				obj2 = Class16.smethod_0(1648924112);
				goto IL_025c;
			}
			goto IL_03c9;
		}
		GC.KeepAlive(this);
		return;
		IL_005a:
		string text = (string)obj;
		if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
		{
			ACE.Elements.eListCollection.eListCollection eListCollection2 = eListCollection_0;
			ITEMPOS itemPos = eListCollection2.FindMatter(text);
			ITEMINFO itemInfo = eListCollection2.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
			if (itemInfo != null)
			{
				string name = itemInfo.name;
				dataGridView_0[2, e.RowIndex].Value = name;
				dataGridView_0[2, e.RowIndex].Style.ForeColor = itemInfo.color;
				string iconName = itemInfo.IconName;
				ICONS icons = eListCollection_0.Icons;
				dataGridView_0[1, e.RowIndex].Value = icons.GetIcon(iconName, IsTga: false, 32);
			}
			else
			{
				string value3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648902988));
				dataGridView_0[2, e.RowIndex].Value = value3;
				Color red = Color.Red;
				dataGridView_0[2, e.RowIndex].Style.ForeColor = red;
				dataGridView_0[1, e.RowIndex].Value = ICONS.NopeIcon;
			}
			numericUpDown_2.Text = text;
			ref int id = ref list_0[e.RowIndex].id;
			id = ACE.RSGlobal.RSGlobal.UIntParseFast(text);
		}
		else
		{
			string value4 = Class16.smethod_0(1648924112);
			dataGridView_0[0, e.RowIndex].Value = value4;
			numericUpDown_2.Text = Class16.smethod_0(1648924112);
			string empty = string.Empty;
			dataGridView_0[2, e.RowIndex].Value = empty;
			list_0[e.RowIndex].id = 0;
		}
		goto IL_03c9;
		IL_03c9:
		bool_1 = false;
		return;
		IL_025c:
		string text2 = (string)obj2;
		if (text2.Contains(Class16.smethod_0(1648923229)))
		{
			text2 = text2.Substring(0, text2.Length - 1);
		}
		else
		{
			DataGridViewCell dataGridViewCell = dataGridView_0[3, e.RowIndex];
			string text3 = Class16.smethod_0(1648923229);
			dataGridViewCell.Value = string.Concat(dataGridViewCell.Value, text3);
		}
		if (!ACE.RSGlobal.RSGlobal.IsNumber(text2))
		{
			text2 = Class16.smethod_0(1648924112);
			string value5 = Class16.smethod_0(1648919583);
			dataGridView_0[3, e.RowIndex].Value = value5;
		}
		if (Convert.ToDouble(text2) > 100.0)
		{
			text2 = Class16.smethod_0(1648919573);
			string value6 = Class16.smethod_0(1648926675);
			dataGridView_0[3, e.RowIndex].Value = value6;
		}
		else if (Convert.ToDouble(text2) < 0.0)
		{
			text2 = Class16.smethod_0(1648924112);
			string value7 = Class16.smethod_0(1648919583);
			dataGridView_0[3, e.RowIndex].Value = value7;
		}
		decimal num = 100m;
		decimal value8 = Convert.ToDecimal(text2) / num;
		ref float prob = ref list_0[e.RowIndex].prob;
		prob = Convert.ToSingle(value8);
		decimal decimal_ = Convert.ToDecimal(text2);
		method_12(decimal_);
		method_8();
		method_18(bool_2: false);
		goto IL_03c9;
	}

	private decimal method_10(NumericUpDown numericUpDown_8, decimal decimal_1)
	{
		if (decimal_1 < numericUpDown_8.Minimum)
		{
			return numericUpDown_8.Minimum;
		}
		if (decimal_1 > numericUpDown_8.Maximum)
		{
			return numericUpDown_8.Maximum;
		}
		return decimal_1;
	}

	private int method_11(TrackBar trackBar_6, decimal decimal_1)
	{
		decimal num = trackBar_6.Minimum;
		decimal num2 = trackBar_6.Maximum;
		decimal d = ((decimal_1 < num) ? num : ((decimal_1 > num2) ? num2 : decimal_1));
		return decimal.ToInt32(decimal.Truncate(d));
	}

	private void method_12(decimal decimal_1)
	{
		numericUpDown_1.Value = method_10(numericUpDown_1, decimal_1);
	}

	private void method_13(decimal decimal_1)
	{
		trackBar_1.Value = method_11(trackBar_1, decimal_1);
	}

	private void numericUpDown_7_DoubleClick(object sender, EventArgs e)
	{
		commonStorage_0.ResetBuffer();
		decimal value = numericUpDown_7.Value;
		ACE.Elements.eListCollection.eListCollection eListCollection2 = eListCollection_0;
		int[] mattersLists = eListCollection2.MattersLists;
		ITEMPOS iTEMPOS = eListCollection2.FindItemPos(mattersLists, (int)value);
		if (iTEMPOS != null)
		{
			itemsWindow_0.newitemlist = iTEMPOS.int_0;
			itemsWindow_0.newitemindex = iTEMPOS.int_1;
		}
		itemsWindow_0.newlistsindices = eListCollection_0.MattersLists;
		itemsWindow_0.ShowDialog();
		if (CommonStorage.sData != null && CommonStorage.sData != string.Empty)
		{
			numericUpDown_7.Text = CommonStorage.sData;
		}
		GC.KeepAlive(this);
	}

	private void numericUpDown_2_DoubleClick(object sender, EventArgs e)
	{
		method_14();
	}

	private void method_14()
	{
		commonStorage_0.ResetBuffer();
		decimal value = numericUpDown_2.Value;
		ACE.Elements.eListCollection.eListCollection eListCollection2 = eListCollection_0;
		int[] mattersLists = eListCollection2.MattersLists;
		ITEMPOS iTEMPOS = eListCollection2.FindItemPos(mattersLists, (int)value);
		if (iTEMPOS != null)
		{
			itemsWindow_0.newitemlist = iTEMPOS.int_0;
			itemsWindow_0.newitemindex = iTEMPOS.int_1;
		}
		itemsWindow_0.newlistsindices = eListCollection_0.MattersLists;
		itemsWindow_0.ShowDialog();
		if (CommonStorage.sData != null && CommonStorage.sData != string.Empty)
		{
			numericUpDown_2.Text = CommonStorage.sData;
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 4)
		{
			method_14();
		}
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		if (bool_1)
		{
			return;
		}
		bool_1 = true;
		int index;
		NumericUpDown numericUpDown;
		object obj;
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			DataGridView dataGridView = dataGridView_0;
			int count = list_0.Count;
			if (dataGridView.SelectedRows[0].Index < count)
			{
				index = dataGridView_0.SelectedRows[0].Index;
				numericUpDown = numericUpDown_2;
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
		numericUpDown_2.Text = Class16.smethod_0(1648924112);
		method_13(0m);
		numericUpDown_1.Text = Class16.smethod_0(1648924112);
		goto IL_011e;
		IL_0099:
		numericUpDown.Text = (string)obj;
		decimal decimal_ = Convert.ToDecimal(list_0[index].prob * 100f);
		method_12(decimal_);
		decimal num = 10m;
		decimal decimal_2 = numericUpDown_1.Value * num;
		method_13(decimal_2);
		goto IL_011e;
		IL_011e:
		method_17();
		bool_1 = false;
	}

	private void numericUpDown_2_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_1)
		{
			if (dataGridView_0.SelectedRows.Count < 1)
			{
				GC.KeepAlive(this);
				return;
			}
			decimal value = numericUpDown_2.Value;
			DataGridView dataGridView = dataGridView_0;
			dataGridView_0[0, dataGridView.SelectedRows[0].Index].Value = value.ToString();
			GC.KeepAlive(this);
		}
	}

	private void numericUpDown_1_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_1)
		{
			if (dataGridView_0.SelectedRows.Count < 1)
			{
				GC.KeepAlive(this);
				return;
			}
			decimal num = 10m;
			decimal decimal_ = numericUpDown_1.Value * num;
			method_13(decimal_);
			method_16();
		}
	}

	private void trackBar_1_Scroll(object sender, EventArgs e)
	{
		if (!bool_1)
		{
			decimal decimal_ = trackBar_1.Value / 10;
			method_12(decimal_);
			GC.KeepAlive(this);
		}
	}

	private void dataGridView_0_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 5 && e.RowIndex > -1)
		{
			int num = ((!(bool)dataGridView_0[5, e.RowIndex].Value) ? 1 : 0);
			dataGridView_0[5, e.RowIndex].Value = (byte)num != 0;
			dataGridView_0.RefreshEdit();
		}
		GC.KeepAlive(this);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		button_2.Enabled = false;
		method_15();
		dataGridView_0.Focus();
		button_2.Enabled = true;
		GC.KeepAlive(this);
	}

	private void DropEditor_Load(object sender, EventArgs e)
	{
	}

	private void DropEditor_FormClosed(object sender, FormClosedEventArgs e)
	{
		bool flag = checkBox_0.Checked;
		settingsClass_0.SaveSetting(Class16.smethod_0(1648987494), Class16.smethod_0(1648926403), flag.ToString());
		GC.KeepAlive(this);
	}

	private void method_15()
	{
		if (dataGridView_0.Rows.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		list_0 = PROB_VALUES.SortDesceding(list_0);
		method_19();
	}

	private void method_16()
	{
		float num6;
		if (dataGridView_0.RowCount != 0 && dataGridView_0.SelectedRows.Count != 0)
		{
			decimal num = 100m;
			float num2 = (float)(numericUpDown_1.Value / num);
			if (num2 < 1E-06f)
			{
				num2 = 0f;
			}
			float num3 = (float)(1.0 - (double)num2);
			float num4 = 0f;
			int num5 = 0;
			int index = dataGridView_0.SelectedRows[0].Index;
			num6 = 0f;
			int num7 = 0;
			if (0 < list_0.Count)
			{
				do
				{
					if (num7 != index)
					{
						num6 = (float)((double)list_0[num7].prob + (double)num6);
						if ((bool)dataGridView_0[5, num7].Value)
						{
							num3 = (float)((double)num3 - (double)list_0[num7].prob);
							num5++;
						}
						else
						{
							num4 = (float)((double)list_0[num7].prob + (double)num4);
						}
					}
					num7++;
				}
				while (num7 < list_0.Count);
			}
			if (!((double)Math.Abs((float)(1.0 - (double)num6)) < 5E-07) || !((double)list_0[index].prob > 5E-07))
			{
				bool_1 = true;
				if (!(num3 < 0f) && (num4 != 0f || num5 < list_0.Count - 1))
				{
					list_0[index].prob = num2;
					decimal decimal_ = (decimal)(num2 * 100f);
					method_12(decimal_);
					float prob = list_0[index].prob;
					int numAfterDecimal = 2;
					if ((double)prob < 0.0001)
					{
						numAfterDecimal = 4;
					}
					string value = ACE.RSGlobal.RSGlobal.ToPercent(prob, numAfterDecimal);
					dataGridView_0[3, index].Value = value;
				}
				else
				{
					decimal num8 = 10m;
					decimal decimal_2 = numericUpDown_1.Value * num8;
					method_13(decimal_2);
				}
				if (!checkBox_0.Checked && (float_0 == null || (nint)float_0.LongLength < list_0.Count))
				{
					method_17();
				}
				int num9 = 0;
				if (0 < list_0.Count)
				{
					do
					{
						if (!(bool)dataGridView_0[5, num9].Value && num9 != index)
						{
							if (!checkBox_0.Checked)
							{
								float prob2 = (float)((double)float_0[num9] * (double)num3);
								list_0[num9].prob = prob2;
							}
							else
							{
								float num10 = ((!(num4 > 0f)) ? ((float)(1.0 / (double)(float)list_0.Count)) : ((float)((double)list_0[num9].prob / (double)num4)));
								if (num3 <= 0f)
								{
									num10 = 0f;
								}
								list_0[num9].prob = (float)((double)num10 * (double)num3);
							}
							float prob3 = list_0[num9].prob;
							int numAfterDecimal2 = 2;
							if ((double)prob3 < 0.0001)
							{
								numAfterDecimal2 = 4;
							}
							string value2 = ACE.RSGlobal.RSGlobal.ToPercent(prob3, numAfterDecimal2);
							dataGridView_0[3, num9].Value = value2;
						}
						num9++;
					}
					while (num9 < list_0.Count);
				}
				num6 = 0f;
				int num11 = 0;
				if (0 >= list_0.Count)
				{
					goto IL_03e9;
				}
				do
				{
					num6 = (float)((double)list_0[num11].prob + (double)num6);
					num11++;
				}
				while (num11 < list_0.Count);
			}
			if (num6 != 1f)
			{
				goto IL_03e9;
			}
			goto IL_0497;
		}
		GC.KeepAlive(this);
		return;
		IL_03e9:
		int maxProbIndex = PROB_VALUES.GetMaxProbIndex(list_0);
		ref float prob4 = ref list_0[maxProbIndex].prob;
		prob4 = (float)(1.0 - (double)num6 + (double)prob4);
		if (list_0[maxProbIndex].prob < 0f)
		{
			list_0[maxProbIndex].prob = 0f;
		}
		float prob5 = list_0[maxProbIndex].prob;
		int numAfterDecimal3 = 2;
		if ((double)prob5 < 0.0001)
		{
			numAfterDecimal3 = 4;
		}
		string value3 = ACE.RSGlobal.RSGlobal.ToPercent(prob5, numAfterDecimal3);
		dataGridView_0[3, maxProbIndex].Value = value3;
		goto IL_0497;
		IL_0497:
		bool_1 = false;
		method_8();
		method_18(bool_2: false);
	}

	private void method_17()
	{
		float_0 = new float[list_0.Count];
		if (dataGridView_0.SelectedRows.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		float num = (float)trackBar_1.Value / 1000f;
		if (num < 1E-06f)
		{
			num = 0f;
		}
		float num2 = (float)(1.0 - (double)num);
		float num3 = 0f;
		int index = dataGridView_0.SelectedRows[0].Index;
		int num4 = 0;
		if (0 < list_0.Count)
		{
			do
			{
				if (num4 != index)
				{
					if ((bool)dataGridView_0[5, num4].Value)
					{
						num2 = (float)((double)num2 - (double)list_0[num4].prob);
					}
					else
					{
						num3 = (float)((double)list_0[num4].prob + (double)num3);
					}
				}
				num4++;
			}
			while (num4 < list_0.Count);
			if (num3 > 0f)
			{
				int num5 = 0;
				if (0 < list_0.Count)
				{
					do
					{
						if (!(bool)dataGridView_0[5, num5].Value && num5 != index)
						{
							float num6 = (float)((double)list_0[num5].prob / (double)num3);
							if (num2 <= 0f)
							{
								num6 = 0f;
							}
							float_0[num5] = num6;
						}
						num5++;
					}
					while (num5 < list_0.Count);
				}
				goto IL_01cd;
			}
		}
		int num7 = 0;
		if (0 < (nint)float_0.LongLength)
		{
			do
			{
				float num8 = (float)(1.0 / (double)(float)list_0.Count);
				float_0[num7] = num8;
				num7++;
			}
			while (num7 < (nint)float_0.LongLength);
		}
		goto IL_01cd;
		IL_01cd:
		GC.KeepAlive(this);
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void numericUpDown_7_ValueChanged(object sender, EventArgs e)
	{
	}

	private void numericUpDown_7_MouseCaptureChanged(object sender, EventArgs e)
	{
	}

	private void method_18([MarshalAs(UnmanagedType.U1)] bool bool_2)
	{
		ACE.RSGlobal.RSGlobal.recurse_level_UpdateGraphicalProbs_DropEditor++;
		ACE.RSGlobal.RSGlobal.valid_recurse_level_UpdateGraphicalProbs_DropEditor = ACE.RSGlobal.RSGlobal.recurse_level_UpdateGraphicalProbs_DropEditor;
		int num = Math.Max(1, dataGridView_0.Columns[4].Width);
		int num2 = 0;
		if (list_0.Count > 0)
		{
			int num3 = Math.Min(list_0.Count, dataGridView_0.RowCount);
			while (num2 < num3)
			{
				int num4 = Math.Max(1, dataGridView_0.Rows[num2].Height);
				if (!bool_2)
				{
					float prob = list_0[num2].prob;
					int num5 = 0;
					if (prob > 1E-06f)
					{
						num5 = (int)((double)(float)num * (double)prob - 2.0);
						num5 = ((num5 < 1) ? 1 : num5);
					}
					int num6 = Convert.ToInt32(dataGridView_0[4, num2].Tag ?? ((object)(-1)));
					if (num6 == num5)
					{
						num2++;
						continue;
					}
				}
				float prob2 = list_0[num2].prob;
				dataGridView_0[4, num2].Value = ACE.RSGlobal.RSGlobal.DrawProgress(prob2, num, num4);
				float prob3 = list_0[num2].prob;
				int num7 = 0;
				if (prob3 > 1E-06f)
				{
					num7 = (int)((double)(float)num * (double)prob3 - 2.0);
					num7 = ((num7 < 1) ? 1 : num7);
				}
				dataGridView_0[4, num2].Tag = num7;
				num2++;
			}
		}
		ACE.RSGlobal.RSGlobal.recurse_level_UpdateGraphicalProbs_DropEditor--;
		GC.KeepAlive(this);
	}

	private void DropEditor_Resize(object sender, EventArgs e)
	{
	}

	private void trackBar_1_MouseUp(object sender, MouseEventArgs e)
	{
	}

	private void dataGridView_0_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
	{
		if (e.Column.Index == 3 || e.Column.Index == 4)
		{
			float num = (float)dataGridView_0[3, e.RowIndex1].Tag;
			float num2 = (float)dataGridView_0[3, e.RowIndex2].Tag;
			if ((double)num > (double)num2)
			{
				PROB_VALUES value = list_0[e.RowIndex1];
				List<PROB_VALUES> list = list_0;
				list_0[e.RowIndex1] = list[e.RowIndex2];
				list_0[e.RowIndex2] = value;
				e.SortResult = 1;
				e.Handled = true;
			}
			else if ((double)num < (double)num2)
			{
				PROB_VALUES value2 = list_0[e.RowIndex1];
				List<PROB_VALUES> list2 = list_0;
				list_0[e.RowIndex1] = list2[e.RowIndex2];
				list_0[e.RowIndex2] = value2;
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
		if (e.Column.Index == 4)
		{
			method_18(bool_2: true);
		}
	}

	private void dataGridView_0_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
		{
			method_15();
		}
	}

	private void checkBox_0_Click(object sender, EventArgs e)
	{
		if (checkBox_0.Checked)
		{
			method_15();
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (dataGridView_0.RowCount < 1)
		{
			GC.KeepAlive(this);
			return;
		}
		decimal num = list_0.Count;
		float num2 = (float)(1m / num);
		float num3 = 0f;
		bool_1 = true;
		int num4 = list_0.Count - 1;
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
				dataGridView_0[3, num4].Value = value;
				list_0[num4].prob = num2;
				num4--;
			}
			while (num4 >= 0);
		}
		bool_1 = false;
		method_8();
		method_18(bool_2: false);
		method_17();
	}

	private void trackBar_1_MouseDown(object sender, MouseEventArgs e)
	{
		decimal num = 99m;
		if (numericUpDown_1.Value < num)
		{
			method_17();
		}
	}

	private void method_19()
	{
		bool_1 = true;
		dataGridView_0.Rows.Clear();
		List<PROB_VALUES>.Enumerator enumerator = list_0.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				PROB_VALUES current = enumerator.Current;
				string iconName = null;
				ITEMINFO itemInfo = eListCollection_0.GetItemInfo(current.id);
				string name;
				if (itemInfo != null)
				{
					name = itemInfo.name;
					iconName = itemInfo.IconName;
				}
				else
				{
					name = TextStorage.TEXTS.GetText(Class16.smethod_0(1648902988));
				}
				float prob = current.prob;
				int numAfterDecimal = 2;
				if ((double)prob < 0.0001)
				{
					numAfterDecimal = 4;
				}
				string text = ACE.RSGlobal.RSGlobal.ToPercent(prob, numAfterDecimal);
				object[] array = new object[6];
				int id = current.id;
				array[0] = id.ToString();
				array[1] = eListCollection_0.Icons.GetIcon(iconName, IsTga: false, 32);
				array[2] = name;
				array[3] = text;
				array[4] = null;
				array[5] = false;
				dataGridView_0.Rows.Add(array);
				if (itemInfo != null)
				{
					int rowIndex = dataGridView_0.RowCount - 1;
					dataGridView_0[2, rowIndex].Style.ForeColor = itemInfo.color;
				}
				else
				{
					Color red = Color.Red;
					int rowIndex2 = dataGridView_0.RowCount - 1;
					dataGridView_0[2, rowIndex2].Style.ForeColor = red;
				}
			}
			while (enumerator.MoveNext());
		}
		method_8();
		method_18(bool_2: true);
		bool_1 = false;
	}

	private void dataGridView_0_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
	{
		if (e.RowIndex < 0 || e.RowIndex >= list_0.Count || eListCollection_0 == null)
		{
			return;
		}
		try
		{
			int id = list_0[e.RowIndex].id;
			if (id <= 0)
			{
				return;
			}
			ITEMINFO itemInfo = eListCollection_0.GetItemInfo(id);
			if (itemInfo != null)
			{
				string text = itemInfo.name;
				if (!string.IsNullOrEmpty(itemInfo.CatName))
				{
					text = text + Class16.smethod_0(1648986283) + itemInfo.CatName + Class16.smethod_0(1649008474);
				}
				text += string.Format(Class16.smethod_0(1648986300), id);
				if (itemInfo.item_type != ItemType.All)
				{
					text += string.Format(Class16.smethod_0(1648986307), itemInfo.item_type);
				}
				e.ToolTipText = text;
			}
		}
		catch
		{
		}
	}
}
