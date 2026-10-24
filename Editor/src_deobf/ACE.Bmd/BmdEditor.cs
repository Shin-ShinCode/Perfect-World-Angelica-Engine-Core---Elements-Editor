using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.Bmd;

public class BmdEditor : Form
{
	private sealed class Class50
	{
		public BmdEditor bmdEditor_0;

		public DataGridView dataGridView_0;

		internal void method_0(object sender, DataGridViewCellCancelEventArgs e)
		{
			bmdEditor_0.method_36(dataGridView_0);
		}

		internal void method_1(object sender, EventArgs e)
		{
			bmdEditor_0.method_38(dataGridView_0);
		}
	}

	public BMD Data;

	public CommonStorage CStorage;

	private bool bool_0;

	private IContainer icontainer_0;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripButton toolStripButton_4;

	private ToolStripButton toolStripButton_5;

	private ToolStripButton toolStripButton_6;

	private ToolStripButton toolStripButton_7;

	private StatusStrip statusStrip_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private Panel panel_0;

	private Label label_0;

	private TextBox textBox_0;

	private SplitContainer splitContainer_0;

	private GroupBox groupBox_0;

	private ListBox listBox_0;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private PropertyGrid propertyGrid_0;

	private TabPage tabPage_1;

	private PropertyGrid propertyGrid_1;

	private TabPage tabPage_2;

	private DataGridView dataGridView_0;

	private Panel panel_1;

	private Button button_0;

	private Button button_1;

	private TabPage tabPage_3;

	private DataGridView dataGridView_1;

	private Panel panel_2;

	private Button button_2;

	private Button button_3;

	private TabPage tabPage_4;

	private DataGridView dataGridView_2;

	private Panel panel_3;

	private Button button_4;

	private Button button_5;

	private TabPage tabPage_5;

	private DataGridView dataGridView_3;

	private Panel panel_4;

	private Button button_6;

	private Button button_7;

	private TabPage tabPage_6;

	private SplitContainer splitContainer_1;

	private GroupBox groupBox_1;

	private ListBox listBox_1;

	private Panel panel_5;

	private Button button_8;

	private Button button_9;

	private GroupBox groupBox_2;

	private DataGridView dataGridView_4;

	private Panel panel_6;

	private Button button_10;

	private Button button_11;

	private GroupBox groupBox_3;

	private ListBox listBox_2;

	private Panel panel_7;

	private Button button_12;

	private Button button_13;

	private PropertyGrid propertyGrid_2;

	private GroupBox groupBox_4;

	private DataGridView dataGridView_5;

	private Panel panel_8;

	private Button button_14;

	private Button button_15;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private bool bool_1;

	private byte[] byte_0;

	private Control control_0;

	public BmdEditor(CommonStorage cStorage)
	{
		method_10();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		CStorage = cStorage;
		Data = new BMD();
		bool_0 = false;
		TextStorage.TEXTS.SetFormLanguage(this, null);
		method_7();
		method_28();
		method_3();
	}

