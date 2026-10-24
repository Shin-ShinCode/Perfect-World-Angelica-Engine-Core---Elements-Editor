using System;
using System.Drawing;
using System.Windows.Forms;

namespace ACE.Classes;

public static class DKBox
{
	private sealed class Form0 : Form
	{
		private bool bool_0;

		private readonly Color color_0 = Color.FromArgb(32, 32, 32);

		private readonly Color color_1 = Color.FromArgb(45, 45, 48);

		private readonly Color color_2 = Color.FromArgb(240, 240, 240);

		private readonly Color color_3 = Color.FromArgb(58, 58, 60);

		private readonly Color color_4 = Color.FromArgb(85, 85, 85);

		private readonly Color color_5 = Color.FromArgb(75, 75, 78);

		private readonly Color color_6 = Color.FromArgb(28, 88, 40);

		private readonly Color color_7 = Color.FromArgb(40, 110, 50);

		private readonly Color color_8 = Color.FromArgb(35, 100, 45);

		private readonly Color color_9 = Color.FromArgb(120, 30, 30);

		private readonly Color color_10 = Color.FromArgb(150, 40, 40);

		private readonly Color color_11 = Color.FromArgb(140, 35, 35);

		public Form0(string string_0, string string_1, MessageBoxButtons messageBoxButtons_0, MessageBoxIcon messageBoxIcon_0, Rectangle workingArea, MessageBoxDefaultButton messageBoxDefaultButton_0 = MessageBoxDefaultButton.Button1, string yesButtonText = null, string noButtonText = null)
		{
			Text = string_1;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.StartPosition = FormStartPosition.CenterParent;
			base.TopMost = false;
			BackColor = color_0;
			ForeColor = color_2;
			if (base.IsHandleCreated)
			{
				TDark.ApplyImmersiveDarkMode(base.Handle, enabled: true);
			}
			Font font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular);
			if (workingArea.Width <= 0 || workingArea.Height <= 0)
			{
				workingArea = Screen.PrimaryScreen != null ? Screen.PrimaryScreen.WorkingArea : new Rectangle(0, 0, 1024, 768);
			}
			int maxWidth = Math.Max(240, Math.Min(760, workingArea.Width - 56));
			int minWidth = Math.Min(350, maxWidth);
			int textLeft = messageBoxIcon_0 != MessageBoxIcon.None ? 67 : 20;
			int maxTextWidth = Math.Max(160, maxWidth - textLeft - 20);
			string message = string_0 ?? string.Empty;
			TextFormatFlags textFlags = TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl | TextFormatFlags.NoPrefix;
			Size measured = TextRenderer.MeasureText(message, font, new Size(maxTextWidth, int.MaxValue), textFlags);
			int width = Math.Max(minWidth, Math.Min(maxWidth, measured.Width + textLeft + 20));
			int textWidth = Math.Max(160, width - textLeft - 20);
			Size textSize = TextRenderer.MeasureText(message, font, new Size(textWidth, int.MaxValue), textFlags);
			int labelHeight = Math.Max(32, textSize.Height);
			const int footerHeight = 55;
			int maxClientHeight = Math.Max(150, workingArea.Height - 80);
			int desiredBodyHeight = labelHeight + 40;
			int bodyHeight = Math.Min(desiredBodyHeight, Math.Max(95, maxClientHeight - footerHeight));
			base.ClientSize = new Size(width, bodyHeight + footerHeight);
			Panel body = new Panel
			{
				Dock = DockStyle.Fill,
				AutoScroll = true,
				BackColor = color_0
			};
			body.AutoScrollMinSize = new Size(0, labelHeight + 40);
			if (messageBoxIcon_0 != MessageBoxIcon.None)
			{
				PictureBox value = new PictureBox
				{
					Image = method_0(messageBoxIcon_0),
					SizeMode = PictureBoxSizeMode.StretchImage,
					Size = new Size(32, 32),
					Location = new Point(20, 20),
					BackColor = Color.Transparent
				};
				body.Controls.Add(value);
			}
			Label value2 = new Label
			{
				Text = message,
				Location = new Point(textLeft, 20),
				Size = new Size(textWidth, labelHeight),
				Font = font,
				ForeColor = color_2,
				BackColor = Color.Transparent,
				TextAlign = ContentAlignment.TopLeft,
				AutoSize = false,
				UseMnemonic = false
			};
			body.Controls.Add(value2);
			base.Controls.Add(body);
			FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
			{
				Dock = DockStyle.Bottom,
				Height = footerHeight,
				BackColor = color_1,
				FlowDirection = FlowDirection.RightToLeft,
				Padding = new Padding(15, 12, 15, 12)
			};
			base.Controls.Add(flowLayoutPanel);
			method_1(flowLayoutPanel, messageBoxButtons_0, messageBoxDefaultButton_0, yesButtonText, noButtonText);
			DialogResult defaultResult = DialogResult.OK;
			switch (messageBoxButtons_0)
			{
			case MessageBoxButtons.OKCancel:
				defaultResult = messageBoxDefaultButton_0 == MessageBoxDefaultButton.Button2 ? DialogResult.Cancel : DialogResult.OK;
				break;
			case MessageBoxButtons.YesNo:
				defaultResult = messageBoxDefaultButton_0 == MessageBoxDefaultButton.Button2 ? DialogResult.No : DialogResult.Yes;
				break;
			case MessageBoxButtons.YesNoCancel:
				defaultResult = messageBoxDefaultButton_0 switch
				{
					MessageBoxDefaultButton.Button2 => DialogResult.No,
					MessageBoxDefaultButton.Button3 => DialogResult.Cancel,
					_ => DialogResult.Yes
				};
				break;
			case MessageBoxButtons.AbortRetryIgnore:
				defaultResult = messageBoxDefaultButton_0 switch
				{
					MessageBoxDefaultButton.Button2 => DialogResult.Retry,
					MessageBoxDefaultButton.Button3 => DialogResult.Ignore,
					_ => DialogResult.Abort
				};
				break;
			case MessageBoxButtons.RetryCancel:
				defaultResult = messageBoxDefaultButton_0 == MessageBoxDefaultButton.Button2 ? DialogResult.Cancel : DialogResult.Retry;
				break;
			}
			foreach (Control control in flowLayoutPanel.Controls)
			{
				if (control is Button button && button.DialogResult == defaultResult)
				{
					base.AcceptButton = button;
					base.ActiveControl = button;
					break;
				}
			}
		}

