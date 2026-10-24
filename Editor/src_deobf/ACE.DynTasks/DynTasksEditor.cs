using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ACE.Classes;
using ACE.License;
using ACE.Pck;
using ACE.Properties;
using ACE.RSGlobal;
using Sentry;

namespace ACE.DynTasks;

public class DynTasksEditor : Form
{
	[Serializable]
	private sealed class Class109
	{
		public static readonly Class109 class109_0 = new Class109();

		public static Action action_0;

		public static Func<DataGridViewRow, int> func_0;

		public static Func<int, int> func_1;

		internal void method_0()
		{
			try
			{
				if (LicenseCredentials.TryLoadCredentials(out var email, out var password) && !AceNative.IsSuccess(CommonStorage.License.AuthenticateUser(email, password, out var _)))
				{
					Environment.Exit(0);
				}
			}
			catch
			{
			}
		}

		internal int method_1(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_2(int int_0)
		{
			return int_0;
		}
	}

	public DYN_TASKS DynData;

	public bool DontChange;

	public bool IsFileChanged;

	public CommonStorage CStorage;

	public int SelectedTaskIndex = -1;

	private IContainer icontainer_0;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripMenuItem toolStripMenuItem_5;

	private GroupBox groupBox_0;

	private Label label_0;

	private TextBox textBox_0;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_1;

	private Label label_1;

	private DataGridView dataGridView_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_6;

	private ToolStripMenuItem toolStripMenuItem_7;

	private ToolStripMenuItem toolStripMenuItem_8;

	private ToolStripSeparator toolStripSeparator_2;

	private ToolStripMenuItem toolStripMenuItem_9;

	private Button button_2;

	private Button button_3;

	private Button button_4;

	private TextBox textBox_2;

	private Button button_5;

	private Label label_2;

	private SplitContainer splitContainer_0;

	private PropertyGrid propertyGrid_0;

	private StatusStrip statusStrip_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private bool bool_0;

	private Button button_6;

	private Button button_7;

	private byte[] byte_0;

	private Control control_0;

