using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.PWMap;

public sealed class PwMapTextureBrowseDialog : Form
{
	private string string_0 = string.Empty;

	private string string_1 = Class16.smethod_0(1649121484);

	private TreeView treeView_0;

	private PictureBox pictureBox_0;

	private TextBox textBox_0;

	private Button button_0;

	private Button button_1;

	private Label label_0;

	public string SelectedTexturePath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public string TextureFolder
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public PwMapTextureBrowseDialog()
	{
		Text = Class16.smethod_0(1649203635);
		base.Size = new Size(640, 480);
		base.StartPosition = FormStartPosition.CenterParent;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.FormBorderStyle = FormBorderStyle.Sizable;
		base.ShowInTaskbar = false;
		method_2();
		method_1();
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0(string string_2)
	{
		string_0 = string_2;
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
			SplitterDistance = 250,
			FixedPanel = FixedPanel.Panel1
		};
		base.Controls.Add(splitContainer);
		Panel panel = new Panel
		{
			Dock = DockStyle.Top,
			Height = 28
		};
		textBox_0 = new TextBox
		{
			Dock = DockStyle.Fill
		};
		textBox_0.TextChanged += textBox_0_TextChanged;
		Label value = new Label
		{
			Text = Class16.smethod_0(1648935725),
			AutoSize = true,
			Dock = DockStyle.Left,
			TextAlign = ContentAlignment.MiddleLeft
		};
		panel.Controls.Add(textBox_0);
		panel.Controls.Add(value);
		splitContainer.Panel1.Controls.Add(panel);
		panel.BringToFront();
		treeView_0 = new TreeView
		{
			Dock = DockStyle.Fill,
			HideSelection = false,
			PathSeparator = Class16.smethod_0(1648892117)
		};
		treeView_0.AfterSelect += treeView_0_AfterSelect;
		treeView_0.NodeMouseDoubleClick += treeView_0_NodeMouseDoubleClick;
		splitContainer.Panel1.Controls.Add(treeView_0);
		pictureBox_0 = new PictureBox
		{
			Dock = DockStyle.Fill,
			SizeMode = PictureBoxSizeMode.Zoom,
			BackColor = Color.FromArgb(40, 40, 40),
			BorderStyle = BorderStyle.FixedSingle
		};
		splitContainer.Panel2.Controls.Add(pictureBox_0);
		label_0 = new Label
		{
			Dock = DockStyle.Top,
			Height = 20,
			TextAlign = ContentAlignment.MiddleLeft,
			ForeColor = Color.Gray
		};
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
			if (method_3(path))
			{
				method_4(path);
			}
		}
		treeView_0.EndUpdate();
	}

	private bool method_3(string string_2)
	{
		if (string.IsNullOrEmpty(TextureFolder))
		{
			return true;
		}
		return string_2.Replace('\\', '/').StartsWith(TextureFolder + Class16.smethod_0(1648892117), StringComparison.OrdinalIgnoreCase);
	}

	private void method_4(string string_2)
	{
		string[] array = string_2.Replace('\\', '/').Split('/');
		TreeNodeCollection nodes = treeView_0.Nodes;
		TreeNode treeNode = null;
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			TreeNode treeNode2 = nodes[text];
			if (treeNode2 == null)
			{
				treeNode2 = new TreeNode(text)
				{
					Name = text
				};
				if (i == array.Length - 1)
				{
					treeNode2.Tag = string_2;
				}
				nodes.Add(treeNode2);
			}
			treeNode = treeNode2;
			nodes = treeNode.Nodes;
		}
	}

	private void treeView_0_AfterSelect(object sender, TreeViewEventArgs e)
	{
		string text = e.Node?.Tag as string;
		button_0.Enabled = !string.IsNullOrEmpty(text);
		label_0.Text = text ?? string.Empty;
		method_0(text ?? string.Empty);
		method_5(text);
	}

	private void method_5(string string_2)
	{
		pictureBox_0.Image?.Dispose();
		pictureBox_0.Image = null;
		if (string.IsNullOrEmpty(string_2))
		{
			return;
		}
		try
		{
			string text = System.IO.Path.GetExtension(string_2).ToLowerInvariant();
			if ((text == Class16.smethod_0(1648904847) || text == Class16.smethod_0(1648904836) || text == Class16.smethod_0(1649008314) || text == Class16.smethod_0(1649008311) || text == Class16.smethod_0(1649008300)) && File.Exists(string_2))
			{
				pictureBox_0.Image = Image.FromFile(string_2);
			}
		}
		catch
		{
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		string text = textBox_0.Text.Trim();
		if (string.IsNullOrEmpty(text))
		{
			smethod_1(treeView_0.Nodes);
		}
		else
		{
			smethod_0(treeView_0.Nodes, text);
		}
	}

	private static bool smethod_0(TreeNodeCollection treeNodeCollection_0, string string_2)
	{
		bool result = false;
		foreach (TreeNode item in treeNodeCollection_0)
		{
			bool flag = smethod_0(item.Nodes, string_2);
			if (item.Text.IndexOf(string_2, StringComparison.OrdinalIgnoreCase) >= 0 || flag)
			{
				item.Expand();
				result = true;
			}
			else
			{
				item.Collapse();
			}
		}
		return result;
	}

	private static void smethod_1(TreeNodeCollection treeNodeCollection_0)
	{
		foreach (TreeNode item in treeNodeCollection_0)
		{
			item.Collapse();
			smethod_1(item.Nodes);
		}
	}

	private void method_6()
	{
		if (!string.IsNullOrEmpty(SelectedTexturePath))
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void treeView_0_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		method_6();
	}
}
