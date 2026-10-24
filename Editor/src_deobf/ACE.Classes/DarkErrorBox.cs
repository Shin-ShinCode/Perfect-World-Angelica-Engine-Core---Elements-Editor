using System;
using System.Drawing;
using System.Windows.Forms;

namespace ACE.Classes;

public static class DarkErrorBox
{
	private sealed class Form1 : Form
	{
		private Label label_0;

		private TextBox textBox_0;

		private Button button_0;

		private Button button_1;

		private PictureBox pictureBox_0;

		private Exception exception_0;

		private bool bool_0;

		public Form1(string string_0, string string_1, Exception exception_1)
		{
			exception_0 = exception_1;
			Text = string_1;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Padding = new Padding(20);
			AutoSize = true;
			base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			MinimumSize = new Size(400, 150);
			method_0(string_0);
			TDark.ApplyNativeDarkThemeRecursive(this);
			BackColor = TDark.DarkBack;
			ForeColor = TDark.DarkFore;
		}

		private void method_0(string string_0)
		{
			TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
			{
				Dock = DockStyle.Fill,
				ColumnCount = 2,
				RowCount = 3,
				AutoSize = true,
				Padding = new Padding(0)
			};
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50f));
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			pictureBox_0 = new PictureBox
			{
				SizeMode = PictureBoxSizeMode.CenterImage,
				Image = SystemIcons.Error.ToBitmap(),
				Size = new Size(32, 32),
				Margin = new Padding(0, 0, 10, 0)
			};
			tableLayoutPanel.Controls.Add(pictureBox_0, 0, 0);
			label_0 = new Label
			{
				Text = string_0,
				AutoSize = true,
				MaximumSize = new Size(500, 0),
				TextAlign = ContentAlignment.MiddleLeft,
				Font = SystemFonts.MessageBoxFont,
				Margin = new Padding(0, 5, 0, 20)
			};
			tableLayoutPanel.Controls.Add(label_0, 1, 0);
			FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
			{
				FlowDirection = FlowDirection.RightToLeft,
				AutoSize = true,
				Dock = DockStyle.Fill,
				Margin = new Padding(0)
			};
			button_1 = new Button
			{
				Text = Class16.smethod_0(1648938905),
				DialogResult = DialogResult.OK,
				AutoSize = true,
				Padding = new Padding(10, 5, 10, 5),
				MinimumSize = new Size(75, 30),
				FlatStyle = FlatStyle.Flat
			};
			flowLayoutPanel.Controls.Add(button_1);
			if (exception_0 != null)
			{
				button_0 = new Button
				{
					Text = Class16.smethod_0(1648908483),
					AutoSize = true,
					Padding = new Padding(10, 5, 10, 5),
					MinimumSize = new Size(75, 30),
					FlatStyle = FlatStyle.Flat,
					Margin = new Padding(0, 0, 10, 0)
				};
				button_0.Click += button_0_Click;
				flowLayoutPanel.Controls.Add(button_0);
			}
			tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 1);
			textBox_0 = new TextBox
			{
				Multiline = true,
				ReadOnly = true,
				ScrollBars = ScrollBars.Vertical,
				Visible = false,
				Dock = DockStyle.Fill,
				Height = 200,
				Text = exception_0?.ToString(),
				Font = new Font(Class16.smethod_0(1648929975), 9f),
				Margin = new Padding(0, 10, 0, 0)
			};
			tableLayoutPanel.Controls.Add(textBox_0, 0, 2);
			tableLayoutPanel.SetColumnSpan(textBox_0, 2);
			base.Controls.Add(tableLayoutPanel);
			base.AcceptButton = button_1;
		}

		private void method_1()
		{
			bool_0 = !bool_0;
			textBox_0.Visible = bool_0;
			button_0.Text = (bool_0 ? Class16.smethod_0(1648908516) : Class16.smethod_0(1648908483));
			if (bool_0)
			{
				MaximumSize = new Size(600, 600);
			}
			else
			{
				MaximumSize = Size.Empty;
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			method_1();
		}
	}

	public static void Show(string message, string title = "Error", Exception ex = null)
	{
		if (!TDark.IsDarkMode)
		{
			MessageBox.Show(message + ((ex != null) ? (Class16.smethod_0(1648908541) + ex.Message) : string.Empty), title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		Form1 form = new Form1(message, title, ex);
		try
		{
			form.ShowDialog();
		}
		finally
		{
			((IDisposable)form).Dispose();
		}
	}
}
