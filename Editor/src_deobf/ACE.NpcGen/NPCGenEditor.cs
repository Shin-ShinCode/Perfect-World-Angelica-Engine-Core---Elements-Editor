using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements;
using ACE.Elements.eListCollection;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.NpcGen;

public class NPCGenEditor : Form
{
	public bool IsFileChanged;

	public bool DontChange;

	public NPCGen_FW NPCGen;

	public eListCollection eLC;

	public ItemsWindow ItemsWindow1;

	public CommonStorage CStorage;

	public int SelectedGroup;

	public int SelectedNPC;

	public int MobsList;

	public int NPCsList;

	private bool bool_0;

	public Form ElementsWindow;

	private DataGridView dataGridView_0;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_0;

	private DataGridView dataGridView_1;

	private GroupBox groupBox_0;

	private GroupBox groupBox_1;

	private GroupBox groupBox_2;

	private NumericUpDown numericUpDown_0;

	private Label label_0;

	private NumericUpDown numericUpDown_1;

	private Label label_1;

	private NumericUpDown numericUpDown_2;

	private Label label_2;

	private NumericUpDown numericUpDown_3;

	private Label label_3;

	private NumericUpDown numericUpDown_4;

	private Label label_4;

	private NumericUpDown numericUpDown_5;

	private Label label_5;

	private NumericUpDown numericUpDown_6;

	private Label label_6;

	private NumericUpDown numericUpDown_7;

	private Label label_7;

	private NumericUpDown numericUpDown_8;

	private Label label_8;

	private NumericUpDown numericUpDown_9;

	private Label label_9;

	private GroupBox groupBox_3;

	private Button button_2;

	private ComboBox comboBox_0;

	private NumericUpDown numericUpDown_10;

	private NumericUpDown numericUpDown_11;

	private Label label_10;

	private Label label_11;

	private NumericUpDown numericUpDown_12;

	private NumericUpDown numericUpDown_13;

	private NumericUpDown numericUpDown_14;

	private NumericUpDown numericUpDown_15;

	private CheckBox checkBox_0;

	private NumericUpDown numericUpDown_16;

	private CheckBox checkBox_1;

	private NumericUpDown numericUpDown_17;

	private CheckBox checkBox_2;

	private Label label_12;

	private Label label_13;

	private NumericUpDown numericUpDown_18;

	private Label label_14;

	private NumericUpDown numericUpDown_19;

	private Label label_15;

	private Label label_16;

	private Label label_17;

	private Label label_18;

	private NumericUpDown numericUpDown_20;

	private NumericUpDown numericUpDown_21;

	private NumericUpDown numericUpDown_22;

	private NumericUpDown numericUpDown_23;

	private NumericUpDown numericUpDown_24;

	private NumericUpDown numericUpDown_25;

	private GroupBox groupBox_4;

	private NumericUpDown numericUpDown_26;

	private Label label_19;

	private Label label_20;

	private Label label_21;

	private Label label_22;

	private NumericUpDown numericUpDown_27;

	private CheckBox checkBox_3;

	private NumericUpDown numericUpDown_28;

	private NumericUpDown numericUpDown_29;

	private Button button_3;

	private Button button_4;

	private Button button_5;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private GroupBox groupBox_5;

	private ComboBox comboBox_1;

	private Label label_23;

	private ComboBox comboBox_2;

	private Label label_24;

	private GroupBox groupBox_6;

	private ProgressBar progressBar_0;

	private TabPage tabPage_0;

	private TabPage tabPage_1;

	private TabPage tabPage_2;

	private TabPage tabPage_3;

	private TextBox textBox_1;

	private Button button_6;

	private Button button_7;

	private Label label_25;

	private DataGridView dataGridView_2;

	private Button button_8;

	private Button button_9;

	private Button button_10;

	private GroupBox groupBox_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private PropertyGrid propertyGrid_0;

	private DataGridView dataGridView_3;

	private TableLayoutPanel tableLayoutPanel_0;

	private Button button_11;

	private Button button_12;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private ToolTip toolTip_0;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private TabControl tabControl_0;

	private TabPage tabPage_4;

	private GroupBox groupBox_8;

	private GroupBox groupBox_9;

	private CheckBox checkBox_4;

	private CheckBox checkBox_5;

	private CheckBox checkBox_6;

	private Label label_26;

	private Label label_27;

	private Label label_28;

	private Label label_29;

	private IContainer icontainer_0;

	private DataGridViewRow[] dataGridViewRow_0;

