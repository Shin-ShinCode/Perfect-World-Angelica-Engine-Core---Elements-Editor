using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Region;

public class RegionEditorForm : Form
{
	private RegionFile regionFile_0;

	private string string_0;

	private bool bool_0;

	private bool bool_1;

	private int int_0 = -1;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private StatusStrip statusStrip_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private ToolStripStatusLabel toolStripStatusLabel_1;

	private ToolStripStatusLabel toolStripStatusLabel_2;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TabPage tabPage_1;

	private TabPage tabPage_2;

	private DataGridView dataGridView_0;

	private DataGridView dataGridView_1;

	private DataGridView dataGridView_2;

	private ContextMenuStrip contextMenuStrip_0;

	private ContextMenuStrip contextMenuStrip_1;

	private ContextMenuStrip contextMenuStrip_2;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private Button button_0;

	private string string_1;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private bool bool_2;

	public bool HasFileLoaded
	{
		get
		{
			if (regionFile_0 != null)
			{
				if (regionFile_0.regions.Count <= 0)
				{
					return regionFile_0.teleports.Count > 0;
				}
				return true;
			}
			return false;
		}
	}

	public RegionEditorForm()
	{
		method_2();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		method_1(dataGridView_0);
		method_1(dataGridView_1);
		method_1(dataGridView_2);
		base.Activated += RegionEditorForm_Activated;
		method_15();
	}

	private void method_0()
	{
		base.Icon = Resources.regioneditor;
	}

