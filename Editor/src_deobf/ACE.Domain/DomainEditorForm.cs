using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.RSGlobal;
using Sentry;

namespace ACE.Domain;

public class DomainEditorForm : Form
{
	public struct Triangle(int id1, int id2, int id3)
	{
		public int id1 = id1;

		public int id2 = id2;

		public int id3 = id3;

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1648888223), id1, id2, id3);
		}
	}

	public int count;

	public List<string> name;

	public List<int> id;

	public List<int> type;

	public List<int> reward;

	public List<int> iconposX;

	public List<int> iconposY;

	public List<int> pointscount;

	public List<List<Point>> points;

	public List<int> trianglescount;

	public List<List<Triangle>> triangles;

	public List<int> neighborscount;

	public List<List<int>> neighbors;

	public int version;

	public int version1Extra1;

	public int version1Extra2;

	public int battletimecount;

	public List<int> day;

	public List<int> hour;

	public List<int> minute;

	public int battletime_max;

	public int battletimecount2;

	public List<int> day2;

	public List<int> hour2;

	public List<int> minute2;

	public int battletime_max2;

	public byte[] magic = new byte[4];

	private bool bool_0;

	private IContainer icontainer_0;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripMenuItem toolStripMenuItem_5;

	private StatusStrip statusStrip_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private SplitContainer splitContainer_0;

	private GroupBox groupBox_0;

	private ListBox listBox_0;

	private Panel panel_0;

	private Button button_0;

	private Button button_1;

	private GroupBox groupBox_1;

	private TabControl tabControl_1;

	private TabPage tabPage_1;

	private Button button_2;

	private GroupBox groupBox_2;

	private Label label_0;

	private Label label_1;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private GroupBox groupBox_3;

	private Label label_2;

	private ComboBox comboBox_0;

	private Label label_3;

	private TextBox textBox_2;

	private Label label_4;

	private TextBox textBox_3;

	private Label label_5;

	private TextBox textBox_4;

	private TabPage tabPage_2;

	private SplitContainer splitContainer_1;

	private GroupBox groupBox_4;

	private ListBox listBox_1;

	private Panel panel_1;

	private Button button_3;

	private Button button_4;

	private GroupBox groupBox_5;

	private Button button_5;

	private Label label_6;

	private Label label_7;

	private TextBox textBox_5;

	private TextBox textBox_6;

	private TabPage tabPage_3;

	private SplitContainer splitContainer_2;

	private GroupBox groupBox_6;

	private ListBox listBox_2;

	private Panel panel_2;

	private Button button_6;

	private Button button_7;

	private GroupBox groupBox_7;

	private Button button_8;

	private Label label_8;

	private Label label_9;

	private Label label_10;

	private TextBox textBox_7;

	private TextBox textBox_8;

	private TextBox textBox_9;

	private TabPage tabPage_4;

	private SplitContainer splitContainer_3;

	private GroupBox groupBox_8;

	private ListBox listBox_3;

	private Panel panel_3;

	private Button button_9;

	private Button button_10;

	private GroupBox groupBox_9;

	private Button button_11;

	private Label label_11;

	private TextBox textBox_10;

	private TabPage tabPage_5;

	private SplitContainer splitContainer_4;

	private GroupBox groupBox_10;

	private ListBox listBox_4;

	private Panel panel_4;

	private Button button_12;

	private Button button_13;

	private GroupBox groupBox_11;

	private Button button_14;

	private GroupBox groupBox_12;

	private Label label_12;

	private TextBox textBox_11;

	private GroupBox groupBox_13;

	private Label label_13;

	private Label label_14;

	private Label label_15;

	private TextBox textBox_12;

	private TextBox textBox_13;

	private TextBox textBox_14;

	private Label label_16;

	private GroupBox groupBox_14;

	private Label label_17;

	private Label label_18;

	private TextBox textBox_15;

	private TextBox textBox_16;

	private TabPage tabPage_6;

	private SplitContainer splitContainer_5;

	private GroupBox groupBox_15;

	private ListBox listBox_5;

	private Panel panel_5;

	private Button button_15;

	private Button button_16;

	private GroupBox groupBox_16;

	private Button button_17;

	private GroupBox groupBox_17;

	private Label label_19;

	private TextBox textBox_17;

	private GroupBox groupBox_18;

	private Label label_20;

	private Label label_21;

	private Label label_22;

	private TextBox textBox_18;

	private TextBox textBox_19;

	private TextBox textBox_20;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private bool bool_1;

	private Control control_0;

	private byte[] byte_0;

	private bool bool_2;

	public DomainEditorForm()
	{
		method_5();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		base.Activated += DomainEditorForm_Activated;
		method_2();
		method_0();
		method_22();
	}

	private void method_0()
	{
		count = 0;
		name = new List<string>();
		id = new List<int>();
		type = new List<int>();
		reward = new List<int>();
		iconposX = new List<int>();
		iconposY = new List<int>();
		pointscount = new List<int>();
		points = new List<List<Point>>();
		trianglescount = new List<int>();
		triangles = new List<List<Triangle>>();
		neighborscount = new List<int>();
		neighbors = new List<List<int>>();
		version = 2;
		version1Extra1 = 0;
		version1Extra2 = 0;
		battletimecount = 0;
		day = new List<int>();
		hour = new List<int>();
		minute = new List<int>();
		battletime_max = 0;
		battletimecount2 = 0;
		day2 = new List<int>();
		hour2 = new List<int>();
		minute2 = new List<int>();
		battletime_max2 = 0;
	}

	private void method_1()
	{
		bool_0 = true;
		listBox_0.Items.Clear();
		listBox_1.Items.Clear();
		listBox_2.Items.Clear();
		listBox_3.Items.Clear();
		listBox_4.Items.Clear();
		listBox_5.Items.Clear();
		textBox_4.Text = string.Empty;
		textBox_3.Text = string.Empty;
		comboBox_0.SelectedIndex = -1;
		textBox_2.Text = string.Empty;
		textBox_1.Text = string.Empty;
		textBox_0.Text = string.Empty;
		textBox_6.Text = string.Empty;
		textBox_5.Text = string.Empty;
		textBox_9.Text = string.Empty;
		textBox_8.Text = string.Empty;
		textBox_7.Text = string.Empty;
		textBox_10.Text = string.Empty;
		textBox_14.Text = string.Empty;
		textBox_13.Text = string.Empty;
		textBox_12.Text = string.Empty;
		textBox_11.Text = string.Empty;
		textBox_20.Text = string.Empty;
		textBox_19.Text = string.Empty;
		textBox_18.Text = string.Empty;
		textBox_17.Text = string.Empty;
		textBox_16.Text = string.Empty;
		textBox_15.Text = string.Empty;
		method_0();
		method_3();
		method_27();
		bool_0 = false;
	}

	private void method_2()
	{
		button_2.Visible = false;
		button_5.Visible = false;
		button_8.Visible = false;
		button_11.Visible = false;
		button_14.Visible = false;
		button_17.Visible = false;
		listBox_0.SelectionMode = SelectionMode.MultiExtended;
		listBox_1.SelectionMode = SelectionMode.MultiExtended;
		listBox_2.SelectionMode = SelectionMode.MultiExtended;
		listBox_3.SelectionMode = SelectionMode.MultiExtended;
		listBox_4.SelectionMode = SelectionMode.MultiExtended;
		listBox_5.SelectionMode = SelectionMode.MultiExtended;
		textBox_4.TextChanged += textBox_0_TextChanged;
		textBox_3.TextChanged += textBox_0_TextChanged;
		textBox_2.TextChanged += textBox_0_TextChanged;
		textBox_1.TextChanged += textBox_0_TextChanged;
		textBox_0.TextChanged += textBox_0_TextChanged;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		textBox_6.TextChanged += textBox_5_TextChanged;
		textBox_5.TextChanged += textBox_5_TextChanged;
		textBox_9.TextChanged += textBox_7_TextChanged;
		textBox_8.TextChanged += textBox_7_TextChanged;
		textBox_7.TextChanged += textBox_7_TextChanged;
		textBox_10.TextChanged += textBox_10_TextChanged;
		textBox_14.TextChanged += textBox_12_TextChanged;
		textBox_13.TextChanged += textBox_12_TextChanged;
		textBox_12.TextChanged += textBox_12_TextChanged;
		textBox_20.TextChanged += textBox_20_TextChanged;
		textBox_19.TextChanged += textBox_20_TextChanged;
		textBox_18.TextChanged += textBox_20_TextChanged;
		textBox_16.TextChanged += textBox_16_TextChanged;
		textBox_15.TextChanged += textBox_16_TextChanged;
	}

	private void method_3()
	{
		bool_0 = true;
		label_16.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648888245), Class16.smethod_0(1648888267)), version);
		groupBox_14.Enabled = version == 1;
		tabPage_6.Enabled = version == 2;
		bool_0 = false;
	}

	private void method_4()
	{
		if (version != 2)
		{
			version = 2;
			method_3();
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

	private void method_5()
	{
		new ComponentResourceManager(typeof(DomainEditorForm));
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripSeparator_1 = new ToolStripSeparator();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		toolStripMenuItem_5 = new ToolStripMenuItem();
		statusStrip_0 = new StatusStrip();
		toolStripStatusLabel_0 = new ToolStripStatusLabel();
		tabControl_0 = new TabControl();
		tabPage_0 = new TabPage();
		splitContainer_0 = new SplitContainer();
		groupBox_0 = new GroupBox();
		listBox_0 = new ListBox();
		panel_0 = new Panel();
		button_0 = new Button();
		button_1 = new Button();
		groupBox_1 = new GroupBox();
		tabControl_1 = new TabControl();
		tabPage_1 = new TabPage();
		button_2 = new Button();
		groupBox_2 = new GroupBox();
		label_0 = new Label();
		label_1 = new Label();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		groupBox_3 = new GroupBox();
		label_2 = new Label();
		comboBox_0 = new ComboBox();
		label_3 = new Label();
		textBox_2 = new TextBox();
		label_4 = new Label();
		textBox_3 = new TextBox();
		label_5 = new Label();
		textBox_4 = new TextBox();
		tabPage_2 = new TabPage();
		splitContainer_1 = new SplitContainer();
		groupBox_4 = new GroupBox();
		listBox_1 = new ListBox();
		panel_1 = new Panel();
		button_3 = new Button();
		button_4 = new Button();
		groupBox_5 = new GroupBox();
		button_5 = new Button();
		label_6 = new Label();
		label_7 = new Label();
		textBox_5 = new TextBox();
		textBox_6 = new TextBox();
		tabPage_3 = new TabPage();
		splitContainer_2 = new SplitContainer();
		groupBox_6 = new GroupBox();
		listBox_2 = new ListBox();
		panel_2 = new Panel();
		button_6 = new Button();
		button_7 = new Button();
		groupBox_7 = new GroupBox();
		button_8 = new Button();
		label_8 = new Label();
		label_9 = new Label();
		label_10 = new Label();
		textBox_7 = new TextBox();
		textBox_8 = new TextBox();
		textBox_9 = new TextBox();
		tabPage_4 = new TabPage();
		splitContainer_3 = new SplitContainer();
		groupBox_8 = new GroupBox();
		listBox_3 = new ListBox();
		panel_3 = new Panel();
		button_9 = new Button();
		button_10 = new Button();
		groupBox_9 = new GroupBox();
		button_11 = new Button();
		label_11 = new Label();
		textBox_10 = new TextBox();
		tabPage_5 = new TabPage();
		splitContainer_4 = new SplitContainer();
		groupBox_10 = new GroupBox();
		listBox_4 = new ListBox();
		panel_4 = new Panel();
		button_12 = new Button();
		button_13 = new Button();
		groupBox_11 = new GroupBox();
		label_16 = new Label();
		groupBox_14 = new GroupBox();
		label_17 = new Label();
		label_18 = new Label();
		textBox_15 = new TextBox();
		textBox_16 = new TextBox();
		button_14 = new Button();
		groupBox_12 = new GroupBox();
		label_12 = new Label();
		textBox_11 = new TextBox();
		groupBox_13 = new GroupBox();
		label_13 = new Label();
		label_14 = new Label();
		label_15 = new Label();
		textBox_12 = new TextBox();
		textBox_13 = new TextBox();
		textBox_14 = new TextBox();
		tabPage_6 = new TabPage();
		splitContainer_5 = new SplitContainer();
		groupBox_15 = new GroupBox();
		listBox_5 = new ListBox();
		panel_5 = new Panel();
		button_15 = new Button();
		button_16 = new Button();
		groupBox_16 = new GroupBox();
		button_17 = new Button();
		groupBox_17 = new GroupBox();
		label_19 = new Label();
		textBox_17 = new TextBox();
		groupBox_18 = new GroupBox();
		label_20 = new Label();
		label_21 = new Label();
		label_22 = new Label();
		textBox_18 = new TextBox();
		textBox_19 = new TextBox();
		textBox_20 = new TextBox();
		menuStrip_0.SuspendLayout();
		statusStrip_0.SuspendLayout();
		tabControl_0.SuspendLayout();
		tabPage_0.SuspendLayout();
		((ISupportInitialize)splitContainer_0).BeginInit();
		splitContainer_0.Panel1.SuspendLayout();
		splitContainer_0.Panel2.SuspendLayout();
		splitContainer_0.SuspendLayout();
		groupBox_0.SuspendLayout();
		panel_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		tabControl_1.SuspendLayout();
		tabPage_1.SuspendLayout();
		groupBox_2.SuspendLayout();
		groupBox_3.SuspendLayout();
		tabPage_2.SuspendLayout();
		((ISupportInitialize)splitContainer_1).BeginInit();
		splitContainer_1.Panel1.SuspendLayout();
		splitContainer_1.Panel2.SuspendLayout();
		splitContainer_1.SuspendLayout();
		groupBox_4.SuspendLayout();
		panel_1.SuspendLayout();
		groupBox_5.SuspendLayout();
		tabPage_3.SuspendLayout();
		((ISupportInitialize)splitContainer_2).BeginInit();
		splitContainer_2.Panel1.SuspendLayout();
		splitContainer_2.Panel2.SuspendLayout();
		splitContainer_2.SuspendLayout();
		groupBox_6.SuspendLayout();
		panel_2.SuspendLayout();
		groupBox_7.SuspendLayout();
		tabPage_4.SuspendLayout();
		((ISupportInitialize)splitContainer_3).BeginInit();
		splitContainer_3.Panel1.SuspendLayout();
		splitContainer_3.Panel2.SuspendLayout();
		splitContainer_3.SuspendLayout();
		groupBox_8.SuspendLayout();
		panel_3.SuspendLayout();
		groupBox_9.SuspendLayout();
		tabPage_5.SuspendLayout();
		((ISupportInitialize)splitContainer_4).BeginInit();
		splitContainer_4.Panel1.SuspendLayout();
		splitContainer_4.Panel2.SuspendLayout();
		splitContainer_4.SuspendLayout();
		groupBox_10.SuspendLayout();
		panel_4.SuspendLayout();
		groupBox_11.SuspendLayout();
		groupBox_14.SuspendLayout();
		groupBox_12.SuspendLayout();
		groupBox_13.SuspendLayout();
		tabPage_6.SuspendLayout();
		((ISupportInitialize)splitContainer_5).BeginInit();
		splitContainer_5.Panel1.SuspendLayout();
		splitContainer_5.Panel2.SuspendLayout();
		splitContainer_5.SuspendLayout();
		groupBox_15.SuspendLayout();
		panel_5.SuspendLayout();
		groupBox_16.SuspendLayout();
		groupBox_17.SuspendLayout();
		groupBox_18.SuspendLayout();
		SuspendLayout();
		menuStrip_0.BackColor = SystemColors.MenuBar;
		menuStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripMenuItem_0 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1648888303);
		menuStrip_0.Size = new Size(784, 24);
		menuStrip_0.TabIndex = 0;
		menuStrip_0.Text = Class16.smethod_0(1648888303);
		toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[7] { toolStripMenuItem_1, toolStripSeparator_0, toolStripMenuItem_2, toolStripMenuItem_3, toolStripSeparator_1, toolStripMenuItem_4, toolStripMenuItem_5 });
		toolStripMenuItem_0.Name = Class16.smethod_0(1648916926);
		toolStripMenuItem_0.Size = new Size(37, 20);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_1.Name = Class16.smethod_0(1648888319);
		toolStripMenuItem_1.ShortcutKeys = Keys.O | Keys.Control;
		toolStripMenuItem_1.Size = new Size(248, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1649014291);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1648920981);
		toolStripSeparator_0.Size = new Size(245, 6);
		toolStripMenuItem_2.Name = Class16.smethod_0(1649014314);
		toolStripMenuItem_2.ShortcutKeys = Keys.S | Keys.Control;
		toolStripMenuItem_2.Size = new Size(248, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1649014344);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.Name = Class16.smethod_0(1649014370);
		toolStripMenuItem_3.ShortcutKeys = Keys.S | Keys.Shift | Keys.Control;
		toolStripMenuItem_3.Size = new Size(248, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1649014403);
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		toolStripSeparator_1.Name = Class16.smethod_0(1648921077);
		toolStripSeparator_1.Size = new Size(245, 6);
		toolStripMenuItem_4.Name = Class16.smethod_0(1649014436);
		toolStripMenuItem_4.Size = new Size(248, 22);
		toolStripMenuItem_4.Text = Class16.smethod_0(1649014457);
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		toolStripMenuItem_5.Name = Class16.smethod_0(1649014477);
		toolStripMenuItem_5.Size = new Size(248, 22);
		toolStripMenuItem_5.Text = Class16.smethod_0(1648920914);
		toolStripMenuItem_5.Click += toolStripMenuItem_5_Click;
		statusStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripStatusLabel_0 });
		statusStrip_0.Location = new Point(0, 539);
		statusStrip_0.Name = Class16.smethod_0(1649014497);
		statusStrip_0.Size = new Size(784, 22);
		statusStrip_0.TabIndex = 1;
		statusStrip_0.Text = Class16.smethod_0(1649014497);
		toolStripStatusLabel_0.Name = Class16.smethod_0(1649014515);
		toolStripStatusLabel_0.Size = new Size(39, 17);
		toolStripStatusLabel_0.Text = Class16.smethod_0(1648920624);
		tabControl_0.Controls.Add(tabPage_0);
		tabControl_0.Controls.Add(tabPage_5);
		tabControl_0.Controls.Add(tabPage_6);
		tabControl_0.Dock = DockStyle.Fill;
		tabControl_0.Location = new Point(0, 24);
		tabControl_0.Name = Class16.smethod_0(1649014551);
		tabControl_0.SelectedIndex = 0;
		tabControl_0.Size = new Size(784, 515);
		tabControl_0.TabIndex = 2;
		tabPage_0.BackColor = Color.FromArgb(239, 244, 250);
		tabPage_0.Controls.Add(splitContainer_0);
		tabPage_0.Location = new Point(4, 22);
		tabPage_0.Name = Class16.smethod_0(1649014572);
		tabPage_0.Padding = new Padding(3);
		tabPage_0.Size = new Size(776, 489);
		tabPage_0.TabIndex = 0;
		tabPage_0.Text = Class16.smethod_0(1649014585);
		splitContainer_0.Dock = DockStyle.Fill;
		splitContainer_0.Location = new Point(3, 3);
		splitContainer_0.Name = Class16.smethod_0(1649014607);
		splitContainer_0.Panel1.Controls.Add(groupBox_0);
		splitContainer_0.Panel2.Controls.Add(groupBox_1);
		splitContainer_0.Size = new Size(770, 483);
		splitContainer_0.SplitterDistance = 238;
		splitContainer_0.TabIndex = 0;
		groupBox_0.Controls.Add(listBox_0);
		groupBox_0.Controls.Add(panel_0);
		groupBox_0.Dock = DockStyle.Fill;
		groupBox_0.Location = new Point(0, 0);
		groupBox_0.Name = Class16.smethod_0(1649014627);
		groupBox_0.Size = new Size(238, 483);
		groupBox_0.TabIndex = 0;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1649014585);
		listBox_0.BackColor = Color.FromArgb(32, 32, 32);
		listBox_0.Dock = DockStyle.Fill;
		listBox_0.ForeColor = Color.White;
		listBox_0.FormattingEnabled = true;
		listBox_0.Location = new Point(3, 16);
		listBox_0.Name = Class16.smethod_0(1649014660);
		listBox_0.Size = new Size(232, 434);
		listBox_0.TabIndex = 0;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		panel_0.Controls.Add(button_0);
		panel_0.Controls.Add(button_1);
		panel_0.Dock = DockStyle.Bottom;
		panel_0.Location = new Point(3, 450);
		panel_0.Name = Class16.smethod_0(1649014673);
		panel_0.Size = new Size(232, 30);
		panel_0.TabIndex = 1;
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_0.BackColor = Color.IndianRed;
		button_0.ForeColor = Color.White;
		button_0.Location = new Point(157, 3);
		button_0.Name = Class16.smethod_0(1649014698);
		button_0.Size = new Size(75, 23);
		button_0.TabIndex = 1;
		button_0.Text = Class16.smethod_0(1648931371);
		button_0.UseVisualStyleBackColor = false;
		button_0.Click += button_0_Click;
		button_1.BackColor = Color.SteelBlue;
		button_1.ForeColor = Color.White;
		button_1.Location = new Point(3, 3);
		button_1.Name = Class16.smethod_0(1649014723);
		button_1.Size = new Size(75, 23);
		button_1.TabIndex = 0;
		button_1.Text = Class16.smethod_0(1648931361);
		button_1.UseVisualStyleBackColor = false;
		button_1.Click += button_1_Click;
		groupBox_1.Controls.Add(tabControl_1);
		groupBox_1.Dock = DockStyle.Fill;
		groupBox_1.Location = new Point(0, 0);
		groupBox_1.Name = Class16.smethod_0(1649014745);
		groupBox_1.Size = new Size(528, 483);
		groupBox_1.TabIndex = 0;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1649014781);
		tabControl_1.Controls.Add(tabPage_1);
		tabControl_1.Controls.Add(tabPage_2);
		tabControl_1.Controls.Add(tabPage_3);
		tabControl_1.Controls.Add(tabPage_4);
		tabControl_1.Dock = DockStyle.Fill;
		tabControl_1.Location = new Point(3, 16);
		tabControl_1.Name = Class16.smethod_0(1649013770);
		tabControl_1.SelectedIndex = 0;
		tabControl_1.Size = new Size(522, 464);
		tabControl_1.TabIndex = 0;
		tabPage_1.BackColor = Color.FromArgb(239, 244, 250);
		tabPage_1.Controls.Add(button_2);
		tabPage_1.Controls.Add(groupBox_2);
		tabPage_1.Controls.Add(groupBox_3);
		tabPage_1.Location = new Point(4, 22);
		tabPage_1.Name = Class16.smethod_0(1649013800);
		tabPage_1.Padding = new Padding(3);
		tabPage_1.Size = new Size(514, 438);
		tabPage_1.TabIndex = 0;
		tabPage_1.Text = Class16.smethod_0(1649013831);
		button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_2.BackColor = Color.ForestGreen;
		button_2.ForeColor = Color.White;
		button_2.Location = new Point(433, 409);
		button_2.Name = Class16.smethod_0(1649013840);
		button_2.Size = new Size(75, 23);
		button_2.TabIndex = 2;
		button_2.Text = Class16.smethod_0(1649013865);
		button_2.UseVisualStyleBackColor = false;
		button_2.Click += button_2_Click;
		groupBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_2.Controls.Add(label_0);
		groupBox_2.Controls.Add(label_1);
		groupBox_2.Controls.Add(textBox_0);
		groupBox_2.Controls.Add(textBox_1);
		groupBox_2.Location = new Point(6, 216);
		groupBox_2.Name = Class16.smethod_0(1649013886);
		groupBox_2.Size = new Size(502, 80);
		groupBox_2.TabIndex = 1;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1649013905);
		label_0.AutoSize = true;
		label_0.Location = new Point(12, 52);
		label_0.Name = Class16.smethod_0(1649013933);
		label_0.Size = new Size(17, 13);
		label_0.TabIndex = 3;
		label_0.Text = Class16.smethod_0(1649013950);
		label_1.AutoSize = true;
		label_1.Location = new Point(12, 26);
		label_1.Name = Class16.smethod_0(1649013959);
		label_1.Size = new Size(17, 13);
		label_1.TabIndex = 2;
		label_1.Text = Class16.smethod_0(1649013968);
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.Location = new Point(35, 49);
		textBox_0.Name = Class16.smethod_0(1649013977);
		textBox_0.Size = new Size(461, 20);
		textBox_0.TabIndex = 1;
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.Location = new Point(35, 23);
		textBox_1.Name = Class16.smethod_0(1649014007);
		textBox_1.Size = new Size(461, 20);
		textBox_1.TabIndex = 0;
		groupBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_3.Controls.Add(label_2);
		groupBox_3.Controls.Add(comboBox_0);
		groupBox_3.Controls.Add(label_3);
		groupBox_3.Controls.Add(textBox_2);
		groupBox_3.Controls.Add(label_4);
		groupBox_3.Controls.Add(textBox_3);
		groupBox_3.Controls.Add(label_5);
		groupBox_3.Controls.Add(textBox_4);
		groupBox_3.Location = new Point(6, 6);
		groupBox_3.Name = Class16.smethod_0(1649014029);
		groupBox_3.Size = new Size(502, 204);
		groupBox_3.TabIndex = 0;
		groupBox_3.TabStop = false;
		groupBox_3.Text = Class16.smethod_0(1649014051);
		label_2.AutoSize = true;
		label_2.Location = new Point(12, 104);
		label_2.Name = Class16.smethod_0(1649014074);
		label_2.Size = new Size(34, 13);
		label_2.TabIndex = 7;
		label_2.Text = Class16.smethod_0(1649014090);
		comboBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[4]
		{
			Class16.smethod_0(1649014110),
			Class16.smethod_0(1649014113),
			Class16.smethod_0(1649014129),
			Class16.smethod_0(1649014145)
		});
		comboBox_0.Location = new Point(61, 101);
		comboBox_0.Name = Class16.smethod_0(1649014161);
		comboBox_0.Size = new Size(435, 21);
		comboBox_0.TabIndex = 6;
		label_3.AutoSize = true;
		label_3.Location = new Point(12, 78);
		label_3.Name = Class16.smethod_0(1649014188);
		label_3.Size = new Size(47, 13);
		label_3.TabIndex = 5;
		label_3.Text = Class16.smethod_0(1649014206);
		textBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_2.Location = new Point(61, 75);
		textBox_2.Name = Class16.smethod_0(1649014220);
		textBox_2.Size = new Size(435, 20);
		textBox_2.TabIndex = 4;
		label_4.AutoSize = true;
		label_4.Location = new Point(12, 52);
		label_4.Name = Class16.smethod_0(1649014232);
		label_4.Size = new Size(21, 13);
		label_4.TabIndex = 3;
		label_4.Text = Class16.smethod_0(1648930840);
		textBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_3.Location = new Point(61, 49);
		textBox_3.Name = Class16.smethod_0(1649014254);
		textBox_3.Size = new Size(435, 20);
		textBox_3.TabIndex = 2;
		label_5.AutoSize = true;
		label_5.Location = new Point(12, 26);
		label_5.Name = Class16.smethod_0(1649014270);
		label_5.Size = new Size(38, 13);
		label_5.TabIndex = 1;
		label_5.Text = Class16.smethod_0(1648930944);
		textBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_4.Location = new Point(61, 23);
		textBox_4.MaxLength = 15;
		textBox_4.Name = Class16.smethod_0(1649013262);
		textBox_4.Size = new Size(435, 20);
		textBox_4.TabIndex = 0;
		tabPage_2.BackColor = Color.FromArgb(239, 244, 250);
		tabPage_2.Controls.Add(splitContainer_1);
		tabPage_2.Location = new Point(4, 22);
		tabPage_2.Name = Class16.smethod_0(1649013272);
		tabPage_2.Padding = new Padding(3);
		tabPage_2.Size = new Size(514, 438);
		tabPage_2.TabIndex = 1;
		tabPage_2.Text = Class16.smethod_0(1649013300);
		splitContainer_1.Dock = DockStyle.Fill;
		splitContainer_1.Location = new Point(3, 3);
		splitContainer_1.Name = Class16.smethod_0(1649013305);
		splitContainer_1.Panel1.Controls.Add(groupBox_4);
		splitContainer_1.Panel2.Controls.Add(groupBox_5);
		splitContainer_1.Size = new Size(508, 432);
		splitContainer_1.SplitterDistance = 235;
		splitContainer_1.TabIndex = 0;
		groupBox_4.Controls.Add(listBox_1);
		groupBox_4.Controls.Add(panel_1);
		groupBox_4.Dock = DockStyle.Fill;
		groupBox_4.Location = new Point(0, 0);
		groupBox_4.Name = Class16.smethod_0(1649013340);
		groupBox_4.Size = new Size(235, 432);
		groupBox_4.TabIndex = 0;
		groupBox_4.TabStop = false;
		groupBox_4.Text = Class16.smethod_0(1649013300);
		listBox_1.BackColor = Color.FromArgb(32, 32, 32);
		listBox_1.Dock = DockStyle.Fill;
		listBox_1.ForeColor = Color.White;
		listBox_1.FormattingEnabled = true;
		listBox_1.Location = new Point(3, 16);
		listBox_1.Name = Class16.smethod_0(1649013365);
		listBox_1.Size = new Size(229, 383);
		listBox_1.TabIndex = 0;
		listBox_1.SelectedIndexChanged += listBox_1_SelectedIndexChanged;
		panel_1.Controls.Add(button_3);
		panel_1.Controls.Add(button_4);
		panel_1.Dock = DockStyle.Bottom;
		panel_1.Location = new Point(3, 399);
		panel_1.Name = Class16.smethod_0(1649013377);
		panel_1.Size = new Size(229, 30);
		panel_1.TabIndex = 1;
		button_3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_3.BackColor = Color.IndianRed;
		button_3.ForeColor = Color.White;
		button_3.Location = new Point(154, 3);
		button_3.Name = Class16.smethod_0(1649013401);
		button_3.Size = new Size(75, 23);
		button_3.TabIndex = 1;
		button_3.Text = Class16.smethod_0(1648931371);
		button_3.UseVisualStyleBackColor = false;
		button_3.Click += button_3_Click;
		button_4.BackColor = Color.SteelBlue;
		button_4.ForeColor = Color.White;
		button_4.Location = new Point(3, 3);
		button_4.Name = Class16.smethod_0(1649013425);
		button_4.Size = new Size(75, 23);
		button_4.TabIndex = 0;
		button_4.Text = Class16.smethod_0(1648931361);
		button_4.UseVisualStyleBackColor = false;
		button_4.Click += button_4_Click;
		groupBox_5.Controls.Add(button_5);
		groupBox_5.Controls.Add(label_6);
		groupBox_5.Controls.Add(label_7);
		groupBox_5.Controls.Add(textBox_5);
		groupBox_5.Controls.Add(textBox_6);
		groupBox_5.Dock = DockStyle.Fill;
		groupBox_5.Location = new Point(0, 0);
		groupBox_5.Name = Class16.smethod_0(1649013454);
		groupBox_5.Size = new Size(269, 432);
		groupBox_5.TabIndex = 0;
		groupBox_5.TabStop = false;
		groupBox_5.Text = Class16.smethod_0(1649013473);
		button_5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_5.BackColor = Color.ForestGreen;
		button_5.ForeColor = Color.White;
		button_5.Location = new Point(188, 403);
		button_5.Name = Class16.smethod_0(1649013501);
		button_5.Size = new Size(75, 23);
		button_5.TabIndex = 4;
		button_5.Text = Class16.smethod_0(1649013865);
		button_5.UseVisualStyleBackColor = false;
		button_5.Click += button_5_Click;
		label_6.AutoSize = true;
		label_6.Location = new Point(12, 52);
		label_6.Name = Class16.smethod_0(1649013525);
		label_6.Size = new Size(17, 13);
		label_6.TabIndex = 3;
		label_6.Text = Class16.smethod_0(1649013950);
		label_7.AutoSize = true;
		label_7.Location = new Point(12, 26);
		label_7.Name = Class16.smethod_0(1649013543);
		label_7.Size = new Size(17, 13);
		label_7.TabIndex = 2;
		label_7.Text = Class16.smethod_0(1649013968);
		textBox_5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_5.Location = new Point(35, 49);
		textBox_5.Name = Class16.smethod_0(1649013553);
		textBox_5.Size = new Size(228, 20);
		textBox_5.TabIndex = 1;
		textBox_6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_6.Location = new Point(35, 23);
		textBox_6.Name = Class16.smethod_0(1649013581);
		textBox_6.Size = new Size(228, 20);
		textBox_6.TabIndex = 0;
		tabPage_3.BackColor = Color.FromArgb(239, 244, 250);
		tabPage_3.Controls.Add(splitContainer_2);
		tabPage_3.Location = new Point(4, 22);
		tabPage_3.Name = Class16.smethod_0(1649013593);
		tabPage_3.Size = new Size(514, 438);
		tabPage_3.TabIndex = 2;
		tabPage_3.Text = Class16.smethod_0(1649013616);
		splitContainer_2.Dock = DockStyle.Fill;
		splitContainer_2.Location = new Point(0, 0);
		splitContainer_2.Name = Class16.smethod_0(1649013632);
		splitContainer_2.Panel1.Controls.Add(groupBox_6);
		splitContainer_2.Panel2.Controls.Add(groupBox_7);
		splitContainer_2.Size = new Size(514, 438);
		splitContainer_2.SplitterDistance = 236;
		splitContainer_2.TabIndex = 0;
		groupBox_6.Controls.Add(listBox_2);
		groupBox_6.Controls.Add(panel_2);
		groupBox_6.Dock = DockStyle.Fill;
		groupBox_6.Location = new Point(0, 0);
		groupBox_6.Name = Class16.smethod_0(1649013670);
		groupBox_6.Size = new Size(236, 438);
		groupBox_6.TabIndex = 0;
		groupBox_6.TabStop = false;
		groupBox_6.Text = Class16.smethod_0(1649013616);
		listBox_2.BackColor = Color.FromArgb(32, 32, 32);
		listBox_2.Dock = DockStyle.Fill;
		listBox_2.ForeColor = Color.White;
		listBox_2.FormattingEnabled = true;
		listBox_2.Location = new Point(3, 16);
		listBox_2.Name = Class16.smethod_0(1649013690);
		listBox_2.Size = new Size(230, 389);
		listBox_2.TabIndex = 0;
		listBox_2.SelectedIndexChanged += listBox_2_SelectedIndexChanged;
		panel_2.Controls.Add(button_6);
		panel_2.Controls.Add(button_7);
		panel_2.Dock = DockStyle.Bottom;
		panel_2.Location = new Point(3, 405);
		panel_2.Name = Class16.smethod_0(1649013713);
		panel_2.Size = new Size(230, 30);
		panel_2.TabIndex = 1;
		button_6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_6.BackColor = Color.IndianRed;
		button_6.ForeColor = Color.White;
		button_6.Location = new Point(155, 3);
		button_6.Name = Class16.smethod_0(1649013748);
		button_6.Size = new Size(75, 23);
		button_6.TabIndex = 1;
		button_6.Text = Class16.smethod_0(1648931371);
		button_6.UseVisualStyleBackColor = false;
		button_6.Click += button_6_Click;
		button_7.BackColor = Color.SteelBlue;
		button_7.ForeColor = Color.White;
		button_7.Location = new Point(3, 3);
		button_7.Name = Class16.smethod_0(1649012751);
		button_7.Size = new Size(75, 23);
		button_7.TabIndex = 0;
		button_7.Text = Class16.smethod_0(1648931361);
		button_7.UseVisualStyleBackColor = false;
		button_7.Click += button_7_Click;
		groupBox_7.Controls.Add(button_8);
		groupBox_7.Controls.Add(label_8);
		groupBox_7.Controls.Add(label_9);
		groupBox_7.Controls.Add(label_10);
		groupBox_7.Controls.Add(textBox_7);
		groupBox_7.Controls.Add(textBox_8);
		groupBox_7.Controls.Add(textBox_9);
		groupBox_7.Dock = DockStyle.Fill;
		groupBox_7.Location = new Point(0, 0);
		groupBox_7.Name = Class16.smethod_0(1649012775);
		groupBox_7.Size = new Size(274, 438);
		groupBox_7.TabIndex = 0;
		groupBox_7.TabStop = false;
		groupBox_7.Text = Class16.smethod_0(1649012805);
		button_8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_8.BackColor = Color.ForestGreen;
		button_8.ForeColor = Color.White;
		button_8.Location = new Point(193, 409);
		button_8.Name = Class16.smethod_0(1649012828);
		button_8.Size = new Size(75, 23);
		button_8.TabIndex = 6;
		button_8.Text = Class16.smethod_0(1649013865);
		button_8.UseVisualStyleBackColor = false;
		button_8.Click += button_8_Click;
		label_8.AutoSize = true;
		label_8.Location = new Point(12, 78);
		label_8.Name = Class16.smethod_0(1649012855);
		label_8.Size = new Size(27, 13);
		label_8.TabIndex = 5;
		label_8.Text = Class16.smethod_0(1649012878);
		label_9.AutoSize = true;
		label_9.Location = new Point(12, 52);
		label_9.Name = Class16.smethod_0(1649012881);
		label_9.Size = new Size(27, 13);
		label_9.TabIndex = 4;
		label_9.Text = Class16.smethod_0(1649012904);
		label_10.AutoSize = true;
		label_10.Location = new Point(12, 26);
		label_10.Name = Class16.smethod_0(1649012915);
		label_10.Size = new Size(27, 13);
		label_10.TabIndex = 3;
		label_10.Text = Class16.smethod_0(1649012938);
		textBox_7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_7.Location = new Point(43, 75);
		textBox_7.Name = Class16.smethod_0(1649012957);
		textBox_7.Size = new Size(225, 20);
		textBox_7.TabIndex = 2;
		textBox_8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_8.Location = new Point(43, 49);
		textBox_8.Name = Class16.smethod_0(1649012982);
		textBox_8.Size = new Size(225, 20);
		textBox_8.TabIndex = 1;
		textBox_9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_9.Location = new Point(43, 23);
		textBox_9.Name = Class16.smethod_0(1649013007);
		textBox_9.Size = new Size(225, 20);
		textBox_9.TabIndex = 0;
		tabPage_4.BackColor = Color.FromArgb(239, 244, 250);
		tabPage_4.Controls.Add(splitContainer_3);
		tabPage_4.Location = new Point(4, 22);
		tabPage_4.Name = Class16.smethod_0(1649013024);
		tabPage_4.Size = new Size(514, 438);
		tabPage_4.TabIndex = 3;
		tabPage_4.Text = Class16.smethod_0(1649013055);
		splitContainer_3.Dock = DockStyle.Fill;
		splitContainer_3.Location = new Point(0, 0);
		splitContainer_3.Name = Class16.smethod_0(1649013071);
		splitContainer_3.Panel1.Controls.Add(groupBox_8);
		splitContainer_3.Panel2.Controls.Add(groupBox_9);
		splitContainer_3.Size = new Size(514, 438);
		splitContainer_3.SplitterDistance = 236;
		splitContainer_3.TabIndex = 0;
		groupBox_8.Controls.Add(listBox_3);
		groupBox_8.Controls.Add(panel_3);
		groupBox_8.Dock = DockStyle.Fill;
		groupBox_8.Location = new Point(0, 0);
		groupBox_8.Name = Class16.smethod_0(1649013101);
		groupBox_8.Size = new Size(236, 438);
		groupBox_8.TabIndex = 0;
		groupBox_8.TabStop = false;
		groupBox_8.Text = Class16.smethod_0(1649013055);
		listBox_3.Location = new Point(3, 16);
		listBox_3.Name = Class16.smethod_0(1649013121);
		listBox_3.Size = new Size(294, 589);
		listBox_3.TabIndex = 0;
		listBox_3.SelectedIndexChanged += listBox_3_SelectedIndexChanged;
		panel_3.Controls.Add(button_9);
		panel_3.Controls.Add(button_10);
		panel_3.Dock = DockStyle.Bottom;
		panel_3.Location = new Point(3, 405);
		panel_3.Name = Class16.smethod_0(1649013144);
		panel_3.Size = new Size(230, 30);
		panel_3.TabIndex = 1;
		button_9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_9.BackColor = Color.IndianRed;
		button_9.ForeColor = Color.White;
		button_9.Location = new Point(155, 3);
		button_9.Name = Class16.smethod_0(1649013171);
		button_9.Size = new Size(75, 23);
		button_9.TabIndex = 1;
		button_9.Text = Class16.smethod_0(1648931371);
		button_9.UseVisualStyleBackColor = false;
		button_9.Click += button_9_Click;
		button_10.BackColor = Color.SteelBlue;
		button_10.ForeColor = Color.White;
		button_10.Location = new Point(3, 3);
		button_10.Name = Class16.smethod_0(1649013206);
		button_10.Size = new Size(75, 23);
		button_10.TabIndex = 0;
		button_10.Text = Class16.smethod_0(1648931361);
		button_10.UseVisualStyleBackColor = false;
		button_10.Click += button_10_Click;
		groupBox_9.Controls.Add(button_11);
		groupBox_9.Controls.Add(label_11);
		groupBox_9.Controls.Add(textBox_10);
		groupBox_9.Dock = DockStyle.Fill;
		groupBox_9.Location = new Point(0, 0);
		groupBox_9.Name = Class16.smethod_0(1649013230);
		groupBox_9.Size = new Size(274, 438);
		groupBox_9.TabIndex = 0;
		groupBox_9.TabStop = false;
		groupBox_9.Text = Class16.smethod_0(1649016332);
		button_11.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_11.BackColor = Color.ForestGreen;
		button_11.ForeColor = Color.White;
		button_11.Location = new Point(193, 409);
		button_11.Name = Class16.smethod_0(1649016347);
		button_11.Size = new Size(75, 23);
		button_11.TabIndex = 2;
		button_11.Text = Class16.smethod_0(1649013865);
		button_11.UseVisualStyleBackColor = false;
		button_11.Click += button_11_Click;
		label_11.AutoSize = true;
		label_11.Location = new Point(12, 26);
		label_11.Name = Class16.smethod_0(1649016382);
		label_11.Size = new Size(21, 13);
		label_11.TabIndex = 1;
		label_11.Text = Class16.smethod_0(1648930840);
		textBox_10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_10.Location = new Point(43, 23);
		textBox_10.Name = Class16.smethod_0(1649016394);
		textBox_10.Size = new Size(225, 20);
		textBox_10.TabIndex = 0;
		tabPage_5.BackColor = Color.FromArgb(239, 244, 250);
		tabPage_5.Controls.Add(splitContainer_4);
		tabPage_5.Location = new Point(4, 22);
		tabPage_5.Name = Class16.smethod_0(1649016416);
		tabPage_5.Padding = new Padding(3);
		tabPage_5.Size = new Size(776, 489);
		tabPage_5.TabIndex = 1;
		tabPage_5.Text = Class16.smethod_0(1649016441);
		splitContainer_4.Dock = DockStyle.Fill;
		splitContainer_4.Location = new Point(3, 3);
		splitContainer_4.Name = Class16.smethod_0(1649016468);
		splitContainer_4.Panel1.Controls.Add(groupBox_10);
		splitContainer_4.Panel2.Controls.Add(groupBox_11);
		splitContainer_4.Size = new Size(770, 483);
		splitContainer_4.SplitterDistance = 238;
		splitContainer_4.TabIndex = 0;
		groupBox_10.Controls.Add(listBox_4);
		groupBox_10.Controls.Add(panel_4);
		groupBox_10.Dock = DockStyle.Fill;
		groupBox_10.Location = new Point(0, 0);
		groupBox_10.Name = Class16.smethod_0(1649016500);
		groupBox_10.Size = new Size(238, 483);
		groupBox_10.TabIndex = 0;
		groupBox_10.TabStop = false;
		groupBox_10.Text = Class16.smethod_0(1649016441);
		listBox_4.BackColor = Color.FromArgb(32, 32, 32);
		listBox_4.Dock = DockStyle.Fill;
		listBox_4.ForeColor = Color.White;
		listBox_4.FormattingEnabled = true;
		listBox_4.Location = new Point(3, 16);
		listBox_4.Name = Class16.smethod_0(1649016522);
		listBox_4.Size = new Size(232, 434);
		listBox_4.TabIndex = 0;
		listBox_4.SelectedIndexChanged += listBox_4_SelectedIndexChanged;
		panel_4.Controls.Add(button_12);
		panel_4.Controls.Add(button_13);
		panel_4.Dock = DockStyle.Bottom;
		panel_4.Location = new Point(3, 450);
		panel_4.Name = Class16.smethod_0(1649016547);
		panel_4.Size = new Size(232, 30);
		panel_4.TabIndex = 1;
		button_12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_12.BackColor = Color.IndianRed;
		button_12.ForeColor = Color.White;
		button_12.Location = new Point(157, 3);
		button_12.Name = Class16.smethod_0(1649016576);
		button_12.Size = new Size(75, 23);
		button_12.TabIndex = 1;
		button_12.Text = Class16.smethod_0(1648931371);
		button_12.UseVisualStyleBackColor = false;
		button_12.Click += button_12_Click;
		button_13.BackColor = Color.SteelBlue;
		button_13.ForeColor = Color.White;
		button_13.Location = new Point(3, 3);
		button_13.Name = Class16.smethod_0(1649016613);
		button_13.Size = new Size(75, 23);
		button_13.TabIndex = 0;
		button_13.Text = Class16.smethod_0(1648931361);
		button_13.UseVisualStyleBackColor = false;
		button_13.Click += button_13_Click;
		groupBox_11.Controls.Add(label_16);
		groupBox_11.Controls.Add(groupBox_14);
		groupBox_11.Controls.Add(button_14);
		groupBox_11.Controls.Add(groupBox_12);
		groupBox_11.Controls.Add(groupBox_13);
		groupBox_11.Dock = DockStyle.Fill;
		groupBox_11.Location = new Point(0, 0);
		groupBox_11.Name = Class16.smethod_0(1649016639);
		groupBox_11.Size = new Size(528, 483);
		groupBox_11.TabIndex = 0;
		groupBox_11.TabStop = false;
		groupBox_11.Text = Class16.smethod_0(1649016671);
		label_16.AutoSize = true;
		label_16.Location = new Point(6, 16);
		label_16.Name = Class16.smethod_0(1649016689);
		label_16.Size = new Size(100, 13);
		label_16.TabIndex = 4;
		label_16.Text = Class16.smethod_0(1649016724);
		groupBox_14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_14.Controls.Add(label_17);
		groupBox_14.Controls.Add(label_18);
		groupBox_14.Controls.Add(textBox_15);
		groupBox_14.Controls.Add(textBox_16);
		groupBox_14.Enabled = false;
		groupBox_14.Location = new Point(6, 209);
		groupBox_14.Name = Class16.smethod_0(1649016750);
		groupBox_14.Size = new Size(516, 68);
		groupBox_14.TabIndex = 3;
		groupBox_14.TabStop = false;
		groupBox_14.Text = Class16.smethod_0(1649016771);
		label_17.AutoSize = true;
		label_17.Location = new Point(332, 26);
		label_17.Name = Class16.smethod_0(1649016793);
		label_17.Size = new Size(43, 13);
		label_17.TabIndex = 3;
		label_17.Text = Class16.smethod_0(1649016819);
		label_18.AutoSize = true;
		label_18.Location = new Point(12, 26);
		label_18.Name = Class16.smethod_0(1649015810);
		label_18.Size = new Size(43, 13);
		label_18.TabIndex = 2;
		label_18.Text = Class16.smethod_0(1649015844);
		textBox_15.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_15.Location = new Point(381, 23);
		textBox_15.Name = Class16.smethod_0(1649015851);
		textBox_15.Size = new Size(120, 20);
		textBox_15.TabIndex = 1;
		textBox_15.TextChanged += textBox_16_TextChanged;
		textBox_16.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_16.Location = new Point(61, 23);
		textBox_16.Name = Class16.smethod_0(1649015887);
		textBox_16.Size = new Size(114, 20);
		textBox_16.TabIndex = 0;
		textBox_16.TextChanged += textBox_16_TextChanged;
		button_14.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_14.BackColor = Color.ForestGreen;
		button_14.ForeColor = Color.White;
		button_14.Location = new Point(447, 454);
		button_14.Name = Class16.smethod_0(1649015907);
		button_14.Size = new Size(75, 23);
		button_14.TabIndex = 2;
		button_14.Text = Class16.smethod_0(1649013865);
		button_14.UseVisualStyleBackColor = false;
		button_14.Click += button_14_Click;
		groupBox_12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_12.Controls.Add(label_12);
		groupBox_12.Controls.Add(textBox_11);
		groupBox_12.Location = new Point(6, 143);
		groupBox_12.Name = Class16.smethod_0(1649015936);
		groupBox_12.Size = new Size(516, 60);
		groupBox_12.TabIndex = 1;
		groupBox_12.TabStop = false;
		groupBox_12.Text = Class16.smethod_0(1649015972);
		label_12.AutoSize = true;
		label_12.Location = new Point(12, 26);
		label_12.Name = Class16.smethod_0(1649015986);
		label_12.Size = new Size(30, 13);
		label_12.TabIndex = 1;
		label_12.Text = Class16.smethod_0(1649016011);
		textBox_11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_11.Location = new Point(48, 23);
		textBox_11.Name = Class16.smethod_0(1649016030);
		textBox_11.Size = new Size(462, 20);
		textBox_11.TabIndex = 0;
		textBox_11.TextChanged += textBox_11_TextChanged;
		groupBox_13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_13.Controls.Add(label_13);
		groupBox_13.Controls.Add(label_14);
		groupBox_13.Controls.Add(label_15);
		groupBox_13.Controls.Add(textBox_12);
		groupBox_13.Controls.Add(textBox_13);
		groupBox_13.Controls.Add(textBox_14);
		groupBox_13.Location = new Point(6, 32);
		groupBox_13.Name = Class16.smethod_0(1649016049);
		groupBox_13.Size = new Size(516, 105);
		groupBox_13.TabIndex = 0;
		groupBox_13.TabStop = false;
		groupBox_13.Text = Class16.smethod_0(1649016080);
		label_13.AutoSize = true;
		label_13.Location = new Point(12, 78);
		label_13.Name = Class16.smethod_0(1649016105);
		label_13.Size = new Size(42, 13);
		label_13.TabIndex = 5;
		label_13.Text = Class16.smethod_0(1649016123);
		label_14.AutoSize = true;
		label_14.Location = new Point(12, 52);
		label_14.Name = Class16.smethod_0(1649016137);
		label_14.Size = new Size(33, 13);
		label_14.TabIndex = 4;
		label_14.Text = Class16.smethod_0(1649016153);
		label_15.AutoSize = true;
		label_15.Location = new Point(12, 26);
		label_15.Name = Class16.smethod_0(1649016173);
		label_15.Size = new Size(29, 13);
		label_15.TabIndex = 3;
		label_15.Text = Class16.smethod_0(1649016188);
		textBox_12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_12.Location = new Point(60, 75);
		textBox_12.Name = Class16.smethod_0(1649016199);
		textBox_12.Size = new Size(450, 20);
		textBox_12.TabIndex = 2;
		textBox_13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_13.Location = new Point(60, 49);
		textBox_13.Name = Class16.smethod_0(1649016211);
		textBox_13.Size = new Size(450, 20);
		textBox_13.TabIndex = 1;
		textBox_14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_14.Location = new Point(60, 23);
		textBox_14.Name = Class16.smethod_0(1649016237);
		textBox_14.Size = new Size(450, 20);
		textBox_14.TabIndex = 0;
		tabPage_6.BackColor = Color.FromArgb(239, 244, 250);
		tabPage_6.Controls.Add(splitContainer_5);
		tabPage_6.Enabled = false;
		tabPage_6.Location = new Point(4, 22);
		tabPage_6.Name = Class16.smethod_0(1649016254);
		tabPage_6.Padding = new Padding(3);
		tabPage_6.Size = new Size(776, 489);
		tabPage_6.TabIndex = 2;
		tabPage_6.Text = Class16.smethod_0(1649016272);
		splitContainer_5.Dock = DockStyle.Fill;
		splitContainer_5.Location = new Point(3, 3);
		splitContainer_5.Name = Class16.smethod_0(1649016302);
		splitContainer_5.Panel1.Controls.Add(groupBox_15);
		splitContainer_5.Panel2.Controls.Add(groupBox_16);
		splitContainer_5.Size = new Size(770, 483);
		splitContainer_5.SplitterDistance = 238;
		splitContainer_5.TabIndex = 0;
		groupBox_15.Controls.Add(listBox_5);
		groupBox_15.Controls.Add(panel_5);
		groupBox_15.Dock = DockStyle.Fill;
		groupBox_15.Location = new Point(0, 0);
		groupBox_15.Name = Class16.smethod_0(1649015311);
		groupBox_15.Size = new Size(238, 483);
		groupBox_15.TabIndex = 0;
		groupBox_15.TabStop = false;
		groupBox_15.Text = Class16.smethod_0(1649015342);
		listBox_5.BackColor = Color.FromArgb(32, 32, 32);
		listBox_5.Dock = DockStyle.Fill;
		listBox_5.ForeColor = Color.White;
		listBox_5.FormattingEnabled = true;
		listBox_5.Location = new Point(3, 16);
		listBox_5.Name = Class16.smethod_0(1649015366);
		listBox_5.Size = new Size(232, 434);
		listBox_5.TabIndex = 0;
		listBox_5.SelectedIndexChanged += listBox_5_SelectedIndexChanged;
		panel_5.Controls.Add(button_15);
		panel_5.Controls.Add(button_16);
		panel_5.Dock = DockStyle.Bottom;
		panel_5.Location = new Point(3, 450);
		panel_5.Name = Class16.smethod_0(1649015384);
		panel_5.Size = new Size(232, 30);
		panel_5.TabIndex = 1;
		button_15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_15.BackColor = Color.IndianRed;
		button_15.ForeColor = Color.White;
		button_15.Location = new Point(157, 3);
		button_15.Name = Class16.smethod_0(1649015422);
		button_15.Size = new Size(75, 23);
		button_15.TabIndex = 1;
		button_15.Text = Class16.smethod_0(1648931371);
		button_15.UseVisualStyleBackColor = false;
		button_15.Click += button_15_Click;
		button_16.BackColor = Color.SteelBlue;
		button_16.ForeColor = Color.White;
		button_16.Location = new Point(3, 3);
		button_16.Name = Class16.smethod_0(1649015452);
		button_16.Size = new Size(75, 23);
		button_16.TabIndex = 0;
		button_16.Text = Class16.smethod_0(1648931361);
		button_16.UseVisualStyleBackColor = false;
		button_16.Click += button_16_Click;
		groupBox_16.Controls.Add(button_17);
		groupBox_16.Controls.Add(groupBox_17);
		groupBox_16.Controls.Add(groupBox_18);
		groupBox_16.Dock = DockStyle.Fill;
		groupBox_16.Location = new Point(0, 0);
		groupBox_16.Name = Class16.smethod_0(1649015479);
		groupBox_16.Size = new Size(528, 483);
		groupBox_16.TabIndex = 0;
		groupBox_16.TabStop = false;
		groupBox_16.Text = Class16.smethod_0(1649015504);
		button_17.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_17.BackColor = Color.ForestGreen;
		button_17.ForeColor = Color.White;
		button_17.Location = new Point(447, 454);
		button_17.Name = Class16.smethod_0(1649015540);
		button_17.Size = new Size(75, 23);
		button_17.TabIndex = 2;
		button_17.Text = Class16.smethod_0(1649013865);
		button_17.UseVisualStyleBackColor = false;
		button_17.Click += button_17_Click;
		groupBox_17.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_17.Controls.Add(label_19);
		groupBox_17.Controls.Add(textBox_17);
		groupBox_17.Location = new Point(6, 130);
		groupBox_17.Name = Class16.smethod_0(1649015562);
		groupBox_17.Size = new Size(516, 60);
		groupBox_17.TabIndex = 1;
		groupBox_17.TabStop = false;
		groupBox_17.Text = Class16.smethod_0(1649015599);
		label_19.AutoSize = true;
		label_19.Location = new Point(12, 26);
		label_19.Name = Class16.smethod_0(1649015618);
		label_19.Size = new Size(30, 13);
		label_19.TabIndex = 1;
		label_19.Text = Class16.smethod_0(1649016011);
		textBox_17.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_17.Location = new Point(48, 23);
		textBox_17.Name = Class16.smethod_0(1649015652);
		textBox_17.Size = new Size(462, 20);
		textBox_17.TabIndex = 0;
		textBox_17.TextChanged += textBox_17_TextChanged;
		groupBox_18.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_18.Controls.Add(label_20);
		groupBox_18.Controls.Add(label_21);
		groupBox_18.Controls.Add(label_22);
		groupBox_18.Controls.Add(textBox_18);
		groupBox_18.Controls.Add(textBox_19);
		groupBox_18.Controls.Add(textBox_20);
		groupBox_18.Location = new Point(6, 19);
		groupBox_18.Name = Class16.smethod_0(1649015672);
		groupBox_18.Size = new Size(516, 105);
		groupBox_18.TabIndex = 0;
		groupBox_18.TabStop = false;
		groupBox_18.Text = Class16.smethod_0(1649015704);
		label_20.AutoSize = true;
		label_20.Location = new Point(12, 78);
		label_20.Name = Class16.smethod_0(1649015742);
		label_20.Size = new Size(42, 13);
		label_20.TabIndex = 5;
		label_20.Text = Class16.smethod_0(1649016123);
		label_21.AutoSize = true;
		label_21.Location = new Point(12, 52);
		label_21.Name = Class16.smethod_0(1649015753);
		label_21.Size = new Size(33, 13);
		label_21.TabIndex = 4;
		label_21.Text = Class16.smethod_0(1649016153);
		label_22.AutoSize = true;
		label_22.Location = new Point(12, 26);
		label_22.Name = Class16.smethod_0(1649015770);
		label_22.Size = new Size(29, 13);
		label_22.TabIndex = 3;
		label_22.Text = Class16.smethod_0(1649016188);
		textBox_18.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_18.Location = new Point(60, 75);
		textBox_18.Name = Class16.smethod_0(1649015786);
		textBox_18.Size = new Size(450, 20);
		textBox_18.TabIndex = 2;
		textBox_18.TextChanged += textBox_20_TextChanged;
		textBox_19.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_19.Location = new Point(60, 49);
		textBox_19.Name = Class16.smethod_0(1649014791);
		textBox_19.Size = new Size(450, 20);
		textBox_19.TabIndex = 1;
		textBox_19.TextChanged += textBox_20_TextChanged;
		textBox_20.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_20.Location = new Point(60, 23);
		textBox_20.Name = Class16.smethod_0(1649014802);
		textBox_20.Size = new Size(450, 20);
		textBox_20.TabIndex = 0;
		textBox_20.TextChanged += textBox_20_TextChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(784, 561);
		base.Controls.Add(tabControl_0);
		base.Controls.Add(statusStrip_0);
		base.Controls.Add(menuStrip_0);
		base.Icon = Resources.Domain2Editor_Icon;
		base.MainMenuStrip = menuStrip_0;
		MinimumSize = new Size(800, 600);
		base.Name = Class16.smethod_0(1649014828);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649014843);
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		statusStrip_0.ResumeLayout(performLayout: false);
		statusStrip_0.PerformLayout();
		tabControl_0.ResumeLayout(performLayout: false);
		tabPage_0.ResumeLayout(performLayout: false);
		splitContainer_0.Panel1.ResumeLayout(performLayout: false);
		splitContainer_0.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_0).EndInit();
		splitContainer_0.ResumeLayout(performLayout: false);
		groupBox_0.ResumeLayout(performLayout: false);
		panel_0.ResumeLayout(performLayout: false);
		groupBox_1.ResumeLayout(performLayout: false);
		tabControl_1.ResumeLayout(performLayout: false);
		tabPage_1.ResumeLayout(performLayout: false);
		groupBox_2.ResumeLayout(performLayout: false);
		groupBox_2.PerformLayout();
		groupBox_3.ResumeLayout(performLayout: false);
		groupBox_3.PerformLayout();
		tabPage_2.ResumeLayout(performLayout: false);
		splitContainer_1.Panel1.ResumeLayout(performLayout: false);
		splitContainer_1.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_1).EndInit();
		splitContainer_1.ResumeLayout(performLayout: false);
		groupBox_4.ResumeLayout(performLayout: false);
		panel_1.ResumeLayout(performLayout: false);
		groupBox_5.ResumeLayout(performLayout: false);
		groupBox_5.PerformLayout();
		tabPage_3.ResumeLayout(performLayout: false);
		splitContainer_2.Panel1.ResumeLayout(performLayout: false);
		splitContainer_2.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_2).EndInit();
		splitContainer_2.ResumeLayout(performLayout: false);
		groupBox_6.ResumeLayout(performLayout: false);
		panel_2.ResumeLayout(performLayout: false);
		groupBox_7.ResumeLayout(performLayout: false);
		groupBox_7.PerformLayout();
		tabPage_4.ResumeLayout(performLayout: false);
		splitContainer_3.Panel1.ResumeLayout(performLayout: false);
		splitContainer_3.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_3).EndInit();
		splitContainer_3.ResumeLayout(performLayout: false);
		groupBox_8.ResumeLayout(performLayout: false);
		panel_3.ResumeLayout(performLayout: false);
		groupBox_9.ResumeLayout(performLayout: false);
		groupBox_9.PerformLayout();
		tabPage_5.ResumeLayout(performLayout: false);
		splitContainer_4.Panel1.ResumeLayout(performLayout: false);
		splitContainer_4.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_4).EndInit();
		splitContainer_4.ResumeLayout(performLayout: false);
		groupBox_10.ResumeLayout(performLayout: false);
		panel_4.ResumeLayout(performLayout: false);
		groupBox_11.ResumeLayout(performLayout: false);
		groupBox_11.PerformLayout();
		groupBox_14.ResumeLayout(performLayout: false);
		groupBox_14.PerformLayout();
		groupBox_12.ResumeLayout(performLayout: false);
		groupBox_12.PerformLayout();
		groupBox_13.ResumeLayout(performLayout: false);
		groupBox_13.PerformLayout();
		tabPage_6.ResumeLayout(performLayout: false);
		splitContainer_5.Panel1.ResumeLayout(performLayout: false);
		splitContainer_5.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_5).EndInit();
		splitContainer_5.ResumeLayout(performLayout: false);
		groupBox_15.ResumeLayout(performLayout: false);
		panel_5.ResumeLayout(performLayout: false);
		groupBox_16.ResumeLayout(performLayout: false);
		groupBox_17.ResumeLayout(performLayout: false);
		groupBox_17.PerformLayout();
		groupBox_18.ResumeLayout(performLayout: false);
		groupBox_18.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649014871);
		openFileDialog.Title = TextStorage.Msg(Class16.smethod_0(1649014888));
		if (openFileDialog.ShowDialog() != DialogResult.OK || !File.Exists(openFileDialog.FileName))
		{
			return;
		}
		EditorSessionTracker.LogFolderAccess(openFileDialog.FileName, Class16.smethod_0(1649014925), Class16.smethod_0(1649014943));
		method_1();
		try
		{
			using (FileStream fileStream = File.OpenRead(openFileDialog.FileName))
			{
				BinaryReader binaryReader = new BinaryReader(fileStream);
				try
				{
					if (fileStream.Length < 8L)
					{
						DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649014956), Class16.smethod_0(1649014988)).Replace(Class16.smethod_0(1648912699), Class16.smethod_0(1649015010)), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					magic = binaryReader.ReadBytes(4);
					count = binaryReader.ReadInt32();
					for (int i = 0; i < count; i++)
					{
						if (binaryReader.BaseStream.Position + 32L + 24L <= binaryReader.BaseStream.Length)
						{
							byte[] bytes = binaryReader.ReadBytes(32);
							string item = Encoding.Unicode.GetString(bytes).TrimEnd(default(char));
							name.Add(item);
							this.id.Add(binaryReader.ReadInt32());
							type.Add(binaryReader.ReadInt32());
							reward.Add(binaryReader.ReadInt32());
							iconposX.Add(binaryReader.ReadInt32());
							iconposY.Add(binaryReader.ReadInt32());
							int num = binaryReader.ReadInt32();
							pointscount.Add(num);
							if (num >= 0 && binaryReader.BaseStream.Position + num * 8L <= binaryReader.BaseStream.Length)
							{
								List<Point> list = new List<Point>();
								for (int j = 0; j < num; j++)
								{
									int num2 = binaryReader.ReadInt32();
									int num3 = binaryReader.ReadInt32();
									list.Add(new Point(num2, num3));
								}
								points.Add(list);
								int num4 = binaryReader.ReadInt32();
								trianglescount.Add(num4);
								if (num4 >= 0 && binaryReader.BaseStream.Position + num4 * 12L <= binaryReader.BaseStream.Length)
								{
									List<Triangle> list2 = new List<Triangle>();
									for (int k = 0; k < num4; k++)
									{
										int id = binaryReader.ReadInt32();
										int id2 = binaryReader.ReadInt32();
										int id3 = binaryReader.ReadInt32();
										list2.Add(new Triangle(id, id2, id3));
									}
									triangles.Add(list2);
									int num5 = binaryReader.ReadInt32();
									neighborscount.Add(num5);
									if (num5 >= 0 && binaryReader.BaseStream.Position + num5 * 4L <= binaryReader.BaseStream.Length)
									{
										List<int> list3 = new List<int>();
										for (int l = 0; l < num5; l++)
										{
											list3.Add(binaryReader.ReadInt32());
										}
										neighbors.Add(list3);
										continue;
									}
									throw new EndOfStreamException(TextStorage.Msg(Class16.smethod_0(1649015039), Class16.smethod_0(1649015065)));
								}
								throw new EndOfStreamException(TextStorage.Msg(Class16.smethod_0(1649015039), Class16.smethod_0(1649015065)));
							}
							throw new EndOfStreamException(TextStorage.Msg(Class16.smethod_0(1649015039), Class16.smethod_0(1649015065)));
						}
						throw new EndOfStreamException(TextStorage.Msg(Class16.smethod_0(1649015039), Class16.smethod_0(1649015065)));
					}
					if (binaryReader.BaseStream.Position + 4L > binaryReader.BaseStream.Length)
					{
						throw new EndOfStreamException(TextStorage.Msg(Class16.smethod_0(1649015039), Class16.smethod_0(1649015065)));
					}
					battletimecount = binaryReader.ReadInt32();
					for (int m = 0; m < battletimecount; m++)
					{
						day.Add(binaryReader.ReadInt32());
						hour.Add(binaryReader.ReadInt32());
						minute.Add(binaryReader.ReadInt32());
					}
					battletime_max = binaryReader.ReadInt32();
					long num6 = binaryReader.BaseStream.Length - binaryReader.BaseStream.Position;
					if (num6 >= 8L)
					{
						long position = binaryReader.BaseStream.Position;
						int num7 = binaryReader.ReadInt32();
						long num8 = 4L + num7 * 12L + 4L;
						binaryReader.BaseStream.Position = position;
						if (num7 >= 0 && num6 == num8)
						{
							version = 2;
							battletimecount2 = binaryReader.ReadInt32();
							for (int n = 0; n < battletimecount2; n++)
							{
								day2.Add(binaryReader.ReadInt32());
								hour2.Add(binaryReader.ReadInt32());
								minute2.Add(binaryReader.ReadInt32());
							}
							battletime_max2 = binaryReader.ReadInt32();
						}
						else
						{
							version = 1;
							version1Extra1 = binaryReader.ReadInt32();
							version1Extra2 = binaryReader.ReadInt32();
						}
					}
					else
					{
						version = 1;
					}
					method_6();
					method_7();
					method_20();
					method_21();
					method_3();
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649015126), Class16.smethod_0(1649015166)), version, System.IO.Path.GetFileName(openFileDialog.FileName));
		}
		catch (Exception ex)
		{
			if ((ex is EndOfStreamException || ex is InvalidDataException) ? true : false)
			{
				SentryHelper.CaptureMessage(Class16.smethod_0(1649015201) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649015250));
			}
			else
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649014828));
			}
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649014956), Class16.smethod_0(1649014988)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		if (count == 0)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649015290)), Class16.smethod_0(1649010207), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = Class16.smethod_0(1649014871);
		saveFileDialog.Title = TextStorage.Msg(Class16.smethod_0(1649010217));
		if (saveFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		EditorSessionTracker.LogFolderAccess(saveFileDialog.FileName, Class16.smethod_0(1649010254), Class16.smethod_0(1649014943));
		try
		{
			FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(fileStream);
				try
				{
					binaryWriter.Write(magic);
					binaryWriter.Write(count);
					for (int i = 0; i < count; i++)
					{
						byte[] array = new byte[32];
						byte[] bytes = Encoding.Unicode.GetBytes(name[i]);
						Array.Copy(bytes, array, Math.Min(bytes.Length, 32));
						binaryWriter.Write(array);
						binaryWriter.Write(id[i]);
						binaryWriter.Write(type[i]);
						binaryWriter.Write(reward[i]);
						binaryWriter.Write(iconposX[i]);
						binaryWriter.Write(iconposY[i]);
						binaryWriter.Write(pointscount[i]);
						for (int j = 0; j < pointscount[i]; j++)
						{
							binaryWriter.Write(points[i][j].X);
							binaryWriter.Write(points[i][j].Y);
						}
						binaryWriter.Write(trianglescount[i]);
						for (int k = 0; k < trianglescount[i]; k++)
						{
							binaryWriter.Write(triangles[i][k].id1);
							binaryWriter.Write(triangles[i][k].id2);
							binaryWriter.Write(triangles[i][k].id3);
						}
						binaryWriter.Write(neighborscount[i]);
						for (int l = 0; l < neighborscount[i]; l++)
						{
							binaryWriter.Write(neighbors[i][l]);
						}
					}
					binaryWriter.Write(battletimecount);
					for (int m = 0; m < battletimecount; m++)
					{
						binaryWriter.Write(day[m]);
						binaryWriter.Write(hour[m]);
						binaryWriter.Write(minute[m]);
					}
					binaryWriter.Write(battletime_max);
					int num = version;
					if (num != 2 && battletimecount2 > 0)
					{
						num = 2;
					}
					if (num == 2)
					{
						binaryWriter.Write(battletimecount2);
						for (int n = 0; n < battletimecount2; n++)
						{
							binaryWriter.Write(day2[n]);
							binaryWriter.Write(hour2[n]);
							binaryWriter.Write(minute2[n]);
						}
						binaryWriter.Write(battletime_max2);
						version = 2;
					}
					else
					{
						binaryWriter.Write(version1Extra1);
						binaryWriter.Write(version1Extra2);
						version = 1;
					}
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
			method_3();
			toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649010266), Class16.smethod_0(1649010305)), version, System.IO.Path.GetFileName(saveFileDialog.FileName));
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649014828));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649010347), Class16.smethod_0(1649010378)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		if (count == 0)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649015290)), Class16.smethod_0(1649010207), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = Class16.smethod_0(1649010415);
		saveFileDialog.Title = TextStorage.Msg(Class16.smethod_0(1649010438));
		if (saveFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(fileStream);
				try
				{
					binaryWriter.Write(count);
					for (int i = 0; i < count; i++)
					{
						binaryWriter.Write(id[i]);
						binaryWriter.Write(type[i]);
						binaryWriter.Write(reward[i]);
						binaryWriter.Write(neighborscount[i]);
						for (int j = 0; j < neighborscount[i]; j++)
						{
							binaryWriter.Write(neighbors[i][j]);
						}
					}
					binaryWriter.Write(battletimecount);
					for (int k = 0; k < battletimecount; k++)
					{
						binaryWriter.Write(day[k]);
						binaryWriter.Write(hour[k]);
						binaryWriter.Write(minute[k]);
					}
					binaryWriter.Write(battletime_max);
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
			toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649010458), Class16.smethod_0(1649010510)), System.IO.Path.GetFileName(saveFileDialog.FileName));
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649014828));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649010544), Class16.smethod_0(1649010579)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_6()
	{
		List<int> list = method_8(listBox_0);
		listBox_0.BeginUpdate();
		listBox_0.Items.Clear();
		for (int i = 0; i < count; i++)
		{
			string item = string.Format(Class16.smethod_0(1649010620), i + 1, name[i], id[i]);
			listBox_0.Items.Add(item);
		}
		listBox_0.EndUpdate();
		foreach (int item2 in list)
		{
			if (item2 >= 0 && item2 < listBox_0.Items.Count)
			{
				listBox_0.SetSelected(item2, value: true);
			}
		}
	}

	private void method_7()
	{
		List<int> list = method_8(listBox_4);
		listBox_4.BeginUpdate();
		listBox_4.Items.Clear();
		for (int i = 0; i < battletimecount; i++)
		{
			string item = string.Format(Class16.smethod_0(1649010646), i + 1, day[i], hour[i], minute[i]);
			listBox_4.Items.Add(item);
		}
		listBox_4.EndUpdate();
		foreach (int item2 in list)
		{
			if (item2 >= 0 && item2 < listBox_4.Items.Count)
			{
				listBox_4.SetSelected(item2, value: true);
			}
		}
		bool_0 = true;
		textBox_11.Text = battletime_max.ToString();
		bool_0 = false;
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		method_1();
		toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649010683));
	}

	private void toolStripMenuItem_5_Click(object sender, EventArgs e)
	{
		if (this.BeginInvokeSafe(method_31))
		{
			return;
		}
		try
		{
			Application.ExitThread();
		}
		catch
		{
			Close();
		}
	}

	private List<int> method_8(ListBox listBox_6)
	{
		List<int> list = new List<int>();
		foreach (int selectedIndex in listBox_6.SelectedIndices)
		{
			list.Add(selectedIndex);
		}
		return list;
	}

	private int? method_9()
	{
		if (listBox_0.SelectedIndices.Count == 0)
		{
			return null;
		}
		return listBox_0.SelectedIndices[0];
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			if (count != 0 && listBox_0.SelectedIndices.Count != 0)
			{
				int num = listBox_0.SelectedIndices[0];
				bool_0 = true;
				textBox_4.Text = name[num];
				textBox_3.Text = id[num].ToString();
				comboBox_0.SelectedIndex = type[num];
				textBox_2.Text = reward[num].ToString();
				textBox_1.Text = iconposX[num].ToString();
				textBox_0.Text = iconposY[num].ToString();
				bool_0 = false;
				method_10(num);
				method_11(num);
				method_12(num);
			}
			else
			{
				method_13();
			}
		}
	}

	private void method_10(int int_0)
	{
		List<int> list = method_8(listBox_1);
		listBox_1.Items.Clear();
		if (int_0 < 0 || int_0 >= points.Count)
		{
			return;
		}
		for (int i = 0; i < pointscount[int_0]; i++)
		{
			Point point = points[int_0][i];
			string item = string.Format(Class16.smethod_0(1649009692), i + 1, point.X, point.Y);
			listBox_1.Items.Add(item);
		}
		foreach (int item2 in list)
		{
			if (item2 >= 0 && item2 < listBox_1.Items.Count)
			{
				listBox_1.SetSelected(item2, value: true);
			}
		}
	}

	private void method_11(int int_0)
	{
		List<int> list = method_8(listBox_2);
		listBox_2.Items.Clear();
		if (int_0 < 0 || int_0 >= triangles.Count)
		{
			return;
		}
		for (int i = 0; i < trianglescount[int_0]; i++)
		{
			Triangle triangle = triangles[int_0][i];
			string item = string.Format(Class16.smethod_0(1648942820), i + 1, triangle);
			listBox_2.Items.Add(item);
		}
		foreach (int item2 in list)
		{
			if (item2 >= 0 && item2 < listBox_2.Items.Count)
			{
				listBox_2.SetSelected(item2, value: true);
			}
		}
	}

	private void method_12(int int_0)
	{
		List<int> list = method_8(listBox_3);
		listBox_3.Items.Clear();
		if (int_0 < 0 || int_0 >= neighbors.Count)
		{
			return;
		}
		for (int i = 0; i < neighborscount[int_0]; i++)
		{
			string item = string.Format(Class16.smethod_0(1649009719), i + 1, neighbors[int_0][i]);
			listBox_3.Items.Add(item);
		}
		foreach (int item2 in list)
		{
			if (item2 >= 0 && item2 < listBox_3.Items.Count)
			{
				listBox_3.SetSelected(item2, value: true);
			}
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_26();
		name.Add(Class16.smethod_0(1649009731));
		id.Add(count + 1);
		type.Add(0);
		reward.Add(0);
		iconposX.Add(0);
		iconposY.Add(0);
		pointscount.Add(0);
		points.Add(new List<Point>());
		trianglescount.Add(0);
		triangles.Add(new List<Triangle>());
		neighborscount.Add(0);
		neighbors.Add(new List<int>());
		count++;
		method_6();
		if (listBox_0.Items.Count > 0)
		{
			listBox_0.ClearSelected();
			listBox_0.SetSelected(count - 1, value: true);
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (count == 0 || listBox_0.SelectedIndices.Count == 0)
		{
			return;
		}
		method_26();
		List<int> list = method_8(listBox_0);
		list.Sort();
		list.Reverse();
		foreach (int item in list)
		{
			name.RemoveAt(item);
			id.RemoveAt(item);
			type.RemoveAt(item);
			reward.RemoveAt(item);
			iconposX.RemoveAt(item);
			iconposY.RemoveAt(item);
			pointscount.RemoveAt(item);
			points.RemoveAt(item);
			trianglescount.RemoveAt(item);
			triangles.RemoveAt(item);
			neighborscount.RemoveAt(item);
			neighbors.RemoveAt(item);
			count--;
		}
		method_6();
		method_13();
	}

	private void method_13()
	{
		bool_0 = true;
		textBox_4.Text = string.Empty;
		textBox_3.Text = string.Empty;
		comboBox_0.SelectedIndex = -1;
		textBox_2.Text = string.Empty;
		textBox_1.Text = string.Empty;
		textBox_0.Text = string.Empty;
		textBox_6.Text = string.Empty;
		textBox_5.Text = string.Empty;
		textBox_9.Text = string.Empty;
		textBox_8.Text = string.Empty;
		textBox_7.Text = string.Empty;
		textBox_10.Text = string.Empty;
		listBox_1.Items.Clear();
		listBox_2.Items.Clear();
		listBox_3.Items.Clear();
		bool_0 = false;
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_14();
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		method_28(sender as Control);
		method_14();
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_28(sender as Control);
		method_14();
	}

	private void method_14()
	{
		if (bool_0 || listBox_0.SelectedIndices.Count == 0)
		{
			return;
		}
		if (textBox_4.Text.Length > 15)
		{
			bool_0 = true;
			textBox_4.Text = textBox_4.Text.Substring(0, 15);
			textBox_4.SelectionStart = textBox_4.Text.Length;
			bool_0 = false;
		}
		foreach (int selectedIndex in listBox_0.SelectedIndices)
		{
			name[selectedIndex] = textBox_4.Text;
			if (int.TryParse(textBox_3.Text, out var result))
			{
				id[selectedIndex] = result;
			}
			if (comboBox_0.SelectedIndex >= 0)
			{
				type[selectedIndex] = comboBox_0.SelectedIndex;
			}
			if (int.TryParse(textBox_2.Text, out var result2))
			{
				reward[selectedIndex] = result2;
			}
			if (int.TryParse(textBox_1.Text, out var result3))
			{
				iconposX[selectedIndex] = result3;
			}
			if (int.TryParse(textBox_0.Text, out var result4))
			{
				iconposY[selectedIndex] = result4;
			}
		}
		method_6();
	}

	private void listBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		int? num = method_9();
		if (count != 0 && num.HasValue && listBox_1.SelectedIndices.Count != 0)
		{
			int num2 = listBox_1.SelectedIndices[0];
			if (num2 >= 0 && num2 < points[num.Value].Count)
			{
				Point point = points[num.Value][num2];
				bool_0 = true;
				textBox_6.Text = point.X.ToString();
				textBox_5.Text = point.Y.ToString();
				bool_0 = false;
			}
		}
		else
		{
			bool_0 = true;
			textBox_6.Text = string.Empty;
			textBox_5.Text = string.Empty;
			bool_0 = false;
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		int? num = method_9();
		if (count != 0 && num.HasValue)
		{
			method_26();
			points[num.Value].Add(new Point(0, 0));
			pointscount[num.Value]++;
			method_10(num.Value);
			if (pointscount[num.Value] > 0)
			{
				listBox_1.ClearSelected();
				listBox_1.SetSelected(pointscount[num.Value] - 1, value: true);
			}
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		int? num = method_9();
		if (count == 0 || !num.HasValue || listBox_1.SelectedIndices.Count == 0)
		{
			return;
		}
		method_26();
		List<int> list = method_8(listBox_1);
		list.Sort();
		list.Reverse();
		foreach (int item in list)
		{
			if (item >= 0 && item < points[num.Value].Count)
			{
				points[num.Value].RemoveAt(item);
				pointscount[num.Value]--;
			}
		}
		method_10(num.Value);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		method_15();
	}

	private void textBox_5_TextChanged(object sender, EventArgs e)
	{
		method_28(sender as Control);
		method_15();
	}

	private void method_15()
	{
		if (bool_0)
		{
			return;
		}
		int? num = method_9();
		if (!num.HasValue || listBox_1.SelectedIndices.Count == 0 || !int.TryParse(textBox_6.Text, out var result) || !int.TryParse(textBox_5.Text, out var result2))
		{
			return;
		}
		foreach (int selectedIndex in listBox_1.SelectedIndices)
		{
			if (selectedIndex >= 0 && selectedIndex < points[num.Value].Count)
			{
				points[num.Value][selectedIndex] = new Point(result, result2);
			}
		}
		method_10(num.Value);
	}

	private void listBox_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		int? num = method_9();
		if (count != 0 && num.HasValue && listBox_2.SelectedIndices.Count != 0)
		{
			int num2 = listBox_2.SelectedIndices[0];
			if (num2 >= 0 && num2 < triangles[num.Value].Count)
			{
				Triangle triangle = triangles[num.Value][num2];
				bool_0 = true;
				textBox_9.Text = triangle.id1.ToString();
				textBox_8.Text = triangle.id2.ToString();
				textBox_7.Text = triangle.id3.ToString();
				bool_0 = false;
			}
		}
		else
		{
			bool_0 = true;
			textBox_9.Text = string.Empty;
			textBox_8.Text = string.Empty;
			textBox_7.Text = string.Empty;
			bool_0 = false;
		}
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		int? num = method_9();
		if (count != 0 && num.HasValue)
		{
			method_26();
			triangles[num.Value].Add(new Triangle(0, 0, 0));
			trianglescount[num.Value]++;
			method_11(num.Value);
			if (trianglescount[num.Value] > 0)
			{
				listBox_2.ClearSelected();
				listBox_2.SetSelected(trianglescount[num.Value] - 1, value: true);
			}
		}
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		int? num = method_9();
		if (count == 0 || !num.HasValue || listBox_2.SelectedIndices.Count == 0)
		{
			return;
		}
		method_26();
		List<int> list = method_8(listBox_2);
		list.Sort();
		list.Reverse();
		foreach (int item in list)
		{
			if (item >= 0 && item < triangles[num.Value].Count)
			{
				triangles[num.Value].RemoveAt(item);
				trianglescount[num.Value]--;
			}
		}
		method_11(num.Value);
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		method_16();
	}

	private void textBox_7_TextChanged(object sender, EventArgs e)
	{
		method_28(sender as Control);
		method_16();
	}

	private void method_16()
	{
		if (bool_0)
		{
			return;
		}
		int? num = method_9();
		if (!num.HasValue || listBox_2.SelectedIndices.Count == 0 || !int.TryParse(textBox_9.Text, out var result) || !int.TryParse(textBox_8.Text, out var result2) || !int.TryParse(textBox_7.Text, out var result3))
		{
			return;
		}
		foreach (int selectedIndex in listBox_2.SelectedIndices)
		{
			if (selectedIndex >= 0 && selectedIndex < triangles[num.Value].Count)
			{
				triangles[num.Value][selectedIndex] = new Triangle(result, result2, result3);
			}
		}
		method_11(num.Value);
	}

	private void listBox_3_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		int? num = method_9();
		if (count != 0 && num.HasValue && listBox_3.SelectedIndices.Count != 0)
		{
			int num2 = listBox_3.SelectedIndices[0];
			if (num2 >= 0 && num2 < neighbors[num.Value].Count)
			{
				bool_0 = true;
				textBox_10.Text = neighbors[num.Value][num2].ToString();
				bool_0 = false;
			}
		}
		else
		{
			bool_0 = true;
			textBox_10.Text = string.Empty;
			bool_0 = false;
		}
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		int? num = method_9();
		if (count != 0 && num.HasValue)
		{
			method_26();
			neighbors[num.Value].Add(0);
			neighborscount[num.Value]++;
			method_12(num.Value);
			if (neighborscount[num.Value] > 0)
			{
				listBox_3.ClearSelected();
				listBox_3.SetSelected(neighborscount[num.Value] - 1, value: true);
			}
		}
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		int? num = method_9();
		if (count == 0 || !num.HasValue || listBox_3.SelectedIndices.Count == 0)
		{
			return;
		}
		method_26();
		List<int> list = method_8(listBox_3);
		list.Sort();
		list.Reverse();
		foreach (int item in list)
		{
			if (item >= 0 && item < neighbors[num.Value].Count)
			{
				neighbors[num.Value].RemoveAt(item);
				neighborscount[num.Value]--;
			}
		}
		method_12(num.Value);
	}

	private void button_11_Click(object sender, EventArgs e)
	{
		method_17();
	}

	private void textBox_10_TextChanged(object sender, EventArgs e)
	{
		method_28(sender as Control);
		method_17();
	}

	private void method_17()
	{
		if (bool_0)
		{
			return;
		}
		int? num = method_9();
		if (!num.HasValue || listBox_3.SelectedIndices.Count == 0 || !int.TryParse(textBox_10.Text, out var result))
		{
			return;
		}
		foreach (int selectedIndex in listBox_3.SelectedIndices)
		{
			if (selectedIndex >= 0 && selectedIndex < neighbors[num.Value].Count)
			{
				neighbors[num.Value][selectedIndex] = result;
			}
		}
		method_12(num.Value);
	}

	private void listBox_4_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		if (battletimecount != 0 && listBox_4.SelectedIndices.Count != 0)
		{
			int num = listBox_4.SelectedIndices[0];
			if (num >= 0 && num < battletimecount)
			{
				bool_0 = true;
				textBox_14.Text = day[num].ToString();
				textBox_13.Text = hour[num].ToString();
				textBox_12.Text = minute[num].ToString();
				bool_0 = false;
			}
		}
		else
		{
			bool_0 = true;
			textBox_14.Text = string.Empty;
			textBox_13.Text = string.Empty;
			textBox_12.Text = string.Empty;
			bool_0 = false;
		}
	}

	private void button_13_Click(object sender, EventArgs e)
	{
		method_26();
		day.Add(0);
		hour.Add(0);
		minute.Add(0);
		battletimecount++;
		method_7();
		if (battletimecount > 0)
		{
			listBox_4.ClearSelected();
			listBox_4.SetSelected(battletimecount - 1, value: true);
		}
	}

	private void button_12_Click(object sender, EventArgs e)
	{
		if (battletimecount == 0 || listBox_4.SelectedIndices.Count == 0)
		{
			return;
		}
		method_26();
		List<int> list = method_8(listBox_4);
		list.Sort();
		list.Reverse();
		foreach (int item in list)
		{
			if (item >= 0 && item < battletimecount)
			{
				day.RemoveAt(item);
				hour.RemoveAt(item);
				minute.RemoveAt(item);
				battletimecount--;
			}
		}
		method_7();
	}

	private void button_14_Click(object sender, EventArgs e)
	{
		method_18();
	}

	private void textBox_12_TextChanged(object sender, EventArgs e)
	{
		method_28(sender as Control);
		method_18();
	}

	private void method_18()
	{
		if (bool_0 || listBox_4.SelectedIndices.Count == 0 || !int.TryParse(textBox_14.Text, out var result) || !int.TryParse(textBox_13.Text, out var result2) || !int.TryParse(textBox_12.Text, out var result3))
		{
			return;
		}
		foreach (int selectedIndex in listBox_4.SelectedIndices)
		{
			if (selectedIndex >= 0 && selectedIndex < battletimecount)
			{
				day[selectedIndex] = result;
				hour[selectedIndex] = result2;
				minute[selectedIndex] = result3;
			}
		}
		method_7();
	}

	private void textBox_11_TextChanged(object sender, EventArgs e)
	{
		if (!bool_0 && int.TryParse(textBox_11.Text, out var result))
		{
			method_28(sender as Control);
			battletime_max = result;
		}
	}

	private void listBox_5_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		if (battletimecount2 != 0 && listBox_5.SelectedIndices.Count != 0)
		{
			int num = listBox_5.SelectedIndices[0];
			if (num >= 0 && num < battletimecount2)
			{
				bool_0 = true;
				textBox_20.Text = day2[num].ToString();
				textBox_19.Text = hour2[num].ToString();
				textBox_18.Text = minute2[num].ToString();
				bool_0 = false;
			}
		}
		else
		{
			bool_0 = true;
			textBox_20.Text = string.Empty;
			textBox_19.Text = string.Empty;
			textBox_18.Text = string.Empty;
			bool_0 = false;
		}
	}

	private void button_16_Click(object sender, EventArgs e)
	{
		method_26();
		method_4();
		day2.Add(0);
		hour2.Add(0);
		minute2.Add(0);
		battletimecount2++;
		method_20();
		if (battletimecount2 > 0)
		{
			listBox_5.ClearSelected();
			listBox_5.SetSelected(battletimecount2 - 1, value: true);
		}
	}

	private void button_15_Click(object sender, EventArgs e)
	{
		if (battletimecount2 == 0 || listBox_5.SelectedIndices.Count == 0)
		{
			return;
		}
		method_26();
		method_4();
		List<int> list = method_8(listBox_5);
		list.Sort();
		list.Reverse();
		foreach (int item in list)
		{
			if (item >= 0 && item < battletimecount2)
			{
				day2.RemoveAt(item);
				hour2.RemoveAt(item);
				minute2.RemoveAt(item);
				battletimecount2--;
			}
		}
		method_20();
	}

	private void button_17_Click(object sender, EventArgs e)
	{
		method_19();
	}

	private void textBox_20_TextChanged(object sender, EventArgs e)
	{
		method_28(sender as Control);
		method_19();
	}

	private void method_19()
	{
		if (bool_0 || listBox_5.SelectedIndices.Count == 0 || !int.TryParse(textBox_20.Text, out var result) || !int.TryParse(textBox_19.Text, out var result2) || !int.TryParse(textBox_18.Text, out var result3))
		{
			return;
		}
		method_4();
		foreach (int selectedIndex in listBox_5.SelectedIndices)
		{
			if (selectedIndex >= 0 && selectedIndex < battletimecount2)
			{
				day2[selectedIndex] = result;
				hour2[selectedIndex] = result2;
				minute2[selectedIndex] = result3;
			}
		}
		method_20();
	}

	private void method_20()
	{
		List<int> list = method_8(listBox_5);
		listBox_5.BeginUpdate();
		listBox_5.Items.Clear();
		for (int i = 0; i < battletimecount2; i++)
		{
			string item = string.Format(Class16.smethod_0(1649010646), i + 1, day2[i], hour2[i], minute2[i]);
			listBox_5.Items.Add(item);
		}
		listBox_5.EndUpdate();
		foreach (int item2 in list)
		{
			if (item2 >= 0 && item2 < listBox_5.Items.Count)
			{
				listBox_5.SetSelected(item2, value: true);
			}
		}
		bool_0 = true;
		textBox_17.Text = battletime_max2.ToString();
		bool_0 = false;
	}

	private void textBox_17_TextChanged(object sender, EventArgs e)
	{
		if (!bool_0 && int.TryParse(textBox_17.Text, out var result))
		{
			method_28(sender as Control);
			method_4();
			battletime_max2 = result;
		}
	}

	private void textBox_16_TextChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_28(sender as Control);
			if (int.TryParse(textBox_16.Text, out var result))
			{
				version1Extra1 = result;
			}
			if (int.TryParse(textBox_15.Text, out var result2))
			{
				version1Extra2 = result2;
			}
		}
	}

	private void method_21()
	{
		bool_0 = true;
		textBox_16.Text = version1Extra1.ToString();
		textBox_15.Text = version1Extra2.ToString();
		bool_0 = false;
	}

	private void method_22()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1649009756), 100);
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_23, method_24);
		fileBasedUndoManager_0.AttachToToolStrip(menuStrip_0, method_32, method_33);
		method_29();
	}

	private byte[] method_23()
	{
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					binaryWriter.Write(count);
					smethod_3(binaryWriter, name);
					smethod_1(binaryWriter, id);
					smethod_1(binaryWriter, type);
					smethod_1(binaryWriter, reward);
					smethod_1(binaryWriter, iconposX);
					smethod_1(binaryWriter, iconposY);
					smethod_1(binaryWriter, pointscount);
					binaryWriter.Write(points.Count);
					foreach (List<Point> point in points)
					{
						binaryWriter.Write(point.Count);
						foreach (Point item in point)
						{
							binaryWriter.Write(item.X);
							binaryWriter.Write(item.Y);
						}
					}
					smethod_1(binaryWriter, trianglescount);
					binaryWriter.Write(triangles.Count);
					foreach (List<Triangle> triangle in triangles)
					{
						binaryWriter.Write(triangle.Count);
						foreach (Triangle item2 in triangle)
						{
							binaryWriter.Write(item2.id1);
							binaryWriter.Write(item2.id2);
							binaryWriter.Write(item2.id3);
						}
					}
					smethod_1(binaryWriter, neighborscount);
					binaryWriter.Write(neighbors.Count);
					foreach (List<int> neighbor in neighbors)
					{
						binaryWriter.Write(neighbor.Count);
						foreach (int item3 in neighbor)
						{
							binaryWriter.Write(item3);
						}
					}
					binaryWriter.Write(version);
					binaryWriter.Write(version1Extra1);
					binaryWriter.Write(version1Extra2);
					binaryWriter.Write(battletimecount);
					smethod_1(binaryWriter, day);
					smethod_1(binaryWriter, hour);
					smethod_1(binaryWriter, minute);
					binaryWriter.Write(battletime_max);
					binaryWriter.Write(battletimecount2);
					smethod_1(binaryWriter, day2);
					smethod_1(binaryWriter, hour2);
					smethod_1(binaryWriter, minute2);
					binaryWriter.Write(battletime_max2);
					binaryWriter.Write(magic.Length);
					binaryWriter.Write(magic);
					smethod_5(binaryWriter, listBox_0);
					smethod_5(binaryWriter, listBox_1);
					smethod_5(binaryWriter, listBox_2);
					smethod_5(binaryWriter, listBox_3);
					smethod_5(binaryWriter, listBox_4);
					smethod_5(binaryWriter, listBox_5);
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

	private void method_24(byte[] byte_1)
	{
		if (byte_1 == null || byte_1.Length == 0)
		{
			return;
		}
		byte[] array = method_23();
		bool_1 = true;
		method_29();
		try
		{
			method_25(byte_1);
		}
		catch (Exception ex) when (((ex is EndOfStreamException || ex is InvalidDataException || ex is ArgumentOutOfRangeException || ex is OverflowException) ? 1 : 0) != 0)
		{
			SentryHelper.CaptureMessage(Class16.smethod_0(1649009761) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649009795));
			fileBasedUndoManager_0?.Clear();
			bool flag = false;
			if (array != null && array.Length != 0)
			{
				try
				{
					method_25(array);
					flag = true;
				}
				catch
				{
				}
			}
			if (!flag)
			{
				method_1();
			}
			toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649015039), Class16.smethod_0(1649015065));
		}
		finally
		{
			bool_0 = false;
			bool_1 = false;
		}
	}

	private void method_25(byte[] byte_1)
	{
		MemoryStream memoryStream = new MemoryStream(byte_1);
		try
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			try
			{
				count = smethod_0(binaryReader, Class16.smethod_0(1649009842), 500000, 0);
				name = smethod_4(binaryReader);
				id = smethod_2(binaryReader);
				type = smethod_2(binaryReader);
				reward = smethod_2(binaryReader);
				iconposX = smethod_2(binaryReader);
				iconposY = smethod_2(binaryReader);
				pointscount = smethod_2(binaryReader);
				int num = smethod_0(binaryReader, Class16.smethod_0(1649009869), count, 0);
				points = new List<List<Point>>(num);
				for (int i = 0; i < num; i++)
				{
					int int_ = (int)Math.Min(2147483647L, (binaryReader.BaseStream.Length - binaryReader.BaseStream.Position) / 8L);
					int num2 = smethod_0(binaryReader, Class16.smethod_0(1649009893), int_, 8);
					List<Point> list = new List<Point>(num2);
					for (int j = 0; j < num2; j++)
					{
						list.Add(new Point(binaryReader.ReadInt32(), binaryReader.ReadInt32()));
					}
					points.Add(list);
				}
				trianglescount = smethod_2(binaryReader);
				int num3 = smethod_0(binaryReader, Class16.smethod_0(1649009911), count, 0);
				triangles = new List<List<Triangle>>(num3);
				for (int k = 0; k < num3; k++)
				{
					int int_2 = (int)Math.Min(2147483647L, (binaryReader.BaseStream.Length - binaryReader.BaseStream.Position) / 12L);
					int num4 = smethod_0(binaryReader, Class16.smethod_0(1649009930), int_2, 12);
					List<Triangle> list2 = new List<Triangle>(num4);
					for (int l = 0; l < num4; l++)
					{
						list2.Add(new Triangle
						{
							id1 = binaryReader.ReadInt32(),
							id2 = binaryReader.ReadInt32(),
							id3 = binaryReader.ReadInt32()
						});
					}
					triangles.Add(list2);
				}
				neighborscount = smethod_2(binaryReader);
				int num5 = smethod_0(binaryReader, Class16.smethod_0(1649009959), count, 0);
				neighbors = new List<List<int>>(num5);
				for (int m = 0; m < num5; m++)
				{
					int int_3 = (int)Math.Min(2147483647L, (binaryReader.BaseStream.Length - binaryReader.BaseStream.Position) / 4L);
					int num6 = smethod_0(binaryReader, Class16.smethod_0(1649009978), int_3, 4);
					List<int> list3 = new List<int>(num6);
					for (int n = 0; n < num6; n++)
					{
						list3.Add(binaryReader.ReadInt32());
					}
					neighbors.Add(list3);
				}
				version = binaryReader.ReadInt32();
				version1Extra1 = binaryReader.ReadInt32();
				version1Extra2 = binaryReader.ReadInt32();
				battletimecount = smethod_0(binaryReader, Class16.smethod_0(1649010007), (int)Math.Min(2147483647L, (binaryReader.BaseStream.Length - binaryReader.BaseStream.Position) / 4L), 0);
				day = smethod_2(binaryReader);
				hour = smethod_2(binaryReader);
				minute = smethod_2(binaryReader);
				battletime_max = binaryReader.ReadInt32();
				battletimecount2 = smethod_0(binaryReader, Class16.smethod_0(1649010031), (int)Math.Min(2147483647L, (binaryReader.BaseStream.Length - binaryReader.BaseStream.Position) / 4L), 0);
				day2 = smethod_2(binaryReader);
				hour2 = smethod_2(binaryReader);
				minute2 = smethod_2(binaryReader);
				battletime_max2 = binaryReader.ReadInt32();
				int num7 = smethod_0(binaryReader, Class16.smethod_0(1649010050), (int)Math.Min(2147483647L, binaryReader.BaseStream.Length - binaryReader.BaseStream.Position), 0);
				magic = binaryReader.ReadBytes(num7);
				if (magic.Length != num7)
				{
					throw new EndOfStreamException(Class16.smethod_0(1649010077));
				}
				List<int> list_ = smethod_6(binaryReader);
				List<int> list_2 = smethod_6(binaryReader);
				List<int> list_3 = smethod_6(binaryReader);
				List<int> list_4 = smethod_6(binaryReader);
				List<int> list_5 = smethod_6(binaryReader);
				List<int> list_6 = smethod_6(binaryReader);
				bool_0 = true;
				SuspendLayout();
				try
				{
					method_6();
					method_7();
					method_20();
					method_21();
					method_3();
					smethod_7(listBox_0, list_);
					if (listBox_0.SelectedIndices.Count == 0)
					{
						method_13();
					}
					smethod_7(listBox_1, list_2);
					smethod_7(listBox_2, list_3);
					smethod_7(listBox_3, list_4);
					smethod_7(listBox_4, list_5);
					smethod_7(listBox_5, list_6);
					if (listBox_1.SelectedIndices.Count > 0)
					{
						listBox_1_SelectedIndexChanged(this, EventArgs.Empty);
					}
					if (listBox_2.SelectedIndices.Count > 0)
					{
						listBox_2_SelectedIndexChanged(this, EventArgs.Empty);
					}
					if (listBox_3.SelectedIndices.Count > 0)
					{
						listBox_3_SelectedIndexChanged(this, EventArgs.Empty);
					}
					if (listBox_4.SelectedIndices.Count > 0)
					{
						listBox_4_SelectedIndexChanged(this, EventArgs.Empty);
					}
					if (listBox_5.SelectedIndices.Count > 0)
					{
						listBox_5_SelectedIndexChanged(this, EventArgs.Empty);
					}
				}
				finally
				{
					ResumeLayout(performLayout: false);
					bool_0 = false;
				}
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

	private static int smethod_0(BinaryReader binaryReader_0, string string_0, int int_0, int int_1)
	{
		int num = binaryReader_0.ReadInt32();
		if (num >= 0 && num <= int_0)
		{
			if (int_1 > 0)
			{
				long num2 = binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
				if ((long)num * (long)int_1 > num2)
				{
					throw new EndOfStreamException(Class16.smethod_0(1649010127) + string_0 + Class16.smethod_0(1649010159));
				}
			}
			return num;
		}
		throw new InvalidDataException(string.Format(Class16.smethod_0(1648917887), string_0, num));
	}

	private static void smethod_1(BinaryWriter binaryWriter_0, List<int> list_0)
	{
		binaryWriter_0.Write(list_0.Count);
		foreach (int item in list_0)
		{
			binaryWriter_0.Write(item);
		}
	}

	private static List<int> smethod_2(BinaryReader binaryReader_0)
	{
		int int_ = (int)Math.Min(2147483647L, (binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position) / 4L);
		int num = smethod_0(binaryReader_0, Class16.smethod_0(1649009157), int_, 4);
		List<int> list = new List<int>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(binaryReader_0.ReadInt32());
		}
		return list;
	}

	private static void smethod_3(BinaryWriter binaryWriter_0, List<string> list_0)
	{
		binaryWriter_0.Write(list_0.Count);
		foreach (string item in list_0)
		{
			binaryWriter_0.Write(item ?? string.Empty);
		}
	}

	private static List<string> smethod_4(BinaryReader binaryReader_0)
	{
		int int_ = (int)Math.Min(2147483647L, binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position);
		int num = smethod_0(binaryReader_0, Class16.smethod_0(1649009170), int_, 0);
		List<string> list = new List<string>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(binaryReader_0.ReadString());
		}
		return list;
	}

	private static void smethod_5(BinaryWriter binaryWriter_0, ListBox listBox_6)
	{
		binaryWriter_0.Write(listBox_6.SelectedIndices.Count);
		foreach (int selectedIndex in listBox_6.SelectedIndices)
		{
			binaryWriter_0.Write(selectedIndex);
		}
	}

	private static List<int> smethod_6(BinaryReader binaryReader_0)
	{
		int int_ = (int)Math.Min(2147483647L, (binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position) / 4L);
		int num = smethod_0(binaryReader_0, Class16.smethod_0(1649009194), int_, 4);
		List<int> list = new List<int>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(binaryReader_0.ReadInt32());
		}
		return list;
	}

	private void method_26()
	{
		if (!bool_1)
		{
			method_29();
			byte[] array = method_23();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
		}
	}

	private void method_27()
	{
		method_29();
		fileBasedUndoManager_0?.Clear();
	}

	private void method_28(Control control_1)
	{
		if (!bool_1 && !bool_0 && control_1 != null)
		{
			if (control_0 != control_1)
			{
				control_0 = control_1;
				byte_0 = method_23();
				bool_2 = false;
			}
			if (!bool_2 && byte_0 != null)
			{
				fileBasedUndoManager_0?.PushUndo(byte_0);
				byte_0 = null;
				bool_2 = true;
			}
		}
	}

	private void method_29()
	{
		control_0 = null;
		byte_0 = null;
		bool_2 = false;
	}

	private static void smethod_7(ListBox listBox_6, List<int> list_0)
	{
		listBox_6.ClearSelected();
		foreach (int item in list_0)
		{
			if (item >= 0 && item < listBox_6.Items.Count)
			{
				listBox_6.SetSelected(item, value: true);
			}
		}
	}

	private void DomainEditorForm_Activated(object sender, EventArgs e)
	{
		method_30();
	}

	private void method_30()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_DomainEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_DomainEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void method_31()
	{
		try
		{
			Application.ExitThread();
		}
		catch
		{
			Close();
		}
	}

	private void method_32(object sender, EventArgs e)
	{
		byte[] currentState = method_23();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_24(array);
		}
	}

	private void method_33(object sender, EventArgs e)
	{
		byte[] currentState = method_23();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_24(array);
		}
	}
}