	public DynTasksEditor(CommonStorage CStorage)
	{
		try
		{
			method_7();
			TDark.StoreOriginalColors(this);
			TDark.ApplyThemeToForm(this);
			this.CStorage = CStorage;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			DontChange = false;
			IsFileChanged = false;
			method_0();
			method_17();
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void method_0()
	{
		dataGridViewComboBoxColumn_1.Items.Clear();
		dataGridViewComboBoxColumn_1.Items.AddRange(Class16.smethod_0(1648924120), Class16.smethod_0(1649006922), Class16.smethod_0(1649006950), Class16.smethod_0(1649001208), Class16.smethod_0(1649006962), Class16.smethod_0(1649006991), Class16.smethod_0(1649001226), Class16.smethod_0(1649001252), Class16.smethod_0(1649001270), Class16.smethod_0(1649001280), Class16.smethod_0(1649001298), Class16.smethod_0(1649007007));
		dataGridViewComboBoxColumn_2.Items.Clear();
		dataGridViewComboBoxColumn_2.Items.AddRange(Class16.smethod_0(1648924120), Class16.smethod_0(1649007040), Class16.smethod_0(1649007050));
		dataGridViewComboBoxColumn_0.Items.Clear();
		dataGridViewComboBoxColumn_0.Items.AddRange(Class16.smethod_0(1649007069), Class16.smethod_0(1649007074), Class16.smethod_0(1649007094), Class16.smethod_0(1649007099));
	}

	private void method_1()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		try
		{
			openFileDialog.Filter = Class16.smethod_0(1649000917);
			openFileDialog.FileName = Class16.smethod_0(1649004063);
			if (openFileDialog.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog.FileName))
			{
				try
				{
					DYN_TASKS dynData = new DYN_TASKS(openFileDialog.FileName);
					DynData = dynData;
					method_2();
					method_26();
					CommonStorage.Profile.SaveSetting(Class16.smethod_0(1649004084), Class16.smethod_0(1649004097), openFileDialog.FileName);
					return;
				}
				catch (InvalidDataException ex)
				{
					string text = (string.IsNullOrWhiteSpace(openFileDialog.FileName) ? Class16.smethod_0(1649004126) : openFileDialog.FileName);
					SentryHelper.CaptureMessage(Class16.smethod_0(1649004139) + text + Class16.smethod_0(1648927638) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649004182));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649004220), Class16.smethod_0(1649004260)), Class16.smethod_0(1649004306) + ex.Message), Class16.smethod_0(1649004362), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				catch (EndOfStreamException ex2)
				{
					string text2 = (string.IsNullOrWhiteSpace(openFileDialog.FileName) ? Class16.smethod_0(1649004126) : openFileDialog.FileName);
					SentryHelper.CaptureMessage(Class16.smethod_0(1649004379) + text2 + Class16.smethod_0(1648927638) + ex2.Message, (SentryLevel)2, Class16.smethod_0(1649004423));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649004220), Class16.smethod_0(1649004260)), Class16.smethod_0(1649004461) + ex2.Message), Class16.smethod_0(1649004362), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				catch (Exception ex3)
				{
					SentryHelper.CaptureException(ex3, Class16.smethod_0(1649004521));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649004220), Class16.smethod_0(1649004260)), ex3.Message), Class16.smethod_0(1649004362), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
		}
		finally
		{
			((IDisposable)openFileDialog).Dispose();
		}
	}

	public void OpenFile(string fileName)
	{
		if (!string.IsNullOrWhiteSpace(fileName) && File.Exists(fileName))
		{
			try
			{
				DYN_TASKS dynData = new DYN_TASKS(fileName);
				DynData = dynData;
				method_2();
				method_26();
			}
			catch (InvalidDataException ex)
			{
				string text = (string.IsNullOrWhiteSpace(fileName) ? Class16.smethod_0(1649004126) : fileName);
				SentryHelper.CaptureMessage(Class16.smethod_0(1649004139) + text + Class16.smethod_0(1648927638) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649003523));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649003573), Class16.smethod_0(1649004260)), Class16.smethod_0(1649004306) + ex.Message), Class16.smethod_0(1649004362), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			catch (EndOfStreamException ex2)
			{
				string text2 = (string.IsNullOrWhiteSpace(fileName) ? Class16.smethod_0(1649004126) : fileName);
				SentryHelper.CaptureMessage(Class16.smethod_0(1649004379) + text2 + Class16.smethod_0(1648927638) + ex2.Message, (SentryLevel)2, Class16.smethod_0(1649003615));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649003573), Class16.smethod_0(1649004260)), Class16.smethod_0(1649004461) + ex2.Message), Class16.smethod_0(1649004362), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			catch (Exception ex3)
			{
				SentryHelper.CaptureException(ex3, Class16.smethod_0(1649003649));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649003573), Class16.smethod_0(1649004260)), ex3.Message), Class16.smethod_0(1649004362), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void method_2()
	{
		if (DynData != null && DynData.FileLoaded)
		{
			DontChange = true;
			textBox_0.Text = DynData.FileName;
			textBox_1.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649003687), Class16.smethod_0(1649003719)), DynData.Version, DYN_TASKS.GetTimestampText(DynData.TimeMark));
			method_8(bool_1: false);
			dataGridView_0.Enabled = true;
			button_2.Enabled = true;
			contextMenuStrip_0.Enabled = true;
			dataGridView_0.Rows.Clear();
			propertyGrid_0.SelectedObject = null;
			SelectedTaskIndex = -1;
			int count = DynData.Tasks.Count;
			DataGridViewRow[] array = new DataGridViewRow[count];
			for (int i = 0; i < count; i++)
			{
				DYN_TASKS.DynTaskTmpl dynTaskTmpl = DynData.Tasks[i];
				DataGridViewRow dataGridViewRow = new DataGridViewRow();
				dataGridViewRow.Resizable = DataGridViewTriState.False;
				dataGridViewRow.CreateCells(dataGridView_0);
				dataGridViewRow.Cells[0].Value = dynTaskTmpl.ID.ToString();
				dataGridViewRow.Cells[1].Value = dynTaskTmpl.Name ?? string.Empty;
				dataGridViewRow.Cells[2].Value = method_3(dynTaskTmpl.DynTaskType);
				dataGridViewRow.Cells[3].Value = method_4(dynTaskTmpl.EnumMethod);
				dataGridViewRow.Cells[4].Value = method_5(dynTaskTmpl.EnumFinishType);
				dataGridViewRow.Cells[5].Value = dynTaskTmpl.Premise_Lev_Min.ToString();
				dataGridViewRow.Cells[6].Value = dynTaskTmpl.Premise_Lev_Max.ToString();
				dataGridViewRow.Cells[7].Value = dynTaskTmpl.CanGiveUp != 0;
				dataGridViewRow.Cells[8].Value = dynTaskTmpl.CanRedo != 0;
				dataGridViewRow.Tag = dynTaskTmpl.ID;
				array[i] = dataGridViewRow;
			}
			if (array.Length != 0)
			{
				dataGridView_0.Rows.AddRange(array);
			}
			DontChange = false;
			toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649003746), Class16.smethod_0(1649003782)), count);
		}
	}

	private string method_3(byte byte_1)
	{
		if (byte_1 < dataGridViewComboBoxColumn_0.Items.Count)
		{
			return dataGridViewComboBoxColumn_0.Items[byte_1].ToString();
		}
		return string.Format(Class16.smethod_0(1649007028), byte_1);
	}

	private string method_4(byte byte_1)
	{
		if (byte_1 < dataGridViewComboBoxColumn_1.Items.Count)
		{
			return dataGridViewComboBoxColumn_1.Items[byte_1].ToString();
		}
		return string.Format(Class16.smethod_0(1649007028), byte_1);
	}

	private string method_5(byte byte_1)
	{
		if (byte_1 < dataGridViewComboBoxColumn_2.Items.Count)
		{
			return dataGridViewComboBoxColumn_2.Items[byte_1].ToString();
		}
		return string.Format(Class16.smethod_0(1649007028), byte_1);
	}

	private void method_6()
	{
		if (DynData != null && DynData.FileLoaded)
		{
			try
			{
				DynData.Save();
				method_8(bool_1: false);
				toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649003805));
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649003825));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649003851), Class16.smethod_0(1649003900)), ex.Message), Class16.smethod_0(1649003931), MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

	private void method_7()
	{
		icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		toolStripSeparator_1 = new ToolStripSeparator();
		toolStripMenuItem_5 = new ToolStripMenuItem();
		groupBox_0 = new GroupBox();
		label_0 = new Label();
		textBox_0 = new TextBox();
		button_0 = new Button();
		button_1 = new Button();
		textBox_1 = new TextBox();
		label_1 = new Label();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		dataGridViewComboBoxColumn_2 = new DataGridViewComboBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
		contextMenuStrip_0 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_6 = new ToolStripMenuItem();
		toolStripMenuItem_7 = new ToolStripMenuItem();
		toolStripMenuItem_8 = new ToolStripMenuItem();
		toolStripSeparator_2 = new ToolStripSeparator();
		toolStripMenuItem_9 = new ToolStripMenuItem();
		button_2 = new Button();
		button_3 = new Button();
		button_4 = new Button();
		textBox_2 = new TextBox();
		button_5 = new Button();
		label_2 = new Label();
		splitContainer_0 = new SplitContainer();
		propertyGrid_0 = new PropertyGrid();
		statusStrip_0 = new StatusStrip();
		toolStripStatusLabel_0 = new ToolStripStatusLabel();
		menuStrip_0.SuspendLayout();
		groupBox_0.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		contextMenuStrip_0.SuspendLayout();
		((ISupportInitialize)splitContainer_0).BeginInit();
		splitContainer_0.Panel1.SuspendLayout();
		splitContainer_0.Panel2.SuspendLayout();
		splitContainer_0.SuspendLayout();
		statusStrip_0.SuspendLayout();
		SuspendLayout();
		menuStrip_0.BackColor = SystemColors.InactiveBorder;
		menuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		menuStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripMenuItem_0 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1649009132);
		menuStrip_0.Padding = new Padding(0, 2, 2, 2);
		menuStrip_0.RenderMode = ToolStripRenderMode.Professional;
		menuStrip_0.Size = new Size(1184, 24);
		menuStrip_0.TabIndex = 0;
		menuStrip_0.Text = Class16.smethod_0(1649012229);
		menuStrip_0.Visible = false;
		toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[7] { toolStripMenuItem_1, toolStripMenuItem_2, toolStripMenuItem_3, toolStripSeparator_0, toolStripMenuItem_4, toolStripSeparator_1, toolStripMenuItem_5 });
		toolStripMenuItem_0.Name = Class16.smethod_0(1649012245);
		toolStripMenuItem_0.Size = new Size(37, 20);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_1.Name = Class16.smethod_0(1648920856);
		toolStripMenuItem_1.ShortcutKeys = Keys.O | Keys.Control;
		toolStripMenuItem_1.Size = new Size(186, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648931498);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_2.Name = Class16.smethod_0(1648920878);
		toolStripMenuItem_2.ShortcutKeys = Keys.S | Keys.Control;
		toolStripMenuItem_2.Size = new Size(186, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.Name = Class16.smethod_0(1648920892);
		toolStripMenuItem_3.ShortcutKeys = Keys.S | Keys.Shift | Keys.Control;
		toolStripMenuItem_3.Size = new Size(186, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1649003956);
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1649012270);
		toolStripSeparator_0.Size = new Size(183, 6);
		toolStripMenuItem_4.Name = Class16.smethod_0(1649003973);
		toolStripMenuItem_4.Size = new Size(186, 22);
		toolStripMenuItem_4.Text = Class16.smethod_0(1649003984);
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		toolStripSeparator_1.Name = Class16.smethod_0(1649004015);
		toolStripSeparator_1.Size = new Size(183, 6);
		toolStripMenuItem_5.Name = Class16.smethod_0(1648920908);
		toolStripMenuItem_5.Size = new Size(186, 22);
		toolStripMenuItem_5.Text = Class16.smethod_0(1648920914);
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(textBox_0);
		groupBox_0.Controls.Add(button_0);
		groupBox_0.Controls.Add(button_1);
		groupBox_0.Controls.Add(button_2);
		groupBox_0.Controls.Add(button_3);
		groupBox_0.Controls.Add(button_4);
		groupBox_0.Controls.Add(textBox_1);
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Location = new Point(3, 0);
		groupBox_0.Name = Class16.smethod_0(1648929126);
		groupBox_0.Size = new Size(1178, 72);
		groupBox_0.TabIndex = 1;
		groupBox_0.TabStop = false;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_0.Location = new Point(10, 16);
		label_0.Name = Class16.smethod_0(1648893046);
		label_0.Size = new Size(28, 15);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1648916193);
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.BackColor = Color.White;
		textBox_0.Location = new Point(44, 13);
		textBox_0.Name = Class16.smethod_0(1649003008);
		textBox_0.ReadOnly = true;
		textBox_0.Size = new Size(614, 23);
		textBox_0.TabIndex = 1;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_0.Image = Resources.cmdOpen;
		button_0.Location = new Point(664, 11);
		button_0.Name = Class16.smethod_0(1648920945);
		button_0.Size = new Size(102, 25);
		button_0.TabIndex = 2;
		button_0.Text = Class16.smethod_0(1648931498);
		button_0.TextAlign = ContentAlignment.MiddleRight;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_1.Enabled = false;
		button_1.Image = Resources.cmdSave;
		button_1.Location = new Point(772, 11);
		button_1.Name = Class16.smethod_0(1648920967);
		button_1.Size = new Size(102, 25);
		button_1.TabIndex = 3;
		button_1.Text = Class16.smethod_0(1648941761);
		button_1.TextAlign = ContentAlignment.MiddleRight;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.BackColor = Color.White;
		textBox_1.Location = new Point(78, 42);
		textBox_1.Name = Class16.smethod_0(1649003028);
		textBox_1.ReadOnly = true;
		textBox_1.Size = new Size(580, 23);
		textBox_1.TabIndex = 4;
		textBox_1.TextAlign = HorizontalAlignment.Center;
		label_1.AutoSize = true;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_1.Location = new Point(10, 45);
		label_1.Name = Class16.smethod_0(1649003044);
		label_1.Size = new Size(62, 15);
		label_1.TabIndex = 5;
		label_1.Text = Class16.smethod_0(1649003063);
		splitContainer_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		splitContainer_0.Location = new Point(3, 103);
		splitContainer_0.Name = Class16.smethod_0(1648931759);
		splitContainer_0.Panel1.Controls.Add(dataGridView_0);
		splitContainer_0.Panel2.Controls.Add(propertyGrid_0);
		splitContainer_0.Size = new Size(1178, 523);
		splitContainer_0.SplitterDistance = 850;
		splitContainer_0.TabIndex = 2;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_0.BackgroundColor = Color.White;
		dataGridView_0.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_0.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1, dataGridViewComboBoxColumn_0, dataGridViewComboBoxColumn_1, dataGridViewComboBoxColumn_2, dataGridViewTextBoxColumn_2, dataGridViewTextBoxColumn_3, dataGridViewCheckBoxColumn_0, dataGridViewCheckBoxColumn_1);
		dataGridView_0.ContextMenuStrip = contextMenuStrip_0;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.White;
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8f);
		dataGridViewCellStyle.ForeColor = Color.Black;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = Color.White;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.Enabled = false;
		dataGridView_0.GridColor = Color.Silver;
		dataGridView_0.Location = new Point(0, 0);
		dataGridView_0.Margin = new Padding(3, 4, 3, 4);
		dataGridView_0.Name = Class16.smethod_0(1649003067);
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1648942905), 8f);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648942905), 9.75f);
		dataGridView_0.RowsDefaultCellStyle = dataGridViewCellStyle3;
		dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold);
		dataGridView_0.RowTemplate.Height = 22;
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellToolTips = false;
		dataGridView_0.Size = new Size(850, 523);
		dataGridView_0.TabIndex = 0;
		dataGridView_0.CellDoubleClick += dataGridView_0_CellDoubleClick;
		dataGridView_0.CellValueChanged += dataGridView_0_CellValueChanged;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle4.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Bold);
		dataGridViewCellStyle4.ForeColor = Color.Maroon;
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648929955);
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 70;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle5.ForeColor = Color.Black;
		dataGridViewTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle5;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649012442);
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewComboBoxColumn_0.HeaderText = Class16.smethod_0(1648936875);
		dataGridViewComboBoxColumn_0.Name = Class16.smethod_0(1649003082);
		dataGridViewComboBoxColumn_0.Width = 80;
		dataGridViewComboBoxColumn_1.HeaderText = Class16.smethod_0(1649001189);
		dataGridViewComboBoxColumn_1.Name = Class16.smethod_0(1649003108);
		dataGridViewComboBoxColumn_1.Width = 100;
		dataGridViewComboBoxColumn_2.HeaderText = Class16.smethod_0(1649003124);
		dataGridViewComboBoxColumn_2.Name = Class16.smethod_0(1649003142);
		dataGridViewComboBoxColumn_2.Width = 80;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1649003154);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1649003175);
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_2.Width = 55;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1649003185);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1649003206);
		dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_3.Width = 55;
		dataGridViewCheckBoxColumn_0.HeaderText = Class16.smethod_0(1649003216);
		dataGridViewCheckBoxColumn_0.Name = Class16.smethod_0(1649003238);
		dataGridViewCheckBoxColumn_0.Width = 55;
		dataGridViewCheckBoxColumn_1.HeaderText = Class16.smethod_0(1648903490);
		dataGridViewCheckBoxColumn_1.Name = Class16.smethod_0(1649003249);
		dataGridViewCheckBoxColumn_1.Width = 50;
		contextMenuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 8f);
		contextMenuStrip_0.Items.AddRange(new ToolStripItem[5] { toolStripMenuItem_6, toolStripMenuItem_7, toolStripMenuItem_8, toolStripSeparator_2, toolStripMenuItem_9 });
		contextMenuStrip_0.Name = Class16.smethod_0(1649003266);
		contextMenuStrip_0.Size = new Size(150, 98);
		toolStripMenuItem_6.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		toolStripMenuItem_6.Name = Class16.smethod_0(1649003303);
		toolStripMenuItem_6.ShortcutKeys = Keys.N | Keys.Control;
		toolStripMenuItem_6.Size = new Size(149, 22);
		toolStripMenuItem_6.Text = Class16.smethod_0(1648931361);
		toolStripMenuItem_6.Click += toolStripMenuItem_6_Click;
		toolStripMenuItem_7.Name = Class16.smethod_0(1649003316);
		toolStripMenuItem_7.ShortcutKeys = Keys.F2;
		toolStripMenuItem_7.Size = new Size(149, 22);
		toolStripMenuItem_7.Text = Class16.smethod_0(1649003334);
		toolStripMenuItem_7.Click += toolStripMenuItem_7_Click;
		toolStripMenuItem_8.Enabled = false;
		toolStripMenuItem_8.Name = Class16.smethod_0(1649003348);
		toolStripMenuItem_8.ShortcutKeys = Keys.Delete;
		toolStripMenuItem_8.Size = new Size(149, 22);
		toolStripMenuItem_8.Text = Class16.smethod_0(1648925718);
		toolStripMenuItem_8.Click += toolStripMenuItem_8_Click;
		toolStripSeparator_2.Name = Class16.smethod_0(1649003364);
		toolStripSeparator_2.Size = new Size(146, 6);
		toolStripMenuItem_9.Name = Class16.smethod_0(1649003389);
		toolStripMenuItem_9.ShortcutKeys = Keys.D | Keys.Control;
		toolStripMenuItem_9.Size = new Size(149, 22);
		toolStripMenuItem_9.Text = Class16.smethod_0(1649003400);
		toolStripMenuItem_9.Click += button_2_Click;
		button_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_2.Enabled = false;
		button_2.Image = Resources.cmdAdd;
		button_2.Location = new Point(877, 42);
		button_2.Name = Class16.smethod_0(1648926646);
		button_2.Size = new Size(90, 25);
		button_2.TabIndex = 3;
		button_2.Text = Class16.smethod_0(1648931361);
		button_2.TextAlign = ContentAlignment.MiddleRight;
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_3.Enabled = false;
		button_3.Image = Resources.cmdDelete;
		button_3.Location = new Point(973, 42);
		button_3.Name = Class16.smethod_0(1649003416);
		button_3.Size = new Size(90, 25);
		button_3.TabIndex = 4;
		button_3.Text = Class16.smethod_0(1648925718);
		button_3.TextAlign = ContentAlignment.MiddleRight;
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		button_4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_4.Location = new Point(1069, 42);
		button_4.Name = Class16.smethod_0(1649003432);
		button_4.Size = new Size(102, 25);
		button_4.TabIndex = 5;
		button_4.Text = Class16.smethod_0(1649014457);
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		label_2.AutoSize = true;
		label_2.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_2.Location = new Point(10, 77);
		label_2.Name = Class16.smethod_0(1649003455);
		label_2.Size = new Size(45, 15);
		label_2.TabIndex = 6;
		label_2.Text = Class16.smethod_0(1649003471);
		textBox_2.Location = new Point(61, 74);
		textBox_2.Name = Class16.smethod_0(1648919457);
		textBox_2.Size = new Size(200, 23);
		textBox_2.TabIndex = 7;
		textBox_2.KeyDown += textBox_2_KeyDown;
		button_5.Location = new Point(267, 72);
		button_5.Name = Class16.smethod_0(1649003485);
		button_5.Size = new Size(90, 25);
		button_5.TabIndex = 8;
		button_5.Text = Class16.smethod_0(1648916643);
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		propertyGrid_0.Dock = DockStyle.Fill;
		propertyGrid_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		propertyGrid_0.Location = new Point(0, 0);
		propertyGrid_0.Name = Class16.smethod_0(1649003503);
		propertyGrid_0.Size = new Size(324, 523);
		propertyGrid_0.TabIndex = 0;
		propertyGrid_0.PropertyValueChanged += propertyGrid_0_PropertyValueChanged;
		statusStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripStatusLabel_0 });
		statusStrip_0.Location = new Point(0, 629);
		statusStrip_0.Name = Class16.smethod_0(1649003514);
		statusStrip_0.Size = new Size(1184, 22);
		statusStrip_0.TabIndex = 9;
		statusStrip_0.Text = Class16.smethod_0(1649003514);
		toolStripStatusLabel_0.Name = Class16.smethod_0(1648916149);
		toolStripStatusLabel_0.Size = new Size(39, 17);
		toolStripStatusLabel_0.Text = Class16.smethod_0(1648920624);
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1184, 651);
		base.Controls.Add(statusStrip_0);
		base.Controls.Add(button_5);
		base.Controls.Add(textBox_2);
		base.Controls.Add(label_2);
		base.Controls.Add(splitContainer_0);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(menuStrip_0);
		Font = new Font(Class16.smethod_0(1648942905), 9f);
		base.MainMenuStrip = menuStrip_0;
		MinimumSize = new Size(900, 500);
		base.Name = Class16.smethod_0(1649004084);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649002517);
		base.FormClosing += DynTasksEditor_FormClosing;
		base.Load += DynTasksEditor_Load;
		base.Activated += DynTasksEditor_Activated;
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		((ISupportInitialize)dataGridView_0).EndInit();
		contextMenuStrip_0.ResumeLayout(performLayout: false);
		splitContainer_0.Panel1.ResumeLayout(performLayout: false);
		splitContainer_0.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_0).EndInit();
		splitContainer_0.ResumeLayout(performLayout: false);
		statusStrip_0.ResumeLayout(performLayout: false);
		statusStrip_0.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void method_8(bool bool_1)
	{
		IsFileChanged = bool_1;
		button_1.Enabled = bool_1;
		if (DynData != null)
		{
			DynData.FileChanged = bool_1;
		}
	}

	private void method_9()
	{
		method_8(bool_1: true);
	}

	private void method_10()
	{
		if (DynData != null && DynData.FileLoaded)
		{
			method_25();
			if (dataGridView_0.SelectedRows.Count > 0)
			{
				DynData.AddTask(dataGridView_0.SelectedRows[0].Index);
			}
			else
			{
				DynData.AddTask();
			}
			DYN_TASKS.DynTaskTmpl dynTaskTmpl = DynData.Tasks[DynData.Tasks.Count - 1];
			object[] values = new object[9]
			{
				dynTaskTmpl.ID.ToString(),
				dynTaskTmpl.Name ?? string.Empty,
				method_3(dynTaskTmpl.DynTaskType),
				method_4(dynTaskTmpl.EnumMethod),
				method_5(dynTaskTmpl.EnumFinishType),
				dynTaskTmpl.Premise_Lev_Min.ToString(),
				dynTaskTmpl.Premise_Lev_Max.ToString(),
				dynTaskTmpl.CanGiveUp != 0,
				dynTaskTmpl.CanRedo != 0
			};
			int num = dataGridView_0.Rows.Add(values);
			dataGridView_0.Rows[num].Tag = dynTaskTmpl.ID;
			dataGridView_0.CurrentCell = dataGridView_0[0, num];
			dataGridView_0.Rows[num].Selected = true;
			method_9();
			toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649002536), Class16.smethod_0(1649002573)), dynTaskTmpl.ID);
		}
	}

	private void method_11()
	{
		if (DynData != null && DynData.FileLoaded && dataGridView_0.SelectedRows.Count != 0)
		{
			int index = dataGridView_0.SelectedRows[0].Index;
			uint iD = DynData.Tasks[index].ID;
			if (DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649002598), Class16.smethod_0(1649002627)), iD), Class16.smethod_0(1649002687), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				method_25();
				DynData.DeleteTask(index);
				dataGridView_0.Rows.RemoveAt(index);
				method_9();
				toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649002708), Class16.smethod_0(1649002731)), iD);
				button_3.Enabled = dataGridView_0.SelectedRows.Count > 0;
			}
		}
	}

	private void method_12(int int_0)
	{
		if (DynData == null || !DynData.FileLoaded)
		{
			return;
		}
		string text = textBox_2.Text.Trim();
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		uint result;
		bool flag = uint.TryParse(text, out result);
		bool flag2 = false;
		for (int i = int_0 + 1; i < DynData.Tasks.Count; i++)
		{
			DYN_TASKS.DynTaskTmpl dynTaskTmpl = DynData.Tasks[i];
			bool num;
			if (!flag)
			{
				string name = dynTaskTmpl.Name;
				if (name != null && name.Contains(text, StringComparison.OrdinalIgnoreCase))
				{
					goto IL_00b7;
				}
				string description = dynTaskTmpl.Description;
				if (description == null)
				{
					continue;
				}
				num = description.Contains(text, StringComparison.OrdinalIgnoreCase);
			}
			else
			{
				num = dynTaskTmpl.ID == result;
			}
			if (!num)
			{
				continue;
			}
			goto IL_00b7;
			IL_00b7:
			dataGridView_0.CurrentCell = dataGridView_0[0, i];
			dataGridView_0.Rows[i].Selected = true;
			flag2 = true;
			break;
		}
		if (!flag2 && int_0 != -1)
		{
			method_12(-1);
		}
		else if (!flag2)
		{
			toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649002766));
		}
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		method_1();
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		method_6();
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_16();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_1();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_6();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void toolStripMenuItem_6_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_11();
	}

	private void toolStripMenuItem_8_Click(object sender, EventArgs e)
	{
		method_11();
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		int int_ = -1;
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			int_ = dataGridView_0.SelectedRows[0].Index;
		}
		method_12(int_);
	}

	private void textBox_2_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			button_5_Click(sender, e);
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		bool flag = dataGridView_0.SelectedRows.Count > 0;
		button_3.Enabled = flag;
		toolStripMenuItem_8.Enabled = flag;
		if (flag && DynData != null && DynData.FileLoaded)
		{
			method_29(dataGridView_0);
			SelectedTaskIndex = dataGridView_0.SelectedRows[0].Index;
			if (SelectedTaskIndex >= 0 && SelectedTaskIndex < DynData.Tasks.Count)
			{
				propertyGrid_0.SelectedObject = DynData.Tasks[SelectedTaskIndex];
			}
		}
	}

	private void method_13()
	{
		method_29(null);
		try
		{
			fileBasedUndoManager_0?.Dispose();
		}
		catch
		{
		}
		fileBasedUndoManager_0 = null;
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int rowIndex = e.RowIndex;
		int columnIndex = e.ColumnIndex;
		if (rowIndex < 0 || DynData == null || !DynData.FileLoaded || rowIndex >= DynData.Tasks.Count)
		{
			return;
		}
		DYN_TASKS.DynTaskTmpl dynTaskTmpl = DynData.Tasks[rowIndex];
		object value = dataGridView_0[columnIndex, rowIndex].Value;
		object obj;
		if (value == null)
		{
			obj = null;
		}
		else
		{
			obj = value.ToString();
			if (obj != null)
			{
				goto IL_0088;
			}
		}
		obj = string.Empty;
		goto IL_0088;
		IL_0088:
		string text = (string)obj;
		bool flag = false;
		switch (columnIndex)
		{
		case 0:
		{
			if (uint.TryParse(text, out var result2))
			{
				if (!DynData.IsIdUsed(result2, rowIndex))
				{
					method_28(dataGridView_0);
					dynTaskTmpl.ID = result2;
					dataGridView_0.Rows[rowIndex].Tag = result2;
					flag = true;
				}
				else
				{
					dataGridView_0[0, rowIndex].Value = dynTaskTmpl.ID.ToString();
				}
			}
			else
			{
				dataGridView_0[0, rowIndex].Value = dynTaskTmpl.ID.ToString();
			}
			break;
		}
		case 1:
			method_28(dataGridView_0);
			dynTaskTmpl.Name = text;
			flag = true;
			break;
		case 2:
		{
			int num2 = dataGridViewComboBoxColumn_0.Items.IndexOf(text);
			if (num2 >= 0)
			{
				method_28(dataGridView_0);
				dynTaskTmpl.DynTaskType = (byte)num2;
				flag = true;
			}
			break;
		}
		case 3:
		{
			int num = dataGridViewComboBoxColumn_1.Items.IndexOf(text);
			if (num >= 0)
			{
				method_28(dataGridView_0);
				dynTaskTmpl.EnumMethod = (byte)num;
				flag = true;
			}
			break;
		}
		case 4:
		{
			int num3 = dataGridViewComboBoxColumn_2.Items.IndexOf(text);
			if (num3 >= 0)
			{
				method_28(dataGridView_0);
				dynTaskTmpl.EnumFinishType = (byte)num3;
				flag = true;
			}
			break;
		}
		case 5:
		{
			if (byte.TryParse(text, out var result3))
			{
				method_28(dataGridView_0);
				dynTaskTmpl.Premise_Lev_Min = result3;
				flag = true;
			}
			else
			{
				dataGridView_0[5, rowIndex].Value = dynTaskTmpl.Premise_Lev_Min.ToString();
			}
			break;
		}
		case 6:
		{
			if (byte.TryParse(text, out var result))
			{
				method_28(dataGridView_0);
				dynTaskTmpl.Premise_Lev_Max = result;
				flag = true;
			}
			else
			{
				dataGridView_0[6, rowIndex].Value = dynTaskTmpl.Premise_Lev_Max.ToString();
			}
			break;
		}
		case 7:
			method_28(dataGridView_0);
			dynTaskTmpl.CanGiveUp = (Convert.ToBoolean(text) ? ((byte)1) : ((byte)0));
			flag = true;
			break;
		case 8:
			method_28(dataGridView_0);
			dynTaskTmpl.CanRedo = (Convert.ToBoolean(text) ? ((byte)1) : ((byte)0));
			flag = true;
			break;
		}
		if (flag)
		{
			method_9();
		}
		if (flag && SelectedTaskIndex == rowIndex)
		{
			propertyGrid_0.Refresh();
		}
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && DynData != null && DynData.FileLoaded)
		{
			method_14(e.RowIndex);
		}
	}

	private void toolStripMenuItem_7_Click(object sender, EventArgs e)
	{
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			method_14(dataGridView_0.SelectedRows[0].Index);
		}
	}

	private void method_14(int int_0)
	{
		if (DynData == null || !DynData.FileLoaded || int_0 < 0 || int_0 >= DynData.Tasks.Count)
		{
			return;
		}
		DynTaskDetailEditor dynTaskDetailEditor = new DynTaskDetailEditor(DynData.Tasks[int_0], CStorage);
		try
		{
			if (dynTaskDetailEditor.ShowDialog(this) == DialogResult.OK)
			{
				method_25();
				DynData.Tasks[int_0] = dynTaskDetailEditor.Task;
				DYN_TASKS.DynTaskTmpl dynTaskTmpl = DynData.Tasks[int_0];
				dataGridView_0[0, int_0].Value = dynTaskTmpl.ID.ToString();
				dataGridView_0[1, int_0].Value = dynTaskTmpl.Name ?? string.Empty;
				dataGridView_0[2, int_0].Value = method_3(dynTaskTmpl.DynTaskType);
				dataGridView_0[3, int_0].Value = method_4(dynTaskTmpl.EnumMethod);
				dataGridView_0[4, int_0].Value = method_5(dynTaskTmpl.EnumFinishType);
				dataGridView_0[5, int_0].Value = dynTaskTmpl.Premise_Lev_Min.ToString();
				dataGridView_0[6, int_0].Value = dynTaskTmpl.Premise_Lev_Max.ToString();
				dataGridView_0[7, int_0].Value = dynTaskTmpl.CanGiveUp != 0;
				dataGridView_0[8, int_0].Value = dynTaskTmpl.CanRedo != 0;
				dataGridView_0.Rows[int_0].Tag = dynTaskTmpl.ID;
				propertyGrid_0.SelectedObject = dynTaskTmpl;
				method_9();
				propertyGrid_0.Refresh();
			}
		}
		finally
		{
			((IDisposable)dynTaskDetailEditor).Dispose();
		}
	}

	private void propertyGrid_0_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		if (!DontChange && DynData != null && DynData.FileLoaded)
		{
			method_28(propertyGrid_0);
			method_9();
			if (SelectedTaskIndex >= 0 && SelectedTaskIndex < dataGridView_0.Rows.Count && SelectedTaskIndex < DynData.Tasks.Count)
			{
				DYN_TASKS.DynTaskTmpl dynTaskTmpl = DynData.Tasks[SelectedTaskIndex];
				DontChange = true;
				dataGridView_0[0, SelectedTaskIndex].Value = dynTaskTmpl.ID.ToString();
				dataGridView_0[1, SelectedTaskIndex].Value = dynTaskTmpl.Name ?? string.Empty;
				dataGridView_0[2, SelectedTaskIndex].Value = method_3(dynTaskTmpl.DynTaskType);
				dataGridView_0[3, SelectedTaskIndex].Value = method_4(dynTaskTmpl.EnumMethod);
				dataGridView_0[4, SelectedTaskIndex].Value = method_5(dynTaskTmpl.EnumFinishType);
				dataGridView_0[5, SelectedTaskIndex].Value = dynTaskTmpl.Premise_Lev_Min.ToString();
				dataGridView_0[6, SelectedTaskIndex].Value = dynTaskTmpl.Premise_Lev_Max.ToString();
				dataGridView_0[7, SelectedTaskIndex].Value = dynTaskTmpl.CanGiveUp != 0;
				dataGridView_0[8, SelectedTaskIndex].Value = dynTaskTmpl.CanRedo != 0;
				DontChange = false;
			}
			method_27(propertyGrid_0);
		}
	}

	private void DynTasksEditor_Load(object sender, EventArgs e)
	{
		Task.Run((Action)Class109.class109_0.method_0);
		string setting = CommonStorage.Profile.GetSetting(Class16.smethod_0(1649004084), Class16.smethod_0(1649004097), string.Empty);
		if (!string.IsNullOrEmpty(setting) && File.Exists(setting))
		{
			OpenFile(setting);
		}
	}

	private void DynTasksEditor_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (IsFileChanged)
		{
			switch (DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649002784)), TextStorage.Msg(Class16.smethod_0(1649002823)), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
			{
			case DialogResult.Yes:
				method_6();
				if (IsFileChanged)
				{
					e.Cancel = true;
					return;
				}
				break;
			case DialogResult.Cancel:
				e.Cancel = true;
				return;
			}
		}
		method_13();
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		if (DynData == null || !DynData.FileLoaded)
		{
			return;
		}
		using SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = Class16.smethod_0(1649002852);
		saveFileDialog.FileName = Class16.smethod_0(1649002874);
		if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			try
			{
				method_15(saveFileDialog.FileName);
				toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649002902));
				return;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649004084));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649002922), Class16.smethod_0(1649002961)), ex.Message), Class16.smethod_0(1648997892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
	}

	private void method_15(string string_0)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(string_0, Encoding.UTF8);
		try
		{
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement(Class16.smethod_0(1648997911));
			xmlTextWriter.WriteAttributeString(Class16.smethod_0(1648942674), DynData.Version.ToString());
			xmlTextWriter.WriteAttributeString(Class16.smethod_0(1648997926), DynData.TimeMark.ToString());
			foreach (DYN_TASKS.DynTaskTmpl task in DynData.Tasks)
			{
				xmlTextWriter.WriteStartElement(Class16.smethod_0(1648997941));
				xmlTextWriter.WriteAttributeString(Class16.smethod_0(1648941057), task.ID.ToString());
				xmlTextWriter.WriteAttributeString(Class16.smethod_0(1648936731), task.Name ?? string.Empty);
				xmlTextWriter.WriteAttributeString(Class16.smethod_0(1648936875), task.DynTaskType.ToString());
				xmlTextWriter.WriteAttributeString(Class16.smethod_0(1649001189), task.EnumMethod.ToString());
				xmlTextWriter.WriteAttributeString(Class16.smethod_0(1648997944), task.EnumFinishType.ToString());
				xmlTextWriter.WriteAttributeString(Class16.smethod_0(1648997961), task.Premise_Lev_Min.ToString());
				xmlTextWriter.WriteAttributeString(Class16.smethod_0(1648997976), task.Premise_Lev_Max.ToString());
				xmlTextWriter.WriteStartElement(Class16.smethod_0(1648997999));
				xmlTextWriter.WriteCData(task.Description ?? string.Empty);
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteStartElement(Class16.smethod_0(1648998009));
				xmlTextWriter.WriteCData(task.OkText ?? string.Empty);
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteStartElement(Class16.smethod_0(1648998030));
				xmlTextWriter.WriteCData(task.NoText ?? string.Empty);
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteEndElement();
			}
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
		}
		finally
		{
			((IDisposable)xmlTextWriter).Dispose();
		}
	}

	private void method_16()
	{
		if (DynData == null || !DynData.FileLoaded)
		{
			return;
		}
		using SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = Class16.smethod_0(1648998035);
		saveFileDialog.FileName = Class16.smethod_0(1649004063);
		if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			try
			{
				DynData.SaveAs(saveFileDialog.FileName);
				textBox_0.Text = DynData.FileName;
				method_8(bool_1: false);
				toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649003805));
				return;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648998091));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648998127), Class16.smethod_0(1649003900)), ex.Message), Class16.smethod_0(1649003931), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
	}

	private void method_17()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1648997911), 100);
		fileBasedUndoManager_0.SetStateChangedCallback(method_30);
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_21, method_22);
		method_18();
		method_20();
	}

	private void method_18()
	{
		button_6 = new Button
		{
			Name = Class16.smethod_0(1648919713),
			Text = string.Empty,
			Enabled = false,
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			Image = Resources.GShopEditor_PW_mbUndo,
			ImageAlign = ContentAlignment.MiddleCenter,
			FlatStyle = FlatStyle.Standard,
			UseVisualStyleBackColor = true,
			Parent = groupBox_0
		};
		button_7 = new Button
		{
			Name = Class16.smethod_0(1648919742),
			Text = string.Empty,
			Enabled = false,
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			Image = Resources.GShopEditor_PW_mbRedo,
			ImageAlign = ContentAlignment.MiddleCenter,
			FlatStyle = FlatStyle.Standard,
			UseVisualStyleBackColor = true,
			Parent = groupBox_0
		};
		button_6.Click += button_6_Click;
		button_7.Click += button_7_Click;
		groupBox_0.Resize += groupBox_0_Resize;
		method_19();
	}

	private void method_19()
	{
		if (button_6 != null && button_7 != null)
		{
			int num = Math.Max(32, button_0.Height);
			int num2 = button_0.Width;
			int top = button_0.Top;
			int num3 = groupBox_0.ClientSize.Width - 6;
			button_7.SetBounds(num3 - num, top, num, button_0.Height);
			button_6.SetBounds(button_7.Left - 4 - num, top, num, button_0.Height);
			button_1.SetBounds(button_6.Left - 4 - num2, top, num2, button_1.Height);
			button_0.SetBounds(button_1.Left - 4 - num2, top, num2, button_0.Height);
			textBox_0.Width = Math.Max(140, button_0.Left - textBox_0.Left - 4);
			int top2 = textBox_1.Top;
			button_4.SetBounds(num3 - button_4.Width, top2, button_4.Width, button_4.Height);
			button_3.SetBounds(button_4.Left - 4 - button_3.Width, top2, button_3.Width, button_3.Height);
			button_2.SetBounds(button_3.Left - 4 - button_2.Width, top2, button_2.Width, button_2.Height);
			textBox_1.Width = Math.Max(140, button_2.Left - textBox_1.Left - 4);
		}
	}

	private void method_20()
	{
		dataGridView_0.CellBeginEdit += dataGridView_0_CellBeginEdit;
		dataGridView_0.CurrentCellDirtyStateChanged += dataGridView_0_CurrentCellDirtyStateChanged;
		dataGridView_0.Leave += dataGridView_0_Leave;
		propertyGrid_0.Enter += propertyGrid_0_Enter;
		propertyGrid_0.MouseDown += propertyGrid_0_MouseDown;
		propertyGrid_0.Leave += propertyGrid_0_Leave;
	}

	private byte[] method_21()
	{
		if (DynData != null && DynData.FileLoaded)
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				try
				{
					BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
					try
					{
						binaryWriter.Write(DynData.FileName ?? string.Empty);
						binaryWriter.Write(DynData.FileLoaded);
						binaryWriter.Write(DynData.FileChanged);
						binaryWriter.Write(DynData.DataSize);
						binaryWriter.Write(DynData.TimeMark);
						binaryWriter.Write(DynData.Version);
						binaryWriter.Write(DynData.Tasks.Count);
						foreach (DYN_TASKS.DynTaskTmpl task in DynData.Tasks)
						{
							task.Write(binaryWriter);
						}
						binaryWriter.Write(IsFileChanged);
						binaryWriter.Write(dataGridView_0?.CurrentRow?.Index ?? (-1));
						DataGridView dataGridView = dataGridView_0;
						object obj;
						if (dataGridView == null)
						{
							obj = null;
						}
						else
						{
							obj = dataGridView.SelectedRows.Cast<DataGridViewRow>().Select(Class109.class109_0.method_1).OrderBy(Class109.class109_0.method_2)
								.ToArray();
							if (obj != null)
							{
								goto IL_01a4;
							}
						}
						obj = Array.Empty<int>();
						goto IL_01a4;
						IL_01a4:
						int[] array = (int[])obj;
						binaryWriter.Write(array.Length);
						int[] array2 = array;
						foreach (int value in array2)
						{
							binaryWriter.Write(value);
						}
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
			catch
			{
				return null;
			}
		}
		return null;
	}

	private void method_22(byte[] byte_1)
	{
		if (byte_1 == null || byte_1.Length == 0)
		{
			return;
		}
		bool_0 = true;
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_1);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					if (DynData == null)
					{
						DynData = new DYN_TASKS();
					}
					DynData.FileName = binaryReader.ReadString();
					binaryReader.ReadBoolean();
					DynData.FileChanged = binaryReader.ReadBoolean();
					DynData.DataSize = binaryReader.ReadUInt32();
					DynData.TimeMark = binaryReader.ReadUInt32();
					DynData.Version = binaryReader.ReadInt16();
					int num = binaryReader.ReadInt32();
					DynData.Tasks.Clear();
					for (int i = 0; i < num; i++)
					{
						DYN_TASKS.DynTaskTmpl dynTaskTmpl = new DYN_TASKS.DynTaskTmpl();
						dynTaskTmpl.Read(binaryReader);
						DynData.Tasks.Add(dynTaskTmpl);
					}
					bool bool_ = binaryReader.ReadBoolean();
					int int_ = binaryReader.ReadInt32();
					int num2 = binaryReader.ReadInt32();
					int[] array = new int[num2];
					for (int j = 0; j < num2; j++)
					{
						array[j] = binaryReader.ReadInt32();
					}
					method_2();
					method_23(int_, array);
					method_8(bool_);
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
			bool_0 = false;
			method_29(null);
		}
	}

	private void method_23(int int_0, int[] int_1)
	{
		if (dataGridView_0.Rows.Count == 0)
		{
			propertyGrid_0.SelectedObject = null;
			SelectedTaskIndex = -1;
			return;
		}
		dataGridView_0.ClearSelection();
		int_0 = method_24(int_0);
		bool flag = false;
		int[] array = int_1 ?? Array.Empty<int>();
		foreach (int int_2 in array)
		{
			int num = method_24(int_2);
			if (num >= 0)
			{
				dataGridView_0.Rows[num].Selected = true;
				flag = true;
			}
		}
		if (int_0 >= 0)
		{
			dataGridView_0.CurrentCell = dataGridView_0[0, int_0];
			if (!flag)
			{
				dataGridView_0.Rows[int_0].Selected = true;
			}
			dataGridView_0.FirstDisplayedScrollingRowIndex = int_0;
		}
		dataGridView_0_SelectionChanged(null, EventArgs.Empty);
	}

	private int method_24(int int_0)
	{
		if (dataGridView_0.Rows.Count == 0)
		{
			return -1;
		}
		if (int_0 < 0)
		{
			return 0;
		}
		return Math.Min(int_0, dataGridView_0.Rows.Count - 1);
	}

	private void method_25()
	{
		if (!bool_0 && DynData != null && DynData.FileLoaded)
		{
			byte[] array = method_21();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
			method_29(null);
		}
	}

	private void method_26()
	{
		method_29(null);
		fileBasedUndoManager_0?.Clear();
	}

	private void method_27(Control control_1)
	{
		if (!bool_0 && control_1 != null && DynData != null && DynData.FileLoaded && control_0 != control_1)
		{
			control_0 = control_1;
			byte_0 = method_21();
		}
	}

	private void method_28(Control control_1)
	{
		if (!bool_0 && control_1 != null && control_0 == control_1 && byte_0 != null)
		{
			fileBasedUndoManager_0?.PushUndo(byte_0);
			method_29(control_1);
		}
	}

	private void method_29(Control control_1)
	{
		if (control_1 == null || control_0 == control_1)
		{
			control_0 = null;
			byte_0 = null;
		}
	}

	private void method_30()
	{
		if (button_6 != null)
		{
			button_6.Enabled = fileBasedUndoManager_0?.CanUndo ?? false;
		}
		if (button_7 != null)
		{
			button_7.Enabled = fileBasedUndoManager_0?.CanRedo ?? false;
		}
	}

	private void DynTasksEditor_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_DynTasksEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_DynTasksEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_21();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_22(array);
		}
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_21();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_22(array);
		}
	}

	private void groupBox_0_Resize(object sender, EventArgs e)
	{
		method_19();
	}

	private void dataGridView_0_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
		method_27(dataGridView_0);
	}

	private void dataGridView_0_CurrentCellDirtyStateChanged(object sender, EventArgs e)
	{
		if (dataGridView_0.IsCurrentCellDirty)
		{
			dataGridView_0.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private void dataGridView_0_Leave(object sender, EventArgs e)
	{
		method_29(dataGridView_0);
	}

	private void propertyGrid_0_Enter(object sender, EventArgs e)
	{
		method_27(propertyGrid_0);
	}

	private void propertyGrid_0_MouseDown(object sender, MouseEventArgs e)
	{
		method_27(propertyGrid_0);
	}

	private void propertyGrid_0_Leave(object sender, EventArgs e)
	{
		method_29(propertyGrid_0);
	}
}
