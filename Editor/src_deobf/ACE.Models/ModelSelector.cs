using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.NpcGen;
using ACE.Pck;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Models;

public class ModelSelector : Form
{
	public static CommonStorage CStorage;

	public static MODEL_VIEWER ModelViewer;

	public static PCK_LIST PCKs;

	public static ItemsToolTip ItemsToolTip1;

	public DialogResult dialogResult;

	public string currentPath;

	public int currentIndex;

	public int int_0;

	public ItemType listType;

	public GENDER gender;

	public bool dontrefresh;

	private string string_0;

	private string string_1;

	private ColumnHeader columnHeader_0;

	private ComboBox comboBox_0;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private Button button_0;

	private CheckBox checkBox_0;

	private ToolTip toolTip_0;

	private TextBox textBox_0;

	private Button button_1;

	private ComboBox comboBox_1;

	private ListViewEx listViewEx_0;

	private ColumnHeader columnHeader_1;

	private ColumnHeader columnHeader_2;

	private ColumnHeader columnHeader_3;

	private ColumnHeader columnHeader_4;

	private Button button_2;

	private Button button_3;

	private TableLayoutPanel tableLayoutPanel_0;

	private GroupBox groupBox_0;

	private IContainer icontainer_0;

	public ModelSelector()
	{
		try
		{
			method_4();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(listViewEx_0, value: true);
			PCKs = MODEL_VIEWER.PCKs;
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649116953));
			textBox_0.Text = text;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	public void RefreshPckList()
	{
		dontrefresh = true;
		comboBox_1.Items.Clear();
		ComboBox.ObjectCollection items = comboBox_1.Items;
		object[] pckNames = PCKs.GetPckNames();
		items.AddRange(pckNames);
		comboBox_1.Text = ModelViewer.pck_name;
		dontrefresh = false;
	}

	private void method_0()
	{
		int modelsCount = ModelViewer.GetModelsCount();
		if (modelsCount > -1)
		{
			if (modelsCount != listViewEx_0.VirtualListSize)
			{
				listViewEx_0.VirtualListSize = modelsCount;
			}
			else
			{
				listViewEx_0.Refresh();
			}
		}
		GC.KeepAlive(this);
	}

	private void ModelSelector_Load(object sender, EventArgs e)
	{
		if (MODEL_VIEWER.PCKs != null)
		{
			method_0();
		}
		if (CommonStorage.Params.ShowThumbs)
		{
			ICONS icons = DataFiles.Elements.Icons;
			if (icons != null)
			{
				listViewEx_0.SmallImageList = icons.imageList;
			}
		}
		GC.KeepAlive(this);
	}

