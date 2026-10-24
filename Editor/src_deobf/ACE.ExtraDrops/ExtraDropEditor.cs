using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements;
using ACE.Elements.eListCollection;
using ACE.License;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.ExtraDrops;

public class ExtraDropEditor : Form
{
	private sealed class Class133
	{
		public TextBox textBox_0;

		internal void method_0()
		{
			textBox_0.SelectAll();
		}
	}

	private static class Class134
	{
		public static Func<EXTRADROPTABLE, ExtraDropGroupVm> func_0;
	}

	private sealed class Class135
	{
		public ExtraDropEditor extraDropEditor_0;

		public Control control_0;

		internal void method_0(object sender, EventArgs e)
		{
			extraDropEditor_0.method_27(control_0);
		}

		internal void method_1(object sender, EventArgs e)
		{
			if (extraDropEditor_0.control_0 == control_0)
			{
				extraDropEditor_0.method_29();
			}
		}
	}

	[Serializable]
	private sealed class Class136
	{
		public static readonly Class136 class136_0 = new Class136();

		public static Func<ExtraDropItemVm, decimal> func_0;

		public static Func<ExtraDropGroupVm, EXTRADROPTABLE> func_1;

		public static Func<int, int> func_2;

		internal decimal method_0(ExtraDropItemVm extraDropItemVm_0)
		{
			return extraDropItemVm_0.ProbabilityPercent;
		}

		internal EXTRADROPTABLE method_1(ExtraDropGroupVm extraDropGroupVm_0)
		{
			return extraDropGroupVm_0?.ToTable();
		}

		internal int method_2(int int_0)
		{
			return int_0;
		}
	}

	private EXTRA_DROPS extra_DROPS_0;

	private eListCollection eListCollection_0;

	private ItemsWindow itemsWindow_0;

	private CommonStorage commonStorage_0;

	private ItemsToolTip itemsToolTip_0;

	private ExtraDropsDocument extraDropsDocument_0;

	private readonly BindingSource bindingSource_0 = new BindingSource();

	private readonly BindingSource bindingSource_1 = new BindingSource();

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private int int_0 = -1;

	private bool bool_3;

	private IContainer icontainer_0;

	private ToolTip toolTip_0;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripMenuItem toolStripMenuItem_4;

	private TableLayoutPanel tableLayoutPanel_0;

	private Panel panel_0;

	private TextBox textBox_0;

	private ListBox listBox_0;

	private FlowLayoutPanel flowLayoutPanel_0;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private Panel panel_1;

	private GroupBox groupBox_0;

	private Label label_0;

	private TextBox textBox_1;

	private Label label_1;

	private ComboBox comboBox_0;

	private GroupBox groupBox_1;

	private TableLayoutPanel tableLayoutPanel_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	private Label label_6;

	private Label label_7;

	private Label label_8;

	private Label label_9;

	private NumericUpDown numericUpDown_0;

	private NumericUpDown numericUpDown_1;

	private NumericUpDown numericUpDown_2;

	private NumericUpDown numericUpDown_3;

	private NumericUpDown numericUpDown_4;

	private NumericUpDown numericUpDown_5;

	private NumericUpDown numericUpDown_6;

	private NumericUpDown numericUpDown_7;

	private Label label_10;

	private Button button_4;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TableLayoutPanel tableLayoutPanel_2;

	private TextBox textBox_2;

	private Button button_5;

	private DataGridView dataGridView_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private FlowLayoutPanel flowLayoutPanel_1;

	private Button button_6;

	private Button button_7;

	private Button button_8;

	private TabPage tabPage_1;

	private TableLayoutPanel tableLayoutPanel_3;

	private TextBox textBox_3;

	private Button button_9;

	private DataGridView dataGridView_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewImageColumn dataGridViewImageColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private TableLayoutPanel tableLayoutPanel_4;

	private FlowLayoutPanel flowLayoutPanel_2;

	private TableLayoutPanel tableLayoutPanel_5;

	private Label label_11;

	private NumericUpDown numericUpDown_8;

	private TrackBar trackBar_0;

	private Button button_10;

	private Button button_11;

	private Button button_12;

	private Button button_13;

	private Button button_14;

	private Label label_12;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private bool bool_4;

	private Button button_15;

	private Button button_16;

	private Control control_0;

	private byte[] byte_0;

	private bool bool_5;

