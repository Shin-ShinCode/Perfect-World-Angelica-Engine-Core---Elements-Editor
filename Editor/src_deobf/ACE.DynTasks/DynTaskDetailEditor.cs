using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.DynTasks;

public class DynTaskDetailEditor : Form
{
	private DYN_TASKS.DynTaskTmpl dynTaskTmpl_0;

	private CommonStorage commonStorage_0;

	public bool DontChange;

	private IContainer icontainer_0;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private Label label_0;

	private TextBox textBox_0;

	private Label label_1;

	private TextBox textBox_1;

	private Label label_2;

	private NumericUpDown numericUpDown_0;

	private Label label_3;

	private NumericUpDown numericUpDown_1;

	private Label label_4;

	private NumericUpDown numericUpDown_2;

	private Label label_5;

	private NumericUpDown numericUpDown_3;

	private Label label_6;

	private NumericUpDown numericUpDown_4;

	private Label label_7;

	private NumericUpDown numericUpDown_5;

	private TabPage tabPage_1;

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

	private TabPage tabPage_2;

	private Label label_8;

	private ComboBox comboBox_0;

	private Label label_9;

	private NumericUpDown numericUpDown_6;

	private Label label_10;

	private NumericUpDown numericUpDown_7;

	private Label label_11;

	private NumericUpDown numericUpDown_8;

	private Label label_12;

	private NumericUpDown numericUpDown_9;

	private Label label_13;

	private NumericUpDown numericUpDown_10;

	private Label label_14;

	private NumericUpDown numericUpDown_11;

	private Label label_15;

	private NumericUpDown numericUpDown_12;

	private TabPage tabPage_3;

	private ListBox listBox_0;

	private Button button_0;

	private Button button_1;

	private PropertyGrid propertyGrid_0;

	private TabPage tabPage_4;

	private ListBox listBox_1;

	private Button button_2;

	private Button button_3;

	private PropertyGrid propertyGrid_1;

	private TabPage tabPage_5;

	private ListBox listBox_2;

	private Button button_4;

	private Button button_5;

	private PropertyGrid propertyGrid_2;

	private Label label_16;

	private NumericUpDown numericUpDown_13;

	private Label label_17;

	private NumericUpDown numericUpDown_14;

	private Label label_18;

	private NumericUpDown numericUpDown_15;

	private Label label_19;

	private NumericUpDown numericUpDown_16;

	private Label label_20;

	private NumericUpDown numericUpDown_17;

	private TabPage tabPage_6;

	private ListBox listBox_3;

	private Button button_6;

	private Button button_7;

	private PropertyGrid propertyGrid_3;

	private TabPage tabPage_7;

	private Label label_21;

	private TextBox textBox_2;

	private Label label_22;

	private TextBox textBox_3;

	private Label label_23;

	private TextBox textBox_4;

	private TabPage tabPage_8;

	private PropertyGrid propertyGrid_4;

	private TabPage tabPage_9;

	private Label label_24;

	private PropertyGrid propertyGrid_5;

	private Label label_25;

	private PropertyGrid propertyGrid_6;

	private Button button_8;

	private Button button_9;

	public DYN_TASKS.DynTaskTmpl Task
	{
		[CompilerGenerated]
		get
		{
			return dynTaskTmpl_0;
		}
	}

	public CommonStorage CStorage
	{
		[CompilerGenerated]
		get
		{
			return commonStorage_0;
		}
	}

