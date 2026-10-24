using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ACE.NpcGen.Import;

public sealed class CoordDataImportDialog : Form
{
	[Serializable]
	private sealed class Class248
	{
		public static readonly Class248 class248_0 = new Class248();

		public static Func<string, string> func_0;

		internal string method_0(string string_0)
		{
			return string_0;
		}
	}

	private readonly ComboBox comboBox_0;

	private readonly CheckBox checkBox_0;

	private readonly CheckBox checkBox_1;

	private readonly NumericUpDown numericUpDown_0;

	private readonly Label label_0;

	public string SelectedMapId
	{
		get
		{
			object selectedItem = comboBox_0.SelectedItem;
			object obj;
			if (selectedItem == null)
			{
				obj = null;
			}
			else
			{
				obj = selectedItem.ToString();
				if (obj != null)
				{
					goto IL_0020;
				}
			}
			obj = string.Empty;
			goto IL_0020;
			IL_0020:
			return (string)obj;
		}
	}

	public bool IgnoreDuplicates => checkBox_0.Checked;

	public bool ConsiderNearCoordinates
	{
		get
		{
			if (checkBox_0.Checked)
			{
				return checkBox_1.Checked;
			}
			return false;
		}
	}

	public float NearDistance => Convert.ToSingle(numericUpDown_0.Value);

	public CoordDataImportDialog(IReadOnlyCollection<string> fileNames, IReadOnlyCollection<string> availableMaps, string detectedMap)
	{
		Text = Class16.smethod_0(1649119022);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.StartPosition = FormStartPosition.CenterParent;
		base.ShowInTaskbar = false;
		base.ShowIcon = false;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.ClientSize = new Size(470, 240);
		Label value = new Label
		{
			AutoSize = false,
			Location = new Point(12, 12),
			Size = new Size(446, 42),
			Text = smethod_0(fileNames)
		};
		label_0 = new Label
		{
			AutoSize = false,
			Location = new Point(12, 58),
			Size = new Size(446, 18),
			Text = (string.IsNullOrWhiteSpace(detectedMap) ? Class16.smethod_0(1649119067) : (Class16.smethod_0(1649119046) + detectedMap))
		};
		Label value2 = new Label
		{
			AutoSize = true,
			Location = new Point(12, 87),
			Text = Class16.smethod_0(1649119151)
		};
		comboBox_0 = new ComboBox
		{
			DropDownStyle = ComboBoxStyle.DropDownList,
			Location = new Point(80, 83),
			Size = new Size(180, 21)
		};
		foreach (string item in (availableMaps ?? Array.Empty<string>()).OrderBy(Class248.class248_0.method_0, StringComparer.OrdinalIgnoreCase))
		{
			comboBox_0.Items.Add(item);
		}
		if (!string.IsNullOrWhiteSpace(detectedMap))
		{
			int num = comboBox_0.FindStringExact(detectedMap);
			if (num >= 0)
			{
				comboBox_0.SelectedIndex = num;
			}
		}
		if (comboBox_0.SelectedIndex < 0 && comboBox_0.Items.Count > 0)
		{
			comboBox_0.SelectedIndex = 0;
		}
		checkBox_0 = new CheckBox
		{
			AutoSize = true,
			Location = new Point(15, 122),
			Text = Class16.smethod_0(1649119154),
			Checked = true
		};
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		checkBox_1 = new CheckBox
		{
			AutoSize = true,
			Location = new Point(34, 148),
			Text = Class16.smethod_0(1649119200),
			Checked = false
		};
		checkBox_1.CheckedChanged += checkBox_1_CheckedChanged;
		Label value3 = new Label
		{
			AutoSize = true,
			Location = new Point(52, 177),
			Text = Class16.smethod_0(1649118225)
		};
		numericUpDown_0 = new NumericUpDown
		{
			DecimalPlaces = 2,
			Increment = 1m,
			Minimum = 0m,
			Maximum = 10000m,
			Value = 5m,
			Location = new Point(145, 173),
			Size = new Size(82, 20)
		};
		Button button = new Button
		{
			Text = Class16.smethod_0(1648931405),
			DialogResult = DialogResult.OK,
			Location = new Point(270, 202),
			Size = new Size(90, 28)
		};
		Button button2 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			DialogResult = DialogResult.Cancel,
			Location = new Point(368, 202),
			Size = new Size(90, 28)
		};
		base.Controls.Add(value);
		base.Controls.Add(label_0);
		base.Controls.Add(value2);
		base.Controls.Add(comboBox_0);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(checkBox_1);
		base.Controls.Add(value3);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(button);
		base.Controls.Add(button2);
		base.AcceptButton = button;
		base.CancelButton = button2;
		method_0();
	}

	private static string smethod_0(IReadOnlyCollection<string> ireadOnlyCollection_0)
	{
		if (ireadOnlyCollection_0 != null && ireadOnlyCollection_0.Count != 0)
		{
			string text = string.Join(Class16.smethod_0(1648942920), ireadOnlyCollection_0);
			return Class16.smethod_0(1649118325) + text;
		}
		return Class16.smethod_0(1649118254);
	}

	private void method_0()
	{
		bool enabled = checkBox_0.Checked && checkBox_1.Checked;
		checkBox_1.Enabled = checkBox_0.Checked;
		numericUpDown_0.Enabled = enabled;
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		method_0();
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		method_0();
	}
}
