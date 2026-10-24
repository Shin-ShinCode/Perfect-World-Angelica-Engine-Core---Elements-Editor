using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.Cpk;
using ACE.Elements;
using ACE.Elements.eListCollection;
using ACE.Path;
using ACE.Pck;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.Settings;
using Sentry;

namespace ACE.GShop;

public class GShopEditor_FW : Form
{
	public PCK_LIST PCKs;

	public bool bGShopOpened;

	public ShopDirLua Categories;

	public bool LoadingComplete;

	public Form ElementsWindow;

	public ItemsToolTip ItemsToolTip1;

	public ITEM_EXT_DESC Descriptions;

	public bool IconsLoaded;

	public ICONS ShopIcons;

	public IconsWindow ShopIconsWindow;

	public bool IsFileChanged;

	public bool DontChange;

	public eListCollection eLC;

	public ItemsWindow ItemsWindow1;

	public CommonStorage CStorage;

	public int SelectedItem;

	public int RowIndexUnderCursor;

	public bool WindowLoaded;

	private bool bool_0;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_0;

	private DataGridView dataGridView_0;

	private Button button_2;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private TextBox textBox_1;

	private Button button_3;

	private Button button_4;

	private Label label_0;

	private Panel panel_0;

	private GroupBox groupBox_0;

	private PictureBox pictureBox_0;

	private TextBox textBox_2;

	private NumericUpDown numericUpDown_0;

	private PictureBox pictureBox_1;

	private NumericUpDown numericUpDown_1;

	private Button button_5;

	private TextBox textBox_3;

	private Button button_6;

	private BackgroundWorker backgroundWorker_0;

	private TextBox textBox_4;

	private Label label_1;

	private NumericUpDown numericUpDown_2;

	private CheckBox checkBox_0;

	private GroupBox groupBox_1;

	private NumericUpDown numericUpDown_3;

	private Label label_2;

	private Label label_3;

	private TextBox textBox_5;

	private NumericUpDown numericUpDown_4;

	private Label label_4;

	private Label label_5;

	private GroupBox groupBox_2;

	private GroupBox groupBox_3;

	private GroupBox groupBox_4;

	private Label label_6;

	private PictureBox pictureBox_2;

	private NumericUpDown numericUpDown_5;

	private NumericUpDown numericUpDown_6;

	private Label label_7;

	private CheckBox checkBox_1;

	private Label label_8;

	private NumericUpDown numericUpDown_7;

	private Label label_9;

	private TextBox textBox_6;

	private Label label_10;

	private ToolTip toolTip_0;

	private GroupBox groupBox_5;

	private NumericUpDown numericUpDown_8;

	private Label label_11;

	private Label label_12;

	private DateTimePicker dateTimePicker_0;

	private DateTimePicker dateTimePicker_1;

	private Label label_13;

	private NumericUpDown numericUpDown_9;

	private NumericUpDown numericUpDown_10;

	private Label label_14;

	private NumericUpDown numericUpDown_11;

	private Label label_15;

	private NumericUpDown numericUpDown_12;

	private Label label_16;

	private NumericUpDown numericUpDown_13;

	private Label label_17;

	private Label label_18;

	private Label label_19;

	private DateTimePicker dateTimePicker_2;

	private DateTimePicker dateTimePicker_3;

	private Label label_20;

	private ComboBox comboBox_0;

	private ComboBox comboBox_1;

	private Timer timer_0;

	private ColorDialog colorDialog_0;

	private StatusStrip statusStrip_0;

	private ToolStripProgressBar toolStripProgressBar_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private ToolStripStatusLabel toolStripStatusLabel_1;

	private ToolStripStatusLabel toolStripStatusLabel_2;

	private ToolStripStatusLabel toolStripStatusLabel_3;

	private DataGridView dataGridView_1;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripMenuItem toolStripMenuItem_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private ContextMenuStrip contextMenuStrip_1;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripMenuItem toolStripMenuItem_5;

	private ToolStripMenuItem toolStripMenuItem_6;

	private GroupBox groupBox_6;

	private ToolStripSeparator toolStripSeparator_2;

	private ToolStripMenuItem toolStripMenuItem_7;

	private ToolStripSeparator toolStripSeparator_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private ToolStripSeparator toolStripSeparator_4;

	private ToolStripMenuItem toolStripMenuItem_8;

	private ToolStripMenuItem toolStripMenuItem_9;

	private ToolStripMenuItem toolStripMenuItem_10;

	private Button button_7;

	private GroupBox groupBox_7;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_11;

	private ToolStripMenuItem toolStripMenuItem_12;

	private ToolStripMenuItem toolStripMenuItem_13;

	private IContainer icontainer_0;

	private Color color_0;

