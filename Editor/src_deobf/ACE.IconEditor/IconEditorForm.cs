using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.IconEditor;

public sealed class IconEditorForm : Form
{
	private sealed class Class145
	{
		public int int_0;

		internal bool method_0(IconEntry iconEntry_0)
		{
			if (int_0 >= iconEntry_0.StartIndex)
			{
				return int_0 < iconEntry_0.StartIndex + Math.Max(1, iconEntry_0.FrameCount);
			}
			return false;
		}
	}

	private sealed class Class146
	{
		public HashSet<IconEntry> hashSet_0;

		internal bool method_0(IconEntry iconEntry_0)
		{
			return !hashSet_0.Contains(iconEntry_0);
		}
	}

	[Serializable]
	private sealed class Class147
	{
		public static readonly Class147 class147_0 = new Class147();

		public static Func<IconEntry, int> func_0;

		public static Func<IconEntry, int> func_1;

		public static Func<IconEntry, int> func_2;

		internal int method_0(IconEntry iconEntry_0)
		{
			return iconEntry_0.StartIndex;
		}

		internal int method_1(IconEntry iconEntry_0)
		{
			return iconEntry_0.StartIndex;
		}

		internal int method_2(IconEntry iconEntry_0)
		{
			return iconEntry_0.StartIndex;
		}
	}

	private IconSheet iconSheet_0;

	private IconEntry iconEntry_0;

	private int int_0;

	private int int_1 = -1;

	private bool bool_0;

	private IContainer icontainer_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private ToolStripButton toolStripButton_4;

	private ToolStripComboBox toolStripComboBox_0;

	private ListBox listBox_0;

	private Label label_0;

	private Panel panel_0;

	private SpritesheetCanvas spritesheetCanvas_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private PictureBox pictureBox_0;

	private Timer timer_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	public IconEditorForm()
	{
		method_2();
		method_0();
		TextStorage.TEXTS.SetFormLanguage(this);
		base.Activated += IconEditorForm_Activated;
	}

