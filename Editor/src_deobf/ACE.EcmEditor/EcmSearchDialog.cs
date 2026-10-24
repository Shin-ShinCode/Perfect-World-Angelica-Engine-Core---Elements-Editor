using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.EcmEditor.Models;
using ACE.EcmEditor.Services;

namespace ACE.EcmEditor;

public class EcmSearchDialog : Form
{
	private sealed class Class116
	{
		private EcmFile ecmFile_0;

		private int int_0;

		private string string_0 = string.Empty;

		public EcmFile method_0()
		{
			return ecmFile_0;
		}

		public void method_1(EcmFile ecmFile_1)
		{
			ecmFile_0 = ecmFile_1;
		}

		public int method_2()
		{
			return int_0;
		}

		public void method_3(int int_1)
		{
			int_0 = int_1;
		}

		public string method_4()
		{
			return string_0;
		}

		public void method_5(string string_1)
		{
			string_0 = string_1;
		}

		public override string ToString()
		{
			return method_4();
		}
	}

	private readonly EcmFile ecmFile_0;

	private readonly List<EcmFile> list_0;

	private readonly EcmDirectoryScanner ecmDirectoryScanner_0;

	private readonly bool bool_0;

	private EcmFile ecmFile_1;

	private string string_0;

	private IContainer icontainer_0;

	private Label label_0;

	private TextBox textBox_0;

	private Button button_0;

	private CheckBox checkBox_0;

	private GroupBox groupBox_0;

	private ListBox listBox_0;

	private Label label_1;

	private Button button_1;

	public EcmFile SelectedFile
	{
		[CompilerGenerated]
		get
		{
			return ecmFile_1;
		}
	}

	public string SelectedSearchText
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public EcmSearchDialog(EcmFile currentFile, List<EcmFile> allFiles, EcmDirectoryScanner scanner, bool searchAll)
	{
		ecmFile_0 = currentFile;
		list_0 = allFiles;
		ecmDirectoryScanner_0 = scanner;
		bool_0 = searchAll;
		method_4();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		if (bool_0)
		{
			Text = TextStorage.Msg(Class16.smethod_0(1648995465), Class16.smethod_0(1648995494));
			label_0.Text = TextStorage.Msg(Class16.smethod_0(1648995517), Class16.smethod_0(1648995541));
		}
		else
		{
			Text = TextStorage.Msg(Class16.smethod_0(1648995562), Class16.smethod_0(1648995587));
			label_0.Text = TextStorage.Msg(Class16.smethod_0(1648995621), Class16.smethod_0(1648995641));
		}
	}

	private void method_0(EcmFile ecmFile_2)
	{
		ecmFile_1 = ecmFile_2;
	}

	private void method_1(string string_1)
	{
		string_0 = string_1;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_2();
	}

