using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class ConfigWindow : Form
{
	[Serializable]
	private sealed class Class125
	{
		public static readonly Class125 class125_0 = new Class125();

		public static Predicate<string> predicate_0;

		public static Predicate<string> predicate_1;

		internal bool method_0(string string_0)
		{
			return string_0.Contains(Class16.smethod_0(1648908124));
		}

		internal bool method_1(string string_0)
		{
			return string_0.Contains(Class16.smethod_0(1648908132));
		}
	}

	protected int conversationListIndex;

	protected string loadedConfFileName;

	protected string loadedConfFullPath;

	protected string defaultConfigPath;

	protected string[] listNames;

	protected string[] listOffsets;

	protected string[][] fieldNames;

	protected string[][] fieldTypes;

	protected string[] CopyfieldNames;

	protected string[] CopyfieldTypes;

	private static readonly string string_0 = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648991896));

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ComboBox comboBox_0;

	private Label label_0;

	private Button button_0;

	private Button button_1;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripMenuItem toolStripMenuItem_5;

	private ComboBox comboBox_1;

	private Label label_1;

	private TextBox textBox_0;

	private Label label_2;

	private DataGridView dataGridView_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_6;

	private ToolStripMenuItem toolStripMenuItem_7;

	private Button button_2;

	private Button button_3;

	private Label label_3;

	private TextBox textBox_1;

	private Label label_4;

	private TextBox textBox_2;

	private ToolStripMenuItem toolStripMenuItem_8;

	private ToolStripMenuItem toolStripMenuItem_9;

	private TextBox textBox_3;

	private Button button_4;

	private Button button_5;

	private TextBox textBox_4;

	private TextBox textBox_5;

	private Label label_5;

	private Button button_6;

	private Button button_7;

	private Button button_8;

	private Button button_9;

	private Button button_10;

	private Button button_11;

	private Button button_12;

	private TextBox textBox_6;

	private IContainer icontainer_0;

	public ConfigWindow()
	{
		try
		{
			method_4();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this, null);
			base.KeyPreview = true;
			base.KeyDown += ConfigWindow_KeyDown;
			method_0();
			method_2();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648991864));
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
			base.Dispose(true);
			throw;
		}
	}

	private void method_0()
	{
		try
		{
			if (File.Exists(string_0))
			{
				defaultConfigPath = File.ReadAllText(string_0).Trim();
			}
			else
			{
				defaultConfigPath = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648991932));
			}
		}
		catch
		{
			defaultConfigPath = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648991932));
		}
	}

	private void method_1()
	{
		try
		{
			File.WriteAllText(string_0, defaultConfigPath);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648991938));
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
		}
	}

	private void method_2()
	{
		comboBox_0.Items.Clear();
		try
		{
			if (Directory.Exists(defaultConfigPath))
			{
				string[] files = Directory.GetFiles(defaultConfigPath, Class16.smethod_0(1648991979), SearchOption.TopDirectoryOnly);
				string[] array = files;
				foreach (string path in array)
				{
					comboBox_0.Items.Add(System.IO.Path.GetFileName(path));
				}
				if (comboBox_0.Items.Count > 0)
				{
					comboBox_0.SelectedIndex = 0;
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648991999));
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedItem != null)
		{
			string text = System.IO.Path.Combine(defaultConfigPath, comboBox_0.SelectedItem.ToString());
			if (File.Exists(text))
			{
				method_5(text);
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648992038), Class16.smethod_0(1648992074)), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648992118), Class16.smethod_0(1648992150)), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_2();
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		try
		{
			folderBrowserDialog.Description = TextStorage.Msg(Class16.smethod_0(1648992174), Class16.smethod_0(1648992211));
			folderBrowserDialog.SelectedPath = defaultConfigPath;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				defaultConfigPath = folderBrowserDialog.SelectedPath;
				method_1();
				method_2();
			}
		}
		finally
		{
			((IDisposable)folderBrowserDialog).Dispose();
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(loadedConfFullPath))
		{
			toolStripMenuItem_3_Click(sender, e);
		}
		else
		{
			method_3(loadedConfFullPath);
		}
	}

	private void method_3(string string_1)
	{
		try
		{
			StreamWriter streamWriter = new StreamWriter(string_1);
			int num = listNames.Length;
			streamWriter.WriteLine(num);
			streamWriter.WriteLine(conversationListIndex);
			for (int i = 0; i < num; i++)
			{
				streamWriter.WriteLine();
				streamWriter.WriteLine(listNames[i]);
				streamWriter.WriteLine(listOffsets[i]);
				streamWriter.WriteLine(string.Join(Class16.smethod_0(1648898262), fieldNames[i]));
				streamWriter.WriteLine(string.Join(Class16.smethod_0(1648898262), fieldTypes[i]));
			}
			streamWriter.Close();
			loadedConfFileName = System.IO.Path.GetFileName(string_1);
			loadedConfFullPath = string_1;
			Text = Class16.smethod_0(1648991234) + loadedConfFileName;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648991264));
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648991298), Class16.smethod_0(1648991347)), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_4()
	{
		icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(ConfigWindow));
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripSeparator_1 = new ToolStripSeparator();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_5 = new ToolStripMenuItem();
		comboBox_0 = new ComboBox();
		label_0 = new Label();
		button_0 = new Button();
		button_1 = new Button();
		comboBox_1 = new ComboBox();
		label_1 = new Label();
		textBox_0 = new TextBox();
		label_2 = new Label();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		contextMenuStrip_0 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_6 = new ToolStripMenuItem();
		toolStripMenuItem_9 = new ToolStripMenuItem();
		toolStripMenuItem_8 = new ToolStripMenuItem();
		toolStripMenuItem_7 = new ToolStripMenuItem();
		button_2 = new Button();
		button_3 = new Button();
		label_3 = new Label();
		textBox_1 = new TextBox();
		label_4 = new Label();
		textBox_2 = new TextBox();
		textBox_3 = new TextBox();
		button_4 = new Button();
		button_5 = new Button();
		textBox_4 = new TextBox();
		textBox_5 = new TextBox();
		label_5 = new Label();
		button_6 = new Button();
		button_7 = new Button();
		button_8 = new Button();
		button_9 = new Button();
		button_10 = new Button();
		button_11 = new Button();
		button_12 = new Button();
		textBox_6 = new TextBox();
		menuStrip_0.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		contextMenuStrip_0.SuspendLayout();
		SuspendLayout();
		menuStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripMenuItem_0 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1649009132);
		menuStrip_0.Padding = new Padding(0, 2, 2, 2);
		menuStrip_0.RenderMode = ToolStripRenderMode.System;
		menuStrip_0.Size = new Size(1007, 24);
		menuStrip_0.TabIndex = 1;
		menuStrip_0.Text = Class16.smethod_0(1648931410);
		toolStripMenuItem_0.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[7] { toolStripMenuItem_1, toolStripMenuItem_2, toolStripMenuItem_3, toolStripSeparator_1, toolStripMenuItem_4, toolStripSeparator_0, toolStripMenuItem_5 });
		toolStripMenuItem_0.Name = Class16.smethod_0(1649012245);
		toolStripMenuItem_0.Padding = new Padding(0);
		toolStripMenuItem_0.Size = new Size(29, 20);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_0.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_1.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripMenuItem_1.Name = Class16.smethod_0(1648991396);
		toolStripMenuItem_1.Size = new Size(240, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648991416);
		toolStripMenuItem_1.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_2.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripMenuItem_2.Name = Class16.smethod_0(1648991438);
		toolStripMenuItem_2.ShortcutKeys = Keys.S | Keys.Control;
		toolStripMenuItem_2.Size = new Size(240, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_2.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripMenuItem_3.Name = Class16.smethod_0(1649014314);
		toolStripMenuItem_3.Size = new Size(240, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1649003956);
		toolStripMenuItem_3.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		toolStripSeparator_1.Name = Class16.smethod_0(1648920981);
		toolStripSeparator_1.Size = new Size(237, 6);
		toolStripMenuItem_4.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripMenuItem_4.Name = Class16.smethod_0(1648991458);
		toolStripMenuItem_4.Size = new Size(240, 22);
		toolStripMenuItem_4.Text = Class16.smethod_0(1648991503);
		toolStripMenuItem_4.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1648921077);
		toolStripSeparator_0.Size = new Size(237, 6);
		toolStripMenuItem_5.Name = Class16.smethod_0(1648991528);
		toolStripMenuItem_5.Size = new Size(240, 22);
		toolStripMenuItem_5.Text = Class16.smethod_0(1648991589);
		toolStripMenuItem_5.Click += toolStripMenuItem_5_Click;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(73, 601);
		comboBox_0.Name = Class16.smethod_0(1648991628);
		comboBox_0.Size = new Size(400, 21);
		comboBox_0.TabIndex = 29;
		label_0.AutoSize = true;
		label_0.Location = new Point(12, 604);
		label_0.Name = Class16.smethod_0(1648991652);
		label_0.Size = new Size(55, 13);
		label_0.TabIndex = 28;
		label_0.Text = Class16.smethod_0(1648991665);
		button_0.Location = new Point(479, 599);
		button_0.Name = Class16.smethod_0(1648991682);
		button_0.Size = new Size(80, 23);
		button_0.TabIndex = 30;
		button_0.Text = Class16.smethod_0(1648916975);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Location = new Point(565, 599);
		button_1.Name = Class16.smethod_0(1648991716);
		button_1.Size = new Size(75, 23);
		button_1.TabIndex = 31;
		button_1.Text = Class16.smethod_0(1648991736);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		comboBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Location = new Point(138, 53);
		comboBox_1.Name = Class16.smethod_0(1648990734);
		comboBox_1.Size = new Size(502, 21);
		comboBox_1.TabIndex = 2;
		comboBox_1.DrawItem += comboBox_1_DrawItem;
		comboBox_1.SelectedIndexChanged += comboBox_1_SelectedIndexChanged;
		label_1.AutoSize = true;
		label_1.Location = new Point(12, 83);
		label_1.Name = Class16.smethod_0(1648919238);
		label_1.Size = new Size(57, 13);
		label_1.TabIndex = 3;
		label_1.Text = Class16.smethod_0(1648990747);
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.Location = new Point(138, 80);
		textBox_0.Name = Class16.smethod_0(1648990772);
		textBox_0.Size = new Size(502, 20);
		textBox_0.TabIndex = 4;
		textBox_0.TextChanged += textBox_0_TextChanged;
		label_2.AutoSize = true;
		label_2.Location = new Point(12, 109);
		label_2.Name = Class16.smethod_0(1648912083);
		label_2.Size = new Size(67, 13);
		label_2.TabIndex = 5;
		label_2.Text = Class16.smethod_0(1648990787);
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_0.BackgroundColor = SystemColors.Window;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1);
		dataGridView_0.ContextMenuStrip = contextMenuStrip_0;
		dataGridView_0.EnableHeadersVisualStyles = false;
		dataGridView_0.Location = new Point(45, 166);
		dataGridView_0.Name = Class16.smethod_0(1648990815);
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
		dataGridView_0.RowTemplate.Height = 18;
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.Size = new Size(595, 346);
		dataGridView_0.TabIndex = 6;
		dataGridView_0.CellValueChanged += dataGridView_0_CellValueChanged;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648990839);
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 41;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648936875);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648990853);
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		contextMenuStrip_0.BackgroundImageLayout = ImageLayout.None;
		contextMenuStrip_0.Items.AddRange(new ToolStripItem[4] { toolStripMenuItem_6, toolStripMenuItem_9, toolStripMenuItem_8, toolStripMenuItem_7 });
		contextMenuStrip_0.Name = Class16.smethod_0(1648990859);
		contextMenuStrip_0.RenderMode = ToolStripRenderMode.System;
		contextMenuStrip_0.ShowImageMargin = false;
		contextMenuStrip_0.Size = new Size(144, 92);
		toolStripMenuItem_6.Name = Class16.smethod_0(1648990894);
		toolStripMenuItem_6.Size = new Size(143, 22);
		toolStripMenuItem_6.Text = Class16.smethod_0(1648990924);
		toolStripMenuItem_6.Click += toolStripMenuItem_6_Click;
		toolStripMenuItem_9.Name = Class16.smethod_0(1648990930);
		toolStripMenuItem_9.Size = new Size(143, 22);
		toolStripMenuItem_9.Text = Class16.smethod_0(1648990974);
		toolStripMenuItem_9.Click += toolStripMenuItem_8_Click;
		toolStripMenuItem_8.Name = Class16.smethod_0(1648990996);
		toolStripMenuItem_8.Size = new Size(143, 22);
		toolStripMenuItem_8.Text = Class16.smethod_0(1648991019);
		toolStripMenuItem_8.Click += toolStripMenuItem_8_Click;
		toolStripMenuItem_7.Name = Class16.smethod_0(1648991035);
		toolStripMenuItem_7.Size = new Size(143, 22);
		toolStripMenuItem_7.Text = Class16.smethod_0(1648991076);
		toolStripMenuItem_7.Click += button_7_Click;
		button_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_2.Location = new Point(359, 129);
		button_2.Name = Class16.smethod_0(1648991094);
		button_2.Size = new Size(100, 23);
		button_2.TabIndex = 8;
		button_2.Text = Class16.smethod_0(1648991108);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_3.Location = new Point(243, 129);
		button_3.Name = Class16.smethod_0(1648991134);
		button_3.Size = new Size(110, 23);
		button_3.TabIndex = 9;
		button_3.Text = Class16.smethod_0(1648991148);
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		label_3.AutoSize = true;
		label_3.Location = new Point(12, 56);
		label_3.Name = Class16.smethod_0(1648912145);
		label_3.Size = new Size(26, 13);
		label_3.TabIndex = 10;
		label_3.Text = Class16.smethod_0(1648991167);
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.Location = new Point(138, 106);
		textBox_1.Name = Class16.smethod_0(1648991171);
		textBox_1.Size = new Size(502, 20);
		textBox_1.TabIndex = 11;
		textBox_1.TextChanged += textBox_1_TextChanged;
		label_4.AutoSize = true;
		label_4.Location = new Point(12, 30);
		label_4.Name = Class16.smethod_0(1648912200);
		label_4.Size = new Size(120, 13);
		label_4.TabIndex = 12;
		label_4.Text = Class16.smethod_0(1648991192);
		textBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_2.Location = new Point(138, 27);
		textBox_2.Name = Class16.smethod_0(1648991231);
		textBox_2.Size = new Size(502, 20);
		textBox_2.TabIndex = 13;
		textBox_2.TextChanged += textBox_2_TextChanged;
		textBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_3.Location = new Point(12, 550);
		textBox_3.Name = Class16.smethod_0(1648990235);
		textBox_3.Size = new Size(460, 20);
		textBox_3.TabIndex = 14;
		button_4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_4.Location = new Point(495, 547);
		button_4.Name = Class16.smethod_0(1648990257);
		button_4.Size = new Size(145, 23);
		button_4.TabIndex = 15;
		button_4.Text = Class16.smethod_0(1648990279);
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		button_5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_5.Location = new Point(495, 575);
		button_5.Name = Class16.smethod_0(1648990310);
		button_5.Size = new Size(145, 23);
		button_5.TabIndex = 16;
		button_5.Text = Class16.smethod_0(1648990324);
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		textBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_4.Location = new Point(12, 578);
		textBox_4.Name = Class16.smethod_0(1648990347);
		textBox_4.Size = new Size(460, 20);
		textBox_4.TabIndex = 17;
		textBox_5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_5.Enabled = false;
		textBox_5.ImeMode = ImeMode.Disable;
		textBox_5.Location = new Point(138, 131);
		textBox_5.Name = Class16.smethod_0(1648990369);
		textBox_5.ReadOnly = true;
		textBox_5.Size = new Size(83, 20);
		textBox_5.TabIndex = 19;
		label_5.AutoSize = true;
		label_5.Location = new Point(12, 134);
		label_5.Name = Class16.smethod_0(1648990399);
		label_5.Size = new Size(78, 13);
		label_5.TabIndex = 18;
		label_5.Text = Class16.smethod_0(1648990411);
		button_6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_6.Location = new Point(12, 522);
		button_6.Name = Class16.smethod_0(1648990434);
		button_6.Size = new Size(306, 23);
		button_6.TabIndex = 21;
		button_6.Text = Class16.smethod_0(1648931361);
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		button_7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_7.Location = new Point(325, 522);
		button_7.Name = Class16.smethod_0(1648990450);
		button_7.Size = new Size(315, 23);
		button_7.TabIndex = 20;
		button_7.Text = Class16.smethod_0(1648925718);
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		button_8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_8.Font = new Font(Class16.smethod_0(1648942905), 20f);
		button_8.Location = new Point(4, 331);
		button_8.Name = Class16.smethod_0(1648990477);
		button_8.Size = new Size(39, 85);
		button_8.TabIndex = 23;
		button_8.Text = Class16.smethod_0(1648990488);
		button_8.UseVisualStyleBackColor = true;
		button_8.Click += button_8_Click;
		button_9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_9.Font = new Font(Class16.smethod_0(1648942905), 20f);
		button_9.Location = new Point(4, 421);
		button_9.Name = Class16.smethod_0(1648990497);
		button_9.Size = new Size(39, 85);
		button_9.TabIndex = 22;
		button_9.Text = Class16.smethod_0(1648990526);
		button_9.UseVisualStyleBackColor = true;
		button_9.Click += button_9_Click;
		button_10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_10.Font = new Font(Class16.smethod_0(1648942905), 20f);
		button_10.Location = new Point(4, 175);
		button_10.Name = Class16.smethod_0(1648990535);
		button_10.Size = new Size(39, 42);
		button_10.TabIndex = 25;
		button_10.Text = Class16.smethod_0(1648990557);
		button_10.UseVisualStyleBackColor = true;
		button_10.Click += button_10_Click;
		button_11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_11.Font = new Font(Class16.smethod_0(1648942905), 20f);
		button_11.Location = new Point(4, 222);
		button_11.Name = Class16.smethod_0(1648990566);
		button_11.Size = new Size(39, 42);
		button_11.TabIndex = 24;
		button_11.Text = Class16.smethod_0(1648990579);
		button_11.UseVisualStyleBackColor = true;
		button_11.Click += button_11_Click;
		button_12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_12.Location = new Point(683, 573);
		button_12.Name = Class16.smethod_0(1648990596);
		button_12.Size = new Size(287, 25);
		button_12.TabIndex = 26;
		button_12.Text = Class16.smethod_0(1648990609);
		button_12.UseVisualStyleBackColor = true;
		button_12.Click += button_12_Click;
		textBox_6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_6.Location = new Point(646, 27);
		textBox_6.MaxLength = 3276700;
		textBox_6.Multiline = true;
		textBox_6.Name = Class16.smethod_0(1648990645);
		textBox_6.ScrollBars = ScrollBars.Both;
		textBox_6.Size = new Size(350, 541);
		textBox_6.TabIndex = 27;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1007, 641);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(comboBox_0);
		base.Controls.Add(label_0);
		base.Controls.Add(textBox_6);
		base.Controls.Add(button_12);
		base.Controls.Add(button_10);
		base.Controls.Add(button_11);
		base.Controls.Add(button_8);
		base.Controls.Add(button_9);
		base.Controls.Add(button_6);
		base.Controls.Add(button_7);
		base.Controls.Add(textBox_5);
		base.Controls.Add(label_5);
		base.Controls.Add(textBox_4);
		base.Controls.Add(button_5);
		base.Controls.Add(button_4);
		base.Controls.Add(textBox_3);
		base.Controls.Add(textBox_2);
		base.Controls.Add(label_4);
		base.Controls.Add(textBox_1);
		base.Controls.Add(label_3);
		base.Controls.Add(button_3);
		base.Controls.Add(button_2);
		base.Controls.Add(dataGridView_0);
		base.Controls.Add(label_2);
		base.Controls.Add(textBox_0);
		base.Controls.Add(label_1);
		base.Controls.Add(comboBox_1);
		base.Controls.Add(menuStrip_0);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.Icon = Resources.edit;
		base.MainMenuStrip = menuStrip_0;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(660, 680);
		base.Name = Class16.smethod_0(1648990668);
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		Text = Class16.smethod_0(1648990687);
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		((ISupportInitialize)dataGridView_0).EndInit();
		contextMenuStrip_0.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_6();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void method_5(string string_1)
	{
		if (!File.Exists(string_1))
		{
			return;
		}
		loadedConfFileName = System.IO.Path.GetFileName(string_1);
		loadedConfFullPath = string_1;
		StreamReader streamReader = new StreamReader(string_1);
		comboBox_1.Items.Clear();
		int num = Convert.ToInt32(streamReader.ReadLine());
		listNames = new string[num];
		listOffsets = new string[num];
		fieldNames = new string[num][];
		fieldTypes = new string[num][];
		try
		{
			conversationListIndex = Convert.ToInt32(streamReader.ReadLine());
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648990706));
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
			conversationListIndex = 58;
		}
		textBox_2.Text = conversationListIndex.ToString();
		for (int i = 0; i < num; i++)
		{
			string text;
			while ((text = streamReader.ReadLine()) == string.Empty)
			{
			}
			comboBox_1.Items.Add(Class16.smethod_0(1648924364) + i + Class16.smethod_0(1648985628) + text);
			listNames[i] = text;
			listOffsets[i] = streamReader.ReadLine();
			fieldNames[i] = streamReader.ReadLine().Split(';');
			fieldTypes[i] = streamReader.ReadLine().Split(';');
		}
		streamReader.Close();
		Text = Class16.smethod_0(1648991234) + loadedConfFileName;
		if (comboBox_1.Items.Count > 0)
		{
			comboBox_1.SelectedIndex = 0;
		}
	}

	private void ConfigWindow_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && e.KeyCode == Keys.Up)
		{
			button_8_Click(sender, e);
			e.Handled = true;
		}
		else if (e.Control && e.KeyCode == Keys.Down)
		{
			button_9_Click(sender, e);
			e.Handled = true;
		}
	}

	private void method_6()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = defaultConfigPath;
		openFileDialog.Filter = Class16.smethod_0(1648985638);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			method_5(openFileDialog.FileName);
		}
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = defaultConfigPath;
		saveFileDialog.Filter = Class16.smethod_0(1648985638);
		if (!string.IsNullOrEmpty(loadedConfFileName))
		{
			saveFileDialog.FileName = loadedConfFileName;
		}
		if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != string.Empty)
		{
			method_3(saveFileDialog.FileName);
		}
	}

	private void comboBox_1_DrawItem(object sender, DrawItemEventArgs e)
	{
		if (e.Index < 0)
		{
			return;
		}
		try
		{
			ComboBox comboBox = sender as ComboBox;
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
				e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.White), new Point(e.Bounds.X, e.Bounds.Y));
			}
			else
			{
				e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
				e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.White), new Point(e.Bounds.X, e.Bounds.Y));
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648985672));
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
		}
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex > -1)
		{
			textBox_0.Text = listNames[comboBox_1.SelectedIndex];
			textBox_1.Text = listOffsets[comboBox_1.SelectedIndex];
			dataGridView_0.Rows.Clear();
			for (int i = 0; i < fieldNames[comboBox_1.SelectedIndex].Length; i++)
			{
				DataGridViewRowCollection rows = dataGridView_0.Rows;
				object[] values = new string[2]
				{
					fieldNames[comboBox_1.SelectedIndex][i],
					fieldTypes[comboBox_1.SelectedIndex][i]
				};
				rows.Add(values);
				dataGridView_0.Rows[i].HeaderCell.Value = i.ToString();
			}
			int num = method_12(comboBox_1.SelectedIndex);
			textBox_5.Text = num.ToString();
		}
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (comboBox_1.SelectedIndex < 0)
			{
				return;
			}
			string[] obj;
			int rowIndex;
			object obj2;
			if (fieldNames != null && e.ColumnIndex == 0)
			{
				obj = fieldNames[comboBox_1.SelectedIndex];
				rowIndex = e.RowIndex;
				object value = dataGridView_0[e.ColumnIndex, e.RowIndex].Value;
				if (value == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = value.ToString();
					if (obj2 != null)
					{
						goto IL_006c;
					}
				}
				obj2 = string.Empty;
				goto IL_006c;
			}
			goto IL_0091;
			IL_00eb:
			object obj3;
			int rowIndex2;
			object obj4;
			((object[])obj3)[rowIndex2] = obj4;
			int num = method_12(comboBox_1.SelectedIndex);
			textBox_5.Text = num.ToString();
			return;
			IL_0091:
			if (fieldTypes == null || e.ColumnIndex != 1)
			{
				return;
			}
			obj3 = fieldTypes[comboBox_1.SelectedIndex];
			rowIndex2 = e.RowIndex;
			object value2 = dataGridView_0[e.ColumnIndex, e.RowIndex].Value;
			if (value2 == null)
			{
				obj4 = null;
			}
			else
			{
				obj4 = value2.ToString();
				if (obj4 != null)
				{
					goto IL_00eb;
				}
			}
			obj4 = string.Empty;
			goto IL_00eb;
			IL_006c:
			obj[rowIndex] = (string)obj2;
			int num2 = method_12(comboBox_1.SelectedIndex);
			textBox_5.Text = num2.ToString();
			goto IL_0091;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648985672));
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648985712), Class16.smethod_0(1648985772)), string.Empty);
		}
	}

	private void toolStripMenuItem_6_Click(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex > -1)
		{
			int num = -1;
			if (dataGridView_0.CurrentCell != null)
			{
				num = dataGridView_0.CurrentCell.RowIndex + 1;
			}
			if (fieldNames[comboBox_1.SelectedIndex].Length != 0)
			{
				string[] array = new string[fieldNames[comboBox_1.SelectedIndex].Length + 1];
				Array.Copy(fieldNames[comboBox_1.SelectedIndex], 0, array, 0, dataGridView_0.CurrentCell.RowIndex + 1);
				array[dataGridView_0.CurrentCell.RowIndex + 1] = Class16.smethod_0(1648985841);
				Array.Copy(fieldNames[comboBox_1.SelectedIndex], dataGridView_0.CurrentCell.RowIndex + 1, array, dataGridView_0.CurrentCell.RowIndex + 2, fieldNames[comboBox_1.SelectedIndex].Length - dataGridView_0.CurrentCell.RowIndex - 1);
				fieldNames[comboBox_1.SelectedIndex] = array;
				array = new string[fieldTypes[comboBox_1.SelectedIndex].Length + 1];
				Array.Copy(fieldTypes[comboBox_1.SelectedIndex], 0, array, 0, dataGridView_0.CurrentCell.RowIndex + 1);
				array[dataGridView_0.CurrentCell.RowIndex + 1] = Class16.smethod_0(1648985856);
				Array.Copy(fieldTypes[comboBox_1.SelectedIndex], dataGridView_0.CurrentCell.RowIndex + 1, array, dataGridView_0.CurrentCell.RowIndex + 2, fieldTypes[comboBox_1.SelectedIndex].Length - dataGridView_0.CurrentCell.RowIndex - 1);
				fieldTypes[comboBox_1.SelectedIndex] = array;
			}
			else
			{
				string[] array2 = new string[1] { Class16.smethod_0(1648985841) };
				fieldNames[comboBox_1.SelectedIndex] = array2;
				array2 = new string[1] { Class16.smethod_0(1648985856) };
				fieldTypes[comboBox_1.SelectedIndex] = array2;
			}
			comboBox_1_SelectedIndexChanged(null, null);
			if (num > -1)
			{
				dataGridView_0.CurrentCell = dataGridView_0.Rows[num].Cells[0];
			}
		}
	}

	private void toolStripMenuItem_8_Click(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex <= -1)
		{
			return;
		}
		CopyfieldNames = new string[0];
		CopyfieldTypes = new string[0];
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < dataGridView_0.SelectedCells.Count; i++)
		{
			bool flag = true;
			for (int j = 0; j < arrayList.Count; j++)
			{
				if ((int)arrayList[j] == dataGridView_0.SelectedCells[i].RowIndex)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				arrayList.Add(dataGridView_0.SelectedCells[i].RowIndex);
			}
		}
		arrayList.Sort();
		for (int k = 0; k < arrayList.Count; k++)
		{
			string[] array = new string[CopyfieldNames.Length + 1];
			if (CopyfieldNames.Length != 0)
			{
				Array.Copy(CopyfieldNames, 0, array, 0, CopyfieldNames.Length);
			}
			array[CopyfieldNames.Length] = fieldNames[comboBox_1.SelectedIndex][(int)arrayList[k]];
			CopyfieldNames = array;
			array = new string[CopyfieldTypes.Length + 1];
			if (CopyfieldTypes.Length != 0)
			{
				Array.Copy(CopyfieldTypes, 0, array, 0, CopyfieldTypes.Length);
			}
			array[CopyfieldTypes.Length] = fieldTypes[comboBox_1.SelectedIndex][(int)arrayList[k]];
			CopyfieldTypes = array;
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex <= -1)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < dataGridView_0.SelectedCells.Count; i++)
		{
			bool flag = true;
			for (int j = 0; j < arrayList.Count; j++)
			{
				if ((int)arrayList[j] == dataGridView_0.SelectedCells[i].RowIndex)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				arrayList.Add(dataGridView_0.SelectedCells[i].RowIndex);
			}
		}
		arrayList.Sort();
		int num = -1;
		if (dataGridView_0.CurrentCell != null)
		{
			num = dataGridView_0.CurrentCell.RowIndex;
		}
		for (int k = 0; k < dataGridView_0.SelectedCells.Count; k++)
		{
			for (int l = 0; l < CopyfieldNames.Length; l++)
			{
				for (int m = 0; m < arrayList.Count; m++)
				{
					arrayList2.Add(arrayList[m]);
				}
				if (fieldNames[comboBox_1.SelectedIndex].Length != 0)
				{
					string[] array = new string[fieldNames[comboBox_1.SelectedIndex].Length + 1];
					Array.Copy(fieldNames[comboBox_1.SelectedIndex], 0, array, 0, (int)arrayList2[k] + 1);
					array[(int)arrayList2[k] + 1] = CopyfieldNames[l];
					Array.Copy(fieldNames[comboBox_1.SelectedIndex], (int)arrayList2[k] + 1, array, (int)arrayList2[k] + 2, fieldNames[comboBox_1.SelectedIndex].Length - (int)arrayList2[k] - 1);
					fieldNames[comboBox_1.SelectedIndex] = array;
					array = new string[fieldTypes[comboBox_1.SelectedIndex].Length + 1];
					Array.Copy(fieldTypes[comboBox_1.SelectedIndex], 0, array, 0, (int)arrayList2[k] + 1);
					array[(int)arrayList2[k] + 1] = CopyfieldTypes[l];
					Array.Copy(fieldTypes[comboBox_1.SelectedIndex], (int)arrayList2[k] + 1, array, (int)arrayList2[k] + 2, fieldTypes[comboBox_1.SelectedIndex].Length - (int)arrayList2[k] - 1);
					fieldTypes[comboBox_1.SelectedIndex] = array;
				}
				else
				{
					string[] array2 = new string[1] { CopyfieldNames[l] };
					fieldNames[comboBox_1.SelectedIndex] = array2;
					array2 = new string[1] { CopyfieldTypes[l] };
					fieldTypes[comboBox_1.SelectedIndex] = array2;
				}
				for (int n = 0; n < dataGridView_0.SelectedCells.Count; n++)
				{
					arrayList2[n] = (int)arrayList2[n] + 1;
				}
				for (int num2 = k; num2 < dataGridView_0.SelectedCells.Count; num2++)
				{
					if (l < CopyfieldNames.Length - 1)
					{
						arrayList[num2] = (int)arrayList[num2] + 1 + l;
					}
					else
					{
						arrayList[num2] = (int)arrayList[num2] + l;
					}
				}
				num = (int)arrayList2[0];
			}
		}
		comboBox_1_SelectedIndexChanged(null, null);
		if (num > -1)
		{
			dataGridView_0.CurrentCell = dataGridView_0.Rows[num].Cells[0];
		}
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex <= -1)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		foreach (DataGridViewCell selectedCell in dataGridView_0.SelectedCells)
		{
			if (!arrayList.Contains(selectedCell.RowIndex))
			{
				arrayList.Add(selectedCell.RowIndex);
			}
		}
		if (arrayList.Count > 0)
		{
			arrayList.Sort();
			int count = dataGridView_0.Rows.Count;
			foreach (int item in arrayList)
			{
				string[] array = new string[fieldNames[comboBox_1.SelectedIndex].Length + 1];
				string[] array2 = new string[fieldTypes[comboBox_1.SelectedIndex].Length + 1];
				Array.Copy(fieldNames[comboBox_1.SelectedIndex], array, fieldNames[comboBox_1.SelectedIndex].Length);
				Array.Copy(fieldTypes[comboBox_1.SelectedIndex], array2, fieldTypes[comboBox_1.SelectedIndex].Length);
				array[array.Length - 1] = fieldNames[comboBox_1.SelectedIndex][item];
				array2[array2.Length - 1] = fieldTypes[comboBox_1.SelectedIndex][item];
				fieldNames[comboBox_1.SelectedIndex] = array;
				fieldTypes[comboBox_1.SelectedIndex] = array2;
			}
			comboBox_1_SelectedIndexChanged(null, null);
			dataGridView_0.ClearSelection();
			for (int i = count; i < dataGridView_0.Rows.Count; i++)
			{
				dataGridView_0.Rows[i].Selected = true;
			}
			dataGridView_0.FirstDisplayedScrollingRowIndex = count;
		}
		else
		{
			toolStripMenuItem_6_Click(sender, e);
		}
		int num2 = method_12(comboBox_1.SelectedIndex);
		textBox_5.Text = num2.ToString();
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex <= -1 || dataGridView_0.SelectedCells.Count <= 0)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		foreach (DataGridViewCell selectedCell in dataGridView_0.SelectedCells)
		{
			if (!arrayList.Contains(selectedCell.RowIndex))
			{
				arrayList.Add(selectedCell.RowIndex);
			}
		}
		arrayList.Sort();
		foreach (int item in arrayList)
		{
			if (item > 0)
			{
				string text = fieldNames[comboBox_1.SelectedIndex][item];
				string text2 = fieldTypes[comboBox_1.SelectedIndex][item];
				fieldNames[comboBox_1.SelectedIndex][item] = fieldNames[comboBox_1.SelectedIndex][item - 1];
				fieldTypes[comboBox_1.SelectedIndex][item] = fieldTypes[comboBox_1.SelectedIndex][item - 1];
				fieldNames[comboBox_1.SelectedIndex][item - 1] = text;
				fieldTypes[comboBox_1.SelectedIndex][item - 1] = text2;
				dataGridView_0.Rows.RemoveAt(item);
				dataGridView_0.Rows.Insert(item - 1, text, text2);
			}
		}
		comboBox_1_SelectedIndexChanged(null, null);
		dataGridView_0.ClearSelection();
		foreach (int item2 in arrayList)
		{
			dataGridView_0.Rows[item2 - 1].Selected = true;
		}
		dataGridView_0.FirstDisplayedScrollingRowIndex = (int)arrayList[0] - 1;
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex <= -1 || dataGridView_0.SelectedCells.Count <= 0)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		foreach (DataGridViewCell selectedCell in dataGridView_0.SelectedCells)
		{
			if (!arrayList.Contains(selectedCell.RowIndex))
			{
				arrayList.Add(selectedCell.RowIndex);
			}
		}
		arrayList.Sort();
		arrayList.Reverse();
		bool flag = true;
		foreach (int item in arrayList)
		{
			if (item >= dataGridView_0.Rows.Count - 1)
			{
				flag = false;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		foreach (int item2 in arrayList)
		{
			string text = fieldNames[comboBox_1.SelectedIndex][item2];
			string text2 = fieldTypes[comboBox_1.SelectedIndex][item2];
			fieldNames[comboBox_1.SelectedIndex][item2] = fieldNames[comboBox_1.SelectedIndex][item2 + 1];
			fieldTypes[comboBox_1.SelectedIndex][item2] = fieldTypes[comboBox_1.SelectedIndex][item2 + 1];
			fieldNames[comboBox_1.SelectedIndex][item2 + 1] = text;
			fieldTypes[comboBox_1.SelectedIndex][item2 + 1] = text2;
			dataGridView_0.Rows.RemoveAt(item2);
			dataGridView_0.Rows.Insert(item2 + 1, text, text2);
		}
		comboBox_1_SelectedIndexChanged(null, null);
		dataGridView_0.ClearSelection();
		foreach (int item3 in arrayList)
		{
			if (item3 + 1 < dataGridView_0.Rows.Count)
			{
				dataGridView_0.Rows[item3 + 1].Selected = true;
			}
		}
		if (arrayList.Count > 0 && (int)arrayList[0] + 1 < dataGridView_0.Rows.Count)
		{
			dataGridView_0.FirstDisplayedScrollingRowIndex = (int)arrayList[0] + 1;
		}
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex <= -1 || dataGridView_0.SelectedCells.Count <= 0)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		foreach (DataGridViewCell selectedCell in dataGridView_0.SelectedCells)
		{
			if (!arrayList.Contains(selectedCell.RowIndex))
			{
				arrayList.Add(selectedCell.RowIndex);
			}
		}
		arrayList.Sort();
		foreach (int item in arrayList)
		{
			string text = fieldNames[comboBox_1.SelectedIndex][item];
			string text2 = fieldTypes[comboBox_1.SelectedIndex][item];
			for (int num2 = item; num2 > 0; num2--)
			{
				fieldNames[comboBox_1.SelectedIndex][num2] = fieldNames[comboBox_1.SelectedIndex][num2 - 1];
				fieldTypes[comboBox_1.SelectedIndex][num2] = fieldTypes[comboBox_1.SelectedIndex][num2 - 1];
			}
			fieldNames[comboBox_1.SelectedIndex][0] = text;
			fieldTypes[comboBox_1.SelectedIndex][0] = text2;
			dataGridView_0.Rows.RemoveAt(item);
			dataGridView_0.Rows.Insert(0, text, text2);
		}
		comboBox_1_SelectedIndexChanged(null, null);
		dataGridView_0.ClearSelection();
		dataGridView_0.Rows[0].Selected = true;
		dataGridView_0.FirstDisplayedScrollingRowIndex = 0;
	}

	private void button_11_Click(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex <= -1 || dataGridView_0.SelectedCells.Count <= 0)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		foreach (DataGridViewCell selectedCell in dataGridView_0.SelectedCells)
		{
			if (!arrayList.Contains(selectedCell.RowIndex))
			{
				arrayList.Add(selectedCell.RowIndex);
			}
		}
		arrayList.Sort();
		arrayList.Reverse();
		foreach (int item in arrayList)
		{
			string text = fieldNames[comboBox_1.SelectedIndex][item];
			string text2 = fieldTypes[comboBox_1.SelectedIndex][item];
			for (int i = item; i < fieldNames[comboBox_1.SelectedIndex].Length - 1; i++)
			{
				fieldNames[comboBox_1.SelectedIndex][i] = fieldNames[comboBox_1.SelectedIndex][i + 1];
				fieldTypes[comboBox_1.SelectedIndex][i] = fieldTypes[comboBox_1.SelectedIndex][i + 1];
			}
			fieldNames[comboBox_1.SelectedIndex][fieldNames[comboBox_1.SelectedIndex].Length - 1] = text;
			fieldTypes[comboBox_1.SelectedIndex][fieldTypes[comboBox_1.SelectedIndex].Length - 1] = text2;
			dataGridView_0.Rows.RemoveAt(item);
			dataGridView_0.Rows.Add(text, text2);
		}
		comboBox_1_SelectedIndexChanged(null, null);
		dataGridView_0.ClearSelection();
		dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Selected = true;
		dataGridView_0.FirstDisplayedScrollingRowIndex = dataGridView_0.Rows.Count - 1;
	}

	private void button_12_Click(object sender, EventArgs e)
	{
		string string_ = textBox_6.Text;
		method_8(string_);
	}

	private void method_8(string string_1)
	{
		if (comboBox_1.SelectedIndex == -1)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648985879), Class16.smethod_0(1648985926)), string.Empty);
			return;
		}
		fieldNames[comboBox_1.SelectedIndex] = new string[0];
		fieldTypes[comboBox_1.SelectedIndex] = new string[0];
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		string[] array = string_1.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
		int num = array.Length;
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			string text = array[i].Trim();
			if (text.StartsWith(Class16.smethod_0(1648985965)))
			{
				if (!flag)
				{
					flag = true;
					continue;
				}
				List<string> list3 = new List<string>();
				int num2 = 0;
				bool flag2 = false;
				for (; i < num; i++)
				{
					string text2 = array[i].Trim();
					list3.Add(text2);
					if (text2.Contains(Class16.smethod_0(1648908124)))
					{
						num2++;
						flag2 = true;
					}
					if (text2.Contains(Class16.smethod_0(1648908132)))
					{
						num2--;
						if (num2 == 0 && flag2)
						{
							i++;
							break;
						}
					}
				}
				string text3 = string.Empty;
				for (; i < num; i++)
				{
					text3 = array[i].Trim();
					if (!string.IsNullOrEmpty(text3) && text3 != Class16.smethod_0(1648898262))
					{
						if (text3.EndsWith(Class16.smethod_0(1648898262)))
						{
							text3 = text3.Substring(0, text3.Length - 1);
						}
						break;
					}
				}
				string text4 = string.Empty;
				int int_ = 0;
				if (!string.IsNullOrEmpty(text3))
				{
					string[] array2 = text3.Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
					if (array2.Length != 0)
					{
						text4 = array2[0];
						if (text4.Contains(Class16.smethod_0(1648924364)))
						{
							int num3 = text4.IndexOf(Class16.smethod_0(1648924364));
							int num4 = text4.IndexOf(Class16.smethod_0(1649008474));
							int_ = int.Parse(text4.Substring(num3 + 1, num4 - num3 - 1));
							text4 = text4.Substring(0, num3);
						}
					}
				}
				method_10(text4, int_, list, list2, list3, string.Empty);
			}
			else
			{
				if (!flag || text.StartsWith(Class16.smethod_0(1648908124)) || text.StartsWith(Class16.smethod_0(1648908132)) || text == Class16.smethod_0(1648898262))
				{
					continue;
				}
				if (text.EndsWith(Class16.smethod_0(1648898262)))
				{
					text = text.Substring(0, text.Length - 1);
				}
				if (text.StartsWith(Class16.smethod_0(1648985965)))
				{
					i--;
					continue;
				}
				string[] array3 = text.Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
				string string_2 = string.Join(Class16.smethod_0(1648942211), array3.Take(array3.Length - 1));
				string text5 = array3[array3.Length - 1];
				int num5 = 0;
				if (text5.Contains(Class16.smethod_0(1648924364)))
				{
					int num6 = text5.IndexOf(Class16.smethod_0(1648924364));
					int num7 = text5.IndexOf(Class16.smethod_0(1649008474));
					num5 = int.Parse(text5.Substring(num6 + 1, num7 - num6 - 1));
					text5 = text5.Substring(0, num6);
				}
				string text6 = method_9(string_2, num5);
				string text7 = text5;
				if (text5 == Class16.smethod_0(1648932143))
				{
					text7 = Class16.smethod_0(1648941057);
				}
				else if (text5 == Class16.smethod_0(1648905100))
				{
					text7 = Class16.smethod_0(1648936731);
				}
				if (!text6.StartsWith(Class16.smethod_0(1648902792)) && !text6.StartsWith(Class16.smethod_0(1648902778)) && num5 != 0)
				{
					for (int j = 1; j <= num5; j++)
					{
						list.Add(string.Format(Class16.smethod_0(1648985970), text7, j));
						list2.Add(text6);
					}
				}
				else
				{
					list.Add(text7);
					list2.Add(text6);
				}
			}
		}
		fieldNames[comboBox_1.SelectedIndex] = list.ToArray();
		fieldTypes[comboBox_1.SelectedIndex] = list2.ToArray();
		comboBox_1_SelectedIndexChanged(null, null);
	}

	private string method_9(string string_1, int int_0)
	{
		string_1 = string_1.Trim().ToLower();
		if (!(string_1 == Class16.smethod_0(1648989776)) && !(string_1 == Class16.smethod_0(1648985984)) && !(string_1 == Class16.smethod_0(1648986003)) && !(string_1 == Class16.smethod_0(1648986018)) && !(string_1 == Class16.smethod_0(1648986032)))
		{
			if (!(string_1 == Class16.smethod_0(1648986043)) && !(string_1 == Class16.smethod_0(1648986063)) && !(string_1 == Class16.smethod_0(1648986084)) && !(string_1 == Class16.smethod_0(1648986091)))
			{
				if (!(string_1 == Class16.smethod_0(1648986105)) && !(string_1 == Class16.smethod_0(1648985106)) && !(string_1 == Class16.smethod_0(1648985122)) && !(string_1 == Class16.smethod_0(1648985136)) && !(string_1 == Class16.smethod_0(1648985159)) && !(string_1 == Class16.smethod_0(1648989830)))
				{
					if (string_1 == Class16.smethod_0(1648902744))
					{
						return Class16.smethod_0(1648902744);
					}
					if (string_1 == Class16.smethod_0(1648989855))
					{
						return Class16.smethod_0(1648989855);
					}
					if (string_1.StartsWith(Class16.smethod_0(1648985163)))
					{
						return string.Format(Class16.smethod_0(1648985182), int_0);
					}
					if (string_1.StartsWith(Class16.smethod_0(1648985199)))
					{
						return string.Format(Class16.smethod_0(1648985214), int_0 * 2);
					}
					return Class16.smethod_0(1648908791);
				}
				return Class16.smethod_0(1648989830);
			}
			return Class16.smethod_0(1648989805);
		}
		return Class16.smethod_0(1648989776);
	}

	private void method_10(string string_1, int int_0, List<string> list_0, List<string> list_1, List<string> list_2, string string_2)
	{
		int num = list_2.FindIndex(Class125.class125_0.method_0) + 1;
		int num2 = list_2.FindLastIndex(Class125.class125_0.method_1) - 1;
		int num3 = ((int_0 <= 0) ? 1 : int_0);
		for (int i = 1; i <= num3; i++)
		{
			string text = string_2;
			if (!string.IsNullOrEmpty(string_1))
			{
				text = (string.IsNullOrEmpty(text) ? string.Format(Class16.smethod_0(1648985970), string_1, i) : (text + string.Format(Class16.smethod_0(1648985224), string_1, i)));
			}
			int j = num;
			while (j <= num2)
			{
				string text2 = list_2[j].Trim();
				if (text2.StartsWith(Class16.smethod_0(1648985965)))
				{
					List<string> list = new List<string>();
					int num4 = 0;
					bool flag = false;
					for (; j <= num2; j++)
					{
						string text3 = list_2[j].Trim();
						list.Add(text3);
						if (text3.Contains(Class16.smethod_0(1648908124)))
						{
							num4++;
							flag = true;
						}
						if (text3.Contains(Class16.smethod_0(1648908132)))
						{
							num4--;
							if (num4 == 0 && flag)
							{
								j++;
								break;
							}
						}
					}
					string text4 = string.Empty;
					for (; j <= num2; j++)
					{
						text4 = list_2[j].Trim();
						if (!string.IsNullOrEmpty(text4) && text4 != Class16.smethod_0(1648898262))
						{
							if (text4.EndsWith(Class16.smethod_0(1648898262)))
							{
								text4 = text4.Substring(0, text4.Length - 1);
							}
							break;
						}
					}
					string text5 = string.Empty;
					int int_1 = 0;
					if (!string.IsNullOrEmpty(text4))
					{
						string[] array = text4.Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
						if (array.Length != 0)
						{
							text5 = array[0];
							if (text5.Contains(Class16.smethod_0(1648924364)))
							{
								int num5 = text5.IndexOf(Class16.smethod_0(1648924364));
								int num6 = text5.IndexOf(Class16.smethod_0(1649008474));
								int_1 = int.Parse(text5.Substring(num5 + 1, num6 - num5 - 1));
								text5 = text5.Substring(0, num5);
							}
						}
					}
					method_10(text5, int_1, list_0, list_1, list, text);
				}
				else if (!text2.StartsWith(Class16.smethod_0(1648908124)) && !text2.StartsWith(Class16.smethod_0(1648908132)) && !(text2 == Class16.smethod_0(1648898262)))
				{
					if (text2.EndsWith(Class16.smethod_0(1648898262)))
					{
						text2 = text2.Substring(0, text2.Length - 1);
					}
					string[] array2 = text2.Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
					if (array2.Length >= 2)
					{
						string string_3 = string.Join(Class16.smethod_0(1648942211), array2.Take(array2.Length - 1));
						string text6 = array2[array2.Length - 1];
						int num7 = 0;
						if (text6.Contains(Class16.smethod_0(1648924364)))
						{
							int num8 = text6.IndexOf(Class16.smethod_0(1648924364));
							int num9 = text6.IndexOf(Class16.smethod_0(1649008474));
							num7 = int.Parse(text6.Substring(num8 + 1, num9 - num8 - 1));
							text6 = text6.Substring(0, num8);
						}
						string text7 = method_9(string_3, num7);
						string text8 = text + Class16.smethod_0(1648923968) + text6;
						if (!text7.StartsWith(Class16.smethod_0(1648902792)) && !text7.StartsWith(Class16.smethod_0(1648902778)))
						{
							int num10 = ((num7 <= 0) ? 1 : num7);
							for (int k = 1; k <= num10; k++)
							{
								string text9 = text8;
								if (num10 > 1)
								{
									text9 += string.Format(Class16.smethod_0(1648985247), k);
								}
								list_0.Add(text9);
								list_1.Add(text7);
							}
						}
						else
						{
							list_0.Add(text8);
							list_1.Add(text7);
						}
					}
					j++;
				}
				else
				{
					j++;
				}
			}
		}
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex <= -1 || dataGridView_0.SelectedCells == null)
		{
			return;
		}
		int num = -1;
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < dataGridView_0.SelectedCells.Count; i++)
		{
			bool flag = true;
			for (int j = 0; j < arrayList.Count; j++)
			{
				if ((int)arrayList[j] == dataGridView_0.SelectedCells[i].RowIndex)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				arrayList.Add(dataGridView_0.SelectedCells[i].RowIndex);
			}
		}
		arrayList.Sort();
		for (int num2 = arrayList.Count - 1; num2 > -1; num2--)
		{
			string[] array = new string[fieldNames[comboBox_1.SelectedIndex].Length - 1];
			Array.Copy(fieldNames[comboBox_1.SelectedIndex], 0, array, 0, (int)arrayList[num2]);
			Array.Copy(fieldNames[comboBox_1.SelectedIndex], (int)arrayList[num2] + 1, array, (int)arrayList[num2], fieldNames[comboBox_1.SelectedIndex].Length - 1 - (int)arrayList[num2]);
			fieldNames[comboBox_1.SelectedIndex] = array;
			array = new string[fieldTypes[comboBox_1.SelectedIndex].Length - 1];
			Array.Copy(fieldTypes[comboBox_1.SelectedIndex], 0, array, 0, (int)arrayList[num2]);
			Array.Copy(fieldTypes[comboBox_1.SelectedIndex], (int)arrayList[num2] + 1, array, (int)arrayList[num2], fieldTypes[comboBox_1.SelectedIndex].Length - 1 - (int)arrayList[num2]);
			fieldTypes[comboBox_1.SelectedIndex] = array;
		}
		comboBox_1_SelectedIndexChanged(null, null);
		if (dataGridView_0.Rows != null)
		{
			num = (int)arrayList[0] - 1;
		}
		if (num > -1)
		{
			dataGridView_0.CurrentCell = dataGridView_0.Rows[num].Cells[0];
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		string[] array = new string[listNames.Length + 1];
		Array.Copy(listNames, 0, array, 0, comboBox_1.SelectedIndex + 1);
		array[comboBox_1.SelectedIndex + 1] = Class16.smethod_0(1648985250);
		Array.Copy(listNames, comboBox_1.SelectedIndex + 1, array, comboBox_1.SelectedIndex + 2, listNames.Length - comboBox_1.SelectedIndex - 1);
		listNames = array;
		string[] array2 = new string[listOffsets.Length + 1];
		Array.Copy(listOffsets, 0, array2, 0, comboBox_1.SelectedIndex + 1);
		array2[comboBox_1.SelectedIndex + 1] = Class16.smethod_0(1648924112);
		Array.Copy(listOffsets, comboBox_1.SelectedIndex + 1, array2, comboBox_1.SelectedIndex + 2, listOffsets.Length - comboBox_1.SelectedIndex - 1);
		listOffsets = array2;
		string[][] array3 = new string[fieldNames.Length + 1][];
		Array.Copy(fieldNames, 0, array3, 0, comboBox_1.SelectedIndex + 1);
		array3[comboBox_1.SelectedIndex + 1] = new string[2]
		{
			Class16.smethod_0(1648941057),
			Class16.smethod_0(1648936731)
		};
		Array.Copy(fieldNames, comboBox_1.SelectedIndex + 1, array3, comboBox_1.SelectedIndex + 2, fieldNames.Length - comboBox_1.SelectedIndex - 1);
		fieldNames = array3;
		string[][] array4 = new string[fieldTypes.Length + 1][];
		Array.Copy(fieldTypes, 0, array4, 0, comboBox_1.SelectedIndex + 1);
		array4[comboBox_1.SelectedIndex + 1] = new string[2]
		{
			Class16.smethod_0(1648989776),
			Class16.smethod_0(1648985265)
		};
		Array.Copy(fieldTypes, comboBox_1.SelectedIndex + 1, array4, comboBox_1.SelectedIndex + 2, fieldTypes.Length - comboBox_1.SelectedIndex - 1);
		fieldTypes = array4;
		comboBox_1.Items.Add(Class16.smethod_0(1648924364) + (listNames.Length - 1) + Class16.smethod_0(1648985628) + listNames[listNames.Length - 1]);
		for (int i = 0; i < listNames.Length; i++)
		{
			comboBox_1.Items[i] = Class16.smethod_0(1648924364) + i + Class16.smethod_0(1648985628) + listNames[i];
		}
		comboBox_1.SelectedIndex += 1;
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex > -1)
		{
			int selectedIndex = comboBox_1.SelectedIndex;
			string[] destinationArray = new string[listOffsets.Length - 1];
			Array.Copy(listOffsets, 0, destinationArray, 0, selectedIndex);
			Array.Copy(listOffsets, selectedIndex + 1, destinationArray, selectedIndex, listOffsets.Length - 1 - selectedIndex);
			listOffsets = destinationArray;
			string[] destinationArray2 = new string[listNames.Length - 1];
			Array.Copy(listNames, 0, destinationArray2, 0, selectedIndex);
			Array.Copy(listNames, selectedIndex + 1, destinationArray2, selectedIndex, listNames.Length - 1 - selectedIndex);
			listNames = destinationArray2;
			string[][] destinationArray3 = new string[fieldNames.Length - 1][];
			Array.Copy(fieldNames, 0, destinationArray3, 0, selectedIndex);
			Array.Copy(fieldNames, selectedIndex + 1, destinationArray3, selectedIndex, fieldNames.Length - 1 - selectedIndex);
			fieldNames = destinationArray3;
			destinationArray3 = new string[fieldTypes.Length - 1][];
			Array.Copy(fieldTypes, 0, destinationArray3, 0, selectedIndex);
			Array.Copy(fieldTypes, selectedIndex + 1, destinationArray3, selectedIndex, fieldTypes.Length - 1 - selectedIndex);
			fieldTypes = destinationArray3;
			dataGridView_0.Rows.Clear();
			comboBox_1.Items.Clear();
			for (int i = 0; i < listNames.Length; i++)
			{
				comboBox_1.Items.Add(Class16.smethod_0(1648924364) + i + Class16.smethod_0(1648985628) + listNames[i]);
			}
			selectedIndex--;
			if (selectedIndex < 0 && comboBox_1.Items.Count > 0)
			{
				selectedIndex++;
			}
			comboBox_1.SelectedIndex = selectedIndex;
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < dataGridView_0.SelectedCells.Count; i++)
		{
			bool flag = true;
			for (int j = 0; j < arrayList.Count; j++)
			{
				if ((int)arrayList[j] == dataGridView_0.SelectedCells[i].RowIndex)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				arrayList.Add(dataGridView_0.SelectedCells[i].RowIndex);
			}
		}
		for (int k = 0; k < arrayList.Count; k++)
		{
			dataGridView_0.Rows[(int)arrayList[k]].Cells[0].Value = textBox_3.Text;
		}
		int num = method_12(comboBox_1.SelectedIndex);
		textBox_5.Text = num.ToString();
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < dataGridView_0.SelectedCells.Count; i++)
		{
			bool flag = true;
			for (int j = 0; j < arrayList.Count; j++)
			{
				if ((int)arrayList[j] == dataGridView_0.SelectedCells[i].RowIndex)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				arrayList.Add(dataGridView_0.SelectedCells[i].RowIndex);
			}
		}
		for (int k = 0; k < arrayList.Count; k++)
		{
			dataGridView_0.Rows[(int)arrayList[k]].Cells[1].Value = textBox_4.Text;
		}
		int num = method_12(comboBox_1.SelectedIndex);
		textBox_5.Text = num.ToString();
	}

	private void textBox_2_TextChanged(object sender, EventArgs e)
	{
		if (int.TryParse(textBox_2.Text, out var result))
		{
			conversationListIndex = result;
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex > -1)
		{
			listNames[comboBox_1.SelectedIndex] = textBox_0.Text;
			comboBox_1.Items[comboBox_1.SelectedIndex] = Class16.smethod_0(1648924364) + comboBox_1.SelectedIndex + Class16.smethod_0(1648985628) + textBox_0.Text;
		}
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		if (comboBox_1.SelectedIndex > -1)
		{
			listOffsets[comboBox_1.SelectedIndex] = textBox_1.Text;
		}
	}

	private int method_11(string string_1)
	{
		if (string_1 != null)
		{
			switch (string_1.Length)
			{
			case 3:
				if (!(string_1 == Class16.smethod_0(1648989776)))
				{
					break;
				}
				goto IL_00c3;
			case 4:
				if (!(string_1 == Class16.smethod_0(1648989786)))
				{
					break;
				}
				goto IL_00c3;
			case 5:
			{
				char c = string_1[3];
				if ((uint)c <= 51u)
				{
					if (c == '1')
					{
						if (!(string_1 == Class16.smethod_0(1648989805)))
						{
							break;
						}
						goto IL_0105;
					}
					if (c != '3' || !(string_1 == Class16.smethod_0(1648902717)))
					{
						break;
					}
				}
				else
				{
					if (c == '6')
					{
						if (!(string_1 == Class16.smethod_0(1648989830)))
						{
							break;
						}
						goto IL_011f;
					}
					if (c != 'a' || !(string_1 == Class16.smethod_0(1648902744)))
					{
						break;
					}
				}
				goto IL_00c3;
			}
			case 6:
				{
					char c = string_1[0];
					if (c != 'd')
					{
						if (c != 'u' || !(string_1 == Class16.smethod_0(1648989809)))
						{
							break;
						}
						goto IL_0105;
					}
					if (!(string_1 == Class16.smethod_0(1648989855)))
					{
						break;
					}
					goto IL_011f;
				}
				IL_011f:
				GC.KeepAlive(this);
				return 8;
				IL_0105:
				GC.KeepAlive(this);
				return 2;
				IL_00c3:
				GC.KeepAlive(this);
				return 4;
			}
		}
		if (string_1.Contains(Class16.smethod_0(1648985282)))
		{
			if (int.TryParse(string_1.Split(':')[1], out var result))
			{
				GC.KeepAlive(this);
				return result;
			}
			GC.KeepAlive(this);
			return 0;
		}
		if (string_1.Contains(Class16.smethod_0(1648985302)))
		{
			if (int.TryParse(string_1.Split(':')[1], out var result2))
			{
				GC.KeepAlive(this);
				return result2;
			}
			GC.KeepAlive(this);
			return 0;
		}
		if (string_1.Contains(Class16.smethod_0(1648985317)))
		{
			if (int.TryParse(string_1.Split(':')[1], out var result3))
			{
				GC.KeepAlive(this);
				return result3;
			}
			GC.KeepAlive(this);
			return 0;
		}
		GC.KeepAlive(this);
		return 0;
	}

	private int method_12(int int_0)
	{
		int num = 0;
		for (int i = 0; i < fieldTypes[int_0].Length; i++)
		{
			num += method_11(fieldTypes[int_0][i]);
		}
		return num;
	}

	private ScanInfo[] method_13(string string_1)
	{
		if (listNames != null && File.Exists(string_1))
		{
			StreamReader streamReader = new StreamReader(string_1);
			ScanInfo[] array = new ScanInfo[listNames.Length];
			int num = 0;
			while (num < array.Length)
			{
				try
				{
					string text = streamReader.ReadLine();
					if (!text.StartsWith(Class16.smethod_0(1648929947)))
					{
						ScanInfo scanInfo = new ScanInfo();
						scanInfo.EntrySizePrior = -1;
						scanInfo.EntrySizeEstimated = -1;
						if (num != conversationListIndex)
						{
							scanInfo.EntrySizePrior = method_12(num);
						}
						if (text == Class16.smethod_0(1649014110))
						{
							scanInfo.FirstElementID = -1;
						}
						else
						{
							scanInfo.FirstElementID = Convert.ToInt32(text);
						}
						text = streamReader.ReadLine();
						if (text == Class16.smethod_0(1649014110))
						{
							scanInfo.SecondElementID = -1;
						}
						else
						{
							scanInfo.SecondElementID = Convert.ToInt32(text);
						}
						array[num] = scanInfo;
						num++;
					}
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1648985323));
					ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
				}
			}
			streamReader.Close();
			for (int i = num; i < array.Length; i++)
			{
				ScanInfo scanInfo = new ScanInfo();
				scanInfo.EntrySizePrior = method_12(i);
				scanInfo.FirstElementID = -1;
				scanInfo.SecondElementID = -1;
				array[i] = scanInfo;
			}
			return array;
		}
		return null;
	}

	private void method_14(int int_0, int int_1, BinaryReader binaryReader_0)
	{
		string text = listOffsets[int_1];
		if (loadedConfFileName.EndsWith(Class16.smethod_0(1648985381)) && int_0 > 8)
		{
			if (int_1 == 0)
			{
				text = Class16.smethod_0(1648935001);
			}
			if (int_1 == 20 || int_1 == 100)
			{
				text = Class16.smethod_0(1648902775);
			}
		}
		if (!(text != string.Empty) || !(text != Class16.smethod_0(1648924112)))
		{
			return;
		}
		if (text == Class16.smethod_0(1648902775))
		{
			if (int_1 == 0)
			{
				binaryReader_0.ReadBytes(4);
				int count = binaryReader_0.ReadInt32();
				binaryReader_0.ReadBytes(count);
			}
			if (int_1 == 20)
			{
				binaryReader_0.ReadBytes(4);
				int count2 = binaryReader_0.ReadInt32();
				binaryReader_0.ReadBytes(count2);
				binaryReader_0.ReadBytes(4);
			}
			int num = 100;
			if (int_0 >= 191)
			{
				num = 99;
			}
			if (int_1 == num)
			{
				binaryReader_0.ReadBytes(4);
				int count3 = binaryReader_0.ReadInt32();
				binaryReader_0.ReadBytes(count3);
			}
		}
		else
		{
			binaryReader_0.ReadBytes(Convert.ToInt32(text));
		}
	}

	private void method_15(int int_0, BinaryReader binaryReader_0)
	{
		if (fieldTypes[int_0][0].Contains(Class16.smethod_0(1648902775)))
		{
			string s = Class16.smethod_0(1648985387);
			byte[] bytes = Encoding.GetEncoding(Class16.smethod_0(1648985403)).GetBytes(s);
			_ = binaryReader_0.BaseStream.Position;
			while (true)
			{
				int num = 0;
				if (0 >= (nint)bytes.LongLength)
				{
					break;
				}
				while (true)
				{
					byte b = bytes[num];
					if (binaryReader_0.ReadByte() != b)
					{
						break;
					}
					num++;
					if (num >= (nint)bytes.LongLength)
					{
						goto end_IL_0067;
					}
				}
				continue;
				end_IL_0067:
				break;
			}
			Stream baseStream = binaryReader_0.BaseStream;
			long num2 = (nint)bytes.LongLength + 72;
			baseStream.Position -= num2;
		}
		else
		{
			char[] separator = new char[1] { ':' };
			Stream baseStream2 = binaryReader_0.BaseStream;
			int num3 = Convert.ToInt32(fieldTypes[int_0][0].Split(separator)[0]);
			long num4 = Convert.ToInt32(listOffsets[int_0]) + num3;
			baseStream2.Position += num4;
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_5_Click(object sender, EventArgs e)
	{
		string text = Class16.smethod_0(1648985421);
		ScanInfo[] array = method_13(Application.StartupPath + text);
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1648985455);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			StreamReader streamReader = new StreamReader(openFileDialog.FileName);
			BinaryReader binaryReader = new BinaryReader(streamReader.BaseStream);
			short num = binaryReader.ReadInt16();
			binaryReader.ReadInt16();
			string empty = string.Empty;
			string text2 = Class16.smethod_0(1648924428);
			empty = string.Concat(empty, string.Concat(Class16.smethod_0(1648985472) + loadedConfFileName, text2));
			short num2 = num;
			text2 = Class16.smethod_0(1648898460);
			empty = string.Concat(empty, string.Concat(Class16.smethod_0(1648985499) + num2, text2));
			int num3 = 0;
			if (0 < (nint)listNames.LongLength)
			{
				int num4 = 1;
				do
				{
					method_14(num, num3, binaryReader);
					string text3;
					if (num3 == conversationListIndex)
					{
						method_15(num3, binaryReader);
						int num5 = num3;
						text3 = Class16.smethod_0(1648985528);
						empty = string.Concat(empty, num5.ToString(Class16.smethod_0(1648902328)) + text3);
						num3++;
						num4++;
					}
					int num6 = num3;
					text3 = Class16.smethod_0(1648924402);
					empty = string.Concat(empty, num6.ToString(Class16.smethod_0(1648902328)) + text3);
					array[num3].ElementCount = binaryReader.ReadInt32();
					long position = binaryReader.BaseStream.Position;
					ScanInfo scanInfo = array[num3];
					if (scanInfo.ElementCount > 0)
					{
						if (scanInfo.FirstElementID > -1)
						{
							if (scanInfo.SecondElementID > -1)
							{
								binaryReader.ReadBytes(scanInfo.EntrySizePrior);
								ScanInfo scanInfo2 = array[num3];
								scanInfo2.EntrySizeEstimated = scanInfo2.EntrySizePrior;
								ScanInfo scanInfo3 = array[num3];
								int secondElementID = scanInfo3.SecondElementID;
								if (binaryReader.ReadInt32() != secondElementID)
								{
									do
									{
										scanInfo3.EntrySizeEstimated++;
										binaryReader.BaseStream.Position -= 3L;
										scanInfo3 = array[num3];
										secondElementID = scanInfo3.SecondElementID;
									}
									while (binaryReader.BaseStream.Position + 4L <= binaryReader.BaseStream.Length && binaryReader.ReadInt32() != secondElementID);
								}
								ScanInfo scanInfo4 = array[num3];
								long position2 = scanInfo4.EntrySizeEstimated * scanInfo4.ElementCount + position;
								binaryReader.BaseStream.Position = position2;
								scanInfo4 = array[num3];
								secondElementID = scanInfo4.EntrySizePrior;
								int entrySizeEstimated = scanInfo4.EntrySizeEstimated;
								if (secondElementID != entrySizeEstimated)
								{
									int num7 = entrySizeEstimated - secondElementID;
									int num8 = entrySizeEstimated;
									int num9 = secondElementID;
									string text4 = Class16.smethod_0(1648942897);
									string text5 = Class16.smethod_0(1648985574);
									string text6 = Class16.smethod_0(1648985576);
									empty = string.Concat(empty, string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648985587) + num9, text6), num8.ToString()), text5), num7.ToString()), text4));
								}
								else
								{
									empty += Class16.smethod_0(1648922929);
								}
							}
							else if (num3 < (nint)array.LongLength - 1)
							{
								if (array[num4].FirstElementID <= -1)
								{
									empty += Class16.smethod_0(1648984602);
									break;
								}
								if (!(listOffsets[num4] == Class16.smethod_0(1648902775)) && ((num4 != 20 && num4 != 100) || num <= 8 || !loadedConfFileName.EndsWith(Class16.smethod_0(1648985381))))
								{
									Stream baseStream = binaryReader.BaseStream;
									ScanInfo scanInfo5 = array[num3];
									long num10 = scanInfo5.EntrySizePrior * scanInfo5.ElementCount;
									baseStream.Position += num10;
									int firstElementID = array[num4].FirstElementID;
									if (binaryReader.ReadInt32() != firstElementID)
									{
										do
										{
											binaryReader.BaseStream.Position -= 3L;
											firstElementID = array[num4].FirstElementID;
										}
										while (binaryReader.BaseStream.Position + 4L <= binaryReader.BaseStream.Length && binaryReader.ReadInt32() != firstElementID);
									}
									Stream baseStream2 = binaryReader.BaseStream;
									long num11 = Convert.ToInt32(listOffsets[num4]) + 8;
									baseStream2.Position -= num11;
									long num12 = binaryReader.BaseStream.Position - position;
									ScanInfo scanInfo6 = array[num3];
									scanInfo6.EntrySizeEstimated = (int)(num12 / scanInfo6.ElementCount);
									scanInfo6 = array[num3];
									int entrySizePrior = scanInfo6.EntrySizePrior;
									int entrySizeEstimated2 = scanInfo6.EntrySizeEstimated;
									if (entrySizePrior != entrySizeEstimated2)
									{
										int num13 = entrySizeEstimated2 - entrySizePrior;
										int num14 = entrySizeEstimated2;
										int num15 = entrySizePrior;
										string text7 = Class16.smethod_0(1648942897);
										string text8 = Class16.smethod_0(1648985574);
										string text9 = Class16.smethod_0(1648985576);
										empty = string.Concat(empty, string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648985587) + num15, text9), num14.ToString()), text8), num13.ToString()), text7));
									}
									else
									{
										empty += Class16.smethod_0(1648922929);
									}
								}
								else
								{
									int num16 = num3;
									string caption = listNames[num3];
									string text10 = Class16.smethod_0(1648984666);
									if (DKBox.Show(string.Concat(Class16.smethod_0(1648984847) + num16, text10), caption, MessageBoxButtons.YesNo) != DialogResult.Yes)
									{
										empty += Class16.smethod_0(1648984858);
										break;
									}
									ScanInfo scanInfo7 = array[num3];
									scanInfo7.EntrySizeEstimated = scanInfo7.EntrySizePrior;
									ScanInfo scanInfo8 = array[num3];
									long position3 = scanInfo8.EntrySizeEstimated * scanInfo8.ElementCount + position;
									binaryReader.BaseStream.Position = position3;
									string text11 = Class16.smethod_0(1648942897);
									empty = string.Concat(empty, string.Concat(Class16.smethod_0(1648984919) + array[num3].EntrySizeEstimated, text11));
								}
							}
							else
							{
								Stream baseStream3 = binaryReader.BaseStream;
								ScanInfo scanInfo9 = array[num3];
								long num17 = scanInfo9.EntrySizePrior * scanInfo9.ElementCount;
								baseStream3.Position += num17;
								if (binaryReader.BaseStream.Length != binaryReader.BaseStream.Position)
								{
									empty += Class16.smethod_0(1648984980);
									break;
								}
								ScanInfo scanInfo10 = array[num3];
								scanInfo10.EntrySizeEstimated = scanInfo10.EntrySizePrior;
								string text12 = Class16.smethod_0(1648942897);
								empty = string.Concat(empty, string.Concat(Class16.smethod_0(1648984919) + array[num3].EntrySizeEstimated, text12));
							}
						}
						else
						{
							if (num3 < (nint)array.LongLength - 1)
							{
								empty = ((array[num3 + 1].FirstElementID <= -1) ? (empty + Class16.smethod_0(1648984602)) : (empty + Class16.smethod_0(1648985046)));
								break;
							}
							Stream baseStream4 = binaryReader.BaseStream;
							ScanInfo scanInfo11 = array[num3];
							long num18 = scanInfo11.EntrySizePrior * scanInfo11.ElementCount;
							baseStream4.Position += num18;
							if (binaryReader.BaseStream.Length != binaryReader.BaseStream.Position)
							{
								empty += Class16.smethod_0(1648984980);
								break;
							}
							ScanInfo scanInfo12 = array[num3];
							scanInfo12.EntrySizeEstimated = scanInfo12.EntrySizePrior;
							string text13 = Class16.smethod_0(1648942897);
							empty = string.Concat(empty, string.Concat(Class16.smethod_0(1648984919) + array[num3].EntrySizeEstimated, text13));
						}
					}
					else
					{
						empty += Class16.smethod_0(1648985075);
					}
					empty += Class16.smethod_0(1648924428);
					num3++;
					num4++;
				}
				while (num3 < (nint)listNames.LongLength);
			}
			long num19 = binaryReader.BaseStream.Length - binaryReader.BaseStream.Position;
			empty = string.Concat(empty, Class16.smethod_0(1648984087) + num19);
			binaryReader.Close();
			streamReader.Close();
			new DebugWindow(Class16.smethod_0(1648984108), empty);
		}
		GC.KeepAlive(this);
	}
}