	private void method_0()
	{
		try
		{
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			if (base.IsHandleCreated)
			{
				TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
			}
			TDark.ApplyNativeDarkThemeRecursive(this);
		}
		catch
		{
		}
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = Class16.smethod_0(1649050920),
			Title = TextStorage.Msg(Class16.smethod_0(1649050964), Class16.smethod_0(1649050997))
		};
		if (openFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			method_1(openFileDialog.FileName);
		}
	}

	private void method_1(string string_0)
	{
		Bitmap bitmap = DdsLoader.Load(string_0);
		if (bitmap == null)
		{
			MessageBox.Show(this, TextStorage.Msg(Class16.smethod_0(1649051011), Class16.smethod_0(1649051060)), TextStorage.Msg(Class16.smethod_0(1648934865), Class16.smethod_0(1648934892)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		string text = System.IO.Path.ChangeExtension(string_0, Class16.smethod_0(1648997294));
		IconTxtParser.LoadResult loadResult = IconTxtParser.Load(text);
		int num = method_19();
		if (loadResult.IsIconList && loadResult.IconListHeaderLines.Length >= 1 && int.TryParse(loadResult.IconListHeaderLines[0], out var result) && result > 0)
		{
			num = result;
			method_20(num);
			toolStripComboBox_0.SelectedItem = num.ToString();
		}
		Bitmap bitmap2 = iconSheet_0?.Image;
		iconSheet_0 = new IconSheet
		{
			DdsPath = string_0,
			TxtPath = text,
			Image = bitmap,
			IconSize = num,
			Entries = loadResult.Entries.OrderBy(Class147.class147_0.method_0).ToList(),
			IsIconListFormat = loadResult.IsIconList,
			IconListHeaderLines = loadResult.IconListHeaderLines
		};
		bitmap2?.Dispose();
		toolStripButton_1.Enabled = true;
		toolStripButton_2.Enabled = true;
		toolStripButton_3.Enabled = false;
		toolStripButton_4.Enabled = false;
		method_8(null);
		int_1 = -1;
		iconEntry_0 = null;
		tableLayoutPanel_0.Enabled = false;
		method_6();
		method_4();
		toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649051083), Class16.smethod_0(1649051112)), System.IO.Path.GetFileName(string_0));
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		if (iconSheet_0 != null && iconSheet_0.Image != null)
		{
			bool flag = IconTxtParser.Save(iconSheet_0);
			bool flag2 = DdsLoader.Save(iconSheet_0.Image, iconSheet_0.DdsPath);
			if (flag && flag2)
			{
				toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649051129), Class16.smethod_0(1649050140)), System.IO.Path.GetFileName(iconSheet_0.TxtPath), System.IO.Path.GetFileName(iconSheet_0.DdsPath));
				MessageBox.Show(this, TextStorage.Msg(Class16.smethod_0(1649050164), Class16.smethod_0(1649050206)), TextStorage.Msg(Class16.smethod_0(1649050238), Class16.smethod_0(1648941761)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show(this, string.Format(TextStorage.Msg(Class16.smethod_0(1649050258), Class16.smethod_0(1649050303)), flag ? Class16.smethod_0(1648938905) : Class16.smethod_0(1649050340), flag2 ? Class16.smethod_0(1648938905) : Class16.smethod_0(1649050340)), TextStorage.Msg(Class16.smethod_0(1649050238), Class16.smethod_0(1648941761)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		if (iconSheet_0 == null || iconSheet_0.Image == null)
		{
			return;
		}
		AddIconDialog addIconDialog = new AddIconDialog(iconSheet_0);
		try
		{
			if (addIconDialog.ShowDialog(this) == DialogResult.OK && addIconDialog.NewEntry != null && addIconDialog.ImageToAdd != null)
			{
				try
				{
					method_17(addIconDialog.ImageToAdd, addIconDialog.NewEntry.StartIndex, addIconDialog.SourceFrameSize, addIconDialog.NewEntry.FrameCount);
					iconSheet_0.Entries.Add(addIconDialog.NewEntry);
					iconSheet_0.Entries = iconSheet_0.Entries.OrderBy(Class147.class147_0.method_1).ToList();
					method_8(new IconEntry[1] { addIconDialog.NewEntry });
					method_4();
					method_10(addIconDialog.NewEntry);
					toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649050344));
					return;
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649050380));
					MessageBox.Show(this, ex.Message, TextStorage.Msg(Class16.smethod_0(1649050414), Class16.smethod_0(1649056356)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
		}
		finally
		{
			((IDisposable)addIconDialog).Dispose();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			icontainer_0?.Dispose();
			timer_0?.Dispose();
			iconSheet_0?.Image?.Dispose();
			if (pictureBox_0.Image != null)
			{
				pictureBox_0.Image.Dispose();
				pictureBox_0.Image = null;
			}
		}
		base.Dispose(disposing);
	}

	private void method_2()
	{
		toolStripButton_0 = new ToolStripButton();
		toolStripButton_1 = new ToolStripButton();
		toolStripButton_2 = new ToolStripButton();
		toolStripButton_3 = new ToolStripButton();
		toolStripButton_4 = new ToolStripButton();
		toolStripComboBox_0 = new ToolStripComboBox();
		listBox_0 = new ListBox();
		label_0 = new Label();
		panel_0 = new Panel();
		spritesheetCanvas_0 = new SpritesheetCanvas();
		tableLayoutPanel_0 = new TableLayoutPanel();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		textBox_2 = new TextBox();
		textBox_3 = new TextBox();
		pictureBox_0 = new PictureBox();
		timer_0 = new Timer();
		toolStripStatusLabel_0 = new ToolStripStatusLabel();
		((ISupportInitialize)pictureBox_0).BeginInit();
		SuspendLayout();
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		Text = Class16.smethod_0(1649050446);
		base.StartPosition = FormStartPosition.CenterScreen;
		base.ClientSize = new Size(1280, 820);
		MinimumSize = new Size(1000, 680);
		base.Name = Class16.smethod_0(1649050459);
		ToolStrip toolStrip = new ToolStrip();
		toolStrip.Dock = DockStyle.Top;
		toolStrip.GripStyle = ToolStripGripStyle.Hidden;
		toolStripButton_0.Text = Class16.smethod_0(1648931498);
		toolStripButton_0.Click += toolStripButton_0_Click;
		toolStrip.Items.Add(toolStripButton_0);
		toolStripButton_1.Text = Class16.smethod_0(1648941761);
		toolStripButton_1.Enabled = false;
		toolStripButton_1.Click += toolStripButton_1_Click;
		toolStrip.Items.Add(toolStripButton_1);
		toolStrip.Items.Add(new ToolStripSeparator());
		toolStripButton_2.Text = Class16.smethod_0(1649056356);
		toolStripButton_2.Enabled = false;
		toolStripButton_2.Click += toolStripButton_2_Click;
		toolStrip.Items.Add(toolStripButton_2);
		toolStripButton_3.Text = Class16.smethod_0(1648931371);
		toolStripButton_3.Enabled = false;
		toolStripButton_3.Click += toolStripButton_3_Click;
		toolStrip.Items.Add(toolStripButton_3);
		toolStripButton_4.Text = Class16.smethod_0(1648931384);
		toolStripButton_4.Enabled = false;
		toolStripButton_4.Click += toolStripButton_4_Click;
		toolStrip.Items.Add(toolStripButton_4);
		toolStrip.Items.Add(new ToolStripSeparator());
		toolStrip.Items.Add(new ToolStripLabel(Class16.smethod_0(1649050480)));
		toolStripComboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		toolStripComboBox_0.Width = 80;
		toolStripComboBox_0.Items.Add(Class16.smethod_0(1648935093));
		toolStripComboBox_0.Items.Add(Class16.smethod_0(1648911852));
		toolStripComboBox_0.Items.Add(Class16.smethod_0(1648935128));
		toolStripComboBox_0.SelectedIndex = 2;
		toolStripComboBox_0.SelectedIndexChanged += toolStripComboBox_0_SelectedIndexChanged;
		toolStrip.Items.Add(toolStripComboBox_0);
		base.Controls.Add(toolStrip);
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
		tableLayoutPanel.Dock = DockStyle.Fill;
		tableLayoutPanel.ColumnCount = 3;
		tableLayoutPanel.RowCount = 1;
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320f));
		base.Controls.Add(tableLayoutPanel);
		GroupBox groupBox = new GroupBox();
		groupBox.Text = Class16.smethod_0(1649050497);
		groupBox.Dock = DockStyle.Fill;
		groupBox.Padding = new Padding(8);
		tableLayoutPanel.Controls.Add(groupBox, 0, 0);
		listBox_0.Dock = DockStyle.Fill;
		listBox_0.SelectionMode = SelectionMode.MultiExtended;
		listBox_0.DrawMode = DrawMode.OwnerDrawFixed;
		listBox_0.ItemHeight = 20;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		listBox_0.DrawItem += listBox_0_DrawItem;
		groupBox.Controls.Add(listBox_0);
		GroupBox groupBox2 = new GroupBox();
		groupBox2.Text = Class16.smethod_0(1649050517);
		groupBox2.Dock = DockStyle.Fill;
		groupBox2.Padding = new Padding(8);
		tableLayoutPanel.Controls.Add(groupBox2, 1, 0);
		TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
		tableLayoutPanel2.Dock = DockStyle.Fill;
		tableLayoutPanel2.ColumnCount = 1;
		tableLayoutPanel2.RowCount = 2;
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		groupBox2.Controls.Add(tableLayoutPanel2);
		label_0.AutoSize = true;
		label_0.ForeColor = SystemColors.GrayText;
		label_0.Margin = new Padding(0, 0, 0, 8);
		label_0.Text = Class16.smethod_0(1649050535);
		tableLayoutPanel2.Controls.Add(label_0, 0, 0);
		panel_0.Dock = DockStyle.Fill;
		panel_0.AutoScroll = true;
		panel_0.BackColor = Color.FromArgb(26, 26, 26);
		tableLayoutPanel2.Controls.Add(panel_0, 0, 1);
		spritesheetCanvas_0.Location = Point.Empty;
		spritesheetCanvas_0.Size = new Size(1, 1);
		spritesheetCanvas_0.FrameClicked += method_3;
		panel_0.Controls.Add(spritesheetCanvas_0);
		GroupBox groupBox3 = new GroupBox();
		groupBox3.Text = Class16.smethod_0(1649050557);
		groupBox3.Dock = DockStyle.Fill;
		groupBox3.Padding = new Padding(8);
		tableLayoutPanel.Controls.Add(groupBox3, 2, 0);
		tableLayoutPanel_0.Dock = DockStyle.Fill;
		tableLayoutPanel_0.ColumnCount = 1;
		tableLayoutPanel_0.RowCount = 10;
		tableLayoutPanel_0.Enabled = false;
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		groupBox3.Controls.Add(tableLayoutPanel_0);
		tableLayoutPanel_0.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649050574),
			AutoSize = true
		}, 0, 0);
		textBox_0.ReadOnly = true;
		textBox_0.Dock = DockStyle.Top;
		tableLayoutPanel_0.Controls.Add(textBox_0, 0, 1);
		tableLayoutPanel_0.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1648936731),
			AutoSize = true
		}, 0, 2);
		textBox_1.Dock = DockStyle.Top;
		textBox_1.TextChanged += textBox_1_TextChanged;
		tableLayoutPanel_0.Controls.Add(textBox_1, 0, 3);
		tableLayoutPanel_0.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649050584),
			AutoSize = true
		}, 0, 4);
		textBox_2.ReadOnly = true;
		textBox_2.Dock = DockStyle.Top;
		tableLayoutPanel_0.Controls.Add(textBox_2, 0, 5);
		tableLayoutPanel_0.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649050602),
			AutoSize = true
		}, 0, 6);
		textBox_3.Dock = DockStyle.Top;
		textBox_3.TextChanged += textBox_3_TextChanged;
		tableLayoutPanel_0.Controls.Add(textBox_3, 0, 7);
		tableLayoutPanel_0.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1648992688),
			AutoSize = true
		}, 0, 8);
		Panel panel = new Panel();
		panel.Dock = DockStyle.Top;
		panel.Height = 160;
		panel.BackColor = Color.FromArgb(26, 26, 26);
		tableLayoutPanel_0.Controls.Add(panel, 0, 9);
		pictureBox_0.Size = new Size(128, 128);
		pictureBox_0.SizeMode = PictureBoxSizeMode.CenterImage;
		pictureBox_0.Location = new Point(16, 16);
		panel.Controls.Add(pictureBox_0);
		StatusStrip statusStrip = new StatusStrip();
		base.Controls.Add(statusStrip);
		toolStripStatusLabel_0.Text = Class16.smethod_0(1648920624);
		statusStrip.Items.Add(toolStripStatusLabel_0);
		timer_0.Interval = 100;
		timer_0.Tick += timer_0_Tick;
		((ISupportInitialize)pictureBox_0).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		Class146 @class = new Class146();
		if (iconSheet_0 == null || iconSheet_0.Image == null)
		{
			return;
		}
		List<IconEntry> list = method_9();
		if (list.Count == 0)
		{
			return;
		}
		DialogResult dialogResult = MessageBox.Show(this, string.Format(TextStorage.Msg(Class16.smethod_0(1649049620), Class16.smethod_0(1649049656)), list.Count), TextStorage.Msg(Class16.smethod_0(1649049718), Class16.smethod_0(1649049749)), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		@class.hashSet_0 = new HashSet<IconEntry>(list);
		List<IconEntry> list2 = iconSheet_0.Entries.Where(@class.method_0).OrderBy(Class147.class147_0.method_2).ToList();
		Bitmap image = new Bitmap(iconSheet_0.Image.Width, iconSheet_0.Image.Height, PixelFormat.Format32bppArgb);
		using (Graphics graphics = Graphics.FromImage(image))
		{
			graphics.Clear(Color.Transparent);
			graphics.CompositingMode = CompositingMode.SourceCopy;
			graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			graphics.PixelOffsetMode = PixelOffsetMode.Half;
			int num = 0;
			foreach (IconEntry item in list2)
			{
				int num2 = Math.Max(1, item.FrameCount);
				for (int i = 0; i < num2; i++)
				{
					int num3 = item.StartIndex + i;
					if (num3 >= 0 && num3 < iconSheet_0.TotalFrames)
					{
						Point framePosition = iconSheet_0.GetFramePosition(num3);
						Point framePosition2 = iconSheet_0.GetFramePosition(num + i);
						graphics.DrawImage(iconSheet_0.Image, new Rectangle(framePosition2.X, framePosition2.Y, iconSheet_0.IconSize, iconSheet_0.IconSize), new Rectangle(framePosition.X, framePosition.Y, iconSheet_0.IconSize, iconSheet_0.IconSize), GraphicsUnit.Pixel);
					}
				}
				item.StartIndex = num;
				num += num2;
			}
		}
		Bitmap image2 = iconSheet_0.Image;
		iconSheet_0.Image = image;
		image2.Dispose();
		iconSheet_0.Entries = list2;
		method_8(null);
		iconEntry_0 = null;
		int_1 = -1;
		tableLayoutPanel_0.Enabled = false;
		method_6();
		method_13();
		method_4();
		toolStripButton_3.Enabled = false;
		toolStripButton_4.Enabled = false;
		toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649049755), Class16.smethod_0(1649049787)), list.Count);
	}

	private void toolStripButton_4_Click(object sender, EventArgs e)
	{
		if (iconSheet_0 == null || iconSheet_0.Image == null)
		{
			return;
		}
		List<IconEntry> list = method_9();
		if (list.Count == 0)
		{
			return;
		}
		string text = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(iconSheet_0.DdsPath) ?? Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), Class16.smethod_0(1648931384));
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		ExportOptionsDialog exportOptionsDialog = new ExportOptionsDialog(text);
		try
		{
			if (exportOptionsDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			int num = 0;
			try
			{
				foreach (IconEntry item in list)
				{
					bool flag = exportOptionsDialog.SelectedFormat switch
					{
						ExportOptionsDialog.ExportFormat.Dds => true, 
						ExportOptionsDialog.ExportFormat.Png => false, 
						_ => item.Name.EndsWith(Class16.smethod_0(1648904847), StringComparison.OrdinalIgnoreCase), 
					};
					string text2 = smethod_3(item.Name);
					if (string.IsNullOrWhiteSpace(text2))
					{
						text2 = string.Format(Class16.smethod_0(1649049821), item.StartIndex);
					}
					if (!flag && text2.EndsWith(Class16.smethod_0(1648904847), StringComparison.OrdinalIgnoreCase))
					{
						string text3 = text2;
						text2 = text3.Substring(0, text3.Length - 4);
					}
					string text4 = (flag ? Class16.smethod_0(1648904847) : Class16.smethod_0(1649008311));
					if (!text2.EndsWith(text4, StringComparison.OrdinalIgnoreCase))
					{
						text2 += text4;
					}
					string string_ = System.IO.Path.Combine(exportOptionsDialog.SelectedPath, text2);
					string_ = smethod_4(string_);
					using Bitmap bitmap = iconSheet_0.GetFrame(item.StartIndex);
					if (bitmap != null && (flag ? DdsLoader.Save(bitmap, string_) : smethod_2(bitmap, string_)))
					{
						num++;
					}
				}
				MessageBox.Show(this, string.Format(TextStorage.Msg(Class16.smethod_0(1649049836), Class16.smethod_0(1649049871)), num, exportOptionsDialog.SelectedPath), TextStorage.Msg(Class16.smethod_0(1649049898), Class16.smethod_0(1648931384)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				try
				{
					Process.Start(new ProcessStartInfo(Class16.smethod_0(1649049928), exportOptionsDialog.SelectedPath)
					{
						UseShellExecute = true
					});
				}
				catch
				{
				}
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649049947));
				MessageBox.Show(this, ex.Message, TextStorage.Msg(Class16.smethod_0(1649049898), Class16.smethod_0(1648931384)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		finally
		{
			((IDisposable)exportOptionsDialog).Dispose();
		}
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		List<IconEntry> list = method_9();
		toolStripButton_3.Enabled = list.Count > 0;
		toolStripButton_4.Enabled = list.Count > 0;
		if (list.Count == 1)
		{
			iconEntry_0 = list[0];
			tableLayoutPanel_0.Enabled = true;
			method_5(iconEntry_0);
			method_12(iconEntry_0);
			method_11(iconEntry_0.StartIndex);
			toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649049984), Class16.smethod_0(1648993479)), iconEntry_0.Name);
		}
		else
		{
			iconEntry_0 = null;
			tableLayoutPanel_0.Enabled = false;
			method_6();
			method_13();
			toolStripStatusLabel_0.Text = ((list.Count > 1) ? string.Format(TextStorage.Msg(Class16.smethod_0(1649050060), Class16.smethod_0(1649050091)), list.Count) : TextStorage.Msg(Class16.smethod_0(1649050030), Class16.smethod_0(1648920624)));
		}
		method_7();
	}

	private void listBox_0_DrawItem(object sender, DrawItemEventArgs e)
	{
		if (e.Index >= 0 && e.Index < listBox_0.Items.Count)
		{
			e.DrawBackground();
			if (listBox_0.Items[e.Index] is IconEntry iconEntry)
			{
				string text = string.Format(Class16.smethod_0(1649053196), iconEntry.StartIndex, iconEntry.Name, iconEntry.FrameCount);
				Color foreColor = (((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? SystemColors.HighlightText : listBox_0.ForeColor);
				TextRenderer.DrawText(e.Graphics, text, e.Font, e.Bounds, foreColor, TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter);
			}
			e.DrawFocusRectangle();
		}
	}

	private void method_3(object object_0, int int_2)
	{
		Class145 @class = new Class145();
		@class.int_0 = int_2;
		if (iconSheet_0 == null)
		{
			return;
		}
		IconEntry iconEntry = iconSheet_0.Entries.FirstOrDefault(@class.method_0);
		if (iconEntry == null)
		{
			return;
		}
		int num = iconSheet_0.Entries.IndexOf(iconEntry);
		if (num < 0)
		{
			return;
		}
		Keys modifierKeys = Control.ModifierKeys;
		if ((modifierKeys & Keys.Control) == Keys.Control)
		{
			bool selected = listBox_0.GetSelected(num);
			listBox_0.SetSelected(num, !selected);
			int_1 = num;
		}
		else if ((modifierKeys & Keys.Shift) == Keys.Shift && int_1 >= 0)
		{
			int num2 = Math.Min(int_1, num);
			int num3 = Math.Max(int_1, num);
			listBox_0.BeginUpdate();
			listBox_0.ClearSelected();
			for (int i = num2; i <= num3; i++)
			{
				listBox_0.SetSelected(i, value: true);
			}
			listBox_0.EndUpdate();
		}
		else
		{
			method_10(iconEntry);
			int_1 = num;
		}
	}

	private void toolStripComboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (iconSheet_0 != null)
		{
			int num = method_19();
			if (num > 0 && num != iconSheet_0.IconSize)
			{
				iconSheet_0.IconSize = num;
				method_4();
				toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649053218), Class16.smethod_0(1649053258)), num, num);
			}
		}
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		if (!bool_0 && iconEntry_0 != null)
		{
			iconEntry_0.Name = textBox_1.Text;
			listBox_0.Invalidate();
		}
	}

	private void textBox_3_TextChanged(object sender, EventArgs e)
	{
		if (!bool_0 && iconEntry_0 != null)
		{
			List<int> list = smethod_5(textBox_3.Text);
			iconEntry_0.Durations = list;
			if (list.Count > 0)
			{
				timer_0.Interval = Math.Max(10, list[0] * 10);
			}
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (iconSheet_0 != null && iconEntry_0 != null)
		{
			int num = Math.Max(1, iconEntry_0.FrameCount);
			int_0 = (int_0 + 1) % num;
			method_14(iconEntry_0);
			if (iconEntry_0.Durations.Count > int_0)
			{
				int interval = Math.Max(10, iconEntry_0.Durations[int_0] * 10);
				timer_0.Interval = interval;
			}
		}
	}

	private void method_4()
	{
		if (iconSheet_0 != null && iconSheet_0.Image != null)
		{
			spritesheetCanvas_0.SheetImage = iconSheet_0.Image;
			spritesheetCanvas_0.IconSize = iconSheet_0.IconSize;
			spritesheetCanvas_0.TotalFrames = iconSheet_0.TotalFrames;
			spritesheetCanvas_0.Size = new Size(iconSheet_0.Width, iconSheet_0.Height);
			panel_0.AutoScrollMinSize = spritesheetCanvas_0.Size;
			label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649053327), Class16.smethod_0(1649053353)), iconSheet_0.Width, iconSheet_0.Height, iconSheet_0.Columns, iconSheet_0.Rows, iconSheet_0.IconSize, iconSheet_0.Entries.Count);
			method_7();
			spritesheetCanvas_0.Invalidate();
		}
		else
		{
			spritesheetCanvas_0.SheetImage = null;
			spritesheetCanvas_0.TotalFrames = 0;
			spritesheetCanvas_0.IconSize = 32;
			spritesheetCanvas_0.Size = new Size(1, 1);
			panel_0.AutoScrollMinSize = Size.Empty;
			label_0.Text = TextStorage.Msg(Class16.smethod_0(1649053301));
		}
	}

	private void method_5(IconEntry iconEntry_1)
	{
		bool_0 = true;
		try
		{
			textBox_0.Text = iconEntry_1.StartIndex.ToString();
			textBox_1.Text = iconEntry_1.Name ?? string.Empty;
			textBox_2.Text = iconEntry_1.FrameCount.ToString();
			textBox_3.Text = string.Join(Class16.smethod_0(1648942211), iconEntry_1.Durations ?? new List<int>());
		}
		finally
		{
			bool_0 = false;
		}
	}

	private void method_6()
	{
		bool_0 = true;
		try
		{
			textBox_0.Text = string.Empty;
			textBox_1.Text = string.Empty;
			textBox_2.Text = string.Empty;
			textBox_3.Text = string.Empty;
		}
		finally
		{
			bool_0 = false;
		}
		method_16();
	}

	private void method_7()
	{
		if (iconSheet_0 == null)
		{
			spritesheetCanvas_0.SetHighlightedFrames(Array.Empty<int>());
			return;
		}
		List<int> list = new List<int>();
		foreach (IconEntry item in method_9())
		{
			int num = Math.Max(1, item.FrameCount);
			for (int i = 0; i < num; i++)
			{
				int num2 = item.StartIndex + i;
				if (num2 >= 0 && num2 < iconSheet_0.TotalFrames)
				{
					list.Add(num2);
				}
			}
		}
		spritesheetCanvas_0.SetHighlightedFrames(list);
	}

	private void method_8(IEnumerable<IconEntry> ienumerable_0)
	{
		object obj;
		if (ienumerable_0 == null)
		{
			obj = null;
		}
		else
		{
			obj = ienumerable_0.ToList();
			if (obj != null)
			{
				goto IL_0015;
			}
		}
		obj = new List<IconEntry>();
		goto IL_0015;
		IL_0015:
		List<IconEntry> collection = (List<IconEntry>)obj;
		HashSet<IconEntry> hashSet = new HashSet<IconEntry>(collection);
		listBox_0.BeginUpdate();
		listBox_0.Items.Clear();
		if (iconSheet_0 != null)
		{
			foreach (IconEntry entry in iconSheet_0.Entries)
			{
				listBox_0.Items.Add(entry);
			}
			for (int i = 0; i < listBox_0.Items.Count; i++)
			{
				if (listBox_0.Items[i] is IconEntry item && hashSet.Contains(item))
				{
					listBox_0.SetSelected(i, value: true);
				}
			}
		}
		listBox_0.EndUpdate();
		listBox_0.Invalidate();
	}

	private List<IconEntry> method_9()
	{
		List<IconEntry> list = new List<IconEntry>();
		foreach (object selectedItem in listBox_0.SelectedItems)
		{
			if (selectedItem is IconEntry item)
			{
				list.Add(item);
			}
		}
		return list;
	}

	private void method_10(IconEntry iconEntry_1)
	{
		int num = iconSheet_0?.Entries.IndexOf(iconEntry_1) ?? (-1);
		if (num >= 0)
		{
			listBox_0.BeginUpdate();
			listBox_0.ClearSelected();
			listBox_0.SetSelected(num, value: true);
			listBox_0.SelectedIndex = num;
			listBox_0.EndUpdate();
			int_1 = num;
			listBox_0.TopIndex = Math.Max(0, num - 3);
		}
	}

	private void method_11(int int_2)
	{
		if (iconSheet_0 != null && int_2 >= 0)
		{
			Point framePosition = iconSheet_0.GetFramePosition(int_2);
			int num = Math.Max(0, framePosition.X - panel_0.ClientSize.Width / 2 + iconSheet_0.IconSize / 2);
			int num2 = Math.Max(0, framePosition.Y - panel_0.ClientSize.Height / 2 + iconSheet_0.IconSize / 2);
			panel_0.AutoScrollPosition = new Point(num, num2);
		}
	}

	private void method_12(IconEntry iconEntry_1)
	{
		method_13();
		if (iconSheet_0 != null && iconEntry_1 != null)
		{
			int_0 = 0;
			method_14(iconEntry_1);
			if (Math.Max(1, iconEntry_1.FrameCount) > 1)
			{
				int interval = ((iconEntry_1.Durations.Count > 0) ? Math.Max(10, iconEntry_1.Durations[0] * 10) : 100);
				timer_0.Interval = interval;
				timer_0.Start();
			}
		}
	}

	private void method_13()
	{
		timer_0.Stop();
		method_16();
	}

	private void method_14(IconEntry iconEntry_1)
	{
		if (iconSheet_0 == null || iconEntry_1 == null)
		{
			return;
		}
		int num = Math.Max(1, iconEntry_1.FrameCount);
		int frameIndex = iconEntry_1.StartIndex + int_0 % num;
		using Bitmap bitmap = iconSheet_0.GetFrame(frameIndex);
		if (bitmap == null)
		{
			method_16();
			return;
		}
		Bitmap bitmap_ = smethod_1(bitmap, 128, 128);
		method_15(bitmap_);
	}

	private void method_15(Bitmap bitmap_0)
	{
		Image image = pictureBox_0.Image;
		pictureBox_0.Image = bitmap_0;
		image?.Dispose();
	}

	private void method_16()
	{
		if (pictureBox_0.Image != null)
		{
			pictureBox_0.Image.Dispose();
			pictureBox_0.Image = null;
		}
	}

	private void method_17(Bitmap bitmap_0, int int_2, int int_3, int int_4)
	{
		if (iconSheet_0 == null || iconSheet_0.Image == null || bitmap_0 == null)
		{
			return;
		}
		int num = Math.Max(1, int_4);
		Bitmap image = new Bitmap(iconSheet_0.Image.Width, iconSheet_0.Image.Height, PixelFormat.Format32bppArgb);
		using (Graphics graphics = Graphics.FromImage(image))
		{
			graphics.Clear(Color.Transparent);
			graphics.CompositingMode = CompositingMode.SourceCopy;
			graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			graphics.PixelOffsetMode = PixelOffsetMode.Half;
			graphics.DrawImage(iconSheet_0.Image, 0, 0, iconSheet_0.Image.Width, iconSheet_0.Image.Height);
			if (int_3 <= 0)
			{
				using Bitmap bitmap_1 = smethod_1(bitmap_0, iconSheet_0.IconSize, iconSheet_0.IconSize);
				method_18(graphics, bitmap_1, int_2);
			}
			else
			{
				int num2 = bitmap_0.Width / int_3;
				int num3 = bitmap_0.Height / int_3;
				if (num2 > 0 && num3 > 0)
				{
					int num4 = int_2;
					int num5 = int_2 + num;
					for (int i = 0; i < num3; i++)
					{
						if (num4 >= num5)
						{
							break;
						}
						for (int j = 0; j < num2; j++)
						{
							if (num4 >= num5)
							{
								break;
							}
							Rectangle rectangle_ = new Rectangle(j * int_3, i * int_3, int_3, int_3);
							using Bitmap bitmap = smethod_0(bitmap_0, rectangle_);
							using Bitmap bitmap_2 = ((int_3 == iconSheet_0.IconSize) ? new Bitmap(bitmap) : smethod_1(bitmap, iconSheet_0.IconSize, iconSheet_0.IconSize));
							method_18(graphics, bitmap_2, num4);
							num4++;
						}
					}
				}
				else
				{
					using Bitmap bitmap_3 = smethod_1(bitmap_0, iconSheet_0.IconSize, iconSheet_0.IconSize);
					method_18(graphics, bitmap_3, int_2);
				}
			}
		}
		Bitmap image2 = iconSheet_0.Image;
		iconSheet_0.Image = image;
		image2.Dispose();
	}

	private void method_18(Graphics graphics_0, Bitmap bitmap_0, int int_2)
	{
		if (iconSheet_0 != null && bitmap_0 != null)
		{
			Point framePosition = iconSheet_0.GetFramePosition(int_2);
			graphics_0.DrawImage(bitmap_0, new Rectangle(framePosition.X, framePosition.Y, iconSheet_0.IconSize, iconSheet_0.IconSize), new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height), GraphicsUnit.Pixel);
		}
	}

	private static Bitmap smethod_0(Bitmap bitmap_0, Rectangle rectangle_0)
	{
		Bitmap bitmap = new Bitmap(rectangle_0.Width, rectangle_0.Height, PixelFormat.Format32bppArgb);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.CompositingMode = CompositingMode.SourceCopy;
		graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		graphics.PixelOffsetMode = PixelOffsetMode.Half;
		graphics.DrawImage(bitmap_0, new Rectangle(0, 0, rectangle_0.Width, rectangle_0.Height), rectangle_0, GraphicsUnit.Pixel);
		return bitmap;
	}

	private static Bitmap smethod_1(Bitmap bitmap_0, int int_2, int int_3)
	{
		Bitmap bitmap = new Bitmap(int_2, int_3, PixelFormat.Format32bppArgb);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.CompositingMode = CompositingMode.SourceCopy;
		graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		graphics.PixelOffsetMode = PixelOffsetMode.Half;
		graphics.DrawImage(bitmap_0, new Rectangle(0, 0, int_2, int_3), new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height), GraphicsUnit.Pixel);
		return bitmap;
	}

	private static bool smethod_2(Bitmap bitmap_0, string string_0)
	{
		try
		{
			bitmap_0.Save(string_0, ImageFormat.Png);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static string smethod_3(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return string.Empty;
		}
		char[] invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();
		char[] array = string_0.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			if (invalidFileNameChars.Contains(array[i]))
			{
				array[i] = '_';
			}
		}
		return new string(array).Trim();
	}

	private static string smethod_4(string string_0)
	{
		if (!File.Exists(string_0))
		{
			return string_0;
		}
		string path = System.IO.Path.GetDirectoryName(string_0) ?? string.Empty;
		string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(string_0);
		string extension = System.IO.Path.GetExtension(string_0);
		int num = 1;
		string text;
		do
		{
			text = System.IO.Path.Combine(path, string.Format(Class16.smethod_0(1649053409), fileNameWithoutExtension, num, extension));
			num++;
		}
		while (File.Exists(text));
		return text;
	}

	private static List<int> smethod_5(string string_0)
	{
		List<int> list = new List<int>();
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return list;
		}
		string[] array = string_0.Split(new char[4] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		foreach (string s in array2)
		{
			if (int.TryParse(s, out var result))
			{
				list.Add(result);
			}
		}
		return list;
	}

	private int method_19()
	{
		if (toolStripComboBox_0.SelectedItem == null)
		{
			return 32;
		}
		if (!int.TryParse(toolStripComboBox_0.SelectedItem.ToString(), out var result))
		{
			return 32;
		}
		return result;
	}

	private void method_20(int int_2)
	{
		string text = int_2.ToString();
		if (!toolStripComboBox_0.Items.Contains(text))
		{
			toolStripComboBox_0.Items.Add(text);
		}
	}

	private void IconEditorForm_Activated(object sender, EventArgs e)
	{
		method_21();
	}

	private void method_21()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_IconEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_IconEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}
}
