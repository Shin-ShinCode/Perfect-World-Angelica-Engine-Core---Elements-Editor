using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.Cpk;
using ACE.Elements;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.FastImageSelector;
using ACE.License;
using ACE.Pck;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.Settings;
using ACE.sTASKedit.Classes;
using Sentry;

namespace ACE.GShop;

public class GShopEditor_PW : Form
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct Struct59
	{
		public static int int_0 = 0;

		public static int int_1 = 1;

		public static int int_2 = 2;

		public static int int_3 = 3;

		public static int int_4 = 4;

		public static int int_5 = 5;

		public static int int_6 = 6;
	}

	public enum CONTROL_TYPE
	{
		Client = -1,
		Server
	}

	public enum FILTER_MODE
	{
		None,
		Search,
		NotFoundedItems,
		WithCount0,
		NotFoundedIcons,
		WithVeryLongName,
		WithFullDescription,
		WithBuggedPileNum,
		WithEqualsItemID,
		WithEqualsItemName,
		ShowFashionSubCat9
	}

	public PCK_LIST PCKs;

	public bool OriginalOrderChanged;

	public int GoodsCounter;

	public int FocusedCatDeep;

	public FILTER_MODE FilterMode;

	public List<int> SearchResults;

	public SettingsClass Profile;

	public bool LoadingComplete;

	public Form ElementsWindow;

	public ItemsToolTip ItemsToolTip1;

	public bool bSurfacesLoaded;

	public ICONS ShopIcons;

	public IconsWindow ShopIconsWindow;

	public bool IsFileChanged;

	public bool DontChange;

	public eListCollection eLC;

	public ItemsWindow ItemsWindow1;

	public TasksWindow TasksWindow1;

	public CommonStorage CStorage;

	public int SelectedItemIndex;

	public GSHOP_ITEM_PW pwGItem;

	public int RowIndexUnderCursor;

	public int SelectedCatIndex;

	public int SelectedSubCatIndex;

	public bool bFashionSubCat9Exists;

	public bool WindowLoaded;

	public string FileName;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_0;

	private ToolTip toolTip_0;

	private DataGridViewEx dataGridViewEx_0;

	private Button button_2;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private Panel panel_0;

	private GroupBox groupBox_0;

	private PictureBox pictureBox_0;

	private TextBox textBox_1;

	private PictureBox pictureBox_1;

	private NumericUpDownEx numericUpDownEx_0;

	private Button button_3;

	private TextBox textBox_2;

	private BackgroundWorker backgroundWorker_0;

	private TextBox textBox_3;

	private Label label_0;

	private CheckBox checkBox_0;

	private GroupBox groupBox_1;

	private NumericUpDownEx numericUpDownEx_1;

	private Label label_1;

	private Label label_2;

	private TextBox textBox_4;

	private NumericUpDownEx numericUpDownEx_2;

	private Label label_3;

	private Label label_4;

	private GroupBox groupBox_2;

	private GroupBox groupBox_3;

	private GroupBox groupBox_4;

	private PictureBox pictureBox_2;

	private NumericUpDownEx numericUpDownEx_3;

	private ToolTip toolTip_1;

	private Label label_5;

	private DateTimePicker dateTimePicker_0;

	private DateTimePicker dateTimePicker_1;

	private Label label_6;

	private Timer timer_0;

	private ColorDialog colorDialog_0;

	private StatusStrip statusStrip_0;

	private ToolStripProgressBar toolStripProgressBar_0;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripMenuItem toolStripMenuItem_3;

	private TextBox textBox_5;

	private NumericUpDownEx numericUpDownEx_4;

	private Button button_4;

	private Button button_5;

	private Button button_6;

	private Button button_7;

	private NumericUpDownEx numericUpDownEx_5;

	private Label label_7;

	private Label label_8;

	private GroupBox groupBox_5;

	private Button button_8;

	private TextBox textBox_6;

	private NumericUpDownEx numericUpDownEx_6;

	private Label label_9;

	private NumericUpDownEx numericUpDownEx_7;

	private Label label_10;

	private TextBox textBox_7;

	private ComboBox comboBox_0;

	private Label label_11;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripMenuItem toolStripMenuItem_5;

	private NumericUpDownEx numericUpDownEx_8;

	private Label label_12;

	private NumericUpDownEx numericUpDownEx_9;

	private Label label_13;

	private TableLayoutPanel tableLayoutPanel_0;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private RadioButton radioButton_2;

	private RadioButton radioButton_3;

	private RadioButton radioButton_4;

	private RadioButton radioButton_5;

	private RadioButton radioButton_6;

	private RadioButton radioButton_7;

	private RadioButton radioButton_8;

	private RadioButton radioButton_9;

	private RadioButton radioButton_10;

	private RadioButton radioButton_11;

	private RadioButton radioButton_12;

	private RadioButton radioButton_13;

	private RadioButton radioButton_14;

	private RadioButton radioButton_15;

	private RadioButton radioButton_16;

	private RadioButton radioButton_17;

	private ToolStripMenuItem toolStripMenuItem_6;

	private CheckBox checkBox_1;

	private ToolStripMenuItem toolStripMenuItem_7;

	private ToolStripMenuItem toolStripMenuItem_8;

	private ToolStripMenuItem toolStripMenuItem_9;

	private ToolStripMenuItem toolStripMenuItem_10;

	private GroupBox groupBox_6;

	private Button button_9;

	private NumericUpDownEx numericUpDownEx_10;

	private Label label_14;

	private NumericUpDownEx numericUpDownEx_11;

	private Label label_15;

	private NumericUpDownEx numericUpDownEx_12;

	private Label label_16;

	private ToolStripSeparator toolStripSeparator_2;

	private ToolStripSeparator toolStripSeparator_3;

	private ToolStripMenuItem toolStripMenuItem_11;

	private ToolStripMenuItem toolStripMenuItem_12;

	private ToolStripMenuItem toolStripMenuItem_13;

	private ToolStripMenuItem toolStripMenuItem_14;

	private ToolStripMenuItem toolStripMenuItem_15;

	private ToolStripMenuItem toolStripMenuItem_16;

	private ToolStripMenuItem toolStripMenuItem_17;

	private ToolStripMenuItem toolStripMenuItem_18;

	private ToolStripSeparator toolStripSeparator_4;

	private ToolStripSeparator toolStripSeparator_5;

	private ToolStripMenuItem toolStripMenuItem_19;

	private ToolStripSeparator toolStripSeparator_6;

	private ToolStripMenuItem toolStripMenuItem_20;

	private ToolStripMenuItem toolStripMenuItem_21;

	private ToolStripMenuItem toolStripMenuItem_22;

	private ToolStripMenuItem toolStripMenuItem_23;

	private ToolStripMenuItem toolStripMenuItem_24;

	private ToolStripSeparator toolStripSeparator_7;

	private Button button_10;

	private ToolStripSeparator toolStripSeparator_8;

	private ToolStripMenuItem toolStripMenuItem_25;

	private Button button_11;

	private Button button_12;

	private ToolStripMenuItem toolStripMenuItem_26;

	private ToolStripMenuItem toolStripMenuItem_27;

	private ToolStripMenuItem toolStripMenuItem_28;

	private ToolStripMenuItem toolStripMenuItem_29;

	private ToolStripMenuItem toolStripMenuItem_30;

	private ToolStripMenuItem toolStripMenuItem_31;

	private ToolStripMenuItem toolStripMenuItem_32;

	private ToolStripMenuItem toolStripMenuItem_33;

	private ToolStripMenuItem toolStripMenuItem_34;

	private ToolStripSeparator toolStripSeparator_9;

	private ToolStripSeparator toolStripSeparator_10;

	private ToolStripSeparator toolStripSeparator_11;

	private ToolStripMenuItem toolStripMenuItem_35;

	private ToolStripMenuItem toolStripMenuItem_36;

	private ToolStripMenuItem toolStripMenuItem_37;

	private ToolStripSeparator toolStripSeparator_12;

	private ToolStripMenuItem toolStripMenuItem_38;

	private Button button_13;

	private RadioButton radioButton_18;

	private ToolStripSeparator toolStripSeparator_13;

	private ToolStripMenuItem toolStripMenuItem_39;

	private ToolStripMenuItem toolStripMenuItem_40;

	private ToolStripMenuItem toolStripMenuItem_41;

	private ToolStripMenuItem toolStripMenuItem_42;

	private ToolStripMenuItem toolStripMenuItem_43;

	private ToolStripSeparator toolStripSeparator_14;

	private ToolStripMenuItem toolStripMenuItem_44;

	private ContextMenuStrip contextMenuStrip_1;

	private ToolStripMenuItem toolStripMenuItem_45;

	private TextBox textBox_8;

	private ContextMenuStrip contextMenuStrip_2;

	private ToolStripMenuItem toolStripMenuItem_46;

	private ToolStripSeparator toolStripSeparator_15;

	private Timer timer_1;

	private ToolStripSeparator toolStripSeparator_16;

	private ToolStripMenuItem toolStripMenuItem_47;

	private ToolStripMenuItem toolStripMenuItem_48;

	private ToolStripMenuItem toolStripMenuItem_49;

	private ToolStripMenuItem toolStripMenuItem_50;

	private ToolStripMenuItem toolStripMenuItem_51;

	private ToolStripMenuItem toolStripMenuItem_52;

	private ToolStripMenuItem toolStripMenuItem_53;

	private ToolStripMenuItem toolStripMenuItem_54;

	private ToolStripMenuItem toolStripMenuItem_55;

	private ToolStripMenuItem toolStripMenuItem_56;

	private ToolStripSeparator toolStripSeparator_17;

	private ToolStripMenuItem toolStripMenuItem_57;

	private ToolStripMenuItem toolStripMenuItem_58;

	private ToolStripSeparator toolStripSeparator_18;

	private ToolStripMenuItem toolStripMenuItem_59;

	private ToolStripMenuItem toolStripMenuItem_60;

	private Timer timer_2;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ToolStripSeparator toolStripSeparator_19;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private ToolStripSeparator toolStripSeparator_20;

	private ToolStripButton toolStripButton_4;

	private ToolStripSeparator toolStripSeparator_21;

	private ToolStripSplitButton toolStripSplitButton_0;

	private ToolStripSplitButton toolStripSplitButton_1;

	private ToolStripSeparator toolStripSeparator_22;

	private ToolStripButton toolStripButton_5;

	private ToolStripButton toolStripButton_6;

	private ToolStripMenuItem toolStripMenuItem_61;

	private ToolStripMenuItem toolStripMenuItem_62;

	private ToolStripMenuItem toolStripMenuItem_63;

	private ToolStripSeparator toolStripSeparator_23;

	private ToolStripMenuItem toolStripMenuItem_64;

	private TableLayoutPanel tableLayoutPanel_1;

	private DataGridViewEx dataGridViewEx_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private Button button_14;

	private ToolStripMenuItem toolStripMenuItem_65;

	private ToolStripButton toolStripButton_7;

	private ToolStripButton toolStripButton_8;

	private ToolStripMenuItem toolStripMenuItem_66;

	private ToolStripSeparator toolStripSeparator_24;

	private ToolStripMenuItem toolStripMenuItem_67;

	private ToolStripMenuItem toolStripMenuItem_68;

	private ToolStripMenuItem toolStripMenuItem_69;

	private ToolStripMenuItem toolStripMenuItem_70;

	private ToolStripButton toolStripButton_9;

	private ToolStripMenuItem toolStripMenuItem_71;

	private ToolStripMenuItem toolStripMenuItem_72;

	private NumericUpDownEx numericUpDownEx_13;

	private Label label_17;

	private NumericUpDownEx numericUpDownEx_14;

	private Label label_18;

	private ComboBox comboBox_1;

	private TextBox textBox_9;

	private GroupBox groupBox_7;

	private DataGridViewEx dataGridViewEx_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private ToolStripMenuItem toolStripMenuItem_73;

	private ToolStripMenuItem toolStripMenuItem_74;

	private ToolStripMenuItem toolStripMenuItem_75;

	private ToolStripMenuItem toolStripMenuItem_76;

	private ToolStripMenuItem toolStripMenuItem_77;

	private ToolStripMenuItem toolStripMenuItem_78;

	private ToolStripMenuItem toolStripMenuItem_79;

	private ToolStripMenuItem toolStripMenuItem_80;

	private ToolStripMenuItem toolStripMenuItem_81;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewImageColumn dataGridViewImageColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	private ToolStripSeparator toolStripSeparator_25;

	private ToolStripButton toolStripButton_10;

	private Label label_19;

	private Label label_20;

	private NumericUpDownEx numericUpDownEx_15;

	private Label label_21;

	private NumericUpDownEx numericUpDownEx_16;

	private Label label_22;

	private NumericUpDownEx numericUpDownEx_17;

	private TextBox textBox_10;

	private ToolStripSeparator toolStripSeparator_26;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_82;

	private ToolStripMenuItem toolStripMenuItem_83;

	private ToolStripMenuItem toolStripMenuItem_84;

	private IContainer icontainer_0;

	private Dictionary<int, DataGridViewRow> dictionary_0 = new Dictionary<int, DataGridViewRow>();

	private Random random_0 = new Random();

	private PfimImageReader pfimImageReader_0 = new PfimImageReader();

	private bool bool_0;

	private int int_0;

	private int int_1;

	private Color color_0;

	private bool bool_1;

	private bool bool_2;

	private int int_2;

	private int int_3;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private int[] int_4;

	private int int_5;

	private GroupBox groupBox_8;

	private GroupBox groupBox_9;

	private TextBox textBox_11;

	private Label label_23;

	private NumericUpDownEx numericUpDownEx_18;

	private Label label_24;

	private NumericUpDownEx numericUpDownEx_19;

	private Label label_25;

	private NumericUpDownEx numericUpDownEx_20;

	private Label label_26;

	private NumericUpDownEx numericUpDownEx_21;

	private Label label_27;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TabPage tabPage_1;

	private Point point_0;

	private GroupBox groupBox_10;

	private NumericUpDownEx numericUpDownEx_22;

	private Label label_28;

	private NumericUpDownEx numericUpDownEx_23;

	private Label label_29;

	private NumericUpDownEx numericUpDownEx_24;

	private Label label_30;

	private NumericUpDownEx numericUpDownEx_25;

	private Label label_31;

	private ToolStripMenuItem toolStripMenuItem_85;

	private ToolStripMenuItem toolStripMenuItem_86;

	private ToolStripMenuItem toolStripMenuItem_87;

	private ToolStripMenuItem toolStripMenuItem_88;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private byte[] byte_0;

	private bool bool_6;

	public GShopEditor_PW(eListCollection eLC, ItemsWindow ItemsWindow1, CommonStorage CStorage, Form ElementsWindow, ItemsToolTip ItemsToolTip1, PCK_LIST PCKs)
	{
		try
		{
			method_6();
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridViewEx_0, value: true);
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			if (base.IsHandleCreated)
			{
				TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
			}
			TDark.ApplyNativeDarkThemeRecursive(this);
			BindEventsToOccupation();
			this.CStorage = CStorage;
			Profile = CommonStorage.Profile;
			this.eLC = eLC;
			this.ItemsWindow1 = ItemsWindow1;
			this.ElementsWindow = ElementsWindow;
			this.ItemsToolTip1 = ItemsToolTip1;
			this.PCKs = PCKs;
			bSurfacesLoaded = false;
			DontChange = false;
			RowIndexUnderCursor = -1;
			LoadingComplete = false;
			OriginalOrderChanged = false;
			dataGridViewEx_0.Cursor = ACE.RSGlobal.RSGlobal.LoadPWCursor();
			dataGridViewEx_0.DragStart += dataGridViewEx_0_DragStart;
			dataGridViewEx_0.KeyDown += dataGridViewEx_0_KeyDown;
			method_87();
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void method_0(Control.ControlCollection controlCollection_0, Color color_1)
	{
		foreach (Control item in controlCollection_0)
		{
			Color color = Color.FromArgb(255, 255, 128);
			if (item is NumericUpDown && !(item.BackColor == color))
			{
				item.BackColor = color_1;
			}
		}
		GC.KeepAlive(this);
	}

	private void dataGridViewEx_0_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			bool flag = !DontChange;
			DontChange = true;
			dataGridViewEx_0.ClearSelection();
			if (flag)
			{
				DontChange = false;
			}
			dataGridViewEx_0_SelectionChanged(null, null);
			e.Handled = true;
		}
		GC.KeepAlive(this);
	}

	private void method_1(bool bool_7)
	{
		button_2.Enabled = bool_7;
		contextMenuStrip_0.Enabled = bool_7;
		groupBox_0.Enabled = bool_7;
	}

	private int method_2()
	{
		int num = dataGridViewEx_0?.CurrentCell?.RowIndex ?? (-1);
		if (num >= 0 && num < dataGridViewEx_0.RowCount)
		{
			return num;
		}
		if (dataGridViewEx_0 == null)
		{
			return -1;
		}
		int firstRow = dataGridViewEx_0.Rows.GetFirstRow(DataGridViewElementStates.Selected);
		if (firstRow >= 0 && firstRow < dataGridViewEx_0.RowCount)
		{
			return firstRow;
		}
		return -1;
	}

	private static DateTime smethod_0(DateTimePicker dateTimePicker_2, DateTime dateTime_0)
	{
		if (dateTimePicker_2 == null)
		{
			return dateTime_0;
		}
		if (dateTime_0 < dateTimePicker_2.MinDate)
		{
			return dateTimePicker_2.MinDate;
		}
		if (dateTime_0 > dateTimePicker_2.MaxDate)
		{
			return dateTimePicker_2.MaxDate;
		}
		return dateTime_0;
	}

	private static void smethod_1(DateTimePicker dateTimePicker_2, DateTime dateTime_0)
	{
		if (dateTimePicker_2 == null || dateTimePicker_2.IsDisposed)
		{
			return;
		}
		try
		{
			dateTimePicker_2.Value = smethod_0(dateTimePicker_2, dateTime_0);
		}
		catch (ArgumentOutOfRangeException)
		{
			DateTime dateTime = DateTime.Now;
			if (dateTime < dateTimePicker_2.MinDate)
			{
				dateTime = dateTimePicker_2.MinDate;
			}
			else if (dateTime > dateTimePicker_2.MaxDate)
			{
				dateTime = dateTimePicker_2.MaxDate;
			}
			dateTimePicker_2.Value = dateTime;
		}
	}

	private bool method_3(out DialogResult dialogResult_0)
	{
		dialogResult_0 = DialogResult.Cancel;
		ItemsWindow itemsWindow = ItemsWindow1;
		if (itemsWindow != null && !itemsWindow.IsDisposed && !itemsWindow.Disposing)
		{
			try
			{
				if (itemsWindow.Modal)
				{
					if (itemsWindow.Visible)
					{
						itemsWindow.Activate();
					}
					return false;
				}
				dialogResult_0 = itemsWindow.ShowDialog(this);
				return true;
			}
			catch (ObjectDisposedException ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649067438));
				return false;
			}
			catch (InvalidOperationException ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1649067474));
				return false;
			}
		}
		SentryHelper.CaptureMessage(Class16.smethod_0(1649067337), (SentryLevel)2, Class16.smethod_0(1649067405));
		return false;
	}

	private void dataGridViewEx_0_SelectionChanged(object sender, EventArgs e)
	{
		if (DontChange || dataGridViewEx_0 == null || dataGridViewEx_0.IsDisposed)
		{
			return;
		}
		int count = dataGridViewEx_0.SelectedRows.Count;
		method_1(count > 0);
		if (count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		if (DataFiles.GShop?.Items == null)
		{
			method_1(bool_7: false);
			GC.KeepAlive(this);
			return;
		}
		int num = method_2();
		if (num < 0)
		{
			method_1(bool_7: false);
			method_34();
			GC.KeepAlive(this);
			return;
		}
		object[] vars = new object[3] { num, count, dataGridViewEx_0.RowCount };
		string headerText = TextStorage.TEXTS.GetText(Class16.smethod_0(1648978629), vars);
		dataGridViewTextBoxColumn_9.HeaderText = headerText;
		if (count > 1)
		{
			_ = Color.White;
			GC.KeepAlive(this);
			return;
		}
		DataGridViewRow dataGridViewRow = dataGridViewEx_0.Rows[num];
		object tag = dataGridViewRow.Tag;
		int result;
		if (tag is int)
		{
			result = (int)tag;
		}
		else if (!int.TryParse(tag?.ToString(), out result))
		{
			result = -1;
		}
		if (result >= 0 && result < DataFiles.GShop.Items.Length && DataFiles.GShop.Items[result] is GSHOP_ITEM_PW gSHOP_ITEM_PW)
		{
			SelectedItemIndex = result;
			GSHOP_ITEM_PW gSHOP_ITEM_PW2 = (pwGItem = gSHOP_ITEM_PW);
			bool flag = !DontChange;
			DontChange = true;
			_ = (decimal)gSHOP_ITEM_PW2.ID;
			textBox_1.Text = pwGItem.sName;
			textBox_3.Text = pwGItem.sIconPath;
			decimal value = pwGItem.ItemID;
			numericUpDownEx_0.SetValueSafe(value);
			decimal value2 = pwGItem.Count;
			numericUpDownEx_2.SetValueSafe(value2);
			decimal value3 = (decimal)pwGItem.Price;
			numericUpDownEx_1.SetValueSafe(value3);
			textBox_2.Text = ACE.RSGlobal.RSGlobal.rn2CrLF(pwGItem.sDescription);
			numericUpDownEx_5.SetValueSafe(pwGItem.Status);
			method_64();
			textBox_5.Text = method_46(pwGItem.Duration);
			numericUpDownEx_4.SetValueSafe(pwGItem.Duration);
			int selectedItemIndex = SelectedItemIndex;
			textBox_6.Text = DataFiles.GShop.GetItemCategory(selectedItemIndex);
			decimal value4 = pwGItem.GiftID;
			numericUpDownEx_3.SetValueSafe(value4);
			decimal value5 = pwGItem.GiftCount;
			numericUpDownEx_7.SetValueSafe(value5);
			decimal value6 = pwGItem.LogPrice;
			numericUpDownEx_6.SetValueSafe(value6);
			textBox_7.Text = method_46(pwGItem.GiftDuration);
			DateTime dateTime_ = ACE.RSGlobal.RSGlobal.Timestamp2DateTime(pwGItem.StartDate);
			smethod_1(dateTimePicker_1, dateTime_);
			DateTime dateTime_2 = ACE.RSGlobal.RSGlobal.Timestamp2DateTime(pwGItem.ExpireDate);
			smethod_1(dateTimePicker_0, dateTime_2);
			int val = pwGItem.ControlType + 1;
			val = Math.Max(0, Math.Min(comboBox_0.Items.Count - 1, val));
			comboBox_0.SelectedIndex = val;
			decimal value7 = pwGItem.Day;
			numericUpDownEx_9.SetValueSafe(value7);
			decimal value8 = pwGItem.Flags;
			numericUpDownEx_8.SetValueSafe(value8);
			decimal value9 = pwGItem.MinVipLevel;
			numericUpDownEx_13.SetValueSafe(value9);
			decimal value10 = pwGItem.BuyTimesLimit;
			numericUpDownEx_14.SetValueSafe(value10);
			int buyTimesLimitMode = pwGItem.BuyTimesLimitMode;
			comboBox_1.SelectedIndex = ((buyTimesLimitMode >= 0 && buyTimesLimitMode < comboBox_1.Items.Count) ? buyTimesLimitMode : 0);
			decimal value11 = pwGItem.Occupation;
			numericUpDownEx_17.SetValueSafe(value11);
			if (pwGItem.tasks_id < 0)
			{
				pwGItem.tasks_id = 0;
			}
			decimal num2 = pwGItem.tasks_id;
			if (num2 < 0m)
			{
				num2 = default(decimal);
			}
			numericUpDownEx_16.SetValueSafe(num2);
			if (numericUpDownEx_16.Value < 0m)
			{
				numericUpDownEx_16.Value = 0m;
			}
			decimal value12 = pwGItem.tasks_space;
			numericUpDownEx_15.SetValueSafe(value12);
			decimal value13 = pwGItem.reserved1;
			numericUpDownEx_18.SetValueSafe(value13);
			decimal value14 = pwGItem.reserved2;
			numericUpDownEx_21.SetValueSafe(value14);
			decimal value15 = pwGItem.reserved3;
			numericUpDownEx_20.SetValueSafe(value15);
			decimal value16 = pwGItem.reserved4;
			numericUpDownEx_19.SetValueSafe(value16);
			decimal value17 = pwGItem.special_server_forbid;
			numericUpDownEx_25.SetValueSafe(value17);
			decimal value18 = pwGItem.in_green_shop;
			numericUpDownEx_24.SetValueSafe(value18);
			decimal value19 = pwGItem.add_trade_time;
			numericUpDownEx_23.SetValueSafe(value19);
			decimal value20 = pwGItem.reserved6;
			numericUpDownEx_22.SetValueSafe(value20);
			if (DataFiles.GShop.VersionPW >= PW_GSHOP_VERSION.PW_1_5_3)
			{
				int num3 = 0;
				do
				{
					int num4 = pwGItem.owner_npcs[num3];
					dataGridViewEx_2[0, num3].Value = num4.ToString();
					num3++;
				}
				while (num3 < 8);
			}
			if (flag)
			{
				DontChange = false;
			}
			method_83();
			UpdatePropsInElements(bOnlyRecalculate: false);
			method_34();
		}
		else
		{
			bool flag2 = !DontChange;
			DontChange = true;
			dataGridViewEx_0.ClearSelection();
			if (flag2)
			{
				DontChange = false;
			}
			method_1(bool_7: false);
			method_34();
			GC.KeepAlive(this);
		}
	}

	private void method_4()
	{
		int num = 0;
		if (0 < dataGridViewEx_0.RowCount)
		{
			do
			{
				method_96(num);
				num++;
			}
			while (num < dataGridViewEx_0.RowCount);
		}
	}

	private void method_5()
	{
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				method_96(dataGridViewEx_0.SelectedRows[num].Index);
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_7();
	}

	private void method_6()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(GShopEditor_PW));
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_82 = new ToolStripMenuItem();
		toolStripMenuItem_83 = new ToolStripMenuItem();
		toolStripMenuItem_55 = new ToolStripMenuItem();
		toolStripMenuItem_56 = new ToolStripMenuItem();
		toolStripSeparator_17 = new ToolStripSeparator();
		toolStripMenuItem_57 = new ToolStripMenuItem();
		toolStripMenuItem_58 = new ToolStripMenuItem();
		toolStripSeparator_18 = new ToolStripSeparator();
		toolStripMenuItem_59 = new ToolStripMenuItem();
		toolStripMenuItem_67 = new ToolStripMenuItem();
		toolStripMenuItem_71 = new ToolStripMenuItem();
		toolStripMenuItem_76 = new ToolStripMenuItem();
		toolStripMenuItem_75 = new ToolStripMenuItem();
		toolStripMenuItem_87 = new ToolStripMenuItem();
		toolStripMenuItem_88 = new ToolStripMenuItem();
		toolStripMenuItem_74 = new ToolStripMenuItem();
		toolStripMenuItem_84 = new ToolStripMenuItem();
		toolStripMenuItem_70 = new ToolStripMenuItem();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		toolStripMenuItem_51 = new ToolStripMenuItem();
		toolStripMenuItem_85 = new ToolStripMenuItem();
		toolStripMenuItem_86 = new ToolStripMenuItem();
		toolStripMenuItem_79 = new ToolStripMenuItem();
		toolStripMenuItem_78 = new ToolStripMenuItem();
		toolStripMenuItem_77 = new ToolStripMenuItem();
		toolStripMenuItem_72 = new ToolStripMenuItem();
		toolStripMenuItem_68 = new ToolStripMenuItem();
		toolStripMenuItem_52 = new ToolStripMenuItem();
		toolStripSeparator_24 = new ToolStripSeparator();
		toolStripMenuItem_53 = new ToolStripMenuItem();
		toolStripMenuItem_69 = new ToolStripMenuItem();
		toolStripMenuItem_54 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_66 = new ToolStripMenuItem();
		toolStripMenuItem_5 = new ToolStripMenuItem();
		toolStripMenuItem_17 = new ToolStripMenuItem();
		toolStripMenuItem_18 = new ToolStripMenuItem();
		toolStripSeparator_4 = new ToolStripSeparator();
		toolStripMenuItem_37 = new ToolStripMenuItem();
		toolStripMenuItem_6 = new ToolStripMenuItem();
		toolStripSeparator_2 = new ToolStripSeparator();
		toolStripMenuItem_7 = new ToolStripMenuItem();
		toolStripMenuItem_8 = new ToolStripMenuItem();
		toolStripMenuItem_14 = new ToolStripMenuItem();
		toolStripMenuItem_15 = new ToolStripMenuItem();
		toolStripMenuItem_16 = new ToolStripMenuItem();
		toolStripSeparator_3 = new ToolStripSeparator();
		toolStripMenuItem_11 = new ToolStripMenuItem();
		toolStripMenuItem_13 = new ToolStripMenuItem();
		toolStripMenuItem_9 = new ToolStripMenuItem();
		toolStripMenuItem_10 = new ToolStripMenuItem();
		toolStripMenuItem_81 = new ToolStripMenuItem();
		toolStripMenuItem_35 = new ToolStripMenuItem();
		toolStripMenuItem_27 = new ToolStripMenuItem();
		toolStripMenuItem_28 = new ToolStripMenuItem();
		toolStripMenuItem_29 = new ToolStripMenuItem();
		toolStripSeparator_9 = new ToolStripSeparator();
		toolStripMenuItem_30 = new ToolStripMenuItem();
		toolStripSeparator_10 = new ToolStripSeparator();
		toolStripMenuItem_73 = new ToolStripMenuItem();
		toolStripMenuItem_31 = new ToolStripMenuItem();
		toolStripMenuItem_32 = new ToolStripMenuItem();
		toolStripMenuItem_49 = new ToolStripMenuItem();
		toolStripMenuItem_60 = new ToolStripMenuItem();
		toolStripSeparator_11 = new ToolStripSeparator();
		toolStripMenuItem_33 = new ToolStripMenuItem();
		toolStripSeparator_14 = new ToolStripSeparator();
		toolStripMenuItem_44 = new ToolStripMenuItem();
		toolStripMenuItem_21 = new ToolStripMenuItem();
		toolStripMenuItem_22 = new ToolStripMenuItem();
		toolStripMenuItem_23 = new ToolStripMenuItem();
		toolStripMenuItem_34 = new ToolStripMenuItem();
		toolStripSeparator_12 = new ToolStripSeparator();
		toolStripMenuItem_38 = new ToolStripMenuItem();
		button_2 = new Button();
		button_1 = new Button();
		textBox_0 = new TextBox();
		toolTip_0 = new ToolTip(icontainer_0);
		button_0 = new Button();
		contextMenuStrip_0 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripSeparator_8 = new ToolStripSeparator();
		toolStripMenuItem_25 = new ToolStripMenuItem();
		toolStripSeparator_5 = new ToolStripSeparator();
		toolStripMenuItem_61 = new ToolStripMenuItem();
		toolStripMenuItem_62 = new ToolStripMenuItem();
		toolStripMenuItem_63 = new ToolStripMenuItem();
		toolStripSeparator_23 = new ToolStripSeparator();
		toolStripMenuItem_64 = new ToolStripMenuItem();
		toolStripMenuItem_19 = new ToolStripMenuItem();
		toolStripSeparator_13 = new ToolStripSeparator();
		toolStripMenuItem_39 = new ToolStripMenuItem();
		toolStripMenuItem_40 = new ToolStripMenuItem();
		toolStripMenuItem_41 = new ToolStripMenuItem();
		toolStripMenuItem_42 = new ToolStripMenuItem();
		toolStripMenuItem_43 = new ToolStripMenuItem();
		toolStripMenuItem_26 = new ToolStripMenuItem();
		toolStripSeparator_6 = new ToolStripSeparator();
		toolStripMenuItem_12 = new ToolStripMenuItem();
		toolStripSeparator_1 = new ToolStripSeparator();
		toolStripMenuItem_20 = new ToolStripMenuItem();
		toolStripMenuItem_65 = new ToolStripMenuItem();
		toolStripMenuItem_24 = new ToolStripMenuItem();
		toolStripMenuItem_80 = new ToolStripMenuItem();
		toolStripSeparator_7 = new ToolStripSeparator();
		toolStripMenuItem_36 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		panel_0 = new Panel();
		tableLayoutPanel_1 = new TableLayoutPanel();
		dataGridViewEx_0 = new DataGridViewEx();
		dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_1 = new DataGridViewImageColumn();
		dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
		button_11 = new Button();
		textBox_8 = new TextBox();
		button_12 = new Button();
		tableLayoutPanel_0 = new TableLayoutPanel();
		radioButton_18 = new RadioButton();
		radioButton_17 = new RadioButton();
		contextMenuStrip_1 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_45 = new ToolStripMenuItem();
		toolStripSeparator_16 = new ToolStripSeparator();
		toolStripMenuItem_47 = new ToolStripMenuItem();
		radioButton_0 = new RadioButton();
		radioButton_1 = new RadioButton();
		contextMenuStrip_2 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_46 = new ToolStripMenuItem();
		toolStripSeparator_15 = new ToolStripSeparator();
		toolStripMenuItem_50 = new ToolStripMenuItem();
		toolStripMenuItem_48 = new ToolStripMenuItem();
		radioButton_2 = new RadioButton();
		radioButton_3 = new RadioButton();
		radioButton_4 = new RadioButton();
		radioButton_5 = new RadioButton();
		radioButton_6 = new RadioButton();
		radioButton_7 = new RadioButton();
		radioButton_8 = new RadioButton();
		radioButton_9 = new RadioButton();
		radioButton_10 = new RadioButton();
		radioButton_11 = new RadioButton();
		radioButton_12 = new RadioButton();
		radioButton_13 = new RadioButton();
		radioButton_14 = new RadioButton();
		radioButton_15 = new RadioButton();
		radioButton_16 = new RadioButton();
		groupBox_0 = new GroupBox();
		tabControl_0 = new TabControl();
		tabPage_0 = new TabPage();
		groupBox_3 = new GroupBox();
		textBox_10 = new TextBox();
		label_22 = new Label();
		numericUpDownEx_17 = new NumericUpDownEx();
		textBox_9 = new TextBox();
		comboBox_1 = new ComboBox();
		numericUpDownEx_14 = new NumericUpDownEx();
		label_18 = new Label();
		numericUpDownEx_13 = new NumericUpDownEx();
		numericUpDownEx_8 = new NumericUpDownEx();
		numericUpDownEx_9 = new NumericUpDownEx();
		label_13 = new Label();
		comboBox_0 = new ComboBox();
		label_11 = new Label();
		label_5 = new Label();
		dateTimePicker_0 = new DateTimePicker();
		dateTimePicker_1 = new DateTimePicker();
		label_6 = new Label();
		label_12 = new Label();
		label_17 = new Label();
		groupBox_5 = new GroupBox();
		button_13 = new Button();
		button_8 = new Button();
		textBox_6 = new TextBox();
		groupBox_2 = new GroupBox();
		button_14 = new Button();
		dataGridViewEx_1 = new DataGridViewEx();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		button_3 = new Button();
		textBox_2 = new TextBox();
		groupBox_6 = new GroupBox();
		label_20 = new Label();
		label_19 = new Label();
		button_9 = new Button();
		numericUpDownEx_10 = new NumericUpDownEx();
		label_14 = new Label();
		numericUpDownEx_11 = new NumericUpDownEx();
		label_15 = new Label();
		numericUpDownEx_12 = new NumericUpDownEx();
		label_16 = new Label();
		groupBox_7 = new GroupBox();
		dataGridViewEx_2 = new DataGridViewEx();
		dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		tabPage_1 = new TabPage();
		groupBox_10 = new GroupBox();
		numericUpDownEx_22 = new NumericUpDownEx();
		label_28 = new Label();
		numericUpDownEx_23 = new NumericUpDownEx();
		label_29 = new Label();
		numericUpDownEx_24 = new NumericUpDownEx();
		label_30 = new Label();
		numericUpDownEx_25 = new NumericUpDownEx();
		label_31 = new Label();
		groupBox_9 = new GroupBox();
		textBox_11 = new TextBox();
		label_23 = new Label();
		numericUpDownEx_15 = new NumericUpDownEx();
		numericUpDownEx_16 = new NumericUpDownEx();
		label_21 = new Label();
		groupBox_4 = new GroupBox();
		textBox_7 = new TextBox();
		numericUpDownEx_6 = new NumericUpDownEx();
		label_9 = new Label();
		numericUpDownEx_7 = new NumericUpDownEx();
		label_10 = new Label();
		pictureBox_2 = new PictureBox();
		numericUpDownEx_3 = new NumericUpDownEx();
		groupBox_8 = new GroupBox();
		numericUpDownEx_19 = new NumericUpDownEx();
		label_25 = new Label();
		numericUpDownEx_20 = new NumericUpDownEx();
		label_26 = new Label();
		numericUpDownEx_21 = new NumericUpDownEx();
		label_27 = new Label();
		numericUpDownEx_18 = new NumericUpDownEx();
		label_24 = new Label();
		groupBox_1 = new GroupBox();
		numericUpDownEx_5 = new NumericUpDownEx();
		label_7 = new Label();
		button_4 = new Button();
		button_5 = new Button();
		button_6 = new Button();
		button_7 = new Button();
		label_8 = new Label();
		textBox_5 = new TextBox();
		numericUpDownEx_4 = new NumericUpDownEx();
		label_4 = new Label();
		numericUpDownEx_1 = new NumericUpDownEx();
		label_1 = new Label();
		label_2 = new Label();
		textBox_4 = new TextBox();
		pictureBox_0 = new PictureBox();
		numericUpDownEx_2 = new NumericUpDownEx();
		numericUpDownEx_0 = new NumericUpDownEx();
		label_3 = new Label();
		textBox_3 = new TextBox();
		label_0 = new Label();
		pictureBox_1 = new PictureBox();
		textBox_1 = new TextBox();
		checkBox_0 = new CheckBox();
		button_10 = new Button();
		checkBox_1 = new CheckBox();
		backgroundWorker_0 = new BackgroundWorker();
		toolTip_1 = new ToolTip(icontainer_0);
		timer_0 = new Timer(icontainer_0);
		colorDialog_0 = new ColorDialog();
		statusStrip_0 = new StatusStrip();
		toolStripProgressBar_0 = new ToolStripProgressBar();
		toolStripStatusLabel_0 = new ToolStripStatusLabel();
		timer_1 = new Timer(icontainer_0);
		timer_2 = new Timer(icontainer_0);
		toolStrip_0 = new ToolStrip();
		toolStripButton_0 = new ToolStripButton();
		toolStripButton_1 = new ToolStripButton();
		toolStripSeparator_19 = new ToolStripSeparator();
		toolStripButton_2 = new ToolStripButton();
		toolStripButton_3 = new ToolStripButton();
		toolStripSeparator_20 = new ToolStripSeparator();
		toolStripButton_4 = new ToolStripButton();
		toolStripButton_6 = new ToolStripButton();
		toolStripSeparator_21 = new ToolStripSeparator();
		toolStripButton_9 = new ToolStripButton();
		toolStripSplitButton_0 = new ToolStripSplitButton();
		toolStripSplitButton_1 = new ToolStripSplitButton();
		toolStripSeparator_22 = new ToolStripSeparator();
		toolStripButton_8 = new ToolStripButton();
		toolStripSeparator_26 = new ToolStripSeparator();
		toolStripButton_5 = new ToolStripButton();
		toolStripButton_7 = new ToolStripButton();
		toolStripSeparator_25 = new ToolStripSeparator();
		toolStripButton_10 = new ToolStripButton();
		menuStrip_0.SuspendLayout();
		contextMenuStrip_0.SuspendLayout();
		panel_0.SuspendLayout();
		tableLayoutPanel_1.SuspendLayout();
		((ISupportInitialize)dataGridViewEx_0).BeginInit();
		tableLayoutPanel_0.SuspendLayout();
		contextMenuStrip_1.SuspendLayout();
		contextMenuStrip_2.SuspendLayout();
		groupBox_0.SuspendLayout();
		tabControl_0.SuspendLayout();
		tabPage_0.SuspendLayout();
		groupBox_3.SuspendLayout();
		((ISupportInitialize)numericUpDownEx_17).BeginInit();
		((ISupportInitialize)numericUpDownEx_14).BeginInit();
		((ISupportInitialize)numericUpDownEx_13).BeginInit();
		((ISupportInitialize)numericUpDownEx_8).BeginInit();
		((ISupportInitialize)numericUpDownEx_9).BeginInit();
		groupBox_5.SuspendLayout();
		groupBox_2.SuspendLayout();
		((ISupportInitialize)dataGridViewEx_1).BeginInit();
		groupBox_6.SuspendLayout();
		((ISupportInitialize)numericUpDownEx_10).BeginInit();
		((ISupportInitialize)numericUpDownEx_11).BeginInit();
		((ISupportInitialize)numericUpDownEx_12).BeginInit();
		groupBox_7.SuspendLayout();
		((ISupportInitialize)dataGridViewEx_2).BeginInit();
		tabPage_1.SuspendLayout();
		groupBox_10.SuspendLayout();
		((ISupportInitialize)numericUpDownEx_22).BeginInit();
		((ISupportInitialize)numericUpDownEx_23).BeginInit();
		((ISupportInitialize)numericUpDownEx_24).BeginInit();
		((ISupportInitialize)numericUpDownEx_25).BeginInit();
		groupBox_9.SuspendLayout();
		((ISupportInitialize)numericUpDownEx_15).BeginInit();
		((ISupportInitialize)numericUpDownEx_16).BeginInit();
		groupBox_4.SuspendLayout();
		((ISupportInitialize)numericUpDownEx_6).BeginInit();
		((ISupportInitialize)numericUpDownEx_7).BeginInit();
		((ISupportInitialize)pictureBox_2).BeginInit();
		((ISupportInitialize)numericUpDownEx_3).BeginInit();
		groupBox_8.SuspendLayout();
		((ISupportInitialize)numericUpDownEx_19).BeginInit();
		((ISupportInitialize)numericUpDownEx_20).BeginInit();
		((ISupportInitialize)numericUpDownEx_21).BeginInit();
		((ISupportInitialize)numericUpDownEx_18).BeginInit();
		groupBox_1.SuspendLayout();
		((ISupportInitialize)numericUpDownEx_5).BeginInit();
		((ISupportInitialize)numericUpDownEx_1).BeginInit();
		((ISupportInitialize)pictureBox_0).BeginInit();
		((ISupportInitialize)numericUpDownEx_2).BeginInit();
		((ISupportInitialize)numericUpDownEx_0).BeginInit();
		((ISupportInitialize)pictureBox_1).BeginInit();
		statusStrip_0.SuspendLayout();
		toolStrip_0.SuspendLayout();
		SuspendLayout();
		menuStrip_0.BackColor = SystemColors.InactiveBorder;
		menuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		menuStrip_0.Items.AddRange(new ToolStripItem[6] { toolStripMenuItem_82, toolStripMenuItem_66, toolStripMenuItem_5, toolStripMenuItem_9, toolStripMenuItem_27, toolStripMenuItem_21 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1649009132);
		menuStrip_0.Padding = new Padding(0, 2, 2, 2);
		menuStrip_0.RenderMode = ToolStripRenderMode.Professional;
		menuStrip_0.Size = new Size(1174, 24);
		menuStrip_0.TabIndex = 0;
		menuStrip_0.Text = Class16.smethod_0(1649066519);
		toolStripMenuItem_82.DropDownItems.AddRange(new ToolStripItem[8] { toolStripMenuItem_83, toolStripMenuItem_55, toolStripMenuItem_84, toolStripMenuItem_70, toolStripMenuItem_4, toolStripMenuItem_51, toolStripSeparator_0, toolStripMenuItem_0 });
		toolStripMenuItem_82.ImageScaling = ToolStripItemImageScaling.None;
		toolStripMenuItem_82.Name = Class16.smethod_0(1648920842);
		toolStripMenuItem_82.Padding = new Padding(0);
		toolStripMenuItem_82.Size = new Size(29, 20);
		toolStripMenuItem_82.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_82.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_83.BackgroundImageLayout = ImageLayout.None;
		toolStripMenuItem_83.Image = Resources.GShopEditor_PW_mnuOpen;
		toolStripMenuItem_83.ImageAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_83.Name = Class16.smethod_0(1648920856);
		toolStripMenuItem_83.ShortcutKeys = Keys.O | Keys.Control;
		toolStripMenuItem_83.Size = new Size(206, 22);
		toolStripMenuItem_83.Text = Class16.smethod_0(1648931498);
		toolStripMenuItem_83.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_83.Click += toolStripMenuItem_83_Click;
		toolStripMenuItem_55.DropDownItems.AddRange(new ToolStripItem[13]
		{
			toolStripMenuItem_56, toolStripSeparator_17, toolStripMenuItem_57, toolStripMenuItem_58, toolStripSeparator_18, toolStripMenuItem_59, toolStripMenuItem_67, toolStripMenuItem_71, toolStripMenuItem_76, toolStripMenuItem_75,
			toolStripMenuItem_87, toolStripMenuItem_88, toolStripMenuItem_74
		});
		toolStripMenuItem_55.Image = Resources.mnuOpenAs;
		toolStripMenuItem_55.Name = Class16.smethod_0(1649066531);
		toolStripMenuItem_55.Size = new Size(206, 22);
		toolStripMenuItem_55.Text = Class16.smethod_0(1649066547);
		toolStripMenuItem_56.Image = Resources.mnuOpenAs_1_2_6;
		toolStripMenuItem_56.Name = Class16.smethod_0(1649066561);
		toolStripMenuItem_56.Size = new Size(174, 22);
		toolStripMenuItem_56.Text = Class16.smethod_0(1649066591);
		toolStripMenuItem_56.Click += toolStripMenuItem_56_Click;
		toolStripSeparator_17.Name = Class16.smethod_0(1649012245);
		toolStripSeparator_17.Size = new Size(171, 6);
		toolStripMenuItem_57.Image = Resources.mnuOpenAs_1_4_2_v27;
		toolStripMenuItem_57.Name = Class16.smethod_0(1649066611);
		toolStripMenuItem_57.Size = new Size(174, 22);
		toolStripMenuItem_57.Text = Class16.smethod_0(1649066645);
		toolStripMenuItem_57.Click += toolStripMenuItem_57_Click;
		toolStripMenuItem_58.Font = new Font(Class16.smethod_0(1648942905), 9f);
		toolStripMenuItem_58.Image = Resources.mnuOpenAs_1_4_2_v29;
		toolStripMenuItem_58.Name = Class16.smethod_0(1649066671);
		toolStripMenuItem_58.Size = new Size(174, 22);
		toolStripMenuItem_58.Text = Class16.smethod_0(1649066689);
		toolStripMenuItem_58.Click += toolStripMenuItem_58_Click;
		toolStripSeparator_18.Name = Class16.smethod_0(1649066715);
		toolStripSeparator_18.Size = new Size(171, 6);
		toolStripMenuItem_59.Font = new Font(Class16.smethod_0(1648942905), 9f);
		toolStripMenuItem_59.Image = Resources.mnuOpenAs_1_4_4;
		toolStripMenuItem_59.Name = Class16.smethod_0(1649066749);
		toolStripMenuItem_59.Size = new Size(174, 22);
		toolStripMenuItem_59.Text = Class16.smethod_0(1649066763);
		toolStripMenuItem_59.Click += toolStripMenuItem_59_Click;
		toolStripMenuItem_67.Image = Resources.mnuOpenAs_1_5_3;
		toolStripMenuItem_67.Name = Class16.smethod_0(1649066799);
		toolStripMenuItem_67.Size = new Size(174, 22);
		toolStripMenuItem_67.Text = Class16.smethod_0(1649066821);
		toolStripMenuItem_67.Click += toolStripMenuItem_67_Click;
		toolStripMenuItem_71.Image = Resources.mnuOpenAs_1_5_4;
		toolStripMenuItem_71.Name = Class16.smethod_0(1649066840);
		toolStripMenuItem_71.Size = new Size(174, 22);
		toolStripMenuItem_71.Text = Class16.smethod_0(1649066870);
		toolStripMenuItem_71.Click += toolStripMenuItem_71_Click;
		toolStripMenuItem_76.Image = Resources.mnuOpenAs_1_5_5;
		toolStripMenuItem_76.Name = Class16.smethod_0(1649066889);
		toolStripMenuItem_76.Size = new Size(174, 22);
		toolStripMenuItem_76.Text = Class16.smethod_0(1649066919);
		toolStripMenuItem_76.Click += toolStripMenuItem_76_Click;
		toolStripMenuItem_75.Image = Resources.mnuOpenAs_1_6_0;
		toolStripMenuItem_75.Name = Class16.smethod_0(1649066938);
		toolStripMenuItem_75.Size = new Size(174, 22);
		toolStripMenuItem_75.Text = Class16.smethod_0(1649066960);
		toolStripMenuItem_75.Click += toolStripMenuItem_75_Click;
		toolStripMenuItem_87.Image = Resources.mnuOpenAs_1_6_0;
		toolStripMenuItem_87.Name = Class16.smethod_0(1649066988);
		toolStripMenuItem_87.Size = new Size(174, 22);
		toolStripMenuItem_87.Text = Class16.smethod_0(1649065990);
		toolStripMenuItem_87.Click += toolStripMenuItem_79_Click;
		toolStripMenuItem_88.Image = Resources.mnuOpenAs_1_6_0;
		toolStripMenuItem_88.Name = Class16.smethod_0(1649066002);
		toolStripMenuItem_88.Size = new Size(174, 22);
		toolStripMenuItem_88.Text = Class16.smethod_0(1649066036);
		toolStripMenuItem_88.Click += toolStripMenuItem_88_Click;
		toolStripMenuItem_74.Image = Resources.mnuOpenAs_1_6_0;
		toolStripMenuItem_74.Name = Class16.smethod_0(1649066048);
		toolStripMenuItem_74.Size = new Size(174, 22);
		toolStripMenuItem_74.Text = Class16.smethod_0(1649066078);
		toolStripMenuItem_74.Click += toolStripMenuItem_74_Click;
		toolStripMenuItem_84.Image = Resources.GShopEditor_PW_mnuSave;
		toolStripMenuItem_84.Name = Class16.smethod_0(1648920878);
		toolStripMenuItem_84.ShortcutKeys = Keys.S | Keys.Control;
		toolStripMenuItem_84.Size = new Size(206, 22);
		toolStripMenuItem_84.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_84.TextAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_84.Click += toolStripMenuItem_84_Click;
		toolStripMenuItem_70.Image = Resources.GShopEditor_PW_mnuSaveAs;
		toolStripMenuItem_70.Name = Class16.smethod_0(1648920892);
		toolStripMenuItem_70.ShortcutKeys = Keys.S | Keys.Shift | Keys.Control;
		toolStripMenuItem_70.Size = new Size(206, 22);
		toolStripMenuItem_70.Text = Class16.smethod_0(1649066091);
		toolStripMenuItem_70.Click += toolStripMenuItem_70_Click;
		toolStripMenuItem_4.Image = Resources.mnuSaveToGshopSev;
		toolStripMenuItem_4.Name = Class16.smethod_0(1649066105);
		toolStripMenuItem_4.Size = new Size(206, 22);
		toolStripMenuItem_4.Text = Class16.smethod_0(1649066129);
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		toolStripMenuItem_51.DropDownItems.AddRange(new ToolStripItem[12]
		{
			toolStripMenuItem_85, toolStripMenuItem_86, toolStripMenuItem_79, toolStripMenuItem_78, toolStripMenuItem_77, toolStripMenuItem_72, toolStripMenuItem_68, toolStripMenuItem_52, toolStripSeparator_24, toolStripMenuItem_53,
			toolStripMenuItem_69, toolStripMenuItem_54
		});
		toolStripMenuItem_51.Image = Resources.mnuExportGShop;
		toolStripMenuItem_51.Name = Class16.smethod_0(1649066160);
		toolStripMenuItem_51.Size = new Size(206, 22);
		toolStripMenuItem_51.Text = Class16.smethod_0(1648931384);
		toolStripMenuItem_85.Name = Class16.smethod_0(1649066189);
		toolStripMenuItem_85.Size = new Size(174, 22);
		toolStripMenuItem_85.Text = Class16.smethod_0(1649066078);
		toolStripMenuItem_85.Click += toolStripMenuItem_85_Click;
		toolStripMenuItem_86.Name = Class16.smethod_0(1649066215);
		toolStripMenuItem_86.Size = new Size(174, 22);
		toolStripMenuItem_86.Text = Class16.smethod_0(1649066036);
		toolStripMenuItem_86.Click += toolStripMenuItem_86_Click;
		toolStripMenuItem_79.Name = Class16.smethod_0(1649066233);
		toolStripMenuItem_79.Size = new Size(174, 22);
		toolStripMenuItem_79.Text = Class16.smethod_0(1649065990);
		toolStripMenuItem_79.Click += toolStripMenuItem_79_Click;
		toolStripMenuItem_78.Name = Class16.smethod_0(1649066256);
		toolStripMenuItem_78.Size = new Size(174, 22);
		toolStripMenuItem_78.Text = Class16.smethod_0(1649066960);
		toolStripMenuItem_78.Click += toolStripMenuItem_78_Click;
		toolStripMenuItem_77.Name = Class16.smethod_0(1649066287);
		toolStripMenuItem_77.Size = new Size(174, 22);
		toolStripMenuItem_77.Text = Class16.smethod_0(1649066919);
		toolStripMenuItem_77.Click += toolStripMenuItem_77_Click;
		toolStripMenuItem_72.Name = Class16.smethod_0(1649066310);
		toolStripMenuItem_72.Size = new Size(174, 22);
		toolStripMenuItem_72.Text = Class16.smethod_0(1649066870);
		toolStripMenuItem_72.Click += toolStripMenuItem_72_Click;
		toolStripMenuItem_68.Name = Class16.smethod_0(1649066333);
		toolStripMenuItem_68.Size = new Size(174, 22);
		toolStripMenuItem_68.Text = Class16.smethod_0(1649066821);
		toolStripMenuItem_68.Click += toolStripMenuItem_68_Click;
		toolStripMenuItem_52.Name = Class16.smethod_0(1649066356);
		toolStripMenuItem_52.Size = new Size(174, 22);
		toolStripMenuItem_52.Text = Class16.smethod_0(1649066371);
		toolStripMenuItem_52.Click += toolStripMenuItem_52_Click;
		toolStripSeparator_24.Name = Class16.smethod_0(1649066407);
		toolStripSeparator_24.Size = new Size(171, 6);
		toolStripMenuItem_53.Name = Class16.smethod_0(1649066425);
		toolStripMenuItem_53.Size = new Size(174, 22);
		toolStripMenuItem_53.Text = Class16.smethod_0(1649066448);
		toolStripMenuItem_53.Click += toolStripMenuItem_53_Click;
		toolStripMenuItem_69.Name = Class16.smethod_0(1649066476);
		toolStripMenuItem_69.Size = new Size(174, 22);
		toolStripMenuItem_69.Text = Class16.smethod_0(1649066645);
		toolStripMenuItem_69.Click += toolStripMenuItem_69_Click;
		toolStripMenuItem_54.Name = Class16.smethod_0(1649069575);
		toolStripMenuItem_54.Size = new Size(174, 22);
		toolStripMenuItem_54.Text = Class16.smethod_0(1649069598);
		toolStripMenuItem_54.Click += toolStripMenuItem_54_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1649012270);
		toolStripSeparator_0.Size = new Size(203, 6);
		toolStripMenuItem_0.Image = Resources.GShopEditor_PW_mnuExit;
		toolStripMenuItem_0.Name = Class16.smethod_0(1648920908);
		toolStripMenuItem_0.Size = new Size(206, 22);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648920914);
		toolStripMenuItem_0.Click += toolStripMenuItem_0_Click;
		toolStripMenuItem_66.Alignment = ToolStripItemAlignment.Right;
		toolStripMenuItem_66.Image = Resources.mnuSelectSurfacesPck;
		toolStripMenuItem_66.ImageAlign = ContentAlignment.MiddleLeft;
		toolStripMenuItem_66.Name = Class16.smethod_0(1649069610);
		toolStripMenuItem_66.Size = new Size(134, 20);
		toolStripMenuItem_66.Text = Class16.smethod_0(1649069645);
		toolStripMenuItem_66.TextImageRelation = TextImageRelation.TextBeforeImage;
		toolStripMenuItem_66.Click += toolStripMenuItem_66_Click;
		toolStripMenuItem_5.DropDownItems.AddRange(new ToolStripItem[10] { toolStripMenuItem_17, toolStripMenuItem_18, toolStripSeparator_4, toolStripMenuItem_37, toolStripMenuItem_6, toolStripSeparator_2, toolStripMenuItem_7, toolStripSeparator_3, toolStripMenuItem_11, toolStripMenuItem_13 });
		toolStripMenuItem_5.Name = Class16.smethod_0(1649000435);
		toolStripMenuItem_5.Size = new Size(39, 20);
		toolStripMenuItem_5.Text = Class16.smethod_0(1648932164);
		toolStripMenuItem_17.Enabled = false;
		toolStripMenuItem_17.Image = Resources.GShopEditor_PW_mnuUndo;
		toolStripMenuItem_17.Name = Class16.smethod_0(1648969955);
		toolStripMenuItem_17.ShortcutKeys = Keys.Z | Keys.Control;
		toolStripMenuItem_17.Size = new Size(294, 22);
		toolStripMenuItem_17.Text = Class16.smethod_0(1648903487);
		toolStripMenuItem_17.Visible = false;
		toolStripMenuItem_18.Enabled = false;
		toolStripMenuItem_18.Image = Resources.GShopEditor_PW_mnuRedo;
		toolStripMenuItem_18.Name = Class16.smethod_0(1648969969);
		toolStripMenuItem_18.ShortcutKeys = Keys.Y | Keys.Control;
		toolStripMenuItem_18.Size = new Size(294, 22);
		toolStripMenuItem_18.Text = Class16.smethod_0(1648903490);
		toolStripMenuItem_18.Visible = false;
		toolStripSeparator_4.Name = Class16.smethod_0(1649069671);
		toolStripSeparator_4.Size = new Size(291, 6);
		toolStripSeparator_4.Visible = false;
		toolStripMenuItem_37.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		toolStripMenuItem_37.Image = Resources.mnuAutoFixAllBugs;
		toolStripMenuItem_37.Name = Class16.smethod_0(1649069688);
		toolStripMenuItem_37.Size = new Size(294, 22);
		toolStripMenuItem_37.Text = Class16.smethod_0(1649069712);
		toolStripMenuItem_37.Click += toolStripMenuItem_37_Click;
		toolStripMenuItem_6.Image = Resources.GShopEditor_PW_mnuSearch;
		toolStripMenuItem_6.Name = Class16.smethod_0(1649069745);
		toolStripMenuItem_6.ShortcutKeys = Keys.F | Keys.Control;
		toolStripMenuItem_6.Size = new Size(294, 22);
		toolStripMenuItem_6.Text = Class16.smethod_0(1648931650);
		toolStripMenuItem_6.Click += toolStripMenuItem_6_Click;
		toolStripSeparator_2.Name = Class16.smethod_0(1649073717);
		toolStripSeparator_2.Size = new Size(291, 6);
		toolStripMenuItem_7.DropDownItems.AddRange(new ToolStripItem[4] { toolStripMenuItem_8, toolStripMenuItem_14, toolStripMenuItem_15, toolStripMenuItem_16 });
		toolStripMenuItem_7.Image = Resources.mnuActiveSaleOption;
		toolStripMenuItem_7.Name = Class16.smethod_0(1648900906);
		toolStripMenuItem_7.Size = new Size(294, 22);
		toolStripMenuItem_7.Text = Class16.smethod_0(1649069761);
		toolStripMenuItem_8.Checked = true;
		toolStripMenuItem_8.CheckState = CheckState.Checked;
		toolStripMenuItem_8.Name = Class16.smethod_0(1649069786);
		toolStripMenuItem_8.Size = new Size(168, 22);
		toolStripMenuItem_8.Text = Class16.smethod_0(1649069815);
		toolStripMenuItem_8.Click += toolStripMenuItem_16_Click;
		toolStripMenuItem_14.Name = Class16.smethod_0(1649069832);
		toolStripMenuItem_14.Size = new Size(168, 22);
		toolStripMenuItem_14.Text = Class16.smethod_0(1649069861);
		toolStripMenuItem_14.Click += toolStripMenuItem_16_Click;
		toolStripMenuItem_15.Name = Class16.smethod_0(1649069876);
		toolStripMenuItem_15.Size = new Size(168, 22);
		toolStripMenuItem_15.Text = Class16.smethod_0(1649069889);
		toolStripMenuItem_15.Click += toolStripMenuItem_16_Click;
		toolStripMenuItem_16.Name = Class16.smethod_0(1649069904);
		toolStripMenuItem_16.Size = new Size(168, 22);
		toolStripMenuItem_16.Text = Class16.smethod_0(1649069933);
		toolStripMenuItem_16.Click += toolStripMenuItem_16_Click;
		toolStripSeparator_3.Name = Class16.smethod_0(1649003364);
		toolStripSeparator_3.Size = new Size(291, 6);
		toolStripMenuItem_11.Image = Resources.GShopEditor_PW_mnuExportSelectedItems;
		toolStripMenuItem_11.Name = Class16.smethod_0(1649069948);
		toolStripMenuItem_11.Size = new Size(294, 22);
		toolStripMenuItem_11.Text = Class16.smethod_0(1649069969);
		toolStripMenuItem_11.Click += toolStripMenuItem_11_Click;
		toolStripMenuItem_13.Image = Resources.GShopEditor_PW_mnuImport;
		toolStripMenuItem_13.Name = Class16.smethod_0(1649073742);
		toolStripMenuItem_13.Size = new Size(294, 22);
		toolStripMenuItem_13.Text = Class16.smethod_0(1649070005);
		toolStripMenuItem_13.Click += toolStripMenuItem_13_Click;
		toolStripMenuItem_9.DropDownItems.AddRange(new ToolStripItem[3] { toolStripMenuItem_10, toolStripMenuItem_81, toolStripMenuItem_35 });
		toolStripMenuItem_9.Name = Class16.smethod_0(1649070054);
		toolStripMenuItem_9.Size = new Size(44, 20);
		toolStripMenuItem_9.Text = Class16.smethod_0(1648931701);
		toolStripMenuItem_10.Checked = true;
		toolStripMenuItem_10.CheckOnClick = true;
		toolStripMenuItem_10.CheckState = CheckState.Checked;
		toolStripMenuItem_10.Name = Class16.smethod_0(1649070068);
		toolStripMenuItem_10.Size = new Size(327, 22);
		toolStripMenuItem_10.Text = Class16.smethod_0(1649069070);
		toolStripMenuItem_10.Click += toolStripMenuItem_10_Click;
		toolStripMenuItem_81.Checked = true;
		toolStripMenuItem_81.CheckOnClick = true;
		toolStripMenuItem_81.CheckState = CheckState.Checked;
		toolStripMenuItem_81.Name = Class16.smethod_0(1649069082);
		toolStripMenuItem_81.Size = new Size(327, 22);
		toolStripMenuItem_81.Text = Class16.smethod_0(1649069119);
		toolStripMenuItem_81.CheckedChanged += toolStripMenuItem_81_CheckedChanged;
		toolStripMenuItem_81.Click += toolStripMenuItem_81_Click;
		toolStripMenuItem_35.CheckOnClick = true;
		toolStripMenuItem_35.Name = Class16.smethod_0(1649069149);
		toolStripMenuItem_35.Size = new Size(327, 22);
		toolStripMenuItem_35.Text = Class16.smethod_0(1649069170);
		toolStripMenuItem_35.Click += toolStripMenuItem_35_Click;
		toolStripMenuItem_27.DropDownItems.AddRange(new ToolStripItem[14]
		{
			toolStripMenuItem_28, toolStripMenuItem_29, toolStripSeparator_9, toolStripMenuItem_30, toolStripSeparator_10, toolStripMenuItem_73, toolStripMenuItem_31, toolStripMenuItem_32, toolStripMenuItem_49, toolStripMenuItem_60,
			toolStripSeparator_11, toolStripMenuItem_33, toolStripSeparator_14, toolStripMenuItem_44
		});
		toolStripMenuItem_27.Name = Class16.smethod_0(1649069225);
		toolStripMenuItem_27.Size = new Size(62, 20);
		toolStripMenuItem_27.Text = Class16.smethod_0(1649069243);
		toolStripMenuItem_28.Image = Resources.mnuShowJustNotFoundedItems;
		toolStripMenuItem_28.Name = Class16.smethod_0(1649069258);
		toolStripMenuItem_28.Size = new Size(336, 22);
		toolStripMenuItem_28.Text = Class16.smethod_0(1649069291);
		toolStripMenuItem_28.Click += toolStripMenuItem_28_Click;
		toolStripMenuItem_29.Image = Resources.mnuShowItemsWithCount0;
		toolStripMenuItem_29.Name = Class16.smethod_0(1649069328);
		toolStripMenuItem_29.Size = new Size(336, 22);
		toolStripMenuItem_29.Text = Class16.smethod_0(1649069365);
		toolStripMenuItem_29.Click += toolStripMenuItem_29_Click;
		toolStripSeparator_9.Name = Class16.smethod_0(1649069387);
		toolStripSeparator_9.Size = new Size(333, 6);
		toolStripMenuItem_30.Image = Resources.mnuShowNotFoundIcons;
		toolStripMenuItem_30.Name = Class16.smethod_0(1649069421);
		toolStripMenuItem_30.Size = new Size(336, 22);
		toolStripMenuItem_30.Text = Class16.smethod_0(1649069440);
		toolStripMenuItem_30.Click += toolStripMenuItem_30_Click;
		toolStripSeparator_10.Name = Class16.smethod_0(1649069485);
		toolStripSeparator_10.Size = new Size(333, 6);
		toolStripMenuItem_73.Image = Resources.mnuShowFashionSubCat9;
		toolStripMenuItem_73.Name = Class16.smethod_0(1649069511);
		toolStripMenuItem_73.Size = new Size(336, 22);
		toolStripMenuItem_73.Text = Class16.smethod_0(1649069531);
		toolStripMenuItem_73.Visible = false;
		toolStripMenuItem_73.Click += toolStripMenuItem_73_Click;
		toolStripMenuItem_31.Image = Resources.mnuShowItemsWithVeryLongName;
		toolStripMenuItem_31.Name = Class16.smethod_0(1648900257);
		toolStripMenuItem_31.Size = new Size(336, 22);
		toolStripMenuItem_31.Text = Class16.smethod_0(1649068578);
		toolStripMenuItem_31.Click += toolStripMenuItem_31_Click;
		toolStripMenuItem_32.Image = Resources.mnuShowItemWithFullDescription;
		toolStripMenuItem_32.Name = Class16.smethod_0(1648900300);
		toolStripMenuItem_32.Size = new Size(336, 22);
		toolStripMenuItem_32.Text = Class16.smethod_0(1649068637);
		toolStripMenuItem_32.Click += toolStripMenuItem_32_Click;
		toolStripMenuItem_49.Image = Resources.mnuShowItemsWithEqualsID;
		toolStripMenuItem_49.Name = Class16.smethod_0(1648900193);
		toolStripMenuItem_49.Size = new Size(336, 22);
		toolStripMenuItem_49.Text = Class16.smethod_0(1649068675);
		toolStripMenuItem_49.Click += toolStripMenuItem_49_Click;
		toolStripMenuItem_60.Image = Resources.mnuShowItemsWithEqualsName;
		toolStripMenuItem_60.Name = Class16.smethod_0(1648900224);
		toolStripMenuItem_60.Size = new Size(336, 22);
		toolStripMenuItem_60.Text = Class16.smethod_0(1649068718);
		toolStripMenuItem_60.Click += toolStripMenuItem_60_Click;
		toolStripSeparator_11.Name = Class16.smethod_0(1649068750);
		toolStripSeparator_11.Size = new Size(333, 6);
		toolStripMenuItem_33.Image = Resources.mnuShowItemsWithBuggedPileNum;
		toolStripMenuItem_33.Name = Class16.smethod_0(1649068768);
		toolStripMenuItem_33.Size = new Size(336, 22);
		toolStripMenuItem_33.Text = Class16.smethod_0(1649068812);
		toolStripMenuItem_33.Click += toolStripMenuItem_33_Click;
		toolStripSeparator_14.Name = Class16.smethod_0(1649068857);
		toolStripSeparator_14.Size = new Size(333, 6);
		toolStripMenuItem_44.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		toolStripMenuItem_44.Image = Resources.mnuAAutoFixAllBugs;
		toolStripMenuItem_44.Name = Class16.smethod_0(1649068883);
		toolStripMenuItem_44.Size = new Size(336, 22);
		toolStripMenuItem_44.Text = Class16.smethod_0(1649069712);
		toolStripMenuItem_44.Click += toolStripMenuItem_44_Click;
		toolStripMenuItem_21.DropDownItems.AddRange(new ToolStripItem[5] { toolStripMenuItem_22, toolStripMenuItem_23, toolStripMenuItem_34, toolStripSeparator_12, toolStripMenuItem_38 });
		toolStripMenuItem_21.Name = Class16.smethod_0(1648900183);
		toolStripMenuItem_21.Size = new Size(61, 20);
		toolStripMenuItem_21.Text = Class16.smethod_0(1649068916);
		toolStripMenuItem_22.Checked = true;
		toolStripMenuItem_22.CheckOnClick = true;
		toolStripMenuItem_22.CheckState = CheckState.Checked;
		toolStripMenuItem_22.Name = Class16.smethod_0(1649068923);
		toolStripMenuItem_22.Size = new Size(367, 22);
		toolStripMenuItem_22.Text = Class16.smethod_0(1649068944);
		toolStripMenuItem_23.Checked = true;
		toolStripMenuItem_23.CheckOnClick = true;
		toolStripMenuItem_23.CheckState = CheckState.Checked;
		toolStripMenuItem_23.Name = Class16.smethod_0(1649069005);
		toolStripMenuItem_23.Size = new Size(367, 22);
		toolStripMenuItem_23.Text = Class16.smethod_0(1649069025);
		toolStripMenuItem_34.Checked = true;
		toolStripMenuItem_34.CheckOnClick = true;
		toolStripMenuItem_34.CheckState = CheckState.Checked;
		toolStripMenuItem_34.Name = Class16.smethod_0(1649068069);
		toolStripMenuItem_34.Size = new Size(367, 22);
		toolStripMenuItem_34.Text = Class16.smethod_0(1649068091);
		toolStripSeparator_12.Name = Class16.smethod_0(1649068148);
		toolStripSeparator_12.Size = new Size(364, 6);
		toolStripMenuItem_38.Checked = true;
		toolStripMenuItem_38.CheckOnClick = true;
		toolStripMenuItem_38.CheckState = CheckState.Checked;
		toolStripMenuItem_38.Name = Class16.smethod_0(1649068174);
		toolStripMenuItem_38.Size = new Size(367, 22);
		toolStripMenuItem_38.Text = Class16.smethod_0(1649068203);
		button_2.Dock = DockStyle.Fill;
		button_2.Enabled = false;
		button_2.ForeColor = Color.FromArgb(192, 0, 0);
		button_2.Image = Resources.GShopEditor_PW_cmdDeleteItem;
		button_2.Location = new Point(270, 601);
		button_2.Name = Class16.smethod_0(1649070315);
		button_2.Size = new Size(231, 24);
		button_2.TabIndex = 71;
		button_2.Text = Class16.smethod_0(1648925718);
		button_2.TextAlign = ContentAlignment.MiddleRight;
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_1.Image = Resources.GShopEditor_PW_cmdSearch;
		button_1.Location = new Point(477, 69);
		button_1.Name = Class16.smethod_0(1649070343);
		button_1.Size = new Size(30, 25);
		button_1.TabIndex = 35;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.BackColor = Color.FromArgb(220, 255, 255);
		textBox_0.Location = new Point(31, 70);
		textBox_0.Name = Class16.smethod_0(1648995997);
		textBox_0.Size = new Size(443, 22);
		textBox_0.TabIndex = 34;
		textBox_0.Text = Class16.smethod_0(1649070359);
		textBox_0.TextAlign = HorizontalAlignment.Center;
		textBox_0.Click += textBox_0_Click;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.DoubleClick += textBox_0_DoubleClick;
		textBox_0.Enter += textBox_0_Enter;
		textBox_0.Leave += textBox_0_Leave;
		toolTip_0.AutomaticDelay = 5000;
		toolTip_0.ToolTipIcon = ToolTipIcon.Info;
		button_0.Dock = DockStyle.Fill;
		button_0.Image = Resources.GShopEditor_PW_cmdAddItem;
		button_0.Location = new Point(3, 601);
		button_0.Name = Class16.smethod_0(1649070376);
		button_0.Size = new Size(231, 24);
		button_0.TabIndex = 33;
		button_0.Text = Class16.smethod_0(1648931357);
		button_0.TextAlign = ContentAlignment.MiddleRight;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		contextMenuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		contextMenuStrip_0.Items.AddRange(new ToolStripItem[24]
		{
			toolStripMenuItem_1, toolStripMenuItem_2, toolStripSeparator_8, toolStripMenuItem_25, toolStripSeparator_5, toolStripMenuItem_61, toolStripMenuItem_19, toolStripSeparator_13, toolStripMenuItem_39, toolStripMenuItem_40,
			toolStripMenuItem_41, toolStripMenuItem_42, toolStripMenuItem_43, toolStripMenuItem_26, toolStripSeparator_6, toolStripMenuItem_12, toolStripSeparator_1, toolStripMenuItem_20, toolStripMenuItem_65, toolStripMenuItem_24,
			toolStripMenuItem_80, toolStripSeparator_7, toolStripMenuItem_36, toolStripMenuItem_3
		});
		contextMenuStrip_0.Name = Class16.smethod_0(1649003266);
		contextMenuStrip_0.Size = new Size(284, 436);
		toolStripMenuItem_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		toolStripMenuItem_1.Image = Resources.GShopEditor_PW_mnuClone;
		toolStripMenuItem_1.Name = Class16.smethod_0(1649070444);
		toolStripMenuItem_1.ShortcutKeys = Keys.N | Keys.Control;
		toolStripMenuItem_1.Size = new Size(283, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648931357);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_2.Image = Resources.GShopEditor_PW_mnuDelete;
		toolStripMenuItem_2.Name = Class16.smethod_0(1649003348);
		toolStripMenuItem_2.ShortcutKeys = Keys.Delete;
		toolStripMenuItem_2.Size = new Size(283, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648925718);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripSeparator_8.Name = Class16.smethod_0(1649068258);
		toolStripSeparator_8.Size = new Size(280, 6);
		toolStripMenuItem_25.Image = Resources.mnuAddFromElements;
		toolStripMenuItem_25.Name = Class16.smethod_0(1649068292);
		toolStripMenuItem_25.Size = new Size(283, 22);
		toolStripMenuItem_25.Text = Class16.smethod_0(1649068317);
		toolStripMenuItem_25.Click += toolStripMenuItem_25_Click;
		toolStripSeparator_5.Name = Class16.smethod_0(1649068344);
		toolStripSeparator_5.Size = new Size(280, 6);
		toolStripMenuItem_61.DropDownItems.AddRange(new ToolStripItem[4] { toolStripMenuItem_62, toolStripMenuItem_63, toolStripSeparator_23, toolStripMenuItem_64 });
		toolStripMenuItem_61.Image = Resources.GShopEditor_PW_mnuMoveItems;
		toolStripMenuItem_61.Name = Class16.smethod_0(1649068369);
		toolStripMenuItem_61.Size = new Size(283, 22);
		toolStripMenuItem_61.Text = Class16.smethod_0(1649068396);
		toolStripMenuItem_62.Image = Resources.mnuMoveToFirstPlace;
		toolStripMenuItem_62.Name = Class16.smethod_0(1649068413);
		toolStripMenuItem_62.ShortcutKeys = Keys.Up | Keys.Control | Keys.Alt;
		toolStripMenuItem_62.Size = new Size(340, 22);
		toolStripMenuItem_62.Text = Class16.smethod_0(1649068439);
		toolStripMenuItem_62.Click += toolStripMenuItem_62_Click;
		toolStripMenuItem_63.Image = Resources.mnuMoveToEnd;
		toolStripMenuItem_63.Name = Class16.smethod_0(1649068462);
		toolStripMenuItem_63.ShortcutKeys = Keys.Down | Keys.Control | Keys.Alt;
		toolStripMenuItem_63.Size = new Size(340, 22);
		toolStripMenuItem_63.Text = Class16.smethod_0(1649068473);
		toolStripMenuItem_63.Click += toolStripMenuItem_63_Click;
		toolStripSeparator_23.Name = Class16.smethod_0(1649068490);
		toolStripSeparator_23.Size = new Size(337, 6);
		toolStripMenuItem_64.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Italic, GraphicsUnit.Point, 204);
		toolStripMenuItem_64.Image = Resources.mnuAdvancedMoving;
		toolStripMenuItem_64.Name = Class16.smethod_0(1649068524);
		toolStripMenuItem_64.Size = new Size(340, 22);
		toolStripMenuItem_64.Text = Class16.smethod_0(1649063428);
		toolStripMenuItem_64.Click += toolStripMenuItem_64_Click;
		toolStripMenuItem_19.Image = Resources.GShopEditor_PW_mnuChangeCat;
		toolStripMenuItem_19.Name = Class16.smethod_0(1649070525);
		toolStripMenuItem_19.Size = new Size(283, 22);
		toolStripMenuItem_19.Text = Class16.smethod_0(1649063475);
		toolStripMenuItem_19.Click += toolStripMenuItem_19_Click;
		toolStripSeparator_13.Name = Class16.smethod_0(1649063497);
		toolStripSeparator_13.Size = new Size(280, 6);
		toolStripMenuItem_39.Image = Resources.mnuSetDiscount10;
		toolStripMenuItem_39.Name = Class16.smethod_0(1649063523);
		toolStripMenuItem_39.Size = new Size(283, 22);
		toolStripMenuItem_39.Text = Class16.smethod_0(1649063546);
		toolStripMenuItem_39.Click += toolStripMenuItem_39_Click;
		toolStripMenuItem_40.Image = Resources.mnuSetDiscount20;
		toolStripMenuItem_40.Name = Class16.smethod_0(1649063576);
		toolStripMenuItem_40.Size = new Size(283, 22);
		toolStripMenuItem_40.Text = Class16.smethod_0(1649063607);
		toolStripMenuItem_40.Click += toolStripMenuItem_40_Click;
		toolStripMenuItem_41.Image = Resources.mnuSetDiscount30;
		toolStripMenuItem_41.Name = Class16.smethod_0(1649063637);
		toolStripMenuItem_41.Size = new Size(283, 22);
		toolStripMenuItem_41.Text = Class16.smethod_0(1649063660);
		toolStripMenuItem_41.Click += toolStripMenuItem_41_Click;
		toolStripMenuItem_42.Image = Resources.mnuSetDiscount50;
		toolStripMenuItem_42.Name = Class16.smethod_0(1649063682);
		toolStripMenuItem_42.Size = new Size(283, 22);
		toolStripMenuItem_42.Text = Class16.smethod_0(1649063660);
		toolStripMenuItem_42.Click += toolStripMenuItem_42_Click;
		toolStripMenuItem_43.Image = Resources.mnuSetDiscount90;
		toolStripMenuItem_43.Name = Class16.smethod_0(1649063705);
		toolStripMenuItem_43.Size = new Size(283, 22);
		toolStripMenuItem_43.Text = Class16.smethod_0(1649063660);
		toolStripMenuItem_43.Click += toolStripMenuItem_43_Click;
		toolStripMenuItem_26.Image = Resources.mnuAdvancedPriceChanger;
		toolStripMenuItem_26.Name = Class16.smethod_0(1649063728);
		toolStripMenuItem_26.Size = new Size(283, 22);
		toolStripMenuItem_26.Text = Class16.smethod_0(1649063766);
		toolStripMenuItem_26.Click += toolStripMenuItem_26_Click;
		toolStripSeparator_6.Name = Class16.smethod_0(1649063787);
		toolStripSeparator_6.Size = new Size(280, 6);
		toolStripMenuItem_12.Image = Resources.GShopEditor_PW_mnuExport;
		toolStripMenuItem_12.Name = Class16.smethod_0(1648996987);
		toolStripMenuItem_12.Size = new Size(283, 22);
		toolStripMenuItem_12.Text = Class16.smethod_0(1649063820);
		toolStripMenuItem_12.Click += toolStripMenuItem_12_Click;
		toolStripSeparator_1.Name = Class16.smethod_0(1649004015);
		toolStripSeparator_1.Size = new Size(280, 6);
		toolStripMenuItem_20.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		toolStripMenuItem_20.Image = Resources.mnuSetNamesByGoodsNames;
		toolStripMenuItem_20.Name = Class16.smethod_0(1648900106);
		toolStripMenuItem_20.Size = new Size(283, 22);
		toolStripMenuItem_20.Text = Class16.smethod_0(1649063839);
		toolStripMenuItem_20.Click += toolStripMenuItem_20_Click;
		toolStripMenuItem_65.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		toolStripMenuItem_65.Image = Resources.mnuSetNamesByGoodsNamesWithCount;
		toolStripMenuItem_65.Name = Class16.smethod_0(1648900136);
		toolStripMenuItem_65.Size = new Size(283, 22);
		toolStripMenuItem_65.Text = Class16.smethod_0(1649063869);
		toolStripMenuItem_65.Click += toolStripMenuItem_65_Click;
		toolStripMenuItem_24.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		toolStripMenuItem_24.Image = Resources.mnuSetItemDescriptionByGoodsDescription;
		toolStripMenuItem_24.Name = Class16.smethod_0(1648901092);
		toolStripMenuItem_24.Size = new Size(283, 22);
		toolStripMenuItem_24.Text = Class16.smethod_0(1649063908);
		toolStripMenuItem_24.Click += toolStripMenuItem_24_Click;
		toolStripMenuItem_80.Image = Resources.mnuFixItems;
		toolStripMenuItem_80.Name = Class16.smethod_0(1649062920);
		toolStripMenuItem_80.Size = new Size(283, 22);
		toolStripMenuItem_80.Text = Class16.smethod_0(1649062938);
		toolStripMenuItem_80.Click += toolStripMenuItem_80_Click;
		toolStripSeparator_7.Name = Class16.smethod_0(1649062981);
		toolStripSeparator_7.Size = new Size(280, 6);
		toolStripMenuItem_36.Image = Resources.mnuGoToItemCat;
		toolStripMenuItem_36.Name = Class16.smethod_0(1649063006);
		toolStripMenuItem_36.Size = new Size(283, 22);
		toolStripMenuItem_36.Text = Class16.smethod_0(1649063019);
		toolStripMenuItem_36.Click += toolStripMenuItem_36_Click;
		toolStripMenuItem_3.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		toolStripMenuItem_3.Image = Resources.GShopEditor_PW_mnuGoTo;
		toolStripMenuItem_3.Name = Class16.smethod_0(1649070591);
		toolStripMenuItem_3.ShortcutKeys = Keys.G | Keys.Control;
		toolStripMenuItem_3.Size = new Size(283, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1649063053);
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		panel_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		panel_0.Controls.Add(tableLayoutPanel_1);
		panel_0.Controls.Add(textBox_8);
		panel_0.Controls.Add(button_12);
		panel_0.Controls.Add(tableLayoutPanel_0);
		panel_0.Controls.Add(button_1);
		panel_0.Controls.Add(textBox_0);
		panel_0.Controls.Add(groupBox_0);
		panel_0.Controls.Add(button_10);
		panel_0.Controls.Add(checkBox_1);
		panel_0.Location = new Point(3, 52);
		panel_0.Name = Class16.smethod_0(1648930054);
		panel_0.Size = new Size(1169, 724);
		panel_0.TabIndex = 81;
		tableLayoutPanel_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tableLayoutPanel_1.ColumnCount = 3;
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30f));
		tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel_1.Controls.Add(dataGridViewEx_0, 0, 0);
		tableLayoutPanel_1.Controls.Add(button_0, 0, 1);
		tableLayoutPanel_1.Controls.Add(button_2, 2, 1);
		tableLayoutPanel_1.Controls.Add(button_11, 1, 1);
		tableLayoutPanel_1.Location = new Point(3, 96);
		tableLayoutPanel_1.Name = Class16.smethod_0(1648929329);
		tableLayoutPanel_1.RowCount = 2;
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		tableLayoutPanel_1.Size = new Size(504, 628);
		tableLayoutPanel_1.TabIndex = 113;
		dataGridViewEx_0.AllowDrop = true;
		dataGridViewEx_0.AllowUserToAddRows = false;
		dataGridViewEx_0.AllowUserToDeleteRows = false;
		dataGridViewEx_0.BackgroundColor = Color.FromArgb(32, 32, 32);
		dataGridViewEx_0.BorderStyle = BorderStyle.None;
		dataGridViewEx_0.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridViewEx_0.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridViewEx_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewEx_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewEx_0.Columns.AddRange(dataGridViewTextBoxColumn_7, dataGridViewTextBoxColumn_8, dataGridViewImageColumn_1, dataGridViewTextBoxColumn_9, dataGridViewTextBoxColumn_10, dataGridViewTextBoxColumn_11, dataGridViewTextBoxColumn_12);
		tableLayoutPanel_1.SetColumnSpan(dataGridViewEx_0, 3);
		dataGridViewEx_0.ContextMenuStrip = contextMenuStrip_0;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(32, 32, 32);
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = Color.White;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = Color.White;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridViewEx_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridViewEx_0.Dock = DockStyle.Fill;
		dataGridViewEx_0.EditMode = DataGridViewEditMode.EditProgrammatically;
		dataGridViewEx_0.GridColor = Color.Silver;
		dataGridViewEx_0.Location = new Point(3, 4);
		dataGridViewEx_0.Margin = new Padding(3, 4, 3, 4);
		dataGridViewEx_0.Name = Class16.smethod_0(1649063072);
		dataGridViewEx_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dataGridViewEx_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dataGridViewEx_0.RowHeadersVisible = false;
		dataGridViewEx_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648929920), 9f);
		dataGridViewEx_0.RowsDefaultCellStyle = dataGridViewCellStyle3;
		dataGridViewEx_0.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewEx_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridViewEx_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridViewEx_0.ShowCellToolTips = false;
		dataGridViewEx_0.Size = new Size(498, 590);
		dataGridViewEx_0.TabIndex = 0;
		dataGridViewEx_0.CellDoubleClick += dataGridViewEx_0_CellDoubleClick;
		dataGridViewEx_0.CellMouseDown += dataGridViewEx_0_CellMouseDown;
		dataGridViewEx_0.CellMouseEnter += dataGridViewEx_0_CellMouseEnter;
		dataGridViewEx_0.CellMouseLeave += dataGridViewEx_0_CellMouseLeave;
		dataGridViewEx_0.CellMouseMove += dataGridViewEx_0_CellMouseMove;
		dataGridViewEx_0.SelectionChanged += dataGridViewEx_0_SelectionChanged;
		dataGridViewEx_0.SortCompare += dataGridViewEx_0_SortCompare;
		dataGridViewEx_0.Sorted += dataGridViewEx_0_Sorted;
		dataGridViewEx_0.DragOver += dataGridViewEx_0_DragOver;
		dataGridViewEx_0.MouseDown += dataGridViewEx_0_MouseDown;
		dataGridViewEx_0.MouseLeave += dataGridViewEx_0_MouseLeave;
		dataGridViewEx_0.MouseHover += dataGridViewEx_0_MouseHover;
		dataGridViewEx_0.MouseUp += dataGridViewEx_0_MouseUp;
		dataGridViewTextBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle4.ForeColor = Color.Silver;
		dataGridViewTextBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_7.Frozen = true;
		dataGridViewTextBoxColumn_7.HeaderText = Class16.smethod_0(1649063088);
		dataGridViewTextBoxColumn_7.Name = Class16.smethod_0(1648929955);
		dataGridViewTextBoxColumn_7.ReadOnly = true;
		dataGridViewTextBoxColumn_7.Width = 40;
		dataGridViewTextBoxColumn_8.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle5.ForeColor = Color.FromArgb(224, 224, 224);
		dataGridViewTextBoxColumn_8.DefaultCellStyle = dataGridViewCellStyle5;
		dataGridViewTextBoxColumn_8.Frozen = true;
		dataGridViewTextBoxColumn_8.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_8.Name = Class16.smethod_0(1649063108);
		dataGridViewTextBoxColumn_8.ReadOnly = true;
		dataGridViewTextBoxColumn_8.Width = 60;
		dataGridViewImageColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewImageColumn_1.Frozen = true;
		dataGridViewImageColumn_1.HeaderText = string.Empty;
		dataGridViewImageColumn_1.Name = Class16.smethod_0(1648930015);
		dataGridViewImageColumn_1.ReadOnly = true;
		dataGridViewImageColumn_1.Resizable = DataGridViewTriState.False;
		dataGridViewImageColumn_1.Width = 20;
		dataGridViewTextBoxColumn_9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle6.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewTextBoxColumn_9.DefaultCellStyle = dataGridViewCellStyle6;
		dataGridViewTextBoxColumn_9.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_9.Name = Class16.smethod_0(1649012442);
		dataGridViewTextBoxColumn_9.ReadOnly = true;
		dataGridViewTextBoxColumn_9.Resizable = DataGridViewTriState.True;
		dataGridViewTextBoxColumn_10.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle7.Font = new Font(Class16.smethod_0(1648942905), 7.8f);
		dataGridViewTextBoxColumn_10.DefaultCellStyle = dataGridViewCellStyle7;
		dataGridViewTextBoxColumn_10.HeaderText = Class16.smethod_0(1648968311);
		dataGridViewTextBoxColumn_10.Name = Class16.smethod_0(1649063113);
		dataGridViewTextBoxColumn_10.ReadOnly = true;
		dataGridViewTextBoxColumn_10.Width = 60;
		dataGridViewTextBoxColumn_11.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle8.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		dataGridViewCellStyle8.ForeColor = Color.Gold;
		dataGridViewTextBoxColumn_11.DefaultCellStyle = dataGridViewCellStyle8;
		dataGridViewTextBoxColumn_11.HeaderText = Class16.smethod_0(1648970377);
		dataGridViewTextBoxColumn_11.Name = Class16.smethod_0(1649070429);
		dataGridViewTextBoxColumn_11.ReadOnly = true;
		dataGridViewTextBoxColumn_11.Width = 80;
		dataGridViewTextBoxColumn_12.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle9.Font = new Font(Class16.smethod_0(1648942905), 7.8f);
		dataGridViewTextBoxColumn_12.DefaultCellStyle = dataGridViewCellStyle9;
		dataGridViewTextBoxColumn_12.HeaderText = Class16.smethod_0(1648958804);
		dataGridViewTextBoxColumn_12.Name = Class16.smethod_0(1649063128);
		dataGridViewTextBoxColumn_12.ReadOnly = true;
		dataGridViewTextBoxColumn_12.ToolTipText = Class16.smethod_0(1649063139);
		dataGridViewTextBoxColumn_12.Width = 45;
		button_11.Dock = DockStyle.Fill;
		button_11.Image = Resources.GShopEditor_PW_cmdAddFromElements;
		button_11.Location = new Point(240, 601);
		button_11.Name = Class16.smethod_0(1649073880);
		button_11.Size = new Size(24, 24);
		button_11.TabIndex = 110;
		button_11.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(button_11, Class16.smethod_0(1649068317));
		button_11.UseVisualStyleBackColor = true;
		button_11.Click += button_11_Click;
		textBox_8.Location = new Point(31, 83);
		textBox_8.MaxLength = 10;
		textBox_8.Name = Class16.smethod_0(1649071144);
		textBox_8.Size = new Size(124, 22);
		textBox_8.TabIndex = 112;
		textBox_8.TextAlign = HorizontalAlignment.Center;
		textBox_8.Visible = false;
		textBox_8.KeyUp += textBox_8_KeyUp;
		textBox_8.Leave += textBox_8_Leave;
		button_12.Image = Resources.cmdRefreshItems;
		button_12.Location = new Point(5, 70);
		button_12.Name = Class16.smethod_0(1649063185);
		button_12.Size = new Size(24, 22);
		button_12.TabIndex = 111;
		button_12.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(button_12, Class16.smethod_0(1649063215));
		button_12.UseVisualStyleBackColor = true;
		button_12.Click += button_12_Click;
		tableLayoutPanel_0.ColumnCount = 10;
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.46658f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.46658f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.46658f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.46658f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.46658f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.46658f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.46658f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.46658f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.267387f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
		tableLayoutPanel_0.Controls.Add(radioButton_18, 9, 0);
		tableLayoutPanel_0.Controls.Add(radioButton_17, 0, 0);
		tableLayoutPanel_0.Controls.Add(radioButton_0, 8, 1);
		tableLayoutPanel_0.Controls.Add(radioButton_1, 7, 1);
		tableLayoutPanel_0.Controls.Add(radioButton_2, 6, 1);
		tableLayoutPanel_0.Controls.Add(radioButton_3, 5, 1);
		tableLayoutPanel_0.Controls.Add(radioButton_4, 4, 1);
		tableLayoutPanel_0.Controls.Add(radioButton_5, 3, 1);
		tableLayoutPanel_0.Controls.Add(radioButton_6, 2, 1);
		tableLayoutPanel_0.Controls.Add(radioButton_7, 1, 1);
		tableLayoutPanel_0.Controls.Add(radioButton_8, 0, 1);
		tableLayoutPanel_0.Controls.Add(radioButton_9, 8, 0);
		tableLayoutPanel_0.Controls.Add(radioButton_10, 7, 0);
		tableLayoutPanel_0.Controls.Add(radioButton_11, 6, 0);
		tableLayoutPanel_0.Controls.Add(radioButton_12, 5, 0);
		tableLayoutPanel_0.Controls.Add(radioButton_13, 4, 0);
		tableLayoutPanel_0.Controls.Add(radioButton_14, 3, 0);
		tableLayoutPanel_0.Controls.Add(radioButton_15, 2, 0);
		tableLayoutPanel_0.Controls.Add(radioButton_16, 1, 0);
		tableLayoutPanel_0.Dock = DockStyle.Top;
		tableLayoutPanel_0.Location = new Point(0, 0);
		tableLayoutPanel_0.Name = Class16.smethod_0(1649063227);
		tableLayoutPanel_0.RowCount = 2;
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 55f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 45f));
		tableLayoutPanel_0.Size = new Size(1169, 65);
		tableLayoutPanel_0.TabIndex = 76;
		radioButton_18.Appearance = Appearance.Button;
		radioButton_18.AutoCheck = false;
		radioButton_18.AutoSize = true;
		radioButton_18.Dock = DockStyle.Fill;
		radioButton_18.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_18.Image = Resources.optFilter;
		radioButton_18.Location = new Point(1120, 3);
		radioButton_18.Name = Class16.smethod_0(1648895496);
		tableLayoutPanel_0.SetRowSpan(radioButton_18, 2);
		radioButton_18.Size = new Size(46, 59);
		radioButton_18.TabIndex = 94;
		radioButton_18.TabStop = true;
		radioButton_18.TextAlign = ContentAlignment.MiddleRight;
		radioButton_18.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_18, Class16.smethod_0(1648935595));
		radioButton_18.UseVisualStyleBackColor = true;
		radioButton_18.Click += radioButton_18_Click;
		radioButton_17.AllowDrop = true;
		radioButton_17.Appearance = Appearance.Button;
		radioButton_17.AutoCheck = false;
		radioButton_17.ContextMenuStrip = contextMenuStrip_1;
		radioButton_17.Dock = DockStyle.Fill;
		radioButton_17.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_17.Image = Resources.optCat0;
		radioButton_17.Location = new Point(3, 3);
		radioButton_17.Name = Class16.smethod_0(1649063241);
		radioButton_17.Size = new Size(122, 29);
		radioButton_17.TabIndex = 93;
		radioButton_17.TabStop = true;
		radioButton_17.TextAlign = ContentAlignment.MiddleRight;
		radioButton_17.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_17, Class16.smethod_0(1649063263));
		radioButton_17.UseVisualStyleBackColor = true;
		radioButton_17.Click += radioButton_16_Click;
		radioButton_17.DragDrop += radioButton_16_DragDrop;
		radioButton_17.DragEnter += radioButton_16_DragEnter;
		radioButton_17.MouseDown += radioButton_16_MouseDown;
		radioButton_17.MouseMove += radioButton_16_MouseMove;
		contextMenuStrip_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		contextMenuStrip_1.Items.AddRange(new ToolStripItem[3] { toolStripMenuItem_45, toolStripSeparator_16, toolStripMenuItem_47 });
		contextMenuStrip_1.Name = Class16.smethod_0(1649003266);
		contextMenuStrip_1.Size = new Size(251, 54);
		toolStripMenuItem_45.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		toolStripMenuItem_45.Image = Resources.mnuRenameCat;
		toolStripMenuItem_45.Name = Class16.smethod_0(1649063349);
		toolStripMenuItem_45.Size = new Size(250, 22);
		toolStripMenuItem_45.Text = Class16.smethod_0(1649063360);
		toolStripMenuItem_45.Click += toolStripMenuItem_45_Click;
		toolStripSeparator_16.Name = Class16.smethod_0(1649063381);
		toolStripSeparator_16.Size = new Size(247, 6);
		toolStripMenuItem_47.ForeColor = Color.Black;
		toolStripMenuItem_47.Image = Resources.mnuRemoveAllSubCatsAndItems;
		toolStripMenuItem_47.Name = Class16.smethod_0(1649063407);
		toolStripMenuItem_47.Size = new Size(250, 22);
		toolStripMenuItem_47.Text = Class16.smethod_0(1649062409);
		toolStripMenuItem_47.Click += toolStripMenuItem_47_Click;
		radioButton_0.Appearance = Appearance.Button;
		radioButton_0.AutoCheck = false;
		radioButton_0.Dock = DockStyle.Fill;
		radioButton_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_0.Image = Resources.optAllSubCats;
		radioButton_0.Location = new Point(1027, 38);
		radioButton_0.Name = Class16.smethod_0(1649062450);
		radioButton_0.Size = new Size(87, 24);
		radioButton_0.TabIndex = 92;
		radioButton_0.TabStop = true;
		radioButton_0.Text = Class16.smethod_0(1649062478);
		radioButton_0.TextAlign = ContentAlignment.MiddleRight;
		radioButton_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		radioButton_0.UseVisualStyleBackColor = true;
		radioButton_0.MouseDown += radioButton_8_MouseDown;
		radioButton_1.AllowDrop = true;
		radioButton_1.Appearance = Appearance.Button;
		radioButton_1.AutoCheck = false;
		radioButton_1.ContextMenuStrip = contextMenuStrip_2;
		radioButton_1.Dock = DockStyle.Fill;
		radioButton_1.Font = new Font(Class16.smethod_0(1648942905), 8.8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_1.Image = Resources.optSubCat7;
		radioButton_1.Location = new Point(899, 38);
		radioButton_1.Name = Class16.smethod_0(1649062492);
		radioButton_1.Size = new Size(122, 24);
		radioButton_1.TabIndex = 91;
		radioButton_1.TabStop = true;
		radioButton_1.TextAlign = ContentAlignment.MiddleRight;
		radioButton_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_1, Class16.smethod_0(1649062509));
		radioButton_1.UseVisualStyleBackColor = true;
		radioButton_1.Click += radioButton_8_Click;
		radioButton_1.DragDrop += radioButton_8_DragDrop;
		radioButton_1.DragEnter += radioButton_8_DragEnter;
		radioButton_1.DragOver += radioButton_8_DragOver;
		radioButton_1.MouseDown += radioButton_8_MouseDown;
		radioButton_1.MouseMove += radioButton_8_MouseMove;
		contextMenuStrip_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		contextMenuStrip_2.Items.AddRange(new ToolStripItem[4] { toolStripMenuItem_46, toolStripSeparator_15, toolStripMenuItem_50, toolStripMenuItem_48 });
		contextMenuStrip_2.Name = Class16.smethod_0(1649003266);
		contextMenuStrip_2.Size = new Size(211, 76);
		contextMenuStrip_2.Opening += contextMenuStrip_2_Opening;
		toolStripMenuItem_46.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		toolStripMenuItem_46.Image = Resources.mnuRenameSubCat;
		toolStripMenuItem_46.Name = Class16.smethod_0(1649062557);
		toolStripMenuItem_46.Size = new Size(210, 22);
		toolStripMenuItem_46.Text = Class16.smethod_0(1649063360);
		toolStripMenuItem_46.Click += toolStripMenuItem_46_Click;
		toolStripSeparator_15.Name = Class16.smethod_0(1649072092);
		toolStripSeparator_15.Size = new Size(207, 6);
		toolStripMenuItem_50.Image = Resources.mnuDeleteSubCat;
		toolStripMenuItem_50.Name = Class16.smethod_0(1649062571);
		toolStripMenuItem_50.Size = new Size(210, 22);
		toolStripMenuItem_50.Text = Class16.smethod_0(1649062593);
		toolStripMenuItem_50.Click += toolStripMenuItem_50_Click;
		toolStripMenuItem_48.ForeColor = Color.Black;
		toolStripMenuItem_48.Image = Resources.mnuRemoveSubCatAndItems;
		toolStripMenuItem_48.Name = Class16.smethod_0(1649062628);
		toolStripMenuItem_48.Size = new Size(210, 22);
		toolStripMenuItem_48.Text = Class16.smethod_0(1649062650);
		toolStripMenuItem_48.Click += toolStripMenuItem_48_Click;
		radioButton_2.AllowDrop = true;
		radioButton_2.Appearance = Appearance.Button;
		radioButton_2.AutoCheck = false;
		radioButton_2.ContextMenuStrip = contextMenuStrip_2;
		radioButton_2.Dock = DockStyle.Fill;
		radioButton_2.Font = new Font(Class16.smethod_0(1648942905), 8.8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_2.Image = Resources.optSubCat6;
		radioButton_2.Location = new Point(771, 38);
		radioButton_2.Name = Class16.smethod_0(1649062683);
		radioButton_2.Size = new Size(122, 24);
		radioButton_2.TabIndex = 90;
		radioButton_2.TabStop = true;
		radioButton_2.TextAlign = ContentAlignment.MiddleRight;
		radioButton_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_2, Class16.smethod_0(1649062509));
		radioButton_2.UseVisualStyleBackColor = true;
		radioButton_2.Click += radioButton_8_Click;
		radioButton_2.DragDrop += radioButton_8_DragDrop;
		radioButton_2.DragEnter += radioButton_8_DragEnter;
		radioButton_2.DragOver += radioButton_8_DragOver;
		radioButton_2.MouseDown += radioButton_8_MouseDown;
		radioButton_2.MouseMove += radioButton_8_MouseMove;
		radioButton_3.AllowDrop = true;
		radioButton_3.Appearance = Appearance.Button;
		radioButton_3.AutoCheck = false;
		radioButton_3.ContextMenuStrip = contextMenuStrip_2;
		radioButton_3.Dock = DockStyle.Fill;
		radioButton_3.Font = new Font(Class16.smethod_0(1648942905), 8.8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_3.Image = Resources.optSubCat5;
		radioButton_3.Location = new Point(643, 38);
		radioButton_3.Name = Class16.smethod_0(1649062708);
		radioButton_3.Size = new Size(122, 24);
		radioButton_3.TabIndex = 89;
		radioButton_3.TabStop = true;
		radioButton_3.TextAlign = ContentAlignment.MiddleRight;
		radioButton_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_3, Class16.smethod_0(1649062509));
		radioButton_3.UseVisualStyleBackColor = true;
		radioButton_3.Click += radioButton_8_Click;
		radioButton_3.DragDrop += radioButton_8_DragDrop;
		radioButton_3.DragEnter += radioButton_8_DragEnter;
		radioButton_3.DragOver += radioButton_8_DragOver;
		radioButton_3.MouseDown += radioButton_8_MouseDown;
		radioButton_3.MouseMove += radioButton_8_MouseMove;
		radioButton_4.AllowDrop = true;
		radioButton_4.Appearance = Appearance.Button;
		radioButton_4.AutoCheck = false;
		radioButton_4.ContextMenuStrip = contextMenuStrip_2;
		radioButton_4.Dock = DockStyle.Fill;
		radioButton_4.Font = new Font(Class16.smethod_0(1648942905), 8.8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_4.Image = Resources.optSubCat4;
		radioButton_4.Location = new Point(515, 38);
		radioButton_4.Name = Class16.smethod_0(1649062725);
		radioButton_4.Size = new Size(122, 24);
		radioButton_4.TabIndex = 88;
		radioButton_4.TabStop = true;
		radioButton_4.TextAlign = ContentAlignment.MiddleRight;
		radioButton_4.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_4, Class16.smethod_0(1649062509));
		radioButton_4.UseVisualStyleBackColor = true;
		radioButton_4.Click += radioButton_8_Click;
		radioButton_4.DragDrop += radioButton_8_DragDrop;
		radioButton_4.DragEnter += radioButton_8_DragEnter;
		radioButton_4.DragOver += radioButton_8_DragOver;
		radioButton_4.MouseDown += radioButton_8_MouseDown;
		radioButton_4.MouseMove += radioButton_8_MouseMove;
		radioButton_5.AllowDrop = true;
		radioButton_5.Appearance = Appearance.Button;
		radioButton_5.AutoCheck = false;
		radioButton_5.ContextMenuStrip = contextMenuStrip_2;
		radioButton_5.Dock = DockStyle.Fill;
		radioButton_5.Font = new Font(Class16.smethod_0(1648942905), 8.8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_5.Image = Resources.optSubCat3;
		radioButton_5.Location = new Point(387, 38);
		radioButton_5.Name = Class16.smethod_0(1649062742);
		radioButton_5.Size = new Size(122, 24);
		radioButton_5.TabIndex = 87;
		radioButton_5.TabStop = true;
		radioButton_5.TextAlign = ContentAlignment.MiddleRight;
		radioButton_5.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_5, Class16.smethod_0(1649062509));
		radioButton_5.UseVisualStyleBackColor = true;
		radioButton_5.Click += radioButton_8_Click;
		radioButton_5.DragDrop += radioButton_8_DragDrop;
		radioButton_5.DragEnter += radioButton_8_DragEnter;
		radioButton_5.DragOver += radioButton_8_DragOver;
		radioButton_5.MouseDown += radioButton_8_MouseDown;
		radioButton_5.MouseMove += radioButton_8_MouseMove;
		radioButton_6.AllowDrop = true;
		radioButton_6.Appearance = Appearance.Button;
		radioButton_6.AutoCheck = false;
		radioButton_6.ContextMenuStrip = contextMenuStrip_2;
		radioButton_6.Dock = DockStyle.Fill;
		radioButton_6.Font = new Font(Class16.smethod_0(1648942905), 8.8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_6.Image = Resources.optSubCat2;
		radioButton_6.Location = new Point(259, 38);
		radioButton_6.Name = Class16.smethod_0(1649062759);
		radioButton_6.Size = new Size(122, 24);
		radioButton_6.TabIndex = 86;
		radioButton_6.TabStop = true;
		radioButton_6.TextAlign = ContentAlignment.MiddleRight;
		radioButton_6.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_6, Class16.smethod_0(1649062509));
		radioButton_6.UseVisualStyleBackColor = true;
		radioButton_6.Click += radioButton_8_Click;
		radioButton_6.DragDrop += radioButton_8_DragDrop;
		radioButton_6.DragEnter += radioButton_8_DragEnter;
		radioButton_6.DragOver += radioButton_8_DragOver;
		radioButton_6.MouseDown += radioButton_8_MouseDown;
		radioButton_6.MouseMove += radioButton_8_MouseMove;
		radioButton_7.AllowDrop = true;
		radioButton_7.Appearance = Appearance.Button;
		radioButton_7.AutoCheck = false;
		radioButton_7.ContextMenuStrip = contextMenuStrip_2;
		radioButton_7.Dock = DockStyle.Fill;
		radioButton_7.Font = new Font(Class16.smethod_0(1648942905), 8.8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_7.Image = Resources.optSubCat1;
		radioButton_7.Location = new Point(131, 38);
		radioButton_7.Name = Class16.smethod_0(1649062768);
		radioButton_7.Size = new Size(122, 24);
		radioButton_7.TabIndex = 85;
		radioButton_7.TabStop = true;
		radioButton_7.TextAlign = ContentAlignment.MiddleRight;
		radioButton_7.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_7, Class16.smethod_0(1649062509));
		radioButton_7.UseVisualStyleBackColor = true;
		radioButton_7.Click += radioButton_8_Click;
		radioButton_7.DragDrop += radioButton_8_DragDrop;
		radioButton_7.DragEnter += radioButton_8_DragEnter;
		radioButton_7.DragOver += radioButton_8_DragOver;
		radioButton_7.MouseDown += radioButton_8_MouseDown;
		radioButton_7.MouseMove += radioButton_8_MouseMove;
		radioButton_8.AllowDrop = true;
		radioButton_8.Appearance = Appearance.Button;
		radioButton_8.AutoCheck = false;
		radioButton_8.ContextMenuStrip = contextMenuStrip_2;
		radioButton_8.Dock = DockStyle.Fill;
		radioButton_8.Font = new Font(Class16.smethod_0(1648942905), 8.8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_8.Image = Resources.optSubCat0;
		radioButton_8.Location = new Point(3, 38);
		radioButton_8.Name = Class16.smethod_0(1649062785);
		radioButton_8.Size = new Size(122, 24);
		radioButton_8.TabIndex = 84;
		radioButton_8.TabStop = true;
		radioButton_8.TextAlign = ContentAlignment.MiddleRight;
		radioButton_8.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_8, Class16.smethod_0(1649062509));
		radioButton_8.UseVisualStyleBackColor = true;
		radioButton_8.Click += radioButton_8_Click;
		radioButton_8.DragDrop += radioButton_8_DragDrop;
		radioButton_8.DragEnter += radioButton_8_DragEnter;
		radioButton_8.DragOver += radioButton_8_DragOver;
		radioButton_8.MouseDown += radioButton_8_MouseDown;
		radioButton_8.MouseMove += radioButton_8_MouseMove;
		radioButton_9.Appearance = Appearance.Button;
		radioButton_9.AutoCheck = false;
		radioButton_9.Dock = DockStyle.Fill;
		radioButton_9.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_9.Image = Resources.optAllCats;
		radioButton_9.Location = new Point(1027, 3);
		radioButton_9.Name = Class16.smethod_0(1649062802);
		radioButton_9.Size = new Size(87, 29);
		radioButton_9.TabIndex = 83;
		radioButton_9.TabStop = true;
		radioButton_9.Text = Class16.smethod_0(1649062478);
		radioButton_9.TextAlign = ContentAlignment.MiddleRight;
		radioButton_9.TextImageRelation = TextImageRelation.ImageBeforeText;
		radioButton_9.UseVisualStyleBackColor = true;
		radioButton_9.MouseDown += radioButton_16_MouseDown;
		radioButton_10.AllowDrop = true;
		radioButton_10.Appearance = Appearance.Button;
		radioButton_10.AutoCheck = false;
		radioButton_10.ContextMenuStrip = contextMenuStrip_1;
		radioButton_10.Dock = DockStyle.Fill;
		radioButton_10.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_10.Image = Resources.optCat7;
		radioButton_10.Location = new Point(899, 3);
		radioButton_10.Name = Class16.smethod_0(1649062819);
		radioButton_10.Size = new Size(122, 29);
		radioButton_10.TabIndex = 82;
		radioButton_10.TabStop = true;
		radioButton_10.TextAlign = ContentAlignment.MiddleRight;
		radioButton_10.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_10, Class16.smethod_0(1649063263));
		radioButton_10.UseVisualStyleBackColor = true;
		radioButton_10.Click += radioButton_16_Click;
		radioButton_10.DragDrop += radioButton_16_DragDrop;
		radioButton_10.DragEnter += radioButton_16_DragEnter;
		radioButton_10.MouseDown += radioButton_16_MouseDown;
		radioButton_10.MouseMove += radioButton_16_MouseMove;
		radioButton_11.AllowDrop = true;
		radioButton_11.Appearance = Appearance.Button;
		radioButton_11.AutoCheck = false;
		radioButton_11.ContextMenuStrip = contextMenuStrip_1;
		radioButton_11.Dock = DockStyle.Fill;
		radioButton_11.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_11.Image = Resources.optCat6;
		radioButton_11.Location = new Point(771, 3);
		radioButton_11.Name = Class16.smethod_0(1649062833);
		radioButton_11.Size = new Size(122, 29);
		radioButton_11.TabIndex = 81;
		radioButton_11.TabStop = true;
		radioButton_11.TextAlign = ContentAlignment.MiddleRight;
		radioButton_11.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_11, Class16.smethod_0(1649063263));
		radioButton_11.UseVisualStyleBackColor = true;
		radioButton_11.Click += radioButton_16_Click;
		radioButton_11.DragDrop += radioButton_16_DragDrop;
		radioButton_11.DragEnter += radioButton_16_DragEnter;
		radioButton_11.MouseDown += radioButton_16_MouseDown;
		radioButton_11.MouseMove += radioButton_16_MouseMove;
		radioButton_12.AllowDrop = true;
		radioButton_12.Appearance = Appearance.Button;
		radioButton_12.AutoCheck = false;
		radioButton_12.ContextMenuStrip = contextMenuStrip_1;
		radioButton_12.Dock = DockStyle.Fill;
		radioButton_12.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_12.Image = Resources.optCat5;
		radioButton_12.Location = new Point(643, 3);
		radioButton_12.Name = Class16.smethod_0(1649062855);
		radioButton_12.Size = new Size(122, 29);
		radioButton_12.TabIndex = 80;
		radioButton_12.TabStop = true;
		radioButton_12.TextAlign = ContentAlignment.MiddleRight;
		radioButton_12.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_12, Class16.smethod_0(1649063263));
		radioButton_12.UseVisualStyleBackColor = true;
		radioButton_12.Click += radioButton_16_Click;
		radioButton_12.DragDrop += radioButton_16_DragDrop;
		radioButton_12.DragEnter += radioButton_16_DragEnter;
		radioButton_12.MouseDown += radioButton_16_MouseDown;
		radioButton_12.MouseMove += radioButton_16_MouseMove;
		radioButton_13.AllowDrop = true;
		radioButton_13.Appearance = Appearance.Button;
		radioButton_13.AutoCheck = false;
		radioButton_13.ContextMenuStrip = contextMenuStrip_1;
		radioButton_13.Dock = DockStyle.Fill;
		radioButton_13.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_13.Image = Resources.optCat4;
		radioButton_13.Location = new Point(515, 3);
		radioButton_13.Name = Class16.smethod_0(1649062869);
		radioButton_13.Size = new Size(122, 29);
		radioButton_13.TabIndex = 79;
		radioButton_13.TabStop = true;
		radioButton_13.TextAlign = ContentAlignment.MiddleRight;
		radioButton_13.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_13, Class16.smethod_0(1649063263));
		radioButton_13.UseVisualStyleBackColor = true;
		radioButton_13.Click += radioButton_16_Click;
		radioButton_13.DragDrop += radioButton_16_DragDrop;
		radioButton_13.DragEnter += radioButton_16_DragEnter;
		radioButton_13.MouseDown += radioButton_16_MouseDown;
		radioButton_13.MouseMove += radioButton_16_MouseMove;
		radioButton_14.AllowDrop = true;
		radioButton_14.Appearance = Appearance.Button;
		radioButton_14.AutoCheck = false;
		radioButton_14.ContextMenuStrip = contextMenuStrip_1;
		radioButton_14.Dock = DockStyle.Fill;
		radioButton_14.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_14.Image = Resources.optCat3;
		radioButton_14.Location = new Point(387, 3);
		radioButton_14.Name = Class16.smethod_0(1649062875);
		radioButton_14.Size = new Size(122, 29);
		radioButton_14.TabIndex = 78;
		radioButton_14.TabStop = true;
		radioButton_14.TextAlign = ContentAlignment.MiddleRight;
		radioButton_14.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_14, Class16.smethod_0(1649063263));
		radioButton_14.UseVisualStyleBackColor = true;
		radioButton_14.Click += radioButton_16_Click;
		radioButton_14.DragDrop += radioButton_16_DragDrop;
		radioButton_14.DragEnter += radioButton_16_DragEnter;
		radioButton_14.MouseDown += radioButton_16_MouseDown;
		radioButton_14.MouseMove += radioButton_16_MouseMove;
		radioButton_15.AllowDrop = true;
		radioButton_15.Appearance = Appearance.Button;
		radioButton_15.AutoCheck = false;
		radioButton_15.ContextMenuStrip = contextMenuStrip_1;
		radioButton_15.Dock = DockStyle.Fill;
		radioButton_15.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_15.Image = Resources.optCat2;
		radioButton_15.Location = new Point(259, 3);
		radioButton_15.Name = Class16.smethod_0(1649062889);
		radioButton_15.Size = new Size(122, 29);
		radioButton_15.TabIndex = 77;
		radioButton_15.TabStop = true;
		radioButton_15.TextAlign = ContentAlignment.MiddleRight;
		radioButton_15.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_15, Class16.smethod_0(1649063263));
		radioButton_15.UseVisualStyleBackColor = true;
		radioButton_15.Click += radioButton_16_Click;
		radioButton_15.DragDrop += radioButton_16_DragDrop;
		radioButton_15.DragEnter += radioButton_16_DragEnter;
		radioButton_15.MouseDown += radioButton_16_MouseDown;
		radioButton_15.MouseMove += radioButton_16_MouseMove;
		radioButton_16.AllowDrop = true;
		radioButton_16.Appearance = Appearance.Button;
		radioButton_16.AutoCheck = false;
		radioButton_16.ContextMenuStrip = contextMenuStrip_1;
		radioButton_16.Dock = DockStyle.Fill;
		radioButton_16.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		radioButton_16.Image = Resources.optCat1;
		radioButton_16.Location = new Point(131, 3);
		radioButton_16.Name = Class16.smethod_0(1649062911);
		radioButton_16.Size = new Size(122, 29);
		radioButton_16.TabIndex = 76;
		radioButton_16.TabStop = true;
		radioButton_16.TextAlign = ContentAlignment.MiddleRight;
		radioButton_16.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(radioButton_16, Class16.smethod_0(1649063263));
		radioButton_16.UseVisualStyleBackColor = true;
		radioButton_16.Click += radioButton_16_Click;
		radioButton_16.DragDrop += radioButton_16_DragDrop;
		radioButton_16.DragEnter += radioButton_16_DragEnter;
		radioButton_16.MouseDown += radioButton_16_MouseDown;
		radioButton_16.MouseMove += radioButton_16_MouseMove;
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		groupBox_0.BackColor = Color.FromArgb(239, 244, 250);
		groupBox_0.Controls.Add(tabControl_0);
		groupBox_0.Controls.Add(groupBox_1);
		groupBox_0.Controls.Add(textBox_3);
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(pictureBox_1);
		groupBox_0.Controls.Add(textBox_1);
		groupBox_0.Controls.Add(checkBox_0);
		groupBox_0.Location = new Point(513, 60);
		groupBox_0.Name = Class16.smethod_0(1648929344);
		groupBox_0.Size = new Size(653, 688);
		groupBox_0.TabIndex = 73;
		groupBox_0.TabStop = false;
		tabControl_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tabControl_0.Controls.Add(tabPage_0);
		tabControl_0.Controls.Add(tabPage_1);
		tabControl_0.Location = new Point(0, 174);
		tabControl_0.Name = Class16.smethod_0(1648910731);
		tabControl_0.SelectedIndex = 0;
		tabControl_0.Size = new Size(651, 490);
		tabControl_0.TabIndex = 113;
		tabPage_0.BackColor = Color.FromArgb(239, 244, 250);
		tabPage_0.Controls.Add(groupBox_3);
		tabPage_0.Controls.Add(groupBox_5);
		tabPage_0.Controls.Add(groupBox_2);
		tabPage_0.Controls.Add(groupBox_6);
		tabPage_0.Controls.Add(groupBox_7);
		tabPage_0.Location = new Point(4, 22);
		tabPage_0.Name = Class16.smethod_0(1648910757);
		tabPage_0.Padding = new Padding(3);
		tabPage_0.Size = new Size(643, 464);
		tabPage_0.TabIndex = 0;
		tabPage_0.Text = Class16.smethod_0(1649061901);
		groupBox_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_3.Controls.Add(textBox_10);
		groupBox_3.Controls.Add(label_22);
		groupBox_3.Controls.Add(numericUpDownEx_17);
		groupBox_3.Controls.Add(textBox_9);
		groupBox_3.Controls.Add(comboBox_1);
		groupBox_3.Controls.Add(numericUpDownEx_14);
		groupBox_3.Controls.Add(label_18);
		groupBox_3.Controls.Add(numericUpDownEx_13);
		groupBox_3.Controls.Add(numericUpDownEx_8);
		groupBox_3.Controls.Add(numericUpDownEx_9);
		groupBox_3.Controls.Add(label_13);
		groupBox_3.Controls.Add(comboBox_0);
		groupBox_3.Controls.Add(label_11);
		groupBox_3.Controls.Add(label_5);
		groupBox_3.Controls.Add(dateTimePicker_0);
		groupBox_3.Controls.Add(dateTimePicker_1);
		groupBox_3.Controls.Add(label_6);
		groupBox_3.Controls.Add(label_12);
		groupBox_3.Controls.Add(label_17);
		groupBox_3.Location = new Point(2, 270);
		groupBox_3.Name = Class16.smethod_0(1649073432);
		groupBox_3.Size = new Size(640, 129);
		groupBox_3.TabIndex = 118;
		groupBox_3.TabStop = false;
		groupBox_3.Text = Class16.smethod_0(1649061905);
		textBox_10.BackColor = Color.FromArgb(192, 255, 192);
		textBox_10.Cursor = Cursors.Arrow;
		textBox_10.Location = new Point(167, 101);
		textBox_10.Name = Class16.smethod_0(1649061920);
		textBox_10.ReadOnly = true;
		textBox_10.Size = new Size(142, 22);
		textBox_10.TabIndex = 162;
		textBox_10.TextAlign = HorizontalAlignment.Center;
		textBox_10.DoubleClick += textBox_10_DoubleClick;
		label_22.Location = new Point(2, 103);
		label_22.Name = Class16.smethod_0(1649061944);
		label_22.Size = new Size(165, 16);
		label_22.TabIndex = 157;
		label_22.Text = Class16.smethod_0(1649061972);
		label_22.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_17.BackColor = Color.FromArgb(192, 255, 192);
		numericUpDownEx_17.Enabled = false;
		numericUpDownEx_17.ForeColor = Color.Black;
		numericUpDownEx_17.Location = new Point(315, 102);
		numericUpDownEx_17.Maximum = new decimal(new int[4] { 20, 0, 0, 0 });
		numericUpDownEx_17.Minimum = new decimal(new int[4] { 1, 0, 0, -2147483648 });
		numericUpDownEx_17.Name = Class16.smethod_0(1649061993);
		numericUpDownEx_17.Size = new Size(38, 22);
		numericUpDownEx_17.TabIndex = 156;
		numericUpDownEx_17.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_17.ThousandsSeparator = true;
		numericUpDownEx_17.Value = new decimal(new int[4] { 10, 0, 0, 0 });
		numericUpDownEx_17.ValueChanged += numericUpDownEx_17_ValueChanged;
		numericUpDownEx_17.DoubleClick += numericUpDownEx_17_DoubleClick;
		textBox_9.Enabled = false;
		textBox_9.Location = new Point(359, 73);
		textBox_9.Name = Class16.smethod_0(1649062010);
		textBox_9.Size = new Size(276, 22);
		textBox_9.TabIndex = 155;
		textBox_9.TextAlign = HorizontalAlignment.Center;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Items.AddRange(new object[5]
		{
			Class16.smethod_0(1648924120),
			Class16.smethod_0(1649062025),
			Class16.smethod_0(1649062047),
			Class16.smethod_0(1649062062),
			Class16.smethod_0(1649062078)
		});
		comboBox_1.Location = new Point(252, 74);
		comboBox_1.Name = Class16.smethod_0(1649062093);
		comboBox_1.Size = new Size(101, 21);
		comboBox_1.TabIndex = 154;
		comboBox_1.SelectedIndexChanged += comboBox_1_SelectedIndexChanged;
		numericUpDownEx_14.BackColor = SystemColors.Window;
		numericUpDownEx_14.Enabled = false;
		numericUpDownEx_14.ForeColor = Color.Black;
		numericUpDownEx_14.Location = new Point(167, 73);
		numericUpDownEx_14.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_14.Name = Class16.smethod_0(1649062117);
		numericUpDownEx_14.Size = new Size(79, 22);
		numericUpDownEx_14.TabIndex = 151;
		numericUpDownEx_14.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_14.ThousandsSeparator = true;
		numericUpDownEx_14.ValueChanged += numericUpDownEx_14_ValueChanged;
		label_18.Enabled = false;
		label_18.Location = new Point(2, 75);
		label_18.Name = Class16.smethod_0(1649062129);
		label_18.Size = new Size(165, 16);
		label_18.TabIndex = 150;
		label_18.Text = Class16.smethod_0(1649062152);
		label_18.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_13.BackColor = SystemColors.Window;
		numericUpDownEx_13.Enabled = false;
		numericUpDownEx_13.ForeColor = Color.Black;
		numericUpDownEx_13.Location = new Point(448, 48);
		numericUpDownEx_13.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_13.Name = Class16.smethod_0(1649062196);
		numericUpDownEx_13.Size = new Size(94, 22);
		numericUpDownEx_13.TabIndex = 149;
		numericUpDownEx_13.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_13.ThousandsSeparator = true;
		numericUpDownEx_13.ValueChanged += numericUpDownEx_13_ValueChanged;
		numericUpDownEx_8.BackColor = SystemColors.Window;
		numericUpDownEx_8.ForeColor = Color.Black;
		numericUpDownEx_8.Location = new Point(590, 18);
		numericUpDownEx_8.Maximum = new decimal(new int[4] { 10000000, 0, 0, 0 });
		numericUpDownEx_8.Name = Class16.smethod_0(1649002474);
		numericUpDownEx_8.Size = new Size(45, 22);
		numericUpDownEx_8.TabIndex = 147;
		numericUpDownEx_8.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_8.ThousandsSeparator = true;
		numericUpDownEx_8.ValueChanged += numericUpDownEx_8_ValueChanged;
		numericUpDownEx_9.BackColor = SystemColors.Window;
		numericUpDownEx_9.ForeColor = Color.Black;
		numericUpDownEx_9.Location = new Point(590, 46);
		numericUpDownEx_9.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_9.Name = Class16.smethod_0(1648941238);
		numericUpDownEx_9.Size = new Size(45, 22);
		numericUpDownEx_9.TabIndex = 145;
		numericUpDownEx_9.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_9.ThousandsSeparator = true;
		numericUpDownEx_9.ValueChanged += numericUpDownEx_9_ValueChanged;
		label_13.Location = new Point(544, 48);
		label_13.Name = Class16.smethod_0(1648912262);
		label_13.Size = new Size(45, 16);
		label_13.TabIndex = 144;
		label_13.Text = Class16.smethod_0(1649016188);
		label_13.TextAlign = ContentAlignment.MiddleRight;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649062214),
			Class16.smethod_0(1649062219)
		});
		comboBox_0.Location = new Point(448, 18);
		comboBox_0.Name = Class16.smethod_0(1649062232);
		comboBox_0.Size = new Size(94, 21);
		comboBox_0.TabIndex = 143;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		label_11.Location = new Point(379, 21);
		label_11.Name = Class16.smethod_0(1648912145);
		label_11.Size = new Size(68, 16);
		label_11.TabIndex = 142;
		label_11.Text = Class16.smethod_0(1649062250);
		label_11.TextAlign = ContentAlignment.MiddleRight;
		label_5.Location = new Point(6, 48);
		label_5.Name = Class16.smethod_0(1649072853);
		label_5.Size = new Size(112, 16);
		label_5.TabIndex = 140;
		label_5.Text = Class16.smethod_0(1649062265);
		label_5.TextAlign = ContentAlignment.MiddleRight;
		dateTimePicker_0.Location = new Point(124, 46);
		dateTimePicker_0.MaxDate = new DateTime(2110, 12, 31, 0, 0, 0, 0);
		dateTimePicker_0.MinDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		dateTimePicker_0.Name = Class16.smethod_0(1649072208);
		dateTimePicker_0.Size = new Size(229, 22);
		dateTimePicker_0.TabIndex = 139;
		dateTimePicker_0.Value = new DateTime(2014, 2, 13, 14, 32, 21, 0);
		dateTimePicker_0.ValueChanged += dateTimePicker_0_ValueChanged;
		dateTimePicker_1.Location = new Point(124, 18);
		dateTimePicker_1.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
		dateTimePicker_1.MinDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		dateTimePicker_1.Name = Class16.smethod_0(1649062294);
		dateTimePicker_1.Size = new Size(229, 22);
		dateTimePicker_1.TabIndex = 138;
		dateTimePicker_1.Value = new DateTime(2014, 2, 13, 14, 32, 21, 0);
		dateTimePicker_1.ValueChanged += dateTimePicker_1_ValueChanged;
		label_6.Location = new Point(8, 20);
		label_6.Name = Class16.smethod_0(1649072908);
		label_6.Size = new Size(110, 16);
		label_6.TabIndex = 137;
		label_6.Text = Class16.smethod_0(1649062310);
		label_6.TextAlign = ContentAlignment.MiddleRight;
		label_12.Location = new Point(541, 20);
		label_12.Name = Class16.smethod_0(1648912200);
		label_12.Size = new Size(48, 16);
		label_12.TabIndex = 146;
		label_12.Text = Class16.smethod_0(1649062333);
		label_12.TextAlign = ContentAlignment.MiddleRight;
		label_17.Enabled = false;
		label_17.Location = new Point(350, 48);
		label_17.Name = Class16.smethod_0(1649062338);
		label_17.Size = new Size(96, 16);
		label_17.TabIndex = 148;
		label_17.Text = Class16.smethod_0(1649062367);
		label_17.TextAlign = ContentAlignment.MiddleRight;
		groupBox_5.Controls.Add(button_13);
		groupBox_5.Controls.Add(button_8);
		groupBox_5.Controls.Add(textBox_6);
		groupBox_5.Location = new Point(1, 3);
		groupBox_5.Name = Class16.smethod_0(1649062390);
		groupBox_5.Size = new Size(640, 51);
		groupBox_5.TabIndex = 120;
		groupBox_5.TabStop = false;
		groupBox_5.Text = Class16.smethod_0(1649062395);
		button_13.Image = Resources.cmdGoToItemCat;
		button_13.Location = new Point(432, 18);
		button_13.Name = Class16.smethod_0(1649065482);
		button_13.Size = new Size(24, 24);
		button_13.TabIndex = 144;
		button_13.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(button_13, Class16.smethod_0(1649063019));
		button_13.UseVisualStyleBackColor = true;
		button_13.Click += button_13_Click;
		button_8.Image = Resources.cmdChangeCat;
		button_8.Location = new Point(458, 18);
		button_8.Name = Class16.smethod_0(1649065511);
		button_8.Size = new Size(177, 24);
		button_8.TabIndex = 143;
		button_8.Text = Class16.smethod_0(1649063475);
		button_8.TextAlign = ContentAlignment.MiddleRight;
		button_8.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_8.UseVisualStyleBackColor = true;
		button_8.Click += button_8_Click;
		textBox_6.BackColor = Color.FromArgb(192, 255, 192);
		textBox_6.Cursor = Cursors.Arrow;
		textBox_6.Location = new Point(9, 19);
		textBox_6.Name = Class16.smethod_0(1649065522);
		textBox_6.ReadOnly = true;
		textBox_6.Size = new Size(421, 22);
		textBox_6.TabIndex = 0;
		textBox_6.TextAlign = HorizontalAlignment.Center;
		textBox_6.DoubleClick += textBox_6_DoubleClick;
		groupBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_2.Controls.Add(button_14);
		groupBox_2.Controls.Add(dataGridViewEx_1);
		groupBox_2.Controls.Add(button_3);
		groupBox_2.Controls.Add(textBox_2);
		groupBox_2.Location = new Point(1, 60);
		groupBox_2.Name = Class16.smethod_0(1649073088);
		groupBox_2.Size = new Size(430, 207);
		groupBox_2.TabIndex = 117;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1648997999);
		button_14.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		button_14.AutoSize = true;
		button_14.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_14.Image = Resources.GShopEditor_PW_cmdselectlast;
		button_14.Location = new Point(51, 45);
		button_14.Name = Class16.smethod_0(1648978676);
		button_14.Size = new Size(24, 24);
		button_14.TabIndex = 111;
		button_14.TabStop = false;
		button_14.TextAlign = ContentAlignment.BottomCenter;
		button_14.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_14.UseVisualStyleBackColor = true;
		button_14.Visible = false;
		dataGridViewEx_1.AllowDrop = true;
		dataGridViewEx_1.AllowUserToAddRows = false;
		dataGridViewEx_1.AllowUserToDeleteRows = false;
		dataGridViewEx_1.BackgroundColor = Color.FromArgb(64, 64, 64);
		dataGridViewEx_1.BorderStyle = BorderStyle.None;
		dataGridViewEx_1.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridViewEx_1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridViewEx_1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewEx_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewEx_1.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1, dataGridViewImageColumn_0, dataGridViewTextBoxColumn_2, dataGridViewTextBoxColumn_3, dataGridViewTextBoxColumn_4);
		dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle10.BackColor = Color.FromArgb(32, 32, 32);
		dataGridViewCellStyle10.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle10.ForeColor = Color.White;
		dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle10.SelectionForeColor = Color.White;
		dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
		dataGridViewEx_1.DefaultCellStyle = dataGridViewCellStyle10;
		dataGridViewEx_1.EditMode = DataGridViewEditMode.EditProgrammatically;
		dataGridViewEx_1.GridColor = Color.Silver;
		dataGridViewEx_1.Location = new Point(18, 47);
		dataGridViewEx_1.Margin = new Padding(3, 4, 3, 4);
		dataGridViewEx_1.Name = Class16.smethod_0(1649065543);
		dataGridViewEx_1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle11.BackColor = SystemColors.Control;
		dataGridViewCellStyle11.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
		dataGridViewEx_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
		dataGridViewEx_1.RowHeadersVisible = false;
		dataGridViewEx_1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle12.Font = new Font(Class16.smethod_0(1648929920), 9f);
		dataGridViewEx_1.RowsDefaultCellStyle = dataGridViewCellStyle12;
		dataGridViewEx_1.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewEx_1.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridViewEx_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridViewEx_1.ShowCellToolTips = false;
		dataGridViewEx_1.Size = new Size(24, 22);
		dataGridViewEx_1.TabIndex = 112;
		dataGridViewEx_1.Visible = false;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle13.ForeColor = Color.Silver;
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle13;
		dataGridViewTextBoxColumn_0.Frozen = true;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648929947);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648910847);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.Width = 40;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle14.ForeColor = Color.FromArgb(224, 224, 224);
		dataGridViewTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle14;
		dataGridViewTextBoxColumn_1.Frozen = true;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648914199);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.Width = 60;
		dataGridViewImageColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewImageColumn_0.Frozen = true;
		dataGridViewImageColumn_0.HeaderText = string.Empty;
		dataGridViewImageColumn_0.Name = Class16.smethod_0(1649065559);
		dataGridViewImageColumn_0.ReadOnly = true;
		dataGridViewImageColumn_0.Resizable = DataGridViewTriState.False;
		dataGridViewImageColumn_0.Width = 20;
		dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle15.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle15;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648913143);
		dataGridViewTextBoxColumn_2.ReadOnly = true;
		dataGridViewTextBoxColumn_2.Resizable = DataGridViewTriState.True;
		dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle16.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		dataGridViewCellStyle16.ForeColor = Color.Gold;
		dataGridViewTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle16;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648970377);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1649065590);
		dataGridViewTextBoxColumn_3.ReadOnly = true;
		dataGridViewTextBoxColumn_3.Width = 80;
		dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle17.Font = new Font(Class16.smethod_0(1648942905), 7.8f);
		dataGridViewTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle17;
		dataGridViewTextBoxColumn_4.HeaderText = Class16.smethod_0(1648958804);
		dataGridViewTextBoxColumn_4.Name = Class16.smethod_0(1649065623);
		dataGridViewTextBoxColumn_4.ReadOnly = true;
		dataGridViewTextBoxColumn_4.ToolTipText = Class16.smethod_0(1649065648);
		dataGridViewTextBoxColumn_4.Width = 45;
		button_3.Dock = DockStyle.Top;
		button_3.Image = Resources.GShopEditor_PW_cmdPasteColorTag;
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(3, 18);
		button_3.Name = Class16.smethod_0(1649073117);
		button_3.Size = new Size(424, 23);
		button_3.TabIndex = 108;
		button_3.Text = Class16.smethod_0(1649073140);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		textBox_2.AcceptsReturn = true;
		textBox_2.AcceptsTab = true;
		textBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		textBox_2.BackColor = SystemColors.Window;
		textBox_2.Location = new Point(6, 45);
		textBox_2.Multiline = true;
		textBox_2.Name = Class16.smethod_0(1649065707);
		textBox_2.ScrollBars = ScrollBars.Vertical;
		textBox_2.Size = new Size(421, 159);
		textBox_2.TabIndex = 106;
		textBox_2.TextChanged += textBox_2_TextChanged;
		textBox_2.KeyDown += textBox_2_KeyDown;
		textBox_2.MouseLeave += textBox_2_MouseLeave;
		textBox_2.MouseMove += textBox_2_MouseMove;
		groupBox_6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_6.Controls.Add(label_20);
		groupBox_6.Controls.Add(label_19);
		groupBox_6.Controls.Add(button_9);
		groupBox_6.Controls.Add(numericUpDownEx_10);
		groupBox_6.Controls.Add(label_14);
		groupBox_6.Controls.Add(numericUpDownEx_11);
		groupBox_6.Controls.Add(label_15);
		groupBox_6.Controls.Add(numericUpDownEx_12);
		groupBox_6.Controls.Add(label_16);
		groupBox_6.Location = new Point(1, 407);
		groupBox_6.Name = Class16.smethod_0(1649065734);
		groupBox_6.Size = new Size(641, 56);
		groupBox_6.TabIndex = 121;
		groupBox_6.TabStop = false;
		groupBox_6.Text = Class16.smethod_0(1649065752);
		label_20.Location = new Point(235, 11);
		label_20.Name = Class16.smethod_0(1649065790);
		label_20.Size = new Size(170, 16);
		label_20.TabIndex = 126;
		label_20.Text = Class16.smethod_0(1648924410);
		label_20.TextAlign = ContentAlignment.MiddleCenter;
		label_19.Location = new Point(425, 11);
		label_19.Name = Class16.smethod_0(1649065814);
		label_19.Size = new Size(165, 16);
		label_19.TabIndex = 125;
		label_19.Text = Class16.smethod_0(1648924410);
		label_19.TextAlign = ContentAlignment.MiddleCenter;
		button_9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_9.Image = Resources.cmdGoToItem;
		button_9.Location = new Point(591, 13);
		button_9.Name = Class16.smethod_0(1649065837);
		button_9.Size = new Size(43, 39);
		button_9.TabIndex = 109;
		button_9.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_1.SetToolTip(button_9, Class16.smethod_0(1649065855));
		button_9.UseVisualStyleBackColor = true;
		button_9.Click += button_9_Click;
		numericUpDownEx_10.BackColor = SystemColors.Window;
		numericUpDownEx_10.ForeColor = Color.Black;
		numericUpDownEx_10.Location = new Point(137, 24);
		numericUpDownEx_10.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDownEx_10.Name = Class16.smethod_0(1649065898);
		numericUpDownEx_10.Size = new Size(82, 22);
		numericUpDownEx_10.TabIndex = 124;
		numericUpDownEx_10.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_10.ThousandsSeparator = true;
		numericUpDownEx_10.ValueChanged += numericUpDownEx_10_ValueChanged;
		label_14.Location = new Point(3, 26);
		label_14.Name = Class16.smethod_0(1649065915);
		label_14.Size = new Size(135, 16);
		label_14.TabIndex = 123;
		label_14.Text = Class16.smethod_0(1649065943);
		label_14.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_11.BackColor = SystemColors.Window;
		numericUpDownEx_11.ForeColor = Color.Black;
		numericUpDownEx_11.Location = new Point(508, 29);
		numericUpDownEx_11.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDownEx_11.Name = Class16.smethod_0(1649065965);
		numericUpDownEx_11.Size = new Size(82, 22);
		numericUpDownEx_11.TabIndex = 122;
		numericUpDownEx_11.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_11.ThousandsSeparator = true;
		numericUpDownEx_11.ValueChanged += numericUpDownEx_11_ValueChanged;
		label_15.Location = new Point(408, 31);
		label_15.Name = Class16.smethod_0(1649065980);
		label_15.Size = new Size(99, 16);
		label_15.TabIndex = 121;
		label_15.Text = Class16.smethod_0(1649064974);
		label_15.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_12.BackColor = SystemColors.Window;
		numericUpDownEx_12.ForeColor = Color.Black;
		numericUpDownEx_12.Location = new Point(323, 30);
		numericUpDownEx_12.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_12.Name = Class16.smethod_0(1649064991);
		numericUpDownEx_12.Size = new Size(82, 22);
		numericUpDownEx_12.TabIndex = 120;
		numericUpDownEx_12.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_12.ThousandsSeparator = true;
		numericUpDownEx_12.ValueChanged += numericUpDownEx_12_ValueChanged;
		label_16.Location = new Point(224, 32);
		label_16.Name = Class16.smethod_0(1649065007);
		label_16.Size = new Size(97, 16);
		label_16.TabIndex = 119;
		label_16.Text = Class16.smethod_0(1649065018);
		label_16.TextAlign = ContentAlignment.MiddleRight;
		groupBox_7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_7.Controls.Add(dataGridViewEx_2);
		groupBox_7.Location = new Point(437, 60);
		groupBox_7.Name = Class16.smethod_0(1649065044);
		groupBox_7.Size = new Size(205, 207);
		groupBox_7.TabIndex = 123;
		groupBox_7.TabStop = false;
		groupBox_7.Text = Class16.smethod_0(1649065063);
		dataGridViewEx_2.AllowDrop = true;
		dataGridViewEx_2.AllowUserToAddRows = false;
		dataGridViewEx_2.AllowUserToDeleteRows = false;
		dataGridViewEx_2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dataGridViewEx_2.BackgroundColor = Color.FromArgb(32, 32, 32);
		dataGridViewEx_2.BorderStyle = BorderStyle.None;
		dataGridViewEx_2.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridViewEx_2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridViewEx_2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewEx_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewEx_2.ColumnHeadersVisible = false;
		dataGridViewEx_2.Columns.AddRange(dataGridViewTextBoxColumn_5, dataGridViewTextBoxColumn_6);
		dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle18.BackColor = Color.FromArgb(32, 32, 32);
		dataGridViewCellStyle18.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle18.ForeColor = Color.White;
		dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle18.SelectionForeColor = Color.White;
		dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
		dataGridViewEx_2.DefaultCellStyle = dataGridViewCellStyle18;
		dataGridViewEx_2.GridColor = Color.Silver;
		dataGridViewEx_2.Location = new Point(3, 18);
		dataGridViewEx_2.Margin = new Padding(3, 4, 3, 4);
		dataGridViewEx_2.MultiSelect = false;
		dataGridViewEx_2.Name = Class16.smethod_0(1649065085);
		dataGridViewEx_2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle19.BackColor = SystemColors.Control;
		dataGridViewCellStyle19.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle19.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle19.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle19.WrapMode = DataGridViewTriState.False;
		dataGridViewEx_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
		dataGridViewEx_2.RowHeadersVisible = false;
		dataGridViewEx_2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle20.Font = new Font(Class16.smethod_0(1648929920), 9f);
		dataGridViewEx_2.RowsDefaultCellStyle = dataGridViewCellStyle20;
		dataGridViewEx_2.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 7.25f);
		dataGridViewEx_2.RowTemplate.Height = 20;
		dataGridViewEx_2.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridViewEx_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridViewEx_2.ShowCellToolTips = false;
		dataGridViewEx_2.Size = new Size(199, 186);
		dataGridViewEx_2.TabIndex = 1;
		toolTip_1.SetToolTip(dataGridViewEx_2, Class16.smethod_0(1649065096));
		dataGridViewEx_2.CellDoubleClick += dataGridViewEx_2_CellDoubleClick;
		dataGridViewEx_2.CellValueChanged += dataGridViewEx_2_CellValueChanged;
		dataGridViewEx_2.KeyPress += dataGridViewEx_2_KeyPress;
		dataGridViewEx_2.KeyUp += dataGridViewEx_2_KeyUp;
		dataGridViewTextBoxColumn_5.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle21.ForeColor = Color.FromArgb(224, 224, 224);
		dataGridViewTextBoxColumn_5.DefaultCellStyle = dataGridViewCellStyle21;
		dataGridViewTextBoxColumn_5.Frozen = true;
		dataGridViewTextBoxColumn_5.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_5.Name = Class16.smethod_0(1649065168);
		dataGridViewTextBoxColumn_5.Resizable = DataGridViewTriState.False;
		dataGridViewTextBoxColumn_5.Width = 50;
		dataGridViewTextBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle22.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewTextBoxColumn_6.DefaultCellStyle = dataGridViewCellStyle22;
		dataGridViewTextBoxColumn_6.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_6.Name = Class16.smethod_0(1649065191);
		dataGridViewTextBoxColumn_6.ReadOnly = true;
		dataGridViewTextBoxColumn_6.Resizable = DataGridViewTriState.False;
		tabPage_1.BackColor = Color.FromArgb(239, 244, 250);
		tabPage_1.Controls.Add(groupBox_10);
		tabPage_1.Controls.Add(groupBox_9);
		tabPage_1.Controls.Add(groupBox_4);
		tabPage_1.Controls.Add(groupBox_8);
		tabPage_1.Location = new Point(4, 22);
		tabPage_1.Name = Class16.smethod_0(1648910790);
		tabPage_1.Padding = new Padding(3);
		tabPage_1.Size = new Size(643, 464);
		tabPage_1.TabIndex = 1;
		tabPage_1.Text = Class16.smethod_0(1649065200);
		groupBox_10.Controls.Add(numericUpDownEx_22);
		groupBox_10.Controls.Add(label_28);
		groupBox_10.Controls.Add(numericUpDownEx_23);
		groupBox_10.Controls.Add(label_29);
		groupBox_10.Controls.Add(numericUpDownEx_24);
		groupBox_10.Controls.Add(label_30);
		groupBox_10.Controls.Add(numericUpDownEx_25);
		groupBox_10.Controls.Add(label_31);
		groupBox_10.Location = new Point(1, 148);
		groupBox_10.Name = Class16.smethod_0(1648928966);
		groupBox_10.Size = new Size(371, 82);
		groupBox_10.TabIndex = 154;
		groupBox_10.TabStop = false;
		groupBox_10.Text = Class16.smethod_0(1649065221);
		numericUpDownEx_22.BackColor = SystemColors.Window;
		numericUpDownEx_22.ForeColor = Color.Black;
		numericUpDownEx_22.Location = new Point(271, 42);
		numericUpDownEx_22.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_22.Name = Class16.smethod_0(1649065225);
		numericUpDownEx_22.Size = new Size(79, 22);
		numericUpDownEx_22.TabIndex = 153;
		numericUpDownEx_22.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_22.ThousandsSeparator = true;
		numericUpDownEx_22.ValueChanged += numericUpDownEx_22_ValueChanged;
		label_28.Location = new Point(274, 23);
		label_28.Name = Class16.smethod_0(1648925100);
		label_28.Size = new Size(67, 16);
		label_28.TabIndex = 152;
		label_28.Text = Class16.smethod_0(1649065241);
		label_28.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_23.BackColor = SystemColors.Window;
		numericUpDownEx_23.ForeColor = Color.Black;
		numericUpDownEx_23.Location = new Point(186, 42);
		numericUpDownEx_23.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_23.Name = Class16.smethod_0(1649065258);
		numericUpDownEx_23.Size = new Size(79, 22);
		numericUpDownEx_23.TabIndex = 151;
		numericUpDownEx_23.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_23.ThousandsSeparator = true;
		numericUpDownEx_23.ValueChanged += numericUpDownEx_23_ValueChanged;
		label_29.Location = new Point(177, 23);
		label_29.Name = Class16.smethod_0(1648925176);
		label_29.Size = new Size(95, 16);
		label_29.TabIndex = 150;
		label_29.Text = Class16.smethod_0(1649065287);
		label_29.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_24.BackColor = SystemColors.Window;
		numericUpDownEx_24.ForeColor = Color.Black;
		numericUpDownEx_24.Location = new Point(99, 42);
		numericUpDownEx_24.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_24.Name = Class16.smethod_0(1649065309);
		numericUpDownEx_24.Size = new Size(79, 22);
		numericUpDownEx_24.TabIndex = 149;
		numericUpDownEx_24.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_24.ThousandsSeparator = true;
		numericUpDownEx_24.ValueChanged += numericUpDownEx_24_ValueChanged;
		label_30.Location = new Point(102, 23);
		label_30.Name = Class16.smethod_0(1648920093);
		label_30.Size = new Size(67, 16);
		label_30.TabIndex = 148;
		label_30.Text = Class16.smethod_0(1649065325);
		label_30.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_25.BackColor = SystemColors.Window;
		numericUpDownEx_25.ForeColor = Color.Black;
		numericUpDownEx_25.Location = new Point(6, 42);
		numericUpDownEx_25.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_25.Name = Class16.smethod_0(1649065342);
		numericUpDownEx_25.Size = new Size(79, 22);
		numericUpDownEx_25.TabIndex = 147;
		numericUpDownEx_25.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_25.ThousandsSeparator = true;
		numericUpDownEx_25.ValueChanged += numericUpDownEx_25_ValueChanged;
		label_31.Location = new Point(2, 23);
		label_31.Name = Class16.smethod_0(1648914048);
		label_31.Size = new Size(87, 16);
		label_31.TabIndex = 146;
		label_31.Text = Class16.smethod_0(1649065362);
		label_31.TextAlign = ContentAlignment.MiddleRight;
		groupBox_9.Controls.Add(textBox_11);
		groupBox_9.Controls.Add(label_23);
		groupBox_9.Controls.Add(numericUpDownEx_15);
		groupBox_9.Controls.Add(numericUpDownEx_16);
		groupBox_9.Controls.Add(label_21);
		groupBox_9.Location = new Point(2, 3);
		groupBox_9.Name = Class16.smethod_0(1648929037);
		groupBox_9.Size = new Size(226, 78);
		groupBox_9.TabIndex = 162;
		groupBox_9.TabStop = false;
		groupBox_9.Text = Class16.smethod_0(1649065387);
		textBox_11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_11.BackColor = Color.FromArgb(32, 32, 32);
		textBox_11.BorderStyle = BorderStyle.FixedSingle;
		textBox_11.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_11.ForeColor = Color.White;
		textBox_11.Location = new Point(6, 43);
		textBox_11.MaxLength = 32;
		textBox_11.Name = Class16.smethod_0(1649065407);
		textBox_11.Size = new Size(213, 23);
		textBox_11.TabIndex = 146;
		textBox_11.TextAlign = HorizontalAlignment.Center;
		toolTip_1.SetToolTip(textBox_11, Class16.smethod_0(1649065422));
		label_23.Location = new Point(6, 16);
		label_23.Name = Class16.smethod_0(1648912083);
		label_23.Size = new Size(25, 22);
		label_23.TabIndex = 158;
		label_23.Text = Class16.smethod_0(1648930840);
		label_23.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_15.BackColor = SystemColors.Window;
		numericUpDownEx_15.Enabled = false;
		numericUpDownEx_15.ForeColor = Color.Black;
		numericUpDownEx_15.Location = new Point(160, 16);
		numericUpDownEx_15.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDownEx_15.Name = Class16.smethod_0(1649065455);
		numericUpDownEx_15.Size = new Size(50, 22);
		numericUpDownEx_15.TabIndex = 161;
		numericUpDownEx_15.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_15.ValueChanged += numericUpDownEx_15_ValueChanged;
		numericUpDownEx_16.BackColor = Color.FromArgb(255, 255, 128);
		numericUpDownEx_16.Enabled = false;
		numericUpDownEx_16.ForeColor = Color.Black;
		numericUpDownEx_16.Location = new Point(34, 16);
		numericUpDownEx_16.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_16.Name = Class16.smethod_0(1649065471);
		numericUpDownEx_16.Size = new Size(78, 22);
		numericUpDownEx_16.TabIndex = 159;
		numericUpDownEx_16.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_16.ValueChanged += numericUpDownEx_16_ValueChanged;
		numericUpDownEx_16.DoubleClick += numericUpDownEx_16_DoubleClick;
		label_21.Location = new Point(113, 15);
		label_21.Name = Class16.smethod_0(1648930240);
		label_21.Size = new Size(45, 22);
		label_21.TabIndex = 160;
		label_21.Text = Class16.smethod_0(1649064460);
		label_21.TextAlign = ContentAlignment.MiddleRight;
		groupBox_4.Controls.Add(textBox_7);
		groupBox_4.Controls.Add(numericUpDownEx_6);
		groupBox_4.Controls.Add(label_9);
		groupBox_4.Controls.Add(numericUpDownEx_7);
		groupBox_4.Controls.Add(label_10);
		groupBox_4.Controls.Add(pictureBox_2);
		groupBox_4.Controls.Add(numericUpDownEx_3);
		groupBox_4.Location = new Point(1, 86);
		groupBox_4.Name = Class16.smethod_0(1649072433);
		groupBox_4.Size = new Size(641, 56);
		groupBox_4.TabIndex = 116;
		groupBox_4.TabStop = false;
		groupBox_4.Text = Class16.smethod_0(1649072455);
		textBox_7.Location = new Point(423, 23);
		textBox_7.Name = Class16.smethod_0(1649064465);
		textBox_7.Size = new Size(211, 22);
		textBox_7.TabIndex = 124;
		textBox_7.Text = Class16.smethod_0(1649064492);
		textBox_7.TextAlign = HorizontalAlignment.Center;
		textBox_7.TextChanged += textBox_7_TextChanged;
		textBox_7.Leave += textBox_7_Leave;
		numericUpDownEx_6.BackColor = SystemColors.Window;
		numericUpDownEx_6.ForeColor = Color.Black;
		numericUpDownEx_6.Location = new Point(330, 23);
		numericUpDownEx_6.Maximum = new decimal(new int[4] { 10000000, 0, 0, 0 });
		numericUpDownEx_6.Name = Class16.smethod_0(1649064498);
		numericUpDownEx_6.Size = new Size(82, 22);
		numericUpDownEx_6.TabIndex = 122;
		numericUpDownEx_6.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_6.ThousandsSeparator = true;
		numericUpDownEx_6.ValueChanged += numericUpDownEx_6_ValueChanged;
		label_9.Location = new Point(302, 25);
		label_9.Name = Class16.smethod_0(1649064513);
		label_9.Size = new Size(41, 16);
		label_9.TabIndex = 121;
		label_9.Text = Class16.smethod_0(1649072274);
		label_9.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_7.BackColor = SystemColors.Window;
		numericUpDownEx_7.ForeColor = Color.Black;
		numericUpDownEx_7.Location = new Point(191, 23);
		numericUpDownEx_7.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_7.Name = Class16.smethod_0(1649064540);
		numericUpDownEx_7.Size = new Size(96, 22);
		numericUpDownEx_7.TabIndex = 120;
		numericUpDownEx_7.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_7.ThousandsSeparator = true;
		numericUpDownEx_7.ValueChanged += numericUpDownEx_7_ValueChanged;
		label_10.Location = new Point(134, 25);
		label_10.Name = Class16.smethod_0(1649064556);
		label_10.Size = new Size(56, 16);
		label_10.TabIndex = 119;
		label_10.Text = Class16.smethod_0(1649072367);
		label_10.TextAlign = ContentAlignment.MiddleRight;
		pictureBox_2.BackColor = Color.FromArgb(32, 32, 32);
		pictureBox_2.Cursor = Cursors.Hand;
		pictureBox_2.Image = Resources.GiftIcon;
		pictureBox_2.Location = new Point(11, 18);
		pictureBox_2.Name = Class16.smethod_0(1649072472);
		pictureBox_2.Size = new Size(32, 32);
		pictureBox_2.SizeMode = PictureBoxSizeMode.AutoSize;
		pictureBox_2.TabIndex = 100;
		pictureBox_2.TabStop = false;
		pictureBox_2.Click += pictureBox_2_Click;
		pictureBox_2.MouseLeave += pictureBox_2_MouseLeave;
		pictureBox_2.MouseMove += pictureBox_2_MouseMove;
		numericUpDownEx_3.BackColor = Color.FromArgb(255, 255, 128);
		numericUpDownEx_3.ForeColor = Color.Black;
		numericUpDownEx_3.Location = new Point(49, 23);
		numericUpDownEx_3.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_3.Name = Class16.smethod_0(1649072510);
		numericUpDownEx_3.Size = new Size(82, 22);
		numericUpDownEx_3.TabIndex = 96;
		numericUpDownEx_3.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_3.ValueChanged += numericUpDownEx_3_ValueChanged;
		numericUpDownEx_3.DoubleClick += numericUpDownEx_3_DoubleClick;
		groupBox_8.Controls.Add(numericUpDownEx_19);
		groupBox_8.Controls.Add(label_25);
		groupBox_8.Controls.Add(numericUpDownEx_20);
		groupBox_8.Controls.Add(label_26);
		groupBox_8.Controls.Add(numericUpDownEx_21);
		groupBox_8.Controls.Add(label_27);
		groupBox_8.Controls.Add(numericUpDownEx_18);
		groupBox_8.Controls.Add(label_24);
		groupBox_8.Location = new Point(236, 5);
		groupBox_8.Name = Class16.smethod_0(1648929126);
		groupBox_8.Size = new Size(403, 78);
		groupBox_8.TabIndex = 124;
		groupBox_8.TabStop = false;
		groupBox_8.Text = Class16.smethod_0(1649064575);
		numericUpDownEx_19.BackColor = SystemColors.Window;
		numericUpDownEx_19.ForeColor = Color.Black;
		numericUpDownEx_19.Location = new Point(271, 42);
		numericUpDownEx_19.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_19.Name = Class16.smethod_0(1649064588);
		numericUpDownEx_19.Size = new Size(79, 22);
		numericUpDownEx_19.TabIndex = 153;
		numericUpDownEx_19.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_19.ThousandsSeparator = true;
		numericUpDownEx_19.ValueChanged += numericUpDownEx_19_ValueChanged;
		label_25.Location = new Point(274, 23);
		label_25.Name = Class16.smethod_0(1648925008);
		label_25.Size = new Size(67, 16);
		label_25.TabIndex = 152;
		label_25.Text = Class16.smethod_0(1649064604);
		label_25.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_20.BackColor = SystemColors.Window;
		numericUpDownEx_20.ForeColor = Color.Black;
		numericUpDownEx_20.Location = new Point(186, 42);
		numericUpDownEx_20.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_20.Name = Class16.smethod_0(1649064621);
		numericUpDownEx_20.Size = new Size(79, 22);
		numericUpDownEx_20.TabIndex = 151;
		numericUpDownEx_20.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_20.ThousandsSeparator = true;
		numericUpDownEx_20.ValueChanged += numericUpDownEx_20_ValueChanged;
		label_26.Location = new Point(189, 23);
		label_26.Name = Class16.smethod_0(1648930206);
		label_26.Size = new Size(67, 16);
		label_26.TabIndex = 150;
		label_26.Text = Class16.smethod_0(1649064637);
		label_26.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_21.BackColor = SystemColors.Window;
		numericUpDownEx_21.ForeColor = Color.Black;
		numericUpDownEx_21.Location = new Point(99, 42);
		numericUpDownEx_21.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_21.Name = Class16.smethod_0(1649064654);
		numericUpDownEx_21.Size = new Size(79, 22);
		numericUpDownEx_21.TabIndex = 149;
		numericUpDownEx_21.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_21.ThousandsSeparator = true;
		numericUpDownEx_21.ValueChanged += numericUpDownEx_21_ValueChanged;
		label_27.Location = new Point(102, 23);
		label_27.Name = Class16.smethod_0(1648919238);
		label_27.Size = new Size(67, 16);
		label_27.TabIndex = 148;
		label_27.Text = Class16.smethod_0(1649064670);
		label_27.TextAlign = ContentAlignment.MiddleRight;
		numericUpDownEx_18.BackColor = SystemColors.Window;
		numericUpDownEx_18.ForeColor = Color.Black;
		numericUpDownEx_18.Location = new Point(6, 42);
		numericUpDownEx_18.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_18.Name = Class16.smethod_0(1649064687);
		numericUpDownEx_18.Size = new Size(79, 22);
		numericUpDownEx_18.TabIndex = 147;
		numericUpDownEx_18.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_18.ThousandsSeparator = true;
		numericUpDownEx_18.ValueChanged += numericUpDownEx_18_ValueChanged;
		label_24.Location = new Point(9, 23);
		label_24.Name = Class16.smethod_0(1649064703);
		label_24.Size = new Size(67, 16);
		label_24.TabIndex = 146;
		label_24.Text = Class16.smethod_0(1649064714);
		label_24.TextAlign = ContentAlignment.MiddleRight;
		groupBox_1.Controls.Add(numericUpDownEx_5);
		groupBox_1.Controls.Add(label_7);
		groupBox_1.Controls.Add(button_4);
		groupBox_1.Controls.Add(button_5);
		groupBox_1.Controls.Add(button_6);
		groupBox_1.Controls.Add(button_7);
		groupBox_1.Controls.Add(label_8);
		groupBox_1.Controls.Add(textBox_5);
		groupBox_1.Controls.Add(numericUpDownEx_4);
		groupBox_1.Controls.Add(label_4);
		groupBox_1.Controls.Add(numericUpDownEx_1);
		groupBox_1.Controls.Add(label_1);
		groupBox_1.Controls.Add(label_2);
		groupBox_1.Controls.Add(textBox_4);
		groupBox_1.Controls.Add(pictureBox_0);
		groupBox_1.Controls.Add(numericUpDownEx_2);
		groupBox_1.Controls.Add(numericUpDownEx_0);
		groupBox_1.Controls.Add(label_3);
		groupBox_1.Location = new Point(6, 67);
		groupBox_1.Name = Class16.smethod_0(1649072189);
		groupBox_1.Size = new Size(502, 101);
		groupBox_1.TabIndex = 115;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1648969762);
		numericUpDownEx_5.BackColor = SystemColors.Window;
		numericUpDownEx_5.ForeColor = Color.Black;
		numericUpDownEx_5.Location = new Point(59, 73);
		numericUpDownEx_5.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_5.Name = Class16.smethod_0(1649064731);
		numericUpDownEx_5.Size = new Size(70, 22);
		numericUpDownEx_5.TabIndex = 146;
		numericUpDownEx_5.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_5.ThousandsSeparator = true;
		numericUpDownEx_5.ValueChanged += numericUpDownEx_5_ValueChanged;
		numericUpDownEx_5.DoubleClick += label_7_DoubleClick;
		label_7.BackColor = Color.FromArgb(32, 32, 32);
		label_7.BorderStyle = BorderStyle.FixedSingle;
		label_7.ForeColor = Color.White;
		label_7.Location = new Point(135, 73);
		label_7.Name = Class16.smethod_0(1649064766);
		label_7.Size = new Size(180, 22);
		label_7.TabIndex = 147;
		label_7.TextAlign = ContentAlignment.MiddleCenter;
		label_7.DoubleClick += label_7_DoubleClick;
		button_4.Location = new Point(469, 73);
		button_4.Name = Class16.smethod_0(1649064778);
		button_4.Size = new Size(27, 23);
		button_4.TabIndex = 145;
		button_4.Text = Class16.smethod_0(1649064795);
		toolTip_1.SetToolTip(button_4, Class16.smethod_0(1649064492));
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		button_5.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_5.Location = new Point(419, 73);
		button_5.Name = Class16.smethod_0(1649064812);
		button_5.Size = new Size(50, 23);
		button_5.TabIndex = 144;
		button_5.Text = Class16.smethod_0(1648941218);
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		button_6.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_6.Location = new Point(369, 73);
		button_6.Name = Class16.smethod_0(1649064819);
		button_6.Size = new Size(50, 23);
		button_6.TabIndex = 143;
		button_6.Text = Class16.smethod_0(1648941238);
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		button_7.Location = new Point(319, 73);
		button_7.Name = Class16.smethod_0(1649064832);
		button_7.Size = new Size(50, 23);
		button_7.TabIndex = 142;
		button_7.Text = Class16.smethod_0(1648941240);
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		label_8.Location = new Point(5, 76);
		label_8.Name = Class16.smethod_0(1648916149);
		label_8.Size = new Size(50, 16);
		label_8.TabIndex = 122;
		label_8.Text = Class16.smethod_0(1649064854);
		label_8.TextAlign = ContentAlignment.MiddleRight;
		textBox_5.Location = new Point(352, 45);
		textBox_5.Name = Class16.smethod_0(1649064868);
		textBox_5.Size = new Size(89, 22);
		textBox_5.TabIndex = 121;
		textBox_5.Text = Class16.smethod_0(1649064492);
		textBox_5.TextAlign = HorizontalAlignment.Center;
		textBox_5.TextChanged += textBox_5_TextChanged;
		textBox_5.Leave += textBox_5_Leave;
		numericUpDownEx_4.BackColor = SystemColors.Window;
		numericUpDownEx_4.ForeColor = Color.Black;
		numericUpDownEx_4.Location = new Point(443, 45);
		numericUpDownEx_4.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_4.Name = Class16.smethod_0(1649064875);
		numericUpDownEx_4.Size = new Size(52, 22);
		numericUpDownEx_4.TabIndex = 148;
		numericUpDownEx_4.TextAlign = HorizontalAlignment.Center;
		toolTip_1.SetToolTip(numericUpDownEx_4, Class16.smethod_0(1649064897));
		numericUpDownEx_4.ValueChanged += numericUpDownEx_4_ValueChanged;
		label_4.Font = new Font(Class16.smethod_0(1648942905), 7f);
		label_4.Location = new Point(311, 45);
		label_4.Name = Class16.smethod_0(1649072225);
		label_4.Size = new Size(48, 22);
		label_4.TabIndex = 119;
		label_4.Text = Class16.smethod_0(1649072243);
		label_4.TextAlign = ContentAlignment.MiddleLeft;
		numericUpDownEx_1.BackColor = SystemColors.Window;
		numericUpDownEx_1.DecimalPlaces = 2;
		numericUpDownEx_1.ForeColor = Color.Black;
		numericUpDownEx_1.Location = new Point(230, 45);
		numericUpDownEx_1.Maximum = new decimal(new int[4] { 42949672, 0, 0, 0 });
		numericUpDownEx_1.Name = Class16.smethod_0(1648970377);
		numericUpDownEx_1.Size = new Size(79, 22);
		numericUpDownEx_1.TabIndex = 118;
		numericUpDownEx_1.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_1.ThousandsSeparator = true;
		numericUpDownEx_1.ValueChanged += numericUpDownEx_1_ValueChanged;
		label_1.Location = new Point(194, 47);
		label_1.Name = Class16.smethod_0(1649072259);
		label_1.Size = new Size(38, 16);
		label_1.TabIndex = 117;
		label_1.Text = Class16.smethod_0(1649072274);
		label_1.TextAlign = ContentAlignment.MiddleRight;
		label_2.Location = new Point(45, 19);
		label_2.Name = Class16.smethod_0(1649072295);
		label_2.Size = new Size(61, 16);
		label_2.TabIndex = 116;
		label_2.Text = Class16.smethod_0(1649072309);
		label_2.TextAlign = ContentAlignment.MiddleRight;
		textBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_4.BackColor = Color.FromArgb(32, 32, 32);
		textBox_4.BorderStyle = BorderStyle.FixedSingle;
		textBox_4.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_4.ForeColor = Color.White;
		textBox_4.Location = new Point(194, 17);
		textBox_4.MaxLength = 32;
		textBox_4.Name = Class16.smethod_0(1649072313);
		textBox_4.Size = new Size(302, 23);
		textBox_4.TabIndex = 115;
		textBox_4.TextAlign = HorizontalAlignment.Center;
		toolTip_1.SetToolTip(textBox_4, Class16.smethod_0(1649065422));
		textBox_4.KeyPress += textBox_4_KeyPress;
		textBox_4.Leave += textBox_4_Leave;
		pictureBox_0.BackColor = Color.Transparent;
		pictureBox_0.Cursor = Cursors.Hand;
		pictureBox_0.Image = Resources.GShopEditor_PW_ItemIcon;
		pictureBox_0.Location = new Point(11, 27);
		pictureBox_0.Name = Class16.smethod_0(1649072328);
		pictureBox_0.Size = new Size(32, 32);
		pictureBox_0.SizeMode = PictureBoxSizeMode.AutoSize;
		pictureBox_0.TabIndex = 100;
		pictureBox_0.TabStop = false;
		pictureBox_0.Click += pictureBox_0_Click;
		pictureBox_0.MouseLeave += pictureBox_0_MouseLeave;
		pictureBox_0.MouseMove += pictureBox_0_MouseMove;
		numericUpDownEx_2.BackColor = SystemColors.Window;
		numericUpDownEx_2.ForeColor = Color.Black;
		numericUpDownEx_2.Location = new Point(106, 45);
		numericUpDownEx_2.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_2.Name = Class16.smethod_0(1648968311);
		numericUpDownEx_2.Size = new Size(88, 22);
		numericUpDownEx_2.TabIndex = 114;
		numericUpDownEx_2.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_2.ThousandsSeparator = true;
		numericUpDownEx_2.ValueChanged += numericUpDownEx_2_ValueChanged;
		numericUpDownEx_0.BackColor = Color.FromArgb(255, 255, 128);
		numericUpDownEx_0.ForeColor = Color.Black;
		numericUpDownEx_0.Location = new Point(106, 17);
		numericUpDownEx_0.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDownEx_0.Name = Class16.smethod_0(1649070408);
		numericUpDownEx_0.Size = new Size(82, 22);
		numericUpDownEx_0.TabIndex = 96;
		numericUpDownEx_0.TextAlign = HorizontalAlignment.Center;
		numericUpDownEx_0.ValueChanged += numericUpDownEx_0_ValueChanged;
		numericUpDownEx_0.DoubleClick += numericUpDownEx_0_DoubleClick;
		label_3.Location = new Point(48, 47);
		label_3.Name = Class16.smethod_0(1649072351);
		label_3.Size = new Size(56, 16);
		label_3.TabIndex = 113;
		label_3.Text = Class16.smethod_0(1649072367);
		label_3.TextAlign = ContentAlignment.MiddleRight;
		textBox_3.BackColor = Color.FromArgb(192, 255, 192);
		textBox_3.Cursor = Cursors.IBeam;
		textBox_3.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_3.Location = new Point(78, 41);
		textBox_3.Name = Class16.smethod_0(1649064922);
		textBox_3.Size = new Size(430, 20);
		textBox_3.TabIndex = 111;
		textBox_3.TextAlign = HorizontalAlignment.Center;
		textBox_3.TextChanged += textBox_3_TextChanged;
		textBox_3.DoubleClick += textBox_3_DoubleClick;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 10f);
		label_0.Location = new Point(8, 42);
		label_0.Name = Class16.smethod_0(1649072415);
		label_0.Size = new Size(64, 18);
		label_0.TabIndex = 110;
		label_0.Text = Class16.smethod_0(1649072429);
		label_0.TextAlign = ContentAlignment.MiddleRight;
		pictureBox_1.BackColor = Color.FromArgb(18, 26, 28);
		pictureBox_1.BorderStyle = BorderStyle.FixedSingle;
		pictureBox_1.Cursor = Cursors.Hand;
		pictureBox_1.Image = Resources.ShopItemIcon;
		pictureBox_1.Location = new Point(518, 40);
		pictureBox_1.Name = Class16.smethod_0(1648895083);
		pictureBox_1.Size = new Size(128, 128);
		pictureBox_1.TabIndex = 102;
		pictureBox_1.TabStop = false;
		pictureBox_1.Click += pictureBox_1_Click;
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.BackColor = Color.FromArgb(32, 32, 32);
		textBox_1.BorderStyle = BorderStyle.FixedSingle;
		textBox_1.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Bold);
		textBox_1.ForeColor = Color.FromArgb(255, 203, 74);
		textBox_1.Location = new Point(6, 10);
		textBox_1.MaxLength = 32;
		textBox_1.Name = Class16.smethod_0(1649072568);
		textBox_1.Size = new Size(640, 27);
		textBox_1.TabIndex = 99;
		textBox_1.TextAlign = HorizontalAlignment.Center;
		toolTip_1.SetToolTip(textBox_1, Class16.smethod_0(1648986709));
		textBox_1.TextChanged += textBox_1_TextChanged;
		checkBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold | FontStyle.Underline);
		checkBox_0.ForeColor = Color.Red;
		checkBox_0.Location = new Point(560, 13);
		checkBox_0.Name = Class16.smethod_0(1649072153);
		checkBox_0.Size = new Size(86, 20);
		checkBox_0.TabIndex = 116;
		checkBox_0.Text = Class16.smethod_0(1649072174);
		checkBox_0.TextAlign = ContentAlignment.MiddleCenter;
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.Visible = false;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		button_10.Location = new Point(231, 307);
		button_10.Name = Class16.smethod_0(1648929185);
		button_10.Size = new Size(75, 23);
		button_10.TabIndex = 83;
		button_10.Text = Class16.smethod_0(1648929202);
		button_10.UseVisualStyleBackColor = true;
		button_10.Click += button_10_Click;
		checkBox_1.Appearance = Appearance.Button;
		checkBox_1.AutoSize = true;
		checkBox_1.Image = Resources.chkEnabeOrder;
		checkBox_1.Location = new Point(31, 70);
		checkBox_1.Name = Class16.smethod_0(1649064938);
		checkBox_1.Size = new Size(22, 22);
		checkBox_1.TabIndex = 77;
		toolTip_1.SetToolTip(checkBox_1, Class16.smethod_0(1649063942));
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.Visible = false;
		backgroundWorker_0.WorkerReportsProgress = true;
		backgroundWorker_0.WorkerSupportsCancellation = true;
		backgroundWorker_0.DoWork += backgroundWorker_0_DoWork;
		backgroundWorker_0.ProgressChanged += backgroundWorker_0_ProgressChanged;
		backgroundWorker_0.RunWorkerCompleted += backgroundWorker_0_RunWorkerCompleted;
		timer_0.Interval = 200;
		timer_0.Tick += timer_0_Tick;
		statusStrip_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		statusStrip_0.AutoSize = false;
		statusStrip_0.Dock = DockStyle.None;
		statusStrip_0.Items.AddRange(new ToolStripItem[2] { toolStripProgressBar_0, toolStripStatusLabel_0 });
		statusStrip_0.Location = new Point(3, 779);
		statusStrip_0.Name = Class16.smethod_0(1649003514);
		statusStrip_0.Size = new Size(1167, 22);
		statusStrip_0.TabIndex = 82;
		statusStrip_0.Text = Class16.smethod_0(1649003514);
		toolStripProgressBar_0.AutoSize = false;
		toolStripProgressBar_0.Name = Class16.smethod_0(1649072588);
		toolStripProgressBar_0.Size = new Size(1040, 16);
		toolStripStatusLabel_0.AutoSize = false;
		toolStripStatusLabel_0.Name = Class16.smethod_0(1649072595);
		toolStripStatusLabel_0.Size = new Size(110, 17);
		toolStripStatusLabel_0.Spring = true;
		toolStripStatusLabel_0.Text = Class16.smethod_0(1649072623);
		timer_1.Interval = 300;
		timer_1.Tick += timer_1_Tick;
		timer_2.Interval = 200;
		timer_2.Tick += timer_2_Tick;
		toolStrip_0.BackColor = Color.Transparent;
		toolStrip_0.Items.AddRange(new ToolStripItem[19]
		{
			toolStripButton_0, toolStripButton_1, toolStripSeparator_19, toolStripButton_2, toolStripButton_3, toolStripSeparator_20, toolStripButton_4, toolStripButton_6, toolStripSeparator_21, toolStripButton_9,
			toolStripSplitButton_0, toolStripSplitButton_1, toolStripSeparator_22, toolStripButton_8, toolStripSeparator_26, toolStripButton_5, toolStripButton_7, toolStripSeparator_25, toolStripButton_10
		});
		toolStrip_0.Location = new Point(0, 24);
		toolStrip_0.Name = Class16.smethod_0(1649063962);
		toolStrip_0.Size = new Size(1174, 25);
		toolStrip_0.TabIndex = 83;
		toolStrip_0.Text = Class16.smethod_0(1649063962);
		toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_0.Enabled = false;
		toolStripButton_0.Image = Resources.GShopEditor_PW_mbBack;
		toolStripButton_0.ImageTransparentColor = Color.Magenta;
		toolStripButton_0.Name = Class16.smethod_0(1649063976);
		toolStripButton_0.Size = new Size(23, 22);
		toolStripButton_0.Text = Class16.smethod_0(1649063997);
		toolStripButton_0.Visible = false;
		toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_1.Enabled = false;
		toolStripButton_1.Image = Resources.GShopEditor_PW_mbForward;
		toolStripButton_1.ImageTransparentColor = Color.Magenta;
		toolStripButton_1.Name = Class16.smethod_0(1649064017);
		toolStripButton_1.Size = new Size(23, 22);
		toolStripButton_1.Text = Class16.smethod_0(1649064033);
		toolStripButton_1.Visible = false;
		toolStripSeparator_19.Name = Class16.smethod_0(1649064055);
		toolStripSeparator_19.Size = new Size(6, 25);
		toolStripSeparator_19.Visible = false;
		toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_2.Image = Resources.GShopEditor_PW_mbOpen;
		toolStripButton_2.ImageTransparentColor = Color.Magenta;
		toolStripButton_2.Name = Class16.smethod_0(1649064073);
		toolStripButton_2.Size = new Size(23, 22);
		toolStripButton_2.Text = Class16.smethod_0(1649064094);
		toolStripButton_2.Click += toolStripButton_2_Click;
		toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_3.Enabled = false;
		toolStripButton_3.Image = Resources.GShopEditor_PW_mbSave;
		toolStripButton_3.ImageTransparentColor = Color.Magenta;
		toolStripButton_3.Name = Class16.smethod_0(1649064113);
		toolStripButton_3.Size = new Size(23, 22);
		toolStripButton_3.Text = Class16.smethod_0(1649073775);
		toolStripButton_3.Click += toolStripButton_3_Click;
		toolStripSeparator_20.Name = Class16.smethod_0(1649064134);
		toolStripSeparator_20.Size = new Size(6, 25);
		toolStripButton_4.Enabled = false;
		toolStripButton_4.Image = Resources.GShopEditor_PW_mbImport;
		toolStripButton_4.ImageTransparentColor = Color.Magenta;
		toolStripButton_4.Name = Class16.smethod_0(1649064153);
		toolStripButton_4.Size = new Size(63, 22);
		toolStripButton_4.Text = Class16.smethod_0(1648931405);
		toolStripButton_4.Click += toolStripButton_4_Click;
		toolStripButton_6.Enabled = false;
		toolStripButton_6.Image = Resources.GShopEditor_PW_mbExport;
		toolStripButton_6.ImageTransparentColor = Color.Magenta;
		toolStripButton_6.Name = Class16.smethod_0(1649064168);
		toolStripButton_6.Size = new Size(60, 22);
		toolStripButton_6.Text = Class16.smethod_0(1648931384);
		toolStripButton_6.Click += toolStripButton_6_Click;
		toolStripSeparator_21.Name = Class16.smethod_0(1649064191);
		toolStripSeparator_21.Size = new Size(6, 25);
		toolStripButton_9.Enabled = false;
		toolStripButton_9.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold | FontStyle.Underline);
		toolStripButton_9.Image = Resources.mbApplyOrdering;
		toolStripButton_9.ImageTransparentColor = Color.Magenta;
		toolStripButton_9.Name = Class16.smethod_0(1649064210);
		toolStripButton_9.Size = new Size(100, 22);
		toolStripButton_9.Text = Class16.smethod_0(1649064232);
		toolStripButton_9.Click += toolStripButton_9_Click;
		toolStripSplitButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripSplitButton_0.Enabled = false;
		toolStripSplitButton_0.Image = Resources.GShopEditor_PW_mbUndo;
		toolStripSplitButton_0.ImageTransparentColor = Color.Magenta;
		toolStripSplitButton_0.Name = Class16.smethod_0(1649064260);
		toolStripSplitButton_0.Size = new Size(32, 22);
		toolStripSplitButton_0.Text = Class16.smethod_0(1648933841);
		toolStripSplitButton_0.Visible = false;
		toolStripSplitButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripSplitButton_1.Enabled = false;
		toolStripSplitButton_1.Image = Resources.GShopEditor_PW_mbRedo;
		toolStripSplitButton_1.ImageTransparentColor = Color.Magenta;
		toolStripSplitButton_1.Name = Class16.smethod_0(1649064265);
		toolStripSplitButton_1.Size = new Size(32, 22);
		toolStripSplitButton_1.Text = Class16.smethod_0(1648933869);
		toolStripSplitButton_1.Visible = false;
		toolStripSeparator_22.Name = Class16.smethod_0(1649064286);
		toolStripSeparator_22.Size = new Size(6, 25);
		toolStripButton_8.Enabled = false;
		toolStripButton_8.Image = Resources.mbTimestamp;
		toolStripButton_8.ImageTransparentColor = Color.Magenta;
		toolStripButton_8.Name = Class16.smethod_0(1648900888);
		toolStripButton_8.Size = new Size(87, 22);
		toolStripButton_8.Text = Class16.smethod_0(1649064305);
		toolStripButton_8.ToolTipText = Class16.smethod_0(1649064321);
		toolStripButton_8.Click += toolStripButton_8_Click;
		toolStripSeparator_26.Name = Class16.smethod_0(1648920981);
		toolStripSeparator_26.Size = new Size(6, 25);
		toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_5.Image = Resources.GShopEditor_PW_mbSettings;
		toolStripButton_5.ImageTransparentColor = Color.Magenta;
		toolStripButton_5.Name = Class16.smethod_0(1648900879);
		toolStripButton_5.Size = new Size(23, 22);
		toolStripButton_5.Text = Class16.smethod_0(1649068916);
		toolStripButton_5.Click += toolStripButton_5_Click;
		toolStripButton_7.Alignment = ToolStripItemAlignment.Right;
		toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_7.Enabled = false;
		toolStripButton_7.Image = Resources.GShopEditor_PW_mbReload;
		toolStripButton_7.ImageTransparentColor = Color.Magenta;
		toolStripButton_7.Name = Class16.smethod_0(1649064362);
		toolStripButton_7.Size = new Size(23, 22);
		toolStripButton_7.Text = Class16.smethod_0(1649064377);
		toolStripButton_7.Click += toolStripButton_7_Click;
		toolStripSeparator_25.Alignment = ToolStripItemAlignment.Right;
		toolStripSeparator_25.Name = Class16.smethod_0(1649064395);
		toolStripSeparator_25.Size = new Size(6, 25);
		toolStripSeparator_25.Visible = false;
		toolStripButton_10.Alignment = ToolStripItemAlignment.Right;
		toolStripButton_10.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		toolStripButton_10.Image = Resources.mbShowSubCat9;
		toolStripButton_10.ImageTransparentColor = Color.Magenta;
		toolStripButton_10.Name = Class16.smethod_0(1649064416);
		toolStripButton_10.Size = new Size(204, 22);
		toolStripButton_10.Text = Class16.smethod_0(1649064444);
		toolStripButton_10.Visible = false;
		toolStripButton_10.Click += toolStripButton_10_Click;
		base.AcceptButton = button_10;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(1174, 801);
		base.Controls.Add(statusStrip_0);
		base.Controls.Add(panel_0);
		base.Controls.Add(toolStrip_0);
		base.Controls.Add(menuStrip_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.Icon = Resources.GShopEditor_PW_Icon;
		base.KeyPreview = true;
		base.MainMenuStrip = menuStrip_0;
		base.Margin = new Padding(3, 4, 3, 4);
		MinimumSize = new Size(1100, 700);
		base.Name = Class16.smethod_0(1649059353);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649067720);
		base.Activated += GShopEditor_PW_Activated;
		base.FormClosing += GShopEditor_PW_FormClosing;
		base.Load += GShopEditor_PW_Load;
		base.Shown += GShopEditor_PW_Shown;
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		contextMenuStrip_0.ResumeLayout(performLayout: false);
		panel_0.ResumeLayout(performLayout: false);
		panel_0.PerformLayout();
		tableLayoutPanel_1.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridViewEx_0).EndInit();
		tableLayoutPanel_0.ResumeLayout(performLayout: false);
		tableLayoutPanel_0.PerformLayout();
		contextMenuStrip_1.ResumeLayout(performLayout: false);
		contextMenuStrip_2.ResumeLayout(performLayout: false);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		tabControl_0.ResumeLayout(performLayout: false);
		tabPage_0.ResumeLayout(performLayout: false);
		groupBox_3.ResumeLayout(performLayout: false);
		groupBox_3.PerformLayout();
		((ISupportInitialize)numericUpDownEx_17).EndInit();
		((ISupportInitialize)numericUpDownEx_14).EndInit();
		((ISupportInitialize)numericUpDownEx_13).EndInit();
		((ISupportInitialize)numericUpDownEx_8).EndInit();
		((ISupportInitialize)numericUpDownEx_9).EndInit();
		groupBox_5.ResumeLayout(performLayout: false);
		groupBox_5.PerformLayout();
		groupBox_2.ResumeLayout(performLayout: false);
		groupBox_2.PerformLayout();
		((ISupportInitialize)dataGridViewEx_1).EndInit();
		groupBox_6.ResumeLayout(performLayout: false);
		((ISupportInitialize)numericUpDownEx_10).EndInit();
		((ISupportInitialize)numericUpDownEx_11).EndInit();
		((ISupportInitialize)numericUpDownEx_12).EndInit();
		groupBox_7.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridViewEx_2).EndInit();
		tabPage_1.ResumeLayout(performLayout: false);
		groupBox_10.ResumeLayout(performLayout: false);
		((ISupportInitialize)numericUpDownEx_22).EndInit();
		((ISupportInitialize)numericUpDownEx_23).EndInit();
		((ISupportInitialize)numericUpDownEx_24).EndInit();
		((ISupportInitialize)numericUpDownEx_25).EndInit();
		groupBox_9.ResumeLayout(performLayout: false);
		groupBox_9.PerformLayout();
		((ISupportInitialize)numericUpDownEx_15).EndInit();
		((ISupportInitialize)numericUpDownEx_16).EndInit();
		groupBox_4.ResumeLayout(performLayout: false);
		groupBox_4.PerformLayout();
		((ISupportInitialize)numericUpDownEx_6).EndInit();
		((ISupportInitialize)numericUpDownEx_7).EndInit();
		((ISupportInitialize)pictureBox_2).EndInit();
		((ISupportInitialize)numericUpDownEx_3).EndInit();
		groupBox_8.ResumeLayout(performLayout: false);
		((ISupportInitialize)numericUpDownEx_19).EndInit();
		((ISupportInitialize)numericUpDownEx_20).EndInit();
		((ISupportInitialize)numericUpDownEx_21).EndInit();
		((ISupportInitialize)numericUpDownEx_18).EndInit();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		((ISupportInitialize)numericUpDownEx_5).EndInit();
		((ISupportInitialize)numericUpDownEx_1).EndInit();
		((ISupportInitialize)pictureBox_0).EndInit();
		((ISupportInitialize)numericUpDownEx_2).EndInit();
		((ISupportInitialize)numericUpDownEx_0).EndInit();
		((ISupportInitialize)pictureBox_1).EndInit();
		statusStrip_0.ResumeLayout(performLayout: false);
		statusStrip_0.PerformLayout();
		toolStrip_0.ResumeLayout(performLayout: false);
		toolStrip_0.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void method_7()
	{
		if (DataFiles.GShop == null || DataFiles.GShop.Categories == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649059382)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		FilterMode = FILTER_MODE.None;
		if (SelectedSubCatIndex > -1)
		{
			int selectedCatIndex = SelectedCatIndex;
			if (selectedCatIndex < 0 || selectedCatIndex >= DataFiles.GShop.Categories.Length)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649059405)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			Category[] categories = DataFiles.GShop.Categories;
			if ((uint)SelectedSubCatIndex >= categories[selectedCatIndex].SubCatsCount)
			{
				string subCatName = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071255));
				DataFiles.GShop.Categories[selectedCatIndex].AddSubCat(SelectedSubCatIndex, subCatName);
				method_40();
			}
		}
		else
		{
			int selectedCatIndex2 = SelectedCatIndex;
			if (selectedCatIndex2 > -1 && DataFiles.GShop.Categories[selectedCatIndex2].SubCatsCount == 0)
			{
				string subCatName2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071255));
				DataFiles.GShop.Categories[selectedCatIndex2].AddSubCat(0, subCatName2);
				method_40();
			}
		}
		int count = dataGridViewEx_0.SelectedRows.Count;
		if (count > 0)
		{
			int[] array = new int[count];
			int num = 0;
			if (0 < count)
			{
				do
				{
					int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
					array[num] = num2;
					num++;
				}
				while (num < count);
			}
			Array.Sort(array);
			int num3 = 0;
			if (0 < count)
			{
				do
				{
					int sourceIndex = array[num3];
					DataFiles.GShop.AddItem(sourceIndex);
					int int_ = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
					dataGridViewEx_0.Rows.Add(method_97(int_, bool_7: false));
					num3++;
				}
				while (num3 < count);
			}
			bool flag = !DontChange;
			DontChange = true;
			dataGridViewEx_0.ClearSelection();
			if (flag)
			{
				DontChange = false;
			}
			int rowIndex = dataGridViewEx_0.RowCount - 1;
			DataGridViewEx dataGridViewEx = dataGridViewEx_0;
			dataGridViewEx_0.CurrentCell = dataGridViewEx[Struct59.int_1, rowIndex];
			int num4 = dataGridViewEx_0.RowCount - count;
			if (num4 < dataGridViewEx_0.RowCount)
			{
				do
				{
					dataGridViewEx_0.Rows[num4].Selected = true;
					num4++;
				}
				while (num4 < dataGridViewEx_0.RowCount);
			}
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UPDATE_REFERENCES, (int)DataFiles.CurrentGShop, 0);
			byte b = ((dataGridViewEx_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			button_2.Enabled = b != 0;
			byte b2 = ((dataGridViewEx_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			contextMenuStrip_0.Enabled = b2 != 0;
			byte b3 = ((dataGridViewEx_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			groupBox_0.Enabled = b3 != 0;
			method_40();
			method_11();
		}
		else
		{
			method_56();
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_8();
	}

	private void method_8()
	{
		if (dataGridViewEx_0.SelectedRows.Count <= 0)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649059425));
		}
		int count = dataGridViewEx_0.SelectedRows.Count;
		if (count <= 0)
		{
			GC.KeepAlive(this);
			return;
		}
		int[] array = new int[count];
		int num = 0;
		if (0 < count)
		{
			do
			{
				array[num] = dataGridViewEx_0.SelectedRows[num].Index;
				num++;
			}
			while (num < count);
		}
		bool flag = !DontChange;
		DontChange = true;
		Array.Sort(array);
		int num2 = count - 1;
		if (num2 >= 0)
		{
			while ((nint)DataFiles.GShop.Items.LongLength != 1)
			{
				int index = array[num2];
				int num3 = (int)dataGridViewEx_0.Rows[index].Tag;
				int key = DataFiles.GShop.DeleteItem(num3);
				int index2 = array[num2];
				dataGridViewEx_0.Rows.RemoveAt(index2);
				dictionary_0.Remove(key);
				int num4 = 0;
				if (0 < dataGridViewEx_0.RowCount)
				{
					do
					{
						if ((int)dataGridViewEx_0.Rows[num4].Tag >= num3)
						{
							int num5 = (int)dataGridViewEx_0.Rows[num4].Tag;
							dataGridViewEx_0.Rows[num4].Tag = num5 - 1;
						}
						num4++;
					}
					while (num4 < dataGridViewEx_0.RowCount);
				}
				num2--;
				if (num2 < 0)
				{
					break;
				}
			}
		}
		if (flag)
		{
			DontChange = false;
		}
		dataGridViewEx_0_SelectionChanged(null, null);
		method_40();
		method_11();
		ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UPDATE_REFERENCES, (int)DataFiles.CurrentGShop, 0);
		GC.KeepAlive(this);
	}

	private void method_9()
	{
		DataFiles.GShop.Save();
		IsFileChanged = false;
		method_38();
		method_34();
		GC.KeepAlive(this);
	}

	private void method_10(object sender, EventArgs e)
	{
		method_9();
	}

	private void toolStripMenuItem_84_Click(object sender, EventArgs e)
	{
		method_9();
	}

	private void method_11()
	{
		method_91();
		IsFileChanged = true;
		method_38();
		method_34();
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		dataGridViewEx_0.Focus();
		GC.KeepAlive(this);
	}

	private void method_12(object sender, EventArgs e)
	{
		method_14();
	}

	private void method_13(PW_GSHOP_VERSION pw_GSHOP_VERSION_0)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649059466);
		openFileDialog.FileName = Class16.smethod_0(1648909700);
		if (openFileDialog.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			ReadGShop(openFileDialog.FileName, pw_GSHOP_VERSION_0, bReload: false);
		}
		GC.KeepAlive(this);
	}

	private void method_14()
	{
		method_13(PW_GSHOP_VERSION.AUTO);
	}

	private void textBox_0_Enter(object sender, EventArgs e)
	{
		base.AcceptButton = button_1;
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
		base.AcceptButton = button_10;
	}

	private void textBox_0_Click(object sender, EventArgs e)
	{
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071086));
		if (textBox_0.Text == text)
		{
			textBox_0.SelectAll();
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_DoubleClick(object sender, EventArgs e)
	{
		textBox_0.SelectAll();
		GC.KeepAlive(this);
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (LoadingComplete)
		{
			base.AcceptButton = button_1;
			string empty = string.Empty;
			if (textBox_0.Text == empty)
			{
				method_43(-1);
			}
			if (textBox_0.TextLength < 3)
			{
				Color searchIdleBack = TDark.SearchIdleBack;
				textBox_0.BackColor = searchIdleBack;
			}
			if (textBox_0.TextLength > 2 || ACE.RSGlobal.RSGlobal.IsUIntFast(textBox_0.Text))
			{
				method_15();
			}
		}
	}

	private void method_15()
	{
		if (ACE.RSGlobal.RSGlobal.antirecurse_FindItem_GShopEditor_PW)
		{
			return;
		}
		ACE.RSGlobal.RSGlobal.antirecurse_FindItem_GShopEditor_PW = true;
		try
		{
			if (textBox_0?.Text == null)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649059496)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			string empty = string.Empty;
			if (textBox_0.Text == empty)
			{
				try
				{
					method_43(-1);
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649059532));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649059554), Class16.smethod_0(1649059599)), ex.Message), Class16.smethod_0(1649059627), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				ACE.RSGlobal.RSGlobal.antirecurse_FindItem_GShopEditor_PW = false;
				return;
			}
			if (DataFiles.GShop?.Items == null)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649059658)), TextStorage.Msg(Class16.smethod_0(1649059688)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ACE.RSGlobal.RSGlobal.antirecurse_FindItem_GShopEditor_PW = false;
				return;
			}
			SearchResults = new List<int>();
			string text = textBox_0.Text.ToLowerInvariant();
			bool flag = false;
			int num = 0;
			try
			{
				if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
				{
					flag = true;
					num = Convert.ToInt32(text);
				}
			}
			catch (OverflowException ex2)
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649059712), Class16.smethod_0(1649059759)), ex2.Message), Class16.smethod_0(1649059797), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ACE.RSGlobal.RSGlobal.antirecurse_FindItem_GShopEditor_PW = false;
				return;
			}
			catch (FormatException ex3)
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649059823), Class16.smethod_0(1649058835)), ex3.Message), Class16.smethod_0(1649058886), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ACE.RSGlobal.RSGlobal.antirecurse_FindItem_GShopEditor_PW = false;
				return;
			}
			int num2 = 0;
			if (0 < (nint)DataFiles.GShop.Items.LongLength)
			{
				do
				{
					bool flag2 = false;
					GSHOP_ITEM_PW gSHOP_ITEM_PW = null;
					try
					{
						gSHOP_ITEM_PW = (GSHOP_ITEM_PW)DataFiles.GShop.Items[num2];
						if (gSHOP_ITEM_PW == null)
						{
							num2++;
							continue;
						}
					}
					catch (IndexOutOfRangeException ex4)
					{
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649058897), Class16.smethod_0(1649058930)), num2, ex4.Message), Class16.smethod_0(1649058980), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						break;
					}
					catch (InvalidCastException ex5)
					{
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649058998), Class16.smethod_0(1649059038)), num2, ex5.Message), Class16.smethod_0(1649059073), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						num2++;
						continue;
					}
					catch (Exception ex6)
					{
						SentryHelper.CaptureException(ex6, Class16.smethod_0(1649059532));
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649059090), Class16.smethod_0(1649059140)), num2, ex6.Message), Class16.smethod_0(1649059177), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						num2++;
						continue;
					}
					try
					{
						if (!flag)
						{
							if (!string.IsNullOrEmpty(gSHOP_ITEM_PW.sName))
							{
								flag2 = ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(gSHOP_ITEM_PW.sName, text) || flag2;
							}
							ITEMINFO itemInfo = gSHOP_ITEM_PW.ItemInfo;
							if (itemInfo != null && eLC != null && eLC.IsItemExist(itemInfo.pos) && !string.IsNullOrEmpty(gSHOP_ITEM_PW.ItemInfo.name) && ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(gSHOP_ITEM_PW.ItemInfo.name, text))
							{
								flag2 = true;
							}
							if (!flag2)
							{
								goto IL_045e;
							}
						}
						else if (num2 + 1 != num && gSHOP_ITEM_PW.ID != num && gSHOP_ITEM_PW.ItemID != num && gSHOP_ITEM_PW.GiftID != num)
						{
							goto IL_045e;
						}
					}
					catch (Exception ex7)
					{
						SentryHelper.CaptureException(ex7, Class16.smethod_0(1649059532));
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649059201), Class16.smethod_0(1649059248)), num2, ex7.Message), Class16.smethod_0(1649059311), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						num2++;
						continue;
					}
					try
					{
						SearchResults.Add(num2);
					}
					catch (Exception ex8)
					{
						SentryHelper.CaptureException(ex8, Class16.smethod_0(1649059532));
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649058317), Class16.smethod_0(1649058357)), num2, ex8.Message), Class16.smethod_0(1649058400), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					goto IL_045e;
					IL_045e:
					num2++;
				}
				while (num2 < (nint)DataFiles.GShop.Items.LongLength);
			}
			try
			{
				if (SearchResults.Count > 0)
				{
					Color searchMatchBack = TDark.SearchMatchBack;
					textBox_0.BackColor = searchMatchBack;
					method_94(FILTER_MODE.Search);
				}
				else
				{
					Color searchErrorBack = TDark.SearchErrorBack;
					textBox_0.BackColor = searchErrorBack;
				}
			}
			catch (Exception ex9)
			{
				SentryHelper.CaptureException(ex9, Class16.smethod_0(1649059532));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649058427), Class16.smethod_0(1649058479)), ex9.Message), Class16.smethod_0(1649058514), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex10)
		{
			SentryHelper.CaptureException(ex10, Class16.smethod_0(1649059532));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649058551), Class16.smethod_0(1649058604)), ex10.Message), Class16.smethod_0(1649058648), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.antirecurse_FindItem_GShopEditor_PW = false;
			GC.KeepAlive(this);
		}
	}

	private void method_16(int int_6, bool bool_7, bool bool_8)
	{
		if (DataFiles.GShop?.Items == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649058667)), TextStorage.Msg(Class16.smethod_0(1649059688)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if (int_6 < 0)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649058710)), TextStorage.Msg(Class16.smethod_0(1649058729)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (int_6 >= DataFiles.GShop.Items.Length)
		{
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649058755), Class16.smethod_0(1649058798)), int_6, DataFiles.GShop.Items.Length - 1), Class16.smethod_0(1649057834), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		GSHOP_ITEM_PW gSHOP_ITEM_PW;
		try
		{
			gSHOP_ITEM_PW = (GSHOP_ITEM_PW)DataFiles.GShop.Items[int_6];
			if (gSHOP_ITEM_PW == null)
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649057859), Class16.smethod_0(1649057901)), int_6), Class16.smethod_0(1649057934), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649057951));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649057983), Class16.smethod_0(1649059140)), int_6, ex.Message), Class16.smethod_0(1649059177), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if (bool_8)
		{
			uint catIndex = gSHOP_ITEM_PW.CatIndex;
			if (catIndex <= 8)
			{
				uint subCatIndex = gSHOP_ITEM_PW.SubCatIndex;
				if (subCatIndex <= 8)
				{
					try
					{
						method_45((int)catIndex, (int)subCatIndex);
					}
					catch (Exception ex2)
					{
						SentryHelper.CaptureException(ex2, Class16.smethod_0(1649057951));
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649058019), Class16.smethod_0(1649058059)), ex2.Message), Class16.smethod_0(1649059627), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					goto IL_01e9;
				}
			}
			GC.KeepAlive(this);
			return;
		}
		goto IL_01e9;
		IL_01e9:
		try
		{
			int num = method_36(int_6);
			if (num > -1)
			{
				method_19(num, bool_7);
			}
			else
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649058098), Class16.smethod_0(1649058131)), int_6), Class16.smethod_0(1649058199), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex3)
		{
			SentryHelper.CaptureException(ex3, Class16.smethod_0(1649057951));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649058222), Class16.smethod_0(1649058251)), ex3.Message), Class16.smethod_0(1649058295), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_17()
	{
		try
		{
			ShopIconsWindow?.Hide();
		}
		catch
		{
		}
		try
		{
			ShopIconsWindow?.Dispose();
		}
		catch
		{
		}
		ShopIconsWindow = null;
		try
		{
			((IDisposable)ShopIcons)?.Dispose();
		}
		catch
		{
		}
		ShopIcons = null;
		pictureBox_1.Image = null;
	}

	private void method_18(int int_6)
	{
		method_16(int_6, bool_7: true, bool_8: true);
	}

	private void method_19(int int_6, bool bool_7)
	{
		if (int_6 < 0)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649061385)), TextStorage.Msg(Class16.smethod_0(1649061410)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (dataGridViewEx_0?.Rows == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649061434)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if (int_6 >= dataGridViewEx_0.Rows.Count)
		{
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649061468), Class16.smethod_0(1649061500)), int_6, dataGridViewEx_0.Rows.Count - 1), Class16.smethod_0(1649061567), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (bool_7)
		{
			bool flag = !DontChange;
			DontChange = true;
			try
			{
				dataGridViewEx_0.ClearSelection();
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649061596));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649061619), Class16.smethod_0(1649061669)), ex.Message), Class16.smethod_0(1649061710), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (flag)
			{
				DontChange = false;
			}
			try
			{
				DataGridViewEx dataGridViewEx = dataGridViewEx_0;
				dataGridViewEx_0.CurrentCell = dataGridViewEx[Struct59.int_1, int_6];
			}
			catch (ArgumentOutOfRangeException ex2)
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649061732), Class16.smethod_0(1649061769)), int_6, ex2.Message), Class16.smethod_0(1649061817), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			catch (Exception ex3)
			{
				SentryHelper.CaptureException(ex3, Class16.smethod_0(1649061596));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649061841), Class16.smethod_0(1649061880)), ex3.Message), Class16.smethod_0(1649060902), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		try
		{
			dataGridViewEx_0.Rows[int_6].Selected = true;
		}
		catch (Exception ex4)
		{
			SentryHelper.CaptureException(ex4, Class16.smethod_0(1649061596));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649060919), Class16.smethod_0(1649060951)), int_6, ex4.Message), Class16.smethod_0(1649058295), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_15();
	}

	private void GShopEditor_PW_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (IsFileChanged && !ElementsWindow.Visible)
		{
			switch (TextStorage.TEXTS.ShowMessage(246, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, null))
			{
			case DialogResult.Yes:
				method_9();
				break;
			case DialogResult.Cancel:
				e.Cancel = true;
				GC.KeepAlive(this);
				return;
			}
		}
		method_53();
		Hide();
		if (!ElementsWindow.Visible)
		{
			ACE.RSGlobal.RSGlobal.End(null, null);
		}
		else
		{
			e.Cancel = true;
		}
		GC.KeepAlive(this);
	}

	private void method_20(object sender, EventArgs e)
	{
		SettingsWindow settingsWindow = new SettingsWindow(CStorage, Class16.smethod_0(1649067813));
		try
		{
			if (settingsWindow.ShowDialog(this) == DialogResult.OK)
			{
				object surfacesPckDir = eLC.Params.SurfacesPckDir;
				SettingsClass profile = CommonStorage.Profile;
				profile.SaveSetting(profile.DefaultSection, Class16.smethod_0(1649067817), surfacesPckDir);
				object gShopPath = eLC.Params.GShopPath;
				SettingsClass profile2 = CommonStorage.Profile;
				profile2.SaveSetting(profile2.DefaultSection, Class16.smethod_0(1649067797), gShopPath);
				method_21();
			}
		}
		finally
		{
			((IDisposable)settingsWindow).Dispose();
		}
	}

	private void method_21()
	{
		if (backgroundWorker_0.IsBusy)
		{
			GC.KeepAlive(this);
			return;
		}
		method_17();
		bSurfacesLoaded = false;
		toolStripMenuItem_66.Visible = true;
		toolStripMenuItem_66.Enabled = false;
		method_85();
		backgroundWorker_0.RunWorkerAsync();
		GC.KeepAlive(this);
	}

	private unsafe void method_22(string string_0, int* pInt_0)
	{
		Bitmap bitmap = null;
		if (string.IsNullOrEmpty(string_0))
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649060978)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (!Directory.Exists(string_0))
		{
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649061012), Class16.smethod_0(1649061053)), string_0), Class16.smethod_0(1649061132), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if (pfimImageReader_0 is IDisposable disposable)
		{
			disposable.Dispose();
		}
		pfimImageReader_0 = new PfimImageReader();
		string[] files;
		try
		{
			files = Directory.GetFiles(string_0, Class16.smethod_0(1649067891), SearchOption.AllDirectories);
		}
		catch (UnauthorizedAccessException ex)
		{
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649061158), Class16.smethod_0(1649061197)), string_0, ex.Message), Class16.smethod_0(1649061233), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		catch (DirectoryNotFoundException ex2)
		{
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649061260), Class16.smethod_0(1649061292)), ex2.Message), Class16.smethod_0(1649061315), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		catch (Exception ex3)
		{
			SentryHelper.CaptureException(ex3, Class16.smethod_0(1649061337));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649060359), Class16.smethod_0(1649060397)), string_0, ex3.Message), Class16.smethod_0(1649060432), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		int num = 0;
		string[] array = files;
		for (int i = 0; i < (nint)array.LongLength; i++)
		{
			string text = array[i];
			num++;
			if (text.Contains(Class16.smethod_0(1649060456)))
			{
				continue;
			}
			int num2 = num;
			if (num2 - num2 / 500 * 500 == 0)
			{
				backgroundWorker_0.ReportProgress((int)((double)num / (double)(nint)files.LongLength * 100.0));
			}
			FileInfo fileInfo;
			try
			{
				fileInfo = new FileInfo(text);
			}
			catch (Exception ex4)
			{
				SentryHelper.CaptureException(ex4, Class16.smethod_0(1649061337));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649060475), Class16.smethod_0(1649060516)), text, ex4.Message), Class16.smethod_0(1649060546), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				continue;
			}
			if (fileInfo.Length > 30720L)
			{
				continue;
			}
			FileStream fileStream = null;
			try
			{
				fileStream = File.OpenRead(text);
				bitmap = null;
				if (pfimImageReader_0.TryReadShopIcon(fileStream, 128, out bitmap))
				{
					string text2 = null;
					if (eLC.Params.SurfacesPckDir.Contains(Class16.smethod_0(1649060563)))
					{
						int startIndex = text.LastIndexOf(Class16.smethod_0(1649060588), StringComparison.OrdinalIgnoreCase) + 9;
						text2 = Class16.smethod_0(1648904820) + text.Substring(startIndex);
					}
					else
					{
						text2 = Class16.smethod_0(1648904820) + text.Substring(eLC.Params.SurfacesPckDir.Length);
					}
					text2 = text2.ToLowerInvariant();
					if (ShopIcons.TryAddIcon(text2, bitmap))
					{
						(*pInt_0)++;
					}
				}
			}
			catch (UnauthorizedAccessException ex5)
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649060605), Class16.smethod_0(1649060639)), text, ex5.Message), Class16.smethod_0(1649060678), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			catch (IOException ex6)
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649060702), Class16.smethod_0(1649060729)), text, ex6.Message), Class16.smethod_0(1649060769), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			catch (Exception ex7)
			{
				SentryHelper.CaptureException(ex7, Class16.smethod_0(1649061337));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649060798), Class16.smethod_0(1649060824)), text, ex7.Message), Class16.smethod_0(1649059847), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				try
				{
					fileStream?.Close();
				}
				catch (Exception ex8)
				{
					SentryHelper.CaptureException(ex8, Class16.smethod_0(1649061337));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649059867), Class16.smethod_0(1649059917)), text, ex8.Message), Class16.smethod_0(1649059964), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
		GC.KeepAlive(this);
	}

	private int method_23()
	{
		pfimImageReader_0 = new PfimImageReader();
		int num = 0;
		foreach (KeyValuePair<string, int> fileTableIndex in PCKs[Class16.smethod_0(1649067915)].FileTableIndices)
		{
			ValueType valueType = fileTableIndex;
			num++;
			int num2 = num;
			if (num2 - num2 / 500 * 500 == 0)
			{
				PCK pCK = PCKs[Class16.smethod_0(1649067915)];
				int percentProgress = (int)((double)num / (double)pCK.FileTableIndices.Count * 100.0);
				backgroundWorker_0.ReportProgress(percentProgress);
			}
			string key = ((KeyValuePair<string, int>)(object)valueType).Key;
			if (!key.EndsWith(Class16.smethod_0(1648904847)) || key.Contains(Class16.smethod_0(1649059983)) || key.Contains(Class16.smethod_0(1649059997)) || key.Contains(Class16.smethod_0(1649060002)))
			{
				continue;
			}
			uint value = (uint)((KeyValuePair<string, int>)(object)valueType).Value;
			if ((int)PCKs[Class16.smethod_0(1649067915)].Pck.FileTable[value].OriginalSize > 30720)
			{
				continue;
			}
			byte[] fileContent = PCKs[Class16.smethod_0(1649067915)].Pck.GetFileContent((int)value);
			if (fileContent == null)
			{
				continue;
			}
			try
			{
				Bitmap result = null;
				MemoryStream memoryStream = new MemoryStream(fileContent, writable: false);
				try
				{
					if (pfimImageReader_0.TryReadShopIcon(memoryStream, 128, out result))
					{
						ShopIcons.TryAddIcon(key, result);
					}
				}
				finally
				{
					((IDisposable)memoryStream).Dispose();
				}
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureMessage(Class16.smethod_0(1649060023) + key + Class16.smethod_0(1648927638) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649060049));
			}
		}
		PCKs[Class16.smethod_0(1649067915)].Close();
		int iconNamesCount = ShopIcons.IconNamesCount;
		GC.KeepAlive(this);
		return iconNamesCount;
	}

	private void method_24(string string_0)
	{
		DKBox.Show(this, string_0, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
	}

	private int method_25()
	{
		if (int_0 == 0)
		{
			method_27();
		}
		return int_0;
	}

	private static void smethod_2(PictureBox pictureBox_3, Image image_0)
	{
		if (pictureBox_3 == null)
		{
			return;
		}
		Image image = pictureBox_3.Image;
		if (image_0 == null)
		{
			pictureBox_3.Image = null;
			if (image == null)
			{
				return;
			}
			try
			{
				image.Dispose();
				return;
			}
			catch
			{
				return;
			}
		}
		try
		{
			_ = image_0.FrameDimensionsList;
		}
		catch
		{
			pictureBox_3.Image = null;
			if (image != null)
			{
				try
				{
					image.Dispose();
					return;
				}
				catch
				{
					return;
				}
			}
			return;
		}
		Image image2 = null;
		try
		{
			image2 = (Image)image_0.Clone();
		}
		catch
		{
			try
			{
				image2 = new Bitmap(image_0);
			}
			catch
			{
				image2 = null;
			}
		}
		pictureBox_3.Image = image2;
		if (image == null)
		{
			return;
		}
		try
		{
			image.Dispose();
		}
		catch
		{
		}
	}

	private static void smethod_3(PictureBox pictureBox_3)
	{
		if (pictureBox_3?.Image == null)
		{
			return;
		}
		try
		{
			_ = pictureBox_3.Image.FrameDimensionsList;
		}
		catch
		{
			pictureBox_3.Image = null;
		}
	}

	private void method_26()
	{
		smethod_3(pictureBox_1);
		smethod_3(pictureBox_0);
		smethod_3(pictureBox_2);
	}

	private void method_27()
	{
		int num = 0;
		int num2 = 0;
		CommonStorage.GetWindowDisplayLogicalResolution(base.Handle, ref num, ref num2);
		int_0 = (int)((double)num2 * (1.0 / 128.0) - 1.0);
		int_1 = (int)((double)num * (1.0 / 128.0) - 1.0);
	}

	private unsafe void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		(ShopIcons = new ICONS(CStorage)).IsGShop = true;
		ShopIcons.icon_width = 128;
		ShopIcons.icon_height = 128;
		ShopIcons.SortedImage = null;
		int num = 0;
		ParamsClass paramsClass = eLC.Params;
		if (paramsClass.UsePck)
		{
			if (!PCKs.LoadIfNotLoaded(Class16.smethod_0(1649067915)))
			{
				TextStorage.TEXTS.ShowErrorMessage(597);
				ShopIcons = null;
				return;
			}
			if (!PCKs[Class16.smethod_0(1649067915)].Pck.OpenRead())
			{
				TextStorage.TEXTS.ShowErrorMessage(597);
				ShopIcons = null;
				return;
			}
			num = method_23();
		}
		else
		{
			string surfacesPckDir = paramsClass.SurfacesPckDir;
			if (string.IsNullOrWhiteSpace(surfacesPckDir) || !surfacesPckDir.Contains(Class16.smethod_0(1649067041)) || !Directory.Exists(surfacesPckDir))
			{
				TextStorage.TEXTS.ShowErrorMessage(596);
				((IDisposable)ShopIcons)?.Dispose();
				GC.KeepAlive(this);
				return;
			}
			method_22(eLC.Params.SurfacesPckDir, &num);
		}
		ShopIcons.icons_count = num;
		int num2 = ((CommonStorage.AParams.ExperimentalIcons || num > 2500 || CommonStorage.GetMemoryUsageMb() > 2000.0) ? 1 : 0);
		if (CommonStorage.AParams.DisableNewIconsWindow || (byte)num2 == 0)
		{
			int num3 = method_85();
			ShopIcons.icons_per_line = num3;
			double num4 = num;
			int lines_count = (int)Math.Ceiling(num4 / (double)method_25());
			ShopIcons.lines_count = lines_count;
			ShopIcons.SortedImage = ShopIcons.CreateScreenAdaptedImage(num3);
			(ShopIconsWindow = new IconsWindow(CStorage, ShopIcons)).PathData = eLC.PathData;
			ShopIconsWindow.VIconsCount = method_25();
			ShopIconsWindow.IsShopPW = true;
			ShopIconsWindow.SortedIconsLoaded(num3);
		}
		GC.KeepAlive(this);
	}

	private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		ICONS shopIcons = ShopIcons;
		if (shopIcons != null && shopIcons.icons_count > 0)
		{
			bSurfacesLoaded = true;
			toolStripMenuItem_66.Visible = false;
		}
		else
		{
			bSurfacesLoaded = false;
			toolStripMenuItem_66.Visible = true;
			toolStripMenuItem_66.Enabled = true;
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649060108));
			toolStripMenuItem_66.Text = text;
		}
		method_29();
		method_34();
	}

	private void pictureBox_1_Click(object sender, EventArgs e)
	{
		method_28();
	}

	private void method_28()
	{
		ICONS shopIcons = ShopIcons;
		GSHOP_ITEM_PW gSHOP_ITEM_PW = pwGItem;
		if (shopIcons == null || gSHOP_ITEM_PW == null)
		{
			return;
		}
		if (shopIcons.SortedImage != null)
		{
			if (ShopIconsWindow != null)
			{
				CStorage.ResetBuffer();
				ShopIconsWindow.CurrentIconName = gSHOP_ITEM_PW.sIconPath;
				try
				{
					ShopIconsWindow.ShowDialog(this);
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649060123));
				}
				if (CommonStorage.sData != null)
				{
					textBox_3.Text = CommonStorage.sData;
				}
			}
			return;
		}
		if (shopIcons.Icons != null)
		{
			int? vImageCount = null;
			int? hImageCount = null;
			Size imageSize = new Size(shopIcons.icon_width, shopIcons.icon_height);
			ICONS shopIcons2 = ShopIcons;
			ICONS shopIcons3 = ShopIcons;
			ImageSelectorConfig config = new ImageSelectorConfig(imageSize, shopIcons3.IconNamesCount, hImageCount, vImageCount, shopIcons2.GetIconByIndex);
			ICONS shopIcons4 = ShopIcons;
			int? currentImageIndex = shopIcons4.GetIconIndexInFile(gSHOP_ITEM_PW.sIconPath);
			FastImageSelectorWindow fastImageSelectorWindow = new FastImageSelectorWindow(config, currentImageIndex);
			try
			{
				if (fastImageSelectorWindow.ShowDialog(this) == DialogResult.OK)
				{
					string iconName = shopIcons.GetIconName(fastImageSelectorWindow.ResultImageIndex);
					if (iconName != null)
					{
						textBox_3.Text = iconName;
					}
				}
				return;
			}
			finally
			{
				((IDisposable)fastImageSelectorWindow).Dispose();
			}
		}
		if (TextStorage.TEXTS.ShowQuestionMessage(280) == DialogResult.Yes)
		{
			toolStripMenuItem_66_Click(null, null);
		}
	}

	private void method_29()
	{
		GSHOP_ITEM_PW gSHOP_ITEM_PW = pwGItem;
		if (gSHOP_ITEM_PW != null && bSurfacesLoaded)
		{
			string text = gSHOP_ITEM_PW.sIconPath;
			if (text != null && text.StartsWith(Class16.smethod_0(1649060155), StringComparison.OrdinalIgnoreCase))
			{
				text = Class16.smethod_0(1648904820) + text.Substring(9);
			}
			Image image = ShopIcons.GetIcon(text, IsTga: false);
			if (image != null)
			{
				smethod_2(pictureBox_1, image);
				GC.KeepAlive(this);
			}
		}
	}

	private void dataGridViewEx_0_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
	{
		if (e.Column.Index == Struct59.int_5)
		{
			double num = Convert.ToDouble((string)e.CellValue1);
			double num2 = Convert.ToDouble((string)e.CellValue2);
			if (num > num2)
			{
				e.SortResult = 1;
			}
			else if (num < num2)
			{
				e.SortResult = -1;
			}
			else
			{
				e.SortResult = 0;
			}
			e.Handled = true;
		}
		else if (e.Column.Index == Struct59.int_3)
		{
			e.SortResult = ACE.RSGlobal.RSGlobal.StrCmpLogicalW((string)e.CellValue1, (string)e.CellValue2);
			e.Handled = true;
		}
		GC.KeepAlive(this);
	}

	private void textBox_2_MouseMove(object sender, MouseEventArgs e)
	{
		string text = textBox_2.Text;
		IntPtr handle = ((Control)sender).Handle;
		ItemsToolTip1.ShowToolTip(handle, string.Join(Class16.smethod_0(1648924428), ACE.RSGlobal.RSGlobal.SplitTextWithLines(text, 60)));
		GC.KeepAlive(this);
	}

	private void dataGridViewEx_0_MouseLeave(object sender, EventArgs e)
	{
		bool_5 = false;
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void dataGridViewEx_0_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		bool_5 = false;
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		if (RowIndexUnderCursor >= 0)
		{
			int rowIndexUnderCursor = RowIndexUnderCursor;
			if (rowIndexUnderCursor < dataGridViewEx_0.RowCount)
			{
				int num = (int)dataGridViewEx_0.Rows[rowIndexUnderCursor].Tag;
				if (bool_5 && num < (nint)DataFiles.GShop.Items.LongLength && DataFiles.GShop.Items[num].ItemInfo != null)
				{
					GSHOP_ITEM[] items = DataFiles.GShop.Items;
					if (eLC.IsItemExist(items[num].ItemInfo.pos))
					{
						if (HINTS.ToolTipWindow != null)
						{
							IntPtr handle = dataGridViewEx_0.Handle;
							GSHOP_ITEM[] items2 = DataFiles.GShop.Items;
							HINTS.ShowElementToolTip(handle, items2[num].ItemInfo.pos, IsShopPrice: false, bUnlimited: false, null);
						}
						goto IL_0102;
					}
				}
				if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
				{
					HINTS.ToolTipWindow.SmoothHide();
				}
				goto IL_0102;
			}
		}
		GC.KeepAlive(this);
		return;
		IL_0102:
		GC.KeepAlive(this);
	}

	private void dataGridViewEx_0_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		bool_5 = true;
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridViewEx_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
					TextBox textBox = textBox_1;
					((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).sName = textBox.Text;
					num++;
				}
				while (num < dataGridViewEx_0.SelectedRows.Count);
			}
			method_11();
			method_34();
		}
		if (!DontChange)
		{
			method_5();
		}
	}

	private void numericUpDownEx_5_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridViewEx_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
					decimal value = numericUpDownEx_5.Value;
					((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).Status = (uint)value;
					num++;
				}
				while (num < dataGridViewEx_0.SelectedRows.Count);
			}
			method_11();
			method_34();
			method_64();
		}
		if (DataFiles.GShop.VersionPW < PW_GSHOP_VERSION.PW_1_7_6)
		{
			decimal value2 = numericUpDownEx_5.Value;
			if (value2 > 19m)
			{
				numericUpDownEx_5.SetValueSafe(19m);
			}
		}
	}

	private void numericUpDownEx_0_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridViewEx_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
					decimal value = numericUpDownEx_0.Value;
					ref int itemID = ref ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).ItemID;
					itemID = (int)value;
					num++;
				}
				while (num < dataGridViewEx_0.SelectedRows.Count);
			}
			method_11();
			method_34();
		}
		if (!DontChange)
		{
			int itemID2 = pwGItem.ItemID;
			eListCollection eListCollection2 = eLC;
			int[] mattersLists = eListCollection2.MattersLists;
			eListCollection eListCollection3 = eListCollection2;
			ITEMPOS itemPos = eListCollection3.FindItemPos(mattersLists, itemID2);
			ITEMINFO itemInfo = eListCollection3.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
			pwGItem.ItemInfo = itemInfo;
			if (pwGItem.ItemInfo != null)
			{
				if (toolStripMenuItem_22.Checked)
				{
					toolStripMenuItem_20_Click(null, null);
				}
				if (toolStripMenuItem_23.Checked)
				{
					toolStripMenuItem_24_Click(null, null);
				}
			}
			method_5();
			UpdatePropsInElements(bOnlyRecalculate: true);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UPDATE_REFERENCES, (int)DataFiles.CurrentGShop, 0);
		}
		GC.KeepAlive(this);
	}

	private void numericUpDownEx_2_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange && toolStripMenuItem_34.Checked)
		{
			int num = 0;
			if (0 < dataGridViewEx_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
					GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)DataFiles.GShop.Items[num2];
					if (gSHOP_ITEM_PW.Count >= 1)
					{
						decimal value = numericUpDownEx_2.Value;
						double num3 = gSHOP_ITEM_PW.Count;
						double num4 = gSHOP_ITEM_PW.Price / num3;
						double num5 = (double)value * num4;
						if (Math.Abs(gSHOP_ITEM_PW.Price - num5) > 0.01)
						{
							gSHOP_ITEM_PW.Price = num5;
						}
					}
					num++;
				}
				while (num < dataGridViewEx_0.SelectedRows.Count);
			}
			bool flag = !DontChange;
			DontChange = true;
			decimal value2 = (decimal)pwGItem.Price;
			numericUpDownEx_1.SetValueSafe(value2);
			if (flag)
			{
				DontChange = false;
			}
		}
		if (!DontChange)
		{
			int num6 = 0;
			if (0 < dataGridViewEx_0.SelectedRows.Count)
			{
				do
				{
					int num7 = (int)dataGridViewEx_0.SelectedRows[num6].Tag;
					decimal value3 = numericUpDownEx_2.Value;
					ref int count = ref ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num7]).Count;
					count = (int)value3;
					num6++;
				}
				while (num6 < dataGridViewEx_0.SelectedRows.Count);
			}
			method_11();
			method_34();
		}
		if (!DontChange)
		{
			method_5();
			UpdatePropsInElements(bOnlyRecalculate: true);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UPDATE_REFERENCES, (int)DataFiles.CurrentGShop, 0);
		}
		GC.KeepAlive(this);
	}

	private void numericUpDownEx_1_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridViewEx_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
					decimal value = numericUpDownEx_1.Value;
					((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).Price = (double)value;
					num++;
				}
				while (num < dataGridViewEx_0.SelectedRows.Count);
			}
			method_11();
			method_34();
		}
		if (!DontChange)
		{
			method_5();
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UPDATE_REFERENCES, (int)DataFiles.CurrentGShop, 0);
		}
		GC.KeepAlive(this);
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void numericUpDownEx_3_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridViewEx_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
					decimal value = numericUpDownEx_3.Value;
					ref int giftID = ref ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).GiftID;
					giftID = (int)value;
					num++;
				}
				while (num < dataGridViewEx_0.SelectedRows.Count);
			}
			method_11();
			method_34();
		}
		int giftID2 = pwGItem.GiftID;
		eListCollection eListCollection2 = eLC;
		int[] mattersLists = eListCollection2.MattersLists;
		eListCollection eListCollection3 = eListCollection2;
		ITEMPOS itemPos = eListCollection3.FindItemPos(mattersLists, giftID2);
		ITEMINFO itemInfo = eListCollection3.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		if (itemInfo != null)
		{
			smethod_2(pictureBox_2, eLC.Icons.GetIcon(itemInfo.IconName, IsTga: false));
		}
		else
		{
			pictureBox_2.Image = null;
		}
		GC.KeepAlive(this);
	}

	private void method_30(object sender, EventArgs e)
	{
	}

	private void method_31(object sender, EventArgs e)
	{
	}

	private void textBox_2_TextChanged(object sender, EventArgs e)
	{
		if (textBox_2.Focused)
		{
			string text = textBox_2.Text;
			IntPtr handle = ((Control)sender).Handle;
			ItemsToolTip1.ShowToolTip(handle, string.Join(Class16.smethod_0(1648924428), ACE.RSGlobal.RSGlobal.SplitTextWithLines(text, 60)));
		}
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				TextBox textBox = textBox_2;
				((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).sDescription = ACE.RSGlobal.RSGlobal.CrLF2rn(textBox.Text);
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void method_32()
	{
		dataGridViewEx_0_SelectionChanged(null, null);
	}

	private void method_33(object sender, EventArgs e)
	{
		method_28();
	}

	private void textBox_3_DoubleClick(object sender, EventArgs e)
	{
		method_28();
	}

	private void numericUpDownEx_0_DoubleClick(object sender, EventArgs e)
	{
		decimal value = numericUpDownEx_0.Value;
		int num = method_35((int)value);
		if (num > 0)
		{
			decimal value2 = num;
			numericUpDownEx_0.SetValueSafe(value2);
		}
		GC.KeepAlive(this);
	}

	private void numericUpDownEx_3_DoubleClick(object sender, EventArgs e)
	{
		decimal value = numericUpDownEx_3.Value;
		int num = method_35((int)value);
		if (num > 0)
		{
			decimal value2 = num;
			numericUpDownEx_3.SetValueSafe(value2);
		}
		GC.KeepAlive(this);
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		colorDialog_0.Color = color_0;
		if (colorDialog_0.ShowDialog(this) == DialogResult.OK)
		{
			string value = RSCommon.Color2ColorTag(colorDialog_0.Color);
			int selectionStart = textBox_2.SelectionStart;
			string text = textBox_2.Text;
			textBox_2.Text = text.Insert(textBox_2.SelectionStart, value);
			textBox_2.SelectionStart = selectionStart + 7;
			textBox_2.Focus();
			Color color = colorDialog_0.Color;
			color_0 = color;
		}
		GC.KeepAlive(this);
	}

	private void method_34()
	{
		object[] vars = new object[1] { dataGridViewEx_0.RowCount };
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649067057), vars);
		toolStripStatusLabel_0.Text = text;
		toolStripMenuItem_84.Enabled = IsFileChanged;
		toolStripButton_3.Enabled = IsFileChanged;
		byte b = (byte)((DataFiles.GShop != null && DataFiles.GShop.FileLoaded) ? 1u : 0u);
		toolStripButton_4.Enabled = b != 0;
		byte b2 = ((dataGridViewEx_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		toolStripButton_6.Enabled = b2 != 0;
		byte b3 = (byte)((DataFiles.GShop != null && DataFiles.GShop.FileLoaded) ? 1u : 0u);
		toolStripButton_7.Enabled = b3 != 0;
		byte b4 = (byte)((DataFiles.GShop != null && DataFiles.GShop.FileLoaded) ? 1u : 0u);
		toolStripButton_8.Enabled = b4 != 0;
		GC.KeepAlive(this);
	}

	private int method_35(int int_6)
	{
		if (ItemsWindow1 != null && !ItemsWindow1.IsDisposed && !ItemsWindow1.Disposing && eLC != null)
		{
			eListCollection eListCollection2 = eLC;
			ITEMPOS iTEMPOS = eListCollection2.FindItemPos(eListCollection2.MattersLists, int_6);
			if (iTEMPOS != null)
			{
				ItemsWindow1.newitemlist = iTEMPOS.int_0;
				ItemsWindow1.newitemindex = iTEMPOS.int_1;
			}
			ItemsWindow1.newlistsindices = eLC.MattersLists;
			ItemsWindow1.bMultiSelect = false;
			CStorage.ResetBuffer();
			if (method_3(out var dialogResult_) && dialogResult_ == DialogResult.OK)
			{
				int result = Convert.ToInt32(CommonStorage.sData);
				GC.KeepAlive(this);
				return result;
			}
			GC.KeepAlive(this);
			return 0;
		}
		return 0;
	}

	private void pictureBox_0_Click(object sender, EventArgs e)
	{
		decimal value = numericUpDownEx_0.Value;
		int num = method_35((int)value);
		if (num > 0)
		{
			decimal value2 = num;
			numericUpDownEx_0.SetValueSafe(value2);
		}
		GC.KeepAlive(this);
	}

	private void pictureBox_2_Click(object sender, EventArgs e)
	{
		decimal value = numericUpDownEx_3.Value;
		int num = method_35((int)value);
		if (num > 0)
		{
			decimal value2 = num;
			numericUpDownEx_3.SetValueSafe(value2);
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		method_7();
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		method_8();
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_50();
	}

	private int method_36(int int_6)
	{
		int num = 0;
		if (0 < dataGridViewEx_0.RowCount)
		{
			do
			{
				if ((int)dataGridViewEx_0.Rows[num].Tag != int_6)
				{
					num++;
					continue;
				}
				return num;
			}
			while (num < dataGridViewEx_0.RowCount);
		}
		GC.KeepAlive(this);
		return -1;
	}

	private int method_37(int int_6)
	{
		int result = (int)dataGridViewEx_0.Rows[int_6].Tag;
		GC.KeepAlive(this);
		return result;
	}

	private void toolStripMenuItem_66_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(605, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void method_38()
	{
		if (DataFiles.GShop != null)
		{
			string text = DataFiles.GShop.VersionPW switch
			{
				PW_GSHOP_VERSION.PW_1_2_6 => Class16.smethod_0(1649060171), 
				PW_GSHOP_VERSION.PW_1_4_2_v27 => Class16.smethod_0(1649060191), 
				PW_GSHOP_VERSION.PW_1_4_2_v29 => Class16.smethod_0(1649060201), 
				PW_GSHOP_VERSION.PW_1_4_4 => Class16.smethod_0(1649060219), 
				PW_GSHOP_VERSION.PW_1_5_3 => Class16.smethod_0(1649060232), 
				PW_GSHOP_VERSION.PW_1_5_5_v156 => Class16.smethod_0(1649060251), 
				PW_GSHOP_VERSION.PW_1_5_5_v181 => Class16.smethod_0(1649060278), 
				PW_GSHOP_VERSION.PW_1_6_0 => Class16.smethod_0(1649060290), 
				PW_GSHOP_VERSION.PW_1_7_6 => Class16.smethod_0(1649060311), 
				PW_GSHOP_VERSION.PW_1_8_3 => Class16.smethod_0(1649060324), 
				PW_GSHOP_VERSION.PW_1_8_6 => Class16.smethod_0(1649060329), 
				_ => Class16.smethod_0(1648941528), 
			};
			string fileName = DataFiles.GShop.FileName;
			string text2 = (IsFileChanged ? Class16.smethod_0(1648941528) : string.Empty);
			Text = text2 + fileName + Class16.smethod_0(1648942627) + text;
		}
	}

	private void method_39()
	{
		int num = 0;
		do
		{
			string text = Class16.smethod_0(1649060350);
			RadioButton radioButton = (RadioButton)tableLayoutPanel_0.Controls[text + num];
			Category[] categories = DataFiles.GShop.Categories;
			radioButton.Text = categories[num].name;
			num++;
		}
		while (num < 8);
		GC.KeepAlive(this);
	}

	private void method_40()
	{
		int num = 0;
		do
		{
			string text = Class16.smethod_0(1649055235);
			RadioButton radioButton = (RadioButton)tableLayoutPanel_0.Controls[text + num];
			int selectedCatIndex = SelectedCatIndex;
			if (selectedCatIndex > -1)
			{
				Category[] categories = DataFiles.GShop.Categories;
				if (num < (nint)categories[selectedCatIndex].SubCats.LongLength)
				{
					string text2 = Class16.smethod_0(1648942897);
					int selectedCatIndex2 = SelectedCatIndex;
					string text3 = Class16.smethod_0(1648899468);
					int selectedCatIndex3 = SelectedCatIndex;
					string text4 = DataFiles.GShop.Categories[selectedCatIndex3].SubCats[num];
					radioButton.Text = string.Concat(string.Concat(text4 + text3, DataFiles.GShop.GetCatItemsCount((uint)selectedCatIndex2, (uint)num)), text2);
					radioButton.Image = radioButton_0.Image;
					goto IL_0019;
				}
			}
			radioButton.Text = string.Empty;
			radioButton.Image = null;
			goto IL_0019;
			IL_0019:
			byte b = ((SelectedCatIndex > -1) ? ((byte)1) : ((byte)0));
			radioButton.Enabled = b != 0;
			int selectedSubCatIndex = SelectedSubCatIndex;
			if (selectedSubCatIndex > -1)
			{
				byte b2 = ((num == selectedSubCatIndex) ? ((byte)1) : ((byte)0));
				radioButton.Checked = b2 != 0;
			}
			else
			{
				radioButton.Checked = false;
			}
			num++;
		}
		while (num < 8);
		byte b3 = ((SelectedSubCatIndex == -1) ? ((byte)1) : ((byte)0));
		radioButton_0.Checked = b3 != 0;
		int selectedCatIndex4 = SelectedCatIndex;
		if (selectedCatIndex4 > -1)
		{
			if ((nint)DataFiles.GShop.Categories[selectedCatIndex4].SubCats.LongLength > 8)
			{
				int selectedCatIndex5 = SelectedCatIndex;
				Category[] categories2 = DataFiles.GShop.Categories;
				toolStripButton_10.Text = categories2[selectedCatIndex5].SubCats[8];
				toolStripButton_10.Visible = true;
				toolStripSeparator_25.Visible = true;
			}
			else
			{
				toolStripButton_10.Visible = false;
				toolStripSeparator_25.Visible = false;
			}
		}
		GC.KeepAlive(this);
	}

	private void method_41()
	{
		dataGridViewEx_0.Rows.Clear();
		dictionary_0.Clear();
		IsFileChanged = false;
		toolStripMenuItem_84.Enabled = false;
		if (!DataFiles.GShop.FileLoaded)
		{
			FileName = DataFiles.GShop.FileName;
			GC.KeepAlive(this);
			return;
		}
		byte b = ((DataFiles.GShop.VersionPW > PW_GSHOP_VERSION.PW_1_2_6) ? ((byte)1) : ((byte)0));
		toolStripMenuItem_4.Visible = b != 0;
		byte b2 = ((DataFiles.GShop.VersionPW > PW_GSHOP_VERSION.PW_1_2_6) ? ((byte)1) : ((byte)0));
		toolStripButton_8.Visible = b2 != 0;
		byte b3 = ((DataFiles.GShop.VersionPW > PW_GSHOP_VERSION.PW_1_2_6) ? ((byte)1) : ((byte)0));
		toolStripSeparator_26.Visible = b3 != 0;
		uint timeStamp = DataFiles.GShop.TimeStamp;
		toolStripButton_8.Text = CommonStorage.Timestamp2String(timeStamp, ShowSeconds: true);
		if (!bSurfacesLoaded)
		{
			method_21();
		}
		switch (DataFiles.GShop.VersionPW)
		{
		default:
			dateTimePicker_1.Enabled = true;
			comboBox_0.Enabled = true;
			numericUpDownEx_9.Enabled = true;
			numericUpDownEx_8.Enabled = true;
			groupBox_4.Enabled = true;
			break;
		case PW_GSHOP_VERSION.PW_1_4_2_v27:
		case PW_GSHOP_VERSION.PW_1_4_2_v29:
			dateTimePicker_1.Enabled = true;
			comboBox_0.Enabled = true;
			numericUpDownEx_9.Enabled = true;
			numericUpDownEx_8.Enabled = true;
			groupBox_4.Enabled = false;
			break;
		case PW_GSHOP_VERSION.PW_1_2_6:
			dateTimePicker_1.Enabled = false;
			comboBox_0.Enabled = false;
			numericUpDownEx_9.Enabled = false;
			numericUpDownEx_8.Enabled = false;
			groupBox_4.Enabled = false;
			break;
		}
		if (DataFiles.GShop.VersionPW >= PW_GSHOP_VERSION.PW_1_5_3)
		{
			dataGridViewEx_2.Rows.Clear();
			uint num = 8u;
			do
			{
				string[] array = new string[2]
				{
					Class16.smethod_0(1648924112),
					null
				};
				string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908635));
				array[1] = text;
				DataGridViewRowCollection rows = dataGridViewEx_2.Rows;
				object[] values = array;
				rows.Add(values);
				num--;
			}
			while (num != 0);
		}
		if (DataFiles.GShop.VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v156)
		{
			numericUpDownEx_13.Enabled = true;
			numericUpDownEx_14.Enabled = true;
			comboBox_1.Enabled = true;
			label_17.Enabled = true;
			label_18.Enabled = true;
		}
		else
		{
			numericUpDownEx_13.Enabled = false;
			numericUpDownEx_14.Enabled = false;
			comboBox_1.Enabled = false;
			label_17.Enabled = false;
			label_18.Enabled = false;
		}
		if (DataFiles.GShop.VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v181)
		{
			numericUpDownEx_17.Enabled = true;
			textBox_10.Enabled = true;
		}
		else
		{
			numericUpDownEx_17.Enabled = false;
			textBox_10.Enabled = false;
		}
		if (DataFiles.GShop.VersionPW >= PW_GSHOP_VERSION.PW_1_6_0)
		{
			numericUpDownEx_16.Enabled = true;
			numericUpDownEx_15.Enabled = true;
		}
		else
		{
			numericUpDownEx_16.Enabled = false;
			numericUpDownEx_15.Enabled = false;
		}
		if (DataFiles.GShop.VersionPW >= PW_GSHOP_VERSION.PW_1_7_6)
		{
			numericUpDownEx_18.Enabled = true;
			numericUpDownEx_21.Enabled = true;
			numericUpDownEx_20.Enabled = true;
			numericUpDownEx_19.Enabled = true;
		}
		else
		{
			numericUpDownEx_18.Enabled = false;
			numericUpDownEx_21.Enabled = false;
			numericUpDownEx_20.Enabled = false;
			numericUpDownEx_19.Enabled = false;
		}
		numericUpDownEx_5.Visible = true;
		numericUpDownEx_5.Enabled = true;
		label_7.Visible = true;
		if ((nint)DataFiles.GShop.Categories.LongLength > 1 && DataFiles.GShop.Categories[1].SubCatsCount > 8)
		{
			bFashionSubCat9Exists = true;
		}
		else
		{
			bFashionSubCat9Exists = false;
		}
		toolStripMenuItem_73.Visible = bFashionSubCat9Exists;
		LoadingComplete = true;
		SelectedCatIndex = -3;
		SelectedSubCatIndex = -3;
		FileName = DataFiles.GShop.FileName;
		method_39();
		if (DataFiles.GShop.ItemsCount < 500)
		{
			method_43(-1);
		}
		else
		{
			int num2 = (int)(DataFiles.GShop.ItemsCount - 1);
			SelectItems(new int[1] { num2 });
		}
		method_38();
		method_34();
		method_55();
		method_92();
	}

	private void dataGridViewEx_0_MouseHover(object sender, EventArgs e)
	{
		if (dataGridViewEx_0.RowCount > 20)
		{
			IntPtr handle = base.Handle;
			if (ACE.RSGlobal.RSGlobal.GetForegroundWindow() == handle && !((Control)sender).Focused)
			{
				((Control)sender).Focus();
			}
		}
		GC.KeepAlive(this);
	}

	private void radioButton_16_MouseDown(object sender, MouseEventArgs e)
	{
		bool_3 = true;
		RadioButton radioButton = (RadioButton)sender;
		int int_ = -1;
		string text = Class16.smethod_0(1649062802);
		if (radioButton.Name != text)
		{
			int startIndex = radioButton.Name.Length - 1;
			int_ = Convert.ToInt32(radioButton.Name.Substring(startIndex));
		}
		method_43(int_);
		bool_3 = false;
	}

	private void radioButton_8_MouseDown(object sender, MouseEventArgs e)
	{
		bool_1 = true;
		RadioButton radioButton = (RadioButton)sender;
		int int_ = -1;
		string text = Class16.smethod_0(1649062450);
		if (radioButton.Name != text)
		{
			int startIndex = radioButton.Name.Length - 1;
			int_ = Convert.ToInt32(radioButton.Name.Substring(startIndex));
		}
		method_44(int_);
		bool_1 = false;
	}

	private void method_42(int int_6, [MarshalAs(UnmanagedType.U1)] bool bool_7)
	{
		if (int_6 == SelectedCatIndex)
		{
			return;
		}
		SelectedCatIndex = int_6;
		RadioButton radioButton;
		switch (int_6)
		{
		default:
		{
			FilterMode = FILTER_MODE.None;
			radioButton_0.Enabled = true;
			string text = Class16.smethod_0(1649060350);
			radioButton = (RadioButton)tableLayoutPanel_0.Controls[text + int_6];
			break;
		}
		case -1:
			FilterMode = FILTER_MODE.None;
			radioButton_0.Enabled = true;
			radioButton = radioButton_9;
			break;
		case -2:
			radioButton = radioButton_18;
			radioButton_0.Enabled = false;
			break;
		}
		int num = 0;
		do
		{
			string text2 = Class16.smethod_0(1649060350);
			RadioButton radioButton2 = (RadioButton)tableLayoutPanel_0.Controls[text2 + num];
			if (radioButton2 != radioButton)
			{
				radioButton2.Checked = false;
			}
			num++;
		}
		while (num < 8);
		radioButton.Checked = true;
		method_40();
		string text3 = Class16.smethod_0(1649062802);
		radioButton_9.Checked = radioButton.Name == text3;
		string text4 = Class16.smethod_0(1648895496);
		radioButton_18.Checked = radioButton.Name == text4;
		if (bool_7 || int_6 < 0)
		{
			SelectedSubCatIndex = -3;
			method_44(-1);
		}
		if (int_6 > -1)
		{
			string text5 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649055251));
			toolStripMenuItem_13.Text = text5;
		}
		else
		{
			string text6 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649055274));
			toolStripMenuItem_13.Text = text6;
		}
		GC.KeepAlive(this);
	}

	private void method_43(int int_6)
	{
		method_42(int_6, bool_7: true);
	}

	private void method_44(int int_6)
	{
		if (int_6 == SelectedSubCatIndex)
		{
			return;
		}
		if (int_6 > 7)
		{
			if (SelectedCatIndex == 1 && int_6 == 8)
			{
				toolStripMenuItem_73_Click(null, null);
			}
			else
			{
				object[] vars = new object[1] { int_6 + 1 };
				TextStorage.TEXTS.ShowMessage(517, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
			}
			GC.KeepAlive(this);
			return;
		}
		RadioButton radioButton = radioButton_0;
		if (int_6 > -1)
		{
			string text = Class16.smethod_0(1649055235);
			radioButton = (RadioButton)tableLayoutPanel_0.Controls[text + int_6];
		}
		string text2 = Class16.smethod_0(1649062450);
		bool flag = radioButton.Name == text2;
		int num = 0;
		do
		{
			string text3 = Class16.smethod_0(1649055235);
			RadioButton radioButton2 = (RadioButton)tableLayoutPanel_0.Controls[text3 + num];
			if (radioButton2 != radioButton)
			{
				radioButton2.Checked = false;
			}
			num++;
		}
		while (num < 8);
		radioButton.Checked = true;
		radioButton_0.Checked = flag;
		SelectedSubCatIndex = int_6;
		method_95();
	}

	private void method_45(int int_6, int int_7)
	{
		method_42(int_6, bool_7: false);
		method_44(int_7);
	}

	private void textBox_2_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && e.KeyCode == Keys.A)
		{
			((TextBox)sender).SelectAll();
			e.Handled = true;
		}
		GC.KeepAlive(this);
	}

	private void textBox_3_TextChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridViewEx_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
					TextBox textBox = textBox_3;
					((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).sIconPath = textBox.Text;
					num++;
				}
				while (num < dataGridViewEx_0.SelectedRows.Count);
			}
			method_11();
			method_34();
		}
		method_29();
	}

	private string method_46(uint uint_0)
	{
		string result = CommonStorage.SecondsToString(uint_0);
		GC.KeepAlive(this);
		return result;
	}

	private void textBox_5_TextChanged(object sender, EventArgs e)
	{
		if (DontChange || DataFiles.GShop == null || DataFiles.GShop.Items == null)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				TextBox textBox = textBox_5;
				((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).Duration = CommonStorage.StringToSeconds(textBox.Text);
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
		if (!DontChange && pwGItem != null)
		{
			DontChange = true;
			numericUpDownEx_4.SetValueSafe(pwGItem.Duration);
			DontChange = false;
		}
	}

	private void numericUpDownEx_4_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		uint num = (uint)(int)numericUpDownEx_4.Value;
		int num2 = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num3 = (int)dataGridViewEx_0.SelectedRows[num2].Tag;
				((GSHOP_ITEM_PW)DataFiles.GShop.Items[num3]).Duration = num;
				num2++;
			}
			while (num2 < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
		DontChange = true;
		textBox_5.Text = method_46(num);
		DontChange = false;
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		object[] vars = new object[1] { 1 };
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649055297), vars);
		textBox_5.Text = text;
		GC.KeepAlive(this);
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		object[] vars = new object[1] { 1 };
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649055320), vars);
		textBox_5.Text = text;
		GC.KeepAlive(this);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		object[] vars = new object[1] { 30 };
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649055351), vars);
		textBox_5.Text = text;
		GC.KeepAlive(this);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648906540));
		textBox_5.Text = text;
		GC.KeepAlive(this);
	}

	private void textBox_5_Leave(object sender, EventArgs e)
	{
		textBox_5.Text = method_46(pwGItem.Duration);
		if (!DontChange && LoadingComplete && pwGItem.Duration != 0)
		{
			decimal num = 1m;
			if (numericUpDownEx_10.Value > num && numericUpDownEx_10.Enabled && TextStorage.TEXTS.ShowQuestionMessage(388) == DialogResult.Yes)
			{
				decimal value = 1m;
				numericUpDownEx_10.SetValueSafe(value);
			}
		}
		GC.KeepAlive(this);
	}

	private void dateTimePicker_1_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				DateTime value = dateTimePicker_1.Value;
				((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).StartDate = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(value);
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				DateTime value = dateTimePicker_0.Value;
				((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).ExpireDate = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(value);
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedIndex < 0)
		{
			return;
		}
		CONTROL_TYPE controlType = (CONTROL_TYPE)(comboBox_0.SelectedIndex - 1);
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridViewEx_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
					((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).ControlType = (int)controlType;
					num++;
				}
				while (num < dataGridViewEx_0.SelectedRows.Count);
			}
			method_11();
			method_34();
		}
		int status = (int)numericUpDownEx_5.Value;
		int control = comboBox_0.SelectedIndex - 1;
		if (!CheckControlTypeAndStatus((CONTROL_TYPE)control, status))
		{
			numericUpDownEx_5.SetValueSafe(0m);
		}
		GC.KeepAlive(this);
	}

	private void numericUpDownEx_9_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				decimal value = numericUpDownEx_9.Value;
				((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).Day = (uint)(int)value;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void numericUpDownEx_8_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				decimal value = numericUpDownEx_8.Value;
				((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).Flags = (uint)(int)value;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void numericUpDownEx_7_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				decimal value = numericUpDownEx_7.Value;
				ref int giftCount = ref ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).GiftCount;
				giftCount = (int)value;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void numericUpDownEx_6_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				decimal value = numericUpDownEx_6.Value;
				ref uint logPrice = ref ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).LogPrice;
				logPrice = (uint)(int)value;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void textBox_7_TextChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				TextBox textBox = textBox_7;
				ref uint giftDuration = ref ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).GiftDuration;
				giftDuration = CommonStorage.StringToSeconds(textBox.Text);
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void textBox_7_Leave(object sender, EventArgs e)
	{
		textBox_7.Text = method_46(pwGItem.GiftDuration);
		GC.KeepAlive(this);
	}

	private void pictureBox_0_MouseMove(object sender, MouseEventArgs e)
	{
		method_47(pwGItem?.ItemInfo, sender, bool_7: false);
	}

	private void pictureBox_2_MouseMove(object sender, MouseEventArgs e)
	{
		method_47(pwGItem?.ItemInfo, sender, bool_7: true);
	}

	private void pictureBox_0_MouseLeave(object sender, EventArgs e)
	{
		method_48();
	}

	private void pictureBox_2_MouseLeave(object sender, EventArgs e)
	{
		method_48();
	}

	private void method_47(ITEMINFO iteminfo_0, object object_0, bool bool_7)
	{
		if (HINTS.ToolTipWindow == null)
		{
			GC.KeepAlive(this);
			return;
		}
		if (bool_7)
		{
			if (pwGItem == null || pwGItem.GiftID == 0)
			{
				GC.KeepAlive(this);
				return;
			}
			ITEMPOS iTEMPOS = eLC.FindItemPos(eLC.MattersLists, pwGItem.GiftID);
			if (iTEMPOS != null && eLC.IsItemExist(iTEMPOS))
			{
				HINTS.ShowElementToolTip(((Control)object_0).Handle, iTEMPOS, IsShopPrice: false, bUnlimited: false, null);
			}
		}
		else if (iteminfo_0 != null && eLC.IsItemExist(iteminfo_0.pos))
		{
			HINTS.ShowElementToolTip(((Control)object_0).Handle, iteminfo_0.pos, IsShopPrice: false, bUnlimited: false, null);
		}
		GC.KeepAlive(this);
	}

	private void method_48()
	{
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void method_49()
	{
		GSHOP_ITEM_PW gSHOP_ITEM_PW = pwGItem;
		uint subCatIndex = gSHOP_ITEM_PW.SubCatIndex;
		uint catIndex = gSHOP_ITEM_PW.CatIndex;
		if (new CategorySelector_PW(CStorage, DataFiles.GShop, (int)catIndex, (int)subCatIndex).ShowDialog(this) == DialogResult.OK)
		{
			if (!DontChange)
			{
				int num = 0;
				if (0 < dataGridViewEx_0.SelectedRows.Count)
				{
					do
					{
						int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
						ref int reference = ref CommonStorage.iarr1[0];
						((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).CatIndex = (uint)reference;
						num++;
					}
					while (num < dataGridViewEx_0.SelectedRows.Count);
				}
				method_11();
				method_34();
			}
			if (!DontChange)
			{
				int num3 = 0;
				if (0 < dataGridViewEx_0.SelectedRows.Count)
				{
					do
					{
						int num4 = (int)dataGridViewEx_0.SelectedRows[num3].Tag;
						ref int reference2 = ref CommonStorage.iarr1[1];
						((GSHOP_ITEM_PW)DataFiles.GShop.Items[num4]).SubCatIndex = (uint)reference2;
						num3++;
					}
					while (num3 < dataGridViewEx_0.SelectedRows.Count);
				}
				method_11();
				method_34();
			}
			int selectedItemIndex = SelectedItemIndex;
			textBox_6.Text = DataFiles.GShop.GetItemCategory(selectedItemIndex);
			method_11();
			method_39();
			if (SelectedCatIndex > -1)
			{
				method_40();
				int[] array = new int[dataGridViewEx_0.SelectedRows.Count];
				int num5 = 0;
				if (0 < (nint)array.LongLength)
				{
					do
					{
						array[num5] = method_37(dataGridViewEx_0.SelectedRows[num5].Index);
						num5++;
					}
					while (num5 < (nint)array.LongLength);
				}
				int num6 = 0;
				if (0 < (nint)array.LongLength)
				{
					do
					{
						bool bool_ = num6 == 0;
						method_16(array[num6], bool_, bool_8: true);
						num6++;
					}
					while (num6 < (nint)array.LongLength);
				}
			}
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UPDATE_REFERENCES, (int)DataFiles.CurrentGShop, 0);
		}
		GC.KeepAlive(this);
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		method_49();
	}

	private void textBox_6_DoubleClick(object sender, EventArgs e)
	{
		method_49();
	}

	private void numericUpDownEx_10_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				if (eLC.IsItemExist(items[num2].ItemInfo))
				{
					decimal value = numericUpDownEx_10.Value;
					string fieldUName = Class16.smethod_0(1648955717);
					ITEMPOS pos = DataFiles.GShop.Items[num2].ItemInfo.pos;
					eLC.SetValue(pos, fieldUName, value.ToString());
					ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_CURRENT_ITEM, 0, 0);
					ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_UNDO_REDO, 0, 0);
				}
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_5();
		ACE.RSGlobal.RSGlobal.replaced = true;
	}

	private void numericUpDownEx_12_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				if (eLC.IsItemExist(items[num2].ItemInfo))
				{
					decimal value = numericUpDownEx_12.Value;
					string fieldUName = Class16.smethod_0(1648970148);
					ITEMPOS pos = DataFiles.GShop.Items[num2].ItemInfo.pos;
					eLC.SetValue(pos, fieldUName, value.ToString());
					UpdatePropsInElements(bOnlyRecalculate: true);
					ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_CURRENT_ITEM, 0, 0);
					ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_UNDO_REDO, 0, 0);
				}
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		ACE.RSGlobal.RSGlobal.replaced = true;
		GC.KeepAlive(this);
	}

	private void numericUpDownEx_11_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				if (eLC.IsItemExist(items[num2].ItemInfo))
				{
					decimal value = numericUpDownEx_11.Value;
					string fieldUName = Class16.smethod_0(1648965136);
					ITEMPOS pos = DataFiles.GShop.Items[num2].ItemInfo.pos;
					eLC.SetValue(pos, fieldUName, value.ToString());
					UpdatePropsInElements(bOnlyRecalculate: true);
					ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_CURRENT_ITEM, 0, 0);
					ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_UNDO_REDO, 0, 0);
				}
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		ACE.RSGlobal.RSGlobal.replaced = true;
		GC.KeepAlive(this);
	}

	private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		object[] vars = new object[1] { e.ProgressPercentage };
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649055374), vars);
		toolStripMenuItem_66.Text = text;
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_6_Click(object sender, EventArgs e)
	{
		textBox_0.Focus();
		textBox_0.SelectAll();
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_19_Click(object sender, EventArgs e)
	{
		method_49();
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		method_50();
	}

	private void method_50()
	{
		int num = -1;
		List<int> list = new List<int>();
		int num2 = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num3 = (int)dataGridViewEx_0.SelectedRows[num2].Tag;
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				if (eLC.IsItemExist(items[num3].ItemInfo))
				{
					if (num == -1)
					{
						num = DataFiles.GShop.Items[num3].ItemInfo.pos.int_0;
					}
					int item = DataFiles.GShop.Items[num3].ItemInfo.pos.int_1;
					if (DataFiles.GShop.Items[num3].ItemInfo.pos.int_0 == num && !list.Contains(item))
					{
						list.Add(item);
					}
				}
				num2++;
			}
			while (num2 < dataGridViewEx_0.SelectedRows.Count);
		}
		int[] array = list.ToArray();
		Array.Sort(array);
		if (list.Count != 0)
		{
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_LIST, num, 0);
			IntPtr objectPointer = ACE.RSGlobal.RSGlobal.GetObjectPointer(array);
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_ITEMS, array.Length, objectPointer);
		}
		else
		{
			TextStorage.TEXTS.ShowErrorMessage(257);
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_20_Click(object sender, EventArgs e)
	{
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				if (eLC.IsItemExist(items[num2].ItemInfo))
				{
					GSHOP_ITEM[] items2 = DataFiles.GShop.Items;
					method_51(items2[num2], bool_7: false);
				}
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		bool flag = !DontChange;
		DontChange = true;
		textBox_1.Text = pwGItem.sName;
		if (flag)
		{
			DontChange = false;
		}
		method_11();
		method_5();
	}

	private void method_51(GSHOP_ITEM gshop_ITEM_0, [MarshalAs(UnmanagedType.U1)] bool bool_7)
	{
		string text = gshop_ITEM_0.ItemInfo.name;
		if (bool_7)
		{
			int count = gshop_ITEM_0.Count;
			if (count > 1)
			{
				int num = count;
				if (text.Length + num.ToString().Length + 3 <= 32)
				{
					string text2 = Class16.smethod_0(1648942897);
					text = string.Concat(text, string.Concat(Class16.smethod_0(1648899468) + gshop_ITEM_0.Count, text2));
				}
			}
		}
		gshop_ITEM_0.sName = text;
		GC.KeepAlive(this);
	}

	private void method_52(GSHOP_ITEM gshop_ITEM_0)
	{
		eListCollection eListCollection2 = eLC;
		ITEM_EXT_DESC descriptions = eListCollection2.Descriptions;
		if (descriptions != null && descriptions.Descriptions != null)
		{
			if (eListCollection2.IsDescExist(gshop_ITEM_0.ItemInfo.id))
			{
				string sDescription = eLC.Descriptions.Descriptions[gshop_ITEM_0.ItemInfo.id];
				((GSHOP_ITEM_PW)gshop_ITEM_0).sDescription = sDescription;
			}
		}
		else
		{
			TextStorage.TEXTS.ShowErrorMessage(247);
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_10_Click(object sender, EventArgs e)
	{
		method_55();
	}

	private void method_53()
	{
		Profile.DefaultSection = Class16.smethod_0(1649055397);
		object value = (int)base.WindowState;
		SettingsClass profile = Profile;
		profile.SaveSetting(profile.DefaultSection, Class16.smethod_0(1649055415), value);
		object value2 = base.Left;
		SettingsClass profile2 = Profile;
		profile2.SaveSetting(profile2.DefaultSection, Class16.smethod_0(1649055425), value2);
		object value3 = base.Top;
		SettingsClass profile3 = Profile;
		profile3.SaveSetting(profile3.DefaultSection, Class16.smethod_0(1649055444), value3);
		object value4 = base.Width;
		SettingsClass profile4 = Profile;
		profile4.SaveSetting(profile4.DefaultSection, Class16.smethod_0(1649055454), value4);
		object value5 = base.Height;
		SettingsClass profile5 = Profile;
		profile5.SaveSetting(profile5.DefaultSection, Class16.smethod_0(1649055458), value5);
		object value6 = toolStripMenuItem_10.Checked;
		SettingsClass profile6 = Profile;
		profile6.SaveSetting(profile6.DefaultSection, Class16.smethod_0(1649070068), value6);
		object value7 = toolStripMenuItem_35.Checked;
		SettingsClass profile7 = Profile;
		profile7.SaveSetting(profile7.DefaultSection, Class16.smethod_0(1649069149), value7);
		object value8 = toolStripMenuItem_22.Checked;
		SettingsClass profile8 = Profile;
		profile8.SaveSetting(profile8.DefaultSection, Class16.smethod_0(1649068923), value8);
		object value9 = toolStripMenuItem_23.Checked;
		SettingsClass profile9 = Profile;
		profile9.SaveSetting(profile9.DefaultSection, Class16.smethod_0(1649069005), value9);
		object value10 = toolStripMenuItem_34.Checked;
		SettingsClass profile10 = Profile;
		profile10.SaveSetting(profile10.DefaultSection, Class16.smethod_0(1649068069), value10);
		object value11 = toolStripMenuItem_38.Checked;
		SettingsClass profile11 = Profile;
		profile11.SaveSetting(profile11.DefaultSection, Class16.smethod_0(1649068174), value11);
		Profile.DefaultSection = Class16.smethod_0(1648898876);
	}

	private void method_54()
	{
		Profile.DefaultSection = Class16.smethod_0(1649055397);
		string setting = Profile.GetSetting(Class16.smethod_0(1649055415));
		if (setting == Class16.smethod_0(1648924112) || setting == Class16.smethod_0(1648934967))
		{
			base.WindowState = (FormWindowState)Convert.ToInt32(setting);
		}
		if (setting == Class16.smethod_0(1648924112))
		{
			SettingsClass profile = Profile;
			base.Left = profile.GetSetting(Class16.smethod_0(1649055425), base.Left, 0, 1000);
			SettingsClass profile2 = Profile;
			base.Top = profile2.GetSetting(Class16.smethod_0(1649055444), base.Top, 0, 500);
			Size minimumSize = MinimumSize;
			SettingsClass profile3 = Profile;
			base.Width = profile3.GetSetting(Class16.smethod_0(1649055454), base.Width, minimumSize.Width, 5000);
			Size minimumSize2 = MinimumSize;
			SettingsClass profile4 = Profile;
			base.Height = profile4.GetSetting(Class16.smethod_0(1649055458), base.Height, minimumSize2.Height, 5000);
		}
		toolStripMenuItem_10.Checked = Profile.GetSetting(Class16.smethod_0(1649070068), Default: true);
		toolStripMenuItem_35.Checked = Profile.GetSetting(Class16.smethod_0(1649069149), Default: false);
		toolStripMenuItem_22.Checked = Profile.GetSetting(Class16.smethod_0(1649068923), Default: true);
		toolStripMenuItem_23.Checked = Profile.GetSetting(Class16.smethod_0(1649069005), Default: true);
		toolStripMenuItem_34.Checked = Profile.GetSetting(Class16.smethod_0(1649068069), Default: true);
		toolStripMenuItem_38.Checked = Profile.GetSetting(Class16.smethod_0(1649068174), Default: false);
		toolStripMenuItem_81.Checked = CommonStorage.AParams.ShowItemAmountInGshop;
		SetSaleOption((int)CommonStorage.AParams.CurrentGShopSaleOption);
		Profile.DefaultSection = Class16.smethod_0(1648898876);
	}

	private void method_55()
	{
		groupBox_3.Visible = toolStripMenuItem_10.Checked;
		groupBox_4.Visible = toolStripMenuItem_10.Checked;
		int num = ((!toolStripMenuItem_10.Checked) ? groupBox_6.Top : groupBox_3.Top) - groupBox_2.Top - 3;
		groupBox_2.Height = num;
		int num3;
		if (toolStripMenuItem_10.Checked && DataFiles.GShop.VersionPW >= PW_GSHOP_VERSION.PW_1_5_3)
		{
			int num2 = -3 - groupBox_7.Width;
			num3 = groupBox_4.Width + num2;
		}
		else
		{
			num3 = groupBox_4.Width;
		}
		groupBox_2.Width = num3;
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_24_Click(object sender, EventArgs e)
	{
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				if (eLC.IsItemExist(items[num2].ItemInfo))
				{
					GSHOP_ITEM[] items2 = DataFiles.GShop.Items;
					method_52(items2[num2]);
				}
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		bool flag = !DontChange;
		DontChange = true;
		textBox_2.Text = ACE.RSGlobal.RSGlobal.rn2CrLF(pwGItem.sDescription);
		if (flag)
		{
			DontChange = false;
		}
		method_11();
	}

	private void toolStripMenuItem_25_Click(object sender, EventArgs e)
	{
		method_56();
	}

	public void SelectItemsByID(List<int> IDs)
	{
		List<int> list = new List<int>();
		List<int>.Enumerator enumerator = IDs.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				int current = enumerator.Current;
				int num = 0;
				if (0 >= (nint)DataFiles.GShop.Items.LongLength)
				{
					continue;
				}
				do
				{
					if (DataFiles.GShop.Items[num].ItemID == current)
					{
						list.Add(num);
					}
					num++;
				}
				while (num < (nint)DataFiles.GShop.Items.LongLength);
			}
			while (enumerator.MoveNext());
		}
		if (list.Count != 0)
		{
			SelectItems(list.ToArray());
		}
		else
		{
			TextStorage.TEXTS.ShowMessage(257, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		}
		GC.KeepAlive(this);
	}

	public void SelectItems(int[] ItemsIndices)
	{
		bool bool_ = true;
		int num = ItemsIndices[0];
		if (num >= (nint)DataFiles.GShop.Items.LongLength)
		{
			GC.KeepAlive(this);
			return;
		}
		int catIndex = (int)((GSHOP_ITEM_PW)DataFiles.GShop.Items[num]).CatIndex;
		int subCatIndex = (int)((GSHOP_ITEM_PW)DataFiles.GShop.Items[num]).SubCatIndex;
		int num2 = 0;
		if (0 < (nint)ItemsIndices.LongLength)
		{
			while (true)
			{
				int num3 = ItemsIndices[num2];
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				if (catIndex == (int)((GSHOP_ITEM_PW)items[num3]).CatIndex)
				{
					GSHOP_ITEM[] items2 = DataFiles.GShop.Items;
					if (subCatIndex == (int)((GSHOP_ITEM_PW)items2[num3]).SubCatIndex)
					{
						num2++;
						if (num2 >= (nint)ItemsIndices.LongLength)
						{
							break;
						}
						continue;
					}
				}
				bool_ = false;
				method_43(-1);
				break;
			}
		}
		int num4 = 0;
		if (0 < (nint)ItemsIndices.LongLength)
		{
			do
			{
				bool bool_2 = num4 == 0;
				method_16(ItemsIndices[num4], bool_2, bool_);
				num4++;
			}
			while (num4 < (nint)ItemsIndices.LongLength);
		}
	}

	public void SelectItems(int int_6, int[] indices)
	{
		List<int> list = new List<int>();
		bool flag;
		int num = ((flag = eLC.Lists[int_6].uListName == Class16.smethod_0(1648955681)) ? eLC.findex(int_6, Class16.smethod_0(1648951885)) : (-1));
		int num2 = 0;
		if (0 < (nint)indices.LongLength)
		{
			do
			{
				List<int> list2 = new List<int>();
				if (!flag || num < 0)
				{
					list2.Add(eLC.getid(int_6, indices[num2]));
				}
				else
				{
					for (int i = 0; i < 6; i++)
					{
						int num3 = Convert.ToInt32(eLC.Lists[int_6].elementValues[indices[num2]][num + i]);
						if (num3 > 0)
						{
							list2.Add(num3);
						}
					}
				}
				foreach (int item in list2)
				{
					int num4 = 0;
					if (0 >= (nint)DataFiles.GShop.Items.LongLength)
					{
						continue;
					}
					do
					{
						if (DataFiles.GShop.Items[num4].ItemID == item)
						{
							list.Add(num4);
						}
						num4++;
					}
					while (num4 < (nint)DataFiles.GShop.Items.LongLength);
				}
				num2++;
			}
			while (num2 < (nint)indices.LongLength);
		}
		if (list.Count != 0)
		{
			SelectItems(list.ToArray());
		}
		else
		{
			TextStorage.TEXTS.ShowMessage(257, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		}
		GC.KeepAlive(this);
	}

	private void method_56()
	{
		if (ItemsWindow1 == null || ItemsWindow1.IsDisposed || ItemsWindow1.Disposing || eLC == null)
		{
			return;
		}
		ItemsWindow1.newlistsindices = eLC.MattersLists;
		ItemsWindow1.bMultiSelect = true;
		CStorage.ResetBuffer();
		if (method_3(out var dialogResult_) && dialogResult_ == DialogResult.OK && CommonStorage.sarr1 != null)
		{
			if (ItemsWindow1.itemlist < 0 || eLC.Lists == null || ItemsWindow1.itemlist >= eLC.Lists.Length || eLC.Lists[ItemsWindow1.itemlist] == null)
			{
				return;
			}
			eList eList2 = eLC.Lists[ItemsWindow1.itemlist];
			string text = Class16.smethod_0(1649078890);
			string uListName = eList2.uListName;
			AddFromElements(ACE.RSGlobal.RSGlobal.StringArray2IntArray(CommonStorage.sarr1), uListName == text);
		}
		GC.KeepAlive(this);
	}

	public void AddFromElements(int[] ids, [MarshalAs(UnmanagedType.U1)] bool IsFashion)
	{
		if (DataFiles.GShop.Items == null)
		{
			GC.KeepAlive(this);
		}
		else if (ids != null && ids.Length != 0)
		{
			FilterMode = FILTER_MODE.None;
			if (DataFiles.GShop.VersionPW < PW_GSHOP_VERSION.PW_1_4_2_v27)
			{
				string text = Class16.smethod_0(1649055479);
				IsFashion = !(DataFiles.GShop.Categories[1].name != text) && IsFashion;
			}
			IsFashion = toolStripMenuItem_38.Checked && IsFashion;
			if (SelectedSubCatIndex > -1)
			{
				int selectedCatIndex = SelectedCatIndex;
				Category[] categories = DataFiles.GShop.Categories;
				if ((uint)SelectedSubCatIndex >= categories[selectedCatIndex].SubCatsCount)
				{
					string subCatName = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071255));
					int selectedSubCatIndex = SelectedSubCatIndex;
					selectedCatIndex = SelectedCatIndex;
					DataFiles.GShop.Categories[selectedCatIndex].AddSubCat(selectedSubCatIndex, subCatName);
					method_40();
				}
			}
			else
			{
				int selectedCatIndex2 = SelectedCatIndex;
				if (selectedCatIndex2 > -1 && DataFiles.GShop.Categories[selectedCatIndex2].SubCatsCount == 0)
				{
					string subCatName2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071255));
					selectedCatIndex2 = SelectedCatIndex;
					DataFiles.GShop.Categories[selectedCatIndex2].AddSubCat(0, subCatName2);
					method_40();
				}
			}
			if (IsFashion)
			{
				int selectedCatIndex3 = SelectedCatIndex;
				if (selectedCatIndex3 != -1 && (selectedCatIndex3 != 1 || SelectedSubCatIndex != -1))
				{
					SelectedCatIndex = -3;
					method_43(1);
				}
			}
			int num = 0;
			if (0 < (nint)ids.LongLength)
			{
				do
				{
					int itemID = ids[num];
					DataFiles.GShop.AddNewItem(itemID);
					int id = ids[num];
					eListCollection eListCollection2 = eLC;
					int[] mattersLists = eListCollection2.MattersLists;
					eListCollection eListCollection3 = eListCollection2;
					ITEMPOS itemPos = eListCollection3.FindItemPos(mattersLists, id);
					ITEMINFO itemInfo = eListCollection3.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
					int num2 = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
					DataFiles.GShop.Items[num2].ItemInfo = itemInfo;
					int num3 = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
					ref ITEMINFO itemInfo2 = ref DataFiles.GShop.Items[num3].ItemInfo;
					if (itemInfo2 != null)
					{
						int num4 = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
						GSHOP_ITEM[] items = DataFiles.GShop.Items;
						method_51(items[num4], bool_7: true);
						int num5 = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
						GSHOP_ITEM[] items2 = DataFiles.GShop.Items;
						method_52(items2[num5]);
					}
					int num6 = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
					GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)DataFiles.GShop.Items[num6];
					if (IsFashion && itemInfo2 != null)
					{
						gSHOP_ITEM_PW.CatIndex = 1u;
						ref ITEMPOS pos = ref itemInfo2.pos;
						int valueI = eLC.GetValueI(pos, Class16.smethod_0(1649055483));
						int valueI2 = eLC.GetValueI(pos, Class16.smethod_0(1648956046));
						switch (valueI)
						{
						default:
						{
							int selectedCatIndex5 = SelectedCatIndex;
							if (selectedCatIndex5 > -1)
							{
								gSHOP_ITEM_PW.CatIndex = (uint)selectedCatIndex5;
								int selectedSubCatIndex2 = SelectedSubCatIndex;
								if (selectedSubCatIndex2 > -1)
								{
									gSHOP_ITEM_PW.SubCatIndex = (uint)selectedSubCatIndex2;
								}
							}
							break;
						}
						case 1:
							if (valueI2 == 0)
							{
								gSHOP_ITEM_PW.SubCatIndex = 0u;
							}
							else
							{
								gSHOP_ITEM_PW.SubCatIndex = 3u;
							}
							break;
						case 2:
							gSHOP_ITEM_PW.SubCatIndex = 4u;
							break;
						case 3:
							if (valueI2 == 0)
							{
								gSHOP_ITEM_PW.SubCatIndex = 1u;
							}
							else
							{
								gSHOP_ITEM_PW.SubCatIndex = 5u;
							}
							break;
						case 4:
							if (valueI2 == 0)
							{
								gSHOP_ITEM_PW.SubCatIndex = 2u;
							}
							else
							{
								gSHOP_ITEM_PW.SubCatIndex = 6u;
							}
							break;
						case 5:
						case 7:
							gSHOP_ITEM_PW.SubCatIndex = 5u;
							break;
						case 6:
						case 8:
							if (valueI2 == 0)
							{
								gSHOP_ITEM_PW.SubCatIndex = 0u;
							}
							else
							{
								gSHOP_ITEM_PW.SubCatIndex = 5u;
							}
							break;
						case 9:
							gSHOP_ITEM_PW.SubCatIndex = 7u;
							break;
						case 10:
						{
							if (bFashionSubCat9Exists)
							{
								gSHOP_ITEM_PW.SubCatIndex = 8u;
								break;
							}
							int selectedCatIndex4 = SelectedCatIndex;
							if (selectedCatIndex4 < 0 || selectedCatIndex4 == 0 || selectedCatIndex4 == 1)
							{
								gSHOP_ITEM_PW.CatIndex = 0u;
								gSHOP_ITEM_PW.SubCatIndex = 6u;
							}
							break;
						}
						}
					}
					else
					{
						int selectedCatIndex6 = SelectedCatIndex;
						if (selectedCatIndex6 > -1)
						{
							gSHOP_ITEM_PW.CatIndex = (uint)selectedCatIndex6;
							int selectedSubCatIndex3 = SelectedSubCatIndex;
							if (selectedSubCatIndex3 > -1)
							{
								gSHOP_ITEM_PW.SubCatIndex = (uint)selectedSubCatIndex3;
							}
						}
					}
					DataGridViewRow dataGridViewRow = method_97((int)((nint)DataFiles.GShop.Items.LongLength - 1), bool_7: false);
					if (dataGridViewRow != null)
					{
						dataGridViewEx_0.Rows.Add(dataGridViewRow);
					}
					num++;
				}
				while (num < (nint)ids.LongLength);
			}
			bool flag = !DontChange;
			DontChange = true;
			dataGridViewEx_0.ClearSelection();
			int num7 = dataGridViewEx_0.RowCount - 1;
			int num8 = Struct59.int_1;
			if (num7 >= 0 && num8 >= 0 && num8 < dataGridViewEx_0.ColumnCount)
			{
				dataGridViewEx_0.CurrentCell = dataGridViewEx_0[num8, num7];
				for (int i = Math.Max(0, dataGridViewEx_0.RowCount - ids.Length); i < dataGridViewEx_0.RowCount; i++)
				{
					dataGridViewEx_0.Rows[i].Selected = true;
				}
			}
			if (flag)
			{
				DontChange = false;
				dataGridViewEx_0_SelectionChanged(null, EventArgs.Empty);
			}
			method_11();
			if (SelectedSubCatIndex < 0 && !IsFashion)
			{
				method_49();
			}
			method_40();
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UPDATE_REFERENCES, (int)DataFiles.CurrentGShop, 0);
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	public void AddFromElements(int int_6, int[] ItemIndices)
	{
		eList eList2 = eLC.Lists[int_6];
		if (eList2.uListName == Class16.smethod_0(1648955681))
		{
			int num = eLC.get_LI(Class16.smethod_0(1649078890));
			if (num < 0)
			{
				return;
			}
			List<int> list = new List<int>();
			int num2 = eLC.findex(int_6, Class16.smethod_0(1648951885));
			if (num2 < 0)
			{
				return;
			}
			for (int i = 0; i < (nint)ItemIndices.LongLength; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					int num3 = Convert.ToInt32(eLC.Lists[int_6].elementValues[ItemIndices[i]][num2 + j]);
					if (num3 > 0 && !list.Contains(num3))
					{
						list.Add(num3);
					}
				}
			}
			if (list.Count > 0)
			{
				AddFromElements(list.ToArray(), IsFashion: true);
			}
			GC.KeepAlive(this);
			return;
		}
		int[] array = new int[(nint)ItemIndices.LongLength];
		int num4 = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				array[num4] = eLC.getid(int_6, ItemIndices[num4]);
				num4++;
			}
			while (num4 < (nint)array.LongLength);
		}
		AddFromElements(array, eList2.uListName == Class16.smethod_0(1649078890));
		GC.KeepAlive(this);
	}

	private void button_11_Click(object sender, EventArgs e)
	{
		method_56();
	}

	private void button_12_Click(object sender, EventArgs e)
	{
		RefreshAllItems();
	}

	public void RefreshAllItems()
	{
		method_95();
	}

	private void toolStripMenuItem_26_Click(object sender, EventArgs e)
	{
		string[] array = new string[dataGridViewEx_0.SelectedRows.Count];
		int[] array2 = method_68();
		int num = 0;
		if (0 < (nint)array2.LongLength)
		{
			do
			{
				int num2 = array2[num];
				array[num] = ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).Price.ToString();
				num++;
			}
			while (num < (nint)array2.LongLength);
		}
		CommonStorage.sarr1 = array;
		ChangeValuesWindow changeValuesWindow = new ChangeValuesWindow(array[0], CStorage, IsFloat: true, IsInt: false);
		try
		{
			if (changeValuesWindow.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
		}
		finally
		{
			((IDisposable)changeValuesWindow).Dispose();
		}
		string[] sarr = CommonStorage.sarr1;
		int num3 = 0;
		if (0 < (nint)array2.LongLength)
		{
			do
			{
				string value = sarr[num3];
				int num4 = array2[num3];
				((GSHOP_ITEM_PW)DataFiles.GShop.Items[num4]).Price = Convert.ToDouble(value);
				num3++;
			}
			while (num3 < (nint)array2.LongLength);
		}
		method_5();
		bool flag = !DontChange;
		DontChange = true;
		decimal value2 = (decimal)pwGItem.Price;
		numericUpDownEx_1.SetValueSafe(value2);
		if (flag)
		{
			DontChange = false;
		}
		method_11();
	}

	private void toolStripMenuItem_35_Click(object sender, EventArgs e)
	{
		method_57();
	}

	private void method_57()
	{
		dataGridViewTextBoxColumn_12.Visible = toolStripMenuItem_35.Checked;
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_36_Click(object sender, EventArgs e)
	{
		if (dataGridViewEx_0.SelectedRows.Count > 0)
		{
			method_18((int)dataGridViewEx_0.SelectedRows[0].Tag);
		}
		GC.KeepAlive(this);
	}

	private void button_13_Click(object sender, EventArgs e)
	{
		if (dataGridViewEx_0.SelectedRows.Count > 0)
		{
			method_18((int)dataGridViewEx_0.SelectedRows[0].Tag);
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		string fn_sev = null;
		if (!CommonStorage.AParams.SaveGshopSevIntoCurrentDir)
		{
			string fileBaseName = ACE.RSGlobal.RSGlobal.GetFileBaseName(DataFiles.GShop.FileName);
			string text = fileBaseName.Substring(fileBaseName.Length - 1);
			if (text == Class16.smethod_0(1648934925))
			{
				fn_sev = CommonStorage.Params.GShopSev1Path;
			}
			else if (text == Class16.smethod_0(1648934967))
			{
				fn_sev = CommonStorage.Params.GShopSev2Path;
			}
			else if (text == Class16.smethod_0(1648911557))
			{
				fn_sev = CommonStorage.Params.GShopSev3Path;
			}
		}
		fn_sev = DataFiles.GShop.SaveToSev(fn_sev);
		object[] vars = new object[1] { fn_sev };
		string message = TextStorage.TEXTS.GetText(Class16.smethod_0(1649055504), vars);
		ShowBackgroundMessage(message);
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void toolStripMenuItem_28_Click(object sender, EventArgs e)
	{
		dictionary_0.Clear();
		method_94(FILTER_MODE.NotFoundedItems);
	}

	private void toolStripMenuItem_29_Click(object sender, EventArgs e)
	{
		method_94(FILTER_MODE.WithCount0);
	}

	private void toolStripMenuItem_30_Click(object sender, EventArgs e)
	{
		if (bSurfacesLoaded)
		{
			method_94(FILTER_MODE.NotFoundedIcons);
		}
		else if (TextStorage.TEXTS.ShowQuestionMessage(280) == DialogResult.Yes)
		{
			toolStripMenuItem_66_Click(null, null);
		}
	}

	private void toolStripMenuItem_31_Click(object sender, EventArgs e)
	{
		method_94(FILTER_MODE.WithVeryLongName);
	}

	private void toolStripMenuItem_32_Click(object sender, EventArgs e)
	{
		method_94(FILTER_MODE.WithFullDescription);
	}

	private void toolStripMenuItem_33_Click(object sender, EventArgs e)
	{
		dictionary_0.Clear();
		method_94(FILTER_MODE.WithBuggedPileNum);
	}

	private void method_58(object sender, EventArgs e)
	{
		object[] vars = new object[1] { Class16.smethod_0(1649055535) };
		TextStorage.TEXTS.ShowMessage(265, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
		GC.KeepAlive(this);
	}

	private void radioButton_18_Click(object sender, EventArgs e)
	{
		if (!radioButton_18.Checked)
		{
			textBox_0.Focus();
			textBox_0.SelectAll();
			method_15();
		}
	}

	private void toolStripMenuItem_37_Click(object sender, EventArgs e)
	{
		method_59();
	}

	private void method_59()
	{
		List<string> list = null;
		if (DataFiles.GShop.Items == null)
		{
			GC.KeepAlive(this);
			return;
		}
		List<string> list2 = new List<string>();
		int num = 0;
		if (0 < (nint)DataFiles.GShop.Items.LongLength)
		{
			do
			{
				list = new List<string>();
				GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)DataFiles.GShop.Items[num];
				if (!method_74(gSHOP_ITEM_PW, ref list))
				{
					list.Add(Class16.smethod_0(1649055537) + gSHOP_ITEM_PW.ItemID);
					DataFiles.GShop.DeleteItem(num);
					num--;
				}
				if (list.Count > 0)
				{
					int num2 = num;
					string separator = Class16.smethod_0(1648986192);
					string text = Class16.smethod_0(1648908709);
					list2.Add(string.Concat(string.Concat(Class16.smethod_0(1649055567) + num2, text), string.Join(separator, list)));
				}
				num++;
			}
			while (num < (nint)DataFiles.GShop.Items.LongLength);
		}
		method_11();
		SelectedCatIndex = -3;
		method_43(-1);
		object[] vars = new object[1] { list2.Count };
		if (TextStorage.TEXTS.ShowMessage(266, MessageBoxButtons.YesNo, MessageBoxIcon.Question, vars) == DialogResult.Yes)
		{
			string text2 = Class16.smethod_0(1649055571);
			string text3 = System.IO.Path.GetTempPath() + text2;
			FileStream fileStream = File.Create(text3);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
			streamWriter.Write(string.Join(Class16.smethod_0(1648924428), list2));
			streamWriter.Close();
			fileStream.Close();
			if (File.Exists(text3))
			{
				string text4 = Class16.smethod_0(1648904453);
				string arguments = string.Concat(text4 + text3, text4);
				ACE.RSGlobal.RSGlobal.ShellP(Class16.smethod_0(1648971820), arguments, waitForExit: false);
			}
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_39_Click(object sender, EventArgs e)
	{
		method_60(10);
	}

	private void toolStripMenuItem_40_Click(object sender, EventArgs e)
	{
		method_60(20);
	}

	private void toolStripMenuItem_41_Click(object sender, EventArgs e)
	{
		method_60(30);
	}

	private void toolStripMenuItem_42_Click(object sender, EventArgs e)
	{
		method_60(50);
	}

	private void toolStripMenuItem_43_Click(object sender, EventArgs e)
	{
		method_60(90);
	}

	private void method_60(int int_6)
	{
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			double num2 = 1.0 - (double)int_6 / 100.0;
			do
			{
				int num3 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)DataFiles.GShop.Items[num3];
				double num4 = gSHOP_ITEM_PW.Price * num2;
				if (Math.Abs(gSHOP_ITEM_PW.Price - num4) > 0.01)
				{
					gSHOP_ITEM_PW.Price = num4;
					if (DataFiles.GShop.VersionPW >= PW_GSHOP_VERSION.PW_1_7_6)
					{
						switch (int_6)
						{
						case 20:
							gSHOP_ITEM_PW.Status = 32u;
							break;
						case 10:
							gSHOP_ITEM_PW.Status = 16u;
							break;
						default:
							gSHOP_ITEM_PW.Status = 16u;
							break;
						case 90:
							gSHOP_ITEM_PW.Status = 2048u;
							break;
						case 50:
							gSHOP_ITEM_PW.Status = 256u;
							break;
						case 30:
							gSHOP_ITEM_PW.Status = 64u;
							break;
						}
					}
					else
					{
						switch (int_6)
						{
						default:
							gSHOP_ITEM_PW.Status = 4u;
							break;
						case 10:
						case 20:
						case 30:
						case 50:
						case 90:
							gSHOP_ITEM_PW.Status = 4u;
							break;
						}
					}
				}
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		bool flag = !DontChange;
		DontChange = true;
		decimal value = (decimal)pwGItem.Price;
		numericUpDownEx_1.SetValueSafe(value);
		numericUpDownEx_5.SetValueSafe(pwGItem.Status);
		method_64();
		if (flag)
		{
			DontChange = false;
		}
		method_5();
		method_11();
	}

	private void toolStripMenuItem_44_Click(object sender, EventArgs e)
	{
		method_59();
	}

	private void toolStripMenuItem_11_Click(object sender, EventArgs e)
	{
		method_61();
	}

	private void toolStripMenuItem_12_Click(object sender, EventArgs e)
	{
		method_61();
	}

	private void toolStripMenuItem_13_Click(object sender, EventArgs e)
	{
		method_62();
	}

	private void method_61()
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		int[] array = new int[dataGridViewEx_0.SelectedRows.Count];
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				array[num] = num2;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		Array.Sort(array);
		if ((nint)array.LongLength == 1)
		{
			object[] vars = new object[1] { array[0] };
			string fileName = TextStorage.TEXTS.GetText(Class16.smethod_0(1649067153), vars);
			saveFileDialog.FileName = fileName;
		}
		else
		{
			object[] array2 = new object[2]
			{
				array[0],
				null
			};
			array2[1] = array[(nint)array.LongLength - 1];
			string fileName2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649067176), array2);
			saveFileDialog.FileName = fileName2;
		}
		saveFileDialog.Filter = Class16.smethod_0(1649067207);
		if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			string empty = string.Empty;
			if (saveFileDialog.FileName != empty)
			{
				EditorSessionTracker.LogFolderAccess(saveFileDialog.FileName, Class16.smethod_0(1649006856), Class16.smethod_0(1648906382));
				FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
				BinaryWriter binaryWriter = new BinaryWriter(fileStream);
				binaryWriter.Write(2);
				binaryWriter.Write((int)DataFiles.GShop.Game);
				binaryWriter.Write((int)DataFiles.GShop.VersionPW);
				binaryWriter.Write(array.Length);
				int num3 = 0;
				if (0 < (nint)array.LongLength)
				{
					do
					{
						int num4 = array[num3];
						PW_GSHOP_VERSION versionPW = DataFiles.GShop.VersionPW;
						GSHOP_ITEM[] items = DataFiles.GShop.Items;
						GSHOP.WriteItem_PW(binaryWriter, (GSHOP_ITEM_PW)items[num4], versionPW);
						num3++;
					}
					while (num3 < (nint)array.LongLength);
				}
				binaryWriter.Close();
				fileStream.Close();
				TextStorage.TEXTS.ShowMessage(271, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			}
		}
		GC.KeepAlive(this);
	}

	private void method_62()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649067251);
		if (openFileDialog.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			FilterMode = FILTER_MODE.None;
			GSHOP gSHOP = new GSHOP(openFileDialog.FileName);
			ref GAMES game = ref DataFiles.GShop.Game;
			GAMES game2 = gSHOP.Game;
			if (game2 != game)
			{
				object[] vars = new object[1] { ACE.RSGlobal.RSGlobal.GetGamePrefix(game2) };
				TextStorage.TEXTS.ShowMessage(481, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
				GC.KeepAlive(this);
				return;
			}
			uint num = 0u;
			if (0 < gSHOP.ItemsCount)
			{
				do
				{
					GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)gSHOP.Items[num];
					int selectedCatIndex = SelectedCatIndex;
					if (selectedCatIndex > -1)
					{
						gSHOP_ITEM_PW.CatIndex = (uint)selectedCatIndex;
						int selectedSubCatIndex = SelectedSubCatIndex;
						if (selectedSubCatIndex > -1)
						{
							gSHOP_ITEM_PW.SubCatIndex = (uint)selectedSubCatIndex;
						}
						else
						{
							Category[] categories = DataFiles.GShop.Categories;
							if (gSHOP_ITEM_PW.SubCatIndex >= categories[selectedCatIndex].SubCatsCount)
							{
								string subCatName = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071255));
								uint subCatIndex = gSHOP_ITEM_PW.SubCatIndex;
								uint catIndex = gSHOP_ITEM_PW.CatIndex;
								DataFiles.GShop.Categories[catIndex].AddSubCat((int)subCatIndex, subCatName);
							}
						}
					}
					else
					{
						if (gSHOP_ITEM_PW.CatIndex > 8)
						{
							gSHOP_ITEM_PW.CatIndex = 0u;
						}
						uint catIndex2 = gSHOP_ITEM_PW.CatIndex;
						Category[] categories2 = DataFiles.GShop.Categories;
						if (gSHOP_ITEM_PW.SubCatIndex >= categories2[catIndex2].SubCatsCount)
						{
							string subCatName2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071255));
							uint subCatIndex2 = gSHOP_ITEM_PW.SubCatIndex;
							catIndex2 = gSHOP_ITEM_PW.CatIndex;
							DataFiles.GShop.Categories[catIndex2].AddSubCat((int)subCatIndex2, subCatName2);
						}
					}
					DataFiles.GShop.AddItem(gSHOP_ITEM_PW);
					int int_ = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
					dataGridViewEx_0.Rows.Add(method_97(int_, bool_7: false));
					num++;
				}
				while (num < gSHOP.ItemsCount);
			}
			bool flag = !DontChange;
			DontChange = true;
			dataGridViewEx_0.ClearSelection();
			if (flag)
			{
				DontChange = false;
			}
			int rowIndex = dataGridViewEx_0.RowCount - 1;
			DataGridViewEx dataGridViewEx = dataGridViewEx_0;
			dataGridViewEx_0.CurrentCell = dataGridViewEx[Struct59.int_1, rowIndex];
			uint itemsCount = gSHOP.ItemsCount;
			int num2 = dataGridViewEx_0.RowCount - (int)itemsCount;
			if (num2 < dataGridViewEx_0.RowCount)
			{
				do
				{
					dataGridViewEx_0.Rows[num2].Selected = true;
					num2++;
				}
				while (num2 < dataGridViewEx_0.RowCount);
			}
			byte b = ((dataGridViewEx_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			button_2.Enabled = b != 0;
			byte b2 = ((dataGridViewEx_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			contextMenuStrip_0.Enabled = b2 != 0;
			byte b3 = ((dataGridViewEx_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
			groupBox_0.Enabled = b3 != 0;
			method_40();
			method_11();
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_UPDATE_REFERENCES, (int)DataFiles.CurrentGShop, 0);
		}
		GC.KeepAlive(this);
	}

	private void label_7_DoubleClick(object sender, EventArgs e)
	{
		StoreStatusWindow storeStatusWindow = new StoreStatusWindow(numericUpDownEx_5.Value.ToString(), CStorage);
		if (storeStatusWindow.ShowDialog(this) == DialogResult.OK && decimal.TryParse(CommonStorage.sData, out var result))
		{
			numericUpDownEx_5.SetValueSafe(result);
		}
		GC.KeepAlive(this);
	}

	private string method_63(uint uint_0)
	{
		int num = (int)uint_0;
		List<string> list = new List<string>();
		if (num >= 524288)
		{
			list.Add(Class16.smethod_0(1649055613));
			num -= 524288;
		}
		else if (num >= 262144)
		{
			list.Add(Class16.smethod_0(1649055616));
			num -= 262144;
		}
		else if (num >= 131072)
		{
			list.Add(Class16.smethod_0(1649055627));
			num -= 131072;
		}
		else if (num >= 65536)
		{
			list.Add(Class16.smethod_0(1649055646));
			num -= 65536;
		}
		else if (num >= 32768)
		{
			list.Add(Class16.smethod_0(1649055649));
			num -= 32768;
		}
		else if (num >= 16384)
		{
			list.Add(Class16.smethod_0(1649055668));
			num -= 16384;
		}
		if (num >= 4096)
		{
			list.Add(Class16.smethod_0(1649055679));
			num -= 4096;
		}
		else if (num >= 2048)
		{
			list.Add(Class16.smethod_0(1649055679));
			num -= 2048;
		}
		else if (num >= 1024)
		{
			list.Add(Class16.smethod_0(1649055679));
			num -= 1024;
		}
		else if (num >= 512)
		{
			list.Add(Class16.smethod_0(1649055681));
			num -= 512;
		}
		else if (num >= 256)
		{
			list.Add(Class16.smethod_0(1649055691));
			num -= 256;
		}
		else if (num >= 128)
		{
			list.Add(Class16.smethod_0(1649055709));
			num -= 128;
		}
		else if (num >= 64)
		{
			list.Add(Class16.smethod_0(1649055719));
			num -= 64;
		}
		else if (num >= 32)
		{
			list.Add(Class16.smethod_0(1649055721));
			num -= 32;
		}
		else if (num >= 16)
		{
			list.Add(Class16.smethod_0(1649055731));
			num -= 16;
		}
		switch (num)
		{
		case 15:
			list.Insert(0, Class16.smethod_0(1648969991));
			break;
		default:
			list.Insert(0, string.Format(Class16.smethod_0(1649054773), num));
			break;
		case 9:
			list.Insert(0, Class16.smethod_0(1649054725));
			break;
		case 0:
			list.Insert(0, Class16.smethod_0(1649007069));
			break;
		case 1:
			list.Insert(0, Class16.smethod_0(1648904254));
			break;
		case 2:
			list.Insert(0, Class16.smethod_0(1649054747));
			break;
		case 3:
			list.Insert(0, Class16.smethod_0(1649054731));
			break;
		}
		return string.Join(Class16.smethod_0(1648941500), list);
	}

	private void method_64()
	{
		uint uint_ = (uint)numericUpDownEx_5.Value;
		label_7.Text = method_63(uint_);
	}

	private void textBox_8_Leave(object sender, EventArgs e)
	{
		textBox_8.Visible = false;
		if (FocusedCatDeep == 1)
		{
			string name = textBox_8.Text;
			int selectedCatIndex = SelectedCatIndex;
			DataFiles.GShop.Categories[selectedCatIndex].name = name;
			method_39();
			method_11();
			return;
		}
		string text = textBox_8.Text;
		int selectedSubCatIndex = SelectedSubCatIndex;
		int selectedCatIndex2 = SelectedCatIndex;
		if (selectedCatIndex2 >= 0 && selectedCatIndex2 < DataFiles.GShop.Categories.Length && selectedSubCatIndex >= 0 && (uint)selectedSubCatIndex < DataFiles.GShop.Categories[selectedCatIndex2].SubCatsCount)
		{
			DataFiles.GShop.Categories[selectedCatIndex2].SubCats[selectedSubCatIndex] = text;
			method_11();
			method_40();
		}
	}

	private void textBox_8_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			textBox_8_Leave(null, null);
		}
	}

	private void toolStripMenuItem_45_Click(object sender, EventArgs e)
	{
		FocusedCatDeep = 1;
		method_86();
	}

	private void toolStripMenuItem_46_Click(object sender, EventArgs e)
	{
		FocusedCatDeep = 2;
		method_86();
	}

	private void toolStripMenuItem_50_Click(object sender, EventArgs e)
	{
		if (SelectedSubCatIndex == 0)
		{
			int selectedCatIndex = SelectedCatIndex;
			if (DataFiles.GShop.Categories[selectedCatIndex].SubCatsCount == 1)
			{
				if (TextStorage.TEXTS.ShowQuestionMessage(274) == DialogResult.Yes)
				{
					toolStripMenuItem_48_Click(null, null);
				}
				return;
			}
		}
		int selectedSubCatIndex = SelectedSubCatIndex;
		int selectedCatIndex2 = SelectedCatIndex;
		DataFiles.GShop.DeleteSubCat((uint)selectedCatIndex2, (uint)selectedSubCatIndex);
		int num = 0;
		if (0 < dataGridViewEx_0.RowCount)
		{
			do
			{
				int num2 = method_37(num);
				((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).SubCatIndex = 0u;
				num++;
			}
			while (num < dataGridViewEx_0.RowCount);
		}
		method_40();
		method_95();
		method_11();
	}

	private void radioButton_16_Click(object sender, EventArgs e)
	{
		if (timer_1.Enabled && ACE.RSGlobal.RSGlobal.PrevSenderHash_optCats_Click_GShopEditor_PW == sender.GetHashCode())
		{
			timer_1.Enabled = false;
			FocusedCatDeep = 1;
			method_86();
		}
		else
		{
			ACE.RSGlobal.RSGlobal.PrevSenderHash_optCats_Click_GShopEditor_PW = sender.GetHashCode();
			timer_1.Enabled = false;
			timer_1.Enabled = true;
		}
		GC.KeepAlive(this);
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		timer_1.Enabled = false;
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_47_Click(object sender, EventArgs e)
	{
		if (TextStorage.TEXTS.ShowQuestionMessage(275) != DialogResult.Yes)
		{
			return;
		}
		int num = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
		if (num >= 0)
		{
			do
			{
				if (((GSHOP_ITEM_PW)DataFiles.GShop.Items[num]).CatIndex == (uint)SelectedCatIndex)
				{
					DataFiles.GShop.DeleteItem(num);
				}
				num--;
			}
			while (num >= 0);
		}
		int selectedCatIndex = SelectedCatIndex;
		DataFiles.GShop.Categories[selectedCatIndex].SubCats = new string[0];
		int selectedCatIndex2 = SelectedCatIndex;
		DataFiles.GShop.Categories[selectedCatIndex2].SubCatsCount = 0u;
		method_40();
		SelectedSubCatIndex = -3;
		method_44(-1);
		method_11();
	}

	private void radioButton_8_Click(object sender, EventArgs e)
	{
		if (timer_1.Enabled && ACE.RSGlobal.RSGlobal.PrevSenderHash_optSubCats_Click_GShopEditor_PW == sender.GetHashCode())
		{
			timer_1.Enabled = false;
			FocusedCatDeep = 2;
			method_86();
		}
		else
		{
			ACE.RSGlobal.RSGlobal.PrevSenderHash_optSubCats_Click_GShopEditor_PW = sender.GetHashCode();
			timer_1.Enabled = false;
			timer_1.Enabled = true;
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_48_Click(object sender, EventArgs e)
	{
		int selectedSubCatIndex = SelectedSubCatIndex;
		int selectedCatIndex = SelectedCatIndex;
		DataFiles.GShop.DeleteSubCat((uint)selectedCatIndex, (uint)selectedSubCatIndex);
		int[] array = new int[dataGridViewEx_0.RowCount];
		int num = 0;
		if (0 < dataGridViewEx_0.RowCount)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.Rows[num].Tag;
				array[num] = num2;
				num++;
			}
			while (num < dataGridViewEx_0.RowCount);
		}
		Array.Sort(array);
		int num3 = (int)((nint)array.LongLength - 1);
		if (num3 >= 0)
		{
			do
			{
				int index = array[num3];
				DataFiles.GShop.DeleteItem(index);
				num3--;
			}
			while (num3 >= 0);
		}
		method_40();
		int selectedSubCatIndex2 = SelectedSubCatIndex;
		if (selectedSubCatIndex2 > 0)
		{
			method_44(selectedSubCatIndex2 - 1);
		}
		else
		{
			dataGridViewEx_0.Rows.Clear();
			dataGridViewEx_0_SelectionChanged(null, null);
		}
		method_11();
	}

	private void contextMenuStrip_2_Opening(object sender, CancelEventArgs e)
	{
		int selectedCatIndex = SelectedCatIndex;
		if (DataFiles.GShop.Categories[selectedCatIndex].SubCatsCount > (uint)SelectedSubCatIndex)
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649054776));
			toolStripMenuItem_46.Text = text;
			toolStripSeparator_15.Visible = true;
			toolStripMenuItem_50.Visible = true;
			toolStripMenuItem_48.Visible = true;
		}
		else
		{
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649054807));
			toolStripMenuItem_46.Text = text2;
			toolStripSeparator_15.Visible = false;
			toolStripMenuItem_50.Visible = false;
			toolStripMenuItem_48.Visible = false;
		}
		GC.KeepAlive(this);
	}

	private void radioButton_8_MouseMove(object sender, MouseEventArgs e)
	{
		if (!bool_1 && e.Button == MouseButtons.Left)
		{
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Image != null)
			{
				bool_2 = true;
				int_2 = SelectedCatIndex;
				int_3 = SelectedSubCatIndex;
				radioButton.DoDragDrop(radioButton.Text, DragDropEffects.Move);
			}
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private void radioButton_8_DragDrop(object sender, DragEventArgs e)
	{
		bool_2 = false;
		RadioButton radioButton = (RadioButton)sender;
		if (!smethod_4(e.Data, out var string_) || string_ != Class16.smethod_0(1649054830) || int_4 == null || int_4.Length == 0)
		{
			return;
		}
		int startIndex = radioButton.Name.Length - 1;
		int subCatIndex = Convert.ToInt32(radioButton.Name.Substring(startIndex));
		if (radioButton.Image == null)
		{
			string subCatName = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071255));
			int selectedCatIndex = SelectedCatIndex;
			DataFiles.GShop.Categories[selectedCatIndex].AddSubCat(subCatIndex, subCatName);
		}
		if (e.Effect == DragDropEffects.Copy)
		{
			int[] array = int_4;
			int num = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					int sourceIndex = array[num];
					((GSHOP_ITEM_PW)DataFiles.GShop.AddItem(sourceIndex)).SubCatIndex = (uint)subCatIndex;
					num++;
				}
				while (num < (nint)array.LongLength);
			}
			int endval = (int)((nint)DataFiles.GShop.Items.LongLength - 1);
			int[] itemsIndices = ACE.RSGlobal.RSGlobal.IntArray((int)((nint)DataFiles.GShop.Items.LongLength - (nint)int_4.LongLength), endval, 1);
			SelectItems(itemsIndices);
		}
		else
		{
			int[] array2 = int_4;
			int num2 = 0;
			if (0 < (nint)array2.LongLength)
			{
				do
				{
					int num3 = array2[num2];
					((GSHOP_ITEM_PW)DataFiles.GShop.Items[num3]).SubCatIndex = (uint)subCatIndex;
					num2++;
				}
				while (num2 < (nint)array2.LongLength);
			}
			SelectItems(int_4);
		}
		method_40();
	}

	private void radioButton_8_DragEnter(object sender, DragEventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.antirecurse_optSubCats_DragEnter_GShopEditor_PW)
		{
			return;
		}
		RadioButton radioButton = (RadioButton)sender;
		if (bool_2 && radioButton.Image != null)
		{
			e.Effect = DragDropEffects.Move;
			int startIndex = radioButton.Name.Length - 1;
			int num = Convert.ToInt32(radioButton.Name.Substring(startIndex));
			if (int_2 == SelectedCatIndex && SelectedSubCatIndex == num)
			{
				return;
			}
			ACE.RSGlobal.RSGlobal.antirecurse_optSubCats_DragEnter_GShopEditor_PW = true;
			int selectedCatIndex = SelectedCatIndex;
			int subCat = int_3;
			int cat = int_2;
			DataFiles.GShop.ExchangeSubCats((uint)cat, (uint)subCat, (uint)selectedCatIndex, (uint)num, IsExchange: true);
			int_2 = SelectedCatIndex;
			int_3 = num;
			SelectedSubCatIndex = num;
			method_40();
			if (DataFiles.GShop.VersionPW <= PW_GSHOP_VERSION.PW_1_2_6 || SelectedCatIndex != 1)
			{
				string text = Class16.smethod_0(1649055479);
				int selectedCatIndex2 = SelectedCatIndex;
				if (!(DataFiles.GShop.Categories[selectedCatIndex2].name == text))
				{
					goto IL_0121;
				}
			}
			if (HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.ShowToolTip((Control)sender, 277, 3000);
			}
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
		goto IL_0121;
		IL_0121:
		ACE.RSGlobal.RSGlobal.antirecurse_optSubCats_DragEnter_GShopEditor_PW = false;
		GC.KeepAlive(this);
	}

	private void radioButton_16_MouseMove(object sender, MouseEventArgs e)
	{
		if (!bool_3 && e.Button == MouseButtons.Left)
		{
			RadioButton radioButton = (RadioButton)sender;
			bool_4 = true;
			radioButton.DoDragDrop(radioButton.Text, DragDropEffects.Move);
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private void radioButton_16_DragDrop(object sender, DragEventArgs e)
	{
		RadioButton radioButton = (RadioButton)sender;
		int startIndex = radioButton.Name.Length - 1;
		int num = Convert.ToInt32(radioButton.Name.Substring(startIndex));
		if (bool_2 && int_2 != num && DataFiles.GShop.Categories[num].SubCatsCount < 8)
		{
			int num2 = int_3;
			int num3 = int_2;
			string subCatName = DataFiles.GShop.Categories[num3].SubCats[num2];
			uint subCatsCount = DataFiles.GShop.Categories[num].SubCatsCount;
			DataFiles.GShop.Categories[num].AddSubCat((int)subCatsCount, subCatName);
			uint subCat = DataFiles.GShop.Categories[num].SubCatsCount - 1;
			int subCat2 = int_3;
			int cat = int_2;
			DataFiles.GShop.ExchangeSubCats((uint)cat, (uint)subCat2, (uint)num, subCat, IsExchange: false);
			Category[] categories = DataFiles.GShop.Categories;
			method_45(num, (int)(categories[num].SubCatsCount - 1));
			if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
			{
				HINTS.ToolTipWindow.SmoothHide();
			}
			method_11();
		}
		bool_4 = false;
		bool_2 = false;
	}

	private void radioButton_16_DragEnter(object sender, DragEventArgs e)
	{
		RadioButton radioButton = (RadioButton)sender;
		if (SelectedCatIndex < 0)
		{
			return;
		}
		int startIndex = radioButton.Name.Length - 1;
		int num = Convert.ToInt32(radioButton.Name.Substring(startIndex));
		if (bool_2 && int_2 != num)
		{
			if (DataFiles.GShop.Categories[num].SubCatsCount < 8)
			{
				e.Effect = DragDropEffects.Move;
				if (HINTS.ToolTipWindow != null)
				{
					HINTS.ToolTipWindow.ShowToolTip((Control)sender, 276, 3000);
				}
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		else if (bool_4)
		{
			e.Effect = DragDropEffects.Move;
			int selectedCatIndex = SelectedCatIndex;
			if (selectedCatIndex != num)
			{
				DataFiles.GShop.ExchangeCats((uint)selectedCatIndex, (uint)num);
				method_39();
				method_42(num, bool_7: false);
				method_11();
				if (HINTS.ToolTipWindow != null)
				{
					HINTS.ToolTipWindow.ShowToolTip((Control)sender, 279, 3000);
				}
			}
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_49_Click(object sender, EventArgs e)
	{
		if (DataFiles.GShop.Items == null)
		{
			GC.KeepAlive(this);
			return;
		}
		SearchResults = new List<int>();
		List<int> list = new List<int>(DataFiles.GShop.Items.Length);
		int num = 0;
		if (0 < (nint)DataFiles.GShop.Items.LongLength)
		{
			do
			{
				int itemID = DataFiles.GShop.Items[num].ItemID;
				if (list.Contains(itemID))
				{
					if (!SearchResults.Contains(list.IndexOf(itemID)))
					{
						SearchResults.Add(list.IndexOf(itemID));
					}
					SearchResults.Add(num);
				}
				list.Add(itemID);
				num++;
			}
			while (num < (nint)DataFiles.GShop.Items.LongLength);
		}
		method_94(FILTER_MODE.WithEqualsItemID);
		if (dataGridViewEx_0.RowCount > 0)
		{
			ItemsToolTip1.ShowToolTip(dataGridViewEx_0, 278, 5000);
		}
		GC.KeepAlive(this);
	}

	private void GShopEditor_PW_Load(object sender, EventArgs e)
	{
		if (eLC == null)
		{
			Close();
			return;
		}
		method_76();
		method_54();
		if (!AceNative.IsSuccess(AceNative.IsLicenseValid()))
		{
			Close();
			return;
		}
		method_57();
		if (!DataFiles.GShop.FileLoaded)
		{
			string text = eLC.Params.GShopPath;
			if (text == string.Empty)
			{
				text = Profile.GetSetting(Class16.smethod_0(1649059353), Class16.smethod_0(1649070297), string.Empty);
			}
			try
			{
				DataFiles.GShop.Load(text, PW_GSHOP_VERSION.AUTO, 0);
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649054847));
				object[] vars = new object[1] { ex.Message };
				TextStorage.TEXTS.ShowMessage(326, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
			}
			bool fileLoaded = DataFiles.GShop.FileLoaded;
			panel_0.Enabled = fileLoaded;
		}
		bool fileLoaded2 = DataFiles.GShop.FileLoaded;
		panel_0.Enabled = fileLoaded2;
		if (DataFiles.GShop.FileLoaded)
		{
			method_41();
		}
		WindowLoaded = true;
	}

	private void toolStripMenuItem_53_Click(object sender, EventArgs e)
	{
		method_67(PW_GSHOP_VERSION.PW_1_4_2_v29);
	}

	private void toolStripMenuItem_54_Click(object sender, EventArgs e)
	{
		method_67(PW_GSHOP_VERSION.PW_1_2_6);
	}

	private void toolStripMenuItem_52_Click(object sender, EventArgs e)
	{
		method_67(PW_GSHOP_VERSION.PW_1_4_4);
	}

	private void method_65()
	{
		method_66(DataFiles.GShop.VersionPW, bool_7: true);
		GC.KeepAlive(this);
	}

	private void method_66(PW_GSHOP_VERSION pw_GSHOP_VERSION_0, [MarshalAs(UnmanagedType.U1)] bool bool_7)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = Class16.smethod_0(1649054880);
		saveFileDialog.FileName = Class16.smethod_0(1648909700);
		if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			string empty = string.Empty;
			if (saveFileDialog.FileName != empty)
			{
				DataFiles.GShop.Save(saveFileDialog.FileName, pw_GSHOP_VERSION_0);
				if (bool_7)
				{
					LoadingComplete = false;
					DataFiles.GShop.Load(saveFileDialog.FileName, pw_GSHOP_VERSION_0, 0);
					method_41();
					eLC.Params.GShopPath = saveFileDialog.FileName;
					SettingsClass profile = Profile;
					profile.SaveSetting(profile.DefaultSection, Class16.smethod_0(1649067797), eLC.Params.GShopPath);
				}
			}
		}
		GC.KeepAlive(this);
	}

	private void method_67(PW_GSHOP_VERSION pw_GSHOP_VERSION_0)
	{
		method_66(pw_GSHOP_VERSION_0, bool_7: false);
	}

	private void toolStripMenuItem_56_Click(object sender, EventArgs e)
	{
		method_13(PW_GSHOP_VERSION.PW_1_2_6);
	}

	private void toolStripMenuItem_57_Click(object sender, EventArgs e)
	{
		method_13(PW_GSHOP_VERSION.PW_1_4_2_v27);
	}

	private void toolStripMenuItem_58_Click(object sender, EventArgs e)
	{
		method_13(PW_GSHOP_VERSION.PW_1_4_2_v29);
	}

	private void toolStripMenuItem_59_Click(object sender, EventArgs e)
	{
		method_13(PW_GSHOP_VERSION.PW_1_4_4);
	}

	private void toolStripMenuItem_60_Click(object sender, EventArgs e)
	{
		if (DataFiles.GShop.Items == null)
		{
			GC.KeepAlive(this);
			return;
		}
		SearchResults = new List<int>();
		List<string> list = new List<string>(DataFiles.GShop.Items.Length);
		int num = 0;
		if (0 < (nint)DataFiles.GShop.Items.LongLength)
		{
			do
			{
				string item = DataFiles.GShop.Items[num].sName.ToLowerInvariant();
				if (list.Contains(item))
				{
					if (!SearchResults.Contains(list.IndexOf(item)))
					{
						SearchResults.Add(list.IndexOf(item));
					}
					SearchResults.Add(num);
				}
				list.Add(item);
				num++;
			}
			while (num < (nint)DataFiles.GShop.Items.LongLength);
		}
		method_94(FILTER_MODE.WithEqualsItemName);
		if (dataGridViewEx_0.RowCount > 0)
		{
			ItemsToolTip1.ShowToolTip(dataGridViewEx_0, 284, 5000);
		}
		GC.KeepAlive(this);
	}

	private void timer_2_Tick(object sender, EventArgs e)
	{
		method_71();
	}

	private void dataGridViewEx_0_MouseUp(object sender, MouseEventArgs e)
	{
		timer_2.Enabled = false;
		GC.KeepAlive(this);
	}

	private void dataGridViewEx_0_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
	{
		timer_0.Enabled = false;
		if (e.RowIndex > -1 && e.Button == MouseButtons.Left)
		{
			Point location = e.Location;
			point_0 = location;
			timer_2.Enabled = true;
		}
		GC.KeepAlive(this);
	}

	private int[] method_68()
	{
		int[] array = new int[dataGridViewEx_0.SelectedRows.Count];
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				array[num] = num2;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		Array.Sort(array);
		GC.KeepAlive(this);
		return array;
	}

	private int[] method_69()
	{
		int[] array = new int[dataGridViewEx_0.SelectedRows.Count];
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				array[num] = dataGridViewEx_0.SelectedRows[num].Index;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		Array.Sort(array);
		GC.KeepAlive(this);
		return array;
	}

	private static bool smethod_4(IDataObject idataObject_0, out string string_0)
	{
		string_0 = null;
		if (idataObject_0 == null)
		{
			return false;
		}
		try
		{
			if (idataObject_0.GetDataPresent(typeof(string)))
			{
				string_0 = idataObject_0.GetData(typeof(string)) as string;
			}
			if (string.IsNullOrEmpty(string_0) && idataObject_0.GetDataPresent(DataFormats.UnicodeText))
			{
				string_0 = idataObject_0.GetData(DataFormats.UnicodeText) as string;
			}
			if (string.IsNullOrEmpty(string_0) && idataObject_0.GetDataPresent(DataFormats.Text))
			{
				string_0 = idataObject_0.GetData(DataFormats.Text) as string;
			}
		}
		catch
		{
			string_0 = null;
			return false;
		}
		return !string.IsNullOrEmpty(string_0);
	}

	private void dataGridViewEx_0_DragOver(object sender, DragEventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.antirecurse_dgwItems1_DragOver_GShopEditor_PW)
		{
			return;
		}
		ACE.RSGlobal.RSGlobal.antirecurse_dgwItems1_DragOver_GShopEditor_PW = true;
		try
		{
			if (!smethod_4(e.Data, out var string_) || string_ != Class16.smethod_0(1649054830) || dataGridViewEx_0.RowCount == 0)
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			e.Effect = DragDropEffects.Move;
			Point position = Cursor.Position;
			DataGridViewEx dataGridViewEx = dataGridViewEx_0;
			int num = int_5;
			int num2 = (position.Y - num) / dataGridViewEx.RowTemplate.Height;
			int num3 = RowIndexUnderCursor + num2;
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num3 >= dataGridViewEx_0.RowCount - 1)
			{
				num3 = dataGridViewEx_0.RowCount - 1;
			}
			int num4 = num3 - RowIndexUnderCursor;
			if (num4 == 0)
			{
				return;
			}
			int[] array = method_69();
			if (array.Length == 0)
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			if (array[0] + num4 < 0 || num4 + array[array.Length - 1] >= dataGridViewEx_0.RowCount)
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			int_4 = DataFiles.GShop.MoveItems(array, num4, dataGridViewEx_0.Rows);
			bool flag = !DontChange;
			DontChange = true;
			for (int i = 0; i < int_4.Length; i++)
			{
				byte b = ((i == 0) ? ((byte)1) : ((byte)0));
				method_16(int_4[i], b != 0, bool_8: false);
			}
			if (flag)
			{
				DontChange = false;
			}
			int[] array2 = method_69();
			if (array2.Length == 0)
			{
				return;
			}
			int num5 = ((array[0] < array2[0]) ? array[0] : array2[0]);
			int num6 = ((array[array.Length - 1] > array2[array2.Length - 1]) ? array[array.Length - 1] : array2[array2.Length - 1]);
			for (int j = num5; j <= num6; j++)
			{
				method_96(j);
			}
			RowIndexUnderCursor = num3;
			int_5 = Cursor.Position.Y;
			method_11();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649054913));
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.antirecurse_dgwItems1_DragOver_GShopEditor_PW = false;
		}
		GC.KeepAlive(this);
	}

	private void method_70(object sender, EventArgs e)
	{
	}

	private void GShopEditor_PW_Activated(object sender, EventArgs e)
	{
		ACE.Classes.Settings.ProductName = Class16.smethod_0(1649054958);
		method_76();
	}

	private void toolStripButton_5_Click(object sender, EventArgs e)
	{
		toolStripMenuItem_21.ShowDropDown();
		GC.KeepAlive(this);
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		method_14();
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		method_9();
	}

	private void toolStripButton_4_Click(object sender, EventArgs e)
	{
		method_62();
	}

	private void toolStripButton_6_Click(object sender, EventArgs e)
	{
		method_61();
	}

	private void dataGridViewEx_0_MouseDown(object sender, MouseEventArgs e)
	{
	}

	private void method_71()
	{
		timer_2.Enabled = false;
		if (!bool_5)
		{
			return;
		}
		int_4 = method_68();
		if (OriginalOrderChanged)
		{
			if (TextStorage.TEXTS.ShowQuestionMessage(339) == DialogResult.Yes)
			{
				method_95();
				SelectItems(int_4);
			}
		}
		else
		{
			_ = Cursor;
			int_5 = Cursor.Position.Y;
			dataGridViewEx_0.DoDragDrop(Class16.smethod_0(1649054830), DragDropEffects.Copy | DragDropEffects.Move);
			GC.KeepAlive(this);
		}
	}

	private void dataGridViewEx_0_DragStart(object sender, EventArgs e)
	{
		method_71();
		ACE.RSGlobal.RSGlobal.GetTickCount();
		dataGridViewEx_0.MouseDownTime = 0;
	}

	private void toolStripMenuItem_64_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(325, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void radioButton_8_DragOver(object sender, DragEventArgs e)
	{
		if (smethod_4(e.Data, out var string_) && string_ == Class16.smethod_0(1649054830))
		{
			if (e.KeyState == 9)
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.Move;
			}
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_62_Click(object sender, EventArgs e)
	{
		method_69();
		int[] array = method_68();
		if (OriginalOrderChanged)
		{
			if (TextStorage.TEXTS.ShowQuestionMessage(339) != DialogResult.Yes)
			{
				return;
			}
			method_95();
			SelectItems(array);
		}
		int firstItemIndex = (int)dataGridViewEx_0.Rows[0].Tag;
		DataFiles.GShop.MoveItemsToFirstPlace(array, firstItemIndex);
		method_95();
		bool flag = !DontChange;
		DontChange = true;
		int num = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				byte b = ((num == 0) ? ((byte)1) : ((byte)0));
				method_19(num, b != 0);
				num++;
			}
			while (num < (nint)array.LongLength);
		}
		if (flag)
		{
			DontChange = false;
		}
		RowIndexUnderCursor = 0;
		method_11();
	}

	private void toolStripMenuItem_63_Click(object sender, EventArgs e)
	{
		method_72(bool_7: false);
	}

	private void dataGridViewEx_0_Sorted(object sender, EventArgs e)
	{
		OriginalOrderChanged = true;
		toolStripButton_9.Enabled = true;
		string toolTipText = TextStorage.TEXTS.GetText(Class16.smethod_0(1649054973));
		toolStripButton_9.ToolTipText = toolTipText;
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_65_Click(object sender, EventArgs e)
	{
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				if (eLC.IsItemExist(items[num2].ItemInfo))
				{
					GSHOP_ITEM[] items2 = DataFiles.GShop.Items;
					method_51(items2[num2], bool_7: true);
				}
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		bool flag = !DontChange;
		DontChange = true;
		textBox_1.Text = pwGItem.sName;
		if (flag)
		{
			DontChange = false;
		}
		method_11();
		method_5();
	}

	private void toolStripButton_7_Click(object sender, EventArgs e)
	{
		toolStripButton_7.Enabled = false;
		PW_GSHOP_VERSION versionPW = DataFiles.GShop.VersionPW;
		ReadGShop(DataFiles.GShop.FileName, versionPW, bReload: true);
		toolStripButton_7.Enabled = true;
		GC.KeepAlive(this);
	}

	public void ReadGShop(string FileName, PW_GSHOP_VERSION Version, [MarshalAs(UnmanagedType.U1)] bool bReload)
	{
		try
		{
			if (string.IsNullOrEmpty(FileName))
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649054996)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			if (!File.Exists(FileName))
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649055008)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			DATA_FILES_ENUM currentGShop = DataFiles.CurrentGShop;
			string fileBaseName = ACE.RSGlobal.RSGlobal.GetFileBaseName(FileName);
			if (!bReload && DataFiles.TrySetGShop(FileName) && (Version == PW_GSHOP_VERSION.AUTO || DataFiles.GShop == null || DataFiles.GShop.VersionPW == Version))
			{
				if (DataFiles.CurrentGShop != currentGShop)
				{
					CheckFileRelevance();
				}
			}
			else
			{
				GSHOP gSHOP = new GSHOP(FileName, Version);
				if (gSHOP != null && gSHOP.FileLoaded)
				{
					DataFiles.SetGShop(fileBaseName);
					if (DataFiles.GShop.FileChanged)
					{
						object[] vars = new object[1] { fileBaseName };
						switch (TextStorage.TEXTS.ShowMessage(867, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, vars))
						{
						case DialogResult.Yes:
							DataFiles.GShop.Save();
							break;
						case DialogResult.Cancel:
							DataFiles.SetGShop(currentGShop);
							GC.KeepAlive(this);
							return;
						}
					}
					DataFiles.GShop = gSHOP;
					eListCollection eListCollection2 = eLC;
					if (eListCollection2 != null)
					{
						ELEMENTS_REFERENCES references = eListCollection2.References;
						DataFiles.GShop.UpdateReferences(references);
					}
					LoadingComplete = false;
					method_41();
					eLC.Params.GShopPath = FileName;
					SettingsClass profile = Profile;
					profile.SaveSetting(profile.DefaultSection, Class16.smethod_0(1649067797), eLC.Params.GShopPath);
					IsFileChanged = false;
					method_38();
					method_34();
				}
			}
			bool fileLoaded = DataFiles.GShop.FileLoaded;
			panel_0.Enabled = fileLoaded;
			GC.KeepAlive(this);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649055035));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649055066), Class16.smethod_0(1649055111)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void toolStripButton_8_Click(object sender, EventArgs e)
	{
		try
		{
			if (DataFiles.GShop == null)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649055139)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			DateTime utcNow = DateTime.UtcNow;
			ref uint timeStamp = ref DataFiles.GShop.TimeStamp;
			timeStamp = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(utcNow);
			uint timeStamp2 = DataFiles.GShop.TimeStamp;
			toolStripButton_8.Text = CommonStorage.Timestamp2String(timeStamp2, ShowSeconds: true);
			method_11();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649055035));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649055168), Class16.smethod_0(1649055202)), ex.Message), Class16.smethod_0(1648910318), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void toolStripMenuItem_69_Click(object sender, EventArgs e)
	{
		method_67(PW_GSHOP_VERSION.PW_1_4_2_v27);
	}

	private void toolStripMenuItem_68_Click(object sender, EventArgs e)
	{
		method_67(PW_GSHOP_VERSION.PW_1_5_3);
	}

	private void toolStripMenuItem_70_Click(object sender, EventArgs e)
	{
		method_65();
	}

	private void method_72([MarshalAs(UnmanagedType.U1)] bool bool_7)
	{
		int[] array = method_69();
		int[] itemsIndices = method_68();
		if (OriginalOrderChanged)
		{
			if (!bool_7 && TextStorage.TEXTS.ShowQuestionMessage(339) != DialogResult.Yes)
			{
				return;
			}
			method_95();
			SelectItems(itemsIndices);
		}
		int index = dataGridViewEx_0.RowCount - 1;
		int lastItemIndex = (int)dataGridViewEx_0.Rows[index].Tag;
		DataFiles.GShop.MoveItemsToLastPlace(itemsIndices, lastItemIndex);
		method_95();
		bool flag = !DontChange;
		DontChange = true;
		int num = dataGridViewEx_0.RowCount - 1;
		int num2 = array.Length;
		if (num >= dataGridViewEx_0.RowCount - num2)
		{
			int num3;
			do
			{
				byte b = ((num == dataGridViewEx_0.RowCount - 1) ? ((byte)1) : ((byte)0));
				method_19(num, b != 0);
				num--;
				num3 = array.Length;
			}
			while (num >= dataGridViewEx_0.RowCount - num3);
		}
		if (flag)
		{
			DontChange = false;
		}
		RowIndexUnderCursor = dataGridViewEx_0.RowCount - 1;
		method_11();
	}

	private void toolStripButton_9_Click(object sender, EventArgs e)
	{
		try
		{
			if (dataGridViewEx_0?.Rows != null && DataFiles.GShop?.Items != null)
			{
				int[] array = new int[dataGridViewEx_0.RowCount];
				int num = 0;
				if (0 < dataGridViewEx_0.RowCount)
				{
					do
					{
						int num2 = (int)dataGridViewEx_0.Rows[num].Tag;
						array[num] = num2;
						num++;
					}
					while (num < dataGridViewEx_0.RowCount);
				}
				DataFiles.GShop.ReorderItems(array);
				Array.Sort(array);
				int num3 = 0;
				if (0 < (nint)array.LongLength)
				{
					do
					{
						int num4 = array[num3];
						dataGridViewEx_0.Rows[num3].Tag = num4;
						num3++;
					}
					while (num3 < (nint)array.LongLength);
				}
				string toolTipText = TextStorage.TEXTS.GetText(Class16.smethod_0(1649054247));
				toolStripButton_9.ToolTipText = toolTipText;
				toolStripButton_9.Enabled = false;
				OriginalOrderChanged = false;
				method_11();
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649054211)), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649059353));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649054270), Class16.smethod_0(1649054302)), ex.Message), Class16.smethod_0(1648910318), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void toolStripMenuItem_72_Click(object sender, EventArgs e)
	{
		method_67(PW_GSHOP_VERSION.PW_1_5_5_v156);
	}

	private void numericUpDownEx_13_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				decimal value = numericUpDownEx_13.Value;
				((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).MinVipLevel = (int)value;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void numericUpDownEx_14_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				decimal value = numericUpDownEx_14.Value;
				ref int buyTimesLimit = ref ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).BuyTimesLimit;
				buyTimesLimit = (int)value;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				int selectedIndex = comboBox_1.SelectedIndex;
				((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).BuyTimesLimitMode = selectedIndex;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void dataGridViewEx_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 1 && e.RowIndex > -1)
		{
			if (ItemsWindow1 == null || ItemsWindow1.IsDisposed || ItemsWindow1.Disposing || eLC == null)
			{
				return;
			}
			int id = ACE.RSGlobal.RSGlobal.UIntParseFast((string)dataGridViewEx_2[0, e.RowIndex].Value);
			int listIndex = DataFiles.LI(Class16.smethod_0(1648960167));
			eListCollection eListCollection2 = eLC;
			ITEMPOS iTEMPOS = null;
			int num = eListCollection2.FindItemIndexByID(listIndex, id);
			if (num > -1)
			{
				iTEMPOS = new ITEMPOS(listIndex, num);
			}
			if (iTEMPOS != null)
			{
				ItemsWindow1.newitemlist = iTEMPOS.int_0;
				ItemsWindow1.newitemindex = iTEMPOS.int_1;
			}
			int num2 = DataFiles.LI(Class16.smethod_0(1648960167));
			int[] newlistsindices = new int[1] { num2 };
			ItemsWindow1.newlistsindices = newlistsindices;
			ItemsWindow1.bMultiSelect = false;
			CStorage.ResetBuffer();
			if (method_3(out var dialogResult_) && dialogResult_ == DialogResult.OK)
			{
				dataGridViewEx_2[0, e.RowIndex].Value = CommonStorage.sData;
			}
		}
		GC.KeepAlive(this);
	}

	private void dataGridViewEx_2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 0 && e.RowIndex > -1)
		{
			string text = (string)dataGridViewEx_2[0, e.RowIndex].Value;
			if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
			{
				int num = ACE.RSGlobal.RSGlobal.UIntParseFast(text);
				if (num == 0)
				{
					string value = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908635));
					dataGridViewEx_2[1, e.RowIndex].Value = value;
					Color white = Color.White;
					dataGridViewEx_2[1, e.RowIndex].Style.ForeColor = white;
				}
				else
				{
					int listIndex = DataFiles.LI(Class16.smethod_0(1648960167));
					eListCollection eListCollection2 = eLC;
					ITEMPOS iTEMPOS = null;
					int num2 = eListCollection2.FindItemIndexByID(listIndex, num);
					if (num2 > -1)
					{
						iTEMPOS = new ITEMPOS(listIndex, num2);
					}
					if (iTEMPOS != null)
					{
						eListCollection eListCollection3 = eLC;
						dataGridViewEx_2[1, e.RowIndex].Value = eListCollection3.GetParsedItemName(iTEMPOS);
						Color itemColor = eLC.GetItemColor(iTEMPOS.int_0, iTEMPOS.int_1);
						dataGridViewEx_2[1, e.RowIndex].Style.ForeColor = itemColor;
					}
					else
					{
						string value2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
						dataGridViewEx_2[1, e.RowIndex].Value = value2;
						Color red = Color.Red;
						dataGridViewEx_2[1, e.RowIndex].Style.ForeColor = red;
					}
				}
				if (!DontChange)
				{
					int num3 = 0;
					if (0 < dataGridViewEx_0.SelectedRows.Count)
					{
						do
						{
							int num4 = (int)dataGridViewEx_0.SelectedRows[num3].Tag;
							((GSHOP_ITEM_PW)DataFiles.GShop.Items[num4]).owner_npcs[e.RowIndex] = num;
							num3++;
						}
						while (num3 < dataGridViewEx_0.SelectedRows.Count);
					}
					method_11();
					method_34();
				}
			}
			else
			{
				dataGridViewEx_2.CancelEdit();
				int num5 = pwGItem.owner_npcs[e.RowIndex];
				dataGridViewEx_2[0, e.RowIndex].Value = num5.ToString();
			}
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_67_Click(object sender, EventArgs e)
	{
		method_13(PW_GSHOP_VERSION.PW_1_5_3);
	}

	private void toolStripMenuItem_71_Click(object sender, EventArgs e)
	{
		method_13(PW_GSHOP_VERSION.PW_1_5_5_v156);
	}

	private void toolStripMenuItem_73_Click(object sender, EventArgs e)
	{
		method_94(FILTER_MODE.ShowFashionSubCat9);
	}

	private void dataGridViewEx_2_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	private void dataGridViewEx_2_KeyUp(object sender, KeyEventArgs e)
	{
		try
		{
			if (e.KeyCode == Keys.Delete && dataGridViewEx_2.SelectedRows.Count > 0 && pwGItem?.owner_npcs != null && pwGItem.owner_npcs.Length != 0)
			{
				int index = dataGridViewEx_2.SelectedRows[0].Index;
				if (index >= 0 && index < pwGItem.owner_npcs.Length)
				{
					dataGridViewEx_2[0, index].Value = Class16.smethod_0(1648924112);
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649059353));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649054333), Class16.smethod_0(1649054365)), ex.Message), Class16.smethod_0(1648910318), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			GC.KeepAlive(this);
		}
	}

	private void toolStripMenuItem_76_Click(object sender, EventArgs e)
	{
		method_13(PW_GSHOP_VERSION.PW_1_5_5_v181);
	}

	private void toolStripMenuItem_75_Click(object sender, EventArgs e)
	{
		method_13(PW_GSHOP_VERSION.PW_1_6_0);
	}

	private void method_73(object sender, EventArgs e)
	{
		method_13(PW_GSHOP_VERSION.PW_1_7_6);
	}

	private void toolStripMenuItem_77_Click(object sender, EventArgs e)
	{
		method_67(PW_GSHOP_VERSION.PW_1_5_5_v181);
	}

	private void toolStripMenuItem_78_Click(object sender, EventArgs e)
	{
		method_67(PW_GSHOP_VERSION.PW_1_6_0);
	}

	private void toolStripMenuItem_79_Click(object sender, EventArgs e)
	{
		method_67(PW_GSHOP_VERSION.PW_1_7_6);
	}

	private void toolStripMenuItem_88_Click(object sender, EventArgs e)
	{
		method_67(PW_GSHOP_VERSION.PW_1_8_3);
	}

	private void toolStripMenuItem_85_Click(object sender, EventArgs e)
	{
		method_67(PW_GSHOP_VERSION.PW_1_8_6);
	}

	private void toolStripMenuItem_86_Click(object sender, EventArgs e)
	{
		method_13(PW_GSHOP_VERSION.PW_1_8_3);
	}

	private void toolStripMenuItem_74_Click(object sender, EventArgs e)
	{
		method_13(PW_GSHOP_VERSION.PW_1_8_6);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_74(GSHOP_ITEM_PW gshop_ITEM_PW_0, ref List<string> list_0)
	{
		int itemID = gshop_ITEM_PW_0.ItemID;
		eListCollection eListCollection2 = eLC;
		int[] mattersLists = eListCollection2.MattersLists;
		eListCollection eListCollection3 = eListCollection2;
		ITEMPOS itemPos = eListCollection3.FindItemPos(mattersLists, itemID);
		ITEMINFO info = (gshop_ITEM_PW_0.ItemInfo = eListCollection3.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true));
		if (eLC.IsItemExist(info))
		{
			int valueByFieldNameI = eLC.GetValueByFieldNameI(gshop_ITEM_PW_0.ItemInfo.pos, Class16.smethod_0(1648955717), 1);
			int count = gshop_ITEM_PW_0.Count;
			if (count > valueByFieldNameI)
			{
				list_0.Add(Class16.smethod_0(1649054396) + count);
				gshop_ITEM_PW_0.Count = valueByFieldNameI;
			}
			uint catIndex = gshop_ITEM_PW_0.CatIndex;
			if (catIndex > 8)
			{
				list_0.Add(Class16.smethod_0(1649054422) + catIndex);
				gshop_ITEM_PW_0.CatIndex = 0u;
			}
			uint catIndex2 = gshop_ITEM_PW_0.CatIndex;
			Category[] categories = DataFiles.GShop.Categories;
			uint subCatIndex = gshop_ITEM_PW_0.SubCatIndex;
			if (subCatIndex >= categories[catIndex2].SubCatsCount)
			{
				list_0.Add(Class16.smethod_0(1649054438) + subCatIndex);
				gshop_ITEM_PW_0.SubCatIndex = 0u;
			}
			int num = ((DataFiles.GShop.VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v156) ? 19 : 12);
			if (gshop_ITEM_PW_0.Status > (uint)num)
			{
				list_0.Add(Class16.smethod_0(1649054449) + gshop_ITEM_PW_0.Status);
				gshop_ITEM_PW_0.Status = 0u;
			}
			if (gshop_ITEM_PW_0.Price == 0.0)
			{
				list_0.Add(Class16.smethod_0(1649054471) + gshop_ITEM_PW_0.Price);
				gshop_ITEM_PW_0.Price = 1.0;
			}
			if (bSurfacesLoaded && !DataFiles.GShop.b_gshop3)
			{
				string sIconPath = gshop_ITEM_PW_0.sIconPath;
				if (!ShopIcons.Exists(sIconPath, IsTga: false))
				{
					list_0.Add(Class16.smethod_0(1649054484) + gshop_ITEM_PW_0.sIconPath);
					gshop_ITEM_PW_0.sIconPath = Class16.smethod_0(1649071385);
				}
			}
			int giftID = gshop_ITEM_PW_0.GiftID;
			if (giftID != 0)
			{
				int id = giftID;
				eListCollection eListCollection4 = eLC;
				int[] mattersLists2 = eListCollection4.MattersLists;
				eListCollection eListCollection5 = eListCollection4;
				ITEMPOS itemPos2 = eListCollection5.FindItemPos(mattersLists2, id);
				if (eListCollection5.GetItemInfo(itemPos2, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true) != null)
				{
					if (gshop_ITEM_PW_0.GiftCount == 0)
					{
						list_0.Add(Class16.smethod_0(1649054502) + 0);
						gshop_ITEM_PW_0.GiftCount = 1;
					}
				}
				else
				{
					list_0.Add(Class16.smethod_0(1649054519) + gshop_ITEM_PW_0.GiftID);
					gshop_ITEM_PW_0.GiftID = 0;
					gshop_ITEM_PW_0.GiftCount = 0;
				}
			}
			if (gshop_ITEM_PW_0.Duration != 0 && valueByFieldNameI > 1)
			{
				list_0.Add(Class16.smethod_0(1649054533) + gshop_ITEM_PW_0.Duration);
				gshop_ITEM_PW_0.Duration = 0u;
			}
			int controlType = gshop_ITEM_PW_0.ControlType;
			if (controlType != -1 && controlType != 0 && controlType != 1 && controlType != 2)
			{
				list_0.Add(Class16.smethod_0(1649054560) + controlType);
				gshop_ITEM_PW_0.ControlType = -1;
			}
			if (gshop_ITEM_PW_0.SaleOptions != null && gshop_ITEM_PW_0.SaleOptions.Length != 0 && gshop_ITEM_PW_0.SaleOptions[0] != null && gshop_ITEM_PW_0.SaleOptions[0].Flags != 0)
			{
				list_0.Add(Class16.smethod_0(1649054579) + gshop_ITEM_PW_0.SaleOptions[0].Flags);
				gshop_ITEM_PW_0.SaleOptions[0].Flags = 0u;
			}
			if (gshop_ITEM_PW_0.SaleOptions == null || gshop_ITEM_PW_0.SaleOptions.Length < 4)
			{
				list_0.Add(Class16.smethod_0(1649054592));
				gshop_ITEM_PW_0.SaleOptions = new SALE_OPTION[4];
			}
			int num2 = 1;
			do
			{
				if (gshop_ITEM_PW_0.SaleOptions[num2] == null)
				{
					gshop_ITEM_PW_0.SaleOptions[num2] = new SALE_OPTION();
				}
				if (gshop_ITEM_PW_0.SaleOptions[num2].Price != 0)
				{
					list_0.Add(Class16.smethod_0(1649054624) + num2 + Class16.smethod_0(1649054642) + gshop_ITEM_PW_0.SaleOptions[num2].Price);
				}
				gshop_ITEM_PW_0.SaleOptions[num2].Price = 0u;
				gshop_ITEM_PW_0.SaleOptions[num2].ExpireDate = 0u;
				gshop_ITEM_PW_0.SaleOptions[num2].Duration = 0u;
				gshop_ITEM_PW_0.SaleOptions[num2].StartDate = 0u;
				gshop_ITEM_PW_0.SaleOptions[num2].ControlType = -1;
				gshop_ITEM_PW_0.SaleOptions[num2].Day = 0u;
				gshop_ITEM_PW_0.SaleOptions[num2].Status = 0u;
				gshop_ITEM_PW_0.SaleOptions[num2].Flags = 0u;
				gshop_ITEM_PW_0.SaleOptions[num2].MinVipLevel = 0u;
				num2++;
			}
			while (num2 < 4);
			if (DataFiles.GShop.VersionPW >= PW_GSHOP_VERSION.PW_1_5_3)
			{
				if (gshop_ITEM_PW_0.owner_npcs == null || gshop_ITEM_PW_0.owner_npcs.Length < 8)
				{
					list_0.Add(Class16.smethod_0(1649054657));
					gshop_ITEM_PW_0.owner_npcs = new int[8];
				}
				int num3 = 0;
				do
				{
					int num4 = gshop_ITEM_PW_0.owner_npcs[num3];
					if (num4 > 0)
					{
						int listIndex = DataFiles.LI(Class16.smethod_0(1648960167));
						eListCollection eListCollection6 = eLC;
						ITEMPOS iTEMPOS = null;
						int num5 = eListCollection6.FindItemIndexByID(listIndex, num4);
						if (num5 > -1)
						{
							iTEMPOS = new ITEMPOS(listIndex, num5);
						}
						if (iTEMPOS == null)
						{
							list_0.Add(Class16.smethod_0(1649054688) + num4);
							gshop_ITEM_PW_0.owner_npcs[num3] = 0;
						}
					}
					num3++;
				}
				while (num3 < 8);
			}
			GC.KeepAlive(this);
			return true;
		}
		return false;
	}

	private void toolStripMenuItem_80_Click(object sender, EventArgs e)
	{
		List<string> list = null;
		if (DataFiles.GShop.Items == null)
		{
			GC.KeepAlive(this);
			return;
		}
		int count = dataGridViewEx_0.SelectedRows.Count;
		int[] array = new int[count];
		int num = 0;
		if (0 < count)
		{
			do
			{
				array[num] = dataGridViewEx_0.SelectedRows[num].Index;
				num++;
			}
			while (num < count);
		}
		Array.Sort(array);
		List<string> list2 = new List<string>();
		int num2 = count - 1;
		if (num2 >= 0)
		{
			while ((nint)DataFiles.GShop.Items.LongLength != 1)
			{
				int index = array[num2];
				int num3 = (int)dataGridViewEx_0.Rows[index].Tag;
				list = new List<string>();
				GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)DataFiles.GShop.Items[num3];
				if (!method_74(gSHOP_ITEM_PW, ref list))
				{
					list.Add(Class16.smethod_0(1649055537) + gSHOP_ITEM_PW.ItemID);
					dataGridViewEx_0.Rows.RemoveAt(index);
					DataFiles.GShop.DeleteItem(num3);
				}
				if (list.Count > 0)
				{
					int num4 = num3;
					string separator = Class16.smethod_0(1648986192);
					string text = Class16.smethod_0(1648908709);
					list2.Add(string.Concat(string.Concat(Class16.smethod_0(1649055567) + num4, text), string.Join(separator, list)));
				}
				num2--;
				if (num2 < 0)
				{
					break;
				}
			}
		}
		method_40();
		method_5();
		method_11();
		object[] vars = new object[1] { list2.Count };
		if (TextStorage.TEXTS.ShowMessage(266, MessageBoxButtons.YesNo, MessageBoxIcon.Question, vars) == DialogResult.Yes)
		{
			string text2 = Class16.smethod_0(1649055571);
			string text3 = System.IO.Path.GetTempPath() + text2;
			File.WriteAllText(text3, string.Join(Class16.smethod_0(1648924428), list2), Encoding.UTF8);
			if (File.Exists(text3))
			{
				string text4 = Class16.smethod_0(1648904453);
				string arguments = string.Concat(text4 + text3, text4);
				ACE.RSGlobal.RSGlobal.ShellP(Class16.smethod_0(1648971820), arguments, waitForExit: false);
			}
		}
		GC.KeepAlive(this);
	}

	private void textBox_4_Leave(object sender, EventArgs e)
	{
		method_75();
	}

	private void method_75()
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				GSHOP_ITEM[] items = DataFiles.GShop.Items;
				if (eLC.IsItemExist(items[num2].ItemInfo))
				{
					ref ITEMPOS pos = ref DataFiles.GShop.Items[num2].ItemInfo.pos;
					string name = textBox_4.Text;
					DataFiles.GShop.Items[num2].ItemInfo.name = name;
					string value = textBox_4.Text;
					ITEMPOS iTEMPOS = pos;
					int num3 = iTEMPOS.int_0;
					eListCollection eListCollection2 = eLC;
					eListCollection2.SetValue(num3, iTEMPOS.int_1, eListCollection2.Lists[num3].NameFieldIndex, value, AutoSaveStage: true);
				}
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_CURRENT_ITEM, 0, 0);
		ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_REFRESH_UNDO_REDO, 0, 0);
		GC.KeepAlive(this);
	}

	private void textBox_4_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			method_75();
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool CheckFileRelevance()
	{
		string fileName = FileName;
		if (DataFiles.GShop.FileName != fileName)
		{
			method_41();
			return true;
		}
		return false;
	}

	private void method_76()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_GShopEditor_PW != CommonStorage.Texts.LangIndex)
		{
			ToolTip toolTip = toolTip_1;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071086));
			textBox_0.Text = text;
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_GShopEditor_PW = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_81_Click(object sender, EventArgs e)
	{
	}

	private void toolStripMenuItem_81_CheckedChanged(object sender, EventArgs e)
	{
		ToolStripMenuItem toolStripMenuItem = toolStripMenuItem_81;
		CommonStorage.AParams.ShowItemAmountInGshop = toolStripMenuItem.Checked;
		dataGridViewTextBoxColumn_10.Visible = toolStripMenuItem_81.Checked;
		GC.KeepAlive(this);
	}

	private void toolStripButton_10_Click(object sender, EventArgs e)
	{
		toolStripMenuItem_73_Click(null, null);
	}

	private void toolStripMenuItem_16_Click(object sender, EventArgs e)
	{
		string name = ((ToolStripMenuItem)sender).Name;
		int saleOption = ACE.RSGlobal.RSGlobal.UIntParseFast(name.Substring(name.Length - 1));
		SetSaleOption(saleOption);
	}

	public void SetSaleOption(int index)
	{
		int num = 0;
		do
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)toolStripMenuItem_7.DropDownItems[num];
			byte b = ((num == index) ? ((byte)1) : ((byte)0));
			toolStripMenuItem.Checked = b != 0;
			num++;
		}
		while (num <= 3);
		CommonStorage.AParams.CurrentGShopSaleOption = (uint)index;
		if (dataGridViewEx_0.SelectedRows.Count > 0)
		{
			method_4();
			method_32();
		}
	}

	public void UpdatePropsInElements([MarshalAs(UnmanagedType.U1)] bool bOnlyRecalculate)
	{
		ITEMINFO itemInfo = pwGItem.ItemInfo;
		if (itemInfo != null)
		{
			textBox_4.Text = itemInfo.name;
			textBox_4.ForeColor = pwGItem.ItemInfo.color;
			smethod_2(pictureBox_0, eLC.Icons.GetIcon(pwGItem.ItemInfo.IconName, IsTga: false));
			groupBox_6.Enabled = true;
			bool flag = !DontChange;
			DontChange = true;
			if (!bOnlyRecalculate)
			{
				FIELDPOS fIELDPOS = eLC.FindFieldPos(pwGItem.ItemInfo.pos, Class16.smethod_0(1648955717));
				if (fIELDPOS != null)
				{
					numericUpDownEx_10.Enabled = true;
					decimal value = eLC.GetValueI(fIELDPOS);
					numericUpDownEx_10.SetValueSafe(value);
				}
				else
				{
					decimal value2 = 1m;
					numericUpDownEx_10.SetValueSafe(value2);
					numericUpDownEx_10.Enabled = false;
				}
				FIELDPOS fIELDPOS2 = eLC.FindFieldPos(pwGItem.ItemInfo.pos, Class16.smethod_0(1648970148));
				if (fIELDPOS2 != null)
				{
					numericUpDownEx_12.Enabled = true;
					decimal value3 = eLC.GetValueI(fIELDPOS2);
					numericUpDownEx_12.SetValueSafe(value3);
				}
				else
				{
					decimal value4 = 1m;
					numericUpDownEx_12.SetValueSafe(value4);
					numericUpDownEx_12.Enabled = false;
				}
				FIELDPOS fIELDPOS3 = eLC.FindFieldPos(pwGItem.ItemInfo.pos, Class16.smethod_0(1648965136));
				if (fIELDPOS3 != null)
				{
					numericUpDownEx_11.Enabled = true;
					decimal value5 = CStorage.GetGamePricePW(eLC.GetValueI(fIELDPOS3));
					numericUpDownEx_11.SetValueSafe(value5);
				}
				else
				{
					decimal value6 = 1m;
					numericUpDownEx_11.SetValueSafe(value6);
					numericUpDownEx_11.Enabled = false;
				}
			}
			if (flag)
			{
				DontChange = false;
			}
			int count = pwGItem.Count;
			int num = ((count <= 0) ? 1 : count);
			decimal d = num;
			decimal num2 = decimal.Multiply(numericUpDownEx_11.Value, d);
			object[] array = new object[2];
			string pieces = CommonStorage.GetPieces(num);
			array[0] = pieces;
			array[1] = num2.ToString(Class16.smethod_0(1648909972));
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649054706), array);
			label_19.Text = text;
			NumericUpDownEx control = numericUpDownEx_11;
			toolTip_1.SetToolTip(control, label_19.Text);
			decimal d2 = num;
			decimal num3 = decimal.Multiply(numericUpDownEx_12.Value, d2);
			object[] array2 = new object[2];
			string pieces2 = CommonStorage.GetPieces(num);
			array2[0] = pieces2;
			array2[1] = num3.ToString(Class16.smethod_0(1648909972));
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649054706), array2);
			label_20.Text = text2;
			NumericUpDownEx control2 = numericUpDownEx_12;
			toolTip_1.SetToolTip(control2, label_20.Text);
		}
		else
		{
			pictureBox_0.Image = null;
			string text3 = Class16.smethod_0(1648924112);
			if (numericUpDownEx_0.Text == text3)
			{
				string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648971625));
				textBox_4.Text = text4;
				Color white = Color.White;
				textBox_4.ForeColor = white;
			}
			else
			{
				string text5 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
				textBox_4.Text = text5;
				Color red = Color.Red;
				textBox_4.ForeColor = red;
			}
			groupBox_6.Enabled = false;
			numericUpDownEx_10.SetValueSafe(default(decimal));
			numericUpDownEx_12.SetValueSafe(default(decimal));
			numericUpDownEx_11.SetValueSafe(default(decimal));
		}
		GC.KeepAlive(this);
	}

	public void ShowBackgroundMessage(string message, [MarshalAs(UnmanagedType.U1)] bool IsAlert, int ShowTime, [MarshalAs(UnmanagedType.U1)] bool IsOutside)
	{
		if (!ACE.RSGlobal.RSGlobal.AntiRecurse_ShowBackgroundMessage_GShopEditor_PW)
		{
			ACE.RSGlobal.RSGlobal.AntiRecurse_ShowBackgroundMessage_GShopEditor_PW = true;
			if (IsOutside)
			{
				string toolTipTitle = TextStorage.TEXTS.GetText(Class16.smethod_0(1649053705));
				toolTip_0.ToolTipTitle = toolTipTitle;
			}
			else
			{
				int index = (IsAlert ? 1 : 0);
				string toolTipTitle2 = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(688, index), null);
				toolTip_0.ToolTipTitle = toolTipTitle2;
			}
			ToolTipIcon toolTipIcon = ((!IsAlert) ? ToolTipIcon.Info : ToolTipIcon.Warning);
			toolTip_0.ToolTipIcon = toolTipIcon;
			Point point;
			if (TDark.IsDarkMode)
			{
				point = method_77(toolTip_0, message);
			}
			else
			{
				int num = TextRenderer.MeasureText(message, Font).Width;
				int num2 = base.Height - 50;
				int num3 = panel_0.Left + (base.Width / 2 - num / 2);
				point = new Point(num3, num2);
			}
			toolTip_0.Show(message, this, point.X, point.Y, ShowTime);
			Application.DoEvents();
			ACE.RSGlobal.RSGlobal.AntiRecurse_ShowBackgroundMessage_GShopEditor_PW = false;
			GC.KeepAlive(this);
		}
	}

	private Point method_77(ToolTip toolTip_2, string string_0)
	{
		int num = Math.Max(140, base.ClientSize.Width - 20);
		TextFormatFlags flags = TextFormatFlags.WordBreak | TextFormatFlags.NoPadding;
		Size size = TextRenderer.MeasureText(string_0 ?? string.Empty, Font, new Size(Math.Max(80, num - 16), int.MaxValue), flags);
		bool flag = !string.IsNullOrWhiteSpace(toolTip_2?.ToolTipTitle);
		bool flag2;
		int num2 = ((flag2 = toolTip_2 != null && toolTip_2.ToolTipIcon != ToolTipIcon.None) ? 20 : 0);
		int num3 = 0;
		if (flag)
		{
			Font font = new Font(Font, FontStyle.Bold);
			try
			{
				num3 = TextRenderer.MeasureText(toolTip_2.ToolTipTitle, font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.SingleLine | TextFormatFlags.NoPadding).Width;
			}
			finally
			{
				((IDisposable)font).Dispose();
			}
		}
		int val = Math.Max(size.Width + 16 + ((!flag) ? num2 : 0), num3 + 16 + num2);
		val = Math.Max(130, Math.Min(num, val));
		int num4 = size.Height;
		if (!flag && flag2)
		{
			num4 = Math.Max(num4, 16);
		}
		int num5 = num4 + 10 + (flag ? (Font.Height + 8) : 0);
		int val2 = (base.ClientSize.Width - val) / 2;
		int val3 = Math.Max(10, base.ClientSize.Width - val - 10);
		val2 = Math.Max(10, Math.Min(val2, val3));
		int val4 = base.ClientSize.Height - num5 - 10;
		val4 = Math.Max(10, val4);
		return new Point(val2, val4);
	}

	public void ShowBackgroundMessage(string message, [MarshalAs(UnmanagedType.U1)] bool IsAlert, int ShowTime)
	{
		ShowBackgroundMessage(message, IsAlert, ShowTime, IsOutside: false);
	}

	public void ShowBackgroundMessage(string message, [MarshalAs(UnmanagedType.U1)] bool IsAlert)
	{
		ShowBackgroundMessage(message, IsAlert, 5000, IsOutside: false);
	}

	public void ShowBackgroundMessage(string message)
	{
		ShowBackgroundMessage(message, IsAlert: false);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool CheckControlTypeAndStatus(CONTROL_TYPE control, int status)
	{
		return true;
	}

	private void numericUpDownEx_17_ValueChanged(object sender, EventArgs e)
	{
		if (!DontChange)
		{
			int num = 0;
			if (0 < dataGridViewEx_0.SelectedRows.Count)
			{
				do
				{
					int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
					decimal value = numericUpDownEx_17.Value;
					ref int occupation = ref ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).Occupation;
					occupation = (int)value;
					num++;
				}
				while (num < dataGridViewEx_0.SelectedRows.Count);
			}
			method_11();
			method_34();
		}
		decimal value2 = (int)numericUpDownEx_17.Value;
		string text = eLC.DecodedValues.DecodeValue(58, value2);
		textBox_10.Text = text;
		GC.KeepAlive(this);
	}

	private void method_78(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				decimal value = numericUpDownEx_15.Value;
				ref int tasks_space = ref ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).tasks_space;
				tasks_space = (int)value;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_11();
		method_34();
	}

	private void method_79()
	{
		string[] decodedValuesArray = eLC.DecodedValues.GetDecodedValuesArray(58);
		decimal mask = Convert.ToDecimal(pwGItem.Occupation);
		ListBoxWindow listBoxWindow = new ListBoxWindow(base.Size, decodedValuesArray, pwGItem.Occupation + 1, IsMask: false, mask, bMultiplieSelection: false);
		try
		{
			if (listBoxWindow.ShowDialog(this) == DialogResult.OK)
			{
				ref decimal reference = ref eLC.DecodedValues.GetRealValuesArray(58)[CommonStorage.iData];
				pwGItem.Occupation = (int)reference;
				decimal value = pwGItem.Occupation;
				numericUpDownEx_17.SetValueSafe(value);
			}
		}
		finally
		{
			((IDisposable)listBoxWindow).Dispose();
		}
		GC.KeepAlive(this);
	}

	private void numericUpDownEx_17_DoubleClick(object sender, EventArgs e)
	{
		method_79();
	}

	private void method_80(object sender, EventArgs e)
	{
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void method_81(object sender, MouseEventArgs e)
	{
	}

	private void textBox_10_DoubleClick(object sender, EventArgs e)
	{
		method_79();
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_93();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void numericUpDownEx_16_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				decimal value = numericUpDownEx_16.Value;
				ref int tasks_id = ref ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).tasks_id;
				tasks_id = (int)value;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_83();
		method_11();
		method_34();
	}

	private int method_82(int int_6)
	{
		TASKS tASKS = eLC?.Tasks;
		if (tASKS != null && tASKS.quests != null)
		{
			CStorage.ResetBuffer();
			TasksWindow tasksWindow = new TasksWindow(tASKS, CStorage, int_6.ToString());
			try
			{
				if (tasksWindow.ShowDialog() == DialogResult.OK)
				{
					int result = Convert.ToInt32(CommonStorage.sData);
					GC.KeepAlive(this);
					return result;
				}
			}
			finally
			{
				((IDisposable)tasksWindow).Dispose();
			}
			GC.KeepAlive(this);
			return 0;
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649053728)), TextStorage.TEXTS.GetText(Class16.smethod_0(1649071086)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		return 0;
	}

	private void method_83()
	{
		int num = (int)numericUpDownEx_16.Value;
		if (num > 0 && eLC?.Tasks != null)
		{
			string taskName = eLC.Tasks.GetTaskName(num);
			textBox_11.Text = taskName;
		}
		else
		{
			textBox_11.Text = Class16.smethod_0(1648924410);
		}
	}

	private void numericUpDownEx_16_DoubleClick(object sender, EventArgs e)
	{
		decimal value = numericUpDownEx_16.Value;
		int num = method_82((int)value);
		if (num > 0)
		{
			decimal value2 = num;
			numericUpDownEx_16.SetValueSafe(value2);
			method_83();
		}
		GC.KeepAlive(this);
	}

	private void numericUpDownEx_15_ValueChanged(object sender, EventArgs e)
	{
		if (DontChange)
		{
			return;
		}
		int num = 0;
		if (0 < dataGridViewEx_0.SelectedRows.Count)
		{
			do
			{
				int num2 = (int)dataGridViewEx_0.SelectedRows[num].Tag;
				decimal value = numericUpDownEx_15.Value;
				ref int tasks_space = ref ((GSHOP_ITEM_PW)DataFiles.GShop.Items[num2]).tasks_space;
				tasks_space = (int)value;
				num++;
			}
			while (num < dataGridViewEx_0.SelectedRows.Count);
		}
		method_83();
		method_11();
		method_34();
	}

	private void numericUpDownEx_18_ValueChanged(object sender, EventArgs e)
	{
		method_84(numericUpDownEx_18, method_99);
	}

	private void numericUpDownEx_21_ValueChanged(object sender, EventArgs e)
	{
		method_84(numericUpDownEx_21, method_100);
	}

	private void numericUpDownEx_20_ValueChanged(object sender, EventArgs e)
	{
		method_84(numericUpDownEx_20, method_101);
	}

	private void numericUpDownEx_19_ValueChanged(object sender, EventArgs e)
	{
		method_84(numericUpDownEx_19, method_102);
	}

	private void numericUpDownEx_25_ValueChanged(object sender, EventArgs e)
	{
		method_84(numericUpDownEx_25, method_103);
	}

	private void numericUpDownEx_24_ValueChanged(object sender, EventArgs e)
	{
		method_84(numericUpDownEx_24, method_104);
	}

	private void numericUpDownEx_23_ValueChanged(object sender, EventArgs e)
	{
		method_84(numericUpDownEx_23, method_105);
	}

	private void numericUpDownEx_22_ValueChanged(object sender, EventArgs e)
	{
		method_84(numericUpDownEx_22, method_106);
	}

	private void method_84(Control control_0, Action<int> action_0)
	{
		if (!DontChange)
		{
			for (int i = 0; i < dataGridViewEx_0.SelectedRows.Count; i++)
			{
				int obj = (int)dataGridViewEx_0.SelectedRows[i].Tag;
				action_0(obj);
			}
			method_11();
			method_34();
		}
	}

	private int method_85()
	{
		if (int_1 == 0)
		{
			method_27();
		}
		return int_1;
	}

	private void textBox_2_MouseLeave(object sender, EventArgs e)
	{
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && ItemsToolTip1.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	private void method_86()
	{
		int selectedCatIndex = SelectedCatIndex;
		if (selectedCatIndex < 0)
		{
			return;
		}
		RadioButton radioButton;
		if (FocusedCatDeep == 1)
		{
			string text = Class16.smethod_0(1649060350);
			radioButton = (RadioButton)tableLayoutPanel_0.Controls[text + selectedCatIndex];
			int selectedCatIndex2 = SelectedCatIndex;
			Category[] categories = DataFiles.GShop.Categories;
			textBox_8.Text = categories[selectedCatIndex2].name;
		}
		else
		{
			int selectedSubCatIndex = SelectedSubCatIndex;
			string text2 = Class16.smethod_0(1649055235);
			radioButton = (RadioButton)tableLayoutPanel_0.Controls[text2 + selectedSubCatIndex];
			int selectedCatIndex3 = SelectedCatIndex;
			Category[] categories2 = DataFiles.GShop.Categories;
			if ((uint)SelectedSubCatIndex >= categories2[selectedCatIndex3].SubCatsCount)
			{
				string subCatName = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071255));
				int selectedSubCatIndex2 = SelectedSubCatIndex;
				int selectedCatIndex4 = SelectedCatIndex;
				DataFiles.GShop.Categories[selectedCatIndex4].AddSubCat(selectedSubCatIndex2, subCatName);
				method_40();
				method_11();
			}
			int selectedSubCatIndex3 = SelectedSubCatIndex;
			int selectedCatIndex5 = SelectedCatIndex;
			Category[] categories3 = DataFiles.GShop.Categories;
			textBox_8.Text = categories3[selectedCatIndex5].SubCats[selectedSubCatIndex3];
		}
		textBox_8.Width = radioButton.Width;
		textBox_8.Left = radioButton.Left;
		int num = textBox_8.Height;
		int top = (radioButton.Height - num) / 2 + radioButton.Top;
		textBox_8.Top = top;
		textBox_8.Visible = true;
		textBox_8.Focus();
		textBox_8.SelectAll();
		GC.KeepAlive(this);
	}

	private void dataGridViewEx_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex > -1)
		{
			method_50();
		}
	}

	private void dataGridViewEx_0_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		timer_0.Enabled = false;
		bool_5 = true;
		RowIndexUnderCursor = e.RowIndex;
		timer_0.Enabled = true;
		timer_2.Enabled = false;
		if (e.Button == MouseButtons.Left)
		{
			if (Math.Abs(e.Location.Y - point_0.Y) < 5)
			{
				Point location = e.Location;
				if (Math.Abs(point_0.X - location.X) > 20)
				{
					timer_2.Enabled = true;
					goto IL_00a3;
				}
			}
			timer_2.Enabled = false;
		}
		goto IL_00a3;
		IL_00a3:
		GC.KeepAlive(this);
	}

	private void method_87()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1649053764));
		toolStripMenuItem_17.Visible = true;
		toolStripMenuItem_18.Visible = true;
		toolStripSplitButton_0.Visible = true;
		toolStripSplitButton_1.Visible = true;
		toolStripMenuItem_17.Click += toolStripSplitButton_0_ButtonClick;
		toolStripMenuItem_18.Click += toolStripSplitButton_1_ButtonClick;
		toolStripSplitButton_0.ButtonClick += toolStripSplitButton_0_ButtonClick;
		toolStripSplitButton_1.ButtonClick += toolStripSplitButton_1_ButtonClick;
		fileBasedUndoManager_0.SetStateChangedCallback(method_88);
	}

	private void toolStripSplitButton_0_ButtonClick(object sender, EventArgs e)
	{
		byte[] currentState = method_89();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_90(array);
		}
	}

	private void toolStripSplitButton_1_ButtonClick(object sender, EventArgs e)
	{
		byte[] currentState = method_89();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_90(array);
		}
	}

	private void method_88()
	{
		bool canUndo = fileBasedUndoManager_0.CanUndo;
		bool canRedo = fileBasedUndoManager_0.CanRedo;
		toolStripMenuItem_17.Enabled = canUndo;
		toolStripMenuItem_18.Enabled = canRedo;
		toolStripSplitButton_0.Enabled = canUndo;
		toolStripSplitButton_1.Enabled = canRedo;
	}

	private byte[] method_89()
	{
		if (DataFiles.GShop?.Items != null && DataFiles.GShop.FileLoaded)
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				try
				{
					BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
					try
					{
						binaryWriter.Write(DataFiles.GShop.TimeStamp);
						binaryWriter.Write(DataFiles.GShop.Items.Length);
						for (int i = 0; i < DataFiles.GShop.Items.Length; i++)
						{
							GSHOP.WriteItem_PW(binaryWriter, (GSHOP_ITEM_PW)DataFiles.GShop.Items[i], DataFiles.GShop.VersionPW);
						}
						DataFiles.GShop.WriteCategories_PW(binaryWriter);
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

	private void method_90(byte[] byte_1)
	{
		if (byte_1 == null || byte_1.Length < 8 || DataFiles.GShop == null || dataGridViewEx_0 == null || dataGridViewEx_0.IsDisposed || dataGridViewEx_0.Disposing)
		{
			return;
		}
		bool_6 = true;
		bool dontChange = DontChange;
		DontChange = true;
		bool flag = false;
		bool flag2 = false;
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_1);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					DataFiles.GShop.TimeStamp = binaryReader.ReadUInt32();
					int num = binaryReader.ReadInt32();
					if (num >= 0 && num <= byte_1.Length / 4)
					{
						GSHOP_ITEM[] array = new GSHOP_ITEM[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = GSHOP.ReadItem_PW(binaryReader, DataFiles.GShop.VersionPW);
						}
						DataFiles.GShop.Items = array;
						DataFiles.GShop.ItemsCount = (uint)num;
						DataFiles.GShop.ReadCategories_PW(binaryReader);
						SuspendLayout();
						flag = true;
						dataGridViewEx_0.SuspendLayout();
						flag2 = true;
						dataGridViewEx_0.Rows.Clear();
						dictionary_0.Clear();
						List<DataGridViewRow> list = new List<DataGridViewRow>(DataFiles.GShop.Items.Length);
						for (int j = 0; j < DataFiles.GShop.Items.Length; j++)
						{
							DataGridViewRow dataGridViewRow = method_97(j, bool_7: false);
							if (dataGridViewRow != null && dataGridViewRow.DataGridView == null)
							{
								list.Add(dataGridViewRow);
							}
						}
						for (int k = 0; k < list.Count; k++)
						{
							DataGridViewRow dataGridViewRow2 = list[k];
							if (dataGridViewRow2 != null && dataGridViewRow2.DataGridView == null)
							{
								dataGridViewEx_0.Rows.Add(dataGridViewRow2);
							}
						}
						dataGridViewEx_0.ResumeLayout(performLayout: false);
						flag2 = false;
						method_39();
						method_40();
						ResumeLayout(performLayout: false);
						flag = false;
						if (dataGridViewEx_0.RowCount > 0 && dataGridViewEx_0.ColumnCount > Struct59.int_1)
						{
							dataGridViewEx_0.CurrentCell = dataGridViewEx_0[Struct59.int_1, 0];
						}
						uint timeStamp = DataFiles.GShop.TimeStamp;
						toolStripButton_8.Text = CommonStorage.Timestamp2String(timeStamp, ShowSeconds: true);
						IsFileChanged = true;
						method_38();
						method_34();
						byte_0 = method_89();
						return;
					}
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649053768), num));
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
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649053821));
		}
		finally
		{
			if (flag2 && dataGridViewEx_0 != null && !dataGridViewEx_0.IsDisposed)
			{
				try
				{
					dataGridViewEx_0.ResumeLayout(performLayout: false);
				}
				catch
				{
				}
			}
			if (flag && !base.IsDisposed)
			{
				try
				{
					ResumeLayout(performLayout: false);
				}
				catch
				{
				}
			}
			DontChange = dontChange;
			bool_6 = false;
		}
	}

	private void method_91()
	{
		if (!bool_6 && fileBasedUndoManager_0 != null && byte_0 != null)
		{
			fileBasedUndoManager_0.PushUndo(byte_0);
			byte_0 = method_89();
		}
	}

	private void method_92()
	{
		byte_0 = method_89();
		fileBasedUndoManager_0?.Clear();
	}

	public void BindEventsToOccupation()
	{
		numericUpDownEx_17.Controls[1].MouseLeave += method_80;
		numericUpDownEx_17.Controls[1].MouseMove += method_81;
		GC.KeepAlive(this);
	}

	private void method_93()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_83_Click(object sender, EventArgs e)
	{
		method_14();
	}

	private void GShopEditor_PW_Shown(object sender, EventArgs e)
	{
		if (TDark.IsDarkMode)
		{
			TDark.ApplyTheme(this);
			TDark.ApplyNativeDarkThemeRecursive(this);
		}
		eListCollection eListCollection2 = eLC;
		if (eListCollection2 != null && eListCollection2.Game == GAMES.PW)
		{
			if (!CommonStorage.License.Licenses.PW.GShop)
			{
				TextStorage.TEXTS.ShowMessage(201, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			}
			GC.KeepAlive(this);
		}
		else
		{
			TextStorage.TEXTS.ShowErrorMessage(200);
			Close();
		}
	}

	private void method_94(FILTER_MODE filter_MODE_0)
	{
		FilterMode = filter_MODE_0;
		method_43(-2);
		method_95();
	}

	private void method_95()
	{
		if (DataFiles.GShop.Items == null)
		{
			GC.KeepAlive(this);
			return;
		}
		bool flag = !DontChange;
		DontChange = true;
		dataGridViewEx_0.Rows.Clear();
		DataGridViewColumn sortedColumn = dataGridViewEx_0.SortedColumn;
		if (sortedColumn != null)
		{
			sortedColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			sortedColumn.SortMode = DataGridViewColumnSortMode.Automatic;
		}
		int selectedSubCatIndex = SelectedSubCatIndex;
		int selectedCatIndex = SelectedCatIndex;
		int catItemsCount = DataFiles.GShop.GetCatItemsCount((uint)selectedCatIndex, (uint)selectedSubCatIndex);
		if (catItemsCount > 500)
		{
			dataGridViewEx_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		}
		else
		{
			dataGridViewEx_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		}
		List<DataGridViewRow> list = new List<DataGridViewRow>(catItemsCount);
		GoodsCounter = 1;
		int num = 0;
		if (0 < (nint)DataFiles.GShop.Items.LongLength)
		{
			do
			{
				DataGridViewRow dataGridViewRow = method_97(num, bool_7: true);
				if (dataGridViewRow != null)
				{
					list.Add(dataGridViewRow);
				}
				GoodsCounter++;
				num++;
			}
			while (num < (nint)DataFiles.GShop.Items.LongLength);
		}
		for (int i = 0; i < list.Count; i++)
		{
			DataGridViewRow dataGridViewRow2 = list[i];
			if (dataGridViewRow2 != null && dataGridViewRow2.DataGridView == null)
			{
				dataGridViewEx_0.Rows.Add(dataGridViewRow2);
			}
		}
		if (flag)
		{
			DontChange = false;
		}
		method_34();
		Cursor = Cursors.Default;
		byte b = ((dataGridViewEx_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		button_2.Enabled = b != 0;
		byte b2 = ((dataGridViewEx_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		contextMenuStrip_0.Enabled = b2 != 0;
		method_26();
		byte b3 = ((dataGridViewEx_0.SelectedRows.Count > 0) ? ((byte)1) : ((byte)0));
		groupBox_0.Enabled = b3 != 0;
		OriginalOrderChanged = false;
		string toolTipText = TextStorage.TEXTS.GetText(Class16.smethod_0(1649054247));
		toolStripButton_9.ToolTipText = toolTipText;
		toolStripButton_9.Enabled = false;
		if (catItemsCount > 500)
		{
			dataGridViewEx_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
		}
		GC.KeepAlive(this);
	}

	private void method_96(int int_6)
	{
		if (int_6 >= 0 && int_6 < dataGridViewEx_0.Rows.Count)
		{
			DataGridViewRow dataGridViewRow_ = dataGridViewEx_0.Rows[int_6];
			if (dataGridViewRow_.Tag == null || !int.TryParse(dataGridViewRow_.Tag.ToString(), out var _))
			{
				throw new InvalidOperationException(Class16.smethod_0(1649053942));
			}
			method_98(ref dataGridViewRow_, (int)dataGridViewEx_0.Rows[int_6].Tag, bool_7: false);
			GC.KeepAlive(this);
			return;
		}
		throw new ArgumentOutOfRangeException(Class16.smethod_0(1649053863), Class16.smethod_0(1649053866));
	}

	private DataGridViewRow method_97(int int_6, [MarshalAs(UnmanagedType.U1)] bool bool_7)
	{
		DataGridViewRow dataGridViewRow_ = null;
		if (method_98(ref dataGridViewRow_, int_6, bool_7))
		{
			return dataGridViewRow_;
		}
		return null;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_98(ref DataGridViewRow dataGridViewRow_0, int int_6, [MarshalAs(UnmanagedType.U1)] bool bool_7)
	{
		try
		{
			if (DataFiles.GShop?.Items == null)
			{
				return false;
			}
			if (int_6 >= 0 && int_6 < DataFiles.GShop.Items.Length)
			{
				GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)DataFiles.GShop.Items[int_6];
				if (gSHOP_ITEM_PW == null)
				{
					return false;
				}
				string text;
				Color foreColor;
				Image value;
				int itemID;
				int num2;
				int[] mattersLists;
				eListCollection eListCollection3;
				ITEMPOS itemPos;
				ITEMINFO itemInfo;
				eListCollection eListCollection2;
				int iD;
				int count2;
				DataGridViewTextBoxColumn dataGridViewTextBoxColumn;
				DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
				DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
				DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
				switch (FilterMode)
				{
				case FILTER_MODE.WithCount0:
					if (gSHOP_ITEM_PW.Count != 0)
					{
						GC.KeepAlive(this);
						return false;
					}
					goto IL_01e8;
				case FILTER_MODE.NotFoundedIcons:
					if (bSurfacesLoaded)
					{
						string sIconPath = gSHOP_ITEM_PW.sIconPath;
						if (ShopIcons.Exists(sIconPath, IsTga: false))
						{
							GC.KeepAlive(this);
							return false;
						}
					}
					goto IL_01e8;
				case FILTER_MODE.WithVeryLongName:
					if (gSHOP_ITEM_PW.sName.Length <= 16)
					{
						GC.KeepAlive(this);
						return false;
					}
					goto IL_01e8;
				case FILTER_MODE.WithFullDescription:
					if (gSHOP_ITEM_PW.sDescription.Length != 512)
					{
						GC.KeepAlive(this);
						return false;
					}
					goto IL_01e8;
				default:
					if (!radioButton_9.Checked && !radioButton_18.Checked)
					{
						if (gSHOP_ITEM_PW.CatIndex != (uint)SelectedCatIndex)
						{
							GC.KeepAlive(this);
							return false;
						}
						if (!radioButton_0.Checked && gSHOP_ITEM_PW.SubCatIndex != (uint)SelectedSubCatIndex)
						{
							GC.KeepAlive(this);
							return false;
						}
					}
					goto IL_01e8;
				case FILTER_MODE.Search:
				case FILTER_MODE.WithEqualsItemID:
				case FILTER_MODE.WithEqualsItemName:
				{
					List<int> searchResults = SearchResults;
					if (searchResults == null || !searchResults.Contains(int_6))
					{
						GC.KeepAlive(this);
						return false;
					}
					goto IL_01e8;
				}
				case FILTER_MODE.ShowFashionSubCat9:
					{
						int selectedCatIndex = SelectedCatIndex;
						int num = ((selectedCatIndex <= -1 || DataFiles.GShop.Categories[selectedCatIndex].SubCatsCount <= 8) ? 1 : SelectedCatIndex);
						if (gSHOP_ITEM_PW.CatIndex != (uint)num || gSHOP_ITEM_PW.SubCatIndex != 8)
						{
							break;
						}
						goto IL_01e8;
					}
					IL_01e8:
					if (bool_7 && dictionary_0.TryGetValue(gSHOP_ITEM_PW.ID, out dataGridViewRow_0))
					{
						dataGridViewRow_0.Tag = int_6;
						GC.KeepAlive(this);
						return true;
					}
					dictionary_0.Remove(gSHOP_ITEM_PW.ID);
					text = gSHOP_ITEM_PW.sName;
					foreColor = Color.White;
					value = eLC.Icons.GetIcon(string.Empty, IsTga: false, 20);
					itemID = gSHOP_ITEM_PW.ItemID;
					num2 = 0;
					eListCollection2 = eLC;
					mattersLists = eListCollection2.MattersLists;
					eListCollection3 = eListCollection2;
					itemPos = eListCollection3.FindItemPos(mattersLists, itemID);
					itemInfo = eListCollection3.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
					DataFiles.GShop.Items[int_6].ItemInfo = itemInfo;
					if (itemInfo == null)
					{
						if (dataGridViewRow_0 == null)
						{
							(dataGridViewRow_0 = new DataGridViewRow()).Resizable = DataGridViewTriState.False;
							dataGridViewRow_0.CreateCells(dataGridViewEx_0);
						}
						dataGridViewRow_0.Cells[0].Value = value;
						dataGridViewRow_0.Cells[1].Value = gSHOP_ITEM_PW.ID;
						dataGridViewRow_0.Cells[2].Value = gSHOP_ITEM_PW.ItemID;
						dataGridViewRow_0.Cells[3].Value = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
						dataGridViewRow_0.Tag = int_6;
					}
					switch (FilterMode)
					{
					case FILTER_MODE.WithBuggedPileNum:
					{
						if (itemInfo == null)
						{
							return false;
						}
						int valueByFieldNameI = eLC.GetValueByFieldNameI(itemInfo.pos, Class16.smethod_0(1648955717), 1);
						if (gSHOP_ITEM_PW.Count <= valueByFieldNameI)
						{
							GC.KeepAlive(this);
							return false;
						}
						break;
					}
					case FILTER_MODE.NotFoundedItems:
					{
						if (itemInfo != null)
						{
							return false;
						}
						int giftID = gSHOP_ITEM_PW.GiftID;
						if (giftID > 0)
						{
							int id = giftID;
							eListCollection2 = eLC;
							int[] mattersLists2 = eListCollection2.MattersLists;
							eListCollection eListCollection4 = eListCollection2;
							ITEMPOS itemPos2 = eListCollection4.FindItemPos(mattersLists2, id);
							if (eListCollection4.GetItemInfo(itemPos2, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true) != null)
							{
								GC.KeepAlive(this);
								return false;
							}
						}
						break;
					}
					}
					if (itemInfo != null)
					{
						Color white = Color.White;
						if (itemInfo.color != white)
						{
							foreColor = itemInfo.color;
						}
						value = eLC.Icons.GetIcon(itemInfo.IconName, IsTga: false, 20);
						if (gSHOP_ITEM_PW.Count > 0)
						{
							int count = gSHOP_ITEM_PW.Count;
							num2 = eLC.GetValueByFieldNameI(itemInfo.pos, Class16.smethod_0(1648955717), 1) / count;
						}
					}
					else
					{
						string text2;
						if (itemID != 0)
						{
							text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
							foreColor = Color.Red;
						}
						else
						{
							text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648971625));
							foreColor = Color.Red;
						}
						string text3 = Class16.smethod_0(1649008474);
						text = string.Concat(text, string.Concat(Class16.smethod_0(1648961184) + text2, text3));
					}
					if (dataGridViewRow_0 == null)
					{
						(dataGridViewRow_0 = new DataGridViewRow()).Resizable = DataGridViewTriState.False;
						dataGridViewRow_0.CreateCells(dataGridViewEx_0);
					}
					iD = gSHOP_ITEM_PW.ID;
					dataGridViewRow_0.Cells[Struct59.int_0].Value = iD;
					dataGridViewRow_0.Cells[Struct59.int_1].Value = itemID;
					dataGridViewRow_0.Cells[Struct59.int_2].Value = value;
					dataGridViewRow_0.Cells[Struct59.int_3].Value = text;
					count2 = gSHOP_ITEM_PW.Count;
					dataGridViewRow_0.Cells[Struct59.int_4].Value = count2;
					dataGridViewRow_0.Cells[Struct59.int_5].Value = ACE.RSGlobal.RSGlobal.DoubleToString(gSHOP_ITEM_PW.Price);
					dataGridViewRow_0.Cells[Struct59.int_6].Value = num2;
					dataGridViewTextBoxColumn = dataGridViewTextBoxColumn_9;
					dataGridViewRow_0.Cells[Struct59.int_3].Style.Font = dataGridViewTextBoxColumn.DefaultCellStyle.Font;
					dataGridViewRow_0.Cells[Struct59.int_3].Style.ForeColor = foreColor;
					dataGridViewTextBoxColumn2 = dataGridViewTextBoxColumn_11;
					dataGridViewRow_0.Cells[Struct59.int_5].Style.Font = dataGridViewTextBoxColumn2.DefaultCellStyle.Font;
					dataGridViewTextBoxColumn3 = dataGridViewTextBoxColumn_12;
					dataGridViewRow_0.Cells[Struct59.int_6].Style.Font = dataGridViewTextBoxColumn3.DefaultCellStyle.Font;
					dataGridViewTextBoxColumn4 = dataGridViewTextBoxColumn_12;
					dataGridViewRow_0.Cells[Struct59.int_4].Style.Font = dataGridViewTextBoxColumn4.DefaultCellStyle.Font;
					dataGridViewRow_0.Tag = int_6;
					dictionary_0.Add(gSHOP_ITEM_PW.ID, dataGridViewRow_0);
					GC.KeepAlive(this);
					return true;
				}
				GC.KeepAlive(this);
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649059353));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649054008)) + ex.Message, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return false;
		}
	}

	private void method_99(int int_6)
	{
		((GSHOP_ITEM_PW)DataFiles.GShop.Items[int_6]).reserved1 = (int)numericUpDownEx_18.Value;
	}

	private void method_100(int int_6)
	{
		((GSHOP_ITEM_PW)DataFiles.GShop.Items[int_6]).reserved2 = (int)numericUpDownEx_21.Value;
	}

	private void method_101(int int_6)
	{
		((GSHOP_ITEM_PW)DataFiles.GShop.Items[int_6]).reserved3 = (int)numericUpDownEx_20.Value;
	}

	private void method_102(int int_6)
	{
		((GSHOP_ITEM_PW)DataFiles.GShop.Items[int_6]).reserved4 = (int)numericUpDownEx_19.Value;
	}

	private void method_103(int int_6)
	{
		((GSHOP_ITEM_PW)DataFiles.GShop.Items[int_6]).special_server_forbid = (int)numericUpDownEx_25.Value;
	}

	private void method_104(int int_6)
	{
		((GSHOP_ITEM_PW)DataFiles.GShop.Items[int_6]).in_green_shop = (byte)numericUpDownEx_24.Value;
	}

	private void method_105(int int_6)
	{
		((GSHOP_ITEM_PW)DataFiles.GShop.Items[int_6]).add_trade_time = (int)numericUpDownEx_23.Value;
	}

	private void method_106(int int_6)
	{
		((GSHOP_ITEM_PW)DataFiles.GShop.Items[int_6]).reserved6 = (int)numericUpDownEx_22.Value;
	}
}
