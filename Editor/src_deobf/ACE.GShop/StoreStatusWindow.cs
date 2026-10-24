using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.GShop;

public class StoreStatusWindow : Form
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

	private Button button_1;

	private ToolTip toolTip_0;

	private Button button_2;

	private Button button_3;

	private GroupBox groupBox_0;

	private GroupBox groupBox_1;

	private GroupBox groupBox_2;

	private IContainer icontainer_0;

	public StoreStatusWindow(string status, CommonStorage ref_CStorage)
	{
		try
		{
			commonStorage_0 = ref_CStorage;
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			numericUpDown_0.Text = status;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void checkBox_20_CheckedChanged(object sender, EventArgs e)
	{
		if (lockCheckBox)
		{
			return;
		}
		lockCheckBox = true;
		if (sender is CheckBox { Checked: not false } checkBox)
		{
			if (checkBox == checkBox_0 || checkBox == checkBox_1 || checkBox == checkBox_2 || checkBox == checkBox_3 || checkBox == checkBox_4 || checkBox == checkBox_5)
			{
				checkBox_0.Checked = checkBox == checkBox_0;
				checkBox_1.Checked = checkBox == checkBox_1;
				checkBox_2.Checked = checkBox == checkBox_2;
				checkBox_3.Checked = checkBox == checkBox_3;
				checkBox_4.Checked = checkBox == checkBox_4;
				checkBox_5.Checked = checkBox == checkBox_5;
			}
			if (checkBox == checkBox_14 || checkBox == checkBox_13 || checkBox == checkBox_12 || checkBox == checkBox_11 || checkBox == checkBox_10 || checkBox == checkBox_9 || checkBox == checkBox_8 || checkBox == checkBox_7 || checkBox == checkBox_6)
			{
				checkBox_14.Checked = checkBox == checkBox_14;
				checkBox_13.Checked = checkBox == checkBox_13;
				checkBox_12.Checked = checkBox == checkBox_12;
				checkBox_11.Checked = checkBox == checkBox_11;
				checkBox_10.Checked = checkBox == checkBox_10;
				checkBox_9.Checked = checkBox == checkBox_9;
				checkBox_8.Checked = checkBox == checkBox_8;
				checkBox_7.Checked = checkBox == checkBox_7;
				checkBox_6.Checked = checkBox == checkBox_6;
			}
			if (checkBox == checkBox_15 || checkBox == checkBox_16 || checkBox == checkBox_17 || checkBox == checkBox_18 || checkBox == checkBox_19 || checkBox == checkBox_20)
			{
				checkBox_15.Checked = checkBox == checkBox_15;
				checkBox_16.Checked = checkBox == checkBox_16;
				checkBox_17.Checked = checkBox == checkBox_17;
				checkBox_18.Checked = checkBox == checkBox_18;
				checkBox_19.Checked = checkBox == checkBox_19;
				checkBox_20.Checked = checkBox == checkBox_20;
			}
		}
		int num = 0;
		if (checkBox_0.Checked)
		{
			num = 0;
		}
		else if (checkBox_1.Checked)
		{
			num = 1;
		}
		else if (checkBox_2.Checked)
		{
			num = 2;
		}
		else if (checkBox_3.Checked)
		{
			num = 3;
		}
		else if (checkBox_4.Checked)
		{
			num = 9;
		}
		else if (checkBox_5.Checked)
		{
			num = 15;
		}
		if (checkBox_14.Checked)
		{
			num += 16;
		}
		else if (checkBox_13.Checked)
		{
			num += 32;
		}
		else if (checkBox_12.Checked)
		{
			num += 64;
		}
		else if (checkBox_11.Checked)
		{
			num += 128;
		}
		else if (checkBox_10.Checked)
		{
			num += 256;
		}
		else if (checkBox_9.Checked)
		{
			num += 512;
		}
		else if (checkBox_8.Checked)
		{
			num += 1024;
		}
		else if (checkBox_7.Checked)
		{
			num += 2048;
		}
		else if (checkBox_6.Checked)
		{
			num += 4096;
		}
		if (checkBox_15.Checked)
		{
			num += 16384;
		}
		else if (checkBox_16.Checked)
		{
			num += 32768;
		}
		else if (checkBox_17.Checked)
		{
			num += 65536;
		}
		else if (checkBox_18.Checked)
		{
			num += 131072;
		}
		else if (checkBox_19.Checked)
		{
			num += 262144;
		}
		else if (checkBox_20.Checked)
		{
			num += 524288;
		}
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
		checkBox_0.Checked = true;
		checkBox_14.Checked = true;
		checkBox_15.Checked = true;
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		checkBox_0.Checked = false;
		checkBox_1.Checked = false;
		checkBox_2.Checked = false;
		checkBox_3.Checked = false;
		checkBox_4.Checked = false;
		checkBox_5.Checked = false;
		checkBox_14.Checked = false;
		checkBox_13.Checked = false;
		checkBox_12.Checked = false;
		checkBox_11.Checked = false;
		checkBox_10.Checked = false;
		checkBox_9.Checked = false;
		checkBox_8.Checked = false;
		checkBox_7.Checked = false;
		checkBox_6.Checked = false;
		checkBox_15.Checked = false;
		checkBox_16.Checked = false;
		checkBox_17.Checked = false;
		checkBox_18.Checked = false;
		checkBox_19.Checked = false;
		checkBox_20.Checked = false;
		GC.KeepAlive(this);
	}

	private void method_0()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(StoreStatusWindow));
		numericUpDown_0 = new NumericUpDown();
		button_0 = new Button();
		label_0 = new Label();
		button_1 = new Button();
		button_2 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		button_3 = new Button();
		groupBox_0 = new GroupBox();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		checkBox_3 = new CheckBox();
		checkBox_4 = new CheckBox();
		checkBox_5 = new CheckBox();
		groupBox_1 = new GroupBox();
		checkBox_6 = new CheckBox();
		checkBox_7 = new CheckBox();
		checkBox_8 = new CheckBox();
		checkBox_9 = new CheckBox();
		checkBox_10 = new CheckBox();
		checkBox_11 = new CheckBox();
		checkBox_12 = new CheckBox();
		checkBox_13 = new CheckBox();
		checkBox_14 = new CheckBox();
		groupBox_2 = new GroupBox();
		checkBox_15 = new CheckBox();
		checkBox_16 = new CheckBox();
		checkBox_17 = new CheckBox();
		checkBox_18 = new CheckBox();
		checkBox_19 = new CheckBox();
		checkBox_20 = new CheckBox();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		groupBox_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		groupBox_2.SuspendLayout();
		SuspendLayout();
		numericUpDown_0.BackColor = Color.White;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_0.ForeColor = Color.Black;
		numericUpDown_0.Location = new Point(75, 360);
		numericUpDown_0.Margin = new Padding(4);
		numericUpDown_0.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1649054123);
		numericUpDown_0.Size = new Size(190, 22);
		numericUpDown_0.TabIndex = 10;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.OK;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(12, 390);
		button_0.Name = Class16.smethod_0(1648925748);
		button_0.Size = new Size(195, 33);
		button_0.TabIndex = 11;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648988505);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.Location = new Point(10, 360);
		label_0.Name = Class16.smethod_0(1648912083);
		label_0.Size = new Size(52, 20);
		label_0.TabIndex = 12;
		label_0.Text = Class16.smethod_0(1649064854);
		button_1.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_1.ForeColor = Color.FromArgb(192, 0, 0);
		button_1.Location = new Point(272, 359);
		button_1.Name = Class16.smethod_0(1648988562);
		button_1.Size = new Size(55, 22);
		button_1.TabIndex = 29;
		button_1.Text = Class16.smethod_0(1648912688);
		toolTip_0.SetToolTip(button_1, Class16.smethod_0(1648977778));
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_2.ForeColor = Color.Blue;
		button_2.Location = new Point(333, 359);
		button_2.Name = Class16.smethod_0(1648988542);
		button_2.Size = new Size(55, 22);
		button_2.TabIndex = 30;
		button_2.Text = Class16.smethod_0(1648988552);
		toolTip_0.SetToolTip(button_2, Class16.smethod_0(1648976420));
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.AutoSize = true;
		button_3.DialogResult = DialogResult.Cancel;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(213, 390);
		button_3.Name = Class16.smethod_0(1648925752);
		button_3.Size = new Size(183, 33);
		button_3.TabIndex = 31;
		button_3.TabStop = false;
		button_3.Text = Class16.smethod_0(1648989215);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		groupBox_0.Controls.Add(checkBox_0);
		groupBox_0.Controls.Add(checkBox_1);
		groupBox_0.Controls.Add(checkBox_2);
		groupBox_0.Controls.Add(checkBox_3);
		groupBox_0.Controls.Add(checkBox_4);
		groupBox_0.Controls.Add(checkBox_5);
		groupBox_0.Location = new Point(12, 12);
		groupBox_0.Name = Class16.smethod_0(1649054158);
		groupBox_0.Size = new Size(253, 206);
		groupBox_0.TabIndex = 0;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1649054182);
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(15, 20);
		checkBox_0.Name = Class16.smethod_0(1649054199);
		checkBox_0.Size = new Size(125, 21);
		checkBox_0.TabIndex = 0;
		checkBox_0.Text = Class16.smethod_0(1649057289);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_1.AutoSize = true;
		checkBox_1.Location = new Point(15, 45);
		checkBox_1.Name = Class16.smethod_0(1649057312);
		checkBox_1.Size = new Size(107, 21);
		checkBox_1.TabIndex = 1;
		checkBox_1.Text = Class16.smethod_0(1649057343);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_2.AutoSize = true;
		checkBox_2.Location = new Point(15, 70);
		checkBox_2.Name = Class16.smethod_0(1649057355);
		checkBox_2.Size = new Size(169, 21);
		checkBox_2.TabIndex = 2;
		checkBox_2.Text = Class16.smethod_0(1649057386);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_2.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_3.AutoSize = true;
		checkBox_3.Location = new Point(15, 95);
		checkBox_3.Name = Class16.smethod_0(1649057422);
		checkBox_3.Size = new Size(189, 21);
		checkBox_3.TabIndex = 3;
		checkBox_3.Text = Class16.smethod_0(1649057443);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_3.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(15, 120);
		checkBox_4.Name = Class16.smethod_0(1649057487);
		checkBox_4.Size = new Size(176, 21);
		checkBox_4.TabIndex = 4;
		checkBox_4.Text = Class16.smethod_0(1649057506);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_4.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_5.AutoSize = true;
		checkBox_5.Location = new Point(15, 145);
		checkBox_5.Name = Class16.smethod_0(1649057548);
		checkBox_5.Size = new Size(182, 21);
		checkBox_5.TabIndex = 5;
		checkBox_5.Text = Class16.smethod_0(1649057574);
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_5.CheckedChanged += checkBox_20_CheckedChanged;
		groupBox_1.Controls.Add(checkBox_6);
		groupBox_1.Controls.Add(checkBox_7);
		groupBox_1.Controls.Add(checkBox_8);
		groupBox_1.Controls.Add(checkBox_9);
		groupBox_1.Controls.Add(checkBox_10);
		groupBox_1.Controls.Add(checkBox_11);
		groupBox_1.Controls.Add(checkBox_12);
		groupBox_1.Controls.Add(checkBox_13);
		groupBox_1.Controls.Add(checkBox_14);
		groupBox_1.Location = new Point(268, 12);
		groupBox_1.Name = Class16.smethod_0(1649057600);
		groupBox_1.Size = new Size(162, 266);
		groupBox_1.TabIndex = 1;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1649057625);
		checkBox_6.AutoSize = true;
		checkBox_6.Location = new Point(15, 20);
		checkBox_6.Name = Class16.smethod_0(1649057642);
		checkBox_6.Size = new Size(92, 21);
		checkBox_6.TabIndex = 0;
		checkBox_6.Text = Class16.smethod_0(1649057679);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_6.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_7.AutoSize = true;
		checkBox_7.Location = new Point(15, 45);
		checkBox_7.Name = Class16.smethod_0(1649057688);
		checkBox_7.Size = new Size(92, 21);
		checkBox_7.TabIndex = 1;
		checkBox_7.Text = Class16.smethod_0(1649057725);
		checkBox_7.UseVisualStyleBackColor = true;
		checkBox_7.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_8.AutoSize = true;
		checkBox_8.Location = new Point(15, 70);
		checkBox_8.Name = Class16.smethod_0(1649057742);
		checkBox_8.Size = new Size(92, 21);
		checkBox_8.TabIndex = 2;
		checkBox_8.Text = Class16.smethod_0(1649057763);
		checkBox_8.UseVisualStyleBackColor = true;
		checkBox_8.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_9.AutoSize = true;
		checkBox_9.Location = new Point(15, 95);
		checkBox_9.Name = Class16.smethod_0(1649057788);
		checkBox_9.Size = new Size(85, 21);
		checkBox_9.TabIndex = 3;
		checkBox_9.Text = Class16.smethod_0(1649056788);
		checkBox_9.UseVisualStyleBackColor = true;
		checkBox_9.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_10.AutoSize = true;
		checkBox_10.Location = new Point(15, 120);
		checkBox_10.Name = Class16.smethod_0(1649056804);
		checkBox_10.Size = new Size(85, 21);
		checkBox_10.TabIndex = 4;
		checkBox_10.Text = Class16.smethod_0(1649056828);
		checkBox_10.UseVisualStyleBackColor = true;
		checkBox_10.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_11.AutoSize = true;
		checkBox_11.Location = new Point(15, 145);
		checkBox_11.Name = Class16.smethod_0(1649056844);
		checkBox_11.Size = new Size(85, 21);
		checkBox_11.TabIndex = 5;
		checkBox_11.Text = Class16.smethod_0(1649056868);
		checkBox_11.UseVisualStyleBackColor = true;
		checkBox_11.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_12.AutoSize = true;
		checkBox_12.Location = new Point(15, 170);
		checkBox_12.Name = Class16.smethod_0(1649056884);
		checkBox_12.Size = new Size(78, 21);
		checkBox_12.TabIndex = 6;
		checkBox_12.Text = Class16.smethod_0(1649056908);
		checkBox_12.UseVisualStyleBackColor = true;
		checkBox_12.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_13.AutoSize = true;
		checkBox_13.Location = new Point(15, 195);
		checkBox_13.Name = Class16.smethod_0(1649056915);
		checkBox_13.Size = new Size(78, 21);
		checkBox_13.TabIndex = 7;
		checkBox_13.Text = Class16.smethod_0(1649056939);
		checkBox_13.UseVisualStyleBackColor = true;
		checkBox_13.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_14.AutoSize = true;
		checkBox_14.Location = new Point(15, 220);
		checkBox_14.Name = Class16.smethod_0(1649056954);
		checkBox_14.Size = new Size(78, 21);
		checkBox_14.TabIndex = 8;
		checkBox_14.Text = Class16.smethod_0(1649056978);
		checkBox_14.UseVisualStyleBackColor = true;
		checkBox_14.CheckedChanged += checkBox_20_CheckedChanged;
		groupBox_2.Controls.Add(checkBox_15);
		groupBox_2.Controls.Add(checkBox_16);
		groupBox_2.Controls.Add(checkBox_17);
		groupBox_2.Controls.Add(checkBox_18);
		groupBox_2.Controls.Add(checkBox_19);
		groupBox_2.Controls.Add(checkBox_20);
		groupBox_2.Location = new Point(450, 12);
		groupBox_2.Name = Class16.smethod_0(1649056993);
		groupBox_2.Size = new Size(150, 180);
		groupBox_2.TabIndex = 2;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1649057011);
		checkBox_15.AutoSize = true;
		checkBox_15.Location = new Point(15, 20);
		checkBox_15.Name = Class16.smethod_0(1649057029);
		checkBox_15.Size = new Size(103, 21);
		checkBox_15.TabIndex = 0;
		checkBox_15.Text = Class16.smethod_0(1649057040);
		checkBox_15.UseVisualStyleBackColor = true;
		checkBox_15.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_16.AutoSize = true;
		checkBox_16.Location = new Point(15, 45);
		checkBox_16.Name = Class16.smethod_0(1649057068);
		checkBox_16.Size = new Size(103, 21);
		checkBox_16.TabIndex = 1;
		checkBox_16.Text = Class16.smethod_0(1649057087);
		checkBox_16.UseVisualStyleBackColor = true;
		checkBox_16.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_17.AutoSize = true;
		checkBox_17.Location = new Point(15, 70);
		checkBox_17.Name = Class16.smethod_0(1649057099);
		checkBox_17.Size = new Size(103, 21);
		checkBox_17.TabIndex = 2;
		checkBox_17.Text = Class16.smethod_0(1649057126);
		checkBox_17.UseVisualStyleBackColor = true;
		checkBox_17.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_18.AutoSize = true;
		checkBox_18.Location = new Point(15, 95);
		checkBox_18.Name = Class16.smethod_0(1649057138);
		checkBox_18.Size = new Size(110, 21);
		checkBox_18.TabIndex = 3;
		checkBox_18.Text = Class16.smethod_0(1649057165);
		checkBox_18.UseVisualStyleBackColor = true;
		checkBox_18.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_19.AutoSize = true;
		checkBox_19.Location = new Point(15, 120);
		checkBox_19.Name = Class16.smethod_0(1649057178);
		checkBox_19.Size = new Size(110, 21);
		checkBox_19.TabIndex = 4;
		checkBox_19.Text = Class16.smethod_0(1649057205);
		checkBox_19.UseVisualStyleBackColor = true;
		checkBox_19.CheckedChanged += checkBox_20_CheckedChanged;
		checkBox_20.AutoSize = true;
		checkBox_20.Location = new Point(15, 145);
		checkBox_20.Name = Class16.smethod_0(1649057218);
		checkBox_20.Size = new Size(110, 21);
		checkBox_20.TabIndex = 5;
		checkBox_20.Text = Class16.smethod_0(1649057245);
		checkBox_20.UseVisualStyleBackColor = true;
		checkBox_20.CheckedChanged += checkBox_20_CheckedChanged;
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(7f, 17f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_3;
		base.ClientSize = new Size(620, 435);
		base.Controls.Add(button_3);
		base.Controls.Add(button_2);
		base.Controls.Add(button_1);
		base.Controls.Add(label_0);
		base.Controls.Add(button_0);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(groupBox_1);
		base.Controls.Add(groupBox_2);
		Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.edit;
		base.Margin = new Padding(4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649057258);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649056258);
		((ISupportInitialize)numericUpDown_0).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		groupBox_2.ResumeLayout(performLayout: false);
		groupBox_2.PerformLayout();
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
			int num = (int)numericUpDown_0.Value;
			button_1_Click(null, null);
			if (num >= 524288)
			{
				checkBox_20.Checked = true;
				num -= 524288;
			}
			else if (num >= 262144)
			{
				checkBox_19.Checked = true;
				num -= 262144;
			}
			else if (num >= 131072)
			{
				checkBox_18.Checked = true;
				num -= 131072;
			}
			else if (num >= 65536)
			{
				checkBox_17.Checked = true;
				num -= 65536;
			}
			else if (num >= 32768)
			{
				checkBox_16.Checked = true;
				num -= 32768;
			}
			else if (num >= 16384)
			{
				checkBox_15.Checked = true;
				num -= 16384;
			}
			if (num >= 4096)
			{
				checkBox_6.Checked = true;
				num -= 4096;
			}
			else if (num >= 2048)
			{
				checkBox_7.Checked = true;
				num -= 2048;
			}
			else if (num >= 1024)
			{
				checkBox_8.Checked = true;
				num -= 1024;
			}
			else if (num >= 512)
			{
				checkBox_9.Checked = true;
				num -= 512;
			}
			else if (num >= 256)
			{
				checkBox_10.Checked = true;
				num -= 256;
			}
			else if (num >= 128)
			{
				checkBox_11.Checked = true;
				num -= 128;
			}
			else if (num >= 64)
			{
				checkBox_12.Checked = true;
				num -= 64;
			}
			else if (num >= 32)
			{
				checkBox_13.Checked = true;
				num -= 32;
			}
			else if (num >= 16)
			{
				checkBox_14.Checked = true;
				num -= 16;
			}
			switch (num)
			{
			case 15:
				checkBox_5.Checked = true;
				break;
			case 9:
				checkBox_4.Checked = true;
				break;
			case 3:
				checkBox_3.Checked = true;
				break;
			case 2:
				checkBox_2.Checked = true;
				break;
			case 1:
				checkBox_1.Checked = true;
				break;
			case 0:
				checkBox_0.Checked = true;
				break;
			}
			lockCheckBox = false;
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		Close();
	}
}
