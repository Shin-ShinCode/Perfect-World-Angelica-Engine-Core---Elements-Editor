using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.tasks;

namespace ACE.sTASKedit.Forms;

public class PlayerWantedOccupationsWindow : Form
{
	private uint uint_0;

	private IContainer icontainer_0;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private CheckBox checkBox_5;

	private CheckBox checkBox_6;

	private CheckBox checkBox_7;

	private CheckBox checkBox_8;

	private CheckBox checkBox_9;

	private CheckBox checkBox_10;

	private CheckBox checkBox_11;

	private Button button_0;

	private Button button_1;

	public TextBox textBox_Occupations;

	private CheckBox checkBox_12;

	private CheckBox checkBox_13;

	private CheckBox checkBox_14;

	private CheckBox checkBox_15;

	private CheckBox checkBox_16;

	public PlayerWantedOccupationsWindow(int Occupations)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		SetLocalization();
		textBox_Occupations.Text = Occupations.ToString();
		Occupations_ClickChanged();
	}

	private void checkBox_16_CheckedChanged(object sender, EventArgs e)
	{
		if (((CheckBox)sender).Checked)
		{
			uint_0 += uint.Parse(((CheckBox)sender).Tag.ToString());
		}
		else
		{
			uint_0 -= uint.Parse(((CheckBox)sender).Tag.ToString());
		}
		textBox_Occupations.Text = uint_0.ToString();
	}

	public void Occupations_ClickChanged()
	{
		if (!uint.TryParse(textBox_Occupations.Text, out var result))
		{
			throw new Exception(GProD.TX(403));
		}
		for (int i = 0; i < base.Controls.Count; i++)
		{
			if (base.Controls[i].GetType().Name == Class16.smethod_0(1648986432))
			{
				((CheckBox)base.Controls[i]).Checked = false;
			}
		}
		List<int> list = new List<int>(GlobalFunctions.GetPowers((int)result));
		for (int j = 0; j <= 16; j++)
		{
			if (Class5.smethod_1(base.Controls.Find(string.Format(Class16.smethod_0(1649254022), j + 1), searchAllChildren: true)) is CheckBox checkBox && list.Contains(j))
			{
				checkBox.Checked = true;
			}
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	public void SetLocalization()
	{
		Text = GProD.TX(6000);
		for (int i = 1; i <= 17; i++)
		{
			if (Class5.smethod_1(base.Controls.Find(string.Format(Class16.smethod_0(1649254022), i), searchAllChildren: true)) is CheckBox checkBox)
			{
				checkBox.Text = GProD.TX(1119 + i);
			}
		}
		button_0.Text = GProD.TX(6001);
		button_1.Text = GProD.TX(6002);
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
		new ComponentResourceManager(typeof(PlayerWantedOccupationsWindow));
		textBox_Occupations = new TextBox();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		checkBox_3 = new CheckBox();
		checkBox_4 = new CheckBox();
		checkBox_5 = new CheckBox();
		checkBox_6 = new CheckBox();
		checkBox_7 = new CheckBox();
		checkBox_8 = new CheckBox();
		checkBox_9 = new CheckBox();
		checkBox_10 = new CheckBox();
		checkBox_11 = new CheckBox();
		button_0 = new Button();
		button_1 = new Button();
		checkBox_12 = new CheckBox();
		checkBox_13 = new CheckBox();
		checkBox_14 = new CheckBox();
		checkBox_15 = new CheckBox();
		checkBox_16 = new CheckBox();
		SuspendLayout();
		textBox_Occupations.Location = new Point(10, 12);
		textBox_Occupations.Name = Class16.smethod_0(1649254052);
		textBox_Occupations.Size = new Size(234, 20);
		textBox_Occupations.TabIndex = 0;
		textBox_Occupations.TextAlign = HorizontalAlignment.Center;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(10, 48);
		checkBox_0.Name = Class16.smethod_0(1649254078);
		checkBox_0.Size = new Size(84, 17);
		checkBox_0.TabIndex = 1;
		checkBox_0.Tag = Class16.smethod_0(1648934925);
		checkBox_0.Text = Class16.smethod_0(1648995233);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_1.AutoSize = true;
		checkBox_1.Location = new Point(150, 48);
		checkBox_1.Name = Class16.smethod_0(1649254098);
		checkBox_1.Size = new Size(59, 17);
		checkBox_1.TabIndex = 2;
		checkBox_1.Tag = Class16.smethod_0(1648934967);
		checkBox_1.Text = Class16.smethod_0(1648995285);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_2.AutoSize = true;
		checkBox_2.Location = new Point(150, 126);
		checkBox_2.Name = Class16.smethod_0(1649254134);
		checkBox_2.Size = new Size(63, 17);
		checkBox_2.TabIndex = 3;
		checkBox_2.Tag = Class16.smethod_0(1648935001);
		checkBox_2.Text = Class16.smethod_0(1648995053);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_2.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_3.AutoSize = true;
		checkBox_3.Location = new Point(150, 74);
		checkBox_3.Name = Class16.smethod_0(1649254154);
		checkBox_3.Size = new Size(86, 17);
		checkBox_3.TabIndex = 4;
		checkBox_3.Tag = Class16.smethod_0(1648935043);
		checkBox_3.Text = Class16.smethod_0(1648995203);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_3.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(10, 74);
		checkBox_4.Name = Class16.smethod_0(1649254190);
		checkBox_4.Size = new Size(71, 17);
		checkBox_4.TabIndex = 5;
		checkBox_4.Tag = Class16.smethod_0(1648935093);
		checkBox_4.Text = Class16.smethod_0(1648995163);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_4.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_5.AutoSize = true;
		checkBox_5.Location = new Point(10, 126);
		checkBox_5.Name = Class16.smethod_0(1649254210);
		checkBox_5.Size = new Size(67, 17);
		checkBox_5.TabIndex = 6;
		checkBox_5.Tag = Class16.smethod_0(1648935128);
		checkBox_5.Text = Class16.smethod_0(1648995012);
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_5.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_6.AutoSize = true;
		checkBox_6.Location = new Point(10, 100);
		checkBox_6.Name = Class16.smethod_0(1649254246);
		checkBox_6.Size = new Size(57, 17);
		checkBox_6.TabIndex = 7;
		checkBox_6.Tag = Class16.smethod_0(1648935171);
		checkBox_6.Text = Class16.smethod_0(1648994331);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_6.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_7.AutoSize = true;
		checkBox_7.Location = new Point(150, 100);
		checkBox_7.Name = Class16.smethod_0(1649254266);
		checkBox_7.Size = new Size(52, 17);
		checkBox_7.TabIndex = 8;
		checkBox_7.Tag = Class16.smethod_0(1648935222);
		checkBox_7.Text = Class16.smethod_0(1648995324);
		checkBox_7.UseVisualStyleBackColor = true;
		checkBox_7.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_8.AutoSize = true;
		checkBox_8.Location = new Point(10, 152);
		checkBox_8.Name = Class16.smethod_0(1649254302);
		checkBox_8.Size = new Size(60, 17);
		checkBox_8.TabIndex = 9;
		checkBox_8.Tag = Class16.smethod_0(1648935258);
		checkBox_8.Text = Class16.smethod_0(1648995093);
		checkBox_8.UseVisualStyleBackColor = true;
		checkBox_8.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_9.AutoSize = true;
		checkBox_9.Location = new Point(150, 152);
		checkBox_9.Name = Class16.smethod_0(1649254322);
		checkBox_9.Size = new Size(56, 17);
		checkBox_9.TabIndex = 10;
		checkBox_9.Tag = Class16.smethod_0(1648935311);
		checkBox_9.Text = Class16.smethod_0(1648995132);
		checkBox_9.UseVisualStyleBackColor = true;
		checkBox_9.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_10.AutoSize = true;
		checkBox_10.Location = new Point(10, 178);
		checkBox_10.Name = Class16.smethod_0(1649254359);
		checkBox_10.Size = new Size(77, 17);
		checkBox_10.TabIndex = 11;
		checkBox_10.Tag = Class16.smethod_0(1648935357);
		checkBox_10.Text = Class16.smethod_0(1648994370);
		checkBox_10.UseVisualStyleBackColor = true;
		checkBox_10.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_11.AutoSize = true;
		checkBox_11.Location = new Point(150, 178);
		checkBox_11.Name = Class16.smethod_0(1649254388);
		checkBox_11.Size = new Size(85, 17);
		checkBox_11.TabIndex = 12;
		checkBox_11.Tag = Class16.smethod_0(1648935404);
		checkBox_11.Text = Class16.smethod_0(1648994420);
		checkBox_11.UseVisualStyleBackColor = true;
		checkBox_11.CheckedChanged += checkBox_16_CheckedChanged;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_0.Location = new Point(10, 163);
		button_0.Name = Class16.smethod_0(1649253385);
		button_0.Size = new Size(100, 23);
		button_0.TabIndex = 16;
		button_0.Text = Class16.smethod_0(1648938905);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_1.Location = new Point(136, 163);
		button_1.Name = Class16.smethod_0(1649262492);
		button_1.Size = new Size(100, 23);
		button_1.TabIndex = 17;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		checkBox_12.AutoSize = true;
		checkBox_12.Location = new Point(10, 204);
		checkBox_12.Name = Class16.smethod_0(1649253401);
		checkBox_12.Size = new Size(73, 17);
		checkBox_12.TabIndex = 13;
		checkBox_12.Tag = Class16.smethod_0(1648938515);
		checkBox_12.Text = Class16.smethod_0(1649253438);
		checkBox_12.UseVisualStyleBackColor = true;
		checkBox_12.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_13.AutoSize = true;
		checkBox_13.Location = new Point(150, 204);
		checkBox_13.Name = Class16.smethod_0(1649253453);
		checkBox_13.Size = new Size(73, 17);
		checkBox_13.TabIndex = 14;
		checkBox_13.Tag = Class16.smethod_0(1648938562);
		checkBox_13.Text = Class16.smethod_0(1649253474);
		checkBox_13.UseVisualStyleBackColor = true;
		checkBox_13.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_14.AutoSize = true;
		checkBox_14.Location = new Point(10, 230);
		checkBox_14.Name = Class16.smethod_0(1649253489);
		checkBox_14.Size = new Size(73, 17);
		checkBox_14.TabIndex = 15;
		checkBox_14.Tag = Class16.smethod_0(1648938609);
		checkBox_14.Text = Class16.smethod_0(1649253526);
		checkBox_14.UseVisualStyleBackColor = true;
		checkBox_14.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_15.AutoSize = true;
		checkBox_15.Location = new Point(150, 230);
		checkBox_15.Name = Class16.smethod_0(1649253541);
		checkBox_15.Size = new Size(48, 17);
		checkBox_15.TabIndex = 18;
		checkBox_15.Tag = Class16.smethod_0(1648938657);
		checkBox_15.Text = Class16.smethod_0(1648994547);
		checkBox_15.UseVisualStyleBackColor = true;
		checkBox_15.CheckedChanged += checkBox_16_CheckedChanged;
		checkBox_16.AutoSize = true;
		checkBox_16.Location = new Point(150, 230);
		checkBox_16.Name = Class16.smethod_0(1649253562);
		checkBox_16.Size = new Size(61, 17);
		checkBox_16.TabIndex = 18;
		checkBox_16.Tag = Class16.smethod_0(1648938705);
		checkBox_16.Text = Class16.smethod_0(1648994584);
		checkBox_16.UseVisualStyleBackColor = true;
		checkBox_16.CheckedChanged += checkBox_16_CheckedChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Window;
		base.ClientSize = new Size(254, 290);
		base.ControlBox = false;
		base.Controls.Add(checkBox_16);
		base.Controls.Add(checkBox_15);
		base.Controls.Add(checkBox_14);
		base.Controls.Add(checkBox_13);
		base.Controls.Add(checkBox_12);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(checkBox_11);
		base.Controls.Add(checkBox_10);
		base.Controls.Add(checkBox_9);
		base.Controls.Add(checkBox_8);
		base.Controls.Add(checkBox_7);
		base.Controls.Add(checkBox_6);
		base.Controls.Add(checkBox_5);
		base.Controls.Add(checkBox_4);
		base.Controls.Add(checkBox_3);
		base.Controls.Add(checkBox_2);
		base.Controls.Add(checkBox_1);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(textBox_Occupations);
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		MaximumSize = new Size(270, 329);
		base.MinimizeBox = false;
		MinimumSize = new Size(270, 329);
		base.Name = Class16.smethod_0(1649253599);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649253627);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
