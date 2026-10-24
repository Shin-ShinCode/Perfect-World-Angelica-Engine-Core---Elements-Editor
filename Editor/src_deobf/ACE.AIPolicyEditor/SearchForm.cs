using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.AIPolicyEditor.AIPolicy;
using ACE.AIPolicyEditor.AIPolicy.Conditions;
using ACE.Classes;
using ACE.Properties;

namespace ACE.AIPolicyEditor;

public class SearchForm : Form
{
	private List<int[]> list_0 = new List<int[]>();

	private List<int[]> list_1 = new List<int[]>();

	private AIFile aifile_0;

	private List<IOperation> list_2 = new List<IOperation>();

	private readonly List<int> list_3 = new List<int>();

	private IContainer icontainer_0;

	private Label label_0;

	private TextBox textBox_0;

	private Button button_0;

	private ListBox listBox_0;

	private Label label_1;

	private ComboBox comboBox_0;

	private ComboBox comboBox_1;

	private Button button_1;

	private Button button_2;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private CheckBox checkBox_5;

	private Label label_2;

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

	public SearchForm()
	{
		method_5();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
	}

	private List<IOperation> method_0()
	{
		return list_2;
	}

	private void method_1(List<IOperation> list_4)
	{
		list_2 = list_4;
	}

	private List<int> method_2()
	{
		return list_3;
	}

	private static bool smethod_0(string string_0, string string_1, bool bool_0, StringComparison stringComparison_0)
	{
		if (!string.IsNullOrEmpty(string_0) && !string.IsNullOrEmpty(string_1))
		{
			if (!bool_0)
			{
				return string_0.IndexOf(string_1, stringComparison_0) >= 0;
			}
			return string.Equals(string_0, string_1, stringComparison_0);
		}
		return false;
	}

	private static bool smethod_1(CTriggerData ctriggerData_0, string string_0)
	{
		try
		{
			return Conditions.Search(ctriggerData_0.RootConditon, string_0);
		}
		catch
		{
			return false;
		}
	}

	private static bool smethod_2(IOperation ioperation_0, string string_0)
	{
		try
		{
			return ioperation_0.Search(string_0);
		}
		catch
		{
			return false;
		}
	}

	private static string smethod_3(int[] int_0)
	{
		return int_0.Length switch
		{
			1 => string.Format(Class16.smethod_0(1648932896), int_0[0]), 
			2 => string.Format(Class16.smethod_0(1648932925), int_0[0], int_0[1]), 
			3 => string.Format(Class16.smethod_0(1648932959), int_0[0], int_0[1], int_0[2]), 
			_ => string.Join(Class16.smethod_0(1648942920), int_0), 
		};
	}

	private void method_3(int[] int_0, int[] int_1)
	{
		list_0.Add(int_0);
		list_1.Add(int_1);
		listBox_0.Items.Add(smethod_3(int_0));
	}

