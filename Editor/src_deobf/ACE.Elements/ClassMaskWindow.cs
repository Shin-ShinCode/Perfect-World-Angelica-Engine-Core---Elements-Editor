using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.Elements;

public class ClassMaskWindow : Form
{
	private CommonStorage commonStorage_0;

	protected bool lockCheckBox;

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

	private NumericUpDown numericUpDown_0;

	public Label label1;

	private Button button_0;

	private Label label_0;

	private Button button_1;

	private Button button_2;

	private CheckBox checkBox_10;

	private CheckBox checkBox_11;

	private CheckBox checkBox_12;

	private CheckBox checkBox_13;

	public Container components;

	public ClassMaskWindow(string mask, CommonStorage ref_CStorage)
	{
		try
		{
			commonStorage_0 = ref_CStorage;
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this, null);
			decimal value = Convert.ToDecimal(mask);
			numericUpDown_0.Value = value;
			lockCheckBox = false;
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		lockCheckBox = true;
		ushort num = (ushort)Convert.ToInt16(numericUpDown_0.Value);
		if ((ushort)(num & 0xE000) != 0)
		{
			num %= 8192;
			checkBox_12.Checked = true;
		}
		else
		{
			checkBox_12.Checked = false;
		}
		if ((ushort)(num & 0xF000) != 0)
		{
			num %= 4096;
			checkBox_13.Checked = true;
		}
		else
		{
			checkBox_13.Checked = false;
		}
		if ((ushort)(num & 0xF800) != 0)
		{
			num %= 2048;
			checkBox_10.Checked = true;
		}
		else
		{
			checkBox_10.Checked = false;
		}
		if ((ushort)(num & 0xFC00) != 0)
		{
			num %= 1024;
			checkBox_11.Checked = true;
		}
		else
		{
			checkBox_11.Checked = false;
		}
		if ((ushort)(num & 0xFE00) != 0)
		{
			num %= 512;
			checkBox_9.Checked = true;
		}
		else
		{
			checkBox_9.Checked = false;
		}
		if ((ushort)(num & 0xFF00) != 0)
		{
			num %= 256;
			checkBox_8.Checked = true;
		}
		else
		{
			checkBox_8.Checked = false;
		}
		if ((ushort)(num & 0xFF80) != 0)
		{
			num %= 128;
			checkBox_7.Checked = true;
		}
		else
		{
			checkBox_7.Checked = false;
		}
		if ((ushort)(num & 0xFFC0) != 0)
		{
			num %= 64;
			checkBox_6.Checked = true;
		}
		else
		{
			checkBox_6.Checked = false;
		}
		if ((ushort)(num & 0xFFE0) != 0)
		{
			num %= 32;
			checkBox_5.Checked = true;
		}
		else
		{
			checkBox_5.Checked = false;
		}
		if ((ushort)(num & 0xFFF0) != 0)
		{
			num %= 16;
			checkBox_4.Checked = true;
		}
		else
		{
			checkBox_4.Checked = false;
		}
		if ((ushort)(num & 0xFFF8) != 0)
		{
			num %= 8;
			checkBox_3.Checked = true;
		}
		else
		{
			checkBox_3.Checked = false;
		}
		if ((ushort)(num & 0xFFFC) != 0)
		{
			num %= 4;
			checkBox_2.Checked = true;
		}
		else
		{
			checkBox_2.Checked = false;
		}
		if ((ushort)(num & 0xFFFE) != 0)
		{
			num %= 2;
			checkBox_1.Checked = true;
		}
		else
		{
			checkBox_1.Checked = false;
		}
		if (num != 0)
		{
			checkBox_0.Checked = true;
		}
		else
		{
			checkBox_0.Checked = false;
		}
		lockCheckBox = false;
	}

