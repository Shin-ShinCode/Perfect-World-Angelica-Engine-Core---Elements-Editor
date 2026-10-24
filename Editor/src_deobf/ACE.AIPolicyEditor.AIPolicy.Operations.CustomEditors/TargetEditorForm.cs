using System;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class TargetEditorForm : Form
{
	private sealed class Class33
	{
		private EnumTarget enumTarget_0;

		private string string_0;

		public EnumTarget method_0()
		{
			return enumTarget_0;
		}

		public void method_1(EnumTarget enumTarget_1)
		{
			enumTarget_0 = enumTarget_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_1)
		{
			string_0 = string_1;
		}

		public override string ToString()
		{
			return method_2();
		}
	}

	private ComboBox comboBox_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private TextBox textBox_4;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	private TargetParam targetParam_0;

	public TargetParam Result => targetParam_0;

	public TargetEditorForm(TargetParam param)
	{
		targetParam_0 = (TargetParam)param.Clone();
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyThemeToForm(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		method_1();
	}

	private void method_0()
	{
		Text = Class16.smethod_0(1648938844);
		base.Size = new Size(400, 290);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.StartPosition = FormStartPosition.CenterParent;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		label_0 = new Label
		{
			Text = Class16.smethod_0(1648938856),
			Location = new Point(10, 15),
			AutoSize = true
		};
		comboBox_0 = new ComboBox
		{
			Location = new Point(100, 12),
			Width = 270,
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		label_1 = new Label
		{
			Text = Class16.smethod_0(1648938878),
			Location = new Point(10, 50),
			AutoSize = true
		};
		textBox_0 = new TextBox
		{
			Location = new Point(100, 47),
			Width = 180,
			ReadOnly = true
		};
		label_2 = new Label
		{
			Location = new Point(10, 82),
			AutoSize = true
		};
		textBox_1 = new TextBox
		{
			Location = new Point(100, 79),
			Width = 270
		};
		label_3 = new Label
		{
			Location = new Point(10, 114),
			AutoSize = true
		};
		textBox_2 = new TextBox
		{
			Location = new Point(100, 111),
			Width = 270
		};
		label_4 = new Label
		{
			Location = new Point(10, 146),
			AutoSize = true
		};
		textBox_3 = new TextBox
		{
			Location = new Point(100, 143),
			Width = 270
		};
		label_5 = new Label
		{
			Location = new Point(10, 178),
			AutoSize = true
		};
		textBox_4 = new TextBox
		{
			Location = new Point(100, 175),
			Width = 270
		};
		button_0 = new Button
		{
			Text = Class16.smethod_0(1648938889),
			Location = new Point(290, 45),
			Width = 80
		};
		button_0.Click += button_0_Click;
		button_1 = new Button
		{
			Text = Class16.smethod_0(1648938905),
			Location = new Point(210, 215),
			Width = 80,
			DialogResult = DialogResult.OK
		};
		button_1.Click += button_1_Click;
		button_2 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			Location = new Point(300, 215),
			Width = 80,
			DialogResult = DialogResult.Cancel
		};
		base.Controls.AddRange(new Control[15]
		{
			label_0, comboBox_0, label_1, textBox_0, button_0, label_2, textBox_1, label_3, textBox_2, label_4,
			textBox_3, label_5, textBox_4, button_1, button_2
		});
		base.AcceptButton = button_1;
		base.CancelButton = button_2;
	}

	private void method_1()
	{
		foreach (EnumTarget value in Enum.GetValues(typeof(EnumTarget)))
		{
			if (value != EnumTarget.t_num)
			{
				string string_ = MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938914) + value) ?? value.ToString();
				ComboBox.ObjectCollection items = comboBox_0.Items;
				Class33 @class = new Class33();
				@class.method_1(value);
				@class.method_3(string_);
				items.Add(@class);
			}
		}
		for (int i = 0; i < comboBox_0.Items.Count; i++)
		{
			if (((Class33)comboBox_0.Items[i]).method_0() == targetParam_0.Target)
			{
				comboBox_0.SelectedIndex = i;
				break;
			}
		}
		textBox_0.Text = targetParam_0.Occupations.ToString();
		method_2();
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedItem is Class33 @class)
		{
			targetParam_0.Target = @class.method_0();
			method_2();
		}
	}

	private void method_2()
	{
		bool visible = targetParam_0.Target == EnumTarget.occupation_list;
		label_1.Visible = visible;
		textBox_0.Visible = visible;
		button_0.Visible = visible;
		bool flag = targetParam_0.Target == EnumTarget.t_random_in_range || targetParam_0.Target == EnumTarget.t_nearest_in_range || targetParam_0.Target == EnumTarget.t_farthest_in_range;
		bool flag2 = targetParam_0.Target == EnumTarget.unk_18;
		bool flag3 = targetParam_0.Target == EnumTarget.unk_20;
		smethod_0(label_2, textBox_1, flag || flag2 || flag3, flag ? Class16.smethod_0(1648938938) : Class16.smethod_0(1648938923), targetParam_0.Players);
		smethod_0(label_3, textBox_2, flag2 || flag3, Class16.smethod_0(1648938959), targetParam_0.Unk2);
		smethod_0(label_4, textBox_3, flag2 || flag3, Class16.smethod_0(1648938963), targetParam_0.Unk3);
		smethod_0(label_5, textBox_4, flag3, Class16.smethod_0(1648938983), targetParam_0.Unk4);
	}

	private static void smethod_0(Label label_6, TextBox textBox_5, bool bool_0, string string_0, uint uint_0)
	{
		label_6.Visible = bool_0;
		textBox_5.Visible = bool_0;
		if (bool_0)
		{
			label_6.Text = string_0;
			textBox_5.Text = uint_0.ToString();
		}
	}

	private static uint smethod_1(TextBox textBox_5, uint uint_0)
	{
		if (!uint.TryParse(textBox_5.Text, out var result))
		{
			return uint_0;
		}
		return result;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		MasksEditorForm masksEditorForm = new MasksEditorForm((int)targetParam_0.Occupations);
		try
		{
			masksEditorForm.ChangeValue += method_3;
			masksEditorForm.ShowDialog();
		}
		finally
		{
			((IDisposable)masksEditorForm).Dispose();
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (targetParam_0.Target == EnumTarget.t_random_in_range || targetParam_0.Target == EnumTarget.t_nearest_in_range || targetParam_0.Target == EnumTarget.t_farthest_in_range || targetParam_0.Target == EnumTarget.unk_18 || targetParam_0.Target == EnumTarget.unk_20)
		{
			targetParam_0.Players = smethod_1(textBox_1, targetParam_0.Players);
		}
		if (targetParam_0.Target == EnumTarget.unk_18 || targetParam_0.Target == EnumTarget.unk_20)
		{
			targetParam_0.Unk2 = smethod_1(textBox_2, targetParam_0.Unk2);
			targetParam_0.Unk3 = smethod_1(textBox_3, targetParam_0.Unk3);
		}
		if (targetParam_0.Target == EnumTarget.unk_20)
		{
			targetParam_0.Unk4 = smethod_1(textBox_4, targetParam_0.Unk4);
		}
		base.DialogResult = DialogResult.OK;
	}

	private void method_3(int int_0)
	{
		targetParam_0.Occupations = (uint)int_0;
		textBox_0.Text = int_0.ToString();
	}
}
