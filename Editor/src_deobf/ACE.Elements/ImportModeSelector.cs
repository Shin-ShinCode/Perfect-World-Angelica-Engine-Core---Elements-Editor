using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.Elements;

public class ImportModeSelector : Form
{
	private CommonStorage commonStorage_0;

	private Button button_0;

	private Button button_1;

	private Label label_0;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private RadioButton radioButton_2;

	private RadioButton radioButton_3;

	public Container components;

	public ImportModeSelector(CommonStorage CStorage)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			commonStorage_0 = CStorage;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648976718));
			Text = text;
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648976741));
			label_0.Text = text2;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (radioButton_0.Checked)
		{
			CommonStorage.iData = 1;
		}
		else if (radioButton_2.Checked)
		{
			CommonStorage.iData = 2;
		}
		else if (radioButton_3.Checked)
		{
			CommonStorage.iData = 3;
		}
		else if (radioButton_1.Checked)
		{
			CommonStorage.iData = 4;
		}
		GC.KeepAlive(this);
	}

	private void method_0()
	{
		((IDisposable)components)?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		new ComponentResourceManager(typeof(ImportModeSelector));
		button_0 = new Button();
		button_1 = new Button();
		label_0 = new Label();
		radioButton_0 = new RadioButton();
		radioButton_1 = new RadioButton();
		radioButton_2 = new RadioButton();
		radioButton_3 = new RadioButton();
		SuspendLayout();
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.ImportModeSelector_cmdCancel;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(201, 118);
		button_0.Name = Class16.smethod_0(1649000848);
		button_0.Size = new Size(191, 38);
		button_0.TabIndex = 35;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648989215);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.OK;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.ImportModeSelector_cmdAccept;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(4, 118);
		button_1.Name = Class16.smethod_0(1648976764);
		button_1.Size = new Size(191, 38);
		button_1.TabIndex = 34;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648988505);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_0.Location = new Point(5, -2);
		label_0.Name = Class16.smethod_0(1648976780);
		label_0.Size = new Size(388, 44);
		label_0.TabIndex = 36;
		label_0.Text = Class16.smethod_0(1648976786);
		label_0.TextAlign = ContentAlignment.MiddleCenter;
		radioButton_0.AutoSize = true;
		radioButton_0.Checked = true;
		radioButton_0.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_0.Location = new Point(21, 38);
		radioButton_0.Name = Class16.smethod_0(1648976893);
		radioButton_0.Size = new Size(156, 19);
		radioButton_0.TabIndex = 37;
		radioButton_0.TabStop = true;
		radioButton_0.Text = Class16.smethod_0(1648975901);
		radioButton_0.UseVisualStyleBackColor = true;
		radioButton_1.AutoSize = true;
		radioButton_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_1.Location = new Point(21, 93);
		radioButton_1.Name = Class16.smethod_0(1648975933);
		radioButton_1.Size = new Size(234, 19);
		radioButton_1.TabIndex = 38;
		radioButton_1.Text = Class16.smethod_0(1648975972);
		radioButton_1.UseVisualStyleBackColor = true;
		radioButton_2.AutoSize = true;
		radioButton_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_2.Location = new Point(21, 56);
		radioButton_2.Name = Class16.smethod_0(1648976011);
		radioButton_2.Size = new Size(99, 19);
		radioButton_2.TabIndex = 39;
		radioButton_2.Text = Class16.smethod_0(1648976032);
		radioButton_2.UseVisualStyleBackColor = true;
		radioButton_3.AutoSize = true;
		radioButton_3.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_3.Location = new Point(21, 75);
		radioButton_3.Name = Class16.smethod_0(1648976060);
		radioButton_3.Size = new Size(99, 19);
		radioButton_3.TabIndex = 40;
		radioButton_3.Text = Class16.smethod_0(1648976072);
		radioButton_3.UseVisualStyleBackColor = true;
		base.AcceptButton = button_1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = button_0;
		base.ClientSize = new Size(397, 161);
		base.Controls.Add(radioButton_3);
		base.Controls.Add(radioButton_2);
		base.Controls.Add(radioButton_1);
		base.Controls.Add(radioButton_0);
		base.Controls.Add(label_0);
		base.Controls.Add(button_0);
		base.Controls.Add(button_1);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648976091);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648976124);
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
}
