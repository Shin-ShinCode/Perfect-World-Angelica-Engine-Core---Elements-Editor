using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.sTASKedit.Classes;

namespace ACE.sTASKedit.Forms;

public class TranslationSettingsWindow : Form
{
	private IContainer icontainer_0;

	private Label label_0;

	private CheckBox checkBox_0;

	private Label label_1;

	private ComboBox comboBox_0;

	private Button button_0;

	private Button button_1;

	public TranslationSettingsWindow()
	{
		method_4();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		method_0();
		method_1();
	}

	private void method_0()
	{
		comboBox_0.Items.Clear();
		foreach (LanguageInfo supportedLanguage in TranslationService.GetSupportedLanguages())
		{
			if (!string.Equals(supportedLanguage.Code, Class16.smethod_0(1648897915), StringComparison.OrdinalIgnoreCase))
			{
				comboBox_0.Items.Add(supportedLanguage);
			}
		}
	}

	private void method_1()
	{
		TranslationSettings translationSettings = ACE.sTASKedit.Classes.Settings.Fields.TranslationSettings;
		checkBox_0.Checked = translationSettings.EnableAutoTranslation;
		method_2(translationSettings.TargetLanguage);
	}

	private void method_2(string string_0)
	{
		string value = (string.IsNullOrWhiteSpace(string_0) ? Class16.smethod_0(1649156964) : string_0.Trim());
		int num = 0;
		while (true)
		{
			if (num < comboBox_0.Items.Count)
			{
				if (comboBox_0.Items[num] is LanguageInfo languageInfo && languageInfo.Code.Equals(value, StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = -1;
			for (int i = 0; i < comboBox_0.Items.Count; i++)
			{
				if (comboBox_0.Items[i] is LanguageInfo languageInfo2 && languageInfo2.Code.Equals(Class16.smethod_0(1649156964), StringComparison.OrdinalIgnoreCase))
				{
					num2 = i;
					break;
				}
			}
			comboBox_0.SelectedIndex = ((num2 >= 0) ? num2 : ((comboBox_0.Items.Count <= 0) ? (-1) : 0));
			return;
		}
		comboBox_0.SelectedIndex = num;
	}

	private void method_3()
	{
		TranslationSettings translationSettings = ACE.sTASKedit.Classes.Settings.Fields.TranslationSettings;
		translationSettings.EnableAutoTranslation = checkBox_0.Checked;
		translationSettings.SourceLanguage = Class16.smethod_0(1648897915);
		if (comboBox_0.SelectedItem is LanguageInfo languageInfo)
		{
			translationSettings.TargetLanguage = languageInfo.Code;
		}
		else if (string.IsNullOrWhiteSpace(translationSettings.TargetLanguage))
		{
			translationSettings.TargetLanguage = Class16.smethod_0(1649156964);
		}
		ACE.sTASKedit.Classes.Settings.WriteXml();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedItem == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649249479)), TextStorage.Msg(Class16.smethod_0(1649249506)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		method_3();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
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
		checkBox_0 = new CheckBox();
		label_1 = new Label();
		comboBox_0 = new ComboBox();
		button_0 = new Button();
		button_1 = new Button();
		SuspendLayout();
		label_0.Location = new Point(12, 9);
		label_0.Name = Class16.smethod_0(1649249543);
		label_0.Size = new Size(560, 54);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1649249559);
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(15, 82);
		checkBox_0.Name = Class16.smethod_0(1649249736);
		checkBox_0.Size = new Size(276, 17);
		checkBox_0.TabIndex = 1;
		checkBox_0.Text = Class16.smethod_0(1649249775);
		checkBox_0.UseVisualStyleBackColor = true;
		label_1.AutoSize = true;
		label_1.Location = new Point(12, 121);
		label_1.Name = Class16.smethod_0(1649248803);
		label_1.Size = new Size(136, 13);
		label_1.TabIndex = 2;
		label_1.Text = Class16.smethod_0(1649248837);
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(154, 118);
		comboBox_0.Name = Class16.smethod_0(1649248868);
		comboBox_0.Size = new Size(418, 21);
		comboBox_0.TabIndex = 3;
		button_0.Location = new Point(386, 167);
		button_0.Name = Class16.smethod_0(1649195699);
		button_0.Size = new Size(90, 30);
		button_0.TabIndex = 4;
		button_0.Text = Class16.smethod_0(1648941761);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.DialogResult = DialogResult.Cancel;
		button_1.Location = new Point(482, 167);
		button_1.Name = Class16.smethod_0(1648992414);
		button_1.Size = new Size(90, 30);
		button_1.TabIndex = 5;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = button_1;
		base.ClientSize = new Size(584, 209);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(comboBox_0);
		base.Controls.Add(label_1);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(label_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649248892);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649248924);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
