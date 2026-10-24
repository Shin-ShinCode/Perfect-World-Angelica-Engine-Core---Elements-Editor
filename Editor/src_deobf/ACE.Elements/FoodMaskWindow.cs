using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.Elements;

public class FoodMaskWindow : Form
{
	private CommonStorage commonStorage_0;

	protected bool lockCheckBox;

	private NumericUpDown numericUpDown_0;

	public Label label1;

	private Button button_0;

	private Label label_0;

	private Button button_1;

	private ToolTip toolTip_0;

	private Button button_2;

	private Button button_3;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private IContainer icontainer_0;

	public FoodMaskWindow(string mask, CommonStorage ref_CStorage)
	{
		try
		{
			commonStorage_0 = ref_CStorage;
			method_2();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this, null);
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

	private void checkBox_4_CheckedChanged(object sender, EventArgs e)
	{
		if (!lockCheckBox)
		{
			lockCheckBox = true;
			int num = 0;
			num = (checkBox_3.Checked ? 1 : num);
			if (checkBox_4.Checked)
			{
				num += 2;
			}
			if (checkBox_1.Checked)
			{
				num += 4;
			}
			if (checkBox_2.Checked)
			{
				num += 8;
			}
			if (checkBox_0.Checked)
			{
				num += 16;
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
		checkBox_3.Checked = true;
		checkBox_4.Checked = true;
		checkBox_1.Checked = true;
		checkBox_2.Checked = true;
		checkBox_0.Checked = true;
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		checkBox_3.Checked = false;
		checkBox_4.Checked = false;
		checkBox_1.Checked = false;
		checkBox_2.Checked = false;
		checkBox_0.Checked = false;
		GC.KeepAlive(this);
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (!lockCheckBox)
		{
			lockCheckBox = true;
			int num = (int)numericUpDown_0.Value;
			button_1_Click(null, null);
			if (num / 16 > 0)
			{
				num %= 16;
				checkBox_0.Checked = true;
			}
			if (num / 8 > 0)
			{
				num %= 8;
				checkBox_2.Checked = true;
			}
			if (num / 4 > 0)
			{
				num %= 4;
				checkBox_1.Checked = true;
			}
			if (num / 2 > 0)
			{
				num %= 2;
				checkBox_4.Checked = true;
			}
			if (num > 0)
			{
				checkBox_3.Checked = true;
			}
			lockCheckBox = false;
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void method_1()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(FoodMaskWindow));
		numericUpDown_0 = new NumericUpDown();
		button_0 = new Button();
		label_0 = new Label();
		button_1 = new Button();
		button_2 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		button_3 = new Button();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		checkBox_3 = new CheckBox();
		checkBox_4 = new CheckBox();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		SuspendLayout();
		numericUpDown_0.BackColor = Color.White;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_0.ForeColor = Color.Black;
		numericUpDown_0.Location = new Point(70, 74);
		numericUpDown_0.Margin = new Padding(4);
		numericUpDown_0.Maximum = new decimal(new int[4] { 31, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648988480);
		numericUpDown_0.Size = new Size(57, 22);
		numericUpDown_0.TabIndex = 10;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.OK;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.FoodMaskWindow_cmdok;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(7, 103);
		button_0.Name = Class16.smethod_0(1648925748);
		button_0.Size = new Size(120, 32);
		button_0.TabIndex = 11;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648988505);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.Location = new Point(5, 74);
		label_0.Name = Class16.smethod_0(1648912083);
		label_0.Size = new Size(46, 20);
		label_0.TabIndex = 12;
		label_0.Text = Class16.smethod_0(1648988522);
		button_1.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_1.ForeColor = Color.FromArgb(192, 0, 0);
		button_1.Location = new Point(141, 74);
		button_1.Name = Class16.smethod_0(1648988562);
		button_1.Size = new Size(55, 22);
		button_1.TabIndex = 29;
		button_1.Text = Class16.smethod_0(1648988590);
		toolTip_0.SetToolTip(button_1, Class16.smethod_0(1648977778));
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_2.ForeColor = Color.Blue;
		button_2.Location = new Point(200, 74);
		button_2.Name = Class16.smethod_0(1648988542);
		button_2.Size = new Size(55, 22);
		button_2.TabIndex = 30;
		button_2.Text = Class16.smethod_0(1648988552);
		toolTip_0.SetToolTip(button_2, Class16.smethod_0(1648977807));
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.AutoSize = true;
		button_3.DialogResult = DialogResult.Cancel;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_3.Image = Resources.FoodMaskWindow_cmdcancel;
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(135, 103);
		button_3.Name = Class16.smethod_0(1648925752);
		button_3.Size = new Size(120, 32);
		button_3.TabIndex = 31;
		button_3.TabStop = false;
		button_3.Text = Class16.smethod_0(1648989215);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		checkBox_0.AutoSize = true;
		checkBox_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_0.ForeColor = Color.Black;
		checkBox_0.Location = new Point(155, 43);
		checkBox_0.Margin = new Padding(4);
		checkBox_0.Name = Class16.smethod_0(1648981596);
		checkBox_0.Size = new Size(80, 21);
		checkBox_0.TabIndex = 36;
		checkBox_0.Text = Class16.smethod_0(1648977818);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_4_CheckedChanged;
		checkBox_1.AutoSize = true;
		checkBox_1.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_1.ForeColor = Color.Black;
		checkBox_1.Location = new Point(155, 13);
		checkBox_1.Margin = new Padding(4);
		checkBox_1.Name = Class16.smethod_0(1648981652);
		checkBox_1.Size = new Size(91, 21);
		checkBox_1.TabIndex = 34;
		checkBox_1.Text = Class16.smethod_0(1648977834);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.CheckedChanged += checkBox_4_CheckedChanged;
		checkBox_2.AutoSize = true;
		checkBox_2.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_2.ForeColor = Color.Black;
		checkBox_2.Location = new Point(13, 43);
		checkBox_2.Margin = new Padding(4);
		checkBox_2.Name = Class16.smethod_0(1648981675);
		checkBox_2.Size = new Size(126, 21);
		checkBox_2.TabIndex = 35;
		checkBox_2.Text = Class16.smethod_0(1648977849);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_2.CheckedChanged += checkBox_4_CheckedChanged;
		checkBox_3.AutoSize = true;
		checkBox_3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_3.ForeColor = Color.Black;
		checkBox_3.Location = new Point(13, 13);
		checkBox_3.Margin = new Padding(4);
		checkBox_3.Name = Class16.smethod_0(1648981711);
		checkBox_3.Size = new Size(60, 21);
		checkBox_3.TabIndex = 32;
		checkBox_3.Text = Class16.smethod_0(1648977873);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_3.CheckedChanged += checkBox_4_CheckedChanged;
		checkBox_4.AutoSize = true;
		checkBox_4.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_4.ForeColor = Color.Black;
		checkBox_4.Location = new Point(86, 13);
		checkBox_4.Margin = new Padding(4);
		checkBox_4.Name = Class16.smethod_0(1648981740);
		checkBox_4.Size = new Size(57, 21);
		checkBox_4.TabIndex = 33;
		checkBox_4.Text = Class16.smethod_0(1648977893);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_4.CheckedChanged += checkBox_4_CheckedChanged;
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(7f, 17f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_3;
		base.ClientSize = new Size(261, 141);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(checkBox_1);
		base.Controls.Add(checkBox_2);
		base.Controls.Add(checkBox_3);
		base.Controls.Add(checkBox_4);
		base.Controls.Add(button_3);
		base.Controls.Add(button_2);
		base.Controls.Add(button_1);
		base.Controls.Add(label_0);
		base.Controls.Add(button_0);
		base.Controls.Add(numericUpDown_0);
		Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.FoodMaskWindow_Icon;
		base.Margin = new Padding(4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648977896);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648976901);
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
}