	public DialogResult ShowDialog(Form owner, string path, int int_1, int int_2, int int_3)
	{
		if (!string.IsNullOrWhiteSpace(path))
		{
			currentPath = PCK.FixPath(path);
		}
		int_0 = int_1;
		eListCollection elements = DataFiles.Elements;
		listType = elements.Lists[int_1].ListType;
		string_0 = null;
		dontrefresh = true;
		ItemType itemType = listType;
		int num;
		if (itemType == ItemType.PW_ARMOR_ESSENCE || itemType == ItemType.PW_NEW_ARMOR_ESSENCE || itemType == ItemType.PW_FASHION_ESSENCE || itemType == ItemType.PW_FASHION2_ESSENCE)
		{
			eList eList2 = DataFiles.Elements.Lists[int_1];
			if (int_3 == eList2.get_fields(Class16.smethod_0(1648960631)))
			{
				num = 1;
				goto IL_0092;
			}
		}
		num = 0;
		goto IL_0092;
		IL_0092:
		if ((byte)num != 0)
		{
			ModelViewer.SetPackage(CommonStorage.AParams.ModelsPckBaseName);
			comboBox_1.Enabled = false;
			comboBox_0.Enabled = true;
			if (int_1 == DataFiles.LI(Class16.smethod_0(1649078890)) || int_1 == DataFiles.LI(Class16.smethod_0(1649078912)))
			{
				int int_4 = DataFiles.Elements.Lists[int_1].get_fields(Class16.smethod_0(1648956046));
				int num2 = (int)(gender = (GENDER)DataFiles.Elements.GetValueI(int_1, int_2, int_4));
				ModelViewer.SetGender((GENDER)num2, bUpdateCache: true);
			}
			comboBox_0.SelectedIndex = (int)gender;
		}
		else
		{
			comboBox_1.Enabled = true;
			comboBox_0.SelectedIndex = -1;
			comboBox_0.Enabled = false;
			string package = CommonStorage.AParams.ModelsPckBaseName;
			if (!string.IsNullOrWhiteSpace(currentPath))
			{
				if (currentPath.Contains(Class16.smethod_0(1648927580)))
				{
					package = ACE.RSGlobal.RSGlobal.GetPathRoot(currentPath);
				}
				ModelViewer.SetPackage(package);
			}
		}
		comboBox_1.Text = ModelViewer.pck_name;
		dontrefresh = false;
		ModelViewer.SetSource(int_1, int_2, int_3);
		checkBox_0.Checked = CommonStorage.Profile.GetSetting(Class16.smethod_0(1649116976), Default: false);
		if (checkBox_0.Checked)
		{
			ModelViewer.FilterPaths();
		}
		if (MODEL_VIEWER.SKIPreview == null || !MODEL_VIEWER.SKIPreview.Visible)
		{
			ModelViewer.Show();
		}
		dialogResult = DialogResult.None;
		ShowDialog(owner);
		return dialogResult;
	}

	private void ModelSelector_Shown(object sender, EventArgs e)
	{
		string modelName = currentPath;
		GENDER modelGender = ModelViewer.GetModelGender(modelName);
		if (modelGender != ModelViewer.gender)
		{
			gender = modelGender;
			ModelViewer.SetGender(modelGender, bUpdateCache: true);
			dontrefresh = true;
			comboBox_0.SelectedIndex = (int)gender;
			dontrefresh = false;
			method_0();
		}
		string modelName2 = currentPath;
		int num = ModelViewer.GetModelIndex(modelName2, bContains: false, 0);
		if (num < 0 && currentIndex > -1)
		{
			int num2 = currentIndex;
			num = ((num2 >= listViewEx_0.VirtualListSize) ? (listViewEx_0.VirtualListSize - 1) : ((num2 > -1) ? num2 : num));
		}
		if (num > -1)
		{
			method_1(num);
		}
		byte b = ((listViewEx_0.SelectedIndices.Count > 0) ? ((byte)1) : ((byte)0));
		button_2.Enabled = b != 0;
		listViewEx_0.Focus();
		GC.KeepAlive(this);
	}

	private void method_1(int int_1)
	{
		if (listViewEx_0 != null && !listViewEx_0.IsDisposed && int_1 > -1 && int_1 < listViewEx_0.VirtualListSize)
		{
			try
			{
				listViewEx_0.Items[int_1].Selected = true;
				listViewEx_0.Items[int_1].Focused = true;
				listViewEx_0.Items[int_1].EnsureVisible();
			}
			catch (InvalidOperationException)
			{
			}
			catch (NullReferenceException)
			{
			}
		}
		GC.KeepAlive(this);
	}

	private void method_2(object sender, EventArgs e)
	{
		if (listViewEx_0.SelectedItems.Count > 0 && listViewEx_0.SelectedItems[0].SubItems.Count > 0)
		{
			CommonStorage.sData = listViewEx_0.SelectedItems[0].SubItems[0].Text;
		}
		dialogResult = DialogResult.Cancel;
		ModelViewer?.HidePreviewWindow(bCloseWindow: true);
		Hide();
	}

