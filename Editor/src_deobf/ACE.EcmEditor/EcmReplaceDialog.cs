using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.Classes;
using ACE.EcmEditor.Models;
using ACE.EcmEditor.Services;

namespace ACE.EcmEditor;

public class EcmReplaceDialog : Form
{
	private sealed class Class114
	{
		private EcmFile ecmFile_0;

		private string string_0 = string.Empty;

		private string string_1 = string.Empty;

		private int int_0;

		public EcmFile method_0()
		{
			return ecmFile_0;
		}

		public void method_1(EcmFile ecmFile_1)
		{
			ecmFile_0 = ecmFile_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_2)
		{
			string_0 = string_2;
		}

		public string method_4()
		{
			return string_1;
		}

		public void method_5(string string_2)
		{
			string_1 = string_2;
		}

		public int method_6()
		{
			return int_0;
		}

		public void method_7(int int_1)
		{
			int_0 = int_1;
		}
	}

	[Serializable]
	private sealed class Class115
	{
		public static readonly Class115 class115_0 = new Class115();

		public static Func<Class114, int> func_0;

		public static Func<EcmFile, bool> func_1;

		public static Func<EcmFile, bool> func_2;

		internal int method_0(Class114 class114_0)
		{
			return class114_0.method_6();
		}

		internal bool method_1(EcmFile ecmFile_0)
		{
			return ecmFile_0.Gender == EcmGender.Male;
		}

		internal bool method_2(EcmFile ecmFile_0)
		{
			return ecmFile_0.Gender == EcmGender.Female;
		}
	}

	private readonly EcmFile ecmFile_0;

	private readonly List<EcmFile> list_0;

	private readonly EcmDirectoryScanner ecmDirectoryScanner_0;

	private readonly EcmUndoRedoManager ecmUndoRedoManager_0;

	private List<Class114> list_1 = new List<Class114>();

	private IContainer icontainer_0;

	private GroupBox groupBox_0;

	private Label label_0;

	private ComboBox comboBox_0;

	private Label label_1;

	private TextBox textBox_0;

	private Label label_2;

	private TextBox textBox_1;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private Button button_0;

	private GroupBox groupBox_1;

	private ListBox listBox_0;

