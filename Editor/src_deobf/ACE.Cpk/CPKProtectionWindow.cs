using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.License;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Cpk;

public class CPKProtectionWindow : Form
{
	public CommonStorage CStorage;

	private ToolTip toolTip_0;

	private CheckBox checkBox_0;

	public Form ElementsWindow;

	private Label label_0;

	private TextBox textBox_0;

	private Button button_0;

	private Label label_1;

	private TextBox textBox_1;

	private GroupBox groupBox_0;

	private Button button_1;

	private Button button_2;

	private IContainer icontainer_0;

	public CPKProtectionWindow(CommonStorage CStorage, Form ElementsWindow)
	{
		try
		{
			method_2();
			this.CStorage = CStorage;
			this.ElementsWindow = ElementsWindow;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			if (base.IsHandleCreated)
			{
				TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
			}
			TDark.ApplyNativeDarkThemeRecursive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_0();
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
	}

	private void textBox_1_DoubleClick(object sender, EventArgs e)
	{
		method_0();
	}

	private void CPKProtectionWindow_Shown(object sender, EventArgs e)
	{
		if (CommonStorage.License.GetFeatureEntitlementsByName(Class16.smethod_0(1648893727)) || LICENSE_INFO.Info.LicenseType == LICENSE_TYPE.DEV)
		{
			textBox_0.Text = Class16.smethod_0(1648893729);
		}
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		string text = textBox_1.Text;
		if (string.IsNullOrWhiteSpace(text))
		{
			GC.KeepAlive(this);
			return;
		}
		if (!ACE.RSGlobal.RSGlobal.IsUIntFast(textBox_0.Text))
		{
			TextStorage.TEXTS.ShowErrorMessage(530);
			GC.KeepAlive(this);
			return;
		}
		if (text.StartsWith(Class16.smethod_0(1648904453)))
		{
			text = text.Replace(Class16.smethod_0(1648904453), string.Empty);
		}
		bool flag = File.Exists(text);
		bool flag2 = Directory.Exists(text);
		if (flag)
		{
			CheckBox checkBox = checkBox_0;
			TextBox textBox = textBox_0;
			if (CPK.UnprotectCPK(text, ACE.RSGlobal.RSGlobal.UIntParseFast(textBox.Text), checkBox.Checked))
			{
				TextStorage.TEXTS.ShowMessage(544, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			}
		}
		else if (flag2)
		{
			bool flag3 = false;
			string[] files = Directory.GetFiles(text, Class16.smethod_0(1648893746));
			int num = 0;
			if (0 < (nint)files.LongLength)
			{
				do
				{
					string fn = files[num];
					CheckBox checkBox2 = checkBox_0;
					TextBox textBox2 = textBox_0;
					int num2 = ((CPK.UnprotectCPK(fn, ACE.RSGlobal.RSGlobal.UIntParseFast(textBox2.Text), checkBox2.Checked) || flag3) ? 1 : 0);
					flag3 = (byte)num2 != 0;
					num++;
				}
				while (num < (nint)files.LongLength);
				if (flag3)
				{
					TextStorage.TEXTS.ShowMessage(544, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
				}
			}
		}
		else
		{
			object[] vars = new object[1] { text };
			TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
		}
		GC.KeepAlive(this);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		string text = textBox_1.Text;
		if (string.IsNullOrWhiteSpace(text))
		{
			GC.KeepAlive(this);
			return;
		}
		if (!ACE.RSGlobal.RSGlobal.IsUIntFast(textBox_0.Text))
		{
			TextStorage.TEXTS.ShowErrorMessage(530);
			GC.KeepAlive(this);
			return;
		}
		Cursor = Cursors.WaitCursor;
		button_2.Enabled = false;
		button_1.Enabled = false;
		if (text.StartsWith(Class16.smethod_0(1648904453)))
		{
			text = text.Replace(Class16.smethod_0(1648904453), string.Empty);
		}
		bool flag = File.Exists(text);
		bool flag2 = Directory.Exists(text);
		if (flag)
		{
			if (ACE.RSGlobal.RSGlobal.IsUIntFast(textBox_0.Text))
			{
				string userName = CommonStorage.License.UserName;
				if (CPK.ProtectCPK(text, bAddTrash: true, ACE.RSGlobal.RSGlobal.UIntParseFast(textBox_0.Text), userName))
				{
					ACE.RSGlobal.RSGlobal.Sleep(2000u);
					TextStorage.TEXTS.ShowMessage(532, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
				}
			}
			else
			{
				TextStorage.TEXTS.ShowErrorMessage(530);
			}
		}
		else if (flag2)
		{
			bool flag3 = false;
			string[] files = Directory.GetFiles(text, Class16.smethod_0(1648893746));
			int num = 0;
			if (0 < (nint)files.LongLength)
			{
				do
				{
					int num2 = ((CPK.ProtectCPK(files[num], bAddTrash: true, UserName: CommonStorage.License.UserName, ProtectionKey: ACE.RSGlobal.RSGlobal.UIntParseFast(textBox_0.Text)) || flag3) ? 1 : 0);
					flag3 = (byte)num2 != 0;
					num++;
				}
				while (num < (nint)files.LongLength);
				if (flag3)
				{
					TextStorage.TEXTS.ShowMessage(532, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
				}
			}
		}
		else
		{
			object[] vars = new object[1] { text };
			TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
		}
		button_2.Enabled = true;
		button_1.Enabled = true;
		Cursor = Cursors.Default;
		GC.KeepAlive(this);
	}

	private void method_0()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = TextStorage.Msg(Class16.smethod_0(1648893766), Class16.smethod_0(1648893791));
		openFileDialog.Multiselect = true;
		if (openFileDialog.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_1.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void CPKProtectionWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		Form elementsWindow = ElementsWindow;
		if (elementsWindow != null && !elementsWindow.Visible)
		{
			ACE.RSGlobal.RSGlobal.End(null, null);
		}
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
		new ComponentResourceManager(typeof(CPKProtectionWindow));
		button_1 = new Button();
		button_2 = new Button();
		groupBox_0 = new GroupBox();
		checkBox_0 = new CheckBox();
		label_0 = new Label();
		textBox_0 = new TextBox();
		button_0 = new Button();
		label_1 = new Label();
		textBox_1 = new TextBox();
		toolTip_0 = new ToolTip(icontainer_0);
		groupBox_0.SuspendLayout();
		SuspendLayout();
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.Cancel;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.cmdUnprotectCPK;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(226, 90);
		button_1.Name = Class16.smethod_0(1648893823);
		button_1.Size = new Size(227, 38);
		button_1.TabIndex = 35;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648893845);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.AutoSize = true;
		button_2.DialogResult = DialogResult.OK;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_2.Image = Resources.cmdProtectCPK;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(5, 90);
		button_2.Name = Class16.smethod_0(1648893857);
		button_2.Size = new Size(215, 38);
		button_2.TabIndex = 34;
		button_2.TabStop = false;
		button_2.Text = Class16.smethod_0(1648893885);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		groupBox_0.Controls.Add(checkBox_0);
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(textBox_0);
		groupBox_0.Controls.Add(button_0);
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Controls.Add(textBox_1);
		groupBox_0.Controls.Add(button_2);
		groupBox_0.Controls.Add(button_1);
		groupBox_0.Location = new Point(6, 0);
		groupBox_0.Name = Class16.smethod_0(1648893902);
		groupBox_0.Size = new Size(453, 133);
		groupBox_0.TabIndex = 40;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1648893925);
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(338, 71);
		checkBox_0.Name = Class16.smethod_0(1648893943);
		checkBox_0.Size = new Size(107, 17);
		checkBox_0.TabIndex = 47;
		checkBox_0.Text = Class16.smethod_0(1648892945);
		checkBox_0.UseVisualStyleBackColor = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_0.Location = new Point(2, 48);
		label_0.Name = Class16.smethod_0(1648892969);
		label_0.Size = new Size(41, 15);
		label_0.TabIndex = 46;
		label_0.Text = Class16.smethod_0(1648892990);
		label_0.TextAlign = ContentAlignment.MiddleRight;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_0.Location = new Point(49, 45);
		textBox_0.Name = Class16.smethod_0(1648892992);
		textBox_0.Size = new Size(396, 23);
		textBox_0.TabIndex = 45;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(textBox_0, Class16.smethod_0(1648893008));
		button_0.Image = Resources.cmdBrowse;
		button_0.Location = new Point(419, 15);
		button_0.Name = Class16.smethod_0(1648893030);
		button_0.Size = new Size(26, 24);
		button_0.TabIndex = 44;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_1.Location = new Point(7, 20);
		label_1.Name = Class16.smethod_0(1648893046);
		label_1.Size = new Size(36, 15);
		label_1.TabIndex = 43;
		label_1.Text = Class16.smethod_0(1648893060);
		label_1.TextAlign = ContentAlignment.MiddleRight;
		textBox_1.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_1.Location = new Point(49, 16);
		textBox_1.Name = Class16.smethod_0(1648893071);
		textBox_1.Size = new Size(368, 23);
		textBox_1.TabIndex = 42;
		textBox_1.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(textBox_1, Class16.smethod_0(1648893086));
		textBox_1.TextChanged += textBox_1_TextChanged;
		textBox_1.DoubleClick += textBox_1_DoubleClick;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_1;
		base.ClientSize = new Size(464, 136);
		base.Controls.Add(groupBox_0);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.CPKProtectionWindow_Icon;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648893099);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648893133);
		base.TopMost = true;
		base.FormClosing += CPKProtectionWindow_FormClosing;
		base.Shown += CPKProtectionWindow_Shown;
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		ResumeLayout(performLayout: false);
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
