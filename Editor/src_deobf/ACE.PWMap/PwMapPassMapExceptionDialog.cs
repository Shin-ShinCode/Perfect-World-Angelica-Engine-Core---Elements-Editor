using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.PWMap;

public sealed class PwMapPassMapExceptionDialog : Form
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private bool bool_4 = true;

	private bool bool_5;

	private bool bool_6;

	private int int_0 = 1;

	private Label label_0;

	private Label label_1;

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

	private ComboBox comboBox_0;

	private CheckBox checkBox_0;

	public bool Omit
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
	}

	public bool Force
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
	}

	public bool AllLevels
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
	}

	public bool AllPositions
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
	}

	public bool AnyModel
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
	}

	public bool AnyMesh
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
	}

	public bool FlipRmap
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
	}

	public int ExceptionSize
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
	}

	public PwMapPassMapExceptionDialog()
	{
		Text = Class16.smethod_0(1649089964);
		base.Size = new Size(380, 440);
		base.StartPosition = FormStartPosition.CenterParent;
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.ShowInTaskbar = false;
		method_9();
		method_8();
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0(bool bool_7)
	{
		bool_0 = bool_7;
	}

	private void method_1(bool bool_7)
	{
		bool_1 = bool_7;
	}

	private void method_2(bool bool_7)
	{
		bool_2 = bool_7;
	}

	private void method_3(bool bool_7)
	{
		bool_3 = bool_7;
	}

	private void method_4(bool bool_7)
	{
		bool_4 = bool_7;
	}

	private void method_5(bool bool_7)
	{
		bool_5 = bool_7;
	}

	private void method_6(bool bool_7)
	{
		bool_6 = bool_7;
	}

	private void method_7(int int_1)
	{
		int_0 = int_1;
	}

	private void method_8()
	{
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
	}

	private void method_9()
	{
		int int_ = 12;
		GroupBox groupBox = method_11(Class16.smethod_0(1649089988), 14, ref int_, 60);
		label_0 = new Label
		{
			Text = Class16.smethod_0(1649090007),
			Location = new Point(10, 20),
			AutoSize = true
		};
		label_1 = new Label
		{
			Text = Class16.smethod_0(1649090021),
			Location = new Point(10, 38),
			AutoSize = true
		};
		groupBox.Controls.AddRange(new Control[2] { label_0, label_1 });
		GroupBox control_ = method_11(Class16.smethod_0(1649090026), 14, ref int_, 62);
		radioButton_0 = smethod_0(Class16.smethod_0(1649090043), 10, 18, control_, bool_7: true);
		radioButton_1 = smethod_0(Class16.smethod_0(1649089035), 120, 18, control_, bool_7: false);
		radioButton_2 = smethod_0(Class16.smethod_0(1649089060), 230, 18, control_, bool_7: false);
		GroupBox control_2 = method_11(Class16.smethod_0(1648886228), 14, ref int_, 50);
		radioButton_3 = smethod_0(Class16.smethod_0(1649089076), 10, 18, control_2, bool_7: false);
		radioButton_4 = smethod_0(Class16.smethod_0(1649089089), 150, 18, control_2, bool_7: true);
		GroupBox control_3 = method_11(Class16.smethod_0(1648893587), 14, ref int_, 50);
		radioButton_5 = smethod_0(Class16.smethod_0(1649089106), 10, 18, control_3, bool_7: false);
		radioButton_6 = smethod_0(Class16.smethod_0(1649089130), 170, 18, control_3, bool_7: true);
		GroupBox control_4 = method_11(Class16.smethod_0(1648930017), 14, ref int_, 50);
		radioButton_7 = smethod_0(Class16.smethod_0(1649089158), 10, 18, control_4, bool_7: true);
		radioButton_8 = smethod_0(Class16.smethod_0(1649089161), 100, 18, control_4, bool_7: false);
		radioButton_9 = smethod_0(Class16.smethod_0(1648924120), 180, 18, control_4, bool_7: false);
		GroupBox groupBox2 = method_11(Class16.smethod_0(1649089171), 14, ref int_, 60);
		Label value = new Label
		{
			Text = Class16.smethod_0(1648989928),
			Location = new Point(10, 22),
			AutoSize = true
		};
		groupBox2.Controls.Add(value);
		comboBox_0 = new ComboBox
		{
			DropDownStyle = ComboBoxStyle.DropDownList,
			Location = new Point(55, 19),
			Width = 60
		};
		comboBox_0.Items.AddRange(new object[6]
		{
			Class16.smethod_0(1648934925),
			Class16.smethod_0(1648911557),
			Class16.smethod_0(1648911820),
			Class16.smethod_0(1648910977),
			Class16.smethod_0(1648911318),
			Class16.smethod_0(1648911285)
		});
		comboBox_0.SelectedIndex = 0;
		groupBox2.Controls.Add(comboBox_0);
		checkBox_0 = new CheckBox
		{
			Text = Class16.smethod_0(1649089192),
			Location = new Point(140, 21),
			AutoSize = true
		};
		groupBox2.Controls.Add(checkBox_0);
		int_ += 8;
		Button button = new Button
		{
			Text = Class16.smethod_0(1648938905),
			Width = 80,
			Location = new Point(base.ClientSize.Width / 2 - 90, int_),
			DialogResult = DialogResult.OK
		};
		button.Click += method_12;
		Button button2 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			Width = 80,
			Location = new Point(base.ClientSize.Width / 2 + 10, int_),
			DialogResult = DialogResult.Cancel
		};
		base.Controls.Add(button);
		base.Controls.Add(button2);
		base.AcceptButton = button;
		base.CancelButton = button2;
	}

	public void LoadFrom(string modelName, string meshName, bool omit, bool force, bool allLevels, bool allPositions, bool anyModel, bool anyMesh, bool flipRmap, int size)
	{
		label_0.Text = modelName;
		label_1.Text = meshName;
		radioButton_7.Checked = omit;
		radioButton_8.Checked = force;
		radioButton_9.Checked = !omit && !force;
		radioButton_4.Checked = allLevels;
		radioButton_3.Checked = !allLevels;
		radioButton_6.Checked = allPositions;
		radioButton_5.Checked = !allPositions;
		radioButton_0.Checked = anyModel;
		radioButton_1.Checked = !anyModel && anyMesh;
		radioButton_2.Checked = !anyModel && !anyMesh;
		checkBox_0.Checked = flipRmap;
		smethod_1(comboBox_0, size.ToString());
	}

	private void method_10()
	{
		method_0(radioButton_7.Checked);
		method_1(radioButton_8.Checked);
		method_2(radioButton_4.Checked);
		method_3(radioButton_6.Checked);
		method_4(radioButton_0.Checked);
		method_5(radioButton_1.Checked);
		method_6(checkBox_0.Checked);
		int.TryParse(comboBox_0.SelectedItem?.ToString(), out var result);
		method_7((result <= 0) ? 1 : result);
	}

	private GroupBox method_11(string string_0, int int_1, ref int int_2, int int_3)
	{
		GroupBox groupBox = new GroupBox
		{
			Text = string_0,
			Location = new Point(int_1, int_2),
			Size = new Size(base.ClientSize.Width - int_1 * 2, int_3)
		};
		base.Controls.Add(groupBox);
		int_2 += int_3 + 6;
		return groupBox;
	}

	private static RadioButton smethod_0(string string_0, int int_1, int int_2, Control control_0, bool bool_7)
	{
		RadioButton radioButton = new RadioButton
		{
			Text = string_0,
			Location = new Point(int_1, int_2),
			AutoSize = true,
			Checked = bool_7
		};
		control_0.Controls.Add(radioButton);
		return radioButton;
	}

	private static void smethod_1(ComboBox comboBox_1, string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < comboBox_1.Items.Count)
			{
				if (comboBox_1.Items[num].ToString() == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		comboBox_1.SelectedIndex = num;
	}

	private void method_12(object sender, EventArgs e)
	{
		method_10();
	}
}
