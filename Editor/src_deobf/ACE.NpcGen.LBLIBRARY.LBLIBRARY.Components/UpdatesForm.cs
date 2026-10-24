using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class UpdatesForm : Form
{
	private Point point_0 = Point.Empty;

	private Size size_0;

	private ButtonB buttonB_0;

	private ComboBoxA comboBoxA_0;

	private IContainer icontainer_0;

	private OpenFileDialog openFileDialog_0;

	private bool bool_0;

	private bool bool_1;

	private int int_0 = 1;

	private Point point_1;

	private ToolTip toolTip_0;

	private Panel panel_0;

	private RichTextBox richTextBox_0;

	private Label label_0;

	public int SetLanguage
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			if (int_0 == 1)
			{
				comboBoxA_0.SelectedIndex = 0;
			}
			else
			{
				comboBoxA_0.SelectedIndex = 1;
			}
		}
	}

	public UpdatesForm()
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyThemeToForm(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	public void SetText(List<string> Text)
	{
		string[] lines;
		if (int_0 == 1)
		{
			foreach (string item in Text)
			{
				if (!item.StartsWith(Class16.smethod_0(1649117906)))
				{
					RichTextBox richTextBox = richTextBox_0;
					richTextBox.Text = richTextBox.Text + item + Class16.smethod_0(1648941987);
				}
				else
				{
					RichTextBox richTextBox2 = richTextBox_0;
					richTextBox2.Text = richTextBox2.Text + Class16.smethod_0(1649117915) + item + Class16.smethod_0(1648941987);
				}
			}
			lines = richTextBox_0.Lines;
			string[] array = lines;
			foreach (string text in array)
			{
				if (text.StartsWith(Class16.smethod_0(1649117930)))
				{
					richTextBox_0.Select(richTextBox_0.Text.IndexOf(text), text.Length);
					richTextBox_0.SelectionColor = Color.Green;
					richTextBox_0.SelectionFont = new Font(Class16.smethod_0(1649117828), 12f);
				}
			}
			richTextBox_0.AutoScrollOffset = new Point(0, 1000);
			richTextBox_0.Select(0, 0);
			return;
		}
		foreach (string item2 in Text)
		{
			if (!item2.StartsWith(Class16.smethod_0(1648915585)))
			{
				RichTextBox richTextBox3 = richTextBox_0;
				richTextBox3.Text = richTextBox3.Text + item2 + Class16.smethod_0(1648941987);
			}
			else
			{
				RichTextBox richTextBox4 = richTextBox_0;
				richTextBox4.Text = richTextBox4.Text + Class16.smethod_0(1649117915) + item2 + Class16.smethod_0(1648941987);
			}
		}
		lines = richTextBox_0.Lines;
		string[] array2 = lines;
		foreach (string text2 in array2)
		{
			if (text2.StartsWith(Class16.smethod_0(1649117955)))
			{
				richTextBox_0.Select(richTextBox_0.Text.IndexOf(text2), text2.Length);
				richTextBox_0.SelectionColor = Color.Green;
				richTextBox_0.SelectionFont = new Font(Class16.smethod_0(1649117828), 12f);
			}
		}
		richTextBox_0.AutoScrollOffset = new Point(0, 1000);
		richTextBox_0.Select(0, 0);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void buttonB_0_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void comboBoxA_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		richTextBox_0.Text = string.Empty;
		if (comboBoxA_0.SelectedIndex == 0)
		{
			int_0 = 1;
			label_0.Text = TextStorage.Msg(Class16.smethod_0(1649117971), Class16.smethod_0(1649118000));
			SetText(File.ReadAllLines(Application.StartupPath + Class16.smethod_0(1649118030), Encoding.GetEncoding(1251)).ToList());
		}
		else
		{
			int_0 = 2;
			label_0.Text = TextStorage.Msg(Class16.smethod_0(1649118054), Class16.smethod_0(1649118000));
			SetText(File.ReadAllLines(Application.StartupPath + Class16.smethod_0(1649118085), Encoding.GetEncoding(1251)).ToList());
		}
	}

	private void method_0()
	{
		icontainer_0 = new Container();
		panel_0 = new Panel();
		comboBoxA_0 = new ComboBoxA();
		label_0 = new Label();
		buttonB_0 = new ButtonB();
		toolTip_0 = new ToolTip(icontainer_0);
		openFileDialog_0 = new OpenFileDialog();
		richTextBox_0 = new RichTextBox();
		panel_0.SuspendLayout();
		SuspendLayout();
		panel_0.BackColor = Color.FromArgb(220, 120, 80);
		panel_0.Controls.Add(comboBoxA_0);
		panel_0.Controls.Add(label_0);
		panel_0.Controls.Add(buttonB_0);
		panel_0.Dock = DockStyle.Top;
		panel_0.Location = new Point(0, 0);
		panel_0.Name = Class16.smethod_0(1649118445);
		panel_0.Size = new Size(730, 33);
		panel_0.TabIndex = 4;
		panel_0.MouseDown += panel_0_MouseDown;
		panel_0.MouseMove += panel_0_MouseMove;
		panel_0.MouseUp += panel_0_MouseUp;
		comboBoxA_0.ArrowColor = Color.Black;
		comboBoxA_0.BackColor = Color.FromArgb(255, 224, 192);
		comboBoxA_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBoxA_0.FlatStyle = FlatStyle.Flat;
		comboBoxA_0.FormattingEnabled = true;
		comboBoxA_0.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1648896752),
			Class16.smethod_0(1648899236)
		});
		comboBoxA_0.Location = new Point(0, 0);
		comboBoxA_0.Name = Class16.smethod_0(1649118109);
		comboBoxA_0.SelectionColor = Color.FromArgb(192, 255, 255);
		comboBoxA_0.SetColorBlack = ComboBoxA.MyEnum.None;
		comboBoxA_0.SetFont = new Font(Class16.smethod_0(1648929920), 9f);
		comboBoxA_0.Size = new Size(128, 21);
		comboBoxA_0.TabIndex = 2;
		comboBoxA_0.Visible = false;
		comboBoxA_0.SelectedIndexChanged += comboBoxA_0_SelectedIndexChanged;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648929920), 14.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.ForeColor = Color.White;
		label_0.Location = new Point(270, 5);
		label_0.Name = Class16.smethod_0(1649118460);
		label_0.Size = new Size(200, 24);
		label_0.TabIndex = 1;
		label_0.Text = TextStorage.Msg(Class16.smethod_0(1649118127), Class16.smethod_0(1649118000));
		label_0.MouseDown += label_0_MouseDown;
		label_0.MouseMove += label_0_MouseMove;
		label_0.MouseUp += label_0_MouseUp;
		buttonB_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		buttonB_0.BZBackColor = Color.FromArgb(220, 120, 80);
		buttonB_0.DisplayText = Class16.smethod_0(1648916453);
		buttonB_0.FlatStyle = FlatStyle.Flat;
		buttonB_0.Font = new Font(Class16.smethod_0(1649118691), 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		buttonB_0.ForeColor = Color.White;
		buttonB_0.Location = new Point(699, 2);
		buttonB_0.MouseClickColor1 = Color.FromArgb(60, 60, 160);
		buttonB_0.MouseHoverColor = Color.FromArgb(50, 50, 50);
		buttonB_0.Name = Class16.smethod_0(1649118158);
		buttonB_0.Size = new Size(31, 30);
		buttonB_0.TabIndex = 0;
		buttonB_0.Text = Class16.smethod_0(1648916453);
		buttonB_0.TextLocation_X = 6;
		buttonB_0.TextLocation_Y = 5;
		toolTip_0.SetToolTip(buttonB_0, Class16.smethod_0(1649014457));
		buttonB_0.UseVisualStyleBackColor = true;
		buttonB_0.Click += buttonB_0_Click;
		openFileDialog_0.FileName = Class16.smethod_0(1649065387);
		openFileDialog_0.Filter = Class16.smethod_0(1649118169);
		richTextBox_0.BackColor = Color.WhiteSmoke;
		richTextBox_0.BorderStyle = BorderStyle.None;
		richTextBox_0.Cursor = Cursors.SizeNS;
		richTextBox_0.Location = new Point(3, 33);
		richTextBox_0.Name = Class16.smethod_0(1649117191);
		richTextBox_0.ReadOnly = true;
		richTextBox_0.ScrollBars = RichTextBoxScrollBars.Vertical;
		richTextBox_0.Size = new Size(727, 438);
		richTextBox_0.TabIndex = 5;
		richTextBox_0.Text = string.Empty;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.WhiteSmoke;
		base.ClientSize = new Size(730, 473);
		base.Controls.Add(richTextBox_0);
		base.Controls.Add(panel_0);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Name = Class16.smethod_0(1649117200);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649118502);
		panel_0.ResumeLayout(performLayout: false);
		panel_0.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void panel_0_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			bool_0 = true;
			Point point = PointToScreen(new Point(e.X, e.Y));
			point_1 = new Point
			{
				X = base.Location.X - point.X,
				Y = base.Location.Y - point.Y
			};
		}
		else
		{
			bool_0 = false;
		}
		if (e.Clicks == 2)
		{
			bool_0 = false;
		}
	}

	private void panel_0_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_0)
		{
			Point location = panel_0.PointToScreen(new Point(e.X, e.Y));
			location.Offset(point_1);
			base.Location = location;
			if ((base.Location.X > 2 || base.Location.Y > 2) && base.WindowState == FormWindowState.Maximized)
			{
				base.Location = point_0;
				base.Size = size_0;
				bool_1 = false;
			}
		}
	}

	private void panel_0_MouseUp(object sender, MouseEventArgs e)
	{
		bool_0 = false;
		if (base.Location.Y <= 5 && !bool_1)
		{
			size_0 = base.Size;
			point_0 = base.Location;
			Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
			base.Location = new Point(0, 0);
			base.Size = new Size(workingArea.Width, workingArea.Height);
			bool_1 = true;
		}
	}

	private void label_0_MouseDown(object sender, MouseEventArgs e)
	{
		panel_0_MouseDown(sender, e);
	}

	private void label_0_MouseMove(object sender, MouseEventArgs e)
	{
		panel_0_MouseMove(sender, e);
	}

	private void label_0_MouseUp(object sender, MouseEventArgs e)
	{
		panel_0_MouseUp(sender, e);
	}
}
