using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.Elements;

public class EquipSlotMaskWindow : Form
{
	private CommonStorage commonStorage_0;

	protected bool lockCheckBox;

	private NumericUpDown numericUpDown_0;

	public Label label1;

	private Button button_0;

	private Label label_0;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private CheckBox checkBox_5;

	private CheckBox checkBox_6;

	private CheckBox checkBox_7;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private CheckBox checkBox_8;

	private CheckBox checkBox_9;

	private CheckBox checkBox_10;

	private CheckBox checkBox_11;

	private CheckBox checkBox_12;

	private CheckBox checkBox_13;

	private CheckBox checkBox_14;

	private CheckBox checkBox_15;

	private CheckBox checkBox_16;

	private CheckBox checkBox_17;

	private CheckBox checkBox_18;

	private CheckBox checkBox_19;

	private CheckBox checkBox_20;

	private CheckBox checkBox_21;

	private CheckBox checkBox_22;

	private CheckBox checkBox_23;

	private CheckBox checkBox_24;

	private CheckBox checkBox_25;

	private CheckBox checkBox_26;

	private CheckBox checkBox_27;

	private CheckBox checkBox_28;

	private CheckBox checkBox_29;

	private CheckBox checkBox_30;

	private CheckBox checkBox_31;

	private CheckBox checkBox_32;

	public IContainer components;

