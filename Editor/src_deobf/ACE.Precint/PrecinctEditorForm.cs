using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Precint;

public class PrecinctEditorForm : Form
{
	[Serializable]
	private sealed class Class351
	{
		public static readonly Class351 class351_0 = new Class351();

		public static Func<PrecinctEntry, int> func_0;

		internal int method_0(PrecinctEntry precinctEntry_0)
		{
			return precinctEntry_0.ID;
		}
	}

	private PrecinctFile precinctFile_0;

	private string string_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private StatusStrip statusStrip_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private ToolStripStatusLabel toolStripStatusLabel_1;

	private SplitContainer splitContainer_0;

	private DataGridView dataGridView_0;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TabPage tabPage_1;

	private TabPage tabPage_2;

	private TabPage tabPage_3;

	private TabPage tabPage_4;

	private DataGridView dataGridView_1;

	private DataGridView dataGridView_2;

	private DataGridView dataGridView_3;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private TextBox textBox_4;

	private Button button_0;

	private ContextMenuStrip contextMenuStrip_0;

	private ContextMenuStrip contextMenuStrip_1;

	private ContextMenuStrip contextMenuStrip_2;

	private ContextMenuStrip contextMenuStrip_3;

	private FileBasedUndoManager fileBasedUndoManager_0;

	public bool HasFileLoaded
	{
		get
		{
			if (precinctFile_0 != null)
			{
				return precinctFile_0.zones.Count > 0;
			}
			return false;
		}
	}

	public PrecinctEditorForm()
	{
		method_2();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		base.Activated += PrecinctEditorForm_Activated;
		method_1(dataGridView_0);
		method_1(dataGridView_1);
		method_1(dataGridView_2);
		method_1(dataGridView_3);
		method_15();
	}

	private void method_0()
	{
		base.Icon = Resources.PrecinctEditor;
	}

