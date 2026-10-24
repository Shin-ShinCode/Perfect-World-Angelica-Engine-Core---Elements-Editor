using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements;
using ACE.Properties;

namespace ACE.DynamicObjects;

public class DynamicObjectsEditorForm : Form
{
	public DYNAMICOBJECTS_DATA DynData;

	public bool DontChange;

	public CommonStorage CStorage;

	public bool FileLoaded;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private TextBox textBox_0;

	private Button button_0;

	private Button button_1;

	private Label label_0;

	private DataGridView dataGridView_0;

	private Button button_2;

	private Button button_3;

	private Label label_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private Button button_4;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private Button button_5;

	private Label label_2;

	private Button button_6;

	private Button button_7;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripMenuItem toolStripMenuItem_5;

	private GroupBox groupBox_0;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_6;

	private ToolStripMenuItem toolStripMenuItem_7;

	private ToolStripMenuItem toolStripMenuItem_8;

	private ToolStripMenuItem toolStripMenuItem_9;

	private IContainer icontainer_0;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private bool bool_0;

	private Button button_8;

	private Button button_9;

	public DynamicObjectsEditorForm(CommonStorage CStorage)
	{
		try
		{
			method_6();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			this.CStorage = CStorage;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			DontChange = false;
			FileLoaded = false;
			method_16();
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void method_0()
	{
		try
		{
			fileBasedUndoManager_0?.Dispose();
		}
		catch
		{
		}
		fileBasedUndoManager_0 = null;
	}

	public void OpenFile(string fileName)
	{
		if (!string.IsNullOrWhiteSpace(fileName) && File.Exists(fileName))
		{
			try
			{
				DynData = new DYNAMICOBJECTS_DATA(fileName);
			}
			catch
			{
			}
			if (DynData != null && DynData.Entries != null)
			{
				method_1();
			}
		}
	}

	private void method_1()
	{
		FileLoaded = false;
		textBox_0.Text = DynData.fn;
		button_0.Enabled = false;
		dataGridView_0.Enabled = true;
		button_3.Enabled = true;
		button_6.Enabled = true;
		contextMenuStrip_0.Enabled = true;
		textBox_1.Text = smethod_0(DynData.TimeStamp);
		dataGridViewTextBoxColumn_2.Visible = DynData.ReservedFieldCount >= 1;
		dataGridViewTextBoxColumn_3.Visible = DynData.ReservedFieldCount >= 2;
		DontChange = true;
		dataGridView_0.Rows.Clear();
		int count = DynData.Entries.Count;
		DataGridViewRow[] array = new DataGridViewRow[count];
		for (int i = 0; i < count; i++)
		{
			DYNAMICOBJECTS_DATA.Entry entry = DynData.Entries[i];
			DataGridViewRow dataGridViewRow = new DataGridViewRow();
			dataGridViewRow.Resizable = DataGridViewTriState.False;
			dataGridViewRow.CreateCells(dataGridView_0);
			dataGridViewRow.Cells[0].Value = entry.Id.ToString();
			dataGridViewRow.Cells[1].Value = entry.Path ?? string.Empty;
			dataGridViewRow.Cells[2].Value = entry.Reserved1.ToString();
			dataGridViewRow.Cells[3].Value = entry.Reserved2.ToString();
			dataGridViewRow.Tag = entry.Id;
			array[i] = dataGridViewRow;
		}
		if (array.Length != 0)
		{
			dataGridView_0.Rows.AddRange(array);
		}
		DontChange = false;
		FileLoaded = true;
		if (!bool_0)
		{
			method_22();
		}
		GC.KeepAlive(this);
	}

	private static string smethod_0(uint uint_0)
	{
		try
		{
			byte[] bytes = BitConverter.GetBytes(uint_0);
			string text = Encoding.ASCII.GetString(bytes);
			bool flag = true;
			foreach (char c in text)
			{
				if (c < ' ' || c > '~')
				{
					flag = false;
					break;
				}
			}
			string text2 = uint_0.ToString(Class16.smethod_0(1648997405));
			return flag ? (text + Class16.smethod_0(1648997414) + text2 + Class16.smethod_0(1648942897)) : (Class16.smethod_0(1648917675) + text2);
		}
		catch
		{
			return uint_0.ToString();
		}
	}

	private void method_2()
	{
		if (DynData != null)
		{
			DynData.Save();
			button_0.Enabled = false;
			GC.KeepAlive(this);
		}
	}

	private void method_3()
	{
		button_0.Enabled = true;
		if (DynData != null)
		{
			DynData.FileChanged = true;
		}
	}

	private void method_4()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		try
		{
			openFileDialog.Filter = TextStorage.Msg(Class16.smethod_0(1648997417), Class16.smethod_0(1648997450));
			openFileDialog.FileName = TextStorage.Msg(Class16.smethod_0(1648997548), Class16.smethod_0(1648997579));
			if (openFileDialog.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog.FileName))
			{
				try
				{
					DynData = new DYNAMICOBJECTS_DATA(openFileDialog.FileName);
				}
				catch
				{
				}
				if (DynData != null && DynData.Entries != null)
				{
					method_1();
				}
				else
				{
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648997613)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			GC.KeepAlive(this);
		}
		finally
		{
			((IDisposable)openFileDialog).Dispose();
		}
	}

	private void toolStripMenuItem_7_Click(object sender, EventArgs e)
	{
		method_4();
	}

	private void toolStripMenuItem_8_Click(object sender, EventArgs e)
	{
		method_2();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_4();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_2();
	}

	private void DynamicObjectsEditorForm_Load(object sender, EventArgs e)
	{
		if (DynData != null && DynData.Entries != null && !FileLoaded)
		{
			method_1();
		}
	}

	private void DynamicObjectsEditorForm_Shown(object sender, EventArgs e)
	{
		if (DynData == null || DynData.Entries == null)
		{
			method_4();
		}
	}

	private void DynamicObjectsEditorForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		DYNAMICOBJECTS_DATA dynData = DynData;
		if (dynData != null && dynData.FileChanged)
		{
			switch (DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648997634), Class16.smethod_0(1648997679)), TextStorage.Msg(Class16.smethod_0(1649002823), Class16.smethod_0(1648997745)), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
			case DialogResult.Cancel:
				e.Cancel = true;
				return;
			case DialogResult.Yes:
			{
				method_2();
				DYNAMICOBJECTS_DATA dynData2 = DynData;
				if (dynData2 != null && dynData2.FileChanged)
				{
					e.Cancel = true;
					return;
				}
				break;
			}
			}
		}
		method_0();
		GC.KeepAlive(this);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		object obj;
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			object value = dataGridView_0[0, dataGridView_0.SelectedRows[0].Index].Value;
			if (value == null)
			{
				obj = null;
			}
			else
			{
				obj = value.ToString();
				if (obj != null)
				{
					goto IL_004f;
				}
			}
			obj = string.Empty;
			goto IL_004f;
		}
		goto IL_0054;
		IL_004f:
		CommonStorage.sData = (string)obj;
		goto IL_0054;
		IL_0054:
		Close();
	}

	private void method_5()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_6()
	{
		icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(DynamicObjectsEditorForm));
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_6 = new ToolStripMenuItem();
		toolStripMenuItem_7 = new ToolStripMenuItem();
		toolStripMenuItem_8 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		textBox_0 = new TextBox();
		button_0 = new Button();
		button_1 = new Button();
		label_0 = new Label();
		groupBox_0 = new GroupBox();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		contextMenuStrip_0 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		toolStripMenuItem_5 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripSeparator_1 = new ToolStripSeparator();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		button_2 = new Button();
		button_3 = new Button();
		label_1 = new Label();
		button_4 = new Button();
		textBox_1 = new TextBox();
		textBox_2 = new TextBox();
		button_5 = new Button();
		label_2 = new Label();
		button_6 = new Button();
		button_7 = new Button();
		menuStrip_0.SuspendLayout();
		groupBox_0.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		contextMenuStrip_0.SuspendLayout();
		SuspendLayout();
		menuStrip_0.BackColor = SystemColors.InactiveBorder;
		menuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		menuStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripMenuItem_6 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1649009132);
		menuStrip_0.Padding = new Padding(0, 2, 2, 2);
		menuStrip_0.RenderMode = ToolStripRenderMode.Professional;
		menuStrip_0.Size = new Size(1006, 24);
		menuStrip_0.TabIndex = 0;
		menuStrip_0.Text = Class16.smethod_0(1649012229);
		menuStrip_0.Visible = false;
		toolStripMenuItem_6.DropDownItems.AddRange(new ToolStripItem[4] { toolStripMenuItem_7, toolStripMenuItem_8, toolStripSeparator_0, toolStripMenuItem_0 });
		toolStripMenuItem_6.ImageScaling = ToolStripItemImageScaling.None;
		toolStripMenuItem_6.Name = Class16.smethod_0(1649012245);
		toolStripMenuItem_6.Padding = new Padding(0);
		toolStripMenuItem_6.Size = new Size(29, 20);
		toolStripMenuItem_6.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_6.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_7.BackgroundImageLayout = ImageLayout.None;
		toolStripMenuItem_7.ImageAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_7.Name = Class16.smethod_0(1648920856);
		toolStripMenuItem_7.ShortcutKeys = Keys.O | Keys.Control;
		toolStripMenuItem_7.Size = new Size(146, 22);
		toolStripMenuItem_7.Text = Class16.smethod_0(1648931498);
		toolStripMenuItem_7.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_7.Click += toolStripMenuItem_7_Click;
		toolStripMenuItem_8.Name = Class16.smethod_0(1648920878);
		toolStripMenuItem_8.ShortcutKeys = Keys.S | Keys.Control;
		toolStripMenuItem_8.Size = new Size(146, 22);
		toolStripMenuItem_8.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_8.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_8.Click += toolStripMenuItem_8_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1649012270);
		toolStripSeparator_0.Size = new Size(143, 6);
		toolStripMenuItem_0.Name = Class16.smethod_0(1648920908);
		toolStripMenuItem_0.Size = new Size(146, 22);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648920914);
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.BackColor = Color.White;
		textBox_0.Location = new Point(72, 13);
		textBox_0.Name = Class16.smethod_0(1649003008);
		textBox_0.ReadOnly = true;
		textBox_0.Size = new Size(381, 22);
		textBox_0.TabIndex = 36;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_0.Enabled = false;
		button_0.Image = Resources.cmdSave;
		button_0.Location = new Point(564, 11);
		button_0.Name = Class16.smethod_0(1648920967);
		button_0.Size = new Size(102, 25);
		button_0.TabIndex = 38;
		button_0.Text = Class16.smethod_0(1648941761);
		button_0.TextAlign = ContentAlignment.MiddleRight;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_1.Image = Resources.cmdOpen;
		button_1.Location = new Point(459, 11);
		button_1.Name = Class16.smethod_0(1648920945);
		button_1.Size = new Size(102, 25);
		button_1.TabIndex = 39;
		button_1.Text = Class16.smethod_0(1648931498);
		button_1.TextAlign = ContentAlignment.MiddleRight;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_0.Location = new Point(38, 16);
		label_0.Name = Class16.smethod_0(1648893046);
		label_0.Size = new Size(28, 15);
		label_0.TabIndex = 72;
		label_0.Text = Class16.smethod_0(1648916193);
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(button_1);
		groupBox_0.Controls.Add(textBox_0);
		groupBox_0.Controls.Add(button_0);
		groupBox_0.Location = new Point(3, -3);
		groupBox_0.Name = Class16.smethod_0(1648929126);
		groupBox_0.Size = new Size(670, 41);
		groupBox_0.TabIndex = 80;
		groupBox_0.TabStop = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_0.BackgroundColor = Color.White;
		dataGridView_0.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_0.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1, dataGridViewTextBoxColumn_2, dataGridViewTextBoxColumn_3);
		dataGridView_0.ContextMenuStrip = contextMenuStrip_0;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.White;
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = Color.Black;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = Color.White;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.Enabled = false;
		dataGridView_0.GridColor = Color.Silver;
		dataGridView_0.Location = new Point(3, 97);
		dataGridView_0.Margin = new Padding(3, 4, 3, 4);
		dataGridView_0.Name = Class16.smethod_0(1648997775);
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
		dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridView_0.RowTemplate.Height = 20;
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellToolTips = false;
		dataGridView_0.Size = new Size(670, 426);
		dataGridView_0.TabIndex = 106;
		dataGridView_0.CellDoubleClick += dataGridView_0_CellDoubleClick;
		dataGridView_0.CellValueChanged += dataGridView_0_CellValueChanged;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle4.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Bold);
		dataGridViewCellStyle4.ForeColor = Color.Maroon;
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648929955);
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 70;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle5.ForeColor = Color.Black;
		dataGridViewTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle5;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648893060);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648997790);
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle6;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648997804);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648997811);
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_2.Width = 70;
		dataGridViewTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle6;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648997837);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1648997853);
		dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_3.Width = 70;
		toolStripMenuItem_9 = new ToolStripMenuItem();
		contextMenuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		contextMenuStrip_0.Items.AddRange(new ToolStripItem[7] { toolStripMenuItem_1, toolStripMenuItem_4, toolStripMenuItem_5, toolStripMenuItem_9, toolStripMenuItem_2, toolStripSeparator_1, toolStripMenuItem_3 });
		contextMenuStrip_0.Name = Class16.smethod_0(1649003266);
		contextMenuStrip_0.Size = new Size(202, 120);
		toolStripMenuItem_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		toolStripMenuItem_1.Name = Class16.smethod_0(1649003303);
		toolStripMenuItem_1.ShortcutKeys = Keys.N | Keys.Control;
		toolStripMenuItem_1.Size = new Size(201, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648931361);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_4.Name = Class16.smethod_0(1648997864);
		toolStripMenuItem_4.Size = new Size(201, 22);
		toolStripMenuItem_4.Text = Class16.smethod_0(1648996866);
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		toolStripMenuItem_5.Name = Class16.smethod_0(1648996896);
		toolStripMenuItem_5.Size = new Size(201, 22);
		toolStripMenuItem_5.Text = Class16.smethod_0(1648996932);
		toolStripMenuItem_5.Click += toolStripMenuItem_5_Click;
		toolStripMenuItem_9.Name = Class16.smethod_0(1648996959);
		toolStripMenuItem_9.Size = new Size(201, 22);
		toolStripMenuItem_9.Text = Class16.smethod_0(1648996970);
		toolStripMenuItem_9.Click += toolStripMenuItem_9_Click;
		toolStripMenuItem_2.Enabled = false;
		toolStripMenuItem_2.Name = Class16.smethod_0(1649003348);
		toolStripMenuItem_2.ShortcutKeys = Keys.Delete;
		toolStripMenuItem_2.Size = new Size(201, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648925718);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripSeparator_1.Name = Class16.smethod_0(1649004015);
		toolStripSeparator_1.Size = new Size(198, 6);
		toolStripMenuItem_3.Enabled = false;
		toolStripMenuItem_3.Name = Class16.smethod_0(1648996987);
		toolStripMenuItem_3.Size = new Size(201, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1648931384);
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_2.Enabled = false;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 9f);
		button_2.Image = Resources.cmdDelete;
		button_2.Location = new Point(339, 526);
		button_2.Name = Class16.smethod_0(1649003416);
		button_2.Size = new Size(334, 25);
		button_2.TabIndex = 108;
		button_2.Text = Class16.smethod_0(1648925718);
		button_2.TextAlign = ContentAlignment.MiddleRight;
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_3.Enabled = false;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 9f);
		button_3.Image = Resources.cmdAdd;
		button_3.Location = new Point(3, 526);
		button_3.Name = Class16.smethod_0(1648926646);
		button_3.Size = new Size(334, 25);
		button_3.TabIndex = 107;
		button_3.Text = Class16.smethod_0(1648931361);
		button_3.TextAlign = ContentAlignment.MiddleRight;
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		label_1.AutoSize = true;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_1.Location = new Point(4, 43);
		label_1.Name = Class16.smethod_0(1649003044);
		label_1.Size = new Size(60, 15);
		label_1.TabIndex = 110;
		label_1.Text = Class16.smethod_0(1648997003);
		button_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_4.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Underline);
		button_4.Image = Resources.cmdClose;
		button_4.Location = new Point(3, 553);
		button_4.Name = Class16.smethod_0(1649003432);
		button_4.Size = new Size(670, 37);
		button_4.TabIndex = 112;
		button_4.Text = Class16.smethod_0(1649014457);
		button_4.TextAlign = ContentAlignment.MiddleRight;
		button_4.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.BackColor = Color.White;
		textBox_1.Font = new Font(Class16.smethod_0(1648942905), 10f);
		textBox_1.Location = new Point(75, 40);
		textBox_1.Name = Class16.smethod_0(1649003028);
		textBox_1.ReadOnly = true;
		textBox_1.Size = new Size(381, 25);
		textBox_1.TabIndex = 135;
		textBox_1.TextAlign = HorizontalAlignment.Center;
		textBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_2.BackColor = Color.White;
		textBox_2.Location = new Point(75, 70);
		textBox_2.Name = Class16.smethod_0(1648919457);
		textBox_2.Size = new Size(381, 22);
		textBox_2.TabIndex = 136;
		button_5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_5.Image = Resources.cmdFindNext;
		button_5.Location = new Point(462, 68);
		button_5.Name = Class16.smethod_0(1649003485);
		button_5.Size = new Size(211, 25);
		button_5.TabIndex = 137;
		button_5.Text = Class16.smethod_0(1648997028);
		button_5.TextAlign = ContentAlignment.MiddleRight;
		button_5.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		label_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_2.Location = new Point(12, 72);
		label_2.Name = Class16.smethod_0(1649003455);
		label_2.Size = new Size(60, 15);
		label_2.TabIndex = 138;
		label_2.Text = Class16.smethod_0(1649003471);
		label_2.TextAlign = ContentAlignment.MiddleRight;
		button_6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_6.Enabled = false;
		button_6.Image = Resources.cmdImport;
		button_6.Location = new Point(462, 40);
		button_6.Name = Class16.smethod_0(1648997044);
		button_6.Size = new Size(102, 25);
		button_6.TabIndex = 139;
		button_6.Text = Class16.smethod_0(1648931405);
		button_6.TextAlign = ContentAlignment.MiddleRight;
		button_6.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		button_7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_7.Enabled = false;
		button_7.Image = Resources.cmdExport;
		button_7.Location = new Point(571, 39);
		button_7.Name = Class16.smethod_0(1648997060);
		button_7.Size = new Size(102, 25);
		button_7.TabIndex = 140;
		button_7.Text = Class16.smethod_0(1648931384);
		button_7.TextAlign = ContentAlignment.MiddleRight;
		button_7.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		base.AcceptButton = button_4;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(675, 593);
		base.Controls.Add(button_7);
		base.Controls.Add(button_6);
		base.Controls.Add(label_2);
		base.Controls.Add(button_5);
		base.Controls.Add(textBox_2);
		base.Controls.Add(textBox_1);
		base.Controls.Add(button_4);
		base.Controls.Add(dataGridView_0);
		base.Controls.Add(label_1);
		base.Controls.Add(button_2);
		base.Controls.Add(button_3);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(menuStrip_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.edit;
		base.MainMenuStrip = menuStrip_0;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.Name = Class16.smethod_0(1648997076);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648997099);
		base.FormClosing += DynamicObjectsEditorForm_FormClosing;
		base.Load += DynamicObjectsEditorForm_Load;
		base.Shown += DynamicObjectsEditorForm_Shown;
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		((ISupportInitialize)dataGridView_0).EndInit();
		contextMenuStrip_0.ResumeLayout(performLayout: false);
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

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_2.Enabled = b != 0;
		toolStripMenuItem_2.Enabled = b != 0;
		button_7.Enabled = b != 0;
		toolStripMenuItem_3.Enabled = b != 0;
		if (CommonStorage.License.Special.ModelPreview && CommonStorage.Params.ShowModelPreview)
		{
			method_13();
		}
		GC.KeepAlive(this);
	}

	private bool method_7(uint uint_0, int int_0)
	{
		if (DynData?.Entries == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < DynData.Entries.Count)
			{
				if (num != int_0 && DynData.Entries[num].Id == uint_0)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private uint method_8()
	{
		uint num = 0u;
		if (DynData?.Entries != null)
		{
			for (int i = 0; i < DynData.Entries.Count; i++)
			{
				uint id = DynData.Entries[i].Id;
				if (id > num)
				{
					num = id;
				}
			}
		}
		uint num2 = num;
		do
		{
			num2++;
		}
		while (method_7(num2, -1));
		return num2;
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int rowIndex = e.RowIndex;
		int columnIndex = e.ColumnIndex;
		if (rowIndex < 0)
		{
			GC.KeepAlive(this);
			return;
		}
		if (DynData == null || DynData.Entries == null || rowIndex >= DynData.Entries.Count)
		{
			return;
		}
		object value = dataGridView_0[columnIndex, rowIndex].Value;
		object obj;
		if (value == null)
		{
			obj = null;
		}
		else
		{
			obj = value.ToString();
			if (obj != null)
			{
				goto IL_007a;
			}
		}
		obj = string.Empty;
		goto IL_007a;
		IL_007a:
		string text = (string)obj;
		DYNAMICOBJECTS_DATA.Entry value2 = DynData.Entries[rowIndex];
		switch (columnIndex)
		{
		case 0:
		{
			uint num = (uint)dataGridView_0.Rows[rowIndex].Tag;
			if (!method_14(text))
			{
				dataGridView_0[0, rowIndex].Value = num.ToString();
				GC.KeepAlive(this);
				break;
			}
			uint num2 = Convert.ToUInt32(text);
			if (num2 != num)
			{
				if (method_7(num2, rowIndex))
				{
					dataGridView_0[0, rowIndex].Value = num.ToString();
					GC.KeepAlive(this);
					break;
				}
				method_21();
				value2.Id = num2;
				DynData.Entries[rowIndex] = value2;
				dataGridView_0.Rows[rowIndex].Tag = num2;
				method_3();
			}
			break;
		}
		case 1:
			if (!string.Equals(value2.Path ?? string.Empty, text, StringComparison.Ordinal))
			{
				method_21();
				value2.Path = text;
				DynData.Entries[rowIndex] = value2;
				method_3();
			}
			break;
		case 2:
		{
			if (int.TryParse(text, out var result2) && value2.Reserved1 != result2)
			{
				method_21();
				value2.Reserved1 = result2;
				DynData.Entries[rowIndex] = value2;
				method_3();
			}
			break;
		}
		case 3:
		{
			if (int.TryParse(text, out var result) && value2.Reserved2 != result)
			{
				method_21();
				value2.Reserved2 = result;
				DynData.Entries[rowIndex] = value2;
				method_3();
			}
			break;
		}
		}
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		int int_ = 0;
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			int_ = dataGridView_0.SelectedRows[0].Index;
		}
		method_9(int_);
	}

	private void method_9(int int_0)
	{
		bool flag = false;
		string text = textBox_2.Text;
		uint num = 0u;
		if (method_14(text))
		{
			num = Convert.ToUInt32(text);
			flag = true;
		}
		if (DynData == null || DynData.Entries == null)
		{
			return;
		}
		bool flag2 = false;
		for (int i = int_0 + 1; i < DynData.Entries.Count; i++)
		{
			DYNAMICOBJECTS_DATA.Entry entry = DynData.Entries[i];
			if (flag2 = (flag ? (entry.Id == num) : method_15(entry.Path ?? string.Empty, text)))
			{
				dataGridView_0.CurrentCell = dataGridView_0[0, i];
				dataGridView_0.Rows[i].Selected = true;
				break;
			}
		}
		if (!flag2 && int_0 != -1)
		{
			method_9(-1);
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void method_10()
	{
		if (DynData != null && DynData.Entries != null)
		{
			method_21();
			uint num = method_8();
			DYNAMICOBJECTS_DATA.Entry item = new DYNAMICOBJECTS_DATA.Entry
			{
				Id = num,
				Path = string.Empty,
				Reserved1 = 0,
				Reserved2 = 0
			};
			DynData.Entries.Add(item);
			object[] values = new object[4]
			{
				num.ToString(),
				string.Empty,
				item.Reserved1.ToString(),
				item.Reserved2.ToString()
			};
			dataGridView_0.Rows.Add(values);
			int num2 = DynData.Entries.Count - 1;
			dataGridView_0.Rows[num2].Tag = num;
			dataGridView_0.CurrentCell = dataGridView_0[0, num2];
			dataGridView_0.Rows[num2].Selected = true;
			dataGridView_0_SelectionChanged(this, EventArgs.Empty);
			method_3();
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_11();
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		method_11();
	}

	private void method_11()
	{
		int count = dataGridView_0.SelectedRows.Count;
		if (count <= 0 || DynData == null || DynData.Entries == null)
		{
			return;
		}
		method_21();
		int[] array = new int[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = dataGridView_0.SelectedRows[i].Index;
		}
		Array.Sort(array);
		for (int num = count - 1; num >= 0; num--)
		{
			int num2 = array[num];
			if (num2 >= 0 && num2 < DynData.Entries.Count)
			{
				DynData.Entries.RemoveAt(num2);
				dataGridView_0.Rows.RemoveAt(num2);
			}
		}
		dataGridView_0_SelectionChanged(this, EventArgs.Empty);
		method_3();
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		if (DynData == null || DynData.Entries == null)
		{
			return;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = TextStorage.Msg(Class16.smethod_0(1648997151), Class16.smethod_0(1648997178));
		if (openFileDialog.ShowDialog(this) != DialogResult.OK || !File.Exists(openFileDialog.FileName))
		{
			return;
		}
		method_21();
		bool_0 = true;
		string text = System.IO.Path.GetExtension(openFileDialog.FileName).ToLowerInvariant();
		try
		{
			if (text == Class16.smethod_0(1648997294))
			{
				StreamReader streamReader = new StreamReader(openFileDialog.FileName);
				try
				{
					for (string text2 = streamReader.ReadLine(); text2 != null; text2 = streamReader.ReadLine())
					{
						uint num = method_8();
						DYNAMICOBJECTS_DATA.Entry item = new DYNAMICOBJECTS_DATA.Entry
						{
							Id = num,
							Path = text2,
							Reserved1 = 0,
							Reserved2 = 0
						};
						DynData.Entries.Add(item);
						object[] values = new object[4]
						{
							num.ToString(),
							text2,
							item.Reserved1.ToString(),
							item.Reserved2.ToString()
						};
						dataGridView_0.Rows.Add(values);
						dataGridView_0.Rows[dataGridView_0.RowCount - 1].Tag = num;
					}
				}
				finally
				{
					((IDisposable)streamReader).Dispose();
				}
			}
			else if (text == Class16.smethod_0(1648909430))
			{
				DYNAMICOBJECTS_DATA dYNAMICOBJECTS_DATA = null;
				try
				{
					dYNAMICOBJECTS_DATA = new DYNAMICOBJECTS_DATA(openFileDialog.FileName);
				}
				catch
				{
				}
				if (dYNAMICOBJECTS_DATA != null && dYNAMICOBJECTS_DATA.Entries != null)
				{
					Dictionary<uint, int> dictionary = new Dictionary<uint, int>(dataGridView_0.RowCount);
					for (int i = 0; i < dataGridView_0.RowCount; i++)
					{
						if (dataGridView_0.Rows[i].Tag is uint key)
						{
							dictionary[key] = i;
						}
					}
					for (int j = 0; j < dYNAMICOBJECTS_DATA.Entries.Count; j++)
					{
						DYNAMICOBJECTS_DATA.Entry entry = dYNAMICOBJECTS_DATA.Entries[j];
						if (dictionary.TryGetValue(entry.Id, out var value))
						{
							DynData.Entries[value] = entry;
							dataGridView_0[1, value].Value = entry.Path ?? string.Empty;
							dataGridView_0[2, value].Value = entry.Reserved1.ToString();
							dataGridView_0[3, value].Value = entry.Reserved2.ToString();
							continue;
						}
						DynData.Entries.Add(entry);
						object[] values2 = new object[4]
						{
							entry.Id.ToString(),
							entry.Path ?? string.Empty,
							entry.Reserved1.ToString(),
							entry.Reserved2.ToString()
						};
						dataGridView_0.Rows.Add(values2);
						dataGridView_0.Rows[dataGridView_0.RowCount - 1].Tag = entry.Id;
					}
				}
			}
		}
		finally
		{
			bool_0 = false;
		}
		if (dataGridView_0.RowCount > 0)
		{
			int num2 = dataGridView_0.RowCount - 1;
			dataGridView_0.CurrentCell = dataGridView_0[0, num2];
			dataGridView_0.Rows[num2].Selected = true;
		}
		dataGridView_0_SelectionChanged(this, EventArgs.Empty);
		method_3();
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_12();
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		method_12();
	}

	private void method_12()
	{
		int count = dataGridView_0.SelectedRows.Count;
		if (count <= 0 || DynData == null || DynData.Entries == null)
		{
			return;
		}
		using SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.FileName = TextStorage.Msg(Class16.smethod_0(1648997297), Class16.smethod_0(1648997351));
		saveFileDialog.Filter = TextStorage.Msg(Class16.smethod_0(1648996357), Class16.smethod_0(1648996384));
		if (saveFileDialog.ShowDialog(this) != DialogResult.OK || saveFileDialog.FileName == string.Empty)
		{
			return;
		}
		DYNAMICOBJECTS_DATA dYNAMICOBJECTS_DATA = new DYNAMICOBJECTS_DATA(null);
		dYNAMICOBJECTS_DATA.fn = saveFileDialog.FileName;
		dYNAMICOBJECTS_DATA.FileChanged = true;
		dYNAMICOBJECTS_DATA.TimeStamp = DynData.TimeStamp;
		dYNAMICOBJECTS_DATA.SetReservedFieldCount(DynData.ReservedFieldCount);
		dYNAMICOBJECTS_DATA.Entries = new List<DYNAMICOBJECTS_DATA.Entry>(count);
		for (int i = 0; i < count; i++)
		{
			int index = dataGridView_0.SelectedRows[i].Index;
			if (index >= 0 && index < DynData.Entries.Count)
			{
				dYNAMICOBJECTS_DATA.Entries.Add(DynData.Entries[index]);
			}
		}
		dYNAMICOBJECTS_DATA.FileChanged = true;
		dYNAMICOBJECTS_DATA.Save();
		TextStorage.TEXTS.ShowMessage(271, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		int count = dataGridView_0.SelectedRows.Count;
		if (count <= 0)
		{
			GC.KeepAlive(this);
			return;
		}
		int[] array = new int[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = dataGridView_0.SelectedRows[i].Index;
		}
		Array.Sort(array);
		string[] array2 = new string[count];
		for (int j = 0; j < count; j++)
		{
			int rowIndex = array[j];
			array2[j] = (string)(dataGridView_0[1, rowIndex].Value ?? string.Empty);
		}
		CommonStorage.sarr1 = array2;
		if (new ChangeValuesWindow(array2[0], CStorage, IsFloat: false, IsInt: false).ShowDialog() == DialogResult.OK)
		{
			method_21();
			bool_0 = true;
			try
			{
				for (int k = 0; k < count; k++)
				{
					int rowIndex2 = array[k];
					dataGridView_0[1, rowIndex2].Value = CommonStorage.sarr1[k];
				}
			}
			finally
			{
				bool_0 = false;
			}
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_5_Click(object sender, EventArgs e)
	{
		int count = dataGridView_0.SelectedRows.Count;
		if (count <= 0)
		{
			GC.KeepAlive(this);
			return;
		}
		int[] array = new int[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = dataGridView_0.SelectedRows[i].Index;
		}
		Array.Sort(array);
		string[] array2 = new string[count];
		int num;
		object obj;
		for (int j = 0; j < count; array2[num] = (string)obj, j++)
		{
			int rowIndex = array[j];
			num = j;
			object value = dataGridView_0[0, rowIndex].Value;
			if (value == null)
			{
				obj = null;
			}
			else
			{
				obj = value.ToString();
				if (obj != null)
				{
					continue;
				}
			}
			obj = Class16.smethod_0(1648924112);
		}
		CommonStorage.sarr1 = array2;
		if (new ChangeValuesWindow(array2[0], CStorage, IsFloat: false, IsInt: true).ShowDialog() == DialogResult.OK)
		{
			method_21();
			bool_0 = true;
			try
			{
				for (int k = 0; k < count; k++)
				{
					int rowIndex2 = array[k];
					dataGridView_0[0, rowIndex2].Value = CommonStorage.sarr1[k];
				}
			}
			finally
			{
				bool_0 = false;
			}
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_9_Click(object sender, EventArgs e)
	{
		method_13();
	}

	private void method_13()
	{
		if (dataGridView_0.SelectedRows.Count > 0 && ItemsWindow.ModelViewer != null)
		{
			ItemsWindow.ModelViewer.SetOwner(this);
			string text = dataGridView_0.SelectedRows[0].Cells[1].Value?.ToString();
			if (!string.IsNullOrWhiteSpace(text))
			{
				ItemsWindow.ModelViewer.ShowModelPreview(text, IsDir: false, TextStorage.Msg(Class16.smethod_0(1648996439), Class16.smethod_0(1648996472)));
			}
		}
	}

	private bool method_14(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				char c = string_0[num];
				if (!char.IsDigit(c))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private bool method_15(string string_0, string string_1)
	{
		if (string_0 == null)
		{
			return false;
		}
		return string_0.IndexOf(string_1, StringComparison.OrdinalIgnoreCase) >= 0;
	}

	private void method_16()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1648996501), 100);
		fileBasedUndoManager_0.SetStateChangedCallback(method_23);
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_19, method_20);
		method_17();
	}

	private void method_17()
	{
		button_8 = new Button
		{
			Name = Class16.smethod_0(1648929618),
			Text = string.Empty,
			Enabled = false,
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			Image = Resources.GShopEditor_PW_mbUndo,
			ImageAlign = ContentAlignment.MiddleCenter,
			FlatStyle = FlatStyle.Standard,
			UseVisualStyleBackColor = true,
			Parent = groupBox_0
		};
		button_9 = new Button
		{
			Name = Class16.smethod_0(1648929390),
			Text = string.Empty,
			Enabled = false,
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			Image = Resources.GShopEditor_PW_mbRedo,
			ImageAlign = ContentAlignment.MiddleCenter,
			FlatStyle = FlatStyle.Standard,
			UseVisualStyleBackColor = true,
			Parent = groupBox_0
		};
		button_8.Click += button_8_Click;
		button_9.Click += button_9_Click;
		groupBox_0.Resize += groupBox_0_Resize;
		method_18();
	}

	private void method_18()
	{
		if (button_8 != null && button_9 != null)
		{
			int num = Math.Max(32, button_1.Height);
			int top = button_1.Top;
			int num2 = groupBox_0.ClientSize.Width - 6;
			button_9.SetBounds(num2 - num, top, num, button_1.Height);
			button_8.SetBounds(button_9.Left - 4 - num, top, num, button_1.Height);
			button_0.SetBounds(button_8.Left - 4 - 82, top, 82, button_0.Height);
			button_1.SetBounds(button_0.Left - 4 - 82, top, 82, button_1.Height);
			textBox_0.Width = Math.Max(140, button_1.Left - textBox_0.Left - 4);
		}
	}

	private byte[] method_19()
	{
		if (DynData == null)
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
					binaryWriter.Write(DynData.TimeStamp);
					binaryWriter.Write(DynData.ReservedFieldCount);
					binaryWriter.Write(DynData.Entries.Count);
					foreach (DYNAMICOBJECTS_DATA.Entry entry in DynData.Entries)
					{
						binaryWriter.Write(entry.Id);
						binaryWriter.Write(entry.Path ?? string.Empty);
						binaryWriter.Write(entry.Reserved1);
						binaryWriter.Write(entry.Reserved2);
					}
					binaryWriter.Write(dataGridView_0.CurrentCell?.RowIndex ?? (-1));
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

	private void method_20(byte[] byte_0)
	{
		if (byte_0 == null || byte_0.Length == 0)
		{
			return;
		}
		bool_0 = true;
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_0);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					string fn = DynData?.fn;
					DynData = new DYNAMICOBJECTS_DATA();
					DynData.fn = fn;
					DynData.TimeStamp = binaryReader.ReadUInt32();
					int reservedFieldCount = binaryReader.ReadInt32();
					DynData.SetReservedFieldCount(reservedFieldCount);
					int num = binaryReader.ReadInt32();
					DynData.Entries = new List<DYNAMICOBJECTS_DATA.Entry>(num);
					for (int i = 0; i < num; i++)
					{
						DynData.Entries.Add(new DYNAMICOBJECTS_DATA.Entry
						{
							Id = binaryReader.ReadUInt32(),
							Path = binaryReader.ReadString(),
							Reserved1 = binaryReader.ReadInt32(),
							Reserved2 = binaryReader.ReadInt32()
						});
					}
					int num2 = binaryReader.ReadInt32();
					DynData.FileChanged = true;
					method_1();
					if (num2 >= 0 && num2 < dataGridView_0.Rows.Count)
					{
						dataGridView_0.CurrentCell = dataGridView_0[0, num2];
						dataGridView_0.Rows[num2].Selected = true;
					}
					button_0.Enabled = true;
					dataGridView_0_SelectionChanged(this, EventArgs.Empty);
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
		}
	}

	private void method_21()
	{
		if (!bool_0 && DynData != null)
		{
			byte[] array = method_19();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
		}
	}

	private void method_22()
	{
		fileBasedUndoManager_0?.Clear();
	}

	private void method_23()
	{
		if (button_8 != null)
		{
			button_8.Enabled = fileBasedUndoManager_0?.CanUndo ?? false;
		}
		if (button_9 != null)
		{
			button_9.Enabled = fileBasedUndoManager_0?.CanRedo ?? false;
		}
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_19();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_20(array);
		}
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_19();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_20(array);
		}
	}

	private void groupBox_0_Resize(object sender, EventArgs e)
	{
		method_18();
	}
}