	public EquipSlotMaskWindow(string mask, CommonStorage ref_CStorage)
	{
		try
		{
			commonStorage_0 = ref_CStorage;
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			if (CommonStorage.Texts.Lang.Prefix != Class16.smethod_0(1648932072))
			{
				TextStorage.TEXTS.SetFormLanguage(this, null);
			}
			numericUpDown_0.Text = mask;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void checkBox_32_CheckedChanged(object sender, EventArgs e)
	{
		if (lockCheckBox)
		{
			return;
		}
		uint num = 0u;
		int num2 = 1;
		do
		{
			int num3 = num2;
			string text = Class16.smethod_0(1648986432);
			if (((CheckBox)base.Controls[text + num3]).Enabled)
			{
				int num4 = num2;
				string text2 = Class16.smethod_0(1648986432);
				if (((CheckBox)base.Controls[text2 + num4]).Checked)
				{
					num = (uint)Math.Pow(2.0, (uint)(num2 - 1)) + num;
				}
			}
			num2++;
		}
		while (num2 <= 32);
		lockCheckBox = true;
		decimal value = Convert.ToDecimal(num);
		numericUpDown_0.Value = value;
		lockCheckBox = false;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (commonStorage_0 != null)
		{
			CommonStorage.sData = numericUpDown_0.Value.ToString();
		}
		Close();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		int num = 1;
		do
		{
			int num2 = num;
			string text = Class16.smethod_0(1648986432);
			if (((CheckBox)base.Controls[text + num2]).Enabled)
			{
				int num3 = num;
				string text2 = Class16.smethod_0(1648986432);
				((CheckBox)base.Controls[text2 + num3]).Checked = true;
			}
			num++;
		}
		while (num <= 32);
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		int num = 1;
		do
		{
			int num2 = num;
			string text = Class16.smethod_0(1648986432);
			((CheckBox)base.Controls[text + num2]).Checked = false;
			num++;
		}
		while (num <= 32);
		GC.KeepAlive(this);
	}

	private void method_0()
	{
		components?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		new ComponentResourceManager(typeof(EquipSlotMaskWindow));
		numericUpDown_0 = new NumericUpDown();
		button_0 = new Button();
		label_0 = new Label();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		checkBox_3 = new CheckBox();
		checkBox_4 = new CheckBox();
		checkBox_5 = new CheckBox();
		checkBox_6 = new CheckBox();
		checkBox_7 = new CheckBox();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		checkBox_8 = new CheckBox();
		checkBox_9 = new CheckBox();
		checkBox_10 = new CheckBox();
		checkBox_11 = new CheckBox();
		checkBox_12 = new CheckBox();
		checkBox_13 = new CheckBox();
		checkBox_14 = new CheckBox();
		checkBox_15 = new CheckBox();
		checkBox_16 = new CheckBox();
		checkBox_17 = new CheckBox();
		checkBox_18 = new CheckBox();
		checkBox_19 = new CheckBox();
		checkBox_20 = new CheckBox();
		checkBox_21 = new CheckBox();
		checkBox_22 = new CheckBox();
		checkBox_23 = new CheckBox();
		checkBox_24 = new CheckBox();
		checkBox_25 = new CheckBox();
		checkBox_26 = new CheckBox();
		checkBox_27 = new CheckBox();
		checkBox_28 = new CheckBox();
		checkBox_29 = new CheckBox();
		checkBox_30 = new CheckBox();
		checkBox_31 = new CheckBox();
		checkBox_32 = new CheckBox();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		SuspendLayout();
		numericUpDown_0.BackColor = Color.White;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_0.ForeColor = Color.Black;
		numericUpDown_0.Location = new Point(91, 275);
		numericUpDown_0.Margin = new Padding(4);
		numericUpDown_0.Maximum = new decimal(new int[4] { -1, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648988480);
		numericUpDown_0.Size = new Size(176, 22);
		numericUpDown_0.TabIndex = 10;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.OK;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.EquipSlotMaskWindow_cmdok;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(6, 304);
		button_0.Name = Class16.smethod_0(1648925748);
		button_0.Size = new Size(195, 38);
		button_0.TabIndex = 11;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648988505);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.Location = new Point(12, 275);
		label_0.Name = Class16.smethod_0(1648912083);
		label_0.Size = new Size(72, 20);
		label_0.TabIndex = 12;
		label_0.Text = Class16.smethod_0(1648988522);
		label_0.TextAlign = ContentAlignment.MiddleRight;
		checkBox_0.AutoSize = true;
		checkBox_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_0.ForeColor = Color.Black;
		checkBox_0.Location = new Point(15, 151);
		checkBox_0.Margin = new Padding(4);
		checkBox_0.Name = Class16.smethod_0(1648986455);
		checkBox_0.Size = new Size(71, 21);
		checkBox_0.TabIndex = 19;
		checkBox_0.Text = Class16.smethod_0(1648986471);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_1.AutoSize = true;
		checkBox_1.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_1.ForeColor = Color.Black;
		checkBox_1.Location = new Point(120, 59);
		checkBox_1.Margin = new Padding(4);
		checkBox_1.Name = Class16.smethod_0(1648986485);
		checkBox_1.Size = new Size(79, 21);
		checkBox_1.TabIndex = 27;
		checkBox_1.Text = Class16.smethod_0(1648986502);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_2.AutoSize = true;
		checkBox_2.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_2.ForeColor = Color.Black;
		checkBox_2.Location = new Point(120, 13);
		checkBox_2.Margin = new Padding(4);
		checkBox_2.Name = Class16.smethod_0(1648986518);
		checkBox_2.Size = new Size(96, 21);
		checkBox_2.TabIndex = 25;
		checkBox_2.Text = Class16.smethod_0(1648986535);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_2.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_3.AutoSize = true;
		checkBox_3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_3.ForeColor = Color.Black;
		checkBox_3.Location = new Point(120, 36);
		checkBox_3.Margin = new Padding(4);
		checkBox_3.Name = Class16.smethod_0(1648986544);
		checkBox_3.Size = new Size(58, 21);
		checkBox_3.TabIndex = 26;
		checkBox_3.Text = Class16.smethod_0(1648986561);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_3.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_4.AutoSize = true;
		checkBox_4.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_4.ForeColor = Color.Black;
		checkBox_4.Location = new Point(15, 219);
		checkBox_4.Margin = new Padding(4);
		checkBox_4.Name = Class16.smethod_0(1648986582);
		checkBox_4.Size = new Size(64, 21);
		checkBox_4.TabIndex = 23;
		checkBox_4.Text = Class16.smethod_0(1648986599);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_4.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_5.AutoSize = true;
		checkBox_5.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_5.ForeColor = Color.Black;
		checkBox_5.Location = new Point(15, 242);
		checkBox_5.Margin = new Padding(4);
		checkBox_5.Name = Class16.smethod_0(1648986612);
		checkBox_5.Size = new Size(64, 21);
		checkBox_5.TabIndex = 24;
		checkBox_5.Text = Class16.smethod_0(1648981509);
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_5.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_6.AutoSize = true;
		checkBox_6.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_6.ForeColor = Color.Black;
		checkBox_6.Location = new Point(15, 174);
		checkBox_6.Margin = new Padding(4);
		checkBox_6.Name = Class16.smethod_0(1648981514);
		checkBox_6.Size = new Size(60, 21);
		checkBox_6.TabIndex = 21;
		checkBox_6.Text = Class16.smethod_0(1648981530);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_6.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_7.AutoSize = true;
		checkBox_7.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_7.ForeColor = Color.Black;
		checkBox_7.Location = new Point(15, 198);
		checkBox_7.Margin = new Padding(4);
		checkBox_7.Name = Class16.smethod_0(1648981550);
		checkBox_7.Size = new Size(79, 21);
		checkBox_7.TabIndex = 22;
		checkBox_7.Text = Class16.smethod_0(1648981566);
		checkBox_7.UseVisualStyleBackColor = true;
		checkBox_7.CheckedChanged += checkBox_32_CheckedChanged;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_1.ForeColor = Color.FromArgb(192, 0, 0);
		button_1.Location = new Point(274, 274);
		button_1.Name = Class16.smethod_0(1648988562);
		button_1.Size = new Size(55, 22);
		button_1.TabIndex = 29;
		button_1.Text = Class16.smethod_0(1648988590);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_2.ForeColor = Color.Blue;
		button_2.Location = new Point(335, 274);
		button_2.Name = Class16.smethod_0(1648988542);
		button_2.Size = new Size(55, 22);
		button_2.TabIndex = 30;
		button_2.Text = Class16.smethod_0(1648981582);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.AutoSize = true;
		button_3.DialogResult = DialogResult.Cancel;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_3.Image = Resources.EquipSlotMaskWindow_cmdcancel;
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(207, 304);
		button_3.Name = Class16.smethod_0(1648925752);
		button_3.Size = new Size(183, 32);
		button_3.TabIndex = 31;
		button_3.TabStop = false;
		button_3.Text = Class16.smethod_0(1648989215);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		checkBox_8.AutoSize = true;
		checkBox_8.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_8.ForeColor = Color.Black;
		checkBox_8.Location = new Point(15, 105);
		checkBox_8.Margin = new Padding(4);
		checkBox_8.Name = Class16.smethod_0(1648981596);
		checkBox_8.Size = new Size(60, 21);
		checkBox_8.TabIndex = 36;
		checkBox_8.Text = Class16.smethod_0(1648981612);
		checkBox_8.UseVisualStyleBackColor = true;
		checkBox_8.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_9.AutoSize = true;
		checkBox_9.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_9.ForeColor = Color.Black;
		checkBox_9.Location = new Point(15, 128);
		checkBox_9.Margin = new Padding(4);
		checkBox_9.Name = Class16.smethod_0(1648981616);
		checkBox_9.Size = new Size(65, 21);
		checkBox_9.TabIndex = 37;
		checkBox_9.Text = Class16.smethod_0(1648981632);
		checkBox_9.UseVisualStyleBackColor = true;
		checkBox_9.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_10.AutoSize = true;
		checkBox_10.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_10.ForeColor = Color.Black;
		checkBox_10.Location = new Point(15, 59);
		checkBox_10.Margin = new Padding(4);
		checkBox_10.Name = Class16.smethod_0(1648981652);
		checkBox_10.Size = new Size(79, 21);
		checkBox_10.TabIndex = 34;
		checkBox_10.Text = Class16.smethod_0(1648981668);
		checkBox_10.UseVisualStyleBackColor = true;
		checkBox_10.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_11.AutoSize = true;
		checkBox_11.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_11.ForeColor = Color.Black;
		checkBox_11.Location = new Point(15, 82);
		checkBox_11.Margin = new Padding(4);
		checkBox_11.Name = Class16.smethod_0(1648981675);
		checkBox_11.Size = new Size(60, 21);
		checkBox_11.TabIndex = 35;
		checkBox_11.Text = Class16.smethod_0(1648981691);
		checkBox_11.UseVisualStyleBackColor = true;
		checkBox_11.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_12.AutoSize = true;
		checkBox_12.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_12.ForeColor = Color.Black;
		checkBox_12.Location = new Point(15, 13);
		checkBox_12.Margin = new Padding(4);
		checkBox_12.Name = Class16.smethod_0(1648981711);
		checkBox_12.Size = new Size(75, 21);
		checkBox_12.TabIndex = 32;
		checkBox_12.Text = Class16.smethod_0(1648981727);
		checkBox_12.UseVisualStyleBackColor = true;
		checkBox_12.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_13.AutoSize = true;
		checkBox_13.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_13.ForeColor = Color.Black;
		checkBox_13.Location = new Point(15, 36);
		checkBox_13.Margin = new Padding(4);
		checkBox_13.Name = Class16.smethod_0(1648981740);
		checkBox_13.Size = new Size(57, 21);
		checkBox_13.TabIndex = 33;
		checkBox_13.Text = Class16.smethod_0(1648981756);
		checkBox_13.UseVisualStyleBackColor = true;
		checkBox_13.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_14.AutoSize = true;
		checkBox_14.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_14.ForeColor = Color.Black;
		checkBox_14.Location = new Point(120, 82);
		checkBox_14.Margin = new Padding(4);
		checkBox_14.Name = Class16.smethod_0(1648981767);
		checkBox_14.Size = new Size(90, 21);
		checkBox_14.TabIndex = 38;
		checkBox_14.Text = Class16.smethod_0(1648981776);
		checkBox_14.UseVisualStyleBackColor = true;
		checkBox_14.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_15.AutoSize = true;
		checkBox_15.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_15.ForeColor = Color.Black;
		checkBox_15.Location = new Point(120, 105);
		checkBox_15.Margin = new Padding(4);
		checkBox_15.Name = Class16.smethod_0(1648981794);
		checkBox_15.Size = new Size(92, 21);
		checkBox_15.TabIndex = 39;
		checkBox_15.Text = Class16.smethod_0(1648981811);
		checkBox_15.UseVisualStyleBackColor = true;
		checkBox_15.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_16.AutoSize = true;
		checkBox_16.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_16.ForeColor = Color.Black;
		checkBox_16.Location = new Point(120, 128);
		checkBox_16.Margin = new Padding(4);
		checkBox_16.Name = Class16.smethod_0(1648981837);
		checkBox_16.Size = new Size(96, 21);
		checkBox_16.TabIndex = 40;
		checkBox_16.Text = Class16.smethod_0(1648981854);
		checkBox_16.UseVisualStyleBackColor = true;
		checkBox_16.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_17.AutoSize = true;
		checkBox_17.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_17.ForeColor = Color.Black;
		checkBox_17.Location = new Point(120, 151);
		checkBox_17.Margin = new Padding(4);
		checkBox_17.Name = Class16.smethod_0(1648981865);
		checkBox_17.Size = new Size(66, 21);
		checkBox_17.TabIndex = 41;
		checkBox_17.Text = Class16.smethod_0(1648981882);
		checkBox_17.UseVisualStyleBackColor = true;
		checkBox_17.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_18.AutoSize = true;
		checkBox_18.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_18.ForeColor = Color.Black;
		checkBox_18.Location = new Point(120, 220);
		checkBox_18.Margin = new Padding(4);
		checkBox_18.Name = Class16.smethod_0(1648981903);
		checkBox_18.Size = new Size(70, 21);
		checkBox_18.TabIndex = 44;
		checkBox_18.Text = Class16.smethod_0(1648981912);
		checkBox_18.UseVisualStyleBackColor = true;
		checkBox_18.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_19.AutoSize = true;
		checkBox_19.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_19.ForeColor = Color.Black;
		checkBox_19.Location = new Point(120, 243);
		checkBox_19.Margin = new Padding(4);
		checkBox_19.Name = Class16.smethod_0(1648981934);
		checkBox_19.Size = new Size(73, 21);
		checkBox_19.TabIndex = 45;
		checkBox_19.Text = Class16.smethod_0(1648981951);
		checkBox_19.UseVisualStyleBackColor = true;
		checkBox_19.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_20.AutoSize = true;
		checkBox_20.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_20.ForeColor = Color.Black;
		checkBox_20.Location = new Point(120, 174);
		checkBox_20.Margin = new Padding(4);
		checkBox_20.Name = Class16.smethod_0(1648981965);
		checkBox_20.Size = new Size(56, 21);
		checkBox_20.TabIndex = 42;
		checkBox_20.Text = Class16.smethod_0(1648981982);
		checkBox_20.UseVisualStyleBackColor = true;
		checkBox_20.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_21.AutoSize = true;
		checkBox_21.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_21.ForeColor = Color.Black;
		checkBox_21.Location = new Point(120, 197);
		checkBox_21.Margin = new Padding(4);
		checkBox_21.Name = Class16.smethod_0(1648981985);
		checkBox_21.Size = new Size(64, 21);
		checkBox_21.TabIndex = 43;
		checkBox_21.Text = Class16.smethod_0(1648982002);
		checkBox_21.UseVisualStyleBackColor = true;
		checkBox_21.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_22.AutoSize = true;
		checkBox_22.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_22.Location = new Point(252, 36);
		checkBox_22.Margin = new Padding(4);
		checkBox_22.Name = Class16.smethod_0(1648980999);
		checkBox_22.Size = new Size(60, 21);
		checkBox_22.TabIndex = 47;
		checkBox_22.Text = Class16.smethod_0(1648981008);
		checkBox_22.UseVisualStyleBackColor = true;
		checkBox_22.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_23.AutoSize = true;
		checkBox_23.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_23.Location = new Point(252, 59);
		checkBox_23.Margin = new Padding(4);
		checkBox_23.Name = Class16.smethod_0(1648981028);
		checkBox_23.Size = new Size(93, 21);
		checkBox_23.TabIndex = 48;
		checkBox_23.Text = Class16.smethod_0(1648981045);
		checkBox_23.UseVisualStyleBackColor = true;
		checkBox_23.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_24.AutoSize = true;
		checkBox_24.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_24.Location = new Point(252, 13);
		checkBox_24.Margin = new Padding(4);
		checkBox_24.Name = Class16.smethod_0(1648981062);
		checkBox_24.Size = new Size(128, 21);
		checkBox_24.TabIndex = 46;
		checkBox_24.Text = Class16.smethod_0(1648981079);
		checkBox_24.UseVisualStyleBackColor = true;
		checkBox_24.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_25.AutoSize = true;
		checkBox_25.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_25.Location = new Point(252, 82);
		checkBox_25.Margin = new Padding(4);
		checkBox_25.Name = Class16.smethod_0(1648981103);
		checkBox_25.Size = new Size(79, 21);
		checkBox_25.TabIndex = 49;
		checkBox_25.Text = Class16.smethod_0(1648986502);
		checkBox_25.UseVisualStyleBackColor = true;
		checkBox_25.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_26.AutoSize = true;
		checkBox_26.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_26.Location = new Point(252, 105);
		checkBox_26.Margin = new Padding(4);
		checkBox_26.Name = Class16.smethod_0(1648981112);
		checkBox_26.Size = new Size(131, 21);
		checkBox_26.TabIndex = 50;
		checkBox_26.Text = Class16.smethod_0(1648981129);
		checkBox_26.UseVisualStyleBackColor = true;
		checkBox_26.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_27.AutoSize = true;
		checkBox_27.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Italic, GraphicsUnit.Point, 204);
		checkBox_27.Location = new Point(252, 197);
		checkBox_27.Margin = new Padding(4);
		checkBox_27.Name = Class16.smethod_0(1648981164);
		checkBox_27.Size = new Size(97, 21);
		checkBox_27.TabIndex = 54;
		checkBox_27.Text = Class16.smethod_0(1648981181);
		checkBox_27.UseVisualStyleBackColor = true;
		checkBox_27.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_28.AutoSize = true;
		checkBox_28.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Italic, GraphicsUnit.Point, 204);
		checkBox_28.Location = new Point(252, 220);
		checkBox_28.Margin = new Padding(4);
		checkBox_28.Name = Class16.smethod_0(1648981198);
		checkBox_28.Size = new Size(97, 21);
		checkBox_28.TabIndex = 55;
		checkBox_28.Text = Class16.smethod_0(1648981215);
		checkBox_28.UseVisualStyleBackColor = true;
		checkBox_28.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_29.AutoSize = true;
		checkBox_29.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_29.Location = new Point(252, 151);
		checkBox_29.Margin = new Padding(4);
		checkBox_29.Name = Class16.smethod_0(1648981224);
		checkBox_29.Size = new Size(122, 21);
		checkBox_29.TabIndex = 52;
		checkBox_29.Text = Class16.smethod_0(1648981241);
		checkBox_29.UseVisualStyleBackColor = true;
		checkBox_29.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_30.AutoSize = true;
		checkBox_30.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_30.Location = new Point(252, 174);
		checkBox_30.Margin = new Padding(4);
		checkBox_30.Name = Class16.smethod_0(1648981265);
		checkBox_30.Size = new Size(74, 21);
		checkBox_30.TabIndex = 53;
		checkBox_30.Text = Class16.smethod_0(1648981282);
		checkBox_30.UseVisualStyleBackColor = true;
		checkBox_30.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_31.AutoSize = true;
		checkBox_31.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_31.Location = new Point(252, 128);
		checkBox_31.Margin = new Padding(4);
		checkBox_31.Name = Class16.smethod_0(1648981298);
		checkBox_31.Size = new Size(122, 21);
		checkBox_31.TabIndex = 51;
		checkBox_31.Text = Class16.smethod_0(1648981315);
		checkBox_31.UseVisualStyleBackColor = true;
		checkBox_31.CheckedChanged += checkBox_32_CheckedChanged;
		checkBox_32.AutoSize = true;
		checkBox_32.Enabled = false;
		checkBox_32.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Italic, GraphicsUnit.Point, 204);
		checkBox_32.Location = new Point(252, 245);
		checkBox_32.Margin = new Padding(4);
		checkBox_32.Name = Class16.smethod_0(1648981339);
		checkBox_32.Size = new Size(44, 21);
		checkBox_32.TabIndex = 56;
		checkBox_32.Text = Class16.smethod_0(1648908427);
		checkBox_32.UseVisualStyleBackColor = true;
		checkBox_32.CheckedChanged += checkBox_32_CheckedChanged;
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(7f, 17f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_3;
		base.ClientSize = new Size(397, 343);
		base.Controls.Add(checkBox_32);
		base.Controls.Add(checkBox_27);
		base.Controls.Add(checkBox_28);
		base.Controls.Add(checkBox_29);
		base.Controls.Add(checkBox_30);
		base.Controls.Add(checkBox_31);
		base.Controls.Add(checkBox_25);
		base.Controls.Add(checkBox_26);
		base.Controls.Add(checkBox_22);
		base.Controls.Add(checkBox_23);
		base.Controls.Add(checkBox_24);
		base.Controls.Add(checkBox_18);
		base.Controls.Add(checkBox_19);
		base.Controls.Add(checkBox_20);
		base.Controls.Add(checkBox_21);
		base.Controls.Add(checkBox_16);
		base.Controls.Add(checkBox_17);
		base.Controls.Add(checkBox_14);
		base.Controls.Add(checkBox_15);
		base.Controls.Add(checkBox_8);
		base.Controls.Add(checkBox_9);
		base.Controls.Add(checkBox_10);
		base.Controls.Add(checkBox_11);
		base.Controls.Add(checkBox_12);
		base.Controls.Add(checkBox_13);
		base.Controls.Add(button_3);
		base.Controls.Add(button_2);
		base.Controls.Add(button_1);
		base.Controls.Add(checkBox_1);
		base.Controls.Add(checkBox_2);
		base.Controls.Add(checkBox_3);
		base.Controls.Add(checkBox_4);
		base.Controls.Add(checkBox_5);
		base.Controls.Add(checkBox_6);
		base.Controls.Add(checkBox_7);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(label_0);
		base.Controls.Add(button_0);
		base.Controls.Add(numericUpDown_0);
		Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.EquipSlotMaskWindow_Icon;
		base.Margin = new Padding(4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648981364);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648981390);
		base.Load += EquipSlotMaskWindow_Load;
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

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (!lockCheckBox)
		{
			lockCheckBox = true;
			uint num = (uint)numericUpDown_0.Value;
			button_1_Click(null, null);
			if (num / (uint)Math.Pow(2.0, 31.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 31.0);
				checkBox_28.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 30.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 30.0);
				checkBox_27.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 29.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 29.0);
				checkBox_30.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 28.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 28.0);
				checkBox_29.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 27.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 27.0);
				checkBox_31.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 26.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 26.0);
				checkBox_26.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 25.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 25.0);
				checkBox_25.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 24.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 24.0);
				checkBox_23.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 23.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 23.0);
				checkBox_22.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 22.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 22.0);
				checkBox_24.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 21.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 21.0);
				checkBox_19.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 20.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 20.0);
				checkBox_18.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 19.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 19.0);
				checkBox_21.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 18.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 18.0);
				checkBox_20.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 17.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 17.0);
				checkBox_17.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 16.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 16.0);
				checkBox_16.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 15.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 15.0);
				checkBox_15.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 14.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 14.0);
				checkBox_14.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 13.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 13.0);
				checkBox_1.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 12.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 12.0);
				checkBox_3.Checked = true;
			}
			if (num / (uint)Math.Pow(2.0, 11.0) != 0)
			{
				num %= (uint)Math.Pow(2.0, 11.0);
				checkBox_2.Checked = true;
			}
			if ((num & 0xFFFFFC00u) != 0)
			{
				num &= 0x3FF;
				checkBox_5.Checked = true;
			}
			if ((num & 0xFFFFFE00u) != 0)
			{
				num &= 0x1FF;
				checkBox_4.Checked = true;
			}
			if ((num & 0xFFFFFF00u) != 0)
			{
				num &= 0xFF;
				checkBox_7.Checked = true;
			}
			if ((num & 0xFFFFFF80u) != 0)
			{
				num &= 0x7F;
				checkBox_6.Checked = true;
			}
			if ((num & 0xFFFFFFC0u) != 0)
			{
				num &= 0x3F;
				checkBox_0.Checked = true;
			}
			if ((num & 0xFFFFFFE0u) != 0)
			{
				num &= 0x1F;
				checkBox_9.Checked = true;
			}
			if ((num & 0xFFFFFFF0u) != 0)
			{
				num &= 0xF;
				checkBox_8.Checked = true;
			}
			if ((num & 0xFFFFFFF8u) != 0)
			{
				num &= 7;
				checkBox_11.Checked = true;
			}
			if ((num & 0xFFFFFFFCu) != 0)
			{
				num &= 3;
				checkBox_10.Checked = true;
			}
			if ((num & 0xFFFFFFFEu) != 0)
			{
				num &= 1;
				checkBox_13.Checked = true;
			}
			if (num != 0)
			{
				checkBox_12.Checked = true;
			}
			lockCheckBox = false;
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void EquipSlotMaskWindow_Load(object sender, EventArgs e)
	{
	}
}