	private void textBox_0_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.Handled = true;
			method_2();
		}
	}

	private void method_2()
	{
		string text = textBox_0.Text;
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		listBox_0.Items.Clear();
		StringComparison stringComparison = (checkBox_0.Checked ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
		if (bool_0)
		{
			foreach (EcmFile item in list_0)
			{
				if (item.ScriptData == null)
				{
					ecmDirectoryScanner_0.LoadContent(item);
				}
				if (item.CurrentContent.IndexOf(text, stringComparison) >= 0)
				{
					int num = method_3(item.CurrentContent, text, stringComparison);
					ListBox.ObjectCollection items = listBox_0.Items;
					Class116 @class = new Class116();
					@class.method_1(item);
					@class.method_3(num);
					@class.method_5(string.Format(Class16.smethod_0(1648938828), item.DisplayName, num));
					items.Add(@class);
				}
			}
		}
		else if (ecmFile_0 != null && ecmFile_0.CurrentContent.IndexOf(text, stringComparison) >= 0)
		{
			int num2 = method_3(ecmFile_0.CurrentContent, text, stringComparison);
			ListBox.ObjectCollection items2 = listBox_0.Items;
			Class116 class2 = new Class116();
			class2.method_1(ecmFile_0);
			class2.method_3(num2);
			class2.method_5(string.Format(Class16.smethod_0(1648938828), ecmFile_0.DisplayName, num2));
			items2.Add(class2);
		}
		label_1.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648995673), Class16.smethod_0(1648995703)), listBox_0.Items.Count);
	}

	private int method_3(string string_1, string string_2, StringComparison stringComparison_0)
	{
		int num = 0;
		int startIndex = 0;
		while ((startIndex = string_1.IndexOf(string_2, startIndex, stringComparison_0)) != -1)
		{
			num++;
			startIndex += string_2.Length;
		}
		return num;
	}

	private void listBox_0_DoubleClick(object sender, EventArgs e)
	{
		if (listBox_0.SelectedItem is Class116 @class)
		{
			method_0(@class.method_0());
			method_1(textBox_0.Text);
			Close();
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_4()
	{
		label_0 = new Label();
		textBox_0 = new TextBox();
		button_0 = new Button();
		checkBox_0 = new CheckBox();
		groupBox_0 = new GroupBox();
		listBox_0 = new ListBox();
		label_1 = new Label();
		button_1 = new Button();
		groupBox_0.SuspendLayout();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648934511), 9f, FontStyle.Bold);
		label_0.Location = new Point(16, 16);
		label_0.Name = Class16.smethod_0(1648995946);
		label_0.Size = new Size(80, 15);
		label_0.Text = Class16.smethod_0(1648995727);
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.BorderStyle = BorderStyle.FixedSingle;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 10f);
		textBox_0.Location = new Point(16, 38);
		textBox_0.Name = Class16.smethod_0(1648995997);
		textBox_0.Size = new Size(384, 25);
		textBox_0.KeyDown += textBox_0_KeyDown;
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_0.FlatStyle = FlatStyle.Flat;
		button_0.Location = new Point(410, 37);
		button_0.Name = Class16.smethod_0(1648911491);
		button_0.Size = new Size(90, 27);
		button_0.Text = Class16.smethod_0(1648931650);
		button_0.Click += button_0_Click;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(16, 72);
		checkBox_0.Name = Class16.smethod_0(1648996062);
		checkBox_0.Size = new Size(103, 19);
		checkBox_0.Text = Class16.smethod_0(1648928555);
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_0.Controls.Add(listBox_0);
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Location = new Point(12, 100);
		groupBox_0.Name = Class16.smethod_0(1648992964);
		groupBox_0.Padding = new Padding(12, 8, 12, 8);
		groupBox_0.Size = new Size(496, 240);
		groupBox_0.Text = Class16.smethod_0(1648995738);
		listBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listBox_0.BorderStyle = BorderStyle.None;
		listBox_0.Font = new Font(Class16.smethod_0(1648942905), 9.5f);
		listBox_0.Location = new Point(16, 24);
		listBox_0.Name = Class16.smethod_0(1648995752);
		listBox_0.Size = new Size(464, 186);
		listBox_0.DoubleClick += listBox_0_DoubleClick;
		label_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_1.AutoSize = true;
		label_1.Location = new Point(16, 216);
		label_1.Name = Class16.smethod_0(1648995769);
		label_1.Size = new Size(0, 15);
		label_1.Text = string.Empty;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_1.FlatStyle = FlatStyle.Flat;
		button_1.Location = new Point(418, 348);
		button_1.Name = Class16.smethod_0(1648995798);
		button_1.Size = new Size(90, 30);
		button_1.Text = Class16.smethod_0(1649014457);
		button_1.Click += button_1_Click;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(520, 390);
		base.Controls.Add(label_0);
		base.Controls.Add(textBox_0);
		base.Controls.Add(button_0);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(button_1);
		base.MinimizeBox = false;
		MinimumSize = new Size(420, 350);
		base.Name = Class16.smethod_0(1648995813);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648931650);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
