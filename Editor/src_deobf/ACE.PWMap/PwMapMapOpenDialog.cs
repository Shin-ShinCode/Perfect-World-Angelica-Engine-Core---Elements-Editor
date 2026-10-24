using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.PWMap;

public sealed class PwMapMapOpenDialog : Form
{
	private sealed class Class296
	{
		private readonly string string_0;

		private readonly string string_1;

		public Class296(string string_2, string string_3)
		{
			string_0 = string_2;
			string_1 = string_3;
		}

		public string method_0()
		{
			return string_0;
		}

		public string method_1()
		{
			return string_1;
		}

		public override string ToString()
		{
			return method_0();
		}
	}

	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private Label label_0;

	private ComboBox comboBox_0;

	private Button button_0;

	private Button button_1;

	private Label label_1;

	private readonly List<Class296> list_0 = new List<Class296>();

	public string SelectedMapPath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public string SelectedMapName
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
	}

	public PwMapMapOpenDialog()
	{
		Text = Class16.smethod_0(1649089554);
		base.Size = new Size(380, 200);
		base.StartPosition = FormStartPosition.CenterParent;
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.ShowInTaskbar = false;
		method_3();
		method_2();
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0(string string_2)
	{
		string_0 = string_2;
	}

	private void method_1(string string_2)
	{
		string_1 = string_2;
	}

	private void method_2()
	{
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
	}

	private void method_3()
	{
		label_0 = new Label
		{
			Text = Class16.smethod_0(1649089569),
			Location = new Point(14, 16),
			AutoSize = true,
			Font = new Font(Font.FontFamily, 9f, FontStyle.Regular)
		};
		base.Controls.Add(label_0);
		comboBox_0 = new ComboBox
		{
			DropDownStyle = ComboBoxStyle.DropDownList,
			Location = new Point(14, 40),
			Width = 340,
			MaxDropDownItems = 12,
			Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)
		};
		base.Controls.Add(comboBox_0);
		label_1 = new Label
		{
			Text = string.Empty,
			Location = new Point(14, 72),
			AutoSize = true,
			ForeColor = Color.DimGray
		};
		base.Controls.Add(label_1);
		button_0 = new Button
		{
			Text = Class16.smethod_0(1648916975),
			Width = 90,
			Height = 30,
			Location = new Point(base.ClientSize.Width - 200, 110),
			Anchor = (AnchorStyles.Bottom | AnchorStyles.Right),
			Enabled = false
		};
		button_0.Click += button_0_Click;
		base.Controls.Add(button_0);
		button_1 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			Width = 90,
			Height = 30,
			Location = new Point(base.ClientSize.Width - 100, 110),
			Anchor = (AnchorStyles.Bottom | AnchorStyles.Right),
			DialogResult = DialogResult.Cancel
		};
		base.Controls.Add(button_1);
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		base.AcceptButton = button_0;
		base.CancelButton = button_1;
	}

	public void InitializeFromPreferences(params string[] scanPaths)
	{
		list_0.Clear();
		comboBox_0.Items.Clear();
		HashSet<string> hashSet_ = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		foreach (string text in scanPaths)
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				method_4(text, hashSet_);
			}
		}
		if (list_0.Count == 0)
		{
			label_1.Text = TextStorage.Msg(Class16.smethod_0(1649089597), Class16.smethod_0(1649089626));
			button_0.Enabled = false;
			return;
		}
		label_1.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649089696), Class16.smethod_0(1649089720)), list_0.Count);
		foreach (Class296 item in list_0)
		{
			comboBox_0.Items.Add(item);
		}
		comboBox_0.SelectedIndex = 0;
		button_0.Enabled = true;
	}

	public void SelectMap(string mapName)
	{
		if (string.IsNullOrWhiteSpace(mapName))
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < comboBox_0.Items.Count)
			{
				if (comboBox_0.Items[num] is Class296 @class && string.Equals(@class.method_0(), mapName, StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		comboBox_0.SelectedIndex = num;
	}

	private void method_4(string string_2, HashSet<string> hashSet_0)
	{
		if (!Directory.Exists(string_2))
		{
			return;
		}
		try
		{
			string[] files = Directory.GetFiles(string_2, Class16.smethod_0(1649089744), SearchOption.AllDirectories);
			string[] array = files;
			foreach (string path in array)
			{
				string fullPath = System.IO.Path.GetFullPath(path);
				if (hashSet_0.Add(fullPath))
				{
					string path2 = System.IO.Path.GetDirectoryName(path) ?? Class16.smethod_0(1648928036);
					string name = new DirectoryInfo(path2).Name;
					list_0.Add(new Class296(name, fullPath));
				}
			}
		}
		catch
		{
		}
	}

	private void method_5()
	{
		if (comboBox_0.SelectedItem is Class296 @class)
		{
			method_0(@class.method_1());
			method_1(@class.method_0());
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_5();
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		button_0.Enabled = comboBox_0.SelectedIndex >= 0;
	}
}
