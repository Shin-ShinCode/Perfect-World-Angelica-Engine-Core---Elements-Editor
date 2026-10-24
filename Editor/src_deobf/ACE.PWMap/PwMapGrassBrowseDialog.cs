using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.PWMap;

public sealed class PwMapGrassBrowseDialog : Form
{
	private string string_0 = string.Empty;

	private TreeView treeView_0;

	private PictureBox pictureBox_0;

	private TextBox textBox_0;

	private Button button_0;

	private Button button_1;

	private Label label_0;

	public string SelectedGrassPath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public PwMapGrassBrowseDialog()
	{
		Text = Class16.smethod_0(1649090297);
		base.Size = new Size(520, 420);
		base.StartPosition = FormStartPosition.CenterParent;
		base.FormBorderStyle = FormBorderStyle.Sizable;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.ShowInTaskbar = false;
		method_2();
		method_1();
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0(string string_1)
	{
		string_0 = string_1;
	}

	private void method_1()
	{
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
	}

	private void method_2()
	{
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			SplitterDistance = 240,
			FixedPanel = FixedPanel.Panel1
		};
		base.Controls.Add(splitContainer);
		Panel panel = new Panel
		{
			Dock = DockStyle.Top,
			Height = 26
		};
		Label value = new Label
		{
			Text = Class16.smethod_0(1648935725),
			Dock = DockStyle.Left,
			AutoSize = true,
			TextAlign = ContentAlignment.MiddleLeft
		};
		textBox_0 = new TextBox
		{
			Dock = DockStyle.Fill
		};
		textBox_0.TextChanged += textBox_0_TextChanged;
		panel.Controls.Add(textBox_0);
		panel.Controls.Add(value);
		splitContainer.Panel1.Controls.Add(panel);
		panel.BringToFront();
		treeView_0 = new TreeView
		{
			Dock = DockStyle.Fill,
			HideSelection = false,
			Sorted = true
		};
		treeView_0.AfterSelect += treeView_0_AfterSelect;
		treeView_0.NodeMouseDoubleClick += treeView_0_NodeMouseDoubleClick;
		splitContainer.Panel1.Controls.Add(treeView_0);
		label_0 = new Label
		{
			Dock = DockStyle.Top,
			Height = 20,
			ForeColor = Color.Gray,
			TextAlign = ContentAlignment.MiddleLeft
		};
		pictureBox_0 = new PictureBox
		{
			Dock = DockStyle.Fill,
			SizeMode = PictureBoxSizeMode.Zoom,
			BackColor = Color.FromArgb(50, 50, 50),
			BorderStyle = BorderStyle.FixedSingle
		};
		splitContainer.Panel2.Controls.Add(pictureBox_0);
		splitContainer.Panel2.Controls.Add(label_0);
		label_0.BringToFront();
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Bottom,
			Height = 38,
			FlowDirection = FlowDirection.RightToLeft,
			Padding = new Padding(4)
		};
		button_1 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			Width = 80,
			DialogResult = DialogResult.Cancel
		};
		button_0 = new Button
		{
			Text = Class16.smethod_0(1648938905),
			Width = 80,
			DialogResult = DialogResult.OK,
			Enabled = false
		};
		flowLayoutPanel.Controls.Add(button_1);
		flowLayoutPanel.Controls.Add(button_0);
		base.Controls.Add(flowLayoutPanel);
		flowLayoutPanel.BringToFront();
		base.AcceptButton = button_0;
		base.CancelButton = button_1;
	}

	public void PopulateFromPaths(IEnumerable<string> paths)
	{
		treeView_0.BeginUpdate();
		treeView_0.Nodes.Clear();
		foreach (string path in paths)
		{
			string text = System.IO.Path.GetExtension(path).ToLowerInvariant();
			if (!(text != Class16.smethod_0(1649090323)) || !(text != Class16.smethod_0(1649094375)) || !(text != Class16.smethod_0(1648906325)))
			{
				string fileName = System.IO.Path.GetFileName(path);
				TreeNode node = new TreeNode(fileName)
				{
					Tag = path,
					ToolTipText = path
				};
				treeView_0.Nodes.Add(node);
			}
		}
		treeView_0.EndUpdate();
	}

	public void PopulateFromFolder(string folder)
	{
		if (Directory.Exists(folder))
		{
			string[] files = Directory.GetFiles(folder, Class16.smethod_0(1649090342), SearchOption.AllDirectories);
			PopulateFromPaths(files);
		}
	}

	private void treeView_0_AfterSelect(object sender, TreeViewEventArgs e)
	{
		string text = e.Node?.Tag as string;
		button_0.Enabled = !string.IsNullOrEmpty(text);
		label_0.Text = text ?? string.Empty;
		method_0(text ?? string.Empty);
		method_3(text);
	}

	private void method_3(string string_1)
	{
		pictureBox_0.Image?.Dispose();
		pictureBox_0.Image = null;
		if (string.IsNullOrEmpty(string_1))
		{
			return;
		}
		string text = System.IO.Path.ChangeExtension(string_1, Class16.smethod_0(1649008311));
		try
		{
			if (File.Exists(text))
			{
				pictureBox_0.Image = Image.FromFile(text);
			}
		}
		catch
		{
		}
	}

	private void method_4()
	{
		string value = textBox_0.Text.Trim();
		foreach (TreeNode node in treeView_0.Nodes)
		{
			bool flag = string.IsNullOrEmpty(value) || node.Text.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
			node.ForeColor = (flag ? treeView_0.ForeColor : Color.DimGray);
		}
	}

	private void method_5()
	{
		if (!string.IsNullOrEmpty(SelectedGrassPath))
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		method_4();
	}

	private void treeView_0_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		method_5();
	}
}