	public GShopEditor_FW(eListCollection eLC, ItemsWindow ItemsWindow1, CommonStorage CStorage, Form ElementsWindow, ItemsToolTip ItemsToolTip1, PCK_LIST PCKs)
	{
		try
		{
			method_6();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			this.CStorage = CStorage;
			this.PCKs = PCKs;
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			this.eLC = eLC;
			this.ItemsWindow1 = ItemsWindow1;
			this.ElementsWindow = ElementsWindow;
			this.ItemsToolTip1 = ItemsToolTip1;
			IconsLoaded = false;
			DontChange = false;
			IsFileChanged = false;
			RowIndexUnderCursor = -1;
			LoadingComplete = false;
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071086));
			textBox_0.Text = text;
			dataGridView_0.Cursor = ACE.RSGlobal.RSGlobal.LoadFWCursor();
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private bool method_0(out DialogResult dialogResult_0)
	{
		dialogResult_0 = DialogResult.Cancel;
		ItemsWindow itemsWindow = ItemsWindow1;
		if (itemsWindow != null && !itemsWindow.IsDisposed && !itemsWindow.Disposing)
		{
			try
			{
				if (itemsWindow.Modal)
				{
					if (itemsWindow.Visible)
					{
						itemsWindow.Activate();
					}
					return false;
				}
				dialogResult_0 = itemsWindow.ShowDialog(this);
				return true;
			}
			catch (ObjectDisposedException ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649070171));
				return false;
			}
			catch (InvalidOperationException ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1649070223));
				return false;
			}
		}
		SentryHelper.CaptureMessage(Class16.smethod_0(1649071099), (SentryLevel)2, Class16.smethod_0(1649070138));
		return false;
	}

	private void toolStripMenuItem_12_Click(object sender, EventArgs e)
	{
		method_16();
	}

	private void GShopEditor_FW_Shown(object sender, EventArgs e)
	{
		bool fileLoaded = DataFiles.GShop.FileLoaded;
		panel_0.Enabled = fileLoaded;
		if (!DataFiles.GShop.FileLoaded)
		{
			string text = CommonStorage.Params.GShopPath;
			if (text == string.Empty)
			{
				text = CommonStorage.Profile.GetSetting(Class16.smethod_0(1649070284), Class16.smethod_0(1649070297), string.Empty);
			}
			DataFiles.GShop.Load(text, PW_GSHOP_VERSION.AUTO, 0);
		}
		eListCollection eListCollection2 = eLC;
		if (eListCollection2 != null && eListCollection2.Game == GAMES.FW)
		{
			WindowLoaded = true;
			if (DataFiles.GShop.FileLoaded && dataGridView_0.RowCount == 0)
			{
				method_1();
				method_26();
				method_32();
				string fileName = DataFiles.GShop.FileName;
				textBox_1.Text = fileName;
				method_19();
				bGShopOpened = true;
			}
			LoadingComplete = true;
		}
		else
		{
			TextStorage.TEXTS.ShowErrorMessage(200);
			Close();
		}
	}

	private void method_1()
	{
		IsFileChanged = false;
		button_3.Enabled = false;
		if (DataFiles.GShop.Items == null)
		{
			GC.KeepAlive(this);
			return;
		}
		toolStripStatusLabel_0.Visible = false;
		toolStripProgressBar_0.Visible = true;
		dataGridView_0.Rows.Clear();
		DataGridViewRow[] array = new DataGridViewRow[(nint)DataFiles.GShop.Items.LongLength];
		int num = 0;
		if (0 < (nint)DataFiles.GShop.Items.LongLength)
		{
			do
			{
				array[num] = method_4(num);
				int value = (int)((double)(float)num / (double)(float)(nint)DataFiles.GShop.Items.LongLength * 90.0);
				if (!toolStripProgressBar_0.IsDisposed)
				{
					toolStripProgressBar_0.Value = value;
					Application.DoEvents();
				}
				num++;
			}
			while (num < (nint)DataFiles.GShop.Items.LongLength);
		}
		dataGridView_0.Rows.AddRange(array);
		if (!toolStripProgressBar_0.IsDisposed)
		{
			toolStripProgressBar_0.Value = 100;
		}
		dataGridView_0.Focus();
		method_30();
		toolStripProgressBar_0.Visible = false;
		toolStripStatusLabel_0.Visible = true;
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				method_3(dataGridView_0.SelectedRows[num].Index);
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		GC.KeepAlive(this);
	}

	private void method_3(int int_0)
	{
		int int_1 = (int)dataGridView_0.Rows[int_0].Tag;
		method_7(dataGridView_0.Rows[int_0], int_1);
		GC.KeepAlive(this);
	}

	private DataGridViewRow method_4(int int_0)
	{
		DataGridViewRow dataGridViewRow = new DataGridViewRow();
		dataGridViewRow.Resizable = DataGridViewTriState.False;
		method_7(dataGridViewRow, int_0);
		return dataGridViewRow;
	}

	private void method_5()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_6()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(GShopEditor_FW));
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
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_11 = new ToolStripMenuItem();
		toolStripMenuItem_12 = new ToolStripMenuItem();
		toolStripMenuItem_13 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		button_2 = new Button();
		button_1 = new Button();
		textBox_0 = new TextBox();
		button_0 = new Button();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		contextMenuStrip_0 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripSeparator_1 = new ToolStripSeparator();
		toolStripMenuItem_10 = new ToolStripMenuItem();
		toolStripMenuItem_7 = new ToolStripMenuItem();
		toolStripSeparator_3 = new ToolStripSeparator();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripSeparator_4 = new ToolStripSeparator();
		toolStripMenuItem_8 = new ToolStripMenuItem();
		toolStripMenuItem_9 = new ToolStripMenuItem();
		textBox_1 = new TextBox();
		button_3 = new Button();
		button_4 = new Button();
		label_0 = new Label();
		groupBox_7 = new GroupBox();
		button_6 = new Button();
		panel_0 = new Panel();
		button_7 = new Button();
		groupBox_0 = new GroupBox();
		groupBox_6 = new GroupBox();
		dataGridView_1 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		contextMenuStrip_1 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_5 = new ToolStripMenuItem();
		toolStripMenuItem_6 = new ToolStripMenuItem();
		toolStripSeparator_2 = new ToolStripSeparator();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		groupBox_5 = new GroupBox();
		numericUpDown_10 = new NumericUpDown();
		label_14 = new Label();
		numericUpDown_8 = new NumericUpDown();
		label_11 = new Label();
		label_12 = new Label();
		dateTimePicker_0 = new DateTimePicker();
		dateTimePicker_1 = new DateTimePicker();
		label_13 = new Label();
		groupBox_3 = new GroupBox();
		comboBox_1 = new ComboBox();
		comboBox_0 = new ComboBox();
		numericUpDown_11 = new NumericUpDown();
		label_15 = new Label();
		numericUpDown_12 = new NumericUpDown();
		label_16 = new Label();
		numericUpDown_13 = new NumericUpDown();
		label_17 = new Label();
		label_18 = new Label();
		label_19 = new Label();
		dateTimePicker_2 = new DateTimePicker();
		dateTimePicker_3 = new DateTimePicker();
		label_20 = new Label();
		numericUpDown_7 = new NumericUpDown();
		label_9 = new Label();
		textBox_6 = new TextBox();
		label_10 = new Label();
		label_8 = new Label();
		groupBox_2 = new GroupBox();
		button_5 = new Button();
		textBox_3 = new TextBox();
		checkBox_0 = new CheckBox();
		groupBox_1 = new GroupBox();
		numericUpDown_9 = new NumericUpDown();
		label_5 = new Label();
		numericUpDown_3 = new NumericUpDown();
		label_2 = new Label();
		label_3 = new Label();
		textBox_5 = new TextBox();
		pictureBox_0 = new PictureBox();
		numericUpDown_4 = new NumericUpDown();
		numericUpDown_1 = new NumericUpDown();
		label_4 = new Label();
		numericUpDown_2 = new NumericUpDown();
		textBox_4 = new TextBox();
		label_1 = new Label();
		numericUpDown_0 = new NumericUpDown();
		pictureBox_1 = new PictureBox();
		groupBox_4 = new GroupBox();
		label_6 = new Label();
		pictureBox_2 = new PictureBox();
		numericUpDown_5 = new NumericUpDown();
		numericUpDown_6 = new NumericUpDown();
		label_7 = new Label();
		checkBox_1 = new CheckBox();
		textBox_2 = new TextBox();
		backgroundWorker_0 = new BackgroundWorker();
		toolTip_0 = new ToolTip(icontainer_0);
		timer_0 = new Timer(icontainer_0);
		colorDialog_0 = new ColorDialog();
		statusStrip_0 = new StatusStrip();
		toolStripProgressBar_0 = new ToolStripProgressBar();
		toolStripStatusLabel_0 = new ToolStripStatusLabel();
		toolStripStatusLabel_1 = new ToolStripStatusLabel();
		toolStripStatusLabel_2 = new ToolStripStatusLabel();
		toolStripStatusLabel_3 = new ToolStripStatusLabel();
		menuStrip_0.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		contextMenuStrip_0.SuspendLayout();
		groupBox_7.SuspendLayout();
		panel_0.SuspendLayout();
		groupBox_0.SuspendLayout();
		groupBox_6.SuspendLayout();
		((ISupportInitialize)dataGridView_1).BeginInit();
		contextMenuStrip_1.SuspendLayout();
		groupBox_5.SuspendLayout();
		((ISupportInitialize)numericUpDown_10).BeginInit();
		((ISupportInitialize)numericUpDown_8).BeginInit();
		groupBox_3.SuspendLayout();
		((ISupportInitialize)numericUpDown_11).BeginInit();
		((ISupportInitialize)numericUpDown_12).BeginInit();
		((ISupportInitialize)numericUpDown_13).BeginInit();
		((ISupportInitialize)numericUpDown_7).BeginInit();
		groupBox_2.SuspendLayout();
		groupBox_1.SuspendLayout();
		((ISupportInitialize)numericUpDown_9).BeginInit();
		((ISupportInitialize)numericUpDown_3).BeginInit();
		((ISupportInitialize)pictureBox_0).BeginInit();
		((ISupportInitialize)numericUpDown_4).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)pictureBox_1).BeginInit();
		groupBox_4.SuspendLayout();
		((ISupportInitialize)pictureBox_2).BeginInit();
		((ISupportInitialize)numericUpDown_5).BeginInit();
		((ISupportInitialize)numericUpDown_6).BeginInit();
		statusStrip_0.SuspendLayout();
		SuspendLayout();
		menuStrip_0.BackColor = SystemColors.InactiveBorder;
		menuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		menuStrip_0.ImageScalingSize = new Size(20, 20);
		menuStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripMenuItem_11 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1649009132);
		menuStrip_0.Padding = new Padding(0, 2, 2, 2);
		menuStrip_0.RenderMode = ToolStripRenderMode.Professional;
		menuStrip_0.Size = new Size(1102, 24);
		menuStrip_0.TabIndex = 0;
		menuStrip_0.Text = Class16.smethod_0(1649012229);
		menuStrip_0.Visible = false;
		toolStripMenuItem_11.DropDownItems.AddRange(new ToolStripItem[4] { toolStripMenuItem_12, toolStripMenuItem_13, toolStripSeparator_0, toolStripMenuItem_0 });
		toolStripMenuItem_11.ImageScaling = ToolStripItemImageScaling.None;
		toolStripMenuItem_11.Name = Class16.smethod_0(1649012245);
		toolStripMenuItem_11.Padding = new Padding(0);
		toolStripMenuItem_11.Size = new Size(29, 20);
		toolStripMenuItem_11.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_11.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_12.BackgroundImageLayout = ImageLayout.None;
		toolStripMenuItem_12.Image = Resources.GShopEditor_FW_mnuOpen;
		toolStripMenuItem_12.ImageAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_12.Name = Class16.smethod_0(1648920856);
		toolStripMenuItem_12.ShortcutKeys = Keys.O | Keys.Control;
		toolStripMenuItem_12.Size = new Size(150, 26);
		toolStripMenuItem_12.Text = Class16.smethod_0(1648931498);
		toolStripMenuItem_12.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_12.Click += toolStripMenuItem_12_Click;
		toolStripMenuItem_13.Image = Resources.GShopEditor_FW_mnuSave;
		toolStripMenuItem_13.Name = Class16.smethod_0(1648920878);
		toolStripMenuItem_13.ShortcutKeys = Keys.S | Keys.Control;
		toolStripMenuItem_13.Size = new Size(150, 26);
		toolStripMenuItem_13.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_13.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_13.Click += toolStripMenuItem_13_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1649012270);
		toolStripSeparator_0.Size = new Size(147, 6);
		toolStripMenuItem_0.Image = Resources.GShopEditor_FW_mnuExit;
		toolStripMenuItem_0.Name = Class16.smethod_0(1648920908);
		toolStripMenuItem_0.Size = new Size(150, 26);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648920914);
		button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_2.Enabled = false;
		button_2.ForeColor = Color.FromArgb(192, 0, 0);
		button_2.Image = Resources.GShopEditor_FW_cmdDeleteItem;
		button_2.Location = new Point(237, 597);
		button_2.Name = Class16.smethod_0(1649070315);
		button_2.Size = new Size(195, 25);
		button_2.TabIndex = 71;
		button_2.Text = Class16.smethod_0(1648925718);
		button_2.TextAlign = ContentAlignment.MiddleRight;
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_1.Image = Resources.GShopEditor_FW_cmdSearch;
		button_1.Location = new Point(402, 2);
		button_1.Name = Class16.smethod_0(1649070343);
		button_1.Size = new Size(30, 25);
		button_1.TabIndex = 35;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.BackColor = Color.FromArgb(220, 255, 255);
		textBox_0.Location = new Point(3, 3);
		textBox_0.Name = Class16.smethod_0(1648995997);
		textBox_0.Size = new Size(396, 22);
		textBox_0.TabIndex = 34;
		textBox_0.Text = Class16.smethod_0(1649070359);
		textBox_0.TextAlign = HorizontalAlignment.Center;
		textBox_0.Click += textBox_0_Click;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.DoubleClick += textBox_0_DoubleClick;
		textBox_0.Enter += textBox_0_Enter;
		textBox_0.Leave += textBox_0_Leave;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_0.Image = Resources.cmdAddItem;
		button_0.Location = new Point(2, 597);
		button_0.Name = Class16.smethod_0(1649070376);
		button_0.Size = new Size(206, 25);
		button_0.TabIndex = 33;
		button_0.Text = Class16.smethod_0(1648931361);
		button_0.TextAlign = ContentAlignment.MiddleRight;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_0.BackgroundColor = Color.FromArgb(32, 32, 32);
		dataGridView_0.BorderStyle = BorderStyle.None;
		dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_0.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_1, dataGridViewTextBoxColumn_2, dataGridViewImageColumn_0, dataGridViewTextBoxColumn_3, dataGridViewTextBoxColumn_4);
		dataGridView_0.ContextMenuStrip = contextMenuStrip_0;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(32, 32, 32);
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = Color.White;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = Color.White;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.EditMode = DataGridViewEditMode.EditOnEnter;
		dataGridView_0.GridColor = Color.Silver;
		dataGridView_0.Location = new Point(2, 33);
		dataGridView_0.Margin = new Padding(3, 4, 3, 4);
		dataGridView_0.Name = Class16.smethod_0(1649070393);
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
		dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellToolTips = false;
		dataGridView_0.Size = new Size(430, 562);
		dataGridView_0.TabIndex = 0;
		dataGridView_0.CellMouseEnter += dataGridView_0_CellMouseEnter;
		dataGridView_0.CellMouseLeave += dataGridView_0_CellMouseLeave;
		dataGridView_0.CellMouseMove += dataGridView_0_CellMouseMove;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridView_0.SortCompare += dataGridView_0_SortCompare;
		dataGridView_0.MouseLeave += dataGridView_0_MouseLeave;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle4.ForeColor = Color.Silver;
		dataGridViewTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_1.Frozen = true;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_1.MinimumWidth = 6;
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648929955);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.Width = 40;
		dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle5.ForeColor = Color.FromArgb(224, 224, 224);
		dataGridViewTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle5;
		dataGridViewTextBoxColumn_2.Frozen = true;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1649070408);
		dataGridViewTextBoxColumn_2.MinimumWidth = 6;
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648928792);
		dataGridViewTextBoxColumn_2.ReadOnly = true;
		dataGridViewTextBoxColumn_2.Width = 65;
		dataGridViewImageColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewImageColumn_0.HeaderText = string.Empty;
		dataGridViewImageColumn_0.MinimumWidth = 6;
		dataGridViewImageColumn_0.Name = Class16.smethod_0(1648930015);
		dataGridViewImageColumn_0.ReadOnly = true;
		dataGridViewImageColumn_0.Resizable = DataGridViewTriState.False;
		dataGridViewImageColumn_0.Width = 20;
		dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle6.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle6;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_3.MinimumWidth = 6;
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1649012442);
		dataGridViewTextBoxColumn_3.ReadOnly = true;
		dataGridViewTextBoxColumn_3.Resizable = DataGridViewTriState.True;
		dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle7.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		dataGridViewCellStyle7.ForeColor = Color.FromArgb(0, 200, 0);
		dataGridViewTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle7;
		dataGridViewTextBoxColumn_4.HeaderText = Class16.smethod_0(1648970377);
		dataGridViewTextBoxColumn_4.MinimumWidth = 6;
		dataGridViewTextBoxColumn_4.Name = Class16.smethod_0(1649070429);
		dataGridViewTextBoxColumn_4.ReadOnly = true;
		dataGridViewTextBoxColumn_4.Width = 80;
		contextMenuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		contextMenuStrip_0.ImageScalingSize = new Size(20, 20);
		contextMenuStrip_0.Items.AddRange(new ToolStripItem[10] { toolStripMenuItem_1, toolStripMenuItem_2, toolStripSeparator_1, toolStripMenuItem_10, toolStripMenuItem_7, toolStripSeparator_3, toolStripMenuItem_3, toolStripSeparator_4, toolStripMenuItem_8, toolStripMenuItem_9 });
		contextMenuStrip_0.Name = Class16.smethod_0(1649003266);
		contextMenuStrip_0.Size = new Size(301, 204);
		toolStripMenuItem_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		toolStripMenuItem_1.Image = Resources.mnuClone;
		toolStripMenuItem_1.Name = Class16.smethod_0(1649070444);
		toolStripMenuItem_1.ShortcutKeys = Keys.N | Keys.Control;
		toolStripMenuItem_1.Size = new Size(300, 26);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648931357);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_2.Image = Resources.mnuDelete;
		toolStripMenuItem_2.Name = Class16.smethod_0(1649003348);
		toolStripMenuItem_2.ShortcutKeys = Keys.Delete;
		toolStripMenuItem_2.Size = new Size(300, 26);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648925718);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripSeparator_1.Name = Class16.smethod_0(1649004015);
		toolStripSeparator_1.Size = new Size(297, 6);
		toolStripMenuItem_10.Image = Resources.mnuSetGoodsNameByItemName;
		toolStripMenuItem_10.Name = Class16.smethod_0(1649070451);
		toolStripMenuItem_10.Size = new Size(300, 26);
		toolStripMenuItem_10.Text = Class16.smethod_0(1649070483);
		toolStripMenuItem_10.Click += toolStripMenuItem_10_Click;
		toolStripMenuItem_7.Image = Resources.mnuChangeCat;
		toolStripMenuItem_7.Name = Class16.smethod_0(1649070525);
		toolStripMenuItem_7.Size = new Size(300, 26);
		toolStripMenuItem_7.Text = Class16.smethod_0(1649070536);
		toolStripMenuItem_7.Click += toolStripMenuItem_7_Click;
		toolStripSeparator_3.Name = Class16.smethod_0(1649003364);
		toolStripSeparator_3.Size = new Size(297, 6);
		toolStripMenuItem_3.Image = Resources.mnuGoTo;
		toolStripMenuItem_3.Name = Class16.smethod_0(1649070591);
		toolStripMenuItem_3.ShortcutKeys = Keys.G | Keys.Control;
		toolStripMenuItem_3.Size = new Size(300, 26);
		toolStripMenuItem_3.Text = Class16.smethod_0(1649073677);
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		toolStripSeparator_4.Name = Class16.smethod_0(1649073717);
		toolStripSeparator_4.Size = new Size(297, 6);
		toolStripMenuItem_8.Image = Resources.mnuExport;
		toolStripMenuItem_8.Name = Class16.smethod_0(1648996987);
		toolStripMenuItem_8.Size = new Size(300, 26);
		toolStripMenuItem_8.Text = Class16.smethod_0(1648931384);
		toolStripMenuItem_8.Click += toolStripMenuItem_8_Click;
		toolStripMenuItem_9.Image = Resources.mnuImport;
		toolStripMenuItem_9.Name = Class16.smethod_0(1649073742);
		toolStripMenuItem_9.Size = new Size(300, 26);
		toolStripMenuItem_9.Text = Class16.smethod_0(1648931405);
		toolStripMenuItem_9.Click += toolStripMenuItem_9_Click;
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.BackColor = Color.White;
		textBox_1.Location = new Point(94, 13);
		textBox_1.Name = Class16.smethod_0(1649073758);
		textBox_1.ReadOnly = true;
		textBox_1.Size = new Size(720, 22);
		textBox_1.TabIndex = 36;
		textBox_1.TextAlign = HorizontalAlignment.Center;
		button_3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_3.Enabled = false;
		button_3.Image = Resources.cmdSave;
		button_3.Location = new Point(919, 12);
		button_3.Name = Class16.smethod_0(1648920967);
		button_3.Size = new Size(144, 25);
		button_3.TabIndex = 38;
		button_3.Text = Class16.smethod_0(1649073775);
		button_3.TextAlign = ContentAlignment.MiddleRight;
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		button_4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_4.Image = Resources.cmdOpen;
		button_4.Location = new Point(816, 12);
		button_4.Name = Class16.smethod_0(1648920945);
		button_4.Size = new Size(102, 25);
		button_4.TabIndex = 39;
		button_4.Text = Class16.smethod_0(1648931498);
		button_4.TextAlign = ContentAlignment.MiddleRight;
		button_4.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		label_0.Location = new Point(7, 15);
		label_0.Name = Class16.smethod_0(1649073790);
		label_0.Size = new Size(70, 15);
		label_0.TabIndex = 72;
		label_0.Text = Class16.smethod_0(1649073801);
		groupBox_7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_7.Controls.Add(button_6);
		groupBox_7.Controls.Add(label_0);
		groupBox_7.Controls.Add(button_4);
		groupBox_7.Controls.Add(textBox_1);
		groupBox_7.Controls.Add(button_3);
		groupBox_7.Location = new Point(3, -3);
		groupBox_7.Name = Class16.smethod_0(1648929126);
		groupBox_7.Size = new Size(1097, 42);
		groupBox_7.TabIndex = 80;
		groupBox_7.TabStop = false;
		button_6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_6.Image = Resources.cmdOpenOtherFiles;
		button_6.Location = new Point(1064, 12);
		button_6.Name = Class16.smethod_0(1649073819);
		button_6.Size = new Size(30, 25);
		button_6.TabIndex = 73;
		button_6.TextAlign = ContentAlignment.MiddleRight;
		button_6.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_0.SetToolTip(button_6, Class16.smethod_0(1649073843));
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		panel_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		panel_0.Controls.Add(button_7);
		panel_0.Controls.Add(groupBox_0);
		panel_0.Controls.Add(dataGridView_0);
		panel_0.Controls.Add(button_2);
		panel_0.Controls.Add(button_0);
		panel_0.Controls.Add(button_1);
		panel_0.Controls.Add(textBox_0);
		panel_0.Location = new Point(3, 42);
		panel_0.Name = Class16.smethod_0(1648930054);
		panel_0.Size = new Size(1097, 626);
		panel_0.TabIndex = 81;
		button_7.Image = Resources.cmdAddFromElements;
		button_7.Location = new Point(210, 597);
		button_7.Name = Class16.smethod_0(1649073880);
		button_7.Size = new Size(24, 24);
		button_7.TabIndex = 111;
		button_7.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_0.SetToolTip(button_7, Class16.smethod_0(1649073905));
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		groupBox_0.BackColor = Color.FromArgb(239, 244, 250);
		groupBox_0.Controls.Add(groupBox_6);
		groupBox_0.Controls.Add(groupBox_5);
		groupBox_0.Controls.Add(groupBox_3);
		groupBox_0.Controls.Add(groupBox_2);
		groupBox_0.Controls.Add(checkBox_0);
		groupBox_0.Controls.Add(groupBox_1);
		groupBox_0.Controls.Add(numericUpDown_2);
		groupBox_0.Controls.Add(textBox_4);
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Controls.Add(numericUpDown_0);
		groupBox_0.Controls.Add(pictureBox_1);
		groupBox_0.Controls.Add(groupBox_4);
		groupBox_0.Controls.Add(checkBox_1);
		groupBox_0.Controls.Add(textBox_2);
		groupBox_0.Location = new Point(438, -7);
		groupBox_0.Name = Class16.smethod_0(1648929344);
		groupBox_0.Size = new Size(653, 627);
		groupBox_0.TabIndex = 73;
		groupBox_0.TabStop = false;
		groupBox_6.Controls.Add(dataGridView_1);
		groupBox_6.Location = new Point(6, 147);
		groupBox_6.Name = Class16.smethod_0(1649073948);
		groupBox_6.Size = new Size(640, 94);
		groupBox_6.TabIndex = 121;
		groupBox_6.TabStop = false;
		groupBox_6.Text = Class16.smethod_0(1649073988);
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToDeleteRows = false;
		dataGridView_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_1.BackgroundColor = Color.White;
		dataGridView_1.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		dataGridView_1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_1.ColumnHeadersVisible = false;
		dataGridView_1.Columns.AddRange(dataGridViewTextBoxColumn_0);
		dataGridView_1.ContextMenuStrip = contextMenuStrip_1;
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle8.BackColor = Color.White;
		dataGridViewCellStyle8.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle8.ForeColor = Color.Black;
		dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
		dataGridView_1.DefaultCellStyle = dataGridViewCellStyle8;
		dataGridView_1.EditMode = DataGridViewEditMode.EditOnEnter;
		dataGridView_1.GridColor = Color.Silver;
		dataGridView_1.Location = new Point(6, 18);
		dataGridView_1.Margin = new Padding(0);
		dataGridView_1.MultiSelect = false;
		dataGridView_1.Name = Class16.smethod_0(1649074031);
		dataGridView_1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle9.BackColor = SystemColors.Control;
		dataGridViewCellStyle9.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
		dataGridView_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
		dataGridView_1.RowHeadersVisible = false;
		dataGridView_1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle10.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_1.RowsDefaultCellStyle = dataGridViewCellStyle10;
		dataGridView_1.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_1.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_1.Size = new Size(628, 69);
		dataGridView_1.TabIndex = 109;
		dataGridView_1.CellDoubleClick += dataGridView_1_CellDoubleClick;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle11.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle11;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649074055);
		dataGridViewTextBoxColumn_0.MinimumWidth = 6;
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649074077);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.Resizable = DataGridViewTriState.True;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		contextMenuStrip_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		contextMenuStrip_1.ImageScalingSize = new Size(20, 20);
		contextMenuStrip_1.Items.AddRange(new ToolStripItem[4] { toolStripMenuItem_5, toolStripMenuItem_6, toolStripSeparator_2, toolStripMenuItem_4 });
		contextMenuStrip_1.Name = Class16.smethod_0(1649003266);
		contextMenuStrip_1.Size = new Size(119, 88);
		contextMenuStrip_1.Opening += contextMenuStrip_1_Opening;
		toolStripMenuItem_5.Image = Resources.mnuChangeItemCategory;
		toolStripMenuItem_5.Name = Class16.smethod_0(1649074091);
		toolStripMenuItem_5.Size = new Size(118, 26);
		toolStripMenuItem_5.Text = Class16.smethod_0(1648970834);
		toolStripMenuItem_5.Click += toolStripMenuItem_5_Click;
		toolStripMenuItem_6.ForeColor = Color.Red;
		toolStripMenuItem_6.Image = Resources.mnuDeleteItemCategory;
		toolStripMenuItem_6.Name = Class16.smethod_0(1649074127);
		toolStripMenuItem_6.Size = new Size(118, 26);
		toolStripMenuItem_6.Text = Class16.smethod_0(1648925718);
		toolStripMenuItem_6.Click += toolStripMenuItem_6_Click;
		toolStripSeparator_2.Name = Class16.smethod_0(1649072092);
		toolStripSeparator_2.Size = new Size(115, 6);
		toolStripMenuItem_4.Font = new Font(Class16.smethod_0(1648942905), 9f);
		toolStripMenuItem_4.Image = Resources.mnuAddItemCategory;
		toolStripMenuItem_4.Name = Class16.smethod_0(1649074147);
		toolStripMenuItem_4.Size = new Size(118, 26);
		toolStripMenuItem_4.Text = Class16.smethod_0(1648931361);
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		groupBox_5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_5.Controls.Add(numericUpDown_10);
		groupBox_5.Controls.Add(label_14);
		groupBox_5.Controls.Add(numericUpDown_8);
		groupBox_5.Controls.Add(label_11);
		groupBox_5.Controls.Add(label_12);
		groupBox_5.Controls.Add(dateTimePicker_0);
		groupBox_5.Controls.Add(dateTimePicker_1);
		groupBox_5.Controls.Add(label_13);
		groupBox_5.Location = new Point(214, 452);
		groupBox_5.Name = Class16.smethod_0(1649073156);
		groupBox_5.Size = new Size(432, 71);
		groupBox_5.TabIndex = 119;
		groupBox_5.TabStop = false;
		groupBox_5.Text = Class16.smethod_0(1649073174);
		numericUpDown_10.BackColor = SystemColors.Window;
		numericUpDown_10.ForeColor = Color.Black;
		numericUpDown_10.Location = new Point(354, 41);
		numericUpDown_10.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_10.Name = Class16.smethod_0(1649073189);
		numericUpDown_10.Size = new Size(70, 22);
		numericUpDown_10.TabIndex = 140;
		numericUpDown_10.TextAlign = HorizontalAlignment.Center;
		numericUpDown_10.ThousandsSeparator = true;
		numericUpDown_10.ValueChanged += numericUpDown_10_ValueChanged;
		label_14.Location = new Point(242, 44);
		label_14.Name = Class16.smethod_0(1649073209);
		label_14.Size = new Size(105, 16);
		label_14.TabIndex = 139;
		label_14.Text = Class16.smethod_0(1649073233);
		label_14.TextAlign = ContentAlignment.MiddleRight;
		numericUpDown_8.BackColor = SystemColors.Window;
		numericUpDown_8.ForeColor = Color.Black;
		numericUpDown_8.Location = new Point(354, 17);
		numericUpDown_8.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_8.Name = Class16.smethod_0(1649073262);
		numericUpDown_8.Size = new Size(70, 22);
		numericUpDown_8.TabIndex = 138;
		numericUpDown_8.TextAlign = HorizontalAlignment.Center;
		numericUpDown_8.ThousandsSeparator = true;
		numericUpDown_8.ValueChanged += numericUpDown_8_ValueChanged;
		label_11.Location = new Point(242, 20);
		label_11.Name = Class16.smethod_0(1649073274);
		label_11.Size = new Size(108, 16);
		label_11.TabIndex = 137;
		label_11.Text = Class16.smethod_0(1649073297);
		label_11.TextAlign = ContentAlignment.MiddleRight;
		label_12.Location = new Point(9, 44);
		label_12.Name = Class16.smethod_0(1649073327);
		label_12.Size = new Size(65, 16);
		label_12.TabIndex = 136;
		label_12.Text = Class16.smethod_0(1649073336);
		label_12.TextAlign = ContentAlignment.MiddleRight;
		dateTimePicker_0.Location = new Point(77, 42);
		dateTimePicker_0.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		dateTimePicker_0.MinDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		dateTimePicker_0.Name = Class16.smethod_0(1649073346);
		dateTimePicker_0.Size = new Size(154, 22);
		dateTimePicker_0.TabIndex = 135;
		dateTimePicker_0.Value = new DateTime(2014, 2, 13, 14, 32, 21, 0);
		dateTimePicker_0.ValueChanged += dateTimePicker_0_ValueChanged;
		dateTimePicker_1.Location = new Point(77, 18);
		dateTimePicker_1.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		dateTimePicker_1.MinDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		dateTimePicker_1.Name = Class16.smethod_0(1649073368);
		dateTimePicker_1.Size = new Size(154, 22);
		dateTimePicker_1.TabIndex = 134;
		dateTimePicker_1.Value = new DateTime(2014, 2, 13, 14, 32, 21, 0);
		dateTimePicker_1.ValueChanged += dateTimePicker_1_ValueChanged;
		label_13.Location = new Point(6, 21);
		label_13.Name = Class16.smethod_0(1649073392);
		label_13.Size = new Size(70, 16);
		label_13.TabIndex = 128;
		label_13.Text = Class16.smethod_0(1649073411);
		label_13.TextAlign = ContentAlignment.MiddleRight;
		groupBox_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_3.Controls.Add(comboBox_1);
		groupBox_3.Controls.Add(comboBox_0);
		groupBox_3.Controls.Add(numericUpDown_11);
		groupBox_3.Controls.Add(label_15);
		groupBox_3.Controls.Add(numericUpDown_12);
		groupBox_3.Controls.Add(label_16);
		groupBox_3.Controls.Add(numericUpDown_13);
		groupBox_3.Controls.Add(label_17);
		groupBox_3.Controls.Add(label_18);
		groupBox_3.Controls.Add(label_19);
		groupBox_3.Controls.Add(dateTimePicker_2);
		groupBox_3.Controls.Add(dateTimePicker_3);
		groupBox_3.Controls.Add(label_20);
		groupBox_3.Controls.Add(numericUpDown_7);
		groupBox_3.Controls.Add(label_9);
		groupBox_3.Controls.Add(textBox_6);
		groupBox_3.Controls.Add(label_10);
		groupBox_3.Controls.Add(label_8);
		groupBox_3.Location = new Point(6, 523);
		groupBox_3.Name = Class16.smethod_0(1649073432);
		groupBox_3.Size = new Size(640, 100);
		groupBox_3.TabIndex = 118;
		groupBox_3.TabStop = false;
		groupBox_3.Text = Class16.smethod_0(1649073450);
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Items.AddRange(new object[5]
		{
			Class16.smethod_0(1648908427),
			Class16.smethod_0(1649073467),
			Class16.smethod_0(1649073483),
			Class16.smethod_0(1649073497),
			Class16.smethod_0(1649073514)
		});
		comboBox_1.Location = new Point(339, 45);
		comboBox_1.Name = Class16.smethod_0(1649073535);
		comboBox_1.Size = new Size(119, 21);
		comboBox_1.TabIndex = 150;
		comboBox_1.SelectedIndexChanged += comboBox_1_SelectedIndexChanged;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1649073550),
			Class16.smethod_0(1649073560),
			Class16.smethod_0(1649073589)
		});
		comboBox_0.Location = new Point(339, 18);
		comboBox_0.Name = Class16.smethod_0(1649073606);
		comboBox_0.Size = new Size(119, 21);
		comboBox_0.TabIndex = 149;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		numericUpDown_11.BackColor = SystemColors.Window;
		numericUpDown_11.ForeColor = Color.Black;
		numericUpDown_11.Location = new Point(567, 73);
		numericUpDown_11.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_11.Name = Class16.smethod_0(1649073616);
		numericUpDown_11.Size = new Size(69, 22);
		numericUpDown_11.TabIndex = 148;
		numericUpDown_11.TextAlign = HorizontalAlignment.Center;
		numericUpDown_11.ThousandsSeparator = true;
		numericUpDown_11.ValueChanged += numericUpDown_11_ValueChanged;
		label_15.Location = new Point(466, 76);
		label_15.Name = Class16.smethod_0(1649073646);
		label_15.Size = new Size(99, 16);
		label_15.TabIndex = 147;
		label_15.Text = Class16.smethod_0(1649072647);
		label_15.TextAlign = ContentAlignment.MiddleRight;
		numericUpDown_12.BackColor = SystemColors.Window;
		numericUpDown_12.ForeColor = Color.Black;
		numericUpDown_12.Location = new Point(339, 72);
		numericUpDown_12.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_12.Name = Class16.smethod_0(1649072670);
		numericUpDown_12.Size = new Size(119, 22);
		numericUpDown_12.TabIndex = 146;
		numericUpDown_12.TextAlign = HorizontalAlignment.Center;
		numericUpDown_12.ThousandsSeparator = true;
		numericUpDown_12.ValueChanged += numericUpDown_12_ValueChanged;
		label_16.Location = new Point(237, 75);
		label_16.Name = Class16.smethod_0(1649072689);
		label_16.Size = new Size(98, 16);
		label_16.TabIndex = 145;
		label_16.Text = Class16.smethod_0(1649072712);
		label_16.TextAlign = ContentAlignment.MiddleRight;
		toolTip_0.SetToolTip(label_16, Class16.smethod_0(1649072670));
		numericUpDown_13.BackColor = SystemColors.Window;
		numericUpDown_13.ForeColor = Color.Black;
		numericUpDown_13.Location = new Point(567, 46);
		numericUpDown_13.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_13.Name = Class16.smethod_0(1649072740);
		numericUpDown_13.Size = new Size(69, 22);
		numericUpDown_13.TabIndex = 144;
		numericUpDown_13.TextAlign = HorizontalAlignment.Center;
		numericUpDown_13.ThousandsSeparator = true;
		numericUpDown_13.ValueChanged += numericUpDown_13_ValueChanged;
		label_17.Location = new Point(470, 48);
		label_17.Name = Class16.smethod_0(1649072767);
		label_17.Size = new Size(92, 16);
		label_17.TabIndex = 143;
		label_17.Text = Class16.smethod_0(1649072790);
		label_17.TextAlign = ContentAlignment.MiddleRight;
		toolTip_0.SetToolTip(label_17, Class16.smethod_0(1649072740));
		label_18.Location = new Point(253, 48);
		label_18.Name = Class16.smethod_0(1649072803);
		label_18.Size = new Size(83, 16);
		label_18.TabIndex = 141;
		label_18.Text = Class16.smethod_0(1649072830);
		label_18.TextAlign = ContentAlignment.MiddleRight;
		label_19.Location = new Point(6, 48);
		label_19.Name = Class16.smethod_0(1649072853);
		label_19.Size = new Size(73, 16);
		label_19.TabIndex = 140;
		label_19.Text = Class16.smethod_0(1649073336);
		label_19.TextAlign = ContentAlignment.MiddleRight;
		dateTimePicker_2.Location = new Point(83, 46);
		dateTimePicker_2.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		dateTimePicker_2.MinDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		dateTimePicker_2.Name = Class16.smethod_0(1649072870);
		dateTimePicker_2.Size = new Size(146, 22);
		dateTimePicker_2.TabIndex = 139;
		dateTimePicker_2.Value = new DateTime(2014, 2, 13, 14, 32, 21, 0);
		dateTimePicker_2.ValueChanged += dateTimePicker_2_ValueChanged;
		dateTimePicker_3.Location = new Point(83, 21);
		dateTimePicker_3.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		dateTimePicker_3.MinDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		dateTimePicker_3.Name = Class16.smethod_0(1649072880);
		dateTimePicker_3.Size = new Size(146, 22);
		dateTimePicker_3.TabIndex = 138;
		dateTimePicker_3.Value = new DateTime(2014, 2, 13, 14, 32, 21, 0);
		dateTimePicker_3.ValueChanged += dateTimePicker_3_ValueChanged;
		label_20.Location = new Point(3, 21);
		label_20.Name = Class16.smethod_0(1649072908);
		label_20.Size = new Size(78, 16);
		label_20.TabIndex = 137;
		label_20.Text = Class16.smethod_0(1649072927);
		label_20.TextAlign = ContentAlignment.MiddleRight;
		numericUpDown_7.BackColor = SystemColors.Window;
		numericUpDown_7.ForeColor = Color.Black;
		numericUpDown_7.Location = new Point(567, 19);
		numericUpDown_7.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_7.Name = Class16.smethod_0(1649072939);
		numericUpDown_7.Size = new Size(69, 22);
		numericUpDown_7.TabIndex = 122;
		numericUpDown_7.TextAlign = HorizontalAlignment.Center;
		numericUpDown_7.ThousandsSeparator = true;
		numericUpDown_7.ValueChanged += numericUpDown_7_ValueChanged;
		label_9.Location = new Point(473, 21);
		label_9.Name = Class16.smethod_0(1649072966);
		label_9.Size = new Size(92, 16);
		label_9.TabIndex = 121;
		label_9.Text = Class16.smethod_0(1649072988);
		label_9.TextAlign = ContentAlignment.MiddleRight;
		textBox_6.Location = new Point(83, 70);
		textBox_6.Name = Class16.smethod_0(1649073000);
		textBox_6.Size = new Size(146, 22);
		textBox_6.TabIndex = 120;
		textBox_6.TextAlign = HorizontalAlignment.Center;
		textBox_6.TextChanged += textBox_6_TextChanged;
		label_10.Location = new Point(7, 73);
		label_10.Name = Class16.smethod_0(1649073017);
		label_10.Size = new Size(72, 16);
		label_10.TabIndex = 119;
		label_10.Text = Class16.smethod_0(1649073044);
		label_10.TextAlign = ContentAlignment.MiddleRight;
		label_8.Location = new Point(258, 21);
		label_8.Name = Class16.smethod_0(1649073062);
		label_8.Size = new Size(76, 16);
		label_8.TabIndex = 117;
		label_8.Text = Class16.smethod_0(1649073072);
		label_8.TextAlign = ContentAlignment.MiddleRight;
		groupBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		groupBox_2.Controls.Add(button_5);
		groupBox_2.Controls.Add(textBox_3);
		groupBox_2.Location = new Point(6, 245);
		groupBox_2.Name = Class16.smethod_0(1649073088);
		groupBox_2.Size = new Size(640, 203);
		groupBox_2.TabIndex = 117;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1648997999);
		button_5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_5.Image = Resources.cmdPasteColorTag;
		button_5.ImageAlign = ContentAlignment.MiddleRight;
		button_5.Location = new Point(6, 17);
		button_5.Name = Class16.smethod_0(1649073117);
		button_5.Size = new Size(628, 23);
		button_5.TabIndex = 108;
		button_5.Text = Class16.smethod_0(1649073140);
		button_5.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		textBox_3.AcceptsReturn = true;
		textBox_3.AcceptsTab = true;
		textBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_3.BackColor = SystemColors.Window;
		textBox_3.Location = new Point(6, 42);
		textBox_3.Multiline = true;
		textBox_3.Name = Class16.smethod_0(1649072131);
		textBox_3.ScrollBars = ScrollBars.Vertical;
		textBox_3.Size = new Size(628, 155);
		textBox_3.TabIndex = 106;
		textBox_3.TextChanged += textBox_3_TextChanged;
		textBox_3.MouseLeave += textBox_3_MouseLeave;
		textBox_3.MouseMove += textBox_3_MouseMove;
		checkBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold | FontStyle.Underline);
		checkBox_0.ForeColor = Color.Red;
		checkBox_0.Location = new Point(564, 123);
		checkBox_0.Name = Class16.smethod_0(1649072153);
		checkBox_0.Size = new Size(86, 20);
		checkBox_0.TabIndex = 116;
		checkBox_0.Text = Class16.smethod_0(1649072174);
		checkBox_0.TextAlign = ContentAlignment.MiddleCenter;
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		groupBox_1.Controls.Add(numericUpDown_9);
		groupBox_1.Controls.Add(label_5);
		groupBox_1.Controls.Add(numericUpDown_3);
		groupBox_1.Controls.Add(label_2);
		groupBox_1.Controls.Add(label_3);
		groupBox_1.Controls.Add(textBox_5);
		groupBox_1.Controls.Add(pictureBox_0);
		groupBox_1.Controls.Add(numericUpDown_4);
		groupBox_1.Controls.Add(numericUpDown_1);
		groupBox_1.Controls.Add(label_4);
		groupBox_1.Location = new Point(6, 67);
		groupBox_1.Name = Class16.smethod_0(1649072189);
		groupBox_1.Size = new Size(554, 75);
		groupBox_1.TabIndex = 115;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1649072204);
		numericUpDown_9.BackColor = SystemColors.Window;
		numericUpDown_9.ForeColor = Color.Black;
		numericUpDown_9.Location = new Point(446, 45);
		numericUpDown_9.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_9.Name = Class16.smethod_0(1649072208);
		numericUpDown_9.Size = new Size(102, 22);
		numericUpDown_9.TabIndex = 120;
		numericUpDown_9.TextAlign = HorizontalAlignment.Center;
		numericUpDown_9.ThousandsSeparator = true;
		numericUpDown_9.ValueChanged += numericUpDown_9_ValueChanged;
		label_5.Location = new Point(348, 47);
		label_5.Name = Class16.smethod_0(1649072225);
		label_5.Size = new Size(96, 16);
		label_5.TabIndex = 119;
		label_5.Text = Class16.smethod_0(1649072243);
		label_5.TextAlign = ContentAlignment.MiddleRight;
		numericUpDown_3.BackColor = SystemColors.Window;
		numericUpDown_3.ForeColor = Color.Black;
		numericUpDown_3.Location = new Point(228, 45);
		numericUpDown_3.Maximum = new decimal(new int[4] { 900000000, 0, 0, 0 });
		numericUpDown_3.Name = Class16.smethod_0(1648970377);
		numericUpDown_3.Size = new Size(102, 22);
		numericUpDown_3.TabIndex = 118;
		numericUpDown_3.TextAlign = HorizontalAlignment.Center;
		numericUpDown_3.ThousandsSeparator = true;
		numericUpDown_3.ValueChanged += numericUpDown_3_ValueChanged;
		label_2.Location = new Point(183, 47);
		label_2.Name = Class16.smethod_0(1649072259);
		label_2.Size = new Size(41, 16);
		label_2.TabIndex = 117;
		label_2.Text = Class16.smethod_0(1649072274);
		label_2.TextAlign = ContentAlignment.MiddleRight;
		label_3.Location = new Point(52, 19);
		label_3.Name = Class16.smethod_0(1649072295);
		label_3.Size = new Size(61, 16);
		label_3.TabIndex = 116;
		label_3.Text = Class16.smethod_0(1649072309);
		label_3.TextAlign = ContentAlignment.MiddleRight;
		textBox_5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_5.BackColor = Color.FromArgb(32, 32, 32);
		textBox_5.BorderStyle = BorderStyle.FixedSingle;
		textBox_5.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_5.ForeColor = Color.White;
		textBox_5.Location = new Point(184, 17);
		textBox_5.MaxLength = 32;
		textBox_5.Name = Class16.smethod_0(1649072313);
		textBox_5.ReadOnly = true;
		textBox_5.Size = new Size(364, 23);
		textBox_5.TabIndex = 115;
		textBox_5.TextAlign = HorizontalAlignment.Center;
		pictureBox_0.BackColor = Color.Transparent;
		pictureBox_0.Cursor = Cursors.Hand;
		pictureBox_0.Image = Resources.ItemIcon;
		pictureBox_0.Location = new Point(6, 22);
		pictureBox_0.Name = Class16.smethod_0(1649072328);
		pictureBox_0.Size = new Size(40, 40);
		pictureBox_0.SizeMode = PictureBoxSizeMode.CenterImage;
		pictureBox_0.TabIndex = 100;
		pictureBox_0.TabStop = false;
		pictureBox_0.Click += pictureBox_0_Click;
		numericUpDown_4.BackColor = SystemColors.Window;
		numericUpDown_4.ForeColor = Color.Black;
		numericUpDown_4.Location = new Point(113, 45);
		numericUpDown_4.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_4.Name = Class16.smethod_0(1648968311);
		numericUpDown_4.Size = new Size(65, 22);
		numericUpDown_4.TabIndex = 114;
		numericUpDown_4.TextAlign = HorizontalAlignment.Center;
		numericUpDown_4.ThousandsSeparator = true;
		numericUpDown_4.ValueChanged += numericUpDown_4_ValueChanged;
		numericUpDown_1.BackColor = Color.FromArgb(255, 255, 128);
		numericUpDown_1.ForeColor = Color.Black;
		numericUpDown_1.Location = new Point(113, 17);
		numericUpDown_1.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_1.Name = Class16.smethod_0(1649070408);
		numericUpDown_1.Size = new Size(65, 22);
		numericUpDown_1.TabIndex = 96;
		numericUpDown_1.TextAlign = HorizontalAlignment.Center;
		numericUpDown_1.ValueChanged += numericUpDown_1_ValueChanged;
		numericUpDown_1.DoubleClick += numericUpDown_1_DoubleClick;
		label_4.Location = new Point(55, 47);
		label_4.Name = Class16.smethod_0(1649072351);
		label_4.Size = new Size(56, 16);
		label_4.TabIndex = 113;
		label_4.Text = Class16.smethod_0(1649072367);
		label_4.TextAlign = ContentAlignment.MiddleRight;
		numericUpDown_2.BackColor = Color.FromArgb(255, 255, 128);
		numericUpDown_2.ForeColor = Color.Black;
		numericUpDown_2.Location = new Point(78, 39);
		numericUpDown_2.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_2.Name = Class16.smethod_0(1649072381);
		numericUpDown_2.Size = new Size(59, 22);
		numericUpDown_2.TabIndex = 112;
		numericUpDown_2.TextAlign = HorizontalAlignment.Center;
		numericUpDown_2.ValueChanged += numericUpDown_2_ValueChanged;
		numericUpDown_2.DoubleClick += numericUpDown_2_DoubleClick;
		textBox_4.Cursor = Cursors.Arrow;
		textBox_4.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_4.Location = new Point(143, 41);
		textBox_4.Name = Class16.smethod_0(1649072396);
		textBox_4.ReadOnly = true;
		textBox_4.Size = new Size(417, 20);
		textBox_4.TabIndex = 111;
		textBox_4.TextAlign = HorizontalAlignment.Center;
		textBox_4.DoubleClick += textBox_4_DoubleClick;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 10f);
		label_1.Location = new Point(8, 42);
		label_1.Name = Class16.smethod_0(1649072415);
		label_1.Size = new Size(64, 18);
		label_1.TabIndex = 110;
		label_1.Text = Class16.smethod_0(1649072429);
		label_1.TextAlign = ContentAlignment.MiddleRight;
		numericUpDown_0.BackColor = SystemColors.Window;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 11f);
		numericUpDown_0.ForeColor = Color.Black;
		numericUpDown_0.Location = new Point(6, 10);
		numericUpDown_0.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648941057);
		numericUpDown_0.Size = new Size(66, 27);
		numericUpDown_0.TabIndex = 103;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.ThousandsSeparator = true;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		pictureBox_1.BackColor = Color.FromArgb(8, 16, 24);
		pictureBox_1.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_1.Cursor = Cursors.Hand;
		pictureBox_1.Location = new Point(566, 40);
		pictureBox_1.Name = Class16.smethod_0(1648895083);
		pictureBox_1.Size = new Size(80, 80);
		pictureBox_1.TabIndex = 102;
		pictureBox_1.TabStop = false;
		pictureBox_1.Click += pictureBox_1_Click;
		groupBox_4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_4.Controls.Add(label_6);
		groupBox_4.Controls.Add(pictureBox_2);
		groupBox_4.Controls.Add(numericUpDown_5);
		groupBox_4.Controls.Add(numericUpDown_6);
		groupBox_4.Controls.Add(label_7);
		groupBox_4.Location = new Point(6, 452);
		groupBox_4.Name = Class16.smethod_0(1649072433);
		groupBox_4.Size = new Size(202, 71);
		groupBox_4.TabIndex = 116;
		groupBox_4.TabStop = false;
		groupBox_4.Text = Class16.smethod_0(1649072455);
		label_6.Location = new Point(52, 20);
		label_6.Name = Class16.smethod_0(1649072458);
		label_6.Size = new Size(61, 16);
		label_6.TabIndex = 116;
		label_6.Text = Class16.smethod_0(1649072309);
		label_6.TextAlign = ContentAlignment.MiddleRight;
		pictureBox_2.BackColor = Color.FromArgb(32, 32, 32);
		pictureBox_2.Cursor = Cursors.Hand;
		pictureBox_2.Location = new Point(6, 21);
		pictureBox_2.Name = Class16.smethod_0(1649072472);
		pictureBox_2.Size = new Size(40, 40);
		pictureBox_2.SizeMode = PictureBoxSizeMode.CenterImage;
		pictureBox_2.TabIndex = 100;
		pictureBox_2.TabStop = false;
		pictureBox_2.Click += pictureBox_2_Click;
		numericUpDown_5.BackColor = SystemColors.Window;
		numericUpDown_5.DecimalPlaces = 5;
		numericUpDown_5.ForeColor = Color.Black;
		numericUpDown_5.Location = new Point(113, 42);
		numericUpDown_5.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_5.Name = Class16.smethod_0(1649072495);
		numericUpDown_5.Size = new Size(82, 22);
		numericUpDown_5.TabIndex = 114;
		numericUpDown_5.TextAlign = HorizontalAlignment.Center;
		numericUpDown_5.ThousandsSeparator = true;
		numericUpDown_5.ValueChanged += numericUpDown_5_ValueChanged;
		numericUpDown_6.BackColor = Color.FromArgb(255, 255, 128);
		numericUpDown_6.ForeColor = Color.Black;
		numericUpDown_6.Location = new Point(113, 18);
		numericUpDown_6.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_6.Name = Class16.smethod_0(1649072510);
		numericUpDown_6.Size = new Size(82, 22);
		numericUpDown_6.TabIndex = 96;
		numericUpDown_6.TextAlign = HorizontalAlignment.Center;
		numericUpDown_6.ValueChanged += numericUpDown_6_ValueChanged;
		numericUpDown_6.DoubleClick += numericUpDown_6_DoubleClick;
		label_7.Location = new Point(55, 44);
		label_7.Name = Class16.smethod_0(1649072515);
		label_7.Size = new Size(57, 16);
		label_7.TabIndex = 113;
		label_7.Text = Class16.smethod_0(1649072529);
		label_7.TextAlign = ContentAlignment.MiddleRight;
		checkBox_1.AutoSize = true;
		checkBox_1.Font = new Font(Class16.smethod_0(1648942905), 9f);
		checkBox_1.Location = new Point(631, 18);
		checkBox_1.Name = Class16.smethod_0(1649072551);
		checkBox_1.Size = new Size(15, 14);
		checkBox_1.TabIndex = 109;
		toolTip_0.SetToolTip(checkBox_1, Class16.smethod_0(1649072551));
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.CheckedChanged += checkBox_1_CheckedChanged;
		textBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_2.BackColor = SystemColors.Window;
		textBox_2.Font = new Font(Class16.smethod_0(1648942905), 11f);
		textBox_2.ForeColor = Color.Black;
		textBox_2.Location = new Point(78, 10);
		textBox_2.MaxLength = 32;
		textBox_2.Name = Class16.smethod_0(1649072568);
		textBox_2.Size = new Size(547, 27);
		textBox_2.TabIndex = 99;
		textBox_2.TextAlign = HorizontalAlignment.Center;
		textBox_2.TextChanged += textBox_2_TextChanged;
		backgroundWorker_0.DoWork += backgroundWorker_0_DoWork;
		backgroundWorker_0.RunWorkerCompleted += backgroundWorker_0_RunWorkerCompleted;
		timer_0.Interval = 200;
		timer_0.Tick += timer_0_Tick;
		statusStrip_0.ImageScalingSize = new Size(20, 20);
		statusStrip_0.Items.AddRange(new ToolStripItem[5] { toolStripProgressBar_0, toolStripStatusLabel_0, toolStripStatusLabel_1, toolStripStatusLabel_2, toolStripStatusLabel_3 });
		statusStrip_0.Location = new Point(0, 666);
		statusStrip_0.Name = Class16.smethod_0(1649003514);
		statusStrip_0.Size = new Size(1102, 22);
		statusStrip_0.TabIndex = 82;
		statusStrip_0.Text = Class16.smethod_0(1649003514);
		toolStripProgressBar_0.Name = Class16.smethod_0(1649072588);
		toolStripProgressBar_0.Size = new Size(1080, 16);
		toolStripStatusLabel_0.Name = Class16.smethod_0(1649072595);
		toolStripStatusLabel_0.Size = new Size(77, 15);
		toolStripStatusLabel_0.Spring = true;
		toolStripStatusLabel_0.Text = Class16.smethod_0(1649072623);
		toolStripStatusLabel_0.Visible = false;
		toolStripStatusLabel_1.ForeColor = Color.FromArgb(192, 0, 0);
		toolStripStatusLabel_1.Name = Class16.smethod_0(1649067524);
		toolStripStatusLabel_1.RightToLeft = RightToLeft.Yes;
		toolStripStatusLabel_1.Size = new Size(127, 15);
		toolStripStatusLabel_1.Spring = true;
		toolStripStatusLabel_1.Text = Class16.smethod_0(1649067537);
		toolStripStatusLabel_1.ToolTipText = Class16.smethod_0(1649067574);
		toolStripStatusLabel_1.Visible = false;
		toolStripStatusLabel_2.ForeColor = Color.FromArgb(192, 0, 0);
		toolStripStatusLabel_2.Name = Class16.smethod_0(1649067609);
		toolStripStatusLabel_2.RightToLeft = RightToLeft.Yes;
		toolStripStatusLabel_2.Size = new Size(143, 15);
		toolStripStatusLabel_2.Spring = true;
		toolStripStatusLabel_2.Text = Class16.smethod_0(1649067638);
		toolStripStatusLabel_2.ToolTipText = Class16.smethod_0(1649067574);
		toolStripStatusLabel_2.Visible = false;
		toolStripStatusLabel_3.ForeColor = Color.FromArgb(192, 0, 0);
		toolStripStatusLabel_3.Name = Class16.smethod_0(1649067670);
		toolStripStatusLabel_3.RightToLeft = RightToLeft.Yes;
		toolStripStatusLabel_3.Size = new Size(136, 15);
		toolStripStatusLabel_3.Spring = true;
		toolStripStatusLabel_3.Text = Class16.smethod_0(1649067689);
		toolStripStatusLabel_3.ToolTipText = Class16.smethod_0(1649067574);
		toolStripStatusLabel_3.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(1102, 688);
		base.Controls.Add(statusStrip_0);
		base.Controls.Add(groupBox_7);
		base.Controls.Add(panel_0);
		base.Controls.Add(menuStrip_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.Icon = Resources.GShopEditor_FW_Icon;
		base.MainMenuStrip = menuStrip_0;
		base.Margin = new Padding(3, 4, 3, 4);
		base.Name = Class16.smethod_0(1649070284);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649067720);
		base.Activated += GShopEditor_FW_Activated;
		base.FormClosing += GShopEditor_FW_FormClosing;
		base.Shown += GShopEditor_FW_Shown;
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		((ISupportInitialize)dataGridView_0).EndInit();
		contextMenuStrip_0.ResumeLayout(performLayout: false);
		groupBox_7.ResumeLayout(performLayout: false);
		groupBox_7.PerformLayout();
		panel_0.ResumeLayout(performLayout: false);
		panel_0.PerformLayout();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		groupBox_6.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_1).EndInit();
		contextMenuStrip_1.ResumeLayout(performLayout: false);
		groupBox_5.ResumeLayout(performLayout: false);
		((ISupportInitialize)numericUpDown_10).EndInit();
		((ISupportInitialize)numericUpDown_8).EndInit();
		groupBox_3.ResumeLayout(performLayout: false);
		groupBox_3.PerformLayout();
		((ISupportInitialize)numericUpDown_11).EndInit();
		((ISupportInitialize)numericUpDown_12).EndInit();
		((ISupportInitialize)numericUpDown_13).EndInit();
		((ISupportInitialize)numericUpDown_7).EndInit();
		groupBox_2.ResumeLayout(performLayout: false);
		groupBox_2.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		((ISupportInitialize)numericUpDown_9).EndInit();
		((ISupportInitialize)numericUpDown_3).EndInit();
		((ISupportInitialize)pictureBox_0).EndInit();
		((ISupportInitialize)numericUpDown_4).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		((ISupportInitialize)numericUpDown_2).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)pictureBox_1).EndInit();
		groupBox_4.ResumeLayout(performLayout: false);
		((ISupportInitialize)pictureBox_2).EndInit();
		((ISupportInitialize)numericUpDown_5).EndInit();
		((ISupportInitialize)numericUpDown_6).EndInit();
		statusStrip_0.ResumeLayout(performLayout: false);
		statusStrip_0.PerformLayout();
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
				method_5();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void method_7(DataGridViewRow dataGridViewRow_0, int int_0)
	{
		string text = DataFiles.GShop.Items[int_0].sName;
		Color foreColor = Color.FromArgb(255, 237, 165);
		Image value = eLC.Icons.GetIcon(string.Empty, IsTga: false, 20);
		GSHOP_ITEM_FW gSHOP_ITEM_FW = (GSHOP_ITEM_FW)DataFiles.GShop.Items[int_0];
		int itemID = gSHOP_ITEM_FW.ItemID;
		eListCollection eListCollection2 = eLC;
		int[] mattersLists = eListCollection2.MattersLists;
		eListCollection eListCollection3 = eListCollection2;
		ITEMPOS itemPos = eListCollection3.FindItemPos(mattersLists, itemID);
		ITEMINFO itemInfo = eListCollection3.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		DataFiles.GShop.Items[int_0].ItemInfo = itemInfo;
		if (itemInfo != null)
		{
			Color white = Color.White;
			if (itemInfo.color != white)
			{
				foreColor = itemInfo.color;
			}
			value = eLC.Icons.GetIcon(itemInfo.IconName, IsTga: false, 20);
		}
		else
		{
			string text2;
			if (itemID != 0)
			{
				text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
				foreColor = Color.Red;
			}
			else
			{
				text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648971625));
			}
			string text3 = Class16.smethod_0(1649008474);
			text = string.Concat(text, string.Concat(Class16.smethod_0(1648961184) + text2, text3));
		}
		if (gSHOP_ITEM_FW.IsHide != 0)
		{
			foreColor = Color.Gray;
		}
		if (dataGridViewRow_0.Cells.Count == 0)
		{
			dataGridViewRow_0.CreateCells(dataGridView_0);
		}
		int iD = gSHOP_ITEM_FW.ID;
		dataGridViewRow_0.Cells[0].Value = iD.ToString();
		int num = itemID;
		dataGridViewRow_0.Cells[1].Value = num.ToString();
		dataGridViewRow_0.Cells[2].Value = value;
		dataGridViewRow_0.Cells[3].Value = text;
		int price = gSHOP_ITEM_FW.Price;
		string text4 = Class16.smethod_0(1648909972);
		dataGridViewRow_0.Cells[4].Value = price.ToString(text4);
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn = dataGridViewTextBoxColumn_3;
		dataGridViewRow_0.Cells[3].Style.Font = dataGridViewTextBoxColumn.DefaultCellStyle.Font;
		dataGridViewRow_0.Cells[3].Style.ForeColor = foreColor;
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = dataGridViewTextBoxColumn_4;
		dataGridViewRow_0.Cells[4].Style.Font = dataGridViewTextBoxColumn2.DefaultCellStyle.Font;
		dataGridViewRow_0.Tag = int_0;
		GC.KeepAlive(this);
	}

	private void method_8(Control.ControlCollection controlCollection_0, Color color_1)
	{
		foreach (Control item in controlCollection_0)
		{
			Color color = Color.FromArgb(255, 255, 128);
			if (item is NumericUpDown && !(item.BackColor == color))
			{
				item.BackColor = color_1;
			}
		}
		GC.KeepAlive(this);
	}

	private static DateTime smethod_0(DateTimePicker dateTimePicker_4, DateTime dateTime_0)
	{
		if (dateTimePicker_4 == null)
		{
			return dateTime_0;
		}
		if (dateTime_0 < dateTimePicker_4.MinDate)
		{
			return dateTimePicker_4.MinDate;
		}
		if (dateTime_0 > dateTimePicker_4.MaxDate)
		{
			return dateTimePicker_4.MaxDate;
		}
		return dateTime_0;
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_2.Enabled = b != 0;
		byte b2 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		groupBox_0.Enabled = b2 != 0;
		if (dataGridView_0.SelectedRows.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		object[] vars = new object[3]
		{
			dataGridView_0.SelectedRows[0].Index,
			dataGridView_0.SelectedRows.Count,
			dataGridView_0.RowCount
		};
		string headerText = TextStorage.TEXTS.GetText(Class16.smethod_0(1648978629), vars);
		dataGridViewTextBoxColumn_3.HeaderText = headerText;
		DataGridView dataGridView = dataGridView_0;
		DataGridView dataGridView2 = dataGridView_0;
		SelectedItem = (int)dataGridView2.Rows[dataGridView.SelectedRows[0].Index].Tag;
		Color numericDefaultBack = TDark.NumericDefaultBack;
		Color searchEditBack = TDark.SearchEditBack;
		if (dataGridView_0.SelectedRows.Count > 1)
		{
			if (numericUpDown_0.BackColor == numericDefaultBack)
			{
				method_8(groupBox_0.Controls, searchEditBack);
			}
			toolStripMenuItem_7.Visible = false;
			GC.KeepAlive(this);
			return;
		}
		if (numericUpDown_0.BackColor != numericDefaultBack)
		{
			method_8(groupBox_0.Controls, numericDefaultBack);
		}
		toolStripMenuItem_7.Visible = true;
		DontChange = true;
		int selectedItem = SelectedItem;
		decimal value = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem]).ID;
		numericUpDown_0.Value = value;
		int selectedItem2 = SelectedItem;
		GSHOP_ITEM[] items = DataFiles.GShop.Items;
		textBox_2.Text = ((GSHOP_ITEM_FW)items[selectedItem2]).sName;
		int selectedItem3 = SelectedItem;
		decimal value2 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem3]).FileIcon;
		numericUpDown_2.Value = value2;
		int selectedItem4 = SelectedItem;
		decimal value3 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem4]).ItemID;
		numericUpDown_1.Value = value3;
		int selectedItem5 = SelectedItem;
		decimal value4 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem5]).Count;
		numericUpDown_4.Value = value4;
		int selectedItem6 = SelectedItem;
		byte b3 = ((((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem6]).IsHide == 1) ? ((byte)1) : ((byte)0));
		checkBox_0.Checked = b3 != 0;
		int selectedItem7 = SelectedItem;
		byte b4 = ((((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem7]).CanGetConsumeScore == 1) ? ((byte)1) : ((byte)0));
		checkBox_1.Checked = b4 != 0;
		int selectedItem8 = SelectedItem;
		decimal value5 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem8]).GiftID;
		numericUpDown_6.Value = value5;
		int selectedItem9 = SelectedItem;
		decimal value6 = (decimal)((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem9]).GiftRate;
		numericUpDown_5.Value = value6;
		int selectedItem10 = SelectedItem;
		if (((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem10]).BuyTypeMask == 1)
		{
			comboBox_0.SelectedIndex = 0;
		}
		else
		{
			int selectedItem11 = SelectedItem;
			if (((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem11]).BuyTypeMask == 8)
			{
				comboBox_0.SelectedIndex = 1;
			}
			else
			{
				int selectedItem12 = SelectedItem;
				if (((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem12]).BuyTypeMask == 9)
				{
					comboBox_0.SelectedIndex = 2;
				}
			}
		}
		int selectedItem13 = SelectedItem;
		decimal value7 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem13]).Price;
		numericUpDown_3.Value = value7;
		int selectedItem14 = SelectedItem;
		decimal value8 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem14]).ExpireDate;
		numericUpDown_9.Value = value8;
		int selectedItem15 = SelectedItem;
		GSHOP_ITEM[] items2 = DataFiles.GShop.Items;
		textBox_6.Text = ((GSHOP_ITEM_FW)items2[selectedItem15]).sExtSearch;
		int selectedItem16 = SelectedItem;
		decimal value9 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem16]).NewItemIndex;
		numericUpDown_7.Value = value9;
		int selectedItem17 = SelectedItem;
		DateTime dateTime_ = ACE.RSGlobal.RSGlobal.Timestamp2DateTime(((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem17]).SellBeginTime);
		dateTimePicker_3.Value = smethod_0(dateTimePicker_3, dateTime_);
		int selectedItem18 = SelectedItem;
		DateTime dateTime_2 = ACE.RSGlobal.RSGlobal.Timestamp2DateTime(((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem18]).SellEndTime);
		dateTimePicker_2.Value = smethod_0(dateTimePicker_2, dateTime_2);
		int selectedItem19 = SelectedItem;
		DateTime dateTime_3 = ACE.RSGlobal.RSGlobal.Timestamp2DateTime(((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem19]).DiscountBeginTime);
		dateTimePicker_1.Value = smethod_0(dateTimePicker_1, dateTime_3);
		int selectedItem20 = SelectedItem;
		DateTime dateTime_4 = ACE.RSGlobal.RSGlobal.Timestamp2DateTime(((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem20]).DiscountEndTime);
		dateTimePicker_0.Value = smethod_0(dateTimePicker_0, dateTime_4);
		int selectedItem21 = SelectedItem;
		decimal value10 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem21]).DiscountPrice;
		numericUpDown_8.Value = value10;
		int selectedItem22 = SelectedItem;
		GSHOP_ITEM[] items3 = DataFiles.GShop.Items;
		comboBox_1.SelectedIndex = ((GSHOP_ITEM_FW)items3[selectedItem22]).LogoIcon;
		int selectedItem23 = SelectedItem;
		decimal value11 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem23]).PreviewBackgroundPic;
		numericUpDown_13.Value = value11;
		int selectedItem24 = SelectedItem;
		decimal value12 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem24]).PreviewPriority;
		numericUpDown_11.Value = value12;
		int selectedItem25 = SelectedItem;
		decimal value13 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem25]).DiscountItemShowIndex;
		numericUpDown_10.Value = value13;
		int selectedItem26 = SelectedItem;
		decimal value14 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem26]).PriorityPreviewModel;
		numericUpDown_12.Value = value14;
		DontChange = false;
	}

	private void method_9()
	{
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				method_3(dataGridView_0.SelectedRows[num].Index);
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void method_10()
	{
		int count = dataGridView_0.SelectedRows.Count;
		if (count > 0)
		{
			int[] array = new int[count];
			int num = 0;
			if (0 < count)
			{
				do
				{
					int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
					array[num] = num2;
					num++;
				}
				while (num < count);
			}
			Array.Sort(array);
			int num3 = 0;
			if (0 < count)
			{
				do
				{
					int sourceIndex = array[num3];
					DataFiles.GShop.AddItem(sourceIndex);
					int int_ = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
					dataGridView_0.Rows.Add(method_4(int_));
					num3++;
				}
				while (num3 < count);
			}
			DontChange = true;
			dataGridView_0.ClearSelection();
			DontChange = false;
			int rowIndex = dataGridView_0.RowCount - 1;
			dataGridView_0.CurrentCell = dataGridView_0[1, rowIndex];
			int num4 = dataGridView_0.RowCount - count;
			if (num4 < dataGridView_0.RowCount)
			{
				do
				{
					dataGridView_0.Rows[num4].Selected = true;
					num4++;
				}
				while (num4 < dataGridView_0.RowCount);
			}
		}
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_2.Enabled = b != 0;
		method_14();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_11();
	}

	private void method_11()
	{
		int count = dataGridView_0.SelectedRows.Count;
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
				array[num] = dataGridView_0.SelectedRows[num].Index;
				num++;
			}
			while (num < count);
		}
		DontChange = true;
		Array.Sort(array);
		int num2 = count - 1;
		if (num2 >= 0)
		{
			while ((nint)DataFiles.GShop.Items.LongLength != 1)
			{
				int index = array[num2];
				int num3 = (int)dataGridView_0.Rows[index].Tag;
				DataFiles.GShop.DeleteItem(num3);
				int index2 = array[num2];
				dataGridView_0.Rows.RemoveAt(index2);
				int num4 = 0;
				if (0 < (nint)DataFiles.GShop.Items.LongLength)
				{
					do
					{
						if ((int)dataGridView_0.Rows[num4].Tag >= num3)
						{
							int num5 = (int)dataGridView_0.Rows[num4].Tag - 1;
							dataGridView_0.Rows[num4].Tag = num5;
						}
						num4++;
					}
					while (num4 < (nint)DataFiles.GShop.Items.LongLength);
				}
				num2--;
				if (num2 < 0)
				{
					break;
				}
			}
		}
		DontChange = false;
		dataGridView_0_SelectionChanged(null, null);
		method_14();
	}

	private void method_12(object sender, EventArgs e)
	{
		ItemsWindow1.newlistsindices = eLC.MattersLists;
		ItemsWindow1.bMultiSelect = false;
		CStorage.ResetBuffer();
		method_0(out var _);
		if (CommonStorage.sData != null)
		{
			numericUpDown_1.Text = CommonStorage.sData;
		}
		GC.KeepAlive(this);
	}

	private void method_13()
	{
		DataFiles.GShop.Save();
		PATH_DATA pathData = eLC.PathData;
		if (pathData.FileChanged)
		{
			pathData.Save();
		}
		ITEM_EXT_DESC descriptions = Descriptions;
		if (descriptions != null && descriptions.FileChanged)
		{
			descriptions.Save(descriptions.fn, IsSaveAs: false);
		}
		ShopDirLua categories = Categories;
		if (categories != null && categories.FileChanged)
		{
			categories.Save();
		}
		IsFileChanged = false;
		method_30();
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_13();
	}

	private void toolStripMenuItem_13_Click(object sender, EventArgs e)
	{
		method_13();
	}

	private void method_14()
	{
		button_3.Enabled = true;
		IsFileChanged = true;
	}

	private void method_15(object sender, EventArgs e)
	{
		dataGridView_0.Focus();
		GC.KeepAlive(this);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		method_16();
	}

	private void method_16()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649067764);
		openFileDialog.FileName = Class16.smethod_0(1648909700);
		if (openFileDialog.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			LoadFile(openFileDialog.FileName);
		}
		GC.KeepAlive(this);
	}

	public void LoadFile(string fn)
	{
		textBox_1.Text = fn;
		LoadingComplete = false;
		DataFiles.GShop.Load(fn, PW_GSHOP_VERSION.AUTO, 0);
		bool fileLoaded = DataFiles.GShop.FileLoaded;
		panel_0.Enabled = fileLoaded;
		method_1();
		method_26();
		method_32();
		method_19();
		LoadingComplete = true;
		if (eLC.Params.GShopPath == string.Empty)
		{
			eLC.Params.GShopPath = fn;
			object gShopPath = eLC.Params.GShopPath;
			SettingsClass profile = CommonStorage.Profile;
			profile.SaveSetting(profile.DefaultSection, Class16.smethod_0(1649067797), gShopPath);
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_Enter(object sender, EventArgs e)
	{
		base.AcceptButton = button_1;
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
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
		if (LoadingComplete)
		{
			base.AcceptButton = button_1;
			if (textBox_0.TextLength < 3)
			{
				Color searchIdleBack = TDark.SearchIdleBack;
				textBox_0.BackColor = searchIdleBack;
			}
			if (textBox_0.TextLength > 3 || ACE.RSGlobal.RSGlobal.IsUIntFast(textBox_0.Text))
			{
				method_17(bool_1: true);
			}
		}
	}

	private void method_17([MarshalAs(UnmanagedType.U1)] bool bool_1)
	{
		if (ACE.RSGlobal.RSGlobal.antirecurse_FindItem_GShopEditor_FW)
		{
			return;
		}
		ACE.RSGlobal.RSGlobal.antirecurse_FindItem_GShopEditor_FW = true;
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
			int[] array = new int[dataGridView_0.SelectedRows.Count];
			int num3 = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					array[num3] = dataGridView_0.SelectedRows[num3].Index;
					num3++;
				}
				while (num3 < (nint)array.LongLength);
			}
			Array.Sort(array);
			num2 = array[(nint)array.LongLength - 1] + 1;
		}
		int num4 = -1;
		int num5 = num2;
		if (num2 < (nint)DataFiles.GShop.Items.LongLength)
		{
			while (true)
			{
				int num6 = (int)dataGridView_0.Rows[num5].Tag;
				GSHOP_ITEM_FW gSHOP_ITEM_FW = (GSHOP_ITEM_FW)DataFiles.GShop.Items[num6];
				if (flag)
				{
					if (gSHOP_ITEM_FW.ID == num)
					{
						goto IL_018b;
					}
					ITEMINFO itemInfo = gSHOP_ITEM_FW.ItemInfo;
					if (itemInfo != null && itemInfo.id == num)
					{
						goto IL_017f;
					}
				}
				else
				{
					if (ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(gSHOP_ITEM_FW.sName, text))
					{
						break;
					}
					ITEMINFO itemInfo2 = gSHOP_ITEM_FW.ItemInfo;
					if (itemInfo2 != null && ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(itemInfo2.name, text))
					{
						goto IL_0173;
					}
					if (ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(gSHOP_ITEM_FW.sExtSearch, text))
					{
						goto IL_0177;
					}
				}
				num5++;
				if (num5 < (nint)DataFiles.GShop.Items.LongLength)
				{
					continue;
				}
				goto IL_0183;
			}
			num4 = num5;
		}
		goto IL_018d;
		IL_01b4:
		if (!bool_1)
		{
			method_17(bool_1: true);
		}
		else
		{
			Color searchErrorBack = TDark.SearchErrorBack;
			textBox_0.BackColor = searchErrorBack;
		}
		goto IL_01d4;
		IL_018d:
		ACE.RSGlobal.RSGlobal.antirecurse_FindItem_GShopEditor_FW = false;
		if (num4 <= -1)
		{
			goto IL_01b4;
		}
		SelectRow(num4);
		Color searchMatchBack = TDark.SearchMatchBack;
		textBox_0.BackColor = searchMatchBack;
		goto IL_01d4;
		IL_018b:
		num4 = num5;
		goto IL_018d;
		IL_017f:
		num4 = num5;
		goto IL_018d;
		IL_0183:
		ACE.RSGlobal.RSGlobal.antirecurse_FindItem_GShopEditor_FW = false;
		goto IL_01b4;
		IL_01d4:
		GC.KeepAlive(this);
		return;
		IL_0177:
		num4 = num5;
		goto IL_018d;
		IL_0173:
		num4 = num5;
		goto IL_018d;
	}

	public void SelectItem(int ItemIndex)
	{
		int num = method_36(ItemIndex);
		if (num > -1)
		{
			SelectRow(num);
		}
	}

	public void SelectRow(int RowIndex)
	{
		DontChange = true;
		dataGridView_0.ClearSelection();
		DontChange = false;
		dataGridView_0.CurrentCell = dataGridView_0[1, RowIndex];
		dataGridView_0.Rows[RowIndex].Selected = true;
		GC.KeepAlive(this);
	}

	private void method_18()
	{
		try
		{
			ShopIconsWindow?.Hide();
		}
		catch
		{
		}
		try
		{
			ShopIconsWindow?.Dispose();
		}
		catch
		{
		}
		ShopIconsWindow = null;
		try
		{
			((IDisposable)ShopIcons)?.Dispose();
		}
		catch
		{
		}
		ShopIcons = null;
		pictureBox_1.Image = null;
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_17(bool_1: false);
	}

	private void GShopEditor_FW_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing)
		{
			e.Cancel = true;
		}
		Hide();
		if (!ElementsWindow.Visible)
		{
			ACE.RSGlobal.RSGlobal.End(null, null);
		}
		GC.KeepAlive(this);
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		SettingsWindow settingsWindow = new SettingsWindow(CStorage, Class16.smethod_0(1649067813));
		try
		{
			if (settingsWindow.ShowDialog(this) == DialogResult.OK)
			{
				object surfacesPckDir = eLC.Params.SurfacesPckDir;
				SettingsClass profile = CommonStorage.Profile;
				profile.SaveSetting(profile.DefaultSection, Class16.smethod_0(1649067817), surfacesPckDir);
				object shopDescPath = eLC.Params.ShopDescPath;
				SettingsClass profile2 = CommonStorage.Profile;
				profile2.SaveSetting(profile2.DefaultSection, Class16.smethod_0(1649067846), shopDescPath);
				object shopdirLua = eLC.Params.ShopdirLua;
				SettingsClass profile3 = CommonStorage.Profile;
				profile3.SaveSetting(profile3.DefaultSection, Class16.smethod_0(1649067857), shopdirLua);
				object gShopPath = eLC.Params.GShopPath;
				SettingsClass profile4 = CommonStorage.Profile;
				profile4.SaveSetting(profile4.DefaultSection, Class16.smethod_0(1649067797), gShopPath);
				method_26();
				method_32();
				method_19();
			}
		}
		finally
		{
			((IDisposable)settingsWindow).Dispose();
		}
	}

	private void method_19()
	{
		if (backgroundWorker_0.IsBusy)
		{
			GC.KeepAlive(this);
			return;
		}
		method_18();
		IconsLoaded = false;
		backgroundWorker_0.RunWorkerAsync();
		GC.KeepAlive(this);
	}

	private unsafe void method_20(string string_0, int* pInt_0)
	{
		string[] directories = Directory.GetDirectories(string_0);
		PfimImageReader pfimImageReader = new PfimImageReader();
		int num = 0;
		if (0 >= (nint)directories.LongLength)
		{
			return;
		}
		do
		{
			string text = directories[num];
			if (!text.EndsWith(Class16.smethod_0(1649067874)))
			{
				string[] files = Directory.GetFiles(text, Class16.smethod_0(1649067891));
				int num2 = 0;
				if (0 < (nint)files.LongLength)
				{
					do
					{
						string text2 = files[num2];
						if (new FileInfo(text2).Length <= 30720L)
						{
							Bitmap bitmap = pfimImageReader.ReadDds(File.OpenRead(text2));
							if (bitmap != null && bitmap.Width == 80)
							{
								string iconName = Class16.smethod_0(1648904820) + text2.Substring(text2.LastIndexOf(Class16.smethod_0(1649067911)));
								ShopIcons.TryAddIcon(iconName, bitmap);
								(*pInt_0)++;
							}
						}
						num2++;
					}
					while (num2 < (nint)files.LongLength);
				}
				if ((nint)Directory.GetDirectories(text).LongLength > 0)
				{
					method_20(text, pInt_0);
				}
			}
			num++;
		}
		while (num < (nint)directories.LongLength);
	}

	private int method_21()
	{
		int num = 0;
		PfimImageReader pfimImageReader = new PfimImageReader();
		foreach (KeyValuePair<string, int> fileTableIndex in PCKs[Class16.smethod_0(1649067915)].FileTableIndices)
		{
			ValueType valueType = fileTableIndex;
			string key = ((KeyValuePair<string, int>)(object)valueType).Key;
			if (!key.StartsWith(Class16.smethod_0(1649067930)) || !key.EndsWith(Class16.smethod_0(1648904847)) || key.StartsWith(Class16.smethod_0(1649067951)))
			{
				continue;
			}
			uint value = (uint)((KeyValuePair<string, int>)(object)valueType).Value;
			if ((int)PCKs[Class16.smethod_0(1649067915)].Pck.FileTable[value].OriginalSize > 30720)
			{
				continue;
			}
			PCK pCK = PCKs[Class16.smethod_0(1649067915)];
			byte[] fileContent = pCK.Pck.GetFileContent((int)value);
			if (fileContent != null)
			{
				Bitmap bitmap;
				try
				{
					bitmap = pfimImageReader.ReadDds(new MemoryStream(fileContent));
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureMessage(Class16.smethod_0(1649067975) + key + Class16.smethod_0(1648927638) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649068001));
					continue;
				}
				if (bitmap != null && bitmap.Width == 80)
				{
					string iconName = Class16.smethod_0(1648904820) + key.Substring(key.LastIndexOf(Class16.smethod_0(1649067911)));
					ShopIcons.TryAddIcon(iconName, bitmap);
					num++;
				}
			}
		}
		PCKs[Class16.smethod_0(1649067915)].Close();
		GC.KeepAlive(this);
		return num;
	}

	private unsafe void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		(ShopIcons = new ICONS(CStorage)).IsGShop = true;
		ShopIcons.icon_width = 80;
		ShopIcons.icon_height = 80;
		int num = 0;
		ParamsClass paramsClass = eLC.Params;
		if (paramsClass.UsePck)
		{
			if (!PCKs.LoadIfNotLoaded(Class16.smethod_0(1649067915)))
			{
				TextStorage.TEXTS.ShowErrorMessage(597);
				ShopIcons = null;
				return;
			}
			if (!PCKs[Class16.smethod_0(1649067915)].Pck.OpenRead())
			{
				TextStorage.TEXTS.ShowErrorMessage(597);
				ShopIcons = null;
				return;
			}
			num = method_21();
		}
		else
		{
			string text = paramsClass.SurfacesPckDir + Class16.smethod_0(1649067036);
			if (string.IsNullOrWhiteSpace(text) || !text.Contains(Class16.smethod_0(1649067041)) || !Directory.Exists(text))
			{
				TextStorage.TEXTS.ShowErrorMessage(596);
				ShopIcons = null;
				return;
			}
			method_20(text, &num);
		}
		ShopIcons.icons_per_line = 10;
		int lines_count = (int)Math.Ceiling((double)num / 10.0);
		ShopIcons.lines_count = lines_count;
		ShopIcons.SortedImage = ShopIcons.CreateScreenAdaptedImage(10);
		(ShopIconsWindow = new IconsWindow(CStorage, ShopIcons)).PathData = eLC.PathData;
		ShopIconsWindow.VIconsCount = 9;
		ShopIconsWindow.IsShopFWorJD = true;
		ShopIconsWindow.SortedIconsLoaded(10);
		GC.KeepAlive(this);
	}

	private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		if (ShopIcons != null)
		{
			IconsLoaded = true;
			method_25();
		}
	}

	private Image method_22(uint uint_0)
	{
		if (method_24(uint_0, out var string_))
		{
			Bitmap result = ShopIcons.GetIcon(string_, IsTga: false);
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return null;
	}

	private void pictureBox_1_Click(object sender, EventArgs e)
	{
		method_23();
	}

	private static void smethod_1(PictureBox pictureBox_3, Image image_0)
	{
		if (pictureBox_3 == null)
		{
			return;
		}
		Image image = pictureBox_3.Image;
		if (image_0 == null)
		{
			pictureBox_3.Image = null;
			if (image == null)
			{
				return;
			}
			try
			{
				image.Dispose();
				return;
			}
			catch
			{
				return;
			}
		}
		try
		{
			_ = image_0.FrameDimensionsList;
		}
		catch
		{
			pictureBox_3.Image = null;
			if (image != null)
			{
				try
				{
					image.Dispose();
					return;
				}
				catch
				{
					return;
				}
			}
			return;
		}
		Image image2 = null;
		try
		{
			image2 = (Image)image_0.Clone();
		}
		catch
		{
			try
			{
				image2 = new Bitmap(image_0);
			}
			catch
			{
				image2 = null;
			}
		}
		pictureBox_3.Image = image2;
		if (image == null)
		{
			return;
		}
		try
		{
			image.Dispose();
		}
		catch
		{
		}
	}

	private void method_23()
	{
		if (ShopIconsWindow == null)
		{
			method_19();
			TextStorage.TEXTS.ShowMessage(774, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			GC.KeepAlive(this);
			return;
		}
		CStorage.ResetBuffer();
		int selectedItem = SelectedItem;
		uint fileIcon = (uint)((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem]).FileIcon;
		method_24(fileIcon, out var string_);
		ShopIconsWindow.CurrentIconName = string_;
		ShopIconsWindow.ShowDialog(this);
		if (CommonStorage.iData > 0)
		{
			decimal value = CommonStorage.iData;
			numericUpDown_2.Value = value;
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private unsafe bool method_24(uint uint_0, out string string_0)
	{
		bool flag = default(bool);
		string path = eLC.PathData.GetPath(uint_0, &flag);
		string_0 = (flag ? path : null);
		GC.KeepAlive(this);
		return flag;
	}

	private void method_25()
	{
		if (IconsLoaded)
		{
			int selectedItem = SelectedItem;
			GSHOP_ITEM[] items = DataFiles.GShop.Items;
			smethod_1(pictureBox_1, method_22((uint)((GSHOP_ITEM_FW)items[selectedItem]).FileIcon));
		}
		GC.KeepAlive(this);
	}

	private void method_26()
	{
		if (!File.Exists(eLC.Params.ShopDescPath))
		{
			Descriptions = null;
		}
		else if ((Descriptions = new ITEM_EXT_DESC(eLC.Params.ShopDescPath)) != null)
		{
			DontChange = true;
			method_27();
			DontChange = false;
		}
	}

	private void method_27()
	{
		if (Descriptions != null)
		{
			int selectedItem = SelectedItem;
			GSHOP_ITEM[] items = DataFiles.GShop.Items;
			textBox_3.Text = Descriptions.Get(((GSHOP_ITEM_FW)items[selectedItem]).ID);
		}
		else
		{
			textBox_3.Text = string.Empty;
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_0_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
	{
		if (e.Column.Index != 3)
		{
			string empty = string.Empty;
			string oldValue = Class16.smethod_0(1648942211);
			string oldValue2 = Class16.smethod_0(1648928036);
			string oldValue3 = Class16.smethod_0(1648928028);
			int num = ACE.RSGlobal.RSGlobal.UIntParseFast(((string)e.CellValue1).Replace(oldValue3, empty).Replace(oldValue2, empty).Replace(oldValue, empty));
			string empty2 = string.Empty;
			string oldValue4 = Class16.smethod_0(1648942211);
			string oldValue5 = Class16.smethod_0(1648928036);
			string oldValue6 = Class16.smethod_0(1648928028);
			int num2 = ACE.RSGlobal.RSGlobal.UIntParseFast(((string)e.CellValue2).Replace(oldValue6, empty2).Replace(oldValue5, empty2).Replace(oldValue4, empty2));
			if (num > num2)
			{
				e.SortResult = 1;
			}
			else if (num < num2)
			{
				e.SortResult = -1;
			}
			else
			{
				e.SortResult = 0;
			}
			e.Handled = true;
		}
		GC.KeepAlive(this);
	}

	private void textBox_3_MouseLeave(object sender, EventArgs e)
	{
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void textBox_3_MouseMove(object sender, MouseEventArgs e)
	{
		string string_ = textBox_3.Text;
		method_28(string_);
	}

	private void dataGridView_0_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		timer_0.Enabled = false;
		bool_0 = true;
		RowIndexUnderCursor = e.RowIndex;
		timer_0.Enabled = true;
		GC.KeepAlive(this);
	}

	private void dataGridView_0_MouseLeave(object sender, EventArgs e)
	{
		bool_0 = false;
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_0_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		bool_0 = false;
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void method_28(string string_0)
	{
		if (LoadingComplete)
		{
			IntPtr handle = base.Handle;
			ItemsToolTip1.ShowToolTip(handle, string_0, 17.0, 2.0);
		}
		GC.KeepAlive(this);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		ITEM_EXT_DESC descriptions = Descriptions;
		if (descriptions != null && descriptions.Descriptions != null)
		{
			timer_0.Enabled = false;
			int rowIndexUnderCursor = RowIndexUnderCursor;
			if (rowIndexUnderCursor < 0)
			{
				return;
			}
			int num = (int)dataGridView_0.Rows[rowIndexUnderCursor].Tag;
			GSHOP_ITEM[] items = DataFiles.GShop.Items;
			string text = Descriptions.Get(items[num].ID);
			if (text != null && text != string.Empty && bool_0)
			{
				method_28(text);
			}
			else if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
			{
				HINTS.ToolTipWindow.SmoothHide();
			}
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_0_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		bool_0 = true;
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
					decimal value = numericUpDown_0.Value;
					ref int iD = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).ID;
					iD = (int)value;
					num++;
				}
				while (num < dataGridView_0.SelectedRows.Count);
			}
			method_14();
			method_30();
		}
		method_27();
		method_33();
		if (!DontChange)
		{
			method_2();
		}
	}

	private unsafe void numericUpDown_2_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
					decimal value = numericUpDown_2.Value;
					ref int fileIcon = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).FileIcon;
					fileIcon = (int)value;
					num++;
				}
				while (num < dataGridView_0.SelectedRows.Count);
			}
			method_14();
			method_30();
		}
		if (eLC.PathData != null)
		{
			uint id = (uint)numericUpDown_2.Value;
			bool flag = default(bool);
			string path = eLC.PathData.GetPath(id, &flag);
			textBox_4.Text = path;
		}
		method_25();
	}

	private void textBox_2_TextChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
					TextBox textBox = textBox_2;
					((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).sName = textBox.Text;
					num++;
				}
				while (num < dataGridView_0.SelectedRows.Count);
			}
			method_14();
			method_30();
		}
		if (!DontChange)
		{
			method_2();
		}
	}

	private void numericUpDown_1_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
					decimal value = numericUpDown_1.Value;
					ref int itemID = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).ItemID;
					itemID = (int)value;
					num++;
				}
				while (num < dataGridView_0.SelectedRows.Count);
			}
			method_14();
			method_30();
		}
		if (!DontChange)
		{
			method_2();
		}
		int selectedItem = SelectedItem;
		if (((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem]).ItemInfo != null)
		{
			int selectedItem2 = SelectedItem;
			GSHOP_ITEM[] items = DataFiles.GShop.Items;
			textBox_5.Text = ((GSHOP_ITEM_FW)items[selectedItem2]).ItemInfo.name;
			int selectedItem3 = SelectedItem;
			GSHOP_ITEM[] items2 = DataFiles.GShop.Items;
			textBox_5.ForeColor = ((GSHOP_ITEM_FW)items2[selectedItem3]).ItemInfo.color;
			int selectedItem4 = SelectedItem;
			GSHOP_ITEM[] items3 = DataFiles.GShop.Items;
			smethod_1(pictureBox_0, eLC.Icons.GetIcon(((GSHOP_ITEM_FW)items3[selectedItem4]).ItemInfo.IconName, IsTga: false));
		}
		else
		{
			pictureBox_0.Image = null;
			string text = Class16.smethod_0(1648924112);
			if (numericUpDown_1.Text == text)
			{
				string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648971625));
				textBox_5.Text = text2;
				Color white = Color.White;
				textBox_5.ForeColor = white;
			}
			else
			{
				string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
				textBox_5.Text = text3;
				Color red = Color.Red;
				textBox_5.ForeColor = red;
			}
		}
		GC.KeepAlive(this);
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				int canGetConsumeScore = (checkBox_1.Checked ? 1 : 0);
				((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).CanGetConsumeScore = (uint)canGetConsumeScore;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void numericUpDown_4_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				decimal value = numericUpDown_4.Value;
				ref int count = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).Count;
				count = (int)value;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void numericUpDown_3_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
					decimal value = numericUpDown_3.Value;
					((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).Price = (int)value;
					num++;
				}
				while (num < dataGridView_0.SelectedRows.Count);
			}
			method_14();
			method_30();
		}
		if (!DontChange)
		{
			method_2();
		}
	}

	private void numericUpDown_9_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
					decimal value = numericUpDown_9.Value;
					ref uint expireDate = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).ExpireDate;
					expireDate = (uint)(int)value;
					num++;
				}
				while (num < dataGridView_0.SelectedRows.Count);
			}
			method_14();
			method_30();
		}
		int selectedItem = SelectedItem;
		if (((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem]).ExpireDate != 0)
		{
			int selectedItem2 = SelectedItem;
			GSHOP_ITEM[] items = DataFiles.GShop.Items;
			NumericUpDown control = numericUpDown_9;
			toolTip_0.SetToolTip(control, CommonStorage.SecondsToString(((GSHOP_ITEM_FW)items[selectedItem2]).ExpireDate));
		}
		else
		{
			string caption = TextStorage.TEXTS.GetText(Class16.smethod_0(1648906540));
			toolTip_0.SetToolTip(numericUpDown_9, caption);
		}
		GC.KeepAlive(this);
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
					int isHide = (checkBox_0.Checked ? 1 : 0);
					((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).IsHide = (uint)isHide;
					num++;
				}
				while (num < dataGridView_0.SelectedRows.Count);
			}
			method_14();
			method_30();
		}
		if (!DontChange)
		{
			method_2();
		}
	}

	private void numericUpDown_6_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
					decimal value = numericUpDown_6.Value;
					ref int giftID = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).GiftID;
					giftID = (int)value;
					num++;
				}
				while (num < dataGridView_0.SelectedRows.Count);
			}
			method_14();
			method_30();
		}
		int selectedItem = SelectedItem;
		int giftID2 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem]).GiftID;
		eListCollection eListCollection2 = eLC;
		int[] mattersLists = eListCollection2.MattersLists;
		eListCollection eListCollection3 = eListCollection2;
		ITEMPOS itemPos = eListCollection3.FindItemPos(mattersLists, giftID2);
		ITEMINFO itemInfo = eListCollection3.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		if (itemInfo != null)
		{
			smethod_1(pictureBox_2, eLC.Icons.GetIcon(itemInfo.IconName, IsTga: false));
		}
		else
		{
			pictureBox_2.Image = null;
		}
		GC.KeepAlive(this);
	}

	private void numericUpDown_5_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				decimal value = numericUpDown_5.Value;
				ref float giftRate = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).GiftRate;
				giftRate = (float)value;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void dateTimePicker_1_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				DateTime value = dateTimePicker_1.Value;
				ref uint discountBeginTime = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).DiscountBeginTime;
				discountBeginTime = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(value);
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				DateTime value = dateTimePicker_0.Value;
				ref uint discountEndTime = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).DiscountEndTime;
				discountEndTime = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(value);
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void numericUpDown_8_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				decimal value = numericUpDown_8.Value;
				ref int discountPrice = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).DiscountPrice;
				discountPrice = (int)value;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void numericUpDown_10_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				decimal value = numericUpDown_10.Value;
				ref uint discountItemShowIndex = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).DiscountItemShowIndex;
				discountItemShowIndex = (uint)(int)value;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void dateTimePicker_3_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				DateTime value = dateTimePicker_3.Value;
				ref uint sellBeginTime = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).SellBeginTime;
				sellBeginTime = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(value);
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void dateTimePicker_2_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				DateTime value = dateTimePicker_2.Value;
				ref uint sellEndTime = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).SellEndTime;
				sellEndTime = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(value);
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void textBox_6_TextChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				TextBox textBox = textBox_6;
				((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).sExtSearch = textBox.Text;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedIndex == 0)
		{
			if (DontChange)
			{
				return;
			}
			int num = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
					((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).BuyTypeMask = 1u;
					num++;
				}
				while (num < dataGridView_0.SelectedRows.Count);
			}
			method_14();
			method_30();
		}
		else if (comboBox_0.SelectedIndex == 1)
		{
			if (DontChange)
			{
				return;
			}
			int num3 = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num4 = (int)dataGridView_0.SelectedRows[num3].Tag;
					((GSHOP_ITEM_FW)DataFiles.GShop.Items[num4]).BuyTypeMask = 8u;
					num3++;
				}
				while (num3 < dataGridView_0.SelectedRows.Count);
			}
			method_14();
			method_30();
		}
		else
		{
			if (DontChange)
			{
				return;
			}
			int num5 = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num6 = (int)dataGridView_0.SelectedRows[num5].Tag;
					((GSHOP_ITEM_FW)DataFiles.GShop.Items[num6]).BuyTypeMask = 9u;
					num5++;
				}
				while (num5 < dataGridView_0.SelectedRows.Count);
			}
			method_14();
			method_30();
		}
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				int selectedIndex = comboBox_1.SelectedIndex;
				((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).LogoIcon = selectedIndex;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void numericUpDown_12_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				decimal value = numericUpDown_12.Value;
				ref int priorityPreviewModel = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).PriorityPreviewModel;
				priorityPreviewModel = (int)value;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void numericUpDown_7_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				decimal value = numericUpDown_7.Value;
				ref uint newItemIndex = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).NewItemIndex;
				newItemIndex = (uint)(int)value;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void numericUpDown_13_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				decimal value = numericUpDown_13.Value;
				ref int previewBackgroundPic = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).PreviewBackgroundPic;
				previewBackgroundPic = (int)value;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void numericUpDown_11_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				decimal value = numericUpDown_11.Value;
				ref int previewPriority = ref ((GSHOP_ITEM_FW)DataFiles.GShop.Items[num2]).PreviewPriority;
				previewPriority = (int)value;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		method_14();
		method_30();
	}

	private void textBox_3_TextChanged(object sender, EventArgs e)
	{
		if (textBox_3.Focused)
		{
			string string_ = textBox_3.Text;
			method_28(string_);
		}
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridView_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
					TextBox textBox = textBox_3;
					int iD = DataFiles.GShop.Items[num2].ID;
					Descriptions.Change(iD, textBox.Text);
					num++;
				}
				while (num < dataGridView_0.SelectedRows.Count);
			}
		}
		method_30();
	}

	private void method_29()
	{
		dataGridView_0_SelectionChanged(null, null);
	}

	private void numericUpDown_2_DoubleClick(object sender, EventArgs e)
	{
		method_23();
	}

	private void textBox_4_DoubleClick(object sender, EventArgs e)
	{
		method_23();
	}

	private void numericUpDown_1_DoubleClick(object sender, EventArgs e)
	{
		decimal value = numericUpDown_1.Value;
		int num = method_31((int)value);
		if (num > 0)
		{
			decimal value2 = num;
			numericUpDown_1.Value = value2;
		}
		GC.KeepAlive(this);
	}

	private void numericUpDown_6_DoubleClick(object sender, EventArgs e)
	{
		decimal value = numericUpDown_6.Value;
		int num = method_31((int)value);
		if (num > 0)
		{
			decimal value2 = num;
			numericUpDown_6.Value = value2;
		}
		GC.KeepAlive(this);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		colorDialog_0.Color = color_0;
		if (colorDialog_0.ShowDialog(this) == DialogResult.OK)
		{
			string value = RSCommon.Color2ColorTag(colorDialog_0.Color);
			int selectionStart = textBox_3.SelectionStart;
			string text = textBox_3.Text;
			textBox_3.Text = text.Insert(textBox_3.SelectionStart, value);
			textBox_3.SelectionStart = selectionStart + 7;
			textBox_3.Focus();
			Color color = colorDialog_0.Color;
			color_0 = color;
		}
		GC.KeepAlive(this);
	}

	private void method_30()
	{
		if (DataFiles.GShop.FileLoaded)
		{
			object[] array = new object[1];
			int num = DataFiles.GShop.Items.Length;
			array[0] = num;
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649067057), array);
			toolStripStatusLabel_0.Text = text;
		}
		eListCollection eListCollection2 = eLC;
		byte b;
		if (eListCollection2 != null)
		{
			PATH_DATA pathData = eListCollection2.PathData;
			if (pathData != null && pathData.FileChanged)
			{
				b = 1;
				goto IL_0077;
			}
		}
		b = 0;
		goto IL_0077;
		IL_0077:
		toolStripStatusLabel_1.Visible = b != 0;
		ITEM_EXT_DESC descriptions = Descriptions;
		byte b2 = (byte)((descriptions != null && descriptions.FileChanged) ? 1u : 0u);
		toolStripStatusLabel_2.Visible = b2 != 0;
		ShopDirLua categories = Categories;
		byte b3 = (byte)((categories != null && categories.FileChanged) ? 1u : 0u);
		toolStripStatusLabel_3.Visible = b3 != 0;
		byte b4;
		if (!IsFileChanged)
		{
			PATH_DATA pathData2 = eLC.PathData;
			if (pathData2 == null || !pathData2.FileChanged)
			{
				ITEM_EXT_DESC descriptions2 = Descriptions;
				if (descriptions2 == null || !descriptions2.FileChanged)
				{
					ShopDirLua categories2 = Categories;
					if (categories2 == null || !categories2.FileChanged)
					{
						b4 = 0;
						goto IL_012c;
					}
				}
			}
		}
		b4 = 1;
		goto IL_012c;
		IL_012c:
		button_3.Enabled = b4 != 0;
		GC.KeepAlive(this);
	}

	private int method_31(int int_0)
	{
		eListCollection eListCollection2 = eLC;
		ITEMPOS iTEMPOS = eListCollection2.FindItemPos(eListCollection2.MattersLists, int_0);
		if (iTEMPOS != null)
		{
			ItemsWindow1.newitemlist = iTEMPOS.int_0;
			ItemsWindow1.newitemindex = iTEMPOS.int_1;
		}
		ItemsWindow1.newlistsindices = eLC.MattersLists;
		ItemsWindow1.bMultiSelect = false;
		CStorage.ResetBuffer();
		if (method_0(out var dialogResult_) && dialogResult_ == DialogResult.OK)
		{
			int result = Convert.ToInt32(CommonStorage.sData);
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return 0;
	}

	private void pictureBox_0_Click(object sender, EventArgs e)
	{
		decimal value = numericUpDown_1.Value;
		int num = method_31((int)value);
		if (num > 0)
		{
			decimal value2 = num;
			numericUpDown_1.Value = value2;
		}
		GC.KeepAlive(this);
	}

	private void pictureBox_2_Click(object sender, EventArgs e)
	{
		decimal value = numericUpDown_6.Value;
		int num = method_31((int)value);
		if (num > 0)
		{
			decimal value2 = num;
			numericUpDown_6.Value = value2;
		}
		GC.KeepAlive(this);
	}

	private void method_32()
	{
		try
		{
			if (eLC.Params.ShopdirLua != string.Empty && File.Exists(eLC.Params.ShopdirLua))
			{
				Categories = new ShopDirLua(eLC.Params.ShopdirLua);
			}
			method_33();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649067087));
			object[] array = new object[1];
			string text = Class16.smethod_0(1648941987);
			array[0] = string.Concat(ex.Message + text, ex.StackTrace);
			TextStorage.TEXTS.ShowMessage(387, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, array);
		}
		GC.KeepAlive(this);
	}

	private void method_33()
	{
		dataGridView_1.Rows.Clear();
		if (Categories == null)
		{
			return;
		}
		int selectedItem = SelectedItem;
		GSHOP_ITEM[] items = DataFiles.GShop.Items;
		List<ITEM_CATEGORY_POS> itemCategories = Categories.GetItemCategories(((GSHOP_ITEM_FW)items[selectedItem]).ID);
		int num = 0;
		if (0 < itemCategories.Count)
		{
			do
			{
				dataGridView_1.Rows.Add(method_34(itemCategories[num]));
				num++;
			}
			while (num < itemCategories.Count);
		}
		GC.KeepAlive(this);
	}

	private DataGridViewRow method_34(ITEM_CATEGORY_POS item_CATEGORY_POS_0)
	{
		DataGridViewRow dataGridViewRow = new DataGridViewRow();
		dataGridViewRow.Resizable = DataGridViewTriState.False;
		ShopDirLua categories = Categories;
		string text = ((1 > item_CATEGORY_POS_0.deep) ? string.Empty : categories.GetSubCat(item_CATEGORY_POS_0, 1).Name) + Class16.smethod_0(1649078775);
		if (item_CATEGORY_POS_0.pos2 > -1)
		{
			ShopDirLua categories2 = Categories;
			string text2 = ((2 > item_CATEGORY_POS_0.deep) ? string.Empty : categories2.GetSubCat(item_CATEGORY_POS_0, 2).Name);
			text = string.Concat(text, text2 + Class16.smethod_0(1649078775));
			if (item_CATEGORY_POS_0.pos3 > -1)
			{
				ShopDirLua categories3 = Categories;
				string text3 = ((3 > item_CATEGORY_POS_0.deep) ? string.Empty : categories3.GetSubCat(item_CATEGORY_POS_0, 3).Name);
				text = string.Concat(text, text3 + Class16.smethod_0(1649078775));
			}
		}
		object[] vars = new object[1] { item_CATEGORY_POS_0.item_pos + 1 };
		string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649067115), vars);
		int selectedItem = SelectedItem;
		GSHOP_ITEM[] items = DataFiles.GShop.Items;
		text = string.Concat(text, ((GSHOP_ITEM_FW)items[selectedItem]).sName + text4);
		dataGridViewRow.CreateCells(values: new object[1] { text }, dataGridView: dataGridView_1);
		dataGridViewRow.Tag = item_CATEGORY_POS_0;
		GC.KeepAlive(this);
		return dataGridViewRow;
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		method_11();
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		int selectedItem = SelectedItem;
		if (((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem]).ItemInfo != null)
		{
			IntPtr handle = ElementsWindow.Handle;
			int selectedItem2 = SelectedItem;
			ACE.RSGlobal.RSGlobal.SendMessage(handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_LIST, ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem2]).ItemInfo.pos.int_0, 0);
			int selectedItem3 = SelectedItem;
			int int_ = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem3]).ItemInfo.pos.int_1;
			IntPtr objectPointer = ACE.RSGlobal.RSGlobal.GetObjectPointer(new int[1] { int_ });
			IntPtr handle2 = ElementsWindow.Handle;
			int selectedItem4 = SelectedItem;
			int int_2 = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem4]).ItemInfo.pos.int_1;
			ACE.RSGlobal.RSGlobal.SendMessage(handle2, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_ITEMS, new int[1] { int_2 }.Length, objectPointer);
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		method_35();
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		int count = dataGridView_0.SelectedRows.Count;
		int[] array = new int[count];
		int num = 0;
		if (0 < count)
		{
			do
			{
				int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				array[num] = items[num2].ID;
				num++;
			}
			while (num < count);
		}
		Array.Sort(array);
		CategorySelector_FW categorySelector_FW = new CategorySelector_FW(CStorage, Categories, null, array);
		try
		{
			if (categorySelector_FW.ShowDialog(this) == DialogResult.OK)
			{
				method_33();
				method_30();
			}
		}
		finally
		{
			((IDisposable)categorySelector_FW).Dispose();
		}
	}

	private void toolStripMenuItem_5_Click(object sender, EventArgs e)
	{
		method_35();
	}

	private void toolStripMenuItem_6_Click(object sender, EventArgs e)
	{
		if (dataGridView_1.SelectedRows.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		ITEM_CATEGORY_POS iTEM_CATEGORY_POS = (ITEM_CATEGORY_POS)dataGridView_1.SelectedRows[0].Tag;
		iTEM_CATEGORY_POS.Category.DeleteItem(iTEM_CATEGORY_POS.item_pos);
		Categories.FileChanged = true;
		method_33();
		method_30();
	}

	private void method_35()
	{
		ITEM_CATEGORY_POS catPos = (ITEM_CATEGORY_POS)dataGridView_1.SelectedRows[0].Tag;
		int selectedItem = SelectedItem;
		int iD = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem]).ID;
		int[] iDs = new int[1] { iD };
		CategorySelector_FW categorySelector_FW = new CategorySelector_FW(CStorage, Categories, catPos, iDs);
		try
		{
			if (categorySelector_FW.ShowDialog(this) == DialogResult.OK)
			{
				method_33();
				method_30();
			}
		}
		finally
		{
			((IDisposable)categorySelector_FW).Dispose();
		}
	}

	private void contextMenuStrip_1_Opening(object sender, CancelEventArgs e)
	{
		byte b = ((Categories != null) ? ((byte)1) : ((byte)0));
		contextMenuStrip_1.Enabled = b != 0;
		if (Categories == null)
		{
			TextStorage.TEXTS.ShowErrorMessage(317);
			GC.KeepAlive(this);
			return;
		}
		ITEM_CATEGORY_POS iTEM_CATEGORY_POS = null;
		if (dataGridView_1.SelectedRows.Count != 0)
		{
			iTEM_CATEGORY_POS = (ITEM_CATEGORY_POS)dataGridView_1.SelectedRows[0].Tag;
		}
		byte b2 = ((iTEM_CATEGORY_POS != null) ? ((byte)1) : ((byte)0));
		toolStripMenuItem_5.Visible = b2 != 0;
		byte b3 = ((iTEM_CATEGORY_POS != null) ? ((byte)1) : ((byte)0));
		toolStripMenuItem_6.Visible = b3 != 0;
		byte b4 = ((iTEM_CATEGORY_POS != null) ? ((byte)1) : ((byte)0));
		toolStripSeparator_2.Visible = b4 != 0;
		GC.KeepAlive(this);
	}

	private int method_36(int int_0)
	{
		int num = 0;
		if (0 < dataGridView_0.RowCount)
		{
			do
			{
				if ((int)dataGridView_0.Rows[num].Tag != int_0)
				{
					num++;
					continue;
				}
				return num;
			}
			while (num < dataGridView_0.RowCount);
		}
		GC.KeepAlive(this);
		return -1;
	}

	private void toolStripMenuItem_7_Click(object sender, EventArgs e)
	{
		if (!bGShopOpened)
		{
			return;
		}
		int selectedItem = SelectedItem;
		int iD = ((GSHOP_ITEM_FW)DataFiles.GShop.Items[selectedItem]).ID;
		int[] iDs = new int[1] { iD };
		CategorySelector_FW categorySelector_FW = new CategorySelector_FW(CStorage, Categories, null, iDs);
		try
		{
			if (categorySelector_FW.ShowDialog(this) != DialogResult.OK)
			{
				GC.KeepAlive(this);
				return;
			}
			if (dataGridView_0.SelectedRows.Count > 1)
			{
				int selectedItem2 = SelectedItem;
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				List<ITEM_CATEGORY_POS> itemCategories = Categories.GetItemCategories(((GSHOP_ITEM_FW)items[selectedItem2]).ID);
				int num = 0;
				if (0 < dataGridView_0.SelectedRows.Count)
				{
					do
					{
						int num2 = (int)dataGridView_0.SelectedRows[num].Tag;
						int iD2 = DataFiles.GShop.Items[num2].ID;
						itemCategories[itemCategories.Count - 1].Category.AddItem(iD2);
						num++;
					}
					while (num < dataGridView_0.SelectedRows.Count);
				}
			}
			else
			{
				method_33();
			}
			method_30();
			TextStorage.TEXTS.ShowMessage(290, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		}
		finally
		{
			((IDisposable)categorySelector_FW).Dispose();
		}
		GC.KeepAlive(this);
	}

	private void GShopEditor_FW_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_GShopEditor_FW != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_GShopEditor_FW = CommonStorage.Texts.LangIndex;
		}
		ACE.Classes.Settings.ProductName = Class16.smethod_0(1649067138);
		if (DataFiles.GShop.FileLoaded && !bGShopOpened && LoadingComplete && dataGridView_0.RowCount == 0)
		{
			method_1();
			method_26();
			method_32();
			string fileName = DataFiles.GShop.FileName;
			textBox_1.Text = fileName;
			method_19();
			LoadingComplete = true;
			bGShopOpened = true;
			panel_0.Enabled = true;
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_8_Click(object sender, EventArgs e)
	{
		method_37();
	}

	private void toolStripMenuItem_9_Click(object sender, EventArgs e)
	{
		method_38();
	}

	private void method_37()
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		int[] array = new int[dataGridView_0.SelectedRows.Count];
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				array[num] = dataGridView_0.SelectedRows[num].Index;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		Array.Sort(array);
		if ((nint)array.LongLength == 1)
		{
			object[] vars = new object[1] { array[0] };
			string fileName = TextStorage.TEXTS.GetText(Class16.smethod_0(1649067153), vars);
			saveFileDialog.FileName = fileName;
		}
		else
		{
			object[] array2 = new object[2]
			{
				array[0],
				null
			};
			array2[1] = array[(nint)array.LongLength - 1];
			string fileName2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649067176), array2);
			saveFileDialog.FileName = fileName2;
		}
		saveFileDialog.Filter = Class16.smethod_0(1649067207);
		if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			string empty = string.Empty;
			if (saveFileDialog.FileName != empty)
			{
				EditorSessionTracker.LogFolderAccess(saveFileDialog.FileName, Class16.smethod_0(1649006856), Class16.smethod_0(1648906382));
				FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
				BinaryWriter binaryWriter = new BinaryWriter(fileStream);
				binaryWriter.Write(2);
				binaryWriter.Write((int)DataFiles.GShop.Game);
				binaryWriter.Write(DataFiles.GShop.Version);
				binaryWriter.Write(array.Length);
				int num2 = 0;
				if (0 < (nint)array.LongLength)
				{
					do
					{
						int num3 = array[num2];
						int version = DataFiles.GShop.Version;
						GSHOP_ITEM[] items = DataFiles.GShop.Items;
						GSHOP.WriteItem_FW(binaryWriter, (GSHOP_ITEM_FW)items[num3], 0, version);
						num2++;
					}
					while (num2 < (nint)array.LongLength);
				}
				binaryWriter.Close();
				fileStream.Close();
				TextStorage.TEXTS.ShowMessage(271, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			}
		}
		GC.KeepAlive(this);
	}

	private void method_38()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649067251);
		if (openFileDialog.ShowDialog(this) != DialogResult.OK || !File.Exists(openFileDialog.FileName))
		{
			return;
		}
		GSHOP gSHOP = new GSHOP(openFileDialog.FileName);
		ref GAMES game = ref DataFiles.GShop.Game;
		GAMES game2 = gSHOP.Game;
		if (game2 != game)
		{
			object[] vars = new object[1] { ACE.RSGlobal.RSGlobal.GetGamePrefix(game2) };
			TextStorage.TEXTS.ShowMessage(481, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
			GC.KeepAlive(this);
			return;
		}
		uint num = 0u;
		if (0 < gSHOP.ItemsCount)
		{
			do
			{
				GSHOP_ITEM_FW item = (GSHOP_ITEM_FW)gSHOP.Items[num];
				DataFiles.GShop.AddItem(item);
				int int_ = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
				dataGridView_0.Rows.Add(method_4(int_));
				num++;
			}
			while (num < gSHOP.ItemsCount);
		}
		DontChange = true;
		dataGridView_0.ClearSelection();
		DontChange = false;
		int rowIndex = dataGridView_0.RowCount - 1;
		dataGridView_0.CurrentCell = dataGridView_0[1, rowIndex];
		uint itemsCount = gSHOP.ItemsCount;
		int num2 = dataGridView_0.RowCount - (int)itemsCount;
		if (num2 < dataGridView_0.RowCount)
		{
			do
			{
				dataGridView_0.Rows[num2].Selected = true;
				num2++;
			}
			while (num2 < dataGridView_0.RowCount);
		}
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_2.Enabled = b != 0;
		method_14();
	}

	private void toolStripMenuItem_10_Click(object sender, EventArgs e)
	{
		int[] array = new int[dataGridView_0.SelectedRows.Count];
		int num = 0;
		if (0 < dataGridView_0.SelectedRows.Count)
		{
			do
			{
				array[num] = dataGridView_0.SelectedRows[num].Index;
				num++;
			}
			while (num < dataGridView_0.SelectedRows.Count);
		}
		Array.Sort(array);
		int num2 = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				int num3 = array[num2];
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				if (eLC.IsItemExist(items[num3].ItemInfo))
				{
					GSHOP_ITEM[] items2 = DataFiles.GShop.Items;
					method_39(items2[num3], bool_1: false);
				}
				num2++;
			}
			while (num2 < (nint)array.LongLength);
		}
		method_14();
		method_2();
	}

	private void method_39(GSHOP_ITEM gshop_ITEM_0, [MarshalAs(UnmanagedType.U1)] bool bool_1)
	{
		string text = gshop_ITEM_0.ItemInfo.name;
		if (bool_1)
		{
			int count = gshop_ITEM_0.Count;
			if (count > 1)
			{
				int num = count;
				if (text.Length + num.ToString().Length + 3 <= 32)
				{
					string text2 = Class16.smethod_0(1648942897);
					text = string.Concat(text, string.Concat(Class16.smethod_0(1648899468) + gshop_ITEM_0.Count, text2));
				}
			}
		}
		gshop_ITEM_0.sName = text;
		GC.KeepAlive(this);
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		method_41();
	}

	private void method_40(int[] int_0)
	{
		if (DataFiles.GShop.Items == null)
		{
			GC.KeepAlive(this);
			return;
		}
		int num = 0;
		if (0 < (nint)int_0.LongLength)
		{
			do
			{
				int itemID = int_0[num];
				DataFiles.GShop.AddNewItem(itemID);
				int id = int_0[num];
				eListCollection eListCollection2 = eLC;
				int[] mattersLists = eListCollection2.MattersLists;
				eListCollection eListCollection3 = eListCollection2;
				ITEMPOS itemPos = eListCollection3.FindItemPos(mattersLists, id);
				ITEMINFO itemInfo = eListCollection3.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
				int num2 = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
				DataFiles.GShop.Items[num2].ItemInfo = itemInfo;
				int num3 = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
				if (DataFiles.GShop.Items[num3].ItemInfo != null)
				{
					int num4 = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
					GSHOP_ITEM[] items = DataFiles.GShop.Items;
					method_39(items[num4], bool_1: true);
				}
				int int_1 = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
				dataGridView_0.Rows.Add(method_4(int_1));
				num++;
			}
			while (num < (nint)int_0.LongLength);
		}
		dataGridView_0.ClearSelection();
		int rowIndex = dataGridView_0.RowCount - 1;
		dataGridView_0.CurrentCell = dataGridView_0[1, rowIndex];
		int num5 = int_0.Length;
		int num6 = dataGridView_0.RowCount - num5;
		if (num6 < dataGridView_0.RowCount)
		{
			do
			{
				dataGridView_0.Rows[num6].Selected = true;
				num6++;
			}
			while (num6 < dataGridView_0.RowCount);
		}
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_2.Enabled = b != 0;
		byte b2 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		contextMenuStrip_0.Enabled = b2 != 0;
		byte b3 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		groupBox_0.Enabled = b3 != 0;
		method_14();
		toolStripMenuItem_4_Click(null, null);
	}

	private void method_41()
	{
		ItemsWindow1.newlistsindices = eLC.MattersLists;
		ItemsWindow1.bMultiSelect = true;
		CStorage.ResetBuffer();
		if (method_0(out var dialogResult_) && dialogResult_ == DialogResult.OK && CommonStorage.sarr1 != null)
		{
			method_40(ACE.RSGlobal.RSGlobal.StringArray2IntArray(CommonStorage.sarr1));
		}
		GC.KeepAlive(this);
	}
}
