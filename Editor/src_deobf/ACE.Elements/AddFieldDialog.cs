using System;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.Elements;

public class AddFieldDialog : Form
{
	private TextBox textBox_0;

	private ComboBox comboBox_0;

	private NumericUpDown numericUpDown_0;

	private Button button_0;

	private Button button_1;

	private static readonly string[] string_0 = new string[11]
	{
		Class16.smethod_0(1648989776),
		Class16.smethod_0(1648989786),
		Class16.smethod_0(1648989805),
		Class16.smethod_0(1648989809),
		Class16.smethod_0(1648989830),
		Class16.smethod_0(1648989834),
		Class16.smethod_0(1648902744),
		Class16.smethod_0(1648989855),
		Class16.smethod_0(1648902778),
		Class16.smethod_0(1648902792),
		Class16.smethod_0(1648902764)
	};

	public string FieldName => textBox_0.Text;

	public string FieldType
	{
		get
		{
			object selectedItem = comboBox_0.SelectedItem;
			object obj;
			if (selectedItem == null)
			{
				obj = null;
			}
			else
			{
				obj = selectedItem.ToString();
				if (obj != null)
				{
					goto IL_0025;
				}
			}
			obj = Class16.smethod_0(1648989776);
			goto IL_0025;
			IL_0025:
			string text = (string)obj;
			if (!(text == Class16.smethod_0(1648902778)) && !(text == Class16.smethod_0(1648902792)) && !(text == Class16.smethod_0(1648902764)))
			{
				return text;
			}
			return string.Format(Class16.smethod_0(1648989868), text, (int)numericUpDown_0.Value);
		}
	}

	public AddFieldDialog()
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0()
	{
		Text = Class16.smethod_0(1648989874);
		base.Size = new Size(400, 200);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Font = new Font(Class16.smethod_0(1648942905), 9f);
		Label value = new Label
		{
			Text = Class16.smethod_0(1648989902),
			Location = new Point(20, 20),
			Size = new Size(80, 20)
		};
		base.Controls.Add(value);
		textBox_0 = new TextBox
		{
			Location = new Point(110, 18),
			Size = new Size(250, 23),
			Text = Class16.smethod_0(1648989912)
		};
		base.Controls.Add(textBox_0);
		Label value2 = new Label
		{
			Text = Class16.smethod_0(1649014090),
			Location = new Point(20, 55),
			Size = new Size(80, 20)
		};
		base.Controls.Add(value2);
		comboBox_0 = new ComboBox
		{
			Location = new Point(110, 53),
			Size = new Size(100, 23),
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		ComboBox.ObjectCollection items = comboBox_0.Items;
		object[] items2 = string_0;
		items.AddRange(items2);
		comboBox_0.SelectedIndex = 0;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		base.Controls.Add(comboBox_0);
		Label value3 = new Label
		{
			Text = Class16.smethod_0(1648989928),
			Location = new Point(220, 55),
			Size = new Size(40, 20)
		};
		base.Controls.Add(value3);
		numericUpDown_0 = new NumericUpDown
		{
			Location = new Point(265, 53),
			Size = new Size(70, 23),
			Minimum = 1m,
			Maximum = 4096m,
			Value = 64m,
			Enabled = false
		};
		base.Controls.Add(numericUpDown_0);
		Button button = new Button
		{
			Text = Class16.smethod_0(1648935128),
			Location = new Point(110, 85),
			Size = new Size(40, 23),
			Tag = 32
		};
		Button button2 = new Button
		{
			Text = Class16.smethod_0(1648935171),
			Location = new Point(155, 85),
			Size = new Size(40, 23),
			Tag = 64
		};
		Button button3 = new Button
		{
			Text = Class16.smethod_0(1648935222),
			Location = new Point(200, 85),
			Size = new Size(45, 23),
			Tag = 128
		};
		Button button4 = new Button
		{
			Text = Class16.smethod_0(1648935258),
			Location = new Point(250, 85),
			Size = new Size(45, 23),
			Tag = 256
		};
		button.Click += method_1;
		button2.Click += method_2;
		button3.Click += method_3;
		button4.Click += method_4;
		base.Controls.Add(button);
		base.Controls.Add(button2);
		base.Controls.Add(button3);
		base.Controls.Add(button4);
		button_0 = new Button
		{
			Text = Class16.smethod_0(1648989948),
			Location = new Point(110, 120),
			Size = new Size(100, 30),
			BackColor = Color.FromArgb(92, 184, 92),
			ForeColor = Color.White,
			FlatStyle = FlatStyle.Flat,
			DialogResult = DialogResult.OK
		};
		button_0.Click += button_0_Click;
		base.Controls.Add(button_0);
		button_1 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			Location = new Point(220, 120),
			Size = new Size(100, 30),
			BackColor = Color.FromArgb(217, 83, 79),
			ForeColor = Color.White,
			FlatStyle = FlatStyle.Flat,
			DialogResult = DialogResult.Cancel
		};
		base.Controls.Add(button_1);
		base.AcceptButton = button_0;
		base.CancelButton = button_1;
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		object selectedItem = comboBox_0.SelectedItem;
		object obj;
		if (selectedItem == null)
		{
			obj = null;
		}
		else
		{
			obj = selectedItem.ToString();
			if (obj != null)
			{
				goto IL_0020;
			}
		}
		obj = string.Empty;
		goto IL_0020;
		IL_0020:
		string text = (string)obj;
		numericUpDown_0.Enabled = text == Class16.smethod_0(1648902778) || text == Class16.smethod_0(1648902792) || text == Class16.smethod_0(1648902764);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox_0.Text))
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648989964), Class16.smethod_0(1648990005)), Class16.smethod_0(1648990038), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			base.DialogResult = DialogResult.None;
			return;
		}
		string text = textBox_0.Text.Trim();
		if (text.Contains(Class16.smethod_0(1648942211)))
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648990061), Class16.smethod_0(1648990109)), Class16.smethod_0(1648990038), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			base.DialogResult = DialogResult.None;
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		numericUpDown_0.Value = 32m;
	}

	private void method_2(object sender, EventArgs e)
	{
		numericUpDown_0.Value = 64m;
	}

	private void method_3(object sender, EventArgs e)
	{
		numericUpDown_0.Value = 128m;
	}

	private void method_4(object sender, EventArgs e)
	{
		numericUpDown_0.Value = 256m;
	}
}