		protected override void OnShown(EventArgs eventArgs_0)
		{
			base.OnShown(eventArgs_0);
			if (base.Owner == null)
			{
				bool_0 = true;
				base.TopMost = true;
				BringToFront();
				Activate();
				BeginInvoke(new Action(method_3));
			}
			else
			{
				BringToFront();
				Activate();
			}
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			TDark.ApplyImmersiveDarkMode(base.Handle, enabled: true);
		}

		private Image method_0(MessageBoxIcon messageBoxIcon_0)
		{
			return messageBoxIcon_0 switch
			{
				MessageBoxIcon.Question => SystemIcons.Question.ToBitmap(), 
				MessageBoxIcon.Hand => SystemIcons.Error.ToBitmap(), 
				MessageBoxIcon.Asterisk => SystemIcons.Information.ToBitmap(), 
				MessageBoxIcon.Exclamation => SystemIcons.Warning.ToBitmap(), 
				_ => null, 
			};
		}

		private void method_1(FlowLayoutPanel flowLayoutPanel_0, MessageBoxButtons messageBoxButtons_0, MessageBoxDefaultButton messageBoxDefaultButton_0, string yesButtonText, string noButtonText)
		{
			switch (messageBoxButtons_0)
			{
			case MessageBoxButtons.OK:
				method_2(flowLayoutPanel_0, Class16.smethod_0(1648938905), DialogResult.OK, bool_1: true);
				break;
			case MessageBoxButtons.OKCancel:
				method_2(flowLayoutPanel_0, Class16.smethod_0(1648941799), DialogResult.Cancel, bool_1: false);
				method_2(flowLayoutPanel_0, Class16.smethod_0(1648938905), DialogResult.OK, bool_1: true);
				break;
			case MessageBoxButtons.AbortRetryIgnore:
				method_2(flowLayoutPanel_0, Class16.smethod_0(1648908458), DialogResult.Ignore, bool_1: false);
				method_2(flowLayoutPanel_0, Class16.smethod_0(1648908454), DialogResult.Retry, bool_1: true);
				method_2(flowLayoutPanel_0, Class16.smethod_0(1648908479), DialogResult.Abort, bool_1: false);
				break;
			case MessageBoxButtons.YesNoCancel:
				method_2(flowLayoutPanel_0, Class16.smethod_0(1648941799), DialogResult.Cancel, bool_1: false);
				method_2(flowLayoutPanel_0, noButtonText ?? Class16.smethod_0(1648908427), DialogResult.No, bool_1: false);
				method_2(flowLayoutPanel_0, yesButtonText ?? Class16.smethod_0(1648908444), DialogResult.Yes, bool_1: true);
				break;
			case MessageBoxButtons.YesNo:
				method_2(flowLayoutPanel_0, noButtonText ?? Class16.smethod_0(1648908427), DialogResult.No, bool_1: false);
				method_2(flowLayoutPanel_0, yesButtonText ?? Class16.smethod_0(1648908444), DialogResult.Yes, bool_1: true);
				break;
			case MessageBoxButtons.RetryCancel:
				method_2(flowLayoutPanel_0, Class16.smethod_0(1648941799), DialogResult.Cancel, bool_1: false);
				method_2(flowLayoutPanel_0, Class16.smethod_0(1648908454), DialogResult.Retry, bool_1: true);
				break;
			}
		}

