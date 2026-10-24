using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.PWMap;

public sealed class PwMapPreferencesDialog : Form
{
	private sealed class Class297
	{
		public string string_0;

		public TextBox textBox_0;

		public Control control_0;

		internal void method_0(object sender, EventArgs e)
		{
			using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
			{
				Description = string_0
			};
			if (!string.IsNullOrWhiteSpace(textBox_0.Text) && Directory.Exists(textBox_0.Text))
			{
				folderBrowserDialog.SelectedPath = textBox_0.Text;
			}
			if (folderBrowserDialog.ShowDialog(control_0.FindForm()) == DialogResult.OK)
			{
				textBox_0.Text = folderBrowserDialog.SelectedPath;
			}
		}
	}

	private sealed class Class298
	{
		public PwMapPreferencesDialog pwMapPreferencesDialog_0;

		public Panel panel_0;

		internal void method_0(object sender, EventArgs e)
		{
			pwMapPreferencesDialog_0.DialogResult = DialogResult.Cancel;
			pwMapPreferencesDialog_0.Close();
		}

		internal void method_1(object sender, EventArgs e)
		{
			pwMapPreferencesDialog_0.method_6(bool_2: false);
		}

		internal void method_2(object sender, EventArgs e)
		{
			pwMapPreferencesDialog_0.method_6(bool_2: true);
		}

		internal void method_3(object sender, EventArgs e)
		{
			pwMapPreferencesDialog_0.button_2.Location = new Point(panel_0.ClientSize.Width - 100, 10);
			pwMapPreferencesDialog_0.button_1.Location = new Point(panel_0.ClientSize.Width - 200, 10);
			pwMapPreferencesDialog_0.button_0.Location = new Point(panel_0.ClientSize.Width - 300, 10);
		}

		internal void method_4(object sender, TreeViewEventArgs e)
		{
			pwMapPreferencesDialog_0.method_3(e.Node.Text);
		}
	}

	private sealed class Class299
	{
		public Panel panel_0;

		public Panel panel_1;

		public PwMapPreferencesDialog pwMapPreferencesDialog_0;

		internal void method_0(object sender, EventArgs e)
		{
			using ColorDialog colorDialog = new ColorDialog
			{
				Color = panel_0.BackColor,
				FullOpen = true,
				AllowFullOpen = true
			};
			if (colorDialog.ShowDialog(panel_1.FindForm()) == DialogResult.OK)
			{
				panel_0.BackColor = colorDialog.Color;
				pwMapPreferencesDialog_0.method_13(panel_0, colorDialog.Color);
			}
		}
	}

	private bool bool_0;

	private bool bool_1;

	private readonly PwMapPreferencesStore pwMapPreferencesStore_0;

	private TreeView treeView_0;

	private Panel panel_0;

	private Panel panel_1;

	private Panel panel_2;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private ComboBox comboBox_0;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private Panel panel_3;

	private Panel panel_4;

	private Color color_0;

	private Color color_1;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private Panel panel_5;

	private Panel panel_6;

	private Panel panel_7;

	private Panel panel_8;

	private Panel panel_9;

	private Panel panel_10;

	private Panel panel_11;

	private Panel panel_12;

	private Color color_2;

	private Color color_3;

	private Color color_4;

	private Color color_5;

	private Color color_6;

	private Color color_7;

	private Color color_8;