	public DynTaskDetailEditor(DYN_TASKS.DynTaskTmpl task, CommonStorage cStorage)
	{
		method_8();
		TDark.StoreOriginalColors(this);
		TDark.ApplyThemeToForm(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		object obj;
		if (task == null)
		{
			obj = null;
		}
		else
		{
			obj = task.Clone();
			if (obj != null)
			{
				goto IL_0039;
			}
		}
		obj = new DYN_TASKS.DynTaskTmpl();
		goto IL_0039;
		IL_0039:
		method_0((DYN_TASKS.DynTaskTmpl)obj);
		method_1(cStorage);
		method_2();
	}

	private void method_0(DYN_TASKS.DynTaskTmpl dynTaskTmpl_1)
	{
		dynTaskTmpl_0 = dynTaskTmpl_1;
	}

	private void method_1(CommonStorage commonStorage_1)
	{
		commonStorage_0 = commonStorage_1;
	}

	private void method_2()
	{
		DontChange = true;
		textBox_0.Text = Task.ID.ToString();
		textBox_1.Text = Task.Name ?? string.Empty;
		numericUpDown_0.Value = Task.DynTaskType;
		numericUpDown_1.Value = Task.SpecialAward;
		numericUpDown_2.Value = Task.TokenMask1;
		numericUpDown_3.Value = Task.TokenMask2;
		numericUpDown_4.Value = Task.Premise_Lev_Min;
		numericUpDown_5.Value = Task.Premise_Lev_Max;
		checkBox_0.Checked = Task.ChooseOne != 0;
		checkBox_1.Checked = Task.RandOne != 0;
		checkBox_2.Checked = Task.ExeChildInOrder != 0;
		checkBox_3.Checked = Task.ParentAlsoFail != 0;
		checkBox_4.Checked = Task.ParentAlsoSucc != 0;
		checkBox_5.Checked = Task.CanGiveUp != 0;
		checkBox_6.Checked = Task.CanRedo != 0;
		checkBox_7.Checked = Task.CanRedoAfterFailure != 0;
		checkBox_8.Checked = Task.ClearAsGiveUp != 0;
		checkBox_9.Checked = Task.NeedRecord != 0;
		checkBox_10.Checked = Task.FailAsPlayerDie != 0;
		checkBox_11.Checked = Task.AutoDeliver != 0;
		checkBox_12.Checked = Task.DeathTrig != 0;
		checkBox_13.Checked = Task.ClearAcquired != 0;
		checkBox_14.Checked = Task.Premise_Spouse != 0;
		checkBox_15.Checked = Task.Teamwork != 0;
		checkBox_16.Checked = Task.ShowDirection != 0;
		comboBox_0.SelectedIndex = ((Task.EnumMethod < comboBox_0.Items.Count) ? Task.EnumMethod : 0);
		numericUpDown_6.Value = Task.EnumFinishType;
		textBox_2.Text = Task.Description ?? string.Empty;
		textBox_3.Text = Task.OkText ?? string.Empty;
		textBox_4.Text = Task.NoText ?? string.Empty;
		numericUpDown_13.Value = Task.TimeLimit;
		numericUpDown_14.Value = Task.Premise_Reputation;
		numericUpDown_15.Value = Task.Premise_Period;
		numericUpDown_16.Value = Task.Premise_Deposit;
		numericUpDown_17.Value = Task.Gender;
		numericUpDown_7.Value = Task.GoldWanted;
		numericUpDown_8.Value = Task.FactionContribWanted;
		numericUpDown_9.Value = Task.FactionExpContribWanted;
		numericUpDown_10.Value = Task.WaitTime;
		numericUpDown_11.Value = Task.ReachSiteId;
		numericUpDown_12.Value = Task.LeaveSiteId;
		propertyGrid_4.SelectedObject = Task.Award_S;
		propertyGrid_5.SelectedObject = Task.DelvTaskTalk;
		propertyGrid_6.SelectedObject = Task.AwardTalk;
		method_3();
		method_4();
		method_5();
		method_6();
		DontChange = false;
	}

	private void method_3()
	{
		listBox_0.Items.Clear();
		foreach (DYN_TASKS.MonsterWanted item in Task.MonsterWanted)
		{
			listBox_0.Items.Add(string.Format(Class16.smethod_0(1649001993), item.MonsterTemplId, item.MonsterNum));
		}
	}

	private void method_4()
	{
		listBox_1.Items.Clear();
		foreach (DYN_TASKS.ItemWanted item in Task.ItemsWanted)
		{
			listBox_1.Items.Add(string.Format(Class16.smethod_0(1649002016), item.ItemTemplId, item.ItemNum));
		}
	}

	private void method_5()
	{
		listBox_2.Items.Clear();
		foreach (DYN_TASKS.ItemWanted premItem in Task.PremItems)
		{
			listBox_2.Items.Add(string.Format(Class16.smethod_0(1649002016), premItem.ItemTemplId, premItem.ItemNum));
		}
	}

	private void method_6()
	{
		listBox_3.Items.Clear();
		foreach (DYN_TASKS.ItemWanted givenItem in Task.GivenItems)
		{
			listBox_3.Items.Add(string.Format(Class16.smethod_0(1649002016), givenItem.ItemTemplId, givenItem.ItemNum));
		}
	}

	private void method_7()
	{
		if (uint.TryParse(textBox_0.Text, out var result))
		{
			Task.ID = result;
		}
		Task.Name = textBox_1.Text;
		Task.DynTaskType = (byte)numericUpDown_0.Value;
		Task.SpecialAward = (int)numericUpDown_1.Value;
		Task.TokenMask1 = (int)numericUpDown_2.Value;
		Task.TokenMask2 = (int)numericUpDown_3.Value;
		Task.Premise_Lev_Min = (byte)numericUpDown_4.Value;
		Task.Premise_Lev_Max = (byte)numericUpDown_5.Value;
		Task.ChooseOne = (checkBox_0.Checked ? ((byte)1) : ((byte)0));
		Task.RandOne = (checkBox_1.Checked ? ((byte)1) : ((byte)0));
		Task.ExeChildInOrder = (checkBox_2.Checked ? ((byte)1) : ((byte)0));
		Task.ParentAlsoFail = (checkBox_3.Checked ? ((byte)1) : ((byte)0));
		Task.ParentAlsoSucc = (checkBox_4.Checked ? ((byte)1) : ((byte)0));
		Task.CanGiveUp = (checkBox_5.Checked ? ((byte)1) : ((byte)0));
		Task.CanRedo = (checkBox_6.Checked ? ((byte)1) : ((byte)0));
		Task.CanRedoAfterFailure = (checkBox_7.Checked ? ((byte)1) : ((byte)0));
		Task.ClearAsGiveUp = (checkBox_8.Checked ? ((byte)1) : ((byte)0));
		Task.NeedRecord = (checkBox_9.Checked ? ((byte)1) : ((byte)0));
		Task.FailAsPlayerDie = (checkBox_10.Checked ? ((byte)1) : ((byte)0));
		Task.AutoDeliver = (checkBox_11.Checked ? ((byte)1) : ((byte)0));
		Task.DeathTrig = (checkBox_12.Checked ? ((byte)1) : ((byte)0));
		Task.ClearAcquired = (checkBox_13.Checked ? ((byte)1) : ((byte)0));
		Task.Premise_Spouse = (checkBox_14.Checked ? ((byte)1) : ((byte)0));
		Task.Teamwork = (checkBox_15.Checked ? ((byte)1) : ((byte)0));
		Task.ShowDirection = (checkBox_16.Checked ? ((byte)1) : ((byte)0));
		Task.EnumMethod = (byte)comboBox_0.SelectedIndex;
		Task.EnumFinishType = (byte)numericUpDown_6.Value;
		Task.Description = textBox_2.Text;
		Task.OkText = textBox_3.Text;
		Task.NoText = textBox_4.Text;
		Task.TimeLimit = (uint)numericUpDown_13.Value;
		Task.Premise_Reputation = (int)numericUpDown_14.Value;
		Task.Premise_Period = (uint)numericUpDown_15.Value;
		Task.Premise_Deposit = (uint)numericUpDown_16.Value;
		Task.Gender = (uint)numericUpDown_17.Value;
		Task.GoldWanted = (uint)numericUpDown_7.Value;
		Task.FactionContribWanted = (int)numericUpDown_8.Value;
		Task.FactionExpContribWanted = (int)numericUpDown_9.Value;
		Task.WaitTime = (uint)numericUpDown_10.Value;
		Task.ReachSiteId = (uint)numericUpDown_11.Value;
		Task.LeaveSiteId = (uint)numericUpDown_12.Value;
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		method_7();
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		DYN_TASKS.MonsterWanted item = new DYN_TASKS.MonsterWanted
		{
			MonsterTemplId = 1u,
			MonsterNum = 1u
		};
		Task.MonsterWanted.Add(item);
		method_3();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (listBox_0.SelectedIndex >= 0 && listBox_0.SelectedIndex < Task.MonsterWanted.Count)
		{
			Task.MonsterWanted.RemoveAt(listBox_0.SelectedIndex);
			propertyGrid_0.SelectedObject = null;
			method_3();
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		DYN_TASKS.ItemWanted item = new DYN_TASKS.ItemWanted
		{
			ItemTemplId = 1,
			ItemNum = 1
		};
		Task.ItemsWanted.Add(item);
		method_4();
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (listBox_1.SelectedIndex >= 0 && listBox_1.SelectedIndex < Task.ItemsWanted.Count)
		{
			Task.ItemsWanted.RemoveAt(listBox_1.SelectedIndex);
			propertyGrid_1.SelectedObject = null;
			method_4();
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

	private void method_8()
	{
		tabControl_0 = new TabControl();
		tabPage_0 = new TabPage();
		label_0 = new Label();
		textBox_0 = new TextBox();
		label_1 = new Label();
		textBox_1 = new TextBox();
		label_2 = new Label();
		numericUpDown_0 = new NumericUpDown();
		label_3 = new Label();
		numericUpDown_1 = new NumericUpDown();
		label_4 = new Label();
		numericUpDown_2 = new NumericUpDown();
		label_5 = new Label();
		numericUpDown_3 = new NumericUpDown();
		label_6 = new Label();
		numericUpDown_4 = new NumericUpDown();
		label_7 = new Label();
		numericUpDown_5 = new NumericUpDown();
		tabPage_1 = new TabPage();
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
		tabPage_2 = new TabPage();
		label_8 = new Label();
		comboBox_0 = new ComboBox();
		label_9 = new Label();
		numericUpDown_6 = new NumericUpDown();
		label_10 = new Label();
		numericUpDown_7 = new NumericUpDown();
		label_11 = new Label();
		numericUpDown_8 = new NumericUpDown();
		label_12 = new Label();
		numericUpDown_9 = new NumericUpDown();
		label_13 = new Label();
		numericUpDown_10 = new NumericUpDown();
		label_14 = new Label();
		numericUpDown_11 = new NumericUpDown();
		label_15 = new Label();
		numericUpDown_12 = new NumericUpDown();
		tabPage_3 = new TabPage();
		listBox_0 = new ListBox();
		button_0 = new Button();
		button_1 = new Button();
		propertyGrid_0 = new PropertyGrid();
		tabPage_4 = new TabPage();
		listBox_1 = new ListBox();
		button_2 = new Button();
		button_3 = new Button();
		propertyGrid_1 = new PropertyGrid();
		tabPage_5 = new TabPage();
		listBox_2 = new ListBox();
		button_4 = new Button();
		button_5 = new Button();
		propertyGrid_2 = new PropertyGrid();
		label_16 = new Label();
		numericUpDown_13 = new NumericUpDown();
		label_17 = new Label();
		numericUpDown_14 = new NumericUpDown();
		label_18 = new Label();
		numericUpDown_15 = new NumericUpDown();
		label_19 = new Label();
		numericUpDown_16 = new NumericUpDown();
		label_20 = new Label();
		numericUpDown_17 = new NumericUpDown();
		tabPage_6 = new TabPage();
		listBox_3 = new ListBox();
		button_6 = new Button();
		button_7 = new Button();
		propertyGrid_3 = new PropertyGrid();
		tabPage_7 = new TabPage();
		label_21 = new Label();
		textBox_2 = new TextBox();
		label_22 = new Label();
		textBox_3 = new TextBox();
		label_23 = new Label();
		textBox_4 = new TextBox();
		tabPage_8 = new TabPage();
		propertyGrid_4 = new PropertyGrid();
		tabPage_9 = new TabPage();
		label_24 = new Label();
		propertyGrid_5 = new PropertyGrid();
		label_25 = new Label();
		propertyGrid_6 = new PropertyGrid();
		button_8 = new Button();
		button_9 = new Button();
		tabControl_0.SuspendLayout();
		tabPage_0.SuspendLayout();
		tabPage_1.SuspendLayout();
		tabPage_2.SuspendLayout();
		tabPage_3.SuspendLayout();
		tabPage_4.SuspendLayout();
		tabPage_5.SuspendLayout();
		tabPage_6.SuspendLayout();
		tabPage_7.SuspendLayout();
		tabPage_8.SuspendLayout();
		tabPage_9.SuspendLayout();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		((ISupportInitialize)numericUpDown_3).BeginInit();
		((ISupportInitialize)numericUpDown_4).BeginInit();
		((ISupportInitialize)numericUpDown_5).BeginInit();
		((ISupportInitialize)numericUpDown_6).BeginInit();
		((ISupportInitialize)numericUpDown_7).BeginInit();
		((ISupportInitialize)numericUpDown_8).BeginInit();
		((ISupportInitialize)numericUpDown_9).BeginInit();
		((ISupportInitialize)numericUpDown_10).BeginInit();
		((ISupportInitialize)numericUpDown_11).BeginInit();
		((ISupportInitialize)numericUpDown_12).BeginInit();
		((ISupportInitialize)numericUpDown_13).BeginInit();
		((ISupportInitialize)numericUpDown_14).BeginInit();
		((ISupportInitialize)numericUpDown_15).BeginInit();
		((ISupportInitialize)numericUpDown_16).BeginInit();
		((ISupportInitialize)numericUpDown_17).BeginInit();
		SuspendLayout();
		tabControl_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tabControl_0.Controls.Add(tabPage_0);
		tabControl_0.Controls.Add(tabPage_1);
		tabControl_0.Controls.Add(tabPage_2);
		tabControl_0.Controls.Add(tabPage_3);
		tabControl_0.Controls.Add(tabPage_4);
		tabControl_0.Controls.Add(tabPage_5);
		tabControl_0.Controls.Add(tabPage_6);
		tabControl_0.Controls.Add(tabPage_7);
		tabControl_0.Controls.Add(tabPage_8);
		tabControl_0.Controls.Add(tabPage_9);
		tabControl_0.Location = new Point(12, 12);
		tabControl_0.Name = Class16.smethod_0(1648910731);
		tabControl_0.SelectedIndex = 0;
		tabControl_0.Size = new Size(760, 480);
		tabControl_0.TabIndex = 0;
		tabPage_0.Controls.Add(label_0);
		tabPage_0.Controls.Add(textBox_0);
		tabPage_0.Controls.Add(label_1);
		tabPage_0.Controls.Add(textBox_1);
		tabPage_0.Controls.Add(label_2);
		tabPage_0.Controls.Add(numericUpDown_0);
		tabPage_0.Controls.Add(label_3);
		tabPage_0.Controls.Add(numericUpDown_1);
		tabPage_0.Controls.Add(label_4);
		tabPage_0.Controls.Add(numericUpDown_2);
		tabPage_0.Controls.Add(label_5);
		tabPage_0.Controls.Add(numericUpDown_3);
		tabPage_0.Controls.Add(label_6);
		tabPage_0.Controls.Add(numericUpDown_4);
		tabPage_0.Controls.Add(label_7);
		tabPage_0.Controls.Add(numericUpDown_5);
		tabPage_0.Location = new Point(4, 24);
		tabPage_0.Name = Class16.smethod_0(1649002044);
		tabPage_0.Padding = new Padding(3);
		tabPage_0.Size = new Size(752, 452);
		tabPage_0.TabIndex = 0;
		tabPage_0.Text = Class16.smethod_0(1649002051);
		tabPage_0.UseVisualStyleBackColor = true;
		label_0.AutoSize = true;
		label_0.Location = new Point(20, 20);
		label_0.Name = Class16.smethod_0(1649002071);
		label_0.Size = new Size(21, 15);
		label_0.Text = Class16.smethod_0(1648930840);
		textBox_0.Location = new Point(120, 17);
		textBox_0.Name = Class16.smethod_0(1649002075);
		textBox_0.Size = new Size(150, 23);
		label_1.AutoSize = true;
		label_1.Location = new Point(20, 50);
		label_1.Name = Class16.smethod_0(1649002095);
		label_1.Size = new Size(42, 15);
		label_1.Text = Class16.smethod_0(1648930944);
		textBox_1.Location = new Point(120, 47);
		textBox_1.Name = Class16.smethod_0(1649002109);
		textBox_1.Size = new Size(400, 23);
		label_2.AutoSize = true;
		label_2.Location = new Point(20, 80);
		label_2.Name = Class16.smethod_0(1649002115);
		label_2.Size = new Size(63, 15);
		label_2.Text = Class16.smethod_0(1649002141);
		numericUpDown_0.Location = new Point(120, 77);
		numericUpDown_0.Maximum = 255m;
		numericUpDown_0.Name = Class16.smethod_0(1649002158);
		numericUpDown_0.Size = new Size(100, 23);
		label_3.AutoSize = true;
		label_3.Location = new Point(20, 110);
		label_3.Name = Class16.smethod_0(1649002168);
		label_3.Size = new Size(82, 15);
		label_3.Text = Class16.smethod_0(1649002198);
		numericUpDown_1.Location = new Point(120, 107);
		numericUpDown_1.Maximum = 2147483647m;
		numericUpDown_1.Minimum = -2147483648m;
		numericUpDown_1.Name = Class16.smethod_0(1649002211);
		numericUpDown_1.Size = new Size(150, 23);
		label_4.AutoSize = true;
		label_4.Location = new Point(20, 140);
		label_4.Name = Class16.smethod_0(1649002233);
		label_4.Size = new Size(80, 15);
		label_4.Text = Class16.smethod_0(1649002261);
		numericUpDown_2.Location = new Point(120, 137);
		numericUpDown_2.Maximum = 2147483647m;
		numericUpDown_2.Minimum = -2147483648m;
		numericUpDown_2.Name = Class16.smethod_0(1649002273);
		numericUpDown_2.Size = new Size(150, 23);
		label_5.AutoSize = true;
		label_5.Location = new Point(20, 170);
		label_5.Name = Class16.smethod_0(1649002301);
		label_5.Size = new Size(80, 15);
		label_5.Text = Class16.smethod_0(1649002313);
		numericUpDown_3.Location = new Point(120, 167);
		numericUpDown_3.Maximum = 2147483647m;
		numericUpDown_3.Minimum = -2147483648m;
		numericUpDown_3.Name = Class16.smethod_0(1649002341);
		numericUpDown_3.Size = new Size(150, 23);
		label_6.AutoSize = true;
		label_6.Location = new Point(20, 200);
		label_6.Name = Class16.smethod_0(1649002353);
		label_6.Size = new Size(62, 15);
		label_6.Text = Class16.smethod_0(1649002371);
		numericUpDown_4.Location = new Point(120, 197);
		numericUpDown_4.Maximum = 255m;
		numericUpDown_4.Name = Class16.smethod_0(1649002396);
		numericUpDown_4.Size = new Size(100, 23);
		label_7.AutoSize = true;
		label_7.Location = new Point(20, 230);
		label_7.Name = Class16.smethod_0(1649002414);
		label_7.Size = new Size(65, 15);
		label_7.Text = Class16.smethod_0(1649002424);
		numericUpDown_5.Location = new Point(120, 227);
		numericUpDown_5.Maximum = 255m;
		numericUpDown_5.Name = Class16.smethod_0(1649002441);
		numericUpDown_5.Size = new Size(100, 23);
		tabPage_1.Controls.Add(checkBox_0);
		tabPage_1.Controls.Add(checkBox_1);
		tabPage_1.Controls.Add(checkBox_2);
		tabPage_1.Controls.Add(checkBox_3);
		tabPage_1.Controls.Add(checkBox_4);
		tabPage_1.Controls.Add(checkBox_5);
		tabPage_1.Controls.Add(checkBox_6);
		tabPage_1.Controls.Add(checkBox_7);
		tabPage_1.Controls.Add(checkBox_8);
		tabPage_1.Controls.Add(checkBox_9);
		tabPage_1.Controls.Add(checkBox_10);
		tabPage_1.Controls.Add(checkBox_11);
		tabPage_1.Controls.Add(checkBox_12);
		tabPage_1.Controls.Add(checkBox_13);
		tabPage_1.Controls.Add(checkBox_14);
		tabPage_1.Controls.Add(checkBox_15);
		tabPage_1.Controls.Add(checkBox_16);
		tabPage_1.Location = new Point(4, 24);
		tabPage_1.Name = Class16.smethod_0(1649002459);
		tabPage_1.Padding = new Padding(3);
		tabPage_1.Size = new Size(752, 452);
		tabPage_1.TabIndex = 1;
		tabPage_1.Text = Class16.smethod_0(1649002474);
		tabPage_1.UseVisualStyleBackColor = true;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(20, 20);
		checkBox_0.Name = Class16.smethod_0(1649002494);
		checkBox_0.Text = Class16.smethod_0(1649001481);
		checkBox_1.AutoSize = true;
		checkBox_1.Location = new Point(20, 50);
		checkBox_1.Name = Class16.smethod_0(1649001498);
		checkBox_1.Text = Class16.smethod_0(1649001515);
		checkBox_2.AutoSize = true;
		checkBox_2.Location = new Point(20, 80);
		checkBox_2.Name = Class16.smethod_0(1649001540);
		checkBox_2.Text = Class16.smethod_0(1649001565);
		checkBox_3.AutoSize = true;
		checkBox_3.Location = new Point(20, 110);
		checkBox_3.Name = Class16.smethod_0(1649001586);
		checkBox_3.Text = Class16.smethod_0(1649001610);
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(20, 140);
		checkBox_4.Name = Class16.smethod_0(1649001633);
		checkBox_4.Text = Class16.smethod_0(1649001657);
		checkBox_5.AutoSize = true;
		checkBox_5.Location = new Point(20, 170);
		checkBox_5.Name = Class16.smethod_0(1649001683);
		checkBox_5.Text = Class16.smethod_0(1649001710);
		checkBox_6.AutoSize = true;
		checkBox_6.Location = new Point(200, 20);
		checkBox_6.Name = Class16.smethod_0(1649001720);
		checkBox_6.Text = Class16.smethod_0(1649001737);
		checkBox_7.AutoSize = true;
		checkBox_7.Location = new Point(200, 50);
		checkBox_7.Name = Class16.smethod_0(1649001752);
		checkBox_7.Text = Class16.smethod_0(1649001789);
		checkBox_8.AutoSize = true;
		checkBox_8.Location = new Point(200, 80);
		checkBox_8.Name = Class16.smethod_0(1649001810);
		checkBox_8.Text = Class16.smethod_0(1649001833);
		checkBox_9.AutoSize = true;
		checkBox_9.Location = new Point(200, 110);
		checkBox_9.Name = Class16.smethod_0(1649001856);
		checkBox_9.Text = Class16.smethod_0(1649001884);
		checkBox_10.AutoSize = true;
		checkBox_10.Location = new Point(200, 140);
		checkBox_10.Name = Class16.smethod_0(1649001902);
		checkBox_10.Text = Class16.smethod_0(1649001927);
		checkBox_11.AutoSize = true;
		checkBox_11.Location = new Point(200, 170);
		checkBox_11.Name = Class16.smethod_0(1649001944);
		checkBox_11.Text = Class16.smethod_0(1649001973);
		checkBox_12.AutoSize = true;
		checkBox_12.Location = new Point(380, 20);
		checkBox_12.Name = Class16.smethod_0(1649000960);
		checkBox_12.Text = Class16.smethod_0(1649000979);
		checkBox_13.AutoSize = true;
		checkBox_13.Location = new Point(380, 50);
		checkBox_13.Name = Class16.smethod_0(1649001007);
		checkBox_13.Text = Class16.smethod_0(1649001030);
		checkBox_14.AutoSize = true;
		checkBox_14.Location = new Point(380, 80);
		checkBox_14.Name = Class16.smethod_0(1649001043);
		checkBox_14.Text = Class16.smethod_0(1649001067);
		checkBox_15.AutoSize = true;
		checkBox_15.Location = new Point(380, 110);
		checkBox_15.Name = Class16.smethod_0(1649001088);
		checkBox_15.Text = Class16.smethod_0(1649001106);
		checkBox_16.AutoSize = true;
		checkBox_16.Location = new Point(380, 140);
		checkBox_16.Name = Class16.smethod_0(1649001121);
		checkBox_16.Text = Class16.smethod_0(1649001144);
		tabPage_2.Controls.Add(label_8);
		tabPage_2.Controls.Add(comboBox_0);
		tabPage_2.Controls.Add(label_9);
		tabPage_2.Controls.Add(numericUpDown_6);
		tabPage_2.Controls.Add(label_10);
		tabPage_2.Controls.Add(numericUpDown_7);
		tabPage_2.Controls.Add(label_11);
		tabPage_2.Controls.Add(numericUpDown_8);
		tabPage_2.Controls.Add(label_12);
		tabPage_2.Controls.Add(numericUpDown_9);
		tabPage_2.Controls.Add(label_13);
		tabPage_2.Controls.Add(numericUpDown_10);
		tabPage_2.Controls.Add(label_14);
		tabPage_2.Controls.Add(numericUpDown_11);
		tabPage_2.Controls.Add(label_15);
		tabPage_2.Controls.Add(numericUpDown_12);
		tabPage_2.Location = new Point(4, 24);
		tabPage_2.Name = Class16.smethod_0(1649001173);
		tabPage_2.Padding = new Padding(3);
		tabPage_2.Size = new Size(752, 452);
		tabPage_2.TabIndex = 2;
		tabPage_2.Text = Class16.smethod_0(1649001189);
		tabPage_2.UseVisualStyleBackColor = true;
		label_8.AutoSize = true;
		label_8.Location = new Point(20, 20);
		label_8.Text = Class16.smethod_0(1649001194);
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Location = new Point(150, 17);
		comboBox_0.Size = new Size(200, 23);
		comboBox_0.Items.AddRange(new object[12]
		{
			Class16.smethod_0(1648924120),
			Class16.smethod_0(1649006922),
			Class16.smethod_0(1649006950),
			Class16.smethod_0(1649001208),
			Class16.smethod_0(1649006962),
			Class16.smethod_0(1649006991),
			Class16.smethod_0(1649001226),
			Class16.smethod_0(1649001252),
			Class16.smethod_0(1649001270),
			Class16.smethod_0(1649001280),
			Class16.smethod_0(1649001298),
			Class16.smethod_0(1649007007)
		});
		label_9.AutoSize = true;
		label_9.Location = new Point(20, 50);
		label_9.Text = Class16.smethod_0(1649001325);
		numericUpDown_6.Location = new Point(150, 47);
		numericUpDown_6.Maximum = 255m;
		numericUpDown_6.Size = new Size(100, 23);
		label_10.AutoSize = true;
		label_10.Location = new Point(20, 80);
		label_10.Text = Class16.smethod_0(1649001336);
		numericUpDown_7.Location = new Point(150, 77);
		numericUpDown_7.Maximum = 4294967295m;
		numericUpDown_7.Size = new Size(150, 23);
		label_11.AutoSize = true;
		label_11.Location = new Point(20, 110);
		label_11.Text = Class16.smethod_0(1649001355);
		numericUpDown_8.Location = new Point(150, 107);
		numericUpDown_8.Maximum = 2147483647m;
		numericUpDown_8.Minimum = -2147483648m;
		numericUpDown_8.Size = new Size(150, 23);
		label_12.AutoSize = true;
		label_12.Location = new Point(20, 140);
		label_12.Text = Class16.smethod_0(1649001378);
		numericUpDown_9.Location = new Point(150, 137);
		numericUpDown_9.Maximum = 2147483647m;
		numericUpDown_9.Minimum = -2147483648m;
		numericUpDown_9.Size = new Size(150, 23);
		label_13.AutoSize = true;
		label_13.Location = new Point(20, 170);
		label_13.Text = Class16.smethod_0(1649001413);
		numericUpDown_10.Location = new Point(150, 167);
		numericUpDown_10.Maximum = 4294967295m;
		numericUpDown_10.Size = new Size(150, 23);
		label_14.AutoSize = true;
		label_14.Location = new Point(20, 200);
		label_14.Text = Class16.smethod_0(1649001430);
		numericUpDown_11.Location = new Point(150, 197);
		numericUpDown_11.Maximum = 4294967295m;
		numericUpDown_11.Size = new Size(150, 23);
		label_15.AutoSize = true;
		label_15.Location = new Point(20, 230);
		label_15.Text = Class16.smethod_0(1649001443);
		numericUpDown_12.Location = new Point(150, 227);
		numericUpDown_12.Maximum = 4294967295m;
		numericUpDown_12.Size = new Size(150, 23);
		tabPage_3.Controls.Add(listBox_0);
		tabPage_3.Controls.Add(button_0);
		tabPage_3.Controls.Add(button_1);
		tabPage_3.Controls.Add(propertyGrid_0);
		tabPage_3.Location = new Point(4, 24);
		tabPage_3.Name = Class16.smethod_0(1649001464);
		tabPage_3.Padding = new Padding(3);
		tabPage_3.Size = new Size(752, 452);
		tabPage_3.TabIndex = 3;
		tabPage_3.Text = Class16.smethod_0(1649000458);
		tabPage_3.UseVisualStyleBackColor = true;
		listBox_0.Location = new Point(10, 10);
		listBox_0.Size = new Size(250, 350);
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		button_0.Location = new Point(10, 370);
		button_0.Size = new Size(80, 25);
		button_0.Text = Class16.smethod_0(1648931361);
		button_0.Click += button_0_Click;
		button_1.Location = new Point(100, 370);
		button_1.Size = new Size(80, 25);
		button_1.Text = Class16.smethod_0(1648931371);
		button_1.Click += button_1_Click;
		propertyGrid_0.Location = new Point(270, 10);
		propertyGrid_0.Size = new Size(470, 400);
		propertyGrid_0.PropertyValueChanged += propertyGrid_0_PropertyValueChanged;
		tabPage_4.Controls.Add(listBox_1);
		tabPage_4.Controls.Add(button_2);
		tabPage_4.Controls.Add(button_3);
		tabPage_4.Controls.Add(propertyGrid_1);
		tabPage_4.Location = new Point(4, 24);
		tabPage_4.Name = Class16.smethod_0(1649000473);
		tabPage_4.Padding = new Padding(3);
		tabPage_4.Size = new Size(752, 452);
		tabPage_4.TabIndex = 4;
		tabPage_4.Text = Class16.smethod_0(1649000502);
		tabPage_4.UseVisualStyleBackColor = true;
		listBox_1.Location = new Point(10, 10);
		listBox_1.Size = new Size(250, 350);
		listBox_1.SelectedIndexChanged += listBox_1_SelectedIndexChanged;
		button_2.Location = new Point(10, 370);
		button_2.Size = new Size(80, 25);
		button_2.Text = Class16.smethod_0(1648931361);
		button_2.Click += button_2_Click;
		button_3.Location = new Point(100, 370);
		button_3.Size = new Size(80, 25);
		button_3.Text = Class16.smethod_0(1648931371);
		button_3.Click += button_3_Click;
		propertyGrid_1.Location = new Point(270, 10);
		propertyGrid_1.Size = new Size(470, 400);
		propertyGrid_1.PropertyValueChanged += propertyGrid_1_PropertyValueChanged;
		tabPage_5.Controls.Add(listBox_2);
		tabPage_5.Controls.Add(button_4);
		tabPage_5.Controls.Add(button_5);
		tabPage_5.Controls.Add(propertyGrid_2);
		tabPage_5.Controls.Add(label_16);
		tabPage_5.Controls.Add(numericUpDown_13);
		tabPage_5.Controls.Add(label_17);
		tabPage_5.Controls.Add(numericUpDown_14);
		tabPage_5.Controls.Add(label_18);
		tabPage_5.Controls.Add(numericUpDown_15);
		tabPage_5.Controls.Add(label_19);
		tabPage_5.Controls.Add(numericUpDown_16);
		tabPage_5.Controls.Add(label_20);
		tabPage_5.Controls.Add(numericUpDown_17);
		tabPage_5.Location = new Point(4, 24);
		tabPage_5.Name = Class16.smethod_0(1649000513);
		tabPage_5.Padding = new Padding(3);
		tabPage_5.Size = new Size(752, 452);
		tabPage_5.TabIndex = 5;
		tabPage_5.Text = Class16.smethod_0(1649000540);
		tabPage_5.UseVisualStyleBackColor = true;
		listBox_2.Location = new Point(10, 10);
		listBox_2.Size = new Size(200, 200);
		listBox_2.SelectedIndexChanged += listBox_2_SelectedIndexChanged;
		button_4.Location = new Point(10, 220);
		button_4.Size = new Size(80, 25);
		button_4.Text = Class16.smethod_0(1648931361);
		button_4.Click += button_4_Click;
		button_5.Location = new Point(100, 220);
		button_5.Size = new Size(80, 25);
		button_5.Text = Class16.smethod_0(1648931371);
		button_5.Click += button_5_Click;
		propertyGrid_2.Location = new Point(220, 10);
		propertyGrid_2.Size = new Size(520, 240);
		propertyGrid_2.PropertyValueChanged += propertyGrid_2_PropertyValueChanged;
		label_16.AutoSize = true;
		label_16.Location = new Point(10, 260);
		label_16.Text = Class16.smethod_0(1649000546);
		numericUpDown_13.Location = new Point(120, 257);
		numericUpDown_13.Maximum = 4294967295m;
		numericUpDown_13.Size = new Size(150, 23);
		label_17.AutoSize = true;
		label_17.Location = new Point(10, 290);
		label_17.Text = Class16.smethod_0(1649000572);
		numericUpDown_14.Location = new Point(120, 287);
		numericUpDown_14.Maximum = 2147483647m;
		numericUpDown_14.Minimum = -2147483648m;
		numericUpDown_14.Size = new Size(150, 23);
		label_18.AutoSize = true;
		label_18.Location = new Point(10, 320);
		label_18.Text = Class16.smethod_0(1649000590);
		numericUpDown_15.Location = new Point(120, 317);
		numericUpDown_15.Maximum = 4294967295m;
		numericUpDown_15.Size = new Size(150, 23);
		label_19.AutoSize = true;
		label_19.Location = new Point(380, 260);
		label_19.Text = Class16.smethod_0(1649000604);
		numericUpDown_16.Location = new Point(480, 257);
		numericUpDown_16.Maximum = 4294967295m;
		numericUpDown_16.Size = new Size(150, 23);
		label_20.AutoSize = true;
		label_20.Location = new Point(380, 290);
		label_20.Text = Class16.smethod_0(1649000611);
		numericUpDown_17.Location = new Point(480, 287);
		numericUpDown_17.Maximum = 4294967295m;
		numericUpDown_17.Size = new Size(150, 23);
		tabPage_6.Controls.Add(listBox_3);
		tabPage_6.Controls.Add(button_6);
		tabPage_6.Controls.Add(button_7);
		tabPage_6.Controls.Add(propertyGrid_3);
		tabPage_6.Location = new Point(4, 24);
		tabPage_6.Name = Class16.smethod_0(1649000625);
		tabPage_6.Padding = new Padding(3);
		tabPage_6.Size = new Size(752, 452);
		tabPage_6.TabIndex = 6;
		tabPage_6.Text = Class16.smethod_0(1649000653);
		tabPage_6.UseVisualStyleBackColor = true;
		listBox_3.Location = new Point(10, 10);
		listBox_3.Size = new Size(250, 350);
		listBox_3.SelectedIndexChanged += listBox_3_SelectedIndexChanged;
		button_6.Location = new Point(10, 370);
		button_6.Size = new Size(80, 25);
		button_6.Text = Class16.smethod_0(1648931361);
		button_6.Click += button_6_Click;
		button_7.Location = new Point(100, 370);
		button_7.Size = new Size(80, 25);
		button_7.Text = Class16.smethod_0(1648931371);
		button_7.Click += button_7_Click;
		propertyGrid_3.Location = new Point(270, 10);
		propertyGrid_3.Size = new Size(470, 400);
		propertyGrid_3.PropertyValueChanged += propertyGrid_3_PropertyValueChanged;
		tabPage_7.Controls.Add(label_21);
		tabPage_7.Controls.Add(textBox_2);
		tabPage_7.Controls.Add(label_22);
		tabPage_7.Controls.Add(textBox_3);
		tabPage_7.Controls.Add(label_23);
		tabPage_7.Controls.Add(textBox_4);
		tabPage_7.Location = new Point(4, 24);
		tabPage_7.Name = Class16.smethod_0(1649000671);
		tabPage_7.Padding = new Padding(3);
		tabPage_7.Size = new Size(752, 452);
		tabPage_7.TabIndex = 7;
		tabPage_7.Text = Class16.smethod_0(1649000686);
		tabPage_7.UseVisualStyleBackColor = true;
		label_21.AutoSize = true;
		label_21.Location = new Point(10, 10);
		label_21.Text = Class16.smethod_0(1649000690);
		textBox_2.Location = new Point(10, 30);
		textBox_2.Multiline = true;
		textBox_2.ScrollBars = ScrollBars.Vertical;
		textBox_2.Size = new Size(720, 120);
		label_22.AutoSize = true;
		label_22.Location = new Point(10, 160);
		label_22.Text = Class16.smethod_0(1649000717);
		textBox_3.Location = new Point(10, 180);
		textBox_3.Multiline = true;
		textBox_3.ScrollBars = ScrollBars.Vertical;
		textBox_3.Size = new Size(720, 100);
		label_23.AutoSize = true;
		label_23.Location = new Point(10, 290);
		label_23.Text = Class16.smethod_0(1649000732);
		textBox_4.Location = new Point(10, 310);
		textBox_4.Multiline = true;
		textBox_4.ScrollBars = ScrollBars.Vertical;
		textBox_4.Size = new Size(720, 100);
		tabPage_8.Controls.Add(propertyGrid_4);
		tabPage_8.Location = new Point(4, 24);
		tabPage_8.Name = Class16.smethod_0(1649000739);
		tabPage_8.Padding = new Padding(3);
		tabPage_8.Size = new Size(752, 452);
		tabPage_8.TabIndex = 8;
		tabPage_8.Text = Class16.smethod_0(1649000754);
		tabPage_8.UseVisualStyleBackColor = true;
		propertyGrid_4.Dock = DockStyle.Fill;
		tabPage_9.Controls.Add(label_24);
		tabPage_9.Controls.Add(propertyGrid_5);
		tabPage_9.Controls.Add(label_25);
		tabPage_9.Controls.Add(propertyGrid_6);
		tabPage_9.Location = new Point(4, 24);
		tabPage_9.Name = Class16.smethod_0(1649000774);
		tabPage_9.Padding = new Padding(3);
		tabPage_9.Size = new Size(752, 452);
		tabPage_9.TabIndex = 9;
		tabPage_9.Text = Class16.smethod_0(1649000789);
		tabPage_9.UseVisualStyleBackColor = true;
		label_24.AutoSize = true;
		label_24.Location = new Point(10, 10);
		label_24.Text = Class16.smethod_0(1649000793);
		propertyGrid_5.Location = new Point(10, 30);
		propertyGrid_5.Size = new Size(360, 410);
		label_25.AutoSize = true;
		label_25.Location = new Point(380, 10);
		label_25.Text = Class16.smethod_0(1649000818);
		propertyGrid_6.Location = new Point(380, 30);
		propertyGrid_6.Size = new Size(360, 410);
		button_8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_8.Location = new Point(592, 500);
		button_8.Name = Class16.smethod_0(1649000844);
		button_8.Size = new Size(90, 28);
		button_8.TabIndex = 1;
		button_8.Text = Class16.smethod_0(1648938905);
		button_8.UseVisualStyleBackColor = true;
		button_8.Click += button_8_Click;
		button_9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_9.DialogResult = DialogResult.Cancel;
		button_9.Location = new Point(688, 500);
		button_9.Name = Class16.smethod_0(1649000848);
		button_9.Size = new Size(90, 28);
		button_9.TabIndex = 2;
		button_9.Text = Class16.smethod_0(1648941799);
		button_9.UseVisualStyleBackColor = true;
		button_9.Click += button_9_Click;
		base.AcceptButton = button_8;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = button_9;
		base.ClientSize = new Size(784, 540);
		base.Controls.Add(tabControl_0);
		base.Controls.Add(button_8);
		base.Controls.Add(button_9);
		Font = new Font(Class16.smethod_0(1648942905), 9f);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649000864);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649000890);
		base.Activated += DynTaskDetailEditor_Activated;
		tabControl_0.ResumeLayout(performLayout: false);
		tabPage_0.ResumeLayout(performLayout: false);
		tabPage_0.PerformLayout();
		tabPage_1.ResumeLayout(performLayout: false);
		tabPage_1.PerformLayout();
		tabPage_2.ResumeLayout(performLayout: false);
		tabPage_2.PerformLayout();
		tabPage_3.ResumeLayout(performLayout: false);
		tabPage_4.ResumeLayout(performLayout: false);
		tabPage_5.ResumeLayout(performLayout: false);
		tabPage_5.PerformLayout();
		tabPage_6.ResumeLayout(performLayout: false);
		tabPage_7.ResumeLayout(performLayout: false);
		tabPage_7.PerformLayout();
		tabPage_8.ResumeLayout(performLayout: false);
		tabPage_9.ResumeLayout(performLayout: false);
		tabPage_9.PerformLayout();
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		((ISupportInitialize)numericUpDown_2).EndInit();
		((ISupportInitialize)numericUpDown_3).EndInit();
		((ISupportInitialize)numericUpDown_4).EndInit();
		((ISupportInitialize)numericUpDown_5).EndInit();
		((ISupportInitialize)numericUpDown_6).EndInit();
		((ISupportInitialize)numericUpDown_7).EndInit();
		((ISupportInitialize)numericUpDown_8).EndInit();
		((ISupportInitialize)numericUpDown_9).EndInit();
		((ISupportInitialize)numericUpDown_10).EndInit();
		((ISupportInitialize)numericUpDown_11).EndInit();
		((ISupportInitialize)numericUpDown_12).EndInit();
		((ISupportInitialize)numericUpDown_13).EndInit();
		((ISupportInitialize)numericUpDown_14).EndInit();
		((ISupportInitialize)numericUpDown_15).EndInit();
		((ISupportInitialize)numericUpDown_16).EndInit();
		((ISupportInitialize)numericUpDown_17).EndInit();
		ResumeLayout(performLayout: false);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		DYN_TASKS.ItemWanted item = new DYN_TASKS.ItemWanted
		{
			ItemTemplId = 1,
			ItemNum = 1
		};
		Task.PremItems.Add(item);
		method_5();
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		if (listBox_2.SelectedIndex >= 0 && listBox_2.SelectedIndex < Task.PremItems.Count)
		{
			Task.PremItems.RemoveAt(listBox_2.SelectedIndex);
			propertyGrid_2.SelectedObject = null;
			method_5();
		}
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		DYN_TASKS.ItemWanted item = new DYN_TASKS.ItemWanted
		{
			ItemTemplId = 1,
			ItemNum = 1
		};
		Task.GivenItems.Add(item);
		method_6();
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		if (listBox_3.SelectedIndex >= 0 && listBox_3.SelectedIndex < Task.GivenItems.Count)
		{
			Task.GivenItems.RemoveAt(listBox_3.SelectedIndex);
			propertyGrid_3.SelectedObject = null;
			method_6();
		}
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listBox_0.SelectedIndex >= 0 && listBox_0.SelectedIndex < Task.MonsterWanted.Count)
		{
			propertyGrid_0.SelectedObject = Task.MonsterWanted[listBox_0.SelectedIndex];
		}
	}

	private void listBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listBox_1.SelectedIndex >= 0 && listBox_1.SelectedIndex < Task.ItemsWanted.Count)
		{
			propertyGrid_1.SelectedObject = Task.ItemsWanted[listBox_1.SelectedIndex];
		}
	}

	private void listBox_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listBox_2.SelectedIndex >= 0 && listBox_2.SelectedIndex < Task.PremItems.Count)
		{
			propertyGrid_2.SelectedObject = Task.PremItems[listBox_2.SelectedIndex];
		}
	}

	private void listBox_3_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listBox_3.SelectedIndex >= 0 && listBox_3.SelectedIndex < Task.GivenItems.Count)
		{
			propertyGrid_3.SelectedObject = Task.GivenItems[listBox_3.SelectedIndex];
		}
	}

	private void propertyGrid_0_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		method_3();
	}

	private void propertyGrid_1_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		method_4();
	}

	private void propertyGrid_2_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		method_5();
	}

	private void propertyGrid_3_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		method_6();
	}

	private void DynTaskDetailEditor_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_DynTaskDetailEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_DynTaskDetailEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}
}