	public void OpenFile(string fileName)
	{
		if (string.IsNullOrWhiteSpace(fileName))
		{
			return;
		}
		if (!File.Exists(fileName))
		{
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648921395), Class16.smethod_0(1648921428)), fileName), Class16.smethod_0(1648921454), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		try
		{
			Data = new BMD(fileName);
			method_0();
			method_35();
			method_4(Class16.smethod_0(1648921456) + System.IO.Path.GetFileName(fileName));
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648921478));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648921503), Class16.smethod_0(1648921532)), ex.Message), Class16.smethod_0(1648921554), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_0()
	{
		bool_0 = true;
		try
		{
			TextBox textBox = textBox_0;
			BMD data = Data;
			object obj;
			if (data == null)
			{
				obj = null;
			}
			else
			{
				obj = data.fn;
				if (obj != null)
				{
					goto IL_0028;
				}
			}
			obj = string.Empty;
			goto IL_0028;
			IL_0028:
			textBox.Text = (string)obj;
			propertyGrid_0.SelectedObject = Data;
			method_1();
			if (listBox_0.Items.Count > 0)
			{
				listBox_0.SelectedIndex = 0;
			}
			else
			{
				method_15();
			}
			method_3();
			method_2();
		}
		finally
		{
			bool_0 = false;
		}
	}

	private void method_1()
	{
		bool_0 = true;
		try
		{
			int num = listBox_0.SelectedIndex;
			listBox_0.BeginUpdate();
			listBox_0.Items.Clear();
			if (Data?.Meshes != null)
			{
				for (int i = 0; i < Data.Meshes.Count; i++)
				{
					listBox_0.Items.Add(string.Format(Class16.smethod_0(1648921583), i, Data.Meshes[i]));
				}
			}
			listBox_0.EndUpdate();
			if (listBox_0.Items.Count > 0)
			{
				if (num < 0 || num >= listBox_0.Items.Count)
				{
					num = 0;
				}
				listBox_0.SelectedIndex = num;
			}
		}
		finally
		{
			bool_0 = false;
		}
	}

	private void method_2()
	{
		string text = (string.IsNullOrWhiteSpace(Data?.fn) ? Class16.smethod_0(1648920580) : System.IO.Path.GetFileName(Data.fn));
		string text2 = ((Data == null || !Data.FileChanged) ? string.Empty : Class16.smethod_0(1648941528));
		Text = Class16.smethod_0(1648920586) + text + text2;
	}

	private void method_3()
	{
		bool flag = Data != null;
		bool enabled = method_6() != null;
		toolStripButton_1.Enabled = flag && Data.FileChanged;
		toolStripMenuItem_2.Enabled = toolStripButton_1.Enabled;
		toolStripButton_3.Enabled = enabled;
		toolStripButton_5.Enabled = Data != null && listBox_1.SelectedIndex >= 0;
		toolStripButton_7.Enabled = Data != null && listBox_2.SelectedIndex >= 0;
	}

	private void method_4(string string_0)
	{
		toolStripStatusLabel_0.Text = (string.IsNullOrWhiteSpace(string_0) ? Class16.smethod_0(1648920624) : string_0);
	}

	private void method_5()
	{
		if (Data != null)
		{
			Data.FileChanged = true;
			method_3();
			method_2();
		}
	}

	private BMD.BmdMesh method_6()
	{
		if (Data?.Meshes == null)
		{
			return null;
		}
		int selectedIndex = listBox_0.SelectedIndex;
		if (selectedIndex >= 0 && selectedIndex < Data.Meshes.Count)
		{
			return Data.Meshes[selectedIndex];
		}
		return null;
	}

	private void method_7()
	{
		TDark.ApplyThemeToDynamicControl(dataGridView_0);
		TDark.ApplyThemeToDynamicControl(dataGridView_1);
		TDark.ApplyThemeToDynamicControl(dataGridView_2);
		TDark.ApplyThemeToDynamicControl(dataGridView_3);
		TDark.ApplyThemeToDynamicControl(dataGridView_4);
		TDark.ApplyThemeToDynamicControl(dataGridView_5);
		TDark.ApplyThemeToDynamicControl(propertyGrid_0);
		TDark.ApplyThemeToDynamicControl(propertyGrid_1);
		TDark.ApplyThemeToDynamicControl(propertyGrid_2);
	}

	private void method_8()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		try
		{
			openFileDialog.Filter = Class16.smethod_0(1648920644);
			openFileDialog.FileName = Class16.smethod_0(1648920693);
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				OpenFile(openFileDialog.FileName);
			}
		}
		finally
		{
			((IDisposable)openFileDialog).Dispose();
		}
	}

	private void method_9()
	{
		if (Data == null)
		{
			return;
		}
		try
		{
			if (!string.IsNullOrWhiteSpace(Data.fn) && File.Exists(Data.fn))
			{
				try
				{
					CStorage?.CreateBackup(Data.fn);
				}
				catch
				{
				}
			}
			Data.Save();
			method_3();
			method_2();
			method_4(Class16.smethod_0(1648920709) + System.IO.Path.GetFileName(Data.fn));
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648920714));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648920750), Class16.smethod_0(1648920771)), ex.Message), Class16.smethod_0(1648920801), MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

	private void method_10()
	{
		icontainer_0 = new Container();
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		toolStrip_0 = new ToolStrip();
		toolStripButton_0 = new ToolStripButton();
		toolStripButton_1 = new ToolStripButton();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripButton_2 = new ToolStripButton();
		toolStripButton_3 = new ToolStripButton();
		toolStripSeparator_1 = new ToolStripSeparator();
		toolStripButton_4 = new ToolStripButton();
		toolStripButton_5 = new ToolStripButton();
		toolStripButton_6 = new ToolStripButton();
		toolStripButton_7 = new ToolStripButton();
		statusStrip_0 = new StatusStrip();
		toolStripStatusLabel_0 = new ToolStripStatusLabel();
		panel_0 = new Panel();
		label_0 = new Label();
		textBox_0 = new TextBox();
		splitContainer_0 = new SplitContainer();
		groupBox_0 = new GroupBox();
		listBox_0 = new ListBox();
		tabControl_0 = new TabControl();
		tabPage_0 = new TabPage();
		propertyGrid_0 = new PropertyGrid();
		tabPage_1 = new TabPage();
		propertyGrid_1 = new PropertyGrid();
		tabPage_2 = new TabPage();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		panel_1 = new Panel();
		button_0 = new Button();
		button_1 = new Button();
		tabPage_3 = new TabPage();
		dataGridView_1 = new DataGridView();
		dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		panel_2 = new Panel();
		button_2 = new Button();
		button_3 = new Button();
		tabPage_4 = new TabPage();
		dataGridView_2 = new DataGridView();
		dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
		panel_3 = new Panel();
		button_4 = new Button();
		button_5 = new Button();
		tabPage_5 = new TabPage();
		dataGridView_3 = new DataGridView();
		dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
		panel_4 = new Panel();
		button_6 = new Button();
		button_7 = new Button();
		tabPage_6 = new TabPage();
		splitContainer_1 = new SplitContainer();
		groupBox_1 = new GroupBox();
		listBox_1 = new ListBox();
		panel_5 = new Panel();
		button_8 = new Button();
		button_9 = new Button();
		groupBox_2 = new GroupBox();
		dataGridView_4 = new DataGridView();
		dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
		panel_6 = new Panel();
		button_10 = new Button();
		button_11 = new Button();
		groupBox_3 = new GroupBox();
		listBox_2 = new ListBox();
		panel_7 = new Panel();
		button_12 = new Button();
		button_13 = new Button();
		propertyGrid_2 = new PropertyGrid();
		groupBox_4 = new GroupBox();
		dataGridView_5 = new DataGridView();
		dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
		panel_8 = new Panel();
		button_14 = new Button();
		button_15 = new Button();
		menuStrip_0.SuspendLayout();
		toolStrip_0.SuspendLayout();
		statusStrip_0.SuspendLayout();
		panel_0.SuspendLayout();
		((ISupportInitialize)splitContainer_0).BeginInit();
		splitContainer_0.Panel1.SuspendLayout();
		splitContainer_0.Panel2.SuspendLayout();
		splitContainer_0.SuspendLayout();
		groupBox_0.SuspendLayout();
		tabControl_0.SuspendLayout();
		tabPage_0.SuspendLayout();
		tabPage_1.SuspendLayout();
		tabPage_2.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		panel_1.SuspendLayout();
		tabPage_3.SuspendLayout();
		((ISupportInitialize)dataGridView_1).BeginInit();
		panel_2.SuspendLayout();
		tabPage_4.SuspendLayout();
		((ISupportInitialize)dataGridView_2).BeginInit();
		panel_3.SuspendLayout();
		tabPage_5.SuspendLayout();
		((ISupportInitialize)dataGridView_3).BeginInit();
		panel_4.SuspendLayout();
		tabPage_6.SuspendLayout();
		((ISupportInitialize)splitContainer_1).BeginInit();
		splitContainer_1.Panel1.SuspendLayout();
		splitContainer_1.Panel2.SuspendLayout();
		splitContainer_1.SuspendLayout();
		groupBox_1.SuspendLayout();
		panel_5.SuspendLayout();
		groupBox_2.SuspendLayout();
		((ISupportInitialize)dataGridView_4).BeginInit();
		panel_6.SuspendLayout();
		groupBox_3.SuspendLayout();
		panel_7.SuspendLayout();
		groupBox_4.SuspendLayout();
		((ISupportInitialize)dataGridView_5).BeginInit();
		panel_8.SuspendLayout();
		SuspendLayout();
		menuStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripMenuItem_0 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1648920830);
		menuStrip_0.Size = new Size(1438, 24);
		menuStrip_0.TabIndex = 0;
		toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[4] { toolStripMenuItem_1, toolStripMenuItem_2, toolStripMenuItem_3, toolStripMenuItem_4 });
		toolStripMenuItem_0.Name = Class16.smethod_0(1648920842);
		toolStripMenuItem_0.Size = new Size(37, 20);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_1.Name = Class16.smethod_0(1648920856);
		toolStripMenuItem_1.Size = new Size(123, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648931498);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_2.Name = Class16.smethod_0(1648920878);
		toolStripMenuItem_2.Size = new Size(123, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.Name = Class16.smethod_0(1648920892);
		toolStripMenuItem_3.Size = new Size(123, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1648931581);
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		toolStripMenuItem_4.Name = Class16.smethod_0(1648920908);
		toolStripMenuItem_4.Size = new Size(123, 22);
		toolStripMenuItem_4.Text = Class16.smethod_0(1648920914);
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		toolStrip_0.Items.AddRange(new ToolStripItem[10] { toolStripButton_0, toolStripButton_1, toolStripSeparator_0, toolStripButton_2, toolStripButton_3, toolStripSeparator_1, toolStripButton_4, toolStripButton_5, toolStripButton_6, toolStripButton_7 });
		toolStrip_0.Location = new Point(0, 24);
		toolStrip_0.Name = Class16.smethod_0(1648920933);
		toolStrip_0.Size = new Size(1438, 25);
		toolStrip_0.TabIndex = 1;
		toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_0.Name = Class16.smethod_0(1648920945);
		toolStripButton_0.Size = new Size(40, 22);
		toolStripButton_0.Text = Class16.smethod_0(1648931498);
		toolStripButton_0.Click += toolStripButton_0_Click;
		toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_1.Enabled = false;
		toolStripButton_1.Name = Class16.smethod_0(1648920967);
		toolStripButton_1.Size = new Size(35, 22);
		toolStripButton_1.Text = Class16.smethod_0(1648941761);
		toolStripButton_1.Click += toolStripButton_1_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1648920981);
		toolStripSeparator_0.Size = new Size(6, 25);
		toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_2.Name = Class16.smethod_0(1648921007);
		toolStripButton_2.Size = new Size(66, 22);
		toolStripButton_2.Text = Class16.smethod_0(1648921016);
		toolStripButton_2.Click += toolStripButton_2_Click;
		toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_3.Name = Class16.smethod_0(1648921039);
		toolStripButton_3.Size = new Size(79, 22);
		toolStripButton_3.Text = Class16.smethod_0(1648921051);
		toolStripButton_3.Click += toolStripButton_3_Click;
		toolStripSeparator_1.Name = Class16.smethod_0(1648921077);
		toolStripSeparator_1.Size = new Size(6, 25);
		toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_4.Name = Class16.smethod_0(1648915983);
		toolStripButton_4.Size = new Size(59, 22);
		toolStripButton_4.Text = Class16.smethod_0(1648915992);
		toolStripButton_4.Click += button_8_Click;
		toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_5.Name = Class16.smethod_0(1648916015);
		toolStripButton_5.Size = new Size(72, 22);
		toolStripButton_5.Text = Class16.smethod_0(1648916027);
		toolStripButton_5.Click += button_9_Click;
		toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_6.Name = Class16.smethod_0(1648916053);
		toolStripButton_6.Size = new Size(67, 22);
		toolStripButton_6.Text = Class16.smethod_0(1648916071);
		toolStripButton_6.Click += button_12_Click;
		toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_7.Name = Class16.smethod_0(1648916087);
		toolStripButton_7.Size = new Size(80, 22);
		toolStripButton_7.Text = Class16.smethod_0(1648916108);
		toolStripButton_7.Click += button_13_Click;
		statusStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripStatusLabel_0 });
		statusStrip_0.Location = new Point(0, 800);
		statusStrip_0.Name = Class16.smethod_0(1648916127);
		statusStrip_0.Size = new Size(1438, 22);
		statusStrip_0.TabIndex = 2;
		toolStripStatusLabel_0.Name = Class16.smethod_0(1648916149);
		toolStripStatusLabel_0.Size = new Size(39, 17);
		toolStripStatusLabel_0.Text = Class16.smethod_0(1648920624);
		panel_0.Controls.Add(textBox_0);
		panel_0.Controls.Add(label_0);
		panel_0.Dock = DockStyle.Top;
		panel_0.Location = new Point(0, 49);
		panel_0.Name = Class16.smethod_0(1648916165);
		panel_0.Padding = new Padding(8, 6, 8, 6);
		panel_0.Size = new Size(1438, 34);
		panel_0.TabIndex = 3;
		label_0.AutoSize = true;
		label_0.Location = new Point(11, 10);
		label_0.Name = Class16.smethod_0(1648916183);
		label_0.Size = new Size(26, 15);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1648916193);
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.Location = new Point(43, 6);
		textBox_0.Name = Class16.smethod_0(1648916213);
		textBox_0.ReadOnly = true;
		textBox_0.Size = new Size(1383, 23);
		textBox_0.TabIndex = 1;
		splitContainer_0.Dock = DockStyle.Fill;
		splitContainer_0.Location = new Point(0, 83);
		splitContainer_0.Name = Class16.smethod_0(1648916231);
		splitContainer_0.Panel1.Controls.Add(groupBox_0);
		splitContainer_0.Panel2.Controls.Add(tabControl_0);
		splitContainer_0.Size = new Size(1438, 717);
		splitContainer_0.SplitterDistance = 312;
		splitContainer_0.TabIndex = 4;
		groupBox_0.Controls.Add(listBox_0);
		groupBox_0.Dock = DockStyle.Fill;
		groupBox_0.Location = new Point(0, 0);
		groupBox_0.Name = Class16.smethod_0(1648916247);
		groupBox_0.Padding = new Padding(8);
		groupBox_0.Size = new Size(312, 717);
		groupBox_0.TabIndex = 0;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1648916263);
		listBox_0.Dock = DockStyle.Fill;
		listBox_0.FormattingEnabled = true;
		listBox_0.ItemHeight = 15;
		listBox_0.Location = new Point(8, 24);
		listBox_0.Name = Class16.smethod_0(1648916276);
		listBox_0.Size = new Size(296, 685);
		listBox_0.TabIndex = 0;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		tabControl_0.Controls.Add(tabPage_0);
		tabControl_0.Controls.Add(tabPage_1);
		tabControl_0.Controls.Add(tabPage_2);
		tabControl_0.Controls.Add(tabPage_3);
		tabControl_0.Controls.Add(tabPage_4);
		tabControl_0.Controls.Add(tabPage_5);
		tabControl_0.Controls.Add(tabPage_6);
		tabControl_0.Dock = DockStyle.Fill;
		tabControl_0.Location = new Point(0, 0);
		tabControl_0.Name = Class16.smethod_0(1648916292);
		tabControl_0.SelectedIndex = 0;
		tabControl_0.Size = new Size(1122, 717);
		tabControl_0.TabIndex = 0;
		tabPage_0.Controls.Add(propertyGrid_0);
		tabPage_0.Location = new Point(4, 24);
		tabPage_0.Name = Class16.smethod_0(1648916298);
		tabPage_0.Padding = new Padding(3);
		tabPage_0.Size = new Size(1114, 689);
		tabPage_0.TabIndex = 0;
		tabPage_0.Text = Class16.smethod_0(1648931458);
		tabPage_0.UseVisualStyleBackColor = true;
		propertyGrid_0.Dock = DockStyle.Fill;
		propertyGrid_0.Location = new Point(3, 3);
		propertyGrid_0.Name = Class16.smethod_0(1648916312);
		propertyGrid_0.Size = new Size(1108, 683);
		propertyGrid_0.TabIndex = 0;
		propertyGrid_0.PropertyValueChanged += propertyGrid_0_PropertyValueChanged;
		tabPage_1.Controls.Add(propertyGrid_1);
		tabPage_1.Location = new Point(4, 24);
		tabPage_1.Name = Class16.smethod_0(1648916331);
		tabPage_1.Padding = new Padding(3);
		tabPage_1.Size = new Size(1114, 689);
		tabPage_1.TabIndex = 1;
		tabPage_1.Text = Class16.smethod_0(1648916345);
		tabPage_1.UseVisualStyleBackColor = true;
		propertyGrid_1.Dock = DockStyle.Fill;
		propertyGrid_1.Location = new Point(3, 3);
		propertyGrid_1.Name = Class16.smethod_0(1648916364);
		propertyGrid_1.Size = new Size(1108, 683);
		propertyGrid_1.TabIndex = 0;
		propertyGrid_1.PropertyValueChanged += propertyGrid_1_PropertyValueChanged;
		tabPage_2.Controls.Add(dataGridView_0);
		tabPage_2.Controls.Add(panel_1);
		tabPage_2.Location = new Point(4, 24);
		tabPage_2.Name = Class16.smethod_0(1648916383);
		tabPage_2.Padding = new Padding(3);
		tabPage_2.Size = new Size(1114, 689);
		tabPage_2.TabIndex = 2;
		tabPage_2.Text = Class16.smethod_0(1648916393);
		tabPage_2.UseVisualStyleBackColor = true;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1, dataGridViewTextBoxColumn_2, dataGridViewTextBoxColumn_3, dataGridViewTextBoxColumn_4, dataGridViewTextBoxColumn_5, dataGridViewTextBoxColumn_6, dataGridViewTextBoxColumn_7);
		dataGridView_0.Dock = DockStyle.Fill;
		dataGridView_0.Location = new Point(3, 39);
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1648916408);
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.Size = new Size(1108, 647);
		dataGridView_0.TabIndex = 1;
		dataGridView_0.CellValueChanged += dataGridView_0_CellValueChanged;
		dataGridViewTextBoxColumn_0.FillWeight = 55f;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648929947);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648916426);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648916453);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648916461);
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648916476);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648915460);
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648915467);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1648915475);
		dataGridViewTextBoxColumn_4.HeaderText = Class16.smethod_0(1648915490);
		dataGridViewTextBoxColumn_4.Name = Class16.smethod_0(1648915504);
		dataGridViewTextBoxColumn_5.HeaderText = Class16.smethod_0(1648915533);
		dataGridViewTextBoxColumn_5.Name = Class16.smethod_0(1648915548);
		dataGridViewTextBoxColumn_6.HeaderText = Class16.smethod_0(1648915562);
		dataGridViewTextBoxColumn_6.Name = Class16.smethod_0(1648915570);
		dataGridViewTextBoxColumn_7.HeaderText = Class16.smethod_0(1648915585);
		dataGridViewTextBoxColumn_7.Name = Class16.smethod_0(1648915593);
		panel_1.Controls.Add(button_1);
		panel_1.Controls.Add(button_0);
		panel_1.Dock = DockStyle.Top;
		panel_1.Location = new Point(3, 3);
		panel_1.Name = Class16.smethod_0(1648915608);
		panel_1.Size = new Size(1108, 36);
		panel_1.TabIndex = 0;
		button_0.Location = new Point(6, 6);
		button_0.Name = Class16.smethod_0(1648915633);
		button_0.Size = new Size(94, 24);
		button_0.TabIndex = 0;
		button_0.Text = Class16.smethod_0(1648915660);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Location = new Point(106, 6);
		button_1.Name = Class16.smethod_0(1648915677);
		button_1.Size = new Size(107, 24);
		button_1.TabIndex = 1;
		button_1.Text = Class16.smethod_0(1648915691);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		tabPage_3.Controls.Add(dataGridView_1);
		tabPage_3.Controls.Add(panel_2);
		tabPage_3.Location = new Point(4, 24);
		tabPage_3.Name = Class16.smethod_0(1648915719);
		tabPage_3.Padding = new Padding(3);
		tabPage_3.Size = new Size(1114, 689);
		tabPage_3.TabIndex = 3;
		tabPage_3.Text = Class16.smethod_0(1648915734);
		tabPage_3.UseVisualStyleBackColor = true;
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToDeleteRows = false;
		dataGridView_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_1.Columns.AddRange(dataGridViewTextBoxColumn_8, dataGridViewTextBoxColumn_9, dataGridViewTextBoxColumn_10, dataGridViewTextBoxColumn_11);
		dataGridView_1.Dock = DockStyle.Fill;
		dataGridView_1.Location = new Point(3, 39);
		dataGridView_1.MultiSelect = false;
		dataGridView_1.Name = Class16.smethod_0(1648915738);
		dataGridView_1.RowHeadersVisible = false;
		dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_1.Size = new Size(1108, 647);
		dataGridView_1.TabIndex = 1;
		dataGridView_1.CellValueChanged += dataGridView_1_CellValueChanged;
		dataGridViewTextBoxColumn_8.FillWeight = 55f;
		dataGridViewTextBoxColumn_8.HeaderText = Class16.smethod_0(1648929947);
		dataGridViewTextBoxColumn_8.Name = Class16.smethod_0(1648915753);
		dataGridViewTextBoxColumn_8.ReadOnly = true;
		dataGridViewTextBoxColumn_9.HeaderText = Class16.smethod_0(1648915780);
		dataGridViewTextBoxColumn_9.Name = Class16.smethod_0(1648915788);
		dataGridViewTextBoxColumn_10.HeaderText = Class16.smethod_0(1648915795);
		dataGridViewTextBoxColumn_10.Name = Class16.smethod_0(1648915803);
		dataGridViewTextBoxColumn_11.HeaderText = Class16.smethod_0(1648915818);
		dataGridViewTextBoxColumn_11.Name = Class16.smethod_0(1648915826);
		panel_2.Controls.Add(button_3);
		panel_2.Controls.Add(button_2);
		panel_2.Dock = DockStyle.Top;
		panel_2.Location = new Point(3, 3);
		panel_2.Name = Class16.smethod_0(1648915841);
		panel_2.Size = new Size(1108, 36);
		panel_2.TabIndex = 0;
		button_2.Location = new Point(6, 6);
		button_2.Name = Class16.smethod_0(1648915871);
		button_2.Size = new Size(94, 24);
		button_2.TabIndex = 0;
		button_2.Text = Class16.smethod_0(1648915880);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Location = new Point(106, 6);
		button_3.Name = Class16.smethod_0(1648915903);
		button_3.Size = new Size(107, 24);
		button_3.TabIndex = 1;
		button_3.Text = Class16.smethod_0(1648915915);
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		tabPage_4.Controls.Add(dataGridView_2);
		tabPage_4.Controls.Add(panel_3);
		tabPage_4.Location = new Point(4, 24);
		tabPage_4.Name = Class16.smethod_0(1648915941);
		tabPage_4.Padding = new Padding(3);
		tabPage_4.Size = new Size(1114, 689);
		tabPage_4.TabIndex = 4;
		tabPage_4.Text = Class16.smethod_0(1648915958);
		tabPage_4.UseVisualStyleBackColor = true;
		dataGridView_2.AllowUserToAddRows = false;
		dataGridView_2.AllowUserToDeleteRows = false;
		dataGridView_2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_2.Columns.AddRange(dataGridViewTextBoxColumn_12, dataGridViewTextBoxColumn_13, dataGridViewTextBoxColumn_14, dataGridViewTextBoxColumn_15);
		dataGridView_2.Dock = DockStyle.Fill;
		dataGridView_2.Location = new Point(3, 39);
		dataGridView_2.MultiSelect = false;
		dataGridView_2.Name = Class16.smethod_0(1648914948);
		dataGridView_2.RowHeadersVisible = false;
		dataGridView_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_2.Size = new Size(1108, 647);
		dataGridView_2.TabIndex = 1;
		dataGridView_2.CellValueChanged += dataGridView_2_CellValueChanged;
		dataGridViewTextBoxColumn_12.FillWeight = 55f;
		dataGridViewTextBoxColumn_12.HeaderText = Class16.smethod_0(1648929947);
		dataGridViewTextBoxColumn_12.Name = Class16.smethod_0(1648914965);
		dataGridViewTextBoxColumn_12.ReadOnly = true;
		dataGridViewTextBoxColumn_13.HeaderText = Class16.smethod_0(1648916453);
		dataGridViewTextBoxColumn_13.Name = Class16.smethod_0(1648914978);
		dataGridViewTextBoxColumn_14.HeaderText = Class16.smethod_0(1648916476);
		dataGridViewTextBoxColumn_14.Name = Class16.smethod_0(1648914995);
		dataGridViewTextBoxColumn_15.HeaderText = Class16.smethod_0(1648915467);
		dataGridViewTextBoxColumn_15.Name = Class16.smethod_0(1648915020);
		panel_3.Controls.Add(button_5);
		panel_3.Controls.Add(button_4);
		panel_3.Dock = DockStyle.Top;
		panel_3.Location = new Point(3, 3);
		panel_3.Name = Class16.smethod_0(1648915037);
		panel_3.Size = new Size(1108, 36);
		panel_3.TabIndex = 0;
		button_4.Location = new Point(6, 6);
		button_4.Name = Class16.smethod_0(1648915061);
		button_4.Size = new Size(102, 24);
		button_4.TabIndex = 0;
		button_4.Text = Class16.smethod_0(1648915072);
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		button_5.Location = new Point(114, 6);
		button_5.Name = Class16.smethod_0(1648915089);
		button_5.Size = new Size(114, 24);
		button_5.TabIndex = 1;
		button_5.Text = Class16.smethod_0(1648915119);
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		tabPage_5.Controls.Add(dataGridView_3);
		tabPage_5.Controls.Add(panel_4);
		tabPage_5.Location = new Point(4, 24);
		tabPage_5.Name = Class16.smethod_0(1648915131);
		tabPage_5.Padding = new Padding(3);
		tabPage_5.Size = new Size(1114, 689);
		tabPage_5.TabIndex = 5;
		tabPage_5.Text = Class16.smethod_0(1648915147);
		tabPage_5.UseVisualStyleBackColor = true;
		dataGridView_3.AllowUserToAddRows = false;
		dataGridView_3.AllowUserToDeleteRows = false;
		dataGridView_3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_3.Columns.AddRange(dataGridViewTextBoxColumn_16, dataGridViewTextBoxColumn_17, dataGridViewTextBoxColumn_18, dataGridViewTextBoxColumn_19, dataGridViewTextBoxColumn_20, dataGridViewTextBoxColumn_21, dataGridViewTextBoxColumn_22);
		dataGridView_3.Dock = DockStyle.Fill;
		dataGridView_3.Location = new Point(3, 39);
		dataGridView_3.MultiSelect = false;
		dataGridView_3.Name = Class16.smethod_0(1648915169);
		dataGridView_3.RowHeadersVisible = false;
		dataGridView_3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_3.Size = new Size(1108, 647);
		dataGridView_3.TabIndex = 1;
		dataGridView_3.CellValueChanged += dataGridView_3_CellValueChanged;
		dataGridViewTextBoxColumn_16.FillWeight = 55f;
		dataGridViewTextBoxColumn_16.HeaderText = Class16.smethod_0(1648929947);
		dataGridViewTextBoxColumn_16.Name = Class16.smethod_0(1648915185);
		dataGridViewTextBoxColumn_16.ReadOnly = true;
		dataGridViewTextBoxColumn_17.HeaderText = Class16.smethod_0(1648941238);
		dataGridViewTextBoxColumn_17.Name = Class16.smethod_0(1648915213);
		dataGridViewTextBoxColumn_18.HeaderText = Class16.smethod_0(1648915231);
		dataGridViewTextBoxColumn_18.Name = Class16.smethod_0(1648915235);
		dataGridViewTextBoxColumn_19.HeaderText = Class16.smethod_0(1648915263);
		dataGridViewTextBoxColumn_19.Name = Class16.smethod_0(1648915279);
		dataGridViewTextBoxColumn_20.HeaderText = Class16.smethod_0(1648915289);
		dataGridViewTextBoxColumn_20.Name = Class16.smethod_0(1648915307);
		dataGridViewTextBoxColumn_21.HeaderText = Class16.smethod_0(1648915335);
		dataGridViewTextBoxColumn_21.Name = Class16.smethod_0(1648915344);
		dataGridViewTextBoxColumn_22.HeaderText = Class16.smethod_0(1648915365);
		dataGridViewTextBoxColumn_22.Name = Class16.smethod_0(1648915382);
		panel_4.Controls.Add(button_7);
		panel_4.Controls.Add(button_6);
		panel_4.Dock = DockStyle.Top;
		panel_4.Location = new Point(3, 3);
		panel_4.Name = Class16.smethod_0(1648915387);
		panel_4.Size = new Size(1108, 36);
		panel_4.TabIndex = 0;
		button_6.Location = new Point(6, 6);
		button_6.Name = Class16.smethod_0(1648915410);
		button_6.Size = new Size(112, 24);
		button_6.TabIndex = 0;
		button_6.Text = Class16.smethod_0(1648915439);
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		button_7.Location = new Point(124, 6);
		button_7.Name = Class16.smethod_0(1648915451);
		button_7.Size = new Size(123, 24);
		button_7.TabIndex = 1;
		button_7.Text = Class16.smethod_0(1648914451);
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		tabPage_6.Controls.Add(splitContainer_1);
		tabPage_6.Location = new Point(4, 24);
		tabPage_6.Name = Class16.smethod_0(1648914474);
		tabPage_6.Padding = new Padding(3);
		tabPage_6.Size = new Size(1114, 689);
		tabPage_6.TabIndex = 6;
		tabPage_6.Text = Class16.smethod_0(1648914501);
		tabPage_6.UseVisualStyleBackColor = true;
		splitContainer_1.Dock = DockStyle.Fill;
		splitContainer_1.Location = new Point(3, 3);
		splitContainer_1.Name = Class16.smethod_0(1648914517);
		splitContainer_1.Panel1.Controls.Add(groupBox_2);
		splitContainer_1.Panel1.Controls.Add(groupBox_1);
		splitContainer_1.Panel2.Controls.Add(groupBox_4);
		splitContainer_1.Panel2.Controls.Add(propertyGrid_2);
		splitContainer_1.Panel2.Controls.Add(groupBox_3);
		splitContainer_1.Size = new Size(1108, 683);
		splitContainer_1.SplitterDistance = 448;
		splitContainer_1.TabIndex = 0;
		groupBox_1.Controls.Add(listBox_1);
		groupBox_1.Controls.Add(panel_5);
		groupBox_1.Dock = DockStyle.Top;
		groupBox_1.Location = new Point(0, 0);
		groupBox_1.Name = Class16.smethod_0(1648914530);
		groupBox_1.Padding = new Padding(6);
		groupBox_1.Size = new Size(448, 246);
		groupBox_1.TabIndex = 0;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1648914558);
		listBox_1.Dock = DockStyle.Fill;
		listBox_1.FormattingEnabled = true;
		listBox_1.ItemHeight = 15;
		listBox_1.Location = new Point(6, 22);
		listBox_1.Name = Class16.smethod_0(1648914568);
		listBox_1.Size = new Size(436, 188);
		listBox_1.TabIndex = 0;
		listBox_1.SelectedIndexChanged += listBox_1_SelectedIndexChanged;
		panel_5.Controls.Add(button_9);
		panel_5.Controls.Add(button_8);
		panel_5.Dock = DockStyle.Bottom;
		panel_5.Location = new Point(6, 210);
		panel_5.Name = Class16.smethod_0(1648914596);
		panel_5.Size = new Size(436, 30);
		panel_5.TabIndex = 1;
		button_8.Location = new Point(3, 3);
		button_8.Name = Class16.smethod_0(1648914609);
		button_8.Size = new Size(84, 24);
		button_8.TabIndex = 0;
		button_8.Text = Class16.smethod_0(1648915992);
		button_8.UseVisualStyleBackColor = true;
		button_8.Click += button_8_Click;
		button_9.Location = new Point(93, 3);
		button_9.Name = Class16.smethod_0(1648914639);
		button_9.Size = new Size(96, 24);
		button_9.TabIndex = 1;
		button_9.Text = Class16.smethod_0(1648916027);
		button_9.UseVisualStyleBackColor = true;
		button_9.Click += button_9_Click;
		groupBox_2.Controls.Add(dataGridView_4);
		groupBox_2.Controls.Add(panel_6);
		groupBox_2.Dock = DockStyle.Fill;
		groupBox_2.Location = new Point(0, 246);
		groupBox_2.Name = Class16.smethod_0(1648914656);
		groupBox_2.Padding = new Padding(6);
		groupBox_2.Size = new Size(448, 437);
		groupBox_2.TabIndex = 1;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1648914685);
		dataGridView_4.AllowUserToAddRows = false;
		dataGridView_4.AllowUserToDeleteRows = false;
		dataGridView_4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView_4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_4.Columns.AddRange(dataGridViewTextBoxColumn_23, dataGridViewTextBoxColumn_24);
		dataGridView_4.Dock = DockStyle.Fill;
		dataGridView_4.Location = new Point(6, 22);
		dataGridView_4.MultiSelect = false;
		dataGridView_4.Name = Class16.smethod_0(1648914697);
		dataGridView_4.RowHeadersVisible = false;
		dataGridView_4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_4.Size = new Size(436, 379);
		dataGridView_4.TabIndex = 0;
		dataGridView_4.CellValueChanged += dataGridView_4_CellValueChanged;
		dataGridViewTextBoxColumn_23.FillWeight = 55f;
		dataGridViewTextBoxColumn_23.HeaderText = Class16.smethod_0(1648929947);
		dataGridViewTextBoxColumn_23.Name = Class16.smethod_0(1648914726);
		dataGridViewTextBoxColumn_23.ReadOnly = true;
		dataGridViewTextBoxColumn_24.HeaderText = Class16.smethod_0(1648914739);
		dataGridViewTextBoxColumn_24.Name = Class16.smethod_0(1648914753);
		panel_6.Controls.Add(button_11);
		panel_6.Controls.Add(button_10);
		panel_6.Dock = DockStyle.Bottom;
		panel_6.Location = new Point(6, 401);
		panel_6.Name = Class16.smethod_0(1648914781);
		panel_6.Size = new Size(436, 30);
		panel_6.TabIndex = 1;
		button_10.Location = new Point(3, 3);
		button_10.Name = Class16.smethod_0(1648914805);
		button_10.Size = new Size(98, 24);
		button_10.TabIndex = 0;
		button_10.Text = Class16.smethod_0(1648914828);
		button_10.UseVisualStyleBackColor = true;
		button_10.Click += button_10_Click;
		button_11.Location = new Point(107, 3);
		button_11.Name = Class16.smethod_0(1648914846);
		button_11.Size = new Size(109, 24);
		button_11.TabIndex = 1;
		button_11.Text = Class16.smethod_0(1648914864);
		button_11.UseVisualStyleBackColor = true;
		button_11.Click += button_11_Click;
		groupBox_3.Controls.Add(listBox_2);
		groupBox_3.Controls.Add(panel_7);
		groupBox_3.Dock = DockStyle.Top;
		groupBox_3.Location = new Point(0, 0);
		groupBox_3.Name = Class16.smethod_0(1648914893);
		groupBox_3.Padding = new Padding(6);
		groupBox_3.Size = new Size(656, 246);
		groupBox_3.TabIndex = 0;
		groupBox_3.TabStop = false;
		groupBox_3.Text = Class16.smethod_0(1648914919);
		listBox_2.Dock = DockStyle.Fill;
		listBox_2.FormattingEnabled = true;
		listBox_2.ItemHeight = 15;
		listBox_2.Location = new Point(6, 22);
		listBox_2.Name = Class16.smethod_0(1648914943);
		listBox_2.Size = new Size(644, 188);
		listBox_2.TabIndex = 0;
		listBox_2.SelectedIndexChanged += listBox_2_SelectedIndexChanged;
		panel_7.Controls.Add(button_13);
		panel_7.Controls.Add(button_12);
		panel_7.Dock = DockStyle.Bottom;
		panel_7.Location = new Point(6, 210);
		panel_7.Name = Class16.smethod_0(1648918033);
		panel_7.Size = new Size(644, 30);
		panel_7.TabIndex = 1;
		button_12.Location = new Point(3, 3);
		button_12.Name = Class16.smethod_0(1648918063);
		button_12.Size = new Size(91, 24);
		button_12.TabIndex = 0;
		button_12.Text = Class16.smethod_0(1648916071);
		button_12.UseVisualStyleBackColor = true;
		button_12.Click += button_12_Click;
		button_13.Location = new Point(100, 3);
		button_13.Name = Class16.smethod_0(1648918086);
		button_13.Size = new Size(103, 24);
		button_13.TabIndex = 1;
		button_13.Text = Class16.smethod_0(1648916108);
		button_13.UseVisualStyleBackColor = true;
		button_13.Click += button_13_Click;
		propertyGrid_2.Dock = DockStyle.Top;
		propertyGrid_2.Location = new Point(0, 246);
		propertyGrid_2.Name = Class16.smethod_0(1648918104);
		propertyGrid_2.Size = new Size(656, 186);
		propertyGrid_2.TabIndex = 1;
		propertyGrid_2.PropertyValueChanged += propertyGrid_2_PropertyValueChanged;
		groupBox_4.Controls.Add(dataGridView_5);
		groupBox_4.Controls.Add(panel_8);
		groupBox_4.Dock = DockStyle.Fill;
		groupBox_4.Location = new Point(0, 432);
		groupBox_4.Name = Class16.smethod_0(1648918132);
		groupBox_4.Padding = new Padding(6);
		groupBox_4.Size = new Size(656, 251);
		groupBox_4.TabIndex = 2;
		groupBox_4.TabStop = false;
		groupBox_4.Text = Class16.smethod_0(1648918156);
		dataGridView_5.AllowUserToAddRows = false;
		dataGridView_5.AllowUserToDeleteRows = false;
		dataGridView_5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView_5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_5.Columns.AddRange(dataGridViewTextBoxColumn_25, dataGridViewTextBoxColumn_26, dataGridViewTextBoxColumn_27, dataGridViewTextBoxColumn_28, dataGridViewTextBoxColumn_29, dataGridViewTextBoxColumn_30);
		dataGridView_5.Dock = DockStyle.Fill;
		dataGridView_5.Location = new Point(6, 22);
		dataGridView_5.MultiSelect = false;
		dataGridView_5.Name = Class16.smethod_0(1648918170);
		dataGridView_5.RowHeadersVisible = false;
		dataGridView_5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_5.Size = new Size(644, 193);
		dataGridView_5.TabIndex = 0;
		dataGridView_5.CellValueChanged += dataGridView_5_CellValueChanged;
		dataGridViewTextBoxColumn_25.FillWeight = 55f;
		dataGridViewTextBoxColumn_25.HeaderText = Class16.smethod_0(1648929947);
		dataGridViewTextBoxColumn_25.Name = Class16.smethod_0(1648918194);
		dataGridViewTextBoxColumn_25.ReadOnly = true;
		dataGridViewTextBoxColumn_26.HeaderText = Class16.smethod_0(1648918221);
		dataGridViewTextBoxColumn_26.Name = Class16.smethod_0(1648918236);
		dataGridViewTextBoxColumn_27.HeaderText = Class16.smethod_0(1648918249);
		dataGridViewTextBoxColumn_27.Name = Class16.smethod_0(1648918264);
		dataGridViewTextBoxColumn_28.HeaderText = Class16.smethod_0(1648918293);
		dataGridViewTextBoxColumn_28.Name = Class16.smethod_0(1648918308);
		dataGridViewTextBoxColumn_29.HeaderText = Class16.smethod_0(1648918321);
		dataGridViewTextBoxColumn_29.Name = Class16.smethod_0(1648918336);
		dataGridViewTextBoxColumn_30.HeaderText = Class16.smethod_0(1648918366);
		dataGridViewTextBoxColumn_30.Name = Class16.smethod_0(1648918370);
		panel_8.Controls.Add(button_15);
		panel_8.Controls.Add(button_14);
		panel_8.Dock = DockStyle.Bottom;
		panel_8.Location = new Point(6, 215);
		panel_8.Name = Class16.smethod_0(1648918397);
		panel_8.Size = new Size(644, 30);
		panel_8.TabIndex = 1;
		button_14.Location = new Point(3, 3);
		button_14.Name = Class16.smethod_0(1648918411);
		button_14.Size = new Size(84, 24);
		button_14.TabIndex = 0;
		button_14.Text = Class16.smethod_0(1648918436);
		button_14.UseVisualStyleBackColor = true;
		button_14.Click += button_14_Click;
		button_15.Location = new Point(93, 3);
		button_15.Name = Class16.smethod_0(1648918443);
		button_15.Size = new Size(96, 24);
		button_15.TabIndex = 1;
		button_15.Text = Class16.smethod_0(1648918471);
		button_15.UseVisualStyleBackColor = true;
		button_15.Click += button_15_Click;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1438, 822);
		base.Controls.Add(splitContainer_0);
		base.Controls.Add(panel_0);
		base.Controls.Add(statusStrip_0);
		base.Controls.Add(toolStrip_0);
		base.Controls.Add(menuStrip_0);
		base.MainMenuStrip = menuStrip_0;
		MinimumSize = new Size(1180, 700);
		base.Name = Class16.smethod_0(1648918481);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648918497);
		base.FormClosing += BmdEditor_FormClosing;
		base.Activated += BmdEditor_Activated;
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		toolStrip_0.ResumeLayout(performLayout: false);
		toolStrip_0.PerformLayout();
		statusStrip_0.ResumeLayout(performLayout: false);
		statusStrip_0.PerformLayout();
		panel_0.ResumeLayout(performLayout: false);
		panel_0.PerformLayout();
		splitContainer_0.Panel1.ResumeLayout(performLayout: false);
		splitContainer_0.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_0).EndInit();
		splitContainer_0.ResumeLayout(performLayout: false);
		groupBox_0.ResumeLayout(performLayout: false);
		tabControl_0.ResumeLayout(performLayout: false);
		tabPage_0.ResumeLayout(performLayout: false);
		tabPage_1.ResumeLayout(performLayout: false);
		tabPage_2.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_0).EndInit();
		panel_1.ResumeLayout(performLayout: false);
		tabPage_3.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_1).EndInit();
		panel_2.ResumeLayout(performLayout: false);
		tabPage_4.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_2).EndInit();
		panel_3.ResumeLayout(performLayout: false);
		tabPage_5.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_3).EndInit();
		panel_4.ResumeLayout(performLayout: false);
		tabPage_6.ResumeLayout(performLayout: false);
		splitContainer_1.Panel1.ResumeLayout(performLayout: false);
		splitContainer_1.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_1).EndInit();
		splitContainer_1.ResumeLayout(performLayout: false);
		groupBox_1.ResumeLayout(performLayout: false);
		panel_5.ResumeLayout(performLayout: false);
		groupBox_2.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_4).EndInit();
		panel_6.ResumeLayout(performLayout: false);
		groupBox_3.ResumeLayout(performLayout: false);
		panel_7.ResumeLayout(performLayout: false);
		groupBox_4.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_5).EndInit();
		panel_8.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void method_11()
	{
		if (Data != null)
		{
			method_34();
			BMD.BmdMesh item = method_13();
			Data.Meshes.Add(item);
			method_1();
			if (listBox_0.Items.Count > 0)
			{
				listBox_0.SelectedIndex = listBox_0.Items.Count - 1;
			}
			method_5();
			method_4(Class16.smethod_0(1648917507));
		}
	}

	private void method_12()
	{
		if (Data?.Meshes == null)
		{
			return;
		}
		int selectedIndex = listBox_0.SelectedIndex;
		if (selectedIndex >= 0 && selectedIndex < Data.Meshes.Count)
		{
			method_34();
			Data.Meshes.RemoveAt(selectedIndex);
			method_1();
			if (listBox_0.Items.Count > 0)
			{
				listBox_0.SelectedIndex = Math.Min(selectedIndex, listBox_0.Items.Count - 1);
			}
			else
			{
				method_15();
			}
			method_5();
			method_4(Class16.smethod_0(1648917532));
		}
	}

	private BMD.BmdMesh method_13()
	{
		bool flag = Data == null || Data.LitModelVersion >= 268436224;
		BMD.BmdMesh bmdMesh = new BMD.BmdMesh();
		bmdMesh.IsNewFormat = flag;
		bmdMesh.MeshVersion = (flag ? 268435462u : 268435462u);
		bmdMesh.Name = string.Format(Class16.smethod_0(1648917551), (Data?.Meshes?.Count).GetValueOrDefault() + 1);
		bmdMesh.TexturePath = string.Empty;
		bmdMesh.SupportLightMap = false;
		bmdMesh.UseLightMap = false;
		bmdMesh.HasExtraColorsFlag = !flag;
		bmdMesh.ExtraColorsFlag = 0;
		return bmdMesh;
	}

	private void method_14()
	{
		bool_0 = true;
		try
		{
			BMD.BmdMesh bmdMesh = method_6();
			propertyGrid_1.SelectedObject = bmdMesh;
			if (bmdMesh == null)
			{
				method_15();
				return;
			}
			method_17(bmdMesh);
			method_18(bmdMesh);
			method_19(bmdMesh);
			method_20(bmdMesh);
			method_21(bmdMesh);
			method_16(bmdMesh);
		}
		finally
		{
			bool_0 = false;
		}
		method_22();
		method_24();
	}

	private void method_15()
	{
		propertyGrid_1.SelectedObject = null;
		dataGridView_0.Rows.Clear();
		dataGridView_1.Rows.Clear();
		dataGridView_2.Rows.Clear();
		dataGridView_3.Rows.Clear();
	}

	private static string smethod_0(uint uint_0)
	{
		return string.Format(Class16.smethod_0(1648917566), uint_0);
	}

	private void method_16(BMD.BmdMesh bmdMesh_0)
	{
		bool visible = false;
		for (int i = 0; i < bmdMesh_0.Vertices.Count; i++)
		{
			if (bmdMesh_0.Vertices[i].HasSpecular)
			{
				visible = true;
				break;
			}
		}
		dataGridView_0.Columns[Class16.smethod_0(1648915548)].Visible = visible;
		dataGridView_3.Columns[Class16.smethod_0(1648915213)].Visible = bmdMesh_0.DayColors.Count > 0 || !bmdMesh_0.SupportLightMap || !bmdMesh_0.UseLightMap;
		dataGridView_3.Columns[Class16.smethod_0(1648915235)].Visible = bmdMesh_0.NightColors.Count > 0 || !bmdMesh_0.SupportLightMap || !bmdMesh_0.UseLightMap;
		dataGridView_3.Columns[Class16.smethod_0(1648915279)].Visible = bmdMesh_0.DayColorsExtra.Count > 0 || bmdMesh_0.ExtraColorsFlag == 1;
		dataGridView_3.Columns[Class16.smethod_0(1648915307)].Visible = bmdMesh_0.NightColorsExtra.Count > 0 || bmdMesh_0.ExtraColorsFlag == 1;
		dataGridView_3.Columns[Class16.smethod_0(1648915344)].Visible = bmdMesh_0.SupportLightMap;
		dataGridView_3.Columns[Class16.smethod_0(1648915382)].Visible = bmdMesh_0.SupportLightMap;
	}

	private void method_17(BMD.BmdMesh bmdMesh_0)
	{
		int count = bmdMesh_0.Vertices.Count;
		while (bmdMesh_0.Normals.Count < count)
		{
			bmdMesh_0.Normals.Add(new BMD.Vector3Value());
		}
		while (bmdMesh_0.DayColors.Count < count)
		{
			bmdMesh_0.DayColors.Add(0u);
		}
		while (bmdMesh_0.NightColors.Count < count)
		{
			bmdMesh_0.NightColors.Add(0u);
		}
		while (bmdMesh_0.DayColorsExtra.Count < count)
		{
			bmdMesh_0.DayColorsExtra.Add(0u);
		}
		while (bmdMesh_0.NightColorsExtra.Count < count)
		{
			bmdMesh_0.NightColorsExtra.Add(0u);
		}
		while (bmdMesh_0.LightTexCoords.Count < count)
		{
			bmdMesh_0.LightTexCoords.Add(new BMD.LightMapCoord());
		}
	}

	private void method_18(BMD.BmdMesh bmdMesh_0)
	{
		dataGridView_0.Rows.Clear();
		for (int i = 0; i < bmdMesh_0.Vertices.Count; i++)
		{
			BMD.BmdVertex bmdVertex = bmdMesh_0.Vertices[i];
			dataGridView_0.Rows.Add(i, bmdVertex.Single_0, bmdVertex.Single_1, bmdVertex.Single_2, smethod_0(bmdVertex.Diffuse), smethod_0(bmdVertex.Specular), bmdVertex.Single_3, bmdVertex.Single_4);
		}
	}

	private void method_19(BMD.BmdMesh bmdMesh_0)
	{
		dataGridView_1.Rows.Clear();
		for (int i = 0; i < bmdMesh_0.Faces.Count; i++)
		{
			BMD.FaceShort faceShort = bmdMesh_0.Faces[i];
			dataGridView_1.Rows.Add(i, faceShort.Int16_0, faceShort.Int16_1, faceShort.Int16_2);
		}
	}

	private void method_20(BMD.BmdMesh bmdMesh_0)
	{
		dataGridView_2.Rows.Clear();
		for (int i = 0; i < bmdMesh_0.Normals.Count; i++)
		{
			BMD.Vector3Value vector3Value = bmdMesh_0.Normals[i];
			dataGridView_2.Rows.Add(i, vector3Value.Single_0, vector3Value.Single_1, vector3Value.Single_2);
		}
	}

	private void method_21(BMD.BmdMesh bmdMesh_0)
	{
		dataGridView_3.Rows.Clear();
		int count = bmdMesh_0.Vertices.Count;
		for (int i = 0; i < count; i++)
		{
			uint uint_ = ((i < bmdMesh_0.DayColors.Count) ? bmdMesh_0.DayColors[i] : 0u);
			uint uint_2 = ((i < bmdMesh_0.NightColors.Count) ? bmdMesh_0.NightColors[i] : 0u);
			uint uint_3 = ((i < bmdMesh_0.DayColorsExtra.Count) ? bmdMesh_0.DayColorsExtra[i] : 0u);
			uint uint_4 = ((i < bmdMesh_0.NightColorsExtra.Count) ? bmdMesh_0.NightColorsExtra[i] : 0u);
			BMD.LightMapCoord lightMapCoord = ((i < bmdMesh_0.LightTexCoords.Count) ? bmdMesh_0.LightTexCoords[i] : new BMD.LightMapCoord());
			dataGridView_3.Rows.Add(i, smethod_0(uint_), smethod_0(uint_2), smethod_0(uint_3), smethod_0(uint_4), lightMapCoord.Single_0, lightMapCoord.Single_1);
		}
	}

	private void method_22()
	{
		bool_0 = true;
		try
		{
			int selectedIndex = listBox_1.SelectedIndex;
			listBox_1.Items.Clear();
			if (Data?.HullMeshes != null)
			{
				for (int i = 0; i < Data.HullMeshes.Count; i++)
				{
					listBox_1.Items.Add(string.Format(Class16.smethod_0(1648921583), i, Data.HullMeshes[i]));
				}
			}
			if (listBox_1.Items.Count > 0)
			{
				listBox_1.SelectedIndex = ((selectedIndex >= 0 && selectedIndex < listBox_1.Items.Count) ? selectedIndex : 0);
			}
			else
			{
				dataGridView_4.Rows.Clear();
			}
		}
		finally
		{
			bool_0 = false;
		}
	}

	private void method_23()
	{
		dataGridView_4.Rows.Clear();
		if (Data?.HullMeshes == null)
		{
			return;
		}
		int selectedIndex = listBox_1.SelectedIndex;
		if (selectedIndex >= 0 && selectedIndex < Data.HullMeshes.Count)
		{
			BMD.HullMesh hullMesh = Data.HullMeshes[selectedIndex];
			for (int i = 0; i < hullMesh.MeshIds.Count; i++)
			{
				dataGridView_4.Rows.Add(i, hullMesh.MeshIds[i]);
			}
		}
	}

	private void method_24()
	{
		bool_0 = true;
		try
		{
			int selectedIndex = listBox_2.SelectedIndex;
			listBox_2.Items.Clear();
			if (Data?.CollisionBrushes != null)
			{
				for (int i = 0; i < Data.CollisionBrushes.Count; i++)
				{
					listBox_2.Items.Add(string.Format(Class16.smethod_0(1648921583), i, Data.CollisionBrushes[i]));
				}
			}
			if (listBox_2.Items.Count > 0)
			{
				listBox_2.SelectedIndex = ((selectedIndex >= 0 && selectedIndex < listBox_2.Items.Count) ? selectedIndex : 0);
				return;
			}
			propertyGrid_2.SelectedObject = null;
			dataGridView_5.Rows.Clear();
		}
		finally
		{
			bool_0 = false;
		}
	}

	private void method_25()
	{
		dataGridView_5.Rows.Clear();
		propertyGrid_2.SelectedObject = null;
		if (Data?.CollisionBrushes == null)
		{
			return;
		}
		int selectedIndex = listBox_2.SelectedIndex;
		if (selectedIndex >= 0 && selectedIndex < Data.CollisionBrushes.Count)
		{
			BMD.CollisionBrush collisionBrush = Data.CollisionBrushes[selectedIndex];
			propertyGrid_2.SelectedObject = collisionBrush;
			for (int i = 0; i < collisionBrush.Sides.Count; i++)
			{
				BMD.CollisionSide collisionSide = collisionBrush.Sides[i];
				dataGridView_5.Rows.Add(i, collisionSide.Normal.Single_0, collisionSide.Normal.Single_1, collisionSide.Normal.Single_2, collisionSide.Distance, collisionSide.Bevel);
			}
		}
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		if (Data != null)
		{
			method_34();
			Data.HullMeshes.Add(new BMD.HullMesh());
			method_22();
			if (listBox_1.Items.Count > 0)
			{
				listBox_1.SelectedIndex = listBox_1.Items.Count - 1;
			}
			method_5();
			method_3();
		}
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		if (Data?.HullMeshes == null)
		{
			return;
		}
		int selectedIndex = listBox_1.SelectedIndex;
		if (selectedIndex >= 0 && selectedIndex < Data.HullMeshes.Count)
		{
			method_34();
			Data.HullMeshes.RemoveAt(selectedIndex);
			if (Data.CollisionBrushes != null && selectedIndex < Data.CollisionBrushes.Count)
			{
				Data.CollisionBrushes.RemoveAt(selectedIndex);
			}
			method_22();
			method_24();
			method_5();
			method_3();
		}
	}

	private void button_12_Click(object sender, EventArgs e)
	{
		if (Data != null)
		{
			method_34();
			Data.CollisionBrushes.Add(new BMD.CollisionBrush());
			method_24();
			if (listBox_2.Items.Count > 0)
			{
				listBox_2.SelectedIndex = listBox_2.Items.Count - 1;
			}
			method_5();
			method_3();
		}
	}

	private void button_13_Click(object sender, EventArgs e)
	{
		if (Data?.CollisionBrushes != null)
		{
			int selectedIndex = listBox_2.SelectedIndex;
			if (selectedIndex >= 0 && selectedIndex < Data.CollisionBrushes.Count)
			{
				method_34();
				Data.CollisionBrushes.RemoveAt(selectedIndex);
				method_24();
				method_5();
				method_3();
			}
		}
	}

	private void listBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_23();
			method_3();
		}
	}

	private void listBox_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_25();
			method_3();
		}
	}

	private void BmdEditor_Activated(object sender, EventArgs e)
	{
		method_26();
	}

	private void method_26()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_BmdEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this, null);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_BmdEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void method_27()
	{
		if (Data == null)
		{
			return;
		}
		using SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = Class16.smethod_0(1648920644);
		saveFileDialog.FileName = (string.IsNullOrWhiteSpace(Data.fn) ? Class16.smethod_0(1648920693) : System.IO.Path.GetFileName(Data.fn));
		if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			try
			{
				Data.Save(saveFileDialog.FileName);
				textBox_0.Text = Data.fn;
				method_3();
				method_2();
				method_4(Class16.smethod_0(1648920709) + System.IO.Path.GetFileName(Data.fn));
				return;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648917581));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648917602), Class16.smethod_0(1648920771)), ex.Message), Class16.smethod_0(1648920801), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		method_8();
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		method_9();
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_27();
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		method_8();
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		method_9();
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		method_11();
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		method_12();
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_14();
			method_3();
		}
	}

	private void propertyGrid_0_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		if (!bool_0 && Data != null)
		{
			method_37(propertyGrid_0);
			method_5();
			method_1();
			method_14();
			method_36(propertyGrid_0);
		}
	}

	private void propertyGrid_1_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		if (!bool_0)
		{
			method_37(propertyGrid_1);
			method_1();
			method_14();
			method_5();
			method_36(propertyGrid_1);
		}
	}

	private void propertyGrid_2_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		if (!bool_0)
		{
			method_37(propertyGrid_2);
			method_24();
			method_5();
			method_36(propertyGrid_2);
		}
	}

	private void BmdEditor_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (Data != null && Data.FileChanged)
		{
			switch (DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648917633)), TextStorage.Msg(Class16.smethod_0(1648917659), Class16.smethod_0(1648921454)), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
			case DialogResult.Cancel:
				e.Cancel = true;
				break;
			case DialogResult.Yes:
				method_9();
				break;
			}
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh != null)
		{
			method_34();
			BMD.BmdVertex bmdVertex = new BMD.BmdVertex();
			bmdVertex.HasSpecular = bmdMesh.MeshVersion <= 268435459 && !bmdMesh.IsNewFormat;
			bmdMesh.Vertices.Add(bmdVertex);
			method_17(bmdMesh);
			method_14();
			if (dataGridView_0.Rows.Count > 0)
			{
				dataGridView_0.CurrentCell = dataGridView_0[1, dataGridView_0.Rows.Count - 1];
			}
			method_5();
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh != null && dataGridView_0.SelectedRows.Count != 0)
		{
			int index = dataGridView_0.SelectedRows[0].Index;
			if (index >= 0 && index < bmdMesh.Vertices.Count)
			{
				method_34();
				bmdMesh.Vertices.RemoveAt(index);
				smethod_1(bmdMesh.Normals, index);
				smethod_1(bmdMesh.DayColors, index);
				smethod_1(bmdMesh.NightColors, index);
				smethod_1(bmdMesh.DayColorsExtra, index);
				smethod_1(bmdMesh.NightColorsExtra, index);
				smethod_1(bmdMesh.LightTexCoords, index);
				method_14();
				method_5();
			}
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh != null)
		{
			method_34();
			bmdMesh.Faces.Add(new BMD.FaceShort());
			if (bmdMesh.HasFaceNormals || (Data != null && Data.LitModelVersion >= 268436226))
			{
				bmdMesh.HasFaceNormals = true;
				bmdMesh.FaceNormals.Add(new BMD.FaceShort());
			}
			method_14();
			method_5();
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh != null && dataGridView_1.SelectedRows.Count != 0)
		{
			int index = dataGridView_1.SelectedRows[0].Index;
			if (index >= 0 && index < bmdMesh.Faces.Count)
			{
				method_34();
				bmdMesh.Faces.RemoveAt(index);
				smethod_1(bmdMesh.FaceNormals, index);
				method_14();
				method_5();
			}
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh != null)
		{
			method_34();
			bmdMesh.Normals.Add(new BMD.Vector3Value());
			method_14();
			method_5();
		}
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh != null && dataGridView_2.SelectedRows.Count != 0)
		{
			int index = dataGridView_2.SelectedRows[0].Index;
			if (index >= 0 && index < bmdMesh.Normals.Count)
			{
				method_34();
				bmdMesh.Normals.RemoveAt(index);
				method_14();
				method_5();
			}
		}
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh != null)
		{
			method_34();
			bmdMesh.DayColors.Add(0u);
			bmdMesh.NightColors.Add(0u);
			bmdMesh.DayColorsExtra.Add(0u);
			bmdMesh.NightColorsExtra.Add(0u);
			bmdMesh.LightTexCoords.Add(new BMD.LightMapCoord());
			method_14();
			method_5();
		}
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh != null && dataGridView_3.SelectedRows.Count != 0)
		{
			int index = dataGridView_3.SelectedRows[0].Index;
			method_34();
			smethod_1(bmdMesh.DayColors, index);
			smethod_1(bmdMesh.NightColors, index);
			smethod_1(bmdMesh.DayColorsExtra, index);
			smethod_1(bmdMesh.NightColorsExtra, index);
			smethod_1(bmdMesh.LightTexCoords, index);
			method_14();
			method_5();
		}
	}

	private static void smethod_1<T>(List<T> list_0, int int_0)
	{
		if (list_0 != null && int_0 >= 0 && int_0 < list_0.Count)
		{
			list_0.RemoveAt(int_0);
		}
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		if (Data?.HullMeshes != null)
		{
			int selectedIndex = listBox_1.SelectedIndex;
			if (selectedIndex >= 0 && selectedIndex < Data.HullMeshes.Count)
			{
				method_34();
				Data.HullMeshes[selectedIndex].MeshIds.Add(0);
				method_23();
				method_5();
				method_22();
			}
		}
	}

	private void button_11_Click(object sender, EventArgs e)
	{
		if (Data?.HullMeshes == null || dataGridView_4.SelectedRows.Count == 0)
		{
			return;
		}
		int selectedIndex = listBox_1.SelectedIndex;
		if (selectedIndex >= 0 && selectedIndex < Data.HullMeshes.Count)
		{
			int index = dataGridView_4.SelectedRows[0].Index;
			if (index >= 0 && index < Data.HullMeshes[selectedIndex].MeshIds.Count)
			{
				method_34();
				Data.HullMeshes[selectedIndex].MeshIds.RemoveAt(index);
				method_23();
				method_5();
				method_22();
			}
		}
	}

	private void button_14_Click(object sender, EventArgs e)
	{
		if (Data?.CollisionBrushes != null)
		{
			int selectedIndex = listBox_2.SelectedIndex;
			if (selectedIndex >= 0 && selectedIndex < Data.CollisionBrushes.Count)
			{
				method_34();
				Data.CollisionBrushes[selectedIndex].Sides.Add(new BMD.CollisionSide());
				method_25();
				method_5();
				method_24();
			}
		}
	}

	private void button_15_Click(object sender, EventArgs e)
	{
		if (Data?.CollisionBrushes == null || dataGridView_5.SelectedRows.Count == 0)
		{
			return;
		}
		int selectedIndex = listBox_2.SelectedIndex;
		if (selectedIndex >= 0 && selectedIndex < Data.CollisionBrushes.Count)
		{
			int index = dataGridView_5.SelectedRows[0].Index;
			if (index >= 0 && index < Data.CollisionBrushes[selectedIndex].Sides.Count)
			{
				method_34();
				Data.CollisionBrushes[selectedIndex].Sides.RemoveAt(index);
				method_25();
				method_5();
				method_24();
			}
		}
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.RowIndex < 0)
		{
			return;
		}
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh == null || e.RowIndex >= bmdMesh.Vertices.Count)
		{
			return;
		}
		method_37(dataGridView_0);
		BMD.BmdVertex bmdVertex = bmdMesh.Vertices[e.RowIndex];
		string name = dataGridView_0.Columns[e.ColumnIndex].Name;
		object value = dataGridView_0[e.ColumnIndex, e.RowIndex].Value;
		if (name != null)
		{
			switch (name.Length)
			{
			case 15:
				if (name == Class16.smethod_0(1648915548))
				{
					bmdVertex.Specular = smethod_7(value, bmdVertex.Specular);
					dataGridView_0[e.ColumnIndex, e.RowIndex].Value = smethod_0(bmdVertex.Specular);
				}
				break;
			case 14:
				if (name == Class16.smethod_0(1648915504))
				{
					bmdVertex.Diffuse = smethod_7(value, bmdVertex.Diffuse);
					dataGridView_0[e.ColumnIndex, e.RowIndex].Value = smethod_0(bmdVertex.Diffuse);
				}
				break;
			case 8:
				switch (name[7])
				{
				case 'U':
					if (name == Class16.smethod_0(1648915570))
					{
						bmdVertex.Single_3 = smethod_6(value, bmdVertex.Single_3);
					}
					break;
				case 'V':
					if (name == Class16.smethod_0(1648915593))
					{
						bmdVertex.Single_4 = smethod_6(value, bmdVertex.Single_4);
					}
					break;
				case 'X':
					if (name == Class16.smethod_0(1648916461))
					{
						bmdVertex.Single_0 = smethod_6(value, bmdVertex.Single_0);
					}
					break;
				case 'Y':
					if (name == Class16.smethod_0(1648915460))
					{
						bmdVertex.Single_1 = smethod_6(value, bmdVertex.Single_1);
					}
					break;
				case 'Z':
					if (name == Class16.smethod_0(1648915475))
					{
						bmdVertex.Single_2 = smethod_6(value, bmdVertex.Single_2);
					}
					break;
				}
				break;
			}
		}
		bmdMesh.Vertices[e.RowIndex] = bmdVertex;
		method_5();
	}

	private void dataGridView_1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.RowIndex < 0)
		{
			return;
		}
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh == null || e.RowIndex >= bmdMesh.Faces.Count)
		{
			return;
		}
		method_37(dataGridView_1);
		BMD.FaceShort faceShort = bmdMesh.Faces[e.RowIndex];
		string name = dataGridView_1.Columns[e.ColumnIndex].Name;
		object value = dataGridView_1[e.ColumnIndex, e.RowIndex].Value;
		if (!(name == Class16.smethod_0(1648915788)))
		{
			if (!(name == Class16.smethod_0(1648915803)))
			{
				if (name == Class16.smethod_0(1648915826))
				{
					faceShort.Int16_2 = smethod_4(value, faceShort.Int16_2);
				}
			}
			else
			{
				faceShort.Int16_1 = smethod_4(value, faceShort.Int16_1);
			}
		}
		else
		{
			faceShort.Int16_0 = smethod_4(value, faceShort.Int16_0);
		}
		bmdMesh.Faces[e.RowIndex] = faceShort;
		method_5();
	}

	private void dataGridView_2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.RowIndex < 0)
		{
			return;
		}
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh == null || e.RowIndex >= bmdMesh.Normals.Count)
		{
			return;
		}
		method_37(dataGridView_2);
		BMD.Vector3Value vector3Value = bmdMesh.Normals[e.RowIndex];
		string name = dataGridView_2.Columns[e.ColumnIndex].Name;
		object value = dataGridView_2[e.ColumnIndex, e.RowIndex].Value;
		if (!(name == Class16.smethod_0(1648914978)))
		{
			if (!(name == Class16.smethod_0(1648914995)))
			{
				if (name == Class16.smethod_0(1648915020))
				{
					vector3Value.Single_2 = smethod_6(value, vector3Value.Single_2);
				}
			}
			else
			{
				vector3Value.Single_1 = smethod_6(value, vector3Value.Single_1);
			}
		}
		else
		{
			vector3Value.Single_0 = smethod_6(value, vector3Value.Single_0);
		}
		bmdMesh.Normals[e.RowIndex] = vector3Value;
		method_5();
	}

	private void dataGridView_3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.RowIndex < 0)
		{
			return;
		}
		BMD.BmdMesh bmdMesh = method_6();
		if (bmdMesh == null)
		{
			return;
		}
		method_37(dataGridView_3);
		smethod_2(bmdMesh, e.RowIndex + 1);
		string name = dataGridView_3.Columns[e.ColumnIndex].Name;
		object value = dataGridView_3[e.ColumnIndex, e.RowIndex].Value;
		if (!(name == Class16.smethod_0(1648915213)))
		{
			if (!(name == Class16.smethod_0(1648915235)))
			{
				if (!(name == Class16.smethod_0(1648915279)))
				{
					if (!(name == Class16.smethod_0(1648915307)))
					{
						if (!(name == Class16.smethod_0(1648915344)))
						{
							if (name == Class16.smethod_0(1648915382))
							{
								bmdMesh.LightTexCoords[e.RowIndex].Single_1 = smethod_6(value, bmdMesh.LightTexCoords[e.RowIndex].Single_1);
							}
						}
						else
						{
							bmdMesh.LightTexCoords[e.RowIndex].Single_0 = smethod_6(value, bmdMesh.LightTexCoords[e.RowIndex].Single_0);
						}
					}
					else
					{
						bmdMesh.NightColorsExtra[e.RowIndex] = smethod_7(value, bmdMesh.NightColorsExtra[e.RowIndex]);
						dataGridView_3[e.ColumnIndex, e.RowIndex].Value = smethod_0(bmdMesh.NightColorsExtra[e.RowIndex]);
					}
				}
				else
				{
					bmdMesh.DayColorsExtra[e.RowIndex] = smethod_7(value, bmdMesh.DayColorsExtra[e.RowIndex]);
					dataGridView_3[e.ColumnIndex, e.RowIndex].Value = smethod_0(bmdMesh.DayColorsExtra[e.RowIndex]);
				}
			}
			else
			{
				bmdMesh.NightColors[e.RowIndex] = smethod_7(value, bmdMesh.NightColors[e.RowIndex]);
				dataGridView_3[e.ColumnIndex, e.RowIndex].Value = smethod_0(bmdMesh.NightColors[e.RowIndex]);
			}
		}
		else
		{
			bmdMesh.DayColors[e.RowIndex] = smethod_7(value, bmdMesh.DayColors[e.RowIndex]);
			dataGridView_3[e.ColumnIndex, e.RowIndex].Value = smethod_0(bmdMesh.DayColors[e.RowIndex]);
		}
		method_5();
	}

	private void dataGridView_4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.RowIndex < 0 || e.ColumnIndex < 0 || Data?.HullMeshes == null)
		{
			return;
		}
		int selectedIndex = listBox_1.SelectedIndex;
		if (selectedIndex >= 0 && selectedIndex < Data.HullMeshes.Count && e.RowIndex < Data.HullMeshes[selectedIndex].MeshIds.Count)
		{
			method_37(dataGridView_4);
			string name = dataGridView_4.Columns[e.ColumnIndex].Name;
			if (!(name != Class16.smethod_0(1648914753)))
			{
				int value = smethod_3(dataGridView_4[e.ColumnIndex, e.RowIndex].Value, Data.HullMeshes[selectedIndex].MeshIds[e.RowIndex]);
				Data.HullMeshes[selectedIndex].MeshIds[e.RowIndex] = value;
				method_5();
				method_22();
			}
		}
	}

	private void dataGridView_5_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_0 || e.RowIndex < 0 || e.ColumnIndex < 0 || Data?.CollisionBrushes == null)
		{
			return;
		}
		int selectedIndex = listBox_2.SelectedIndex;
		if (selectedIndex < 0 || selectedIndex >= Data.CollisionBrushes.Count || e.RowIndex >= Data.CollisionBrushes[selectedIndex].Sides.Count)
		{
			return;
		}
		method_37(dataGridView_5);
		BMD.CollisionSide collisionSide = Data.CollisionBrushes[selectedIndex].Sides[e.RowIndex];
		string name = dataGridView_5.Columns[e.ColumnIndex].Name;
		object value = dataGridView_5[e.ColumnIndex, e.RowIndex].Value;
		if (!(name == Class16.smethod_0(1648918236)))
		{
			if (!(name == Class16.smethod_0(1648918264)))
			{
				if (!(name == Class16.smethod_0(1648918308)))
				{
					if (!(name == Class16.smethod_0(1648918336)))
					{
						if (name == Class16.smethod_0(1648918370))
						{
							collisionSide.Bevel = smethod_5(value, collisionSide.Bevel);
						}
					}
					else
					{
						collisionSide.Distance = smethod_6(value, collisionSide.Distance);
					}
				}
				else
				{
					collisionSide.Normal.Single_2 = smethod_6(value, collisionSide.Normal.Single_2);
				}
			}
			else
			{
				collisionSide.Normal.Single_1 = smethod_6(value, collisionSide.Normal.Single_1);
			}
		}
		else
		{
			collisionSide.Normal.Single_0 = smethod_6(value, collisionSide.Normal.Single_0);
		}
		Data.CollisionBrushes[selectedIndex].Sides[e.RowIndex] = collisionSide;
		method_5();
	}

	private static void smethod_2(BMD.BmdMesh bmdMesh_0, int int_0)
	{
		while (bmdMesh_0.DayColors.Count < int_0)
		{
			bmdMesh_0.DayColors.Add(0u);
		}
		while (bmdMesh_0.NightColors.Count < int_0)
		{
			bmdMesh_0.NightColors.Add(0u);
		}
		while (bmdMesh_0.DayColorsExtra.Count < int_0)
		{
			bmdMesh_0.DayColorsExtra.Add(0u);
		}
		while (bmdMesh_0.NightColorsExtra.Count < int_0)
		{
			bmdMesh_0.NightColorsExtra.Add(0u);
		}
		while (bmdMesh_0.LightTexCoords.Count < int_0)
		{
			bmdMesh_0.LightTexCoords.Add(new BMD.LightMapCoord());
		}
	}

	private static int smethod_3(object object_0, int int_0)
	{
		string s = Convert.ToString(object_0, CultureInfo.InvariantCulture);
		if (!int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return int_0;
		}
		return result;
	}

	private static short smethod_4(object object_0, short short_0)
	{
		string s = Convert.ToString(object_0, CultureInfo.InvariantCulture);
		if (!short.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return short_0;
		}
		return result;
	}

	private static byte smethod_5(object object_0, byte byte_1)
	{
		string s = Convert.ToString(object_0, CultureInfo.InvariantCulture);
		if (!byte.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return byte_1;
		}
		return result;
	}

	private static float smethod_6(object object_0, float float_0)
	{
		string s = Convert.ToString(object_0, CultureInfo.InvariantCulture);
		if (!float.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var result))
		{
			return float_0;
		}
		return result;
	}

	private static uint smethod_7(object object_0, uint uint_0)
	{
		string text = Convert.ToString(object_0, CultureInfo.InvariantCulture);
		if (string.IsNullOrWhiteSpace(text))
		{
			return uint_0;
		}
		text = text.Trim();
		bool flag = text.StartsWith(Class16.smethod_0(1648917675), StringComparison.OrdinalIgnoreCase) || Regex.IsMatch(text, Class16.smethod_0(1648917692));
		if (text.StartsWith(Class16.smethod_0(1648917675), StringComparison.OrdinalIgnoreCase))
		{
			text = text.Substring(2);
		}
		if (flag)
		{
			if (!uint.TryParse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
			{
				return uint_0;
			}
			return result;
		}
		if (!uint.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2))
		{
			return uint_0;
		}
		return result2;
	}

	private void method_28()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1648921454), 100);
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_31, method_32);
		fileBasedUndoManager_0.AttachToToolStrip(toolStrip_0, method_39, method_40);
		method_29();
	}

	private void method_29()
	{
		method_30(dataGridView_0);
		method_30(dataGridView_1);
		method_30(dataGridView_2);
		method_30(dataGridView_3);
		method_30(dataGridView_4);
		method_30(dataGridView_5);
		propertyGrid_0.Enter += propertyGrid_0_Enter;
		propertyGrid_0.MouseDown += propertyGrid_0_MouseDown;
		propertyGrid_0.Leave += propertyGrid_0_Leave;
		propertyGrid_1.Enter += propertyGrid_1_Enter;
		propertyGrid_1.MouseDown += propertyGrid_1_MouseDown;
		propertyGrid_1.Leave += propertyGrid_1_Leave;
		propertyGrid_2.Enter += propertyGrid_2_Enter;
		propertyGrid_2.MouseDown += propertyGrid_2_MouseDown;
		propertyGrid_2.Leave += propertyGrid_2_Leave;
	}

	private void method_30(DataGridView dataGridView_6)
	{
		Class50 @class = new Class50();
		@class.bmdEditor_0 = this;
		@class.dataGridView_0 = dataGridView_6;
		@class.dataGridView_0.CellBeginEdit += @class.method_0;
		@class.dataGridView_0.Leave += @class.method_1;
	}

	private byte[] method_31()
	{
		if (Data == null)
		{
			return null;
		}
		try
		{
			string text = System.IO.Path.Combine(System.IO.Path.GetTempPath(), string.Format(Class16.smethod_0(1648917699), Guid.NewGuid()));
			try
			{
				string fn = Data.fn;
				Data.Save(text);
				Data.fn = fn;
				byte[] array = File.ReadAllBytes(text);
				MemoryStream memoryStream = new MemoryStream();
				try
				{
					BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
					try
					{
						binaryWriter.Write(fn ?? string.Empty);
						binaryWriter.Write(Data.FileLoaded);
						binaryWriter.Write(Data.FileChanged);
						binaryWriter.Write(array.Length);
						binaryWriter.Write(array);
						binaryWriter.Write(listBox_0.SelectedIndex);
						binaryWriter.Write(listBox_1.SelectedIndex);
						binaryWriter.Write(listBox_2.SelectedIndex);
						binaryWriter.Write(tabControl_0.SelectedIndex);
						binaryWriter.Write(dataGridView_0.CurrentRow?.Index ?? (-1));
						binaryWriter.Write(dataGridView_1.CurrentRow?.Index ?? (-1));
						binaryWriter.Write(dataGridView_2.CurrentRow?.Index ?? (-1));
						binaryWriter.Write(dataGridView_3.CurrentRow?.Index ?? (-1));
						binaryWriter.Write(dataGridView_4.CurrentRow?.Index ?? (-1));
						binaryWriter.Write(dataGridView_5.CurrentRow?.Index ?? (-1));
						binaryWriter.Flush();
						return memoryStream.ToArray();
					}
					finally
					{
						((IDisposable)binaryWriter).Dispose();
					}
				}
				finally
				{
					((IDisposable)memoryStream).Dispose();
				}
			}
			finally
			{
				try
				{
					File.Delete(text);
				}
				catch
				{
				}
			}
		}
		catch
		{
			return null;
		}
	}

	private void method_32(byte[] byte_1)
	{
		if (byte_1 == null || byte_1.Length == 0)
		{
			return;
		}
		bool_1 = true;
		string text = null;
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_1);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					string fn = binaryReader.ReadString();
					bool fileLoaded = binaryReader.ReadBoolean();
					bool fileChanged = binaryReader.ReadBoolean();
					int count = binaryReader.ReadInt32();
					byte[] bytes = binaryReader.ReadBytes(count);
					int int_ = binaryReader.ReadInt32();
					int int_2 = binaryReader.ReadInt32();
					int int_3 = binaryReader.ReadInt32();
					int int_4 = binaryReader.ReadInt32();
					int int_5 = binaryReader.ReadInt32();
					int int_6 = binaryReader.ReadInt32();
					int int_7 = binaryReader.ReadInt32();
					int int_8 = binaryReader.ReadInt32();
					int int_9 = binaryReader.ReadInt32();
					int int_10 = binaryReader.ReadInt32();
					text = System.IO.Path.Combine(System.IO.Path.GetTempPath(), string.Format(Class16.smethod_0(1648917699), Guid.NewGuid()));
					File.WriteAllBytes(text, bytes);
					Data = new BMD(text);
					Data.fn = fn;
					Data.FileLoaded = fileLoaded;
					Data.FileChanged = fileChanged;
					method_0();
					method_33(int_, int_2, int_3, int_4, int_5, int_6, int_7, int_8, int_9, int_10);
					method_3();
					method_2();
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		finally
		{
			bool_1 = false;
			method_38(null);
			if (text != null)
			{
				try
				{
					File.Delete(text);
				}
				catch
				{
				}
			}
		}
	}

	private void method_33(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7, int int_8, int int_9)
	{
		if (tabControl_0.TabPages.Count > 0)
		{
			tabControl_0.SelectedIndex = smethod_9(int_3, tabControl_0.TabPages.Count);
		}
		if (listBox_0.Items.Count > 0)
		{
			listBox_0.SelectedIndex = smethod_9(int_0, listBox_0.Items.Count);
		}
		if (listBox_1.Items.Count > 0)
		{
			listBox_1.SelectedIndex = smethod_9(int_1, listBox_1.Items.Count);
		}
		if (listBox_2.Items.Count > 0)
		{
			listBox_2.SelectedIndex = smethod_9(int_2, listBox_2.Items.Count);
		}
		smethod_8(dataGridView_0, int_4, 1);
		smethod_8(dataGridView_1, int_5, 1);
		smethod_8(dataGridView_2, int_6, 1);
		smethod_8(dataGridView_3, int_7, 1);
		smethod_8(dataGridView_4, int_8, 1);
		smethod_8(dataGridView_5, int_9, 1);
	}

	private static void smethod_8(DataGridView dataGridView_6, int int_0, int int_1)
	{
		if (dataGridView_6.Rows.Count != 0 && dataGridView_6.ColumnCount != 0)
		{
			int num = smethod_9(int_0, dataGridView_6.Rows.Count);
			int columnIndex = Math.Min(int_1, dataGridView_6.ColumnCount - 1);
			dataGridView_6.ClearSelection();
			dataGridView_6.CurrentCell = dataGridView_6[columnIndex, num];
			dataGridView_6.Rows[num].Selected = true;
		}
	}

	private static int smethod_9(int int_0, int int_1)
	{
		if (int_1 <= 0)
		{
			return -1;
		}
		if (int_0 < 0)
		{
			return 0;
		}
		return Math.Min(int_0, int_1 - 1);
	}

	private void method_34()
	{
		if (!bool_1 && Data != null)
		{
			byte[] array = method_31();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
			method_38(null);
		}
	}

	private void method_35()
	{
		method_38(null);
		fileBasedUndoManager_0?.Clear();
	}

	private void method_36(Control control_1)
	{
		if (!bool_1 && control_1 != null && Data != null && control_0 != control_1)
		{
			control_0 = control_1;
			byte_0 = method_31();
		}
	}

	private void method_37(Control control_1)
	{
		if (!bool_1 && control_1 != null && control_0 == control_1 && byte_0 != null)
		{
			fileBasedUndoManager_0?.PushUndo(byte_0);
			method_38(control_1);
		}
	}

	private void method_38(Control control_1)
	{
		if (control_1 == null || control_0 == control_1)
		{
			control_0 = null;
			byte_0 = null;
		}
	}

	private void method_39(object sender, EventArgs e)
	{
		byte[] currentState = method_31();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_32(array);
		}
	}

	private void method_40(object sender, EventArgs e)
	{
		byte[] currentState = method_31();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_32(array);
		}
	}

	private void propertyGrid_0_Enter(object sender, EventArgs e)
	{
		method_36(propertyGrid_0);
	}

	private void propertyGrid_0_MouseDown(object sender, MouseEventArgs e)
	{
		method_36(propertyGrid_0);
	}

	private void propertyGrid_0_Leave(object sender, EventArgs e)
	{
		method_38(propertyGrid_0);
	}

	private void propertyGrid_1_Enter(object sender, EventArgs e)
	{
		method_36(propertyGrid_1);
	}

	private void propertyGrid_1_MouseDown(object sender, MouseEventArgs e)
	{
		method_36(propertyGrid_1);
	}

	private void propertyGrid_1_Leave(object sender, EventArgs e)
	{
		method_38(propertyGrid_1);
	}

	private void propertyGrid_2_Enter(object sender, EventArgs e)
	{
		method_36(propertyGrid_2);
	}

	private void propertyGrid_2_MouseDown(object sender, MouseEventArgs e)
	{
		method_36(propertyGrid_2);
	}

	private void propertyGrid_2_Leave(object sender, EventArgs e)
	{
		method_38(propertyGrid_2);
	}
}
