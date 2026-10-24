using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.License;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.sTASKedit.Classes;

namespace ACE.Addons;

public class AddonsEditor : Form
{
	private static class Class47
	{
		public static Func<Class49, float> func_0;
	}

	private sealed class Class48
	{
		public AddonsEditor addonsEditor_0;

		public Control control_0;

		internal void method_0(object sender, EventArgs e)
		{
			addonsEditor_0.method_36(control_0);
		}

		internal void method_1(object sender, MouseEventArgs e)
		{
			addonsEditor_0.method_36(control_0);
		}

		internal void method_2(object sender, EventArgs e)
		{
			addonsEditor_0.method_38(control_0);
		}
	}

	private sealed class Class49
	{
		public int int_0;

		public float float_0;

		public Class49(int int_1)
		{
			int_0 = int_1;
			float_0 = 0f;
		}

		public Class49(int int_1, float float_1)
		{
			int_0 = int_1;
			float_0 = float_1;
		}

		public Class49()
		{
			float_0 = 0f;
		}

		public Class49 method_0()
		{
			return new Class49(int_0, float_0);
		}
	}

	private Class49[] class49_0;

	private Class49[] class49_1;

	private Class49[] class49_2;

	private Class49[] class49_3;

	private float[] float_0;

	private float float_1;

	private float[] float_2;

	private float[] float_3;

	private eListCollection eListCollection_0;

	private CommonStorage commonStorage_0;

	private bool bool_0;

	private bool bool_1;

	private ITEMPOS itempos_0;

	private TrackBar trackBar_0;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private CheckBox checkBox_0;

	private ToolTip toolTip_0;

	private CheckBox checkBox_1;

	private NumericUpDown numericUpDown_0;

	private TrackBar trackBar_1;

	private Label label_0;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private CheckBox checkBox_5;

	private NumericUpDown numericUpDown_1;

	private TrackBar trackBar_2;

	private Label label_1;

	private NumericUpDown numericUpDown_2;

	private TrackBar trackBar_3;

	private Label label_2;

	private NumericUpDown numericUpDown_3;

	private TrackBar trackBar_4;

	private Label label_3;

	private NumericUpDown numericUpDown_4;

	private TrackBar trackBar_5;

	private Label label_4;

	private CheckBox checkBox_6;

	private NumericUpDown numericUpDown_5;

	private TrackBar trackBar_6;

	private Label label_5;

	private CheckBox checkBox_7;

	private CheckBox checkBox_8;

	private CheckBox checkBox_9;

	private NumericUpDown numericUpDown_6;

	private TrackBar trackBar_7;

	private Label label_6;

	private NumericUpDown numericUpDown_7;

	private TrackBar trackBar_8;

	private Label label_7;

	private NumericUpDown numericUpDown_8;

	private TrackBar trackBar_9;

	private Label label_8;

	private NumericUpDown numericUpDown_9;

	private TrackBar trackBar_10;

	private Label label_9;

	private Label label_10;

	private ComboBox comboBox_0;

	private NumericUpDown numericUpDown_10;

	private Label label_11;

	private Label label_12;

	private Label label_13;

	private ComboBox comboBox_1;

	private TrackBar trackBar_11;

	private CheckBox checkBox_10;

	private Button button_3;

	private NumericUpDown numericUpDown_11;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private Button button_4;

	private SettingsClass settingsClass_0;

	private CheckBox checkBox_11;

	private NumericUpDown numericUpDown_12;

	private TrackBar trackBar_12;

	private Label label_14;

	private int int_0;

	private int int_1;

	private DataGridView dataGridView_0;

	private NumericUpDown numericUpDown_13;

	private TrackBar trackBar_13;

	private Button button_5;

	private Label label_15;

	private Button button_6;

	private NumericUpDown numericUpDown_14;

	private IContainer icontainer_0;

	private const decimal decimal_0 = 10000000m;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private Button button_7;

	private Button button_8;

	private bool bool_2;

	private byte[] byte_0;

	private Control control_0;

