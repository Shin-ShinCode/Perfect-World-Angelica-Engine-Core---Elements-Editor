using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.Models;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.ActionHistory;

public class ActionsHistoryViewer : Form
{
	public struct CachedText
	{
		public string lists;

		public string items;

		public string fields;

		public string names;
	}

	public ItemsToolTip ItemsToolTip1;

	public eListCollection eLC;

	public ACTION_HISTORY AHistory;

	public CommonStorage CStorage;

	public Form ElementsWindow;

	public int OwnerStageIndex;

	public int SelectedStageIndex;

	public int StagesCount;

	public CachedText Cached;

	private DataGridView dataGridView_0;

	private Panel panel_0;

	private GroupBox groupBox_0;

	private ToolTip toolTip_0;

	private Button button_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private GroupBox groupBox_1;

	private DateTimePicker dateTimePicker_0;

	private Label label_0;

	private DateTimePicker dateTimePicker_1;

	private Label label_1;

	private ComboBox comboBox_0;

	private GroupBox groupBox_2;

	private GroupBox groupBox_3;

	private GroupBox groupBox_4;

	private GroupBox groupBox_5;

	private DataGridView dataGridView_1;

	private TextBox textBox_0;

	private TableLayoutPanel tableLayoutPanel_1;

	private TextBox textBox_1;

	private Button button_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private TextBox textBox_4;

	private Button button_2;

	private Button button_3;

	private Button button_4;

	private Button button_5;

	private Button button_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private ImageList imageList_0;

	private Panel panel_1;

	private TextBox textBox_5;

	private Button button_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private TextBox textBox_6;

	private Button button_8;

	private Button button_9;

	private IContainer icontainer_0;

