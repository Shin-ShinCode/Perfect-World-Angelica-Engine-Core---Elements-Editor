#nullable enable annotations
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using ACE.Classes;
using ACE.NpcGen;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.UIEdit.Models;
using ACE.UIEdit.Services;

namespace ACE.UIEdit;

public sealed class UIXmlEditorForm : Form
{
	private sealed class Class372
	{
		public string string_0;

		internal bool method_0(string string_1)
		{
			return !string.Equals(string_1, string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class373
	{
		public UIXmlEditorForm uixmlEditorForm_0;

		public PreviewBackgroundMode previewBackgroundMode_0;

		internal void method_0(object sender, EventArgs e)
		{
			uixmlEditorForm_0.previewBackgroundMode_0 = previewBackgroundMode_0;
			uixmlEditorForm_0.previewCanvasPanel_0.BackgroundMode = previewBackgroundMode_0;
			uixmlEditorForm_0.previewCanvasPanel_0.Invalidate();
			uixmlEditorForm_0.method_122();
		}
	}

	private sealed class Class374
	{
		public Control control_0;

		public UIXmlEditorForm uixmlEditorForm_0;

		public PreviewItemPanel previewItemPanel_0;

		internal void method_0(object sender, MouseEventArgs e)
		{
			MouseEventArgs e2 = new MouseEventArgs(e.Button, e.Clicks, control_0.Left + e.X, control_0.Top + e.Y, e.Delta);
			uixmlEditorForm_0.method_81(previewItemPanel_0, e2);
		}

		internal void method_1(object sender, MouseEventArgs e)
		{
			MouseEventArgs e2 = new MouseEventArgs(e.Button, e.Clicks, control_0.Left + e.X, control_0.Top + e.Y, e.Delta);
			uixmlEditorForm_0.method_83(previewItemPanel_0, e2);
		}

		internal void method_2(object sender, MouseEventArgs e)
		{
			MouseEventArgs e2 = new MouseEventArgs(e.Button, e.Clicks, control_0.Left + e.X, control_0.Top + e.Y, e.Delta);
			uixmlEditorForm_0.method_84(previewItemPanel_0, e2);
		}

		internal void method_3(object sender, EventArgs e)
		{
			uixmlEditorForm_0.method_77(previewItemPanel_0, e);
		}
	}

	private sealed class Class375
	{
		public string string_0;

		internal bool method_0(UiControlModel uiControlModel_0)
		{
			return string.Equals(smethod_22(uiControlModel_0), string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class376
	{
		public string string_0;

		internal bool method_0(UiControlModel uiControlModel_0)
		{
			return string.Equals(smethod_22(uiControlModel_0), string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class377
	{
		public UIXmlEditorForm uixmlEditorForm_0;

		public string[] string_0;

		public bool bool_0;

		internal bool method_0(UiSourceFile uiSourceFile_0)
		{
			return uixmlEditorForm_0.method_50(uiSourceFile_0, string_0, bool_0);
		}
	}

	private sealed class Class378
	{
		public Rectangle rectangle_0;

		public Point point_0;

		internal bool method_0(KeyValuePair<UiControlModel, PreviewItemPanel> keyValuePair_0)
		{
			Rectangle bounds = keyValuePair_0.Value.Bounds;
			if (rectangle_0.Width <= 2 && rectangle_0.Height <= 2)
			{
				return bounds.Contains(point_0);
			}
			return bounds.IntersectsWith(rectangle_0);
		}
	}

	private sealed class Class379
	{
		public string string_0;

		internal bool method_0(UiControlModel uiControlModel_0)
		{
			return string.Equals(smethod_22(uiControlModel_0), string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class380
	{
		public string string_0;

		internal bool method_0(UiSourceFile uiSourceFile_0)
		{
			return string.Equals(uiSourceFile_0.FileName, System.IO.Path.GetFileName(string_0), StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class381
	{
		public UIXmlEditorForm uixmlEditorForm_0;

		public bool bool_0;

		internal void method_0()
		{
			uixmlEditorForm_0.method_126(bool_0);
		}
	}

	private struct Struct115
	{
		public int int_0;

		public int int_1;
	}

	[Serializable]
	private sealed class Class382
	{
		public static readonly Class382 class382_0 = new Class382();

		public static Func<UiControlModel, int> func_0;

		public static Func<UiControlModel, int> func_1;

		public static Func<string, bool> func_2;

		public static Func<string, string> func_3;

		public static Func<string, bool> func_4;

		public static Func<UiSourceFile, string> func_5;

		public static Func<UiSourceFile, string> func_6;

		public static Func<UiControlModel, int> func_7;

		public static Func<DataGridViewRow, UiControlModel> func_8;

		public static Func<UiControlModel, bool> func_9;

		public static Func<UiControlModel, bool> func_10;

		public static Func<UiControlModel, bool> func_11;

		public static Func<UiControlModel, bool> func_12;

		public static Func<KeyValuePair<UiControlModel, PreviewItemPanel>, UiControlModel> func_13;

		public static Func<UiControlModel, int> func_14;

		public static Func<UiControlModel, int> func_15;

		public static Func<UiControlModel, int> func_16;

		public static Func<UiControlModel, int> func_17;

		public static Func<UiControlModel, int> func_18;

		public static Func<UiControlModel, int> func_19;

		internal int method_0(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0.Int32_0;
		}

		internal int method_1(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0.Int32_1;
		}

		internal bool method_2(string string_0)
		{
			return !string.IsNullOrWhiteSpace(string_0);
		}

		internal string method_3(string string_0)
		{
			return string_0.Trim();
		}

		internal bool method_4(string string_0)
		{
			return string_0.Length > 0;
		}

		internal string method_5(UiSourceFile uiSourceFile_0)
		{
			return uiSourceFile_0.RelativeDirectory;
		}

		internal string method_6(UiSourceFile uiSourceFile_0)
		{
			return uiSourceFile_0.FileName;
		}

		internal int method_7(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0.Layer;
		}

		internal UiControlModel method_8(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Tag as UiControlModel;
		}

		internal bool method_9(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0 != null;
		}

		internal bool method_10(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0 != null;
		}

		internal bool method_11(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0 != null;
		}

		internal bool method_12(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0 != null;
		}

		internal UiControlModel method_13(KeyValuePair<UiControlModel, PreviewItemPanel> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}

		internal int method_14(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0.Int32_0;
		}

		internal int method_15(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0.Int32_1;
		}

		internal int method_16(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0.Int32_0 + Math.Max(1, uiControlModel_0.Width);
		}

		internal int method_17(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0.Int32_1 + Math.Max(1, uiControlModel_0.Height);
		}

		internal int method_18(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0.Layer;
		}

		internal int method_19(UiControlModel uiControlModel_0)
		{
			return uiControlModel_0.Layer;
		}
	}

	private readonly UiXmlFileService uiXmlFileService_0 = new UiXmlFileService();

	private readonly UiLayoutParser uiLayoutParser_0 = new UiLayoutParser();

	private readonly UiImageLoader uiImageLoader_0 = new UiImageLoader();

	private readonly UiPckProvider uiPckProvider_0 = new UiPckProvider();

	private UiEditorSettings uiEditorSettings_0 = new UiEditorSettings();

	private readonly List<UiSourceFile> list_0 = new List<UiSourceFile>();

	private UiSourceFile? uiSourceFile_0;

	private UiDialogModel? uiDialogModel_0;

	private UiControlModel? uiControlModel_0;

	private string? string_0;

	private Point point_0 = new Point(int.MinValue, int.MinValue);

	private readonly Dictionary<UiControlModel, PreviewItemPanel> dictionary_0 = new Dictionary<UiControlModel, PreviewItemPanel>();

	private readonly HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private readonly HashSet<string> hashSet_1 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private bool bool_0;

	private bool bool_1;

	private int int_0;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private string string_1 = string.Empty;

	private string string_2 = string.Empty;

	private string? string_3;

	private float float_0 = 1f;

	private bool bool_14;

	private TabPage? tabPage_0;

	private PreviewBackgroundMode previewBackgroundMode_0;

	private FormTexts? formTexts_0;

	private readonly List<string> list_1 = new List<string>();

	private readonly List<string> list_2 = new List<string>();

	private readonly Dictionary<string, (DateTime, UiDialogModel)> dictionary_1 = new Dictionary<string, (DateTime, UiDialogModel)>(StringComparer.OrdinalIgnoreCase);

	private Point point_1;

	private SplitContainer? splitContainer_0;

	private SplitContainer? splitContainer_1;

	private SplitContainer? splitContainer_2;

	private TableLayoutPanel? tableLayoutPanel_0;

	private PreviewItemPanel? previewItemPanel_0;

	private UiControlModel? uiControlModel_1;

	private PreviewItemPanel? previewItemPanel_1;

	private UiControlModel? uiControlModel_2;

	private Point point_2;

	private readonly Dictionary<string, Point> dictionary_2 = new Dictionary<string, Point>(StringComparer.OrdinalIgnoreCase);

	private Point point_3;

	private Point point_4;

	private int int_1;

	private int int_2;

	private IContainer? icontainer_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private ListBox listBox_0;

	private DataGridView dataGridView_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private ToolStripButton toolStripButton_4;

	private ToolStripButton toolStripButton_5;

	private ToolStripButton toolStripButton_6;

	private ToolStripButton toolStripButton_7;

	private ToolStripButton toolStripButton_8;

	private ToolStripButton toolStripButton_9;

	private ToolStripButton toolStripButton_10;

	private ToolStripButton toolStripButton_11;

	private ToolStripButton toolStripButton_12;

	private ToolStripLabel toolStripLabel_0;

	private ToolStripButton toolStripButton_13;

	private ToolStripButton toolStripButton_14;

	private ToolStripDropDownButton toolStripDropDownButton_0;

	private RichTextBox richTextBox_0;

	private DataGridView dataGridView_1;

	private TextBox textBox_3;

	private TextBox textBox_4;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private TableLayoutPanel tableLayoutPanel_1;

	private CheckBox checkBox_0;

	private Button button_4;

	private CheckBox checkBox_1;

	private NumericUpDown numericUpDown_0;

	private Button button_5;

	private Button button_6;

	private Button button_7;

	private Button button_8;

	private Button button_9;

	private Button button_10;

	private Button button_11;

	private Button button_12;

	private Button button_13;

	private Button button_14;

	private Button button_15;

	private Button button_16;

	private Button button_17;

	private Button button_18;

	private Button button_19;

	private Button button_20;

	private Button button_21;

	private Button button_22;

	private Button button_23;

	private Button button_24;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripMenuItem toolStripMenuItem_5;

	private ToolStripMenuItem toolStripMenuItem_6;

	private Panel panel_0;

	private PreviewCanvasPanel previewCanvasPanel_0;

	private Panel panel_1;

	private Label label_0;

	private DataGridView dataGridView_2;

	private PropertyGrid propertyGrid_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private ToolStripStatusLabel toolStripStatusLabel_1;

	private ToolStripStatusLabel toolStripStatusLabel_2;

	private Timer timer_0;

	public UIXmlEditorForm()
	{
		method_0();
		method_1();
		uiImageLoader_0.SetPckProvider(uiPckProvider_0);
		method_35();
		method_36();
		TextStorage.TEXTS.SetFormLanguage(this, null);
		method_130();
		base.Activated += UIXmlEditorForm_Activated;
		method_46();
	}

	[DllImport("user32.dll")]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_3, IntPtr intptr_1, IntPtr intptr_2);

	[DllImport("user32.dll", EntryPoint = "SendMessage")]
	private static extern IntPtr SendMessage_1(IntPtr intptr_0, int int_3, IntPtr intptr_1, ref Struct115 struct115_0);

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
		icontainer_0 = new Container();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		textBox_2 = new TextBox();
		listBox_0 = new ListBox();
		dataGridView_0 = new DataGridView();
		toolStripButton_0 = new ToolStripButton();
		toolStripButton_1 = new ToolStripButton();
		toolStripButton_2 = new ToolStripButton();
		toolStripButton_3 = new ToolStripButton();
		toolStripButton_4 = new ToolStripButton();
		toolStripButton_5 = new ToolStripButton();
		toolStripButton_6 = new ToolStripButton();
		toolStripButton_7 = new ToolStripButton();
		toolStripButton_8 = new ToolStripButton();
		toolStripButton_9 = new ToolStripButton();
		toolStripButton_10 = new ToolStripButton();
		toolStripButton_11 = new ToolStripButton();
		toolStripButton_12 = new ToolStripButton();
		toolStripLabel_0 = new ToolStripLabel();
		toolStripButton_13 = new ToolStripButton();
		toolStripButton_14 = new ToolStripButton();
		toolStripDropDownButton_0 = new ToolStripDropDownButton();
		richTextBox_0 = new RichTextBox();
		dataGridView_1 = new DataGridView();
		textBox_3 = new TextBox();
		textBox_4 = new TextBox();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		tableLayoutPanel_1 = new TableLayoutPanel();
		checkBox_0 = new CheckBox();
		button_4 = new Button();
		checkBox_1 = new CheckBox();
		numericUpDown_0 = new NumericUpDown();
		button_5 = new Button();
		button_6 = new Button();
		button_7 = new Button();
		button_8 = new Button();
		button_9 = new Button();
		button_10 = new Button();
		button_11 = new Button();
		button_12 = new Button();
		button_13 = new Button();
		button_14 = new Button();
		button_15 = new Button();
		button_16 = new Button();
		button_17 = new Button();
		button_18 = new Button();
		button_19 = new Button();
		button_20 = new Button();
		button_21 = new Button();
		button_22 = new Button();
		button_23 = new Button();
		button_24 = new Button();
		checkBox_2 = new CheckBox();
		checkBox_3 = new CheckBox();
		checkBox_4 = new CheckBox();
		contextMenuStrip_0 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		toolStripMenuItem_5 = new ToolStripMenuItem();
		toolStripMenuItem_6 = new ToolStripMenuItem();
		panel_0 = new Panel();
		previewCanvasPanel_0 = new PreviewCanvasPanel();
		panel_1 = new Panel();
		label_0 = new Label();
		dataGridView_2 = new DataGridView();
		propertyGrid_0 = new PropertyGrid();
		toolStripStatusLabel_0 = new ToolStripStatusLabel();
		toolStripStatusLabel_1 = new ToolStripStatusLabel();
		toolStripStatusLabel_2 = new ToolStripStatusLabel();
		timer_0 = new Timer(icontainer_0);
		((ISupportInitialize)dataGridView_0).BeginInit();
		((ISupportInitialize)dataGridView_1).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)dataGridView_2).BeginInit();
		SuspendLayout();
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1400, 850);
		DoubleBuffered = true;
		base.KeyPreview = true;
		MinimumSize = new Size(1100, 700);
		base.Name = Class16.smethod_0(1649275816);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649128537);
		toolStripButton_0.Text = Class16.smethod_0(1648941761);
		toolStripButton_1.Text = Class16.smethod_0(1649275846);
		toolStripButton_2.Text = Class16.smethod_0(1649275851);
		toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_3.Image = Resources.GShopEditor_PW_mbUndo;
		toolStripButton_3.ImageTransparentColor = Color.Magenta;
		toolStripButton_3.Text = Class16.smethod_0(1648903487);
		toolStripButton_3.ToolTipText = Class16.smethod_0(1648933841);
		toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_4.Image = Resources.GShopEditor_PW_mbRedo;
		toolStripButton_4.ImageTransparentColor = Color.Magenta;
		toolStripButton_4.Text = Class16.smethod_0(1648903490);
		toolStripButton_4.ToolTipText = Class16.smethod_0(1648933869);
		toolStripButton_5.Text = Class16.smethod_0(1649275876);
		toolStripButton_6.Text = Class16.smethod_0(1649275883);
		toolStripButton_7.Text = Class16.smethod_0(1649275902);
		toolStripButton_8.Text = Class16.smethod_0(1649086694);
		toolStripButton_9.Text = Class16.smethod_0(1648991736);
		toolStripButton_10.Text = Class16.smethod_0(1649274895);
		toolStripButton_11.Text = Class16.smethod_0(1649274908);
		toolStripButton_12.Text = Class16.smethod_0(1648926675);
		toolStripLabel_0.Text = Class16.smethod_0(1648926675);
		toolStripDropDownButton_0.Text = Class16.smethod_0(1649274913);
		toolStripButton_13.Text = Class16.smethod_0(1649274930);
		toolStripButton_14.Text = Class16.smethod_0(1649274959);
		toolStripMenuItem_0.Text = Class16.smethod_0(1649274970);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648980510);
		toolStripMenuItem_2.Text = Class16.smethod_0(1649003400);
		toolStripMenuItem_3.Text = Class16.smethod_0(1648925718);
		toolStripMenuItem_4.Text = Class16.smethod_0(1649274989);
		toolStripMenuItem_5.Text = Class16.smethod_0(1649275006);
		toolStripMenuItem_6.Text = Class16.smethod_0(1649275019);
		toolStripStatusLabel_0.Text = string.Empty;
		toolStripStatusLabel_1.Text = string.Empty;
		toolStripStatusLabel_2.Text = string.Empty;
		timer_0.Interval = 650;
		((ISupportInitialize)dataGridView_0).EndInit();
		((ISupportInitialize)dataGridView_1).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)dataGridView_2).EndInit();
		ResumeLayout(performLayout: false);
	}

	private void method_1()
	{
		base.Controls.Clear();
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 1,
			Padding = new Padding(0),
			Margin = new Padding(0)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		base.Controls.Add(tableLayoutPanel);
		splitContainer_0 = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Vertical,
			SplitterWidth = 6
		};
		tableLayoutPanel.Controls.Add(splitContainer_0, 0, 0);
		method_2(splitContainer_0.Panel1);
		method_5(splitContainer_0.Panel2);
		method_37();
	}

	private void method_2(Control control_0)
	{
		splitContainer_1 = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterWidth = 6
		};
		control_0.Controls.Add(splitContainer_1);
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 3,
			RowCount = 6,
			Padding = new Padding(6, 6, 6, 4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		splitContainer_1.Panel1.Controls.Add(tableLayoutPanel);
		Label control = new Label
		{
			Text = Class16.smethod_0(1649275046),
			AutoSize = true,
			Anchor = AnchorStyles.Left,
			Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold)
		};
		tableLayoutPanel.Controls.Add(control, 0, 0);
		textBox_0.Dock = DockStyle.Fill;
		textBox_0.ReadOnly = true;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f);
		tableLayoutPanel.Controls.Add(textBox_0, 1, 0);
		Button button = new Button
		{
			Text = Class16.smethod_0(1648924410),
			Width = 30,
			Height = 23,
			FlatStyle = FlatStyle.Flat,
			Cursor = Cursors.Hand
		};
		tableLayoutPanel.Controls.Add(button, 2, 0);
		Label control2 = new Label
		{
			Text = Class16.smethod_0(1649275068),
			AutoSize = true,
			Anchor = AnchorStyles.Left,
			Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold)
		};
		tableLayoutPanel.Controls.Add(control2, 0, 1);
		textBox_1.Dock = DockStyle.Fill;
		textBox_1.ReadOnly = true;
		textBox_1.Font = new Font(Class16.smethod_0(1648942905), 8f);
		tableLayoutPanel.Controls.Add(textBox_1, 1, 1);
		Button button2 = new Button
		{
			Text = Class16.smethod_0(1648924410),
			Width = 30,
			Height = 23,
			FlatStyle = FlatStyle.Flat,
			Cursor = Cursors.Hand
		};
		tableLayoutPanel.Controls.Add(button2, 2, 1);
		Label control3 = new Label
		{
			Text = Class16.smethod_0(1649275080),
			AutoSize = true,
			Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold),
			ForeColor = Color.FromArgb(130, 150, 170),
			Padding = new Padding(0, 6, 0, 2)
		};
		tableLayoutPanel.SetColumnSpan(control3, 3);
		tableLayoutPanel.Controls.Add(control3, 0, 2);
		TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 3,
			RowCount = 1,
			Margin = new Padding(0),
			Height = 28
		};
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		textBox_2.Dock = DockStyle.Fill;
		textBox_2.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		button_4.Text = Class16.smethod_0(1648931650);
		button_4.FlatStyle = FlatStyle.Flat;
		button_4.Height = 24;
		Button button3 = new Button
		{
			Text = Class16.smethod_0(1648928315),
			AutoSize = true,
			FlatStyle = FlatStyle.Flat,
			Height = 24
		};
		tableLayoutPanel2.Controls.Add(textBox_2, 0, 0);
		tableLayoutPanel2.Controls.Add(button_4, 1, 0);
		tableLayoutPanel2.Controls.Add(button3, 2, 0);
		tableLayoutPanel.SetColumnSpan(tableLayoutPanel2, 3);
		tableLayoutPanel.Controls.Add(tableLayoutPanel2, 0, 3);
		checkBox_0.Text = Class16.smethod_0(1649275096);
		checkBox_0.AutoSize = true;
		checkBox_0.Font = new Font(Class16.smethod_0(1648942905), 7.5f);
		tableLayoutPanel.SetColumnSpan(checkBox_0, 3);
		tableLayoutPanel.Controls.Add(checkBox_0, 0, 4);
		listBox_0.Dock = DockStyle.Fill;
		listBox_0.HorizontalScrollbar = true;
		listBox_0.IntegralHeight = false;
		listBox_0.Font = new Font(Class16.smethod_0(1649275143), 8.5f, FontStyle.Regular, GraphicsUnit.Point);
		listBox_0.BorderStyle = BorderStyle.FixedSingle;
		tableLayoutPanel.SetColumnSpan(listBox_0, 3);
		tableLayoutPanel.Controls.Add(listBox_0, 0, 5);
		method_3();
		method_4();
		button.Click += method_132;
		button2.Click += method_133;
		button3.Click += method_134;
	}

