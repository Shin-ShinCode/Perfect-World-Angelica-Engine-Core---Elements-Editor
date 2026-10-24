using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.Elements;

public class InputWindow : Form
{
	public static CommonStorage CStorage;

	private Label label_0;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_0;

	public Container components;

	public InputWindow(string Caption, string sData, [MarshalAs(UnmanagedType.U1)] bool bMultiline)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this, null);
			textBox_0.Multiline = bMultiline;
			int num = (bMultiline ? 262 : 133);
			base.Height = num;
			if (sData != null)
			{
				textBox_0.Text = sData;
			}
			if (Caption != null)
			{
				label_0.Text = Caption;
			}
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	public static string InputText(Form owner, string Caption, string sData, [MarshalAs(UnmanagedType.U1)] bool bMultiline)
	{
		object obj = null;
		InputWindow inputWindow = new InputWindow(Caption, sData, bMultiline);
		try
		{
			if (inputWindow.ShowDialog(owner) == DialogResult.OK)
			{
				obj = CommonStorage.sData;
			}
		}
		finally
		{
			((IDisposable)inputWindow).Dispose();
		}
		return (string)obj;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		CommonStorage.sData = null;
		Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		CommonStorage.sData = textBox_0.Text;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void InputWindow_Shown(object sender, EventArgs e)
	{
		textBox_0.Focus();
		textBox_0.SelectAll();
		GC.KeepAlive(this);
	}

	private void method_0()
	{
		((IDisposable)components)?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		new ComponentResourceManager(typeof(InputWindow));
		button_0 = new Button();
		button_1 = new Button();
		textBox_0 = new TextBox();
		label_0 = new Label();
		SuspendLayout();
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.InputWindow_cmdCancel;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(320, 53);
		button_0.Name = Class16.smethod_0(1649000848);
		button_0.Size = new Size(316, 38);
		button_0.TabIndex = 33;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648919424);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.OK;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.InputWindow_cmdAccept;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(3, 53);
		button_1.Name = Class16.smethod_0(1648976764);
		button_1.Size = new Size(311, 38);
		button_1.TabIndex = 0;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648989226);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_0.AcceptsReturn = true;
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_0.Location = new Point(3, 23);
		textBox_0.MaxLength = 1000000;
		textBox_0.Multiline = true;
		textBox_0.Name = Class16.smethod_0(1648976150);
		textBox_0.ScrollBars = ScrollBars.Both;
		textBox_0.Size = new Size(633, 24);
		textBox_0.TabIndex = 1;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.Location = new Point(3, 3);
		label_0.Name = Class16.smethod_0(1648976164);
		label_0.Size = new Size(633, 17);
		label_0.TabIndex = 71;
		label_0.Text = Class16.smethod_0(1648976181);
		label_0.TextAlign = ContentAlignment.MiddleCenter;
		base.AcceptButton = button_1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_0;
		base.ClientSize = new Size(640, 94);
		base.Controls.Add(label_0);
		base.Controls.Add(textBox_0);
		base.Controls.Add(button_0);
		base.Controls.Add(button_1);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.InputWindow_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648976217);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648976235);
		base.Shown += InputWindow_Shown;
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