	private void method_3()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_4()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(ModelSelector));
		groupBox_0 = new GroupBox();
		checkBox_0 = new CheckBox();
		button_0 = new Button();
		comboBox_0 = new ComboBox();
		comboBox_1 = new ComboBox();
		textBox_0 = new TextBox();
		button_1 = new Button();
		listViewEx_0 = new ListViewEx();
		columnHeader_1 = new ColumnHeader();
		columnHeader_0 = new ColumnHeader();
		columnHeader_3 = new ColumnHeader();
		columnHeader_2 = new ColumnHeader();
		columnHeader_4 = new ColumnHeader();
		contextMenuStrip_0 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		button_2 = new Button();
		button_3 = new Button();
		tableLayoutPanel_0 = new TableLayoutPanel();
		toolTip_0 = new ToolTip(icontainer_0);
		groupBox_0.SuspendLayout();
		contextMenuStrip_0.SuspendLayout();
		tableLayoutPanel_0.SuspendLayout();
		SuspendLayout();
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_0.Controls.Add(checkBox_0);
		groupBox_0.Controls.Add(button_0);
		groupBox_0.Controls.Add(comboBox_0);
		groupBox_0.Controls.Add(comboBox_1);
		groupBox_0.Controls.Add(textBox_0);
		groupBox_0.Controls.Add(button_1);
		groupBox_0.Location = new Point(3, -3);
		groupBox_0.Name = Class16.smethod_0(1648929126);
		groupBox_0.Size = new Size(783, 40);
		groupBox_0.TabIndex = 80;
		groupBox_0.TabStop = false;
		checkBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(635, 14);
		checkBox_0.Name = Class16.smethod_0(1649117001);
		checkBox_0.Size = new Size(113, 17);
		checkBox_0.TabIndex = 143;
		checkBox_0.Text = Class16.smethod_0(1649117025);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_0.Image = Resources.cmdHelp;
		button_0.Location = new Point(753, 12);
		button_0.Name = Class16.smethod_0(1649117048);
		button_0.Size = new Size(28, 22);
		button_0.TabIndex = 138;
		button_0.TextAlign = ContentAlignment.MiddleRight;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Enabled = false;
		comboBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649117070),
			Class16.smethod_0(1649117073)
		});
		comboBox_0.Location = new Point(113, 12);
		comboBox_0.Name = Class16.smethod_0(1649117094);
		comboBox_0.Size = new Size(102, 21);
		comboBox_0.TabIndex = 141;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Location = new Point(5, 12);
		comboBox_1.Name = Class16.smethod_0(1649117110);
		comboBox_1.Size = new Size(102, 21);
		comboBox_1.TabIndex = 139;
		comboBox_1.SelectedIndexChanged += comboBox_1_SelectedIndexChanged;
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.BackColor = Color.White;
		textBox_0.Location = new Point(222, 12);
		textBox_0.Name = Class16.smethod_0(1648919457);
		textBox_0.Size = new Size(332, 22);
		textBox_0.TabIndex = 136;
		textBox_0.Text = Class16.smethod_0(1649117124);
		textBox_0.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(textBox_0, Class16.smethod_0(1649117154));
		textBox_0.Click += textBox_0_Click;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.Enter += textBox_0_Enter;
		textBox_0.Leave += textBox_0_Leave;
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_1.Image = Resources.cmdFindNext;
		button_1.Location = new Point(557, 12);
		button_1.Name = Class16.smethod_0(1649003485);
		button_1.Size = new Size(28, 22);
		button_1.TabIndex = 137;
		button_1.TextAlign = ContentAlignment.MiddleRight;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		listViewEx_0.AllowColumnReorder = true;
		listViewEx_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listViewEx_0.BackColor = Color.FromArgb(32, 32, 32);
		listViewEx_0.BorderStyle = BorderStyle.FixedSingle;
		listViewEx_0.Columns.AddRange(new ColumnHeader[5] { columnHeader_1, columnHeader_0, columnHeader_3, columnHeader_2, columnHeader_4 });
		listViewEx_0.ContextMenuStrip = contextMenuStrip_0;
		listViewEx_0.Cursor = Cursors.Default;
		listViewEx_0.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		listViewEx_0.ForeColor = Color.White;
		listViewEx_0.FullRowSelect = true;
		listViewEx_0.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		listViewEx_0.HideSelection = false;
		listViewEx_0.LabelWrap = false;
		listViewEx_0.Location = new Point(3, 39);
		listViewEx_0.MultiSelect = false;
		listViewEx_0.Name = Class16.smethod_0(1649116197);
		listViewEx_0.ShowGroups = false;
		listViewEx_0.ShowItemToolTips = true;
		listViewEx_0.Size = new Size(783, 500);
		listViewEx_0.TabIndex = 113;
		listViewEx_0.Tag = Class16.smethod_0(1648919381);
		listViewEx_0.UseCompatibleStateImageBehavior = false;
		listViewEx_0.View = View.Details;
		listViewEx_0.VirtualMode = true;
		listViewEx_0.RetrieveVirtualItem += listViewEx_0_RetrieveVirtualItem;
		listViewEx_0.SelectedIndexChanged += listViewEx_0_SelectedIndexChanged;
		listViewEx_0.DoubleClick += listViewEx_0_DoubleClick;
		listViewEx_0.MouseHover += listViewEx_0_MouseHover;
		listViewEx_0.MouseMove += listViewEx_0_MouseMove;
		columnHeader_1.DisplayIndex = 2;
		columnHeader_1.Tag = Class16.smethod_0(1649012442);
		columnHeader_1.Text = Class16.smethod_0(1648936731);
		columnHeader_1.Width = 220;
		columnHeader_0.DisplayIndex = 0;
		columnHeader_0.Text = Class16.smethod_0(1648929947);
		columnHeader_3.DisplayIndex = 1;
		columnHeader_3.Tag = Class16.smethod_0(1648997790);
		columnHeader_3.Text = Class16.smethod_0(1648893060);
		columnHeader_3.Width = 385;
		columnHeader_2.Tag = Class16.smethod_0(1648929955);
		columnHeader_2.Text = Class16.smethod_0(1648941057);
		columnHeader_2.TextAlign = HorizontalAlignment.Center;
		columnHeader_2.Width = 57;
		columnHeader_4.Tag = Class16.smethod_0(1649116203);
		columnHeader_4.Text = Class16.smethod_0(1649116217);
		columnHeader_4.Width = 40;
		contextMenuStrip_0.Items.AddRange(new ToolStripItem[5] { toolStripMenuItem_0, toolStripMenuItem_1, toolStripSeparator_0, toolStripMenuItem_2, toolStripMenuItem_3 });
		contextMenuStrip_0.Name = Class16.smethod_0(1649003266);
		contextMenuStrip_0.Size = new Size(232, 98);
		contextMenuStrip_0.Opening += contextMenuStrip_0_Opening;
		toolStripMenuItem_0.Image = Resources.mnuOk;
		toolStripMenuItem_0.Name = Class16.smethod_0(1649116236);
		toolStripMenuItem_0.Size = new Size(231, 22);
		toolStripMenuItem_0.Text = Class16.smethod_0(1649116240);
		toolStripMenuItem_0.Click += toolStripMenuItem_0_Click;
		toolStripMenuItem_1.Image = Resources.ModelSelector_mnuGoToItem;
		toolStripMenuItem_1.Name = Class16.smethod_0(1648970773);
		toolStripMenuItem_1.Size = new Size(231, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1649116259);
		toolStripMenuItem_1.Visible = false;
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1648920981);
		toolStripSeparator_0.Size = new Size(228, 6);
		toolStripMenuItem_2.Image = Resources.mnuCopyPath;
		toolStripMenuItem_2.Name = Class16.smethod_0(1649116281);
		toolStripMenuItem_2.Size = new Size(231, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1649116299);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.Name = Class16.smethod_0(1649116328);
		toolStripMenuItem_3.Size = new Size(231, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1649116346);
		toolStripMenuItem_3.Visible = false;
		button_2.AutoSize = true;
		button_2.Dock = DockStyle.Fill;
		button_2.Enabled = false;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_2.Image = Resources.ModelSelector_cmdOk;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(3, 3);
		button_2.Name = Class16.smethod_0(1648973834);
		button_2.Size = new Size(388, 42);
		button_2.TabIndex = 114;
		button_2.TabStop = false;
		button_2.Text = Class16.smethod_0(1648919277);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.AutoSize = true;
		button_3.DialogResult = DialogResult.Cancel;
		button_3.Dock = DockStyle.Fill;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_3.Image = Resources.ModelSelector_cmdCancel;
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(397, 3);
		button_3.Name = Class16.smethod_0(1649000848);
		button_3.Size = new Size(388, 42);
		button_3.TabIndex = 115;
		button_3.TabStop = false;
		button_3.Text = Class16.smethod_0(1648989215);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		tableLayoutPanel_0.ColumnCount = 2;
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel_0.Controls.Add(button_2, 0, 0);
		tableLayoutPanel_0.Controls.Add(button_3, 1, 0);
		tableLayoutPanel_0.Dock = DockStyle.Bottom;
		tableLayoutPanel_0.Location = new Point(0, 542);
		tableLayoutPanel_0.Name = Class16.smethod_0(1648929366);
		tableLayoutPanel_0.RowCount = 1;
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
		tableLayoutPanel_0.Size = new Size(788, 48);
		tableLayoutPanel_0.TabIndex = 116;
		base.AcceptButton = button_2;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_3;
		base.ClientSize = new Size(788, 590);
		base.Controls.Add(tableLayoutPanel_0);
		base.Controls.Add(listViewEx_0);
		base.Controls.Add(groupBox_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.Icon = Resources.ModelSelector_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649116389);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649116240);
		base.FormClosing += ModelSelector_FormClosing;
		base.Load += ModelSelector_Load;
		base.Shown += ModelSelector_Shown;
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		contextMenuStrip_0.ResumeLayout(performLayout: false);
		tableLayoutPanel_0.ResumeLayout(performLayout: false);
		tableLayoutPanel_0.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_3();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void ModelSelector_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (method_8(out var int_))
		{
			currentIndex = int_;
			currentPath = ModelViewer.GetModelName(int_) ?? string.Empty;
		}
		ModelViewer?.HidePreviewWindow(bCloseWindow: true);
		object value = checkBox_0.Checked;
		SettingsClass profile = CommonStorage.Profile;
		profile.SaveSetting(profile.DefaultSection, Class16.smethod_0(1649116976), value);
		Hide();
		e.Cancel = true;
		GC.KeepAlive(this);
	}

	private void listViewEx_0_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		if (e != null && ModelViewer != null)
		{
			int num = int_0;
			e.Item = ModelViewer.CreateListViewItem(e.ItemIndex, num);
			GC.KeepAlive(this);
		}
	}

	private void listViewEx_0_MouseMove(object sender, MouseEventArgs e)
	{
		if (listViewEx_0 != null && !listViewEx_0.IsDisposed && ModelViewer != null)
		{
			ListViewItem itemAt = listViewEx_0.GetItemAt(e.X, e.Y);
			if (itemAt != null && itemAt.Index >= 0 && itemAt.Index < listViewEx_0.VirtualListSize && itemAt.Index < ModelViewer.GetModelsCount())
			{
				string_1 = ModelViewer.GetModelName(itemAt.Index);
				if (string.IsNullOrEmpty(string_1))
				{
					GC.KeepAlive(this);
				}
				else if (e.Button == MouseButtons.Right)
				{
					ITEMPOS itemPos = null;
					if (itemAt.Tag != null)
					{
						itemPos = (ITEMPOS)itemAt.Tag;
					}
					if (string_0 != string_1)
					{
						string modelName = string_1;
						ModelViewer.ShowModelPreview(modelName, itemPos, itemAt.Index);
					}
					string_0 = string_1;
				}
			}
			else
			{
				GC.KeepAlive(this);
			}
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private void listViewEx_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_7();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_5();
	}

	private void method_5()
	{
		if (method_8(out var int_))
		{
			string modelName = ModelViewer.GetModelName(int_);
			if (!string.IsNullOrEmpty(modelName))
			{
				CommonStorage.sData = modelName;
			}
			CommonStorage.iData = comboBox_0.SelectedIndex;
			dialogResult = DialogResult.OK;
		}
		ModelViewer?.HidePreviewWindow(bCloseWindow: true);
		Hide();
	}

	private void listViewEx_0_DoubleClick(object sender, EventArgs e)
	{
		method_5();
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		_ = textBox_0.TextLength;
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		int num = 0;
		if (method_8(out var int_))
		{
			num = int_;
		}
		method_6(num + 1);
	}

	private void method_6(int int_1)
	{
		List<vITEMPOS> list = null;
		if (MODEL_VIEWER.CurrentPck == null || !MODEL_VIEWER.CurrentPck.FileLoaded)
		{
			return;
		}
		int num = 0;
		int num2 = -1;
		string text = textBox_0.Text;
		if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
		{
			num = Convert.ToInt32(text);
			if (num > 0 && num < ModelViewer.Paths.Count)
			{
				num2 = num;
				goto IL_017f;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			num2 = ModelViewer.GetModelIndex(text, bContains: true, int_1);
			if (num2 >= 0)
			{
				goto IL_017f;
			}
		}
		int count = ModelViewer.Paths.Count;
		int num3 = int_1;
		if (int_1 >= count)
		{
			goto IL_017f;
		}
		while (true)
		{
			string key = ModelViewer.Paths[num3];
			list = null;
			if (!string.IsNullOrEmpty(text))
			{
				if (MODEL_VIEWER.ModelsCache.TryGetValue(key, out list))
				{
					int count2 = list.Count;
					int num4 = 0;
					if (0 < count2)
					{
						do
						{
							vITEMPOS vITEMPOS2 = list[num4];
							ITEMPOS iTEMPOS = new ITEMPOS(vITEMPOS2.Int32_1, vITEMPOS2.Int32_0);
							if (DataFiles.Elements.IsItemExist(iTEMPOS))
							{
								if (num > 0)
								{
									if (DataFiles.Elements.getid(iTEMPOS.int_0, iTEMPOS.int_1) == num)
									{
										num2 = num3;
										break;
									}
								}
								else if (ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(DataFiles.Elements.GetParsedItemName(iTEMPOS), text))
								{
									num2 = num3;
									break;
								}
							}
							num4++;
						}
						while (num4 < count2);
					}
				}
			}
			else
			{
				num2 = ((!MODEL_VIEWER.ModelsCache.ContainsKey(key)) ? num3 : num2);
			}
			if (num2 > -1)
			{
				break;
			}
			num3++;
			if (num3 < count)
			{
				continue;
			}
			goto IL_017f;
		}
		goto IL_01c2;
		IL_0200:
		GC.KeepAlive(this);
		return;
		IL_01c2:
		Color backColor = (TDark.IsDarkMode ? Color.FromArgb(30, 60, 60) : Color.FromArgb(220, 255, 255));
		textBox_0.BackColor = backColor;
		method_1(num2);
		goto IL_0200;
		IL_017f:
		if (num2 > -1)
		{
			goto IL_01c2;
		}
		if (int_1 != 0)
		{
			method_6(0);
		}
		else
		{
			Color backColor2 = (TDark.IsDarkMode ? Color.FromArgb(100, 30, 30) : Color.FromArgb(255, 100, 100));
			textBox_0.BackColor = backColor2;
		}
		goto IL_0200;
	}

	private void textBox_0_Enter(object sender, EventArgs e)
	{
		base.AcceptButton = button_1;
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649116953));
		if (textBox_0.Text == text)
		{
			textBox_0.SelectAll();
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
		base.AcceptButton = button_2;
	}

	private void method_7()
	{
		if (ModelViewer != null && listViewEx_0 != null && !listViewEx_0.IsDisposed)
		{
			if (method_8(out var int_))
			{
				button_2.Enabled = true;
				string modelName = ModelViewer.GetModelName(int_);
				ITEMPOS itemPos = method_9(int_);
				ModelViewer.ShowModelPreview(modelName, itemPos, int_);
			}
			else
			{
				button_2.Enabled = false;
			}
			GC.KeepAlive(this);
		}
		else
		{
			button_2.Enabled = false;
			GC.KeepAlive(this);
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!dontrefresh && comboBox_0.SelectedIndex > -1)
		{
			string text = null;
			if (method_8(out var int_))
			{
				text = ModelViewer.GetModelName(int_);
			}
			int num = (int)(gender = (GENDER)comboBox_0.SelectedIndex);
			ModelViewer.SetGender((GENDER)num, bUpdateCache: true);
			method_0();
			if (text != null)
			{
				int modelIndex = ModelViewer.GetModelIndex(text, bContains: false, 0);
				modelIndex = ((modelIndex >= 0) ? modelIndex : 0);
				method_1(modelIndex);
			}
			listViewEx_0.Focus();
			ModelViewer.LastShowedModel = null;
			method_7();
		}
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!dontrefresh)
		{
			ComboBox comboBox = comboBox_1;
			ModelViewer.SetPackage(comboBox.Text);
			method_0();
			if (listViewEx_0.Items.Count > 0)
			{
				method_1(0);
			}
			listViewEx_0.Focus();
			method_7();
		}
	}

	private void contextMenuStrip_0_Opening(object sender, CancelEventArgs e)
	{
		if (method_8(out var int_))
		{
			contextMenuStrip_0.Enabled = true;
			byte b = ((method_9(int_) != null) ? ((byte)1) : ((byte)0));
			toolStripMenuItem_1.Visible = b != 0;
		}
		else
		{
			contextMenuStrip_0.Enabled = false;
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		method_5();
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		if (method_8(out var int_))
		{
			ITEMPOS iTEMPOS = method_9(int_);
			if (iTEMPOS != null)
			{
				CommonStorage.oData = iTEMPOS;
				dialogResult = DialogResult.Retry;
				Hide();
			}
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		if (method_8(out var int_))
		{
			string text = ModelViewer.GetModelName(int_);
			if (ModelViewer.model_type == MODEL_TYPE.FASHION)
			{
				text = ModelViewer.ArmorPath + text;
			}
			ACE.RSGlobal.RSGlobal.CtrlC(text);
		}
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(680, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void textBox_0_Click(object sender, EventArgs e)
	{
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649116953));
		if (textBox_0.Text == text)
		{
			textBox_0.SelectAll();
		}
		GC.KeepAlive(this);
	}

	private void listViewEx_0_MouseHover(object sender, EventArgs e)
	{
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		string text = null;
		if (method_8(out var int_))
		{
			text = ModelViewer.GetModelName(int_);
		}
		if (checkBox_0.Checked)
		{
			ModelViewer.FilterPaths();
		}
		else
		{
			MODEL_VIEWER modelViewer = ModelViewer;
			modelViewer.SetModelType(modelViewer.model_type);
		}
		method_0();
		if (text != null)
		{
			int modelIndex = ModelViewer.GetModelIndex(text, bContains: false, 0);
			modelIndex = ((modelIndex >= 0) ? modelIndex : 0);
			method_1(modelIndex);
		}
		listViewEx_0.Focus();
		GC.KeepAlive(this);
	}

	private bool method_8(out int int_1)
	{
		int_1 = -1;
		if (listViewEx_0 != null && !listViewEx_0.IsDisposed && ModelViewer != null && listViewEx_0.SelectedIndices.Count != 0)
		{
			int num = listViewEx_0.SelectedIndices[0];
			if (num >= 0 && num < listViewEx_0.VirtualListSize && num < ModelViewer.GetModelsCount())
			{
				int_1 = num;
				return true;
			}
			return false;
		}
		return false;
	}

	private ITEMPOS method_9(int int_1)
	{
		if (listViewEx_0 != null && !listViewEx_0.IsDisposed && int_1 >= 0 && int_1 < listViewEx_0.VirtualListSize)
		{
			try
			{
				if (listViewEx_0.SelectedItems.Count > 0 && listViewEx_0.SelectedItems[0] != null && listViewEx_0.SelectedItems[0].Index == int_1)
				{
					return listViewEx_0.SelectedItems[0].Tag as ITEMPOS;
				}
				return listViewEx_0.Items[int_1]?.Tag as ITEMPOS;
			}
			catch (ArgumentOutOfRangeException)
			{
				return null;
			}
			catch (InvalidOperationException)
			{
				return null;
			}
		}
		return null;
	}
}
