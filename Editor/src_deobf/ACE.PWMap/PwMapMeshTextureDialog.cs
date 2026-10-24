using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.PWMap;

public sealed class PwMapMeshTextureDialog : Form
{
	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private string string_2 = string.Empty;

	private TreeView treeView_0;

	private PictureBox pictureBox_0;

	private Label label_0;

	private Label label_1;

	private Button button_0;

	private Button button_1;

	public string SelectedTexturePath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public string MeshName
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

	public string CurrentTexture
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public PwMapMeshTextureDialog()
	{
		Text = Class16.smethod_0(1649089765);
		base.Size = new Size(580, 440);
		base.StartPosition = FormStartPosition.CenterParent;
		base.FormBorderStyle = FormBorderStyle.Sizable;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.ShowInTaskbar = false;
		method_2();
		method_1();
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0(string string_3)
	{
		string_0 = string_3;
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
			SplitterDistance = 230,
			FixedPanel = FixedPanel.Panel1
		};
		base.Controls.Add(splitContainer);
		treeView_0 = new TreeView
		{
			Dock = DockStyle.Fill,
			HideSelection = false,
			PathSeparator = Class16.smethod_0(1648892117),
			Sorted = true
		};
		treeView_0.AfterSelect += treeView_0_AfterSelect;
		treeView_0.NodeMouseDoubleClick += treeView_0_NodeMouseDoubleClick;
		splitContainer.Panel1.Controls.Add(treeView_0);
		Panel panel = new Panel
		{
			Dock = DockStyle.Top,
			Height = 50
		};
		label_0 = new Label
		{
			Text = Class16.smethod_0(1649089776),
			Location = new Point(4, 4),
			AutoSize = true,
			ForeColor = Color.Gray
		};
		label_1 = new Label
		{
			Text = Class16.smethod_0(1649089806),
			Location = new Point(4, 24),
			AutoSize = true
		};
		panel.Controls.AddRange(new Control[2] { label_0, label_1 });
		splitContainer.Panel2.Controls.Add(panel);
		panel.BringToFront();
		pictureBox_0 = new PictureBox
		{
			Dock = DockStyle.Fill,
			SizeMode = PictureBoxSizeMode.Zoom,
			BackColor = Color.FromArgb(45, 45, 45),
			BorderStyle = BorderStyle.FixedSingle
		};
		splitContainer.Panel2.Controls.Add(pictureBox_0);
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
			Enabled = false,
			DialogResult = DialogResult.OK
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
			if (!(text != Class16.smethod_0(1648904847)) || !(text != Class16.smethod_0(1648904836)) || !(text != Class16.smethod_0(1649008314)) || !(text != Class16.smethod_0(1649008311)))
			{
				method_3(path);
			}
		}
		treeView_0.EndUpdate();
		label_0.Text = TextStorage.Msg(Class16.smethod_0(1649089829), Class16.smethod_0(1649089841)) + (CurrentTexture ?? Class16.smethod_0(1649089857));
	}

	private void method_3(string string_3)
	{
		string[] array = string_3.Replace('\\', '/').Split('/');
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
					treeNode2.Tag = string_3;
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
		label_1.Text = TextStorage.Msg(Class16.smethod_0(1649089878), Class16.smethod_0(1649089891)) + (text ?? Class16.smethod_0(1649089916));
		method_0(text ?? string.Empty);
		method_4(text);
	}

	private void method_4(string string_3)
	{
		pictureBox_0.Image?.Dispose();
		pictureBox_0.Image = null;
		if (string.IsNullOrEmpty(string_3))
		{
			return;
		}
		try
		{
			if (File.Exists(string_3))
			{
				pictureBox_0.Image = Image.FromFile(string_3);
			}
		}
		catch
		{
		}
	}

	private void method_5()
	{
		if (!string.IsNullOrEmpty(SelectedTexturePath))
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void treeView_0_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		method_5();
	}
}
