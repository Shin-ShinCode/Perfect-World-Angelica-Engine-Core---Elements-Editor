using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.RSGlobal;
using ACE.Settings;
using ACE.Updater;
using Sentry;

namespace ACE.License;

public class ActivationWindow : Form
{
	private CommonStorage commonStorage_0;

	private LICENSE_INFO license_INFO_0;

	public bool bNeedsTwoFactor;

	private LICENSE_INFO.UserLicense[] userLicense_0;

	private static Icon icon_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private Button button_0;

	private Label label_0;

	private Label label_1;

	private ImageList imageList_0;

	private Label label_2;

	private ToolTip toolTip_0;

	private CheckBox checkBox_0;

	private LinkLabel linkLabel_0;

	private Label label_3;

	private Panel panel_0;

	private ComboBox comboBox_0;

	private LinkLabel linkLabel_1;

	private Panel panel_1;

	private Label label_4;

	private IContainer icontainer_0;

	public ActivationWindow(CommonStorage CStorage)
	{
		try
		{
			method_2();
			method_0();
			commonStorage_0 = CStorage;
			license_INFO_0 = CommonStorage.License;
			try
			{
				Version version = Assembly.GetExecutingAssembly().GetName().Version;
				label_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649046370), Class16.smethod_0(1649046407)), version.Major, version.Minor, version.Build);
			}
			catch
			{
				label_4.Text = string.Empty;
			}
			method_1();
			base.Paint += ActivationWindow_Paint;
			TDark.StoreOriginalColors(this);
			TDark.ApplyThemeToForm(this);
			GC.KeepAlive(this);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649046418));
			Dispose(disposing: true);
			throw new Exception(Class16.smethod_0(1648935998) + ex.Message);
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_0, IntPtr intptr_1, string string_0);

	[DllImport("user32.dll", EntryPoint = "SendMessage")]
	private static extern int SendMessage_1(IntPtr intptr_0, int int_0, int int_1, int int_2);

	[DllImport("user32.dll")]
	private static extern bool ReleaseCapture();

	private static void smethod_0(TextBox textBox_3, string string_0)
	{
		if (textBox_3 == null)
		{
			return;
		}
		try
		{
			IntPtr handle = textBox_3.Handle;
			SendMessage(handle, 5377, (IntPtr)1, string_0 ?? string.Empty);
		}
		catch
		{
		}
	}

	private void method_0()
	{
		if (icon_0 == null)
		{
			try
			{
				icon_0 = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureMessage(Class16.smethod_0(1649046458) + ex.Message, (SentryLevel)1, Class16.smethod_0(1649046504));
			}
		}
		if (icon_0 != null)
		{
			try
			{
				base.Icon = icon_0;
			}
			catch
			{
			}
		}
	}

	private void method_1()
	{
		try
		{
			LANGUAGES languages = CommonStorage.Texts.Languages;
			comboBox_0.Items.Clear();
			ComboBox.ObjectCollection items = comboBox_0.Items;
			object[] languages2 = languages.GetLanguages();
			items.AddRange(languages2);
			comboBox_0.SelectedIndex = CommonStorage.LangIndex;
		}
		catch
		{
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (comboBox_0.SelectedIndex >= 0)
			{
				commonStorage_0.SetLanguage(comboBox_0.SelectedIndex);
				TextStorage.TEXTS.SetFormLanguage(this, toolTip_0);
				GC.KeepAlive(this);
			}
		}
		catch
		{
		}
	}

	private void linkLabel_1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			linkLabel_1.Enabled = false;
			Application.DoEvents();
			string updaterExePath = CommonStorage.UpdaterExePath;
			UpdateInfo update;
			string error;
			if (File.Exists(updaterExePath))
			{
				Process.Start(updaterExePath, Class16.smethod_0(1649045524))?.Close();
				linkLabel_1.Enabled = true;
			}
			else if (UpdateFeedParser.TryFetchLatestCompatibleUpdate(Class16.smethod_0(1649045540), out update, out error))
			{
				Version version = Assembly.GetExecutingAssembly().GetName().Version;
				if (update.RemoteVersion > version && DKBox.Show(null, null, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
				{
					if (!string.IsNullOrWhiteSpace(update.Url))
					{
						Process.Start(new ProcessStartInfo(update.Url)
						{
							UseShellExecute = true
						});
					}
					else
					{
						Process.Start(new ProcessStartInfo(Class16.smethod_0(1649045591))
						{
							UseShellExecute = true
						});
					}
				}
			}
			else
			{
				Process.Start(new ProcessStartInfo(Class16.smethod_0(1649045591))
				{
					UseShellExecute = true
				});
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649045633));
		}
		finally
		{
			linkLabel_1.Enabled = true;
		}
	}

	private void ActivationWindow_Paint(object sender, PaintEventArgs e)
	{
		Color color = (TDark.IsDarkMode ? Color.FromArgb(60, 60, 65) : Color.FromArgb(200, 200, 200));
		Pen pen = new Pen(color, 1f);
		try
		{
			e.Graphics.DrawRectangle(pen, 0, 0, base.Width - 1, base.Height - 1);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	private void ActivationWindow_Shown(object sender, EventArgs e)
	{
		smethod_0(textBox_0, Class16.smethod_0(1649045679));
		smethod_0(textBox_1, Class16.smethod_0(1649045683));
		smethod_0(textBox_2, Class16.smethod_0(1649045698));
		TextStorage.TEXTS.SetFormLanguage(this, toolTip_0);
		if (LicenseCredentials.TryLoadCredentials(out var email, out var password))
		{
			textBox_0.Text = email;
			textBox_1.Text = password;
			checkBox_0.Checked = true;
			method_4(email, password);
		}
		else
		{
			checkBox_0.Checked = false;
		}
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		Color color = Color.FromArgb(0, 191, 179);
		Color mouseOverBackColor = Color.FromArgb(0, 170, 160);
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		textBox_2 = new TextBox();
		button_0 = new Button();
		label_0 = new Label();
		label_1 = new Label();
		imageList_0 = new ImageList(icontainer_0);
		label_2 = new Label();
		toolTip_0 = new ToolTip(icontainer_0);
		checkBox_0 = new CheckBox();
		linkLabel_0 = new LinkLabel();
		label_3 = new Label();
		panel_0 = new Panel();
		comboBox_0 = new ComboBox();
		linkLabel_1 = new LinkLabel();
		panel_1 = new Panel();
		label_4 = new Label();
		panel_0.SuspendLayout();
		panel_1.SuspendLayout();
		SuspendLayout();
		panel_0.BackColor = Color.FromArgb(245, 245, 245);
		panel_0.Controls.Add(label_3);
		panel_0.Controls.Add(comboBox_0);
		panel_0.Controls.Add(label_2);
		panel_0.Dock = DockStyle.Top;
		panel_0.Location = new Point(0, 0);
		panel_0.Name = Class16.smethod_0(1649045713);
		panel_0.Padding = new Padding(0, 0, 0, 1);
		panel_0.Size = new Size(440, 44);
		panel_0.TabIndex = 20;
		panel_0.MouseDown += label_2_MouseDown;
		label_2.BackColor = Color.Transparent;
		label_2.Dock = DockStyle.Fill;
		label_2.Font = new Font(Class16.smethod_0(1648934511), 11.25f, FontStyle.Bold);
		label_2.ForeColor = Color.FromArgb(50, 50, 50);
		label_2.Location = new Point(0, 0);
		label_2.Name = Class16.smethod_0(1648992332);
		label_2.Size = new Size(440, 43);
		label_2.TabIndex = 0;
		label_2.Text = Class16.smethod_0(1648898209);
		label_2.TextAlign = ContentAlignment.MiddleCenter;
		label_2.MouseDown += label_2_MouseDown;
		label_3.BackColor = Color.Transparent;
		label_3.Cursor = Cursors.Hand;
		label_3.Dock = DockStyle.Right;
		label_3.Font = new Font(Class16.smethod_0(1648942905), 12f);
		label_3.ForeColor = Color.FromArgb(100, 100, 100);
		label_3.Location = new Point(400, 0);
		label_3.Name = Class16.smethod_0(1649045731);
		label_3.Size = new Size(40, 43);
		label_3.TabIndex = 1;
		label_3.Text = Class16.smethod_0(1649045746);
		label_3.TextAlign = ContentAlignment.MiddleCenter;
		label_3.Click += label_3_Click;
		label_3.MouseEnter += label_3_MouseEnter;
		label_3.MouseLeave += label_3_MouseLeave;
		comboBox_0.Dock = DockStyle.Left;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FlatStyle = FlatStyle.Flat;
		comboBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(0, 0);
		comboBox_0.Name = Class16.smethod_0(1649045755);
		comboBox_0.Size = new Size(130, 24);
		comboBox_0.TabIndex = 30;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f);
		label_0.ForeColor = Color.FromArgb(100, 100, 100);
		label_0.Location = new Point(42, 62);
		label_0.Name = Class16.smethod_0(1649045781);
		label_0.Size = new Size(117, 17);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1649045800);
		textBox_0.BorderStyle = BorderStyle.FixedSingle;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 11f);
		textBox_0.Location = new Point(42, 90);
		textBox_0.Name = Class16.smethod_0(1649045838);
		textBox_0.Size = new Size(356, 27);
		textBox_0.TabIndex = 1;
		textBox_1.BorderStyle = BorderStyle.FixedSingle;
		textBox_1.Font = new Font(Class16.smethod_0(1648942905), 11f);
		textBox_1.Location = new Point(42, 130);
		textBox_1.Name = Class16.smethod_0(1649045853);
		textBox_1.PasswordChar = '*';
		textBox_1.Size = new Size(356, 27);
		textBox_1.TabIndex = 2;
		textBox_1.UseSystemPasswordChar = true;
		checkBox_0.AutoSize = true;
		checkBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		checkBox_0.ForeColor = Color.FromArgb(80, 80, 80);
		checkBox_0.Location = new Point(42, 170);
		checkBox_0.Name = Class16.smethod_0(1649045871);
		checkBox_0.Size = new Size(104, 19);
		checkBox_0.TabIndex = 3;
		checkBox_0.Text = Class16.smethod_0(1649045883);
		checkBox_0.UseVisualStyleBackColor = true;
		linkLabel_0.AutoSize = true;
		linkLabel_0.ActiveLinkColor = color;
		linkLabel_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		linkLabel_0.LinkColor = color;
		linkLabel_0.Location = new Point(292, 171);
		linkLabel_0.Name = Class16.smethod_0(1649045909);
		linkLabel_0.Size = new Size(89, 15);
		linkLabel_0.TabIndex = 9;
		linkLabel_0.TabStop = true;
		linkLabel_0.Text = Class16.smethod_0(1649045932);
		linkLabel_0.VisitedLinkColor = color;
		linkLabel_0.Click += linkLabel_0_Click;
		button_0.BackColor = color;
		button_0.Cursor = Cursors.Hand;
		button_0.FlatAppearance.BorderSize = 0;
		button_0.FlatAppearance.MouseOverBackColor = mouseOverBackColor;
		button_0.FlatStyle = FlatStyle.Flat;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Bold);
		button_0.ForeColor = Color.White;
		button_0.Location = new Point(42, 205);
		button_0.Name = Class16.smethod_0(1649045945);
		button_0.Size = new Size(356, 40);
		button_0.TabIndex = 4;
		button_0.Text = Class16.smethod_0(1649045960);
		button_0.UseVisualStyleBackColor = false;
		button_0.Click += button_0_Click;
		label_1.AutoSize = true;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_1.ForeColor = Color.FromArgb(100, 100, 100);
		label_1.Location = new Point(42, 260);
		label_1.Name = Class16.smethod_0(1649045980);
		label_1.Size = new Size(56, 15);
		label_1.TabIndex = 5;
		label_1.Text = Class16.smethod_0(1649045985);
		label_1.Visible = false;
		textBox_2.BorderStyle = BorderStyle.FixedSingle;
		textBox_2.Font = new Font(Class16.smethod_0(1648942905), 11f);
		textBox_2.Location = new Point(42, 280);
		textBox_2.Name = Class16.smethod_0(1649046001);
		textBox_2.Size = new Size(356, 27);
		textBox_2.TabIndex = 6;
		textBox_2.Visible = false;
		panel_1.BackColor = Color.FromArgb(245, 245, 245);
		panel_1.Controls.Add(linkLabel_1);
		panel_1.Controls.Add(label_4);
		panel_1.Dock = DockStyle.Bottom;
		panel_1.Location = new Point(0, 268);
		panel_1.Name = Class16.smethod_0(1649049090);
		panel_1.Size = new Size(440, 32);
		panel_1.TabIndex = 25;
		label_4.Dock = DockStyle.Left;
		label_4.Font = new Font(Class16.smethod_0(1648942905), 8f);
		label_4.ForeColor = Color.FromArgb(140, 140, 140);
		label_4.Location = new Point(0, 0);
		label_4.Name = Class16.smethod_0(1649049106);
		label_4.Padding = new Padding(10, 0, 0, 0);
		label_4.Size = new Size(200, 32);
		label_4.TabIndex = 0;
		label_4.TextAlign = ContentAlignment.MiddleLeft;
		linkLabel_1.Dock = DockStyle.Right;
		linkLabel_1.Font = new Font(Class16.smethod_0(1648942905), 8f);
		linkLabel_1.ActiveLinkColor = color;
		linkLabel_1.LinkColor = color;
		linkLabel_1.VisitedLinkColor = color;
		linkLabel_1.Location = new Point(290, 0);
		linkLabel_1.Name = Class16.smethod_0(1649049123);
		linkLabel_1.Padding = new Padding(0, 0, 10, 0);
		linkLabel_1.Size = new Size(150, 32);
		linkLabel_1.TabIndex = 1;
		linkLabel_1.TabStop = true;
		linkLabel_1.Text = Class16.smethod_0(1649049144);
		linkLabel_1.TextAlign = ContentAlignment.MiddleRight;
		linkLabel_1.LinkClicked += linkLabel_1_LinkClicked;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		base.ClientSize = new Size(440, 300);
		base.ControlBox = false;
		base.Controls.Add(panel_0);
		base.Controls.Add(panel_1);
		base.Controls.Add(label_0);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(linkLabel_0);
		base.Controls.Add(textBox_0);
		base.Controls.Add(textBox_1);
		base.Controls.Add(label_1);
		base.Controls.Add(textBox_2);
		base.Controls.Add(button_0);
		Font = new Font(Class16.smethod_0(1648942905), 8.25f);
		base.FormBorderStyle = FormBorderStyle.None;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649049168);
		base.Padding = new Padding(1);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648898209);
		base.TopMost = true;
		base.Shown += ActivationWindow_Shown;
		panel_0.ResumeLayout(performLayout: false);
		panel_1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void method_3(bool bool_0)
	{
		base.UseWaitCursor = bool_0;
		label_0.Enabled = !bool_0;
		textBox_0.Enabled = !bool_0;
		textBox_1.Enabled = !bool_0;
		checkBox_0.Enabled = !bool_0;
		linkLabel_0.Enabled = !bool_0;
		textBox_2.Enabled = !bool_0;
		button_0.Enabled = !bool_0;
		comboBox_0.Enabled = !bool_0;
		linkLabel_1.Enabled = !bool_0;
		if (bool_0)
		{
			Application.DoEvents();
		}
	}

	private void linkLabel_0_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShellP(Class16.smethod_0(1649049199));
	}

	private void label_3_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void label_2_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			ReleaseCapture();
			SendMessage_1(base.Handle, 161, 2, 0);
		}
	}

	private void method_4(string string_0, string string_1)
	{
		method_3(bool_0: true);
		try
		{
			AceNative.AceStatusCode statusCode = license_INFO_0.AuthenticateUser(string_0, string_1, out userLicense_0);
			if (!AceNative.IsSuccess(statusCode))
			{
				method_3(bool_0: false);
				LicenseCredentials.ClearCredentials();
			}
			else if (userLicense_0 != null && userLicense_0.Length != 0)
			{
				string key = userLicense_0[0].key;
				bool flag = license_INFO_0.ActivateWithKey(key);
				method_3(bool_0: false);
				if (flag)
				{
					if (checkBox_0.Checked)
					{
						LicenseCredentials.SaveCredentials(string_0, string_1);
					}
					base.DialogResult = DialogResult.OK;
					Close();
				}
			}
			else
			{
				method_3(bool_0: false);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649049244));
			method_3(bool_0: false);
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		string text = textBox_0.Text.Trim();
		string text2 = textBox_1.Text;
		if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(text2))
		{
			return;
		}
		method_3(bool_0: true);
		try
		{
			AceNative.AceStatusCode statusCode = license_INFO_0.AuthenticateUser(text, text2, out userLicense_0);
			if (AceNative.IsSuccess(statusCode))
			{
				if (userLicense_0 != null && userLicense_0.Length != 0)
				{
					string key = userLicense_0[0].key;
					bool flag = license_INFO_0.ActivateWithKey(key);
					method_3(bool_0: false);
					if (flag)
					{
						if (checkBox_0.Checked)
						{
							LicenseCredentials.SaveCredentials(text, text2);
						}
						else
						{
							LicenseCredentials.ClearCredentials();
						}
						base.DialogResult = DialogResult.OK;
						Close();
					}
				}
				else
				{
					method_3(bool_0: false);
				}
			}
			else
			{
				method_3(bool_0: false);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649049272));
			method_3(bool_0: false);
		}
	}

	private void label_3_MouseEnter(object sender, EventArgs e)
	{
		label_3.ForeColor = Color.FromArgb(220, 50, 50);
	}

	private void label_3_MouseLeave(object sender, EventArgs e)
	{
		label_3.ForeColor = (TDark.IsDarkMode ? Color.FromArgb(180, 180, 180) : Color.FromArgb(100, 100, 100));
	}
}