	private void method_1(DataGridView dataGridView_4)
	{
		dataGridView_4.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
		dataGridView_4.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
		dataGridView_4.DefaultCellStyle.SelectionForeColor = Color.White;
		dataGridView_4.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
		dataGridView_4.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
		dataGridView_4.ColumnHeadersDefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		dataGridView_4.ColumnHeadersDefaultCellStyle.Padding = new Padding(4);
		dataGridView_4.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 9f);
		dataGridView_4.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
		dataGridView_4.RowTemplate.Height = 28;
	}

	public void LoadPrecinctFile(string path)
	{
		if (!string.IsNullOrWhiteSpace(path))
		{
			string_0 = path;
			method_4();
		}
	}

	private void method_2()
	{
		Text = Class16.smethod_0(1649189075);
		base.Size = new Size(1200, 800);
		MinimumSize = new Size(800, 600);
		base.StartPosition = FormStartPosition.CenterScreen;
		BackColor = SystemColors.Control;
		Font = new Font(Class16.smethod_0(1648942905), 9f);
		method_0();
		toolStrip_0 = new ToolStrip
		{
			GripStyle = ToolStripGripStyle.Hidden,
			ImageScalingSize = new Size(20, 20),
			Dock = DockStyle.Top,
			BackColor = SystemColors.Control,
			Padding = new Padding(8, 4, 4, 4),
			RenderMode = ToolStripRenderMode.System
		};
		toolStripButton_0 = new ToolStripButton(TextStorage.Msg(Class16.smethod_0(1649189112), Class16.smethod_0(1649189130)))
		{
			Name = Class16.smethod_0(1649195764),
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			Padding = new Padding(8, 4, 8, 4),
			ToolTipText = Class16.smethod_0(1649189159)
		};
		toolStripButton_0.Click += toolStripButton_0_Click;
		toolStripButton_1 = new ToolStripButton(TextStorage.Msg(Class16.smethod_0(1649189188), Class16.smethod_0(1649189206)))
		{
			Name = Class16.smethod_0(1649195699),
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			Padding = new Padding(8, 4, 8, 4),
			ToolTipText = Class16.smethod_0(1649189219)
		};
		toolStripButton_1.Click += toolStripButton_1_Click;
		toolStripButton_2 = new ToolStripButton(TextStorage.Msg(Class16.smethod_0(1649189254), Class16.smethod_0(1649189278)))
		{
			Name = Class16.smethod_0(1649189309),
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			Padding = new Padding(8, 4, 8, 4),
			ToolTipText = Class16.smethod_0(1649189326)
		};
		toolStripButton_2.Click += toolStripButton_2_Click;
		toolStripButton_3 = new ToolStripButton(TextStorage.Msg(Class16.smethod_0(1649189353), Class16.smethod_0(1649192452)))
		{
			Name = Class16.smethod_0(1649192467),
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			Padding = new Padding(8, 4, 8, 4),
			ToolTipText = Class16.smethod_0(1649192482)
		};
		toolStripButton_3.Click += toolStripButton_3_Click;
		toolStrip_0.Items.AddRange(new ToolStripItem[6]
		{
			toolStripButton_0,
			toolStripButton_1,
			new ToolStripSeparator(),
			toolStripButton_2,
			new ToolStripSeparator(),
			toolStripButton_3
		});
		statusStrip_0 = new StatusStrip
		{
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			BackColor = SystemColors.Control
		};
		toolStripStatusLabel_0 = new ToolStripStatusLabel(TextStorage.Msg(Class16.smethod_0(1649192527), Class16.smethod_0(1648920624)))
		{
			Name = Class16.smethod_0(1649192538),
			Spring = true,
			TextAlign = ContentAlignment.MiddleLeft
		};
		toolStripStatusLabel_1 = new ToolStripStatusLabel(TextStorage.Msg(Class16.smethod_0(1649192564), Class16.smethod_0(1649192587)))
		{
			Name = Class16.smethod_0(1649192614),
			BorderSides = ToolStripStatusLabelBorderSides.Left,
			Padding = new Padding(8, 0, 8, 0)
		};
		statusStrip_0.Items.AddRange(new ToolStripItem[2] { toolStripStatusLabel_0, toolStripStatusLabel_1 });
		splitContainer_0 = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterDistance = 350,
			BorderStyle = BorderStyle.FixedSingle,
			BackColor = SystemColors.ControlDark
		};
		dataGridView_0 = new DataGridView
		{
			AllowUserToAddRows = false,
			AllowUserToDeleteRows = false,
			AllowUserToResizeColumns = true,
			AllowUserToResizeRows = false,
			AutoGenerateColumns = false,
			BackgroundColor = SystemColors.Window,
			BorderStyle = BorderStyle.None,
			CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
			ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
			Dock = DockStyle.Fill,
			EditMode = DataGridViewEditMode.EditOnF2,
			EnableHeadersVisualStyles = true,
			MultiSelect = false,
			ReadOnly = false,
			RowHeadersVisible = false,
			SelectionMode = DataGridViewSelectionMode.FullRowSelect,
			VirtualMode = true
		};
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648941057),
			Name = Class16.smethod_0(1649192632),
			Width = 60
		});
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648936731),
			Name = Class16.smethod_0(1649192652),
			AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
			MinimumWidth = 150
		});
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649211101),
			Name = Class16.smethod_0(1649192658),
			Width = 80
		});
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649192684),
			Name = Class16.smethod_0(1649192690),
			Width = 80
		});
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649192706),
			Name = Class16.smethod_0(1649192727),
			Width = 80
		});
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649009756),
			Name = Class16.smethod_0(1649192742),
			Width = 80
		});
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649192758),
			Name = Class16.smethod_0(1649192772),
			Width = 70
		});
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649211187),
			Name = Class16.smethod_0(1649192791),
			Width = 70
		});
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649192806),
			Name = Class16.smethod_0(1649192822),
			Width = 80
		});
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649192832),
			Name = Class16.smethod_0(1649192849),
			Width = 90
		});
		dataGridView_0.CellValueNeeded += dataGridView_0_CellValueNeeded;
		dataGridView_0.CellValuePushed += dataGridView_0_CellValuePushed;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		contextMenuStrip_0 = new ContextMenuStrip
		{
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649192876)));
		toolStripMenuItem.Click += method_6;
		ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649192896)));
		toolStripMenuItem2.Click += method_7;
		ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649192934)));
		toolStripMenuItem3.Click += method_8;
		contextMenuStrip_0.Items.AddRange(new ToolStripItem[4]
		{
			toolStripMenuItem,
			new ToolStripSeparator(),
			toolStripMenuItem2,
			toolStripMenuItem3
		});
		dataGridView_0.ContextMenuStrip = contextMenuStrip_0;
		tabControl_0 = new TabControl
		{
			Dock = DockStyle.Fill,
			Font = new Font(Class16.smethod_0(1648942905), 9.5f),
			Padding = new Point(12, 8)
		};
		tabPage_0 = new TabPage(Class16.smethod_0(1649191941))
		{
			Name = Class16.smethod_0(1649191970),
			BackColor = Color.White,
			Padding = new Padding(0),
			UseVisualStyleBackColor = true
		};
		dataGridView_1 = new DataGridView
		{
			AllowUserToAddRows = false,
			AllowUserToDeleteRows = false,
			AllowUserToResizeColumns = true,
			AllowUserToResizeRows = false,
			AutoGenerateColumns = false,
			BackgroundColor = SystemColors.Window,
			BorderStyle = BorderStyle.None,
			CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
			ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
			Dock = DockStyle.Fill,
			EditMode = DataGridViewEditMode.EditOnF2,
			EnableHeadersVisualStyles = true,
			MultiSelect = false,
			ReadOnly = false,
			RowHeadersVisible = false,
			SelectionMode = DataGridViewSelectionMode.FullRowSelect,
			VirtualMode = true
		};
		dataGridView_1.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648916453),
			Name = Class16.smethod_0(1649191985),
			AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_1.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648916476),
			Name = Class16.smethod_0(1649192023),
			AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_1.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648915467),
			Name = Class16.smethod_0(1649192038),
			AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_1.CellValueNeeded += dataGridView_1_CellValueNeeded;
		dataGridView_1.CellValuePushed += dataGridView_1_CellValuePushed;
		contextMenuStrip_1 = new ContextMenuStrip
		{
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649192053)));
		toolStripMenuItem4.Click += method_9;
		ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649192078)));
		toolStripMenuItem5.Click += method_10;
		contextMenuStrip_1.Items.AddRange(new ToolStripItem[3]
		{
			toolStripMenuItem4,
			new ToolStripSeparator(),
			toolStripMenuItem5
		});
		dataGridView_1.ContextMenuStrip = contextMenuStrip_1;
		tabPage_0.Controls.Add(dataGridView_1);
		tabPage_1 = new TabPage(Class16.smethod_0(1649192098))
		{
			Name = Class16.smethod_0(1649192127),
			BackColor = Color.White,
			Padding = new Padding(0),
			UseVisualStyleBackColor = true
		};
		dataGridView_2 = new DataGridView
		{
			AllowUserToAddRows = false,
			AllowUserToDeleteRows = false,
			AllowUserToResizeColumns = true,
			AllowUserToResizeRows = false,
			AutoGenerateColumns = false,
			BackgroundColor = SystemColors.Window,
			BorderStyle = BorderStyle.None,
			CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
			ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
			Dock = DockStyle.Fill,
			EditMode = DataGridViewEditMode.EditOnF2,
			EnableHeadersVisualStyles = true,
			MultiSelect = false,
			ReadOnly = false,
			RowHeadersVisible = false,
			SelectionMode = DataGridViewSelectionMode.FullRowSelect,
			VirtualMode = true
		};
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648936731),
			Name = Class16.smethod_0(1649192141),
			Width = 200
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648916453),
			Name = Class16.smethod_0(1649192158),
			Width = 150,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648916476),
			Name = Class16.smethod_0(1649192172),
			Width = 150,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648915467),
			Name = Class16.smethod_0(1649192178),
			Width = 150,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_2.CellValueNeeded += dataGridView_2_CellValueNeeded;
		dataGridView_2.CellValuePushed += dataGridView_2_CellValuePushed;
		contextMenuStrip_2 = new ContextMenuStrip
		{
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649192192)));
		toolStripMenuItem6.Click += method_11;
		ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649192223)));
		toolStripMenuItem7.Click += method_12;
		contextMenuStrip_2.Items.AddRange(new ToolStripItem[3]
		{
			toolStripMenuItem6,
			new ToolStripSeparator(),
			toolStripMenuItem7
		});
		dataGridView_2.ContextMenuStrip = contextMenuStrip_2;
		tabPage_1.Controls.Add(dataGridView_2);
		tabPage_2 = new TabPage(Class16.smethod_0(1649192241))
		{
			Name = Class16.smethod_0(1649192264),
			BackColor = Color.White,
			Padding = new Padding(0),
			UseVisualStyleBackColor = true
		};
		dataGridView_3 = new DataGridView
		{
			AllowUserToAddRows = false,
			AllowUserToDeleteRows = false,
			AllowUserToResizeColumns = true,
			AllowUserToResizeRows = false,
			AutoGenerateColumns = false,
			BackgroundColor = SystemColors.Window,
			BorderStyle = BorderStyle.None,
			CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
			ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
			Dock = DockStyle.Fill,
			EditMode = DataGridViewEditMode.EditOnF2,
			EnableHeadersVisualStyles = true,
			MultiSelect = false,
			ReadOnly = false,
			RowHeadersVisible = false,
			SelectionMode = DataGridViewSelectionMode.FullRowSelect,
			VirtualMode = true
		};
		dataGridView_3.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649192287),
			Name = Class16.smethod_0(1649192296),
			AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
			MinimumWidth = 300
		});
		dataGridView_3.CellValueNeeded += dataGridView_3_CellValueNeeded;
		dataGridView_3.CellValuePushed += dataGridView_3_CellValuePushed;
		contextMenuStrip_3 = new ContextMenuStrip
		{
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		ToolStripMenuItem toolStripMenuItem8 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649192315)));
		toolStripMenuItem8.Click += method_13;
		ToolStripMenuItem toolStripMenuItem9 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649192348)));
		toolStripMenuItem9.Click += method_14;
		contextMenuStrip_3.Items.AddRange(new ToolStripItem[3]
		{
			toolStripMenuItem8,
			new ToolStripSeparator(),
			toolStripMenuItem9
		});
		dataGridView_3.ContextMenuStrip = contextMenuStrip_3;
		tabPage_2.Controls.Add(dataGridView_3);
		tabPage_3 = new TabPage(Class16.smethod_0(1649192368))
		{
			Name = Class16.smethod_0(1649192409),
			BackColor = Color.White,
			Padding = new Padding(12),
			UseVisualStyleBackColor = true
		};
		GroupBox groupBox = new GroupBox
		{
			Name = Class16.smethod_0(1649192426),
			Text = Class16.smethod_0(1649191429),
			Location = new Point(12, 12),
			Size = new Size(400, 150),
			Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold)
		};
		Label label = new Label
		{
			Name = Class16.smethod_0(1649191462),
			Text = Class16.smethod_0(1649013968),
			Location = new Point(20, 35),
			Width = 30,
			TextAlign = ContentAlignment.MiddleRight,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_0 = new TextBox
		{
			Location = new Point(60, 33),
			Width = 180,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_0.TextChanged += textBox_2_TextChanged;
		Label label2 = new Label
		{
			Name = Class16.smethod_0(1649191477),
			Text = Class16.smethod_0(1649013950),
			Location = new Point(20, 70),
			Width = 30,
			TextAlign = ContentAlignment.MiddleRight,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_1 = new TextBox
		{
			Location = new Point(60, 68),
			Width = 180,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_1.TextChanged += textBox_2_TextChanged;
		Label label3 = new Label
		{
			Name = Class16.smethod_0(1649191492),
			Text = Class16.smethod_0(1649111438),
			Location = new Point(20, 105),
			Width = 30,
			TextAlign = ContentAlignment.MiddleRight,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_2 = new TextBox
		{
			Location = new Point(60, 103),
			Width = 180,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_2.TextChanged += textBox_2_TextChanged;
		groupBox.Controls.AddRange(new Control[6] { label, textBox_0, label2, textBox_1, label3, textBox_2 });
		tabPage_3.Controls.Add(groupBox);
		tabPage_4 = new TabPage(Class16.smethod_0(1649191499))
		{
			Name = Class16.smethod_0(1649191530),
			BackColor = Color.White,
			Padding = new Padding(12),
			UseVisualStyleBackColor = true
		};
		GroupBox groupBox2 = new GroupBox
		{
			Name = Class16.smethod_0(1649191556),
			Text = Class16.smethod_0(1649191568),
			Location = new Point(12, 12),
			Size = new Size(400, 120),
			Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold)
		};
		Label label4 = new Label
		{
			Name = Class16.smethod_0(1649049106),
			Text = Class16.smethod_0(1648931051),
			Location = new Point(20, 35),
			Width = 80,
			TextAlign = ContentAlignment.MiddleRight,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_3 = new TextBox
		{
			Location = new Point(110, 33),
			Width = 150,
			TextAlign = HorizontalAlignment.Center,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_3.TextChanged += textBox_3_TextChanged;
		Label label5 = new Label
		{
			Name = Class16.smethod_0(1649191599),
			Text = Class16.smethod_0(1649191610),
			Location = new Point(20, 70),
			Width = 80,
			TextAlign = ContentAlignment.MiddleRight,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_4 = new TextBox
		{
			Location = new Point(110, 68),
			Width = 150,
			TextAlign = HorizontalAlignment.Center,
			ReadOnly = true,
			BackColor = SystemColors.Control,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		button_0 = new Button
		{
			Name = Class16.smethod_0(1649191627),
			Text = Class16.smethod_0(1649191649),
			Location = new Point(270, 67),
			Width = 120,
			Height = 28,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		button_0.Click += button_0_Click;
		groupBox2.Controls.AddRange(new Control[5] { label4, textBox_3, label5, textBox_4, button_0 });
		tabPage_4.Controls.Add(groupBox2);
		tabControl_0.TabPages.Add(tabPage_0);
		tabControl_0.TabPages.Add(tabPage_1);
		tabControl_0.TabPages.Add(tabPage_2);
		tabControl_0.TabPages.Add(tabPage_3);
		tabControl_0.TabPages.Add(tabPage_4);
		splitContainer_0.Panel1.Controls.Add(dataGridView_0);
		splitContainer_0.Panel2.Controls.Add(tabControl_0);
		base.Controls.Add(splitContainer_0);
		base.Controls.Add(toolStrip_0);
		base.Controls.Add(statusStrip_0);
	}

	private void method_3()
	{
		if (precinctFile_0 != null)
		{
			toolStripStatusLabel_1.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649191672), Class16.smethod_0(1649191697)), precinctFile_0.zones.Count);
			toolStripStatusLabel_0.Text = ((!string.IsNullOrEmpty(string_0)) ? (Class16.smethod_0(1648912665) + System.IO.Path.GetFileName(string_0)) : TextStorage.Msg(Class16.smethod_0(1649192527), Class16.smethod_0(1648920624)));
		}
		else
		{
			toolStripStatusLabel_1.Text = TextStorage.Msg(Class16.smethod_0(1649192564), Class16.smethod_0(1649192587));
			toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649191726));
		}
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		try
		{
			openFileDialog.Filter = Class16.smethod_0(1649191756);
			if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
			{
				string_0 = openFileDialog.FileName;
				precinctFile_0 = null;
				dataGridView_0.RowCount = 0;
				dataGridView_1.RowCount = 0;
				dataGridView_2.RowCount = 0;
				dataGridView_3.RowCount = 0;
				method_4();
			}
		}
		finally
		{
			((IDisposable)openFileDialog).Dispose();
		}
	}

	private void method_4()
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return;
		}
		bool_1 = true;
		bool_2 = true;
		try
		{
			precinctFile_0 = new PrecinctFile();
			if (!precinctFile_0.ReadFile(string_0))
			{
				bool_0 = false;
				dataGridView_0.RowCount = 0;
				dataGridView_1.RowCount = 0;
				dataGridView_2.RowCount = 0;
				dataGridView_3.RowCount = 0;
				method_3();
				return;
			}
			bool_0 = true;
			textBox_3.Text = precinctFile_0.dwVersion.ToString();
			textBox_4.Text = precinctFile_0.dwTimeStamp.ToString();
			dataGridView_0.RowCount = precinctFile_0.zones.Count;
			dataGridView_0.Invalidate();
			dataGridView_0.Refresh();
			try
			{
				if (dataGridView_0.RowCount > 0)
				{
					dataGridView_0.ClearSelection();
					dataGridView_0.CurrentCell = dataGridView_0.Rows[0].Cells[0];
					dataGridView_0.Rows[0].Selected = true;
					dataGridView_0_SelectionChanged(dataGridView_0, null);
				}
			}
			catch
			{
			}
			Text = Class16.smethod_0(1649191812) + System.IO.Path.GetFileName(string_0);
			method_3();
		}
		finally
		{
			bool_2 = false;
			bool_1 = false;
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		if (precinctFile_0 != null && !string.IsNullOrEmpty(string_0))
		{
			if (precinctFile_0.SaveFile(string_0))
			{
				toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649191837));
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649191837)), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649191850));
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649191850)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		else
		{
			toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649191885));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649191885)), TextStorage.Msg(Class16.smethod_0(1648943005)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649191916)), Class16.smethod_0(1649190913), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649190928)));
		toolStripMenuItem.Click += method_5;
		contextMenuStrip.Items.Add(toolStripMenuItem);
		contextMenuStrip.Show(toolStrip_0, new Point(toolStripButton_3.Bounds.Left, toolStripButton_3.Bounds.Bottom));
	}

	private void method_5(object sender, EventArgs e)
	{
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649190967)), string.Empty);
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		try
		{
			DialogResult dialogResult = folderBrowserDialog.ShowDialog();
			if (dialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
			{
				return;
			}
			string selectedPath = folderBrowserDialog.SelectedPath;
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649190999)), string.Empty);
			FolderBrowserDialog folderBrowserDialog2 = new FolderBrowserDialog();
			try
			{
				DialogResult dialogResult2 = folderBrowserDialog2.ShowDialog();
				if (dialogResult2 == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog2.SelectedPath))
				{
					string[] files = Directory.GetFiles(folderBrowserDialog2.SelectedPath, Class16.smethod_0(1649090256), SearchOption.AllDirectories);
					string[] array = files;
					foreach (string path in array)
					{
						PrecinctFile precinctFile = new PrecinctFile();
						if (precinctFile.ReadFile(path))
						{
							string fileName = System.IO.Path.GetFileName(path);
							string name = new DirectoryInfo(System.IO.Path.GetDirectoryName(path)).Name;
							string path2 = System.IO.Path.Combine(selectedPath, name + Class16.smethod_0(1648927580) + fileName);
							precinctFile.SaveFile(path2, both: false, PutToData: false);
						}
					}
				}
			}
			finally
			{
				((IDisposable)folderBrowserDialog2).Dispose();
			}
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649191030)), string.Empty);
		}
		finally
		{
			((IDisposable)folderBrowserDialog).Dispose();
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		if (!bool_1 && bool_0 && precinctFile_0 != null)
		{
			try
			{
				PushPrecinctUndo();
				PrecinctEntry precinctEntry = new PrecinctEntry
				{
					ID = ((precinctFile_0.zones.Count > 0) ? (((IEnumerable<PrecinctEntry>)precinctFile_0.zones).Max((Func<PrecinctEntry, int>)Class351.class351_0.method_0) + 1) : 0),
					name = Class16.smethod_0(1649191051),
					m_iPriority = 0,
					m_idDstIns = 0,
					m_idSrcInst = 0,
					m_idDomain = 0,
					m_bPKProtect = 0,
					iNumMark = 0,
					m_iMusicInter = 0,
					m_iMusicLoop = 0
				};
				precinctEntry.m_vCityPos = new PrecinctVector3(Class16.smethod_0(1648924112), Class16.smethod_0(1648924112), Class16.smethod_0(1648924112));
				precinctEntry.m_aPoints.Add(new PrecinctVector3(Class16.smethod_0(1648924112), Class16.smethod_0(1648924112), Class16.smethod_0(1648924112)));
				precinctEntry.m_aPoints.Add(new PrecinctVector3(Class16.smethod_0(1648911042), Class16.smethod_0(1648924112), Class16.smethod_0(1648911042)));
				precinctEntry.m_aPoints.Add(new PrecinctVector3(Class16.smethod_0(1648911042), Class16.smethod_0(1648924112), Class16.smethod_0(1648924112)));
				precinctFile_0.zones.Add(precinctEntry);
				dataGridView_0.RowCount = precinctFile_0.zones.Count;
				dataGridView_0.Refresh();
				method_3();
				dataGridView_0.ClearSelection();
				int index = dataGridView_0.Rows.Count - 1;
				dataGridView_0.Rows[index].Selected = true;
				dataGridView_0.CurrentCell = dataGridView_0.Rows[index].Cells[0];
			}
			catch
			{
			}
		}
	}

	private void dataGridView_0_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (bool_0 && precinctFile_0 != null && e.RowIndex >= 0 && e.RowIndex < precinctFile_0.zones.Count)
		{
			int rowIndex = e.RowIndex;
			switch (e.ColumnIndex)
			{
			case 0:
				e.Value = precinctFile_0.zones[rowIndex].ID;
				break;
			case 1:
				e.Value = precinctFile_0.zones[rowIndex].name;
				break;
			case 2:
				e.Value = precinctFile_0.zones[rowIndex].m_iPriority;
				break;
			case 3:
				e.Value = precinctFile_0.zones[rowIndex].m_idDstIns;
				break;
			case 4:
				e.Value = precinctFile_0.zones[rowIndex].m_idSrcInst;
				break;
			case 5:
				e.Value = precinctFile_0.zones[rowIndex].m_idDomain;
				break;
			case 6:
				e.Value = precinctFile_0.zones[rowIndex].m_bPKProtect;
				break;
			case 7:
				e.Value = precinctFile_0.zones[rowIndex].iNumMark;
				break;
			case 8:
				e.Value = precinctFile_0.zones[rowIndex].m_iMusicInter;
				break;
			case 9:
				e.Value = precinctFile_0.zones[rowIndex].m_iMusicLoop;
				break;
			}
		}
	}

	private void dataGridView_0_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
	{
		if (bool_1 || !bool_0 || precinctFile_0 == null || e.RowIndex < 0 || e.RowIndex >= precinctFile_0.zones.Count)
		{
			return;
		}
		PushPrecinctUndo();
		bool_1 = true;
		int rowIndex = e.RowIndex;
		try
		{
			object value = e.Value;
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
					goto IL_007c;
				}
			}
			obj = Class16.smethod_0(1648924112);
			goto IL_007c;
			IL_007c:
			string text = (string)obj;
			switch (e.ColumnIndex)
			{
			case 0:
				precinctFile_0.zones[rowIndex].ID = int.Parse(text);
				break;
			case 1:
				precinctFile_0.zones[rowIndex].name = text;
				break;
			case 2:
				precinctFile_0.zones[rowIndex].m_iPriority = int.Parse(text);
				break;
			case 3:
				precinctFile_0.zones[rowIndex].m_idDstIns = int.Parse(text);
				break;
			case 4:
				precinctFile_0.zones[rowIndex].m_idSrcInst = int.Parse(text);
				break;
			case 5:
				precinctFile_0.zones[rowIndex].m_idDomain = int.Parse(text);
				break;
			case 6:
				precinctFile_0.zones[rowIndex].m_bPKProtect = byte.Parse(text);
				break;
			case 7:
				precinctFile_0.zones[rowIndex].iNumMark = int.Parse(text);
				break;
			case 8:
				precinctFile_0.zones[rowIndex].m_iMusicInter = int.Parse(text);
				break;
			case 9:
				precinctFile_0.zones[rowIndex].m_iMusicLoop = int.Parse(text);
				break;
			}
		}
		catch
		{
		}
		bool_1 = false;
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		if (!bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null || dataGridView_0.CurrentCell.RowIndex < 0)
		{
			return;
		}
		int rowIndex = dataGridView_0.CurrentCell.RowIndex;
		if (rowIndex < precinctFile_0.zones.Count)
		{
			dataGridView_1.RowCount = precinctFile_0.zones[rowIndex].m_aPoints.Count;
			dataGridView_2.RowCount = precinctFile_0.zones[rowIndex].Npcs.Count;
			dataGridView_3.RowCount = precinctFile_0.zones[rowIndex].music.Count;
			bool flag = bool_2;
			bool_2 = true;
			try
			{
				textBox_0.Text = precinctFile_0.zones[rowIndex].m_vCityPos.oX;
				textBox_1.Text = precinctFile_0.zones[rowIndex].m_vCityPos.oY;
				textBox_2.Text = precinctFile_0.zones[rowIndex].m_vCityPos.oZ;
			}
			finally
			{
				bool_2 = flag;
			}
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			PushPrecinctUndo();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count)
			{
				PrecinctEntry item = precinctFile_0.zones[rowIndex].Clone();
				precinctFile_0.zones.Add(item);
				dataGridView_0.RowCount = precinctFile_0.zones.Count;
				dataGridView_0.Refresh();
				method_3();
				dataGridView_0.ClearSelection();
				int index = dataGridView_0.Rows.Count - 1;
				dataGridView_0.Rows[index].Selected = true;
				dataGridView_0.CurrentCell = dataGridView_0.Rows[index].Cells[0];
			}
		}
		catch
		{
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			PushPrecinctUndo();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count)
			{
				precinctFile_0.zones.RemoveAt(rowIndex);
				dataGridView_0.RowCount = precinctFile_0.zones.Count;
				dataGridView_1.RowCount = 0;
				dataGridView_2.RowCount = 0;
				dataGridView_3.RowCount = 0;
				dataGridView_0.Refresh();
				method_3();
				if (dataGridView_0.Rows.Count > 0)
				{
					int index = Math.Min(rowIndex, dataGridView_0.Rows.Count - 1);
					dataGridView_0.ClearSelection();
					dataGridView_0.Rows[index].Selected = true;
					dataGridView_0.CurrentCell = dataGridView_0.Rows[index].Cells[0];
				}
			}
		}
		catch
		{
		}
	}

	private void dataGridView_1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (!bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count && e.RowIndex >= 0 && e.RowIndex < precinctFile_0.zones[rowIndex].m_aPoints.Count)
			{
				switch (e.ColumnIndex)
				{
				case 0:
					e.Value = precinctFile_0.zones[rowIndex].m_aPoints[e.RowIndex].oX;
					break;
				case 1:
					e.Value = precinctFile_0.zones[rowIndex].m_aPoints[e.RowIndex].oY;
					break;
				case 2:
					e.Value = precinctFile_0.zones[rowIndex].m_aPoints[e.RowIndex].oZ;
					break;
				}
			}
		}
		catch
		{
		}
	}

	private void dataGridView_1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
	{
		if (!bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex < 0 || rowIndex >= precinctFile_0.zones.Count || e.RowIndex < 0 || e.RowIndex >= precinctFile_0.zones[rowIndex].m_aPoints.Count)
			{
				return;
			}
			PushPrecinctUndo();
			object value = e.Value;
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
					goto IL_00ad;
				}
			}
			obj = Class16.smethod_0(1648924112);
			goto IL_00ad;
			IL_00ad:
			string text = (string)obj;
			switch (e.ColumnIndex)
			{
			case 0:
				precinctFile_0.zones[rowIndex].m_aPoints[e.RowIndex].oX = text;
				break;
			case 1:
				precinctFile_0.zones[rowIndex].m_aPoints[e.RowIndex].oY = text;
				break;
			case 2:
				precinctFile_0.zones[rowIndex].m_aPoints[e.RowIndex].oZ = text;
				break;
			}
		}
		catch
		{
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			PushPrecinctUndo();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count)
			{
				PrecinctVector3 item = new PrecinctVector3(Class16.smethod_0(1648924112), Class16.smethod_0(1648924112), Class16.smethod_0(1648924112));
				precinctFile_0.zones[rowIndex].m_aPoints.Add(item);
				dataGridView_1.RowCount = precinctFile_0.zones[rowIndex].m_aPoints.Count;
				dataGridView_1.Refresh();
				dataGridView_1.ClearSelection();
				int index = dataGridView_1.Rows.Count - 1;
				dataGridView_1.Rows[index].Selected = true;
				dataGridView_1.CurrentCell = dataGridView_1.Rows[index].Cells[0];
			}
		}
		catch
		{
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null || dataGridView_1.CurrentCell == null)
		{
			return;
		}
		try
		{
			PushPrecinctUndo();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			int rowIndex2 = dataGridView_1.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count && rowIndex2 >= 0 && rowIndex2 < precinctFile_0.zones[rowIndex].m_aPoints.Count)
			{
				precinctFile_0.zones[rowIndex].m_aPoints.RemoveAt(rowIndex2);
				dataGridView_1.RowCount = precinctFile_0.zones[rowIndex].m_aPoints.Count;
				dataGridView_1.Refresh();
				if (dataGridView_1.Rows.Count > 0)
				{
					dataGridView_1.ClearSelection();
					int index = Math.Min(rowIndex2, dataGridView_1.Rows.Count - 1);
					dataGridView_1.Rows[index].Selected = true;
					dataGridView_1.CurrentCell = dataGridView_1.Rows[index].Cells[0];
				}
			}
		}
		catch
		{
		}
	}

	private void dataGridView_2_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (!bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count && e.RowIndex >= 0 && e.RowIndex < precinctFile_0.zones[rowIndex].Npcs.Count)
			{
				switch (e.ColumnIndex)
				{
				case 0:
					e.Value = precinctFile_0.zones[rowIndex].Npcs[e.RowIndex].Name;
					break;
				case 1:
					e.Value = precinctFile_0.zones[rowIndex].Npcs[e.RowIndex].position.oX;
					break;
				case 2:
					e.Value = precinctFile_0.zones[rowIndex].Npcs[e.RowIndex].position.oY;
					break;
				case 3:
					e.Value = precinctFile_0.zones[rowIndex].Npcs[e.RowIndex].position.oZ;
					break;
				}
			}
		}
		catch
		{
		}
	}

	private void dataGridView_2_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
	{
		if (!bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex < 0 || rowIndex >= precinctFile_0.zones.Count || e.RowIndex < 0 || e.RowIndex >= precinctFile_0.zones[rowIndex].Npcs.Count)
			{
				return;
			}
			PushPrecinctUndo();
			object value = e.Value;
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
					goto IL_00a8;
				}
			}
			obj = string.Empty;
			goto IL_00a8;
			IL_00a8:
			string text = (string)obj;
			switch (e.ColumnIndex)
			{
			case 0:
				precinctFile_0.zones[rowIndex].Npcs[e.RowIndex].Name = text;
				break;
			case 1:
				precinctFile_0.zones[rowIndex].Npcs[e.RowIndex].position.oX = text;
				break;
			case 2:
				precinctFile_0.zones[rowIndex].Npcs[e.RowIndex].position.oY = text;
				break;
			case 3:
				precinctFile_0.zones[rowIndex].Npcs[e.RowIndex].position.oZ = text;
				break;
			}
		}
		catch
		{
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			PushPrecinctUndo();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count)
			{
				PrecinctNPC item = new PrecinctNPC
				{
					Name = Class16.smethod_0(1649191078),
					position = new PrecinctVector3(Class16.smethod_0(1648924112), Class16.smethod_0(1648924112), Class16.smethod_0(1648924112))
				};
				precinctFile_0.zones[rowIndex].Npcs.Add(item);
				dataGridView_2.RowCount = precinctFile_0.zones[rowIndex].Npcs.Count;
				dataGridView_2.Refresh();
				dataGridView_2.ClearSelection();
				int index = dataGridView_2.Rows.Count - 1;
				dataGridView_2.Rows[index].Selected = true;
				dataGridView_2.CurrentCell = dataGridView_2.Rows[index].Cells[0];
			}
		}
		catch
		{
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null || dataGridView_2.CurrentCell == null)
		{
			return;
		}
		try
		{
			PushPrecinctUndo();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			int rowIndex2 = dataGridView_2.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count && rowIndex2 >= 0 && rowIndex2 < precinctFile_0.zones[rowIndex].Npcs.Count)
			{
				precinctFile_0.zones[rowIndex].Npcs.RemoveAt(rowIndex2);
				dataGridView_2.RowCount = precinctFile_0.zones[rowIndex].Npcs.Count;
				dataGridView_2.Refresh();
				if (dataGridView_2.Rows.Count > 0)
				{
					dataGridView_2.ClearSelection();
					int index = Math.Min(rowIndex2, dataGridView_2.Rows.Count - 1);
					dataGridView_2.Rows[index].Selected = true;
					dataGridView_2.CurrentCell = dataGridView_2.Rows[index].Cells[0];
				}
			}
		}
		catch
		{
		}
	}

	private void dataGridView_3_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (!bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count && e.RowIndex >= 0 && e.RowIndex < precinctFile_0.zones[rowIndex].music.Count)
			{
				e.Value = precinctFile_0.zones[rowIndex].music[e.RowIndex];
			}
		}
		catch
		{
		}
	}

	private void dataGridView_3_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
	{
		if (!bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex < 0 || rowIndex >= precinctFile_0.zones.Count || e.RowIndex < 0 || e.RowIndex >= precinctFile_0.zones[rowIndex].music.Count)
			{
				return;
			}
			PushPrecinctUndo();
			List<string> music = precinctFile_0.zones[rowIndex].music;
			int rowIndex2 = e.RowIndex;
			object value = e.Value;
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
					goto IL_00bb;
				}
			}
			obj = string.Empty;
			goto IL_00bb;
			IL_00bb:
			music[rowIndex2] = (string)obj;
		}
		catch
		{
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			PushPrecinctUndo();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count)
			{
				precinctFile_0.zones[rowIndex].music.Add(Class16.smethod_0(1649191092));
				dataGridView_3.RowCount = precinctFile_0.zones[rowIndex].music.Count;
				dataGridView_3.Refresh();
				dataGridView_3.ClearSelection();
				int index = dataGridView_3.Rows.Count - 1;
				dataGridView_3.Rows[index].Selected = true;
				dataGridView_3.CurrentCell = dataGridView_3.Rows[index].Cells[0];
			}
		}
		catch
		{
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || precinctFile_0 == null || dataGridView_0.CurrentCell == null || dataGridView_3.CurrentCell == null)
		{
			return;
		}
		try
		{
			PushPrecinctUndo();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			int rowIndex2 = dataGridView_3.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count && rowIndex2 >= 0 && rowIndex2 < precinctFile_0.zones[rowIndex].music.Count)
			{
				precinctFile_0.zones[rowIndex].music.RemoveAt(rowIndex2);
				dataGridView_3.RowCount = precinctFile_0.zones[rowIndex].music.Count;
				dataGridView_3.Refresh();
				if (dataGridView_3.Rows.Count > 0)
				{
					dataGridView_3.ClearSelection();
					int index = Math.Min(rowIndex2, dataGridView_3.Rows.Count - 1);
					dataGridView_3.Rows[index].Selected = true;
					dataGridView_3.CurrentCell = dataGridView_3.Rows[index].Cells[0];
				}
			}
		}
		catch
		{
		}
	}

	private void textBox_2_TextChanged(object sender, EventArgs e)
	{
		if (bool_2 || precinctFile_0 == null || !bool_0 || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			PushPrecinctUndo();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < precinctFile_0.zones.Count)
			{
				precinctFile_0.zones[rowIndex].m_vCityPos.oX = textBox_0.Text;
				precinctFile_0.zones[rowIndex].m_vCityPos.oY = textBox_1.Text;
				precinctFile_0.zones[rowIndex].m_vCityPos.oZ = textBox_2.Text;
			}
		}
		catch
		{
		}
	}

	private void textBox_3_TextChanged(object sender, EventArgs e)
	{
		if (bool_2 || precinctFile_0 == null)
		{
			return;
		}
		try
		{
			PushPrecinctUndo();
			uint dwVersion = Convert.ToUInt32(textBox_3.Text);
			precinctFile_0.dwVersion = dwVersion;
		}
		catch
		{
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (precinctFile_0 != null)
		{
			PushPrecinctUndo();
			long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			textBox_4.Text = num.ToString();
			precinctFile_0.dwTimeStamp = (int)num;
		}
	}

	private void method_15()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1649211086));
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_16, method_17);
		fileBasedUndoManager_0.AttachToToolStrip(toolStrip_0, method_20, method_21);
	}

	private byte[] method_16()
	{
		if (precinctFile_0 == null)
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
					binaryWriter.Write(precinctFile_0.dwVersion);
					binaryWriter.Write(precinctFile_0.dwTimeStamp);
					binaryWriter.Write(precinctFile_0.zones.Count);
					foreach (PrecinctEntry zone in precinctFile_0.zones)
					{
						binaryWriter.Write(zone.ID);
						binaryWriter.Write(zone.name ?? string.Empty);
						binaryWriter.Write(zone.iNumMark);
						binaryWriter.Write(zone.m_iPriority);
						binaryWriter.Write(zone.m_idDstIns);
						binaryWriter.Write(zone.m_iMusicInter);
						binaryWriter.Write(zone.m_iMusicLoop);
						binaryWriter.Write(zone.m_idSrcInst);
						binaryWriter.Write(zone.m_idDomain);
						binaryWriter.Write(zone.m_bPKProtect);
						PrecinctVector3 vCityPos = zone.m_vCityPos;
						object obj;
						if (vCityPos == null)
						{
							obj = null;
						}
						else
						{
							obj = vCityPos.oX;
							if (obj != null)
							{
								goto IL_0112;
							}
						}
						obj = Class16.smethod_0(1648924112);
						goto IL_0112;
						IL_0138:
						object obj2;
						binaryWriter.Write((string)obj2);
						PrecinctVector3 vCityPos2 = zone.m_vCityPos;
						object obj3;
						if (vCityPos2 == null)
						{
							obj3 = null;
						}
						else
						{
							obj3 = vCityPos2.oZ;
							if (obj3 != null)
							{
								goto IL_015e;
							}
						}
						obj3 = Class16.smethod_0(1648924112);
						goto IL_015e;
						IL_0112:
						binaryWriter.Write((string)obj);
						PrecinctVector3 vCityPos3 = zone.m_vCityPos;
						if (vCityPos3 == null)
						{
							obj2 = null;
						}
						else
						{
							obj2 = vCityPos3.oY;
							if (obj2 != null)
							{
								goto IL_0138;
							}
						}
						obj2 = Class16.smethod_0(1648924112);
						goto IL_0138;
						IL_015e:
						binaryWriter.Write((string)obj3);
						binaryWriter.Write(zone.m_aPoints.Count);
						foreach (PrecinctVector3 aPoint in zone.m_aPoints)
						{
							binaryWriter.Write(aPoint.oX ?? Class16.smethod_0(1648924112));
							binaryWriter.Write(aPoint.oY ?? Class16.smethod_0(1648924112));
							binaryWriter.Write(aPoint.oZ ?? Class16.smethod_0(1648924112));
						}
						binaryWriter.Write(zone.Npcs.Count);
						using (List<PrecinctNPC>.Enumerator enumerator3 = zone.Npcs.GetEnumerator())
						{
							object obj6;
							for (; enumerator3.MoveNext(); binaryWriter.Write((string)obj6))
							{
								PrecinctNPC current3 = enumerator3.Current;
								binaryWriter.Write(current3.Name ?? string.Empty);
								PrecinctVector3 position = current3.position;
								object obj4;
								if (position == null)
								{
									obj4 = null;
								}
								else
								{
									obj4 = position.oX;
									if (obj4 != null)
									{
										goto IL_0259;
									}
								}
								obj4 = Class16.smethod_0(1648924112);
								goto IL_0259;
								IL_027f:
								object obj5;
								binaryWriter.Write((string)obj5);
								PrecinctVector3 position2 = current3.position;
								if (position2 == null)
								{
									obj6 = null;
								}
								else
								{
									obj6 = position2.oZ;
									if (obj6 != null)
									{
										continue;
									}
								}
								obj6 = Class16.smethod_0(1648924112);
								continue;
								IL_0259:
								binaryWriter.Write((string)obj4);
								PrecinctVector3 position3 = current3.position;
								if (position3 == null)
								{
									obj5 = null;
								}
								else
								{
									obj5 = position3.oY;
									if (obj5 != null)
									{
										goto IL_027f;
									}
								}
								obj5 = Class16.smethod_0(1648924112);
								goto IL_027f;
							}
						}
						binaryWriter.Write(zone.music.Count);
						foreach (string item in zone.music)
						{
							binaryWriter.Write(item ?? string.Empty);
						}
					}
					binaryWriter.Write(dataGridView_0.CurrentCell?.RowIndex ?? (-1));
					binaryWriter.Write(dataGridView_1.CurrentCell?.RowIndex ?? (-1));
					binaryWriter.Write(dataGridView_2.CurrentCell?.RowIndex ?? (-1));
					binaryWriter.Write(dataGridView_3.CurrentCell?.RowIndex ?? (-1));
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

	private void method_17(byte[] byte_0)
	{
		if (byte_0 == null || byte_0.Length == 0 || precinctFile_0 == null)
		{
			return;
		}
		bool_2 = true;
		bool_1 = true;
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_0);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					precinctFile_0.dwVersion = binaryReader.ReadUInt32();
					precinctFile_0.dwTimeStamp = binaryReader.ReadInt32();
					int num = binaryReader.ReadInt32();
					precinctFile_0.zones = new List<PrecinctEntry>(num);
					for (int i = 0; i < num; i++)
					{
						PrecinctEntry precinctEntry = new PrecinctEntry
						{
							ID = binaryReader.ReadInt32(),
							name = binaryReader.ReadString(),
							iNumMark = binaryReader.ReadInt32(),
							m_iPriority = binaryReader.ReadInt32(),
							m_idDstIns = binaryReader.ReadInt32(),
							m_iMusicInter = binaryReader.ReadInt32(),
							m_iMusicLoop = binaryReader.ReadInt32(),
							m_idSrcInst = binaryReader.ReadInt32(),
							m_idDomain = binaryReader.ReadInt32(),
							m_bPKProtect = binaryReader.ReadByte(),
							m_vCityPos = new PrecinctVector3(binaryReader.ReadString(), binaryReader.ReadString(), binaryReader.ReadString())
						};
						int num2 = binaryReader.ReadInt32();
						precinctEntry.m_aPoints = new List<PrecinctVector3>(num2);
						for (int j = 0; j < num2; j++)
						{
							precinctEntry.m_aPoints.Add(new PrecinctVector3(binaryReader.ReadString(), binaryReader.ReadString(), binaryReader.ReadString()));
						}
						int num3 = binaryReader.ReadInt32();
						precinctEntry.Npcs = new List<PrecinctNPC>(num3);
						for (int k = 0; k < num3; k++)
						{
							precinctEntry.Npcs.Add(new PrecinctNPC
							{
								Name = binaryReader.ReadString(),
								position = new PrecinctVector3(binaryReader.ReadString(), binaryReader.ReadString(), binaryReader.ReadString())
							});
						}
						int num4 = binaryReader.ReadInt32();
						precinctEntry.music = new List<string>(num4);
						for (int l = 0; l < num4; l++)
						{
							precinctEntry.music.Add(binaryReader.ReadString());
						}
						precinctFile_0.zones.Add(precinctEntry);
					}
					int int_ = binaryReader.ReadInt32();
					int int_2 = binaryReader.ReadInt32();
					int int_3 = binaryReader.ReadInt32();
					int int_4 = binaryReader.ReadInt32();
					method_18();
					int num5 = smethod_1(int_, dataGridView_0.Rows.Count);
					smethod_0(dataGridView_0, num5);
					dataGridView_0_SelectionChanged(dataGridView_0, EventArgs.Empty);
					smethod_0(dataGridView_1, smethod_1(int_2, dataGridView_1.Rows.Count));
					smethod_0(dataGridView_2, smethod_1(int_3, dataGridView_2.Rows.Count));
					smethod_0(dataGridView_3, smethod_1(int_4, dataGridView_3.Rows.Count));
					if (num5 < 0 && dataGridView_0.Rows.Count > 0)
					{
						dataGridView_0.CurrentCell = dataGridView_0.Rows[0].Cells[0];
					}
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
			bool_2 = false;
		}
	}

	public void PushPrecinctUndo()
	{
		if (!bool_2 && !bool_1)
		{
			byte[] array = method_16();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
		}
	}

	private void method_18()
	{
		if (precinctFile_0 != null)
		{
			textBox_3.Text = precinctFile_0.dwVersion.ToString();
			textBox_4.Text = precinctFile_0.dwTimeStamp.ToString();
			dataGridView_0.RowCount = precinctFile_0.zones.Count;
			dataGridView_0.Invalidate();
			dataGridView_0.Refresh();
			method_3();
		}
	}

	private static void smethod_0(DataGridView dataGridView_4, int int_0)
	{
		dataGridView_4.ClearSelection();
		if (int_0 >= 0 && int_0 < dataGridView_4.Rows.Count)
		{
			dataGridView_4.Rows[int_0].Selected = true;
			dataGridView_4.CurrentCell = dataGridView_4.Rows[int_0].Cells[0];
		}
	}

	private static int smethod_1(int int_0, int int_1)
	{
		if (int_0 >= 0 && int_0 < int_1)
		{
			return int_0;
		}
		return -1;
	}

	private void PrecinctEditorForm_Activated(object sender, EventArgs e)
	{
		method_19();
	}

	private void method_19()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_PrecinctEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_PrecinctEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void method_20(object sender, EventArgs e)
	{
		byte[] currentState = method_16();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_17(array);
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		byte[] currentState = method_16();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_17(array);
		}
	}
}