	private void method_0()
	{
		((IDisposable)components)?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		new ComponentResourceManager(typeof(ClassMaskWindow));
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
		numericUpDown_0 = new NumericUpDown();
		button_0 = new Button();
		label_0 = new Label();
		button_1 = new Button();
		button_2 = new Button();
		checkBox_10 = new CheckBox();
		checkBox_11 = new CheckBox();
		checkBox_12 = new CheckBox();
		checkBox_13 = new CheckBox();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		SuspendLayout();
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(19, 11);
		checkBox_0.Margin = new Padding(4);
		checkBox_0.Name = Class16.smethod_0(1648988213);
		checkBox_0.Size = new Size(71, 21);
		checkBox_0.TabIndex = 0;
		checkBox_0.Text = Class16.smethod_0(1648988231);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_1.AutoSize = true;
		checkBox_1.Location = new Point(163, 11);
		checkBox_1.Margin = new Padding(4);
		checkBox_1.Name = Class16.smethod_0(1648988245);
		checkBox_1.Size = new Size(61, 21);
		checkBox_1.TabIndex = 1;
		checkBox_1.Text = Class16.smethod_0(1648988256);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_2.AutoSize = true;
		checkBox_2.Location = new Point(163, 101);
		checkBox_2.Margin = new Padding(4);
		checkBox_2.Name = Class16.smethod_0(1648988267);
		checkBox_2.Size = new Size(73, 21);
		checkBox_2.TabIndex = 2;
		checkBox_2.Text = Class16.smethod_0(1648988294);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_2.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_3.AutoSize = true;
		checkBox_3.Location = new Point(163, 41);
		checkBox_3.Margin = new Padding(4);
		checkBox_3.Name = Class16.smethod_0(1648988299);
		checkBox_3.Size = new Size(59, 21);
		checkBox_3.TabIndex = 3;
		checkBox_3.Text = Class16.smethod_0(1648988326);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_3.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(19, 41);
		checkBox_4.Margin = new Padding(4);
		checkBox_4.Name = Class16.smethod_0(1648988330);
		checkBox_4.Size = new Size(81, 21);
		checkBox_4.TabIndex = 4;
		checkBox_4.Text = Class16.smethod_0(1648988357);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_4.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_5.AutoSize = true;
		checkBox_5.Location = new Point(19, 101);
		checkBox_5.Margin = new Padding(4);
		checkBox_5.Name = Class16.smethod_0(1648988372);
		checkBox_5.Size = new Size(76, 21);
		checkBox_5.TabIndex = 5;
		checkBox_5.Text = Class16.smethod_0(1648995012);
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_5.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_6.AutoSize = true;
		checkBox_6.Location = new Point(19, 71);
		checkBox_6.Margin = new Padding(4);
		checkBox_6.Name = Class16.smethod_0(1648988390);
		checkBox_6.Size = new Size(65, 21);
		checkBox_6.TabIndex = 6;
		checkBox_6.Text = Class16.smethod_0(1648994331);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_6.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_7.AutoSize = true;
		checkBox_7.Location = new Point(163, 71);
		checkBox_7.Margin = new Padding(4);
		checkBox_7.Name = Class16.smethod_0(1648988400);
		checkBox_7.Size = new Size(59, 21);
		checkBox_7.TabIndex = 7;
		checkBox_7.Text = Class16.smethod_0(1648988419);
		checkBox_7.UseVisualStyleBackColor = true;
		checkBox_7.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_8.AutoSize = true;
		checkBox_8.Location = new Point(19, 131);
		checkBox_8.Margin = new Padding(4);
		checkBox_8.Name = Class16.smethod_0(1648988432);
		checkBox_8.Size = new Size(63, 21);
		checkBox_8.TabIndex = 8;
		checkBox_8.Text = Class16.smethod_0(1648988450);
		checkBox_8.UseVisualStyleBackColor = true;
		checkBox_8.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_9.AutoSize = true;
		checkBox_9.Location = new Point(163, 131);
		checkBox_9.Margin = new Padding(4);
		checkBox_9.Name = Class16.smethod_0(1648988470);
		checkBox_9.Size = new Size(64, 21);
		checkBox_9.TabIndex = 9;
		checkBox_9.Text = Class16.smethod_0(1648995132);
		checkBox_9.UseVisualStyleBackColor = true;
		checkBox_9.CheckedChanged += checkBox_13_CheckedChanged;
		numericUpDown_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_0.Location = new Point(62, 219);
		numericUpDown_0.Margin = new Padding(4);
		numericUpDown_0.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648988480);
		numericUpDown_0.Size = new Size(75, 22);
		numericUpDown_0.TabIndex = 10;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_0.AutoSize = true;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.ClassMaskWindow_cmdok;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(7, 246);
		button_0.Name = Class16.smethod_0(1648925748);
		button_0.Size = new Size(287, 27);
		button_0.TabIndex = 11;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648988505);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		label_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.Location = new Point(4, 219);
		label_0.Name = Class16.smethod_0(1648912083);
		label_0.Size = new Size(46, 20);
		label_0.TabIndex = 12;
		label_0.Text = Class16.smethod_0(1648988522);
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_1.ForeColor = Color.Blue;
		button_1.Location = new Point(220, 219);
		button_1.Name = Class16.smethod_0(1648988542);
		button_1.Size = new Size(72, 22);
		button_1.TabIndex = 32;
		button_1.Text = Class16.smethod_0(1648988552);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_2.ForeColor = Color.FromArgb(192, 0, 0);
		button_2.Location = new Point(144, 219);
		button_2.Name = Class16.smethod_0(1648988562);
		button_2.Size = new Size(70, 22);
		button_2.TabIndex = 31;
		button_2.Text = Class16.smethod_0(1648988590);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		checkBox_10.AutoSize = true;
		checkBox_10.Location = new Point(163, 160);
		checkBox_10.Margin = new Padding(4);
		checkBox_10.Name = Class16.smethod_0(1648988604);
		checkBox_10.Size = new Size(83, 21);
		checkBox_10.TabIndex = 34;
		checkBox_10.Text = Class16.smethod_0(1648988616);
		checkBox_10.UseVisualStyleBackColor = true;
		checkBox_10.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_11.AutoSize = true;
		checkBox_11.Location = new Point(19, 160);
		checkBox_11.Margin = new Padding(4);
		checkBox_11.Name = Class16.smethod_0(1648988632);
		checkBox_11.Size = new Size(61, 21);
		checkBox_11.TabIndex = 33;
		checkBox_11.Text = Class16.smethod_0(1648988660);
		checkBox_11.UseVisualStyleBackColor = true;
		checkBox_11.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_12.AutoSize = true;
		checkBox_12.Location = new Point(163, 189);
		checkBox_12.Margin = new Padding(4);
		checkBox_12.Name = Class16.smethod_0(1648988664);
		checkBox_12.Size = new Size(108, 21);
		checkBox_12.TabIndex = 36;
		checkBox_12.Text = Class16.smethod_0(1648991764);
		checkBox_12.UseVisualStyleBackColor = true;
		checkBox_12.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_13.AutoSize = true;
		checkBox_13.Location = new Point(19, 189);
		checkBox_13.Margin = new Padding(4);
		checkBox_13.Name = Class16.smethod_0(1648991778);
		checkBox_13.Size = new Size(112, 21);
		checkBox_13.TabIndex = 35;
		checkBox_13.Text = Class16.smethod_0(1648991806);
		checkBox_13.UseVisualStyleBackColor = true;
		checkBox_13.CheckedChanged += checkBox_13_CheckedChanged;
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(7f, 17f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(297, 276);
		base.Controls.Add(checkBox_12);
		base.Controls.Add(checkBox_13);
		base.Controls.Add(checkBox_10);
		base.Controls.Add(checkBox_11);
		base.Controls.Add(button_1);
		base.Controls.Add(button_2);
		base.Controls.Add(label_0);
		base.Controls.Add(button_0);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(checkBox_9);
		base.Controls.Add(checkBox_8);
		base.Controls.Add(checkBox_7);
		base.Controls.Add(checkBox_6);
		base.Controls.Add(checkBox_5);
		base.Controls.Add(checkBox_3);
		base.Controls.Add(checkBox_2);
		base.Controls.Add(checkBox_1);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(checkBox_4);
		Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.ClassMaskWindow_Icon;
		base.Margin = new Padding(4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648991828);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648991842);
		base.Load += ClassMaskWindow_Load;
		base.LocationChanged += ClassMaskWindow_LocationChanged;
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

	private void checkBox_13_CheckedChanged(object sender, EventArgs e)
	{
		if (!lockCheckBox)
		{
			ushort num = 0;
			num = (ushort)(checkBox_0.Checked ? 1 : num);
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
			if (checkBox_4.Checked)
			{
				num += 16;
			}
			if (checkBox_5.Checked)
			{
				num += 32;
			}
			if (checkBox_6.Checked)
			{
				num += 64;
			}
			if (checkBox_7.Checked)
			{
				num += 128;
			}
			if (checkBox_8.Checked)
			{
				num += 256;
			}
			if (checkBox_9.Checked)
			{
				num += 512;
			}
			if (checkBox_11.Checked)
			{
				num += 1024;
			}
			if (checkBox_10.Checked)
			{
				num += 2048;
			}
			if (checkBox_13.Checked)
			{
				num += 4096;
			}
			if (checkBox_12.Checked)
			{
				num += 8192;
			}
			decimal value = Convert.ToDecimal(num);
			numericUpDown_0.Value = value;
		}
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (commonStorage_0 != null)
		{
			CommonStorage.sData = numericUpDown_0.Value.ToString();
		}
		Close();
	}

	private void ClassMaskWindow_Load(object sender, EventArgs e)
	{
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		checkBox_0.Checked = true;
		checkBox_4.Checked = true;
		checkBox_6.Checked = true;
		checkBox_5.Checked = true;
		checkBox_8.Checked = true;
		checkBox_1.Checked = true;
		checkBox_3.Checked = true;
		checkBox_7.Checked = true;
		checkBox_2.Checked = true;
		checkBox_9.Checked = true;
		checkBox_11.Checked = true;
		checkBox_10.Checked = true;
		checkBox_13.Checked = true;
		checkBox_12.Checked = true;
		GC.KeepAlive(this);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		checkBox_0.Checked = false;
		checkBox_4.Checked = false;
		checkBox_6.Checked = false;
		checkBox_5.Checked = false;
		checkBox_8.Checked = false;
		checkBox_1.Checked = false;
		checkBox_3.Checked = false;
		checkBox_7.Checked = false;
		checkBox_2.Checked = false;
		checkBox_9.Checked = false;
		checkBox_11.Checked = false;
		checkBox_10.Checked = false;
		checkBox_13.Checked = false;
		checkBox_12.Checked = false;
		GC.KeepAlive(this);
	}

	private void ClassMaskWindow_LocationChanged(object sender, EventArgs e)
	{
	}
}