		private Button method_2(FlowLayoutPanel flowLayoutPanel_0, string string_0, DialogResult dialogResult_0, bool bool_1)
		{
			Button button = new Button
			{
				Text = string_0,
				DialogResult = dialogResult_0,
				AutoSize = true,
				Padding = new Padding(15, 3, 15, 3),
				MinimumSize = new Size(80, 28),
				Margin = new Padding(8, 0, 0, 0),
				Cursor = Cursors.Hand,
				Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular),
				FlatStyle = FlatStyle.Flat
			};
			button.FlatAppearance.BorderSize = 1;
			if (dialogResult_0 != DialogResult.Cancel && dialogResult_0 != DialogResult.No && dialogResult_0 != DialogResult.Abort)
			{
				if (bool_1)
				{
					button.BackColor = color_6;
					button.FlatAppearance.BorderColor = color_7;
					button.FlatAppearance.MouseOverBackColor = color_8;
					button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(color_6);
				}
				else
				{
					button.BackColor = color_3;
					button.FlatAppearance.BorderColor = color_4;
					button.FlatAppearance.MouseOverBackColor = color_5;
					button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(color_3);
				}
			}
			else
			{
				button.BackColor = color_9;
				button.FlatAppearance.BorderColor = color_10;
				button.FlatAppearance.MouseOverBackColor = color_11;
				button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(color_9);
			}
			button.ForeColor = Color.White;
			flowLayoutPanel_0.Controls.Add(button);
			switch (dialogResult_0)
			{
			case DialogResult.Cancel:
			case DialogResult.Abort:
			case DialogResult.No:
				base.CancelButton = button;
				break;
			case DialogResult.OK:
			case DialogResult.Retry:
			case DialogResult.Yes:
				base.AcceptButton = button;
				break;
			}
			return button;
		}

		protected override void OnFormClosing(FormClosingEventArgs formClosingEventArgs_0)
		{
			base.OnFormClosing(formClosingEventArgs_0);
			if (base.DialogResult == DialogResult.None && formClosingEventArgs_0.CloseReason == CloseReason.UserClosing)
			{
				if (base.CancelButton != null)
				{
					base.DialogResult = base.CancelButton.DialogResult;
				}
				else
				{
					base.DialogResult = DialogResult.Cancel;
				}
			}
		}

		private void method_3()
		{
			if (bool_0 && !base.IsDisposed)
			{
				base.TopMost = false;
				bool_0 = false;
			}
		}
	}

	private static IWin32Window smethod_0(IWin32Window iwin32Window_0)
	{
		if (iwin32Window_0 is Form form && smethod_1(form))
		{
			return form;
		}
		Form activeForm = Form.ActiveForm;
		if (smethod_1(activeForm))
		{
			return activeForm;
		}
		int num = Application.OpenForms.Count - 1;
		Form form2;
		while (true)
		{
			if (num >= 0)
			{
				form2 = Application.OpenForms[num];
				if (smethod_1(form2) && (form2.ContainsFocus || form2.Focused || form2.Modal))
				{
					break;
				}
				num--;
				continue;
			}
			int num2 = Application.OpenForms.Count - 1;
			Form form3;
			while (true)
			{
				if (num2 >= 0)
				{
					form3 = Application.OpenForms[num2];
					if (smethod_1(form3))
					{
						break;
					}
					num2--;
					continue;
				}
				return iwin32Window_0;
			}
			return form3;
		}
		return form2;
	}

	private static bool smethod_1(Form form_0)
	{
		if (form_0 != null && !form_0.IsDisposed && form_0.IsHandleCreated)
		{
			return form_0.Visible;
		}
		return false;
	}

	private static Rectangle GetWorkingArea(IWin32Window owner)
	{
		if (owner is Control control && !control.IsDisposed && control.IsHandleCreated)
		{
			return Screen.FromControl(control).WorkingArea;
		}
		Form activeForm = Form.ActiveForm;
		if (activeForm != null && !activeForm.IsDisposed && activeForm.IsHandleCreated)
		{
			return Screen.FromControl(activeForm).WorkingArea;
		}
		return Screen.PrimaryScreen != null ? Screen.PrimaryScreen.WorkingArea : new Rectangle(0, 0, 1024, 768);
	}

	public static DialogResult Show(string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
	{
		IWin32Window win32Window = smethod_0(null);
		if (!TDark.IsDarkMode)
		{
			if (win32Window == null)
			{
				return MessageBox.Show(text, caption, buttons, icon);
			}
			return MessageBox.Show(win32Window, text, caption, buttons, icon);
		}
		Form0 form = new Form0(text, caption, buttons, icon, GetWorkingArea(win32Window));
		try
		{
			form.StartPosition = ((win32Window == null) ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent);
			return (win32Window != null) ? form.ShowDialog(win32Window) : form.ShowDialog();
		}
		finally
		{
			((IDisposable)form).Dispose();
		}
	}

	public static DialogResult ShowYesNo(string text, string caption, MessageBoxIcon icon, string yesButtonText, string noButtonText)
	{
		IWin32Window owner = smethod_0(null);
		if (!TDark.IsDarkMode)
		{
			return owner == null
				? MessageBox.Show(text, caption, MessageBoxButtons.YesNo, icon, MessageBoxDefaultButton.Button2)
				: MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo, icon, MessageBoxDefaultButton.Button2);
		}

		Form0 form = new Form0(text, caption, MessageBoxButtons.YesNo, icon, GetWorkingArea(owner), MessageBoxDefaultButton.Button2, yesButtonText, noButtonText);
		try
		{
			form.StartPosition = owner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;
			return owner == null ? form.ShowDialog() : form.ShowDialog(owner);
		}
		finally
		{
			((IDisposable)form).Dispose();
		}
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
	{
		owner = smethod_0(owner);
		if (!TDark.IsDarkMode)
		{
			if (owner == null)
			{
				return MessageBox.Show(text, caption, buttons, icon);
			}
			return MessageBox.Show(owner, text, caption, buttons, icon);
		}
		Form0 form = new Form0(text, caption, buttons, icon, GetWorkingArea(owner));
		try
		{
			form.StartPosition = ((owner == null) ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent);
			return form.ShowDialog(owner);
		}
		finally
		{
			((IDisposable)form).Dispose();
		}
	}

	public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
	{
		IWin32Window win32Window = smethod_0(null);
		if (!TDark.IsDarkMode)
		{
			if (win32Window == null)
			{
				return MessageBox.Show(text, caption, buttons, icon, defaultButton);
			}
			return MessageBox.Show(win32Window, text, caption, buttons, icon, defaultButton);
		}
		Form0 form = new Form0(text, caption, buttons, icon, GetWorkingArea(win32Window), defaultButton);
		try
		{
			form.StartPosition = ((win32Window == null) ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent);
			return (win32Window != null) ? form.ShowDialog(win32Window) : form.ShowDialog();
		}
		finally
		{
			((IDisposable)form).Dispose();
		}
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
	{
		owner = smethod_0(owner);
		if (!TDark.IsDarkMode)
		{
			if (owner == null)
			{
				return MessageBox.Show(text, caption, buttons, icon, defaultButton);
			}
			return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton);
		}
		Form0 form = new Form0(text, caption, buttons, icon, GetWorkingArea(owner), defaultButton);
		try
		{
			form.StartPosition = ((owner == null) ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent);
			return form.ShowDialog(owner);
		}
		finally
		{
			((IDisposable)form).Dispose();
		}
	}
}
