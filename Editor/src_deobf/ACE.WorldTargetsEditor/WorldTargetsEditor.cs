using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Dependency.Cyotek.Windows.Forms.ImageBox;
using ACE.Properties;

namespace ACE.WorldTargetsEditor;

public class WorldTargetsEditor : Form
{
	private sealed class Class385
	{
		public WorldTargetsEditor worldTargetsEditor_0;

		public int int_0;

		public Predicate<FileStructure> predicate_0;

		internal bool method_0(FileStructure fileStructure_0)
		{
			return fileStructure_0.ID == worldTargetsEditor_0.worldTargetsFile_0.TeleportList[int_0].ID;
		}
	}

	[Serializable]
	private sealed class Class386
	{
		public static readonly Class386 class386_0 = new Class386();

		public static Func<int, int> func_0;

		public static Func<int, int> func_1;

		public static Func<DataGridViewRow, int> func_2;

		public static Func<int, int> func_3;

		internal int method_0(int int_0)
		{
			return int_0;
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
	}

	private List<int> list_0;

	private int int_0;

	private Graphics graphics_0;

	private WorldTargetsFile worldTargetsFile_0;

	private WorldTargetsFile worldTargetsFile_1;

	private IContainer icontainer_0;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripMenuItem toolStripMenuItem_5;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripSeparator toolStripSeparator_2;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private DataGridView dataGridView_0;

	private Button button_0;

	private Button button_1;

	private OpenFileDialog openFileDialog_0;

	private OpenFileDialog openFileDialog_1;

	private GroupBox groupBox_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private GroupBox groupBox_1;

	private TextBox textBox_3;

	private Label label_3;

	private TextBox textBox_4;

	private TextBox textBox_5;

	private Label label_4;

	private Label label_5;

	private TextBox textBox_6;

	private ImageBox imageBox_0;

	private Button button_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private SaveFileDialog saveFileDialog_0;

	private SaveFileDialog saveFileDialog_1;

	private ComboBox comboBox_0;

	private Button button_3;

	private Label label_6;

	private ToolStripMenuItem toolStripMenuItem_6;

	private ToolStripMenuItem toolStripMenuItem_7;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private bool bool_0;

	public WorldTargetsEditor()
	{
		method_3();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		method_4();
	}

	[DllImport("Kernel32.dll")]
	private static extern bool ReadProcessMemory(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, int int_1, int int_2);

	private void method_0()
	{
		if (graphics_0 != null)
		{
			try
			{
				graphics_0.Dispose();
			}
			catch
			{
			}
			graphics_0 = null;
		}
	}

	private void method_1(Image image_0)
	{
		method_0();
		Image image = imageBox_0?.Image;
		if (imageBox_0 != null)
		{
			imageBox_0.Image = image_0;
		}
		if (image != null && image != image_0)
		{
			try
			{
				image.Dispose();
			}
			catch
			{
			}
		}
		if (imageBox_0?.Image != null)
		{
			graphics_0 = Graphics.FromImage(imageBox_0.Image);
		}
	}

	private void method_2()
	{
		try
		{
			fileBasedUndoManager_0?.Dispose();
		}
		catch
		{
		}
		fileBasedUndoManager_0 = null;
		method_0();
		if (imageBox_0?.Image != null)
		{
			try
			{
				Image image = imageBox_0.Image;
				imageBox_0.Image = null;
				image.Dispose();
			}
			catch
			{
			}
		}
		list_0?.Clear();
		worldTargetsFile_0 = null;
		worldTargetsFile_1 = null;
	}

	protected override void OnFormClosed(FormClosedEventArgs formClosedEventArgs_0)
	{
		method_2();
		base.OnFormClosed(formClosedEventArgs_0);
	}

