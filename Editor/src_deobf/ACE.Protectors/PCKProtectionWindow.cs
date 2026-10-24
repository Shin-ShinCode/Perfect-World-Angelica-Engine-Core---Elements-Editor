using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Cpk;
using ACE.License;
using ACE.Pck;
using ACE.Properties;
using ACE.RSGlobal;
using Newtonsoft.Json;

namespace ACE.Protectors;

public class PCKProtectionWindow : Form
{
	private sealed class Class354
	{
		public string string_0;

		internal bool method_0(Class356 class356_0)
		{
			return class356_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class355
	{
		public string string_0;

		internal bool method_0(Class356 class356_0)
		{
			return class356_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class356
	{
		private string string_0;

		private int int_0 = 6;

		private string string_1;

		private string string_2;

		private int int_1 = 1;

		private int int_2;

		private int int_3;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public int MaxLevel
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public string EncryptedKey
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public string CleanKey
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public int ProtectionLevel
		{
			[CompilerGenerated]
			get
			{
				return int_1;
			}
			[CompilerGenerated]
			set
			{
				int_1 = value;
			}
		}

		public int ExtraFilesMask
		{
			[CompilerGenerated]
			get
			{
				return int_2;
			}
			[CompilerGenerated]
			set
			{
				int_2 = value;
			}
		}

		public int Game
		{
			[CompilerGenerated]
			get
			{
				return int_3;
			}
			[CompilerGenerated]
			set
			{
				int_3 = value;
			}
		}
	}

	private sealed class Class357
	{
		public Class356 class356_0;

		internal bool method_0(Class356 class356_1)
		{
			return class356_1.Name.Equals(class356_0.Name, StringComparison.OrdinalIgnoreCase);
		}
	}

	public static PCK_LIST PCKs;

	public CommonStorage CStorage;

	public LICENSE_INFO License;

	public PCK_PROTECTION_SETTINGS PCKSettings;

	public PCK_PROTECTION_OPTIONS PCKOptions;

	public Hashtable ExtraFiles;

	public string EncryptedKey;

	public string CleanKey;

	private string[] string_0;

	private readonly string string_1 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Class16.smethod_0(1648898132), Class16.smethod_0(1649174531));

	private List<Class356> list_0;

	private ToolTip toolTip_0;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private GroupBox groupBox_0;

	private Button button_0;

	private Label label_0;

	private TextBox textBox_0;

	private Button button_1;

	private Button button_2;

	private ComboBox comboBox_0;

	private Label label_1;

	private Button button_3;

	private Button button_4;

	private GroupBox groupBox_1;

	private ComboBox comboBox_1;

	private ComboBox comboBox_2;

	private CheckBox checkBox_3;

	private ComboBox comboBox_3;

	private TextBox textBox_1;

	private ComboBox comboBox_4;

	private CheckBox checkBox_4;

	private ComboBox comboBox_5;

	private CheckBox checkBox_5;

	private ComboBox comboBox_6;

	private Label label_2;

	private TextBox textBox_2;

	private Label label_3;

	private Label label_4;

	private NumericUpDown numericUpDown_0;

	private Button button_5;

	private Button button_6;

	private Button button_7;

	private GroupBox groupBox_2;

	private ComboBox comboBox_7;

	private Label label_5;

	private ComboBox comboBox_8;

	private GroupBox groupBox_3;

	private CheckBox checkBox_6;

	private GroupBox groupBox_4;

	private GroupBox groupBox_5;

	private Button button_8;

	private ProgressBar progressBar_0;

	private ProgressBar progressBar_1;

	private Button button_9;

	private Button button_10;

	private ComboBox comboBox_9;

	private CheckBox checkBox_7;

	private TextBox textBox_3;

	private ComboBox comboBox_10;

	private CheckBox checkBox_8;

	private Button button_11;

	private CheckBox checkBox_9;

	private Panel panel_0;

	private NumericUpDown numericUpDown_1;

	private CheckBox checkBox_10;

	private TextBox textBox_4;

	private NumericUpDown numericUpDown_2;

	public Form ElementsWindow;

	private TextBox textBox_5;

	private Button button_12;

	private Label label_6;

	private TextBox textBox_6;

	private GroupBox groupBox_6;

	private Button button_13;

	private Button button_14;

	private IContainer icontainer_0;

	public PCKProtectionWindow(CommonStorage CStorage, Form ElementsWindow)
	{
		try
		{
			method_7();
			this.CStorage = CStorage;
			License = CommonStorage.License;
			this.ElementsWindow = ElementsWindow;
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			if (base.IsHandleCreated)
			{
				TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
			}
			TDark.ApplyNativeDarkThemeRecursive(this);
			if (CommonStorage.License.Licenses.PCKProtection)
			{
				groupBox_6.Enabled = true;
				groupBox_5.Enabled = true;
			}
			textBox_6.Text = CommonStorage.Profile.GetSetting(Class16.smethod_0(1649144053));
			if (License.GetFeatureEntitlementsByName(Class16.smethod_0(1648893727)) || LICENSE_INFO.Info.LicenseType == LICENSE_TYPE.DEV)
			{
				panel_0.Visible = true;
				button_10.Enabled = true;
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
		try
		{
			string directoryName = System.IO.Path.GetDirectoryName(string_1);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649174555));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649174603), Class16.smethod_0(1649174661)) + ex.Message, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private List<Class356> method_1()
	{
		method_0();
		if (!File.Exists(string_1))
		{
			return new List<Class356>();
		}
		try
		{
			string text = File.ReadAllText(string_1, Encoding.UTF8);
			List<Class356> list = JsonConvert.DeserializeObject<List<Class356>>(text);
			if (list == null)
			{
				list = new List<Class356>();
			}
			return list;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649174704));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649174756), Class16.smethod_0(1649174795)) + ex.Message, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return new List<Class356>();
		}
	}

	private void method_2()
	{
		if (list_0 == null)
		{
			return;
		}
		try
		{
			method_0();
			string contents = JsonConvert.SerializeObject((object)list_0, (Formatting)1);
			File.WriteAllText(string_1, contents, Encoding.UTF8);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649174833));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649174885), Class16.smethod_0(1649174932)) + ex.Message, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_3(string string_2)
	{
		Class354 @class = new Class354();
		@class.string_0 = string_2;
		comboBox_6.Items.Clear();
		if (list_0 != null && list_0.Count != 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				comboBox_6.Items.Add(list_0[i].Name);
			}
			if (!string.IsNullOrWhiteSpace(@class.string_0))
			{
				int num = list_0.FindIndex(@class.method_0);
				comboBox_6.SelectedIndex = ((num >= 0) ? num : 0);
			}
			else
			{
				comboBox_6.SelectedIndex = 0;
			}
		}
		else
		{
			comboBox_6.SelectedIndex = -1;
		}
	}

	private byte[] method_4(byte[] byte_0, string string_2)
	{
		if (string.IsNullOrWhiteSpace(string_2))
		{
			throw new ArgumentException(Class16.smethod_0(1649174962));
		}
		byte[] bytes = Encoding.GetEncoding(1251).GetBytes(string_2);
		byte[] array = new byte[byte_0.Length];
		for (int i = 0; i < byte_0.Length; i++)
		{
			array[i] = (byte)(bytes[i % bytes.Length] ^ byte_0[i]);
		}
		return array;
	}

	private int method_5()
	{
		return BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);
	}

	private void method_6()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_7()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(PCKProtectionWindow));
		button_13 = new Button();
		button_14 = new Button();
		groupBox_6 = new GroupBox();
		groupBox_4 = new GroupBox();
		checkBox_6 = new CheckBox();
		checkBox_0 = new CheckBox();
		groupBox_1 = new GroupBox();
		textBox_3 = new TextBox();
		comboBox_10 = new ComboBox();
		checkBox_8 = new CheckBox();
		comboBox_9 = new ComboBox();
		checkBox_7 = new CheckBox();
		textBox_1 = new TextBox();
		comboBox_4 = new ComboBox();
		checkBox_4 = new CheckBox();
		comboBox_2 = new ComboBox();
		checkBox_3 = new CheckBox();
		button_3 = new Button();
		comboBox_5 = new ComboBox();
		button_12 = new Button();
		checkBox_5 = new CheckBox();
		label_6 = new Label();
		textBox_6 = new TextBox();
		comboBox_3 = new ComboBox();
		checkBox_2 = new CheckBox();
		comboBox_1 = new ComboBox();
		checkBox_1 = new CheckBox();
		comboBox_0 = new ComboBox();
		label_1 = new Label();
		button_4 = new Button();
		textBox_5 = new TextBox();
		toolTip_0 = new ToolTip(icontainer_0);
		textBox_4 = new TextBox();
		numericUpDown_2 = new NumericUpDown();
		textBox_0 = new TextBox();
		groupBox_0 = new GroupBox();
		button_9 = new Button();
		button_10 = new Button();
		button_0 = new Button();
		label_0 = new Label();
		button_1 = new Button();
		button_2 = new Button();
		checkBox_9 = new CheckBox();
		comboBox_6 = new ComboBox();
		label_2 = new Label();
		textBox_2 = new TextBox();
		label_3 = new Label();
		label_4 = new Label();
		numericUpDown_0 = new NumericUpDown();
		button_5 = new Button();
		button_6 = new Button();
		button_7 = new Button();
		groupBox_2 = new GroupBox();
		button_11 = new Button();
		comboBox_7 = new ComboBox();
		label_5 = new Label();
		comboBox_8 = new ComboBox();
		groupBox_3 = new GroupBox();
		groupBox_5 = new GroupBox();
		button_8 = new Button();
		progressBar_0 = new ProgressBar();
		progressBar_1 = new ProgressBar();
		panel_0 = new Panel();
		checkBox_10 = new CheckBox();
		numericUpDown_1 = new NumericUpDown();
		groupBox_6.SuspendLayout();
		groupBox_4.SuspendLayout();
		groupBox_1.SuspendLayout();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		groupBox_0.SuspendLayout();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		groupBox_2.SuspendLayout();
		groupBox_3.SuspendLayout();
		groupBox_5.SuspendLayout();
		panel_0.SuspendLayout();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		SuspendLayout();
		button_13.AutoSize = true;
		button_13.DialogResult = DialogResult.Cancel;
		button_13.Enabled = false;
		button_13.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_13.Image = Resources.cmdUnprotectPCK;
		button_13.ImageAlign = ContentAlignment.MiddleRight;
		button_13.Location = new Point(228, 289);
		button_13.Name = Class16.smethod_0(1649187772);
		button_13.Size = new Size(218, 38);
		button_13.TabIndex = 35;
		button_13.TabStop = false;
		button_13.Text = Class16.smethod_0(1649026485);
		button_13.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_13.UseVisualStyleBackColor = true;
		button_13.Click += button_13_Click;
		button_14.AutoSize = true;
		button_14.DialogResult = DialogResult.OK;
		button_14.Enabled = false;
		button_14.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		button_14.Image = Resources.cmdProtectPCK;
		button_14.ImageAlign = ContentAlignment.MiddleRight;
		button_14.Location = new Point(6, 289);
		button_14.Name = Class16.smethod_0(1649187498);
		button_14.Size = new Size(218, 38);
		button_14.TabIndex = 34;
		button_14.TabStop = false;
		button_14.Text = Class16.smethod_0(1649175018);
		button_14.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_14.UseVisualStyleBackColor = true;
		button_14.Click += button_14_Click;
		groupBox_6.Controls.Add(groupBox_4);
		groupBox_6.Controls.Add(groupBox_1);
		groupBox_6.Controls.Add(button_3);
		groupBox_6.Controls.Add(button_12);
		groupBox_6.Controls.Add(label_6);
		groupBox_6.Controls.Add(textBox_6);
		groupBox_6.Controls.Add(button_14);
		groupBox_6.Controls.Add(button_13);
		groupBox_6.Enabled = false;
		groupBox_6.Location = new Point(467, 3);
		groupBox_6.Name = Class16.smethod_0(1649169927);
		groupBox_6.Size = new Size(453, 333);
		groupBox_6.TabIndex = 40;
		groupBox_6.TabStop = false;
		groupBox_6.Text = Class16.smethod_0(1649169950);
		groupBox_4.Controls.Add(checkBox_6);
		groupBox_4.Controls.Add(checkBox_0);
		groupBox_4.Location = new Point(9, 246);
		groupBox_4.Name = Class16.smethod_0(1648995906);
		groupBox_4.Size = new Size(436, 40);
		groupBox_4.TabIndex = 56;
		groupBox_4.TabStop = false;
		groupBox_4.Text = Class16.smethod_0(1649175243);
		checkBox_6.AutoSize = true;
		checkBox_6.Checked = true;
		checkBox_6.CheckState = CheckState.Checked;
		checkBox_6.Location = new Point(10, 18);
		checkBox_6.Name = Class16.smethod_0(1649169978);
		checkBox_6.Size = new Size(105, 17);
		checkBox_6.TabIndex = 55;
		checkBox_6.Text = Class16.smethod_0(1649170001);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(296, 18);
		checkBox_0.Name = Class16.smethod_0(1649170030);
		checkBox_0.Size = new Size(81, 17);
		checkBox_0.TabIndex = 47;
		checkBox_0.Text = Class16.smethod_0(1649170042);
		checkBox_0.UseVisualStyleBackColor = true;
		groupBox_1.Controls.Add(textBox_3);
		groupBox_1.Controls.Add(comboBox_10);
		groupBox_1.Controls.Add(checkBox_8);
		groupBox_1.Controls.Add(comboBox_5);
		groupBox_1.Controls.Add(comboBox_9);
		groupBox_1.Controls.Add(checkBox_7);
		groupBox_1.Controls.Add(checkBox_5);
		groupBox_1.Controls.Add(textBox_1);
		groupBox_1.Controls.Add(comboBox_4);
		groupBox_1.Controls.Add(checkBox_4);
		groupBox_1.Controls.Add(comboBox_2);
		groupBox_1.Controls.Add(comboBox_3);
		groupBox_1.Controls.Add(checkBox_3);
		groupBox_1.Controls.Add(checkBox_2);
		groupBox_1.Controls.Add(checkBox_1);
		groupBox_1.Controls.Add(comboBox_1);
		groupBox_1.Location = new Point(9, 43);
		groupBox_1.Name = Class16.smethod_0(1649170068);
		groupBox_1.Size = new Size(435, 197);
		groupBox_1.TabIndex = 54;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1649170080);
		textBox_3.Enabled = false;
		textBox_3.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_3.Location = new Point(66, 168);
		textBox_3.Name = Class16.smethod_0(1649170112);
		textBox_3.Size = new Size(117, 23);
		textBox_3.TabIndex = 66;
		textBox_3.Text = Class16.smethod_0(1649170141);
		textBox_3.TextAlign = HorizontalAlignment.Center;
		textBox_3.TextChanged += textBox_3_TextChanged;
		comboBox_10.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_10.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_10.FormattingEnabled = true;
		comboBox_10.Location = new Point(189, 169);
		comboBox_10.Name = Class16.smethod_0(1649170164);
		comboBox_10.Size = new Size(238, 21);
		comboBox_10.TabIndex = 65;
		checkBox_8.AutoSize = true;
		checkBox_8.Enabled = false;
		checkBox_8.Location = new Point(6, 171);
		checkBox_8.Name = Class16.smethod_0(1649170188);
		checkBox_8.Size = new Size(58, 17);
		checkBox_8.TabIndex = 64;
		checkBox_8.Text = Class16.smethod_0(1649170208);
		checkBox_8.UseVisualStyleBackColor = true;
		comboBox_9.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_9.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_9.FormattingEnabled = true;
		comboBox_9.Location = new Point(189, 18);
		comboBox_9.Name = Class16.smethod_0(1649170230);
		comboBox_9.Size = new Size(238, 21);
		comboBox_9.TabIndex = 63;
		checkBox_7.AutoSize = true;
		checkBox_7.Enabled = false;
		checkBox_7.Location = new Point(6, 20);
		checkBox_7.Name = Class16.smethod_0(1649170240);
		checkBox_7.Size = new Size(172, 17);
		checkBox_7.TabIndex = 62;
		checkBox_7.Text = Class16.smethod_0(1649170270);
		checkBox_7.UseVisualStyleBackColor = true;
		textBox_1.Enabled = false;
		textBox_1.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_1.Location = new Point(66, 143);
		textBox_1.Name = Class16.smethod_0(1649170298);
		textBox_1.Size = new Size(117, 23);
		textBox_1.TabIndex = 61;
		textBox_1.Text = Class16.smethod_0(1649170326);
		textBox_1.TextAlign = HorizontalAlignment.Center;
		textBox_1.TextChanged += textBox_1_TextChanged;
		comboBox_4.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_4.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_4.FormattingEnabled = true;
		comboBox_4.Location = new Point(189, 144);
		comboBox_4.Name = Class16.smethod_0(1649170349);
		comboBox_4.Size = new Size(238, 21);
		comboBox_4.TabIndex = 60;
		checkBox_4.AutoSize = true;
		checkBox_4.Enabled = false;
		checkBox_4.Location = new Point(6, 146);
		checkBox_4.Name = Class16.smethod_0(1649170372);
		checkBox_4.Size = new Size(58, 17);
		checkBox_4.TabIndex = 59;
		checkBox_4.Text = Class16.smethod_0(1649170208);
		checkBox_4.UseVisualStyleBackColor = true;
		comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_2.FormattingEnabled = true;
		comboBox_2.Location = new Point(189, 42);
		comboBox_2.Name = Class16.smethod_0(1649170399);
		comboBox_2.Size = new Size(238, 21);
		comboBox_2.TabIndex = 56;
		checkBox_3.AutoSize = true;
		checkBox_3.Enabled = false;
		checkBox_3.Location = new Point(6, 45);
		checkBox_3.Name = Class16.smethod_0(1649170420);
		checkBox_3.Size = new Size(163, 17);
		checkBox_3.TabIndex = 55;
		checkBox_3.Text = Class16.smethod_0(1649169421);
		checkBox_3.UseVisualStyleBackColor = true;
		button_3.Image = Resources.cmdBrowsePckFile;
		button_3.Location = new Point(419, 15);
		button_3.Name = Class16.smethod_0(1649188067);
		button_3.Size = new Size(26, 24);
		button_3.TabIndex = 51;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		comboBox_5.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_5.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_5.FormattingEnabled = true;
		comboBox_5.Location = new Point(189, 111);
		comboBox_5.Name = Class16.smethod_0(1649169448);
		comboBox_5.Size = new Size(238, 21);
		comboBox_5.TabIndex = 58;
		button_12.Image = Resources.cmdBrowseClientDir;
		button_12.Location = new Point(393, 15);
		button_12.Name = Class16.smethod_0(1649188587);
		button_12.Size = new Size(26, 24);
		button_12.TabIndex = 44;
		button_12.UseVisualStyleBackColor = true;
		button_12.Click += button_12_Click;
		checkBox_5.AutoSize = true;
		checkBox_5.Enabled = false;
		checkBox_5.Location = new Point(6, 113);
		checkBox_5.Name = Class16.smethod_0(1649169466);
		checkBox_5.Size = new Size(162, 17);
		checkBox_5.TabIndex = 57;
		checkBox_5.Text = Class16.smethod_0(1649169488);
		checkBox_5.UseVisualStyleBackColor = true;
		label_6.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_6.Location = new Point(7, 20);
		label_6.Name = Class16.smethod_0(1648893046);
		label_6.Size = new Size(36, 15);
		label_6.TabIndex = 43;
		label_6.Text = Class16.smethod_0(1649116897);
		label_6.TextAlign = ContentAlignment.MiddleRight;
		textBox_6.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_6.Location = new Point(49, 16);
		textBox_6.Name = Class16.smethod_0(1649169523);
		textBox_6.Size = new Size(339, 23);
		textBox_6.TabIndex = 42;
		textBox_6.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(textBox_6, Class16.smethod_0(1649169551));
		textBox_6.TextChanged += textBox_6_TextChanged;
		textBox_6.DoubleClick += textBox_6_DoubleClick;
		comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_3.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_3.FormattingEnabled = true;
		comboBox_3.Location = new Point(189, 89);
		comboBox_3.Name = Class16.smethod_0(1649169615);
		comboBox_3.Size = new Size(238, 21);
		comboBox_3.TabIndex = 54;
		checkBox_2.AutoSize = true;
		checkBox_2.Enabled = false;
		checkBox_2.Location = new Point(6, 68);
		checkBox_2.Name = Class16.smethod_0(1649169636);
		checkBox_2.Size = new Size(156, 17);
		checkBox_2.TabIndex = 48;
		checkBox_2.Text = Class16.smethod_0(1649169663);
		checkBox_2.UseVisualStyleBackColor = true;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Location = new Point(189, 66);
		comboBox_1.Name = Class16.smethod_0(1649169690);
		comboBox_1.Size = new Size(238, 21);
		comboBox_1.TabIndex = 53;
		checkBox_1.AutoSize = true;
		checkBox_1.Enabled = false;
		checkBox_1.Location = new Point(6, 91);
		checkBox_1.Name = Class16.smethod_0(1649169713);
		checkBox_1.Size = new Size(182, 17);
		checkBox_1.TabIndex = 49;
		checkBox_1.Text = Class16.smethod_0(1649169738);
		checkBox_1.UseVisualStyleBackColor = true;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[6]
		{
			Class16.smethod_0(1649169776),
			Class16.smethod_0(1649169794),
			Class16.smethod_0(1649169821),
			Class16.smethod_0(1649169838),
			Class16.smethod_0(1649169853),
			Class16.smethod_0(1649169871)
		});
		comboBox_0.Location = new Point(119, 68);
		comboBox_0.Name = Class16.smethod_0(1649169890);
		comboBox_0.Size = new Size(326, 21);
		comboBox_0.TabIndex = 44;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_1.ImageAlign = ContentAlignment.MiddleRight;
		label_1.Location = new Point(1, 71);
		label_1.Name = Class16.smethod_0(1649169915);
		label_1.Size = new Size(112, 13);
		label_1.TabIndex = 45;
		label_1.Text = Class16.smethod_0(1649168924);
		label_1.TextAlign = ContentAlignment.MiddleRight;
		button_4.Dock = DockStyle.Bottom;
		button_4.Image = Resources.cmdSaveKey;
		button_4.ImageAlign = ContentAlignment.MiddleRight;
		button_4.Location = new Point(3, 81);
		button_4.Name = Class16.smethod_0(1649187574);
		button_4.Size = new Size(447, 24);
		button_4.TabIndex = 50;
		button_4.Text = Class16.smethod_0(1649168948);
		button_4.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		textBox_5.Dock = DockStyle.Top;
		textBox_5.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_5.Location = new Point(3, 18);
		textBox_5.Multiline = true;
		textBox_5.Name = Class16.smethod_0(1649168984);
		textBox_5.ReadOnly = true;
		textBox_5.Size = new Size(447, 53);
		textBox_5.TabIndex = 45;
		textBox_5.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(textBox_5, Class16.smethod_0(1649169005));
		textBox_4.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_4.Location = new Point(11, 31);
		textBox_4.Multiline = true;
		textBox_4.Name = Class16.smethod_0(1649169052);
		textBox_4.ReadOnly = true;
		textBox_4.Size = new Size(251, 72);
		textBox_4.TabIndex = 43;
		textBox_4.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(textBox_4, Class16.smethod_0(1649169068));
		numericUpDown_2.Location = new Point(268, 31);
		numericUpDown_2.Maximum = new decimal(new int[4] { 100000000, 0, 0, 0 });
		numericUpDown_2.Name = Class16.smethod_0(1649169108);
		numericUpDown_2.Size = new Size(47, 22);
		numericUpDown_2.TabIndex = 44;
		toolTip_0.SetToolTip(numericUpDown_2, Class16.smethod_0(1649169127));
		numericUpDown_2.ValueChanged += numericUpDown_2_ValueChanged;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		textBox_0.Location = new Point(49, 20);
		textBox_0.Name = Class16.smethod_0(1649169136);
		textBox_0.Size = new Size(308, 23);
		textBox_0.TabIndex = 42;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.DoubleClick += textBox_0_DoubleClick;
		groupBox_0.Controls.Add(button_9);
		groupBox_0.Controls.Add(button_10);
		groupBox_0.Controls.Add(button_0);
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(textBox_0);
		groupBox_0.Controls.Add(button_1);
		groupBox_0.Controls.Add(button_2);
		groupBox_0.Enabled = false;
		groupBox_0.Location = new Point(7, 173);
		groupBox_0.Name = Class16.smethod_0(1649169172);
		groupBox_0.Size = new Size(453, 49);
		groupBox_0.TabIndex = 41;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1649169187);
		button_9.Enabled = false;
		button_9.Image = Resources.cmdUnprotectElementClient;
		button_9.Location = new Point(389, 19);
		button_9.Name = Class16.smethod_0(1649187740);
		button_9.Size = new Size(26, 24);
		button_9.TabIndex = 53;
		button_9.UseVisualStyleBackColor = true;
		button_9.Click += button_9_Click;
		button_10.Enabled = false;
		button_10.Image = Resources.cmdProtectElementClient;
		button_10.Location = new Point(363, 19);
		button_10.Name = Class16.smethod_0(1649187476);
		button_10.Size = new Size(26, 24);
		button_10.TabIndex = 52;
		button_10.UseVisualStyleBackColor = true;
		button_10.Click += button_10_Click;
		button_0.Image = Resources.cmdSelectElementclientExe;
		button_0.Location = new Point(419, 19);
		button_0.Name = Class16.smethod_0(1649187591);
		button_0.Size = new Size(26, 24);
		button_0.TabIndex = 44;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_0.Location = new Point(7, 24);
		label_0.Name = Class16.smethod_0(1648912083);
		label_0.Size = new Size(36, 15);
		label_0.TabIndex = 43;
		label_0.Text = Class16.smethod_0(1649116897);
		label_0.TextAlign = ContentAlignment.MiddleRight;
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.OK;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.button2;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(4, 49);
		button_1.Name = Class16.smethod_0(1648991134);
		button_1.Size = new Size(218, 38);
		button_1.TabIndex = 34;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1649175018);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_2.AutoSize = true;
		button_2.DialogResult = DialogResult.Cancel;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_2.Image = Resources.button3;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(227, 51);
		button_2.Name = Class16.smethod_0(1648990257);
		button_2.Size = new Size(218, 38);
		button_2.TabIndex = 35;
		button_2.TabStop = false;
		button_2.Text = Class16.smethod_0(1649026485);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		checkBox_9.AutoSize = true;
		checkBox_9.Location = new Point(126, 8);
		checkBox_9.Name = Class16.smethod_0(1649169231);
		checkBox_9.Size = new Size(136, 17);
		checkBox_9.TabIndex = 36;
		checkBox_9.Text = Class16.smethod_0(1649169261);
		checkBox_9.UseVisualStyleBackColor = true;
		comboBox_6.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_6.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_6.FormattingEnabled = true;
		comboBox_6.Location = new Point(119, 18);
		comboBox_6.Name = Class16.smethod_0(1649169280);
		comboBox_6.Size = new Size(326, 21);
		comboBox_6.TabIndex = 53;
		comboBox_6.SelectedIndexChanged += comboBox_6_SelectedIndexChanged;
		label_2.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_2.Location = new Point(1, 18);
		label_2.Name = Class16.smethod_0(1649169298);
		label_2.Size = new Size(112, 13);
		label_2.TabIndex = 54;
		label_2.Text = Class16.smethod_0(1649169315);
		label_2.TextAlign = ContentAlignment.MiddleRight;
		textBox_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_2.Location = new Point(119, 92);
		textBox_2.Name = Class16.smethod_0(1649169343);
		textBox_2.Size = new Size(170, 22);
		textBox_2.TabIndex = 59;
		label_3.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_3.Location = new Point(1, 94);
		label_3.Name = Class16.smethod_0(1649169367);
		label_3.Size = new Size(112, 13);
		label_3.TabIndex = 60;
		label_3.Text = Class16.smethod_0(1649169391);
		label_3.TextAlign = ContentAlignment.MiddleRight;
		label_4.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_4.Location = new Point(294, 94);
		label_4.Name = Class16.smethod_0(1649169402);
		label_4.Size = new Size(58, 13);
		label_4.TabIndex = 61;
		label_4.Text = Class16.smethod_0(1649168414);
		label_4.TextAlign = ContentAlignment.MiddleRight;
		numericUpDown_0.Location = new Point(355, 92);
		numericUpDown_0.Maximum = new decimal(new int[4] { 6, 0, 0, 0 });
		numericUpDown_0.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1649168431);
		numericUpDown_0.Size = new Size(48, 22);
		numericUpDown_0.TabIndex = 62;
		numericUpDown_0.Value = new decimal(new int[4] { 6, 0, 0, 0 });
		button_5.ImageAlign = ContentAlignment.MiddleRight;
		button_5.Location = new Point(404, 90);
		button_5.Name = Class16.smethod_0(1649168451);
		button_5.Size = new Size(45, 24);
		button_5.TabIndex = 63;
		button_5.Text = Class16.smethod_0(1649168474);
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		button_6.ImageAlign = ContentAlignment.MiddleRight;
		button_6.Location = new Point(119, 120);
		button_6.Name = Class16.smethod_0(1649168494);
		button_6.Size = new Size(105, 23);
		button_6.TabIndex = 64;
		button_6.Text = Class16.smethod_0(1649168507);
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		button_7.ImageAlign = ContentAlignment.MiddleRight;
		button_7.Location = new Point(232, 120);
		button_7.Name = Class16.smethod_0(1649168532);
		button_7.Size = new Size(105, 23);
		button_7.TabIndex = 65;
		button_7.Text = Class16.smethod_0(1648991416);
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		groupBox_2.Controls.Add(button_11);
		groupBox_2.Controls.Add(button_4);
		groupBox_2.Controls.Add(textBox_5);
		groupBox_2.Enabled = false;
		groupBox_2.Location = new Point(7, 228);
		groupBox_2.Name = Class16.smethod_0(1649168545);
		groupBox_2.Size = new Size(453, 108);
		groupBox_2.TabIndex = 55;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1649168566);
		button_11.Dock = DockStyle.Bottom;
		button_11.Image = Resources.cmdNextKey;
		button_11.ImageAlign = ContentAlignment.MiddleRight;
		button_11.Location = new Point(3, 57);
		button_11.Name = Class16.smethod_0(1649187356);
		button_11.Size = new Size(447, 24);
		button_11.TabIndex = 51;
		button_11.Text = Class16.smethod_0(1649168590);
		button_11.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_11.UseVisualStyleBackColor = true;
		button_11.Click += button_11_Click;
		comboBox_7.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_7.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_7.FormattingEnabled = true;
		comboBox_7.Items.AddRange(new object[9]
		{
			Class16.smethod_0(1649168626),
			Class16.smethod_0(1648994670),
			Class16.smethod_0(1648994682),
			Class16.smethod_0(1648994731),
			Class16.smethod_0(1649168642),
			Class16.smethod_0(1649168666),
			Class16.smethod_0(1649168693),
			Class16.smethod_0(1649190294),
			Class16.smethod_0(1649168709)
		});
		comboBox_7.Location = new Point(119, 43);
		comboBox_7.Name = Class16.smethod_0(1649168712);
		comboBox_7.Size = new Size(238, 21);
		comboBox_7.TabIndex = 56;
		comboBox_7.SelectedIndexChanged += comboBox_7_SelectedIndexChanged;
		label_5.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		label_5.ImageAlign = ContentAlignment.MiddleRight;
		label_5.Location = new Point(23, 46);
		label_5.Name = Class16.smethod_0(1649168734);
		label_5.Size = new Size(90, 13);
		label_5.TabIndex = 57;
		label_5.Text = Class16.smethod_0(1649168748);
		label_5.TextAlign = ContentAlignment.MiddleRight;
		comboBox_8.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_8.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_8.FormattingEnabled = true;
		comboBox_8.Items.AddRange(new object[1] { Class16.smethod_0(1649007050) });
		comboBox_8.Location = new Point(363, 43);
		comboBox_8.Name = Class16.smethod_0(1649168752);
		comboBox_8.Size = new Size(82, 21);
		comboBox_8.TabIndex = 58;
		comboBox_8.SelectedIndexChanged += comboBox_8_SelectedIndexChanged;
		groupBox_3.Controls.Add(label_2);
		groupBox_3.Controls.Add(comboBox_8);
		groupBox_3.Controls.Add(label_1);
		groupBox_3.Controls.Add(comboBox_7);
		groupBox_3.Controls.Add(comboBox_0);
		groupBox_3.Controls.Add(label_5);
		groupBox_3.Controls.Add(comboBox_6);
		groupBox_3.Controls.Add(label_3);
		groupBox_3.Controls.Add(textBox_2);
		groupBox_3.Controls.Add(label_4);
		groupBox_3.Controls.Add(numericUpDown_0);
		groupBox_3.Controls.Add(button_5);
		groupBox_3.Controls.Add(button_6);
		groupBox_3.Controls.Add(button_7);
		groupBox_3.Location = new Point(7, 3);
		groupBox_3.Name = Class16.smethod_0(1649168781);
		groupBox_3.Size = new Size(453, 160);
		groupBox_3.TabIndex = 51;
		groupBox_3.TabStop = false;
		groupBox_3.Text = Class16.smethod_0(1649168806);
		groupBox_5.Controls.Add(button_8);
		groupBox_5.Controls.Add(progressBar_0);
		groupBox_5.Controls.Add(progressBar_1);
		groupBox_5.Location = new Point(7, 336);
		groupBox_5.Name = Class16.smethod_0(1649168818);
		groupBox_5.Size = new Size(913, 109);
		groupBox_5.TabIndex = 56;
		groupBox_5.TabStop = false;
		groupBox_5.Text = Class16.smethod_0(1648968290);
		button_8.AutoSize = true;
		button_8.DialogResult = DialogResult.OK;
		button_8.Dock = DockStyle.Bottom;
		button_8.Enabled = false;
		button_8.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_8.Image = Resources.cmdRestoreFiles;
		button_8.ImageAlign = ContentAlignment.MiddleRight;
		button_8.Location = new Point(3, 68);
		button_8.Name = Class16.smethod_0(1649187544);
		button_8.Size = new Size(907, 38);
		button_8.TabIndex = 35;
		button_8.TabStop = false;
		button_8.Text = Class16.smethod_0(1649168834);
		button_8.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_8.UseVisualStyleBackColor = true;
		button_8.Click += button_8_Click;
		progressBar_0.Location = new Point(3, 43);
		progressBar_0.Name = Class16.smethod_0(1649032508);
		progressBar_0.Size = new Size(907, 23);
		progressBar_0.TabIndex = 1;
		progressBar_1.Dock = DockStyle.Top;
		progressBar_1.Location = new Point(3, 18);
		progressBar_1.Name = Class16.smethod_0(1649168865);
		progressBar_1.Size = new Size(907, 23);
		progressBar_1.TabIndex = 0;
		panel_0.Controls.Add(numericUpDown_2);
		panel_0.Controls.Add(textBox_4);
		panel_0.Controls.Add(checkBox_10);
		panel_0.Controls.Add(numericUpDown_1);
		panel_0.Controls.Add(checkBox_9);
		panel_0.Dock = DockStyle.Bottom;
		panel_0.Location = new Point(0, 448);
		panel_0.Name = Class16.smethod_0(1649168892);
		panel_0.Size = new Size(924, 112);
		panel_0.TabIndex = 36;
		panel_0.Visible = false;
		checkBox_10.AutoSize = true;
		checkBox_10.Location = new Point(268, 8);
		checkBox_10.Name = Class16.smethod_0(1649171977);
		checkBox_10.Size = new Size(163, 17);
		checkBox_10.TabIndex = 38;
		checkBox_10.Text = Class16.smethod_0(1649172005);
		checkBox_10.UseVisualStyleBackColor = true;
		numericUpDown_1.Location = new Point(11, 3);
		numericUpDown_1.Maximum = new decimal(new int[4] { 100000000, 0, 0, 0 });
		numericUpDown_1.Name = Class16.smethod_0(1649172038);
		numericUpDown_1.Size = new Size(109, 22);
		numericUpDown_1.TabIndex = 37;
		numericUpDown_1.ValueChanged += numericUpDown_1_ValueChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(924, 560);
		base.Controls.Add(panel_0);
		base.Controls.Add(groupBox_5);
		base.Controls.Add(groupBox_3);
		base.Controls.Add(groupBox_2);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(groupBox_6);
		Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.PCKProtectionWindow_Icon;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649172049);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649172075);
		base.HelpButtonClicked += PCKProtectionWindow_HelpButtonClicked;
		base.FormClosing += PCKProtectionWindow_FormClosing;
		base.Shown += PCKProtectionWindow_Shown;
		groupBox_6.ResumeLayout(performLayout: false);
		groupBox_6.PerformLayout();
		groupBox_4.ResumeLayout(performLayout: false);
		groupBox_4.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		((ISupportInitialize)numericUpDown_2).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		((ISupportInitialize)numericUpDown_0).EndInit();
		groupBox_2.ResumeLayout(performLayout: false);
		groupBox_2.PerformLayout();
		groupBox_3.ResumeLayout(performLayout: false);
		groupBox_3.PerformLayout();
		groupBox_5.ResumeLayout(performLayout: false);
		groupBox_5.PerformLayout();
		panel_0.ResumeLayout(performLayout: false);
		panel_0.PerformLayout();
		((ISupportInitialize)numericUpDown_1).EndInit();
		ResumeLayout(performLayout: false);
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_6();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_8(GAMES games_0)
	{
		if (games_0 != GAMES.PW)
		{
			return true;
		}
		if (CommonStorage.License.Special.PCK.AllowAnyProject)
		{
			return true;
		}
		string text = textBox_6.Text;
		if (text.StartsWith(Class16.smethod_0(1648904453)))
		{
			text = text.Replace(Class16.smethod_0(1648904453), string.Empty);
		}
		bool flag = File.Exists(text);
		bool flag2 = false;
		bool flag3 = false;
		PCK pCK = null;
		if (Directory.Exists(text))
		{
			string text2 = text + Class16.smethod_0(1649199435);
			if (File.Exists(text2))
			{
				flag3 = ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(File.ReadAllText(text2), comboBox_6.Text);
			}
			else
			{
				object[] vars = new object[1] { text2 };
				TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
			}
			int num = 0;
			string[] array = string_0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					if (array[num].EndsWith(Class16.smethod_0(1648908995)))
					{
						pCK = new PCK(string_0[num], GAMES.PW, null);
					}
					num++;
					array = string_0;
				}
				while (num < (nint)array.LongLength);
			}
			if (pCK == null)
			{
				object[] vars2 = new object[1] { Class16.smethod_0(1648908995) };
				TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars2);
				GC.KeepAlive(this);
				return false;
			}
		}
		else
		{
			if (flag)
			{
				if (text.EndsWith(Class16.smethod_0(1648908995)))
				{
					pCK = new PCK(text, GAMES.PW, null);
				}
				flag3 = true;
			}
			if (pCK == null)
			{
				goto IL_01f8;
			}
		}
		if (pCK.FileLoaded)
		{
			string value = Class16.smethod_0(1649175820);
			if (!comboBox_8.Text.StartsWith(value))
			{
				string fileU = pCK.GetFileU(Class16.smethod_0(1649172117));
				pCK.Close();
				if (fileU != null)
				{
					flag2 = ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(fileU, comboBox_6.Text);
				}
				else
				{
					object[] vars3 = new object[1] { Class16.smethod_0(1649172117) };
					TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars3);
				}
				goto IL_01fb;
			}
		}
		goto IL_01f8;
		IL_01fb:
		GC.KeepAlive(this);
		int num2 = ((flag2 && flag3) ? 1 : 0);
		return (byte)num2 != 0;
		IL_01f8:
		flag2 = true;
		goto IL_01fb;
	}

	private void button_12_Click(object sender, EventArgs e)
	{
		method_11();
	}

	private void textBox_6_DoubleClick(object sender, EventArgs e)
	{
		method_11();
	}

	private void PCKProtectionWindow_Shown(object sender, EventArgs e)
	{
		method_15();
		if (list_0 == null)
		{
			Close();
		}
		comboBox_7.SelectedIndex = (int)CommonStorage.Params.Game;
		checkBox_2.Enabled = License.Special.PCK.Serverlist;
		comboBox_1.Enabled = License.Special.PCK.Serverlist;
		checkBox_1.Enabled = License.Special.PCK.Elements;
		comboBox_3.Enabled = License.Special.PCK.Elements;
		checkBox_7.Enabled = License.Special.PCK.GShop;
		checkBox_5.Enabled = License.Special.PCK.Tasks;
		comboBox_5.Enabled = License.Special.PCK.Tasks;
		checkBox_4.Enabled = License.Special.PCK.CustomFile;
		textBox_1.Enabled = License.Special.PCK.CustomFile;
		checkBox_3.Enabled = License.Special.PCK.PathData;
		comboBox_4.Enabled = true;
		comboBox_9.Enabled = true;
		comboBox_2.Enabled = true;
		comboBox_10.Enabled = true;
		checkBox_8.Enabled = License.Special.PCK.CustomFile;
		textBox_3.Enabled = License.Special.PCK.CustomFile2;
		GC.KeepAlive(this);
		if (TDark.IsDarkMode)
		{
			TDark.ApplyTheme(this);
			TDark.ApplyNativeDarkThemeRecursive(this);
		}
	}

	private void button_13_Click(object sender, EventArgs e)
	{
		if (!CommonStorage.License.Licenses.PCKProtection)
		{
			return;
		}
		string text = textBox_6.Text;
		if (string.IsNullOrWhiteSpace(text))
		{
			GC.KeepAlive(this);
			return;
		}
		bool flag = false;
		Cursor = Cursors.WaitCursor;
		button_14.Enabled = false;
		button_13.Enabled = false;
		if (text.StartsWith(Class16.smethod_0(1648904453)))
		{
			text = text.Replace(Class16.smethod_0(1648904453), string.Empty);
		}
		bool flag2 = File.Exists(text);
		bool flag3 = Directory.Exists(text);
		_ = comboBox_0.SelectedIndex;
		if (PCKs != null)
		{
			PCKs.CloseAllFiles();
		}
		long num = 0L;
		long num2 = 0L;
		string[] array = string_0;
		int num3 = array.Length;
		long[] array2 = new long[num3];
		int num4 = 0;
		if (0 < num3)
		{
			do
			{
				long length = new FileInfo(array[num4]).Length;
				array2[num4] = length / 10000L;
				num += array2[num4];
				num4++;
				array = string_0;
			}
			while (num4 < (nint)array.LongLength);
		}
		GAMES selectedIndex = (GAMES)comboBox_7.SelectedIndex;
		string text2 = string_0[ACE.RSGlobal.RSGlobal.GetMinValueIndex(array2)];
		if (method_19(text2))
		{
			if ((nint)string_0.LongLength > 1 && !PCK.IsArchiveProtected(text2, selectedIndex))
			{
				object[] vars = new object[1] { text2 };
				if (TextStorage.TEXTS.ShowMessage(649, MessageBoxButtons.YesNo, MessageBoxIcon.Question, vars) == DialogResult.No)
				{
					goto IL_044b;
				}
			}
			if (PCKSettings.ProtectionLevel > 1)
			{
				PCKOptions.IsProtected = true;
			}
			comboBox_7.SelectedIndex = (int)selectedIndex;
			object[] vars2 = new object[1] { Class16.smethod_0(1649172150) };
			string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172160), vars2);
			groupBox_5.Text = text3;
			method_9(0L, num);
			Application.DoEvents();
			bool allowAnyProject = License.Special.PCK.AllowAnyProject;
			if (flag2)
			{
				string fileName = System.IO.Path.GetFileName(text);
				object[] vars3 = new object[1] { fileName };
				string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172160), vars3);
				groupBox_5.Text = text4;
				if (PCK.UnProtect(text, selectedIndex, PCKSettings, PCKOptions, allowAnyProject))
				{
					long num5 = num;
					method_9(num5, num5);
					TextStorage.TEXTS.ShowMessage(544, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
					button_13.Enabled = false;
					byte b = ((!button_13.Enabled) ? ((byte)1) : ((byte)0));
					button_14.Enabled = b != 0;
					flag = true;
				}
			}
			else if (flag3)
			{
				int num6 = 0;
				_ = checkBox_0.Checked;
				TextStorage.TEXTS.DontShowExceptions = true;
				int num7 = 0;
				string[] array3 = string_0;
				if (0 < (nint)array3.LongLength)
				{
					do
					{
						string fileName2 = System.IO.Path.GetFileName(array3[num7]);
						object[] vars4 = new object[1] { fileName2 };
						string text5 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172160), vars4);
						groupBox_5.Text = text5;
						method_9(num2, num);
						Application.DoEvents();
						num2 += array2[num7];
						if (PCK.UnProtect(string_0[num7], selectedIndex, PCKSettings, PCKOptions, allowAnyProject))
						{
							num6++;
						}
						num7++;
						array3 = string_0;
					}
					while (num7 < (nint)array3.LongLength);
				}
				CommonStorage.Texts.DontShowExceptions = false;
				long num8 = num;
				method_9(num8, num8);
				if ((nint)num6 == (nint)string_0.LongLength)
				{
					TextStorage.TEXTS.ShowMessage(544, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
				}
				else
				{
					object[] vars5 = new object[2] { num6, string_0.Length };
					TextStorage.TEXTS.ShowMessage(544, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars5);
				}
				if (PCKSettings.ProtectionLevel > 1 && button_9.Enabled)
				{
					button_9_Click(sender, e);
				}
			}
			else
			{
				object[] vars6 = new object[1] { text };
				TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars6);
			}
		}
		goto IL_044b;
		IL_044b:
		string text6 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172191));
		Text = text6;
		groupBox_2.Enabled = true;
		progressBar_1.Style = ProgressBarStyle.Blocks;
		progressBar_0.Value = 0;
		if (flag2 && !flag)
		{
			button_13.Enabled = PCK.IsArchiveProtected(text, (GAMES)comboBox_7.SelectedIndex);
			byte b2 = ((!button_13.Enabled) ? ((byte)1) : ((byte)0));
			button_14.Enabled = b2 != 0;
		}
		else if (flag3)
		{
			button_13.Enabled = true;
			button_14.Enabled = true;
		}
		string text7 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172214));
		groupBox_5.Text = text7;
		Cursor = Cursors.Default;
		GC.KeepAlive(this);
	}

	private void method_9(long long_0, long long_1)
	{
		int num;
		if (long_0 <= 0L)
		{
			num = 0;
		}
		else if (long_1 <= 0L)
		{
			num = 100;
		}
		else
		{
			int num2 = 1 - (int)((double)long_0 / (double)long_1 * -99.0);
			num2 = ((num2 > 100) ? 100 : num2);
			num = num2;
		}
		progressBar_0.Value = num;
		object[] vars = new object[1] { num };
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172237), vars);
		Text = text;
		GC.KeepAlive(this);
	}

	private void button_14_Click(object sender, EventArgs e)
	{
		if (!CommonStorage.License.Licenses.PCKProtection)
		{
			return;
		}
		string text = textBox_6.Text;
		if (string.IsNullOrWhiteSpace(text))
		{
			GC.KeepAlive(this);
			return;
		}
		string[] array = string_0;
		bool flag;
		bool flag2;
		bool flag3;
		string path;
		if (array != null && array.Length != 0)
		{
			flag = false;
			Cursor = Cursors.WaitCursor;
			progressBar_1.Style = ProgressBarStyle.Marquee;
			button_14.Enabled = false;
			button_13.Enabled = false;
			if (text.StartsWith(Class16.smethod_0(1648904453)))
			{
				text = text.Replace(Class16.smethod_0(1648904453), string.Empty);
			}
			flag2 = File.Exists(text);
			flag3 = Directory.Exists(text);
			int num = comboBox_0.SelectedIndex + 1;
			long num2 = 0L;
			long num3 = 0L;
			array = string_0;
			int num4 = array.Length;
			long[] array2 = new long[num4];
			ulong num5 = 0uL;
			int num6 = 0;
			if (0 < num4)
			{
				do
				{
					string text2 = array[num6];
					if (string.IsNullOrEmpty(text2) || !File.Exists(text2))
					{
						object[] vars = new object[1] { text2 };
						TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
						num6++;
						continue;
					}
					long num7;
					try
					{
						num7 = new FileInfo(text2).Length;
					}
					catch (Exception ex)
					{
						SentryHelper.CaptureException(ex, Class16.smethod_0(1649172260));
						num6++;
						continue;
					}
					string pkxName = PCK.PCK_STRUCT.GetPkxName(string_0[num6]);
					if (File.Exists(pkxName))
					{
						try
						{
							num7 += new FileInfo(pkxName).Length;
						}
						catch
						{
						}
					}
					num5 += (ulong)num7;
					array2[num6] = num7 / 10000L + 1L;
					int num8 = ((num < 3) ? 1 : 4);
					num2 += array2[num6] * num8;
					if (checkBox_6.Checked)
					{
						num2 += array2[num6] * 6L;
					}
					num6++;
					array = string_0;
				}
				while (num6 < (nint)array.LongLength);
			}
			GAMES selectedIndex = (GAMES)comboBox_7.SelectedIndex;
			string text3 = string_0[ACE.RSGlobal.RSGlobal.GetMinValueIndex(array2)];
			if (method_19(text3))
			{
				comboBox_7.SelectedIndex = (int)selectedIndex;
				if (!method_8(selectedIndex))
				{
					TextStorage.TEXTS.ShowErrorMessage(640);
				}
				else
				{
					if ((nint)string_0.LongLength > 1)
					{
						bool flag4 = !TextStorage.TEXTS.DontShowExceptions;
						TextStorage.TEXTS.DontShowExceptions = true;
						bool flag5 = PCK.IsArchiveProtected(text3, selectedIndex);
						if (flag4)
						{
							TextStorage.TEXTS.DontShowExceptions = false;
						}
						if (flag5)
						{
							object[] vars2 = new object[1] { text3 };
							if (TextStorage.TEXTS.ShowMessage(648, MessageBoxButtons.YesNo, MessageBoxIcon.Question, vars2) == DialogResult.No)
							{
								goto IL_08f8;
							}
						}
					}
					method_9(0L, num2);
					Application.DoEvents();
					if (PCKs != null)
					{
						PCKs.CloseAllFiles();
					}
					if (checkBox_6.Checked)
					{
						if (num5 > 104857600L)
						{
							object[] vars3 = new object[1] { ACE.RSGlobal.RSGlobal.FileSize2Text(num5) };
							if (TextStorage.TEXTS.ShowMessage(627, MessageBoxButtons.YesNo, MessageBoxIcon.Question, vars3) == DialogResult.No)
							{
								goto IL_08f8;
							}
						}
						if (flag3)
						{
							string text4 = text + Class16.smethod_0(1649172298);
							if (Directory.Exists(text4))
							{
								if (TextStorage.TEXTS.ShowQuestionMessage(622) == DialogResult.No)
								{
									goto IL_08f8;
								}
								Directory.Delete(text4, recursive: true);
							}
							Directory.CreateDirectory(text4);
							int num9 = 0;
							string[] array3 = string_0;
							if (0 < (nint)array3.LongLength)
							{
								do
								{
									string fileName = System.IO.Path.GetFileName(array3[num9]);
									object[] vars4 = new object[1] { fileName };
									string text5 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172314), vars4);
									groupBox_5.Text = text5;
									method_9(num3, num2);
									Application.DoEvents();
									if (!File.Exists(string.Concat(text4 + Class16.smethod_0(1648927580), fileName)))
									{
										File.Copy(string_0[num9], string.Concat(text4 + Class16.smethod_0(1648927580), fileName));
										if (File.Exists(PCK.PCK_STRUCT.GetPkxName(string_0[num9])))
										{
											text5 = System.IO.Path.GetFileName(PCK.PCK_STRUCT.GetPkxName(string_0[num9]));
											vars4 = new object[1] { text5 };
											string text6 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172314), vars4);
											groupBox_5.Text = text6;
											Application.DoEvents();
											text6 = Class16.smethod_0(1648927580);
											File.Copy(PCK.PCK_STRUCT.GetPkxName(string_0[num9]), string.Concat(text4 + text6, text5));
										}
										num3 += array2[num9] * 6L;
									}
									num9++;
									array3 = string_0;
								}
								while (num9 < (nint)array3.LongLength);
							}
						}
						else
						{
							CStorage.CreateBackup(text);
							if (File.Exists(PCK.PCK_STRUCT.GetPkxName(text)))
							{
								CStorage.CreateBackup(PCK.PCK_STRUCT.GetPkxName(text));
							}
						}
					}
					object[] vars5 = new object[1] { Class16.smethod_0(1649172337) };
					string text7 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172357), vars5);
					groupBox_5.Text = text7;
					method_9(num3, num2);
					Application.DoEvents();
					if (flag2)
					{
						text7 = System.IO.Path.GetDirectoryName(text);
						if (text7.EndsWith(Class16.smethod_0(1649172380)))
						{
							text7 = text7.Substring(0, text7.Length - 5);
						}
						if (text7.EndsWith(Class16.smethod_0(1648909375)))
						{
							text7 = text7.Substring(0, text7.Length - 10);
						}
						string fileName2 = System.IO.Path.GetFileName(text);
						object[] vars6 = new object[1] { fileName2 };
						fileName2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172160), vars6);
						groupBox_5.Text = fileName2;
						TextBox textBox = textBox_3;
						TextBox textBox2 = textBox_1;
						fileName2 = Class16.smethod_0(1648927580);
						Hashtable extraFiles = ExtraFiles;
						PCK_PROTECTION_OPTIONS pCKOptions = PCKOptions;
						if (PCK.Protect(text, selectedIndex, PCKSettings, pCKOptions, extraFiles, text7 + fileName2, textBox2.Text, textBox.Text))
						{
							long num10 = num2;
							method_9(num10, num10);
							TextStorage.TEXTS.ShowMessage(532, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
							flag = true;
							button_13.Enabled = true;
							byte b = ((!button_13.Enabled) ? ((byte)1) : ((byte)0));
							button_14.Enabled = b != 0;
						}
					}
					else if (flag3)
					{
						int num11 = 0;
						_ = checkBox_0.Checked;
						TextStorage.TEXTS.DontShowExceptions = true;
						List<string> list = new List<string>();
						int num12 = 0;
						string[] array4 = string_0;
						if (0 < (nint)array4.LongLength)
						{
							do
							{
								string fileName3 = System.IO.Path.GetFileName(array4[num12]);
								object[] vars7 = new object[1] { fileName3 };
								fileName3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172357), vars7);
								groupBox_5.Text = fileName3;
								method_9(num3, num2);
								Application.DoEvents();
								int num13 = ((PCKSettings.ProtectionLevel < 3) ? 1 : 4);
								num3 += array2[num12] * num13;
								TextBox textBox3 = textBox_3;
								TextBox textBox4 = textBox_1;
								Hashtable extraFiles2 = ExtraFiles;
								PCK_PROTECTION_OPTIONS pCKOptions2 = PCKOptions;
								if (PCK.Protect(string_0[num12], selectedIndex, PCKSettings, pCKOptions2, extraFiles2, text, textBox4.Text, textBox3.Text))
								{
									list.Add(string_0[num12] + Class16.smethod_0(1649172384));
									num11++;
								}
								else
								{
									list.Add(string_0[num12] + Class16.smethod_0(1649172402));
								}
								num12++;
								array4 = string_0;
							}
							while (num12 < (nint)array4.LongLength);
						}
						CommonStorage.Texts.DontShowExceptions = false;
						long num14 = num2;
						method_9(num14, num14);
						if ((nint)num11 == (nint)string_0.LongLength)
						{
							TextStorage.TEXTS.ShowMessage(532, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
						}
						else
						{
							object[] vars8 = new object[2] { num11, string_0.Length };
							TextStorage.TEXTS.ShowMessage(647, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars8);
							ACE.RSGlobal.RSGlobal.OpenInNotepad(list);
						}
						if (PCKSettings.ProtectionLevel > 1 || PCKSettings.ExtraFilesMask != 0)
						{
							button_10_Click(sender, e);
						}
						path = text + Class16.smethod_0(1649172298);
						button_8.Enabled = Directory.Exists(path);
					}
					else
					{
						object[] vars9 = new object[1] { text };
						TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars9);
					}
				}
			}
			goto IL_08f8;
		}
		TextStorage.TEXTS.ShowErrorMessage(953);
		GC.KeepAlive(this);
		return;
		IL_08f8:
		groupBox_2.Enabled = true;
		path = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172191));
		Text = path;
		progressBar_1.Style = ProgressBarStyle.Blocks;
		progressBar_0.Value = 0;
		if (flag2 && !flag)
		{
			button_13.Enabled = PCK.IsArchiveProtected(text, (GAMES)comboBox_7.SelectedIndex);
			byte b2 = ((!button_13.Enabled) ? ((byte)1) : ((byte)0));
			button_14.Enabled = b2 != 0;
		}
		else if (flag3)
		{
			button_13.Enabled = true;
			button_14.Enabled = true;
		}
		path = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172214));
		groupBox_5.Text = path;
		Cursor = Cursors.Default;
		GC.KeepAlive(this);
	}

	private void method_10()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649172417);
		if (openFileDialog.ShowDialog(this) == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_6.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void method_11()
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		string description = TextStorage.TEXTS.GetText(Class16.smethod_0(1649172459));
		folderBrowserDialog.Description = description;
		folderBrowserDialog.SelectedPath = textBox_6.Text;
		folderBrowserDialog.ShowNewFolderButton = false;
		if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK && Directory.Exists(folderBrowserDialog.SelectedPath))
		{
			textBox_6.Text = folderBrowserDialog.SelectedPath;
		}
		GC.KeepAlive(this);
	}

	private void method_12(string string_2)
	{
		button_8.Enabled = false;
		string_0 = null;
		if (!string.IsNullOrWhiteSpace(string_2))
		{
			if (Directory.Exists(string_2))
			{
				if (!string_2.EndsWith(Class16.smethod_0(1648927580)))
				{
					string_2 += Class16.smethod_0(1648927580);
				}
				if (Directory.Exists(string_2 + Class16.smethod_0(1648909499)))
				{
					string_2 += Class16.smethod_0(1649171458);
				}
				textBox_6.Text = string_2;
				if (File.Exists(string_2 + Class16.smethod_0(1649171473)))
				{
					textBox_0.Text = string_2 + Class16.smethod_0(1649171473);
				}
				else if (File.Exists(string_2 + Class16.smethod_0(1649171497)))
				{
					textBox_0.Text = string_2 + Class16.smethod_0(1649171497);
				}
				button_8.Enabled = Directory.Exists(string_2 + Class16.smethod_0(1649172298));
				if (Directory.Exists(string_2 + Class16.smethod_0(1648908941)))
				{
					string_2 += Class16.smethod_0(1648908957);
				}
				if (!Directory.Exists(string_2))
				{
					GC.KeepAlive(this);
					return;
				}
				if ((string_0 = Directory.GetFiles(string_2, Class16.smethod_0(1648909407))).Length == 0)
				{
					string_0 = Directory.GetFiles(string_2, Class16.smethod_0(1649171527));
				}
				if (File.Exists(string_2 + Class16.smethod_0(1649171540)))
				{
					ACE.RSGlobal.RSGlobal.AddElementToArray(ref string_0, string_2 + Class16.smethod_0(1649171540));
				}
				if (File.Exists(string_2 + Class16.smethod_0(1649171554)))
				{
					ACE.RSGlobal.RSGlobal.AddElementToArray(ref string_0, string_2 + Class16.smethod_0(1649171554));
				}
				button_13.Enabled = true;
				button_14.Enabled = true;
			}
			else if (File.Exists(string_2))
			{
				string_0 = new string[1] { string_2 };
				button_13.Enabled = PCK.IsArchiveProtected(string_2, (GAMES)comboBox_7.SelectedIndex);
				byte b = ((!button_13.Enabled) ? ((byte)1) : ((byte)0));
				button_14.Enabled = b != 0;
			}
		}
		method_13();
	}

	private void method_13()
	{
		comboBox_1.Items.Clear();
		comboBox_3.Items.Clear();
		comboBox_9.Items.Clear();
		comboBox_5.Items.Clear();
		comboBox_4.Items.Clear();
		comboBox_2.Items.Clear();
		comboBox_10.Items.Clear();
		string[] array = string_0;
		if (array != null)
		{
			int num = array.Length;
			if (num > 0)
			{
				int num2 = 0;
				if (0 < num)
				{
					do
					{
						string item = (array[num2].EndsWith(Class16.smethod_0(1649171540)) ? Class16.smethod_0(1649171540) : ((!string_0[num2].EndsWith(Class16.smethod_0(1649171554))) ? System.IO.Path.GetFileName(string_0[num2]) : Class16.smethod_0(1649171554)));
						if (License.Special.PCK.Serverlist)
						{
							comboBox_1.Items.Add(item);
						}
						if (License.Special.PCK.Elements)
						{
							comboBox_3.Items.Add(item);
						}
						if (License.Special.PCK.GShop)
						{
							comboBox_9.Items.Add(item);
						}
						if (License.Special.PCK.Tasks)
						{
							comboBox_5.Items.Add(item);
						}
						if (License.Special.PCK.CustomFile)
						{
							comboBox_4.Items.Add(item);
						}
						if (License.Special.PCK.CustomFile2)
						{
							comboBox_10.Items.Add(item);
						}
						if (License.Special.PCK.PathData)
						{
							comboBox_2.Items.Add(item);
						}
						num2++;
						array = string_0;
					}
					while (num2 < (nint)array.LongLength);
				}
				if (License.Special.PCK.Serverlist)
				{
					comboBox_1.SelectedIndex = 0;
				}
				if (License.Special.PCK.Elements)
				{
					comboBox_3.SelectedIndex = 0;
				}
				if (License.Special.PCK.GShop)
				{
					comboBox_9.SelectedIndex = 0;
				}
				if (License.Special.PCK.Tasks)
				{
					comboBox_5.SelectedIndex = 0;
				}
				if (License.Special.PCK.CustomFile)
				{
					comboBox_4.SelectedIndex = 0;
				}
				if (License.Special.PCK.CustomFile2)
				{
					comboBox_10.SelectedIndex = 0;
				}
				if (License.Special.PCK.PathData)
				{
					comboBox_2.SelectedIndex = 0;
				}
			}
		}
		GC.KeepAlive(this);
	}

	private void PCKProtectionWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		Form elementsWindow = ElementsWindow;
		if (elementsWindow != null && !elementsWindow.Visible)
		{
			ACE.RSGlobal.RSGlobal.End(null, null);
		}
		GC.KeepAlive(this);
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void PCKProtectionWindow_HelpButtonClicked(object sender, CancelEventArgs e)
	{
		method_14();
	}

	private void method_14()
	{
	}

	private void method_15()
	{
		try
		{
			list_0 = method_1();
			if (list_0 == null)
			{
				list_0 = new List<Class356>();
			}
			for (int i = 0; i < list_0.Count; i++)
			{
				if (list_0[i].MaxLevel < 1 || list_0[i].MaxLevel > 6)
				{
					list_0[i].MaxLevel = 6;
				}
				if (list_0[i].ProtectionLevel < 1)
				{
					list_0[i].ProtectionLevel = 1;
				}
				if (list_0[i].ProtectionLevel > list_0[i].MaxLevel)
				{
					list_0[i].ProtectionLevel = list_0[i].MaxLevel;
				}
				if (list_0[i].Game < 0)
				{
					list_0[i].Game = comboBox_7.SelectedIndex;
				}
			}
			if (list_0.Count == 0)
			{
				int protectionLevel = ((comboBox_0.SelectedIndex < 0) ? 1 : (comboBox_0.SelectedIndex + 1));
				Class356 item = new Class356
				{
					Name = Class16.smethod_0(1649171582),
					MaxLevel = 6,
					ProtectionLevel = protectionLevel,
					Game = comboBox_7.SelectedIndex
				};
				list_0.Add(item);
				method_2();
			}
			else
			{
				method_2();
			}
			method_3(list_0[0].Name);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649171593));
			string text = Class16.smethod_0(1648934564) + ex.Message + Class16.smethod_0(1648934582) + ex.StackTrace + Class16.smethod_0(1648934604);
			foreach (DictionaryEntry datum in ex.Data)
			{
				text += string.Format(Class16.smethod_0(1648934622), datum.Key, datum.Value);
			}
			DKBox.Show(text, Class16.smethod_0(1649171635), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Close();
		}
	}

	private Class356 method_16(Class356 class356_0)
	{
		if (class356_0 == null)
		{
			class356_0 = new Class356
			{
				Name = Class16.smethod_0(1649171582),
				MaxLevel = 6,
				ProtectionLevel = 1,
				Game = comboBox_7.SelectedIndex
			};
		}
		if (string.IsNullOrWhiteSpace(class356_0.Name))
		{
			class356_0.Name = Class16.smethod_0(1649171582);
		}
		if (class356_0.MaxLevel < 1 || class356_0.MaxLevel > 6)
		{
			class356_0.MaxLevel = 6;
		}
		if (class356_0.ProtectionLevel < 1)
		{
			class356_0.ProtectionLevel = 1;
		}
		if (class356_0.ProtectionLevel > class356_0.MaxLevel)
		{
			class356_0.ProtectionLevel = class356_0.MaxLevel;
		}
		if (class356_0.Game < 0)
		{
			class356_0.Game = comboBox_7.SelectedIndex;
		}
		return class356_0;
	}

	private void comboBox_6_SelectedIndexChanged(object sender, EventArgs e)
	{
		int selectedIndex = comboBox_6.SelectedIndex;
		if (list_0 != null && list_0.Count != 0 && selectedIndex >= 0)
		{
			Class356 @class = list_0[selectedIndex];
			groupBox_2.Enabled = false;
			int num = Math.Max(1, @class.ProtectionLevel);
			int num2 = ((@class.MaxLevel < num) ? @class.MaxLevel : num);
			comboBox_0.SelectedIndex = num2 - 1;
			comboBox_0_SelectedIndexChanged(null, null);
		}
		else
		{
			groupBox_2.Enabled = false;
		}
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		Class355 @class = new Class355();
		@class.string_0 = textBox_2.Text.Trim();
		if (string.IsNullOrWhiteSpace(@class.string_0))
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649171685), Class16.smethod_0(1649171722)), Class16.smethod_0(1649171765), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		if (list_0 != null && list_0.Exists(@class.method_0))
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649171770), Class16.smethod_0(1649171820)), Class16.smethod_0(1649171765), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		int num = (int)numericUpDown_0.Value;
		int num2 = comboBox_0.SelectedIndex + 1;
		if (num2 < 1)
		{
			num2 = 1;
		}
		num2 = ((num2 > num) ? num : num2);
		Class356 item = new Class356
		{
			Name = @class.string_0,
			MaxLevel = num,
			ProtectionLevel = num2,
			Game = comboBox_7.SelectedIndex
		};
		if (list_0 == null)
		{
			list_0 = new List<Class356>();
		}
		list_0.Add(item);
		method_2();
		method_3(@class.string_0);
		textBox_2.Clear();
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		if (list_0 != null && list_0.Count != 0 && comboBox_6.SelectedIndex >= 0)
		{
			Class356 @class = method_16(list_0[comboBox_6.SelectedIndex]);
			if (string.IsNullOrWhiteSpace(@class.EncryptedKey) || string.IsNullOrWhiteSpace(@class.CleanKey))
			{
				string string_ = ((string_0 == null || string_0.Length == 0) ? textBox_6.Text : string_0[0]);
				@class = method_18(@class, Math.Max(1, @class.ProtectionLevel), @class.ExtraFilesMask, (GAMES)@class.Game, string_);
				list_0[comboBox_6.SelectedIndex] = @class;
				method_2();
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = Class16.smethod_0(1649171923);
			saveFileDialog.FileName = @class.Name + Class16.smethod_0(1649170960);
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string contents = JsonConvert.SerializeObject((object)@class, (Formatting)1);
				File.WriteAllText(saveFileDialog.FileName, contents, Encoding.UTF8);
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649170983), Class16.smethod_0(1649171023)), Class16.smethod_0(1649171053), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			GC.KeepAlive(this);
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649171859), Class16.smethod_0(1649171896)), Class16.smethod_0(1649171765), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1649171923);
		if (openFileDialog.ShowDialog(this) != DialogResult.OK || !File.Exists(openFileDialog.FileName))
		{
			return;
		}
		try
		{
			Class357 @class = new Class357();
			string text = File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
			@class.class356_0 = method_16(JsonConvert.DeserializeObject<Class356>(text));
			if (list_0 == null)
			{
				list_0 = new List<Class356>();
			}
			int num = list_0.FindIndex(@class.method_0);
			if (num >= 0)
			{
				if (DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649171059), Class16.smethod_0(1649171111)), Class16.smethod_0(1649049749), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				{
					return;
				}
				list_0[num] = @class.class356_0;
			}
			else
			{
				list_0.Add(@class.class356_0);
			}
			if (string.IsNullOrWhiteSpace(@class.class356_0.EncryptedKey) || string.IsNullOrWhiteSpace(@class.class356_0.CleanKey))
			{
				string string_ = ((string_0 == null || string_0.Length == 0) ? textBox_6.Text : string_0[0]);
				@class.class356_0 = method_18(@class.class356_0, Math.Max(1, @class.class356_0.ProtectionLevel), @class.class356_0.ExtraFilesMask, (GAMES)@class.class356_0.Game, string_);
				if (num >= 0)
				{
					list_0[num] = @class.class356_0;
				}
				else
				{
					list_0[list_0.Count - 1] = @class.class356_0;
				}
			}
			method_2();
			method_3(@class.class356_0.Name);
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649171162), Class16.smethod_0(1649171215)), Class16.smethod_0(1649171053), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649172049));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649171242), Class16.smethod_0(1649171282)) + ex.Message, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		GC.KeepAlive(this);
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBox_6.SelectedIndex >= 0 && list_0 != null && list_0.Count != 0)
		{
			int selectedIndex = comboBox_6.SelectedIndex;
			Class356 @class = list_0[selectedIndex];
			if (comboBox_0.SelectedIndex > @class.MaxLevel - 1)
			{
				object[] vars = new object[1] { list_0[selectedIndex].MaxLevel };
				TextStorage.TEXTS.ShowMessage(619, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
				comboBox_0.SelectedIndex = @class.MaxLevel - 1;
			}
			byte b = ((comboBox_0.SelectedIndex > -1) ? ((byte)1) : ((byte)0));
			groupBox_0.Enabled = b != 0;
			string[] array = string_0;
			if (array != null && array.Length != 0 && method_19(array[0]))
			{
				groupBox_2.Enabled = true;
			}
			else
			{
				groupBox_2.Enabled = false;
			}
			GC.KeepAlive(this);
		}
	}

	private void comboBox_7_SelectedIndexChanged(object sender, EventArgs e)
	{
		int selectedIndex = comboBox_7.SelectedIndex;
		comboBox_8.Items.Clear();
		if (selectedIndex == 1)
		{
			string[] array = new string[8];
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649171313));
			array[0] = text;
			array[1] = Class16.smethod_0(1649175820);
			array[2] = Class16.smethod_0(1649175884);
			array[3] = Class16.smethod_0(1649175890);
			array[4] = Class16.smethod_0(1649175824);
			array[5] = Class16.smethod_0(1649175864);
			array[6] = Class16.smethod_0(1649175860);
			array[7] = Class16.smethod_0(1649175840);
			ComboBox.ObjectCollection items = comboBox_8.Items;
			object[] items2 = array;
			items.AddRange(items2);
		}
		else
		{
			string item = TextStorage.TEXTS.GetText(Class16.smethod_0(1649171313));
			comboBox_8.Items.Add(item);
		}
		comboBox_8.SelectedIndex = 0;
		comboBox_0_SelectedIndexChanged(null, null);
	}

	private void textBox_6_TextChanged(object sender, EventArgs e)
	{
		method_12(textBox_6.Text);
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		string value = ACE.RSGlobal.RSGlobal.ShowOpenFileDialog(Class16.smethod_0(1649171336), Class16.smethod_0(1649171375));
		if (!string.IsNullOrEmpty(value))
		{
			textBox_0.Text = value;
		}
		GC.KeepAlive(this);
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		if (comboBox_7.SelectedIndex > 0)
		{
			if (!checkBox_9.Checked && !checkBox_10.Checked && !method_19(null))
			{
				return;
			}
			string text = textBox_0.Text;
			if (text.Length > 2 && text.StartsWith(Class16.smethod_0(1648904453)) && text.EndsWith(Class16.smethod_0(1648904453)))
			{
				text = text.Substring(1, text.Length - 2);
			}
			if (checkBox_6.Checked)
			{
				CStorage.CreateBackup(text);
			}
			if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
			{
				string destFileName = text + Class16.smethod_0(1648898363);
				File.Copy(text, destFileName, overwrite: true);
				if (panel_0.Visible)
				{
					if (checkBox_9.Checked)
					{
						decimal value = numericUpDown_1.Value;
						ComboBox comboBox = comboBox_8;
						ComboBox comboBox2 = comboBox_7;
						if (ClientModifier.PatchElementsLoading(text, (GAMES)comboBox2.SelectedIndex, comboBox.Text, (int)value))
						{
							ACE.RSGlobal.RSGlobal.msgbox(Class16.smethod_0(1649171403));
						}
					}
					if (checkBox_10.Checked)
					{
						decimal value2 = numericUpDown_1.Value;
						ComboBox comboBox3 = comboBox_8;
						ComboBox comboBox4 = comboBox_7;
						if (ClientModifier.PatchTasksLoading(text, (GAMES)comboBox4.SelectedIndex, comboBox3.Text, (int)value2))
						{
							ACE.RSGlobal.RSGlobal.msgbox(Class16.smethod_0(1649171430));
						}
					}
				}
				else
				{
					TextBox textBox = textBox_3;
					TextBox textBox2 = textBox_1;
					Hashtable extraFiles = ExtraFiles;
					PCK_PROTECTION_OPTIONS pCKOptions = PCKOptions;
					ComboBox comboBox5 = comboBox_8;
					ComboBox comboBox6 = comboBox_7;
					if (ClientModifier.ApplyClientPckPatch(text, (GAMES)comboBox6.SelectedIndex, comboBox5.Text, pCKOptions, extraFiles, textBox2.Text, textBox.Text, bUnprotect: false))
					{
						object[] vars = new object[1] { System.IO.Path.GetFileName(text) };
						TextStorage.TEXTS.ShowMessage(629, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
						textBox_0_TextChanged(null, null);
					}
				}
			}
			else
			{
				object[] vars2 = new object[1] { text };
				TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars2);
			}
		}
		else
		{
			TextStorage.TEXTS.ShowErrorMessage(628);
		}
		groupBox_2.Enabled = true;
		GC.KeepAlive(this);
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		string text = textBox_0.Text;
		string text2 = Class16.smethod_0(1649144963);
		string text3 = Class16.smethod_0(1648927580);
		string text4 = string.Concat(string.Concat(System.IO.Path.GetDirectoryName(text) + text3, System.IO.Path.GetFileNameWithoutExtension(text)), text2);
		if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
		{
			if (comboBox_7.SelectedIndex > 0)
			{
				if (!method_19(null))
				{
					return;
				}
				if (!File.Exists(text4) || new FileInfo(text4).Length <= 70L)
				{
					object[] vars = new object[1] { text4 };
					if (TextStorage.TEXTS.ShowMessage(897, MessageBoxButtons.YesNo, MessageBoxIcon.Question, vars) != DialogResult.Yes)
					{
						goto IL_0185;
					}
				}
				TextBox textBox = textBox_3;
				TextBox textBox2 = textBox_1;
				Hashtable extraFiles = ExtraFiles;
				PCK_PROTECTION_OPTIONS pCKOptions = PCKOptions;
				ComboBox comboBox = comboBox_8;
				ComboBox comboBox2 = comboBox_7;
				if (ClientModifier.ApplyClientPckPatch(text, (GAMES)comboBox2.SelectedIndex, comboBox.Text, pCKOptions, extraFiles, textBox2.Text, textBox.Text, bUnprotect: true))
				{
					groupBox_2.Enabled = true;
					object[] vars2 = new object[1] { System.IO.Path.GetFileName(text) };
					TextStorage.TEXTS.ShowMessage(650, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars2);
					textBox_0_TextChanged(null, null);
					goto IL_0221;
				}
			}
			else
			{
				TextStorage.TEXTS.ShowErrorMessage(628);
			}
		}
		else
		{
			object[] vars3 = new object[1] { text };
			TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars3);
		}
		goto IL_0185;
		IL_0221:
		GC.KeepAlive(this);
		return;
		IL_0185:
		try
		{
			string text5 = Class16.smethod_0(1649171446);
			string text6 = string.Concat(System.IO.Path.GetDirectoryName(text) + text5, System.IO.Path.GetFileNameWithoutExtension(text));
			if (Directory.Exists(text6))
			{
				string arguments = Class16.smethod_0(1649170437) + text6;
				ACE.RSGlobal.RSGlobal.ShellP(Class16.smethod_0(1649049928), arguments, waitForExit: false);
			}
			else
			{
				TextStorage.TEXTS.ShowErrorMessage(635);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649172049));
			object[] vars4 = new object[1] { ex.Message };
			TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars4);
		}
		goto IL_0221;
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(textBox_5.Text))
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = Class16.smethod_0(1649170453);
			saveFileDialog.Filter = Class16.smethod_0(1649170463);
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
			{
				string encryptedKey = EncryptedKey;
				File.WriteAllText(saveFileDialog.FileName, encryptedKey, Encoding.ASCII);
				TextStorage.TEXTS.ShowMessage(630, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			}
		}
		GC.KeepAlive(this);
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		string text = textBox_6.Text;
		if (string.IsNullOrWhiteSpace(text))
		{
			GC.KeepAlive(this);
			return;
		}
		if (text.StartsWith(Class16.smethod_0(1648904453)))
		{
			text = text.Replace(Class16.smethod_0(1648904453), string.Empty);
		}
		bool flag = File.Exists(text);
		bool flag2 = Directory.Exists(text);
		string text2 = null;
		if (flag)
		{
			string text3 = Class16.smethod_0(1649171446);
			text2 = string.Concat(System.IO.Path.GetDirectoryName(text) + text3, System.IO.Path.GetFileNameWithoutExtension(text));
		}
		else if (flag2)
		{
			text2 = text + Class16.smethod_0(1649172298);
		}
		if (Directory.Exists(text2))
		{
			string arguments = Class16.smethod_0(1649170437) + text2;
			ACE.RSGlobal.RSGlobal.ShellP(Class16.smethod_0(1649049928), arguments, waitForExit: false);
		}
		else
		{
			TextStorage.TEXTS.ShowErrorMessage(635);
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (panel_0.Visible)
		{
			button_9.Enabled = true;
			GC.KeepAlive(this);
			return;
		}
		string text = textBox_0.Text;
		if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
		{
			ComboBox comboBox = comboBox_8;
			ComboBox comboBox2 = comboBox_7;
			switch (ClientModifier.GetClientProtectionStatus(text, (GAMES)comboBox2.SelectedIndex, comboBox.Text))
			{
			case PROTECTION_STATUS.UNPROTECTED:
			{
				button_9.Enabled = false;
				byte b2 = ((!button_9.Enabled) ? ((byte)1) : ((byte)0));
				button_10.Enabled = b2 != 0;
				break;
			}
			case PROTECTION_STATUS.PROTECTED:
			{
				button_9.Enabled = true;
				byte b = ((!button_9.Enabled) ? ((byte)1) : ((byte)0));
				button_10.Enabled = b != 0;
				break;
			}
			case PROTECTION_STATUS.AVAILABLE:
				button_10.Enabled = true;
				button_9.Enabled = true;
				break;
			}
		}
		else
		{
			button_10.Enabled = false;
			button_9.Enabled = false;
		}
		GC.KeepAlive(this);
	}

	private void comboBox_8_SelectedIndexChanged(object sender, EventArgs e)
	{
		textBox_0_TextChanged(null, null);
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		if (!method_17(textBox_1.Text))
		{
			TextStorage.TEXTS.ShowMessage(652, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			textBox_1.Text = string.Empty;
		}
		GC.KeepAlive(this);
	}

	private void textBox_3_TextChanged(object sender, EventArgs e)
	{
		if (!method_17(textBox_3.Text))
		{
			TextStorage.TEXTS.ShowMessage(652, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
			textBox_3.Text = string.Empty;
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_17(string string_2)
	{
		int num = ((!ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(string_2, Class16.smethod_0(1648909672)) && !ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(string_2, Class16.smethod_0(1648910178))) ? 1 : 0);
		GC.KeepAlive(this);
		return (byte)num != 0;
	}

	private void button_11_Click(object sender, EventArgs e)
	{
		string cleanKey = CleanKey;
		if (textBox_5.Text == cleanKey)
		{
			textBox_5.Text = Class16.smethod_0(1649170505) + EncryptedKey;
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649170515));
			groupBox_2.Text = text;
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649170538));
			button_11.Text = text2;
		}
		else
		{
			textBox_5.Text = CleanKey;
			string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649170561));
			groupBox_2.Text = text3;
			string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649170584));
			button_11.Text = text4;
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_DoubleClick(object sender, EventArgs e)
	{
		if (License.GetFeatureEntitlementsByName(Class16.smethod_0(1648893727)) || LICENSE_INFO.Info.LicenseType == LICENSE_TYPE.DEV)
		{
			panel_0.Visible = true;
			button_10.Enabled = true;
		}
		GC.KeepAlive(this);
	}

	private void numericUpDown_1_ValueChanged(object sender, EventArgs e)
	{
	}

	private void numericUpDown_2_ValueChanged(object sender, EventArgs e)
	{
		numericUpDown_1_ValueChanged(null, null);
	}

	private unsafe Class356 method_18(Class356 class356_0, int int_0, int int_1, GAMES games_0, string string_2)
	{
		class356_0.ProtectionLevel = int_0;
		class356_0.ExtraFilesMask = int_1;
		class356_0.Game = (int)games_0;
		PCK_PROTECTION_SETTINGS pCK_PROTECTION_SETTINGS;
		if (!string.IsNullOrWhiteSpace(string_2) && File.Exists(string_2))
		{
			GAMES gAMES = games_0;
			pCK_PROTECTION_SETTINGS = PCK.GetDefaultSettings(string_2, &gAMES);
			games_0 = gAMES;
		}
		else
		{
			pCK_PROTECTION_SETTINGS = PCK.GetDefaultKeys(games_0);
		}
		if (int_0 < 1)
		{
			int_0 = 1;
		}
		class356_0.MaxLevel = ((class356_0.MaxLevel < int_0) ? int_0 : class356_0.MaxLevel);
		pCK_PROTECTION_SETTINGS.ProtectionLevel = (sbyte)int_0;
		pCK_PROTECTION_SETTINGS.ExtraFilesMask = (byte)int_1;
		pCK_PROTECTION_SETTINGS.KEY_1 = method_5();
		pCK_PROTECTION_SETTINGS.KEY_2 = method_5();
		pCK_PROTECTION_SETTINGS.FTO_KEY = pCK_PROTECTION_SETTINGS.KEY_1;
		int num = Math.Abs(method_5()) % 200;
		pCK_PROTECTION_SETTINGS.MetaDataShift = (ushort)((int_0 >= 4) ? ((uint)(280 + num)) : 280u);
		byte[] structBytes = PCK.GetStructBytes(pCK_PROTECTION_SETTINGS);
		class356_0.CleanKey = Convert.ToBase64String(structBytes);
		class356_0.EncryptedKey = Convert.ToBase64String(method_4(structBytes, class356_0.Name));
		PCKSettings = pCK_PROTECTION_SETTINGS;
		CleanKey = class356_0.CleanKey;
		EncryptedKey = class356_0.EncryptedKey;
		PCKOptions = new PCK_PROTECTION_OPTIONS(PCKSettings, class356_0.Name);
		PCKOptions.Game = games_0;
		method_2();
		return class356_0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_19(string string_2)
	{
		if (comboBox_7.SelectedIndex < 0)
		{
			GC.KeepAlive(this);
			return false;
		}
		if (comboBox_6.SelectedIndex >= 0 && list_0 != null && list_0.Count != 0)
		{
			if (string.IsNullOrWhiteSpace(string_2))
			{
				string[] array = string_0;
				if (array != null && (nint)array.LongLength > 0)
				{
					string_2 = array[0];
				}
				if (string.IsNullOrWhiteSpace(string_2))
				{
					string_2 = textBox_6.Text;
				}
			}
			if (ACE.RSGlobal.RSGlobal.antirecurse_UpdatePckSettings_PCKProtectionWindow)
			{
				return false;
			}
			ACE.RSGlobal.RSGlobal.antirecurse_UpdatePckSettings_PCKProtectionWindow = true;
			bool flag = false;
			try
			{
				int selectedIndex = comboBox_6.SelectedIndex;
				int num = comboBox_0.SelectedIndex + 1;
				int num2 = 0;
				ExtraFiles = new Hashtable();
				if (checkBox_2.Checked)
				{
					num2 = ACE.RSGlobal.RSGlobal.pow(2, 0);
					ExtraFiles.Add(Class16.smethod_0(1649048735), comboBox_1.Text);
				}
				if (checkBox_1.Checked)
				{
					num2 = ACE.RSGlobal.RSGlobal.pow(2, 1) + num2;
					ExtraFiles.Add(Class16.smethod_0(1648906367), comboBox_3.Text);
				}
				if (checkBox_7.Checked)
				{
					num2 = ACE.RSGlobal.RSGlobal.pow(2, 2) + num2;
					ExtraFiles.Add(Class16.smethod_0(1648906382), comboBox_9.Text);
				}
				if (checkBox_5.Checked)
				{
					num2 = ACE.RSGlobal.RSGlobal.pow(2, 3) + num2;
					ExtraFiles.Add(Class16.smethod_0(1648906421), comboBox_5.Text);
				}
				if (checkBox_4.Checked)
				{
					num2 = ACE.RSGlobal.RSGlobal.pow(2, 4) + num2;
					ExtraFiles.Add(Class16.smethod_0(1649175997), comboBox_4.Text);
				}
				if (checkBox_8.Checked)
				{
					num2 = ACE.RSGlobal.RSGlobal.pow(2, 5) + num2;
					ExtraFiles.Add(Class16.smethod_0(1649176015), comboBox_10.Text);
				}
				if (checkBox_3.Checked)
				{
					num2 = ACE.RSGlobal.RSGlobal.pow(2, 6) + num2;
					ExtraFiles.Add(Class16.smethod_0(1648906425), comboBox_2.Text);
				}
				GAMES selectedIndex2 = (GAMES)comboBox_7.SelectedIndex;
				Class356 @class = list_0[selectedIndex];
				if (string.IsNullOrWhiteSpace(@class.EncryptedKey) || string.IsNullOrWhiteSpace(@class.CleanKey) || @class.ProtectionLevel != num || @class.ExtraFilesMask != num2 || @class.Game != (int)selectedIndex2)
				{
					@class = method_18(@class, num, num2, selectedIndex2, string_2);
					list_0[selectedIndex] = @class;
				}
				else
				{
					PCKSettings = PCK_PROTECTION_SETTINGS.Deserialize(@class.EncryptedKey, @class.Name);
					CleanKey = @class.CleanKey;
					EncryptedKey = @class.EncryptedKey;
					PCKOptions = new PCK_PROTECTION_OPTIONS(PCKSettings, @class.Name);
					PCKOptions.Game = selectedIndex2;
				}
				string text = (CleanKey = PCK_PROTECTION_SETTINGS.DecryptKey(EncryptedKey, @class.Name));
				textBox_5.Text = text;
				groupBox_2.Text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649170561));
				flag = true;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649170615));
				if (ex.GetType() == typeof(ApplicationException))
				{
					object[] vars = new object[1] { ex.Message };
					TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
				}
				else
				{
					string text2 = Class16.smethod_0(1648934564) + ex.Message + Class16.smethod_0(1648934582) + ex.StackTrace + Class16.smethod_0(1648934604);
					foreach (DictionaryEntry datum in ex.Data)
					{
						text2 += string.Format(Class16.smethod_0(1648934622), datum.Key, datum.Value);
					}
					DKBox.Show(text2, Class16.smethod_0(1649170651), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				flag = false;
			}
			ACE.RSGlobal.RSGlobal.antirecurse_UpdatePckSettings_PCKProtectionWindow = false;
			GC.KeepAlive(this);
			return flag;
		}
		GC.KeepAlive(this);
		return false;
	}
}