	public bool WasSaved
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
	}

	public bool NeedsRestart
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
	}

	public PwMapPreferencesDialog(PwMapPreferencesStore store)
	{
		pwMapPreferencesStore_0 = store ?? throw new ArgumentNullException(Class16.smethod_0(1649089225));
		Text = Class16.smethod_0(1649089244);
		base.Size = new Size(720, 400);
		base.StartPosition = FormStartPosition.CenterParent;
		base.FormBorderStyle = FormBorderStyle.Sizable;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.ShowInTaskbar = false;
		MinimumSize = new Size(600, 350);
		method_8();
		method_4();
		method_3(Class16.smethod_0(1649089262));
		treeView_0.SelectedNode = treeView_0.Nodes[0];
		method_2();
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0(bool bool_2)
	{
		bool_0 = bool_2;
	}

	private void method_1(bool bool_2)
	{
		bool_1 = bool_2;
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

	private void method_3(string string_0)
	{
		panel_1.Visible = string_0 == Class16.smethod_0(1649089262);
		panel_2.Visible = string_0 == Class16.smethod_0(1649089276);
		panel_5.Visible = string_0 == Class16.smethod_0(1649089282);
	}

	private void method_4()
	{
		PwMapGeneralSettings settings = pwMapPreferencesStore_0.Settings;
		textBox_0.Text = settings.ElementPath;
		textBox_1.Text = settings.ServerPath;
		textBox_2.Text = settings.WorkingPath;
		smethod_1(comboBox_0, settings.Language);
		checkBox_0.Checked = settings.SaveSideEffects;
		checkBox_1.Checked = settings.EnableShadowCalculation;
		checkBox_2.Checked = settings.VSync;
		PwMapNpcMapSettings npcMapSettings = pwMapPreferencesStore_0.NpcMapSettings;
		checkBox_3.Checked = npcMapSettings.ImmediateUpdate;
		color_0 = Color.FromArgb(npcMapSettings.PassColor);
		color_1 = Color.FromArgb(npcMapSettings.DenyColor);
		panel_3.BackColor = Color.FromArgb(255, color_0);
		panel_4.BackColor = Color.FromArgb(255, color_1);
		method_14();
	}

	private void method_5()
	{
		string elementPath = pwMapPreferencesStore_0.Settings.ElementPath;
		string serverPath = pwMapPreferencesStore_0.Settings.ServerPath;
		string workingPath = pwMapPreferencesStore_0.Settings.WorkingPath;
		string language = pwMapPreferencesStore_0.Settings.Language;
		PwMapGeneralSettings settings = pwMapPreferencesStore_0.Settings;
		settings.ElementPath = textBox_0.Text.Trim();
		settings.ServerPath = textBox_1.Text.Trim();
		settings.WorkingPath = textBox_2.Text.Trim();
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
				goto IL_00ba;
			}
		}
		obj = Class16.smethod_0(1649090288);
		goto IL_00ba;
		IL_00ba:
		settings.Language = (string)obj;
		settings.SaveSideEffects = checkBox_0.Checked;
		settings.EnableShadowCalculation = checkBox_1.Checked;
		settings.VSync = checkBox_2.Checked;
		PwMapNpcMapSettings npcMapSettings = pwMapPreferencesStore_0.NpcMapSettings;
		npcMapSettings.ImmediateUpdate = checkBox_3.Checked;
		npcMapSettings.PassColor = color_0.ToArgb();
		npcMapSettings.DenyColor = color_1.ToArgb();
		method_15();
		pwMapPreferencesStore_0.Save();
		method_1(!string.Equals(elementPath, settings.ElementPath, StringComparison.OrdinalIgnoreCase) || !string.Equals(serverPath, settings.ServerPath, StringComparison.OrdinalIgnoreCase) || !string.Equals(workingPath, settings.WorkingPath, StringComparison.OrdinalIgnoreCase) || !string.Equals(language, settings.Language, StringComparison.OrdinalIgnoreCase));
	}

	private void method_6(bool bool_2)
	{
		if (!string.IsNullOrWhiteSpace(textBox_0.Text) && !string.IsNullOrWhiteSpace(textBox_1.Text) && !string.IsNullOrWhiteSpace(textBox_2.Text))
		{
			method_5();
			method_0(bool_2: true);
			if (bool_2)
			{
				base.DialogResult = DialogResult.OK;
				Close();
				method_7();
			}
			else
			{
				method_7();
			}
		}
		else
		{
			MessageBox.Show(this, Class16.smethod_0(1649089298), Class16.smethod_0(1649089244), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void method_7()
	{
		if (NeedsRestart)
		{
			DialogResult dialogResult = MessageBox.Show(Class16.smethod_0(1649089373), Class16.smethod_0(1649089465), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				Application.Restart();
			}
		}
	}

	private static void smethod_0(Panel panel_13, string string_0, ref Color color_9)
	{
		using ColorDialog colorDialog = new ColorDialog
		{
			Color = panel_13.BackColor,
			FullOpen = true,
			AllowFullOpen = true
		};
		if (colorDialog.ShowDialog() == DialogResult.OK)
		{
			color_9 = colorDialog.Color;
			panel_13.BackColor = colorDialog.Color;
		}
	}

	private static void smethod_1(ComboBox comboBox_1, string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < comboBox_1.Items.Count)
			{
				if (string.Equals(comboBox_1.Items[num].ToString(), string_0, StringComparison.OrdinalIgnoreCase))
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

	private void method_8()
	{
		Class298 @class = new Class298();
		@class.pwMapPreferencesDialog_0 = this;
		@class.panel_0 = new Panel
		{
			Dock = DockStyle.Bottom,
			Height = 50,
			Padding = new Padding(8, 8, 8, 8)
		};
		button_2 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			Width = 90,
			Height = 30,
			Anchor = (AnchorStyles.Bottom | AnchorStyles.Right)
		};
		button_2.Click += @class.method_0;
		button_1 = new Button
		{
			Text = Class16.smethod_0(1648941761),
			Width = 90,
			Height = 30,
			Anchor = (AnchorStyles.Bottom | AnchorStyles.Right)
		};
		button_1.Click += @class.method_1;
		button_0 = new Button
		{
			Text = Class16.smethod_0(1649014457),
			Width = 90,
			Height = 30,
			Anchor = (AnchorStyles.Bottom | AnchorStyles.Right)
		};
		button_0.Click += @class.method_2;
		button_2.Location = new Point(@class.panel_0.ClientSize.Width - 100, 10);
		button_1.Location = new Point(@class.panel_0.ClientSize.Width - 200, 10);
		button_0.Location = new Point(@class.panel_0.ClientSize.Width - 300, 10);
		@class.panel_0.Controls.AddRange(new Control[3] { button_0, button_1, button_2 });
		@class.panel_0.Resize += @class.method_3;
		base.Controls.Add(@class.panel_0);
		treeView_0 = new TreeView
		{
			Dock = DockStyle.Left,
			Width = 150,
			HideSelection = false,
			ShowLines = false,
			FullRowSelect = true,
			ItemHeight = 24
		};
		treeView_0.Nodes.Add(Class16.smethod_0(1649089262));
		treeView_0.Nodes.Add(Class16.smethod_0(1649089276));
		treeView_0.Nodes.Add(Class16.smethod_0(1649089282));
		treeView_0.AfterSelect += @class.method_4;
		base.Controls.Add(treeView_0);
		panel_0 = new Panel
		{
			Dock = DockStyle.Fill,
			Padding = new Padding(12, 8, 12, 4)
		};
		base.Controls.Add(panel_0);
		panel_0.BringToFront();
		method_9();
		method_10();
		method_11();
		base.CancelButton = button_2;
	}

	private void method_9()
	{
		panel_1 = new Panel
		{
			Dock = DockStyle.Fill,
			Visible = false,
			AutoScroll = true
		};
		panel_0.Controls.Add(panel_1);
		int num = 8;
		Label value = new Label
		{
			Text = Class16.smethod_0(1649089488),
			Font = new Font(Font.FontFamily, 10f, FontStyle.Bold),
			Location = new Point(4, 8),
			AutoSize = true
		};
		panel_1.Controls.Add(value);
		num = 36;
		Label value2 = new Label
		{
			BorderStyle = BorderStyle.Fixed3D,
			Location = new Point(4, 36),
			Size = new Size(460, 2)
		};
		panel_1.Controls.Add(value2);
		num = 48;
		smethod_2(Class16.smethod_0(1649089519), ref num, 4, 420, panel_1, out textBox_0);
		smethod_2(Class16.smethod_0(1649088524), ref num, 4, 420, panel_1, out textBox_1);
		smethod_2(Class16.smethod_0(1649088551), ref num, 4, 420, panel_1, out textBox_2);
		num += 6;
		Label value3 = new Label
		{
			Text = Class16.smethod_0(1649022364),
			ForeColor = Color.Gold,
			Location = new Point(4, num + 3),
			AutoSize = true,
			Visible = false
		};
		panel_1.Controls.Add(value3);
		comboBox_0 = new ComboBox
		{
			DropDownStyle = ComboBoxStyle.DropDownList,
			Location = new Point(84, num),
			Width = 80,
			MaxDropDownItems = 9,
			Visible = false
		};
		comboBox_0.Items.AddRange(new object[6]
		{
			Class16.smethod_0(1649090288),
			Class16.smethod_0(1649088580),
			Class16.smethod_0(1649088589),
			Class16.smethod_0(1649088598),
			Class16.smethod_0(1649088607),
			Class16.smethod_0(1648941057)
		});
		comboBox_0.SelectedIndex = 0;
		panel_1.Controls.Add(comboBox_0);
		num += 30;
		checkBox_0 = new CheckBox
		{
			Text = Class16.smethod_0(1649088608),
			Location = new Point(4, num),
			AutoSize = true
		};
		panel_1.Controls.Add(checkBox_0);
		num += 24;
		checkBox_1 = new CheckBox
		{
			Text = Class16.smethod_0(1649088641),
			Location = new Point(4, num),
			AutoSize = true
		};
		panel_1.Controls.Add(checkBox_1);
		num += 24;
		checkBox_2 = new CheckBox
		{
			Text = Class16.smethod_0(1649088673),
			Checked = true,
			Location = new Point(4, num),
			AutoSize = true
		};
		panel_1.Controls.Add(checkBox_2);
		num += 32;
		Label value4 = new Label
		{
			Text = Class16.smethod_0(1649088700),
			ForeColor = Color.Gold,
			Location = new Point(4, num),
			AutoSize = true
		};
		panel_1.Controls.Add(value4);
	}

	private void method_10()
	{
		panel_2 = new Panel
		{
			Dock = DockStyle.Fill,
			Visible = false,
			AutoScroll = true
		};
		panel_0.Controls.Add(panel_2);
		Label value = new Label
		{
			Text = Class16.smethod_0(1649088729),
			Font = new Font(Font.FontFamily, 10f, FontStyle.Bold),
			Location = new Point(4, 8),
			AutoSize = true
		};
		panel_2.Controls.Add(value);
		Label value2 = new Label
		{
			BorderStyle = BorderStyle.Fixed3D,
			Location = new Point(4, 36),
			Size = new Size(460, 2)
		};
		panel_2.Controls.Add(value2);
		checkBox_3 = new CheckBox
		{
			Text = Class16.smethod_0(1649088752),
			Location = new Point(4, 48),
			AutoSize = true
		};
		panel_2.Controls.Add(checkBox_3);
		Label value3 = new Label
		{
			Text = Class16.smethod_0(1649088783),
			ForeColor = Color.Gold,
			Location = new Point(4, 81),
			AutoSize = true
		};
		panel_2.Controls.Add(value3);
		panel_3 = new Panel
		{
			Location = new Point(104, 78),
			Size = new Size(28, 28),
			BorderStyle = BorderStyle.FixedSingle,
			BackColor = Color.Green,
			Cursor = Cursors.Hand
		};
		panel_3.Click += panel_3_Click;
		panel_2.Controls.Add(panel_3);
		Label value4 = new Label
		{
			Text = Class16.smethod_0(1649088793),
			ForeColor = Color.Gold,
			Location = new Point(4, 117),
			AutoSize = true
		};
		panel_2.Controls.Add(value4);
		panel_4 = new Panel
		{
			Location = new Point(104, 114),
			Size = new Size(28, 28),
			BorderStyle = BorderStyle.FixedSingle,
			BackColor = Color.Red,
			Cursor = Cursors.Hand
		};
		panel_4.Click += panel_4_Click;
		panel_2.Controls.Add(panel_4);
		Label value5 = new Label
		{
			Text = Class16.smethod_0(1649088700),
			ForeColor = Color.Gold,
			Location = new Point(4, 154),
			AutoSize = true
		};
		panel_2.Controls.Add(value5);
	}

	private static void smethod_2(string string_0, ref int int_0, int int_1, int int_2, Control control_0, out TextBox textBox_3)
	{
		Class297 @class = new Class297();
		@class.string_0 = string_0;
		@class.control_0 = control_0;
		Label value = new Label
		{
			Text = @class.string_0,
			Location = new Point(int_1, int_0),
			AutoSize = true
		};
		@class.control_0.Controls.Add(value);
		int_0 += 20;
		textBox_3 = new TextBox
		{
			Location = new Point(int_1, int_0),
			Width = int_2,
			Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)
		};
		@class.control_0.Controls.Add(textBox_3);
		Button button = new Button
		{
			Text = Class16.smethod_0(1648924410),
			Width = 30,
			Height = 23,
			Location = new Point(int_1 + int_2 + 4, int_0),
			Anchor = (AnchorStyles.Top | AnchorStyles.Right)
		};
		@class.textBox_0 = textBox_3;
		button.Click += @class.method_0;
		@class.control_0.Controls.Add(button);
		int_0 += 30;
	}

	private void method_11()
	{
		panel_5 = new Panel
		{
			Dock = DockStyle.Fill,
			Visible = false,
			AutoScroll = true
		};
		panel_0.Controls.Add(panel_5);
		int num = 8;
		Label value = new Label
		{
			Text = Class16.smethod_0(1649088811),
			Font = new Font(Font.FontFamily, 10f, FontStyle.Bold),
			Location = new Point(4, 8),
			AutoSize = true
		};
		panel_5.Controls.Add(value);
		num = 36;
		Label value2 = new Label
		{
			BorderStyle = BorderStyle.Fixed3D,
			Location = new Point(4, 36),
			Size = new Size(460, 2)
		};
		panel_5.Controls.Add(value2);
		num = 48;
		Label value3 = new Label
		{
			Text = Class16.smethod_0(1649088845),
			ForeColor = Color.Silver,
			Location = new Point(4, 48),
			AutoSize = true
		};
		panel_5.Controls.Add(value3);
		num = 86;
		method_12(Class16.smethod_0(1649088931), ref num, 4, panel_5, ref color_2, out panel_6);
		method_12(Class16.smethod_0(1649088946), ref num, 4, panel_5, ref color_3, out panel_7);
		method_12(Class16.smethod_0(1649088962), ref num, 4, panel_5, ref color_4, out panel_8);
		method_12(Class16.smethod_0(1649088983), ref num, 4, panel_5, ref color_5, out panel_9);
		method_12(Class16.smethod_0(1649088996), ref num, 4, panel_5, ref color_6, out panel_10);
		method_12(Class16.smethod_0(1649089007), ref num, 4, panel_5, ref color_7, out panel_11);
		method_12(Class16.smethod_0(1649089020), ref num, 4, panel_5, ref color_8, out panel_12);
		num += 10;
		Label value4 = new Label
		{
			Text = Class16.smethod_0(1649083905),
			ForeColor = Color.Gold,
			Location = new Point(4, num),
			AutoSize = true
		};
		panel_5.Controls.Add(value4);
	}

	private void method_12(string string_0, ref int int_0, int int_1, Panel panel_13, ref Color color_9, out Panel panel_14)
	{
		Class299 @class = new Class299();
		@class.panel_1 = panel_13;
		@class.pwMapPreferencesDialog_0 = this;
		Label value = new Label
		{
			Text = string_0,
			ForeColor = Color.Silver,
			Location = new Point(int_1, int_0 + 4),
			AutoSize = true
		};
		@class.panel_1.Controls.Add(value);
		panel_14 = new Panel
		{
			Location = new Point(int_1 + 100, int_0),
			Size = new Size(28, 28),
			BorderStyle = BorderStyle.FixedSingle,
			BackColor = Color.FromArgb(255, color_9),
			Cursor = Cursors.Hand
		};
		@class.panel_0 = panel_14;
		panel_14.Click += @class.method_0;
		@class.panel_1.Controls.Add(panel_14);
		int_0 += 34;
	}

	private void method_13(Panel panel_13, Color color_9)
	{
		if (panel_13 == panel_6)
		{
			color_2 = color_9;
		}
		else if (panel_13 == panel_7)
		{
			color_3 = color_9;
		}
		else if (panel_13 == panel_8)
		{
			color_4 = color_9;
		}
		else if (panel_13 == panel_9)
		{
			color_5 = color_9;
		}
		else if (panel_13 == panel_10)
		{
			color_6 = color_9;
		}
		else if (panel_13 == panel_11)
		{
			color_7 = color_9;
		}
		else if (panel_13 == panel_12)
		{
			color_8 = color_9;
		}
	}

	private void method_14()
	{
		PwMapCameraSettings cameraSettings = pwMapPreferencesStore_0.CameraSettings;
		color_2 = Color.FromArgb(cameraSettings.ColorModeTerrain);
		color_3 = Color.FromArgb(cameraSettings.ColorModeLitModel);
		color_4 = Color.FromArgb(cameraSettings.ColorModeWater);
		color_5 = Color.FromArgb(cameraSettings.ColorModeFlora);
		color_6 = Color.FromArgb(cameraSettings.ColorModeGfx);
		color_7 = Color.FromArgb(cameraSettings.ColorModeLight);
		color_8 = Color.FromArgb(cameraSettings.ColorModeGrass);
		if (panel_6 != null)
		{
			panel_6.BackColor = Color.FromArgb(255, color_2);
		}
		if (panel_7 != null)
		{
			panel_7.BackColor = Color.FromArgb(255, color_3);
		}
		if (panel_8 != null)
		{
			panel_8.BackColor = Color.FromArgb(255, color_4);
		}
		if (panel_9 != null)
		{
			panel_9.BackColor = Color.FromArgb(255, color_5);
		}
		if (panel_10 != null)
		{
			panel_10.BackColor = Color.FromArgb(255, color_6);
		}
		if (panel_11 != null)
		{
			panel_11.BackColor = Color.FromArgb(255, color_7);
		}
		if (panel_12 != null)
		{
			panel_12.BackColor = Color.FromArgb(255, color_8);
		}
	}

	private void method_15()
	{
		PwMapCameraSettings cameraSettings = pwMapPreferencesStore_0.CameraSettings;
		cameraSettings.ColorModeTerrain = color_2.ToArgb();
		cameraSettings.ColorModeLitModel = color_3.ToArgb();
		cameraSettings.ColorModeWater = color_4.ToArgb();
		cameraSettings.ColorModeFlora = color_5.ToArgb();
		cameraSettings.ColorModeGfx = color_6.ToArgb();
		cameraSettings.ColorModeLight = color_7.ToArgb();
		cameraSettings.ColorModeGrass = color_8.ToArgb();
	}

	private void panel_3_Click(object sender, EventArgs e)
	{
		smethod_0(panel_3, Class16.smethod_0(1649083946), ref color_0);
	}

	private void panel_4_Click(object sender, EventArgs e)
	{
		smethod_0(panel_4, Class16.smethod_0(1649083963), ref color_1);
	}
}