	private void toolStripMenuItem_5_Click(object sender, EventArgs e)
	{
		Environment.Exit(0);
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		if (openFileDialog_0.ShowDialog() == DialogResult.OK)
		{
			EditorSessionTracker.LogFolderAccess(openFileDialog_0.FileName, Class16.smethod_0(1649006856), Class16.smethod_0(1649270961));
			worldTargetsFile_0 = new WorldTargetsFile();
			BinaryReader binaryReader = new BinaryReader(File.Open(openFileDialog_0.FileName, FileMode.Open, FileAccess.Read, FileShare.Read));
			try
			{
				worldTargetsFile_0.ReadSevFile(binaryReader);
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
			SortPoints();
			method_8();
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		if (openFileDialog_1.ShowDialog() == DialogResult.OK)
		{
			EditorSessionTracker.LogFolderAccess(openFileDialog_1.FileName, Class16.smethod_0(1648903793), Class16.smethod_0(1649270961));
			worldTargetsFile_0 = new WorldTargetsFile();
			StreamReader streamReader = new StreamReader(openFileDialog_1.FileName, Encoding.Unicode);
			try
			{
				worldTargetsFile_0.ReadTxtFile(streamReader);
			}
			finally
			{
				((IDisposable)streamReader).Dispose();
			}
			SortPoints();
			method_8();
		}
	}

	public void SortPoints()
	{
		dataGridView_0.SuspendLayout();
		dataGridView_0.Rows.Clear();
		DataGridViewRow[] array = new DataGridViewRow[worldTargetsFile_0.TeleportAmount];
		for (int i = 0; i < worldTargetsFile_0.TeleportAmount; i++)
		{
			DataGridViewRow dataGridViewRow = new DataGridViewRow();
			dataGridViewRow.CreateCells(dataGridView_0, i + 1, worldTargetsFile_0.TeleportList[i].ID, worldTargetsFile_0.TeleportList[i].MapName);
			array[i] = dataGridViewRow;
		}
		dataGridView_0.Rows.AddRange(array);
		dataGridView_0.ResumeLayout(performLayout: false);
		dataGridView_0_CurrentCellChanged(null, null);
	}

	private void dataGridView_0_CurrentCellChanged(object sender, EventArgs e)
	{
		if (dataGridView_0.CurrentRow == null || dataGridView_0.CurrentRow.Index == -1)
		{
			return;
		}
		int_0 = dataGridView_0.CurrentRow.Index;
		list_0 = new List<int>();
		foreach (DataGridViewRow selectedRow in dataGridView_0.SelectedRows)
		{
			list_0.Add(selectedRow.Index);
		}
		textBox_6.Text = worldTargetsFile_0.TeleportList[int_0].MapName;
		textBox_2.Text = worldTargetsFile_0.TeleportList[int_0].ID.ToString();
		textBox_1.Text = worldTargetsFile_0.TeleportList[int_0].MapId.ToString();
		textBox_0.Text = worldTargetsFile_0.TeleportList[int_0].GroupId.ToString();
		textBox_5.Text = worldTargetsFile_0.TeleportList[int_0].X_position.ToString();
		textBox_4.Text = worldTargetsFile_0.TeleportList[int_0].Y_position.ToString();
		textBox_3.Text = worldTargetsFile_0.TeleportList[int_0].Z_position.ToString();
		if (graphics_0 != null && imageBox_0.Image != null)
		{
			try
			{
				float num = worldTargetsFile_0.TeleportList[int_0].X_position + (float)(imageBox_0.Image.Width / 2) - 10f;
				float num2 = Math.Abs(worldTargetsFile_0.TeleportList[int_0].Z_position - (float)(imageBox_0.Image.Height / 2)) - 8f;
				graphics_0.DrawImage(Resources.arrowimage, num, num2);
				imageBox_0.ScrollTo(Convert.ToInt32(worldTargetsFile_0.TeleportList[int_0].X_position + (float)(imageBox_0.Image.Width / 2)) - imageBox_0.DisplayRectangle.Width / 2, Convert.ToInt32(Math.Abs(worldTargetsFile_0.TeleportList[int_0].Z_position - (float)(imageBox_0.Image.Height / 2))) - imageBox_0.DisplayRectangle.Height / 2);
				imageBox_0.Refresh();
			}
			catch (OverflowException)
			{
			}
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		string path = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1649270989));
		if (!File.Exists(path))
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649271005)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
		try
		{
			Bitmap bitmap = new Bitmap(fileStream);
			try
			{
				method_1(new Bitmap(bitmap));
			}
			finally
			{
				((IDisposable)bitmap).Dispose();
			}
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}

	private void textBox_6_Leave(object sender, EventArgs e)
	{
		method_11(sender as Control, bool_1: true);
	}

	private void textBox_6_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			textBox_6_Leave(sender, new EventArgs());
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (worldTargetsFile_0 == null || dataGridView_0.Rows.Count <= 0 || list_0 == null || list_0.Count <= 0)
		{
			return;
		}
		method_7();
		dataGridView_0.ScrollBars = ScrollBars.None;
		list_0 = list_0.OrderBy(Class386.class386_0.method_0).ToList();
		foreach (int item in list_0)
		{
			worldTargetsFile_0.TeleportAmount++;
			FileStructure fileStructure = new FileStructure();
			fileStructure.ID = worldTargetsFile_0.TeleportList[item].ID;
			fileStructure.MapId = worldTargetsFile_0.TeleportList[item].MapId;
			fileStructure.MapName = worldTargetsFile_0.TeleportList[item].MapName;
			fileStructure.X_position = worldTargetsFile_0.TeleportList[item].X_position;
			fileStructure.Y_position = worldTargetsFile_0.TeleportList[item].Y_position;
			fileStructure.Z_position = worldTargetsFile_0.TeleportList[item].Z_position;
			worldTargetsFile_0.TeleportList.Add(fileStructure);
			dataGridView_0.Rows.Add(worldTargetsFile_0.TeleportAmount, dataGridView_0.Rows[item].Cells[1].Value, dataGridView_0.Rows[item].Cells[2].Value);
		}
		dataGridView_0.ScrollBars = ScrollBars.Vertical;
		List<int> list = list_0;
		dataGridView_0.CurrentCell = dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[1];
		for (int i = 1; i <= list.Count; i++)
		{
			dataGridView_0.Rows[dataGridView_0.Rows.Count - i].Selected = true;
		}
		dataGridView_0_CurrentCellChanged(null, null);
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
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(WorldTargetsEditor));
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		toolStripSeparator_1 = new ToolStripSeparator();
		toolStripMenuItem_5 = new ToolStripMenuItem();
		toolStripMenuItem_6 = new ToolStripMenuItem();
		toolStripMenuItem_7 = new ToolStripMenuItem();
		toolStrip_0 = new ToolStrip();
		toolStripButton_0 = new ToolStripButton();
		toolStripButton_1 = new ToolStripButton();
		toolStripSeparator_2 = new ToolStripSeparator();
		toolStripButton_2 = new ToolStripButton();
		toolStripButton_3 = new ToolStripButton();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		openFileDialog_0 = new OpenFileDialog();
		openFileDialog_1 = new OpenFileDialog();
		groupBox_0 = new GroupBox();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		textBox_2 = new TextBox();
		label_0 = new Label();
		label_1 = new Label();
		label_2 = new Label();
		groupBox_1 = new GroupBox();
		comboBox_0 = new ComboBox();
		button_3 = new Button();
		textBox_3 = new TextBox();
		label_3 = new Label();
		textBox_4 = new TextBox();
		textBox_5 = new TextBox();
		label_4 = new Label();
		label_5 = new Label();
		label_6 = new Label();
		textBox_6 = new TextBox();
		imageBox_0 = new ImageBox();
		button_2 = new Button();
		saveFileDialog_0 = new SaveFileDialog();
		saveFileDialog_1 = new SaveFileDialog();
		button_1 = new Button();
		button_0 = new Button();
		menuStrip_0.SuspendLayout();
		toolStrip_0.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		groupBox_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		SuspendLayout();
		menuStrip_0.Items.AddRange(new ToolStripItem[3] { toolStripMenuItem_0, toolStripMenuItem_6, toolStripMenuItem_7 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1648931410);
		menuStrip_0.Size = new Size(678, 24);
		menuStrip_0.TabIndex = 0;
		menuStrip_0.Text = Class16.smethod_0(1648931410);
		toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[7] { toolStripMenuItem_1, toolStripMenuItem_2, toolStripSeparator_0, toolStripMenuItem_3, toolStripMenuItem_4, toolStripSeparator_1, toolStripMenuItem_5 });
		toolStripMenuItem_0.Name = Class16.smethod_0(1648916926);
		toolStripMenuItem_0.Size = new Size(37, 20);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_1.Image = Resources.Open_sevImage;
		toolStripMenuItem_1.Name = Class16.smethod_0(1649271044);
		toolStripMenuItem_1.Size = new Size(203, 24);
		toolStripMenuItem_1.Text = Class16.smethod_0(1649271050);
		toolStripMenuItem_1.Click += toolStripButton_0_Click;
		toolStripMenuItem_2.Image = Resources.Open_cltImage;
		toolStripMenuItem_2.Name = Class16.smethod_0(1649271087);
		toolStripMenuItem_2.Size = new Size(203, 24);
		toolStripMenuItem_2.Text = Class16.smethod_0(1649271101);
		toolStripMenuItem_2.Click += toolStripButton_1_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1648920981);
		toolStripSeparator_0.Size = new Size(200, 6);
		toolStripMenuItem_3.Image = Resources.Save_sevImage;
		toolStripMenuItem_3.Name = Class16.smethod_0(1649271122);
		toolStripMenuItem_3.Size = new Size(203, 24);
		toolStripMenuItem_3.Text = Class16.smethod_0(1649271136);
		toolStripMenuItem_3.Click += toolStripButton_2_Click;
		toolStripMenuItem_4.Image = Resources.Save_cltImage;
		toolStripMenuItem_4.Name = Class16.smethod_0(1649271173);
		toolStripMenuItem_4.Size = new Size(203, 24);
		toolStripMenuItem_4.Text = Class16.smethod_0(1649271179);
		toolStripMenuItem_4.Click += toolStripButton_3_Click;
		toolStripSeparator_1.Name = Class16.smethod_0(1648921077);
		toolStripSeparator_1.Size = new Size(200, 6);
		toolStripMenuItem_5.Image = Resources.exitImage;
		toolStripMenuItem_5.ImageScaling = ToolStripItemImageScaling.None;
		toolStripMenuItem_5.Name = Class16.smethod_0(1649271208);
		toolStripMenuItem_5.Size = new Size(203, 24);
		toolStripMenuItem_5.Text = Class16.smethod_0(1648920914);
		toolStripMenuItem_5.Click += toolStripMenuItem_5_Click;
		toolStripMenuItem_6.Name = Class16.smethod_0(1649271238);
		toolStripMenuItem_6.Size = new Size(87, 20);
		toolStripMenuItem_6.Text = Class16.smethod_0(1649271264);
		toolStripMenuItem_6.Click += toolStripMenuItem_6_Click;
		toolStripMenuItem_7.Name = Class16.smethod_0(1649271282);
		toolStripMenuItem_7.Size = new Size(100, 20);
		toolStripMenuItem_7.Text = Class16.smethod_0(1649274397);
		toolStripMenuItem_7.Click += toolStripMenuItem_7_Click;
		toolStrip_0.Items.AddRange(new ToolStripItem[5] { toolStripButton_0, toolStripButton_1, toolStripSeparator_2, toolStripButton_2, toolStripButton_3 });
		toolStrip_0.Location = new Point(0, 24);
		toolStrip_0.Name = Class16.smethod_0(1649107758);
		toolStrip_0.Size = new Size(678, 25);
		toolStrip_0.TabIndex = 1;
		toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_0.Image = Resources.Open_sevImage;
		toolStripButton_0.ImageTransparentColor = Color.Magenta;
		toolStripButton_0.Name = Class16.smethod_0(1649274408);
		toolStripButton_0.Size = new Size(23, 22);
		toolStripButton_0.Text = Class16.smethod_0(1649176097);
		toolStripButton_0.ToolTipText = Class16.smethod_0(1649274431);
		toolStripButton_0.Click += toolStripButton_0_Click;
		toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_1.Image = Resources.Open_cltImage;
		toolStripButton_1.ImageTransparentColor = Color.Magenta;
		toolStripButton_1.Name = Class16.smethod_0(1649274460);
		toolStripButton_1.Size = new Size(23, 22);
		toolStripButton_1.Text = Class16.smethod_0(1649274467);
		toolStripButton_1.ToolTipText = Class16.smethod_0(1649274490);
		toolStripButton_1.Click += toolStripButton_1_Click;
		toolStripSeparator_2.Name = Class16.smethod_0(1649036149);
		toolStripSeparator_2.Size = new Size(6, 25);
		toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_2.Image = Resources.Save_sevImage;
		toolStripButton_2.ImageTransparentColor = Color.Magenta;
		toolStripButton_2.Name = Class16.smethod_0(1649274527);
		toolStripButton_2.Size = new Size(23, 22);
		toolStripButton_2.Text = Class16.smethod_0(1649109208);
		toolStripButton_2.ToolTipText = Class16.smethod_0(1649274542);
		toolStripButton_2.Click += toolStripButton_2_Click;
		toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_3.Image = Resources.Save_cltImage;
		toolStripButton_3.ImageTransparentColor = Color.Magenta;
		toolStripButton_3.Name = Class16.smethod_0(1649274563);
		toolStripButton_3.Size = new Size(23, 22);
		toolStripButton_3.Text = Class16.smethod_0(1649109239);
		toolStripButton_3.ToolTipText = Class16.smethod_0(1649274578);
		toolStripButton_3.Click += toolStripButton_3_Click;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dataGridView_0.BackgroundColor = Color.FromArgb(15, 15, 15);
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
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1, dataGridViewTextBoxColumn_2);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle2;
		dataGridView_0.EnableHeadersVisualStyles = false;
		dataGridView_0.Location = new Point(0, 52);
		dataGridView_0.Name = Class16.smethod_0(1649274615);
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.ScrollBars = ScrollBars.Vertical;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellErrors = false;
		dataGridView_0.ShowCellToolTips = false;
		dataGridView_0.ShowEditingIcon = false;
		dataGridView_0.ShowRowErrors = false;
		dataGridView_0.Size = new Size(322, 425);
		dataGridView_0.TabIndex = 16;
		dataGridView_0.CurrentCellChanged += dataGridView_0_CurrentCellChanged;
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle3;
		dataGridViewTextBoxColumn_0.FillWeight = 6.912442f;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648929947);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648910847);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.Resizable = DataGridViewTriState.False;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 36;
		dataGridViewCellStyle4.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle4.ForeColor = Color.FromArgb(77, 255, 143);
		dataGridViewTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_1.FillWeight = 44.7233f;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1649118934);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648914199);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.Resizable = DataGridViewTriState.False;
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_1.Width = 84;
		dataGridViewCellStyle5.ForeColor = Color.White;
		dataGridViewTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle5;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648963847);
		dataGridViewTextBoxColumn_2.ReadOnly = true;
		dataGridViewTextBoxColumn_2.Resizable = DataGridViewTriState.False;
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_2.Width = 200;
		openFileDialog_0.DefaultExt = Class16.smethod_0(1649274627);
		openFileDialog_0.Filter = Class16.smethod_0(1649274645);
		openFileDialog_0.FileName = Class16.smethod_0(1649274679);
		openFileDialog_1.FileName = Class16.smethod_0(1649274703);
		openFileDialog_1.Filter = Class16.smethod_0(1649274727);
		groupBox_0.Controls.Add(textBox_0);
		groupBox_0.Controls.Add(textBox_1);
		groupBox_0.Controls.Add(textBox_2);
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Controls.Add(label_2);
		groupBox_0.Location = new Point(329, 78);
		groupBox_0.Name = Class16.smethod_0(1648929126);
		groupBox_0.Size = new Size(151, 91);
		groupBox_0.TabIndex = 19;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1649089262);
		textBox_0.Location = new Point(69, 63);
		textBox_0.Name = Class16.smethod_0(1649274753);
		textBox_0.Size = new Size(69, 20);
		textBox_0.TabIndex = 5;
		textBox_0.KeyDown += textBox_6_KeyDown;
		textBox_0.Leave += textBox_6_Leave;
		textBox_1.Location = new Point(69, 42);
		textBox_1.Name = Class16.smethod_0(1649274781);
		textBox_1.Size = new Size(69, 20);
		textBox_1.TabIndex = 4;
		textBox_1.KeyDown += textBox_6_KeyDown;
		textBox_1.Leave += textBox_6_Leave;
		textBox_2.Location = new Point(69, 21);
		textBox_2.Name = Class16.smethod_0(1649274793);
		textBox_2.Size = new Size(69, 20);
		textBox_2.TabIndex = 3;
		textBox_2.KeyDown += textBox_6_KeyDown;
		textBox_2.Leave += textBox_6_Leave;
		label_0.AutoSize = true;
		label_0.Location = new Point(23, 66);
		label_0.Name = Class16.smethod_0(1648912145);
		label_0.Size = new Size(39, 13);
		label_0.TabIndex = 2;
		label_0.Text = Class16.smethod_0(1649112918);
		label_1.AutoSize = true;
		label_1.Location = new Point(13, 45);
		label_1.Name = Class16.smethod_0(1648912083);
		label_1.Size = new Size(45, 13);
		label_1.TabIndex = 1;
		label_1.Text = Class16.smethod_0(1649274810);
		label_2.AutoSize = true;
		label_2.Location = new Point(47, 24);
		label_2.Name = Class16.smethod_0(1648919238);
		label_2.Size = new Size(21, 13);
		label_2.TabIndex = 0;
		label_2.Text = Class16.smethod_0(1648930840);
		groupBox_1.Controls.Add(comboBox_0);
		groupBox_1.Controls.Add(button_3);
		groupBox_1.Controls.Add(textBox_3);
		groupBox_1.Controls.Add(label_3);
		groupBox_1.Controls.Add(textBox_4);
		groupBox_1.Controls.Add(textBox_5);
		groupBox_1.Controls.Add(label_4);
		groupBox_1.Controls.Add(label_5);
		groupBox_1.Controls.Add(label_6);
		groupBox_1.Location = new Point(484, 78);
		groupBox_1.Name = Class16.smethod_0(1648929037);
		groupBox_1.Size = new Size(192, 91);
		groupBox_1.TabIndex = 3;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1649274824);
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[8]
		{
			Class16.smethod_0(1649274842),
			Class16.smethod_0(1649274862),
			Class16.smethod_0(1649274878),
			Class16.smethod_0(1649175824),
			Class16.smethod_0(1649273870),
			Class16.smethod_0(1649175864),
			Class16.smethod_0(1649273886),
			Class16.smethod_0(1649273901)
		});
		comboBox_0.Location = new Point(104, 24);
		comboBox_0.Name = Class16.smethod_0(1649273918);
		comboBox_0.Size = new Size(87, 21);
		comboBox_0.TabIndex = 10;
		button_3.Location = new Point(104, 45);
		button_3.Name = Class16.smethod_0(1649273941);
		button_3.Size = new Size(87, 44);
		button_3.TabIndex = 9;
		button_3.Text = Class16.smethod_0(1649108671);
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		textBox_3.Location = new Point(29, 63);
		textBox_3.Name = Class16.smethod_0(1649273973);
		textBox_3.Size = new Size(69, 20);
		textBox_3.TabIndex = 8;
		textBox_3.KeyDown += textBox_6_KeyDown;
		textBox_3.Leave += textBox_6_Leave;
		label_3.AutoSize = true;
		label_3.Location = new Point(6, 45);
		label_3.Name = Class16.smethod_0(1648930240);
		label_3.Size = new Size(17, 13);
		label_3.TabIndex = 6;
		label_3.Text = Class16.smethod_0(1649013950);
		textBox_4.Location = new Point(29, 42);
		textBox_4.Name = Class16.smethod_0(1649273989);
		textBox_4.Size = new Size(69, 20);
		textBox_4.TabIndex = 7;
		textBox_4.KeyDown += textBox_6_KeyDown;
		textBox_4.Leave += textBox_6_Leave;
		textBox_5.Location = new Point(29, 21);
		textBox_5.Name = Class16.smethod_0(1649274005);
		textBox_5.Size = new Size(69, 20);
		textBox_5.TabIndex = 6;
		textBox_5.KeyDown += textBox_6_KeyDown;
		textBox_5.Leave += textBox_6_Leave;
		label_4.AutoSize = true;
		label_4.Location = new Point(6, 66);
		label_4.Name = Class16.smethod_0(1648912262);
		label_4.Size = new Size(17, 13);
		label_4.TabIndex = 5;
		label_4.Text = Class16.smethod_0(1649111438);
		label_5.AutoSize = true;
		label_5.Location = new Point(6, 24);
		label_5.Name = Class16.smethod_0(1648912200);
		label_5.Size = new Size(17, 13);
		label_5.TabIndex = 4;
		label_5.Text = Class16.smethod_0(1649013968);
		label_6.AutoSize = true;
		label_6.Location = new Point(105, 8);
		label_6.Name = Class16.smethod_0(1648930206);
		label_6.Size = new Size(70, 13);
		label_6.TabIndex = 11;
		label_6.Text = Class16.smethod_0(1649274021);
		textBox_6.Location = new Point(329, 52);
		textBox_6.Name = Class16.smethod_0(1649274034);
		textBox_6.Size = new Size(346, 20);
		textBox_6.TabIndex = 20;
		textBox_6.TextAlign = HorizontalAlignment.Center;
		textBox_6.KeyDown += textBox_6_KeyDown;
		textBox_6.Leave += textBox_6_Leave;
		imageBox_0.Location = new Point(329, 175);
		imageBox_0.Name = Class16.smethod_0(1649274061);
		imageBox_0.Size = new Size(346, 302);
		imageBox_0.TabIndex = 21;
		imageBox_0.TabStop = false;
		button_2.Location = new Point(329, 478);
		button_2.Name = Class16.smethod_0(1649274076);
		button_2.Size = new Size(346, 33);
		button_2.TabIndex = 22;
		button_2.Text = Class16.smethod_0(1649274082);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		saveFileDialog_0.FileName = Class16.smethod_0(1649274107);
		saveFileDialog_0.Filter = Class16.smethod_0(1649274645);
		saveFileDialog_1.FileName = Class16.smethod_0(1649274131);
		saveFileDialog_1.Filter = Class16.smethod_0(1649274727);
		button_1.Image = Resources.NpcGenEditorForm_remove;
		button_1.Location = new Point(162, 478);
		button_1.Name = Class16.smethod_0(1648925718);
		button_1.Size = new Size(161, 33);
		button_1.TabIndex = 18;
		button_1.Text = Class16.smethod_0(1648925718);
		button_1.TextAlign = ContentAlignment.MiddleRight;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_0.Image = Resources.cmdAddItem;
		button_0.Location = new Point(0, 478);
		button_0.Name = Class16.smethod_0(1648931361);
		button_0.Size = new Size(160, 33);
		button_0.TabIndex = 17;
		button_0.Text = Class16.smethod_0(1648931357);
		button_0.TextAlign = ContentAlignment.MiddleRight;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(678, 511);
		base.Controls.Add(button_2);
		base.Controls.Add(imageBox_0);
		base.Controls.Add(groupBox_1);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(dataGridView_0);
		base.Controls.Add(toolStrip_0);
		base.Controls.Add(menuStrip_0);
		base.Controls.Add(textBox_6);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.edit;
		base.MainMenuStrip = menuStrip_0;
		base.MaximizeBox = false;
		base.Name = Class16.smethod_0(1649274155);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649274188);
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		toolStrip_0.ResumeLayout(performLayout: false);
		toolStrip_0.PerformLayout();
		((ISupportInitialize)dataGridView_0).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (worldTargetsFile_0 == null || dataGridView_0.Rows.Count == 0 || list_0 == null || list_0.Count == 0)
		{
			return;
		}
		method_7();
		list_0 = list_0.OrderByDescending(Class386.class386_0.method_1).ToList();
		dataGridView_0.ScrollBars = ScrollBars.None;
		int num = list_0.Min();
		dataGridView_0.ClearSelection();
		worldTargetsFile_0.TeleportAmount -= list_0.Count;
		foreach (int item in list_0)
		{
			worldTargetsFile_0.TeleportList.RemoveAt(item);
			dataGridView_0.Rows.RemoveAt(item);
		}
		dataGridView_0.ScrollBars = ScrollBars.Vertical;
		if (dataGridView_0.Rows.Count > num)
		{
			dataGridView_0.CurrentCell = dataGridView_0.Rows[num].Cells[1];
			dataGridView_0.FirstDisplayedScrollingRowIndex = num;
		}
		else if (dataGridView_0.Rows.Count != 0)
		{
			dataGridView_0.CurrentCell = dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[1];
			dataGridView_0.FirstDisplayedScrollingRowIndex = dataGridView_0.Rows.Count - 1;
		}
		dataGridView_0_CurrentCellChanged(null, null);
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		if (saveFileDialog_0.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		if (worldTargetsFile_0 != null)
		{
			EditorSessionTracker.LogFolderAccess(saveFileDialog_0.FileName, Class16.smethod_0(1649006856), Class16.smethod_0(1649270961));
			BinaryWriter binaryWriter = new BinaryWriter(File.Create(saveFileDialog_0.FileName));
			try
			{
				worldTargetsFile_0.WriteSevFile(binaryWriter);
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649274215)), TextStorage.Msg(Class16.smethod_0(1649274247), Class16.smethod_0(1649274188)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649274279)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		ClassPosition coordinates = GetCoordinates();
		if (coordinates != null)
		{
			method_7();
			textBox_5.Text = coordinates.PosX.ToString();
			textBox_4.Text = coordinates.PosY.ToString();
			textBox_3.Text = coordinates.PosZ.ToString();
			method_11(textBox_5, bool_1: false);
			method_11(textBox_4, bool_1: false);
			method_11(textBox_3, bool_1: false);
		}
	}

	public ClassPosition GetCoordinates()
	{
		Process[] processesByName = Process.GetProcessesByName(Class16.smethod_0(1649099831));
		if (processesByName.Length == 0)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649274306)), TextStorage.Msg(Class16.smethod_0(1649274350), Class16.smethod_0(1649144029)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return null;
		}
		if (comboBox_0.SelectedIndex != -1)
		{
			int[] array = new int[3];
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			Process[] processesByName2 = Process.GetProcessesByName(Class16.smethod_0(1649099831));
			IntPtr intptr_ = (IntPtr)0;
			if (processesByName2.Length != 0)
			{
				intptr_ = processesByName2[0].Handle;
			}
			byte[] array2 = new byte[4];
			int num4 = 0;
			switch (comboBox_0.SelectedIndex)
			{
			case 0:
				array[0] = 12635628;
				array[1] = 52;
				array[2] = 4892;
				num = 380;
				num2 = 384;
				num3 = 388;
				break;
			case 1:
				array[0] = 11698372;
				array[1] = 52;
				array[2] = 4328;
				num = 380;
				num2 = 384;
				num3 = 388;
				break;
			case 2:
				array[0] = 12124828;
				array[1] = 52;
				array[2] = 4568;
				num = 380;
				num2 = 384;
				num3 = 388;
				break;
			case 3:
				array[0] = 12635628;
				array[1] = 52;
				array[2] = 4892;
				num = 384;
				num2 = 388;
				num3 = 392;
				break;
			case 4:
				array[0] = 12817100;
				array[1] = 52;
				array[2] = 4928;
				num = 384;
				num2 = 388;
				num3 = 392;
				break;
			case 5:
				array[0] = 13069772;
				array[1] = 44;
				array[2] = 5152;
				num = 384;
				num2 = 388;
				num3 = 392;
				break;
			case 6:
				array[0] = 13095436;
				array[1] = 44;
				array[2] = 5152;
				num = 384;
				num2 = 388;
				num3 = 392;
				break;
			case 7:
				array[0] = 14304060;
				array[1] = 28;
				array[2] = 40;
				num = 60;
				num2 = 64;
				num3 = 68;
				break;
			}
			for (int i = 0; i < array.Length; i++)
			{
				ReadProcessMemory(intptr_, (IntPtr)(num4 + array[i]), array2, 4, 0);
				num4 = BitConverter.ToInt32(array2, 0);
			}
			ReadProcessMemory(intptr_, (IntPtr)(num4 + num), array2, 4, 0);
			float float_ = BitConverter.ToSingle(array2, 0);
			ReadProcessMemory(intptr_, (IntPtr)(num4 + num2), array2, 4, 0);
			float float_2 = BitConverter.ToSingle(array2, 0);
			ReadProcessMemory(intptr_, (IntPtr)(num4 + num3), array2, 4, 0);
			float float_3 = BitConverter.ToSingle(array2, 0);
			return new ClassPosition(float_, float_2, float_3);
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649273356)), TextStorage.Msg(Class16.smethod_0(1649274247), Class16.smethod_0(1649274188)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		return null;
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		if (worldTargetsFile_0 == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649274279)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		else if (saveFileDialog_1.ShowDialog() == DialogResult.OK)
		{
			StreamWriter streamWriter = new StreamWriter(saveFileDialog_1.FileName, append: false, Encoding.Unicode);
			try
			{
				worldTargetsFile_0.WriteTxtFile(streamWriter);
			}
			finally
			{
				((IDisposable)streamWriter).Dispose();
			}
		}
	}

	private void toolStripMenuItem_6_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		try
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				worldTargetsFile_1 = new WorldTargetsFile();
				StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.UTF8);
				try
				{
					worldTargetsFile_1.ReadTxtFile(streamReader);
					return;
				}
				finally
				{
					((IDisposable)streamReader).Dispose();
				}
			}
		}
		finally
		{
			((IDisposable)openFileDialog).Dispose();
		}
	}

	private void toolStripMenuItem_7_Click(object sender, EventArgs e)
	{
		Class385 @class = new Class385();
		@class.worldTargetsEditor_0 = this;
		if (worldTargetsFile_0 != null && worldTargetsFile_1 != null)
		{
			method_7();
			@class.int_0 = 0;
			while (@class.int_0 < worldTargetsFile_0.TeleportAmount)
			{
				FileStructure fileStructure = worldTargetsFile_1.TeleportList.Find(@class.method_0);
				if (fileStructure != null)
				{
					worldTargetsFile_0.TeleportList[@class.int_0].MapName = fileStructure.MapName;
				}
				@class.int_0++;
			}
			SortPoints();
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649273395)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_4()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1649273436), 100);
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_5, method_6);
		fileBasedUndoManager_0.AttachToToolStrip(toolStrip_0, method_12, method_13);
	}

	private byte[] method_5()
	{
		if (worldTargetsFile_0?.TeleportList == null)
		{
			return null;
		}
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					binaryWriter.Write(worldTargetsFile_0.TeleportList.Count);
					foreach (FileStructure teleport in worldTargetsFile_0.TeleportList)
					{
						binaryWriter.Write(teleport.ID);
						binaryWriter.Write(teleport.MapId);
						binaryWriter.Write(teleport.MapName ?? string.Empty);
						binaryWriter.Write(teleport.X_position);
						binaryWriter.Write(teleport.Y_position);
						binaryWriter.Write(teleport.Z_position);
						binaryWriter.Write(teleport.GroupId);
					}
					binaryWriter.Write(dataGridView_0?.CurrentRow?.Index ?? (-1));
					DataGridView dataGridView = dataGridView_0;
					object obj;
					if (dataGridView == null)
					{
						obj = null;
					}
					else
					{
						obj = dataGridView.SelectedRows.Cast<DataGridViewRow>().Select(Class386.class386_0.method_2).OrderBy(Class386.class386_0.method_3)
							.ToArray();
						if (obj != null)
						{
							goto IL_017f;
						}
					}
					obj = Array.Empty<int>();
					goto IL_017f;
					IL_017f:
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

	private void method_6(byte[] byte_0)
	{
		if (byte_0 == null || byte_0.Length == 0)
		{
			return;
		}
		bool_0 = true;
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_0);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					int num = binaryReader.ReadInt32();
					List<FileStructure> list = new List<FileStructure>(num);
					for (int i = 0; i < num; i++)
					{
						list.Add(new FileStructure
						{
							ID = binaryReader.ReadInt32(),
							MapId = binaryReader.ReadInt32(),
							MapName = binaryReader.ReadString(),
							X_position = binaryReader.ReadSingle(),
							Y_position = binaryReader.ReadSingle(),
							Z_position = binaryReader.ReadSingle(),
							GroupId = binaryReader.ReadInt32()
						});
					}
					worldTargetsFile_0 = new WorldTargetsFile
					{
						TeleportList = list
					};
					worldTargetsFile_0.TeleportAmount = worldTargetsFile_0.TeleportList.Count;
					int int_ = binaryReader.ReadInt32();
					int num2 = binaryReader.ReadInt32();
					int[] array = new int[num2];
					for (int j = 0; j < num2; j++)
					{
						array[j] = binaryReader.ReadInt32();
					}
					SortPoints();
					method_9(int_, array);
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
		}
	}

	private void method_7()
	{
		if (!bool_0)
		{
			byte[] array = method_5();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
		}
	}

	private void method_8()
	{
		fileBasedUndoManager_0?.Clear();
	}

	private void method_9(int int_1, int[] int_2)
	{
		if (dataGridView_0 == null || dataGridView_0.Rows.Count == 0)
		{
			return;
		}
		int_1 = method_10(int_1);
		dataGridView_0.ClearSelection();
		if (int_1 >= 0)
		{
			dataGridView_0.CurrentCell = dataGridView_0.Rows[int_1].Cells[1];
		}
		bool flag = false;
		int[] array = int_2 ?? Array.Empty<int>();
		foreach (int int_3 in array)
		{
			int num = method_10(int_3);
			if (num >= 0)
			{
				dataGridView_0.Rows[num].Selected = true;
				flag = true;
			}
		}
		if (!flag && int_1 >= 0)
		{
			dataGridView_0.Rows[int_1].Selected = true;
		}
		if (int_1 >= 0)
		{
			dataGridView_0.FirstDisplayedScrollingRowIndex = int_1;
			dataGridView_0_CurrentCellChanged(null, null);
		}
	}

	private int method_10(int int_1)
	{
		if (dataGridView_0 != null && dataGridView_0.Rows.Count != 0)
		{
			if (int_1 < 0)
			{
				return 0;
			}
			return Math.Min(int_1, dataGridView_0.Rows.Count - 1);
		}
		return -1;
	}

	private void method_11(Control control_0, bool bool_1)
	{
		if (bool_0 || worldTargetsFile_0 == null || list_0 == null || list_0.Count == 0 || control_0 == null)
		{
			return;
		}
		if (bool_1)
		{
			method_7();
		}
		string name = control_0.Name;
		if (name == null)
		{
			return;
		}
		switch (name.Length)
		{
		case 9:
			switch (name[0])
			{
			case 'X':
				if (!(name == Class16.smethod_0(1649274005)))
				{
					break;
				}
				{
					foreach (int item in list_0)
					{
						if (item < worldTargetsFile_0.TeleportList.Count)
						{
							float.TryParse(textBox_5.Text, out worldTargetsFile_0.TeleportList[item].X_position);
						}
					}
					break;
				}
			case 'Y':
				if (!(name == Class16.smethod_0(1649273989)))
				{
					break;
				}
				{
					foreach (int item2 in list_0)
					{
						if (item2 < worldTargetsFile_0.TeleportList.Count)
						{
							float.TryParse(textBox_4.Text, out worldTargetsFile_0.TeleportList[item2].Y_position);
						}
					}
					break;
				}
			case 'Z':
				if (!(name == Class16.smethod_0(1649273973)))
				{
					break;
				}
				{
					foreach (int item3 in list_0)
					{
						if (item3 < worldTargetsFile_0.TeleportList.Count)
						{
							float.TryParse(textBox_3.Text, out worldTargetsFile_0.TeleportList[item3].Z_position);
						}
					}
					break;
				}
			}
			break;
		case 10:
			if (!(name == Class16.smethod_0(1649274793)))
			{
				break;
			}
			{
				foreach (int item4 in list_0)
				{
					if (item4 < worldTargetsFile_0.TeleportList.Count)
					{
						int.TryParse(textBox_2.Text, out worldTargetsFile_0.TeleportList[item4].ID);
						dataGridView_0.Rows[item4].Cells[1].Value = textBox_2.Text;
					}
				}
				break;
			}
		case 12:
			if (!(name == Class16.smethod_0(1649274034)))
			{
				break;
			}
			{
				foreach (int item5 in list_0)
				{
					if (item5 < worldTargetsFile_0.TeleportList.Count)
					{
						worldTargetsFile_0.TeleportList[item5].MapName = textBox_6.Text;
						dataGridView_0.Rows[item5].Cells[2].Value = textBox_6.Text;
					}
				}
				break;
			}
		case 13:
			switch (name[0])
			{
			case 'M':
				if (!(name == Class16.smethod_0(1649274781)))
				{
					break;
				}
				{
					foreach (int item6 in list_0)
					{
						if (item6 < worldTargetsFile_0.TeleportList.Count)
						{
							int.TryParse(textBox_1.Text, out worldTargetsFile_0.TeleportList[item6].MapId);
						}
					}
					break;
				}
			case 'G':
				if (!(name == Class16.smethod_0(1649274753)))
				{
					break;
				}
				{
					foreach (int item7 in list_0)
					{
						if (item7 < worldTargetsFile_0.TeleportList.Count)
						{
							int.TryParse(textBox_0.Text, out worldTargetsFile_0.TeleportList[item7].GroupId);
						}
					}
					break;
				}
			}
			break;
		case 11:
			break;
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		byte[] currentState = method_5();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_6(array);
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		byte[] currentState = method_5();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_6(array);
		}
	}
}
