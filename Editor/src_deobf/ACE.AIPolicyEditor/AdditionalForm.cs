using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.AIPolicyEditor.AIPolicy;
using ACE.Classes;
using ACE.Properties;

namespace ACE.AIPolicyEditor;

public class AdditionalForm : Form
{
	private sealed class Class36
	{
		public IOperation ioperation_0;

		internal bool method_0(IOperation ioperation_1)
		{
			return ioperation_1.OperID == ioperation_0.OperID;
		}
	}

	[Serializable]
	private sealed class Class37
	{
		public static readonly Class37 class37_0 = new Class37();

		public static Func<CPolicyData, IEnumerable<CTriggerData>> func_0;

		public static Func<CTriggerData, int> func_1;

		internal IEnumerable<CTriggerData> method_0(CPolicyData cpolicyData_0)
		{
			return cpolicyData_0.Triggers;
		}

		internal int method_1(CTriggerData ctriggerData_0)
		{
			return ctriggerData_0.Version;
		}
	}

	private AIFile aifile_0;

	private IContainer icontainer_0;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private CheckBox checkBox_0;

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

	public AdditionalForm()
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		checkBox_0.Checked = MainForm.ConditionType == 1;
		string localizedString = MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937458));
		if (!string.IsNullOrEmpty(localizedString))
		{
			checkBox_0.Text = localizedString;
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		int num = Aipolicy.Controllers.SelectMany(Class37.class37_0.method_0).Max((Func<CTriggerData, int>)Class37.class37_0.method_1);
		foreach (CPolicyData controller in Aipolicy.Controllers)
		{
			foreach (CTriggerData trigger in controller.Triggers)
			{
				trigger.Version = num;
			}
		}
		DKBox.Show(string.Format(Class16.smethod_0(1648932366), MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648932381)), num), Class16.smethod_0(1648941399), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		int num = 0;
		List<CPolicyData> list = new List<CPolicyData>();
		foreach (CPolicyData controller in Aipolicy.Controllers)
		{
			if (controller.Triggers.Count == 0)
			{
				list.Add(controller);
				num++;
			}
		}
		foreach (CPolicyData item in list)
		{
			Aipolicy.Controllers.Remove(item);
		}
		DKBox.Show(string.Format(Class16.smethod_0(1648932366), MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648932409)), num), Class16.smethod_0(1648941399), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		MainForm.ConditionType = (checkBox_0.Checked ? 1 : 0);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		int num = 0;
		using (OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = Class16.smethod_0(1648932447)
		})
		{
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				AIFile aIFile = new AIFile
				{
					InAnotherThread = false
				};
				aIFile.Read(openFileDialog.FileName);
				Dictionary<int, CPolicyData> dictionary = new Dictionary<int, CPolicyData>();
				foreach (CPolicyData controller in aIFile.Controllers)
				{
					if (!dictionary.ContainsKey(controller.ID))
					{
						dictionary[controller.ID] = controller;
					}
				}
				HashSet<int> hashSet = new HashSet<int> { 2, 36, 53 };
				for (int i = 0; i < Aipolicy.Controllers.Count; i++)
				{
					CPolicyData cPolicyData = Aipolicy.Controllers[i];
					if (!dictionary.TryGetValue(cPolicyData.ID, out var value))
					{
						continue;
					}
					Dictionary<int, CTriggerData> dictionary2 = new Dictionary<int, CTriggerData>();
					foreach (CTriggerData trigger in value.Triggers)
					{
						if (!dictionary2.ContainsKey(trigger.ID))
						{
							dictionary2[trigger.ID] = trigger;
						}
					}
					for (int j = 0; j < cPolicyData.Triggers.Count; j++)
					{
						CTriggerData cTriggerData = cPolicyData.Triggers[j];
						if (!dictionary2.TryGetValue(cTriggerData.ID, out var value2))
						{
							continue;
						}
						for (int k = 0; k < cTriggerData.Operations.Count; k++)
						{
							Class36 @class = new Class36();
							@class.ioperation_0 = cTriggerData.Operations[k];
							if (!hashSet.Contains(@class.ioperation_0.OperID))
							{
								continue;
							}
							IOperation operation = ((value2.Operations.Count <= k || value2.Operations[k].OperID != @class.ioperation_0.OperID) ? value2.Operations.FirstOrDefault(@class.method_0) : value2.Operations[k]);
							if (operation != null)
							{
								if (operation is ICloneable cloneable)
								{
									operation = cloneable.Clone() as IOperation;
								}
								cTriggerData.Operations[k] = operation;
								num++;
							}
						}
					}
					Application.DoEvents();
				}
			}
			catch (Exception ex)
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648932475), Class16.smethod_0(1648932533)), ex.Message), Class16.smethod_0(1648941399), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}
		DKBox.Show(string.Format(Class16.smethod_0(1648932366), MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648932571)), num), Class16.smethod_0(1648941399), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
		new ComponentResourceManager(typeof(AdditionalForm));
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		SuspendLayout();
		button_0.Location = new Point(10, 10);
		button_0.Name = Class16.smethod_0(1648932614);
		button_0.Size = new Size(450, 23);
		button_0.TabIndex = 0;
		button_0.Text = Class16.smethod_0(1648932641);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Location = new Point(10, 42);
		button_1.Name = Class16.smethod_0(1648932672);
		button_1.Size = new Size(450, 23);
		button_1.TabIndex = 1;
		button_1.Text = Class16.smethod_0(1648932716);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Enabled = false;
		button_2.Location = new Point(10, 74);
		button_2.Name = Class16.smethod_0(1648932749);
		button_2.Size = new Size(450, 23);
		button_2.TabIndex = 2;
		button_2.Text = Class16.smethod_0(1648932780);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		checkBox_0 = new CheckBox();
		checkBox_0.Location = new Point(10, 106);
		checkBox_0.Name = Class16.smethod_0(1648932860);
		checkBox_0.Size = new Size(450, 23);
		checkBox_0.TabIndex = 3;
		checkBox_0.Text = Class16.smethod_0(1648931856);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(470, 180);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(button_2);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f);
		base.Icon = Resources.edit;
		base.Name = Class16.smethod_0(1648931918);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648931931);
		ResumeLayout(performLayout: false);
	}
}
