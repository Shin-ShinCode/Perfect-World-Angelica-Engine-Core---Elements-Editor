using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.License;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class ChangeValuesWindow : Form
{
	private static class Class124
	{
		public static Comparison<string> comparison_0;
	}

	private CommonStorage commonStorage_0;

	private string[] string_0;

	private SettingsClass settingsClass_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private TextBox textBox_0;

	private RadioButton radioButton_0;

	private Label label_0;

	private Label label_1;

	private TextBox textBox_1;

	private NumericUpDown numericUpDown_0;

	private RadioButton radioButton_1;

	private Label label_2;

	private Label label_3;

	private NumericUpDown numericUpDown_1;

	private Label label_4;

	private NumericUpDown numericUpDown_2;

	private Label label_5;

	private NumericUpDown numericUpDown_3;

	private RadioButton radioButton_2;

	private GroupBox groupBox_0;

	private GroupBox groupBox_1;

	private GroupBox groupBox_2;

	private Label label_6;

	private GroupBox groupBox_3;

	private GroupBox groupBox_4;

	private Label label_7;

	private LinkLabel linkLabel_0;

	private RadioButton radioButton_3;

	private RadioButton radioButton_4;

	private RadioButton radioButton_5;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_2;

	private RadioButton radioButton_6;

	private RadioButton radioButton_7;

	private ComboBox comboBox_0;

	private NumericUpDown numericUpDown_4;

	public Container components;

	public ChangeValuesWindow(string value, CommonStorage ref_CStorage, [MarshalAs(UnmanagedType.U1)] bool IsFloat, [MarshalAs(UnmanagedType.U1)] bool IsInt)
	{
		try
		{
			bool_0 = false;
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			bool_1 = IsFloat;
			bool_2 = IsInt;
			commonStorage_0 = ref_CStorage;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			comboBox_0.SelectedIndex = 0;
			settingsClass_0 = CommonStorage.Profile;
			textBox_2.Text = value;
			if (ACE.RSGlobal.RSGlobal.IsNumber(value))
			{
				numericUpDown_0.Text = value;
				double num = Convert.ToDouble(value);
				numericUpDown_3.Text = num.ToString();
				double num2 = Convert.ToDouble(value) + 10.0;
				numericUpDown_2.Text = num2.ToString();
			}
			if (bool_2)
			{
				numericUpDown_3.DecimalPlaces = 0;
				numericUpDown_2.DecimalPlaces = 0;
				numericUpDown_0.DecimalPlaces = 0;
				numericUpDown_1.DecimalPlaces = 0;
			}
			byte b = (byte)((!bool_1 && !bool_2) ? 1u : 0u);
			groupBox_1.Enabled = b != 0;
			radioButton_0.Enabled = groupBox_1.Enabled;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void ChangeValuesWindow_Load(object sender, EventArgs e)
	{
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648990174), vars);
			HINTS.ToolTipWindow.ShowToolTip(IntPtr.Zero, text, 3000);
			GC.KeepAlive(this);
			return;
		}
		if (string_0 == null)
		{
			method_3();
		}
		CommonStorage.sarr1 = string_0;
		if (radioButton_6.Checked)
		{
			settingsClass_0.SaveSetting(Class16.smethod_0(1648990197), Class16.smethod_0(1648989198), Class16.smethod_0(1648924112));
		}
		else if (radioButton_0.Checked)
		{
			settingsClass_0.SaveSetting(Class16.smethod_0(1648990197), Class16.smethod_0(1648989198), Class16.smethod_0(1648934925));
		}
		else if (radioButton_7.Checked)
		{
			settingsClass_0.SaveSetting(Class16.smethod_0(1648990197), Class16.smethod_0(1648989198), Class16.smethod_0(1648934967));
		}
		else if (radioButton_1.Checked)
		{
			settingsClass_0.SaveSetting(Class16.smethod_0(1648990197), Class16.smethod_0(1648989198), Class16.smethod_0(1648911557));
		}
		else if (radioButton_2.Checked)
		{
			settingsClass_0.SaveSetting(Class16.smethod_0(1648990197), Class16.smethod_0(1648989198), Class16.smethod_0(1648935001));
		}
		else if (radioButton_3.Checked)
		{
			settingsClass_0.SaveSetting(Class16.smethod_0(1648990197), Class16.smethod_0(1648989198), Class16.smethod_0(1648911820));
		}
		else if (radioButton_4.Checked)
		{
			settingsClass_0.SaveSetting(Class16.smethod_0(1648990197), Class16.smethod_0(1648989198), Class16.smethod_0(1648910861));
		}
		else if (radioButton_5.Checked)
		{
			settingsClass_0.SaveSetting(Class16.smethod_0(1648990197), Class16.smethod_0(1648989198), Class16.smethod_0(1648911788));
		}
		Close();
	}

	private void textBox_2_Enter(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_2(radioButton_6);
		}
	}

	private void comboBox_0_Enter(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_2(radioButton_7);
		}
	}

	private void numericUpDown_4_Enter(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_2(radioButton_7);
		}
	}

	private void textBox_0_Enter(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_2(radioButton_0);
		}
	}

	private void textBox_1_Enter(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_2(radioButton_0);
		}
	}

	private void ChangeValuesWindow_Shown(object sender, EventArgs e)
	{
		string setting = settingsClass_0.GetSetting(Class16.smethod_0(1648990197), Class16.smethod_0(1648989198), string.Empty);
		if (ACE.RSGlobal.RSGlobal.IsUIntFast(setting))
		{
			radioButton_6.Checked = false;
			switch (Convert.ToInt32(setting))
			{
			default:
				method_2(radioButton_6);
				textBox_2.Focus();
				textBox_2.SelectionStart = textBox_2.TextLength;
				break;
			case 1:
				method_2(radioButton_0);
				textBox_0.Focus();
				break;
			case 2:
				method_2(radioButton_7);
				comboBox_0.Focus();
				break;
			case 3:
				method_2(radioButton_1);
				numericUpDown_0.Focus();
				break;
			case 4:
				method_2(radioButton_2);
				numericUpDown_3.Focus();
				break;
			case 5:
				method_2(radioButton_3);
				break;
			case 6:
				method_2(radioButton_4);
				break;
			case 7:
				method_2(radioButton_5);
				break;
			}
		}
		else
		{
			method_2(radioButton_6);
			textBox_2.Focus();
			textBox_2.SelectionStart = textBox_2.TextLength;
		}
		bool_0 = true;
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			TextStorage.TEXTS.ShowMessage(913, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
			GC.KeepAlive(this);
		}
	}

	private void method_0()
	{
		((IDisposable)components)?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		new ComponentResourceManager(typeof(ChangeValuesWindow));
		button_0 = new Button();
		button_1 = new Button();
		textBox_2 = new TextBox();
		radioButton_6 = new RadioButton();
		radioButton_7 = new RadioButton();
		comboBox_0 = new ComboBox();
		numericUpDown_4 = new NumericUpDown();
		textBox_0 = new TextBox();
		radioButton_0 = new RadioButton();
		label_0 = new Label();
		label_1 = new Label();
		textBox_1 = new TextBox();
		numericUpDown_0 = new NumericUpDown();
		radioButton_1 = new RadioButton();
		label_2 = new Label();
		label_3 = new Label();
		numericUpDown_1 = new NumericUpDown();
		label_4 = new Label();
		numericUpDown_2 = new NumericUpDown();
		label_5 = new Label();
		numericUpDown_3 = new NumericUpDown();
		radioButton_2 = new RadioButton();
		groupBox_0 = new GroupBox();
		linkLabel_0 = new LinkLabel();
		groupBox_1 = new GroupBox();
		groupBox_2 = new GroupBox();
		label_6 = new Label();
		groupBox_3 = new GroupBox();
		groupBox_4 = new GroupBox();
		label_7 = new Label();
		radioButton_3 = new RadioButton();
		radioButton_4 = new RadioButton();
		radioButton_5 = new RadioButton();
		((ISupportInitialize)numericUpDown_4).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		((ISupportInitialize)numericUpDown_3).BeginInit();
		groupBox_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		groupBox_2.SuspendLayout();
		groupBox_3.SuspendLayout();
		groupBox_4.SuspendLayout();
		SuspendLayout();
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.ChangeValuesWindow_cmdcancel;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(328, 430);
		button_0.Name = Class16.smethod_0(1648925752);
		button_0.Size = new Size(308, 38);
		button_0.TabIndex = 33;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648989215);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.OK;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.ChangeValuesWindow_cmdok;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(3, 430);
		button_1.Name = Class16.smethod_0(1648925748);
		button_1.Size = new Size(318, 38);
		button_1.TabIndex = 0;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648989226);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_2.AcceptsReturn = true;
		textBox_2.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_2.Location = new Point(6, 21);
		textBox_2.Multiline = true;
		textBox_2.Name = Class16.smethod_0(1648989255);
		textBox_2.ScrollBars = ScrollBars.Both;
		textBox_2.Size = new Size(616, 74);
		textBox_2.TabIndex = 1;
		textBox_2.TextChanged += textBox_1_TextChanged;
		textBox_2.Enter += textBox_2_Enter;
		radioButton_6.AutoCheck = false;
		radioButton_6.AutoSize = true;
		radioButton_6.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		radioButton_6.Location = new Point(6, -2);
		radioButton_6.Name = Class16.smethod_0(1648989270);
		radioButton_6.Size = new Size(77, 19);
		radioButton_6.TabIndex = 2;
		radioButton_6.Text = Class16.smethod_0(1648989275);
		radioButton_6.UseVisualStyleBackColor = true;
		radioButton_6.Click += radioButton_5_Click;
		radioButton_7.AutoCheck = false;
		radioButton_7.AutoSize = true;
		radioButton_7.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		radioButton_7.Location = new Point(6, -2);
		radioButton_7.Name = Class16.smethod_0(1648989291);
		radioButton_7.Size = new Size(127, 19);
		radioButton_7.TabIndex = 1;
		radioButton_7.Text = Class16.smethod_0(1648989312);
		radioButton_7.UseVisualStyleBackColor = true;
		radioButton_7.Click += radioButton_5_Click;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[4]
		{
			Class16.smethod_0(1648989337),
			Class16.smethod_0(1648989361),
			Class16.smethod_0(1648989392),
			Class16.smethod_0(1648989428)
		});
		comboBox_0.Location = new Point(77, 19);
		comboBox_0.Name = Class16.smethod_0(1648928687);
		comboBox_0.Size = new Size(219, 21);
		comboBox_0.TabIndex = 36;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		comboBox_0.Enter += comboBox_0_Enter;
		numericUpDown_4.DecimalPlaces = 7;
		numericUpDown_4.Location = new Point(9, 50);
		numericUpDown_4.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_4.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_4.Minimum = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_4.Name = Class16.smethod_0(1648989455);
		numericUpDown_4.Size = new Size(287, 22);
		numericUpDown_4.TabIndex = 37;
		numericUpDown_4.TextAlign = HorizontalAlignment.Center;
		numericUpDown_4.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_4.ValueChanged += numericUpDown_3_ValueChanged;
		numericUpDown_4.Enter += numericUpDown_4_Enter;
		textBox_0.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_0.Location = new Point(100, 24);
		textBox_0.Name = Class16.smethod_0(1648919457);
		textBox_0.Size = new Size(205, 20);
		textBox_0.TabIndex = 39;
		textBox_0.TextChanged += textBox_1_TextChanged;
		textBox_0.Enter += textBox_0_Enter;
		radioButton_0.AutoCheck = false;
		radioButton_0.AutoSize = true;
		radioButton_0.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		radioButton_0.Location = new Point(6, -1);
		radioButton_0.Name = Class16.smethod_0(1648989468);
		radioButton_0.Size = new Size(248, 19);
		radioButton_0.TabIndex = 38;
		radioButton_0.Text = Class16.smethod_0(1648989485);
		radioButton_0.UseVisualStyleBackColor = true;
		radioButton_0.Click += radioButton_5_Click;
		label_0.AutoSize = true;
		label_0.Location = new Point(11, 26);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(33, 13);
		label_0.TabIndex = 40;
		label_0.Text = Class16.smethod_0(1648916538);
		label_1.AutoSize = true;
		label_1.Location = new Point(11, 52);
		label_1.Name = Class16.smethod_0(1648912083);
		label_1.Size = new Size(76, 13);
		label_1.TabIndex = 42;
		label_1.Text = Class16.smethod_0(1648989523);
		textBox_1.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_1.Location = new Point(100, 50);
		textBox_1.Name = Class16.smethod_0(1648996045);
		textBox_1.Size = new Size(205, 20);
		textBox_1.TabIndex = 41;
		textBox_1.TextChanged += textBox_1_TextChanged;
		textBox_1.Enter += textBox_1_Enter;
		numericUpDown_0.DecimalPlaces = 7;
		numericUpDown_0.Location = new Point(146, 23);
		numericUpDown_0.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_0.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_0.Minimum = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_0.Name = Class16.smethod_0(1648989551);
		numericUpDown_0.Size = new Size(157, 22);
		numericUpDown_0.TabIndex = 44;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_0.ValueChanged += numericUpDown_3_ValueChanged;
		numericUpDown_0.Enter += numericUpDown_0_Enter;
		radioButton_1.AutoCheck = false;
		radioButton_1.AutoSize = true;
		radioButton_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		radioButton_1.Location = new Point(6, -2);
		radioButton_1.Name = Class16.smethod_0(1648989574);
		radioButton_1.Size = new Size(112, 19);
		radioButton_1.TabIndex = 43;
		radioButton_1.Text = Class16.smethod_0(1648989589);
		radioButton_1.UseVisualStyleBackColor = true;
		radioButton_1.Click += radioButton_5_Click;
		label_2.AutoSize = true;
		label_2.Location = new Point(9, 25);
		label_2.Name = Class16.smethod_0(1648912145);
		label_2.Size = new Size(69, 13);
		label_2.TabIndex = 45;
		label_2.Text = Class16.smethod_0(1648989603);
		label_3.AutoSize = true;
		label_3.Location = new Point(9, 51);
		label_3.Name = Class16.smethod_0(1648912262);
		label_3.Size = new Size(89, 13);
		label_3.TabIndex = 49;
		label_3.Text = Class16.smethod_0(1648989624);
		numericUpDown_1.DecimalPlaces = 7;
		numericUpDown_1.Location = new Point(146, 49);
		numericUpDown_1.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_1.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_1.Minimum = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_1.Name = Class16.smethod_0(1648989654);
		numericUpDown_1.Size = new Size(157, 22);
		numericUpDown_1.TabIndex = 48;
		numericUpDown_1.TextAlign = HorizontalAlignment.Center;
		numericUpDown_1.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_1.ValueChanged += numericUpDown_3_ValueChanged;
		numericUpDown_1.Enter += numericUpDown_1_Enter;
		label_4.AutoSize = true;
		label_4.Location = new Point(6, 51);
		label_4.Name = Class16.smethod_0(1648930240);
		label_4.Size = new Size(89, 13);
		label_4.TabIndex = 54;
		label_4.Text = Class16.smethod_0(1648989671);
		numericUpDown_2.DecimalPlaces = 3;
		numericUpDown_2.Location = new Point(165, 49);
		numericUpDown_2.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_2.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_2.Minimum = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_2.Name = Class16.smethod_0(1648989692);
		numericUpDown_2.Size = new Size(135, 22);
		numericUpDown_2.TabIndex = 53;
		numericUpDown_2.TextAlign = HorizontalAlignment.Center;
		numericUpDown_2.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_2.ValueChanged += numericUpDown_3_ValueChanged;
		numericUpDown_2.Enter += numericUpDown_2_Enter;
		label_5.AutoSize = true;
		label_5.Location = new Point(6, 25);
		label_5.Name = Class16.smethod_0(1648930206);
		label_5.Size = new Size(88, 13);
		label_5.TabIndex = 52;
		label_5.Text = Class16.smethod_0(1648988687);
		numericUpDown_3.DecimalPlaces = 3;
		numericUpDown_3.Location = new Point(165, 23);
		numericUpDown_3.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_3.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_3.Minimum = new decimal(new int[4] { 2000000000, 0, 0, -2147483648 });
		numericUpDown_3.Name = Class16.smethod_0(1648988708);
		numericUpDown_3.Size = new Size(135, 22);
		numericUpDown_3.TabIndex = 51;
		numericUpDown_3.TextAlign = HorizontalAlignment.Center;
		numericUpDown_3.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_3.ValueChanged += numericUpDown_3_ValueChanged;
		numericUpDown_3.Enter += numericUpDown_3_Enter;
		radioButton_2.AutoCheck = false;
		radioButton_2.AutoSize = true;
		radioButton_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		radioButton_2.Location = new Point(6, -2);
		radioButton_2.Name = Class16.smethod_0(1648988727);
		radioButton_2.Size = new Size(185, 19);
		radioButton_2.TabIndex = 50;
		radioButton_2.Text = Class16.smethod_0(1648988743);
		radioButton_2.UseVisualStyleBackColor = true;
		radioButton_2.Click += radioButton_5_Click;
		groupBox_0.Controls.Add(linkLabel_0);
		groupBox_0.Controls.Add(radioButton_6);
		groupBox_0.Controls.Add(textBox_2);
		groupBox_0.Location = new Point(5, 7);
		groupBox_0.Name = Class16.smethod_0(1648929126);
		groupBox_0.Size = new Size(629, 116);
		groupBox_0.TabIndex = 55;
		groupBox_0.TabStop = false;
		linkLabel_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		linkLabel_0.Location = new Point(4, 96);
		linkLabel_0.Name = Class16.smethod_0(1648988768);
		linkLabel_0.Size = new Size(617, 16);
		linkLabel_0.TabIndex = 4;
		linkLabel_0.TabStop = true;
		linkLabel_0.Text = Class16.smethod_0(1648988794);
		linkLabel_0.TextAlign = ContentAlignment.MiddleCenter;
		linkLabel_0.LinkClicked += linkLabel_0_LinkClicked;
		groupBox_1.Controls.Add(radioButton_0);
		groupBox_1.Controls.Add(textBox_0);
		groupBox_1.Controls.Add(label_0);
		groupBox_1.Controls.Add(textBox_1);
		groupBox_1.Controls.Add(label_1);
		groupBox_1.Location = new Point(5, 129);
		groupBox_1.Name = Class16.smethod_0(1648988867);
		groupBox_1.Size = new Size(318, 83);
		groupBox_1.TabIndex = 3;
		groupBox_1.TabStop = false;
		groupBox_2.Controls.Add(label_6);
		groupBox_2.Controls.Add(radioButton_7);
		groupBox_2.Controls.Add(comboBox_0);
		groupBox_2.Controls.Add(numericUpDown_4);
		groupBox_2.Location = new Point(329, 129);
		groupBox_2.Name = Class16.smethod_0(1648928966);
		groupBox_2.Size = new Size(305, 81);
		groupBox_2.TabIndex = 3;
		groupBox_2.TabStop = false;
		label_6.AutoSize = true;
		label_6.Location = new Point(6, 21);
		label_6.Name = Class16.smethod_0(1648925008);
		label_6.Size = new Size(43, 13);
		label_6.TabIndex = 53;
		label_6.Text = Class16.smethod_0(1648988892);
		groupBox_3.Controls.Add(radioButton_1);
		groupBox_3.Controls.Add(numericUpDown_0);
		groupBox_3.Controls.Add(label_2);
		groupBox_3.Controls.Add(numericUpDown_1);
		groupBox_3.Controls.Add(label_3);
		groupBox_3.Location = new Point(5, 218);
		groupBox_3.Name = Class16.smethod_0(1648928911);
		groupBox_3.Size = new Size(316, 81);
		groupBox_3.TabIndex = 56;
		groupBox_3.TabStop = false;
		groupBox_4.Controls.Add(radioButton_2);
		groupBox_4.Controls.Add(numericUpDown_3);
		groupBox_4.Controls.Add(label_5);
		groupBox_4.Controls.Add(numericUpDown_2);
		groupBox_4.Controls.Add(label_4);
		groupBox_4.Location = new Point(327, 218);
		groupBox_4.Name = Class16.smethod_0(1648988898);
		groupBox_4.Size = new Size(307, 81);
		groupBox_4.TabIndex = 4;
		groupBox_4.TabStop = false;
		label_7.BackColor = Color.White;
		label_7.BorderStyle = BorderStyle.Fixed3D;
		label_7.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_7.Location = new Point(5, 361);
		label_7.Name = Class16.smethod_0(1648992688);
		label_7.Size = new Size(629, 63);
		label_7.TabIndex = 57;
		label_7.Text = Class16.smethod_0(1648988914);
		label_7.Click += label_7_Click;
		label_7.MouseClick += label_7_MouseClick;
		radioButton_3.AutoCheck = false;
		radioButton_3.AutoSize = true;
		radioButton_3.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_3.Location = new Point(5, 305);
		radioButton_3.Name = Class16.smethod_0(1648988931);
		radioButton_3.Size = new Size(203, 19);
		radioButton_3.TabIndex = 58;
		radioButton_3.Text = Class16.smethod_0(1648988954);
		radioButton_3.UseVisualStyleBackColor = true;
		radioButton_3.Click += radioButton_5_Click;
		radioButton_4.AutoCheck = false;
		radioButton_4.AutoSize = true;
		radioButton_4.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_4.Location = new Point(327, 305);
		radioButton_4.Name = Class16.smethod_0(1648988995);
		radioButton_4.Size = new Size(210, 19);
		radioButton_4.TabIndex = 59;
		radioButton_4.Text = Class16.smethod_0(1648989019);
		radioButton_4.UseVisualStyleBackColor = true;
		radioButton_4.Click += radioButton_5_Click;
		radioButton_5.AutoCheck = false;
		radioButton_5.AutoSize = true;
		radioButton_5.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_5.Location = new Point(5, 330);
		radioButton_5.Name = Class16.smethod_0(1648989069);
		radioButton_5.Size = new Size(222, 19);
		radioButton_5.TabIndex = 60;
		radioButton_5.Text = Class16.smethod_0(1648989095);
		radioButton_5.UseVisualStyleBackColor = true;
		radioButton_5.Click += radioButton_5_Click;
		base.AcceptButton = button_1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_0;
		base.ClientSize = new Size(640, 470);
		base.Controls.Add(radioButton_5);
		base.Controls.Add(radioButton_4);
		base.Controls.Add(radioButton_3);
		base.Controls.Add(label_7);
		base.Controls.Add(groupBox_4);
		base.Controls.Add(groupBox_3);
		base.Controls.Add(groupBox_2);
		base.Controls.Add(groupBox_1);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(button_0);
		base.Controls.Add(button_1);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.ChangeValuesWindow_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648990197);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648989131);
		base.Load += ChangeValuesWindow_Load;
		base.Shown += ChangeValuesWindow_Shown;
		((ISupportInitialize)numericUpDown_4).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		((ISupportInitialize)numericUpDown_2).EndInit();
		((ISupportInitialize)numericUpDown_3).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		groupBox_2.ResumeLayout(performLayout: false);
		groupBox_2.PerformLayout();
		groupBox_3.ResumeLayout(performLayout: false);
		groupBox_3.PerformLayout();
		groupBox_4.ResumeLayout(performLayout: false);
		groupBox_4.PerformLayout();
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

	private void radioButton_5_Click(object sender, EventArgs e)
	{
		method_2((RadioButton)sender);
	}

	private void method_2(RadioButton radioButton_8)
	{
		radioButton_8.Checked = true;
		RadioButton radioButton = radioButton_6;
		if (radioButton_8 != radioButton)
		{
			radioButton.Checked = false;
		}
		RadioButton radioButton2 = radioButton_0;
		if (radioButton_8 != radioButton2)
		{
			radioButton2.Checked = false;
		}
		RadioButton radioButton3 = radioButton_7;
		if (radioButton_8 != radioButton3)
		{
			radioButton3.Checked = false;
		}
		RadioButton radioButton4 = radioButton_1;
		if (radioButton_8 != radioButton4)
		{
			radioButton4.Checked = false;
		}
		RadioButton radioButton5 = radioButton_2;
		if (radioButton_8 != radioButton5)
		{
			radioButton5.Checked = false;
		}
		RadioButton radioButton6 = radioButton_3;
		if (radioButton_8 != radioButton6)
		{
			radioButton6.Checked = false;
		}
		RadioButton radioButton7 = radioButton_4;
		if (radioButton_8 != radioButton7)
		{
			radioButton7.Checked = false;
		}
		RadioButton radioButton8 = radioButton_5;
		if (radioButton_8 != radioButton8)
		{
			radioButton8.Checked = false;
		}
		method_4();
	}

	private void method_3()
	{
		string[] array = (string_0 = new string[(nint)CommonStorage.sarr1.LongLength]);
		CommonStorage.sarr1.CopyTo(array, 0);
		if (radioButton_6.Checked)
		{
			int num = 0;
			if (0 < (nint)string_0.LongLength)
			{
				do
				{
					string text = textBox_2.Text;
					if (text.Contains(Class16.smethod_0(1648989165)))
					{
						text = text.Replace(Class16.smethod_0(1648989165), string_0[num]);
					}
					if (bool_1 && !ACE.RSGlobal.RSGlobal.IsNumber(text))
					{
						text = string_0[num];
					}
					if (bool_2 && !ACE.RSGlobal.RSGlobal.IsUIntFast(text))
					{
						text = string_0[num];
					}
					string_0[num] = text;
					num++;
				}
				while (num < (nint)string_0.LongLength);
			}
		}
		else if (radioButton_0.Checked)
		{
			string text2 = textBox_0.Text;
			string replacement = textBox_1.Text;
			if (text2 == null || text2 == string.Empty)
			{
				GC.KeepAlive(this);
				return;
			}
			int num2 = 0;
			if (0 < (nint)string_0.LongLength)
			{
				do
				{
					string_0[num2] = ACE.RSGlobal.RSGlobal.ReplaceIgnoreCase(string_0[num2], text2, replacement);
					num2++;
				}
				while (num2 < (nint)string_0.LongLength);
			}
		}
		else if (radioButton_7.Checked)
		{
			decimal num3 = default(decimal);
			int num4 = 0;
			if (0 < (nint)string_0.LongLength)
			{
				do
				{
					if (ACE.RSGlobal.RSGlobal.IsNumber(string_0[num4]))
					{
						num3 = Convert.ToDecimal(CommonStorage.sarr1[num4]);
						decimal num5 = Convert.ToDecimal(num3);
						decimal value = numericUpDown_4.Value;
						if (comboBox_0.SelectedIndex == 0)
						{
							num3 = num5 + value;
						}
						else if (comboBox_0.SelectedIndex == 1)
						{
							num3 = num5 - value;
						}
						else if (comboBox_0.SelectedIndex == 2)
						{
							num3 = num5 * value;
						}
						else if (comboBox_0.SelectedIndex == 3 && value != default(decimal))
						{
							num3 = num5 / value;
						}
						if (bool_2 || (!string_0[num4].Contains(Class16.smethod_0(1648928036)) && !bool_1))
						{
							num3 = Math.Round(num3);
						}
						string text3 = decimal.Round(num3, 7).ToString(Class16.smethod_0(1648989181));
						string_0[num4] = text3;
					}
					num4++;
				}
				while (num4 < (nint)string_0.LongLength);
			}
		}
		else if (radioButton_1.Checked)
		{
			decimal value2 = numericUpDown_0.Value;
			decimal value3 = numericUpDown_1.Value;
			int num6 = 0;
			if (0 < (nint)string_0.LongLength)
			{
				do
				{
					decimal num7 = (decimal)num6 * value3;
					decimal d = value2 + num7;
					if (bool_2)
					{
						d = Math.Round(d);
					}
					string text4 = decimal.Round(d, 7).ToString(Class16.smethod_0(1648989181));
					string_0[num6] = text4;
					num6++;
				}
				while (num6 < (nint)string_0.LongLength);
			}
		}
		else if (radioButton_2.Checked)
		{
			double num8 = Convert.ToDouble(numericUpDown_3.Value);
			double num9 = Convert.ToDouble(numericUpDown_2.Value);
			if (num8 > num9)
			{
				num8 = num9;
			}
			int num10 = 0;
			if (0 < (nint)string_0.LongLength)
			{
				do
				{
					if (string_0[num10].Contains(Class16.smethod_0(1648928036)))
					{
						double num11 = RND.GenerateRnd(num8, num9);
						string_0[num10] = num11.ToString();
					}
					else
					{
						int num12 = RND.GenerateRnd((int)num8, (int)num9);
						string_0[num10] = num12.ToString();
					}
					num10++;
				}
				while (num10 < (nint)string_0.LongLength);
			}
		}
		else if (!radioButton_3.Checked && !radioButton_4.Checked)
		{
			if (radioButton_5.Checked)
			{
				int num13 = string_0.Length;
				ACE.RSGlobal.RSGlobal.KeepOnlyUniqueValues(ref string_0);
				List<string> list = new List<string>(string_0);
				string item = ((bool_1 || bool_2) ? Class16.smethod_0(1648924112) : string.Empty);
				int num14 = string_0.Length;
				if (num14 < num13)
				{
					int num15 = num13 - num14;
					do
					{
						list.Add(item);
						num15--;
					}
					while (num15 != 0);
				}
				string_0 = list.ToArray();
			}
		}
		else
		{
			Array.Sort(string_0, ACE.RSGlobal.RSGlobal.StrCmpLogicalW);
			if (radioButton_4.Checked)
			{
				Array.Reverse(string_0);
			}
		}
		GC.KeepAlive(this);
	}

	private void numericUpDown_0_Enter(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_2(radioButton_1);
		}
	}

	private void numericUpDown_1_Enter(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_2(radioButton_1);
		}
	}

	private void numericUpDown_3_Enter(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_2(radioButton_2);
		}
	}

	private void numericUpDown_2_Enter(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_2(radioButton_2);
		}
	}

	private void numericUpDown_3_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_4();
		}
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_4();
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_4();
		}
	}

	private void method_4()
	{
		if ((nint)CommonStorage.sarr1.LongLength < 10000)
		{
			method_3();
			object[] vars = new object[1] { string.Join(Class16.smethod_0(1648993435), string_0) };
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648988167), vars);
			label_7.Text = text;
		}
		else
		{
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648988190));
			label_7.Text = text2;
		}
		GC.KeepAlive(this);
	}

	private void linkLabel_0_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		int selectionStart = textBox_2.SelectionStart;
		string text = textBox_2.Text;
		string value = Class16.smethod_0(1648989165);
		textBox_2.Text = text.Insert(textBox_2.SelectionStart, value);
		textBox_2.SelectionStart = selectionStart + 9;
		textBox_2.Focus();
		GC.KeepAlive(this);
	}

	private void label_7_Click(object sender, EventArgs e)
	{
	}

	private void label_7_MouseClick(object sender, MouseEventArgs e)
	{
		string[] array = string_0;
		if (array != null)
		{
			ACE.RSGlobal.RSGlobal.CtrlC(string.Join(Class16.smethod_0(1648942920), array));
		}
		GC.KeepAlive(this);
	}
}
