using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.License;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.Settings;
using Sentry;

namespace ACE.Domain2;

public class Domain2Editor : Form
{
	private sealed class Class102
	{
		public DOMAIN2.DomainInfo[] domainInfo_0;

		public DOMAIN2.BattletimeServer[] battletimeServer_0;

		public int int_0;

		public int int_1;
	}

	public bool IsFileChanged;

	public bool DontChange;

	public DOMAIN2 Domain2;

	public CommonStorage CStorage;

	public int SelectedDomain;

	private readonly Stack<Class102> stack_0 = new Stack<Class102>();

	private readonly Stack<Class102> stack_1 = new Stack<Class102>();

	private bool bool_0;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private TextBox textBox_0;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private Label label_0;

	private DataGridView dataGridView_0;

	private Button button_4;

	private Button button_5;

	private DataGridView dataGridView_1;

	private Label label_1;

	private NumericUpDown numericUpDown_0;

	private GroupBox groupBox_0;

	private Button button_6;

	private Button button_7;

	private Button button_8;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private TableLayoutPanel tableLayoutPanel_0;

	private PropertyGrid propertyGrid_0;

	private NumericUpDown numericUpDown_1;

	private Label label_2;

	private GroupBox groupBox_1;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private Button button_9;

	public IContainer components;

