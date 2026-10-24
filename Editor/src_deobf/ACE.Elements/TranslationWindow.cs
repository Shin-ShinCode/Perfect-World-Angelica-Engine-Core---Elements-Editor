using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.Properties;

namespace ACE.Elements;

public class TranslationWindow : Form
{
	public ACE.Elements.eListCollection.eListCollection eLC;

	public ITEMS_COLLECTION Items;

	public bool bAbort;

	private ComboBox comboBox_0;

	private Label label_0;

	private Label label_1;

	private ComboBox comboBox_1;

	private ProgressBar progressBar_0;

	private Button button_0;

	private Button button_1;

	private IContainer icontainer_0;

	private Button button_2;

	private ToolTip toolTip_0;

	private StatusStrip statusStrip_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private CheckBox checkBox_0;

	public TranslationWindow(ACE.Elements.eListCollection.eListCollection eLC, ITEMS_COLLECTION Items)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			this.eLC = eLC;
			this.Items = Items;
			TextStorage.TEXTS.SetFormLanguage(this, null);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(comboBox_0.Text) && !string.IsNullOrEmpty(comboBox_1.Text))
		{
			ComboBox comboBox = comboBox_0;
			CommonStorage.Profile.SaveSetting(Class16.smethod_0(1648965955), Class16.smethod_0(1648965979), comboBox.Text);
			ComboBox comboBox2 = comboBox_1;
			CommonStorage.Profile.SaveSetting(Class16.smethod_0(1648965955), Class16.smethod_0(1648965998), comboBox2.Text);
			int num = 0;
			List<vITEMPOS>.Enumerator enumerator = Items.GetListOfItems().GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					vITEMPOS current = enumerator.Current;
					object[] array = new object[2];
					num++;
					array[0] = num;
					array[1] = Items.Count;
					string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648966007), array);
					toolStripStatusLabel_0.Text = text;
					int count = Items.Count;
					int value;
					if (num <= 0)
					{
						value = 0;
					}
					else if (count <= 0)
					{
						value = 100;
					}
					else
					{
						int num2 = 1 - (int)((double)num / (double)count * -99.0);
						num2 = ((num2 > 100) ? 100 : num2);
						value = num2;
					}
					progressBar_0.Value = value;
					Application.DoEvents();
					if (bAbort)
					{
						break;
					}
					CheckBox checkBox = checkBox_0;
					ComboBox comboBox3 = comboBox_1;
					ComboBox comboBox4 = comboBox_0;
					eLC.TranslateItem(current, comboBox4.SelectedIndex, comboBox3.SelectedIndex, checkBox.Checked);
				}
				while (enumerator.MoveNext());
			}
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		string text = comboBox_0.Text;
		comboBox_0.Text = comboBox_1.Text;
		comboBox_1.Text = text;
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		bAbort = true;
		Close();
	}

	private void TranslationWindow_Load(object sender, EventArgs e)
	{
		UniversalTranslator.OpenAIApiKey = CommonStorage.AParams.OpenAIApiKey;
		UniversalTranslator.OpenAIBaseUrl = CommonStorage.AParams.OpenAIBaseUrl;
		if (CommonStorage.License.Special.UseOpenAITranslator || !string.IsNullOrWhiteSpace(CommonStorage.AParams.OpenAIApiKey))
		{
			UniversalTranslator.SwitchTranslator(useOpenAi: true);
		}
		if (UniversalTranslator.Init())
		{
			string[] languagesNames = UniversalTranslator.GetLanguagesNames();
			ComboBox.ObjectCollection items = comboBox_0.Items;
			object[] items2 = languagesNames;
			items.AddRange(items2);
			ComboBox.ObjectCollection items3 = comboBox_1.Items;
			items2 = languagesNames;
			items3.AddRange(items2);
			comboBox_0.SelectedItem = CommonStorage.Profile.GetSetting(Class16.smethod_0(1648965955), Class16.smethod_0(1648965979), Class16.smethod_0(1648897915));
			comboBox_1.SelectedItem = CommonStorage.Profile.GetSetting(Class16.smethod_0(1648965955), Class16.smethod_0(1648965998), Class16.smethod_0(1648932116));
			if (comboBox_0.SelectedIndex == -1)
			{
				comboBox_0.SelectedItem = Class16.smethod_0(1648897915);
			}
			if (comboBox_1.SelectedIndex == -1)
			{
				comboBox_1.SelectedIndex = UniversalTranslator.pt_index;
			}
		}
		else
		{
			Close();
		}
	}

	private void method_0()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(TranslationWindow));
		comboBox_0 = new ComboBox();
		label_0 = new Label();
		label_1 = new Label();
		comboBox_1 = new ComboBox();
		progressBar_0 = new ProgressBar();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		statusStrip_0 = new StatusStrip();
		toolStripStatusLabel_0 = new ToolStripStatusLabel();
		checkBox_0 = new CheckBox();
		statusStrip_0.SuspendLayout();
		SuspendLayout();
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f);
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(131, 6);
		comboBox_0.Margin = new Padding(4);
		comboBox_0.Name = Class16.smethod_0(1648966030);
		comboBox_0.Size = new Size(414, 25);
		comboBox_0.TabIndex = 2;
		label_0.Location = new Point(0, 9);
		label_0.Margin = new Padding(4, 0, 4, 0);
		label_0.Name = Class16.smethod_0(1648966044);
		label_0.Size = new Size(131, 17);
		label_0.TabIndex = 3;
		label_0.Text = Class16.smethod_0(1648966057);
		label_0.TextAlign = ContentAlignment.MiddleRight;
		label_1.Location = new Point(0, 40);
		label_1.Margin = new Padding(4, 0, 4, 0);
		label_1.Name = Class16.smethod_0(1648966081);
		label_1.Size = new Size(131, 17);
		label_1.TabIndex = 5;
		label_1.Text = Class16.smethod_0(1648966106);
		label_1.TextAlign = ContentAlignment.MiddleRight;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.Font = new Font(Class16.smethod_0(1648942905), 9.75f);
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Location = new Point(131, 37);
		comboBox_1.Margin = new Padding(4);
		comboBox_1.Name = Class16.smethod_0(1648966131);
		comboBox_1.Size = new Size(414, 25);
		comboBox_1.TabIndex = 4;
		progressBar_0.Location = new Point(8, 69);
		progressBar_0.Name = Class16.smethod_0(1648972329);
		progressBar_0.Size = new Size(569, 23);
		progressBar_0.TabIndex = 40;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.TranslationWindow_cmdcancel;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(7, 160);
		button_0.Name = Class16.smethod_0(1648925752);
		button_0.Size = new Size(570, 46);
		button_0.TabIndex = 42;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648989215);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.OK;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.cmdStart;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(7, 127);
		button_1.Name = Class16.smethod_0(1648961031);
		button_1.Size = new Size(570, 46);
		button_1.TabIndex = 41;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648978128);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.AutoSize = true;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_2.Image = Resources.cmdExchange;
		button_2.Location = new Point(552, 5);
		button_2.Name = Class16.smethod_0(1648961046);
		button_2.Size = new Size(25, 57);
		button_2.TabIndex = 43;
		button_2.TabStop = false;
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_0.SetToolTip(button_2, Class16.smethod_0(1648961056));
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		statusStrip_0.ImageScalingSize = new Size(32, 32);
		statusStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripStatusLabel_0 });
		statusStrip_0.Location = new Point(0, 195);
		statusStrip_0.Name = Class16.smethod_0(1649003514);
		statusStrip_0.Size = new Size(586, 22);
		statusStrip_0.TabIndex = 44;
		statusStrip_0.Text = Class16.smethod_0(1649003514);
		toolStripStatusLabel_0.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripStatusLabel_0.Name = Class16.smethod_0(1648961067);
		toolStripStatusLabel_0.Size = new Size(0, 17);
		checkBox_0.Appearance = Appearance.Button;
		checkBox_0.Checked = true;
		checkBox_0.CheckState = CheckState.Checked;
		checkBox_0.Image = Resources.chkTranslateItemDesc;
		checkBox_0.ImageAlign = ContentAlignment.MiddleRight;
		checkBox_0.Location = new Point(8, 98);
		checkBox_0.Name = Class16.smethod_0(1648961080);
		checkBox_0.Size = new Size(569, 28);
		checkBox_0.TabIndex = 45;
		checkBox_0.Text = Class16.smethod_0(1648961107);
		checkBox_0.TextAlign = ContentAlignment.MiddleCenter;
		checkBox_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		checkBox_0.UseVisualStyleBackColor = true;
		base.AcceptButton = button_1;
		base.AutoScaleDimensions = new SizeF(7f, 17f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_0;
		base.ClientSize = new Size(586, 217);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(statusStrip_0);
		base.Controls.Add(button_2);
		base.Controls.Add(button_0);
		base.Controls.Add(button_1);
		base.Controls.Add(progressBar_0);
		base.Controls.Add(label_1);
		base.Controls.Add(comboBox_1);
		base.Controls.Add(label_0);
		base.Controls.Add(comboBox_0);
		Font = new Font(Class16.smethod_0(1648942905), 9.75f);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.Icon = Resources.edit;
		base.Margin = new Padding(4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648965955);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648961161);
		base.Load += TranslationWindow_Load;
		statusStrip_0.ResumeLayout(performLayout: false);
		statusStrip_0.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_0();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}
}
