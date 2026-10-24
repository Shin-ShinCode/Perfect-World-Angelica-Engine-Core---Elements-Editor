using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class CustomDataWindow : Form
{
	public bool t_changed;

	private NumericUpDown numericUpDown_0;

	private NumericUpDown numericUpDown_1;

	private int int_0;

	private Label label_0;

	private Label label_1;

	private Button button_0;

	private Label label_2;

	private Button button_1;

	private Container container_0;

	public CustomDataWindow(int _maxparamindex)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this);
			int_0 = _maxparamindex;
			if (_maxparamindex > -1)
			{
				decimal maximum = _maxparamindex;
				numericUpDown_0.Maximum = maximum;
				decimal maximum2 = int_0;
				numericUpDown_1.Maximum = maximum2;
			}
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void method_0(bool bool_0)
	{
		((IDisposable)container_0)?.Dispose();
	}

	private void method_1()
	{
		new ComponentResourceManager(typeof(CustomDataWindow));
		label_0 = new Label();
		label_1 = new Label();
		button_0 = new Button();
		label_2 = new Label();
		button_1 = new Button();
		numericUpDown_0 = new NumericUpDown();
		numericUpDown_1 = new NumericUpDown();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.Location = new Point(12, 9);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(175, 15);
		label_0.TabIndex = 0;
		label_0.Text = TextStorage.Msg(Class16.smethod_0(1648984269), Class16.smethod_0(1648984305));
		label_1.AutoSize = true;
		label_1.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_1.Location = new Point(307, 9);
		label_1.Name = Class16.smethod_0(1648912083);
		label_1.Size = new Size(90, 15);
		label_1.TabIndex = 1;
		label_1.Text = TextStorage.Msg(Class16.smethod_0(1648984351), Class16.smethod_0(1648984371));
		button_0.Font = new Font(Class16.smethod_0(1648929920), 9f);
		button_0.Location = new Point(12, 49);
		button_0.Name = Class16.smethod_0(1648991094);
		button_0.Size = new Size(558, 23);
		button_0.TabIndex = 2;
		button_0.Text = TextStorage.Msg(Class16.smethod_0(1648984393), Class16.smethod_0(1648984439));
		button_0.UseVisualStyleBackColor = true;
		label_2.AutoSize = true;
		label_2.Font = new Font(Class16.smethod_0(1648929920), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_2.ForeColor = Color.Red;
		label_2.Location = new Point(137, 31);
		label_2.Name = Class16.smethod_0(1648912145);
		label_2.Size = new Size(254, 16);
		label_2.TabIndex = 3;
		label_2.Text = TextStorage.Msg(Class16.smethod_0(1648984468), Class16.smethod_0(1648984524));
		button_1.Location = new Point(471, 6);
		button_1.Name = Class16.smethod_0(1648991134);
		button_1.Size = new Size(99, 23);
		button_1.TabIndex = 4;
		button_1.Text = TextStorage.Msg(Class16.smethod_0(1648984574), Class16.smethod_0(1648987676));
		button_1.UseVisualStyleBackColor = true;
		numericUpDown_0.Location = new Point(242, 8);
		numericUpDown_0.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648987689);
		numericUpDown_0.Size = new Size(48, 20);
		numericUpDown_0.TabIndex = 14;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_1.Location = new Point(417, 8);
		numericUpDown_1.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		numericUpDown_1.Name = Class16.smethod_0(1648987710);
		numericUpDown_1.Size = new Size(48, 20);
		numericUpDown_1.TabIndex = 15;
		numericUpDown_1.TextAlign = HorizontalAlignment.Center;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(584, 78);
		base.Controls.Add(numericUpDown_1);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(button_1);
		base.Controls.Add(label_2);
		base.Controls.Add(button_0);
		base.Controls.Add(label_1);
		base.Controls.Add(label_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648987715);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648987738);
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void method_2(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.custom_startindex = (int)numericUpDown_0.Value;
		ACE.RSGlobal.RSGlobal.custom_valcount = (int)numericUpDown_1.Value + (1 - ACE.RSGlobal.RSGlobal.custom_startindex);
		ACE.RSGlobal.RSGlobal.custom_valcount = ((ACE.RSGlobal.RSGlobal.custom_valcount < 1) ? 1 : ACE.RSGlobal.RSGlobal.custom_valcount);
		Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		decimal value = int_0;
		numericUpDown_1.Value = value;
	}

	private void method_4(object sender, EventArgs e)
	{
		decimal value = numericUpDown_0.Value;
		numericUpDown_1.Minimum = value;
	}

	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_0(bool_0: true);
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
