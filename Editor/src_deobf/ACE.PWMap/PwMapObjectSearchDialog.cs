using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.PWMap;

public sealed class PwMapObjectSearchDialog : Form
{
	private string string_0 = string.Empty;

	private int int_0 = -1;

	private TextBox textBox_0;

	private ListView listView_0;

	private readonly List<(string, int, string, float, float, float)> list_0;

	public string SelectedObjectLabel
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public int SelectedObjectIndex
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
	}

	public PwMapObjectSearchDialog(List<(string Label, int Index, string Type, float X, float Y, float Z)> objects)
	{
		list_0 = objects ?? new List<(string, int, string, float, float, float)>();
		Text = Class16.smethod_0(1649089923);
		base.Size = new Size(520, 460);
		base.StartPosition = FormStartPosition.CenterParent;
		base.FormBorderStyle = FormBorderStyle.Sizable;
		base.MinimizeBox = false;
		base.MaximizeBox = true;
		base.ShowInTaskbar = false;
		MinimumSize = new Size(400, 300);
		method_3();
		method_2();
		TextStorage.TEXTS.SetFormLanguage(this, null);
		method_4(string.Empty);
	}

	private void method_0(string string_1)
	{
		string_0 = string_1;
	}

	private void method_1(int int_1)
	{
		int_0 = int_1;
	}

	private void method_2()
	{
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
	}

	private void method_3()
	{
		Label value = new Label
		{
			Text = Class16.smethod_0(1649003471),
			Location = new Point(12, 14),
			AutoSize = true
		};
		base.Controls.Add(value);
		textBox_0 = new TextBox
		{
			Location = new Point(70, 11),
			Size = new Size(base.ClientSize.Width - 82, 22),
			Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)
		};
		textBox_0.TextChanged += textBox_0_TextChanged;
		base.Controls.Add(textBox_0);
		listView_0 = new ListView
		{
			Location = new Point(12, 40),
			Size = new Size(base.ClientSize.Width - 24, base.ClientSize.Height - 90),
			Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right),
			View = View.Details,
			FullRowSelect = true,
			GridLines = true,
			HideSelection = false,
			MultiSelect = false
		};
		listView_0.Columns.Add(Class16.smethod_0(1648936731), 200);
		listView_0.Columns.Add(Class16.smethod_0(1648936875), 80);
		listView_0.Columns.Add(Class16.smethod_0(1648893587), 180);
		listView_0.DoubleClick += listView_0_DoubleClick;
		listView_0.KeyDown += listView_0_KeyDown;
		base.Controls.Add(listView_0);
		Button button = new Button
		{
			Text = Class16.smethod_0(1649089944),
			Width = 80,
			Height = 28,
			Location = new Point(base.ClientSize.Width - 190, base.ClientSize.Height - 40),
			Anchor = (AnchorStyles.Bottom | AnchorStyles.Right),
			DialogResult = DialogResult.OK
		};
		button.Click += method_6;
		Button button2 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			Width = 80,
			Height = 28,
			Location = new Point(base.ClientSize.Width - 95, base.ClientSize.Height - 40),
			Anchor = (AnchorStyles.Bottom | AnchorStyles.Right),
			DialogResult = DialogResult.Cancel
		};
		base.Controls.AddRange(new Control[2] { button, button2 });
		base.AcceptButton = button;
		base.CancelButton = button2;
	}

	private void method_4(string string_1)
	{
		listView_0.BeginUpdate();
		listView_0.Items.Clear();
		string text = (string_1 ?? string.Empty).Trim().ToUpperInvariant();
		int num = 0;
		for (int i = 0; i < list_0.Count; i++)
		{
			if (num >= 500)
			{
				break;
			}
			(string, int, string, float, float, float) tuple = list_0[i];
			if (text.Length <= 0 || tuple.Item1.ToUpperInvariant().Contains(text) || tuple.Item3.ToUpperInvariant().Contains(text))
			{
				ListViewItem listViewItem = new ListViewItem(tuple.Item1);
				listViewItem.SubItems.Add(tuple.Item3);
				listViewItem.SubItems.Add(string.Format(Class16.smethod_0(1649094136), tuple.Item4, tuple.Item5, tuple.Item6));
				listViewItem.Tag = tuple.Item2;
				listView_0.Items.Add(listViewItem);
				num++;
			}
		}
		listView_0.EndUpdate();
	}

	private void listView_0_DoubleClick(object sender, EventArgs e)
	{
		method_5();
	}

	private void method_5()
	{
		if (listView_0.SelectedItems.Count != 0)
		{
			ListViewItem listViewItem = listView_0.SelectedItems[0];
			method_0(listViewItem.Text);
			method_1((int)listViewItem.Tag);
			base.DialogResult = DialogResult.OK;
		}
	}

	protected override void OnShown(EventArgs eventArgs_0)
	{
		base.OnShown(eventArgs_0);
		textBox_0.Focus();
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		method_4(textBox_0.Text);
	}

	private void listView_0_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			method_5();
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		method_5();
	}
}
