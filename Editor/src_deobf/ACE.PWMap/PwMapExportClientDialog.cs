using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.PWMap;

public sealed class PwMapExportClientDialog : Form
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

	private string string_0 = string.Empty;

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

	private TextBox textBox_0;

	public bool ExportTerrainTextures
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
	}

	public bool ExportT2mk
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
	}

	public bool ExportT2lm
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
	}

	public bool ExportLitModels
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
	}

	public bool ExportGfx
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
	}

	public bool ExportEcm
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
	}

	public bool ExportLodData
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
	}

	public bool ExportSurfaces
	{
		[CompilerGenerated]
		get
		{
			return bool_7;
		}
	}

	public bool ExportCltTiles
	{
		[CompilerGenerated]
		get
		{
			return bool_8;
		}
	}

	public bool ConvertToPwi
	{
		[CompilerGenerated]
		get
		{
			return bool_9;
		}
	}

	public string BmdTexturePath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public PwMapExportClientDialog()
	{
		Text = Class16.smethod_0(1649086479);
		base.Size = new Size(380, 440);
		base.StartPosition = FormStartPosition.CenterParent;
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.ShowInTaskbar = false;
		method_12();
		method_11();
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0(bool bool_10)
	{
		bool_0 = bool_10;
	}

	private void method_1(bool bool_10)
	{
		bool_1 = bool_10;
	}

	private void method_2(bool bool_10)
	{
		bool_2 = bool_10;
	}

	private void method_3(bool bool_10)
	{
		bool_3 = bool_10;
	}

	private void method_4(bool bool_10)
	{
		bool_4 = bool_10;
	}

	private void method_5(bool bool_10)
	{
		bool_5 = bool_10;
	}

	private void method_6(bool bool_10)
	{
		bool_6 = bool_10;
	}

	private void method_7(bool bool_10)
	{
		bool_7 = bool_10;
	}

	private void method_8(bool bool_10)
	{
		bool_8 = bool_10;
	}

	private void method_9(bool bool_10)
	{
		bool_9 = bool_10;
	}

	private void method_10(string string_1)
	{
		string_0 = string_1;
	}

	private void method_11()
	{
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
	}

	private void method_12()
	{
		int num = 12;
		GroupBox groupBox = new GroupBox
		{
			Text = Class16.smethod_0(1649086499),
			Location = new Point(16, 12),
			Size = new Size(base.ClientSize.Width - 32, 250)
		};
		base.Controls.Add(groupBox);
		int int_ = 22;
		checkBox_0 = smethod_0(Class16.smethod_0(1649086529), bool_10: true, 14, ref int_, groupBox);
		checkBox_1 = smethod_0(Class16.smethod_0(1649086552), bool_10: true, 14, ref int_, groupBox);
		checkBox_2 = smethod_0(Class16.smethod_0(1649086579), bool_10: true, 14, ref int_, groupBox);
		checkBox_3 = smethod_0(Class16.smethod_0(1649086610), bool_10: true, 14, ref int_, groupBox);
		checkBox_4 = smethod_0(Class16.smethod_0(1649086632), bool_10: true, 14, ref int_, groupBox);
		checkBox_5 = smethod_0(Class16.smethod_0(1649086650), bool_10: true, 14, ref int_, groupBox);
		checkBox_6 = smethod_0(Class16.smethod_0(1649086679), bool_10: true, 14, ref int_, groupBox);
		checkBox_7 = smethod_0(Class16.smethod_0(1649086694), bool_10: true, 14, ref int_, groupBox);
		checkBox_8 = smethod_0(Class16.smethod_0(1649086709), bool_10: true, 14, ref int_, groupBox);
		checkBox_9 = smethod_0(Class16.smethod_0(1649086725), bool_10: false, 14, ref int_, groupBox);
		num = 12 + (groupBox.Height + 10);
		GroupBox groupBox2 = new GroupBox
		{
			Text = Class16.smethod_0(1649086745),
			Location = new Point(16, num),
			Size = new Size(base.ClientSize.Width - 32, 54)
		};
		base.Controls.Add(groupBox2);
		textBox_0 = new TextBox
		{
			Location = new Point(12, 22),
			Width = groupBox2.Width - 90,
			Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)
		};
		groupBox2.Controls.Add(textBox_0);
		Button button = new Button
		{
			Text = Class16.smethod_0(1648924410),
			Width = 30,
			Location = new Point(groupBox2.Width - 68, 21),
			Anchor = (AnchorStyles.Top | AnchorStyles.Right)
		};
		button.Click += method_14;
		groupBox2.Controls.Add(button);
		num += groupBox2.Height + 16;
		Button button2 = new Button
		{
			Text = Class16.smethod_0(1648931384),
			Width = 90,
			Height = 28,
			Location = new Point(base.ClientSize.Width / 2 - 100, num),
			DialogResult = DialogResult.OK
		};
		button2.Click += method_15;
		Button button3 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			Width = 90,
			Height = 28,
			Location = new Point(base.ClientSize.Width / 2 + 10, num),
			DialogResult = DialogResult.Cancel
		};
		base.Controls.AddRange(new Control[2] { button2, button3 });
		base.AcceptButton = button2;
		base.CancelButton = button3;
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
		method_9(checkBox_9.Checked);
		method_10(textBox_0.Text.Trim());
	}

	private static CheckBox smethod_0(string string_1, bool bool_10, int int_0, ref int int_1, Control control_0)
	{
		CheckBox checkBox = new CheckBox
		{
			Text = string_1,
			Checked = bool_10,
			Location = new Point(int_0, int_1),
			AutoSize = true
		};
		control_0.Controls.Add(checkBox);
		int_1 += 22;
		return checkBox;
	}

	private void method_14(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		try
		{
			folderBrowserDialog.Description = TextStorage.Msg(Class16.smethod_0(1649086768), Class16.smethod_0(1649086745));
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				textBox_0.Text = folderBrowserDialog.SelectedPath;
			}
		}
		finally
		{
			((IDisposable)folderBrowserDialog).Dispose();
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		method_13();
	}
}
