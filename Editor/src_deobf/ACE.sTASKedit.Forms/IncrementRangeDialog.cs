using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.sTASKedit.Forms;

public class IncrementRangeDialog : Form
{
	private IContainer icontainer_0;

	private Label label_0;

	public NumericUpDown numericUpDown_IdMin;

	private Label label_1;

	public NumericUpDown numericUpDown_IdMax;

	private Label label_2;

	public NumericUpDown numericUpDown_Increment;

	private Button button_0;

	private Button button_1;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	public int IdMin => (int)numericUpDown_IdMin.Value;

	public int IdMax => (int)numericUpDown_IdMax.Value;

	public int Increment => (int)numericUpDown_Increment.Value;

	public IncrementRangeDialog()
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		numericUpDown_Increment_ValueChanged(null, null);
	}

	private void numericUpDown_Increment_ValueChanged(object sender, EventArgs e)
	{
		int num = (int)numericUpDown_IdMin.Value;
		int num2 = (int)numericUpDown_IdMax.Value;
		int num3 = (int)numericUpDown_Increment.Value;
		string text = string.Empty;
		int num4 = 3;
		for (int i = 0; i < num4 && num + i <= num2; i++)
		{
			int num5 = num + i;
			int num6 = num5 + num3;
			text += string.Format(Class16.smethod_0(1649251066), num5, num6);
		}
		int num7 = Math.Max(0, num2 - num + 1);
		text = ((num7 > num4) ? (text + string.Format(Class16.smethod_0(1649251093), num7 - num4)) : ((num7 <= 0) ? Class16.smethod_0(1649250360) : text.TrimEnd('\r', '\n')));
		label_4.Text = text;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_0()
	{
		new ComponentResourceManager(typeof(IncrementRangeDialog));
		label_0 = new Label();
		numericUpDown_IdMin = new NumericUpDown();
		label_1 = new Label();
		numericUpDown_IdMax = new NumericUpDown();
		label_2 = new Label();
		numericUpDown_Increment = new NumericUpDown();
		button_0 = new Button();
		button_1 = new Button();
		label_3 = new Label();
		label_4 = new Label();
		label_5 = new Label();
		((ISupportInitialize)numericUpDown_IdMin).BeginInit();
		((ISupportInitialize)numericUpDown_IdMax).BeginInit();
		((ISupportInitialize)numericUpDown_Increment).BeginInit();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Location = new Point(12, 15);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(41, 13);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1649250390);
		numericUpDown_IdMin.Location = new Point(91, 13);
		numericUpDown_IdMin.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_IdMin.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_IdMin.Name = Class16.smethod_0(1649250404);
		numericUpDown_IdMin.Size = new Size(120, 20);
		numericUpDown_IdMin.TabIndex = 1;
		numericUpDown_IdMin.Value = new decimal(new int[4] { 2000, 0, 0, 0 });
		numericUpDown_IdMin.ValueChanged += numericUpDown_Increment_ValueChanged;
		label_1.AutoSize = true;
		label_1.Location = new Point(12, 41);
		label_1.Name = Class16.smethod_0(1648912083);
		label_1.Size = new Size(44, 13);
		label_1.TabIndex = 2;
		label_1.Text = Class16.smethod_0(1649250430);
		numericUpDown_IdMax.Location = new Point(91, 39);
		numericUpDown_IdMax.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_IdMax.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_IdMax.Name = Class16.smethod_0(1649250444);
		numericUpDown_IdMax.Size = new Size(120, 20);
		numericUpDown_IdMax.TabIndex = 3;
		numericUpDown_IdMax.Value = new decimal(new int[4] { 3000, 0, 0, 0 });
		numericUpDown_IdMax.ValueChanged += numericUpDown_Increment_ValueChanged;
		label_2.AutoSize = true;
		label_2.Location = new Point(12, 67);
		label_2.Name = Class16.smethod_0(1648912145);
		label_2.Size = new Size(57, 13);
		label_2.TabIndex = 4;
		label_2.Text = Class16.smethod_0(1649250470);
		numericUpDown_Increment.Location = new Point(91, 65);
		numericUpDown_Increment.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_Increment.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		numericUpDown_Increment.Name = Class16.smethod_0(1649250487);
		numericUpDown_Increment.Size = new Size(120, 20);
		numericUpDown_Increment.TabIndex = 5;
		numericUpDown_Increment.Value = new decimal(new int[4] { 10000, 0, 0, 0 });
		numericUpDown_Increment.ValueChanged += numericUpDown_Increment_ValueChanged;
		button_0.DialogResult = DialogResult.OK;
		button_0.Location = new Point(15, 195);
		button_0.Name = Class16.smethod_0(1649251235);
		button_0.Size = new Size(75, 23);
		button_0.TabIndex = 6;
		button_0.Text = Class16.smethod_0(1648938905);
		button_0.UseVisualStyleBackColor = true;
		button_1.DialogResult = DialogResult.Cancel;
		button_1.Location = new Point(136, 195);
		button_1.Name = Class16.smethod_0(1649262492);
		button_1.Size = new Size(75, 23);
		button_1.TabIndex = 7;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.UseVisualStyleBackColor = true;
		label_3.AutoSize = true;
		label_3.Location = new Point(12, 97);
		label_3.Name = Class16.smethod_0(1648912200);
		label_3.Size = new Size(48, 13);
		label_3.TabIndex = 8;
		label_3.Text = Class16.smethod_0(1649251251);
		label_4.Font = new Font(Class16.smethod_0(1648929975), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_4.Location = new Point(12, 115);
		label_4.Name = Class16.smethod_0(1649251266);
		label_4.Size = new Size(210, 50);
		label_4.TabIndex = 9;
		label_4.Text = Class16.smethod_0(1649250517);
		label_5.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Italic, GraphicsUnit.Point, 0);
		label_5.Location = new Point(12, 168);
		label_5.Name = Class16.smethod_0(1648912262);
		label_5.Size = new Size(210, 20);
		label_5.TabIndex = 10;
		label_5.Text = Class16.smethod_0(1649250572);
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = button_1;
		base.ClientSize = new Size(234, 230);
		base.Controls.Add(label_5);
		base.Controls.Add(label_4);
		base.Controls.Add(label_3);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(numericUpDown_Increment);
		base.Controls.Add(label_2);
		base.Controls.Add(numericUpDown_IdMax);
		base.Controls.Add(label_1);
		base.Controls.Add(numericUpDown_IdMin);
		base.Controls.Add(label_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649250656);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649250683);
		((ISupportInitialize)numericUpDown_IdMin).EndInit();
		((ISupportInitialize)numericUpDown_IdMax).EndInit();
		((ISupportInitialize)numericUpDown_Increment).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
