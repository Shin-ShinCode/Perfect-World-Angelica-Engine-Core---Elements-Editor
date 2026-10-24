using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.PWMap;

public sealed class PwMapExportServerDialog : Form
{
	private bool bool_0 = true;

	private bool bool_1 = true;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private bool bool_4 = true;

	private bool bool_5 = true;

	private bool bool_6 = true;

	private bool bool_7 = true;

	private bool bool_8 = true;

	private bool bool_9;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private CheckBox checkBox_5;

	private CheckBox checkBox_6;

	private CheckBox checkBox_7;

	private CheckBox checkBox_8;

	private CheckBox checkBox_9;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private bool bool_10;

	public bool ExportHmap
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
	}

	public bool ExportWmap
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
	}

	public bool ExportBht
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
	}

	public bool ExportAirmap
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
	}

	public bool ExportPrecinct
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
	}

	public bool ExportRegion
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
	}

	public bool ExportWaterConf
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
	}

	public bool ExportPassmap
	{
		[CompilerGenerated]
		get
		{
			return bool_7;
		}
	}

	public bool ExportDhmap
	{
		[CompilerGenerated]
		get
		{
			return bool_8;
		}
	}

	public bool ExportCurrentSectorOnly
	{
		[CompilerGenerated]
		get
		{
			return bool_9;
		}
	}

	public PwMapExportServerDialog()
	{
		Text = Class16.smethod_0(1649086805);
		base.Size = new Size(340, 430);
		base.StartPosition = FormStartPosition.CenterParent;
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.ShowInTaskbar = false;
		method_11();
		method_10();
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0(bool bool_11)
	{
		bool_0 = bool_11;
	}

	private void method_1(bool bool_11)
	{
		bool_1 = bool_11;
	}

	private void method_2(bool bool_11)
	{
		bool_2 = bool_11;
	}

	private void method_3(bool bool_11)
	{
		bool_3 = bool_11;
	}

	private void method_4(bool bool_11)
	{
		bool_4 = bool_11;
	}

	private void method_5(bool bool_11)
	{
		bool_5 = bool_11;
	}

	private void method_6(bool bool_11)
	{
		bool_6 = bool_11;
	}

	private void method_7(bool bool_11)
	{
		bool_7 = bool_11;
	}

	private void method_8(bool bool_11)
	{
		bool_8 = bool_11;
	}

	private void method_9(bool bool_11)
	{
		bool_9 = bool_11;
	}

	private void method_10()
	{
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
	}

	private void method_11()
	{
		int num = 12;
		GroupBox groupBox = new GroupBox
		{
			Text = Class16.smethod_0(1649086825),
			Location = new Point(18, 12),
			Size = new Size(base.ClientSize.Width - 36, 248)
		};
		base.Controls.Add(groupBox);
		int int_ = 22;
		checkBox_9 = smethod_0(Class16.smethod_0(1648973290), bool_11: true, 18, ref int_, groupBox);
		checkBox_9.Font = new Font(checkBox_9.Font, FontStyle.Bold);
		checkBox_9.CheckedChanged += checkBox_9_CheckedChanged;
		int_ += 4;
		checkBox_0 = smethod_0(Class16.smethod_0(1649086854), bool_11: true, 18, ref int_, groupBox);
		checkBox_1 = smethod_0(Class16.smethod_0(1649086879), bool_11: true, 18, ref int_, groupBox);
		checkBox_2 = smethod_0(Class16.smethod_0(1649086903), bool_11: true, 18, ref int_, groupBox);
		checkBox_3 = smethod_0(Class16.smethod_0(1649086925), bool_11: true, 18, ref int_, groupBox);
		checkBox_4 = smethod_0(Class16.smethod_0(1649086950), bool_11: true, 18, ref int_, groupBox);
		checkBox_5 = smethod_0(Class16.smethod_0(1649086961), bool_11: true, 18, ref int_, groupBox);
		checkBox_6 = smethod_0(Class16.smethod_0(1649090050), bool_11: true, 18, ref int_, groupBox);
		checkBox_7 = smethod_0(Class16.smethod_0(1649090078), bool_11: true, 18, ref int_, groupBox);
		checkBox_8 = smethod_0(Class16.smethod_0(1649090102), bool_11: true, 18, ref int_, groupBox);
		CheckBox[] array = new CheckBox[9] { checkBox_0, checkBox_1, checkBox_2, checkBox_3, checkBox_4, checkBox_5, checkBox_6, checkBox_7, checkBox_8 };
		foreach (CheckBox checkBox in array)
		{
			checkBox.CheckedChanged += method_12;
		}
		num += groupBox.Height + 8;
		GroupBox groupBox2 = new GroupBox
		{
			Text = Class16.smethod_0(1649090128),
			Location = new Point(18, num),
			Size = new Size(base.ClientSize.Width - 36, 55)
		};
		base.Controls.Add(groupBox2);
		radioButton_0 = new RadioButton
		{
			Text = Class16.smethod_0(1649090148),
			Location = new Point(14, 22),
			AutoSize = true,
			Checked = true
		};
		radioButton_1 = new RadioButton
		{
			Text = Class16.smethod_0(1649090173),
			Location = new Point(170, 22),
			AutoSize = true
		};
		groupBox2.Controls.AddRange(new Control[2] { radioButton_0, radioButton_1 });
		num += groupBox2.Height + 14;
		Button button = new Button
		{
			Text = Class16.smethod_0(1648931384),
			Width = 90,
			Height = 28,
			Location = new Point(base.ClientSize.Width / 2 - 100, num),
			DialogResult = DialogResult.OK
		};
		button.Click += method_14;
		Button button2 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			Width = 90,
			Height = 28,
			Location = new Point(base.ClientSize.Width / 2 + 10, num),
			DialogResult = DialogResult.Cancel
		};
		base.Controls.AddRange(new Control[2] { button, button2 });
		base.AcceptButton = button;
		base.CancelButton = button2;
	}

	private void checkBox_9_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_10)
		{
			bool_10 = true;
			bool flag = checkBox_9.Checked;
			checkBox_0.Checked = flag;
			checkBox_1.Checked = flag;
			checkBox_2.Checked = flag;
			checkBox_3.Checked = flag;
			checkBox_4.Checked = flag;
			checkBox_5.Checked = flag;
			checkBox_6.Checked = flag;
			checkBox_7.Checked = flag;
			checkBox_8.Checked = flag;
			bool_10 = false;
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		if (!bool_10)
		{
			bool_10 = true;
			bool flag = checkBox_0.Checked && checkBox_1.Checked && checkBox_2.Checked && checkBox_3.Checked && checkBox_4.Checked && checkBox_5.Checked && checkBox_6.Checked && checkBox_7.Checked && checkBox_8.Checked;
			checkBox_9.Checked = flag;
			bool_10 = false;
		}
	}

	private void method_13()
	{
		method_0(checkBox_0.Checked);
		method_1(checkBox_1.Checked);
		method_2(checkBox_2.Checked);
		method_3(checkBox_3.Checked);
		method_4(checkBox_4.Checked);
		method_5(checkBox_5.Checked);
		method_6(checkBox_6.Checked);
		method_7(checkBox_7.Checked);
		method_8(checkBox_8.Checked);
		method_9(radioButton_1.Checked);
	}

	private static CheckBox smethod_0(string string_0, bool bool_11, int int_0, ref int int_1, Control control_0)
	{
		CheckBox checkBox = new CheckBox
		{
			Text = string_0,
			Checked = bool_11,
			Location = new Point(int_0, int_1),
			AutoSize = true
		};
		control_0.Controls.Add(checkBox);
		int_1 += 22;
		return checkBox;
	}

	private void method_14(object sender, EventArgs e)
	{
		method_13();
	}
}