	private void method_1(DataGridView dataGridView_3)
	{
		dataGridView_3.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
		dataGridView_3.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
		dataGridView_3.DefaultCellStyle.SelectionForeColor = Color.White;
		dataGridView_3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
		dataGridView_3.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
		dataGridView_3.ColumnHeadersDefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		dataGridView_3.ColumnHeadersDefaultCellStyle.Padding = new Padding(4);
		dataGridView_3.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 9f);
		dataGridView_3.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
		dataGridView_3.RowTemplate.Height = 28;
	}

	public void LoadRegionFile(string path)
	{
		if (!string.IsNullOrWhiteSpace(path))
		{
			string_0 = path;
			method_4();
		}
	}

	private void method_2()
	{
		Text = Class16.smethod_0(1649163033);
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
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			Padding = new Padding(8, 4, 8, 4),
			ToolTipText = Class16.smethod_0(1649163066)
		};
		toolStripButton_0.Click += toolStripButton_0_Click;
		toolStripButton_1 = new ToolStripButton(TextStorage.Msg(Class16.smethod_0(1649189188), Class16.smethod_0(1649189206)))
		{
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			Padding = new Padding(8, 4, 8, 4),
			ToolTipText = Class16.smethod_0(1649189219)
		};
		toolStripButton_1.Click += toolStripButton_1_Click;
		toolStripButton_2 = new ToolStripButton(TextStorage.Msg(Class16.smethod_0(1649163101), Class16.smethod_0(1649189278)))
		{
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			Padding = new Padding(8, 4, 8, 4),
			ToolTipText = Class16.smethod_0(1649189326)
		};
		toolStripButton_2.Click += toolStripButton_2_Click;
		toolStripButton_3 = new ToolStripButton(TextStorage.Msg(Class16.smethod_0(1649189353), Class16.smethod_0(1649192452)))
		{
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
		tabControl_0 = new TabControl
		{
			Dock = DockStyle.Fill,
			Font = new Font(Class16.smethod_0(1648942905), 9.5f),
			Padding = new Point(12, 8)
		};
		tabPage_0 = new TabPage(Class16.smethod_0(1649163115))
		{
			BackColor = Color.White,
			Padding = new Padding(0),
			UseVisualStyleBackColor = true
		};
		tabPage_1 = new TabPage(Class16.smethod_0(1649163166))
		{
			BackColor = Color.White,
			Padding = new Padding(6),
			UseVisualStyleBackColor = true
		};
		tabPage_2 = new TabPage(Class16.smethod_0(1649191499))
		{
			BackColor = Color.White,
			Padding = new Padding(12),
			UseVisualStyleBackColor = true
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
		DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
		dataGridViewComboBoxColumn.HeaderText = Class16.smethod_0(1648936875);
		dataGridViewComboBoxColumn.Name = Class16.smethod_0(1649163201);
		dataGridViewComboBoxColumn.Width = 200;
		dataGridViewComboBoxColumn.DataSource = Enum.GetValues(typeof(RegionType));
		dataGridViewComboBoxColumn.ValueType = typeof(RegionType);
		dataGridViewComboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
		dataGridViewComboBoxColumn.FlatStyle = FlatStyle.Flat;
		DataGridViewComboBoxColumn dataGridViewColumn = dataGridViewComboBoxColumn;
		dataGridView_0.Columns.Add(dataGridViewColumn);
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648936731),
			Name = Class16.smethod_0(1649163218),
			AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
			MinimumWidth = 150
		});
		dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649163235),
			Name = Class16.smethod_0(1649163250),
			Width = 100,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Alignment = DataGridViewContentAlignment.MiddleCenter
			}
		});
		dataGridView_0.CellValueNeeded += dataGridView_0_CellValueNeeded;
		dataGridView_0.CellValuePushed += dataGridView_0_CellValuePushed;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		contextMenuStrip_0 = new ContextMenuStrip
		{
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649162255)));
		toolStripMenuItem.Click += method_6;
		ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649162279)));
		toolStripMenuItem2.Click += method_7;
		ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649162297)));
		toolStripMenuItem3.Click += method_8;
		contextMenuStrip_0.Items.AddRange(new ToolStripItem[4]
		{
			toolStripMenuItem,
			new ToolStripSeparator(),
			toolStripMenuItem2,
			toolStripMenuItem3
		});
		dataGridView_0.ContextMenuStrip = contextMenuStrip_0;
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
			Name = Class16.smethod_0(1649162332),
			AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_1.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648916476),
			Name = Class16.smethod_0(1649162338),
			AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_1.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1648915467),
			Name = Class16.smethod_0(1649162352),
			AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_1.CellValueNeeded += dataGridView_1_CellValueNeeded;
		dataGridView_1.CellValuePushed += dataGridView_1_CellValuePushed;
		dataGridView_1.SelectionChanged += dataGridView_1_SelectionChanged;
		contextMenuStrip_1 = new ContextMenuStrip
		{
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649162374)));
		toolStripMenuItem4.Click += method_9;
		ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649162397)));
		toolStripMenuItem5.Click += method_10;
		contextMenuStrip_1.Items.AddRange(new ToolStripItem[3]
		{
			toolStripMenuItem4,
			new ToolStripSeparator(),
			toolStripMenuItem5
		});
		dataGridView_1.ContextMenuStrip = contextMenuStrip_1;
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Vertical,
			SplitterDistance = 400,
			BorderStyle = BorderStyle.FixedSingle,
			BackColor = SystemColors.ControlDark
		};
		Panel panel = new Panel
		{
			Dock = DockStyle.Fill,
			Padding = new Padding(0)
		};
		panel.Controls.Add(dataGridView_0);
		Panel panel2 = new Panel
		{
			Dock = DockStyle.Fill,
			Padding = new Padding(0)
		};
		panel2.Controls.Add(dataGridView_1);
		splitContainer.Panel1.Controls.Add(panel);
		splitContainer.Panel2.Controls.Add(panel2);
		tabPage_0.Controls.Add(splitContainer);
		dataGridView_2 = new DataGridView
		{
			AllowUserToAddRows = false,
			AllowUserToDeleteRows = false,
			AllowUserToResizeColumns = true,
			AllowUserToResizeRows = false,
			AutoGenerateColumns = false,
			AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
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
			HeaderText = Class16.smethod_0(1648936875),
			Name = Class16.smethod_0(1649162423),
			FillWeight = 50f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Alignment = DataGridViewContentAlignment.MiddleCenter
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162437),
			Name = Class16.smethod_0(1649162442),
			FillWeight = 60f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Alignment = DataGridViewContentAlignment.MiddleCenter
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162458),
			Name = Class16.smethod_0(1649162477),
			FillWeight = 60f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Alignment = DataGridViewContentAlignment.MiddleCenter
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162483),
			Name = Class16.smethod_0(1649162499),
			FillWeight = 60f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Alignment = DataGridViewContentAlignment.MiddleCenter
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162512),
			Name = Class16.smethod_0(1649162535),
			FillWeight = 80f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162549),
			Name = Class16.smethod_0(1649162564),
			FillWeight = 80f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162570),
			Name = Class16.smethod_0(1649162585),
			FillWeight = 80f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162607),
			Name = Class16.smethod_0(1649162620),
			FillWeight = 80f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162627),
			Name = Class16.smethod_0(1649162640),
			FillWeight = 80f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162663),
			Name = Class16.smethod_0(1649162676),
			FillWeight = 80f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162683),
			Name = Class16.smethod_0(1649162698),
			FillWeight = 80f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162712),
			Name = Class16.smethod_0(1649162735),
			FillWeight = 80f,
			DefaultCellStyle = new DataGridViewCellStyle
			{
				Format = Class16.smethod_0(1649192000)
			}
		});
		dataGridView_2.Columns.Add(new DataGridViewTextBoxColumn
		{
			HeaderText = Class16.smethod_0(1649162749),
			Name = Class16.smethod_0(1649157644),
			FillWeight = 80f,
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
		ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649157650)));
		toolStripMenuItem6.Click += method_11;
		ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649157685)));
		toolStripMenuItem7.Click += method_12;
		ToolStripMenuItem toolStripMenuItem8 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649157706)));
		toolStripMenuItem8.Click += method_13;
		contextMenuStrip_2.Items.AddRange(new ToolStripItem[4]
		{
			toolStripMenuItem6,
			new ToolStripSeparator(),
			toolStripMenuItem7,
			toolStripMenuItem8
		});
		dataGridView_2.ContextMenuStrip = contextMenuStrip_2;
		tabPage_1.Controls.Add(dataGridView_2);
		GroupBox groupBox = new GroupBox
		{
			Text = Class16.smethod_0(1649191568),
			Location = new Point(12, 12),
			Size = new Size(400, 120),
			Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold)
		};
		Label label = new Label
		{
			Text = Class16.smethod_0(1648931051),
			Location = new Point(20, 35),
			Width = 80,
			TextAlign = ContentAlignment.MiddleRight,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_0 = new TextBox
		{
			Location = new Point(110, 33),
			Width = 150,
			TextAlign = HorizontalAlignment.Center,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_0.TextChanged += textBox_0_TextChanged;
		Label label2 = new Label
		{
			Text = Class16.smethod_0(1649191610),
			Location = new Point(20, 70),
			Width = 80,
			TextAlign = ContentAlignment.MiddleRight,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		textBox_1 = new TextBox
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
			Text = Class16.smethod_0(1649191649),
			Location = new Point(270, 67),
			Width = 120,
			Height = 28,
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		button_0.Click += button_0_Click;
		groupBox.Controls.AddRange(new Control[5] { label, textBox_0, label2, textBox_1, button_0 });
		tabPage_2.Controls.Add(groupBox);
		tabControl_0.TabPages.Add(tabPage_0);
		tabControl_0.TabPages.Add(tabPage_1);
		tabControl_0.TabPages.Add(tabPage_2);
		statusStrip_0 = new StatusStrip
		{
			Font = new Font(Class16.smethod_0(1648942905), 9f),
			BackColor = SystemColors.Control
		};
		toolStripStatusLabel_0 = new ToolStripStatusLabel(TextStorage.Msg(Class16.smethod_0(1649192527), Class16.smethod_0(1648920624)))
		{
			Spring = true,
			TextAlign = ContentAlignment.MiddleLeft
		};
		toolStripStatusLabel_1 = new ToolStripStatusLabel(TextStorage.Msg(Class16.smethod_0(1649157736), Class16.smethod_0(1649157763)))
		{
			BorderSides = ToolStripStatusLabelBorderSides.Left,
			Padding = new Padding(8, 0, 8, 0)
		};
		toolStripStatusLabel_2 = new ToolStripStatusLabel(TextStorage.Msg(Class16.smethod_0(1649157788), Class16.smethod_0(1649157810)))
		{
			BorderSides = ToolStripStatusLabelBorderSides.Left,
			Padding = new Padding(8, 0, 8, 0)
		};
		statusStrip_0.Items.AddRange(new ToolStripItem[3] { toolStripStatusLabel_0, toolStripStatusLabel_1, toolStripStatusLabel_2 });
		base.Controls.Add(tabControl_0);
		base.Controls.Add(toolStrip_0);
		base.Controls.Add(statusStrip_0);
	}

	private void method_3()
	{
		if (regionFile_0 != null)
		{
			toolStripStatusLabel_1.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649157838), Class16.smethod_0(1649157851)), regionFile_0.regions.Count);
			toolStripStatusLabel_2.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649157878), Class16.smethod_0(1649157902)), regionFile_0.teleports.Count);
			toolStripStatusLabel_0.Text = ((!string.IsNullOrEmpty(string_1)) ? (Class16.smethod_0(1648912665) + System.IO.Path.GetFileName(string_1)) : TextStorage.Msg(Class16.smethod_0(1649192527), Class16.smethod_0(1648920624)));
		}
		else
		{
			toolStripStatusLabel_1.Text = TextStorage.Msg(Class16.smethod_0(1649157736), Class16.smethod_0(1649157763));
			toolStripStatusLabel_2.Text = TextStorage.Msg(Class16.smethod_0(1649157788), Class16.smethod_0(1649157810));
			toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649157924));
		}
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		try
		{
			openFileDialog.Filter = Class16.smethod_0(1649157944);
			if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
			{
				string_0 = openFileDialog.FileName;
				regionFile_0 = null;
				dataGridView_0.RowCount = 0;
				dataGridView_1.RowCount = 0;
				dataGridView_2.RowCount = 0;
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
		string_1 = string_0;
		regionFile_0 = new RegionFile();
		if (regionFile_0.ReadFile(string_1))
		{
			try
			{
				textBox_0.Text = regionFile_0.dwVersion.ToString();
				textBox_1.Text = regionFile_0.dwTimeStamp.ToString();
				dataGridView_0.RowCount = regionFile_0.regions.Count;
				dataGridView_2.RowCount = regionFile_0.teleports.Count;
				bool_0 = true;
				bool_1 = false;
				try
				{
					if (dataGridView_0.RowCount > 0)
					{
						dataGridView_0.Rows[0].Selected = true;
						dataGridView_0.CurrentCell = dataGridView_0.Rows[0].Cells[0];
						dataGridView_0_SelectionChanged(dataGridView_0, null);
					}
				}
				catch
				{
				}
				Text = Class16.smethod_0(1649158004) + System.IO.Path.GetFileName(string_1);
				method_3();
				method_19();
			}
			catch
			{
				bool_1 = false;
				return;
			}
		}
		bool_1 = false;
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		if (regionFile_0 != null && !string.IsNullOrEmpty(string_1))
		{
			if (regionFile_0.SaveFile(string_1))
			{
				toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649158019));
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649158019)), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649158046));
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649158046)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		else
		{
			toolStripStatusLabel_0.Text = TextStorage.Msg(Class16.smethod_0(1649158071));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649158071)), TextStorage.Msg(Class16.smethod_0(1648943005)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649158100)), Class16.smethod_0(1649190913), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649158127)));
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
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649157132)), string.Empty);
			FolderBrowserDialog folderBrowserDialog2 = new FolderBrowserDialog();
			try
			{
				DialogResult dialogResult2 = folderBrowserDialog2.ShowDialog();
				if (dialogResult2 == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog2.SelectedPath))
				{
					string[] files = Directory.GetFiles(folderBrowserDialog2.SelectedPath, Class16.smethod_0(1649090247), SearchOption.AllDirectories);
					string[] array = files;
					foreach (string path in array)
					{
						RegionFile regionFile = new RegionFile();
						if (regionFile.ReadFile(path))
						{
							string fileName = System.IO.Path.GetFileName(path);
							string name = new DirectoryInfo(System.IO.Path.GetDirectoryName(path)).Name;
							string path2 = System.IO.Path.Combine(selectedPath, name + Class16.smethod_0(1648927580) + fileName);
							regionFile.SaveFile(path2, both: false, PutToData: false);
						}
					}
				}
			}
			finally
			{
				((IDisposable)folderBrowserDialog2).Dispose();
			}
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649157153)), string.Empty);
		}
		finally
		{
			((IDisposable)folderBrowserDialog).Dispose();
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		if (!bool_1 && bool_0 && regionFile_0 != null)
		{
			try
			{
				method_18();
				RegionEntry regionEntry = new RegionEntry
				{
					Type = 0,
					name = Class16.smethod_0(1649157188),
					Strategy = 0
				};
				regionEntry.Zones.Add(new RegionVector3(Class16.smethod_0(1648924112), Class16.smethod_0(1648924112), Class16.smethod_0(1648924112)));
				regionEntry.Zones.Add(new RegionVector3(Class16.smethod_0(1648911042), Class16.smethod_0(1648924112), Class16.smethod_0(1648911042)));
				regionEntry.Zones.Add(new RegionVector3(Class16.smethod_0(1648911042), Class16.smethod_0(1648924112), Class16.smethod_0(1648924112)));
				regionFile_0.regions.Add(regionEntry);
				dataGridView_0.RowCount = regionFile_0.regions.Count;
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
		if (!bool_1 && bool_0 && regionFile_0 != null && e.RowIndex >= 0 && e.RowIndex < regionFile_0.regions.Count)
		{
			int rowIndex = e.RowIndex;
			if (e.ColumnIndex == 0)
			{
				e.Value = (RegionType)regionFile_0.regions[rowIndex].Type;
			}
			else if (e.ColumnIndex == 1)
			{
				e.Value = regionFile_0.regions[rowIndex].name;
			}
			else if (e.ColumnIndex == 2)
			{
				e.Value = regionFile_0.regions[rowIndex].Strategy;
			}
		}
	}

	private void dataGridView_0_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
	{
		if (bool_1 || !bool_0 || regionFile_0 == null || e.RowIndex < 0 || e.RowIndex >= regionFile_0.regions.Count)
		{
			return;
		}
		method_18();
		bool_1 = true;
		int rowIndex = e.RowIndex;
		try
		{
			RegionEntry regionEntry;
			object obj;
			RegionEntry regionEntry2;
			object obj2;
			if (e.ColumnIndex == 0)
			{
				if (e.Value is RegionType type)
				{
					regionFile_0.regions[rowIndex].Type = (int)type;
				}
				else if (e.Value != null)
				{
					regionFile_0.regions[rowIndex].Type = int.Parse(e.Value.ToString());
				}
			}
			else
			{
				if (e.ColumnIndex == 1)
				{
					regionEntry = regionFile_0.regions[rowIndex];
					object value = e.Value;
					if (value == null)
					{
						obj = null;
					}
					else
					{
						obj = value.ToString();
						if (obj != null)
						{
							goto IL_0101;
						}
					}
					obj = string.Empty;
					goto IL_0101;
				}
				if (e.ColumnIndex == 2)
				{
					regionEntry2 = regionFile_0.regions[rowIndex];
					object value2 = e.Value;
					if (value2 == null)
					{
						obj2 = null;
					}
					else
					{
						obj2 = value2.ToString();
						if (obj2 != null)
						{
							goto IL_0142;
						}
					}
					obj2 = Class16.smethod_0(1648924112);
					goto IL_0142;
				}
			}
			goto end_IL_005c;
			IL_0142:
			regionEntry2.Strategy = int.Parse((string)obj2);
			goto end_IL_005c;
			IL_0101:
			regionEntry.name = (string)obj;
			end_IL_005c:;
		}
		catch
		{
		}
		bool_1 = false;
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || regionFile_0 == null || dataGridView_0.CurrentCell == null || dataGridView_0.CurrentCell.RowIndex < 0)
		{
			return;
		}
		int rowIndex = dataGridView_0.CurrentCell.RowIndex;
		if (rowIndex >= regionFile_0.regions.Count)
		{
			return;
		}
		dataGridView_1.RowCount = regionFile_0.regions[rowIndex].ZoneCount;
		if (int_0 != -1 && int_0 < dataGridView_1.RowCount)
		{
			try
			{
				dataGridView_1.Rows[int_0].Selected = true;
				dataGridView_1.CurrentCell = dataGridView_1.Rows[int_0].Cells[0];
			}
			catch
			{
			}
		}
		int_0 = -1;
	}

	private void method_7(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || regionFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			method_18();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < regionFile_0.regions.Count)
			{
				RegionEntry regionEntry = regionFile_0.regions[rowIndex].Clone();
				regionEntry.name += Class16.smethod_0(1649191143);
				regionFile_0.regions.Add(regionEntry);
				dataGridView_0.RowCount = regionFile_0.regions.Count;
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
		if (bool_1 || !bool_0 || regionFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			method_18();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < regionFile_0.regions.Count)
			{
				regionFile_0.regions.RemoveAt(rowIndex);
				dataGridView_0.RowCount = regionFile_0.regions.Count;
				dataGridView_1.RowCount = 0;
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
		if (!bool_0 || regionFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < regionFile_0.regions.Count && e.RowIndex >= 0 && e.RowIndex < regionFile_0.regions[rowIndex].Zones.Count)
			{
				if (e.ColumnIndex == 0)
				{
					e.Value = regionFile_0.regions[rowIndex].Zones[e.RowIndex].oX;
				}
				else if (e.ColumnIndex == 1)
				{
					e.Value = regionFile_0.regions[rowIndex].Zones[e.RowIndex].oY;
				}
				else if (e.ColumnIndex == 2)
				{
					e.Value = regionFile_0.regions[rowIndex].Zones[e.RowIndex].oZ;
				}
			}
		}
		catch
		{
		}
	}

	private void dataGridView_1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
	{
		if (!bool_0 || regionFile_0 == null || dataGridView_0.CurrentCell == null)
		{
			return;
		}
		try
		{
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			if (rowIndex < 0 || rowIndex >= regionFile_0.regions.Count || e.RowIndex < 0 || e.RowIndex >= regionFile_0.regions[rowIndex].Zones.Count)
			{
				return;
			}
			method_18();
			RegionVector3 regionVector;
			object obj;
			if (e.ColumnIndex == 0)
			{
				regionVector = regionFile_0.regions[rowIndex].Zones[e.RowIndex];
				object value = e.Value;
				if (value == null)
				{
					obj = null;
				}
				else
				{
					obj = value.ToString();
					if (obj != null)
					{
						goto IL_00d6;
					}
				}
				obj = Class16.smethod_0(1648924112);
				goto IL_00d6;
			}
			RegionVector3 regionVector2;
			object obj2;
			if (e.ColumnIndex == 1)
			{
				regionVector2 = regionFile_0.regions[rowIndex].Zones[e.RowIndex];
				object value2 = e.Value;
				if (value2 == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = value2.ToString();
					if (obj2 != null)
					{
						goto IL_012a;
					}
				}
				obj2 = Class16.smethod_0(1648924112);
				goto IL_012a;
			}
			if (e.ColumnIndex != 2)
			{
				return;
			}
			RegionVector3 regionVector3 = regionFile_0.regions[rowIndex].Zones[e.RowIndex];
			object value3 = e.Value;
			object obj3;
			if (value3 == null)
			{
				obj3 = null;
			}
			else
			{
				obj3 = value3.ToString();
				if (obj3 != null)
				{
					goto IL_017b;
				}
			}
			obj3 = Class16.smethod_0(1648924112);
			goto IL_017b;
			IL_00d6:
			regionVector.oX = (string)obj;
			return;
			IL_017b:
			regionVector3.oZ = (string)obj3;
			return;
			IL_012a:
			regionVector2.oY = (string)obj2;
		}
		catch
		{
		}
	}

	private void dataGridView_1_SelectionChanged(object sender, EventArgs e)
	{
	}

	private void method_9(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || regionFile_0 == null || dataGridView_0.CurrentCell == null || dataGridView_1.CurrentCell == null)
		{
			return;
		}
		try
		{
			method_18();
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			int rowIndex2 = dataGridView_1.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < regionFile_0.regions.Count && rowIndex2 >= 0)
			{
				RegionVector3 item = ((regionFile_0.regions[rowIndex].Zones.Count <= 0 || rowIndex2 >= regionFile_0.regions[rowIndex].Zones.Count) ? new RegionVector3() : regionFile_0.regions[rowIndex].Zones[rowIndex2].Clone());
				regionFile_0.regions[rowIndex].Zones.Insert(Math.Max(1, rowIndex2), item);
				dataGridView_1.RowCount = regionFile_0.regions[rowIndex].Zones.Count;
				dataGridView_1.Refresh();
				dataGridView_0_SelectionChanged(null, null);
				dataGridView_1.ClearSelection();
				int index = Math.Max(1, rowIndex2);
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
		if (bool_1 || !bool_0 || regionFile_0 == null || dataGridView_0.CurrentCell == null || dataGridView_1.CurrentCell == null)
		{
			return;
		}
		try
		{
			int rowIndex = dataGridView_0.CurrentCell.RowIndex;
			int rowIndex2 = dataGridView_1.CurrentCell.RowIndex;
			if (rowIndex < 0 || rowIndex >= regionFile_0.regions.Count || rowIndex2 < 0 || rowIndex2 >= regionFile_0.regions[rowIndex].Zones.Count)
			{
				return;
			}
			if (rowIndex2 != 0 && rowIndex2 != regionFile_0.regions[rowIndex].Zones.Count - 1)
			{
				method_18();
				regionFile_0.regions[rowIndex].Zones.RemoveAt(rowIndex2);
				dataGridView_1.RowCount = regionFile_0.regions[rowIndex].Zones.Count;
				dataGridView_1.Refresh();
				dataGridView_0_SelectionChanged(null, null);
				if (dataGridView_1.Rows.Count > 0)
				{
					dataGridView_1.ClearSelection();
					int index = Math.Min(rowIndex2, dataGridView_1.Rows.Count - 1);
					dataGridView_1.Rows[index].Selected = true;
					dataGridView_1.CurrentCell = dataGridView_1.Rows[index].Cells[0];
				}
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649157205)), TextStorage.Msg(Class16.smethod_0(1648943005)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch
		{
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (!bool_1 && bool_0 && regionFile_0 != null)
		{
			try
			{
				method_18();
				CELTransportBox item = new CELTransportBox
				{
					m_iType = 1,
					m_idSrcInst = 0,
					m_idInst = 0,
					m_iLevelLmt = 0,
					tm_vPos = new RegionVector3(Class16.smethod_0(1648924112), Class16.smethod_0(1648924112), Class16.smethod_0(1648924112)),
					m_vExts = new RegionVector3(Class16.smethod_0(1648911042), Class16.smethod_0(1648911042), Class16.smethod_0(1648911042)),
					m_vTarge = new RegionVector3(Class16.smethod_0(1648924112), Class16.smethod_0(1648924112), Class16.smethod_0(1648924112))
				};
				regionFile_0.teleports.Add(item);
				dataGridView_2.RowCount = regionFile_0.teleports.Count;
				dataGridView_2.Refresh();
				method_3();
				dataGridView_2.ClearSelection();
				int index = dataGridView_2.Rows.Count - 1;
				dataGridView_2.Rows[index].Selected = true;
				dataGridView_2.CurrentCell = dataGridView_2.Rows[index].Cells[0];
			}
			catch
			{
			}
		}
	}

	private void dataGridView_2_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (bool_0 && regionFile_0 != null && e.RowIndex >= 0 && e.RowIndex < regionFile_0.teleports.Count)
		{
			int rowIndex = e.RowIndex;
			switch (e.ColumnIndex)
			{
			case 0:
				e.Value = regionFile_0.teleports[rowIndex].m_iType;
				break;
			case 1:
				e.Value = regionFile_0.teleports[rowIndex].m_idSrcInst;
				break;
			case 2:
				e.Value = regionFile_0.teleports[rowIndex].m_idInst;
				break;
			case 3:
				e.Value = regionFile_0.teleports[rowIndex].m_iLevelLmt;
				break;
			case 4:
				e.Value = regionFile_0.teleports[rowIndex].tm_vPos.oX;
				break;
			case 5:
				e.Value = regionFile_0.teleports[rowIndex].tm_vPos.oY;
				break;
			case 6:
				e.Value = regionFile_0.teleports[rowIndex].tm_vPos.oZ;
				break;
			case 7:
				e.Value = regionFile_0.teleports[rowIndex].m_vExts.oX;
				break;
			case 8:
				e.Value = regionFile_0.teleports[rowIndex].m_vExts.oY;
				break;
			case 9:
				e.Value = regionFile_0.teleports[rowIndex].m_vExts.oZ;
				break;
			case 10:
				e.Value = regionFile_0.teleports[rowIndex].m_vTarge.oX;
				break;
			case 11:
				e.Value = regionFile_0.teleports[rowIndex].m_vTarge.oY;
				break;
			case 12:
				e.Value = regionFile_0.teleports[rowIndex].m_vTarge.oZ;
				break;
			}
		}
	}

	private void dataGridView_2_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
	{
		if (!bool_0 || regionFile_0 == null || e.RowIndex < 0 || e.RowIndex >= regionFile_0.teleports.Count)
		{
			return;
		}
		try
		{
			method_18();
			int rowIndex = e.RowIndex;
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
					goto IL_006b;
				}
			}
			obj = Class16.smethod_0(1648924112);
			goto IL_006b;
			IL_006b:
			string text = (string)obj;
			switch (e.ColumnIndex)
			{
			case 0:
				regionFile_0.teleports[rowIndex].m_iType = int.Parse(method_14(text));
				break;
			case 1:
				regionFile_0.teleports[rowIndex].m_idSrcInst = int.Parse(method_14(text));
				break;
			case 2:
				regionFile_0.teleports[rowIndex].m_idInst = int.Parse(method_14(text));
				break;
			case 3:
				regionFile_0.teleports[rowIndex].m_iLevelLmt = int.Parse(method_14(text));
				break;
			case 4:
				regionFile_0.teleports[rowIndex].tm_vPos.oX = text;
				break;
			case 5:
				regionFile_0.teleports[rowIndex].tm_vPos.oY = text;
				break;
			case 6:
				regionFile_0.teleports[rowIndex].tm_vPos.oZ = text;
				break;
			case 7:
				regionFile_0.teleports[rowIndex].m_vExts.oX = text;
				break;
			case 8:
				regionFile_0.teleports[rowIndex].m_vExts.oY = text;
				break;
			case 9:
				regionFile_0.teleports[rowIndex].m_vExts.oZ = text;
				break;
			case 10:
				regionFile_0.teleports[rowIndex].m_vTarge.oX = text;
				break;
			case 11:
				regionFile_0.teleports[rowIndex].m_vTarge.oY = text;
				break;
			case 12:
				regionFile_0.teleports[rowIndex].m_vTarge.oZ = text;
				break;
			}
		}
		catch
		{
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || regionFile_0 == null || dataGridView_2.CurrentCell == null)
		{
			return;
		}
		try
		{
			method_18();
			int rowIndex = dataGridView_2.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < regionFile_0.teleports.Count)
			{
				CELTransportBox item = regionFile_0.teleports[rowIndex].Clone();
				regionFile_0.teleports.Add(item);
				dataGridView_2.RowCount = regionFile_0.teleports.Count;
				dataGridView_2.Refresh();
				method_3();
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

	private void method_13(object sender, EventArgs e)
	{
		if (bool_1 || !bool_0 || regionFile_0 == null || dataGridView_2.CurrentCell == null)
		{
			return;
		}
		try
		{
			method_18();
			int rowIndex = dataGridView_2.CurrentCell.RowIndex;
			if (rowIndex >= 0 && rowIndex < regionFile_0.teleports.Count)
			{
				regionFile_0.teleports.RemoveAt(rowIndex);
				dataGridView_2.RowCount = regionFile_0.teleports.Count;
				dataGridView_2.Refresh();
				method_3();
				if (dataGridView_2.Rows.Count > 0)
				{
					dataGridView_2.ClearSelection();
					int index = Math.Min(rowIndex, dataGridView_2.Rows.Count - 1);
					dataGridView_2.Rows[index].Selected = true;
					dataGridView_2.CurrentCell = dataGridView_2.Rows[index].Cells[0];
				}
			}
		}
		catch
		{
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (!bool_2 && !bool_1 && regionFile_0 != null)
		{
			try
			{
				method_18();
				uint dwVersion = Convert.ToUInt32(textBox_0.Text);
				regionFile_0.dwVersion = dwVersion;
			}
			catch
			{
			}
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (regionFile_0 != null)
		{
			method_18();
			long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			textBox_1.Text = num.ToString();
			regionFile_0.dwTimeStamp = (int)num;
		}
	}

	private string method_14(string string_2)
	{
		if (string.IsNullOrEmpty(string_2))
		{
			return Class16.smethod_0(1648924112);
		}
		string text = string.Empty;
		for (int i = 0; i < string_2.Length; i++)
		{
			char c = string_2[i];
			if (char.IsDigit(c) || c == '-')
			{
				text += c;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		return Class16.smethod_0(1648924112);
	}

	private void method_15()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1649211232), 100);
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_16, method_17);
		fileBasedUndoManager_0.AttachToToolStrip(toolStrip_0, method_20, method_21);
	}

	private byte[] method_16()
	{
		if (regionFile_0 == null)
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
					binaryWriter.Write(regionFile_0.dwVersion);
					binaryWriter.Write(regionFile_0.dwTimeStamp);
					binaryWriter.Write(regionFile_0.encoding?.CodePage ?? 65001);
					binaryWriter.Write(regionFile_0.regions.Count);
					foreach (RegionEntry region in regionFile_0.regions)
					{
						binaryWriter.Write(region.Type);
						binaryWriter.Write(region.Strategy);
						binaryWriter.Write(region.name ?? string.Empty);
						binaryWriter.Write(region.Zones.Count);
						foreach (RegionVector3 zone in region.Zones)
						{
							binaryWriter.Write(zone.oX ?? Class16.smethod_0(1648924112));
							binaryWriter.Write(zone.oY ?? Class16.smethod_0(1648924112));
							binaryWriter.Write(zone.oZ ?? Class16.smethod_0(1648924112));
						}
					}
					binaryWriter.Write(regionFile_0.teleports.Count);
					foreach (CELTransportBox teleport in regionFile_0.teleports)
					{
						binaryWriter.Write(teleport.m_iType);
						binaryWriter.Write(teleport.m_idInst);
						binaryWriter.Write(teleport.m_idSrcInst);
						binaryWriter.Write(teleport.m_iLevelLmt);
						smethod_0(binaryWriter, teleport.tm_vPos);
						smethod_0(binaryWriter, teleport.m_vExts);
						smethod_0(binaryWriter, teleport.m_vTarge);
					}
					binaryWriter.Write(dataGridView_0.CurrentCell?.RowIndex ?? (-1));
					binaryWriter.Write(dataGridView_1.CurrentCell?.RowIndex ?? (-1));
					binaryWriter.Write(dataGridView_2.CurrentCell?.RowIndex ?? (-1));
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
		if (byte_0 == null || byte_0.Length == 0)
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
					if (regionFile_0 == null)
					{
						regionFile_0 = new RegionFile();
					}
					regionFile_0.dwVersion = binaryReader.ReadUInt32();
					regionFile_0.dwTimeStamp = binaryReader.ReadInt32();
					regionFile_0.encoding = Encoding.GetEncoding(binaryReader.ReadInt32());
					int num = binaryReader.ReadInt32();
					regionFile_0.regions = new List<RegionEntry>(num);
					for (int i = 0; i < num; i++)
					{
						RegionEntry regionEntry = new RegionEntry
						{
							Type = binaryReader.ReadInt32(),
							Strategy = binaryReader.ReadInt32(),
							name = binaryReader.ReadString()
						};
						int num2 = binaryReader.ReadInt32();
						regionEntry.Zones = new List<RegionVector3>(num2);
						for (int j = 0; j < num2; j++)
						{
							regionEntry.Zones.Add(new RegionVector3(binaryReader.ReadString(), binaryReader.ReadString(), binaryReader.ReadString()));
						}
						regionFile_0.regions.Add(regionEntry);
					}
					int num3 = binaryReader.ReadInt32();
					regionFile_0.teleports = new List<CELTransportBox>(num3);
					for (int k = 0; k < num3; k++)
					{
						regionFile_0.teleports.Add(new CELTransportBox
						{
							m_iType = binaryReader.ReadInt32(),
							m_idInst = binaryReader.ReadInt32(),
							m_idSrcInst = binaryReader.ReadInt32(),
							m_iLevelLmt = binaryReader.ReadInt32(),
							tm_vPos = smethod_1(binaryReader),
							m_vExts = smethod_1(binaryReader),
							m_vTarge = smethod_1(binaryReader)
						});
					}
					int int_ = binaryReader.ReadInt32();
					int int_2 = binaryReader.ReadInt32();
					int int_3 = binaryReader.ReadInt32();
					bool_0 = true;
					textBox_0.Text = regionFile_0.dwVersion.ToString();
					textBox_1.Text = regionFile_0.dwTimeStamp.ToString();
					dataGridView_0.RowCount = regionFile_0.regions.Count;
					dataGridView_0.Invalidate();
					dataGridView_0.Refresh();
					int_ = smethod_3(int_, dataGridView_0.Rows.Count);
					if (int_ >= 0 && int_ < regionFile_0.regions.Count)
					{
						dataGridView_1.RowCount = regionFile_0.regions[int_].ZoneCount;
					}
					else
					{
						dataGridView_1.RowCount = 0;
					}
					dataGridView_1.Invalidate();
					dataGridView_1.Refresh();
					dataGridView_2.RowCount = regionFile_0.teleports.Count;
					dataGridView_2.Invalidate();
					dataGridView_2.Refresh();
					method_3();
					smethod_2(dataGridView_0, int_);
					smethod_2(dataGridView_1, smethod_3(int_2, dataGridView_1.Rows.Count));
					smethod_2(dataGridView_2, smethod_3(int_3, dataGridView_2.Rows.Count));
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

	private static void smethod_0(BinaryWriter binaryWriter_0, RegionVector3 regionVector3_0)
	{
		object obj;
		if (regionVector3_0 == null)
		{
			obj = null;
		}
		else
		{
			obj = regionVector3_0.oX;
			if (obj != null)
			{
				goto IL_001b;
			}
		}
		obj = Class16.smethod_0(1648924112);
		goto IL_001b;
		IL_003b:
		object obj2;
		binaryWriter_0.Write((string)obj2);
		object obj3;
		if (regionVector3_0 == null)
		{
			obj3 = null;
		}
		else
		{
			obj3 = regionVector3_0.oZ;
			if (obj3 != null)
			{
				goto IL_005b;
			}
		}
		obj3 = Class16.smethod_0(1648924112);
		goto IL_005b;
		IL_005b:
		binaryWriter_0.Write((string)obj3);
		return;
		IL_001b:
		binaryWriter_0.Write((string)obj);
		if (regionVector3_0 == null)
		{
			obj2 = null;
		}
		else
		{
			obj2 = regionVector3_0.oY;
			if (obj2 != null)
			{
				goto IL_003b;
			}
		}
		obj2 = Class16.smethod_0(1648924112);
		goto IL_003b;
	}

	private static RegionVector3 smethod_1(BinaryReader binaryReader_0)
	{
		return new RegionVector3(binaryReader_0.ReadString(), binaryReader_0.ReadString(), binaryReader_0.ReadString());
	}

	private void method_18()
	{
		if (!bool_2 && regionFile_0 != null)
		{
			byte[] array = method_16();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
		}
	}

	private void method_19()
	{
		fileBasedUndoManager_0?.Clear();
	}

	private static void smethod_2(DataGridView dataGridView_3, int int_1)
	{
		dataGridView_3.ClearSelection();
		if (int_1 >= 0 && int_1 < dataGridView_3.Rows.Count)
		{
			dataGridView_3.Rows[int_1].Selected = true;
			dataGridView_3.CurrentCell = dataGridView_3.Rows[int_1].Cells[0];
		}
	}

	private static int smethod_3(int int_1, int int_2)
	{
		if (int_1 >= 0 && int_1 < int_2)
		{
			return int_1;
		}
		return -1;
	}

	private void RegionEditorForm_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_RegionEditorForm != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_RegionEditorForm = CommonStorage.Texts.LangIndex;
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
