using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.Protectors;
using ACE.RSGlobal;

namespace ACE.Settings;

public class SettingsWindow : Form
{
	private CommonStorage commonStorage_0;

	private int int_0;

	private bool bool_0;

	private ADDITIONAL_PARAMS additional_PARAMS_0;

	private int int_1;

	private bool bool_1;

	private string string_0;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private ToolTip toolTip_0;

	private CheckBox checkBox_4;

	private CheckBox checkBox_5;

	private CheckBox checkBox_6;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_0;

	private Label label_0;

	private Button button_2;

	private TextBox textBox_1;

	private Label label_1;

	private Button button_3;

	private TextBox textBox_2;

	private Label label_2;

	private Button button_4;

	private Button button_5;

	private Button button_6;

	private CheckBox checkBox_7;

	private TextBox textBox_3;

	private Label label_3;

	private CheckBox checkBox_8;

	private NumericUpDown numericUpDown_0;

	private Label label_4;

	private CheckBox checkBox_9;

	private CheckBox checkBox_10;

	private Button button_7;

	private Button button_8;

	private TextBox textBox_4;

	private Label label_5;

	private Button button_9;

	private Button button_10;

	private TextBox textBox_5;

	private Label label_6;

	private Button button_11;

	private Button button_12;

	private TextBox textBox_6;

	private NumericUpDown numericUpDown_1;

	private Label label_7;

	private GroupBox groupBox_0;

	private GroupBox groupBox_1;

	private ComboBox comboBox_0;

	private NumericUpDown numericUpDown_2;

	private Label label_8;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private TabPage tabPage_1;

	private CheckBox checkBox_11;

	private TabPage tabPage_2;

	private TabPage tabPage_3;

	private GroupBox groupBox_2;

	private ComboBox comboBox_1;

	private GroupBox groupBox_3;

	private Button button_13;

	private Label label_9;

	private TextBox textBox_7;

	private Button button_14;

	private Label label_10;

	private TextBox textBox_8;

	private Button button_15;

	private Button button_16;

	private Label label_11;

	private TextBox textBox_9;

	private GroupBox groupBox_4;

	private GroupBox groupBox_5;

	private Button button_17;

	private Button button_18;

	private Label label_12;

	private TextBox textBox_10;

	private ParamsClass paramsClass_0;

	private Label label_13;

	private CheckBox checkBox_12;

	private CheckBox checkBox_13;

	private NumericUpDown numericUpDown_3;

	private CheckBox checkBox_14;

	private NumericUpDown numericUpDown_4;

	private Label label_14;

	private NumericUpDown numericUpDown_5;

	private Label label_15;

	private CheckBox checkBox_15;

	private TabPage tabPage_4;

	private GroupBox groupBox_6;

	private Label label_16;

	private TextBox textBox_11;

	private GroupBox groupBox_7;

	private Label label_17;

	private TextBox textBox_12;

	private Label label_18;

	private TextBox textBox_13;

	private Label label_19;

	private TextBox textBox_14;

	private TextBox textBox_15;

	private NumericUpDown numericUpDown_6;

	private Label label_20;

	private Label label_21;

	private TextBox textBox_16;

	private TextBox textBox_17;

	private Label label_22;

	private Label label_23;

	private ComboBox comboBox_2;

	private Label label_24;

	private GroupBox groupBox_8;

	private CheckBox checkBox_16;

	private Button button_19;

	private TextBox textBox_18;

	private Label label_25;

	private Button button_20;

	private TextBox textBox_19;

	private Label label_26;

	private TextBox textBox_20;

	private Label label_27;

	private TextBox textBox_21;

	private Label label_28;

	private TextBox textBox_22;

	private Label label_29;

	private TextBox textBox_23;

	private Label label_30;

	private TextBox textBox_24;

	private Label label_31;

	private Button button_21;

	private Button button_22;

	private Label label_32;

	private TextBox textBox_25;

	private GroupBox groupBox_9;

	private Button button_23;

	private TextBox textBox_26;

	private Button button_24;

	private Label label_33;

	private Button button_25;

	private Button button_26;

	private Label label_34;

	private TextBox textBox_27;

	private Button button_27;

	private TextBox textBox_28;

	private Button button_28;

	private Label label_35;

	private Button button_29;

	private TextBox textBox_29;

	private Button button_30;

	private Label label_36;

	private CheckBox checkBox_17;

	private ComboBox comboBox_3;

	private Label label_37;

	private TextBox textBox_30;

	private Label label_38;

	private GroupBox groupBox_10;

	private Button button_31;

	private TextBox textBox_31;

	private Label label_39;

	private Button button_32;

	private Button button_33;

	private Label label_40;

	private TextBox textBox_32;

	private TextBox textBox_33;

	private Label label_41;

	private Button button_34;

	private Button button_35;

	private TextBox textBox_34;

	private Label label_42;

	private Button button_36;

	private Button button_37;

	private TextBox textBox_35;

	private Label label_43;

	private Button button_38;

	private Button button_39;

	private TextBox textBox_36;

	private Label label_44;

	private Button button_40;

	private Button button_41;

	private Button button_42;

	private Button button_43;

	private Label label_45;

	private TextBox textBox_37;

	private Button button_44;

	private CheckBox checkBox_18;

	private BindingSource bindingSource_0;

	private GroupBox groupBox_11;

	private ComboBox comboBox_4;

	private TextBox textBox_38;

	private NumericUpDown numericUpDown_7;

	private NumericUpDown numericUpDown_8;

	private NumericUpDown numericUpDown_9;

	private Label label_46;

	private CheckBox checkBox_19;

	private CheckBox checkBox_20;

	private DataGridView dataGridView_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private LinkLabel linkLabel_0;

	private TabPage tabPage_5;

	private PropertyGrid propertyGrid_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private CheckBox checkBox_21;

	private CheckBox checkBox_22;

	private CheckBox checkBox_23;

	private CheckBox checkBox_24;

	private CheckBox checkBox_25;

	private NumericUpDown numericUpDown_10;

	private CheckBox checkBox_26;

	private CheckBox checkBox_27;

	private GroupBox groupBox_12;

	private Button button_45;

	private CheckBox checkBox_28;

	private CheckBox checkBox_29;

	private Label label_47;

	private GroupBox groupBox_13;

	private ComboBox comboBox_5;

	private Button button_46;

	private TabPage tabPage_6;

	private GroupBox groupBox_14;

	private LinkLabel linkLabel_1;

	private DataGridView dataGridView_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private GroupBox groupBox_15;

	private LinkLabel linkLabel_2;

	private DataGridView dataGridView_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private TextBox textBox_39;

	private Label label_48;

	private TextBox textBox_40;

	private Label label_49;

	private Button button_47;

	private Button button_48;

	private Label label_50;

	private TextBox textBox_41;

	private Button button_49;

	private Button button_50;

	private Label label_51;

	private TextBox textBox_42;

	private Button button_51;

	private Button button_52;

	private Label label_52;

	private TextBox textBox_43;

	private Button button_53;

	private Button button_54;

	private Label label_53;

	private TextBox textBox_44;

	private Label label_54;

	private Timer timer_0;

	private Label label_55;

	private GroupBox groupBox_16;

	private CheckBox checkBox_30;

	private CheckBox checkBox_31;

	private Button button_55;

	private IContainer icontainer_0;

	private Button button_56;

	private Button button_57;

	private Label label_56;

	private TextBox textBox_45;

	private Button button_58;

	private Button button_59;

	private Label label_57;

	private TextBox textBox_46;

	private TextBox textBox_47;

	private Label label_58;

