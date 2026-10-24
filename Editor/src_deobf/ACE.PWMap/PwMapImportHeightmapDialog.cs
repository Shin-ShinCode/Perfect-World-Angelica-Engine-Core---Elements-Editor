using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.PWMap;

public sealed class PwMapImportHeightmapDialog : Form
{
	private TextBox textBox_0;

	private Button button_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private CheckBox checkBox_0;

	private PictureBox pictureBox_0;

	private Button button_1;

	private Button button_2;

	public string SelectedFilePath
	{
		get
		{
			TextBox textBox = textBox_0;
			object obj;
			if (textBox == null)
			{
				obj = null;
			}
			else
			{
				obj = textBox.Text;
				if (obj != null)
				{
					goto IL_001b;
				}
			}
			obj = string.Empty;
			goto IL_001b;
			IL_001b:
			return (string)obj;
		}
	}

	public float MinHeight
	{
		get
		{
			float.TryParse(textBox_1?.Text, out var result);
			return result;
		}
	}

	public float MaxHeight
	{
		get
		{
			if (float.TryParse(textBox_2?.Text, out var result))
			{
				return result;
			}
			return 200f;
		}
	}

	public bool ApplySmooth => checkBox_0?.Checked ?? false;

	public PwMapImportHeightmapDialog()
	{
		Text = Class16.smethod_0(1649090346);
		base.Size = new Size(480, 400);
		base.StartPosition = FormStartPosition.CenterParent;
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		method_1();
		method_0();
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0()
	{
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
	}

	private void method_1()
	{
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 3,
			RowCount = 6,
			Padding = new Padding(8)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 36f));
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1648916193),
			AutoSize = true
		}, 0, 0);
		textBox_0 = new TextBox
		{
			Dock = DockStyle.Fill,
			ReadOnly = true
		};
		tableLayoutPanel.Controls.Add(textBox_0, 1, 0);
		button_0 = new Button
		{
			Text = Class16.smethod_0(1649090369),
			Dock = DockStyle.Fill
		};
		button_0.Click += button_0_Click;
		tableLayoutPanel.Controls.Add(button_0, 2, 0);
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649090390),
			AutoSize = true
		}, 0, 1);
		textBox_1 = new TextBox
		{
			Dock = DockStyle.Fill,
			Text = Class16.smethod_0(1648924112)
		};
		tableLayoutPanel.Controls.Add(textBox_1, 1, 1);
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649090400),
			AutoSize = true
		}, 0, 2);
		textBox_2 = new TextBox
		{
			Dock = DockStyle.Fill,
			Text = Class16.smethod_0(1649090418)
		};
		tableLayoutPanel.Controls.Add(textBox_2, 1, 2);
		checkBox_0 = new CheckBox
		{
			Text = Class16.smethod_0(1649090436),
			AutoSize = true
		};
		tableLayoutPanel.SetColumnSpan(checkBox_0, 3);
		tableLayoutPanel.Controls.Add(checkBox_0, 0, 3);
		pictureBox_0 = new PictureBox
		{
			Dock = DockStyle.Fill,
			SizeMode = PictureBoxSizeMode.Zoom,
			BorderStyle = BorderStyle.FixedSingle,
			BackColor = Color.FromArgb(30, 30, 30)
		};
		tableLayoutPanel.SetColumnSpan(pictureBox_0, 3);
		tableLayoutPanel.Controls.Add(pictureBox_0, 0, 4);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			FlowDirection = FlowDirection.RightToLeft,
			WrapContents = false
		};
		button_2 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			DialogResult = DialogResult.Cancel
		};
		button_1 = new Button
		{
			Text = Class16.smethod_0(1648931405),
			DialogResult = DialogResult.OK
		};
		flowLayoutPanel.Controls.Add(button_2);
		flowLayoutPanel.Controls.Add(button_1);
		tableLayoutPanel.SetColumnSpan(flowLayoutPanel, 3);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 5);
		base.AcceptButton = button_1;
		base.CancelButton = button_2;
		base.Controls.Add(tableLayoutPanel);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		try
		{
			openFileDialog.Title = TextStorage.Msg(Class16.smethod_0(1649090450));
			openFileDialog.Filter = Class16.smethod_0(1649090487);
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				textBox_0.Text = openFileDialog.FileName;
				method_2(openFileDialog.FileName);
			}
		}
		finally
		{
			((IDisposable)openFileDialog).Dispose();
		}
	}

	private void method_2(string string_0)
	{
		try
		{
			if (!File.Exists(string_0))
			{
				return;
			}
			string text = System.IO.Path.GetExtension(string_0).ToLowerInvariant();
			if (text == Class16.smethod_0(1649089551))
			{
				pictureBox_0.Image = null;
				return;
			}
			pictureBox_0.Image?.Dispose();
			using FileStream stream = File.OpenRead(string_0);
			pictureBox_0.Image = Image.FromStream(stream);
		}
		catch
		{
			pictureBox_0.Image = null;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			pictureBox_0?.Image?.Dispose();
		}
		base.Dispose(disposing);
	}
}
