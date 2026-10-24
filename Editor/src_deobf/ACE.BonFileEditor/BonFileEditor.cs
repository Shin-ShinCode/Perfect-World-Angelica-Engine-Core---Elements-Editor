using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.RSGlobal;
using Sentry;

namespace ACE.BonFileEditor;

public class BonFileEditor : Form
{
	[Serializable]
	private sealed class Class51
	{
		public static readonly Class51 class51_0 = new Class51();

		public static Func<DataGridViewRow, int> func_0;

		public static Func<int, int> func_1;

		public static Func<DataGridViewRow, int> func_2;

		public static Func<int, int> func_3;

		public static Func<DataGridViewRow, int> func_4;

		public static Func<int, int> func_5;

		internal int method_0(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_1(int int_0)
		{
			return int_0;
		}

		internal int method_2(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_3(int int_0)
		{
			return int_0;
		}

		internal int method_4(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_5(int int_0)
		{
			return int_0;
		}
	}

	private Client client_0;

	public ClientFinder Cf;

	public ClientWindow SelectedWindow;

	public bool Running;

	private BonFile bonFile_0;

	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private int int_0 = -1;

	private IContainer icontainer_0;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripLabel toolStripLabel_0;

	private ToolStripTextBox toolStripTextBox_0;

	private ToolStripButton toolStripButton_2;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripButton toolStripButton_3;

	private ToolStripButton toolStripButton_4;

	private StatusStrip statusStrip_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private ToolStripStatusLabel toolStripStatusLabel_1;

	private ToolStripStatusLabel toolStripStatusLabel_2;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private Label label_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private Label label_1;

	private TextBox textBox_2;

	private Label label_2;

	private TextBox textBox_3;

	private Label label_3;

	private TextBox textBox_4;

	private Label label_4;

	private TextBox textBox_5;

	private Label label_5;

	private TextBox textBox_6;

	private TextBox textBox_7;

	private TextBox textBox_8;

	private TextBox textBox_9;

	private DataGridView dataGridView_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private TextBox textBox_10;

	private Label label_6;

	private TextBox textBox_11;

	private Label label_7;

	private TextBox textBox_12;

	private Label label_8;

	private TextBox textBox_13;

	private Label label_9;

	private TextBox textBox_14;

	private Label label_10;

	private TextBox textBox_15;

	private TextBox textBox_16;

	private TextBox textBox_17;

	private TextBox textBox_18;

	private TextBox textBox_19;

	private TextBox textBox_20;

	private TextBox textBox_21;

	private TextBox textBox_22;

	private TextBox textBox_23;

	private TextBox textBox_24;

	private TextBox textBox_25;

	private TextBox textBox_26;

	private TableLayoutPanel tableLayoutPanel_0;

	private ToolStripMenuItem toolStripMenuItem_2;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TabPage tabPage_1;

	private DataGridView dataGridView_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private TabPage tabPage_2;

	private DataGridView dataGridView_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private Label label_11;

	private Label label_12;

	private TextBox textBox_27;

	private TextBox textBox_28;

	private Label label_13;

	private TextBox textBox_29;

	private TextBox textBox_30;

	private Label label_14;

	private TabPage tabPage_3;

	private TextBox textBox_31;

	private Label label_15;

	private Label label_16;

	private Label label_17;

	private TextBox textBox_32;

	private TextBox textBox_33;

	private DataGridView dataGridView_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private TextBox textBox_34;

	private TextBox textBox_35;

	private TextBox textBox_36;

	private TextBox textBox_37;

	private TextBox textBox_38;

	private TextBox textBox_39;

	private TextBox textBox_40;

	private TextBox textBox_41;

	private TextBox textBox_42;

	private TextBox textBox_43;

	private TextBox textBox_44;

	private TextBox textBox_45;

	private TextBox textBox_46;

	private TextBox textBox_47;

	private TextBox textBox_48;

	private TextBox textBox_49;

	private GroupBox groupBox_0;

	private TextBox textBox_50;

	private TextBox textBox_51;

	private TextBox textBox_52;

	private TextBox textBox_53;

	private TextBox textBox_54;

	private TextBox textBox_55;

	private TextBox textBox_56;

	private TextBox textBox_57;

	private TextBox textBox_58;

	private TextBox textBox_59;

	private TextBox textBox_60;

	private TextBox textBox_61;

	private TextBox textBox_62;

	private TextBox textBox_63;

	private TextBox textBox_64;

	private TextBox textBox_65;

	private ComboBox comboBox_0;

	private Button button_0;

	private TrackBar trackBar_0;

	private TrackBar trackBar_1;

	private TrackBar trackBar_2;

	private TrackBar trackBar_3;

	private TrackBar trackBar_4;

	private TrackBar trackBar_5;

	private TrackBar trackBar_6;

	private TrackBar trackBar_7;

	private TrackBar trackBar_8;

	private TrackBar trackBar_9;

	private TrackBar trackBar_10;

	private TrackBar trackBar_11;

	private TrackBar trackBar_12;

	private TrackBar trackBar_13;

	private TrackBar trackBar_14;

	private TrackBar trackBar_15;

	private GroupBox groupBox_1;

	private Label label_18;

	private ComboBox comboBox_1;

	private ToolStripMenuItem toolStripMenuItem_3;

	private Panel panel_0;

	private TableLayoutPanel tableLayoutPanel_1;

	private TableLayoutPanel tableLayoutPanel_2;

	private TableLayoutPanel tableLayoutPanel_3;

	private TableLayoutPanel tableLayoutPanel_4;

	public BonFileEditor()
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		method_4(Class16.smethod_0(1648917924));
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.FileName = Class16.smethod_0(1648917960);
		openFileDialog.Filter = Class16.smethod_0(1648917983);
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			bonFile_0 = new BonFile(openFileDialog.FileName);
			string_0 = openFileDialog.FileName;
			string_1 = string.Empty;
			int_0 = -1;
			Text = openFileDialog.FileName + Class16.smethod_0(1648918011) + bonFile_0.Version + Class16.smethod_0(1648917001);
			textBox_0.Text = bonFile_0.count.ToString();
			textBox_1.Text = bonFile_0.count2.ToString();
			textBox_2.Text = bonFile_0.count3.ToString();
			textBox_3.Text = bonFile_0.unknown0.ToString();
			textBox_5.Text = bonFile_0.unknown.ToString();
			textBox_4.Text = bonFile_0.spacecontrol.ToString();
			dataGridView_0.Rows.Clear();
			dataGridView_1.Rows.Clear();
			dataGridView_3.Rows.Clear();
			for (int i = 0; i < bonFile_0.FirstStages.Count; i++)
			{
				dataGridView_0.Rows.Add(bonFile_0.FirstStages[i].BoneName);
			}
			for (int j = 0; j < bonFile_0.SecondStagesAlt.Count; j++)
			{
				dataGridView_2.Rows.Add(bonFile_0.SecondStagesAlt[j].BoneName);
			}
			for (int k = 0; k < bonFile_0.GfxAnimations.Count; k++)
			{
				dataGridView_3.Rows.Add(bonFile_0.GfxAnimations[k].BoneName);
			}
			comboBox_1.Enabled = true;
			method_4(Class16.smethod_0(1648917029));
		}
		catch (InvalidDataException ex)
		{
			SentryHelper.CaptureMessage(Class16.smethod_0(1648917054) + ex.Message, (SentryLevel)2, Class16.smethod_0(1648917072));
			DKBox.Show(Class16.smethod_0(1648917113) + ex.Message, Class16.smethod_0(1648917205), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		catch (EndOfStreamException ex2)
		{
			SentryHelper.CaptureMessage(Class16.smethod_0(1648917218) + ex2.Message, (SentryLevel)2, Class16.smethod_0(1648917253));
			DKBox.Show(Class16.smethod_0(1648917294) + ex2.Message, Class16.smethod_0(1648917205), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		catch (Exception ex3)
		{
			SentryHelper.CaptureException(ex3, Class16.smethod_0(1648917381));
			DKBox.Show(Class16.smethod_0(1648917402) + ex3.Message, Class16.smethod_0(1648917205), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		if (bonFile_0 != null)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = Class16.smethod_0(1648917960);
			saveFileDialog.Filter = Class16.smethod_0(1648917983);
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				bonFile_0.Save(saveFileDialog.FileName, bonFile_0.Version);
				string_0 = saveFileDialog.FileName;
				method_4(Class16.smethod_0(1648917442));
			}
		}
	}

	private void dataGridView_0_CurrentCellChanged(object sender, EventArgs e)
	{
		if (bonFile_0 != null && bonFile_0.FirstStages != null)
		{
			if (dataGridView_0.CurrentRow == null)
			{
				method_4(null);
				return;
			}
			if (dataGridView_0.CurrentRow.Index == -1)
			{
				method_4(null);
				return;
			}
			int index = dataGridView_0.CurrentRow.Index;
			if (index >= 0 && index < bonFile_0.FirstStages.Count)
			{
				textBox_10.Text = bonFile_0.FirstStages[index].BoneName;
				textBox_14.Text = bonFile_0.FirstStages[index].ID[0].ToString();
				textBox_13.Text = bonFile_0.FirstStages[index].ID[1].ToString();
				textBox_11.Text = bonFile_0.FirstStages[index].Extras.Count.ToString();
				textBox_12.Text = bonFile_0.FirstStages[index].Extras2.ToString();
				textBox_9.Text = bonFile_0.FirstStages[index].Points[0].decimal_0.ToString();
				textBox_26.Text = bonFile_0.FirstStages[index].Points[1].decimal_0.ToString();
				textBox_22.Text = bonFile_0.FirstStages[index].Points[2].decimal_0.ToString();
				textBox_18.Text = bonFile_0.FirstStages[index].Points[3].decimal_0.ToString();
				textBox_45.Text = bonFile_0.FirstStages[index].Points[4].decimal_0.ToString();
				textBox_41.Text = bonFile_0.FirstStages[index].Points[5].decimal_0.ToString();
				textBox_39.Text = bonFile_0.FirstStages[index].Points[6].decimal_0.ToString();
				textBox_37.Text = bonFile_0.FirstStages[index].Points[7].decimal_0.ToString();
				textBox_8.Text = bonFile_0.FirstStages[index].Points[0].decimal_1.ToString();
				textBox_25.Text = bonFile_0.FirstStages[index].Points[1].decimal_1.ToString();
				textBox_21.Text = bonFile_0.FirstStages[index].Points[2].decimal_1.ToString();
				textBox_17.Text = bonFile_0.FirstStages[index].Points[3].decimal_1.ToString();
				textBox_44.Text = bonFile_0.FirstStages[index].Points[4].decimal_1.ToString();
				textBox_40.Text = bonFile_0.FirstStages[index].Points[5].decimal_1.ToString();
				textBox_38.Text = bonFile_0.FirstStages[index].Points[6].decimal_1.ToString();
				textBox_36.Text = bonFile_0.FirstStages[index].Points[7].decimal_1.ToString();
				textBox_7.Text = bonFile_0.FirstStages[index].Points[0].decimal_2.ToString();
				textBox_24.Text = bonFile_0.FirstStages[index].Points[1].decimal_2.ToString();
				textBox_20.Text = bonFile_0.FirstStages[index].Points[2].decimal_2.ToString();
				textBox_16.Text = bonFile_0.FirstStages[index].Points[3].decimal_2.ToString();
				textBox_43.Text = bonFile_0.FirstStages[index].Points[4].decimal_2.ToString();
				textBox_47.Text = bonFile_0.FirstStages[index].Points[5].decimal_2.ToString();
				textBox_48.Text = bonFile_0.FirstStages[index].Points[6].decimal_2.ToString();
				textBox_35.Text = bonFile_0.FirstStages[index].Points[7].decimal_2.ToString();
				textBox_6.Text = bonFile_0.FirstStages[index].unknown0.ToString();
				textBox_23.Text = bonFile_0.FirstStages[index].unknown1.ToString();
				textBox_19.Text = bonFile_0.FirstStages[index].unknown2.ToString();
				textBox_15.Text = bonFile_0.FirstStages[index].unknown3.ToString();
				textBox_42.Text = bonFile_0.FirstStages[index].unknown4.ToString();
				textBox_46.Text = bonFile_0.FirstStages[index].unknown5.ToString();
				textBox_49.Text = bonFile_0.FirstStages[index].unknown6.ToString();
				textBox_34.Text = bonFile_0.FirstStages[index].unknown7.ToString();
				method_4(null);
			}
			else
			{
				method_4(null);
			}
		}
		else
		{
			method_4(null);
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
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(BonFileEditor));
		toolStrip_0 = new ToolStrip();
		toolStripButton_0 = new ToolStripButton();
		toolStripButton_1 = new ToolStripButton();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripLabel_0 = new ToolStripLabel();
		toolStripTextBox_0 = new ToolStripTextBox();
		toolStripButton_2 = new ToolStripButton();
		toolStripSeparator_1 = new ToolStripSeparator();
		toolStripButton_3 = new ToolStripButton();
		toolStripButton_4 = new ToolStripButton();
		statusStrip_0 = new StatusStrip();
		toolStripStatusLabel_0 = new ToolStripStatusLabel();
		toolStripStatusLabel_1 = new ToolStripStatusLabel();
		toolStripStatusLabel_2 = new ToolStripStatusLabel();
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		label_0 = new Label();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		label_1 = new Label();
		textBox_2 = new TextBox();
		label_2 = new Label();
		textBox_3 = new TextBox();
		label_3 = new Label();
		textBox_4 = new TextBox();
		label_4 = new Label();
		textBox_5 = new TextBox();
		label_5 = new Label();
		panel_0 = new Panel();
		tableLayoutPanel_1 = new TableLayoutPanel();
		tableLayoutPanel_2 = new TableLayoutPanel();
		tableLayoutPanel_3 = new TableLayoutPanel();
		tableLayoutPanel_4 = new TableLayoutPanel();
		groupBox_1 = new GroupBox();
		label_18 = new Label();
		comboBox_1 = new ComboBox();
		button_0 = new Button();
		comboBox_0 = new ComboBox();
		tableLayoutPanel_0 = new TableLayoutPanel();
		textBox_7 = new TextBox();
		textBox_34 = new TextBox();
		textBox_9 = new TextBox();
		textBox_35 = new TextBox();
		textBox_36 = new TextBox();
		textBox_8 = new TextBox();
		textBox_37 = new TextBox();
		textBox_6 = new TextBox();
		textBox_24 = new TextBox();
		textBox_26 = new TextBox();
		textBox_38 = new TextBox();
		textBox_25 = new TextBox();
		textBox_39 = new TextBox();
		textBox_23 = new TextBox();
		textBox_20 = new TextBox();
		textBox_22 = new TextBox();
		textBox_40 = new TextBox();
		textBox_21 = new TextBox();
		textBox_41 = new TextBox();
		textBox_19 = new TextBox();
		textBox_42 = new TextBox();
		textBox_16 = new TextBox();
		textBox_43 = new TextBox();
		textBox_44 = new TextBox();
		textBox_45 = new TextBox();
		textBox_18 = new TextBox();
		textBox_17 = new TextBox();
		textBox_15 = new TextBox();
		textBox_46 = new TextBox();
		textBox_47 = new TextBox();
		textBox_48 = new TextBox();
		textBox_49 = new TextBox();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		textBox_12 = new TextBox();
		label_8 = new Label();
		textBox_13 = new TextBox();
		label_9 = new Label();
		textBox_14 = new TextBox();
		textBox_11 = new TextBox();
		label_7 = new Label();
		textBox_10 = new TextBox();
		label_6 = new Label();
		label_10 = new Label();
		tabControl_0 = new TabControl();
		tabPage_0 = new TabPage();
		tabPage_1 = new TabPage();
		dataGridView_1 = new DataGridView();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		tabPage_2 = new TabPage();
		textBox_30 = new TextBox();
		label_14 = new Label();
		label_11 = new Label();
		label_12 = new Label();
		textBox_27 = new TextBox();
		textBox_28 = new TextBox();
		label_13 = new Label();
		textBox_29 = new TextBox();
		dataGridView_2 = new DataGridView();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		tabPage_3 = new TabPage();
		trackBar_7 = new TrackBar();
		trackBar_8 = new TrackBar();
		trackBar_9 = new TrackBar();
		trackBar_10 = new TrackBar();
		trackBar_11 = new TrackBar();
		trackBar_4 = new TrackBar();
		trackBar_5 = new TrackBar();
		trackBar_6 = new TrackBar();
		trackBar_1 = new TrackBar();
		trackBar_2 = new TrackBar();
		trackBar_3 = new TrackBar();
		trackBar_0 = new TrackBar();
		groupBox_0 = new GroupBox();
		trackBar_12 = new TrackBar();
		trackBar_13 = new TrackBar();
		trackBar_14 = new TrackBar();
		trackBar_15 = new TrackBar();
		textBox_50 = new TextBox();
		textBox_51 = new TextBox();
		textBox_52 = new TextBox();
		textBox_53 = new TextBox();
		textBox_54 = new TextBox();
		textBox_55 = new TextBox();
		textBox_56 = new TextBox();
		textBox_57 = new TextBox();
		textBox_58 = new TextBox();
		textBox_59 = new TextBox();
		textBox_60 = new TextBox();
		textBox_61 = new TextBox();
		textBox_62 = new TextBox();
		textBox_63 = new TextBox();
		textBox_64 = new TextBox();
		textBox_65 = new TextBox();
		textBox_31 = new TextBox();
		label_15 = new Label();
		label_17 = new Label();
		textBox_32 = new TextBox();
		textBox_33 = new TextBox();
		dataGridView_3 = new DataGridView();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		label_16 = new Label();
		toolStrip_0.SuspendLayout();
		statusStrip_0.SuspendLayout();
		menuStrip_0.SuspendLayout();
		panel_0.SuspendLayout();
		tableLayoutPanel_1.SuspendLayout();
		tableLayoutPanel_2.SuspendLayout();
		tableLayoutPanel_3.SuspendLayout();
		tableLayoutPanel_4.SuspendLayout();
		groupBox_1.SuspendLayout();
		tableLayoutPanel_0.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		tabControl_0.SuspendLayout();
		tabPage_0.SuspendLayout();
		tabPage_1.SuspendLayout();
		((ISupportInitialize)dataGridView_1).BeginInit();
		tabPage_2.SuspendLayout();
		((ISupportInitialize)dataGridView_2).BeginInit();
		tabPage_3.SuspendLayout();
		((ISupportInitialize)trackBar_7).BeginInit();
		((ISupportInitialize)trackBar_8).BeginInit();
		((ISupportInitialize)trackBar_9).BeginInit();
		((ISupportInitialize)trackBar_10).BeginInit();
		((ISupportInitialize)trackBar_11).BeginInit();
		((ISupportInitialize)trackBar_4).BeginInit();
		((ISupportInitialize)trackBar_5).BeginInit();
		((ISupportInitialize)trackBar_6).BeginInit();
		((ISupportInitialize)trackBar_1).BeginInit();
		((ISupportInitialize)trackBar_2).BeginInit();
		((ISupportInitialize)trackBar_3).BeginInit();
		((ISupportInitialize)trackBar_0).BeginInit();
		groupBox_0.SuspendLayout();
		((ISupportInitialize)trackBar_12).BeginInit();
		((ISupportInitialize)trackBar_13).BeginInit();
		((ISupportInitialize)trackBar_14).BeginInit();
		((ISupportInitialize)trackBar_15).BeginInit();
		((ISupportInitialize)dataGridView_3).BeginInit();
		SuspendLayout();
		toolStrip_0.Items.AddRange(new ToolStripItem[9] { toolStripButton_0, toolStripButton_1, toolStripSeparator_0, toolStripLabel_0, toolStripTextBox_0, toolStripButton_2, toolStripSeparator_1, toolStripButton_3, toolStripButton_4 });
		toolStrip_0.Location = new Point(0, 24);
		toolStrip_0.Name = Class16.smethod_0(1648920933);
		toolStrip_0.Size = new Size(1332, 25);
		toolStrip_0.TabIndex = 19;
		toolStrip_0.Text = Class16.smethod_0(1648917466);
		toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_0.Name = Class16.smethod_0(1648917493);
		toolStripButton_0.Size = new Size(40, 22);
		toolStripButton_0.Text = Class16.smethod_0(1648931498);
		toolStripButton_0.Click += toolStripButton_0_Click;
		toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_1.Name = Class16.smethod_0(1648916495);
		toolStripButton_1.Size = new Size(35, 22);
		toolStripButton_1.Text = Class16.smethod_0(1648941761);
		toolStripButton_1.Click += toolStripButton_1_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1648920981);
		toolStripSeparator_0.Size = new Size(6, 25);
		toolStripLabel_0.Name = Class16.smethod_0(1648916513);
		toolStripLabel_0.Size = new Size(33, 22);
		toolStripLabel_0.Text = Class16.smethod_0(1648916538);
		toolStripTextBox_0.Name = Class16.smethod_0(1648916558);
		toolStripTextBox_0.Size = new Size(160, 25);
		toolStripTextBox_0.ToolTipText = Class16.smethod_0(1648916579);
		toolStripTextBox_0.KeyDown += toolStripTextBox_0_KeyDown;
		toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_2.Name = Class16.smethod_0(1648916621);
		toolStripButton_2.Size = new Size(64, 22);
		toolStripButton_2.Text = Class16.smethod_0(1648916643);
		toolStripButton_2.Click += toolStripButton_2_Click;
		toolStripSeparator_1.Name = Class16.smethod_0(1648921077);
		toolStripSeparator_1.Size = new Size(6, 25);
		toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_3.Name = Class16.smethod_0(1648916659);
		toolStripButton_3.Size = new Size(86, 22);
		toolStripButton_3.Text = Class16.smethod_0(1648916703);
		toolStripButton_3.Click += toolStripButton_3_Click;
		toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_4.Name = Class16.smethod_0(1648916725);
		toolStripButton_4.Size = new Size(72, 22);
		toolStripButton_4.Text = Class16.smethod_0(1648916756);
		toolStripButton_4.Click += toolStripButton_4_Click;
		statusStrip_0.Items.AddRange(new ToolStripItem[3] { toolStripStatusLabel_0, toolStripStatusLabel_1, toolStripStatusLabel_2 });
		statusStrip_0.Location = new Point(0, 585);
		statusStrip_0.Name = Class16.smethod_0(1648916127);
		statusStrip_0.Size = new Size(1332, 22);
		statusStrip_0.TabIndex = 20;
		statusStrip_0.Text = Class16.smethod_0(1648916773);
		toolStripStatusLabel_0.Name = Class16.smethod_0(1648916778);
		toolStripStatusLabel_0.Size = new Size(72, 17);
		toolStripStatusLabel_0.Text = Class16.smethod_0(1648916792);
		toolStripStatusLabel_1.Name = Class16.smethod_0(1648916811);
		toolStripStatusLabel_1.Size = new Size(1133, 17);
		toolStripStatusLabel_1.Spring = true;
		toolStripStatusLabel_1.Text = Class16.smethod_0(1648916838);
		toolStripStatusLabel_2.Name = Class16.smethod_0(1648916880);
		toolStripStatusLabel_2.Size = new Size(112, 17);
		toolStripStatusLabel_2.Text = Class16.smethod_0(1648916902);
		menuStrip_0.Items.AddRange(new ToolStripItem[2] { toolStripMenuItem_0, toolStripMenuItem_3 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1648931410);
		menuStrip_0.Size = new Size(1332, 24);
		menuStrip_0.TabIndex = 0;
		menuStrip_0.Text = Class16.smethod_0(1648931410);
		toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem_1, toolStripMenuItem_2 });
		toolStripMenuItem_0.Name = Class16.smethod_0(1648916926);
		toolStripMenuItem_0.Size = new Size(37, 20);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_1.Name = Class16.smethod_0(1648916946);
		toolStripMenuItem_1.ShortcutKeys = Keys.O | Keys.Control;
		toolStripMenuItem_1.Size = new Size(146, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648916975);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_2.Name = Class16.smethod_0(1648916978);
		toolStripMenuItem_2.ShortcutKeys = Keys.S | Keys.Control;
		toolStripMenuItem_2.Size = new Size(146, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.Enabled = false;
		toolStripMenuItem_3.Name = Class16.smethod_0(1648911887);
		toolStripMenuItem_3.Size = new Size(245, 20);
		toolStripMenuItem_3.Text = Class16.smethod_0(1648911961);
		label_0.AutoSize = true;
		label_0.Dock = DockStyle.Fill;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_0.Location = new Point(3, 0);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(298, 25);
		label_0.TabIndex = 1;
		label_0.Text = Class16.smethod_0(1648912021);
		label_0.TextAlign = ContentAlignment.MiddleCenter;
		textBox_0.Dock = DockStyle.Fill;
		textBox_0.Location = new Point(3, 28);
		textBox_0.Name = Class16.smethod_0(1648912046);
		textBox_0.ReadOnly = true;
		textBox_0.Size = new Size(298, 20);
		textBox_0.TabIndex = 2;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		textBox_1.Dock = DockStyle.Fill;
		textBox_1.Location = new Point(307, 28);
		textBox_1.Name = Class16.smethod_0(1648912068);
		textBox_1.ReadOnly = true;
		textBox_1.Size = new Size(298, 20);
		textBox_1.TabIndex = 4;
		textBox_1.TextAlign = HorizontalAlignment.Center;
		label_1.AutoSize = true;
		label_1.Dock = DockStyle.Fill;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_1.Location = new Point(307, 0);
		label_1.Name = Class16.smethod_0(1648912083);
		label_1.Size = new Size(298, 25);
		label_1.TabIndex = 3;
		label_1.Text = Class16.smethod_0(1648912096);
		label_1.TextAlign = ContentAlignment.MiddleCenter;
		textBox_2.Dock = DockStyle.Fill;
		textBox_2.Location = new Point(611, 28);
		textBox_2.Name = Class16.smethod_0(1648912122);
		textBox_2.ReadOnly = true;
		textBox_2.Size = new Size(298, 20);
		textBox_2.TabIndex = 6;
		textBox_2.TextAlign = HorizontalAlignment.Center;
		label_2.AutoSize = true;
		label_2.Dock = DockStyle.Fill;
		label_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_2.Location = new Point(611, 0);
		label_2.Name = Class16.smethod_0(1648912145);
		label_2.Size = new Size(298, 25);
		label_2.TabIndex = 5;
		label_2.Text = Class16.smethod_0(1648912166);
		label_2.TextAlign = ContentAlignment.MiddleCenter;
		textBox_3.Dock = DockStyle.Fill;
		textBox_3.Location = new Point(3, 28);
		textBox_3.Name = Class16.smethod_0(1648912191);
		textBox_3.ReadOnly = true;
		textBox_3.Size = new Size(298, 20);
		textBox_3.TabIndex = 8;
		textBox_3.TextAlign = HorizontalAlignment.Center;
		label_3.AutoSize = true;
		label_3.Dock = DockStyle.Fill;
		label_3.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_3.Location = new Point(3, 0);
		label_3.Name = Class16.smethod_0(1648912200);
		label_3.Size = new Size(298, 25);
		label_3.TabIndex = 7;
		label_3.Text = Class16.smethod_0(1648912221);
		label_3.TextAlign = ContentAlignment.MiddleCenter;
		textBox_4.Dock = DockStyle.Fill;
		textBox_4.Location = new Point(307, 28);
		textBox_4.Name = Class16.smethod_0(1648912237);
		textBox_4.ReadOnly = true;
		textBox_4.Size = new Size(298, 20);
		textBox_4.TabIndex = 10;
		textBox_4.TextAlign = HorizontalAlignment.Center;
		label_4.AutoSize = true;
		label_4.Dock = DockStyle.Fill;
		label_4.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_4.Location = new Point(307, 0);
		label_4.Name = Class16.smethod_0(1648912262);
		label_4.Size = new Size(298, 25);
		label_4.TabIndex = 9;
		label_4.Text = Class16.smethod_0(1648912267);
		label_4.TextAlign = ContentAlignment.MiddleCenter;
		textBox_5.Dock = DockStyle.Fill;
		textBox_5.Location = new Point(611, 28);
		textBox_5.Name = Class16.smethod_0(1648912288);
		textBox_5.ReadOnly = true;
		textBox_5.Size = new Size(298, 20);
		textBox_5.TabIndex = 12;
		textBox_5.TextAlign = HorizontalAlignment.Center;
		label_5.AutoSize = true;
		label_5.Dock = DockStyle.Fill;
		label_5.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_5.Location = new Point(611, 0);
		label_5.Name = Class16.smethod_0(1648930240);
		label_5.Size = new Size(298, 25);
		label_5.TabIndex = 11;
		label_5.Text = Class16.smethod_0(1648912305);
		label_5.TextAlign = ContentAlignment.MiddleCenter;
		panel_0.Controls.Add(tableLayoutPanel_1);
		panel_0.Dock = DockStyle.Top;
		panel_0.Location = new Point(0, 49);
		panel_0.Name = Class16.smethod_0(1648912321);
		panel_0.Padding = new Padding(6);
		panel_0.Size = new Size(1332, 130);
		panel_0.TabIndex = 18;
		tableLayoutPanel_1.ColumnCount = 2;
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		tableLayoutPanel_1.Controls.Add(tableLayoutPanel_2, 0, 0);
		tableLayoutPanel_1.Controls.Add(groupBox_1, 1, 0);
		tableLayoutPanel_1.Dock = DockStyle.Fill;
		tableLayoutPanel_1.Location = new Point(6, 6);
		tableLayoutPanel_1.Name = Class16.smethod_0(1648912339);
		tableLayoutPanel_1.RowCount = 1;
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_1.Size = new Size(1320, 118);
		tableLayoutPanel_1.TabIndex = 3;
		tableLayoutPanel_2.ColumnCount = 1;
		tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel_2.Controls.Add(tableLayoutPanel_3, 0, 0);
		tableLayoutPanel_2.Controls.Add(tableLayoutPanel_4, 0, 1);
		tableLayoutPanel_2.Dock = DockStyle.Fill;
		tableLayoutPanel_2.Location = new Point(3, 3);
		tableLayoutPanel_2.Name = Class16.smethod_0(1648912366);
		tableLayoutPanel_2.RowCount = 2;
		tableLayoutPanel_2.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		tableLayoutPanel_2.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		tableLayoutPanel_2.Size = new Size(918, 112);
		tableLayoutPanel_2.TabIndex = 2;
		tableLayoutPanel_3.ColumnCount = 3;
		tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
		tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
		tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
		tableLayoutPanel_3.Controls.Add(label_0, 0, 0);
		tableLayoutPanel_3.Controls.Add(label_1, 1, 0);
		tableLayoutPanel_3.Controls.Add(label_2, 2, 0);
		tableLayoutPanel_3.Controls.Add(textBox_0, 0, 1);
		tableLayoutPanel_3.Controls.Add(textBox_1, 1, 1);
		tableLayoutPanel_3.Controls.Add(textBox_2, 2, 1);
		tableLayoutPanel_3.Dock = DockStyle.Fill;
		tableLayoutPanel_3.Location = new Point(3, 3);
		tableLayoutPanel_3.Name = Class16.smethod_0(1648911365);
		tableLayoutPanel_3.RowCount = 2;
		tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		tableLayoutPanel_3.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		tableLayoutPanel_3.Size = new Size(912, 50);
		tableLayoutPanel_3.TabIndex = 0;
		tableLayoutPanel_4.ColumnCount = 3;
		tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
		tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
		tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));
		tableLayoutPanel_4.Controls.Add(label_3, 0, 0);
		tableLayoutPanel_4.Controls.Add(label_4, 1, 0);
		tableLayoutPanel_4.Controls.Add(label_5, 2, 0);
		tableLayoutPanel_4.Controls.Add(textBox_3, 0, 1);
		tableLayoutPanel_4.Controls.Add(textBox_4, 1, 1);
		tableLayoutPanel_4.Controls.Add(textBox_5, 2, 1);
		tableLayoutPanel_4.Dock = DockStyle.Fill;
		tableLayoutPanel_4.Location = new Point(3, 59);
		tableLayoutPanel_4.Name = Class16.smethod_0(1648911390);
		tableLayoutPanel_4.RowCount = 2;
		tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		tableLayoutPanel_4.Size = new Size(912, 50);
		tableLayoutPanel_4.TabIndex = 1;
		groupBox_1.Controls.Add(label_18);
		groupBox_1.Controls.Add(comboBox_1);
		groupBox_1.Controls.Add(button_0);
		groupBox_1.Controls.Add(comboBox_0);
		groupBox_1.Dock = DockStyle.Fill;
		groupBox_1.Location = new Point(927, 3);
		groupBox_1.Name = Class16.smethod_0(1648929037);
		groupBox_1.Size = new Size(390, 112);
		groupBox_1.TabIndex = 17;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1648911408);
		label_18.AutoSize = true;
		label_18.Location = new Point(40, 23);
		label_18.Name = Class16.smethod_0(1648911426);
		label_18.Size = new Size(45, 13);
		label_18.TabIndex = 18;
		label_18.Text = Class16.smethod_0(1648931051);
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.Enabled = false;
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1648911440),
			Class16.smethod_0(1648911450),
			Class16.smethod_0(1648911468)
		});
		comboBox_1.Location = new Point(103, 18);
		comboBox_1.Name = Class16.smethod_0(1648911478);
		comboBox_1.Size = new Size(130, 21);
		comboBox_1.TabIndex = 17;
		comboBox_1.SelectedIndexChanged += comboBox_1_SelectedIndexChanged;
		button_0.Enabled = false;
		button_0.Location = new Point(19, 47);
		button_0.Name = Class16.smethod_0(1648911491);
		button_0.Size = new Size(66, 23);
		button_0.TabIndex = 16;
		button_0.Text = Class16.smethod_0(1648931650);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Enabled = false;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(103, 47);
		comboBox_0.Name = Class16.smethod_0(1648911507);
		comboBox_0.Size = new Size(130, 21);
		comboBox_0.TabIndex = 15;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		tableLayoutPanel_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		tableLayoutPanel_0.ColumnCount = 4;
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
		tableLayoutPanel_0.Controls.Add(textBox_7, 2, 0);
		tableLayoutPanel_0.Controls.Add(textBox_34, 3, 7);
		tableLayoutPanel_0.Controls.Add(textBox_9, 0, 0);
		tableLayoutPanel_0.Controls.Add(textBox_35, 2, 7);
		tableLayoutPanel_0.Controls.Add(textBox_36, 1, 7);
		tableLayoutPanel_0.Controls.Add(textBox_8, 1, 0);
		tableLayoutPanel_0.Controls.Add(textBox_37, 0, 7);
		tableLayoutPanel_0.Controls.Add(textBox_6, 3, 0);
		tableLayoutPanel_0.Controls.Add(textBox_24, 2, 1);
		tableLayoutPanel_0.Controls.Add(textBox_26, 0, 1);
		tableLayoutPanel_0.Controls.Add(textBox_38, 1, 6);
		tableLayoutPanel_0.Controls.Add(textBox_25, 1, 1);
		tableLayoutPanel_0.Controls.Add(textBox_39, 0, 6);
		tableLayoutPanel_0.Controls.Add(textBox_23, 3, 1);
		tableLayoutPanel_0.Controls.Add(textBox_20, 2, 2);
		tableLayoutPanel_0.Controls.Add(textBox_22, 0, 2);
		tableLayoutPanel_0.Controls.Add(textBox_40, 1, 5);
		tableLayoutPanel_0.Controls.Add(textBox_21, 1, 2);
		tableLayoutPanel_0.Controls.Add(textBox_41, 0, 5);
		tableLayoutPanel_0.Controls.Add(textBox_19, 3, 2);
		tableLayoutPanel_0.Controls.Add(textBox_42, 3, 4);
		tableLayoutPanel_0.Controls.Add(textBox_16, 2, 3);
		tableLayoutPanel_0.Controls.Add(textBox_43, 2, 4);
		tableLayoutPanel_0.Controls.Add(textBox_44, 1, 4);
		tableLayoutPanel_0.Controls.Add(textBox_45, 0, 4);
		tableLayoutPanel_0.Controls.Add(textBox_18, 0, 3);
		tableLayoutPanel_0.Controls.Add(textBox_17, 1, 3);
		tableLayoutPanel_0.Controls.Add(textBox_15, 3, 3);
		tableLayoutPanel_0.Controls.Add(textBox_46, 3, 5);
		tableLayoutPanel_0.Controls.Add(textBox_47, 2, 5);
		tableLayoutPanel_0.Controls.Add(textBox_48, 2, 6);
		tableLayoutPanel_0.Controls.Add(textBox_49, 3, 6);
		tableLayoutPanel_0.Location = new Point(164, 50);
		tableLayoutPanel_0.Margin = new Padding(1);
		tableLayoutPanel_0.Name = Class16.smethod_0(1648929366);
		tableLayoutPanel_0.RowCount = 8;
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
		tableLayoutPanel_0.Size = new Size(403, 201);
		tableLayoutPanel_0.TabIndex = 110;
		textBox_7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_7.Location = new Point(202, 2);
		textBox_7.Margin = new Padding(2);
		textBox_7.Name = Class16.smethod_0(1648911533);
		textBox_7.Size = new Size(96, 20);
		textBox_7.TabIndex = 7;
		textBox_7.Tag = Class16.smethod_0(1648911557);
		textBox_7.Leave += textBox_49_Leave;
		textBox_34.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_34.Location = new Point(302, 177);
		textBox_34.Margin = new Padding(2);
		textBox_34.Name = Class16.smethod_0(1648911565);
		textBox_34.Size = new Size(99, 20);
		textBox_34.TabIndex = 109;
		textBox_34.Tag = Class16.smethod_0(1648935128);
		textBox_34.Leave += textBox_49_Leave;
		textBox_9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_9.Location = new Point(2, 2);
		textBox_9.Margin = new Padding(2);
		textBox_9.Name = Class16.smethod_0(1648911591);
		textBox_9.Size = new Size(96, 20);
		textBox_9.TabIndex = 5;
		textBox_9.Tag = Class16.smethod_0(1648934925);
		textBox_9.Leave += textBox_49_Leave;
		textBox_35.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_35.Location = new Point(202, 177);
		textBox_35.Margin = new Padding(2);
		textBox_35.Name = Class16.smethod_0(1648911615);
		textBox_35.Size = new Size(96, 20);
		textBox_35.TabIndex = 108;
		textBox_35.Tag = Class16.smethod_0(1648911639);
		textBox_35.Leave += textBox_49_Leave;
		textBox_36.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_36.Location = new Point(102, 177);
		textBox_36.Margin = new Padding(2);
		textBox_36.Name = Class16.smethod_0(1648911640);
		textBox_36.Size = new Size(96, 20);
		textBox_36.TabIndex = 107;
		textBox_36.Tag = Class16.smethod_0(1648911664);
		textBox_36.Leave += textBox_49_Leave;
		textBox_8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_8.Location = new Point(102, 2);
		textBox_8.Margin = new Padding(2);
		textBox_8.Name = Class16.smethod_0(1648911673);
		textBox_8.Size = new Size(96, 20);
		textBox_8.TabIndex = 6;
		textBox_8.Tag = Class16.smethod_0(1648934967);
		textBox_8.Leave += textBox_49_Leave;
		textBox_37.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_37.Location = new Point(2, 177);
		textBox_37.Margin = new Padding(2);
		textBox_37.Name = Class16.smethod_0(1648911697);
		textBox_37.Size = new Size(96, 20);
		textBox_37.TabIndex = 106;
		textBox_37.Tag = Class16.smethod_0(1648911721);
		textBox_37.Leave += textBox_49_Leave;
		textBox_6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_6.Location = new Point(302, 2);
		textBox_6.Margin = new Padding(2);
		textBox_6.Name = Class16.smethod_0(1648911730);
		textBox_6.Size = new Size(99, 20);
		textBox_6.TabIndex = 8;
		textBox_6.Tag = Class16.smethod_0(1648935001);
		textBox_6.Leave += textBox_49_Leave;
		textBox_24.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_24.Location = new Point(202, 27);
		textBox_24.Margin = new Padding(2);
		textBox_24.Name = Class16.smethod_0(1648911764);
		textBox_24.Size = new Size(96, 20);
		textBox_24.TabIndex = 84;
		textBox_24.Tag = Class16.smethod_0(1648911788);
		textBox_24.Leave += textBox_49_Leave;
		textBox_26.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_26.Location = new Point(2, 27);
		textBox_26.Margin = new Padding(2);
		textBox_26.Name = Class16.smethod_0(1648911796);
		textBox_26.Size = new Size(96, 20);
		textBox_26.TabIndex = 82;
		textBox_26.Tag = Class16.smethod_0(1648911820);
		textBox_26.Leave += textBox_49_Leave;
		textBox_38.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_38.Location = new Point(102, 152);
		textBox_38.Margin = new Padding(2);
		textBox_38.Name = Class16.smethod_0(1648911828);
		textBox_38.Size = new Size(96, 20);
		textBox_38.TabIndex = 103;
		textBox_38.Tag = Class16.smethod_0(1648911852);
		textBox_38.Leave += textBox_49_Leave;
		textBox_25.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_25.Location = new Point(102, 27);
		textBox_25.Margin = new Padding(2);
		textBox_25.Name = Class16.smethod_0(1648911861);
		textBox_25.Size = new Size(96, 20);
		textBox_25.TabIndex = 83;
		textBox_25.Tag = Class16.smethod_0(1648910861);
		textBox_25.Leave += textBox_49_Leave;
		textBox_39.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_39.Location = new Point(2, 152);
		textBox_39.Margin = new Padding(2);
		textBox_39.Name = Class16.smethod_0(1648910869);
		textBox_39.Size = new Size(96, 20);
		textBox_39.TabIndex = 102;
		textBox_39.Tag = Class16.smethod_0(1648910893);
		textBox_39.Leave += textBox_49_Leave;
		textBox_23.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_23.Location = new Point(302, 27);
		textBox_23.Margin = new Padding(2);
		textBox_23.Name = Class16.smethod_0(1648910902);
		textBox_23.Size = new Size(99, 20);
		textBox_23.TabIndex = 85;
		textBox_23.Tag = Class16.smethod_0(1648935043);
		textBox_23.Leave += textBox_49_Leave;
		textBox_20.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_20.Location = new Point(202, 52);
		textBox_20.Margin = new Padding(2);
		textBox_20.Name = Class16.smethod_0(1648910920);
		textBox_20.Size = new Size(96, 20);
		textBox_20.TabIndex = 88;
		textBox_20.Tag = Class16.smethod_0(1648910944);
		textBox_20.Leave += textBox_49_Leave;
		textBox_22.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_22.Location = new Point(2, 52);
		textBox_22.Margin = new Padding(2);
		textBox_22.Name = Class16.smethod_0(1648910953);
		textBox_22.Size = new Size(96, 20);
		textBox_22.TabIndex = 86;
		textBox_22.Tag = Class16.smethod_0(1648910977);
		textBox_22.Leave += textBox_49_Leave;
		textBox_40.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_40.Location = new Point(102, 127);
		textBox_40.Margin = new Padding(2);
		textBox_40.Name = Class16.smethod_0(1648910985);
		textBox_40.Size = new Size(96, 20);
		textBox_40.TabIndex = 99;
		textBox_40.Tag = Class16.smethod_0(1648911009);
		textBox_40.Leave += textBox_49_Leave;
		textBox_21.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_21.Location = new Point(102, 52);
		textBox_21.Margin = new Padding(2);
		textBox_21.Name = Class16.smethod_0(1648911018);
		textBox_21.Size = new Size(96, 20);
		textBox_21.TabIndex = 87;
		textBox_21.Tag = Class16.smethod_0(1648911042);
		textBox_21.Leave += textBox_49_Leave;
		textBox_41.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_41.Location = new Point(2, 127);
		textBox_41.Margin = new Padding(2);
		textBox_41.Name = Class16.smethod_0(1648911051);
		textBox_41.Size = new Size(96, 20);
		textBox_41.TabIndex = 98;
		textBox_41.Tag = Class16.smethod_0(1648911075);
		textBox_41.Leave += textBox_49_Leave;
		textBox_19.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_19.Location = new Point(302, 52);
		textBox_19.Margin = new Padding(2);
		textBox_19.Name = Class16.smethod_0(1648911092);
		textBox_19.Size = new Size(99, 20);
		textBox_19.TabIndex = 89;
		textBox_19.Tag = Class16.smethod_0(1648911118);
		textBox_19.Leave += textBox_49_Leave;
		textBox_42.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_42.Location = new Point(302, 102);
		textBox_42.Margin = new Padding(2);
		textBox_42.Name = Class16.smethod_0(1648911127);
		textBox_42.Size = new Size(99, 20);
		textBox_42.TabIndex = 97;
		textBox_42.Tag = Class16.smethod_0(1648911145);
		textBox_42.Leave += textBox_49_Leave;
		textBox_16.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_16.Location = new Point(202, 77);
		textBox_16.Margin = new Padding(2);
		textBox_16.Name = Class16.smethod_0(1648911154);
		textBox_16.Size = new Size(96, 20);
		textBox_16.TabIndex = 92;
		textBox_16.Tag = Class16.smethod_0(1648911178);
		textBox_16.Leave += textBox_49_Leave;
		textBox_43.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_43.Location = new Point(202, 102);
		textBox_43.Margin = new Padding(2);
		textBox_43.Name = Class16.smethod_0(1648911187);
		textBox_43.Size = new Size(96, 20);
		textBox_43.TabIndex = 96;
		textBox_43.Tag = Class16.smethod_0(1648911211);
		textBox_43.Leave += textBox_49_Leave;
		textBox_44.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_44.Location = new Point(102, 102);
		textBox_44.Margin = new Padding(2);
		textBox_44.Name = Class16.smethod_0(1648911228);
		textBox_44.Size = new Size(96, 20);
		textBox_44.TabIndex = 95;
		textBox_44.Tag = Class16.smethod_0(1648911252);
		textBox_44.Leave += textBox_49_Leave;
		textBox_45.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_45.Location = new Point(2, 102);
		textBox_45.Margin = new Padding(2);
		textBox_45.Name = Class16.smethod_0(1648911261);
		textBox_45.Size = new Size(96, 20);
		textBox_45.TabIndex = 94;
		textBox_45.Tag = Class16.smethod_0(1648911285);
		textBox_45.Leave += textBox_49_Leave;
		textBox_18.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_18.Location = new Point(2, 77);
		textBox_18.Margin = new Padding(2);
		textBox_18.Name = Class16.smethod_0(1648911294);
		textBox_18.Size = new Size(96, 20);
		textBox_18.TabIndex = 90;
		textBox_18.Tag = Class16.smethod_0(1648911318);
		textBox_18.Leave += textBox_49_Leave;
		textBox_17.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_17.Location = new Point(102, 77);
		textBox_17.Margin = new Padding(2);
		textBox_17.Name = Class16.smethod_0(1648911327);
		textBox_17.Size = new Size(96, 20);
		textBox_17.TabIndex = 91;
		textBox_17.Tag = Class16.smethod_0(1648911351);
		textBox_17.Leave += textBox_49_Leave;
		textBox_15.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_15.Location = new Point(302, 77);
		textBox_15.Margin = new Padding(2);
		textBox_15.Name = Class16.smethod_0(1648911352);
		textBox_15.Size = new Size(99, 20);
		textBox_15.TabIndex = 93;
		textBox_15.Tag = Class16.smethod_0(1648935093);
		textBox_15.Leave += textBox_49_Leave;
		textBox_46.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_46.Location = new Point(302, 127);
		textBox_46.Margin = new Padding(2);
		textBox_46.Name = Class16.smethod_0(1648910354);
		textBox_46.Size = new Size(99, 20);
		textBox_46.TabIndex = 101;
		textBox_46.Tag = Class16.smethod_0(1648910388);
		textBox_46.Leave += textBox_49_Leave;
		textBox_47.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_47.Location = new Point(202, 127);
		textBox_47.Margin = new Padding(2);
		textBox_47.Name = Class16.smethod_0(1648910397);
		textBox_47.Size = new Size(96, 20);
		textBox_47.TabIndex = 100;
		textBox_47.Tag = Class16.smethod_0(1648910421);
		textBox_47.Leave += textBox_49_Leave;
		textBox_48.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_48.Location = new Point(202, 152);
		textBox_48.Margin = new Padding(2);
		textBox_48.Name = Class16.smethod_0(1648910430);
		textBox_48.Size = new Size(96, 20);
		textBox_48.TabIndex = 104;
		textBox_48.Tag = Class16.smethod_0(1648910454);
		textBox_48.Leave += textBox_49_Leave;
		textBox_49.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_49.Location = new Point(302, 152);
		textBox_49.Margin = new Padding(2);
		textBox_49.Name = Class16.smethod_0(1648910463);
		textBox_49.Size = new Size(99, 20);
		textBox_49.TabIndex = 105;
		textBox_49.Tag = Class16.smethod_0(1648910481);
		textBox_49.Leave += textBox_49_Leave;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridView_0.BackgroundColor = Color.WhiteSmoke;
		dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle2;
		dataGridView_0.EditMode = DataGridViewEditMode.EditOnKeystroke;
		dataGridView_0.EnableHeadersVisualStyles = false;
		dataGridView_0.Location = new Point(0, 0);
		dataGridView_0.Name = Class16.smethod_0(1648910490);
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridView_0.ScrollBars = ScrollBars.Vertical;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellErrors = false;
		dataGridView_0.ShowCellToolTips = false;
		dataGridView_0.ShowEditingIcon = false;
		dataGridView_0.ShowRowErrors = false;
		dataGridView_0.Size = new Size(163, 228);
		dataGridView_0.TabIndex = 73;
		dataGridView_0.CurrentCellChanged += dataGridView_0_CurrentCellChanged;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648910512);
		dataGridViewTextBoxColumn_0.Width = 161;
		textBox_12.Location = new Point(368, 26);
		textBox_12.Name = Class16.smethod_0(1648910546);
		textBox_12.ReadOnly = true;
		textBox_12.Size = new Size(63, 20);
		textBox_12.TabIndex = 81;
		label_8.AutoSize = true;
		label_8.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_8.Location = new Point(301, 29);
		label_8.Name = Class16.smethod_0(1648920093);
		label_8.Size = new Size(54, 15);
		label_8.TabIndex = 80;
		label_8.Text = Class16.smethod_0(1648910570);
		textBox_13.Location = new Point(468, 2);
		textBox_13.Name = Class16.smethod_0(1648910587);
		textBox_13.ReadOnly = true;
		textBox_13.Size = new Size(63, 20);
		textBox_13.TabIndex = 79;
		label_9.AutoSize = true;
		label_9.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_9.Location = new Point(433, 3);
		label_9.Name = Class16.smethod_0(1648925176);
		label_9.Size = new Size(35, 15);
		label_9.TabIndex = 78;
		label_9.Text = Class16.smethod_0(1648910615);
		textBox_14.Location = new Point(368, 2);
		textBox_14.Name = Class16.smethod_0(1648910628);
		textBox_14.ReadOnly = true;
		textBox_14.Size = new Size(63, 20);
		textBox_14.TabIndex = 77;
		textBox_11.Location = new Point(234, 25);
		textBox_11.Name = Class16.smethod_0(1648910647);
		textBox_11.ReadOnly = true;
		textBox_11.Size = new Size(63, 20);
		textBox_11.TabIndex = 75;
		label_7.AutoSize = true;
		label_7.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_7.Location = new Point(161, 29);
		label_7.Name = Class16.smethod_0(1648925008);
		label_7.Size = new Size(40, 15);
		label_7.TabIndex = 74;
		label_7.Text = Class16.smethod_0(1648910670);
		textBox_10.Location = new Point(234, 2);
		textBox_10.Name = Class16.smethod_0(1648910684);
		textBox_10.ReadOnly = true;
		textBox_10.Size = new Size(99, 20);
		textBox_10.TabIndex = 15;
		label_6.AutoSize = true;
		label_6.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_6.Location = new Point(161, 3);
		label_6.Name = Class16.smethod_0(1648930206);
		label_6.Size = new Size(72, 15);
		label_6.TabIndex = 14;
		label_6.Text = Class16.smethod_0(1648910709);
		label_10.AutoSize = true;
		label_10.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_10.Location = new Point(333, 3);
		label_10.Name = Class16.smethod_0(1648925100);
		label_10.Size = new Size(35, 15);
		label_10.TabIndex = 76;
		label_10.Text = Class16.smethod_0(1648910726);
		tabControl_0.Controls.Add(tabPage_0);
		tabControl_0.Controls.Add(tabPage_1);
		tabControl_0.Controls.Add(tabPage_2);
		tabControl_0.Controls.Add(tabPage_3);
		tabControl_0.Dock = DockStyle.Fill;
		tabControl_0.Location = new Point(0, 179);
		tabControl_0.Name = Class16.smethod_0(1648910731);
		tabControl_0.SelectedIndex = 0;
		tabControl_0.Size = new Size(1332, 406);
		tabControl_0.TabIndex = 14;
		tabControl_0.SelectedIndexChanged += tabControl_0_SelectedIndexChanged;
		tabPage_0.BackColor = Color.FromArgb(238, 245, 250);
		tabPage_0.Controls.Add(tableLayoutPanel_0);
		tabPage_0.Controls.Add(textBox_11);
		tabPage_0.Controls.Add(dataGridView_0);
		tabPage_0.Controls.Add(label_10);
		tabPage_0.Controls.Add(textBox_12);
		tabPage_0.Controls.Add(label_6);
		tabPage_0.Controls.Add(label_8);
		tabPage_0.Controls.Add(textBox_10);
		tabPage_0.Controls.Add(textBox_13);
		tabPage_0.Controls.Add(label_7);
		tabPage_0.Controls.Add(label_9);
		tabPage_0.Controls.Add(textBox_14);
		tabPage_0.Location = new Point(4, 22);
		tabPage_0.Name = Class16.smethod_0(1648910757);
		tabPage_0.Padding = new Padding(3);
		tabPage_0.Size = new Size(1324, 427);
		tabPage_0.TabIndex = 0;
		tabPage_0.Text = Class16.smethod_0(1648910772);
		tabPage_1.BackColor = Color.FromArgb(238, 245, 250);
		tabPage_1.Controls.Add(dataGridView_1);
		tabPage_1.Location = new Point(4, 22);
		tabPage_1.Name = Class16.smethod_0(1648910790);
		tabPage_1.Padding = new Padding(3);
		tabPage_1.Size = new Size(1322, 470);
		tabPage_1.TabIndex = 1;
		tabPage_1.Text = Class16.smethod_0(1648910805);
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToDeleteRows = false;
		dataGridView_1.AllowUserToResizeColumns = false;
		dataGridView_1.AllowUserToResizeRows = false;
		dataGridView_1.BackgroundColor = Color.WhiteSmoke;
		dataGridView_1.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dataGridView_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		dataGridView_1.Columns.AddRange(dataGridViewTextBoxColumn_1);
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
		dataGridViewCellStyle4.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
		dataGridView_1.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridView_1.EditMode = DataGridViewEditMode.EditOnKeystroke;
		dataGridView_1.EnableHeadersVisualStyles = false;
		dataGridView_1.Location = new Point(0, 0);
		dataGridView_1.Name = Class16.smethod_0(1648910816);
		dataGridView_1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_1.RowHeadersVisible = false;
		dataGridView_1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridView_1.ScrollBars = ScrollBars.Vertical;
		dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_1.ShowCellErrors = false;
		dataGridView_1.ShowCellToolTips = false;
		dataGridView_1.ShowEditingIcon = false;
		dataGridView_1.ShowRowErrors = false;
		dataGridView_1.Size = new Size(163, 228);
		dataGridView_1.TabIndex = 74;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648910847);
		dataGridViewTextBoxColumn_1.Width = 161;
		tabPage_2.BackColor = Color.FromArgb(238, 245, 250);
		tabPage_2.Controls.Add(textBox_30);
		tabPage_2.Controls.Add(label_14);
		tabPage_2.Controls.Add(label_11);
		tabPage_2.Controls.Add(label_12);
		tabPage_2.Controls.Add(textBox_27);
		tabPage_2.Controls.Add(textBox_28);
		tabPage_2.Controls.Add(label_13);
		tabPage_2.Controls.Add(textBox_29);
		tabPage_2.Controls.Add(dataGridView_2);
		tabPage_2.Location = new Point(4, 22);
		tabPage_2.Name = Class16.smethod_0(1648913944);
		tabPage_2.Padding = new Padding(3);
		tabPage_2.Size = new Size(1322, 470);
		tabPage_2.TabIndex = 2;
		tabPage_2.Text = Class16.smethod_0(1648913967);
		textBox_30.Location = new Point(236, 69);
		textBox_30.Name = Class16.smethod_0(1648913998);
		textBox_30.Size = new Size(63, 20);
		textBox_30.TabIndex = 87;
		textBox_30.Tag = Class16.smethod_0(1648914022);
		textBox_30.Leave += textBox_29_Leave;
		label_14.AutoSize = true;
		label_14.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_14.Location = new Point(163, 71);
		label_14.Name = Class16.smethod_0(1648914031);
		label_14.Size = new Size(31, 15);
		label_14.TabIndex = 86;
		label_14.Text = Class16.smethod_0(1648914045);
		label_11.AutoSize = true;
		label_11.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_11.Location = new Point(163, 27);
		label_11.Name = Class16.smethod_0(1648914048);
		label_11.Size = new Size(35, 15);
		label_11.TabIndex = 82;
		label_11.Text = Class16.smethod_0(1648910726);
		label_12.AutoSize = true;
		label_12.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_12.Location = new Point(163, 4);
		label_12.Name = Class16.smethod_0(1648920306);
		label_12.Size = new Size(72, 15);
		label_12.TabIndex = 80;
		label_12.Text = Class16.smethod_0(1648910709);
		textBox_27.Location = new Point(236, 3);
		textBox_27.Name = Class16.smethod_0(1648914070);
		textBox_27.Size = new Size(99, 20);
		textBox_27.TabIndex = 81;
		textBox_27.Tag = Class16.smethod_0(1648914091);
		textBox_27.Leave += textBox_29_Leave;
		textBox_28.Location = new Point(236, 47);
		textBox_28.Name = Class16.smethod_0(1648914108);
		textBox_28.Size = new Size(63, 20);
		textBox_28.TabIndex = 85;
		textBox_28.Tag = Class16.smethod_0(1648914132);
		textBox_28.Leave += textBox_29_Leave;
		label_13.AutoSize = true;
		label_13.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_13.Location = new Point(163, 49);
		label_13.Name = Class16.smethod_0(1648925222);
		label_13.Size = new Size(35, 15);
		label_13.TabIndex = 84;
		label_13.Text = Class16.smethod_0(1648910615);
		textBox_29.Location = new Point(236, 25);
		textBox_29.Name = Class16.smethod_0(1648914141);
		textBox_29.Size = new Size(63, 20);
		textBox_29.TabIndex = 83;
		textBox_29.Tag = Class16.smethod_0(1648914164);
		textBox_29.Leave += textBox_29_Leave;
		dataGridView_2.AllowUserToAddRows = false;
		dataGridView_2.AllowUserToDeleteRows = false;
		dataGridView_2.AllowUserToResizeColumns = false;
		dataGridView_2.AllowUserToResizeRows = false;
		dataGridView_2.BackgroundColor = Color.WhiteSmoke;
		dataGridView_2.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dataGridView_2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dataGridView_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		dataGridView_2.Columns.AddRange(dataGridViewTextBoxColumn_2);
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle6.BackColor = Color.WhiteSmoke;
		dataGridViewCellStyle6.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
		dataGridView_2.DefaultCellStyle = dataGridViewCellStyle6;
		dataGridView_2.EditMode = DataGridViewEditMode.EditOnKeystroke;
		dataGridView_2.EnableHeadersVisualStyles = false;
		dataGridView_2.Location = new Point(0, 0);
		dataGridView_2.Name = Class16.smethod_0(1648914173);
		dataGridView_2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_2.RowHeadersVisible = false;
		dataGridView_2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridView_2.ScrollBars = ScrollBars.Vertical;
		dataGridView_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_2.ShowCellErrors = false;
		dataGridView_2.ShowCellToolTips = false;
		dataGridView_2.ShowEditingIcon = false;
		dataGridView_2.ShowRowErrors = false;
		dataGridView_2.Size = new Size(163, 228);
		dataGridView_2.TabIndex = 75;
		dataGridView_2.CurrentCellChanged += dataGridView_2_CurrentCellChanged;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648914199);
		dataGridViewTextBoxColumn_2.Width = 161;
		tabPage_3.BackColor = Color.FromArgb(238, 245, 250);
		tabPage_3.Controls.Add(trackBar_7);
		tabPage_3.Controls.Add(trackBar_8);
		tabPage_3.Controls.Add(trackBar_9);
		tabPage_3.Controls.Add(trackBar_10);
		tabPage_3.Controls.Add(trackBar_11);
		tabPage_3.Controls.Add(trackBar_4);
		tabPage_3.Controls.Add(trackBar_5);
		tabPage_3.Controls.Add(trackBar_6);
		tabPage_3.Controls.Add(trackBar_1);
		tabPage_3.Controls.Add(trackBar_2);
		tabPage_3.Controls.Add(trackBar_3);
		tabPage_3.Controls.Add(trackBar_0);
		tabPage_3.Controls.Add(groupBox_0);
		tabPage_3.Controls.Add(textBox_54);
		tabPage_3.Controls.Add(textBox_55);
		tabPage_3.Controls.Add(textBox_56);
		tabPage_3.Controls.Add(textBox_57);
		tabPage_3.Controls.Add(textBox_58);
		tabPage_3.Controls.Add(textBox_59);
		tabPage_3.Controls.Add(textBox_60);
		tabPage_3.Controls.Add(textBox_61);
		tabPage_3.Controls.Add(textBox_62);
		tabPage_3.Controls.Add(textBox_63);
		tabPage_3.Controls.Add(textBox_64);
		tabPage_3.Controls.Add(textBox_65);
		tabPage_3.Controls.Add(textBox_31);
		tabPage_3.Controls.Add(label_15);
		tabPage_3.Controls.Add(label_17);
		tabPage_3.Controls.Add(textBox_32);
		tabPage_3.Controls.Add(textBox_33);
		tabPage_3.Controls.Add(dataGridView_3);
		tabPage_3.Controls.Add(label_16);
		tabPage_3.Location = new Point(4, 22);
		tabPage_3.Name = Class16.smethod_0(1648914224);
		tabPage_3.Padding = new Padding(3);
		tabPage_3.Size = new Size(1322, 470);
		tabPage_3.TabIndex = 3;
		tabPage_3.Text = Class16.smethod_0(1648914247);
		trackBar_7.Enabled = false;
		trackBar_7.LargeChange = 2;
		trackBar_7.Location = new Point(281, 433);
		trackBar_7.Maximum = 10000;
		trackBar_7.Minimum = -10000;
		trackBar_7.Name = Class16.smethod_0(1648914257);
		trackBar_7.Size = new Size(366, 45);
		trackBar_7.TabIndex = 148;
		trackBar_7.Tag = Class16.smethod_0(1648914274);
		trackBar_7.ValueChanged += trackBar_7_ValueChanged;
		trackBar_7.Leave += textBox_65_Leave;
		trackBar_8.Enabled = false;
		trackBar_8.LargeChange = 2;
		trackBar_8.Location = new Point(281, 403);
		trackBar_8.Maximum = 10000;
		trackBar_8.Minimum = -10000;
		trackBar_8.Name = Class16.smethod_0(1648914283);
		trackBar_8.Size = new Size(368, 45);
		trackBar_8.TabIndex = 147;
		trackBar_8.Tag = Class16.smethod_0(1648914308);
		trackBar_8.ValueChanged += trackBar_8_ValueChanged;
		trackBar_8.Leave += textBox_65_Leave;
		trackBar_9.Enabled = false;
		trackBar_9.LargeChange = 2;
		trackBar_9.Location = new Point(281, 369);
		trackBar_9.Maximum = 10000;
		trackBar_9.Minimum = -10000;
		trackBar_9.Name = Class16.smethod_0(1648914317);
		trackBar_9.Size = new Size(367, 45);
		trackBar_9.TabIndex = 146;
		trackBar_9.Tag = Class16.smethod_0(1648914334);
		trackBar_9.ValueChanged += trackBar_9_ValueChanged;
		trackBar_9.Leave += textBox_65_Leave;
		trackBar_10.Enabled = false;
		trackBar_10.LargeChange = 2;
		trackBar_10.Location = new Point(281, 335);
		trackBar_10.Maximum = 10000;
		trackBar_10.Minimum = -10000;
		trackBar_10.Name = Class16.smethod_0(1648914343);
		trackBar_10.Size = new Size(367, 45);
		trackBar_10.TabIndex = 145;
		trackBar_10.Tag = Class16.smethod_0(1648914359);
		trackBar_10.ValueChanged += trackBar_10_ValueChanged;
		trackBar_10.Leave += textBox_65_Leave;
		trackBar_11.Enabled = false;
		trackBar_11.LargeChange = 2;
		trackBar_11.Location = new Point(281, 301);
		trackBar_11.Maximum = 10000;
		trackBar_11.Minimum = -10000;
		trackBar_11.Name = Class16.smethod_0(1648914360);
		trackBar_11.Size = new Size(368, 45);
		trackBar_11.TabIndex = 144;
		trackBar_11.Tag = Class16.smethod_0(1648914376);
		trackBar_11.ValueChanged += trackBar_11_ValueChanged;
		trackBar_11.Leave += textBox_65_Leave;
		trackBar_4.Enabled = false;
		trackBar_4.LargeChange = 2;
		trackBar_4.Location = new Point(281, 269);
		trackBar_4.Maximum = 10000;
		trackBar_4.Minimum = -10000;
		trackBar_4.Name = Class16.smethod_0(1648914385);
		trackBar_4.Size = new Size(366, 45);
		trackBar_4.TabIndex = 143;
		trackBar_4.Tag = Class16.smethod_0(1648914401);
		trackBar_4.ValueChanged += trackBar_4_ValueChanged;
		trackBar_4.Leave += textBox_65_Leave;
		trackBar_5.Enabled = false;
		trackBar_5.LargeChange = 2;
		trackBar_5.Location = new Point(281, 234);
		trackBar_5.Maximum = 10000;
		trackBar_5.Minimum = -10000;
		trackBar_5.Name = Class16.smethod_0(1648914410);
		trackBar_5.Size = new Size(367, 45);
		trackBar_5.TabIndex = 142;
		trackBar_5.Tag = Class16.smethod_0(1648914426);
		trackBar_5.ValueChanged += trackBar_5_ValueChanged;
		trackBar_5.Leave += textBox_65_Leave;
		trackBar_6.Enabled = false;
		trackBar_6.LargeChange = 2;
		trackBar_6.Location = new Point(280, 200);
		trackBar_6.Maximum = 10000;
		trackBar_6.Minimum = -10000;
		trackBar_6.Name = Class16.smethod_0(1648913411);
		trackBar_6.Size = new Size(369, 45);
		trackBar_6.TabIndex = 141;
		trackBar_6.Tag = Class16.smethod_0(1648913427);
		trackBar_6.ValueChanged += trackBar_6_ValueChanged;
		trackBar_1.Enabled = false;
		trackBar_1.LargeChange = 2;
		trackBar_1.Location = new Point(277, 167);
		trackBar_1.Maximum = 10000;
		trackBar_1.Minimum = -10000;
		trackBar_1.Name = Class16.smethod_0(1648913444);
		trackBar_1.Size = new Size(372, 45);
		trackBar_1.TabIndex = 140;
		trackBar_1.Tag = Class16.smethod_0(1648913460);
		trackBar_1.ValueChanged += trackBar_1_ValueChanged;
		trackBar_1.Leave += textBox_65_Leave;
		trackBar_2.Enabled = false;
		trackBar_2.LargeChange = 2;
		trackBar_2.Location = new Point(277, 130);
		trackBar_2.Maximum = 10000;
		trackBar_2.Minimum = -10000;
		trackBar_2.Name = Class16.smethod_0(1648913469);
		trackBar_2.Size = new Size(372, 45);
		trackBar_2.TabIndex = 139;
		trackBar_2.Tag = Class16.smethod_0(1648913485);
		trackBar_2.ValueChanged += trackBar_2_ValueChanged;
		trackBar_2.Leave += textBox_65_Leave;
		trackBar_3.Enabled = false;
		trackBar_3.LargeChange = 2;
		trackBar_3.Location = new Point(277, 91);
		trackBar_3.Maximum = 10000;
		trackBar_3.Minimum = -10000;
		trackBar_3.Name = Class16.smethod_0(1648913494);
		trackBar_3.Size = new Size(370, 45);
		trackBar_3.TabIndex = 138;
		trackBar_3.Tag = Class16.smethod_0(1648913510);
		trackBar_3.ValueChanged += trackBar_3_ValueChanged;
		trackBar_3.Leave += textBox_65_Leave;
		trackBar_0.Enabled = false;
		trackBar_0.LargeChange = 2;
		trackBar_0.Location = new Point(276, 51);
		trackBar_0.Maximum = 10000;
		trackBar_0.Minimum = -10000;
		trackBar_0.Name = Class16.smethod_0(1648913519);
		trackBar_0.Size = new Size(371, 45);
		trackBar_0.TabIndex = 137;
		trackBar_0.Tag = Class16.smethod_0(1648913535);
		trackBar_0.ValueChanged += trackBar_0_ValueChanged;
		trackBar_0.Leave += textBox_65_Leave;
		groupBox_0.Controls.Add(trackBar_12);
		groupBox_0.Controls.Add(trackBar_13);
		groupBox_0.Controls.Add(trackBar_14);
		groupBox_0.Controls.Add(trackBar_15);
		groupBox_0.Controls.Add(textBox_50);
		groupBox_0.Controls.Add(textBox_51);
		groupBox_0.Controls.Add(textBox_52);
		groupBox_0.Controls.Add(textBox_53);
		groupBox_0.Location = new Point(653, 18);
		groupBox_0.Name = Class16.smethod_0(1648929126);
		groupBox_0.Size = new Size(664, 446);
		groupBox_0.TabIndex = 136;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1648913536);
		trackBar_12.Enabled = false;
		trackBar_12.LargeChange = 2;
		trackBar_12.Location = new Point(171, 186);
		trackBar_12.Maximum = 10000;
		trackBar_12.Minimum = -10000;
		trackBar_12.Name = Class16.smethod_0(1648913557);
		trackBar_12.Size = new Size(482, 45);
		trackBar_12.TabIndex = 97;
		trackBar_12.Tag = Class16.smethod_0(1648913574);
		trackBar_12.ValueChanged += trackBar_12_ValueChanged;
		trackBar_12.Leave += textBox_65_Leave;
		trackBar_13.Enabled = false;
		trackBar_13.LargeChange = 2;
		trackBar_13.Location = new Point(171, 135);
		trackBar_13.Maximum = 10000;
		trackBar_13.Minimum = -10000;
		trackBar_13.Name = Class16.smethod_0(1648913583);
		trackBar_13.Size = new Size(482, 45);
		trackBar_13.TabIndex = 96;
		trackBar_13.Tag = Class16.smethod_0(1648913592);
		trackBar_13.ValueChanged += trackBar_13_ValueChanged;
		trackBar_13.Leave += textBox_65_Leave;
		trackBar_14.Enabled = false;
		trackBar_14.LargeChange = 2;
		trackBar_14.Location = new Point(171, 81);
		trackBar_14.Maximum = 10000;
		trackBar_14.Minimum = -10000;
		trackBar_14.Name = Class16.smethod_0(1648913601);
		trackBar_14.Size = new Size(482, 45);
		trackBar_14.TabIndex = 95;
		trackBar_14.Tag = Class16.smethod_0(1648913618);
		trackBar_14.ValueChanged += trackBar_14_ValueChanged;
		trackBar_14.Leave += textBox_65_Leave;
		trackBar_15.Enabled = false;
		trackBar_15.LargeChange = 2;
		trackBar_15.Location = new Point(171, 33);
		trackBar_15.Maximum = 10000;
		trackBar_15.Minimum = -10000;
		trackBar_15.Name = Class16.smethod_0(1648913627);
		trackBar_15.Size = new Size(482, 45);
		trackBar_15.TabIndex = 94;
		trackBar_15.Tag = Class16.smethod_0(1648913652);
		trackBar_15.ValueChanged += trackBar_15_ValueChanged;
		trackBar_15.Leave += textBox_65_Leave;
		textBox_50.Location = new Point(5, 149);
		textBox_50.Margin = new Padding(2);
		textBox_50.Name = Class16.smethod_0(1648913661);
		textBox_50.Size = new Size(161, 20);
		textBox_50.TabIndex = 89;
		textBox_50.Tag = Class16.smethod_0(1648913592);
		textBox_50.Leave += textBox_65_Leave;
		textBox_51.Location = new Point(5, 41);
		textBox_51.Margin = new Padding(2);
		textBox_51.Name = Class16.smethod_0(1648913687);
		textBox_51.Size = new Size(161, 20);
		textBox_51.TabIndex = 8;
		textBox_51.Tag = Class16.smethod_0(1648913652);
		textBox_51.Leave += textBox_65_Leave;
		textBox_52.Location = new Point(5, 190);
		textBox_52.Margin = new Padding(2);
		textBox_52.Name = Class16.smethod_0(1648913705);
		textBox_52.Size = new Size(161, 20);
		textBox_52.TabIndex = 93;
		textBox_52.Tag = Class16.smethod_0(1648913574);
		textBox_52.Leave += textBox_65_Leave;
		textBox_53.Location = new Point(5, 98);
		textBox_53.Margin = new Padding(2);
		textBox_53.Name = Class16.smethod_0(1648913731);
		textBox_53.Size = new Size(161, 20);
		textBox_53.TabIndex = 85;
		textBox_53.Tag = Class16.smethod_0(1648913618);
		textBox_53.Leave += textBox_65_Leave;
		textBox_54.Anchor = AnchorStyles.None;
		textBox_54.Location = new Point(168, 275);
		textBox_54.Margin = new Padding(2);
		textBox_54.Name = Class16.smethod_0(1648913765);
		textBox_54.Size = new Size(109, 20);
		textBox_54.TabIndex = 99;
		textBox_54.Tag = Class16.smethod_0(1648914401);
		textBox_54.Leave += textBox_65_Leave;
		textBox_55.Anchor = AnchorStyles.None;
		textBox_55.Location = new Point(168, 174);
		textBox_55.Margin = new Padding(2);
		textBox_55.Name = Class16.smethod_0(1648913789);
		textBox_55.Size = new Size(109, 20);
		textBox_55.TabIndex = 98;
		textBox_55.Tag = Class16.smethod_0(1648913460);
		textBox_55.Leave += textBox_65_Leave;
		textBox_56.Anchor = AnchorStyles.None;
		textBox_56.Location = new Point(168, 309);
		textBox_56.Margin = new Padding(2);
		textBox_56.Name = Class16.smethod_0(1648913813);
		textBox_56.Size = new Size(109, 20);
		textBox_56.TabIndex = 102;
		textBox_56.Tag = Class16.smethod_0(1648914376);
		textBox_56.Leave += textBox_65_Leave;
		textBox_57.Anchor = AnchorStyles.None;
		textBox_57.Location = new Point(168, 59);
		textBox_57.Margin = new Padding(2);
		textBox_57.Name = Class16.smethod_0(1648913837);
		textBox_57.Size = new Size(109, 20);
		textBox_57.TabIndex = 97;
		textBox_57.Tag = Class16.smethod_0(1648913535);
		textBox_57.Leave += textBox_65_Leave;
		textBox_58.Anchor = AnchorStyles.None;
		textBox_58.Location = new Point(168, 344);
		textBox_58.Margin = new Padding(2);
		textBox_58.Name = Class16.smethod_0(1648913861);
		textBox_58.Size = new Size(109, 20);
		textBox_58.TabIndex = 105;
		textBox_58.Tag = Class16.smethod_0(1648914359);
		textBox_58.Leave += textBox_65_Leave;
		textBox_59.Anchor = AnchorStyles.None;
		textBox_59.Location = new Point(168, 206);
		textBox_59.Margin = new Padding(2);
		textBox_59.Name = Class16.smethod_0(1648913885);
		textBox_59.Size = new Size(109, 20);
		textBox_59.TabIndex = 101;
		textBox_59.Tag = Class16.smethod_0(1648913427);
		textBox_59.Leave += textBox_65_Leave;
		textBox_60.Anchor = AnchorStyles.None;
		textBox_60.Location = new Point(168, 99);
		textBox_60.Margin = new Padding(2);
		textBox_60.Name = Class16.smethod_0(1648913909);
		textBox_60.Size = new Size(109, 20);
		textBox_60.TabIndex = 100;
		textBox_60.Tag = Class16.smethod_0(1648913510);
		textBox_60.Leave += textBox_65_Leave;
		textBox_61.Anchor = AnchorStyles.None;
		textBox_61.Location = new Point(168, 243);
		textBox_61.Margin = new Padding(2);
		textBox_61.Name = Class16.smethod_0(1648912909);
		textBox_61.Size = new Size(109, 20);
		textBox_61.TabIndex = 104;
		textBox_61.Tag = Class16.smethod_0(1648914426);
		textBox_61.Leave += textBox_65_Leave;
		textBox_62.Anchor = AnchorStyles.None;
		textBox_62.Location = new Point(168, 136);
		textBox_62.Margin = new Padding(2);
		textBox_62.Name = Class16.smethod_0(1648912933);
		textBox_62.Size = new Size(109, 20);
		textBox_62.TabIndex = 103;
		textBox_62.Tag = Class16.smethod_0(1648913485);
		textBox_62.Leave += textBox_65_Leave;
		textBox_63.Anchor = AnchorStyles.None;
		textBox_63.Location = new Point(168, 380);
		textBox_63.Margin = new Padding(2);
		textBox_63.Name = Class16.smethod_0(1648912957);
		textBox_63.Size = new Size(109, 20);
		textBox_63.TabIndex = 106;
		textBox_63.Tag = Class16.smethod_0(1648914334);
		textBox_63.Leave += textBox_65_Leave;
		textBox_64.Anchor = AnchorStyles.None;
		textBox_64.Location = new Point(168, 412);
		textBox_64.Margin = new Padding(2);
		textBox_64.Name = Class16.smethod_0(1648912981);
		textBox_64.Size = new Size(109, 20);
		textBox_64.TabIndex = 107;
		textBox_64.Tag = Class16.smethod_0(1648914308);
		textBox_64.Leave += textBox_65_Leave;
		textBox_65.Anchor = AnchorStyles.None;
		textBox_65.Location = new Point(168, 441);
		textBox_65.Margin = new Padding(2);
		textBox_65.Name = Class16.smethod_0(1648913005);
		textBox_65.Size = new Size(109, 20);
		textBox_65.TabIndex = 108;
		textBox_65.Tag = Class16.smethod_0(1648914274);
		textBox_65.Leave += textBox_65_Leave;
		textBox_31.Location = new Point(236, 25);
		textBox_31.Name = Class16.smethod_0(1648913029);
		textBox_31.ReadOnly = true;
		textBox_31.Size = new Size(63, 20);
		textBox_31.TabIndex = 96;
		textBox_31.Tag = Class16.smethod_0(1648914022);
		label_15.AutoSize = true;
		label_15.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_15.Location = new Point(163, 27);
		label_15.Name = Class16.smethod_0(1648913041);
		label_15.Size = new Size(31, 15);
		label_15.TabIndex = 95;
		label_15.Text = Class16.smethod_0(1648914045);
		label_17.AutoSize = true;
		label_17.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_17.Location = new Point(163, 4);
		label_17.Name = Class16.smethod_0(1648913063);
		label_17.Size = new Size(72, 15);
		label_17.TabIndex = 89;
		label_17.Text = Class16.smethod_0(1648910709);
		textBox_32.Location = new Point(236, 3);
		textBox_32.Name = Class16.smethod_0(1648913077);
		textBox_32.ReadOnly = true;
		textBox_32.Size = new Size(99, 20);
		textBox_32.TabIndex = 90;
		textBox_32.Tag = Class16.smethod_0(1648914091);
		textBox_33.Location = new Point(357, 3);
		textBox_33.Name = Class16.smethod_0(1648913102);
		textBox_33.ReadOnly = true;
		textBox_33.Size = new Size(63, 20);
		textBox_33.TabIndex = 92;
		textBox_33.Tag = Class16.smethod_0(1648914164);
		dataGridView_3.AllowUserToAddRows = false;
		dataGridView_3.AllowUserToDeleteRows = false;
		dataGridView_3.AllowUserToResizeColumns = false;
		dataGridView_3.AllowUserToResizeRows = false;
		dataGridView_3.BackgroundColor = Color.WhiteSmoke;
		dataGridView_3.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle7.BackColor = SystemColors.Control;
		dataGridViewCellStyle7.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
		dataGridView_3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
		dataGridView_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		dataGridView_3.Columns.AddRange(dataGridViewTextBoxColumn_3);
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle8.BackColor = Color.WhiteSmoke;
		dataGridViewCellStyle8.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
		dataGridView_3.DefaultCellStyle = dataGridViewCellStyle8;
		dataGridView_3.EditMode = DataGridViewEditMode.EditOnKeystroke;
		dataGridView_3.EnableHeadersVisualStyles = false;
		dataGridView_3.Location = new Point(0, 0);
		dataGridView_3.Name = Class16.smethod_0(1648913113);
		dataGridView_3.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_3.RowHeadersVisible = false;
		dataGridView_3.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridView_3.ScrollBars = ScrollBars.Vertical;
		dataGridView_3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_3.ShowCellErrors = false;
		dataGridView_3.ShowCellToolTips = false;
		dataGridView_3.ShowEditingIcon = false;
		dataGridView_3.ShowRowErrors = false;
		dataGridView_3.Size = new Size(163, 228);
		dataGridView_3.TabIndex = 88;
		dataGridView_3.CurrentCellChanged += dataGridView_3_CurrentCellChanged;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1648913143);
		dataGridViewTextBoxColumn_3.Width = 161;
		label_16.AutoSize = true;
		label_16.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label_16.Location = new Point(335, 5);
		label_16.Name = Class16.smethod_0(1648913168);
		label_16.Size = new Size(21, 15);
		label_16.TabIndex = 91;
		label_16.Text = Class16.smethod_0(1648930840);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(238, 245, 250);
		base.ClientSize = new Size(1332, 607);
		base.Controls.Add(statusStrip_0);
		base.Controls.Add(tabControl_0);
		base.Controls.Add(panel_0);
		base.Controls.Add(toolStrip_0);
		base.Controls.Add(menuStrip_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		base.Icon = Resources.edit;
		base.MainMenuStrip = menuStrip_0;
		MinimumSize = new Size(565, 555);
		base.Name = Class16.smethod_0(1648913190);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648913202);
		base.Activated += BonFileEditor_Activated;
		toolStrip_0.ResumeLayout(performLayout: false);
		toolStrip_0.PerformLayout();
		statusStrip_0.ResumeLayout(performLayout: false);
		statusStrip_0.PerformLayout();
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		panel_0.ResumeLayout(performLayout: false);
		tableLayoutPanel_1.ResumeLayout(performLayout: false);
		tableLayoutPanel_2.ResumeLayout(performLayout: false);
		tableLayoutPanel_3.ResumeLayout(performLayout: false);
		tableLayoutPanel_3.PerformLayout();
		tableLayoutPanel_4.ResumeLayout(performLayout: false);
		tableLayoutPanel_4.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		tableLayoutPanel_0.ResumeLayout(performLayout: false);
		tableLayoutPanel_0.PerformLayout();
		((ISupportInitialize)dataGridView_0).EndInit();
		tabControl_0.ResumeLayout(performLayout: false);
		tabPage_0.ResumeLayout(performLayout: false);
		tabPage_0.PerformLayout();
		tabPage_1.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_1).EndInit();
		tabPage_2.ResumeLayout(performLayout: false);
		tabPage_2.PerformLayout();
		((ISupportInitialize)dataGridView_2).EndInit();
		tabPage_3.ResumeLayout(performLayout: false);
		tabPage_3.PerformLayout();
		((ISupportInitialize)trackBar_7).EndInit();
		((ISupportInitialize)trackBar_8).EndInit();
		((ISupportInitialize)trackBar_9).EndInit();
		((ISupportInitialize)trackBar_10).EndInit();
		((ISupportInitialize)trackBar_11).EndInit();
		((ISupportInitialize)trackBar_4).EndInit();
		((ISupportInitialize)trackBar_5).EndInit();
		((ISupportInitialize)trackBar_6).EndInit();
		((ISupportInitialize)trackBar_1).EndInit();
		((ISupportInitialize)trackBar_2).EndInit();
		((ISupportInitialize)trackBar_3).EndInit();
		((ISupportInitialize)trackBar_0).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		((ISupportInitialize)trackBar_12).EndInit();
		((ISupportInitialize)trackBar_13).EndInit();
		((ISupportInitialize)trackBar_14).EndInit();
		((ISupportInitialize)trackBar_15).EndInit();
		((ISupportInitialize)dataGridView_3).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void textBox_49_Leave(object sender, EventArgs e)
	{
		if (dataGridView_0.CurrentRow == null || dataGridView_0.CurrentRow.Index == -1)
		{
			return;
		}
		int num = Convert.ToInt32((sender as Control).Tag.ToString());
		IOrderedEnumerable<int> orderedEnumerable = dataGridView_0.SelectedRows.Cast<DataGridViewRow>().Select(Class51.class51_0.method_0).OrderByDescending(Class51.class51_0.method_1);
		foreach (int item in orderedEnumerable)
		{
			switch (num)
			{
			case 1:
				bonFile_0.FirstStages[item].Points[0].decimal_0 = Convert.ToDecimal(textBox_9.Text);
				break;
			case 2:
				bonFile_0.FirstStages[item].Points[0].decimal_1 = Convert.ToDecimal(textBox_8.Text);
				break;
			case 3:
				bonFile_0.FirstStages[item].Points[0].decimal_2 = Convert.ToDecimal(textBox_7.Text);
				break;
			case 4:
				bonFile_0.FirstStages[item].unknown0 = Convert.ToInt32(textBox_6.Text);
				break;
			case 5:
				bonFile_0.FirstStages[item].Points[1].decimal_0 = Convert.ToDecimal(textBox_26.Text);
				break;
			case 6:
				bonFile_0.FirstStages[item].Points[1].decimal_1 = Convert.ToDecimal(textBox_25.Text);
				break;
			case 7:
				bonFile_0.FirstStages[item].Points[1].decimal_2 = Convert.ToDecimal(textBox_24.Text);
				break;
			case 8:
				bonFile_0.FirstStages[item].unknown1 = Convert.ToInt32(textBox_23.Text);
				break;
			case 9:
				bonFile_0.FirstStages[item].Points[2].decimal_0 = Convert.ToDecimal(textBox_22.Text);
				break;
			case 10:
				bonFile_0.FirstStages[item].Points[2].decimal_1 = Convert.ToDecimal(textBox_21.Text);
				break;
			case 11:
				bonFile_0.FirstStages[item].Points[2].decimal_2 = Convert.ToDecimal(textBox_20.Text);
				break;
			case 12:
				bonFile_0.FirstStages[item].unknown2 = Convert.ToInt32(textBox_19.Text);
				break;
			case 13:
				bonFile_0.FirstStages[item].Points[3].decimal_0 = Convert.ToDecimal(textBox_18.Text);
				break;
			case 14:
				bonFile_0.FirstStages[item].Points[3].decimal_1 = Convert.ToDecimal(textBox_17.Text);
				break;
			case 15:
				bonFile_0.FirstStages[item].Points[3].decimal_2 = Convert.ToDecimal(textBox_16.Text);
				break;
			case 16:
				bonFile_0.FirstStages[item].unknown3 = Convert.ToDecimal(textBox_15.Text);
				break;
			case 17:
				bonFile_0.FirstStages[item].Points[4].decimal_0 = Convert.ToDecimal(textBox_45.Text);
				break;
			case 18:
				bonFile_0.FirstStages[item].Points[4].decimal_1 = Convert.ToDecimal(textBox_44.Text);
				break;
			case 19:
				bonFile_0.FirstStages[item].Points[4].decimal_2 = Convert.ToDecimal(textBox_43.Text);
				break;
			case 20:
				bonFile_0.FirstStages[item].unknown4 = Convert.ToDecimal(textBox_42.Text);
				break;
			case 21:
				bonFile_0.FirstStages[item].Points[5].decimal_0 = Convert.ToDecimal(textBox_41.Text);
				break;
			case 22:
				bonFile_0.FirstStages[item].Points[5].decimal_1 = Convert.ToDecimal(textBox_40.Text);
				break;
			case 23:
				bonFile_0.FirstStages[item].Points[5].decimal_2 = Convert.ToDecimal(textBox_47.Text);
				break;
			case 24:
				bonFile_0.FirstStages[item].unknown5 = Convert.ToDecimal(textBox_46.Text);
				break;
			case 25:
				bonFile_0.FirstStages[item].Points[6].decimal_0 = Convert.ToDecimal(textBox_39.Text);
				break;
			case 26:
				bonFile_0.FirstStages[item].Points[6].decimal_1 = Convert.ToDecimal(textBox_38.Text);
				break;
			case 27:
				bonFile_0.FirstStages[item].Points[6].decimal_2 = Convert.ToDecimal(textBox_48.Text);
				break;
			case 28:
				bonFile_0.FirstStages[item].unknown6 = Convert.ToDecimal(textBox_49.Text);
				break;
			case 29:
				bonFile_0.FirstStages[item].Points[7].decimal_0 = Convert.ToDecimal(textBox_37.Text);
				break;
			case 30:
				bonFile_0.FirstStages[item].Points[7].decimal_1 = Convert.ToDecimal(textBox_36.Text);
				break;
			case 31:
				bonFile_0.FirstStages[item].Points[7].decimal_2 = Convert.ToDecimal(textBox_35.Text);
				break;
			case 32:
				bonFile_0.FirstStages[item].unknown7 = Convert.ToDecimal(textBox_34.Text);
				break;
			}
		}
	}

	private void dataGridView_2_CurrentCellChanged(object sender, EventArgs e)
	{
		if (bonFile_0 != null && bonFile_0.SecondStagesAlt != null)
		{
			if (dataGridView_2.CurrentRow == null)
			{
				method_4(null);
				return;
			}
			if (dataGridView_2.CurrentRow.Index == -1)
			{
				method_4(null);
				return;
			}
			int index = dataGridView_2.CurrentRow.Index;
			if (index >= 0 && index < bonFile_0.SecondStagesAlt.Count)
			{
				textBox_27.Text = bonFile_0.SecondStagesAlt[index].BoneName.ToString();
				textBox_29.Text = bonFile_0.SecondStagesAlt[index].ID[0].ToString();
				textBox_28.Text = bonFile_0.SecondStagesAlt[index].ID[1].ToString();
				textBox_30.Text = bonFile_0.SecondStagesAlt[index].Unknown1.ToString();
				method_4(null);
			}
			else
			{
				method_4(null);
			}
		}
		else
		{
			method_4(null);
		}
	}

	private void textBox_29_Leave(object sender, EventArgs e)
	{
		if (dataGridView_2.CurrentRow == null || dataGridView_2.CurrentRow.Index == -1)
		{
			return;
		}
		int num = Convert.ToInt32((sender as Control).Tag.ToString());
		IOrderedEnumerable<int> orderedEnumerable = dataGridView_2.SelectedRows.Cast<DataGridViewRow>().Select(Class51.class51_0.method_2).OrderByDescending(Class51.class51_0.method_3);
		foreach (int item in orderedEnumerable)
		{
			switch (num)
			{
			case 33:
				bonFile_0.SecondStagesAlt[item].BoneName = textBox_27.Text;
				break;
			case 34:
				bonFile_0.SecondStagesAlt[item].ID[0] = Convert.ToInt32(textBox_29.Text);
				break;
			case 35:
				bonFile_0.SecondStagesAlt[item].ID[1] = Convert.ToInt32(textBox_28.Text);
				break;
			case 36:
				bonFile_0.SecondStagesAlt[item].Unknown1 = Convert.ToInt32(textBox_30.Text);
				break;
			}
		}
	}

	private void textBox_65_Leave(object sender, EventArgs e)
	{
		if (dataGridView_3.CurrentRow == null || dataGridView_3.CurrentRow.Index == -1)
		{
			return;
		}
		int num = Convert.ToInt32((sender as Control).Tag.ToString());
		IOrderedEnumerable<int> orderedEnumerable = dataGridView_3.SelectedRows.Cast<DataGridViewRow>().Select(Class51.class51_0.method_4).OrderByDescending(Class51.class51_0.method_5);
		foreach (int item in orderedEnumerable)
		{
			switch (num)
			{
			case 37:
				bonFile_0.GfxAnimations[item].Cords[0].decimal_0 = Convert.ToDecimal(textBox_57.Text);
				break;
			case 38:
				bonFile_0.GfxAnimations[item].Cords[0].decimal_1 = Convert.ToDecimal(textBox_55.Text);
				break;
			case 39:
				bonFile_0.GfxAnimations[item].Cords[0].decimal_2 = Convert.ToDecimal(textBox_54.Text);
				break;
			case 40:
				bonFile_0.GfxAnimations[item].CordsInts[0] = Convert.ToInt32(textBox_51.Text);
				break;
			case 41:
				bonFile_0.GfxAnimations[item].Cords[1].decimal_0 = Convert.ToDecimal(textBox_60.Text);
				break;
			case 42:
				bonFile_0.GfxAnimations[item].Cords[1].decimal_1 = Convert.ToDecimal(textBox_59.Text);
				break;
			case 43:
				bonFile_0.GfxAnimations[item].Cords[1].decimal_2 = Convert.ToDecimal(textBox_56.Text);
				break;
			case 44:
				bonFile_0.GfxAnimations[item].CordsInts[1] = Convert.ToInt32(textBox_53.Text);
				break;
			case 45:
				bonFile_0.GfxAnimations[item].Cords[2].decimal_0 = Convert.ToDecimal(textBox_62.Text);
				break;
			case 46:
				bonFile_0.GfxAnimations[item].Cords[2].decimal_1 = Convert.ToDecimal(textBox_61.Text);
				break;
			case 47:
				bonFile_0.GfxAnimations[item].Cords[2].decimal_2 = Convert.ToDecimal(textBox_58.Text);
				break;
			case 48:
				bonFile_0.GfxAnimations[item].CordsInts[2] = Convert.ToInt32(textBox_50.Text);
				break;
			case 49:
				bonFile_0.GfxAnimations[item].Cords[3].decimal_0 = Convert.ToDecimal(textBox_63.Text);
				break;
			case 50:
				bonFile_0.GfxAnimations[item].Cords[3].decimal_1 = Convert.ToDecimal(textBox_64.Text);
				break;
			case 51:
				bonFile_0.GfxAnimations[item].Cords[3].decimal_2 = Convert.ToDecimal(textBox_65.Text);
				break;
			case 52:
				bonFile_0.GfxAnimations[item].unknown1 = (float)Convert.ToDecimal(textBox_52.Text);
				break;
			}
		}
	}

	private void dataGridView_3_CurrentCellChanged(object sender, EventArgs e)
	{
		if (dataGridView_3.CurrentRow == null)
		{
			method_4(null);
			return;
		}
		if (dataGridView_3.CurrentRow.Index == -1)
		{
			method_4(null);
			return;
		}
		int index = dataGridView_3.CurrentRow.Index;
		textBox_32.Text = bonFile_0.GfxAnimations[index].BoneName;
		textBox_33.Text = bonFile_0.GfxAnimations[index].ID.ToString();
		textBox_31.Text = bonFile_0.GfxAnimations[index].unknown0.ToString();
		textBox_57.Text = bonFile_0.GfxAnimations[index].Cords[0].decimal_0.ToString();
		textBox_55.Text = bonFile_0.GfxAnimations[index].Cords[0].decimal_1.ToString();
		textBox_54.Text = bonFile_0.GfxAnimations[index].Cords[0].decimal_2.ToString();
		textBox_51.Text = bonFile_0.GfxAnimations[index].CordsInts[0].ToString();
		textBox_60.Text = bonFile_0.GfxAnimations[index].Cords[1].decimal_0.ToString();
		textBox_59.Text = bonFile_0.GfxAnimations[index].Cords[1].decimal_1.ToString();
		textBox_56.Text = bonFile_0.GfxAnimations[index].Cords[1].decimal_2.ToString();
		textBox_53.Text = bonFile_0.GfxAnimations[index].CordsInts[1].ToString();
		textBox_62.Text = bonFile_0.GfxAnimations[index].Cords[2].decimal_0.ToString();
		textBox_61.Text = bonFile_0.GfxAnimations[index].Cords[2].decimal_1.ToString();
		textBox_58.Text = bonFile_0.GfxAnimations[index].Cords[2].decimal_2.ToString();
		textBox_50.Text = bonFile_0.GfxAnimations[index].CordsInts[2].ToString();
		textBox_63.Text = bonFile_0.GfxAnimations[index].Cords[3].decimal_0.ToString();
		textBox_64.Text = bonFile_0.GfxAnimations[index].Cords[3].decimal_1.ToString();
		textBox_65.Text = bonFile_0.GfxAnimations[index].Cords[3].decimal_2.ToString();
		textBox_52.Text = bonFile_0.GfxAnimations[index].unknown1.ToString();
		method_4(null);
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBox_0.Text == string.Empty)
		{
			method_4(Class16.smethod_0(1648913224));
			return;
		}
		foreach (ClientWindow item in comboBox_0.Items)
		{
			if (!(item.Name != comboBox_0.SelectedItem.ToString()))
			{
				SelectedWindow = item;
				client_0 = new Client(item.Process);
				WindowManager.SetMainHandle(item.Process.MainWindowHandle);
				trackBar_0.Enabled = true;
				trackBar_3.Enabled = true;
				trackBar_2.Enabled = true;
				trackBar_1.Enabled = true;
				trackBar_6.Enabled = true;
				trackBar_5.Enabled = true;
				trackBar_4.Enabled = true;
				trackBar_11.Enabled = true;
				trackBar_10.Enabled = true;
				trackBar_9.Enabled = true;
				trackBar_8.Enabled = true;
				trackBar_7.Enabled = true;
				trackBar_15.Enabled = true;
				trackBar_14.Enabled = true;
				trackBar_13.Enabled = true;
				trackBar_12.Enabled = true;
				method_4(Class16.smethod_0(1648913256));
			}
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (Cf == null)
		{
			method_4(Class16.smethod_0(1648913293));
			return;
		}
		comboBox_0.Items.Clear();
		foreach (ClientWindow clientWindow in Cf.ClientWindows)
		{
			comboBox_0.Items.Add(clientWindow);
			comboBox_0.SelectedIndex = 0;
			comboBox_0.Enabled = true;
		}
		method_4((comboBox_0.Items.Count > 0) ? Class16.smethod_0(1648913377) : Class16.smethod_0(1648913348));
	}

	private void trackBar_0_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_0.Value;
		decimal num = (decimal)value / 10000m;
		textBox_57.Text = num.ToString();
		client_0.Rotation1((float)num);
	}

	private void trackBar_3_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_3.Value;
		decimal num = (decimal)value / 10000m;
		textBox_60.Text = num.ToString();
		client_0.Rotation2((float)num);
	}

	private void trackBar_2_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_2.Value;
		decimal num = (decimal)value / 10000m;
		textBox_62.Text = num.ToString();
		client_0.Rotation3((float)num);
	}

	private void trackBar_1_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_1.Value;
		decimal num = (decimal)value / 10000m;
		textBox_55.Text = num.ToString();
		client_0.Rotation4((float)num);
	}

	private void trackBar_6_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_6.Value;
		decimal num = (decimal)value / 10000m;
		textBox_59.Text = num.ToString();
		client_0.Rotation5((float)num);
	}

	private void trackBar_5_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_5.Value;
		decimal num = (decimal)value / 10000m;
		textBox_61.Text = num.ToString();
		client_0.Rotation6((float)num);
	}

	private void trackBar_4_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_4.Value;
		decimal num = (decimal)value / 10000m;
		textBox_54.Text = num.ToString();
		client_0.Rotation7((float)num);
	}

	private void trackBar_11_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_11.Value;
		decimal num = (decimal)value / 10000m;
		textBox_56.Text = num.ToString();
		client_0.Rotation8((float)num);
	}

	private void trackBar_10_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_10.Value;
		decimal num = (decimal)value / 10000m;
		textBox_58.Text = num.ToString();
		client_0.Rotation9((float)num);
	}

	private void trackBar_9_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_9.Value;
		decimal num = (decimal)value / 10000m;
		textBox_63.Text = num.ToString();
		client_0.Rotation10((float)num);
	}

	private void trackBar_8_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_8.Value;
		decimal num = (decimal)value / 10000m;
		textBox_64.Text = num.ToString();
		client_0.Rotation11((float)num);
	}

	private void trackBar_7_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_7.Value;
		decimal num = (decimal)value / 10000m;
		textBox_65.Text = num.ToString();
		client_0.Rotation12((float)num);
	}

	private void trackBar_15_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_15.Value;
		decimal num = (decimal)value / 10000m;
		textBox_51.Text = num.ToString();
		client_0.Rotation13((float)num);
	}

	private void trackBar_14_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_14.Value;
		decimal num = (decimal)value / 10000m;
		textBox_53.Text = num.ToString();
		client_0.Rotation14((float)num);
	}

	private void trackBar_13_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_13.Value;
		decimal num = (decimal)value / 10000m;
		textBox_50.Text = num.ToString();
		client_0.Rotation15((float)num);
	}

	private void trackBar_12_ValueChanged(object sender, EventArgs e)
	{
		int value = trackBar_12.Value;
		decimal num = (decimal)value / 10000m;
		textBox_52.Text = num.ToString();
		client_0.Rotation16((float)num);
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string text = comboBox_1.Text;
		if (!(text == Class16.smethod_0(1648911440)))
		{
			if (!(text == Class16.smethod_0(1648911450)))
			{
				if (!(text == Class16.smethod_0(1648911468)))
				{
					Client.version = 0;
				}
				else
				{
					Client.version = 178;
					Cf = new ClientFinder(Client.base_address_178, Client.game_struct, Client.char_ptr, Client.name_178);
					button_0.Enabled = true;
					comboBox_1.Enabled = false;
				}
			}
			else
			{
				Client.version = 176;
				Cf = new ClientFinder(Client.base_address_176, Client.game_struct, Client.char_ptr, Client.name_176);
				button_0.Enabled = true;
				comboBox_1.Enabled = false;
			}
		}
		else
		{
			Client.version = 174;
			Cf = new ClientFinder(Client.base_address_174, Client.game_struct, Client.char_ptr, Client.name_174);
			button_0.Enabled = true;
			comboBox_1.Enabled = false;
		}
		method_4((Client.version == 0) ? Class16.smethod_0(1648912418) : string.Format(Class16.smethod_0(1648912384), Client.version));
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		toolStripMenuItem_1_Click(sender, e);
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		toolStripMenuItem_2_Click(sender, e);
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		method_1();
	}

	private void toolStripTextBox_0_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			method_1();
		}
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		button_0_Click(sender, e);
	}

	private void toolStripButton_4_Click(object sender, EventArgs e)
	{
		if (client_0 != null && SelectedWindow != null)
		{
			TrackBar[] array = method_3();
			foreach (TrackBar trackBar in array)
			{
				if (trackBar.Enabled)
				{
					trackBar.Value = 0;
				}
			}
			method_4(Class16.smethod_0(1648912498));
		}
		else
		{
			method_4(Class16.smethod_0(1648912456));
		}
	}

	private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		int_0 = -1;
		method_4(null);
	}

	private void method_1()
	{
		DataGridView dataGridView = method_2();
		if (dataGridView != null && dataGridView.Rows.Count != 0)
		{
			string text = toolStripTextBox_0.Text.Trim();
			if (text.Length == 0)
			{
				method_4(Class16.smethod_0(1648912573));
				return;
			}
			if (!string.Equals(string_1, text, StringComparison.OrdinalIgnoreCase))
			{
				string_1 = text;
				int_0 = -1;
			}
			int num = int_0 + 1;
			int num2 = smethod_0(dataGridView, text, num);
			if (num2 == -1 && num > 0)
			{
				num2 = smethod_0(dataGridView, text, 0);
			}
			if (num2 == -1)
			{
				method_4(Class16.smethod_0(1648912604) + text + Class16.smethod_0(1648912610));
				return;
			}
			int_0 = num2;
			dataGridView.ClearSelection();
			dataGridView.Rows[num2].Selected = true;
			if (dataGridView.Rows[num2].Cells.Count > 0)
			{
				dataGridView.CurrentCell = dataGridView.Rows[num2].Cells[0];
			}
			if (dataGridView.Rows.Count > 0)
			{
				dataGridView.FirstDisplayedScrollingRowIndex = Math.Max(0, num2 - 2);
			}
			method_4(string.Format(Class16.smethod_0(1648912637), text, num2 + 1));
		}
		else
		{
			method_4(Class16.smethod_0(1648912530));
		}
	}

	private static int smethod_0(DataGridView dataGridView_4, string string_2, int int_1)
	{
		int num = int_1;
		while (true)
		{
			object obj;
			if (num < dataGridView_4.Rows.Count)
			{
				if (dataGridView_4.Rows[num].Cells.Count == 0)
				{
					goto IL_0059;
				}
				object value = dataGridView_4.Rows[num].Cells[0].Value;
				if (value == null)
				{
					obj = null;
				}
				else
				{
					obj = value.ToString();
					if (obj != null)
					{
						goto IL_004d;
					}
				}
				obj = string.Empty;
				goto IL_004d;
			}
			return -1;
			IL_0059:
			num++;
			continue;
			IL_004d:
			string text = (string)obj;
			if (text.IndexOf(string_2, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				break;
			}
			goto IL_0059;
		}
		return num;
	}

	private DataGridView method_2()
	{
		if (tabControl_0.SelectedTab == tabPage_0)
		{
			return dataGridView_0;
		}
		if (tabControl_0.SelectedTab == tabPage_1)
		{
			return dataGridView_1;
		}
		if (tabControl_0.SelectedTab == tabPage_2)
		{
			return dataGridView_2;
		}
		if (tabControl_0.SelectedTab == tabPage_3)
		{
			return dataGridView_3;
		}
		return null;
	}

	private TrackBar[] method_3()
	{
		return new TrackBar[16]
		{
			trackBar_0, trackBar_3, trackBar_2, trackBar_1, trackBar_6, trackBar_5, trackBar_4, trackBar_11, trackBar_10, trackBar_9,
			trackBar_8, trackBar_7, trackBar_15, trackBar_14, trackBar_13, trackBar_12
		};
	}

	private void method_4(string string_2)
	{
		toolStripStatusLabel_0.Text = (string.IsNullOrWhiteSpace(string_0) ? Class16.smethod_0(1648916792) : (Class16.smethod_0(1648912665) + System.IO.Path.GetFileName(string_0)));
		DataGridView dataGridView = method_2();
		string arg = ((tabControl_0.SelectedTab != null) ? tabControl_0.SelectedTab.Text : Class16.smethod_0(1648912686));
		int num = dataGridView?.Rows.Count ?? 0;
		string arg2 = Class16.smethod_0(1648912688);
		object obj;
		if (dataGridView?.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
		{
			if (dataGridView.CurrentRow.Cells.Count <= 0)
			{
				obj = string.Empty;
			}
			else
			{
				object value = dataGridView.CurrentRow.Cells[0].Value;
				if (value == null)
				{
					obj = null;
				}
				else
				{
					obj = value.ToString();
					if (obj != null)
					{
						goto IL_00f4;
					}
				}
				obj = string.Empty;
			}
			goto IL_00f4;
		}
		goto IL_0144;
		IL_00f4:
		string text = (string)obj;
		arg2 = ((text.Length > 0) ? string.Format(Class16.smethod_0(1648938828), dataGridView.CurrentRow.Index + 1, text) : string.Format(Class16.smethod_0(1648912699), dataGridView.CurrentRow.Index + 1));
		goto IL_0144;
		IL_0144:
		toolStripStatusLabel_1.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648912717), Class16.smethod_0(1648912751)), arg, num, arg2);
		if (!string.IsNullOrWhiteSpace(string_2))
		{
			toolStripStatusLabel_2.Text = string_2;
			return;
		}
		string arg3 = (string.IsNullOrWhiteSpace(comboBox_1.Text) ? Class16.smethod_0(1648912794) : (Class16.smethod_0(1648912786) + comboBox_1.Text));
		string arg4 = ((comboBox_0.SelectedItem != null) ? comboBox_0.SelectedItem.ToString() : Class16.smethod_0(1648912820));
		toolStripStatusLabel_2.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648912837), Class16.smethod_0(1648912850)), arg3, arg4);
	}

	private void BonFileEditor_Activated(object sender, EventArgs e)
	{
		method_5();
	}

	private void method_5()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_BonFileEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_BonFileEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}
}