	public SettingsWindow(CommonStorage CStorage, string ActionToDo)
	{
		try
		{
			bool_0 = true;
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			bool_0 = false;
			commonStorage_0 = CStorage;
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			paramsClass_0 = CommonStorage.Params;
			ADDITIONAL_PARAMS aParams = CommonStorage.AParams;
			aParams.PrevParams = aParams;
			ADDITIONAL_PARAMS selectedObject = (additional_PARAMS_0 = CommonStorage.AParams.GetClone());
			propertyGrid_0.SelectedObject = selectedObject;
			string_0 = ActionToDo;
			int_0 = LANG_INFO.CurrentLang.Index;
			LANGUAGES languages = CommonStorage.Texts.Languages;
			ComboBox.ObjectCollection items = comboBox_0.Items;
			object[] languages2 = languages.GetLanguages();
			items.AddRange(languages2);
			comboBox_0.SelectedIndex = CommonStorage.LangIndex;
			int_1 = CommonStorage.LangIndex;
			checkBox_0.Checked = paramsClass_0.LoadLastElements;
			checkBox_20.Checked = paramsClass_0.EnableCustomCursors;
			checkBox_1.Checked = paramsClass_0.LoadLastList;
			checkBox_2.Checked = paramsClass_0.AutoCheckID;
			checkBox_30.Checked = paramsClass_0.ShowItemsColor;
			checkBox_31.Checked = paramsClass_0.ShowMobsColor;
			decimal value = paramsClass_0.MaxMobLevel;
			numericUpDown_1.Value = value;
			checkBox_3.Checked = paramsClass_0.UseAlternativeRecipesNames;
			checkBox_4.Checked = paramsClass_0.DontChangeUniqueID;
			checkBox_5.Checked = paramsClass_0.ShowRealValues;
			checkBox_28.Checked = paramsClass_0.UseAddonsFilter;
			checkBox_29.Checked = paramsClass_0.UseSkillsFilter;
			checkBox_6.Checked = paramsClass_0.ShowUnknownFields;
			textBox_0.Text = paramsClass_0.DescriptionsPath;
			textBox_1.Text = paramsClass_0.ColorsPath;
			checkBox_21.Checked = paramsClass_0.ShowMainPreviewWindow;
			textBox_3.Text = paramsClass_0.DefaultCreator;
			checkBox_10.Checked = paramsClass_0.ShowIcons;
			checkBox_9.Checked = paramsClass_0.ShowThumbs;
			checkBox_8.Checked = paramsClass_0.SortIcons;
			decimal value2 = paramsClass_0.ThumbSize;
			numericUpDown_0.Value = value2;
			textBox_5.Text = paramsClass_0.IconsPath;
			textBox_4.Text = paramsClass_0.IconsNamesPath;
			comboBox_5.SelectedIndex = paramsClass_0.FieldDoubleClickAction;
			decimal value3 = paramsClass_0.FieldHeight;
			numericUpDown_2.Value = value3;
			checkBox_11.Checked = paramsClass_0.UseAltFont;
			comboBox_1.SelectedIndex = paramsClass_0.NewItemsPlace;
			checkBox_26.Checked = paramsClass_0.FirstListIndexIs1;
			checkBox_27.Checked = paramsClass_0.DisableFastSearch;
			textBox_7.Text = paramsClass_0.ShopDescPath;
			textBox_8.Text = paramsClass_0.ShopdirLua;
			textBox_27.Text = paramsClass_0.SurfacesPckDir;
			decimal value4 = paramsClass_0.MaxBackupsCount;
			numericUpDown_10.Value = value4;
			checkBox_12.Checked = paramsClass_0.AutoUpdate;
			checkBox_13.Checked = paramsClass_0.WarnWhenDeletingItemWithEntries;
			decimal value5 = paramsClass_0.PreviewRefineLevel;
			numericUpDown_3.Value = value5;
			checkBox_25.Checked = paramsClass_0.ExportIconsWithName;
			checkBox_23.Checked = paramsClass_0.CompressBackups;
			checkBox_24.Checked = paramsClass_0.IgnoreApiFileNameDifference;
			byte b = (byte)((CommonStorage.License.Special.PW.PreviewRefine && paramsClass_0.PreviewRefine) ? 1u : 0u);
			checkBox_14.Checked = b != 0;
			checkBox_15.Checked = paramsClass_0.SaveActionsHistory;
			decimal value6 = paramsClass_0.ActionsHistoryLimit;
			numericUpDown_5.Value = value6;
			decimal value7 = paramsClass_0.AHistoryDropDownMenuLimit;
			numericUpDown_4.Value = value7;
			checkBox_22.Checked = paramsClass_0.WarnAboutUnsavedElements;
			textBox_14.Text = paramsClass_0.SSH.Address;
			textBox_15.Text = paramsClass_0.SSH.Login;
			numericUpDown_6.Text = paramsClass_0.SSH.Port;
			if (!string.IsNullOrEmpty(paramsClass_0.SSH.Pass))
			{
				textBox_16.Text = Class16.smethod_0(1649156968);
			}
			textBox_18.Text = paramsClass_0.SSH.ConfigPath;
			textBox_11.Text = paramsClass_0.SSH.ElementsPath;
			textBox_19.Text = paramsClass_0.SSH.TasksPath;
			textBox_17.Text = paramsClass_0.SSH.ToolsDirectory;
			textBox_20.Text = paramsClass_0.SSH.GShopPath;
			textBox_40.Text = paramsClass_0.SSH.GShop1Path;
			textBox_39.Text = paramsClass_0.SSH.GShop2Path;
			textBox_47.Text = paramsClass_0.SSH.GShop3Path;
			textBox_23.Text = paramsClass_0.SSH.AIPolicyPath;
			textBox_22.Text = paramsClass_0.SSH.NPCGenPath;
			textBox_21.Text = paramsClass_0.SSH.DomainSevPath;
			textBox_24.Text = paramsClass_0.SSH.Domain2SevPath;
			textBox_31.Text = paramsClass_0.SSH.ExtraDropPath;
			textBox_13.Text = paramsClass_0.SSH.RestartCommand ?? Class16.smethod_0(1648902039);
			textBox_12.Text = paramsClass_0.SSH.CustomCommand ?? string.Empty;
			comboBox_2.SelectedIndex = (int)paramsClass_0.SSH.ServerButtonAction;
			bool_0 = true;
			comboBox_3.SelectedIndex = (int)paramsClass_0.Game;
			bool_0 = false;
			checkBox_17.Checked = paramsClass_0.UsePck;
			textBox_30.Text = paramsClass_0.FileIconTitle;
			checkBox_16.Checked = paramsClass_0.SSH.UseCompression;
			method_12(paramsClass_0);
			checkBox_18.Checked = paramsClass_0.SaveDescAndColors;
			comboBox_4.SelectedIndex = (int)paramsClass_0.PckKeyMode;
			decimal value8 = paramsClass_0.PckKey1;
			numericUpDown_8.Value = value8;
			decimal value9 = paramsClass_0.PckKey2;
			numericUpDown_7.Value = value9;
			textBox_38.Text = paramsClass_0.PckProtectedKey;
			decimal value10 = paramsClass_0.ToolTipFieldsNumLimit;
			numericUpDown_9.Value = value10;
			checkBox_19.Checked = paramsClass_0.ShowModelPreview;
			string[] pckFiles = paramsClass_0.PckFiles;
			if (pckFiles != null)
			{
				string[] array = pckFiles;
				int num = 0;
				if (0 < (nint)array.LongLength)
				{
					do
					{
						string text = array[num];
						object[] values = new object[1] { text };
						dataGridView_0.Rows.Add(values);
						num++;
					}
					while (num < (nint)array.LongLength);
				}
			}
			if (additional_PARAMS_0.NpcGenPaths != null)
			{
				string[] npcGenPaths = additional_PARAMS_0.NpcGenPaths;
				int num2 = 0;
				if (0 < (nint)npcGenPaths.LongLength)
				{
					do
					{
						string text2 = npcGenPaths[num2];
						object[] values2 = new object[1] { text2 };
						dataGridView_1.Rows.Add(values2);
						num2++;
					}
					while (num2 < (nint)npcGenPaths.LongLength);
				}
			}
			if (additional_PARAMS_0.PreinctPaths != null)
			{
				string[] preinctPaths = additional_PARAMS_0.PreinctPaths;
				int num3 = 0;
				if (0 < (nint)preinctPaths.LongLength)
				{
					do
					{
						string text3 = preinctPaths[num3];
						object[] values3 = new object[1] { text3 };
						dataGridView_2.Rows.Add(values3);
						num3++;
					}
					while (num3 < (nint)preinctPaths.LongLength);
				}
			}
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void method_0()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SettingsWindow));
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
		groupBox_16 = new GroupBox();
		checkBox_31 = new CheckBox();
		checkBox_30 = new CheckBox();
		checkBox_7 = new CheckBox();
		button_55 = new Button();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		checkBox_4 = new CheckBox();
		checkBox_6 = new CheckBox();
		checkBox_5 = new CheckBox();
		checkBox_3 = new CheckBox();
		toolTip_0 = new ToolTip(icontainer_0);
		button_4 = new Button();
		button_6 = new Button();
		button_5 = new Button();
		checkBox_8 = new CheckBox();
		button_9 = new Button();
		button_7 = new Button();
		button_11 = new Button();
		button_15 = new Button();
		button_17 = new Button();
		checkBox_13 = new CheckBox();
		numericUpDown_5 = new NumericUpDown();
		button_20 = new Button();
		textBox_18 = new TextBox();
		button_19 = new Button();
		textBox_16 = new TextBox();
		button_24 = new Button();
		button_22 = new Button();
		button_30 = new Button();
		button_28 = new Button();
		button_25 = new Button();
		button_31 = new Button();
		button_35 = new Button();
		button_32 = new Button();
		button_41 = new Button();
		button_39 = new Button();
		button_37 = new Button();
		button_42 = new Button();
		button_44 = new Button();
		numericUpDown_8 = new NumericUpDown();
		numericUpDown_7 = new NumericUpDown();
		numericUpDown_9 = new NumericUpDown();
		checkBox_27 = new CheckBox();
		button_45 = new Button();
		button_49 = new Button();
		button_47 = new Button();
		button_53 = new Button();
		button_51 = new Button();
		button_56 = new Button();
		button_58 = new Button();
		checkBox_11 = new CheckBox();
		button_12 = new Button();
		textBox_6 = new TextBox();
		label_13 = new Label();
		button_3 = new Button();
		textBox_2 = new TextBox();
		label_2 = new Label();
		button_2 = new Button();
		textBox_1 = new TextBox();
		label_1 = new Label();
		button_1 = new Button();
		textBox_0 = new TextBox();
		label_0 = new Label();
		button_0 = new Button();
		textBox_3 = new TextBox();
		label_3 = new Label();
		numericUpDown_2 = new NumericUpDown();
		label_8 = new Label();
		button_8 = new Button();
		textBox_4 = new TextBox();
		label_5 = new Label();
		button_10 = new Button();
		textBox_5 = new TextBox();
		label_6 = new Label();
		numericUpDown_0 = new NumericUpDown();
		label_4 = new Label();
		checkBox_9 = new CheckBox();
		checkBox_10 = new CheckBox();
		groupBox_0 = new GroupBox();
		label_7 = new Label();
		numericUpDown_1 = new NumericUpDown();
		groupBox_1 = new GroupBox();
		comboBox_0 = new ComboBox();
		tabControl_0 = new TabControl();
		tabPage_0 = new TabPage();
		tableLayoutPanel_0 = new TableLayoutPanel();
		checkBox_21 = new CheckBox();
		numericUpDown_3 = new NumericUpDown();
		checkBox_14 = new CheckBox();
		checkBox_19 = new CheckBox();
		label_46 = new Label();
		tabPage_1 = new TabPage();
		checkBox_22 = new CheckBox();
		checkBox_20 = new CheckBox();
		checkBox_23 = new CheckBox();
		checkBox_24 = new CheckBox();
		checkBox_25 = new CheckBox();
		numericUpDown_10 = new NumericUpDown();
		checkBox_26 = new CheckBox();
		groupBox_12 = new GroupBox();
		checkBox_28 = new CheckBox();
		checkBox_29 = new CheckBox();
		label_47 = new Label();
		groupBox_13 = new GroupBox();
		comboBox_5 = new ComboBox();
		comboBox_3 = new ComboBox();
		label_37 = new Label();
		numericUpDown_4 = new NumericUpDown();
		label_14 = new Label();
		label_15 = new Label();
		checkBox_15 = new CheckBox();
		checkBox_12 = new CheckBox();
		groupBox_2 = new GroupBox();
		comboBox_1 = new ComboBox();
		tabPage_2 = new TabPage();
		textBox_30 = new TextBox();
		label_38 = new Label();
		groupBox_10 = new GroupBox();
		label_55 = new Label();
		tabPage_3 = new TabPage();
		checkBox_17 = new CheckBox();
		button_26 = new Button();
		label_34 = new Label();
		groupBox_5 = new GroupBox();
		checkBox_18 = new CheckBox();
		textBox_27 = new TextBox();
		button_21 = new Button();
		label_32 = new Label();
		textBox_25 = new TextBox();
		groupBox_9 = new GroupBox();
		linkLabel_0 = new LinkLabel();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		groupBox_11 = new GroupBox();
		textBox_38 = new TextBox();
		comboBox_4 = new ComboBox();
		button_27 = new Button();
		textBox_28 = new TextBox();
		label_35 = new Label();
		button_29 = new Button();
		textBox_29 = new TextBox();
		label_36 = new Label();
		button_23 = new Button();
		textBox_26 = new TextBox();
		label_33 = new Label();
		groupBox_4 = new GroupBox();
		button_59 = new Button();
		label_57 = new Label();
		textBox_46 = new TextBox();
		button_57 = new Button();
		label_56 = new Label();
		textBox_45 = new TextBox();
		button_52 = new Button();
		label_52 = new Label();
		textBox_43 = new TextBox();
		button_54 = new Button();
		label_53 = new Label();
		textBox_44 = new TextBox();
		button_48 = new Button();
		label_50 = new Label();
		textBox_41 = new TextBox();
		button_50 = new Button();
		label_51 = new Label();
		textBox_42 = new TextBox();
		button_43 = new Button();
		label_45 = new Label();
		textBox_37 = new TextBox();
		textBox_34 = new TextBox();
		label_42 = new Label();
		button_36 = new Button();
		textBox_35 = new TextBox();
		label_43 = new Label();
		button_38 = new Button();
		textBox_36 = new TextBox();
		label_44 = new Label();
		button_40 = new Button();
		button_33 = new Button();
		label_40 = new Label();
		textBox_32 = new TextBox();
		textBox_33 = new TextBox();
		label_41 = new Label();
		button_34 = new Button();
		button_18 = new Button();
		label_12 = new Label();
		textBox_10 = new TextBox();
		button_16 = new Button();
		label_11 = new Label();
		textBox_9 = new TextBox();
		groupBox_3 = new GroupBox();
		textBox_7 = new TextBox();
		button_14 = new Button();
		label_10 = new Label();
		textBox_8 = new TextBox();
		button_13 = new Button();
		label_9 = new Label();
		tabPage_6 = new TabPage();
		groupBox_15 = new GroupBox();
		linkLabel_2 = new LinkLabel();
		dataGridView_2 = new DataGridView();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		groupBox_14 = new GroupBox();
		linkLabel_1 = new LinkLabel();
		dataGridView_1 = new DataGridView();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		tabPage_4 = new TabPage();
		groupBox_8 = new GroupBox();
		textBox_47 = new TextBox();
		label_58 = new Label();
		textBox_39 = new TextBox();
		label_48 = new Label();
		textBox_40 = new TextBox();
		label_49 = new Label();
		textBox_31 = new TextBox();
		label_39 = new Label();
		textBox_24 = new TextBox();
		label_31 = new Label();
		textBox_21 = new TextBox();
		label_28 = new Label();
		textBox_22 = new TextBox();
		label_29 = new Label();
		textBox_23 = new TextBox();
		label_30 = new Label();
		textBox_19 = new TextBox();
		label_26 = new Label();
		textBox_20 = new TextBox();
		label_27 = new Label();
		label_25 = new Label();
		checkBox_16 = new CheckBox();
		textBox_11 = new TextBox();
		label_16 = new Label();
		groupBox_6 = new GroupBox();
		label_19 = new Label();
		textBox_14 = new TextBox();
		textBox_15 = new TextBox();
		numericUpDown_6 = new NumericUpDown();
		label_20 = new Label();
		label_21 = new Label();
		label_22 = new Label();
		textBox_17 = new TextBox();
		groupBox_7 = new GroupBox();
		comboBox_2 = new ComboBox();
		label_17 = new Label();
		textBox_12 = new TextBox();
		label_18 = new Label();
		textBox_13 = new TextBox();
		label_24 = new Label();
		label_23 = new Label();
		tabPage_5 = new TabPage();
		label_54 = new Label();
		button_46 = new Button();
		propertyGrid_0 = new PropertyGrid();
		bindingSource_0 = new BindingSource(icontainer_0);
		timer_0 = new Timer(icontainer_0);
		groupBox_16.SuspendLayout();
		((ISupportInitialize)numericUpDown_5).BeginInit();
		((ISupportInitialize)numericUpDown_8).BeginInit();
		((ISupportInitialize)numericUpDown_7).BeginInit();
		((ISupportInitialize)numericUpDown_9).BeginInit();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		groupBox_0.SuspendLayout();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		groupBox_1.SuspendLayout();
		tabControl_0.SuspendLayout();
		tabPage_0.SuspendLayout();
		tableLayoutPanel_0.SuspendLayout();
		((ISupportInitialize)numericUpDown_3).BeginInit();
		tabPage_1.SuspendLayout();
		((ISupportInitialize)numericUpDown_10).BeginInit();
		groupBox_12.SuspendLayout();
		groupBox_13.SuspendLayout();
		((ISupportInitialize)numericUpDown_4).BeginInit();
		groupBox_2.SuspendLayout();
		tabPage_2.SuspendLayout();
		groupBox_10.SuspendLayout();
		tabPage_3.SuspendLayout();
		groupBox_5.SuspendLayout();
		groupBox_9.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		groupBox_11.SuspendLayout();
		groupBox_4.SuspendLayout();
		groupBox_3.SuspendLayout();
		tabPage_6.SuspendLayout();
		groupBox_15.SuspendLayout();
		((ISupportInitialize)dataGridView_2).BeginInit();
		groupBox_14.SuspendLayout();
		((ISupportInitialize)dataGridView_1).BeginInit();
		tabPage_4.SuspendLayout();
		groupBox_8.SuspendLayout();
		groupBox_6.SuspendLayout();
		((ISupportInitialize)numericUpDown_6).BeginInit();
		groupBox_7.SuspendLayout();
		tabPage_5.SuspendLayout();
		((ISupportInitialize)bindingSource_0).BeginInit();
		SuspendLayout();
		groupBox_16.Controls.Add(checkBox_31);
		groupBox_16.Controls.Add(checkBox_30);
		groupBox_16.Controls.Add(checkBox_7);
		groupBox_16.Location = new Point(1176, 400);
		groupBox_16.Margin = new Padding(3, 4, 3, 4);
		groupBox_16.Name = Class16.smethod_0(1649156978);
		groupBox_16.Padding = new Padding(3, 4, 3, 4);
		groupBox_16.Size = new Size(277, 72);
		groupBox_16.TabIndex = 0;
		groupBox_16.TabStop = false;
		groupBox_16.Visible = false;
		checkBox_31.AutoSize = true;
		checkBox_31.Checked = true;
		checkBox_31.CheckState = CheckState.Checked;
		checkBox_31.Location = new Point(11, 21);
		checkBox_31.Margin = new Padding(3, 4, 3, 4);
		checkBox_31.Name = Class16.smethod_0(1649156994);
		checkBox_31.Size = new Size(147, 17);
		checkBox_31.TabIndex = 1;
		checkBox_31.Text = Class16.smethod_0(1649157017);
		checkBox_31.UseVisualStyleBackColor = true;
		checkBox_30.AutoSize = true;
		checkBox_30.Checked = true;
		checkBox_30.CheckState = CheckState.Checked;
		checkBox_30.Location = new Point(7, 0);
		checkBox_30.Margin = new Padding(3, 4, 3, 4);
		checkBox_30.Name = Class16.smethod_0(1649157055);
		checkBox_30.Size = new Size(122, 17);
		checkBox_30.TabIndex = 4;
		checkBox_30.Text = Class16.smethod_0(1649157079);
		checkBox_30.UseVisualStyleBackColor = true;
		checkBox_30.CheckedChanged += checkBox_30_CheckedChanged;
		checkBox_7.AutoSize = true;
		checkBox_7.Checked = true;
		checkBox_7.CheckState = CheckState.Checked;
		checkBox_7.Enabled = false;
		checkBox_7.Location = new Point(-5, 0);
		checkBox_7.Margin = new Padding(3, 4, 3, 4);
		checkBox_7.Name = Class16.smethod_0(1649157097);
		checkBox_7.Size = new Size(180, 17);
		checkBox_7.TabIndex = 13;
		checkBox_7.Text = Class16.smethod_0(1649156102);
		checkBox_7.UseVisualStyleBackColor = true;
		checkBox_7.Visible = false;
		button_55.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_55.DialogResult = DialogResult.OK;
		button_55.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_55.Image = Resources.SettingsWindow_cmdsave;
		button_55.ImageAlign = ContentAlignment.MiddleRight;
		button_55.Location = new Point(5, 597);
		button_55.Margin = new Padding(3, 4, 3, 4);
		button_55.Name = Class16.smethod_0(1649156129);
		button_55.Size = new Size(295, 38);
		button_55.TabIndex = 6;
		button_55.Text = Class16.smethod_0(1648941761);
		button_55.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_55.UseVisualStyleBackColor = true;
		button_55.Click += button_55_Click;
		checkBox_0.AutoSize = true;
		checkBox_0.Checked = true;
		checkBox_0.CheckState = CheckState.Checked;
		checkBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_0.Location = new Point(15, 11);
		checkBox_0.Margin = new Padding(3, 4, 3, 4);
		checkBox_0.Name = Class16.smethod_0(1649156151);
		checkBox_0.Size = new Size(134, 17);
		checkBox_0.TabIndex = 2;
		checkBox_0.Text = Class16.smethod_0(1649156173);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_1.AutoSize = true;
		checkBox_1.Checked = true;
		checkBox_1.CheckState = CheckState.Checked;
		checkBox_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_1.Location = new Point(15, 30);
		checkBox_1.Margin = new Padding(3, 4, 3, 4);
		checkBox_1.Name = Class16.smethod_0(1649156193);
		checkBox_1.Size = new Size(148, 17);
		checkBox_1.TabIndex = 5;
		checkBox_1.Text = Class16.smethod_0(1649156223);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_2.AutoSize = true;
		checkBox_2.Checked = true;
		checkBox_2.CheckState = CheckState.Checked;
		checkBox_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_2.Location = new Point(282, 78);
		checkBox_2.Margin = new Padding(3, 4, 3, 4);
		checkBox_2.Name = Class16.smethod_0(1649156254);
		checkBox_2.Size = new Size(215, 17);
		checkBox_2.TabIndex = 6;
		checkBox_2.Text = Class16.smethod_0(1649156267);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_4.AutoSize = true;
		checkBox_4.Checked = true;
		checkBox_4.CheckState = CheckState.Checked;
		checkBox_4.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_4.Location = new Point(282, 97);
		checkBox_4.Margin = new Padding(3, 4, 3, 4);
		checkBox_4.Name = Class16.smethod_0(1649156319);
		checkBox_4.Size = new Size(224, 17);
		checkBox_4.TabIndex = 9;
		checkBox_4.Text = Class16.smethod_0(1649156339);
		toolTip_0.SetToolTip(checkBox_4, Class16.smethod_0(1649156390));
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_6.AutoSize = true;
		checkBox_6.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_6.Location = new Point(358, 54);
		checkBox_6.Margin = new Padding(3, 4, 3, 4);
		checkBox_6.Name = Class16.smethod_0(1649156590);
		checkBox_6.Size = new Size(139, 17);
		checkBox_6.TabIndex = 12;
		checkBox_6.Text = Class16.smethod_0(1649159681);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_5.AutoSize = true;
		checkBox_5.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_5.Location = new Point(3, 54);
		checkBox_5.Margin = new Padding(3, 4, 3, 4);
		checkBox_5.Name = Class16.smethod_0(1649159707);
		checkBox_5.Size = new Size(145, 17);
		checkBox_5.TabIndex = 10;
		checkBox_5.Text = Class16.smethod_0(1649159731);
		toolTip_0.SetToolTip(checkBox_5, Class16.smethod_0(1649159761));
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_3.AutoSize = true;
		checkBox_3.Checked = true;
		checkBox_3.CheckState = CheckState.Checked;
		checkBox_3.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_3.Location = new Point(358, 29);
		checkBox_3.Margin = new Padding(3, 4, 3, 4);
		checkBox_3.Name = Class16.smethod_0(1649159900);
		checkBox_3.Size = new Size(153, 17);
		checkBox_3.TabIndex = 8;
		checkBox_3.Text = Class16.smethod_0(1649159928);
		toolTip_0.SetToolTip(checkBox_3, componentResourceManager.GetString(Class16.smethod_0(1649159966)));
		checkBox_3.UseVisualStyleBackColor = true;
		toolTip_0.AutoPopDelay = 20000;
		toolTip_0.InitialDelay = 500;
		toolTip_0.ReshowDelay = 100;
		button_4.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_4.Image = Resources.cmdExtDescInfo;
		button_4.Location = new Point(5, 39);
		button_4.Name = Class16.smethod_0(1649188265);
		button_4.Size = new Size(26, 22);
		button_4.TabIndex = 16;
		toolTip_0.SetToolTip(button_4, Class16.smethod_0(1649160002));
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		button_6.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_6.Image = Resources.cmdItemColorInfo;
		button_6.Location = new Point(5, 63);
		button_6.Name = Class16.smethod_0(1649187333);
		button_6.Size = new Size(26, 22);
		button_6.TabIndex = 17;
		toolTip_0.SetToolTip(button_6, Class16.smethod_0(1649160002));
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		button_5.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_5.Image = Resources.cmdTasksInfo;
		button_5.Location = new Point(4, 240);
		button_5.Name = Class16.smethod_0(1649187713);
		button_5.Size = new Size(26, 22);
		button_5.TabIndex = 18;
		toolTip_0.SetToolTip(button_5, Class16.smethod_0(1649160002));
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		checkBox_8.AutoSize = true;
		checkBox_8.Checked = true;
		checkBox_8.CheckState = CheckState.Checked;
		checkBox_8.Location = new Point(16, 77);
		checkBox_8.Margin = new Padding(3, 4, 3, 4);
		checkBox_8.Name = Class16.smethod_0(1649160039);
		checkBox_8.Size = new Size(313, 17);
		checkBox_8.TabIndex = 22;
		checkBox_8.Text = Class16.smethod_0(1649160050);
		toolTip_0.SetToolTip(checkBox_8, Class16.smethod_0(1649160113));
		checkBox_8.UseVisualStyleBackColor = true;
		button_9.Image = Resources.cmdIconsDDSInfo;
		button_9.Location = new Point(13, 22);
		button_9.Name = Class16.smethod_0(1649188305);
		button_9.Size = new Size(26, 22);
		button_9.TabIndex = 26;
		toolTip_0.SetToolTip(button_9, Class16.smethod_0(1649160002));
		button_9.UseVisualStyleBackColor = true;
		button_9.Click += button_9_Click;
		button_7.Image = Resources.cmdIconsTXTInfo;
		button_7.Location = new Point(13, 49);
		button_7.Name = Class16.smethod_0(1649188335);
		button_7.Size = new Size(26, 22);
		button_7.TabIndex = 30;
		toolTip_0.SetToolTip(button_7, Class16.smethod_0(1649160002));
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		button_11.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_11.Image = Resources.cmdPathDataInfo;
		button_11.Location = new Point(4, 265);
		button_11.Name = Class16.smethod_0(1649187454);
		button_11.Size = new Size(26, 22);
		button_11.TabIndex = 22;
		toolTip_0.SetToolTip(button_11, Class16.smethod_0(1649160002));
		button_11.UseVisualStyleBackColor = true;
		button_11.Click += button_11_Click;
		button_15.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_15.Image = Resources.cmdGShopInfo;
		button_15.Location = new Point(4, 43);
		button_15.Name = Class16.smethod_0(1649188294);
		button_15.Size = new Size(26, 22);
		button_15.TabIndex = 44;
		toolTip_0.SetToolTip(button_15, Class16.smethod_0(1649160002));
		button_15.UseVisualStyleBackColor = true;
		button_15.Click += button_15_Click;
		button_17.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_17.Image = Resources.cmdNPCGenInfo;
		button_17.Location = new Point(4, 287);
		button_17.Name = Class16.smethod_0(1649187373);
		button_17.Size = new Size(26, 22);
		button_17.TabIndex = 48;
		toolTip_0.SetToolTip(button_17, Class16.smethod_0(1649160002));
		button_17.UseVisualStyleBackColor = true;
		button_17.Click += button_17_Click;
		checkBox_13.AutoSize = true;
		checkBox_13.Checked = true;
		checkBox_13.CheckState = CheckState.Checked;
		checkBox_13.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_13.Location = new Point(282, 59);
		checkBox_13.Margin = new Padding(3, 4, 3, 4);
		checkBox_13.Name = Class16.smethod_0(1649159195);
		checkBox_13.Size = new Size(284, 17);
		checkBox_13.TabIndex = 47;
		checkBox_13.Text = Class16.smethod_0(1649159244);
		toolTip_0.SetToolTip(checkBox_13, Class16.smethod_0(1649159289));
		checkBox_13.UseVisualStyleBackColor = true;
		numericUpDown_5.Location = new Point(223, 69);
		numericUpDown_5.Maximum = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_5.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_5.Name = Class16.smethod_0(1649159390);
		numericUpDown_5.Size = new Size(53, 22);
		numericUpDown_5.TabIndex = 50;
		numericUpDown_5.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(numericUpDown_5, Class16.smethod_0(1649159411));
		numericUpDown_5.Value = new decimal(new int[4] { 5000, 0, 0, 0 });
		button_20.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_20.Image = Resources.cmdSSHCompressInfo;
		button_20.Location = new Point(141, 314);
		button_20.Name = Class16.smethod_0(1649187671);
		button_20.Size = new Size(26, 22);
		button_20.TabIndex = 19;
		toolTip_0.SetToolTip(button_20, Class16.smethod_0(1649160002));
		button_20.UseVisualStyleBackColor = true;
		button_20.Click += button_20_Click;
		textBox_18.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_18.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_18.Location = new Point(89, 17);
		textBox_18.Margin = new Padding(3, 4, 3, 4);
		textBox_18.Name = Class16.smethod_0(1649159439);
		textBox_18.Size = new Size(429, 22);
		textBox_18.TabIndex = 21;
		toolTip_0.SetToolTip(textBox_18, Class16.smethod_0(1649159462));
		button_19.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_19.Image = Resources.cmdSetConfigPath;
		button_19.Location = new Point(521, 17);
		button_19.Name = Class16.smethod_0(1649187623);
		button_19.Size = new Size(26, 22);
		button_19.TabIndex = 22;
		toolTip_0.SetToolTip(button_19, Class16.smethod_0(1649159554));
		button_19.UseVisualStyleBackColor = true;
		button_19.Click += button_19_Click;
		textBox_16.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_16.Location = new Point(324, 47);
		textBox_16.Margin = new Padding(3, 4, 3, 4);
		textBox_16.Name = Class16.smethod_0(1649159603);
		textBox_16.PasswordChar = '*';
		textBox_16.Size = new Size(223, 22);
		textBox_16.TabIndex = 42;
		toolTip_0.SetToolTip(textBox_16, Class16.smethod_0(1649159628));
		textBox_16.UseSystemPasswordChar = true;
		button_24.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_24.Image = Resources.cmdAboutConfigsPck;
		button_24.Location = new Point(5, 22);
		button_24.Name = Class16.smethod_0(1649185147);
		button_24.Size = new Size(26, 22);
		button_24.TabIndex = 17;
		toolTip_0.SetToolTip(button_24, Class16.smethod_0(1649160002));
		button_24.UseVisualStyleBackColor = true;
		button_24.Visible = false;
		button_24.Click += button_24_Click;
		button_22.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_22.Image = Resources.cmdClientInfo;
		button_22.Location = new Point(9, 7);
		button_22.Name = Class16.smethod_0(1649188253);
		button_22.Size = new Size(26, 22);
		button_22.TabIndex = 51;
		toolTip_0.SetToolTip(button_22, Class16.smethod_0(1649160002));
		button_22.UseVisualStyleBackColor = true;
		button_22.Click += button_22_Click;
		button_30.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_30.Image = Resources.cmdAboutSurfacesPck;
		button_30.Location = new Point(5, 46);
		button_30.Name = Class16.smethod_0(1649188522);
		button_30.Size = new Size(26, 22);
		button_30.TabIndex = 22;
		toolTip_0.SetToolTip(button_30, Class16.smethod_0(1649160002));
		button_30.UseVisualStyleBackColor = true;
		button_30.Visible = false;
		button_30.Click += button_30_Click;
		button_28.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_28.Image = Resources.cmdAboutModelsPck;
		button_28.Location = new Point(5, 70);
		button_28.Name = Class16.smethod_0(1649188498);
		button_28.Size = new Size(26, 22);
		button_28.TabIndex = 26;
		toolTip_0.SetToolTip(button_28, Class16.smethod_0(1649160002));
		button_28.UseVisualStyleBackColor = true;
		button_28.Visible = false;
		button_28.Click += button_28_Click;
		button_25.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_25.Image = Resources.cmdSurfacesDirInfo;
		button_25.Location = new Point(3, 975);
		button_25.Name = Class16.smethod_0(1649187688);
		button_25.Size = new Size(26, 22);
		button_25.TabIndex = 34;
		toolTip_0.SetToolTip(button_25, Class16.smethod_0(1649160002));
		button_25.UseVisualStyleBackColor = true;
		button_25.Click += button_25_Click;
		button_31.Image = Resources.cmdAboutFileIcon;
		button_31.Location = new Point(550, 9);
		button_31.Name = Class16.smethod_0(1649185276);
		button_31.Size = new Size(26, 22);
		button_31.TabIndex = 36;
		toolTip_0.SetToolTip(button_31, Class16.smethod_0(1649160002));
		button_31.UseVisualStyleBackColor = true;
		button_31.Click += button_31_Click;
		button_35.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_35.Image = Resources.cmdAboutAIPolicy;
		button_35.Location = new Point(4, 311);
		button_35.Name = Class16.smethod_0(1649185132);
		button_35.Size = new Size(26, 22);
		button_35.TabIndex = 52;
		toolTip_0.SetToolTip(button_35, Class16.smethod_0(1649160002));
		button_35.UseVisualStyleBackColor = true;
		button_35.Click += button_35_Click;
		button_32.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_32.Image = Resources.cmdAboutGShopSev;
		button_32.Location = new Point(4, 141);
		button_32.Name = Class16.smethod_0(1649188427);
		button_32.Size = new Size(26, 22);
		button_32.TabIndex = 56;
		toolTip_0.SetToolTip(button_32, Class16.smethod_0(1649160002));
		button_32.UseVisualStyleBackColor = true;
		button_32.Click += button_32_Click;
		button_41.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_41.Image = Resources.cmdAboutDomainSev;
		button_41.Location = new Point(4, 334);
		button_41.Name = Class16.smethod_0(1649185205);
		button_41.Size = new Size(26, 22);
		button_41.TabIndex = 60;
		toolTip_0.SetToolTip(button_41, Class16.smethod_0(1649160002));
		button_41.UseVisualStyleBackColor = true;
		button_41.Click += button_41_Click;
		button_39.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_39.Image = Resources.cmdAboutDomain2Sev;
		button_39.Location = new Point(4, 357);
		button_39.Name = Class16.smethod_0(1649185180);
		button_39.Size = new Size(26, 22);
		button_39.TabIndex = 64;
		toolTip_0.SetToolTip(button_39, Class16.smethod_0(1649160002));
		button_39.UseVisualStyleBackColor = true;
		button_39.Click += button_39_Click;
		button_37.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_37.Image = Resources.cmdAboutExtraDrop;
		button_37.Location = new Point(4, 380);
		button_37.Name = Class16.smethod_0(1649185252);
		button_37.Size = new Size(26, 22);
		button_37.TabIndex = 68;
		toolTip_0.SetToolTip(button_37, Class16.smethod_0(1649160002));
		button_37.UseVisualStyleBackColor = true;
		button_37.Click += button_37_Click;
		button_42.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_42.Image = Resources.cmdAboutElements;
		button_42.Location = new Point(4, 20);
		button_42.Name = Class16.smethod_0(1649185229);
		button_42.Size = new Size(26, 22);
		button_42.TabIndex = 72;
		toolTip_0.SetToolTip(button_42, Class16.smethod_0(1649160002));
		button_42.UseVisualStyleBackColor = true;
		button_42.Click += button_42_Click;
		button_44.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_44.Image = Resources.cmdSetDefaultPaths;
		button_44.Location = new Point(531, 8);
		button_44.Name = Class16.smethod_0(1649187646);
		button_44.Size = new Size(26, 22);
		button_44.TabIndex = 52;
		toolTip_0.SetToolTip(button_44, Class16.smethod_0(1649159554));
		button_44.UseVisualStyleBackColor = true;
		button_44.Click += button_44_Click;
		numericUpDown_8.Increment = new decimal(new int[4]);
		numericUpDown_8.Location = new Point(118, 17);
		numericUpDown_8.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_8.Minimum = new decimal(new int[4] { 2147483647, 0, 0, -2147483648 });
		numericUpDown_8.Name = Class16.smethod_0(1649159672);
		numericUpDown_8.Size = new Size(208, 22);
		numericUpDown_8.TabIndex = 47;
		toolTip_0.SetToolTip(numericUpDown_8, Class16.smethod_0(1649158665));
		numericUpDown_7.Increment = new decimal(new int[4]);
		numericUpDown_7.Location = new Point(332, 17);
		numericUpDown_7.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_7.Minimum = new decimal(new int[4] { 2147483647, 0, 0, -2147483648 });
		numericUpDown_7.Name = Class16.smethod_0(1649158685);
		numericUpDown_7.Size = new Size(208, 22);
		numericUpDown_7.TabIndex = 48;
		toolTip_0.SetToolTip(numericUpDown_7, Class16.smethod_0(1649158702));
		numericUpDown_9.Location = new Point(358, 78);
		numericUpDown_9.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		numericUpDown_9.Name = Class16.smethod_0(1649158706);
		numericUpDown_9.Size = new Size(81, 22);
		numericUpDown_9.TabIndex = 60;
		numericUpDown_9.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(numericUpDown_9, Class16.smethod_0(1649158737));
		numericUpDown_9.Value = new decimal(new int[4] { 30, 0, 0, 0 });
		checkBox_27.AutoSize = true;
		checkBox_27.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_27.Location = new Point(11, 249);
		checkBox_27.Margin = new Padding(3, 4, 3, 4);
		checkBox_27.Name = Class16.smethod_0(1649158785);
		checkBox_27.Size = new Size(462, 17);
		checkBox_27.TabIndex = 59;
		checkBox_27.Text = Class16.smethod_0(1649158820);
		toolTip_0.SetToolTip(checkBox_27, Class16.smethod_0(1649158820));
		checkBox_27.UseVisualStyleBackColor = true;
		button_45.Image = Resources.cmdAboutFilters;
		button_45.Location = new Point(208, 44);
		button_45.Name = Class16.smethod_0(1649188363);
		button_45.Size = new Size(26, 22);
		button_45.TabIndex = 14;
		toolTip_0.SetToolTip(button_45, Class16.smethod_0(1649160002));
		button_45.UseVisualStyleBackColor = true;
		button_45.Click += button_45_Click;
		button_49.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_49.Image = Resources.cmdAboutGShopSev1;
		button_49.Location = new Point(4, 164);
		button_49.Name = Class16.smethod_0(1649188450);
		button_49.Size = new Size(26, 22);
		button_49.TabIndex = 76;
		toolTip_0.SetToolTip(button_49, Class16.smethod_0(1649160002));
		button_49.UseVisualStyleBackColor = true;
		button_49.Click += button_49_Click;
		button_47.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_47.Image = Resources.cmdAboutGShopSev2;
		button_47.Location = new Point(4, 187);
		button_47.Name = Class16.smethod_0(1649188474);
		button_47.Size = new Size(26, 22);
		button_47.TabIndex = 80;
		toolTip_0.SetToolTip(button_47, Class16.smethod_0(1649160002));
		button_47.UseVisualStyleBackColor = true;
		button_47.Click += button_47_Click;
		button_53.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_53.Image = Resources.cmdAboutGShop1;
		button_53.Location = new Point(4, 66);
		button_53.Name = Class16.smethod_0(1649188385);
		button_53.Size = new Size(26, 22);
		button_53.TabIndex = 84;
		toolTip_0.SetToolTip(button_53, Class16.smethod_0(1649160002));
		button_53.UseVisualStyleBackColor = true;
		button_53.Click += button_53_Click;
		button_51.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_51.Image = Resources.cmdAboutGShop2;
		button_51.Location = new Point(4, 89);
		button_51.Name = Class16.smethod_0(1649188414);
		button_51.Size = new Size(26, 22);
		button_51.TabIndex = 88;
		toolTip_0.SetToolTip(button_51, Class16.smethod_0(1649160002));
		button_51.UseVisualStyleBackColor = true;
		button_51.Click += button_51_Click;
		button_56.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_56.Image = Resources.cmdAboutGShop2;
		button_56.Location = new Point(5, 116);
		button_56.Name = Class16.smethod_0(1649158904);
		button_56.Size = new Size(26, 22);
		button_56.TabIndex = 92;
		toolTip_0.SetToolTip(button_56, Class16.smethod_0(1649160002));
		button_56.UseVisualStyleBackColor = true;
		button_56.Click += button_56_Click;
		button_58.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_58.Image = Resources.cmdAboutGShopSev2;
		button_58.Location = new Point(4, 213);
		button_58.Name = Class16.smethod_0(1649158933);
		button_58.Size = new Size(26, 22);
		button_58.TabIndex = 96;
		toolTip_0.SetToolTip(button_58, Class16.smethod_0(1649160002));
		button_58.UseVisualStyleBackColor = true;
		button_58.Click += button_58_Click;
		checkBox_11.AutoSize = true;
		checkBox_11.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_11.Location = new Point(3, 29);
		checkBox_11.Margin = new Padding(3, 4, 3, 4);
		checkBox_11.Name = Class16.smethod_0(1649158957);
		checkBox_11.Size = new Size(187, 17);
		checkBox_11.TabIndex = 43;
		checkBox_11.Text = Class16.smethod_0(1649158969);
		checkBox_11.UseVisualStyleBackColor = true;
		button_12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_12.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_12.Image = Resources.cmdBrowsePathData;
		button_12.Location = new Point(528, 264);
		button_12.Margin = new Padding(3, 4, 3, 4);
		button_12.Name = Class16.smethod_0(1649188043);
		button_12.Size = new Size(26, 23);
		button_12.TabIndex = 21;
		button_12.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_12.UseVisualStyleBackColor = true;
		button_12.Click += button_12_Click;
		textBox_6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_6.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_6.Location = new Point(124, 265);
		textBox_6.Margin = new Padding(3, 4, 3, 4);
		textBox_6.Name = Class16.smethod_0(1649159009);
		textBox_6.Size = new Size(403, 22);
		textBox_6.TabIndex = 20;
		label_13.AutoSize = true;
		label_13.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_13.Location = new Point(30, 267);
		label_13.Name = Class16.smethod_0(1649159039);
		label_13.Size = new Size(57, 13);
		label_13.TabIndex = 19;
		label_13.Text = Class16.smethod_0(1648908925);
		button_3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_3.Image = Resources.cmdBrowseTasks;
		button_3.Location = new Point(528, 241);
		button_3.Margin = new Padding(3, 4, 3, 4);
		button_3.Name = Class16.smethod_0(1649188205);
		button_3.Size = new Size(26, 23);
		button_3.TabIndex = 15;
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		textBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_2.Location = new Point(124, 241);
		textBox_2.Margin = new Padding(3, 4, 3, 4);
		textBox_2.Name = Class16.smethod_0(1649159053);
		textBox_2.Size = new Size(403, 22);
		textBox_2.TabIndex = 14;
		label_2.AutoSize = true;
		label_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_2.Location = new Point(30, 243);
		label_2.Name = Class16.smethod_0(1649159064);
		label_2.Size = new Size(59, 13);
		label_2.TabIndex = 13;
		label_2.Text = Class16.smethod_0(1648910178);
		button_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_2.Image = Resources.cmdBrowseColor;
		button_2.Location = new Point(524, 63);
		button_2.Margin = new Padding(3, 4, 3, 4);
		button_2.Name = Class16.smethod_0(1649188646);
		button_2.Size = new Size(26, 22);
		button_2.TabIndex = 12;
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_1.Location = new Point(123, 63);
		textBox_1.Margin = new Padding(3, 4, 3, 4);
		textBox_1.Name = Class16.smethod_0(1649159087);
		textBox_1.Size = new Size(400, 22);
		textBox_1.TabIndex = 11;
		label_1.AutoSize = true;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_1.Location = new Point(31, 66);
		label_1.Name = Class16.smethod_0(1649159099);
		label_1.Size = new Size(66, 15);
		label_1.TabIndex = 10;
		label_1.Text = Class16.smethod_0(1649159127);
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.cmdBrowseDesc;
		button_1.Location = new Point(524, 39);
		button_1.Margin = new Padding(3, 4, 3, 4);
		button_1.Name = Class16.smethod_0(1649188693);
		button_1.Size = new Size(26, 22);
		button_1.TabIndex = 9;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_0.Location = new Point(123, 39);
		textBox_0.Margin = new Padding(3, 4, 3, 4);
		textBox_0.Name = Class16.smethod_0(1649159136);
		textBox_0.Size = new Size(400, 22);
		textBox_0.TabIndex = 8;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_0.Location = new Point(31, 42);
		label_0.Name = Class16.smethod_0(1649159162);
		label_0.Size = new Size(79, 13);
		label_0.TabIndex = 7;
		label_0.Text = Class16.smethod_0(1649158161);
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.cmdcancel;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(301, 597);
		button_0.Name = Class16.smethod_0(1648925752);
		button_0.Size = new Size(294, 38);
		button_0.TabIndex = 9;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648941799);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		textBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_3.Location = new Point(166, 118);
		textBox_3.Margin = new Padding(3, 4, 3, 4);
		textBox_3.Name = Class16.smethod_0(1649158189);
		textBox_3.Size = new Size(403, 22);
		textBox_3.TabIndex = 15;
		label_3.Location = new Point(13, 120);
		label_3.Name = Class16.smethod_0(1649158213);
		label_3.Size = new Size(152, 16);
		label_3.TabIndex = 14;
		label_3.Text = Class16.smethod_0(1649158237);
		label_3.TextAlign = ContentAlignment.MiddleRight;
		numericUpDown_2.Location = new Point(243, 97);
		numericUpDown_2.Maximum = new decimal(new int[4] { 256, 0, 0, 0 });
		numericUpDown_2.Minimum = new decimal(new int[4] { 8, 0, 0, 0 });
		numericUpDown_2.Name = Class16.smethod_0(1649158260);
		numericUpDown_2.Size = new Size(62, 22);
		numericUpDown_2.TabIndex = 32;
		numericUpDown_2.TextAlign = HorizontalAlignment.Center;
		numericUpDown_2.Value = new decimal(new int[4] { 20, 0, 0, 0 });
		label_8.Location = new Point(13, 99);
		label_8.Name = Class16.smethod_0(1649158273);
		label_8.Size = new Size(224, 16);
		label_8.TabIndex = 31;
		label_8.Text = Class16.smethod_0(1649158299);
		label_8.TextAlign = ContentAlignment.MiddleRight;
		button_8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_8.Image = Resources.cmdBrowseIconsTXT;
		button_8.Location = new Point(531, 48);
		button_8.Margin = new Padding(3, 4, 3, 4);
		button_8.Name = Class16.smethod_0(1649187944);
		button_8.Size = new Size(26, 22);
		button_8.TabIndex = 29;
		button_8.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_8.UseVisualStyleBackColor = true;
		button_8.Click += button_8_Click;
		textBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_4.Location = new Point(138, 49);
		textBox_4.Margin = new Padding(3, 4, 3, 4);
		textBox_4.Name = Class16.smethod_0(1649158349);
		textBox_4.Size = new Size(391, 22);
		textBox_4.TabIndex = 28;
		label_5.AutoSize = true;
		label_5.Location = new Point(39, 51);
		label_5.Name = Class16.smethod_0(1649158373);
		label_5.Size = new Size(81, 13);
		label_5.TabIndex = 27;
		label_5.Text = Class16.smethod_0(1649158397);
		button_10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_10.Image = Resources.cmdBrowseIconsDDS;
		button_10.Location = new Point(531, 21);
		button_10.Margin = new Padding(3, 4, 3, 4);
		button_10.Name = Class16.smethod_0(1649187920);
		button_10.Size = new Size(26, 22);
		button_10.TabIndex = 25;
		button_10.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_10.UseVisualStyleBackColor = true;
		button_10.Click += button_10_Click;
		textBox_5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_5.Location = new Point(138, 22);
		textBox_5.Margin = new Padding(3, 4, 3, 4);
		textBox_5.Name = Class16.smethod_0(1649158421);
		textBox_5.Size = new Size(391, 22);
		textBox_5.TabIndex = 24;
		label_6.AutoSize = true;
		label_6.Location = new Point(39, 24);
		label_6.Name = Class16.smethod_0(1649158432);
		label_6.Size = new Size(87, 13);
		label_6.TabIndex = 23;
		label_6.Text = Class16.smethod_0(1649158456);
		numericUpDown_0.Location = new Point(243, 55);
		numericUpDown_0.Maximum = new decimal(new int[4] { 256, 0, 0, 0 });
		numericUpDown_0.Minimum = new decimal(new int[4] { 8, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1649158480);
		numericUpDown_0.Size = new Size(62, 22);
		numericUpDown_0.TabIndex = 17;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.Value = new decimal(new int[4] { 20, 0, 0, 0 });
		label_4.Location = new Point(14, 55);
		label_4.Name = Class16.smethod_0(1649158499);
		label_4.Size = new Size(223, 16);
		label_4.TabIndex = 16;
		label_4.Text = Class16.smethod_0(1649158526);
		label_4.TextAlign = ContentAlignment.MiddleRight;
		checkBox_9.AutoSize = true;
		checkBox_9.Checked = true;
		checkBox_9.CheckState = CheckState.Checked;
		checkBox_9.Location = new Point(16, 32);
		checkBox_9.Margin = new Padding(3, 4, 3, 4);
		checkBox_9.Name = Class16.smethod_0(1649158555);
		checkBox_9.Size = new Size(180, 17);
		checkBox_9.TabIndex = 13;
		checkBox_9.Text = Class16.smethod_0(1649158583);
		checkBox_9.UseVisualStyleBackColor = true;
		checkBox_10.AutoSize = true;
		checkBox_10.Checked = true;
		checkBox_10.CheckState = CheckState.Checked;
		checkBox_10.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		checkBox_10.Location = new Point(16, 7);
		checkBox_10.Margin = new Padding(3, 4, 3, 4);
		checkBox_10.Name = Class16.smethod_0(1649158620);
		checkBox_10.Size = new Size(138, 19);
		checkBox_10.TabIndex = 11;
		checkBox_10.Text = Class16.smethod_0(1649158639);
		checkBox_10.UseVisualStyleBackColor = true;
		checkBox_10.CheckedChanged += checkBox_10_CheckedChanged;
		groupBox_0.Controls.Add(label_7);
		groupBox_0.Controls.Add(numericUpDown_1);
		groupBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		groupBox_0.Location = new Point(287, 9);
		groupBox_0.Name = Class16.smethod_0(1649153537);
		groupBox_0.Size = new Size(282, 51);
		groupBox_0.TabIndex = 38;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1649153564);
		label_7.BackColor = Color.FromArgb(32, 32, 32);
		label_7.BorderStyle = BorderStyle.FixedSingle;
		label_7.ForeColor = Color.FromArgb(255, 120, 0);
		label_7.Location = new Point(10, 22);
		label_7.Name = Class16.smethod_0(1649153588);
		label_7.Size = new Size(183, 18);
		label_7.TabIndex = 15;
		label_7.Text = Class16.smethod_0(1649153601);
		label_7.TextAlign = ContentAlignment.MiddleCenter;
		numericUpDown_1.BackColor = Color.White;
		numericUpDown_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		numericUpDown_1.ForeColor = Color.Black;
		numericUpDown_1.Location = new Point(197, 20);
		numericUpDown_1.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_1.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		numericUpDown_1.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_1.Name = Class16.smethod_0(1649145162);
		numericUpDown_1.Size = new Size(75, 23);
		numericUpDown_1.TabIndex = 16;
		numericUpDown_1.TextAlign = HorizontalAlignment.Center;
		numericUpDown_1.Value = new decimal(new int[4] { 150, 0, 0, 0 });
		groupBox_1.Controls.Add(comboBox_0);
		groupBox_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		groupBox_1.Location = new Point(11, 9);
		groupBox_1.Name = Class16.smethod_0(1649153626);
		groupBox_1.Size = new Size(270, 52);
		groupBox_1.TabIndex = 39;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1648907720);
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(8, 20);
		comboBox_0.Name = Class16.smethod_0(1649153652);
		comboBox_0.Size = new Size(253, 21);
		comboBox_0.TabIndex = 37;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		tabControl_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tabControl_0.Controls.Add(tabPage_0);
		tabControl_0.Controls.Add(tabPage_1);
		tabControl_0.Controls.Add(tabPage_2);
		tabControl_0.Controls.Add(tabPage_3);
		tabControl_0.Controls.Add(tabPage_6);
		tabControl_0.Controls.Add(tabPage_4);
		tabControl_0.Controls.Add(tabPage_5);
		tabControl_0.Location = new Point(5, 8);
		tabControl_0.Name = Class16.smethod_0(1649153671);
		tabControl_0.SelectedIndex = 0;
		tabControl_0.Size = new Size(590, 587);
		tabControl_0.TabIndex = 33;
		tabControl_0.SelectedIndexChanged += tabControl_0_SelectedIndexChanged;
		tabPage_0.Controls.Add(tableLayoutPanel_0);
		tabPage_0.Controls.Add(groupBox_1);
		tabPage_0.Controls.Add(groupBox_0);
		tabPage_0.Location = new Point(4, 22);
		tabPage_0.Name = Class16.smethod_0(1649153683);
		tabPage_0.Padding = new Padding(3);
		tabPage_0.Size = new Size(582, 561);
		tabPage_0.TabIndex = 0;
		tabPage_0.Text = Class16.smethod_0(1649105744);
		tabPage_0.UseVisualStyleBackColor = true;
		tableLayoutPanel_0.ColumnCount = 2;
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37f));
		tableLayoutPanel_0.Controls.Add(checkBox_21, 0, 0);
		tableLayoutPanel_0.Controls.Add(numericUpDown_3, 1, 4);
		tableLayoutPanel_0.Controls.Add(numericUpDown_9, 1, 3);
		tableLayoutPanel_0.Controls.Add(checkBox_14, 0, 4);
		tableLayoutPanel_0.Controls.Add(checkBox_11, 0, 1);
		tableLayoutPanel_0.Controls.Add(checkBox_19, 1, 0);
		tableLayoutPanel_0.Controls.Add(checkBox_3, 1, 1);
		tableLayoutPanel_0.Controls.Add(checkBox_5, 0, 2);
		tableLayoutPanel_0.Controls.Add(checkBox_6, 1, 2);
		tableLayoutPanel_0.Controls.Add(label_46, 0, 3);
		tableLayoutPanel_0.Location = new Point(6, 67);
		tableLayoutPanel_0.Name = Class16.smethod_0(1648929366);
		tableLayoutPanel_0.RowCount = 5;
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
		tableLayoutPanel_0.Size = new Size(565, 126);
		tableLayoutPanel_0.TabIndex = 63;
		checkBox_21.AutoSize = true;
		checkBox_21.Checked = true;
		checkBox_21.CheckState = CheckState.Checked;
		checkBox_21.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		checkBox_21.Location = new Point(3, 4);
		checkBox_21.Margin = new Padding(3, 4, 3, 4);
		checkBox_21.Name = Class16.smethod_0(1649153710);
		checkBox_21.Size = new Size(247, 17);
		checkBox_21.TabIndex = 62;
		checkBox_21.Text = Class16.smethod_0(1649153741);
		checkBox_21.UseVisualStyleBackColor = true;
		numericUpDown_3.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		numericUpDown_3.Location = new Point(358, 103);
		numericUpDown_3.Maximum = new decimal(new int[4] { 12, 0, 0, 0 });
		numericUpDown_3.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_3.Name = Class16.smethod_0(1649153778);
		numericUpDown_3.Size = new Size(81, 22);
		numericUpDown_3.TabIndex = 57;
		numericUpDown_3.TextAlign = HorizontalAlignment.Center;
		numericUpDown_3.Value = new decimal(new int[4] { 12, 0, 0, 0 });
		checkBox_14.AutoSize = true;
		checkBox_14.Checked = true;
		checkBox_14.CheckState = CheckState.Checked;
		checkBox_14.Dock = DockStyle.Right;
		checkBox_14.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		checkBox_14.Location = new Point(203, 104);
		checkBox_14.Margin = new Padding(3, 4, 3, 4);
		checkBox_14.Name = Class16.smethod_0(1649153814);
		checkBox_14.Size = new Size(149, 18);
		checkBox_14.TabIndex = 58;
		checkBox_14.Text = Class16.smethod_0(1649153837);
		checkBox_14.UseVisualStyleBackColor = true;
		checkBox_14.CheckedChanged += checkBox_14_CheckedChanged;
		checkBox_19.AutoSize = true;
		checkBox_19.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		checkBox_19.Location = new Point(358, 4);
		checkBox_19.Margin = new Padding(3, 4, 3, 4);
		checkBox_19.Name = Class16.smethod_0(1649153857);
		checkBox_19.Size = new Size(121, 17);
		checkBox_19.TabIndex = 61;
		checkBox_19.Text = Class16.smethod_0(1649153882);
		checkBox_19.UseVisualStyleBackColor = true;
		label_46.AutoSize = true;
		label_46.Dock = DockStyle.Right;
		label_46.Location = new Point(159, 75);
		label_46.Name = Class16.smethod_0(1649153906);
		label_46.Size = new Size(193, 25);
		label_46.TabIndex = 59;
		label_46.Text = Class16.smethod_0(1649153937);
		label_46.TextAlign = ContentAlignment.MiddleCenter;
		tabPage_1.Controls.Add(checkBox_22);
		tabPage_1.Controls.Add(checkBox_20);
		tabPage_1.Controls.Add(checkBox_23);
		tabPage_1.Controls.Add(checkBox_24);
		tabPage_1.Controls.Add(checkBox_25);
		tabPage_1.Controls.Add(numericUpDown_10);
		tabPage_1.Controls.Add(checkBox_26);
		tabPage_1.Controls.Add(checkBox_27);
		tabPage_1.Controls.Add(groupBox_12);
		tabPage_1.Controls.Add(label_47);
		tabPage_1.Controls.Add(groupBox_13);
		tabPage_1.Controls.Add(comboBox_3);
		tabPage_1.Controls.Add(label_37);
		tabPage_1.Controls.Add(numericUpDown_4);
		tabPage_1.Controls.Add(label_14);
		tabPage_1.Controls.Add(numericUpDown_5);
		tabPage_1.Controls.Add(label_15);
		tabPage_1.Controls.Add(checkBox_15);
		tabPage_1.Controls.Add(checkBox_13);
		tabPage_1.Controls.Add(checkBox_12);
		tabPage_1.Controls.Add(textBox_3);
		tabPage_1.Controls.Add(groupBox_2);
		tabPage_1.Controls.Add(label_3);
		tabPage_1.Controls.Add(checkBox_0);
		tabPage_1.Controls.Add(checkBox_4);
		tabPage_1.Controls.Add(checkBox_2);
		tabPage_1.Controls.Add(checkBox_1);
		tabPage_1.Location = new Point(4, 22);
		tabPage_1.Name = Class16.smethod_0(1649153989);
		tabPage_1.Padding = new Padding(3);
		tabPage_1.Size = new Size(582, 561);
		tabPage_1.TabIndex = 1;
		tabPage_1.Text = Class16.smethod_0(1649111802);
		tabPage_1.UseVisualStyleBackColor = true;
		checkBox_22.AutoSize = true;
		checkBox_22.Checked = true;
		checkBox_22.CheckState = CheckState.Checked;
		checkBox_22.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_22.Location = new Point(11, 327);
		checkBox_22.Margin = new Padding(3, 4, 3, 4);
		checkBox_22.Name = Class16.smethod_0(1649154006);
		checkBox_22.Size = new Size(243, 17);
		checkBox_22.TabIndex = 65;
		checkBox_22.Text = Class16.smethod_0(1649154032);
		checkBox_22.UseVisualStyleBackColor = true;
		checkBox_20.AutoSize = true;
		checkBox_20.Checked = true;
		checkBox_20.CheckState = CheckState.Checked;
		checkBox_20.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		checkBox_20.Location = new Point(11, 378);
		checkBox_20.Name = Class16.smethod_0(1649153062);
		checkBox_20.Size = new Size(149, 19);
		checkBox_20.TabIndex = 64;
		checkBox_20.Text = Class16.smethod_0(1649153083);
		checkBox_20.UseVisualStyleBackColor = true;
		checkBox_23.AutoSize = true;
		checkBox_23.Checked = true;
		checkBox_23.CheckState = CheckState.Checked;
		checkBox_23.Location = new Point(11, 355);
		checkBox_23.Name = Class16.smethod_0(1649153119);
		checkBox_23.Size = new Size(204, 17);
		checkBox_23.TabIndex = 64;
		checkBox_23.Text = Class16.smethod_0(1649153136);
		checkBox_23.UseVisualStyleBackColor = true;
		checkBox_24.AutoSize = true;
		checkBox_24.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_24.Location = new Point(11, 307);
		checkBox_24.Name = Class16.smethod_0(1649153178);
		checkBox_24.Size = new Size(205, 17);
		checkBox_24.TabIndex = 63;
		checkBox_24.Text = Class16.smethod_0(1649153223);
		checkBox_24.UseVisualStyleBackColor = true;
		checkBox_25.AutoSize = true;
		checkBox_25.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_25.Location = new Point(11, 287);
		checkBox_25.Margin = new Padding(3, 4, 3, 4);
		checkBox_25.Name = Class16.smethod_0(1649153258);
		checkBox_25.Size = new Size(188, 17);
		checkBox_25.TabIndex = 62;
		checkBox_25.Text = Class16.smethod_0(1649153295);
		checkBox_25.UseVisualStyleBackColor = true;
		numericUpDown_10.Location = new Point(492, 355);
		numericUpDown_10.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
		numericUpDown_10.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_10.Name = Class16.smethod_0(1649153333);
		numericUpDown_10.Size = new Size(78, 22);
		numericUpDown_10.TabIndex = 57;
		numericUpDown_10.TextAlign = HorizontalAlignment.Center;
		numericUpDown_10.Value = new decimal(new int[4] { 20, 0, 0, 0 });
		checkBox_26.AutoSize = true;
		checkBox_26.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_26.Location = new Point(11, 268);
		checkBox_26.Margin = new Padding(3, 4, 3, 4);
		checkBox_26.Name = Class16.smethod_0(1649153358);
		checkBox_26.Size = new Size(242, 17);
		checkBox_26.TabIndex = 60;
		checkBox_26.Text = Class16.smethod_0(1649153377);
		checkBox_26.UseVisualStyleBackColor = true;
		groupBox_12.Controls.Add(button_45);
		groupBox_12.Controls.Add(checkBox_28);
		groupBox_12.Controls.Add(checkBox_29);
		groupBox_12.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		groupBox_12.Location = new Point(326, 268);
		groupBox_12.Margin = new Padding(3, 4, 3, 4);
		groupBox_12.Name = Class16.smethod_0(1649153425);
		groupBox_12.Padding = new Padding(3, 4, 3, 4);
		groupBox_12.Size = new Size(244, 76);
		groupBox_12.TabIndex = 58;
		groupBox_12.TabStop = false;
		groupBox_12.Text = Class16.smethod_0(1649153442);
		checkBox_28.AutoSize = true;
		checkBox_28.Checked = true;
		checkBox_28.CheckState = CheckState.Checked;
		checkBox_28.Location = new Point(9, 47);
		checkBox_28.Margin = new Padding(3, 4, 3, 4);
		checkBox_28.Name = Class16.smethod_0(1649153481);
		checkBox_28.Size = new Size(145, 17);
		checkBox_28.TabIndex = 13;
		checkBox_28.Text = Class16.smethod_0(1649153506);
		checkBox_28.UseVisualStyleBackColor = true;
		checkBox_29.AutoSize = true;
		checkBox_29.Checked = true;
		checkBox_29.CheckState = CheckState.Checked;
		checkBox_29.Location = new Point(9, 23);
		checkBox_29.Margin = new Padding(3, 4, 3, 4);
		checkBox_29.Name = Class16.smethod_0(1649152519);
		checkBox_29.Size = new Size(180, 17);
		checkBox_29.TabIndex = 11;
		checkBox_29.Text = Class16.smethod_0(1649152536);
		checkBox_29.UseVisualStyleBackColor = true;
		label_47.Location = new Point(275, 356);
		label_47.Name = Class16.smethod_0(1649152581);
		label_47.Size = new Size(214, 16);
		label_47.TabIndex = 56;
		label_47.Text = Class16.smethod_0(1649152606);
		label_47.TextAlign = ContentAlignment.MiddleRight;
		groupBox_13.Controls.Add(comboBox_5);
		groupBox_13.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		groupBox_13.Location = new Point(11, 196);
		groupBox_13.Name = Class16.smethod_0(1649152639);
		groupBox_13.Size = new Size(558, 46);
		groupBox_13.TabIndex = 55;
		groupBox_13.TabStop = false;
		groupBox_13.Text = Class16.smethod_0(1649152671);
		comboBox_5.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_5.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_5.FormattingEnabled = true;
		comboBox_5.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1648908427),
			Class16.smethod_0(1649152731),
			Class16.smethod_0(1649152771)
		});
		comboBox_5.Location = new Point(5, 17);
		comboBox_5.Name = Class16.smethod_0(1649152818);
		comboBox_5.Size = new Size(547, 21);
		comboBox_5.TabIndex = 41;
		comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_3.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_3.FormattingEnabled = true;
		comboBox_3.Items.AddRange(new object[11]
		{
			Class16.smethod_0(1649007050),
			Class16.smethod_0(1648994670),
			Class16.smethod_0(1648994682),
			Class16.smethod_0(1648994731),
			Class16.smethod_0(1649168642),
			Class16.smethod_0(1649152850),
			Class16.smethod_0(1649168693),
			Class16.smethod_0(1649190294),
			Class16.smethod_0(1649168709),
			Class16.smethod_0(1649152876),
			Class16.smethod_0(1649152894)
		});
		comboBox_3.Location = new Point(316, 19);
		comboBox_3.Name = Class16.smethod_0(1649168712);
		comboBox_3.Size = new Size(260, 21);
		comboBox_3.TabIndex = 53;
		comboBox_3.SelectedIndexChanged += comboBox_3_SelectedIndexChanged;
		label_37.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_37.ImageAlign = ContentAlignment.MiddleRight;
		label_37.Location = new Point(276, 22);
		label_37.Name = Class16.smethod_0(1649168734);
		label_37.Size = new Size(43, 13);
		label_37.TabIndex = 54;
		label_37.Text = Class16.smethod_0(1649168748);
		label_37.TextAlign = ContentAlignment.MiddleLeft;
		numericUpDown_4.Location = new Point(223, 93);
		numericUpDown_4.Maximum = new decimal(new int[4] { 200, 0, 0, 0 });
		numericUpDown_4.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_4.Name = Class16.smethod_0(1649152907);
		numericUpDown_4.Size = new Size(53, 22);
		numericUpDown_4.TabIndex = 52;
		numericUpDown_4.TextAlign = HorizontalAlignment.Center;
		numericUpDown_4.Value = new decimal(new int[4] { 20, 0, 0, 0 });
		label_14.Location = new Point(6, 94);
		label_14.Name = Class16.smethod_0(1649152950);
		label_14.Size = new Size(214, 16);
		label_14.TabIndex = 51;
		label_14.Text = Class16.smethod_0(1649152977);
		label_14.TextAlign = ContentAlignment.MiddleRight;
		label_15.Location = new Point(6, 70);
		label_15.Name = Class16.smethod_0(1649152007);
		label_15.Size = new Size(214, 16);
		label_15.TabIndex = 49;
		label_15.Text = Class16.smethod_0(1649152036);
		label_15.TextAlign = ContentAlignment.MiddleRight;
		checkBox_15.AutoSize = true;
		checkBox_15.Checked = true;
		checkBox_15.CheckState = CheckState.Checked;
		checkBox_15.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_15.Location = new Point(15, 49);
		checkBox_15.Margin = new Padding(3, 4, 3, 4);
		checkBox_15.Name = Class16.smethod_0(1649152069);
		checkBox_15.Size = new Size(236, 17);
		checkBox_15.TabIndex = 48;
		checkBox_15.Text = Class16.smethod_0(1649152089);
		checkBox_15.UseVisualStyleBackColor = true;
		checkBox_12.AutoSize = true;
		checkBox_12.Checked = true;
		checkBox_12.CheckState = CheckState.Checked;
		checkBox_12.Enabled = false;
		checkBox_12.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_12.Location = new Point(279, 22);
		checkBox_12.Margin = new Padding(3, 4, 3, 4);
		checkBox_12.Name = Class16.smethod_0(1649152143);
		checkBox_12.Size = new Size(190, 17);
		checkBox_12.TabIndex = 46;
		checkBox_12.Text = Class16.smethod_0(1649152155);
		checkBox_12.UseVisualStyleBackColor = true;
		checkBox_12.Visible = false;
		groupBox_2.Controls.Add(comboBox_1);
		groupBox_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		groupBox_2.Location = new Point(11, 143);
		groupBox_2.Name = Class16.smethod_0(1649152193);
		groupBox_2.Size = new Size(558, 47);
		groupBox_2.TabIndex = 45;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1649152219);
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1649152268),
			Class16.smethod_0(1649152298),
			Class16.smethod_0(1649152334)
		});
		comboBox_1.Location = new Point(5, 18);
		comboBox_1.Name = Class16.smethod_0(1649152363);
		comboBox_1.Size = new Size(547, 21);
		comboBox_1.TabIndex = 41;
		tabPage_2.Controls.Add(button_31);
		tabPage_2.Controls.Add(textBox_30);
		tabPage_2.Controls.Add(label_38);
		tabPage_2.Controls.Add(groupBox_10);
		tabPage_2.Controls.Add(numericUpDown_2);
		tabPage_2.Controls.Add(checkBox_10);
		tabPage_2.Controls.Add(label_8);
		tabPage_2.Controls.Add(checkBox_9);
		tabPage_2.Controls.Add(label_4);
		tabPage_2.Controls.Add(numericUpDown_0);
		tabPage_2.Controls.Add(checkBox_8);
		tabPage_2.Location = new Point(4, 22);
		tabPage_2.Name = Class16.smethod_0(1649152386);
		tabPage_2.Padding = new Padding(3);
		tabPage_2.Size = new Size(582, 561);
		tabPage_2.TabIndex = 2;
		tabPage_2.Text = Class16.smethod_0(1649050497);
		tabPage_2.UseVisualStyleBackColor = true;
		textBox_30.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_30.Location = new Point(392, 8);
		textBox_30.Margin = new Padding(3, 4, 3, 4);
		textBox_30.Name = Class16.smethod_0(1649152401);
		textBox_30.Size = new Size(152, 22);
		textBox_30.TabIndex = 35;
		label_38.Location = new Point(240, 9);
		label_38.Name = Class16.smethod_0(1649152424);
		label_38.Size = new Size(146, 16);
		label_38.TabIndex = 34;
		label_38.Text = Class16.smethod_0(1649152455);
		label_38.TextAlign = ContentAlignment.MiddleRight;
		groupBox_10.Controls.Add(label_55);
		groupBox_10.Controls.Add(textBox_5);
		groupBox_10.Controls.Add(button_10);
		groupBox_10.Controls.Add(button_9);
		groupBox_10.Controls.Add(label_6);
		groupBox_10.Controls.Add(label_5);
		groupBox_10.Controls.Add(button_7);
		groupBox_10.Controls.Add(textBox_4);
		groupBox_10.Controls.Add(button_8);
		groupBox_10.Location = new Point(6, 125);
		groupBox_10.Name = Class16.smethod_0(1649152480);
		groupBox_10.Size = new Size(570, 81);
		groupBox_10.TabIndex = 33;
		groupBox_10.TabStop = false;
		groupBox_10.Text = Class16.smethod_0(1649210934);
		label_55.Dock = DockStyle.Fill;
		label_55.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Underline, GraphicsUnit.Point, 204);
		label_55.ForeColor = Color.Gray;
		label_55.Location = new Point(3, 18);
		label_55.Name = Class16.smethod_0(1649152499);
		label_55.Size = new Size(564, 60);
		label_55.TabIndex = 31;
		label_55.Text = Class16.smethod_0(1649155600);
		label_55.TextAlign = ContentAlignment.MiddleCenter;
		label_55.Visible = false;
		tabPage_3.AutoScroll = true;
		tabPage_3.Controls.Add(checkBox_17);
		tabPage_3.Controls.Add(button_25);
		tabPage_3.Controls.Add(button_44);
		tabPage_3.Controls.Add(button_26);
		tabPage_3.Controls.Add(label_34);
		tabPage_3.Controls.Add(groupBox_5);
		tabPage_3.Controls.Add(textBox_27);
		tabPage_3.Controls.Add(button_21);
		tabPage_3.Controls.Add(button_22);
		tabPage_3.Controls.Add(label_32);
		tabPage_3.Controls.Add(textBox_25);
		tabPage_3.Controls.Add(groupBox_9);
		tabPage_3.Controls.Add(groupBox_4);
		tabPage_3.Controls.Add(groupBox_3);
		tabPage_3.Location = new Point(4, 22);
		tabPage_3.Name = Class16.smethod_0(1649155650);
		tabPage_3.Padding = new Padding(3);
		tabPage_3.Size = new Size(582, 561);
		tabPage_3.TabIndex = 3;
		tabPage_3.Text = Class16.smethod_0(1648964508);
		tabPage_3.UseVisualStyleBackColor = true;
		checkBox_17.AutoSize = true;
		checkBox_17.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		checkBox_17.Location = new Point(8, 36);
		checkBox_17.Name = Class16.smethod_0(1649155665);
		checkBox_17.Size = new Size(69, 17);
		checkBox_17.TabIndex = 18;
		checkBox_17.Text = Class16.smethod_0(1649155681);
		checkBox_17.UseVisualStyleBackColor = true;
		checkBox_17.CheckedChanged += checkBox_17_CheckedChanged;
		button_26.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_26.Image = Resources.cmdBrowseSurfacesPckDir;
		button_26.Location = new Point(531, 977);
		button_26.Margin = new Padding(3, 4, 3, 4);
		button_26.Name = Class16.smethod_0(1649188175);
		button_26.Size = new Size(26, 22);
		button_26.TabIndex = 33;
		button_26.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_26.UseVisualStyleBackColor = true;
		button_26.Click += button_26_Click;
		label_34.AutoSize = true;
		label_34.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_34.Location = new Point(29, 979);
		label_34.Name = Class16.smethod_0(1649155703);
		label_34.Size = new Size(55, 15);
		label_34.TabIndex = 31;
		label_34.Text = Class16.smethod_0(1649086694);
		groupBox_5.Controls.Add(checkBox_18);
		groupBox_5.Controls.Add(button_1);
		groupBox_5.Controls.Add(button_2);
		groupBox_5.Controls.Add(button_4);
		groupBox_5.Controls.Add(label_0);
		groupBox_5.Controls.Add(textBox_1);
		groupBox_5.Controls.Add(textBox_0);
		groupBox_5.Controls.Add(button_6);
		groupBox_5.Controls.Add(label_1);
		groupBox_5.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		groupBox_5.Location = new Point(6, 806);
		groupBox_5.Name = Class16.smethod_0(1649155718);
		groupBox_5.Size = new Size(556, 93);
		groupBox_5.TabIndex = 41;
		groupBox_5.TabStop = false;
		groupBox_5.Text = Class16.smethod_0(1649155756);
		checkBox_18.AutoSize = true;
		checkBox_18.Location = new Point(9, 18);
		checkBox_18.Name = Class16.smethod_0(1649155798);
		checkBox_18.Size = new Size(300, 17);
		checkBox_18.TabIndex = 35;
		checkBox_18.Text = Class16.smethod_0(1649155816);
		checkBox_18.UseVisualStyleBackColor = true;
		textBox_27.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_27.Location = new Point(85, 977);
		textBox_27.Margin = new Padding(3, 4, 3, 4);
		textBox_27.Name = Class16.smethod_0(1649155885);
		textBox_27.Size = new Size(445, 22);
		textBox_27.TabIndex = 32;
		button_21.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_21.Image = Resources.cmdBrowseClientPath;
		button_21.Location = new Point(504, 8);
		button_21.Margin = new Padding(3, 4, 3, 4);
		button_21.Name = Class16.smethod_0(1649188620);
		button_21.Size = new Size(26, 22);
		button_21.TabIndex = 50;
		button_21.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_21.UseVisualStyleBackColor = true;
		button_21.Click += button_21_Click;
		label_32.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_32.Location = new Point(35, 10);
		label_32.Name = Class16.smethod_0(1649155909);
		label_32.Size = new Size(65, 19);
		label_32.TabIndex = 48;
		label_32.Text = Class16.smethod_0(1649155921);
		label_32.TextAlign = ContentAlignment.MiddleCenter;
		textBox_25.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_25.Location = new Point(101, 7);
		textBox_25.Margin = new Padding(3, 4, 3, 4);
		textBox_25.Name = Class16.smethod_0(1649169523);
		textBox_25.Size = new Size(402, 22);
		textBox_25.TabIndex = 49;
		textBox_25.Enter += textBox_25_Enter;
		textBox_25.Leave += textBox_25_Leave;
		groupBox_9.Controls.Add(linkLabel_0);
		groupBox_9.Controls.Add(dataGridView_0);
		groupBox_9.Controls.Add(groupBox_11);
		groupBox_9.Controls.Add(button_27);
		groupBox_9.Controls.Add(textBox_28);
		groupBox_9.Controls.Add(button_28);
		groupBox_9.Controls.Add(label_35);
		groupBox_9.Controls.Add(button_29);
		groupBox_9.Controls.Add(textBox_29);
		groupBox_9.Controls.Add(button_30);
		groupBox_9.Controls.Add(label_36);
		groupBox_9.Controls.Add(button_23);
		groupBox_9.Controls.Add(textBox_26);
		groupBox_9.Controls.Add(button_24);
		groupBox_9.Controls.Add(label_33);
		groupBox_9.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		groupBox_9.Location = new Point(3, 36);
		groupBox_9.Name = Class16.smethod_0(1649155943);
		groupBox_9.Size = new Size(559, 351);
		groupBox_9.TabIndex = 47;
		groupBox_9.TabStop = false;
		groupBox_9.Text = Class16.smethod_0(1649155954);
		linkLabel_0.BackColor = Color.White;
		linkLabel_0.Location = new Point(377, 2);
		linkLabel_0.Name = Class16.smethod_0(1649155971);
		linkLabel_0.Size = new Size(173, 13);
		linkLabel_0.TabIndex = 143;
		linkLabel_0.TabStop = true;
		linkLabel_0.Text = Class16.smethod_0(1649155993);
		linkLabel_0.TextAlign = ContentAlignment.MiddleRight;
		linkLabel_0.LinkClicked += linkLabel_0_LinkClicked;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_0.BackgroundColor = Color.White;
		dataGridView_0.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_0.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeight = 29;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		dataGridView_0.ColumnHeadersVisible = false;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0);
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.White;
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = Color.Black;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = Color.White;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.GridColor = Color.Silver;
		dataGridView_0.Location = new Point(3, 22);
		dataGridView_0.Margin = new Padding(3, 4, 3, 4);
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1649156025);
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.RowHeadersWidth = 51;
		dataGridView_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowsDefaultCellStyle = dataGridViewCellStyle3;
		dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellToolTips = false;
		dataGridView_0.Size = new Size(550, 271);
		dataGridView_0.TabIndex = 142;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649156047);
		dataGridViewTextBoxColumn_0.MinimumWidth = 6;
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649175478);
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		groupBox_11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_11.Controls.Add(numericUpDown_7);
		groupBox_11.Controls.Add(numericUpDown_8);
		groupBox_11.Controls.Add(textBox_38);
		groupBox_11.Controls.Add(comboBox_4);
		groupBox_11.Location = new Point(6, 297);
		groupBox_11.Name = Class16.smethod_0(1649156062);
		groupBox_11.Size = new Size(547, 46);
		groupBox_11.TabIndex = 27;
		groupBox_11.TabStop = false;
		groupBox_11.Text = Class16.smethod_0(1649156076);
		textBox_38.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_38.Enabled = false;
		textBox_38.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_38.Location = new Point(118, 17);
		textBox_38.Margin = new Padding(3, 4, 3, 4);
		textBox_38.Name = Class16.smethod_0(1649156087);
		textBox_38.Size = new Size(422, 22);
		textBox_38.TabIndex = 44;
		textBox_38.TextAlign = HorizontalAlignment.Center;
		comboBox_4.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_4.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_4.FormattingEnabled = true;
		comboBox_4.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1649155080),
			Class16.smethod_0(1648929287),
			Class16.smethod_0(1649155103)
		});
		comboBox_4.Location = new Point(6, 17);
		comboBox_4.Name = Class16.smethod_0(1649155125);
		comboBox_4.Size = new Size(106, 21);
		comboBox_4.TabIndex = 43;
		comboBox_4.SelectedIndexChanged += comboBox_4_SelectedIndexChanged;
		button_27.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_27.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_27.Image = Resources.cmdBrowseModelsPck;
		button_27.Location = new Point(527, 70);
		button_27.Margin = new Padding(3, 4, 3, 4);
		button_27.Name = Class16.smethod_0(1649187968);
		button_27.Size = new Size(26, 22);
		button_27.TabIndex = 25;
		button_27.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_27.UseVisualStyleBackColor = true;
		button_27.Visible = false;
		button_27.Click += button_27_Click;
		textBox_28.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_28.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_28.Location = new Point(124, 70);
		textBox_28.Margin = new Padding(3, 4, 3, 4);
		textBox_28.Name = Class16.smethod_0(1649155141);
		textBox_28.Size = new Size(402, 22);
		textBox_28.TabIndex = 24;
		textBox_28.Visible = false;
		label_35.AutoSize = true;
		label_35.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_35.Location = new Point(31, 73);
		label_35.Name = Class16.smethod_0(1649155164);
		label_35.Size = new Size(73, 15);
		label_35.TabIndex = 23;
		label_35.Text = Class16.smethod_0(1649155183);
		label_35.Visible = false;
		button_29.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_29.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_29.Image = Resources.cmdBrowseSurfacesPck;
		button_29.Location = new Point(527, 46);
		button_29.Margin = new Padding(3, 4, 3, 4);
		button_29.Name = Class16.smethod_0(1649188148);
		button_29.Size = new Size(26, 22);
		button_29.TabIndex = 21;
		button_29.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_29.UseVisualStyleBackColor = true;
		button_29.Visible = false;
		button_29.Click += button_29_Click;
		textBox_29.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_29.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_29.Location = new Point(124, 46);
		textBox_29.Margin = new Padding(3, 4, 3, 4);
		textBox_29.Name = Class16.smethod_0(1649155193);
		textBox_29.Size = new Size(402, 22);
		textBox_29.TabIndex = 20;
		textBox_29.Visible = false;
		label_36.AutoSize = true;
		label_36.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_36.Location = new Point(31, 49);
		label_36.Name = Class16.smethod_0(1649155218);
		label_36.Size = new Size(79, 15);
		label_36.TabIndex = 19;
		label_36.Text = Class16.smethod_0(1649155247);
		label_36.Visible = false;
		button_23.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_23.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_23.Image = Resources.cmdBrowseConfigsPck;
		button_23.Location = new Point(527, 22);
		button_23.Margin = new Padding(3, 4, 3, 4);
		button_23.Name = Class16.smethod_0(1649188659);
		button_23.Size = new Size(26, 22);
		button_23.TabIndex = 12;
		button_23.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_23.UseVisualStyleBackColor = true;
		button_23.Visible = false;
		button_23.Click += button_23_Click;
		textBox_26.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_26.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_26.Location = new Point(124, 22);
		textBox_26.Margin = new Padding(3, 4, 3, 4);
		textBox_26.Name = Class16.smethod_0(1649155259);
		textBox_26.Size = new Size(402, 22);
		textBox_26.TabIndex = 11;
		textBox_26.Visible = false;
		label_33.AutoSize = true;
		label_33.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_33.Location = new Point(31, 25);
		label_33.Name = Class16.smethod_0(1649155283);
		label_33.Size = new Size(73, 15);
		label_33.TabIndex = 10;
		label_33.Text = Class16.smethod_0(1649155310);
		label_33.Visible = false;
		groupBox_4.Controls.Add(button_58);
		groupBox_4.Controls.Add(button_59);
		groupBox_4.Controls.Add(label_57);
		groupBox_4.Controls.Add(textBox_46);
		groupBox_4.Controls.Add(button_56);
		groupBox_4.Controls.Add(button_57);
		groupBox_4.Controls.Add(label_56);
		groupBox_4.Controls.Add(textBox_45);
		groupBox_4.Controls.Add(button_51);
		groupBox_4.Controls.Add(button_52);
		groupBox_4.Controls.Add(label_52);
		groupBox_4.Controls.Add(textBox_43);
		groupBox_4.Controls.Add(button_53);
		groupBox_4.Controls.Add(button_54);
		groupBox_4.Controls.Add(label_53);
		groupBox_4.Controls.Add(textBox_44);
		groupBox_4.Controls.Add(button_47);
		groupBox_4.Controls.Add(button_48);
		groupBox_4.Controls.Add(label_50);
		groupBox_4.Controls.Add(textBox_41);
		groupBox_4.Controls.Add(button_49);
		groupBox_4.Controls.Add(button_50);
		groupBox_4.Controls.Add(label_51);
		groupBox_4.Controls.Add(textBox_42);
		groupBox_4.Controls.Add(button_42);
		groupBox_4.Controls.Add(button_43);
		groupBox_4.Controls.Add(label_45);
		groupBox_4.Controls.Add(textBox_37);
		groupBox_4.Controls.Add(textBox_34);
		groupBox_4.Controls.Add(label_42);
		groupBox_4.Controls.Add(button_36);
		groupBox_4.Controls.Add(button_37);
		groupBox_4.Controls.Add(textBox_35);
		groupBox_4.Controls.Add(label_43);
		groupBox_4.Controls.Add(button_38);
		groupBox_4.Controls.Add(button_39);
		groupBox_4.Controls.Add(textBox_36);
		groupBox_4.Controls.Add(label_44);
		groupBox_4.Controls.Add(button_40);
		groupBox_4.Controls.Add(button_41);
		groupBox_4.Controls.Add(button_32);
		groupBox_4.Controls.Add(button_33);
		groupBox_4.Controls.Add(label_40);
		groupBox_4.Controls.Add(textBox_32);
		groupBox_4.Controls.Add(textBox_33);
		groupBox_4.Controls.Add(label_41);
		groupBox_4.Controls.Add(button_34);
		groupBox_4.Controls.Add(button_35);
		groupBox_4.Controls.Add(button_17);
		groupBox_4.Controls.Add(button_18);
		groupBox_4.Controls.Add(label_12);
		groupBox_4.Controls.Add(textBox_10);
		groupBox_4.Controls.Add(textBox_2);
		groupBox_4.Controls.Add(button_15);
		groupBox_4.Controls.Add(label_2);
		groupBox_4.Controls.Add(button_16);
		groupBox_4.Controls.Add(button_3);
		groupBox_4.Controls.Add(label_11);
		groupBox_4.Controls.Add(label_13);
		groupBox_4.Controls.Add(textBox_9);
		groupBox_4.Controls.Add(textBox_6);
		groupBox_4.Controls.Add(button_12);
		groupBox_4.Controls.Add(button_11);
		groupBox_4.Controls.Add(button_5);
		groupBox_4.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		groupBox_4.Location = new Point(3, 391);
		groupBox_4.Name = Class16.smethod_0(1649155321);
		groupBox_4.Size = new Size(559, 409);
		groupBox_4.TabIndex = 45;
		groupBox_4.TabStop = false;
		groupBox_4.Text = Class16.smethod_0(1648964508);
		button_59.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_59.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_59.Image = Resources.cmdBrowseGShopSev2;
		button_59.Location = new Point(528, 214);
		button_59.Margin = new Padding(3, 4, 3, 4);
		button_59.Name = Class16.smethod_0(1649155348);
		button_59.Size = new Size(26, 23);
		button_59.TabIndex = 95;
		button_59.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_59.UseVisualStyleBackColor = true;
		button_59.Click += button_59_Click;
		label_57.AutoSize = true;
		label_57.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_57.Location = new Point(30, 215);
		label_57.Name = Class16.smethod_0(1649155373);
		label_57.Size = new Size(89, 15);
		label_57.TabIndex = 93;
		label_57.Text = Class16.smethod_0(1648908801);
		textBox_46.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_46.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_46.Location = new Point(124, 215);
		textBox_46.Margin = new Padding(3, 4, 3, 4);
		textBox_46.Name = Class16.smethod_0(1649155379);
		textBox_46.Size = new Size(403, 22);
		textBox_46.TabIndex = 94;
		button_57.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_57.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_57.Image = Resources.cmdBrowseGShop2;
		button_57.Location = new Point(529, 117);
		button_57.Margin = new Padding(3, 4, 3, 4);
		button_57.Name = Class16.smethod_0(1649155402);
		button_57.Size = new Size(26, 23);
		button_57.TabIndex = 91;
		button_57.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_57.UseVisualStyleBackColor = true;
		button_57.Click += button_57_Click;
		label_56.AutoSize = true;
		label_56.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_56.Location = new Point(31, 118);
		label_56.Name = Class16.smethod_0(1649155424);
		label_56.Size = new Size(72, 15);
		label_56.TabIndex = 89;
		label_56.Text = Class16.smethod_0(1648909745);
		textBox_45.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_45.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_45.Location = new Point(125, 118);
		textBox_45.Margin = new Padding(3, 4, 3, 4);
		textBox_45.Name = Class16.smethod_0(1649155440);
		textBox_45.Size = new Size(403, 22);
		textBox_45.TabIndex = 90;
		button_52.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_52.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_52.Image = Resources.cmdBrowseGShop2;
		button_52.Location = new Point(528, 90);
		button_52.Margin = new Padding(3, 4, 3, 4);
		button_52.Name = Class16.smethod_0(1649187849);
		button_52.Size = new Size(26, 23);
		button_52.TabIndex = 87;
		button_52.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_52.UseVisualStyleBackColor = true;
		button_52.Click += button_52_Click;
		label_52.AutoSize = true;
		label_52.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_52.Location = new Point(30, 91);
		label_52.Name = Class16.smethod_0(1649155468);
		label_52.Size = new Size(72, 15);
		label_52.TabIndex = 85;
		label_52.Text = Class16.smethod_0(1648909735);
		textBox_43.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_43.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_43.Location = new Point(124, 91);
		textBox_43.Margin = new Padding(3, 4, 3, 4);
		textBox_43.Name = Class16.smethod_0(1649155484);
		textBox_43.Size = new Size(403, 22);
		textBox_43.TabIndex = 86;
		button_54.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_54.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_54.Image = Resources.cmdBrowseGShop1;
		button_54.Location = new Point(528, 67);
		button_54.Margin = new Padding(3, 4, 3, 4);
		button_54.Name = Class16.smethod_0(1649188826);
		button_54.Size = new Size(26, 23);
		button_54.TabIndex = 83;
		button_54.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_54.UseVisualStyleBackColor = true;
		button_54.Click += button_54_Click;
		label_53.AutoSize = true;
		label_53.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_53.Location = new Point(30, 68);
		label_53.Name = Class16.smethod_0(1649155496);
		label_53.Size = new Size(72, 15);
		label_53.TabIndex = 81;
		label_53.Text = Class16.smethod_0(1648909717);
		textBox_44.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_44.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_44.Location = new Point(124, 68);
		textBox_44.Margin = new Padding(3, 4, 3, 4);
		textBox_44.Name = Class16.smethod_0(1649155512);
		textBox_44.Size = new Size(403, 22);
		textBox_44.TabIndex = 82;
		button_48.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_48.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_48.Image = Resources.cmdBrowseGShopSev2;
		button_48.Location = new Point(528, 188);
		button_48.Margin = new Padding(3, 4, 3, 4);
		button_48.Name = Class16.smethod_0(1649187903);
		button_48.Size = new Size(26, 23);
		button_48.TabIndex = 79;
		button_48.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_48.UseVisualStyleBackColor = true;
		button_48.Click += button_48_Click;
		label_50.AutoSize = true;
		label_50.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_50.Location = new Point(30, 189);
		label_50.Name = Class16.smethod_0(1649155540);
		label_50.Size = new Size(89, 15);
		label_50.TabIndex = 77;
		label_50.Text = Class16.smethod_0(1648909812);
		textBox_41.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_41.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_41.Location = new Point(124, 189);
		textBox_41.Margin = new Padding(3, 4, 3, 4);
		textBox_41.Name = Class16.smethod_0(1649155546);
		textBox_41.Size = new Size(403, 22);
		textBox_41.TabIndex = 78;
		button_50.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_50.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_50.Image = Resources.cmdBrowseGShop1Sev;
		button_50.Location = new Point(528, 165);
		button_50.Margin = new Padding(3, 4, 3, 4);
		button_50.Name = Class16.smethod_0(1649188848);
		button_50.Size = new Size(26, 23);
		button_50.TabIndex = 75;
		button_50.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_50.UseVisualStyleBackColor = true;
		button_50.Click += button_50_Click;
		label_51.AutoSize = true;
		label_51.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_51.Location = new Point(30, 166);
		label_51.Name = Class16.smethod_0(1649155569);
		label_51.Size = new Size(89, 15);
		label_51.TabIndex = 73;
		label_51.Text = Class16.smethod_0(1648909791);
		textBox_42.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_42.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_42.Location = new Point(124, 166);
		textBox_42.Margin = new Padding(3, 4, 3, 4);
		textBox_42.Name = Class16.smethod_0(1649154567);
		textBox_42.Size = new Size(403, 22);
		textBox_42.TabIndex = 74;
		button_43.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_43.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_43.Image = Resources.cmdBrowseElements;
		button_43.Location = new Point(528, 21);
		button_43.Margin = new Padding(3, 4, 3, 4);
		button_43.Name = Class16.smethod_0(1649188764);
		button_43.Size = new Size(26, 23);
		button_43.TabIndex = 71;
		button_43.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_43.UseVisualStyleBackColor = true;
		button_43.Click += button_43_Click;
		label_45.AutoSize = true;
		label_45.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_45.Location = new Point(30, 22);
		label_45.Name = Class16.smethod_0(1649154590);
		label_45.Size = new Size(81, 15);
		label_45.TabIndex = 69;
		label_45.Text = Class16.smethod_0(1648909672);
		textBox_37.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_37.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_37.Location = new Point(124, 22);
		textBox_37.Margin = new Padding(3, 4, 3, 4);
		textBox_37.Name = Class16.smethod_0(1649154612);
		textBox_37.Size = new Size(403, 22);
		textBox_37.TabIndex = 70;
		textBox_34.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_34.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_34.Location = new Point(124, 381);
		textBox_34.Margin = new Padding(3, 4, 3, 4);
		textBox_34.Name = Class16.smethod_0(1649154626);
		textBox_34.Size = new Size(403, 22);
		textBox_34.TabIndex = 66;
		label_42.AutoSize = true;
		label_42.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_42.Location = new Point(30, 381);
		label_42.Name = Class16.smethod_0(1649154649);
		label_42.Size = new Size(86, 13);
		label_42.TabIndex = 65;
		label_42.Text = Class16.smethod_0(1648908903);
		button_36.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_36.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_36.Image = Resources.cmdBrowseExtraDrop;
		button_36.Location = new Point(528, 380);
		button_36.Margin = new Padding(3, 4, 3, 4);
		button_36.Name = Class16.smethod_0(1649188788);
		button_36.Size = new Size(26, 23);
		button_36.TabIndex = 67;
		button_36.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_36.UseVisualStyleBackColor = true;
		button_36.Click += button_36_Click;
		textBox_35.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_35.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_35.Location = new Point(124, 358);
		textBox_35.Margin = new Padding(3, 4, 3, 4);
		textBox_35.Name = Class16.smethod_0(1649154679);
		textBox_35.Size = new Size(403, 22);
		textBox_35.TabIndex = 62;
		label_43.AutoSize = true;
		label_43.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_43.Location = new Point(30, 360);
		label_43.Name = Class16.smethod_0(1649154703);
		label_43.Size = new Size(71, 13);
		label_43.TabIndex = 61;
		label_43.Text = Class16.smethod_0(1648908885);
		button_38.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_38.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_38.Image = Resources.cmdBrowseDomain2Sev;
		button_38.Location = new Point(528, 357);
		button_38.Margin = new Padding(3, 4, 3, 4);
		button_38.Name = Class16.smethod_0(1649188705);
		button_38.Size = new Size(26, 23);
		button_38.TabIndex = 63;
		button_38.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_38.UseVisualStyleBackColor = true;
		button_38.Click += button_38_Click;
		textBox_36.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_36.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_36.Location = new Point(124, 335);
		textBox_36.Margin = new Padding(3, 4, 3, 4);
		textBox_36.Name = Class16.smethod_0(1649154712);
		textBox_36.Size = new Size(403, 22);
		textBox_36.TabIndex = 58;
		label_44.AutoSize = true;
		label_44.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_44.Location = new Point(30, 337);
		label_44.Name = Class16.smethod_0(1649154743);
		label_44.Size = new Size(65, 13);
		label_44.TabIndex = 57;
		label_44.Text = Class16.smethod_0(1648908868);
		button_40.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_40.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_40.Image = Resources.cmdBrowseDomainSev;
		button_40.Location = new Point(528, 334);
		button_40.Margin = new Padding(3, 4, 3, 4);
		button_40.Name = Class16.smethod_0(1649188731);
		button_40.Size = new Size(26, 23);
		button_40.TabIndex = 59;
		button_40.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_40.UseVisualStyleBackColor = true;
		button_40.Click += button_40_Click;
		button_33.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_33.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_33.Image = Resources.cmdBrowseGShopSev;
		button_33.Location = new Point(528, 142);
		button_33.Margin = new Padding(3, 4, 3, 4);
		button_33.Name = Class16.smethod_0(1649187879);
		button_33.Size = new Size(26, 23);
		button_33.TabIndex = 55;
		button_33.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_33.UseVisualStyleBackColor = true;
		button_33.Click += button_33_Click;
		label_40.AutoSize = true;
		label_40.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_40.Location = new Point(30, 143);
		label_40.Name = Class16.smethod_0(1649154759);
		label_40.Size = new Size(83, 15);
		label_40.TabIndex = 53;
		label_40.Text = Class16.smethod_0(1648909763);
		textBox_32.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_32.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_32.Location = new Point(124, 143);
		textBox_32.Margin = new Padding(3, 4, 3, 4);
		textBox_32.Name = Class16.smethod_0(1649154769);
		textBox_32.Size = new Size(403, 22);
		textBox_32.TabIndex = 54;
		textBox_33.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_33.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_33.Location = new Point(124, 312);
		textBox_33.Margin = new Padding(3, 4, 3, 4);
		textBox_33.Name = Class16.smethod_0(1649154799);
		textBox_33.Size = new Size(403, 22);
		textBox_33.TabIndex = 50;
		label_41.AutoSize = true;
		label_41.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_41.Location = new Point(30, 314);
		label_41.Name = Class16.smethod_0(1649154821);
		label_41.Size = new Size(72, 13);
		label_41.TabIndex = 49;
		label_41.Text = Class16.smethod_0(1648908830);
		button_34.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_34.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_34.Image = Resources.cmdBrowseAIPolicy;
		button_34.Location = new Point(528, 311);
		button_34.Margin = new Padding(3, 4, 3, 4);
		button_34.Name = Class16.smethod_0(1649188563);
		button_34.Size = new Size(26, 23);
		button_34.TabIndex = 51;
		button_34.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_34.UseVisualStyleBackColor = true;
		button_34.Click += button_34_Click;
		button_18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_18.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_18.Image = Resources.cmdBrowseNPCGen;
		button_18.Location = new Point(528, 288);
		button_18.Margin = new Padding(3, 4, 3, 4);
		button_18.Name = Class16.smethod_0(1649187993);
		button_18.Size = new Size(26, 23);
		button_18.TabIndex = 47;
		button_18.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_18.UseVisualStyleBackColor = true;
		button_18.Click += button_18_Click;
		label_12.AutoSize = true;
		label_12.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_12.Location = new Point(30, 289);
		label_12.Name = Class16.smethod_0(1649154825);
		label_12.Size = new Size(72, 13);
		label_12.TabIndex = 45;
		label_12.Text = Class16.smethod_0(1648908842);
		textBox_10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_10.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_10.Location = new Point(124, 289);
		textBox_10.Margin = new Padding(3, 4, 3, 4);
		textBox_10.Name = Class16.smethod_0(1649154841);
		textBox_10.Size = new Size(403, 22);
		textBox_10.TabIndex = 46;
		button_16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_16.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_16.Image = Resources.cmdBrowseGShop;
		button_16.Location = new Point(528, 44);
		button_16.Margin = new Padding(3, 4, 3, 4);
		button_16.Name = Class16.smethod_0(1649188813);
		button_16.Size = new Size(26, 23);
		button_16.TabIndex = 43;
		button_16.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_16.UseVisualStyleBackColor = true;
		button_16.Click += button_16_Click;
		label_11.AutoSize = true;
		label_11.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_11.Location = new Point(30, 45);
		label_11.Name = Class16.smethod_0(1649154869);
		label_11.Size = new Size(66, 15);
		label_11.TabIndex = 41;
		label_11.Text = Class16.smethod_0(1648909700);
		textBox_9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_9.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_9.Location = new Point(124, 45);
		textBox_9.Margin = new Padding(3, 4, 3, 4);
		textBox_9.Name = Class16.smethod_0(1649154884);
		textBox_9.Size = new Size(403, 22);
		textBox_9.TabIndex = 42;
		groupBox_3.Controls.Add(textBox_7);
		groupBox_3.Controls.Add(button_14);
		groupBox_3.Controls.Add(label_10);
		groupBox_3.Controls.Add(textBox_8);
		groupBox_3.Controls.Add(button_13);
		groupBox_3.Controls.Add(label_9);
		groupBox_3.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		groupBox_3.Location = new Point(6, 903);
		groupBox_3.Name = Class16.smethod_0(1649154903);
		groupBox_3.Size = new Size(556, 69);
		groupBox_3.TabIndex = 40;
		groupBox_3.TabStop = false;
		groupBox_3.Text = Class16.smethod_0(1649154919);
		textBox_7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_7.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_7.Location = new Point(79, 16);
		textBox_7.Margin = new Padding(3, 4, 3, 4);
		textBox_7.Name = Class16.smethod_0(1649154935);
		textBox_7.Size = new Size(445, 22);
		textBox_7.TabIndex = 20;
		button_14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_14.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_14.Image = Resources.cmdBrowseShopdirLua;
		button_14.Location = new Point(525, 40);
		button_14.Margin = new Padding(3, 4, 3, 4);
		button_14.Name = Class16.smethod_0(1649188114);
		button_14.Size = new Size(26, 22);
		button_14.TabIndex = 25;
		button_14.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_14.UseVisualStyleBackColor = true;
		button_14.Click += button_14_Click;
		label_10.AutoSize = true;
		label_10.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_10.Location = new Point(6, 43);
		label_10.Name = Class16.smethod_0(1649154945);
		label_10.Size = new Size(66, 13);
		label_10.TabIndex = 23;
		label_10.Text = Class16.smethod_0(1649154974);
		textBox_8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_8.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_8.Location = new Point(79, 40);
		textBox_8.Margin = new Padding(3, 4, 3, 4);
		textBox_8.Name = Class16.smethod_0(1649154984);
		textBox_8.Size = new Size(445, 22);
		textBox_8.TabIndex = 24;
		button_13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_13.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_13.Image = Resources.cmdBrowseShopDesc;
		button_13.Location = new Point(525, 15);
		button_13.Margin = new Padding(3, 4, 3, 4);
		button_13.Name = Class16.smethod_0(1649188090);
		button_13.Size = new Size(26, 23);
		button_13.TabIndex = 21;
		button_13.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_13.UseVisualStyleBackColor = true;
		button_13.Click += button_13_Click;
		label_9.AutoSize = true;
		label_9.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_9.Location = new Point(6, 16);
		label_9.Name = Class16.smethod_0(1649155012);
		label_9.Size = new Size(56, 13);
		label_9.TabIndex = 19;
		label_9.Text = Class16.smethod_0(1649155030);
		tabPage_6.Controls.Add(groupBox_15);
		tabPage_6.Controls.Add(groupBox_14);
		tabPage_6.Location = new Point(4, 22);
		tabPage_6.Name = Class16.smethod_0(1649155045);
		tabPage_6.Padding = new Padding(3);
		tabPage_6.Size = new Size(582, 561);
		tabPage_6.TabIndex = 5;
		tabPage_6.Text = Class16.smethod_0(1649155061);
		tabPage_6.UseVisualStyleBackColor = true;
		groupBox_15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_15.Controls.Add(linkLabel_2);
		groupBox_15.Controls.Add(dataGridView_2);
		groupBox_15.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		groupBox_15.Location = new Point(6, 433);
		groupBox_15.Name = Class16.smethod_0(1649154060);
		groupBox_15.Size = new Size(570, 125);
		groupBox_15.TabIndex = 55;
		groupBox_15.TabStop = false;
		groupBox_15.Text = Class16.smethod_0(1649154074);
		linkLabel_2.BackColor = Color.White;
		linkLabel_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		linkLabel_2.Location = new Point(274, 2);
		linkLabel_2.Name = Class16.smethod_0(1649154116);
		linkLabel_2.Size = new Size(292, 13);
		linkLabel_2.TabIndex = 143;
		linkLabel_2.TabStop = true;
		linkLabel_2.Text = Class16.smethod_0(1649154137);
		linkLabel_2.TextAlign = ContentAlignment.MiddleRight;
		linkLabel_2.LinkClicked += linkLabel_2_LinkClicked;
		dataGridView_2.AllowUserToResizeColumns = false;
		dataGridView_2.AllowUserToResizeRows = false;
		dataGridView_2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_2.BackgroundColor = Color.White;
		dataGridView_2.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridView_2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_2.ColumnHeadersHeight = 29;
		dataGridView_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		dataGridView_2.ColumnHeadersVisible = false;
		dataGridView_2.Columns.AddRange(dataGridViewTextBoxColumn_2);
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = Color.White;
		dataGridViewCellStyle5.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewCellStyle5.ForeColor = Color.Black;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = Color.White;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		dataGridView_2.DefaultCellStyle = dataGridViewCellStyle5;
		dataGridView_2.GridColor = Color.Silver;
		dataGridView_2.Location = new Point(4, 22);
		dataGridView_2.Margin = new Padding(3, 4, 3, 4);
		dataGridView_2.MultiSelect = false;
		dataGridView_2.Name = Class16.smethod_0(1649154195);
		dataGridView_2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle6.BackColor = SystemColors.Control;
		dataGridViewCellStyle6.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
		dataGridView_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
		dataGridView_2.RowHeadersVisible = false;
		dataGridView_2.RowHeadersWidth = 51;
		dataGridView_2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle7.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_2.RowsDefaultCellStyle = dataGridViewCellStyle7;
		dataGridView_2.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_2.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_2.ShowCellToolTips = false;
		dataGridView_2.Size = new Size(561, 96);
		dataGridView_2.TabIndex = 142;
		dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle8;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1649156047);
		dataGridViewTextBoxColumn_2.MinimumWidth = 6;
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648914199);
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		groupBox_14.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_14.Controls.Add(linkLabel_1);
		groupBox_14.Controls.Add(dataGridView_1);
		groupBox_14.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		groupBox_14.Location = new Point(6, 6);
		groupBox_14.Name = Class16.smethod_0(1649154217);
		groupBox_14.Size = new Size(570, 421);
		groupBox_14.TabIndex = 54;
		groupBox_14.TabStop = false;
		groupBox_14.Text = Class16.smethod_0(1649154245);
		linkLabel_1.BackColor = Color.White;
		linkLabel_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		linkLabel_1.Location = new Point(271, 2);
		linkLabel_1.Name = Class16.smethod_0(1649154278);
		linkLabel_1.Size = new Size(295, 13);
		linkLabel_1.TabIndex = 143;
		linkLabel_1.TabStop = true;
		linkLabel_1.Text = Class16.smethod_0(1649154298);
		linkLabel_1.TextAlign = ContentAlignment.MiddleRight;
		linkLabel_1.LinkClicked += linkLabel_1_LinkClicked;
		dataGridView_1.AllowUserToResizeColumns = false;
		dataGridView_1.AllowUserToResizeRows = false;
		dataGridView_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_1.BackgroundColor = Color.White;
		dataGridView_1.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridView_1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_1.ColumnHeadersHeight = 29;
		dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		dataGridView_1.ColumnHeadersVisible = false;
		dataGridView_1.Columns.AddRange(dataGridViewTextBoxColumn_1);
		dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle9.BackColor = Color.White;
		dataGridViewCellStyle9.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewCellStyle9.ForeColor = Color.Black;
		dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle9.SelectionForeColor = Color.White;
		dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
		dataGridView_1.DefaultCellStyle = dataGridViewCellStyle9;
		dataGridView_1.GridColor = Color.Silver;
		dataGridView_1.Location = new Point(4, 22);
		dataGridView_1.Margin = new Padding(3, 4, 3, 4);
		dataGridView_1.MultiSelect = false;
		dataGridView_1.Name = Class16.smethod_0(1649154366);
		dataGridView_1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle10.BackColor = SystemColors.Control;
		dataGridViewCellStyle10.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
		dataGridView_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
		dataGridView_1.RowHeadersVisible = false;
		dataGridView_1.RowHeadersWidth = 51;
		dataGridView_1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle11.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_1.RowsDefaultCellStyle = dataGridViewCellStyle11;
		dataGridView_1.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_1.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_1.ShowCellToolTips = false;
		dataGridView_1.Size = new Size(561, 392);
		dataGridView_1.TabIndex = 142;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle12;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1649156047);
		dataGridViewTextBoxColumn_1.MinimumWidth = 6;
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648910847);
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		tabPage_4.AutoScroll = true;
		tabPage_4.Controls.Add(groupBox_8);
		tabPage_4.Controls.Add(groupBox_6);
		tabPage_4.Controls.Add(groupBox_7);
		tabPage_4.Location = new Point(4, 22);
		tabPage_4.Name = Class16.smethod_0(1649154378);
		tabPage_4.Padding = new Padding(3);
		tabPage_4.Size = new Size(582, 561);
		tabPage_4.TabIndex = 5;
		tabPage_4.Text = Class16.smethod_0(1649062219);
		tabPage_4.UseVisualStyleBackColor = true;
		groupBox_8.Controls.Add(textBox_47);
		groupBox_8.Controls.Add(label_58);
		groupBox_8.Controls.Add(textBox_39);
		groupBox_8.Controls.Add(label_48);
		groupBox_8.Controls.Add(textBox_40);
		groupBox_8.Controls.Add(label_49);
		groupBox_8.Controls.Add(textBox_31);
		groupBox_8.Controls.Add(label_39);
		groupBox_8.Controls.Add(textBox_24);
		groupBox_8.Controls.Add(label_31);
		groupBox_8.Controls.Add(textBox_21);
		groupBox_8.Controls.Add(label_28);
		groupBox_8.Controls.Add(textBox_22);
		groupBox_8.Controls.Add(label_29);
		groupBox_8.Controls.Add(textBox_23);
		groupBox_8.Controls.Add(label_30);
		groupBox_8.Controls.Add(textBox_19);
		groupBox_8.Controls.Add(label_26);
		groupBox_8.Controls.Add(textBox_20);
		groupBox_8.Controls.Add(label_27);
		groupBox_8.Controls.Add(button_19);
		groupBox_8.Controls.Add(textBox_18);
		groupBox_8.Controls.Add(label_25);
		groupBox_8.Controls.Add(button_20);
		groupBox_8.Controls.Add(checkBox_16);
		groupBox_8.Controls.Add(textBox_11);
		groupBox_8.Controls.Add(label_16);
		groupBox_8.Location = new Point(6, 219);
		groupBox_8.Name = Class16.smethod_0(1649154394);
		groupBox_8.Size = new Size(554, 348);
		groupBox_8.TabIndex = 47;
		groupBox_8.TabStop = false;
		groupBox_8.Text = Class16.smethod_0(1649210934);
		textBox_47.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_47.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_47.Location = new Point(90, 139);
		textBox_47.Margin = new Padding(3, 4, 3, 4);
		textBox_47.Name = Class16.smethod_0(1649154409);
		textBox_47.Size = new Size(458, 22);
		textBox_47.TabIndex = 42;
		label_58.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_58.Location = new Point(0, 143);
		label_58.Name = Class16.smethod_0(1649154435);
		label_58.Size = new Size(91, 13);
		label_58.TabIndex = 41;
		label_58.Text = Class16.smethod_0(1649154448);
		label_58.TextAlign = ContentAlignment.MiddleLeft;
		textBox_39.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_39.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_39.Location = new Point(89, 112);
		textBox_39.Margin = new Padding(3, 4, 3, 4);
		textBox_39.Name = Class16.smethod_0(1649154478);
		textBox_39.Size = new Size(458, 22);
		textBox_39.TabIndex = 40;
		label_48.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_48.Location = new Point(-1, 116);
		label_48.Name = Class16.smethod_0(1649154496);
		label_48.Size = new Size(91, 13);
		label_48.TabIndex = 39;
		label_48.Text = Class16.smethod_0(1649154517);
		label_48.TextAlign = ContentAlignment.MiddleLeft;
		textBox_40.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_40.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_40.Location = new Point(89, 89);
		textBox_40.Margin = new Padding(3, 4, 3, 4);
		textBox_40.Name = Class16.smethod_0(1649154531);
		textBox_40.Size = new Size(458, 22);
		textBox_40.TabIndex = 38;
		label_49.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_49.Location = new Point(-1, 93);
		label_49.Name = Class16.smethod_0(1649149445);
		label_49.Size = new Size(91, 13);
		label_49.TabIndex = 37;
		label_49.Text = Class16.smethod_0(1649149450);
		label_49.TextAlign = ContentAlignment.MiddleLeft;
		textBox_31.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_31.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_31.Location = new Point(89, 281);
		textBox_31.Margin = new Padding(3, 4, 3, 4);
		textBox_31.Name = Class16.smethod_0(1649149472);
		textBox_31.Size = new Size(458, 22);
		textBox_31.TabIndex = 36;
		label_39.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_39.Location = new Point(1, 285);
		label_39.Name = Class16.smethod_0(1649149502);
		label_39.Size = new Size(91, 13);
		label_39.TabIndex = 35;
		label_39.Text = Class16.smethod_0(1649149524);
		label_39.TextAlign = ContentAlignment.MiddleLeft;
		textBox_24.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_24.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_24.Location = new Point(89, 258);
		textBox_24.Margin = new Padding(3, 4, 3, 4);
		textBox_24.Name = Class16.smethod_0(1649149538);
		textBox_24.Size = new Size(458, 22);
		textBox_24.TabIndex = 34;
		label_31.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_31.Location = new Point(1, 262);
		label_31.Name = Class16.smethod_0(1649149573);
		label_31.Size = new Size(82, 13);
		label_31.TabIndex = 33;
		label_31.Text = Class16.smethod_0(1649149596);
		label_31.TextAlign = ContentAlignment.MiddleLeft;
		textBox_21.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_21.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_21.Location = new Point(89, 235);
		textBox_21.Margin = new Padding(3, 4, 3, 4);
		textBox_21.Name = Class16.smethod_0(1649149615);
		textBox_21.Size = new Size(458, 22);
		textBox_21.TabIndex = 32;
		label_28.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_28.Location = new Point(1, 239);
		label_28.Name = Class16.smethod_0(1649149633);
		label_28.Size = new Size(82, 13);
		label_28.TabIndex = 31;
		label_28.Text = Class16.smethod_0(1649149663);
		label_28.TextAlign = ContentAlignment.MiddleLeft;
		textBox_22.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_22.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_22.Location = new Point(89, 212);
		textBox_22.Margin = new Padding(3, 4, 3, 4);
		textBox_22.Name = Class16.smethod_0(1649149673);
		textBox_22.Size = new Size(458, 22);
		textBox_22.TabIndex = 30;
		label_29.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_29.Location = new Point(1, 216);
		label_29.Name = Class16.smethod_0(1649149696);
		label_29.Size = new Size(82, 13);
		label_29.TabIndex = 29;
		label_29.Text = Class16.smethod_0(1649114972);
		label_29.TextAlign = ContentAlignment.MiddleLeft;
		textBox_23.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_23.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_23.Location = new Point(89, 189);
		textBox_23.Margin = new Padding(3, 4, 3, 4);
		textBox_23.Name = Class16.smethod_0(1649149715);
		textBox_23.Size = new Size(458, 22);
		textBox_23.TabIndex = 28;
		label_30.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_30.Location = new Point(1, 193);
		label_30.Name = Class16.smethod_0(1649149748);
		label_30.Size = new Size(82, 13);
		label_30.TabIndex = 27;
		label_30.Text = Class16.smethod_0(1649149755);
		label_30.TextAlign = ContentAlignment.MiddleLeft;
		textBox_19.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_19.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_19.Location = new Point(89, 166);
		textBox_19.Margin = new Padding(3, 4, 3, 4);
		textBox_19.Name = Class16.smethod_0(1649149776);
		textBox_19.Size = new Size(458, 22);
		textBox_19.TabIndex = 26;
		label_26.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_26.Location = new Point(1, 170);
		label_26.Name = Class16.smethod_0(1649149806);
		label_26.Size = new Size(82, 13);
		label_26.TabIndex = 25;
		label_26.Text = Class16.smethod_0(1649149828);
		label_26.TextAlign = ContentAlignment.MiddleLeft;
		textBox_20.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_20.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_20.Location = new Point(89, 66);
		textBox_20.Margin = new Padding(3, 4, 3, 4);
		textBox_20.Name = Class16.smethod_0(1649149846);
		textBox_20.Size = new Size(458, 22);
		textBox_20.TabIndex = 24;
		label_27.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_27.Location = new Point(1, 70);
		label_27.Name = Class16.smethod_0(1649149871);
		label_27.Size = new Size(91, 13);
		label_27.TabIndex = 23;
		label_27.Text = Class16.smethod_0(1649149892);
		label_27.TextAlign = ContentAlignment.MiddleLeft;
		label_25.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_25.Location = new Point(1, 21);
		label_25.Name = Class16.smethod_0(1649149905);
		label_25.Size = new Size(82, 13);
		label_25.TabIndex = 20;
		label_25.Text = Class16.smethod_0(1649149921);
		label_25.TextAlign = ContentAlignment.MiddleLeft;
		checkBox_16.AutoSize = true;
		checkBox_16.Checked = true;
		checkBox_16.CheckState = CheckState.Checked;
		checkBox_16.Location = new Point(173, 318);
		checkBox_16.Margin = new Padding(3, 4, 3, 4);
		checkBox_16.Name = Class16.smethod_0(1649149943);
		checkBox_16.Size = new Size(238, 17);
		checkBox_16.TabIndex = 17;
		checkBox_16.Text = Class16.smethod_0(1649148938);
		checkBox_16.UseVisualStyleBackColor = true;
		textBox_11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_11.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_11.Location = new Point(89, 43);
		textBox_11.Margin = new Padding(3, 4, 3, 4);
		textBox_11.Name = Class16.smethod_0(1649148985);
		textBox_11.Size = new Size(458, 22);
		textBox_11.TabIndex = 16;
		label_16.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_16.Location = new Point(1, 47);
		label_16.Name = Class16.smethod_0(1649149010);
		label_16.Size = new Size(82, 13);
		label_16.TabIndex = 15;
		label_16.Text = Class16.smethod_0(1649149036);
		label_16.TextAlign = ContentAlignment.MiddleLeft;
		groupBox_6.Controls.Add(label_19);
		groupBox_6.Controls.Add(textBox_14);
		groupBox_6.Controls.Add(textBox_15);
		groupBox_6.Controls.Add(numericUpDown_6);
		groupBox_6.Controls.Add(label_20);
		groupBox_6.Controls.Add(label_21);
		groupBox_6.Controls.Add(textBox_16);
		groupBox_6.Controls.Add(label_22);
		groupBox_6.Controls.Add(textBox_17);
		groupBox_6.Controls.Add(label_23);
		groupBox_6.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		groupBox_6.Location = new Point(6, 6);
		groupBox_6.Name = Class16.smethod_0(1649149049);
		groupBox_6.Size = new Size(553, 104);
		groupBox_6.TabIndex = 41;
		groupBox_6.TabStop = false;
		groupBox_6.Text = Class16.smethod_0(1649149065);
		label_19.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_19.Location = new Point(8, 25);
		label_19.Name = Class16.smethod_0(1649149107);
		label_19.Size = new Size(49, 13);
		label_19.TabIndex = 45;
		label_19.Text = Class16.smethod_0(1649149123);
		label_19.TextAlign = ContentAlignment.MiddleLeft;
		textBox_14.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_14.Location = new Point(58, 22);
		textBox_14.Margin = new Padding(3, 4, 3, 4);
		textBox_14.Name = Class16.smethod_0(1649149137);
		textBox_14.Size = new Size(373, 22);
		textBox_14.TabIndex = 46;
		textBox_15.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_15.Location = new Point(58, 47);
		textBox_15.Margin = new Padding(3, 4, 3, 4);
		textBox_15.Name = Class16.smethod_0(1649149164);
		textBox_15.Size = new Size(210, 22);
		textBox_15.TabIndex = 40;
		numericUpDown_6.Location = new Point(480, 22);
		numericUpDown_6.Maximum = new decimal(new int[4] { 2000000000, 0, 0, 0 });
		numericUpDown_6.Name = Class16.smethod_0(1649149182);
		numericUpDown_6.Size = new Size(67, 22);
		numericUpDown_6.TabIndex = 44;
		numericUpDown_6.TextAlign = HorizontalAlignment.Center;
		numericUpDown_6.Value = new decimal(new int[4] { 22, 0, 0, 0 });
		label_20.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_20.Location = new Point(8, 53);
		label_20.Name = Class16.smethod_0(1649149199);
		label_20.Size = new Size(43, 13);
		label_20.TabIndex = 39;
		label_20.Text = Class16.smethod_0(1649149214);
		label_20.TextAlign = ContentAlignment.MiddleLeft;
		label_21.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_21.Location = new Point(437, 25);
		label_21.Name = Class16.smethod_0(1649149219);
		label_21.Size = new Size(37, 13);
		label_21.TabIndex = 43;
		label_21.Text = Class16.smethod_0(1649149233);
		label_21.TextAlign = ContentAlignment.MiddleRight;
		label_22.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_22.Location = new Point(274, 53);
		label_22.Name = Class16.smethod_0(1649149253);
		label_22.Size = new Size(50, 13);
		label_22.TabIndex = 41;
		label_22.Text = Class16.smethod_0(1649149259);
		label_22.TextAlign = ContentAlignment.MiddleRight;
		textBox_17.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_17.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_17.Location = new Point(110, 75);
		textBox_17.Margin = new Padding(3, 4, 3, 4);
		textBox_17.Name = Class16.smethod_0(1649149275);
		textBox_17.Size = new Size(437, 22);
		textBox_17.TabIndex = 47;
		toolTip_0.SetToolTip(textBox_17, Class16.smethod_0(1649149310));
		label_23.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_23.Location = new Point(8, 80);
		label_23.Name = Class16.smethod_0(1649149369);
		label_23.Size = new Size(96, 13);
		label_23.TabIndex = 48;
		label_23.Text = Class16.smethod_0(1649149404);
		label_23.TextAlign = ContentAlignment.MiddleLeft;
		groupBox_7.Controls.Add(comboBox_2);
		groupBox_7.Controls.Add(label_17);
		groupBox_7.Controls.Add(textBox_12);
		groupBox_7.Controls.Add(label_18);
		groupBox_7.Controls.Add(textBox_13);
		groupBox_7.Controls.Add(label_24);
		groupBox_7.Location = new Point(6, 116);
		groupBox_7.Name = Class16.smethod_0(1649149431);
		groupBox_7.Size = new Size(554, 97);
		groupBox_7.TabIndex = 38;
		groupBox_7.TabStop = false;
		groupBox_7.Text = Class16.smethod_0(1649148417);
		comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_2.FormattingEnabled = true;
		comboBox_2.Items.AddRange(new object[6]
		{
			Class16.smethod_0(1648908427),
			Class16.smethod_0(1649148432),
			Class16.smethod_0(1649148475),
			Class16.smethod_0(1649148500),
			Class16.smethod_0(1649025121),
			Class16.smethod_0(1649025160)
		});
		comboBox_2.Location = new Point(173, 70);
		comboBox_2.Name = Class16.smethod_0(1649148535);
		comboBox_2.Size = new Size(375, 21);
		comboBox_2.TabIndex = 42;
		label_17.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_17.Location = new Point(8, 46);
		label_17.Name = Class16.smethod_0(1649148555);
		label_17.Size = new Size(131, 13);
		label_17.TabIndex = 17;
		label_17.Text = Class16.smethod_0(1649148578);
		label_17.TextAlign = ContentAlignment.MiddleLeft;
		textBox_12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_12.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_12.Location = new Point(156, 41);
		textBox_12.Margin = new Padding(3, 4, 3, 4);
		textBox_12.Name = Class16.smethod_0(1649148600);
		textBox_12.Size = new Size(392, 22);
		textBox_12.TabIndex = 18;
		label_18.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_18.Location = new Point(8, 18);
		label_18.Name = Class16.smethod_0(1649148631);
		label_18.Size = new Size(142, 13);
		label_18.TabIndex = 15;
		label_18.Text = Class16.smethod_0(1649148642);
		label_18.TextAlign = ContentAlignment.MiddleLeft;
		textBox_13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_13.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_13.Location = new Point(156, 13);
		textBox_13.Margin = new Padding(3, 4, 3, 4);
		textBox_13.Name = Class16.smethod_0(1649148676);
		textBox_13.Size = new Size(392, 22);
		textBox_13.TabIndex = 16;
		label_24.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_24.Image = Resources.lblSeverAction;
		label_24.ImageAlign = ContentAlignment.MiddleRight;
		label_24.Location = new Point(8, 73);
		label_24.Name = Class16.smethod_0(1649183295);
		label_24.Size = new Size(159, 13);
		label_24.TabIndex = 43;
		label_24.Text = Class16.smethod_0(1649148695);
		label_24.TextAlign = ContentAlignment.MiddleLeft;
		tabPage_5.Controls.Add(label_54);
		tabPage_5.Controls.Add(button_46);
		tabPage_5.Controls.Add(propertyGrid_0);
		tabPage_5.Location = new Point(4, 22);
		tabPage_5.Name = Class16.smethod_0(1649148717);
		tabPage_5.Padding = new Padding(3);
		tabPage_5.Size = new Size(582, 561);
		tabPage_5.TabIndex = 6;
		tabPage_5.Text = Class16.smethod_0(1649073450);
		tabPage_5.UseVisualStyleBackColor = true;
		label_54.AutoSize = true;
		label_54.BackColor = Color.FromArgb(255, 255, 192);
		label_54.BorderStyle = BorderStyle.FixedSingle;
		label_54.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_54.Location = new Point(85, 8);
		label_54.Name = Class16.smethod_0(1649148723);
		label_54.Size = new Size(107, 15);
		label_54.TabIndex = 56;
		label_54.Text = Class16.smethod_0(1649148746);
		button_46.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_46.Image = Resources.cmdRestoreByDefault;
		button_46.ImageAlign = ContentAlignment.MiddleRight;
		button_46.Location = new Point(374, 4);
		button_46.Name = Class16.smethod_0(1649187526);
		button_46.Size = new Size(205, 23);
		button_46.TabIndex = 55;
		button_46.Text = Class16.smethod_0(1649148782);
		button_46.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_46.UseVisualStyleBackColor = true;
		button_46.Click += button_46_Click;
		propertyGrid_0.Dock = DockStyle.Fill;
		propertyGrid_0.LineColor = SystemColors.ControlDark;
		propertyGrid_0.Location = new Point(3, 3);
		propertyGrid_0.Name = Class16.smethod_0(1649148807);
		propertyGrid_0.Size = new Size(576, 555);
		propertyGrid_0.TabIndex = 54;
		timer_0.Interval = 7000;
		timer_0.Tick += timer_0_Tick;
		base.AcceptButton = button_55;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(600, 637);
		base.Controls.Add(tabControl_0);
		base.Controls.Add(groupBox_16);
		base.Controls.Add(button_0);
		base.Controls.Add(button_55);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.Icon = Resources.SettingsWindow_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		MaximumSize = new Size(616, 2000);
		base.MinimizeBox = false;
		MinimumSize = new Size(616, 316);
		base.Name = Class16.smethod_0(1649148818);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649068916);
		base.FormClosing += SettingsWindow_FormClosing;
		base.Shown += SettingsWindow_Shown;
		groupBox_16.ResumeLayout(performLayout: false);
		groupBox_16.PerformLayout();
		((ISupportInitialize)numericUpDown_5).EndInit();
		((ISupportInitialize)numericUpDown_8).EndInit();
		((ISupportInitialize)numericUpDown_7).EndInit();
		((ISupportInitialize)numericUpDown_9).EndInit();
		((ISupportInitialize)numericUpDown_2).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		((ISupportInitialize)numericUpDown_1).EndInit();
		groupBox_1.ResumeLayout(performLayout: false);
		tabControl_0.ResumeLayout(performLayout: false);
		tabPage_0.ResumeLayout(performLayout: false);
		tableLayoutPanel_0.ResumeLayout(performLayout: false);
		tableLayoutPanel_0.PerformLayout();
		((ISupportInitialize)numericUpDown_3).EndInit();
		tabPage_1.ResumeLayout(performLayout: false);
		tabPage_1.PerformLayout();
		((ISupportInitialize)numericUpDown_10).EndInit();
		groupBox_12.ResumeLayout(performLayout: false);
		groupBox_12.PerformLayout();
		groupBox_13.ResumeLayout(performLayout: false);
		((ISupportInitialize)numericUpDown_4).EndInit();
		groupBox_2.ResumeLayout(performLayout: false);
		tabPage_2.ResumeLayout(performLayout: false);
		tabPage_2.PerformLayout();
		groupBox_10.ResumeLayout(performLayout: false);
		groupBox_10.PerformLayout();
		tabPage_3.ResumeLayout(performLayout: false);
		tabPage_3.PerformLayout();
		groupBox_5.ResumeLayout(performLayout: false);
		groupBox_5.PerformLayout();
		groupBox_9.ResumeLayout(performLayout: false);
		groupBox_9.PerformLayout();
		((ISupportInitialize)dataGridView_0).EndInit();
		groupBox_11.ResumeLayout(performLayout: false);
		groupBox_11.PerformLayout();
		groupBox_4.ResumeLayout(performLayout: false);
		groupBox_4.PerformLayout();
		groupBox_3.ResumeLayout(performLayout: false);
		groupBox_3.PerformLayout();
		tabPage_6.ResumeLayout(performLayout: false);
		groupBox_15.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_2).EndInit();
		groupBox_14.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_1).EndInit();
		tabPage_4.ResumeLayout(performLayout: false);
		groupBox_8.ResumeLayout(performLayout: false);
		groupBox_8.PerformLayout();
		groupBox_6.ResumeLayout(performLayout: false);
		groupBox_6.PerformLayout();
		((ISupportInitialize)numericUpDown_6).EndInit();
		groupBox_7.ResumeLayout(performLayout: false);
		groupBox_7.PerformLayout();
		tabPage_5.ResumeLayout(performLayout: false);
		tabPage_5.PerformLayout();
		((ISupportInitialize)bindingSource_0).EndInit();
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

	private void button_55_Click(object sender, EventArgs e)
	{
		bool_1 = true;
		CommonStorage.AParams = additional_PARAMS_0;
		int langIndex = CommonStorage.LangIndex;
		object value = langIndex.ToString();
		SettingsClass defaultProfile = CommonStorage.DefaultProfile;
		defaultProfile.SaveSetting(defaultProfile.DefaultSection, Class16.smethod_0(1648907720), value);
		paramsClass_0.LoadLastElements = checkBox_0.Checked;
		paramsClass_0.EnableCustomCursors = checkBox_20.Checked;
		CommonStorage.Profile.SaveSetting(Class16.smethod_0(1648906769), paramsClass_0.EnableCustomCursors);
		CommonStorage.PWCursor1 = ACE.RSGlobal.RSGlobal.LoadPWCursor();
		paramsClass_0.LoadLastList = checkBox_1.Checked;
		paramsClass_0.AutoCheckID = checkBox_2.Checked;
		paramsClass_0.ShowItemsColor = checkBox_30.Checked;
		checkBox_31.Checked = paramsClass_0.ShowMobsColor;
		decimal value2 = numericUpDown_1.Value;
		paramsClass_0.MaxMobLevel = (int)value2;
		paramsClass_0.UseAlternativeRecipesNames = checkBox_3.Checked;
		paramsClass_0.DontChangeUniqueID = checkBox_4.Checked;
		paramsClass_0.ShowRealValues = checkBox_5.Checked;
		paramsClass_0.UseAddonsFilter = checkBox_28.Checked;
		paramsClass_0.UseSkillsFilter = checkBox_29.Checked;
		paramsClass_0.ShowUnknownFields = checkBox_6.Checked;
		paramsClass_0.DescriptionsPath = textBox_0.Text;
		paramsClass_0.ColorsPath = textBox_1.Text;
		paramsClass_0.TasksPath = textBox_2.Text;
		paramsClass_0.ShowMainPreviewWindow = checkBox_21.Checked;
		paramsClass_0.DefaultCreator = textBox_3.Text;
		paramsClass_0.ShowIcons = checkBox_10.Checked;
		paramsClass_0.ShowThumbs = checkBox_9.Checked;
		paramsClass_0.SortIcons = checkBox_8.Checked;
		decimal value3 = numericUpDown_0.Value;
		paramsClass_0.ThumbSize = (int)value3;
		paramsClass_0.IconsPath = textBox_5.Text;
		paramsClass_0.IconsNamesPath = textBox_4.Text;
		paramsClass_0.PathDataPath = textBox_6.Text;
		decimal value4 = numericUpDown_2.Value;
		paramsClass_0.FieldHeight = (int)value4;
		if (comboBox_5.SelectedIndex > -1)
		{
			paramsClass_0.FieldDoubleClickAction = comboBox_5.SelectedIndex;
		}
		paramsClass_0.UseAltFont = checkBox_11.Checked;
		if (comboBox_1.SelectedIndex > -1)
		{
			paramsClass_0.NewItemsPlace = comboBox_1.SelectedIndex;
		}
		paramsClass_0.FirstListIndexIs1 = checkBox_26.Checked;
		paramsClass_0.DisableFastSearch = checkBox_27.Checked;
		paramsClass_0.ShopDescPath = textBox_7.Text;
		paramsClass_0.ShopdirLua = textBox_8.Text;
		paramsClass_0.SurfacesPckDir = textBox_27.Text;
		paramsClass_0.GShopPath = textBox_9.Text;
		paramsClass_0.GShop1Path = textBox_44.Text;
		paramsClass_0.GShop2Path = textBox_43.Text;
		paramsClass_0.GShop3Path = textBox_45.Text;
		paramsClass_0.NPCGenPath = textBox_10.Text;
		decimal value5 = numericUpDown_10.Value;
		paramsClass_0.MaxBackupsCount = (int)value5;
		paramsClass_0.AutoUpdate = checkBox_12.Checked;
		paramsClass_0.WarnWhenDeletingItemWithEntries = checkBox_13.Checked;
		decimal value6 = numericUpDown_3.Value;
		paramsClass_0.PreviewRefineLevel = (int)value6;
		paramsClass_0.ExportIconsWithName = checkBox_25.Checked;
		paramsClass_0.PreviewRefine = checkBox_14.Checked;
		paramsClass_0.CompressBackups = checkBox_23.Checked;
		paramsClass_0.IgnoreApiFileNameDifference = checkBox_24.Checked;
		paramsClass_0.SaveActionsHistory = checkBox_15.Checked;
		decimal value7 = numericUpDown_5.Value;
		paramsClass_0.ActionsHistoryLimit = (int)value7;
		decimal value8 = numericUpDown_4.Value;
		paramsClass_0.AHistoryDropDownMenuLimit = (int)value8;
		paramsClass_0.WarnAboutUnsavedElements = checkBox_22.Checked;
		paramsClass_0.SSH.Address = textBox_14.Text;
		paramsClass_0.SSH.Login = textBox_15.Text;
		paramsClass_0.SSH.Port = numericUpDown_6.Text;
		string text = Class16.smethod_0(1649156968);
		if (textBox_16.Text != text)
		{
			paramsClass_0.SSH.Pass = textBox_16.Text;
		}
		paramsClass_0.SSH.ToolsDirectory = textBox_17.Text?.Trim();
		paramsClass_0.SSH.ConfigPath = textBox_18.Text;
		paramsClass_0.SSH.ElementsPath = textBox_11.Text;
		paramsClass_0.SSH.TasksPath = textBox_19.Text;
		paramsClass_0.SSH.GShopPath = textBox_20.Text;
		paramsClass_0.SSH.GShop1Path = textBox_40.Text;
		paramsClass_0.SSH.GShop2Path = textBox_39.Text;
		paramsClass_0.SSH.GShop3Path = textBox_47.Text;
		paramsClass_0.SSH.AIPolicyPath = textBox_23.Text;
		paramsClass_0.SSH.NPCGenPath = textBox_22.Text;
		paramsClass_0.SSH.DomainSevPath = textBox_21.Text;
		paramsClass_0.SSH.Domain2SevPath = textBox_24.Text;
		paramsClass_0.SSH.ExtraDropPath = textBox_31.Text;
		paramsClass_0.SSH.RestartCommand = textBox_13.Text;
		paramsClass_0.SSH.CustomCommand = textBox_12.Text;
		try
		{
			SshIntegration.SaveCommandTemplate(paramsClass_0.SSH._restart_txt, paramsClass_0.SSH.RestartCommand);
			SshIntegration.SaveCommandTemplate(paramsClass_0.SSH._custom_txt, paramsClass_0.SSH.CustomCommand);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649148847));
		}
		if (comboBox_2.SelectedIndex > -1)
		{
			paramsClass_0.SSH.ServerButtonAction = (SERVER_BUTTON_ACTIONS)comboBox_2.SelectedIndex;
		}
		paramsClass_0.Game = (GAMES)comboBox_3.SelectedIndex;
		paramsClass_0.UsePck = checkBox_17.Checked;
		paramsClass_0.ClientPath = textBox_25.Text;
		paramsClass_0.FileIconTitle = textBox_30.Text;
		paramsClass_0.ConfigsPckPath = textBox_26.Text;
		paramsClass_0.SurfacesPckPath = textBox_29.Text;
		paramsClass_0.ModelsPckPath = textBox_28.Text;
		paramsClass_0.GShopSevPath = textBox_32.Text;
		paramsClass_0.GShopSev1Path = textBox_42.Text;
		paramsClass_0.GShopSev2Path = textBox_41.Text;
		paramsClass_0.GShopSev3Path = textBox_46.Text;
		paramsClass_0.DomainSevPath = textBox_36.Text;
		paramsClass_0.Domain2SevPath = textBox_35.Text;
		paramsClass_0.AIPolicyPath = textBox_33.Text;
		paramsClass_0.ExtraDropSevPath = textBox_34.Text;
		paramsClass_0.ElementsPath = textBox_37.Text;
		paramsClass_0.SSH.UseCompression = checkBox_16.Checked;
		paramsClass_0.SaveDescAndColors = checkBox_18.Checked;
		paramsClass_0.PckKeyMode = (PCK_KEY_MODE)comboBox_4.SelectedIndex;
		decimal value9 = numericUpDown_8.Value;
		paramsClass_0.PckKey1 = (int)value9;
		decimal value10 = numericUpDown_7.Value;
		paramsClass_0.PckKey2 = (int)value10;
		paramsClass_0.PckProtectedKey = textBox_38.Text;
		decimal value11 = numericUpDown_9.Value;
		paramsClass_0.ToolTipFieldsNumLimit = (int)value11;
		paramsClass_0.ShowModelPreview = checkBox_19.Checked;
		paramsClass_0.PckFiles = method_2(dataGridView_0);
		additional_PARAMS_0.NpcGenPaths = method_2(dataGridView_1);
		additional_PARAMS_0.PreinctPaths = method_2(dataGridView_2);
		Close();
	}

	private string[] method_2(DataGridView dataGridView_3)
	{
		List<string> list = new List<string>();
		int num = 0;
		if (0 < dataGridView_3.RowCount)
		{
			do
			{
				string text = (string)dataGridView_3.Rows[num].Cells[0].Value;
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text.Trim());
				}
				num++;
			}
			while (num < dataGridView_3.RowCount);
		}
		string[] result = list.ToArray();
		GC.KeepAlive(this);
		return result;
	}

	private void button_45_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(244, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		int num = int_0;
		if (LANG_INFO.CurrentLang.Index != num)
		{
			commonStorage_0.SetLanguage(num);
		}
		Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649148875);
		openFileDialog.FileName = Class16.smethod_0(1649148912);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_0.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649137776);
		openFileDialog.FileName = Class16.smethod_0(1649137809);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_1.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649137965);
		openFileDialog.FileName = Class16.smethod_0(1648910178);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_2.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(241, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(242, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(243, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		commonStorage_0.SetLanguage(comboBox_0.SelectedIndex);
		ToolTip toolTip = toolTip_0;
		TextStorage.TEXTS.SetFormLanguage(this, toolTip);
		comboBox_5.SelectedIndex = paramsClass_0.FieldDoubleClickAction;
		comboBox_1.SelectedIndex = paramsClass_0.NewItemsPlace;
		GC.KeepAlive(this);
	}

	private void method_3(object sender, EventArgs e)
	{
		numericUpDown_0.Text = ((Button)sender).Text;
		GC.KeepAlive(this);
	}

	private void method_4(object sender, EventArgs e)
	{
		numericUpDown_0.Text = ((Button)sender).Text;
		GC.KeepAlive(this);
	}

	private void method_5(object sender, EventArgs e)
	{
		numericUpDown_0.Text = ((Button)sender).Text;
		GC.KeepAlive(this);
	}

	private void method_6(object sender, EventArgs e)
	{
		numericUpDown_0.Text = ((Button)sender).Text;
		GC.KeepAlive(this);
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649147912);
		openFileDialog.FileName = Class16.smethod_0(1649147959);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_5.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649147976);
		openFileDialog.FileName = Class16.smethod_0(1649148023);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_4.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void checkBox_10_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void checkBox_30_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void method_7(object sender, EventArgs e)
	{
	}

	private void button_12_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649148040);
		openFileDialog.FileName = Class16.smethod_0(1648908925);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_6.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(240, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(239, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_11_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(238, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_13_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649148076);
		openFileDialog.FileName = Class16.smethod_0(1649148108);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_7.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void button_14_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649148127);
		openFileDialog.FileName = Class16.smethod_0(1649154974);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_8.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void button_26_Click(object sender, EventArgs e)
	{
		string text = CommonStorage.OpenDirectory(base.Handle, 169);
		if (text != null)
		{
			textBox_27.Text = text;
		}
		GC.KeepAlive(this);
	}

	private void button_16_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649148157);
		openFileDialog.FileName = Class16.smethod_0(1648909700);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_9.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void SettingsWindow_Shown(object sender, EventArgs e)
	{
		if (string_0.StartsWith(Class16.smethod_0(1649067813)))
		{
			tabControl_0.SelectedIndex = 3;
			textBox_25.Focus();
			if (string_0.EndsWith(Class16.smethod_0(1648906382)))
			{
				button_16_Click(null, null);
			}
			else if (string_0.EndsWith(Class16.smethod_0(1649148182)))
			{
				button_21_Click(null, null);
			}
		}
		else if (string_0.StartsWith(Class16.smethod_0(1649143085)))
		{
			tabControl_0.SelectedIndex = 6;
		}
		else if (string_0.StartsWith(Class16.smethod_0(1649137666)))
		{
			tabControl_0.SelectedIndex = 5;
		}
		else if (string_0 == Class16.smethod_0(1649133408))
		{
			tabControl_0.SelectedIndex = 4;
		}
		checkBox_17_CheckedChanged(null, null);
	}

	private void button_17_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(235, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_25_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(237, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_15_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(236, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (tabControl_0.SelectedIndex)
		{
		case 0:
			base.Height = 316;
			break;
		case 2:
			base.Height = 332;
			break;
		default:
			base.Height = 604;
			break;
		case 3:
		case 6:
			base.Height = 604;
			break;
		}
		TabControl tabControl = tabControl_0;
		tabControl_0.TabPages[tabControl.SelectedIndex].Focus();
		GC.KeepAlive(this);
	}

	private void method_8(object sender, EventArgs e)
	{
		tabControl_0.SelectedIndex = 2;
		GC.KeepAlive(this);
	}

	private void checkBox_14_CheckedChanged(object sender, EventArgs e)
	{
		GC.KeepAlive(this);
	}

	private void button_19_Click(object sender, EventArgs e)
	{
		string text = textBox_18.Text;
		text = text.Replace('\\', '/');
		if (!text.EndsWith(Class16.smethod_0(1648892117)))
		{
			text += Class16.smethod_0(1648892117);
		}
		textBox_11.Text = text + Class16.smethod_0(1648909672);
		textBox_19.Text = text + Class16.smethod_0(1648910178);
		textBox_20.Text = text + Class16.smethod_0(1648909700);
		textBox_40.Text = text + Class16.smethod_0(1648909717);
		textBox_39.Text = text + Class16.smethod_0(1648909735);
		textBox_47.Text = text + Class16.smethod_0(1648909745);
		textBox_23.Text = text + Class16.smethod_0(1648908830);
		textBox_31.Text = text + Class16.smethod_0(1648908903);
		textBox_22.Text = text + Class16.smethod_0(1649148202);
		string value = Class16.smethod_0(1648892117);
		int num = text.Substring(0, text.Length - 1).LastIndexOf(value);
		if (num > 0)
		{
			string value2 = Class16.smethod_0(1648892117);
			num = text.Substring(0, num - 1).LastIndexOf(value2);
		}
		if (num > -1)
		{
			string text2 = text.Substring(0, num);
			textBox_21.Text = text2 + Class16.smethod_0(1649148226);
			textBox_24.Text = text2 + Class16.smethod_0(1649148263);
		}
		GC.KeepAlive(this);
	}

	private void button_20_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(563, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_22_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(565, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void checkBox_17_CheckedChanged(object sender, EventArgs e)
	{
		byte b = ((!checkBox_17.Checked) ? ((byte)1) : ((byte)0));
		textBox_27.Enabled = b != 0;
		byte b2 = ((!checkBox_17.Checked) ? ((byte)1) : ((byte)0));
		groupBox_10.Enabled = b2 != 0;
		byte b3 = ((!groupBox_10.Enabled) ? ((byte)1) : ((byte)0));
		label_55.Visible = b3 != 0;
		groupBox_9.Enabled = checkBox_17.Checked;
		GC.KeepAlive(this);
	}

	private void button_31_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(568, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void comboBox_3_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			paramsClass_0.Game = (GAMES)comboBox_3.SelectedIndex;
			ParamsClass paramsClass = paramsClass_0;
			if (paramsClass.Game != GAMES.UNKNOWN_GAME)
			{
				paramsClass.AutoDetectFileIconTitle();
			}
			textBox_30.Text = paramsClass_0.FileIconTitle;
			GC.KeepAlive(this);
		}
	}

	private void button_21_Click(object sender, EventArgs e)
	{
		string text = CommonStorage.OpenDirectory(base.Handle, 569, textBox_25.Text);
		if (text != null)
		{
			textBox_25.Text = text;
			if (string.IsNullOrWhiteSpace(textBox_26.Text))
			{
				button_44_Click(null, null);
			}
			base.AcceptButton = button_55;
			button_55.Focus();
			timer_0.Enabled = true;
		}
		GC.KeepAlive(this);
	}

	private void button_44_Click(object sender, EventArgs e)
	{
		ParamsClass paramsClass = null;
		if (string.IsNullOrWhiteSpace(textBox_25.Text))
		{
			button_21_Click(null, null);
		}
		string text = textBox_25.Text;
		if (!string.IsNullOrWhiteSpace(text))
		{
			if (Directory.Exists(text + Class16.smethod_0(1648909336)))
			{
				text += Class16.smethod_0(1648909336);
			}
			if (!text.EndsWith(Class16.smethod_0(1648927580)))
			{
				text += Class16.smethod_0(1648927580);
			}
			paramsClass = new ParamsClass();
			commonStorage_0.SetDefaultPaths(ref paramsClass, ref additional_PARAMS_0, text, bSetPcksAndPrecincts: false);
			method_12(paramsClass);
			checkBox_17.Checked = true;
			method_9();
			method_11(bool_2: false);
		}
	}

	private void button_23_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_26, Class16.smethod_0(1648908995), Class16.smethod_0(1649148293));
		GC.KeepAlive(this);
	}

	private void button_29_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_29, Class16.smethod_0(1648909021), Class16.smethod_0(1649148333));
		GC.KeepAlive(this);
	}

	private void button_27_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_28, Class16.smethod_0(1648909032), Class16.smethod_0(1649148374));
		GC.KeepAlive(this);
	}

	private void button_24_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(571, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_30_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(570, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_28_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(572, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_42_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(573, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_32_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(574, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_35_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(575, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_41_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(576, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_39_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(577, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_37_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(578, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_43_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_37, Class16.smethod_0(1648909672), Class16.smethod_0(1649148413));
		GC.KeepAlive(this);
	}

	private void button_33_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_32, Class16.smethod_0(1648909763), Class16.smethod_0(1649151517));
		GC.KeepAlive(this);
	}

	private void button_18_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_10, Class16.smethod_0(1648908842), Class16.smethod_0(1649151549));
		GC.KeepAlive(this);
	}

	private void button_34_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_33, Class16.smethod_0(1648908830), Class16.smethod_0(1649151571));
		GC.KeepAlive(this);
	}

	private void button_40_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_36, Class16.smethod_0(1648908868), Class16.smethod_0(1649151603));
		GC.KeepAlive(this);
	}

	private void button_38_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_35, Class16.smethod_0(1648908885), Class16.smethod_0(1649151639));
		GC.KeepAlive(this);
	}

	private void button_36_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_34, Class16.smethod_0(1648908903), Class16.smethod_0(1649151668));
		GC.KeepAlive(this);
	}

	private void comboBox_4_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (comboBox_4.SelectedIndex)
		{
		case 0:
			numericUpDown_8.Visible = false;
			numericUpDown_7.Visible = false;
			textBox_38.Visible = true;
			textBox_38.Enabled = false;
			break;
		case 1:
			numericUpDown_8.Visible = true;
			numericUpDown_7.Visible = true;
			textBox_38.Visible = false;
			break;
		case 2:
			numericUpDown_8.Visible = false;
			numericUpDown_7.Visible = false;
			textBox_38.Visible = true;
			textBox_38.Enabled = true;
			break;
		}
		GC.KeepAlive(this);
	}

	private void linkLabel_0_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		method_9();
	}

	private void method_9()
	{
		if (string.IsNullOrWhiteSpace(textBox_25.Text))
		{
			button_21_Click(null, null);
		}
		string path = textBox_25.Text;
		dataGridView_0.Rows.Clear();
		List<string> list = commonStorage_0.GeneratePcks(path);
		if (list != null)
		{
			List<string>.Enumerator enumerator = list.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					string current = enumerator.Current;
					object[] values = new object[1] { current };
					dataGridView_0.Rows.Add(values);
				}
				while (enumerator.MoveNext());
			}
		}
		GC.KeepAlive(this);
	}

	private void button_46_Click(object sender, EventArgs e)
	{
		additional_PARAMS_0.RestoreByDefault();
		propertyGrid_0.SelectedObject = additional_PARAMS_0;
		GC.KeepAlive(this);
	}

	private void linkLabel_1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		method_10();
	}

	private void linkLabel_2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		method_11(bool_2: true);
	}

	private void method_10()
	{
		string text = CommonStorage.OpenDirectory(base.Handle, 731, additional_PARAMS_0.ServerPath);
		if (text != null)
		{
			additional_PARAMS_0.ServerPath = text;
			dataGridView_1.Rows.Clear();
			List<string> list = commonStorage_0.GenerateNpcgens(additional_PARAMS_0.ServerPath);
			if (list != null)
			{
				List<string>.Enumerator enumerator = list.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						string current = enumerator.Current;
						object[] values = new object[1] { current };
						dataGridView_1.Rows.Add(values);
					}
					while (enumerator.MoveNext());
				}
			}
		}
		GC.KeepAlive(this);
	}

	private void method_11([MarshalAs(UnmanagedType.U1)] bool bool_2)
	{
		string text = null;
		if (!bool_2 && Directory.Exists(textBox_25.Text))
		{
			text = textBox_25.Text;
		}
		else
		{
			string text2 = CommonStorage.OpenDirectory(base.Handle, 732, textBox_25.Text);
			if (text2 != null)
			{
				text = text2;
			}
		}
		if (!string.IsNullOrWhiteSpace(text) && Directory.Exists(text))
		{
			dataGridView_2.Rows.Clear();
			List<string> list = commonStorage_0.GeneratePrecincts(text);
			if (list != null)
			{
				List<string>.Enumerator enumerator = list.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						string current = enumerator.Current;
						object[] values = new object[1] { current };
						dataGridView_2.Rows.Add(values);
					}
					while (enumerator.MoveNext());
				}
			}
		}
		GC.KeepAlive(this);
	}

	private void textBox_25_Enter(object sender, EventArgs e)
	{
		base.AcceptButton = button_21;
	}

	private void textBox_25_Leave(object sender, EventArgs e)
	{
		base.AcceptButton = button_55;
	}

	private void button_50_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_42, Class16.smethod_0(1648909791), Class16.smethod_0(1649151517));
		GC.KeepAlive(this);
	}

	private void button_48_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_41, Class16.smethod_0(1648909812), Class16.smethod_0(1649151517));
		GC.KeepAlive(this);
	}

	private void button_54_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_44, Class16.smethod_0(1648909717), Class16.smethod_0(1649151701));
		GC.KeepAlive(this);
	}

	private void button_52_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_43, Class16.smethod_0(1648909735), Class16.smethod_0(1649151701));
		GC.KeepAlive(this);
	}

	private void button_53_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(775, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_51_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(776, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_49_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(777, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_47_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(778, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void method_12(ParamsClass paramsClass_1)
	{
		textBox_25.Text = paramsClass_1.ClientPath;
		textBox_26.Text = paramsClass_1.ConfigsPckPath;
		textBox_29.Text = paramsClass_1.SurfacesPckPath;
		textBox_28.Text = paramsClass_1.ModelsPckPath;
		textBox_32.Text = paramsClass_1.GShopSevPath;
		textBox_42.Text = paramsClass_1.GShopSev1Path;
		textBox_41.Text = paramsClass_1.GShopSev2Path;
		textBox_46.Text = paramsClass_1.GShopSev3Path;
		textBox_36.Text = paramsClass_1.DomainSevPath;
		textBox_35.Text = paramsClass_1.Domain2SevPath;
		textBox_33.Text = paramsClass_1.AIPolicyPath;
		textBox_34.Text = paramsClass_1.ExtraDropSevPath;
		textBox_37.Text = paramsClass_1.ElementsPath;
		textBox_9.Text = paramsClass_1.GShopPath;
		textBox_44.Text = paramsClass_1.GShop1Path;
		textBox_43.Text = paramsClass_1.GShop2Path;
		textBox_45.Text = paramsClass_1.GShop3Path;
		textBox_10.Text = paramsClass_1.NPCGenPath;
		textBox_6.Text = paramsClass_1.PathDataPath;
		textBox_2.Text = paramsClass_1.TasksPath;
		GC.KeepAlive(this);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		GC.KeepAlive(this);
	}

	private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!bool_1)
		{
			int num = int_1;
			if (CommonStorage.LangIndex != num)
			{
				commonStorage_0.SetLanguage(num);
			}
		}
		GC.KeepAlive(this);
	}

	private void button_56_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(776, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_57_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_45, Class16.smethod_0(1648909745), Class16.smethod_0(1649151701));
		GC.KeepAlive(this);
	}

	private void button_58_Click(object sender, EventArgs e)
	{
		TextStorage.TEXTS.ShowMessage(778, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		GC.KeepAlive(this);
	}

	private void button_59_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(ref textBox_46, Class16.smethod_0(1648908801), Class16.smethod_0(1649151517));
		GC.KeepAlive(this);
	}
}
