using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Controls;

public class ControlCOMPARE_KEY_VALUE : UserControl
{
	private COMPARE_KEY_VALUE compare_KEY_VALUE_0 = new COMPARE_KEY_VALUE();

	private IContainer icontainer_0;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private ComboBox comboBox_0;

	private ComboBox comboBox_1;

	private ComboBox comboBox_2;

	public ControlCOMPARE_KEY_VALUE()
	{
		method_0();
		UpdateControl(new COMPARE_KEY_VALUE());
	}

	[CLSCompliant(false)]
	public void UpdateControl(COMPARE_KEY_VALUE Compare_Key_Value)
	{
		compare_KEY_VALUE_0 = Compare_Key_Value;
		comboBox_0.SelectedIndex = compare_KEY_VALUE_0.nLeftType;
		textBox_0.Text = compare_KEY_VALUE_0.lLeftNum.ToString();
		comboBox_1.SelectedIndex = compare_KEY_VALUE_0.nCompOper;
		comboBox_2.SelectedIndex = compare_KEY_VALUE_0.nRightType;
		textBox_1.Text = compare_KEY_VALUE_0.lRightNum.ToString();
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		compare_KEY_VALUE_0.nLeftType = comboBox_0.SelectedIndex;
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox_0.Text))
		{
			textBox_0.Text = Class16.smethod_0(1648924112);
		}
		if (int.TryParse(textBox_0.Text, out var result))
		{
			compare_KEY_VALUE_0.lLeftNum = result;
			return;
		}
		textBox_0.Text = Class16.smethod_0(1648924112);
		compare_KEY_VALUE_0.lLeftNum = 0;
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		compare_KEY_VALUE_0.nCompOper = comboBox_1.SelectedIndex;
	}

	private void comboBox_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		compare_KEY_VALUE_0.nRightType = comboBox_2.SelectedIndex;
	}

	private void textBox_1_Leave(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox_1.Text))
		{
			textBox_1.Text = Class16.smethod_0(1648924112);
		}
		if (int.TryParse(textBox_1.Text, out var result))
		{
			compare_KEY_VALUE_0.lRightNum = result;
			return;
		}
		textBox_1.Text = Class16.smethod_0(1648924112);
		compare_KEY_VALUE_0.lRightNum = 0;
	}

	public void SetLocalization()
	{
		string[] array = new string[2]
		{
			GProD.TX(2510),
			GProD.TX(2511)
		};
		string[] array2 = new string[4]
		{
			GProD.TX(2520),
			GProD.TX(2521),
			GProD.TX(2522),
			GProD.TX(2523)
		};
		label_0.Text = GProD.TX(5041);
		comboBox_0.Items.Clear();
		ComboBox.ObjectCollection items = comboBox_0.Items;
		object[] items2 = array;
		items.AddRange(items2);
		label_1.Text = GProD.TX(5042);
		label_2.Text = GProD.TX(5043);
		comboBox_1.Items.Clear();
		ComboBox.ObjectCollection items3 = comboBox_1.Items;
		items2 = array2;
		items3.AddRange(items2);
		label_3.Text = GProD.TX(5044);
		comboBox_2.Items.Clear();
		ComboBox.ObjectCollection items4 = comboBox_2.Items;
		items2 = array;
		items4.AddRange(items2);
		label_4.Text = GProD.TX(5045);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_0()
	{
		label_0 = new Label();
		label_1 = new Label();
		label_2 = new Label();
		label_3 = new Label();
		label_4 = new Label();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		comboBox_0 = new ComboBox();
		comboBox_1 = new ComboBox();
		comboBox_2 = new ComboBox();
		SuspendLayout();
		label_0.BorderStyle = BorderStyle.FixedSingle;
		label_0.Location = new Point(0, 0);
		label_0.Name = Class16.smethod_0(1649251437);
		label_0.Padding = new Padding(0, 1, 0, 0);
		label_0.Size = new Size(62, 20);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1649251451);
		label_0.TextAlign = ContentAlignment.TopCenter;
		label_1.BorderStyle = BorderStyle.FixedSingle;
		label_1.Location = new Point(61, 0);
		label_1.Name = Class16.smethod_0(1649251467);
		label_1.Padding = new Padding(0, 1, 0, 0);
		label_1.Size = new Size(62, 20);
		label_1.TabIndex = 1;
		label_1.Text = Class16.smethod_0(1649251488);
		label_1.TextAlign = ContentAlignment.TopCenter;
		label_2.BorderStyle = BorderStyle.FixedSingle;
		label_2.Location = new Point(122, 0);
		label_2.Name = Class16.smethod_0(1649251511);
		label_2.Padding = new Padding(0, 1, 0, 0);
		label_2.Size = new Size(62, 20);
		label_2.TabIndex = 2;
		label_2.Text = Class16.smethod_0(1649251533);
		label_2.TextAlign = ContentAlignment.TopCenter;
		label_3.BorderStyle = BorderStyle.FixedSingle;
		label_3.Location = new Point(183, 0);
		label_3.Name = Class16.smethod_0(1649251549);
		label_3.Padding = new Padding(0, 1, 0, 0);
		label_3.Size = new Size(62, 20);
		label_3.TabIndex = 3;
		label_3.Text = Class16.smethod_0(1649251572);
		label_3.TextAlign = ContentAlignment.TopCenter;
		label_4.BorderStyle = BorderStyle.FixedSingle;
		label_4.Location = new Point(244, 0);
		label_4.Name = Class16.smethod_0(1649251589);
		label_4.Padding = new Padding(0, 1, 0, 0);
		label_4.Size = new Size(62, 20);
		label_4.TabIndex = 4;
		label_4.Text = Class16.smethod_0(1649251603);
		label_4.TextAlign = ContentAlignment.TopCenter;
		textBox_0.Location = new Point(61, 18);
		textBox_0.Multiline = true;
		textBox_0.Name = Class16.smethod_0(1649251619);
		textBox_0.Size = new Size(62, 21);
		textBox_0.TabIndex = 6;
		textBox_0.Leave += textBox_0_Leave;
		textBox_1.Location = new Point(244, 18);
		textBox_1.Multiline = true;
		textBox_1.Name = Class16.smethod_0(1649251642);
		textBox_1.Size = new Size(62, 21);
		textBox_1.TabIndex = 9;
		textBox_1.Leave += textBox_1_Leave;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FlatStyle = FlatStyle.System;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1648892990),
			Class16.smethod_0(1648941098)
		});
		comboBox_0.Location = new Point(0, 18);
		comboBox_0.Name = Class16.smethod_0(1649251666);
		comboBox_0.Size = new Size(62, 21);
		comboBox_0.TabIndex = 5;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.FlatStyle = FlatStyle.System;
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1648936452),
			Class16.smethod_0(1648936480),
			Class16.smethod_0(1648936470)
		});
		comboBox_1.Location = new Point(122, 18);
		comboBox_1.Name = Class16.smethod_0(1649251691);
		comboBox_1.Size = new Size(62, 21);
		comboBox_1.TabIndex = 7;
		comboBox_1.SelectedIndexChanged += comboBox_1_SelectedIndexChanged;
		comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_2.FlatStyle = FlatStyle.System;
		comboBox_2.FormattingEnabled = true;
		comboBox_2.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1648892990),
			Class16.smethod_0(1648941098)
		});
		comboBox_2.Location = new Point(183, 18);
		comboBox_2.Name = Class16.smethod_0(1649251724);
		comboBox_2.Size = new Size(62, 21);
		comboBox_2.TabIndex = 8;
		comboBox_2.SelectedIndexChanged += comboBox_2_SelectedIndexChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Controls.Add(comboBox_2);
		base.Controls.Add(comboBox_1);
		base.Controls.Add(comboBox_0);
		base.Controls.Add(textBox_1);
		base.Controls.Add(textBox_0);
		base.Controls.Add(label_4);
		base.Controls.Add(label_3);
		base.Controls.Add(label_2);
		base.Controls.Add(label_1);
		base.Controls.Add(label_0);
		MinimumSize = new Size(308, 41);
		base.Name = Class16.smethod_0(1649251750);
		base.Size = new Size(308, 41);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
