using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class OperationSelectorForm : Form
{
	private int int_0;

	private IOperation ioperation_0;

	private List<IOperation> list_0 = new List<IOperation>();

	private IContainer icontainer_0;

	private ComboBox comboBox_0;

	private Button button_0;

	public int CurrentVersion
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
	}

	public IOperation Op
	{
		[CompilerGenerated]
		get
		{
			return ioperation_0;
		}
		[CompilerGenerated]
		set
		{
			ioperation_0 = value;
		}
	}

	public OperationSelectorForm(int version)
	{
		method_3();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		method_0(version);
		foreach (int knownOperationId in Operation.GetKnownOperationIds())
		{
			IOperation operation = Operation.Read(null, version, knownOperationId);
			if (operation != null)
			{
				method_1().Add(operation);
			}
		}
		foreach (IOperation item in method_1())
		{
			comboBox_0.Items.Add(string.Format(Class16.smethod_0(1648942645), item.Name, MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648942674)), item.FromVersion));
		}
	}

	private void method_0(int int_1)
	{
		int_0 = int_1;
	}

	private List<IOperation> method_1()
	{
		return list_0;
	}

	private void method_2(List<IOperation> list_1)
	{
		list_0 = list_1;
	}

	public int GetUpdatedVersion()
	{
		return CurrentVersion;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedIndex > -1)
		{
			Op = method_1()[comboBox_0.SelectedIndex];
			if (Op.FromVersion > CurrentVersion)
			{
				method_0(Op.FromVersion);
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_3()
	{
		new ComponentResourceManager(typeof(OperationSelectorForm));
		comboBox_0 = new ComboBox();
		button_0 = new Button();
		SuspendLayout();
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(10, 10);
		comboBox_0.Name = Class16.smethod_0(1648937312);
		comboBox_0.Size = new Size(272, 21);
		comboBox_0.TabIndex = 0;
		button_0.Location = new Point(10, 41);
		button_0.Name = Class16.smethod_0(1648935792);
		button_0.Size = new Size(272, 23);
		button_0.TabIndex = 1;
		button_0.Text = Class16.smethod_0(1648935811);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(300, 110);
		base.Controls.Add(button_0);
		base.Controls.Add(comboBox_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648937337);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648937373);
		ResumeLayout(performLayout: false);
	}
}