	public ExtraDropEditor(EXTRA_DROPS extra, eListCollection ref_eLC, ItemsWindow itemsWindow, CommonStorage ref_CStorage)
	{
		try
		{
			extra_DROPS_0 = extra;
			eListCollection_0 = ref_eLC;
			itemsWindow_0 = itemsWindow;
			commonStorage_0 = ref_CStorage;
			method_7();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_0, value: true);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_1, value: true);
			itemsToolTip_0 = new ItemsToolTip(TOOLTIP_TYPE.Fly);
			ItemsToolTip.eLC = eListCollection_0;
			ItemsToolTip.CStorage = commonStorage_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip_0);
			dataGridView_0.AutoGenerateColumns = false;
			dataGridView_1.AutoGenerateColumns = false;
			dataGridViewTextBoxColumn_0.DataPropertyName = Class16.smethod_0(1649077794);
			dataGridViewTextBoxColumn_2.DataPropertyName = Class16.smethod_0(1649077794);
			dataGridViewTextBoxColumn_4.DataPropertyName = Class16.smethod_0(1649077803);
			bindingSource_0.DataSource = typeof(ExtraDropMonsterVm);
			bindingSource_1.DataSource = typeof(ExtraDropItemVm);
			dataGridView_0.DataSource = bindingSource_0;
			dataGridView_1.DataSource = bindingSource_1;
			dataGridView_0.DataError += dataGridView_1_DataError;
			dataGridView_1.DataError += dataGridView_1_DataError;
			dataGridView_0.Scroll += dataGridView_1_Scroll;
			dataGridView_1.Scroll += dataGridView_1_Scroll;
			dataGridView_1.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dataGridView_1.EditMode = DataGridViewEditMode.EditOnEnter;
			dataGridView_1.CellClick += dataGridView_1_CellClick;
			dataGridView_1.CellEndEdit += dataGridView_1_CellEndEdit;
			dataGridView_1.CellMouseDown += dataGridView_1_CellMouseDown;
			dataGridView_1.MouseMove += dataGridView_1_MouseMove;
			dataGridView_1.MouseUp += dataGridView_1_MouseUp;
			dataGridView_1.MouseLeave += dataGridView_1_MouseLeave;
			dataGridView_1.EditingControlShowing += dataGridView_1_EditingControlShowing;
			dataGridView_1.SelectionChanged += dataGridView_1_SelectionChanged;
			numericUpDown_8.ValueChanged += numericUpDown_8_ValueChanged;
			trackBar_0.ValueChanged += trackBar_0_ValueChanged;
			numericUpDown_8.Enabled = false;
			trackBar_0.Enabled = false;
			dataGridViewTextBoxColumn_4.DefaultCellStyle.Format = Class16.smethod_0(1649077836);
			dataGridViewTextBoxColumn_4.DefaultCellStyle.FormatProvider = CultureInfo.CurrentCulture;
			comboBox_0.Items.Clear();
			comboBox_0.Items.Add(EDT_TYPE.Replace);
			comboBox_0.Items.Add(EDT_TYPE.Addon);
			comboBox_0.Items.Add(EDT_TYPE.Unknown);
			method_19();
			method_1();
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private ExtraDropGroupVm method_0()
	{
		return listBox_0.SelectedItem as ExtraDropGroupVm;
	}

	private void method_1()
	{
		bool_0 = true;
		extraDropsDocument_0 = ExtraDropsDocument.FromExtraDrops(extra_DROPS_0);
		listBox_0.DataSource = extraDropsDocument_0.Groups;
		listBox_0.DisplayMember = Class16.smethod_0(1648936731);
		if (extraDropsDocument_0.Groups.Count > 0)
		{
			listBox_0.SelectedIndex = 0;
		}
		else
		{
			method_2(null);
		}
		method_3(bool_6: false);
		bool_0 = false;
	}

	private void method_2(ExtraDropGroupVm extraDropGroupVm_0)
	{
		bool_0 = true;
		textBox_1.DataBindings.Clear();
		comboBox_0.DataBindings.Clear();
		numericUpDown_0.DataBindings.Clear();
		numericUpDown_1.DataBindings.Clear();
		numericUpDown_2.DataBindings.Clear();
		numericUpDown_3.DataBindings.Clear();
		numericUpDown_4.DataBindings.Clear();
		numericUpDown_5.DataBindings.Clear();
		numericUpDown_6.DataBindings.Clear();
		numericUpDown_7.DataBindings.Clear();
		if (extraDropGroupVm_0 == null)
		{
			textBox_1.Text = string.Empty;
			comboBox_0.SelectedIndex = -1;
			bindingSource_0.DataSource = null;
			bindingSource_1.DataSource = null;
			method_9();
			method_17();
			bool_0 = false;
			return;
		}
		textBox_1.Text = extraDropGroupVm_0.Name ?? string.Empty;
		comboBox_0.DataBindings.Add(Class16.smethod_0(1649077849), extraDropGroupVm_0, Class16.smethod_0(1648936875), formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged);
		numericUpDown_0.DataBindings.Add(Class16.smethod_0(1648941098), extraDropGroupVm_0, Class16.smethod_0(1649077876), formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged);
		numericUpDown_1.DataBindings.Add(Class16.smethod_0(1648941098), extraDropGroupVm_0, Class16.smethod_0(1649077895), formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged);
		numericUpDown_2.DataBindings.Add(Class16.smethod_0(1648941098), extraDropGroupVm_0, Class16.smethod_0(1649077906), formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged);
		numericUpDown_3.DataBindings.Add(Class16.smethod_0(1648941098), extraDropGroupVm_0, Class16.smethod_0(1649077933), formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged);
		numericUpDown_4.DataBindings.Add(Class16.smethod_0(1648941098), extraDropGroupVm_0, Class16.smethod_0(1649077944), formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged);
		numericUpDown_5.DataBindings.Add(Class16.smethod_0(1648941098), extraDropGroupVm_0, Class16.smethod_0(1649077963), formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged);
		numericUpDown_6.DataBindings.Add(Class16.smethod_0(1648941098), extraDropGroupVm_0, Class16.smethod_0(1649077990), formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged);
		numericUpDown_7.DataBindings.Add(Class16.smethod_0(1648941098), extraDropGroupVm_0, Class16.smethod_0(1649078001), formattingEnabled: true, DataSourceUpdateMode.OnPropertyChanged);
		bindingSource_0.DataSource = null;
		bindingSource_1.DataSource = null;
		bindingSource_0.DataSource = extraDropGroupVm_0.Monsters;
		bindingSource_1.DataSource = extraDropGroupVm_0.Items;
		bindingSource_0.ResetBindings(metadataChanged: false);
		bindingSource_1.ResetBindings(metadataChanged: false);
		dataGridView_0.Invalidate();
		dataGridView_1.Invalidate();
		dataGridView_0.Refresh();
		dataGridView_1.Refresh();
		method_15(textBox_2.Text);
		method_16(textBox_3.Text);
		method_12();
		method_9();
		method_17();
		bool_0 = false;
	}

	private void method_3(bool bool_6)
	{
		bool_1 = bool_6;
		if (extra_DROPS_0 != null)
		{
			extra_DROPS_0.FileChanged = bool_6;
		}
		method_4();
	}

	private void method_4()
	{
		string arg = (string.IsNullOrWhiteSpace(extra_DROPS_0?.FileName) ? TextStorage.Msg(Class16.smethod_0(1649078028), Class16.smethod_0(1649078054)) : System.IO.Path.GetFileName(extra_DROPS_0.FileName));
		Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649078069), Class16.smethod_0(1649078109)), arg) + (bool_1 ? Class16.smethod_0(1648941528) : string.Empty);
	}

	private void method_5()
	{
		try
		{
			Validate();
		}
		catch
		{
		}
		if (dataGridView_0.IsCurrentCellInEditMode)
		{
			dataGridView_0.EndEdit();
		}
		if (dataGridView_1.IsCurrentCellInEditMode)
		{
			dataGridView_1.EndEdit();
		}
		bindingSource_0.EndEdit();
		bindingSource_1.EndEdit();
	}

	private void dataGridView_1_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		e.ThrowException = false;
	}

	private void dataGridView_1_Scroll(object sender, ScrollEventArgs e)
	{
		(sender as DataGridView)?.Invalidate();
	}

	private bool method_6()
	{
		if (!bool_1)
		{
			return true;
		}
		return DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649078140)), TextStorage.Msg(Class16.smethod_0(1649002823)), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) switch
		{
			DialogResult.Cancel => false, 
			DialogResult.No => true, 
			_ => method_8(bool_6: false), 
		};
	}

	private void method_7()
	{
		icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(ExtraDropEditor));
		toolTip_0 = new ToolTip(icontainer_0);
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		tableLayoutPanel_0 = new TableLayoutPanel();
		panel_0 = new Panel();
		flowLayoutPanel_0 = new FlowLayoutPanel();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		listBox_0 = new ListBox();
		textBox_0 = new TextBox();
		panel_1 = new Panel();
		tabControl_0 = new TabControl();
		tabPage_0 = new TabPage();
		tableLayoutPanel_2 = new TableLayoutPanel();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		flowLayoutPanel_1 = new FlowLayoutPanel();
		button_6 = new Button();
		button_7 = new Button();
		button_8 = new Button();
		button_5 = new Button();
		textBox_2 = new TextBox();
		tabPage_1 = new TabPage();
		tableLayoutPanel_3 = new TableLayoutPanel();
		dataGridView_1 = new DataGridView();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_1 = new DataGridViewImageColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		tableLayoutPanel_4 = new TableLayoutPanel();
		flowLayoutPanel_2 = new FlowLayoutPanel();
		tableLayoutPanel_5 = new TableLayoutPanel();
		label_11 = new Label();
		numericUpDown_8 = new NumericUpDown();
		trackBar_0 = new TrackBar();
		button_10 = new Button();
		button_11 = new Button();
		button_12 = new Button();
		button_13 = new Button();
		button_14 = new Button();
		label_12 = new Label();
		button_9 = new Button();
		textBox_3 = new TextBox();
		groupBox_1 = new GroupBox();
		tableLayoutPanel_1 = new TableLayoutPanel();
		label_2 = new Label();
		label_3 = new Label();
		label_4 = new Label();
		label_5 = new Label();
		label_6 = new Label();
		label_7 = new Label();
		label_8 = new Label();
		label_9 = new Label();
		numericUpDown_0 = new NumericUpDown();
		numericUpDown_1 = new NumericUpDown();
		numericUpDown_2 = new NumericUpDown();
		numericUpDown_3 = new NumericUpDown();
		numericUpDown_4 = new NumericUpDown();
		numericUpDown_5 = new NumericUpDown();
		numericUpDown_6 = new NumericUpDown();
		numericUpDown_7 = new NumericUpDown();
		label_10 = new Label();
		button_4 = new Button();
		groupBox_0 = new GroupBox();
		label_1 = new Label();
		comboBox_0 = new ComboBox();
		label_0 = new Label();
		textBox_1 = new TextBox();
		menuStrip_0.SuspendLayout();
		tableLayoutPanel_0.SuspendLayout();
		panel_0.SuspendLayout();
		flowLayoutPanel_0.SuspendLayout();
		panel_1.SuspendLayout();
		tabControl_0.SuspendLayout();
		tabPage_0.SuspendLayout();
		tableLayoutPanel_2.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		flowLayoutPanel_1.SuspendLayout();
		tabPage_1.SuspendLayout();
		tableLayoutPanel_3.SuspendLayout();
		((ISupportInitialize)dataGridView_1).BeginInit();
		tableLayoutPanel_4.SuspendLayout();
		flowLayoutPanel_2.SuspendLayout();
		tableLayoutPanel_5.SuspendLayout();
		((ISupportInitialize)numericUpDown_8).BeginInit();
		((ISupportInitialize)trackBar_0).BeginInit();
		groupBox_1.SuspendLayout();
		tableLayoutPanel_1.SuspendLayout();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		((ISupportInitialize)numericUpDown_3).BeginInit();
		((ISupportInitialize)numericUpDown_4).BeginInit();
		((ISupportInitialize)numericUpDown_5).BeginInit();
		((ISupportInitialize)numericUpDown_6).BeginInit();
		((ISupportInitialize)numericUpDown_7).BeginInit();
		groupBox_0.SuspendLayout();
		SuspendLayout();
		menuStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripMenuItem_0 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1649078164);
		menuStrip_0.Size = new Size(1200, 24);
		menuStrip_0.TabIndex = 0;
		toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[4] { toolStripMenuItem_1, toolStripMenuItem_2, toolStripMenuItem_3, toolStripMenuItem_4 });
		toolStripMenuItem_0.Name = Class16.smethod_0(1648916926);
		toolStripMenuItem_0.Size = new Size(37, 20);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_1.Name = Class16.smethod_0(1649078171);
		toolStripMenuItem_1.Size = new Size(180, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648904254);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_2.Name = Class16.smethod_0(1649078206);
		toolStripMenuItem_2.Size = new Size(180, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648931498);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.Name = Class16.smethod_0(1649078238);
		toolStripMenuItem_3.Size = new Size(180, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		toolStripMenuItem_4.Name = Class16.smethod_0(1649014314);
		toolStripMenuItem_4.Size = new Size(180, 22);
		toolStripMenuItem_4.Text = Class16.smethod_0(1648931581);
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		tableLayoutPanel_0.ColumnCount = 2;
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel_0.Controls.Add(panel_0, 0, 0);
		tableLayoutPanel_0.Controls.Add(panel_1, 1, 0);
		tableLayoutPanel_0.Dock = DockStyle.Fill;
		tableLayoutPanel_0.Location = new Point(0, 24);
		tableLayoutPanel_0.Name = Class16.smethod_0(1649078270);
		tableLayoutPanel_0.RowCount = 1;
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_0.Size = new Size(1200, 676);
		tableLayoutPanel_0.TabIndex = 1;
		panel_0.Controls.Add(listBox_0);
		panel_0.Controls.Add(flowLayoutPanel_0);
		panel_0.Controls.Add(textBox_0);
		panel_0.Dock = DockStyle.Fill;
		panel_0.Location = new Point(3, 3);
		panel_0.Name = Class16.smethod_0(1649077263);
		panel_0.Size = new Size(254, 670);
		panel_0.TabIndex = 0;
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.Location = new Point(6, 6);
		textBox_0.Name = Class16.smethod_0(1649077273);
		textBox_0.Size = new Size(242, 23);
		textBox_0.TabIndex = 0;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(textBox_0, Class16.smethod_0(1649077302));
		textBox_0.TextChanged += textBox_0_TextChanged;
		listBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listBox_0.FormattingEnabled = true;
		listBox_0.IntegralHeight = false;
		listBox_0.Location = new Point(6, 35);
		listBox_0.Name = Class16.smethod_0(1649077325);
		listBox_0.Size = new Size(242, 593);
		listBox_0.TabIndex = 1;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		flowLayoutPanel_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		flowLayoutPanel_0.Controls.Add(button_0);
		flowLayoutPanel_0.Controls.Add(button_1);
		flowLayoutPanel_0.Controls.Add(button_2);
		flowLayoutPanel_0.Controls.Add(button_3);
		flowLayoutPanel_0.Location = new Point(6, 634);
		flowLayoutPanel_0.Name = Class16.smethod_0(1649077341);
		flowLayoutPanel_0.Size = new Size(242, 30);
		flowLayoutPanel_0.WrapContents = false;
		flowLayoutPanel_0.TabIndex = 2;
		button_0.Margin = new Padding(0, 0, 2, 0);
		button_0.Size = new Size(55, 26);
		button_0.Text = Class16.smethod_0(1648931361);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Margin = new Padding(0, 0, 2, 0);
		button_1.Size = new Size(55, 26);
		button_1.Text = Class16.smethod_0(1648992393);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Margin = new Padding(0, 0, 2, 0);
		button_2.Size = new Size(70, 26);
		button_2.Text = Class16.smethod_0(1649003400);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Margin = new Padding(0);
		button_3.Size = new Size(55, 26);
		button_3.Text = Class16.smethod_0(1648925718);
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		panel_1.Controls.Add(tabControl_0);
		panel_1.Controls.Add(groupBox_1);
		panel_1.Controls.Add(groupBox_0);
		panel_1.Dock = DockStyle.Fill;
		panel_1.Location = new Point(263, 3);
		panel_1.Name = Class16.smethod_0(1649077355);
		panel_1.Size = new Size(934, 670);
		panel_1.TabIndex = 1;
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Controls.Add(comboBox_0);
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(textBox_1);
		groupBox_0.Location = new Point(6, 6);
		groupBox_0.Name = Class16.smethod_0(1649077382);
		groupBox_0.Size = new Size(922, 62);
		groupBox_0.TabIndex = 0;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1649077398);
		label_0.AutoSize = true;
		label_0.Location = new Point(10, 26);
		label_0.Name = Class16.smethod_0(1649002095);
		label_0.Size = new Size(42, 15);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1648930944);
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.Location = new Point(58, 22);
		textBox_1.Name = Class16.smethod_0(1649002109);
		textBox_1.Size = new Size(590, 23);
		textBox_1.TabIndex = 1;
		textBox_1.TextChanged += textBox_1_TextChanged;
		label_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		label_1.AutoSize = true;
		label_1.Location = new Point(660, 26);
		label_1.Name = Class16.smethod_0(1649077402);
		label_1.Size = new Size(34, 15);
		label_1.TabIndex = 2;
		label_1.Text = Class16.smethod_0(1649014090);
		comboBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(700, 22);
		comboBox_0.Name = Class16.smethod_0(1649077416);
		comboBox_0.Size = new Size(210, 23);
		comboBox_0.TabIndex = 3;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_1.Controls.Add(tableLayoutPanel_1);
		groupBox_1.Location = new Point(6, 74);
		groupBox_1.Name = Class16.smethod_0(1649077438);
		groupBox_1.Size = new Size(922, 126);
		groupBox_1.TabIndex = 1;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1649077450);
		tableLayoutPanel_1.ColumnCount = 8;
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_1.Controls.Add(label_2, 0, 0);
		tableLayoutPanel_1.Controls.Add(label_3, 1, 0);
		tableLayoutPanel_1.Controls.Add(label_4, 2, 0);
		tableLayoutPanel_1.Controls.Add(label_5, 3, 0);
		tableLayoutPanel_1.Controls.Add(label_6, 4, 0);
		tableLayoutPanel_1.Controls.Add(label_7, 5, 0);
		tableLayoutPanel_1.Controls.Add(label_8, 6, 0);
		tableLayoutPanel_1.Controls.Add(label_9, 7, 0);
		tableLayoutPanel_1.Controls.Add(numericUpDown_0, 0, 1);
		tableLayoutPanel_1.Controls.Add(numericUpDown_1, 1, 1);
		tableLayoutPanel_1.Controls.Add(numericUpDown_2, 2, 1);
		tableLayoutPanel_1.Controls.Add(numericUpDown_3, 3, 1);
		tableLayoutPanel_1.Controls.Add(numericUpDown_4, 4, 1);
		tableLayoutPanel_1.Controls.Add(numericUpDown_5, 5, 1);
		tableLayoutPanel_1.Controls.Add(numericUpDown_6, 6, 1);
		tableLayoutPanel_1.Controls.Add(numericUpDown_7, 7, 1);
		tableLayoutPanel_1.Controls.Add(label_10, 0, 2);
		tableLayoutPanel_1.Controls.Add(button_4, 7, 2);
		tableLayoutPanel_1.Dock = DockStyle.Fill;
		tableLayoutPanel_1.Location = new Point(3, 19);
		tableLayoutPanel_1.Name = Class16.smethod_0(1649077493);
		tableLayoutPanel_1.RowCount = 3;
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 18f));
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_1.Size = new Size(916, 104);
		tableLayoutPanel_1.TabIndex = 0;
		label_2.Dock = DockStyle.Fill;
		label_2.TextAlign = ContentAlignment.MiddleCenter;
		label_2.Text = Class16.smethod_0(1648924112);
		label_3.Dock = DockStyle.Fill;
		label_3.TextAlign = ContentAlignment.MiddleCenter;
		label_3.Text = Class16.smethod_0(1648934925);
		label_4.Dock = DockStyle.Fill;
		label_4.TextAlign = ContentAlignment.MiddleCenter;
		label_4.Text = Class16.smethod_0(1648934967);
		label_5.Dock = DockStyle.Fill;
		label_5.TextAlign = ContentAlignment.MiddleCenter;
		label_5.Text = Class16.smethod_0(1648911557);
		label_6.Dock = DockStyle.Fill;
		label_6.TextAlign = ContentAlignment.MiddleCenter;
		label_6.Text = Class16.smethod_0(1648935001);
		label_7.Dock = DockStyle.Fill;
		label_7.TextAlign = ContentAlignment.MiddleCenter;
		label_7.Text = Class16.smethod_0(1648911820);
		label_8.Dock = DockStyle.Fill;
		label_8.TextAlign = ContentAlignment.MiddleCenter;
		label_8.Text = Class16.smethod_0(1648910861);
		label_9.Dock = DockStyle.Fill;
		label_9.TextAlign = ContentAlignment.MiddleCenter;
		label_9.Text = Class16.smethod_0(1648911788);
		NumericUpDown[] array = new NumericUpDown[8] { numericUpDown_0, numericUpDown_1, numericUpDown_2, numericUpDown_3, numericUpDown_4, numericUpDown_5, numericUpDown_6, numericUpDown_7 };
		for (int i = 0; i < array.Length; i++)
		{
			array[i].DecimalPlaces = 6;
			array[i].Increment = 0.000001m;
			array[i].Minimum = 0m;
			array[i].Maximum = 100m;
			array[i].Dock = DockStyle.Fill;
			array[i].TextAlign = HorizontalAlignment.Center;
			array[i].ValueChanged += method_18;
		}
		tableLayoutPanel_1.SetColumnSpan(label_10, 7);
		label_10.Dock = DockStyle.Fill;
		label_10.Text = Class16.smethod_0(1649077505);
		label_10.TextAlign = ContentAlignment.MiddleLeft;
		button_4.Dock = DockStyle.Fill;
		button_4.Text = Class16.smethod_0(1649077527);
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		tabControl_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tabControl_0.Controls.Add(tabPage_0);
		tabControl_0.Controls.Add(tabPage_1);
		tabControl_0.Location = new Point(6, 206);
		tabControl_0.Name = Class16.smethod_0(1649077543);
		tabControl_0.SelectedIndex = 0;
		tabControl_0.Size = new Size(922, 458);
		tabControl_0.TabIndex = 2;
		tabPage_0.Controls.Add(tableLayoutPanel_2);
		tabPage_0.Location = new Point(4, 24);
		tabPage_0.Name = Class16.smethod_0(1649001464);
		tabPage_0.Padding = new Padding(3);
		tabPage_0.Size = new Size(914, 430);
		tabPage_0.TabIndex = 0;
		tabPage_0.Text = Class16.smethod_0(1649000458);
		tabPage_0.UseVisualStyleBackColor = true;
		tableLayoutPanel_2.ColumnCount = 2;
		tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120f));
		tableLayoutPanel_2.Controls.Add(textBox_2, 0, 0);
		tableLayoutPanel_2.Controls.Add(button_5, 1, 0);
		tableLayoutPanel_2.Controls.Add(dataGridView_0, 0, 1);
		tableLayoutPanel_2.Controls.Add(flowLayoutPanel_1, 0, 2);
		tableLayoutPanel_2.Dock = DockStyle.Fill;
		tableLayoutPanel_2.Location = new Point(3, 3);
		tableLayoutPanel_2.Name = Class16.smethod_0(1649077552);
		tableLayoutPanel_2.RowCount = 3;
		tableLayoutPanel_2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
		tableLayoutPanel_2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_2.RowStyles.Add(new RowStyle(SizeType.Absolute, 34f));
		tableLayoutPanel_2.Size = new Size(908, 424);
		tableLayoutPanel_2.TabIndex = 0;
		textBox_2.Dock = DockStyle.Fill;
		textBox_2.Location = new Point(3, 5);
		textBox_2.Margin = new Padding(3, 5, 3, 3);
		textBox_2.Name = Class16.smethod_0(1649077581);
		toolTip_0.SetToolTip(textBox_2, Class16.smethod_0(1649077604));
		textBox_2.Size = new Size(782, 23);
		textBox_2.TabIndex = 0;
		textBox_2.TextChanged += textBox_2_TextChanged;
		button_5.Dock = DockStyle.Fill;
		button_5.Location = new Point(791, 3);
		button_5.Name = Class16.smethod_0(1649077629);
		button_5.Size = new Size(114, 26);
		button_5.TabIndex = 1;
		button_5.Text = Class16.smethod_0(1649077642);
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridView_0.BackgroundColor = Color.FromArgb(32, 32, 32);
		dataGridView_0.BorderStyle = BorderStyle.None;
		dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewImageColumn_0, dataGridViewTextBoxColumn_1);
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(32, 32, 32);
		dataGridViewCellStyle.ForeColor = Color.White;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = Color.White;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.Dock = DockStyle.Fill;
		dataGridView_0.GridColor = Color.Silver;
		dataGridView_0.Location = new Point(3, 35);
		dataGridView_0.MultiSelect = true;
		dataGridView_0.Name = Class16.smethod_0(1649077657);
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.RowTemplate.Height = 28;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.Size = new Size(902, 352);
		dataGridView_0.TabIndex = 2;
		dataGridView_0.CellDoubleClick += dataGridView_0_CellDoubleClick;
		dataGridView_0.CellFormatting += dataGridView_0_CellFormatting;
		dataGridView_0.CellMouseEnter += dataGridView_0_CellMouseEnter;
		dataGridView_0.CellMouseLeave += dataGridView_1_CellMouseLeave;
		dataGridView_0.CellValueChanged += dataGridView_0_CellValueChanged;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649077675);
		dataGridViewTextBoxColumn_0.Width = 80;
		dataGridViewImageColumn_0.HeaderText = string.Empty;
		dataGridViewImageColumn_0.Name = Class16.smethod_0(1649077702);
		dataGridViewImageColumn_0.ReadOnly = true;
		dataGridViewImageColumn_0.Width = 28;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649077715);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		tableLayoutPanel_2.SetColumnSpan(flowLayoutPanel_1, 2);
		flowLayoutPanel_1.Controls.Add(button_6);
		flowLayoutPanel_1.Controls.Add(button_7);
		flowLayoutPanel_1.Controls.Add(button_8);
		flowLayoutPanel_1.Dock = DockStyle.Fill;
		flowLayoutPanel_1.Location = new Point(3, 393);
		flowLayoutPanel_1.Name = Class16.smethod_0(1649077736);
		flowLayoutPanel_1.Size = new Size(902, 28);
		flowLayoutPanel_1.TabIndex = 3;
		button_6.Size = new Size(80, 26);
		button_6.Text = Class16.smethod_0(1648931361);
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		button_7.Size = new Size(80, 26);
		button_7.Text = Class16.smethod_0(1648925718);
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		button_8.Size = new Size(80, 26);
		button_8.Text = Class16.smethod_0(1648928315);
		button_8.UseVisualStyleBackColor = true;
		button_8.Click += button_8_Click;
		tabPage_1.Controls.Add(tableLayoutPanel_3);
		tabPage_1.Location = new Point(4, 24);
		tabPage_1.Name = Class16.smethod_0(1649076736);
		tabPage_1.Padding = new Padding(3);
		tabPage_1.Size = new Size(914, 430);
		tabPage_1.TabIndex = 1;
		tabPage_1.Text = Class16.smethod_0(1648935628);
		tabPage_1.UseVisualStyleBackColor = true;
		tableLayoutPanel_3.ColumnCount = 2;
		tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120f));
		tableLayoutPanel_3.Controls.Add(textBox_3, 0, 0);
		tableLayoutPanel_3.Controls.Add(button_9, 1, 0);
		tableLayoutPanel_3.Controls.Add(dataGridView_1, 0, 1);
		tableLayoutPanel_3.Controls.Add(tableLayoutPanel_4, 0, 2);
		tableLayoutPanel_3.Dock = DockStyle.Fill;
		tableLayoutPanel_3.Location = new Point(3, 3);
		tableLayoutPanel_3.Name = Class16.smethod_0(1649076759);
		tableLayoutPanel_3.RowCount = 3;
		tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
		tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Absolute, 34f));
		tableLayoutPanel_3.Size = new Size(908, 424);
		tableLayoutPanel_3.TabIndex = 0;
		textBox_3.Dock = DockStyle.Fill;
		textBox_3.Location = new Point(3, 5);
		textBox_3.Margin = new Padding(3, 5, 3, 3);
		textBox_3.Name = Class16.smethod_0(1649076769);
		toolTip_0.SetToolTip(textBox_3, Class16.smethod_0(1649076797));
		textBox_3.Size = new Size(782, 23);
		textBox_3.TabIndex = 0;
		textBox_3.TextChanged += textBox_3_TextChanged;
		button_9.Dock = DockStyle.Fill;
		button_9.Location = new Point(791, 3);
		button_9.Name = Class16.smethod_0(1649076811);
		button_9.Size = new Size(114, 26);
		button_9.TabIndex = 1;
		button_9.Text = Class16.smethod_0(1649076837);
		button_9.UseVisualStyleBackColor = true;
		button_9.Click += button_9_Click;
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToDeleteRows = false;
		dataGridView_1.AllowUserToResizeRows = false;
		dataGridView_1.BackgroundColor = Color.FromArgb(32, 32, 32);
		dataGridView_1.BorderStyle = BorderStyle.None;
		dataGridView_1.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_1.Columns.AddRange(dataGridViewTextBoxColumn_2, dataGridViewImageColumn_1, dataGridViewTextBoxColumn_3, dataGridViewTextBoxColumn_4, dataGridViewTextBoxColumn_5);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(32, 32, 32);
		dataGridViewCellStyle2.ForeColor = Color.White;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = Color.White;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dataGridView_1.DefaultCellStyle = dataGridViewCellStyle2;
		dataGridView_1.Dock = DockStyle.Fill;
		dataGridView_1.GridColor = Color.Silver;
		dataGridView_1.Location = new Point(3, 35);
		dataGridView_1.MultiSelect = true;
		dataGridView_1.Name = Class16.smethod_0(1649076853);
		dataGridView_1.RowHeadersVisible = false;
		dataGridView_1.RowTemplate.Height = 28;
		dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_1.Size = new Size(902, 352);
		dataGridView_1.TabIndex = 2;
		dataGridView_1.CellDoubleClick += dataGridView_1_CellDoubleClick;
		dataGridView_1.CellFormatting += dataGridView_1_CellFormatting;
		dataGridView_1.CellMouseEnter += dataGridView_1_CellMouseEnter;
		dataGridView_1.CellMouseLeave += dataGridView_1_CellMouseLeave;
		dataGridView_1.CellPainting += dataGridView_1_CellPainting;
		dataGridView_1.CellValueChanged += dataGridView_1_CellValueChanged;
		dataGridView_1.ColumnHeaderMouseClick += dataGridView_1_ColumnHeaderMouseClick;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1649076868);
		dataGridViewTextBoxColumn_2.Width = 80;
		dataGridViewImageColumn_1.HeaderText = string.Empty;
		dataGridViewImageColumn_1.Name = Class16.smethod_0(1649076884);
		dataGridViewImageColumn_1.ReadOnly = true;
		dataGridViewImageColumn_1.Width = 28;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1648986725);
		dataGridViewTextBoxColumn_3.ReadOnly = true;
		dataGridViewTextBoxColumn_3.Width = 220;
		dataGridViewTextBoxColumn_4.HeaderText = Class16.smethod_0(1649076902);
		dataGridViewTextBoxColumn_4.Name = Class16.smethod_0(1649076924);
		dataGridViewTextBoxColumn_4.Width = 110;
		dataGridViewTextBoxColumn_5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_5.HeaderText = Class16.smethod_0(1649076942);
		dataGridViewTextBoxColumn_5.Name = Class16.smethod_0(1649076944);
		dataGridViewTextBoxColumn_5.ReadOnly = true;
		tableLayoutPanel_3.SetColumnSpan(tableLayoutPanel_4, 2);
		tableLayoutPanel_4.ColumnCount = 2;
		tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel_4.Controls.Add(flowLayoutPanel_2, 0, 0);
		tableLayoutPanel_4.Controls.Add(tableLayoutPanel_5, 1, 0);
		tableLayoutPanel_4.Dock = DockStyle.Fill;
		tableLayoutPanel_4.Location = new Point(3, 393);
		tableLayoutPanel_4.Margin = new Padding(3, 3, 3, 0);
		tableLayoutPanel_4.Name = Class16.smethod_0(1649076973);
		tableLayoutPanel_4.RowCount = 1;
		tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_4.Size = new Size(902, 31);
		tableLayoutPanel_4.TabIndex = 3;
		flowLayoutPanel_2.AutoSize = true;
		flowLayoutPanel_2.WrapContents = false;
		flowLayoutPanel_2.Controls.Add(button_10);
		flowLayoutPanel_2.Controls.Add(button_11);
		flowLayoutPanel_2.Controls.Add(button_12);
		flowLayoutPanel_2.Controls.Add(button_13);
		flowLayoutPanel_2.Controls.Add(button_14);
		flowLayoutPanel_2.Controls.Add(label_12);
		flowLayoutPanel_2.Dock = DockStyle.Fill;
		flowLayoutPanel_2.Location = new Point(0, 0);
		flowLayoutPanel_2.Name = Class16.smethod_0(1649076985);
		flowLayoutPanel_2.Size = new Size(510, 31);
		flowLayoutPanel_2.TabIndex = 0;
		tableLayoutPanel_5.ColumnCount = 3;
		tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130f));
		tableLayoutPanel_5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel_5.Controls.Add(label_11, 0, 0);
		tableLayoutPanel_5.Controls.Add(numericUpDown_8, 1, 0);
		tableLayoutPanel_5.Controls.Add(trackBar_0, 2, 0);
		tableLayoutPanel_5.Dock = DockStyle.Fill;
		tableLayoutPanel_5.Location = new Point(513, 0);
		tableLayoutPanel_5.Margin = new Padding(3, 0, 0, 0);
		tableLayoutPanel_5.Name = Class16.smethod_0(1649077014);
		tableLayoutPanel_5.RowCount = 1;
		tableLayoutPanel_5.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_5.Size = new Size(389, 31);
		tableLayoutPanel_5.TabIndex = 1;
		label_11.AutoSize = true;
		label_11.Dock = DockStyle.Fill;
		label_11.Location = new Point(3, 0);
		label_11.Name = Class16.smethod_0(1649077034);
		label_11.Size = new Size(77, 31);
		label_11.TabIndex = 0;
		label_11.Text = Class16.smethod_0(1649077068);
		label_11.TextAlign = ContentAlignment.MiddleRight;
		numericUpDown_8.DecimalPlaces = 6;
		numericUpDown_8.Dock = DockStyle.Fill;
		numericUpDown_8.Increment = 0.000001m;
		numericUpDown_8.Location = new Point(86, 4);
		numericUpDown_8.Margin = new Padding(3, 4, 3, 3);
		numericUpDown_8.Maximum = new decimal(new int[4] { 100, 0, 0, 0 });
		numericUpDown_8.Name = Class16.smethod_0(1649077086);
		numericUpDown_8.Size = new Size(124, 23);
		numericUpDown_8.TabIndex = 1;
		numericUpDown_8.TextAlign = HorizontalAlignment.Center;
		trackBar_0.AutoSize = false;
		trackBar_0.Dock = DockStyle.Fill;
		trackBar_0.Location = new Point(216, 3);
		trackBar_0.Margin = new Padding(3, 3, 3, 3);
		trackBar_0.Maximum = 1000000;
		trackBar_0.Name = Class16.smethod_0(1649077104);
		trackBar_0.Size = new Size(170, 25);
		trackBar_0.TabIndex = 2;
		trackBar_0.TickStyle = TickStyle.None;
		button_10.Size = new Size(80, 26);
		button_10.Text = Class16.smethod_0(1648931361);
		button_10.UseVisualStyleBackColor = true;
		button_10.Click += button_10_Click;
		button_11.Size = new Size(80, 26);
		button_11.Text = Class16.smethod_0(1648925718);
		button_11.UseVisualStyleBackColor = true;
		button_11.Click += button_11_Click;
		button_12.Size = new Size(80, 26);
		button_12.Text = Class16.smethod_0(1648928315);
		button_12.UseVisualStyleBackColor = true;
		button_12.Click += button_12_Click;
		button_13.Size = new Size(90, 26);
		button_13.Text = Class16.smethod_0(1649077130);
		button_13.UseVisualStyleBackColor = true;
		button_13.Click += button_13_Click;
		button_14.Size = new Size(90, 26);
		button_14.Text = Class16.smethod_0(1649077144);
		button_14.UseVisualStyleBackColor = true;
		button_14.Click += button_14_Click;
		label_12.AutoSize = true;
		label_12.Margin = new Padding(12, 6, 3, 3);
		label_12.Name = Class16.smethod_0(1649077160);
		label_12.Size = new Size(86, 15);
		label_12.TabIndex = 10;
		label_12.Text = Class16.smethod_0(1649077177);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(1200, 700);
		base.Controls.Add(tableLayoutPanel_0);
		base.Controls.Add(menuStrip_0);
		Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.Icon = Resources.edit;
		base.MainMenuStrip = menuStrip_0;
		MinimumSize = new Size(1000, 600);
		base.Name = Class16.smethod_0(1649077200);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649077230);
		base.FormClosing += ExtraDropEditor_FormClosing;
		base.Activated += ExtraDropEditor_Activated;
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		tableLayoutPanel_0.ResumeLayout(performLayout: false);
		panel_0.ResumeLayout(performLayout: false);
		panel_0.PerformLayout();
		flowLayoutPanel_0.ResumeLayout(performLayout: false);
		panel_1.ResumeLayout(performLayout: false);
		tabControl_0.ResumeLayout(performLayout: false);
		tabPage_0.ResumeLayout(performLayout: false);
		tableLayoutPanel_2.ResumeLayout(performLayout: false);
		tableLayoutPanel_2.PerformLayout();
		((ISupportInitialize)dataGridView_0).EndInit();
		flowLayoutPanel_1.ResumeLayout(performLayout: false);
		tabPage_1.ResumeLayout(performLayout: false);
		tableLayoutPanel_3.ResumeLayout(performLayout: false);
		tableLayoutPanel_3.PerformLayout();
		((ISupportInitialize)dataGridView_1).EndInit();
		flowLayoutPanel_2.ResumeLayout(performLayout: false);
		flowLayoutPanel_2.PerformLayout();
		tableLayoutPanel_5.ResumeLayout(performLayout: false);
		tableLayoutPanel_5.PerformLayout();
		((ISupportInitialize)numericUpDown_8).EndInit();
		((ISupportInitialize)trackBar_0).EndInit();
		tableLayoutPanel_4.ResumeLayout(performLayout: false);
		tableLayoutPanel_4.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		tableLayoutPanel_1.ResumeLayout(performLayout: false);
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		((ISupportInitialize)numericUpDown_2).EndInit();
		((ISupportInitialize)numericUpDown_3).EndInit();
		((ISupportInitialize)numericUpDown_4).EndInit();
		((ISupportInitialize)numericUpDown_5).EndInit();
		((ISupportInitialize)numericUpDown_6).EndInit();
		((ISupportInitialize)numericUpDown_7).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			icontainer_0?.Dispose();
		}
		base.Dispose(disposing);
	}

	private bool method_8(bool bool_6)
	{
		method_5();
		if (!AceNative.IsSuccess(AceNative.IsLicenseValid()))
		{
			return false;
		}
		try
		{
			if (bool_6 || string.IsNullOrWhiteSpace(extra_DROPS_0?.FileName))
			{
				using SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = Class16.smethod_0(1649076231);
				saveFileDialog.Title = TextStorage.Msg(Class16.smethod_0(1649076281));
				saveFileDialog.FileName = (string.IsNullOrWhiteSpace(extra_DROPS_0?.FileName) ? Class16.smethod_0(1648908903) : System.IO.Path.GetFileName(extra_DROPS_0.FileName));
				if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
				{
					return false;
				}
				extra_DROPS_0.FileName = saveFileDialog.FileName;
			}
			extraDropsDocument_0.ApplyTo(extra_DROPS_0);
			extra_DROPS_0.Save();
			TextStorage.TEXTS.ShowMessage(332, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			method_3(bool_6: false);
			return true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649076319));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649076346), Class16.smethod_0(1649010378)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return false;
		}
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		if (method_6())
		{
			DialogResult dialogResult = DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649076389)), TextStorage.Msg(Class16.smethod_0(1649076409)), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				string tempFileName = System.IO.Path.GetTempFileName();
				File.WriteAllBytes(tempFileName, new byte[8] { 1, 0, 0, 0, 0, 0, 0, 0 });
				extra_DROPS_0 = new EXTRA_DROPS(tempFileName);
				File.Delete(tempFileName);
				extra_DROPS_0.FileName = string.Empty;
				method_1();
				method_30();
			}
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		if (!method_6())
		{
			return;
		}
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649076231);
		openFileDialog.Title = TextStorage.Msg(Class16.smethod_0(1649076439));
		if (openFileDialog.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		try
		{
			extra_DROPS_0 = new EXTRA_DROPS(openFileDialog.FileName);
			if (!extra_DROPS_0.FileLoaded)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649076458)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			method_1();
			method_30();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649076319));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649076494), Class16.smethod_0(1649076522)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_8(bool_6: false);
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		method_8(bool_6: true);
	}

	private void ExtraDropEditor_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!method_6())
		{
			e.Cancel = true;
		}
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_2(method_0());
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (bool_0 || extraDropsDocument_0?.Groups == null)
		{
			return;
		}
		string value = (textBox_0.Text ?? string.Empty).Trim().ToLowerInvariant();
		if (string.IsNullOrEmpty(value))
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num >= extraDropsDocument_0.Groups.Count)
			{
				return;
			}
			ExtraDropGroupVm extraDropGroupVm = extraDropsDocument_0.Groups[num];
			object obj;
			if (extraDropGroupVm == null)
			{
				obj = null;
			}
			else
			{
				obj = extraDropGroupVm.Name;
				if (obj != null)
				{
					goto IL_0074;
				}
			}
			obj = string.Empty;
			goto IL_0074;
			IL_0074:
			string text = (string)obj;
			if (text.ToLowerInvariant().Contains(value))
			{
				break;
			}
			num++;
		}
		listBox_0.SelectedIndex = num;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (extraDropsDocument_0?.Groups != null)
		{
			method_26();
			ExtraDropGroupVm item = ExtraDropGroupVm.FromTable(EXTRADROPTABLE.CreateEmpty(Class16.smethod_0(1649076552)));
			extraDropsDocument_0.Groups.Add(item);
			listBox_0.SelectedIndex = extraDropsDocument_0.Groups.Count - 1;
			method_3(bool_6: true);
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (extraDropsDocument_0?.Groups != null)
		{
			method_26();
			int num = listBox_0.SelectedIndex;
			if (num < 0)
			{
				num = 0;
			}
			ExtraDropGroupVm item = ExtraDropGroupVm.FromTable(EXTRADROPTABLE.CreateEmpty(Class16.smethod_0(1649076552)));
			extraDropsDocument_0.Groups.Insert(num, item);
			listBox_0.SelectedIndex = num;
			method_3(bool_6: true);
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		if (extraDropsDocument_0?.Groups != null)
		{
			ExtraDropGroupVm extraDropGroupVm = method_0();
			if (extraDropGroupVm != null)
			{
				method_26();
				EXTRADROPTABLE eXTRADROPTABLE = extraDropGroupVm.ToTable();
				eXTRADROPTABLE.Name = extraDropGroupVm.Name + Class16.smethod_0(1649006882);
				ExtraDropGroupVm item = ExtraDropGroupVm.FromTable(eXTRADROPTABLE);
				extraDropsDocument_0.Groups.Add(item);
				listBox_0.SelectedIndex = extraDropsDocument_0.Groups.Count - 1;
				method_3(bool_6: true);
			}
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (extraDropsDocument_0?.Groups == null)
		{
			return;
		}
		int selectedIndex = listBox_0.SelectedIndex;
		if (selectedIndex < 0)
		{
			return;
		}
		DialogResult dialogResult = DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649076568), Class16.smethod_0(1649076606)), extraDropsDocument_0.Groups[selectedIndex]?.Name), Class16.smethod_0(1649076624), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		method_26();
		bool_0 = true;
		try
		{
			extraDropsDocument_0.Groups.RemoveAt(selectedIndex);
			listBox_0.DataSource = null;
			listBox_0.DataSource = extraDropsDocument_0.Groups;
			listBox_0.DisplayMember = Class16.smethod_0(1648936731);
			if (extraDropsDocument_0.Groups.Count > 0)
			{
				listBox_0.SelectedIndex = Math.Min(selectedIndex, extraDropsDocument_0.Groups.Count - 1);
			}
			else
			{
				method_2(null);
			}
		}
		finally
		{
			bool_0 = false;
		}
		method_2(method_0());
		method_3(bool_6: true);
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		method_28(textBox_1);
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm != null)
		{
			int selectionStart = textBox_1.SelectionStart;
			int selectionLength = textBox_1.SelectionLength;
			string text = textBox_1.Text ?? string.Empty;
			if (extraDropGroupVm.Name != text)
			{
				extraDropGroupVm.Name = text;
			}
			if (selectionStart <= textBox_1.TextLength)
			{
				textBox_1.SelectionStart = selectionStart;
				textBox_1.SelectionLength = selectionLength;
			}
		}
		method_3(bool_6: true);
	}

	private void method_9()
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm == null)
		{
			label_10.Text = TextStorage.Msg(Class16.smethod_0(1649076643));
			label_10.ForeColor = SystemColors.ControlText;
		}
		else
		{
			decimal dropSumPercent = extraDropGroupVm.DropSumPercent;
			label_10.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649076676), Class16.smethod_0(1649076689)), dropSumPercent);
			label_10.ForeColor = ((Math.Abs(dropSumPercent - 100m) <= 0.000001m) ? Color.DarkGreen : Color.Red);
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm != null)
		{
			method_26();
			bool_0 = true;
			extraDropGroupVm.NormalizeDropProbabilities();
			bool_0 = false;
			method_9();
			method_3(bool_6: true);
		}
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm != null)
		{
			method_26();
			extraDropGroupVm.Monsters.Add(new ExtraDropMonsterVm(0));
			method_3(bool_6: true);
		}
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm == null)
		{
			return;
		}
		method_26();
		List<int> list = new List<int>();
		foreach (DataGridViewRow selectedRow in dataGridView_0.SelectedRows)
		{
			if (selectedRow.Index >= 0)
			{
				list.Add(selectedRow.Index);
			}
		}
		list.Sort();
		list.Reverse();
		for (int i = 0; i < list.Count; i++)
		{
			int num = list[i];
			if (num >= 0 && num < extraDropGroupVm.Monsters.Count)
			{
				extraDropGroupVm.Monsters.RemoveAt(num);
			}
		}
		method_3(bool_6: true);
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm != null)
		{
			method_26();
			extraDropGroupVm.Monsters.Clear();
			method_3(bool_6: true);
		}
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm != null)
		{
			commonStorage_0.ResetBuffer();
			int num = eListCollection_0.get_LI(Class16.smethod_0(1648963546));
			itemsWindow_0.newitemlist = -1;
			itemsWindow_0.newitemindex = -1;
			itemsWindow_0.newlistsindices = new int[2]
			{
				num,
				eListCollection_0.get_LI(Class16.smethod_0(1648960167))
			};
			itemsWindow_0.bMultiSelect = false;
			if (itemsWindow_0.ShowDialog(this) == DialogResult.OK && CommonStorage.sData != null)
			{
				method_26();
				int id = Convert.ToInt32(CommonStorage.sData);
				extraDropGroupVm.Monsters.Add(new ExtraDropMonsterVm(id));
				method_3(bool_6: true);
			}
		}
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.RowIndex < 0 || e.ColumnIndex != dataGridViewTextBoxColumn_0.Index)
		{
			return;
		}
		method_28(dataGridView_0);
		if (dataGridView_0.Rows[e.RowIndex].DataBoundItem is ExtraDropMonsterVm extraDropMonsterVm)
		{
			string s = Convert.ToString(dataGridView_0[e.ColumnIndex, e.RowIndex].Value ?? Class16.smethod_0(1648924112));
			if (!int.TryParse(s, out var result) || result < 0)
			{
				result = 0;
			}
			if (extraDropMonsterVm.Id != result)
			{
				extraDropMonsterVm.Id = result;
			}
			dataGridView_0.InvalidateRow(e.RowIndex);
			method_3(bool_6: true);
		}
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && dataGridView_0.Rows[e.RowIndex].DataBoundItem is ExtraDropMonsterVm extraDropMonsterVm)
		{
			int num = eListCollection_0.get_LI(Class16.smethod_0(1648963546));
			commonStorage_0.ResetBuffer();
			ITEMPOS iTEMPOS = null;
			if (extraDropMonsterVm.Id > 0)
			{
				iTEMPOS = eListCollection_0.FindItemPos(num, extraDropMonsterVm.Id) ?? eListCollection_0.FindItemPos(eListCollection_0.get_LI(Class16.smethod_0(1648960167)), extraDropMonsterVm.Id);
			}
			if (iTEMPOS != null)
			{
				itemsWindow_0.newitemlist = iTEMPOS.int_0;
				itemsWindow_0.newitemindex = iTEMPOS.int_1;
			}
			else
			{
				itemsWindow_0.newitemlist = -1;
				itemsWindow_0.newitemindex = -1;
			}
			itemsWindow_0.newlistsindices = new int[2]
			{
				num,
				eListCollection_0.get_LI(Class16.smethod_0(1648960167))
			};
			itemsWindow_0.bMultiSelect = false;
			if (itemsWindow_0.ShowDialog(this) == DialogResult.OK && CommonStorage.sData != null)
			{
				method_26();
				int id = Convert.ToInt32(CommonStorage.sData);
				extraDropMonsterVm.Id = id;
				dataGridView_0.InvalidateRow(e.RowIndex);
				method_3(bool_6: true);
			}
		}
	}

	private void dataGridView_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (e.RowIndex >= 0 && dataGridView_0.Rows[e.RowIndex].DataBoundItem is ExtraDropMonsterVm { Id: var id })
		{
			if (!method_10(id, out var string_, out var image_, out var color_))
			{
				string_ = TextStorage.TEXTS.GetText(Class16.smethod_0(1648902988));
				image_ = ICONS.NopeIcon;
				color_ = Color.Red;
			}
			if (e.ColumnIndex == dataGridViewImageColumn_0.Index)
			{
				e.Value = image_;
				e.FormattingApplied = true;
			}
			else if (e.ColumnIndex == dataGridViewTextBoxColumn_1.Index)
			{
				e.Value = string_;
				e.CellStyle.ForeColor = color_;
				e.FormattingApplied = true;
			}
		}
	}

	private bool method_10(int int_1, out string string_0, out Image image_0, out Color color_0)
	{
		string_0 = string.Empty;
		image_0 = ICONS.NopeIcon;
		color_0 = Color.Red;
		if (int_1 > 0 && eListCollection_0 != null)
		{
			int num = eListCollection_0.get_LI(Class16.smethod_0(1648963546));
			ITEMPOS iTEMPOS = eListCollection_0.FindItemPos(num, int_1) ?? eListCollection_0.FindItemPos(eListCollection_0.get_LI(Class16.smethod_0(1648960167)), int_1);
			if (iTEMPOS == null)
			{
				return false;
			}
			ITEMINFO itemInfo = eListCollection_0.GetItemInfo(iTEMPOS, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
			if (itemInfo == null)
			{
				return false;
			}
			string_0 = itemInfo.name;
			image_0 = eListCollection_0.Icons.GetIcon(itemInfo.IconName, IsTga: false);
			color_0 = itemInfo.color;
			return true;
		}
		return false;
	}

	private void dataGridView_0_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && dataGridView_0.Rows[e.RowIndex].DataBoundItem is ExtraDropMonsterVm { Id: >0 } extraDropMonsterVm)
		{
			int num = eListCollection_0.get_LI(Class16.smethod_0(1648963546));
			ITEMPOS iTEMPOS = eListCollection_0.FindItemPos(num, extraDropMonsterVm.Id) ?? eListCollection_0.FindItemPos(eListCollection_0.get_LI(Class16.smethod_0(1648960167)), extraDropMonsterVm.Id);
			if (iTEMPOS != null)
			{
				itemsToolTip_0.ShowItemToolTip(dataGridView_0, iTEMPOS, IsShopPrice: false, bSmooth: true);
			}
		}
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm == null)
		{
			return;
		}
		if (extraDropGroupVm.Items.Count >= 256)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649076714)), TextStorage.Msg(Class16.smethod_0(1649071628)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		method_26();
		extraDropGroupVm.Items.Add(new ExtraDropItemVm(0, 0m));
		if (extraDropGroupVm.Items.Count > 0 && dataGridView_1.Rows.Count == extraDropGroupVm.Items.Count)
		{
			int num = extraDropGroupVm.Items.Count - 1;
			if (num >= 0 && num < dataGridView_1.Rows.Count)
			{
				dataGridView_1.CurrentCell = dataGridView_1[dataGridViewTextBoxColumn_4.Index, num];
				try
				{
					dataGridView_1.FirstDisplayedScrollingRowIndex = num;
				}
				catch
				{
				}
			}
		}
		method_17();
		method_12();
		method_3(bool_6: true);
	}

	private void button_11_Click(object sender, EventArgs e)
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm == null)
		{
			return;
		}
		method_26();
		List<int> list = smethod_2(dataGridView_1);
		for (int i = 0; i < list.Count; i++)
		{
			int num = list[i];
			if (num >= 0 && num < extraDropGroupVm.Items.Count)
			{
				extraDropGroupVm.Items.RemoveAt(num);
			}
		}
		method_17();
		method_12();
		method_3(bool_6: true);
	}

	private void button_12_Click(object sender, EventArgs e)
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm != null)
		{
			method_26();
			extraDropGroupVm.Items.Clear();
			method_17();
			method_12();
			method_3(bool_6: true);
		}
	}

	private void button_13_Click(object sender, EventArgs e)
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm != null)
		{
			method_26();
			for (int i = 0; i < extraDropGroupVm.Items.Count; i++)
			{
				extraDropGroupVm.Items[i].ProbabilityPercent = 0m;
			}
			dataGridView_1.Invalidate();
			method_17();
			method_12();
			method_3(bool_6: true);
		}
	}

	private void button_14_Click(object sender, EventArgs e)
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm != null)
		{
			method_26();
			extraDropGroupVm.NormalizeItemProbabilities();
			bindingSource_1.ResetBindings(metadataChanged: false);
			dataGridView_1.Invalidate();
			dataGridView_1.Refresh();
			method_17();
			method_12();
			method_3(bool_6: true);
		}
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm == null)
		{
			return;
		}
		commonStorage_0.ResetBuffer();
		itemsWindow_0.newitemlist = -1;
		itemsWindow_0.newitemindex = -1;
		itemsWindow_0.newlistsindices = eListCollection_0.MattersLists;
		itemsWindow_0.bMultiSelect = false;
		if (itemsWindow_0.ShowDialog(this) != DialogResult.OK || CommonStorage.sData == null)
		{
			return;
		}
		int id = Convert.ToInt32(CommonStorage.sData);
		if (extraDropGroupVm.Items.Count >= 256)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649076714)), Class16.smethod_0(1649071647), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		method_26();
		extraDropGroupVm.Items.Add(new ExtraDropItemVm(id, 0m));
		if (extraDropGroupVm.Items.Count > 0 && dataGridView_1.Rows.Count == extraDropGroupVm.Items.Count)
		{
			int num = extraDropGroupVm.Items.Count - 1;
			if (num >= 0 && num < dataGridView_1.Rows.Count)
			{
				dataGridView_1.CurrentCell = dataGridView_1[dataGridViewTextBoxColumn_4.Index, num];
				try
				{
					dataGridView_1.FirstDisplayedScrollingRowIndex = num;
				}
				catch
				{
				}
			}
		}
		method_17();
		method_12();
		method_3(bool_6: true);
	}

	private void dataGridView_1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.RowIndex < 0)
		{
			return;
		}
		method_28(dataGridView_1);
		if (!(dataGridView_1.Rows[e.RowIndex].DataBoundItem is ExtraDropItemVm extraDropItemVm))
		{
			return;
		}
		if (e.ColumnIndex == dataGridViewTextBoxColumn_2.Index)
		{
			string s = Convert.ToString(dataGridView_1[e.ColumnIndex, e.RowIndex].Value ?? Class16.smethod_0(1648924112));
			if (!int.TryParse(s, out var result) || result < 0)
			{
				result = 0;
			}
			extraDropItemVm.Id = result;
			dataGridView_1.InvalidateRow(e.RowIndex);
			method_3(bool_6: true);
		}
		else if (e.ColumnIndex == dataGridViewTextBoxColumn_4.Index)
		{
			string text = Convert.ToString(dataGridView_1[e.ColumnIndex, e.RowIndex].Value ?? Class16.smethod_0(1648924112));
			text = text.Replace(Class16.smethod_0(1648923229), string.Empty).Trim();
			if (!decimal.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out var result2) && !decimal.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out result2))
			{
				result2 = default(decimal);
			}
			extraDropItemVm.ProbabilityPercent = result2;
			dataGridView_1.InvalidateRow(e.RowIndex);
			method_17();
			method_12();
			method_3(bool_6: true);
		}
	}

	private void dataGridView_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex < 0)
		{
			return;
		}
		if (e.ColumnIndex != dataGridViewTextBoxColumn_4.Index && e.ColumnIndex != dataGridViewTextBoxColumn_5.Index)
		{
			if (e.ColumnIndex != dataGridViewTextBoxColumn_4.Index && e.ColumnIndex != dataGridViewTextBoxColumn_5.Index)
			{
				if (dataGridView_1.Rows[e.RowIndex].DataBoundItem is ExtraDropItemVm extraDropItemVm)
				{
					commonStorage_0.ResetBuffer();
					ITEMPOS iTEMPOS = null;
					if (extraDropItemVm.Id > 0)
					{
						iTEMPOS = eListCollection_0.FindItemPos(eListCollection_0.MattersLists, extraDropItemVm.Id);
					}
					if (iTEMPOS != null)
					{
						itemsWindow_0.newitemlist = iTEMPOS.int_0;
						itemsWindow_0.newitemindex = iTEMPOS.int_1;
					}
					else
					{
						itemsWindow_0.newitemlist = -1;
						itemsWindow_0.newitemindex = -1;
					}
					itemsWindow_0.newlistsindices = eListCollection_0.MattersLists;
					itemsWindow_0.bMultiSelect = false;
					if (itemsWindow_0.ShowDialog(this) == DialogResult.OK && CommonStorage.sData != null)
					{
						method_26();
						int id = Convert.ToInt32(CommonStorage.sData);
						extraDropItemVm.Id = id;
						dataGridView_1.InvalidateRow(e.RowIndex);
						method_3(bool_6: true);
					}
				}
			}
			else
			{
				dataGridView_1.CurrentCell = dataGridView_1[dataGridViewTextBoxColumn_4.Index, e.RowIndex];
				dataGridView_1.BeginEdit(selectAll: true);
			}
		}
		else
		{
			dataGridView_1.CurrentCell = dataGridView_1[dataGridViewTextBoxColumn_4.Index, e.RowIndex];
			dataGridView_1.BeginEdit(selectAll: true);
		}
	}

	private void dataGridView_1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (e.RowIndex >= 0 && dataGridView_1.Rows[e.RowIndex].DataBoundItem is ExtraDropItemVm { Id: var id })
		{
			if (!method_14(id, out var string_, out var image_, out var color_))
			{
				string_ = TextStorage.TEXTS.GetText(Class16.smethod_0(1648902988));
				image_ = ICONS.NopeIcon;
				color_ = Color.Red;
			}
			if (e.ColumnIndex == dataGridViewImageColumn_1.Index)
			{
				e.Value = image_;
				e.FormattingApplied = true;
			}
			else if (e.ColumnIndex == dataGridViewTextBoxColumn_3.Index)
			{
				e.Value = string_;
				e.CellStyle.ForeColor = color_;
				e.FormattingApplied = true;
			}
		}
	}

	private void dataGridView_1_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridViewTextBoxColumn_4.Index || e.ColumnIndex == dataGridViewTextBoxColumn_2.Index || e.ColumnIndex == dataGridViewTextBoxColumn_5.Index))
		{
			int columnIndex = ((e.ColumnIndex == dataGridViewTextBoxColumn_5.Index) ? dataGridViewTextBoxColumn_4.Index : e.ColumnIndex);
			dataGridView_1.CurrentCell = dataGridView_1[columnIndex, e.RowIndex];
			dataGridView_1.BeginEdit(selectAll: true);
		}
	}

	private void dataGridView_1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			dataGridView_1.InvalidateRow(e.RowIndex);
			method_17();
		}
	}

	private void dataGridView_1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewTextBoxColumn_5.Index && e.Button == MouseButtons.Left)
		{
			method_27(trackBar_0);
			method_28(trackBar_0);
			bool_2 = true;
			int_0 = e.RowIndex;
			method_11(e.RowIndex, e.X);
		}
	}

	private void dataGridView_1_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_2 && int_0 >= 0 && int_0 < dataGridView_1.Rows.Count)
		{
			Rectangle cellDisplayRectangle = dataGridView_1.GetCellDisplayRectangle(dataGridViewTextBoxColumn_5.Index, int_0, cutOverflow: false);
			if (cellDisplayRectangle.Width > 0 && cellDisplayRectangle.Height > 0)
			{
				int int_ = e.X - cellDisplayRectangle.X;
				method_11(int_0, int_);
			}
		}
	}

	private void dataGridView_1_MouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			bool_2 = false;
			int_0 = -1;
		}
	}

	private void dataGridView_1_MouseLeave(object sender, EventArgs e)
	{
		bool_2 = false;
		int_0 = -1;
	}

	private void method_11(int int_1, int int_2)
	{
		if (int_1 < 0 || int_1 >= dataGridView_1.Rows.Count || !(dataGridView_1.Rows[int_1].DataBoundItem is ExtraDropItemVm extraDropItemVm))
		{
			return;
		}
		Rectangle cellDisplayRectangle = dataGridView_1.GetCellDisplayRectangle(dataGridViewTextBoxColumn_5.Index, int_1, cutOverflow: false);
		Rectangle rectangle = new Rectangle(0, 0, cellDisplayRectangle.Width, cellDisplayRectangle.Height);
		rectangle.Inflate(-4, -8);
		if (rectangle.Width > 0)
		{
			decimal num = 100m * (decimal)(int_2 - rectangle.X) / (decimal)rectangle.Width;
			if (num < 0m)
			{
				num = default(decimal);
			}
			if (num > 100m)
			{
				num = 100m;
			}
			num = Math.Round(num, 6, MidpointRounding.AwayFromZero);
			extraDropItemVm.ProbabilityPercent = num;
			if (int_1 < dataGridView_1.Rows.Count)
			{
				dataGridView_1.CurrentCell = dataGridView_1[dataGridViewTextBoxColumn_4.Index, int_1];
			}
			dataGridView_1.InvalidateRow(int_1);
			method_17();
			method_12();
			method_3(bool_6: true);
		}
	}

	private void dataGridView_1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		Class133 @class = new Class133();
		if (dataGridView_1.CurrentCell != null && dataGridView_1.CurrentCell.ColumnIndex == dataGridViewTextBoxColumn_4.Index)
		{
			Control control = e.Control;
			@class.textBox_0 = control as TextBox;
			if (@class.textBox_0 != null)
			{
				BeginInvoke(new Action(@class.method_0));
			}
		}
	}

	private void dataGridView_1_SelectionChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_12();
		}
	}

	private void numericUpDown_8_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0 || bool_3)
		{
			return;
		}
		method_28(numericUpDown_8);
		if (method_13(out var extraDropItemVm_, out var int_))
		{
			decimal decimal_ = (extraDropItemVm_.ProbabilityPercent = numericUpDown_8.Value);
			bool_3 = true;
			try
			{
				trackBar_0.Value = smethod_0(decimal_);
			}
			finally
			{
				bool_3 = false;
			}
			dataGridView_1.InvalidateRow(int_);
			method_17();
			method_3(bool_6: true);
		}
	}

	private void trackBar_0_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0 || bool_3)
		{
			return;
		}
		method_28(trackBar_0);
		if (!method_13(out var extraDropItemVm_, out var int_))
		{
			return;
		}
		decimal num = (extraDropItemVm_.ProbabilityPercent = smethod_1(trackBar_0.Value));
		bool_3 = true;
		try
		{
			decimal num3 = num;
			if (num3 < numericUpDown_8.Minimum)
			{
				num3 = numericUpDown_8.Minimum;
			}
			if (num3 > numericUpDown_8.Maximum)
			{
				num3 = numericUpDown_8.Maximum;
			}
			numericUpDown_8.Value = num3;
		}
		finally
		{
			bool_3 = false;
		}
		dataGridView_1.InvalidateRow(int_);
		method_17();
		method_3(bool_6: true);
	}

	private void method_12()
	{
		if (!method_13(out var extraDropItemVm_, out var _))
		{
			bool_3 = true;
			try
			{
				numericUpDown_8.Enabled = false;
				trackBar_0.Enabled = false;
				numericUpDown_8.Value = numericUpDown_8.Minimum;
				trackBar_0.Value = trackBar_0.Minimum;
				return;
			}
			finally
			{
				bool_3 = false;
			}
		}
		decimal num = extraDropItemVm_.ProbabilityPercent;
		if (num < 0m)
		{
			num = default(decimal);
		}
		if (num > 100m)
		{
			num = 100m;
		}
		bool_3 = true;
		try
		{
			numericUpDown_8.Enabled = true;
			trackBar_0.Enabled = true;
			decimal num2 = num;
			if (num2 < numericUpDown_8.Minimum)
			{
				num2 = numericUpDown_8.Minimum;
			}
			if (num2 > numericUpDown_8.Maximum)
			{
				num2 = numericUpDown_8.Maximum;
			}
			numericUpDown_8.Value = num2;
			trackBar_0.Value = smethod_0(num);
		}
		finally
		{
			bool_3 = false;
		}
	}

	private bool method_13(out ExtraDropItemVm extraDropItemVm_0, out int int_1)
	{
		extraDropItemVm_0 = null;
		int_1 = -1;
		if (dataGridView_1 != null && dataGridView_1.Rows.Count != 0)
		{
			int num = -1;
			if (dataGridView_1.CurrentCell != null)
			{
				num = dataGridView_1.CurrentCell.RowIndex;
			}
			else if (dataGridView_1.SelectedCells.Count > 0)
			{
				num = dataGridView_1.SelectedCells[0].RowIndex;
			}
			else if (dataGridView_1.SelectedRows.Count > 0)
			{
				num = dataGridView_1.SelectedRows[0].Index;
			}
			if (num >= 0 && num < dataGridView_1.Rows.Count)
			{
				extraDropItemVm_0 = dataGridView_1.Rows[num].DataBoundItem as ExtraDropItemVm;
				if (extraDropItemVm_0 == null)
				{
					return false;
				}
				int_1 = num;
				return true;
			}
			return false;
		}
		return false;
	}

	private static int smethod_0(decimal decimal_0)
	{
		if (decimal_0 < 0m)
		{
			decimal_0 = default(decimal);
		}
		if (decimal_0 > 100m)
		{
			decimal_0 = 100m;
		}
		int num = (int)Math.Round(decimal_0 * 10000m, MidpointRounding.AwayFromZero);
		if (num < 0)
		{
			num = 0;
		}
		if (num > 1000000)
		{
			num = 1000000;
		}
		return num;
	}

	private static decimal smethod_1(int int_1)
	{
		if (int_1 < 0)
		{
			int_1 = 0;
		}
		if (int_1 > 1000000)
		{
			int_1 = 1000000;
		}
		return (decimal)int_1 / 10000m;
	}

	private bool method_14(int int_1, out string string_0, out Image image_0, out Color color_0)
	{
		string_0 = string.Empty;
		image_0 = ICONS.NopeIcon;
		color_0 = Color.Red;
		if (int_1 > 0 && eListCollection_0 != null)
		{
			ITEMPOS iTEMPOS = eListCollection_0.FindMatter(int_1.ToString());
			if (iTEMPOS == null)
			{
				return false;
			}
			ITEMINFO itemInfo = eListCollection_0.GetItemInfo(iTEMPOS, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
			if (itemInfo == null)
			{
				return false;
			}
			string_0 = itemInfo.name;
			image_0 = eListCollection_0.Icons.GetIcon(itemInfo.IconName, IsTga: false);
			color_0 = itemInfo.color;
			return true;
		}
		return false;
	}

	private void dataGridView_1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
	{
		if (e.RowIndex < 0 || e.ColumnIndex != dataGridViewTextBoxColumn_5.Index)
		{
			return;
		}
		e.Handled = true;
		e.PaintBackground(e.CellBounds, cellsPaintSelectionBackground: true);
		decimal num = ((dataGridView_1.Rows[e.RowIndex].DataBoundItem is ExtraDropItemVm extraDropItemVm) ? extraDropItemVm.ProbabilityPercent : 0m);
		if (num < 0m)
		{
			num = default(decimal);
		}
		if (num > 100m)
		{
			num = 100m;
		}
		Rectangle cellBounds = e.CellBounds;
		cellBounds.Inflate(-4, -8);
		if (cellBounds.Width <= 0 || cellBounds.Height <= 0)
		{
			return;
		}
		Brush brush = new SolidBrush(Color.FromArgb(60, 60, 60));
		try
		{
			e.Graphics.FillRectangle(brush, cellBounds);
		}
		finally
		{
			((IDisposable)brush).Dispose();
		}
		int num2 = (int)Math.Round((double)((decimal)cellBounds.Width * (num / 100m)));
		if (num2 > 0)
		{
			Rectangle rect = new Rectangle(cellBounds.X, cellBounds.Y, num2, cellBounds.Height);
			Brush brush2 = new SolidBrush(Color.FromArgb(80, 200, 120));
			try
			{
				e.Graphics.FillRectangle(brush2, rect);
			}
			finally
			{
				((IDisposable)brush2).Dispose();
			}
		}
		Pen pen = new Pen(Color.FromArgb(120, 120, 120));
		try
		{
			e.Graphics.DrawRectangle(pen, cellBounds);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	private void dataGridView_1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex != dataGridViewTextBoxColumn_4.Index && e.ColumnIndex != dataGridViewTextBoxColumn_5.Index)
		{
			return;
		}
		ExtraDropGroupVm extraDropGroupVm = method_0();
		if (extraDropGroupVm != null)
		{
			method_26();
			List<ExtraDropItemVm> list = extraDropGroupVm.Items.OrderByDescending(Class136.class136_0.method_0).ToList();
			bool_0 = true;
			extraDropGroupVm.Items.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				extraDropGroupVm.Items.Add(list[i]);
			}
			bool_0 = false;
			bindingSource_1.ResetBindings(metadataChanged: false);
			dataGridView_1.Invalidate();
			dataGridView_1.Refresh();
			method_3(bool_6: true);
		}
	}

	private void dataGridView_1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && dataGridView_1.Rows[e.RowIndex].DataBoundItem is ExtraDropItemVm { Id: >0 } extraDropItemVm)
		{
			ITEMPOS iTEMPOS = eListCollection_0.FindMatter(extraDropItemVm.Id.ToString());
			if (iTEMPOS != null)
			{
				itemsToolTip_0.ShowItemToolTip(dataGridView_1, iTEMPOS, IsShopPrice: false, bSmooth: true);
			}
		}
	}

	private void dataGridView_1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		itemsToolTip_0?.Hide();
	}

	private void textBox_2_TextChanged(object sender, EventArgs e)
	{
		method_15(textBox_2.Text);
	}

	private void method_15(string string_0)
	{
		string_0 = (string_0 ?? string.Empty).Trim().ToLowerInvariant();
		for (int i = 0; i < dataGridView_0.Rows.Count; i++)
		{
			DataGridViewRow dataGridViewRow = dataGridView_0.Rows[i];
			ExtraDropMonsterVm extraDropMonsterVm = dataGridViewRow.DataBoundItem as ExtraDropMonsterVm;
			string text = string.Empty;
			if (extraDropMonsterVm != null && method_10(extraDropMonsterVm.Id, out var string_1, out var _, out var _))
			{
				text = string_1;
			}
			bool flag = (dataGridViewRow.Visible = string.IsNullOrEmpty(string_0) || (extraDropMonsterVm != null && extraDropMonsterVm.Id.ToString().Contains(string_0)) || text.ToLowerInvariant().Contains(string_0));
			dataGridViewRow.DefaultCellStyle.BackColor = (flag ? Color.FromArgb(32, 32, 32) : Color.FromArgb(32, 32, 32));
		}
		dataGridView_0.Invalidate();
		dataGridView_0.Refresh();
	}

	private void textBox_3_TextChanged(object sender, EventArgs e)
	{
		method_16(textBox_3.Text);
	}

	private void method_16(string string_0)
	{
		string_0 = (string_0 ?? string.Empty).Trim().ToLowerInvariant();
		for (int i = 0; i < dataGridView_1.Rows.Count; i++)
		{
			DataGridViewRow dataGridViewRow = dataGridView_1.Rows[i];
			ExtraDropItemVm extraDropItemVm = dataGridViewRow.DataBoundItem as ExtraDropItemVm;
			string text = string.Empty;
			if (extraDropItemVm != null && method_14(extraDropItemVm.Id, out var string_1, out var _, out var _))
			{
				text = string_1;
			}
			bool visible = string.IsNullOrEmpty(string_0) || (extraDropItemVm != null && extraDropItemVm.Id.ToString().Contains(string_0)) || text.ToLowerInvariant().Contains(string_0);
			dataGridViewRow.Visible = visible;
		}
		dataGridView_1.Invalidate();
		dataGridView_1.Refresh();
	}

	private void method_17()
	{
		decimal num = method_0()?.ItemsSumPercent ?? 0m;
		label_12.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649071651), Class16.smethod_0(1649071674)), num);
		label_12.ForeColor = ((Math.Abs(num - 100m) <= 0.000001m) ? Color.DarkGreen : Color.Red);
	}

	private static List<int> smethod_2(DataGridView dataGridView_2)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (DataGridViewRow selectedRow in dataGridView_2.SelectedRows)
		{
			if (selectedRow.Index >= 0)
			{
				hashSet.Add(selectedRow.Index);
			}
		}
		foreach (DataGridViewCell selectedCell in dataGridView_2.SelectedCells)
		{
			if (selectedCell.RowIndex >= 0)
			{
				hashSet.Add(selectedCell.RowIndex);
			}
		}
		if (dataGridView_2.CurrentCell != null && dataGridView_2.CurrentCell.RowIndex >= 0)
		{
			hashSet.Add(dataGridView_2.CurrentCell.RowIndex);
		}
		List<int> list = hashSet.ToList();
		list.Sort();
		list.Reverse();
		return list;
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_28(comboBox_0);
			method_3(bool_6: true);
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_28(sender as Control);
			method_9();
			method_3(bool_6: true);
		}
	}

	private void method_19()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1649071707), 100);
		fileBasedUndoManager_0.SetStateChangedCallback(method_31);
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_24, method_25);
		method_20();
		method_21();
	}

	private void method_20()
	{
		button_15 = new Button
		{
			Name = Class16.smethod_0(1649071732),
			Text = string.Empty,
			Enabled = false,
			Size = new Size(28, 24),
			Image = Resources.GShopEditor_PW_mbUndo,
			ImageAlign = ContentAlignment.MiddleCenter,
			FlatStyle = FlatStyle.Standard,
			UseVisualStyleBackColor = true,
			Parent = groupBox_0
		};
		button_16 = new Button
		{
			Name = Class16.smethod_0(1649071745),
			Text = string.Empty,
			Enabled = false,
			Size = new Size(28, 24),
			Image = Resources.GShopEditor_PW_mbRedo,
			ImageAlign = ContentAlignment.MiddleCenter,
			FlatStyle = FlatStyle.Standard,
			UseVisualStyleBackColor = true,
			Parent = groupBox_0
		};
		button_15.Click += button_15_Click;
		button_16.Click += button_16_Click;
		groupBox_0.Resize += groupBox_0_Resize;
		method_23();
	}

	private void method_21()
	{
		method_22(textBox_1);
		method_22(comboBox_0);
		method_22(numericUpDown_0);
		method_22(numericUpDown_1);
		method_22(numericUpDown_2);
		method_22(numericUpDown_3);
		method_22(numericUpDown_4);
		method_22(numericUpDown_5);
		method_22(numericUpDown_6);
		method_22(numericUpDown_7);
		method_22(numericUpDown_8);
		method_22(trackBar_0);
		dataGridView_0.CellBeginEdit += dataGridView_0_CellBeginEdit;
		dataGridView_1.CellBeginEdit += dataGridView_1_CellBeginEdit;
		dataGridView_1.CellEndEdit += dataGridView_1_CellEndEdit_1;
		dataGridView_0.CurrentCellChanged += dataGridView_0_CurrentCellChanged;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged_1;
		tabControl_0.SelectedIndexChanged += tabControl_0_SelectedIndexChanged;
		dataGridView_1.MouseDown += dataGridView_1_MouseDown;
	}

	private void method_22(Control control_1)
	{
		Class135 @class = new Class135();
		@class.extraDropEditor_0 = this;
		@class.control_0 = control_1;
		if (@class.control_0 != null)
		{
			@class.control_0.Enter += @class.method_0;
			@class.control_0.Leave += @class.method_1;
		}
	}

	private void method_23()
	{
		if (button_15 != null && button_16 != null)
		{
			int num = groupBox_0.ClientSize.Width - 10;
			comboBox_0.SetBounds(num - 210, 21, 210, comboBox_0.Height);
			label_1.SetBounds(comboBox_0.Left - 42, label_1.Top, 38, label_1.Height);
			button_16.SetBounds(label_1.Left - 6 - 28, 21, 28, comboBox_0.Height);
			button_15.SetBounds(button_16.Left - 6 - 28, 21, 28, comboBox_0.Height);
			textBox_1.Width = Math.Max(140, button_15.Left - textBox_1.Left - 6);
		}
	}

	private byte[] method_24()
	{
		if (extraDropsDocument_0 == null)
		{
			return null;
		}
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					EXTRA_DROPS eXTRA_DROPS = extra_DROPS_0;
					object obj;
					if (eXTRA_DROPS == null)
					{
						obj = null;
					}
					else
					{
						obj = eXTRA_DROPS.FileName;
						if (obj != null)
						{
							goto IL_0034;
						}
					}
					obj = string.Empty;
					goto IL_0034;
					IL_0034:
					binaryWriter.Write((string)obj);
					binaryWriter.Write(bool_1);
					binaryWriter.Write(listBox_0.SelectedIndex);
					binaryWriter.Write(tabControl_0.SelectedIndex);
					int[] array = smethod_3(dataGridView_0);
					binaryWriter.Write(array.Length);
					int[] array2 = array;
					foreach (int value in array2)
					{
						binaryWriter.Write(value);
					}
					int[] array3 = smethod_3(dataGridView_1);
					binaryWriter.Write(array3.Length);
					int[] array4 = array3;
					foreach (int value2 in array4)
					{
						binaryWriter.Write(value2);
					}
					binaryWriter.Write(dataGridView_0.CurrentCell?.RowIndex ?? (-1));
					binaryWriter.Write(dataGridView_1.CurrentCell?.RowIndex ?? (-1));
					List<EXTRADROPTABLE> list = extraDropsDocument_0.Groups.Select(Class136.class136_0.method_1).ToList();
					binaryWriter.Write(list.Count);
					foreach (EXTRADROPTABLE item in list)
					{
						if (item != null)
						{
							binaryWriter.Write(value: true);
							item.Save(binaryWriter);
						}
						else
						{
							binaryWriter.Write(value: false);
						}
					}
					binaryWriter.Flush();
					return memoryStream.ToArray();
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		catch
		{
			return null;
		}
	}

	private void method_25(byte[] byte_1)
	{
		if (byte_1 == null || byte_1.Length == 0)
		{
			return;
		}
		bool_4 = true;
		bool_0 = true;
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_1);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					string fileName = binaryReader.ReadString();
					bool bool_ = binaryReader.ReadBoolean();
					int int_ = binaryReader.ReadInt32();
					int int_2 = binaryReader.ReadInt32();
					int num = binaryReader.ReadInt32();
					int[] array = new int[num];
					for (int i = 0; i < num; i++)
					{
						array[i] = binaryReader.ReadInt32();
					}
					int num2 = binaryReader.ReadInt32();
					int[] array2 = new int[num2];
					for (int j = 0; j < num2; j++)
					{
						array2[j] = binaryReader.ReadInt32();
					}
					int int_3 = binaryReader.ReadInt32();
					int int_4 = binaryReader.ReadInt32();
					int num3 = binaryReader.ReadInt32();
					List<EXTRADROPTABLE> list = new List<EXTRADROPTABLE>(num3);
					for (int k = 0; k < num3; k++)
					{
						bool flag = binaryReader.ReadBoolean();
						list.Add(flag ? new EXTRADROPTABLE(binaryReader) : null);
					}
					if (extra_DROPS_0 != null)
					{
						extra_DROPS_0.FileName = fileName;
					}
					extraDropsDocument_0 = new ExtraDropsDocument(list.Select(ExtraDropGroupVm.FromTable));
					listBox_0.DataSource = null;
					listBox_0.DataSource = extraDropsDocument_0.Groups;
					listBox_0.DisplayMember = Class16.smethod_0(1648936731);
					int num4 = method_32(int_);
					if (num4 >= 0)
					{
						listBox_0.SelectedIndex = num4;
					}
					else
					{
						method_2(null);
					}
					tabControl_0.SelectedIndex = method_33(int_2);
					bool_0 = false;
					method_2(method_0());
					smethod_4(dataGridView_0, array, int_3);
					smethod_4(dataGridView_1, array2, int_4);
					method_3(bool_);
					method_12();
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		finally
		{
			bool_0 = false;
			bool_4 = false;
			method_29();
		}
	}

	private void method_26()
	{
		if (!bool_4)
		{
			method_29();
			byte[] array = method_24();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
		}
	}

	private void method_27(Control control_1)
	{
		if (!bool_4 && !bool_0 && control_1 != null && control_0 != control_1)
		{
			control_0 = control_1;
			byte_0 = method_24();
			bool_5 = false;
		}
	}

	private void method_28(Control control_1)
	{
		if (!bool_4 && !bool_0 && control_1 != null)
		{
			if (control_0 != control_1)
			{
				method_27(control_1);
			}
			if (!bool_5 && byte_0 != null)
			{
				fileBasedUndoManager_0?.PushUndo(byte_0);
				bool_5 = true;
			}
		}
	}

	private void method_29()
	{
		control_0 = null;
		byte_0 = null;
		bool_5 = false;
	}

	private void method_30()
	{
		method_29();
		fileBasedUndoManager_0?.Clear();
	}

	private void method_31()
	{
		if (button_15 != null)
		{
			button_15.Enabled = fileBasedUndoManager_0?.CanUndo ?? false;
		}
		if (button_16 != null)
		{
			button_16.Enabled = fileBasedUndoManager_0?.CanRedo ?? false;
		}
	}

	private static int[] smethod_3(DataGridView dataGridView_2)
	{
		if (dataGridView_2 == null)
		{
			return Array.Empty<int>();
		}
		HashSet<int> hashSet = new HashSet<int>();
		foreach (DataGridViewRow selectedRow in dataGridView_2.SelectedRows)
		{
			if (selectedRow.Index >= 0)
			{
				hashSet.Add(selectedRow.Index);
			}
		}
		foreach (DataGridViewCell selectedCell in dataGridView_2.SelectedCells)
		{
			if (selectedCell.RowIndex >= 0)
			{
				hashSet.Add(selectedCell.RowIndex);
			}
		}
		return hashSet.OrderBy(Class136.class136_0.method_2).ToArray();
	}

	private static void smethod_4(DataGridView dataGridView_2, int[] int_1, int int_2)
	{
		if (dataGridView_2 == null || dataGridView_2.Rows.Count == 0)
		{
			return;
		}
		dataGridView_2.ClearSelection();
		int[] array = int_1 ?? Array.Empty<int>();
		foreach (int num in array)
		{
			if (num >= 0 && num < dataGridView_2.Rows.Count)
			{
				dataGridView_2.Rows[num].Selected = true;
			}
		}
		if (int_2 >= 0 && int_2 < dataGridView_2.Rows.Count && dataGridView_2.ColumnCount > 0)
		{
			dataGridView_2.CurrentCell = dataGridView_2[0, int_2];
			dataGridView_2.Rows[int_2].Selected = true;
		}
		else if (dataGridView_2.Rows.Count > 0 && dataGridView_2.ColumnCount > 0)
		{
			dataGridView_2.CurrentCell = dataGridView_2[0, 0];
		}
	}

	private int method_32(int int_1)
	{
		if (extraDropsDocument_0?.Groups != null && extraDropsDocument_0.Groups.Count != 0)
		{
			if (int_1 < 0)
			{
				return 0;
			}
			return Math.Min(int_1, extraDropsDocument_0.Groups.Count - 1);
		}
		return -1;
	}

	private int method_33(int int_1)
	{
		if (tabControl_0.TabPages.Count == 0)
		{
			return 0;
		}
		if (int_1 < 0)
		{
			return 0;
		}
		return Math.Min(int_1, tabControl_0.TabPages.Count - 1);
	}

	private void ExtraDropEditor_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_ExtraDropEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_ExtraDropEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void button_15_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_24();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_25(array);
		}
	}

	private void button_16_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_24();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_25(array);
		}
	}

	private void groupBox_0_Resize(object sender, EventArgs e)
	{
		method_23();
	}

	private void dataGridView_0_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
		method_27(dataGridView_0);
	}

	private void dataGridView_1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
		method_27(dataGridView_1);
	}

	private void dataGridView_1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
	{
		method_29();
	}

	private void dataGridView_0_CurrentCellChanged(object sender, EventArgs e)
	{
		if (!dataGridView_0.IsCurrentCellInEditMode)
		{
			method_29();
		}
	}

	private void listBox_0_SelectedIndexChanged_1(object sender, EventArgs e)
	{
		method_29();
	}

	private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_29();
	}

	private void dataGridView_1_MouseDown(object sender, MouseEventArgs e)
	{
		if (bool_2 || dataGridView_1.CurrentCell?.ColumnIndex == dataGridViewTextBoxColumn_5.Index || e.Button == MouseButtons.Left)
		{
			method_27(trackBar_0);
		}
	}
}
