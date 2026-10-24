using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Controls;

public class Controltask_tm : UserControl
{
	private task_tm task_tm_0 = new task_tm();

	private IContainer icontainer_0;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	private ComboBox comboBox_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private TextBox textBox_4;

	public Controltask_tm()
	{
		method_0();
		UpdateControl(new task_tm());
	}

	[CLSCompliant(false)]
	public void UpdateControl(task_tm TaskTm)
	{
		task_tm_0 = TaskTm;
		textBox_0.Text = task_tm_0.year.ToString();
		textBox_1.Text = task_tm_0.month.ToString();
		textBox_2.Text = task_tm_0.day.ToString();
		textBox_3.Text = task_tm_0.hour.ToString();
		textBox_4.Text = task_tm_0.min.ToString();
		comboBox_0.SelectedIndex = task_tm_0.wday + 1;
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox_0.Text))
		{
			textBox_0.Text = Class16.smethod_0(1648924112);
		}
		if (int.TryParse(textBox_0.Text, out var result))
		{
			task_tm_0.year = result;
			return;
		}
		textBox_0.Text = Class16.smethod_0(1648924112);
		task_tm_0.year = 0;
	}

	private void textBox_1_Leave(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox_1.Text))
		{
			textBox_1.Text = Class16.smethod_0(1648924112);
		}
		if (int.TryParse(textBox_1.Text, out var result))
		{
			task_tm_0.month = result;
			return;
		}
		textBox_1.Text = Class16.smethod_0(1648924112);
		task_tm_0.month = 0;
	}

	private void textBox_2_Leave(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox_2.Text))
		{
			textBox_2.Text = Class16.smethod_0(1648924112);
		}
		if (int.TryParse(textBox_2.Text, out var result))
		{
			task_tm_0.day = result;
			return;
		}
		textBox_2.Text = Class16.smethod_0(1648924112);
		task_tm_0.day = 0;
	}

	private void textBox_3_Leave(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox_3.Text))
		{
			textBox_3.Text = Class16.smethod_0(1648924112);
		}
		if (int.TryParse(textBox_3.Text, out var result))
		{
			task_tm_0.hour = result;
			return;
		}
		textBox_3.Text = Class16.smethod_0(1648924112);
		task_tm_0.hour = 0;
	}

	private void textBox_4_Leave(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox_4.Text))
		{
			textBox_4.Text = Class16.smethod_0(1648924112);
		}
		if (int.TryParse(textBox_4.Text, out var result))
		{
			task_tm_0.min = result;
			return;
		}
		textBox_4.Text = Class16.smethod_0(1648924112);
		task_tm_0.min = 0;
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		task_tm_0.wday = comboBox_0.SelectedIndex - 1;
	}

	public void SetLocalization()
	{
		string[] array = new string[9]
		{
			GProD.TX(2099),
			GProD.TX(2100),
			GProD.TX(2101),
			GProD.TX(2102),
			GProD.TX(2103),
			GProD.TX(2104),
			GProD.TX(2105),
			GProD.TX(2106),
			GProD.TX(2107)
		};
		label_0.Text = GProD.TX(5000);
		label_1.Text = GProD.TX(5001);
		label_2.Text = GProD.TX(5002);
		label_3.Text = GProD.TX(5003);
		label_4.Text = GProD.TX(5004);
		label_5.Text = GProD.TX(5005);
		comboBox_0.Items.Clear();
		ComboBox.ObjectCollection items = comboBox_0.Items;
		object[] items2 = array;
		items.AddRange(items2);
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
		label_5 = new Label();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		textBox_2 = new TextBox();
		textBox_3 = new TextBox();
		textBox_4 = new TextBox();
		comboBox_0 = new ComboBox();
		SuspendLayout();
		label_0.BorderStyle = BorderStyle.FixedSingle;
		label_0.Location = new Point(0, 0);
		label_0.Name = Class16.smethod_0(1649251781);
		label_0.Padding = new Padding(0, 1, 0, 0);
		label_0.Size = new Size(48, 20);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1648955471);
		label_0.TextAlign = ContentAlignment.TopCenter;
		label_1.BorderStyle = BorderStyle.FixedSingle;
		label_1.Location = new Point(47, 0);
		label_1.Name = Class16.smethod_0(1649251798);
		label_1.Padding = new Padding(0, 1, 0, 0);
		label_1.Size = new Size(48, 20);
		label_1.TabIndex = 1;
		label_1.Text = Class16.smethod_0(1648906641);
		label_1.TextAlign = ContentAlignment.TopCenter;
		label_2.BorderStyle = BorderStyle.FixedSingle;
		label_2.Location = new Point(94, 0);
		label_2.Name = Class16.smethod_0(1649251808);
		label_2.Padding = new Padding(0, 1, 0, 0);
		label_2.Size = new Size(48, 20);
		label_2.TabIndex = 2;
		label_2.Text = Class16.smethod_0(1648906674);
		label_2.TextAlign = ContentAlignment.TopCenter;
		label_3.BorderStyle = BorderStyle.FixedSingle;
		label_3.Location = new Point(141, 0);
		label_3.Name = Class16.smethod_0(1649251824);
		label_3.Padding = new Padding(0, 1, 0, 0);
		label_3.Size = new Size(48, 20);
		label_3.TabIndex = 3;
		label_3.Text = Class16.smethod_0(1648906705);
		label_3.TextAlign = ContentAlignment.TopCenter;
		label_4.BorderStyle = BorderStyle.FixedSingle;
		label_4.Location = new Point(188, 0);
		label_4.Name = Class16.smethod_0(1649250817);
		label_4.Padding = new Padding(0, 1, 0, 0);
		label_4.Size = new Size(48, 20);
		label_4.TabIndex = 4;
		label_4.Text = Class16.smethod_0(1648906737);
		label_4.TextAlign = ContentAlignment.TopCenter;
		label_5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label_5.BorderStyle = BorderStyle.FixedSingle;
		label_5.Location = new Point(235, 0);
		label_5.Name = Class16.smethod_0(1649250833);
		label_5.Padding = new Padding(0, 1, 0, 0);
		label_5.Size = new Size(48, 20);
		label_5.TabIndex = 5;
		label_5.Text = Class16.smethod_0(1649250850);
		label_5.TextAlign = ContentAlignment.TopCenter;
		textBox_0.Location = new Point(0, 18);
		textBox_0.Multiline = true;
		textBox_0.Name = Class16.smethod_0(1649250869);
		textBox_0.Size = new Size(48, 21);
		textBox_0.TabIndex = 6;
		textBox_0.Leave += textBox_0_Leave;
		textBox_1.Location = new Point(47, 18);
		textBox_1.Multiline = true;
		textBox_1.Name = Class16.smethod_0(1649250880);
		textBox_1.Size = new Size(48, 21);
		textBox_1.TabIndex = 7;
		textBox_1.Leave += textBox_1_Leave;
		textBox_2.Location = new Point(94, 18);
		textBox_2.Multiline = true;
		textBox_2.Name = Class16.smethod_0(1649250908);
		textBox_2.Size = new Size(48, 21);
		textBox_2.TabIndex = 8;
		textBox_2.Leave += textBox_2_Leave;
		textBox_3.Location = new Point(141, 18);
		textBox_3.Multiline = true;
		textBox_3.Name = Class16.smethod_0(1649250926);
		textBox_3.Size = new Size(48, 21);
		textBox_3.TabIndex = 9;
		textBox_3.Leave += textBox_3_Leave;
		textBox_4.Location = new Point(188, 18);
		textBox_4.Multiline = true;
		textBox_4.Name = Class16.smethod_0(1649250937);
		textBox_4.Size = new Size(48, 21);
		textBox_4.TabIndex = 10;
		textBox_4.Leave += textBox_4_Leave;
		comboBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FlatStyle = FlatStyle.System;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[9]
		{
			Class16.smethod_0(1649014110),
			Class16.smethod_0(1649250955),
			Class16.smethod_0(1649250973),
			Class16.smethod_0(1649250983),
			Class16.smethod_0(1649250985),
			Class16.smethod_0(1649250995),
			Class16.smethod_0(1649251013),
			Class16.smethod_0(1649251023),
			Class16.smethod_0(1649204806)
		});
		comboBox_0.Location = new Point(235, 18);
		comboBox_0.Name = Class16.smethod_0(1649251025);
		comboBox_0.Size = new Size(48, 21);
		comboBox_0.TabIndex = 11;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.BorderStyle = BorderStyle.FixedSingle;
		base.Controls.Add(comboBox_0);
		base.Controls.Add(textBox_4);
		base.Controls.Add(textBox_3);
		base.Controls.Add(textBox_2);
		base.Controls.Add(textBox_1);
		base.Controls.Add(textBox_0);
		base.Controls.Add(label_5);
		base.Controls.Add(label_4);
		base.Controls.Add(label_3);
		base.Controls.Add(label_2);
		base.Controls.Add(label_1);
		base.Controls.Add(label_0);
		MinimumSize = new Size(285, 41);
		base.Name = Class16.smethod_0(1649251053);
		base.Size = new Size(285, 41);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
