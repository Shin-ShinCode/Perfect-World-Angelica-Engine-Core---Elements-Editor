using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class MasksEditorForm : Form
{
	private bool bool_0 = true;

	private SetIntValue setIntValue_0;

	private int int_0;

	private IContainer icontainer_0;

	private TextBox textBox_0;

	private Button button_0;

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

	private CheckBox checkBox_12;

	private CheckBox checkBox_13;

	private CheckBox checkBox_14;

	private CheckBox checkBox_15;

	private CheckBox checkBox_16;

	private CheckBox checkBox_17;

	public event SetIntValue ChangeValue
	{
		[CompilerGenerated]
		add
		{
			SetIntValue setIntValue = setIntValue_0;
			SetIntValue setIntValue2;
			do
			{
				setIntValue2 = setIntValue;
				SetIntValue value2 = (SetIntValue)Delegate.Combine(setIntValue2, value);
				setIntValue = Interlocked.CompareExchange(ref setIntValue_0, value2, setIntValue2);
			}
			while ((object)setIntValue != setIntValue2);
		}
		[CompilerGenerated]
		remove
		{
			SetIntValue setIntValue = setIntValue_0;
			SetIntValue setIntValue2;
			do
			{
				setIntValue2 = setIntValue;
				SetIntValue value2 = (SetIntValue)Delegate.Remove(setIntValue2, value);
				setIntValue = Interlocked.CompareExchange(ref setIntValue_0, value2, setIntValue2);
			}
			while ((object)setIntValue != setIntValue2);
		}
	}

	public MasksEditorForm(int int_1 = 0)
	{
		method_2();
		TDark.StoreOriginalColors(this);
		TDark.ApplyThemeToForm(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		method_1(int_1);
		List<uint> mask = Utils.GetMask((uint)method_0());
		for (int i = 0; i < mask.Count; i++)
		{
			if (mask[i] == 1 && base.Controls.Find(string.Format(Class16.smethod_0(1648935886), i + 1), searchAllChildren: false)[0] is CheckBox checkBox)
			{
				checkBox.Checked = true;
			}
		}
		textBox_0.Text = method_0().ToString();
		bool_0 = false;
	}

	private int method_0()
	{
		return int_0;
	}

	private void method_1(int int_1)
	{
		int_0 = int_1;
	}

	private void checkBox_17_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			CheckBox checkBox = sender as CheckBox;
			if (checkBox.Checked)
			{
				method_1(method_0() + int.Parse(checkBox.Tag.ToString()));
			}
			else
			{
				method_1(method_0() - int.Parse(checkBox.Tag.ToString()));
			}
			textBox_0.Text = method_0().ToString();
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		setIntValue_0?.Invoke(textBox_0.Text.ToInt32());
		base.DialogResult = DialogResult.OK;
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

	private void method_2()
	{
		new ComponentResourceManager(typeof(MasksEditorForm));
		textBox_0 = new TextBox();
		button_0 = new Button();
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
		checkBox_12 = new CheckBox();
		checkBox_13 = new CheckBox();
		checkBox_14 = new CheckBox();
		checkBox_15 = new CheckBox();
		checkBox_16 = new CheckBox();
		checkBox_17 = new CheckBox();
		SuspendLayout();
		textBox_0.Location = new Point(10, 10);
		textBox_0.Name = Class16.smethod_0(1648935909);
		textBox_0.Size = new Size(170, 22);
		textBox_0.TabIndex = 0;
		button_0.Location = new Point(185, 9);
		button_0.Name = Class16.smethod_0(1648941744);
		button_0.Size = new Size(97, 23);
		button_0.TabIndex = 1;
		button_0.Text = Class16.smethod_0(1648941761);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(10, 41);
		checkBox_0.Name = Class16.smethod_0(1648935920);
		checkBox_0.Size = new Size(58, 17);
		checkBox_0.TabIndex = 2;
		checkBox_0.Tag = Class16.smethod_0(1648934925);
		checkBox_0.Text = Class16.smethod_0(1648934933);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_1.AutoSize = true;
		checkBox_1.Location = new Point(10, 64);
		checkBox_1.Name = Class16.smethod_0(1648934938);
		checkBox_1.Size = new Size(58, 17);
		checkBox_1.TabIndex = 3;
		checkBox_1.Tag = Class16.smethod_0(1648934967);
		checkBox_1.Text = Class16.smethod_0(1648934975);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_2.AutoSize = true;
		checkBox_2.Location = new Point(10, 87);
		checkBox_2.Name = Class16.smethod_0(1648934988);
		checkBox_2.Size = new Size(58, 17);
		checkBox_2.TabIndex = 4;
		checkBox_2.Tag = Class16.smethod_0(1648935001);
		checkBox_2.Text = Class16.smethod_0(1648935009);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_2.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_3.AutoSize = true;
		checkBox_3.Location = new Point(10, 110);
		checkBox_3.Name = Class16.smethod_0(1648935030);
		checkBox_3.Size = new Size(58, 17);
		checkBox_3.TabIndex = 5;
		checkBox_3.Tag = Class16.smethod_0(1648935043);
		checkBox_3.Text = Class16.smethod_0(1648935051);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_3.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(10, 133);
		checkBox_4.Name = Class16.smethod_0(1648935064);
		checkBox_4.Size = new Size(58, 17);
		checkBox_4.TabIndex = 6;
		checkBox_4.Tag = Class16.smethod_0(1648935093);
		checkBox_4.Text = Class16.smethod_0(1648935102);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_4.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_5.AutoSize = true;
		checkBox_5.Location = new Point(10, 156);
		checkBox_5.Name = Class16.smethod_0(1648935107);
		checkBox_5.Size = new Size(58, 17);
		checkBox_5.TabIndex = 7;
		checkBox_5.Tag = Class16.smethod_0(1648935128);
		checkBox_5.Text = Class16.smethod_0(1648935137);
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_5.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_6.AutoSize = true;
		checkBox_6.Location = new Point(10, 179);
		checkBox_6.Name = Class16.smethod_0(1648935158);
		checkBox_6.Size = new Size(58, 17);
		checkBox_6.TabIndex = 8;
		checkBox_6.Tag = Class16.smethod_0(1648935171);
		checkBox_6.Text = Class16.smethod_0(1648935188);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_6.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_7.AutoSize = true;
		checkBox_7.Location = new Point(10, 202);
		checkBox_7.Name = Class16.smethod_0(1648935193);
		checkBox_7.Size = new Size(58, 17);
		checkBox_7.TabIndex = 9;
		checkBox_7.Tag = Class16.smethod_0(1648935222);
		checkBox_7.Text = Class16.smethod_0(1648935224);
		checkBox_7.UseVisualStyleBackColor = true;
		checkBox_7.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_8.AutoSize = true;
		checkBox_8.Location = new Point(10, 225);
		checkBox_8.Name = Class16.smethod_0(1648935245);
		checkBox_8.Size = new Size(58, 17);
		checkBox_8.TabIndex = 10;
		checkBox_8.Tag = Class16.smethod_0(1648935258);
		checkBox_8.Text = Class16.smethod_0(1648935276);
		checkBox_8.UseVisualStyleBackColor = true;
		checkBox_8.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_9.AutoSize = true;
		checkBox_9.Location = new Point(10, 248);
		checkBox_9.Name = Class16.smethod_0(1648935281);
		checkBox_9.Size = new Size(64, 17);
		checkBox_9.TabIndex = 11;
		checkBox_9.Tag = Class16.smethod_0(1648935311);
		checkBox_9.Text = Class16.smethod_0(1648935313);
		checkBox_9.UseVisualStyleBackColor = true;
		checkBox_9.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_10.AutoSize = true;
		checkBox_10.Location = new Point(10, 271);
		checkBox_10.Name = Class16.smethod_0(1648935335);
		checkBox_10.Size = new Size(64, 17);
		checkBox_10.TabIndex = 12;
		checkBox_10.Tag = Class16.smethod_0(1648935357);
		checkBox_10.Text = Class16.smethod_0(1648935360);
		checkBox_10.UseVisualStyleBackColor = true;
		checkBox_10.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_11.AutoSize = true;
		checkBox_11.Location = new Point(10, 294);
		checkBox_11.Name = Class16.smethod_0(1648935382);
		checkBox_11.Size = new Size(64, 17);
		checkBox_11.TabIndex = 13;
		checkBox_11.Tag = Class16.smethod_0(1648935404);
		checkBox_11.Text = Class16.smethod_0(1648935415);
		checkBox_11.UseVisualStyleBackColor = true;
		checkBox_11.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_12.AutoSize = true;
		checkBox_12.Location = new Point(10, 317);
		checkBox_12.Name = Class16.smethod_0(1648938501);
		checkBox_12.Size = new Size(64, 17);
		checkBox_12.TabIndex = 14;
		checkBox_12.Tag = Class16.smethod_0(1648938515);
		checkBox_12.Text = Class16.smethod_0(1648938534);
		checkBox_12.UseVisualStyleBackColor = true;
		checkBox_12.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_13.AutoSize = true;
		checkBox_13.Location = new Point(10, 340);
		checkBox_13.Name = Class16.smethod_0(1648938548);
		checkBox_13.Size = new Size(64, 17);
		checkBox_13.TabIndex = 15;
		checkBox_13.Tag = Class16.smethod_0(1648938562);
		checkBox_13.Text = Class16.smethod_0(1648938581);
		checkBox_13.UseVisualStyleBackColor = true;
		checkBox_13.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_14.AutoSize = true;
		checkBox_14.Location = new Point(10, 363);
		checkBox_14.Name = Class16.smethod_0(1648938587);
		checkBox_14.Size = new Size(64, 17);
		checkBox_14.TabIndex = 16;
		checkBox_14.Tag = Class16.smethod_0(1648938609);
		checkBox_14.Text = Class16.smethod_0(1648938629);
		checkBox_14.UseVisualStyleBackColor = true;
		checkBox_14.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_15.AutoSize = true;
		checkBox_15.Location = new Point(10, 386);
		checkBox_15.Name = Class16.smethod_0(1648938635);
		checkBox_15.Size = new Size(64, 17);
		checkBox_15.TabIndex = 17;
		checkBox_15.Tag = Class16.smethod_0(1648938657);
		checkBox_15.Text = Class16.smethod_0(1648938677);
		checkBox_15.UseVisualStyleBackColor = true;
		checkBox_15.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_16.AutoSize = true;
		checkBox_16.Location = new Point(10, 409);
		checkBox_16.Name = Class16.smethod_0(1648938683);
		checkBox_16.Size = new Size(64, 17);
		checkBox_16.TabIndex = 18;
		checkBox_16.Tag = Class16.smethod_0(1648938705);
		checkBox_16.Text = Class16.smethod_0(1648938725);
		checkBox_16.UseVisualStyleBackColor = true;
		checkBox_16.CheckedChanged += checkBox_17_CheckedChanged;
		checkBox_17.AutoSize = true;
		checkBox_17.Location = new Point(10, 432);
		checkBox_17.Name = Class16.smethod_0(1648938731);
		checkBox_17.Size = new Size(64, 17);
		checkBox_17.TabIndex = 19;
		checkBox_17.Tag = Class16.smethod_0(1648938753);
		checkBox_17.Text = Class16.smethod_0(1648938774);
		checkBox_17.UseVisualStyleBackColor = true;
		checkBox_17.CheckedChanged += checkBox_17_CheckedChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(300, 460);
		base.Controls.Add(checkBox_17);
		base.Controls.Add(checkBox_16);
		base.Controls.Add(checkBox_15);
		base.Controls.Add(checkBox_14);
		base.Controls.Add(checkBox_13);
		base.Controls.Add(checkBox_12);
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
		base.Controls.Add(button_0);
		base.Controls.Add(textBox_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648938788);
		Text = Class16.smethod_0(1648938802);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
