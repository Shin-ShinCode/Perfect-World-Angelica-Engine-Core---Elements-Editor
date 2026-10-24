using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.EcmEditor;

public class EcmInsertContentDialog : Form
{
	private string string_0 = string.Empty;

	private IContainer icontainer_0;

	private Label label_0;

	private RichTextBox richTextBox_0;

	private Button button_0;

	private Button button_1;

	public string ContentToInsert
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public EcmInsertContentDialog()
	{
		method_1();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
	}

	private void method_0(string string_1)
	{
		string_0 = string_1;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_0(richTextBox_0.Text);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_1()
	{
		label_0 = new Label();
		richTextBox_0 = new RichTextBox();
		button_0 = new Button();
		button_1 = new Button();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648934511), 9f, FontStyle.Bold);
		label_0.Location = new Point(16, 16);
		label_0.Name = Class16.smethod_0(1648992332);
		label_0.Size = new Size(110, 15);
		label_0.Text = Class16.smethod_0(1648992339);
		richTextBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		richTextBox_0.AcceptsTab = true;
		richTextBox_0.BorderStyle = BorderStyle.FixedSingle;
		richTextBox_0.DetectUrls = false;
		richTextBox_0.Font = new Font(Class16.smethod_0(1648929975), 10f);
		richTextBox_0.Location = new Point(16, 40);
		richTextBox_0.MaxLength = int.MaxValue;
		richTextBox_0.Name = Class16.smethod_0(1648992372);
		richTextBox_0.ScrollBars = RichTextBoxScrollBars.Both;
		richTextBox_0.Size = new Size(568, 320);
		richTextBox_0.WordWrap = false;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_0.FlatStyle = FlatStyle.Flat;
		button_0.Location = new Point(394, 372);
		button_0.Name = Class16.smethod_0(1648992389);
		button_0.Size = new Size(90, 30);
		button_0.Text = Class16.smethod_0(1648992393);
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_1.FlatStyle = FlatStyle.Flat;
		button_1.Location = new Point(494, 372);
		button_1.Name = Class16.smethod_0(1648992414);
		button_1.Size = new Size(90, 30);
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.Click += button_1_Click;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(600, 416);
		base.Controls.Add(label_0);
		base.Controls.Add(richTextBox_0);
		base.Controls.Add(button_0);
		base.Controls.Add(button_1);
		base.MinimizeBox = false;
		MinimumSize = new Size(450, 350);
		base.Name = Class16.smethod_0(1648992430);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648998766);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
