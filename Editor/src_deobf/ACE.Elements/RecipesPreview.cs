using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.License;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.Settings;

namespace ACE.Elements;

public class RecipesPreview : Form
{
	public static bool TabsPaused;

	public int CraftSkillID;

	public int InitStageIndex;

	public bool norefresh;

	public ITEMPOS SelectedCellItem;

	public CommonStorage CStorage;

	public ITEMPOS ServicePos;

	public ICONS Icons;

	public ItemsToolTip ItemsToolTip1;

	public ItemsWindow ItemsWindow1;

	public ACE.Elements.eListCollection.eListCollection eLC;

	public int SelectedTabIndex;

	public bool bRecipesPW;

	private static bool bool_0;

	protected bool IsRequeiredItemsContext;

	protected bool IsResultItemContext;

	private bool bool_1;

	private static bool bool_2;

	private ITEMPOS_f itempos_f_0;

	private bool bool_3;

	private static bool bool_4;

	private int int_0;

	private bool bool_5;

	private PictureBox pictureBox_0;

	private PictureBox pictureBox_1;

	private PictureBox pictureBox_2;

	private Panel panel_0;

	public PictureBox SelectedCell;

	public Form ElementsWindow;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	private Label label_6;

	private Label label_7;

	private Label label_8;

	private Label label_9;

	private Label label_10;

	private Label label_11;

	private Label label_12;

	private Label label_13;

	private Label label_14;

	private Label label_15;

	private PictureBox pictureBox_3;

	private Label label_16;

	private Label label_17;

	private Label label_18;

	private PictureBox pictureBox_4;

	private PictureBox pictureBox_5;

	private PictureBox pictureBox_6;

	private PictureBox pictureBox_7;

	private PictureBox pictureBox_8;

	private PictureBox pictureBox_9;

	private PictureBox pictureBox_10;

	private PictureBox pictureBox_11;

	private PictureBox pictureBox_12;

	private PictureBox pictureBox_13;

	private PictureBox pictureBox_14;

	private PictureBox pictureBox_15;

	private PictureBox pictureBox_16;

	private PictureBox pictureBox_17;

	private PictureBox pictureBox_18;

	private PictureBox pictureBox_19;

	private PictureBox pictureBox_20;

	private PictureBox pictureBox_21;

	private PictureBox pictureBox_22;

	private PictureBox pictureBox_23;

	private PictureBox pictureBox_24;

	private PictureBox pictureBox_25;

	private PictureBox pictureBox_26;

	private PictureBox pictureBox_27;

	private PictureBox pictureBox_28;

	private PictureBox pictureBox_29;

	private PictureBox pictureBox_30;

	private PictureBox pictureBox_31;

	private PictureBox pictureBox_32;

	private PictureBox pictureBox_33;

	private PictureBox pictureBox_34;

	private PictureBox pictureBox_35;

	private PictureBox pictureBox_36;

	private PictureBox pictureBox_37;

	private PictureBox pictureBox_38;

	private PictureBox pictureBox_39;

	private PictureBox pictureBox_40;

	private PictureBox pictureBox_41;

	private PictureBox pictureBox_42;

	private PictureBox pictureBox_43;

	private PictureBox pictureBox_44;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private TextBox textBox_4;

	private TextBox textBox_5;

	private TextBox textBox_6;

	private TextBox textBox_7;

	private Label label_19;

	private Label label_20;

	private TextBox textBox_8;

	private TextBox textBox_9;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripMenuItem toolStripMenuItem_5;

	private PictureBox pictureBox_45;

	private PictureBox pictureBox_46;

	private PictureBox pictureBox_47;

	private PictureBox pictureBox_48;

	private PictureBox pictureBox_49;

	private Timer timer_0;

	private ToolStripSeparator toolStripSeparator_0;

	private TextBox textBox_10;

	private Label label_21;

	private Label label_22;

	private Label label_23;

	private ToolTip toolTip_0;

	public Label SelectedTab;

	private NumericUpDown numericUpDown_0;

	private NumericUpDown numericUpDown_1;

	private PictureBox pictureBox_50;

	public ItemType ListType;

	private Panel panel_1;

	private Panel panel_2;

	private PictureBox pictureBox_51;

	private Button button_0;

	private IContainer icontainer_0;

	private Point point_0;

	protected PictureBox ContextCell;

	public PictureBox PrevCell;

	public Image PrevCellImage;

	private PictureBox pictureBox_52;

	private Image image_0;

	private Font font_0 = new Font(Class16.smethod_0(1648942905), 9.5f, FontStyle.Bold);

