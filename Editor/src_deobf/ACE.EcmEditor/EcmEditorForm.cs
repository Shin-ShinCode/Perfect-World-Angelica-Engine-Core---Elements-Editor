using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;
using ACE.EcmEditor.Models;
using ACE.EcmEditor.Services;
using ACE.Properties;

namespace ACE.EcmEditor;

public class EcmEditorForm : Form
{
	private sealed class Class110
	{
		public EcmVersion ecmVersion_0;

		internal bool method_0(EcmFile ecmFile_0)
		{
			EcmVersion ecmVersion = EcmClassIdentifier.DetectVersion(ecmFile_0.FileName);
			return ecmVersion == ecmVersion_0;
		}
	}

	private sealed class Class111
	{
		public string string_0;

		internal bool method_0(EcmFile ecmFile_0)
		{
			return ecmFile_0.DisplayName.IndexOf(string_0, StringComparison.OrdinalIgnoreCase) >= 0;
		}
	}

	[Serializable]
	private sealed class Class112
	{
		public static readonly Class112 class112_0 = new Class112();

		public static Func<EcmFile, bool> func_0;

		public static Func<EcmFile, bool> func_1;

		internal bool method_0(EcmFile ecmFile_0)
		{
			return ecmFile_0.IsModified;
		}

		internal bool method_1(EcmFile ecmFile_0)
		{
			return ecmFile_0.IsModified;
		}
	}

	private readonly EcmDirectoryScanner ecmDirectoryScanner_0;

	private readonly EcmUndoRedoManager ecmUndoRedoManager_0;

	private List<EcmFile> list_0 = new List<EcmFile>();

	private List<EcmFile> list_1 = new List<EcmFile>();

	private EcmFile ecmFile_0;

	private bool bool_0;

	private string string_0 = string.Empty;

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

	private ToolStripMenuItem toolStripMenuItem_6;

	private ToolStripMenuItem toolStripMenuItem_7;

	private ToolStripMenuItem toolStripMenuItem_8;

	private ToolStripSeparator toolStripSeparator_2;

	private ToolStripMenuItem toolStripMenuItem_9;

	private ToolStripMenuItem toolStripMenuItem_10;

	private ToolStripMenuItem toolStripMenuItem_11;

	private ToolStripSeparator toolStripSeparator_3;

	private ToolStripMenuItem toolStripMenuItem_12;

	private ToolStripMenuItem toolStripMenuItem_13;

	private ToolStripMenuItem toolStripMenuItem_14;

	private ToolStripMenuItem toolStripMenuItem_15;

	private ToolStripMenuItem toolStripMenuItem_16;

	private ToolStripMenuItem toolStripMenuItem_17;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripSeparator toolStripSeparator_4;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private ToolStripSeparator toolStripSeparator_5;

	private ToolStripButton toolStripButton_4;

	private ToolStripButton toolStripButton_5;

	private ToolStripSeparator toolStripSeparator_6;

	private ToolStripButton toolStripButton_6;

	private ToolStripButton toolStripButton_7;

	private ToolStripSeparator toolStripSeparator_7;

	private ToolStripLabel toolStripLabel_0;

	private ToolStripComboBox toolStripComboBox_0;

	private ToolStripSeparator toolStripSeparator_8;

	private ToolStripButton toolStripButton_8;

	private ToolStripButton toolStripButton_9;

	private ToolStripButton toolStripButton_10;

	private ToolStripButton toolStripButton_11;

	private ToolStripSeparator toolStripSeparator_9;

	private ToolStripButton toolStripButton_12;

	private SplitContainer splitContainer_0;

	private Panel panel_0;

	private Label label_0;

	private TextBox textBox_0;

	private CheckedListBox checkedListBox_0;

	private RichTextBox richTextBox_0;

	private StatusStrip statusStrip_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private ToolStripStatusLabel toolStripStatusLabel_1;

	private ToolStripStatusLabel toolStripStatusLabel_2;

	private ToolStripStatusLabel toolStripStatusLabel_3;

	private ToolTip toolTip_0;

	public EcmEditorForm()
		: this(null)
	{
	}

