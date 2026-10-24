using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.License;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class OperationsByID : Form
{
	private CommonStorage commonStorage_0;

	private ACE.Elements.eListCollection.eListCollection eListCollection_0;

	private SettingsClass settingsClass_0;

	public string[] result;

	private TextBox textBox_0;

	private ComboBox comboBox_0;

	private ComboBox comboBox_1;

	private TextBox textBox_1;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private GroupBox groupBox_0;

	private RadioButton radioButton_2;

	private ToolTip toolTip_0;

	private Button button_0;

	private Button button_1;

	private IContainer icontainer_0;

	public OperationsByID(ACE.Elements.eListCollection.eListCollection ref_eLC, CommonStorage ref_CStorage, int SelectedList)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			commonStorage_0 = ref_CStorage;
			settingsClass_0 = CommonStorage.Profile;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			eListCollection_0 = ref_eLC;
			settingsClass_0.DefaultSection = Class16.smethod_0(1648967784);
			switch (settingsClass_0.GetSetting(Class16.smethod_0(1648930017), 0, int.MinValue, int.MaxValue))
			{
			case 0:
				radioButton_1.Checked = true;
				break;
			case 1:
				radioButton_2.Checked = true;
				break;
			case 2:
				radioButton_0.Checked = true;
				break;
			}
			int setting = settingsClass_0.GetSetting(Class16.smethod_0(1648967813), 0, int.MinValue, int.MaxValue);
			comboBox_1.SelectedIndex = setting;
			int setting2 = settingsClass_0.GetSetting(Class16.smethod_0(1648967837), 0, int.MinValue, int.MaxValue);
			comboBox_0.SelectedIndex = setting2;
			settingsClass_0.DefaultSection = Class16.smethod_0(1648898876);
			if (SelectedList > -1)
			{
				int num = SelectedList;
				textBox_1.Text = num.ToString();
			}
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void method_0()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(OperationsByID));
		button_0 = new Button();
		button_1 = new Button();
		textBox_0 = new TextBox();
		comboBox_0 = new ComboBox();
		comboBox_1 = new ComboBox();
		textBox_1 = new TextBox();
		radioButton_0 = new RadioButton();
		radioButton_1 = new RadioButton();
		groupBox_0 = new GroupBox();
		radioButton_2 = new RadioButton();
		toolTip_0 = new ToolTip(icontainer_0);
		groupBox_0.SuspendLayout();
		SuspendLayout();
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.OperationsByID_cmdCancel;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(328, 128);
		button_0.Name = Class16.smethod_0(1649000848);
		button_0.Size = new Size(308, 38);
		button_0.TabIndex = 33;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648989215);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.OK;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.OperationsByID_cmdOk;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(3, 128);
		button_1.Name = Class16.smethod_0(1648973834);
		button_1.Size = new Size(318, 38);
		button_1.TabIndex = 0;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648989226);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_0.Location = new Point(337, 12);
		textBox_0.MaxLength = 2000000000;
		textBox_0.Name = Class16.smethod_0(1648928945);
		textBox_0.Size = new Size(296, 22);
		textBox_0.TabIndex = 58;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1648967850),
			Class16.smethod_0(1648967901)
		});
		comboBox_0.Location = new Point(4, 12);
		comboBox_0.Name = Class16.smethod_0(1648967837);
		comboBox_0.Size = new Size(327, 25);
		comboBox_0.TabIndex = 63;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1648967942),
			Class16.smethod_0(1648967963),
			Class16.smethod_0(1648968012)
		});
		comboBox_1.Location = new Point(4, 43);
		comboBox_1.Name = Class16.smethod_0(1648967813);
		comboBox_1.Size = new Size(327, 25);
		comboBox_1.TabIndex = 64;
		comboBox_1.SelectedIndexChanged += comboBox_1_SelectedIndexChanged;
		textBox_1.Location = new Point(337, 43);
		textBox_1.Name = Class16.smethod_0(1648968068);
		textBox_1.Size = new Size(296, 22);
		textBox_1.TabIndex = 65;
		radioButton_0.AutoSize = true;
		radioButton_0.Checked = true;
		radioButton_0.Location = new Point(527, 19);
		radioButton_0.Name = Class16.smethod_0(1648968082);
		radioButton_0.Size = new Size(58, 17);
		radioButton_0.TabIndex = 66;
		radioButton_0.TabStop = true;
		radioButton_0.Text = Class16.smethod_0(1648925718);
		radioButton_0.UseVisualStyleBackColor = true;
		radioButton_1.AutoSize = true;
		radioButton_1.Location = new Point(38, 19);
		radioButton_1.Name = Class16.smethod_0(1648968111);
		radioButton_1.Size = new Size(190, 17);
		radioButton_1.TabIndex = 67;
		radioButton_1.Text = Class16.smethod_0(1648968132);
		radioButton_1.UseVisualStyleBackColor = true;
		radioButton_1.Click += radioButton_1_Click;
		groupBox_0.Controls.Add(radioButton_2);
		groupBox_0.Controls.Add(radioButton_1);
		groupBox_0.Controls.Add(radioButton_0);
		groupBox_0.Location = new Point(4, 75);
		groupBox_0.Name = Class16.smethod_0(1648968161);
		groupBox_0.Size = new Size(630, 47);
		groupBox_0.TabIndex = 68;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1648968177);
		radioButton_2.AutoSize = true;
		radioButton_2.Location = new Point(267, 19);
		radioButton_2.Name = Class16.smethod_0(1648971282);
		radioButton_2.Size = new Size(182, 17);
		radioButton_2.TabIndex = 68;
		radioButton_2.Text = Class16.smethod_0(1648971314);
		radioButton_2.UseVisualStyleBackColor = true;
		base.AcceptButton = button_1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_0;
		base.ClientSize = new Size(639, 168);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(textBox_1);
		base.Controls.Add(comboBox_1);
		base.Controls.Add(comboBox_0);
		base.Controls.Add(textBox_0);
		base.Controls.Add(button_0);
		base.Controls.Add(button_1);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.OperationsByID_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648967784);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648971359);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
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

	private void button_1_Click(object sender, EventArgs e)
	{
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			TextStorage.TEXTS.ShowMessage(913, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
			GC.KeepAlive(this);
			return;
		}
		if (radioButton_1.Checked)
		{
			settingsClass_0.SaveSetting(Class16.smethod_0(1648967784), Class16.smethod_0(1648930017), Class16.smethod_0(1648924112));
		}
		else if (radioButton_2.Checked)
		{
			settingsClass_0.SaveSetting(Class16.smethod_0(1648967784), Class16.smethod_0(1648930017), Class16.smethod_0(1648934925));
		}
		else if (radioButton_0.Checked)
		{
			settingsClass_0.SaveSetting(Class16.smethod_0(1648967784), Class16.smethod_0(1648930017), Class16.smethod_0(1648934967));
		}
		settingsClass_0.SaveSetting(Class16.smethod_0(1648967784), Class16.smethod_0(1648967837), comboBox_0.SelectedIndex);
		settingsClass_0.SaveSetting(Class16.smethod_0(1648967784), Class16.smethod_0(1648967813), comboBox_1.SelectedIndex);
		int[] array = null;
		int[] array2 = null;
		if (string.IsNullOrEmpty(textBox_0.Text))
		{
			GC.KeepAlive(this);
			return;
		}
		try
		{
			string value = Class16.smethod_0(1648928028);
			if (textBox_0.Text.Contains(value))
			{
				comboBox_0.SelectedIndex = 0;
			}
			else
			{
				string value2 = Class16.smethod_0(1648941518);
				if (textBox_0.Text.Contains(value2))
				{
					comboBox_0.SelectedIndex = 1;
				}
				else
				{
					comboBox_0.SelectedIndex = 0;
				}
			}
			array = ACE.RSGlobal.RSGlobal.TryParseInts(textBox_0.Text);
			switch (comboBox_1.SelectedIndex)
			{
			case 0:
			{
				int endval = (int)((nint)eListCollection_0.Lists.LongLength - 1);
				array2 = ACE.RSGlobal.RSGlobal.IntArray(0, endval, 1);
				break;
			}
			case 1:
				array2 = eListCollection_0.MattersLists;
				break;
			case 2:
				array2 = eListCollection_0.ParseLists(textBox_1.Text);
				break;
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648967784));
		}
		if (array2 != null && array2.Length != 0)
		{
			if (radioButton_1.Checked && (nint)array2.LongLength > 1)
			{
				TextStorage.TEXTS.ShowErrorMessage(143);
				GC.KeepAlive(this);
				return;
			}
			object[] vars2 = new object[0];
			eListCollection_0.ActionsHistory.SubStagesBegin(-1, null, 146, vars2);
			List<ITEMPOS> list = new List<ITEMPOS>(50);
			int num = 0;
			int num2 = 0;
			if (0 < (nint)array2.LongLength)
			{
				do
				{
					int num3 = array2[num2];
					ACE.Elements.eListCollection.eListCollection eListCollection2 = eListCollection_0;
					if (num3 != eListCollection2.ConversationListIndex && num3 >= 0 && num3 <= (nint)eListCollection2.Lists.LongLength - 1)
					{
						int num4 = 0;
						if (0 < eListCollection2.GetItemsCount(num3))
						{
							do
							{
								int value3 = eListCollection_0.getid(num3, num4);
								if (array != null && array.Length != 0 && Array.IndexOf(array, value3) > -1)
								{
									if (radioButton_0.Checked)
									{
										int[] itemsindices = new int[1] { num4 };
										eListCollection_0.ActionsHistory.stDeleteItems(num3, itemsindices);
										eListCollection_0.RemoveItem(num3, num4);
										eListCollection_0.ActionsHistory.Complete();
										num++;
										num4--;
									}
									else
									{
										list.Add(new ITEMPOS(num3, num4));
										num++;
									}
								}
								num4++;
							}
							while (num4 < eListCollection_0.GetItemsCount(num3));
						}
					}
					num2++;
				}
				while (num2 < (nint)array2.LongLength);
			}
			eListCollection_0.ActionsHistory.SubStagesComplete(-1, null);
			if (radioButton_0.Checked)
			{
				object[] vars3 = new object[1] { num };
				TextStorage.TEXTS.ShowMessage(144, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars3);
			}
			else if (radioButton_1.Checked)
			{
				CommonStorage.iData = 1;
				CommonStorage.oData = list;
				object[] vars4 = new object[1] { num };
				TextStorage.TEXTS.ShowMessage(145, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars4);
			}
			else if (radioButton_2 != null)
			{
				CommonStorage.iData = 2;
				CommonStorage.oData = list;
				object[] vars5 = new object[1] { num };
				TextStorage.TEXTS.ShowMessage(145, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars5);
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}
		else
		{
			TextStorage.TEXTS.ShowErrorMessage(142);
			GC.KeepAlive(this);
		}
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		byte b = ((comboBox_1.SelectedIndex == 2) ? ((byte)1) : ((byte)0));
		textBox_1.Enabled = b != 0;
		GC.KeepAlive(this);
	}

	private void radioButton_1_Click(object sender, EventArgs e)
	{
		comboBox_1.SelectedIndex = 2;
		GC.KeepAlive(this);
	}
}