	private Font font_1 = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);

	protected override bool ShowWithoutActivation
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return true;
		}
	}

	public RecipesPreview(CommonStorage ref_CStorage, ICONS Icons, ItemsToolTip ItemsToolTip1, ItemsWindow ItemsWindow1, Form ElementsWindow)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			CStorage = ref_CStorage;
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			this.ElementsWindow = ElementsWindow;
			this.Icons = Icons;
			this.ItemsToolTip1 = ItemsToolTip1;
			this.ItemsWindow1 = ItemsWindow1;
			new ElipseFormAngles(this);
			Cursor = CommonStorage.PWCursor1;
			SelectedTabIndex = -1;
			norefresh = false;
			int num = 0;
			do
			{
				int num2 = num;
				string text = Class16.smethod_0(1648971648);
				string text2 = Class16.smethod_0(1648971657);
				((PictureBox)panel_1.Controls[text2 + num2.ToString(text)]).AllowDrop = true;
				num++;
			}
			while (num < 32);
			int num3 = 0;
			do
			{
				string text3 = Class16.smethod_0(1648894096);
				((Label)panel_1.Controls[text3 + num3]).AllowDrop = true;
				num3++;
			}
			while (num3 < 8);
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	public void CreatePreview(ITEMPOS ip, int TabIndex)
	{
		if (ip != null && ip.int_1 >= 0 && ip.int_1 < eLC.GetItemsCount(ip.int_0))
		{
			int num = 0;
			int num2 = 2;
			if (2 < eLC.GetFieldsCount(ip.int_0))
			{
				do
				{
					if (eLC.Lists[ip.int_0].elementTypes[num2].StartsWith(Class16.smethod_0(1648902778)))
					{
						string text = Class16.smethod_0(1648894096);
						Label label = (Label)panel_1.Controls[text + num];
						string value = eLC.GetValue(ip.int_0, ip.int_1, num2);
						label.Text = value;
						if (label.Text.Length > 7)
						{
							label.Text = label.Text.Substring(0, 7);
						}
						label.Tag = num2;
						num++;
					}
					num2++;
				}
				while (num2 < eLC.GetFieldsCount(ip.int_0));
			}
			if (((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix) != Class16.smethod_0(1648932072))
			{
				label_22.Visible = true;
			}
			ServicePos = ip;
			ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC;
			ItemType itemType = (ListType = eListCollection2.Lists[ip.int_0].ListType);
			int num3 = ((eListCollection2.Game == GAMES.PW && itemType == ItemType.PW_NPC_MAKE_SERVICE) ? 1 : 0);
			byte b = (byte)num3;
			bRecipesPW = b != 0;
			if (b != 0)
			{
				ACE.Elements.eList.eList eList2 = eListCollection2.Lists[ip.int_0];
				ITEMPOS servicePos = ServicePos;
				int int_ = servicePos.int_1;
				int num4 = servicePos.int_0;
				int num5 = (CraftSkillID = eLC.GetValueI(num4, int_, eList2.get_fields(Class16.smethod_0(1648971676))));
				if (num5 > 0)
				{
					decimal value2 = num5;
					label_20.Text = eLC.DecodedValues.DecodeValue(23, value2);
				}
				else
				{
					label_20.Text = string.Empty;
					label_19.Text = string.Empty;
				}
				label_23.Visible = false;
			}
			else
			{
				label_20.Text = string.Empty;
				label_19.Text = string.Empty;
				label_22.Visible = true;
				label_23.Visible = true;
			}
			int num6 = 4;
			do
			{
				string text2 = Class16.smethod_0(1648894096);
				Label label2 = (Label)panel_1.Controls[text2 + num6];
				if (eLC.Game != GAMES.JD || ServicePos.int_0 != 95)
				{
					label2.Enabled = true;
				}
				else
				{
					label2.Text = string.Empty;
					label2.Enabled = false;
				}
				num6++;
			}
			while (num6 < 8);
			method_4(TabIndex);
			InitStageIndex = eLC.ActionsHistory.CurrentStageIndex;
		}
		else if (base.Visible)
		{
			Close();
		}
	}

	private void RecipesPreview_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing)
		{
			CommonStorage.Params.ShowMainPreviewWindow = false;
		}
		Hide();
		e.Cancel = true;
		GC.KeepAlive(this);
	}

	private void RecipesPreview_MouseDown(object sender, MouseEventArgs e)
	{
		_ = Cursor;
		Point position = Cursor.Position;
		point_0 = position;
		bool_0 = true;
		GC.KeepAlive(this);
	}

	private void RecipesPreview_MouseUp(object sender, MouseEventArgs e)
	{
		bool_0 = false;
	}

	private void method_0()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(RecipesPreview));
		pictureBox_51 = new PictureBox();
		button_0 = new Button();
		panel_1 = new Panel();
		textBox_10 = new TextBox();
		pictureBox_20 = new PictureBox();
		contextMenuStrip_0 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		pictureBox_21 = new PictureBox();
		pictureBox_22 = new PictureBox();
		pictureBox_23 = new PictureBox();
		pictureBox_24 = new PictureBox();
		pictureBox_25 = new PictureBox();
		pictureBox_26 = new PictureBox();
		pictureBox_27 = new PictureBox();
		pictureBox_28 = new PictureBox();
		pictureBox_29 = new PictureBox();
		pictureBox_30 = new PictureBox();
		pictureBox_31 = new PictureBox();
		pictureBox_32 = new PictureBox();
		pictureBox_33 = new PictureBox();
		pictureBox_34 = new PictureBox();
		pictureBox_35 = new PictureBox();
		pictureBox_5 = new PictureBox();
		pictureBox_6 = new PictureBox();
		pictureBox_7 = new PictureBox();
		pictureBox_8 = new PictureBox();
		pictureBox_9 = new PictureBox();
		pictureBox_10 = new PictureBox();
		pictureBox_11 = new PictureBox();
		pictureBox_12 = new PictureBox();
		pictureBox_13 = new PictureBox();
		pictureBox_14 = new PictureBox();
		pictureBox_15 = new PictureBox();
		pictureBox_16 = new PictureBox();
		pictureBox_17 = new PictureBox();
		pictureBox_18 = new PictureBox();
		pictureBox_19 = new PictureBox();
		pictureBox_4 = new PictureBox();
		label_2 = new Label();
		label_3 = new Label();
		label_4 = new Label();
		label_5 = new Label();
		label_6 = new Label();
		label_7 = new Label();
		label_1 = new Label();
		label_0 = new Label();
		pictureBox_46 = new PictureBox();
		panel_0 = new Panel();
		numericUpDown_1 = new NumericUpDown();
		pictureBox_50 = new PictureBox();
		numericUpDown_0 = new NumericUpDown();
		pictureBox_3 = new PictureBox();
		textBox_9 = new TextBox();
		textBox_8 = new TextBox();
		label_19 = new Label();
		label_20 = new Label();
		textBox_1 = new TextBox();
		textBox_2 = new TextBox();
		textBox_3 = new TextBox();
		textBox_4 = new TextBox();
		textBox_5 = new TextBox();
		textBox_6 = new TextBox();
		textBox_7 = new TextBox();
		textBox_0 = new TextBox();
		pictureBox_44 = new PictureBox();
		pictureBox_40 = new PictureBox();
		pictureBox_41 = new PictureBox();
		pictureBox_42 = new PictureBox();
		pictureBox_43 = new PictureBox();
		pictureBox_38 = new PictureBox();
		pictureBox_39 = new PictureBox();
		pictureBox_36 = new PictureBox();
		pictureBox_37 = new PictureBox();
		label_15 = new Label();
		label_12 = new Label();
		label_10 = new Label();
		label_11 = new Label();
		pictureBox_48 = new PictureBox();
		label_23 = new Label();
		panel_2 = new Panel();
		label_13 = new Label();
		label_14 = new Label();
		pictureBox_47 = new PictureBox();
		pictureBox_0 = new PictureBox();
		pictureBox_1 = new PictureBox();
		pictureBox_2 = new PictureBox();
		label_8 = new Label();
		label_9 = new Label();
		label_16 = new Label();
		label_17 = new Label();
		label_18 = new Label();
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		toolStripMenuItem_5 = new ToolStripMenuItem();
		pictureBox_45 = new PictureBox();
		pictureBox_49 = new PictureBox();
		timer_0 = new Timer(icontainer_0);
		label_21 = new Label();
		label_22 = new Label();
		toolTip_0 = new ToolTip(icontainer_0);
		((ISupportInitialize)pictureBox_51).BeginInit();
		panel_1.SuspendLayout();
		((ISupportInitialize)pictureBox_20).BeginInit();
		contextMenuStrip_0.SuspendLayout();
		((ISupportInitialize)pictureBox_21).BeginInit();
		((ISupportInitialize)pictureBox_22).BeginInit();
		((ISupportInitialize)pictureBox_23).BeginInit();
		((ISupportInitialize)pictureBox_24).BeginInit();
		((ISupportInitialize)pictureBox_25).BeginInit();
		((ISupportInitialize)pictureBox_26).BeginInit();
		((ISupportInitialize)pictureBox_27).BeginInit();
		((ISupportInitialize)pictureBox_28).BeginInit();
		((ISupportInitialize)pictureBox_29).BeginInit();
		((ISupportInitialize)pictureBox_30).BeginInit();
		((ISupportInitialize)pictureBox_31).BeginInit();
		((ISupportInitialize)pictureBox_32).BeginInit();
		((ISupportInitialize)pictureBox_33).BeginInit();
		((ISupportInitialize)pictureBox_34).BeginInit();
		((ISupportInitialize)pictureBox_35).BeginInit();
		((ISupportInitialize)pictureBox_5).BeginInit();
		((ISupportInitialize)pictureBox_6).BeginInit();
		((ISupportInitialize)pictureBox_7).BeginInit();
		((ISupportInitialize)pictureBox_8).BeginInit();
		((ISupportInitialize)pictureBox_9).BeginInit();
		((ISupportInitialize)pictureBox_10).BeginInit();
		((ISupportInitialize)pictureBox_11).BeginInit();
		((ISupportInitialize)pictureBox_12).BeginInit();
		((ISupportInitialize)pictureBox_13).BeginInit();
		((ISupportInitialize)pictureBox_14).BeginInit();
		((ISupportInitialize)pictureBox_15).BeginInit();
		((ISupportInitialize)pictureBox_16).BeginInit();
		((ISupportInitialize)pictureBox_17).BeginInit();
		((ISupportInitialize)pictureBox_18).BeginInit();
		((ISupportInitialize)pictureBox_19).BeginInit();
		((ISupportInitialize)pictureBox_4).BeginInit();
		((ISupportInitialize)pictureBox_46).BeginInit();
		panel_0.SuspendLayout();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		((ISupportInitialize)pictureBox_50).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)pictureBox_3).BeginInit();
		((ISupportInitialize)pictureBox_44).BeginInit();
		((ISupportInitialize)pictureBox_40).BeginInit();
		((ISupportInitialize)pictureBox_41).BeginInit();
		((ISupportInitialize)pictureBox_42).BeginInit();
		((ISupportInitialize)pictureBox_43).BeginInit();
		((ISupportInitialize)pictureBox_38).BeginInit();
		((ISupportInitialize)pictureBox_39).BeginInit();
		((ISupportInitialize)pictureBox_36).BeginInit();
		((ISupportInitialize)pictureBox_37).BeginInit();
		((ISupportInitialize)pictureBox_48).BeginInit();
		panel_2.SuspendLayout();
		((ISupportInitialize)pictureBox_47).BeginInit();
		((ISupportInitialize)pictureBox_0).BeginInit();
		((ISupportInitialize)pictureBox_1).BeginInit();
		((ISupportInitialize)pictureBox_2).BeginInit();
		menuStrip_0.SuspendLayout();
		((ISupportInitialize)pictureBox_45).BeginInit();
		((ISupportInitialize)pictureBox_49).BeginInit();
		SuspendLayout();
		pictureBox_51.Image = Resources.EmptyCell;
		Point location = new Point(308, 137);
		pictureBox_51.Location = location;
		pictureBox_51.Name = Class16.smethod_0(1648971688);
		Size size = new Size(32, 32);
		pictureBox_51.Size = size;
		pictureBox_51.TabIndex = 3;
		pictureBox_51.TabStop = false;
		pictureBox_51.Visible = false;
		Point location2 = new Point(28, 77);
		button_0.Location = location2;
		button_0.Name = Class16.smethod_0(1648991094);
		Size size2 = new Size(63, 20);
		button_0.Size = size2;
		button_0.TabIndex = 6;
		button_0.Text = Class16.smethod_0(1648991094);
		button_0.UseVisualStyleBackColor = true;
		panel_1.AllowDrop = true;
		panel_1.BackgroundImageLayout = ImageLayout.None;
		TextBox value = textBox_10;
		panel_1.Controls.Add(value);
		PictureBox value2 = pictureBox_20;
		panel_1.Controls.Add(value2);
		PictureBox value3 = pictureBox_21;
		panel_1.Controls.Add(value3);
		PictureBox value4 = pictureBox_22;
		panel_1.Controls.Add(value4);
		PictureBox value5 = pictureBox_23;
		panel_1.Controls.Add(value5);
		PictureBox value6 = pictureBox_24;
		panel_1.Controls.Add(value6);
		PictureBox value7 = pictureBox_25;
		panel_1.Controls.Add(value7);
		PictureBox value8 = pictureBox_26;
		panel_1.Controls.Add(value8);
		PictureBox value9 = pictureBox_27;
		panel_1.Controls.Add(value9);
		PictureBox value10 = pictureBox_28;
		panel_1.Controls.Add(value10);
		PictureBox value11 = pictureBox_29;
		panel_1.Controls.Add(value11);
		PictureBox value12 = pictureBox_30;
		panel_1.Controls.Add(value12);
		PictureBox value13 = pictureBox_31;
		panel_1.Controls.Add(value13);
		PictureBox value14 = pictureBox_32;
		panel_1.Controls.Add(value14);
		PictureBox value15 = pictureBox_33;
		panel_1.Controls.Add(value15);
		PictureBox value16 = pictureBox_34;
		panel_1.Controls.Add(value16);
		PictureBox value17 = pictureBox_35;
		panel_1.Controls.Add(value17);
		PictureBox value18 = pictureBox_5;
		panel_1.Controls.Add(value18);
		PictureBox value19 = pictureBox_6;
		panel_1.Controls.Add(value19);
		PictureBox value20 = pictureBox_7;
		panel_1.Controls.Add(value20);
		PictureBox value21 = pictureBox_8;
		panel_1.Controls.Add(value21);
		PictureBox value22 = pictureBox_9;
		panel_1.Controls.Add(value22);
		PictureBox value23 = pictureBox_10;
		panel_1.Controls.Add(value23);
		PictureBox value24 = pictureBox_11;
		panel_1.Controls.Add(value24);
		PictureBox value25 = pictureBox_12;
		panel_1.Controls.Add(value25);
		PictureBox value26 = pictureBox_13;
		panel_1.Controls.Add(value26);
		PictureBox value27 = pictureBox_14;
		panel_1.Controls.Add(value27);
		PictureBox value28 = pictureBox_15;
		panel_1.Controls.Add(value28);
		PictureBox value29 = pictureBox_16;
		panel_1.Controls.Add(value29);
		PictureBox value30 = pictureBox_17;
		panel_1.Controls.Add(value30);
		PictureBox value31 = pictureBox_18;
		panel_1.Controls.Add(value31);
		PictureBox value32 = pictureBox_19;
		panel_1.Controls.Add(value32);
		PictureBox value33 = pictureBox_4;
		panel_1.Controls.Add(value33);
		Label value34 = label_2;
		panel_1.Controls.Add(value34);
		Label value35 = label_3;
		panel_1.Controls.Add(value35);
		Label value36 = label_4;
		panel_1.Controls.Add(value36);
		Label value37 = label_5;
		panel_1.Controls.Add(value37);
		Label value38 = label_6;
		panel_1.Controls.Add(value38);
		Label value39 = label_7;
		panel_1.Controls.Add(value39);
		Label value40 = label_1;
		panel_1.Controls.Add(value40);
		Label value41 = label_0;
		panel_1.Controls.Add(value41);
		PictureBox value42 = pictureBox_46;
		panel_1.Controls.Add(value42);
		Point location3 = new Point(13, 58);
		panel_1.Location = location3;
		panel_1.Name = Class16.smethod_0(1648971704);
		Size size3 = new Size(299, 200);
		panel_1.Size = size3;
		panel_1.TabIndex = 7;
		panel_1.MouseDown += RecipesPreview_MouseDown;
		panel_1.MouseMove += RecipesPreview_MouseMove;
		panel_1.MouseUp += RecipesPreview_MouseUp;
		textBox_10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Color backColor = Color.FromArgb(20, 30, 37);
		textBox_10.BackColor = backColor;
		textBox_10.BorderStyle = BorderStyle.FixedSingle;
		textBox_10.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		Color foreColor = Color.FromArgb(239, 191, 72);
		textBox_10.ForeColor = foreColor;
		Point location4 = new Point(176, 34);
		textBox_10.Location = location4;
		textBox_10.MaxLength = 7;
		textBox_10.Name = Class16.smethod_0(1648971722);
		Size size4 = new Size(72, 22);
		textBox_10.Size = size4;
		textBox_10.TabIndex = 0;
		textBox_10.Text = Class16.smethod_0(1648971739);
		textBox_10.TextAlign = HorizontalAlignment.Center;
		textBox_10.Visible = false;
		textBox_10.KeyUp += textBox_10_KeyUp;
		textBox_10.Leave += textBox_10_Leave;
		pictureBox_20.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_20.Image = Resources.cell31;
		Point location5 = new Point(254, 160);
		pictureBox_20.Location = location5;
		pictureBox_20.Name = Class16.smethod_0(1648971754);
		Size size5 = new Size(32, 32);
		pictureBox_20.Size = size5;
		pictureBox_20.TabIndex = 48;
		pictureBox_20.TabStop = false;
		pictureBox_20.Click += pictureBox_4_Click;
		pictureBox_20.DragDrop += pictureBox_4_DragDrop;
		pictureBox_20.DragEnter += pictureBox_4_DragEnter;
		pictureBox_20.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_20.MouseDown += pictureBox_4_MouseDown;
		pictureBox_20.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_20.MouseHover += pictureBox_4_MouseHover;
		pictureBox_20.MouseMove += pictureBox_4_MouseMove;
		pictureBox_20.MouseUp += pictureBox_37_MouseUp;
		Color backColor2 = Color.FromArgb(32, 32, 32);
		contextMenuStrip_0.BackColor = backColor2;
		contextMenuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		ToolStripItem[] toolStripItems = new ToolStripItem[5] { toolStripMenuItem_0, toolStripSeparator_0, toolStripMenuItem_2, toolStripMenuItem_1, toolStripMenuItem_3 };
		contextMenuStrip_0.Items.AddRange(toolStripItems);
		contextMenuStrip_0.Name = Class16.smethod_0(1648971775);
		contextMenuStrip_0.RenderMode = ToolStripRenderMode.Professional;
		contextMenuStrip_0.ShowImageMargin = false;
		contextMenuStrip_0.ShowItemToolTips = false;
		Size size6 = new Size(159, 98);
		contextMenuStrip_0.Size = size6;
		toolStripMenuItem_0.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripMenuItem_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold | FontStyle.Underline);
		Color foreColor2 = Color.FromArgb(255, 128, 0);
		toolStripMenuItem_0.ForeColor = foreColor2;
		toolStripMenuItem_0.Name = Class16.smethod_0(1648970773);
		Size size7 = new Size(158, 22);
		toolStripMenuItem_0.Size = size7;
		toolStripMenuItem_0.Text = Class16.smethod_0(1648970791);
		toolStripMenuItem_0.Click += toolStripMenuItem_0_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1648970800);
		Size size8 = new Size(155, 6);
		toolStripSeparator_0.Size = size8;
		toolStripSeparator_0.Visible = false;
		toolStripMenuItem_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold | FontStyle.Underline);
		Color foreColor3 = Color.FromArgb(239, 191, 72);
		toolStripMenuItem_2.ForeColor = foreColor3;
		toolStripMenuItem_2.Name = Class16.smethod_0(1648970822);
		Size size9 = new Size(158, 22);
		toolStripMenuItem_2.Size = size9;
		toolStripMenuItem_2.Text = Class16.smethod_0(1648970834);
		toolStripMenuItem_2.Visible = false;
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold | FontStyle.Underline);
		Color foreColor4 = Color.FromArgb(192, 0, 0);
		toolStripMenuItem_1.ForeColor = foreColor4;
		toolStripMenuItem_1.Name = Class16.smethod_0(1648970855);
		Size size10 = new Size(158, 22);
		toolStripMenuItem_1.Size = size10;
		toolStripMenuItem_1.Text = Class16.smethod_0(1648925718);
		toolStripMenuItem_1.Visible = false;
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_3.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold | FontStyle.Underline);
		Color foreColor5 = Color.FromArgb(0, 192, 0);
		toolStripMenuItem_3.ForeColor = foreColor5;
		toolStripMenuItem_3.Name = Class16.smethod_0(1648970867);
		Size size11 = new Size(158, 22);
		toolStripMenuItem_3.Size = size11;
		toolStripMenuItem_3.Text = Class16.smethod_0(1648931361);
		toolStripMenuItem_3.Visible = false;
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		pictureBox_21.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_21.Image = Resources.cell30;
		Point location6 = new Point(220, 160);
		pictureBox_21.Location = location6;
		pictureBox_21.Name = Class16.smethod_0(1648970892);
		Size size12 = new Size(32, 32);
		pictureBox_21.Size = size12;
		pictureBox_21.TabIndex = 47;
		pictureBox_21.TabStop = false;
		pictureBox_21.Click += pictureBox_4_Click;
		pictureBox_21.DragDrop += pictureBox_4_DragDrop;
		pictureBox_21.DragEnter += pictureBox_4_DragEnter;
		pictureBox_21.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_21.MouseDown += pictureBox_4_MouseDown;
		pictureBox_21.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_21.MouseHover += pictureBox_4_MouseHover;
		pictureBox_21.MouseMove += pictureBox_4_MouseMove;
		pictureBox_21.MouseUp += pictureBox_37_MouseUp;
		pictureBox_22.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_22.Image = Resources.cell29;
		Point location7 = new Point(186, 160);
		pictureBox_22.Location = location7;
		pictureBox_22.Name = Class16.smethod_0(1648970897);
		Size size13 = new Size(32, 32);
		pictureBox_22.Size = size13;
		pictureBox_22.TabIndex = 46;
		pictureBox_22.TabStop = false;
		pictureBox_22.Click += pictureBox_4_Click;
		pictureBox_22.DragDrop += pictureBox_4_DragDrop;
		pictureBox_22.DragEnter += pictureBox_4_DragEnter;
		pictureBox_22.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_22.MouseDown += pictureBox_4_MouseDown;
		pictureBox_22.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_22.MouseHover += pictureBox_4_MouseHover;
		pictureBox_22.MouseMove += pictureBox_4_MouseMove;
		pictureBox_22.MouseUp += pictureBox_37_MouseUp;
		pictureBox_23.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_23.Image = Resources.cell28;
		Point location8 = new Point(152, 160);
		pictureBox_23.Location = location8;
		pictureBox_23.Name = Class16.smethod_0(1648970918);
		Size size14 = new Size(32, 32);
		pictureBox_23.Size = size14;
		pictureBox_23.TabIndex = 45;
		pictureBox_23.TabStop = false;
		pictureBox_23.Click += pictureBox_4_Click;
		pictureBox_23.DragDrop += pictureBox_4_DragDrop;
		pictureBox_23.DragEnter += pictureBox_4_DragEnter;
		pictureBox_23.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_23.MouseDown += pictureBox_4_MouseDown;
		pictureBox_23.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_23.MouseHover += pictureBox_4_MouseHover;
		pictureBox_23.MouseMove += pictureBox_4_MouseMove;
		pictureBox_23.MouseUp += pictureBox_37_MouseUp;
		pictureBox_24.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_24.Image = Resources.cell27;
		Point location9 = new Point(118, 160);
		pictureBox_24.Location = location9;
		pictureBox_24.Name = Class16.smethod_0(1648970923);
		Size size15 = new Size(32, 32);
		pictureBox_24.Size = size15;
		pictureBox_24.TabIndex = 44;
		pictureBox_24.TabStop = false;
		pictureBox_24.Click += pictureBox_4_Click;
		pictureBox_24.DragDrop += pictureBox_4_DragDrop;
		pictureBox_24.DragEnter += pictureBox_4_DragEnter;
		pictureBox_24.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_24.MouseDown += pictureBox_4_MouseDown;
		pictureBox_24.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_24.MouseHover += pictureBox_4_MouseHover;
		pictureBox_24.MouseMove += pictureBox_4_MouseMove;
		pictureBox_24.MouseUp += pictureBox_37_MouseUp;
		pictureBox_25.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_25.Image = Resources.cell26;
		Point location10 = new Point(84, 160);
		pictureBox_25.Location = location10;
		pictureBox_25.Name = Class16.smethod_0(1648970936);
		Size size16 = new Size(32, 32);
		pictureBox_25.Size = size16;
		pictureBox_25.TabIndex = 43;
		pictureBox_25.TabStop = false;
		pictureBox_25.Click += pictureBox_4_Click;
		pictureBox_25.DragDrop += pictureBox_4_DragDrop;
		pictureBox_25.DragEnter += pictureBox_4_DragEnter;
		pictureBox_25.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_25.MouseDown += pictureBox_4_MouseDown;
		pictureBox_25.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_25.MouseHover += pictureBox_4_MouseHover;
		pictureBox_25.MouseMove += pictureBox_4_MouseMove;
		pictureBox_25.MouseUp += pictureBox_37_MouseUp;
		pictureBox_26.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_26.Image = Resources.cell25;
		Point location11 = new Point(50, 160);
		pictureBox_26.Location = location11;
		pictureBox_26.Name = Class16.smethod_0(1648970957);
		Size size17 = new Size(32, 32);
		pictureBox_26.Size = size17;
		pictureBox_26.TabIndex = 42;
		pictureBox_26.TabStop = false;
		pictureBox_26.Click += pictureBox_4_Click;
		pictureBox_26.DragDrop += pictureBox_4_DragDrop;
		pictureBox_26.DragEnter += pictureBox_4_DragEnter;
		pictureBox_26.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_26.MouseDown += pictureBox_4_MouseDown;
		pictureBox_26.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_26.MouseHover += pictureBox_4_MouseHover;
		pictureBox_26.MouseMove += pictureBox_4_MouseMove;
		pictureBox_26.MouseUp += pictureBox_37_MouseUp;
		pictureBox_27.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_27.Image = Resources.cell24;
		Point location12 = new Point(16, 160);
		pictureBox_27.Location = location12;
		pictureBox_27.Name = Class16.smethod_0(1648970962);
		Size size18 = new Size(32, 32);
		pictureBox_27.Size = size18;
		pictureBox_27.TabIndex = 41;
		pictureBox_27.TabStop = false;
		pictureBox_27.Click += pictureBox_4_Click;
		pictureBox_27.DragDrop += pictureBox_4_DragDrop;
		pictureBox_27.DragEnter += pictureBox_4_DragEnter;
		pictureBox_27.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_27.MouseDown += pictureBox_4_MouseDown;
		pictureBox_27.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_27.MouseHover += pictureBox_4_MouseHover;
		pictureBox_27.MouseMove += pictureBox_4_MouseMove;
		pictureBox_27.MouseUp += pictureBox_37_MouseUp;
		pictureBox_28.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_28.Image = Resources.cell23;
		Point location13 = new Point(254, 126);
		pictureBox_28.Location = location13;
		pictureBox_28.Name = Class16.smethod_0(1648970983);
		Size size19 = new Size(32, 32);
		pictureBox_28.Size = size19;
		pictureBox_28.TabIndex = 40;
		pictureBox_28.TabStop = false;
		pictureBox_28.Click += pictureBox_4_Click;
		pictureBox_28.DragDrop += pictureBox_4_DragDrop;
		pictureBox_28.DragEnter += pictureBox_4_DragEnter;
		pictureBox_28.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_28.MouseDown += pictureBox_4_MouseDown;
		pictureBox_28.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_28.MouseHover += pictureBox_4_MouseHover;
		pictureBox_28.MouseMove += pictureBox_4_MouseMove;
		pictureBox_28.MouseUp += pictureBox_37_MouseUp;
		pictureBox_29.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_29.Image = Resources.cell22;
		Point location14 = new Point(220, 126);
		pictureBox_29.Location = location14;
		pictureBox_29.Name = Class16.smethod_0(1648970996);
		Size size20 = new Size(32, 32);
		pictureBox_29.Size = size20;
		pictureBox_29.TabIndex = 39;
		pictureBox_29.TabStop = false;
		pictureBox_29.Click += pictureBox_4_Click;
		pictureBox_29.DragDrop += pictureBox_4_DragDrop;
		pictureBox_29.DragEnter += pictureBox_4_DragEnter;
		pictureBox_29.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_29.MouseDown += pictureBox_4_MouseDown;
		pictureBox_29.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_29.MouseHover += pictureBox_4_MouseHover;
		pictureBox_29.MouseMove += pictureBox_4_MouseMove;
		pictureBox_29.MouseUp += pictureBox_37_MouseUp;
		pictureBox_30.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_30.Image = Resources.cell21;
		Point location15 = new Point(186, 126);
		pictureBox_30.Location = location15;
		pictureBox_30.Name = Class16.smethod_0(1648971001);
		Size size21 = new Size(32, 32);
		pictureBox_30.Size = size21;
		pictureBox_30.TabIndex = 38;
		pictureBox_30.TabStop = false;
		pictureBox_30.Click += pictureBox_4_Click;
		pictureBox_30.DragDrop += pictureBox_4_DragDrop;
		pictureBox_30.DragEnter += pictureBox_4_DragEnter;
		pictureBox_30.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_30.MouseDown += pictureBox_4_MouseDown;
		pictureBox_30.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_30.MouseHover += pictureBox_4_MouseHover;
		pictureBox_30.MouseMove += pictureBox_4_MouseMove;
		pictureBox_30.MouseUp += pictureBox_37_MouseUp;
		pictureBox_31.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_31.Image = Resources.cell20;
		Point location16 = new Point(152, 126);
		pictureBox_31.Location = location16;
		pictureBox_31.Name = Class16.smethod_0(1648971022);
		Size size22 = new Size(32, 32);
		pictureBox_31.Size = size22;
		pictureBox_31.TabIndex = 37;
		pictureBox_31.TabStop = false;
		pictureBox_31.Click += pictureBox_4_Click;
		pictureBox_31.DragDrop += pictureBox_4_DragDrop;
		pictureBox_31.DragEnter += pictureBox_4_DragEnter;
		pictureBox_31.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_31.MouseDown += pictureBox_4_MouseDown;
		pictureBox_31.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_31.MouseHover += pictureBox_4_MouseHover;
		pictureBox_31.MouseMove += pictureBox_4_MouseMove;
		pictureBox_31.MouseUp += pictureBox_37_MouseUp;
		pictureBox_32.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_32.Image = Resources.cell19;
		Point location17 = new Point(118, 126);
		pictureBox_32.Location = location17;
		pictureBox_32.Name = Class16.smethod_0(1648971027);
		Size size23 = new Size(32, 32);
		pictureBox_32.Size = size23;
		pictureBox_32.TabIndex = 36;
		pictureBox_32.TabStop = false;
		pictureBox_32.Click += pictureBox_4_Click;
		pictureBox_32.DragDrop += pictureBox_4_DragDrop;
		pictureBox_32.DragEnter += pictureBox_4_DragEnter;
		pictureBox_32.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_32.MouseDown += pictureBox_4_MouseDown;
		pictureBox_32.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_32.MouseHover += pictureBox_4_MouseHover;
		pictureBox_32.MouseMove += pictureBox_4_MouseMove;
		pictureBox_32.MouseUp += pictureBox_37_MouseUp;
		pictureBox_33.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_33.Image = Resources.cell18;
		Point location18 = new Point(84, 126);
		pictureBox_33.Location = location18;
		pictureBox_33.Name = Class16.smethod_0(1648971040);
		Size size24 = new Size(32, 32);
		pictureBox_33.Size = size24;
		pictureBox_33.TabIndex = 35;
		pictureBox_33.TabStop = false;
		pictureBox_33.Click += pictureBox_4_Click;
		pictureBox_33.DragDrop += pictureBox_4_DragDrop;
		pictureBox_33.DragEnter += pictureBox_4_DragEnter;
		pictureBox_33.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_33.MouseDown += pictureBox_4_MouseDown;
		pictureBox_33.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_33.MouseHover += pictureBox_4_MouseHover;
		pictureBox_33.MouseMove += pictureBox_4_MouseMove;
		pictureBox_33.MouseUp += pictureBox_37_MouseUp;
		pictureBox_34.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_34.Image = Resources.cell17;
		Point location19 = new Point(50, 126);
		pictureBox_34.Location = location19;
		pictureBox_34.Name = Class16.smethod_0(1648971061);
		Size size25 = new Size(32, 32);
		pictureBox_34.Size = size25;
		pictureBox_34.TabIndex = 34;
		pictureBox_34.TabStop = false;
		pictureBox_34.Click += pictureBox_4_Click;
		pictureBox_34.DragDrop += pictureBox_4_DragDrop;
		pictureBox_34.DragEnter += pictureBox_4_DragEnter;
		pictureBox_34.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_34.MouseDown += pictureBox_4_MouseDown;
		pictureBox_34.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_34.MouseHover += pictureBox_4_MouseHover;
		pictureBox_34.MouseMove += pictureBox_4_MouseMove;
		pictureBox_34.MouseUp += pictureBox_37_MouseUp;
		pictureBox_35.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_35.Image = Resources.cell16;
		Point location20 = new Point(16, 126);
		pictureBox_35.Location = location20;
		pictureBox_35.Name = Class16.smethod_0(1648971066);
		Size size26 = new Size(32, 32);
		pictureBox_35.Size = size26;
		pictureBox_35.TabIndex = 33;
		pictureBox_35.TabStop = false;
		pictureBox_35.Click += pictureBox_4_Click;
		pictureBox_35.DragDrop += pictureBox_4_DragDrop;
		pictureBox_35.DragEnter += pictureBox_4_DragEnter;
		pictureBox_35.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_35.MouseDown += pictureBox_4_MouseDown;
		pictureBox_35.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_35.MouseHover += pictureBox_4_MouseHover;
		pictureBox_35.MouseMove += pictureBox_4_MouseMove;
		pictureBox_35.MouseUp += pictureBox_37_MouseUp;
		pictureBox_5.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_5.Image = Resources.cell15;
		Point location21 = new Point(254, 91);
		pictureBox_5.Location = location21;
		pictureBox_5.Name = Class16.smethod_0(1648971087);
		Size size27 = new Size(32, 32);
		pictureBox_5.Size = size27;
		pictureBox_5.TabIndex = 32;
		pictureBox_5.TabStop = false;
		pictureBox_5.Click += pictureBox_4_Click;
		pictureBox_5.DragDrop += pictureBox_4_DragDrop;
		pictureBox_5.DragEnter += pictureBox_4_DragEnter;
		pictureBox_5.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_5.MouseDown += pictureBox_4_MouseDown;
		pictureBox_5.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_5.MouseHover += pictureBox_4_MouseHover;
		pictureBox_5.MouseMove += pictureBox_4_MouseMove;
		pictureBox_5.MouseUp += pictureBox_37_MouseUp;
		pictureBox_6.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_6.Image = Resources.cell14;
		Point location22 = new Point(220, 91);
		pictureBox_6.Location = location22;
		pictureBox_6.Name = Class16.smethod_0(1648971100);
		Size size28 = new Size(32, 32);
		pictureBox_6.Size = size28;
		pictureBox_6.TabIndex = 31;
		pictureBox_6.TabStop = false;
		pictureBox_6.Click += pictureBox_4_Click;
		pictureBox_6.DragDrop += pictureBox_4_DragDrop;
		pictureBox_6.DragEnter += pictureBox_4_DragEnter;
		pictureBox_6.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_6.MouseDown += pictureBox_4_MouseDown;
		pictureBox_6.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_6.MouseHover += pictureBox_4_MouseHover;
		pictureBox_6.MouseMove += pictureBox_4_MouseMove;
		pictureBox_6.MouseUp += pictureBox_37_MouseUp;
		pictureBox_7.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_7.Image = Resources.cell13;
		Point location23 = new Point(186, 91);
		pictureBox_7.Location = location23;
		pictureBox_7.Name = Class16.smethod_0(1648971105);
		Size size29 = new Size(32, 32);
		pictureBox_7.Size = size29;
		pictureBox_7.TabIndex = 30;
		pictureBox_7.TabStop = false;
		pictureBox_7.Click += pictureBox_4_Click;
		pictureBox_7.DragDrop += pictureBox_4_DragDrop;
		pictureBox_7.DragEnter += pictureBox_4_DragEnter;
		pictureBox_7.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_7.MouseDown += pictureBox_4_MouseDown;
		pictureBox_7.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_7.MouseHover += pictureBox_4_MouseHover;
		pictureBox_7.MouseMove += pictureBox_4_MouseMove;
		pictureBox_7.MouseUp += pictureBox_37_MouseUp;
		pictureBox_8.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_8.Image = Resources.cell12;
		Point location24 = new Point(152, 91);
		pictureBox_8.Location = location24;
		pictureBox_8.Name = Class16.smethod_0(1648971126);
		Size size30 = new Size(32, 32);
		pictureBox_8.Size = size30;
		pictureBox_8.TabIndex = 29;
		pictureBox_8.TabStop = false;
		pictureBox_8.Click += pictureBox_4_Click;
		pictureBox_8.DragDrop += pictureBox_4_DragDrop;
		pictureBox_8.DragEnter += pictureBox_4_DragEnter;
		pictureBox_8.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_8.MouseDown += pictureBox_4_MouseDown;
		pictureBox_8.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_8.MouseHover += pictureBox_4_MouseHover;
		pictureBox_8.MouseMove += pictureBox_4_MouseMove;
		pictureBox_8.MouseUp += pictureBox_37_MouseUp;
		pictureBox_9.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_9.Image = Resources.cell11;
		Point location25 = new Point(118, 91);
		pictureBox_9.Location = location25;
		pictureBox_9.Name = Class16.smethod_0(1648971131);
		Size size31 = new Size(32, 32);
		pictureBox_9.Size = size31;
		pictureBox_9.TabIndex = 28;
		pictureBox_9.TabStop = false;
		pictureBox_9.Click += pictureBox_4_Click;
		pictureBox_9.DragDrop += pictureBox_4_DragDrop;
		pictureBox_9.DragEnter += pictureBox_4_DragEnter;
		pictureBox_9.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_9.MouseDown += pictureBox_4_MouseDown;
		pictureBox_9.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_9.MouseHover += pictureBox_4_MouseHover;
		pictureBox_9.MouseMove += pictureBox_4_MouseMove;
		pictureBox_9.MouseUp += pictureBox_37_MouseUp;
		pictureBox_10.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_10.Image = Resources.cell10;
		Point location26 = new Point(84, 91);
		pictureBox_10.Location = location26;
		pictureBox_10.Name = Class16.smethod_0(1648971144);
		Size size32 = new Size(32, 32);
		pictureBox_10.Size = size32;
		pictureBox_10.TabIndex = 27;
		pictureBox_10.TabStop = false;
		pictureBox_10.Click += pictureBox_4_Click;
		pictureBox_10.DragDrop += pictureBox_4_DragDrop;
		pictureBox_10.DragEnter += pictureBox_4_DragEnter;
		pictureBox_10.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_10.MouseDown += pictureBox_4_MouseDown;
		pictureBox_10.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_10.MouseHover += pictureBox_4_MouseHover;
		pictureBox_10.MouseMove += pictureBox_4_MouseMove;
		pictureBox_10.MouseUp += pictureBox_37_MouseUp;
		pictureBox_11.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_11.Image = Resources.cell09;
		Point location27 = new Point(50, 91);
		pictureBox_11.Location = location27;
		pictureBox_11.Name = Class16.smethod_0(1648971165);
		Size size33 = new Size(32, 32);
		pictureBox_11.Size = size33;
		pictureBox_11.TabIndex = 26;
		pictureBox_11.TabStop = false;
		pictureBox_11.Click += pictureBox_4_Click;
		pictureBox_11.DragDrop += pictureBox_4_DragDrop;
		pictureBox_11.DragEnter += pictureBox_4_DragEnter;
		pictureBox_11.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_11.MouseDown += pictureBox_4_MouseDown;
		pictureBox_11.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_11.MouseHover += pictureBox_4_MouseHover;
		pictureBox_11.MouseMove += pictureBox_4_MouseMove;
		pictureBox_11.MouseUp += pictureBox_37_MouseUp;
		pictureBox_12.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_12.Image = Resources.cell08;
		Point location28 = new Point(16, 91);
		pictureBox_12.Location = location28;
		pictureBox_12.Name = Class16.smethod_0(1648971170);
		Size size34 = new Size(32, 32);
		pictureBox_12.Size = size34;
		pictureBox_12.TabIndex = 25;
		pictureBox_12.TabStop = false;
		pictureBox_12.Click += pictureBox_4_Click;
		pictureBox_12.DragDrop += pictureBox_4_DragDrop;
		pictureBox_12.DragEnter += pictureBox_4_DragEnter;
		pictureBox_12.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_12.MouseDown += pictureBox_4_MouseDown;
		pictureBox_12.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_12.MouseHover += pictureBox_4_MouseHover;
		pictureBox_12.MouseMove += pictureBox_4_MouseMove;
		pictureBox_12.MouseUp += pictureBox_37_MouseUp;
		pictureBox_13.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_13.Image = Resources.cell07;
		Point location29 = new Point(254, 56);
		pictureBox_13.Location = location29;
		pictureBox_13.Name = Class16.smethod_0(1648971191);
		Size size35 = new Size(32, 32);
		pictureBox_13.Size = size35;
		pictureBox_13.TabIndex = 24;
		pictureBox_13.TabStop = false;
		pictureBox_13.Click += pictureBox_4_Click;
		pictureBox_13.DragDrop += pictureBox_4_DragDrop;
		pictureBox_13.DragEnter += pictureBox_4_DragEnter;
		pictureBox_13.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_13.MouseDown += pictureBox_4_MouseDown;
		pictureBox_13.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_13.MouseHover += pictureBox_4_MouseHover;
		pictureBox_13.MouseMove += pictureBox_4_MouseMove;
		pictureBox_13.MouseUp += pictureBox_37_MouseUp;
		pictureBox_14.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_14.Image = Resources.cell06;
		Point location30 = new Point(220, 56);
		pictureBox_14.Location = location30;
		pictureBox_14.Name = Class16.smethod_0(1648971204);
		Size size36 = new Size(32, 32);
		pictureBox_14.Size = size36;
		pictureBox_14.TabIndex = 23;
		pictureBox_14.TabStop = false;
		pictureBox_14.Click += pictureBox_4_Click;
		pictureBox_14.DragDrop += pictureBox_4_DragDrop;
		pictureBox_14.DragEnter += pictureBox_4_DragEnter;
		pictureBox_14.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_14.MouseDown += pictureBox_4_MouseDown;
		pictureBox_14.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_14.MouseHover += pictureBox_4_MouseHover;
		pictureBox_14.MouseMove += pictureBox_4_MouseMove;
		pictureBox_14.MouseUp += pictureBox_37_MouseUp;
		pictureBox_15.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_15.Image = Resources.cell05;
		Point location31 = new Point(186, 56);
		pictureBox_15.Location = location31;
		pictureBox_15.Name = Class16.smethod_0(1648971209);
		Size size37 = new Size(32, 32);
		pictureBox_15.Size = size37;
		pictureBox_15.TabIndex = 22;
		pictureBox_15.TabStop = false;
		pictureBox_15.Click += pictureBox_4_Click;
		pictureBox_15.DragDrop += pictureBox_4_DragDrop;
		pictureBox_15.DragEnter += pictureBox_4_DragEnter;
		pictureBox_15.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_15.MouseDown += pictureBox_4_MouseDown;
		pictureBox_15.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_15.MouseHover += pictureBox_4_MouseHover;
		pictureBox_15.MouseMove += pictureBox_4_MouseMove;
		pictureBox_15.MouseUp += pictureBox_37_MouseUp;
		pictureBox_16.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_16.Image = Resources.cell04;
		Point location32 = new Point(152, 56);
		pictureBox_16.Location = location32;
		pictureBox_16.Name = Class16.smethod_0(1648971230);
		Size size38 = new Size(32, 32);
		pictureBox_16.Size = size38;
		pictureBox_16.TabIndex = 21;
		pictureBox_16.TabStop = false;
		pictureBox_16.Click += pictureBox_4_Click;
		pictureBox_16.DragDrop += pictureBox_4_DragDrop;
		pictureBox_16.DragEnter += pictureBox_4_DragEnter;
		pictureBox_16.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_16.MouseDown += pictureBox_4_MouseDown;
		pictureBox_16.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_16.MouseHover += pictureBox_4_MouseHover;
		pictureBox_16.MouseMove += pictureBox_4_MouseMove;
		pictureBox_16.MouseUp += pictureBox_37_MouseUp;
		pictureBox_17.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_17.Image = Resources.cell03;
		Point location33 = new Point(118, 56);
		pictureBox_17.Location = location33;
		pictureBox_17.Name = Class16.smethod_0(1648971235);
		Size size39 = new Size(32, 32);
		pictureBox_17.Size = size39;
		pictureBox_17.TabIndex = 20;
		pictureBox_17.TabStop = false;
		pictureBox_17.Click += pictureBox_4_Click;
		pictureBox_17.DragDrop += pictureBox_4_DragDrop;
		pictureBox_17.DragEnter += pictureBox_4_DragEnter;
		pictureBox_17.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_17.MouseDown += pictureBox_4_MouseDown;
		pictureBox_17.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_17.MouseHover += pictureBox_4_MouseHover;
		pictureBox_17.MouseMove += pictureBox_4_MouseMove;
		pictureBox_17.MouseUp += pictureBox_37_MouseUp;
		pictureBox_18.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_18.Image = Resources.cell02;
		Point location34 = new Point(84, 56);
		pictureBox_18.Location = location34;
		pictureBox_18.Name = Class16.smethod_0(1648971248);
		Size size40 = new Size(32, 32);
		pictureBox_18.Size = size40;
		pictureBox_18.TabIndex = 19;
		pictureBox_18.TabStop = false;
		pictureBox_18.Click += pictureBox_4_Click;
		pictureBox_18.DragDrop += pictureBox_4_DragDrop;
		pictureBox_18.DragEnter += pictureBox_4_DragEnter;
		pictureBox_18.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_18.MouseDown += pictureBox_4_MouseDown;
		pictureBox_18.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_18.MouseHover += pictureBox_4_MouseHover;
		pictureBox_18.MouseMove += pictureBox_4_MouseMove;
		pictureBox_18.MouseUp += pictureBox_37_MouseUp;
		pictureBox_19.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_19.Image = Resources.cell01;
		Point location35 = new Point(50, 56);
		pictureBox_19.Location = location35;
		pictureBox_19.Name = Class16.smethod_0(1648970245);
		Size size41 = new Size(32, 32);
		pictureBox_19.Size = size41;
		pictureBox_19.TabIndex = 18;
		pictureBox_19.TabStop = false;
		pictureBox_19.Click += pictureBox_4_Click;
		pictureBox_19.DragDrop += pictureBox_4_DragDrop;
		pictureBox_19.DragEnter += pictureBox_4_DragEnter;
		pictureBox_19.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_19.MouseDown += pictureBox_4_MouseDown;
		pictureBox_19.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_19.MouseHover += pictureBox_4_MouseHover;
		pictureBox_19.MouseMove += pictureBox_4_MouseMove;
		pictureBox_19.MouseUp += pictureBox_37_MouseUp;
		pictureBox_4.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_4.Image = Resources.cell00;
		Point location36 = new Point(16, 56);
		pictureBox_4.Location = location36;
		pictureBox_4.Name = Class16.smethod_0(1648970250);
		Size size42 = new Size(32, 32);
		pictureBox_4.Size = size42;
		pictureBox_4.TabIndex = 17;
		pictureBox_4.TabStop = false;
		pictureBox_4.Click += pictureBox_4_Click;
		pictureBox_4.DragDrop += pictureBox_4_DragDrop;
		pictureBox_4.DragEnter += pictureBox_4_DragEnter;
		pictureBox_4.DoubleClick += pictureBox_4_DoubleClick;
		pictureBox_4.MouseDown += pictureBox_4_MouseDown;
		pictureBox_4.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_4.MouseHover += pictureBox_4_MouseHover;
		pictureBox_4.MouseMove += pictureBox_4_MouseMove;
		pictureBox_4.MouseUp += pictureBox_37_MouseUp;
		label_2.Font = new Font(Class16.smethod_0(1648942905), 9.5f, FontStyle.Bold);
		Color foreColor6 = Color.FromArgb(240, 240, 240);
		label_2.ForeColor = foreColor6;
		label_2.Image = Resources.tab7;
		Point location37 = new Point(221, 29);
		label_2.Location = location37;
		label_2.Name = Class16.smethod_0(1648970271);
		Size size43 = new Size(65, 22);
		label_2.Size = size43;
		label_2.TabIndex = 16;
		label_2.Tag = Class16.smethod_0(1648911788);
		label_2.TextAlign = ContentAlignment.MiddleCenter;
		label_2.TextChanged += label_0_TextChanged;
		label_2.Click += label_0_Click;
		label_2.DragDrop += label_0_DragDrop;
		label_2.DragEnter += label_0_DragEnter;
		label_2.DoubleClick += label_0_DoubleClick;
		label_2.MouseDown += label_0_MouseDown;
		label_2.MouseEnter += label_0_MouseEnter;
		label_2.MouseLeave += label_0_MouseLeave;
		label_2.MouseMove += label_0_MouseMove;
		label_3.Font = new Font(Class16.smethod_0(1648942905), 9.5f, FontStyle.Bold);
		Color foreColor7 = Color.FromArgb(240, 240, 240);
		label_3.ForeColor = foreColor7;
		label_3.Image = Resources.tab3;
		Point location38 = new Point(221, 6);
		label_3.Location = location38;
		label_3.Name = Class16.smethod_0(1648970274);
		Size size44 = new Size(65, 22);
		label_3.Size = size44;
		label_3.TabIndex = 15;
		label_3.Tag = Class16.smethod_0(1648911557);
		label_3.TextAlign = ContentAlignment.MiddleCenter;
		label_3.TextChanged += label_0_TextChanged;
		label_3.Click += label_0_Click;
		label_3.DragDrop += label_0_DragDrop;
		label_3.DragEnter += label_0_DragEnter;
		label_3.DoubleClick += label_0_DoubleClick;
		label_3.MouseDown += label_0_MouseDown;
		label_3.MouseEnter += label_0_MouseEnter;
		label_3.MouseLeave += label_0_MouseLeave;
		label_3.MouseMove += label_0_MouseMove;
		label_4.Font = new Font(Class16.smethod_0(1648942905), 9.5f, FontStyle.Bold);
		Color foreColor8 = Color.FromArgb(240, 240, 240);
		label_4.ForeColor = foreColor8;
		label_4.Image = Resources.tab6;
		Point location39 = new Point(153, 29);
		label_4.Location = location39;
		label_4.Name = Class16.smethod_0(1648970293);
		Size size45 = new Size(65, 22);
		label_4.Size = size45;
		label_4.TabIndex = 14;
		label_4.Tag = Class16.smethod_0(1648910861);
		label_4.TextAlign = ContentAlignment.MiddleCenter;
		label_4.TextChanged += label_0_TextChanged;
		label_4.Click += label_0_Click;
		label_4.DragDrop += label_0_DragDrop;
		label_4.DragEnter += label_0_DragEnter;
		label_4.DoubleClick += label_0_DoubleClick;
		label_4.MouseDown += label_0_MouseDown;
		label_4.MouseEnter += label_0_MouseEnter;
		label_4.MouseLeave += label_0_MouseLeave;
		label_4.MouseMove += label_0_MouseMove;
		label_5.Font = new Font(Class16.smethod_0(1648942905), 9.5f, FontStyle.Bold);
		Color foreColor9 = Color.FromArgb(240, 240, 240);
		label_5.ForeColor = foreColor9;
		label_5.Image = Resources.tab2;
		Point location40 = new Point(153, 6);
		label_5.Location = location40;
		label_5.Name = Class16.smethod_0(1648970296);
		Size size46 = new Size(65, 22);
		label_5.Size = size46;
		label_5.TabIndex = 13;
		label_5.Tag = Class16.smethod_0(1648934967);
		label_5.TextAlign = ContentAlignment.MiddleCenter;
		label_5.TextChanged += label_0_TextChanged;
		label_5.Click += label_0_Click;
		label_5.DragDrop += label_0_DragDrop;
		label_5.DragEnter += label_0_DragEnter;
		label_5.DoubleClick += label_0_DoubleClick;
		label_5.MouseDown += label_0_MouseDown;
		label_5.MouseEnter += label_0_MouseEnter;
		label_5.MouseLeave += label_0_MouseLeave;
		label_5.MouseMove += label_0_MouseMove;
		label_6.Font = new Font(Class16.smethod_0(1648942905), 9.5f, FontStyle.Bold);
		Color foreColor10 = Color.FromArgb(240, 240, 240);
		label_6.ForeColor = foreColor10;
		label_6.Image = Resources.tab5;
		Point location41 = new Point(84, 29);
		label_6.Location = location41;
		label_6.Name = Class16.smethod_0(1648970307);
		Size size47 = new Size(65, 22);
		label_6.Size = size47;
		label_6.TabIndex = 12;
		label_6.Tag = Class16.smethod_0(1648911820);
		label_6.TextAlign = ContentAlignment.MiddleCenter;
		label_6.TextChanged += label_0_TextChanged;
		label_6.Click += label_0_Click;
		label_6.DragDrop += label_0_DragDrop;
		label_6.DragEnter += label_0_DragEnter;
		label_6.DoubleClick += label_0_DoubleClick;
		label_6.MouseDown += label_0_MouseDown;
		label_6.MouseEnter += label_0_MouseEnter;
		label_6.MouseLeave += label_0_MouseLeave;
		label_6.MouseMove += label_0_MouseMove;
		label_7.Font = new Font(Class16.smethod_0(1648942905), 9.5f, FontStyle.Bold);
		Color foreColor11 = Color.FromArgb(240, 240, 240);
		label_7.ForeColor = foreColor11;
		label_7.Image = Resources.tab1;
		Point location42 = new Point(84, 6);
		label_7.Location = location42;
		label_7.Name = Class16.smethod_0(1648970326);
		Size size48 = new Size(65, 22);
		label_7.Size = size48;
		label_7.TabIndex = 11;
		label_7.Tag = Class16.smethod_0(1648934925);
		label_7.TextAlign = ContentAlignment.MiddleCenter;
		label_7.TextChanged += label_0_TextChanged;
		label_7.Click += label_0_Click;
		label_7.DragDrop += label_0_DragDrop;
		label_7.DragEnter += label_0_DragEnter;
		label_7.DoubleClick += label_0_DoubleClick;
		label_7.MouseDown += label_0_MouseDown;
		label_7.MouseEnter += label_0_MouseEnter;
		label_7.MouseLeave += label_0_MouseLeave;
		label_7.MouseMove += label_0_MouseMove;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 9.5f, FontStyle.Bold);
		Color foreColor12 = Color.FromArgb(240, 240, 240);
		label_1.ForeColor = foreColor12;
		label_1.Image = Resources.tab4;
		Point location43 = new Point(16, 29);
		label_1.Location = location43;
		label_1.Name = Class16.smethod_0(1648970329);
		Size size49 = new Size(65, 22);
		label_1.Size = size49;
		label_1.TabIndex = 10;
		label_1.Tag = Class16.smethod_0(1648935001);
		label_1.TextAlign = ContentAlignment.MiddleCenter;
		label_1.TextChanged += label_0_TextChanged;
		label_1.Click += label_0_Click;
		label_1.DragDrop += label_0_DragDrop;
		label_1.DragEnter += label_0_DragEnter;
		label_1.DoubleClick += label_0_DoubleClick;
		label_1.MouseDown += label_0_MouseDown;
		label_1.MouseEnter += label_0_MouseEnter;
		label_1.MouseLeave += label_0_MouseLeave;
		label_1.MouseMove += label_0_MouseMove;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9.5f, FontStyle.Bold);
		Color foreColor13 = Color.FromArgb(240, 240, 240);
		label_0.ForeColor = foreColor13;
		label_0.Image = Resources.tab0;
		Point location44 = new Point(16, 6);
		label_0.Location = location44;
		label_0.Name = Class16.smethod_0(1648970348);
		Size size50 = new Size(65, 22);
		label_0.Size = size50;
		label_0.TabIndex = 9;
		label_0.Tag = Class16.smethod_0(1648924112);
		label_0.TextAlign = ContentAlignment.MiddleCenter;
		label_0.TextChanged += label_0_TextChanged;
		label_0.Click += label_0_Click;
		label_0.DragDrop += label_0_DragDrop;
		label_0.DragEnter += label_0_DragEnter;
		label_0.DoubleClick += label_0_DoubleClick;
		label_0.MouseDown += label_0_MouseDown;
		label_0.MouseEnter += label_0_MouseEnter;
		label_0.MouseLeave += label_0_MouseLeave;
		label_0.MouseMove += label_0_MouseMove;
		pictureBox_46.Dock = DockStyle.Fill;
		pictureBox_46.Image = Resources.RecipesPreview_pictureBox3;
		Point location45 = new Point(0, 0);
		pictureBox_46.Location = location45;
		pictureBox_46.Name = Class16.smethod_0(1648976984);
		Size size51 = new Size(299, 200);
		pictureBox_46.Size = size51;
		pictureBox_46.TabIndex = 49;
		pictureBox_46.TabStop = false;
		pictureBox_46.MouseDown += RecipesPreview_MouseDown;
		pictureBox_46.MouseMove += RecipesPreview_MouseMove;
		pictureBox_46.MouseUp += RecipesPreview_MouseUp;
		panel_0.AutoSize = true;
		panel_0.BackgroundImageLayout = ImageLayout.None;
		NumericUpDown value43 = numericUpDown_1;
		panel_0.Controls.Add(value43);
		PictureBox value44 = pictureBox_50;
		panel_0.Controls.Add(value44);
		NumericUpDown value45 = numericUpDown_0;
		panel_0.Controls.Add(value45);
		PictureBox value46 = pictureBox_3;
		panel_0.Controls.Add(value46);
		TextBox value47 = textBox_9;
		panel_0.Controls.Add(value47);
		TextBox value48 = textBox_8;
		panel_0.Controls.Add(value48);
		Label value49 = label_19;
		panel_0.Controls.Add(value49);
		Label value50 = label_20;
		panel_0.Controls.Add(value50);
		TextBox value51 = textBox_1;
		panel_0.Controls.Add(value51);
		TextBox value52 = textBox_2;
		panel_0.Controls.Add(value52);
		TextBox value53 = textBox_3;
		panel_0.Controls.Add(value53);
		TextBox value54 = textBox_4;
		panel_0.Controls.Add(value54);
		TextBox value55 = textBox_5;
		panel_0.Controls.Add(value55);
		TextBox value56 = textBox_6;
		panel_0.Controls.Add(value56);
		TextBox value57 = textBox_7;
		panel_0.Controls.Add(value57);
		TextBox value58 = textBox_0;
		panel_0.Controls.Add(value58);
		PictureBox value59 = pictureBox_44;
		panel_0.Controls.Add(value59);
		PictureBox value60 = pictureBox_40;
		panel_0.Controls.Add(value60);
		PictureBox value61 = pictureBox_41;
		panel_0.Controls.Add(value61);
		PictureBox value62 = pictureBox_42;
		panel_0.Controls.Add(value62);
		PictureBox value63 = pictureBox_43;
		panel_0.Controls.Add(value63);
		PictureBox value64 = pictureBox_38;
		panel_0.Controls.Add(value64);
		PictureBox value65 = pictureBox_39;
		panel_0.Controls.Add(value65);
		PictureBox value66 = pictureBox_36;
		panel_0.Controls.Add(value66);
		PictureBox value67 = pictureBox_37;
		panel_0.Controls.Add(value67);
		Label value68 = label_15;
		panel_0.Controls.Add(value68);
		Label value69 = label_12;
		panel_0.Controls.Add(value69);
		Label value70 = label_10;
		panel_0.Controls.Add(value70);
		Label value71 = label_11;
		panel_0.Controls.Add(value71);
		PictureBox value72 = pictureBox_48;
		panel_0.Controls.Add(value72);
		Label value73 = label_23;
		panel_0.Controls.Add(value73);
		Point location46 = new Point(13, 261);
		panel_0.Location = location46;
		panel_0.Name = Class16.smethod_0(1648970359);
		Size size52 = new Size(302, 212);
		panel_0.Size = size52;
		panel_0.TabIndex = 8;
		panel_0.MouseDown += RecipesPreview_MouseDown;
		panel_0.MouseMove += RecipesPreview_MouseMove;
		panel_0.MouseUp += RecipesPreview_MouseUp;
		Color backColor3 = Color.FromArgb(20, 30, 37);
		numericUpDown_1.BackColor = backColor3;
		numericUpDown_1.BorderStyle = BorderStyle.None;
		numericUpDown_1.Enabled = false;
		numericUpDown_1.Font = new Font(Class16.smethod_0(1648942905), 8f);
		Color white = Color.White;
		numericUpDown_1.ForeColor = white;
		Point location47 = new Point(77, 7);
		numericUpDown_1.Location = location47;
		decimal maximum = new decimal(new int[4] { 200000000, 0, 0, 0 });
		numericUpDown_1.Maximum = maximum;
		numericUpDown_1.Name = Class16.smethod_0(1648968311);
		Size size53 = new Size(63, 18);
		numericUpDown_1.Size = size53;
		numericUpDown_1.TabIndex = 69;
		numericUpDown_1.ThousandsSeparator = true;
		decimal value74 = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_1.Value = value74;
		numericUpDown_1.Visible = false;
		numericUpDown_1.ValueChanged += textBox_0_TextChanged;
		numericUpDown_1.Leave += textBox_0_Leave;
		pictureBox_50.Image = Resources.RecipesPreview_pictureBox5;
		Point location48 = new Point(68, 2);
		pictureBox_50.Location = location48;
		pictureBox_50.Name = Class16.smethod_0(1648976337);
		Size size54 = new Size(66, 23);
		pictureBox_50.Size = size54;
		pictureBox_50.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_50.TabIndex = 68;
		pictureBox_50.TabStop = false;
		pictureBox_50.Visible = false;
		Color backColor4 = Color.FromArgb(20, 30, 37);
		numericUpDown_0.BackColor = backColor4;
		numericUpDown_0.BorderStyle = BorderStyle.None;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 8f);
		Color white2 = Color.White;
		numericUpDown_0.ForeColor = white2;
		Point location49 = new Point(205, 7);
		numericUpDown_0.Location = location49;
		decimal maximum2 = new decimal(new int[4] { 200000000, 0, 0, 0 });
		numericUpDown_0.Maximum = maximum2;
		numericUpDown_0.Name = Class16.smethod_0(1648970377);
		Size size55 = new Size(86, 18);
		numericUpDown_0.Size = size55;
		numericUpDown_0.TabIndex = 67;
		numericUpDown_0.ThousandsSeparator = true;
		numericUpDown_0.ValueChanged += textBox_0_TextChanged;
		numericUpDown_0.Leave += textBox_0_Leave;
		pictureBox_3.Image = Resources.RecipesPreview_pictureBox1;
		Point location50 = new Point(190, 164);
		pictureBox_3.Location = location50;
		pictureBox_3.Name = Class16.smethod_0(1648976327);
		Size size56 = new Size(96, 22);
		pictureBox_3.Size = size56;
		pictureBox_3.TabIndex = 4;
		pictureBox_3.TabStop = false;
		pictureBox_3.Visible = false;
		Color backColor5 = Color.FromArgb(20, 30, 37);
		textBox_9.BackColor = backColor5;
		textBox_9.BorderStyle = BorderStyle.None;
		textBox_9.Enabled = false;
		textBox_9.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		Color foreColor14 = Color.FromArgb(240, 240, 240);
		textBox_9.ForeColor = foreColor14;
		Point location51 = new Point(207, 8);
		textBox_9.Location = location51;
		textBox_9.Name = Class16.smethod_0(1648970397);
		Size size57 = new Size(85, 16);
		textBox_9.Size = size57;
		textBox_9.TabIndex = 64;
		textBox_9.TabStop = false;
		textBox_9.Text = Class16.smethod_0(1648924112);
		textBox_9.Visible = false;
		textBox_9.TextChanged += textBox_0_TextChanged;
		textBox_9.KeyUp += textBox_0_KeyUp;
		textBox_9.Leave += textBox_0_Leave;
		Color backColor6 = Color.FromArgb(20, 30, 37);
		textBox_8.BackColor = backColor6;
		textBox_8.BorderStyle = BorderStyle.None;
		textBox_8.Enabled = false;
		textBox_8.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		Color foreColor15 = Color.FromArgb(240, 240, 240);
		textBox_8.ForeColor = foreColor15;
		Point location52 = new Point(129, 172);
		textBox_8.Location = location52;
		textBox_8.Name = Class16.smethod_0(1648970412);
		Size size58 = new Size(45, 16);
		textBox_8.Size = size58;
		textBox_8.TabIndex = 63;
		textBox_8.Text = Class16.smethod_0(1648934925);
		textBox_8.TextChanged += textBox_0_TextChanged;
		textBox_8.KeyUp += textBox_0_KeyUp;
		textBox_8.Leave += textBox_0_Leave;
		label_19.AutoSize = true;
		Color transparent = Color.Transparent;
		label_19.BackColor = transparent;
		label_19.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color foreColor16 = Color.FromArgb(239, 191, 72);
		label_19.ForeColor = foreColor16;
		Point location53 = new Point(214, 136);
		label_19.Location = location53;
		label_19.Name = Class16.smethod_0(1648970428);
		Size size59 = new Size(13, 13);
		label_19.Size = size59;
		label_19.TabIndex = 62;
		label_19.Text = Class16.smethod_0(1648924112);
		label_20.AutoSize = true;
		Color transparent2 = Color.Transparent;
		label_20.BackColor = transparent2;
		label_20.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color foreColor17 = Color.FromArgb(239, 191, 72);
		label_20.ForeColor = foreColor17;
		Point location54 = new Point(71, 136);
		label_20.Location = location54;
		label_20.Name = Class16.smethod_0(1648970440);
		Size size60 = new Size(43, 13);
		label_20.Size = size60;
		label_20.TabIndex = 61;
		label_20.Text = Class16.smethod_0(1648970459);
		Color backColor7 = Color.FromArgb(20, 30, 37);
		textBox_1.BackColor = backColor7;
		textBox_1.BorderStyle = BorderStyle.None;
		textBox_1.Enabled = false;
		textBox_1.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		Color foreColor18 = Color.FromArgb(240, 240, 240);
		textBox_1.ForeColor = foreColor18;
		Point location55 = new Point(232, 111);
		textBox_1.Location = location55;
		textBox_1.Name = Class16.smethod_0(1648970484);
		Size size61 = new Size(47, 16);
		textBox_1.Size = size61;
		textBox_1.TabIndex = 60;
		textBox_1.Text = Class16.smethod_0(1648924112);
		textBox_1.TextChanged += textBox_0_TextChanged;
		textBox_1.KeyUp += textBox_0_KeyUp;
		textBox_1.Leave += textBox_0_Leave;
		Color backColor8 = Color.FromArgb(20, 30, 37);
		textBox_2.BackColor = backColor8;
		textBox_2.BorderStyle = BorderStyle.None;
		textBox_2.Enabled = false;
		textBox_2.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		Color foreColor19 = Color.FromArgb(240, 240, 240);
		textBox_2.ForeColor = foreColor19;
		Point location56 = new Point(162, 111);
		textBox_2.Location = location56;
		textBox_2.Name = Class16.smethod_0(1648970488);
		Size size62 = new Size(45, 16);
		textBox_2.Size = size62;
		textBox_2.TabIndex = 59;
		textBox_2.Text = Class16.smethod_0(1648924112);
		textBox_2.TextChanged += textBox_0_TextChanged;
		textBox_2.KeyUp += textBox_0_KeyUp;
		textBox_2.Leave += textBox_0_Leave;
		Color backColor9 = Color.FromArgb(20, 30, 37);
		textBox_3.BackColor = backColor9;
		textBox_3.BorderStyle = BorderStyle.None;
		textBox_3.Enabled = false;
		textBox_3.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		Color foreColor20 = Color.FromArgb(240, 240, 240);
		textBox_3.ForeColor = foreColor20;
		Point location57 = new Point(232, 60);
		textBox_3.Location = location57;
		textBox_3.Name = Class16.smethod_0(1648970508);
		Size size63 = new Size(47, 16);
		textBox_3.Size = size63;
		textBox_3.TabIndex = 58;
		textBox_3.Text = Class16.smethod_0(1648924112);
		textBox_3.TextChanged += textBox_0_TextChanged;
		textBox_3.KeyUp += textBox_0_KeyUp;
		textBox_3.Leave += textBox_0_Leave;
		Color backColor10 = Color.FromArgb(20, 30, 37);
		textBox_4.BackColor = backColor10;
		textBox_4.BorderStyle = BorderStyle.None;
		textBox_4.Enabled = false;
		textBox_4.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		Color foreColor21 = Color.FromArgb(240, 240, 240);
		textBox_4.ForeColor = foreColor21;
		Point location58 = new Point(162, 60);
		textBox_4.Location = location58;
		textBox_4.Name = Class16.smethod_0(1648970512);
		Size size64 = new Size(45, 16);
		textBox_4.Size = size64;
		textBox_4.TabIndex = 57;
		textBox_4.Text = Class16.smethod_0(1648924112);
		textBox_4.TextChanged += textBox_0_TextChanged;
		textBox_4.KeyUp += textBox_0_KeyUp;
		textBox_4.Leave += textBox_0_Leave;
		Color backColor11 = Color.FromArgb(20, 30, 37);
		textBox_5.BackColor = backColor11;
		textBox_5.BorderStyle = BorderStyle.None;
		textBox_5.Enabled = false;
		textBox_5.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		Color foreColor22 = Color.FromArgb(240, 240, 240);
		textBox_5.ForeColor = foreColor22;
		Point location59 = new Point(93, 111);
		textBox_5.Location = location59;
		textBox_5.Name = Class16.smethod_0(1648970532);
		Size size65 = new Size(47, 16);
		textBox_5.Size = size65;
		textBox_5.TabIndex = 56;
		textBox_5.Text = Class16.smethod_0(1648924112);
		textBox_5.TextChanged += textBox_0_TextChanged;
		textBox_5.KeyUp += textBox_0_KeyUp;
		textBox_5.Leave += textBox_0_Leave;
		Color backColor12 = Color.FromArgb(20, 30, 37);
		textBox_6.BackColor = backColor12;
		textBox_6.BorderStyle = BorderStyle.None;
		textBox_6.Enabled = false;
		textBox_6.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		Color foreColor23 = Color.FromArgb(240, 240, 240);
		textBox_6.ForeColor = foreColor23;
		Point location60 = new Point(25, 111);
		textBox_6.Location = location60;
		textBox_6.Name = Class16.smethod_0(1648970536);
		Size size66 = new Size(45, 16);
		textBox_6.Size = size66;
		textBox_6.TabIndex = 55;
		textBox_6.Text = Class16.smethod_0(1648924112);
		textBox_6.TextChanged += textBox_0_TextChanged;
		textBox_6.KeyUp += textBox_0_KeyUp;
		textBox_6.Leave += textBox_0_Leave;
		Color backColor13 = Color.FromArgb(20, 30, 37);
		textBox_7.BackColor = backColor13;
		textBox_7.BorderStyle = BorderStyle.None;
		textBox_7.Enabled = false;
		textBox_7.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		Color foreColor24 = Color.FromArgb(240, 240, 240);
		textBox_7.ForeColor = foreColor24;
		Point location61 = new Point(93, 60);
		textBox_7.Location = location61;
		textBox_7.Name = Class16.smethod_0(1648970556);
		Size size67 = new Size(47, 16);
		textBox_7.Size = size67;
		textBox_7.TabIndex = 54;
		textBox_7.Text = Class16.smethod_0(1648924112);
		textBox_7.TextChanged += textBox_0_TextChanged;
		textBox_7.KeyUp += textBox_0_KeyUp;
		textBox_7.Leave += textBox_0_Leave;
		Color backColor14 = Color.FromArgb(20, 30, 37);
		textBox_0.BackColor = backColor14;
		textBox_0.BorderStyle = BorderStyle.None;
		textBox_0.Enabled = false;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		Color foreColor25 = Color.FromArgb(240, 240, 240);
		textBox_0.ForeColor = foreColor25;
		Point location62 = new Point(25, 60);
		textBox_0.Location = location62;
		textBox_0.Name = Class16.smethod_0(1648970560);
		Size size68 = new Size(45, 16);
		textBox_0.Size = size68;
		textBox_0.TabIndex = 53;
		textBox_0.Text = Class16.smethod_0(1648924112);
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.KeyUp += textBox_0_KeyUp;
		textBox_0.Leave += textBox_0_Leave;
		pictureBox_44.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_44.Enabled = false;
		pictureBox_44.Image = Resources.ResultIcon;
		Point location63 = new Point(86, 154);
		pictureBox_44.Location = location63;
		pictureBox_44.Name = Class16.smethod_0(1648970580);
		Size size69 = new Size(32, 32);
		pictureBox_44.Size = size69;
		pictureBox_44.TabIndex = 52;
		pictureBox_44.TabStop = false;
		pictureBox_44.DoubleClick += pictureBox_44_DoubleClick;
		pictureBox_44.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_44.MouseHover += pictureBox_44_MouseHover;
		pictureBox_44.MouseUp += pictureBox_37_MouseUp;
		pictureBox_40.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_40.Image = Resources.rcell7;
		Point location64 = new Point(222, 77);
		pictureBox_40.Location = location64;
		pictureBox_40.Name = Class16.smethod_0(1648970597);
		Size size70 = new Size(32, 32);
		pictureBox_40.Size = size70;
		pictureBox_40.TabIndex = 51;
		pictureBox_40.TabStop = false;
		pictureBox_40.DoubleClick += pictureBox_37_DoubleClick;
		pictureBox_40.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_40.MouseHover += pictureBox_37_MouseHover;
		pictureBox_40.MouseUp += pictureBox_37_MouseUp;
		pictureBox_41.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_41.Image = Resources.rcell6;
		Point location65 = new Point(153, 77);
		pictureBox_41.Location = location65;
		pictureBox_41.Name = Class16.smethod_0(1648970602);
		Size size71 = new Size(32, 32);
		pictureBox_41.Size = size71;
		pictureBox_41.TabIndex = 50;
		pictureBox_41.TabStop = false;
		pictureBox_41.DoubleClick += pictureBox_37_DoubleClick;
		pictureBox_41.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_41.MouseHover += pictureBox_37_MouseHover;
		pictureBox_41.MouseUp += pictureBox_37_MouseUp;
		pictureBox_42.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_42.Image = Resources.rcell3;
		Point location66 = new Point(223, 25);
		pictureBox_42.Location = location66;
		pictureBox_42.Name = Class16.smethod_0(1648970623);
		Size size72 = new Size(32, 32);
		pictureBox_42.Size = size72;
		pictureBox_42.TabIndex = 49;
		pictureBox_42.TabStop = false;
		pictureBox_42.DoubleClick += pictureBox_37_DoubleClick;
		pictureBox_42.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_42.MouseHover += pictureBox_37_MouseHover;
		pictureBox_42.MouseUp += pictureBox_37_MouseUp;
		pictureBox_43.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_43.Image = Resources.rcell2;
		Point location67 = new Point(153, 25);
		pictureBox_43.Location = location67;
		pictureBox_43.Name = Class16.smethod_0(1648970636);
		Size size73 = new Size(32, 32);
		pictureBox_43.Size = size73;
		pictureBox_43.TabIndex = 48;
		pictureBox_43.TabStop = false;
		pictureBox_43.DoubleClick += pictureBox_37_DoubleClick;
		pictureBox_43.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_43.MouseHover += pictureBox_37_MouseHover;
		pictureBox_43.MouseUp += pictureBox_37_MouseUp;
		pictureBox_38.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_38.Image = Resources.rcell5;
		Point location68 = new Point(84, 77);
		pictureBox_38.Location = location68;
		pictureBox_38.Name = Class16.smethod_0(1648970641);
		Size size74 = new Size(32, 32);
		pictureBox_38.Size = size74;
		pictureBox_38.TabIndex = 47;
		pictureBox_38.TabStop = false;
		pictureBox_38.DoubleClick += pictureBox_37_DoubleClick;
		pictureBox_38.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_38.MouseHover += pictureBox_37_MouseHover;
		pictureBox_38.MouseUp += pictureBox_37_MouseUp;
		pictureBox_39.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_39.Image = Resources.rcell4;
		Point location69 = new Point(17, 77);
		pictureBox_39.Location = location69;
		pictureBox_39.Name = Class16.smethod_0(1648970662);
		Size size75 = new Size(32, 32);
		pictureBox_39.Size = size75;
		pictureBox_39.TabIndex = 46;
		pictureBox_39.TabStop = false;
		pictureBox_39.DoubleClick += pictureBox_37_DoubleClick;
		pictureBox_39.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_39.MouseHover += pictureBox_37_MouseHover;
		pictureBox_39.MouseUp += pictureBox_37_MouseUp;
		pictureBox_36.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_36.Image = Resources.rcell1;
		Point location70 = new Point(84, 25);
		pictureBox_36.Location = location70;
		pictureBox_36.Name = Class16.smethod_0(1648970667);
		Size size76 = new Size(32, 32);
		pictureBox_36.Size = size76;
		pictureBox_36.TabIndex = 45;
		pictureBox_36.TabStop = false;
		pictureBox_36.DoubleClick += pictureBox_37_DoubleClick;
		pictureBox_36.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_36.MouseHover += pictureBox_37_MouseHover;
		pictureBox_36.MouseUp += pictureBox_37_MouseUp;
		pictureBox_37.ContextMenuStrip = contextMenuStrip_0;
		pictureBox_37.Image = Resources.rcell0;
		Point location71 = new Point(17, 25);
		pictureBox_37.Location = location71;
		pictureBox_37.Name = Class16.smethod_0(1648970680);
		Size size77 = new Size(32, 32);
		pictureBox_37.Size = size77;
		pictureBox_37.TabIndex = 44;
		pictureBox_37.TabStop = false;
		pictureBox_37.DoubleClick += pictureBox_37_DoubleClick;
		pictureBox_37.MouseLeave += pictureBox_37_MouseLeave;
		pictureBox_37.MouseHover += pictureBox_37_MouseHover;
		pictureBox_37.MouseUp += pictureBox_37_MouseUp;
		label_15.AutoSize = true;
		Color backColor15 = Color.FromArgb(14, 24, 34);
		label_15.BackColor = backColor15;
		label_15.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		Color foreColor26 = Color.FromArgb(239, 191, 72);
		label_15.ForeColor = foreColor26;
		Point location72 = new Point(14, 6);
		label_15.Location = location72;
		label_15.Name = Class16.smethod_0(1648970701);
		Size size78 = new Size(48, 13);
		label_15.Size = size78;
		label_15.TabIndex = 3;
		label_15.Text = Class16.smethod_0(1648970716);
		label_15.Visible = false;
		Color transparent3 = Color.Transparent;
		label_12.BackColor = transparent3;
		label_12.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		Color foreColor27 = Color.FromArgb(239, 191, 72);
		label_12.ForeColor = foreColor27;
		Point location73 = new Point(10, 136);
		label_12.Location = location73;
		label_12.Name = Class16.smethod_0(1648970721);
		Size size79 = new Size(46, 13);
		label_12.Size = size79;
		label_12.TabIndex = 2;
		label_12.Text = Class16.smethod_0(1648970736);
		label_12.TextAlign = ContentAlignment.MiddleRight;
		label_10.AutoSize = true;
		Color transparent4 = Color.Transparent;
		label_10.BackColor = transparent4;
		label_10.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		Color foreColor28 = Color.FromArgb(239, 191, 72);
		label_10.ForeColor = foreColor28;
		Point location74 = new Point(185, 136);
		label_10.Location = location74;
		label_10.Name = Class16.smethod_0(1648969732);
		Size size80 = new Size(21, 13);
		label_10.Size = size80;
		label_10.TabIndex = 1;
		label_10.Text = Class16.smethod_0(1648969736);
		label_11.AutoSize = true;
		Color transparent5 = Color.Transparent;
		label_11.BackColor = transparent5;
		label_11.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		Color foreColor29 = Color.FromArgb(239, 191, 72);
		label_11.ForeColor = foreColor29;
		Point location75 = new Point(120, 154);
		label_11.Location = location75;
		label_11.Name = Class16.smethod_0(1648969746);
		Size size81 = new Size(55, 13);
		label_11.Size = size81;
		label_11.TabIndex = 0;
		label_11.Text = Class16.smethod_0(1648969762);
		pictureBox_48.Dock = DockStyle.Fill;
		pictureBox_48.Image = Resources.RecipesPreview_pictureBox4;
		Point location76 = new Point(0, 0);
		pictureBox_48.Location = location76;
		pictureBox_48.Name = Class16.smethod_0(1648976974);
		Size size82 = new Size(302, 212);
		pictureBox_48.Size = size82;
		pictureBox_48.TabIndex = 65;
		pictureBox_48.TabStop = false;
		pictureBox_48.MouseDown += RecipesPreview_MouseDown;
		pictureBox_48.MouseMove += RecipesPreview_MouseMove;
		pictureBox_48.MouseUp += RecipesPreview_MouseUp;
		label_23.Font = new Font(Class16.smethod_0(1648942905), 81.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color foreColor30 = Color.FromArgb(20, 37, 47);
		label_23.ForeColor = foreColor30;
		Point location77 = new Point(6, 25);
		label_23.Location = location77;
		label_23.Name = Class16.smethod_0(1648969781);
		Size size83 = new Size(286, 126);
		label_23.Size = size83;
		label_23.TabIndex = 66;
		label_23.Text = Class16.smethod_0(1648978611);
		label_23.TextAlign = ContentAlignment.MiddleCenter;
		label_23.Visible = false;
		panel_2.BackgroundImageLayout = ImageLayout.None;
		Label value75 = label_13;
		panel_2.Controls.Add(value75);
		Label value76 = label_14;
		panel_2.Controls.Add(value76);
		PictureBox value77 = pictureBox_47;
		panel_2.Controls.Add(value77);
		Point location78 = new Point(13, 32);
		panel_2.Location = location78;
		panel_2.Name = Class16.smethod_0(1648969795);
		Size size84 = new Size(299, 27);
		panel_2.Size = size84;
		panel_2.TabIndex = 8;
		panel_2.MouseDown += RecipesPreview_MouseDown;
		panel_2.MouseMove += RecipesPreview_MouseMove;
		panel_2.MouseUp += RecipesPreview_MouseUp;
		label_13.AutoSize = true;
		Color transparent6 = Color.Transparent;
		label_13.BackColor = transparent6;
		label_13.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		Color foreColor31 = Color.FromArgb(239, 191, 72);
		label_13.ForeColor = foreColor31;
		Point location79 = new Point(153, 5);
		label_13.Location = location79;
		label_13.Name = Class16.smethod_0(1648969808);
		Size size85 = new Size(21, 13);
		label_13.Size = size85;
		label_13.TabIndex = 4;
		label_13.Text = Class16.smethod_0(1648969736);
		label_14.AutoSize = true;
		Color transparent7 = Color.Transparent;
		label_14.BackColor = transparent7;
		label_14.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		Color foreColor32 = Color.FromArgb(239, 191, 72);
		label_14.ForeColor = foreColor32;
		Point location80 = new Point(12, 5);
		label_14.Location = location80;
		label_14.Name = Class16.smethod_0(1648969839);
		Size size86 = new Size(54, 13);
		label_14.Size = size86;
		label_14.TabIndex = 3;
		label_14.Text = Class16.smethod_0(1648969851);
		pictureBox_47.Dock = DockStyle.Fill;
		pictureBox_47.Image = Resources.RecipesPreview_pictureBox2;
		Point location81 = new Point(0, 0);
		pictureBox_47.Location = location81;
		pictureBox_47.Name = Class16.smethod_0(1648977021);
		Size size87 = new Size(299, 27);
		pictureBox_47.Size = size87;
		pictureBox_47.TabIndex = 5;
		pictureBox_47.TabStop = false;
		pictureBox_47.MouseDown += RecipesPreview_MouseDown;
		pictureBox_47.MouseMove += RecipesPreview_MouseMove;
		pictureBox_47.MouseUp += RecipesPreview_MouseUp;
		pictureBox_0.Image = Resources.RecipesPreview_picExit_normal;
		Point location82 = new Point(12, 10);
		pictureBox_0.Location = location82;
		pictureBox_0.Name = Class16.smethod_0(1648987968);
		Size size88 = new Size(16, 16);
		pictureBox_0.Size = size88;
		pictureBox_0.TabIndex = 9;
		pictureBox_0.TabStop = false;
		pictureBox_0.Visible = false;
		pictureBox_1.Image = Resources.RecipesPreview_picExit_mousemove;
		Point location83 = new Point(34, 10);
		pictureBox_1.Location = location83;
		pictureBox_1.Name = Class16.smethod_0(1648987997);
		Size size89 = new Size(16, 16);
		pictureBox_1.Size = size89;
		pictureBox_1.TabIndex = 10;
		pictureBox_1.TabStop = false;
		pictureBox_1.Visible = false;
		pictureBox_2.Image = Resources.RecipesPreview_picExit;
		Point location84 = new Point(301, 10);
		pictureBox_2.Location = location84;
		pictureBox_2.Name = Class16.smethod_0(1648988021);
		Size size90 = new Size(16, 16);
		pictureBox_2.Size = size90;
		pictureBox_2.TabIndex = 11;
		pictureBox_2.TabStop = false;
		pictureBox_2.Click += pictureBox_2_Click;
		pictureBox_2.MouseEnter += pictureBox_2_MouseEnter;
		pictureBox_2.MouseLeave += pictureBox_2_MouseLeave;
		label_8.Font = new Font(Class16.smethod_0(1648942905), 9.75f);
		Color foreColor33 = Color.FromArgb(119, 119, 94);
		label_8.ForeColor = foreColor33;
		label_8.Image = Resources.label8;
		Point location85 = new Point(166, 465);
		label_8.Location = location85;
		label_8.Name = Class16.smethod_0(1648925008);
		Size size91 = new Size(65, 22);
		label_8.Size = size91;
		label_8.TabIndex = 18;
		label_8.Text = Class16.smethod_0(1648941799);
		label_8.TextAlign = ContentAlignment.MiddleCenter;
		label_9.Font = new Font(Class16.smethod_0(1648942905), 9.75f);
		Color foreColor34 = Color.FromArgb(119, 119, 94);
		label_9.ForeColor = foreColor34;
		label_9.Image = Resources.label9;
		Point location86 = new Point(97, 465);
		label_9.Location = location86;
		label_9.Name = Class16.smethod_0(1648925100);
		Size size92 = new Size(65, 22);
		label_9.Size = size92;
		label_9.TabIndex = 17;
		label_9.Text = Class16.smethod_0(1648969876);
		label_9.TextAlign = ContentAlignment.MiddleCenter;
		label_16.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Bold);
		Color foreColor35 = Color.FromArgb(240, 240, 240);
		label_16.ForeColor = foreColor35;
		label_16.Image = Resources.TabButton_mouseenter;
		Point location87 = new Point(305, 89);
		label_16.Location = location87;
		label_16.Name = Class16.smethod_0(1648969887);
		Size size93 = new Size(65, 22);
		label_16.Size = size93;
		label_16.TabIndex = 18;
		label_16.TextAlign = ContentAlignment.MiddleCenter;
		label_16.Visible = false;
		label_17.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Bold);
		Color foreColor36 = Color.FromArgb(240, 240, 240);
		label_17.ForeColor = foreColor36;
		label_17.Image = Resources.TabButton_normal;
		Point location88 = new Point(305, 66);
		label_17.Location = location88;
		label_17.Name = Class16.smethod_0(1648969906);
		Size size94 = new Size(65, 22);
		label_17.Size = size94;
		label_17.TabIndex = 17;
		label_17.TextAlign = ContentAlignment.MiddleCenter;
		label_17.Visible = false;
		label_18.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Bold);
		Color foreColor37 = Color.FromArgb(240, 240, 240);
		label_18.ForeColor = foreColor37;
		label_18.Image = Resources.TabButton_mousedown;
		Point location89 = new Point(305, 111);
		label_18.Location = location89;
		label_18.Name = Class16.smethod_0(1648969929);
		Size size95 = new Size(65, 22);
		label_18.Size = size95;
		label_18.TabIndex = 19;
		label_18.TextAlign = ContentAlignment.MiddleCenter;
		label_18.Visible = false;
		ToolStripItem[] toolStripItems2 = new ToolStripItem[2] { toolStripMenuItem_4, toolStripMenuItem_5 };
		menuStrip_0.Items.AddRange(toolStripItems2);
		Point location90 = new Point(0, 0);
		menuStrip_0.Location = location90;
		menuStrip_0.Name = Class16.smethod_0(1648888303);
		Size size96 = new Size(326, 24);
		menuStrip_0.Size = size96;
		menuStrip_0.TabIndex = 20;
		menuStrip_0.Visible = false;
		toolStripMenuItem_4.Name = Class16.smethod_0(1648969955);
		toolStripMenuItem_4.ShortcutKeys = Keys.Z | Keys.Control;
		Size size97 = new Size(73, 20);
		toolStripMenuItem_4.Size = size97;
		toolStripMenuItem_4.Text = Class16.smethod_0(1648941799);
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		toolStripMenuItem_5.Name = Class16.smethod_0(1648969969);
		toolStripMenuItem_5.ShortcutKeys = Keys.Y | Keys.Control;
		Size size98 = new Size(63, 20);
		toolStripMenuItem_5.Size = size98;
		toolStripMenuItem_5.Text = Class16.smethod_0(1648969991);
		toolStripMenuItem_5.Click += toolStripMenuItem_5_Click;
		pictureBox_45.Dock = DockStyle.Fill;
		pictureBox_45.Image = Resources.picBackground;
		Point location91 = new Point(0, 0);
		pictureBox_45.Location = location91;
		pictureBox_45.Name = Class16.smethod_0(1648987386);
		Size size99 = new Size(326, 496);
		pictureBox_45.Size = size99;
		pictureBox_45.SizeMode = PictureBoxSizeMode.AutoSize;
		pictureBox_45.TabIndex = 49;
		pictureBox_45.TabStop = false;
		pictureBox_45.MouseDown += RecipesPreview_MouseDown;
		pictureBox_45.MouseMove += RecipesPreview_MouseMove;
		pictureBox_45.MouseUp += RecipesPreview_MouseUp;
		pictureBox_49.Image = Resources.DragImage;
		Point location92 = new Point(308, 175);
		pictureBox_49.Location = location92;
		pictureBox_49.Name = Class16.smethod_0(1648970004);
		Size size100 = new Size(32, 32);
		pictureBox_49.Size = size100;
		pictureBox_49.TabIndex = 49;
		pictureBox_49.TabStop = false;
		pictureBox_49.Visible = false;
		timer_0.Interval = 200;
		timer_0.Tick += timer_0_Tick;
		label_21.AutoSize = true;
		Color backColor16 = Color.FromArgb(50, 54, 66);
		label_21.BackColor = backColor16;
		label_21.Cursor = Cursors.Hand;
		label_21.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold | FontStyle.Underline);
		Color foreColor38 = Color.FromArgb(239, 191, 72);
		label_21.ForeColor = foreColor38;
		Point location93 = new Point(284, 9);
		label_21.Location = location93;
		label_21.Name = Class16.smethod_0(1648970020);
		Size size101 = new Size(12, 15);
		label_21.Size = size101;
		label_21.TabIndex = 50;
		label_21.Text = Class16.smethod_0(1648942867);
		label_21.Click += label_21_Click;
		Color backColor17 = Color.FromArgb(36, 42, 50);
		label_22.BackColor = backColor17;
		label_22.Font = new Font(Class16.smethod_0(1648942905), 10.5f, FontStyle.Bold);
		Color foreColor39 = Color.FromArgb(239, 191, 72);
		label_22.ForeColor = foreColor39;
		Point location94 = new Point(108, 6);
		label_22.Location = location94;
		label_22.Name = Class16.smethod_0(1648970026);
		Size size102 = new Size(117, 17);
		label_22.Size = size102;
		label_22.TabIndex = 51;
		label_22.Text = Class16.smethod_0(1648992688);
		label_22.TextAlign = ContentAlignment.MiddleCenter;
		label_22.Visible = false;
		label_22.MouseDown += RecipesPreview_MouseDown;
		label_22.MouseMove += RecipesPreview_MouseMove;
		label_22.MouseUp += RecipesPreview_MouseUp;
		AllowDrop = true;
		SizeF sizeF = new SizeF(6f, 13f);
		base.AutoScaleDimensions = sizeF;
		base.AutoScaleMode = AutoScaleMode.Font;
		Color backColor18 = Color.FromArgb(20, 27, 37);
		BackColor = backColor18;
		BackgroundImageLayout = ImageLayout.None;
		Size clientSize = new Size(326, 496);
		base.ClientSize = clientSize;
		Label value78 = label_22;
		base.Controls.Add(value78);
		Label value79 = label_21;
		base.Controls.Add(value79);
		PictureBox value80 = pictureBox_49;
		base.Controls.Add(value80);
		PictureBox value81 = pictureBox_51;
		base.Controls.Add(value81);
		Label value82 = label_18;
		base.Controls.Add(value82);
		Label value83 = label_16;
		base.Controls.Add(value83);
		Label value84 = label_8;
		base.Controls.Add(value84);
		Label value85 = label_17;
		base.Controls.Add(value85);
		Label value86 = label_9;
		base.Controls.Add(value86);
		PictureBox value87 = pictureBox_2;
		base.Controls.Add(value87);
		PictureBox value88 = pictureBox_1;
		base.Controls.Add(value88);
		PictureBox value89 = pictureBox_0;
		base.Controls.Add(value89);
		Panel value90 = panel_2;
		base.Controls.Add(value90);
		Panel value91 = panel_1;
		base.Controls.Add(value91);
		Button value92 = button_0;
		base.Controls.Add(value92);
		Panel value93 = panel_0;
		base.Controls.Add(value93);
		PictureBox value94 = pictureBox_45;
		base.Controls.Add(value94);
		MenuStrip value95 = menuStrip_0;
		base.Controls.Add(value95);
		base.FormBorderStyle = FormBorderStyle.None;
		base.KeyPreview = true;
		base.MainMenuStrip = menuStrip_0;
		base.Name = Class16.smethod_0(1648970043);
		base.Opacity = 0.97;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.Manual;
		Text = Class16.smethod_0(1648970064);
		base.FormClosing += RecipesPreview_FormClosing;
		base.KeyDown += RecipesPreview_KeyDown;
		base.MouseDown += RecipesPreview_MouseDown;
		base.MouseMove += RecipesPreview_MouseMove;
		base.MouseUp += RecipesPreview_MouseUp;
		((ISupportInitialize)pictureBox_51).EndInit();
		panel_1.ResumeLayout(performLayout: false);
		panel_1.PerformLayout();
		((ISupportInitialize)pictureBox_20).EndInit();
		contextMenuStrip_0.ResumeLayout(performLayout: false);
		((ISupportInitialize)pictureBox_21).EndInit();
		((ISupportInitialize)pictureBox_22).EndInit();
		((ISupportInitialize)pictureBox_23).EndInit();
		((ISupportInitialize)pictureBox_24).EndInit();
		((ISupportInitialize)pictureBox_25).EndInit();
		((ISupportInitialize)pictureBox_26).EndInit();
		((ISupportInitialize)pictureBox_27).EndInit();
		((ISupportInitialize)pictureBox_28).EndInit();
		((ISupportInitialize)pictureBox_29).EndInit();
		((ISupportInitialize)pictureBox_30).EndInit();
		((ISupportInitialize)pictureBox_31).EndInit();
		((ISupportInitialize)pictureBox_32).EndInit();
		((ISupportInitialize)pictureBox_33).EndInit();
		((ISupportInitialize)pictureBox_34).EndInit();
		((ISupportInitialize)pictureBox_35).EndInit();
		((ISupportInitialize)pictureBox_5).EndInit();
		((ISupportInitialize)pictureBox_6).EndInit();
		((ISupportInitialize)pictureBox_7).EndInit();
		((ISupportInitialize)pictureBox_8).EndInit();
		((ISupportInitialize)pictureBox_9).EndInit();
		((ISupportInitialize)pictureBox_10).EndInit();
		((ISupportInitialize)pictureBox_11).EndInit();
		((ISupportInitialize)pictureBox_12).EndInit();
		((ISupportInitialize)pictureBox_13).EndInit();
		((ISupportInitialize)pictureBox_14).EndInit();
		((ISupportInitialize)pictureBox_15).EndInit();
		((ISupportInitialize)pictureBox_16).EndInit();
		((ISupportInitialize)pictureBox_17).EndInit();
		((ISupportInitialize)pictureBox_18).EndInit();
		((ISupportInitialize)pictureBox_19).EndInit();
		((ISupportInitialize)pictureBox_4).EndInit();
		((ISupportInitialize)pictureBox_46).EndInit();
		panel_0.ResumeLayout(performLayout: false);
		panel_0.PerformLayout();
		((ISupportInitialize)numericUpDown_1).EndInit();
		((ISupportInitialize)pictureBox_50).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)pictureBox_3).EndInit();
		((ISupportInitialize)pictureBox_44).EndInit();
		((ISupportInitialize)pictureBox_40).EndInit();
		((ISupportInitialize)pictureBox_41).EndInit();
		((ISupportInitialize)pictureBox_42).EndInit();
		((ISupportInitialize)pictureBox_43).EndInit();
		((ISupportInitialize)pictureBox_38).EndInit();
		((ISupportInitialize)pictureBox_39).EndInit();
		((ISupportInitialize)pictureBox_36).EndInit();
		((ISupportInitialize)pictureBox_37).EndInit();
		((ISupportInitialize)pictureBox_48).EndInit();
		panel_2.ResumeLayout(performLayout: false);
		panel_2.PerformLayout();
		((ISupportInitialize)pictureBox_47).EndInit();
		((ISupportInitialize)pictureBox_0).EndInit();
		((ISupportInitialize)pictureBox_1).EndInit();
		((ISupportInitialize)pictureBox_2).EndInit();
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		((ISupportInitialize)pictureBox_45).EndInit();
		((ISupportInitialize)pictureBox_49).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_0();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void RecipesPreview_MouseMove(object sender, MouseEventArgs e)
	{
		if (!ACE.RSGlobal.RSGlobal.antirecurse_RecipesPreview_MouseMove_RecipesPreview)
		{
			ACE.RSGlobal.RSGlobal.antirecurse_RecipesPreview_MouseMove_RecipesPreview = true;
			if (bool_0)
			{
				_ = Cursor;
				Point position = Cursor.Position;
				int num = base.Left - point_0.X;
				base.Left = position.X + num;
				_ = Cursor;
				Point position2 = Cursor.Position;
				int num2 = base.Top - point_0.Y;
				base.Top = position2.Y + num2;
				_ = Cursor;
				Point position3 = Cursor.Position;
				point_0 = position3;
			}
			ACE.RSGlobal.RSGlobal.antirecurse_RecipesPreview_MouseMove_RecipesPreview = false;
			GC.KeepAlive(this);
		}
	}

	private void pictureBox_2_MouseEnter(object sender, EventArgs e)
	{
		pictureBox_2.Image = pictureBox_1.Image;
		GC.KeepAlive(this);
	}

	private void pictureBox_2_MouseLeave(object sender, EventArgs e)
	{
		pictureBox_2.Image = pictureBox_0.Image;
		GC.KeepAlive(this);
	}

	private void pictureBox_2_Click(object sender, EventArgs e)
	{
		RecipesPreview_FormClosing(null, new FormClosingEventArgs(CloseReason.UserClosing, cancel: false));
	}

	private void label_0_MouseEnter(object sender, EventArgs e)
	{
		Label label = (Label)sender;
		if (SelectedTabIndex != method_2(label))
		{
			label.Image = label_16.Image;
		}
		GC.KeepAlive(this);
	}

	private void label_0_MouseLeave(object sender, EventArgs e)
	{
		Label label = (Label)sender;
		if (SelectedTabIndex != method_2(label))
		{
			label.Image = label_17.Image;
		}
		GC.KeepAlive(this);
	}

	private void label_0_MouseDown(object sender, MouseEventArgs e)
	{
		bool_5 = true;
		Label label_ = (Label)sender;
		int num = method_2(label_);
		if (SelectedTabIndex != num)
		{
			method_4(num);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_TAB, num, 0);
		}
		bool_5 = false;
	}

	private void label_0_Click(object sender, EventArgs e)
	{
	}

	private int method_2(Label label_24)
	{
		int startIndex = label_24.Name.Length - 1;
		int result = Convert.ToInt32(label_24.Name.Substring(startIndex));
		GC.KeepAlive(this);
		return result;
	}

	private void method_3(int int_1, [MarshalAs(UnmanagedType.U1)] bool bool_6)
	{
		SelectedTabIndex = int_1;
		string text = Class16.smethod_0(1648894096);
		if (!(panel_1.Controls[text + int_1] is Label label))
		{
			return;
		}
		SelectedTab = label;
		IntPtr handle = base.Handle;
		if (ACE.RSGlobal.RSGlobal.GetForegroundWindow() == handle)
		{
			label.Focus();
		}
		label.Image = label_18.Image;
		int num = 0;
		do
		{
			if (num != SelectedTabIndex)
			{
				string text2 = Class16.smethod_0(1648894096);
				if (panel_1.Controls[text2 + num] is Label label2)
				{
					label2.Image = label_17.Image;
				}
			}
			num++;
		}
		while (num < 8);
		int num2 = -1;
		byte b = ((!bRecipesPW) ? ((byte)1) : ((byte)0));
		int[] array = method_9(label, b != 0);
		if (array == null)
		{
			if (bool_6)
			{
				method_6(-1);
			}
			return;
		}
		int num3 = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				int int_2 = array[num3];
				int num4 = num3;
				string text3 = Class16.smethod_0(1648971648);
				string text4 = Class16.smethod_0(1648971657);
				if (panel_1.Controls[text4 + num4.ToString(text3)] is PictureBox pictureBox)
				{
					string fieldName = eLC.Lists[ServicePos.int_0].elementFields[int_2];
					bool isNpcCraftRecipe = bRecipesPW
						&& ListType == ItemType.PW_NPC_MAKE_SERVICE
						&& fieldName.StartsWith("pages_", StringComparison.Ordinal)
						&& fieldName.Contains("_id_goods_");
					int referencedId = eLC.GetValueI(ServicePos.int_0, ServicePos.int_1, int_2);
					ITEMPOS iTEMPOS = isNpcCraftRecipe
						? (referencedId > 0 ? eLC.FindItemPos(ItemType.PW_RECIPE_ESSENCE, referencedId) : null)
						: eLC.FindItemPos(ServicePos, int_2);
					pictureBox.Tag = new ITEMPOS_f(iTEMPOS, int_2);
					if (iTEMPOS == null)
					{
						pictureBox.Image = pictureBox_51.Image;
					}
					else
					{
						Image image = eLC.GetIcon(iTEMPOS, bRealSize: false, 32);
						pictureBox.Image = image;
						ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC;
						if (eListCollection2.Game == GAMES.PW && ListType == ItemType.PW_NPC_MAKE_SERVICE)
						{
							ACE.Elements.eList.eList eList2 = eListCollection2.Lists[iTEMPOS.int_0];
							int int_3 = iTEMPOS.int_1;
							int num5 = iTEMPOS.int_0;
							if (eLC.GetValueI(num5, int_3, eList2.get_fields(Class16.smethod_0(1648970107))) != CraftSkillID)
							{
								pictureBox.Image = ACE.RSGlobal.RSGlobal.BlurImage(pictureBox.Image);
							}
						}
						if (num2 < 0)
						{
							num2 = num3;
						}
					}
					num3++;
				}
				else
				{
					num3++;
				}
			}
			while (num3 < (nint)array.LongLength);
		}
		if (bool_6)
		{
			method_6(num2);
		}
	}

	private void method_4(int int_1)
	{
		method_3(int_1, bool_6: true);
	}

	private void pictureBox_4_Click(object sender, EventArgs e)
	{
	}

	private int method_5(PictureBox pictureBox_53)
	{
		int startIndex = pictureBox_53.Name.Length - 2;
		int result = Convert.ToInt32(pictureBox_53.Name.Substring(startIndex));
		GC.KeepAlive(this);
		return result;
	}

	private void method_6(int int_1)
	{
		norefresh = true;
		int num = 0;
		List<int> list = new List<int>();
		int num13;
		if (int_1 > -1)
		{
			int num2 = int_1;
			string text = Class16.smethod_0(1648971648);
			string text2 = Class16.smethod_0(1648971657);
			PictureBox pictureBox = (PictureBox)panel_1.Controls[text2 + num2.ToString(text)];
			if (pictureBox.Tag == null)
			{
				GC.KeepAlive(this);
				return;
			}
			IntPtr handle = base.Handle;
			if (ACE.RSGlobal.RSGlobal.GetForegroundWindow() == handle)
			{
				pictureBox.Focus();
			}
			ITEMPOS itemPos = ((ITEMPOS_f)pictureBox.Tag).ItemPos;
			if (itemPos == null)
			{
				GC.KeepAlive(this);
				return;
			}
			if (bRecipesPW)
			{
				int result_f = -1;
				ITEMPOS iTEMPOS = eLC.GenerateRecipeResult(itemPos, ref result_f, bRandomItem: true);
				if (iTEMPOS == null)
				{
					GC.KeepAlive(this);
					return;
				}
				SelectedCell = pictureBox;
				SelectedCellItem = itemPos;
				Image image = eLC.GetIcon(itemPos, bRealSize: false, 32);
				pictureBox.Image = image;
				ACE.Elements.eList.eList eList2 = eLC.Lists[itemPos.int_0];
				int int_2 = itemPos.int_1;
				int num3 = itemPos.int_0;
				int valueI = eLC.GetValueI(num3, int_2, eList2.get_fields(Class16.smethod_0(1648970107)));
				if (valueI != CraftSkillID)
				{
					pictureBox.Image = ACE.RSGlobal.RSGlobal.BlurImage(pictureBox.Image);
				}
				pictureBox_44.Tag = new ITEMPOS_f(iTEMPOS, result_f);
				Image image2 = eLC.GetIcon(iTEMPOS, bRealSize: false, 32);
				pictureBox_44.Image = image2;
				pictureBox_44.Enabled = true;
				int num4 = eLC.findex(itemPos.int_0, Class16.smethod_0(1648970122));
				string value = eLC.GetValue(itemPos.int_0, itemPos.int_1, num4);
				textBox_8.Text = value;
				textBox_8.Tag = num4;
				textBox_8.Enabled = true;
				int num5 = eLC.findex(itemPos.int_0, Class16.smethod_0(1648970148));
				int valueI2 = eLC.GetValueI(itemPos.int_0, itemPos.int_1, num5);
				numericUpDown_0.Text = valueI2.ToString(Class16.smethod_0(1648909972));
				numericUpDown_0.Tag = num5;
				numericUpDown_0.Enabled = true;
				if (valueI == CraftSkillID)
				{
					if (valueI > 0)
					{
						decimal value2 = valueI;
						label_20.Text = eLC.DecodedValues.DecodeValue(23, value2);
						ACE.Elements.eList.eList eList3 = eLC.Lists[itemPos.int_0];
						int int_3 = itemPos.int_1;
						int num6 = itemPos.int_0;
						int valueI3 = eLC.GetValueI(num6, int_3, eList3.get_fields(Class16.smethod_0(1648970152)));
						label_19.Text = valueI3.ToString();
					}
					else
					{
						label_20.Text = string.Empty;
						label_19.Text = string.Empty;
					}
				}
				else
				{
					string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648970170));
					label_20.Text = text3;
					label_19.Text = string.Empty;
				}
				ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC;
				if (eListCollection2.Version >= 27)
				{
					int int_4 = eListCollection2.Lists[itemPos.int_0].get_fields(Class16.smethod_0(1648970193));
					ITEMPOS iTEMPOS2 = eLC.FindItemPos(itemPos, int_4);
					if (iTEMPOS2 != null)
					{
						pictureBox_37.Enabled = true;
						Image image3 = eLC.GetIcon(iTEMPOS2, bRealSize: false, 32);
						pictureBox_37.Image = image3;
						pictureBox_37.Tag = new ITEMPOS_f(iTEMPOS2, int_4);
						textBox_0.Text = Class16.smethod_0(1648934925);
						textBox_0.Enabled = false;
						num = 1;
					}
				}
				int num7 = 1;
				do
				{
					int num8 = num7;
					ACE.Elements.eList.eList eList4 = eLC.Lists[itemPos.int_0];
					string text4 = Class16.smethod_0(1648986201);
					int num9 = eList4.get_fields(string.Concat(Class16.smethod_0(1648970216) + num8, text4));
					ITEMPOS iTEMPOS3 = eLC.FindItemPos(itemPos, num9);
					if (!(iTEMPOS3 == null))
					{
						string text5 = Class16.smethod_0(1648970233);
						PictureBox pictureBox2 = (PictureBox)panel_0.Controls[text5 + num];
						string text6 = Class16.smethod_0(1648965133);
						TextBox textBox = (TextBox)panel_0.Controls[text6 + num];
						pictureBox2.Enabled = true;
						Image image4 = eLC.GetIcon(iTEMPOS3, bRealSize: false, 32);
						pictureBox2.Image = image4;
						pictureBox2.Tag = new ITEMPOS_f(iTEMPOS3, num9);
						string value3 = eLC.GetValue(itemPos.int_0, itemPos.int_1, num9 + 1);
						textBox.Text = value3;
						textBox.Enabled = true;
						textBox.Tag = num9 + 1;
						num++;
					}
					else
					{
						list.Add(num9);
					}
					if (num == 8)
					{
						break;
					}
					num7++;
				}
				while (num7 <= 32);
			}
			else
			{
				SelectedCellItem = itemPos;
				Image image5 = eLC.GetIcon(itemPos, bRealSize: false, 32);
				pictureBox_44.Image = image5;
				int int_5 = ((ITEMPOS_f)pictureBox.Tag).int_0;
				pictureBox_44.Tag = new ITEMPOS_f(itemPos, int_5);
				textBox_8.Text = Class16.smethod_0(1648934925);
				textBox_8.Enabled = false;
				int num10 = eLC.Lists[itemPos.int_0].get_fields(Class16.smethod_0(1648965136));
				if (num10 > 0)
				{
					uint gamePricePW = (uint)CStorage.GetGamePricePW(eLC.GetValueI(itemPos.int_0, itemPos.int_1, num10));
					if (gamePricePW > 99999)
					{
						uint num11 = gamePricePW;
						numericUpDown_0.Text = num11.ToString(Class16.smethod_0(1648909972));
					}
					else
					{
						uint num12 = gamePricePW;
						numericUpDown_0.Text = num12.ToString();
					}
					numericUpDown_0.Tag = num10;
					numericUpDown_0.Enabled = true;
					num13 = 0;
					goto IL_0784;
				}
				numericUpDown_0.Text = Class16.smethod_0(1648934925);
				numericUpDown_0.Enabled = false;
			}
		}
		else
		{
			pictureBox_44.Image = pictureBox_51.Image;
			pictureBox_44.Tag = null;
			pictureBox_44.Enabled = false;
			textBox_8.Text = string.Empty;
			textBox_8.Enabled = false;
			numericUpDown_0.Text = string.Empty;
			numericUpDown_0.Enabled = false;
		}
		num13 = 0;
		if (num < 8)
		{
			goto IL_0784;
		}
		goto IL_0828;
		IL_0784:
		do
		{
			string text7 = Class16.smethod_0(1648970233);
			PictureBox pictureBox3 = (PictureBox)panel_0.Controls[text7 + (num + num13)];
			string text8 = Class16.smethod_0(1648965133);
			TextBox textBox2 = (TextBox)panel_0.Controls[text8 + (num + num13)];
			pictureBox3.Image = pictureBox_51.Image;
			textBox2.Text = string.Empty;
			textBox2.Enabled = false;
			if (num13 < list.Count)
			{
				pictureBox3.Enabled = true;
				pictureBox3.Tag = new ITEMPOS_f(null, list[num13]);
				int num14 = list[num13] + 1;
				textBox2.Tag = num14;
			}
			else
			{
				pictureBox3.Enabled = false;
			}
			num13++;
		}
		while (num13 + num < 8);
		goto IL_0828;
		IL_0828:
		norefresh = false;
	}

	private void pictureBox_37_MouseLeave(object sender, EventArgs e)
	{
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void pictureBox_4_MouseHover(object sender, EventArgs e)
	{
		if (eLC.Game != GAMES.PW)
		{
			return;
		}
		ITEMPOS itemPos = ((ITEMPOS_f)((PictureBox)sender).Tag).ItemPos;
		if (itemPos != null)
		{
			if (bRecipesPW)
			{
				int result_f = 0;
				ITEMPOS iTEMPOS = eLC.GenerateRecipeResult(itemPos, ref result_f, bRandomItem: true);
				if (iTEMPOS != null && CommonStorage.Params.ToolTipFieldsNumLimit > 0)
				{
					if (HINTS.ToolTipWindow != null)
					{
						HINTS.ShowElementToolTip(((Control)sender).Handle, iTEMPOS, IsShopPrice: false, bUnlimited: false, null);
					}
				}
				else if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
				{
					HINTS.ToolTipWindow.SmoothHide();
				}
			}
			else
			{
				IntPtr handle = ((Control)sender).Handle;
				ItemsToolTip1.ShowItemToolTip(handle, itemPos, IsShopPrice: true, bSmooth: true);
			}
		}
		else if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void pictureBox_37_MouseHover(object sender, EventArgs e)
	{
		PictureBox pictureBox = (PictureBox)sender;
		if (pictureBox.Tag != null)
		{
			ITEMPOS itemPos = ((ITEMPOS_f)pictureBox.Tag).ItemPos;
			if (itemPos != null && CommonStorage.Params.ToolTipFieldsNumLimit > 0)
			{
				if (HINTS.ToolTipWindow != null)
				{
					HINTS.ShowElementToolTip(((Control)sender).Handle, itemPos, IsShopPrice: false, bUnlimited: false, null);
				}
			}
			else if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
			{
				HINTS.ToolTipWindow.SmoothHide();
			}
		}
		GC.KeepAlive(this);
	}

	private void pictureBox_44_MouseHover(object sender, EventArgs e)
	{
		ITEMPOS itemPos = ((ITEMPOS_f)((PictureBox)sender).Tag).ItemPos;
		if (itemPos != null)
		{
			ItemsToolTip1.AnullItem();
			if (HINTS.ToolTipWindow != null)
			{
				HINTS.ShowElementToolTip(((Control)sender).Handle, itemPos, IsShopPrice: false, bUnlimited: false, null);
			}
		}
		else if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void pictureBox_37_MouseUp(object sender, MouseEventArgs e)
	{
		PictureBox pictureBox = (PictureBox)sender;
		IsResultItemContext = false;
		IsRequeiredItemsContext = false;
		toolStripMenuItem_0.Visible = true;
		toolStripSeparator_0.Visible = true;
		toolStripMenuItem_3.Visible = true;
		toolStripMenuItem_1.Visible = true;
		toolStripMenuItem_2.Visible = true;
		string text = Class16.smethod_0(1648970580);
		if (pictureBox.Name == text)
		{
			IsResultItemContext = true;
			toolStripMenuItem_3.Visible = false;
			toolStripMenuItem_1.Visible = false;
		}
		else
		{
			string value = Class16.smethod_0(1648970233);
			if (pictureBox.Name.StartsWith(value))
			{
				IsRequeiredItemsContext = true;
			}
			if (((ITEMPOS_f)pictureBox.Tag).ItemPos != null)
			{
				toolStripMenuItem_3.Visible = false;
			}
			else
			{
				toolStripMenuItem_0.Visible = false;
				toolStripSeparator_0.Visible = false;
				toolStripMenuItem_2.Visible = false;
				toolStripMenuItem_1.Visible = false;
			}
		}
		ContextCell = pictureBox;
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648990174), vars);
			HINTS.ToolTipWindow.ShowToolTip(IntPtr.Zero, text, 3000);
			GC.KeepAlive(this);
			return;
		}
		if (((ITEMPOS_f)ContextCell.Tag).ItemPos != null)
		{
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_LIST, ((ITEMPOS_f)ContextCell.Tag).ItemPos.int_0, 0);
			int int_ = ((ITEMPOS_f)ContextCell.Tag).ItemPos.int_1;
			IntPtr objectPointer = ACE.RSGlobal.RSGlobal.GetObjectPointer(new int[1] { int_ });
			IntPtr handle = ElementsWindow.Handle;
			int int_2 = ((ITEMPOS_f)ContextCell.Tag).ItemPos.int_1;
			ACE.RSGlobal.RSGlobal.SendMessage(handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_ITEMS, new int[1] { int_2 }.Length, objectPointer);
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (norefresh)
		{
			return;
		}
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648990174), vars);
			HINTS.ToolTipWindow.ShowToolTip(IntPtr.Zero, text, 3000);
			GC.KeepAlive(this);
			return;
		}
		Control control = (Control)sender;
		int int_ = (int)control.Tag;
		string text2;
		if (sender.GetType() == typeof(NumericUpDown))
		{
			text2 = ((NumericUpDown)sender).Value.ToString();
		}
		else
		{
			string empty = string.Empty;
			string oldValue = Class16.smethod_0(1648928028);
			text2 = control.Text.Replace(oldValue, empty);
		}
		if (!ACE.RSGlobal.RSGlobal.IsUIntFast(text2))
		{
			GC.KeepAlive(this);
			return;
		}
		ITEMPOS selectedCellItem = SelectedCellItem;
		eLC.SetValue(selectedCellItem.int_0, selectedCellItem.int_1, int_, text2, AutoSaveStage: true);
		bool_1 = true;
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
	}

	private void toolStripMenuItem_5_Click(object sender, EventArgs e)
	{
	}

	private void pictureBox_4_DoubleClick(object sender, EventArgs e)
	{
		PictureBox pictureBox_ = (PictureBox)sender;
		if (method_7(pictureBox_, ServicePos, bool_6: false))
		{
			method_6(method_5(pictureBox_));
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_7(PictureBox pictureBox_53, ITEMPOS itempos_0, [MarshalAs(UnmanagedType.U1)] bool bool_6)
	{
		if (pictureBox_53 != null && !pictureBox_53.IsDisposed && !(itempos_0 == null) && eLC != null && ItemsWindow1 != null && !ItemsWindow1.IsDisposed && !ItemsWindow1.Disposing)
		{
			if (!base.IsDisposed && !base.Disposing && ElementsWindow != null && !ElementsWindow.IsDisposed)
			{
				if (!(pictureBox_53.Tag is ITEMPOS_f iTEMPOS_f))
				{
					return false;
				}
				if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
				{
					object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
					string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648990174), vars);
					if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.IsDisposed && !HINTS.ToolTipWindow.Disposing)
					{
						HINTS.ToolTipWindow.ShowToolTip(IntPtr.Zero, text, 3000);
					}
					GC.KeepAlive(this);
					return false;
				}
				ITEMPOS itemPos = iTEMPOS_f.ItemPos;
				int num = iTEMPOS_f.int_0;
				if (itemPos != null)
				{
					ItemsWindow1.newitemlist = itemPos.int_0;
					ItemsWindow1.newitemindex = itemPos.int_1;
				}
				else
				{
					ItemsWindow1.newitemlist = -1;
					ItemsWindow1.newitemindex = -1;
				}
				ItemsWindow1.newlistsindices = eLC.GetFieldLists(itempos_0.int_0, itempos_0.int_1, num);
				ItemsWindow1.bMultiSelect = false;
				CStorage.ResetBuffer();
				DialogResult dialogResult;
				try
				{
					dialogResult = ItemsWindow1.ShowDialog(this);
				}
				catch (ObjectDisposedException ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1648965153));
					return false;
				}
				catch (InvalidOperationException ex2)
				{
					SentryHelper.CaptureException(ex2, Class16.smethod_0(1648965153));
					return false;
				}
				if (dialogResult == DialogResult.OK)
				{
					if (bool_6 && itemPos == null)
					{
						int num2 = 0;
						do
						{
							string text2 = Class16.smethod_0(1648970233);
							PictureBox pictureBox = (PictureBox)panel_0.Controls[text2 + num2];
							if (((ITEMPOS_f)pictureBox.Tag).ItemPos != null)
							{
								num2++;
								continue;
							}
							pictureBox_53 = pictureBox;
							num = ((ITEMPOS_f)pictureBox.Tag).int_0;
							string text3 = Class16.smethod_0(1648965133);
							TextBox textBox = (TextBox)panel_0.Controls[text3 + num2];
							textBox.Enabled = true;
							textBox.Text = Class16.smethod_0(1648934925);
							break;
						}
						while (num2 < 8);
					}
					if (!int.TryParse(CommonStorage.sData, out var result))
					{
						GC.KeepAlive(this);
						return false;
					}
					itemPos = eLC.FindItemPos(eLC.GetFieldLists(itempos_0.int_0, itempos_0.int_1, num), result);
					if (itemPos == null)
					{
						GC.KeepAlive(this);
						return false;
					}
					int num3 = result;
					string value = num3.ToString();
					eLC.SetValue(itempos_0.int_0, itempos_0.int_1, num, value, AutoSaveStage: true);
					pictureBox_53.Tag = new ITEMPOS_f(itemPos, num);
					Image image = eLC.GetIcon(itemPos, bRealSize: false, 32);
					if (pictureBox_53.IsDisposed)
					{
						return false;
					}
					pictureBox_53.Image = image;
					if (ElementsWindow != null && !ElementsWindow.IsDisposed && ElementsWindow.IsHandleCreated)
					{
						if (ServicePos.Equals(itempos_0))
						{
							ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_FIELD, num, 0);
						}
						else
						{
							ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UPDATE_ELEMENTS_REFERENCES, 0, 0);
						}
						ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_UNDO_REDO, 0, 0);
					}
					GC.KeepAlive(this);
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private void pictureBox_4_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			PictureBox pictureBox = (PictureBox)sender;
			if ((itempos_f_0 = ((ITEMPOS_f)pictureBox.Tag).Clone()).ItemPos != null)
			{
				pictureBox_52 = pictureBox;
				image_0 = new Bitmap(pictureBox.Image);
				PrevCell = null;
				bool_2 = true;
				object[] vars = new object[0];
				eLC.ActionsHistory.SubStagesBegin(-1, null, 163, vars);
				bool_3 = false;
				pictureBox.DoDragDrop(pictureBox.Image, DragDropEffects.Move);
			}
		}
		GC.KeepAlive(this);
	}

	private void pictureBox_4_MouseDown(object sender, MouseEventArgs e)
	{
		PictureBox pictureBox_ = (PictureBox)sender;
		int int_ = method_5(pictureBox_);
		method_6(int_);
	}

	private void pictureBox_4_DragEnter(object sender, DragEventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.antirecurse_Cells_DragEnter_RecipesPreview)
		{
			return;
		}
		if (bool_2 && e.Data.GetDataPresent(DataFormats.Bitmap))
		{
			e.Effect = DragDropEffects.Move;
			PictureBox pictureBox = (PictureBox)sender;
			int num = itempos_f_0.int_0;
			int num2 = ((ITEMPOS_f)pictureBox.Tag).int_0;
			if (num == num2)
			{
				GC.KeepAlive(this);
				return;
			}
			if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
			{
				object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
				string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648990174), vars);
				HINTS.ToolTipWindow.ShowToolTip(IntPtr.Zero, text, 3000);
				GC.KeepAlive(this);
				return;
			}
			ACE.RSGlobal.RSGlobal.antirecurse_Cells_DragEnter_RecipesPreview = true;
			ITEMPOS servicePos = ServicePos;
			string value = eLC.GetValueI(servicePos.int_0, servicePos.int_1, num).ToString();
			ITEMPOS servicePos2 = ServicePos;
			string value2 = eLC.GetValueI(servicePos2.int_0, servicePos2.int_1, num2).ToString();
			int[] itemsindices = new int[1] { ServicePos.int_1 };
			int[] fieldsindices = ACE.RSGlobal.RSGlobal.iarr(num, num2);
			eLC.ActionsHistory.stChangeFields(ServicePos.int_0, itemsindices, fieldsindices, -1, null);
			ITEMPOS servicePos3 = ServicePos;
			eLC.SetValue(servicePos3.int_0, servicePos3.int_1, num, value2, AutoSaveStage: false);
			ITEMPOS servicePos4 = ServicePos;
			eLC.SetValue(servicePos4.int_0, servicePos4.int_1, num2, value, AutoSaveStage: false);
			eLC.ActionsHistory.Complete();
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_FIELD, num, 0);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_FIELD, num2, 0);
			method_3(SelectedTabIndex, bool_6: false);
			pictureBox_52 = pictureBox;
			image_0 = new Bitmap(pictureBox.Image);
			itempos_f_0 = ((ITEMPOS_f)pictureBox.Tag).Clone();
			SelectedCell = pictureBox;
			SelectedCellItem = ((ITEMPOS_f)pictureBox.Tag).ItemPos;
			bool_3 = true;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
		ACE.RSGlobal.RSGlobal.antirecurse_Cells_DragEnter_RecipesPreview = false;
		GC.KeepAlive(this);
	}

	private void pictureBox_4_DragDrop(object sender, DragEventArgs e)
	{
		bool_2 = false;
		if (bool_3)
		{
			eLC.ActionsHistory.SubStagesComplete(-1, null);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_UNDO_REDO, 0, 0);
		}
		else
		{
			eLC.ActionsHistory.CancelLastStage(cancelSuperStage: false);
		}
		GC.KeepAlive(this);
	}

	private void label_0_DragEnter(object sender, DragEventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.ar_Tabs_DragEnter_RecipesPreview)
		{
			return;
		}
		try
		{
			ACE.RSGlobal.RSGlobal.ar_Tabs_DragEnter_RecipesPreview = true;
			Label label = (Label)sender;
			if (bool_2 && e.Data.GetDataPresent(DataFormats.Bitmap))
			{
				if (!bool_4)
				{
					bool_4 = true;
				}
				TabsPaused = true;
				timer_0.Enabled = true;
				while (TabsPaused)
				{
					Application.DoEvents();
				}
				_ = Cursor;
				int num = Cursor.Position.X;
				_ = Cursor;
				int num2 = Cursor.Position.Y;
				int num3 = panel_1.Left + label.Left;
				int num4 = base.Left + num3;
				int num5 = panel_1.Top + label.Top;
				int num6 = base.Top + num5;
				int num7 = label.Width + num4;
				int num8 = label.Height + num6;
				int num9 = ((num - num4 > 0 && num7 - num > 0) ? 1 : 0);
				bool flag = (byte)num9 != 0;
				int num10 = ((num2 - num6 > 0 && num8 - num2 > 0) ? 1 : 0);
				bool flag2 = (byte)num10 != 0;
				int num11 = ((flag && flag2) ? 1 : 0);
				if ((byte)num11 == 0)
				{
					return;
				}
				e.Effect = DragDropEffects.None;
				int num12 = method_2(label);
				if (SelectedTabIndex != num12)
				{
					method_3(method_2(label), bool_6: false);
				}
			}
			else if (e.Data.GetDataPresent(DataFormats.StringFormat))
			{
				e.Effect = DragDropEffects.Move;
				Label selectedTab = SelectedTab;
				if (label == selectedTab)
				{
					return;
				}
				if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
				{
					object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
					string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648990174), vars);
					HINTS.ToolTipWindow.ShowToolTip(IntPtr.Zero, text, 3000);
					return;
				}
				int num13 = ServicePos.int_0;
				int[] array = eLC.GetPageAllFields(num13, method_2(selectedTab)).ToArray();
				int num14 = ServicePos.int_0;
				int[] array2 = eLC.GetPageAllFields(num14, method_2(label)).ToArray();
				int num15 = array[0];
				int num16 = array2[0];
				int num17 = array.Length;
				int[] array3 = new int[num17 << 1];
				Array.Copy(array, 0, array3, 0, num17);
				Array.Copy(array2, 0, array3, num17, num17);
				int int_ = ServicePos.int_1;
				int[] itemsindices = new int[1] { int_ };
				int num18 = ServicePos.int_0;
				eLC.ActionsHistory.stChangeFields(num18, itemsindices, array3, 324, null);
				object[] array4 = new object[2];
				ITEMPOS servicePos = ServicePos;
				string value = eLC.GetValue(servicePos.int_0, servicePos.int_1, num15);
				array4[0] = value;
				ITEMPOS servicePos2 = ServicePos;
				string value2 = eLC.GetValue(servicePos2.int_0, servicePos2.int_1, num16);
				array4[1] = value2;
				eLC.ActionsHistory.Stage.CaptionVars = array4;
				object[] array5 = new object[num17];
				object[] array6 = new object[num17];
				ITEMPOS servicePos3 = ServicePos;
				Array.Copy(eLC.Lists[servicePos3.int_0].elementValues[servicePos3.int_1], num15, array5, 0, num17);
				ITEMPOS servicePos4 = ServicePos;
				Array.Copy(eLC.Lists[servicePos4.int_0].elementValues[servicePos4.int_1], num16, array6, 0, num17);
				ITEMPOS servicePos5 = ServicePos;
				Array.Copy(array5, 0, eLC.Lists[servicePos5.int_0].elementValues[servicePos5.int_1], num16, num17);
				ITEMPOS servicePos6 = ServicePos;
				Array.Copy(array6, 0, eLC.Lists[servicePos6.int_0].elementValues[servicePos6.int_1], num15, num17);
				eLC.ActionsHistory.Complete();
				string text2 = label.Text;
				label.Text = SelectedTab.Text;
				SelectedTab.Text = text2;
				Image image = label.Image;
				label.Image = SelectedTab.Image;
				SelectedTab.Image = image;
				SelectedTab = label;
				SelectedTabIndex = method_2(label);
				IntPtr handle = ElementsWindow.Handle;
				ACE.RSGlobal.RSGlobal.SendMessage(handle, ACE.RSGlobal.RSGlobal.WM_SELECT_TAB, SelectedTabIndex, 0);
				IntPtr handle2 = ElementsWindow.Handle;
				ACE.RSGlobal.RSGlobal.SendMessage(handle2, ACE.RSGlobal.RSGlobal.WM_REFRESH_CURRENT_ITEM, 0, 0);
				IntPtr handle3 = ElementsWindow.Handle;
				ACE.RSGlobal.RSGlobal.SendMessage(handle3, ACE.RSGlobal.RSGlobal.WM_REFRESH_UNDO_REDO, 0, 0);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648965197));
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.ar_Tabs_DragEnter_RecipesPreview = false;
		}
		GC.KeepAlive(this);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		TabsPaused = false;
		timer_0.Enabled = false;
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648990174), vars);
			HINTS.ToolTipWindow.ShowToolTip(IntPtr.Zero, text, 3000);
			GC.KeepAlive(this);
		}
		else if (IsResultItemContext)
		{
			if (method_7(pictureBox_44, SelectedCellItem, bool_6: false))
			{
				method_6(method_5(SelectedCell));
				ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_FIELD, ((ITEMPOS_f)SelectedCell.Tag).int_0, 0);
			}
		}
		else if (IsRequeiredItemsContext)
		{
			method_7(ContextCell, SelectedCellItem, bool_6: true);
		}
		else if (method_7(ContextCell, ServicePos, bool_6: false))
		{
			method_6(method_5(ContextCell));
		}
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648990174), vars);
			HINTS.ToolTipWindow.ShowToolTip(IntPtr.Zero, text, 3000);
			GC.KeepAlive(this);
			return;
		}
		_ = (ITEMPOS_f)ContextCell.Tag;
		int num = ((ITEMPOS_f)ContextCell.Tag).int_0;
		if (IsRequeiredItemsContext)
		{
			int[] itemsindices = new int[1] { SelectedCellItem.int_1 };
			int[] fieldsindices = ACE.RSGlobal.RSGlobal.iarr(num, num + 1);
			eLC.ActionsHistory.stChangeFields(SelectedCellItem.int_0, itemsindices, fieldsindices, 166, null);
			ITEMPOS selectedCellItem = SelectedCellItem;
			eLC.SetValue(selectedCellItem.int_0, selectedCellItem.int_1, num, Class16.smethod_0(1648924112), AutoSaveStage: false);
			ITEMPOS selectedCellItem2 = SelectedCellItem;
			eLC.SetValue(selectedCellItem2.int_0, selectedCellItem2.int_1, num + 1, Class16.smethod_0(1648924112), AutoSaveStage: false);
			eLC.ActionsHistory.Complete();
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_UNDO_REDO, 0, 0);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UPDATE_ELEMENTS_REFERENCES, 0, 0);
			method_6(method_5(SelectedCell));
		}
		else
		{
			ITEMPOS servicePos = ServicePos;
			eLC.SetValue(servicePos.int_0, servicePos.int_1, num, Class16.smethod_0(1648924112), AutoSaveStage: true);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_FIELD, num, 0);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_UNDO_REDO, 0, 0);
			method_4(SelectedTabIndex);
		}
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648990174), vars);
			HINTS.ToolTipWindow.ShowToolTip(IntPtr.Zero, text, 3000);
			GC.KeepAlive(this);
		}
		else if (IsRequeiredItemsContext)
		{
			method_7(ContextCell, SelectedCellItem, bool_6: true);
		}
		else if (method_7(ContextCell, ServicePos, bool_6: false))
		{
			method_6(method_5(ContextCell));
		}
	}

	private void pictureBox_44_DoubleClick(object sender, EventArgs e)
	{
		if (method_7(pictureBox_44, SelectedCellItem, bool_6: false))
		{
			method_6(method_5(SelectedCell));
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_FIELD, ((ITEMPOS_f)SelectedCell.Tag).int_0, 0);
		}
		GC.KeepAlive(this);
	}

	private void pictureBox_37_DoubleClick(object sender, EventArgs e)
	{
		method_7(ContextCell, SelectedCellItem, bool_6: true);
	}

	private void textBox_10_Leave(object sender, EventArgs e)
	{
		method_8(textBox_10.Text);
		textBox_10.Visible = false;
		GC.KeepAlive(this);
	}

	private void textBox_10_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			method_8(textBox_10.Text);
			textBox_10.Visible = false;
		}
		GC.KeepAlive(this);
	}

	private void method_8(string string_0)
	{
		int num = int_0;
		string text = Class16.smethod_0(1648894096);
		Label label = (Label)panel_1.Controls[text + num];
		if (label.Text != string_0)
		{
			if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
			{
				object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
				string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648990174), vars);
				HINTS.ToolTipWindow.ShowToolTip(IntPtr.Zero, text2, 3000);
				GC.KeepAlive(this);
				return;
			}
			int num2 = (int)label.Tag;
			ITEMPOS servicePos = ServicePos;
			eLC.SetValue(servicePos.int_0, servicePos.int_1, num2, string_0, AutoSaveStage: true);
			label.Text = string_0;
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_FIELD, num2, 0);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_UNDO_REDO, 0, 0);
		}
		GC.KeepAlive(this);
	}

	private void label_0_DoubleClick(object sender, EventArgs e)
	{
		Label label = (Label)sender;
		int_0 = method_2(label);
		_ = Cursor;
		Point position = Cursor.Position;
		int left = panel_1.Left;
		int left2 = -20 - left - base.Left + position.X;
		textBox_10.Left = left2;
		_ = Cursor;
		Point position2 = Cursor.Position;
		int top = panel_1.Top;
		int top2 = 10 - top - base.Top + position2.Y;
		textBox_10.Top = top2;
		textBox_10.Text = label.Text;
		textBox_10.Visible = true;
		textBox_10.Focus();
		textBox_10.SelectAll();
		GC.KeepAlive(this);
	}

	private void label_21_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(167, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void textBox_0_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			SelectedCell?.Focus();
		}
		GC.KeepAlive(this);
	}

	private void RecipesPreview_KeyDown(object sender, KeyEventArgs e)
	{
	}

	private void label_0_MouseMove(object sender, MouseEventArgs e)
	{
		if (!bool_5 && e.Button == MouseButtons.Left)
		{
			if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
			{
				object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
				string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648990174), vars);
				HINTS.ToolTipWindow.ShowToolTip(IntPtr.Zero, text, 3000);
				GC.KeepAlive(this);
			}
			else
			{
				Label label = (Label)sender;
				label.DoDragDrop(label.Text, DragDropEffects.Move);
				GC.KeepAlive(this);
			}
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private int[] method_9(Label label_24, [MarshalAs(UnmanagedType.U1)] bool bool_6)
	{
		List<int> list = new List<int>();
		if (label_24 != null && label_24.Tag != null)
		{
			int num = 0;
			int num2 = (int)label_24.Tag;
			if (num2 < eLC.GetFieldsCount(ServicePos.int_0))
			{
				do
				{
					ITEMPOS servicePos = ServicePos;
					FIELDTYPE fieldType = eLC.GetFieldType(servicePos.int_0, servicePos.int_1, num2);
					string fieldName = eLC.Lists[ServicePos.int_0].elementFields[num2];
					bool flag2 = bRecipesPW && ListType == ItemType.PW_NPC_MAKE_SERVICE && fieldName.StartsWith("pages_", StringComparison.Ordinal) && fieldName.Contains("_id_goods_");
					if (fieldType < FIELDTYPE.matters && !flag2)
					{
						goto IL_0046;
					}
					ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC;
					bool flag;
					if (eListCollection2.Game == GAMES.JD)
					{
						int num3 = ServicePos.int_0;
						if (num3 == eListCollection2.get_LI(Class16.smethod_0(1648965225)))
						{
							flag = eLC.Lists[num3].elementFields[num2].EndsWith(Class16.smethod_0(1648965249));
							goto IL_0118;
						}
					}
					ACE.Elements.eListCollection.eListCollection eListCollection3 = eLC;
					GAMES game = eListCollection3.Game;
					flag = ((game == GAMES.SW || game == GAMES.ROG || game == GAMES.TOS) ? eListCollection3.Lists[ServicePos.int_0].elementFields[num2].EndsWith(Class16.smethod_0(1648965264)) : (flag2 || fieldType == FIELDTYPE.matters));
					goto IL_0118;
					IL_0118:
					int num4 = ((flag || !bool_6) ? 1 : 0);
					if ((byte)num4 != 0)
					{
						list.Add(num2);
						num++;
						if (num == 32)
						{
							break;
						}
					}
					goto IL_0046;
					IL_0046:
					num2++;
				}
				while (num2 < eLC.GetFieldsCount(ServicePos.int_0));
			}
			int[] result = list.ToArray();
			GC.KeepAlive(this);
			return result;
		}
		return list.ToArray();
	}

	private int[] method_10(int int_1, [MarshalAs(UnmanagedType.U1)] bool bool_6)
	{
		string text = Class16.smethod_0(1648894096);
		Panel panel = panel_1;
		if (!(panel.Controls[text + int_1] is Label label_))
		{
			return Array.Empty<int>();
		}
		int[] result = method_9(label_, bool_6);
		GC.KeepAlive(this);
		return result;
	}

	private void label_0_DragDrop(object sender, DragEventArgs e)
	{
		if (e.Effect == DragDropEffects.Move)
		{
			Label label_ = (Label)sender;
			int wparam = method_2(label_);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_TAB, wparam, 0);
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
		if (bool_1)
		{
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_UNDO_REDO, 0, 0);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UPDATE_ELEMENTS_REFERENCES, 0, 0);
			bool_1 = false;
		}
	}

	private void label_0_TextChanged(object sender, EventArgs e)
	{
		Label label = (Label)sender;
		Font font = font_0;
		Font font2 = ((TextRenderer.MeasureText(label.Text, font).Width >= label.Width) ? font_1 : font_0);
		label.Font = font2;
		GC.KeepAlive(this);
	}
}
