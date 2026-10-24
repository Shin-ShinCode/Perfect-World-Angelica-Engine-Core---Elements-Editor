using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.Elements;

public class LinkingWindow : Form
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

	private Button button_1;

	private ToolTip toolTip_0;

	private Button button_2;

	private Button button_3;

	private IContainer icontainer_0;

	public LinkingWindow(string mask, CommonStorage ref_CStorage)
	{
		try
		{
			commonStorage_0 = ref_CStorage;
			method_2();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			if (commonStorage_0.elVersion <= 12)
			{
				int num = 8;
				do
				{
					int num2 = num;
					string text = Class16.smethod_0(1648986432);
					((CheckBox)base.Controls[text + num2]).Enabled = false;
					num++;
				}
				while (num <= 15);
			}
			checkBox_15.Enabled = true;
			numericUpDown_0.Text = mask;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private int method_0(int int_0, int int_1)
	{
		int result = (int)Math.Pow(int_0, int_1);
		GC.KeepAlive(this);
		return result;
	}

	private void checkBox_15_CheckedChanged(object sender, EventArgs e)
	{
		if (!lockCheckBox)
		{
			lockCheckBox = true;
			int num = 0;
			num = (checkBox_0.Checked ? 1 : num);
			if (checkBox_1.Checked)
			{
				num += 2;
			}
			if (checkBox_2.Checked)
			{
				num += 4;
			}
			if (checkBox_3.Checked)
			{
				num += 8;
			}
			if (checkBox_6.Checked)
			{
				num += 16;
			}
			if (checkBox_7.Checked)
			{
				num += 32;
			}
			if (checkBox_4.Checked)
			{
				num += 64;
			}
			if (checkBox_5.Checked)
			{
				num = method_0(2, 15) + num;
			}
			if (checkBox_14.Checked)
			{
				num += 128;
			}
			if (checkBox_15.Checked)
			{
				num += 256;
			}
			if (checkBox_12.Checked)
			{
				num += 512;
			}
			if (checkBox_13.Checked)
			{
				num += 1024;
			}
			if (checkBox_10.Checked)
			{
				num = method_0(2, 11) + num;
			}
			if (checkBox_11.Checked)
			{
				num = method_0(2, 12) + num;
			}
			if (checkBox_8.Checked)
			{
				num = method_0(2, 13) + num;
			}
			if (checkBox_9.Checked)
			{
				num = method_0(2, 14) + num;
			}
			decimal value = Convert.ToDecimal(num);
			numericUpDown_0.Value = value;
			lockCheckBox = false;
		}
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
			CheckBox checkBox = (CheckBox)base.Controls[text + num2];
			checkBox.Checked = checkBox.Enabled;
			num++;
		}
		while (num <= 16);
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		checkBox_0.Checked = false;
		checkBox_1.Checked = false;
		checkBox_2.Checked = false;
		checkBox_3.Checked = false;
		checkBox_6.Checked = false;
		checkBox_7.Checked = false;
		checkBox_4.Checked = false;
		checkBox_5.Checked = false;
		checkBox_14.Checked = false;
		checkBox_15.Checked = false;
		checkBox_12.Checked = false;
		checkBox_13.Checked = false;
		checkBox_10.Checked = false;
		checkBox_11.Checked = false;
		checkBox_8.Checked = false;
		checkBox_9.Checked = false;
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(LinkingWindow));
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
		checkBox_8 = new CheckBox();
		checkBox_9 = new CheckBox();
		checkBox_10 = new CheckBox();
		checkBox_11 = new CheckBox();
		checkBox_12 = new CheckBox();
		checkBox_13 = new CheckBox();
		checkBox_14 = new CheckBox();
		checkBox_15 = new CheckBox();
		button_1 = new Button();
		button_2 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		button_3 = new Button();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		SuspendLayout();
		numericUpDown_0.BackColor = Color.White;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_0.ForeColor = Color.Black;
		numericUpDown_0.Location = new Point(75, 203);
		numericUpDown_0.Margin = new Padding(4);
		numericUpDown_0.Maximum = new decimal(new int[4] { 65535, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648988480);
		numericUpDown_0.Size = new Size(176, 22);
		numericUpDown_0.TabIndex = 10;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.OK;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.LinkingWindow_cmdok;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(4, 232);
		button_0.Name = Class16.smethod_0(1648925748);
		button_0.Size = new Size(183, 32);
		button_0.TabIndex = 11;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648988505);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.Location = new Point(10, 203);
		label_0.Name = Class16.smethod_0(1648912083);
		label_0.Size = new Size(46, 20);
		label_0.TabIndex = 12;
		label_0.Text = Class16.smethod_0(1648988522);
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(13, 13);
		checkBox_0.Margin = new Padding(4);
		checkBox_0.Name = Class16.smethod_0(1648981711);
		checkBox_0.Size = new Size(132, 21);
		checkBox_0.TabIndex = 13;
		checkBox_0.Text = Class16.smethod_0(1648975260);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_1.AutoSize = true;
		checkBox_1.Location = new Point(13, 36);
		checkBox_1.Margin = new Padding(4);
		checkBox_1.Name = Class16.smethod_0(1648981740);
		checkBox_1.Size = new Size(112, 21);
		checkBox_1.TabIndex = 14;
		checkBox_1.Text = Class16.smethod_0(1648975275);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_2.AutoSize = true;
		checkBox_2.Location = new Point(13, 59);
		checkBox_2.Margin = new Padding(4);
		checkBox_2.Name = Class16.smethod_0(1648981652);
		checkBox_2.Size = new Size(116, 21);
		checkBox_2.TabIndex = 15;
		checkBox_2.Text = Class16.smethod_0(1648975296);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_2.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_3.AutoSize = true;
		checkBox_3.Location = new Point(13, 82);
		checkBox_3.Margin = new Padding(4);
		checkBox_3.Name = Class16.smethod_0(1648981675);
		checkBox_3.Size = new Size(113, 21);
		checkBox_3.TabIndex = 16;
		checkBox_3.Text = Class16.smethod_0(1648975325);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_3.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(13, 151);
		checkBox_4.Margin = new Padding(4);
		checkBox_4.Name = Class16.smethod_0(1648986455);
		checkBox_4.Size = new Size(93, 21);
		checkBox_4.TabIndex = 19;
		checkBox_4.Text = Class16.smethod_0(1648975337);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_4.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_5.AutoSize = true;
		checkBox_5.Location = new Point(13, 174);
		checkBox_5.Margin = new Padding(4);
		checkBox_5.Name = Class16.smethod_0(1648981794);
		checkBox_5.Size = new Size(100, 21);
		checkBox_5.TabIndex = 20;
		checkBox_5.Text = Class16.smethod_0(1648975355);
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_5.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_6.AutoSize = true;
		checkBox_6.Location = new Point(13, 105);
		checkBox_6.Margin = new Padding(4);
		checkBox_6.Name = Class16.smethod_0(1648981596);
		checkBox_6.Size = new Size(154, 21);
		checkBox_6.TabIndex = 17;
		checkBox_6.Text = Class16.smethod_0(1648974359);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_6.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_7.AutoSize = true;
		checkBox_7.Location = new Point(13, 128);
		checkBox_7.Margin = new Padding(4);
		checkBox_7.Name = Class16.smethod_0(1648981616);
		checkBox_7.Size = new Size(147, 21);
		checkBox_7.TabIndex = 18;
		checkBox_7.Text = Class16.smethod_0(1648974377);
		checkBox_7.UseVisualStyleBackColor = true;
		checkBox_7.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_8.AutoSize = true;
		checkBox_8.Location = new Point(171, 151);
		checkBox_8.Margin = new Padding(4);
		checkBox_8.Name = Class16.smethod_0(1648986485);
		checkBox_8.Size = new Size(124, 21);
		checkBox_8.TabIndex = 27;
		checkBox_8.Text = Class16.smethod_0(1648974402);
		checkBox_8.UseVisualStyleBackColor = true;
		checkBox_8.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_9.AutoSize = true;
		checkBox_9.Location = new Point(171, 174);
		checkBox_9.Margin = new Padding(4);
		checkBox_9.Name = Class16.smethod_0(1648981767);
		checkBox_9.Size = new Size(206, 21);
		checkBox_9.TabIndex = 28;
		checkBox_9.Text = Class16.smethod_0(1648974425);
		checkBox_9.UseVisualStyleBackColor = true;
		checkBox_9.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_10.AutoSize = true;
		checkBox_10.Location = new Point(171, 105);
		checkBox_10.Margin = new Padding(4);
		checkBox_10.Name = Class16.smethod_0(1648986518);
		checkBox_10.Size = new Size(104, 21);
		checkBox_10.TabIndex = 25;
		checkBox_10.Text = Class16.smethod_0(1648974470);
		toolTip_0.SetToolTip(checkBox_10, Class16.smethod_0(1648974483));
		checkBox_10.UseVisualStyleBackColor = true;
		checkBox_10.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_11.AutoSize = true;
		checkBox_11.Location = new Point(171, 128);
		checkBox_11.Margin = new Padding(4);
		checkBox_11.Name = Class16.smethod_0(1648986544);
		checkBox_11.Size = new Size(141, 21);
		checkBox_11.TabIndex = 26;
		checkBox_11.Text = Class16.smethod_0(1648974558);
		checkBox_11.UseVisualStyleBackColor = true;
		checkBox_11.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_12.AutoSize = true;
		checkBox_12.Location = new Point(171, 59);
		checkBox_12.Margin = new Padding(4);
		checkBox_12.Name = Class16.smethod_0(1648986582);
		checkBox_12.Size = new Size(123, 21);
		checkBox_12.TabIndex = 23;
		checkBox_12.Text = Class16.smethod_0(1648974583);
		checkBox_12.UseVisualStyleBackColor = true;
		checkBox_12.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_13.AutoSize = true;
		checkBox_13.Location = new Point(171, 82);
		checkBox_13.Margin = new Padding(4);
		checkBox_13.Name = Class16.smethod_0(1648986612);
		checkBox_13.Size = new Size(157, 21);
		checkBox_13.TabIndex = 24;
		checkBox_13.Text = Class16.smethod_0(1648974605);
		checkBox_13.UseVisualStyleBackColor = true;
		checkBox_13.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_14.AutoSize = true;
		checkBox_14.Location = new Point(171, 13);
		checkBox_14.Margin = new Padding(4);
		checkBox_14.Name = Class16.smethod_0(1648981514);
		checkBox_14.Size = new Size(148, 21);
		checkBox_14.TabIndex = 21;
		checkBox_14.Text = Class16.smethod_0(1648974626);
		checkBox_14.UseVisualStyleBackColor = true;
		checkBox_14.CheckedChanged += checkBox_15_CheckedChanged;
		checkBox_15.AutoSize = true;
		checkBox_15.Location = new Point(171, 36);
		checkBox_15.Margin = new Padding(4);
		checkBox_15.Name = Class16.smethod_0(1648981550);
		checkBox_15.Size = new Size(177, 21);
		checkBox_15.TabIndex = 22;
		checkBox_15.Text = Class16.smethod_0(1648974660);
		checkBox_15.UseVisualStyleBackColor = true;
		checkBox_15.CheckedChanged += checkBox_15_CheckedChanged;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_1.ForeColor = Color.FromArgb(192, 0, 0);
		button_1.Location = new Point(258, 203);
		button_1.Name = Class16.smethod_0(1648988562);
		button_1.Size = new Size(55, 22);
		button_1.TabIndex = 29;
		button_1.Text = Class16.smethod_0(1648988590);
		toolTip_0.SetToolTip(button_1, Class16.smethod_0(1648977778));
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_2.ForeColor = Color.Blue;
		button_2.Location = new Point(319, 203);
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
		button_3.Image = Resources.LinkingWindow_cmdcancel;
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(191, 232);
		button_3.Name = Class16.smethod_0(1648925752);
		button_3.Size = new Size(183, 32);
		button_3.TabIndex = 31;
		button_3.TabStop = false;
		button_3.Text = Class16.smethod_0(1648989215);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(7f, 17f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_3;
		base.ClientSize = new Size(378, 269);
		base.Controls.Add(button_3);
		base.Controls.Add(button_2);
		base.Controls.Add(button_1);
		base.Controls.Add(checkBox_8);
		base.Controls.Add(checkBox_9);
		base.Controls.Add(checkBox_10);
		base.Controls.Add(checkBox_11);
		base.Controls.Add(checkBox_12);
		base.Controls.Add(checkBox_13);
		base.Controls.Add(checkBox_14);
		base.Controls.Add(checkBox_15);
		base.Controls.Add(checkBox_4);
		base.Controls.Add(checkBox_5);
		base.Controls.Add(checkBox_6);
		base.Controls.Add(checkBox_7);
		base.Controls.Add(checkBox_2);
		base.Controls.Add(checkBox_3);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(checkBox_1);
		base.Controls.Add(label_0);
		base.Controls.Add(button_0);
		base.Controls.Add(numericUpDown_0);
		Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.LinkingWindow_Icon;
		base.Margin = new Padding(4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648974693);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648974705);
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

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (!lockCheckBox)
		{
			lockCheckBox = true;
			int num = (int)numericUpDown_0.Value;
			button_1_Click(null, null);
			if (num / method_0(2, 15) > 0)
			{
				num %= method_0(2, 15);
				checkBox_5.Checked = true;
			}
			if (num / method_0(2, 14) > 0)
			{
				num %= method_0(2, 14);
				checkBox_9.Checked = true;
			}
			if (num / method_0(2, 13) > 0)
			{
				num %= method_0(2, 13);
				checkBox_8.Checked = true;
			}
			if (num / method_0(2, 12) > 0)
			{
				num %= method_0(2, 12);
				checkBox_11.Checked = true;
			}
			if (num / method_0(2, 11) > 0)
			{
				num %= method_0(2, 11);
				checkBox_10.Checked = true;
			}
			if (num / 1024 > 0)
			{
				num %= 1024;
				checkBox_13.Checked = true;
			}
			if (num / 512 > 0)
			{
				num %= 512;
				checkBox_12.Checked = true;
			}
			if (num / 256 > 0)
			{
				num %= 256;
				checkBox_15.Checked = true;
			}
			if (num / 128 > 0)
			{
				num %= 128;
				checkBox_14.Checked = true;
			}
			if (num / 64 > 0)
			{
				num %= 64;
				checkBox_4.Checked = true;
			}
			if (num / 32 > 0)
			{
				num %= 32;
				checkBox_7.Checked = true;
			}
			if (num / 16 > 0)
			{
				num %= 16;
				checkBox_6.Checked = true;
			}
			if (num / 8 > 0)
			{
				num %= 8;
				checkBox_3.Checked = true;
			}
			if (num / 4 > 0)
			{
				num %= 4;
				checkBox_2.Checked = true;
			}
			if (num / 2 > 0)
			{
				num %= 2;
				checkBox_1.Checked = true;
			}
			if (num > 0)
			{
				checkBox_0.Checked = true;
			}
			lockCheckBox = false;
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		Close();
	}
}
