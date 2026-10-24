using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.AIPolicyEditor.AIPolicy;
using ACE.AIPolicyEditor.AIPolicy.Conditions;
using ACE.Classes;
using ACE.Properties;

namespace ACE.AIPolicyEditor;

public class SearchFlyoutsForm : Form
{
	private List<int[]> list_0 = new List<int[]>();

	private List<int[]> list_1 = new List<int[]>();

	private AIFile aifile_0;

	private IContainer icontainer_0;

	private Label label_0;

	private TextBox textBox_0;

	private Button button_0;

	private ListBox listBox_0;

	public AIFile Aipolicy
	{
		[CompilerGenerated]
		get
		{
			return aifile_0;
		}
		[CompilerGenerated]
		set
		{
			aifile_0 = value;
		}
	}

	public SearchFlyoutsForm()
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		list_0.Clear();
		list_1.Clear();
		string text = textBox_0.Text.ToLower();
		foreach (CPolicyData controller in Aipolicy.Controllers)
		{
			if (controller.ID.ToString().Contains(text))
			{
				list_0.Add(new int[1] { controller.ID });
				list_1.Add(new int[1] { Aipolicy.Controllers.IndexOf(controller) });
			}
			foreach (CTriggerData trigger in controller.Triggers)
			{
				if (trigger.ID.ToString().Contains(text) || trigger.Name.ToString().Contains(text) || Conditions.Search(trigger.RootConditon, text))
				{
					list_0.Add(new int[2] { controller.ID, trigger.ID });
					list_1.Add(new int[2]
					{
						Aipolicy.Controllers.IndexOf(controller),
						controller.Triggers.IndexOf(trigger)
					});
				}
				foreach (IOperation operation in trigger.Operations)
				{
					if (operation.Search(text))
					{
						list_0.Add(new int[3]
						{
							controller.ID,
							trigger.ID,
							trigger.Operations.IndexOf(operation)
						});
						list_1.Add(new int[3]
						{
							Aipolicy.Controllers.IndexOf(controller),
							controller.Triggers.IndexOf(trigger),
							trigger.Operations.IndexOf(operation)
						});
					}
				}
			}
		}
		listBox_0.Items.Clear();
		foreach (int[] item in list_0)
		{
			switch (item.Length)
			{
			case 1:
				listBox_0.Items.Add(string.Format(Class16.smethod_0(1648932896), item[0]));
				break;
			case 2:
				listBox_0.Items.Add(string.Format(Class16.smethod_0(1648932925), item[0], item[1]));
				break;
			case 3:
				listBox_0.Items.Add(string.Format(Class16.smethod_0(1648932959), item[0], item[1], item[2]));
				break;
			}
		}
	}

	private void listBox_0_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		if (listBox_0.SelectedIndex > -1)
		{
			if (list_0[listBox_0.SelectedIndex].Length != 0)
			{
				Aipolicy.ControllerIndex = list_1[listBox_0.SelectedIndex][0];
			}
			if (list_0[listBox_0.SelectedIndex].Length > 1)
			{
				Aipolicy.TriggerIndex = list_1[listBox_0.SelectedIndex][1];
			}
			if (list_0[listBox_0.SelectedIndex].Length > 2)
			{
				Aipolicy.OperationIndex = list_1[listBox_0.SelectedIndex][2];
			}
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

	private void method_0()
	{
		new ComponentResourceManager(typeof(SearchFlyoutsForm));
		label_0 = new Label();
		textBox_0 = new TextBox();
		button_0 = new Button();
		listBox_0 = new ListBox();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Location = new Point(100, 4);
		label_0.Name = Class16.smethod_0(1648933000);
		label_0.Size = new Size(81, 13);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1648933025);
		textBox_0.Location = new Point(10, 30);
		textBox_0.Name = Class16.smethod_0(1648933054);
		textBox_0.Size = new Size(280, 22);
		textBox_0.TabIndex = 1;
		button_0.Location = new Point(10, 61);
		button_0.Name = Class16.smethod_0(1648933073);
		button_0.Size = new Size(280, 23);
		button_0.TabIndex = 2;
		button_0.Text = Class16.smethod_0(1648931650);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		listBox_0.BackColor = Color.FromArgb(32, 32, 32);
		listBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		listBox_0.ForeColor = Color.White;
		listBox_0.FormattingEnabled = true;
		listBox_0.ItemHeight = 15;
		listBox_0.Location = new Point(10, 105);
		listBox_0.Name = Class16.smethod_0(1648933100);
		listBox_0.Size = new Size(280, 289);
		listBox_0.TabIndex = 3;
		listBox_0.MouseDoubleClick += listBox_0_MouseDoubleClick;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(300, 450);
		base.Controls.Add(listBox_0);
		base.Controls.Add(button_0);
		base.Controls.Add(textBox_0);
		base.Controls.Add(label_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648933127);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648931650);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
