using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Properties;

namespace ACE.Elements;

public class FieldTypeEditorForm : Form
{
	private sealed class Class126
	{
		private int int_0;

		private string string_0;

		private string string_1;

		private int int_1;

		private int int_2;

		private string string_2;

		private byte[] byte_0;

		private bool bool_0;

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_3)
		{
			int_0 = int_3;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_3)
		{
			string_0 = string_3;
		}

		public string method_4()
		{
			return string_1;
		}

		public void method_5(string string_3)
		{
			string_1 = string_3;
		}

		public int method_6()
		{
			return int_1;
		}

		public void method_7(int int_3)
		{
			int_1 = int_3;
		}

		public int method_8()
		{
			return int_2;
		}

		public void method_9(int int_3)
		{
			int_2 = int_3;
		}

		public string method_10()
		{
			return string_2;
		}

		public void method_11(string string_3)
		{
			string_2 = string_3;
		}

		public byte[] method_12()
		{
			return byte_0;
		}

		public void method_13(byte[] byte_1)
		{
			byte_0 = byte_1;
		}

		public bool method_14()
		{
			return bool_0;
		}

		public void method_15(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public Class126 method_16()
		{
			Class126 @class = new Class126();
			@class.method_1(method_0());
			@class.method_3(method_2());
			@class.method_5(method_4());
			@class.method_7(method_6());
			@class.method_9(method_8());
			@class.method_11(method_10());
			@class.method_13((method_12() != null) ? ((byte[])method_12().Clone()) : null);
			@class.method_15(method_14());
			return @class;
		}
	}

	private sealed class Class127
	{
		private string string_0;

		private string string_1;

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_2)
		{
			string_0 = string_2;
		}

		public string method_2()
		{
			return string_1;
		}