	private void method_3()
	{
		TabControl tabControl = new TabControl
		{
			Dock = DockStyle.Fill
		};
		TabPage tabPage = new TabPage(Class16.smethod_0(1649209715));
		TabPage tabPage2 = new TabPage(Class16.smethod_0(1649050557));
		TabPage tabPage3 = new TabPage(Class16.smethod_0(1649105470));
		TabPage value = new TabPage(Class16.smethod_0(1648931739));
		tabControl.TabPages.Add(tabPage);
		tabControl.TabPages.Add(tabPage2);
		tabControl.TabPages.Add(tabPage3);
		tabControl.TabPages.Add(value);
		splitContainer_1.Panel2.Controls.Add(tabControl);
		dataGridView_0.Dock = DockStyle.Fill;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.MultiSelect = true;
		dataGridView_0.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView_0.RowHeadersVisible = false;
		if (dataGridView_0.Columns.Count == 0)
		{
			dataGridView_0.Columns.Add(Class16.smethod_0(1649275155), Class16.smethod_0(1649104969));
			dataGridView_0.Columns.Add(Class16.smethod_0(1649275171), Class16.smethod_0(1648936875));
			dataGridView_0.Columns.Add(Class16.smethod_0(1649275187), Class16.smethod_0(1648916453));
			dataGridView_0.Columns.Add(Class16.smethod_0(1649275200), Class16.smethod_0(1648916476));
			dataGridView_0.Columns.Add(Class16.smethod_0(1649275221), Class16.smethod_0(1649212937));
			dataGridView_0.Columns.Add(Class16.smethod_0(1649275226), Class16.smethod_0(1649085359));
			dataGridView_0.Columns[0].FillWeight = 180f;
			dataGridView_0.Columns[1].FillWeight = 140f;
			dataGridView_0.Columns[2].FillWeight = 58f;
			dataGridView_0.Columns[3].FillWeight = 58f;
			dataGridView_0.Columns[4].FillWeight = 64f;
			dataGridView_0.Columns[5].FillWeight = 76f;
		}
		tabPage.Controls.Add(dataGridView_0);
		propertyGrid_0.Dock = DockStyle.Fill;
		propertyGrid_0.HelpVisible = false;
		propertyGrid_0.ToolbarVisible = false;
		tabPage2.Controls.Add(propertyGrid_0);
		dataGridView_1.Dock = DockStyle.Fill;
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToDeleteRows = false;
		dataGridView_1.AllowUserToResizeRows = false;
		dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_1.MultiSelect = false;
		dataGridView_1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView_1.RowHeadersVisible = false;
		if (dataGridView_1.Columns.Count == 0)
		{
			dataGridView_1.Columns.Add(Class16.smethod_0(1649275253), Class16.smethod_0(1649275253));
			dataGridView_1.Columns.Add(Class16.smethod_0(1649275256), Class16.smethod_0(1649275277));
			dataGridView_1.Columns.Add(Class16.smethod_0(1649275287), Class16.smethod_0(1649275287));
			dataGridView_1.Columns[0].FillWeight = 22f;
			dataGridView_1.Columns[1].FillWeight = 22f;
			dataGridView_1.Columns[2].FillWeight = 220f;
		}
		tabPage3.Controls.Add(dataGridView_1);
		tabPage_0 = value;
	}

