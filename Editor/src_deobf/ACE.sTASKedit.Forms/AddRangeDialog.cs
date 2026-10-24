using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.sTASKedit.Forms;

public class AddRangeDialog : Form
{
	private IContainer icontainer_0;

	private Label label_0;

	public NumericUpDown numericUpDown_StartOldId;

	private Label label_1;

	public NumericUpDown numericUpDown_Count;

	private Label label_2;

	public NumericUpDown numericUpDown_StartNewId;

	private Button button_0;

	private Button button_1;

	private Label label_3;

	private Label label_4;

	public int StartOldId => (int)numericUpDown_StartOldId.Value;

	public int Count => (int)numericUpDown_Count.Value;

	public int StartNewId => (int)numericUpDown_StartNewId.Value;

	public AddRangeDialog()
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		numericUpDown_StartNewId_ValueChanged(null, null);
	}

	private void numericUpDown_StartNewId_ValueChanged(object sender, EventArgs e)
	{
		int num = (int)numericUpDown_StartOldId.Value;
		int num2 = (int)numericUpDown_Count.Value;
		int num3 = (int)numericUpDown_StartNewId.Value;
		string text = string.Empty;
		int num4 = 3;
		for (int i = 0; i < Math.Min(num2, num4); i++)
		{
			text += string.Format(Class16.smethod_0(1649251066), num + i, num3 + i);
		}
		text = ((num2 <= num4) ? text.TrimEnd('\r', '\n') : (text + string.Format(Class16.smethod_0(1649251093), num2 - num4)));
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
		new ComponentResourceManager(typeof(AddRangeDialog));
		label_0 = new Label();
		numericUpDown_StartOldId = new NumericUpDown();
		label_1 = new Label();
		numericUpDown_Count = new NumericUpDown();
		label_2 = new Label();
		numericUpDown_StartNewId = new NumericUpDown();
		button_0 = new Button();
		button_1 = new Button();
		label_3 = new Label();
		label_4 = new Label();
		((ISupportInitialize)numericUpDown_StartOldId).BeginInit();
		((ISupportInitialize)numericUpDown_Count).BeginInit();
		((ISupportInitialize)numericUpDown_StartNewId).BeginInit();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Location = new Point(12, 15);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(65, 13);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1649251107);
		numericUpDown_StartOldId.Location = new Point(91, 13);
		numericUpDown_StartOldId.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_StartOldId.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_StartOldId.Name = Class16.smethod_0(1649251135);
		numericUpDown_StartOldId.Size = new Size(120, 20);
		numericUpDown_StartOldId.TabIndex = 1;
		numericUpDown_StartOldId.Value = new decimal(new int[4] { 15000, 0, 0, 0 });
		numericUpDown_StartOldId.ValueChanged += numericUpDown_StartNewId_ValueChanged;
		label_1.AutoSize = true;
		label_1.Location = new Point(12, 41);
		label_1.Name = Class16.smethod_0(1648912083);
		label_1.Size = new Size(38, 13);
		label_1.TabIndex = 2;
		label_1.Text = Class16.smethod_0(1648970716);
		numericUpDown_Count.Location = new Point(91, 39);
		numericUpDown_Count.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		numericUpDown_Count.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_Count.Name = Class16.smethod_0(1649251166);
		numericUpDown_Count.Size = new Size(120, 20);
		numericUpDown_Count.TabIndex = 3;
		numericUpDown_Count.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		numericUpDown_Count.ValueChanged += numericUpDown_StartNewId_ValueChanged;
		label_2.AutoSize = true;
		label_2.Location = new Point(12, 67);
		label_2.Name = Class16.smethod_0(1648912145);
		label_2.Size = new Size(71, 13);
		label_2.TabIndex = 4;
		label_2.Text = Class16.smethod_0(1649251184);
		numericUpDown_StartNewId.Location = new Point(91, 65);
		numericUpDown_StartNewId.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_StartNewId.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_StartNewId.Name = Class16.smethod_0(1649251212);
		numericUpDown_StartNewId.Size = new Size(120, 20);
		numericUpDown_StartNewId.TabIndex = 5;
		numericUpDown_StartNewId.Value = new decimal(new int[4] { 62000, 0, 0, 0 });
		numericUpDown_StartNewId.ValueChanged += numericUpDown_StartNewId_ValueChanged;
		button_0.DialogResult = DialogResult.OK;
		button_0.Location = new Point(15, 175);
		button_0.Name = Class16.smethod_0(1649251235);
		button_0.Size = new Size(75, 23);
		button_0.TabIndex = 6;
		button_0.Text = Class16.smethod_0(1648938905);
		button_0.UseVisualStyleBackColor = true;
		button_1.DialogResult = DialogResult.Cancel;
		button_1.Location = new Point(136, 175);
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
		label_4.Text = Class16.smethod_0(1649251294);
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = button_1;
		base.ClientSize = new Size(234, 210);
		base.Controls.Add(label_4);
		base.Controls.Add(label_3);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(numericUpDown_StartNewId);
		base.Controls.Add(label_2);
		base.Controls.Add(numericUpDown_Count);
		base.Controls.Add(label_1);
		base.Controls.Add(numericUpDown_StartOldId);
		base.Controls.Add(label_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649250320);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649250349);
		((ISupportInitialize)numericUpDown_StartOldId).EndInit();
		((ISupportInitialize)numericUpDown_Count).EndInit();
		((ISupportInitialize)numericUpDown_StartNewId).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