		public void method_3(string string_2)
		{
			string_1 = string_2;
		}
	}

	private sealed class Class128
	{
		public string string_0;

		internal bool method_0(Class126 class126_0)
		{
			return class126_0.method_2() == string_0;
		}
	}

	private readonly ACE.Elements.eList.eList eList_0;

	private readonly int int_0;

	private readonly byte[] byte_0;

	private readonly int int_1;

	private readonly string[] string_0;

	private readonly string[] string_1;

	private List<Class126> list_0;

	private bool bool_0;

	private string[] string_2;

	private string[] string_3;

	private int int_2 = -1;

	private static readonly string[] string_4 = new string[11]
	{
		Class16.smethod_0(1648989776),
		Class16.smethod_0(1648989786),
		Class16.smethod_0(1648989805),
		Class16.smethod_0(1648989809),
		Class16.smethod_0(1648989830),
		Class16.smethod_0(1648989834),
		Class16.smethod_0(1648902744),
		Class16.smethod_0(1648989855),
		Class16.smethod_0(1648902778),
		Class16.smethod_0(1648902792),
		Class16.smethod_0(1648902764)
	};

	private IContainer icontainer_0;

	private DataGridView dataGridView_0;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private TextBox textBox_0;

	private ComboBox comboBox_0;

	private NumericUpDown numericUpDown_0;

	private Button button_3;

	private Label label_3;

	private GroupBox groupBox_0;

	private CheckBox checkBox_0;

	public bool StructureChanged
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
	}

	public string[] NewTypes
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
	}

	public string[] NewFields
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
	}

	public bool ApplyToAllItems => checkBox_0?.Checked ?? true;

	public FieldTypeEditorForm(ACE.Elements.eList.eList list, int fieldIndex, int elementIndex)
	{
		eList_0 = list;
		int_0 = elementIndex;
		string_0 = (string[])list.elementTypes.Clone();
		string_1 = (string[])list.elementFields.Clone();
		byte_0 = method_3(list, elementIndex);
		int_1 = byte_0.Length;
		method_5();
		method_8();
		label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648980571), Class16.smethod_0(1648980611)), int_1);
		textBox_0.Text = method_10(byte_0);
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		method_11();
		method_12();
		if (fieldIndex >= 0 && fieldIndex < dataGridView_0.Rows.Count)
		{
			dataGridView_0.ClearSelection();
			dataGridView_0.Rows[fieldIndex].Selected = true;
			dataGridView_0.CurrentCell = dataGridView_0.Rows[fieldIndex].Cells[0];
		}
	}

	private void method_0(bool bool_1)
	{
		bool_0 = bool_1;
	}

	private void method_1(string[] string_5)
	{
		string_2 = string_5;
	}

	private void method_2(string[] string_5)
	{
		string_3 = string_5;
	}

	private byte[] method_3(ACE.Elements.eList.eList eList_1, int int_3)
	{
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			try
			{
				for (int i = 0; i < eList_1.elementTypes.Length; i++)
				{
					object object_ = eList_1.elementValues[int_3][i];
					FIELD_DATA_TYPE field_DATA_TYPE_ = eList_1.FieldDataTypes[i];
					method_4(binaryWriter, object_, field_DATA_TYPE_);
				}
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

	private void method_4(BinaryWriter binaryWriter_0, object object_0, FIELD_DATA_TYPE field_DATA_TYPE_0)
	{
		switch (field_DATA_TYPE_0.data_type)
		{
		case FIELD_DATA_TYPE_ENUM.Int:
			binaryWriter_0.Write((int)object_0);
			break;
		case FIELD_DATA_TYPE_ENUM.Int16:
			binaryWriter_0.Write((short)object_0);
			break;
		case FIELD_DATA_TYPE_ENUM.UInt:
			binaryWriter_0.Write((uint)object_0);
			break;
		case FIELD_DATA_TYPE_ENUM.Int64:
			binaryWriter_0.Write((long)object_0);
			break;
		case FIELD_DATA_TYPE_ENUM.UInt64:
			binaryWriter_0.Write((ulong)object_0);
			break;
		case FIELD_DATA_TYPE_ENUM.Float:
			binaryWriter_0.Write((float)object_0);
			break;
		case FIELD_DATA_TYPE_ENUM.Double:
			binaryWriter_0.Write((double)object_0);
			break;
		case FIELD_DATA_TYPE_ENUM.UInt16:
			binaryWriter_0.Write((ushort)object_0);
			break;
		case FIELD_DATA_TYPE_ENUM.String:
		case FIELD_DATA_TYPE_ENUM.WString:
		case FIELD_DATA_TYPE_ENUM.Bool:
			binaryWriter_0.Write((byte[])object_0);
			break;
		}
	}

	private void method_5()
	{
		list_0 = new List<Class126>();
		int num = 0;
		for (int i = 0; i < eList_0.elementFields.Length; i++)
		{
			string string_ = eList_0.elementTypes[i];
			int num2 = method_7(string_);
			Class126 @class = new Class126();
			@class.method_1(i);
			@class.method_3(eList_0.elementFields[i]);
			@class.method_5(string_);
			@class.method_7(num2);
			@class.method_9(num);
			Class126 item = @class;
			list_0.Add(item);
			num += num2;
		}
		method_6();
	}

	private void method_6()
	{
		int num = 0;
		foreach (Class126 item in list_0)
		{
			item.method_9(num);
			item.method_7(method_7(item.method_4()));
			try
			{
				if (num + item.method_6() <= byte_0.Length)
				{
					item.method_13(new byte[item.method_6()]);
					Array.Copy(byte_0, num, item.method_12(), 0, item.method_6());
					item.method_11(method_23(item.method_12(), item.method_4()));
					item.method_15(bool_1: false);
				}
				else
				{
					item.method_11(Class16.smethod_0(1648980655));
					item.method_13(null);
					item.method_15(bool_1: true);
				}
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648980677));
				item.method_11(Class16.smethod_0(1648935998) + ex.Message);
				item.method_15(bool_1: true);
			}
			num += item.method_6();
		}
	}

	private int method_7(string string_5)
	{
		if (!(string_5 == Class16.smethod_0(1648989776)) && !(string_5 == Class16.smethod_0(1648989786)) && !(string_5 == Class16.smethod_0(1648902744)))
		{
			if (!(string_5 == Class16.smethod_0(1648989805)) && !(string_5 == Class16.smethod_0(1648989809)))
			{
				if (!(string_5 == Class16.smethod_0(1648989830)) && !(string_5 == Class16.smethod_0(1648989834)) && !(string_5 == Class16.smethod_0(1648989855)))
				{
					if (string_5.StartsWith(Class16.smethod_0(1648985302)))
					{
						return int.Parse(string_5.Substring(8));
					}
					if (string_5.StartsWith(Class16.smethod_0(1648985317)))
					{
						return int.Parse(string_5.Substring(7));
					}
					if (string_5.StartsWith(Class16.smethod_0(1648985282)))
					{
						return int.Parse(string_5.Substring(5));
					}
					return 4;
				}
				return 8;
			}
			return 2;
		}
		return 4;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_8()
	{
		dataGridView_0 = new DataGridView();
		label_0 = new Label();
		label_1 = new Label();
		label_2 = new Label();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		textBox_0 = new TextBox();
		comboBox_0 = new ComboBox();
		numericUpDown_0 = new NumericUpDown();
		button_3 = new Button();
		label_3 = new Label();
		groupBox_0 = new GroupBox();
		checkBox_0 = new CheckBox();
		((ISupportInitialize)dataGridView_0).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		SuspendLayout();
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		Text = Class16.smethod_0(1648980724);
		base.ClientSize = new Size(1050, 700);
		base.FormBorderStyle = FormBorderStyle.Sizable;
		MinimumSize = new Size(950, 600);
		base.StartPosition = FormStartPosition.CenterParent;
		Font = new Font(Class16.smethod_0(1648942905), 9f);
		base.Icon = Resources.edit;
		base.Name = Class16.smethod_0(1648980769);
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
		tableLayoutPanel.Dock = DockStyle.Fill;
		tableLayoutPanel.ColumnCount = 1;
		tableLayoutPanel.RowCount = 4;
		tableLayoutPanel.Padding = new Padding(10);
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 110f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60f));
		base.Controls.Add(tableLayoutPanel);
		GroupBox groupBox = new GroupBox();
		groupBox.Text = Class16.smethod_0(1648980795);
		groupBox.Dock = DockStyle.Fill;
		tableLayoutPanel.Controls.Add(groupBox, 0, 0);
		label_0.Text = Class16.smethod_0(1648980831);
		label_0.Location = new Point(15, 22);
		label_0.Size = new Size(250, 20);
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		groupBox.Controls.Add(label_0);
		label_1.Text = Class16.smethod_0(1648980857);
		label_1.Location = new Point(280, 22);
		label_1.Size = new Size(200, 20);
		label_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		groupBox.Controls.Add(label_1);
		label_2.Text = Class16.smethod_0(1648980888);
		label_2.Location = new Point(500, 22);
		label_2.Size = new Size(300, 20);
		label_2.ForeColor = Color.Green;
		label_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		groupBox.Controls.Add(label_2);
		Label label = new Label();
		label.Text = Class16.smethod_0(1648980923);
		label.Location = new Point(15, 48);
		label.Size = new Size(100, 20);
		groupBox.Controls.Add(label);
		textBox_0.Location = new Point(120, 45);
		textBox_0.Size = new Size(700, 23);
		textBox_0.ReadOnly = true;
		textBox_0.Font = new Font(Class16.smethod_0(1648929975), 8f);
		textBox_0.BackColor = Color.FromArgb(240, 240, 255);
		groupBox.Controls.Add(textBox_0);
		dataGridView_0.Dock = DockStyle.Fill;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.ReadOnly = true;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.MultiSelect = false;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		dataGridView_0.Font = new Font(Class16.smethod_0(1648929975), 9f);
		dataGridView_0.BackgroundColor = Color.White;
		dataGridView_0.Columns.Add(Class16.smethod_0(1648935608), Class16.smethod_0(1648929947));
		dataGridView_0.Columns.Add(Class16.smethod_0(1648980946), Class16.smethod_0(1648980946));
		dataGridView_0.Columns.Add(Class16.smethod_0(1648980967), Class16.smethod_0(1648980967));
		dataGridView_0.Columns.Add(Class16.smethod_0(1648936875), Class16.smethod_0(1648936875));
		dataGridView_0.Columns.Add(Class16.smethod_0(1648936731), Class16.smethod_0(1648980970));
		dataGridView_0.Columns.Add(Class16.smethod_0(1648941098), Class16.smethod_0(1648980987));
		dataGridView_0.Columns.Add(Class16.smethod_0(1648979987), Class16.smethod_0(1648980002));
		dataGridView_0.Columns[Class16.smethod_0(1648935608)].Width = 30;
		dataGridView_0.Columns[Class16.smethod_0(1648935608)].MinimumWidth = 30;
		dataGridView_0.Columns[Class16.smethod_0(1648980946)].Width = 55;
		dataGridView_0.Columns[Class16.smethod_0(1648980946)].MinimumWidth = 55;
		dataGridView_0.Columns[Class16.smethod_0(1648980967)].Width = 40;
		dataGridView_0.Columns[Class16.smethod_0(1648980967)].MinimumWidth = 40;
		dataGridView_0.Columns[Class16.smethod_0(1648936875)].Width = 90;
		dataGridView_0.Columns[Class16.smethod_0(1648936875)].MinimumWidth = 80;
		dataGridView_0.Columns[Class16.smethod_0(1648979987)].Width = 180;
		dataGridView_0.Columns[Class16.smethod_0(1648979987)].MinimumWidth = 100;
		dataGridView_0.Columns[Class16.smethod_0(1648936731)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridView_0.Columns[Class16.smethod_0(1648936731)].FillWeight = 35f;
		dataGridView_0.Columns[Class16.smethod_0(1648936731)].MinimumWidth = 120;
		dataGridView_0.Columns[Class16.smethod_0(1648941098)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridView_0.Columns[Class16.smethod_0(1648941098)].FillWeight = 65f;
		dataGridView_0.Columns[Class16.smethod_0(1648941098)].MinimumWidth = 150;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridView_0.CellDoubleClick += dataGridView_0_CellDoubleClick;
		tableLayoutPanel.Controls.Add(dataGridView_0, 0, 1);
		groupBox_0.Text = Class16.smethod_0(1648980018);
		groupBox_0.Dock = DockStyle.Fill;
		tableLayoutPanel.Controls.Add(groupBox_0, 0, 2);
		label_3.Text = Class16.smethod_0(1648980049);
		label_3.Location = new Point(15, 25);
		label_3.Size = new Size(300, 20);
		label_3.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Italic);
		groupBox_0.Controls.Add(label_3);
		Label label2 = new Label();
		label2.Text = Class16.smethod_0(1649014090);
		label2.Location = new Point(15, 55);
		label2.Size = new Size(50, 20);
		groupBox_0.Controls.Add(label2);
		comboBox_0.Location = new Point(70, 52);
		comboBox_0.Size = new Size(100, 23);
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Enabled = false;
		ComboBox.ObjectCollection items = comboBox_0.Items;
		object[] items2 = string_4;
		items.AddRange(items2);
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		groupBox_0.Controls.Add(comboBox_0);
		Label label3 = new Label();
		label3.Text = Class16.smethod_0(1648989928);
		label3.Location = new Point(185, 55);
		label3.Size = new Size(40, 20);
		groupBox_0.Controls.Add(label3);
		numericUpDown_0.Location = new Point(230, 52);
		numericUpDown_0.Size = new Size(70, 23);
		numericUpDown_0.Minimum = 1m;
		numericUpDown_0.Maximum = 4096m;
		numericUpDown_0.Value = 64m;
		numericUpDown_0.Enabled = false;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		groupBox_0.Controls.Add(numericUpDown_0);
		int num = 320;
		int[] array = new int[6] { 16, 32, 64, 128, 256, 512 };
		for (int i = 0; i < array.Length; i++)
		{
			int num2 = array[i];
			Button button = new Button();
			button.Text = num2.ToString();
			button.Location = new Point(num, 52);
			button.Size = new Size(45, 23);
			button.Tag = num2;
			button.Click += method_13;
			groupBox_0.Controls.Add(button);
			num += 50;
		}
		button_3.Text = Class16.smethod_0(1648980095);
		button_3.Location = new Point(630, 50);
		button_3.Size = new Size(130, 27);
		button_3.BackColor = Color.FromArgb(66, 139, 202);
		button_3.ForeColor = Color.White;
		button_3.FlatStyle = FlatStyle.Flat;
		button_3.Enabled = false;
		button_3.Click += button_3_Click;
		groupBox_0.Controls.Add(button_3);
		Button button2 = new Button();
		button2.Text = Class16.smethod_0(1648980119);
		button2.Location = new Point(770, 20);
		button2.Size = new Size(55, 27);
		button2.Click += method_14;
		groupBox_0.Controls.Add(button2);
		Button button3 = new Button();
		button3.Text = Class16.smethod_0(1648980134);
		button3.Location = new Point(770, 52);
		button3.Size = new Size(55, 27);
		button3.Click += method_15;
		groupBox_0.Controls.Add(button3);
		Button button4 = new Button();
		button4.Text = Class16.smethod_0(1648980145);
		button4.Location = new Point(830, 20);
		button4.Size = new Size(55, 27);
		button4.BackColor = Color.FromArgb(92, 184, 92);
		button4.ForeColor = Color.White;
		button4.FlatStyle = FlatStyle.Flat;
		button4.Click += method_16;
		groupBox_0.Controls.Add(button4);
		Button button5 = new Button();
		button5.Text = Class16.smethod_0(1648980165);
		button5.Location = new Point(830, 52);
		button5.Size = new Size(55, 27);
		button5.BackColor = Color.FromArgb(217, 83, 79);
		button5.ForeColor = Color.White;
		button5.FlatStyle = FlatStyle.Flat;
		button5.Click += method_17;
		groupBox_0.Controls.Add(button5);
		Panel panel = new Panel();
		panel.Dock = DockStyle.Fill;
		tableLayoutPanel.Controls.Add(panel, 0, 3);
		checkBox_0.Text = Class16.smethod_0(1648980180);
		checkBox_0.Location = new Point(10, 15);
		checkBox_0.Size = new Size(250, 25);
		checkBox_0.Checked = true;
		panel.Controls.Add(checkBox_0);
		Button button6 = new Button();
		button6.Text = Class16.smethod_0(1648980218);
		button6.Location = new Point(270, 12);
		button6.Size = new Size(100, 32);
		button6.BackColor = Color.FromArgb(91, 192, 222);
		button6.ForeColor = Color.White;
		button6.FlatStyle = FlatStyle.Flat;
		button6.Click += method_24;
		panel.Controls.Add(button6);
		Button button7 = new Button();
		button7.Text = Class16.smethod_0(1648980240);
		button7.Location = new Point(380, 12);
		button7.Size = new Size(100, 32);
		button7.BackColor = Color.FromArgb(153, 102, 204);
		button7.ForeColor = Color.White;
		button7.FlatStyle = FlatStyle.Flat;
		button7.Click += method_30;
		panel.Controls.Add(button7);
		button_2.Text = Class16.smethod_0(1648980269);
		button_2.Location = new Point(510, 12);
		button_2.Size = new Size(110, 32);
		button_2.BackColor = Color.FromArgb(240, 173, 78);
		button_2.ForeColor = Color.White;
		button_2.FlatStyle = FlatStyle.Flat;
		button_2.Click += button_2_Click;
		panel.Controls.Add(button_2);
		button_0.Text = Class16.smethod_0(1648980293);
		button_0.Location = new Point(630, 12);
		button_0.Size = new Size(120, 32);
		button_0.BackColor = Color.FromArgb(92, 184, 92);
		button_0.ForeColor = Color.White;
		button_0.FlatStyle = FlatStyle.Flat;
		button_0.Click += button_0_Click;
		panel.Controls.Add(button_0);
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.Location = new Point(760, 12);
		button_1.Size = new Size(80, 32);
		button_1.BackColor = Color.FromArgb(217, 83, 79);
		button_1.ForeColor = Color.White;
		button_1.FlatStyle = FlatStyle.Flat;
		button_1.Click += button_1_Click;
		panel.Controls.Add(button_1);
		((ISupportInitialize)dataGridView_0).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
		ResumeLayout(performLayout: false);
	}

	private int method_9()
	{
		int num = 0;
		foreach (Class126 item in list_0)
		{
			num += method_7(item.method_4());
		}
		return num;
	}

	private string method_10(byte[] byte_1)
	{
		if (byte_1 != null && byte_1.Length != 0)
		{
			if (byte_1.Length > 200)
			{
				return BitConverter.ToString(byte_1, 0, 200).Replace('-', ' ') + string.Format(Class16.smethod_0(1648980323), byte_1.Length);
			}
			return BitConverter.ToString(byte_1).Replace('-', ' ');
		}
		return Class16.smethod_0(1648980317);
	}

	private void method_11()
	{
		dataGridView_0.Rows.Clear();
		foreach (Class126 item in list_0)
		{
			int index = dataGridView_0.Rows.Add(item.method_0(), string.Format(Class16.smethod_0(1648980359), item.method_8()), item.method_6(), item.method_4(), item.method_2(), item.method_10(), (item.method_12() != null) ? BitConverter.ToString(item.method_12()).Replace('-', ' ') : string.Empty);
			if (item.method_14())
			{
				dataGridView_0.Rows[index].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
			}
			else if (!item.method_4().StartsWith(Class16.smethod_0(1648902778)) && !item.method_4().StartsWith(Class16.smethod_0(1648902792)))
			{
				if (item.method_4() == Class16.smethod_0(1648902744) || item.method_4() == Class16.smethod_0(1648989855))
				{
					dataGridView_0.Rows[index].DefaultCellStyle.BackColor = TDark.FieldFloatBack;
				}
			}
			else
			{
				dataGridView_0.Rows[index].DefaultCellStyle.BackColor = TDark.FieldStringBack;
			}
		}
	}

	private void method_12()
	{
		int num = method_9();
		label_1.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648980374), Class16.smethod_0(1648980403)), num);
		if (num == int_1)
		{
			label_2.Text = TextStorage.Msg(Class16.smethod_0(1648980444), Class16.smethod_0(1648983559));
			label_2.ForeColor = Color.Green;
			button_0.Enabled = true;
		}
		else
		{
			int num2 = num - int_1;
			string arg = ((num2 > 0) ? Class16.smethod_0(1648941500) : string.Empty);
			label_2.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648983644), Class16.smethod_0(1648983692)), arg, num2);
			label_2.ForeColor = Color.Red;
			button_0.Enabled = false;
		}
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		if (dataGridView_0.SelectedRows.Count == 0)
		{
			int_2 = -1;
			label_3.Text = TextStorage.Msg(Class16.smethod_0(1648983807), Class16.smethod_0(1648980049));
			comboBox_0.Enabled = false;
			numericUpDown_0.Enabled = false;
			button_3.Enabled = false;
			return;
		}
		int_2 = dataGridView_0.SelectedRows[0].Index;
		Class126 @class = list_0[int_2];
		label_3.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648983845), Class16.smethod_0(1648983876)), @class.method_0(), @class.method_2(), @class.method_4());
		comboBox_0.Enabled = true;
		button_3.Enabled = true;
		string value = method_19(@class.method_4());
		int num = Array.IndexOf(string_4, value);
		if (num >= 0)
		{
			comboBox_0.SelectedIndex = num;
		}
		if (method_20(@class.method_4()))
		{
			numericUpDown_0.Enabled = true;
			numericUpDown_0.Value = method_21(@class.method_4());
		}
		else
		{
			numericUpDown_0.Enabled = false;
			numericUpDown_0.Value = method_7(@class.method_4());
		}
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex < 0 || e.RowIndex >= list_0.Count)
		{
			return;
		}
		Class126 @class = list_0[e.RowIndex];
		string[] array = new string[6]
		{
			Class16.smethod_0(1648989776),
			Class16.smethod_0(1648989786),
			Class16.smethod_0(1648902744),
			Class16.smethod_0(1648985265),
			Class16.smethod_0(1648983916),
			Class16.smethod_0(1648983932)
		};
		int num = -1;
		for (int i = 0; i < array.Length; i++)
		{
			if (@class.method_4() == array[i] || @class.method_4().StartsWith(method_19(array[i])))
			{
				num = i;
				break;
			}
		}
		string text = array[(num + 1) % array.Length];
		@class.method_5(text);
		int rowIndex = e.RowIndex;
		method_6();
		method_11();
		method_12();
		int_2 = rowIndex;
		method_18(rowIndex);
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		string text = comboBox_0.SelectedItem?.ToString();
		numericUpDown_0.Enabled = method_20(text ?? string.Empty);
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
	}

	private void method_13(object sender, EventArgs e)
	{
		if (sender is Button { Tag: var tag } && tag is int num)
		{
			numericUpDown_0.Value = num;
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (int_2 < 0 || int_2 >= list_0.Count)
		{
			return;
		}
		object selectedItem = comboBox_0.SelectedItem;
		object obj;
		if (selectedItem == null)
		{
			obj = null;
		}
		else
		{
			obj = selectedItem.ToString();
			if (obj != null)
			{
				goto IL_0044;
			}
		}
		obj = Class16.smethod_0(1648989776);
		goto IL_0044;
		IL_0044:
		string string_ = (string)obj;
		string text = method_22(string_, (int)numericUpDown_0.Value);
		list_0[int_2].method_5(text);
		method_6();
		method_11();
		method_12();
		method_18(int_2);
	}

	private void method_14(object sender, EventArgs e)
	{
		if (int_2 > 1 && int_2 < list_0.Count)
		{
			int num = int_2 - 1;
			Class126 value = list_0[int_2];
			list_0[int_2] = list_0[num];
			list_0[num] = value;
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].method_1(i);
			}
			method_6();
			method_11();
			method_12();
			int_2 = num;
			method_18(num);
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		if (int_2 >= 1 && int_2 < list_0.Count - 1)
		{
			int num = int_2 + 1;
			Class126 value = list_0[int_2];
			list_0[int_2] = list_0[num];
			list_0[num] = value;
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].method_1(i);
			}
			method_6();
			method_11();
			method_12();
			int_2 = num;
			method_18(num);
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		int num = ((int_2 >= 0) ? (int_2 + 1) : list_0.Count);
		AddFieldDialog addFieldDialog = new AddFieldDialog();
		try
		{
			if (addFieldDialog.ShowDialog(this) == DialogResult.OK)
			{
				Class126 @class = new Class126();
				@class.method_1(num);
				@class.method_3(addFieldDialog.FieldName);
				@class.method_5(addFieldDialog.FieldType);
				@class.method_7(method_7(addFieldDialog.FieldType));
				@class.method_9(0);
				Class126 item = @class;
				list_0.Insert(num, item);
				for (int i = 0; i < list_0.Count; i++)
				{
					list_0[i].method_1(i);
				}
				method_6();
				method_11();
				method_12();
				int_2 = num;
				method_18(num);
			}
		}
		finally
		{
			((IDisposable)addFieldDialog).Dispose();
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		if (int_2 >= 0 && int_2 < list_0.Count)
		{
			if (int_2 == 0)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648984035), Class16.smethod_0(1648983061)), Class16.smethod_0(1648983095), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			Class126 @class = list_0[int_2];
			DialogResult dialogResult = DKBox.Show(string.Format(Class16.smethod_0(1648983107), @class.method_2(), @class.method_4(), @class.method_6()) + Class16.smethod_0(1648983152), Class16.smethod_0(1648983205), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				int val = int_2;
				list_0.RemoveAt(int_2);
				for (int i = 0; i < list_0.Count; i++)
				{
					list_0[i].method_1(i);
				}
				method_6();
				method_11();
				method_12();
				int num = Math.Min(val, list_0.Count - 1);
				if (num >= 0)
				{
					int_2 = num;
					method_18(num);
				}
				else
				{
					int_2 = -1;
				}
			}
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648983937), Class16.smethod_0(1648983977)), Class16.smethod_0(1648984016), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void method_18(int int_3)
	{
		if (int_3 >= 0 && int_3 < dataGridView_0.Rows.Count)
		{
			dataGridView_0.ClearSelection();
			dataGridView_0.Rows[int_3].Selected = true;
			if (dataGridView_0.Rows[int_3].Cells.Count > 0)
			{
				dataGridView_0.CurrentCell = dataGridView_0.Rows[int_3].Cells[0];
			}
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_5();
		method_11();
		method_12();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		int num = method_9();
		if (num != int_1)
		{
			DKBox.Show(string.Format(Class16.smethod_0(1648983218), num) + string.Format(Class16.smethod_0(1648983289), int_1) + Class16.smethod_0(1648983356), Class16.smethod_0(1648983403), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		bool flag = false;
		for (int i = 0; i < list_0.Count; i++)
		{
			if (list_0[i].method_4() != string_0[i] || list_0[i].method_2() != string_1[i])
			{
				flag = true;
				break;
			}
		}
		for (int j = 0; j < list_0.Count; j++)
		{
			int num2 = Array.IndexOf(string_1, list_0[j].method_2());
			if (num2 != j)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648983431), Class16.smethod_0(1648983459)), Class16.smethod_0(1648983495), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			base.DialogResult = DialogResult.Cancel;
			return;
		}
		method_1(new string[list_0.Count]);
		method_2(new string[list_0.Count]);
		for (int k = 0; k < list_0.Count; k++)
		{
			NewTypes[k] = list_0[k].method_4();
			NewFields[k] = list_0[k].method_2();
		}
		method_0(bool_1: true);
		base.DialogResult = DialogResult.OK;
	}

	private string method_19(string string_5)
	{
		if (string_5.StartsWith(Class16.smethod_0(1648985302)))
		{
			return Class16.smethod_0(1648902778);
		}
		if (string_5.StartsWith(Class16.smethod_0(1648985317)))
		{
			return Class16.smethod_0(1648902792);
		}
		if (string_5.StartsWith(Class16.smethod_0(1648985282)))
		{
			return Class16.smethod_0(1648902764);
		}
		return string_5;
	}

	private bool method_20(string string_5)
	{
		if (!(string_5 == Class16.smethod_0(1648902778)) && !(string_5 == Class16.smethod_0(1648902792)) && !(string_5 == Class16.smethod_0(1648902764)) && !string_5.StartsWith(Class16.smethod_0(1648985302)) && !string_5.StartsWith(Class16.smethod_0(1648985317)))
		{
			return string_5.StartsWith(Class16.smethod_0(1648985282));
		}
		return true;
	}

	private int method_21(string string_5)
	{
		if (string_5.StartsWith(Class16.smethod_0(1648985302)))
		{
			return int.Parse(string_5.Substring(8));
		}
		if (string_5.StartsWith(Class16.smethod_0(1648985317)))
		{
			return int.Parse(string_5.Substring(7));
		}
		if (string_5.StartsWith(Class16.smethod_0(1648985282)))
		{
			return int.Parse(string_5.Substring(5));
		}
		return 64;
	}

	private string method_22(string string_5, int int_3)
	{
		if (!(string_5 == Class16.smethod_0(1648902778)) && !(string_5 == Class16.smethod_0(1648902792)) && !(string_5 == Class16.smethod_0(1648902764)))
		{
			return string_5;
		}
		return string.Format(Class16.smethod_0(1648989868), string_5, int_3);
	}

	private string method_23(byte[] byte_1, string string_5)
	{
		if (byte_1 != null && byte_1.Length != 0)
		{
			try
			{
				if (string_5 == Class16.smethod_0(1648989776) && byte_1.Length >= 4)
				{
					return BitConverter.ToInt32(byte_1, 0).ToString();
				}
				if (string_5 == Class16.smethod_0(1648989786) && byte_1.Length >= 4)
				{
					return BitConverter.ToUInt32(byte_1, 0).ToString();
				}
				if (string_5 == Class16.smethod_0(1648989805) && byte_1.Length >= 2)
				{
					return BitConverter.ToInt16(byte_1, 0).ToString();
				}
				if (string_5 == Class16.smethod_0(1648989809) && byte_1.Length >= 2)
				{
					return BitConverter.ToUInt16(byte_1, 0).ToString();
				}
				if (string_5 == Class16.smethod_0(1648989830) && byte_1.Length >= 8)
				{
					return BitConverter.ToInt64(byte_1, 0).ToString();
				}
				if (string_5 == Class16.smethod_0(1648989834) && byte_1.Length >= 8)
				{
					return BitConverter.ToUInt64(byte_1, 0).ToString();
				}
				if (string_5 == Class16.smethod_0(1648902744) && byte_1.Length >= 4)
				{
					float num = BitConverter.ToSingle(byte_1, 0);
					if (!float.IsNaN(num) && !float.IsInfinity(num))
					{
						return num.ToString(Class16.smethod_0(1648983526));
					}
					return string.Format(Class16.smethod_0(1648983504), num);
				}
				if (string_5 == Class16.smethod_0(1648989855) && byte_1.Length >= 8)
				{
					double num2 = BitConverter.ToDouble(byte_1, 0);
					if (!double.IsNaN(num2) && !double.IsInfinity(num2))
					{
						return num2.ToString(Class16.smethod_0(1648983535));
					}
					return string.Format(Class16.smethod_0(1648983504), num2);
				}
				if (string_5.StartsWith(Class16.smethod_0(1648985302)))
				{
					string text = Encoding.Unicode.GetString(byte_1);
					int num3 = text.IndexOf('\0');
					return (num3 >= 0) ? text.Substring(0, num3) : text;
				}
				if (string_5.StartsWith(Class16.smethod_0(1648985317)))
				{
					string text2 = Encoding.GetEncoding(Class16.smethod_0(1648985403)).GetString(byte_1);
					int num4 = text2.IndexOf('\0');
					return (num4 >= 0) ? text2.Substring(0, num4) : text2;
				}
				if (string_5.StartsWith(Class16.smethod_0(1648985282)))
				{
					if (byte_1.Length <= 16)
					{
						return BitConverter.ToString(byte_1).Replace('-', ' ');
					}
					return BitConverter.ToString(byte_1, 0, 16).Replace('-', ' ') + Class16.smethod_0(1648924410);
				}
				return BitConverter.ToString(byte_1);
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648983537));
				return Class16.smethod_0(1648935998) + ex.Message;
			}
		}
		return Class16.smethod_0(1648980317);
	}

	public int[] GetFieldOrderMapping()
	{
		int[] array = new int[list_0.Count];
		for (int i = 0; i < list_0.Count; i++)
		{
			array[i] = Array.IndexOf(string_1, list_0[i].method_2());
		}
		return array;
	}

	private void method_24(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		try
		{
			folderBrowserDialog.Description = TextStorage.Msg(Class16.smethod_0(1648982560), Class16.smethod_0(1648982601));
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				string text = method_29(eList_0.ListName);
				string text2 = System.IO.Path.Combine(folderBrowserDialog.SelectedPath, text + Class16.smethod_0(1648982655));
				try
				{
					string contents = method_25(text);
					File.WriteAllText(text2, contents);
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648982656), Class16.smethod_0(1648982700)), text2), Class16.smethod_0(1648982732), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1648982756));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648982805), Class16.smethod_0(1648982835)), ex.Message), Class16.smethod_0(1648997892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
		}
		finally
		{
			((IDisposable)folderBrowserDialog).Dispose();
		}
	}

	private string method_25(string string_5)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(Class16.smethod_0(1648982877) + string_5 + Class16.smethod_0(1648982883));
		stringBuilder.AppendLine();
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = 0; i < list_0.Count; i++)
		{
			if (hashSet.Contains(i))
			{
				continue;
			}
			Class126 @class = list_0[i];
			int int_;
			List<Class127> list_;
			string text = method_27(i, out int_, out list_);
			if (text != null && int_ > 1)
			{
				int count = list_.Count;
				for (int j = 0; j < int_ * count && i + j < list_0.Count; j++)
				{
					hashSet.Add(i + j);
				}
				if (count == 1)
				{
					string string_6;
					string text2 = method_28(list_[0].method_2(), list_[0].method_0(), out string_6, bool_1: false);
					stringBuilder.AppendLine(string.Format(Class16.smethod_0(1648982900), text2, text, string_6, int_));
					continue;
				}
				stringBuilder.AppendLine(Class16.smethod_0(1648982924));
				foreach (Class127 item in list_)
				{
					string string_7;
					string text3 = method_28(item.method_2(), item.method_0(), out string_7, bool_1: false);
					stringBuilder.AppendLine(Class16.smethod_0(1648982940) + text3 + Class16.smethod_0(1648942211) + item.method_0() + string_7 + Class16.smethod_0(1648898262));
				}
				stringBuilder.AppendLine(string.Format(Class16.smethod_0(1648982949), text, int_));
			}
			else
			{
				hashSet.Add(i);
				string text4 = method_26(@class.method_2(), i);
				string string_8;
				string text5 = method_28(@class.method_4(), text4, out string_8, i == 0);
				stringBuilder.AppendLine(Class16.smethod_0(1648904383) + text5 + Class16.smethod_0(1648942211) + text4 + string_8 + Class16.smethod_0(1648898262));
			}
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(Class16.smethod_0(1648982961));
		return stringBuilder.ToString();
	}

	private string method_26(string string_5, int int_3)
	{
		if (int_3 == 0 && string_5.Equals(Class16.smethod_0(1648941057), StringComparison.OrdinalIgnoreCase))
		{
			return Class16.smethod_0(1648932143);
		}
		if (string_5.Equals(Class16.smethod_0(1648936731), StringComparison.OrdinalIgnoreCase))
		{
			return Class16.smethod_0(1648905100);
		}
		return string_5;
	}

	private string method_27(int int_3, out int int_4, out List<Class127> list_1)
	{
		int_4 = 0;
		list_1 = new List<Class127>();
		if (int_3 >= list_0.Count)
		{
			return null;
		}
		Class126 @class = list_0[int_3];
		Match match = Regex.Match(@class.method_2(), Class16.smethod_0(1648982970));
		if (!match.Success)
		{
			return null;
		}
		string value = match.Groups[1].Value;
		int num = int.Parse(match.Groups[2].Value);
		string item = (match.Groups[3].Success ? match.Groups[3].Value : null);
		List<(int, string, string)> list = new List<(int, string, string)>();
		list.Add((int_3, item, @class.method_4()));
		for (int i = int_3 + 1; i < list_0.Count; i++)
		{
			Class126 class2 = list_0[i];
			Match match2 = Regex.Match(class2.method_2(), Class16.smethod_0(1648982970));
			if (!match2.Success)
			{
				break;
			}
			string value2 = match2.Groups[1].Value;
			int num2 = int.Parse(match2.Groups[2].Value);
			string item2 = (match2.Groups[3].Success ? match2.Groups[3].Value : null);
			if (!(value2 == value) || num2 != num)
			{
				break;
			}
			list.Add((i, item2, class2.method_4()));
		}
		int count = list.Count;
		int num3 = 1;
		int num4 = num + 1;
		for (int j = int_3 + count; j < list_0.Count; j += count)
		{
			bool flag = true;
			for (int k = 0; k < count && j + k < list_0.Count; k++)
			{
				Class126 class3 = list_0[j + k];
				Match match3 = Regex.Match(class3.method_2(), Class16.smethod_0(1648982970));
				if (match3.Success)
				{
					string value3 = match3.Groups[1].Value;
					int num5 = int.Parse(match3.Groups[2].Value);
					string text = (match3.Groups[3].Success ? match3.Groups[3].Value : null);
					(int, string, string) tuple = list[k];
					if (value3 != value || num5 != num4 || text != tuple.Item2 || class3.method_4() != tuple.Item3)
					{
						flag = false;
						break;
					}
					continue;
				}
				flag = false;
				break;
			}
			if (!flag)
			{
				break;
			}
			num3++;
			num4++;
		}
		if (num3 < 3)
		{
			return null;
		}
		int_4 = num3;
		foreach (var item5 in list)
		{
			_ = item5.Item1;
			string item3 = item5.Item2;
			string item4 = item5.Item3;
			string text2 = item3 ?? value;
			List<Class127> obj = list_1;
			Class127 class4 = new Class127();
			class4.method_1(text2);
			class4.method_3(item4);
			obj.Add(class4);
		}
		return value;
	}

	private string method_28(string string_5, string string_6, out string string_7, bool bool_1)
	{
		string_7 = string.Empty;
		string text = string_6.ToLowerInvariant();
		if (string_5 == Class16.smethod_0(1648989776))
		{
			if (bool_1 && text == Class16.smethod_0(1648932143))
			{
				return Class16.smethod_0(1648985984);
			}
			return Class16.smethod_0(1648989776);
		}
		if (string_5 == Class16.smethod_0(1648989786))
		{
			return Class16.smethod_0(1648985984);
		}
		if (string_5 == Class16.smethod_0(1648989805))
		{
			return Class16.smethod_0(1648986043);
		}
		if (string_5 == Class16.smethod_0(1648989809))
		{
			return Class16.smethod_0(1648986063);
		}
		if (string_5 == Class16.smethod_0(1648989830))
		{
			return Class16.smethod_0(1648985159);
		}
		if (string_5 == Class16.smethod_0(1648989834))
		{
			return Class16.smethod_0(1648983000);
		}
		if (string_5 == Class16.smethod_0(1648902744))
		{
			return Class16.smethod_0(1648902744);
		}
		if (string_5 == Class16.smethod_0(1648989855))
		{
			return Class16.smethod_0(1648989855);
		}
		if (string_5.StartsWith(Class16.smethod_0(1648985302)))
		{
			int num = int.Parse(string_5.Substring(8));
			int num2 = num / 2;
			string_7 = string.Format(Class16.smethod_0(1649004723), num2);
			return Class16.smethod_0(1648985199);
		}
		if (string_5.StartsWith(Class16.smethod_0(1648985317)))
		{
			int num3 = int.Parse(string_5.Substring(7));
			string_7 = string.Format(Class16.smethod_0(1649004723), num3);
			return Class16.smethod_0(1648985163);
		}
		if (string_5.StartsWith(Class16.smethod_0(1648985282)))
		{
			int num4 = int.Parse(string_5.Substring(5));
			string_7 = string.Format(Class16.smethod_0(1649004723), num4);
			return Class16.smethod_0(1648983029);
		}
		return Class16.smethod_0(1648989776);
	}

	private string method_29(string string_5)
	{
		if (string.IsNullOrEmpty(string_5))
		{
			return Class16.smethod_0(1648982017);
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in string_5)
		{
			if (char.IsLetterOrDigit(c))
			{
				stringBuilder.Append(char.ToUpperInvariant(c));
			}
			else if (c == ' ' || c == '-' || c == '_')
			{
				stringBuilder.Append('_');
			}
		}
		string text = stringBuilder.ToString();
		if (text.Length > 0 && char.IsDigit(text[0]))
		{
			text = Class16.smethod_0(1648923968) + text;
		}
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		return Class16.smethod_0(1648982017);
	}

	private void method_30(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		try
		{
			folderBrowserDialog.Description = TextStorage.Msg(Class16.smethod_0(1648982046), Class16.smethod_0(1648982081));
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				string text = method_29(eList_0.ListName);
				string text2 = System.IO.Path.Combine(folderBrowserDialog.SelectedPath, text + Class16.smethod_0(1648982128));
				try
				{
					string contents = method_31();
					File.WriteAllText(text2, contents);
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648982157), Class16.smethod_0(1648982186)), text2), Class16.smethod_0(1648982732), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1648982219));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648982278), Class16.smethod_0(1648982319)), ex.Message), Class16.smethod_0(1648997892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
		}
		finally
		{
			((IDisposable)folderBrowserDialog).Dispose();
		}
	}

	private string method_31()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(Class16.smethod_0(1648982356) + eList_0.ListName + Class16.smethod_0(1648982391));
		stringBuilder.AppendLine(string.Format(Class16.smethod_0(1648982394), DateTime.Now));
		stringBuilder.AppendLine(string.Format(Class16.smethod_0(1648980611), int_1));
		stringBuilder.AppendLine(string.Format(Class16.smethod_0(1648982435), method_9()));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(Class16.smethod_0(1648982478));
		stringBuilder.AppendLine();
		List<string> list = new List<string>();
		for (int i = 0; i < list_0.Count; i++)
		{
			Class126 @class = list_0[i];
			int num = Array.IndexOf(string_1, @class.method_2());
			if (num < 0)
			{
				list.Add(string.Format(Class16.smethod_0(1648982498), i, @class.method_2(), @class.method_4(), @class.method_8()));
				continue;
			}
			if (num < string_0.Length && string_0[num] != @class.method_4())
			{
				list.Add(string.Format(Class16.smethod_0(1648977433), i, @class.method_2()));
				list.Add(Class16.smethod_0(1648977478) + string_0[num]);
				list.Add(Class16.smethod_0(1648977492) + @class.method_4());
			}
			if (num != i)
			{
				list.Add(Class16.smethod_0(1648977498) + @class.method_2());
				list.Add(string.Format(Class16.smethod_0(1648977520), num));
				list.Add(string.Format(Class16.smethod_0(1648977547), i));
			}
		}
		for (int j = 0; j < string_1.Length; j++)
		{
			Class128 class2 = new Class128();
			class2.string_0 = string_1[j];
			if (!list_0.Any(class2.method_0))
			{
				list.Add(string.Format(Class16.smethod_0(1648977582), class2.string_0, j, string_0[j]));
			}
		}
		if (list.Count == 0)
		{
			stringBuilder.AppendLine(Class16.smethod_0(1648977635));
		}
		else
		{
			foreach (string item in list)
			{
				stringBuilder.AppendLine(item);
			}
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(Class16.smethod_0(1648977670));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(string.Format(Class16.smethod_0(1648977702), Class16.smethod_0(1648929947), Class16.smethod_0(1648980946), Class16.smethod_0(1648980967), Class16.smethod_0(1648936875), Class16.smethod_0(1648980970)));
		stringBuilder.AppendLine(new string('-', 70));
		foreach (Class126 item2 in list_0)
		{
			stringBuilder.AppendLine(string.Format(Class16.smethod_0(1648977742), item2.method_0(), item2.method_8(), item2.method_6(), item2.method_4(), item2.method_2()));
		}
		return stringBuilder.ToString();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}
}