	private Label label_3;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	public EcmReplaceDialog(EcmFile currentFile, List<EcmFile> allFiles, EcmDirectoryScanner scanner, EcmUndoRedoManager undoRedo)
	{
		ecmFile_0 = currentFile;
		list_0 = allFiles;
		ecmDirectoryScanner_0 = scanner;
		ecmUndoRedoManager_0 = undoRedo;
		method_5();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		comboBox_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1648992451), Class16.smethod_0(1648992475)));
		comboBox_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1648992502), Class16.smethod_0(1648992514)));
		comboBox_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1648992530), Class16.smethod_0(1648992552)));
		comboBox_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1648992569), Class16.smethod_0(1648992593)));
		comboBox_0.SelectedIndex = 0;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_0();
	}

	private void method_0()
	{
		string text = textBox_0.Text;
		string string_ = textBox_1.Text;
		if (string.IsNullOrEmpty(text))
		{
			MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648992620), Class16.smethod_0(1648992635)), TextStorage.Msg(Class16.smethod_0(1648992678), Class16.smethod_0(1648992688)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		list_1.Clear();
		listBox_0.Items.Clear();
		List<EcmFile> list = method_1();
		StringComparison stringComparison_ = (checkBox_0.Checked ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
		foreach (EcmFile item2 in list)
		{
			if (item2.ScriptData == null)
			{
				ecmDirectoryScanner_0.LoadContent(item2);
			}
			if (method_2(item2.CurrentContent, text, stringComparison_))
			{
				int num = method_3(item2.CurrentContent, text, stringComparison_);
				Class114 @class = new Class114();
				@class.method_1(item2);
				@class.method_3(item2.CurrentContent);
				@class.method_7(num);
				@class.method_5(method_4(item2.CurrentContent, text, string_, checkBox_0.Checked, checkBox_1.Checked));
				Class114 item = @class;
				list_1.Add(item);
				listBox_0.Items.Add(string.Format(Class16.smethod_0(1648992710), item2.DisplayName, num));
			}
		}
		label_3.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648992726), Class16.smethod_0(1648992750)), list_1.Count, ((IEnumerable<Class114>)list_1).Sum((Func<Class114, int>)Class115.class115_0.method_0));
		if (list_1.Count == 0)
		{
			MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648995869), Class16.smethod_0(1648995882)), TextStorage.Msg(Class16.smethod_0(1648992678), Class16.smethod_0(1648992688)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private List<EcmFile> method_1()
	{
		return comboBox_0.SelectedIndex switch
		{
			0 => (ecmFile_0 != null) ? new List<EcmFile> { ecmFile_0 } : new List<EcmFile>(), 
			1 => list_0, 
			2 => list_0.Where(Class115.class115_0.method_1).ToList(), 
			3 => list_0.Where(Class115.class115_0.method_2).ToList(), 
			_ => new List<EcmFile>(), 
		};
	}

	private bool method_2(string string_0, string string_1, StringComparison stringComparison_0)
	{
		if (checkBox_1.Checked)
		{
			Regex regex = new Regex(Class16.smethod_0(1648905146) + Regex.Escape(string_1) + Class16.smethod_0(1648905146), (!checkBox_0.Checked) ? RegexOptions.IgnoreCase : RegexOptions.None);
			return regex.IsMatch(string_0);
		}
		return string_0.IndexOf(string_1, stringComparison_0) >= 0;
	}

	private int method_3(string string_0, string string_1, StringComparison stringComparison_0)
	{
		if (checkBox_1.Checked)
		{
			Regex regex = new Regex(Class16.smethod_0(1648905146) + Regex.Escape(string_1) + Class16.smethod_0(1648905146), (!checkBox_0.Checked) ? RegexOptions.IgnoreCase : RegexOptions.None);
			return regex.Matches(string_0).Count;
		}
		int num = 0;
		int startIndex = 0;
		while ((startIndex = string_0.IndexOf(string_1, startIndex, stringComparison_0)) != -1)
		{
			num++;
			startIndex += string_1.Length;
		}
		return num;
	}

	private string method_4(string string_0, string string_1, string string_2, bool bool_0, bool bool_1)
	{
		if (bool_1)
		{
			Regex regex = new Regex(Class16.smethod_0(1648905146) + Regex.Escape(string_1) + Class16.smethod_0(1648905146), (!bool_0) ? RegexOptions.IgnoreCase : RegexOptions.None);
			return regex.Replace(string_0, string_2);
		}
		if (bool_0)
		{
			return string_0.Replace(string_1, string_2);
		}
		return Regex.Replace(string_0, Regex.Escape(string_1), string_2, RegexOptions.IgnoreCase);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_5()
	{
		groupBox_0 = new GroupBox();
		label_0 = new Label();
		comboBox_0 = new ComboBox();
		label_1 = new Label();
		textBox_0 = new TextBox();
		label_2 = new Label();
		textBox_1 = new TextBox();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		button_0 = new Button();
		groupBox_1 = new GroupBox();
		listBox_0 = new ListBox();
		label_3 = new Label();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		groupBox_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		SuspendLayout();
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(comboBox_0);
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Controls.Add(textBox_0);
		groupBox_0.Controls.Add(label_2);
		groupBox_0.Controls.Add(textBox_1);
		groupBox_0.Controls.Add(checkBox_0);
		groupBox_0.Controls.Add(checkBox_1);
		groupBox_0.Controls.Add(button_0);
		groupBox_0.Location = new Point(12, 12);
		groupBox_0.Name = Class16.smethod_0(1648995906);
		groupBox_0.Padding = new Padding(12, 8, 12, 8);
		groupBox_0.Size = new Size(526, 168);
		groupBox_0.Text = Class16.smethod_0(1648995923);
		label_0.AutoSize = true;
		label_0.Location = new Point(16, 28);
		label_0.Name = Class16.smethod_0(1648995946);
		label_0.Size = new Size(44, 15);
		label_0.Text = Class16.smethod_0(1648995961);
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Location = new Point(80, 25);
		comboBox_0.Name = Class16.smethod_0(1648995982);
		comboBox_0.Size = new Size(180, 23);
		label_1.AutoSize = true;
		label_1.Location = new Point(16, 60);
		label_1.Name = Class16.smethod_0(1649003455);
		label_1.Size = new Size(33, 15);
		label_1.Text = Class16.smethod_0(1648916538);
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.BorderStyle = BorderStyle.FixedSingle;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 10f);
		textBox_0.Location = new Point(80, 57);
		textBox_0.Name = Class16.smethod_0(1648995997);
		textBox_0.Size = new Size(432, 25);
		label_2.AutoSize = true;
		label_2.Location = new Point(16, 92);
		label_2.Name = Class16.smethod_0(1648996013);
		label_2.Size = new Size(52, 15);
		label_2.Text = Class16.smethod_0(1648996030);
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.BorderStyle = BorderStyle.FixedSingle;
		textBox_1.Font = new Font(Class16.smethod_0(1648942905), 10f);
		textBox_1.Location = new Point(80, 89);
		textBox_1.Name = Class16.smethod_0(1648996045);
		textBox_1.Size = new Size(432, 25);
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(80, 124);
		checkBox_0.Name = Class16.smethod_0(1648996062);
		checkBox_0.Size = new Size(103, 19);
		checkBox_0.Text = Class16.smethod_0(1648928555);
		checkBox_1.AutoSize = true;
		checkBox_1.Location = new Point(200, 124);
		checkBox_1.Name = Class16.smethod_0(1648996085);
		checkBox_1.Size = new Size(88, 19);
		checkBox_1.Text = Class16.smethod_0(1648996096);
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_0.FlatStyle = FlatStyle.Flat;
		button_0.Location = new Point(412, 120);
		button_0.Name = Class16.smethod_0(1648996113);
		button_0.Size = new Size(100, 28);
		button_0.Text = Class16.smethod_0(1648992688);
		button_0.Click += button_0_Click;
		groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_1.Controls.Add(listBox_0);
		groupBox_1.Controls.Add(label_3);
		groupBox_1.Location = new Point(12, 188);
		groupBox_1.Name = Class16.smethod_0(1648996130);
		groupBox_1.Padding = new Padding(12, 8, 12, 8);
		groupBox_1.Size = new Size(526, 200);
		groupBox_1.Text = Class16.smethod_0(1648992688);
		listBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listBox_0.BorderStyle = BorderStyle.None;
		listBox_0.Font = new Font(Class16.smethod_0(1648942905), 9.5f);
		listBox_0.Location = new Point(16, 24);
		listBox_0.Name = Class16.smethod_0(1648996147);
		listBox_0.Size = new Size(496, 144);
		label_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_3.AutoSize = true;
		label_3.Location = new Point(16, 176);
		label_3.Name = Class16.smethod_0(1648996172);
		label_3.Size = new Size(0, 15);
		label_3.Text = string.Empty;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_1.FlatStyle = FlatStyle.Flat;
		button_1.Location = new Point(234, 396);
		button_1.Name = Class16.smethod_0(1648996186);
		button_1.Size = new Size(95, 30);
		button_1.Text = Class16.smethod_0(1648996201);
		button_1.Click += button_1_Click;
		button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_2.FlatStyle = FlatStyle.Flat;
		button_2.Location = new Point(337, 396);
		button_2.Name = Class16.smethod_0(1648996221);
		button_2.Size = new Size(100, 30);
		button_2.Text = Class16.smethod_0(1648996235);
		button_2.Click += button_2_Click;
		button_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_3.FlatStyle = FlatStyle.Flat;
		button_3.Location = new Point(445, 396);
		button_3.Name = Class16.smethod_0(1648992414);
		button_3.Size = new Size(93, 30);
		button_3.Text = Class16.smethod_0(1648941799);
		button_3.Click += button_3_Click;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(550, 440);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(groupBox_1);
		base.Controls.Add(button_1);
		base.Controls.Add(button_2);
		base.Controls.Add(button_3);
		base.MinimizeBox = false;
		MinimumSize = new Size(480, 400);
		base.Name = Class16.smethod_0(1648996263);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648995923);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_6(bool_0: false);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_6(bool_0: true);
	}

	private void method_6(bool bool_0)
	{
		if (list_1.Count == 0)
		{
			MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648996286), Class16.smethod_0(1648996310)), TextStorage.Msg(Class16.smethod_0(1648996338), Class16.smethod_0(1648996201)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		foreach (Class114 item in list_1)
		{
			ecmUndoRedoManager_0.PushState(item.method_0().FilePath, item.method_2());
			item.method_0().CurrentContent = item.method_4();
			if (bool_0)
			{
				ecmDirectoryScanner_0.SaveContent(item.method_0());
				ecmUndoRedoManager_0.Clear(item.method_0().FilePath);
			}
		}
		string text = (bool_0 ? string.Format(TextStorage.Msg(Class16.smethod_0(1648995386), Class16.smethod_0(1648995410)), list_1.Count) : string.Format(TextStorage.Msg(Class16.smethod_0(1648995330), Class16.smethod_0(1648995356)), list_1.Count));
		MessageBox.Show(text, TextStorage.Msg(Class16.smethod_0(1648995455), Class16.smethod_0(1648999325)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}
}