	public Domain2Editor(CommonStorage CStorage)
	{
		try
		{
			method_8();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			this.CStorage = CStorage;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			if (((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix) != Class16.smethod_0(1648932072))
			{
				dataGridViewComboBoxColumn_1.Items.Clear();
				DataGridViewComboBoxCell.ObjectCollection items = dataGridViewComboBoxColumn_1.Items;
				object[] textsByPrefix = CommonStorage.Texts.GetTextsByPrefix(Class16.smethod_0(1649009645));
				items.AddRange(textsByPrefix);
				dataGridViewComboBoxColumn_2.Items.Clear();
				DataGridViewComboBoxCell.ObjectCollection items2 = dataGridViewComboBoxColumn_2.Items;
				textsByPrefix = CommonStorage.Texts.GetTextsByPrefix(Class16.smethod_0(1649009658));
				items2.AddRange(textsByPrefix);
				dataGridViewComboBoxColumn_0.Items.Clear();
				DataGridViewComboBoxCell.ObjectCollection items3 = dataGridViewComboBoxColumn_0.Items;
				textsByPrefix = CommonStorage.Texts.GetTextsByPrefix(Class16.smethod_0(1649008663));
				items3.AddRange(textsByPrefix);
			}
			DontChange = false;
			IsFileChanged = false;
			string string_ = CommonStorage.Profile.GetSetting(Class16.smethod_0(1649008684), Class16.smethod_0(1649008696), string.Empty);
			string domain2FN = CommonStorage.CmdFlags.domain2FN;
			if (domain2FN != null && File.Exists(domain2FN))
			{
				string_ = CommonStorage.CmdFlags.domain2FN;
				CommonStorage.CmdFlags.domain2FN = null;
			}
			if (method_0(string_, bool_1: false))
			{
				method_9(bool_1: true);
			}
			method_3();
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private bool method_0(string string_0, bool bool_1)
	{
		if (!string.IsNullOrWhiteSpace(string_0) && File.Exists(string_0))
		{
			try
			{
				Domain2 = new DOMAIN2(string_0);
				if (Domain2 != null && Domain2.FileLoaded)
				{
					if (bool_1)
					{
						CommonStorage.Profile.SaveSetting(Class16.smethod_0(1649008684), Class16.smethod_0(1649008696), string_0);
					}
					return true;
				}
				return false;
			}
			catch (InvalidDataException ex)
			{
				SentryHelper.CaptureMessage(Class16.smethod_0(1649008724) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649008746));
				DKBox.Show(Class16.smethod_0(1649008791) + ex.Message, Class16.smethod_0(1649008879), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			catch (EndOfStreamException ex2)
			{
				SentryHelper.CaptureMessage(Class16.smethod_0(1649008896) + ex2.Message, (SentryLevel)2, Class16.smethod_0(1649008935));
				DKBox.Show(Class16.smethod_0(1649008972) + ex2.Message, Class16.smethod_0(1649008879), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
			catch (Exception ex3)
			{
				SentryHelper.CaptureException(ex3, Class16.smethod_0(1649009063));
				DKBox.Show(Class16.smethod_0(1649009080) + ex3.Message, Class16.smethod_0(1649008879), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return false;
			}
		}
		return false;
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		switch (keyData)
		{
		case Keys.Z | Keys.Control:
			method_5();
			return true;
		case Keys.Y | Keys.Control:
			method_6();
			return true;
		default:
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}

	private static DOMAIN2.DomainInfo[] smethod_0(DOMAIN2.DomainInfo[] domainInfo_0)
	{
		if (domainInfo_0 == null)
		{
			return Array.Empty<DOMAIN2.DomainInfo>();
		}
		DOMAIN2.DomainInfo[] array = new DOMAIN2.DomainInfo[domainInfo_0.Length];
		for (int i = 0; i < domainInfo_0.Length; i++)
		{
			array[i] = domainInfo_0[i]?.Clone();
		}
		return array;
	}

	private static DOMAIN2.BattletimeServer[] smethod_1(DOMAIN2.BattletimeServer[] battletimeServer_0)
	{
		if (battletimeServer_0 == null)
		{
			return Array.Empty<DOMAIN2.BattletimeServer>();
		}
		DOMAIN2.BattletimeServer[] array = new DOMAIN2.BattletimeServer[battletimeServer_0.Length];
		for (int i = 0; i < battletimeServer_0.Length; i++)
		{
			array[i] = battletimeServer_0[i]?.Clone();
		}
		return array;
	}

	private Class102 method_1()
	{
		return new Class102
		{
			domainInfo_0 = smethod_0(Domain2?.Domains),
			battletimeServer_0 = smethod_1(Domain2?.Times),
			int_0 = (Domain2?.BattletimeMax ?? 0),
			int_1 = (CommonStorage.AParams?.Domain2TimeBetweenMaps ?? 20)
		};
	}

	private void method_2()
	{
		if (bool_0 || Domain2 == null || !Domain2.FileLoaded)
		{
			return;
		}
		if (stack_0.Count >= 100)
		{
			Class102[] array = stack_0.ToArray();
			stack_0.Clear();
			for (int num = array.Length - 2; num >= 0; num--)
			{
				stack_0.Push(array[num]);
			}
		}
		stack_0.Push(method_1());
		stack_1.Clear();
		method_3();
	}

	private void method_3()
	{
		button_2.Enabled = stack_0.Count > 0;
		button_3.Enabled = stack_1.Count > 0;
	}

	private void method_4(Class102 class102_0)
	{
		if (class102_0 == null || Domain2 == null)
		{
			return;
		}
		bool_0 = true;
		DontChange = true;
		try
		{
			Domain2.Domains = smethod_0(class102_0.domainInfo_0);
			Domain2.Times = smethod_1(class102_0.battletimeServer_0);
			Domain2.TimeNum = Domain2.Times.Length;
			Domain2.BattletimeMax = class102_0.int_0;
			if (CommonStorage.AParams != null)
			{
				CommonStorage.AParams.Domain2TimeBetweenMaps = class102_0.int_1;
			}
			method_9(bool_1: false);
			IsFileChanged = true;
			button_0.Enabled = true;
		}
		finally
		{
			DontChange = false;
			bool_0 = false;
			method_3();
		}
	}

	private void method_5()
	{
		if (stack_0.Count > 0)
		{
			stack_1.Push(method_1());
			Class102 class102_ = stack_0.Pop();
			method_4(class102_);
		}
	}

	private void method_6()
	{
		if (stack_1.Count > 0)
		{
			stack_0.Push(method_1());
			Class102 class102_ = stack_1.Pop();
			method_4(class102_);
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		method_14();
	}

	private void method_7()
	{
		components?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_8()
	{
		new ComponentResourceManager(typeof(Domain2Editor));
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
		DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		textBox_0 = new TextBox();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		label_0 = new Label();
		groupBox_1 = new GroupBox();
		button_9 = new Button();
		button_8 = new Button();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		dataGridViewComboBoxColumn_2 = new DataGridViewComboBoxColumn();
		dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		button_4 = new Button();
		button_5 = new Button();
		dataGridView_1 = new DataGridView();
		dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		label_1 = new Label();
		numericUpDown_0 = new NumericUpDown();
		groupBox_0 = new GroupBox();
		button_6 = new Button();
		button_7 = new Button();
		tableLayoutPanel_0 = new TableLayoutPanel();
		propertyGrid_0 = new PropertyGrid();
		numericUpDown_1 = new NumericUpDown();
		label_2 = new Label();
		menuStrip_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		((ISupportInitialize)dataGridView_1).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		groupBox_0.SuspendLayout();
		tableLayoutPanel_0.SuspendLayout();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		SuspendLayout();
		menuStrip_0.BackColor = SystemColors.InactiveBorder;
		menuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		menuStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripMenuItem_1 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1649009132);
		menuStrip_0.Padding = new Padding(0, 2, 2, 2);
		menuStrip_0.RenderMode = ToolStripRenderMode.Professional;
		menuStrip_0.Size = new Size(1006, 24);
		menuStrip_0.TabIndex = 0;
		menuStrip_0.Text = Class16.smethod_0(1649012229);
		menuStrip_0.Visible = false;
		toolStripMenuItem_1.DropDownItems.AddRange(new ToolStripItem[4] { toolStripMenuItem_2, toolStripMenuItem_3, toolStripSeparator_0, toolStripMenuItem_0 });
		toolStripMenuItem_1.ImageScaling = ToolStripItemImageScaling.None;
		toolStripMenuItem_1.Name = Class16.smethod_0(1649012245);
		toolStripMenuItem_1.Padding = new Padding(0);
		toolStripMenuItem_1.Size = new Size(29, 20);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_1.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_2.BackgroundImageLayout = ImageLayout.None;
		toolStripMenuItem_2.Image = Resources.Domain2Editor_mnuOpen;
		toolStripMenuItem_2.ImageAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_2.Name = Class16.smethod_0(1648920856);
		toolStripMenuItem_2.ShortcutKeys = Keys.O | Keys.Control;
		toolStripMenuItem_2.Size = new Size(146, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648931498);
		toolStripMenuItem_2.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.Image = Resources.mnuSave;
		toolStripMenuItem_3.Name = Class16.smethod_0(1648920878);
		toolStripMenuItem_3.ShortcutKeys = Keys.S | Keys.Control;
		toolStripMenuItem_3.Size = new Size(146, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_3.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1649012270);
		toolStripSeparator_0.Size = new Size(143, 6);
		toolStripMenuItem_0.Image = Resources.Domain2Editor_mnuExit;
		toolStripMenuItem_0.Name = Class16.smethod_0(1648920908);
		toolStripMenuItem_0.Size = new Size(146, 22);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648920914);
		textBox_0.BackColor = Color.White;
		textBox_0.Location = new Point(350, 13);
		textBox_0.Name = Class16.smethod_0(1649012295);
		textBox_0.ReadOnly = true;
		textBox_0.Size = new Size(307, 22);
		textBox_0.TabIndex = 36;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		button_0.Enabled = false;
		button_0.Image = Resources.cmdSave;
		button_0.Location = new Point(769, 11);
		button_0.Name = Class16.smethod_0(1648920967);
		button_0.Size = new Size(102, 25);
		button_0.TabIndex = 38;
		button_0.Text = Class16.smethod_0(1648941761);
		button_0.TextAlign = ContentAlignment.MiddleRight;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Image = Resources.cmdOpen;
		button_1.Location = new Point(664, 11);
		button_1.Name = Class16.smethod_0(1648920945);
		button_1.Size = new Size(102, 25);
		button_1.TabIndex = 39;
		button_1.Text = Class16.smethod_0(1648931498);
		button_1.TextAlign = ContentAlignment.MiddleRight;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Enabled = false;
		button_2.Location = new Point(104, 11);
		button_2.Name = Class16.smethod_0(1648929618);
		button_2.Size = new Size(76, 25);
		button_2.TabIndex = 75;
		button_2.Image = Resources.GShopEditor_PW_mbUndo;
		button_2.ImageAlign = ContentAlignment.MiddleLeft;
		button_2.Text = Class16.smethod_0(1648903487);
		button_2.TextAlign = ContentAlignment.MiddleRight;
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Enabled = false;
		button_3.Location = new Point(182, 11);
		button_3.Name = Class16.smethod_0(1648929390);
		button_3.Size = new Size(76, 25);
		button_3.TabIndex = 76;
		button_3.Image = Resources.GShopEditor_PW_mbRedo;
		button_3.ImageAlign = ContentAlignment.MiddleLeft;
		button_3.Text = Class16.smethod_0(1648903490);
		button_3.TextAlign = ContentAlignment.MiddleRight;
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_0.Location = new Point(265, 15);
		label_0.Name = Class16.smethod_0(1649012305);
		label_0.Size = new Size(83, 15);
		label_0.TabIndex = 72;
		label_0.Text = Class16.smethod_0(1649012322);
		groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_1.Controls.Add(button_9);
		groupBox_1.Controls.Add(button_2);
		groupBox_1.Controls.Add(button_3);
		groupBox_1.Controls.Add(button_8);
		groupBox_1.Controls.Add(label_0);
		groupBox_1.Controls.Add(button_1);
		groupBox_1.Controls.Add(textBox_0);
		groupBox_1.Controls.Add(button_0);
		groupBox_1.Location = new Point(3, -3);
		groupBox_1.Name = Class16.smethod_0(1648929126);
		groupBox_1.Size = new Size(1001, 41);
		groupBox_1.TabIndex = 80;
		groupBox_1.TabStop = false;
		button_9.Enabled = false;
		button_9.Location = new Point(10, 11);
		button_9.Name = Class16.smethod_0(1649012350);
		button_9.Size = new Size(90, 25);
		button_9.TabIndex = 74;
		button_9.Text = Class16.smethod_0(1649012373);
		button_9.UseVisualStyleBackColor = true;
		button_9.Click += button_9_Click;
		button_8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_8.Enabled = false;
		button_8.Image = Resources.cmdExportToSev;
		button_8.Location = new Point(874, 11);
		button_8.Name = Class16.smethod_0(1649012391);
		button_8.Size = new Size(121, 25);
		button_8.TabIndex = 73;
		button_8.Text = Class16.smethod_0(1649012412);
		button_8.TextAlign = ContentAlignment.MiddleRight;
		button_8.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_8.UseVisualStyleBackColor = true;
		button_8.Click += button_8_Click;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.BackgroundColor = Color.White;
		dataGridView_0.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_0.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_2, dataGridViewTextBoxColumn_3, dataGridViewTextBoxColumn_4, dataGridViewComboBoxColumn_1, dataGridViewComboBoxColumn_2, dataGridViewCheckBoxColumn_0, dataGridViewTextBoxColumn_5, dataGridViewTextBoxColumn_6, dataGridViewTextBoxColumn_7, dataGridViewTextBoxColumn_8);
		tableLayoutPanel_0.SetColumnSpan(dataGridView_0, 2);
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.White;
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = Color.Black;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = Color.White;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.Dock = DockStyle.Fill;
		dataGridView_0.Enabled = false;
		dataGridView_0.GridColor = Color.Silver;
		dataGridView_0.Location = new Point(3, 4);
		dataGridView_0.Margin = new Padding(3, 4, 3, 4);
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1649012425);
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
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowsDefaultCellStyle = dataGridViewCellStyle3;
		dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellToolTips = false;
		dataGridView_0.Size = new Size(995, 335);
		dataGridView_0.TabIndex = 106;
		dataGridView_0.CellValueChanged += dataGridView_0_CellValueChanged;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1649012442);
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_2.Width = 90;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle5.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Bold);
		dataGridViewCellStyle5.ForeColor = Color.Maroon;
		dataGridViewTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle5;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1648929955);
		dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_3.Width = 40;
		dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle6.ForeColor = Color.Olive;
		dataGridViewTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle6;
		dataGridViewTextBoxColumn_4.HeaderText = Class16.smethod_0(1649012456);
		dataGridViewTextBoxColumn_4.Name = Class16.smethod_0(1649012478);
		dataGridViewTextBoxColumn_4.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_4.Width = 51;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewComboBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle7;
		dataGridViewComboBoxColumn_1.HeaderText = Class16.smethod_0(1649012494);
		dataGridViewComboBoxColumn_1.Items.AddRange(Class16.smethod_0(1649012507), Class16.smethod_0(1649012530), Class16.smethod_0(1649012565));
		dataGridViewComboBoxColumn_1.Name = Class16.smethod_0(1649012586);
		dataGridViewComboBoxColumn_1.Resizable = DataGridViewTriState.True;
		dataGridViewComboBoxColumn_1.Width = 130;
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewComboBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle8;
		dataGridViewComboBoxColumn_2.HeaderText = Class16.smethod_0(1649012614);
		dataGridViewComboBoxColumn_2.Items.AddRange(Class16.smethod_0(1648908427), Class16.smethod_0(1649012628), Class16.smethod_0(1649012639), Class16.smethod_0(1649012652), Class16.smethod_0(1649012663));
		dataGridViewComboBoxColumn_2.Name = Class16.smethod_0(1649012676);
		dataGridViewComboBoxColumn_2.Resizable = DataGridViewTriState.True;
		dataGridViewComboBoxColumn_2.Width = 97;
		dataGridViewCheckBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle9.ForeColor = Color.Gray;
		dataGridViewCellStyle9.NullValue = false;
		dataGridViewCheckBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle9;
		dataGridViewCheckBoxColumn_0.HeaderText = Class16.smethod_0(1649012693);
		dataGridViewCheckBoxColumn_0.Name = Class16.smethod_0(1649012696);
		dataGridViewCheckBoxColumn_0.Resizable = DataGridViewTriState.True;
		dataGridViewCheckBoxColumn_0.Width = 37;
		dataGridViewTextBoxColumn_5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle10.ForeColor = Color.Teal;
		dataGridViewTextBoxColumn_5.DefaultCellStyle = dataGridViewCellStyle10;
		dataGridViewTextBoxColumn_5.HeaderText = Class16.smethod_0(1649012712);
		dataGridViewTextBoxColumn_5.Name = Class16.smethod_0(1649011714);
		dataGridViewTextBoxColumn_5.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle11.ForeColor = Color.Teal;
		dataGridViewTextBoxColumn_6.DefaultCellStyle = dataGridViewCellStyle11;
		dataGridViewTextBoxColumn_6.HeaderText = Class16.smethod_0(1649011742);
		dataGridViewTextBoxColumn_6.Name = Class16.smethod_0(1649011760);
		dataGridViewTextBoxColumn_6.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle12.ForeColor = Color.Teal;
		dataGridViewTextBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle12;
		dataGridViewTextBoxColumn_7.HeaderText = Class16.smethod_0(1649011788);
		dataGridViewTextBoxColumn_7.Name = Class16.smethod_0(1649011814);
		dataGridViewTextBoxColumn_7.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle13.ForeColor = Color.Teal;
		dataGridViewTextBoxColumn_8.DefaultCellStyle = dataGridViewCellStyle13;
		dataGridViewTextBoxColumn_8.HeaderText = Class16.smethod_0(1649011826);
		dataGridViewTextBoxColumn_8.Name = Class16.smethod_0(1649011860);
		dataGridViewTextBoxColumn_8.SortMode = DataGridViewColumnSortMode.NotSortable;
		button_4.Dock = DockStyle.Fill;
		button_4.Enabled = false;
		button_4.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		button_4.Image = Resources.cmdDeleteZone;
		button_4.Location = new Point(503, 530);
		button_4.Name = Class16.smethod_0(1649011872);
		button_4.Size = new Size(495, 25);
		button_4.TabIndex = 108;
		button_4.Text = Class16.smethod_0(1649011900);
		button_4.TextAlign = ContentAlignment.MiddleRight;
		button_4.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		button_5.Dock = DockStyle.Fill;
		button_5.Enabled = false;
		button_5.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		button_5.Image = Resources.cmdAddZone;
		button_5.Location = new Point(3, 530);
		button_5.Name = Class16.smethod_0(1649011927);
		button_5.Size = new Size(494, 25);
		button_5.TabIndex = 107;
		button_5.Text = Class16.smethod_0(1649011936);
		button_5.TextAlign = ContentAlignment.MiddleRight;
		button_5.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToDeleteRows = false;
		dataGridView_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_1.BackgroundColor = Color.White;
		dataGridView_1.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		dataGridView_1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_1.Columns.AddRange(dataGridViewComboBoxColumn_0, dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1);
		dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle14.BackColor = Color.White;
		dataGridViewCellStyle14.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle14.ForeColor = Color.Black;
		dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle14.SelectionForeColor = Color.White;
		dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
		dataGridView_1.DefaultCellStyle = dataGridViewCellStyle14;
		dataGridView_1.GridColor = Color.Silver;
		dataGridView_1.Location = new Point(6, 21);
		dataGridView_1.Margin = new Padding(3, 4, 3, 4);
		dataGridView_1.MultiSelect = false;
		dataGridView_1.Name = Class16.smethod_0(1649011959);
		dataGridView_1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle15.BackColor = SystemColors.Control;
		dataGridViewCellStyle15.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle15.WrapMode = DataGridViewTriState.False;
		dataGridView_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
		dataGridView_1.RowHeadersVisible = false;
		dataGridView_1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle16.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_1.RowsDefaultCellStyle = dataGridViewCellStyle16;
		dataGridView_1.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_1.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_1.ShowCellToolTips = false;
		dataGridView_1.Size = new Size(951, 90);
		dataGridView_1.TabIndex = 109;
		dataGridView_1.CellValueChanged += dataGridView_1_CellValueChanged;
		dataGridView_1.SelectionChanged += dataGridView_1_SelectionChanged;
		dataGridViewComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle17.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle17.ForeColor = Color.Black;
		dataGridViewComboBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle17;
		dataGridViewComboBoxColumn_0.HeaderText = Class16.smethod_0(1649011974);
		dataGridViewComboBoxColumn_0.Items.AddRange(Class16.smethod_0(1649011996), Class16.smethod_0(1649012001), Class16.smethod_0(1649012022), Class16.smethod_0(1649012036), Class16.smethod_0(1649012052), Class16.smethod_0(1649012059), Class16.smethod_0(1649012072));
		dataGridViewComboBoxColumn_0.Name = Class16.smethod_0(1649012095);
		dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle18.ForeColor = Color.Black;
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle18;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649012117);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649012121);
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle19.ForeColor = Color.Black;
		dataGridViewTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle19;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1649012136);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649012158);
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		label_1.Location = new Point(3, 45);
		label_1.Name = Class16.smethod_0(1649012175);
		label_1.Size = new Size(164, 13);
		label_1.TabIndex = 110;
		label_1.Text = Class16.smethod_0(1649012195);
		label_1.TextAlign = ContentAlignment.MiddleRight;
		numericUpDown_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		numericUpDown_0.Location = new Point(167, 43);
		numericUpDown_0.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1649011206);
		numericUpDown_0.Size = new Size(333, 22);
		numericUpDown_0.TabIndex = 111;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_0.Controls.Add(button_6);
		groupBox_0.Controls.Add(button_7);
		groupBox_0.Controls.Add(dataGridView_1);
		groupBox_0.Enabled = false;
		groupBox_0.Location = new Point(3, 71);
		groupBox_0.Name = Class16.smethod_0(1649011229);
		groupBox_0.Size = new Size(996, 118);
		groupBox_0.TabIndex = 112;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1649011241);
		button_6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_6.Enabled = false;
		button_6.Font = new Font(Class16.smethod_0(1648942905), 8f);
		button_6.Image = Resources.cmdDeleteBattleTime;
		button_6.Location = new Point(963, 87);
		button_6.Name = Class16.smethod_0(1649011271);
		button_6.Size = new Size(27, 24);
		button_6.TabIndex = 142;
		button_6.TextAlign = ContentAlignment.MiddleRight;
		button_6.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		button_7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_7.Font = new Font(Class16.smethod_0(1648942905), 8f);
		button_7.Image = Resources.cmdAddBattleTime;
		button_7.Location = new Point(963, 62);
		button_7.Name = Class16.smethod_0(1649011289);
		button_7.Size = new Size(27, 24);
		button_7.TabIndex = 141;
		button_7.TextAlign = ContentAlignment.MiddleRight;
		button_7.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		tableLayoutPanel_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tableLayoutPanel_0.ColumnCount = 2;
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel_0.Controls.Add(dataGridView_0, 0, 0);
		tableLayoutPanel_0.Controls.Add(propertyGrid_0, 0, 1);
		tableLayoutPanel_0.Controls.Add(button_5, 0, 2);
		tableLayoutPanel_0.Controls.Add(button_4, 1, 2);
		tableLayoutPanel_0.Location = new Point(3, 195);
		tableLayoutPanel_0.Name = Class16.smethod_0(1648929366);
		tableLayoutPanel_0.RowCount = 3;
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 65f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 35f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		tableLayoutPanel_0.Size = new Size(1001, 558);
		tableLayoutPanel_0.TabIndex = 113;
		tableLayoutPanel_0.SetColumnSpan(propertyGrid_0, 2);
		propertyGrid_0.Dock = DockStyle.Fill;
		propertyGrid_0.HelpVisible = false;
		propertyGrid_0.Location = new Point(3, 346);
		propertyGrid_0.Name = Class16.smethod_0(1649011312);
		propertyGrid_0.Size = new Size(995, 178);
		propertyGrid_0.TabIndex = 107;
		propertyGrid_0.PropertyValueChanged += propertyGrid_0_PropertyValueChanged;
		numericUpDown_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		numericUpDown_1.Location = new Point(734, 43);
		numericUpDown_1.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_1.Name = Class16.smethod_0(1649011341);
		numericUpDown_1.Size = new Size(267, 22);
		numericUpDown_1.TabIndex = 115;
		numericUpDown_1.Value = new decimal(new int[4] { 20, 0, 0, 0 });
		numericUpDown_1.ValueChanged += numericUpDown_1_ValueChanged;
		label_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_2.Location = new Point(507, 45);
		label_2.Name = Class16.smethod_0(1649011365);
		label_2.Size = new Size(221, 13);
		label_2.TabIndex = 114;
		label_2.Text = Class16.smethod_0(1649011389);
		label_2.TextAlign = ContentAlignment.MiddleRight;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(1006, 755);
		base.Controls.Add(numericUpDown_1);
		base.Controls.Add(label_2);
		base.Controls.Add(tableLayoutPanel_0);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(label_1);
		base.Controls.Add(groupBox_1);
		base.Controls.Add(menuStrip_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.Icon = Resources.Domain2Editor_Icon;
		base.MainMenuStrip = menuStrip_0;
		base.Margin = new Padding(3, 4, 3, 4);
		MinimumSize = new Size(1022, 600);
		base.Name = Class16.smethod_0(1649008684);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649011436);
		base.Activated += Domain2Editor_Activated;
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		((ISupportInitialize)dataGridView_0).EndInit();
		((ISupportInitialize)dataGridView_1).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		tableLayoutPanel_0.ResumeLayout(performLayout: false);
		((ISupportInitialize)numericUpDown_1).EndInit();
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
				method_7();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void method_9(bool bool_1)
	{
		textBox_0.Text = Domain2.fn;
		IsFileChanged = false;
		button_0.Enabled = false;
		dataGridView_0.Enabled = true;
		button_5.Enabled = true;
		groupBox_0.Enabled = true;
		DontChange = true;
		decimal value = Domain2.BattletimeMax;
		numericUpDown_0.Value = value;
		dataGridView_0.SuspendLayout();
		dataGridView_0.ClearSelection();
		dataGridView_0.Rows.Clear();
		int num = 0;
		if (0 < (nint)Domain2.Domains.LongLength)
		{
			do
			{
				method_11(num);
				num++;
			}
			while (num < (nint)Domain2.Domains.LongLength);
		}
		dataGridView_0.ResumeLayout(performLayout: false);
		dataGridView_1.SuspendLayout();
		dataGridView_1.ClearSelection();
		dataGridView_1.Rows.Clear();
		int num2 = 0;
		if (0 < (nint)Domain2.Times.LongLength)
		{
			do
			{
				method_10(num2);
				num2++;
			}
			while (num2 < (nint)Domain2.Times.LongLength);
		}
		dataGridView_1.ResumeLayout(performLayout: false);
		int num3 = 20;
		if (CommonStorage.AParams == null)
		{
			CommonStorage.AParams = new ADDITIONAL_PARAMS();
			CommonStorage.AParams.Domain2TimeBetweenMaps = 20;
			num3 = 20;
		}
		if (CommonStorage.AParams.Domain2TimeBetweenMaps <= 0)
		{
			CommonStorage.AParams.Domain2TimeBetweenMaps = 20;
			num3 = 20;
		}
		numericUpDown_1.Text = num3.ToString();
		DontChange = false;
		button_8.Enabled = true;
		button_9.Enabled = true;
		if (TDark.IsDarkMode)
		{
			TDark.ApplyThemeToDynamicControl(dataGridView_0);
			TDark.ApplyThemeToDynamicControl(dataGridView_1);
			TDark.ApplyThemeToDynamicControl(propertyGrid_0);
		}
		if (bool_1)
		{
			stack_0.Clear();
			stack_1.Clear();
		}
		method_3();
		GC.KeepAlive(this);
	}

	private void method_10(int int_0)
	{
		int num = Domain2.Times[int_0].int_0;
		if (num < 0 || num > 6)
		{
			num = 0;
		}
		string[] array = new string[3]
		{
			dataGridViewComboBoxColumn_0.Items[num].ToString(),
			null,
			null
		};
		int int_1 = Domain2.Times[int_0].int_1;
		array[1] = int_1.ToString();
		int int_2 = Domain2.Times[int_0].int_2;
		array[2] = int_2.ToString();
		DataGridViewRowCollection rows = dataGridView_1.Rows;
		object[] values = array;
		rows.Add(values);
		GC.KeepAlive(this);
	}

	private void method_11(int int_0)
	{
		int num = Domain2.Domains[int_0].WarType;
		if (num < 0 || num > 2)
		{
			num = 0;
		}
		int num2 = Domain2.Domains[int_0].CountryId;
		if (num2 < 1 || num2 > 4)
		{
			num2 = 1;
		}
		object[] array = new object[10]
		{
			Domain2.Domains[int_0].Name,
			Domain2.Domains[int_0].ID.ToString(),
			Domain2.Domains[int_0].Point.ToString(),
			dataGridViewComboBoxColumn_1.Items[num],
			dataGridViewComboBoxColumn_2.Items[num2],
			Convert.ToBoolean(Domain2.Domains[int_0].IsCapital),
			null,
			null,
			null,
			null
		};
		DOMAIN2.DomainInfo domainInfo = Domain2.Domains[int_0];
		DOMAIN2.DomainInfo domainInfo2 = Domain2.Domains[int_0];
		DOMAIN2.DomainInfo domainInfo3 = Domain2.Domains[int_0];
		string text = string.Format(Class16.smethod_0(1649011479), domainInfo3.Coords[0].Single_2, domainInfo2.Coords[0].Single_1, domainInfo.Coords[0].Single_0);
		array[6] = text;
		DOMAIN2.DomainInfo domainInfo4 = Domain2.Domains[int_0];
		DOMAIN2.DomainInfo domainInfo5 = Domain2.Domains[int_0];
		DOMAIN2.DomainInfo domainInfo6 = Domain2.Domains[int_0];
		string text2 = string.Format(Class16.smethod_0(1649011479), domainInfo6.Coords[1].Single_2, domainInfo5.Coords[1].Single_1, domainInfo4.Coords[1].Single_0);
		array[7] = text2;
		DOMAIN2.DomainInfo domainInfo7 = Domain2.Domains[int_0];
		DOMAIN2.DomainInfo domainInfo8 = Domain2.Domains[int_0];
		DOMAIN2.DomainInfo domainInfo9 = Domain2.Domains[int_0];
		string text3 = string.Format(Class16.smethod_0(1649011479), domainInfo9.Coords[2].Single_2, domainInfo8.Coords[2].Single_1, domainInfo7.Coords[2].Single_0);
		array[8] = text3;
		DOMAIN2.DomainInfo domainInfo10 = Domain2.Domains[int_0];
		DOMAIN2.DomainInfo domainInfo11 = Domain2.Domains[int_0];
		DOMAIN2.DomainInfo domainInfo12 = Domain2.Domains[int_0];
		string text4 = string.Format(Class16.smethod_0(1649011479), domainInfo12.Coords[3].Single_2, domainInfo11.Coords[3].Single_1, domainInfo10.Coords[3].Single_0);
		array[9] = text4;
		dataGridView_0.Rows.Add(array);
		GC.KeepAlive(this);
	}

	private void method_12()
	{
		if (!string.IsNullOrWhiteSpace(Domain2?.fn) && File.Exists(Domain2.fn))
		{
			try
			{
				CStorage?.CreateBackup(Domain2.fn);
			}
			catch
			{
			}
		}
		if (AceNative.IsSuccess(AceNative.IsLicenseValid()))
		{
			Domain2.Save();
			IsFileChanged = false;
			button_0.Enabled = false;
			GC.KeepAlive(this);
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_12();
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_12();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_5();
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_6();
	}

	private void method_13()
	{
		Cursor = Cursors.WaitCursor;
		button_0.Enabled = true;
		button_8.Enabled = true;
		IsFileChanged = true;
		Cursor = Cursors.Default;
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_14();
	}

	private void method_14()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649011501);
		openFileDialog.FileName = Class16.smethod_0(1649011531);
		if (openFileDialog.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog.FileName) && method_0(openFileDialog.FileName, bool_1: true))
		{
			method_9(bool_1: true);
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_4.Enabled = b != 0;
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			SelectedDomain = dataGridView_0.SelectedRows[0].Index;
		}
		if (Domain2?.Domains != null && SelectedDomain >= 0 && SelectedDomain < Domain2.Domains.Length)
		{
			propertyGrid_0.SelectedObject = Domain2.Domains[SelectedDomain];
		}
		else
		{
			propertyGrid_0.SelectedObject = null;
		}
		GC.KeepAlive(this);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		method_2();
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			Domain2.AddDomain(dataGridView_0.SelectedRows[0].Index);
			method_11((int)((nint)Domain2.Domains.LongLength - 1));
			dataGridView_0.CurrentCell = dataGridView_0[0, (int)((nint)Domain2.Domains.LongLength - 1)];
			int index = (int)((nint)Domain2.Domains.LongLength - 1);
			dataGridView_0.Rows[index].Selected = true;
		}
		else
		{
			Domain2.AddDomain();
			method_11((int)((nint)Domain2.Domains.LongLength - 1));
			dataGridView_0.CurrentCell = dataGridView_0[0, (int)((nint)Domain2.Domains.LongLength - 1)];
			int index2 = (int)((nint)Domain2.Domains.LongLength - 1);
			dataGridView_0.Rows[index2].Selected = true;
		}
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_4.Enabled = b != 0;
		method_13();
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		if (dataGridView_0.SelectedRows.Count != 0)
		{
			method_2();
			Domain2.DeleteDomain(dataGridView_0.SelectedRows[0].Index);
			DataGridView dataGridView = dataGridView_0;
			dataGridView_0.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
			byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			button_4.Enabled = b != 0;
			method_13();
		}
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		int rowIndex = e.RowIndex;
		int columnIndex = e.ColumnIndex;
		if (rowIndex >= 0 && !DontChange && !bool_0)
		{
			method_2();
			string text = string.Empty;
			if (dataGridView_0[columnIndex, rowIndex].Value != null)
			{
				text = dataGridView_0[columnIndex, rowIndex].Value.ToString();
			}
			float[] array = null;
			if ((uint)(columnIndex - 6) <= 3u)
			{
				text = text.Replace(Class16.smethod_0(1648942211), string.Empty);
				string[] source = text.Split('|');
				try
				{
					array = ACE.RSGlobal.RSGlobal.StringArray2FloatArray(source);
					if ((nint)array.LongLength != 3)
					{
						array = null;
					}
				}
				catch (Exception ex)
				{
					string key = Class16.smethod_0(1648935530);
					ex.Data.Add(key, text);
					string text2 = Class16.smethod_0(1648934564) + ex.Message + Class16.smethod_0(1648934582) + ex.StackTrace + Class16.smethod_0(1649011558) + text + Class16.smethod_0(1648934604);
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649008684));
					DKBox.Show(text2, Class16.smethod_0(1649011571), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			switch (columnIndex)
			{
			default:
			{
				int num = columnIndex - 6;
				if ((uint)num <= 3u)
				{
					int index = num;
					if (array != null)
					{
						float single_ = array[0];
						Domain2.Domains[rowIndex].Coords[index].Single_2 = single_;
						float single_2 = array[1];
						Domain2.Domains[rowIndex].Coords[index].Single_1 = single_2;
						float single_3 = array[2];
						Domain2.Domains[rowIndex].Coords[index].Single_0 = single_3;
					}
					else
					{
						DOMAIN2.DomainInfo domainInfo = Domain2.Domains[rowIndex];
						DOMAIN2.DomainInfo domainInfo2 = Domain2.Domains[rowIndex];
						DOMAIN2.DomainInfo domainInfo3 = Domain2.Domains[rowIndex];
						string format = Class16.smethod_0(1649011479);
						dataGridView_0[columnIndex, rowIndex].Value = string.Format(format, domainInfo3.Coords[index].Single_2, domainInfo2.Coords[index].Single_1, domainInfo.Coords[index].Single_0);
					}
				}
				break;
			}
			case 0:
				Domain2.Domains[rowIndex].Name = text;
				break;
			case 1:
			{
				if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
				{
					Domain2.Domains[rowIndex].ID = Convert.ToInt32(text);
					break;
				}
				int iD = Domain2.Domains[rowIndex].ID;
				dataGridView_0[1, rowIndex].Value = iD.ToString();
				break;
			}
			case 2:
			{
				if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
				{
					Domain2.Domains[rowIndex].Point = Convert.ToInt32(text);
					break;
				}
				int point = Domain2.Domains[rowIndex].Point;
				dataGridView_0[2, rowIndex].Value = point.ToString();
				break;
			}
			case 3:
				Domain2.Domains[rowIndex].WarType = dataGridViewComboBoxColumn_1.Items.IndexOf(text);
				break;
			case 4:
				Domain2.Domains[rowIndex].CountryId = dataGridViewComboBoxColumn_2.Items.IndexOf(text);
				break;
			case 5:
			{
				int isCapital = (Convert.ToBoolean(text) ? 1 : 0);
				Domain2.Domains[rowIndex].IsCapital = isCapital;
				break;
			}
			}
			method_13();
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange && !bool_0)
		{
			DOMAIN2 domain = Domain2;
			if (domain != null && domain.FileLoaded)
			{
				method_2();
				decimal value = numericUpDown_0.Value;
				Domain2.BattletimeMax = (int)value;
				method_13();
			}
		}
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		if (dataGridView_1.SelectedRows.Count != 0)
		{
			method_2();
			Domain2.DeleteTime(dataGridView_1.SelectedRows[0].Index);
			DataGridView dataGridView = dataGridView_1;
			dataGridView_1.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
			byte b = ((dataGridView_1.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			button_6.Enabled = b != 0;
			method_13();
		}
	}

	private void dataGridView_1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		int rowIndex = e.RowIndex;
		int columnIndex = e.ColumnIndex;
		if (rowIndex >= 0 && !DontChange && !bool_0)
		{
			method_2();
			object value = dataGridView_1[columnIndex, rowIndex].Value;
			if (value == null)
			{
				GC.KeepAlive(this);
				return;
			}
			string text = value.ToString();
			switch (columnIndex)
			{
			case 0:
				Domain2.Times[rowIndex].int_0 = dataGridViewComboBoxColumn_0.Items.IndexOf(text);
				goto default;
			case 1:
			{
				if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
				{
					Domain2.Times[rowIndex].int_1 = Convert.ToInt32(text);
					goto default;
				}
				int int_2 = Domain2.Times[rowIndex].int_1;
				dataGridView_0[1, rowIndex].Value = int_2.ToString();
				GC.KeepAlive(this);
				break;
			}
			case 2:
			{
				if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
				{
					Domain2.Times[rowIndex].int_2 = Convert.ToInt32(text);
					goto default;
				}
				int int_ = Domain2.Times[rowIndex].int_2;
				dataGridView_0[2, rowIndex].Value = int_.ToString();
				GC.KeepAlive(this);
				break;
			}
			default:
				method_13();
				break;
			}
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private void dataGridView_1_SelectionChanged(object sender, EventArgs e)
	{
		byte b = ((dataGridView_1.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_6.Enabled = b != 0;
		GC.KeepAlive(this);
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = Class16.smethod_0(1649011611);
		saveFileDialog.FileName = Class16.smethod_0(1648908885);
		if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			string empty = string.Empty;
			if (saveFileDialog.FileName != empty)
			{
				string fileName = saveFileDialog.FileName;
				Domain2.ExportToSev(fileName);
			}
		}
		GC.KeepAlive(this);
	}

	private void propertyGrid_0_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		method_13();
	}

	private void numericUpDown_1_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange && !bool_0)
		{
			method_2();
			decimal value = numericUpDown_1.Value;
			CommonStorage.AParams.Domain2TimeBetweenMaps = (int)value;
			method_13();
		}
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		if (!CommonStorage.License.Special.domain2_mapview)
		{
			return;
		}
		if (Domain2 != null && Domain2.FileLoaded)
		{
			Class102 item = method_1();
			try
			{
				Domain2MapEditor domain2MapEditor = new Domain2MapEditor(Domain2, SelectedDomain);
				try
				{
					try
					{
						domain2MapEditor.ShowDialog(this);
					}
					catch (ObjectDisposedException)
					{
						return;
					}
					method_9(bool_1: false);
					if (domain2MapEditor.HasChanges)
					{
						stack_0.Push(item);
						stack_1.Clear();
						method_3();
						method_13();
					}
					return;
				}
				finally
				{
					((IDisposable)domain2MapEditor).Dispose();
				}
			}
			catch (Exception ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1649008684));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649011676), Class16.smethod_0(1649010692)), ex2.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649011654)), TextStorage.Msg(Class16.smethod_0(1648943005)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void Domain2Editor_Activated(object sender, EventArgs e)
	{
		method_15();
	}

	private void method_15()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_Domain2Editor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this, null);
			if (((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix) != Class16.smethod_0(1648932072))
			{
				dataGridViewComboBoxColumn_1.Items.Clear();
				DataGridViewComboBoxCell.ObjectCollection items = dataGridViewComboBoxColumn_1.Items;
				object[] textsByPrefix = CommonStorage.Texts.GetTextsByPrefix(Class16.smethod_0(1649009645));
				items.AddRange(textsByPrefix);
				dataGridViewComboBoxColumn_2.Items.Clear();
				DataGridViewComboBoxCell.ObjectCollection items2 = dataGridViewComboBoxColumn_2.Items;
				textsByPrefix = CommonStorage.Texts.GetTextsByPrefix(Class16.smethod_0(1649009658));
				items2.AddRange(textsByPrefix);
				dataGridViewComboBoxColumn_0.Items.Clear();
				DataGridViewComboBoxCell.ObjectCollection items3 = dataGridViewComboBoxColumn_0.Items;
				textsByPrefix = CommonStorage.Texts.GetTextsByPrefix(Class16.smethod_0(1649008663));
				items3.AddRange(textsByPrefix);
			}
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_Domain2Editor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		method_2();
		if (dataGridView_1.SelectedRows.Count > 0)
		{
			Domain2.AddTime(dataGridView_1.SelectedRows[0].Index);
			method_10((int)((nint)Domain2.Times.LongLength - 1));
			dataGridView_1.CurrentCell = dataGridView_1[0, (int)((nint)Domain2.Times.LongLength - 1)];
			int index = (int)((nint)Domain2.Times.LongLength - 1);
			dataGridView_1.Rows[index].Selected = true;
		}
		else
		{
			Domain2.AddTime();
			method_10((int)((nint)Domain2.Times.LongLength - 1));
			dataGridView_1.CurrentCell = dataGridView_1[0, (int)((nint)Domain2.Times.LongLength - 1)];
			int index2 = (int)((nint)Domain2.Times.LongLength - 1);
			dataGridView_1.Rows[index2].Selected = true;
		}
		byte b = ((dataGridView_1.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_6.Enabled = b != 0;
		method_13();
	}
}
