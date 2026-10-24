using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements;
using ACE.Properties;
using ACE.RSGlobal;
using Sentry;

namespace ACE.Path;

public class PathEditor : Form
{
	[Serializable]
	private sealed class Class322
	{
		public static readonly Class322 class322_0 = new Class322();

		public static Func<DataGridViewRow, int> func_0;

		public static Func<int, int> func_1;

		internal int method_0(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_1(int int_0)
		{
			return int_0;
		}
	}

	public int currentID;

	public PATH_DATA PathData;

	public bool IsFileChanged;

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

	private Button button_4;

	private DateTimePicker dateTimePicker_0;

	private TextBox textBox_1;

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

	private IContainer icontainer_0;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private bool bool_0;

	private Button button_8;

	private Button button_9;

	public PathEditor(CommonStorage CStorage)
	{
		try
		{
			method_5();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			this.CStorage = CStorage;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			DontChange = false;
			IsFileChanged = false;
			FileLoaded = false;
			currentID = -1;
			method_11();
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void toolStripMenuItem_7_Click(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_0()
	{
		FileLoaded = false;
		textBox_0.Text = PathData.fn;
		button_0.Enabled = PathData.FileChanged;
		dataGridView_0.Enabled = true;
		button_3.Enabled = true;
		button_6.Enabled = true;
		contextMenuStrip_0.Enabled = true;
		DontChange = true;
		DateTime value = ACE.RSGlobal.RSGlobal.Timestamp2DateTime(PathData.TimeStamp);
		dateTimePicker_0.Value = value;
		dataGridView_0.Rows.Clear();
		DataGridViewRow[] array = new DataGridViewRow[PathData.Paths.Count];
		int num = 0;
		foreach (KeyValuePair<uint, string> path in PathData.Paths)
		{
			ValueType valueType = path;
			DataGridViewRow dataGridViewRow = new DataGridViewRow();
			dataGridViewRow.Resizable = DataGridViewTriState.False;
			dataGridViewRow.CreateCells(dataGridView_0);
			uint key = ((KeyValuePair<uint, string>)(object)valueType).Key;
			dataGridViewRow.Cells[0].Value = key.ToString();
			dataGridViewRow.Cells[1].Value = ((KeyValuePair<uint, string>)(object)valueType).Value;
			dataGridViewRow.Tag = ((KeyValuePair<uint, string>)(object)valueType).Key;
			array[num] = dataGridViewRow;
			num++;
		}
		dataGridView_0.Rows.AddRange(array);
		DontChange = false;
		FileLoaded = true;
	}

	private void method_1()
	{
		PathData.Save();
		IsFileChanged = false;
		button_0.Enabled = false;
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_1();
	}

	private void toolStripMenuItem_8_Click(object sender, EventArgs e)
	{
		method_1();
	}

	private void method_2()
	{
		button_0.Enabled = true;
		PathData.FileChanged = true;
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649198687);
		openFileDialog.FileName = Class16.smethod_0(1648908925);
		if (openFileDialog.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			PATH_DATA pATH_DATA = null;
			try
			{
				pATH_DATA = new PATH_DATA(openFileDialog.FileName);
			}
			catch (InvalidDataException ex)
			{
				SentryHelper.CaptureMessage(Class16.smethod_0(1649198751) + ex.Message + Class16.smethod_0(1649198770) + openFileDialog.FileName, (SentryLevel)2, Class16.smethod_0(1649198784));
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649198818)) + Class16.smethod_0(1648908367) + ex.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				GC.KeepAlive(this);
				return;
			}
			catch (EndOfStreamException ex2)
			{
				SentryHelper.CaptureMessage(Class16.smethod_0(1649198841) + ex2.Message + Class16.smethod_0(1649198770) + openFileDialog.FileName, (SentryLevel)2, Class16.smethod_0(1649198877));
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649198818)) + Class16.smethod_0(1648908367) + ex2.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				GC.KeepAlive(this);
				return;
			}
			catch (Exception ex3)
			{
				SentryHelper.CaptureException(ex3, Class16.smethod_0(1649198911));
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649198818)) + Class16.smethod_0(1648908367) + ex3.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				GC.KeepAlive(this);
				return;
			}
			if (pATH_DATA != null && pATH_DATA.Paths != null)
			{
				PathData = pATH_DATA;
				method_0();
				method_19();
				CommonStorage.Params.PathDataPath = openFileDialog.FileName;
				object fileName = openFileDialog.FileName;
				SettingsClass profile = CommonStorage.Profile;
				profile.SaveSetting(profile.DefaultSection, Class16.smethod_0(1649144552), fileName);
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649198818)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		GC.KeepAlive(this);
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_8();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_9();
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		string text;
		object obj;
		if (!DontChange && PathData != null)
		{
			int rowIndex = e.RowIndex;
			int columnIndex = e.ColumnIndex;
			if (rowIndex < 0)
			{
				GC.KeepAlive(this);
				return;
			}
			object value = dataGridView_0[columnIndex, rowIndex].Value;
			if (value == null)
			{
				GC.KeepAlive(this);
				return;
			}
			method_18();
			text = value.ToString();
			if (columnIndex == 0)
			{
				uint num = (uint)dataGridView_0.Rows[rowIndex].Tag;
				if (!ACE.RSGlobal.RSGlobal.IsUIntFast(text))
				{
					uint num2 = num;
					dataGridView_0[0, rowIndex].Value = num2.ToString();
					GC.KeepAlive(this);
					return;
				}
				uint num3 = Convert.ToUInt32(text);
				if (PathData.Paths.ContainsKey(num3))
				{
					uint num4 = num;
					dataGridView_0[0, rowIndex].Value = num4.ToString();
					GC.KeepAlive(this);
					return;
				}
				string value2 = PathData.Paths[num];
				PathData.Paths.Remove(num);
				PathData.Paths.Add(num3, value2);
				dataGridView_0.Rows[rowIndex].Tag = num3;
				goto IL_0185;
			}
			object value3 = dataGridView_0[0, rowIndex].Value;
			if (value3 == null)
			{
				obj = null;
			}
			else
			{
				obj = value3.ToString();
				if (obj != null)
				{
					goto IL_016b;
				}
			}
			obj = Class16.smethod_0(1648924112);
			goto IL_016b;
		}
		GC.KeepAlive(this);
		return;
		IL_016b:
		uint key = Convert.ToUInt32((string)obj);
		PathData.Paths[key] = text;
		goto IL_0185;
		IL_0185:
		method_2();
	}

	private void PathEditor_Load(object sender, EventArgs e)
	{
		PATH_DATA pathData = PathData;
		if (pathData != null && pathData.Paths != null && !FileLoaded)
		{
			method_0();
		}
	}

	public Enum ShowDialog(Form owner, uint id)
	{
		currentID = (int)id;
		return ShowDialog(owner);
	}

	private void method_4()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_5()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(PathEditor));
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
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
		dateTimePicker_0 = new DateTimePicker();
		textBox_1 = new TextBox();
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
		toolStripMenuItem_7.Image = Resources.mnuOpen;
		toolStripMenuItem_7.ImageAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_7.Name = Class16.smethod_0(1648920856);
		toolStripMenuItem_7.ShortcutKeys = Keys.O | Keys.Control;
		toolStripMenuItem_7.Size = new Size(146, 22);
		toolStripMenuItem_7.Text = Class16.smethod_0(1648931498);
		toolStripMenuItem_7.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_7.Click += toolStripMenuItem_7_Click;
		toolStripMenuItem_8.Image = Resources.mnuSave;
		toolStripMenuItem_8.Name = Class16.smethod_0(1648920878);
		toolStripMenuItem_8.ShortcutKeys = Keys.S | Keys.Control;
		toolStripMenuItem_8.Size = new Size(146, 22);
		toolStripMenuItem_8.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_8.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_8.Click += toolStripMenuItem_8_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1649012270);
		toolStripSeparator_0.Size = new Size(143, 6);
		toolStripMenuItem_0.Image = Resources.mnuExit;
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
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1);
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
		contextMenuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		contextMenuStrip_0.Items.AddRange(new ToolStripItem[6] { toolStripMenuItem_1, toolStripMenuItem_4, toolStripMenuItem_5, toolStripMenuItem_2, toolStripSeparator_1, toolStripMenuItem_3 });
		contextMenuStrip_0.Name = Class16.smethod_0(1649003266);
		contextMenuStrip_0.Size = new Size(202, 120);
		toolStripMenuItem_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		toolStripMenuItem_1.Image = Resources.mnuAdd;
		toolStripMenuItem_1.Name = Class16.smethod_0(1649003303);
		toolStripMenuItem_1.ShortcutKeys = Keys.N | Keys.Control;
		toolStripMenuItem_1.Size = new Size(201, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648931361);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_4.Image = Resources.mnuAdvancedChanging;
		toolStripMenuItem_4.Name = Class16.smethod_0(1648997864);
		toolStripMenuItem_4.Size = new Size(201, 22);
		toolStripMenuItem_4.Text = Class16.smethod_0(1648996866);
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		toolStripMenuItem_5.Image = Resources.mnuAdvancedChangingID;
		toolStripMenuItem_5.Name = Class16.smethod_0(1648996896);
		toolStripMenuItem_5.Size = new Size(201, 22);
		toolStripMenuItem_5.Text = Class16.smethod_0(1648996932);
		toolStripMenuItem_5.Click += toolStripMenuItem_5_Click;
		toolStripMenuItem_2.Enabled = false;
		toolStripMenuItem_2.Image = Resources.mnuDelete;
		toolStripMenuItem_2.Name = Class16.smethod_0(1649003348);
		toolStripMenuItem_2.ShortcutKeys = Keys.Delete;
		toolStripMenuItem_2.Size = new Size(201, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648925718);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripSeparator_1.Name = Class16.smethod_0(1649004015);
		toolStripSeparator_1.Size = new Size(198, 6);
		toolStripMenuItem_3.Enabled = false;
		toolStripMenuItem_3.Image = Resources.mnuExport;
		toolStripMenuItem_3.Name = Class16.smethod_0(1648996987);
		toolStripMenuItem_3.Size = new Size(201, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1648931384);
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
		label_1.Size = new Size(71, 15);
		label_1.TabIndex = 110;
		label_1.Text = Class16.smethod_0(1649198933);
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
		dateTimePicker_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dateTimePicker_0.CalendarFont = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dateTimePicker_0.Font = new Font(Class16.smethod_0(1648942905), 10f);
		dateTimePicker_0.Location = new Point(75, 40);
		dateTimePicker_0.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		dateTimePicker_0.MinDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		dateTimePicker_0.Name = Class16.smethod_0(1649198950);
		dateTimePicker_0.Size = new Size(381, 25);
		dateTimePicker_0.TabIndex = 135;
		dateTimePicker_0.Value = new DateTime(2014, 2, 13, 14, 32, 21, 0);
		dateTimePicker_0.ValueChanged += dateTimePicker_0_ValueChanged;
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.BackColor = Color.White;
		textBox_1.Location = new Point(75, 70);
		textBox_1.Name = Class16.smethod_0(1648919457);
		textBox_1.Size = new Size(381, 22);
		textBox_1.TabIndex = 136;
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
		button_7.Location = new Point(567, 39);
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
		base.Controls.Add(textBox_1);
		base.Controls.Add(dateTimePicker_0);
		base.Controls.Add(button_4);
		base.Controls.Add(dataGridView_0);
		base.Controls.Add(label_1);
		base.Controls.Add(button_2);
		base.Controls.Add(button_3);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(menuStrip_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.PathEditor_Icon;
		base.MainMenuStrip = menuStrip_0;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.Name = Class16.smethod_0(1649198966);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649198983);
		base.FormClosing += PathEditor_FormClosing;
		base.Load += PathEditor_Load;
		base.Shown += PathEditor_Shown;
		base.Activated += PathEditor_Activated;
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

	private void method_6()
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

	private void PathEditor_Shown(object sender, EventArgs e)
	{
		PATH_DATA pathData = PathData;
		if (pathData != null && pathData.Paths != null)
		{
			if (currentID > -1)
			{
				string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649199009));
				button_4.Text = text;
				int num = 0;
				{
					foreach (KeyValuePair<uint, string> path in PathData.Paths)
					{
						object obj = path;
						int num2 = currentID;
						if (((KeyValuePair<uint, string>)obj).Key != (uint)num2)
						{
							num++;
							continue;
						}
						dataGridView_0.CurrentCell = dataGridView_0[0, num];
						dataGridView_0.Rows[num].Selected = true;
						break;
					}
					return;
				}
			}
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649199032));
			button_4.Text = text2;
		}
		else
		{
			method_3();
		}
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
					goto IL_0054;
				}
			}
			obj = Class16.smethod_0(1648924112);
			goto IL_0054;
		}
		goto IL_0066;
		IL_0054:
		CommonStorage.sData = Convert.ToUInt32((string)obj).ToString();
		goto IL_0066;
		IL_0066:
		Close();
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_2.Enabled = b != 0;
		byte b2 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		toolStripMenuItem_2.Enabled = b2 != 0;
		byte b3 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_7.Enabled = b3 != 0;
		byte b4 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		toolStripMenuItem_3.Enabled = b4 != 0;
		GC.KeepAlive(this);
	}

	private void PathEditor_FormClosing(object sender, FormClosingEventArgs e)
	{
		PATH_DATA pathData = PathData;
		if (pathData != null && pathData.FileChanged)
		{
			switch (DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649199063), Class16.smethod_0(1649199082)), TextStorage.Msg(Class16.smethod_0(1649002823), Class16.smethod_0(1648997745)), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
			case DialogResult.Cancel:
				e.Cancel = true;
				return;
			case DialogResult.Yes:
			{
				method_1();
				PATH_DATA pathData2 = PathData;
				if (pathData2 != null && pathData2.FileChanged)
				{
					e.Cancel = true;
					return;
				}
				break;
			}
			}
		}
		method_6();
		GC.KeepAlive(this);
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		if (PathData != null && !DontChange)
		{
			method_18();
			DateTime value = dateTimePicker_0.Value;
			PathData.TimeStamp = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(value);
			method_2();
		}
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		int int_ = 0;
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			int_ = dataGridView_0.SelectedRows[0].Index;
		}
		method_7(int_);
	}

	private void method_7(int int_0)
	{
		bool flag = false;
		string text = textBox_1.Text;
		int num = 0;
		if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
		{
			num = Convert.ToInt32(text);
			flag = true;
		}
		PATH_DATA pathData = PathData;
		if (pathData == null)
		{
			return;
		}
		IDictionary<uint, string> paths = pathData.Paths;
		if (paths == null)
		{
			return;
		}
		int num2 = 0;
		bool flag2 = false;
		foreach (KeyValuePair<uint, string> item in paths)
		{
			ValueType valueType = item;
			if (num2 <= int_0)
			{
				num2++;
				continue;
			}
			if (!(flag2 = ((!flag) ? ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(((KeyValuePair<uint, string>)(object)valueType).Value, text) : (((KeyValuePair<uint, string>)(object)valueType).Key == (uint)num))))
			{
				num2++;
				continue;
			}
			dataGridView_0.CurrentCell = dataGridView_0[0, num2];
			dataGridView_0.Rows[num2].Selected = true;
			break;
		}
		if (!flag2 && int_0 != -1)
		{
			method_7(-1);
		}
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649198121);
		if (openFileDialog.ShowDialog(this) != DialogResult.OK || !File.Exists(openFileDialog.FileName))
		{
			return;
		}
		method_18();
		bool_0 = true;
		try
		{
			string text = Class16.smethod_0(1648997294);
			if (System.IO.Path.GetExtension(openFileDialog.FileName) == text)
			{
				StreamReader streamReader = new StreamReader(openFileDialog.FileName);
				string text2 = streamReader.ReadLine();
				if (text2 != null)
				{
					do
					{
						PATH_DATA pathData = PathData;
						uint num = pathData.AddNew(pathData.GetUniqueID(), text2);
						object[] array = new object[2];
						uint num2 = num;
						array[0] = num2.ToString();
						array[1] = text2;
						dataGridView_0.Rows.Add(array);
						int index = PathData.Paths.Count - 1;
						dataGridView_0.Rows[index].Tag = num;
						text2 = streamReader.ReadLine();
					}
					while (text2 != null);
				}
			}
			else
			{
				string text3 = Class16.smethod_0(1648909430);
				if (System.IO.Path.GetExtension(openFileDialog.FileName) == text3)
				{
					foreach (KeyValuePair<uint, string> path in new PATH_DATA(openFileDialog.FileName).Paths)
					{
						ValueType valueType = path;
						uint key = ((KeyValuePair<uint, string>)(object)valueType).Key;
						string value = ((KeyValuePair<uint, string>)(object)valueType).Value;
						if (PathData.Paths.ContainsKey(key))
						{
							for (int i = 0; i < dataGridView_0.RowCount; i++)
							{
								if ((uint)dataGridView_0.Rows[i].Tag == key)
								{
									dataGridView_0[1, i].Value = value;
									break;
								}
							}
						}
						else
						{
							PathData.AddNew(key, value);
							object[] array2 = new object[2];
							uint num3 = key;
							array2[0] = num3.ToString();
							array2[1] = value;
							dataGridView_0.Rows.Add(array2);
							int index2 = PathData.Paths.Count - 1;
							dataGridView_0.Rows[index2].Tag = key;
						}
					}
				}
			}
			int rowIndex = PathData.Paths.Count - 1;
			dataGridView_0.CurrentCell = dataGridView_0[0, rowIndex];
			int index3 = PathData.Paths.Count - 1;
			dataGridView_0.Rows[index3].Selected = true;
			byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			button_2.Enabled = b != 0;
			byte b2 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			toolStripMenuItem_2.Enabled = b2 != 0;
			byte b3 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			button_7.Enabled = b3 != 0;
			byte b4 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			toolStripMenuItem_3.Enabled = b4 != 0;
			method_2();
		}
		finally
		{
			bool_0 = false;
		}
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		method_8();
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		int count = dataGridView_0.SelectedRows.Count;
		if (count > 0)
		{
			string[] array = new string[count];
			int[] array2 = new int[count];
			int num = 0;
			if (0 < count)
			{
				do
				{
					array2[num] = dataGridView_0.SelectedRows[num].Index;
					num++;
				}
				while (num < count);
			}
			Array.Sort(array2);
			int num2 = 0;
			if (0 < count)
			{
				do
				{
					int rowIndex = array2[num2];
					array[num2] = (string)dataGridView_0[1, rowIndex].Value;
					num2++;
				}
				while (num2 < count);
			}
			CommonStorage.sarr1 = array;
			if (new ChangeValuesWindow(array[0], CStorage, IsFloat: false, IsInt: false).ShowDialog() == DialogResult.OK)
			{
				method_18();
				bool_0 = true;
				try
				{
					int num3 = 0;
					if (0 < count)
					{
						do
						{
							int rowIndex2 = array2[num3];
							string value = CommonStorage.sarr1[num3];
							dataGridView_0[1, rowIndex2].Value = value;
							num3++;
						}
						while (num3 < count);
					}
				}
				finally
				{
					bool_0 = false;
				}
			}
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		method_9();
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void method_8()
	{
		method_18();
		string empty = string.Empty;
		PATH_DATA pathData = PathData;
		uint num = pathData.AddNew(pathData.GetUniqueID(), empty);
		object[] array = new object[2];
		uint num2 = num;
		array[0] = num2.ToString();
		array[1] = string.Empty;
		dataGridView_0.Rows.Add(array);
		int rowIndex = PathData.Paths.Count - 1;
		dataGridView_0.CurrentCell = dataGridView_0[0, rowIndex];
		int index = PathData.Paths.Count - 1;
		dataGridView_0.Rows[index].Tag = num;
		int index2 = PathData.Paths.Count - 1;
		dataGridView_0.Rows[index2].Selected = true;
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_2.Enabled = b != 0;
		byte b2 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		toolStripMenuItem_2.Enabled = b2 != 0;
		byte b3 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_7.Enabled = b3 != 0;
		byte b4 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		toolStripMenuItem_3.Enabled = b4 != 0;
		method_2();
	}

	private void method_9()
	{
		int count = dataGridView_0.SelectedRows.Count;
		if (count > 0)
		{
			method_18();
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
					uint key = (uint)dataGridView_0.Rows[index].Tag;
					PathData.Paths.Remove(key);
					PathData.Count--;
					dataGridView_0.Rows.RemoveAt(index);
					num2--;
				}
				while (num2 >= 0);
			}
		}
		byte b = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_2.Enabled = b != 0;
		byte b2 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		toolStripMenuItem_2.Enabled = b2 != 0;
		byte b3 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_7.Enabled = b3 != 0;
		byte b4 = ((dataGridView_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		toolStripMenuItem_3.Enabled = b4 != 0;
		method_2();
	}

	private void method_10()
	{
		int count = dataGridView_0.SelectedRows.Count;
		if (count > 0)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = Class16.smethod_0(1649198184);
			saveFileDialog.Filter = Class16.smethod_0(1649198212);
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string empty = string.Empty;
				if (saveFileDialog.FileName != empty)
				{
					PATH_DATA pATH_DATA = new PATH_DATA(null);
					pATH_DATA.fn = saveFileDialog.FileName;
					pATH_DATA.FileChanged = true;
					DateTime now = DateTime.Now;
					pATH_DATA.TimeStamp = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(now);
					pATH_DATA.Count = count;
					pATH_DATA.Paths = new Dictionary<uint, string>(count);
					int num = 0;
					if (0 < count)
					{
						do
						{
							int index = dataGridView_0.SelectedRows[num].Index;
							uint key = (uint)dataGridView_0.Rows[index].Tag;
							string value = (string)dataGridView_0[1, index].Value;
							pATH_DATA.Paths.Add(key, value);
							num++;
						}
						while (num < count);
					}
					pATH_DATA.Save();
					TextStorage.TEXTS.ShowMessage(271, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
				}
			}
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_5_Click(object sender, EventArgs e)
	{
		int count = dataGridView_0.SelectedRows.Count;
		if (count > 0)
		{
			string[] array = new string[count];
			int[] array2 = new int[count];
			int num = 0;
			if (0 < count)
			{
				do
				{
					array2[num] = dataGridView_0.SelectedRows[num].Index;
					num++;
				}
				while (num < count);
			}
			Array.Sort(array2);
			int num2 = 0;
			if (0 < count)
			{
				do
				{
					int rowIndex = array2[num2];
					int num3 = num2;
					object value = dataGridView_0[0, rowIndex].Value;
					object obj;
					if (value != null)
					{
						obj = value.ToString();
						if (obj != null)
						{
							goto IL_008f;
						}
					}
					else
					{
						obj = null;
					}
					obj = Class16.smethod_0(1648924112);
					goto IL_008f;
					IL_008f:
					array[num3] = (string)obj;
					num2++;
				}
				while (num2 < count);
			}
			CommonStorage.sarr1 = array;
			if (new ChangeValuesWindow(array[0], CStorage, IsFloat: false, IsInt: true).ShowDialog() == DialogResult.OK)
			{
				method_18();
				bool_0 = true;
				try
				{
					int num4 = 0;
					if (0 < count)
					{
						do
						{
							int rowIndex2 = array2[num4];
							string value2 = CommonStorage.sarr1[num4];
							dataGridView_0[0, rowIndex2].Value = value2;
							num4++;
						}
						while (num4 < count);
					}
				}
				finally
				{
					bool_0 = false;
				}
			}
		}
		GC.KeepAlive(this);
	}

	private void method_11()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1649198966), 100);
		fileBasedUndoManager_0.SetStateChangedCallback(method_20);
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_14, method_15);
		method_12();
	}

	private void method_12()
	{
		button_8 = new Button
		{
			Name = Class16.smethod_0(1648919713),
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
			Name = Class16.smethod_0(1648919742),
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
		method_13();
	}

	private void method_13()
	{
		if (button_8 != null && button_9 != null)
		{
			int num = Math.Max(32, button_1.Height);
			int num2 = button_1.Width;
			int top = button_1.Top;
			int num3 = groupBox_0.ClientSize.Width - 6;
			button_9.SetBounds(num3 - num, top, num, button_1.Height);
			button_8.SetBounds(button_9.Left - 4 - num, top, num, button_1.Height);
			button_0.SetBounds(button_8.Left - 4 - num2, top, num2, button_0.Height);
			button_1.SetBounds(button_0.Left - 4 - num2, top, num2, button_1.Height);
			textBox_0.Width = Math.Max(140, button_1.Left - textBox_0.Left - 4);
		}
	}

	private byte[] method_14()
	{
		if (PathData == null)
		{
			return null;
		}
		try
		{
			PathDataSnapshot pathDataSnapshot = PathData.CreateUndoSnapshot();
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					binaryWriter.Write(pathDataSnapshot.FileName ?? string.Empty);
					binaryWriter.Write(pathDataSnapshot.FileChanged);
					binaryWriter.Write(pathDataSnapshot.TimeStamp);
					binaryWriter.Write(pathDataSnapshot.Count);
					binaryWriter.Write(pathDataSnapshot.LastId);
					binaryWriter.Write(pathDataSnapshot.ReservedFieldCount);
					int value = pathDataSnapshot.Entries?.Count ?? 0;
					binaryWriter.Write(value);
					foreach (PathDataEntrySnapshot item in pathDataSnapshot.Entries ?? new List<PathDataEntrySnapshot>())
					{
						binaryWriter.Write(item.Id);
						binaryWriter.Write(item.Path ?? string.Empty);
						binaryWriter.Write(item.Reserved1);
						binaryWriter.Write(item.Reserved2);
					}
					binaryWriter.Write(dataGridView_0?.CurrentRow?.Index ?? (-1));
					DataGridView dataGridView = dataGridView_0;
					object obj;
					if (dataGridView == null)
					{
						obj = null;
					}
					else
					{
						obj = dataGridView.SelectedRows.Cast<DataGridViewRow>().Select(Class322.class322_0.method_0).OrderBy(Class322.class322_0.method_1)
							.ToArray();
						if (obj != null)
						{
							goto IL_01b8;
						}
					}
					obj = Array.Empty<int>();
					goto IL_01b8;
					IL_01b8:
					int[] array = (int[])obj;
					binaryWriter.Write(array.Length);
					int[] array2 = array;
					foreach (int value2 in array2)
					{
						binaryWriter.Write(value2);
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

	private void method_15(byte[] byte_0)
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
					PathDataSnapshot pathDataSnapshot = new PathDataSnapshot
					{
						FileName = binaryReader.ReadString(),
						FileChanged = binaryReader.ReadBoolean(),
						TimeStamp = binaryReader.ReadUInt32(),
						Count = binaryReader.ReadInt32(),
						LastId = binaryReader.ReadUInt32(),
						ReservedFieldCount = binaryReader.ReadInt32()
					};
					int num = binaryReader.ReadInt32();
					pathDataSnapshot.Entries = new List<PathDataEntrySnapshot>(num);
					for (int i = 0; i < num; i++)
					{
						pathDataSnapshot.Entries.Add(new PathDataEntrySnapshot
						{
							Id = binaryReader.ReadUInt32(),
							Path = binaryReader.ReadString(),
							Reserved1 = binaryReader.ReadInt32(),
							Reserved2 = binaryReader.ReadInt32()
						});
					}
					int int_ = binaryReader.ReadInt32();
					int num2 = binaryReader.ReadInt32();
					int[] array = new int[num2];
					for (int j = 0; j < num2; j++)
					{
						array[j] = binaryReader.ReadInt32();
					}
					if (PathData == null)
					{
						PathData = new PATH_DATA(null);
					}
					PathData.RestoreUndoSnapshot(pathDataSnapshot);
					method_0();
					button_0.Enabled = PathData.FileChanged;
					method_16(int_, array);
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

	private void method_16(int int_0, int[] int_1)
	{
		if (dataGridView_0.Rows.Count == 0)
		{
			return;
		}
		dataGridView_0.ClearSelection();
		int_0 = method_17(int_0);
		bool flag = false;
		int[] array = int_1 ?? Array.Empty<int>();
		foreach (int int_2 in array)
		{
			int num = method_17(int_2);
			if (num >= 0)
			{
				dataGridView_0.Rows[num].Selected = true;
				flag = true;
			}
		}
		if (int_0 >= 0)
		{
			dataGridView_0.CurrentCell = dataGridView_0[0, int_0];
			if (!flag)
			{
				dataGridView_0.Rows[int_0].Selected = true;
			}
		}
	}

	private int method_17(int int_0)
	{
		if (dataGridView_0.Rows.Count == 0)
		{
			return -1;
		}
		if (int_0 < 0)
		{
			return 0;
		}
		return Math.Min(int_0, dataGridView_0.Rows.Count - 1);
	}

	private void method_18()
	{
		if (!bool_0 && PathData != null)
		{
			byte[] array = method_14();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
		}
	}

	private void method_19()
	{
		fileBasedUndoManager_0?.Clear();
	}

	private void method_20()
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

	private void PathEditor_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_PathEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_PathEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_14();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_15(array);
		}
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_14();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_15(array);
		}
	}

	private void groupBox_0_Resize(object sender, EventArgs e)
	{
		method_13();
	}
}