	public EcmEditorForm(string folderPath)
	{
		method_5();
		ecmDirectoryScanner_0 = new EcmDirectoryScanner();
		ecmUndoRedoManager_0 = new EcmUndoRedoManager();
		toolStripComboBox_0.SelectedIndex = 0;
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		base.KeyPreview = true;
		base.KeyDown += EcmEditorForm_KeyDown;
		richTextBox_0.TextChanged += richTextBox_0_TextChanged;
		TextStorage.TEXTS.SetFormLanguage(this);
		method_14();
		if (!string.IsNullOrEmpty(folderPath) && Directory.Exists(folderPath))
		{
			method_1(folderPath);
		}
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
		{
			Description = TextStorage.Msg(Class16.smethod_0(1648996514), Class16.smethod_0(1648996538)),
			ShowNewFolderButton = false
		};
		if (!string.IsNullOrEmpty(string_0) && Directory.Exists(string_0))
		{
			folderBrowserDialog.SelectedPath = string_0;
		}
		if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
		{
			method_1(folderBrowserDialog.SelectedPath);
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		method_0();
	}

	private void method_0()
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = TextStorage.Msg(Class16.smethod_0(1648996579), Class16.smethod_0(1648996613)),
			Filter = Class16.smethod_0(1648996627),
			FilterIndex = 1
		};
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1648996685), Class16.smethod_0(1648996696));
		Application.DoEvents();
		EcmPckReader ecmPckReader = new EcmPckReader(openFileDialog.FileName);
		try
		{
			EcmPckOpenResult ecmPckOpenResult = ecmPckReader.OpenWithAutoKey();
			if (!ecmPckOpenResult.Success)
			{
				MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648996723), Class16.smethod_0(1648996744)) + Class16.smethod_0(1648941987) + ecmPckOpenResult.ErrorMessage, TextStorage.Msg(Class16.smethod_0(1648996769), Class16.smethod_0(1648934892)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				method_14();
				return;
			}
			int selectedIndex = toolStripComboBox_0.SelectedIndex;
			List<EcmPckEntry> list = ((selectedIndex > 0) ? ecmPckReader.FindEcmFiles((EcmVersion)selectedIndex) : ecmPckReader.FindAllEcmFiles());
			if (list.Count == 0)
			{
				MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648996785), Class16.smethod_0(1648996808)), TextStorage.Msg(Class16.smethod_0(1648996854), Class16.smethod_0(1648999936)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				method_14();
				return;
			}
			string text = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Class16.smethod_0(1648999958) + Guid.NewGuid().ToString(Class16.smethod_0(1648930778)).Substring(0, 8));
			Directory.CreateDirectory(text);
			toolStripStatusLabel_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648999973), Class16.smethod_0(1648999986)), list.Count);
			Application.DoEvents();
			(int, int) tuple = ecmPckReader.ExtractEcmFiles(list, text);
			ToolStripStatusLabel toolStripStatusLabel;
			string format;
			object arg;
			object obj;
			if (tuple.Item1 > 0)
			{
				method_1(text);
				toolStripStatusLabel = toolStripStatusLabel_0;
				format = TextStorage.Msg(Class16.smethod_0(1649000016), Class16.smethod_0(1649000045));
				arg = tuple.Item1;
				EcmPckKey detectedKey = ecmPckOpenResult.DetectedKey;
				if (detectedKey == null)
				{
					obj = null;
				}
				else
				{
					obj = detectedKey.Name;
					if (obj != null)
					{
						goto IL_023f;
					}
				}
				obj = Class16.smethod_0(1648942867);
				goto IL_023f;
			}
			MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1649000087), Class16.smethod_0(1649000104)), TextStorage.Msg(Class16.smethod_0(1648996769), Class16.smethod_0(1648934892)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			method_14();
			return;
			IL_023f:
			toolStripStatusLabel.Text = string.Format(format, arg, obj);
		}
		finally
		{
			((IDisposable)ecmPckReader).Dispose();
		}
	}

	private void method_1(string string_1)
	{
		string_0 = string_1;
		list_0 = ecmDirectoryScanner_0.ScanRecursive(string_1);
		method_2();
		Text = Class16.smethod_0(1649000139) + string_1;
		method_14();
	}

	private void method_2()
	{
		Class111 @class = new Class111();
		list_1 = method_3(list_0);
		@class.string_0 = textBox_0.Text.Trim();
		if (!string.IsNullOrEmpty(@class.string_0))
		{
			list_1 = list_1.Where(@class.method_0).ToList();
		}
		checkedListBox_0.Items.Clear();
		foreach (EcmFile item in list_1)
		{
			checkedListBox_0.Items.Add(item, isChecked: false);
		}
		label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649000167), Class16.smethod_0(1649000188)), list_1.Count);
	}

	private List<EcmFile> method_3(List<EcmFile> list_2)
	{
		Class110 @class = new Class110();
		if (toolStripComboBox_0.SelectedIndex <= 0)
		{
			return list_2;
		}
		@class.ecmVersion_0 = ((toolStripComboBox_0.SelectedIndex != 1) ? EcmVersion.Extended : EcmVersion.Standard);
		return list_2.Where(@class.method_0).ToList();
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (list_0.Count != 0)
		{
			method_2();
		}
	}

	private void checkedListBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (checkedListBox_0.SelectedItem is EcmFile ecmFile_)
		{
			method_4(ecmFile_);
		}
	}

	private void method_4(EcmFile ecmFile_1)
	{
		if (ecmFile_0 != null && !bool_0)
		{
			ecmFile_0.CurrentContent = richTextBox_0.Text;
		}
		ecmFile_0 = ecmFile_1;
		if (ecmFile_1.ScriptData == null)
		{
			ecmDirectoryScanner_0.LoadContent(ecmFile_1);
		}
		bool_0 = true;
		richTextBox_0.Text = ecmFile_1.CurrentContent;
		bool_0 = false;
		toolTip_0.SetToolTip(checkedListBox_0, ecmFile_1.FilePath);
		method_14();
	}

	private void richTextBox_0_TextChanged(object sender, EventArgs e)
	{
		if (!bool_0 && ecmFile_0 != null)
		{
			ecmUndoRedoManager_0.PushState(ecmFile_0.FilePath, ecmFile_0.CurrentContent);
			ecmFile_0.CurrentContent = richTextBox_0.Text;
			method_14();
		}
	}

	private void toolStripMenuItem_5_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void toolStripButton_4_Click(object sender, EventArgs e)
	{
		method_9();
	}

	private void toolStripButton_5_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void toolStripMenuItem_10_Click(object sender, EventArgs e)
	{
		method_11(bool_1: true);
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
		icontainer_0 = new Container();
		toolTip_0 = new ToolTip(icontainer_0);
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
		toolStripMenuItem_8 = new ToolStripMenuItem();
		toolStripSeparator_2 = new ToolStripSeparator();
		toolStripMenuItem_9 = new ToolStripMenuItem();
		toolStripMenuItem_10 = new ToolStripMenuItem();
		toolStripMenuItem_11 = new ToolStripMenuItem();
		toolStripSeparator_3 = new ToolStripSeparator();
		toolStripMenuItem_12 = new ToolStripMenuItem();
		toolStripMenuItem_13 = new ToolStripMenuItem();
		toolStripMenuItem_14 = new ToolStripMenuItem();
		toolStripMenuItem_15 = new ToolStripMenuItem();
		toolStripMenuItem_16 = new ToolStripMenuItem();
		toolStripMenuItem_17 = new ToolStripMenuItem();
		toolStrip_0 = new ToolStrip();
		toolStripButton_0 = new ToolStripButton();
		toolStripButton_1 = new ToolStripButton();
		toolStripSeparator_4 = new ToolStripSeparator();
		toolStripButton_2 = new ToolStripButton();
		toolStripButton_3 = new ToolStripButton();
		toolStripSeparator_5 = new ToolStripSeparator();
		toolStripButton_4 = new ToolStripButton();
		toolStripButton_5 = new ToolStripButton();
		toolStripSeparator_6 = new ToolStripSeparator();
		toolStripButton_6 = new ToolStripButton();
		toolStripButton_7 = new ToolStripButton();
		toolStripSeparator_7 = new ToolStripSeparator();
		toolStripLabel_0 = new ToolStripLabel();
		toolStripComboBox_0 = new ToolStripComboBox();
		toolStripSeparator_8 = new ToolStripSeparator();
		toolStripButton_8 = new ToolStripButton();
		toolStripButton_9 = new ToolStripButton();
		toolStripButton_10 = new ToolStripButton();
		toolStripButton_11 = new ToolStripButton();
		toolStripSeparator_9 = new ToolStripSeparator();
		toolStripButton_12 = new ToolStripButton();
		splitContainer_0 = new SplitContainer();
		checkedListBox_0 = new CheckedListBox();
		panel_0 = new Panel();
		textBox_0 = new TextBox();
		label_0 = new Label();
		richTextBox_0 = new RichTextBox();
		statusStrip_0 = new StatusStrip();
		toolStripStatusLabel_0 = new ToolStripStatusLabel();
		toolStripStatusLabel_1 = new ToolStripStatusLabel();
		toolStripStatusLabel_2 = new ToolStripStatusLabel();
		toolStripStatusLabel_3 = new ToolStripStatusLabel();
		menuStrip_0.SuspendLayout();
		toolStrip_0.SuspendLayout();
		((ISupportInitialize)splitContainer_0).BeginInit();
		splitContainer_0.Panel1.SuspendLayout();
		splitContainer_0.Panel2.SuspendLayout();
		splitContainer_0.SuspendLayout();
		panel_0.SuspendLayout();
		statusStrip_0.SuspendLayout();
		SuspendLayout();
		menuStrip_0.GripMargin = new Padding(2, 2, 0, 2);
		menuStrip_0.ImageScalingSize = new Size(32, 32);
		menuStrip_0.Items.AddRange(new ToolStripItem[3] { toolStripMenuItem_0, toolStripMenuItem_6, toolStripMenuItem_13 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1648888303);
		menuStrip_0.Padding = new Padding(7, 3, 0, 3);
		menuStrip_0.Size = new Size(2057, 42);
		menuStrip_0.TabIndex = 2;
		toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[7] { toolStripMenuItem_1, toolStripMenuItem_2, toolStripSeparator_0, toolStripMenuItem_3, toolStripMenuItem_4, toolStripSeparator_1, toolStripMenuItem_5 });
		toolStripMenuItem_0.Name = Class16.smethod_0(1648920842);
		toolStripMenuItem_0.Size = new Size(71, 36);
		toolStripMenuItem_0.Text = Class16.smethod_0(1649000202);
		toolStripMenuItem_1.Name = Class16.smethod_0(1649000222);
		toolStripMenuItem_1.ShortcutKeys = Keys.O | Keys.Control;
		toolStripMenuItem_1.Size = new Size(420, 44);
		toolStripMenuItem_1.Text = Class16.smethod_0(1649000246);
		toolStripMenuItem_1.Click += toolStripButton_0_Click;
		toolStripMenuItem_2.Name = Class16.smethod_0(1649000268);
		toolStripMenuItem_2.ShortcutKeys = Keys.O | Keys.Shift | Keys.Control;
		toolStripMenuItem_2.Size = new Size(420, 44);
		toolStripMenuItem_2.Text = Class16.smethod_0(1649000281);
		toolStripMenuItem_2.Click += toolStripButton_1_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1649000308);
		toolStripSeparator_0.Size = new Size(417, 6);
		toolStripMenuItem_3.Name = Class16.smethod_0(1649000326);
		toolStripMenuItem_3.ShortcutKeys = Keys.S | Keys.Control;
		toolStripMenuItem_3.Size = new Size(420, 44);
		toolStripMenuItem_3.Text = Class16.smethod_0(1649000336);
		toolStripMenuItem_3.Click += toolStripButton_2_Click;
		toolStripMenuItem_4.Name = Class16.smethod_0(1649000356);
		toolStripMenuItem_4.ShortcutKeys = Keys.S | Keys.Shift | Keys.Control;
		toolStripMenuItem_4.Size = new Size(420, 44);
		toolStripMenuItem_4.Text = Class16.smethod_0(1649000369);
		toolStripMenuItem_4.Click += toolStripButton_3_Click;
		toolStripSeparator_1.Name = Class16.smethod_0(1649000385);
		toolStripSeparator_1.Size = new Size(417, 6);
		toolStripMenuItem_5.Name = Class16.smethod_0(1649000403);
		toolStripMenuItem_5.Size = new Size(420, 44);
		toolStripMenuItem_5.Text = Class16.smethod_0(1649000430);
		toolStripMenuItem_5.Click += toolStripMenuItem_5_Click;
		toolStripMenuItem_6.DropDownItems.AddRange(new ToolStripItem[8] { toolStripMenuItem_7, toolStripMenuItem_8, toolStripSeparator_2, toolStripMenuItem_9, toolStripMenuItem_10, toolStripMenuItem_11, toolStripSeparator_3, toolStripMenuItem_12 });
		toolStripMenuItem_6.Name = Class16.smethod_0(1649000435);
		toolStripMenuItem_6.Size = new Size(74, 36);
		toolStripMenuItem_6.Text = Class16.smethod_0(1648999425);
		toolStripMenuItem_7.Name = Class16.smethod_0(1648999445);
		toolStripMenuItem_7.ShortcutKeys = Keys.Z | Keys.Control;
		toolStripMenuItem_7.Size = new Size(467, 44);
		toolStripMenuItem_7.Text = Class16.smethod_0(1648999463);
		toolStripMenuItem_7.Click += toolStripButton_4_Click;
		toolStripMenuItem_8.Name = Class16.smethod_0(1648999467);
		toolStripMenuItem_8.ShortcutKeys = Keys.Y | Keys.Control;
		toolStripMenuItem_8.Size = new Size(467, 44);
		toolStripMenuItem_8.Text = Class16.smethod_0(1648999493);
		toolStripMenuItem_8.Click += toolStripButton_5_Click;
		toolStripSeparator_2.Name = Class16.smethod_0(1648999497);
		toolStripSeparator_2.Size = new Size(464, 6);
		toolStripMenuItem_9.Name = Class16.smethod_0(1648999515);
		toolStripMenuItem_9.ShortcutKeys = Keys.F | Keys.Control;
		toolStripMenuItem_9.Size = new Size(467, 44);
		toolStripMenuItem_9.Text = Class16.smethod_0(1648999541);
		toolStripMenuItem_9.Click += toolStripButton_6_Click;
		toolStripMenuItem_10.Name = Class16.smethod_0(1648999556);
		toolStripMenuItem_10.ShortcutKeys = Keys.F | Keys.Shift | Keys.Control;
		toolStripMenuItem_10.Size = new Size(467, 44);
		toolStripMenuItem_10.Text = Class16.smethod_0(1648999569);
		toolStripMenuItem_10.Click += toolStripMenuItem_10_Click;
		toolStripMenuItem_11.Name = Class16.smethod_0(1648999605);
		toolStripMenuItem_11.ShortcutKeys = Keys.H | Keys.Control;
		toolStripMenuItem_11.Size = new Size(467, 44);
		toolStripMenuItem_11.Text = Class16.smethod_0(1648999618);
		toolStripMenuItem_11.Click += toolStripButton_7_Click;
		toolStripSeparator_3.Name = Class16.smethod_0(1648999644);
		toolStripSeparator_3.Size = new Size(464, 6);
		toolStripMenuItem_12.Name = Class16.smethod_0(1648999662);
		toolStripMenuItem_12.Size = new Size(467, 44);
		toolStripMenuItem_12.Text = Class16.smethod_0(1648999681);
		toolStripMenuItem_12.Click += toolStripButton_12_Click;
		toolStripMenuItem_13.DropDownItems.AddRange(new ToolStripItem[4] { toolStripMenuItem_14, toolStripMenuItem_15, toolStripMenuItem_16, toolStripMenuItem_17 });
		toolStripMenuItem_13.Name = Class16.smethod_0(1648999706);
		toolStripMenuItem_13.Size = new Size(132, 36);
		toolStripMenuItem_13.Text = Class16.smethod_0(1648999733);
		toolStripMenuItem_14.Name = Class16.smethod_0(1648999750);
		toolStripMenuItem_14.Size = new Size(327, 44);
		toolStripMenuItem_14.Text = Class16.smethod_0(1648999767);
		toolStripMenuItem_14.Click += toolStripButton_8_Click;
		toolStripMenuItem_15.Name = Class16.smethod_0(1648999779);
		toolStripMenuItem_15.Size = new Size(327, 44);
		toolStripMenuItem_15.Text = Class16.smethod_0(1648999806);
		toolStripMenuItem_15.Click += toolStripButton_9_Click;
		toolStripMenuItem_16.Name = Class16.smethod_0(1648999828);
		toolStripMenuItem_16.ShortcutKeys = Keys.A | Keys.Control;
		toolStripMenuItem_16.Size = new Size(327, 44);
		toolStripMenuItem_16.Text = Class16.smethod_0(1648999844);
		toolStripMenuItem_16.Click += toolStripButton_10_Click;
		toolStripMenuItem_17.Name = Class16.smethod_0(1648999862);
		toolStripMenuItem_17.Size = new Size(327, 44);
		toolStripMenuItem_17.Text = Class16.smethod_0(1648999879);
		toolStripMenuItem_17.Click += toolStripButton_11_Click;
		toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		toolStrip_0.ImageScalingSize = new Size(32, 32);
		toolStrip_0.Items.AddRange(new ToolStripItem[21]
		{
			toolStripButton_0, toolStripButton_1, toolStripSeparator_4, toolStripButton_2, toolStripButton_3, toolStripSeparator_5, toolStripButton_4, toolStripButton_5, toolStripSeparator_6, toolStripButton_6,
			toolStripButton_7, toolStripSeparator_7, toolStripLabel_0, toolStripComboBox_0, toolStripSeparator_8, toolStripButton_8, toolStripButton_9, toolStripButton_10, toolStripButton_11, toolStripSeparator_9,
			toolStripButton_12
		});
		toolStrip_0.Location = new Point(0, 42);
		toolStrip_0.Name = Class16.smethod_0(1648999891);
		toolStrip_0.Padding = new Padding(7, 0, 7, 0);
		toolStrip_0.Size = new Size(2057, 42);
		toolStrip_0.TabIndex = 1;
		toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_0.Name = Class16.smethod_0(1648999907);
		toolStripButton_0.Size = new Size(151, 36);
		toolStripButton_0.Text = Class16.smethod_0(1648999935);
		toolStripButton_0.ToolTipText = Class16.smethod_0(1648998921);
		toolStripButton_0.Click += toolStripButton_0_Click;
		toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_1.Name = Class16.smethod_0(1648998963);
		toolStripButton_1.Size = new Size(126, 36);
		toolStripButton_1.Text = Class16.smethod_0(1648998988);
		toolStripButton_1.ToolTipText = Class16.smethod_0(1648998995);
		toolStripButton_1.Click += toolStripButton_1_Click;
		toolStripSeparator_4.Name = Class16.smethod_0(1648999048);
		toolStripSeparator_4.Size = new Size(6, 42);
		toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_2.Name = Class16.smethod_0(1648999069);
		toolStripButton_2.Size = new Size(68, 36);
		toolStripButton_2.Text = Class16.smethod_0(1648941761);
		toolStripButton_2.ToolTipText = Class16.smethod_0(1648999075);
		toolStripButton_2.Click += toolStripButton_2_Click;
		toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_3.Name = Class16.smethod_0(1648999116);
		toolStripButton_3.Size = new Size(102, 36);
		toolStripButton_3.Text = Class16.smethod_0(1648999133);
		toolStripButton_3.ToolTipText = Class16.smethod_0(1648999148);
		toolStripButton_3.Click += toolStripButton_3_Click;
		toolStripSeparator_5.Name = Class16.smethod_0(1648999185);
		toolStripSeparator_5.Size = new Size(6, 42);
		toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_4.Image = Resources.GShopEditor_PW_mbUndo;
		toolStripButton_4.ImageTransparentColor = Color.Magenta;
		toolStripButton_4.Name = Class16.smethod_0(1648999206);
		toolStripButton_4.Size = new Size(23, 36);
		toolStripButton_4.Text = Class16.smethod_0(1648903487);
		toolStripButton_4.ToolTipText = Class16.smethod_0(1648933841);
		toolStripButton_4.Click += toolStripButton_4_Click;
		toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_5.Image = Resources.GShopEditor_PW_mbRedo;
		toolStripButton_5.ImageTransparentColor = Color.Magenta;
		toolStripButton_5.Name = Class16.smethod_0(1648999220);
		toolStripButton_5.Size = new Size(23, 36);
		toolStripButton_5.Text = Class16.smethod_0(1648903490);
		toolStripButton_5.ToolTipText = Class16.smethod_0(1648933869);
		toolStripButton_5.Click += toolStripButton_5_Click;
		toolStripSeparator_6.Name = Class16.smethod_0(1648999226);
		toolStripSeparator_6.Size = new Size(6, 42);
		toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_6.Name = Class16.smethod_0(1648999247);
		toolStripButton_6.Size = new Size(64, 36);
		toolStripButton_6.Text = Class16.smethod_0(1648999261);
		toolStripButton_6.ToolTipText = Class16.smethod_0(1648999264);
		toolStripButton_6.Click += toolStripButton_6_Click;
		toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_7.Name = Class16.smethod_0(1648999308);
		toolStripButton_7.Size = new Size(100, 36);
		toolStripButton_7.Text = Class16.smethod_0(1648999325);
		toolStripButton_7.ToolTipText = Class16.smethod_0(1648999331);
		toolStripButton_7.Click += toolStripButton_7_Click;
		toolStripSeparator_7.Name = Class16.smethod_0(1648999363);
		toolStripSeparator_7.Size = new Size(6, 42);
		toolStripLabel_0.Name = Class16.smethod_0(1648999376);
		toolStripLabel_0.Size = new Size(97, 36);
		toolStripLabel_0.Text = Class16.smethod_0(1648931051);
		toolStripComboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		toolStripComboBox_0.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1648999393),
			Class16.smethod_0(1648999420),
			Class16.smethod_0(1648998409)
		});
		toolStripComboBox_0.Name = Class16.smethod_0(1648998437);
		toolStripComboBox_0.Size = new Size(220, 42);
		toolStripComboBox_0.SelectedIndexChanged += toolStripComboBox_0_SelectedIndexChanged;
		toolStripSeparator_8.Name = Class16.smethod_0(1648998455);
		toolStripSeparator_8.Size = new Size(6, 42);
		toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_8.Name = Class16.smethod_0(1648998468);
		toolStripButton_8.Size = new Size(121, 36);
		toolStripButton_8.Text = Class16.smethod_0(1648998485);
		toolStripButton_8.ToolTipText = Class16.smethod_0(1648998498);
		toolStripButton_8.Click += toolStripButton_8_Click;
		toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_9.Name = Class16.smethod_0(1648998533);
		toolStripButton_9.Size = new Size(145, 36);
		toolStripButton_9.Text = Class16.smethod_0(1648998544);
		toolStripButton_9.ToolTipText = Class16.smethod_0(1648998569);
		toolStripButton_9.Click += toolStripButton_9_Click;
		toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_10.Name = Class16.smethod_0(1648998606);
		toolStripButton_10.Size = new Size(85, 36);
		toolStripButton_10.Text = Class16.smethod_0(1648998622);
		toolStripButton_10.ToolTipText = Class16.smethod_0(1648998639);
		toolStripButton_10.Click += toolStripButton_10_Click;
		toolStripButton_11.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_11.Name = Class16.smethod_0(1648998670);
		toolStripButton_11.Size = new Size(105, 36);
		toolStripButton_11.Text = Class16.smethod_0(1648998687);
		toolStripButton_11.ToolTipText = Class16.smethod_0(1648998698);
		toolStripButton_11.Click += toolStripButton_11_Click;
		toolStripSeparator_9.Name = Class16.smethod_0(1648998722);
		toolStripSeparator_9.Size = new Size(6, 42);
		toolStripButton_12.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_12.Name = Class16.smethod_0(1648998743);
		toolStripButton_12.Size = new Size(170, 36);
		toolStripButton_12.Text = Class16.smethod_0(1648998766);
		toolStripButton_12.ToolTipText = Class16.smethod_0(1648998779);
		toolStripButton_12.Click += toolStripButton_12_Click;
		splitContainer_0.Dock = DockStyle.Fill;
		splitContainer_0.FixedPanel = FixedPanel.Panel1;
		splitContainer_0.Location = new Point(0, 84);
		splitContainer_0.Margin = new Padding(5, 5, 5, 5);
		splitContainer_0.Name = Class16.smethod_0(1648916231);
		splitContainer_0.Panel1.Controls.Add(checkedListBox_0);
		splitContainer_0.Panel1.Controls.Add(panel_0);
		splitContainer_0.Panel1.Padding = new Padding(10, 0, 0, 0);
		splitContainer_0.Panel1MinSize = 220;
		splitContainer_0.Panel2.Controls.Add(richTextBox_0);
		splitContainer_0.Panel2.Padding = new Padding(0, 0, 10, 0);
		splitContainer_0.Panel2MinSize = 400;
		splitContainer_0.Size = new Size(2057, 1037);
		splitContainer_0.SplitterDistance = 220;
		splitContainer_0.SplitterWidth = 10;
		splitContainer_0.TabIndex = 0;
		checkedListBox_0.BorderStyle = BorderStyle.None;
		checkedListBox_0.CheckOnClick = true;
		checkedListBox_0.Dock = DockStyle.Fill;
		checkedListBox_0.Font = new Font(Class16.smethod_0(1648942905), 9.5f);
		checkedListBox_0.IntegralHeight = false;
		checkedListBox_0.Location = new Point(10, 93);
		checkedListBox_0.Margin = new Padding(5, 5, 5, 5);
		checkedListBox_0.Name = Class16.smethod_0(1648998819);
		checkedListBox_0.Size = new Size(210, 944);
		checkedListBox_0.TabIndex = 0;
		checkedListBox_0.SelectedIndexChanged += checkedListBox_0_SelectedIndexChanged;
		panel_0.Controls.Add(textBox_0);
		panel_0.Controls.Add(label_0);
		panel_0.Dock = DockStyle.Top;
		panel_0.Location = new Point(10, 0);
		panel_0.Margin = new Padding(5, 5, 5, 5);
		panel_0.Name = Class16.smethod_0(1648998834);
		panel_0.Padding = new Padding(0, 7, 0, 7);
		panel_0.Size = new Size(210, 93);
		panel_0.TabIndex = 1;
		textBox_0.BorderStyle = BorderStyle.FixedSingle;
		textBox_0.Dock = DockStyle.Bottom;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_0.Location = new Point(0, 47);
		textBox_0.Margin = new Padding(5, 5, 5, 5);
		textBox_0.Name = Class16.smethod_0(1648998856);
		textBox_0.Size = new Size(210, 39);
		textBox_0.TabIndex = 0;
		textBox_0.TextChanged += textBox_0_TextChanged;
		label_0.AutoSize = true;
		label_0.Dock = DockStyle.Top;
		label_0.Font = new Font(Class16.smethod_0(1648934511), 9f, FontStyle.Bold);
		label_0.Location = new Point(0, 7);
		label_0.Margin = new Padding(5, 0, 5, 0);
		label_0.Name = Class16.smethod_0(1648998884);
		label_0.Padding = new Padding(3, 3, 0, 7);
		label_0.Size = new Size(120, 42);
		label_0.TabIndex = 1;
		label_0.Text = Class16.smethod_0(1648998903);
		richTextBox_0.AcceptsTab = true;
		richTextBox_0.BorderStyle = BorderStyle.None;
		richTextBox_0.DetectUrls = false;
		richTextBox_0.Dock = DockStyle.Fill;
		richTextBox_0.Font = new Font(Class16.smethod_0(1648929975), 10f);
		richTextBox_0.HideSelection = false;
		richTextBox_0.Location = new Point(0, 0);
		richTextBox_0.Margin = new Padding(5, 5, 5, 5);
		richTextBox_0.MaxLength = 50000000;
		richTextBox_0.Name = Class16.smethod_0(1648993799);
		richTextBox_0.Size = new Size(1817, 1037);
		richTextBox_0.TabIndex = 0;
		richTextBox_0.Text = string.Empty;
		richTextBox_0.WordWrap = false;
		statusStrip_0.ImageScalingSize = new Size(32, 32);
		statusStrip_0.Items.AddRange(new ToolStripItem[4] { toolStripStatusLabel_0, toolStripStatusLabel_1, toolStripStatusLabel_2, toolStripStatusLabel_3 });
		statusStrip_0.Location = new Point(0, 1121);
		statusStrip_0.Name = Class16.smethod_0(1649014497);
		statusStrip_0.Padding = new Padding(7, 0, 21, 0);
		statusStrip_0.Size = new Size(2057, 46);
		statusStrip_0.TabIndex = 3;
		toolStripStatusLabel_0.Name = Class16.smethod_0(1648993815);
		toolStripStatusLabel_0.Size = new Size(78, 36);
		toolStripStatusLabel_0.Text = Class16.smethod_0(1648920624);
		toolStripStatusLabel_1.Name = Class16.smethod_0(1648993824);
		toolStripStatusLabel_1.Size = new Size(1736, 36);
		toolStripStatusLabel_1.Spring = true;
		toolStripStatusLabel_2.BorderSides = ToolStripStatusLabelBorderSides.Left;
		toolStripStatusLabel_2.Name = Class16.smethod_0(1648993841);
		toolStripStatusLabel_2.Size = new Size(81, 36);
		toolStripStatusLabel_2.Text = Class16.smethod_0(1648993868);
		toolStripStatusLabel_3.BorderSides = ToolStripStatusLabelBorderSides.Left;
		toolStripStatusLabel_3.Name = Class16.smethod_0(1648993874);
		toolStripStatusLabel_3.Size = new Size(134, 36);
		toolStripStatusLabel_3.Text = Class16.smethod_0(1648993901);
		base.AutoScaleDimensions = new SizeF(12f, 25f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(2057, 1167);
		base.Controls.Add(splitContainer_0);
		base.Controls.Add(toolStrip_0);
		base.Controls.Add(menuStrip_0);
		base.Controls.Add(statusStrip_0);
		base.MainMenuStrip = menuStrip_0;
		base.Margin = new Padding(5, 5, 5, 5);
		MinimumSize = new Size(1524, 786);
		base.Name = Class16.smethod_0(1648993918);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648993930);
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		toolStrip_0.ResumeLayout(performLayout: false);
		toolStrip_0.PerformLayout();
		splitContainer_0.Panel1.ResumeLayout(performLayout: false);
		splitContainer_0.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_0).EndInit();
		splitContainer_0.ResumeLayout(performLayout: false);
		panel_0.ResumeLayout(performLayout: false);
		panel_0.PerformLayout();
		statusStrip_0.ResumeLayout(performLayout: false);
		statusStrip_0.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		method_6();
	}

	private void method_6()
	{
		if (ecmFile_0 != null)
		{
			ecmFile_0.CurrentContent = richTextBox_0.Text;
			if (ecmDirectoryScanner_0.SaveContent(ecmFile_0))
			{
				ecmUndoRedoManager_0.Clear(ecmFile_0.FilePath);
				MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648993947), Class16.smethod_0(1648993968)), TextStorage.Msg(Class16.smethod_0(1648994007), Class16.smethod_0(1648941761)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				method_14();
			}
			else
			{
				MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648994022), Class16.smethod_0(1648994035)), TextStorage.Msg(Class16.smethod_0(1648996769), Class16.smethod_0(1648934892)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		method_7();
	}

	private void method_7()
	{
		if (ecmFile_0 != null)
		{
			ecmFile_0.CurrentContent = richTextBox_0.Text;
		}
		int num = 0;
		int num2 = 0;
		foreach (EcmFile item in list_0.Where(Class112.class112_0.method_0))
		{
			if (ecmDirectoryScanner_0.SaveContent(item))
			{
				ecmUndoRedoManager_0.Clear(item.FilePath);
				num++;
			}
			else
			{
				num2++;
			}
		}
		if (num2 == 0)
		{
			MessageBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648994068), Class16.smethod_0(1648994082)), num), TextStorage.Msg(Class16.smethod_0(1648994120), Class16.smethod_0(1648999133)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			MessageBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648994139), Class16.smethod_0(1648994168)), num, num2), TextStorage.Msg(Class16.smethod_0(1648994120), Class16.smethod_0(1648999133)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		method_14();
	}

	private void toolStripButton_8_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < checkedListBox_0.Items.Count; i++)
		{
			if (checkedListBox_0.Items[i] is EcmFile ecmFile)
			{
				checkedListBox_0.SetItemChecked(i, ecmFile.Gender == EcmGender.Male);
			}
		}
		method_14();
	}

	private void toolStripButton_9_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < checkedListBox_0.Items.Count; i++)
		{
			if (checkedListBox_0.Items[i] is EcmFile ecmFile)
			{
				checkedListBox_0.SetItemChecked(i, ecmFile.Gender == EcmGender.Female);
			}
		}
		method_14();
	}

	private void toolStripButton_10_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < checkedListBox_0.Items.Count; i++)
		{
			checkedListBox_0.SetItemChecked(i, value: true);
		}
		method_14();
	}

	private void toolStripButton_11_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < checkedListBox_0.Items.Count; i++)
		{
			checkedListBox_0.SetItemChecked(i, value: false);
		}
		method_14();
	}

	private List<EcmFile> method_8()
	{
		return checkedListBox_0.CheckedItems.Cast<EcmFile>().ToList();
	}

	private void method_9()
	{
		if (ecmFile_0 != null)
		{
			string text = ecmUndoRedoManager_0.Undo(ecmFile_0.FilePath, richTextBox_0.Text);
			if (text != null)
			{
				bool_0 = true;
				richTextBox_0.Text = text;
				ecmFile_0.CurrentContent = text;
				bool_0 = false;
			}
		}
	}

	private void method_10()
	{
		if (ecmFile_0 != null)
		{
			string text = ecmUndoRedoManager_0.Redo(ecmFile_0.FilePath, richTextBox_0.Text);
			if (text != null)
			{
				bool_0 = true;
				richTextBox_0.Text = text;
				ecmFile_0.CurrentContent = text;
				bool_0 = false;
			}
		}
	}

	private void toolStripButton_12_Click(object sender, EventArgs e)
	{
		List<EcmFile> list = method_8();
		if (list.Count == 0)
		{
			MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648994205), Class16.smethod_0(1648994226)), TextStorage.Msg(Class16.smethod_0(1648994279), Class16.smethod_0(1648998766)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		using EcmInsertContentDialog ecmInsertContentDialog = new EcmInsertContentDialog();
		if (ecmInsertContentDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		int num = 0;
		foreach (EcmFile item in list)
		{
			if (item.ScriptData == null)
			{
				ecmDirectoryScanner_0.LoadContent(item);
			}
			ecmUndoRedoManager_0.PushState(item.FilePath, item.CurrentContent);
			item.CurrentContent = smethod_0(item.CurrentContent, ecmInsertContentDialog.ContentToInsert);
			num++;
		}
		if (ecmFile_0 != null && list.Contains(ecmFile_0))
		{
			bool_0 = true;
			richTextBox_0.Text = ecmFile_0.CurrentContent;
			bool_0 = false;
		}
		MessageBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648994296), Class16.smethod_0(1648993297)), num), TextStorage.Msg(Class16.smethod_0(1648994279), Class16.smethod_0(1648998766)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		method_14();
	}

	private static string smethod_0(string string_1, string string_2)
	{
		int num = string_1.IndexOf(Class16.smethod_0(1648993338), StringComparison.Ordinal);
		if (num > 0)
		{
			int num2 = string_1.LastIndexOf('\n', num - 1);
			num2 = ((num2 >= 0) ? (num2 + 1) : 0);
			return string_1.Substring(0, num2) + string_2 + Class16.smethod_0(1648941987) + string_1.Substring(num2);
		}
		return string_1 + Class16.smethod_0(1648941987) + string_2;
	}

	private void toolStripButton_6_Click(object sender, EventArgs e)
	{
		method_11(bool_1: false);
	}

	private void method_11(bool bool_1)
	{
		EcmSearchDialog ecmSearchDialog = new EcmSearchDialog(ecmFile_0, list_0, ecmDirectoryScanner_0, bool_1);
		try
		{
			ecmSearchDialog.ShowDialog();
			if (ecmSearchDialog.SelectedFile == null)
			{
				return;
			}
			int num = checkedListBox_0.Items.IndexOf(ecmSearchDialog.SelectedFile);
			if (num >= 0)
			{
				checkedListBox_0.SelectedIndex = num;
				if (!string.IsNullOrEmpty(ecmSearchDialog.SelectedSearchText))
				{
					method_12(ecmSearchDialog.SelectedSearchText);
				}
			}
		}
		finally
		{
			((IDisposable)ecmSearchDialog).Dispose();
		}
	}

	private void method_12(string string_1)
	{
		if (!string.IsNullOrEmpty(richTextBox_0.Text))
		{
			int num = richTextBox_0.Text.IndexOf(string_1, StringComparison.OrdinalIgnoreCase);
			if (num >= 0)
			{
				richTextBox_0.Focus();
				richTextBox_0.Select(num, string_1.Length);
				richTextBox_0.ScrollToCaret();
			}
		}
	}

	private void toolStripButton_7_Click(object sender, EventArgs e)
	{
		method_13();
	}

	private void method_13()
	{
		EcmReplaceDialog ecmReplaceDialog = new EcmReplaceDialog(ecmFile_0, list_0, ecmDirectoryScanner_0, ecmUndoRedoManager_0);
		try
		{
			if (ecmReplaceDialog.ShowDialog() == DialogResult.OK)
			{
				if (ecmFile_0 != null)
				{
					bool_0 = true;
					richTextBox_0.Text = ecmFile_0.CurrentContent;
					bool_0 = false;
				}
				method_14();
			}
		}
		finally
		{
			((IDisposable)ecmReplaceDialog).Dispose();
		}
	}

	private void EcmEditorForm_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && !e.Shift && e.KeyCode == Keys.S)
		{
			e.Handled = true;
			method_6();
		}
		else if (e.Control && e.Shift && e.KeyCode == Keys.S)
		{
			e.Handled = true;
			method_7();
		}
		else if (e.Control && !e.Shift && e.KeyCode == Keys.Z)
		{
			e.Handled = true;
			method_9();
		}
		else if (e.Control && e.KeyCode == Keys.Y)
		{
			e.Handled = true;
			method_10();
		}
		else if (e.Control && !e.Shift && e.KeyCode == Keys.F)
		{
			e.Handled = true;
			method_11(bool_1: false);
		}
		else if (e.Control && e.Shift && e.KeyCode == Keys.F)
		{
			e.Handled = true;
			method_11(bool_1: true);
		}
		else if (e.Control && e.KeyCode == Keys.H)
		{
			e.Handled = true;
			method_13();
		}
	}

	private void method_14()
	{
		int count = list_0.Count;
		int count2 = checkedListBox_0.CheckedItems.Count;
		int num = list_0.Count(Class112.class112_0.method_1);
		string text = Class16.smethod_0(1648920624);
		if (ecmFile_0 != null)
		{
			text = ecmFile_0.DisplayName;
			if (ecmFile_0.IsModified)
			{
				text += Class16.smethod_0(1648993379);
			}
		}
		toolStripStatusLabel_0.Text = text;
		string text2 = string.Format(TextStorage.Msg(Class16.smethod_0(1648993396), Class16.smethod_0(1648993420)), count);
		if (count2 > 0)
		{
			text2 = text2 + Class16.smethod_0(1648993435) + string.Format(TextStorage.Msg(Class16.smethod_0(1648993453), Class16.smethod_0(1648993479)), count2);
		}
		toolStripStatusLabel_2.Text = text2;
		toolStripStatusLabel_3.Text = ((num > 0) ? string.Format(TextStorage.Msg(Class16.smethod_0(1648993490), Class16.smethod_0(1648993524)), num) : string.Empty);
	}

	private void toolStripComboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(string_0))
		{
			method_2();
			method_14();
		}
	}
}