	private void method_4()
	{
		Panel panel = new Panel
		{
			Dock = DockStyle.Fill,
			AutoScroll = true,
			Padding = new Padding(6, 6, 6, 6)
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			AutoSizeMode = AutoSizeMode.GrowAndShrink,
			ColumnCount = 1,
			Padding = new Padding(0),
			Margin = new Padding(0)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		panel.Controls.Add(tableLayoutPanel);
		GroupBox groupBox = smethod_0(Class16.smethod_0(1649068916));
		TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			AutoSize = true,
			AutoSizeMode = AutoSizeMode.GrowAndShrink,
			Padding = new Padding(4)
		};
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		checkBox_1.Text = Class16.smethod_0(1649275301);
		checkBox_1.AutoSize = true;
		checkBox_2.Text = Class16.smethod_0(1649275314);
		checkBox_2.AutoSize = true;
		checkBox_3.Text = Class16.smethod_0(1649275340);
		checkBox_3.AutoSize = true;
		checkBox_4.Text = Class16.smethod_0(1649275354);
		checkBox_4.AutoSize = true;
		tableLayoutPanel2.Controls.Add(checkBox_1, 0, 0);
		tableLayoutPanel2.Controls.Add(checkBox_2, 1, 0);
		tableLayoutPanel2.Controls.Add(checkBox_3, 0, 1);
		tableLayoutPanel2.Controls.Add(checkBox_4, 1, 1);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			AutoSize = true,
			WrapContents = false,
			Margin = new Padding(3, 4, 0, 2)
		};
		flowLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649275377),
			AutoSize = true,
			Margin = new Padding(0, 4, 4, 0)
		});
		numericUpDown_0.Minimum = 1m;
		numericUpDown_0.Maximum = 64m;
		numericUpDown_0.Value = 4m;
		numericUpDown_0.Width = 60;
		flowLayoutPanel.Controls.Add(numericUpDown_0);
		tableLayoutPanel2.SetColumnSpan(flowLayoutPanel, 2);
		tableLayoutPanel2.Controls.Add(flowLayoutPanel, 0, 2);
		groupBox.Controls.Add(tableLayoutPanel2);
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.Controls.Add(groupBox, 0, 0);
		GroupBox groupBox2 = smethod_0(Class16.smethod_0(1649278466));
		TableLayoutPanel tableLayoutPanel3 = smethod_1(2);
		button_5.Text = Class16.smethod_0(1649278488);
		button_6.Text = Class16.smethod_0(1648932164);
		button_7.Text = Class16.smethod_0(1649056363);
		button_8.Text = Class16.smethod_0(1649278508);
		smethod_2(button_5, bool_15: false);
		smethod_2(button_6, bool_15: false);
		smethod_2(button_7, bool_15: false);
		smethod_2(button_8, bool_15: false);
		tableLayoutPanel3.Controls.Add(button_5, 0, 0);
		tableLayoutPanel3.Controls.Add(button_6, 1, 0);
		tableLayoutPanel3.Controls.Add(button_7, 0, 1);
		tableLayoutPanel3.Controls.Add(button_8, 1, 1);
		groupBox2.Controls.Add(tableLayoutPanel3);
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.Controls.Add(groupBox2, 0, 1);
		GroupBox groupBox3 = smethod_0(Class16.smethod_0(1648931458));
		TableLayoutPanel tableLayoutPanel4 = smethod_1(2);
		button_9.Text = Class16.smethod_0(1649278513);
		button_10.Text = Class16.smethod_0(1649278535);
		smethod_2(button_9, bool_15: false);
		smethod_2(button_10, bool_15: false);
		tableLayoutPanel4.Controls.Add(button_9, 0, 0);
		tableLayoutPanel4.Controls.Add(button_10, 1, 0);
		groupBox3.Controls.Add(tableLayoutPanel4);
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.Controls.Add(groupBox3, 0, 2);
		GroupBox groupBox4 = smethod_0(Class16.smethod_0(1649278547));
		TableLayoutPanel tableLayoutPanel5 = smethod_1(2);
		button_11.Text = Class16.smethod_0(1648931361);
		button_12.Text = Class16.smethod_0(1648931371);
		button_13.Text = Class16.smethod_0(1649278570);
		button_14.Text = Class16.smethod_0(1649278584);
		button_15.Text = Class16.smethod_0(1649278600);
		button_16.Text = Class16.smethod_0(1649278616);
		button_17.Text = Class16.smethod_0(1649278639);
		smethod_2(button_11, bool_15: false);
		smethod_2(button_12, bool_15: false);
		smethod_2(button_13, bool_15: false);
		smethod_2(button_14, bool_15: false);
		smethod_2(button_15, bool_15: false);
		smethod_2(button_16, bool_15: false);
		smethod_2(button_17, bool_15: false);
		tableLayoutPanel5.Controls.Add(button_11, 0, 0);
		tableLayoutPanel5.Controls.Add(button_12, 1, 0);
		tableLayoutPanel5.Controls.Add(button_13, 0, 1);
		tableLayoutPanel5.Controls.Add(button_14, 1, 1);
		tableLayoutPanel5.Controls.Add(button_15, 0, 2);
		tableLayoutPanel5.Controls.Add(button_16, 1, 2);
		tableLayoutPanel5.SetColumnSpan(button_17, 2);
		tableLayoutPanel5.Controls.Add(button_17, 0, 3);
		groupBox4.Controls.Add(tableLayoutPanel5);
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.Controls.Add(groupBox4, 0, 3);
		GroupBox groupBox5 = smethod_0(Class16.smethod_0(1649278653));
		TableLayoutPanel tableLayoutPanel6 = smethod_1(2);
		button_18.Text = Class16.smethod_0(1649278669);
		button_19.Text = Class16.smethod_0(1649278682);
		smethod_2(button_18, bool_15: false);
		smethod_2(button_19, bool_15: false);
		tableLayoutPanel6.Controls.Add(button_18, 0, 0);
		tableLayoutPanel6.Controls.Add(button_19, 1, 0);
		groupBox5.Controls.Add(tableLayoutPanel6);
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.Controls.Add(groupBox5, 0, 4);
		GroupBox groupBox6 = smethod_0(Class16.smethod_0(1648931739));
		TableLayoutPanel tableLayoutPanel7 = smethod_1(2);
		button_20.Text = Class16.smethod_0(1649278705);
		button_21.Text = Class16.smethod_0(1649278722);
		button_22.Text = Class16.smethod_0(1649278748);
		button_23.Text = Class16.smethod_0(1649278766);
		button_24.Text = Class16.smethod_0(1649278788);
		smethod_2(button_20, bool_15: false);
		smethod_2(button_21, bool_15: false);
		smethod_2(button_22, bool_15: false);
		smethod_2(button_23, bool_15: false);
		smethod_2(button_24, bool_15: true);
		tableLayoutPanel7.Controls.Add(button_20, 0, 0);
		tableLayoutPanel7.Controls.Add(button_21, 1, 0);
		tableLayoutPanel7.Controls.Add(button_22, 0, 1);
		tableLayoutPanel7.Controls.Add(button_23, 1, 1);
		tableLayoutPanel7.SetColumnSpan(button_24, 2);
		tableLayoutPanel7.Controls.Add(button_24, 0, 2);
		groupBox6.Controls.Add(tableLayoutPanel7);
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.Controls.Add(groupBox6, 0, 5);
		tabPage_0?.Controls.Add(panel);
	}

	private void method_5(Control control_0)
	{
		splitContainer_2 = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Vertical,
			SplitterWidth = 6
		};
		control_0.Controls.Add(splitContainer_2);
		Panel panel = new Panel
		{
			Dock = DockStyle.Fill
		};
		splitContainer_2.Panel1.Controls.Add(panel);
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 6,
			Padding = new Padding(0),
			Margin = new Padding(0)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 0f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 0f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		panel.Controls.Add(tableLayoutPanel);
		tableLayoutPanel_0 = tableLayoutPanel;
		method_6(tableLayoutPanel);
		method_7(tableLayoutPanel);
		method_8(tableLayoutPanel);
		method_9(tableLayoutPanel);
		method_10(tableLayoutPanel);
		method_11(tableLayoutPanel);
		method_12();
	}

	private void method_6(TableLayoutPanel tableLayoutPanel_2)
	{
		ToolStrip toolStrip = new ToolStrip
		{
			Dock = DockStyle.Fill,
			GripStyle = ToolStripGripStyle.Hidden
		};
		toolStripButton_0.Enabled = false;
		toolStripButton_0.Image = smethod_5(Class16.smethod_0(1649278807));
		toolStripButton_1.Image = smethod_5(Class16.smethod_0(1649278816));
		toolStripButton_2.Image = smethod_5(Class16.smethod_0(1649278835));
		toolStripButton_3.Image = smethod_5(Class16.smethod_0(1649278816));
		toolStripButton_4.Image = smethod_5(Class16.smethod_0(1649278807));
		toolStrip.Items.Add(toolStripButton_0);
		toolStrip.Items.Add(toolStripButton_1);
		toolStrip.Items.Add(toolStripButton_2);
		toolStrip.Items.Add(new ToolStripSeparator());
		toolStrip.Items.Add(toolStripButton_3);
		toolStrip.Items.Add(toolStripButton_4);
		tableLayoutPanel_2.Controls.Add(toolStrip, 0, 0);
	}

	private void method_7(TableLayoutPanel tableLayoutPanel_2)
	{
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 4,
			RowCount = 1,
			Height = 36,
			Padding = new Padding(8, 4, 8, 4),
			Margin = new Padding(0)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1648916538),
			AutoSize = true,
			Anchor = AnchorStyles.Left
		}, 0, 0);
		textBox_3.Dock = DockStyle.Fill;
		tableLayoutPanel.Controls.Add(textBox_3, 1, 0);
		button_0.Text = Class16.smethod_0(1649278850);
		button_1.Text = Class16.smethod_0(1648978815);
		tableLayoutPanel.Controls.Add(button_0, 2, 0);
		tableLayoutPanel.Controls.Add(button_1, 3, 0);
		tableLayoutPanel_2.Controls.Add(tableLayoutPanel, 0, 1);
	}

	private void method_8(TableLayoutPanel tableLayoutPanel_2)
	{
		richTextBox_0.Dock = DockStyle.Fill;
		richTextBox_0.Multiline = true;
		richTextBox_0.AcceptsTab = true;
		richTextBox_0.WordWrap = false;
		richTextBox_0.HideSelection = false;
		richTextBox_0.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
		richTextBox_0.Font = new Font(Class16.smethod_0(1649275143), 10f, FontStyle.Regular, GraphicsUnit.Point);
		richTextBox_0.BackColor = Color.White;
		richTextBox_0.ForeColor = Color.Black;
		tableLayoutPanel_2.Controls.Add(richTextBox_0, 0, 2);
	}

	private void method_9(TableLayoutPanel tableLayoutPanel_2)
	{
		tableLayoutPanel_1.Dock = DockStyle.Fill;
		tableLayoutPanel_1.ColumnCount = 4;
		tableLayoutPanel_1.RowCount = 1;
		tableLayoutPanel_1.Height = 36;
		tableLayoutPanel_1.Padding = new Padding(8, 4, 8, 4);
		tableLayoutPanel_1.Margin = new Padding(0);
		tableLayoutPanel_1.Visible = false;
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel_1.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1648996030),
			AutoSize = true,
			Anchor = AnchorStyles.Left
		}, 0, 0);
		textBox_4.Dock = DockStyle.Fill;
		tableLayoutPanel_1.Controls.Add(textBox_4, 1, 0);
		button_2.Text = Class16.smethod_0(1648999325);
		button_2.AutoSize = true;
		button_3.Text = Class16.smethod_0(1648973883);
		button_3.AutoSize = true;
		tableLayoutPanel_1.Controls.Add(button_2, 2, 0);
		tableLayoutPanel_1.Controls.Add(button_3, 3, 0);
		tableLayoutPanel_2.Controls.Add(tableLayoutPanel_1, 0, 3);
	}

	private void method_10(TableLayoutPanel tableLayoutPanel_2)
	{
		panel_1.Dock = DockStyle.Fill;
		panel_1.Padding = new Padding(0);
		panel_1.Margin = new Padding(0);
		panel_1.Visible = false;
		label_0.Dock = DockStyle.Top;
		label_0.Text = Class16.smethod_0(1649278869);
		label_0.Height = 24;
		label_0.TextAlign = ContentAlignment.MiddleLeft;
		label_0.Padding = new Padding(8, 0, 0, 0);
		dataGridView_2.Dock = DockStyle.Fill;
		dataGridView_2.AllowUserToAddRows = false;
		dataGridView_2.AllowUserToDeleteRows = false;
		dataGridView_2.AllowUserToResizeRows = false;
		dataGridView_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_2.MultiSelect = false;
		dataGridView_2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView_2.RowHeadersVisible = false;
		if (dataGridView_2.Columns.Count == 0)
		{
			dataGridView_2.Columns.Add(Class16.smethod_0(1649278884), Class16.smethod_0(1649275253));
			dataGridView_2.Columns.Add(Class16.smethod_0(1649278902), Class16.smethod_0(1649275277));
			dataGridView_2.Columns.Add(Class16.smethod_0(1649278914), Class16.smethod_0(1649275287));
			dataGridView_2.Columns[0].FillWeight = 18f;
			dataGridView_2.Columns[1].FillWeight = 18f;
			dataGridView_2.Columns[2].FillWeight = 210f;
		}
		panel_1.Controls.Add(dataGridView_2);
		panel_1.Controls.Add(label_0);
		tableLayoutPanel_2.Controls.Add(panel_1, 0, 4);
	}

	private void method_11(TableLayoutPanel tableLayoutPanel_2)
	{
		StatusStrip statusStrip = new StatusStrip
		{
			Dock = DockStyle.Bottom
		};
		statusStrip.Items.Add(toolStripStatusLabel_0);
		statusStrip.Items.Add(new ToolStripStatusLabel
		{
			Spring = true
		});
		statusStrip.Items.Add(toolStripStatusLabel_2);
		statusStrip.Items.Add(new ToolStripSeparator());
		statusStrip.Items.Add(toolStripStatusLabel_1);
		tableLayoutPanel_2.Controls.Add(statusStrip, 0, 5);
	}

	private void method_12()
	{
		Panel panel = new Panel
		{
			Dock = DockStyle.Fill
		};
		splitContainer_2.Panel2.Controls.Add(panel);
		ToolStrip toolStrip = new ToolStrip
		{
			Dock = DockStyle.Top,
			GripStyle = ToolStripGripStyle.Hidden
		};
		toolStripButton_5.CheckOnClick = true;
		toolStripButton_5.Checked = true;
		toolStripButton_5.Text = Class16.smethod_0(1649275876);
		toolStripButton_5.Image = smethod_5(Class16.smethod_0(1649278835));
		toolStripButton_6.CheckOnClick = true;
		toolStripButton_6.Checked = true;
		toolStripButton_6.Text = Class16.smethod_0(1649275883);
		toolStripButton_9.Text = Class16.smethod_0(1648991736);
		toolStripButton_9.Image = smethod_5(Class16.smethod_0(1649278807));
		toolStripButton_7.Text = Class16.smethod_0(1649275902);
		toolStripButton_8.Text = Class16.smethod_0(1649086694);
		toolStripButton_10.Text = Class16.smethod_0(1648941518);
		toolStripButton_11.Text = Class16.smethod_0(1648941500);
		toolStripButton_12.Text = Class16.smethod_0(1648926675);
		toolStrip.Items.Add(toolStripButton_5);
		toolStrip.Items.Add(toolStripButton_6);
		toolStrip.Items.Add(new ToolStripSeparator());
		toolStrip.Items.Add(toolStripButton_9);
		toolStrip.Items.Add(new ToolStripSeparator());
		toolStrip.Items.Add(toolStripButton_7);
		toolStrip.Items.Add(toolStripButton_8);
		toolStrip.Items.Add(new ToolStripSeparator());
		toolStrip.Items.Add(toolStripButton_10);
		toolStrip.Items.Add(toolStripButton_11);
		toolStrip.Items.Add(toolStripButton_12);
		toolStrip.Items.Add(toolStripLabel_0);
		toolStrip.Items.Add(new ToolStripSeparator());
		toolStrip.Items.Add(toolStripDropDownButton_0);
		toolStrip.Items.Add(new ToolStripSeparator());
		toolStrip.Items.Add(toolStripButton_13);
		toolStrip.Items.Add(toolStripButton_14);
		panel_0.Dock = DockStyle.Fill;
		panel_0.AutoScroll = true;
		panel_0.Padding = new Padding(8);
		panel_0.BackColor = Color.FromArgb(238, 242, 247);
		panel.Controls.Add(panel_0);
		panel.Controls.Add(toolStrip);
		previewCanvasPanel_0.Location = new Point(0, 0);
		previewCanvasPanel_0.Size = new Size(900, 700);
		previewCanvasPanel_0.BackColor = Color.Transparent;
		panel_0.Controls.Add(previewCanvasPanel_0);
	}

	private static GroupBox smethod_0(string string_4)
	{
		return new GroupBox
		{
			Text = string_4,
			Dock = DockStyle.Top,
			AutoSize = true,
			AutoSizeMode = AutoSizeMode.GrowAndShrink,
			Padding = new Padding(6, 4, 6, 6),
			Margin = new Padding(0, 0, 0, 4),
			Font = new Font(Class16.smethod_0(1648942905), 8.5f, FontStyle.Bold)
		};
	}

	private static TableLayoutPanel smethod_1(int int_3)
	{
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			AutoSize = true,
			AutoSizeMode = AutoSizeMode.GrowAndShrink,
			ColumnCount = int_3,
			Padding = new Padding(0),
			Margin = new Padding(0)
		};
		for (int i = 0; i < int_3; i++)
		{
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / (float)int_3));
		}
		return tableLayoutPanel;
	}

	private static void smethod_2(Button button_25, bool bool_15)
	{
		button_25.Dock = DockStyle.Top;
		button_25.Height = 30;
		button_25.Margin = new Padding(2);
		button_25.FlatStyle = FlatStyle.Flat;
		button_25.FlatAppearance.BorderSize = 1;
		button_25.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		button_25.Cursor = Cursors.Hand;
		button_25.UseVisualStyleBackColor = !bool_15;
		if (bool_15)
		{
			button_25.BackColor = Color.FromArgb(43, 85, 117);
			button_25.ForeColor = Color.White;
			button_25.FlatAppearance.BorderColor = Color.FromArgb(33, 70, 100);
		}
	}

	private void method_13()
	{
		method_19();
		method_120();
		timer_0.Tick += timer_0_Tick;
		textBox_2.TextChanged += textBox_2_TextChanged;
		textBox_2.KeyDown += textBox_2_KeyDown;
		button_4.Click += button_4_Click;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		richTextBox_0.TextChanged += richTextBox_0_TextChanged;
		richTextBox_0.SelectionChanged += richTextBox_0_SelectionChanged;
		textBox_3.KeyDown += textBox_3_KeyDown;
		textBox_4.KeyDown += textBox_4_KeyDown;
		button_0.Click += button_0_Click;
		button_1.Click += button_1_Click;
		button_2.Click += button_2_Click;
		button_3.Click += button_3_Click;
		toolStripButton_0.Click += toolStripButton_0_Click;
		toolStripButton_1.Click += toolStripButton_1_Click;
		toolStripButton_2.Click += toolStripButton_2_Click;
		toolStripButton_3.Click += toolStripButton_3_Click;
		toolStripButton_4.Click += toolStripButton_4_Click;
		toolStripButton_5.Click += toolStripButton_5_Click;
		toolStripButton_6.Click += toolStripButton_6_Click;
		toolStripButton_7.Click += toolStripButton_7_Click;
		toolStripButton_8.Click += toolStripButton_8_Click;
		toolStripButton_13.Click += toolStripButton_13_Click;
		toolStripButton_14.Click += toolStripButton_14_Click;
		toolStripButton_9.Click += toolStripButton_9_Click;
		toolStripButton_10.Click += toolStripButton_10_Click;
		toolStripButton_11.Click += toolStripButton_11_Click;
		toolStripButton_12.Click += toolStripButton_12_Click;
		button_5.Click += button_5_Click;
		button_6.Click += button_6_Click;
		button_7.Click += button_7_Click;
		button_8.Click += button_8_Click;
		button_9.Click += button_9_Click;
		button_10.Click += button_10_Click;
		button_11.Click += button_11_Click;
		button_12.Click += button_12_Click;
		button_13.Click += button_13_Click;
		button_14.Click += button_14_Click;
		button_15.Click += button_15_Click;
		button_16.Click += button_16_Click;
		button_17.Click += button_17_Click;
		button_18.Click += button_18_Click;
		button_19.Click += button_19_Click;
		button_20.Click += button_20_Click;
		button_21.Click += button_21_Click;
		button_22.Click += button_22_Click;
		button_23.Click += button_23_Click;
		button_24.Click += button_24_Click;
		checkBox_2.CheckedChanged += checkBox_2_CheckedChanged;
		checkBox_3.CheckedChanged += checkBox_3_CheckedChanged;
		checkBox_4.CheckedChanged += checkBox_4_CheckedChanged;
		dataGridView_1.CellDoubleClick += dataGridView_1_CellDoubleClick;
		dataGridView_2.CellDoubleClick += dataGridView_2_CellDoubleClick;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridView_0.CellDoubleClick += dataGridView_0_CellDoubleClick;
		propertyGrid_0.PropertyValueChanged += propertyGrid_0_PropertyValueChanged;
		previewCanvasPanel_0.MouseDown += panel_0_MouseDown;
		previewCanvasPanel_0.MouseMove += panel_0_MouseMove;
		previewCanvasPanel_0.MouseUp += panel_0_MouseUp;
		previewCanvasPanel_0.MouseWheel += panel_0_MouseWheel;
		panel_0.MouseDown += panel_0_MouseDown;
		panel_0.MouseMove += panel_0_MouseMove;
		panel_0.MouseUp += panel_0_MouseUp;
		panel_0.MouseWheel += panel_0_MouseWheel;
		base.MouseWheel += UIXmlEditorForm_MouseWheel;
		base.Shown += UIXmlEditorForm_Shown;
		base.Resize += UIXmlEditorForm_Resize;
		base.Shown += UIXmlEditorForm_Shown_1;
	}

	private void method_14()
	{
		int num = richTextBox_0.GetLineFromCharIndex(richTextBox_0.SelectionStart) + 1;
		int num2 = richTextBox_0.SelectionStart - richTextBox_0.GetFirstCharIndexOfCurrentLine() + 1;
		toolStripStatusLabel_2.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649278943), Class16.smethod_0(1649278955)), num, num2);
	}

	private void method_15(bool bool_15)
	{
		string text = textBox_3.Text.Trim();
		if (text.Length == 0)
		{
			return;
		}
		string text2 = richTextBox_0.Text;
		if (text2.Length != 0)
		{
			int startIndex = (bool_15 ? Math.Min(text2.Length, richTextBox_0.SelectionStart + Math.Max(1, richTextBox_0.SelectionLength)) : Math.Max(0, richTextBox_0.SelectionStart - 1));
			int num = (bool_15 ? text2.IndexOf(text, startIndex, StringComparison.OrdinalIgnoreCase) : text2.LastIndexOf(text, startIndex, StringComparison.OrdinalIgnoreCase));
			if (num < 0)
			{
				num = (bool_15 ? text2.IndexOf(text, 0, StringComparison.OrdinalIgnoreCase) : text2.LastIndexOf(text, text2.Length - 1, StringComparison.OrdinalIgnoreCase));
			}
			if (num >= 0)
			{
				richTextBox_0.Focus();
				richTextBox_0.SelectionStart = num;
				richTextBox_0.SelectionLength = text.Length;
				richTextBox_0.ScrollToCaret();
				method_14();
			}
		}
	}

	private void method_16(string string_4)
	{
		int selectionStart = richTextBox_0.SelectionStart;
		richTextBox_0.SelectedText = string_4;
		richTextBox_0.SelectionStart = Math.Min(selectionStart + string_4.Length, richTextBox_0.TextLength);
		richTextBox_0.SelectionLength = 0;
		method_55();
		method_126(bool_15: true);
	}

	private void method_17()
	{
		string text = textBox_0.Text.Trim();
		if (string.IsNullOrWhiteSpace(text) || !Directory.Exists(text))
		{
			return;
		}
		using SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Title = method_131(Class16.smethod_0(1649277953), Class16.smethod_0(1649277977), Array.Empty<object>()),
			InitialDirectory = text,
			Filter = Class16.smethod_0(1649278007),
			FileName = Class16.smethod_0(1649278049),
			OverwritePrompt = true
		};
		if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			string text2 = Class16.smethod_0(1649278078);
			UiSourceFile file = new UiSourceFile
			{
				FilePath = saveFileDialog.FileName,
				RootPath = text,
				HasBom = true,
				EncodingName = Class16.smethod_0(1649275591)
			};
			uiXmlFileService_0.SaveFileContent(file, text2);
			method_48(text);
		}
	}

	private void method_18()
	{
		if (uiSourceFile_0 == null)
		{
			return;
		}
		string text = System.IO.Path.GetDirectoryName(uiSourceFile_0.FilePath) ?? textBox_0.Text.Trim();
		string fileName = System.IO.Path.GetFileNameWithoutExtension(uiSourceFile_0.FilePath) + Class16.smethod_0(1649278190);
		using SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Title = method_131(Class16.smethod_0(1649278206), Class16.smethod_0(1649278225), Array.Empty<object>()),
			InitialDirectory = (Directory.Exists(text) ? text : textBox_0.Text.Trim()),
			Filter = Class16.smethod_0(1649278007),
			FileName = fileName,
			OverwritePrompt = true
		};
		if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			string text2 = ((richTextBox_0.TextLength > 0) ? richTextBox_0.Text : uiXmlFileService_0.LoadFileContent(uiSourceFile_0));
			UiSourceFile file = new UiSourceFile
			{
				FilePath = saveFileDialog.FileName,
				RootPath = textBox_0.Text.Trim(),
				HasBom = true,
				EncodingName = Class16.smethod_0(1649275591)
			};
			uiXmlFileService_0.SaveFileContent(file, text2);
			method_48(textBox_0.Text.Trim());
		}
	}

	private void method_19()
	{
		if (contextMenuStrip_0.Items.Count <= 0)
		{
			contextMenuStrip_0.Items.AddRange(new ToolStripItem[9]
			{
				toolStripMenuItem_0,
				toolStripMenuItem_1,
				new ToolStripSeparator(),
				toolStripMenuItem_2,
				toolStripMenuItem_3,
				toolStripMenuItem_4,
				new ToolStripSeparator(),
				toolStripMenuItem_5,
				toolStripMenuItem_6
			});
			toolStripMenuItem_0.Click += toolStripMenuItem_0_Click;
			toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
			toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
			toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
			toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
			toolStripMenuItem_5.Click += toolStripMenuItem_5_Click;
			toolStripMenuItem_6.Click += toolStripMenuItem_6_Click;
		}
	}

	private void method_20(Control control_0, Point point_5)
	{
		bool enabled = uiControlModel_1 != null;
		toolStripMenuItem_0.Enabled = enabled;
		toolStripMenuItem_2.Enabled = enabled;
		toolStripMenuItem_3.Enabled = enabled;
		toolStripMenuItem_4.Enabled = enabled;
		toolStripMenuItem_5.Enabled = enabled;
		toolStripMenuItem_6.Enabled = enabled;
		toolStripMenuItem_1.Enabled = uiControlModel_0 != null && !string.IsNullOrWhiteSpace(string_0);
		contextMenuStrip_0.Show(control_0, point_5);
	}

	private void method_21()
	{
		Class372 @class = new Class372();
		if (uiControlModel_1 != null && uiSourceFile_0 != null)
		{
			@class.string_0 = smethod_22(uiControlModel_1);
			string string_ = (string.Equals(string_3, @class.string_0, StringComparison.OrdinalIgnoreCase) ? null : string_3);
			string[] ienumerable_ = hashSet_0.Where(@class.method_0).ToArray();
			string string_2 = uiLayoutParser_0.RemoveControl(richTextBox_0.Text, uiControlModel_1);
			method_31(string_2, ienumerable_, string_);
		}
	}

	private void method_22()
	{
		string string_;
		if (uiControlModel_1 != null)
		{
			string_ = uiLayoutParser_0.DuplicateControl(richTextBox_0.Text, uiControlModel_1, 16, 16);
			method_31(string_, null, null);
			return;
		}
		Point point = ((point_0.X == int.MinValue || point_0.Y == int.MinValue) ? new Point(16, 16) : point_0);
		string controlXml = Class16.smethod_0(1649278250);
		string_ = uiLayoutParser_0.InsertControlXml(richTextBox_0.Text, controlXml, point.X, point.Y);
		method_31(string_, null, null);
	}

	private void method_23(int int_3)
	{
		if (uiControlModel_1 != null)
		{
			string string_ = smethod_22(uiControlModel_1);
			string[] ienumerable_ = hashSet_0.ToArray();
			string string_2 = uiLayoutParser_0.MoveControlLayer(richTextBox_0.Text, uiControlModel_1, int_3);
			method_31(string_2, ienumerable_, string_);
		}
	}

	private void method_24()
	{
		List<UiControlModel> list = method_89();
		if (list.Count == 0)
		{
			return;
		}
		bool flag = list.Any(method_135);
		foreach (UiControlModel item2 in list)
		{
			string item = smethod_22(item2);
			if (flag)
			{
				hashSet_1.Add(item);
			}
			else
			{
				hashSet_1.Remove(item);
			}
		}
		method_29();
	}

	private void method_25(bool bool_15)
	{
		List<UiControlModel> list = method_89();
		if (list.Count < 2)
		{
			return;
		}
		if (bool_15)
		{
			int int32_ = (int)Math.Round(((IEnumerable<UiControlModel>)list).Average((Func<UiControlModel, int>)Class382.class382_0.method_0), MidpointRounding.AwayFromZero);
			foreach (UiControlModel item in list)
			{
				item.Int32_0 = int32_;
			}
		}
		else
		{
			int int32_2 = (int)Math.Round(((IEnumerable<UiControlModel>)list).Average((Func<UiControlModel, int>)Class382.class382_0.method_1), MidpointRounding.AwayFromZero);
			foreach (UiControlModel item2 in list)
			{
				item2.Int32_1 = int32_2;
			}
		}
		method_86(list);
		method_29();
	}

	private void method_26()
	{
		bool_8 = checkBox_2.Checked;
		method_29();
	}

	private void method_27()
	{
		if (splitContainer_2 != null)
		{
			splitContainer_2.Panel1Collapsed = checkBox_3.Checked;
			method_37();
		}
	}

	private void method_28()
	{
		if (splitContainer_0 != null)
		{
			splitContainer_0.Panel1Collapsed = checkBox_4.Checked;
			method_37();
		}
	}

	private void method_29()
	{
		if (uiDialogModel_0 != null)
		{
			method_127(uiDialogModel_0);
			method_75(uiDialogModel_0);
			method_94();
		}
	}

	private void panel_0_MouseDown(object? sender, MouseEventArgs e)
	{
		Control control_ = (sender as Control) ?? previewCanvasPanel_0;
		Point point_ = method_108(control_, e.Location);
		if (e.Button == MouseButtons.Middle)
		{
			method_105();
		}
		else if (e.Button == MouseButtons.Right)
		{
			method_82(point_);
			method_20(control_, e.Location);
		}
		else if (e.Button == MouseButtons.Left)
		{
			method_109(point_, (Control.ModifierKeys & Keys.Control) == Keys.Control);
		}
	}

	private void panel_0_MouseMove(object? sender, MouseEventArgs e)
	{
		Control control_ = (sender as Control) ?? previewCanvasPanel_0;
		Point point_ = method_108(control_, e.Location);
		if (bool_11)
		{
			method_110(point_);
		}
		else if (bool_9)
		{
			method_106();
		}
	}

	private void panel_0_MouseUp(object? sender, MouseEventArgs e)
	{
		Control control_ = (sender as Control) ?? previewCanvasPanel_0;
		Point point_ = method_108(control_, e.Location);
		if (e.Button == MouseButtons.Left && bool_11)
		{
			method_111(point_);
		}
		else if (e.Button == MouseButtons.Middle)
		{
			method_107();
		}
	}

	private void panel_0_MouseWheel(object? sender, MouseEventArgs e)
	{
		if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
		{
			float num = ((e.Delta > 0) ? 1.12f : (25f / 28f));
			Point value = panel_0.PointToClient(Control.MousePosition);
			method_103(float_0 * num, value);
			if (e is HandledMouseEventArgs e2)
			{
				e2.Handled = true;
			}
		}
	}

	private void UIXmlEditorForm_MouseWheel(object? sender, MouseEventArgs e)
	{
		if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
		{
			return;
		}
		Point value = panel_0.PointToClient(Control.MousePosition);
		if (value.X >= 0 && value.Y >= 0 && value.X <= panel_0.ClientSize.Width && value.Y <= panel_0.ClientSize.Height)
		{
			float num = ((e.Delta > 0) ? 1.12f : (25f / 28f));
			method_103(float_0 * num, value);
			if (e is HandledMouseEventArgs e2)
			{
				e2.Handled = true;
			}
		}
	}

	private void method_30(int int_3)
	{
		if (int_3 < 0 || int_3 >= dataGridView_2.Rows.Count)
		{
			return;
		}
		object value = dataGridView_2.Rows[int_3].Cells[0].Value;
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
				goto IL_0052;
			}
		}
		obj = Class16.smethod_0(1648934925);
		goto IL_0052;
		IL_0052:
		string s = (string)obj;
		if (!int.TryParse(s, out var result))
		{
			result = 1;
		}
		method_67(result);
		method_64(result);
	}

	private void method_31(string? string_4, IEnumerable<string>? ienumerable_0, string? string_5)
	{
		if (string.IsNullOrWhiteSpace(string_4))
		{
			return;
		}
		if (ienumerable_0 != null)
		{
			hashSet_0.Clear();
			foreach (string item in ienumerable_0.Where(Class382.class382_0.method_2))
			{
				hashSet_0.Add(item);
			}
			string_3 = string_5;
		}
		method_52(string_4, bool_15: true, bool_16: true);
		method_55();
		method_126(bool_15: true);
	}

	private Point method_32(UiControlModel uiControlModel_3)
	{
		if (point_0.X != int.MinValue && point_0.Y != int.MinValue)
		{
			return point_0;
		}
		return new Point(Math.Max(0, uiControlModel_3.Int32_0 + 20), Math.Max(0, uiControlModel_3.Int32_1 + 20));
	}

	private static UiControlModel smethod_3(UiControlModel uiControlModel_3)
	{
		return new UiControlModel
		{
			XmlNodeName = uiControlModel_3.XmlNodeName,
			Name = uiControlModel_3.Name,
			Type = uiControlModel_3.Type,
			Int32_0 = uiControlModel_3.Int32_0,
			Int32_1 = uiControlModel_3.Int32_1,
			Width = uiControlModel_3.Width,
			Height = uiControlModel_3.Height,
			Text = uiControlModel_3.Text,
			Hint = uiControlModel_3.Hint,
			Color = uiControlModel_3.Color,
			PrimaryImagePath = uiControlModel_3.PrimaryImagePath,
			SecondaryImagePath = uiControlModel_3.SecondaryImagePath,
			TertiaryImagePath = uiControlModel_3.TertiaryImagePath,
			Layer = uiControlModel_3.Layer
		};
	}

	private void method_33()
	{
		if (uiControlModel_1 != null && smethod_4(richTextBox_0.Text, uiControlModel_1, out var int_))
		{
			method_67(int_);
		}
	}

	private static bool smethod_4(string string_4, UiControlModel uiControlModel_3, out int int_3)
	{
		int_3 = 0;
		if (!string.IsNullOrWhiteSpace(string_4) && !string.IsNullOrWhiteSpace(uiControlModel_3.Name) && !string.IsNullOrWhiteSpace(uiControlModel_3.XmlNodeName))
		{
			string text = Regex.Escape(uiControlModel_3.XmlNodeName);
			string text2 = Regex.Escape(uiControlModel_3.Name);
			string pattern = Class16.smethod_0(1649278358) + text + Class16.smethod_0(1649278361) + text2 + Class16.smethod_0(1649278407);
			Match match = Regex.Match(string_4, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			if (!match.Success)
			{
				string pattern2 = Class16.smethod_0(1649278410) + text2 + Class16.smethod_0(1649278407);
				match = Regex.Match(string_4, pattern2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
				if (!match.Success)
				{
					return false;
				}
			}
			int_3 = 1;
			for (int i = 0; i < match.Index; i++)
			{
				if (string_4[i] == '\n')
				{
					int_3++;
				}
			}
			return true;
		}
		return false;
	}

	private void method_34()
	{
		timer_0?.Dispose();
		uiImageLoader_0?.Dispose();
		uiPckProvider_0?.Dispose();
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (keyData != (Keys.Add | Keys.Control) && keyData != (Keys.Oemplus | Keys.Control))
		{
			if (keyData != (Keys.Subtract | Keys.Control) && keyData != (Keys.OemMinus | Keys.Control))
			{
				if (keyData != (Keys.D0 | Keys.Control) && keyData != (Keys.NumPad0 | Keys.Control))
				{
					switch (keyData)
					{
					case Keys.S | Keys.Control:
						method_57();
						return true;
					case Keys.F | Keys.Control:
						textBox_3.Focus();
						textBox_3.SelectAll();
						return true;
					case Keys.F | Keys.Shift | Keys.Control:
						textBox_2.Focus();
						textBox_2.SelectAll();
						return true;
					case Keys.F5:
						method_126(bool_15: true);
						return true;
					case Keys.Z | Keys.Control:
						method_38();
						return true;
					case Keys.Y | Keys.Control:
						method_39();
						return true;
					case Keys.H | Keys.Control:
						method_114();
						return true;
					case Keys.E | Keys.Control:
						method_117();
						return true;
					case Keys.Delete:
						if (!richTextBox_0.ContainsFocus && !propertyGrid_0.ContainsFocus)
						{
							method_21();
							return true;
						}
						break;
					}
					if (method_87(keyData))
					{
						return true;
					}
					return base.ProcessCmdKey(ref msg, keyData);
				}
				method_103(1f, null);
				return true;
			}
			method_103(float_0 / 1.12f, null);
			return true;
		}
		method_103(float_0 * 1.12f, null);
		return true;
	}

	protected override void OnFormClosing(FormClosingEventArgs formClosingEventArgs_0)
	{
		if (bool_1)
		{
			switch (DKBox.Show(method_131(Class16.smethod_0(1649278459), Class16.smethod_0(1649277470), Array.Empty<object>()), method_131(Class16.smethod_0(1649277520), Class16.smethod_0(1649128537), Array.Empty<object>()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
			case DialogResult.Cancel:
				formClosingEventArgs_0.Cancel = true;
				return;
			case DialogResult.Yes:
				method_57();
				if (bool_1)
				{
					formClosingEventArgs_0.Cancel = true;
					return;
				}
				break;
			}
		}
		method_47();
		method_34();
		base.OnFormClosing(formClosingEventArgs_0);
	}

	private void method_35()
	{
		method_13();
	}

	private void method_36()
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
		Color backColor = (TDark.IsDarkMode ? Color.FromArgb(30, 30, 30) : Color.FromArgb(248, 251, 255));
		Color foreColor = (TDark.IsDarkMode ? Color.FromArgb(220, 220, 220) : Color.FromArgb(31, 35, 40));
		richTextBox_0.BackColor = backColor;
		richTextBox_0.ForeColor = foreColor;
		panel_0.BackColor = (TDark.IsDarkMode ? Color.FromArgb(42, 42, 44) : Color.FromArgb(238, 242, 247));
		panel_1.BackColor = (TDark.IsDarkMode ? Color.FromArgb(37, 37, 38) : Color.FromArgb(247, 249, 252));
		label_0.BackColor = (TDark.IsDarkMode ? Color.FromArgb(45, 45, 48) : Color.FromArgb(236, 240, 246));
		label_0.ForeColor = foreColor;
		dataGridView_2.BackgroundColor = panel_1.BackColor;
		dataGridView_2.DefaultCellStyle.BackColor = (TDark.IsDarkMode ? Color.FromArgb(30, 30, 30) : Color.White);
		dataGridView_2.DefaultCellStyle.ForeColor = foreColor;
		dataGridView_2.ColumnHeadersDefaultCellStyle.BackColor = (TDark.IsDarkMode ? Color.FromArgb(45, 45, 48) : Color.FromArgb(236, 240, 246));
		dataGridView_2.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;
		dataGridView_2.EnableHeadersVisualStyles = false;
		dataGridView_2.GridColor = (TDark.IsDarkMode ? Color.FromArgb(62, 62, 66) : Color.FromArgb(215, 221, 231));
		previewCanvasPanel_0.BackColor = Color.Transparent;
		previewCanvasPanel_0.BackgroundMode = previewBackgroundMode_0;
	}

	private static Image? smethod_5(string string_4)
	{
		try
		{
			string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Class16.smethod_0(1649277543), Class16.smethod_0(1649008358), string_4);
			if (File.Exists(path))
			{
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				try
				{
					using Image original = Image.FromStream(fileStream);
					return new Bitmap(original);
				}
				finally
				{
					((IDisposable)fileStream).Dispose();
				}
			}
			return null;
		}
		catch
		{
			return null;
		}
	}

	private void method_37()
	{
		smethod_24(splitContainer_0, 320, 720, 380);
		smethod_24(splitContainer_1, 480, 140, 700);
		smethod_24(splitContainer_2, 420, 280, 760);
	}

	private static int smethod_6(int int_3, int int_4, int int_5)
	{
		if (int_3 < int_4)
		{
			return int_4;
		}
		if (int_3 > int_5)
		{
			return int_5;
		}
		return int_3;
	}

	private void method_38()
	{
		if (list_1.Count != 0)
		{
			string item = richTextBox_0.Text;
			List<string> list = list_1;
			string string_ = list[list.Count - 1];
			list_1.RemoveAt(list_1.Count - 1);
			list_2.Add(item);
			if (list_2.Count > 260)
			{
				list_2.RemoveAt(0);
			}
			bool_14 = true;
			try
			{
				method_52(string_, bool_15: true, bool_16: false);
			}
			finally
			{
				bool_14 = false;
			}
			method_55();
			method_126(bool_15: true);
			method_43();
		}
	}

	private void method_39()
	{
		if (list_2.Count != 0)
		{
			string item = richTextBox_0.Text;
			List<string> list = list_2;
			string string_ = list[list.Count - 1];
			list_2.RemoveAt(list_2.Count - 1);
			list_1.Add(item);
			if (list_1.Count > 260)
			{
				list_1.RemoveAt(0);
			}
			bool_14 = true;
			try
			{
				method_52(string_, bool_15: true, bool_16: false);
			}
			finally
			{
				bool_14 = false;
			}
			method_55();
			method_126(bool_15: true);
			method_43();
		}
	}

	private void method_40()
	{
		list_1.Clear();
		list_2.Clear();
		string_2 = richTextBox_0.Text ?? string.Empty;
		method_43();
	}

	private void method_41()
	{
		if (!bool_0 && !bool_14)
		{
			string a = richTextBox_0.Text ?? string.Empty;
			if (!string.Equals(a, string_2, StringComparison.Ordinal))
			{
				method_42(string_2);
				string_2 = a;
				method_43();
			}
		}
	}

	private void method_42(string string_4)
	{
		string text = string_4 ?? string.Empty;
		if (list_1.Count > 0)
		{
			List<string> list = list_1;
			if (string.Equals(list[list.Count - 1], text, StringComparison.Ordinal))
			{
				return;
			}
		}
		list_1.Add(text);
		if (list_1.Count > 260)
		{
			list_1.RemoveAt(0);
		}
		list_2.Clear();
	}

	private void method_43()
	{
		toolStripButton_3.Enabled = list_1.Count > 0;
		toolStripButton_4.Enabled = list_2.Count > 0;
	}

	private void method_44()
	{
		bool_2 = toolStripButton_5.Checked;
		foreach (PreviewItemPanel value in dictionary_0.Values)
		{
			value.ShowOutline = bool_2;
			value.Invalidate();
		}
	}

	private void method_45()
	{
		if (textBox_2.TextLength != 0)
		{
			textBox_2.Clear();
			method_49();
			textBox_2.Focus();
		}
	}

	private void method_46()
	{
		uiEditorSettings_0 = UiEditorSettingsStore.Load();
		method_40();
		string text = string.Empty;
		string text2 = string.Empty;
		try
		{
			if (CommonStorage.Params != null)
			{
				text = CommonStorage.Params.SurfacesPckDir ?? string.Empty;
				text2 = CommonStorage.Params.SurfacesPckPath ?? string.Empty;
			}
		}
		catch
		{
		}
		string text3 = ((!string.IsNullOrWhiteSpace(uiEditorSettings_0.InterfacesPckPath)) ? uiEditorSettings_0.InterfacesPckPath : text);
		string text4 = ((!string.IsNullOrWhiteSpace(uiEditorSettings_0.SurfacesPckPath)) ? uiEditorSettings_0.SurfacesPckPath : text2);
		if (!string.IsNullOrWhiteSpace(text3))
		{
			if (uiPckProvider_0.OpenInterfacesPck(text3))
			{
				textBox_0.Text = text3;
				method_125();
			}
			else
			{
				textBox_0.Text = method_131(Class16.smethod_0(1649277556), Class16.smethod_0(1649277580), Array.Empty<object>());
			}
		}
		if (!string.IsNullOrWhiteSpace(text4))
		{
			if (uiPckProvider_0.OpenSurfacesPck(text4))
			{
				textBox_1.Text = text4;
			}
			else
			{
				textBox_1.Text = method_131(Class16.smethod_0(1649277556), Class16.smethod_0(1649277580), Array.Empty<object>());
			}
		}
		toolStripStatusLabel_0.Text = method_131(Class16.smethod_0(1649277595), Class16.smethod_0(1649277630), Array.Empty<object>());
	}

	private void method_47()
	{
		uiEditorSettings_0.InterfacesPckPath = uiPckProvider_0.InterfacesPckPath;
		uiEditorSettings_0.SurfacesPckPath = uiPckProvider_0.SurfacesPckPath;
		UiEditorSettingsStore.Save(uiEditorSettings_0);
	}

	private void method_48(string string_4)
	{
		list_0.Clear();
		dictionary_1.Clear();
		if (!string.IsNullOrWhiteSpace(string_4))
		{
			list_0.AddRange(uiXmlFileService_0.LoadSourceFiles(string_4));
		}
		method_49();
	}

	private void method_49()
	{
		Class377 @class = new Class377();
		@class.uixmlEditorForm_0 = this;
		string text = textBox_2.Text.Trim();
		@class.string_0 = text.Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(Class382.class382_0.method_3).Where(Class382.class382_0.method_4)
			.ToArray();
		IEnumerable<UiSourceFile> source = list_0;
		if (@class.string_0.Length != 0)
		{
			@class.bool_0 = checkBox_0.Checked;
			source = list_0.Where(@class.method_0);
		}
		UiSourceFile uiSourceFile = listBox_0.SelectedItem as UiSourceFile;
		listBox_0.BeginUpdate();
		listBox_0.Items.Clear();
		foreach (UiSourceFile item in source.OrderBy(Class382.class382_0.method_5, StringComparer.OrdinalIgnoreCase).ThenBy(Class382.class382_0.method_6, StringComparer.OrdinalIgnoreCase))
		{
			listBox_0.Items.Add(item);
		}
		listBox_0.EndUpdate();
		if (uiSourceFile == null)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < listBox_0.Items.Count)
			{
				if (listBox_0.Items[num] is UiSourceFile uiSourceFile2 && string.Equals(uiSourceFile2.FilePath, uiSourceFile.FilePath, StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		listBox_0.SelectedIndex = num;
	}

	private bool method_50(UiSourceFile uiSourceFile_1, IReadOnlyList<string> ireadOnlyList_0, bool bool_15)
	{
		string text = uiSourceFile_1.FileName + Class16.smethod_0(1648942211) + uiSourceFile_1.RelativeDirectory;
		string text2 = null;
		foreach (string item in ireadOnlyList_0)
		{
			if (text.IndexOf(item, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				continue;
			}
			if (bool_15)
			{
				try
				{
					if (text2 == null)
					{
						text2 = (uiPckProvider_0.InterfacesPckLoaded ? (uiPckProvider_0.ReadInterfacesText(uiSourceFile_1.FilePath) ?? string.Empty) : uiXmlFileService_0.LoadFileContent(uiSourceFile_1));
					}
				}
				catch
				{
					return false;
				}
				if (text2.IndexOf(item, StringComparison.OrdinalIgnoreCase) < 0)
				{
					return false;
				}
				continue;
			}
			return false;
		}
		return true;
	}

	private void method_51()
	{
		if (!(listBox_0.SelectedItem is UiSourceFile uiSourceFile))
		{
			return;
		}
		if (bool_1)
		{
			switch (DKBox.Show(method_131(Class16.smethod_0(1649277666), Class16.smethod_0(1649277700), Array.Empty<object>()), method_131(Class16.smethod_0(1649277520), Class16.smethod_0(1649128537), Array.Empty<object>()), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
			case DialogResult.Cancel:
				return;
			case DialogResult.Yes:
				method_57();
				if (bool_1)
				{
					return;
				}
				break;
			}
		}
		try
		{
			timer_0.Stop();
			uiSourceFile_0 = uiSourceFile;
			uiControlModel_0 = null;
			string_0 = null;
			hashSet_1.Clear();
			hashSet_0.Clear();
			string_3 = null;
			uiControlModel_1 = null;
			previewItemPanel_0 = null;
			propertyGrid_0.SelectedObject = null;
			float_0 = 1f;
			bool_9 = false;
			method_104();
			point_0 = new Point(int.MinValue, int.MinValue);
			string string_ = ((!uiPckProvider_0.InterfacesPckLoaded) ? uiXmlFileService_0.LoadFileContent(uiSourceFile) : (uiPckProvider_0.ReadInterfacesText(uiSourceFile.FilePath) ?? string.Empty));
			method_52(string_, bool_15: false, bool_16: false);
			method_40();
			method_54();
			toolStripStatusLabel_1.Text = uiSourceFile.FileName + Class16.smethod_0(1648899468) + uiSourceFile.EncodingName + (uiSourceFile.HasBom ? Class16.smethod_0(1649277789) : Class16.smethod_0(1649277774)) + Class16.smethod_0(1648942897);
			method_126(bool_15: true);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649277793));
			DKBox.Show(method_131(Class16.smethod_0(1649277832), Class16.smethod_0(1649277857), new object[1] { ex.Message }), method_131(Class16.smethod_0(1649277520), Class16.smethod_0(1649128537), Array.Empty<object>()), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_52(string string_4, bool bool_15, bool bool_16)
	{
		string a = string_4 ?? string.Empty;
		if (bool_16 && !bool_14 && !bool_0 && !string.Equals(a, string_2, StringComparison.Ordinal))
		{
			method_42(string_2);
		}
		bool_0 = true;
		richTextBox_0.Text = a;
		bool_0 = false;
		string_2 = a;
		method_43();
		method_14();
	}

	private void method_53()
	{
		if (!bool_0)
		{
			method_41();
			method_55();
			timer_0.Interval = smethod_8(richTextBox_0.TextLength);
			timer_0.Stop();
			timer_0.Start();
		}
	}

	private void method_54()
	{
		string_1 = smethod_7(richTextBox_0.Text);
		string_2 = richTextBox_0.Text ?? string.Empty;
		method_56(bool_15: false);
	}

	private void method_55()
	{
		if (uiSourceFile_0 == null)
		{
			method_56(bool_15: false);
			return;
		}
		string a = smethod_7(richTextBox_0.Text);
		method_56(!string.Equals(a, string_1, StringComparison.Ordinal));
	}

	private static string smethod_7(string string_4)
	{
		return (string_4 ?? string.Empty).TrimStart('\ufeff').Replace(Class16.smethod_0(1648924428), Class16.smethod_0(1648941987)).Replace('\r', '\n');
	}

	private void method_56(bool bool_15)
	{
		bool_1 = bool_15;
		toolStripButton_0.Enabled = bool_15 && uiSourceFile_0 != null;
		string text = (bool_1 ? Class16.smethod_0(1648993379) : string.Empty);
		Text = method_131(Class16.smethod_0(1649277520), Class16.smethod_0(1649128537), Array.Empty<object>()) + text;
	}

	private void method_57()
	{
		if (uiSourceFile_0 == null)
		{
			return;
		}
		try
		{
			string text = richTextBox_0.Text;
			if (checkBox_1.Checked)
			{
				string text2 = uiLayoutParser_0.FormatXml(text);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					text = text2;
					method_52(text, bool_15: false, bool_16: true);
				}
			}
			if (uiPckProvider_0.InterfacesPckLoaded)
			{
				uiPckProvider_0.WriteInterfacesFile(uiSourceFile_0.FilePath, text);
			}
			else
			{
				uiXmlFileService_0.SaveFileContent(uiSourceFile_0, text);
			}
			method_54();
			toolStripStatusLabel_1.Text = uiSourceFile_0.FileName + Class16.smethod_0(1648899468) + uiSourceFile_0.EncodingName + (uiSourceFile_0.HasBom ? Class16.smethod_0(1649277789) : Class16.smethod_0(1649277774)) + Class16.smethod_0(1648942897);
			toolStripStatusLabel_0.Text = (uiPckProvider_0.InterfacesPckLoaded ? method_131(Class16.smethod_0(1649277932), Class16.smethod_0(1649276934), new object[1] { uiSourceFile_0.FileName }) : method_131(Class16.smethod_0(1649277895), Class16.smethod_0(1649277917), new object[1] { uiSourceFile_0.FileName }));
			method_126(bool_15: true);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649276947));
			DKBox.Show(method_131(Class16.smethod_0(1649276985), Class16.smethod_0(1649277010), new object[1] { ex.Message }), method_131(Class16.smethod_0(1649277520), Class16.smethod_0(1649128537), Array.Empty<object>()), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_58()
	{
		if (uiSourceFile_0 == null)
		{
			return;
		}
		try
		{
			timer_0.Stop();
			string string_;
			if (uiPckProvider_0.InterfacesPckLoaded)
			{
				uiPckProvider_0.ClearCache();
				string_ = uiPckProvider_0.ReadInterfacesText(uiSourceFile_0.FilePath) ?? string.Empty;
			}
			else
			{
				string_ = uiXmlFileService_0.LoadFileContent(uiSourceFile_0);
			}
			method_52(string_, bool_15: false, bool_16: false);
			method_40();
			method_54();
			method_126(bool_15: true);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649277032));
			DKBox.Show(method_131(Class16.smethod_0(1649277072), Class16.smethod_0(1649277099), new object[1] { ex.Message }), method_131(Class16.smethod_0(1649277520), Class16.smethod_0(1649128537), Array.Empty<object>()), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_59()
	{
		string text = uiLayoutParser_0.FormatXml(richTextBox_0.Text);
		if (!string.IsNullOrEmpty(text))
		{
			int selectionStart = richTextBox_0.SelectionStart;
			method_52(text ?? string.Empty, bool_15: false, bool_16: true);
			richTextBox_0.SelectionStart = Math.Min(selectionStart, richTextBox_0.TextLength);
			method_55();
			method_126(bool_15: true);
		}
	}

	private static int smethod_8(int int_3)
	{
		if (int_3 > 60000)
		{
			return 1800;
		}
		if (int_3 > 30000)
		{
			return 1400;
		}
		if (int_3 > 12000)
		{
			return 1000;
		}
		return 650;
	}

	private void method_60(bool bool_15)
	{
		panel_1.Visible = bool_15;
		if (tableLayoutPanel_0 != null && tableLayoutPanel_0.RowStyles.Count > 4)
		{
			tableLayoutPanel_0.RowStyles[4].Height = (bool_15 ? 130 : 0);
		}
	}

	private void method_61(bool bool_15)
	{
		tableLayoutPanel_1.Visible = bool_15;
		bool_13 = bool_15;
		if (tableLayoutPanel_0 != null && tableLayoutPanel_0.RowStyles.Count > 3)
		{
			tableLayoutPanel_0.RowStyles[3].Height = (bool_15 ? 36 : 0);
		}
	}

	private Struct115 method_62()
	{
		Struct115 struct115_ = default(Struct115);
		try
		{
			SendMessage_1(richTextBox_0.Handle, 1245, IntPtr.Zero, ref struct115_);
		}
		catch
		{
		}
		return struct115_;
	}

	private void method_63(Struct115 struct115_0)
	{
		try
		{
			SendMessage_1(richTextBox_0.Handle, 1246, IntPtr.Zero, ref struct115_0);
		}
		catch
		{
		}
	}

	private void method_64(int int_3)
	{
		if (int_3 <= 0)
		{
			return;
		}
		method_65();
		int num = int_3 - 1;
		if (num >= 0 && num < richTextBox_0.Lines.Length)
		{
			int firstCharIndexFromLine = richTextBox_0.GetFirstCharIndexFromLine(num);
			if (firstCharIndexFromLine >= 0)
			{
				int length = richTextBox_0.Lines[num].Length;
				int selectionStart = richTextBox_0.SelectionStart;
				int selectionLength = richTextBox_0.SelectionLength;
				Color selectionColor = (TDark.IsDarkMode ? TDark.DarkFore : Color.Black);
				Color selectionBackColor = (TDark.IsDarkMode ? Color.FromArgb(83, 62, 26) : Color.FromArgb(255, 244, 207));
				richTextBox_0.Select(firstCharIndexFromLine, length);
				richTextBox_0.SelectionBackColor = selectionBackColor;
				richTextBox_0.SelectionColor = selectionColor;
				richTextBox_0.SelectionStart = selectionStart;
				richTextBox_0.SelectionLength = selectionLength;
				int_0 = int_3;
			}
		}
	}

	private void method_65()
	{
		if (int_0 <= 0)
		{
			return;
		}
		int num = int_0 - 1;
		if (num >= 0 && num < richTextBox_0.Lines.Length)
		{
			int firstCharIndexFromLine = richTextBox_0.GetFirstCharIndexFromLine(num);
			if (firstCharIndexFromLine >= 0)
			{
				int length = richTextBox_0.Lines[num].Length;
				int selectionStart = richTextBox_0.SelectionStart;
				int selectionLength = richTextBox_0.SelectionLength;
				Color selectionBackColor = (TDark.IsDarkMode ? Color.FromArgb(30, 30, 30) : Color.White);
				Color selectionColor = (TDark.IsDarkMode ? TDark.DarkFore : Color.Black);
				richTextBox_0.Select(firstCharIndexFromLine, length);
				richTextBox_0.SelectionBackColor = selectionBackColor;
				richTextBox_0.SelectionColor = selectionColor;
				richTextBox_0.SelectionStart = selectionStart;
				richTextBox_0.SelectionLength = selectionLength;
			}
		}
		int_0 = 0;
	}

	private void method_66(int int_3)
	{
		if (int_3 < 0 || int_3 >= dataGridView_1.Rows.Count)
		{
			return;
		}
		object value = dataGridView_1.Rows[int_3].Cells[0].Value;
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
				goto IL_0052;
			}
		}
		obj = Class16.smethod_0(1648934925);
		goto IL_0052;
		IL_0052:
		string s = (string)obj;
		if (!int.TryParse(s, out var result))
		{
			result = 1;
		}
		method_67(result);
	}

	private void method_67(int int_3)
	{
		int num = Math.Max(1, int_3) - 1;
		if (num >= richTextBox_0.Lines.Length)
		{
			num = richTextBox_0.Lines.Length - 1;
		}
		if (num >= 0)
		{
			int firstCharIndexFromLine = richTextBox_0.GetFirstCharIndexFromLine(num);
			if (firstCharIndexFromLine >= 0)
			{
				richTextBox_0.Focus();
				richTextBox_0.SelectionStart = firstCharIndexFromLine;
				richTextBox_0.SelectionLength = 0;
				richTextBox_0.ScrollToCaret();
			}
		}
	}

	private void method_68()
	{
		dictionary_0.Clear();
		previewCanvasPanel_0.Controls.Clear();
		previewCanvasPanel_0.DialogBackgroundImage = null;
		previewCanvasPanel_0.DialogBackgroundBounds = Rectangle.Empty;
		previewCanvasPanel_0.DialogBackgroundUseNineSlice = false;
		previewCanvasPanel_0.DialogBackgroundPadding = new Padding(0);
		previewCanvasPanel_0.SelectionRectangle = Rectangle.Empty;
		previewCanvasPanel_0.Size = new Size(800, 600);
		previewCanvasPanel_0.ContextMenuStrip = contextMenuStrip_0;
		panel_0.AutoScrollMinSize = previewCanvasPanel_0.Size;
		int_1 = 0;
		int_2 = 0;
		dataGridView_0.Rows.Clear();
		propertyGrid_0.SelectedObject = null;
		uiControlModel_1 = null;
		previewItemPanel_0 = null;
		hashSet_0.Clear();
		string_3 = null;
		dictionary_2.Clear();
		bool_9 = false;
		bool_11 = false;
		bool_12 = false;
		point_0 = new Point(int.MinValue, int.MinValue);
		dataGridView_2.Rows.Clear();
		method_60(bool_15: false);
		method_104();
	}

	private static bool smethod_9(Image? image_0)
	{
		if (image_0 != null && image_0.Width >= 24)
		{
			return image_0.Height >= 24;
		}
		return false;
	}

	private static Padding smethod_10(Image? image_0)
	{
		if (image_0 == null)
		{
			return new Padding(0);
		}
		int num = Math.Max(4, Math.Min(24, image_0.Width / 6));
		int num2 = Math.Max(4, Math.Min(24, image_0.Height / 6));
		return new Padding(num, num2, num, num2);
	}

	private void method_69(PreviewItemPanel previewItemPanel_2, UiControlModel uiControlModel_3)
	{
		previewItemPanel_2.Controls.Clear();
		previewItemPanel_2.ContextMenuStrip = contextMenuStrip_0;
		previewItemPanel_2.PreviewImage = uiImageLoader_0.TryLoad(uiControlModel_3.PrimaryImagePath);
		previewItemPanel_2.Caption = smethod_13(uiControlModel_3);
		previewItemPanel_2.CaptionColor = smethod_21(uiControlModel_3);
		previewItemPanel_2.CaptionAlignment = smethod_19(uiControlModel_3);
		previewItemPanel_2.CaptionOffsetX = uiControlModel_3.TextOffsetX;
		previewItemPanel_2.CaptionOffsetY = uiControlModel_3.TextOffsetY;
		previewItemPanel_2.OutlineEnabled = uiControlModel_3.Outline || !string.IsNullOrWhiteSpace(uiControlModel_3.OutlineColor);
		previewItemPanel_2.OutlineColor = smethod_20(uiControlModel_3.OutlineColor, TDark.IsDarkMode ? Color.FromArgb(190, 10, 10, 10) : Color.FromArgb(190, 22, 22, 22));
		previewItemPanel_2.CaptionWordWrap = uiControlModel_3.Type != UiControlType.StillImageButton && uiControlModel_3.Type != UiControlType.Radio && uiControlModel_3.Type != UiControlType.Check && uiControlModel_3.Type != UiControlType.Combo;
		previewItemPanel_2.DrawCaption = smethod_14(uiControlModel_3, previewItemPanel_2.PreviewImage, previewItemPanel_2.Caption);
		previewItemPanel_2.FillFallbackBackground = smethod_15(uiControlModel_3, previewItemPanel_2.PreviewImage);
		previewItemPanel_2.UseNineSlice = smethod_16(uiControlModel_3, previewItemPanel_2.PreviewImage);
		previewItemPanel_2.NineSlicePadding = smethod_17(previewItemPanel_2.PreviewImage, uiControlModel_3.Type);
		previewItemPanel_2.FallbackBackgroundColor = Color.FromArgb(30, 180, 180, 180);
		previewItemPanel_2.BackColor = Color.Transparent;
		previewItemPanel_2.Invalidate();
	}

	private PreviewItemPanel method_70(UiControlModel uiControlModel_3, int int_3, int int_4, bool bool_15, List<PreviewItemPanel> list_3)
	{
		Rectangle rectangle = smethod_11(uiControlModel_3, int_3, int_4);
		PreviewItemPanel previewItemPanel = new PreviewItemPanel
		{
			Left = method_96(rectangle.X),
			Top = method_97(rectangle.Y),
			Width = method_100(Math.Max(1, rectangle.Width)),
			Height = method_100(Math.Max(1, rectangle.Height)),
			Model = (bool_15 ? uiControlModel_3 : null),
			ShowOutline = bool_2,
			Cursor = (bool_15 ? Cursors.SizeAll : Cursors.Default)
		};
		if (bool_15)
		{
			previewItemPanel.MouseDown += method_81;
			previewItemPanel.MouseMove += method_83;
			previewItemPanel.MouseUp += method_84;
			previewItemPanel.Click += method_77;
			previewItemPanel.MouseWheel += panel_0_MouseWheel;
		}
		else
		{
			previewItemPanel.ContextMenuStrip = null;
		}
		method_69(previewItemPanel, uiControlModel_3);
		if (!bool_15)
		{
			previewItemPanel.ContextMenuStrip = null;
		}
		previewCanvasPanel_0.Controls.Add(previewItemPanel);
		if (bool_15)
		{
			dictionary_0[uiControlModel_3] = previewItemPanel;
		}
		list_3.Add(previewItemPanel);
		return previewItemPanel;
	}

	private static Rectangle smethod_11(UiControlModel uiControlModel_3, int int_3, int int_4)
	{
		int num = int_3;
		int num2 = Math.Max(1, uiControlModel_3.Width);
		int num3 = Math.Max(1, uiControlModel_3.Height);
		if ((uiControlModel_3.Type == UiControlType.Label || uiControlModel_3.Type == UiControlType.Text) && !uiControlModel_3.HasExplicitWidth)
		{
			if (uiControlModel_3.Align == 1)
			{
				num -= num2 / 2;
			}
			else if (uiControlModel_3.Align == 2)
			{
				num -= num2;
			}
		}
		return new Rectangle(num, int_4, num2, num3);
	}

	private void method_71(UiControlModel uiControlModel_3, string string_4, List<PreviewItemPanel> list_3)
	{
		method_70(uiControlModel_3, uiControlModel_3.Int32_0, uiControlModel_3.Int32_1, bool_15: true, list_3);
		if (!string.IsNullOrWhiteSpace(uiControlModel_3.DialogFile) && method_72(uiControlModel_3.DialogFile, string_4, out UiDialogModel uiDialogModel_, out string string_5))
		{
			HashSet<string> hashSet_ = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { string_5 };
			Rectangle rectangle_ = new Rectangle(uiControlModel_3.Int32_0, uiControlModel_3.Int32_1, Math.Max(1, uiControlModel_3.Width), Math.Max(1, uiControlModel_3.Height));
			string string_6 = System.IO.Path.GetDirectoryName(string_5) ?? string_4;
			method_128(uiDialogModel_, uiControlModel_3.Int32_0, uiControlModel_3.Int32_1, rectangle_, string_6, hashSet_, 1, list_3);
		}
	}

	private static void smethod_12(List<PreviewItemPanel> list_3)
	{
		foreach (PreviewItemPanel item in list_3)
		{
			item.BringToFront();
		}
	}

	private bool method_72(string string_4, string string_5, out UiDialogModel uiDialogModel_1, out string string_6)
	{
		uiDialogModel_1 = new UiDialogModel();
		string_6 = method_73(string_4, string_5);
		if (!string.IsNullOrWhiteSpace(string_6) && File.Exists(string_6))
		{
			DateTime lastWriteTimeUtc;
			try
			{
				lastWriteTimeUtc = File.GetLastWriteTimeUtc(string_6);
			}
			catch
			{
				return false;
			}
			if (dictionary_1.TryGetValue(string_6, out (DateTime, UiDialogModel) value) && value.Item1 == lastWriteTimeUtc)
			{
				uiDialogModel_1 = value.Item2;
				return true;
			}
			try
			{
				UiSourceFile file = new UiSourceFile
				{
					FilePath = string_6,
					RootPath = textBox_0.Text.Trim()
				};
				string xmlText = uiXmlFileService_0.LoadFileContent(file);
				string currentFileDirectory = System.IO.Path.GetDirectoryName(string_6) ?? string_5;
				if (!uiLayoutParser_0.TryParse(xmlText, currentFileDirectory, textBox_1.Text.Trim(), out uiDialogModel_1, out XmlException _))
				{
					return false;
				}
				dictionary_1[string_6] = (lastWriteTimeUtc, uiDialogModel_1);
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	private string method_73(string string_4, string string_5)
	{
		Class380 @class = new Class380();
		if (string.IsNullOrWhiteSpace(string_4))
		{
			return string.Empty;
		}
		string text = string_4.Replace('/', '\\').Trim();
		if (System.IO.Path.IsPathRooted(text))
		{
			return text;
		}
		@class.string_0 = text.TrimStart('\\');
		string text2 = System.IO.Path.Combine(string_5 ?? string.Empty, @class.string_0);
		if (File.Exists(text2))
		{
			return text2;
		}
		string path = textBox_0.Text.Trim();
		string text3 = System.IO.Path.Combine(path, @class.string_0);
		if (File.Exists(text3))
		{
			return text3;
		}
		UiSourceFile uiSourceFile = list_0.FirstOrDefault(@class.method_0);
		if (uiSourceFile != null && File.Exists(uiSourceFile.FilePath))
		{
			return uiSourceFile.FilePath;
		}
		return text2;
	}

	private void method_74(Control control_0, PreviewItemPanel previewItemPanel_2)
	{
		Class374 @class = new Class374();
		@class.control_0 = control_0;
		@class.uixmlEditorForm_0 = this;
		@class.previewItemPanel_0 = previewItemPanel_2;
		@class.control_0.MouseDown += @class.method_0;
		@class.control_0.MouseMove += @class.method_1;
		@class.control_0.MouseUp += @class.method_2;
		@class.control_0.Click += @class.method_3;
	}

	private static string smethod_13(UiControlModel uiControlModel_3)
	{
		if (!string.IsNullOrWhiteSpace(uiControlModel_3.Text))
		{
			return uiControlModel_3.Text;
		}
		if (uiControlModel_3.Type != UiControlType.Label && uiControlModel_3.Type != UiControlType.Text)
		{
			return string.Empty;
		}
		return uiControlModel_3.Name;
	}

	private static bool smethod_14(UiControlModel uiControlModel_3, Image? image_0, string string_4)
	{
		if (string.IsNullOrWhiteSpace(string_4))
		{
			return false;
		}
		if (image_0 == null)
		{
			return true;
		}
		if (uiControlModel_3.Type != UiControlType.Label && uiControlModel_3.Type != UiControlType.Text && uiControlModel_3.Type != UiControlType.Edit && uiControlModel_3.Type != UiControlType.SubDialog && uiControlModel_3.Type != UiControlType.Radio && uiControlModel_3.Type != UiControlType.Combo)
		{
			return uiControlModel_3.Type == UiControlType.StillImageButton;
		}
		return true;
	}

	private static bool smethod_15(UiControlModel uiControlModel_3, Image? image_0)
	{
		if (image_0 != null)
		{
			return false;
		}
		if (uiControlModel_3.Type != UiControlType.StillImageButton && uiControlModel_3.Type != UiControlType.Radio && uiControlModel_3.Type != UiControlType.Check)
		{
			return uiControlModel_3.Type == UiControlType.Combo;
		}
		return true;
	}

	private static bool smethod_16(UiControlModel uiControlModel_3, Image? image_0)
	{
		if (image_0 != null && image_0.Width >= 12 && image_0.Height >= 12)
		{
			if (uiControlModel_3.Type != UiControlType.Edit && uiControlModel_3.Type != UiControlType.List && uiControlModel_3.Type != UiControlType.Text && uiControlModel_3.Type != UiControlType.Combo && uiControlModel_3.Type != UiControlType.StillImageButton && uiControlModel_3.Type != UiControlType.Radio)
			{
				return uiControlModel_3.Type == UiControlType.Check;
			}
			return true;
		}
		return false;
	}

	private static Padding smethod_17(Image? image_0, UiControlType uiControlType_0)
	{
		if (image_0 == null)
		{
			return new Padding(0);
		}
		int num = Math.Max(2, Math.Min(16, image_0.Width / 4));
		int num2 = Math.Max(2, Math.Min(16, image_0.Height / 4));
		if (uiControlType_0 == UiControlType.Radio || uiControlType_0 == UiControlType.Check)
		{
			num = Math.Max(2, Math.Min(8, image_0.Width / 5));
			num2 = Math.Max(2, Math.Min(8, image_0.Height / 5));
		}
		return new Padding(num, num2, num, num2);
	}

	private static ContentAlignment smethod_18(int int_3)
	{
		return int_3 switch
		{
			1 => ContentAlignment.MiddleCenter, 
			2 => ContentAlignment.MiddleRight, 
			3 => ContentAlignment.TopLeft, 
			4 => ContentAlignment.TopCenter, 
			5 => ContentAlignment.TopRight, 
			6 => ContentAlignment.BottomLeft, 
			7 => ContentAlignment.BottomCenter, 
			8 => ContentAlignment.BottomRight, 
			_ => ContentAlignment.MiddleLeft, 
		};
	}

	private static ContentAlignment smethod_19(UiControlModel uiControlModel_3)
	{
		if (uiControlModel_3.Align != 0)
		{
			return smethod_18(uiControlModel_3.Align);
		}
		return uiControlModel_3.Type switch
		{
			UiControlType.Radio => ContentAlignment.MiddleCenter, 
			UiControlType.Check => ContentAlignment.MiddleCenter, 
			UiControlType.StillImageButton => ContentAlignment.MiddleCenter, 
			UiControlType.Label => ContentAlignment.TopLeft, 
			UiControlType.Text => ContentAlignment.TopLeft, 
			UiControlType.Combo => ContentAlignment.MiddleCenter, 
			_ => ContentAlignment.MiddleLeft, 
		};
	}

	private static Color smethod_20(string string_4, Color color_0)
	{
		if (string.IsNullOrWhiteSpace(string_4))
		{
			return color_0;
		}
		string[] array = string_4.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
		List<string> list = new List<string>(array.Length);
		string[] array2 = array;
		foreach (string text in array2)
		{
			string text2 = text.Trim();
			if (text2.Length > 0)
			{
				list.Add(text2);
			}
		}
		if (list.Count >= 3 && byte.TryParse(list[0], out var result) && byte.TryParse(list[1], out var result2) && byte.TryParse(list[2], out var result3))
		{
			byte b = byte.MaxValue;
			if (list.Count >= 4 && byte.TryParse(list[3], out var result4))
			{
				b = result4;
				if (b == 0 && (result > 0 || result2 > 0 || result3 > 0))
				{
					b = byte.MaxValue;
				}
			}
			if (b == 0 && result == 0 && result2 == 0 && result3 == 0)
			{
				return color_0;
			}
			return Color.FromArgb(b, result, result2, result3);
		}
		return color_0;
	}

	private static Color smethod_21(UiControlModel uiControlModel_3)
	{
		Color color_ = uiControlModel_3.Type switch
		{
			UiControlType.Radio => Color.FromArgb(252, 234, 204), 
			UiControlType.Check => Color.FromArgb(252, 234, 204), 
			UiControlType.StillImageButton => Color.FromArgb(252, 234, 204), 
			UiControlType.Label => Color.FromArgb(244, 194, 114), 
			UiControlType.Text => Color.FromArgb(252, 234, 204), 
			UiControlType.Combo => Color.FromArgb(252, 234, 204), 
			_ => Color.FromArgb(236, 236, 236), 
		};
		return smethod_20(uiControlModel_3.Color, color_);
	}

	private void method_75(UiDialogModel uiDialogModel_1)
	{
		dataGridView_0.Rows.Clear();
		foreach (UiControlModel item in uiDialogModel_1.Controls.OrderBy(Class382.class382_0.method_7))
		{
			int index = dataGridView_0.Rows.Add(item.Name, item.Type.ToString(), item.Int32_0, item.Int32_1, item.Layer, method_95(item) ? Class16.smethod_0(1648908444) : Class16.smethod_0(1648908427));
			DataGridViewRow dataGridViewRow = dataGridView_0.Rows[index];
			dataGridViewRow.Tag = item;
			if (!method_95(item))
			{
				dataGridViewRow.DefaultCellStyle.ForeColor = (TDark.IsDarkMode ? Color.Silver : Color.DimGray);
			}
		}
	}

	private void method_76()
	{
		if (!bool_10)
		{
			List<UiControlModel> list = dataGridView_0.SelectedRows.Cast<DataGridViewRow>().Select(Class382.class382_0.method_8).Where(Class382.class382_0.method_9)
				.Cast<UiControlModel>()
				.Distinct()
				.ToList();
			if (list.Count == 0)
			{
				method_91(Array.Empty<UiControlModel>(), null, bool_15: true);
				return;
			}
			UiControlModel uiControlModel_ = (dataGridView_0.CurrentRow?.Tag as UiControlModel) ?? list[0];
			method_91(list, uiControlModel_, bool_15: false);
		}
	}

	private void method_77(object? sender, EventArgs e)
	{
		if (sender is PreviewItemPanel { Model: not null } previewItemPanel)
		{
			if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
			{
				method_90(previewItemPanel.Model);
			}
			else
			{
				method_91(new _003C_003Ez__ReadOnlySingleElementList<UiControlModel>(previewItemPanel.Model), previewItemPanel.Model, bool_15: true);
			}
		}
	}

	private void method_78(UiControlModel uiControlModel_3)
	{
		method_91(new _003C_003Ez__ReadOnlySingleElementList<UiControlModel>(uiControlModel_3), uiControlModel_3, bool_15: true);
	}

	private void method_79()
	{
		if (uiControlModel_1 != null)
		{
			if (dictionary_0.TryGetValue(uiControlModel_1, out PreviewItemPanel value))
			{
				value.Left = method_96(uiControlModel_1.Int32_0);
				value.Top = method_97(uiControlModel_1.Int32_1);
				value.Width = method_100(Math.Max(1, uiControlModel_1.Width));
				value.Height = method_100(Math.Max(1, uiControlModel_1.Height));
				method_69(value, uiControlModel_1);
				value.Invalidate();
			}
			method_85(uiControlModel_1);
			method_80(uiControlModel_1);
		}
	}

	private void method_80(UiControlModel uiControlModel_3)
	{
		foreach (DataGridViewRow item in (IEnumerable)dataGridView_0.Rows)
		{
			if (item.Tag == uiControlModel_3)
			{
				item.Cells[2].Value = uiControlModel_3.Int32_0;
				item.Cells[3].Value = uiControlModel_3.Int32_1;
				item.Cells[5].Value = (method_95(uiControlModel_3) ? Class16.smethod_0(1648908444) : Class16.smethod_0(1648908427));
				break;
			}
		}
	}

	private void method_81(object? sender, MouseEventArgs e)
	{
		Class376 @class = new Class376();
		if (!(sender is PreviewItemPanel { Model: not null } previewItemPanel))
		{
			return;
		}
		if (e.Button == MouseButtons.Middle)
		{
			method_105();
			return;
		}
		if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
		{
			method_90(previewItemPanel.Model);
		}
		else
		{
			method_91(new _003C_003Ez__ReadOnlySingleElementList<UiControlModel>(previewItemPanel.Model), previewItemPanel.Model, bool_15: true);
		}
		if (e.Button == MouseButtons.Right)
		{
			method_82(new Point(previewItemPanel.Left + e.X, previewItemPanel.Top + e.Y));
			method_20(previewItemPanel, e.Location);
		}
		else
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			previewItemPanel_1 = previewItemPanel;
			uiControlModel_2 = previewItemPanel.Model;
			bool_7 = false;
			point_2 = previewCanvasPanel_0.PointToClient(Cursor.Position);
			dictionary_2.Clear();
			List<UiControlModel> list = method_89();
			@class.string_0 = smethod_22(previewItemPanel.Model);
			if (list.Count == 0 || !list.Any(@class.method_0))
			{
				list = new List<UiControlModel>(1) { previewItemPanel.Model };
				method_91(list, previewItemPanel.Model, bool_15: true);
			}
			foreach (UiControlModel item in list)
			{
				dictionary_2[smethod_22(item)] = new Point(item.Int32_0, item.Int32_1);
			}
		}
	}

	private void method_82(Point point_5)
	{
		point_0 = new Point(method_98(point_5.X), method_99(point_5.Y));
	}

	private void method_83(object? sender, MouseEventArgs e)
	{
		if (bool_9)
		{
			method_106();
		}
		else
		{
			if (previewItemPanel_1 == null || uiControlModel_2 == null || e.Button != MouseButtons.Left)
			{
				return;
			}
			Point point = previewCanvasPanel_0.PointToClient(Cursor.Position);
			int num = point.X - point_2.X;
			int num2 = point.Y - point_2.Y;
			int num3 = (int)Math.Round((float)num / Math.Max(0.0001f, float_0), MidpointRounding.AwayFromZero);
			int num4 = (int)Math.Round((float)num2 / Math.Max(0.0001f, float_0), MidpointRounding.AwayFromZero);
			int num5 = Math.Max(1, decimal.ToInt32(numericUpDown_0.Value));
			bool flag = false;
			foreach (KeyValuePair<string, Point> item in dictionary_2)
			{
				string key = item.Key;
				Point value = item.Value;
				UiControlModel uiControlModel = method_88(key);
				if (uiControlModel == null)
				{
					continue;
				}
				int num6 = value.X + num3;
				int num7 = value.Y + num4;
				if (num5 > 1)
				{
					num6 = (int)Math.Round((double)num6 / (double)num5, MidpointRounding.AwayFromZero) * num5;
					num7 = (int)Math.Round((double)num7 / (double)num5, MidpointRounding.AwayFromZero) * num5;
				}
				if (num6 != uiControlModel.Int32_0 || num7 != uiControlModel.Int32_1)
				{
					uiControlModel.Int32_0 = num6;
					uiControlModel.Int32_1 = num7;
					flag = true;
					if (dictionary_0.TryGetValue(uiControlModel, out PreviewItemPanel value2))
					{
						value2.Left = method_96(uiControlModel.Int32_0);
						value2.Top = method_97(uiControlModel.Int32_1);
					}
					method_80(uiControlModel);
				}
			}
			if (flag)
			{
				bool_7 = true;
				toolStripStatusLabel_0.Text = ((dictionary_2.Count > 1) ? string.Format(Class16.smethod_0(1649277145), dictionary_2.Count) : string.Format(Class16.smethod_0(1649277123), uiControlModel_2.Name, uiControlModel_2.Int32_0, uiControlModel_2.Int32_1));
			}
		}
	}

	private void method_84(object? sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Middle && bool_9)
		{
			method_107();
		}
		if (previewItemPanel_1 != null && uiControlModel_2 != null)
		{
			if (!bool_7)
			{
				previewItemPanel_1 = null;
				uiControlModel_2 = null;
				dictionary_2.Clear();
				return;
			}
			List<UiControlModel> ienumerable_ = dictionary_2.Keys.Select(method_88).Where(Class382.class382_0.method_10).Cast<UiControlModel>()
				.ToList();
			method_86(ienumerable_);
			previewItemPanel_1 = null;
			uiControlModel_2 = null;
			bool_7 = false;
			dictionary_2.Clear();
		}
	}

	private void method_85(UiControlModel uiControlModel_3)
	{
		method_86(new _003C_003Ez__ReadOnlySingleElementList<UiControlModel>(uiControlModel_3));
	}

	private void method_86(IEnumerable<UiControlModel> ienumerable_0)
	{
		List<UiControlModel> list = ienumerable_0.Where(Class382.class382_0.method_11).Distinct().ToList();
		if (list.Count == 0)
		{
			return;
		}
		string text = richTextBox_0.Text;
		bool flag = false;
		foreach (UiControlModel item in list)
		{
			string text2 = uiLayoutParser_0.UpdateControlModel(text, item);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text2;
				flag = true;
			}
		}
		if (flag)
		{
			int selectionStart = richTextBox_0.SelectionStart;
			method_52(text, bool_15: false, bool_16: true);
			richTextBox_0.SelectionStart = Math.Min(selectionStart, richTextBox_0.TextLength);
			richTextBox_0.SelectionLength = 0;
			method_55();
		}
	}

	private bool method_87(Keys keys_0)
	{
		if (!richTextBox_0.ContainsFocus && !propertyGrid_0.ContainsFocus)
		{
			if (!(base.ActiveControl is TextBoxBase) && !(base.ActiveControl is NumericUpDown) && !(base.ActiveControl is ComboBox))
			{
				if ((keys_0 & Keys.Control) != Keys.Control && (keys_0 & Keys.Alt) != Keys.Alt)
				{
					Keys keys = keys_0 & Keys.KeyCode;
					int num = (((keys_0 & Keys.Shift) != Keys.Shift) ? 1 : 10);
					int num2 = 0;
					int num3 = 0;
					switch (keys)
					{
					default:
						return false;
					case Keys.Left:
						num2 = -num;
						break;
					case Keys.Up:
						num3 = -num;
						break;
					case Keys.Right:
						num2 = num;
						break;
					case Keys.Down:
						num3 = num;
						break;
					}
					List<UiControlModel> list = method_89();
					if (list.Count == 0)
					{
						return false;
					}
					int num4 = Math.Max(1, decimal.ToInt32(numericUpDown_0.Value));
					foreach (UiControlModel item in list)
					{
						item.Int32_0 += num2;
						item.Int32_1 += num3;
						if (num4 > 1)
						{
							item.Int32_0 = (int)Math.Round((double)item.Int32_0 / (double)num4, MidpointRounding.AwayFromZero) * num4;
							item.Int32_1 = (int)Math.Round((double)item.Int32_1 / (double)num4, MidpointRounding.AwayFromZero) * num4;
						}
						if (dictionary_0.TryGetValue(item, out PreviewItemPanel value))
						{
							value.Left = method_96(item.Int32_0);
							value.Top = method_97(item.Int32_1);
						}
						method_80(item);
					}
					method_86(list);
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private static string smethod_22(UiControlModel uiControlModel_3)
	{
		return uiControlModel_3.XmlNodeName + Class16.smethod_0(1648905535) + uiControlModel_3.Name;
	}

	private UiControlModel? method_88(string string_4)
	{
		Class375 @class = new Class375();
		@class.string_0 = string_4;
		if (uiDialogModel_0 != null && !string.IsNullOrWhiteSpace(@class.string_0))
		{
			return uiDialogModel_0.Controls.FirstOrDefault(@class.method_0);
		}
		return null;
	}

	private List<UiControlModel> method_89()
	{
		if (uiDialogModel_0 == null)
		{
			return new List<UiControlModel>();
		}
		if (hashSet_0.Count == 0 && uiControlModel_1 != null)
		{
			hashSet_0.Add(smethod_22(uiControlModel_1));
		}
		if (hashSet_0.Count == 0)
		{
			return new List<UiControlModel>();
		}
		return uiDialogModel_0.Controls.Where(method_136).ToList();
	}

	private void method_90(UiControlModel uiControlModel_3)
	{
		Class379 @class = new Class379();
		@class.string_0 = smethod_22(uiControlModel_3);
		List<UiControlModel> list = method_89();
		bool flag;
		if (flag = hashSet_0.Contains(@class.string_0))
		{
			list.RemoveAll(@class.method_0);
		}
		else
		{
			list.Add(uiControlModel_3);
		}
		UiControlModel uiControlModel_4 = uiControlModel_3;
		if (flag && string.Equals(string_3, @class.string_0, StringComparison.OrdinalIgnoreCase))
		{
			uiControlModel_4 = Class5.smethod_0(list);
		}
		method_91(list, uiControlModel_4, bool_15: true);
	}

	private void method_91(IEnumerable<UiControlModel> ienumerable_0, UiControlModel? uiControlModel_3, bool bool_15)
	{
		List<UiControlModel> list = ienumerable_0.Where(Class382.class382_0.method_12).Distinct().ToList();
		hashSet_0.Clear();
		foreach (UiControlModel item in list)
		{
			hashSet_0.Add(smethod_22(item));
		}
		if (list.Count == 0)
		{
			uiControlModel_1 = null;
			previewItemPanel_0 = null;
			string_3 = null;
			propertyGrid_0.SelectedObject = null;
			method_92();
			if (bool_15)
			{
				method_93();
			}
			return;
		}
		if (uiControlModel_3 == null || !hashSet_0.Contains(smethod_22(uiControlModel_3)))
		{
			uiControlModel_3 = list[0];
		}
		uiControlModel_1 = uiControlModel_3;
		string_3 = smethod_22(uiControlModel_3);
		propertyGrid_0.SelectedObject = ((list.Count == 1) ? uiControlModel_3 : null);
		method_92();
		if (bool_15)
		{
			method_93();
		}
	}

	private void method_92()
	{
		previewItemPanel_0 = null;
		foreach (KeyValuePair<UiControlModel, PreviewItemPanel> item in dictionary_0)
		{
			UiControlModel key = item.Key;
			PreviewItemPanel value = item.Value;
			bool flag = (value.Selected = hashSet_0.Contains(smethod_22(key)));
			value.Invalidate();
			if (flag && uiControlModel_1 != null && string.Equals(smethod_22(key), smethod_22(uiControlModel_1), StringComparison.OrdinalIgnoreCase))
			{
				previewItemPanel_0 = value;
			}
		}
	}

	private void method_93()
	{
		if (dataGridView_0.Rows.Count == 0)
		{
			return;
		}
		bool_10 = true;
		try
		{
			dataGridView_0.ClearSelection();
			DataGridViewRow dataGridViewRow = null;
			DataGridViewRow dataGridViewRow2 = null;
			foreach (DataGridViewRow item in (IEnumerable)dataGridView_0.Rows)
			{
				if (!(item.Tag is UiControlModel uiControlModel_))
				{
					continue;
				}
				string text = smethod_22(uiControlModel_);
				if (hashSet_0.Contains(text))
				{
					item.Selected = true;
					if (dataGridViewRow2 == null)
					{
						dataGridViewRow2 = item;
					}
					if (string.Equals(text, string_3, StringComparison.OrdinalIgnoreCase))
					{
						dataGridViewRow = item;
					}
				}
			}
			DataGridViewRow dataGridViewRow4 = dataGridViewRow ?? dataGridViewRow2;
			if (dataGridViewRow4 != null && dataGridViewRow4.Cells.Count > 0)
			{
				dataGridView_0.CurrentCell = dataGridViewRow4.Cells[0];
				try
				{
					dataGridView_0.FirstDisplayedScrollingRowIndex = dataGridViewRow4.Index;
					return;
				}
				catch
				{
					return;
				}
			}
		}
		finally
		{
			bool_10 = false;
		}
	}

	private void method_94()
	{
		if (uiDialogModel_0 == null)
		{
			method_91(Array.Empty<UiControlModel>(), null, bool_15: true);
			return;
		}
		if (hashSet_0.Count == 0)
		{
			method_91(Array.Empty<UiControlModel>(), null, bool_15: true);
			return;
		}
		List<UiControlModel> list = uiDialogModel_0.Controls.Where(method_137).ToList();
		UiControlModel uiControlModel_ = list.FirstOrDefault(method_138) ?? Class5.smethod_0(list);
		method_91(list, uiControlModel_, bool_15: true);
	}

	private bool method_95(UiControlModel uiControlModel_3)
	{
		if (bool_8 && (uiControlModel_3.Type == UiControlType.Label || uiControlModel_3.Type == UiControlType.Text))
		{
			return false;
		}
		return !hashSet_1.Contains(smethod_22(uiControlModel_3));
	}

	private int method_96(int int_3)
	{
		return (int)Math.Round((float)(int_3 - int_1 + 16) * float_0, MidpointRounding.AwayFromZero);
	}

	private int method_97(int int_3)
	{
		return (int)Math.Round((float)(int_3 - int_2 + 16) * float_0, MidpointRounding.AwayFromZero);
	}

	private int method_98(int int_3)
	{
		return (int)Math.Round((float)int_3 / Math.Max(0.0001f, float_0), MidpointRounding.AwayFromZero) + int_1 - 16;
	}

	private int method_99(int int_3)
	{
		return (int)Math.Round((float)int_3 / Math.Max(0.0001f, float_0), MidpointRounding.AwayFromZero) + int_2 - 16;
	}

	private int method_100(int int_3)
	{
		return Math.Max(1, (int)Math.Round((float)int_3 * float_0, MidpointRounding.AwayFromZero));
	}

	private Point method_101()
	{
		return new Point(Math.Abs(panel_0.AutoScrollPosition.X), Math.Abs(panel_0.AutoScrollPosition.Y));
	}

	private void method_102(Point point_5)
	{
		Point autoScrollPosition = new Point(Math.Max(0, point_5.X), Math.Max(0, point_5.Y));
		try
		{
			panel_0.AutoScrollPosition = autoScrollPosition;
		}
		catch
		{
		}
	}

	private void method_103(float float_1, Point? nullable_0)
	{
		float num = Math.Max(0.25f, Math.Min(4f, float_1));
		if (Math.Abs(num - float_0) < 0.0001f)
		{
			method_104();
			return;
		}
		Point point = method_101();
		Point point2 = nullable_0 ?? new Point(Math.Max(0, panel_0.ClientSize.Width / 2), Math.Max(0, panel_0.ClientSize.Height / 2));
		int num2 = (int)Math.Round((float)(point.X + point2.X) / Math.Max(0.0001f, float_0), MidpointRounding.AwayFromZero);
		int num3 = (int)Math.Round((float)(point.Y + point2.Y) / Math.Max(0.0001f, float_0), MidpointRounding.AwayFromZero);
		float_0 = num;
		if (uiDialogModel_0 != null)
		{
			method_127(uiDialogModel_0);
			method_75(uiDialogModel_0);
			method_94();
		}
		int num4 = (int)Math.Round((float)num2 * float_0 - (float)point2.X, MidpointRounding.AwayFromZero);
		int num5 = (int)Math.Round((float)num3 * float_0 - (float)point2.Y, MidpointRounding.AwayFromZero);
		method_102(new Point(num4, num5));
		method_104();
	}

	private void method_104()
	{
		int num = (int)Math.Round(float_0 * 100f, MidpointRounding.AwayFromZero);
		toolStripLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649277171), Class16.smethod_0(1649277197)), num);
		toolStripButton_12.Text = string.Format(Class16.smethod_0(1649277213), num);
	}

	private void method_105()
	{
		if (!bool_9)
		{
			bool_9 = true;
			point_3 = Cursor.Position;
			point_4 = method_101();
			panel_0.Capture = true;
			panel_0.Cursor = Cursors.Hand;
		}
	}

	private void method_106()
	{
		if (bool_9)
		{
			Point position = Cursor.Position;
			int num = position.X - point_3.X;
			int num2 = position.Y - point_3.Y;
			method_102(new Point(point_4.X - num, point_4.Y - num2));
		}
	}

	private void method_107()
	{
		if (bool_9)
		{
			bool_9 = false;
			panel_0.Capture = false;
			panel_0.Cursor = Cursors.Default;
		}
	}

	private Point method_108(Control control_0, Point point_5)
	{
		return previewCanvasPanel_0.PointToClient(control_0.PointToScreen(point_5));
	}

	private void method_109(Point point_5, bool bool_15)
	{
		bool_11 = true;
		bool_12 = bool_15;
		point_1 = point_5;
		previewCanvasPanel_0.SelectionRectangle = Rectangle.Empty;
		previewCanvasPanel_0.Capture = true;
		if (!bool_15)
		{
			method_91(Array.Empty<UiControlModel>(), null, bool_15: true);
		}
	}

	private void method_110(Point point_5)
	{
		if (bool_11)
		{
			previewCanvasPanel_0.SelectionRectangle = smethod_23(point_1, point_5);
			previewCanvasPanel_0.Invalidate();
		}
	}

	private void method_111(Point point_5)
	{
		Class378 @class = new Class378();
		@class.point_0 = point_5;
		if (!bool_11)
		{
			return;
		}
		@class.rectangle_0 = smethod_23(point_1, @class.point_0);
		List<UiControlModel> list = dictionary_0.Where(@class.method_0).Select(Class382.class382_0.method_13).ToList();
		List<UiControlModel> list2;
		if (bool_12)
		{
			list2 = method_89();
			foreach (UiControlModel item in list)
			{
				if (!list2.Contains(item))
				{
					list2.Add(item);
				}
			}
		}
		else
		{
			list2 = list;
		}
		UiControlModel uiControlModel_ = ((list2.Count > 0) ? list2[0] : null);
		method_91(list2, uiControlModel_, bool_15: true);
		bool_11 = false;
		bool_12 = false;
		previewCanvasPanel_0.SelectionRectangle = Rectangle.Empty;
		previewCanvasPanel_0.Capture = false;
		previewCanvasPanel_0.Invalidate();
	}

	private static Rectangle smethod_23(Point point_5, Point point_6)
	{
		int num = Math.Min(point_5.X, point_6.X);
		int num2 = Math.Min(point_5.Y, point_6.Y);
		int num3 = Math.Abs(point_5.X - point_6.X);
		int num4 = Math.Abs(point_5.Y - point_6.Y);
		return new Rectangle(num, num2, num3, num4);
	}

	private void method_112()
	{
		string sourceText = richTextBox_0.Text ?? string.Empty;
		UiSourceFile? uiSourceFile = uiSourceFile_0;
		object obj;
		if (uiSourceFile == null)
		{
			obj = null;
		}
		else
		{
			obj = uiSourceFile.FilePath;
			if (obj != null)
			{
				goto IL_0030;
			}
		}
		obj = string.Empty;
		goto IL_0030;
		IL_0030:
		string filePath = (string)obj;
		AITranslationEditorForm aITranslationEditorForm = new AITranslationEditorForm(sourceText, filePath, CommonStorage.AParams.OpenAIApiKey, UniversalTranslator.OpenAIModel);
		try
		{
			if (aITranslationEditorForm.ShowDialog(this) == DialogResult.OK)
			{
				CommonStorage.AParams.OpenAIApiKey = aITranslationEditorForm.ApiKey;
				UniversalTranslator.OpenAIApiKey = aITranslationEditorForm.ApiKey;
				if (!string.IsNullOrWhiteSpace(aITranslationEditorForm.Model))
				{
					UniversalTranslator.OpenAIModel = aITranslationEditorForm.Model;
				}
				method_52(aITranslationEditorForm.ResultText, bool_15: true, bool_16: true);
				method_55();
				method_126(bool_15: true);
			}
		}
		finally
		{
			((IDisposable)aITranslationEditorForm).Dispose();
		}
	}

	private void method_113()
	{
		bool_3 = toolStripButton_6.Checked;
		previewCanvasPanel_0.ShowGrid = bool_3;
		previewCanvasPanel_0.Invalidate();
	}

	private void method_114()
	{
		method_61(!bool_13);
	}

	private void method_115()
	{
		string text = textBox_3.Text;
		if (!string.IsNullOrEmpty(text))
		{
			string selectedText = textBox_4.Text ?? string.Empty;
			if (richTextBox_0.SelectionLength > 0 && string.Equals(richTextBox_0.SelectedText, text, StringComparison.OrdinalIgnoreCase))
			{
				richTextBox_0.SelectedText = selectedText;
			}
			method_15(bool_15: true);
		}
	}

	private void method_116()
	{
		string text = textBox_3.Text;
		if (!string.IsNullOrEmpty(text))
		{
			string replacement = textBox_4.Text ?? string.Empty;
			string text2 = richTextBox_0.Text ?? string.Empty;
			string text3 = Regex.Replace(text2, Regex.Escape(text), replacement, RegexOptions.IgnoreCase);
			if (!string.Equals(text2, text3, StringComparison.Ordinal))
			{
				method_52(text3, bool_15: true, bool_16: true);
				method_55();
				method_126(bool_15: true);
			}
		}
	}

	private void method_117()
	{
		SaveFileDialog obj = new SaveFileDialog
		{
			Title = method_131(Class16.smethod_0(1649277216), Class16.smethod_0(1649277240), Array.Empty<object>()),
			Filter = Class16.smethod_0(1649277276)
		};
		UiSourceFile? uiSourceFile = uiSourceFile_0;
		object obj2;
		if (uiSourceFile == null)
		{
			obj2 = null;
		}
		else
		{
			obj2 = uiSourceFile.FileName;
			if (obj2 != null)
			{
				goto IL_005b;
			}
		}
		obj2 = Class16.smethod_0(1649277298);
		goto IL_005b;
		IL_005b:
		obj.FileName = (string)obj2 + Class16.smethod_0(1649008311);
		obj.OverwritePrompt = true;
		using SaveFileDialog saveFileDialog = obj;
		if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		Bitmap bitmap = new Bitmap(Math.Max(1, previewCanvasPanel_0.Width), Math.Max(1, previewCanvasPanel_0.Height));
		try
		{
			previewCanvasPanel_0.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
			bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
		}
		finally
		{
			((IDisposable)bitmap).Dispose();
		}
	}

	private void method_118()
	{
		int num = Math.Max(1, uiDialogModel_0?.Width ?? 800);
		int num2 = Math.Max(1, uiDialogModel_0?.Height ?? 600);
		int num3 = Math.Max(100, panel_0.ClientSize.Width - 20);
		int num4 = Math.Max(100, panel_0.ClientSize.Height - 20);
		float val = (float)num3 / (float)num;
		float val2 = (float)num4 / (float)num2;
		float float_ = Math.Min(val, val2);
		method_103(float_, null);
	}

	private void method_119()
	{
		if (uiControlModel_1 != null)
		{
			string text = string.Format(Class16.smethod_0(1649277315), uiControlModel_1.Int32_0, uiControlModel_1.Int32_1, uiControlModel_1.Width, uiControlModel_1.Height);
			Clipboard.SetText(text);
			toolStripStatusLabel_0.Text = method_131(Class16.smethod_0(1649277365), Class16.smethod_0(1649277387), Array.Empty<object>());
		}
	}

	private void method_120()
	{
		toolStripDropDownButton_0.DropDownItems.Clear();
		method_121(Class16.smethod_0(1649277429), PreviewBackgroundMode.Checkerboard);
		method_121(Class16.smethod_0(1648900669), PreviewBackgroundMode.Dark);
		method_121(Class16.smethod_0(1649272320), PreviewBackgroundMode.GameScene);
		method_122();
	}

	private void method_121(string string_4, PreviewBackgroundMode previewBackgroundMode_1)
	{
		Class373 @class = new Class373();
		@class.uixmlEditorForm_0 = this;
		@class.previewBackgroundMode_0 = previewBackgroundMode_1;
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(string_4);
		toolStripMenuItem.Click += @class.method_0;
		toolStripDropDownButton_0.DropDownItems.Add(toolStripMenuItem);
	}

	private void method_122()
	{
		string arg = previewBackgroundMode_0 switch
		{
			PreviewBackgroundMode.GameScene => Class16.smethod_0(1649272345), 
			PreviewBackgroundMode.Dark => Class16.smethod_0(1648900669), 
			_ => Class16.smethod_0(1649277429), 
		};
		toolStripDropDownButton_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649272362), Class16.smethod_0(1649272378)), arg);
	}

	private static void smethod_24(SplitContainer? splitContainer_3, int int_3, int int_4, int int_5)
	{
		if (splitContainer_3 == null || splitContainer_3.IsDisposed || splitContainer_3.Panel1Collapsed || splitContainer_3.Panel2Collapsed)
		{
			return;
		}
		int num = ((splitContainer_3.Orientation == Orientation.Vertical) ? splitContainer_3.ClientSize.Width : splitContainer_3.ClientSize.Height);
		int num2 = Math.Max(1, splitContainer_3.SplitterWidth);
		int num3 = num - num2;
		if (num3 <= 0)
		{
			return;
		}
		int num4 = Math.Max(0, int_3);
		int num5 = Math.Max(0, int_4);
		int num6 = num4 + num5;
		if (num6 > num3)
		{
			double num7 = ((num6 == 0) ? 0.5 : ((double)num4 / (double)num6));
			num4 = (int)Math.Floor((double)num3 * num7);
			num5 = num3 - num4;
		}
		int num8 = num4;
		int num9 = num3 - num5;
		if (num9 < num8)
		{
			num4 = 0;
			num5 = 0;
			num8 = 0;
			num9 = num3;
		}
		int splitterDistance = smethod_6(int_5, num8, num9);
		try
		{
			splitContainer_3.Panel1MinSize = num4;
			splitContainer_3.Panel2MinSize = num5;
			splitContainer_3.SplitterDistance = splitterDistance;
		}
		catch
		{
			try
			{
				splitContainer_3.Panel1MinSize = 0;
				splitContainer_3.Panel2MinSize = 0;
				splitContainer_3.SplitterDistance = smethod_6(int_5, 0, num3);
			}
			catch
			{
			}
		}
	}

	private void method_123()
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = method_131(Class16.smethod_0(1649272392), Class16.smethod_0(1649272428), Array.Empty<object>()),
			Filter = Class16.smethod_0(1649272456),
			CheckFileExists = true
		};
		if (!string.IsNullOrWhiteSpace(uiPckProvider_0.InterfacesPckPath))
		{
			openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(uiPckProvider_0.InterfacesPckPath) ?? string.Empty;
		}
		if (openFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			if (uiPckProvider_0.OpenInterfacesPck(openFileDialog.FileName))
			{
				textBox_0.Text = openFileDialog.FileName;
				uiImageLoader_0.ClearCache();
				method_125();
				method_47();
			}
			else
			{
				DKBox.Show(method_131(Class16.smethod_0(1649272506), Class16.smethod_0(1649272542), Array.Empty<object>()), method_131(Class16.smethod_0(1649277520), Class16.smethod_0(1649128537), Array.Empty<object>()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}

	private void method_124()
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = method_131(Class16.smethod_0(1649272571), Class16.smethod_0(1649272600), Array.Empty<object>()),
			Filter = Class16.smethod_0(1649272456),
			CheckFileExists = true
		};
		if (!string.IsNullOrWhiteSpace(uiPckProvider_0.SurfacesPckPath))
		{
			openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(uiPckProvider_0.SurfacesPckPath) ?? string.Empty;
		}
		if (openFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			if (uiPckProvider_0.OpenSurfacesPck(openFileDialog.FileName))
			{
				textBox_1.Text = openFileDialog.FileName;
				method_47();
				uiImageLoader_0.ClearCache();
				method_126(bool_15: true);
			}
			else
			{
				DKBox.Show(method_131(Class16.smethod_0(1649272634), Class16.smethod_0(1649272671), Array.Empty<object>()), method_131(Class16.smethod_0(1649277520), Class16.smethod_0(1649128537), Array.Empty<object>()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}

	private void method_125()
	{
		list_0.Clear();
		dictionary_1.Clear();
		if (uiPckProvider_0.InterfacesPckLoaded)
		{
			string[] interfacesXmlPaths = uiPckProvider_0.GetInterfacesXmlPaths();
			string[] array = interfacesXmlPaths;
			foreach (string text in array)
			{
				string filePath = text.Replace('/', '\\').TrimStart('\\');
				list_0.Add(new UiSourceFile
				{
					FilePath = filePath,
					RootPath = string.Empty,
					EncodingName = Class16.smethod_0(1649272698),
					HasBom = false
				});
			}
		}
		method_49();
	}

	private void method_126(bool bool_15)
	{
		Class381 @class = new Class381();
		@class.uixmlEditorForm_0 = this;
		if (bool_4)
		{
			bool_5 = true;
			bool_6 |= bool_15;
			return;
		}
		bool_4 = true;
		try
		{
			dataGridView_1.Rows.Clear();
			dataGridView_2.Rows.Clear();
			label_0.Text = method_131(Class16.smethod_0(1649272718), Class16.smethod_0(1649278869), Array.Empty<object>());
			method_60(bool_15: false);
			int_0 = 0;
			if (uiSourceFile_0 == null)
			{
				method_68();
				toolStripStatusLabel_0.Text = method_131(Class16.smethod_0(1649277595), Class16.smethod_0(1649277630), Array.Empty<object>());
				return;
			}
			bool flag = false;
			UiDialogModel dialog = null;
			XmlException xmlError = null;
			try
			{
				flag = uiLayoutParser_0.TryParse(richTextBox_0.Text, System.IO.Path.GetDirectoryName(uiSourceFile_0.FilePath) ?? string.Empty, textBox_1.Text.Trim(), out dialog, out xmlError);
			}
			catch (Exception ex)
			{
				flag = false;
				xmlError = new XmlException(Class16.smethod_0(1649272743) + ex.Message, ex);
			}
			object obj;
			if (!flag)
			{
				if (xmlError == null)
				{
					obj = null;
				}
				else
				{
					obj = xmlError.Message;
					if (obj != null)
					{
						goto IL_015b;
					}
				}
				obj = Class16.smethod_0(1649272755);
				goto IL_015b;
			}
			uiDialogModel_0 = dialog;
			toolStripStatusLabel_0.Text = method_131(Class16.smethod_0(1649271857), Class16.smethod_0(1649271883), new object[1] { dialog.Controls.Count.ToString() });
			try
			{
				method_127(dialog);
			}
			catch (Exception ex2)
			{
				method_68();
				toolStripStatusLabel_0.Text = method_131(Class16.smethod_0(1649271914), Class16.smethod_0(1649271944), new object[1] { ex2.Message });
			}
			method_75(dialog);
			method_94();
			return;
			IL_015b:
			string text = (string)obj;
			int num = Math.Max(1, xmlError?.LineNumber ?? 1);
			int num2 = Math.Max(1, xmlError?.LinePosition ?? 1);
			dataGridView_1.Rows.Add(num, num2, text);
			dataGridView_2.Rows.Add(num, num2, text);
			label_0.Text = method_131(Class16.smethod_0(1649272782), Class16.smethod_0(1649272801), new object[1] { Class16.smethod_0(1648934925) });
			method_60(bool_15: true);
			toolStripStatusLabel_0.Text = method_131(Class16.smethod_0(1649272829), Class16.smethod_0(1649271830), new object[3]
			{
				Class16.smethod_0(1648934925),
				num.ToString(),
				num2.ToString()
			});
			int_0 = num;
			try
			{
				method_64(num);
			}
			catch
			{
			}
			method_68();
		}
		catch (Exception ex3)
		{
			toolStripStatusLabel_0.Text = method_131(Class16.smethod_0(1649271983), Class16.smethod_0(1649272013), new object[1] { ex3.Message });
		}
		finally
		{
			bool_4 = false;
			if (bool_5 && !base.IsDisposed)
			{
				@class.bool_0 = bool_6;
				bool_5 = false;
				bool_6 = false;
				this.BeginInvokeSafe(@class.method_0);
			}
		}
	}

	private void method_127(UiDialogModel uiDialogModel_1)
	{
		Point point_ = method_101();
		dictionary_0.Clear();
		List<PreviewItemPanel> list_ = new List<PreviewItemPanel>();
		previewCanvasPanel_0.SuspendLayout();
		try
		{
			previewCanvasPanel_0.Controls.Clear();
			previewCanvasPanel_0.ContextMenuStrip = contextMenuStrip_0;
			previewCanvasPanel_0.BackgroundMode = previewBackgroundMode_0;
			previewItemPanel_1 = null;
			uiControlModel_2 = null;
			bool_7 = false;
			dictionary_2.Clear();
			int num = 0;
			int num2 = 0;
			int num3 = Math.Max(uiDialogModel_1.Width, 200);
			int num4 = Math.Max(uiDialogModel_1.Height, 120);
			if (uiDialogModel_1.Controls.Count > 0)
			{
				// Exclude controls parked far off-screen (PW hides elements at coords like -999999): including
				// them sizes the canvas to ~1,000,000px (clamped to 65535) and offsets the origin so far that
				// the visible dialog is pushed out of view. Size only to controls within a sane range.
				List<UiControlModel> list_4 = ((IEnumerable<UiControlModel>)uiDialogModel_1.Controls).Where((UiControlModel uiControlModel_4) => uiControlModel_4.Int32_0 > -2048 && uiControlModel_4.Int32_0 < 16384 && uiControlModel_4.Int32_1 > -2048 && uiControlModel_4.Int32_1 < 16384).ToList();
				if (list_4.Count > 0)
				{
					num = Math.Min(0, list_4.Min((Func<UiControlModel, int>)Class382.class382_0.method_14));
					num2 = Math.Min(0, list_4.Min((Func<UiControlModel, int>)Class382.class382_0.method_15));
					num3 = Math.Max(num3, list_4.Max((Func<UiControlModel, int>)Class382.class382_0.method_16));
					num4 = Math.Max(num4, list_4.Max((Func<UiControlModel, int>)Class382.class382_0.method_17));
				}
			}
			int_1 = num;
			int_2 = num2;
			int num5 = method_100(Math.Max(200, num3 - num + 32));
			int num6 = method_100(Math.Max(120, num4 - num2 + 32));
			previewCanvasPanel_0.Size = new Size(num5, num6);
			previewCanvasPanel_0.Zoom = float_0;
			previewCanvasPanel_0.ShowGrid = bool_3;
			previewCanvasPanel_0.DialogBackgroundImage = uiImageLoader_0.TryLoad(uiDialogModel_1.BackgroundImagePath);
			previewCanvasPanel_0.DialogBackgroundUseNineSlice = smethod_9(previewCanvasPanel_0.DialogBackgroundImage);
			previewCanvasPanel_0.DialogBackgroundPadding = smethod_10(previewCanvasPanel_0.DialogBackgroundImage);
			previewCanvasPanel_0.DialogBackgroundBounds = new Rectangle(method_96(0), method_97(0), method_100(Math.Max(1, uiDialogModel_1.Width)), method_100(Math.Max(1, uiDialogModel_1.Height)));
			panel_0.AutoScrollMinSize = previewCanvasPanel_0.Size;
			string string_ = ((uiSourceFile_0 == null) ? string.Empty : (System.IO.Path.GetDirectoryName(uiSourceFile_0.FilePath) ?? string.Empty));
			foreach (UiControlModel item in uiDialogModel_1.Controls.OrderBy(Class382.class382_0.method_18))
			{
				if (method_95(item))
				{
					if (item.Type == UiControlType.SubDialog)
					{
						method_71(item, string_, list_);
					}
					else
					{
						method_70(item, item.Int32_0, item.Int32_1, bool_15: true, list_);
					}
				}
			}
			smethod_12(list_);
		}
		finally
		{
			previewCanvasPanel_0.ResumeLayout();
		}
		method_92();
		previewCanvasPanel_0.Invalidate();
		method_102(point_);
		method_104();
	}

	private void method_128(UiDialogModel uiDialogModel_1, int int_3, int int_4, Rectangle rectangle_0, string string_4, HashSet<string> hashSet_2, int int_5, List<PreviewItemPanel> list_3)
	{
		if (int_5 > 4)
		{
			return;
		}
		foreach (UiControlModel item in uiDialogModel_1.Controls.OrderBy(Class382.class382_0.method_19))
		{
			if (bool_8 && (item.Type == UiControlType.Label || item.Type == UiControlType.Text))
			{
				continue;
			}
			int int_6 = int_3 + item.Int32_0;
			int int_7 = int_4 + item.Int32_1;
			if (!new Rectangle(int_6, int_7, Math.Max(1, item.Width), Math.Max(1, item.Height)).IntersectsWith(rectangle_0))
			{
				continue;
			}
			if (item.Type == UiControlType.SubDialog)
			{
				method_70(item, int_6, int_7, bool_15: false, list_3);
				if (!string.IsNullOrWhiteSpace(item.DialogFile) && method_72(item.DialogFile, string_4, out UiDialogModel uiDialogModel_2, out string string_5) && hashSet_2.Add(string_5))
				{
					Rectangle rectangle_1 = Rectangle.Intersect(rectangle_0, new Rectangle(int_6, int_7, Math.Max(1, item.Width), Math.Max(1, item.Height)));
					string string_6 = System.IO.Path.GetDirectoryName(string_5) ?? string_4;
					try
					{
						method_128(uiDialogModel_2, int_6, int_7, rectangle_1, string_6, hashSet_2, int_5 + 1, list_3);
					}
					finally
					{
						hashSet_2.Remove(string_5);
					}
				}
			}
			else
			{
				method_70(item, int_6, int_7, bool_15: false, list_3);
			}
		}
	}

	private void UIXmlEditorForm_Activated(object sender, EventArgs e)
	{
		method_129();
	}

	private void method_129()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_UIXmlEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this, null);
			method_130();
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_UIXmlEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void method_130()
	{
		try
		{
			formTexts_0 = TextStorage.TEXTS.LoadFormTexts(Class16.smethod_0(1649272037));
		}
		catch
		{
			formTexts_0 = null;
		}
	}

	private string method_131(string string_4, string string_5, object[] object_0)
	{
		string text = string_5;
		if (formTexts_0?.Controls != null && formTexts_0.Controls.TryGetValue(string_4, out var value) && value != null)
		{
			int langIndex = TextStorage.TEXTS.LangIndex;
			if (langIndex >= 0 && langIndex < value.Length && !string.IsNullOrEmpty(value[langIndex]))
			{
				text = value[langIndex];
			}
			else if (value.Length > 1 && !string.IsNullOrEmpty(value[1]))
			{
				text = value[1];
			}
		}
		if (object_0.Length != 0)
		{
			string obj;
			string oldValue;
			object obj3;
			for (int i = 0; i < object_0.Length; text = obj.Replace(oldValue, (string)obj3), i++)
			{
				obj = text;
				oldValue = Class16.smethod_0(1648938114) + (i + 1);
				object obj2 = object_0[i];
				if (obj2 == null)
				{
					obj3 = null;
				}
				else
				{
					obj3 = obj2.ToString();
					if (obj3 != null)
					{
						continue;
					}
				}
				obj3 = string.Empty;
			}
		}
		return text.Replace(Class16.smethod_0(1648903412), Class16.smethod_0(1648924428));
	}

	private void method_132(object sender, EventArgs e)
	{
		method_123();
	}

	private void method_133(object sender, EventArgs e)
	{
		method_124();
	}

	private void method_134(object sender, EventArgs e)
	{
		method_45();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Stop();
		method_126(bool_15: false);
	}

	private void textBox_2_TextChanged(object sender, EventArgs e)
	{
		if (!checkBox_0.Checked || textBox_2.TextLength <= 0)
		{
			method_49();
		}
	}

	private void textBox_2_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			method_49();
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		method_49();
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		method_49();
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_51();
	}

	private void richTextBox_0_TextChanged(object sender, EventArgs e)
	{
		method_53();
	}

	private void richTextBox_0_SelectionChanged(object sender, EventArgs e)
	{
		method_14();
	}

	private void textBox_3_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			method_15(!e.Shift);
		}
	}

	private void textBox_4_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			method_115();
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_15(bool_15: false);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_15(bool_15: true);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_115();
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_116();
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		method_57();
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		method_58();
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		method_59();
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		method_38();
	}

	private void toolStripButton_4_Click(object sender, EventArgs e)
	{
		method_39();
	}

	private void toolStripButton_5_Click(object sender, EventArgs e)
	{
		method_44();
	}

	private void toolStripButton_6_Click(object sender, EventArgs e)
	{
		method_113();
	}

	private void toolStripButton_7_Click(object sender, EventArgs e)
	{
		method_123();
	}

	private void toolStripButton_8_Click(object sender, EventArgs e)
	{
		method_124();
	}

	private void toolStripButton_13_Click(object sender, EventArgs e)
	{
		method_123();
	}

	private void toolStripButton_14_Click(object sender, EventArgs e)
	{
		method_124();
	}

	private void toolStripButton_9_Click(object sender, EventArgs e)
	{
		method_126(bool_15: true);
	}

	private void toolStripButton_10_Click(object sender, EventArgs e)
	{
		method_103(float_0 / 1.12f, null);
	}

	private void toolStripButton_11_Click(object sender, EventArgs e)
	{
		method_103(float_0 * 1.12f, null);
	}

	private void toolStripButton_12_Click(object sender, EventArgs e)
	{
		method_103(1f, null);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		method_16(Class16.smethod_0(1649272056));
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		method_16(Class16.smethod_0(1649272168));
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		method_16(Class16.smethod_0(1649272247));
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		method_16(Class16.smethod_0(1649271303));
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		method_17();
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		method_18();
	}

	private void button_11_Click(object sender, EventArgs e)
	{
		method_22();
	}

	private void button_12_Click(object sender, EventArgs e)
	{
		method_21();
	}

	private void button_13_Click(object sender, EventArgs e)
	{
		method_23(1);
	}

	private void button_14_Click(object sender, EventArgs e)
	{
		method_23(-1);
	}

	private void button_15_Click(object sender, EventArgs e)
	{
		method_24();
	}

	private void button_16_Click(object sender, EventArgs e)
	{
		method_23(int.MaxValue);
	}

	private void button_17_Click(object sender, EventArgs e)
	{
		method_23(int.MinValue);
	}

	private void button_18_Click(object sender, EventArgs e)
	{
		method_25(bool_15: true);
	}

	private void button_19_Click(object sender, EventArgs e)
	{
		method_25(bool_15: false);
	}

	private void button_20_Click(object sender, EventArgs e)
	{
		method_117();
	}

	private void button_21_Click(object sender, EventArgs e)
	{
		method_118();
	}

	private void button_22_Click(object sender, EventArgs e)
	{
		method_119();
	}

	private void button_23_Click(object sender, EventArgs e)
	{
		method_114();
	}

	private void button_24_Click(object sender, EventArgs e)
	{
		method_112();
	}

	private void checkBox_2_CheckedChanged(object sender, EventArgs e)
	{
		method_26();
	}

	private void checkBox_3_CheckedChanged(object sender, EventArgs e)
	{
		method_27();
	}

	private void checkBox_4_CheckedChanged(object sender, EventArgs e)
	{
		method_28();
	}

	private void dataGridView_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		method_66(e.RowIndex);
	}

	private void dataGridView_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		method_30(e.RowIndex);
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		method_76();
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		method_33();
	}

	private void propertyGrid_0_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		method_79();
	}

	private void UIXmlEditorForm_Shown(object sender, EventArgs e)
	{
		method_37();
	}

	private void UIXmlEditorForm_Resize(object sender, EventArgs e)
	{
		method_37();
	}

	private void UIXmlEditorForm_Shown_1(object sender, EventArgs e)
	{
		method_36();
		method_104();
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		if (uiControlModel_1 != null)
		{
			uiControlModel_0 = smethod_3(uiControlModel_1);
			string_0 = uiLayoutParser_0.ExportControlXml(richTextBox_0.Text, uiControlModel_1);
		}
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		if (uiControlModel_0 != null && !string.IsNullOrWhiteSpace(string_0) && uiSourceFile_0 != null)
		{
			Point point = method_32(uiControlModel_0);
			string string_ = uiLayoutParser_0.InsertControlXml(richTextBox_0.Text, string_0, point.X, point.Y);
			method_31(string_, null, null);
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		if (uiControlModel_1 != null && uiSourceFile_0 != null)
		{
			string string_ = uiLayoutParser_0.DuplicateControl(richTextBox_0.Text, uiControlModel_1, 20, 20);
			method_31(string_, null, null);
		}
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_21();
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		method_33();
	}

	private void toolStripMenuItem_5_Click(object sender, EventArgs e)
	{
		method_23(int.MaxValue);
	}

	private void toolStripMenuItem_6_Click(object sender, EventArgs e)
	{
		method_23(int.MinValue);
	}

	private bool method_135(UiControlModel uiControlModel_3)
	{
		return !hashSet_1.Contains(smethod_22(uiControlModel_3));
	}

	private bool method_136(UiControlModel uiControlModel_3)
	{
		return hashSet_0.Contains(smethod_22(uiControlModel_3));
	}

	private bool method_137(UiControlModel uiControlModel_3)
	{
		return hashSet_0.Contains(smethod_22(uiControlModel_3));
	}

	private bool method_138(UiControlModel uiControlModel_3)
	{
		return string.Equals(smethod_22(uiControlModel_3), string_3, StringComparison.OrdinalIgnoreCase);
	}
}