	public AddonsEditor(ITEMPOS _ItemPos, int AddonsTarget, eListCollection ref_eLC, CommonStorage ref_CStorage)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_0, value: true);
			method_21();
			settingsClass_0 = CommonStorage.Profile;
			itempos_0 = _ItemPos;
			eListCollection_0 = ref_eLC;
			commonStorage_0 = ref_CStorage;
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			if (_ItemPos == null)
			{
				return;
			}
			bool_1 = false;
			bool_0 = true;
			int num = itempos_0.int_0;
			int num2 = (int_0 = eListCollection_0.Lists[num].get_fields(Class16.smethod_0(1648922985)));
			num = 4;
			int num3;
			if (num2 > 0)
			{
				num = 5;
				num3 = itempos_0.int_0;
				eList eList2 = eListCollection_0.Lists[num3];
				int_1 = eList2.get_fields(Class16.smethod_0(1648923022));
			}
			else
			{
				label_5.Enabled = false;
				numericUpDown_5.Enabled = false;
				trackBar_6.Enabled = false;
				checkBox_6.Enabled = false;
			}
			if (int_1 > 0)
			{
				num++;
			}
			else
			{
				label_14.Enabled = false;
				numericUpDown_12.Enabled = false;
				trackBar_12.Enabled = false;
				checkBox_11.Enabled = false;
			}
			float[] array = (float_0 = new float[num]);
			num3 = 0;
			int listIndex;
			string text;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					int num4 = num3;
					num = itempos_0.int_0;
					eList eList3 = eListCollection_0.Lists[num];
					text = Class16.smethod_0(1648923043);
					ITEMPOS iTEMPOS = itempos_0;
					num = iTEMPOS.int_1;
					listIndex = iTEMPOS.int_0;
					float valueF = eListCollection_0.GetValueF(listIndex, num, eList3.get_fields(text + num4));
					float_0[num3] = valueF;
					num3++;
				}
				while (num3 < (nint)float_0.LongLength);
			}
			listIndex = 0;
			text = eListCollection_0.Lists[itempos_0.int_0].uListName;
			if (text == Class16.smethod_0(1648923245))
			{
				listIndex = 3;
				label_1.Enabled = false;
				numericUpDown_1.Enabled = false;
				trackBar_2.Enabled = false;
				checkBox_2.Enabled = false;
				label_0.Enabled = false;
				numericUpDown_0.Enabled = false;
				trackBar_1.Enabled = false;
				checkBox_1.Enabled = false;
				int num5 = itempos_0.int_0;
				eList eList4 = eListCollection_0.Lists[num5];
				ITEMPOS iTEMPOS2 = itempos_0;
				num5 = iTEMPOS2.int_1;
				int listIndex2 = iTEMPOS2.int_0;
				if ((float_1 = eListCollection_0.GetValueF(listIndex2, num5, eList4.get_fields(Class16.smethod_0(1648923079)))) > 1f)
				{
					float_1 = 1f;
				}
				decimal value = (decimal)float_1;
				numericUpDown_10.Value = value;
				decimal num6 = 10000000m;
				decimal num7 = (decimal)float_1 * num6;
				trackBar_11.Value = (int)num7;
			}
			else
			{
				label_11.Enabled = false;
				numericUpDown_10.Enabled = false;
				trackBar_11.Enabled = false;
				if (!(text == Class16.smethod_0(1648923366)))
				{
					if (text == Class16.smethod_0(1648923258) || text == Class16.smethod_0(1648923096))
					{
						listIndex = 5;
					}
				}
				else
				{
					listIndex = 0;
					comboBox_0.Enabled = false;
					label_4.Enabled = false;
					numericUpDown_4.Enabled = false;
					trackBar_5.Enabled = false;
					checkBox_5.Enabled = false;
					label_3.Enabled = false;
					numericUpDown_3.Enabled = false;
					trackBar_4.Enabled = false;
					checkBox_4.Enabled = false;
					label_2.Enabled = false;
					numericUpDown_2.Enabled = false;
					trackBar_3.Enabled = false;
					checkBox_3.Enabled = false;
					label_1.Enabled = false;
					numericUpDown_1.Enabled = false;
					trackBar_2.Enabled = false;
					checkBox_2.Enabled = false;
					label_0.Enabled = false;
					numericUpDown_0.Enabled = false;
					trackBar_1.Enabled = false;
					checkBox_1.Enabled = false;
				}
			}
			float_2 = new float[listIndex];
			float_3 = new float[listIndex];
			int num8 = 0;
			int listIndex3;
			if (0 < listIndex)
			{
				do
				{
					int num9 = num8;
					int num10 = itempos_0.int_0;
					eList eList5 = eListCollection_0.Lists[num10];
					string text2 = Class16.smethod_0(1648923120);
					ITEMPOS iTEMPOS3 = itempos_0;
					num10 = iTEMPOS3.int_1;
					listIndex3 = iTEMPOS3.int_0;
					float valueF2 = eListCollection_0.GetValueF(listIndex3, num10, eList5.get_fields(text2 + num9));
					float_3[num8] = valueF2;
					int num11 = num8;
					listIndex3 = itempos_0.int_0;
					eList5 = eListCollection_0.Lists[listIndex3];
					text2 = Class16.smethod_0(1648926230);
					iTEMPOS3 = itempos_0;
					listIndex3 = iTEMPOS3.int_1;
					num10 = iTEMPOS3.int_0;
					float valueF3 = eListCollection_0.GetValueF(num10, listIndex3, eList5.get_fields(text2 + num11));
					float_2[num8] = valueF3;
					num8++;
				}
				while (num8 < listIndex);
			}
			listIndex3 = 0;
			if (0 < (nint)float_0.LongLength)
			{
				do
				{
					float[] array2 = float_0;
					if (array2[listIndex3] > 1f)
					{
						array2[listIndex3] = 1f;
					}
					decimal value2 = (decimal)float_0[listIndex3];
					string text3 = Class16.smethod_0(1648926260);
					((NumericUpDown)base.Controls[text3 + listIndex3]).Value = value2;
					decimal num12 = 10000000m;
					decimal num13 = (decimal)float_0[listIndex3] * num12;
					text3 = Class16.smethod_0(1648926284);
					string text4 = Class16.smethod_0(1648926260);
					((TrackBar)base.Controls[string.Concat(text4 + listIndex3, text3)]).Value = (int)num13;
					listIndex3++;
				}
				while (listIndex3 < (nint)float_0.LongLength);
			}
			class49_1 = new Class49[0];
			class49_2 = new Class49[0];
			class49_3 = new Class49[0];
			listIndex3 = itempos_0.int_0;
			int num14 = eListCollection_0.Lists[listIndex3].get_fields(Class16.smethod_0(1648923486));
			int num15 = eListCollection_0.Lists[listIndex3].get_fields(Class16.smethod_0(1648922763));
			int num16 = num14;
			eList eList6 = eListCollection_0.Lists[listIndex3];
			eList eList7;
			if (num14 <= eList6.get_fields(Class16.smethod_0(1648926289)))
			{
				do
				{
					ITEMPOS iTEMPOS4 = itempos_0;
					num14 = eListCollection_0.GetValueI(iTEMPOS4.int_0, iTEMPOS4.int_1, num16);
					if (num14 != 0)
					{
						Array.Resize(ref class49_1, (int)((nint)class49_1.LongLength + 1));
						Class49[] array3 = class49_1;
						int num17 = (int)((nint)array3.LongLength - 1);
						array3[num17] = new Class49();
						Class49[] array4 = class49_1;
						array4[(nint)array4.LongLength - 1].int_0 = num14;
						iTEMPOS4 = itempos_0;
						float valueF4 = eListCollection_0.GetValueF(iTEMPOS4.int_0, iTEMPOS4.int_1, num16 + 1);
						Class49[] array5 = class49_1;
						array5[(nint)array5.LongLength - 1].float_0 = valueF4;
						Class49[] array6 = class49_1;
						Class49 @class = array6[(nint)array6.LongLength - 1];
						if (@class.float_0 > 1f)
						{
							@class.float_0 = 1f;
						}
						Class49[] array7 = class49_1;
						@class = array7[(nint)array7.LongLength - 1];
						if (@class.float_0 < 0f)
						{
							@class.float_0 = 0f;
						}
					}
					num16 += 2;
					eList7 = eListCollection_0.Lists[listIndex3];
				}
				while (num16 <= eList7.get_fields(Class16.smethod_0(1648926289)));
			}
			int num18 = num15;
			eList7 = eListCollection_0.Lists[listIndex3];
			if (num15 <= eList7.get_fields(Class16.smethod_0(1648923552)))
			{
				eList eList8;
				do
				{
					ITEMPOS iTEMPOS5 = itempos_0;
					int valueI = eListCollection_0.GetValueI(iTEMPOS5.int_0, iTEMPOS5.int_1, num18);
					if (valueI != 0)
					{
						Array.Resize(ref class49_2, (int)((nint)class49_2.LongLength + 1));
						Class49[] array8 = class49_2;
						int num19 = (int)((nint)array8.LongLength - 1);
						array8[num19] = new Class49();
						Class49[] array9 = class49_2;
						array9[(nint)array9.LongLength - 1].int_0 = valueI;
						iTEMPOS5 = itempos_0;
						float valueF5 = eListCollection_0.GetValueF(iTEMPOS5.int_0, iTEMPOS5.int_1, num18 + 1);
						Class49[] array10 = class49_2;
						array10[(nint)array10.LongLength - 1].float_0 = valueF5;
						Class49[] array11 = class49_2;
						Class49 class2 = array11[(nint)array11.LongLength - 1];
						if (class2.float_0 > 1f)
						{
							class2.float_0 = 1f;
						}
						Class49[] array12 = class49_2;
						class2 = array12[(nint)array12.LongLength - 1];
						if (class2.float_0 < 0f)
						{
							class2.float_0 = 0f;
						}
					}
					num18 += 2;
					eList8 = eListCollection_0.Lists[listIndex3];
				}
				while (num18 <= eList8.get_fields(Class16.smethod_0(1648923552)));
			}
			if (text == Class16.smethod_0(1648923245))
			{
				int num20 = eListCollection_0.Lists[listIndex3].get_fields(Class16.smethod_0(1648926314));
				int num21 = eListCollection_0.Lists[listIndex3].get_fields(Class16.smethod_0(1648923510));
				if (num21 < 0)
				{
					num21 = eListCollection_0.Lists[listIndex3].get_fields(Class16.smethod_0(1648923533));
				}
				int num22 = num20;
				if (num20 <= num21)
				{
					do
					{
						ITEMPOS iTEMPOS6 = itempos_0;
						num20 = eListCollection_0.GetValueI(iTEMPOS6.int_0, iTEMPOS6.int_1, num22);
						if (num20 != 0)
						{
							Array.Resize(ref class49_3, (int)((nint)class49_3.LongLength + 1));
							Class49[] array13 = class49_3;
							int num23 = (int)((nint)array13.LongLength - 1);
							array13[num23] = new Class49();
							Class49[] array14 = class49_3;
							array14[(nint)array14.LongLength - 1].int_0 = num20;
							iTEMPOS6 = itempos_0;
							float valueF6 = eListCollection_0.GetValueF(iTEMPOS6.int_0, iTEMPOS6.int_1, num22 + 1);
							Class49[] array15 = class49_3;
							array15[(nint)array15.LongLength - 1].float_0 = valueF6;
							Class49[] array16 = class49_3;
							Class49 class3 = array16[(nint)array16.LongLength - 1];
							if (class3.float_0 > 1f)
							{
								class3.float_0 = 1f;
							}
							Class49[] array17 = class49_3;
							class3 = array17[(nint)array17.LongLength - 1];
							if (class3.float_0 < 0f)
							{
								class3.float_0 = 0f;
							}
						}
						num22 += 2;
					}
					while (num22 <= num21);
				}
			}
			string settingName = Class16.smethod_0(1648926348);
			string section = Class16.smethod_0(1648926373);
			settingName = settingsClass_0.GetSetting(section, settingName, string.Empty);
			if (settingName == Class16.smethod_0(1648934925))
			{
				comboBox_0.SelectedIndex = 1;
			}
			else if (settingName == Class16.smethod_0(1648934967))
			{
				comboBox_0.SelectedIndex = 2;
			}
			else
			{
				comboBox_0.SelectedIndex = 0;
			}
			settingName = Class16.smethod_0(1648926384);
			section = Class16.smethod_0(1648926373);
			settingName = settingsClass_0.GetSetting(section, settingName, string.Empty);
			if (AddonsTarget == -1)
			{
				if (ACE.RSGlobal.RSGlobal.IsUIntFast(settingName))
				{
					int num24 = Convert.ToInt32(settingName);
					if ((uint)num24 <= 2u)
					{
						AddonsTarget = num24;
						if (num24 != -1)
						{
							goto IL_0d00;
						}
					}
				}
				AddonsTarget = 0;
			}
			goto IL_0d00;
			IL_0d00:
			if (itempos_0.int_0 != 3)
			{
				AddonsTarget = ((AddonsTarget != 2) ? AddonsTarget : 0);
				comboBox_1.Items.RemoveAt(2);
			}
			comboBox_1.SelectedIndex = AddonsTarget;
			settingName = Class16.smethod_0(1648926403);
			section = Class16.smethod_0(1648926373);
			if (settingsClass_0.GetSetting(section, settingName, string.Empty) == Class16.smethod_0(1648926418))
			{
				checkBox_0.Checked = true;
			}
			bool_0 = false;
			method_35();
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
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(AddonsEditor));
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		numericUpDown_13 = new NumericUpDown();
		trackBar_13 = new TrackBar();
		numericUpDown_11 = new NumericUpDown();
		button_5 = new Button();
		label_15 = new Label();
		button_6 = new Button();
		numericUpDown_14 = new NumericUpDown();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		checkBox_0 = new CheckBox();
		toolTip_0 = new ToolTip(icontainer_0);
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		checkBox_3 = new CheckBox();
		checkBox_4 = new CheckBox();
		checkBox_5 = new CheckBox();
		checkBox_6 = new CheckBox();
		checkBox_7 = new CheckBox();
		checkBox_8 = new CheckBox();
		checkBox_9 = new CheckBox();
		checkBox_10 = new CheckBox();
		numericUpDown_5 = new NumericUpDown();
		label_5 = new Label();
		label_11 = new Label();
		label_13 = new Label();
		button_3 = new Button();
		checkBox_11 = new CheckBox();
		numericUpDown_12 = new NumericUpDown();
		label_14 = new Label();
		numericUpDown_0 = new NumericUpDown();
		trackBar_1 = new TrackBar();
		label_0 = new Label();
		numericUpDown_1 = new NumericUpDown();
		trackBar_2 = new TrackBar();
		label_1 = new Label();
		numericUpDown_2 = new NumericUpDown();
		trackBar_3 = new TrackBar();
		label_2 = new Label();
		numericUpDown_3 = new NumericUpDown();
		trackBar_4 = new TrackBar();
		label_3 = new Label();
		numericUpDown_4 = new NumericUpDown();
		trackBar_5 = new TrackBar();
		label_4 = new Label();
		trackBar_6 = new TrackBar();
		numericUpDown_6 = new NumericUpDown();
		trackBar_7 = new TrackBar();
		label_6 = new Label();
		numericUpDown_7 = new NumericUpDown();
		trackBar_8 = new TrackBar();
		label_7 = new Label();
		numericUpDown_8 = new NumericUpDown();
		trackBar_9 = new TrackBar();
		label_8 = new Label();
		numericUpDown_9 = new NumericUpDown();
		trackBar_10 = new TrackBar();
		label_9 = new Label();
		label_10 = new Label();
		comboBox_0 = new ComboBox();
		numericUpDown_10 = new NumericUpDown();
		label_12 = new Label();
		comboBox_1 = new ComboBox();
		trackBar_11 = new TrackBar();
		button_4 = new Button();
		trackBar_12 = new TrackBar();
		((ISupportInitialize)dataGridView_0).BeginInit();
		((ISupportInitialize)numericUpDown_13).BeginInit();
		((ISupportInitialize)trackBar_13).BeginInit();
		((ISupportInitialize)numericUpDown_11).BeginInit();
		((ISupportInitialize)numericUpDown_14).BeginInit();
		((ISupportInitialize)numericUpDown_5).BeginInit();
		((ISupportInitialize)numericUpDown_12).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)trackBar_1).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		((ISupportInitialize)trackBar_2).BeginInit();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		((ISupportInitialize)trackBar_3).BeginInit();
		((ISupportInitialize)numericUpDown_3).BeginInit();
		((ISupportInitialize)trackBar_4).BeginInit();
		((ISupportInitialize)numericUpDown_4).BeginInit();
		((ISupportInitialize)trackBar_5).BeginInit();
		((ISupportInitialize)trackBar_6).BeginInit();
		((ISupportInitialize)numericUpDown_6).BeginInit();
		((ISupportInitialize)trackBar_7).BeginInit();
		((ISupportInitialize)numericUpDown_7).BeginInit();
		((ISupportInitialize)trackBar_8).BeginInit();
		((ISupportInitialize)numericUpDown_8).BeginInit();
		((ISupportInitialize)trackBar_9).BeginInit();
		((ISupportInitialize)numericUpDown_9).BeginInit();
		((ISupportInitialize)trackBar_10).BeginInit();
		((ISupportInitialize)numericUpDown_10).BeginInit();
		((ISupportInitialize)trackBar_11).BeginInit();
		((ISupportInitialize)trackBar_12).BeginInit();
		SuspendLayout();
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_0.BackgroundColor = Color.FromArgb(32, 32, 32);
		dataGridView_0.BorderStyle = BorderStyle.None;
		dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_0.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1, dataGridViewTextBoxColumn_2, dataGridViewImageColumn_0, dataGridViewCheckBoxColumn_0);
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(32, 32, 32);
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = Color.White;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = Color.White;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.GridColor = Color.Silver;
		dataGridView_0.Location = new Point(5, 218);
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1648926437);
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
		dataGridView_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowsDefaultCellStyle = dataGridViewCellStyle3;
		dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.Size = new Size(855, 391);
		dataGridView_0.TabIndex = 25;
		dataGridView_0.CellClick += dataGridView_0_CellClick;
		dataGridView_0.CellDoubleClick += dataGridView_0_CellDoubleClick;
		dataGridView_0.CellToolTipTextNeeded += dataGridView_0_CellToolTipTextNeeded;
		dataGridView_0.CellValueChanged += dataGridView_0_CellValueChanged;
		dataGridView_0.ColumnHeaderMouseClick += dataGridView_0_ColumnHeaderMouseClick;
		dataGridView_0.ColumnWidthChanged += dataGridView_0_ColumnWidthChanged;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridView_0.SortCompare += dataGridView_0_SortCompare;
		dataGridView_0.Sorted += dataGridView_0_Sorted;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle4.ForeColor = Color.FromArgb(210, 210, 210);
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648929955);
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 60;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648926449);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648926485);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_1.Width = 300;
		dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle5;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648941080);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648926496);
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.Programmatic;
		dataGridViewTextBoxColumn_2.Width = 90;
		dataGridViewImageColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle6.NullValue = null;
		dataGridViewImageColumn_0.DefaultCellStyle = dataGridViewCellStyle6;
		dataGridViewImageColumn_0.HeaderText = string.Empty;
		dataGridViewImageColumn_0.ImageLayout = DataGridViewImageCellLayout.Stretch;
		dataGridViewImageColumn_0.Name = Class16.smethod_0(1648926525);
		dataGridViewImageColumn_0.ReadOnly = true;
		dataGridViewImageColumn_0.Resizable = DataGridViewTriState.True;
		dataGridViewImageColumn_0.SortMode = DataGridViewColumnSortMode.Programmatic;
		dataGridViewCheckBoxColumn_0.HeaderText = Class16.smethod_0(1648926548);
		dataGridViewCheckBoxColumn_0.Name = Class16.smethod_0(1648926558);
		dataGridViewCheckBoxColumn_0.ReadOnly = true;
		numericUpDown_13.DecimalPlaces = 5;
		numericUpDown_13.Location = new Point(80, 616);
		numericUpDown_13.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_13.Name = Class16.smethod_0(1648926574);
		numericUpDown_13.Size = new Size(89, 22);
		numericUpDown_13.TabIndex = 42;
		numericUpDown_13.TextAlign = HorizontalAlignment.Center;
		numericUpDown_13.ValueChanged += numericUpDown_13_ValueChanged;
		trackBar_13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		trackBar_13.LargeChange = 50;
		trackBar_13.Location = new Point(175, 616);
		trackBar_13.Margin = new Padding(3, 4, 3, 4);
		trackBar_13.Maximum = 1000;
		trackBar_13.Name = Class16.smethod_0(1648926599);
		trackBar_13.Size = new Size(594, 45);
		trackBar_13.SmallChange = 10;
		trackBar_13.TabIndex = 41;
		trackBar_13.TickFrequency = 10;
		trackBar_13.TickStyle = TickStyle.None;
		trackBar_13.Scroll += trackBar_13_Scroll;
		numericUpDown_11.BackColor = Color.FromArgb(225, 255, 225);
		numericUpDown_11.Increment = new decimal(new int[4]);
		numericUpDown_11.Location = new Point(5, 616);
		numericUpDown_11.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_11.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_11.Name = Class16.smethod_0(1648926630);
		numericUpDown_11.Size = new Size(69, 22);
		numericUpDown_11.TabIndex = 44;
		numericUpDown_11.TextAlign = HorizontalAlignment.Center;
		numericUpDown_11.ValueChanged += numericUpDown_11_ValueChanged;
		numericUpDown_11.DoubleClick += numericUpDown_11_DoubleClick;
		button_5.Image = Resources.AddonsEditor_cmdAdd;
		button_5.ImageAlign = ContentAlignment.MiddleRight;
		button_5.Location = new Point(530, 188);
		button_5.Name = Class16.smethod_0(1648926646);
		button_5.Size = new Size(92, 27);
		button_5.TabIndex = 64;
		button_5.Text = Class16.smethod_0(1648931361);
		button_5.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		label_15.BackColor = Color.FromArgb(239, 244, 250);
		label_15.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_15.Location = new Point(753, 616);
		label_15.Name = Class16.smethod_0(1648926651);
		label_15.Size = new Size(51, 16);
		label_15.TabIndex = 63;
		label_15.Text = Class16.smethod_0(1648926675);
		label_15.TextAlign = ContentAlignment.MiddleCenter;
		toolTip_0.SetToolTip(label_15, Class16.smethod_0(1648926694));
		button_6.Image = Resources.cmdDel;
		button_6.ImageAlign = ContentAlignment.MiddleRight;
		button_6.Location = new Point(625, 188);
		button_6.Name = Class16.smethod_0(1648925697);
		button_6.Size = new Size(92, 27);
		button_6.TabIndex = 65;
		button_6.Text = Class16.smethod_0(1648925718);
		button_6.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		numericUpDown_14.BackColor = Color.FromArgb(225, 255, 225);
		numericUpDown_14.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_14.Increment = new decimal(new int[4]);
		numericUpDown_14.Location = new Point(437, 190);
		numericUpDown_14.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_14.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_14.Name = Class16.smethod_0(1648925723);
		numericUpDown_14.Size = new Size(87, 25);
		numericUpDown_14.TabIndex = 66;
		numericUpDown_14.TextAlign = HorizontalAlignment.Center;
		numericUpDown_14.ValueChanged += numericUpDown_14_ValueChanged;
		numericUpDown_14.DoubleClick += numericUpDown_14_DoubleClick;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.OK;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.cmdok;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(5, 643);
		button_0.Name = Class16.smethod_0(1648925748);
		button_0.Size = new Size(426, 26);
		button_0.TabIndex = 67;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648941761);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.Cancel;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.cmdcancel;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(437, 643);
		button_1.Name = Class16.smethod_0(1648925752);
		button_1.Size = new Size(423, 26);
		button_1.TabIndex = 68;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_2.Image = Resources.cmdSort;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(720, 188);
		button_2.Name = Class16.smethod_0(1648925768);
		button_2.Size = new Size(140, 27);
		button_2.TabIndex = 69;
		button_2.Text = Class16.smethod_0(1648925790);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(841, 197);
		checkBox_0.Margin = new Padding(3, 4, 3, 4);
		checkBox_0.Name = Class16.smethod_0(1648925793);
		checkBox_0.Size = new Size(15, 14);
		checkBox_0.TabIndex = 72;
		toolTip_0.SetToolTip(checkBox_0, Class16.smethod_0(1648925811));
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_1.AutoSize = true;
		checkBox_1.Location = new Point(841, 131);
		checkBox_1.Margin = new Padding(3, 4, 3, 4);
		checkBox_1.Name = Class16.smethod_0(1648925863);
		checkBox_1.Size = new Size(15, 14);
		checkBox_1.TabIndex = 99;
		toolTip_0.SetToolTip(checkBox_1, Class16.smethod_0(1648925873));
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_2.AutoSize = true;
		checkBox_2.Location = new Point(841, 107);
		checkBox_2.Margin = new Padding(3, 4, 3, 4);
		checkBox_2.Name = Class16.smethod_0(1648925903);
		checkBox_2.Size = new Size(15, 14);
		checkBox_2.TabIndex = 95;
		toolTip_0.SetToolTip(checkBox_2, Class16.smethod_0(1648925873));
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_3.AutoSize = true;
		checkBox_3.Location = new Point(841, 83);
		checkBox_3.Margin = new Padding(3, 4, 3, 4);
		checkBox_3.Name = Class16.smethod_0(1648925913);
		checkBox_3.Size = new Size(15, 14);
		checkBox_3.TabIndex = 91;
		toolTip_0.SetToolTip(checkBox_3, Class16.smethod_0(1648925873));
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(841, 59);
		checkBox_4.Margin = new Padding(3, 4, 3, 4);
		checkBox_4.Name = Class16.smethod_0(1648925931);
		checkBox_4.Size = new Size(15, 14);
		checkBox_4.TabIndex = 87;
		toolTip_0.SetToolTip(checkBox_4, Class16.smethod_0(1648925873));
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_5.AutoSize = true;
		checkBox_5.Location = new Point(841, 34);
		checkBox_5.Margin = new Padding(3, 4, 3, 4);
		checkBox_5.Name = Class16.smethod_0(1648925957);
		checkBox_5.Size = new Size(15, 14);
		checkBox_5.TabIndex = 83;
		toolTip_0.SetToolTip(checkBox_5, Class16.smethod_0(1648925873));
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_6.AutoSize = true;
		checkBox_6.Location = new Point(414, 106);
		checkBox_6.Margin = new Padding(3, 4, 3, 4);
		checkBox_6.Name = Class16.smethod_0(1648925975);
		checkBox_6.Size = new Size(15, 14);
		checkBox_6.TabIndex = 119;
		toolTip_0.SetToolTip(checkBox_6, Class16.smethod_0(1648925873));
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_7.AutoSize = true;
		checkBox_7.Location = new Point(414, 82);
		checkBox_7.Margin = new Padding(3, 4, 3, 4);
		checkBox_7.Name = Class16.smethod_0(1648925984);
		checkBox_7.Size = new Size(15, 14);
		checkBox_7.TabIndex = 115;
		toolTip_0.SetToolTip(checkBox_7, Class16.smethod_0(1648925873));
		checkBox_7.UseVisualStyleBackColor = true;
		checkBox_8.AutoSize = true;
		checkBox_8.Location = new Point(414, 58);
		checkBox_8.Margin = new Padding(3, 4, 3, 4);
		checkBox_8.Name = Class16.smethod_0(1648926001);
		checkBox_8.Size = new Size(15, 14);
		checkBox_8.TabIndex = 111;
		toolTip_0.SetToolTip(checkBox_8, Class16.smethod_0(1648925873));
		checkBox_8.UseVisualStyleBackColor = true;
		checkBox_9.AutoSize = true;
		checkBox_9.Location = new Point(414, 34);
		checkBox_9.Margin = new Padding(3, 4, 3, 4);
		checkBox_9.Name = Class16.smethod_0(1648926018);
		checkBox_9.Size = new Size(15, 14);
		checkBox_9.TabIndex = 107;
		toolTip_0.SetToolTip(checkBox_9, Class16.smethod_0(1648925873));
		checkBox_9.UseVisualStyleBackColor = true;
		checkBox_10.AutoSize = true;
		checkBox_10.Location = new Point(414, 9);
		checkBox_10.Margin = new Padding(3, 4, 3, 4);
		checkBox_10.Name = Class16.smethod_0(1648926035);
		checkBox_10.Size = new Size(15, 14);
		checkBox_10.TabIndex = 103;
		toolTip_0.SetToolTip(checkBox_10, Class16.smethod_0(1648925873));
		checkBox_10.UseVisualStyleBackColor = true;
		numericUpDown_5.DecimalPlaces = 6;
		numericUpDown_5.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_5.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_5.Location = new Point(64, 101);
		numericUpDown_5.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_5.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_5.Name = Class16.smethod_0(1648926060);
		numericUpDown_5.Size = new Size(71, 22);
		numericUpDown_5.TabIndex = 122;
		numericUpDown_5.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(numericUpDown_5, Class16.smethod_0(1648926085));
		numericUpDown_5.ValueChanged += numericUpDown_9_ValueChanged;
		label_5.AutoSize = true;
		label_5.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_5.Location = new Point(4, 103);
		label_5.Name = Class16.smethod_0(1648926125);
		label_5.Size = new Size(50, 13);
		label_5.TabIndex = 120;
		label_5.Text = Class16.smethod_0(1648926136);
		toolTip_0.SetToolTip(label_5, Class16.smethod_0(1648926085));
		label_11.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_11.Location = new Point(6, 165);
		label_11.Name = Class16.smethod_0(1648926159);
		label_11.Size = new Size(169, 21);
		label_11.TabIndex = 127;
		label_11.Text = Class16.smethod_0(1648926183);
		label_11.TextAlign = ContentAlignment.MiddleRight;
		toolTip_0.SetToolTip(label_11, Class16.smethod_0(1648925189));
		label_13.AutoSize = true;
		label_13.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_13.Location = new Point(106, 6);
		label_13.Name = Class16.smethod_0(1648925222);
		label_13.Size = new Size(245, 20);
		label_13.TabIndex = 131;
		label_13.Text = Class16.smethod_0(1648925236);
		toolTip_0.SetToolTip(label_13, Class16.smethod_0(1648925189));
		label_13.Visible = false;
		button_3.Image = Resources.cmdCopyCraftToDrop;
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(405, 190);
		button_3.Name = Class16.smethod_0(1648925277);
		button_3.Size = new Size(23, 23);
		button_3.TabIndex = 140;
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_0.SetToolTip(button_3, Class16.smethod_0(1648925302));
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		checkBox_11.AutoSize = true;
		checkBox_11.Location = new Point(414, 129);
		checkBox_11.Margin = new Padding(3, 4, 3, 4);
		checkBox_11.Name = Class16.smethod_0(1648925340);
		checkBox_11.Size = new Size(15, 14);
		checkBox_11.TabIndex = 143;
		toolTip_0.SetToolTip(checkBox_11, Class16.smethod_0(1648925873));
		checkBox_11.UseVisualStyleBackColor = true;
		numericUpDown_12.DecimalPlaces = 6;
		numericUpDown_12.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_12.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_12.Location = new Point(64, 124);
		numericUpDown_12.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_12.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_12.Name = Class16.smethod_0(1648925357);
		numericUpDown_12.Size = new Size(71, 22);
		numericUpDown_12.TabIndex = 146;
		numericUpDown_12.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(numericUpDown_12, Class16.smethod_0(1648926085));
		numericUpDown_12.ValueChanged += numericUpDown_9_ValueChanged;
		label_14.AutoSize = true;
		label_14.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_14.Location = new Point(4, 126);
		label_14.Name = Class16.smethod_0(1648925382);
		label_14.Size = new Size(50, 13);
		label_14.TabIndex = 144;
		label_14.Text = Class16.smethod_0(1648925393);
		toolTip_0.SetToolTip(label_14, Class16.smethod_0(1648926085));
		numericUpDown_0.DecimalPlaces = 6;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_0.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_0.Location = new Point(492, 126);
		numericUpDown_0.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_0.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648925408);
		numericUpDown_0.Size = new Size(71, 22);
		numericUpDown_0.TabIndex = 102;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.ValueChanged += numericUpDown_4_ValueChanged;
		trackBar_1.LargeChange = 1000000;
		trackBar_1.Location = new Point(560, 128);
		trackBar_1.Margin = new Padding(3, 4, 3, 4);
		trackBar_1.Maximum = 10000000;
		trackBar_1.Name = Class16.smethod_0(1648925434);
		trackBar_1.Size = new Size(282, 45);
		trackBar_1.TabIndex = 101;
		trackBar_1.TickFrequency = 1000000;
		trackBar_1.TickStyle = TickStyle.None;
		trackBar_1.Scroll += trackBar_5_Scroll;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_0.Location = new Point(447, 128);
		label_0.Name = Class16.smethod_0(1648925466);
		label_0.Size = new Size(46, 13);
		label_0.TabIndex = 100;
		label_0.Text = Class16.smethod_0(1648925494);
		numericUpDown_1.DecimalPlaces = 6;
		numericUpDown_1.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_1.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_1.Location = new Point(492, 102);
		numericUpDown_1.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_1.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_1.Name = Class16.smethod_0(1648925509);
		numericUpDown_1.Size = new Size(71, 22);
		numericUpDown_1.TabIndex = 98;
		numericUpDown_1.TextAlign = HorizontalAlignment.Center;
		numericUpDown_1.ValueChanged += numericUpDown_4_ValueChanged;
		trackBar_2.LargeChange = 1000000;
		trackBar_2.Location = new Point(560, 103);
		trackBar_2.Margin = new Padding(3, 4, 3, 4);
		trackBar_2.Maximum = 10000000;
		trackBar_2.Name = Class16.smethod_0(1648925535);
		trackBar_2.Size = new Size(282, 45);
		trackBar_2.TabIndex = 97;
		trackBar_2.TickFrequency = 1000000;
		trackBar_2.TickStyle = TickStyle.None;
		trackBar_2.Scroll += trackBar_5_Scroll;
		label_1.AutoSize = true;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_1.Location = new Point(447, 104);
		label_1.Name = Class16.smethod_0(1648925567);
		label_1.Size = new Size(46, 13);
		label_1.TabIndex = 96;
		label_1.Text = Class16.smethod_0(1648925579);
		numericUpDown_2.DecimalPlaces = 6;
		numericUpDown_2.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_2.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_2.Location = new Point(492, 78);
		numericUpDown_2.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_2.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_2.Name = Class16.smethod_0(1648925594);
		numericUpDown_2.Size = new Size(71, 22);
		numericUpDown_2.TabIndex = 94;
		numericUpDown_2.TextAlign = HorizontalAlignment.Center;
		numericUpDown_2.ValueChanged += numericUpDown_4_ValueChanged;
		trackBar_3.LargeChange = 1000000;
		trackBar_3.Location = new Point(560, 80);
		trackBar_3.Margin = new Padding(3, 4, 3, 4);
		trackBar_3.Maximum = 10000000;
		trackBar_3.Name = Class16.smethod_0(1648925628);
		trackBar_3.Size = new Size(282, 45);
		trackBar_3.TabIndex = 93;
		trackBar_3.TickFrequency = 1000000;
		trackBar_3.TickStyle = TickStyle.None;
		trackBar_3.Scroll += trackBar_5_Scroll;
		label_2.AutoSize = true;
		label_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_2.Location = new Point(447, 80);
		label_2.Name = Class16.smethod_0(1648925660);
		label_2.Size = new Size(46, 13);
		label_2.TabIndex = 92;
		label_2.Text = Class16.smethod_0(1648925672);
		numericUpDown_3.DecimalPlaces = 6;
		numericUpDown_3.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_3.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_3.Location = new Point(492, 54);
		numericUpDown_3.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_3.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_3.Name = Class16.smethod_0(1648925695);
		numericUpDown_3.Size = new Size(71, 22);
		numericUpDown_3.TabIndex = 90;
		numericUpDown_3.TextAlign = HorizontalAlignment.Center;
		numericUpDown_3.ValueChanged += numericUpDown_4_ValueChanged;
		trackBar_4.LargeChange = 1000000;
		trackBar_4.Location = new Point(560, 56);
		trackBar_4.Margin = new Padding(3, 4, 3, 4);
		trackBar_4.Maximum = 10000000;
		trackBar_4.Name = Class16.smethod_0(1648924689);
		trackBar_4.Size = new Size(282, 45);
		trackBar_4.TabIndex = 89;
		trackBar_4.TickFrequency = 1000000;
		trackBar_4.TickStyle = TickStyle.None;
		trackBar_4.Scroll += trackBar_5_Scroll;
		label_3.AutoSize = true;
		label_3.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_3.Location = new Point(447, 56);
		label_3.Name = Class16.smethod_0(1648924721);
		label_3.Size = new Size(46, 13);
		label_3.TabIndex = 88;
		label_3.Text = Class16.smethod_0(1648924749);
		numericUpDown_4.DecimalPlaces = 6;
		numericUpDown_4.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_4.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_4.Location = new Point(492, 30);
		numericUpDown_4.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_4.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_4.Name = Class16.smethod_0(1648924764);
		numericUpDown_4.Size = new Size(71, 22);
		numericUpDown_4.TabIndex = 86;
		numericUpDown_4.TextAlign = HorizontalAlignment.Center;
		numericUpDown_4.ValueChanged += numericUpDown_4_ValueChanged;
		trackBar_5.LargeChange = 1000000;
		trackBar_5.Location = new Point(560, 32);
		trackBar_5.Margin = new Padding(3, 4, 3, 4);
		trackBar_5.Maximum = 10000000;
		trackBar_5.Name = Class16.smethod_0(1648924790);
		trackBar_5.Size = new Size(282, 45);
		trackBar_5.TabIndex = 85;
		trackBar_5.TickFrequency = 1000000;
		trackBar_5.TickStyle = TickStyle.None;
		trackBar_5.Scroll += trackBar_5_Scroll;
		label_4.AutoSize = true;
		label_4.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_4.Location = new Point(447, 32);
		label_4.Name = Class16.smethod_0(1648924822);
		label_4.Size = new Size(46, 13);
		label_4.TabIndex = 84;
		label_4.Text = Class16.smethod_0(1648924834);
		trackBar_6.LargeChange = 1000000;
		trackBar_6.Location = new Point(133, 103);
		trackBar_6.Margin = new Padding(3, 4, 3, 4);
		trackBar_6.Maximum = 10000000;
		trackBar_6.Name = Class16.smethod_0(1648924849);
		trackBar_6.Size = new Size(282, 45);
		trackBar_6.TabIndex = 121;
		trackBar_6.TickFrequency = 1000000;
		trackBar_6.TickStyle = TickStyle.None;
		trackBar_6.Scroll += trackBar_12_Scroll;
		numericUpDown_6.DecimalPlaces = 6;
		numericUpDown_6.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_6.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_6.Location = new Point(64, 77);
		numericUpDown_6.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_6.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_6.Name = Class16.smethod_0(1648924880);
		numericUpDown_6.Size = new Size(71, 22);
		numericUpDown_6.TabIndex = 118;
		numericUpDown_6.TextAlign = HorizontalAlignment.Center;
		numericUpDown_6.ValueChanged += numericUpDown_9_ValueChanged;
		trackBar_7.LargeChange = 1000000;
		trackBar_7.Location = new Point(133, 78);
		trackBar_7.Margin = new Padding(3, 4, 3, 4);
		trackBar_7.Maximum = 10000000;
		trackBar_7.Name = Class16.smethod_0(1648924905);
		trackBar_7.Size = new Size(282, 45);
		trackBar_7.TabIndex = 117;
		trackBar_7.TickFrequency = 1000000;
		trackBar_7.TickStyle = TickStyle.None;
		trackBar_7.Scroll += trackBar_12_Scroll;
		label_6.AutoSize = true;
		label_6.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_6.Location = new Point(1, 79);
		label_6.Name = Class16.smethod_0(1648930206);
		label_6.Size = new Size(58, 13);
		label_6.TabIndex = 116;
		label_6.Text = Class16.smethod_0(1648924936);
		numericUpDown_7.DecimalPlaces = 6;
		numericUpDown_7.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_7.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_7.Location = new Point(64, 53);
		numericUpDown_7.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_7.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_7.Name = Class16.smethod_0(1648924952);
		numericUpDown_7.Size = new Size(71, 22);
		numericUpDown_7.TabIndex = 114;
		numericUpDown_7.TextAlign = HorizontalAlignment.Center;
		numericUpDown_7.ValueChanged += numericUpDown_9_ValueChanged;
		trackBar_8.LargeChange = 1000000;
		trackBar_8.Location = new Point(133, 55);
		trackBar_8.Margin = new Padding(3, 4, 3, 4);
		trackBar_8.Maximum = 10000000;
		trackBar_8.Name = Class16.smethod_0(1648924977);
		trackBar_8.Size = new Size(282, 45);
		trackBar_8.TabIndex = 113;
		trackBar_8.TickFrequency = 1000000;
		trackBar_8.TickStyle = TickStyle.None;
		trackBar_8.Scroll += trackBar_12_Scroll;
		label_7.AutoSize = true;
		label_7.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_7.Location = new Point(4, 55);
		label_7.Name = Class16.smethod_0(1648925008);
		label_7.Size = new Size(50, 13);
		label_7.TabIndex = 112;
		label_7.Text = Class16.smethod_0(1648925029);
		numericUpDown_8.DecimalPlaces = 6;
		numericUpDown_8.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_8.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_8.Location = new Point(64, 29);
		numericUpDown_8.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_8.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_8.Name = Class16.smethod_0(1648925044);
		numericUpDown_8.Size = new Size(71, 22);
		numericUpDown_8.TabIndex = 110;
		numericUpDown_8.TextAlign = HorizontalAlignment.Center;
		numericUpDown_8.ValueChanged += numericUpDown_9_ValueChanged;
		trackBar_9.LargeChange = 1000000;
		trackBar_9.Location = new Point(133, 31);
		trackBar_9.Margin = new Padding(3, 4, 3, 4);
		trackBar_9.Maximum = 10000000;
		trackBar_9.Name = Class16.smethod_0(1648925069);
		trackBar_9.Size = new Size(282, 45);
		trackBar_9.TabIndex = 109;
		trackBar_9.TickFrequency = 1000000;
		trackBar_9.TickStyle = TickStyle.None;
		trackBar_9.Scroll += trackBar_12_Scroll;
		label_8.AutoSize = true;
		label_8.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_8.Location = new Point(4, 31);
		label_8.Name = Class16.smethod_0(1648925100);
		label_8.Size = new Size(50, 13);
		label_8.TabIndex = 108;
		label_8.Text = Class16.smethod_0(1648925105);
		numericUpDown_9.DecimalPlaces = 6;
		numericUpDown_9.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_9.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_9.Location = new Point(64, 5);
		numericUpDown_9.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_9.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_9.Name = Class16.smethod_0(1648925120);
		numericUpDown_9.Size = new Size(71, 22);
		numericUpDown_9.TabIndex = 106;
		numericUpDown_9.TextAlign = HorizontalAlignment.Center;
		numericUpDown_9.ValueChanged += numericUpDown_9_ValueChanged;
		trackBar_10.LargeChange = 1000000;
		trackBar_10.Location = new Point(133, 7);
		trackBar_10.Margin = new Padding(3, 4, 3, 4);
		trackBar_10.Maximum = 10000000;
		trackBar_10.Name = Class16.smethod_0(1648925145);
		trackBar_10.Size = new Size(282, 45);
		trackBar_10.TabIndex = 105;
		trackBar_10.TickFrequency = 1000000;
		trackBar_10.TickStyle = TickStyle.None;
		trackBar_10.Scroll += trackBar_12_Scroll;
		label_9.AutoSize = true;
		label_9.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_9.Location = new Point(4, 7);
		label_9.Name = Class16.smethod_0(1648925176);
		label_9.Size = new Size(50, 13);
		label_9.TabIndex = 104;
		label_9.Text = Class16.smethod_0(1648920078);
		label_10.BackColor = Color.White;
		label_10.BorderStyle = BorderStyle.Fixed3D;
		label_10.Location = new Point(437, 6);
		label_10.Name = Class16.smethod_0(1648920093);
		label_10.Size = new Size(3, 145);
		label_10.TabIndex = 123;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1648920099),
			Class16.smethod_0(1648920145),
			Class16.smethod_0(1648920198)
		});
		comboBox_0.Location = new Point(446, 3);
		comboBox_0.Name = Class16.smethod_0(1648920248);
		comboBox_0.Size = new Size(410, 21);
		comboBox_0.TabIndex = 124;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		numericUpDown_10.DecimalPlaces = 6;
		numericUpDown_10.Font = new Font(Class16.smethod_0(1648942905), 8f);
		numericUpDown_10.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_10.Location = new Point(181, 166);
		numericUpDown_10.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_10.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_10.Name = Class16.smethod_0(1648920284);
		numericUpDown_10.Size = new Size(71, 22);
		numericUpDown_10.TabIndex = 129;
		numericUpDown_10.TextAlign = HorizontalAlignment.Center;
		numericUpDown_10.ValueChanged += numericUpDown_10_ValueChanged;
		label_12.BackColor = Color.White;
		label_12.BorderStyle = BorderStyle.Fixed3D;
		label_12.Location = new Point(5, 153);
		label_12.Name = Class16.smethod_0(1648920306);
		label_12.Size = new Size(855, 3);
		label_12.TabIndex = 130;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1648920320),
			Class16.smethod_0(1648920351),
			Class16.smethod_0(1648920372)
		});
		comboBox_1.Location = new Point(5, 190);
		comboBox_1.Name = Class16.smethod_0(1648920385);
		comboBox_1.Size = new Size(397, 21);
		comboBox_1.TabIndex = 139;
		comboBox_1.SelectedIndexChanged += comboBox_1_SelectedIndexChanged;
		trackBar_11.LargeChange = 1000000;
		trackBar_11.Location = new Point(250, 166);
		trackBar_11.Margin = new Padding(3, 4, 3, 4);
		trackBar_11.Maximum = 10000000;
		trackBar_11.Name = Class16.smethod_0(1648920415);
		trackBar_11.Size = new Size(610, 45);
		trackBar_11.TabIndex = 128;
		trackBar_11.TickFrequency = 1000000;
		trackBar_11.TickStyle = TickStyle.None;
		trackBar_11.Scroll += trackBar_11_Scroll;
		button_4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_4.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		button_4.ImageAlign = ContentAlignment.MiddleRight;
		button_4.Location = new Point(799, 613);
		button_4.Name = Class16.smethod_0(1648920454);
		button_4.Size = new Size(61, 27);
		button_4.TabIndex = 141;
		button_4.Text = Class16.smethod_0(1648920478);
		button_4.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		trackBar_12.LargeChange = 1000000;
		trackBar_12.Location = new Point(133, 126);
		trackBar_12.Margin = new Padding(3, 4, 3, 4);
		trackBar_12.Maximum = 10000000;
		trackBar_12.Name = Class16.smethod_0(1648920489);
		trackBar_12.Size = new Size(282, 45);
		trackBar_12.TabIndex = 145;
		trackBar_12.TickFrequency = 1000000;
		trackBar_12.TickStyle = TickStyle.None;
		trackBar_12.Scroll += trackBar_12_Scroll;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_1;
		base.ClientSize = new Size(864, 673);
		base.Controls.Add(checkBox_11);
		base.Controls.Add(checkBox_6);
		base.Controls.Add(button_3);
		base.Controls.Add(button_2);
		base.Controls.Add(button_6);
		base.Controls.Add(button_5);
		base.Controls.Add(numericUpDown_14);
		base.Controls.Add(comboBox_1);
		base.Controls.Add(trackBar_11);
		base.Controls.Add(numericUpDown_10);
		base.Controls.Add(label_12);
		base.Controls.Add(trackBar_12);
		base.Controls.Add(trackBar_6);
		base.Controls.Add(numericUpDown_12);
		base.Controls.Add(label_14);
		base.Controls.Add(button_4);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(dataGridView_0);
		base.Controls.Add(label_13);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(checkBox_1);
		base.Controls.Add(trackBar_1);
		base.Controls.Add(label_11);
		base.Controls.Add(comboBox_0);
		base.Controls.Add(label_10);
		base.Controls.Add(numericUpDown_5);
		base.Controls.Add(label_5);
		base.Controls.Add(checkBox_7);
		base.Controls.Add(checkBox_8);
		base.Controls.Add(checkBox_9);
		base.Controls.Add(checkBox_10);
		base.Controls.Add(numericUpDown_6);
		base.Controls.Add(trackBar_7);
		base.Controls.Add(label_6);
		base.Controls.Add(numericUpDown_7);
		base.Controls.Add(trackBar_8);
		base.Controls.Add(label_7);
		base.Controls.Add(numericUpDown_8);
		base.Controls.Add(trackBar_9);
		base.Controls.Add(label_8);
		base.Controls.Add(numericUpDown_9);
		base.Controls.Add(trackBar_10);
		base.Controls.Add(label_9);
		base.Controls.Add(label_0);
		base.Controls.Add(checkBox_2);
		base.Controls.Add(checkBox_3);
		base.Controls.Add(checkBox_4);
		base.Controls.Add(checkBox_5);
		base.Controls.Add(numericUpDown_1);
		base.Controls.Add(trackBar_2);
		base.Controls.Add(label_1);
		base.Controls.Add(numericUpDown_2);
		base.Controls.Add(trackBar_3);
		base.Controls.Add(label_2);
		base.Controls.Add(numericUpDown_3);
		base.Controls.Add(trackBar_4);
		base.Controls.Add(label_3);
		base.Controls.Add(numericUpDown_4);
		base.Controls.Add(trackBar_5);
		base.Controls.Add(label_4);
		base.Controls.Add(button_0);
		base.Controls.Add(button_1);
		base.Controls.Add(label_15);
		base.Controls.Add(numericUpDown_11);
		base.Controls.Add(numericUpDown_13);
		base.Controls.Add(trackBar_13);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.AddonsEditor_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(880, 500);
		base.Name = Class16.smethod_0(1648926373);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648920520);
		toolTip_0.SetToolTip(this, Class16.smethod_0(1648920548));
		base.Shown += AddonsEditor_Shown;
		base.Resize += AddonsEditor_Resize;
		base.Activated += AddonsEditor_Activated;
		((ISupportInitialize)dataGridView_0).EndInit();
		((ISupportInitialize)numericUpDown_13).EndInit();
		((ISupportInitialize)trackBar_13).EndInit();
		((ISupportInitialize)numericUpDown_11).EndInit();
		((ISupportInitialize)numericUpDown_14).EndInit();
		((ISupportInitialize)numericUpDown_5).EndInit();
		((ISupportInitialize)numericUpDown_12).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)trackBar_1).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		((ISupportInitialize)trackBar_2).EndInit();
		((ISupportInitialize)numericUpDown_2).EndInit();
		((ISupportInitialize)trackBar_3).EndInit();
		((ISupportInitialize)numericUpDown_3).EndInit();
		((ISupportInitialize)trackBar_4).EndInit();
		((ISupportInitialize)numericUpDown_4).EndInit();
		((ISupportInitialize)trackBar_5).EndInit();
		((ISupportInitialize)trackBar_6).EndInit();
		((ISupportInitialize)numericUpDown_6).EndInit();
		((ISupportInitialize)trackBar_7).EndInit();
		((ISupportInitialize)numericUpDown_7).EndInit();
		((ISupportInitialize)trackBar_8).EndInit();
		((ISupportInitialize)numericUpDown_8).EndInit();
		((ISupportInitialize)trackBar_9).EndInit();
		((ISupportInitialize)numericUpDown_9).EndInit();
		((ISupportInitialize)trackBar_10).EndInit();
		((ISupportInitialize)numericUpDown_10).EndInit();
		((ISupportInitialize)trackBar_11).EndInit();
		((ISupportInitialize)trackBar_12).EndInit();
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

	private NumericUpDown method_2(int int_2)
	{
		return int_2 switch
		{
			0 => numericUpDown_9, 
			1 => numericUpDown_8, 
			2 => numericUpDown_7, 
			3 => numericUpDown_6, 
			4 => numericUpDown_5, 
			5 => numericUpDown_12, 
			_ => null, 
		};
	}

	private CheckBox method_3(int int_2)
	{
		return int_2 switch
		{
			0 => checkBox_10, 
			1 => checkBox_9, 
			2 => checkBox_8, 
			3 => checkBox_7, 
			4 => checkBox_6, 
			5 => checkBox_11, 
			_ => null, 
		};
	}

	private TrackBar method_4(int int_2)
	{
		return int_2 switch
		{
			0 => trackBar_10, 
			1 => trackBar_9, 
			2 => trackBar_8, 
			3 => trackBar_7, 
			4 => trackBar_6, 
			5 => trackBar_12, 
			_ => null, 
		};
	}

	private int method_5(NumericUpDown numericUpDown_15)
	{
		if (numericUpDown_15 == numericUpDown_9)
		{
			return 0;
		}
		if (numericUpDown_15 == numericUpDown_8)
		{
			return 1;
		}
		if (numericUpDown_15 == numericUpDown_7)
		{
			return 2;
		}
		if (numericUpDown_15 == numericUpDown_6)
		{
			return 3;
		}
		if (numericUpDown_15 == numericUpDown_5)
		{
			return 4;
		}
		if (numericUpDown_15 == numericUpDown_12)
		{
			return 5;
		}
		return -1;
	}

	private int method_6(TrackBar trackBar_14)
	{
		if (trackBar_14 == trackBar_10)
		{
			return 0;
		}
		if (trackBar_14 == trackBar_9)
		{
			return 1;
		}
		if (trackBar_14 == trackBar_8)
		{
			return 2;
		}
		if (trackBar_14 == trackBar_7)
		{
			return 3;
		}
		if (trackBar_14 == trackBar_6)
		{
			return 4;
		}
		if (trackBar_14 == trackBar_12)
		{
			return 5;
		}
		return -1;
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (comboBox_1.SelectedIndex)
		{
		case 0:
			class49_0 = class49_1;
			break;
		case 1:
			class49_0 = class49_2;
			break;
		case 2:
			class49_0 = class49_3;
			break;
		}
		method_15();
	}

	private void numericUpDown_9_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		NumericUpDown numericUpDown = (NumericUpDown)sender;
		int num = method_5(numericUpDown);
		if (num < 0)
		{
			return;
		}
		TrackBar trackBar = method_4(num);
		if (trackBar != null)
		{
			if (!bool_1 || trackBar != trackBar_0)
			{
				method_37(numericUpDown);
			}
			if (float_0 != null && num < float_0.Length)
			{
				float_0[num] = (float)numericUpDown.Value;
			}
			if (!bool_1 || trackBar != trackBar_0)
			{
				int val = (int)(numericUpDown.Value * 10000000m);
				val = Math.Max(trackBar.Minimum, Math.Min(trackBar.Maximum, val));
				trackBar.Value = val;
				GC.KeepAlive(this);
			}
		}
	}

	private void trackBar_12_Scroll(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_37((Control)sender);
			trackBar_0 = (TrackBar)sender;
			bool_1 = true;
			method_7();
			bool_1 = false;
		}
	}

	private void method_7()
	{
		if (trackBar_0 == null || float_0 == null || float_0.Length == 0)
		{
			return;
		}
		int num = method_6(trackBar_0);
		if (num < 0)
		{
			return;
		}
		NumericUpDown numericUpDown = method_2(num);
		if (numericUpDown == null)
		{
			return;
		}
		int num2 = float_0.Length;
		decimal num3 = (decimal)trackBar_0.Value / 10000000m;
		decimal num4 = 1m - num3;
		decimal num5 = default(decimal);
		int num6 = 0;
		for (int i = 0; i < num2; i++)
		{
			NumericUpDown numericUpDown2 = method_2(i);
			CheckBox checkBox = method_3(i);
			if (numericUpDown2 != null && checkBox != null && numericUpDown2 != numericUpDown)
			{
				if (checkBox.Checked)
				{
					num4 -= numericUpDown2.Value;
					num6++;
				}
				else
				{
					num5 += numericUpDown2.Value;
				}
			}
		}
		if (!(num4 < 0m) && (!(num5 == 0m) || num6 < num2 - 1))
		{
			numericUpDown.Value = num3;
		}
		else
		{
			int val = (int)(numericUpDown.Value * 10000000m);
			val = Math.Max(trackBar_0.Minimum, Math.Min(trackBar_0.Maximum, val));
			trackBar_0.Value = val;
		}
		for (int j = 0; j < num2; j++)
		{
			NumericUpDown numericUpDown3 = method_2(j);
			CheckBox checkBox2 = method_3(j);
			if (numericUpDown3 != null && checkBox2 != null && numericUpDown3 != numericUpDown && !checkBox2.Checked)
			{
				decimal num7 = ((!(num5 > 0m)) ? (1m / (decimal)num2) : (numericUpDown3.Value / num5));
				if (num4 <= 0m)
				{
					num7 = default(decimal);
				}
				decimal val2 = num4 * num7;
				val2 = Math.Max(0m, Math.Min(1m, val2));
				numericUpDown3.Value = val2;
			}
		}
		decimal num8 = default(decimal);
		for (int k = 0; k < num2; k++)
		{
			NumericUpDown numericUpDown4 = method_2(k);
			if (numericUpDown4 != null)
			{
				num8 += numericUpDown4.Value;
			}
		}
		if (num8 < 1m)
		{
			decimal num9 = 1m - num8;
			decimal value = Math.Max(0m, Math.Min(1m, numericUpDown.Value + num9));
			numericUpDown.Value = value;
		}
		GC.KeepAlive(this);
	}

	private NumericUpDown method_8(int int_2)
	{
		return int_2 switch
		{
			0 => numericUpDown_4, 
			1 => numericUpDown_3, 
			2 => numericUpDown_2, 
			3 => numericUpDown_1, 
			4 => numericUpDown_0, 
			_ => null, 
		};
	}

	private CheckBox method_9(int int_2)
	{
		return int_2 switch
		{
			0 => checkBox_5, 
			1 => checkBox_4, 
			2 => checkBox_3, 
			3 => checkBox_2, 
			4 => checkBox_1, 
			_ => null, 
		};
	}

	private TrackBar method_10(int int_2)
	{
		return int_2 switch
		{
			0 => trackBar_5, 
			1 => trackBar_4, 
			2 => trackBar_3, 
			3 => trackBar_2, 
			4 => trackBar_1, 
			_ => null, 
		};
	}

	private int method_11(NumericUpDown numericUpDown_15)
	{
		if (numericUpDown_15 == numericUpDown_4)
		{
			return 0;
		}
		if (numericUpDown_15 == numericUpDown_3)
		{
			return 1;
		}
		if (numericUpDown_15 == numericUpDown_2)
		{
			return 2;
		}
		if (numericUpDown_15 == numericUpDown_1)
		{
			return 3;
		}
		if (numericUpDown_15 == numericUpDown_0)
		{
			return 4;
		}
		return -1;
	}

	private int method_12(TrackBar trackBar_14)
	{
		if (trackBar_14 == trackBar_5)
		{
			return 0;
		}
		if (trackBar_14 == trackBar_4)
		{
			return 1;
		}
		if (trackBar_14 == trackBar_3)
		{
			return 2;
		}
		if (trackBar_14 == trackBar_2)
		{
			return 3;
		}
		if (trackBar_14 == trackBar_1)
		{
			return 4;
		}
		return -1;
	}

	private void numericUpDown_4_ValueChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		NumericUpDown numericUpDown = (NumericUpDown)sender;
		int num = method_11(numericUpDown);
		if (num < 0)
		{
			return;
		}
		TrackBar trackBar = method_10(num);
		if (trackBar == null)
		{
			return;
		}
		if (!bool_1 || trackBar != trackBar_0)
		{
			method_37(numericUpDown);
		}
		float num2 = (float)numericUpDown.Value;
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (float_2 != null && num < float_2.Length)
			{
				float_2[num] = num2;
			}
			break;
		case 1:
			if (float_3 != null && num < float_3.Length)
			{
				float_3[num] = num2;
			}
			break;
		case 2:
			if (float_2 != null && num < float_2.Length)
			{
				float_2[num] = num2;
			}
			if (float_3 != null && num < float_3.Length)
			{
				float_3[num] = num2;
			}
			break;
		}
		if (!bool_1 || trackBar != trackBar_0)
		{
			int val = (int)(numericUpDown.Value * 10000000m);
			val = Math.Max(trackBar.Minimum, Math.Min(trackBar.Maximum, val));
			trackBar.Value = val;
			GC.KeepAlive(this);
		}
	}

	private void trackBar_5_Scroll(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_37((Control)sender);
			trackBar_0 = (TrackBar)sender;
			bool_1 = true;
			method_13();
			bool_1 = false;
		}
	}

	private void method_13()
	{
		if (trackBar_0 == null || float_2 == null || float_2.Length == 0)
		{
			return;
		}
		int num = method_12(trackBar_0);
		if (num < 0)
		{
			return;
		}
		NumericUpDown numericUpDown = method_8(num);
		if (numericUpDown == null)
		{
			return;
		}
		int num2 = float_2.Length;
		decimal num3 = (decimal)trackBar_0.Value / 10000000m;
		decimal num4 = 1m - num3;
		decimal num5 = default(decimal);
		int num6 = 0;
		for (int i = 0; i < num2; i++)
		{
			NumericUpDown numericUpDown2 = method_8(i);
			CheckBox checkBox = method_9(i);
			if (numericUpDown2 != null && checkBox != null && numericUpDown2 != numericUpDown)
			{
				if (checkBox.Checked)
				{
					num4 -= numericUpDown2.Value;
					num6++;
				}
				else
				{
					num5 += numericUpDown2.Value;
				}
			}
		}
		if (!(num4 < 0m) && (!(num5 == 0m) || num6 < num2 - 1))
		{
			numericUpDown.Value = num3;
		}
		else
		{
			int val = (int)(numericUpDown.Value * 10000000m);
			val = Math.Max(trackBar_0.Minimum, Math.Min(trackBar_0.Maximum, val));
			trackBar_0.Value = val;
		}
		for (int j = 0; j < num2; j++)
		{
			NumericUpDown numericUpDown3 = method_8(j);
			CheckBox checkBox2 = method_9(j);
			if (numericUpDown3 != null && checkBox2 != null && numericUpDown3 != numericUpDown && !checkBox2.Checked)
			{
				decimal num7 = ((!(num5 > 0m)) ? (1m / (decimal)num2) : (numericUpDown3.Value / num5));
				if (num4 <= 0m)
				{
					num7 = default(decimal);
				}
				decimal val2 = num4 * num7;
				val2 = Math.Max(0m, Math.Min(1m, val2));
				numericUpDown3.Value = val2;
			}
		}
		decimal num8 = default(decimal);
		for (int k = 0; k < num2; k++)
		{
			NumericUpDown numericUpDown4 = method_8(k);
			if (numericUpDown4 != null)
			{
				num8 += numericUpDown4.Value;
			}
		}
		if (num8 < 1m)
		{
			decimal num9 = 1m - num8;
			decimal value = Math.Max(0m, Math.Min(1m, numericUpDown.Value + num9));
			numericUpDown.Value = value;
		}
		GC.KeepAlive(this);
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		float[] array = null;
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			array = float_2;
			break;
		case 1:
			array = float_3;
			break;
		case 2:
			array = float_2;
			break;
		}
		if (array == null || array.Length == 0)
		{
			return;
		}
		bool_0 = true;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] > 1f)
			{
				array[i] = 1f;
			}
			NumericUpDown numericUpDown = method_8(i);
			TrackBar trackBar = method_10(i);
			if (numericUpDown != null && trackBar != null)
			{
				numericUpDown.Value = (decimal)array[i];
				int val = (int)((decimal)array[i] * 10000000m);
				val = Math.Max(trackBar.Minimum, Math.Min(trackBar.Maximum, val));
				trackBar.Value = val;
			}
		}
		bool_0 = false;
	}

	private void numericUpDown_10_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_37((Control)sender);
			decimal value = numericUpDown_10.Value;
			float_1 = (float)value;
			GC.KeepAlive(this);
		}
	}

	private void trackBar_11_Scroll(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_37((Control)sender);
			decimal num = 10000000m;
			decimal value = (decimal)trackBar_11.Value / num;
			numericUpDown_10.Value = value;
			GC.KeepAlive(this);
		}
	}

	private void numericUpDown_14_DoubleClick(object sender, EventArgs e)
	{
		commonStorage_0.ResetBuffer();
		AddonsWindow addonsWindow = new AddonsWindow(itempos_0.int_0, Class16.smethod_0(1648924112), Class16.smethod_0(1648919556), eListCollection_0, commonStorage_0);
		try
		{
			addonsWindow.ShowDialog(this);
		}
		finally
		{
			((IDisposable)addonsWindow).Dispose();
		}
		if (CommonStorage.sData != null)
		{
			numericUpDown_14.Text = CommonStorage.sData;
		}
		GC.KeepAlive(this);
	}

	private void numericUpDown_11_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			if (dataGridView_0.SelectedRows.Count < 1)
			{
				GC.KeepAlive(this);
				return;
			}
			method_37((Control)sender);
			decimal value = numericUpDown_11.Value;
			DataGridView dataGridView = dataGridView_0;
			dataGridView_0[0, dataGridView.SelectedRows[0].Index].Value = value.ToString();
			GC.KeepAlive(this);
		}
	}

	private void numericUpDown_11_DoubleClick(object sender, EventArgs e)
	{
		method_17();
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (!bool_0 && e.RowIndex >= 0)
		{
			method_37(dataGridView_0);
			bool_0 = true;
			int rowIndex = e.RowIndex;
			if (e.ColumnIndex == 0)
			{
				string text = null;
				if (dataGridView_0[0, rowIndex].Value != null)
				{
					text = dataGridView_0[0, rowIndex].Value.ToString();
				}
				if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
				{
					class49_0[rowIndex].int_0 = Convert.ToInt32(text);
					string addonNameByID = eListCollection_0.Addons.GetAddonNameByID(class49_0[rowIndex].int_0);
					if (addonNameByID != string.Empty)
					{
						dataGridView_0[1, rowIndex].Value = addonNameByID;
						int num = class49_0[rowIndex].int_0;
						if (eListCollection_0.Addons.IsAbility(num.ToString()))
						{
							dataGridView_0[1, rowIndex].Style.ForeColor = SpecialColors.AddonSkillColorPW;
						}
						else
						{
							dataGridView_0[1, rowIndex].Style.ForeColor = SpecialColors.AddonColor;
						}
						numericUpDown_11.Text = text;
					}
					else
					{
						string value = TextStorage.TEXTS.GetText(Class16.smethod_0(1648923167));
						dataGridView_0[1, rowIndex].Value = value;
						Color red = Color.Red;
						dataGridView_0[1, rowIndex].Style.ForeColor = red;
					}
				}
				else
				{
					int num2 = class49_0[rowIndex].int_0;
					dataGridView_0[0, rowIndex].Value = num2.ToString();
				}
			}
			else if (e.ColumnIndex == 2)
			{
				string text2 = null;
				if (dataGridView_0[2, e.RowIndex].Value != null)
				{
					text2 = dataGridView_0[2, e.RowIndex].Value.ToString();
					if (text2.Contains(Class16.smethod_0(1648923229)))
					{
						text2 = text2.Substring(0, text2.Length - 1);
					}
					else
					{
						DataGridViewCell dataGridViewCell = dataGridView_0[2, e.RowIndex];
						string text3 = Class16.smethod_0(1648923229);
						dataGridViewCell.Value = string.Concat(dataGridViewCell.Value, text3);
					}
				}
				if (ACE.RSGlobal.RSGlobal.IsNumber(text2))
				{
					if (Convert.ToDouble(text2) >= 100.0)
					{
						text2 = Class16.smethod_0(1648919573);
						string value2 = Class16.smethod_0(1648926675);
						dataGridView_0[2, e.RowIndex].Value = value2;
					}
					else if (Convert.ToDouble(text2) <= 0.0)
					{
						text2 = Class16.smethod_0(1648924112);
						string value3 = Class16.smethod_0(1648919583);
						dataGridView_0[2, e.RowIndex].Value = value3;
					}
					float num3 = Convert.ToSingle(text2) / 100f;
					class49_0[rowIndex].float_0 = num3;
					if (rowIndex == dataGridView_0.SelectedRows[0].Index)
					{
						decimal value4 = Convert.ToDecimal(text2);
						numericUpDown_13.Value = value4;
					}
				}
				else
				{
					float num4 = class49_0[rowIndex].float_0;
					int numAfterDecimal = 2;
					if ((double)num4 < 0.0001)
					{
						numAfterDecimal = 4;
					}
					string value5 = ACE.RSGlobal.RSGlobal.ToPercent(num4, numAfterDecimal);
					dataGridView_0[2, e.RowIndex].Value = value5;
				}
			}
			bool_0 = false;
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private void method_14()
	{
		float num = 0f;
		int num2 = 0;
		Class49[] array = class49_0;
		int num3 = array.Length;
		if (0 < num3)
		{
			do
			{
				num = (float)((double)array[num2].float_0 + (double)num);
				num2++;
			}
			while (num2 < num3);
		}
		double num4 = Math.Round((double)num * 100.0, 2);
		string text = Class16.smethod_0(1648923229);
		label_15.Text = num4 + text;
		if (Math.Round(num, 5) == 1.0)
		{
			Color green = Color.Green;
			label_15.ForeColor = green;
		}
		else
		{
			Color red = Color.Red;
			label_15.ForeColor = red;
		}
		GC.KeepAlive(this);
	}

	private void method_15()
	{
		dataGridView_0.Rows.Clear();
		int num = 0;
		Class49[] array = class49_0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				string addonNameByID = eListCollection_0.Addons.GetAddonNameByID(array[num].int_0);
				float num2 = class49_0[num].float_0;
				int numAfterDecimal = 2;
				if ((double)num2 < 0.0001)
				{
					numAfterDecimal = 4;
				}
				string text = ACE.RSGlobal.RSGlobal.ToPercent(num2, numAfterDecimal);
				object[] array2 = new object[5];
				int num3 = class49_0[num].int_0;
				array2[0] = num3.ToString();
				array2[1] = addonNameByID;
				array2[2] = text;
				array2[3] = null;
				array2[4] = false;
				dataGridView_0.Rows.Add(array2);
				if (addonNameByID != string.Empty)
				{
					int num4 = class49_0[num].int_0;
					if (eListCollection_0.Addons.IsAbility(num4.ToString()))
					{
						Color foreColor = Color.FromArgb(16736256);
						dataGridView_0[1, num].Style.ForeColor = foreColor;
					}
					else
					{
						Color foreColor2 = Color.FromArgb(114, 114, 240);
						dataGridView_0[1, num].Style.ForeColor = foreColor2;
					}
				}
				else
				{
					string value = TextStorage.TEXTS.GetText(Class16.smethod_0(1648923167));
					dataGridView_0[1, num].Value = value;
					Color red = Color.Red;
					dataGridView_0[1, num].Style.ForeColor = red;
				}
				num++;
				array = class49_0;
			}
			while (num < (nint)array.LongLength);
		}
		if (checkBox_0.Checked)
		{
			method_18();
		}
		method_14();
		method_20(bool_3: true);
	}

	private void numericUpDown_13_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			if (dataGridView_0.SelectedRows.Count < 1)
			{
				GC.KeepAlive(this);
				return;
			}
			method_37((Control)sender);
			decimal num = 10m;
			decimal num2 = numericUpDown_13.Value * num;
			trackBar_13.Value = (int)num2;
			method_16();
		}
	}

	private void trackBar_13_Scroll(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_37((Control)sender);
			decimal value = trackBar_13.Value / 10;
			numericUpDown_13.Value = value;
			GC.KeepAlive(this);
		}
	}

	private void method_16()
	{
		if (dataGridView_0.RowCount != 0 && dataGridView_0.SelectedRows.Count != 0)
		{
			decimal num = 100m;
			float num2 = (float)(numericUpDown_13.Value / num);
			if (num2 < 1E-06f)
			{
				num2 = 0f;
			}
			float num3 = (float)(1.0 - (double)num2);
			float num4 = 0f;
			int num5 = 0;
			int index = dataGridView_0.SelectedRows[0].Index;
			int num6 = 0;
			if (0 < (nint)class49_0.LongLength)
			{
				do
				{
					if (num6 != index)
					{
						if ((bool)dataGridView_0[4, num6].Value)
						{
							num3 = (float)((double)num3 - (double)class49_0[num6].float_0);
							num5++;
						}
						else
						{
							num4 = (float)((double)class49_0[num6].float_0 + (double)num4);
						}
					}
					num6++;
				}
				while (num6 < (nint)class49_0.LongLength);
			}
			bool_0 = true;
			if (!(num3 < 0f) && (num4 != 0f || num5 < (nint)class49_0.LongLength - 1))
			{
				class49_0[index].float_0 = num2;
				int numAfterDecimal = 2;
				if ((double)num2 < 0.0001)
				{
					numAfterDecimal = 4;
				}
				string value = ACE.RSGlobal.RSGlobal.ToPercent(num2, numAfterDecimal);
				dataGridView_0[2, index].Value = value;
				decimal value2 = (decimal)(num2 * 100f);
				numericUpDown_13.Value = value2;
			}
			else
			{
				decimal num7 = 10m;
				decimal num8 = numericUpDown_13.Value * num7;
				trackBar_13.Value = (int)num8;
			}
			int num9 = 0;
			if (0 < (nint)class49_0.LongLength)
			{
				do
				{
					if (!(bool)dataGridView_0[4, num9].Value && num9 != index)
					{
						Class49[] array;
						float num10;
						if (num4 > 0f)
						{
							array = class49_0;
							num10 = (float)((double)array[num9].float_0 / (double)num4);
						}
						else
						{
							array = class49_0;
							num10 = (float)(1.0 / (double)(float)(nint)array.LongLength);
						}
						if (num3 <= 0f)
						{
							num10 = 0f;
						}
						array[num9].float_0 = (float)((double)num10 * (double)num3);
						float num11 = class49_0[num9].float_0;
						int numAfterDecimal2 = 2;
						if ((double)num11 < 0.0001)
						{
							numAfterDecimal2 = 4;
						}
						string value3 = ACE.RSGlobal.RSGlobal.ToPercent(num11, numAfterDecimal2);
						dataGridView_0[2, num9].Value = value3;
					}
					num9++;
				}
				while (num9 < (nint)class49_0.LongLength);
			}
			float num12 = 0f;
			int num13 = 0;
			Class49[] array2 = class49_0;
			int num14 = array2.Length;
			if (0 < num14)
			{
				do
				{
					num12 = (float)((double)array2[num13].float_0 + (double)num12);
					num13++;
				}
				while (num13 < num14);
				if (num12 == 1f)
				{
					goto IL_0394;
				}
			}
			int num15 = method_19(array2);
			Class49 @class = class49_0[num15];
			Class49 class2 = @class;
			class2.float_0 = (float)((double)class2.float_0 + (1.0 - (double)num12));
			@class = class49_0[num15];
			if (@class.float_0 < 0f)
			{
				@class.float_0 = 0f;
			}
			float num16 = class49_0[num15].float_0;
			int numAfterDecimal3 = 2;
			if ((double)num16 < 0.0001)
			{
				numAfterDecimal3 = 4;
			}
			string value4 = ACE.RSGlobal.RSGlobal.ToPercent(num16, numAfterDecimal3);
			dataGridView_0[2, num15].Value = value4;
			goto IL_0394;
		}
		GC.KeepAlive(this);
		return;
		IL_0394:
		bool_0 = false;
		method_14();
		if (checkBox_0.Checked)
		{
			method_18();
		}
		method_20(bool_3: false);
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		int index;
		NumericUpDown numericUpDown;
		object obj;
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			index = dataGridView_0.SelectedRows[0].Index;
			numericUpDown = numericUpDown_11;
			object value = dataGridView_0[0, index].Value;
			if (value == null)
			{
				obj = null;
			}
			else
			{
				obj = value.ToString();
				if (obj != null)
				{
					goto IL_0071;
				}
			}
			obj = Class16.smethod_0(1648924112);
			goto IL_0071;
		}
		numericUpDown_11.Text = Class16.smethod_0(1648924112);
		numericUpDown_13.Text = Class16.smethod_0(1648924112);
		trackBar_13.Value = 0;
		goto IL_00ff;
		IL_00ff:
		bool_0 = false;
		return;
		IL_0071:
		numericUpDown.Text = (string)obj;
		decimal value2 = Convert.ToDecimal(class49_0[index].float_0 * 100f);
		numericUpDown_13.Value = value2;
		decimal num = 10m;
		decimal num2 = numericUpDown_13.Value * num;
		trackBar_13.Value = (int)num2;
		goto IL_00ff;
	}

	private void dataGridView_0_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 4 && e.RowIndex > -1)
		{
			method_34();
			int num = ((!(bool)dataGridView_0[4, e.RowIndex].Value) ? 1 : 0);
			dataGridView_0[4, e.RowIndex].Value = (byte)num != 0;
			dataGridView_0.RefreshEdit();
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 1 || e.ColumnIndex == 3)
		{
			method_17();
		}
	}

	private void method_17()
	{
		commonStorage_0.ResetBuffer();
		AddonsWindow addonsWindow = new AddonsWindow(itempos_0.int_0, Class16.smethod_0(1648924112), Class16.smethod_0(1648919556), eListCollection_0, commonStorage_0);
		try
		{
			addonsWindow.ShowDialog(this);
		}
		finally
		{
			((IDisposable)addonsWindow).Dispose();
		}
		if (CommonStorage.sData != null)
		{
			numericUpDown_11.Text = CommonStorage.sData;
		}
		GC.KeepAlive(this);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		int num = ((comboBox_1.SelectedIndex != 2) ? 32 : 16);
		if ((nint)class49_0.LongLength >= num)
		{
			object[] vars = new object[1] { num };
			TextStorage.TEXTS.ShowMessage(426, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
			GC.KeepAlive(this);
			return;
		}
		if (numericUpDown_14.Value == default(decimal))
		{
			commonStorage_0.ResetBuffer();
			AddonsWindow addonsWindow = new AddonsWindow(itempos_0.int_0, Class16.smethod_0(1648924112), Class16.smethod_0(1648919556), eListCollection_0, commonStorage_0);
			try
			{
				addonsWindow.ShowDialog(this);
			}
			finally
			{
				((IDisposable)addonsWindow).Dispose();
			}
			if (CommonStorage.sData == null)
			{
				GC.KeepAlive(this);
				return;
			}
			numericUpDown_14.Text = CommonStorage.sData;
		}
		int num2 = (int)numericUpDown_14.Value;
		int num3 = 0;
		method_34();
		if (comboBox_1.SelectedIndex == 0)
		{
			Array.Resize(ref class49_1, (int)((nint)class49_1.LongLength + 1));
			num3 = (int)((nint)class49_1.LongLength - 1);
			class49_1[num3] = new Class49(num2);
			class49_0 = class49_1;
		}
		else if (comboBox_1.SelectedIndex == 1)
		{
			Array.Resize(ref class49_2, (int)((nint)class49_2.LongLength + 1));
			num3 = (int)((nint)class49_2.LongLength - 1);
			class49_2[num3] = new Class49(num2);
			class49_0 = class49_2;
		}
		else if (comboBox_1.SelectedIndex == 2)
		{
			Array.Resize(ref class49_3, (int)((nint)class49_3.LongLength + 1));
			num3 = (int)((nint)class49_3.LongLength - 1);
			class49_3[num3] = new Class49(num2);
			class49_0 = class49_3;
		}
		Class49[] array = class49_0;
		if ((nint)array.LongLength == 1)
		{
			array[0].float_0 = 1f;
		}
		string addonNameByID = eListCollection_0.Addons.GetAddonNameByID(class49_0[num3].int_0);
		float num4 = class49_0[num3].float_0;
		int numAfterDecimal = 2;
		if ((double)num4 < 0.0001)
		{
			numAfterDecimal = 4;
		}
		string text = ACE.RSGlobal.RSGlobal.ToPercent(num4, numAfterDecimal);
		object[] array2 = new object[5];
		int num5 = class49_0[num3].int_0;
		array2[0] = num5.ToString();
		array2[1] = addonNameByID;
		array2[2] = text;
		array2[3] = null;
		array2[4] = false;
		dataGridView_0.Rows.Add(array2);
		if (addonNameByID != string.Empty)
		{
			int num6 = class49_0[num3].int_0;
			if (eListCollection_0.Addons.IsAbility(num6.ToString()))
			{
				Color foreColor = Color.FromArgb(16736256);
				dataGridView_0[1, num3].Style.ForeColor = foreColor;
			}
			else
			{
				Color foreColor2 = Color.FromArgb(114, 114, 240);
				dataGridView_0[1, num3].Style.ForeColor = foreColor2;
			}
		}
		else
		{
			string value = TextStorage.TEXTS.GetText(Class16.smethod_0(1648923167));
			dataGridView_0[1, num3].Value = value;
			Color red = Color.Red;
			dataGridView_0[1, num3].Style.ForeColor = red;
		}
		dataGridView_0[3, num3].Tag = 0f;
		int index = dataGridView_0.RowCount - 1;
		dataGridView_0.Rows[index].Selected = true;
		int rowIndex = dataGridView_0.RowCount - 1;
		dataGridView_0.CurrentCell = dataGridView_0[1, rowIndex];
		method_20(bool_3: true);
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		if (dataGridView_0.SelectedRows.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		method_34();
		if ((nint)class49_0.LongLength > 1)
		{
			bool flag = checkBox_0.Checked;
			checkBox_0.Checked = false;
			numericUpDown_13.Value = default(decimal);
			method_16();
			checkBox_0.Checked = flag;
		}
		int num = dataGridView_0.SelectedRows[0].Index;
		if (num < (nint)class49_0.LongLength - 1)
		{
			do
			{
				int num2 = num + 1;
				Class49 @class = class49_0[num2].method_0();
				class49_0[num] = @class;
				num = num2;
			}
			while (num < (nint)class49_0.LongLength - 1);
		}
		if (comboBox_1.SelectedIndex == 0)
		{
			Array.Resize(ref class49_1, (int)((nint)class49_1.LongLength - 1));
			class49_0 = class49_1;
		}
		else if (comboBox_1.SelectedIndex == 1)
		{
			Array.Resize(ref class49_2, (int)((nint)class49_2.LongLength - 1));
			class49_0 = class49_2;
		}
		else if (comboBox_1.SelectedIndex == 2)
		{
			Array.Resize(ref class49_3, (int)((nint)class49_3.LongLength - 1));
			class49_0 = class49_3;
		}
		DataGridView dataGridView = dataGridView_0;
		dataGridView_0.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
		method_14();
		method_20(bool_3: true);
	}

	private static float smethod_0(Class49 class49_4)
	{
		return class49_4.float_0;
	}

	private void method_18()
	{
		if (dataGridView_0.Rows.Count == 0)
		{
			GC.KeepAlive(this);
			return;
		}
		Func<Class49, float> keySelector = smethod_0;
		Class49[] array = new List<Class49>(class49_0).OrderByDescending(keySelector).ToArray();
		switch (comboBox_1.SelectedIndex)
		{
		case 0:
			class49_1 = array;
			break;
		case 1:
			class49_2 = array;
			break;
		case 2:
			class49_3 = array;
			break;
		}
		comboBox_1_SelectedIndexChanged(null, null);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		button_2.Enabled = false;
		method_34();
		method_18();
		button_2.Enabled = true;
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			TextStorage.TEXTS.ShowMessage(913, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
			GC.KeepAlive(this);
			return;
		}
		int[] selectedElItems = CommonStorage.SelectedElItems;
		int num = 0;
		if (0 < (nint)selectedElItems.LongLength)
		{
			do
			{
				itempos_0.int_1 = selectedElItems[num];
				eList eList2 = eListCollection_0.Lists[itempos_0.int_0];
				float num2 = float_0[0];
				ITEMPOS iTEMPOS = itempos_0;
				eListCollection_0.Lists[iTEMPOS.int_0].elementValues[iTEMPOS.int_1][eList2.get_fields(Class16.smethod_0(1648919584))] = num2;
				eList2 = eListCollection_0.Lists[itempos_0.int_0];
				float num3 = float_0[1];
				iTEMPOS = itempos_0;
				eListCollection_0.Lists[iTEMPOS.int_0].elementValues[iTEMPOS.int_1][eList2.get_fields(Class16.smethod_0(1648919621))] = num3;
				eList2 = eListCollection_0.Lists[itempos_0.int_0];
				float num4 = float_0[2];
				iTEMPOS = itempos_0;
				eListCollection_0.Lists[iTEMPOS.int_0].elementValues[iTEMPOS.int_1][eList2.get_fields(Class16.smethod_0(1648919642))] = num4;
				eList2 = eListCollection_0.Lists[itempos_0.int_0];
				float num5 = float_0[3];
				iTEMPOS = itempos_0;
				eListCollection_0.Lists[iTEMPOS.int_0].elementValues[iTEMPOS.int_1][eList2.get_fields(Class16.smethod_0(1648919679))] = num5;
				if (int_0 > 0)
				{
					eList2 = eListCollection_0.Lists[itempos_0.int_0];
					float num6 = float_0[4];
					iTEMPOS = itempos_0;
					eListCollection_0.Lists[iTEMPOS.int_0].elementValues[iTEMPOS.int_1][eList2.get_fields(Class16.smethod_0(1648922985))] = num6;
				}
				if (int_1 > 0)
				{
					eList2 = eListCollection_0.Lists[itempos_0.int_0];
					float num7 = float_0[5];
					ITEMPOS iTEMPOS2 = itempos_0;
					eListCollection_0.Lists[iTEMPOS2.int_0].elementValues[iTEMPOS2.int_1][eList2.get_fields(Class16.smethod_0(1648923022))] = num7;
				}
				int num8 = 0;
				float[] array = float_3;
				if (0 < (nint)array.LongLength)
				{
					do
					{
						int num9 = num8;
						eList eList3 = eListCollection_0.Lists[itempos_0.int_0];
						float num10 = array[num8];
						ITEMPOS iTEMPOS3 = itempos_0;
						eListCollection_0.Lists[iTEMPOS3.int_0].elementValues[iTEMPOS3.int_1][eList3.get_fields(Class16.smethod_0(1648923120) + num9)] = num10;
						int num11 = num8;
						eList eList4 = eListCollection_0.Lists[itempos_0.int_0];
						float num12 = float_2[num8];
						ITEMPOS iTEMPOS4 = itempos_0;
						eListCollection_0.Lists[iTEMPOS4.int_0].elementValues[iTEMPOS4.int_1][eList4.get_fields(Class16.smethod_0(1648926230) + num11)] = num12;
						num8++;
						array = float_3;
					}
					while (num8 < (nint)array.LongLength);
				}
				int num13 = itempos_0.int_0;
				eList eList5 = eListCollection_0.Lists[num13];
				string uListName = eList5.uListName;
				int num14 = eList5.get_fields(Class16.smethod_0(1648923486));
				int num15 = eListCollection_0.Lists[num13].get_fields(Class16.smethod_0(1648922763));
				int num16 = 0;
				int num17 = num14;
				eList5 = eListCollection_0.Lists[num13];
				if (num14 <= eList5.get_fields(Class16.smethod_0(1648926289)))
				{
					eList eList6;
					do
					{
						int num18 = 0;
						float num19 = 0f;
						Class49[] array2 = class49_1;
						if (num16 < (nint)array2.LongLength)
						{
							Class49 @class = array2[num16];
							num18 = @class.int_0;
							num19 = @class.float_0;
						}
						ITEMPOS iTEMPOS5 = itempos_0;
						eListCollection_0.Lists[iTEMPOS5.int_0].elementValues[iTEMPOS5.int_1][num17] = num18;
						iTEMPOS5 = itempos_0;
						eListCollection_0.Lists[iTEMPOS5.int_0].elementValues[iTEMPOS5.int_1][num17 + 1] = num19;
						num16++;
						num17 += 2;
						eList6 = eListCollection_0.Lists[num13];
					}
					while (num17 <= eList6.get_fields(Class16.smethod_0(1648926289)));
				}
				if (class49_1.Length == 0)
				{
					ITEMPOS iTEMPOS6 = itempos_0;
					eListCollection_0.Lists[iTEMPOS6.int_0].elementValues[iTEMPOS6.int_1][num14 + 1] = 1f;
				}
				int num20 = 0;
				int num21 = num15;
				eList eList7 = eListCollection_0.Lists[num13];
				if (num15 <= eList7.get_fields(Class16.smethod_0(1648923552)))
				{
					eList eList8;
					do
					{
						int num22 = 0;
						float num23 = 0f;
						Class49[] array3 = class49_2;
						if (num20 < (nint)array3.LongLength)
						{
							Class49 class2 = array3[num20];
							num22 = class2.int_0;
							num23 = class2.float_0;
						}
						ITEMPOS iTEMPOS7 = itempos_0;
						eListCollection_0.Lists[iTEMPOS7.int_0].elementValues[iTEMPOS7.int_1][num21] = num22;
						iTEMPOS7 = itempos_0;
						eListCollection_0.Lists[iTEMPOS7.int_0].elementValues[iTEMPOS7.int_1][num21 + 1] = num23;
						num20++;
						num21 += 2;
						eList8 = eListCollection_0.Lists[num13];
					}
					while (num21 <= eList8.get_fields(Class16.smethod_0(1648923552)));
				}
				if (class49_2.Length == 0)
				{
					ITEMPOS iTEMPOS8 = itempos_0;
					eListCollection_0.Lists[iTEMPOS8.int_0].elementValues[iTEMPOS8.int_1][num15 + 1] = 1f;
				}
				ITEMPOS iTEMPOS9;
				if (uListName == Class16.smethod_0(1648923245))
				{
					int num24 = 0;
					int num25 = eListCollection_0.Lists[num13].get_fields(Class16.smethod_0(1648926314));
					int num26 = eListCollection_0.Lists[num13].get_fields(Class16.smethod_0(1648923510));
					if (num26 < 0)
					{
						num26 = eListCollection_0.Lists[num13].get_fields(Class16.smethod_0(1648923533));
					}
					int num27 = num25;
					if (num25 <= num26)
					{
						do
						{
							int num28 = 0;
							float num29 = 0f;
							Class49[] array4 = class49_3;
							if (num24 < (nint)array4.LongLength)
							{
								Class49 class3 = array4[num24];
								num28 = class3.int_0;
								num29 = class3.float_0;
							}
							iTEMPOS9 = itempos_0;
							eListCollection_0.Lists[iTEMPOS9.int_0].elementValues[iTEMPOS9.int_1][num27] = num28;
							iTEMPOS9 = itempos_0;
							eListCollection_0.Lists[iTEMPOS9.int_0].elementValues[iTEMPOS9.int_1][num27 + 1] = num29;
							num24++;
							num27 += 2;
						}
						while (num27 <= num26);
					}
					if (class49_3.Length == 0)
					{
						iTEMPOS9 = itempos_0;
						eListCollection_0.Lists[iTEMPOS9.int_0].elementValues[iTEMPOS9.int_1][num25 + 1] = 1f;
					}
					eList eList9 = eListCollection_0.Lists[itempos_0.int_0];
					float num30 = float_1;
					iTEMPOS9 = itempos_0;
					eListCollection_0.Lists[iTEMPOS9.int_0].elementValues[iTEMPOS9.int_1][eList9.get_fields(Class16.smethod_0(1648923079))] = num30;
				}
				iTEMPOS9 = itempos_0;
				eListCollection_0.ItemChanged(iTEMPOS9.int_0, iTEMPOS9.int_1);
				num++;
			}
			while (num < (nint)selectedElItems.LongLength);
		}
		int selectedIndex = comboBox_0.SelectedIndex;
		string settingName = Class16.smethod_0(1648926348);
		string section = Class16.smethod_0(1648926373);
		settingsClass_0.SaveSetting(section, settingName, selectedIndex.ToString());
		int selectedIndex2 = comboBox_1.SelectedIndex;
		section = Class16.smethod_0(1648926384);
		settingName = Class16.smethod_0(1648926373);
		settingsClass_0.SaveSetting(settingName, section, selectedIndex2.ToString());
		bool flag = checkBox_0.Checked;
		section = Class16.smethod_0(1648926403);
		settingName = Class16.smethod_0(1648926373);
		settingsClass_0.SaveSetting(settingName, section, flag.ToString());
		Close();
	}

	private void numericUpDown_14_ValueChanged(object sender, EventArgs e)
	{
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_34();
		Class49[] array = class49_1;
		class49_2 = new Class49[(nint)array.LongLength];
		int num = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				class49_2[num] = class49_1[num].method_0();
				num++;
			}
			while (num < (nint)class49_1.LongLength);
		}
		if (comboBox_1.SelectedIndex == 1)
		{
			class49_0 = class49_2;
			method_15();
			if (checkBox_0.Checked)
			{
				method_18();
			}
		}
	}

	private void dataGridView_0_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
		{
			method_34();
			method_18();
		}
	}

	private int method_19(Class49[] class49_4)
	{
		float num = 0f;
		int result = 0;
		int num2 = class49_4.Length;
		int num3 = 0;
		if (0 < num2)
		{
			do
			{
				float num4 = class49_4[num3].float_0;
				if ((double)num4 > (double)num)
				{
					num = num4;
					result = num3;
				}
				num3++;
			}
			while (num3 < num2);
		}
		return result;
	}

	private void method_20([MarshalAs(UnmanagedType.U1)] bool bool_3)
	{
		ACE.RSGlobal.RSGlobal.recurse_level_UpdateGraphicalProbs_AddonsEditor++;
		// TODO(recovered): restore the re-entrancy latch the licensed UpdateGraphicalProbs uses.
		// Writing the progress-bar image into column 3 can resize the Fill column -> fire
		// ColumnWidthChanged -> re-enter method_20. The latch must be set ONLY on the outermost
		// call (level 1); re-pointing it every call (and the unguarded draw loop below) let
		// re-entrant calls recurse and re-run the draw -> data-dependent FREEZE on entering the
		// Equipment Addons section, leaving names/refs unpainted.
		if (ACE.RSGlobal.RSGlobal.recurse_level_UpdateGraphicalProbs_AddonsEditor == 1)
		{
			ACE.RSGlobal.RSGlobal.valid_recurse_level_UpdateGraphicalProbs_AddonsEditor = ACE.RSGlobal.RSGlobal.recurse_level_UpdateGraphicalProbs_AddonsEditor;
		}
		if (class49_0 != null && dataGridView_0 != null)
		{
			if (dataGridView_0.Columns != null && dataGridView_0.Columns.Count > 3)
			{
				int num = Math.Max(1, dataGridView_0.Columns[3].Width);
				int num2 = 0;
				if (0 < (nint)class49_0.LongLength)
				{
					while (ACE.RSGlobal.RSGlobal.recurse_level_UpdateGraphicalProbs_AddonsEditor == ACE.RSGlobal.RSGlobal.valid_recurse_level_UpdateGraphicalProbs_AddonsEditor && num2 < dataGridView_0.RowCount)
					{
						int num3 = Math.Max(1, dataGridView_0.Rows[num2].Height);
						if (!bool_3)
						{
							float num4 = class49_0[num2].float_0;
							int num5 = 0;
							if (num4 > 1E-06f)
							{
								num5 = (int)((double)(float)num * (double)num4 - 2.0);
								num5 = ((num5 < 1) ? 1 : num5);
							}
							if ((int)dataGridView_0[3, num2].Tag == num5)
							{
								goto IL_0170;
							}
						}
						float value = class49_0[num2].float_0;
						dataGridView_0[3, num2].Value = ACE.RSGlobal.RSGlobal.DrawProgress(value, num, num3);
						float num6 = class49_0[num2].float_0;
						int num7 = 0;
						if (num6 > 1E-06f)
						{
							num7 = (int)((double)(float)num * (double)num6 - 2.0);
							num7 = ((num7 < 1) ? 1 : num7);
						}
						dataGridView_0[3, num2].Tag = num7;
						goto IL_0170;
						IL_0170:
						num2++;
						if (num2 >= (nint)class49_0.LongLength)
						{
							break;
						}
					}
				}
				ACE.RSGlobal.RSGlobal.recurse_level_UpdateGraphicalProbs_AddonsEditor--;
				GC.KeepAlive(this);
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

	private void AddonsEditor_Shown(object sender, EventArgs e)
	{
		method_20(bool_3: true);
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			TextStorage.TEXTS.ShowMessage(913, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
			GC.KeepAlive(this);
		}
	}

	private void AddonsEditor_Resize(object sender, EventArgs e)
	{
	}

	private void dataGridView_0_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
	{
		if (e.Column.Index == 2 || e.Column.Index == 3)
		{
			float num = (float)dataGridView_0[2, e.RowIndex1].Tag;
			float num2 = (float)dataGridView_0[2, e.RowIndex2].Tag;
			if ((double)num > (double)num2)
			{
				e.SortResult = 1;
				e.Handled = true;
			}
			else if ((double)num < (double)num2)
			{
				e.SortResult = -1;
				e.Handled = true;
			}
			else
			{
				e.SortResult = 0;
			}
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_0_Sorted(object sender, EventArgs e)
	{
		if (dataGridView_0.SelectedRows.Count > 0)
		{
			DataGridView dataGridView = dataGridView_0;
			dataGridView_0.CurrentCell = dataGridView[1, dataGridView_0.SelectedRows[0].Index];
			if (!dataGridView_0.CurrentCell.Displayed)
			{
				dataGridView_0.FirstDisplayedCell = dataGridView_0.CurrentCell;
			}
		}
		int num = 0;
		if (0 < (nint)class49_0.LongLength)
		{
			Class49[] array;
			do
			{
				class49_0[num].int_0 = ACE.RSGlobal.RSGlobal.UIntParseFast((string)dataGridView_0[0, num].Value);
				float num2 = (float)dataGridView_0[2, num].Tag;
				array = class49_0;
				array[num].float_0 = num2;
				num++;
			}
			while (num < (nint)array.LongLength);
		}
		GC.KeepAlive(this);
	}

	private void dataGridView_0_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
	{
		if (e.Column.Index == 3)
		{
			method_20(bool_3: true);
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		if (dataGridView_0.RowCount < 1)
		{
			GC.KeepAlive(this);
			return;
		}
		method_34();
		decimal num = class49_0.Length;
		float num2 = (float)(1m / num);
		float num3 = 0f;
		bool_0 = true;
		int num4 = (int)((nint)class49_0.LongLength - 1);
		if (num4 >= 0)
		{
			do
			{
				num3 = (float)((double)num3 + (double)num2);
				if (num4 == 0 && num3 != 1f)
				{
					num2 = (float)(1.0 - (double)num3 + (double)num2);
				}
				class49_0[num4].float_0 = num2;
				float num5 = class49_0[num4].float_0;
				int numAfterDecimal = 2;
				if ((double)num5 < 0.0001)
				{
					numAfterDecimal = 4;
				}
				string value = ACE.RSGlobal.RSGlobal.ToPercent(num5, numAfterDecimal);
				dataGridView_0[2, num4].Value = value;
				num4--;
			}
			while (num4 >= 0);
		}
		bool_0 = false;
		method_14();
		method_20(bool_3: false);
	}

	private void dataGridView_0_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
	{
	}

	private void method_21()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1648919708), 100);
		fileBasedUndoManager_0.SetStateChangedCallback(method_39);
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_27, method_28);
		method_22();
		method_24();
	}

	private void method_22()
	{
		button_7 = new Button
		{
			Name = Class16.smethod_0(1648919713),
			Text = string.Empty,
			Enabled = false,
			Image = Resources.GShopEditor_PW_mbUndo,
			ImageAlign = ContentAlignment.MiddleCenter,
			FlatStyle = FlatStyle.Standard,
			UseVisualStyleBackColor = true,
			Anchor = (AnchorStyles.Top | AnchorStyles.Right),
			Parent = this
		};
		button_8 = new Button
		{
			Name = Class16.smethod_0(1648919742),
			Text = string.Empty,
			Enabled = false,
			Image = Resources.GShopEditor_PW_mbRedo,
			ImageAlign = ContentAlignment.MiddleCenter,
			FlatStyle = FlatStyle.Standard,
			UseVisualStyleBackColor = true,
			Anchor = (AnchorStyles.Top | AnchorStyles.Right),
			Parent = this
		};
		button_7.Click += button_7_Click;
		button_8.Click += button_8_Click;
		toolTip_0?.SetToolTip(button_7, Class16.smethod_0(1648933841));
		toolTip_0?.SetToolTip(button_8, Class16.smethod_0(1648933869));
		base.Resize += AddonsEditor_Resize_1;
		method_23();
	}

	private void method_23()
	{
		if (button_7 != null && button_8 != null)
		{
			int num = Math.Max(23, button_3.Height);
			int num2 = button_5.Top + Math.Max(0, (button_5.Height - num) / 2);
			int num3 = base.ClientSize.Width - 6;
			button_8.SetBounds(num3 - num, num2, num, num);
			button_7.SetBounds(button_8.Left - 4 - num, num2, num, num);
		}
	}

	private void method_24()
	{
		method_26(numericUpDown_11);
		method_26(numericUpDown_13);
		method_26(trackBar_13);
		method_26(numericUpDown_10);
		method_26(trackBar_11);
		for (int i = 0; i <= 5; i++)
		{
			method_25(string.Format(Class16.smethod_0(1648919755), i));
			method_25(string.Format(Class16.smethod_0(1648919790), i));
		}
		for (int j = 0; j <= 4; j++)
		{
			method_25(string.Format(Class16.smethod_0(1648919823), j));
			method_25(string.Format(Class16.smethod_0(1648919843), j));
		}
		dataGridView_0.CellBeginEdit += dataGridView_0_CellBeginEdit;
		dataGridView_0.Leave += dataGridView_0_Leave;
	}

	private void method_25(string string_0)
	{
		Control control = base.Controls[string_0];
		if (control != null)
		{
			method_26(control);
		}
	}

	private void method_26(Control control_1)
	{
		Class48 @class = new Class48();
		@class.addonsEditor_0 = this;
		@class.control_0 = control_1;
		@class.control_0.Enter += @class.method_0;
		@class.control_0.MouseDown += @class.method_1;
		@class.control_0.Leave += @class.method_2;
	}

	private byte[] method_27()
	{
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					smethod_1(binaryWriter, class49_1);
					smethod_1(binaryWriter, class49_2);
					smethod_1(binaryWriter, class49_3);
					smethod_3(binaryWriter, float_0);
					binaryWriter.Write(float_1);
					smethod_3(binaryWriter, float_2);
					smethod_3(binaryWriter, float_3);
					binaryWriter.Write(comboBox_1.SelectedIndex);
					binaryWriter.Write(comboBox_0.SelectedIndex);
					binaryWriter.Write(checkBox_0.Checked);
					binaryWriter.Write(dataGridView_0.CurrentRow?.Index ?? ((dataGridView_0.SelectedRows.Count > 0) ? dataGridView_0.SelectedRows[0].Index : (-1)));
					bool[] array = method_31();
					binaryWriter.Write(array.Length);
					bool[] array2 = array;
					foreach (bool value in array2)
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

	private void method_28(byte[] byte_1)
	{
		if (byte_1 == null || byte_1.Length == 0)
		{
			return;
		}
		bool_2 = true;
		bool_0 = true;
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_1);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					class49_1 = smethod_2(binaryReader);
					class49_2 = smethod_2(binaryReader);
					class49_3 = smethod_2(binaryReader);
					float_0 = smethod_4(binaryReader);
					float_1 = binaryReader.ReadSingle();
					float_2 = smethod_4(binaryReader);
					float_3 = smethod_4(binaryReader);
					int int_ = binaryReader.ReadInt32();
					int int_2 = binaryReader.ReadInt32();
					bool flag = binaryReader.ReadBoolean();
					int int_3 = binaryReader.ReadInt32();
					int num = binaryReader.ReadInt32();
					bool[] array = new bool[num];
					for (int i = 0; i < num; i++)
					{
						array[i] = binaryReader.ReadBoolean();
					}
					checkBox_0.Checked = flag;
					method_29();
					method_30();
					if (comboBox_0.Items.Count > 0)
					{
						comboBox_0.SelectedIndex = smethod_5(int_2, comboBox_0.Items.Count);
					}
					if (comboBox_1.Items.Count > 0)
					{
						comboBox_1.SelectedIndex = smethod_5(int_, comboBox_1.Items.Count);
					}
					method_32(array);
					method_33(int_3);
					method_14();
					method_20(bool_3: true);
					dataGridView_0_SelectionChanged(null, EventArgs.Empty);
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
			bool_2 = false;
			method_38(null);
		}
	}

	private static void smethod_1(BinaryWriter binaryWriter_0, Class49[] class49_4)
	{
		if (class49_4 == null)
		{
			binaryWriter_0.Write(0);
			return;
		}
		binaryWriter_0.Write(class49_4.Length);
		foreach (Class49 @class in class49_4)
		{
			binaryWriter_0.Write(@class?.int_0 ?? 0);
			binaryWriter_0.Write(@class?.float_0 ?? 0f);
		}
	}

	private static Class49[] smethod_2(BinaryReader binaryReader_0)
	{
		int num = binaryReader_0.ReadInt32();
		Class49[] array = new Class49[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new Class49
			{
				int_0 = binaryReader_0.ReadInt32(),
				float_0 = binaryReader_0.ReadSingle()
			};
		}
		return array;
	}

	private static void smethod_3(BinaryWriter binaryWriter_0, float[] float_4)
	{
		if (float_4 == null)
		{
			binaryWriter_0.Write(0);
			return;
		}
		binaryWriter_0.Write(float_4.Length);
		foreach (float value in float_4)
		{
			binaryWriter_0.Write(value);
		}
	}

	private static float[] smethod_4(BinaryReader binaryReader_0)
	{
		int num = binaryReader_0.ReadInt32();
		float[] array = new float[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = binaryReader_0.ReadSingle();
		}
		return array;
	}

	private void method_29()
	{
		for (int i = 0; i < float_0.Length; i++)
		{
			float num = Math.Max(0f, Math.Min(1f, float_0[i]));
			float_0[i] = num;
			if (base.Controls[string.Format(Class16.smethod_0(1648919755), i)] is NumericUpDown numericUpDown)
			{
				numericUpDown.Value = (decimal)num;
			}
			if (base.Controls[string.Format(Class16.smethod_0(1648919790), i)] is TrackBar trackBar)
			{
				int val = (int)((decimal)num * 10000000m);
				trackBar.Value = Math.Max(trackBar.Minimum, Math.Min(trackBar.Maximum, val));
			}
		}
	}

	private void method_30()
	{
		float num = (float_1 = Math.Max(0f, Math.Min(1f, float_1)));
		numericUpDown_10.Value = (decimal)num;
		int val = (int)((decimal)num * 10000000m);
		trackBar_11.Value = Math.Max(trackBar_11.Minimum, Math.Min(trackBar_11.Maximum, val));
	}

	private bool[] method_31()
	{
		bool[] array = new bool[dataGridView_0.RowCount];
		bool flag = default(bool);
		for (int i = 0; i < dataGridView_0.RowCount; i++)
		{
			int num = i;
			object value = dataGridView_0[4, i].Value;
			int num2;
			if (value is bool)
			{
				flag = (bool)value;
				num2 = 1;
			}
			else
			{
				num2 = 0;
			}
			array[num] = (byte)((uint)num2 & (flag ? 1u : 0u)) != 0;
		}
		return array;
	}

	private void method_32(bool[] bool_3)
	{
		if (bool_3 != null)
		{
			for (int i = 0; i < dataGridView_0.RowCount && i < bool_3.Length; i++)
			{
				dataGridView_0[4, i].Value = bool_3[i];
			}
		}
	}

	private void method_33(int int_2)
	{
		if (dataGridView_0.RowCount != 0)
		{
			int num = smethod_5(int_2, dataGridView_0.RowCount);
			dataGridView_0.ClearSelection();
			dataGridView_0.Rows[num].Selected = true;
			dataGridView_0.CurrentCell = dataGridView_0[1, num];
		}
	}

	private static int smethod_5(int int_2, int int_3)
	{
		if (int_3 <= 0)
		{
			return -1;
		}
		if (int_2 < 0)
		{
			return 0;
		}
		return Math.Min(int_2, int_3 - 1);
	}

	private void method_34()
	{
		if (!bool_2)
		{
			byte[] array = method_27();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
			method_38(null);
		}
	}

	private void method_35()
	{
		method_38(null);
		fileBasedUndoManager_0?.Clear();
	}

	private void method_36(Control control_1)
	{
		if (!bool_2 && control_1 != null && control_0 != control_1)
		{
			control_0 = control_1;
			byte_0 = method_27();
		}
	}

	private void method_37(Control control_1)
	{
		if (!bool_2 && control_1 != null && control_0 == control_1 && byte_0 != null)
		{
			fileBasedUndoManager_0?.PushUndo(byte_0);
			byte_0 = null;
		}
	}

	private void method_38(Control control_1)
	{
		if (control_1 == null || control_0 == control_1)
		{
			control_0 = null;
			byte_0 = null;
		}
	}

	private void method_39()
	{
		if (button_7 != null)
		{
			button_7.Enabled = fileBasedUndoManager_0?.CanUndo ?? false;
		}
		if (button_8 != null)
		{
			button_8.Enabled = fileBasedUndoManager_0?.CanRedo ?? false;
		}
	}

	private void AddonsEditor_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_AddonsEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_AddonsEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_27();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_28(array);
		}
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		byte[] currentState = method_27();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_28(array);
		}
	}

	private void AddonsEditor_Resize_1(object sender, EventArgs e)
	{
		method_23();
	}

	private void dataGridView_0_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
		method_36(dataGridView_0);
	}

	private void dataGridView_0_Leave(object sender, EventArgs e)
	{
		method_38(dataGridView_0);
	}
}
