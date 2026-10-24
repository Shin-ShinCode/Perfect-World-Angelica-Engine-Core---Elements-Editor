using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class ReplaceWindow : Form
{
	private int int_0;

	private CommonStorage commonStorage_0;

	private int[] int_1;

	private int[] int_2;

	protected ACE.Elements.eListCollection.eListCollection eLC;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private TextBox textBox_0;

	private Label label_3;

	private GroupBox groupBox_0;

	private GroupBox groupBox_1;

	private GroupBox groupBox_2;

	private NumericUpDown numericUpDown_0;

	private ComboBox comboBox_0;

	private Label label_4;

	private Label label_5;

	private Label label_6;

	private Button button_0;

	private GroupBox groupBox_3;

	private Label label_7;

	private Label label_8;

	private TextBox textBox_1;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private NumericUpDown numericUpDown_1;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private CheckBox checkBox_4;

	private NumericUpDown numericUpDown_2;

	private NumericUpDown numericUpDown_3;

	private NumericUpDown numericUpDown_4;

	private NumericUpDown numericUpDown_5;

	private NumericUpDown numericUpDown_6;

	private NumericUpDown numericUpDown_7;

	private NumericUpDown numericUpDown_8;

	private Label label_9;

	private TextBox textBox_2;

	private NumericUpDown numericUpDown_9;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private RadioButton radioButton_2;

	private RadioButton radioButton_3;

	private CheckBox checkBox_5;

	private CheckBox checkBox_6;

	private ToolTip toolTip_0;

	private IContainer icontainer_0;

	public ReplaceWindow(ACE.Elements.eListCollection.eListCollection ListCollection, int _listnumber, CommonStorage ref_CStorage)
	{
		try
		{
			method_2();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			eLC = ListCollection;
			commonStorage_0 = ref_CStorage;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			CommonStorage.bData = true;
			comboBox_0.SelectedIndex = 0;
			int_0 = _listnumber;
			if (_listnumber >= 0)
			{
				decimal value = _listnumber;
				numericUpDown_1.Value = value;
			}
			checkBox_6.Checked = true;
			checkBox_5.Checked = true;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_0(int int_3, int int_4, int int_5, int int_6)
	{
		bool flag = checkBox_1.Checked;
		bool flag2 = checkBox_0.Checked;
		_ = checkBox_3.Checked;
		bool flag3 = checkBox_2.Checked;
		int num = (int)numericUpDown_9.Value;
		bool flag4 = radioButton_0.Checked;
		int fieldIndex = Convert.ToInt32(numericUpDown_8.Text);
		bool flag5 = checkBox_3.Checked;
		string text = textBox_0.Text;
		string text2 = eLC.GetValue(int_3, int_4, int_5);
		string text3 = text2;
		if (!flag2)
		{
			text = text.ToLowerInvariant();
			text2 = text2.ToLowerInvariant();
		}
		string text4 = (flag4 ? eLC.GetValue(int_3, int_4, fieldIndex) : textBox_2.Text);
		if (!(text == Class16.smethod_0(1648941528)))
		{
			if (flag)
			{
				if (!(text == text2))
				{
					goto IL_00eb;
				}
			}
			else if (!text2.Contains(text))
			{
				goto IL_00eb;
			}
		}
		if (flag3)
		{
			text4 = ((!ACE.RSGlobal.RSGlobal.IsNumber(text4)) ? string.Concat(text4, Class16.smethod_0(1648942211) + num * int_6) : Convert.ToString(Convert.ToInt32(text4) + num * int_6));
		}
		if (flag5 && text != Class16.smethod_0(1648941528))
		{
			string value = text3.Replace(text, text4);
			eLC.SetValue(int_3, int_4, int_5, value, AutoSaveStage: true);
		}
		else
		{
			eLC.SetValue(int_3, int_4, int_5, text4, AutoSaveStage: true);
		}
		GC.KeepAlive(this);
		return true;
		IL_00eb:
		return false;
	}

	private void method_1()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(ReplaceWindow));
		label_0 = new Label();
		label_1 = new Label();
		label_2 = new Label();
		textBox_0 = new TextBox();
		label_3 = new Label();
		groupBox_0 = new GroupBox();
		checkBox_5 = new CheckBox();
		checkBox_6 = new CheckBox();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		groupBox_3 = new GroupBox();
		checkBox_4 = new CheckBox();
		numericUpDown_2 = new NumericUpDown();
		label_7 = new Label();
		label_8 = new Label();
		textBox_1 = new TextBox();
		numericUpDown_3 = new NumericUpDown();
		numericUpDown_4 = new NumericUpDown();
		numericUpDown_5 = new NumericUpDown();
		numericUpDown_6 = new NumericUpDown();
		numericUpDown_7 = new NumericUpDown();
		numericUpDown_1 = new NumericUpDown();
		label_5 = new Label();
		label_6 = new Label();
		label_4 = new Label();
		groupBox_1 = new GroupBox();
		numericUpDown_8 = new NumericUpDown();
		radioButton_0 = new RadioButton();
		radioButton_1 = new RadioButton();
		numericUpDown_9 = new NumericUpDown();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		checkBox_3 = new CheckBox();
		label_9 = new Label();
		textBox_2 = new TextBox();
		radioButton_2 = new RadioButton();
		groupBox_2 = new GroupBox();
		numericUpDown_0 = new NumericUpDown();
		comboBox_0 = new ComboBox();
		radioButton_3 = new RadioButton();
		button_0 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		groupBox_0.SuspendLayout();
		groupBox_3.SuspendLayout();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		((ISupportInitialize)numericUpDown_3).BeginInit();
		((ISupportInitialize)numericUpDown_4).BeginInit();
		((ISupportInitialize)numericUpDown_5).BeginInit();
		((ISupportInitialize)numericUpDown_6).BeginInit();
		((ISupportInitialize)numericUpDown_7).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		groupBox_1.SuspendLayout();
		((ISupportInitialize)numericUpDown_8).BeginInit();
		((ISupportInitialize)numericUpDown_9).BeginInit();
		groupBox_2.SuspendLayout();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Location = new Point(7, 27);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(106, 13);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1648965286);
		label_1.AutoSize = true;
		label_1.Location = new Point(7, 59);
		label_1.Name = Class16.smethod_0(1648912083);
		label_1.Size = new Size(113, 13);
		label_1.TabIndex = 2;
		label_1.Text = Class16.smethod_0(1648965306);
		label_2.AutoSize = true;
		label_2.Location = new Point(7, 91);
		label_2.Name = Class16.smethod_0(1648912145);
		label_2.Size = new Size(114, 13);
		label_2.TabIndex = 4;
		label_2.Text = Class16.smethod_0(1648965342);
		textBox_0.Location = new Point(126, 23);
		textBox_0.Margin = new Padding(3, 4, 3, 4);
		textBox_0.Name = Class16.smethod_0(1648965363);
		textBox_0.Size = new Size(293, 22);
		textBox_0.TabIndex = 8;
		textBox_0.Text = Class16.smethod_0(1648941528);
		label_3.AutoSize = true;
		label_3.Location = new Point(7, 27);
		label_3.Name = Class16.smethod_0(1648912200);
		label_3.Size = new Size(81, 13);
		label_3.TabIndex = 6;
		label_3.Text = Class16.smethod_0(1648965386);
		groupBox_0.Controls.Add(checkBox_5);
		groupBox_0.Controls.Add(checkBox_6);
		groupBox_0.Controls.Add(button_1);
		groupBox_0.Controls.Add(button_2);
		groupBox_0.Controls.Add(button_3);
		groupBox_0.Controls.Add(groupBox_3);
		groupBox_0.Controls.Add(numericUpDown_3);
		groupBox_0.Controls.Add(numericUpDown_4);
		groupBox_0.Controls.Add(numericUpDown_5);
		groupBox_0.Controls.Add(numericUpDown_6);
		groupBox_0.Controls.Add(numericUpDown_7);
		groupBox_0.Controls.Add(numericUpDown_1);
		groupBox_0.Controls.Add(label_5);
		groupBox_0.Controls.Add(label_6);
		groupBox_0.Controls.Add(label_4);
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Controls.Add(label_2);
		groupBox_0.Location = new Point(14, 15);
		groupBox_0.Margin = new Padding(3, 4, 3, 4);
		groupBox_0.Name = Class16.smethod_0(1648929126);
		groupBox_0.Padding = new Padding(3, 4, 3, 4);
		groupBox_0.Size = new Size(681, 121);
		groupBox_0.TabIndex = 0;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1648965408);
		checkBox_5.AutoSize = true;
		checkBox_5.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_5.Location = new Point(361, 94);
		checkBox_5.Margin = new Padding(3, 4, 3, 4);
		checkBox_5.Name = Class16.smethod_0(1648965437);
		checkBox_5.Size = new Size(15, 14);
		checkBox_5.TabIndex = 45;
		toolTip_0.SetToolTip(checkBox_5, Class16.smethod_0(1648965461));
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_5.CheckedChanged += checkBox_5_CheckedChanged;
		checkBox_6.AutoSize = true;
		checkBox_6.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_6.Location = new Point(361, 46);
		checkBox_6.Margin = new Padding(3, 4, 3, 4);
		checkBox_6.Name = Class16.smethod_0(1648965490);
		checkBox_6.Size = new Size(15, 14);
		checkBox_6.TabIndex = 44;
		toolTip_0.SetToolTip(checkBox_6, Class16.smethod_0(1648965461));
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_6.CheckedChanged += checkBox_6_CheckedChanged;
		button_1.Font = new Font(Class16.smethod_0(1648929920), 6.25f);
		button_1.Location = new Point(310, 87);
		button_1.Margin = new Padding(3, 4, 3, 4);
		button_1.Name = Class16.smethod_0(1648965513);
		button_1.Size = new Size(45, 24);
		button_1.TabIndex = 24;
		button_1.Text = Class16.smethod_0(1648941205);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Font = new Font(Class16.smethod_0(1648929920), 6.25f);
		button_2.Location = new Point(310, 54);
		button_2.Margin = new Padding(3, 4, 3, 4);
		button_2.Name = Class16.smethod_0(1648965528);
		button_2.Size = new Size(45, 24);
		button_2.TabIndex = 23;
		button_2.Text = Class16.smethod_0(1648941205);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Font = new Font(Class16.smethod_0(1648929920), 6.25f);
		button_3.Location = new Point(310, 23);
		button_3.Margin = new Padding(3, 4, 3, 4);
		button_3.Name = Class16.smethod_0(1648965550);
		button_3.Size = new Size(45, 24);
		button_3.TabIndex = 22;
		button_3.Text = Class16.smethod_0(1648941205);
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		groupBox_3.Controls.Add(checkBox_4);
		groupBox_3.Controls.Add(numericUpDown_2);
		groupBox_3.Controls.Add(label_7);
		groupBox_3.Controls.Add(label_8);
		groupBox_3.Controls.Add(textBox_1);
		groupBox_3.Location = new Point(386, 13);
		groupBox_3.Margin = new Padding(3, 4, 3, 4);
		groupBox_3.Name = Class16.smethod_0(1648928911);
		groupBox_3.Padding = new Padding(3, 4, 3, 4);
		groupBox_3.Size = new Size(287, 100);
		groupBox_3.TabIndex = 21;
		groupBox_3.TabStop = false;
		checkBox_4.AutoSize = true;
		checkBox_4.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_4.Location = new Point(10, 0);
		checkBox_4.Margin = new Padding(3, 4, 3, 4);
		checkBox_4.Name = Class16.smethod_0(1648965564);
		checkBox_4.Size = new Size(52, 17);
		checkBox_4.TabIndex = 21;
		checkBox_4.Text = Class16.smethod_0(1648935595);
		checkBox_4.UseVisualStyleBackColor = true;
		numericUpDown_2.Location = new Point(143, 30);
		numericUpDown_2.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_2.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		numericUpDown_2.Name = Class16.smethod_0(1648965580);
		numericUpDown_2.Size = new Size(131, 22);
		numericUpDown_2.TabIndex = 6;
		numericUpDown_2.TextAlign = HorizontalAlignment.Center;
		label_7.AutoSize = true;
		label_7.Location = new Point(7, 66);
		label_7.Name = Class16.smethod_0(1648925100);
		label_7.Size = new Size(78, 13);
		label_7.TabIndex = 8;
		label_7.Text = Class16.smethod_0(1648965606);
		label_8.AutoSize = true;
		label_8.Location = new Point(7, 33);
		label_8.Name = Class16.smethod_0(1648925176);
		label_8.Size = new Size(116, 13);
		label_8.TabIndex = 6;
		label_8.Text = Class16.smethod_0(1648965628);
		textBox_1.Location = new Point(143, 64);
		textBox_1.Margin = new Padding(3, 4, 3, 4);
		textBox_1.Name = Class16.smethod_0(1648964624);
		textBox_1.Size = new Size(130, 22);
		textBox_1.TabIndex = 7;
		numericUpDown_3.Location = new Point(240, 89);
		numericUpDown_3.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_3.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		numericUpDown_3.Name = Class16.smethod_0(1648987710);
		numericUpDown_3.Size = new Size(63, 22);
		numericUpDown_3.TabIndex = 5;
		numericUpDown_3.TextAlign = HorizontalAlignment.Center;
		numericUpDown_4.Location = new Point(240, 57);
		numericUpDown_4.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_4.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		numericUpDown_4.Name = Class16.smethod_0(1648964643);
		numericUpDown_4.Size = new Size(63, 22);
		numericUpDown_4.TabIndex = 3;
		numericUpDown_4.TextAlign = HorizontalAlignment.Center;
		numericUpDown_5.Location = new Point(240, 25);
		numericUpDown_5.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_5.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		numericUpDown_5.Name = Class16.smethod_0(1648964663);
		numericUpDown_5.Size = new Size(63, 22);
		numericUpDown_5.TabIndex = 1;
		numericUpDown_5.TextAlign = HorizontalAlignment.Center;
		numericUpDown_6.Location = new Point(142, 89);
		numericUpDown_6.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_6.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		numericUpDown_6.Name = Class16.smethod_0(1648987689);
		numericUpDown_6.Size = new Size(63, 22);
		numericUpDown_6.TabIndex = 4;
		numericUpDown_6.TextAlign = HorizontalAlignment.Center;
		numericUpDown_6.ValueChanged += numericUpDown_6_ValueChanged;
		numericUpDown_7.Location = new Point(142, 57);
		numericUpDown_7.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_7.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		numericUpDown_7.Name = Class16.smethod_0(1648964667);
		numericUpDown_7.Size = new Size(63, 22);
		numericUpDown_7.TabIndex = 2;
		numericUpDown_7.TextAlign = HorizontalAlignment.Center;
		numericUpDown_7.ValueChanged += numericUpDown_7_ValueChanged;
		numericUpDown_1.Location = new Point(142, 25);
		numericUpDown_1.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_1.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		numericUpDown_1.Name = Class16.smethod_0(1648964687);
		numericUpDown_1.Size = new Size(63, 22);
		numericUpDown_1.TabIndex = 0;
		numericUpDown_1.TextAlign = HorizontalAlignment.Center;
		numericUpDown_1.ValueChanged += numericUpDown_1_ValueChanged;
		label_5.AutoSize = true;
		label_5.Location = new Point(212, 94);
		label_5.Name = Class16.smethod_0(1648925008);
		label_5.Size = new Size(35, 13);
		label_5.TabIndex = 11;
		label_5.Text = Class16.smethod_0(1648964691);
		label_6.AutoSize = true;
		label_6.Location = new Point(212, 62);
		label_6.Name = Class16.smethod_0(1648930206);
		label_6.Size = new Size(35, 13);
		label_6.TabIndex = 10;
		label_6.Text = Class16.smethod_0(1648964691);
		label_4.AutoSize = true;
		label_4.Location = new Point(212, 30);
		label_4.Name = Class16.smethod_0(1648930240);
		label_4.Size = new Size(35, 13);
		label_4.TabIndex = 9;
		label_4.Text = Class16.smethod_0(1648964691);
		groupBox_1.Controls.Add(numericUpDown_8);
		groupBox_1.Controls.Add(radioButton_0);
		groupBox_1.Controls.Add(radioButton_1);
		groupBox_1.Controls.Add(numericUpDown_9);
		groupBox_1.Controls.Add(checkBox_0);
		groupBox_1.Controls.Add(checkBox_1);
		groupBox_1.Controls.Add(checkBox_2);
		groupBox_1.Controls.Add(checkBox_3);
		groupBox_1.Controls.Add(textBox_0);
		groupBox_1.Controls.Add(label_3);
		groupBox_1.Controls.Add(label_9);
		groupBox_1.Controls.Add(textBox_2);
		groupBox_1.Location = new Point(14, 143);
		groupBox_1.Margin = new Padding(3, 4, 3, 4);
		groupBox_1.Name = Class16.smethod_0(1648929037);
		groupBox_1.Padding = new Padding(3, 4, 3, 4);
		groupBox_1.Size = new Size(681, 158);
		groupBox_1.TabIndex = 12;
		groupBox_1.TabStop = false;
		numericUpDown_8.Location = new Point(205, 85);
		numericUpDown_8.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_8.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		numericUpDown_8.Name = Class16.smethod_0(1648964704);
		numericUpDown_8.Size = new Size(63, 22);
		numericUpDown_8.TabIndex = 10;
		numericUpDown_8.TextAlign = HorizontalAlignment.Center;
		radioButton_0.AutoSize = true;
		radioButton_0.Location = new Point(9, 87);
		radioButton_0.Margin = new Padding(3, 4, 3, 4);
		radioButton_0.Name = Class16.smethod_0(1648964740);
		radioButton_0.Size = new Size(171, 17);
		radioButton_0.TabIndex = 43;
		radioButton_0.Text = Class16.smethod_0(1648964752);
		radioButton_0.UseVisualStyleBackColor = true;
		radioButton_1.AutoSize = true;
		radioButton_1.Checked = true;
		radioButton_1.Location = new Point(9, 55);
		radioButton_1.Margin = new Padding(3, 4, 3, 4);
		radioButton_1.Name = Class16.smethod_0(1648964796);
		radioButton_1.Size = new Size(164, 17);
		radioButton_1.TabIndex = 42;
		radioButton_1.TabStop = true;
		radioButton_1.Text = Class16.smethod_0(1648964809);
		radioButton_1.UseVisualStyleBackColor = true;
		numericUpDown_9.Location = new Point(279, 121);
		numericUpDown_9.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_9.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		numericUpDown_9.Minimum = new decimal(new int[4] { 9999, 0, 0, -2147483648 });
		numericUpDown_9.Name = Class16.smethod_0(1648964842);
		numericUpDown_9.Size = new Size(63, 22);
		numericUpDown_9.TabIndex = 11;
		numericUpDown_9.TextAlign = HorizontalAlignment.Center;
		checkBox_0.AutoSize = true;
		checkBox_0.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_0.Location = new Point(551, 23);
		checkBox_0.Margin = new Padding(3, 4, 3, 4);
		checkBox_0.Name = Class16.smethod_0(1648964864);
		checkBox_0.Size = new Size(82, 17);
		checkBox_0.TabIndex = 35;
		checkBox_0.Text = Class16.smethod_0(1648964883);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_1.AutoSize = true;
		checkBox_1.Checked = true;
		checkBox_1.CheckState = CheckState.Checked;
		checkBox_1.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_1.Location = new Point(433, 23);
		checkBox_1.Margin = new Padding(3, 4, 3, 4);
		checkBox_1.Name = Class16.smethod_0(1648964908);
		checkBox_1.Size = new Size(83, 17);
		checkBox_1.TabIndex = 34;
		checkBox_1.Text = Class16.smethod_0(1648996096);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_2.AutoSize = true;
		checkBox_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_2.Location = new Point(10, 123);
		checkBox_2.Margin = new Padding(3, 4, 3, 4);
		checkBox_2.Name = Class16.smethod_0(1648964927);
		checkBox_2.Size = new Size(98, 20);
		checkBox_2.TabIndex = 32;
		checkBox_2.Text = Class16.smethod_0(1648964950);
		checkBox_2.UseCompatibleTextRendering = true;
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_3.AutoSize = true;
		checkBox_3.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_3.Location = new Point(433, 60);
		checkBox_3.Margin = new Padding(3, 4, 3, 4);
		checkBox_3.Name = Class16.smethod_0(1648964963);
		checkBox_3.Size = new Size(124, 17);
		checkBox_3.TabIndex = 31;
		checkBox_3.Text = Class16.smethod_0(1648964991);
		checkBox_3.UseVisualStyleBackColor = true;
		label_9.AutoSize = true;
		label_9.Location = new Point(271, 89);
		label_9.Name = Class16.smethod_0(1648912262);
		label_9.Size = new Size(40, 13);
		label_9.TabIndex = 37;
		label_9.Text = Class16.smethod_0(1648965010);
		textBox_2.Location = new Point(200, 55);
		textBox_2.Margin = new Padding(3, 4, 3, 4);
		textBox_2.Name = Class16.smethod_0(1648965025);
		textBox_2.Size = new Size(219, 22);
		textBox_2.TabIndex = 9;
		radioButton_2.AutoSize = true;
		radioButton_2.Checked = true;
		radioButton_2.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		radioButton_2.Location = new Point(24, 140);
		radioButton_2.Margin = new Padding(3, 4, 3, 4);
		radioButton_2.Name = Class16.smethod_0(1648965048);
		radioButton_2.Size = new Size(73, 21);
		radioButton_2.TabIndex = 19;
		radioButton_2.TabStop = true;
		radioButton_2.Text = Class16.smethod_0(1648999325);
		radioButton_2.TextAlign = ContentAlignment.MiddleCenter;
		radioButton_2.UseVisualStyleBackColor = true;
		groupBox_2.Controls.Add(numericUpDown_0);
		groupBox_2.Controls.Add(comboBox_0);
		groupBox_2.Location = new Point(14, 305);
		groupBox_2.Margin = new Padding(3, 4, 3, 4);
		groupBox_2.Name = Class16.smethod_0(1648928966);
		groupBox_2.Padding = new Padding(3, 4, 3, 4);
		groupBox_2.Size = new Size(316, 59);
		groupBox_2.TabIndex = 15;
		groupBox_2.TabStop = false;
		numericUpDown_0.DecimalPlaces = 3;
		numericUpDown_0.Location = new Point(160, 23);
		numericUpDown_0.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_0.Maximum = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_0.Minimum = new decimal(new int[4] { 1000000, 0, 0, -2147483648 });
		numericUpDown_0.Name = Class16.smethod_0(1648965074);
		numericUpDown_0.Size = new Size(146, 22);
		numericUpDown_0.TabIndex = 1;
		numericUpDown_0.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[4]
		{
			Class16.smethod_0(1648941528),
			Class16.smethod_0(1648892117),
			Class16.smethod_0(1648941500),
			Class16.smethod_0(1648941518)
		});
		comboBox_0.Location = new Point(10, 23);
		comboBox_0.Margin = new Padding(3, 4, 3, 4);
		comboBox_0.Name = Class16.smethod_0(1648965110);
		comboBox_0.Size = new Size(142, 21);
		comboBox_0.TabIndex = 0;
		radioButton_3.AutoSize = true;
		radioButton_3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		radioButton_3.Location = new Point(27, 302);
		radioButton_3.Margin = new Padding(3, 4, 3, 4);
		radioButton_3.Name = Class16.smethod_0(1648964111);
		radioButton_3.Size = new Size(95, 21);
		radioButton_3.TabIndex = 14;
		radioButton_3.Text = Class16.smethod_0(1648964141);
		radioButton_3.UseVisualStyleBackColor = true;
		button_0.BackColor = Color.FromArgb(239, 244, 250);
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.button_replace;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(337, 309);
		button_0.Margin = new Padding(3, 4, 3, 4);
		button_0.Name = Class16.smethod_0(1648964159);
		button_0.Size = new Size(358, 55);
		button_0.TabIndex = 12;
		button_0.Text = Class16.smethod_0(1648999325);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = false;
		button_0.Click += button_0_Click;
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(709, 372);
		base.Controls.Add(radioButton_3);
		base.Controls.Add(radioButton_2);
		base.Controls.Add(button_0);
		base.Controls.Add(groupBox_2);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(groupBox_1);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.ReplaceWindow_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		MaximumSize = new Size(1165, 1223);
		base.MinimizeBox = false;
		MinimumSize = new Size(115, 115);
		base.Name = Class16.smethod_0(1648964180);
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648999325);
		base.Activated += ReplaceWindow_Activated;
		base.FormClosed += ReplaceWindow_FormClosed;
		base.Load += ReplaceWindow_Load;
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		groupBox_3.ResumeLayout(performLayout: false);
		groupBox_3.PerformLayout();
		((ISupportInitialize)numericUpDown_2).EndInit();
		((ISupportInitialize)numericUpDown_3).EndInit();
		((ISupportInitialize)numericUpDown_4).EndInit();
		((ISupportInitialize)numericUpDown_5).EndInit();
		((ISupportInitialize)numericUpDown_6).EndInit();
		((ISupportInitialize)numericUpDown_7).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		((ISupportInitialize)numericUpDown_8).EndInit();
		((ISupportInitialize)numericUpDown_9).EndInit();
		groupBox_2.ResumeLayout(performLayout: false);
		((ISupportInitialize)numericUpDown_0).EndInit();
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
				method_1();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.AppStarting;
		int num = 0;
		_ = textBox_0.Text;
		_ = textBox_2.Text;
		string text = comboBox_0.SelectedItem.ToString();
		decimal value = numericUpDown_0.Value;
		bool flag = checkBox_4.Checked;
		int fieldIndex = (int)numericUpDown_2.Value;
		string text2 = textBox_1.Text;
		int num2 = (int)numericUpDown_1.Value;
		int num3 = (int)numericUpDown_5.Value + 1;
		int num4 = eLC.Lists.Length;
		num3 = ((num3 > num4) ? num4 : num3);
		if (checkBox_6.Checked)
		{
			int_1 = CommonStorage.iarr1;
		}
		if (checkBox_5.Checked)
		{
			int_2 = CommonStorage.iarr2;
		}
		object[] vars = new object[0];
		eLC.ActionsHistory.SubStagesBegin(-1, null, 133, vars);
		if (num2 < num3)
		{
			do
			{
				if (num2 != eLC.ConversationListIndex)
				{
					int num5;
					int num6;
					if (checkBox_6.Checked)
					{
						num5 = 0;
						num6 = eLC.Lists[num2].elementValues.Length;
					}
					else
					{
						num5 = (int)numericUpDown_7.Value;
						num6 = (int)numericUpDown_4.Value + 1;
						int num7 = eLC.Lists[num2].elementValues.Length;
						num6 = ((num6 > num7) ? num7 : num6);
					}
					if (num5 < num6)
					{
						do
						{
							if (!flag || !(text2 != eLC.GetValue(num2, num5, fieldIndex)))
							{
								if (checkBox_6.Checked)
								{
									int[] array = int_1;
									if (array == null || array.Length == 0 || Array.IndexOf(array, num5) <= -1)
									{
										goto IL_0855;
									}
								}
								int num8;
								int num9;
								if (checkBox_5.Checked)
								{
									num8 = 0;
									num9 = eLC.Lists[num2].elementValues[num5].Length;
								}
								else
								{
									num8 = (int)numericUpDown_6.Value;
									num9 = (int)numericUpDown_3.Value + 1;
									int num10 = eLC.Lists[num2].elementValues[num5].Length;
									num9 = ((num9 > num10) ? num10 : num9);
								}
								if (num8 < num9)
								{
									do
									{
										if (checkBox_5.Checked)
										{
											int[] array2 = int_2;
											if (array2 == null || array2.Length == 0 || Array.IndexOf(array2, num8) <= -1)
											{
												goto IL_0817;
											}
										}
										if (radioButton_2.Checked && method_0(num2, num5, num8, num))
										{
											num++;
										}
										if (radioButton_3.Checked)
										{
											string text3 = eLC.Lists[num2].elementTypes[num8];
											if (text3 == Class16.smethod_0(1648989805))
											{
												short num11 = Convert.ToInt16(eLC.GetValue(num2, num5, num8));
												short num12 = Convert.ToInt16(value);
												string value2 = string.Empty;
												if (text == Class16.smethod_0(1648941528))
												{
													value2 = (num12 * num11).ToString();
												}
												if (text == Class16.smethod_0(1648892117))
												{
													value2 = (num11 / num12).ToString();
												}
												if (text == Class16.smethod_0(1648941500))
												{
													value2 = (num12 + num11).ToString();
												}
												if (text == Class16.smethod_0(1648941518))
												{
													value2 = (num11 - num12).ToString();
												}
												eLC.SetValue(num2, num5, num8, value2, AutoSaveStage: true);
												num++;
											}
											if (text3 == Class16.smethod_0(1648989809))
											{
												short num13 = (short)Convert.ToUInt16(eLC.GetValue(num2, num5, num8));
												short num14 = (short)Convert.ToUInt16(value);
												string value3 = string.Empty;
												if (text == Class16.smethod_0(1648941528))
												{
													value3 = (num14 * num13).ToString();
												}
												if (text == Class16.smethod_0(1648892117))
												{
													value3 = (num13 / num14).ToString();
												}
												if (text == Class16.smethod_0(1648941500))
												{
													value3 = (num14 + num13).ToString();
												}
												if (text == Class16.smethod_0(1648941518))
												{
													value3 = (num13 - num14).ToString();
												}
												eLC.SetValue(num2, num5, num8, value3, AutoSaveStage: true);
												num++;
											}
											if (text3 == Class16.smethod_0(1648989776))
											{
												int num15 = Convert.ToInt32(eLC.GetValue(num2, num5, num8));
												int num16 = Convert.ToInt32(value);
												string value4 = string.Empty;
												if (text == Class16.smethod_0(1648941528))
												{
													value4 = (num16 * num15).ToString();
												}
												if (text == Class16.smethod_0(1648892117))
												{
													value4 = (num15 / num16).ToString();
												}
												if (text == Class16.smethod_0(1648941500))
												{
													value4 = (num16 + num15).ToString();
												}
												if (text == Class16.smethod_0(1648941518))
												{
													value4 = (num15 - num16).ToString();
												}
												eLC.SetValue(num2, num5, num8, value4, AutoSaveStage: true);
												num++;
											}
											if (text3 == Class16.smethod_0(1648989830))
											{
												long num17 = Convert.ToInt64(eLC.GetValue(num2, num5, num8));
												long num18 = Convert.ToInt64(value);
												string value5 = string.Empty;
												if (text == Class16.smethod_0(1648941528))
												{
													value5 = (num18 * num17).ToString();
												}
												if (text == Class16.smethod_0(1648892117))
												{
													value5 = (num17 / num18).ToString();
												}
												if (text == Class16.smethod_0(1648941500))
												{
													value5 = (num18 + num17).ToString();
												}
												if (text == Class16.smethod_0(1648941518))
												{
													value5 = (num17 - num18).ToString();
												}
												eLC.SetValue(num2, num5, num8, value5, AutoSaveStage: true);
												num++;
											}
											if (text3 == Class16.smethod_0(1648902744))
											{
												float num19 = Convert.ToSingle(eLC.GetValue(num2, num5, num8));
												float num20 = Convert.ToSingle(value);
												string value6 = string.Empty;
												if (text == Class16.smethod_0(1648941528))
												{
													value6 = ((float)((double)num20 * (double)num19)).ToString(Class16.smethod_0(1648964192));
												}
												if (text == Class16.smethod_0(1648892117))
												{
													value6 = ((float)((double)num19 / (double)num20)).ToString(Class16.smethod_0(1648964192));
												}
												if (text == Class16.smethod_0(1648941500))
												{
													value6 = ((float)((double)num20 + (double)num19)).ToString(Class16.smethod_0(1648964192));
												}
												if (text == Class16.smethod_0(1648941518))
												{
													value6 = ((float)((double)num19 - (double)num20)).ToString(Class16.smethod_0(1648964192));
												}
												eLC.SetValue(num2, num5, num8, value6, AutoSaveStage: true);
												num++;
											}
											if (text3 == Class16.smethod_0(1648989855))
											{
												double num21 = Convert.ToDouble(eLC.GetValue(num2, num5, num8));
												double num22 = Convert.ToDouble(value);
												string value7 = string.Empty;
												if (text == Class16.smethod_0(1648941528))
												{
													value7 = (num22 * num21).ToString(Class16.smethod_0(1648964192));
												}
												if (text == Class16.smethod_0(1648892117))
												{
													value7 = (num21 / num22).ToString(Class16.smethod_0(1648964192));
												}
												if (text == Class16.smethod_0(1648941500))
												{
													value7 = (num22 + num21).ToString(Class16.smethod_0(1648964192));
												}
												if (text == Class16.smethod_0(1648941518))
												{
													value7 = (num21 - num22).ToString(Class16.smethod_0(1648964192));
												}
												eLC.SetValue(num2, num5, num8, value7, AutoSaveStage: true);
												num++;
											}
										}
										goto IL_0817;
										IL_0817:
										num8++;
									}
									while (num8 < num9);
								}
							}
							goto IL_0855;
							IL_0855:
							num5++;
						}
						while (num5 < num6);
					}
				}
				num2++;
			}
			while (num2 < num3);
		}
		eLC.ActionsHistory.SubStagesComplete(-1, null);
		Cursor = Cursors.Default;
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648964201), Class16.smethod_0(1648964242)) + num, string.Empty);
		if (num > 0)
		{
			ACE.RSGlobal.RSGlobal.replaced = true;
		}
		GC.KeepAlive(this);
	}

	private void ReplaceWindow_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.selectfield)
		{
			numericUpDown_6.Focus();
		}
		ACE.RSGlobal.RSGlobal.selectfield = false;
		GC.KeepAlive(this);
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		decimal maximum = numericUpDown_5.Maximum;
		numericUpDown_5.Value = maximum;
		GC.KeepAlive(this);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		decimal maximum = numericUpDown_4.Maximum;
		numericUpDown_4.Value = maximum;
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		decimal maximum = numericUpDown_3.Maximum;
		numericUpDown_3.Value = maximum;
		GC.KeepAlive(this);
	}

	private void numericUpDown_1_ValueChanged(object sender, EventArgs e)
	{
		decimal value = numericUpDown_1.Value;
		numericUpDown_5.Minimum = value;
		GC.KeepAlive(this);
	}

	private void numericUpDown_7_ValueChanged(object sender, EventArgs e)
	{
		decimal value = numericUpDown_7.Value;
		numericUpDown_4.Minimum = value;
		GC.KeepAlive(this);
	}

	private void numericUpDown_6_ValueChanged(object sender, EventArgs e)
	{
		decimal value = numericUpDown_6.Value;
		numericUpDown_3.Minimum = value;
		GC.KeepAlive(this);
	}

	private void ReplaceWindow_Load(object sender, EventArgs e)
	{
		radioButton_3.Parent = this;
	}

	private void checkBox_6_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox_6.Checked)
		{
			int num = int_0;
			if (num >= 0)
			{
				decimal value = num;
				numericUpDown_1.Value = value;
			}
			numericUpDown_1.Enabled = false;
			numericUpDown_5.Enabled = false;
			numericUpDown_7.Enabled = false;
			numericUpDown_4.Enabled = false;
		}
		else
		{
			numericUpDown_1.Enabled = true;
			numericUpDown_5.Enabled = true;
			numericUpDown_7.Enabled = true;
			numericUpDown_4.Enabled = true;
		}
		GC.KeepAlive(this);
	}

	private void checkBox_5_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox_5.Checked)
		{
			numericUpDown_6.Enabled = false;
			numericUpDown_3.Enabled = false;
		}
		else
		{
			numericUpDown_6.Enabled = true;
			numericUpDown_3.Enabled = true;
		}
		GC.KeepAlive(this);
	}

	private void ReplaceWindow_FormClosed(object sender, FormClosedEventArgs e)
	{
		CommonStorage.bData = false;
	}
}