	public NPCGenEditor(NPCGen_FW NPCGen, eListCollection eLC, ItemsWindow ItemsWindow1, Form ElementsWindow, CommonStorage CStorage)
	{
		try
		{
			method_5();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			this.CStorage = CStorage;
			this.eLC = eLC;
			this.NPCGen = NPCGen;
			this.ItemsWindow1 = ItemsWindow1;
			this.ElementsWindow = ElementsWindow;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			bool_0 = true;
			DontChange = false;
			IsFileChanged = false;
			TabPage value = tabPage_0;
			tabControl_0.TabPages.Remove(value);
			TabPage value2 = tabPage_1;
			tabControl_0.TabPages.Remove(value2);
			TabPage value3 = tabPage_3;
			tabControl_0.TabPages.Remove(value3);
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		method_19();
	}

	private void NPCGenEditor_Shown(object sender, EventArgs e)
	{
		if (eLC == null)
		{
			TextStorage.TEXTS.ShowErrorMessage(200);
			Hide();
		}
		NPCGen_FW nPCGen = NPCGen;
		if (!nPCGen.FileLoaded)
		{
			nPCGen.Load(CommonStorage.Params.NPCGenPath);
		}
		tabControl_0.Enabled = NPCGen.FileLoaded;
		NPCGen_FW nPCGen2 = NPCGen;
		if (nPCGen2.FileLoaded)
		{
			textBox_1.Text = nPCGen2.fn;
		}
		if (dataGridView_1.SelectedRows.Count == 0)
		{
			method_0();
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071086));
			textBox_0.Text = text;
		}
		GC.KeepAlive(this);
	}

	private void method_0()
	{
		method_1();
		method_21();
	}

	private void method_1()
	{
		IsFileChanged = false;
		button_6.Enabled = false;
		if (NPCGen.AIGens == null)
		{
			return;
		}
		MobsList = eLC.get_LI(Class16.smethod_0(1648963546));
		NPCsList = eLC.get_LI(Class16.smethod_0(1648960167));
		dataGridView_1.Rows.Clear();
		NPCGen_FW nPCGen = NPCGen;
		dataGridViewRow_0 = new DataGridViewRow[(nint)nPCGen.AIGens.LongLength];
		int num = 0;
		if (0 < (nint)nPCGen.AIGens.LongLength)
		{
			do
			{
				method_2(num);
				if (progressBar_0 != null && !progressBar_0.IsDisposed)
				{
					progressBar_0.Value = (int)((double)(float)num / (double)(float)(nint)NPCGen.AIGens.LongLength * 90.0);
					Application.DoEvents();
				}
				num++;
			}
			while (num < (nint)NPCGen.AIGens.LongLength);
		}
		DataGridViewRow[] dataGridViewRows = dataGridViewRow_0;
		dataGridView_1.Rows.AddRange(dataGridViewRows);
		if (progressBar_0 != null && !progressBar_0.IsDisposed)
		{
			progressBar_0.Value = 100;
		}
		dataGridView_1.Focus();
		GC.KeepAlive(this);
	}

	private void method_2(int int_0)
	{
		method_6(int_0, bool_1: true, bool_2: false);
	}

	private void method_3(int int_0)
	{
		method_6(int_0, bool_1: false, bool_2: true);
	}

	private void method_4()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_5()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(NPCGenEditor));
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		tabControl_0 = new TabControl();
		tabPage_4 = new TabPage();
		button_10 = new Button();
		button_3 = new Button();
		button_1 = new Button();
		groupBox_3 = new GroupBox();
		button_2 = new Button();
		comboBox_0 = new ComboBox();
		textBox_0 = new TextBox();
		groupBox_8 = new GroupBox();
		groupBox_5 = new GroupBox();
		checkBox_0 = new CheckBox();
		label_19 = new Label();
		label_20 = new Label();
		checkBox_2 = new CheckBox();
		label_21 = new Label();
		label_22 = new Label();
		checkBox_1 = new CheckBox();
		numericUpDown_19 = new NumericUpDown();
		numericUpDown_26 = new NumericUpDown();
		numericUpDown_18 = new NumericUpDown();
		numericUpDown_25 = new NumericUpDown();
		numericUpDown_24 = new NumericUpDown();
		numericUpDown_23 = new NumericUpDown();
		numericUpDown_20 = new NumericUpDown();
		numericUpDown_16 = new NumericUpDown();
		numericUpDown_17 = new NumericUpDown();
		numericUpDown_29 = new NumericUpDown();
		numericUpDown_22 = new NumericUpDown();
		numericUpDown_21 = new NumericUpDown();
		numericUpDown_28 = new NumericUpDown();
		checkBox_3 = new CheckBox();
		numericUpDown_27 = new NumericUpDown();
		label_12 = new Label();
		label_14 = new Label();
		label_15 = new Label();
		label_16 = new Label();
		label_13 = new Label();
		label_17 = new Label();
		label_18 = new Label();
		button_4 = new Button();
		button_5 = new Button();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		groupBox_9 = new GroupBox();
		groupBox_6 = new GroupBox();
		button_8 = new Button();
		button_9 = new Button();
		dataGridView_2 = new DataGridView();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		groupBox_4 = new GroupBox();
		numericUpDown_10 = new NumericUpDown();
		checkBox_6 = new CheckBox();
		checkBox_5 = new CheckBox();
		checkBox_4 = new CheckBox();
		comboBox_2 = new ComboBox();
		comboBox_1 = new ComboBox();
		numericUpDown_11 = new NumericUpDown();
		numericUpDown_12 = new NumericUpDown();
		numericUpDown_13 = new NumericUpDown();
		numericUpDown_14 = new NumericUpDown();
		numericUpDown_9 = new NumericUpDown();
		numericUpDown_15 = new NumericUpDown();
		label_10 = new Label();
		label_23 = new Label();
		label_24 = new Label();
		label_9 = new Label();
		label_29 = new Label();
		label_28 = new Label();
		label_27 = new Label();
		label_26 = new Label();
		label_11 = new Label();
		groupBox_1 = new GroupBox();
		numericUpDown_3 = new NumericUpDown();
		label_3 = new Label();
		numericUpDown_4 = new NumericUpDown();
		label_4 = new Label();
		numericUpDown_5 = new NumericUpDown();
		label_5 = new Label();
		groupBox_2 = new GroupBox();
		numericUpDown_6 = new NumericUpDown();
		label_6 = new Label();
		numericUpDown_7 = new NumericUpDown();
		label_7 = new Label();
		numericUpDown_8 = new NumericUpDown();
		label_8 = new Label();
		groupBox_0 = new GroupBox();
		numericUpDown_0 = new NumericUpDown();
		label_0 = new Label();
		numericUpDown_1 = new NumericUpDown();
		label_1 = new Label();
		numericUpDown_2 = new NumericUpDown();
		label_2 = new Label();
		button_0 = new Button();
		dataGridView_1 = new DataGridView();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		tabPage_0 = new TabPage();
		tabPage_1 = new TabPage();
		tabPage_2 = new TabPage();
		tableLayoutPanel_0 = new TableLayoutPanel();
		button_11 = new Button();
		button_12 = new Button();
		dataGridView_3 = new DataGridView();
		propertyGrid_0 = new PropertyGrid();
		tabPage_3 = new TabPage();
		progressBar_0 = new ProgressBar();
		textBox_1 = new TextBox();
		button_6 = new Button();
		button_7 = new Button();
		label_25 = new Label();
		groupBox_7 = new GroupBox();
		toolTip_0 = new ToolTip(icontainer_0);
		dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		menuStrip_0.SuspendLayout();
		tabControl_0.SuspendLayout();
		tabPage_4.SuspendLayout();
		groupBox_3.SuspendLayout();
		groupBox_8.SuspendLayout();
		groupBox_5.SuspendLayout();
		((ISupportInitialize)numericUpDown_19).BeginInit();
		((ISupportInitialize)numericUpDown_26).BeginInit();
		((ISupportInitialize)numericUpDown_18).BeginInit();
		((ISupportInitialize)numericUpDown_25).BeginInit();
		((ISupportInitialize)numericUpDown_24).BeginInit();
		((ISupportInitialize)numericUpDown_23).BeginInit();
		((ISupportInitialize)numericUpDown_20).BeginInit();
		((ISupportInitialize)numericUpDown_16).BeginInit();
		((ISupportInitialize)numericUpDown_17).BeginInit();
		((ISupportInitialize)numericUpDown_29).BeginInit();
		((ISupportInitialize)numericUpDown_22).BeginInit();
		((ISupportInitialize)numericUpDown_21).BeginInit();
		((ISupportInitialize)numericUpDown_28).BeginInit();
		((ISupportInitialize)numericUpDown_27).BeginInit();
		((ISupportInitialize)dataGridView_0).BeginInit();
		groupBox_9.SuspendLayout();
		groupBox_6.SuspendLayout();
		((ISupportInitialize)dataGridView_2).BeginInit();
		groupBox_4.SuspendLayout();
		((ISupportInitialize)numericUpDown_10).BeginInit();
		((ISupportInitialize)numericUpDown_11).BeginInit();
		((ISupportInitialize)numericUpDown_12).BeginInit();
		((ISupportInitialize)numericUpDown_13).BeginInit();
		((ISupportInitialize)numericUpDown_14).BeginInit();
		((ISupportInitialize)numericUpDown_9).BeginInit();
		((ISupportInitialize)numericUpDown_15).BeginInit();
		groupBox_1.SuspendLayout();
		((ISupportInitialize)numericUpDown_3).BeginInit();
		((ISupportInitialize)numericUpDown_4).BeginInit();
		((ISupportInitialize)numericUpDown_5).BeginInit();
		groupBox_2.SuspendLayout();
		((ISupportInitialize)numericUpDown_6).BeginInit();
		((ISupportInitialize)numericUpDown_7).BeginInit();
		((ISupportInitialize)numericUpDown_8).BeginInit();
		groupBox_0.SuspendLayout();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		((ISupportInitialize)dataGridView_1).BeginInit();
		tabPage_2.SuspendLayout();
		tableLayoutPanel_0.SuspendLayout();
		((ISupportInitialize)dataGridView_3).BeginInit();
		groupBox_7.SuspendLayout();
		SuspendLayout();
		Color inactiveBorder = SystemColors.InactiveBorder;
		menuStrip_0.BackColor = inactiveBorder;
		menuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		ToolStripItem[] toolStripItems = new ToolStripItem[1] { toolStripMenuItem_1 };
		menuStrip_0.Items.AddRange(toolStripItems);
		Point location = new Point(0, 0);
		menuStrip_0.Location = location;
		menuStrip_0.Name = Class16.smethod_0(1649009132);
		Padding padding = new Padding(0, 2, 2, 2);
		menuStrip_0.Padding = padding;
		menuStrip_0.RenderMode = ToolStripRenderMode.Professional;
		Size size = new Size(1006, 24);
		menuStrip_0.Size = size;
		menuStrip_0.TabIndex = 0;
		menuStrip_0.Text = Class16.smethod_0(1649012229);
		menuStrip_0.Visible = false;
		ToolStripItem[] toolStripItems2 = new ToolStripItem[4] { toolStripMenuItem_2, toolStripMenuItem_3, toolStripSeparator_0, toolStripMenuItem_0 };
		toolStripMenuItem_1.DropDownItems.AddRange(toolStripItems2);
		toolStripMenuItem_1.ImageScaling = ToolStripItemImageScaling.None;
		toolStripMenuItem_1.Name = Class16.smethod_0(1649012245);
		Padding padding2 = new Padding(0);
		toolStripMenuItem_1.Padding = padding2;
		Size size2 = new Size(40, 20);
		toolStripMenuItem_1.Size = size2;
		toolStripMenuItem_1.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_1.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_2.BackgroundImageLayout = ImageLayout.None;
		toolStripMenuItem_2.Image = Resources.NPCGenEditor_mnuOpen;
		toolStripMenuItem_2.ImageAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_2.Name = Class16.smethod_0(1648920856);
		toolStripMenuItem_2.ShortcutKeys = Keys.O | Keys.Control;
		Size size3 = new Size(172, 22);
		toolStripMenuItem_2.Size = size3;
		toolStripMenuItem_2.Text = Class16.smethod_0(1648931498);
		toolStripMenuItem_2.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.Image = Resources.NPCGenEditor_mnuSave;
		toolStripMenuItem_3.Name = Class16.smethod_0(1648920878);
		toolStripMenuItem_3.ShortcutKeys = Keys.S | Keys.Control;
		Size size4 = new Size(172, 22);
		toolStripMenuItem_3.Size = size4;
		toolStripMenuItem_3.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_3.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1649012270);
		Size size5 = new Size(169, 6);
		toolStripSeparator_0.Size = size5;
		toolStripMenuItem_0.Image = Resources.NPCGenEditor_mnuExit;
		toolStripMenuItem_0.Name = Class16.smethod_0(1648920908);
		Size size6 = new Size(172, 22);
		toolStripMenuItem_0.Size = size6;
		toolStripMenuItem_0.Text = Class16.smethod_0(1648920914);
		tabControl_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TabPage value = tabPage_4;
		tabControl_0.Controls.Add(value);
		TabPage value2 = tabPage_0;
		tabControl_0.Controls.Add(value2);
		TabPage value3 = tabPage_1;
		tabControl_0.Controls.Add(value3);
		TabPage value4 = tabPage_2;
		tabControl_0.Controls.Add(value4);
		TabPage value5 = tabPage_3;
		tabControl_0.Controls.Add(value5);
		tabControl_0.Enabled = false;
		Point location2 = new Point(0, 40);
		tabControl_0.Location = location2;
		Padding margin = new Padding(3, 4, 3, 4);
		tabControl_0.Margin = margin;
		tabControl_0.Name = Class16.smethod_0(1649117604);
		tabControl_0.SelectedIndex = 0;
		Size size7 = new Size(1006, 614);
		tabControl_0.Size = size7;
		tabControl_0.TabIndex = 11;
		Color backColor = Color.FromArgb(239, 244, 250);
		tabPage_4.BackColor = backColor;
		Button value6 = button_10;
		tabPage_4.Controls.Add(value6);
		Button value7 = button_3;
		tabPage_4.Controls.Add(value7);
		Button value8 = button_1;
		tabPage_4.Controls.Add(value8);
		GroupBox value9 = groupBox_3;
		tabPage_4.Controls.Add(value9);
		TextBox value10 = textBox_0;
		tabPage_4.Controls.Add(value10);
		GroupBox value11 = groupBox_8;
		tabPage_4.Controls.Add(value11);
		GroupBox value12 = groupBox_9;
		tabPage_4.Controls.Add(value12);
		Button value13 = button_0;
		tabPage_4.Controls.Add(value13);
		DataGridView value14 = dataGridView_1;
		tabPage_4.Controls.Add(value14);
		Point location3 = new Point(4, 22);
		tabPage_4.Location = location3;
		Padding margin2 = new Padding(3, 4, 3, 4);
		tabPage_4.Margin = margin2;
		tabPage_4.Name = Class16.smethod_0(1649117615);
		Size size8 = new Size(998, 588);
		tabPage_4.Size = size8;
		tabPage_4.TabIndex = 0;
		tabPage_4.Text = Class16.smethod_0(1649117636);
		Point location4 = new Point(-200, 307);
		button_10.Location = location4;
		button_10.Name = Class16.smethod_0(1648929185);
		Size size9 = new Size(75, 23);
		button_10.Size = size9;
		button_10.TabIndex = 107;
		button_10.Text = Class16.smethod_0(1648929202);
		button_10.UseVisualStyleBackColor = true;
		button_10.Click += button_10_Click;
		button_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_3.Enabled = false;
		button_3.Image = Resources.cmdDeleteGroup;
		Point location5 = new Point(175, 557);
		button_3.Location = location5;
		button_3.Name = Class16.smethod_0(1649117660);
		Size size10 = new Size(166, 25);
		button_3.Size = size10;
		button_3.TabIndex = 71;
		button_3.Text = Class16.smethod_0(1648925718);
		button_3.TextAlign = ContentAlignment.MiddleRight;
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		button_1.Image = Resources.cmdSearch;
		Point location6 = new Point(311, 13);
		button_1.Location = location6;
		button_1.Name = Class16.smethod_0(1649070343);
		Size size11 = new Size(30, 25);
		button_1.Size = size11;
		button_1.TabIndex = 35;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		Button value15 = button_2;
		groupBox_3.Controls.Add(value15);
		ComboBox value16 = comboBox_0;
		groupBox_3.Controls.Add(value16);
		groupBox_3.Enabled = false;
		Point location7 = new Point(109, 196);
		groupBox_3.Location = location7;
		groupBox_3.Name = Class16.smethod_0(1649117673);
		Size size12 = new Size(215, 52);
		groupBox_3.Size = size12;
		groupBox_3.TabIndex = 106;
		groupBox_3.TabStop = false;
		groupBox_3.Text = Class16.smethod_0(1649112585);
		groupBox_3.Visible = false;
		button_2.Image = Resources.button_AsistantGetValues;
		Point location8 = new Point(183, 19);
		button_2.Location = location8;
		button_2.Name = Class16.smethod_0(1649112618);
		Size size13 = new Size(26, 25);
		button_2.Size = size13;
		button_2.TabIndex = 16;
		button_2.UseVisualStyleBackColor = true;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		Point location9 = new Point(8, 20);
		comboBox_0.Location = location9;
		comboBox_0.Name = Class16.smethod_0(1649112649);
		Size size14 = new Size(169, 21);
		comboBox_0.Size = size14;
		comboBox_0.TabIndex = 15;
		Color backColor2 = Color.FromArgb(220, 255, 255);
		textBox_0.BackColor = backColor2;
		Point location10 = new Point(8, 14);
		textBox_0.Location = location10;
		textBox_0.Name = Class16.smethod_0(1648995997);
		Size size15 = new Size(300, 22);
		textBox_0.Size = size15;
		textBox_0.TabIndex = 34;
		textBox_0.Text = Class16.smethod_0(1649070359);
		textBox_0.TextAlign = HorizontalAlignment.Center;
		textBox_0.Click += textBox_0_Click;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.DoubleClick += textBox_0_DoubleClick;
		textBox_0.Enter += textBox_0_Enter;
		textBox_0.Leave += textBox_0_Leave;
		groupBox_8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox value17 = groupBox_5;
		groupBox_8.Controls.Add(value17);
		Button value18 = button_4;
		groupBox_8.Controls.Add(value18);
		Button value19 = button_5;
		groupBox_8.Controls.Add(value19);
		DataGridView value20 = dataGridView_0;
		groupBox_8.Controls.Add(value20);
		groupBox_8.Font = new Font(Class16.smethod_0(1649112680), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location11 = new Point(351, 345);
		groupBox_8.Location = location11;
		Padding margin3 = new Padding(3, 4, 3, 4);
		groupBox_8.Margin = margin3;
		groupBox_8.Name = Class16.smethod_0(1649112710);
		Padding padding3 = new Padding(3, 4, 3, 4);
		groupBox_8.Padding = padding3;
		Size size16 = new Size(641, 238);
		groupBox_8.Size = size16;
		groupBox_8.TabIndex = 14;
		groupBox_8.TabStop = false;
		groupBox_8.Text = Class16.smethod_0(1649112723);
		CheckBox value21 = checkBox_0;
		groupBox_5.Controls.Add(value21);
		Label value22 = label_19;
		groupBox_5.Controls.Add(value22);
		Label value23 = label_20;
		groupBox_5.Controls.Add(value23);
		CheckBox value24 = checkBox_2;
		groupBox_5.Controls.Add(value24);
		Label value25 = label_21;
		groupBox_5.Controls.Add(value25);
		Label value26 = label_22;
		groupBox_5.Controls.Add(value26);
		CheckBox value27 = checkBox_1;
		groupBox_5.Controls.Add(value27);
		NumericUpDown value28 = numericUpDown_19;
		groupBox_5.Controls.Add(value28);
		NumericUpDown value29 = numericUpDown_26;
		groupBox_5.Controls.Add(value29);
		NumericUpDown value30 = numericUpDown_18;
		groupBox_5.Controls.Add(value30);
		NumericUpDown value31 = numericUpDown_25;
		groupBox_5.Controls.Add(value31);
		NumericUpDown value32 = numericUpDown_24;
		groupBox_5.Controls.Add(value32);
		NumericUpDown value33 = numericUpDown_23;
		groupBox_5.Controls.Add(value33);
		NumericUpDown value34 = numericUpDown_20;
		groupBox_5.Controls.Add(value34);
		NumericUpDown value35 = numericUpDown_16;
		groupBox_5.Controls.Add(value35);
		NumericUpDown value36 = numericUpDown_17;
		groupBox_5.Controls.Add(value36);
		NumericUpDown value37 = numericUpDown_29;
		groupBox_5.Controls.Add(value37);
		NumericUpDown value38 = numericUpDown_22;
		groupBox_5.Controls.Add(value38);
		NumericUpDown value39 = numericUpDown_21;
		groupBox_5.Controls.Add(value39);
		NumericUpDown value40 = numericUpDown_28;
		groupBox_5.Controls.Add(value40);
		CheckBox value41 = checkBox_3;
		groupBox_5.Controls.Add(value41);
		NumericUpDown value42 = numericUpDown_27;
		groupBox_5.Controls.Add(value42);
		Label value43 = label_12;
		groupBox_5.Controls.Add(value43);
		Label value44 = label_14;
		groupBox_5.Controls.Add(value44);
		Label value45 = label_15;
		groupBox_5.Controls.Add(value45);
		Label value46 = label_16;
		groupBox_5.Controls.Add(value46);
		Label value47 = label_13;
		groupBox_5.Controls.Add(value47);
		Label value48 = label_17;
		groupBox_5.Controls.Add(value48);
		Label value49 = label_18;
		groupBox_5.Controls.Add(value49);
		groupBox_5.Enabled = false;
		groupBox_5.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location12 = new Point(262, 15);
		groupBox_5.Location = location12;
		groupBox_5.Name = Class16.smethod_0(1649112752);
		Size size17 = new Size(375, 219);
		groupBox_5.Size = size17;
		groupBox_5.TabIndex = 139;
		groupBox_5.TabStop = false;
		groupBox_5.Text = Class16.smethod_0(1648936731);
		checkBox_0.AutoSize = true;
		checkBox_0.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location13 = new Point(184, 171);
		checkBox_0.Location = location13;
		Padding margin4 = new Padding(3, 4, 3, 4);
		checkBox_0.Margin = margin4;
		checkBox_0.Name = Class16.smethod_0(1649112769);
		Size size18 = new Size(113, 19);
		checkBox_0.Size = size18;
		checkBox_0.TabIndex = 127;
		checkBox_0.Text = Class16.smethod_0(1649112799);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		label_19.AutoSize = true;
		label_19.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location14 = new Point(184, 23);
		label_19.Location = location14;
		label_19.Name = Class16.smethod_0(1649112824);
		Size size19 = new Size(53, 15);
		label_19.Size = size19;
		label_19.TabIndex = 129;
		label_19.Text = Class16.smethod_0(1649112840);
		label_20.AutoSize = true;
		label_20.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location15 = new Point(184, 50);
		label_20.Location = location15;
		label_20.Name = Class16.smethod_0(1649112863);
		Size size20 = new Size(62, 15);
		label_20.Size = size20;
		label_20.TabIndex = 130;
		label_20.Text = Class16.smethod_0(1649112873);
		checkBox_2.AutoSize = true;
		checkBox_2.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location16 = new Point(184, 122);
		checkBox_2.Location = location16;
		Padding margin5 = new Padding(3, 4, 3, 4);
		checkBox_2.Margin = margin5;
		checkBox_2.Name = Class16.smethod_0(1649112890);
		Size size21 = new Size(66, 19);
		checkBox_2.Size = size21;
		checkBox_2.TabIndex = 123;
		checkBox_2.Text = Class16.smethod_0(1649112918);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_2.CheckedChanged += checkBox_2_CheckedChanged;
		label_21.AutoSize = true;
		label_21.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location17 = new Point(184, 75);
		label_21.Location = location17;
		label_21.Name = Class16.smethod_0(1649112923);
		Size size22 = new Size(82, 15);
		label_21.Size = size22;
		label_21.TabIndex = 131;
		label_21.Text = Class16.smethod_0(1649112950);
		label_22.AutoSize = true;
		label_22.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location18 = new Point(184, 98);
		label_22.Location = location18;
		label_22.Name = Class16.smethod_0(1649112960);
		Size size23 = new Size(81, 15);
		label_22.Size = size23;
		label_22.TabIndex = 135;
		label_22.Text = Class16.smethod_0(1649112978);
		checkBox_1.AutoSize = true;
		checkBox_1.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location19 = new Point(184, 146);
		checkBox_1.Location = location19;
		Padding margin6 = new Padding(3, 4, 3, 4);
		checkBox_1.Margin = margin6;
		checkBox_1.Name = Class16.smethod_0(1649113004);
		Size size24 = new Size(111, 19);
		checkBox_1.Size = size24;
		checkBox_1.TabIndex = 125;
		checkBox_1.Text = Class16.smethod_0(1649113018);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.CheckedChanged += checkBox_1_CheckedChanged;
		numericUpDown_19.DecimalPlaces = 5;
		numericUpDown_19.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location20 = new Point(101, 171);
		numericUpDown_19.Location = location20;
		decimal maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_19.Maximum = maximum;
		decimal minimum = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_19.Minimum = minimum;
		numericUpDown_19.Name = Class16.smethod_0(1649113040);
		Size size25 = new Size(70, 21);
		numericUpDown_19.Size = size25;
		numericUpDown_19.TabIndex = 121;
		numericUpDown_19.TextAlign = HorizontalAlignment.Center;
		numericUpDown_19.ThousandsSeparator = true;
		numericUpDown_19.ValueChanged += numericUpDown_19_ValueChanged;
		numericUpDown_26.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location21 = new Point(297, 95);
		numericUpDown_26.Location = location21;
		decimal maximum2 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_26.Maximum = maximum2;
		decimal minimum2 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_26.Minimum = minimum2;
		numericUpDown_26.Name = Class16.smethod_0(1649113059);
		Size size26 = new Size(70, 21);
		numericUpDown_26.Size = size26;
		numericUpDown_26.TabIndex = 136;
		numericUpDown_26.TextAlign = HorizontalAlignment.Center;
		numericUpDown_26.ThousandsSeparator = true;
		numericUpDown_26.ValueChanged += numericUpDown_26_ValueChanged;
		numericUpDown_18.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location22 = new Point(297, 119);
		numericUpDown_18.Location = location22;
		decimal maximum3 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_18.Maximum = maximum3;
		decimal minimum3 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_18.Minimum = minimum3;
		numericUpDown_18.Name = Class16.smethod_0(1649113085);
		Size size27 = new Size(70, 21);
		numericUpDown_18.Size = size27;
		numericUpDown_18.TabIndex = 122;
		numericUpDown_18.TextAlign = HorizontalAlignment.Center;
		numericUpDown_18.ThousandsSeparator = true;
		numericUpDown_18.ValueChanged += numericUpDown_18_ValueChanged;
		numericUpDown_25.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location23 = new Point(101, 48);
		numericUpDown_25.Location = location23;
		decimal maximum4 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_25.Maximum = maximum4;
		decimal minimum4 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_25.Minimum = minimum4;
		numericUpDown_25.Name = Class16.smethod_0(1649112078);
		Size size28 = new Size(70, 21);
		numericUpDown_25.Size = size28;
		numericUpDown_25.TabIndex = 113;
		numericUpDown_25.TextAlign = HorizontalAlignment.Center;
		numericUpDown_25.ThousandsSeparator = true;
		numericUpDown_25.ValueChanged += numericUpDown_25_ValueChanged;
		numericUpDown_24.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location24 = new Point(101, 73);
		numericUpDown_24.Location = location24;
		decimal maximum5 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_24.Maximum = maximum5;
		decimal minimum5 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_24.Minimum = minimum5;
		numericUpDown_24.Name = Class16.smethod_0(1649112083);
		Size size29 = new Size(70, 21);
		numericUpDown_24.Size = size29;
		numericUpDown_24.TabIndex = 114;
		numericUpDown_24.TextAlign = HorizontalAlignment.Center;
		numericUpDown_24.ThousandsSeparator = true;
		numericUpDown_24.ValueChanged += numericUpDown_24_ValueChanged;
		Color yellow = Color.Yellow;
		numericUpDown_23.BackColor = yellow;
		numericUpDown_23.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_23.InterceptArrowKeys = false;
		Point location25 = new Point(101, 23);
		numericUpDown_23.Location = location25;
		decimal maximum6 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_23.Maximum = maximum6;
		decimal minimum6 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_23.Minimum = minimum6;
		numericUpDown_23.Name = Class16.smethod_0(1649002075);
		Size size30 = new Size(70, 21);
		numericUpDown_23.Size = size30;
		numericUpDown_23.TabIndex = 112;
		numericUpDown_23.TextAlign = HorizontalAlignment.Center;
		numericUpDown_23.ThousandsSeparator = true;
		numericUpDown_23.ValueChanged += numericUpDown_23_ValueChanged;
		numericUpDown_23.DoubleClick += numericUpDown_23_DoubleClick;
		numericUpDown_20.DecimalPlaces = 5;
		numericUpDown_20.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location26 = new Point(101, 146);
		numericUpDown_20.Location = location26;
		decimal maximum7 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_20.Maximum = maximum7;
		decimal minimum7 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_20.Minimum = minimum7;
		numericUpDown_20.Name = Class16.smethod_0(1649112108);
		Size size31 = new Size(70, 21);
		numericUpDown_20.Size = size31;
		numericUpDown_20.TabIndex = 117;
		numericUpDown_20.TextAlign = HorizontalAlignment.Center;
		numericUpDown_20.ThousandsSeparator = true;
		numericUpDown_20.ValueChanged += numericUpDown_20_ValueChanged;
		numericUpDown_16.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location27 = new Point(297, 169);
		numericUpDown_16.Location = location27;
		decimal maximum8 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_16.Maximum = maximum8;
		decimal minimum8 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_16.Minimum = minimum8;
		numericUpDown_16.Name = Class16.smethod_0(1649112121);
		Size size32 = new Size(70, 21);
		numericUpDown_16.Size = size32;
		numericUpDown_16.TabIndex = 126;
		numericUpDown_16.TextAlign = HorizontalAlignment.Center;
		numericUpDown_16.ThousandsSeparator = true;
		numericUpDown_16.ValueChanged += numericUpDown_16_ValueChanged;
		numericUpDown_17.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location28 = new Point(297, 144);
		numericUpDown_17.Location = location28;
		decimal maximum9 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_17.Maximum = maximum9;
		decimal minimum9 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_17.Minimum = minimum9;
		numericUpDown_17.Name = Class16.smethod_0(1649112148);
		Size size33 = new Size(70, 21);
		numericUpDown_17.Size = size33;
		numericUpDown_17.TabIndex = 124;
		numericUpDown_17.TextAlign = HorizontalAlignment.Center;
		numericUpDown_17.ThousandsSeparator = true;
		numericUpDown_17.ValueChanged += numericUpDown_17_ValueChanged;
		numericUpDown_29.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location29 = new Point(297, 46);
		numericUpDown_29.Location = location29;
		decimal maximum10 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_29.Maximum = maximum10;
		decimal minimum10 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_29.Minimum = minimum10;
		numericUpDown_29.Name = Class16.smethod_0(1649112167);
		Size size34 = new Size(70, 21);
		numericUpDown_29.Size = size34;
		numericUpDown_29.TabIndex = 133;
		numericUpDown_29.TextAlign = HorizontalAlignment.Center;
		numericUpDown_29.ThousandsSeparator = true;
		numericUpDown_29.ValueChanged += numericUpDown_29_ValueChanged;
		numericUpDown_22.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location30 = new Point(101, 97);
		numericUpDown_22.Location = location30;
		decimal maximum11 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_22.Maximum = maximum11;
		decimal minimum11 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_22.Minimum = minimum11;
		numericUpDown_22.Name = Class16.smethod_0(1649112177);
		Size size35 = new Size(70, 21);
		numericUpDown_22.Size = size35;
		numericUpDown_22.TabIndex = 115;
		numericUpDown_22.TextAlign = HorizontalAlignment.Center;
		numericUpDown_22.ThousandsSeparator = true;
		numericUpDown_22.ValueChanged += numericUpDown_22_ValueChanged;
		numericUpDown_21.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location31 = new Point(101, 122);
		numericUpDown_21.Location = location31;
		decimal maximum12 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_21.Maximum = maximum12;
		decimal minimum12 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_21.Minimum = minimum12;
		numericUpDown_21.Name = Class16.smethod_0(1649112204);
		Size size36 = new Size(70, 21);
		numericUpDown_21.Size = size36;
		numericUpDown_21.TabIndex = 116;
		numericUpDown_21.TextAlign = HorizontalAlignment.Center;
		numericUpDown_21.ThousandsSeparator = true;
		numericUpDown_21.ValueChanged += numericUpDown_21_ValueChanged;
		numericUpDown_28.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location32 = new Point(297, 70);
		numericUpDown_28.Location = location32;
		decimal maximum13 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_28.Maximum = maximum13;
		decimal minimum13 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_28.Minimum = minimum13;
		numericUpDown_28.Name = Class16.smethod_0(1649112216);
		Size size37 = new Size(70, 21);
		numericUpDown_28.Size = size37;
		numericUpDown_28.TabIndex = 134;
		numericUpDown_28.TextAlign = HorizontalAlignment.Center;
		numericUpDown_28.ThousandsSeparator = true;
		numericUpDown_28.ValueChanged += numericUpDown_28_ValueChanged;
		checkBox_3.AutoSize = true;
		checkBox_3.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location33 = new Point(9, 197);
		checkBox_3.Location = location33;
		Padding margin7 = new Padding(3, 4, 3, 4);
		checkBox_3.Margin = margin7;
		checkBox_3.Name = Class16.smethod_0(1649112235);
		Size size38 = new Size(104, 19);
		checkBox_3.Size = size38;
		checkBox_3.TabIndex = 128;
		checkBox_3.Text = Class16.smethod_0(1649112261);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_3.CheckedChanged += checkBox_3_CheckedChanged;
		numericUpDown_27.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location34 = new Point(297, 21);
		numericUpDown_27.Location = location34;
		decimal maximum14 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_27.Maximum = maximum14;
		decimal minimum14 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_27.Minimum = minimum14;
		numericUpDown_27.Name = Class16.smethod_0(1649112277);
		Size size39 = new Size(70, 21);
		numericUpDown_27.Size = size39;
		numericUpDown_27.TabIndex = 132;
		numericUpDown_27.TextAlign = HorizontalAlignment.Center;
		numericUpDown_27.ThousandsSeparator = true;
		numericUpDown_27.ValueChanged += numericUpDown_27_ValueChanged;
		label_12.AutoSize = true;
		label_12.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location35 = new Point(6, 23);
		label_12.Location = location35;
		label_12.Name = Class16.smethod_0(1649112293);
		Size size40 = new Size(82, 15);
		label_12.Size = size40;
		label_12.TabIndex = 111;
		label_12.Text = Class16.smethod_0(1649112305);
		label_14.AutoSize = true;
		label_14.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location36 = new Point(6, 73);
		label_14.Location = location36;
		label_14.Name = Class16.smethod_0(1649112335);
		Size size41 = new Size(50, 15);
		label_14.Size = size41;
		label_14.TabIndex = 107;
		label_14.Text = Class16.smethod_0(1649112344);
		label_15.AutoSize = true;
		label_15.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location37 = new Point(6, 97);
		label_15.Location = location37;
		label_15.Name = Class16.smethod_0(1649112367);
		Size size42 = new Size(53, 15);
		label_15.Size = size42;
		label_15.TabIndex = 108;
		label_15.Text = Class16.smethod_0(1649112378);
		label_16.AutoSize = true;
		label_16.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location38 = new Point(6, 124);
		label_16.Location = location38;
		label_16.Name = Class16.smethod_0(1649112392);
		Size size43 = new Size(58, 15);
		label_16.Size = size43;
		label_16.TabIndex = 109;
		label_16.Text = Class16.smethod_0(1649112420);
		label_13.AutoSize = true;
		label_13.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location39 = new Point(6, 48);
		label_13.Location = location39;
		label_13.Name = Class16.smethod_0(1649112438);
		Size size44 = new Size(68, 15);
		label_13.Size = size44;
		label_13.TabIndex = 106;
		label_13.Text = Class16.smethod_0(1649112443);
		label_17.AutoSize = true;
		label_17.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location40 = new Point(6, 148);
		label_17.Location = location40;
		label_17.Name = Class16.smethod_0(1649112459);
		Size size45 = new Size(71, 15);
		label_17.Size = size45;
		label_17.TabIndex = 110;
		label_17.Text = Class16.smethod_0(1649112480);
		label_18.AutoSize = true;
		label_18.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location41 = new Point(6, 172);
		label_18.Location = location41;
		label_18.Name = Class16.smethod_0(1649112508);
		Size size46 = new Size(92, 15);
		label_18.Size = size46;
		label_18.TabIndex = 118;
		label_18.Text = Class16.smethod_0(1649112527);
		button_4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_4.Font = new Font(Class16.smethod_0(1648942905), 9f);
		button_4.Image = Resources.cmdDeleteNPC;
		Point location42 = new Point(132, 209);
		button_4.Location = location42;
		button_4.Name = Class16.smethod_0(1649112538);
		Size size47 = new Size(124, 25);
		button_4.Size = size47;
		button_4.TabIndex = 138;
		button_4.Text = Class16.smethod_0(1648925718);
		button_4.TextAlign = ContentAlignment.MiddleRight;
		button_4.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		button_5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_5.Font = new Font(Class16.smethod_0(1648942905), 9f);
		button_5.Image = Resources.cmdAddNPC;
		Point location43 = new Point(6, 209);
		button_5.Location = location43;
		button_5.Name = Class16.smethod_0(1649112565);
		Size size48 = new Size(124, 25);
		button_5.Size = size48;
		button_5.TabIndex = 137;
		button_5.Text = Class16.smethod_0(1648931361);
		button_5.TextAlign = ContentAlignment.MiddleRight;
		button_5.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Color backgroundColor = SystemColors.Window;
		dataGridView_0.BackgroundColor = backgroundColor;
		dataGridView_0.BorderStyle = BorderStyle.None;
		dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_0.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[2] { dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1 };
		dataGridView_0.Columns.AddRange(dataGridViewColumns);
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		Color backColor3 = SystemColors.Window;
		dataGridViewCellStyle.BackColor = backColor3;
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1649112680), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color windowText = SystemColors.WindowText;
		dataGridViewCellStyle.ForeColor = windowText;
		Color highlight = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionBackColor = highlight;
		Color white = Color.White;
		dataGridViewCellStyle.SelectionForeColor = white;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.EditMode = DataGridViewEditMode.EditOnEnter;
		Color silver = Color.Silver;
		dataGridView_0.GridColor = silver;
		Point location44 = new Point(6, 23);
		dataGridView_0.Location = location44;
		Padding margin8 = new Padding(3, 4, 3, 4);
		dataGridView_0.Margin = margin8;
		dataGridView_0.Name = Class16.smethod_0(1649111557);
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		Color control = SystemColors.Control;
		dataGridViewCellStyle2.BackColor = control;
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1649112680), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color windowText2 = SystemColors.WindowText;
		dataGridViewCellStyle2.ForeColor = windowText2;
		Color highlight2 = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionBackColor = highlight2;
		Color highlightText = SystemColors.HighlightText;
		dataGridViewCellStyle2.SelectionForeColor = highlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowsDefaultCellStyle = dataGridViewCellStyle3;
		string familyName = Class16.smethod_0(1649143423);
		dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(familyName, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowTemplate.Height = 18;
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellToolTips = false;
		Size size49 = new Size(250, 184);
		dataGridView_0.Size = size49;
		dataGridView_0.TabIndex = 69;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
		Color foreColor = Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle4.ForeColor = foreColor;
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649111563);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 60;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649111605);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		GroupBox value50 = groupBox_6;
		groupBox_9.Controls.Add(value50);
		GroupBox value51 = groupBox_4;
		groupBox_9.Controls.Add(value51);
		GroupBox value52 = groupBox_1;
		groupBox_9.Controls.Add(value52);
		GroupBox value53 = groupBox_2;
		groupBox_9.Controls.Add(value53);
		GroupBox value54 = groupBox_0;
		groupBox_9.Controls.Add(value54);
		Point location45 = new Point(351, 6);
		groupBox_9.Location = location45;
		Padding margin9 = new Padding(3, 4, 3, 4);
		groupBox_9.Margin = margin9;
		groupBox_9.Name = Class16.smethod_0(1649111620);
		Padding padding4 = new Padding(3, 4, 3, 4);
		groupBox_9.Padding = padding4;
		Size size50 = new Size(641, 330);
		groupBox_9.Size = size50;
		groupBox_9.TabIndex = 21;
		groupBox_9.TabStop = false;
		groupBox_9.Text = Class16.smethod_0(1649111633);
		Color backColor4 = Color.FromArgb(239, 244, 250);
		groupBox_6.BackColor = backColor4;
		Button value55 = button_8;
		groupBox_6.Controls.Add(value55);
		Button value56 = button_9;
		groupBox_6.Controls.Add(value56);
		DataGridView value57 = dataGridView_2;
		groupBox_6.Controls.Add(value57);
		Point location46 = new Point(446, 22);
		groupBox_6.Location = location46;
		groupBox_6.Name = Class16.smethod_0(1649111662);
		Size size51 = new Size(191, 301);
		groupBox_6.Size = size51;
		groupBox_6.TabIndex = 92;
		groupBox_6.TabStop = false;
		groupBox_6.Text = Class16.smethod_0(1649111672);
		button_8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_8.Enabled = false;
		button_8.Font = new Font(Class16.smethod_0(1648942905), 8f);
		button_8.Image = Resources.cmdDeleteAttach;
		Point location47 = new Point(99, 272);
		button_8.Location = location47;
		button_8.Name = Class16.smethod_0(1649111690);
		Size size52 = new Size(86, 24);
		button_8.Size = size52;
		button_8.TabIndex = 140;
		button_8.Text = Class16.smethod_0(1648925718);
		button_8.TextAlign = ContentAlignment.MiddleRight;
		button_8.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_8.UseVisualStyleBackColor = true;
		button_8.Click += button_8_Click;
		button_9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_9.Font = new Font(Class16.smethod_0(1648942905), 8f);
		button_9.Image = Resources.cmdAddAttach;
		Point location48 = new Point(11, 272);
		button_9.Location = location48;
		button_9.Name = Class16.smethod_0(1649111712);
		Size size53 = new Size(85, 24);
		button_9.Size = size53;
		button_9.TabIndex = 139;
		button_9.Text = Class16.smethod_0(1648931361);
		button_9.TextAlign = ContentAlignment.MiddleRight;
		button_9.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_9.UseVisualStyleBackColor = true;
		button_9.Click += button_9_Click;
		dataGridView_2.AllowUserToAddRows = false;
		dataGridView_2.AllowUserToDeleteRows = false;
		dataGridView_2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Color white2 = Color.White;
		dataGridView_2.BackgroundColor = white2;
		dataGridView_2.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridView_2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DataGridViewColumn[] dataGridViewColumns2 = new DataGridViewColumn[1] { dataGridViewTextBoxColumn_2 };
		dataGridView_2.Columns.AddRange(dataGridViewColumns2);
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		Color white3 = Color.White;
		dataGridViewCellStyle5.BackColor = white3;
		dataGridViewCellStyle5.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color black = Color.Black;
		dataGridViewCellStyle5.ForeColor = black;
		Color highlight3 = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionBackColor = highlight3;
		Color white4 = Color.White;
		dataGridViewCellStyle5.SelectionForeColor = white4;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		dataGridView_2.DefaultCellStyle = dataGridViewCellStyle5;
		Color silver2 = Color.Silver;
		dataGridView_2.GridColor = silver2;
		Point location49 = new Point(11, 22);
		dataGridView_2.Location = location49;
		Padding margin10 = new Padding(3, 4, 3, 4);
		dataGridView_2.Margin = margin10;
		dataGridView_2.MultiSelect = false;
		dataGridView_2.Name = Class16.smethod_0(1649111731);
		dataGridView_2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
		Color control2 = SystemColors.Control;
		dataGridViewCellStyle6.BackColor = control2;
		dataGridViewCellStyle6.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color windowText3 = SystemColors.WindowText;
		dataGridViewCellStyle6.ForeColor = windowText3;
		Color highlight4 = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionBackColor = highlight4;
		Color highlightText2 = SystemColors.HighlightText;
		dataGridViewCellStyle6.SelectionForeColor = highlightText2;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
		dataGridView_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
		dataGridView_2.RowHeadersVisible = false;
		dataGridView_2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle7.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_2.RowsDefaultCellStyle = dataGridViewCellStyle7;
		familyName = Class16.smethod_0(1649143423);
		dataGridView_2.RowTemplate.DefaultCellStyle.Font = new Font(familyName, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_2.RowTemplate.Height = 18;
		dataGridView_2.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_2.ShowCellToolTips = false;
		Size size54 = new Size(174, 248);
		dataGridView_2.Size = size54;
		dataGridView_2.TabIndex = 105;
		dataGridView_2.CellValueChanged += dataGridView_2_CellValueChanged;
		dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle8;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1649111757);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1649111773);
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		NumericUpDown value58 = numericUpDown_10;
		groupBox_4.Controls.Add(value58);
		CheckBox value59 = checkBox_6;
		groupBox_4.Controls.Add(value59);
		CheckBox value60 = checkBox_5;
		groupBox_4.Controls.Add(value60);
		CheckBox value61 = checkBox_4;
		groupBox_4.Controls.Add(value61);
		ComboBox value62 = comboBox_2;
		groupBox_4.Controls.Add(value62);
		ComboBox value63 = comboBox_1;
		groupBox_4.Controls.Add(value63);
		NumericUpDown value64 = numericUpDown_11;
		groupBox_4.Controls.Add(value64);
		NumericUpDown value65 = numericUpDown_12;
		groupBox_4.Controls.Add(value65);
		NumericUpDown value66 = numericUpDown_13;
		groupBox_4.Controls.Add(value66);
		NumericUpDown value67 = numericUpDown_14;
		groupBox_4.Controls.Add(value67);
		NumericUpDown value68 = numericUpDown_9;
		groupBox_4.Controls.Add(value68);
		NumericUpDown value69 = numericUpDown_15;
		groupBox_4.Controls.Add(value69);
		Label value70 = label_10;
		groupBox_4.Controls.Add(value70);
		Label value71 = label_23;
		groupBox_4.Controls.Add(value71);
		Label value72 = label_24;
		groupBox_4.Controls.Add(value72);
		Label value73 = label_9;
		groupBox_4.Controls.Add(value73);
		Label value74 = label_29;
		groupBox_4.Controls.Add(value74);
		Label value75 = label_28;
		groupBox_4.Controls.Add(value75);
		Label value76 = label_27;
		groupBox_4.Controls.Add(value76);
		Label value77 = label_26;
		groupBox_4.Controls.Add(value77);
		Label value78 = label_11;
		groupBox_4.Controls.Add(value78);
		Point location50 = new Point(205, 22);
		groupBox_4.Location = location50;
		groupBox_4.Name = Class16.smethod_0(1649111791);
		Size size55 = new Size(235, 302);
		groupBox_4.Size = size55;
		groupBox_4.TabIndex = 17;
		groupBox_4.TabStop = false;
		groupBox_4.Text = Class16.smethod_0(1649111802);
		numericUpDown_10.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location51 = new Point(105, 209);
		numericUpDown_10.Location = location51;
		decimal maximum15 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_10.Maximum = maximum15;
		decimal minimum15 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_10.Minimum = minimum15;
		numericUpDown_10.Name = Class16.smethod_0(1649111819);
		Size size56 = new Size(119, 21);
		numericUpDown_10.Size = size56;
		numericUpDown_10.TabIndex = 105;
		numericUpDown_10.TextAlign = HorizontalAlignment.Center;
		numericUpDown_10.ThousandsSeparator = true;
		numericUpDown_10.ValueChanged += numericUpDown_10_ValueChanged;
		checkBox_6.AutoSize = true;
		Point location52 = new Point(12, 236);
		checkBox_6.Location = location52;
		Padding margin11 = new Padding(3, 4, 3, 4);
		checkBox_6.Margin = margin11;
		checkBox_6.Name = Class16.smethod_0(1649111840);
		Size size57 = new Size(160, 17);
		checkBox_6.Size = size57;
		checkBox_6.TabIndex = 66;
		checkBox_6.Text = Class16.smethod_0(1649111857);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_6.CheckedChanged += checkBox_6_CheckedChanged;
		checkBox_5.AutoSize = true;
		Point location53 = new Point(12, 254);
		checkBox_5.Location = location53;
		Padding margin12 = new Padding(3, 4, 3, 4);
		checkBox_5.Margin = margin12;
		checkBox_5.Name = Class16.smethod_0(1649111882);
		Size size58 = new Size(124, 17);
		checkBox_5.Size = size58;
		checkBox_5.TabIndex = 78;
		checkBox_5.Text = Class16.smethod_0(1649111910);
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_5.CheckedChanged += checkBox_5_CheckedChanged;
		checkBox_4.AutoSize = true;
		Point location54 = new Point(12, 272);
		checkBox_4.Location = location54;
		Padding margin13 = new Padding(3, 4, 3, 4);
		checkBox_4.Margin = margin13;
		checkBox_4.Name = Class16.smethod_0(1649111932);
		Size size59 = new Size(79, 17);
		checkBox_4.Size = size59;
		checkBox_4.TabIndex = 79;
		checkBox_4.Text = Class16.smethod_0(1649111951);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_4.CheckedChanged += checkBox_4_CheckedChanged;
		comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_2.FormattingEnabled = true;
		object[] items = new object[3]
		{
			Class16.smethod_0(1649111967),
			Class16.smethod_0(1649007040),
			Class16.smethod_0(1649111981)
		};
		comboBox_2.Items.AddRange(items);
		Point location55 = new Point(105, 25);
		comboBox_2.Location = location55;
		comboBox_2.Name = Class16.smethod_0(1649077416);
		Size size60 = new Size(119, 21);
		comboBox_2.Size = size60;
		comboBox_2.TabIndex = 105;
		comboBox_2.SelectedIndexChanged += comboBox_2_SelectedIndexChanged;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.FormattingEnabled = true;
		object[] items2 = new object[3]
		{
			Class16.smethod_0(1649111997),
			Class16.smethod_0(1649112009),
			Class16.smethod_0(1648936686)
		};
		comboBox_1.Items.AddRange(items2);
		Point location56 = new Point(105, 51);
		comboBox_1.Location = location56;
		comboBox_1.Name = Class16.smethod_0(1649112028);
		Size size61 = new Size(119, 21);
		comboBox_1.Size = size61;
		comboBox_1.TabIndex = 81;
		comboBox_1.SelectedIndexChanged += comboBox_1_SelectedIndexChanged;
		numericUpDown_11.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location57 = new Point(105, 187);
		numericUpDown_11.Location = location57;
		decimal maximum16 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_11.Maximum = maximum16;
		decimal minimum16 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_11.Minimum = minimum16;
		numericUpDown_11.Name = Class16.smethod_0(1649112047);
		Size size62 = new Size(119, 21);
		numericUpDown_11.Size = size62;
		numericUpDown_11.TabIndex = 103;
		numericUpDown_11.TextAlign = HorizontalAlignment.Center;
		numericUpDown_11.ThousandsSeparator = true;
		numericUpDown_11.ValueChanged += numericUpDown_11_ValueChanged;
		numericUpDown_12.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location58 = new Point(105, 165);
		numericUpDown_12.Location = location58;
		decimal maximum17 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_12.Maximum = maximum17;
		decimal minimum17 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_12.Minimum = minimum17;
		numericUpDown_12.Name = Class16.smethod_0(1649112057);
		Size size63 = new Size(119, 21);
		numericUpDown_12.Size = size63;
		numericUpDown_12.TabIndex = 99;
		numericUpDown_12.TextAlign = HorizontalAlignment.Center;
		numericUpDown_12.ThousandsSeparator = true;
		numericUpDown_12.ValueChanged += numericUpDown_12_ValueChanged;
		numericUpDown_13.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location59 = new Point(105, 143);
		numericUpDown_13.Location = location59;
		decimal maximum18 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_13.Maximum = maximum18;
		decimal minimum18 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_13.Minimum = minimum18;
		numericUpDown_13.Name = Class16.smethod_0(1649111049);
		Size size64 = new Size(119, 21);
		numericUpDown_13.Size = size64;
		numericUpDown_13.TabIndex = 98;
		numericUpDown_13.TextAlign = HorizontalAlignment.Center;
		numericUpDown_13.ThousandsSeparator = true;
		numericUpDown_13.ValueChanged += numericUpDown_13_ValueChanged;
		numericUpDown_14.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location60 = new Point(105, 121);
		numericUpDown_14.Location = location60;
		decimal maximum19 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_14.Maximum = maximum19;
		decimal minimum19 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_14.Minimum = minimum19;
		numericUpDown_14.Name = Class16.smethod_0(1649111067);
		Size size65 = new Size(119, 21);
		numericUpDown_14.Size = size65;
		numericUpDown_14.TabIndex = 97;
		numericUpDown_14.TextAlign = HorizontalAlignment.Center;
		numericUpDown_14.ThousandsSeparator = true;
		numericUpDown_14.ValueChanged += numericUpDown_14_ValueChanged;
		Color white5 = Color.White;
		numericUpDown_9.BackColor = white5;
		numericUpDown_9.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location61 = new Point(105, 77);
		numericUpDown_9.Location = location61;
		decimal maximum20 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_9.Maximum = maximum20;
		decimal minimum20 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_9.Minimum = minimum20;
		numericUpDown_9.Name = Class16.smethod_0(1649111083);
		Size size66 = new Size(119, 21);
		numericUpDown_9.Size = size66;
		numericUpDown_9.TabIndex = 93;
		numericUpDown_9.TextAlign = HorizontalAlignment.Center;
		numericUpDown_9.ThousandsSeparator = true;
		numericUpDown_9.ValueChanged += numericUpDown_9_ValueChanged;
		numericUpDown_15.Font = new Font(Class16.smethod_0(1649112680), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location62 = new Point(105, 99);
		numericUpDown_15.Location = location62;
		decimal maximum21 = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_15.Maximum = maximum21;
		decimal minimum21 = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_15.Minimum = minimum21;
		numericUpDown_15.Name = Class16.smethod_0(1649111097);
		Size size67 = new Size(119, 21);
		numericUpDown_15.Size = size67;
		numericUpDown_15.TabIndex = 96;
		numericUpDown_15.TextAlign = HorizontalAlignment.Center;
		numericUpDown_15.ThousandsSeparator = true;
		numericUpDown_15.ValueChanged += numericUpDown_15_ValueChanged;
		label_10.AutoSize = true;
		Point location63 = new Point(10, 213);
		label_10.Location = location63;
		label_10.Name = Class16.smethod_0(1649111112);
		Size size68 = new Size(75, 13);
		label_10.Size = size68;
		label_10.TabIndex = 102;
		label_10.Text = Class16.smethod_0(1649111141);
		label_23.AutoSize = true;
		label_23.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location64 = new Point(10, 28);
		label_23.Location = location64;
		label_23.Name = Class16.smethod_0(1649111152);
		Size size69 = new Size(29, 13);
		label_23.Size = size69;
		label_23.TabIndex = 106;
		label_23.Text = Class16.smethod_0(1649014090);
		label_24.AutoSize = true;
		Point location65 = new Point(10, 54);
		label_24.Location = location65;
		label_24.Name = Class16.smethod_0(1649111175);
		Size size70 = new Size(89, 13);
		label_24.Size = size70;
		label_24.TabIndex = 104;
		label_24.Text = Class16.smethod_0(1649111185);
		label_9.AutoSize = true;
		Point location66 = new Point(10, 77);
		label_9.Location = location66;
		label_9.Name = Class16.smethod_0(1649077402);
		Size size71 = new Size(29, 13);
		label_9.Size = size71;
		label_9.TabIndex = 92;
		label_9.Text = Class16.smethod_0(1649014090);
		label_29.AutoSize = true;
		Point location67 = new Point(10, 99);
		label_29.Location = location67;
		label_29.Name = Class16.smethod_0(1649111201);
		Size size72 = new Size(86, 13);
		label_29.Size = size72;
		label_29.TabIndex = 69;
		label_29.Text = Class16.smethod_0(1649111216);
		label_28.AutoSize = true;
		Point location68 = new Point(10, 121);
		label_28.Location = location68;
		label_28.Name = Class16.smethod_0(1649111246);
		Size size73 = new Size(52, 13);
		label_28.Size = size73;
		label_28.TabIndex = 71;
		label_28.Text = Class16.smethod_0(1649111262);
		label_27.AutoSize = true;
		Point location69 = new Point(10, 145);
		label_27.Location = location69;
		label_27.Name = Class16.smethod_0(1649111277);
		Size size74 = new Size(82, 13);
		label_27.Size = size74;
		label_27.TabIndex = 73;
		label_27.Text = Class16.smethod_0(1649111295);
		label_26.AutoSize = true;
		Point location70 = new Point(10, 167);
		label_26.Location = location70;
		label_26.Name = Class16.smethod_0(1649111304);
		Size size75 = new Size(76, 13);
		label_26.Size = size75;
		label_26.TabIndex = 75;
		label_26.Text = Class16.smethod_0(1649111320);
		label_11.AutoSize = true;
		Point location71 = new Point(10, 188);
		label_11.Location = location71;
		label_11.Name = Class16.smethod_0(1649111337);
		Size size76 = new Size(74, 13);
		label_11.Size = size76;
		label_11.TabIndex = 100;
		label_11.Text = Class16.smethod_0(1649111355);
		NumericUpDown value79 = numericUpDown_3;
		groupBox_1.Controls.Add(value79);
		Label value80 = label_3;
		groupBox_1.Controls.Add(value80);
		NumericUpDown value81 = numericUpDown_4;
		groupBox_1.Controls.Add(value81);
		Label value82 = label_4;
		groupBox_1.Controls.Add(value82);
		NumericUpDown value83 = numericUpDown_5;
		groupBox_1.Controls.Add(value83);
		Label value84 = label_5;
		groupBox_1.Controls.Add(value84);
		groupBox_1.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location72 = new Point(11, 226);
		groupBox_1.Location = location72;
		groupBox_1.Name = Class16.smethod_0(1649111382);
		Size size77 = new Size(188, 97);
		groupBox_1.Size = size77;
		groupBox_1.TabIndex = 91;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1649111396);
		numericUpDown_3.DecimalPlaces = 7;
		numericUpDown_3.Font = new Font(Class16.smethod_0(1648942905), 8.7f);
		decimal increment = new decimal(new int[4] { 5, 0, 0, 65536 });
		numericUpDown_3.Increment = increment;
		Point location73 = new Point(27, 67);
		numericUpDown_3.Location = location73;
		decimal maximum22 = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_3.Maximum = maximum22;
		decimal minimum22 = new decimal(new int[4] { 1000000, 0, 0, -2147483648 });
		numericUpDown_3.Minimum = minimum22;
		numericUpDown_3.Name = Class16.smethod_0(1649111401);
		Size size78 = new Size(155, 23);
		numericUpDown_3.Size = size78;
		numericUpDown_3.TabIndex = 79;
		numericUpDown_3.TextAlign = HorizontalAlignment.Center;
		numericUpDown_3.ThousandsSeparator = true;
		numericUpDown_3.ValueChanged += numericUpDown_3_ValueChanged;
		label_3.AutoSize = true;
		label_3.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location74 = new Point(7, 70);
		label_3.Location = location74;
		label_3.Name = Class16.smethod_0(1649111416);
		Size size79 = new Size(17, 15);
		label_3.Size = size79;
		label_3.TabIndex = 78;
		label_3.Text = Class16.smethod_0(1649111438);
		numericUpDown_4.DecimalPlaces = 7;
		numericUpDown_4.Font = new Font(Class16.smethod_0(1648942905), 8.7f);
		decimal increment2 = new decimal(new int[4] { 5, 0, 0, 65536 });
		numericUpDown_4.Increment = increment2;
		Point location75 = new Point(27, 43);
		numericUpDown_4.Location = location75;
		decimal maximum23 = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_4.Maximum = maximum23;
		decimal minimum23 = new decimal(new int[4] { 1000000, 0, 0, -2147483648 });
		numericUpDown_4.Minimum = minimum23;
		numericUpDown_4.Name = Class16.smethod_0(1649111447);
		Size size80 = new Size(155, 23);
		numericUpDown_4.Size = size80;
		numericUpDown_4.TabIndex = 77;
		numericUpDown_4.TextAlign = HorizontalAlignment.Center;
		numericUpDown_4.ThousandsSeparator = true;
		numericUpDown_4.ValueChanged += numericUpDown_4_ValueChanged;
		label_4.AutoSize = true;
		label_4.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location76 = new Point(7, 46);
		label_4.Location = location76;
		label_4.Name = Class16.smethod_0(1649111462);
		Size size81 = new Size(17, 15);
		label_4.Size = size81;
		label_4.TabIndex = 76;
		label_4.Text = Class16.smethod_0(1649013950);
		numericUpDown_5.DecimalPlaces = 7;
		numericUpDown_5.Font = new Font(Class16.smethod_0(1648942905), 8.7f);
		decimal increment3 = new decimal(new int[4] { 5, 0, 0, 65536 });
		numericUpDown_5.Increment = increment3;
		Point location77 = new Point(27, 19);
		numericUpDown_5.Location = location77;
		decimal maximum24 = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_5.Maximum = maximum24;
		decimal minimum24 = new decimal(new int[4] { 1000000, 0, 0, -2147483648 });
		numericUpDown_5.Minimum = minimum24;
		numericUpDown_5.Name = Class16.smethod_0(1649111476);
		Size size82 = new Size(155, 23);
		numericUpDown_5.Size = size82;
		numericUpDown_5.TabIndex = 75;
		numericUpDown_5.TextAlign = HorizontalAlignment.Center;
		numericUpDown_5.ThousandsSeparator = true;
		numericUpDown_5.ValueChanged += numericUpDown_5_ValueChanged;
		label_5.AutoSize = true;
		label_5.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location78 = new Point(7, 22);
		label_5.Location = location78;
		label_5.Name = Class16.smethod_0(1649111483);
		Size size83 = new Size(17, 15);
		label_5.Size = size83;
		label_5.TabIndex = 74;
		label_5.Text = Class16.smethod_0(1649013968);
		NumericUpDown value85 = numericUpDown_6;
		groupBox_2.Controls.Add(value85);
		Label value86 = label_6;
		groupBox_2.Controls.Add(value86);
		NumericUpDown value87 = numericUpDown_7;
		groupBox_2.Controls.Add(value87);
		Label value88 = label_7;
		groupBox_2.Controls.Add(value88);
		NumericUpDown value89 = numericUpDown_8;
		groupBox_2.Controls.Add(value89);
		Label value90 = label_8;
		groupBox_2.Controls.Add(value90);
		groupBox_2.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location79 = new Point(11, 125);
		groupBox_2.Location = location79;
		groupBox_2.Name = Class16.smethod_0(1649111497);
		Size size84 = new Size(188, 97);
		groupBox_2.Size = size84;
		groupBox_2.TabIndex = 90;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1649111524);
		numericUpDown_6.DecimalPlaces = 7;
		numericUpDown_6.Font = new Font(Class16.smethod_0(1648942905), 8.7f);
		decimal increment4 = new decimal(new int[4] { 5, 0, 0, 65536 });
		numericUpDown_6.Increment = increment4;
		Point location80 = new Point(27, 68);
		numericUpDown_6.Location = location80;
		decimal maximum25 = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_6.Maximum = maximum25;
		decimal minimum25 = new decimal(new int[4] { 1000000, 0, 0, -2147483648 });
		numericUpDown_6.Minimum = minimum25;
		numericUpDown_6.Name = Class16.smethod_0(1649111535);
		Size size85 = new Size(155, 23);
		numericUpDown_6.Size = size85;
		numericUpDown_6.TabIndex = 79;
		numericUpDown_6.TextAlign = HorizontalAlignment.Center;
		numericUpDown_6.ThousandsSeparator = true;
		numericUpDown_6.ValueChanged += numericUpDown_6_ValueChanged;
		label_6.AutoSize = true;
		label_6.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location81 = new Point(7, 72);
		label_6.Location = location81;
		label_6.Name = Class16.smethod_0(1648912200);
		Size size86 = new Size(17, 15);
		label_6.Size = size86;
		label_6.TabIndex = 78;
		label_6.Text = Class16.smethod_0(1649111438);
		numericUpDown_7.DecimalPlaces = 7;
		numericUpDown_7.Font = new Font(Class16.smethod_0(1648942905), 8.7f);
		decimal increment5 = new decimal(new int[4] { 5, 0, 0, 65536 });
		numericUpDown_7.Increment = increment5;
		Point location82 = new Point(27, 44);
		numericUpDown_7.Location = location82;
		decimal maximum26 = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_7.Maximum = maximum26;
		decimal minimum26 = new decimal(new int[4] { 1000000, 0, 0, -2147483648 });
		numericUpDown_7.Minimum = minimum26;
		numericUpDown_7.Name = Class16.smethod_0(1649111549);
		Size size87 = new Size(155, 23);
		numericUpDown_7.Size = size87;
		numericUpDown_7.TabIndex = 77;
		numericUpDown_7.TextAlign = HorizontalAlignment.Center;
		numericUpDown_7.ThousandsSeparator = true;
		numericUpDown_7.ValueChanged += numericUpDown_7_ValueChanged;
		label_7.AutoSize = true;
		label_7.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location83 = new Point(7, 47);
		label_7.Location = location83;
		label_7.Name = Class16.smethod_0(1648912262);
		Size size88 = new Size(17, 15);
		label_7.Size = size88;
		label_7.TabIndex = 76;
		label_7.Text = Class16.smethod_0(1649013950);
		numericUpDown_8.DecimalPlaces = 7;
		numericUpDown_8.Font = new Font(Class16.smethod_0(1648942905), 8.7f);
		decimal increment6 = new decimal(new int[4] { 5, 0, 0, 65536 });
		numericUpDown_8.Increment = increment6;
		Point location84 = new Point(27, 20);
		numericUpDown_8.Location = location84;
		decimal maximum27 = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_8.Maximum = maximum27;
		decimal minimum27 = new decimal(new int[4] { 1000000, 0, 0, -2147483648 });
		numericUpDown_8.Minimum = minimum27;
		numericUpDown_8.Name = Class16.smethod_0(1649114627);
		Size size89 = new Size(155, 23);
		numericUpDown_8.Size = size89;
		numericUpDown_8.TabIndex = 75;
		numericUpDown_8.TextAlign = HorizontalAlignment.Center;
		numericUpDown_8.ThousandsSeparator = true;
		numericUpDown_8.ValueChanged += numericUpDown_8_ValueChanged;
		label_8.AutoSize = true;
		label_8.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location85 = new Point(7, 23);
		label_8.Location = location85;
		label_8.Name = Class16.smethod_0(1648930240);
		Size size90 = new Size(17, 15);
		label_8.Size = size90;
		label_8.TabIndex = 74;
		label_8.Text = Class16.smethod_0(1649013968);
		NumericUpDown value91 = numericUpDown_0;
		groupBox_0.Controls.Add(value91);
		Label value92 = label_0;
		groupBox_0.Controls.Add(value92);
		NumericUpDown value93 = numericUpDown_1;
		groupBox_0.Controls.Add(value93);
		Label value94 = label_1;
		groupBox_0.Controls.Add(value94);
		NumericUpDown value95 = numericUpDown_2;
		groupBox_0.Controls.Add(value95);
		Label value96 = label_2;
		groupBox_0.Controls.Add(value96);
		groupBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location86 = new Point(11, 21);
		groupBox_0.Location = location86;
		groupBox_0.Name = Class16.smethod_0(1649114641);
		Size size91 = new Size(188, 97);
		groupBox_0.Size = size91;
		groupBox_0.TabIndex = 89;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1648893587);
		numericUpDown_0.DecimalPlaces = 7;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 8.7f);
		decimal increment7 = new decimal(new int[4] { 5, 0, 0, 65536 });
		numericUpDown_0.Increment = increment7;
		Point location87 = new Point(27, 68);
		numericUpDown_0.Location = location87;
		decimal maximum28 = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_0.Maximum = maximum28;
		decimal minimum28 = new decimal(new int[4] { 1000000, 0, 0, -2147483648 });
		numericUpDown_0.Minimum = minimum28;
		numericUpDown_0.Name = Class16.smethod_0(1649114659);
		Size size92 = new Size(155, 23);
		numericUpDown_0.Size = size92;
		numericUpDown_0.TabIndex = 73;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.ThousandsSeparator = true;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location88 = new Point(7, 72);
		label_0.Location = location88;
		label_0.Name = Class16.smethod_0(1648912145);
		Size size93 = new Size(17, 15);
		label_0.Size = size93;
		label_0.TabIndex = 72;
		label_0.Text = Class16.smethod_0(1649111438);
		numericUpDown_1.DecimalPlaces = 7;
		numericUpDown_1.Font = new Font(Class16.smethod_0(1648942905), 8.7f);
		decimal increment8 = new decimal(new int[4] { 5, 0, 0, 65536 });
		numericUpDown_1.Increment = increment8;
		Point location89 = new Point(27, 44);
		numericUpDown_1.Location = location89;
		decimal maximum29 = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_1.Maximum = maximum29;
		decimal minimum29 = new decimal(new int[4] { 1000000, 0, 0, -2147483648 });
		numericUpDown_1.Minimum = minimum29;
		numericUpDown_1.Name = Class16.smethod_0(1649114673);
		Size size94 = new Size(155, 23);
		numericUpDown_1.Size = size94;
		numericUpDown_1.TabIndex = 71;
		numericUpDown_1.TextAlign = HorizontalAlignment.Center;
		numericUpDown_1.ThousandsSeparator = true;
		numericUpDown_1.ValueChanged += numericUpDown_1_ValueChanged;
		label_1.AutoSize = true;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location90 = new Point(7, 47);
		label_1.Location = location90;
		label_1.Name = Class16.smethod_0(1648912083);
		Size size95 = new Size(17, 15);
		label_1.Size = size95;
		label_1.TabIndex = 70;
		label_1.Text = Class16.smethod_0(1649013950);
		Color white6 = Color.White;
		numericUpDown_2.BackColor = white6;
		numericUpDown_2.DecimalPlaces = 7;
		numericUpDown_2.Font = new Font(Class16.smethod_0(1648942905), 8.7f);
		decimal increment9 = new decimal(new int[4] { 5, 0, 0, 65536 });
		numericUpDown_2.Increment = increment9;
		Point location91 = new Point(27, 20);
		numericUpDown_2.Location = location91;
		decimal maximum30 = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_2.Maximum = maximum30;
		decimal minimum30 = new decimal(new int[4] { 1000000, 0, 0, -2147483648 });
		numericUpDown_2.Minimum = minimum30;
		numericUpDown_2.Name = Class16.smethod_0(1649114695);
		Size size96 = new Size(155, 23);
		numericUpDown_2.Size = size96;
		numericUpDown_2.TabIndex = 69;
		numericUpDown_2.TextAlign = HorizontalAlignment.Center;
		numericUpDown_2.ThousandsSeparator = true;
		numericUpDown_2.ValueChanged += numericUpDown_2_ValueChanged;
		label_2.AutoSize = true;
		label_2.Font = new Font(Class16.smethod_0(1648942905), 9f);
		Point location92 = new Point(7, 23);
		label_2.Location = location92;
		label_2.Name = Class16.smethod_0(1648919238);
		Size size97 = new Size(17, 15);
		label_2.Size = size97;
		label_2.TabIndex = 68;
		label_2.Text = Class16.smethod_0(1649013968);
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_0.Image = Resources.cmdAddGroup;
		Point location93 = new Point(7, 557);
		button_0.Location = location93;
		button_0.Name = Class16.smethod_0(1649114709);
		Size size98 = new Size(166, 25);
		button_0.Size = size98;
		button_0.TabIndex = 33;
		button_0.Text = Class16.smethod_0(1648931361);
		button_0.TextAlign = ContentAlignment.MiddleRight;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToDeleteRows = false;
		dataGridView_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		Color backgroundColor2 = SystemColors.Window;
		dataGridView_1.BackgroundColor = backgroundColor2;
		dataGridView_1.BorderStyle = BorderStyle.None;
		dataGridView_1.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridView_1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DataGridViewColumn[] dataGridViewColumns3 = new DataGridViewColumn[3] { dataGridViewTextBoxColumn_3, dataGridViewTextBoxColumn_4, dataGridViewTextBoxColumn_5 };
		dataGridView_1.Columns.AddRange(dataGridViewColumns3);
		dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
		Color backColor5 = SystemColors.Window;
		dataGridViewCellStyle9.BackColor = backColor5;
		dataGridViewCellStyle9.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color windowText4 = SystemColors.WindowText;
		dataGridViewCellStyle9.ForeColor = windowText4;
		Color highlight5 = SystemColors.Highlight;
		dataGridViewCellStyle9.SelectionBackColor = highlight5;
		Color white7 = Color.White;
		dataGridViewCellStyle9.SelectionForeColor = white7;
		dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
		dataGridView_1.DefaultCellStyle = dataGridViewCellStyle9;
		dataGridView_1.EditMode = DataGridViewEditMode.EditOnEnter;
		Color silver3 = Color.Silver;
		dataGridView_1.GridColor = silver3;
		Point location94 = new Point(7, 44);
		dataGridView_1.Location = location94;
		Padding margin14 = new Padding(3, 4, 3, 4);
		dataGridView_1.Margin = margin14;
		dataGridView_1.Name = Class16.smethod_0(1649114727);
		dataGridView_1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
		Color control3 = SystemColors.Control;
		dataGridViewCellStyle10.BackColor = control3;
		dataGridViewCellStyle10.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color windowText5 = SystemColors.WindowText;
		dataGridViewCellStyle10.ForeColor = windowText5;
		Color highlight6 = SystemColors.Highlight;
		dataGridViewCellStyle10.SelectionBackColor = highlight6;
		Color highlightText3 = SystemColors.HighlightText;
		dataGridViewCellStyle10.SelectionForeColor = highlightText3;
		dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
		dataGridView_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
		dataGridView_1.RowHeadersVisible = false;
		dataGridView_1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle11.Font = new Font(Class16.smethod_0(1649143423), 9f);
		dataGridView_1.RowsDefaultCellStyle = dataGridViewCellStyle11;
		string familyName2 = Class16.smethod_0(1649143423);
		dataGridView_1.RowTemplate.DefaultCellStyle.Font = new Font(familyName2, 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_1.RowTemplate.Height = 18;
		dataGridView_1.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_1.ShowCellToolTips = false;
		Size size99 = new Size(334, 511);
		dataGridView_1.Size = size99;
		dataGridView_1.TabIndex = 0;
		dataGridView_1.SelectionChanged += dataGridView_1_SelectionChanged;
		dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.TopCenter;
		Color silver4 = Color.Silver;
		dataGridViewCellStyle12.ForeColor = silver4;
		dataGridViewTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle12;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1649114743);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1648910847);
		dataGridViewTextBoxColumn_3.ReadOnly = true;
		dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_3.Width = 60;
		dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.TopCenter;
		Color foreColor2 = Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle13.ForeColor = foreColor2;
		dataGridViewTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle13;
		dataGridViewTextBoxColumn_4.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_4.Name = Class16.smethod_0(1649065590);
		dataGridViewTextBoxColumn_4.ReadOnly = true;
		dataGridViewTextBoxColumn_4.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_4.Width = 60;
		dataGridViewTextBoxColumn_5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_5.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_5.Name = Class16.smethod_0(1649012442);
		dataGridViewTextBoxColumn_5.ReadOnly = true;
		dataGridViewTextBoxColumn_5.SortMode = DataGridViewColumnSortMode.NotSortable;
		Point location95 = new Point(4, 22);
		tabPage_0.Location = location95;
		tabPage_0.Name = Class16.smethod_0(1649114744);
		Padding padding5 = new Padding(3);
		tabPage_0.Padding = padding5;
		Size size100 = new Size(998, 588);
		tabPage_0.Size = size100;
		tabPage_0.TabIndex = 1;
		tabPage_0.Text = Class16.smethod_0(1649008358);
		tabPage_0.UseVisualStyleBackColor = true;
		Point location96 = new Point(4, 22);
		tabPage_1.Location = location96;
		tabPage_1.Name = Class16.smethod_0(1649114763);
		Padding padding6 = new Padding(3);
		tabPage_1.Padding = padding6;
		Size size101 = new Size(998, 588);
		tabPage_1.Size = size101;
		tabPage_1.TabIndex = 2;
		tabPage_1.Text = Class16.smethod_0(1649114791);
		tabPage_1.UseVisualStyleBackColor = true;
		TableLayoutPanel value97 = tableLayoutPanel_0;
		tabPage_2.Controls.Add(value97);
		PropertyGrid value98 = propertyGrid_0;
		tabPage_2.Controls.Add(value98);
		Point location97 = new Point(4, 22);
		tabPage_2.Location = location97;
		tabPage_2.Name = Class16.smethod_0(1649114813);
		Padding padding7 = new Padding(3);
		tabPage_2.Padding = padding7;
		Size size102 = new Size(998, 588);
		tabPage_2.Size = size102;
		tabPage_2.TabIndex = 3;
		tabPage_2.Text = Class16.smethod_0(1648942688);
		tabPage_2.UseVisualStyleBackColor = true;
		tableLayoutPanel_0.ColumnCount = 2;
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		Button control4 = button_11;
		tableLayoutPanel_0.Controls.Add(control4, 0, 1);
		Button control5 = button_12;
		tableLayoutPanel_0.Controls.Add(control5, 1, 1);
		DataGridView control6 = dataGridView_3;
		tableLayoutPanel_0.Controls.Add(control6, 0, 0);
		Point location98 = new Point(3, 3);
		tableLayoutPanel_0.Location = location98;
		tableLayoutPanel_0.Name = Class16.smethod_0(1648929366);
		tableLayoutPanel_0.RowCount = 2;
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		Size size103 = new Size(434, 584);
		tableLayoutPanel_0.Size = size103;
		tableLayoutPanel_0.TabIndex = 75;
		button_11.Dock = DockStyle.Fill;
		button_11.Image = Resources.cmdAddTrigger;
		Point location99 = new Point(3, 557);
		button_11.Location = location99;
		button_11.Name = Class16.smethod_0(1649114831);
		Size size104 = new Size(211, 24);
		button_11.Size = size104;
		button_11.TabIndex = 72;
		button_11.Text = Class16.smethod_0(1648931361);
		button_11.TextAlign = ContentAlignment.MiddleRight;
		button_11.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_11.UseVisualStyleBackColor = true;
		button_11.Click += button_11_Click;
		button_12.Dock = DockStyle.Fill;
		button_12.Enabled = false;
		button_12.Image = Resources.cmdDeleteTrigger;
		Point location100 = new Point(220, 557);
		button_12.Location = location100;
		button_12.Name = Class16.smethod_0(1649114843);
		Size size105 = new Size(211, 24);
		button_12.Size = size105;
		button_12.TabIndex = 73;
		button_12.Text = Class16.smethod_0(1648925718);
		button_12.TextAlign = ContentAlignment.MiddleRight;
		button_12.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_12.UseVisualStyleBackColor = true;
		button_12.Click += button_12_Click;
		dataGridView_3.AllowUserToAddRows = false;
		dataGridView_3.AllowUserToDeleteRows = false;
		Color backgroundColor3 = SystemColors.Window;
		dataGridView_3.BackgroundColor = backgroundColor3;
		dataGridView_3.BorderStyle = BorderStyle.None;
		dataGridView_3.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_3.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridView_3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DataGridViewColumn[] dataGridViewColumns4 = new DataGridViewColumn[3] { dataGridViewTextBoxColumn_6, dataGridViewTextBoxColumn_7, dataGridViewTextBoxColumn_8 };
		dataGridView_3.Columns.AddRange(dataGridViewColumns4);
		tableLayoutPanel_0.SetColumnSpan(dataGridView_3, 2);
		dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
		Color backColor6 = SystemColors.Window;
		dataGridViewCellStyle14.BackColor = backColor6;
		dataGridViewCellStyle14.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color windowText6 = SystemColors.WindowText;
		dataGridViewCellStyle14.ForeColor = windowText6;
		Color highlight7 = SystemColors.Highlight;
		dataGridViewCellStyle14.SelectionBackColor = highlight7;
		Color white8 = Color.White;
		dataGridViewCellStyle14.SelectionForeColor = white8;
		dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
		dataGridView_3.DefaultCellStyle = dataGridViewCellStyle14;
		dataGridView_3.Dock = DockStyle.Fill;
		dataGridView_3.EditMode = DataGridViewEditMode.EditOnEnter;
		Color silver5 = Color.Silver;
		dataGridView_3.GridColor = silver5;
		Point location101 = new Point(3, 4);
		dataGridView_3.Location = location101;
		Padding margin15 = new Padding(3, 4, 3, 4);
		dataGridView_3.Margin = margin15;
		dataGridView_3.MultiSelect = false;
		dataGridView_3.Name = Class16.smethod_0(1649114866);
		dataGridView_3.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
		Color control7 = SystemColors.Control;
		dataGridViewCellStyle15.BackColor = control7;
		dataGridViewCellStyle15.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color windowText7 = SystemColors.WindowText;
		dataGridViewCellStyle15.ForeColor = windowText7;
		Color highlight8 = SystemColors.Highlight;
		dataGridViewCellStyle15.SelectionBackColor = highlight8;
		Color highlightText4 = SystemColors.HighlightText;
		dataGridViewCellStyle15.SelectionForeColor = highlightText4;
		dataGridViewCellStyle15.WrapMode = DataGridViewTriState.False;
		dataGridView_3.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
		dataGridView_3.RowHeadersVisible = false;
		dataGridView_3.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle16.Font = new Font(Class16.smethod_0(1649143423), 9f);
		dataGridView_3.RowsDefaultCellStyle = dataGridViewCellStyle16;
		familyName2 = Class16.smethod_0(1649143423);
		dataGridView_3.RowTemplate.DefaultCellStyle.Font = new Font(familyName2, 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_3.RowTemplate.Height = 18;
		dataGridView_3.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_3.ShowCellToolTips = false;
		Size size106 = new Size(428, 546);
		dataGridView_3.Size = size106;
		dataGridView_3.TabIndex = 1;
		dataGridView_3.SelectionChanged += dataGridView_3_SelectionChanged;
		Point location102 = new Point(443, 3);
		propertyGrid_0.Location = location102;
		propertyGrid_0.Name = Class16.smethod_0(1649114892);
		Size size107 = new Size(557, 582);
		propertyGrid_0.Size = size107;
		propertyGrid_0.TabIndex = 74;
		propertyGrid_0.PropertyValueChanged += propertyGrid_0_PropertyValueChanged;
		Point location103 = new Point(4, 22);
		tabPage_3.Location = location103;
		tabPage_3.Name = Class16.smethod_0(1649114916);
		Padding padding8 = new Padding(3);
		tabPage_3.Padding = padding8;
		Size size108 = new Size(998, 588);
		tabPage_3.Size = size108;
		tabPage_3.TabIndex = 4;
		tabPage_3.Text = Class16.smethod_0(1649114933);
		tabPage_3.UseVisualStyleBackColor = true;
		Point location104 = new Point(1, 655);
		progressBar_0.Location = location104;
		progressBar_0.Name = Class16.smethod_0(1649072588);
		Size size109 = new Size(1003, 23);
		progressBar_0.Size = size109;
		progressBar_0.TabIndex = 12;
		Color white9 = Color.White;
		textBox_1.BackColor = white9;
		Point location105 = new Point(101, 13);
		textBox_1.Location = location105;
		textBox_1.Name = Class16.smethod_0(1649012295);
		textBox_1.ReadOnly = true;
		Size size110 = new Size(686, 22);
		textBox_1.Size = size110;
		textBox_1.TabIndex = 36;
		textBox_1.TextAlign = HorizontalAlignment.Center;
		button_6.Enabled = false;
		button_6.Image = Resources.cmdSave;
		Point location106 = new Point(894, 11);
		button_6.Location = location106;
		button_6.Name = Class16.smethod_0(1648920967);
		Size size111 = new Size(102, 25);
		button_6.Size = size111;
		button_6.TabIndex = 38;
		button_6.Text = Class16.smethod_0(1648941761);
		button_6.TextAlign = ContentAlignment.MiddleRight;
		button_6.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		button_7.Image = Resources.cmdOpen;
		Point location107 = new Point(789, 11);
		button_7.Location = location107;
		button_7.Name = Class16.smethod_0(1648920945);
		Size size112 = new Size(102, 25);
		button_7.Size = size112;
		button_7.TabIndex = 39;
		button_7.Text = Class16.smethod_0(1648931498);
		button_7.TextAlign = ContentAlignment.MiddleRight;
		button_7.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		label_25.AutoSize = true;
		label_25.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		Point location108 = new Point(7, 15);
		label_25.Location = location108;
		label_25.Name = Class16.smethod_0(1649114944);
		Size size113 = new Size(78, 15);
		label_25.Size = size113;
		label_25.TabIndex = 72;
		label_25.Text = Class16.smethod_0(1649114972);
		Label value99 = label_25;
		groupBox_7.Controls.Add(value99);
		Button value100 = button_7;
		groupBox_7.Controls.Add(value100);
		TextBox value101 = textBox_1;
		groupBox_7.Controls.Add(value101);
		Button value102 = button_6;
		groupBox_7.Controls.Add(value102);
		Point location109 = new Point(3, -3);
		groupBox_7.Location = location109;
		groupBox_7.Name = Class16.smethod_0(1648929126);
		Size size114 = new Size(1001, 41);
		groupBox_7.Size = size114;
		groupBox_7.TabIndex = 80;
		groupBox_7.TabStop = false;
		dataGridViewTextBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.TopCenter;
		Color silver6 = Color.Silver;
		dataGridViewCellStyle17.ForeColor = silver6;
		dataGridViewTextBoxColumn_6.DefaultCellStyle = dataGridViewCellStyle17;
		dataGridViewTextBoxColumn_6.HeaderText = Class16.smethod_0(1649114743);
		dataGridViewTextBoxColumn_6.Name = Class16.smethod_0(1648914199);
		dataGridViewTextBoxColumn_6.ReadOnly = true;
		dataGridViewTextBoxColumn_6.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_6.Visible = false;
		dataGridViewTextBoxColumn_6.Width = 60;
		dataGridViewTextBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.TopCenter;
		Color foreColor3 = Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle18.ForeColor = foreColor3;
		dataGridViewTextBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle18;
		dataGridViewTextBoxColumn_7.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_7.Name = Class16.smethod_0(1648913143);
		dataGridViewTextBoxColumn_7.ReadOnly = true;
		dataGridViewTextBoxColumn_7.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_7.Width = 60;
		dataGridViewTextBoxColumn_8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_8.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_8.Name = Class16.smethod_0(1649065623);
		dataGridViewTextBoxColumn_8.ReadOnly = true;
		dataGridViewTextBoxColumn_8.SortMode = DataGridViewColumnSortMode.NotSortable;
		base.AcceptButton = button_10;
		SizeF sizeF = new SizeF(6f, 13f);
		base.AutoScaleDimensions = sizeF;
		base.AutoScaleMode = AutoScaleMode.Font;
		Color backColor7 = Color.FromArgb(239, 244, 250);
		BackColor = backColor7;
		Size clientSize = new Size(1006, 680);
		base.ClientSize = clientSize;
		ProgressBar value103 = progressBar_0;
		base.Controls.Add(value103);
		TabControl value104 = tabControl_0;
		base.Controls.Add(value104);
		GroupBox value105 = groupBox_7;
		base.Controls.Add(value105);
		MenuStrip value106 = menuStrip_0;
		base.Controls.Add(value106);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.NPCGenEditor_Icon;
		base.MainMenuStrip = menuStrip_0;
		Padding margin16 = new Padding(3, 4, 3, 4);
		base.Margin = margin16;
		base.MaximizeBox = false;
		base.Name = Class16.smethod_0(1648906758);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649114991);
		base.FormClosing += NPCGenEditor_FormClosing;
		base.Shown += NPCGenEditor_Shown;
		base.Activated += NPCGenEditor_Activated;
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		tabControl_0.ResumeLayout(performLayout: false);
		tabPage_4.ResumeLayout(performLayout: false);
		tabPage_4.PerformLayout();
		groupBox_3.ResumeLayout(performLayout: false);
		groupBox_8.ResumeLayout(performLayout: false);
		groupBox_5.ResumeLayout(performLayout: false);
		groupBox_5.PerformLayout();
		((ISupportInitialize)numericUpDown_19).EndInit();
		((ISupportInitialize)numericUpDown_26).EndInit();
		((ISupportInitialize)numericUpDown_18).EndInit();
		((ISupportInitialize)numericUpDown_25).EndInit();
		((ISupportInitialize)numericUpDown_24).EndInit();
		((ISupportInitialize)numericUpDown_23).EndInit();
		((ISupportInitialize)numericUpDown_20).EndInit();
		((ISupportInitialize)numericUpDown_16).EndInit();
		((ISupportInitialize)numericUpDown_17).EndInit();
		((ISupportInitialize)numericUpDown_29).EndInit();
		((ISupportInitialize)numericUpDown_22).EndInit();
		((ISupportInitialize)numericUpDown_21).EndInit();
		((ISupportInitialize)numericUpDown_28).EndInit();
		((ISupportInitialize)numericUpDown_27).EndInit();
		((ISupportInitialize)dataGridView_0).EndInit();
		groupBox_9.ResumeLayout(performLayout: false);
		groupBox_6.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_2).EndInit();
		groupBox_4.ResumeLayout(performLayout: false);
		groupBox_4.PerformLayout();
		((ISupportInitialize)numericUpDown_10).EndInit();
		((ISupportInitialize)numericUpDown_11).EndInit();
		((ISupportInitialize)numericUpDown_12).EndInit();
		((ISupportInitialize)numericUpDown_13).EndInit();
		((ISupportInitialize)numericUpDown_14).EndInit();
		((ISupportInitialize)numericUpDown_9).EndInit();
		((ISupportInitialize)numericUpDown_15).EndInit();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		((ISupportInitialize)numericUpDown_3).EndInit();
		((ISupportInitialize)numericUpDown_4).EndInit();
		((ISupportInitialize)numericUpDown_5).EndInit();
		groupBox_2.ResumeLayout(performLayout: false);
		groupBox_2.PerformLayout();
		((ISupportInitialize)numericUpDown_6).EndInit();
		((ISupportInitialize)numericUpDown_7).EndInit();
		((ISupportInitialize)numericUpDown_8).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		((ISupportInitialize)numericUpDown_2).EndInit();
		((ISupportInitialize)dataGridView_1).EndInit();
		tabPage_2.ResumeLayout(performLayout: false);
		tableLayoutPanel_0.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_3).EndInit();
		groupBox_7.ResumeLayout(performLayout: false);
		groupBox_7.PerformLayout();
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
				method_4();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void method_6(int int_0, [MarshalAs(UnmanagedType.U1)] bool bool_1, [MarshalAs(UnmanagedType.U1)] bool bool_2)
	{
		string empty = string.Empty;
		string dest = empty;
		string dest2 = empty;
		Color foreColor = Color.White;
		bool flag = false;
		int num = 0;
		NpcGenEntry[] gens = NPCGen.AIGens[int_0].Gens;
		if (0 < (nint)gens.LongLength)
		{
			do
			{
				int dwID = gens[num].dwID;
				int num2 = dwID;
				ACE.RSGlobal.RSGlobal.AppendStringValue(ref dest, num2.ToString());
				ITEMINFO itemInfoByID = eLC.GetItemInfoByID(MobsList, dwID);
				if (itemInfoByID == null)
				{
					itemInfoByID = eLC.GetItemInfoByID(NPCsList, dwID);
					flag = true;
					if (itemInfoByID == null)
					{
						if (dwID != 0)
						{
							string value = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
							ACE.RSGlobal.RSGlobal.AppendStringValue(ref dest2, value);
							foreColor = Color.Red;
						}
						else
						{
							string value2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648971625));
							ACE.RSGlobal.RSGlobal.AppendStringValue(ref dest2, value2);
						}
						goto IL_0087;
					}
				}
				ACE.RSGlobal.RSGlobal.AppendStringValue(ref dest2, itemInfoByID.name);
				foreColor = itemInfoByID.color;
				if (!flag)
				{
					eLC.GetPowerLVL(itemInfoByID.pos);
				}
				NPCGen.AIGens[int_0].Gens[num].ItemPos = itemInfoByID.pos;
				goto IL_0087;
				IL_0087:
				num++;
				gens = NPCGen.AIGens[int_0].Gens;
			}
			while (num < (nint)gens.LongLength);
		}
		if (dest == string.Empty)
		{
			dest = TextStorage.TEXTS.GetText(Class16.smethod_0(1648971625));
			dest2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648971625));
		}
		int num3 = NPCGen.AIGens[int_0].Gens.Length;
		string text2;
		if (num3 > 1)
		{
			string text = Class16.smethod_0(1648942897);
			text2 = string.Concat(Class16.smethod_0(1648942889) + num3, text);
		}
		else
		{
			text2 = string.Empty;
		}
		if (bool_1)
		{
			dataGridViewRow_0[int_0] = new DataGridViewRow();
			dataGridViewRow_0[int_0].Resizable = DataGridViewTriState.False;
			string[] array = new string[3];
			string text3 = int_0 + 1 + text2;
			array[0] = text3;
			array[1] = dest;
			array[2] = dest2;
			DataGridViewRow obj = dataGridViewRow_0[int_0];
			DataGridView dataGridView = dataGridView_1;
			object[] values = array;
			obj.CreateCells(dataGridView, values);
			dataGridViewRow_0[int_0].Cells[1].Style.ForeColor = foreColor;
			dataGridViewRow_0[int_0].Cells[2].Style.ForeColor = foreColor;
		}
		else
		{
			if (bool_2)
			{
				string[] array2 = new string[3]
				{
					(int_0 + 1).ToString(),
					dest,
					dest2
				};
				DataGridViewRowCollection rows = dataGridView_1.Rows;
				object[] values = array2;
				rows.Add(values);
			}
			else
			{
				dataGridView_1[0, int_0].Value = int_0 + 1 + text2;
				dataGridView_1[1, int_0].Value = dest;
				dataGridView_1[2, int_0].Value = dest2;
			}
			dataGridView_1[1, int_0].Style.ForeColor = foreColor;
			dataGridView_1[2, int_0].Style.ForeColor = foreColor;
		}
		byte b = ((dataGridView_1.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_3.Enabled = b != 0;
		GC.KeepAlive(this);
	}

	private void method_7(int int_0)
	{
		method_8(int_0, bool_1: true);
	}

	private void method_8(int int_0, [MarshalAs(UnmanagedType.U1)] bool bool_1)
	{
		int dwID = NPCGen.AIGens[SelectedGroup].Gens[int_0].dwID;
		Color foreColor = default(Color);
		int mobsList = MobsList;
		eListCollection eListCollection2 = eLC;
		ITEMPOS iTEMPOS = null;
		int num = eListCollection2.FindItemIndexByID(mobsList, dwID);
		if (num > -1)
		{
			iTEMPOS = new ITEMPOS(mobsList, num);
		}
		ITEMPOS iTEMPOS2 = iTEMPOS;
		string parsedItemName;
		if (iTEMPOS == null)
		{
			int nPCsList = NPCsList;
			eListCollection eListCollection3 = eLC;
			ITEMPOS iTEMPOS3 = null;
			int num2 = eListCollection3.FindItemIndexByID(nPCsList, dwID);
			if (num2 > -1)
			{
				iTEMPOS3 = new ITEMPOS(nPCsList, num2);
			}
			iTEMPOS2 = iTEMPOS3;
			if (iTEMPOS3 == null)
			{
				if (dwID != 0)
				{
					parsedItemName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
					foreColor = Color.Red;
				}
				else
				{
					parsedItemName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648971625));
				}
				goto IL_0103;
			}
		}
		parsedItemName = eLC.GetParsedItemName(iTEMPOS2);
		foreColor = eLC.GetItemColor(iTEMPOS2.int_0, iTEMPOS2.int_1);
		goto IL_0103;
		IL_0103:
		if (bool_1)
		{
			string[] array = new string[2];
			int num3 = dwID;
			array[0] = num3.ToString();
			array[1] = parsedItemName;
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			object[] values = array;
			rows.Add(values);
		}
		else
		{
			int num4 = dwID;
			dataGridView_0[0, int_0].Value = num4.ToString();
			dataGridView_0[1, int_0].Value = parsedItemName;
		}
		dataGridView_0[1, int_0].Style.ForeColor = foreColor;
		GC.KeepAlive(this);
	}

	private void method_9(Control.ControlCollection controlCollection_0, Color color_0)
	{
		foreach (Control item in controlCollection_0)
		{
			string text = Class16.smethod_0(1649002075);
			if (!(item.Name == text) && item is NumericUpDown)
			{
				item.BackColor = color_0;
			}
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_1_SelectionChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		byte b = ((dataGridView_1.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_3.Enabled = b != 0;
		byte b2 = ((dataGridView_1.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		groupBox_9.Enabled = b2 != 0;
		byte b3 = ((dataGridView_1.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		groupBox_8.Enabled = b3 != 0;
		if (dataGridView_1.SelectedRows.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		Color numericDefaultBack = TDark.NumericDefaultBack;
		Color searchEditBack = TDark.SearchEditBack;
		if (dataGridView_1.SelectedRows.Count > 1)
		{
			if (numericUpDown_2.BackColor == numericDefaultBack)
			{
				method_9(groupBox_0.Controls, searchEditBack);
				method_9(groupBox_2.Controls, searchEditBack);
				method_9(groupBox_1.Controls, searchEditBack);
				method_9(groupBox_4.Controls, searchEditBack);
				button_5.Enabled = false;
				button_4.Enabled = false;
				groupBox_6.Enabled = false;
			}
			GC.KeepAlive(this);
			return;
		}
		if (numericUpDown_2.BackColor != numericDefaultBack)
		{
			method_9(groupBox_0.Controls, numericDefaultBack);
			method_9(groupBox_2.Controls, numericDefaultBack);
			method_9(groupBox_1.Controls, numericDefaultBack);
			method_9(groupBox_4.Controls, numericDefaultBack);
			button_5.Enabled = true;
			button_4.Enabled = true;
			groupBox_6.Enabled = true;
		}
		SelectedGroup = dataGridView_1.SelectedRows[0].Index;
		dataGridView_0.Rows.Clear();
		int num = 0;
		if (0 < (nint)NPCGen.AIGens[SelectedGroup].Gens.LongLength)
		{
			do
			{
				method_7(num);
				num++;
			}
			while (num < (nint)NPCGen.AIGens[SelectedGroup].Gens.LongLength);
		}
		DontChange = true;
		decimal value = NPCGen.AIGens[SelectedGroup].iType;
		numericUpDown_9.Value = value;
		decimal value2 = (decimal)NPCGen.AIGens[SelectedGroup].vPos[0];
		numericUpDown_2.Value = value2;
		decimal value3 = (decimal)NPCGen.AIGens[SelectedGroup].vPos[1];
		numericUpDown_1.Value = value3;
		decimal value4 = (decimal)NPCGen.AIGens[SelectedGroup].vPos[2];
		numericUpDown_0.Value = value4;
		decimal value5 = (decimal)NPCGen.AIGens[SelectedGroup].vDir[0];
		numericUpDown_8.Value = value5;
		decimal value6 = (decimal)NPCGen.AIGens[SelectedGroup].vDir[1];
		numericUpDown_7.Value = value6;
		decimal value7 = (decimal)NPCGen.AIGens[SelectedGroup].vDir[2];
		numericUpDown_6.Value = value7;
		decimal value8 = (decimal)NPCGen.AIGens[SelectedGroup].vExts[0];
		numericUpDown_5.Value = value8;
		decimal value9 = (decimal)NPCGen.AIGens[SelectedGroup].vExts[1];
		numericUpDown_4.Value = value9;
		decimal value10 = (decimal)NPCGen.AIGens[SelectedGroup].vExts[2];
		numericUpDown_3.Value = value10;
		int iNPCType = NPCGen.AIGens[SelectedGroup].iNPCType;
		if (iNPCType <= comboBox_2.Items.Count)
		{
			comboBox_2.SelectedIndex = iNPCType;
		}
		int iGroupType = NPCGen.AIGens[SelectedGroup].iGroupType;
		if (iGroupType <= comboBox_1.Items.Count)
		{
			comboBox_1.SelectedIndex = iGroupType;
		}
		byte b4 = ((NPCGen.AIGens[SelectedGroup].bInitGen == 1) ? ((byte)1) : ((byte)0));
		checkBox_6.Checked = b4 != 0;
		byte b5 = ((NPCGen.AIGens[SelectedGroup].bAutoRevive == 1) ? ((byte)1) : ((byte)0));
		checkBox_5.Checked = b5 != 0;
		byte b6 = ((NPCGen.AIGens[SelectedGroup].bValidOnce == 1) ? ((byte)1) : ((byte)0));
		checkBox_4.Checked = b6 != 0;
		decimal value11 = NPCGen.AIGens[SelectedGroup].dwGenID;
		numericUpDown_15.Value = value11;
		decimal value12 = NPCGen.AIGens[SelectedGroup].idCtrl;
		numericUpDown_14.Value = value12;
		decimal value13 = NPCGen.AIGens[SelectedGroup].iLifeTime;
		numericUpDown_13.Value = value13;
		decimal value14 = NPCGen.AIGens[SelectedGroup].iMaxNum;
		numericUpDown_12.Value = value14;
		decimal value15 = NPCGen.AIGens[SelectedGroup].dwExportID;
		numericUpDown_11.Value = value15;
		decimal value16 = NPCGen.AIGens[SelectedGroup].idBufRegion;
		numericUpDown_10.Value = value16;
		DontChange = false;
		dataGridView_2.Rows.Clear();
		int num2 = 0;
		if (0 < (nint)NPCGen.AIGens[SelectedGroup].Attach.LongLength)
		{
			do
			{
				string[] array = new string[1];
				int num3 = NPCGen.AIGens[SelectedGroup].Attach[num2];
				array[0] = num3.ToString();
				DataGridViewRowCollection rows = dataGridView_2.Rows;
				object[] values = array;
				rows.Add(values);
				num2++;
			}
			while (num2 < (nint)NPCGen.AIGens[SelectedGroup].Attach.LongLength);
		}
		byte b7 = ((dataGridView_2.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_8.Enabled = b7 != 0;
		byte b8 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		groupBox_5.Enabled = b8 != 0;
		byte b9 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_4.Enabled = b9 != 0;
		GC.KeepAlive(this);
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		if (dataGridView_0.SelectedRows.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		if (dataGridView_0.SelectedRows.Count > 1)
		{
			Color numericDefaultBack = TDark.NumericDefaultBack;
			if (numericUpDown_25.BackColor == numericDefaultBack)
			{
				method_9(groupBox_5.Controls, TDark.SearchEditBack);
			}
			GC.KeepAlive(this);
			return;
		}
		Color numericDefaultBack2 = TDark.NumericDefaultBack;
		if (numericUpDown_25.BackColor != numericDefaultBack2)
		{
			method_9(groupBox_5.Controls, numericDefaultBack2);
		}
		SelectedNPC = dataGridView_0.SelectedRows[0].Index;
		method_12();
		DontChange = true;
		decimal value = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].dwID;
		numericUpDown_23.Value = value;
		decimal value2 = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].dwNum;
		numericUpDown_25.Value = value2;
		decimal value3 = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].dwRefresh;
		numericUpDown_24.Value = value3;
		decimal value4 = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].dwDiedTimes;
		numericUpDown_22.Value = value4;
		decimal value5 = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].dwAggressive;
		numericUpDown_21.Value = value5;
		decimal value6 = (decimal)NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].fOffsetWater;
		numericUpDown_20.Value = value6;
		decimal value7 = (decimal)NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].fOffsetTrn;
		numericUpDown_19.Value = value7;
		decimal value8 = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].dwFaction;
		numericUpDown_18.Value = value8;
		decimal value9 = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].dwFacHelper;
		numericUpDown_17.Value = value9;
		decimal value10 = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].dwFacAccept;
		numericUpDown_16.Value = value10;
		byte b = ((NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].bNeedHelp == 1) ? ((byte)1) : ((byte)0));
		checkBox_3.Checked = b != 0;
		byte b2 = ((NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].bDefFaction == 1) ? ((byte)1) : ((byte)0));
		checkBox_2.Checked = b2 != 0;
		byte b3 = ((NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].bDefFacHelper == 1) ? ((byte)1) : ((byte)0));
		checkBox_1.Checked = b3 != 0;
		byte b4 = ((NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].bDefFacAccept == 1) ? ((byte)1) : ((byte)0));
		checkBox_0.Checked = b4 != 0;
		decimal value11 = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].iPathID;
		numericUpDown_27.Value = value11;
		decimal value12 = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].iLoopType;
		numericUpDown_29.Value = value12;
		decimal value13 = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].iSpeedFlag;
		numericUpDown_28.Value = value13;
		decimal value14 = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].iDeadTime;
		numericUpDown_26.Value = value14;
		DontChange = false;
	}

	private void numericUpDown_2_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_2.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].vPos[0] = (float)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_1_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_1.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].vPos[1] = (float)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_0.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].vPos[2] = (float)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_8_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_8.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].vDir[0] = (float)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_7_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_7.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].vDir[1] = (float)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_6_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_6.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].vDir[2] = (float)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_5_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_5.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].vExts[0] = (float)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_4_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_4.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].vExts[1] = (float)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_3_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_3.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].vExts[2] = (float)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_9_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_9.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].iType = (int)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_15_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_15.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].dwGenID = (int)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_14_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_14.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].idCtrl = (int)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_13_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_13.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].iLifeTime = (int)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_12_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_12.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].iMaxNum = (int)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_11_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_11.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].dwExportID = (int)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_10_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				decimal value = numericUpDown_10.Value;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].idBufRegion = (int)value;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void checkBox_6_CheckedChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int num2 = (checkBox_6.Checked ? 1 : 0);
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].bInitGen = (byte)num2;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void checkBox_5_CheckedChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int num2 = (checkBox_5.Checked ? 1 : 0);
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].bAutoRevive = (byte)num2;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void checkBox_4_CheckedChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int num2 = (checkBox_4.Checked ? 1 : 0);
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].bValidOnce = (byte)num2;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_23_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_23.Value;
							NPCGen.AIGens[index].Gens[index2].dwID = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
		if (!DontChange)
		{
			method_12();
			method_10();
			method_11();
		}
	}

	private void numericUpDown_25_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_25.Value;
							NPCGen.AIGens[index].Gens[index2].dwNum = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_24_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_24.Value;
							NPCGen.AIGens[index].Gens[index2].dwRefresh = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_22_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_22.Value;
							NPCGen.AIGens[index].Gens[index2].dwDiedTimes = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_21_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_21.Value;
							NPCGen.AIGens[index].Gens[index2].dwAggressive = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_20_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_20.Value;
							NPCGen.AIGens[index].Gens[index2].fOffsetWater = (float)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_19_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_19.Value;
							NPCGen.AIGens[index].Gens[index2].fOffsetTrn = (float)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_27_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_27.Value;
							NPCGen.AIGens[index].Gens[index2].iPathID = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_29_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_29.Value;
							NPCGen.AIGens[index].Gens[index2].iLoopType = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_28_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_28.Value;
							NPCGen.AIGens[index].Gens[index2].iSpeedFlag = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_26_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_26.Value;
							NPCGen.AIGens[index].Gens[index2].iDeadTime = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_18_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_18.Value;
							NPCGen.AIGens[index].Gens[index2].dwFaction = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_17_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_17.Value;
							NPCGen.AIGens[index].Gens[index2].dwFacHelper = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void numericUpDown_16_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							decimal value = numericUpDown_16.Value;
							NPCGen.AIGens[index].Gens[index2].dwFacAccept = (int)value;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void checkBox_2_CheckedChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							int num3 = (checkBox_2.Checked ? 1 : 0);
							NPCGen.AIGens[index].Gens[index2].bDefFaction = (byte)num3;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							int num3 = (checkBox_1.Checked ? 1 : 0);
							NPCGen.AIGens[index].Gens[index2].bDefFacHelper = (byte)num3;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							int num3 = (checkBox_0.Checked ? 1 : 0);
							NPCGen.AIGens[index].Gens[index2].bDefFacAccept = (byte)num3;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void checkBox_3_CheckedChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int index = dataGridView_1.SelectedRows[num].Index;
				int num2 = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int index2 = dataGridView_0.SelectedRows[num2].Index;
						if (index2 < (nint)NPCGen.AIGens[index].Gens.LongLength)
						{
							int num3 = (checkBox_3.Checked ? 1 : 0);
							NPCGen.AIGens[index].Gens[index2].bNeedHelp = (byte)num3;
						}
						num2++;
					}
					while (num2 < dataGridView_0.SelectedRows.Count);
				}
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void method_10()
	{
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				method_8(dataGridView_0.SelectedRows[num].Index, bool_1: false);
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		GC.KeepAlive(this);
	}

	private void method_11()
	{
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				method_6(dataGridView_1.SelectedRows[num].Index, bool_1: false, bool_2: false);
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		GC.KeepAlive(this);
	}

	private void method_12()
	{
		int[] lists = new int[2] { MobsList, NPCsList };
		ITEMPOS iTEMPOS = eLC.FindItemPos(lists, NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].dwID);
		if (iTEMPOS != null)
		{
			groupBox_5.Text = eLC.GetParsedItemName(iTEMPOS);
		}
		else if (NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].dwID != 0)
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
			groupBox_5.Text = text;
		}
		else
		{
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648971625));
			groupBox_5.Text = text2;
		}
		GC.KeepAlive(this);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		method_13();
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		method_14();
	}

	private void method_13()
	{
		if (dataGridView_1.SelectedRows.Count > 1)
		{
			TextStorage.TEXTS.ShowMessage(152, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			GC.KeepAlive(this);
			return;
		}
		int count = dataGridView_0.SelectedRows.Count;
		if (count > 0)
		{
			int[] array = new int[count];
			int num = 0;
			if (0 < count)
			{
				do
				{
					array[num] = dataGridView_0.SelectedRows[num].Index;
					num++;
				}
				while (num < count);
			}
			Array.Sort(array);
			int num2 = 0;
			if (0 < count)
			{
				do
				{
					NPCGen.AIGens[SelectedGroup].AddGen(array[num2]);
					method_7((int)((nint)NPCGen.AIGens[SelectedGroup].Gens.LongLength - 1));
					num2++;
				}
				while (num2 < count);
			}
			dataGridView_0.ClearSelection();
			int rowIndex = dataGridView_0.RowCount - 1;
			dataGridView_0.CurrentCell = dataGridView_0[1, rowIndex];
			int num3 = dataGridView_0.RowCount - count;
			if (num3 < dataGridView_0.RowCount)
			{
				do
				{
					dataGridView_0.Rows[num3].Selected = true;
					num3++;
				}
				while (num3 < dataGridView_0.RowCount);
			}
		}
		else
		{
			NPCGen.AIGens[SelectedGroup].AddGen();
			method_7(0);
			dataGridView_0.ClearSelection();
			dataGridView_0.CurrentCell = dataGridView_0[1, 0];
			dataGridView_0.Rows[0].Selected = true;
		}
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		groupBox_5.Enabled = b != 0;
		byte b2 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_4.Enabled = b2 != 0;
		method_11();
		method_18();
	}

	private void method_14()
	{
		if (dataGridView_1.SelectedRows.Count > 1)
		{
			TextStorage.TEXTS.ShowMessage(153, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			GC.KeepAlive(this);
			return;
		}
		int count = dataGridView_0.SelectedRows.Count;
		if (count > 0)
		{
			int[] array = new int[count];
			int num = 0;
			if (0 < count)
			{
				do
				{
					array[num] = dataGridView_0.SelectedRows[num].Index;
					num++;
				}
				while (num < count);
			}
			Array.Sort(array);
			int num2 = count - 1;
			if (num2 >= 0)
			{
				do
				{
					int index = array[num2];
					dataGridView_0.Rows.RemoveAt(index);
					NPCGen.AIGens[SelectedGroup].DeleteGen(array[num2]);
					num2--;
				}
				while (num2 >= 0);
			}
		}
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		groupBox_5.Enabled = b != 0;
		byte b2 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_4.Enabled = b2 != 0;
		method_11();
		dataGridView_0_SelectionChanged(null, null);
		method_18();
	}

	private void comboBox_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int selectedIndex = comboBox_2.SelectedIndex;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].iNPCType = selectedIndex;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_1.SelectedRows.Count)
		{
			do
			{
				int selectedIndex = comboBox_1.SelectedIndex;
				NPCGen.AIGens[dataGridView_1.SelectedRows[num].Index].iGroupType = selectedIndex;
				num++;
			}
			while (num < dataGridView_1.SelectedRows.Count);
		}
		method_18();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_15();
	}

	private void method_15()
	{
		int count = dataGridView_1.SelectedRows.Count;
		if (count > 0)
		{
			int[] array = new int[count];
			int num = 0;
			if (0 < count)
			{
				do
				{
					array[num] = dataGridView_1.SelectedRows[num].Index;
					num++;
				}
				while (num < count);
			}
			Array.Sort(array);
			int num2 = 0;
			if (0 < count)
			{
				do
				{
					NPCGen.AddAIGen(array[num2]);
					method_3((int)((nint)NPCGen.AIGens.LongLength - 1));
					num2++;
				}
				while (num2 < count);
			}
			DontChange = true;
			dataGridView_1.ClearSelection();
			DontChange = false;
			int rowIndex = dataGridView_1.RowCount - 1;
			dataGridView_1.CurrentCell = dataGridView_1[1, rowIndex];
			int num3 = dataGridView_1.RowCount - count;
			if (num3 < dataGridView_1.RowCount)
			{
				do
				{
					dataGridView_1.Rows[num3].Selected = true;
					num3++;
				}
				while (num3 < dataGridView_1.RowCount);
			}
		}
		else
		{
			NPCGen.AddAIGen();
			method_3(0);
			DontChange = true;
			dataGridView_1.ClearSelection();
			DontChange = false;
			dataGridView_1.CurrentCell = dataGridView_1[1, 0];
			dataGridView_1.Rows[0].Selected = true;
		}
		byte b = ((dataGridView_1.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_3.Enabled = b != 0;
		byte b2 = ((dataGridView_1.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		groupBox_9.Enabled = b2 != 0;
		byte b3 = ((dataGridView_1.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		groupBox_8.Enabled = b3 != 0;
		method_18();
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_16();
	}

	private void method_16()
	{
		int count = dataGridView_1.SelectedRows.Count;
		if (count <= 0)
		{
			return;
		}
		int[] array = new int[count];
		int num = 0;
		if (0 < count)
		{
			do
			{
				array[num] = dataGridView_1.SelectedRows[num].Index;
				num++;
			}
			while (num < count);
		}
		Array.Sort(array);
		int num2 = count - 1;
		if (num2 >= 0)
		{
			do
			{
				int index = array[num2];
				dataGridView_1.Rows.RemoveAt(index);
				NPCGen.DeleteAIGen(array[num2]);
				num2--;
			}
			while (num2 >= 0);
		}
		int num3 = array[0];
		if (num3 < (nint)NPCGen.AIGens.LongLength)
		{
			do
			{
				method_6(num3, bool_1: false, bool_2: false);
				num3++;
			}
			while (num3 < (nint)NPCGen.AIGens.LongLength);
		}
		dataGridView_1_SelectionChanged(null, null);
		method_18();
	}

	private void numericUpDown_23_DoubleClick(object sender, EventArgs e)
	{
		ItemsWindow1.newlistsindices = ACE.RSGlobal.RSGlobal.iarr(MobsList, NPCsList);
		ITEMPOS itemPos = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].ItemPos;
		if (itemPos != null)
		{
			ItemsWindow1.newitemlist = itemPos.int_0;
			ItemsWindow1.newitemindex = NPCGen.AIGens[SelectedGroup].Gens[SelectedNPC].ItemPos.int_1;
		}
		ItemsWindow1.bMultiSelect = false;
		CStorage.ResetBuffer();
		ItemsWindow1.ShowDialog(this);
		if (CommonStorage.sData != null)
		{
			numericUpDown_23.Text = CommonStorage.sData;
		}
		GC.KeepAlive(this);
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		int[] attach = ACE.RSGlobal.RSGlobal.RemoveArrayElement(NPCGen.AIGens[SelectedGroup].Attach, dataGridView_2.SelectedRows[0].Index);
		NPCGen.AIGens[SelectedGroup].Attach = attach;
		NpcsArea npcsArea = NPCGen.AIGens[SelectedGroup];
		npcsArea.iAttachNum = npcsArea.Attach.Length;
		DataGridView dataGridView = dataGridView_2;
		dataGridView_2.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
		if (dataGridView_2.SelectedRows.Count == 0 && dataGridView_2.RowCount > 0)
		{
			int index = dataGridView_2.RowCount - 1;
			dataGridView_2.Rows[index].Selected = true;
		}
		byte b = ((dataGridView_2.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_8.Enabled = b != 0;
		method_18();
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		NpcsArea npcsArea = NPCGen.AIGens[SelectedGroup];
		Array.Resize(ref npcsArea.Attach, (int)((nint)npcsArea.Attach.LongLength + 1));
		NpcsArea npcsArea2 = NPCGen.AIGens[SelectedGroup];
		npcsArea2.iAttachNum = npcsArea2.Attach.Length;
		string[] array = new string[1] { Class16.smethod_0(1648924112) };
		DataGridViewRowCollection rows = dataGridView_2.Rows;
		object[] values = array;
		rows.Add(values);
		byte b = ((dataGridView_2.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_8.Enabled = b != 0;
		int index = (int)((nint)NPCGen.AIGens[SelectedGroup].Attach.LongLength - 1);
		dataGridView_2.Rows[index].Selected = true;
		method_18();
	}

	private void dataGridView_2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		int rowIndex = e.RowIndex;
		if (rowIndex < 0)
		{
			GC.KeepAlive(this);
			return;
		}
		string text = (string)dataGridView_2[0, rowIndex].Value;
		if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
		{
			NPCGen.AIGens[SelectedGroup].Attach[rowIndex] = Convert.ToInt32(text);
		}
		else
		{
			int num = NPCGen.AIGens[SelectedGroup].Attach[rowIndex];
			dataGridView_2[0, rowIndex].Value = num.ToString();
		}
		method_18();
	}

	private void method_17()
	{
		Cursor = Cursors.WaitCursor;
		NPCGen.Save();
		IsFileChanged = false;
		button_6.Enabled = false;
		Cursor = Cursors.Default;
		GC.KeepAlive(this);
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		method_17();
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_17();
	}

	private void method_18()
	{
		button_6.Enabled = true;
		IsFileChanged = true;
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		dataGridView_1.Focus();
		GC.KeepAlive(this);
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		method_19();
	}

	private void method_19()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649115019);
		openFileDialog.FileName = Class16.smethod_0(1648908842);
		if (openFileDialog.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_1.Text = openFileDialog.FileName;
			NPCGen.Load(openFileDialog.FileName);
			tabControl_0.Enabled = NPCGen.FileLoaded;
			method_0();
			CommonStorage.Profile.SaveSetting(Class16.smethod_0(1648906758), Class16.smethod_0(1649115053), openFileDialog.FileName);
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_Enter(object sender, EventArgs e)
	{
		base.AcceptButton = button_1;
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
		base.AcceptButton = button_10;
	}

	private void textBox_0_Click(object sender, EventArgs e)
	{
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071086));
		if (textBox_0.Text == text)
		{
			textBox_0.SelectAll();
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_DoubleClick(object sender, EventArgs e)
	{
		textBox_0.SelectAll();
		GC.KeepAlive(this);
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071086));
		if (textBox_0.Text == text)
		{
			GC.KeepAlive(this);
			return;
		}
		base.AcceptButton = button_1;
		if (textBox_0.TextLength < 3)
		{
			Color searchIdleBack = TDark.SearchIdleBack;
			textBox_0.BackColor = searchIdleBack;
		}
		if (textBox_0.TextLength > 3 || (ACE.RSGlobal.RSGlobal.IsUIntFast(textBox_0.Text) && textBox_0.TextLength > 2))
		{
			method_20(bool_1: true);
		}
	}

	private void method_20([MarshalAs(UnmanagedType.U1)] bool bool_1)
	{
		if (ACE.RSGlobal.RSGlobal.antirecurse_FindNPC_NPCGenEditor || !bool_0 || NPCGen?.AIGens == null || dataGridView_1 == null || dataGridView_1.RowCount == 0)
		{
			return;
		}
		ACE.RSGlobal.RSGlobal.antirecurse_FindNPC_NPCGenEditor = true;
		string text = textBox_0.Text.ToLowerInvariant();
		bool flag = false;
		int num = 0;
		if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
		{
			flag = true;
			num = Convert.ToInt32(text);
		}
		int num2 = 0;
		if (!bool_1)
		{
			int[] array = new int[dataGridView_1.SelectedRows.Count];
			int num3 = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					array[num3] = dataGridView_1.SelectedRows[num3].Index;
					num3++;
				}
				while (num3 < (nint)array.LongLength);
			}
			Array.Sort(array);
			num2 = array[(nint)array.LongLength - 1] + 1;
		}
		int num4 = -1;
		int num5 = num2;
		if (NPCGen.AIGens != null && num2 < (nint)NPCGen.AIGens.LongLength)
		{
			do
			{
				int num6 = 0;
				if (NPCGen.AIGens[num5]?.Gens != null && 0 < (nint)NPCGen.AIGens[num5].Gens.LongLength)
				{
					do
					{
						if (flag)
						{
							if (NPCGen.AIGens[num5].Gens[num6].dwID == num)
							{
								num4 = num5;
								break;
							}
						}
						else
						{
							ITEMPOS itemPos = NPCGen.AIGens[num5].Gens[num6].ItemPos;
							if (itemPos != null && eLC != null && ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(eLC.GetParsedItemName(itemPos), text))
							{
								num4 = num5;
								break;
							}
						}
						num6++;
					}
					while (num6 < (nint)NPCGen.AIGens[num5].Gens.LongLength);
				}
				if (num4 > -1)
				{
					break;
				}
				num5++;
			}
			while (num5 < (nint)NPCGen.AIGens.LongLength);
		}
		ACE.RSGlobal.RSGlobal.antirecurse_FindNPC_NPCGenEditor = false;
		if (num4 > -1)
		{
			DontChange = true;
			dataGridView_1.ClearSelection();
			DontChange = false;
			dataGridView_1.CurrentCell = dataGridView_1[1, num4];
			dataGridView_1.Rows[num4].Selected = true;
			Color searchMatchBack = TDark.SearchMatchBack;
			textBox_0.BackColor = searchMatchBack;
		}
		else if (!bool_1)
		{
			method_20(bool_1: true);
		}
		else
		{
			Color searchErrorBack = TDark.SearchErrorBack;
			textBox_0.BackColor = searchErrorBack;
		}
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_20(bool_1: false);
	}

	private void NPCGenEditor_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (IsFileChanged)
		{
			switch (DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649115064), Class16.smethod_0(1649115101)), TextStorage.Msg(Class16.smethod_0(1649002823), Class16.smethod_0(1648997745)), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
			case DialogResult.Cancel:
				e.Cancel = true;
				return;
			case DialogResult.Yes:
				method_17();
				if (IsFileChanged)
				{
					e.Cancel = true;
					return;
				}
				break;
			}
		}
		if (!ElementsWindow.Visible)
		{
			ACE.RSGlobal.RSGlobal.End(null, null);
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_3_SelectionChanged(object sender, EventArgs e)
	{
		if (dataGridView_3.SelectedRows.Count > 0)
		{
			NPCCtrl selectedObject = NPCGen.Triggers[dataGridView_3.SelectedRows[0].Index];
			propertyGrid_0.SelectedObject = selectedObject;
			propertyGrid_0.ExpandAllGridItems();
			button_12.Enabled = true;
		}
		else
		{
			propertyGrid_0.SelectedObject = null;
			button_12.Enabled = false;
		}
		GC.KeepAlive(this);
	}

	private void method_21()
	{
		dataGridView_3.Rows.Clear();
		NPCCtrl[] triggers = NPCGen.Triggers;
		if (triggers == null)
		{
			return;
		}
		DataGridViewRow[] array = new DataGridViewRow[(nint)triggers.LongLength];
		int num = 0;
		NPCCtrl[] array2 = triggers;
		if (0 < (nint)array2.LongLength)
		{
			do
			{
				NPCCtrl nPCCtrl = array2[num];
				DataGridViewRow dataGridViewRow = new DataGridViewRow();
				dataGridViewRow.Resizable = DataGridViewTriState.False;
				dataGridViewRow.CreateCells(dataGridView_3);
				dataGridViewRow.SetValues(num, nPCCtrl.id, nPCCtrl.Name);
				array[num] = dataGridViewRow;
				num++;
			}
			while (num < (nint)array2.LongLength);
		}
		dataGridView_3.Rows.AddRange(array);
		GC.KeepAlive(this);
	}

	private void propertyGrid_0_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		string text = Class16.smethod_0(1648932143);
		if (!(e.ChangedItem.PropertyDescriptor.Name == text))
		{
			string text2 = Class16.smethod_0(1648936731);
			if (!(e.ChangedItem.PropertyDescriptor.Name == text2))
			{
				goto IL_00c3;
			}
		}
		if (dataGridView_3.SelectedRows.Count > 0)
		{
			int index = dataGridView_3.SelectedRows[0].Index;
			NPCCtrl nPCCtrl = NPCGen.Triggers[index];
			dataGridView_3[1, index].Value = nPCCtrl.id;
			NPCCtrl nPCCtrl2 = NPCGen.Triggers[index];
			dataGridView_3[2, index].Value = nPCCtrl2.Name;
		}
		goto IL_00c3;
		IL_00c3:
		method_18();
	}

	private void button_11_Click(object sender, EventArgs e)
	{
		int num = NPCGen.AddTrigger(dataGridView_3.SelectedRows[0].Index);
		object[] values = new object[3]
		{
			num,
			NPCGen.Triggers[num].id,
			NPCGen.Triggers[num].Name
		};
		dataGridView_3.Rows.Add(values);
		int rowIndex = dataGridView_3.Rows.Count - 1;
		dataGridView_3.CurrentCell = dataGridView_3[1, rowIndex];
		int index = dataGridView_3.Rows.Count - 1;
		dataGridView_3.Rows[index].Selected = true;
		method_18();
	}

	private void button_12_Click(object sender, EventArgs e)
	{
		int index = dataGridView_3.SelectedRows[0].Index;
		NPCGen.DeleteTrigger(index);
		dataGridView_3.Rows.RemoveAt(index);
		int num = index;
		if (index < (nint)NPCGen.Triggers.LongLength)
		{
			do
			{
				dataGridView_3[0, num].Value = num;
				num++;
			}
			while (num < (nint)NPCGen.Triggers.LongLength);
		}
		method_18();
	}

	private void NPCGenEditor_Activated(object sender, EventArgs e)
	{
		method_22();
	}

	private void method_22()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_NPCGenEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this, null);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_NPCGenEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}
}