	private void method_4()
	{
		label_2.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648933151), Class16.smethod_0(1648933175)), list_0.Count);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		listBox_0.BeginUpdate();
		try
		{
			list_0.Clear();
			list_1.Clear();
			listBox_0.Items.Clear();
			label_2.Text = TextStorage.Msg(Class16.smethod_0(1648933187));
			if (Aipolicy == null)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648933210)), Class16.smethod_0(1648931650), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string obj = textBox_0.Text;
			object obj2;
			if (obj == null)
			{
				obj2 = null;
			}
			else
			{
				obj2 = obj.Trim();
				if (obj2 != null)
				{
					goto IL_009c;
				}
			}
			obj2 = string.Empty;
			goto IL_009c;
			IL_009c:
			string text = (string)obj2;
			if (string.IsNullOrWhiteSpace(text))
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648933244)), Class16.smethod_0(1648931650), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			bool bool_ = checkBox_5.Checked;
			bool flag = checkBox_4.Checked;
			bool flag2 = checkBox_0.Checked;
			bool flag3 = checkBox_1.Checked;
			bool flag4 = checkBox_2.Checked;
			bool flag5 = checkBox_3.Checked;
			StringComparison stringComparison_ = (flag ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
			string string_ = (flag ? text : text.ToLowerInvariant());
			for (int i = 0; i < Aipolicy.Controllers.Count; i++)
			{
				CPolicyData cPolicyData = Aipolicy.Controllers[i];
				if (flag2 && smethod_0(cPolicyData.ID.ToString(), text, bool_, stringComparison_))
				{
					method_3(new int[1] { cPolicyData.ID }, new int[1] { i });
				}
				for (int j = 0; j < cPolicyData.Triggers.Count; j++)
				{
					CTriggerData cTriggerData = cPolicyData.Triggers[j];
					bool flag6 = false;
					if (flag2 && smethod_0(cTriggerData.ID.ToString(), text, bool_, stringComparison_))
					{
						flag6 = true;
					}
					if (flag3 && smethod_0(cTriggerData.Name, text, bool_, stringComparison_))
					{
						flag6 = true;
					}
					if (flag4 && smethod_1(cTriggerData, string_))
					{
						flag6 = true;
					}
					if (flag6)
					{
						method_3(new int[2] { cPolicyData.ID, cTriggerData.ID }, new int[2] { i, j });
					}
					if (!flag5)
					{
						continue;
					}
					for (int k = 0; k < cTriggerData.Operations.Count; k++)
					{
						IOperation operation = cTriggerData.Operations[k];
						if (operation != null && smethod_2(operation, string_))
						{
							method_3(new int[3] { cPolicyData.ID, cTriggerData.ID, k }, new int[3] { i, j, k });
						}
					}
				}
			}
			method_4();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648933277));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648933299), Class16.smethod_0(1648933336)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			listBox_0.EndUpdate();
		}
	}

	private void listBox_0_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		int selectedIndex = listBox_0.SelectedIndex;
		if (selectedIndex >= 0 && selectedIndex < list_0.Count && selectedIndex < list_1.Count)
		{
			int[] int_ = list_1[selectedIndex];
			if (!method_6(int_))
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648933369)), Class16.smethod_0(1648931650), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

	private void method_5()
	{
		new ComponentResourceManager(typeof(SearchForm));
		label_0 = new Label();
		textBox_0 = new TextBox();
		button_0 = new Button();
		button_2 = new Button();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		checkBox_3 = new CheckBox();
		checkBox_4 = new CheckBox();
		checkBox_5 = new CheckBox();
		listBox_0 = new ListBox();
		label_1 = new Label();
		comboBox_0 = new ComboBox();
		comboBox_1 = new ComboBox();
		button_1 = new Button();
		label_2 = new Label();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Location = new Point(12, 9);
		label_0.Name = Class16.smethod_0(1648933000);
		label_0.Size = new Size(67, 13);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1648928287);
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.Location = new Point(12, 28);
		textBox_0.Name = Class16.smethod_0(1648933054);
		textBox_0.Size = new Size(566, 22);
		textBox_0.TabIndex = 1;
		button_0.Location = new Point(12, 57);
		button_0.Name = Class16.smethod_0(1648933073);
		button_0.Size = new Size(275, 27);
		button_0.TabIndex = 2;
		button_0.Text = Class16.smethod_0(1648931650);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_2.Location = new Point(303, 57);
		button_2.Name = Class16.smethod_0(1648928297);
		button_2.Size = new Size(275, 27);
		button_2.TabIndex = 3;
		button_2.Text = Class16.smethod_0(1648928315);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		checkBox_0.AutoSize = true;
		checkBox_0.Checked = true;
		checkBox_0.CheckState = CheckState.Checked;
		checkBox_0.Location = new Point(12, 92);
		checkBox_0.Name = Class16.smethod_0(1648928335);
		checkBox_0.Size = new Size(83, 17);
		checkBox_0.TabIndex = 4;
		checkBox_0.Text = Class16.smethod_0(1648928359);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_1.AutoSize = true;
		checkBox_1.Checked = true;
		checkBox_1.CheckState = CheckState.Checked;
		checkBox_1.Location = new Point(160, 92);
		checkBox_1.Name = Class16.smethod_0(1648928369);
		checkBox_1.Size = new Size(100, 17);
		checkBox_1.TabIndex = 5;
		checkBox_1.Text = Class16.smethod_0(1648928395);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_2.AutoSize = true;
		checkBox_2.Checked = true;
		checkBox_2.CheckState = CheckState.Checked;
		checkBox_2.Location = new Point(320, 92);
		checkBox_2.Name = Class16.smethod_0(1648928423);
		checkBox_2.Size = new Size(122, 17);
		checkBox_2.TabIndex = 6;
		checkBox_2.Text = Class16.smethod_0(1648928454);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_3.AutoSize = true;
		checkBox_3.Checked = true;
		checkBox_3.CheckState = CheckState.Checked;
		checkBox_3.Location = new Point(12, 115);
		checkBox_3.Name = Class16.smethod_0(1648928479);
		checkBox_3.Size = new Size(123, 17);
		checkBox_3.TabIndex = 7;
		checkBox_3.Text = Class16.smethod_0(1648928510);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(160, 115);
		checkBox_4.Name = Class16.smethod_0(1648928535);
		checkBox_4.Size = new Size(97, 17);
		checkBox_4.TabIndex = 8;
		checkBox_4.Text = Class16.smethod_0(1648928555);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_5.AutoSize = true;
		checkBox_5.Location = new Point(320, 115);
		checkBox_5.Name = Class16.smethod_0(1648928576);
		checkBox_5.Size = new Size(86, 17);
		checkBox_5.TabIndex = 9;
		checkBox_5.Text = Class16.smethod_0(1648928601);
		checkBox_5.UseVisualStyleBackColor = true;
		listBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listBox_0.BackColor = SystemColors.ControlText;
		listBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		listBox_0.ForeColor = Color.White;
		listBox_0.FormattingEnabled = true;
		listBox_0.ItemHeight = 15;
		listBox_0.Location = new Point(12, 150);
		listBox_0.Name = Class16.smethod_0(1648933100);
		listBox_0.Size = new Size(566, 289);
		listBox_0.TabIndex = 10;
		listBox_0.MouseDoubleClick += listBox_0_MouseDoubleClick;
		label_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_1.AutoSize = true;
		label_1.Location = new Point(12, 463);
		label_1.Name = Class16.smethod_0(1648928619);
		label_1.Size = new Size(81, 13);
		label_1.TabIndex = 11;
		label_1.Text = Class16.smethod_0(1648928642);
		comboBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1648928671),
			Class16.smethod_0(1648928687)
		});
		comboBox_0.Location = new Point(120, 461);
		comboBox_0.Name = Class16.smethod_0(1648928703);
		comboBox_0.Size = new Size(120, 21);
		comboBox_0.TabIndex = 12;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		comboBox_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Location = new Point(250, 461);
		comboBox_1.Name = Class16.smethod_0(1648928720);
		comboBox_1.Size = new Size(220, 21);
		comboBox_1.TabIndex = 13;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_1.Location = new Point(480, 460);
		button_1.Name = Class16.smethod_0(1648928748);
		button_1.Size = new Size(98, 23);
		button_1.TabIndex = 14;
		button_1.Text = Class16.smethod_0(1648928642);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		label_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_2.AutoSize = true;
		label_2.Location = new Point(12, 435);
		label_2.Name = Class16.smethod_0(1648928763);
		label_2.Size = new Size(50, 13);
		label_2.TabIndex = 15;
		label_2.Text = Class16.smethod_0(1648927763);
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(600, 520);
		base.Controls.Add(label_2);
		base.Controls.Add(button_1);
		base.Controls.Add(comboBox_1);
		base.Controls.Add(comboBox_0);
		base.Controls.Add(label_1);
		base.Controls.Add(listBox_0);
		base.Controls.Add(checkBox_5);
		base.Controls.Add(checkBox_4);
		base.Controls.Add(checkBox_3);
		base.Controls.Add(checkBox_2);
		base.Controls.Add(checkBox_1);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(button_2);
		base.Controls.Add(button_0);
		base.Controls.Add(textBox_0);
		base.Controls.Add(label_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f);
		base.Icon = Resources.edit;
		base.Name = Class16.smethod_0(1648927779);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648931650);
		base.Load += SearchForm_Load;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		listBox_0.BeginUpdate();
		try
		{
			list_0.Clear();
			list_1.Clear();
			listBox_0.Items.Clear();
			label_2.Text = TextStorage.Msg(Class16.smethod_0(1648933187));
			if (Aipolicy == null)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648933210)), Class16.smethod_0(1648931650), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (comboBox_0.SelectedIndex < 0)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648927804)), Class16.smethod_0(1648931650), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (comboBox_1.SelectedIndex < 0)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648927838)), Class16.smethod_0(1648931650), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (comboBox_0.SelectedIndex == 0)
			{
				if (comboBox_1.SelectedIndex >= method_2().Count)
				{
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648927838)), Class16.smethod_0(1648931650), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				int id = method_2()[comboBox_1.SelectedIndex];
				foreach (CPolicyData controller in Aipolicy.Controllers)
				{
					foreach (CTriggerData trigger in controller.Triggers)
					{
						if (Conditions.Search(trigger.RootConditon, id))
						{
							method_3(new int[2] { controller.ID, trigger.ID }, new int[2]
							{
								Aipolicy.Controllers.IndexOf(controller),
								controller.Triggers.IndexOf(trigger)
							});
						}
					}
				}
			}
			else if (comboBox_0.SelectedIndex == 1)
			{
				if (comboBox_1.SelectedIndex >= method_0().Count)
				{
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648927864)), Class16.smethod_0(1648931650), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				foreach (CPolicyData controller2 in Aipolicy.Controllers)
				{
					foreach (CTriggerData trigger2 in controller2.Triggers)
					{
						for (int i = 0; i < trigger2.Operations.Count; i++)
						{
							IOperation operation = trigger2.Operations[i];
							if (operation != null && operation.OperID == method_0()[comboBox_1.SelectedIndex].OperID)
							{
								method_3(new int[3] { controller2.ID, trigger2.ID, i }, new int[3]
								{
									Aipolicy.Controllers.IndexOf(controller2),
									controller2.Triggers.IndexOf(trigger2),
									i
								});
							}
						}
					}
				}
			}
			method_4();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648927909));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648927942), Class16.smethod_0(1648927979)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			listBox_0.EndUpdate();
		}
	}

	private bool method_6(int[] int_0)
	{
		if (Aipolicy != null && int_0 != null && int_0.Length != 0)
		{
			int num = ((int_0.Length != 0) ? int_0[0] : (-1));
			if (num >= 0 && num < Aipolicy.Controllers.Count)
			{
				Aipolicy.ControllerIndex = num;
				if (int_0.Length > 1)
				{
					int num2 = int_0[1];
					CPolicyData cPolicyData = Aipolicy.Controllers[num];
					if (cPolicyData == null || num2 < 0 || num2 >= cPolicyData.Triggers.Count)
					{
						return false;
					}
					ObservableCollection<CTriggerData> currentTriggers = Aipolicy.CurrentTriggers;
					if (currentTriggers == null || num2 >= currentTriggers.Count)
					{
						return false;
					}
					Aipolicy.TriggerIndex = num2;
					if (int_0.Length > 2)
					{
						int num3 = int_0[2];
						CTriggerData cTriggerData = cPolicyData.Triggers[num2];
						if (cTriggerData == null || num3 < 0 || num3 >= cTriggerData.Operations.Count)
						{
							return false;
						}
						ObservableCollection<IOperation> currentOperations = Aipolicy.CurrentOperations;
						if (currentOperations == null || num3 >= currentOperations.Count)
						{
							return false;
						}
						Aipolicy.OperationIndex = num3;
					}
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		textBox_0.Clear();
		listBox_0.Items.Clear();
		list_0.Clear();
		list_1.Clear();
		method_4();
		textBox_0.Focus();
	}

	private void SearchForm_Load(object sender, EventArgs e)
	{
		checkBox_0.Checked = true;
		checkBox_1.Checked = true;
		checkBox_2.Checked = true;
		checkBox_3.Checked = true;
		comboBox_0.SelectedIndex = 0;
		method_4();
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		comboBox_1.Items.Clear();
		if (comboBox_0.SelectedIndex == 0)
		{
			method_2().Clear();
			method_2().AddRange(Conditions.GetConditionIds());
			foreach (int item in method_2())
			{
				comboBox_1.Items.Add(Conditions.GetName(item));
			}
		}
		else if (comboBox_0.SelectedIndex == 1)
		{
			method_2().Clear();
			method_0().Clear();
			foreach (int knownOperationId in Operation.GetKnownOperationIds())
			{
				IOperation operation = Operation.Read(null, CTriggerData.MaxVersion, knownOperationId);
				if (operation != null && operation.FromVersion <= CTriggerData.MaxVersion)
				{
					method_0().Add(operation);
				}
			}
			foreach (IOperation item2 in method_0())
			{
				comboBox_1.Items.Add(string.Format(Class16.smethod_0(1648942645), item2.Name, MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648942674)), item2.FromVersion));
			}
		}
		if (comboBox_1.Items.Count > 0)
		{
			comboBox_1.SelectedIndex = 0;
		}
		else
		{
			comboBox_1.SelectedIndex = -1;
		}
	}
}
