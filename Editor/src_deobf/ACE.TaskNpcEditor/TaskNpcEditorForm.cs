using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.TaskNpcEditor;

public class TaskNpcEditorForm : Form
{
	private sealed class Class362
	{
		private int int_0;

		private short short_0;

		private short short_1;

		private short short_2;

		private short short_3;

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_1)
		{
			int_0 = int_1;
		}

		public short method_2()
		{
			return short_0;
		}

		public void method_3(short short_4)
		{
			short_0 = short_4;
		}

		public short method_4()
		{
			return short_1;
		}

		public void method_5(short short_4)
		{
			short_1 = short_4;
		}

		public short method_6()
		{
			return short_2;
		}

		public void method_7(short short_4)
		{
			short_2 = short_4;
		}

		public short method_8()
		{
			return short_3;
		}

		public void method_9(short short_4)
		{
			short_3 = short_4;
		}
	}

	private readonly BindingList<Class362> bindingList_0 = new BindingList<Class362>();

	private string string_0 = string.Empty;

	private uint uint_0;

	private int int_0;

	private short short_0;

	private bool bool_0;

	private static readonly DateTime dateTime_0 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	public IContainer components;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_4;

	private StatusStrip statusStrip_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private DataGridView dataGridView_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private TableLayoutPanel tableLayoutPanel_1;

	private GroupBox groupBox_0;

	private Label label_0;

	private DateTimePicker dateTimePicker_0;

	private Label label_1;

	private NumericUpDown numericUpDown_0;

	private Label label_2;

	private GroupBox groupBox_1;

	private NumericUpDown numericUpDown_1;

	private Label label_3;

	private NumericUpDown numericUpDown_2;

	private Label label_4;

	private NumericUpDown numericUpDown_3;

	private Label label_5;

	private NumericUpDown numericUpDown_4;

	private Label label_6;

	private NumericUpDown numericUpDown_5;

	private Label label_7;

	private Button button_0;

	private FlowLayoutPanel flowLayoutPanel_0;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private bool bool_1;

	private Button button_4;

	private Button button_5;

	public TaskNpcEditorForm()
	{
		method_5();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		dataGridView_0.AutoGenerateColumns = false;
		dataGridView_0.DataSource = bindingList_0;
		numericUpDown_0.Minimum = -32768m;
		numericUpDown_0.Maximum = 32767m;
		dateTimePicker_0.Value = dateTime_0.ToLocalTime();
		method_7();
		method_4(null);
		method_10();
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = Class16.smethod_0(1649151722),
			Title = Class16.smethod_0(1649151763)
		};
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			method_0(openFileDialog.FileName);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649151796));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649151838), Class16.smethod_0(1649014988)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		method_1(bool_2: false);
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_1(bool_2: true);
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void method_0(string string_1)
	{
		EditorSessionTracker.LogFolderAccess(string_1, Class16.smethod_0(1648903793), Class16.smethod_0(1649151871));
		BinaryReader binaryReader = new BinaryReader(File.OpenRead(string_1));
		try
		{
			uint_0 = binaryReader.ReadUInt32();
			int_0 = binaryReader.ReadInt32();
			short_0 = binaryReader.ReadInt16();
			short num = binaryReader.ReadInt16();
			bindingList_0.Clear();
			for (int i = 0; i < num; i++)
			{
				Class362 @class = new Class362();
				@class.method_1(binaryReader.ReadInt32());
				@class.method_3(binaryReader.ReadInt16());
				@class.method_5(binaryReader.ReadInt16());
				@class.method_7(binaryReader.ReadInt16());
				@class.method_9(binaryReader.ReadInt16());
				Class362 item = @class;
				bindingList_0.Add(item);
			}
			string_0 = string_1;
			bool_0 = false;
			numericUpDown_0.Value = Math.Min(numericUpDown_0.Maximum, Math.Max(numericUpDown_0.Minimum, short_0));
			DateTime value = dateTime_0.AddSeconds(int_0).ToLocalTime();
			dateTimePicker_0.Value = value;
			method_7();
			method_4(method_3());
			method_8(Class16.smethod_0(1649151886) + System.IO.Path.GetFileName(string_1));
			method_16();
		}
		finally
		{
			((IDisposable)binaryReader).Dispose();
		}
	}

	private void method_1(bool bool_2)
	{
		if (bindingList_0.Count > 32767)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649151898)), TextStorage.Msg(Class16.smethod_0(1648943005)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		string fileName = string_0;
		if (bool_2 || string.IsNullOrWhiteSpace(fileName))
		{
			using SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Filter = Class16.smethod_0(1649151722),
				Title = Class16.smethod_0(1649151933)
			};
			if (!string.IsNullOrWhiteSpace(string_0))
			{
				saveFileDialog.FileName = System.IO.Path.GetFileName(string_0);
			}
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			fileName = saveFileDialog.FileName;
		}
		try
		{
			method_2(fileName);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649151958));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649151991), Class16.smethod_0(1649010378)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_2(string string_1)
	{
		EditorSessionTracker.LogFolderAccess(string_1, Class16.smethod_0(1649006856), Class16.smethod_0(1649151871));
		short_0 = (short)numericUpDown_0.Value;
		int_0 = (int)(dateTimePicker_0.Value.ToUniversalTime() - dateTime_0).TotalSeconds;
		uint_0 = (uint)(bindingList_0.Count * 12);
		BinaryWriter binaryWriter = new BinaryWriter(File.Create(string_1));
		try
		{
			binaryWriter.Write(uint_0);
			binaryWriter.Write(int_0);
			binaryWriter.Write(short_0);
			binaryWriter.Write((short)bindingList_0.Count);
			foreach (Class362 item in bindingList_0)
			{
				binaryWriter.Write(item.method_0());
				binaryWriter.Write(item.method_2());
				binaryWriter.Write(item.method_4());
				binaryWriter.Write(item.method_6());
				binaryWriter.Write(item.method_8());
			}
			string_0 = string_1;
			bool_0 = false;
			method_8(Class16.smethod_0(1649150999) + System.IO.Path.GetFileName(string_1));
		}
		finally
		{
			((IDisposable)binaryWriter).Dispose();
		}
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		method_4(method_3());
	}

	private Class362 method_3()
	{
		if (dataGridView_0.CurrentRow?.DataBoundItem is Class362 result)
		{
			return result;
		}
		return null;
	}

	private void method_4(Class362 class362_0)
	{
		bool flag = class362_0 != null;
		numericUpDown_5.Enabled = flag;
		numericUpDown_4.Enabled = flag;
		numericUpDown_3.Enabled = flag;
		numericUpDown_2.Enabled = flag;
		numericUpDown_1.Enabled = flag;
		button_0.Enabled = flag;
		button_2.Enabled = flag;
		button_3.Enabled = flag;
		if (!flag)
		{
			numericUpDown_5.Value = 0m;
			numericUpDown_4.Value = 0m;
			numericUpDown_3.Value = 0m;
			numericUpDown_2.Value = 0m;
			numericUpDown_1.Value = 0m;
		}
		else
		{
			numericUpDown_5.Value = class362_0.method_0();
			numericUpDown_4.Value = class362_0.method_2();
			numericUpDown_3.Value = class362_0.method_4();
			numericUpDown_2.Value = class362_0.method_6();
			numericUpDown_1.Value = class362_0.method_8();
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		Class362 @class = method_3();
		if (@class != null && (@class.method_0() != (int)numericUpDown_5.Value || @class.method_2() != (short)numericUpDown_4.Value || @class.method_4() != (short)numericUpDown_3.Value || @class.method_6() != (short)numericUpDown_2.Value || @class.method_8() != (short)numericUpDown_1.Value))
		{
			method_15();
			@class.method_1((int)numericUpDown_5.Value);
			@class.method_3((short)numericUpDown_4.Value);
			@class.method_5((short)numericUpDown_3.Value);
			@class.method_7((short)numericUpDown_2.Value);
			@class.method_9((short)numericUpDown_1.Value);
			dataGridView_0.Refresh();
			method_9(Class16.smethod_0(1649151013));
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_5()
	{
		new ComponentResourceManager(typeof(TaskNpcEditorForm));
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		statusStrip_0 = new StatusStrip();
		toolStripStatusLabel_0 = new ToolStripStatusLabel();
		tableLayoutPanel_0 = new TableLayoutPanel();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		tableLayoutPanel_1 = new TableLayoutPanel();
		groupBox_0 = new GroupBox();
		label_0 = new Label();
		dateTimePicker_0 = new DateTimePicker();
		label_1 = new Label();
		numericUpDown_0 = new NumericUpDown();
		label_2 = new Label();
		groupBox_1 = new GroupBox();
		button_0 = new Button();
		numericUpDown_1 = new NumericUpDown();
		label_3 = new Label();
		numericUpDown_2 = new NumericUpDown();
		label_4 = new Label();
		numericUpDown_3 = new NumericUpDown();
		label_5 = new Label();
		numericUpDown_4 = new NumericUpDown();
		label_6 = new Label();
		numericUpDown_5 = new NumericUpDown();
		label_7 = new Label();
		flowLayoutPanel_0 = new FlowLayoutPanel();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		menuStrip_0.SuspendLayout();
		statusStrip_0.SuspendLayout();
		tableLayoutPanel_0.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		tableLayoutPanel_1.SuspendLayout();
		groupBox_0.SuspendLayout();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		groupBox_1.SuspendLayout();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		((ISupportInitialize)numericUpDown_3).BeginInit();
		((ISupportInitialize)numericUpDown_4).BeginInit();
		((ISupportInitialize)numericUpDown_5).BeginInit();
		flowLayoutPanel_0.SuspendLayout();
		SuspendLayout();
		menuStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripMenuItem_0 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1648931410);
		menuStrip_0.Size = new Size(914, 24);
		menuStrip_0.TabIndex = 0;
		menuStrip_0.Text = Class16.smethod_0(1648931410);
		toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[5] { toolStripMenuItem_1, toolStripMenuItem_2, toolStripMenuItem_3, toolStripSeparator_0, toolStripMenuItem_4 });
		toolStripMenuItem_0.Name = Class16.smethod_0(1648920842);
		toolStripMenuItem_0.Size = new Size(37, 20);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_1.Name = Class16.smethod_0(1648920856);
		toolStripMenuItem_1.Size = new Size(112, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1649151027);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_2.Name = Class16.smethod_0(1648920878);
		toolStripMenuItem_2.Size = new Size(112, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.Name = Class16.smethod_0(1648920892);
		toolStripMenuItem_3.Size = new Size(112, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1649066091);
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1648920981);
		toolStripSeparator_0.Size = new Size(109, 6);
		toolStripMenuItem_4.Name = Class16.smethod_0(1648920908);
		toolStripMenuItem_4.Size = new Size(112, 22);
		toolStripMenuItem_4.Text = Class16.smethod_0(1648920914);
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		statusStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripStatusLabel_0 });
		statusStrip_0.Location = new Point(0, 539);
		statusStrip_0.Name = Class16.smethod_0(1649003514);
		statusStrip_0.Size = new Size(914, 22);
		statusStrip_0.TabIndex = 2;
		statusStrip_0.Text = Class16.smethod_0(1649003514);
		toolStripStatusLabel_0.Name = Class16.smethod_0(1649192538);
		toolStripStatusLabel_0.Size = new Size(42, 17);
		toolStripStatusLabel_0.Text = Class16.smethod_0(1649204412);
		tableLayoutPanel_0.ColumnCount = 2;
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		tableLayoutPanel_0.Controls.Add(dataGridView_0, 0, 0);
		tableLayoutPanel_0.Controls.Add(tableLayoutPanel_1, 1, 0);
		tableLayoutPanel_0.Dock = DockStyle.Fill;
		tableLayoutPanel_0.Location = new Point(0, 24);
		tableLayoutPanel_0.Name = Class16.smethod_0(1649151041);
		tableLayoutPanel_0.RowCount = 1;
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_0.Size = new Size(914, 515);
		tableLayoutPanel_0.TabIndex = 1;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView_0.BackgroundColor = Color.FromArgb(32, 32, 32);
		dataGridView_0.BorderStyle = BorderStyle.None;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1, dataGridViewTextBoxColumn_2, dataGridViewTextBoxColumn_3, dataGridViewTextBoxColumn_4);
		dataGridView_0.Dock = DockStyle.Fill;
		dataGridView_0.Location = new Point(3, 3);
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1649151058);
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.Size = new Size(633, 509);
		dataGridView_0.TabIndex = 0;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridViewTextBoxColumn_0.DataPropertyName = Class16.smethod_0(1649077794);
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_0.MinimumWidth = 70;
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649151079);
		dataGridViewTextBoxColumn_1.DataPropertyName = Class16.smethod_0(1648916453);
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648916453);
		dataGridViewTextBoxColumn_1.MinimumWidth = 50;
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649151083);
		dataGridViewTextBoxColumn_2.DataPropertyName = Class16.smethod_0(1648916476);
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648916476);
		dataGridViewTextBoxColumn_2.MinimumWidth = 50;
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1649151102);
		dataGridViewTextBoxColumn_3.DataPropertyName = Class16.smethod_0(1648915467);
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648915467);
		dataGridViewTextBoxColumn_3.MinimumWidth = 50;
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1649151105);
		dataGridViewTextBoxColumn_4.DataPropertyName = Class16.smethod_0(1649151124);
		dataGridViewTextBoxColumn_4.HeaderText = Class16.smethod_0(1649151124);
		dataGridViewTextBoxColumn_4.MinimumWidth = 60;
		dataGridViewTextBoxColumn_4.Name = Class16.smethod_0(1649151134);
		tableLayoutPanel_1.ColumnCount = 1;
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel_1.Controls.Add(groupBox_0, 0, 0);
		tableLayoutPanel_1.Controls.Add(groupBox_1, 0, 1);
		tableLayoutPanel_1.Controls.Add(flowLayoutPanel_0, 0, 2);
		tableLayoutPanel_1.Dock = DockStyle.Fill;
		tableLayoutPanel_1.Location = new Point(642, 3);
		tableLayoutPanel_1.Name = Class16.smethod_0(1649151139);
		tableLayoutPanel_1.RowCount = 3;
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120f));
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50f));
		tableLayoutPanel_1.Size = new Size(269, 509);
		tableLayoutPanel_1.TabIndex = 1;
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(dateTimePicker_0);
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Controls.Add(numericUpDown_0);
		groupBox_0.Controls.Add(label_2);
		groupBox_0.Dock = DockStyle.Fill;
		groupBox_0.Location = new Point(3, 3);
		groupBox_0.Name = Class16.smethod_0(1649077382);
		groupBox_0.Size = new Size(263, 114);
		groupBox_0.TabIndex = 0;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1648918859);
		label_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label_0.Location = new Point(9, 86);
		label_0.Name = Class16.smethod_0(1648970701);
		label_0.Size = new Size(246, 18);
		label_0.TabIndex = 4;
		label_0.Text = Class16.smethod_0(1649151164);
		label_0.TextAlign = ContentAlignment.MiddleLeft;
		dateTimePicker_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dateTimePicker_0.CustomFormat = Class16.smethod_0(1649006896);
		dateTimePicker_0.Format = DateTimePickerFormat.Custom;
		dateTimePicker_0.Location = new Point(81, 54);
		dateTimePicker_0.Name = Class16.smethod_0(1649151171);
		dateTimePicker_0.Size = new Size(174, 22);
		dateTimePicker_0.TabIndex = 3;
		dateTimePicker_0.ValueChanged += numericUpDown_0_ValueChanged;
		label_1.AutoSize = true;
		label_1.Location = new Point(9, 58);
		label_1.Name = Class16.smethod_0(1649151197);
		label_1.Size = new Size(64, 13);
		label_1.TabIndex = 2;
		label_1.Text = Class16.smethod_0(1649191610);
		numericUpDown_0.Location = new Point(81, 25);
		numericUpDown_0.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1649151203);
		numericUpDown_0.Size = new Size(83, 22);
		numericUpDown_0.TabIndex = 1;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		label_2.AutoSize = true;
		label_2.Location = new Point(9, 27);
		label_2.Name = Class16.smethod_0(1649049106);
		label_2.Size = new Size(44, 13);
		label_2.TabIndex = 0;
		label_2.Text = Class16.smethod_0(1649151228);
		groupBox_1.Controls.Add(button_0);
		groupBox_1.Controls.Add(numericUpDown_1);
		groupBox_1.Controls.Add(label_3);
		groupBox_1.Controls.Add(numericUpDown_2);
		groupBox_1.Controls.Add(label_4);
		groupBox_1.Controls.Add(numericUpDown_3);
		groupBox_1.Controls.Add(label_5);
		groupBox_1.Controls.Add(numericUpDown_4);
		groupBox_1.Controls.Add(label_6);
		groupBox_1.Controls.Add(numericUpDown_5);
		groupBox_1.Controls.Add(label_7);
		groupBox_1.Dock = DockStyle.Fill;
		groupBox_1.Location = new Point(3, 123);
		groupBox_1.Name = Class16.smethod_0(1649151234);
		groupBox_1.Size = new Size(263, 333);
		groupBox_1.TabIndex = 1;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1649151251);
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_0.Location = new Point(12, 192);
		button_0.Name = Class16.smethod_0(1648996186);
		button_0.Size = new Size(243, 27);
		button_0.TabIndex = 10;
		button_0.Text = Class16.smethod_0(1649151272);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		numericUpDown_1.Location = new Point(80, 153);
		numericUpDown_1.Maximum = new decimal(new int[4] { 32767, 0, 0, 0 });
		numericUpDown_1.Minimum = new decimal(new int[4] { 32768, 0, 0, -2147483648 });
		numericUpDown_1.Name = Class16.smethod_0(1649151297);
		numericUpDown_1.Size = new Size(92, 22);
		numericUpDown_1.TabIndex = 9;
		label_3.AutoSize = true;
		label_3.Location = new Point(9, 155);
		label_3.Name = Class16.smethod_0(1649151318);
		label_3.Size = new Size(28, 13);
		label_3.TabIndex = 8;
		label_3.Text = Class16.smethod_0(1649151124);
		numericUpDown_2.Location = new Point(80, 123);
		numericUpDown_2.Maximum = new decimal(new int[4] { 32767, 0, 0, 0 });
		numericUpDown_2.Minimum = new decimal(new int[4] { 32768, 0, 0, -2147483648 });
		numericUpDown_2.Name = Class16.smethod_0(1649151323);
		numericUpDown_2.Size = new Size(92, 22);
		numericUpDown_2.TabIndex = 7;
		label_4.AutoSize = true;
		label_4.Location = new Point(9, 125);
		label_4.Name = Class16.smethod_0(1649151342);
		label_4.Size = new Size(13, 13);
		label_4.TabIndex = 6;
		label_4.Text = Class16.smethod_0(1648915467);
		numericUpDown_3.Location = new Point(80, 93);
		numericUpDown_3.Maximum = new decimal(new int[4] { 32767, 0, 0, 0 });
		numericUpDown_3.Minimum = new decimal(new int[4] { 32768, 0, 0, -2147483648 });
		numericUpDown_3.Name = Class16.smethod_0(1649151345);
		numericUpDown_3.Size = new Size(92, 22);
		numericUpDown_3.TabIndex = 5;
		label_5.AutoSize = true;
		label_5.Location = new Point(9, 95);
		label_5.Name = Class16.smethod_0(1649151364);
		label_5.Size = new Size(12, 13);
		label_5.TabIndex = 4;
		label_5.Text = Class16.smethod_0(1648916476);
		numericUpDown_4.Location = new Point(80, 63);
		numericUpDown_4.Maximum = new decimal(new int[4] { 32767, 0, 0, 0 });
		numericUpDown_4.Minimum = new decimal(new int[4] { 32768, 0, 0, -2147483648 });
		numericUpDown_4.Name = Class16.smethod_0(1649151375);
		numericUpDown_4.Size = new Size(92, 22);
		numericUpDown_4.TabIndex = 3;
		label_6.AutoSize = true;
		label_6.Location = new Point(9, 65);
		label_6.Name = Class16.smethod_0(1649151378);
		label_6.Size = new Size(13, 13);
		label_6.TabIndex = 2;
		label_6.Text = Class16.smethod_0(1648916453);
		numericUpDown_5.Location = new Point(80, 33);
		numericUpDown_5.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_5.Minimum = new decimal(new int[4] { 2127483648, 0, 0, -2147483648 });
		numericUpDown_5.Name = Class16.smethod_0(1649151397);
		numericUpDown_5.Size = new Size(120, 22);
		numericUpDown_5.TabIndex = 1;
		label_7.AutoSize = true;
		label_7.Location = new Point(9, 35);
		label_7.Name = Class16.smethod_0(1649151401);
		label_7.Size = new Size(18, 13);
		label_7.TabIndex = 0;
		label_7.Text = Class16.smethod_0(1648941057);
		flowLayoutPanel_0.Controls.Add(button_1);
		flowLayoutPanel_0.Controls.Add(button_2);
		flowLayoutPanel_0.Controls.Add(button_3);
		flowLayoutPanel_0.Dock = DockStyle.Fill;
		flowLayoutPanel_0.Location = new Point(3, 462);
		flowLayoutPanel_0.Name = Class16.smethod_0(1649151421);
		flowLayoutPanel_0.Padding = new Padding(6);
		flowLayoutPanel_0.Size = new Size(263, 44);
		flowLayoutPanel_0.TabIndex = 2;
		button_1.Location = new Point(9, 9);
		button_1.Name = Class16.smethod_0(1649151439);
		button_1.Size = new Size(75, 27);
		button_1.TabIndex = 0;
		button_1.Text = Class16.smethod_0(1648931361);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Location = new Point(90, 9);
		button_2.Name = Class16.smethod_0(1649151452);
		button_2.Size = new Size(75, 27);
		button_2.TabIndex = 1;
		button_2.Text = Class16.smethod_0(1649003400);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Location = new Point(171, 9);
		button_3.Name = Class16.smethod_0(1649151471);
		button_3.Size = new Size(75, 27);
		button_3.TabIndex = 2;
		button_3.Text = Class16.smethod_0(1648925718);
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(914, 561);
		base.Controls.Add(tableLayoutPanel_0);
		base.Controls.Add(statusStrip_0);
		base.Controls.Add(menuStrip_0);
		Font = new Font(Class16.smethod_0(1648942905), 8.25f);
		base.Icon = Resources.edit;
		base.MainMenuStrip = menuStrip_0;
		MinimumSize = new Size(760, 520);
		base.Name = Class16.smethod_0(1649151487);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649150487);
		base.FormClosing += TaskNpcEditorForm_FormClosing;
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		statusStrip_0.ResumeLayout(performLayout: false);
		statusStrip_0.PerformLayout();
		tableLayoutPanel_0.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_0).EndInit();
		tableLayoutPanel_1.ResumeLayout(performLayout: false);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		((ISupportInitialize)numericUpDown_0).EndInit();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		((ISupportInitialize)numericUpDown_1).EndInit();
		((ISupportInitialize)numericUpDown_2).EndInit();
		((ISupportInitialize)numericUpDown_3).EndInit();
		((ISupportInitialize)numericUpDown_4).EndInit();
		((ISupportInitialize)numericUpDown_5).EndInit();
		flowLayoutPanel_0.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
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

	private void button_1_Click(object sender, EventArgs e)
	{
		method_15();
		Class362 @class = new Class362();
		Class362 class2 = bindingList_0.LastOrDefault();
		@class.method_1((class2 == null) ? 1 : (class2.method_0() + 1));
		@class.method_3(0);
		@class.method_5(0);
		@class.method_7(0);
		@class.method_9(0);
		Class362 item = @class;
		bindingList_0.Add(item);
		dataGridView_0.ClearSelection();
		int num = bindingList_0.Count - 1;
		if (num >= 0)
		{
			dataGridView_0.Rows[num].Selected = true;
			dataGridView_0.CurrentCell = dataGridView_0.Rows[num].Cells[0];
		}
		method_7();
		method_9(Class16.smethod_0(1649150509));
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		Class362 @class = method_3();
		if (@class != null)
		{
			method_15();
			Class362 class2 = new Class362();
			class2.method_1(@class.method_0());
			class2.method_3(@class.method_2());
			class2.method_5(@class.method_4());
			class2.method_7(@class.method_6());
			class2.method_9(@class.method_8());
			Class362 item = class2;
			bindingList_0.Add(item);
			int index = bindingList_0.Count - 1;
			dataGridView_0.ClearSelection();
			dataGridView_0.Rows[index].Selected = true;
			dataGridView_0.CurrentCell = dataGridView_0.Rows[index].Cells[0];
			method_7();
			method_9(Class16.smethod_0(1649150532));
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		Class362 @class = method_3();
		if (@class != null)
		{
			method_15();
			int num = dataGridView_0.CurrentRow?.Index ?? (-1);
			bindingList_0.Remove(@class);
			if (num >= 0 && num < dataGridView_0.Rows.Count)
			{
				dataGridView_0.Rows[Math.Min(num, dataGridView_0.Rows.Count - 1)].Selected = true;
			}
			method_7();
			method_9(Class16.smethod_0(1649150556));
		}
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_1)
		{
			int num = (int)(dateTimePicker_0.Value.ToUniversalTime() - dateTime_0).TotalSeconds;
			short num2 = (short)numericUpDown_0.Value;
			if (short_0 != num2 || int_0 != num)
			{
				method_15();
				short_0 = num2;
				int_0 = num;
				method_9(Class16.smethod_0(1649150569));
			}
		}
	}

	private void method_7()
	{
		label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649150592), Class16.smethod_0(1649150620)), bindingList_0.Count);
	}

	private void method_8(string string_1)
	{
		toolStripStatusLabel_0.Text = string_1;
	}

	private void method_9(string string_1)
	{
		bool_0 = true;
		method_8(string_1);
	}

	private void TaskNpcEditorForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!bool_0)
		{
			method_6();
			return;
		}
		DialogResult dialogResult = DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649150637)), TextStorage.Msg(Class16.smethod_0(1649150656)), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.No)
		{
			e.Cancel = true;
		}
		else
		{
			method_6();
		}
	}

	private void method_10()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1649150683), 100);
		fileBasedUndoManager_0.SetStateChangedCallback(method_17);
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_12, method_13);
		method_11();
	}

	private void method_11()
	{
		button_4 = new Button
		{
			Name = Class16.smethod_0(1649211550),
			Text = string.Empty,
			Enabled = false,
			Size = new Size(button_1.Height, button_1.Height),
			Margin = new Padding(3),
			Image = Resources.GShopEditor_PW_mbUndo,
			ImageAlign = ContentAlignment.MiddleCenter,
			FlatStyle = FlatStyle.Standard,
			UseVisualStyleBackColor = true
		};
		button_5 = new Button
		{
			Name = Class16.smethod_0(1649211564),
			Text = string.Empty,
			Enabled = false,
			Size = new Size(button_1.Height, button_1.Height),
			Margin = new Padding(3),
			Image = Resources.GShopEditor_PW_mbRedo,
			ImageAlign = ContentAlignment.MiddleCenter,
			FlatStyle = FlatStyle.Standard,
			UseVisualStyleBackColor = true
		};
		button_4.Click += button_4_Click;
		button_5.Click += button_5_Click;
		flowLayoutPanel_0.Controls.Add(button_5);
		flowLayoutPanel_0.Controls.Add(button_4);
		flowLayoutPanel_0.Controls.SetChildIndex(button_4, 0);
		flowLayoutPanel_0.Controls.SetChildIndex(button_5, 1);
	}

	private byte[] method_12()
	{
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					binaryWriter.Write(string_0 ?? string.Empty);
					binaryWriter.Write((uint)(bindingList_0.Count * 12));
					binaryWriter.Write((int)(dateTimePicker_0.Value.ToUniversalTime() - dateTime_0).TotalSeconds);
					binaryWriter.Write((short)numericUpDown_0.Value);
					binaryWriter.Write(bool_0);
					binaryWriter.Write(dataGridView_0.CurrentRow?.Index ?? (-1));
					binaryWriter.Write(bindingList_0.Count);
					foreach (Class362 item in bindingList_0)
					{
						binaryWriter.Write(item.method_0());
						binaryWriter.Write(item.method_2());
						binaryWriter.Write(item.method_4());
						binaryWriter.Write(item.method_6());
						binaryWriter.Write(item.method_8());
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

	private void method_13(byte[] byte_0)
	{
		if (byte_0 == null || byte_0.Length == 0)
		{
			return;
		}
		bool_1 = true;
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_0);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					string_0 = binaryReader.ReadString();
					uint_0 = binaryReader.ReadUInt32();
					int_0 = binaryReader.ReadInt32();
					short_0 = binaryReader.ReadInt16();
					bool flag = binaryReader.ReadBoolean();
					int int_ = binaryReader.ReadInt32();
					int num = binaryReader.ReadInt32();
					bindingList_0.Clear();
					for (int i = 0; i < num; i++)
					{
						BindingList<Class362> bindingList = bindingList_0;
						Class362 @class = new Class362();
						@class.method_1(binaryReader.ReadInt32());
						@class.method_3(binaryReader.ReadInt16());
						@class.method_5(binaryReader.ReadInt16());
						@class.method_7(binaryReader.ReadInt16());
						@class.method_9(binaryReader.ReadInt16());
						bindingList.Add(@class);
					}
					numericUpDown_0.Value = Math.Min(numericUpDown_0.Maximum, Math.Max(numericUpDown_0.Minimum, short_0));
					DateTime dateTime = dateTime_0.AddSeconds(int_0).ToLocalTime();
					if (dateTime < dateTimePicker_0.MinDate)
					{
						dateTime = dateTimePicker_0.MinDate;
					}
					else if (dateTime > dateTimePicker_0.MaxDate)
					{
						dateTime = dateTimePicker_0.MaxDate;
					}
					dateTimePicker_0.Value = dateTime;
					bool_0 = flag;
					method_7();
					method_14(int_);
					method_4(method_3());
					method_8(Class16.smethod_0(1649150697));
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
			bool_1 = false;
		}
	}

	private void method_14(int int_1)
	{
		if (dataGridView_0.Rows.Count != 0)
		{
			int index = Math.Min(Math.Max(int_1, 0), dataGridView_0.Rows.Count - 1);
			dataGridView_0.ClearSelection();
			dataGridView_0.Rows[index].Selected = true;
			dataGridView_0.CurrentCell = dataGridView_0.Rows[index].Cells[0];
		}
	}

	private void method_15()
	{
		if (!bool_1)
		{
			fileBasedUndoManager_0?.PushUndo(method_12());
		}
	}

	private void method_16()
	{
		fileBasedUndoManager_0?.Clear();
	}

	private void method_17()
	{
		if (button_4 != null)
		{
			button_4.Enabled = fileBasedUndoManager_0?.CanUndo ?? false;
		}
		if (button_5 != null)
		{
			button_5.Enabled = fileBasedUndoManager_0?.CanRedo ?? false;
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_12();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_13(array);
		}
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_12();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_13(array);
		}
	}
}
