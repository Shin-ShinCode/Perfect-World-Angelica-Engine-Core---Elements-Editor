using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.IconEditor;

public sealed class ExportOptionsDialog : Form
{
	public enum ExportFormat
	{
		Auto,
		Png,
		Dds
	}

	private readonly TextBox textBox_0;

	private readonly RadioButton radioButton_0;

	private readonly RadioButton radioButton_1;

	private readonly RadioButton radioButton_2;

	private string string_0 = string.Empty;

	private ExportFormat exportFormat_0;

	public string SelectedPath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public ExportFormat SelectedFormat
	{
		[CompilerGenerated]
		get
		{
			return exportFormat_0;
		}
	}

	public ExportOptionsDialog(string defaultPath)
	{
		Text = TextStorage.Msg(Class16.smethod_0(1649051425), Class16.smethod_0(1649051471));
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.StartPosition = FormStartPosition.CenterParent;
		base.ShowInTaskbar = false;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.ClientSize = new Size(520, 230);
		method_0(Directory.Exists(defaultPath) ? defaultPath : Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 3,
			RowCount = 4,
			Padding = new Padding(12)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		base.Controls.Add(tableLayoutPanel);
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = TextStorage.Msg(Class16.smethod_0(1649051492), Class16.smethod_0(1649051515)),
			Anchor = AnchorStyles.Left,
			AutoSize = true
		}, 0, 0);
		textBox_0 = new TextBox
		{
			ReadOnly = true,
			Dock = DockStyle.Fill,
			Text = SelectedPath
		};
		tableLayoutPanel.Controls.Add(textBox_0, 1, 0);
		Button button = new Button
		{
			Text = TextStorage.Msg(Class16.smethod_0(1649051543), Class16.smethod_0(1648978102)),
			AutoSize = true
		};
		button.Click += method_2;
		tableLayoutPanel.Controls.Add(button, 2, 0);
		GroupBox groupBox = new GroupBox
		{
			Text = TextStorage.Msg(Class16.smethod_0(1649051567), Class16.smethod_0(1649051591)),
			Dock = DockStyle.Fill
		};
		tableLayoutPanel.Controls.Add(groupBox, 0, 2);
		tableLayoutPanel.SetColumnSpan(groupBox, 3);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			FlowDirection = FlowDirection.TopDown,
			WrapContents = false
		};
		groupBox.Controls.Add(flowLayoutPanel);
		radioButton_0 = new RadioButton
		{
			Text = TextStorage.Msg(Class16.smethod_0(1649051604), Class16.smethod_0(1649050631)),
			Checked = true,
			AutoSize = true
		};
		flowLayoutPanel.Controls.Add(radioButton_0);
		radioButton_1 = new RadioButton
		{
			Text = TextStorage.Msg(Class16.smethod_0(1649050665), Class16.smethod_0(1649050700)),
			AutoSize = true
		};
		flowLayoutPanel.Controls.Add(radioButton_1);
		radioButton_2 = new RadioButton
		{
			Text = TextStorage.Msg(Class16.smethod_0(1649050716), Class16.smethod_0(1649050743)),
			AutoSize = true
		};
		flowLayoutPanel.Controls.Add(radioButton_2);
		FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			FlowDirection = FlowDirection.RightToLeft
		};
		tableLayoutPanel.Controls.Add(flowLayoutPanel2, 0, 3);
		tableLayoutPanel.SetColumnSpan(flowLayoutPanel2, 3);
		Button button2 = new Button
		{
			Text = Class16.smethod_0(1648931384),
			AutoSize = true
		};
		button2.Click += method_3;
		flowLayoutPanel2.Controls.Add(button2);
		Button button3 = new Button
		{
			Text = TextStorage.Msg(Class16.smethod_0(1649050759), Class16.smethod_0(1648941799)),
			AutoSize = true
		};
		button3.Click += method_4;
		flowLayoutPanel2.Controls.Add(button3);
		TextStorage.TEXTS.SetFormLanguage(this);
	}

	private void method_0(string string_1)
	{
		string_0 = string_1;
	}

	private void method_1(ExportFormat exportFormat_1)
	{
		exportFormat_0 = exportFormat_1;
	}

	private void method_2(object sender, EventArgs e)
	{
		using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
		{
			Description = TextStorage.Msg(Class16.smethod_0(1649050783), Class16.smethod_0(1649050821)),
			SelectedPath = SelectedPath,
			ShowNewFolderButton = true
		};
		if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
		{
			method_0(folderBrowserDialog.SelectedPath);
			textBox_0.Text = SelectedPath;
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(SelectedPath) && Directory.Exists(SelectedPath))
		{
			if (radioButton_1.Checked)
			{
				method_1(ExportFormat.Png);
			}
			else if (radioButton_2.Checked)
			{
				method_1(ExportFormat.Dds);
			}
			else
			{
				method_1(ExportFormat.Auto);
			}
			base.DialogResult = DialogResult.OK;
		}
		else
		{
			MessageBox.Show(this, TextStorage.Msg(Class16.smethod_0(1649050840), Class16.smethod_0(1649050892)), TextStorage.Msg(Class16.smethod_0(1649056107), Class16.smethod_0(1649056149)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}
}