	public ActionsHistoryViewer(eListCollection eLC, CommonStorage CStorage, Form ElementsWindow, ItemsToolTip ItemsToolTip1)
	{
		try
		{
			method_1();
			this.eLC = eLC;
			AHistory = eLC.ActionsHistory;
			this.CStorage = CStorage;
			this.ElementsWindow = ElementsWindow;
			this.ItemsToolTip1 = ItemsToolTip1;
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			if (base.IsHandleCreated)
			{
				TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
			}
			TDark.ApplyNativeDarkThemeRecursive(this);
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			if (CommonStorage.License.Special.TrialFunctionsMask == 1L && !CommonStorage.License.Special.AHistoryViewer)
			{
				string text = Class16.smethod_0(1648929888);
				Text += text;
			}
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ActionsHistoryViewer));
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		panel_0 = new Panel();
		groupBox_1 = new GroupBox();
		panel_1 = new Panel();
		button_7 = new Button();
		textBox_5 = new TextBox();
		dateTimePicker_0 = new DateTimePicker();
		label_0 = new Label();
		dateTimePicker_1 = new DateTimePicker();
		label_1 = new Label();
		comboBox_0 = new ComboBox();
		tableLayoutPanel_0 = new TableLayoutPanel();
		groupBox_0 = new GroupBox();
		tableLayoutPanel_1 = new TableLayoutPanel();
		button_2 = new Button();
		button_3 = new Button();
		button_4 = new Button();
		button_5 = new Button();
		button_6 = new Button();
		textBox_1 = new TextBox();
		button_1 = new Button();
		dataGridView_1 = new DataGridView();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		groupBox_5 = new GroupBox();
		textBox_2 = new TextBox();
		groupBox_3 = new GroupBox();
		textBox_3 = new TextBox();
		groupBox_4 = new GroupBox();
		textBox_4 = new TextBox();
		groupBox_2 = new GroupBox();
		textBox_0 = new TextBox();
		textBox_6 = new TextBox();
		button_0 = new Button();
		button_8 = new Button();
		button_9 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		imageList_0 = new ImageList(icontainer_0);
		((ISupportInitialize)dataGridView_0).BeginInit();
		panel_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		panel_1.SuspendLayout();
		tableLayoutPanel_0.SuspendLayout();
		groupBox_0.SuspendLayout();
		tableLayoutPanel_1.SuspendLayout();
		((ISupportInitialize)dataGridView_1).BeginInit();
		groupBox_5.SuspendLayout();
		groupBox_3.SuspendLayout();
		groupBox_4.SuspendLayout();
		groupBox_2.SuspendLayout();
		SuspendLayout();
		dataGridView_0.AllowDrop = true;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.BackgroundColor = Color.White;
		dataGridView_0.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_0.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1, dataGridViewImageColumn_0, dataGridViewTextBoxColumn_2);
		dataGridView_0.Dock = DockStyle.Fill;
		dataGridView_0.EditMode = DataGridViewEditMode.EditProgrammatically;
		dataGridView_0.GridColor = Color.Silver;
		dataGridView_0.Location = new Point(3, 4);
		dataGridView_0.Margin = new Padding(3, 4, 3, 4);
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1648929911);
		dataGridView_0.ReadOnly = true;
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1648929920), 9f);
		dataGridView_0.RowsDefaultCellStyle = dataGridViewCellStyle2;
		dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellToolTips = false;
		dataGridView_0.Size = new Size(449, 547);
		dataGridView_0.TabIndex = 0;
		dataGridView_0.CellDoubleClick += dataGridView_0_CellDoubleClick;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle3.ForeColor = Color.Gray;
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle3;
		dataGridViewTextBoxColumn_0.Frozen = true;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648929947);
		dataGridViewTextBoxColumn_0.MinimumWidth = 6;
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648929955);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.Width = 46;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle4.Font = new Font(Class16.smethod_0(1648929975), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648929990);
		dataGridViewTextBoxColumn_1.MinimumWidth = 6;
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648929993);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.Width = 125;
		dataGridViewImageColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewImageColumn_0.HeaderText = string.Empty;
		dataGridViewImageColumn_0.MinimumWidth = 6;
		dataGridViewImageColumn_0.Name = Class16.smethod_0(1648930015);
		dataGridViewImageColumn_0.ReadOnly = true;
		dataGridViewImageColumn_0.Resizable = DataGridViewTriState.False;
		dataGridViewImageColumn_0.Width = 20;
		dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle5.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle5;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648930017);
		dataGridViewTextBoxColumn_2.MinimumWidth = 6;
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648930038);
		dataGridViewTextBoxColumn_2.ReadOnly = true;
		dataGridViewTextBoxColumn_2.Resizable = DataGridViewTriState.True;
		panel_0.Controls.Add(groupBox_1);
		panel_0.Controls.Add(tableLayoutPanel_0);
		panel_0.Controls.Add(groupBox_0);
		panel_0.Controls.Add(button_0);
		panel_0.Dock = DockStyle.Fill;
		panel_0.Location = new Point(0, 0);
		panel_0.Name = Class16.smethod_0(1648930054);
		panel_0.Size = new Size(1174, 561);
		panel_0.TabIndex = 81;
		groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		groupBox_1.Controls.Add(panel_1);
		groupBox_1.Controls.Add(dateTimePicker_0);
		groupBox_1.Controls.Add(label_0);
		groupBox_1.Controls.Add(dateTimePicker_1);
		groupBox_1.Controls.Add(label_1);
		groupBox_1.Controls.Add(comboBox_0);
		groupBox_1.Location = new Point(464, 3);
		groupBox_1.Name = Class16.smethod_0(1648930068);
		groupBox_1.Size = new Size(702, 52);
		groupBox_1.TabIndex = 83;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1648930074);
		panel_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		panel_1.Controls.Add(button_7);
		panel_1.Controls.Add(textBox_5);
		panel_1.Location = new Point(172, 15);
		panel_1.Name = Class16.smethod_0(1648930100);
		panel_1.Size = new Size(523, 33);
		panel_1.TabIndex = 147;
		panel_1.Visible = false;
		button_7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_7.Image = Resources.cmdBack;
		button_7.Location = new Point(2, 5);
		button_7.Name = Class16.smethod_0(1648930112);
		button_7.Size = new Size(33, 25);
		button_7.TabIndex = 36;
		button_7.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_0.SetToolTip(button_7, Class16.smethod_0(1648930134));
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		textBox_5.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		textBox_5.Location = new Point(39, 5);
		textBox_5.Name = Class16.smethod_0(1648930155);
		textBox_5.ReadOnly = true;
		textBox_5.Size = new Size(478, 29);
		textBox_5.TabIndex = 1;
		textBox_5.TextAlign = HorizontalAlignment.Center;
		dateTimePicker_0.Enabled = false;
		dateTimePicker_0.Location = new Point(490, 21);
		dateTimePicker_0.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		dateTimePicker_0.MinDate = new DateTime(2016, 5, 1, 0, 0, 0, 0);
		dateTimePicker_0.Name = Class16.smethod_0(1648930189);
		dateTimePicker_0.Size = new Size(202, 25);
		dateTimePicker_0.TabIndex = 146;
		dateTimePicker_0.Value = new DateTime(2016, 6, 2, 0, 0, 0, 0);
		dateTimePicker_0.ValueChanged += dateTimePicker_0_ValueChanged;
		label_0.Location = new Point(452, 22);
		label_0.Name = Class16.smethod_0(1648930206);
		label_0.Size = new Size(29, 16);
		label_0.TabIndex = 145;
		label_0.Text = Class16.smethod_0(1648930211);
		label_0.TextAlign = ContentAlignment.MiddleRight;
		dateTimePicker_1.Enabled = false;
		dateTimePicker_1.Location = new Point(244, 20);
		dateTimePicker_1.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		dateTimePicker_1.MinDate = new DateTime(2016, 5, 1, 0, 0, 0, 0);
		dateTimePicker_1.Name = Class16.smethod_0(1648930229);
		dateTimePicker_1.Size = new Size(202, 25);
		dateTimePicker_1.TabIndex = 144;
		dateTimePicker_1.Value = new DateTime(2016, 6, 1, 0, 0, 0, 0);
		dateTimePicker_1.ValueChanged += dateTimePicker_1_ValueChanged;
		label_1.Location = new Point(172, 22);
		label_1.Name = Class16.smethod_0(1648930240);
		label_1.Size = new Size(70, 16);
		label_1.TabIndex = 143;
		label_1.Text = Class16.smethod_0(1648930261);
		label_1.TextAlign = ContentAlignment.MiddleRight;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[6]
		{
			Class16.smethod_0(1648930265),
			Class16.smethod_0(1648930285),
			Class16.smethod_0(1648941218),
			Class16.smethod_0(1648930288),
			Class16.smethod_0(1648929287),
			Class16.smethod_0(1648929301)
		});
		comboBox_0.Location = new Point(9, 21);
		comboBox_0.Name = Class16.smethod_0(1648929318);
		comboBox_0.Size = new Size(157, 25);
		comboBox_0.TabIndex = 142;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		tableLayoutPanel_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tableLayoutPanel_0.ColumnCount = 1;
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel_0.Controls.Add(dataGridView_0, 0, 0);
		tableLayoutPanel_0.Location = new Point(3, 3);
		tableLayoutPanel_0.Name = Class16.smethod_0(1648929329);
		tableLayoutPanel_0.RowCount = 1;
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_0.Size = new Size(455, 555);
		tableLayoutPanel_0.TabIndex = 113;
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		groupBox_0.BackColor = Color.FromArgb(239, 244, 250);
		groupBox_0.Controls.Add(tableLayoutPanel_1);
		groupBox_0.Controls.Add(dataGridView_1);
		groupBox_0.Controls.Add(groupBox_5);
		groupBox_0.Controls.Add(groupBox_3);
		groupBox_0.Controls.Add(groupBox_4);
		groupBox_0.Controls.Add(groupBox_2);
		groupBox_0.Controls.Add(textBox_6);
		groupBox_0.Location = new Point(464, 57);
		groupBox_0.Name = Class16.smethod_0(1648929344);
		groupBox_0.Size = new Size(702, 497);
		groupBox_0.TabIndex = 73;
		groupBox_0.TabStop = false;
		tableLayoutPanel_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		tableLayoutPanel_1.ColumnCount = 3;
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33332f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334f));
		tableLayoutPanel_1.Controls.Add(button_2, 0, 2);
		tableLayoutPanel_1.Controls.Add(button_3, 1, 2);
		tableLayoutPanel_1.Controls.Add(button_4, 2, 2);
		tableLayoutPanel_1.Controls.Add(button_5, 1, 1);
		tableLayoutPanel_1.Controls.Add(button_6, 2, 1);
		tableLayoutPanel_1.Controls.Add(textBox_1, 0, 0);
		tableLayoutPanel_1.Controls.Add(button_1, 0, 1);
		tableLayoutPanel_1.Controls.Add(button_8, 0, 3);
		tableLayoutPanel_1.Controls.Add(button_9, 1, 3);
		tableLayoutPanel_1.Location = new Point(6, 372);
		tableLayoutPanel_1.Name = Class16.smethod_0(1648929366);
		tableLayoutPanel_1.RowCount = 4;
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
		tableLayoutPanel_1.Size = new Size(692, 120);
		tableLayoutPanel_1.TabIndex = 6;
		button_2.Dock = DockStyle.Fill;
		button_2.Location = new Point(3, 63);
		button_2.Name = Class16.smethod_0(1648929390);
		button_2.Size = new Size(224, 25);
		button_2.TabIndex = 8;
		button_2.Text = Class16.smethod_0(1648929404);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Dock = DockStyle.Fill;
		button_3.Enabled = false;
		button_3.Location = new Point(233, 63);
		button_3.Name = Class16.smethod_0(1648929426);
		button_3.Size = new Size(224, 25);
		button_3.TabIndex = 7;
		button_3.Text = Class16.smethod_0(1648929450);
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		button_4.Dock = DockStyle.Fill;
		button_4.Location = new Point(463, 63);
		button_4.Name = Class16.smethod_0(1648929472);
		button_4.Size = new Size(226, 25);
		button_4.TabIndex = 6;
		button_4.Text = Class16.smethod_0(1648929500);
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		button_5.Dock = DockStyle.Fill;
		button_5.Enabled = false;
		button_5.Location = new Point(233, 33);
		button_5.Name = Class16.smethod_0(1648929525);
		button_5.Size = new Size(224, 24);
		button_5.TabIndex = 5;
		button_5.Text = Class16.smethod_0(1648929537);
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		button_6.Dock = DockStyle.Fill;
		button_6.Location = new Point(463, 33);
		button_6.Name = Class16.smethod_0(1648929555);
		button_6.Size = new Size(226, 24);
		button_6.TabIndex = 4;
		button_6.Text = Class16.smethod_0(1648929583);
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		tableLayoutPanel_1.SetColumnSpan(textBox_1, 3);
		textBox_1.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		textBox_1.Location = new Point(3, 3);
		textBox_1.Name = Class16.smethod_0(1648929606);
		textBox_1.ReadOnly = true;
		textBox_1.Size = new Size(686, 26);
		textBox_1.TabIndex = 2;
		textBox_1.TextAlign = HorizontalAlignment.Center;
		button_1.Dock = DockStyle.Fill;
		button_1.Location = new Point(3, 33);
		button_1.Name = Class16.smethod_0(1648929618);
		button_1.Size = new Size(224, 24);
		button_1.TabIndex = 3;
		button_1.Text = Class16.smethod_0(1648929632);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_8.Dock = DockStyle.Fill;
		button_8.Location = new Point(3, 93);
		button_8.Name = Class16.smethod_0(1648929671);
		button_8.Size = new Size(224, 24);
		button_8.TabIndex = 9;
		button_8.Text = Class16.smethod_0(1648929693);
		button_8.UseVisualStyleBackColor = true;
		button_8.Click += button_8_Click;
		button_9.Dock = DockStyle.Fill;
		button_9.Location = new Point(233, 93);
		button_9.Name = Class16.smethod_0(1648929714);
		button_9.Size = new Size(224, 24);
		button_9.TabIndex = 10;
		button_9.Text = Class16.smethod_0(1648929736);
		button_9.UseVisualStyleBackColor = true;
		button_9.Click += button_9_Click;
		dataGridView_1.AllowDrop = true;
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToDeleteRows = false;
		dataGridView_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dataGridView_1.BackgroundColor = Color.White;
		dataGridView_1.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_1.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridView_1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_1.Columns.AddRange(dataGridViewTextBoxColumn_3, dataGridViewTextBoxColumn_4, dataGridViewTextBoxColumn_5, dataGridViewTextBoxColumn_6);
		dataGridView_1.EditMode = DataGridViewEditMode.EditProgrammatically;
		dataGridView_1.GridColor = Color.Silver;
		dataGridView_1.Location = new Point(6, 303);
		dataGridView_1.Margin = new Padding(3, 4, 3, 4);
		dataGridView_1.Name = Class16.smethod_0(1648929760);
		dataGridView_1.ReadOnly = true;
		dataGridView_1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle6.BackColor = SystemColors.Control;
		dataGridViewCellStyle6.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
		dataGridView_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
		dataGridView_1.RowHeadersVisible = false;
		dataGridView_1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle7.Font = new Font(Class16.smethod_0(1648929920), 9f);
		dataGridView_1.RowsDefaultCellStyle = dataGridViewCellStyle7;
		dataGridView_1.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_1.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_1.ShowCellToolTips = false;
		dataGridView_1.Size = new Size(692, 65);
		dataGridView_1.TabIndex = 5;
		toolTip_0.SetToolTip(dataGridView_1, Class16.smethod_0(1648929776));
		dataGridView_1.CellDoubleClick += dataGridView_1_CellDoubleClick;
		dataGridView_1.CellMouseMove += dataGridView_1_CellMouseMove;
		dataGridView_1.MouseLeave += dataGridView_1_MouseLeave;
		dataGridViewCellStyle8.ForeColor = Color.Gray;
		dataGridViewTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle8;
		dataGridViewTextBoxColumn_3.Frozen = true;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_3.MinimumWidth = 6;
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1648928792);
		dataGridViewTextBoxColumn_3.ReadOnly = true;
		dataGridViewTextBoxColumn_3.Width = 50;
		dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewTextBoxColumn_4.Frozen = true;
		dataGridViewTextBoxColumn_4.HeaderText = Class16.smethod_0(1648928808);
		dataGridViewTextBoxColumn_4.MinimumWidth = 6;
		dataGridViewTextBoxColumn_4.Name = Class16.smethod_0(1648928828);
		dataGridViewTextBoxColumn_4.ReadOnly = true;
		dataGridViewTextBoxColumn_4.Width = 150;
		dataGridViewTextBoxColumn_5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_5.HeaderText = Class16.smethod_0(1648928835);
		dataGridViewTextBoxColumn_5.MinimumWidth = 6;
		dataGridViewTextBoxColumn_5.Name = Class16.smethod_0(1648928851);
		dataGridViewTextBoxColumn_5.ReadOnly = true;
		dataGridViewTextBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle9.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewTextBoxColumn_6.DefaultCellStyle = dataGridViewCellStyle9;
		dataGridViewTextBoxColumn_6.HeaderText = Class16.smethod_0(1648928877);
		dataGridViewTextBoxColumn_6.MinimumWidth = 6;
		dataGridViewTextBoxColumn_6.Name = Class16.smethod_0(1648928893);
		dataGridViewTextBoxColumn_6.ReadOnly = true;
		dataGridViewTextBoxColumn_6.Resizable = DataGridViewTriState.True;
		groupBox_5.Controls.Add(textBox_2);
		groupBox_5.Location = new Point(6, 229);
		groupBox_5.Name = Class16.smethod_0(1648928911);
		groupBox_5.Size = new Size(690, 70);
		groupBox_5.TabIndex = 4;
		groupBox_5.TabStop = false;
		groupBox_5.Text = Class16.smethod_0(1648928927);
		textBox_2.Dock = DockStyle.Fill;
		textBox_2.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_2.Location = new Point(3, 21);
		textBox_2.MaxLength = 1000000;
		textBox_2.Multiline = true;
		textBox_2.Name = Class16.smethod_0(1648928945);
		textBox_2.ReadOnly = true;
		textBox_2.ScrollBars = ScrollBars.Vertical;
		textBox_2.Size = new Size(684, 46);
		textBox_2.TabIndex = 3;
		textBox_2.TextAlign = HorizontalAlignment.Center;
		textBox_2.MouseLeave += textBox_2_MouseLeave;
		textBox_2.MouseMove += textBox_2_MouseMove;
		groupBox_3.Controls.Add(textBox_3);
		groupBox_3.Location = new Point(6, 158);
		groupBox_3.Name = Class16.smethod_0(1648928966);
		groupBox_3.Size = new Size(690, 65);
		groupBox_3.TabIndex = 3;
		groupBox_3.TabStop = false;
		groupBox_3.Text = Class16.smethod_0(1648928982);
		textBox_3.Dock = DockStyle.Fill;
		textBox_3.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_3.Location = new Point(3, 21);
		textBox_3.MaxLength = 1000000;
		textBox_3.Multiline = true;
		textBox_3.Name = Class16.smethod_0(1648929021);
		textBox_3.ReadOnly = true;
		textBox_3.ScrollBars = ScrollBars.Vertical;
		textBox_3.Size = new Size(684, 41);
		textBox_3.TabIndex = 3;
		textBox_3.TextAlign = HorizontalAlignment.Center;
		textBox_3.MouseLeave += textBox_3_MouseLeave;
		textBox_3.MouseMove += textBox_3_MouseMove;
		groupBox_4.Controls.Add(textBox_4);
		groupBox_4.Location = new Point(6, 96);
		groupBox_4.Name = Class16.smethod_0(1648929037);
		groupBox_4.Size = new Size(690, 59);
		groupBox_4.TabIndex = 2;
		groupBox_4.TabStop = false;
		groupBox_4.Text = Class16.smethod_0(1648929053);
		textBox_4.Dock = DockStyle.Fill;
		textBox_4.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_4.Location = new Point(3, 21);
		textBox_4.MaxLength = 1000000;
		textBox_4.Multiline = true;
		textBox_4.Name = Class16.smethod_0(1648929111);
		textBox_4.ReadOnly = true;
		textBox_4.ScrollBars = ScrollBars.Vertical;
		textBox_4.Size = new Size(684, 35);
		textBox_4.TabIndex = 2;
		textBox_4.TextAlign = HorizontalAlignment.Center;
		textBox_4.MouseLeave += textBox_4_MouseLeave;
		textBox_4.MouseMove += textBox_4_MouseMove;
		groupBox_2.Controls.Add(textBox_0);
		groupBox_2.Location = new Point(6, 47);
		groupBox_2.Name = Class16.smethod_0(1648929126);
		groupBox_2.Size = new Size(690, 43);
		groupBox_2.TabIndex = 1;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1648929142);
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_0.Location = new Point(3, 15);
		textBox_0.Name = Class16.smethod_0(1648929153);
		textBox_0.ReadOnly = true;
		textBox_0.Size = new Size(684, 26);
		textBox_0.TabIndex = 1;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		textBox_6.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		textBox_6.Location = new Point(6, 16);
		textBox_6.Name = Class16.smethod_0(1648929168);
		textBox_6.ReadOnly = true;
		textBox_6.Size = new Size(690, 29);
		textBox_6.TabIndex = 0;
		textBox_6.TextAlign = HorizontalAlignment.Center;
		button_0.Location = new Point(231, 307);
		button_0.Name = Class16.smethod_0(1648929185);
		button_0.Size = new Size(75, 23);
		button_0.TabIndex = 83;
		button_0.Text = Class16.smethod_0(1648929202);
		button_0.UseVisualStyleBackColor = true;
		imageList_0.ImageStream = (ImageListStreamer)componentResourceManager.GetObject(Class16.smethod_0(1648929216));
		imageList_0.TransparentColor = Color.Transparent;
		imageList_0.Images.SetKeyName(0, Class16.smethod_0(1648929253));
		imageList_0.Images.SetKeyName(1, Class16.smethod_0(1648932175));
		imageList_0.Images.SetKeyName(2, Class16.smethod_0(1648929269));
		imageList_0.Images.SetKeyName(3, Class16.smethod_0(1648929279));
		imageList_0.Images.SetKeyName(4, Class16.smethod_0(1648924172));
		imageList_0.Images.SetKeyName(5, Class16.smethod_0(1648924177));
		imageList_0.Images.SetKeyName(6, Class16.smethod_0(1648924195));
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(7f, 17f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(1174, 561);
		base.Controls.Add(panel_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.Icon = Resources.ActionsHistoryViewer_Icon;
		base.KeyPreview = true;
		base.Margin = new Padding(3, 4, 3, 4);
		MinimumSize = new Size(800, 600);
		base.Name = Class16.smethod_0(1648924215);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648924234);
		base.FormClosing += ActionsHistoryViewer_FormClosing;
		base.Shown += ActionsHistoryViewer_Shown;
		((ISupportInitialize)dataGridView_0).EndInit();
		panel_0.ResumeLayout(performLayout: false);
		groupBox_1.ResumeLayout(performLayout: false);
		panel_1.ResumeLayout(performLayout: false);
		panel_1.PerformLayout();
		tableLayoutPanel_0.ResumeLayout(performLayout: false);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		tableLayoutPanel_1.ResumeLayout(performLayout: false);
		tableLayoutPanel_1.PerformLayout();
		((ISupportInitialize)dataGridView_1).EndInit();
		groupBox_5.ResumeLayout(performLayout: false);
		groupBox_5.PerformLayout();
		groupBox_3.ResumeLayout(performLayout: false);
		groupBox_3.PerformLayout();
		groupBox_4.ResumeLayout(performLayout: false);
		groupBox_4.PerformLayout();
		groupBox_2.ResumeLayout(performLayout: false);
		groupBox_2.PerformLayout();
		ResumeLayout(performLayout: false);
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

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		textBox_0.Text = string.Empty;
		textBox_6.Text = string.Empty;
		textBox_4.Text = string.Empty;
		textBox_3.Text = string.Empty;
		textBox_2.Text = string.Empty;
		textBox_1.Text = string.Empty;
		button_5.Enabled = false;
		button_3.Enabled = false;
		button_2.Enabled = false;
		button_1.Enabled = false;
		dataGridView_1.Rows.Clear();
		Cached = default(CachedText);
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924309));
		int num;
		HISTORYSTAGE hISTORYSTAGE;
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			groupBox_0.Enabled = true;
			num = (SelectedStageIndex = (int)dataGridView_0.SelectedRows[0].Tag);
			if (comboBox_0.SelectedIndex == 5)
			{
				hISTORYSTAGE = AHistory[OwnerStageIndex].SubStages[num];
				textBox_6.Text = AHistory.GetCaption(OwnerStageIndex, num, bSetDate: true);
				goto IL_01ef;
			}
			if (num > 0 || AHistory.CurrentStageIndex > -1)
			{
				button_1.Enabled = true;
			}
			if (num >= AHistory.History.Count - 1)
			{
				int num2 = AHistory.History.Count - 1;
				if (AHistory.CurrentStageIndex >= num2)
				{
					goto IL_01c5;
				}
			}
			button_2.Enabled = true;
			goto IL_01c5;
		}
		groupBox_0.Enabled = false;
		goto IL_0a73;
		IL_01c5:
		hISTORYSTAGE = AHistory[num];
		string caption = AHistory.GetCaption(num, -1, bSetDate: true);
		textBox_6.Text = caption;
		goto IL_01ef;
		IL_01ef:
		List<string> list = new List<string>();
		switch (hISTORYSTAGE.action)
		{
		case (AH_ACTIONS)8:
			button_3.Enabled = true;
			caption = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924332));
			textBox_0.Text = caption;
			break;
		default:
		{
			int[] listsindices = hISTORYSTAGE.listsindices;
			if (listsindices == null && hISTORYSTAGE.int_0 <= -1)
			{
				break;
			}
			int int_ = hISTORYSTAGE.int_0;
			if (listsindices != null)
			{
				caption = Class16.smethod_0(1648942920);
				textBox_0.Text = string.Join(caption, ACE.RSGlobal.RSGlobal.IntArray2StringArray(listsindices));
			}
			else
			{
				caption = eLC.Lists[int_].ListName;
				string text8 = Class16.smethod_0(1648924347);
				textBox_0.Text = string.Concat(string.Concat(Class16.smethod_0(1648924364) + int_, text8), caption);
			}
			listsindices = hISTORYSTAGE.itemsindices;
			if (listsindices == null)
			{
				break;
			}
			int num7 = listsindices[0];
			if ((nint)listsindices.LongLength == 1 && eLC.IsItemExist(new ITEMPOS(int_, num7)))
			{
				string parsedItemName = eLC.GetParsedItemName(int_, num7, bRealAddonName: true);
				caption = Class16.smethod_0(1648924347);
				textBox_4.Text = string.Concat(string.Concat(Class16.smethod_0(1648924364) + num7, caption), parsedItemName);
			}
			else
			{
				textBox_4.Text = string.Join(Class16.smethod_0(1648942920), ACE.RSGlobal.RSGlobal.IntArray2StringArray(hISTORYSTAGE.itemsindices));
			}
			int int_2;
			int[] fieldsindices;
			if (hISTORYSTAGE.fieldsindices != null)
			{
				dataGridViewTextBoxColumn_4.Width = 150;
				fieldsindices = hISTORYSTAGE.fieldsindices;
				int_2 = fieldsindices[0];
				if ((nint)fieldsindices.LongLength == 1)
				{
					eListCollection eListCollection5 = eLC;
					string text9 = Class16.smethod_0(1648924347);
					textBox_3.Text = string.Concat(string.Concat(Class16.smethod_0(1648924364) + int_2, text9), eListCollection5.GetFieldName(int_, int_2));
				}
				else
				{
					textBox_3.Text = string.Join(Class16.smethod_0(1648942920), ACE.RSGlobal.RSGlobal.IntArray2StringArray(fieldsindices));
				}
			}
			int_2 = 0;
			fieldsindices = hISTORYSTAGE.itemsindices;
			string separator;
			if (0 < (nint)fieldsindices.LongLength)
			{
				do
				{
					int num8 = fieldsindices[int_2];
					string text10 = text;
					ITEMPOS iTEMPOS3 = new ITEMPOS(int_, num8);
					if (eLC.IsItemExist(iTEMPOS3))
					{
						text10 = eLC.GetItemID(iTEMPOS3);
						ITEMINFO itemInfo2 = eLC.GetItemInfo(iTEMPOS3, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
						int num9 = num8;
						string name2 = itemInfo2.name;
						string text11 = Class16.smethod_0(1648924347);
						string text12 = Class16.smethod_0(1648924364);
						list.Add(string.Concat(string.Concat(string.Concat(RSCommon.Color2ColorTag(itemInfo2.color) + text12, num9.ToString()), text11), name2));
					}
					else
					{
						int num10 = num8;
						string text13 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
						string text14 = Class16.smethod_0(1648924347);
						list.Add(string.Concat(string.Concat(Class16.smethod_0(1648924387) + num10, text14), text13));
						iTEMPOS3 = null;
					}
					if (hISTORYSTAGE.fieldsindices != null)
					{
						List<string> list2 = new List<string>();
						int num11 = 0;
						int[] fieldsindices2 = hISTORYSTAGE.fieldsindices;
						if (0 < (nint)fieldsindices2.LongLength)
						{
							do
							{
								int num12 = fieldsindices2[num11];
								string fieldName = eLC.GetFieldName(int_, num12);
								string value = eList.GetValue(hISTORYSTAGE.values_old[int_2][num11], eLC.Lists[int_].elementTypes[num12], roundTrip: false);
								string text15 = value;
								object[][] values_new = hISTORYSTAGE.values_new;
								if (values_new != null)
								{
									text15 = eList.GetValue(values_new[int_2][num11], eLC.Lists[int_].elementTypes[num12], roundTrip: false);
								}
								object[] values = new object[4]
								{
									text10,
									fieldName + Class16.smethod_0(1648924402),
									value,
									text15
								};
								dataGridView_1.Rows.Add(values);
								int index2;
								if (iTEMPOS3 != null)
								{
									index2 = dataGridView_1.RowCount - 1;
									dataGridView_1.Rows[index2].Tag = iTEMPOS3;
								}
								index2 = dataGridView_1.RowCount - 1;
								dataGridView_1[1, index2].Tag = num12;
								if (Cached.fields == null && list2.Count < 40)
								{
									int num13 = num12;
									string text16 = Class16.smethod_0(1648924347);
									list2.Add(string.Concat(string.Concat(Class16.smethod_0(1648924364) + num13, text16), fieldName));
								}
								else if (list2.Count == 40)
								{
									list2.Add(Class16.smethod_0(1648924410));
								}
								num11++;
								fieldsindices2 = hISTORYSTAGE.fieldsindices;
							}
							while (num11 < (nint)fieldsindices2.LongLength);
						}
						separator = Class16.smethod_0(1648924428);
						Cached.fields = string.Join(separator, list2.ToArray());
					}
					int_2++;
					fieldsindices = hISTORYSTAGE.itemsindices;
				}
				while (int_2 < (nint)fieldsindices.LongLength);
			}
			separator = Class16.smethod_0(1648924428);
			Cached.names = string.Join(separator, list.ToArray());
			break;
		}
		case (AH_ACTIONS)6:
		case (AH_ACTIONS)7:
		{
			dataGridViewTextBoxColumn_4.Width = 0;
			int id = hISTORYSTAGE.IDs[0];
			eListCollection eListCollection2 = eLC;
			ITEMPOS iTEMPOS = eListCollection2.FindItemPos(eListCollection2.GetLists(ItemType.Matter), id);
			if ((nint)hISTORYSTAGE.IDs.LongLength == 1 && eLC.IsItemExist(iTEMPOS))
			{
				eListCollection eListCollection3 = eLC;
				string text2 = Class16.smethod_0(1648924347);
				id = hISTORYSTAGE.IDs[0];
				textBox_2.Text = string.Concat(string.Concat(Class16.smethod_0(1648924364) + id, text2), eListCollection3.GetParsedItemName(iTEMPOS));
			}
			else
			{
				textBox_2.Text = string.Join(Class16.smethod_0(1648942920), ACE.RSGlobal.RSGlobal.IntArray2StringArray(hISTORYSTAGE.IDs));
			}
			id = 0;
			int[] iDs = hISTORYSTAGE.IDs;
			string name;
			if (0 < (nint)iDs.LongLength)
			{
				do
				{
					int num3 = iDs[id];
					eListCollection eListCollection4 = eLC;
					ITEMPOS iTEMPOS2 = eListCollection4.FindItemPos(eListCollection4.GetLists(ItemType.Matter), num3);
					string text3;
					string text4;
					if (hISTORYSTAGE.action == (AH_ACTIONS)7)
					{
						text3 = ACE.RSGlobal.RSGlobal.rn2CrLF(hISTORYSTAGE.descriptions_old[id]);
						text4 = ACE.RSGlobal.RSGlobal.rn2CrLF(hISTORYSTAGE.descriptions_new[id]);
					}
					else
					{
						text3 = CommonStorage.PWColor2String(hISTORYSTAGE.colors_old[id]);
						text4 = CommonStorage.PWColor2String(hISTORYSTAGE.color_new);
					}
					object[] array = new object[4];
					int num4 = num3;
					array[0] = num4.ToString();
					array[1] = string.Empty;
					array[2] = text3;
					array[3] = text4;
					dataGridView_1.Rows.Add(array);
					if (eLC.IsItemExist(iTEMPOS2))
					{
						int index = dataGridView_1.RowCount - 1;
						dataGridView_1.Rows[index].Tag = iTEMPOS2;
						ITEMINFO itemInfo = eLC.GetItemInfo(iTEMPOS2, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
						int num5 = num3;
						name = itemInfo.name;
						string text5 = Class16.smethod_0(1648924347);
						string text6 = Class16.smethod_0(1648924364);
						list.Add(string.Concat(string.Concat(string.Concat(RSCommon.Color2ColorTag(itemInfo.color) + text6, num5.ToString()), text5), name));
					}
					else
					{
						int num6 = num3;
						name = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
						string text7 = Class16.smethod_0(1648924347);
						list.Add(string.Concat(string.Concat(Class16.smethod_0(1648924387) + num6, text7), name));
					}
					id++;
					iDs = hISTORYSTAGE.IDs;
				}
				while (id < (nint)iDs.LongLength);
			}
			name = Class16.smethod_0(1648924428);
			Cached.names = string.Join(name, list.ToArray());
			break;
		}
		}
		string backupFileName = hISTORYSTAGE.BackupFileName;
		if (backupFileName != null)
		{
			textBox_1.Text = backupFileName;
			button_5.Enabled = true;
		}
		goto IL_0a73;
		IL_0a73:
		GC.KeepAlive(this);
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		dateTimePicker_1.Enabled = false;
		dateTimePicker_0.Enabled = false;
		panel_1.Visible = false;
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			method_3(1);
			break;
		case 1:
			method_3(7);
			break;
		case 2:
			method_3(31);
			break;
		case 3:
			method_3(0);
			break;
		case 4:
			dataGridView_0.Rows.Clear();
			dateTimePicker_1.Enabled = true;
			dateTimePicker_0.Enabled = true;
			dateTimePicker_1_ValueChanged(null, null);
			break;
		case 5:
			if (OwnerStageIndex > -1)
			{
				panel_1.Visible = true;
				int ownerStageIndex = OwnerStageIndex;
				string caption = AHistory.GetCaption(ownerStageIndex, -1, bSetDate: false);
				textBox_5.Text = caption;
				method_3(0);
			}
			else
			{
				comboBox_0.SelectedIndex = 0;
			}
			break;
		}
		dataGridView_0.Focus();
		GC.KeepAlive(this);
	}

	private void method_2(int int_0, uint uint_0, uint uint_1)
	{
		if (ACE.RSGlobal.RSGlobal.antirecurse_SetActionsDateRange_ActionsHistoryViewer)
		{
			return;
		}
		ACE.RSGlobal.RSGlobal.antirecurse_SetActionsDateRange_ActionsHistoryViewer = true;
		Cursor = Cursors.AppStarting;
		if (AHistory?.History == null)
		{
			dataGridView_0.Rows.Clear();
			Cursor = Cursors.Default;
			ACE.RSGlobal.RSGlobal.antirecurse_SetActionsDateRange_ActionsHistoryViewer = false;
			GC.KeepAlive(this);
			return;
		}
		StagesCount = AHistory.History.Count;
		dataGridView_0.Rows.Clear();
		int num = (int)ACE.RSGlobal.RSGlobal.DateTime2Timestamp(DateTime.UtcNow);
		uint num2 = (uint)(int_0 * 86400);
		List<DataGridViewRow> list = new List<DataGridViewRow>();
		List<HISTORYSTAGE> list2 = ((comboBox_0.SelectedIndex != 5) ? AHistory.History : AHistory.GetSubstages(OwnerStageIndex));
		if (list2 == null)
		{
			dataGridView_0.Rows.Clear();
			Cursor = Cursors.Default;
			ACE.RSGlobal.RSGlobal.antirecurse_SetActionsDateRange_ActionsHistoryViewer = false;
			GC.KeepAlive(this);
			return;
		}
		int num3 = list2.Count - 1;
		if (num3 >= 0)
		{
			do
			{
				bool flag;
				if (int_0 > -1)
				{
					int num4 = ((int_0 == 0 || (uint)(num - (int)list2[num3].TimeStamp) <= num2) ? 1 : 0);
					flag = (byte)num4 != 0;
				}
				else
				{
					int num5 = ((list2[num3].TimeStamp >= uint_0 && list2[num3].TimeStamp <= uint_1) ? 1 : 0);
					flag = (byte)num5 != 0;
				}
				if (flag)
				{
					DataGridViewRow dataGridViewRow = new DataGridViewRow();
					Image value;
					switch (list2[num3].action)
					{
					default:
					{
						string key4 = Class16.smethod_0(1648932175);
						value = imageList_0.Images[key4];
						break;
					}
					case AH_ACTIONS.Update:
					{
						string key3 = Class16.smethod_0(1648929269);
						value = imageList_0.Images[key3];
						break;
					}
					case (AH_ACTIONS)4:
					{
						string key7 = Class16.smethod_0(1648929279);
						value = imageList_0.Images[key7];
						break;
					}
					case (AH_ACTIONS)6:
					{
						string key6 = Class16.smethod_0(1648924195);
						value = imageList_0.Images[key6];
						break;
					}
					case (AH_ACTIONS)7:
					{
						string key5 = Class16.smethod_0(1648924177);
						value = imageList_0.Images[key5];
						break;
					}
					case (AH_ACTIONS)5:
					case (AH_ACTIONS)8:
						if (list2[num3].CaptionIndex == 148)
						{
							string key = Class16.smethod_0(1648924172);
							value = imageList_0.Images[key];
						}
						else
						{
							string key2 = Class16.smethod_0(1648929253);
							value = imageList_0.Images[key2];
						}
						break;
					}
					dataGridViewRow.Resizable = DataGridViewTriState.False;
					dataGridViewRow.Tag = num3;
					dataGridViewRow.CreateCells(dataGridView_0);
					dataGridViewRow.Cells[0].Value = num3;
					dataGridViewRow.Cells[2].Value = value;
					if (list2[num3].action == (AH_ACTIONS)8)
					{
						DataGridView dataGridView = dataGridView_0;
						dataGridViewRow.Cells[3].Style.Font = new Font(dataGridView.RowTemplate.DefaultCellStyle.Font, FontStyle.Bold);
					}
					list2[num3].CachedCaption = null;
					if (list2[num3].IsSubStage)
					{
						DateTime dateTime = ACE.RSGlobal.RSGlobal.Timestamp2DateTime(AHistory[OwnerStageIndex].TimeStamp).ToLocalTime();
						string text = Class16.smethod_0(1648924437);
						dataGridViewRow.Cells[1].Value = dateTime.ToString(text);
						int ownerStageIndex = OwnerStageIndex;
						ACTION_HISTORY aHistory = AHistory;
						dataGridViewRow.Cells[3].Value = aHistory.GetCaption(ownerStageIndex, num3, bSetDate: false);
					}
					else
					{
						DateTime dateTime2 = ACE.RSGlobal.RSGlobal.Timestamp2DateTime(list2[num3].TimeStamp).ToLocalTime();
						string text2 = Class16.smethod_0(1648924437);
						dataGridViewRow.Cells[1].Value = dateTime2.ToString(text2);
						string caption = AHistory.GetCaption(num3, -1, bSetDate: false);
						dataGridViewRow.Cells[3].Value = caption;
					}
					list.Add(dataGridViewRow);
				}
				num3--;
			}
			while (num3 >= 0);
		}
		dataGridView_0.Rows.AddRange(list.ToArray());
		RefreshActionsColor();
		Cursor = Cursors.Default;
		ACE.RSGlobal.RSGlobal.antirecurse_SetActionsDateRange_ActionsHistoryViewer = false;
		GC.KeepAlive(this);
	}

	private void method_3(int int_0)
	{
		if (int_0 >= 0)
		{
			method_2(int_0, 0u, 0u);
		}
	}

	private void method_4(DateTime dateTime_0, DateTime dateTime_1)
	{
		uint uint_ = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(dateTime_1) + 86400;
		method_2(-1, ACE.RSGlobal.RSGlobal.DateTime2Timestamp(dateTime_0), uint_);
		GC.KeepAlive(this);
	}

	private void dateTimePicker_1_ValueChanged(object sender, EventArgs e)
	{
		DateTime value = dateTimePicker_1.Value;
		dateTimePicker_0.MinDate = value;
		DateTime dateTime_ = dateTimePicker_0.Value.Date.ToUniversalTime();
		DateTime dateTime_2 = dateTimePicker_1.Value.Date.ToUniversalTime();
		method_4(dateTime_2, dateTime_);
		GC.KeepAlive(this);
	}

	private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		DateTime value = dateTimePicker_0.Value;
		dateTimePicker_1.MaxDate = value;
		DateTime dateTime_ = dateTimePicker_0.Value.Date.ToUniversalTime();
		DateTime dateTime_2 = dateTimePicker_1.Value.Date.ToUniversalTime();
		method_4(dateTime_2, dateTime_);
		GC.KeepAlive(this);
	}

	private void ActionsHistoryViewer_Shown(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.bFirstRun_ActionsHistoryViewer_Shown_ActionsHistoryViewer)
		{
			List<HISTORYSTAGE> history = AHistory.History;
			if (history != null && history.Count != 0)
			{
				SelectStage(AHistory.CurrentStageIndex);
			}
		}
		else
		{
			RefreshStagesList();
		}
		dataGridView_0.Focus();
		ACE.RSGlobal.RSGlobal.bFirstRun_ActionsHistoryViewer_Shown_ActionsHistoryViewer = false;
		GC.KeepAlive(this);
	}

	public void SelectStage(int Index)
	{
		if (StagesCount != AHistory.History.Count)
		{
			RefreshStagesList();
		}
		uint num = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(DateTime.UtcNow);
		Index = ((Index >= 0) ? Index : 0);
		int timeStamp = (int)AHistory[Index].TimeStamp;
		int num2 = (int)num - timeStamp;
		if (num2 < 86400)
		{
			comboBox_0.SelectedIndex = 0;
		}
		else if (num2 < 604800)
		{
			comboBox_0.SelectedIndex = 1;
		}
		else if (num2 < 2592000)
		{
			comboBox_0.SelectedIndex = 2;
		}
		else
		{
			comboBox_0.SelectedIndex = 3;
		}
		OwnerStageIndex = -1;
		int num3 = 0;
		if (0 < dataGridView_0.RowCount)
		{
			do
			{
				if ((int)dataGridView_0.Rows[num3].Tag == Index)
				{
					dataGridView_0.CurrentCell = dataGridView_0[1, num3];
					dataGridView_0.Rows[num3].Selected = true;
				}
				num3++;
			}
			while (num3 < dataGridView_0.RowCount);
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (comboBox_0.SelectedIndex == 5)
		{
			GC.KeepAlive(this);
			return;
		}
		if (e.RowIndex < 0)
		{
			GC.KeepAlive(this);
			return;
		}
		int num = (int)dataGridView_0.Rows[e.RowIndex].Tag;
		if (AHistory.GetSubstages(num) != null)
		{
			OwnerStageIndex = num;
			comboBox_0.SelectedIndex = 5;
		}
		GC.KeepAlive(this);
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedIndex == 5)
		{
			GC.KeepAlive(this);
			return;
		}
		int num = (int)dataGridView_0.SelectedRows[0].Tag;
		if (AHistory.GetSubstages(num) != null)
		{
			OwnerStageIndex = num;
			comboBox_0.SelectedIndex = 5;
		}
		GC.KeepAlive(this);
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		SelectStage(OwnerStageIndex);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		if (File.Exists(textBox_1.Text))
		{
			ACE.RSGlobal.RSGlobal.ShellP(textBox_1.Text);
		}
		else
		{
			object[] vars = new object[1] { textBox_1.Text };
			TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
		}
		GC.KeepAlive(this);
	}

	private void textBox_4_MouseMove(object sender, MouseEventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(textBox_4.Text))
		{
			string names = Cached.names;
			if (names != null && names.Length < 100)
			{
				IntPtr handle = ((Control)sender).Handle;
				ItemsToolTip1.ShowToolTip(handle, Cached.names);
			}
		}
		GC.KeepAlive(this);
	}

	private void textBox_4_MouseLeave(object sender, EventArgs e)
	{
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void textBox_3_MouseMove(object sender, MouseEventArgs e)
	{
		if (Cached.fields != null)
		{
			IntPtr handle = ((Control)sender).Handle;
			ItemsToolTip1.ShowToolTip(handle, Cached.fields);
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

	private void textBox_2_MouseMove(object sender, MouseEventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(textBox_2.Text))
		{
			string names = Cached.names;
			if (names != null && names.Length < 100)
			{
				IntPtr handle = ((Control)sender).Handle;
				ItemsToolTip1.ShowToolTip(handle, Cached.names);
			}
		}
		GC.KeepAlive(this);
	}

	private void textBox_2_MouseLeave(object sender, EventArgs e)
	{
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		int rowIndex = e.RowIndex;
		if (e.ColumnIndex <= 1 && rowIndex > -1 && dataGridView_1.Rows[rowIndex].Tag != null)
		{
			ITEMPOS iTEMPOS = (ITEMPOS)dataGridView_1.Rows[rowIndex].Tag;
			if (eLC.IsItemExist(iTEMPOS))
			{
				if (HINTS.ToolTipWindow != null)
				{
					HINTS.ShowElementToolTip(((Control)sender).Handle, iTEMPOS, IsShopPrice: false, bUnlimited: false, null);
				}
				else if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
				{
					HINTS.ToolTipWindow.SmoothHide();
				}
			}
		}
		else if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_1_MouseLeave(object sender, EventArgs e)
	{
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		int rowIndex = e.RowIndex;
		if (rowIndex > -1 && dataGridView_1.Rows[rowIndex].Tag != null)
		{
			ITEMPOS iTEMPOS = (ITEMPOS)dataGridView_1.Rows[rowIndex].Tag;
			if (dataGridView_1[1, rowIndex].Tag != null)
			{
				int wparam = (int)dataGridView_1[1, rowIndex].Tag;
				ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_FIELD_SET_ITEM, iTEMPOS.int_0, iTEMPOS.int_1);
				ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_FIELD_SET_FIELD, wparam, 0);
			}
			else
			{
				ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_LIST, iTEMPOS.int_0, 0);
				IntPtr objectPointer = ACE.RSGlobal.RSGlobal.GetObjectPointer(new int[1] { iTEMPOS.int_1 });
				ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_ITEMS, new int[1] { iTEMPOS.int_1 }.Length, objectPointer);
			}
		}
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.AppStarting;
		int selectedStageIndex = SelectedStageIndex;
		int currentStageIndex = AHistory.CurrentStageIndex;
		if (selectedStageIndex <= currentStageIndex)
		{
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UNDO_ACTION, SelectedStageIndex, 0);
		}
		else if (selectedStageIndex - currentStageIndex > 1)
		{
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_REDO_ACTION, SelectedStageIndex - 1, 0);
		}
		int selectedStageIndex2 = SelectedStageIndex;
		if (selectedStageIndex2 > 0)
		{
			SelectStage(selectedStageIndex2 - 1);
		}
		else
		{
			button_1.Enabled = false;
		}
		RefreshActionsColor();
		Cursor = Cursors.Default;
		GC.KeepAlive(this);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.AppStarting;
		int selectedStageIndex = SelectedStageIndex;
		int currentStageIndex = AHistory.CurrentStageIndex;
		if (selectedStageIndex > currentStageIndex)
		{
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_REDO_ACTION, SelectedStageIndex, 0);
		}
		else if (currentStageIndex - selectedStageIndex > 1)
		{
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UNDO_ACTION, SelectedStageIndex + 1, 0);
		}
		int num = AHistory.History.Count - 1;
		int selectedStageIndex2 = SelectedStageIndex;
		if (selectedStageIndex2 < num)
		{
			SelectStage(selectedStageIndex2 + 1);
		}
		else
		{
			button_2.Enabled = false;
		}
		RefreshActionsColor();
		Cursor = Cursors.Default;
		GC.KeepAlive(this);
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		if (TextStorage.TEXTS.ShowQuestionMessage(508) == DialogResult.Yes)
		{
			Cursor = Cursors.AppStarting;
			if (comboBox_0.SelectedIndex != 5)
			{
				ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UNDO_ACTION, SelectedStageIndex, 1);
			}
			else
			{
				ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UNDO_SUBACTION, OwnerStageIndex, SelectedStageIndex);
			}
			Cursor = Cursors.Default;
		}
		GC.KeepAlive(this);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		if (TextStorage.TEXTS.ShowQuestionMessage(508) == DialogResult.Yes)
		{
			Cursor = Cursors.AppStarting;
			if (comboBox_0.SelectedIndex != 5)
			{
				ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_REDO_ACTION, SelectedStageIndex, 1);
			}
			else
			{
				ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_REDO_SUBACTION, OwnerStageIndex, SelectedStageIndex);
			}
			Cursor = Cursors.Default;
		}
		GC.KeepAlive(this);
	}

	public void RefreshActionsColor()
	{
		if (comboBox_0.SelectedIndex != 5)
		{
			Color foreColor = (TDark.IsDarkMode ? TDark.DarkDisabledFore : Color.Silver);
			Color foreColor2 = (TDark.IsDarkMode ? TDark.DarkControlFore : Color.Black);
			int num = 0;
			if (0 < dataGridView_0.RowCount)
			{
				do
				{
					if ((int)dataGridView_0.Rows[num].Tag <= AHistory.CurrentStageIndex)
					{
						dataGridView_0[3, num].Style.ForeColor = foreColor2;
					}
					else
					{
						dataGridView_0[3, num].Style.ForeColor = foreColor;
					}
					num++;
				}
				while (num < dataGridView_0.RowCount);
			}
		}
		GC.KeepAlive(this);
	}

	public void RefreshStagesList()
	{
		int selectedIndex = comboBox_0.SelectedIndex;
		comboBox_0.SelectedIndex = -1;
		comboBox_0.SelectedIndex = selectedIndex;
		GC.KeepAlive(this);
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		if (dataGridView_0.SelectedRows.Count == 0)
		{
			TextStorage.TEXTS.ShowMessage(151, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, null);
			return;
		}
		int stageIndex = (int)dataGridView_0.SelectedRows[0].Tag;
		string caption = AHistory.GetCaption(stageIndex, -1, bSetDate: false);
		DialogResult dialogResult = DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648924450), Class16.smethod_0(1648924500)), caption), TextStorage.Msg(Class16.smethod_0(1648924556), Class16.smethod_0(1648924596)), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.Yes)
		{
			Cursor = Cursors.AppStarting;
			AHistory.DeleteStage(stageIndex);
			RefreshStagesList();
			if (AHistory.CurrentStageIndex >= 0 && AHistory.CurrentStageIndex < AHistory.History.Count)
			{
				SelectStage(AHistory.CurrentStageIndex);
			}
			else
			{
				dataGridView_0.ClearSelection();
			}
			Cursor = Cursors.Default;
		}
		GC.KeepAlive(this);
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		if (AHistory.History != null && AHistory.History.Count != 0)
		{
			DialogResult dialogResult = DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648923726), Class16.smethod_0(1648923760)), AHistory.History.Count), TextStorage.Msg(Class16.smethod_0(1648923658), Class16.smethod_0(1648923698)), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dialogResult == DialogResult.Yes)
			{
				Cursor = Cursors.AppStarting;
				AHistory.ClearHistory();
				RefreshStagesList();
				dataGridView_0.Rows.Clear();
				Cursor = Cursors.Default;
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648923859), Class16.smethod_0(1648923911)), TextStorage.Msg(Class16.smethod_0(1648923658), Class16.smethod_0(1648923698)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			GC.KeepAlive(this);
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648924608), Class16.smethod_0(1648924650)), TextStorage.Msg(Class16.smethod_0(1648923658), Class16.smethod_0(1648923698)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void ActionsHistoryViewer_FormClosing(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		Hide();
	}
}
